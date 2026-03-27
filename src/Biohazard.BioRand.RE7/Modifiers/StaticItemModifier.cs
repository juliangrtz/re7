using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class StaticItemModifier : Modifier
{
    private const string RandomizerKey = "modifier/static-items";

    private readonly static ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-items"))
            return;

        var rng = randomizer.GetRng(RandomizerKey);
        var itemRandomizer = randomizer.ItemRandomizer;
        var itemPlacementService = randomizer.ItemPlacementService;
        var areaService = randomizer.AreaService;
        var templateService = randomizer.TemplateService;
        var randomizableItems = areaService.Areas
                            .Where(area => area.Definition.Dlc == null)
                            .Where(area => area.Items.Any()) // TODO Handle weapons
                            .SelectMany(area => area.Items)
                            .ToList();
        var randomItemSettings = new RandomItemSettings()
        {
            MinAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-min", 0.1),
            MaxAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-max", 1.0),
            ItemRatioKeyFunc = (id) => randomizer.GetConfigOption<double>($"item-drop-ratio-{id.ToString().ToLowerInvariant()}")
        };

        foreach (var item in randomizableItems)
        {
            // TODO Handle extra placements
            var placement = itemPlacementService.FromGuid(item.Guid);
            var definition = _itemDefinitions.FromId(placement.Id);

            if (placement == null ||
                placement.IsExtra ||
                definition == null ||
                !placement.Enabled ||
                !itemRandomizer.IsItemAllowed(definition))
            {
                continue;
            }

            randomizer.FileRepository.ModifyScnFile(placement.Container, randomizer.IsOnRaytracingVersion, scene =>
            {
                var originalGameObject = scene.FindGameObject(placement.Guid)!;
                var originalTransform = originalGameObject.FindComponent<via.Transform>();
                var itemComponent = originalGameObject.FindComponent<app.Item>()!;
                var drop = itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);
                logger.LogLine($"[{placement.Container}] Replacing {itemComponent.ItemStackNum}x {itemComponent.ItemDataID} at {placement.Position} with " +
                    $"[{drop.CountEasy}, {drop.CountNormal}, {drop.CountMadhouse}]x {drop.Id}...");

                itemComponent.ItemDataID = drop.Id;
                itemComponent.ItemStackNum = drop.CountNormal;
                itemComponent._IsOverwriteDifficultItemNumSetting = true;
                itemComponent._DifficultItemNumSetting.EasyNum = drop.CountEasy;
                itemComponent._DifficultItemNumSetting.HardNum = drop.CountMadhouse;
                originalGameObject = originalGameObject.AddOrUpdateComponent(itemComponent);

                var newGameObject = templateService.GetItemTemplate(drop.Id);
                newGameObject = newGameObject.WithGuid(originalGameObject.Guid);
                newGameObject = newGameObject.AddOrUpdateComponent(originalTransform);
                newGameObject = newGameObject.AddOrUpdateComponent(itemComponent);

                if (randomizer.GetConfigOption<bool>("preserve-item-models"))
                {
                    var mesh = originalGameObject.FindComponent("via.render.Mesh");
                    if (mesh != null)
                    {
                        newGameObject = newGameObject.AddOrUpdateComponent(mesh);
                    }
                }

                scene = scene.ReplaceGameObject(originalGameObject.Guid, newGameObject);

                return scene;
            });
        }


    }
}