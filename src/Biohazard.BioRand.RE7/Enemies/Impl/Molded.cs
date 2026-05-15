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

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em4000.scn");

    public bool UsesEnemyGenerator => true;

    public bool SupportsSpeedRandomization => true;
}

internal class MoldedBlade : IEnemyDefinition
{
    public string Id => "MoldedBlade";

    public EnemyID EnemyId => EnemyID.Em4000;

    public EnemyCategory Category => EnemyCategory.Molded;

    public string Name => "Molded (Blade)";

    public bool IsBoss => false;

    public int BaseHealth => 3000;

    public string HealthConfigId => "Molded";

    public List<string> RcolPaths => [PakPath.RcolFile("collision/collider/enemy/em4000/em4000.rcol")];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em4000/parameter/directive/em4000bladebattledirectivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em4000/parameter/resist/em4000bladeresistparameterholder.user");

    public string OriginalPrefabPath
    => PakPath.SceneFile($"scenes/enemy/em4000.scn");

    public bool UsesEnemyGenerator => true;

    public bool SupportsSpeedRandomization => true;
}

// TODO Molded common params
internal class MoldedDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em4000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var applySpeed = enemy.ShouldRandomizeSpeed(randomizer);

        // Speed
        var newSpeed = enemy.GetSpeedMultiplier(randomizer);
        if (applySpeed)
        {
            logger.LogMultiplier("Animation speed multiplier", newSpeed);
        }
        else
        {
            logger.LogLine("Animation speed multiplier: 1x (enemy speed randomization disabled)");
        }

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em4000DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogDirectiveFile(rank, userFilePath, () => randomizer.FileRepository.ModifyUserFile<app.Em4000BattleDirective>(
                userFilePath,
                d => ModifyDirective(d, logger, newSpeed)));
        }
    }

    private app.Em4000BattleDirective ModifyDirective(
        app.Em4000BattleDirective directive,
        RandomizerLogger logger,
        float speed)
    {
        if (speed == 1f)
        {
            logger.LogLine("No speed changes.");
            return directive;
        }

        var oldIdleInterval = directive.movement.idleIntervalTime;
        directive.movement.idleIntervalTime /= speed;
        logger.LogChange("Idle interval", oldIdleInterval, directive.movement.idleIntervalTime);

        var oldAnimationSpeed = directive.movement.animationSpeedRate;
        directive.movement.animationSpeedRate *= speed;
        logger.LogChange("Animation speed", oldAnimationSpeed, directive.movement.animationSpeedRate);

        return directive;
    }
}
