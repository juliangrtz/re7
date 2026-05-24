using app;
using Hexa.NET.ImGui;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;
using System.Diagnostics;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

public partial class REFPlugin {
    private static bool IsEm3300ExplosionEnabled()
        => Config.ReadOrDefault(RandomEnemiesConfigKey, true)
           && Config.ReadOrDefault("enemy-evelineelderly-explosive-behavior", true);

    private static double ElapsedSeconds(long startTimestamp, long endTimestamp)
        => (endTimestamp - startTimestamp) / (double)Stopwatch.Frequency;

    private static Random CreateEm3300ExplosionRandom(ulong enemyObjectAddress) {
        ulong hash = (uint)Config.ReadOrDefault(PluginSeedConfigKey, 0);
        hash = (hash * 16777619UL) ^ 0x456D33333030UL;
        hash = (hash * 16777619UL) ^ enemyObjectAddress;
        var seed = unchecked((int)(hash ^ (hash >> 32)));
        return new Random(seed);
    }

    private static double CreateEm3300ExplosionDelay(ulong enemyObjectAddress) {
        var rng = CreateEm3300ExplosionRandom(enemyObjectAddress);
        return Em3300ExplosionMinDelaySeconds
               + (rng.NextDouble() * (Em3300ExplosionMaxDelaySeconds - Em3300ExplosionMinDelaySeconds));
    }

    private static bool IsValidGameObject(via.GameObject? gameObject) {
        if (gameObject == null)
            return false;

        try {
            return gameObject.Valid;
        }
        catch {
            return false;
        }
    }

    private static via.GameObject? GetEm3300GameObject(app.fsm.EnemyThinkAction? action, via.fsm.ActionArg? actionArg) {
        var gameObject = action?.gameObj;
        if (IsValidGameObject(gameObject))
            return gameObject;

        gameObject = actionArg?.OwnerGameObject;
        return IsValidGameObject(gameObject) ? gameObject : null;
    }

    private static bool IsEm3300ThinkAction(app.fsm.EnemyThinkAction? action) {
        if (action == null)
            return false;

        try {
            return action.enemyID == EnemyID.Em3300;
        }
        catch {
            return false;
        }
    }

    private static bool HasEm3300ExplosionMarker(via.GameObject gameObject) {
        try {
            if (string.Equals(gameObject.Tag, Em3300ExplosionMarkerTag, StringComparison.Ordinal))
                return true;
        }
        catch { }

        try {
            return string.Equals(gameObject.Name, "Em3300_Static", StringComparison.OrdinalIgnoreCase);
        }
        catch {
            return false;
        }
    }

    private static bool IsEm3300GameObject(via.GameObject? gameObject) {
        if (!IsValidGameObject(gameObject))
            return false;

        if (!HasEm3300ExplosionMarker(gameObject!))
            return false;

        try {
            var name = gameObject!.Name;
            if (string.Equals(name, "Em3300", StringComparison.OrdinalIgnoreCase)
                || name.StartsWith("Em3300_", StringComparison.OrdinalIgnoreCase)) {
                return true;
            }
        }
        catch { }

        try {
            if (ObjectManager.getEnemyID(gameObject!) == EnemyID.Em3300)
                return true;
        }
        catch { }

        return false;
    }

    private static void UpdateEm3300ExplosionsInGroup(
        REFrameworkNET.Collections.IList<via.GameObject>? objects,
        HashSet<ulong> activeEm3300Objects) {
        if (objects == null)
            return;

        for (var i = 0; i < objects.Count; i++) {
            var gameObject = objects[i];
            if (IsEm3300GameObject(gameObject)) {
                activeEm3300Objects.Add(gameObject!.Address());
                UpdateEm3300Explosion(gameObject!);
            }
        }
    }

    private static REFrameworkNET.Collections.IList<REFrameworkNET.Collections.IList<via.GameObject>>?
        GetManagedObjects(ObjectManager? objectManager) {
        if (objectManager == null)
            return null;

        try {
            return objectManager.ManagedObjects;
        }
        catch {
            return null;
        }
    }

    private static void PruneEm3300ExplosionStates(HashSet<ulong> activeEm3300Objects) {
        lock (Em3300ExplosionStateLock) {
            var staleObjects = new List<ulong>();
            foreach (var enemyObjectAddress in Em3300ExplosionStates.Keys) {
                if (!activeEm3300Objects.Contains(enemyObjectAddress))
                    staleObjects.Add(enemyObjectAddress);
            }

            foreach (var enemyObjectAddress in staleObjects) {
                Em3300ExplosionStates.Remove(enemyObjectAddress);
            }
        }
    }

    private static bool IsPlayerNearEm3300(via.GameObject enemyObject) {
        var enemyTransform = enemyObject.Transform;
        if (enemyTransform == null || !TryGetPlayerPosition(out var playerPosition))
            return false;

        var delta = SubtractVec3(playerPosition, enemyTransform.Position);
        var distanceSq = (delta.x * delta.x) + (delta.y * delta.y) + (delta.z * delta.z);
        return distanceSq <= Em3300ExplosionProximityDistance * Em3300ExplosionProximityDistance;
    }

