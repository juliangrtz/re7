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

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em3000.scn");

    public bool UsesEnemyGenerator => false;
}

internal class JackStalkerDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em3000");

        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var speedMultiplier = (float)rng.NextDouble(minSpeed, maxSpeed);

        var healthMultiplier = enemy.GetHealthMultiplier(randomizer, rng);

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em3000DirectivesHolder>(enemy.DirectivesHolderPath);

        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em3000BattleDirective>(
                userFilePath,
                d => ModifyDirective(d, logger, healthMultiplier, speedMultiplier)
            );
        }
    }

    private app.Em3000BattleDirective ModifyDirective(
        app.Em3000BattleDirective directive,
        RandomizerLogger logger,
        float healthMultiplier,
        float speedMultiplier)
    {
        // TODO Scale?
        // directive.common.ModelScale

        // Health
        logger.LogLine($"Health: {directive.chapter3Battle1Final.Health} => {directive.chapter3Battle1Final.Health * healthMultiplier}");
        directive.chapter3Battle1Final.Health *= healthMultiplier;

        // Speed
        logger.LogLine($"Speed: {speedMultiplier}x normal speed");
        //directive.common.MotionSpeedForBack *= speedMultiplier;
        //directive.common.MotionSpeedForStepIn *= speedMultiplier;
        directive.common.MotionSpeedForWalk *= speedMultiplier;

        // Misc.
        directive.chapter3Battle1.MansionAIForceDiscoveryTime = 0.5f; // ;)
        return directive;
    }
}