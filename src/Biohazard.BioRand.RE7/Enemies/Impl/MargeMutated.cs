using Biohazard.BioRand.RE7.REEngine;

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

    public bool UsesEnemyGenerator => true;
}

internal class MargeMutatedDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3600;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-enemy-speed"))
        {
            logger.LogSkip("Enemy speed randomization is disabled.");
            return;
        }

        var rng = randomizer.GetRng("enemy/em3600");

        // Speed
        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);
        logger.LogMultiplier("Speed multiplier", newSpeed);

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em3600DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogDirectiveFile(rank, userFilePath, () => randomizer.FileRepository.ModifyUserFile<app.Em3600Directive>(
                userFilePath,
                d => ModifyDirective(d, logger, newSpeed)
            ));
        }
    }

    private app.Em3600Directive ModifyDirective(
        app.Em3600Directive directive,
        RandomizerLogger logger,
        float speed)
    {
        var oldNormalAttackInterval = directive.MyCommonParam.NormalAttackIntervalTime;
        directive.MyCommonParam.NormalAttackIntervalTime /= speed;
        logger.LogChange("Normal attack interval", oldNormalAttackInterval, directive.MyCommonParam.NormalAttackIntervalTime);

        var oldGrappleAttackInterval = directive.MyCommonParam.GrappleAttackIntervalTime;
        directive.MyCommonParam.GrappleAttackIntervalTime /= speed;
        logger.LogChange("Grapple attack interval", oldGrappleAttackInterval, directive.MyCommonParam.GrappleAttackIntervalTime);

        var oldGroundAttackInterval = directive.MyCommonParam.GroundAttackIntervalTime;
        directive.MyCommonParam.GroundAttackIntervalTime /= speed;
        logger.LogChange("Ground attack interval", oldGroundAttackInterval, directive.MyCommonParam.GroundAttackIntervalTime);

        var oldWallAttackInterval = directive.MyCommonParam.WallAttackIntervalTime;
        directive.MyCommonParam.WallAttackIntervalTime /= speed;
        logger.LogChange("Wall attack interval", oldWallAttackInterval, directive.MyCommonParam.WallAttackIntervalTime);

        var oldTwoLegMoveSpeed = directive.MyCommonParam.ChangeTwoLegMoveSpeed;
        directive.MyCommonParam.ChangeTwoLegMoveSpeed *= speed;
        logger.LogChange("Two-leg move speed", oldTwoLegMoveSpeed, directive.MyCommonParam.ChangeTwoLegMoveSpeed);

        var oldFourLegMoveSpeed = directive.MyCommonParam.ChangeFourLegMoveSpeed;
        directive.MyCommonParam.ChangeFourLegMoveSpeed *= speed;
        logger.LogChange("Four-leg move speed", oldFourLegMoveSpeed, directive.MyCommonParam.ChangeFourLegMoveSpeed);

        var oldNormalMoveSpeedRate = directive.NormalModeParam.MoveSpeedRate;
        directive.NormalModeParam.MoveSpeedRate *= speed;
        logger.LogChange("Normal mode move speed", oldNormalMoveSpeedRate, directive.NormalModeParam.MoveSpeedRate);

        var oldNormalBlendRate = directive.NormalModeParam.MoveSpeedBlendRateUpSpeed;
        directive.NormalModeParam.MoveSpeedBlendRateUpSpeed *= speed;
        logger.LogChange("Normal mode blend-up speed", oldNormalBlendRate, directive.NormalModeParam.MoveSpeedBlendRateUpSpeed);

        var oldWallMoveSpeed = directive.WallMoveModeParam.MoveSpeed;
        directive.WallMoveModeParam.MoveSpeed *= speed;
        logger.LogChange("Wall move speed", oldWallMoveSpeed, directive.WallMoveModeParam.MoveSpeed);

        var oldGenerateTime = directive.GenerateModeParam.GenerateTime;
        directive.GenerateModeParam.GenerateTime /= speed;
        logger.LogChange("Generate time", oldGenerateTime, directive.GenerateModeParam.GenerateTime);

        var oldSpawnBugsInterval = directive.GenerateModeParam.SpawnBugsIntervalTime;
        directive.GenerateModeParam.SpawnBugsIntervalTime /= speed;
        logger.LogChange("Spawn bugs interval", oldSpawnBugsInterval, directive.GenerateModeParam.SpawnBugsIntervalTime);

        var oldSneakTime = directive.SneakModeParam.SneakTime;
        directive.SneakModeParam.SneakTime /= speed;
        logger.LogChange("Sneak time", oldSneakTime, directive.SneakModeParam.SneakTime);

        var oldEscapeMoveSpeed = directive.EscapeModeParam.MoveSpeed;
        directive.EscapeModeParam.MoveSpeed *= speed;
        logger.LogChange("Escape move speed", oldEscapeMoveSpeed, directive.EscapeModeParam.MoveSpeed);

        var oldLastModeMoveSpeed = directive.LastModeParam.MoveSpeed;
        directive.LastModeParam.MoveSpeed *= speed;
        logger.LogChange("Last-mode move speed", oldLastModeMoveSpeed, directive.LastModeParam.MoveSpeed);

        return directive;
    }
}
