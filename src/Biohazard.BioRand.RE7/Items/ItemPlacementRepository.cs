using Biohazard.BioRand.RE7.Serialization;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Items;

public class ItemPlacementRepository : List<ItemPlacement>
{
    private static ItemPlacementRepository? _default;
    public ImmutableDictionary<ItemPlacement, ItemDefinition> PlacementToItemMap { get; private set; } = [];
    public ImmutableDictionary<string, List<ItemPlacement>> IdToItemsMap { get; private set; } = [];
    public ImmutableList<ItemPlacement> MainGamePlacements { get; private set; } = [];

    private const string ItemPlacementFileName = "item_placements.json";

    public static ItemPlacementRepository Default
    {
        get
        {
            if (_default == null)
            {
                _default ??= EmbeddedData.GetFile(ItemPlacementFileName).DeserializeJson<ItemPlacementRepository>();
                _default.Initialize();
            }
            return _default;
        }
    }

    private void Initialize()
    {
        PlacementToItemMap = this.ToImmutableDictionary(x => x, x => ItemDefinitionRepository.Default.FromId(x.Id)!);
        IdToItemsMap = this.GroupBy(x => x.Id).ToImmutableDictionary(g => g.Key, g => g.ToList());
        MainGamePlacements = this.Where(x => x.Dlc == null).ToImmutableList();
    }

    public List<ItemPlacement> FromId(string id)
    {
        if (!IdToItemsMap.TryGetValue(id, out var item))
        {
            return new List<ItemPlacement>();
        }

        return item;
    }
}