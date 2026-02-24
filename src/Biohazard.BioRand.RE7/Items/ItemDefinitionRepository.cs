using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using Enums.app.Item;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Items;

public class ItemDefinitionRepository : List<ItemDefinition>
{
    private static ItemDefinitionRepository? _default;
    public ImmutableArray<ItemCategoryType> Kinds { get; private set; }
    public ImmutableDictionary<ItemCategoryType, ImmutableArray<ItemDefinition>> KindToItemMap { get; private set; } = [];
    public ImmutableDictionary<string, ItemDefinition> IdToItemMap { get; private set; } = [];
    public ImmutableDictionary<WeaponID, ItemDefinition> WeaponIdToItemMap { get; private set; } = [];

    public static ItemDefinitionRepository Default
    {
        get
        {
            if (_default == null)
            {
                _default ??= EmbeddedData.GetFile("items.json").DeserializeJson<ItemDefinitionRepository>();
                _default.Initialize();
            }
            return _default;
        }
    }

    private void Initialize()
    {
        var relevantItems = this
            .Where(x => !string.IsNullOrEmpty(x.Name))
            .ToArray();

        Kinds = relevantItems
            .Select(x => x.CategoryType)
            .Distinct()
            .ToImmutableArray();

        KindToItemMap = relevantItems
            .GroupBy(x => x.CategoryType)
            .ToImmutableDictionary(x => x.Key, x => x.ToImmutableArray());

        IdToItemMap = this.ToImmutableDictionary(x => x.Id);

        WeaponIdToItemMap = this
            .Where(x => x.WeaponId != null)
            .ToImmutableDictionary(x => x.WeaponId!.Value);
    }

    public ItemDefinition? Find(string id)
    {
        IdToItemMap.TryGetValue(id, out var item);
        return item;
    }

    public string GetName(string id)
    {
        return Find(id)?.Name ?? id.ToString();
    }

    public string GetId(string name)
    {
        return this.Single(item => item.Name == name).Id;
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

    private const int NumWidth = 3;
    private const int NameWidth = 30;

    public string FormatRecipe(Recipe recipe)
    {
        var readableSrc1 = Find(recipe.SrcItemID1)?.Name ?? recipe.SrcItemID1;
        var readableSrc2 = Find(recipe.SrcItemID2)?.Name ?? recipe.SrcItemID2;
        var readableResult = Find(recipe.ResultItemID)?.Name ?? recipe.ResultItemID;

        return $"{recipe.SrcItemNum1,NumWidth}x {readableSrc1,-NameWidth} + " +
            $"{recipe.SrcItemNum2,NumWidth}x {readableSrc2,-NameWidth} ⇒ " +
            $"{recipe.ResultItemNum,NumWidth}x {readableResult,-NameWidth}";
    }
}