    private static T? TryGetComponent<T>(via.GameObject? gameObject, TypeDefinition typeDefinition)
        where T : class {
        if (!IsValidGameObject(gameObject))
            return null;

        try {
            var runtimeType = typeDefinition.GetRuntimeType().As<_System.Type>();
            return runtimeType == null
                ? null
                : gameObject!.getComponent(runtimeType)?.Cast<T>();
        }
        catch {
            return null;
        }
    }

    private static ShellManager? TryGetShellManager(via.GameObject? playerObject) {
        var shellManager = TryGetComponent<ShellManager>(playerObject, ShellManager.REFType);
        if (shellManager != null)
            return shellManager;

        try {
            shellManager = API.GetManagedSingleton("app.ShellManager")?.As<ShellManager>();
            if (shellManager != null)
                return shellManager;
        }
        catch { }

        try {
            var objectManager = API.GetManagedSingleton("app.ObjectManager")?.As<ObjectManager>();
            var shellManagerObject = objectManager?.findObject("ShellManager") ??
                                     ObjectManager.findObjectInCurrentScene("ShellManager");
            return TryGetComponent<ShellManager>(shellManagerObject, ShellManager.REFType);
        }
        catch {
            return null;
        }
    }

    private static via.GameObject? GetPlayerGameObject() {
        try {
            var objectManager = API.GetManagedSingleton("app.ObjectManager")?.As<ObjectManager>();
            var player = objectManager?.PlayerObj ?? objectManager?.findActivePlayer();
            if (IsValidGameObject(player))
                return player;
        }
        catch { }

        try {
            var player = GameManager.getPlayer();
            return IsValidGameObject(player) ? player : null;
        }
        catch {
            return null;
        }
    }

