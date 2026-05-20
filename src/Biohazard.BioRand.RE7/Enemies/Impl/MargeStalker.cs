using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MargeStalker : IEnemyDefinition {
    public string Id => "MargeStalker";

    public EnemyID EnemyId => EnemyID.Em3100;

    public EnemyCategory Category => EnemyCategory.Marguerite;

    public string Name => "Marguerite Baker (Stalker)";

    public bool IsBoss => false;

    public int BaseHealth => int.MaxValue;

    public List<string> RcolPaths =>
        [PakPath.RcolFile("collision/collider/enemy/em3100/em3100.rcol")];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em3100/em3100directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em3100/em3100resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em3100.scn");

    public bool UsesEnemyGenerator => false;

    public bool SupportsSpeedRandomization => true;
}

internal class MargeStalkerDirectiveModifier : IDirectiveModifier {
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3100;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger) {
        if (!enemy.ShouldRandomizeSpeed(randomizer)) {
            logger.LogSkip("Enemy speed randomization is disabled.");
            return;
        }

        var newSpeed = enemy.GetSpeedMultiplier(randomizer);
        logger.LogMultiplier("Speed multiplier", newSpeed);

        var holder =
            randomizer.FileRepository.DeserializeUserFile<app.Em3100DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units) {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogDirectiveFile(rank, userFilePath, () =>
                randomizer.FileRepository.ModifyUserFile<app.Em3100Directive>(
                    userFilePath,
                    d => ModifyDirective(d, logger, newSpeed)
                ));
        }
    }

    private app.Em3100Directive ModifyDirective(
        app.Em3100Directive directive,
        RandomizerLogger logger,
        float speed) {
        // Speed
        var oldWalkSpeed = directive.FretWalkSpeed;
        directive.FretWalkSpeed *= speed;
        logger.LogChange("Walk speed", oldWalkSpeed, directive.FretWalkSpeed);

        var oldAttackInterval = directive.bugHoleParam.AttackIntervalSec;
        directive.bugHoleParam.AttackIntervalSec /= speed;
        logger.LogChange("Attack interval", oldAttackInterval, directive.bugHoleParam.AttackIntervalSec);

        var oldBugSpawnInterval = directive.bugHoleParam.Em5400SpawnInterval;
        directive.bugHoleParam.Em5400SpawnInterval /= speed;
        logger.LogChange("Bug spawn interval", oldBugSpawnInterval, directive.bugHoleParam.Em5400SpawnInterval);

        return directive;
    }
}