using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MoldedQuick : IEnemyDefinition
{
    public string Id => "MoldedQuick";

    public EnemyID EnemyId => EnemyID.Em4100;

    public EnemyCategory Category => EnemyCategory.Molded;

    public string Name => "Molded (4-Legged)";

    public bool IsBoss => false;

    public int BaseHealth => 900;

    public List<string> RcolPaths => [PakPath.RcolFile("collision/collider/enemy/em4100/em4100.rcol")];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em4100/parameter/directive/em4100directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em4100/parameter/resist/em4100resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em4100.scn");

    public bool UsesEnemyGenerator => true;
}

internal class MoldedQuickDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em4100;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        if (randomizer.GetConfigOption<bool>("enemy-speed-exclude-four-legged-moldeds"))
        {
            logger.LogSkip("Four-legged Moldeds are excluded from enemy speed randomization.");
            return;
        }

        var rng = randomizer.GetRng("enemy/em4100");
        var applySpeed = randomizer.GetConfigOption<bool>("random-enemy-speed");

        // Speed
        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var newSpeed = applySpeed ? (float)rng.NextDouble(minSpeed, maxSpeed) : 1f;
        if (applySpeed)
        {
            logger.LogMultiplier("Animation speed multiplier", newSpeed);
        }
        else
        {
            logger.LogLine("Animation speed multiplier: 1x (enemy speed randomization disabled)");
        }

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em4100DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogDirectiveFile(rank, userFilePath, () => randomizer.FileRepository.ModifyUserFile<app.Em4100BattleDirective>(
                userFilePath,
                d => ModifyDirective(d, logger, newSpeed)));
        }
    }

    private app.Em4100BattleDirective ModifyDirective(
        app.Em4100BattleDirective directive,
        RandomizerLogger logger,
        float speed)
    {
        if (speed == 1f)
        {
            logger.LogLine("No speed changes.");
            return directive;
        }

        var oldAnimationSpeed = directive.movement.animationSpeedRate;
        directive.movement.animationSpeedRate *= speed;
        logger.LogChange("Animation speed", oldAnimationSpeed, directive.movement.animationSpeedRate);
        return directive;
    }
}
