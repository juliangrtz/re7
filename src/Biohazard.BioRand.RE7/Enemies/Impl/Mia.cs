using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MiaChainsaw : MiaBase
{
    public MiaChainsaw() : base("MiaChainsaw", "Mia Winters (Chainsaw)", true, 2300) { }
}

internal class MiaKnife : MiaBase
{
    public MiaKnife() : base("MiaKnife", "Mia Winters (Knife)", false, 700) { }
}

internal abstract class MiaBase(string id, string name, bool isBoss, int health) : IEnemyDefinition
{
    public string Id => id;
    public EnemyID EnemyId => EnemyID.Em2000;
    public EnemyCategory Category => EnemyCategory.Mia;
    public string Name => name;
    public bool IsBoss => isBoss;
    public int BaseHealth => health;

    public List<string> RcolPaths
        => [PakPath.RcolFile("collision/collider/enemy/em2000/em2000.rcol")];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em2000/parameter/directives/em2000battledirectiveholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em2000/parameter/resist/em2000resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em2000.scn"); // also there is scenes/enemy/em2000chapter4.scn

    public bool UsesEnemyGenerator => false;

    public bool SupportsSpeedRandomization => true;
}

internal class MiaDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em2000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em2000");
        var applySpeed = enemy.ShouldRandomizeSpeed(randomizer);
        var speedMultiplier = enemy.GetSpeedMultiplier(randomizer);

        var shouldRandomizeHealth = enemy.ShouldRandomizeHealth(randomizer);
        var health = shouldRandomizeHealth ? enemy.GetHealth(randomizer, rng) : (float?)null;
        if (health.HasValue)
        {
            logger.LogHealthAssignment("Health", enemy.BaseHealth, health.Value);
        }
        else
        {
            logger.LogLine("Health: unchanged (enemy health randomization disabled)");
        }

        if (enemy.IsBoss)
        {
            if (applySpeed)
            {
                logger.LogMultiplier("Walk speed multiplier", speedMultiplier);
            }
            else
            {
                logger.LogLine("Walk speed multiplier: 1x (enemy speed randomization disabled)");
            }
        }

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em2000DirectivesHolder>(enemy.DirectivesHolderPath);

        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogDirectiveFile(rank, userFilePath, () => randomizer.FileRepository.ModifyUserFile<app.Em2000BattleDirective>(
                userFilePath,
                d => ModifyDirective(enemy, d, logger, health, speedMultiplier)
            ));
        }
    }

    private app.Em2000BattleDirective ModifyDirective(
        IEnemyDefinition enemy,
        app.Em2000BattleDirective directive,
        RandomizerLogger logger,
        float? health,
        float speedMultiplier)
    {
        if (enemy.IsBoss)
        {
            if (health.HasValue)
            {
                var oldHealth = directive.chapter1Battle4.Health;
                directive.chapter1Battle4.Health = health.Value;
                logger.LogChange("Chapter 1 battle 4 health", oldHealth, directive.chapter1Battle4.Health);
            }

            if (speedMultiplier == 1f)
            {
                logger.LogLine("No walk speed changes.");
                return directive;
            }

            var oldWalkSpeedThird = directive.chapter1Battle4.WalkSpeedRateThird;
            directive.chapter1Battle4.WalkSpeedRateThird *= speedMultiplier;
            logger.LogChange("Walk speed rate (third)", oldWalkSpeedThird, directive.chapter1Battle4.WalkSpeedRateThird);

            var oldWalkSpeedForRank = directive.chapter1Battle4.WalkSpeedRateForRank;
            directive.chapter1Battle4.WalkSpeedRateForRank *= speedMultiplier;
            logger.LogChange("Walk speed rate (rank)", oldWalkSpeedForRank, directive.chapter1Battle4.WalkSpeedRateForRank);

            var oldEvasiveWalkRate = directive.chapter1Battle4.EvasiveWalkRate;
            directive.chapter1Battle4.EvasiveWalkRate *= speedMultiplier;
            logger.LogChange("Evasive walk rate", oldEvasiveWalkRate, directive.chapter1Battle4.EvasiveWalkRate);
        }
        else
        {
            if (health.HasValue)
            {
                var oldHealth = directive.chapter1Battle2.Health;
                directive.chapter1Battle2.Health = health.Value;
                logger.LogChange("Chapter 1 battle 2 health", oldHealth, directive.chapter1Battle2.Health);
            }
        }

        return directive;
    }
}
