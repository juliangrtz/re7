using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class KeyItemLocationModifier : Modifier
{
    private const string RandomizerKey = "modifier/key-item-locations";
    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;
    private readonly List<ItemDefinition> keyItems =
        itemDefinitions
        .Items
        .Where(x => x.IsStoryProgressionItem && !x.IsDlcItem)
        .ToList();

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        var itemService = randomizer.GetService<ItemPlacementService>();
        logger.Push("Original key item locations");
        foreach (var item in keyItems)
        {
            var placements = itemService.FromId(item.Id);
            foreach (var placement in placements)
            {
                logger.LogLine($"{item.Name}: X={placement.Position.X}, Y={placement.Position.Y}, Z={placement.Position.Z}");
            }
        }
        logger.Pop();
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-key-item-locations"))
            return;

        var rng = randomizer.GetRng(RandomizerKey);
        var itemService = randomizer.GetService<ItemPlacementService>();
        var newPlacements = itemService.ItemPlacements
            .Where(i => i.IsExtra && itemService.PlacementToItemMap[i].IsStoryProgressionItem);

        foreach (var keyItemGroup in newPlacements.GroupBy(l => l.Guid))
        {
            var id = keyItemGroup.Key;
            var newPlacement = rng.Next(keyItemGroup);
            var placements = itemService.FromGuid(id);

            foreach (var placement in placements)
            {
                randomizer.FileRepository.ModifyScnFile(placement.SceneFile, randomizer.IsOnRaytracingVersion, scene =>
                {
                    var obj = scene.FindGameObject(id)!;
                    var transform = obj.FindComponent<via.Transform>()!;
                    transform.Position = new(newPlacement.Position.X, newPlacement.Position.Y, newPlacement.Position.Z);
                    obj = obj.AddOrUpdateComponent(transform);
                    scene = scene.UpdateGameObject(obj);
                    return scene;
                });

                logger.LogLine($"Chose new location for {itemDefinitions.FromId(placement.Id)!.Name}: X={newPlacement.Position.X}, Y={newPlacement.Position.Y}, Z={newPlacement.Position.Z}");
            }

        }
    }
}