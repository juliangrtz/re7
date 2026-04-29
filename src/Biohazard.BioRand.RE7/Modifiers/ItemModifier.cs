using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class ItemModifier : Modifier
{
    private readonly static ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;
    private readonly static HashSet<Guid> _birdCageGuids = [.. BirdCageModifier.Guids];

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-items"))
            return;

        var context = randomizer.StaticItemRandomizationService;
        var rng = context.Rng;
        var itemRandomizer = randomizer.ItemRandomizer;
        var itemPlacementService = randomizer.ItemPlacementService;
        var areaService = randomizer.AreaService;
        var templateService = randomizer.TemplateService;
        var replaceMadhouseTapes = randomizer.GetConfigOption<bool>("replace-madhouse-tapes");
        var replaceWeapons = randomizer.GetConfigOption<bool>("replace-weapons");
        var preserveItemModels = randomizer.GetConfigOption<bool>("preserve-item-models");
        var randomItemSettings = context.RandomItemSettings;

        // Normal items
        foreach (var area in areaService.Areas)
        {
            var randomizableItems = new List<(ItemDefinition Definition, ItemPlacement Placement)>();
            foreach (var itemGameObject in area.Items)
            {
                foreach (var placement in itemPlacementService.FromSceneGuid(area.Path, itemGameObject.Guid))
                {
                    if (placement.Dlc != null
                        || placement.IsExtra
                        || !placement.Enabled
                        || placement.Tags.Contains(ItemPlacement.ExcludeTag)
                        || _birdCageGuids.Contains(placement.Guid))
                    {
                        continue;
                    }

                    var definition = _itemDefinitions.FromId(placement.Id);
                    if (definition == null || !itemRandomizer.IsItemAllowed(definition))
                        continue;

                    randomizableItems.Add((definition, placement));
                }
            }

            if (randomizableItems.Count == 0)
                continue;

            logger.Push(area.Path);

            var itemsToReplace = new List<(ItemDefinition Definition, ItemPlacement Placement)>(randomizableItems.Count);
            foreach (var (definition, placement) in randomizableItems)
            {
                if (!replaceMadhouseTapes && definition.Id == "SaveTape")
                {
                    logger.LogLine($"NOT replacing Madhouse cassette tape at {placement.Position} in {placement.SceneFile}");
                    logger.LogLine($"GUID: {placement.Guid}");
                    continue;
                }

                if (!replaceWeapons && definition.IsWeapon)
                {
                    logger.LogLine($"NOT replacing weapon \"{definition.Name}\" at {placement.Position} in {placement.SceneFile}");
                    logger.LogLine($"GUID: {placement.Guid}");
                    continue;
                }

                itemsToReplace.Add((definition, placement));
            }

            if (itemsToReplace.Count > 0)
            {
                randomizer.FileRepository.ModifyScnFile(area.Path, scene =>
                {
                    foreach (var (_, placement) in itemsToReplace)
                    {
                        var originalGameObject = scene.FindGameObject(placement.Guid)!;
                        var originalTransform = originalGameObject.FindComponent<via.Transform>();
                        var itemComponent = originalGameObject.FindComponent<app.Item>()!;
                        var drop = itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);

                        var replaceeName = _itemDefinitions.FromId(itemComponent.ItemDataID)!.Name;
                        var replacerName = _itemDefinitions.FromId(drop.Id)!.Name;
                        var quantity = itemComponent._IsOverwriteDifficultItemNumSetting
                            ? $"[{itemComponent._DifficultItemNumSetting.EasyNum}, {itemComponent.ItemStackNum}, {itemComponent._DifficultItemNumSetting.HardNum}]"
                            : itemComponent.ItemStackNum.ToString();
                        logger.LogLine($"Replacing {quantity}x {replaceeName} at {placement.Position} with " +
                            $"[{drop.CountEasy}, {drop.CountNormal}, {drop.CountMadhouse}]x {replacerName}...");
                        logger.LogLine($"GUID: {originalGameObject.Guid}");
                        logger.LogLine($"Scene: {placement.SceneFile}");

                        itemComponent.SaveGUID = Guid.NewGuid(); // IMPORTANT!
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

                        if (preserveItemModels)
                        {
                            var mesh = originalGameObject.FindComponent("via.render.Mesh");
                            if (mesh != null)
                            {
                                newGameObject = newGameObject.AddOrUpdateComponent(mesh);
                            }
                        }

                        newGameObject.Settings = newGameObject.Settings
                            .Set("Update", originalGameObject.Settings.Get<bool>("Update"))
                            .Set("Draw", originalGameObject.Settings.Get<bool>("Draw"));

                        scene = scene.ReplaceGameObject(originalGameObject.Guid, newGameObject);
                    }

                    return scene;
                });
            }

            logger.Pop();
        }
    }
}
