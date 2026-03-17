using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Services;
using Enums.app;
using IntelOrca.Biohazard.REE.Rsz;
using System.Text.RegularExpressions;

namespace Biohazard.BioRand.RE7.Modifiers;

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

    // TODO: Extract these to a CSV?

    // (id, min #, max #, coin #)
    private readonly List<(ItemID, int, int, int)> _magnumReplacements = [
        (ItemID.HandgunBulletL, 20, 30, 3),
        (ItemID.ShotgunBullet, 12, 18, 4),
        (ItemID.Gunpowder, 6, 10, 3),
        (ItemID.ChemicalS, 3, 5, 3),
        (ItemID.LiquidBomb, 2, 4, 5),
        (ItemID.FlameBulletS, 3, 6, 5),
        (ItemID.AcidBulletS, 3, 6, 5),
        (ItemID.MachineGunBullet, 40, 60, 5),
        (ItemID.Stimulant, 1, 1, 6),
        (ItemID.Depressant, 1, 1, 6),
    ];

    // (id, min #, max #, coin #)
    private readonly List<(ItemID, int, int, int)> _drugAndCoinReplacements = [
        (ItemID.Herb, 3, 6, 2),
        (ItemID.RemedyM, 2, 4, 2),
        (ItemID.RemedyL, 1, 3, 3),
        (ItemID.Gunpowder, 3, 6, 2),
        (ItemID.ChemicalS, 2, 4, 2),
        (ItemID.MiaKnife, 1, 1, 3),
        (ItemID.ShotgunBullet, 8, 12, 3),
        (ItemID.HandgunBullet, 15, 25, 2),
        (ItemID.HandgunBulletL, 10, 15, 2),
        (ItemID.MachineGun, 1, 1, 7),
        (ItemID.MagnumBullet, 4, 6, 7),
    ];

    private (ItemID Id, int Quantity, int Coins) GetReplacement(bool isMagnum, Rng rng)
    {
        var (itemId, min, max, Coins) = rng.Next(isMagnum ? _magnumReplacements : _drugAndCoinReplacements);
        return (itemId, rng.Next(min, max), Coins);
    }

    private void RandomizeBirdCageContent(Rng rng, BirdCage birdCage, bool isMagnum, Randomizer randomizer)
    {
        (ItemID Id, int Quantity, int Coins) = GetReplacement(isMagnum, rng);
        birdCage.Item.ItemDataID = Id.ToString();
        birdCage.Item.ItemStackNum = Quantity;
        birdCage.CoinCounter.CoinMax = Coins;
        birdCage.Serialize(randomizer);
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
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
                        RandomizeBirdCageContent(rng, birdCage, isMagnum, randomizer);
                    }
                }
            });
        }

        foreach(var birdCage in birdCages)
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
                var newItem = randomizer.GetService<ItemService>().FromId(Item.ItemDataID).First();

                mesh = mesh
                    .Set("Mesh", new RszResourceNode(newItem.Mesh))
                    .Set("Material", new RszResourceNode(newItem.Material));

                newItemHolder = newItemHolder.AddOrUpdateComponent(mesh);
                // TODO: Improve rotation for certain replacements, e.g. shotgun shells
            }

            container = container.AddOrUpdateChild(newGimmick);
            container = container.AddOrUpdateChild(newItemHolder);
            scene = scene.UpdateGameObject(container);
            return scene;
        });
    }
}