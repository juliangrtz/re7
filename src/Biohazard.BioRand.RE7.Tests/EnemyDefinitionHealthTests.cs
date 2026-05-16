using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Impl;
using Biohazard.BioRand.RE7.Modifiers;
using IntelOrca.Biohazard.BioRand;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class EnemyDefinitionHealthTests
{
    [Fact]
    public void MoldedBlade_UsesSharedMoldedHealthConfig()
    {
        using var randomizer = CreateRandomizer(config =>
        {
            config["enemy-random-health"] = true;
            config["enemy-health-min-molded"] = 2000.0;
            config["enemy-health-max-molded"] = 2000.0;
        });

        IEnemyDefinition enemy = EnemyDefinitions.Instance.All.OfType<MoldedBlade>().Single();

        var health = enemy.GetHealth(randomizer, randomizer.GetRng("test/molded-blade-health"));

        Assert.Equal(2000.0f, health);
    }

    [Fact]
    public void GetHealth_UsesCallerProvidedRngSequence()
    {
        using var randomizer = CreateRandomizer(config =>
        {
            config["enemy-random-health"] = true;
            config["enemy-health-min-molded"] = 2250.0;
            config["enemy-health-max-molded"] = 3750.0;
        });

        IEnemyDefinition enemy = EnemyDefinitions.Instance.All.OfType<Molded>().Single();
        var actualRng = randomizer.GetRng("modifier/enemy-health");

        var firstHealth = enemy.GetHealth(randomizer, actualRng);
        var secondHealth = enemy.GetHealth(randomizer, actualRng);

        var expectedRng = randomizer.GetRng("modifier/enemy-health");
        var expectedFirst = enemy.GetHealth(randomizer, expectedRng);
        var expectedSecond = enemy.GetHealth(randomizer, expectedRng);

        Assert.Equal(expectedFirst, firstHealth);
        Assert.Equal(expectedSecond, secondHealth);
        Assert.NotEqual(firstHealth, secondHealth);
    }

    [Fact]
    public void JackMutated_ExposesIndividualHealthParts()
    {
        var enemy = EnemyDefinitions.Instance.All.OfType<JackMutated>().Single();

        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "JackMutated-eye-1" && part.BaseHealth == 1600);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "JackMutated-final-eye" && part.BaseHealth == 1500);
    }

    [Fact]
    public void MargeMutated_ExposesSecondaryHealthParts()
    {
        var enemy = EnemyDefinitions.Instance.All.OfType<MargeMutated>().Single();

        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MargeMutated" && part.BaseHealth == 15000);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MargeMutated-escape-resist" && part.BaseHealth == 1100);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MargeMutated-wall-move-resist" && part.BaseHealth == 900);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MargeMutated-sneak-grapple-resist" && part.BaseHealth == 300);
    }

    [Fact]
    public void MoldedFat_ExposesLostPartHealthParts()
    {
        var enemy = EnemyDefinitions.Instance.All.OfType<MoldedFat>().Single();

        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MoldedFat" && part.BaseHealth == 6000);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MoldedFat-lost-head" && part.BaseHealth == 2000);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MoldedFat-lost-left-arm" && part.BaseHealth == 1000);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MoldedFat-lost-right-arm" && part.BaseHealth == 1000);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MoldedFat-lost-left-leg" && part.BaseHealth == 2000);
        Assert.Contains(enemy.HealthParts, part => part.ConfigId == "MoldedFat-lost-right-leg" && part.BaseHealth == 2000);
    }

    [Fact]
    public void EnemyHealthResolver_DebugUniqueHp_MakesRepeatedHealthValuesDistinct()
    {
        using var randomizer = CreateRandomizer(config =>
        {
            config["debug-unique-enemy-hp"] = true;
        });

        var options = new EnemyRandomizerOptions(
            EnemyVariety: 1,
            MaxPackSize: 1,
            DebugUniqueHp: true,
            IsBalanced: false,
            ProgressiveDifficulty: false,
            ScaleOptions: new ScaleOptions(0.0, 1.0f, 1.0f),
            ForceTargetingProbability: 0.0
        );
        var resolver = new EnemyHealthResolver(randomizer, options, randomizer.GetRng("modifier/enemy-health"));
        var enemy = EnemyDefinitions.Instance.All.OfType<Molded>().Single();

        var firstHealth = resolver.GetHealth(enemy);
        var secondHealth = resolver.GetHealth(enemy);

        Assert.Equal(enemy.BaseHealth, firstHealth);
        Assert.NotEqual(firstHealth, secondHealth);
        Assert.True(secondHealth > firstHealth);
    }

    private static Randomizer CreateRandomizer(Action<RandomizerConfiguration> configure)
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(configure);
        var input = new RandomizerInput
        {
            Seed = 0x42424242,
            UserName = "health-tests",
            ProfileName = "Health Tests",
            ProfileAuthor = "xUnit",
            ProfileDescription = "Enemy health behavior tests.",
            Configuration = configuration
        };

        return new Randomizer(input, RandomizerTest.InputPakPath, new EmptyReporter());
    }
}
