using app;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using System.Diagnostics;
using System.Globalization;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

public partial class REFPlugin
{
    private const double RandomEventDefaultMinIntervalSeconds = 90.0;
    private const double RandomEventDefaultMaxIntervalSeconds = 210.0;
    private const double ExplosiveAmmoMinIntervalSeconds = 0.25;
    private static readonly Lock randomEventStateLock = new();
    private static readonly Dictionary<ulong, PlayerMovementEventState> randomEventMovementStates = [];
    private static readonly Dictionary<ulong, PlayerScaleEventState> randomEventPlayerScaleStates = [];
    private static readonly Dictionary<ulong, PassiveSkillEventState> randomEventPassiveSkillStates = [];
    private static readonly Dictionary<ulong, EnemyRuntimeEventState> randomEventEnemyStates = [];
    private static readonly Dictionary<ulong, long> explosiveAmmoLastShotTimestamps = [];
    private static Random? randomEventRng;
    private static int? randomEventSeed;
    private static long nextRandomEventAt;
    private static RandomEventInstance? activeRandomEvent;
    private static bool activeRandomEventStartedFromUi;
    private static bool randomEventBlindnessFadeRequested;

    [ThreadStatic]
    private static WeaponGun? pendingInfiniteAmmoGun;

    [ThreadStatic]
    private static int pendingInfiniteAmmoLoadNum;

    [ThreadStatic]
    private static bool pendingInfiniteAmmoActive;

    private enum RandomEventKind
    {
        PlayerStatus,
        PlayerBlindness,
        PlayerFreeze,
        PlayerScale,
        WeaponInfiniteAmmo,
        WeaponNeuroAmmo,
        WeaponExplosiveAmmo,
        EnemySpeed,
        EnemyInvisible,
        EnemyWeak,
        EnemyStrong,
        EnemyPaused,
    }

    private readonly record struct RandomEventCandidate(RandomEventKind Kind, double DurationSeconds);

    private readonly record struct PassiveSkillEventDelta(
        string Label,
        float AttackChangeRate,
        float DamageChangeRate,
        float WalkSpeedChangeRate,
        float MoveSpeedChangeRate,
        float DyingMoveSpeedChangeRate,
        float ReloadSpeedChangeRate,
        int BulletStackNumInfinityCount)
    {
        public PassiveSkillEventDelta Negated()
            => this with
            {
                AttackChangeRate = -AttackChangeRate,
                DamageChangeRate = -DamageChangeRate,
                WalkSpeedChangeRate = -WalkSpeedChangeRate,
                MoveSpeedChangeRate = -MoveSpeedChangeRate,
                DyingMoveSpeedChangeRate = -DyingMoveSpeedChangeRate,
                ReloadSpeedChangeRate = -ReloadSpeedChangeRate,
                BulletStackNumInfinityCount = -BulletStackNumInfinityCount
            };
    }

    private static readonly PassiveSkillEventDelta InfiniteAmmoPassiveSkillDelta = new(
        "infinite ammo",
        0,
        0,
        0,
        0,
        0,
        0,
        1);

    private static readonly PassiveSkillEventDelta[] RandomStatusEffectDeltas =
    [
        new("firepower up", 0.35f, 0, 0, 0, 0, 0, 0),
        new("firepower down", -0.30f, 0, 0, 0, 0, 0, 0),
        new("toughness up", 0, -0.25f, 0, 0, 0, 0, 0),
        new("vulnerable", 0, 0.35f, 0, 0, 0, 0, 0),
        new("speed up", 0, 0, 0.35f, 0.35f, 0.35f, 0, 0),
        new("heavy legs", 0, 0, -0.35f, -0.35f, -0.35f, 0, 0),
        new("quick reload", 0, 0, 0, 0, 0, 0.45f, 0),
        new("bottomless pockets", 0, 0, 0, 0, 0, 0, 1),
    ];

    private sealed class RandomEventInstance
    {
        public required RandomEventKind Kind { get; init; }
        public required long StartedAt { get; init; }
        public required long EndsAt { get; init; }
        public required double DurationSeconds { get; init; }
        public PassiveSkillEventDelta StatusDelta { get; init; }
        public float PlayerScaleMultiplier { get; init; } = 1.0f;
        public float EnemySpeedMultiplier { get; init; } = 1.0f;
        public float EnemyHealthMultiplier { get; init; } = 1.0f;
    }

    private sealed class PlayerMovementEventState
    {
        public required PlayerMovement Movement { get; init; }
        public required float ExternalWalkSpeedRate { get; init; }
        public required float ExternalJogSpeedRate { get; init; }
        public required float ExternalDyingWalkSpeedRate { get; init; }
        public required float ExternalDyingJogSpeedRate { get; init; }
        public required float ActionSpeedRate { get; init; }
        public required bool IsForbidTerrainMove { get; init; }
    }

    private sealed class PlayerScaleEventState
    {
        public required via.GameObject PlayerObject { get; init; }
        public required via.vec3 LocalScale { get; init; }
    }

    private sealed class PassiveSkillEventState
    {
        public required PlayerPassiveSkillManager Manager { get; init; }
        public required PassiveSkillEventDelta Delta { get; init; }
    }

    private sealed class EnemyRuntimeEventState
    {
        public required via.GameObject GameObject { get; init; }
        public float? TimeScale { get; set; }
        public bool? DrawSelf { get; set; }
        public EnemyDamageController? DamageController { get; set; }
        public float? DefaultMaxHealth { get; set; }
    }

