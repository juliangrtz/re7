using Enums.app;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Items;

internal class ItemDrops
{
    private static readonly ImmutableDictionary<string, double> _defaultGenericDropRatios =
        new Dictionary<string, double>(StringComparer.Ordinal)
        {
            ["HandgunBullet"] = 0.2,
            ["HandgunBulletL"] = 0.2,
            ["ShotgunBullet"] = 0.2,
            ["MachineGunBullet"] = 0.2,
            ["MagnumBullet"] = 0.05,
            ["BurnerBullet"] = 0.1,
            ["FlameBulletS"] = 0.08,
            ["AcidBulletS"] = 0.08,
            ["RemedyM"] = 0.05,
            ["RemedyL"] = 0.05,
            ["EyeDrops"] = 0.2,
            ["Stimulant"] = 0.01,
            ["Depressant"] = 0.01,
            ["Herb"] = 0.1,
            ["EasyBoots"] = 0.0,
            ["AlphaGrass"] = 0.01,
            ["ChemicalM"] = 0.1,
            ["ChemicalL"] = 0.2,
            ["ChemicalS"] = 0.2,
            ["Gunpowder"] = 0.35,
            ["LiquidBomb"] = 0.05,
            ["Coin"] = 0.1,
        }.ToImmutableDictionary(StringComparer.Ordinal);

    public static ImmutableList<string> GenericDrops { get; private set; } = [
        "EasyBoots",
        "AlphaGrass",
        "LiquidBomb",
        "HandgunBullet",
        "HandgunBulletL",
        "ShotgunBullet",
        "MachineGunBullet",
        "MagnumBullet",
        "BurnerBullet",
        "FlameBulletS",
        "AcidBulletS",
        "RemedyM",
        "RemedyL",
        "EyeDrops",
        "Stimulant",
        "Depressant",
        "Herb",
        "ChemicalM",
        "ChemicalL",
        "ChemicalS",
        "Gunpowder",
        "Coin"
    ];

    public static ImmutableList<string> HighValueDrops { get; private set; } = [
        Weapon,
        DlcCoin,
        LockPick,
        RepairKit,
    ];

    public static string GetHighValueDropLabel(string highValueDrop) => highValueDrop switch
    {
        DlcCoin => "DLC Coin",
        _ => highValueDrop.Replace("-", " ").ToTitleCase()
    };

    public static List<string> GetEnabledValuableDrops() => [
        RepairKit, LockPick
    ];

    public static double GetDefaultGenericDropRatio(string id)
        => _defaultGenericDropRatios.GetValueOrDefault(id, 0.5);

    // Categories
    public const string None = "None";
    public const string CategoryAmmo = "Ammo";
    public const string CategoryHealth = "Health";
    public const string CategoryExplosive = "Explosive";
    public const string CategoryMaterial = "Material";
    public const string CategoryCoin = "Coin";
    public const string CategoryOther = "Other";
    public const string CategoryNone = "None";

    // High value drops
    public const string Weapon = "weapon";
    public const string DlcCoin = "dlc-coin";
    public const string LockPick = "lock-pick";
    public const string RepairKit = "repair-kit";

    public static string ToItemID(string highValueDrop) => highValueDrop switch
    {
        LockPick => ItemID.CylinderKey.ToString(),
        RepairKit => "RepairKit",
        _ => ItemID.NoName.ToString()
    };

    public static string GetCategory(string id) => id switch
    {
        "NoName" => CategoryNone,
        "LiquidBomb" => CategoryExplosive,
        "HandgunBullet" => CategoryAmmo,
        "HandgunBulletL" => CategoryAmmo,
        "ShotgunBullet" => CategoryAmmo,
        "MachineGunBullet" => CategoryAmmo,
        "MagnumBullet" => CategoryAmmo,
        "BurnerBullet" => CategoryAmmo,
        "FlameBulletS" => CategoryAmmo,
        "AcidBulletS" => CategoryAmmo,
        "RemedyM" => CategoryHealth,
        "RemedyL" => CategoryHealth,
        "EyeDrops" => CategoryHealth,
        "Stimulant" => CategoryHealth,
        "Depressant" => CategoryHealth,
        "Herb" => CategoryHealth,
        "ChemicalM" => CategoryMaterial,
        "ChemicalL" => CategoryMaterial,
        "ChemicalS" => CategoryMaterial,
        "Gunpowder" => CategoryMaterial,
        "GoodLuckCoinA" => CategoryCoin,
        "GoodLuckCoinB" => CategoryCoin,
        "GoodLuckCoinC" => CategoryCoin,
        "GoodLuckCoinD" => CategoryCoin,
        "GoodLuckCoinE" => CategoryCoin,
        "Coin" => CategoryCoin,
        _ => CategoryOther
    };

    public static (string BackgroundColor, string TextColor) GetColor(string category)
    {
        return category switch
        {
            CategoryAmmo => ("#66f", "#fff"),
            CategoryHealth => ("#696", "#fff"),
            CategoryExplosive => ("#833", "#fff"),
            CategoryMaterial => ("#866", "#000"),
            CategoryCoin => ("#ff0", "#000"),
            CategoryNone => ("#333", "#fff"),
            _ => ("#ddd", "#000"),
        };
    }
}
