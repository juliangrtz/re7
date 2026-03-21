using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class KeyItemLocationModifier : Modifier
{
    private const string RandomizerKey = "modifier/key-item-locations";
    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;
    private readonly List<NewKeyItemLocation> newLocations = Csv.Deserialize<NewKeyItemLocation>(EmbeddedData.GetFile("key_items.csv")).ToList();
    private readonly List<ItemDefinition> keyItems =
        itemDefinitions
        .Items
        .Where(x => x.IsStoryProgressionItem && !x.IsDlcItem)
        .ToList();

    private string GetNameFromGuid(ItemService itemService, Guid guid)
          => itemDefinitions.FromId(itemService.FromGuid(guid).Id)!.Name!;

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        var itemService = randomizer.GetService<ItemService>();
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

        logger.Push("New key item location candidates");
        foreach (var location in newLocations)
        {
            logger.LogLine($"{GetNameFromGuid(itemService, location.Id)}: X={location.X}, Y={location.Y}, Z={location.Z}");
        }

        logger.Pop();
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-key-item-locations"))
            return;

        var rng = randomizer.GetRng(RandomizerKey);
        var itemService = randomizer.GetService<ItemService>();

        foreach (var keyItemGroup in newLocations.GroupBy(l => l.Id))
        {
            var id = keyItemGroup.Key;
            var newLocation = rng.Next(keyItemGroup);
            var placement = itemService.FromGuid(id);

            randomizer.FileRepository.ModifyScnFile(placement.Container, randomizer.IsOnRaytracingVersion, scene =>
            {
                var obj = scene.FindGameObject(id)!;
                var transform = obj.FindComponent<via.Transform>()!;
                transform.Position = new(newLocation.X, newLocation.Y, newLocation.Z);
                obj = obj.AddOrUpdateComponent(transform);
                scene = scene.UpdateGameObject(obj);
                return scene;
            });

            logger.LogLine($"Chose new location for {GetNameFromGuid(itemService, id)}: X={newLocation.X}, Y={newLocation.Y}, Z={newLocation.Z}");
        }
    }

    public class NewKeyItemLocation
    {
        public Guid Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float RotX { get; set; }
        public float RotY { get; set; }
        public float RotZ { get; set; }
        public float RotW { get; set; }
        public string? Comment { get; set; }
    }
}