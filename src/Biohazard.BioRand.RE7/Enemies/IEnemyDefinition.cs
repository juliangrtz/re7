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
    public string SpeedConfigId => Id;
    public bool SupportsSpeedRandomization => false;

    public string DirectivesHolderPath { get; }
    public string ResistParamsHolderPath { get; }

    public string OriginalPrefabPath { get; }

    public bool UsesEnemyGenerator { get; }

    public bool IsMolded => Category == EnemyCategory.Molded;
    public bool IsInsect => Category == EnemyCategory.Insect;

    public string? SpawnOptionType => UsesEnemyGenerator ? $"app.EnemySpawnInfoOption{EnemyId}" : null;

    public RszGameObject IndividualizeTemplate(Rng rng, RszGameObject template) => template;

    internal float GetHealthMultiplier(Randomizer randomizer, Rng rng)
    {
        var healthPrefix = IsBoss ? "boss" : "enemy";
        var healthConfigId = HealthConfigId.ToLowerInvariant();
        var min = randomizer.GetConfigOption($"{healthPrefix}-health-min-{healthConfigId}", 1.0);
        var max = randomizer.GetConfigOption($"{healthPrefix}-health-max-{healthConfigId}", 1.0);
        return (float)rng.NextDouble(min, max);
    }

    internal float GetHealth(Randomizer randomizer, Rng rng)
    {
        var randomEnemyHealth = randomizer.GetConfigOption<bool>("enemy-random-health");
        var randomBossHealth = randomizer.GetConfigOption<bool>("boss-random-health");
        return (randomEnemyHealth && !IsBoss) || (randomBossHealth && IsBoss) 
            ? BaseHealth * GetHealthMultiplier(randomizer, rng) 
            : BaseHealth;
    }

    internal bool ShouldRandomizeSpeed(Randomizer randomizer)
        => SupportsSpeedRandomization && randomizer.GetConfigOption<bool>("random-enemy-speed");

    internal float GetSpeedMultiplier(Randomizer randomizer)
    {
        if (!ShouldRandomizeSpeed(randomizer))
            return 1f;

        var speedConfigId = SpeedConfigId.ToLowerInvariant();
        var legacyGlobalMinConfigId = "enemy-speed-min";
        var legacyGlobalMaxConfigId = "enemy-speed-max";
        var globalMin = randomizer.GetConfigOption(legacyGlobalMinConfigId, 0.5);
        var globalMax = randomizer.GetConfigOption(legacyGlobalMaxConfigId, 2.0);
        var min = randomizer.GetConfigOption($"enemy-speed-min-{speedConfigId}", globalMin);
        var max = randomizer.GetConfigOption($"enemy-speed-max-{speedConfigId}", globalMax);
        return (float)randomizer.GetRng("enemy/speed", speedConfigId).NextDouble(min, max);
    }
}