    private readonly record struct EnemyEventTarget(
        via.GameObject GameObject,
        EnemyActionController Controller,
        EnemyDamageController? DamageController,
        float DistanceSquared);

    private static bool HasRandomEventState()
    {
        lock (randomEventStateLock)
        {
            return HasRandomEventStateLocked();
        }
    }

    private static bool HasRandomEventStateLocked()
        => randomEventRng != null
            || randomEventSeed != null
            || nextRandomEventAt != 0
            || activeRandomEvent != null
            || activeRandomEventStartedFromUi
            || randomEventMovementStates.Count != 0
            || randomEventPlayerScaleStates.Count != 0
            || randomEventPassiveSkillStates.Count != 0
            || randomEventEnemyStates.Count != 0
            || explosiveAmmoLastShotTimestamps.Count != 0
            || randomEventBlindnessFadeRequested;

    private static bool IsRandomEventsEnabled()
        => config.ReadOrDefault("random-events", false);

    private static bool IsRandomEventActive(RandomEventKind kind)
    {
        var now = Stopwatch.GetTimestamp();
        lock (randomEventStateLock)
        {
            return activeRandomEvent?.Kind == kind && now < activeRandomEvent.EndsAt;
        }
    }

    private static long SecondsToTimestampTicks(double seconds)
        => Math.Max(1, (long)Math.Round(Math.Max(0.0, seconds) * Stopwatch.Frequency));

    private static Random CreateRandomEventRandom(int seed)
    {
        ulong hash = (uint)seed;
        hash = (hash * 16777619UL) ^ 0x42696F52616E6437UL;
        hash = (hash * 16777619UL) ^ 0x6576656E7473UL;
        return new Random(unchecked((int)(hash ^ (hash >> 32))));
    }

    private static void EnsureRandomEventRandomLocked()
    {
        var seed = config.ReadOrDefault(PluginSeedConfigKey, 0);
        if (randomEventRng != null && randomEventSeed == seed)
            return;

        randomEventSeed = seed;
        randomEventRng = CreateRandomEventRandom(seed);
        nextRandomEventAt = 0;
        logger.Log($"Initialized random event scheduler with seed {seed}.", isVerbose: true);
    }

    private static Random GetRandomEventRandomLocked()
    {
        EnsureRandomEventRandomLocked();
        return randomEventRng!;
    }

    private static double GetRandomEventIntervalSeconds()
    {
        var min = config.ReadOrDefault("random-events-interval-min", RandomEventDefaultMinIntervalSeconds);
        var max = config.ReadOrDefault("random-events-interval-max", RandomEventDefaultMaxIntervalSeconds);
        if (max < min)
        {
            (min, max) = (max, min);
        }

        min = Math.Clamp(min, 1.0, 3600.0);
        max = Math.Clamp(max, min, 3600.0);
        return min + (GetRandomEventRandomLocked().NextDouble() * (max - min));
    }

    private static void ScheduleNextRandomEventLocked(long now)
    {
        var intervalSeconds = GetRandomEventIntervalSeconds();
        nextRandomEventAt = now + SecondsToTimestampTicks(intervalSeconds);
        logger.Log($"Next random event scheduled in {intervalSeconds:0.###}s.", isVerbose: true);
    }

    private static double GetRandomEventDurationSeconds(RandomEventKind kind)
        => kind switch
        {
            RandomEventKind.PlayerStatus => config.ReadOrDefault("event-player-status-duration", 30.0),
            RandomEventKind.PlayerBlindness => config.ReadOrDefault("event-player-blindness-duration", 4.0),
            RandomEventKind.PlayerFreeze => config.ReadOrDefault("event-player-freeze-duration", 5.0),
            RandomEventKind.PlayerScale => config.ReadOrDefault("event-player-scale-duration", 25.0),
            RandomEventKind.WeaponInfiniteAmmo => config.ReadOrDefault("event-weapon-infinite-ammo-duration", 25.0),
            RandomEventKind.WeaponNeuroAmmo => config.ReadOrDefault("event-weapon-neuro-ammo-duration", 20.0),
            RandomEventKind.WeaponExplosiveAmmo => config.ReadOrDefault("event-weapon-explosive-ammo-duration", 20.0),
            RandomEventKind.EnemySpeed => config.ReadOrDefault("event-enemy-speed-duration", 25.0),
            RandomEventKind.EnemyInvisible => config.ReadOrDefault("event-enemy-invisible-duration", 15.0),
            RandomEventKind.EnemyWeak => config.ReadOrDefault("event-enemy-weak-duration", 25.0),
            RandomEventKind.EnemyStrong => config.ReadOrDefault("event-enemy-strong-duration", 25.0),
            RandomEventKind.EnemyPaused => config.ReadOrDefault("event-enemy-paused-duration", 8.0),
            _ => 30.0
        };

