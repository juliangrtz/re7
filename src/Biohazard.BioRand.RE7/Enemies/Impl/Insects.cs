using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class FlyingBug : InsectBase
{
    public FlyingBug() : base("FlyingBug", EnemyID.Em5400, "Flying Bug", 150) { }
}

internal class InsectHive : InsectBase
{
    public InsectHive() : base("InsectHive", EnemyID.Em5510, "Insect Hive", 2800) { }
    // Also has variants Em5511 and Em5512, but they only differ in their appearance.
}

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
}

