namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

using app;
using Hexa.NET.ImGui;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;
using System.Collections.Immutable;
using static app.InventoryMenu;

public class REFPlugin
{
    private const string PluginSeedConfigKey = "biorand-seed";
    private const double DefaultEnemyDropMultiplier = 1.0;
    private const double EasyAmmoDropAmountFactor = 1.5;
    private const double NormalAmmoDropAmountFactor = 1.0;
    private const double MadhouseAmmoDropAmountFactor = 0.75;
    private const double ValuableDropChanceWeight = 3.0;
    private const double ValuableWeaponDropChanceWeight = 1.0;

    private static bool IsInitialized = false;
    private static readonly Configuration config = new();
    private static readonly Logger logger = new(config);
    private static readonly Lock enemyDropStateLock = new();
    private static readonly HashSet<ulong> droppedEnemyObjects = [];
    private static readonly Dictionary<ulong, int> enemyDropGenerations = [];

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
        "Stimulant",
        "Depressant",
        "Herb",
        "ChemicalM",
        "ChemicalL",
        "ChemicalS",
        "Gunpowder",
        "Coin",
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
               1 /* Infinite Ammo */,
               2 /* Health Regen */,
               3 /* Clairvoyance (Perma Psychostimulants) */,
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

    private static readonly Dictionary<string, double> SpecialEnemyDropMultipliers = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Em4200"] = 1.25, // Fat Molded
        ["Em2000"] = 1.35, // Mia
        ["Em3001"] = 1.5, // Stalker Jack
        ["Em8001"] = 1.75, // Chainsaw Jack
        ["Em3600"] = 2, // Mutated Marguerite
    };

    private static readonly HashSet<string> BossEnemyTypeIds = new(StringComparer.OrdinalIgnoreCase)
    {
        "Em2000", // Mia
        "Em3001", // Stalker Jack
        "Em3600", // Mutated Marguerite
        "Em8001", // Chainsaw Jack
    };

    private static readonly HashSet<string> BossEnemyDropItemDataIds = new(StringComparer.Ordinal)
    {
        "LiquidBomb",
        "HandgunBulletL",
        "ShotgunBullet",
        "MachineGunBullet",
        "MagnumBullet",
        "BurnerBullet",
        "FlameBulletS",
        "AcidBulletS",
        "RemedyL",
        "EyeDrops",
        "Stimulant",
        "Depressant",
        "ChemicalM",
        "Coin",
    };

    private readonly record struct EnemyDropCandidate(string ItemDataId, double Weight);
    private readonly record struct EnemyDropSelection(string ItemDataId, int StackNum);

    [PluginEntryPoint]
    public static void Main() => Initialize();

    private static void Initialize()
    {
        ImGuiDrawUI.Post += OnImGuiDrawUi;
        IsInitialized = true;
        logger.Log("Loaded.");
        if (config.LoadError != null)
        {
            logger.Log($"Failed to load configuration '{config.ConfigPath}': {config.LoadError}. Using defaults.");
        }
        else if (!config.HasConfigFile)
        {
            logger.Log($"Configuration file not found at '{config.ConfigPath}'. Using defaults.");
        }
        logger.Log($"Configuration has {config.Entries} entries.");
    }

    [PluginExitPoint]
    public static void OnUnload()
    {
        IsInitialized = false;
        lock (enemyDropStateLock)
        {
            droppedEnemyObjects.Clear();
            enemyDropGenerations.Clear();
        }
        logger.Log("Unloaded.");
    }

    #region Inventory

    private static string? GetPlayerName()
    {
        var objectManager = API.GetManagedSingleton("app.ObjectManager");
        if (objectManager == null)
            return null;

        var playerObj = objectManager.GetField("PlayerObj") as ManagedObject;
        if (playerObj == null)
            return null;

        return playerObj.Call("get_Name") as string;
    }

    private static Inventory.ExtendLvDef? ConfigInventorySizeToEnum(string str)
        => str switch
        {
            "12" => Inventory.ExtendLvDef.Lv1,
            "16" => Inventory.ExtendLvDef.Lv2,
            "20" => Inventory.ExtendLvDef.Lv3,
            _ => null
        };

    private static Inventory.ExtendLvDef? GetDesiredInventorySize()
    {
        var playerName = GetPlayerName();
        if (playerName == null) return null;

        if (playerName.StartsWith("Pl00", StringComparison.Ordinal))
        {
            var ethanSize = ConfigInventorySizeToEnum(config.ReadOrDefault("random-starting-inventory-size-ethan", "12"));
            logger.Log($"Playing as Ethan, configured inventory size: {ethanSize}", isVerbose: true);
            return ethanSize;
        }
        else if (playerName.StartsWith("Pl2", StringComparison.Ordinal))
        {
            var miaSize = ConfigInventorySizeToEnum(config.ReadOrDefault("random-starting-inventory-size-mia", "12"));
            logger.Log($"Playing as Mia, configured inventory size: {miaSize}", isVerbose: true);
            return miaSize;
        }
        else
        {
            return null;
        }
    }

    private static bool IsBirthdaySkillItem(Item? item)
    {
        var itemDataId = item?.ItemDataID;
        return itemDataId != null
            && itemDataId.StartsWith("skl", StringComparison.OrdinalIgnoreCase)
            && !itemDataId.EndsWith("no", StringComparison.OrdinalIgnoreCase);
    }

    private static IPlayerOrder? GetPlayerOrder()
    {
        var objectManager = API.GetManagedSingleton("app.ObjectManager");
        if (objectManager == null)
            return null;

        var playerObj = (objectManager.GetField("PlayerObj") as ManagedObject)?.As<via.GameObject>();
        var playerOrderType = PlayerOrder.REFType.GetRuntimeType().As<_System.Type>();
        return playerOrderType == null
            ? null
            : playerObj?.getComponent(playerOrderType)?.Cast<IPlayerOrder>();
    }

    private static bool TryRegisterBirthdayPassiveSkill(PassiveSkillItem? passiveSkillItem)
    {
        if (passiveSkillItem == null || !IsBirthdaySkillItem(passiveSkillItem.Item))
            return false;

        var passiveSkill = passiveSkillItem.PassiveSkill;
        if (passiveSkill == null)
        {
            logger.Log("Birthday skill item had no PassiveSkill userdata.");
            return true;
        }

        var playerOrder = GetPlayerOrder();
        if (playerOrder == null)
        {
            logger.Log($"Unable to register Birthday skill '{passiveSkillItem.Item.ItemDataID}' because app.PlayerOrder was unavailable.");
            return true;
        }

        passiveSkillItem.PlayerOrder = playerOrder;
        playerOrder.registerPassiveSkill(passiveSkill);
        logger.Log($"Registered Birthday passive skill '{passiveSkillItem.Item.ItemDataID}'.", isVerbose: true);
        return true;
    }

    [MethodHook(typeof(PassiveSkillItem), nameof(PassiveSkillItem.onInsertInventory), MethodHookType.Pre)]
    private static PreHookResult PassiveSkillItem_onInsertInventory_Pre(Span<ulong> args)
    {
        var passiveSkillItem = ManagedObject.ToManagedObject(args[1]).As<PassiveSkillItem>();
        return TryRegisterBirthdayPassiveSkill(passiveSkillItem)
            ? PreHookResult.Skip
            : PreHookResult.Continue;
    }

    [MethodHook(typeof(Inventory), nameof(Inventory.setupItemSlotManager), MethodHookType.Pre)]
    private static PreHookResult Inventory_ctor_Pre(Span<ulong> args)
    {
        var inventory = ManagedObject.ToManagedObject(args[1]).As<Inventory>()!;

        var desiredLevel = GetDesiredInventorySize();
        if (desiredLevel == null)
            return PreHookResult.Continue;

        if (inventory.ExtendLv < desiredLevel)
        {
            logger.Log("Increase Inventory._ExtendLv", isVerbose: true);
            inventory._ExtendLv = desiredLevel.Value;
        }
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(Inventory), nameof(Inventory.setExtendLv), MethodHookType.Pre)]
    private static PreHookResult Inventory_setExtendLv_Pre(Span<ulong> args)
    {
        var newLevel = (int)args[2];
        var desiredLevel = GetDesiredInventorySize();
        if (desiredLevel == null)
            return PreHookResult.Continue;

        if (newLevel < (int)desiredLevel)
        {
            logger.Log("Prevent Inventory._ExtendLv shrinking");
            args[2] = (ulong)desiredLevel;
        }

        return PreHookResult.Continue;
    }

    private const int MaxCombineUIRowNum = 5;

    [MethodHook(typeof(DictionaryCombineUIController), nameof(DictionaryCombineUIController.deactivate), MethodHookType.Pre)]
    private static PreHookResult DictionaryCombineUIController_deactivate_Pre(Span<ulong> args)
    {
        var controller = ManagedObject.ToManagedObject(args[1]).As<DictionaryCombineUIController>();
        var type = TDB.Get().FindType("app.InventoryMenu.DictionaryCombineUIController");
        var field = type.GetField("RowNum");
        var current = (int)field.GetDataBoxed(controller.Address(), false);

        if (current != MaxCombineUIRowNum)
        {
            logger.Log($"Patch DictionaryCombineUIController.RowNum from {current} to {MaxCombineUIRowNum}", isVerbose: true);
            field.SetDataBoxed(controller.Address(), MaxCombineUIRowNum, false);
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(InventoryMenu), nameof(InventoryMenu.DictionaryCombine_UnlockedCombine), MethodHookType.Post)]
    private static void InventoryMenu_DictionaryCombine_UnlockedCombine_Post(ref ulong retval)
    {
        if (retval != 1)
        {
            logger.Log("Patch InventoryMenu.DictionaryCombine_UnlockedCombine from false to true", isVerbose: true);
            retval = 1;
        }
    }

    #endregion Inventory

    #region Enemy Drops

    private static ItemManager? GetItemManager()
    {
        return API.GetManagedSingleton("app.ItemManager")?.As<ItemManager>();
    }

    private static T ReadEnemyDropConfigOrDefault<T>(string enemyKey, string fallbackKey, T defaultValue)
    {
        if (config.TryRead(enemyKey, out T value))
            return value;

        if (config.TryRead(fallbackKey, out value))
            return value;

        return defaultValue;
    }

    private static string GetEnemyDropRatioKey(string itemDataId) => $"enemy-drop-ratio-{itemDataId.ToLowerInvariant()}";

    private static string GetItemDropRatioKey(string itemDataId) => $"item-drop-ratio-{itemDataId.ToLowerInvariant()}";

    private static bool IsEnemyDropEnabled()
        => config.ReadOrDefault("random-enemy-drops", true);

    private static string GetCurrentChapterName()
        => API.GetManagedSingleton("app.GameFlowFsmManager").As<GameFlowFsmManager>().CurrentMainGameFlow.ToString();

    private static GameManager.Difficulty GetCurrentDifficulty()
        => API.GetManagedSingleton("app.GameManager").As<GameManager>().GameDifficulty;

    private static bool IsAmmoEnemyDrop(string itemDataId)
        => AmmoEnemyDropItemDataIds.Contains(itemDataId);

    private static int GetItemStackLimit(string itemDataId)
    {
        var defaultStackSize = DefaultEnemyDropStackLimits.GetValueOrDefault(itemDataId, 1);
        return config.ReadOrDefault($"inventory-stack-limit-{itemDataId.ToLowerInvariant()}", defaultStackSize);
    }

    private static string? GetManagedObjectRuntimeTypeName(ManagedObject? managedObject)
    {
        var runtimeType = managedObject?.GetTypeDefinition()?.GetRuntimeType();
        return runtimeType?.Call("get_FullName") as string
            ?? runtimeType?.Call("get_Name") as string;
    }

    private static string? ExtractEnemyTypeId(string? runtimeTypeName)
    {
        if (string.IsNullOrEmpty(runtimeTypeName))
            return null;

        for (var index = 0; index <= runtimeTypeName.Length - 6; index++)
        {
            if ((runtimeTypeName[index] is 'E' or 'e')
                && (runtimeTypeName[index + 1] is 'M' or 'm')
                && char.IsDigit(runtimeTypeName[index + 2])
                && char.IsDigit(runtimeTypeName[index + 3])
                && char.IsDigit(runtimeTypeName[index + 4])
                && char.IsDigit(runtimeTypeName[index + 5]))
            {
                return runtimeTypeName.Substring(index, 6);
            }
        }

        return null;
    }

    private static bool IsBossEnemyTypeId(string? enemyTypeId)
        => enemyTypeId != null && BossEnemyTypeIds.Contains(enemyTypeId);

    private static double GetEnemyDropMultiplier(ManagedObject controllerObject, out string? enemyTypeId)
    {
        var runtimeTypeName = GetManagedObjectRuntimeTypeName(controllerObject);
        enemyTypeId = ExtractEnemyTypeId(runtimeTypeName);
        if (enemyTypeId != null && SpecialEnemyDropMultipliers.TryGetValue(enemyTypeId, out var dropMultiplier))
        {
            logger.Log(
                $"Enemy damage controller '{runtimeTypeName}' matched '{enemyTypeId}' and will use drop multiplier x{dropMultiplier}.",
                isVerbose: true);
            return dropMultiplier;
        }

        logger.Log(
            $"Enemy damage controller '{runtimeTypeName ?? "unknown"}' will use the default drop multiplier x{DefaultEnemyDropMultiplier}.",
            isVerbose: true);
        return DefaultEnemyDropMultiplier;
    }

    private static Random CreateEnemyDropRandom(ulong enemyObjectAddress, int generation)
    {
        ulong hash = (uint)config.ReadOrDefault(PluginSeedConfigKey, 0);
        hash = (hash * 16777619UL) ^ enemyObjectAddress;
        hash = (hash * 16777619UL) ^ (uint)generation;
        var seed = unchecked((int)(hash ^ (hash >> 32)));
        return new Random(seed);
    }

    private static int ApplyDifficultyToDropAmount(int amount)
    {
        var factor = GetCurrentDifficulty() switch
        {
            GameManager.Difficulty.Easy => EasyAmmoDropAmountFactor,
            GameManager.Difficulty.Normal => NormalAmmoDropAmountFactor,
            GameManager.Difficulty.Hard => MadhouseAmmoDropAmountFactor,
            _ => 1
        };

        return Math.Max(1, (int)Math.Round(amount * factor));
    }

    private static int DetermineEnemyDropStackNum(string itemDataId, Random rng)
    {
        if (!IsAmmoEnemyDrop(itemDataId))
            return 1;

        var stackSize = GetItemStackLimit(itemDataId);
        var min = ReadEnemyDropConfigOrDefault("enemy-drop-ammo-min", "item-drop-ammo-min", 0.1);
        var max = ReadEnemyDropConfigOrDefault("enemy-drop-ammo-max", "item-drop-ammo-max", 0.4);
        if (max < min)
        {
            (min, max) = (max, min);
        }

        var minAmount = Math.Max(1, (int)Math.Round(min * stackSize));
        var maxAmount = Math.Max(minAmount, Math.Min(stackSize, (int)Math.Round(max * stackSize)));
        var amount = rng.Next(minAmount, maxAmount + 1);

        if (!ReadEnemyDropConfigOrDefault("enemy-drop-respect-difficulty", "item-drop-respect-difficulty", true))
            return amount;

        return ApplyDifficultyToDropAmount(amount);
    }

    private static int ApplyEnemyDropMultiplier(string itemDataId, int stackNum, double dropMultiplier)
    {
        var sanitizedMultiplier = Math.Max(1.0, dropMultiplier);
        if (sanitizedMultiplier == 1.0)
            return stackNum;

        var stackLimit = Math.Max(1.0, GetItemStackLimit(itemDataId));
        var multipliedStackNum = stackNum * sanitizedMultiplier;
        var finalStackNum = (int)Math.Round(Math.Clamp(multipliedStackNum, 1.0, stackLimit));

        logger.Log(
            $"Adjusted enemy drop '{itemDataId}' stack from {stackNum} to {finalStackNum} using multiplier x{sanitizedMultiplier}.",
            isVerbose: true);
        return finalStackNum;
    }

    private static List<EnemyDropCandidate> BuildEnemyDropCandidates(Random rng, bool restrictToBossDropPool)
    {
        var result = new List<EnemyDropCandidate>();
        var filterAmmoByChapter = ReadEnemyDropConfigOrDefault(
            "enemy-drop-ammo-only-available-weapons",
            "item-drop-ammo-only-available-weapons",
            true);

        if (restrictToBossDropPool)
        {
            logger.Log("Restricting enemy drop pool to boss-quality items.", isVerbose: true);
        }

        HashSet<string>? allowedAmmo = null;
        if (filterAmmoByChapter)
        {
            var chapterName = GetCurrentChapterName();
            logger.Log($"Current chapter: {(chapterName ?? "null")}", isVerbose: true);
            if (chapterName != null && ChapterAmmoAvailability.TryGetValue(chapterName, out var ammoIds))
            {
                allowedAmmo = [.. ammoIds];
            }
        }

        foreach (var itemDataId in GenericEnemyDropItemDataIds)
        {
            if (restrictToBossDropPool && !BossEnemyDropItemDataIds.Contains(itemDataId))
                continue;

            if (allowedAmmo != null && IsAmmoEnemyDrop(itemDataId) && !allowedAmmo.Contains(itemDataId))
                continue;

            var ratio = ReadEnemyDropConfigOrDefault(
                GetEnemyDropRatioKey(itemDataId),
                GetItemDropRatioKey(itemDataId),
                0.0);
            if (ratio <= 0)
                continue;

            result.Add(new EnemyDropCandidate(itemDataId, ratio * 100.0));
        }

        if (ReadEnemyDropConfigOrDefault("enemy-drop-valuable-weapon", "item-drop-valuable-weapon", false))
        {
            result.Add(new EnemyDropCandidate("LiquidBomb", ValuableWeaponDropChanceWeight));
        }

        if (ReadEnemyDropConfigOrDefault("enemy-drop-valuable-lock-pick", "item-drop-valuable-lock-pick", false))
        {
            result.Add(new EnemyDropCandidate("CylinderKey", ValuableDropChanceWeight));
        }

        if (ReadEnemyDropConfigOrDefault("enemy-drop-valuable-repair-kit", "item-drop-valuable-repair-kit", false))
        {
            result.Add(new EnemyDropCandidate("RepairKit", ValuableDropChanceWeight));
        }

        if (ReadEnemyDropConfigOrDefault("enemy-drop-valuable-dlc-coin", "item-drop-valuable-dlc-coin", false))
        {
            foreach (var (itemDataId, (minWeight, maxWeight)) in DlcCoinWeights)
            {
                result.Add(new EnemyDropCandidate(itemDataId, rng.Next(minWeight, maxWeight + 1)));
            }
        }

        if (config.ReadOrDefault("allow-dlc-items", false)
            && ReadEnemyDropConfigOrDefault("enemy-drop-valuable-birthday-skill", "item-drop-valuable-birthday-skill", false))
        {
            result.Add(new EnemyDropCandidate(
                BirthdaySkillItemDataIds[rng.Next(BirthdaySkillItemDataIds.Length)],
                ValuableDropChanceWeight));
        }

        return result;
    }

    private static EnemyDropSelection? SelectEnemyDrop(via.GameObject enemyObject, int generation, bool restrictToBossDropPool)
    {
        var rng = CreateEnemyDropRandom(enemyObject.Address(), generation);
        var candidates = BuildEnemyDropCandidates(rng, restrictToBossDropPool);
        if (candidates.Count == 0)
            return null;

        var totalWeight = candidates.Sum(candidate => candidate.Weight);
        if (totalWeight <= 0)
            return null;

        var roll = rng.NextDouble() * totalWeight;
        var cumulativeWeight = 0.0;
        foreach (var candidate in candidates)
        {
            cumulativeWeight += candidate.Weight;
            if (roll < cumulativeWeight)
            {
                return new EnemyDropSelection(
                    candidate.ItemDataId,
                    DetermineEnemyDropStackNum(candidate.ItemDataId, rng));
            }
        }

        var lastCandidate = candidates[^1];
        return new EnemyDropSelection(
            lastCandidate.ItemDataId,
            DetermineEnemyDropStackNum(lastCandidate.ItemDataId, rng));
    }

    private static void ResetEnemyDropState(via.GameObject? enemyObject)
    {
        if (enemyObject == null)
            return;

        lock (enemyDropStateLock)
        {
            var enemyObjectAddress = enemyObject.Address();
            droppedEnemyObjects.Remove(enemyObjectAddress);
            enemyDropGenerations[enemyObjectAddress] = enemyDropGenerations.GetValueOrDefault(enemyObjectAddress) + 1;
        }
    }

    private static bool TryBeginEnemyDrop(via.GameObject enemyObject, out int generation)
    {
        lock (enemyDropStateLock)
        {
            var enemyObjectAddress = enemyObject.Address();
            generation = enemyDropGenerations.GetValueOrDefault(enemyObjectAddress);
            return droppedEnemyObjects.Add(enemyObjectAddress);
        }
    }

    private static void SpawnEnemyDrop(via.GameObject enemyObject, string itemDataId, int stackNum)
    {
        var itemManager = GetItemManager();
        if (itemManager == null)
        {
            logger.Log("Unable to spawn enemy drop because app.ItemManager was unavailable.");
            return;
        }

        var drop = itemManager.createDropItemInstance(enemyObject, itemDataId, stackNum);
        if (drop == null)
        {
            logger.Log($"Failed to create enemy drop '{itemDataId}'.");
            return;
        }

        var dropTransform = drop.Transform;
        if (dropTransform != null)
        {
            var worldPosition = dropTransform.Position;
            var worldRotation = dropTransform.Rotation;
            dropTransform.setParent(null!, true);
            dropTransform.Position = worldPosition;
            dropTransform.Rotation = worldRotation;
        }

        logger.Log($"Spawned enemy drop '{itemDataId}' x{stackNum} for enemy object 0x{enemyObject.Address():X}.", isVerbose: true);
    }

    private static void SpawnConfiguredEnemyDrop(ManagedObject controllerObject, via.GameObject enemyObject, int generation)
    {
        var dropMultiplier = GetEnemyDropMultiplier(controllerObject, out var enemyTypeId);
        var selection = SelectEnemyDrop(
            enemyObject,
            generation,
            restrictToBossDropPool: IsBossEnemyTypeId(enemyTypeId));
        if (selection == null)
        {
            logger.Log($"No eligible enemy drop candidates for enemy object 0x{enemyObject.Address():X}.", isVerbose: true);
            return;
        }

        var finalStackNum = ApplyEnemyDropMultiplier(
            selection.Value.ItemDataId,
            selection.Value.StackNum,
            dropMultiplier);
        SpawnEnemyDrop(enemyObject, selection.Value.ItemDataId, finalStackNum);
    }

    [MethodHook(typeof(EnemyActionController), nameof(EnemyActionController.spawn), MethodHookType.Pre)]
    private static PreHookResult EnemyActionController_spawn_Pre(Span<ulong> args)
    {
        ResetEnemyDropState(ManagedObject.ToManagedObject(args[1]).As<EnemyActionController>()?.GameObject);
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemyActionController), nameof(EnemyActionController.forgetDie), MethodHookType.Pre)]
    private static PreHookResult EnemyActionController_forgetDie_Pre(Span<ulong> args)
    {
        ResetEnemyDropState(ManagedObject.ToManagedObject(args[1]).As<EnemyActionController>()?.GameObject);
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemyDamageController), nameof(EnemyDamageController.doDie), MethodHookType.Pre)]
    private static PreHookResult EnemyDamageController_doDie_Pre(Span<ulong> args)
    {
        if (!IsEnemyDropEnabled())
            return PreHookResult.Continue;

        var controllerObject = ManagedObject.ToManagedObject(args[1]);
        var controller = controllerObject.As<EnemyDamageController>();
        var enemyObject = controller?.GameObject;
        if (enemyObject == null)
            return PreHookResult.Continue;

        if (!TryBeginEnemyDrop(enemyObject, out var generation))
            return PreHookResult.Continue;

        SpawnConfiguredEnemyDrop(controllerObject, enemyObject, generation);
        return PreHookResult.Continue;
    }

    #endregion Enemy Drops

    #region UI

    private static void OnImGuiDrawUi()
    {
        if (!IsInitialized) return;

        if (ImGui.TreeNode("BioRand 7"))
        {
            ImGui.TreePop();
        }
    }

    #endregion UI
}