    private static List<RandomEventCandidate> GetRandomEventCandidates()
    {
        var result = new List<RandomEventCandidate>();

        if (config.ReadOrDefault("event-player-status-effects", true))
            result.Add(new RandomEventCandidate(RandomEventKind.PlayerStatus, GetRandomEventDurationSeconds(RandomEventKind.PlayerStatus)));

        if (config.ReadOrDefault("event-player-blindness", true))
            result.Add(new RandomEventCandidate(RandomEventKind.PlayerBlindness, GetRandomEventDurationSeconds(RandomEventKind.PlayerBlindness)));

        if (config.ReadOrDefault("event-player-freeze", true))
            result.Add(new RandomEventCandidate(RandomEventKind.PlayerFreeze, GetRandomEventDurationSeconds(RandomEventKind.PlayerFreeze)));

        if (config.ReadOrDefault("event-player-scale", true))
            result.Add(new RandomEventCandidate(RandomEventKind.PlayerScale, GetRandomEventDurationSeconds(RandomEventKind.PlayerScale)));

        if (config.ReadOrDefault("event-weapon-infinite-ammo", true))
            result.Add(new RandomEventCandidate(RandomEventKind.WeaponInfiniteAmmo, GetRandomEventDurationSeconds(RandomEventKind.WeaponInfiniteAmmo)));

        if (config.ReadOrDefault("event-weapon-neuro-ammo", true))
            result.Add(new RandomEventCandidate(RandomEventKind.WeaponNeuroAmmo, GetRandomEventDurationSeconds(RandomEventKind.WeaponNeuroAmmo)));

        if (config.ReadOrDefault("event-weapon-explosive-ammo", true))
            result.Add(new RandomEventCandidate(RandomEventKind.WeaponExplosiveAmmo, GetRandomEventDurationSeconds(RandomEventKind.WeaponExplosiveAmmo)));

        if (config.ReadOrDefault("event-enemy-speed", true))
            result.Add(new RandomEventCandidate(RandomEventKind.EnemySpeed, GetRandomEventDurationSeconds(RandomEventKind.EnemySpeed)));

        if (config.ReadOrDefault("event-enemy-invisible", true))
            result.Add(new RandomEventCandidate(RandomEventKind.EnemyInvisible, GetRandomEventDurationSeconds(RandomEventKind.EnemyInvisible)));

        if (config.ReadOrDefault("event-enemy-weak", true))
            result.Add(new RandomEventCandidate(RandomEventKind.EnemyWeak, GetRandomEventDurationSeconds(RandomEventKind.EnemyWeak)));

        if (config.ReadOrDefault("event-enemy-strong", true))
            result.Add(new RandomEventCandidate(RandomEventKind.EnemyStrong, GetRandomEventDurationSeconds(RandomEventKind.EnemyStrong)));

        if (config.ReadOrDefault("event-enemy-paused", true))
            result.Add(new RandomEventCandidate(RandomEventKind.EnemyPaused, GetRandomEventDurationSeconds(RandomEventKind.EnemyPaused)));

        return result;
    }

    private static RandomEventCandidate? SelectRandomEventCandidate()
    {
        var candidates = GetRandomEventCandidates();
        if (candidates.Count == 0)
            return null;

        return candidates[GetRandomEventRandomLocked().Next(candidates.Count)];
    }

    private static float NextFloat(double min, double max)
    {
        if (max < min)
        {
            (min, max) = (max, min);
        }

        return (float)(min + (GetRandomEventRandomLocked().NextDouble() * (max - min)));
    }

    private static PassiveSkillEventDelta CreateRandomStatusDelta()
        => RandomStatusEffectDeltas[GetRandomEventRandomLocked().Next(RandomStatusEffectDeltas.Length)];

    private static RandomEventInstance CreateRandomEventInstance(RandomEventCandidate candidate, long now)
    {
        var durationSeconds = Math.Clamp(candidate.DurationSeconds, 1.0, 600.0);
        var playerScaleMin = config.ReadOrDefault("event-player-scale-min", 0.65);
        var playerScaleMax = config.ReadOrDefault("event-player-scale-max", 1.55);
        var enemySpeedMin = config.ReadOrDefault("event-enemy-speed-min", 0.4);
        var enemySpeedMax = config.ReadOrDefault("event-enemy-speed-max", 2.5);
        var enemyHealthMultiplier = candidate.Kind switch
        {
            RandomEventKind.EnemyWeak => 0.35f,
            RandomEventKind.EnemyStrong => 2.25f,
            _ => 1.0f
        };

        return new RandomEventInstance()
        {
            Kind = candidate.Kind,
            StartedAt = now,
            EndsAt = now + SecondsToTimestampTicks(durationSeconds),
            DurationSeconds = durationSeconds,
            StatusDelta = candidate.Kind == RandomEventKind.PlayerStatus ? CreateRandomStatusDelta() : default,
            PlayerScaleMultiplier = candidate.Kind == RandomEventKind.PlayerScale ? NextFloat(playerScaleMin, playerScaleMax) : 1.0f,
            EnemySpeedMultiplier = candidate.Kind == RandomEventKind.EnemySpeed ? NextFloat(enemySpeedMin, enemySpeedMax) : 1.0f,
            EnemyHealthMultiplier = enemyHealthMultiplier,
        };
    }

    private static void StartRandomEventLocked(RandomEventCandidate candidate, long now)
    {
        activeRandomEvent = CreateRandomEventInstance(candidate, now);
        activeRandomEventStartedFromUi = false;
        var suffix = GetRandomEventInstanceSuffix(activeRandomEvent);
        logger.Log($"Random event started: {GetRandomEventDisplayName(activeRandomEvent.Kind)}{suffix} for {activeRandomEvent.DurationSeconds:0.###}s.");
    }

    private static string GetRandomEventInstanceSuffix(RandomEventInstance randomEvent)
        => randomEvent.Kind switch
        {
            RandomEventKind.PlayerStatus => $" ({randomEvent.StatusDelta.Label})",
            RandomEventKind.PlayerScale => $" (x{randomEvent.PlayerScaleMultiplier:0.##})",
            RandomEventKind.EnemySpeed => $" (x{randomEvent.EnemySpeedMultiplier:0.##})",
            _ => string.Empty
        };

