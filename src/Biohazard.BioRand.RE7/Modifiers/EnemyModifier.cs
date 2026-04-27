using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Impl;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyModifier : Modifier
{
    private const string RandomizerKey = "modifier/enemies";

    internal sealed record EnemyTableEntry(
        IEnemyDefinition Enemy,
        double Weight
    );

    internal record EnemyRandomizerOptions(
        int EnemyVariety,
        int MaxPackSize,
        bool DebugUniqueHp,
        bool IsBalanced,
        bool ProgressiveDifficulty,
        ScaleOptions ScaleOptions
    );

    internal record ScaleOptions(
        double Probability,
        float Min,
        float Max
    );

    internal sealed class EnemyHealthResolver(Randomizer randomizer, EnemyRandomizerOptions options, Rng healthRng)
    {
        private readonly HashSet<float> _assignedHealthValues = [];

        public float GetHealth(IEnemyDefinition enemy)
        {
            var health = enemy.GetHealth(randomizer, healthRng);
            if (!options.DebugUniqueHp)
            {
                return health;
            }

            while (!_assignedHealthValues.Add(health))
            {
                health += 1f;
            }

            return health;
        }
    }

    internal sealed class EnemyPackSelector(IEnumerable<EnemyModifier.EnemyTableEntry> enemyPool, int maxPackSize, Rng rng)
    {
        private readonly List<EnemyTableEntry> _enemyPool = [.. enemyPool];
        private readonly int _maxPackSize = Math.Max(1, maxPackSize);
        private readonly Rng _rng = rng;
        private IEnemyDefinition? _currentEnemy;
        private int _remainingPackSize;

        public IEnemyDefinition Next()
        {
            if (_currentEnemy == null || _remainingPackSize == 0)
            {
                _currentEnemy = ChooseNextEnemy();
                _remainingPackSize = _rng.Next(1, _maxPackSize + 1);
            }

            _remainingPackSize--;
            return _currentEnemy;
        }

        private IEnemyDefinition ChooseNextEnemy()
        {
            if (_enemyPool.Count == 0)
                throw new InvalidOperationException("Cannot choose an enemy from an empty pack selector.");

            if (_enemyPool.Count == 1 || _currentEnemy == null)
                return ChooseWeightedEnemy(_enemyPool, _rng);

            var candidates = _enemyPool
                .Where(entry => entry.Enemy != _currentEnemy)
                .ToList();

            return ChooseWeightedEnemy(candidates, _rng);
        }
    }

    internal sealed class ExtraEnemyPlacement
    {
        public bool Enabled { get; init; }
        public string Id { get; init; } = "";
        public string Comment { get; init; } = "";
        public string SceneFile { get; init; } = "";
        public int Chapter { get; init; }
        public float PosX { get; init; }
        public float PosY { get; init; }
        public float PosZ { get; init; }
        public float RotX { get; init; }
        public float RotY { get; init; }
        public float RotZ { get; init; }
        public float RotW { get; init; }
    }

    private static EnemyRandomizerOptions BuildOptions(Randomizer randomizer)
    {
        return new EnemyRandomizerOptions(
            EnemyVariety: randomizer.GetConfigOption<int>("enemy-variety"),
            MaxPackSize: randomizer.GetConfigOption<int>("enemy-pack-max-size"),
            DebugUniqueHp: randomizer.GetConfigOption<bool>("debug-unique-enemy-hp"),
            IsBalanced: randomizer.GetConfigOption<bool>("balanced-enemies"),
            ProgressiveDifficulty: randomizer.GetConfigOption("enemy-health-progressive-difficulty", false),

            ScaleOptions: new ScaleOptions(
                Probability: randomizer.GetConfigOption<double>("enemy-scale-probability", 0),
                Min: Math.Clamp(randomizer.GetConfigOption("enemy-scale-min", 0.25f), 0.1f, 10.0f),
                Max: Math.Clamp(randomizer.GetConfigOption("enemy-scale-max", 2.00f), 0.1f, 10.0f)
            )
        );
    }

    private readonly Dictionary<string, RszGameObject> _generatorTemplateCache = new();
    private readonly Dictionary<string, RszGameObject> _spawnInfoTemplateCache = new();
    private static readonly HashSet<Guid> _barnFightMoldeds = [
        new Guid("3d39aa00-a4f6-48ab-87f5-8f04dbfc13a5"),
        new Guid("7ae3d438-f9cb-49da-9a60-00435b946a59"),
    ];
    private Rng.Table<IEnemyDefinition>? _bossTable = null;

    internal static bool ShouldReplaceSpawnInfo(RszGameObject spawnInfoGameObject)
    {
        var component = spawnInfoGameObject.FindComponent<app.EnemySpawnInfo>();
        return component?.Enabled == true
            && !_barnFightMoldeds.Contains(spawnInfoGameObject.Guid);
    }

    private static int GetScaleProbabilityPercent(double probability)
        => (int)Math.Round(Math.Clamp(probability, 0.0, 1.0) * 100.0, MidpointRounding.AwayFromZero);

    private static IEnemyDefinition ChooseWeightedEnemy(
        List<EnemyTableEntry> enemyPool,
        Rng rng)
    {
        if (enemyPool.Count == 0)
            throw new InvalidOperationException("No enemy entries are available.");

        if (enemyPool.Count == 1)
            return enemyPool[0].Enemy;

        var totalWeight = enemyPool.Sum(entry => entry.Weight);
        var roll = rng.NextDouble(0, totalWeight);
        var cumulativeWeight = 0.0;

        for (var i = 0; i < enemyPool.Count - 1; i++)
        {
            cumulativeWeight += enemyPool[i].Weight;
            if (roll < cumulativeWeight)
                return enemyPool[i].Enemy;
        }

        return enemyPool[^1].Enemy;
    }

    internal static ImmutableArray<EnemyTableEntry> SelectAreaEnemyPool(
        IReadOnlyList<EnemyTableEntry> enemyPool,
        int enemyVariety,
        Rng rng)
    {
        if (enemyPool.Count == 0)
            return [];

        var desiredCount = Math.Clamp(enemyVariety, 1, enemyPool.Count);
        if (desiredCount >= enemyPool.Count)
            return [.. enemyPool];

        var remainingEntries = enemyPool.ToList();
        var selectedEntries = ImmutableArray.CreateBuilder<EnemyTableEntry>(desiredCount);
        while (selectedEntries.Count < desiredCount)
        {
            var selectedEnemy = ChooseWeightedEnemy(remainingEntries, rng);
            var selectedEntry = remainingEntries.First(entry => entry.Enemy == selectedEnemy);
            selectedEntries.Add(selectedEntry);
            remainingEntries.Remove(selectedEntry);
        }

        return selectedEntries.ToImmutable();
    }

    private static void RandomizeScale(via.Transform transform, ScaleOptions scaleOptions, Rng rng)
    {
        var unusualScaleChance = GetScaleProbabilityPercent(scaleOptions.Probability);
        if (!rng.NextProbability(unusualScaleChance))
        {
            return;
        }

        var newScale = rng.NextFloat(scaleOptions.Min, scaleOptions.Max);
        transform.Scale = new Vector3(newScale, newScale, newScale);
    }

    private RszGameObject GetOrCreateEnemyTemplate(
        Randomizer randomizer,
        string enemyId,
        via.Transform transform,
        bool updateTransform,
        bool randomizeScale,
        ScaleOptions scaleOptions,
        Rng rng)
    {
        if (!_generatorTemplateCache.TryGetValue(enemyId, out var baseTemplate))
        {
            baseTemplate = randomizer.TemplateService
                .GetEnemyTemplate(enemyId)
                .WithName(enemyId);

            _generatorTemplateCache[enemyId] = baseTemplate;
        }

        var template = CloneGameObject(baseTemplate, rng);
        template = EnemyDefinitions.Instance.FromId(enemyId)!.IndividualizeTemplate(rng, template);

        if (updateTransform || randomizeScale)
        {
            var templateTransform = updateTransform
                ? transform
                : template.FindComponent<via.Transform>()!;

            if (randomizeScale)
            {
                RandomizeScale(templateTransform, scaleOptions, rng);
            }

            template = template.AddOrUpdateComponent(templateTransform);
        }

        return template.WithName(enemyId);
    }

    private RszGameObject GetOrCreateSpawnInfoTemplate(
        Randomizer randomizer,
        string enemyId,
        Rng rng)
    {
        if (!_spawnInfoTemplateCache.TryGetValue(enemyId, out var template))
        {
            template = randomizer.TemplateService
                .GetEnemySpawnInfo(enemyId)
                .WithName(enemyId);

            _spawnInfoTemplateCache[enemyId] = template;
        }

        return CloneGameObject(template, rng)
            .WithName($"ESI_{enemyId}");
    }

    private RszScene ProcessGeneratorScene(
        RszScene scene,
        Randomizer randomizer,
        RandomizerLogger logger,
        EnemyGeneratorWrapper enemyGenerator,
        IEnumerable<(Guid spawnGuid, IEnemyDefinition enemy)> replacements,
        EnemyRandomizerOptions options,
        Rng rng,
        EnemyHealthResolver healthResolver)
    {
        var pooledObjects = new List<RszGameObject>();

        foreach (var (spawnGuid, newEnemy) in replacements)
        {
            var enemyId = newEnemy.EnemyId.ToString();

            var originalSpawnInfoGameObject = scene.FindGameObject(spawnGuid)!;
            var originalTransform = originalSpawnInfoGameObject.FindComponent<via.Transform>()!;
            var originalSpawnInfoComponent = originalSpawnInfoGameObject.FindComponent<app.EnemySpawnInfo>()!;

            if (newEnemy.UsesEnemyGenerator)
            {
                // Enemy that uses generator pool: Replace SpawnInfoOptions, UnitAlias and associated GameObject.
                var originalSpawnOptions = originalSpawnInfoGameObject.Components.Single(c => c.Type.Name.StartsWith("app.EnemySpawnInfoOption"));
                var spawnInfoTemplate = GetOrCreateSpawnInfoTemplate(randomizer, enemyId, rng);
                var newSpawnOptions = spawnInfoTemplate.FindComponent(newEnemy.SpawnOptionType!)!;
                var dlcSpawnOptions = spawnInfoTemplate.FindComponent("app.EnemySpawnInfoOptionDLC");
                originalSpawnInfoGameObject.AddOrUpdateComponent(newSpawnOptions);
                originalSpawnInfoGameObject.Components = originalSpawnInfoGameObject.Components
                    .Remove(originalSpawnOptions)
                    .Add(newSpawnOptions);
                if (dlcSpawnOptions != null)
                {
                    originalSpawnInfoGameObject.AddOrUpdateComponent(dlcSpawnOptions);
                    originalSpawnInfoGameObject.Components = originalSpawnInfoGameObject.Components.Add(dlcSpawnOptions);
                }

                var oldUnitAlias = originalSpawnInfoComponent.UnitAlias;
                var assignedHealth = healthResolver.GetHealth(newEnemy);
                originalSpawnInfoComponent.HealthParameter.Health = assignedHealth;
                originalSpawnInfoComponent.UnitAlias = enemyId;
                originalSpawnInfoGameObject = originalSpawnInfoGameObject
                    .AddOrUpdateComponent(originalSpawnInfoComponent)
                    .WithName(originalSpawnInfoGameObject.Name + "_Now_" + enemyId);

                scene = scene.UpdateGameObject(originalSpawnInfoGameObject);
                logger.LogSpawnHealthAssignment(
                    newEnemy,
                    assignedHealth,
                    "generator replacement",
                    originalSpawnInfoGameObject.Name,
                    spawnGuid,
                    $"PreviousAlias={oldUnitAlias}");

                var template = GetOrCreateEnemyTemplate(
                        randomizer,
                        enemyId,
                        originalTransform,
                        updateTransform: false,
                        randomizeScale: true,
                        options.ScaleOptions,
                        rng
                );
                pooledObjects.Add(template);
            }
            else
            {
                // Static enemy: remove SpawnInfo and insert template
                var template = GetOrCreateEnemyTemplate(
                    randomizer,
                    enemyId,
                    originalTransform,
                    updateTransform: true,
                    randomizeScale: true,
                    options.ScaleOptions,
                    rng)
                    .WithName($"{enemyId}_Static");

                scene = scene.RemoveGameObject(spawnGuid);
                scene = scene.Add(template);
            }
        }

        var generator = scene.FindGameObject(enemyGenerator.GameObject.Guid)!;

        var poolObject = generator.Children
            .Select(child => new { Child = child, Pool = child.FindComponent<app.EnemyPool>() })
            .Where(x => x.Pool != null)
            .Select(x => x.Child)
            .Single();

        var poolComponent = poolObject.FindComponent<app.EnemyPool>()!;
        //poolComponent.ExternalInstancePoolRefs.Clear();

        var newChildren = poolObject.Children.ToList();

        foreach (var pooled in pooledObjects)
        {
            if (!newChildren.Any(c => c.Guid == pooled.Guid))
            {
                newChildren.Add(pooled);
            }
        }

        poolObject.Children = newChildren.ToImmutableArray();

        poolObject = poolObject.AddOrUpdateComponent(poolComponent);

        scene = scene.UpdateGameObject(poolObject);

        return scene;
    }

    private void ProcessArea(
        Area area,
        Randomizer randomizer,
        RandomizerLogger logger,
        IReadOnlyList<EnemyTableEntry> enemyPool,
        EnemyRandomizerOptions options,
        Rng rng,
        EnemyHealthResolver healthResolver)
    {
        logger.Push(area.Path);

        var areaEnemyPool = SelectAreaEnemyPool(enemyPool, options.EnemyVariety, rng);
        logger.LogLine($"Area enemy pool ({areaEnemyPool.Length}/{enemyPool.Count}): {string.Join(", ", areaEnemyPool.Select(entry => entry.Enemy.Name))}");

        var generatorChanges = new List<(EnemyGeneratorWrapper Generator, List<(Guid, IEnemyDefinition)> Replacements)>();
        foreach (var enemyGenerator in area.EnemyGenerators)
        {
            var spawnInfos = enemyGenerator.EnemySpawnInfos;

            if (spawnInfos.Length == 0)
                continue;

            logger.Push($"Generator '{enemyGenerator.Generator.Alias}' ({spawnInfos.Length} EnemySpawnInfos)");

            var packSelector = new EnemyPackSelector(areaEnemyPool, options.MaxPackSize, rng);
            var replacements = new List<(Guid, IEnemyDefinition)>();
            foreach (var spawnInfo in spawnInfos)
            {
                if (!ShouldReplaceSpawnInfo(spawnInfo))
                    continue;

                var component = spawnInfo.FindComponent<app.EnemySpawnInfo>()!;
                var replacement = packSelector.Next();

                logger.LogLine($"Replacing {component.UnitAlias} with {replacement.Name} ({spawnInfo.Name})");
                replacements.Add((spawnInfo.Guid, replacement));
            }

            if (replacements.Count > 0)
            {
                generatorChanges.Add((enemyGenerator, replacements));
            }

            logger.Pop();
        }

        if (generatorChanges.Count > 0)
        {
            randomizer.FileRepository.ModifyScnFile(area.Path, scene =>
            {
                foreach (var (generator, replacements) in generatorChanges)
                {
                    scene = ProcessGeneratorScene(scene, randomizer, logger, generator, replacements, options, rng, healthResolver);
                }
                return scene;
            });
        }

        logger.Pop();
    }

    private ImmutableArray<EnemyTableEntry> CreateEnemyPool(Randomizer randomizer, bool includeBosses = true)
    {
        var enemyPool = ImmutableArray.CreateBuilder<EnemyTableEntry>();
        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            if (!includeBosses && enemy.IsBoss)
                continue;

            var ratio = randomizer.GetConfigOption<double>($"enemy-ratio-{enemy.Id.ToLowerInvariant()}");
            if (ratio != 0)
            {
                enemyPool.Add(new EnemyTableEntry(enemy, ratio));
            }
        }

        return enemyPool.ToImmutable();
    }

    private ImmutableArray<EnemyTableEntry> CreateExtraEnemyPool(Randomizer randomizer)
    {
        var enemyPool = ImmutableArray.CreateBuilder<EnemyTableEntry>();
        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            if (enemy.EnemyId is EnemyID.Em3300) // Elder Eveline
                continue;

            if (enemy.IsBoss && enemy.EnemyId != EnemyID.Em3600)
                continue;

            if (enemy.IsInsect)
                continue;

            var ratio = randomizer.GetConfigOption<double>($"enemy-ratio-{enemy.Id.ToLowerInvariant()}");
            if (ratio != 0)
            {
                enemyPool.Add(new EnemyTableEntry(enemy, ratio));
            }
        }

        // Mia
        enemyPool.Add(new EnemyTableEntry(new MiaChainsaw(), 0.25f)); // TODO Config
        return enemyPool.ToImmutable();
    }

    private IEnemyDefinition GetRandomBoss(Rng rng)
    {
        if (_bossTable == null)
        {
            _bossTable = new Rng.Table<IEnemyDefinition>(rng);
            foreach (var boss in EnemyDefinitions.Instance.Bosses)
            {
                _bossTable.Add(boss, 0.5d);
            }
        }

        return _bossTable.Next();
    }

    private void RandomizeEnemies(Randomizer randomizer, RandomizerLogger logger, EnemyRandomizerOptions options, EnemyHealthResolver healthResolver)
    {
        if (!randomizer.GetConfigOption<bool>("random-enemies"))
            return;

        var rng = randomizer.GetRng(RandomizerKey);
        var enemyPool = CreateEnemyPool(randomizer);

        if (enemyPool.IsDefaultOrEmpty)
        {
            logger.LogLine("Constructed an empty enemy table! Aborting...");
            return;
        }
        else
        {
            logger.LogLine($"Constructed an enemy table of size {enemyPool.Length}:");
            logger.LogLine(string.Join(", ", enemyPool.Select(entry => entry.Enemy.Name)));
        }

        var areaService = randomizer.AreaService;
        areaService.Areas.ToList().ForEach(area => ProcessArea(area, randomizer, logger, enemyPool, options, rng, healthResolver));
    }

    private static RszGameObject CloneGameObject(RszGameObject rootGameObject, Rng rng)
    {
        var guidMap = new Dictionary<Guid, Guid>();
        var root = rootGameObject.VisitGameObjects(gameObject =>
        {
            var newGuid = rng.NextGuid();
            guidMap[gameObject.Guid] = newGuid;
            return gameObject.WithGuid(newGuid);
        });

        return ReplaceGameObjectRefs(root, guidMap);
    }

    private static RszGameObject ReplaceGameObjectRefs(
        RszGameObject gameObject,
        Dictionary<Guid, Guid> guidMap)
    {
        return gameObject.Visit(node =>
        {
            if (node is RszValueNode valueNode && valueNode.Type == RszFieldType.GameObjectRef)
            {
                var refGuid = RszSerializer.Deserialize<Guid>(valueNode);
                if (guidMap.TryGetValue(refGuid, out var newGuid))
                {
                    return RszSerializer.Serialize(RszFieldType.GameObjectRef, newGuid);
                }
            }

            return node;
        });
    }

    private RszGameObject CreateExtraEnemyGameObject(
        Randomizer randomizer,
        RandomizerLogger logger,
        ExtraEnemyPlacement placement,
        IEnemyDefinition definition,
        EnemyRandomizerOptions options,
        Rng rng)
    {
        var enemyId = definition.EnemyId.ToString();
        logger.LogLine($"{definition.Name} at {placement.PosX}/{placement.PosY}/{placement.PosZ}");
        var transform = new via.Transform()
        {
            Position = new Vector3(placement.PosX, placement.PosY, placement.PosZ),
            Rotation = new Quaternion(placement.RotX, placement.RotY, placement.RotZ, placement.RotW),
            Scale = Vector3.One,
        };

        var template = GetOrCreateEnemyTemplate(
            randomizer,
            enemyId,
            transform,
            updateTransform: true,
            randomizeScale: true,
            options.ScaleOptions,
            rng);

        return template.WithName(template.Name + "_Extra");
    }

    private static bool IsRandomExtraEnemyId(string id)
        => id.Equals("random", StringComparison.OrdinalIgnoreCase);

    private static ImmutableArray<ExtraEnemyPlacement> SelectRandomExtraEnemyPlacementsWithoutReplacement(
        List<ExtraEnemyPlacement> placements,
        int count,
        Rng rng)
    {
        if (count >= placements.Count)
            return [.. placements];

        var remainingPlacements = placements.ToList();
        var selectedPlacements = ImmutableArray.CreateBuilder<ExtraEnemyPlacement>(Math.Max(0, count));
        while (selectedPlacements.Count < count && remainingPlacements.Count > 0)
        {
            var selectedPlacement = rng.Next(remainingPlacements);
            selectedPlacements.Add(selectedPlacement);
            remainingPlacements.Remove(selectedPlacement);
        }

        return selectedPlacements.ToImmutable();
    }

    private void PlaceExtraEnemies(Randomizer randomizer, RandomizerLogger logger, EnemyRandomizerOptions options)
    {
        var extraEnemyPct = randomizer.GetConfigOption<double>("extra-enemy-amount");
        if (extraEnemyPct == 0)
            return;

        var rng = randomizer.GetRng("modifier/extra-enemies");
        var extraEnemyProbability = (int)Math.Round(Math.Clamp(extraEnemyPct, 0.0, 1.0) * 100.0, MidpointRounding.AwayFromZero);
        var enemyMultiplier = randomizer.GetConfigOption("enemy-multiplier", 1.0);

        var extraEnemies = Csv.Deserialize<ExtraEnemyPlacement>(randomizer.DynamicData.GetData(DynamicDataName.ExtraEnemies)!)
            .Where(extraEnemy => extraEnemy.Enabled)
            .Where(_ => rng.NextProbability(extraEnemyProbability))
            .GroupBy(extraEnemy => extraEnemy.SceneFile)
            .ToList();

        logger.Push("Additional enemies");
        var hasRandomExtraEnemies = extraEnemies.Any(group => group.Any(extraEnemy => IsRandomExtraEnemyId(extraEnemy.Id)));
        var randomEnemyPool = hasRandomExtraEnemies
            ? CreateExtraEnemyPool(randomizer)
            : [];
        if (hasRandomExtraEnemies && randomEnemyPool.IsDefaultOrEmpty)
        {
            logger.LogLine("Constructed an empty enemy table! Random extra enemies will be skipped.");
        }

        foreach (var enemySceneGroup in extraEnemies)
        {
            var scene = enemySceneGroup.Key;
            var scenePlacements = enemySceneGroup.ToList();
            var targetEnemyCount = EnemyMultiplierModifier.GetTargetEnemyCount(scenePlacements.Count, enemyMultiplier);
            if (targetEnemyCount == 0)
                continue;

            var selectedPlacements = SelectRandomExtraEnemyPlacementsWithoutReplacement(
                scenePlacements,
                Math.Min(targetEnemyCount, scenePlacements.Count),
                rng);
            var sceneHasRandomExtraEnemies = selectedPlacements.Any(extraEnemy => IsRandomExtraEnemyId(extraEnemy.Id));

            logger.Push(enemyMultiplier == 1.0
                ? scene
                : $"{scene} ({scenePlacements.Count} => {targetEnemyCount})");
            randomizer.FileRepository.ModifyScnFile(scene, root =>
            {
                var areaEnemyPool = !sceneHasRandomExtraEnemies || randomEnemyPool.IsDefaultOrEmpty
                    ? []
                    : SelectAreaEnemyPool(randomEnemyPool, options.EnemyVariety, rng);
                var packSelector = areaEnemyPool.IsDefaultOrEmpty
                    ? null
                    : new EnemyPackSelector(areaEnemyPool, options.MaxPackSize, rng);

                var addedExtraEnemies = new List<RszGameObject>(targetEnemyCount);
                foreach (var extraEnemy in selectedPlacements)
                {
                    IEnemyDefinition definition;
                    if (IsRandomExtraEnemyId(extraEnemy.Id))
                    {
                        if (packSelector == null)
                        {
                            logger.LogLine($"Skipping random extra enemy at {extraEnemy.PosX}/{extraEnemy.PosY}/{extraEnemy.PosZ}: empty enemy table.");
                            continue;
                        }

                        definition = packSelector.Next();
                    }
                    else
                    {
                        definition = EnemyDefinitions.Instance.FromId(extraEnemy.Id)
                            ?? throw new InvalidOperationException($"Unknown extra enemy id '{extraEnemy.Id}'.");
                    }

                    var extraEnemyGameObject = CreateExtraEnemyGameObject(randomizer, logger, extraEnemy, definition, options, rng);
                    addedExtraEnemies.Add(extraEnemyGameObject);
                    root = root.Add(extraEnemyGameObject);
                }

                while (addedExtraEnemies.Count < targetEnemyCount && addedExtraEnemies.Count != 0)
                {
                    var source = rng.Next(addedExtraEnemies);
                    var duplicate = CloneGameObject(source, rng);

                    logger.LogLine($"Duplicating {source.Name} ({source.Guid} => {duplicate.Guid})");
                    addedExtraEnemies.Add(duplicate);
                    root = root.Add(duplicate);
                }

                return root;
            });
            logger.Pop();
        }

        logger.Pop();
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var options = BuildOptions(randomizer);
        if (options.DebugUniqueHp)
        {
            logger.LogUniqueSpawnHpHelp();
        }

        var healthResolver = new EnemyHealthResolver(randomizer, options, randomizer.GetRng("modifier/enemy-health"));
        RandomizeEnemies(randomizer, logger, options, healthResolver);
        PlaceExtraEnemies(randomizer, logger, options);
    }
}
