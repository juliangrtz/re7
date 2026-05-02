using IntelOrca.Biohazard.REE.Rsz;
using System.ComponentModel.DataAnnotations;

namespace Biohazard.BioRand.RE7.Enemies;

public interface IEnemyDefinition
{
    [Key]
    public string Id { get; }

    public EnemyID EnemyId { get; }

    public EnemyCategory Category { get; }

    public string Name { get; }

    public bool IsBoss { get; }

    public int BaseHealth { get; }

    public string HealthConfigId => Id;

    public bool UseTemplateHealth => false;

    public double DefaultEnemyRatio => 0.5;

    public string DirectivesHolderPath { get; }
    public string ResistParamsHolderPath { get; }

    public string OriginalPrefabPath { get; }

    public bool UsesEnemyGenerator { get; }

    public DlcType? Dlc => null;

    public bool IsDlc => Dlc != null;

    public string EnemyAlias => EnemyId.ToString();

    public string? TemplateComponentPrefix => null;

    public string EnemyGeneratorComponentType => EnemyGenerationComponents.EnemyGeneratorType;

    public string EnemyPoolComponentType => EnemyGenerationComponents.EnemyPoolType;

    public bool IsMolded => Category == EnemyCategory.Molded;
    public bool IsInsect => Category == EnemyCategory.Insect;

    public string? SpawnOptionType => UsesEnemyGenerator ? $"app.EnemySpawnInfoOption{EnemyAlias}" : null;

    public RszGameObject IndividualizeTemplate(Rng rng, RszGameObject template) => template;

    internal float GetHealthMultiplier(Randomizer randomizer, Rng rng)
    {
        var healthPrefix = IsBoss ? "boss" : "enemy";
        var healthConfigId = HealthConfigId.ToLowerInvariant();
        var min = randomizer.GetConfigOption($"{healthPrefix}-health-min-{healthConfigId}", 1.0);
        var max = randomizer.GetConfigOption($"{healthPrefix}-health-max-{healthConfigId}", 1.0);
        return (float)rng.NextDouble(min, max);
    }

    internal float GetHealth(Randomizer randomizer, Rng rng, float? templateHealth = null)
    {
        var randomEnemyHealth = randomizer.GetConfigOption<bool>("enemy-random-health");
        var randomBossHealth = randomizer.GetConfigOption<bool>("boss-random-health");
        var baseHealth = UseTemplateHealth && templateHealth is > 0 ? templateHealth.Value : BaseHealth;
        return (randomEnemyHealth && !IsBoss) || (randomBossHealth && IsBoss)
            ? baseHealth * GetHealthMultiplier(randomizer, rng)
            : baseHealth;
    }
}
