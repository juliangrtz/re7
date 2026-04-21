using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class FlyingBug : InsectBase
{
    public FlyingBug() : base("FlyingBug", EnemyID.Em5400, "Flying Bug", 150) { }
}

internal class InsectHive : InsectBase
{
    public InsectHive() : base("InsectHive", EnemyID.Em5510, "Insect Hive", 2400) { }
    // Also has variants Em5511 and Em5512, but they only differ in their appearance.
}

internal class InsectSwarm : InsectBase
{
    public InsectSwarm() : base("InsectSwarm", EnemyID.Em5520, "Insect Swarm", 800) { }
}

// ?
//internal class InsectSwarm2 : InsectBase
//{
//    public InsectSwarm2() : base("InsectSwarm2", EnemyID.Em5540, "Insect Swarm 2", 999999) { }
//}

internal abstract class InsectBase(string id, EnemyID enemyId, string name, int health) : IEnemyDefinition
{
    public string Id => id;

    public EnemyID EnemyId => enemyId;

    public EnemyCategory Category => EnemyCategory.Insect;

    public string Name => name;

    public bool IsBoss => false;

    public int BaseHealth => health;

    private string SanitizedId => EnemyId.ToString().ToLower();
    public List<string> RcolPaths => [
        PakPath.RcolFile($"collision/collider/enemy/{SanitizedId}/{SanitizedId}.rcol"),
    ];

    public string DirectivesHolderPath
        => PakPath.UserFile($"prefab/character/{SanitizedId}/{SanitizedId}directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile($"prefab/character/{SanitizedId}/{SanitizedId}resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/{EnemyId.ToString().ToLowerInvariant()}.scn");

    public bool UsesEnemyGenerator => true;
}

internal class InsectsDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId is EnemyID.Em5400 or EnemyID.Em5510 or EnemyID.Em5520;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-enemy-speed"))
            return;

        var rng = randomizer.GetRng($"enemy/{enemy.EnemyId.ToString().ToLowerInvariant()}");

        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var speedMultiplier = (float)rng.NextDouble(minSpeed, maxSpeed);

        logger.LogLine($"New speed: {speedMultiplier}x");

        if (enemy is FlyingBug)
        {
            var holder = randomizer.FileRepository.DeserializeUserFile<app.Em5400DirectivesHolder>(enemy.DirectivesHolderPath);
            foreach (var directive in holder.holder.Units)
            {
                var rank = directive.Rank;
                var userFilePath = PakPath.UserFile(directive.Directive.Path);

                logger.LogLine($"[Rank {rank}] {userFilePath}");


                randomizer.FileRepository.ModifyUserFile<app.Em5400Directive>(userFilePath, directive =>
                {
                    directive.MyCommonParam.DefaultSpeed *= speedMultiplier;
                    directive.MyCommonParam.AttackSpeed *= speedMultiplier;
                    directive.MyCommonParam.AttackIntervalSecMin /= speedMultiplier;
                    directive.MyCommonParam.AttackIntervalSecMax /= speedMultiplier;
                    return directive;
                });
            }
        }
        else if (enemy is InsectHive)
        {
            var holder = randomizer.FileRepository.DeserializeUserFile<app.Em5510DirectivesHolder>(enemy.DirectivesHolderPath);
            foreach (var directive in holder.holder.Units)
            {
                var rank = directive.Rank;
                var userFilePath = PakPath.UserFile(directive.Directive.Path);

                logger.LogLine($"[Rank {rank}] {userFilePath}");
                randomizer.FileRepository.ModifyUserFile<app.Em5510UserData>(userFilePath, directive =>
                {
                    directive.MyGenerateParam.IntervalTime /= speedMultiplier;
                    directive.MyGenerateParam.WaitTime /= speedMultiplier;
                    return directive;
                });
            }
        }
        else if (enemy is InsectSwarm)
        {
            var holder = randomizer.FileRepository.DeserializeUserFile<app.Em5520DirectivesHolder>(enemy.DirectivesHolderPath);
            foreach (var directive in holder.holder.Units)
            {
                var rank = directive.Rank;
                var userFilePath = PakPath.UserFile(directive.Directive.Path);

                logger.LogLine($"[Rank {rank}] {userFilePath}");
                randomizer.FileRepository.ModifyUserFile<app.Em5520Directive>(userFilePath, directive =>
                {
                    directive.MyMoveParam.DefaultSpeed *= speedMultiplier;
                    directive.MyMoveParam.NearPlayerSpeed *= speedMultiplier;
                    directive.MyAttackParam.AttackTime /= speedMultiplier;
                    directive.MyAttackParam.AttackIntervalTime /= speedMultiplier;
                    return directive;
                });
            }
        }
    }
}