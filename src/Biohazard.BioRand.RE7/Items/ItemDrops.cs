using Enums.app;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Items;

internal class ItemDrops
{
    public static ImmutableList<ItemID> GenericDrops { get; private set; } = [
        ItemID.EasyBoots,
        ItemID.AlphaGrass,
        ItemID.LiquidBomb,
        ItemID.HandgunBullet,
        ItemID.HandgunBulletL,
        ItemID.ShotgunBullet,
        ItemID.MachineGunBullet,
        ItemID.MagnumBullet,
        ItemID.BurnerBullet,
        ItemID.FlameBulletS,
        ItemID.AcidBulletS,
        ItemID.RemedyM,
        ItemID.RemedyL,
        ItemID.EyeDrops,
        ItemID.Stimulant,
        ItemID.Depressant,
        ItemID.Herb,
        ItemID.ChemicalM,
        ItemID.ChemicalL,
        ItemID.ChemicalS,
        ItemID.Gunpowder,
    ];

    public static ImmutableList<string> HighValueDrops { get; private set; } = [
        Weapon,
        AntiqueCoin,
        DlcCoin,
        LockPick,
        RepairKit,
        Stabilizer,
        Steroids
    ];

    public static string GetHighValueDropLabel(string highValueDrop) => highValueDrop switch
    {
        DlcCoin => "DLC Coin",
        _ => highValueDrop.Replace("-", " ").ToTitleCase()
    };

    public static List<string> GetEnabledValuableDrops() => [
        RepairKit, LockPick
    ];

    // Categories
    public const string CategoryAmmo = "Ammo";
    public const string CategoryHealth = "Health";
    public const string CategoryExplosive = "Explosive";
    public const string CategoryMaterial = "Material";
    public const string CategoryCoin = "Coin";
    public const string CategoryOther = "Other";
    public const string CategoryNone = "None";

    // High value drops
    public const string Weapon = "weapon";
    public const string AntiqueCoin = "antique-coin";
    public const string DlcCoin = "dlc-coin";
    public const string LockPick = "lock-pick";
    public const string RepairKit = "repair-kit";
    public const string Stabilizer = "stabilizer";
    public const string Steroids = "steroids";

    public static string ToItemID(string highValueDrop) => highValueDrop switch
    {
        AntiqueCoin => "Coin",
        LockPick => ItemID.CylinderKey.ToString(),
        RepairKit => "RepairKit",
        Stabilizer => "Depressant",
        Steroids => "Stimulant",
        _ => ItemID.NoName.ToString()
    };

    public static string GetCategory(ItemID id) => id switch
    {
        ItemID.NoName => CategoryNone,
        ItemID.LiquidBomb => CategoryExplosive,
        ItemID.HandgunBullet => CategoryAmmo,
        ItemID.HandgunBulletL => CategoryAmmo,
        ItemID.ShotgunBullet => CategoryAmmo,
        ItemID.MachineGunBullet => CategoryAmmo,
        ItemID.MagnumBullet => CategoryAmmo,
        ItemID.BurnerBullet => CategoryAmmo,
        ItemID.FlameBulletS => CategoryAmmo,
        ItemID.AcidBulletS => CategoryAmmo,
        ItemID.RemedyM => CategoryHealth,
        ItemID.RemedyL => CategoryHealth,
        ItemID.EyeDrops => CategoryHealth,
        ItemID.Stimulant => CategoryHealth,
        ItemID.Depressant => CategoryHealth,
        ItemID.Herb => CategoryHealth,
        ItemID.ChemicalM => CategoryMaterial,
        ItemID.ChemicalL => CategoryMaterial,
        ItemID.ChemicalS => CategoryMaterial,
        ItemID.Gunpowder => CategoryMaterial,
        ItemID.GoodLuckCoinA => CategoryCoin,
        ItemID.GoodLuckCoinB => CategoryCoin,
        ItemID.GoodLuckCoinC => CategoryCoin,
        ItemID.GoodLuckCoinD => CategoryCoin,
        ItemID.GoodLuckCoinE => CategoryCoin,
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