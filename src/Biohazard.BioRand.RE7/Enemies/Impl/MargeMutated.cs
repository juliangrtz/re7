using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MargeMutated : IEnemyDefinition
{
    public string Id => "MargeMutated";

    public EnemyID EnemyId => EnemyID.Em3600;

    public EnemyCategory Category => EnemyCategory.Marguerite;

    public string Name => "Marguerite Baker (Mutated)";

    public bool IsBoss => true;

    public int BaseHealth => 15000;

    public List<string> RcolPaths =>
        [
            PakPath.RcolFile("collision/collider/enemy/em3600/em3600.rcol"),
            PakPath.RcolFile("collision/collider/enemy/em3600/em3600shell.rcol")
        ];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em3600/em3600directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em3600/em3600resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/chapter/chapter3/enemy_em3600.scn");

    public bool UsesEnemyGenerator => false;
}

internal class MargeMutatedDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3600;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em3600");

        // Speed
        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em3600DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em3600Directive>(
                userFilePath,
                d => ModifyDirective(d, logger, newSpeed)
            );
        }
    }

    private app.Em3600Directive ModifyDirective(
        app.Em3600Directive directive,
        RandomizerLogger logger,
        float speed)
    {
        logger.LogLine($"Speed: {speed}x normal speed");
        directive.MyCommonParam.NormalAttackIntervalTime /= speed;
        directive.MyCommonParam.GrappleAttackIntervalTime /= speed;
        directive.MyCommonParam.GroundAttackIntervalTime /= speed;
        directive.MyCommonParam.WallAttackIntervalTime /= speed;
        directive.MyCommonParam.ChangeTwoLegMoveSpeed *= speed;
        directive.MyCommonParam.ChangeFourLegMoveSpeed *= speed;

        directive.NormalModeParam.MoveSpeedRate *= speed;
        directive.NormalModeParam.MoveSpeedBlendRateUpSpeed *= speed;

        directive.WallMoveModeParam.MoveSpeed *= speed;

        directive.GenerateModeParam.GenerateTime /= speed;
        directive.GenerateModeParam.SpawnBugsIntervalTime /= speed;

        directive.SneakModeParam.SneakTime /= speed;

        directive.EscapeModeParam.MoveSpeed *= speed;

        directive.LastModeParam.MoveSpeed *= speed;

        return directive;
    }
}