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
            config["enemy-health-min-molded"] = 2.0;
            config["enemy-health-max-molded"] = 2.0;
        });

        IEnemyDefinition enemy = EnemyDefinitions.Instance.All.OfType<MoldedBlade>().Single();

        var health = enemy.GetHealth(randomizer, randomizer.GetRng("test/molded-blade-health"));

        Assert.Equal(enemy.BaseHealth * 2.0f, health);
    }

    [Fact]
    public void GetHealth_UsesCallerProvidedRngSequence()
    {
        using var randomizer = CreateRandomizer(config =>
        {
            config["enemy-random-health"] = true;
            config["enemy-health-min-molded"] = 0.75;
            config["enemy-health-max-molded"] = 1.25;
        });

        IEnemyDefinition enemy = EnemyDefinitions.Instance.All.OfType<Molded>().Single();
        var actualRng = randomizer.GetRng("modifier/enemy-health");

        var firstHealth = enemy.GetHealth(randomizer, actualRng);
        var secondHealth = enemy.GetHealth(randomizer, actualRng);

        var expectedRng = randomizer.GetRng("modifier/enemy-health");
        var expectedFirst = enemy.BaseHealth * enemy.GetHealthMultiplier(randomizer, expectedRng);
        var expectedSecond = enemy.BaseHealth * enemy.GetHealthMultiplier(randomizer, expectedRng);

        Assert.Equal(expectedFirst, firstHealth);
        Assert.Equal(expectedSecond, secondHealth);
        Assert.NotEqual(firstHealth, secondHealth);
    }

    [Fact]
    public void EnemyHealthResolver_DebugUniqueHp_MakesRepeatedHealthValuesDistinct()
    {
        using var randomizer = CreateRandomizer(config =>
        {
            config["debug-unique-enemy-hp"] = true;
        });

        var options = new EnemyModifier.EnemyRandomizerOptions(
            EnemyVariety: 1,
            MaxPackSize: 1,
            DebugUniqueHp: true,
            IsBalanced: false,
            ProgressiveDifficulty: false,
            ScaleOptions: new EnemyModifier.ScaleOptions(0.0, 1.0f, 1.0f),
            ForceTargetingProbability: 0.0
        );
        var resolver = new EnemyModifier.EnemyHealthResolver(randomizer, options, randomizer.GetRng("modifier/enemy-health"));
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
