using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Biohazard.BioRand.RE7.Modifiers;

using ReplacementData = (ItemID Id, int Quantity, int Coins, ImmutableArray<string> ValidItemIDs);

internal class BirdCageModifier : Modifier
{
    private const string RandomizerKey = "modifier/bird-cage";

    private readonly List<string> _birdCageScnFiles = [
        "environment/scene/chapter3/c03_trailerhouse.scn",
        "leveldesign/itemset/chapter3/mainhouse_hall/hard.scn", // Madhouse
        "environment/scene/chapter4/c04_cottage.scn",
        "leveldesign/itemset/chapter4/shipoutside/hard.scn", // Madhouse
        // DLCs
        //@"environment\scene\chapter7\c07_gimmickobject_reset_7_1.scn.20",
        //@"environment\scene\chapter7\c07_mainhouse2fstoreroom_7_1.scn.20",
        //@"ch8\environment\scene\chapter8\c08_mine01.scn.20",
    ];

    private readonly Regex _birdCageRegex = new Regex("^sm.*CoinBox((?!Interact).)*$", RegexOptions.Compiled);
    private readonly static ItemDefinitionRepository _items = ItemDefinitionRepository.Default;
    internal static readonly string[] _defaultInsertItems = ["Coin", "CoinOld"];

    private enum ReplacementCategory
    {
        Magnum,
        Drug,
    }

    private record BirdCageReplacement
    {
        public ReplacementCategory Category { get; init; }
        public ItemID ItemId { get; init; }
        public int Min { get; init; }
        public int Max { get; init; }
        public int Coins { get; init; }
        public ImmutableArray<string> InputItemIds { get; init; }

        public BirdCageReplacement() { }
    }

    private ReplacementData GetReplacement(ImmutableList<BirdCageReplacement> replacements, ReplacementCategory category, Rng rng)
    {
        var filtered = replacements.Where(r => r.Category == category).ToList();
        var replacement = rng.Next(filtered);
        return (replacement.ItemId, rng.Next(replacement.Min, replacement.Max), replacement.Coins, replacement.InputItemIds);
    }

    private void RandomizeBirdCageContent(ImmutableList<BirdCageReplacement> replacements, Rng rng, BirdCage birdCage, ReplacementCategory category, Randomizer randomizer)
    {
        var replacementData = GetReplacement(replacements, category, rng);
        birdCage.Item.ItemDataID = replacementData.Id.ToString();
        birdCage.Item.ItemStackNum = replacementData.Quantity;
        birdCage.CoinCounter.CoinMax = replacementData.Coins;

        // TODO Test this properly
        if (!replacementData.ValidItemIDs.SequenceEqual(_defaultInsertItems))
        {
            birdCage.ItemSelectReaction.ReactionSettings.Clear();

            foreach (var id in replacementData.ValidItemIDs)
            {
                birdCage.ItemSelectReaction.ReactionSettings.Add(new app.ItemSelectReaction.ReactionSetting()
                {
                    ItemID = id,
                    StateName = "InsertCoin",
                    Result = Enums.app.ItemSelectReaction.Result.Success,
                });
            }

            birdCage.ItemSelectReaction.Enabled = true;
        }

        birdCage.Serialize(randomizer);
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var csv = randomizer.DynamicData.GetData(DynamicDataName.BirdCages) ?? throw new Exception("Unable to get bird cage data");
        var replacements = Csv.Deserialize<BirdCageReplacement>(csv)
            .ToImmutableList();

        var randomizeMagnum = randomizer.GetConfigOption<bool>("random-bird-cage-magnum");
        var randomizeDrugsAndPowerCoins = randomizer.GetConfigOption<bool>("random-bird-cage-drugs-coins");
        var preserveItemModels = randomizer.GetConfigOption<bool>("preserve-item-models");
        var rng = randomizer.GetRng(RandomizerKey);
        var birdCages = new List<BirdCage>();

        foreach (var file in _birdCageScnFiles)
        {
            var path = PakPath.SceneFile(file);
            var content = randomizer.FileRepository.GetFile(path);
            var scnFile = new ScnFile(randomizer.IsOnRaytracingVersion ? FileVersions.SceneFileVersionRT : FileVersions.SceneFileVersionNonRT, content)
                            .ReadScene(randomizer.FileRepository.TypeRepository);

            scnFile.VisitGameObjects(gameObject =>
            {
                if (_birdCageRegex.IsMatch(gameObject.Name))
                {
                    var birdCage = new BirdCage(randomizer, path, gameObject, preserveItemModels);
                    birdCages.Add(birdCage);

                    var isMagnum = gameObject.Name.EndsWith("Magnum");
                    if (isMagnum && randomizeMagnum || randomizeDrugsAndPowerCoins)
                    {
                        var category = isMagnum ? ReplacementCategory.Magnum : ReplacementCategory.Drug;
                        RandomizeBirdCageContent(replacements, rng, birdCage, category, randomizer);
                    }
                }
            });
        }

        foreach (var birdCage in birdCages)
        {
            var (beforeItemCount, beforeItemId, beforeCoinCounter) = birdCage.BeforeRandomizationState;
            var beforeName = _items.FromId(beforeItemId)!.Name;
            var afterName = _items.FromId(birdCage.Item.ItemDataID)!.Name;
            logger.LogLine($"[{birdCage.PakPath}] Replaced {beforeItemCount}x {beforeName} that cost {beforeCoinCounter} antique coins in bird cage with " +
                $"{birdCage.Item.ItemStackNum}x {afterName} that costs {birdCage.CoinCounter.CoinMax} antique coins");
        }
    }
}

