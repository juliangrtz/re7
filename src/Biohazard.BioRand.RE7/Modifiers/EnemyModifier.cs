namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyModifier : Modifier
{
    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {

    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-enemies"))
            return;

        var enemyVariety = randomizer.GetConfigOption<int>("enemy-variety");
        var maxPackSize = randomizer.GetConfigOption<int>("enemy-pack-max-size");

        var debugUniqueHp = randomizer.GetConfigOption<bool>("debug-unique-enemy-hp");

        var enemyScaleProbability = randomizer.GetConfigOption<double>("enemy-scale-probability", 0);
        var enemyMinScale = Math.Clamp(randomizer.GetConfigOption("enemy-scale-min", 0.25f), 0.1f, 10.0f);
        var enemyMaxScale = Math.Clamp(randomizer.GetConfigOption("enemy-scale-max", 2.00f), 0.1f, 10.0f);

        var enemySpeedProbability = randomizer.GetConfigOption<double>("enemy-speed-probability", 0);
        var enemyMinSpeed = Math.Clamp(randomizer.GetConfigOption("enemy-speed-min", 0.25f), 0.1f, 10.0f);
        var enemyMaxSpeed = Math.Clamp(randomizer.GetConfigOption("enemy-speed-max", 2.00f), 0.1f, 10.0f);
        var excludeQuickMoldeds = randomizer.GetConfigOption<bool>("enemy-speed-exclude-four-legged-moldeds");

        var progressiveDifficulty = randomizer.GetConfigOption("enemy-health-progressive-difficulty", false);

        var randomHealthEnemy = randomizer.GetConfigOption<bool>("enemy-random-health");
        var randomHealthBoss = randomizer.GetConfigOption<bool>("boss-random-health");

        var isBalanced = randomizer.GetConfigOption<bool>("balanced-enemies");

        var areaService = randomizer.AreaService;
        foreach (var area in areaService.Areas)
        {
            if (!area.EnemyGenerators.IsEmpty)
                ProcessArea(area);
        }

        static void ProcessArea(Area area)
        {
            foreach(var enemyGenerator in area.EnemyGenerators)
            {
                foreach(var esi in enemyGenerator.EnemySpawnInfos)
                {
                    // TODO
                }
            }
        }
    }
}