    private static void FinishRandomEventLocked()
    {
        if (activeRandomEvent != null)
        {
            logger.Log($"Random event ended: {GetRandomEventDisplayName(activeRandomEvent.Kind)}.", isVerbose: true);
        }

        RestoreRandomEventRuntimeStateLocked();
        activeRandomEvent = null;
        activeRandomEventStartedFromUi = false;
    }

    private static void UpdateRandomEvents(ObjectManager? objectManager)
    {
        RandomEventInstance? eventToApply = null;
        var now = Stopwatch.GetTimestamp();

        if (!IsRandomEventsEnabled())
        {
            lock (randomEventStateLock)
            {
                if (activeRandomEventStartedFromUi && activeRandomEvent != null)
                {
                    if (now >= activeRandomEvent.EndsAt)
                        FinishRandomEventLocked();
                    else
                        eventToApply = activeRandomEvent;
                }

                if (eventToApply == null && HasRandomEventStateLocked())
                    ClearRandomEventStateLocked(restore: true);
            }

            if (eventToApply != null)
                ApplyRandomEvent(eventToApply, objectManager);
            return;
        }

        lock (randomEventStateLock)
        {
            EnsureRandomEventRandomLocked();
            if (activeRandomEvent != null && now >= activeRandomEvent.EndsAt)
            {
                FinishRandomEventLocked();
                ScheduleNextRandomEventLocked(now);
            }

            if (activeRandomEvent == null)
            {
                if (nextRandomEventAt == 0)
                    ScheduleNextRandomEventLocked(now);

                if (now >= nextRandomEventAt)
                {
                    var candidate = SelectRandomEventCandidate();
                    if (candidate == null)
                    {
                        ScheduleNextRandomEventLocked(now);
                    }
                    else
                    {
                        StartRandomEventLocked(candidate.Value, now);
                    }
                }
            }

            eventToApply = activeRandomEvent;
        }

        if (eventToApply != null)
            ApplyRandomEvent(eventToApply, objectManager);
    }