internal class BirdCage
{
    public Randomizer Randomizer { get; }
    public string PakPath { get; }
    public bool PreserveItemModels { get; }
    public Guid ContainerGuid { get; }

    public app.Item Item { get; }
    public app.ItemSelectReaction ItemSelectReaction { get; }
    public app.CoinCounter CoinCounter { get; }

    public (int, string, int) BeforeRandomizationState { get; }

    public BirdCage(Randomizer randomizer, string path, RszGameObject container, bool preserveItemModels)
    {
        Randomizer = randomizer;
        PakPath = path;
        PreserveItemModels = preserveItemModels;
        ContainerGuid = container.Guid;

        var gimmick = container.Children
            .First(child => child.Name.EndsWith("_Gimmick"));

        ItemSelectReaction = gimmick.FindComponent<app.ItemSelectReaction>()!;
        CoinCounter = gimmick.FindComponent<app.CoinCounter>()!;

        Item = container.Children
            .First(child => child.FindComponent<app.Item>() != null)
            .FindComponent<app.Item>()!;

        BeforeRandomizationState = (Item.ItemStackNum, Item.ItemDataID, CoinCounter.CoinMax);
    }

    public void Serialize(Randomizer randomizer)
    {
        Randomizer.FileRepository.ModifyScnFile(PakPath, randomizer.IsOnRaytracingVersion, scene =>
        {
            var container = scene.FindGameObject(go => go.Guid == ContainerGuid)!;

            var gimmick = container.Children
                .First(child => child.Name.EndsWith("_Gimmick"));

            var itemHolder = container.Children
                .First(child => child.FindComponent<app.Item>() != null);

            var newGimmick = gimmick
                .AddOrUpdateComponent(ItemSelectReaction)
                .AddOrUpdateComponent(CoinCounter);

            var newItemHolder = itemHolder
                .AddOrUpdateComponent(Item);

            if (!PreserveItemModels)
            {
                var mesh = newItemHolder.FindComponent("via.render.Mesh")!;
                var newItem = randomizer.ItemPlacementService.FromId(Item.ItemDataID).First();

                mesh = mesh
                    .Set("Mesh", new RszResourceNode(newItem.Mesh))
                    .Set("Material", new RszResourceNode(newItem.Material));

                newItemHolder = newItemHolder.AddOrUpdateComponent(mesh);
            }

            container = container.AddOrUpdateChild(newGimmick);
            container = container.AddOrUpdateChild(newItemHolder);
            scene = scene.UpdateGameObject(container);
            return scene;
        });
    }
}