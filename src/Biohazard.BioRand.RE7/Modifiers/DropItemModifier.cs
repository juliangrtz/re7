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
    private static readonly ItemDropRepository _itemDrops = ItemDropRepository.Default;
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

    private const double EasyAmmoDropAmountFactor = 1.5f;
    private const double NormalAmmoDropAmountFactor = 1f;
    private const double MadhouseAmmoDropAmountFactor = 0.75f;


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

    private ItemDropTable ConstructItemDropTable(Randomizer randomizer)
    {
        var result = new ItemDropTable()
        {
            _Comment = "Generated by BioRand."
        };

        var respectDifficulty = randomizer.GetConfigOption<bool>("item-drop-respect-difficulty");
        var min = randomizer.GetConfigOption("item-drop-ammo-min", 0.1);
        var max = randomizer.GetConfigOption("item-drop-ammo-max", 1.0);
        var rng = randomizer.GetRng(RandomizerKey);

        foreach (var id in _itemDrops.GenericDrops)
        {
            var idStr = id.ToString();
            var item = _itemDefinitions.FromId(idStr)!;
            var rate = randomizer.GetConfigOption<double>($"item-drop-ratio-{idStr.ToLowerInvariant()}");
            if (rate <= 0)
            {
                continue;
            }

            var ratePct = (uint)(rate * 100.0);
            var (easyDropAmount, normalDropAmount, madhouseDropAmount) = DetermineDropAmount(id, respectDifficulty, min, max, rng);

            if (item.CategoryType == ItemCategoryType.Shell
                && randomizer.GetConfigOption<bool>("item-drop-ammo-only-available-weapons")
                )
            {
                // TODO: Check chapter availability
            }

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

        var allowedValuableDrops = new List<string>();
        foreach (var type in _itemDrops.HighValueDrops)
        {
            if (randomizer.GetConfigOption<bool>($"item-drop-valuable-{type}"))
            {
                allowedValuableDrops.Add(type);
            }
        }
        // TODO Implement valuable drops

        return result;
    }


    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var dropTable = ConstructItemDropTable(randomizer);
        logger.Push("Modified item drop table (all chapters)");
        dropTable.Log(logger);
        logger.Pop();

        foreach (var (_, path) in _dropTableFiles)
        {
            randomizer.FileRepository.ModifyUserFile<ItemDropTable>(path, _ => dropTable);
        }
    }
}
