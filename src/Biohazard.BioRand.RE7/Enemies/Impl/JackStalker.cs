using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class JackStalker : IEnemyDefinition
{
    public string Id => "JackStalker";

    public EnemyID EnemyId => EnemyID.Em3000;

    public EnemyCategory Category => EnemyCategory.Jack;

    public string Name => "Jack Baker (Stalker)";

    public bool IsBoss => false;

    public int BaseHealth => 10000;

    public List<string> RcolPaths
        => [
            PakPath.RcolFile("collision/collider/enemy/em3000/em3000.rcol"),
            PakPath.RcolFile("collision/collider/enemy/em3000/em3000throwattack.rcol")
           ];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em3000/parameter/directive/em3000directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em2000/parameter/resist/em3000resistparameter.user6");
}

internal class JackStalkerStatsModifier : IEnemyStatsModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em3000");
        logger.Push($"{enemy.EnemyId} – {enemy.Name}");

        var minSpeed = randomizer.GetConfigOption<int>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<int>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        var min = randomizer.GetConfigOption<int>("enemy-health-min-jackstalker");
        var max = randomizer.GetConfigOption<int>("enemy-health-max-jackstalker");
        var newHealth = (float)rng.NextDouble(min, max);

        var holder = randomizer.FileRepository
            .DeserializeUserFile<app.Em3000DirectivesHolder>(enemy.DirectivesHolderPath);

        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em3000BattleDirective>(
                userFilePath,
                d => ModifyDirective(d, logger, newHealth, newSpeed)
            );
        }

        logger.Pop();
    }

    private app.Em3000BattleDirective ModifyDirective(
        app.Em3000BattleDirective directive,
        RandomizerLogger logger,
        float health,
        float speed)
    {
        // TODO Scale?
        // directive.common.ModelScale

        // Health
        logger.LogLine($"Health: {directive.chapter3Battle1Final.Health} => {health}");
        directive.chapter3Battle1Final.Health = health;

        // Speed
        logger.LogLine($"Speed: {speed}x normal speed");
        directive.common.MotionSpeedForBack *= speed;
        directive.common.MotionSpeedForStepIn *= speed;
        directive.common.MotionSpeedForWalk *= speed;

        // Misc.
        directive.chapter3Battle1.MansionAIForceDiscoveryTime = 0.5f; // ;)
        return directive;
    }
}