using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using Enums.app.Item;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class KeyItemLocationModifier : Modifier
{
    private const string RandomizerKey = "modifier/key-item-locations";
    private const string TemplateInstanceKey = $"{RandomizerKey}/template-instances";

    private static readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;
    private static readonly AreaDefinitionRepository _areaDefinitions = AreaDefinitionRepository.Default;
    private static readonly HashSet<Guid> _birdCageGuids = [.. BirdCageModifier.Guids];
    private static readonly ImmutableArray<KeyItemRule> _supportedKeyItems =
    [
        new("3CrestKeyB", 3, KeyItemPlacementScope.Chapter3MainHouse), // White Dog's Head
        new("3CrestKeyA", 3, KeyItemPlacementScope.Chapter3MainHouse), // Blue Dog's Head
        new("Battery", 3, KeyItemPlacementScope.Chapter3PreLucas),
        new("MorgueKey", 3, KeyItemPlacementScope.Chapter3PreLucas), // Scorpion Key
        new("MasterKey", 3, KeyItemPlacementScope.Chapter3PreLucas), // Snake Key
        new("TalismanKey", 3, KeyItemPlacementScope.Chapter3PreLucas), // Crow Key
        new("EthanCarKey", 3, KeyItemPlacementScope.Chapter3MainHouse),
        new("SilhouettePazzlePiece", 3, KeyItemPlacementScope.Chapter3MainHouse), // Wooden Statuette
        new("EvCable", 4, KeyItemPlacementScope.MiaPresentShip), // Power Cable
        new("FuseCh4", 4, KeyItemPlacementScope.MiaPresentShip), // General Purpose Fuse
        new("EvOpener", 4, KeyItemPlacementScope.MiaPresentShip), // Lug Wrench
        new("SpareKey", 4, KeyItemPlacementScope.MiaPresentShip, Count: 4), // Corrosive
        new("SerumTypeE", 4, KeyItemPlacementScope.EthanLateGame), // E-Necrotoxin
    ];

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var rule in _supportedKeyItems)
        {
            var item = _itemDefinitions.FromId(rule.Id)!;
            var placements = randomizer.ItemPlacementService.FromId(rule.Id);
            foreach (var placement in placements.Where(x => x.Enabled && !x.IsExtra && x.Dlc == null))
            {
                logger.LogLine($"{item.Name} in {FormatScenePath(placement.SceneFile)}, X={placement.Position.X}, Y={placement.Position.Y}, Z={placement.Position.Z}");
                logger.LogLine($"GUID: {placement.Guid}");
            }
        }
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-key-item-locations"))
            return;

        var rng = randomizer.GetRng(RandomizerKey);
        var itemPlacementService = randomizer.ItemPlacementService;
        var itemRandomizer = randomizer.ItemRandomizer;
        var randomItemSettings = randomizer.StaticItemRandomizationService.RandomItemSettings;
        var preserveItemModels = randomizer.GetConfigOption<bool>("preserve-item-models");
        var availableTargets = GetEligibleTargetPlacements(randomizer, itemPlacementService)
            .DistinctBy(target => target.Key)
            .ToList();
        var replacementPlans = new Dictionary<ReplacementKey, ReplacementPlan>();

        foreach (var rule in _supportedKeyItems)
        {
            var candidates = availableTargets
                .Where(rule.CanPlaceAt)
                .ToArray();
            if (candidates.Length == 0)
            {
                logger.LogLine($"Skipped key item {_itemDefinitions.GetName(rule.Id)}: no eligible chapter {rule.Chapter} placement matched {rule.Scope}.");
                continue;
            }

            var target = rng.Next(candidates);
            availableTargets.Remove(target);
            replacementPlans[target.Key] = ReplacementPlan.KeyItem(target.Placement, rule);
        }

        foreach (var placement in GetOriginalSupportedKeyItemPlacements(itemPlacementService))
        {
            var key = new ReplacementKey(placement.SceneFile, placement.Guid);
            if (replacementPlans.ContainsKey(key))
                continue;

            replacementPlans[key] = ReplacementPlan.Filler(
                placement,
                itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings));
        }

        foreach (var sceneGroup in replacementPlans.Values.GroupBy(plan => plan.Placement.SceneFile, StringComparer.OrdinalIgnoreCase))
        {
            logger.Push(FormatScenePath(sceneGroup.Key));
            randomizer.FileRepository.ModifyScnFile(sceneGroup.Key, scene =>
            {
                var plans = sceneGroup.ToList();
                var targetGuids = plans
                    .Select(plan => plan.Placement.Guid)
                    .ToHashSet();
                var originalGameObjects = scene.FindGameObjectsByGuidWithFsmContext(targetGuids);
                var replacementGameObjects = new Dictionary<Guid, RszGameObject>();

                foreach (var plan in plans)
                {
                    if (!originalGameObjects.TryGetValue(plan.Placement.Guid, out var originalMatch))
                    {
                        logger.LogLine($"Skipped replacing {plan.Placement.Id} in {FormatScenePath(plan.Placement.SceneFile)}: GameObject {plan.Placement.Guid} was not found.");
                        continue;
                    }

                    var replacement = CreateReplacementGameObject(
                        randomizer,
                        logger,
                        rng,
                        randomItemSettings,
                        plan,
                        originalMatch.GameObject,
                        preserveItemModels,
                        originalMatch.HasFsmInHierarchy);

                    replacementGameObjects[plan.Placement.Guid] = replacement;
                }

                return ReplaceGameObjects(scene, replacementGameObjects);
            });
            logger.Pop();
        }
    }

    private static IEnumerable<ItemReplacementTarget> GetEligibleTargetPlacements(
        Randomizer randomizer,
        ItemPlacementService itemPlacementService)
    {
        var replaceMadhouseTapes = randomizer.GetConfigOption<bool>("replace-madhouse-tapes")
            || MadhouseSaveModifier.IsEnabled(randomizer);
        var replaceWeapons = randomizer.GetConfigOption<bool>("replace-weapons");
        var eligibleScenePaths = AreaDefinitionRepository.Default.All
            .Where(area => area.Dlc == null)
            .Select(area => area.Path)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var placement in itemPlacementService.MainGamePlacements)
        {
            if (!eligibleScenePaths.Contains(placement.SceneFile)
                || placement.IsExtra
                || !placement.Enabled
                || string.IsNullOrWhiteSpace(placement.Id)
                || placement.Difficulty != null
                || placement.Tags.Contains(ItemPlacement.ExcludeTag)
                || _birdCageGuids.Contains(placement.Guid))
            {
                continue;
            }

            var definition = _itemDefinitions.FromId(placement.Id);
            if (definition == null
                || !randomizer.ItemRandomizer.IsItemAllowed(definition))
            {
                continue;
            }

            if (!replaceMadhouseTapes && definition.Id == "SaveTape")
                continue;

            if (!replaceWeapons && definition.IsWeapon)
                continue;

            yield return new ItemReplacementTarget(placement, definition);
        }
    }

    private static IEnumerable<ItemPlacement> GetOriginalSupportedKeyItemPlacements(ItemPlacementService itemPlacementService)
    {
        var supportedIds = _supportedKeyItems
            .Select(rule => rule.Id)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return itemPlacementService.MainGamePlacements
            .Where(placement =>
                supportedIds.Contains(placement.Id) &&
                placement.Enabled &&
                !placement.IsExtra)
            .DistinctBy(placement => new ReplacementKey(placement.SceneFile, placement.Guid));
    }

    private static RszGameObject CreateReplacementGameObject(
        Randomizer randomizer,
        RandomizerLogger logger,
        Rng rng,
        RandomItemSettings randomItemSettings,
        ReplacementPlan plan,
        RszGameObject originalGameObject,
        bool preserveItemModels,
        bool preserveObjectShape)
    {
        var originalItem = originalGameObject.FindComponent<app.Item>()
            ?? throw new Exception($"Item placement {plan.Placement.Guid} in {plan.Placement.SceneFile} does not have an app.Item component.");
        var originalTransform = originalGameObject.FindComponent<GeneratedViaTransform>();
        var drop = plan.Drop;
        var templateItemId = randomizer.ItemRandomizer.GetItemTemplateIdForDrop(drop.Id, rng, randomItemSettings);
        var template = TryGetItemTemplate(randomizer, logger, templateItemId, originalGameObject);

        if (preserveObjectShape)
        {
            logger.LogLine("Preserving original pickup object shape because this placement is FSM-controlled.");
            LogReplacement(logger, plan, originalItem, drop);
            ApplyDropToItem(originalItem, rng, drop);
            var preservedGameObject = originalGameObject.AddOrUpdateComponent(originalItem);
            return preserveItemModels
                ? preservedGameObject
                : preservedGameObject.ApplyVisualResourcesFromTemplate(template);
        }

        var replacement = template.CloneWithNewGuids(
            randomizer.GetRng(TemplateInstanceKey, plan.Placement.SceneFile, plan.Placement.Guid, templateItemId),
            originalGameObject.Guid);
        var item = replacement.FindComponent<app.Item>() ?? originalItem;

        ApplyDropToItem(item, rng, drop);
        item.Enabled = true;
        replacement = replacement.AddOrUpdateComponent(item);

        if (originalTransform != null)
        {
            replacement = replacement.AddOrUpdateComponent(originalTransform);
        }

        if (preserveItemModels)
        {
            var mesh = originalGameObject.FindComponent("via.render.Mesh");
            if (mesh != null)
            {
                replacement = replacement.AddOrUpdateComponent(mesh);
            }
        }

        replacement = replacement.PreparePickupInteractionsForPlacement();

        replacement = replacement.WithSettings(
            replacement.Settings
                .Set("Update", originalGameObject.Settings.Get<bool>("Update"))
                .Set("Draw", originalGameObject.Settings.Get<bool>("Draw")));

        LogReplacement(logger, plan, originalItem, drop);
        return replacement.WithGuid(originalGameObject.Guid);
    }

    private static void ApplyDropToItem(app.Item item, Rng rng, Item drop)
    {
        item.SaveGUID = rng.NextGuid();
        item.ItemDataID = drop.Id;
        item.ItemStackNum = drop.CountNormal;
        item._IsOverwriteDifficultItemNumSetting = true;
        item._DifficultItemNumSetting.EasyNum = drop.CountEasy;
        item._DifficultItemNumSetting.HardNum = drop.CountMadhouse;
        item.Enabled = true;
    }

    private static RszGameObject TryGetItemTemplate(
        Randomizer randomizer,
        RandomizerLogger logger,
        string templateItemId,
        RszGameObject originalGameObject)
    {
        try
        {
            return randomizer.TemplateService.GetItemTemplate(templateItemId);
        }
        catch (Exception ex)
        {
            logger.LogLine($"Template {templateItemId} was not found; preserving original pickup object shape. {ex.Message}");
            return originalGameObject;
        }
    }

    private static void LogReplacement(
        RandomizerLogger logger,
        ReplacementPlan plan,
        app.Item originalItem,
        Item drop)
    {
        var replaceeName = _itemDefinitions.GetName(originalItem.ItemDataID);
        var replacerName = _itemDefinitions.GetName(drop.Id);
        var prefix = plan.Kind == ReplacementKind.KeyItem ? "[KEY ITEM]" : "[KEY ITEM FILLER]";
        logger.LogLine($"{prefix} Replacing {replaceeName} at {plan.Placement.Position} with " +
            $"[{drop.CountEasy}, {drop.CountNormal}, {drop.CountMadhouse}]x {replacerName}.");
        logger.LogLine($"GUID: {plan.Placement.Guid}");
    }

    private static string FormatScenePath(string path)
        => _areaDefinitions.FormatScenePath(path);

    private static T ReplaceGameObjects<T>(T node, IReadOnlyDictionary<Guid, RszGameObject> replacements)
        where T : IRszSceneNode
    {
        if (node.Children.IsDefaultOrEmpty)
            return node;

        var children = node.Children.ToBuilder();
        for (var i = 0; i < children.Count; i++)
        {
            if (children[i] is RszGameObject oldGameObject && replacements.TryGetValue(oldGameObject.Guid, out var replacement))
            {
                children[i] = replacement.WithGuid(oldGameObject.Guid);
            }
            else
            {
                children[i] = ReplaceGameObjects(children[i], replacements);
            }
        }

        return (T)node.WithChildren(children.ToImmutable());
    }

    private static bool IsMiaPresentShipScene(ItemPlacement placement)
        => placement.SceneFile.Contains("/chapter4/ship", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter4/c04_ship", StringComparison.OrdinalIgnoreCase);

    private static bool IsChapter3MainHouseScene(ItemPlacement placement)
        => placement.SceneFile.Contains("/chapter3/mainhouse", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter3/c03_mainhouse", StringComparison.OrdinalIgnoreCase);

    private static bool IsChapter3PreLucasScene(ItemPlacement placement)
        => IsChapter3MainHouseScene(placement)
            || placement.SceneFile.Contains("/scene/chapter3/c03_rightarea", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter3/c03_soft_1", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter3/c03_oldhouse", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter3/c03_gh", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/chapter3/oldhouse", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/chapter3/gardenarea", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter3/c03_gardenarea", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter3/c03_trailerhouse", StringComparison.OrdinalIgnoreCase);

    private static bool IsEthanLateGameScene(ItemPlacement placement)
        => placement.SceneFile.Contains("/chapter4/saltdome", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter4/c04_cottage", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/scene/chapter4/c04_mainhouse", StringComparison.OrdinalIgnoreCase)
            || placement.SceneFile.Contains("/animation/ingame/c04/", StringComparison.OrdinalIgnoreCase);

    private enum KeyItemPlacementScope
    {
        Any,
        Chapter3MainHouse,
        Chapter3PreLucas,
        MiaPresentShip,
        EthanLateGame,
    }

    private enum ReplacementKind
    {
        KeyItem,
        Filler,
    }

    private sealed record KeyItemRule(
        string Id,
        int Chapter,
        KeyItemPlacementScope Scope,
        int Count = 1)
    {
        public bool CanPlaceAt(ItemReplacementTarget target)
            => target.Placement.Chapter == Chapter
                && Scope switch
                {
                    KeyItemPlacementScope.Chapter3MainHouse => IsChapter3MainHouseScene(target.Placement),
                    KeyItemPlacementScope.Chapter3PreLucas => IsChapter3PreLucasScene(target.Placement),
                    KeyItemPlacementScope.MiaPresentShip => IsMiaPresentShipScene(target.Placement),
                    KeyItemPlacementScope.EthanLateGame => IsEthanLateGameScene(target.Placement),
                    _ => true,
                };
    }

    private readonly record struct ReplacementKey(string SceneFile, Guid Guid);

    private sealed record ItemReplacementTarget(ItemPlacement Placement, ItemDefinition Definition)
    {
        public ReplacementKey Key => new(Placement.SceneFile, Placement.Guid);
    }

    private sealed record ReplacementPlan(
        ReplacementKind Kind,
        ItemPlacement Placement,
        Item Drop)
    {
        public static ReplacementPlan KeyItem(ItemPlacement placement, KeyItemRule rule)
            => new(ReplacementKind.KeyItem, placement, new Item(rule.Id, rule.Count));

        public static ReplacementPlan Filler(ItemPlacement placement, Item drop)
            => new(ReplacementKind.Filler, placement, drop);
    }
}
