using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using Enums.app.Item;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Items;

public class ItemDefinitionRepository
{
    private static ItemDefinitionRepository? _default;
    public List<ItemDefinition> Items { get; private set; } = [];
    public ImmutableArray<ItemCategoryType> Kinds { get; private set; }
    public ImmutableDictionary<ItemCategoryType, ImmutableArray<ItemDefinition>> KindToItemMap { get; private set; } = [];
    public ImmutableDictionary<string, ItemDefinition> IdToItemMap { get; private set; } = [];
    public ImmutableDictionary<string, ItemDefinition> NameToItemMap { get; private set; } = [];
    public ImmutableDictionary<WeaponID, ItemDefinition> WeaponIdToItemMap { get; private set; } = [];
    private const string ItemDefinitionFileName = "item_definitions.json";

    public static ItemDefinitionRepository Default
    {
        get
        {
            if (_default == null)
            {
                _default = new ItemDefinitionRepository
                {
                    Items = EmbeddedData.GetFile(ItemDefinitionFileName).DeserializeJson<List<ItemDefinition>>()
                };
                _default.Initialize();
            }
            return _default;
        }
    }

    private void Initialize()
    {
        var relevantItems = Items
            .Where(x => !string.IsNullOrEmpty(x.Name))
            .ToArray();

        Kinds = relevantItems
            .Select(x => x.CategoryType)
            .Distinct()
            .ToImmutableArray();

        KindToItemMap = relevantItems
            .GroupBy(x => x.CategoryType)
            .ToImmutableDictionary(x => x.Key, x => x.ToImmutableArray());

        IdToItemMap = Items.ToImmutableDictionary(x => x.Id);

        WeaponIdToItemMap = Items
            .Where(x => x.WeaponId != null)
            .ToImmutableDictionary(x => x.WeaponId!.Value);
    }

    public ItemDefinition? FromId(string id)
    {
        IdToItemMap.TryGetValue(id, out var item);
        return item;
    }

    public ItemDefinition? FromName(string name)
    {
        return IdToItemMap[GetIdByName(name)];
    }

    public string GetName(string id)
    {
        return FromId(id)?.Name ?? id.ToString();
    }

    public string GetIdByName(string name)
    {
        return Items.First(item => item.Name == name).Id;
    }

    public ItemDefinition? FromWeaponId(WeaponID id)
    {
        WeaponIdToItemMap.TryGetValue(id, out var item);
        return item;
    }

    public ItemDefinition[] GetAll(ItemCategoryType kind)
    {
        var items = KindToItemMap[kind].ToArray();
        return items;
    }
}