using IntelOrca.Biohazard.BioRand;

namespace Biohazard.BioRand.RE7.Enemies;

public enum EnemyCategory
{
    Mia,
    Molded,
    Jack,
    Marguerite,
    Insect,
    Eveline,
    Dlc
}

internal static class EnemyCategoryExtensions
{
    public static ConfigCategory ToConfigCategory(this EnemyCategory enemyCategory) => enemyCategory switch
    {
        EnemyCategory.Mia => new ConfigCategory("Mia", "#fcba03", "#fff"),
        EnemyCategory.Molded => new ConfigCategory("Molded", "#171616", "#fff"),
        EnemyCategory.Jack => new ConfigCategory("Jack", "#750c0c", "#fff"),
        EnemyCategory.Marguerite => new ConfigCategory("Marguerite", "#1e7d0b", "#fff"),
        EnemyCategory.Insect => new ConfigCategory("Insect", "#3b1603", "#fff"),
        EnemyCategory.Eveline => new ConfigCategory("Eveline", "#e1eaeb", "#000"),
        EnemyCategory.Dlc => new ConfigCategory("DLC", "#184e77", "#fff"),
        _ => throw new NotImplementedException(),
    };
}
