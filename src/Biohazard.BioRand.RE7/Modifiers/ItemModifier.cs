using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using Enums.app.Item;
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

        var candidates = new List<ItemReplacementCandidate>();
        foreach (var area in areaService.Areas)
        {
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

                    candidates.Add(new ItemReplacementCandidate(area.Path, definition, placement));
                }
            }
        }

        candidates = candidates
            .DistinctBy(candidate => candidate.Key)
            .ToList();
        if (candidates.Count == 0)
            return;

        var replacements = CreateReplacementMap(candidates, itemRandomizer, rng, randomItemSettings);

        foreach (var areaGroup in candidates.GroupBy(candidate => candidate.AreaPath))
        {
            var itemsToReplace = areaGroup
                .Where(candidate => replacements.ContainsKey(candidate.Key))
                .ToList();
            if (itemsToReplace.Count == 0)
                continue;

            logger.Push(areaGroup.Key);

            randomizer.FileRepository.ModifyScnFile(areaGroup.Key, scene =>
            {
                foreach (var candidate in itemsToReplace)
                {
                    var definition = candidate.Definition;
                    var placement = candidate.Placement;
                    var originalGameObject = scene.FindGameObject(placement.Guid)!;
                    var originalTransform = originalGameObject.FindComponent<via.Transform>();
                    var itemComponent = originalGameObject.FindComponent<app.Item>()!;
                    var drop = replacements[candidate.Key];

                    var replaceeName = _itemDefinitions.FromId(itemComponent.ItemDataID)?.Name ?? definition.Name ?? itemComponent.ItemDataID;
                    var replacerName = _itemDefinitions.FromId(drop.Id)?.Name ?? drop.Id;
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

                    var templateItemId = itemRandomizer.GetItemTemplateIdForDrop(drop.Id, rng, randomItemSettings);
                    var newGameObject = templateService.GetItemTemplate(templateItemId);
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

            logger.Pop();
        }
    }

    private static Dictionary<ReplacementKey, Item> CreateReplacementMap(
        IReadOnlyList<ItemReplacementCandidate> candidates,
        ItemRandomizer itemRandomizer,
        Rng rng,
        RandomItemSettings randomItemSettings)
    {
        var result = new Dictionary<ReplacementKey, Item>();

        foreach (var chapterGroup in candidates.GroupBy(candidate => candidate.Placement.Chapter).OrderBy(group => group.Key))
        {
            var availableCandidates = chapterGroup.ToList();
            foreach (var valuableDrop in itemRandomizer.GetValuableDrops(rng, "item-drop"))
            {
                var target = TakeRandomHighValueItem(availableCandidates, rng);
                if (target == null)
                {
                    break;
                }

                result[target.Key] = valuableDrop.Item;
            }

            foreach (var candidate in availableCandidates)
            {
                result[candidate.Key] = itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);
            }
        }

        return result;
    }

    private static ItemReplacementCandidate? TakeRandomHighValueItem(List<ItemReplacementCandidate> candidates, Rng rng)
    {
        if (candidates.Count == 0)
        {
            return null;
        }

        var bestScore = candidates.Max(GetValuablePlacementScore);
        var bestCandidates = candidates
            .Where(candidate => GetValuablePlacementScore(candidate) == bestScore)
            .ToArray();
        var target = rng.Next(bestCandidates);
        candidates.Remove(target);
        return target;
    }

    private static int GetValuablePlacementScore(ItemReplacementCandidate candidate)
    {
        var definition = candidate.Definition;
        return definition.Id switch
        {
            "RepairKit" or "CylinderKey" => 100,
            "PowerUpCoin01A" or "PowerUpCoin01B" => 90,
            "Stimulant" or "Depressant" => 70,
            _ when definition.IsWeapon => 95,
            _ when ItemDrops.GetCategory(definition.Id) == ItemDrops.CategoryCoin => 90,
            _ when definition.CategoryType is ItemCategoryType.KeyItem
                or ItemCategoryType.UsableKeyItem
                or ItemCategoryType.DiscardableKeyItem => 85,
            _ when definition.CategoryType == ItemCategoryType.Shell => 20,
            _ => 50,
        };
    }

    private readonly record struct ReplacementKey(string AreaPath, Guid Guid);

    private sealed record ItemReplacementCandidate(
        string AreaPath,
        ItemDefinition Definition,
        ItemPlacement Placement)
    {
        public ReplacementKey Key => new(AreaPath, Placement.Guid);
    }
}
