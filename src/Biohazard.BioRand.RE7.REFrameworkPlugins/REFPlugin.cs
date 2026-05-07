namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

using app;
using app.Command;
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
    private static readonly HashSet<ulong> preparedDlcEnemyRuntimeObjects = [];
    private static readonly HashSet<ulong> completedImportedDlcEnemySetups = [];
    private static readonly HashSet<ulong> initializedCh8Em4400CommandActions = [];
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
        initializedCh8Em4400CommandActions.Clear();
        globalizedDlcCommandActions.Clear();
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

    private static void TryNormalizeImportedDlcEnemySpawnState(EnemySpawnInfo spawnInfo)
    {
        try
        {
            spawnInfo.IsSpawned = true;
            spawnInfo.IsAppeared = true;
            spawnInfo.IsAlive = true;
            spawnInfo.IsCompleted = false;
            spawnInfo.isCompletedOperation = false;

            var action = CastObject<EnemyActionController>(spawnInfo.EnemyActionController);
            if (action != null)
            {
                action.hasDie = false;
                action.isFinishedDead = false;
                action.calledFinishedDead = false;
                action.isMarkedDeadStats = false;
                try { action.forgetDie(); } catch { }
                try { action.recoveryAll(); } catch { }
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

        var action = CastObject<CH8Em4400ActionController>(spawnInfo.EnemyActionController);
        if (action == null)
            return;

        try
        {
            ForceDoomsRuntimeActive(action);

            action.myStatus ??= CastObject<CH8Em4400Status>(action.enemyStatus);
            action.myThink ??=
                CastObject<CH8Em4400Think>(action.enemyThink) ??
                GetComponent<CH8Em4400Think>(spawnInfo.EnemyInstance, CH8Em4400Think.REFType);

            action.playerStatus ??= GetPlayerStatus();

            if (action.myThink != null)
            {
                TryBridgeImportedCh8Em4400Think(action.myThink, action);
            }

            TryEnsureCh8Em4400CommandActions(spawnInfo, action);

            if (action.myUpdateController == null)
            {
                var updateController = GetOrCreateComponent<CH8EnemyUpdateController>(
                    spawnInfo.EnemyInstance,
                    CH8EnemyUpdateController.REFType);
                if (updateController != null)
                {
                    ForceDoomsRuntimeActive(updateController);
                    try { updateController.addTargetComponentList(action); } catch { }
                    try { updateController.doAwake(); } catch { }
                    try { updateController.doStart(); } catch { }
                    action.myUpdateController = updateController;
                }
            }

            action.isStarted = true;
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to bridge imported CH8 Em4400 runtime: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryBridgeImportedCh8Em4400Think(CH8Em4400Think think, CH8Em4400ActionController action)
    {
        try
        {
            ForceDoomsRuntimeActive(think);

            think.myActionController ??= action;
            think.myStatus ??= action.myStatus ?? CastObject<CH8Em4400Status>(action.enemyStatus);

            if (think.status == null)
            {
                think.status = CastObject<IEnemyStatus>(action.enemyStatus);
            }

            var playerObject = GetPlayerObject();
            var playerStatus = GetPlayerStatus();
            if (playerStatus is IObject playerStatusObject)
            {
                think.playerStatus ??= playerStatusObject.As<IPlayerStatus>();
                think.targetStatus ??= playerStatusObject.As<ICharacterStatus>();
            }

            if (think.Target == null && playerObject != null)
            {
                think.setTarget(playerObject, EnemyThinkBase.ReasonType.Outer);
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

    private static void TryEnsureCh8Em4400CommandActions(
        EnemySpawnInfo spawnInfo,
        CH8Em4400ActionController action)
    {
        try
        {
            if (spawnInfo.EnemyInstance == null)
                return;

            var actionAddress = GetObjectAddress(action);
            var commandController = action.myCommandActionController
                ?? GetComponent<CH8CommandActionController>(spawnInfo.EnemyInstance, CH8CommandActionController.REFType);
            if (commandController == null)
                return;

            action.myCommandActionController = commandController;
            ForceDoomsRuntimeActive(commandController);
            ForceDoomsRuntimeActive(commandController.Commander);
            ForceDoomsRuntimeActive(commandController.Requester);
            ForceDoomsRuntimeActive(action.myBasicAnimController);
            ForceDoomsRuntimeActive(action.mySmoothAnim);
            ForceDoomsRuntimeActive(action.myMotionManager);

            if (actionAddress != 0 && initializedCh8Em4400CommandActions.Contains(actionAddress))
            {
                TryAdvanceCh8Em4400CommandController(action, commandController);
                return;
            }

            InitializeCh8CommandController(spawnInfo.EnemyInstance, action, commandController);

            if (action.myBasicAnimController != null)
            {
                try { CH8Em4400ActionTag.registerToBasicAnimationController(action.myBasicAnimController); } catch { }
            }

            if (action.myCommandRequester == null && commandController.Requester != null)
            {
                action.myCommandRequester = commandController.Requester;
            }

            var actionList = commandController.ActionList;
            if (actionList == null)
                return;

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

                        InitializeCh8CommandAction(spawnInfo.EnemyInstance, action, commandController, commandAction);
                        TrySetupCh8Em4400CommandAction(instance, spawnInfo.EnemyInstance, action, commandController);
                        InitializeCh8CommandAction(spawnInfo.EnemyInstance, action, commandController, commandAction);
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

            InitializeRegisteredCh8CommandActions(spawnInfo.EnemyInstance, action, commandController);
            commandController.IdleAction = commandController.findIdleAction()
                ?? FindCommandActionById(commandController.ActionList, 0);

            if (!commandController.isStarted)
            {
                commandController.doAwake();
                InitializeCh8CommandController(spawnInfo.EnemyInstance, action, commandController);
                InitializeRegisteredCh8CommandActions(spawnInfo.EnemyInstance, action, commandController);
                commandController.IdleAction = commandController.findIdleAction()
                    ?? FindCommandActionById(commandController.ActionList, 0);

                commandController.doStart();
                InitializeCh8CommandController(spawnInfo.EnemyInstance, action, commandController);
                InitializeRegisteredCh8CommandActions(spawnInfo.EnemyInstance, action, commandController);
                commandController.IdleAction = commandController.findIdleAction()
                    ?? FindCommandActionById(commandController.ActionList, 0);

                commandController.isStarted = true;
            }

            TryRequestCh8Em4400IdleAnimation(action, commandController);
            TryAdvanceCh8Em4400CommandController(action, commandController);
            if (actionAddress != 0)
            {
                initializedCh8Em4400CommandActions.Add(actionAddress);
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to initialize imported CH8 Em4400 command actions: {ex.Message}", isVerbose: true);
        }
    }

    private static void TryAdvanceCh8Em4400CommandController(
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        try
        {
            if (commandController.CurrentAction == null && commandController.IdleAction != null)
            {
                commandController.doUpdate();
                action.mySmoothAnim?.update();
                action.myMotionManager?.update();
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to advance imported CH8 Em4400 command controller: {ex.Message}", isVerbose: true);
        }
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
        var status = action.myStatus;
        var think = action.myThink;

        var ch8Base = commandActionObject.As<app.CH8Em4400.Action.CH8Base>();
        if (ch8Base != null)
        {
            ch8Base.myActionController = action;
            ch8Base.myStatus = status;
            if (think != null)
            {
                ch8Base.myThink = think;
            }
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
            return;
        }

        var dead = commandActionObject.As<app.CH8Em4400.Action.CH8Dead>();
        if (dead != null)
        {
            dead.myActionController = action;
            dead.myStatus = status;
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
            ?? action.myMotionManager
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
        command.Owner = owner;
        command.MotionMgr = commandController.MotionManager ?? action.myMotionManager;
        command.MotionFsm = command.MotionMgr?.MotionFsm;
        command.Commander = commandController.Commander;
        command.BasicAnimController = action.myBasicAnimController;
        command.SmoothAnim = action.mySmoothAnim;
        command.ActionController = commandController;

        if (action.myStatus is IObject statusObject)
        {
            command.Status = statusObject.As<ICharacterStatus>();
            commandAction.EmStatus = statusObject.As<IEnemyStatus>();
        }

        commandAction.enemyActionController = action;
        if (action.myThink != null)
        {
            commandAction.enemyThink = action.myThink;
        }

        if (action.myMotion != null)
        {
            commandAction.motion = action.myMotion;
        }
    }

    private static void TryRequestCh8Em4400IdleAnimation(
        CH8Em4400ActionController action,
        CommandActionController commandController)
    {
        var motionEndFrame = action.myMotionManager?.getMotionEndFrame(0) ?? 0;
        if (motionEndFrame > 0)
            return;

        var bac = action.myBasicAnimController;
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
        bac.update();
        action.mySmoothAnim?.update();
        action.myMotionManager?.update();
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
        var runtimeType = typeDefinition.GetRuntimeType().As<_System.Type>();
        return runtimeType == null
            ? null
            : CastObject<T>(gameObject?.getComponent(runtimeType));
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

    private static bool TryPrepareImportedDlcEnemyGenerator(object? generatorObject)
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

        if (!isImportedGenerator && !hasDlcSpawnInfo)
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

    private static void TryPrepareImportedDlcEnemyGenerators(object? managerObject)
    {
        if (!IsNonDlcChapterActive())
            return;

        var generators = (managerObject as IObject)?.GetField("generators");
        var count = GetObjectListCount(generators);
        for (var index = 0; index < count; index++)
        {
            TryPrepareImportedDlcEnemyGenerator(GetObjectListItem(generators, index));
        }
    }

    private static void TryPrepareImportedDlcEnemyGenerators()
        => TryPrepareImportedDlcEnemyGenerators(API.GetManagedSingleton("app.EnemyGeneratorManager"));

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
        TryPrepareImportedDlcEnemyGenerators(ManagedObject.ToManagedObject(args[1]));
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
        => (obj as IObject)?.As<T>();

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

        TryPrepareImportedDlcEnemyGenerators();

        if (ImGui.TreeNode("BioRand 7"))
        {
            ImGui.TreePop();
        }
    }

    #endregion UI
}
