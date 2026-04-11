using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class JackShears : IEnemyDefinition
{
    public string Id => "JackShears";

    public EnemyID EnemyId => EnemyID.Em8000;

    public EnemyCategory Category => EnemyCategory.Jack;

    public string Name => "Jack Baker (Scissor Chainsaw)";

    public bool IsBoss => true;

    public int BaseHealth => 4500; // Weak spot!

    public List<string> RcolPaths => [
        PakPath.RcolFile("collision/collider/enemy/em8000/em8000.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8000/em8000chainsawsensor.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8000/em8100deadbody.rcol.20"),
    ];

    public string DirectivesHolderPath 
        => PakPath.UserFile("prefab/character/em8000/parameter/directive/em8000directiveholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em8000/parameter/resist/em8000resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/chapter/chapter3/enemy_em8000.scn");

    public bool UsesEnemyGenerator => true;
}

internal class JackChainsawDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em8000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        // TODO
    }
}