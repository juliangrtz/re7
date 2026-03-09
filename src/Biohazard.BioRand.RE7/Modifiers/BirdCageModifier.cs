using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
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

    private readonly List<(ItemID, int)> _magnumReplacements = [
        (ItemID.HandgunBulletL, 40),
        (ItemID.ShotgunBullet, 20),
        (ItemID.LiquidBomb, 5)
    ];

    private (ItemID Id, int Quantity) GetMagnumReplacement(Rng rng)
        => rng.Next(_magnumReplacements);

    private (ItemID Id, int Quantity) GetReplacement(Rng rng)
        => rng.Next(_magnumReplacements); // TODO

    private void RandomizeBirdCageContent(Rng rng, BirdCage birdCage, bool isMagnum)
    {
        (ItemID Id, int Quantity) = isMagnum ? GetMagnumReplacement(rng) : GetReplacement(rng);
        birdCage.Item.ItemDataID = Id.ToString();
        birdCage.Item.ItemStackNum = Quantity;
        birdCage.Serialize();
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var randomizeMagnum = randomizer.GetConfigOption<bool>("random-bird-cage-magnum");
        var randomizeDrugsAndPowerCoins = randomizer.GetConfigOption<bool>("random-bird-cage-drugs-coins");
        var preserveItemModels = randomizer.GetConfigOption<bool>("preserve-item-models");
        var rng = randomizer.GetRng(RandomizerKey);

        foreach (var file in _birdCageScnFiles)
        {
            var path = PakPath.ScnFile(file);
            var content = randomizer.FileRepository.GetFile(path);
            var scnFile = new ScnFile(Constants.SceneFileVersion, content).ReadScene(randomizer.FileRepository.TypeRepository);

            scnFile.VisitGameObjects(gameObject =>
            {
                if (_birdCageRegex.IsMatch(gameObject.Name))
                {
                    var birdCage = new BirdCage(randomizer, path, gameObject, preserveItemModels);
                    var isMagnum = gameObject.Name.EndsWith("Magnum");
                    if (isMagnum && randomizeMagnum || randomizeDrugsAndPowerCoins)
                    {
                        RandomizeBirdCageContent(rng, birdCage, isMagnum);
                    }
                }
            });
        }
    }
}

internal class BirdCage
{
    private static readonly ItemPlacementRepository Items = ItemPlacementRepository.Default;

    public Randomizer Randomizer { get; }
    public string PakPath { get; }
    public bool PreserveItemModels { get; }
    public Guid ContainerGuid { get; }

    public app.Item Item { get; }
    public app.ItemSelectReaction ItemSelectReaction { get; }
    public app.CoinCounter CoinCounter { get; }

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
    }

    public void Serialize()
    {
        Randomizer.FileRepository.ModifyScnFile(PakPath, scene =>
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
                var newItem = Items.FromId(Item.ItemDataID).First();

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