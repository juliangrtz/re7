using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class Molded : IEnemyDefinition
{
    public string Id => "Molded";

    public EnemyID EnemyId => EnemyID.Em4000;

    public EnemyCategory Category => EnemyCategory.Molded;

    public string Name => "Molded (Normal)";

    public bool IsBoss => false;

    public int BaseHealth => 3000;

    public List<string> RcolPaths => [PakPath.RcolFile("collision/collider/enemy/em4000/em4000.rcol")];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em4000/parameter/directive/em4000directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em4000/parameter/resist/em4000resistparameterholder.user");
}

internal class MoldedBlade : IEnemyDefinition
{
    public string Id => "MoldedBlade";

    public EnemyID EnemyId => EnemyID.Em4000;

    public EnemyCategory Category => EnemyCategory.Molded;

    public string Name => "Molded (Blade)";

    public bool IsBoss => false;

    public int BaseHealth => 3000;

    public List<string> RcolPaths => [PakPath.RcolFile("collision/collider/enemy/em4000/em4000.rcol")];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em4000/parameter/directive/em4000bladebattledirectivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em4000/parameter/resist/em4000bladeresistparameterholder.user");
}

// TODO Molded common params
internal class MoldedDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em4000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em4000");
        logger.Push($"{enemy.EnemyId} -- {enemy.Name}");

        // Health (vanilla prefab + rando prefab)
        var min = randomizer.GetConfigOption<int>("enemy-health-min-molded");
        var max = randomizer.GetConfigOption<int>("enemy-health-max-molded");
        var newHealth = (float)rng.NextDouble(min, max);
        logger.LogLine($"Health: {enemy.BaseHealth} => {newHealth}");

        // Speed
        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em4000DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em4000BattleDirective>(
                userFilePath,
                d => ModifyDirective(d, logger, newSpeed)
            );
        }

        logger.Pop();
    }

    private app.Em4000BattleDirective ModifyDirective(
        app.Em4000BattleDirective directive,
        RandomizerLogger logger,
        float speed)
    {
        logger.LogLine($"Speed: {speed}x normal speed");
        directive.movement.idleIntervalTime /= speed;
        directive.movement.animationSpeedRate *= speed;

        return directive;
    }
}