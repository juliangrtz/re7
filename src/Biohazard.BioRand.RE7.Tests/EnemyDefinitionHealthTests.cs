using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Impl;
using Biohazard.BioRand.RE7.Modifiers;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;
using System.Reflection;
namespace Biohazard.BioRand.RE7.Tests;

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
            ScaleOptions: new EnemyModifier.ScaleOptions(0.0, 1.0f, 1.0f)
        );
        var resolver = new EnemyModifier.EnemyHealthResolver(randomizer, options, randomizer.GetRng("modifier/enemy-health"));
        IEnemyDefinition enemy = EnemyDefinitions.Instance.All.OfType<Molded>().Single();

        var firstHealth = resolver.GetHealth(enemy);
        var secondHealth = resolver.GetHealth(enemy);

        Assert.Equal(enemy.BaseHealth, firstHealth);
        Assert.NotEqual(firstHealth, secondHealth);
        Assert.True(secondHealth > firstHealth);
    }

    [Fact]
    public void AddEnemyToGenerator_UsesRandomizedHealthForNewSpawnInfos()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["enemy-random-health"] = true;
            config["enemy-health-min-molded"] = 2.0;
            config["enemy-health-max-molded"] = 2.0;
        });

        var modifier = new EnemyModifier();
        var addEnemyToGenerator = typeof(EnemyModifier).GetMethod("AddEnemyToGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.NotNull(addEnemyToGenerator);

        IEnemyDefinition definition = EnemyDefinitions.Instance.All.OfType<Molded>().Single();
        var placement = new EnemyModifier.ExtraEnemyPlacement
        {
            Id = definition.EnemyId.ToString()
        };
        var options = new EnemyModifier.EnemyRandomizerOptions(
            EnemyVariety: 1,
            MaxPackSize: 1,
            DebugUniqueHp: false,
            IsBalanced: false,
            ProgressiveDifficulty: false,
            ScaleOptions: new EnemyModifier.ScaleOptions(0.0, 1.0f, 1.0f)
        );
        var transform = new via.Transform
        {
            Position = Vector3.Zero,
            Rotation = Quaternion.Identity,
            Scale = Vector3.One
        };
        var healthResolver = new EnemyModifier.EnemyHealthResolver(result.Randomizer, options, result.Randomizer.GetRng("modifier/enemy-health"));
        var logger = new RandomizerLogger();

        var generator = result.Randomizer.TemplateService.GetObject("EnemyGenerator").Clone();
        var invocationResult = addEnemyToGenerator!.Invoke(
            modifier,
            [
                result.Randomizer,
                logger,
                generator,
                placement,
                definition,
                transform,
                options,
                result.Randomizer.GetRng("modifier/enemy-scale"),
                healthResolver
            ]);

        Assert.NotNull(invocationResult);
        var (updatedGenerator, spawnInfoGuid) = ((RszGameObject, Guid))invocationResult!;
        var spawnInfoGameObject = updatedGenerator.FindGameObject(spawnInfoGuid);
        Assert.NotNull(spawnInfoGameObject);

        var spawnInfo = spawnInfoGameObject!.FindComponent<app.EnemySpawnInfo>();
        Assert.NotNull(spawnInfo);
        Assert.Equal(definition.BaseHealth * 2.0f, spawnInfo!.HealthParameter.Health);
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
