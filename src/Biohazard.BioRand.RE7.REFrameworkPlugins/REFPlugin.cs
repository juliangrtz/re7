namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

using app;
using app.AI;
using app.Command;
using app.Collision;
using Hexa.NET.ImGui;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;
using System.Collections.Immutable;
using static app.InventoryMenu;
using via.physics;

public class REFPlugin
{
    private const string PluginSeedConfigKey = "biorand-seed";
    private const double DefaultEnemyDropMultiplier = 1.0;
    private const double EasyAmmoDropAmountFactor = 1.5;
    private const double NormalAmmoDropAmountFactor = 1.0;
    private const double MadhouseAmmoDropAmountFactor = 0.75;
    private const double ValuableDropChanceWeight = 3.0;
    private const double ValuableWeaponDropChanceWeight = 1.0;
    private const int ImportedDlcEnemyRuntimeScanIntervalFrames = 30;

    private static bool IsInitialized = false;
    private static int importedDlcEnemyRuntimeScanFrame = 0;
    private static readonly Configuration config = new();
    private static readonly Logger logger = new(config);
    private static readonly Lock enemyDropStateLock = new();
    private static readonly HashSet<ulong> droppedEnemyObjects = [];
    private static readonly Dictionary<ulong, int> enemyDropGenerations = [];
    private static readonly HashSet<ulong> preparedDlcEnemyRuntimeObjects = [];
    private static readonly HashSet<ulong> completedImportedDlcEnemySetups = [];
    private static readonly HashSet<ulong> deferredImportedDlcEnemySetups = [];
    private static readonly HashSet<ulong> bridgedCh8Em4400Instances = [];
    private static readonly HashSet<ulong> attemptedCh8Em4400NativeCommandRegistration = [];
    private static readonly HashSet<ulong> initializedCh8Em4400CommandActions = [];
    private static readonly HashSet<(ulong UpdateController, ulong Target)> registeredCh8EnemyUpdateTargets = [];
    private static readonly List<ManagedObject> globalizedDlcCommandActions = [];
    [ThreadStatic] private static EnemySpawnInfo? pendingDlcSpawnInfo;
    [ThreadStatic] private static EnemySpawnInfo? pendingDlcSetupInfo;
    [ThreadStatic] private static bool isCompletingImportedDlcEnemySetup;

    private static readonly string[] Ch8Em4400CommandActionTypeNames =
    [
        "app.CH8Em4400.Action.CH8MountTry",
        "app.CH8Em4400.Action.CH8Grapple",
        "app.CH8Em4400.Action.CH8Appear",
        "app.CH8Em4400.Action.CH8LostParts",
        "app.CH8Em4400.Action.CH8BlownAway",
        "app.CH8Em4400.Action.CH8SlipFire",
        "app.CH8Em4400.Action.CH8SlipAcid",
        "app.CH8Em4400.Action.CH8Falling",
        "app.CH8Em4400.Action.CH8Anger",
        "app.CH8Em4400.Action.CH8Rush",
        "app.CH8Em4400.Action.CH8Splash",
        "app.CH8Em4400.Action.CH8Breath",
        "app.CH8Em4400.Action.CH8BreathFirst",
        "app.CH8Em4400.Action.CH8BreathForce",
        "app.CH8Em4400.Action.CH8ChanceCounter",
        "app.CH8Em4400.Action.CH8DamageToMove",
        "app.CH8Em4400.Action.CH8DamageToBreath",
        "app.CH8Em4400.Action.CH8Wait",
        "app.CH8Em4400.Action.CH8Suspend",
        "app.CH8Em4400.Action.CH8Resume",
        "app.CH8Em4400.Action.CH8Warp",
        "app.CH8Em4400.Action.CH8Generate",
        "app.CH8Em4400.Action.CH8EasyWait",
        "app.CH8Em4400.Action.CH8AllFoursSmash",
        "app.CH8Em4400.Action.CH8Kneel",
        "app.CH8Em4400.Action.CH8SuspendWalk",
        "app.CH8Em4400.Action.CH8AppearDamage",
        "app.CH8Em4400.Action.CH8Damage",
        "app.CH8Em4400.Action.CH8Dead",
        "app.CH8Em4400.Action.CH8Idle",
        "app.CH8Em4400.Action.CH8Move",
    ];

    #region Data
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
    #endregion

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
        TryPrepareImportedDlcEnemyGenerators();
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
        preparedDlcEnemyRuntimeObjects.Clear();
        completedImportedDlcEnemySetups.Clear();
        deferredImportedDlcEnemySetups.Clear();
        bridgedCh8Em4400Instances.Clear();
        attemptedCh8Em4400NativeCommandRegistration.Clear();
        initializedCh8Em4400CommandActions.Clear();
        registeredCh8EnemyUpdateTargets.Clear();
        globalizedDlcCommandActions.Clear();
        importedDlcEnemyRuntimeScanFrame = 0;
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

    #region DLC Enemy Spawns

    private static bool IsImportedDlcEnemySpawnInfo(object? spawnInfoObject)
    {
        var typeName = GetRuntimeTypeName(spawnInfoObject);
        return typeName is not null &&
            (typeName.Contains("CH8EnemySpawnInfo", StringComparison.Ordinal) ||
             typeName.Contains("CH9EnemySpawnInfo", StringComparison.Ordinal));
    }

    private static bool IsImportedDlcEnemyGenerator(object? generatorObject)
    {
        var typeName = GetRuntimeTypeName(generatorObject);
        return typeName is not null &&
            (typeName.Contains("CH8EnemyGenerator", StringComparison.Ordinal) ||
             typeName.Contains("CH9EnemyGenerator", StringComparison.Ordinal));
    }

    private static bool IsNonDlcChapterActive()
    {
        var gameManager = API.GetManagedSingleton("app.GameManager")?.As<GameManager>();
        if (gameManager == null)
            return false;

        return gameManager.CurrentChapter is not GameManager.ChapterNo.Chapter8 and not GameManager.ChapterNo.Chapter9;
    }

    private static void ForceGameObjectRuntimeActive(via.GameObject? gameObject)
    {
        if (gameObject == null)
            return;

        try
        {
            gameObject.UpdateSelf = true;
            gameObject.DrawSelf = true;
        }
        catch
        {
            // Some destroyed runtime objects can still be reachable during scene teardown.
        }
    }

    private static void ForceDoomsRuntimeActive(DoomsBehavior? behavior)
    {
        if (behavior == null)
            return;

        try
        {
            behavior.IsEnablePause = false;
            behavior.isEnablePause = false;
            behavior.IsPause = false;
            behavior.isPause = false;
            ForceGameObjectRuntimeActive(behavior.GameObject);
        }
        catch
        {
            // Keep DLC rescue hooks non-fatal; a bad enemy should not break unrelated runtime code.
        }
    }

    private static bool IsGameObjectRuntimeActive(via.GameObject? gameObject)
    {
        if (gameObject == null)
            return false;

        try
        {
            return gameObject.Valid && (gameObject.Update || gameObject.Draw);
        }
        catch
        {
            return false;
        }
    }

    private static void ForceAiSensorRuntimeActive(AISensor? sensor)
    {
        if (sensor == null)
            return;

        ForceDoomsRuntimeActive(sensor);
        try
        {
            sensor.Enable = true;
            sensor._IsEnable = true;
            sensor.IsStop = false;
            sensor._IsStop = false;
        }
        catch
        {
            // Sensor activation is best-effort; command ticking is the critical imported-CH8 bridge.
        }
    }

    private static T? TryRead<T>(Func<T?> read)
        where T : class
    {
        try
        {
            return read();
        }
        catch
        {
            return null;
        }
    }

    private static void TryWrite(Action write)
    {
        try
        {
            write();
        }
        catch
        {
            // Some inherited CH8 members are present in the generated TDB but absent on campaign-runtime objects.
        }
    }

