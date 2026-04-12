using Biohazard.BioRand.RE7.Enemies;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Reflection.Emit;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyModifier : Modifier
{
    private const string RandomizerKey = "modifier/enemies";

    #region Config wrappers
    internal record EnemyRandomizerOptions(
        int EnemyVariety,
        int MaxPackSize,
        bool DebugUniqueHp,
        bool IsBalanced,
        bool ProgressiveDifficulty,
        HealthOptions Health,
        ScaleOptions Scale,
        SpeedOptions Speed
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

    internal record SpeedOptions(
        double Probability,
        float Min,
        float Max,
        bool ExcludeQuickMoldeds
    );
    #endregion

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
            ),

            Speed: new SpeedOptions(
                Probability: randomizer.GetConfigOption<double>("enemy-speed-probability", 0),
                Min: Math.Clamp(randomizer.GetConfigOption("enemy-speed-min", 0.25f), 0.1f, 10.0f),
                Max: Math.Clamp(randomizer.GetConfigOption("enemy-speed-max", 2.00f), 0.1f, 10.0f),
                ExcludeQuickMoldeds: randomizer.GetConfigOption<bool>("enemy-speed-exclude-four-legged-moldeds")
            )
        );
    }

    private readonly Dictionary<string, RszGameObject> _generatorTemplateCache = new();

    private RszGameObject GetOrCreateEnemyTemplate(
        Randomizer randomizer,
        string enemyId,
        Guid newGuid,
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

        if (updateTransform)
        {
            baseTemplate = baseTemplate.AddOrUpdateComponent(transform);
        }

        return baseTemplate
            .WithGuid(newGuid)
            .WithName(enemyId);
    }

    private RszGameObject ApplySpawnInfoProperties(app.EnemySpawnInfo originalSpawnInfoGO, RszGameObject newSpawnInfoGO)
    {
        var spawnInfo = newSpawnInfoGO.FindComponent<app.EnemySpawnInfo>()!;

        // Retain original properties that are not set by the template
        spawnInfo.IsForceSpawn = originalSpawnInfoGO.IsForceSpawn;
        spawnInfo.CanSpawnAndSetupForForceSpawn = originalSpawnInfoGO.CanSpawnAndSetupForForceSpawn;
        spawnInfo.IsPermitDelayGenerate = originalSpawnInfoGO.IsPermitDelayGenerate;
        spawnInfo.IsInvalidateCollisionAtStart = originalSpawnInfoGO.IsInvalidateCollisionAtStart;
        spawnInfo.IsPlayerTargetingAtStart = originalSpawnInfoGO.IsPlayerTargetingAtStart;
        spawnInfo.IsWaitRequestCommandAction = originalSpawnInfoGO.IsWaitRequestCommandAction;

        spawnInfo.resumeParameter.ResumePoints.Clear();
        spawnInfo.MyGUID = Guid.NewGuid();

        // TODO Health
        // TODO Resume/Suspend params?
        // TODO Molded BackupParams

        newSpawnInfoGO = newSpawnInfoGO.AddOrUpdateComponent(spawnInfo);
        return newSpawnInfoGO;
    }

    private RszScene ProcessGeneratorScene(
        RszScene scene,
        Randomizer randomizer,
        RandomizerLogger logger,
        EnemyGeneratorWrapper enemyGenerator,
        IEnumerable<(Guid spawnGuid, IEnemyDefinition enemy)> replacements)
    {
        var pooledObjects = new Dictionary<string, RszGameObject>();

        foreach (var (spawnGuid, newEnemy) in replacements)
        {
            var enemyId = newEnemy.EnemyId.ToString();

            var originalGO = scene.FindGameObject(spawnGuid)!;
            var transform = originalGO.FindComponent<via.Transform>()!;
            var originalSpawnInfo = originalGO.FindComponent<app.EnemySpawnInfo>()!;

            if (newEnemy.UsesEnemyGenerator)
            {
                // Replace SpawnInfo
                var newSpawnInfo = randomizer.TemplateService
                    .GetEnemySpawnInfo(enemyId)
                    .WithGuid(spawnGuid)
                    .AddOrUpdateComponent(transform);

                newSpawnInfo = ApplySpawnInfoProperties(originalSpawnInfo, newSpawnInfo);

                var enemySave = newSpawnInfo.FindComponent<app.EnemySave>();
                if (enemySave != null)
                {
                    enemySave.SaveGUID = Guid.NewGuid();
                    newSpawnInfo = newSpawnInfo.AddOrUpdateComponent(enemySave);
                }

                scene = scene.ReplaceGameObject(spawnGuid, newSpawnInfo, keepChildren: false);

                var spawnInfoComp = newSpawnInfo.FindComponent<app.EnemySpawnInfo>()!;
                spawnInfoComp.UnitAlias = enemyId;
                newSpawnInfo = newSpawnInfo.AddOrUpdateComponent(spawnInfoComp);

                // Prepare pooled object (deduped)
                if (!pooledObjects.ContainsKey(enemyId))
                {
                    var template = GetOrCreateEnemyTemplate(
                        randomizer,
                        enemyId,
                        Guid.NewGuid(),
                        transform,
                        updateTransform: false);

                    pooledObjects[enemyId] = template;
                }
            }
            else
            {
                // Static enemy: remove SpawnInfo and insert template
                var template = GetOrCreateEnemyTemplate(
                    randomizer,
                    enemyId,
                    Guid.NewGuid(),
                    transform,
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
        poolComponent.ExternalInstancePoolRefs.Clear();

        var newChildren = poolObject.Children.ToList();

        foreach (var pooled in pooledObjects.Values)
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
        EnemyRandomizerOptions options,
        RandomizerLogger logger,
        Rng.Table<IEnemyDefinition> enemyTable)
    {
        logger.Push(area.Path);

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

            randomizer.FileRepository.ModifyScnFile(area.Path, randomizer.IsOnRaytracingVersion, scene =>
            {
                return ProcessGeneratorScene(scene, randomizer, logger, enemyGenerator, replacements);
            });

            logger.Pop();
        }

        logger.Pop();
    }

    private Rng.Table<IEnemyDefinition> CreateEnemyTable(Randomizer randomizer, Rng rng)
    {
        Rng.Table<IEnemyDefinition> table = rng.CreateProbabilityTable<IEnemyDefinition>();
        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            var ratio = randomizer.GetConfigOption<double>($"enemy-ratio-{enemy.Id.ToLowerInvariant()}");
            if (ratio != 0)
            {
                table.Add(enemy, ratio);
            }
        }

        return table;
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-enemies"))
            return;

        var options = BuildOptions(randomizer);
        var rng = randomizer.GetRng(RandomizerKey);
        var enemyTable = CreateEnemyTable(randomizer, rng);

        if (enemyTable.IsEmpty)
        {
            logger.LogLine("Constructed an empty enemy table! Aborting...");
            return;
        }

        var areaService = randomizer.AreaService;
        //Parallel.ForEach(areaService.Areas, area => ProcessArea(area, randomizer, options, logger, enemyTable));
        // messes up logging
        areaService.Areas.ToList().ForEach(area => ProcessArea(area, randomizer, options, logger, enemyTable));
    }
}