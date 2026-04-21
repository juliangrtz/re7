using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyModifier : Modifier
{
    private const string RandomizerKey = "modifier/enemies";

    internal record EnemyRandomizerOptions(
        int EnemyVariety,
        int MaxPackSize,
        bool DebugUniqueHp,
        bool IsBalanced,
        bool ProgressiveDifficulty,
        HealthOptions Health,
        ScaleOptions Scale
    );

    internal record HealthOptions(
        bool RandomEnemyHealth,
        bool RandomBossHealth
    );

    internal record ScaleOptions(
        double Probability,
        float Min,
        float Max
    );

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

            Health: new HealthOptions(
                RandomEnemyHealth: randomizer.GetConfigOption<bool>("enemy-random-health"),
                RandomBossHealth: randomizer.GetConfigOption<bool>("boss-random-health")
            ),

            Scale: new ScaleOptions(
                Probability: randomizer.GetConfigOption<double>("enemy-scale-probability", 0),
                Min: Math.Clamp(randomizer.GetConfigOption("enemy-scale-min", 0.25f), 0.1f, 10.0f),
                Max: Math.Clamp(randomizer.GetConfigOption("enemy-scale-max", 2.00f), 0.1f, 10.0f)
            )
        );
    }

    private readonly Dictionary<string, RszGameObject> _generatorTemplateCache = new();
    private readonly Dictionary<string, RszGameObject> _spawnInfoTemplateCache = new();
    private readonly Dictionary<string, (bool IsSafe, string? Reason)> _generatorTemplateCompatibilityCache = new(StringComparer.OrdinalIgnoreCase);

    private RszGameObject GetOrCreateEnemyTemplate(
        Randomizer randomizer,
        string enemyId,
        via.Transform transform,
        bool updateTransform)
    {
        if (!_generatorTemplateCache.TryGetValue(enemyId, out var baseTemplate))
        {
            baseTemplate = randomizer.TemplateService
                .GetEnemyTemplate(enemyId)
                .WithName(enemyId);

            _generatorTemplateCache[enemyId] = baseTemplate;
        }

        var template = baseTemplate.Clone();

        if (updateTransform)
        {
            template = template.AddOrUpdateComponent(transform);
        }

        return template.WithName(enemyId);
    }

    private RszGameObject GetOrCreateSpawnInfoTemplate(
        Randomizer randomizer,
        string enemyId)
    {
        if (!_spawnInfoTemplateCache.TryGetValue(enemyId, out var template))
        {
            template = randomizer.TemplateService
                .GetEnemySpawnInfo(enemyId)
                .WithName(enemyId);

            _spawnInfoTemplateCache[enemyId] = template;
        }

        return template
            .Clone()
            .WithName($"ESI_{enemyId}");
    }

    private bool IsGeneratorTemplateSafe(string enemyId, out string? reason)
    {
        if (enemyId == "Em8001") // Nightmare DLC Jack{
        {
            reason = "Nightmare Jack is still bugged!";
            return false;
        }

        reason = null;
        return true;
    }

    private RszScene ProcessGeneratorScene(
        RszScene scene,
        Randomizer randomizer,
        EnemyGeneratorWrapper enemyGenerator,
        IEnumerable<(Guid spawnGuid, IEnemyDefinition enemy)> replacements)
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
                var newSpawnOptions = GetOrCreateSpawnInfoTemplate(randomizer, enemyId).FindComponent(newEnemy.SpawnOptionType!)!;
                originalSpawnInfoGameObject.Components = originalSpawnInfoGameObject.Components
                    .Remove(originalSpawnOptions)
                    .Add(newSpawnOptions);
                originalSpawnInfoGameObject.AddOrUpdateComponent(newSpawnOptions);

                originalSpawnInfoComponent.UnitAlias = enemyId;
                originalSpawnInfoGameObject = originalSpawnInfoGameObject
                    .AddOrUpdateComponent(originalSpawnInfoComponent)
                    .WithName(originalSpawnInfoGameObject.Name + "_Now_" + enemyId);

                scene = scene.UpdateGameObject(originalSpawnInfoGameObject);

                var template = GetOrCreateEnemyTemplate(
                        randomizer,
                        enemyId,
                        originalTransform,
                        updateTransform: false
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
                    updateTransform: true)
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
        Rng.Table<IEnemyDefinition> enemyTable)
    {
        logger.Push(area.Path);

        var generatorChanges = new List<(EnemyGeneratorWrapper Generator, List<(Guid, IEnemyDefinition)> Replacements)>();
        foreach (var enemyGenerator in area.EnemyGenerators)
        {
            var spawnInfos = enemyGenerator.EnemySpawnInfos;

            if (spawnInfos.Length == 0)
                continue;

            logger.Push($"Generator '{enemyGenerator.Generator.Alias}' ({spawnInfos.Length} EnemySpawnInfos)");

            var replacements = new List<(Guid, IEnemyDefinition)>();
            foreach (var spawnInfo in spawnInfos)
            {
                var component = spawnInfo.FindComponent<app.EnemySpawnInfo>()!;
                if (!component.Enabled)
                    continue;

                var replacement = enemyTable.Next();

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
                    scene = ProcessGeneratorScene(scene, randomizer, generator, replacements);
                }
                return scene;
            });
        }

        logger.Pop();
    }

    private Rng.Table<IEnemyDefinition> CreateEnemyTable(Randomizer randomizer, RandomizerLogger logger, Rng rng)
    {
        Rng.Table<IEnemyDefinition> table = rng.CreateProbabilityTable<IEnemyDefinition>();
        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            var ratio = randomizer.GetConfigOption<double>($"enemy-ratio-{enemy.Id.ToLowerInvariant()}");
            if (ratio != 0)
            {
                var enemyId = enemy.EnemyId.ToString();
                if (!IsGeneratorTemplateSafe(enemyId, out var reason))
                {
                    logger.LogLine($"Skipping {enemy.Name} ({enemyId}) for generator randomization: {reason}");
                    continue;
                }

                table.Add(enemy, ratio);
            }
        }

        return table;
    }

    private void RandomizeEnemies(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-enemies"))
            return;

        var options = BuildOptions(randomizer);
        var rng = randomizer.GetRng(RandomizerKey);
        var enemyTable = CreateEnemyTable(randomizer, logger, rng);

        if (enemyTable.IsEmpty)
        {
            logger.LogLine("Constructed an empty enemy table! Aborting...");
            return;
        }
        else
        {
            logger.LogLine($"Constructed an enemy table of size {enemyTable.Count}:");
            logger.LogLine(string.Join(", ", enemyTable.Values.Select(em => em.Name)));
        }

        var areaService = randomizer.AreaService;
        areaService.Areas.ToList().ForEach(area => ProcessArea(area, randomizer, logger, enemyTable));
    }

    private (RszGameObject, Guid) AddEnemyToGenerator(
        Randomizer randomizer,
        RszGameObject generator,
        ExtraEnemyPlacement placement,
        via.Transform transform)
    {
        var pool = generator.Children[0];
        var template = GetOrCreateEnemyTemplate(randomizer, placement.Id, new via.Transform(), true).Clone();
        pool.Children = pool.Children.Add(template);

        var spawnPoints = pool.Children[0];
        var spawnInfo = GetOrCreateSpawnInfoTemplate(randomizer, placement.Id).Clone();
        var spawnInfoGuid = Guid.NewGuid();
        spawnInfo = spawnInfo.AddOrUpdateComponent(transform);
        spawnInfo = spawnInfo.WithGuid(spawnInfoGuid);

        spawnPoints.Children = spawnPoints.Children.Add(spawnInfo);

        pool = pool.AddOrUpdateChild(spawnPoints);
        generator = generator.AddOrUpdateChild(pool);

        return (generator, spawnInfoGuid);
    }

    private RszGameObject CreateFsmGenerator(Randomizer randomizer, Guid spawnInfoGuid)
    {
        var fsmGenerator = randomizer.TemplateService.GetObject("FsmGenerator").Clone();
        fsmGenerator = fsmGenerator.WithName(fsmGenerator.Name + spawnInfoGuid);
        return fsmGenerator.Visit(node =>
        {
            if (node is RszValueNode valueNode && valueNode.Type == RszFieldType.GameObjectRef)
            {
                var refGuid = RszSerializer.Deserialize<Guid>(valueNode);
                return RszSerializer.Serialize(RszFieldType.GameObjectRef, spawnInfoGuid);
            }
            return node;
        });
    }

    private RszScene AddEnemyToScene(
        Randomizer randomizer,
        RandomizerLogger logger,
        RszScene scene,
        ExtraEnemyPlacement placement,
        RszGameObject generator)
    {
        var definition = EnemyDefinitions.Instance.FromId(placement.Id)!;
        logger.LogLine($"{definition.Name} at {placement.PosX}/{placement.PosY}/{placement.PosZ}");
        var transform = new via.Transform()
        {
            Position = new Vector3(placement.PosX, placement.PosY, placement.PosZ),
            Rotation = new Quaternion(placement.RotX, placement.RotY, placement.RotZ, placement.RotW),
            Scale = Vector3.One,
        };

        if (definition.UsesEnemyGenerator)
        {
            var (newGenerator, spawnInfoGuid) = AddEnemyToGenerator(randomizer, generator, placement, transform);
            generator = newGenerator;
            scene = scene.Add(generator);
            scene = scene.Add(CreateFsmGenerator(randomizer, spawnInfoGuid));
        }
        else
        {
            var template = GetOrCreateEnemyTemplate(randomizer, placement.Id, transform, true);
            template = template.WithName(template.Name + "_Extra");
            scene = scene.Add(template);
        }

        return scene;
    }

    private void PlaceExtraEnemies(Randomizer randomizer, RandomizerLogger logger)
    {
        var extraEnemyPct = randomizer.GetConfigOption<double>("extra-enemy-amount");
        if (extraEnemyPct == 0)
            return;

        var extraEnemies = Csv.Deserialize<ExtraEnemyPlacement>(randomizer.DynamicData.GetData(DynamicDataName.ExtraEnemies)!)
            .Where(extraEnemy => extraEnemy.Enabled)
            .GroupBy(extraEnemy => extraEnemy.SceneFile)
            .ToList();

        logger.Push("Additional enemies");
        foreach (var enemySceneGroup in extraEnemies)
        {
            var scene = enemySceneGroup.Key;
            logger.Push(scene);
            randomizer.FileRepository.ModifyScnFile(scene, root =>
            {
                var generator = randomizer.TemplateService.GetObject("EnemyGenerator").Clone();
                foreach (var extraEnemy in enemySceneGroup)
                {
                    root = AddEnemyToScene(randomizer, logger, root, extraEnemy, generator);
                }

                return root;
            });
            logger.Pop();
        }

        logger.Pop();
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        RandomizeEnemies(randomizer, logger);
        PlaceExtraEnemies(randomizer, logger);
    }
}
