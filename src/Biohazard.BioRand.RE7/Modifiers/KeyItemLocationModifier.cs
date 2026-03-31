using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Services;
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
        var itemService = randomizer.ItemPlacementService;
        var csv = randomizer.DynamicData.GetData(DynamicDataName.KeyItems) ?? throw new Exception("Unable to get key item data");
        var keyItems = Csv.Deserialize<KeyItemLocation>(csv)
            .Where(k => k.Enabled && !string.IsNullOrWhiteSpace(k.Id))
            .ToImmutableList();

        // Delete all original key item locations
        foreach (var keyItem in keyItems)
        {
            randomizer.FileRepository.ModifyScnFile(keyItem.OriginalScnFile, randomizer.IsOnRaytracingVersion, scene =>
            {
                var placements = itemService.FromId(keyItem.Id);
                foreach (var placement in placements)
                {
                    scene = scene.RemoveGameObject(placement.Guid);
                }
                return scene;
            });
        }

        // Add random new location
        var groups = keyItems.GroupBy(k => k.Id).ToList();
        foreach (var group in groups)
        {
            var newLocation = rng.Next(group);
            randomizer.FileRepository.ModifyScnFile(newLocation.NewScnFile, randomizer.IsOnRaytracingVersion, scene =>
            {
                RszGameObject parentGameObject = scene.FindGameObject(go => go.Name.EndsWith("_dynamic"))
                    ?? throw new Exception("Failed to obtain \"_dynamic\" parent GameObject!");
                var template = randomizer.TemplateService.GetItemTemplate(newLocation.Id);

                var transform = template.FindComponent<via.Transform>()!;
                transform.Position = new Vector3(newLocation.NewX, newLocation.NewY, newLocation.NewZ);
                template = template.AddOrUpdateComponent(transform);

                parentGameObject = parentGameObject.AddOrUpdateChild(template);
                return scene.UpdateGameObject(parentGameObject);
            });
            logger.LogLine($"Chose new location for {newLocation.Id} in scene {newLocation.NewScnFile}: X={newLocation.NewX}, Y={newLocation.NewY}, Z={newLocation.NewZ}");
        }
    }

    internal class KeyItemLocation
    {
        public bool Enabled { get; init; }
        public string OriginalScnFile { get; init; } = "";
        public string NewScnFile { get; init; } = "";
        public string Id { get; init; } = "";
        public float NewX { get; init; }
        public float NewY { get; init; }
        public float NewZ { get; init; }
        public string Comment { get; init; } = "";
    }
}