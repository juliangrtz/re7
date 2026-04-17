using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Weapons;
using Enums.app.GameFlowFsmManager;
using Enums.app.Item;

namespace Biohazard.BioRand.RE7.Services;

internal class ItemRandomizer(Randomizer randomizer)
{
    private readonly Randomizer _randomizer = randomizer;
    private readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;
    private readonly HashSet<string> _placedItemIds = [];
    private readonly bool _allowUnlockables = randomizer.GetConfigOption<bool>("allow-bonus-items");
    private readonly bool _allowDlcItems = randomizer.GetConfigOption<bool>("allow-dlc-items");
    private readonly Dictionary<RandomItemSettings, EndlessBag<string>> _generalDrops = new();

    public string[] PlacedItemIds => _placedItemIds.ToArray();

    public ItemDefinition[] PlacedItems => _placedItemIds
        .Select(x => ItemDefinitionRepository.Default.FromId(x)!)
        .ToArray();

    public readonly Dictionary<GameFlowKindEnum, List<string>> ChapterAmmoMap = new()
    {
        {GameFlowKindEnum.C03_1_Main, [
            "HandgunBullet", "HandgunBulletL"
        ]},
        {GameFlowKindEnum.C03_2_Main, [
            "HandgunBullet", "HandgunBulletL", "ShotgunBullet"
        ]},
        {GameFlowKindEnum.C03_3_Main, [
            "HandgunBullet", "HandgunBulletL", "ShotgunBullet",
            "MagnumBullet",
            "AcidBulletS", "FlameBulletS"
        ]},
        {GameFlowKindEnum.C03_4_Main, [
            "HandgunBullet", "HandgunBulletL", "ShotgunBullet",
            "MagnumBullet",
            "AcidBulletS", "FlameBulletS",
            "BurnerBullet"
        ]},
        {GameFlowKindEnum.C03_5_Main, [
            "HandgunBullet", "HandgunBulletL", "ShotgunBullet",
            "MagnumBullet",
            "AcidBulletS", "FlameBulletS",
            "BurnerBullet"
        ]},
        {GameFlowKindEnum.C04_1_Main, ["MachineGunBullet"]},
        {GameFlowKindEnum.C04_2_Main, ["MachineGunBullet"]},
        {GameFlowKindEnum.C04_3_Main, ["MachineGunBullet"]},
    };

    private const int ItemStackCeiling = 150;
    private const double EasyAmmoDropAmountFactor = 1.5f;
    private const double NormalAmmoDropAmountFactor = 1f;
    private const double MadhouseAmmoDropAmountFactor = 0.75f;

    // (easy #, normal #, madhouse #)
    public (uint, uint, uint) ApplyDifficultyToDropAmount(uint amount)
        => (
            (uint)Math.Max(1, Math.Round(amount * EasyAmmoDropAmountFactor)),
            (uint)Math.Max(1, Math.Round(amount * NormalAmmoDropAmountFactor)),
            (uint)Math.Max(1, Math.Round(amount * MadhouseAmmoDropAmountFactor))
        );

    // (easy #, normal #, madhouse #)
    public (uint, uint, uint) DetermineDropAmount(string id, double min, double max, Rng rng)
    {
        var item = _itemDefinitions.FromId(id.ToString())!;
        var respectDifficulty = _randomizer.GetConfigOption<bool>("item-drop-respect-difficulty");

        if (item.CategoryType == ItemCategoryType.Shell)
        {
            var stack = Math.Min(item.MaxStack, ItemStackCeiling); // Avoid overly generous drops
            var minAmount = Math.Max(1, (int)Math.Round(min * stack));
            var maxAmount = Math.Min(stack, (int)Math.Round(max * stack));
            var result = (uint)rng.Next(minAmount, maxAmount + 1);
            return respectDifficulty ? ApplyDifficultyToDropAmount(result) : (result, result, result);
        }
        else
        {
            return (1u, 1u, 1u);
        }
    }

