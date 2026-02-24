using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using Enums.app.Item;

namespace Biohazard.BioRand.RE7.Services;

internal class ItemRandomizer
{
    private readonly RE7Randomizer _randomizer;
    private readonly HashSet<string> _placedItemIds = [];
    private readonly bool _allowBonusItems;
    private readonly bool _allowDlcItems;
    private readonly Dictionary<RandomItemSettings, EndlessBag<string>> _generalDrops = new();
    private readonly HashSet<string> _throwAway = [];

    public string[] PlacedItemIds => _placedItemIds.ToArray();

    public ItemDefinition[] PlacedItems => _placedItemIds
        .Select(x => ItemDefinitionRepository.Default.FromId(x)!)
        .ToArray();

    public ItemRandomizer(RE7Randomizer randomizer)
    {
        _randomizer = randomizer;
        _allowBonusItems = randomizer.GetConfigOption<bool>("allow-bonus-items");
        _allowDlcItems = randomizer.GetConfigOption<bool>("allow-dlc-items");
    }

    public ItemDefinition? GetRandomWeapon(Rng rng, bool allowReoccurance = true, bool excludeLegendary = false)
    {
        bool restrictedCheck(ItemDefinition item)
        {
            if (!excludeLegendary)
                return true;

            if (item.WeaponId is not WeaponID weaponId)
                return false;

            return _randomizer
                .GetService<WeaponService>()
                .IsRestricted(weaponId);
        }

        return GetRandomItemDefinition(rng, ItemCategoryType.Weapon, allowReoccurance, restrictedCheck);
    }

    public ItemDefinition? GetRandomItemDefinition(Rng rng, ItemCategoryType kind, bool allowReoccurance = true, Func<ItemDefinition, bool>? extraCheck = null)
    {
        var itemRepo = ItemDefinitionRepository.Default;
        var poolEnumerable = itemRepo
            .GetAll(kind)
            .Where(IsItemSupported);
        if (extraCheck != null)
        {
            poolEnumerable = poolEnumerable.Where(extraCheck);
        }
        if (!allowReoccurance)
        {
            poolEnumerable = poolEnumerable
                .Where(x => !_placedItemIds.Contains(x.Id));
        }
        var pool = poolEnumerable.ToArray();
        if (pool.Length == 0)
            return null;

        var chosen = rng.Next(pool);
        _placedItemIds.Add(chosen.Id);
        return chosen;
    }

    private bool IsItemSupported(ItemDefinition itemDefinition)
    {
        if (_throwAway.Contains(itemDefinition.Id))
            return false;
        if (itemDefinition.IsUnlockable)
            return _allowBonusItems;
        if (itemDefinition.Dlc != null)
            return _allowDlcItems;

#if !ENABLE_BETA_FEATURES
        if (itemDefinition.Id == ItemIds.Flamethrower)
        {
            return false;
        }
#endif
        return true;
    }

    public EndlessBag<string> CreateGeneralItemPool(RandomItemSettings settings, Rng rng)
    {
        return new EndlessBag<string>();
    }

    private Item? GetRandomSingleItem(Rng rng, ItemCategoryType kind, bool allowReoccurance = false)
    {
        ItemDefinition? itemDefinition = kind switch
        {
            ItemCategoryType.Weapon => GetRandomWeapon(rng, allowReoccurance),
            _ => GetRandomItemDefinition(rng, kind, allowReoccurance),
        };
        if (itemDefinition != null)
            return new Item(itemDefinition.Id, 1);
        return null;
    }

    public Item? GetRandomAmmo(string? itemId, Rng rng, RandomItemSettings settings)
    {
        var itemDef = itemId == null
            ? GetRandomItemDefinition(rng, ItemCategoryType.Shell)
            : ItemDefinitionRepository.Default.FromId(itemId);
        if (itemDef == null)
            return null;

        var min = settings.MinAmmoQuantity;
        var max = settings.MaxAmmoQuantity;
        var minAmount = Math.Max(1, (int)Math.Round(min * itemDef.MaxStack));
        var maxAmount = Math.Min(itemDef.MaxStack, (int)Math.Round(max * itemDef.MaxStack));
        var amount = rng.Next(minAmount, maxAmount + 1);
        return new Item(itemDef.Id, amount);
    }
}

public class RandomItemSettings
{
    public double MinAmmoQuantity { get; set; }
    public double MaxAmmoQuantity { get; set; }
    public int MinMoneyQuantity { get; set; }
    public int MaxMoneyQuantity { get; set; }
    public Func<string, double>? ItemRatioKeyFunc { get; set; }
    public Func<string, bool>? ValidateDropKind { get; set; }

    public double GetItemRatio(string dropKind)
    {
        return ItemRatioKeyFunc?.Invoke(dropKind) ?? 0;
    }
}