    private static void ApplyRandomEvent(RandomEventInstance randomEvent, ObjectManager? objectManager)
    {
        try
        {
            switch (randomEvent.Kind)
            {
                case RandomEventKind.PlayerStatus:
                    ApplyPlayerStatusEvent(randomEvent);
                    break;
                case RandomEventKind.PlayerBlindness:
                    ApplyPlayerBlindnessEvent();
                    break;
                case RandomEventKind.PlayerFreeze:
                    ApplyPlayerFreezeEvent();
                    break;
                case RandomEventKind.PlayerScale:
                    ApplyPlayerScaleEvent(randomEvent);
                    break;
                case RandomEventKind.WeaponInfiniteAmmo:
                    ApplyWeaponInfiniteAmmoEvent();
                    break;
                case RandomEventKind.EnemySpeed:
                case RandomEventKind.EnemyInvisible:
                case RandomEventKind.EnemyWeak:
                case RandomEventKind.EnemyStrong:
                case RandomEventKind.EnemyPaused:
                    ApplyEnemyRuntimeEvent(randomEvent, objectManager);
                    break;
            }
        }
        catch (Exception ex)
        {
            logger.Log($"Unable to apply random event {randomEvent.Kind}: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
        }
    }

    private static PlayerMovement? TryGetPlayerMovement()
        => TryGetComponent<PlayerMovement>(GetPlayerGameObject(), PlayerMovement.REFType);

    private static PlayerPassiveSkillManager? TryGetPlayerPassiveSkillManager()
    {
        var playerObject = GetPlayerGameObject();
        var manager = TryGetComponent<PlayerPassiveSkillManager>(playerObject, PlayerPassiveSkillManager.REFType);
        if (manager != null)
            return manager;

        try
        {
            manager = TryGetComponent<PlayerOrder>(playerObject, PlayerOrder.REFType)?.PlayerPassiveSkillManager;
            if (manager != null)
                return manager;
        }
        catch
        {
        }

        try
        {
            return TryGetComponent<PlayerStatus>(playerObject, PlayerStatus.REFType)?.PlayerPassiveSkillManager;
        }
        catch
        {
            return null;
        }
    }

    private static BlackOutManager? TryGetBlackOutManager()
    {
        try
        {
            var manager = API.GetManagedSingleton("app.BlackOutManager")?.As<BlackOutManager>();
            if (manager != null)
                return manager;
        }
        catch
        {
        }

        try
        {
            var objectManager = API.GetManagedSingleton("app.ObjectManager")?.As<ObjectManager>();
            var blackOutObject = objectManager?.findObject("BlackOutManager")
                ?? ObjectManager.findObjectInCurrentScene("BlackOutManager");
            var manager = TryGetComponent<BlackOutManager>(blackOutObject, BlackOutManager.REFType);
            if (manager != null)
                return manager;
        }
        catch
        {
        }

        return TryGetComponent<BlackOutManager>(GetPlayerGameObject(), BlackOutManager.REFType);
    }

    private static void ApplyPlayerStatusEvent(RandomEventInstance randomEvent)
        => ApplyPassiveSkillEvent(randomEvent.StatusDelta);

    private static void ApplyWeaponInfiniteAmmoEvent()
        => ApplyPassiveSkillEvent(InfiniteAmmoPassiveSkillDelta);

    private static void ApplyPassiveSkillEvent(PassiveSkillEventDelta delta)
    {
        var manager = TryGetPlayerPassiveSkillManager();
        if (manager == null)
            return;

        var address = manager.Address();
        lock (randomEventStateLock)
        {
            if (randomEventPassiveSkillStates.ContainsKey(address))
                return;

            ApplyPassiveSkillDelta(manager, delta);
            randomEventPassiveSkillStates[address] = new PassiveSkillEventState()
            {
                Manager = manager,
                Delta = delta
            };
        }
    }

    private static void ApplyPassiveSkillDelta(PlayerPassiveSkillManager manager, PassiveSkillEventDelta delta)
    {
        try
        {
            manager.AttackChangeRate += delta.AttackChangeRate;
            manager.DamageChangeRate += delta.DamageChangeRate;
            manager.WalkSpeedChangeRate += delta.WalkSpeedChangeRate;
            manager.MoveSpeedChangeRate += delta.MoveSpeedChangeRate;
            manager.DyingMoveSpeedChangeRate += delta.DyingMoveSpeedChangeRate;
            manager.ReloadSpeedChangeRate += delta.ReloadSpeedChangeRate;
            manager.BulletStackNumInfinityCount = Math.Max(
                0,
                manager.BulletStackNumInfinityCount + delta.BulletStackNumInfinityCount);
        }
        catch (Exception ex)
        {
            logger.Log($"Unable to apply random status effect '{delta.Label}': {ex.GetType().Name}: {ex.Message}", isVerbose: true);
        }
    }

    private static void ApplyPlayerBlindnessEvent()
    {
        lock (randomEventStateLock)
        {
            if (randomEventBlindnessFadeRequested)
                return;

            var blackOutManager = TryGetBlackOutManager();
            if (blackOutManager == null)
                return;

            try
            {
                blackOutManager.setupFadeTime(0.1f);
                blackOutManager.requestFadeOut_forEvent(BlackOutManager.FadeColorEnum.Black, hideLoading: true);
                randomEventBlindnessFadeRequested = true;
            }
            catch (Exception ex)
            {
                logger.Log($"Unable to request blindness blackout: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            }
        }
    }

    private static void ApplyPlayerFreezeEvent()
    {
        var movement = TryGetPlayerMovement();
        if (movement == null)
            return;

        var address = movement.Address();
        lock (randomEventStateLock)
        {
            if (!randomEventMovementStates.ContainsKey(address))
            {
                randomEventMovementStates[address] = new PlayerMovementEventState()
                {
                    Movement = movement,
                    ExternalWalkSpeedRate = movement.ExternalWalkSpeedRate,
                    ExternalJogSpeedRate = movement.ExternalJogSpeedRate,
                    ExternalDyingWalkSpeedRate = movement.ExternalDyingWalkSpeedRate,
                    ExternalDyingJogSpeedRate = movement.ExternalDyingJogSpeedRate,
                    ActionSpeedRate = movement.ActionSpeedRate,
                    IsForbidTerrainMove = movement.IsForbidTerrainMove
                };
            }

            movement.ExternalWalkSpeedRate = 0.0f;
            movement.ExternalJogSpeedRate = 0.0f;
            movement.ExternalDyingWalkSpeedRate = 0.0f;
            movement.ExternalDyingJogSpeedRate = 0.0f;
            movement.ActionSpeedRate = 0.0f;
            movement.IsForbidTerrainMove = true;
        }
    }

    private static void ApplyPlayerScaleEvent(RandomEventInstance randomEvent)
    {
        var playerObject = GetPlayerGameObject();
        var transform = playerObject?.Transform;
        if (!IsValidGameObject(playerObject) || transform == null)
            return;

        var address = playerObject!.Address();
        lock (randomEventStateLock)
        {
            if (!randomEventPlayerScaleStates.TryGetValue(address, out var state))
            {
                state = new PlayerScaleEventState()
                {
                    PlayerObject = playerObject!,
                    LocalScale = transform.LocalScale
                };
                randomEventPlayerScaleStates[address] = state;
            }

            transform.LocalScale = MultiplyVec3(state.LocalScale, randomEvent.PlayerScaleMultiplier);
        }
    }

    private static EnemyDamageController? TryGetEnemyDamageController(
        via.GameObject gameObject,
        EnemyActionController controller)
    {
        try
        {
            if (controller.enemyDamageController != null)
                return controller.enemyDamageController;
        }
        catch
        {
        }

        return TryGetComponent<EnemyDamageController>(gameObject, EnemyDamageController.REFType);
    }

    private static List<EnemyEventTarget> GetEnemyEventTargets(ObjectManager? objectManager)
    {
        var result = new List<EnemyEventTarget>();
        var managedObjects = GetManagedObjects(objectManager);
        if (managedObjects == null || !TryGetPlayerPosition(out var playerPosition))
            return result;

        var radius = config.ReadOrDefault("event-enemy-radius", 25.0);
        var maxTargets = Math.Max(1, (int)Math.Round(config.ReadOrDefault("event-enemy-max-targets", 8.0)));
        var radiusSq = (float)(radius * radius);
        var seen = new HashSet<ulong>();

        for (var groupIndex = 0; groupIndex < managedObjects.Count; groupIndex++)
        {
            var objects = managedObjects[groupIndex];
            if (objects == null)
                continue;

            for (var objectIndex = 0; objectIndex < objects.Count; objectIndex++)
            {
                var gameObject = objects[objectIndex];
                if (!IsValidGameObject(gameObject))
                    continue;

                var address = gameObject!.Address();
                if (!seen.Add(address))
                    continue;

                var controller = TryGetComponent<EnemyActionController>(gameObject, EnemyActionController.REFType);
                var transform = gameObject.Transform;
                if (controller == null || transform == null)
                    continue;

                var delta = SubtractVec3(transform.Position, playerPosition);
                var distanceSq = (delta.x * delta.x) + (delta.y * delta.y) + (delta.z * delta.z);
                if (distanceSq > radiusSq)
                    continue;

                result.Add(new EnemyEventTarget(
                    gameObject,
                    controller,
                    TryGetEnemyDamageController(gameObject, controller),
                    distanceSq));
            }
        }

        result.Sort((left, right) => left.DistanceSquared.CompareTo(right.DistanceSquared));
        if (result.Count > maxTargets)
            result.RemoveRange(maxTargets, result.Count - maxTargets);

        return result;
    }

    private static EnemyRuntimeEventState GetEnemyRuntimeEventState(EnemyEventTarget target)
    {
        var address = target.GameObject.Address();
        if (!randomEventEnemyStates.TryGetValue(address, out var state))
        {
            state = new EnemyRuntimeEventState()
            {
                GameObject = target.GameObject
            };
            randomEventEnemyStates[address] = state;
        }

        state.DamageController ??= target.DamageController;
        return state;
    }

    private static void ApplyEnemyRuntimeEvent(RandomEventInstance randomEvent, ObjectManager? objectManager)
    {
        var targets = GetEnemyEventTargets(objectManager);
        lock (randomEventStateLock)
        {
            foreach (var target in targets)
            {
                var state = GetEnemyRuntimeEventState(target);
                if (randomEvent.Kind is RandomEventKind.EnemySpeed or RandomEventKind.EnemyPaused or RandomEventKind.EnemyWeak or RandomEventKind.EnemyStrong)
                {
                    state.TimeScale ??= target.GameObject.TimeScale;
                    var multiplier = randomEvent.Kind switch
                    {
                        RandomEventKind.EnemyPaused => 0.0f,
                        RandomEventKind.EnemyWeak => 0.85f,
                        RandomEventKind.EnemyStrong => 1.2f,
                        _ => randomEvent.EnemySpeedMultiplier
                    };
                    target.GameObject.TimeScale = state.TimeScale.Value * multiplier;
                }

                if (randomEvent.Kind == RandomEventKind.EnemyInvisible)
                {
                    state.DrawSelf ??= target.GameObject.DrawSelf;
                    target.GameObject.DrawSelf = false;
                }

                if (randomEvent.Kind is RandomEventKind.EnemyWeak or RandomEventKind.EnemyStrong
                    && state.DamageController != null)
                {
                    state.DefaultMaxHealth ??= state.DamageController.defaultMaxHealth;
                    state.DamageController.defaultMaxHealth = Math.Max(1.0f, state.DefaultMaxHealth.Value * randomEvent.EnemyHealthMultiplier);
                }
            }
        }
    }

    private static void RestoreRandomEventRuntimeStateLocked()
    {
        foreach (var state in randomEventMovementStates.Values)
        {
            try
            {
                state.Movement.ExternalWalkSpeedRate = state.ExternalWalkSpeedRate;
                state.Movement.ExternalJogSpeedRate = state.ExternalJogSpeedRate;
                state.Movement.ExternalDyingWalkSpeedRate = state.ExternalDyingWalkSpeedRate;
                state.Movement.ExternalDyingJogSpeedRate = state.ExternalDyingJogSpeedRate;
                state.Movement.ActionSpeedRate = state.ActionSpeedRate;
                state.Movement.IsForbidTerrainMove = state.IsForbidTerrainMove;
            }
            catch (Exception ex)
            {
                logger.Log($"Unable to restore player movement random event state: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            }
        }
        randomEventMovementStates.Clear();

        foreach (var state in randomEventPlayerScaleStates.Values)
        {
            try
            {
                var transform = state.PlayerObject.Transform;
                if (IsValidGameObject(state.PlayerObject) && transform != null)
                    transform.LocalScale = state.LocalScale;
            }
            catch (Exception ex)
            {
                logger.Log($"Unable to restore player scale random event state: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            }
        }
        randomEventPlayerScaleStates.Clear();

        foreach (var state in randomEventPassiveSkillStates.Values)
        {
            ApplyPassiveSkillDelta(state.Manager, state.Delta.Negated());
        }
        randomEventPassiveSkillStates.Clear();

        foreach (var state in randomEventEnemyStates.Values)
        {
            try
            {
                if (IsValidGameObject(state.GameObject))
                {
                    if (state.TimeScale.HasValue)
                        state.GameObject.TimeScale = state.TimeScale.Value;

                    if (state.DrawSelf.HasValue)
                        state.GameObject.DrawSelf = state.DrawSelf.Value;
                }

                if (state.DamageController != null && state.DefaultMaxHealth.HasValue)
                    state.DamageController.defaultMaxHealth = state.DefaultMaxHealth.Value;
            }
            catch (Exception ex)
            {
                logger.Log($"Unable to restore enemy random event state: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            }
        }
        randomEventEnemyStates.Clear();

        if (randomEventBlindnessFadeRequested)
        {
            try
            {
                var blackOutManager = TryGetBlackOutManager();
                blackOutManager?.setupFadeTime(0.25f);
                blackOutManager?.requestFadeIn_forEvent();
            }
            catch (Exception ex)
            {
                logger.Log($"Unable to clear blindness blackout: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            }
            randomEventBlindnessFadeRequested = false;
        }
    }

    private static void ClearRandomEventState(bool restore)
    {
        lock (randomEventStateLock)
        {
            ClearRandomEventStateLocked(restore);
        }
    }

    private static void ClearRandomEventStateLocked(bool restore)
    {
        if (restore)
            RestoreRandomEventRuntimeStateLocked();
        else
            randomEventBlindnessFadeRequested = false;

        randomEventRng = null;
        randomEventSeed = null;
        nextRandomEventAt = 0;
        activeRandomEvent = null;
        activeRandomEventStartedFromUi = false;
        explosiveAmmoLastShotTimestamps.Clear();
    }

    private static string GetRandomEventDisplayName(RandomEventKind kind)
        => kind switch
        {
            RandomEventKind.PlayerStatus => "player status effect",
            RandomEventKind.PlayerBlindness => "brief blindness",
            RandomEventKind.PlayerFreeze => "movement lock",
            RandomEventKind.PlayerScale => "player scale",
            RandomEventKind.WeaponInfiniteAmmo => "infinite ammo",
            RandomEventKind.WeaponNeuroAmmo => "neuro ammo",
            RandomEventKind.WeaponExplosiveAmmo => "explosive ammo",
            RandomEventKind.EnemySpeed => "enemy speed shuffle",
            RandomEventKind.EnemyInvisible => "invisible enemies",
            RandomEventKind.EnemyWeak => "weak enemies",
            RandomEventKind.EnemyStrong => "strong enemies",
            RandomEventKind.EnemyPaused => "paused enemies",
            _ => kind.ToString()
        };

    private static string GetRandomEventStateLabel()
    {
        lock (randomEventStateLock)
        {
            var now = Stopwatch.GetTimestamp();
            if (activeRandomEvent != null)
            {
                var remaining = Math.Max(0.0, ElapsedSeconds(now, activeRandomEvent.EndsAt));
                return string.Create(
                    CultureInfo.InvariantCulture,
                    $"{GetRandomEventDisplayName(activeRandomEvent.Kind)}{GetRandomEventInstanceSuffix(activeRandomEvent)} active, {remaining:0.#}s left");
            }

            if (nextRandomEventAt != 0)
            {
                var remaining = Math.Max(0.0, ElapsedSeconds(now, nextRandomEventAt));
                return string.Create(CultureInfo.InvariantCulture, $"next in {remaining:0.#}s");
            }

            return "idle";
        }
    }

    private static bool TryGetRandomEventOverlayLabel(out string label)
    {
        lock (randomEventStateLock)
        {
            var now = Stopwatch.GetTimestamp();
            if (activeRandomEvent == null || now >= activeRandomEvent.EndsAt)
            {
                label = string.Empty;
                return false;
            }

            var remaining = Math.Max(0.0, ElapsedSeconds(now, activeRandomEvent.EndsAt));
            label = string.Create(
                CultureInfo.InvariantCulture,
                $"BioRand event: {GetRandomEventDisplayName(activeRandomEvent.Kind)}{GetRandomEventInstanceSuffix(activeRandomEvent)} | {remaining:0.#}s");
            return true;
        }
    }

    private static void ClearRandomEventStateFromUi()
    {
        ClearRandomEventState(restore: true);
        logger.Log("Cleared random event state from UI.");
    }

    private static ObjectManager? TryGetRandomEventObjectManager()
    {
        try
        {
            return API.GetManagedSingleton("app.ObjectManager")?.As<ObjectManager>();
        }
        catch
        {
            return null;
        }
    }

    private static void StartRandomEventFromUi(RandomEventKind kind)
    {
        var now = Stopwatch.GetTimestamp();
        RandomEventInstance eventToApply;
        lock (randomEventStateLock)
        {
            EnsureRandomEventRandomLocked();
            eventToApply = CreateRandomEventInstance(
                new RandomEventCandidate(kind, GetRandomEventDurationSeconds(kind)),
                now);
            StartRandomEventFromUiLocked(eventToApply);
        }

        ApplyRandomEvent(eventToApply, TryGetRandomEventObjectManager());
        logger.Log($"Debug random event started: {GetRandomEventDisplayName(eventToApply.Kind)}{GetRandomEventInstanceSuffix(eventToApply)} for {eventToApply.DurationSeconds:0.###}s.");
    }

    private static void StartRandomStatusEffectFromUi(PassiveSkillEventDelta delta)
    {
        var now = Stopwatch.GetTimestamp();
        var durationSeconds = Math.Clamp(GetRandomEventDurationSeconds(RandomEventKind.PlayerStatus), 1.0, 600.0);
        var eventToApply = new RandomEventInstance()
        {
            Kind = RandomEventKind.PlayerStatus,
            StartedAt = now,
            EndsAt = now + SecondsToTimestampTicks(durationSeconds),
            DurationSeconds = durationSeconds,
            StatusDelta = delta
        };

        lock (randomEventStateLock)
        {
            StartRandomEventFromUiLocked(eventToApply);
        }

        ApplyRandomEvent(eventToApply, TryGetRandomEventObjectManager());
        logger.Log($"Debug random event started: {GetRandomEventDisplayName(eventToApply.Kind)} ({delta.Label}) for {durationSeconds:0.###}s.");
    }

    private static void StartRandomEventFromUiLocked(RandomEventInstance randomEvent)
    {
        RestoreRandomEventRuntimeStateLocked();
        activeRandomEvent = randomEvent;
        activeRandomEventStartedFromUi = true;
        nextRandomEventAt = 0;
        explosiveAmmoLastShotTimestamps.Clear();
    }

    [MethodHook(typeof(WeaponGun), nameof(WeaponGun.expendBullet), MethodHookType.Pre)]
    private static PreHookResult WeaponGun_expendBullet_Pre(Span<ulong> args)
    {
        pendingInfiniteAmmoGun = null;
        pendingInfiniteAmmoLoadNum = 0;
        pendingInfiniteAmmoActive = false;

        if (!IsRandomEventActive(RandomEventKind.WeaponInfiniteAmmo))
            return PreHookResult.Continue;

        var gun = ManagedObject.ToManagedObject(args[1])?.As<WeaponGun>();
        if (gun == null)
            return PreHookResult.Continue;

        try
        {
            pendingInfiniteAmmoGun = gun;
            pendingInfiniteAmmoLoadNum = gun.loadNum;
            pendingInfiniteAmmoActive = true;
            if (gun.loadNum <= 0)
                gun.loadNum = 1;
        }
        catch (Exception ex)
        {
            logger.Log($"Unable to prepare infinite ammo event: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(WeaponGun), nameof(WeaponGun.expendBullet), MethodHookType.Post)]
    private static void WeaponGun_expendBullet_Post(ref ulong retval)
    {
        var gun = pendingInfiniteAmmoGun;
        var loadNum = pendingInfiniteAmmoLoadNum;
        var wasActive = pendingInfiniteAmmoActive;
        pendingInfiniteAmmoGun = null;
        pendingInfiniteAmmoLoadNum = 0;
        pendingInfiniteAmmoActive = false;

        if (!wasActive || gun == null)
            return;

        try
        {
            gun.loadNum = Math.Max(1, loadNum);
            retval = 1;
        }
        catch (Exception ex)
        {
            logger.Log($"Unable to restore infinite ammo event load count: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
        }
    }

    [MethodHook(typeof(WeaponGun), "set_loadNum", MethodHookType.Pre)]
    private static PreHookResult WeaponGun_set_loadNum_Pre(Span<ulong> args)
    {
        if (!IsRandomEventActive(RandomEventKind.WeaponInfiniteAmmo))
            return PreHookResult.Continue;

        if (args.Length < 3)
            return PreHookResult.Continue;

        var gun = ManagedObject.ToManagedObject(args[1])?.As<WeaponGun>();
        if (gun == null)
            return PreHookResult.Continue;

        try
        {
            var requestedLoadNum = unchecked((int)args[2]);
            return requestedLoadNum < gun.loadNum
                ? PreHookResult.Skip
                : PreHookResult.Continue;
        }
        catch (Exception ex)
        {
            logger.Log($"Unable to check infinite ammo load count setter: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            return PreHookResult.Continue;
        }
    }

    [MethodHook(typeof(WeaponGun), nameof(WeaponGun.setupBullet), MethodHookType.Pre)]
    private static PreHookResult WeaponGun_setupBullet_Pre(Span<ulong> args)
    {
        if (args.Length > 2 && IsRandomEventActive(RandomEventKind.WeaponNeuroAmmo))
            args[2] = (ulong)ShellManager.BulletType.AcidBulletS;

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(WeaponGun), nameof(WeaponGun.shoot), MethodHookType.Pre)]
    private static PreHookResult WeaponGun_shoot_Pre(Span<ulong> args)
    {
        if (!IsRandomEventActive(RandomEventKind.WeaponExplosiveAmmo))
            return PreHookResult.Continue;

        var noBullet = args.Length > 4 && args[4] != 0;
        if (noBullet && !IsRandomEventActive(RandomEventKind.WeaponInfiniteAmmo))
            return PreHookResult.Continue;

        var gun = ManagedObject.ToManagedObject(args[1])?.As<WeaponGun>();
        if (gun != null)
            TryRequestExplosiveAmmoBomb(gun);

        return PreHookResult.Continue;
    }

    private static void TryRequestExplosiveAmmoBomb(WeaponGun gun)
    {
        try
        {
            var gunObject = gun.GameObject;
            var address = gunObject?.Address() ?? gun.Address();
            var now = Stopwatch.GetTimestamp();
            lock (randomEventStateLock)
            {
                if (explosiveAmmoLastShotTimestamps.TryGetValue(address, out var lastShot)
                    && ElapsedSeconds(lastShot, now) < ExplosiveAmmoMinIntervalSeconds)
                {
                    return;
                }

                explosiveAmmoLastShotTimestamps[address] = now;
            }

            var owner = GetPlayerGameObject() ?? gunObject;
            var targetTransform = gunObject?.Transform ?? owner?.Transform;
            var shellManager = TryGetShellManager(owner);
            if (owner == null || targetTransform == null || shellManager == null)
                return;

            var bomb = shellManager.createBomb(owner, targetTransform, CreateVec3(0.0f, 0.0f, 1.25f), via.Quaternion.Identity);
            bomb?.requestExplosion();
        }
        catch (Exception ex)
        {
            logger.Log($"Unable to request explosive ammo bomb: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
        }
    }
}
