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
}

internal class MiaStatsModifier : IEnemyStatsModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em2000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em2000");
        logger.Push($"{enemy.EnemyId} – {enemy.Name}");

        var minSpeed = randomizer.GetConfigOption<int>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<int>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        var newHealthMultiplier = enemy.GetHealthMultiplier(randomizer, rng);

        var holder = randomizer.FileRepository
            .DeserializeUserFile<app.Em2000DirectivesHolder>(enemy.DirectivesHolderPath);

        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em2000BattleDirective>(
                userFilePath,
                d => ModifyDirective(enemy, d, logger, newHealthMultiplier, newSpeed)
            );
        }

        logger.Pop();
    }

    private app.Em2000BattleDirective ModifyDirective(
        IEnemyDefinition enemy,
        app.Em2000BattleDirective directive,
        RandomizerLogger logger,
        float healthMultiplier,
        float speed)
    {
        if (enemy.IsBoss)
        {
            logger.LogLine($"Health: {directive.chapter1Battle4.Health} => {healthMultiplier}");
            directive.chapter1Battle4.Health = healthMultiplier;

            logger.LogLine($"Speed: {speed}x normal speed");
            directive.chapter1Battle4.WalkSpeedRateThird *= speed;
            directive.chapter1Battle4.WalkSpeedRateForRank *= speed;
            directive.chapter1Battle4.EvasiveWalkRate *= speed;
        }
        else
        {
            logger.LogLine($"Health: {directive.chapter1Battle2.Health} => {healthMultiplier}");
            directive.chapter1Battle2.Health = healthMultiplier;
        }

        return directive;
    }
}
