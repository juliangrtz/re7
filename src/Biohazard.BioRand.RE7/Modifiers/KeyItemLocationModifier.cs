using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class KeyItemLocationModifier : Modifier
{
    private const string RandomizerKey = "modifier/key-item-locations";
    private static readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;
    private readonly List<ItemDefinition> keyItems =
        _itemDefinitions
        .Items
        .Where(x => x.IsStoryProgressionItem && !x.IsDlcItem)
        .ToList();

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var item in keyItems)
        {
            var placements = randomizer.ItemPlacementService.FromId(item.Id);
            foreach (var placement in placements.Where(x => x.Enabled && !x.IsExtra))
            {
                logger.LogLine($"{item.Name} in {placement.SceneFile}, X={placement.Position.X}, Y={placement.Position.Y}, Z={placement.Position.Z}");
                logger.LogLine($"GUID: {placement.Guid}");
            }
        }
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-key-item-locations"))
            return;

        var rng = randomizer.GetRng(RandomizerKey);
        var itemService = randomizer.ItemPlacementService;
        var csv = randomizer.DynamicData.GetData(DynamicDataName.KeyItems) ?? throw new Exception("Unable to get key item data");
        var keyItems = Csv.Deserialize<KeyItemLocation>(csv)
            .Where(k => k.Enabled && !string.IsNullOrWhiteSpace(k.Id))
            .ToImmutableList();

        var newLocations = keyItems
            .GroupBy(k => k.Id)
            .Select(group => rng.Next(group))
            .ToList();

        var relocationPlans = new List<KeyItemRelocationPlan>();
        foreach (var newLocation in newLocations)
        {
            var sourcePlacements = itemService.FromId(newLocation.Id)
                .Where(placement =>
                    placement.Enabled &&
                    !placement.IsExtra &&
                    string.Equals(placement.SceneFile, newLocation.OriginalScnFile, StringComparison.OrdinalIgnoreCase))
                .ToList();
            if (sourcePlacements.Count == 0)
            {
                logger.LogLine($"Skipped relocating {newLocation.Id}: no source placements found in {newLocation.OriginalScnFile}.");
                continue;
            }

            var sourceScene = randomizer.FileRepository.GetScnFile(newLocation.OriginalScnFile)
                .ReadScene(randomizer.FileRepository.TypeRepository);
            var sourcePlacementGuids = sourcePlacements
                .Select(placement => placement.Guid)
                .ToHashSet();
            if (!Guid.TryParse(newLocation.KeyItemGuid, out var sourceGuid))
            {
                logger.LogLine($"Skipped relocating {newLocation.Id}: invalid source GUID \"{newLocation.KeyItemGuid}\".");
                continue;
            }

            var sourceGameObject = sourceScene.FindGameObject(sourceGuid);
            if (sourceGameObject == null)
            {
                logger.LogLine($"Skipped relocating {newLocation.Id}: failed to resolve source object in {newLocation.OriginalScnFile}.");
                continue;
            }

            relocationPlans.Add(new KeyItemRelocationPlan(
                newLocation,
                CloneSourceGameObject(sourceGameObject, newLocation),
                sourcePlacementGuids));
        }

        foreach (var sceneGroup in keyItems.GroupBy(keyItem => keyItem.OriginalScnFile, StringComparer.OrdinalIgnoreCase))
        {
            var guidsToRemove = relocationPlans
                .Where(plan => string.Equals(plan.Location.OriginalScnFile, sceneGroup.Key, StringComparison.OrdinalIgnoreCase))
                .SelectMany(plan => plan.SourceGuidsToRemove)
                .ToHashSet();

            if (guidsToRemove.Count == 0)
                continue;

            randomizer.FileRepository.ModifyScnFile(sceneGroup.Key, scene =>
            {
                foreach (var guid in guidsToRemove)
                {
                    scene = scene.RemoveGameObject(guid);
                    //var originalKeyItem = scene.FindGameObject(guid)!;
                    //originalKeyItem = originalKeyItem.WithSettings(originalKeyItem.Settings
                    //    .Set("Update", false)
                    //    .Set("Draw", false)
                    //);
                    //scene = scene.UpdateGameObject(originalKeyItem);
                }
                return scene;
            });
        }

        foreach (var sceneGroup in relocationPlans.GroupBy(plan => plan.Location.NewScnFile, StringComparer.OrdinalIgnoreCase))
        {
            randomizer.FileRepository.ModifyScnFile(sceneGroup.Key, scene =>
            {
                var parentGameObject = scene.FindGameObject(go => go.Name.EndsWith("_dynamic"))
                    ?? throw new Exception("Failed to obtain \"_dynamic\" parent GameObject!");

                foreach (var relocationPlan in sceneGroup)
                {
                    parentGameObject = parentGameObject.AddOrUpdateChild(relocationPlan.GameObject);
                }

                return scene.UpdateGameObject(parentGameObject);
            });
        }

        foreach (var newLocation in newLocations)
        {
            logger.LogLine($"Chose new location for {newLocation.Id} in scene {newLocation.NewScnFile}: X={newLocation.NewX}, Y={newLocation.NewY}, Z={newLocation.NewZ}");
        }
    }

    private static RszGameObject CloneSourceGameObject(RszGameObject sourceGameObject, KeyItemLocation location)
    {
        var clone = sourceGameObject.Clone();
        var clonedRootGuid = clone.Guid;
        clone = clone.WithGuid(sourceGameObject.Guid);
        clone = clone.WithSettings(clone.Settings
            .Set("Update", true)
            .Set("Draw", true)
        );
        clone = ReplaceGameObjectRefs(clone, new Dictionary<Guid, Guid>
        {
            [clonedRootGuid] = sourceGameObject.Guid
        });

        var transform = clone.FindComponent<via.Transform>()
            ?? throw new Exception($"Failed to relocate {location.Id}: missing via.Transform component!");
        transform.Position = new Vector3(location.NewX, location.NewY, location.NewZ);
        return clone.AddOrUpdateComponent(transform);
    }

    private static RszGameObject ReplaceGameObjectRefs(
        RszGameObject gameObject,
        Dictionary<Guid, Guid> guidMap)
    {
        return gameObject.Visit(node =>
        {
            if (node is RszValueNode valueNode && valueNode.Type == RszFieldType.GameObjectRef)
            {
                var refGuid = RszSerializer.Deserialize<Guid>(valueNode);
                if (guidMap.TryGetValue(refGuid, out var newGuid))
                {
                    return RszSerializer.Serialize(RszFieldType.GameObjectRef, newGuid);
                }
            }

            return node;
        });
    }

    internal class KeyItemLocation
    {
        public bool Enabled { get; init; }
        public string OriginalScnFile { get; init; } = "";
        public string KeyItemGuid { get; init; } = "";
        public string NewScnFile { get; init; } = "";
        public string Id { get; init; } = "";
        public float NewX { get; init; }
        public float NewY { get; init; }
        public float NewZ { get; init; }
        public string Comment { get; init; } = "";
    }

    private sealed record KeyItemRelocationPlan(
        KeyItemLocation Location,
        RszGameObject GameObject,
        IReadOnlySet<Guid> SourceGuidsToRemove);
}
