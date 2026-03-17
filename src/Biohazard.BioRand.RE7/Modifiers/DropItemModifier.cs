using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Enums.app;
using Enums.app.GameFlowFsmManager;
using Enums.app.Item;
using IntelOrca.Biohazard.BioRand;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class DropItemModifier : Modifier
{
    private const string RandomizerKey = "modifier/item-drops";
    private static readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    private readonly List<(GameFlowKindEnum, string)> _dropTableFiles = new() {
        (GameFlowKindEnum.C03_1_Main, PakPath.UserFile("prefab/item/reliefitemtable_03_01_0000.user")),
        (GameFlowKindEnum.C03_2_Main, PakPath.UserFile("prefab/item/reliefitemtable_03_02_0000.user")),
        (GameFlowKindEnum.C03_2_Main, PakPath.UserFile("prefab/item/reliefitemtable_03_02_0600.user")),
        (GameFlowKindEnum.C03_3_Main, PakPath.UserFile("prefab/item/reliefitemtable_03_03_0000.user")),
        (GameFlowKindEnum.C03_3_Main, PakPath.UserFile("prefab/item/reliefitemtable_03_03_1000.user")),
        (GameFlowKindEnum.C03_4_Main, PakPath.UserFile("prefab/item/reliefitemtable_03_04_0000.user")),
        (GameFlowKindEnum.C03_5_Main, PakPath.UserFile("prefab/item/reliefitemtable_03_05_0000.user")),
        (GameFlowKindEnum.C04_1_Main, PakPath.UserFile("prefab/item/reliefitemtable_04_01_0000.user")),
        (GameFlowKindEnum.C04_2_Main, PakPath.UserFile("prefab/item/reliefitemtable_04_02_0000.user")),
        (GameFlowKindEnum.C04_3_Main, PakPath.UserFile("prefab/item/reliefitemtable_04_02_0500.user")),
        (GameFlowKindEnum.C04_3_Main, PakPath.UserFile("prefab/item/reliefitemtable_04_03_0000.user")),
    };

    // 
    private readonly Dictionary<GameFlowKindEnum, List<ItemID>> _allowedAmmoTypes = new()
    {
        {GameFlowKindEnum.C03_1_Main, [
            ItemID.HandgunBullet, ItemID.HandgunBulletL
        ]},
        {GameFlowKindEnum.C03_2_Main, [
            ItemID.HandgunBullet, ItemID.HandgunBulletL, ItemID.ShotgunBullet
        ]},
        {GameFlowKindEnum.C03_3_Main, [
            ItemID.HandgunBullet, ItemID.HandgunBulletL, ItemID.ShotgunBullet,
            ItemID.MagnumBullet,
            ItemID.AcidBulletS, ItemID.FlameBulletS
        ]},
        {GameFlowKindEnum.C03_4_Main, [
            ItemID.HandgunBullet, ItemID.HandgunBulletL, ItemID.ShotgunBullet,
            ItemID.MagnumBullet,
            ItemID.AcidBulletS, ItemID.FlameBulletS,
            ItemID.BurnerBullet
        ]},
        {GameFlowKindEnum.C03_5_Main, [
            ItemID.HandgunBullet, ItemID.HandgunBulletL, ItemID.ShotgunBullet,
            ItemID.MagnumBullet,
            ItemID.AcidBulletS, ItemID.FlameBulletS,
            ItemID.BurnerBullet
        ]},
        {GameFlowKindEnum.C04_1_Main, [ItemID.MachineGunBullet]},
        {GameFlowKindEnum.C04_2_Main, [ItemID.MachineGunBullet]},
        {GameFlowKindEnum.C04_3_Main, [ItemID.MachineGunBullet]},
    };

    private readonly Dictionary<string, uint> _highValueProbabilities = new()
    {
        {ItemDrops.AntiqueCoin, 10u },
        {ItemDrops.LockPick, 15u },
        {ItemDrops.RepairKit, 15u },
        {ItemDrops.Stabilizer, 5u },
        {ItemDrops.Steroids, 5u }
    };

    // (id, min%, max%)
    // TODO: Look into this, weapons don't spawn :(
    private readonly Dictionary<WeaponID, (uint, uint)> _valuableWeaponDrops = new() {
        //{ WeaponID.Bar, (5, 10) },
        //{ WeaponID.MachineGun, (3, 5) },
        //{ WeaponID.Burner, (3, 5) },
        //{ WeaponID.ChainSaw, (1, 3) },
        //{ WeaponID.GrenadeLauncher, (2, 4) },
        //{ WeaponID.HandAxe, (10, 15) },
        //{ WeaponID.Handgun_G17, (5, 10) },
        //{ WeaponID.Handgun_M19, (5, 10) },
        //{ WeaponID.Handgun_MPM, (5, 10) },
        { WeaponID.LiquidBomb, (3, 5) }, // Remote Bomb
        //{ WeaponID.Magnum, (1, 2) },
        //{ WeaponID.Shotgun_DB, (5, 7) },
        //{ WeaponID.Shotgun_M37, (5, 7) },
    };

    // (id, min%, max%)
    private readonly Dictionary<string, (uint, uint)> _dlcCoinDrops = new()
    {
        {"GoodLuckCoinA_Buy", (3, 5)},  // Defense Coin
        {"GoodLuckCoinB_Buy", (3, 5)}, // Attack Coin
        {"GoodLuckCoinC_Buy", (5, 10)}, // Instinct Coin
        {"GoodLuckCoinD_Buy", (10, 15)}, // Reload Coin
        {"GoodLuckCoinE_Buy", (1, 3)} // Universal Coin
    };

    private const double EasyAmmoDropAmountFactor = 1.5f;
    private const double NormalAmmoDropAmountFactor = 1f;
    private const double MadhouseAmmoDropAmountFactor = 0.75f;
    private const uint ValuableDropNum = 1u;

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        logger.Push("Original item drop tables");
        foreach (var (chapter, path) in _dropTableFiles)
        {
            logger.Push(chapter.ToString().Without("_Main"));
            var deserialized = randomizer.FileRepository.DeserializeUserFile<ItemDropTable>(path)
                ?? throw new RandomizerUserException($"Failed to deserialize {path}! Report this please.");

            deserialized.Log(logger);
            logger.Pop();
        }

        logger.Pop();
    }

    // (easy #, normal #, madhouse #)
    private (uint, uint, uint) ApplyDifficultyToDropAmount(uint amount)
        => (
            (uint)Math.Max(1, Math.Round(amount * EasyAmmoDropAmountFactor)),
            (uint)Math.Max(1, Math.Round(amount * NormalAmmoDropAmountFactor)),
            (uint)Math.Max(1, Math.Round(amount * MadhouseAmmoDropAmountFactor))
        );

    // (easy #, normal #, madhouse #)
    private (uint, uint, uint) DetermineDropAmount(ItemID id, bool respectDifficulty, double min, double max, Rng rng)
    {
        var item = _itemDefinitions.FromId(id.ToString())!;
        if (item.CategoryType == ItemCategoryType.Shell)
        {
            var minAmount = Math.Max(1, (int)Math.Round(min * item.MaxStack));
            var maxAmount = Math.Min(item.MaxStack, (int)Math.Round(max * item.MaxStack));
            var result = (uint)rng.Next(minAmount, maxAmount + 1);
            return respectDifficulty ? ApplyDifficultyToDropAmount(result) : (result, result, result);
        }
        else
        {
            return (1u, 1u, 1u);
        }
    }

    private ItemDropTable ConstructItemDropTable(Randomizer randomizer, GameFlowKindEnum chapter)
    {
        var result = new ItemDropTable()
        {
            _Comment = $"Generated by BioRand for chapter {chapter}."
        };

        var respectDifficulty = randomizer.GetConfigOption<bool>("item-drop-respect-difficulty");
        var ammoOnlyAvailableWeapons = randomizer.GetConfigOption<bool>("item-drop-ammo-only-available-weapons");
        var min = randomizer.GetConfigOption("item-drop-ammo-min", 0.1);
        var max = randomizer.GetConfigOption("item-drop-ammo-max", 1.0);
        var rng = randomizer.GetRng(RandomizerKey);

        foreach (var id in ItemDrops.GenericDrops)
        {
            var idStr = id.ToString();
            var item = _itemDefinitions.FromId(idStr)!;

            var rate = randomizer.GetConfigOption<double>($"item-drop-ratio-{idStr.ToLowerInvariant()}");
            if (rate <= 0)
                continue;

            if (ammoOnlyAvailableWeapons
                && item.CategoryType == ItemCategoryType.Shell
                && _allowedAmmoTypes.TryGetValue(chapter, out var allowedAmmo)
                && !allowedAmmo.Contains(id))
            {
                continue;
            }

            var ratePct = (uint)(rate * 100.0);
            var (easyDropAmount, normalDropAmount, madhouseDropAmount) = DetermineDropAmount(id, respectDifficulty, min, max, rng);

            result.DataList.Add(new ItemDropDistribution()
            {
                ItemID = idStr,
                EasyDropRate = ratePct,
                NormalDropRate = ratePct,
                HardDropRate = ratePct,
                ReliefDropNum = easyDropAmount,
                NormalDropNum = normalDropAmount,
                ReliefNum = madhouseDropAmount
            });
        }

        foreach (var type in ItemDrops.HighValueDrops)
        {
            if (randomizer.GetConfigOption<bool>($"item-drop-valuable-{type}"))
            {
                string id = ItemID.NoName.ToString();
                uint chance = 0u;

                if (type == ItemDrops.Weapon)
                {
                    foreach (var (weaponId, (minWeaponPct, maxWeaponPct)) in _valuableWeaponDrops)
                    {
                        var weaponChance = (uint)rng.Next((int)minWeaponPct, (int)maxWeaponPct);
                        result.DataList.Add(new ItemDropDistribution()
                        {
                            ItemID = weaponId.ToString(),
                            EasyDropRate = weaponChance,
                            NormalDropRate = weaponChance,
                            HardDropRate = weaponChance,
                            ReliefDropNum = ValuableDropNum,
                            NormalDropNum = ValuableDropNum,
                            ReliefNum = ValuableDropNum
                        });
                    }

                    continue;
                }
                else if (type == ItemDrops.DlcCoin)
                {
                    foreach (var (coinId, (coinPctMin, coinPctMax)) in _dlcCoinDrops)
                    {
                        var coinChance = (uint)rng.Next((int)coinPctMin, (int)coinPctMax);
                        result.DataList.Add(new ItemDropDistribution()
                        {
                            ItemID = coinId.ToString(),
                            EasyDropRate = coinChance,
                            NormalDropRate = coinChance,
                            HardDropRate = coinChance,
                            ReliefDropNum = ValuableDropNum,
                            NormalDropNum = ValuableDropNum,
                            ReliefNum = ValuableDropNum
                        });
                    }
                }
                else
                {
                    id = ItemDrops.ToItemID(type);
                    chance = _highValueProbabilities[type];
                }

                result.DataList.Add(new ItemDropDistribution()
                {
                    ItemID = id,
                    EasyDropRate = chance,
                    NormalDropRate = chance,
                    HardDropRate = chance,
                    ReliefDropNum = ValuableDropNum,
                    NormalDropNum = ValuableDropNum,
                    ReliefNum = ValuableDropNum
                });
            }
        }

        return result;
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var (chapter, path) in _dropTableFiles)
        {
            var dropTable = ConstructItemDropTable(randomizer, chapter);

            logger.Push($"Modified item drop table ({chapter})");
            dropTable.Log(logger);
            logger.Pop();

            randomizer.FileRepository.ModifyUserFile<ItemDropTable>(path, _ => dropTable);
        }
    }
}