    public ItemDefinition? GetRandomGun(Rng rng, bool allowReoccurance = true)
    {
        static bool Check(ItemDefinition item)
        {
            if (item.WeaponId == null)
                return false;

            if (WeaponDefinitionRepository.Default.IsRestricted(item.WeaponId.Value))
                return false;

            var definition = WeaponDefinitionRepository.Default.FromWeaponId(item.WeaponId.Value.ToString());
            if (definition.UserType != Enums.app.CharacterDefine.Type.Player)
                return false;

            if (!definition.IsGun)
                return false;

            return true;
        }

        return GetRandomItemDefinition(rng, ItemCategoryType.Weapon, allowReoccurance, Check);
    }

    public ItemDefinition? GetRandomItemDefinition(Rng rng, ItemCategoryType kind, bool allowReoccurance = true, Func<ItemDefinition, bool>? extraCheck = null)
    {
        var itemRepo = ItemDefinitionRepository.Default;
        var poolEnumerable = itemRepo
            .GetAll(kind)
            .Where(IsItemAllowed);
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

    public bool IsItemAllowed(ItemDefinition itemDefinition)
    {
        if (itemDefinition.IsStoryProgressionItem)
            return false;
        if (itemDefinition.IsUnlockable)
            return _allowUnlockables;
        if (itemDefinition.Dlc != null)
            return _allowDlcItems;

        return true;
    }

    public Item GetNextGeneralDrop(Rng rng, RandomItemSettings settings)
    {
        var bag = CreateGeneralItemPool(settings, rng);

        // TODO optimise this
        var id = bag.Next();
        for (var i = 0; i < 1000; i++)
        {
            if (settings.ValidateFunc?.Invoke(id) != false)
            {
                break;
            }
            id = bag.Next();
        }

        var (easyAmount, normalAmount, madhouseAmount) = DetermineDropAmount(id, settings.MinAmmoQuantity, settings.MaxAmmoQuantity, rng);
        return new Item()
        {
            Id = id.ToString(),
            CountEasy = (int)easyAmount,
            CountNormal = (int)normalAmount,
            CountMadhouse = (int)madhouseAmount,
        };
    }

    public EndlessBag<string> CreateGeneralItemPool(RandomItemSettings settings, Rng rng)
    {
        if (!_generalDrops.TryGetValue(settings, out var result))
        {
            var ratios = new Dictionary<string, double>();
            foreach (var dropKind in ItemDrops.GenericDrops)
            {
                var ratio = settings.GetItemRatio(dropKind);
                if (ratio > 0)
                {
                    ratios.Add(dropKind, ratio);
                }
            }

            if (ratios.Count == 0)
                return new EndlessBag<string>(rng, ["EthanLeg"]);

            var smallestRatio = ratios.Min(x => x.Value);
            foreach (var k in ratios.Keys)
            {
                ratios[k] = ratios[k] / smallestRatio;
            }

            var pool = new List<string>();
            foreach (var kvp in ratios)
            {
                for (var i = 0; i < kvp.Value; i++)
                {
                    pool.Add(kvp.Key);
                }
            }
            result = new EndlessBag<string>(rng, pool);
            _generalDrops[settings] = result;
        }

        return result;
    }

    private Item? GetRandomSingleItem(Rng rng, ItemCategoryType kind, bool allowReoccurance = false)
    {
        ItemDefinition? itemDefinition = kind switch
        {
            ItemCategoryType.Weapon => GetRandomGun(rng, allowReoccurance),
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


    public void MarkItemPlaced(string id) => _placedItemIds.Add(id);

    public bool IsItemPlaced(string id) => _placedItemIds.Contains(id);
}

public class RandomItemSettings
{
    public double MinAmmoQuantity { get; set; }
    public double MaxAmmoQuantity { get; set; }
    public Func<string, double>? ItemRatioKeyFunc { get; set; }
    public Func<string, bool>? ValidateFunc { get; set; }

    public double GetItemRatio(string id)
    {
        return ItemRatioKeyFunc?.Invoke(id) ?? 0;
    }
}