using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using Enums.app.Item;
using IntelOrca.Biohazard.BioRand.Routing;
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
    private const int WhiteDogHeadMask = 1 << 0;
    private const int BlueDogHeadMask = 1 << 1;
    private const int BatteryMask = 1 << 2;
    private const int ScorpionKeyMask = 1 << 3;
    private const int SnakeKeyMask = 1 << 4;
    private const int CrowKeyMask = 1 << 5;
    private const int CarKeyMask = 1 << 6;
    private const int WoodenStatuetteMask = 1 << 7;
    private const int PowerCableMask = 1 << 8;
    private const int ShipFuseMask = 1 << 9;
    private const int LugWrenchMask = 1 << 10;
    private const int CorrosiveMask = 1 << 11;
    private const int NecrotoxinMask = 1 << 12;
    private const int DogHeadMasks = WhiteDogHeadMask | BlueDogHeadMask;
    private const int MainHouseCarryMasks = DogHeadMasks | BatteryMask | SnakeKeyMask | CrowKeyMask;
    private const int ShipRepairMasks = PowerCableMask | ShipFuseMask | LugWrenchMask | CorrosiveMask;
    private static readonly ImmutableArray<KeyItemRule> _supportedKeyItems =
    [
        new("3CrestKeyB", 3, WhiteDogHeadMask), // White Dog's Head
        new("3CrestKeyA", 3, BlueDogHeadMask), // Blue Dog's Head
        new("Battery", 3, BatteryMask),
        new("MorgueKey", 3, ScorpionKeyMask), // Scorpion Key
        new("MasterKey", 3, SnakeKeyMask), // Snake Key
        new("TalismanKey", 3, CrowKeyMask), // Crow Key
        new("EthanCarKey", 3, CarKeyMask),
        new("SilhouettePazzlePiece", 3, WoodenStatuetteMask), // Wooden Statuette
        new("EvCable", 4, PowerCableMask), // Power Cable
        new("FuseCh4", 4, ShipFuseMask), // General Purpose Fuse
        new("EvOpener", 4, LugWrenchMask), // Lug Wrench
        new("SpareKey", 4, CorrosiveMask, Count: 4), // Corrosive
        new("SerumTypeE", 4, NecrotoxinMask), // E-Necrotoxin
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
        var replacementPlans = CreateKeyItemReplacementPlans(logger, rng, availableTargets);
        if (replacementPlans == null)
            return;

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

    private static Dictionary<ReplacementKey, ReplacementPlan>? CreateKeyItemReplacementPlans(
        RandomizerLogger logger,
        Rng rng,
        IReadOnlyCollection<ItemReplacementTarget> availableTargets)
    {
        var routeGraph = new KeyItemRouteGraph();
        foreach (var target in availableTargets
            .OrderBy(target => target.Placement.SceneFile, StringComparer.OrdinalIgnoreCase)
            .ThenBy(target => target.Placement.Guid))
        {
            routeGraph.TryAddTarget(target);
        }

        foreach (var rule in _supportedKeyItems)
        {
            if (!routeGraph.HasCandidate(rule))
            {
                logger.LogLine($"Skipped key item {_itemDefinitions.GetName(rule.Id)}: no route-safe chapter {rule.Chapter} normal placement was found.");
            }
        }

        var route = routeGraph.GenerateRoute(rng.Next());
        if (!route.AllNodesVisited)
        {
            logger.LogLine("Skipped key item randomization: route graph could not place every supported key item without a progression cycle.");
            logger.LogLine(route.Log);
            return null;
        }

        var result = new Dictionary<ReplacementKey, ReplacementPlan>();
        var assignments = routeGraph.GetAssignments(route, logger).ToList();
        if (assignments.Count != _supportedKeyItems.Length)
        {
            logger.LogLine("Skipped key item randomization: route graph did not produce exactly one placement for every supported key item.");
            return null;
        }

        foreach (var assignment in assignments)
        {
            if (result.ContainsKey(assignment.Target.Key))
            {
                logger.LogLine($"Skipped key item randomization: route graph assigned multiple key items to {FormatScenePath(assignment.Target.Placement.SceneFile)}.");
                return null;
            }

            result[assignment.Target.Key] = ReplacementPlan.KeyItem(assignment.Target.Placement, assignment.Rule);
            logger.LogLine($"[KEY ITEM ROUTE] {_itemDefinitions.GetName(assignment.Rule.Id)} " +
                $"-> {assignment.RegionName}: {FormatScenePath(assignment.Target.Placement.SceneFile)}");
            logger.LogLine($"GUID: {assignment.Target.Placement.Guid}");
        }

        return result;
    }

    internal static string GenerateRouteGraphMermaid(bool includeItems = false)
        => new KeyItemRouteGraph().ToMermaid(includeItems);

    internal static KeyItemRouteGraphDiagram GenerateRouteGraphDiagram()
        => new KeyItemRouteGraph().ToDiagram();

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

    private static bool PathContains(string path, string value)
        => path.Contains(value, StringComparison.OrdinalIgnoreCase);

    private static bool IsMainHouseBeforeGarage(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/mainhouse_west/")
            || PathContains(path, "c03_mainhouse1fgaragehallway")
            || PathContains(path, "c03_mainhouse1fhallway")
            || PathContains(path, "c03_mainhouse1fldk")
            || PathContains(path, "c03_mainhouse1fliving")
            || PathContains(path, "c03_mainhouse1fpantry")
            || PathContains(path, "c03_mainhouse1fwash");

    private static bool IsMainHouseBeforeShadowPuzzle(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/mainhouse_hall/")
            || PathContains(path, "c03_mainhouse2fbath")
            || PathContains(path, "c03_mainhouse2fgrandma")
            || PathContains(path, "c03_mainhouse2fhallway")
            || PathContains(path, "c03_mainhouse2fplay")
            || PathContains(path, "c03_mainhouse2fstoreroom")
            || PathContains(path, "c03_mainhousehall")
            || PathContains(path, "c03_mainhousestair01");

    private static bool IsMainHouseEastOrBasement(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/mainhouse_east/")
            || PathContains(path, "c03_rightarea");

    private static bool IsMainHouseSnakeKeyRoom(string path)
        => PathContains(path, "c03_mainhouse2fbedroom")
            || PathContains(path, "c03_mainhouse2fkids")
            || PathContains(path, "c03_mainhousoutsideterrace2f3");

    private static bool IsYardOrTrailer(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/gardenarea/")
            || PathContains(path, "c03_gardenarea")
            || PathContains(path, "c03_trailerhouse")
            || PathContains(path, "c03_mainhousoutside")
            || PathContains(path, "c03_mainhousoutsideterrace");

    private static bool IsOldHouseBeforeCrowDoor(string path)
        => PathContains(path, "c03_oldhouse1fbridge")
            || PathContains(path, "c03_oldhouse1fentrance")
            || PathContains(path, "c03_oldhouse1fhallway")
            || PathContains(path, "c03_oldhouse1fhole")
            || PathContains(path, "c03_oldhouse1fhollway")
            || PathContains(path, "c03_oldhouse1fkitchen")
            || PathContains(path, "c03_oldhouse1fpuzzle")
            || PathContains(path, "c03_oldhouse1froom")
            || PathContains(path, "c03_oldhouse1fstorage")
            || PathContains(path, "c03_oldhouse1funderfloor")
            || PathContains(path, "c03_oldhouse1fwallinside")
            || PathContains(path, "c03_oldhouseoutside")
            || PathContains(path, "c03_oldhousesaferoom");

    private static bool IsOldHouseAfterCrowDoorOrGreenHouse(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/oldhouse/")
            || PathContains(path, "/leveldesign/itemset/chapter3/greenhouse/")
            || PathContains(path, "c03_oldhouse1fstairs")
            || PathContains(path, "c03_oldhouse2f")
            || PathContains(path, "c03_oldhousecave")
            || PathContains(path, "c03_gh");

    private static bool IsTestingAreaBeforeBarnFight(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/cowshed/")
            || PathContains(path, "c03_cowshed");

    private static bool IsMiaPresentShipRoute(string path)
        => !PathContains(path, "past")
            && (PathContains(path, "/environment/scene/chapter4/c04_ship")
                || PathContains(path, "/leveldesign/itemset/chapter4/ship")
                || PathContains(path, "/scenes/chapter/chapter4/c04_shipelevator"));

    private static bool IsSaltMineBeforeNecrotoxinUse(string path)
        => !PathContains(path, "/chapter4/lastbattle/")
            && (PathContains(path, "/environment/scene/chapter4/c04_cottage")
                || PathContains(path, "/environment/scene/chapter4/c04_cave")
                || PathContains(path, "/leveldesign/itemset/chapter4/saltdome"));

    private sealed class KeyItemRouteGraph
    {
        private readonly GraphBuilder _builder = new();
        private readonly Dictionary<string, Key> _routeKeys;
        private readonly Dictionary<Node, ItemReplacementTarget> _targetsByNode = [];
        private readonly Dictionary<Node, string> _regionByNode = [];
        private readonly Dictionary<Node, string> _diagramNodeIds = [];
        private readonly List<KeyItemRouteGraphNode> _diagramNodes = [];
        private readonly List<KeyItemRouteGraphEdge> _diagramEdges = [];
        private readonly Node _mainHouseBeforeGarage;
        private readonly Node _garage;
        private readonly Node _mainHouseBeforeShadowPuzzle;
        private readonly Node _mainHouseEast;
        private readonly Node _yard;
        private readonly Node _scorpionRooms;
        private readonly Node _oldHouseBeforeCrow;
        private readonly Node _oldHouseAfterCrow;
        private readonly Node _snakeRooms;
        private readonly Node _testingArea;
        private readonly Node _barn;
        private readonly Node _ship;
        private readonly Node _shipExit;
        private readonly Node _saltMine;
        private readonly Node _finale;

        public KeyItemRouteGraph()
        {
            _routeKeys = _supportedKeyItems.ToDictionary(
                rule => rule.Id,
                rule => _builder.Key(_itemDefinitions.GetName(rule.Id), rule.RouteMask),
                StringComparer.OrdinalIgnoreCase);

            _mainHouseBeforeGarage = Room("main-house-before-garage", "Main House west side before garage", 0, 0);
            _garage = Room("garage", "Garage car fight", 1, 0);
            _mainHouseBeforeShadowPuzzle = Room("main-house-before-shadow-puzzle", "Main House after garage before shadow puzzle", 2, 0);
            _mainHouseEast = Room("main-house-east", "Main House east side and processing area", 3, 0);
            _yard = Room("yard", "Yard and trailer", 4, 0);
            _scorpionRooms = Room("scorpion-rooms", "Main House scorpion-key rooms", 0, 1);
            _oldHouseBeforeCrow = Room("old-house-before-crow", "Old House before Crow Key door", 5, 0);
            _oldHouseAfterCrow = Room("old-house-after-crow", "Old House after Crow Key door and Green House", 6, 0);
            _snakeRooms = Room("snake-rooms", "Snake-key rooms and keycard setup", 7, 0);
            _testingArea = Room("testing-area", "Testing Area before barn battery socket", 8, 0);
            _barn = Room("barn", "Testing Area barn fight", 9, 0);
            _ship = Room("ship", "Wrecked Ship Mia present route", 10, 0);
            _shipExit = Room("ship-exit", "Wrecked Ship elevator repaired", 11, 0);
            _saltMine = Room("salt-mine", "Swamp and Salt Mine before E-Necrotoxin", 12, 0);
            _finale = Room("finale", "Final E-Necrotoxin use", 13, 0);

            Door(_mainHouseBeforeGarage, _garage, RouteKey("EthanCarKey"));
            Door(_mainHouseBeforeGarage, _scorpionRooms, RouteKey("MorgueKey"));
            Door(_garage, _mainHouseBeforeShadowPuzzle);
            Door(_mainHouseBeforeShadowPuzzle, _mainHouseEast, RouteKey("SilhouettePazzlePiece"));
            Door(_mainHouseEast, _yard, RouteKey("3CrestKeyB"), RouteKey("3CrestKeyA"));
            Door(_yard, _oldHouseBeforeCrow);
            Door(_oldHouseBeforeCrow, _oldHouseAfterCrow, RouteKey("TalismanKey"));
            Door(_oldHouseAfterCrow, _snakeRooms, RouteKey("MasterKey"));
            Door(_snakeRooms, _testingArea);
            Door(_testingArea, _barn, RouteKey("Battery"));
            NoReturn(_barn, _ship);
            Door(_ship, _shipExit, RouteKey("EvCable"), RouteKey("FuseCh4"), RouteKey("EvOpener"), RouteKey("SpareKey"));
            NoReturn(_shipExit, _saltMine);
            Door(_saltMine, _finale, RouteKey("SerumTypeE"));
        }

        public bool TryAddTarget(ItemReplacementTarget target)
        {
            var routeTarget = ClassifyTarget(target);
            if (routeTarget == null)
                return false;

            var node = _builder.Item(
                $"{_itemDefinitions.GetName(target.Definition.Id)} @ {FormatScenePath(target.Placement.SceneFile)}",
                routeTarget.GroupMask,
                routeTarget.Room);
            _targetsByNode[node] = target;
            _regionByNode[node] = routeTarget.RegionName;
            return true;
        }

        public bool HasCandidate(KeyItemRule rule)
            => _targetsByNode.Keys.Any(node => (node.Group & rule.RouteMask) == rule.RouteMask);

        public Route GenerateRoute(int seed)
            => _builder.GenerateRoute(seed);

        public string ToMermaid(bool includeItems)
            => _builder.ToGraph().ToMermaid(useLabels: true, includeItems);

        public KeyItemRouteGraphDiagram ToDiagram()
            => new([.. _diagramNodes], [.. _diagramEdges]);

        public IEnumerable<KeyItemRouteAssignment> GetAssignments(Route route, RandomizerLogger logger)
        {
            foreach (var rule in _supportedKeyItems)
            {
                var routeKey = RouteKey(rule.Id);
                var nodes = route.GetItemsContainingKey(routeKey)
                    .Where(_targetsByNode.ContainsKey)
                    .OrderBy(node => node)
                    .ToArray();

                if (nodes.Length == 0)
                {
                    logger.LogLine($"Skipped key item {_itemDefinitions.GetName(rule.Id)}: route did not assign a placement.");
                    continue;
                }

                if (nodes.Length > 1)
                {
                    logger.LogLine($"Skipped key item {_itemDefinitions.GetName(rule.Id)}: route assigned multiple placements.");
                    continue;
                }

                var node = nodes[0];
                yield return new KeyItemRouteAssignment(
                    rule,
                    _targetsByNode[node],
                    _regionByNode[node]);
            }
        }

        private Key RouteKey(string itemId)
            => _routeKeys[itemId];

        private Node Room(string id, string label, int row, int column)
        {
            var node = _builder.Room(label);
            _diagramNodeIds[node] = id;
            _diagramNodes.Add(new(id, label, row, column));
            return node;
        }

        private void Door(Node source, Node target, params Key[] keys)
        {
            _builder.Door(source, target, [.. keys.Select(key => (Requirement)key)]);
            AddDiagramEdge(source, target, keys, isNoReturn: false);
        }

        private void NoReturn(Node source, Node target, params Key[] keys)
        {
            _builder.NoReturn(source, target, [.. keys.Select(key => (Requirement)key)]);
            AddDiagramEdge(source, target, keys, isNoReturn: true);
        }

        private void AddDiagramEdge(Node source, Node target, Key[] keys, bool isNoReturn)
        {
            var labels = keys
                .Select(key => key.Label ?? key.ToString())
                .ToImmutableArray();
            _diagramEdges.Add(new(
                _diagramNodeIds[source],
                _diagramNodeIds[target],
                labels,
                isNoReturn));
        }

        private RouteTarget? ClassifyTarget(ItemReplacementTarget target)
        {
            var placement = target.Placement;
            var path = placement.SceneFile;
            if (placement.Chapter == 3)
            {
                if (IsTestingAreaBeforeBarnFight(path))
                    return new(_testingArea, BatteryMask, "Testing Area before barn battery socket");
                if (IsMainHouseSnakeKeyRoom(path))
                    return new(_snakeRooms, BatteryMask, "Main House snake-key rooms and keycard setup");
                if (IsOldHouseAfterCrowDoorOrGreenHouse(path))
                    return new(_oldHouseAfterCrow, BatteryMask | SnakeKeyMask, "Old House after Crow Key door and Green House");
                if (IsOldHouseBeforeCrowDoor(path))
                    return new(_oldHouseBeforeCrow, BatteryMask | SnakeKeyMask | CrowKeyMask, "Old House before Crow Key door");
                if (IsYardOrTrailer(path))
                    return new(_yard, BatteryMask | SnakeKeyMask | CrowKeyMask, "Yard and trailer");
                if (IsMainHouseEastOrBasement(path))
                    return new(_mainHouseEast, MainHouseCarryMasks, "Main House east side and processing area");
                if (IsMainHouseBeforeShadowPuzzle(path))
                    return new(_mainHouseBeforeShadowPuzzle, MainHouseCarryMasks | WoodenStatuetteMask, "Main House after garage before shadow puzzle");
                if (IsMainHouseBeforeGarage(path))
                    return new(_mainHouseBeforeGarage, MainHouseCarryMasks | ScorpionKeyMask | CarKeyMask | WoodenStatuetteMask, "Main House west side before garage");
            }
            else if (placement.Chapter == 4)
            {
                if (IsMiaPresentShipRoute(path))
                    return new(_ship, ShipRepairMasks, "Wrecked Ship Mia present route");
                if (IsSaltMineBeforeNecrotoxinUse(path))
                    return new(_saltMine, NecrotoxinMask, "Swamp and Salt Mine before E-Necrotoxin");
            }

            return null;
        }
    }

    private enum ReplacementKind
    {
        KeyItem,
        Filler,
    }

    private sealed record KeyItemRule(
        string Id,
        int Chapter,
        int RouteMask,
        int Count = 1);

    private sealed record RouteTarget(Node Room, int GroupMask, string RegionName);

    private sealed record KeyItemRouteAssignment(
        KeyItemRule Rule,
        ItemReplacementTarget Target,
        string RegionName);

    internal sealed record KeyItemRouteGraphDiagram(
        ImmutableArray<KeyItemRouteGraphNode> Nodes,
        ImmutableArray<KeyItemRouteGraphEdge> Edges);

    internal sealed record KeyItemRouteGraphNode(
        string Id,
        string Label,
        int Row,
        int Column);

    internal sealed record KeyItemRouteGraphEdge(
        string SourceId,
        string TargetId,
        ImmutableArray<string> Requirements,
        bool IsNoReturn);

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
