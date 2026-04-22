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

    public string DirectivesHolderPath { get; }
    public string ResistParamsHolderPath { get; }

    public string OriginalPrefabPath { get; }

    public bool UsesEnemyGenerator { get; }

    public bool IsMolded =>
        Category == EnemyCategory.Molded;

    public string? SpawnOptionType
        => UsesEnemyGenerator ? $"app.EnemySpawnInfoOption{EnemyId}" : null;

    internal float GetHealthMultiplier(Randomizer randomizer, Rng rng)
    {
        var healthPrefix = IsBoss ? "boss" : "enemy";
        var healthConfigId = HealthConfigId.ToLowerInvariant();
        var min = randomizer.GetConfigOption<double>($"{healthPrefix}-health-min-{healthConfigId}", 1.0);
        var max = randomizer.GetConfigOption<double>($"{healthPrefix}-health-max-{healthConfigId}", 1.0);
        return (float)rng.NextDouble(min, max);
    }

    internal float GetHealth(Randomizer randomizer, Rng rng)
    {
        var randomEnemyHealth = randomizer.GetConfigOption<bool>("enemy-random-health");
        var randomBossHealth = randomizer.GetConfigOption<bool>("boss-random-health");
        return (randomEnemyHealth && !IsBoss) || (randomBossHealth && IsBoss) ? BaseHealth * GetHealthMultiplier(randomizer, rng) : BaseHealth;
    }
}
