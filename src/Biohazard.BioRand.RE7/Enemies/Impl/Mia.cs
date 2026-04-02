using IntelOrca.Biohazard.BioRand;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MiaChainsaw : IEnemy
{
    public EnemyID Id => EnemyID.Em2000;
    public EnemyCategory Category => EnemyCategory.Mia;
    public ConfigCategory ConfigCategory
        => new ConfigCategory(Category.ToString(), "#fcba03", "#fff");

    public string Name => "Mia (Chainsaw)";
    public bool IsBoss => true;
    public int Health => 2300;

    private const string directivesPath = "natives/stm/prefab/character/em2000/parameter/directives";

    public void ApplyConfigStats(Randomizer randomizer)
    {
        // TODO
    }
}

//internal class MiaKnife : IEnemy
//{
//    public EnemyID Id => EnemyID.Em2000;
//    public EnemyCategory Category => EnemyCategory.Mia;
//    public ConfigCategory ConfigCategory
//        => new ConfigCategory(Category.ToString(), "#fcba03", "#fff");

//    public string Name => "Mia (Knife)";
//    public bool IsBoss => false;
//    public int Health => 700;

//    private const string directivesPath = "natives/stm/prefab/character/em2000/parameter/directives";

//    public void ApplyConfigStats(Randomizer randomizer)
//    {
//        // TODO
//    }
//}