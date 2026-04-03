using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class EvelineGrandmother : IEnemyDefinition
{
    public string Id => "EvelineElderly";

    public EnemyID EnemyId => EnemyID.Em3300;

    public EnemyCategory Category => EnemyCategory.Eveline;

    public string Name => "Eveline (Elderly)";

    public bool IsBoss => false;

    public int BaseHealth => int.MaxValue;

    public List<string> RcolPaths => [];

    public string DirectivesHolderPath => throw new NotSupportedException("Elder Eveline does not have directives!");

    public string ResistParamsHolderPath => throw new NotSupportedException("Elder Eveline does not have resist params!");
}

internal class EvelineFinalBoss : IEnemyDefinition
{
    public string Id => "EvelineFinalBoss";

    public EnemyID EnemyId => EnemyID.Em8900;

    public EnemyCategory Category => EnemyCategory.Eveline;

    public string Name => "Eveline (Final Boss)";

    public bool IsBoss => true;

    public int BaseHealth => 6000; // Only phase 1

    public List<string> RcolPaths => [
        PakPath.RcolFile("collision/collider/enemy/em8900/em8900.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8910/em8910.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8940/em8940.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8950/em8950.rcol"),
    ];

    public string DirectivesHolderPath => throw new NotSupportedException("The final boss has multiple stages with multiple directives!");

    public string ResistParamsHolderPath => throw new NotSupportedException("The final boss has multiple stages with multiple resist params!");
}