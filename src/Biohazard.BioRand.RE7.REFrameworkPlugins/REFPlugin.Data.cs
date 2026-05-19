using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;
public partial class REFPlugin
{
    private static readonly string[] GenericEnemyDropItemDataIds =
    [
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
        "Herb",
        "ChemicalM",
        "ChemicalL",
        "ChemicalS",
        "Gunpowder",
        "Coin",
        "Alcohol",
    ];

    private static readonly HashSet<string> AmmoEnemyDropItemDataIds = new(StringComparer.Ordinal)
    {
        "HandgunBullet",
        "HandgunBulletL",
        "ShotgunBullet",
        "MachineGunBullet",
        "MagnumBullet",
        "BurnerBullet",
        "FlameBulletS",
        "AcidBulletS",
    };

    private static readonly Dictionary<string, int> DefaultEnemyDropStackLimits = new(StringComparer.Ordinal)
    {
        ["HandgunBullet"] = 30,
        ["HandgunBulletL"] = 20,
        ["ShotgunBullet"] = 30,
        ["MachineGunBullet"] = 300,
        ["MagnumBullet"] = 20,
        ["BurnerBullet"] = 500,
        ["FlameBulletS"] = 5,
        ["AcidBulletS"] = 5,
        ["Coin"] = 999,
        ["CylinderKey"] = 20,
        ["EyeDrops"] = 5,
        ["Gunpowder"] = 10,
        ["Herb"] = 5,
        ["LiquidBomb"] = 20,
        ["RemedyL"] = 3,
        ["RemedyM"] = 3,
        ["Alcohol"] = 5,
    };

    private static readonly Dictionary<string, string[]> ChapterAmmoAvailability = new(StringComparer.Ordinal)
    {
        ["C00_Main"] = ["HandgunBullet", "HandgunBulletL"],
        ["C01_Main"] = ["HandgunBullet", "HandgunBulletL"],
        ["C03_1_Main"] = ["HandgunBullet", "HandgunBulletL"],
        ["C03_2_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet"],
        ["C03_3_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet", "MagnumBullet", "AcidBulletS", "FlameBulletS"],
        ["C03_4_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet", "MagnumBullet", "AcidBulletS", "FlameBulletS", "BurnerBullet"],
        ["C03_5_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet", "MagnumBullet", "AcidBulletS", "FlameBulletS", "BurnerBullet"],
        ["C04_1_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet", "MagnumBullet", "AcidBulletS", "FlameBulletS", "BurnerBullet", "MachineGunBullet"],
        ["C04_2_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet", "MagnumBullet", "AcidBulletS", "FlameBulletS", "BurnerBullet", "MachineGunBullet"],
        ["FF050_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet", "MagnumBullet", "AcidBulletS", "FlameBulletS", "BurnerBullet", "MachineGunBullet"],
        ["C04_3_Main"] = ["HandgunBullet", "HandgunBulletL", "ShotgunBullet", "MagnumBullet", "AcidBulletS", "FlameBulletS", "BurnerBullet", "MachineGunBullet"],
    };

    private static readonly Dictionary<string, (int MinWeight, int MaxWeight)> DlcCoinWeights = new(StringComparer.Ordinal)
    {
        ["GoodLuckCoinA_Buy"] = (3, 5),
        ["GoodLuckCoinB_Buy"] = (3, 5),
        ["GoodLuckCoinC_Buy"] = (5, 10),
        ["GoodLuckCoinD_Buy"] = (10, 15),
        ["GoodLuckCoinE_Buy"] = (1, 3),
    };

    public static ImmutableArray<string> BirthdaySkillItemDataIds { get; } =
       new int[] {
               /* 1  Infinite Ammo */
               2 /* Health Regen */,
               /*3  Clairvoyance (Perma Psychostimulants) */
               /* 4, 5, 6, 7 (Time Bonuses) */
               8 /* Defense II */,
               9 /* Defense I */,
               10 /* Speed Up II */,
               11 /* Speed Up I */,
               12 /* Firepower Up II */,
               13 /* Firepower Up I */,
               14 /* Impact II */,
               15 /* Impact I */,
               16 /* Toughness II */,
               17 /* Toughness I */,
               18 /* Guard Up */,
               19 /* Quick Reload */,
               /* 20 (Masochist) */
               21 /* Vengeance */,
               22 /* Narrow Escape */,
               23 /* Brawler */,
       }.Select(index => $"skl{index:000}")
        .ToImmutableArray();

    private static readonly Dictionary<string, string> EnemyDropProbabilityConfigIdsByTypeId = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Em3000"] = "jackstalker",
        ["Em3001"] = "jackstalker",
        ["Em3600"] = "margemutated",
        ["Em4000"] = "molded",
        ["Em4100"] = "moldedquick",
        ["Em4200"] = "moldedfat",
        ["Em5400"] = "flyingbug",
        ["Em5510"] = "insecthive",
        ["Em5511"] = "insecthive",
        ["Em5512"] = "insecthive",
        ["Em5520"] = "insectswarm",
        ["Em8000"] = "jackshears",
        ["Em8001"] = "jackshears",
        ["Em8100"] = "jackmutated",
    };

    private static readonly Dictionary<string, double> SpecialEnemyDropMultipliers = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Em4200"] = 1.25, // Fat Molded
        ["Em2000"] = 1.35, // Mia
        ["Em3001"] = 1.5, // Stalker Jack
        ["Em8000"] = 1.75, // Chainsaw Jack
        ["Em8001"] = 1.75, // Chainsaw Jack
        ["Em3600"] = 2, // Mutated Marguerite
    };

    private static readonly HashSet<string> BossEnemyTypeIds = new(StringComparer.OrdinalIgnoreCase)
    {
        "Em2000", // Mia
        "Em3001", // Stalker Jack
        "Em3600", // Mutated Marguerite
        "Em8000", // Chainsaw Jack
        "Em8001", // Chainsaw Jack
    };

    private static readonly HashSet<string> SingleDropPerSpawnEnemyTypeIds = new(StringComparer.OrdinalIgnoreCase)
    {
        "Em5510", // Insect hive
        "Em5511",
        "Em5512",
    };

    private static readonly HashSet<string> BossEnemyDropItemDataIds = new(StringComparer.Ordinal)
    {
        "LiquidBomb",
        "HandgunBulletL",
        "ShotgunBullet",
        "MagnumBullet",
        "FlameBulletS",
        "AcidBulletS",
        "RemedyL",
        "ChemicalM",
        "Coin",
    };
    private readonly record struct EnemyDropCandidate(string ItemDataId, double Weight);

    private readonly record struct EnemyDropSelection(string ItemDataId, int StackNum);

    private sealed class Em3300ExplosionState
    {
        public bool CountdownStarted { get; set; }
        public long CountdownStartedAt { get; set; }
        public double DelaySeconds { get; set; }
        public bool Exploded { get; set; }
        public long ExplodedAt { get; set; }
        public bool Despawned { get; set; }
    }
}
