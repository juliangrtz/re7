using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MoldedQuick : IEnemyDefinition
{
    public string Id => "MoldedQuick";

    public EnemyID EnemyId => EnemyID.Em4100;

    public EnemyCategory Category => EnemyCategory.Molded;

    public string Name => "Molded (4-Legged)";

    public bool IsBoss => false;

    public int BaseHealth => 900;

    public List<string> RcolPaths => [PakPath.RcolFile("collision/collider/enemy/em4100/em4100.rcol")];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em4100/parameter/directive/em4100directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em4100/parameter/resist/em4100resistparameterholder.user");
}

internal class MoldedQuickDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em4100;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        // TODO
    }
}