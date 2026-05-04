using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyModifier : Modifier
{
    private const string RandomizerKey = "modifier/enemies";
    internal const string ExtraEnemyGeneratorName = "BioRandExtraEnemyGenerator";
    internal const string ExtraEnemyPoolName = "BioRandExtraEnemyPool";
    internal const string ExtraEnemySpawnPointsName = "BioRandExtraEnemySpawnPoints";
    internal const string ExtraEnemySpawnInfoPrefix = "BioRandExtraEnemySpawnInfo";
    internal const string ExtraEnemyGeneratePrefix = "BioRandExtraEnemyGenerate";
    private const string EnemyGenerationFsmFolderName = "EnemyGenFsm";
    private const string ExtraEnemyGenerateFsmResource = "LevelDesign/Fsm/Template/TempFsm_TriggerInAction_EnemyGenerate5.fsm";
    private static readonly IReadOnlyDictionary<int, string> ExtraEnemyGeneratorSceneByChapter = new Dictionary<int, string>()
    {
        [1] = "natives/stm/scenes/chapter/chapter1/enemy_c01.scn.20",
        [3] = "natives/stm/scenes/chapter/chapter3/enemy_c03.scn.20",
        [4] = "natives/stm/scenes/chapter/chapter4/enemy_c04.scn.20",
    };
    private static readonly uint[] ExtraEnemyGenerateActionUids =
    [
        2860522480,
    ];

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

    private sealed record ResolvedExtraEnemyPlacement(
        ExtraEnemyPlacement Placement,
        IEnemyDefinition Enemy
    );

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
            && !_barnFightMoldeds.Contains(spawnInfoGameObject.Guid)
            && !IsExtraEnemySpawnInfo(spawnInfoGameObject);
    }

    internal static bool IsExtraEnemySpawnInfo(RszGameObject gameObject)
    {
        var spawnInfo = gameObject.FindComponent<app.EnemySpawnInfo>();
        return spawnInfo?.Comment.StartsWith(ExtraEnemySpawnInfoPrefix, StringComparison.Ordinal) == true;
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
        Rng rng,
        IEnemyDefinition? definition = null)
    {
        if (!_generatorTemplateCache.TryGetValue(enemyId, out var baseTemplate))
        {
            baseTemplate = randomizer.TemplateService
                .GetEnemyTemplate(enemyId)
                .WithName(enemyId);

            _generatorTemplateCache[enemyId] = baseTemplate;
        }

        var template = CloneGameObject(baseTemplate, rng);
        definition ??= EnemyDefinitions.Instance.FromId(enemyId)
            ?? throw new InvalidOperationException($"Unknown enemy definition for '{enemyId}'.");
        template = definition.IndividualizeTemplate(rng, template);

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
                var originalSpawnOptions = originalSpawnInfoGameObject.Components.Single(c => c.Type.Name.Contains("EnemySpawnInfoOption"));
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

            if (!enemy.UsesEnemyGenerator)
                continue;

            var ratio = randomizer.GetConfigOption<double>($"enemy-ratio-{enemy.Id.ToLowerInvariant()}");
            if (ratio != 0)
            {
                enemyPool.Add(new EnemyTableEntry(enemy, ratio));
            }
        }

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

    private RszGameObject CreateExtraEnemySpawnInfo(
        Randomizer randomizer,
        RandomizerLogger logger,
        ResolvedExtraEnemyPlacement request,
        EnemyHealthResolver healthResolver,
        int index,
        Rng rng)
    {
        var enemyId = request.Enemy.EnemyId.ToString();
        var spawnInfo = GetOrCreateSpawnInfoTemplate(randomizer, enemyId, rng)
            .WithName(enemyId);

        var transform = spawnInfo.FindComponent<via.Transform>()!;
        transform.Position = GetPlacementPosition(request.Placement);
        transform.Rotation = GetPlacementRotation(request.Placement);
        transform.Scale = Vector3.One;
        spawnInfo = spawnInfo.AddOrUpdateComponent(transform);

        var spawnInfoComponent = spawnInfo.FindComponent<app.EnemySpawnInfo>()!;
        var assignedHealth = healthResolver.GetHealth(request.Enemy);
        spawnInfoComponent.UnitAlias = enemyId;
        spawnInfoComponent.Comment = $"{ExtraEnemySpawnInfoPrefix}_{enemyId}_{index:000}";
        spawnInfoComponent.HealthParameter.Health = assignedHealth;
        spawnInfoComponent.MyGUID = rng.NextGuid();
        spawnInfo = spawnInfo.AddOrUpdateComponent(spawnInfoComponent);
        spawnInfo = RefreshRuntimeGuids(spawnInfo, rng);

        logger.LogSpawnHealthAssignment(
            request.Enemy,
            assignedHealth,
            "extra enemy generator",
            spawnInfo.Name,
            spawnInfo.Guid);

        return spawnInfo;
    }

    private RszGameObject CreateExtraEnemyInstance(
        Randomizer randomizer,
        ResolvedExtraEnemyPlacement request,
        EnemyRandomizerOptions options,
        Rng rng)
    {
        var enemyId = request.Enemy.EnemyId.ToString();
        var transform = new via.Transform()
        {
            Position = Vector3.Zero,
            Rotation = Quaternion.Identity,
            Scale = Vector3.One,
        };

        return RefreshRuntimeGuids(GetOrCreateEnemyTemplate(
                randomizer,
                enemyId,
                transform,
                updateTransform: false,
                randomizeScale: true,
                options.ScaleOptions,
                rng,
                request.Enemy)
            .WithName(enemyId), rng);
    }

    private static RszGameObject CreateExtraEnemyFsmGenerator(
        Randomizer randomizer,
        ResolvedExtraEnemyPlacement request,
        RszGameObject spawnInfo,
        int index,
        Rng rng)
    {
        var enemyId = request.Enemy.EnemyId.ToString();
        var fsmGenerator = CloneGameObject(randomizer.TemplateService.GetEnemyFsmGenerator(), rng)
            .WithName($"{ExtraEnemyGeneratePrefix}_{enemyId}_{index:000}");

        ValidateExtraEnemyFsmGeneratorTemplate(fsmGenerator);
        ValidateExtraEnemyFsmResource(fsmGenerator);
        fsmGenerator = ConfigureExtraEnemyGenerateActions(fsmGenerator, spawnInfo.Guid);
        fsmGenerator = RefreshRuntimeGuids(fsmGenerator, rng);

        return fsmGenerator;
    }

    private static RszGameObject CreateExtraEnemyGenerator(
        Randomizer randomizer,
        IReadOnlyList<RszGameObject> spawnInfos,
        IReadOnlyList<RszGameObject> instances,
        Rng rng)
    {
        var generator = CloneGameObject(randomizer.TemplateService.GetEnemyGenerator(), rng)
            .WithName(ExtraEnemyGeneratorName);

        var generatorComponent = generator.FindComponent<app.EnemyGenerator>()!;
        generatorComponent.Alias = ExtraEnemyGeneratorName;
        generator = generator.AddOrUpdateComponent(generatorComponent);

        var pool = generator.Children.Single(child => child.FindComponent<app.EnemyPool>() != null)
            .WithName(ExtraEnemyPoolName);
        var spawnPoints = pool.Children.Single(child => child.Name == "SpawnPoints")
            .WithName(ExtraEnemySpawnPointsName)
            .WithChildren(spawnInfos.ToImmutableArray());

        var poolChildren = ImmutableArray.CreateBuilder<RszGameObject>();
        poolChildren.Add(spawnPoints);
        poolChildren.AddRange(instances);
        pool = pool.WithChildren(poolChildren.ToImmutable());

        var poolComponent = pool.FindComponent<app.EnemyPool>()!;
        poolComponent.ExternalInstancePoolRefs.Clear();
        poolComponent.ExternalInstancePoolRefs.Add(pool.Guid);
        pool = pool.AddOrUpdateComponent(poolComponent);

        return generator.WithChildren(generator.Children.Replace(
            generator.Children.Single(child => child.FindComponent<app.EnemyPool>() != null),
            pool));
    }

    private static RszScene AddExtraEnemyGenerationObjects(
        RszScene scene,
        RszGameObject generator,
        IReadOnlyCollection<RszGameObject> fsmGenerators)
    {
        scene = scene.Add(generator);
        return AddExtraEnemyFsmGenerators(scene, fsmGenerators);
    }

    private static RszScene AddExtraEnemyFsmGenerators(
        RszScene scene,
        IReadOnlyCollection<RszGameObject> fsmGenerators)
    {
        var dynamicParent = scene.FindGameObject(gameObject =>
            gameObject.Name.EndsWith("_dynamic", StringComparison.OrdinalIgnoreCase));
        if (dynamicParent != null)
        {
            var children = dynamicParent.Children
                .AddRange(fsmGenerators);
            return scene.UpdateGameObject(dynamicParent.WithChildren(children));
        }

        var fsmFolder = scene.Children
            .OfType<RszFolder>()
            .FirstOrDefault(folder => folder.Name == EnemyGenerationFsmFolderName);
        if (fsmFolder == null)
        {
            foreach (var fsmGenerator in fsmGenerators)
            {
                scene = scene.Add(fsmGenerator);
            }

            return scene;
        }

        var updatedFolder = fsmFolder.WithChildren(fsmFolder.Children.AddRange(fsmGenerators));
        return scene.WithChildren(scene.Children.Replace(fsmFolder, updatedFolder));
    }

    private static bool IsEnvironmentScene(string scene)
        => scene.Replace('\\', '/').Contains("/environment/scene/", StringComparison.OrdinalIgnoreCase);

    private static string GetExtraEnemyGeneratorScene(
        string requestScene,
        IReadOnlyCollection<ResolvedExtraEnemyPlacement> requests)
    {
        if (!IsEnvironmentScene(requestScene))
            return requestScene;

        var chapters = requests
            .Select(request => request.Placement.Chapter)
            .Distinct()
            .ToArray();
        if (chapters.Length != 1)
        {
            throw new InvalidOperationException(
                $"Extra enemy environment scene '{requestScene}' has placements for multiple chapters: {string.Join(", ", chapters)}.");
        }

        if (ExtraEnemyGeneratorSceneByChapter.TryGetValue(chapters[0], out var generatorScene))
        {
            return generatorScene;
        }

        throw new InvalidOperationException(
            $"Extra enemy environment scene '{requestScene}' is in chapter {chapters[0]}, which has no configured generator scene.");
    }

    private static RszGameObject ConfigureExtraEnemyGenerateActions(
        RszGameObject generationGameObject,
        Guid spawnInfoGuid)
    {
        var actionIndex = 0;
        var result = generationGameObject.Visit(node =>
        {
            if (node is not RszObjectNode objectNode ||
                objectNode.Type.Name != "via.fsm.SceneFsmData")
            {
                return node;
            }

            var actions = (RszArrayNode)objectNode["v1_Actions"];
            var configuredActions = ImmutableArray.CreateBuilder<IRszNode>();
            foreach (var action in actions.Children.OfType<RszObjectNode>())
            {
                if (action.Type.Name != "app.fsm.EnemyGenerate")
                    continue;

                if (actionIndex >= ExtraEnemyGenerateActionUids.Length)
                {
                    throw new InvalidOperationException(
                        $"Extra enemy generation template has more app.fsm.EnemyGenerate actions than {ExtraEnemyGenerateFsmResource} expects.");
                }

                configuredActions.Add(action
                    .SetField("v0_Enabled", true)
                    .SetField("v2_UID", ExtraEnemyGenerateActionUids[actionIndex++])
                    .SetField("SpawnInfo", spawnInfoGuid)
                    .SetField("Operation", Enums.app.EnemyGenerator.Operation.Spawn));
            }

            if (configuredActions.Count == 0)
                return node;

            var conditions = (RszArrayNode)objectNode["v2_Conditions"];
            return objectNode
                .SetField("v1_Actions", new RszArrayNode(actions.Type, configuredActions.ToImmutable()))
                .SetField("v2_Conditions", new RszArrayNode(conditions.Type, []));
        });

        if (actionIndex != ExtraEnemyGenerateActionUids.Length)
        {
            throw new InvalidOperationException(
                $"Extra enemy generation template has {actionIndex} app.fsm.EnemyGenerate actions, expected {ExtraEnemyGenerateActionUids.Length} for {ExtraEnemyGenerateFsmResource}.");
        }

        return result;
    }

    private static void ValidateExtraEnemyFsmGeneratorTemplate(RszGameObject generationGameObject)
    {
        var componentNames = generationGameObject.Components
            .Select(component => component.Type.Name)
            .ToArray();
        var unexpectedComponents = componentNames
            .Where(componentName => componentName is "app.GimmickActiveControl" or "via.physics.Colliders" or "app.TriggerInAction")
            .ToArray();
        if (unexpectedComponents.Length != 0)
        {
            throw new InvalidOperationException(
                $"Extra enemy generation template has unsupported trigger wrapper components: {string.Join(", ", unexpectedComponents)}.");
        }

        if (!componentNames.Contains("via.Transform", StringComparer.Ordinal) ||
            !componentNames.Contains("via.fsm.Fsm", StringComparer.Ordinal))
        {
            throw new InvalidOperationException(
                $"Extra enemy generation template must be a plain GameObject with via.Transform and via.fsm.Fsm; found: {string.Join(", ", componentNames)}.");
        }
    }

    private static void ValidateExtraEnemyFsmResource(RszGameObject generationGameObject)
    {
        var fsm = generationGameObject.FindComponent("via.fsm.Fsm")
            ?? throw new InvalidOperationException("Extra enemy generation template is missing via.fsm.Fsm.");
        var resource = ((RszResourceNode)fsm["Resource"]).Value;
        if (!string.Equals(resource, ExtraEnemyGenerateFsmResource, StringComparison.Ordinal))
        {
            throw new InvalidOperationException(
                $"Extra enemy generation template uses '{resource}', expected '{ExtraEnemyGenerateFsmResource}'.");
        }
    }

    private static RszGameObject RefreshRuntimeGuids(RszGameObject gameObject, Rng rng)
    {
        return gameObject.VisitComponents(component => RefreshRuntimeGuids(component, rng));
    }

    private static RszObjectNode RefreshRuntimeGuids(RszObjectNode objectNode, Rng rng)
    {
        for (var i = 0; i < objectNode.Children.Length; i++)
        {
            var fieldName = objectNode.Type.Fields[i].Name;
            if (fieldName is "SaveGUID" or "InstanceGuid" or "MyGUID")
            {
                objectNode = objectNode.SetField(fieldName, rng.NextGuid());
            }
        }

        return objectNode;
    }

    private static Vector3 GetPlacementPosition(ExtraEnemyPlacement placement)
        => new(placement.PosX, placement.PosY, placement.PosZ);

    private static Quaternion GetPlacementRotation(ExtraEnemyPlacement placement)
        => new(placement.RotX, placement.RotY, placement.RotZ, placement.RotW);

    private static bool TryCreateExtraEnemyRequest(
        RandomizerLogger logger,
        ExtraEnemyPlacement extraEnemy,
        IEnemyDefinition definition,
        out ResolvedExtraEnemyPlacement request)
    {
        if (!definition.UsesEnemyGenerator)
        {
            logger.LogLine($"Skipping {definition.Name} at {extraEnemy.PosX}/{extraEnemy.PosY}/{extraEnemy.PosZ}: enemy has no generator spawn-info template.");
            request = null!;
            return false;
        }

        logger.LogLine($"{definition.Name} at {extraEnemy.PosX}/{extraEnemy.PosY}/{extraEnemy.PosZ}");
        request = new ResolvedExtraEnemyPlacement(extraEnemy, definition);
        return true;
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

    private void PlaceExtraEnemies(
        Randomizer randomizer,
        RandomizerLogger logger,
        EnemyRandomizerOptions options,
        EnemyHealthResolver healthResolver)
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
            var sceneLimit = randomizer.EnemySceneLimitService.GetMaxEnemiesForExtraScene(scene);
            var uncappedTargetEnemyCount = EnemyMultiplierModifier.GetTargetEnemyCount(scenePlacements.Count, enemyMultiplier);
            var targetEnemyCount = sceneLimit == null
                ? uncappedTargetEnemyCount
                : Math.Min(uncappedTargetEnemyCount, sceneLimit.Value);
            if (targetEnemyCount == 0)
                continue;

            var selectedPlacements = SelectRandomExtraEnemyPlacementsWithoutReplacement(
                scenePlacements,
                Math.Min(targetEnemyCount, scenePlacements.Count),
                rng);
            var sceneHasRandomExtraEnemies = selectedPlacements.Any(extraEnemy => IsRandomExtraEnemyId(extraEnemy.Id));

            logger.Push(FormatExtraEnemySceneLog(scene, scenePlacements.Count, uncappedTargetEnemyCount, targetEnemyCount, sceneLimit));
            var extraEnemyRequests = new List<ResolvedExtraEnemyPlacement>(targetEnemyCount);
            var areaEnemyPool = !sceneHasRandomExtraEnemies || randomEnemyPool.IsDefaultOrEmpty
                ? []
                : SelectAreaEnemyPool(randomEnemyPool, options.EnemyVariety, rng);
            var packSelector = areaEnemyPool.IsDefaultOrEmpty
                ? null
                : new EnemyPackSelector(areaEnemyPool, options.MaxPackSize, rng);

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
                    var possibleEnemies = extraEnemy.Id.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                    var selectedEnemyId = possibleEnemies.Length switch
                    {
                        0 => extraEnemy.Id.Trim(),
                        1 => possibleEnemies[0],
                        _ => rng.Next(possibleEnemies),
                    };
                    definition = EnemyDefinitions.Instance.FromId(selectedEnemyId)
                        ?? throw new InvalidOperationException($"Unknown extra enemy id '{extraEnemy.Id}' (selected '{selectedEnemyId}').");
                }

                if (TryCreateExtraEnemyRequest(logger, extraEnemy, definition, out var request))
                {
                    extraEnemyRequests.Add(request);
                }
            }

            while (extraEnemyRequests.Count < targetEnemyCount && extraEnemyRequests.Count != 0)
            {
                var source = rng.Next(extraEnemyRequests);
                logger.LogLine($"Duplicating {source.Enemy.Name} at {source.Placement.PosX}/{source.Placement.PosY}/{source.Placement.PosZ}");
                extraEnemyRequests.Add(source);
            }

            if (extraEnemyRequests.Count == 0)
            {
                logger.Pop();
                continue;
            }

            var spawnInfos = new List<RszGameObject>(extraEnemyRequests.Count);
            var instances = new List<RszGameObject>(extraEnemyRequests.Count);
            var fsmGenerators = new List<RszGameObject>(extraEnemyRequests.Count);

            for (var i = 0; i < extraEnemyRequests.Count; i++)
            {
                var request = extraEnemyRequests[i];
                var spawnInfo = CreateExtraEnemySpawnInfo(randomizer, logger, request, healthResolver, i, rng);
                var instance = CreateExtraEnemyInstance(randomizer, request, options, rng);
                var fsmGenerator = CreateExtraEnemyFsmGenerator(randomizer, request, spawnInfo, i, rng);

                spawnInfos.Add(spawnInfo);
                instances.Add(instance);
                fsmGenerators.Add(fsmGenerator);
            }

            var generatorScene = GetExtraEnemyGeneratorScene(scene, extraEnemyRequests);
            var generator = CreateExtraEnemyGenerator(randomizer, spawnInfos, instances, rng);
            if (string.Equals(generatorScene, scene, StringComparison.OrdinalIgnoreCase))
            {
                randomizer.FileRepository.ModifyScnFile(scene, root =>
                    AddExtraEnemyGenerationObjects(root, generator, fsmGenerators));
            }
            else
            {
                randomizer.FileRepository.ModifyScnFile(generatorScene, root => root.Add(generator));
                randomizer.FileRepository.ModifyScnFile(scene, root => AddExtraEnemyFsmGenerators(root, fsmGenerators));
            }

            logger.Pop();
        }

        logger.Pop();
    }

    private static string FormatExtraEnemySceneLog(
        string scene,
        int placementCount,
        int uncappedTargetEnemyCount,
        int targetEnemyCount,
        int? sceneLimit)
    {
        if (sceneLimit == null && placementCount == targetEnemyCount)
        {
            return scene;
        }

        var label = $"{scene} ({placementCount} => {targetEnemyCount}";
        if (sceneLimit != null && targetEnemyCount != uncappedTargetEnemyCount)
        {
            label += $", limit {sceneLimit}";
        }

        return label + ")";
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
        PlaceExtraEnemies(randomizer, logger, options, healthResolver);
    }
}
