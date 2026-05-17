
using app;
using REFrameworkNET;
using REFrameworkNET.Attributes;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;
public partial class REFPlugin
{
    private static string GetWeaponReloadSpeedConfigId(WeaponID weaponId)
        => weaponId.ToString().ToLowerInvariant().Replace("_", "-");

    private static string GetWeaponReloadSpeedMultiplierConfigKey(WeaponID weaponId)
        => $"weapon-reload-speed-multiplier-{GetWeaponReloadSpeedConfigId(weaponId)}";

    private static bool TryGetWeaponReloadSpeedMultiplier(WeaponID weaponId, out double multiplier)
    {
        lock (weaponReloadSpeedCacheLock)
        {
            if (weaponReloadSpeedMultiplierCache.TryGetValue(weaponId, out var cachedMultiplier))
            {
                multiplier = cachedMultiplier ?? 1.0;
                return cachedMultiplier.HasValue;
            }
        }

        double? result = null;
        if (config.TryRead(GetWeaponReloadSpeedMultiplierConfigKey(weaponId), out double configuredMultiplier))
        {
            result = configuredMultiplier;
        }

        lock (weaponReloadSpeedCacheLock)
        {
            weaponReloadSpeedMultiplierCache[weaponId] = result;
        }

        multiplier = result ?? 1.0;
        return result.HasValue;
    }

    private static void LogWeaponReloadSpeedRate(WeaponID weaponId, int depressantLevel, float baseRate, double multiplier, float newRate)
    {
        lock (weaponReloadSpeedLogLock)
        {
            if (lastLoggedWeaponReloadSpeedWeapon == weaponId
                && lastLoggedWeaponReloadSpeedDepressantLevel == depressantLevel
                && lastLoggedWeaponReloadSpeedRate == newRate)
            {
                return;
            }

            lastLoggedWeaponReloadSpeedWeapon = weaponId;
            lastLoggedWeaponReloadSpeedDepressantLevel = depressantLevel;
            lastLoggedWeaponReloadSpeedRate = newRate;
        }

        logger.Log(
            $"Applied reload speed for {weaponId} with {depressantLevel} stabilizers: {baseRate:0.###} x {multiplier:0.###} = {newRate:0.###}.",
            isVerbose: true);
    }

    private static void ApplyConfiguredWeaponReloadSpeed(PlayerMotionController controller)
    {
        if (!config.ReadOrDefault("weapon-mod-reload-speed", false))
            return;

        var table = controller.PlayerReloadSpeedRateTable;
        var motionManager = controller.MotionManager;
        if (table == null || motionManager == null)
            return;

        var weaponId = controller.CurrentWeaponID;
        if (!TryGetWeaponReloadSpeedMultiplier(weaponId, out var multiplier))
        {
            var currentWeaponId = controller.CurrentWeapon?.WeaponID ?? weaponId;
            if (currentWeaponId == weaponId || !TryGetWeaponReloadSpeedMultiplier(currentWeaponId, out multiplier))
                return;

            weaponId = currentWeaponId;
        }

        var depressantLevel = Math.Max(0, controller.DepressantLevel);
        if (!config.ReadOrDefault("weapon-mod-reload-speed-include-stabilizers", true)
            && depressantLevel > 0)
        {
            multiplier = 1.0;
        }

        var baseRate = table.getReloadSpeedRate(depressantLevel);
        var newRate = Math.Max(0.1f, (float)Math.Round(baseRate * multiplier, 2));
        controller.ReloadSpeedRate = newRate;
        motionManager.setFloatToMotionVariable(PlayerMotionController.VariableNameHash.fReloadSpeedRate, newRate);
        LogWeaponReloadSpeedRate(weaponId, depressantLevel, baseRate, multiplier, newRate);
    }

    [MethodHook(typeof(PlayerMotionController), nameof(PlayerMotionController.update), MethodHookType.Pre)]
    private static PreHookResult PlayerMotionController_update_Pre(Span<ulong> args)
    {
        pendingReloadSpeedController = null;
        if (config.ReadOrDefault("weapon-mod-reload-speed", false))
        {
            pendingReloadSpeedController = ManagedObject.ToManagedObject(args[1])?.As<PlayerMotionController>();
        }
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(PlayerMotionController), nameof(PlayerMotionController.update), MethodHookType.Post)]
    private static void PlayerMotionController_update_Post(ref ulong _)
    {
        var controller = pendingReloadSpeedController;
        pendingReloadSpeedController = null;

        if (controller == null)
            return;

        ApplyConfiguredWeaponReloadSpeed(controller);
    }
}
