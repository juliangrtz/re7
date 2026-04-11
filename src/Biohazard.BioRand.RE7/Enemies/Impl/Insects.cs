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
    // Also has variants Em5511 and Em5512, but they only differ in their appearance.
}

// ?
//internal class InsectSwarm : InsectBase
//{
//    public InsectSwarm() : base("InsectSwarm", EnemyID.Em5540, "Insect Swarm", 999999) { }
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
        => enemy.EnemyId is EnemyID.Em5400 or EnemyID.Em5510;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng($"enemy/{enemy.EnemyId.ToString().ToLowerInvariant()}");

        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var speedMultiplier = (float)rng.NextDouble(minSpeed, maxSpeed);

        // TODO
    }
}