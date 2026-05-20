using app;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

// ReSharper disable once UnusedType.Global
public partial class REFPlugin {
    private const string PluginSeedConfigKey = "biorand-seed";
    private const string MadhouseNormalSavesConfigKey = "madhouse-normal-saves";
    private const double DefaultEnemyDropMultiplier = 1.0;
    private const double EasyAmmoDropAmountFactor = 1.5;
    private const double NormalAmmoDropAmountFactor = 1.0;
    private const double MadhouseAmmoDropAmountFactor = 0.75;
    private const double ValuableDropChanceWeight = 3.0;
    private const double ValuableWeaponDropChanceWeight = 1.0;
    private const double DefaultEnemyDropProbability = 0.5;
    private const string RandomEnemiesConfigKey = "random-enemies";
    private const float Em3300ExplosionProximityDistance = 5.0f;
    private const double Em3300ExplosionMinDelaySeconds = 3.0;
    private const double Em3300ExplosionMaxDelaySeconds = 8.0;
    private const double Em3300DespawnDelaySeconds = 0.25;
    private const string Em3300ExplosionMarkerTag = "BioRandExplosiveEm3300";
    private const float EnemyDropGroundRayStartOffset = 0.25f;
    private const float EnemyDropGroundRayDistance = 50.0f;
    private const float EnemyDropGroundMinNormalY = 0.5f;
    private const float EnemyDropWallProbeDistance = 0.75f;
    private static readonly float[] EnemyDropWallClearanceDistances = [0.6f, 0.9f, 1.2f];

    private static bool _isInitialized;
    private static readonly Configuration Config = new();
    private static readonly Logger Logger = new(Config);
    private static readonly Lock WeaponReloadSpeedCacheLock = new();
    private static readonly Lock WeaponReloadSpeedLogLock = new();
    private static readonly Dictionary<WeaponID, double?> WeaponReloadSpeedMultiplierCache = [];
    private static readonly Lock EnemyDropStateLock = new();
    private static readonly HashSet<ulong> DroppedEnemyObjects = [];
    private static readonly Dictionary<ulong, int> EnemyDropGenerations = [];
    private static readonly Lock Em3300ExplosionStateLock = new();
    private static readonly Dictionary<ulong, Em3300ExplosionState> Em3300ExplosionStates = [];
    private static WeaponID? _lastLoggedWeaponReloadSpeedWeapon;
    private static int? _lastLoggedWeaponReloadSpeedDepressantLevel;
    private static float? _lastLoggedWeaponReloadSpeedRate;

    [ThreadStatic] private static PlayerMotionController? _pendingReloadSpeedController;
    private static MenuHandle? _pendingMadhouseSaveSelectItemMenu;

    [PluginEntryPoint]
    public static void Main() => Initialize();

    private static void Initialize() {
        ImGuiRender.Post += OnImGuiRender;
        ImGuiDrawUI.Post += OnImGuiDrawUi;
        _isInitialized = true;
        Logger.Log("Loaded.");
        if (Config.LoadError != null) {
            Logger.Log($"Failed to load configuration '{Config.ConfigPath}': {Config.LoadError}. Using defaults.");
        } else if (!Config.HasConfigFile) {
            Logger.Log($"Configuration file not found at '{Config.ConfigPath}'. Using defaults.");
        }

        Logger.Log($"Configuration has {Config.Entries} entries.");
    }

    [PluginExitPoint]
    public static void OnUnload() {
        _isInitialized = false;
        _pendingReloadSpeedController = null;
        pendingInfiniteAmmoGun = null;
        pendingInfiniteAmmoActive = false;
        _pendingMadhouseSaveSelectItemMenu = null;
        lock (WeaponReloadSpeedCacheLock) {
            WeaponReloadSpeedMultiplierCache.Clear();
        }

        lock (WeaponReloadSpeedLogLock) {
            _lastLoggedWeaponReloadSpeedWeapon = null;
            _lastLoggedWeaponReloadSpeedDepressantLevel = null;
            _lastLoggedWeaponReloadSpeedRate = null;
        }

        lock (EnemyDropStateLock) {
            DroppedEnemyObjects.Clear();
            EnemyDropGenerations.Clear();
        }

        lock (Em3300ExplosionStateLock) {
            Em3300ExplosionStates.Clear();
        }

        ClearRandomEventState(restore: true);
        Logger.Log("Unloaded.");
    }
}
