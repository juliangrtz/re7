using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class EvelineGrandmother : IEnemyDefinition
{
    public string Id => "EvelineElderly";

    public EnemyID EnemyId => EnemyID.Em3300;

    public EnemyCategory Category => EnemyCategory.Eveline;

    public string Name => "Eveline (Elderly)";

    public bool IsBoss => false;

    public int BaseHealth => int.MaxValue;

    public List<string> RcolPaths => [];

    public string DirectivesHolderPath => throw new NotSupportedException("Elder Eveline does not have directives!");

    public string ResistParamsHolderPath => throw new NotSupportedException("Elder Eveline does not have resist params!");

    public string OriginalPrefabPath 
        => PakPath.SceneFile($"scenes/enemy/em3300.scn");

    public bool UsesEnemyGenerator => false;
}

internal class EvelineFinalBoss : IEnemyDefinition
{
    public string Id => "EvelineFinalBoss";

    public EnemyID EnemyId => EnemyID.Em8900;

    public EnemyCategory Category => EnemyCategory.Eveline;

    public string Name => "Eveline (Final Boss)";

    public bool IsBoss => true;

    public int BaseHealth => 6000; // Only phase 1

    public List<string> RcolPaths => [
        PakPath.RcolFile("collision/collider/enemy/em8900/em8900.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8910/em8910.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8940/em8940.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8950/em8950.rcol"),
    ];

    public string DirectivesHolderPath => throw new NotSupportedException("Em8900 has multiple phases with multiple directives!");

    public string ResistParamsHolderPath => throw new NotSupportedException("Em8900 has multiple phases with multiple resist params!");

    public string OriginalPrefabPath 
        => PakPath.SceneFile($"scenes/enemy/em8900.scn");

    public bool UsesEnemyGenerator => false;
}

internal class EvelineFinalBossDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em8900;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-enemy-speed"))
        {
            logger.LogSkip("Enemy speed randomization is disabled.");
            return;
        }

        var rng = randomizer.GetRng("enemy/em8900");
        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var speedMultiplier = (float)rng.NextDouble(minSpeed, maxSpeed);
        logger.LogMultiplier("Speed multiplier", speedMultiplier);

        var phase1Path = PakPath.UserFile("prefab/character/em8900/parameter/directives/em8900directivedefault.user");
        logger.LogDirectiveFile("Phase 1", phase1Path, () => randomizer.FileRepository.ModifyUserFile<app.Em8900Directive>(
            phase1Path,
            directive =>
            {
                var oldSpeed = directive.wallParam.BaseMoveMotionSpeed;
                directive.wallParam.BaseMoveMotionSpeed *= speedMultiplier;
                logger.LogChange("Wall move speed", oldSpeed, directive.wallParam.BaseMoveMotionSpeed);
                return directive;
            }));

        var phase2Path = PakPath.UserFile("prefab/character/em8940/parameter/directives/em8940directivedefault.user");
        logger.LogDirectiveFile("Phase 2", phase2Path, () => randomizer.FileRepository.ModifyUserFile<app.Em8940Directive>(
            phase2Path,
            directive =>
            {
                var oldHangUpLoopTime = directive.hangUpParam.HangUpLoopTime;
                directive.hangUpParam.HangUpLoopTime /= speedMultiplier;
                logger.LogChange("Hang-up loop time", oldHangUpLoopTime, directive.hangUpParam.HangUpLoopTime);
                return directive;
            }));
    }
}
