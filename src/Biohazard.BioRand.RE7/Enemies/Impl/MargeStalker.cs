using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MargeStalker : IEnemyDefinition
{
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
}

internal class MargeStalkerDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3100;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em3100");

        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em3100DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em3100Directive>(
                userFilePath,
                d => ModifyDirective(d, logger, newSpeed)
            );
        }
    }

    private app.Em3100Directive ModifyDirective(
        app.Em3100Directive directive,
        RandomizerLogger logger,
        float speed)
    {
        // Speed
        logger.LogLine($"Walking speed: {directive.FretWalkSpeed} => {directive.FretWalkSpeed * speed}");
        directive.FretWalkSpeed *= speed;

        logger.LogLine($"Attack interval: {directive.bugHoleParam.AttackIntervalSec} => {directive.bugHoleParam.AttackIntervalSec / speed}");
        directive.bugHoleParam.AttackIntervalSec /= speed;

        logger.LogLine($"Bug spawn interval: {directive.bugHoleParam.Em5400SpawnInterval} => {directive.bugHoleParam.Em5400SpawnInterval / speed}");
        directive.bugHoleParam.Em5400SpawnInterval /= speed;

        return directive;
    }
}
