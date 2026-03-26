using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class StaticItemModifier : Modifier
{
    private const string RandomizerKey = "modifier/static-items";

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng(RandomizerKey);
        var itemRandomizer = randomizer.ItemRandomizer;
        var itemPlacementService = randomizer.ItemPlacementService;
        var randomizableItems = itemPlacementService.PlacementToItemMap
                            .Where(x => x.Value != null)
                            .Where(x => itemRandomizer.IsItemAllowed(x.Value))
                            .ToList();
        var randomItemSettings = new RandomItemSettings()
        {
            MinAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-min", 0.1),
            MaxAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-max", 1.0),
            ItemRatioKeyFunc = (id) => randomizer.GetConfigOption<double>($"item-drop-ratio-{id.ToString().ToLowerInvariant()}")
        };

        foreach (var (placement, definition) in randomizableItems)
        {
            // TODO Handle extra placements
            if (placement.IsExtra || placement == null || definition == null)
            {
                continue;
            }

            randomizer.FileRepository.ModifyScnFile(placement.Container, randomizer.IsOnRaytracingVersion, scene =>
            {
                var gameObject = scene.FindGameObject(placement.Guid)!;
                var itemComponent = gameObject.FindComponent<app.Item>()!;
                var drop = itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);
                logger.LogLine($"Replacing {itemComponent.ItemStackNum}x {itemComponent.ItemDataID} at {placement.Position} with " +
                    $"[{drop.CountEasy}, {drop.CountNormal}, {drop.CountMadhouse}]x {drop.Id}");

                itemComponent.ItemDataID = drop.Id;
                itemComponent.ItemStackNum = drop.CountNormal;
                itemComponent._DifficultItemNumSetting.EasyNum = drop.CountEasy;
                itemComponent._DifficultItemNumSetting.HardNum = drop.CountMadhouse;
                gameObject = gameObject.AddOrUpdateComponent(itemComponent);

                var preserveItemModels = randomizer.GetConfigOption<bool>("preserve-item-models");
                if (!preserveItemModels)
                {
                    var mesh = gameObject.FindComponent("via.render.Mesh");

                    if (mesh != null)
                    {
                        var newItem = randomizer.ItemPlacementService.FromId(definition.Id).First();
                        mesh = mesh
                            .Set("Mesh", new RszResourceNode(newItem.Mesh))
                            .Set("Material", new RszResourceNode(newItem.Material));
                        gameObject = gameObject.AddOrUpdateComponent(mesh);
                    }
                }

                scene = scene.UpdateGameObject(gameObject);
                return scene;
            });
        }
    }
}