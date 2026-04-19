using Biohazard.BioRand.RE7.Enemies;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

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
    private readonly Dictionary<string, RszGameObject> _spawnInfoTemplateCache = new();

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
            .Clone()
            .WithGuid(newGuid)
            .WithName(enemyId);
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
                        Guid.NewGuid(),
                        originalTransform,
                        updateTransform: false
                );
                pooledObjects[enemyId] = template;
            }
            else
            {
                // Static enemy: remove SpawnInfo and insert template
                var template = GetOrCreateEnemyTemplate(
                    randomizer,
                    enemyId,
                    Guid.NewGuid(),
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
                    scene = ProcessGeneratorScene(scene, randomizer, logger, generator, replacements);
                }
                return scene;
            });
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
