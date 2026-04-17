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

        // Delete all original key item locations
        // TODO: Copy original Guids to new key items
        foreach (var keyItem in keyItems)
        {
            randomizer.FileRepository.ModifyScnFile(keyItem.OriginalScnFile, scene =>
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
            randomizer.FileRepository.ModifyScnFile(newLocation.NewScnFile, scene =>
            {
                RszGameObject parentGameObject = scene.FindGameObject(go => go.Name.EndsWith("_dynamic"))
                    ?? throw new Exception("Failed to obtain \"_dynamic\" parent GameObject!");
                var template = randomizer.TemplateService.GetItemTemplate(newLocation.Id).Clone();
                template = template.WithGuid(Guid.NewGuid());

                var item = template.FindComponent<app.Item>();
                if (item != null)
                {
                    item.ItemDataID = newLocation.Id;
                    item.SaveGUID = Guid.NewGuid();
                    template = template.AddOrUpdateComponent(item);
                }

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
