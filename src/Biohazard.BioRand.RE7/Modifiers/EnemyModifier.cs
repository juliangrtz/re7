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
    private static readonly HashSet<string> ExtraEnemyMoldedIds = new(StringComparer.Ordinal)
    {
        "Em4000",
        "Em4100",
        "Em4200",
    };
    private static readonly (string ScenePrefix, string MapName)[] ExtraEnemyMoldedAiMapByScenePrefix =
    [
        ("natives/stm/environment/scene/chapter3/c03_gh", "c03_AIMap"),
        ("natives/stm/environment/scene/chapter3/c03_oldhouse", "c03_AIMap"),
        ("natives/stm/environment/scene/chapter3/c03_cow", "c03_4_Lucus_Cowshed"),
        ("natives/stm/environment/scene/chapter3/c03_leftarea", "c03_4_AIMap"),
        ("natives/stm/environment/scene/chapter3/c03_boat", "c03_4_AIMap"),
        ("natives/stm/environment/scene/chapter3/", "c03_4_AIMap"),
        ("natives/stm/scenes/chapter/chapter3/chapter3_4/", "c03_4_AIMap"),
        ("natives/stm/scenes/chapter/chapter3/chapter3_3/", "c03_AIMap"),
        ("natives/stm/scenes/chapter/chapter3/", "c03_AIMap"),
        ("natives/stm/environment/scene/chapter1/", "c01_AIMap"),
        ("natives/stm/scenes/chapter/chapter1/", "c01_AIMap"),
        ("natives/stm/environment/scene/chapter4/c04_1", "c04_1_AIMap"),
        ("natives/stm/scenes/chapter/chapter4/chapter4_1/", "c04_1_AIMap"),
        ("natives/stm/environment/scene/chapter4/c04_2", "c04_2_AIMap"),
        ("natives/stm/scenes/chapter/chapter4/chapter4_2/", "c04_2_AIMap"),
    ];
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

    private sealed class ExtraEnemyGeneratorBuild
    {
        public List<RszGameObject> SpawnInfos { get; } = [];
        public List<RszGameObject> Instances { get; } = [];
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
    private static readonly HashSet<Guid> _margueritePitFightSpawns = [
        new Guid("d484bae0-a8bf-4633-a917-d0aade800111"),
        new Guid("28c36110-42dd-4a12-b6ed-389c1d97c779"),
        new Guid("d3f157fa-68b6-0270-1678-e3ab4e066613"),
        new Guid("21410999-80f4-02e8-2180-dc308b20b4e3"),
        new Guid("a2143fb9-f0d0-034d-3e86-3e6f6056b159"),
        new Guid("17e1a46c-c5a0-0db8-2359-659c65131060"),
        new Guid("c927df77-f5ef-018d-0dbb-761b332d90bf"),
        new Guid("44468ff6-b747-0f57-2472-38ce265840ea"),
        new Guid("6aa86358-9661-0e1d-3a22-107860110dd9"),
        new Guid("8ba82066-2552-0866-1b55-eb8aa5e7fa87"),
        new Guid("478ac89b-7c37-083c-297f-74e790824f22"),
        new Guid("73e69068-0827-0d3a-3612-324f64e7e264"),
        new Guid("64af1c7e-05b4-085f-0abf-15b9c233779c"),
        new Guid("3d24872f-0990-0e4f-2dbe-536696a000c3"),
        new Guid("dc4a746c-4fba-0d5f-0754-6ffae69a1a28"),
    ];
    private static readonly HashSet<string> _insectSpawnAliases = new(StringComparer.OrdinalIgnoreCase)
    {
        "Em5400",
        "Em5510",
        "Em5511",
        "Em5512",
        "Em5520",
    };
    private Rng.Table<IEnemyDefinition>? _bossTable = null;

    internal static bool ShouldReplaceSpawnInfo(RszGameObject spawnInfoGameObject)
    {
        var component = spawnInfoGameObject.FindComponent<app.EnemySpawnInfo>();
        return component?.Enabled == true
            && !_barnFightMoldeds.Contains(spawnInfoGameObject.Guid)
            && !_margueritePitFightSpawns.Contains(spawnInfoGameObject.Guid)
            && !IsExtraEnemySpawnInfo(spawnInfoGameObject);
    }

    internal static bool IsExtraEnemySpawnInfo(RszGameObject gameObject)
    {
        var spawnInfo = gameObject.FindComponent<app.EnemySpawnInfo>();
        return spawnInfo?.Comment.StartsWith(ExtraEnemySpawnInfoPrefix, StringComparison.Ordinal) == true;
    }

    internal static bool IsInsectSpawnAlias(string unitAlias)
        => _insectSpawnAliases.Contains(unitAlias);

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

    private static void RandomizeScale(GeneratedViaTransform transform, ScaleOptions scaleOptions, Rng rng)
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
        GeneratedViaTransform transform,
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
                : template.FindComponent<GeneratedViaTransform>()!;

            if (randomizeScale)
            {
                RandomizeScale(templateTransform, scaleOptions, rng);
            }

            template = template.AddOrUpdateComponent(templateTransform);
        }

        return DisableEnemyStampSerialization(template.WithName(enemyId));
    }

    private static RszGameObject DisableEnemyStampSerialization(RszGameObject gameObject)
    {
        return gameObject.VisitComponents(component =>
        {
            if (component.Type.Name == "app.StampController" &&
                component.Type.FindFieldIndex("IsSerializeTexture") != -1)
            {
                return component.SetField("IsSerializeTexture", false);
            }

            return component;
        });
    }

    private List<RszGameObject> CreatePoolInstancesForNestedSpawnInfos(
        Randomizer randomizer,
        RszGameObject template,
        EnemyRandomizerOptions options,
        Rng rng)
    {
        var nestedSpawnAliases = new List<string>();
        template.VisitGameObjects(gameObject =>
        {
            var spawnInfo = gameObject.FindComponent<app.EnemySpawnInfo>();
            if (spawnInfo?.Enabled == true && !string.IsNullOrWhiteSpace(spawnInfo.UnitAlias))
            {
                nestedSpawnAliases.Add(spawnInfo.UnitAlias);
            }
        });

        if (nestedSpawnAliases.Count == 0)
            return [];

        var instances = new List<RszGameObject>(nestedSpawnAliases.Count);
        var transform = new GeneratedViaTransform()
        {
            Position = Vector3.Zero,
            Rotation = Quaternion.Identity,
            Scale = Vector3.One,
        };

        foreach (var nestedSpawnAlias in nestedSpawnAliases)
        {
            var definition = EnemyDefinitions.Instance.FromId(nestedSpawnAlias)
                ?? throw new InvalidOperationException(
                    $"Enemy template '{template.Name}' contains a nested spawn info for unsupported enemy '{nestedSpawnAlias}'.");
            if (!definition.UsesEnemyGenerator)
            {
                throw new InvalidOperationException(
                    $"Enemy template '{template.Name}' contains a nested spawn info for non-generator enemy '{nestedSpawnAlias}'.");
            }

            instances.Add(GetOrCreateEnemyTemplate(
                randomizer,
                nestedSpawnAlias,
                transform,
                updateTransform: false,
                randomizeScale: false,
                options.ScaleOptions,
                rng,
                definition));
        }

        return instances;
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
            var originalTransform = originalSpawnInfoGameObject.FindComponent<GeneratedViaTransform>()!;
            var originalSpawnInfoComponent = originalSpawnInfoGameObject.FindComponent<app.EnemySpawnInfo>()!;

            if (newEnemy.UsesEnemyGenerator)
            {
                // Enemy that uses generator pool: Replace SpawnInfoOptions, UnitAlias and associated GameObject.
                var originalSpawnOptions = originalSpawnInfoGameObject.Components.Single(c => c.Type.Name.Contains("EnemySpawnInfoOption"));
                var spawnInfoTemplate = GetOrCreateSpawnInfoTemplate(randomizer, enemyId, rng);
                var newSpawnOptions = spawnInfoTemplate.FindComponent(newEnemy.SpawnOptionType!)!;
                var dlcSpawnOptions = spawnInfoTemplate.FindComponent("app.EnemySpawnInfoOptionDLC");
                originalSpawnInfoGameObject.AddOrUpdateComponent(newSpawnOptions);
                originalSpawnInfoGameObject = originalSpawnInfoGameObject.WithComponents(
                    originalSpawnInfoGameObject.Components
                    .Remove(originalSpawnOptions)
                    .Add(newSpawnOptions));
                if (dlcSpawnOptions != null)
                {
                    originalSpawnInfoGameObject.AddOrUpdateComponent(dlcSpawnOptions);
                    originalSpawnInfoGameObject = originalSpawnInfoGameObject.WithComponents(
                        originalSpawnInfoGameObject.Components.Add(dlcSpawnOptions));
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
                pooledObjects.AddRange(CreatePoolInstancesForNestedSpawnInfos(randomizer, template, options, rng));
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

        poolObject = poolObject.WithChildren(newChildren.ToImmutableArray());

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
            var scene = area.Scene;
            foreach (var (generator, replacements) in generatorChanges)
            {
                scene = ProcessGeneratorScene(scene, randomizer, logger, generator, replacements, options, rng, healthResolver);
            }

            area.Scene = scene;
            randomizer.FileRepository.SetScnFile(area.Path, area.ScnFile.AddMissingResources().Build());
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

            if (enemy.IsBoss)
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

        foreach (var area in randomizer.AreaService.EnemyAreas)
        {
            ProcessArea(area, randomizer, logger, enemyPool, options, rng, healthResolver);
        }
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

        var transform = spawnInfo.FindComponent<GeneratedViaTransform>()!;
        transform.Position = GetPlacementPosition(request.Placement);
        transform.Rotation = GetPlacementRotation(request.Placement);
        transform.Scale = Vector3.One;
        spawnInfo = spawnInfo.AddOrUpdateComponent(transform);

        var spawnInfoComponent = spawnInfo.FindComponent<app.EnemySpawnInfo>()!;
        var assignedHealth = healthResolver.GetHealth(request.Enemy);
        spawnInfoComponent.UnitAlias = enemyId;
        spawnInfoComponent.Comment = $"{ExtraEnemySpawnInfoPrefix}_{enemyId}_{index:000}";
        spawnInfoComponent.HealthParameter.Health = assignedHealth;
        ConfigureExtraEnemyMoldedAiMap(spawnInfoComponent, enemyId, request.Placement.SceneFile);
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

    private static void ConfigureExtraEnemyMoldedAiMap(
        app.EnemySpawnInfo spawnInfo,
        string enemyId,
        string sceneFile)
    {
        if (!ExtraEnemyMoldedIds.Contains(enemyId))
            return;

        var mapName = ResolveExtraEnemyMoldedAiMapName(sceneFile);
        if (mapName == null)
            return;

        spawnInfo.MapParameter ??= new app.EnemySpawnInfo.AIMapParameter();
        spawnInfo.MapParameter.IsUseCheck = true;
        spawnInfo.MapParameter.MapName = mapName;
        spawnInfo.MapParameter.VolumeSpaceMapName = "";
    }

    private static string? ResolveExtraEnemyMoldedAiMapName(string sceneFile)
    {
        var normalizedSceneFile = sceneFile.Replace('\\', '/');
        foreach (var (scenePrefix, mapName) in ExtraEnemyMoldedAiMapByScenePrefix)
        {
            if (normalizedSceneFile.StartsWith(scenePrefix, StringComparison.OrdinalIgnoreCase))
            {
                return mapName;
            }
        }

        return null;
    }

    private List<RszGameObject> CreateExtraEnemyInstances(
        Randomizer randomizer,
        ResolvedExtraEnemyPlacement request,
        EnemyRandomizerOptions options,
        Rng rng)
    {
        var enemyId = request.Enemy.EnemyId.ToString();
        var transform = new GeneratedViaTransform()
        {
            Position = Vector3.Zero,
            Rotation = Quaternion.Identity,
            Scale = Vector3.One,
        };

        var instance = RefreshRuntimeGuids(GetOrCreateEnemyTemplate(
                randomizer,
                enemyId,
                transform,
                updateTransform: false,
                randomizeScale: true,
                options.ScaleOptions,
                rng,
                request.Enemy)
            .WithName(enemyId), rng);
        var instances = new List<RszGameObject>()
        {
            instance,
        };
        instances.AddRange(CreatePoolInstancesForNestedSpawnInfos(randomizer, instance, options, rng)
            .Select(nestedInstance => RefreshRuntimeGuids(nestedInstance, rng)));

        return instances
            .Select(PrepareExtraEnemyPoolInstance)
            .ToList();
    }

    private static RszGameObject PrepareExtraEnemyPoolInstance(RszGameObject instance)
    {
        return instance.WithSettings(instance.Settings.SetField("Draw", false));
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
        pool = pool.AddOrUpdateComponent(poolComponent);

        return generator.WithChildren(generator.Children.Replace(
            generator.Children.Single(child => child.FindComponent<app.EnemyPool>() != null),
            pool));
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
        if (count <= 0)
            return [];

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

    internal static int GetExtraEnemySubsetCount(int placementCount, double percentage)
    {
        if (placementCount <= 0)
            return 0;

        var safePercentage = Math.Clamp(percentage, 0.0, 1.0);
        return Math.Min(
            placementCount,
            Math.Max(0, (int)Math.Round(placementCount * safePercentage, MidpointRounding.AwayFromZero)));
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
        var enemyMultiplier = randomizer.GetConfigOption("enemy-multiplier", 1.0);

        var enabledExtraEnemies = Csv.Deserialize<ExtraEnemyPlacement>(randomizer.DynamicData.GetData(DynamicDataName.ExtraEnemies)!)
            .Where(extraEnemy => extraEnemy.Enabled)
            .ToList();
        var subsetCount = GetExtraEnemySubsetCount(enabledExtraEnemies.Count, extraEnemyPct);
        if (subsetCount == 0)
            return;

        var extraEnemies = SelectRandomExtraEnemyPlacementsWithoutReplacement(enabledExtraEnemies, subsetCount, rng)
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

        var generatorBuilds = new Dictionary<string, ExtraEnemyGeneratorBuild>(StringComparer.OrdinalIgnoreCase);
        var fsmGeneratorsByScene = new Dictionary<string, List<RszGameObject>>(StringComparer.OrdinalIgnoreCase);

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

            var fsmGenerators = new List<RszGameObject>(extraEnemyRequests.Count);
            var generatorScene = GetExtraEnemyGeneratorScene(scene, extraEnemyRequests);
            if (!generatorBuilds.TryGetValue(generatorScene, out var generatorBuild))
            {
                generatorBuild = new ExtraEnemyGeneratorBuild();
                generatorBuilds.Add(generatorScene, generatorBuild);
            }

            for (var i = 0; i < extraEnemyRequests.Count; i++)
            {
                var request = extraEnemyRequests[i];
                var generatorSpawnInfoIndex = generatorBuild.SpawnInfos.Count;
                var spawnInfo = CreateExtraEnemySpawnInfo(randomizer, logger, request, healthResolver, generatorSpawnInfoIndex, rng);
                var requestInstances = CreateExtraEnemyInstances(randomizer, request, options, rng);
                var fsmGenerator = CreateExtraEnemyFsmGenerator(randomizer, request, spawnInfo, generatorSpawnInfoIndex, rng);

                fsmGenerators.Add(fsmGenerator);
                generatorBuild.SpawnInfos.Add(spawnInfo);
                generatorBuild.Instances.AddRange(requestInstances);
            }

            if (!fsmGeneratorsByScene.TryGetValue(scene, out var sceneFsmGenerators))
            {
                sceneFsmGenerators = [];
                fsmGeneratorsByScene.Add(scene, sceneFsmGenerators);
            }

            sceneFsmGenerators.AddRange(fsmGenerators);
            logger.Pop();
        }

        foreach (var (generatorScene, generatorBuild) in generatorBuilds.OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase))
        {
            var generator = CreateExtraEnemyGenerator(randomizer, generatorBuild.SpawnInfos, generatorBuild.Instances, rng);
            randomizer.FileRepository.ModifyScnFile(generatorScene, root =>
            {
                root = root.Add(generator);
                if (fsmGeneratorsByScene.Remove(generatorScene, out var fsmGenerators))
                {
                    root = AddExtraEnemyFsmGenerators(root, fsmGenerators);
                }

                return root;
            });
        }

        foreach (var (scene, fsmGenerators) in fsmGeneratorsByScene.OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase))
        {
            randomizer.FileRepository.ModifyScnFile(scene, root => AddExtraEnemyFsmGenerators(root, fsmGenerators));
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
