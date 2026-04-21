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
            return;

        var rng = randomizer.GetRng("enemy/em8900");
        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var speedMultiplier = (float)rng.NextDouble(minSpeed, maxSpeed);

        randomizer.FileRepository.ModifyUserFile<app.Em8900Directive>(
            PakPath.UserFile("prefab/character/em8900/parameter/directives/em8900directivedefault.user"),
            directive =>
            {
                var newSpeed = directive.wallParam.BaseMoveMotionSpeed * speedMultiplier;
                logger.LogLine($"Wall move speed: {directive.wallParam.BaseMoveMotionSpeed} => {newSpeed}");
                directive.wallParam.BaseMoveMotionSpeed = newSpeed;
                return directive;
            }
        );

        randomizer.FileRepository.ModifyUserFile<app.Em8940Directive>(
            PakPath.UserFile("prefab/character/em8940/parameter/directives/em8940directivedefault.user"),
            directive =>
            {
                var newHangUpLoopTime = directive.hangUpParam.HangUpLoopTime / speedMultiplier;
                logger.LogLine($"Hang up time: {directive.hangUpParam.HangUpLoopTime} => {newHangUpLoopTime}");
                directive.hangUpParam.HangUpLoopTime = newHangUpLoopTime;
                return directive;
            }
        );
    }
}