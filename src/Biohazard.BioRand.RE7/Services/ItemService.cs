using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Services;

internal class ItemService
{
    public ImmutableList<ItemPlacement> ItemPlacements { get; private set; }
    public ImmutableDictionary<ItemPlacement, ItemDefinition> PlacementToItemMap { get; private set; } = [];
    public ImmutableDictionary<string, List<ItemPlacement>> IdToItemsMap { get; private set; } = [];
    public ImmutableList<ItemPlacement> MainGamePlacements { get; private set; } = [];

    public ItemService(Randomizer randomizer)
    {
        var csv = randomizer.DynamicData.GetData(DynamicDataName.ItemPlacements) ?? throw new Exception("Unable to get item data");
        ItemPlacements = Csv.Deserialize<ItemPlacement>(csv)
            .Where(x => x.Enabled)
            .ToImmutableList();

        PlacementToItemMap = ItemPlacements.ToImmutableDictionary(x => x, x => ItemDefinitionRepository.Default.FromId(x.Id)!);
        IdToItemsMap = ItemPlacements.GroupBy(x => x.Id).ToImmutableDictionary(g => g.Key, g => g.ToList());
        MainGamePlacements = ItemPlacements.Where(x => x.Dlc == null).ToImmutableList();
    }

    public List<ItemPlacement> FromId(string id)
    {
        if (!IdToItemsMap.TryGetValue(id, out var item))
        {
            return new List<ItemPlacement>();
        }

        return item;
    }

    public ItemPlacement FromGuid(Guid guid) => ItemPlacements.Single(x => x.Guid == guid);

    public ItemPlacement FromGuid(string guid) => ItemPlacements.Single(x => x.Guid == new Guid(guid));
}