    private static bool TrySetObjectField(object? target, string fieldName, object? value)
    {
        if (target == null)
            return false;

        try
        {
            var method = target.GetType().GetMethod("SetField", [typeof(string), typeof(object)]);
            if (method != null)
            {
                method.Invoke(target, [fieldName, value]);
                return true;
            }
        }
        catch
        {
        }

        try
        {
            ((dynamic)target).SetField(fieldName, value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool TrySetFieldDataIfNull(
        object? target,
        TypeDefinition typeDefinition,
        string fieldName,
        object? value)
    {
        // Live testing showed broad object-reference writes through TDB Field.SetDataBoxed
        // can corrupt the REFramework VM and crash RE7. Keep call sites inert until a
        // single-field write is proven safe under a controlled runtime probe.
        return false;
    }

    private static T? TryGetComponent<T>(via.GameObject? gameObject, TypeDefinition typeDefinition)
        where T : class
    {
        try
        {
            return GetComponent<T>(gameObject, typeDefinition);
        }
        catch
        {
            return null;
        }
    }

    private static void ForEachComponent<T>(via.GameObject? gameObject, TypeDefinition typeDefinition, Action<T> action)
        where T : class
    {
        if (gameObject == null)
            return;

        try
        {
            var runtimeType = typeDefinition.GetRuntimeType().As<_System.Type>();
            if (runtimeType == null)
                return;

            ForEachGameObjectInHierarchy(gameObject, currentGameObject =>
            {
                var components = currentGameObject.findComponents(runtimeType);
                var count = GetObjectListCount(components);
                for (var index = 0; index < count; index++)
                {
                    var component = CastObject<T>(GetObjectListItem(components, index));
                    if (component != null)
                    {
                        action(component);
                    }
                }
            });
        }
        catch
        {
            // Component enumeration can fail while RE Engine is tearing down or rebuilding scene folders.
        }
    }

    private static void ForEachGameObjectInHierarchy(via.GameObject? root, Action<via.GameObject> action)
    {
        if (root == null)
            return;

        var visited = new HashSet<ulong>();
        var stack = new Stack<via.Transform>();
        try
        {
            if (root.Transform != null)
            {
                stack.Push(root.Transform);
            }
        }
        catch
        {
            action(root);
            return;
        }

        while (stack.Count > 0)
        {
            var transform = stack.Pop();
            var transformAddress = GetObjectAddress(transform);
            if (transformAddress != 0 && !visited.Add(transformAddress))
                continue;

            via.GameObject? gameObject = null;
            try { gameObject = transform.GameObject; } catch { }
            if (gameObject != null)
            {
                action(gameObject);
            }

            try
            {
                for (var child = transform.Child; child != null; child = child.Next)
                {
                    stack.Push(child);
                }
            }
            catch
            {
                // Child traversal is best-effort; root-level components are still handled.
            }
        }
    }

    private static void ForceCollidableRuntimeActive(CollidableBase? collidable)
    {
        if (collidable == null)
            return;

        try
        {
            collidable.Enabled = true;
            collidable.onDirty();
        }
        catch
        {
            // Physics colliders are best-effort; direct damage-controller state is handled separately.
        }
    }

    private static void TryNormalizeImportedDlcEnemySpawnState(EnemySpawnInfo spawnInfo)
    {
        try
        {
            spawnInfo.IsSpawned = true;
            // Live CH8 Em4400 instances stay active with IsAppeared=false and completedOperation=true.
            // Forcing the opposite left imported main-game instances in a stale generator state.
            spawnInfo.IsAppeared = false;
            spawnInfo.IsAlive = true;
            spawnInfo.IsCompleted = false;
            spawnInfo.isCompletedOperation = true;

            var action = CastObject<EnemyActionController>(spawnInfo.EnemyActionController);
            if (action != null)
            {
                TryNormalizeImportedDlcEnemyActionState(action);
            }

            var status = CastObject<EnemyStatus>(spawnInfo.EnemyStatus);
            if (status != null)
            {
                status.isAppeared = true;
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to normalize imported DLC enemy spawn state: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryWarpImportedDlcEnemyToSpawnInfo(EnemySpawnInfo spawnInfo)
    {
        try
        {
            var sourceTransform = spawnInfo.GameObject?.Transform;
            var enemyTransform = spawnInfo.EnemyInstance?.Transform;
            if (sourceTransform == null || enemyTransform == null)
                return;

            var position = sourceTransform.Position;
            var rotation = sourceTransform.Rotation;
            var action = CastObject<EnemyActionController>(spawnInfo.EnemyActionController);

            try { action?.movementController?.warp(position, rotation); } catch { }

            enemyTransform.Position = position;
            enemyTransform.Rotation = rotation;

            if (action != null)
            {
                action.spawnedPosition = position;
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to warp imported DLC enemy to spawn info: {ex.Message}", isVerbose: true);
        }
    }

    private static void ClearImportedCh8NeedAreaRequests(object? spawnInfoObject)
    {
        var ch8SpawnInfo = CastObject<CH8EnemySpawnInfo>(spawnInfoObject);
        if (ch8SpawnInfo == null)
            return;

        try
        {
            ch8SpawnInfo.requestOptionWithNeedAreaList?.Clear();
        }
        catch
        {
            // Need-area queues are best-effort for imported CH8 enemies in the main campaign.
        }
    }

    private static void TryBridgeImportedCh8Em4400Spawn(EnemySpawnInfo? spawnInfo)
    {
        if (spawnInfo?.EnemyInstance == null || !IsNonDlcChapterActive())
            return;

        var action = CastObject<CH8Em4400ActionController>(spawnInfo.EnemyActionController)
            ?? GetComponent<CH8Em4400ActionController>(spawnInfo.EnemyInstance, CH8Em4400ActionController.REFType);
        if (action == null)
            return;

        // Keep this bridge deliberately narrow. The real CH8 Em4400 has no
        // CH8EnemyUpdateController and may have IdleAction=null, so lifecycle ticks
        // and synthetic command/update-controller creation are counterproductive.
        TryBridgeImportedCh8Em4400Instance(spawnInfo.EnemyInstance, action);
    }

    private static void TryKickImportedCh8Em4400Idle(
        via.GameObject owner,
        CH8Em4400ActionController action)
    {
        try
        {
            var commandController = GetComponent<CH8CommandActionController>(owner, CH8CommandActionController.REFType);
            if (commandController == null)
                return;

            ForceGameObjectRuntimeActive(owner);
            ForceDoomsRuntimeActive(action);
            ForceDoomsRuntimeActive(commandController);
            ForceDoomsRuntimeActive(commandController.Commander);
            ForceDoomsRuntimeActive(commandController.Requester);

            var idleAction = commandController.IdleAction;
            if (idleAction == null)
            {
                try { idleAction = commandController.findIdleAction(); } catch { }
                idleAction ??= FindCommandActionById(commandController.ActionList, 0);
                if (idleAction != null)
                {
                    commandController.IdleAction = idleAction;
                }
            }

            if (commandController.CurrentAction == null && idleAction == null)
                return;

            commandController.doUpdate();
            logger.Log("Kicked imported CH8 Em4400 command controller once for idle animation.", isVerbose: true);
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to kick imported CH8 Em4400 command controller: {ex.Message}", isVerbose: true);
        }
    }

    private static bool TryBridgeImportedCh8Em4400Instance(
        via.GameObject? enemyInstance,
        CH8Em4400ActionController? action = null)
    {
        if (enemyInstance == null || !IsNonDlcChapterActive())
            return false;

        action ??= GetComponent<CH8Em4400ActionController>(enemyInstance, CH8Em4400ActionController.REFType);
        if (action == null)
            return false;

        try
        {
            var instanceAddress = GetObjectAddress(enemyInstance);
            if (instanceAddress != 0 &&
                bridgedCh8Em4400Instances.Contains(instanceAddress) &&
                IsImportedCh8Em4400BridgeComplete(action))
            {
                return true;
            }

            ForceGameObjectRuntimeActive(enemyInstance);
            ForceDoomsRuntimeActive(action);

            var status = TryRead(() => action.myStatus)
                ?? CastObject<CH8Em4400Status>(TryRead(() => action.enemyStatus))
                ?? TryGetComponent<CH8Em4400Status>(enemyInstance, CH8Em4400Status.REFType);
            var think = TryGetComponent<CH8Em4400Think>(enemyInstance, CH8Em4400Think.REFType);
            var commandController = TryGetComponent<CH8CommandActionController>(enemyInstance, CH8CommandActionController.REFType);
            var visionSensor = TryGetComponent<AIVisionSensor>(enemyInstance, AIVisionSensor.REFType);
            var hearingSensor = TryGetComponent<AIHearingSensor>(enemyInstance, AIHearingSensor.REFType);
            var order = TryRead(() => action.enemyOrder)
                ?? TryGetComponent<EnemyOrder>(enemyInstance, EnemyOrder.REFType);
            var damageController = TryRead(() => action.enemyDamageController)
                ?? CastObject<EnemyDamageController>(TryGetComponent<CH8Em4400DamageController>(enemyInstance, CH8Em4400DamageController.REFType))
                ?? TryGetComponent<EnemyDamageController>(enemyInstance, EnemyDamageController.REFType);
            var strikeController = TryRead(() => action.enemyStrikeController)
                ?? CastObject<EnemyStrikeController>(TryGetComponent<CH8Em4400StrikeController>(enemyInstance, CH8Em4400StrikeController.REFType))
                ?? TryGetComponent<EnemyStrikeController>(enemyInstance, EnemyStrikeController.REFType);
            var hitController = TryRead(() => action.hitController)
                ?? TryGetComponent<HitController>(enemyInstance, HitController.REFType);
            var movementController = TryRead(() => action.movementController)
                ?? TryGetComponent<MovementController>(enemyInstance, MovementController.REFType);
            var commandRequester = TryRead(() => action.myCommandRequester)
                ?? commandController?.Requester
                ?? TryGetComponent<CommandRequester>(enemyInstance, CommandRequester.REFType);
            var basicAnimController = TryRead(() => action.myBasicAnimController)
                ?? TryGetComponent<BasicAnimationController>(enemyInstance, BasicAnimationController.REFType);
            var smoothAnimator = TryRead(() => action.mySmoothAnim)
                ?? TryGetComponent<SmoothAnimator>(enemyInstance, SmoothAnimator.REFType);
            var motionManager = TryRead(() => action.myMotionManager)
                ?? commandController?.MotionManager
                ?? TryGetComponent<MotionManager>(enemyInstance, MotionManager.REFType);
            var motion = TryRead(() => action.myMotion)
                ?? TryGetComponent<via.motion.Motion>(enemyInstance, via.motion.Motion.REFType);
            var sequenceController = TryRead(() => action.mySequenceController)
                ?? TryGetComponent<SequenceController>(enemyInstance, SequenceController.REFType);
            var mesh = TryRead(() => action.myMesh)
                ?? TryGetComponent<via.render.Mesh>(enemyInstance, via.render.Mesh.REFType);
            var characterController = TryRead(() => action.characterController)
                ?? TryGetComponent<CharacterController>(enemyInstance, CharacterController.REFType);
            var humanoid = TryRead(() => action.humanoid)
                ?? TryGetComponent<Humanoid>(enemyInstance, Humanoid.REFType);
            var rankManager = TryRead(() => action.enemyRankManager)
                ?? TryGetComponent<EnemyRankManager>(enemyInstance, EnemyRankManager.REFType);
            var grapple = TryRead(() => action.enemyGrapple)
                ?? CastObject<EnemyGrappleBase>(TryGetComponent<CH8Em4400Grapple>(enemyInstance, CH8Em4400Grapple.REFType))
                ?? TryGetComponent<EnemyGrappleBase>(enemyInstance, EnemyGrappleBase.REFType);
            var navigationSurface = TryGetComponent<via.navigation.NavigationSurface>(enemyInstance, via.navigation.NavigationSurface.REFType);

            TryNormalizeImportedDlcEnemyActionState(action);

            TryWrite(() => action.myStatus ??= status);
            TryWrite(() => action.enemyStatus ??= CastObject<EnemyStatus>(status));
            TryWrite(() => action.enemyThink ??= think);
            TryWrite(() => action.myThink ??= think);
            TryWrite(() => action.myCommandActionController ??= commandController);
            TryWrite(() => action.myCommandRequester ??= commandRequester);
            TryWrite(() => action.myBasicAnimController ??= basicAnimController);
            TryWrite(() => action.mySmoothAnim ??= smoothAnimator);
            TryWrite(() => action.myMotionManager ??= motionManager);
            TryWrite(() => action.myMotion ??= motion);
            TryWrite(() => action.mySequenceController ??= sequenceController);
            TryWrite(() => action.myMesh ??= mesh);
            TryWrite(() => action.characterController ??= characterController);
            TryWrite(() => action.humanoid ??= humanoid);
            TryWrite(() => action.movementController ??= movementController);
            TryWrite(() => action.hitController ??= hitController);
            TryWrite(() => action.enemyOrder ??= order);
            TryWrite(() => action.enemyDamageController ??= damageController);
            TryWrite(() => action.enemyStrikeController ??= strikeController);
            TryWrite(() => action.enemyRankManager ??= rankManager);
            TryWrite(() => action.enemyGrapple ??= grapple);
            TryWrite(() => action.visionSensor ??= visionSensor);
            TryWrite(() => action.hearingSensor ??= hearingSensor);
            TryWrite(() => action.playerStatus ??= GetPlayerStatus());

            TrySetFieldDataIfNull(action, CH8Em4400ActionController.REFType, "<myStatus>k__BackingField", status);
            TrySetFieldDataIfNull(action, CH8Em4400ActionController.REFType, "<myThink>k__BackingField", think);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<enemyStatus>k__BackingField", CastObject<EnemyStatus>(status));
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<enemyThink>k__BackingField", CastObject<EnemyThinkBase>(think));
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<myCommandActionController>k__BackingField", commandController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<myCommandRequester>k__BackingField", commandRequester);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<myBasicAnimController>k__BackingField", basicAnimController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<mySmoothAnim>k__BackingField", smoothAnimator);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<myMotionManager>k__BackingField", motionManager);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<myMotion>k__BackingField", motion);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<mySequenceController>k__BackingField", sequenceController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<myMesh>k__BackingField", mesh);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<characterController>k__BackingField", characterController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<humanoid>k__BackingField", humanoid);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<movementController>k__BackingField", movementController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<hitController>k__BackingField", hitController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<enemyOrder>k__BackingField", order);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<enemyDamageController>k__BackingField", damageController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<enemyStrikeController>k__BackingField", strikeController);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<enemyRankManager>k__BackingField", rankManager);
            TrySetFieldDataIfNull(action, EnemyActionController.REFType, "<enemyGrapple>k__BackingField", grapple);
            TrySetFieldDataIfNull(action, MoldedActionController.REFType, "<visionSensor>k__BackingField", visionSensor);
            TrySetFieldDataIfNull(action, MoldedActionController.REFType, "<hearingSensor>k__BackingField", hearingSensor);
            TrySetFieldDataIfNull(action, MoldedActionController.REFType, "<playerStatus>k__BackingField", GetPlayerStatus());

            TryBridgeImportedCh8Em4400Status(status, action, think, commandController, order, damageController, strikeController, movementController, smoothAnimator);
            TryBridgeImportedCh8EnemyOrder(order, action, think, status, commandController, visionSensor, basicAnimController, motionManager);
            TryBridgeImportedCh8EnemyDamageController(damageController, action, commandController, status, hitController);

            if (think != null)
            {
                TryBridgeImportedCh8Em4400Think(
                    think,
                    action,
                    status,
                    commandController,
                    order,
                    visionSensor,
                    hearingSensor,
                    commandRequester,
                    basicAnimController,
                    navigationSurface);
            }

            if (instanceAddress != 0 && IsImportedCh8Em4400BridgeComplete(action))
            {
                bridgedCh8Em4400Instances.Add(instanceAddress);
            }

            return true;
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 Em4400 runtime: {ex.Message}", isVerbose: true);
            return false;
        }
    }

    private static bool IsImportedCh8Em4400BridgeComplete(CH8Em4400ActionController action)
    {
        try
        {
            return TryRead(() => action.myStatus) != null &&
                TryRead(() => action.myThink) != null &&
                TryRead(() => action.enemyThink) != null &&
                TryRead(() => action.myCommandActionController) is { } commandController &&
                GetCommandActionCount(commandController) > 0;
        }
        catch
        {
            return false;
        }
    }

    private static void TryNormalizeImportedDlcEnemyActionState(EnemyActionController? action)
    {
        if (action == null)
            return;

        try
        {
            TryWrite(() => action.hasDie = false);
            TryWrite(() => action.isFinishedDead = false);
            TryWrite(() => action.calledFinishedDead = false);
            TryWrite(() => action.isMarkedDeadStats = false);
            TrySetObjectField(action, "<hasDie>k__BackingField", false);
            TrySetObjectField(action, "<isFinishedDead>k__BackingField", false);
            TrySetObjectField(action, "<calledFinishedDead>k__BackingField", false);
            TrySetObjectField(action, "<isMarkedDeadStats>k__BackingField", false);
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to normalize imported DLC enemy action state: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryBridgeImportedCh8Em4400Status(
        CH8Em4400Status? status,
        CH8Em4400ActionController action,
        CH8Em4400Think? think,
        CommandActionController? commandController,
        EnemyOrder? order,
        EnemyDamageController? damageController,
        EnemyStrikeController? strikeController,
        MovementController? movementController,
        SmoothAnimator? smoothAnimator)
    {
        if (status == null)
            return;

        try
        {
            ForceDoomsRuntimeActive(status);
            TryWrite(() => status.myActionController ??= action);
            TryWrite(() => status.myThink ??= think);
            TryWrite(() => status.commandActionController ??= commandController);
            TryWrite(() => status.EnemyThink ??= think);
            TryWrite(() => status.enemyActionController ??= action);
            TryWrite(() => status.enemyDamageController ??= damageController);
            TryWrite(() => status.enemyStrikeController ??= strikeController);
            TryWrite(() => status.EnemyOrder ??= order);
            TryWrite(() => status.movementController ??= movementController);
            TryWrite(() => status.SmoothAnim ??= smoothAnimator);
            TrySetFieldDataIfNull(status, CH8Em4400Status.REFType, "myActionController", action);
            TrySetFieldDataIfNull(status, CH8Em4400Status.REFType, "myThink", think);
            TrySetFieldDataIfNull(status, CH8Em4400Status.REFType, "commandActionController", commandController);
            status.isAppeared = true;
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 Em4400 status state: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryBridgeImportedCh8EnemyOrder(
        EnemyOrder? order,
        CH8Em4400ActionController action,
        CH8Em4400Think? think,
        CH8Em4400Status? status,
        CommandActionController? commandController,
        AIVisionSensor? visionSensor,
        BasicAnimationController? basicAnimController,
        MotionManager? motionManager)
    {
        if (order == null)
            return;

        try
        {
            ForceDoomsRuntimeActive(order);
            TryWrite(() => order.enemyActionController ??= action);
            TryWrite(() => order.CommandAction ??= commandController);
            TryWrite(() => order.Think ??= CastObject<ThinkBase>(think));
            TryWrite(() => order.VisionSensor ??= visionSensor);
            if (status is IObject statusObject)
            {
                TryWrite(() => order.CharacterStatus ??= statusObject.As<ICharacterStatus>());
                TryWrite(() => order.EnemyStatus ??= statusObject.As<IEnemyStatus>());
            }
            TryWrite(() => order.BasicAnimController ??= basicAnimController);
            TryWrite(() => order.MotManager ??= motionManager);
            TrySetFieldDataIfNull(order, EnemyOrder.REFType, "<enemyActionController>k__BackingField", action);
            TrySetFieldDataIfNull(order, EnemyOrder.REFType, "CommandAction", commandController);
            TrySetFieldDataIfNull(order, EnemyOrder.REFType, "Think", CastObject<ThinkBase>(think));
            TrySetFieldDataIfNull(order, EnemyOrder.REFType, "VisionSensor", visionSensor);
            if (status is IObject statusObjectForFields)
            {
                TrySetFieldDataIfNull(order, EnemyOrder.REFType, "CharacterStatus", statusObjectForFields.As<ICharacterStatus>());
                TrySetFieldDataIfNull(order, EnemyOrder.REFType, "EnemyStatus", statusObjectForFields.As<IEnemyStatus>());
            }
            TrySetFieldDataIfNull(order, EnemyOrder.REFType, "BasicAnimController", basicAnimController);
            TrySetFieldDataIfNull(order, EnemyOrder.REFType, "MotManager", motionManager);
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 enemy order state: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryBridgeImportedCh8EnemyDamageController(
        EnemyDamageController? damageController,
        CH8Em4400ActionController action,
        CommandActionController? commandController,
        CH8Em4400Status? status,
        HitController? hitController)
    {
        if (damageController == null)
            return;

        try
        {
            ForceDoomsRuntimeActive(damageController);
            TryWrite(() => damageController.enemyActionController ??= action);
            TryWrite(() => damageController.MyCommandActionController ??= commandController);
            TryWrite(() => damageController.HitController ??= hitController);
            if (status is IObject statusObject)
            {
                TryWrite(() => damageController.CharacterStatus ??= statusObject.As<ICharacterStatus>());
            }
            TrySetFieldDataIfNull(damageController, EnemyDamageController.REFType, "<enemyActionController>k__BackingField", action);
            TrySetFieldDataIfNull(damageController, EnemyDamageController.REFType, "<MyCommandActionController>k__BackingField", commandController);
            TrySetFieldDataIfNull(damageController, EnemyDamageController.REFType, "HitController", hitController);
            TrySetFieldDataIfNull(damageController, CH8Em4400DamageController.REFType, "<myActionController>k__BackingField", action);
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 enemy damage state: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryBridgeImportedCh8Em4400Think(
        CH8Em4400Think think,
        CH8Em4400ActionController action,
        CH8Em4400Status? status,
        CommandActionController? commandController,
        EnemyOrder? order,
        AIVisionSensor? visionSensor,
        AIHearingSensor? hearingSensor,
        CommandRequester? commandRequester,
        BasicAnimationController? basicAnimController,
        via.navigation.NavigationSurface? navigationSurface)
    {
        try
        {
            ForceDoomsRuntimeActive(think);

            TryWrite(() => think.myActionController ??= action);
            TryWrite(() => think.myStatus ??= status);
            TryWrite(() => think.Commander ??= commandController?.Commander);
            TryWrite(() => think.BasicAnimCtrl ??= basicAnimController);
            TryWrite(() => think.NaviSurface ??= navigationSurface);
            TrySetFieldDataIfNull(think, CH8Em4400Think.REFType, "<myActionController>k__BackingField", action);
            TrySetFieldDataIfNull(think, CH8Em4400Think.REFType, "<myStatus>k__BackingField", status);
            TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "BasicAnimCtrl", basicAnimController);
            TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "NaviSurface", navigationSurface);
            TrySetFieldDataIfNull(think, ThinkBase.REFType, "Commander", commandController?.Commander);

            if (think.status == null)
            {
                think.status = CastObject<IEnemyStatus>(status);
            }
            TryWrite(() => think.enemyStatus ??= CastObject<EnemyStatus>(status));
            TryWrite(() => think.enemyOrder ??= order);
            TryWrite(() => think.commandRequester ??= commandRequester);
            TryWrite(() => think.visionSensor ??= visionSensor);
            TryWrite(() => think.hearingSensor ??= hearingSensor);
            TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "<status>k__BackingField", CastObject<IEnemyStatus>(status));
            TrySetFieldDataIfNull(think, CH8Em4400Think.REFType, "<enemyStatus>k__BackingField", CastObject<EnemyStatus>(status));
            TrySetFieldDataIfNull(think, CH8Em4400Think.REFType, "<enemyOrder>k__BackingField", order);
            TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "<commandRequester>k__BackingField", commandRequester);
            TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "<visionSensor>k__BackingField", visionSensor);
            TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "<hearingSensor>k__BackingField", hearingSensor);
            ForceAiSensorRuntimeActive(visionSensor);
            ForceAiSensorRuntimeActive(hearingSensor);

            var playerObject = GetPlayerObject();
            var playerStatus = GetPlayerStatus();
            if (playerStatus is IObject playerStatusObject)
            {
                think.playerStatus ??= playerStatusObject.As<IPlayerStatus>();
                think.targetStatus ??= playerStatusObject.As<ICharacterStatus>();
                TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "<playerStatus>k__BackingField", playerStatusObject.As<IPlayerStatus>());
                TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "<targetStatus>k__BackingField", playerStatusObject.As<ICharacterStatus>());
            }

            if (think.Target == null && playerObject != null)
            {
                TrySetFieldDataIfNull(think, EnemyThinkBase.REFType, "_Target", playerObject);
                TrySetObjectField(think, "_Target", playerObject);
                try { think.setTarget(playerObject, EnemyThinkBase.ReasonType.Outer); } catch { }
            }

            if (think.isThinkOff)
            {
                think.thinkOn();
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 Em4400 think state: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryEnsureCh8Em4400UpdateController(
        via.GameObject owner,
        CH8Em4400ActionController action,
        CH8Em4400Think? think,
        CommandActionController? commandController,
        AIVisionSensor? visionSensor,
        AIHearingSensor? hearingSensor)
    {
        try
        {
            var updateController = TryRead(() => action.myUpdateController)
                ?? GetOrCreateComponent<CH8EnemyUpdateController>(owner, CH8EnemyUpdateController.REFType);
            if (updateController == null)
                return;

            ForceDoomsRuntimeActive(updateController);
            TryWrite(() => action.myUpdateController = updateController);

            TryAddCh8EnemyUpdateTarget(updateController, action);
            TryAddCh8EnemyUpdateTarget(updateController, think);
            TryAddCh8EnemyUpdateTarget(updateController, commandController);
            TryAddCh8EnemyUpdateTarget(updateController, commandController?.Commander);
            TryAddCh8EnemyUpdateTarget(updateController, commandController?.Requester);
            TryAddCh8EnemyUpdateTarget(updateController, visionSensor);
            TryAddCh8EnemyUpdateTarget(updateController, hearingSensor);

            try { updateController.intervalFrame = 1; } catch { }
            try { updateController.setLevel(0); } catch { }
            try { updateController.doAwake(); } catch { }
            try { updateController.doStart(); } catch { }
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 Em4400 update controller: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryAddCh8EnemyUpdateTarget(CH8EnemyUpdateController updateController, via.Behavior? behavior)
    {
        if (behavior == null)
            return;

        try
        {
            var updateControllerAddress = GetObjectAddress(updateController);
            var behaviorAddress = GetObjectAddress(behavior);
            if (updateControllerAddress != 0 &&
                behaviorAddress != 0 &&
                !registeredCh8EnemyUpdateTargets.Add((updateControllerAddress, behaviorAddress)))
            {
                return;
            }

            updateController.addTargetComponentList(behavior);
        }
        catch
        {
            // The explicit command-controller tick below is authoritative; this list only restores CH8 parity where it works.
        }
    }

    private static void TryEnsureImportedCh8Em4400DamageAndColliders(
        via.GameObject owner,
        CH8Em4400ActionController action,
        CommandActionController? commandController,
        CH8Em4400Status? status)
    {
        try
        {
            ForEachComponent<HitController>(owner, HitController.REFType, hitController =>
            {
                ForceDoomsRuntimeActive(hitController);
                try { hitController.doAwake(); } catch { }
                try { hitController.doStart(); } catch { }
                try { hitController.update(); } catch { }
            });

            ForEachComponent<DamageController>(owner, DamageController.REFType, damageController =>
            {
                ForceDoomsRuntimeActive(damageController);
                TryWrite(() => damageController.CharacterStatus ??= CastObject<ICharacterStatus>(status));
                TryWrite(() => damageController.HitController ??= TryGetComponent<HitController>(owner, HitController.REFType));
                try { damageController.doAwake(); } catch { }
                try { damageController.doStart(); } catch { }
                try { damageController.doUpdate(); } catch { }
            });

            ForEachComponent<EnemyDamageController>(owner, EnemyDamageController.REFType, damageController =>
            {
                ForceDoomsRuntimeActive(damageController);
                TryWrite(() => damageController.enemyActionController ??= action);
                TryWrite(() => damageController.MyCommandActionController ??= commandController);
                try { damageController.doAwake(); } catch { }
                try { damageController.doStart(); } catch { }
            });

            ForEachComponent<CH8Em4400DamageController>(owner, CH8Em4400DamageController.REFType, damageController =>
            {
                ForceDoomsRuntimeActive(damageController);
                TryWrite(() => damageController.myActionController ??= action);
                TryWrite(() => damageController.enemyStatus ??= CastObject<CH8EnemyStatus>(status));
                try { damageController.doStart(); } catch { }
            });

            ForEachComponent<CollidersController>(owner, CollidersController.REFType, controller =>
            {
                ForceDoomsRuntimeActive(controller);
                try { controller.doStart(); } catch { }
            });

            ForEachComponent<RequestSetCollider>(owner, RequestSetCollider.REFType, collider =>
            {
                ForceCollidableRuntimeActive(collider);
                try { collider.updatePose(); } catch { }
                try { collider.updateBroadphase(); } catch { }
                try { collider.updateNotify(); } catch { }
            });

            ForEachComponent<ColliderSet>(owner, ColliderSet.REFType, collider =>
            {
                ForceCollidableRuntimeActive(collider);
                try { collider.updatePose(); } catch { }
                try { collider.updateBroadphase(); } catch { }
                try { collider.updateNotify(); } catch { }
            });
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 Em4400 damage/collision runtime: {ex.Message}", isVerbose: true);
        }
    }

    private static bool TryEnsureCh8Em4400CommandActions(
        via.GameObject owner,
        CH8Em4400ActionController action)
    {
        try
        {
            var actionAddress = GetObjectAddress(action);
            var commandController = GetComponent<CH8CommandActionController>(owner, CH8CommandActionController.REFType);
            if (commandController == null)
                return false;

            ForceDoomsRuntimeActive(commandController);
            ForceDoomsRuntimeActive(commandController.Commander);
            ForceDoomsRuntimeActive(commandController.Requester);
            ForceDoomsRuntimeActive(TryRead(() => action.myBasicAnimController));
            ForceDoomsRuntimeActive(TryRead(() => action.mySmoothAnim));
            ForceDoomsRuntimeActive(TryRead(() => action.myMotionManager));

            if (actionAddress != 0 && initializedCh8Em4400CommandActions.Contains(actionAddress))
            {
                if (GetCommandActionCount(commandController) > 0 && IsImportedCh8Em4400BridgeComplete(action))
                    return true;

                initializedCh8Em4400CommandActions.Remove(actionAddress);
            }

            InitializeCh8CommandController(owner, action, commandController);

            var basicAnimController = TryRead(() => action.myBasicAnimController);
            if (basicAnimController != null)
            {
                try { CH8Em4400ActionTag.registerToBasicAnimationController(basicAnimController); } catch { }
            }

            if (TryRead(() => action.myCommandRequester) == null && commandController.Requester != null)
            {
                TryWrite(() => action.myCommandRequester = commandController.Requester);
            }

            var actionList = commandController.ActionList;
            if (actionList == null)
                return false;

            var beforeActionCount = actionList.Count;
            if (beforeActionCount == 0)
            {
                foreach (var typeName in Ch8Em4400CommandActionTypeNames)
                {
                    try
                    {
                        var type = TDB.Get().FindType(typeName);
                        var instance = type?.CreateInstance(0);
                        if (instance == null)
                            continue;

                        instance.Globalize();
                        globalizedDlcCommandActions.Add(instance);

                        var commandAction = instance.As<EnemyCommandActionBase>();
                        var baseCommandAction = instance.As<CommandAction>();
                        if (commandAction == null || baseCommandAction == null)
                            continue;

                        InitializeCh8CommandAction(owner, action, commandController, commandAction);
                        TrySetupCh8Em4400CommandAction(instance, owner, action, commandController);
                        InitializeCh8CommandAction(owner, action, commandController, commandAction);
                        SetCh8Em4400CommandActionLinks(instance, action);

                        actionList.Add(baseCommandAction);
                    }
                    catch (Exception ex)
                    {
                        logger.Log($"Failed to add imported CH8 Em4400 command action '{typeName}': {ex.Message}", isVerbose: true);
                    }
                }
            }

            var container = CastObject<CommandActionContainerBase>(action.MyCommandActionContainer);
            if (actionList.Count == 0 && container != null)
            {
                commandController.regist(container);
            }

            InitializeRegisteredCh8CommandActions(owner, action, commandController);
            commandController.IdleAction = commandController.findIdleAction()
                ?? FindCommandActionById(commandController.ActionList, 0);

            TryRequestCh8Em4400IdleAnimation(action, commandController);
            var isReady = GetCommandActionCount(commandController) > 0;
            if (isReady && actionAddress != 0)
            {
                initializedCh8Em4400CommandActions.Add(actionAddress);
            }

            return isReady;
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to initialize imported CH8 Em4400 command actions: {ex.Message}", isVerbose: true);
            return false;
        }
    }

    private static void TryAdvanceCh8Em4400CommandController(
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        try
        {
            if (commandController.CurrentAction == null && commandController.IdleAction == null)
                return;

            commandController.doUpdate();
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to advance imported CH8 Em4400 command controller: {ex.Message}", isVerbose: true);
        }
    }

    private static bool TryTickImportedCh8Em4400Instance(via.GameObject? enemyInstance)
    {
        return IsGameObjectRuntimeActive(enemyInstance) &&
            TryBridgeImportedCh8Em4400Instance(enemyInstance);
    }

    private static void TrySetupCh8Em4400CommandAction(
        ManagedObject commandActionObject,
        via.GameObject owner,
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        try
        {
            SetCh8Em4400CommandActionLinks(commandActionObject, action);
            commandActionObject.As<CommandAction>()?.setup(owner, commandController);
            SetCh8Em4400CommandActionLinks(commandActionObject, action);
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to setup imported CH8 Em4400 command action: {ex.Message}", isVerbose: true);
        }
    }

    private static void SetCh8Em4400CommandActionLinks(
        ManagedObject commandActionObject,
        CH8Em4400ActionController action)
    {
        var status = TryRead(() => action.myStatus);
        var think = TryGetComponent<CH8Em4400Think>(action.GameObject, CH8Em4400Think.REFType);

        var ch8Base = commandActionObject.As<app.CH8Em4400.Action.CH8Base>();
        if (ch8Base != null)
        {
            ch8Base.myActionController = action;
            ch8Base.myStatus = status;
            if (think != null)
            {
                ch8Base.myThink = think;
            }
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Base.REFType, "<myActionController>k__BackingField", action);
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Base.REFType, "<myStatus>k__BackingField", status);
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Base.REFType, "<myThink>k__BackingField", think);
            return;
        }

        var idle = commandActionObject.As<app.CH8Em4400.Action.CH8Idle>();
        if (idle != null)
        {
            idle.myActionController = action;
            idle.myStatus = status;
            if (think != null)
            {
                idle.myThink = think;
            }
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Idle.REFType, "myActionController", action);
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Idle.REFType, "myStatus", status);
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Idle.REFType, "myThink", think);
            return;
        }

        var damage = commandActionObject.As<app.CH8Em4400.Action.CH8Damage>();
        if (damage != null)
        {
            damage.myActionController = action;
            damage.myStatus = status;
            if (think != null)
            {
                damage.myThink = think;
            }
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Damage.REFType, "myActionController", action);
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Damage.REFType, "myStatus", status);
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Damage.REFType, "myThink", think);
            return;
        }

        var dead = commandActionObject.As<app.CH8Em4400.Action.CH8Dead>();
        if (dead != null)
        {
            dead.myActionController = action;
            dead.myStatus = status;
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Dead.REFType, "myActionController", action);
            TrySetFieldDataIfNull(commandActionObject, app.CH8Em4400.Action.CH8Dead.REFType, "myStatus", status);
        }
    }

    private static void InitializeCh8CommandController(
        via.GameObject owner,
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        var commander = commandController.Commander ?? GetComponent<CommandUpdater>(owner, CommandUpdater.REFType);
        if (commander != null)
        {
            commandController.Commander = commander;
            ForceDoomsRuntimeActive(commander);
        }

        var requester = commandController.Requester ?? GetComponent<CommandRequester>(owner, CommandRequester.REFType);
        if (requester != null)
        {
            commandController.Requester = requester;
            ForceDoomsRuntimeActive(requester);
            if (commander != null)
            {
                try { requester.setup(commander); } catch { }
            }
        }

        var motionManager = commandController.MotionManager
            ?? TryRead(() => action.myMotionManager)
            ?? GetComponent<MotionManager>(owner, MotionManager.REFType);
        if (motionManager != null)
        {
            commandController.MotionManager = motionManager;
            ForceDoomsRuntimeActive(motionManager);
        }
    }

    private static void InitializeRegisteredCh8CommandActions(
        via.GameObject owner,
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        var actionList = commandController.ActionList;
        var count = actionList?.Count ?? 0;
        for (var index = 0; index < count; index++)
        {
            InitializeCh8CommandAction(
                owner,
                action,
                commandController,
                CastObject<EnemyCommandActionBase>(actionList?[index]));
        }
    }

    private static void InitializeCh8CommandAction(
        via.GameObject owner,
        CH8Em4400ActionController action,
        CommandActionController commandController,
        EnemyCommandActionBase? commandAction)
    {
        if (commandAction == null)
            return;

        var command = (CommandAction)commandAction;
        var status = TryRead(() => action.myStatus);
        var think = TryGetComponent<CH8Em4400Think>(owner, CH8Em4400Think.REFType);
        command.Owner = owner;
        command.MotionMgr = commandController.MotionManager ?? TryRead(() => action.myMotionManager);
        command.MotionFsm = command.MotionMgr?.MotionFsm;
        command.Commander = commandController.Commander;
        command.BasicAnimController = TryRead(() => action.myBasicAnimController);
        command.SmoothAnim = TryRead(() => action.mySmoothAnim);
        command.ActionController = commandController;
        TrySetFieldDataIfNull(command, CommandAction.REFType, "Owner", owner);
        TrySetFieldDataIfNull(command, CommandAction.REFType, "MotionMgr", command.MotionMgr);
        TrySetFieldDataIfNull(command, CommandAction.REFType, "MotionFsm", command.MotionFsm);
        TrySetFieldDataIfNull(command, CommandAction.REFType, "Commander", command.Commander);
        TrySetFieldDataIfNull(command, CommandAction.REFType, "BasicAnimController", command.BasicAnimController);
        TrySetFieldDataIfNull(command, CommandAction.REFType, "SmoothAnim", command.SmoothAnim);
        TrySetFieldDataIfNull(command, CommandAction.REFType, "ActionController", commandController);

        if (status is IObject statusObject)
        {
            command.Status = statusObject.As<ICharacterStatus>();
            commandAction.EmStatus = statusObject.As<IEnemyStatus>();
            TrySetFieldDataIfNull(command, CommandAction.REFType, "Status", statusObject.As<ICharacterStatus>());
            TrySetFieldDataIfNull(commandAction, EnemyCommandActionBase.REFType, "EmStatus", statusObject.As<IEnemyStatus>());
        }

        commandAction.enemyActionController = action;
        if (think != null)
        {
            commandAction.enemyThink = think;
        }
        TrySetFieldDataIfNull(commandAction, EnemyCommandActionBase.REFType, "<enemyActionController>k__BackingField", action);
        TrySetFieldDataIfNull(commandAction, EnemyCommandActionBase.REFType, "<enemyThink>k__BackingField", CastObject<EnemyThinkBase>(think));

        var motion = TryRead(() => action.myMotion);
        if (motion != null)
        {
            commandAction.motion = motion;
            TrySetFieldDataIfNull(commandAction, EnemyCommandActionBase.REFType, "<motion>k__BackingField", motion);
        }
    }

    private static void TryRequestCh8Em4400IdleAnimation(
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        var motionManager = TryRead(() => action.myMotionManager);
        var motionEndFrame = motionManager?.getMotionEndFrame(0) ?? 0;
        if (motionEndFrame > 0)
            return;

        var bac = TryRead(() => action.myBasicAnimController);
        if (bac == null)
            return;

        var requestOption = (commandController.IdleAction as IObject)?.GetField("AnimRequestOption")
            as SmoothAnimator.RequestOption;
        if (requestOption == null)
        {
            var requestOptionObject = SmoothAnimator.RequestOption.REFType.CreateInstance(0);
            requestOptionObject.Globalize();
            globalizedDlcCommandActions.Add(requestOptionObject);
            requestOption = requestOptionObject.As<SmoothAnimator.RequestOption>();
            requestOption?.clear();
        }

        bac.request(CH8Em4400ActionTag.Idle, requestOption);
    }

    private static CommandAction? FindCommandActionById(REFrameworkNET.Collections.IList<CommandAction>? list, int id)
    {
        var count = list?.Count ?? 0;
        for (var index = 0; index < count; index++)
        {
            var commandAction = list?[index];
            if (commandAction?.ID == id)
                return commandAction;
        }

        return null;
    }

    private static int GetCommandActionCount(CommandActionController? commandController)
    {
        try
        {
            return commandController?.ActionList?.Count ?? 0;
        }
        catch
        {
            return 0;
        }
    }

    private static int GetCommandActionContainerCount(CH8Em4400ActionController? action)
    {
        try
        {
            return Convert.ToInt32((action?.MyCommandActionContainer as IObject)?.Call("get_count") ?? 0);
        }
        catch
        {
            return 0;
        }
    }

    private static bool TryRunImportedCh8Em4400NativeCommandRegistration(
        via.GameObject? owner,
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        var actionAddress = GetObjectAddress(action);
        var shouldAttemptNative = actionAddress == 0 ||
            attemptedCh8Em4400NativeCommandRegistration.Add(actionAddress);

        try
        {
            ForceDoomsRuntimeActive(action);
            ForceDoomsRuntimeActive(commandController);

            if (shouldAttemptNative && GetCommandActionContainerCount(action) == 0)
            {
                action.doAwake();
            }

            var container = CastObject<CommandActionContainerBase>(action.MyCommandActionContainer);
            if (GetCommandActionCount(commandController) == 0 &&
                GetCommandActionContainerCount(action) > 0 &&
                container != null)
            {
                commandController.regist(container);
            }

            var actionCount = GetCommandActionCount(commandController);
            var containerCount = GetCommandActionContainerCount(action);
            if (actionCount > 0)
            {
                logger.Log(
                    $"Completed native imported CH8 Em4400 command registration rescue: container={containerCount}, actions={actionCount}.",
                    isVerbose: true);
                return true;
            }

            owner ??= TryRead(() => action.GameObject);
            if (owner != null && TryEnsureCh8Em4400CommandActions(owner, action))
            {
                logger.Log(
                    $"Completed managed imported CH8 Em4400 command registration fallback: container={containerCount}, actions={GetCommandActionCount(commandController)}.",
                    isVerbose: true);
                return true;
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Failed native imported CH8 Em4400 command registration rescue: {ex.Message}", isVerbose: true);
        }

        return false;
    }

    private static bool IsImportedCh8Em4400CommandRegistrationReady(EnemySpawnInfo spawnInfo)
    {
        var action = CastObject<CH8Em4400ActionController>(spawnInfo.EnemyActionController)
            ?? GetComponent<CH8Em4400ActionController>(spawnInfo.EnemyInstance, CH8Em4400ActionController.REFType);
        if (action == null)
            return true;

        var commandController = TryRead(() => action.myCommandActionController)
            ?? GetComponent<CH8CommandActionController>(spawnInfo.EnemyInstance, CH8CommandActionController.REFType);
        if (commandController == null)
            return false;

        var actionCount = GetCommandActionCount(commandController);
        var containerCount = GetCommandActionContainerCount(action);
        if (actionCount > 0)
            return true;

        if (TryRunImportedCh8Em4400NativeCommandRegistration(spawnInfo.EnemyInstance, action, commandController))
            return true;

        actionCount = GetCommandActionCount(commandController);
        containerCount = GetCommandActionContainerCount(action);
        var spawnInfoAddress = GetObjectAddress(spawnInfo);
        if (spawnInfoAddress != 0 && deferredImportedDlcEnemySetups.Add(spawnInfoAddress))
        {
            logger.Log(
                $"Deferring imported CH8 Em4400 setup for '{spawnInfo.UnitAlias}' until native command actions are registered (container={containerCount}, actions={actionCount}).",
                isVerbose: true);
        }

        return false;
    }

    private static bool TryPrepareImportedDlcEnemySpawnInfo(object? spawnInfoObject)
    {
        if (!IsImportedDlcEnemySpawnInfo(spawnInfoObject) || !IsNonDlcChapterActive())
            return false;

        var spawnInfo = CastObject<EnemySpawnInfo>(spawnInfoObject);
        if (spawnInfo == null)
            return false;

        var address = GetObjectAddress(spawnInfoObject);
        if (address != 0 && preparedDlcEnemyRuntimeObjects.Add(address))
        {
            logger.Log(
                $"Preparing imported DLC enemy spawn info '{spawnInfo.UnitAlias}' for main-game runtime setup.",
                isVerbose: true);
        }

        ForceDoomsRuntimeActive(spawnInfo);
        ForceGameObjectRuntimeActive(spawnInfo.EnemyInstance);
        ClearImportedCh8NeedAreaRequests(spawnInfoObject);

        ForceDoomsRuntimeActive(spawnInfo.EnemyActionController);
        ForceDoomsRuntimeActive(spawnInfo.EnemyOrder);
        ForceDoomsRuntimeActive(spawnInfo.EnemyStatus);
        ForceDoomsRuntimeActive(spawnInfo.EnemyDamageController);
        ForceDoomsRuntimeActive(spawnInfo.EventActionController);

        return true;
    }

    private static int GetObjectListCount(object? listObject)
    {
        try
        {
            return Convert.ToInt32((listObject as IObject)?.Call("get_Count") ?? 0);
        }
        catch
        {
            return 0;
        }
    }

    private static object? GetObjectListItem(object? listObject, int index)
    {
        try
        {
            return (listObject as IObject)?.Call("get_Item", index);
        }
        catch
        {
            return null;
        }
    }

    private static T? GetListItem<T>(object? listObject, int index)
        where T : class
        => CastObject<T>(GetObjectListItem(listObject, index));

    private static T? GetComponent<T>(via.GameObject? gameObject, TypeDefinition typeDefinition)
        where T : class
    {
        if (gameObject == null)
            return null;

        try
        {
            var components = gameObject.Components;
            if (components != null)
            {
                foreach (var component in components)
                {
                    var typed = CastObject<T>(component);
                    if (typed != null)
                        return typed;
                }
            }
        }
        catch
        {
            // Imported DLC objects can fail typed component lookup while still exposing their raw component array.
        }

        try
        {
            var runtimeType = typeDefinition.GetRuntimeType().As<_System.Type>();
            return runtimeType == null
                ? null
                : CastObject<T>(gameObject.getComponent(runtimeType));
        }
        catch
        {
            return null;
        }
    }

    private static T? GetOrCreateComponent<T>(via.GameObject? gameObject, TypeDefinition typeDefinition)
        where T : class
    {
        if (gameObject == null)
            return null;

        var existing = GetComponent<T>(gameObject, typeDefinition);
        if (existing != null)
            return existing;

        var runtimeType = typeDefinition.GetRuntimeType().As<_System.Type>();
        return runtimeType == null
            ? null
            : CastObject<T>(gameObject.createComponent(runtimeType));
    }

    private static via.GameObject? GetPlayerObject()
    {
        var objectManager = API.GetManagedSingleton("app.ObjectManager")?.As<ObjectManager>();
        return objectManager?.getPlayer() ?? objectManager?.PlayerObj;
    }

    private static PlayerStatus? GetPlayerStatus()
        => GetComponent<PlayerStatus>(GetPlayerObject(), PlayerStatus.REFType);

    private static bool TryPrepareImportedDlcEnemySpawnInfoList(object? listObject)
    {
        try
        {
            var preparedAny = false;
            var count = GetObjectListCount(listObject);
            for (var index = 0; index < count; index++)
            {
                preparedAny |= TryPrepareImportedDlcEnemySpawnInfo(GetObjectListItem(listObject, index));
            }

            return preparedAny;
        }
        catch
        {
            return false;
        }
    }

    private static void TryCompleteImportedDlcEnemySetupList(object? listObject)
    {
        try
        {
            var count = GetObjectListCount(listObject);
            for (var index = 0; index < count; index++)
            {
                TryCompleteImportedDlcEnemySetup(GetObjectListItem(listObject, index));
            }
        }
        catch
        {
            // Best-effort runtime rescue for already-bound DLC spawn infos.
        }
    }

    private static bool TryTickImportedDlcEnemyInstanceList(object? listObject)
    {
        try
        {
            var tickedAny = false;
            var count = GetObjectListCount(listObject);
            for (var index = 0; index < count; index++)
            {
                var unit = GetListItem<EnemyPool.AssociateUnit>(listObject, index);
                tickedAny |= TryTickImportedCh8Em4400Instance(unit?.instanceObject);
            }

            return tickedAny;
        }
        catch
        {
            return false;
        }
    }

    private static bool TryTickImportedDlcEnemyInstances(EnemyPool? pool)
    {
        if (pool == null)
            return false;

        return
            TryTickImportedDlcEnemyInstanceList(pool.Instancies) |
            TryTickImportedDlcEnemyInstanceList(pool.ExternalInstancies);
    }

    private static bool TryPrepareImportedDlcEnemyGenerator(object? generatorObject, bool tickInstances = false)
    {
        if (!IsNonDlcChapterActive())
            return false;

        var generator = CastObject<EnemyGenerator>(generatorObject);
        if (generator == null)
            return false;

        var pool = generator.poolInstance;
        var isImportedGenerator = IsImportedDlcEnemyGenerator(generatorObject);
        if (isImportedGenerator)
        {
            ForceDoomsRuntimeActive(generator);
            ForceDoomsRuntimeActive(pool);
        }

        var hasDlcSpawnInfo =
            TryPrepareImportedDlcEnemySpawnInfoList(pool?.SpawnInfos) |
            TryPrepareImportedDlcEnemySpawnInfoList(pool?.ForceSpawnInfos) |
            TryPrepareImportedDlcEnemySpawnInfoList(pool?.ExternalSpawnInfos) |
            TryPrepareImportedDlcEnemySpawnInfoList(pool?.ExternalForceSpawnInfos);

        var hasDlcInstance = tickInstances && TryTickImportedDlcEnemyInstances(pool);

        if (!isImportedGenerator && !hasDlcSpawnInfo && !hasDlcInstance)
            return false;

        ForceDoomsRuntimeActive(generator);
        ForceDoomsRuntimeActive(pool);

        if (hasDlcSpawnInfo)
        {
            TryCompleteImportedDlcEnemySetupList(pool?.SpawnInfos);
            TryCompleteImportedDlcEnemySetupList(pool?.ForceSpawnInfos);
            TryCompleteImportedDlcEnemySetupList(pool?.ExternalSpawnInfos);
            TryCompleteImportedDlcEnemySetupList(pool?.ExternalForceSpawnInfos);
        }

        var address = GetObjectAddress(generatorObject);
        if (address != 0 && preparedDlcEnemyRuntimeObjects.Add(address))
        {
            logger.Log(
                $"Preparing imported DLC enemy generator '{generator.Alias}' for main-game runtime setup.",
                isVerbose: true);
        }

        return true;
    }

    private static void TryPrepareImportedDlcEnemyGenerators(object? managerObject, bool tickInstances = false)
    {
        if (!IsNonDlcChapterActive())
            return;

        var generators = (managerObject as IObject)?.GetField("generators");
        var count = GetObjectListCount(generators);
        for (var index = 0; index < count; index++)
        {
            TryPrepareImportedDlcEnemyGenerator(GetObjectListItem(generators, index), tickInstances);
        }
    }

    private static void TryPrepareImportedDlcEnemyGenerators()
        => TryPrepareImportedDlcEnemyGenerators(API.GetManagedSingleton("app.EnemyGeneratorManager"));

    private static bool ShouldRunImportedDlcEnemyRuntimeScan()
    {
        importedDlcEnemyRuntimeScanFrame++;
        return importedDlcEnemyRuntimeScanFrame % ImportedDlcEnemyRuntimeScanIntervalFrames == 0;
    }

    private static void TryPrepareImportedDlcEnemyRuntime(object? spawnInfoObject, object? managerObject = null)
    {
        if (!IsImportedDlcEnemySpawnInfo(spawnInfoObject) || !IsNonDlcChapterActive())
            return;

        TryPrepareImportedDlcEnemyGenerators(managerObject ?? API.GetManagedSingleton("app.EnemyGeneratorManager"));
        TryPrepareImportedDlcEnemySpawnInfo(spawnInfoObject);
    }

    private static void TryCompleteImportedDlcEnemySetup(object? spawnInfoObject)
    {
        if (isCompletingImportedDlcEnemySetup ||
            !IsImportedDlcEnemySpawnInfo(spawnInfoObject) ||
            !IsNonDlcChapterActive())
        {
            return;
        }

        try
        {
            isCompletingImportedDlcEnemySetup = true;
            TryPrepareImportedDlcEnemyRuntime(spawnInfoObject);

            var spawnInfo = CastObject<EnemySpawnInfo>(spawnInfoObject);
            if (spawnInfo == null ||
                spawnInfo.RequestedOperation != EnemyGenerator.Operation.Setup ||
                spawnInfo.EnemyInstance == null ||
                spawnInfo.EnemyActionController == null ||
                spawnInfo.EnemyOrder == null ||
                spawnInfo.EnemyStatus == null)
            {
                return;
            }

            var spawnInfoAddress = GetObjectAddress(spawnInfoObject);
            if (spawnInfoAddress != 0 && completedImportedDlcEnemySetups.Contains(spawnInfoAddress))
                return;

            if (!IsImportedCh8Em4400CommandRegistrationReady(spawnInfo))
                return;

            spawnInfo.hasBackup = false;
            spawnInfo.setupInstance();
            TryNormalizeImportedDlcEnemySpawnState(spawnInfo);
            TryWarpImportedDlcEnemyToSpawnInfo(spawnInfo);
            TryBridgeImportedCh8Em4400Spawn(spawnInfo);
            spawnInfo.RequestedOperation = EnemyGenerator.Operation.None;
            if (spawnInfoAddress != 0)
            {
                completedImportedDlcEnemySetups.Add(spawnInfoAddress);
            }

            logger.Log(
                $"Completed imported DLC enemy setup for '{spawnInfo.UnitAlias}'.",
                isVerbose: true);
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to complete imported DLC enemy setup: {ex.Message}");
        }
        finally
        {
            isCompletingImportedDlcEnemySetup = false;
        }
    }

    [MethodHook(typeof(EnemySpawnInfo), nameof(EnemySpawnInfo.setupInstance), MethodHookType.Pre)]
    private static PreHookResult EnemySpawnInfo_setupInstance_Pre(Span<ulong> args)
    {
        var spawnInfoObject = ManagedObject.ToManagedObject(args[1]);
        pendingDlcSetupInfo = CastObject<EnemySpawnInfo>(spawnInfoObject);
        TryPrepareImportedDlcEnemyRuntime(spawnInfoObject);
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemySpawnInfo), nameof(EnemySpawnInfo.setupInstance), MethodHookType.Post)]
    private static void EnemySpawnInfo_setupInstance_Post(ref ulong retval)
    {
        var spawnInfo = pendingDlcSetupInfo;
        pendingDlcSetupInfo = null;
        if (spawnInfo != null && IsImportedDlcEnemySpawnInfo(spawnInfo) && IsNonDlcChapterActive())
        {
            TryNormalizeImportedDlcEnemySpawnState(spawnInfo);
            TryWarpImportedDlcEnemyToSpawnInfo(spawnInfo);
        }

        TryBridgeImportedCh8Em4400Spawn(spawnInfo);
    }

    [MethodHook(typeof(EnemySpawnInfo), nameof(EnemySpawnInfo.spawnInstance), MethodHookType.Pre)]
    private static PreHookResult EnemySpawnInfo_spawnInstance_Pre(Span<ulong> args)
    {
        var spawnInfoObject = ManagedObject.ToManagedObject(args[1]);
        pendingDlcSpawnInfo = CastObject<EnemySpawnInfo>(spawnInfoObject);
        TryPrepareImportedDlcEnemyRuntime(spawnInfoObject);
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemySpawnInfo), nameof(EnemySpawnInfo.spawnInstance), MethodHookType.Post)]
    private static void EnemySpawnInfo_spawnInstance_Post(ref ulong retval)
    {
        var spawnInfo = pendingDlcSpawnInfo;
        pendingDlcSpawnInfo = null;
        TryCompleteImportedDlcEnemySetup(spawnInfo);
    }

    [MethodHook(typeof(EnemyGeneratorManager), nameof(EnemyGeneratorManager.addGenerator), MethodHookType.Pre)]
    private static PreHookResult EnemyGeneratorManager_addGenerator_Pre(Span<ulong> args)
    {
        TryPrepareImportedDlcEnemyGenerator(ManagedObject.ToManagedObject(args[2]));
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemyGeneratorManager), nameof(EnemyGeneratorManager.doUpdate), MethodHookType.Pre)]
    private static PreHookResult EnemyGeneratorManager_doUpdate_Pre(Span<ulong> args)
    {
        if (ShouldRunImportedDlcEnemyRuntimeScan())
        {
            TryPrepareImportedDlcEnemyGenerators(ManagedObject.ToManagedObject(args[1]), tickInstances: false);
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemyGeneratorManager), nameof(EnemyGeneratorManager.requestOperation), MethodHookType.Pre)]
    private static PreHookResult EnemyGeneratorManager_requestOperation_Pre(Span<ulong> args)
    {
        TryPrepareImportedDlcEnemyRuntime(
            ManagedObject.ToManagedObject(args[2]),
            ManagedObject.ToManagedObject(args[1]));
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemyGeneratorManager), nameof(EnemyGeneratorManager.requestSpawn), MethodHookType.Pre)]
    private static PreHookResult EnemyGeneratorManager_requestSpawn_Pre(Span<ulong> args)
    {
        TryPrepareImportedDlcEnemyRuntime(
            ManagedObject.ToManagedObject(args[2]),
            ManagedObject.ToManagedObject(args[1]));
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(CH8EnemySpawnInfo), nameof(CH8EnemySpawnInfo.requestOperationWithNeedArea), MethodHookType.Pre)]
    private static PreHookResult CH8EnemySpawnInfo_requestOperationWithNeedArea_Pre(Span<ulong> args)
    {
        var spawnInfoObject = ManagedObject.ToManagedObject(args[1]);
        if (IsImportedDlcEnemySpawnInfo(spawnInfoObject) && IsNonDlcChapterActive())
        {
            ClearImportedCh8NeedAreaRequests(spawnInfoObject);
        }

        return PreHookResult.Continue;
    }

    #endregion DLC Enemy Spawns

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
        => GetRuntimeTypeName(managedObject);

    private static string? GetRuntimeTypeName(object? obj)
    {
        var runtimeType = (obj as IObject)?.GetTypeDefinition()?.GetRuntimeType();
        return runtimeType?.Call("get_FullName") as string
            ?? runtimeType?.Call("get_Name") as string;
    }

    private static T? CastObject<T>(object? obj) where T : class
    {
        var objectValue = obj as IObject;
        if (objectValue == null)
            return null;

        var targetType = GetProxyTypeDefinition<T>();
        if (targetType == null || !IsCompatibleProxyType(objectValue, targetType))
            return null;

        return objectValue.As<T>();
    }

    private static TypeDefinition? GetProxyTypeDefinition<T>() where T : class
    {
        try
        {
            return typeof(T)
                .GetField("REFType", global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.Static)
                ?.GetValue(null) as TypeDefinition;
        }
        catch
        {
            return null;
        }
    }

    private static bool IsCompatibleProxyType(IObject objectValue, TypeDefinition targetType)
    {
        try
        {
            var targetTypeName = targetType.GetFullName();
            if (IsKnownInterfaceProxyCompatible(objectValue, targetTypeName))
                return true;

            for (var currentType = objectValue.GetTypeDefinition(); currentType != null; currentType = currentType.ParentType)
            {
                if (currentType.GetFullName() == targetTypeName)
                    return true;
            }
        }
        catch
        {
        }

        return false;
    }

    private static bool IsKnownInterfaceProxyCompatible(IObject objectValue, string targetTypeName)
    {
        var compatibleBaseTypeName = targetTypeName switch
        {
            "app.IEnemyStatus" => "app.EnemyStatus",
            "app.ICharacterStatus" => "app.CharacterCommonStatus",
            "app.IPlayerStatus" => "app.PlayerStatus",
            _ => null,
        };
        if (compatibleBaseTypeName == null)
            return false;

        for (var currentType = objectValue.GetTypeDefinition(); currentType != null; currentType = currentType.ParentType)
        {
            if (currentType.GetFullName() == compatibleBaseTypeName)
                return true;
        }

        return false;
    }

    private static ulong GetObjectAddress(object? obj)
        => (obj as IObject)?.GetAddress() ?? 0;

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

        if (ShouldRunImportedDlcEnemyRuntimeScan())
        {
            TryPrepareImportedDlcEnemyGenerators();
        }

        if (ImGui.TreeNode("BioRand 7"))
        {
            ImGui.TreePop();
        }
    }

    #endregion UI
}
