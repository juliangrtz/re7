using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal sealed class NotAHeroEm4210 : DlcEnemyDefinition
{
    public NotAHeroEm4210()
        : base(
            "NotAHeroEm4210",
            EnemyID.Em4210,
            "Fat Headless Molded (Em4210)",
            DlcType.NotAHero,
            "CH8",
            spawnOptionAlias: "Em4200",
            componentAlias: "Em4200")
    {
    }
}

internal sealed class NotAHeroEm4400 : DlcEnemyDefinition
{
    public NotAHeroEm4400() : base("NotAHeroEm4400", EnemyID.Em4400, "Mama Mold (Em4400)", DlcType.NotAHero, "CH8") { }
}

internal sealed class NotAHeroEm4450 : DlcEnemyDefinition
{
    public NotAHeroEm4450() : base("NotAHeroEm4450", EnemyID.Em4450, "Little Crawler (Em4450)", DlcType.NotAHero, "CH8") { }
}

internal sealed class NotAHeroEm4460 : DlcEnemyDefinition
{
    public NotAHeroEm4460() : base("NotAHeroEm4460", EnemyID.Em4460, "Mama Mold (Em4460)", DlcType.NotAHero, "CH8") { }
}

internal sealed class NotAHeroEm4500 : DlcEnemyDefinition
{
    public NotAHeroEm4500()
        : base("NotAHeroEm4500", EnemyID.Em4500, "Mutated Lucas (Em4500)", DlcType.NotAHero, "CH8", isBoss: true)
    {
    }
}

internal sealed class NotAHeroEm4600 : DlcEnemyDefinition
{
    public NotAHeroEm4600()
        : base(
            "NotAHeroEm4600",
            EnemyID.Em4600,
            "Fumer (Em4600)",
            DlcType.NotAHero,
            "CH8",
            spawnOptionAlias: "Em4000",
            componentAlias: "Em4000")
    {
    }
}

internal sealed class EndOfZoeEm5700 : DlcEnemyDefinition
{
    public EndOfZoeEm5700() : base("EndOfZoeEm5700", EnemyID.Em5700, "End of Zoe Enemy (Em5700)", DlcType.EndOfZoe, "CH9") { }
}

internal sealed class EndOfZoeEm5800 : DlcEnemyDefinition
{
    public EndOfZoeEm5800() : base("EndOfZoeEm5800", EnemyID.Em5800, "End of Zoe Enemy (Em5800)", DlcType.EndOfZoe, "CH9") { }
}

internal sealed class EndOfZoeEm5850 : DlcEnemyDefinition
{
    public EndOfZoeEm5850() : base("EndOfZoeEm5850", EnemyID.Em5850, "End of Zoe Enemy (Em5850)", DlcType.EndOfZoe, "CH9") { }
}

internal sealed class EndOfZoeEm6700 : DlcEnemyDefinition
{
    public EndOfZoeEm6700() : base("EndOfZoeEm6700", EnemyID.Em6700, "End of Zoe Enemy (Em6700)", DlcType.EndOfZoe, "CH9") { }
}

internal sealed class EndOfZoeEm7500 : DlcEnemyDefinition
{
    public EndOfZoeEm7500() : base("EndOfZoeEm7500", EnemyID.Em7500, "End of Zoe Enemy (Em7500)", DlcType.EndOfZoe, "CH9") { }
}

internal sealed class EndOfZoeEm7700 : DlcEnemyDefinition
{
    public EndOfZoeEm7700() : base("EndOfZoeEm7700", EnemyID.Em7700, "End of Zoe Enemy (Em7700)", DlcType.EndOfZoe, "CH9") { }
}

internal sealed class EndOfZoeEm7800 : DlcEnemyDefinition
{
    public EndOfZoeEm7800() : base("EndOfZoeEm7800", EnemyID.Em7800, "End of Zoe Enemy (Em7800)", DlcType.EndOfZoe, "CH9") { }
}

internal sealed class EndOfZoeEm7900 : DlcEnemyDefinition
{
    public EndOfZoeEm7900() : base("EndOfZoeEm7900", EnemyID.Em7900, "End of Zoe Enemy (Em7900)", DlcType.EndOfZoe, "CH9") { }
}

internal abstract class DlcEnemyDefinition(
    string id,
    EnemyID enemyId,
    string name,
    DlcType dlc,
    string spawnOptionPrefix,
    string? spawnOptionAlias = null,
    string? componentAlias = null,
    bool isBoss = false) : IEnemyDefinition
{
    public string Id => id;

    public EnemyID EnemyId => enemyId;

    public string EnemyAlias => EnemyId.ToString();

    public EnemyCategory Category => EnemyCategory.Dlc;

    public string Name => name;

    public bool IsBoss => isBoss;

    public int BaseHealth => 1;

    public bool UseTemplateHealth => true;

    public double DefaultEnemyRatio => 0.0;

    public string? TemplateComponentPrefix => $"app.{spawnOptionPrefix}{componentAlias ?? EnemyAlias}";

    public string EnemyGeneratorComponentType => spawnOptionPrefix == "CH8"
        ? EnemyGenerationComponents.Ch8EnemyGeneratorType
        : EnemyGenerationComponents.EnemyGeneratorType;

    public string EnemyPoolComponentType => spawnOptionPrefix == "CH8"
        ? EnemyGenerationComponents.Ch8EnemyPoolType
        : EnemyGenerationComponents.EnemyPoolType;

    public string DirectivesHolderPath => string.Empty;

    public string ResistParamsHolderPath => string.Empty;

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/{EnemyAlias.ToLowerInvariant()}.scn");

    public bool UsesEnemyGenerator => true;

    public DlcType? Dlc => dlc;

    public string? SpawnOptionType => $"app.{spawnOptionPrefix}EnemySpawnInfoOption{spawnOptionAlias ?? EnemyAlias}";
}
