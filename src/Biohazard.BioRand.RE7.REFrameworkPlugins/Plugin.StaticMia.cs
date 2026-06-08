using app;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using System.Globalization;
using Em2000ActionController = app.Em2000.Em2000ActionController;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

public partial class REFPlugin {
    private static bool IsBioRandStaticMiaGameObject(via.GameObject? gameObject) {
        if (!IsValidGameObject(gameObject))
            return false;

        try {
            return gameObject!.Name.StartsWith(BioRandStaticMiaNamePrefix, StringComparison.Ordinal);
        }
        catch {
            return false;
        }
    }

    private static via.GameObject? TryGetControllerGameObject(EnemyActionController? controller) {
        if (controller == null)
            return null;

        try {
            var gameObject = controller.GameObject;
            return IsValidGameObject(gameObject) ? gameObject : null;
        }
        catch {
            return null;
        }
    }

    private static EnemyActionController? TryGetEnemyActionController(
        ManagedObject? sourceObject,
        via.GameObject? gameObject) {
        try {
            var controller = sourceObject?.As<EnemyActionController>();
            if (controller != null)
                return controller;
        }
        catch { }

        try {
            var damageController = sourceObject?.As<EnemyDamageController>();
            if (damageController?.enemyActionController != null)
                return damageController.enemyActionController;
        }
        catch { }

        return TryGetComponent<EnemyActionController>(gameObject, EnemyActionController.REFType);
    }

    private static object? TryReadGuid(Func<object?> readGuid) {
        try {
            return readGuid();
        }
        catch {
            return null;
        }
    }

    private static void AddBioRandStaticMiaGuidKey(List<string> keys, string kind, object? guid) {
        var value = guid?.ToString();
        if (string.IsNullOrWhiteSpace(value) ||
            string.Equals(value, Guid.Empty.ToString(), StringComparison.OrdinalIgnoreCase))
            return;

        keys.Add($"guid:{kind}:{value}");
    }

    private static string TryGetGameObjectFolderPath(via.GameObject gameObject) {
        try {
            return gameObject.Folder?.Path ?? string.Empty;
        }
        catch {
            return string.Empty;
        }
    }

    private static string GetBioRandStaticMiaPositionKey(via.GameObject gameObject) {
        var name = string.Empty;
        var folderPath = TryGetGameObjectFolderPath(gameObject);
        var x = 0;
        var y = 0;
        var z = 0;

        try {
            name = gameObject.Name;
        }
        catch { }

        try {
            var position = gameObject.Transform?.Position ?? via.vec3.Zero;
            x = (int)MathF.Round(position.x * BioRandStaticMiaPositionKeyScale);
            y = (int)MathF.Round(position.y * BioRandStaticMiaPositionKeyScale);
            z = (int)MathF.Round(position.z * BioRandStaticMiaPositionKeyScale);
        }
        catch { }

        return string.Create(
            CultureInfo.InvariantCulture,
            $"fallback:{folderPath}:{name}:{x}:{y}:{z}");
    }

    private static List<string> GetBioRandStaticMiaKeys(
        ManagedObject? sourceObject,
        via.GameObject gameObject) {
        var keys = new List<string>(4);
        var controller = TryGetEnemyActionController(sourceObject, gameObject);
        AddBioRandStaticMiaGuidKey(keys, "spawner",
            TryReadGuid(() => controller == null ? null : controller.SpawnerGuid));
        AddBioRandStaticMiaGuidKey(keys, "actual",
            TryReadGuid(() => controller == null ? null : controller.ActualUsingGuid));
        keys.Add(GetBioRandStaticMiaPositionKey(gameObject));
        return keys;
    }

    private static bool IsKilledBioRandStaticMia(ManagedObject? sourceObject, via.GameObject? gameObject) {
        var controller = TryGetEnemyActionController(sourceObject, gameObject);
        gameObject ??= TryGetControllerGameObject(controller);
        if (!IsBioRandStaticMiaGameObject(gameObject))
            return false;

        var keys = GetBioRandStaticMiaKeys(sourceObject, gameObject!);
        lock (BioRandStaticMiaStateLock) {
            return keys.Any(KilledBioRandStaticMiaKeys.Contains);
        }
    }

    private static bool RememberKilledBioRandStaticMia(ManagedObject? sourceObject, via.GameObject? gameObject) {
        var controller = TryGetEnemyActionController(sourceObject, gameObject);
        gameObject ??= TryGetControllerGameObject(controller);
        if (!IsBioRandStaticMiaGameObject(gameObject))
            return false;

        var keys = GetBioRandStaticMiaKeys(sourceObject, gameObject!);
        var added = false;
        lock (BioRandStaticMiaStateLock) {
            foreach (var key in keys) {
                added |= KilledBioRandStaticMiaKeys.Add(key);
            }
        }

        if (added) {
            Logger.Log(
                $"Remembered killed static Mia '{gameObject!.Name}' at object 0x{gameObject.Address():X}.",
                isVerbose: true);
        }

        return true;
    }

    private static bool TrySuppressKilledBioRandStaticMia(ManagedObject? sourceObject, via.GameObject? gameObject) {
        var controller = TryGetEnemyActionController(sourceObject, gameObject);
        gameObject ??= TryGetControllerGameObject(controller);
        if (!IsKilledBioRandStaticMia(sourceObject, gameObject))
            return false;

        try {
            Util.setActive(gameObject!, false, false);
        }
        catch (Exception ex) {
            Logger.Log(
                $"Unable to deactivate killed static Mia object 0x{gameObject?.Address() ?? 0:X}: {ex.GetType().Name}: {ex.Message}",
                isVerbose: true);
        }

        var shouldLog = false;
        lock (BioRandStaticMiaStateLock) {
            if (gameObject != null)
                shouldLog = SuppressedBioRandStaticMiaObjects.Add(gameObject.Address());
        }

        if (shouldLog) {
            Logger.Log(
                $"Suppressed killed static Mia '{gameObject!.Name}' at object 0x{gameObject.Address():X}.",
                isVerbose: true);
        }

        return true;
    }

    [MethodHook(typeof(Em2000ActionController), nameof(Em2000ActionController.reactivate), MethodHookType.Pre)]
    private static PreHookResult Em2000ActionController_reactivate_Pre(Span<ulong> args) {
        var controllerObject = ManagedObject.ToManagedObject(args[1]);
        var controller = controllerObject.As<Em2000ActionController>();
        return TrySuppressKilledBioRandStaticMia(controllerObject, controller?.GameObject)
            ? PreHookResult.Skip
            : PreHookResult.Continue;
    }

    [MethodHook(typeof(Em2000ActionController), nameof(Em2000ActionController.doStart), MethodHookType.Pre)]
    private static PreHookResult Em2000ActionController_doStart_Pre(Span<ulong> args) {
        var controllerObject = ManagedObject.ToManagedObject(args[1]);
        var controller = controllerObject.As<Em2000ActionController>();
        return TrySuppressKilledBioRandStaticMia(controllerObject, controller?.GameObject)
            ? PreHookResult.Skip
            : PreHookResult.Continue;
    }

    [MethodHook(typeof(Em2000ActionController), nameof(Em2000ActionController.doUpdate), MethodHookType.Pre)]
    private static PreHookResult Em2000ActionController_doUpdate_Pre(Span<ulong> args) {
        var controllerObject = ManagedObject.ToManagedObject(args[1]);
        var controller = controllerObject.As<Em2000ActionController>();
        return TrySuppressKilledBioRandStaticMia(controllerObject, controller?.GameObject)
            ? PreHookResult.Skip
            : PreHookResult.Continue;
    }
}
