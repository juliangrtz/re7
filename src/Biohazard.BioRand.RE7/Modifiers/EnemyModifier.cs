using Biohazard.BioRand.RE7.Enemies;
using IntelOrca.Biohazard.REE.Rsz;

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

    private void PerformReplacement(
        Randomizer randomizer,
        RandomizerLogger logger,
        EnemyGeneratorWrapper enemyGenerator,
        string path,
        Guid spawnInfoGuid,
        IEnemyDefinition newEnemy)
    {
        // TODO Log Guids
        randomizer.FileRepository.ModifyScnFile(path, randomizer.IsOnRaytracingVersion, scene =>
        {
            var rng = randomizer.GetRng("modifier/enemy-guids");

            var enemyId = newEnemy.EnemyId.ToString();
            var spawnInfoGameObject = scene.FindGameObject(spawnInfoGuid)!;
            var transform = spawnInfoGameObject.FindComponent<via.Transform>()!;
            var newGuid = rng.NextGuid();
            var template = randomizer.TemplateService.GetEnemyTemplate(enemyId);
            template = template.WithName(enemyId);
            template = template.WithGuid(newGuid);
            template = template.AddOrUpdateComponent(transform);

            // TODO Health

            if (newEnemy.UsesEnemyGenerator)
            {
                var spawnInfo = spawnInfoGameObject.FindComponent<app.EnemySpawnInfo>()!;

                //RszGameObject? go;
                //while ((go = scene.FindGameObject(spawnInfo.UnitAlias)) != null)
                //{
                //    scene = scene.RemoveGameObject(go.Guid);
                //}

                var newSpawnInfo = randomizer.TemplateService.GetEnemySpawnInfo(enemyId);
                newSpawnInfo = newSpawnInfo.WithGuid(spawnInfoGameObject.Guid);
                spawnInfo.UnitAlias = enemyId;
                scene = scene.ReplaceGameObject(spawnInfoGameObject.Guid, newSpawnInfo, keepChildren: false);

                var generator = scene.FindGameObject(enemyGenerator.GameObject.Guid)!;
                var pool = generator.Children.Single(c => c.FindComponent<app.EnemyPool>() != null);
                pool.Children = pool.Children.Add(template);
                scene = scene.UpdateGameObject(pool);
            }
            else
            {
                //scene = scene.RemoveGameObject(spawnInfoGuid);
                spawnInfoGameObject = spawnInfoGameObject.WithGuid(Guid.Empty);
                scene = scene.UpdateGameObject(spawnInfoGameObject);

                template = template.WithName($"{template.Name}_Static");
                scene = scene.Add(template); // TODO Use BioRand folder instead
            }

            return scene;
        });
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
            var enemySpawnInfoCount = enemyGenerator.EnemySpawnInfos.Length;

            if (enemySpawnInfoCount == 0)
                continue;

            logger.Push($"Generator '{enemyGenerator.Generator.Alias}' ({enemySpawnInfoCount} EnemySpawnInfos)");

            foreach (var spawnInfo in enemyGenerator.EnemySpawnInfos)
            {
                var replacement = enemyTable.Next();
                var component = spawnInfo.FindComponent<app.EnemySpawnInfo>()!;
                logger.LogLine($"Replacing {component.UnitAlias} with {replacement.Name}"); // TODO: Extract readable name from UnitAlias
                PerformReplacement(randomizer, logger, enemyGenerator, area.Path, spawnInfo.Guid, replacement);
            }
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
        areaService.Areas.ToList().ForEach(area => ProcessArea(area, randomizer, options, logger, enemyTable));
    }
}