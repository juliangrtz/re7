using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class JackMutated : IEnemyDefinition
{
    public string Id => "JackMutated";

    public EnemyID EnemyId => EnemyID.Em8100;

    public EnemyCategory Category => EnemyCategory.Jack;

    public string Name => "Jack Baker (Mutated)";

    public bool IsBoss => true;

    public int BaseHealth => 30000; // Invincible body. TODO: Model eye HP values properly

    public List<string> RcolPaths => [
        PakPath.RcolFile("collision/collider/enemy/em8100/em8100.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8100/em8100deadbody.rcol.20"),
    ];

    public string DirectivesHolderPath 
        => PakPath.UserFile("prefab/character/em8100/parameter/directive/em8100directivesholder.user");

    public string ResistParamsHolderPath
         => PakPath.UserFile("prefab/character/em8100/parameter/resist/em8100resistparameterholder.user");
}
