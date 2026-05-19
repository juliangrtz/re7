
using app;
using app.Collision;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;
public partial class REFPlugin
{
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

    private static double GetEnemyDropProbability(string? enemyTypeId)
    {
        var probability = config.ReadOrDefault("enemy-drop-probability", DefaultEnemyDropProbability);
        if (enemyTypeId != null
            && EnemyDropProbabilityConfigIdsByTypeId.TryGetValue(enemyTypeId, out var configId)
            && config.TryRead($"enemy-drop-probability-{configId}", out double enemyProbability))
        {
            probability = enemyProbability;
        }

        return Math.Clamp(probability, 0.0, 1.0);
    }

    private static string GetCurrentChapterName()
        => API.GetManagedSingleton("app.GameFlowFsmManager").As<GameFlowFsmManager>().CurrentMainGameFlow.ToString();

    private static GameManager.Difficulty GetCurrentDifficulty()
        => API.GetManagedSingleton("app.GameManager").As<GameManager>().GameDifficulty;

    private static bool IsAmmoEnemyDrop(string itemDataId)
        => AmmoEnemyDropItemDataIds.Contains(itemDataId);

    private static int GetVanillaEnemyDropStackLimit(string itemDataId)
    {
        var defaultStackSize = DefaultEnemyDropStackLimits.GetValueOrDefault(itemDataId, 1);
        return Math.Max(1, defaultStackSize);
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

    private static string? GetEnemyTypeId(ManagedObject dropSourceObject, via.GameObject? enemyObject)
    {
        var runtimeTypeName = GetManagedObjectRuntimeTypeName(dropSourceObject);
        var runtimeTypeId = ExtractEnemyTypeId(runtimeTypeName);
        var objectTypeId = ExtractEnemyTypeId(enemyObject?.Name);
        if (string.Equals(runtimeTypeId, "Em3000", StringComparison.OrdinalIgnoreCase)
            && string.Equals(objectTypeId, "Em8000", StringComparison.OrdinalIgnoreCase))
        {
            return objectTypeId;
        }

        return runtimeTypeId ?? objectTypeId;
    }

    private static double GetEnemyDropMultiplier(ManagedObject dropSourceObject, via.GameObject? enemyObject, out string? enemyTypeId)
    {
        var runtimeTypeName = GetManagedObjectRuntimeTypeName(dropSourceObject);
        enemyTypeId = GetEnemyTypeId(dropSourceObject, enemyObject);
        if (enemyTypeId != null && SpecialEnemyDropMultipliers.TryGetValue(enemyTypeId, out var dropMultiplier))
        {
            logger.Log(
                $"Enemy drop source '{runtimeTypeName}' / object '{enemyObject?.Name ?? "unknown"}' matched '{enemyTypeId}' and will use drop multiplier x{dropMultiplier}.",
                isVerbose: true);
            return dropMultiplier;
        }

        logger.Log(
            $"Enemy drop source '{runtimeTypeName ?? "unknown"}' / object '{enemyObject?.Name ?? "unknown"}' will use the default drop multiplier x{DefaultEnemyDropMultiplier}.",
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

        var stackSize = GetVanillaEnemyDropStackLimit(itemDataId);
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

        var stackLimit = Math.Max(1.0, GetVanillaEnemyDropStackLimit(itemDataId));
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

    private static EnemyDropSelection? SelectEnemyDrop(
        via.GameObject enemyObject,
        int generation,
        bool restrictToBossDropPool,
        string? enemyTypeId)
    {
        var rng = CreateEnemyDropRandom(enemyObject.Address(), generation);
        var dropProbability = GetEnemyDropProbability(enemyTypeId);
        if (dropProbability <= 0.0)
        {
            logger.Log(
                $"Enemy drop probability is 0%; skipping drop for enemy '{enemyTypeId ?? "unknown"}' object 0x{enemyObject.Address():X}.",
                isVerbose: true);
            return null;
        }

        if (dropProbability < 1.0)
        {
            var dropRoll = rng.NextDouble();
            if (dropRoll >= dropProbability)
            {
                logger.Log(
                    $"Enemy drop roll {dropRoll:0.###} failed probability {dropProbability:0.###} for enemy '{enemyTypeId ?? "unknown"}' object 0x{enemyObject.Address():X}.",
                    isVerbose: true);
                return null;
            }
        }

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

    private static bool ShouldKeepEnemyDropStateAfterForgetDie(ManagedObject dropSourceObject, via.GameObject? enemyObject)
    {
        var enemyTypeId = GetEnemyTypeId(dropSourceObject, enemyObject);
        return enemyTypeId != null && SingleDropPerSpawnEnemyTypeIds.Contains(enemyTypeId);
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

    private static via.vec3 CreateVec3(float x, float y, float z)
    {
        var result = via.vec3.Zero;
        result.x = x;
        result.y = y;
        result.z = z;
        return result;
    }

    private static via.vec3 AddVec3(via.vec3 left, via.vec3 right)
        => CreateVec3(left.x + right.x, left.y + right.y, left.z + right.z);

    private static via.vec3 SubtractVec3(via.vec3 left, via.vec3 right)
        => CreateVec3(left.x - right.x, left.y - right.y, left.z - right.z);

    private static via.vec3 MultiplyVec3(via.vec3 value, float scalar)
        => CreateVec3(value.x * scalar, value.y * scalar, value.z * scalar);

    private static bool TryNormalizeHorizontal(via.vec3 value, out via.vec3 normal)
    {
        value.y = 0.0f;
        var length = MathF.Sqrt(value.x * value.x + value.z * value.z);
        if (length <= 0.0001f)
        {
            normal = via.vec3.Zero;
            return false;
        }

        normal = CreateVec3(value.x / length, 0.0f, value.z / length);
        return true;
    }

    private static float DotHorizontal(via.vec3 left, via.vec3 right)
        => left.x * right.x + left.z * right.z;

    private static bool TryCastEnemyDropTerrainRay(
        via.vec3 start,
        via.vec3 end,
        out via.vec3 hitPosition,
        out via.vec3 hitNormal)
    {
        hitPosition = via.vec3.Zero;
        hitNormal = via.vec3.Zero;

        try
        {
            var collisionSystem = API.GetManagedSingleton("app.Collision.CollisionSystem")?.As<CollisionSystem>();
            if (collisionSystem == null)
                return false;

            var filter = collisionSystem.createFilterInfo(
                CollisionSystem.Layer.TerrainCheck,
                CollisionSystem.MaskTerrain.TbEmHit);
            var query = via.physics.CastRayQuery.REFType.CreateInstance(0)?.As<via.physics.CastRayQuery>();
            var result = via.physics.CastRayResult.REFType.CreateInstance(0)?.As<via.physics.CastRayResult>();
            if (filter == null || query == null || result == null)
                return false;

            query.clearOptions();
            query.enableNearSort();
            query.enableOneHitBreak();
            query.disableInsideHits();
            query.FilterInfo = filter;
            query.setRay(start, end);

            result.clear();
            via.physics.System.castRay(query, result);
            if (!result.Finished
                || result.AsyncResult != via.physics.CastRayResult.Result.Success
                || result.NumContactPoints == 0)
                return false;

            var contactPoint = result.getContactPoint(0);
            hitPosition = contactPoint.Position;
            hitNormal = contactPoint.Normal;
            return true;
        }
        catch (Exception ex)
        {
            logger.Log($"Unable to cast enemy drop terrain ray: {ex.GetType().Name}: {ex.Message}", isVerbose: true);
            return false;
        }
    }

    private static bool TryProjectEnemyDropToGround(via.vec3 dropPosition, out via.vec3 groundPosition)
    {
        groundPosition = dropPosition;

        var start = CreateVec3(
            dropPosition.x,
            dropPosition.y + EnemyDropGroundRayStartOffset,
            dropPosition.z);
        var end = CreateVec3(
            dropPosition.x,
            dropPosition.y - EnemyDropGroundRayDistance,
            dropPosition.z);
        if (!TryCastEnemyDropTerrainRay(start, end, out var collisionPosition, out var collisionNormal))
            return false;

        if (collisionNormal.y < EnemyDropGroundMinNormalY
            || collisionPosition.y > dropPosition.y + EnemyDropGroundRayStartOffset)
            return false;

        collisionPosition.x = dropPosition.x;
        collisionPosition.z = dropPosition.z;
        groundPosition = collisionPosition;
        return true;
    }

    private static bool TryGetPlayerPosition(out via.vec3 playerPosition)
    {
        playerPosition = via.vec3.Zero;

        try
        {
            var objectManager = API.GetManagedSingleton("app.ObjectManager")?.As<ObjectManager>();
            var player = objectManager?.PlayerObj ?? objectManager?.findActivePlayer();
            var transform = player?.Transform;
            if (transform == null)
                return false;

            playerPosition = transform.Position;
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool TryGetEnemyDropWallClearanceDirection(via.GameObject enemyObject, via.vec3 dropPosition, out via.vec3 direction)
    {
        direction = via.vec3.Zero;
        if (TryGetPlayerPosition(out var playerPosition)
            && TryNormalizeHorizontal(SubtractVec3(playerPosition, dropPosition), out var playerDirection))
        {
            var start = AddVec3(dropPosition, MultiplyVec3(playerDirection, EnemyDropWallProbeDistance));
            var end = AddVec3(dropPosition, MultiplyVec3(playerDirection, -EnemyDropWallProbeDistance));
            if (TryCastEnemyDropTerrainRay(start, end, out var wallPosition, out var wallNormal)
                && TryNormalizeHorizontal(wallNormal, out direction))
            {
                if (DotHorizontal(direction, playerDirection) < 0.0f)
                    direction = MultiplyVec3(direction, -1.0f);

                return true;
            }

            direction = playerDirection;
            return true;
        }

        var enemyTransform = enemyObject.Transform;
        return enemyTransform != null
            && (TryNormalizeHorizontal(enemyTransform.AxisY, out direction)
                || TryNormalizeHorizontal(enemyTransform.AxisZ, out direction)
                || TryNormalizeHorizontal(enemyTransform.AxisX, out direction));
    }

    private static bool TryProjectEnemyDropAwayFromWall(via.GameObject enemyObject, via.vec3 dropPosition, out via.vec3 groundPosition)
    {
        groundPosition = dropPosition;

        if (!TryGetEnemyDropWallClearanceDirection(enemyObject, dropPosition, out var clearanceDirection))
            return false;

        foreach (var clearanceDistance in EnemyDropWallClearanceDistances)
        {
            var candidatePosition = AddVec3(dropPosition, MultiplyVec3(clearanceDirection, clearanceDistance));
            if (TryProjectEnemyDropToGround(candidatePosition, out groundPosition))
                return true;
        }

        return false;
    }

    private static void SpawnEnemyDrop(via.GameObject enemyObject, string? enemyTypeId, string itemDataId, int stackNum)
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
            if (TryProjectEnemyDropToGround(worldPosition, out var groundPosition))
            {
                logger.Log(
                    $"Projected enemy drop '{itemDataId}' from Y {worldPosition.y:0.###} to ground Y {groundPosition.y:0.###}.",
                    isVerbose: true);
                worldPosition = groundPosition;
            }
            else if (enemyTypeId != null
                && SingleDropPerSpawnEnemyTypeIds.Contains(enemyTypeId)
                && TryProjectEnemyDropAwayFromWall(enemyObject, worldPosition, out groundPosition))
            {
                logger.Log(
                    $"Moved wall-mounted hive drop '{itemDataId}' from ({worldPosition.x:0.###}, {worldPosition.y:0.###}, {worldPosition.z:0.###}) to ground ({groundPosition.x:0.###}, {groundPosition.y:0.###}, {groundPosition.z:0.###}).",
                    isVerbose: true);
                worldPosition = groundPosition;
            }

            dropTransform.setParent(null!, true);
            dropTransform.Position = worldPosition;
            dropTransform.Rotation = worldRotation;
        }

        logger.Log($"Spawned enemy drop '{itemDataId}' x{stackNum} for enemy object 0x{enemyObject.Address():X}.", isVerbose: true);
    }

    private static void SpawnConfiguredEnemyDrop(ManagedObject dropSourceObject, via.GameObject enemyObject, int generation)
    {
        var dropMultiplier = GetEnemyDropMultiplier(dropSourceObject, enemyObject, out var enemyTypeId);
        var selection = SelectEnemyDrop(
            enemyObject,
            generation,
            restrictToBossDropPool: IsBossEnemyTypeId(enemyTypeId),
            enemyTypeId: enemyTypeId);
        if (selection == null)
        {
            logger.Log($"No eligible enemy drop candidates for enemy object 0x{enemyObject.Address():X}.", isVerbose: true);
            return;
        }

        var finalStackNum = ApplyEnemyDropMultiplier(
            selection.Value.ItemDataId,
            selection.Value.StackNum,
            dropMultiplier);
        SpawnEnemyDrop(enemyObject, enemyTypeId, selection.Value.ItemDataId, finalStackNum);
    }

    private static void TrySpawnConfiguredEnemyDrop(ManagedObject dropSourceObject, via.GameObject? enemyObject)
    {
        if (!IsEnemyDropEnabled() || enemyObject == null)
            return;

        if (!TryBeginEnemyDrop(enemyObject, out var generation))
            return;

        SpawnConfiguredEnemyDrop(dropSourceObject, enemyObject, generation);
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
        var controllerObject = ManagedObject.ToManagedObject(args[1]);
        var controller = controllerObject.As<EnemyActionController>();
        if (ShouldKeepEnemyDropStateAfterForgetDie(controllerObject, controller?.GameObject))
        {
            logger.Log(
                $"Preserving enemy drop state after forgetDie for enemy object 0x{controller?.GameObject?.Address() ?? 0:X}.",
                isVerbose: true);
            return PreHookResult.Continue;
        }

        ResetEnemyDropState(controller?.GameObject);
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemyActionController), nameof(EnemyActionController.finishDead), MethodHookType.Pre)]
    private static PreHookResult EnemyActionController_finishDead_Pre(Span<ulong> args)
    {
        var controllerObject = ManagedObject.ToManagedObject(args[1]);
        var controller = controllerObject.As<EnemyActionController>();
        TrySpawnConfiguredEnemyDrop(controllerObject, controller?.GameObject);

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(EnemyDamageController), nameof(EnemyDamageController.doDie), MethodHookType.Pre)]
    private static PreHookResult EnemyDamageController_doDie_Pre(Span<ulong> args)
    {
        var controllerObject = ManagedObject.ToManagedObject(args[1]);
        var controller = controllerObject.As<EnemyDamageController>();
        TrySpawnConfiguredEnemyDrop(controllerObject, controller?.GameObject);

        return PreHookResult.Continue;
    }
}
