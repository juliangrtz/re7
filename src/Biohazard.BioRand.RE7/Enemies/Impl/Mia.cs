using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal abstract class MiaBase(string id, string name, bool isBoss, int health) : IEnemy
{
    public string Id => id;
    public EnemyID EnemyId => EnemyID.Em2000;
    public EnemyCategory Category => EnemyCategory.Mia;
    public string Name => name;
    public bool IsBoss => isBoss;
    public int Health => health;

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em2000/parameter/directives/em2000battledirectiveholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em2000/parameter/resist/em2000resistparameterholder.user");

    public abstract void ApplyConfigStats(Randomizer randomizer, RandomizerLogger logger);
}

internal class MiaChainsaw : MiaBase
{
    public MiaChainsaw() : base("MiaChainsaw", "Mia (Chainsaw)", true, 2300)
    {
    }

    private app.Em2000BattleDirective ModifyDirective(
    app.Em2000BattleDirective directive,
    RandomizerLogger logger,
    float newHealth,
    float newSpeed)
    {
        var logStr = "";

        logStr += $"Health: {directive.chapter1Battle4.Health} => {newHealth}";
        directive.chapter1Battle4.Health = (float)newHealth;

        logStr += $", speed: {directive.chapter1Battle4.WalkSpeedRateForRank} => {newSpeed}";
        directive.chapter1Battle4.WalkSpeedRateThird *= newSpeed;
        directive.chapter1Battle4.WalkSpeedRateForRank *= newSpeed;
        directive.chapter1Battle4.EvasiveWalkRate *= newSpeed;

        logger.LogLine(logStr);
        return directive;
    }

    public override void ApplyConfigStats(Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em2000");
        logger.Push("Mia (Chainsaw)");

        // Speed
        var minSpeed = randomizer.GetConfigOption<int>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<int>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        // Health
        var minHealth = randomizer.GetConfigOption<int>("boss-health-min-em2000");
        var maxHealth = randomizer.GetConfigOption<int>("boss-health-max-em2000");
        var newHealth = (float)rng.NextDouble(minHealth, maxHealth);

        foreach (var directive in randomizer.FileRepository.DeserializeUserFile<app.Em2000DirectivesHolder>(DirectivesHolderPath).holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);
            logger.LogLine($"[Rank {rank}] Modifying directive {userFilePath}");
            randomizer.FileRepository.ModifyUserFile<app.Em2000BattleDirective>(userFilePath, root =>
            {
                return ModifyDirective(root, logger, newHealth, newSpeed);
            });
        }
        logger.Pop();
    }
}

internal class MiaKnife : MiaBase
{
    public MiaKnife() : base("MiaKnife", "Mia (Knife)", false, 700)
    {
    }

    public override void ApplyConfigStats(Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em2000");
        logger.Push("Mia (Knife)");

        // Speed
        var minSpeed = randomizer.GetConfigOption<int>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<int>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        // Health
        var minHealth = randomizer.GetConfigOption<int>("enemy-health-min-miaknife");
        var maxHealth = randomizer.GetConfigOption<int>("enemy-health-max-miaknife");
        var newHealth = (float)rng.NextDouble(minHealth, maxHealth);

        foreach (var directive in randomizer.FileRepository.DeserializeUserFile<app.Em2000DirectivesHolder>(DirectivesHolderPath).holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);
            logger.LogLine($"[Rank {rank}] Modifying directive {userFilePath}");
            randomizer.FileRepository.ModifyUserFile<app.Em2000BattleDirective>(userFilePath, directive =>
            {
                logger.LogLine($"Health: {directive.chapter1Battle2.Health} => {newHealth}");
                directive.chapter1Battle2.Health = (float)newHealth;

                // TODO: FirstFlowWalkTime, SecondFlowWalkTime, WalkTimeDeclineByDamage ?

                return directive;
            });
        }
        logger.Pop();
    }
}