    private static bool TryRequestEm3300BombExplosion(via.GameObject enemyObject) {
        try {
            var playerObject = GetPlayerGameObject();
            var shellManager = TryGetShellManager(playerObject);
            var enemyTransform = enemyObject.Transform;
            if (shellManager == null || playerObject == null || enemyTransform == null) {
                Logger.Log(
                    "Unable to create Em3300 bomb explosion because the player, ShellManager, or enemy transform was unavailable.",
                    isVerbose: true);
                return false;
            }

            var bomb = shellManager.createBomb(playerObject, enemyTransform, via.vec3.Zero, via.Quaternion.Identity);
            if (bomb == null) {
                Logger.Log("ShellManager returned no bomb for Em3300 explosion.", isVerbose: true);
                return false;
            }

            bomb.requestExplosion();
            return true;
        }
        catch (Exception ex) {
            Logger.Log($"Unable to create Em3300 bomb explosion: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            return false;
        }
    }

    private static bool TryRequestEm3300ExplosionEffect(via.GameObject enemyObject) {
        try {
            var objectEffectManager = TryGetComponent<ObjectEffectManager>(enemyObject, ObjectEffectManager.REFType);
            var enemyTransform = enemyObject.Transform;
            if (objectEffectManager == null || enemyTransform == null)
                return false;

            objectEffectManager.requestEffect(
                Em4200Effect.IDHolder.Explosion,
                enemyTransform.Position,
                via.Quaternion.Identity,
                enemyObject,
                string.Empty);
            return true;
        }
        catch (Exception ex) {
            Logger.Log($"Unable to request Em3300 fallback explosion effect: {ex.GetType().Name}: {ex.Message}",
                isVerbose: true);
            return false;
        }
    }

    private static void DetonateEm3300(via.GameObject enemyObject) {
        if (!TryRequestEm3300BombExplosion(enemyObject)) {
            var result = TryRequestEm3300ExplosionEffect(enemyObject);
            if (!result) {
                Logger.Log($"Unable to request Em3300 explosion effect for object 0x{enemyObject.Address():X}.",
                    isVerbose: true);
            }
        }

        Logger.Log($"Triggered Em3300 explosion for object 0x{enemyObject.Address():X}.", isVerbose: true);
    }

    private static void DespawnEm3300(via.GameObject enemyObject) {
        try {
            Util.setActive(enemyObject, false, false);
        }
        catch (Exception ex) {
            Logger.Log(
                $"Unable to deactivate Em3300 object 0x{enemyObject.Address():X}: {ex.GetType().Name}: {ex.Message}",
                isVerbose: true);
        }

        try {
            via.GameObject.destroy(enemyObject);
            Logger.Log($"Despawned Em3300 object 0x{enemyObject.Address():X} after explosion.", isVerbose: true);
        }
        catch (Exception ex) {
            Logger.Log(
                $"Unable to destroy Em3300 object 0x{enemyObject.Address():X}: {ex.GetType().Name}: {ex.Message}",
                isVerbose: true);
        }
    }

    private static bool UpdateEm3300Explosion(via.GameObject enemyObject) {
        var now = Stopwatch.GetTimestamp();
        var enemyObjectAddress = enemyObject.Address();
        var shouldDetonate = false;
        var shouldDespawn = false;
        var skipOriginalUpdate = false;

        lock (Em3300ExplosionStateLock) {
            if (!Em3300ExplosionStates.TryGetValue(enemyObjectAddress, out var state)) {
                state = new Em3300ExplosionState();
                Em3300ExplosionStates[enemyObjectAddress] = state;
            }

            if (state.Despawned) {
                return true;
            }

            if (state.Exploded) {
                skipOriginalUpdate = true;
                if (ElapsedSeconds(state.ExplodedAt, now) >= Em3300DespawnDelaySeconds) {
                    state.Despawned = true;
                    shouldDespawn = true;
                }
            } else if (!state.CountdownStarted) {
                if (IsPlayerNearEm3300(enemyObject)) {
                    state.CountdownStarted = true;
                    state.CountdownStartedAt = now;
                    state.DelaySeconds = CreateEm3300ExplosionDelay(enemyObjectAddress);
                    Logger.Log(
                        $"Started Em3300 explosion countdown for object 0x{enemyObjectAddress:X}; delay {state.DelaySeconds:0.###}s.",
                        isVerbose: true);
                }
            } else if (ElapsedSeconds(state.CountdownStartedAt, now) >= state.DelaySeconds) {
                state.Exploded = true;
                state.ExplodedAt = now;
                shouldDetonate = true;
                skipOriginalUpdate = true;
            }
        }

        if (shouldDetonate) {
            DetonateEm3300(enemyObject);
        }

        if (shouldDespawn) {
            DespawnEm3300(enemyObject);
        }

        return skipOriginalUpdate || shouldDespawn;
    }

    private static void UpdateEm3300Explosions(ObjectManager? objectManager) {
        if (!IsEm3300ExplosionEnabled())
            return;

        var managedObjects = GetManagedObjects(objectManager);
        if (managedObjects == null)
            return;

        var activeEm3300Objects = new HashSet<ulong>();
        for (var groupIndex = 0; groupIndex < managedObjects.Count; groupIndex++) {
            UpdateEm3300ExplosionsInGroup(managedObjects[groupIndex], activeEm3300Objects);
        }

        PruneEm3300ExplosionStates(activeEm3300Objects);
    }

    [Callback(typeof(UpdateBehavior), CallbackType.Post)]
    public static void UpdateBehavior_Post() {
        if (!_isInitialized)
            return;

        try {
            var objectManager = API.GetManagedSingleton("app.ObjectManager")?.As<ObjectManager>();
            UpdateEm3300Explosions(objectManager);
            UpdateRandomEvents(objectManager);
        }
        catch (Exception ex) {
            Logger.Log($"Unable to update runtime features: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
        }
    }

    [MethodHook(typeof(app.fsm.EnemyThinkAction), nameof(app.fsm.EnemyThinkAction.start), MethodHookType.Pre)]
    private static PreHookResult EnemyThinkAction_start_Pre(Span<ulong> args) {
        if (!IsEm3300ExplosionEnabled())
            return PreHookResult.Continue;

        var action = ManagedObject.ToManagedObject(args[1])?.As<app.fsm.EnemyThinkAction>();
        if (!IsEm3300ThinkAction(action))
            return PreHookResult.Continue;

        var actionArg = args.Length > 2
            ? ManagedObject.ToManagedObject(args[2])?.As<via.fsm.ActionArg>()
            : null;
        var enemyObject = GetEm3300GameObject(action, actionArg);
        if (enemyObject != null && IsEm3300GameObject(enemyObject)) {
            lock (Em3300ExplosionStateLock) {
                if (Em3300ExplosionStates.TryGetValue(enemyObject.Address(), out var state) && state.Despawned)
                    Em3300ExplosionStates.Remove(enemyObject.Address());
            }
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(app.fsm.EnemyThinkAction), nameof(app.fsm.EnemyThinkAction.update), MethodHookType.Pre)]
    private static PreHookResult EnemyThinkAction_update_Pre(Span<ulong> args) {
        if (!IsEm3300ExplosionEnabled())
            return PreHookResult.Continue;

        var action = ManagedObject.ToManagedObject(args[1])?.As<app.fsm.EnemyThinkAction>();
        if (!IsEm3300ThinkAction(action))
            return PreHookResult.Continue;

        var actionArg = args.Length > 2
            ? ManagedObject.ToManagedObject(args[2])?.As<via.fsm.ActionArg>()
            : null;
        var enemyObject = GetEm3300GameObject(action, actionArg);
        if (enemyObject == null || !IsEm3300GameObject(enemyObject))
            return PreHookResult.Continue;

        return UpdateEm3300Explosion(enemyObject)
            ? PreHookResult.Skip
            : PreHookResult.Continue;
    }
}