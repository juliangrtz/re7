
using app;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;
public partial class REFPlugin
{
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

    private static bool IsInitialized = false;
    private static readonly Configuration config = new();
    private static readonly Logger logger = new(config);
    private static readonly Lock weaponReloadSpeedCacheLock = new();
    private static readonly Lock weaponReloadSpeedLogLock = new();
    private static readonly Dictionary<WeaponID, double?> weaponReloadSpeedMultiplierCache = [];
    private static readonly Lock enemyDropStateLock = new();
    private static readonly HashSet<ulong> droppedEnemyObjects = [];
    private static readonly Dictionary<ulong, int> enemyDropGenerations = [];
    private static readonly Lock em3300ExplosionStateLock = new();
    private static readonly Dictionary<ulong, Em3300ExplosionState> em3300ExplosionStates = [];
    private static WeaponID? lastLoggedWeaponReloadSpeedWeapon;
    private static int? lastLoggedWeaponReloadSpeedDepressantLevel;
    private static float? lastLoggedWeaponReloadSpeedRate;

    [ThreadStatic]
    private static PlayerMotionController? pendingReloadSpeedController;
    private static MenuHandle? pendingMadhouseSaveSelectItemMenu;

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
        pendingReloadSpeedController = null;
        pendingMadhouseSaveSelectItemMenu = null;
        lock (weaponReloadSpeedCacheLock)
        {
            weaponReloadSpeedMultiplierCache.Clear();
        }
        lock (weaponReloadSpeedLogLock)
        {
            lastLoggedWeaponReloadSpeedWeapon = null;
            lastLoggedWeaponReloadSpeedDepressantLevel = null;
            lastLoggedWeaponReloadSpeedRate = null;
        }
        lock (enemyDropStateLock)
        {
            droppedEnemyObjects.Clear();
            enemyDropGenerations.Clear();
        }
        lock (em3300ExplosionStateLock)
        {
            em3300ExplosionStates.Clear();
        }
        logger.Log("Unloaded.");
    }
}
