using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerExtraEnemyGenerationBehaviorTests
{
    private const string ExtraEnemyScenePath = "natives/stm/scenes/chapter/chapter1/enemy_c01.scn.20";
    private const string RandomExtraEnemyScenePath = "natives/stm/scenes/chapter/chapter4/chapter4_2/moldeads.scn.20";

    [Fact]
    public void ExtraEnemies_AddPlainEnemyTemplatesAtSceneRoot()
    {
        using var result = RunWithExtraEnemies();
        var beforeScene = result.ReadBeforeScene(ExtraEnemyScenePath);
        var afterScene = result.ReadAfterScene(ExtraEnemyScenePath);

        var newGameObjects = GetNewGameObjects(afterScene, beforeScene);
        var newRootEnemies = GetNewRootGameObjects(afterScene, beforeScene)
            .Where(gameObject => gameObject.Name.EndsWith("_Extra", StringComparison.Ordinal))
            .ToList();

        Assert.True(result.WasFileModified(ExtraEnemyScenePath));
        Assert.Equal(2, newRootEnemies.Count);
        Assert.DoesNotContain(newGameObjects, gameObject => gameObject.FindComponent<app.EnemyGenerator>() != null);
        Assert.DoesNotContain(newGameObjects, gameObject => gameObject.FindComponent<app.EnemySpawnInfo>() != null);
        Assert.DoesNotContain(newGameObjects, IsFsmGenerationObject);

        AssertExtraEnemy(newRootEnemies, "Em4000_Extra", -49, 4.88f, 108);
        AssertExtraEnemy(newRootEnemies, "Em4100_Extra", -47.92f, 4.99f, 100.86f);
    }

    [Fact]
    public void ExtraEnemies_RandomId_UsesConfiguredEnemyRatios()
    {
        using var result = RunWithExtraEnemies(
            BuildExtraEnemiesCsv(RandomExtraEnemyScenePath, "random", "random", "random"),
            config =>
            {
                config["enemy-variety"] = 1;
                config["enemy-pack-max-size"] = 1;
                ConfigureEnemyPool(config, "MoldedQuick");
                config["enemy-ratio-moldedquick"] = 1000.0;
            });

        var newRootEnemies = GetNewRootExtraEnemies(result, RandomExtraEnemyScenePath);

        Assert.True(result.WasFileModified(RandomExtraEnemyScenePath));
        Assert.Equal(3, newRootEnemies.Count);
        Assert.All(newRootEnemies, gameObject => Assert.Equal("Em4100_Extra", gameObject.Name));
    }

    [Fact]
    public void ExtraEnemies_RandomId_RespectsEnemyVarietyLimit()
    {
        using var result = RunWithExtraEnemies(
            BuildExtraEnemiesCsv(RandomExtraEnemyScenePath, "random", "random", "random", "random"),
            config =>
            {
                config["enemy-variety"] = 1;
                config["enemy-pack-max-size"] = 1;
                ConfigureEnemyPool(config, "Molded", "MoldedQuick", "MoldedFat");
            });

        var newRootEnemies = GetNewRootExtraEnemies(result, RandomExtraEnemyScenePath);

        Assert.Equal(4, newRootEnemies.Count);
        Assert.Single(newRootEnemies.Select(gameObject => gameObject.Name).Distinct(StringComparer.Ordinal));
    }

    [Fact]
    public void ExtraEnemies_RandomId_RespectsPackMaxSizeOne()
    {
        using var result = RunWithExtraEnemies(
            BuildExtraEnemiesCsv(RandomExtraEnemyScenePath, "random", "random", "random", "random", "random", "random"),
            config =>
            {
                config["enemy-variety"] = 2;
                config["enemy-pack-max-size"] = 1;
                ConfigureEnemyPool(config, "Molded", "MoldedQuick");
                config["enemy-ratio-molded"] = 1000.0;
                config["enemy-ratio-moldedquick"] = 1000.0;
            });

        var newRootEnemies = GetNewRootExtraEnemies(result, RandomExtraEnemyScenePath);
        var enemyNames = newRootEnemies.Select(gameObject => gameObject.Name).ToList();
        var allowedEnemyNames = new HashSet<string>(StringComparer.Ordinal)
        {
            "Em4000_Extra",
            "Em4100_Extra",
            "Em2000_Extra",
        };

        Assert.Equal(6, enemyNames.Count);
        Assert.All(enemyNames, name => Assert.Contains(name, allowedEnemyNames));
        for (var i = 1; i < enemyNames.Count; i++)
        {
            Assert.NotEqual(enemyNames[i - 1], enemyNames[i]);
        }
    }

    [Fact]
    public void ExtraEnemies_RandomId_CanUseCustomExtraEnemyDefinitions()
    {
        using var result = RunWithExtraEnemies(
            BuildExtraEnemiesCsv(RandomExtraEnemyScenePath, "random"),
            config =>
            {
                config["enemy-variety"] = 1;
                config["enemy-pack-max-size"] = 1;
                ConfigureEnemyPool(config);
            });

        var newRootEnemies = GetNewRootExtraEnemies(result, RandomExtraEnemyScenePath);

        var gameObject = Assert.Single(newRootEnemies);
        Assert.Equal("Em2000_Extra", gameObject.Name);
    }

    [Fact]
    public void ExtraEnemies_EnemyMultiplierAboveOne_RoundsAndDuplicatesExtraGameObjects()
    {
        using var result = RunWithExtraEnemies(
            BuildExtraEnemiesCsv(RandomExtraEnemyScenePath, "Em4000", "Em4000", "Em4000"),
            config =>
            {
                config["enemy-multiplier"] = 1.5;
            });

        var newRootEnemies = GetNewRootExtraEnemies(result, RandomExtraEnemyScenePath);
        var positions = GetPositions(newRootEnemies);

        Assert.Equal(5, newRootEnemies.Count);
        Assert.Equal(newRootEnemies.Count, newRootEnemies.Select(gameObject => gameObject.Guid).Distinct().Count());
        Assert.Equal(3, positions.Distinct().Count());
        Assert.Contains(positions.GroupBy(position => position), group => group.Count() > 1);
    }

    [Fact]
    public void ExtraEnemies_EnemyMultiplierBelowOne_RoundsAndTrimsExtraGameObjects()
    {
        using var result = RunWithExtraEnemies(
            BuildExtraEnemiesCsv(RandomExtraEnemyScenePath, "Em4000", "Em4000", "Em4000"),
            config =>
            {
                config["enemy-multiplier"] = 0.5;
            });

        var newRootEnemies = GetNewRootExtraEnemies(result, RandomExtraEnemyScenePath);

        Assert.Equal(2, newRootEnemies.Count);
    }

    [Fact]
    public void ExtraEnemies_PipeSeparatedId_WithUnknownEnemy_Throws()
    {
        var exception = Assert.Throws<InvalidOperationException>(() =>
            RunWithExtraEnemies(BuildExtraEnemiesCsv(RandomExtraEnemyScenePath, "BogusEnemy|")));

        Assert.Contains("Unknown extra enemy id 'BogusEnemy|'", exception.Message, StringComparison.Ordinal);
        Assert.Contains("selected 'BogusEnemy'", exception.Message, StringComparison.Ordinal);
    }

    private static RandomizerRunResult RunWithExtraEnemies()
    {
        var extraEnemiesCsv = $"""
            Enabled,Id,Comment,SceneFile,Chapter,PosX,PosY,PosZ,RotX,RotY,RotZ,RotW
            TRUE,Em4000,Extra molded A,{ExtraEnemyScenePath},1,-49,4.88,108,0,0,0,1
            TRUE,Em4100,Extra molded B,{ExtraEnemyScenePath},1,-47.92,4.99,100.86,0,0,0,1
            """;

        return RunWithExtraEnemies(extraEnemiesCsv);
    }

    private static RandomizerRunResult RunWithExtraEnemies(
        string extraEnemiesCsv,
        Action<RandomizerConfiguration>? configure = null)
        => RandomizerTest.RunState(
            config =>
            {
                config["extra-enemy-amount"] = 1.0;
                configure?.Invoke(config);
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(
                    DynamicDataName.ExtraEnemies,
                    System.Text.Encoding.UTF8.GetBytes(extraEnemiesCsv));
            });

    private static string BuildExtraEnemiesCsv(string scenePath, params string[] enemyIds)
    {
        var builder = new System.Text.StringBuilder();
        builder.AppendLine("Enabled,Id,Comment,SceneFile,Chapter,PosX,PosY,PosZ,RotX,RotY,RotZ,RotW");
        for (var i = 0; i < enemyIds.Length; i++)
        {
            builder.AppendLine($"TRUE,{enemyIds[i]},Random extra {i},{scenePath},4,{-50 + i},5,{100 + i},0,0,0,1");
        }

        return builder.ToString();
    }

    private static void ConfigureEnemyPool(RandomizerConfiguration configuration, params string[] enabledEnemyIds)
    {
        var enabledSet = enabledEnemyIds.ToHashSet(StringComparer.OrdinalIgnoreCase);
        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            configuration[$"enemy-ratio-{enemy.Id.ToLowerInvariant()}"] = enabledSet.Contains(enemy.Id) ? 1.0 : 0.0;
        }
    }

    private static List<RszGameObject> GetNewRootExtraEnemies(RandomizerRunResult result, string scenePath)
    {
        var beforeScene = result.ReadBeforeScene(scenePath);
        var afterScene = result.ReadAfterScene(scenePath);

        return GetNewRootGameObjects(afterScene, beforeScene)
            .Where(gameObject => gameObject.Name.EndsWith("_Extra", StringComparison.Ordinal))
            .ToList();
    }

    private static List<(float X, float Y, float Z)> GetPositions(IEnumerable<RszGameObject> gameObjects)
        => gameObjects
            .Select(gameObject =>
            {
                var position = gameObject.FindComponent<via.Transform>()!.Position;
                return (position.X, position.Y, position.Z);
            })
            .ToList();

    private static List<RszGameObject> GetNewGameObjects(RszScene afterScene, RszScene beforeScene)
        => afterScene.GetGameObjects()
            .Where(gameObject => beforeScene.FindGameObject(gameObject.Guid) == null)
            .ToList();

    private static List<RszGameObject> GetNewRootGameObjects(RszScene afterScene, RszScene beforeScene)
    {
        var beforeRootGuids = beforeScene.Children
            .OfType<RszGameObject>()
            .Select(gameObject => gameObject.Guid)
            .ToHashSet();

        return afterScene.Children
            .OfType<RszGameObject>()
            .Where(gameObject => !beforeRootGuids.Contains(gameObject.Guid))
            .ToList();
    }

    private static bool IsFsmGenerationObject(RszGameObject gameObject)
        => gameObject.FindComponent("via.fsm.Fsm") != null &&
           gameObject.FindComponent("app.TriggerInAction") != null;

    private static void AssertExtraEnemy(
        IReadOnlyCollection<RszGameObject> newRootEnemies,
        string expectedName,
        float expectedX,
        float expectedY,
        float expectedZ)
    {
        var gameObject = Assert.Single(newRootEnemies, gameObject => gameObject.Name == expectedName);
        var transform = gameObject.FindComponent<via.Transform>()!;
        var componentNames = string.Join(", ", gameObject.Components.Select(component => component.Type.Name));

        Assert.True(Math.Abs(transform.Position.X - expectedX) <= 0.001f, $"{expectedName} X mismatch; components: {componentNames}");
        Assert.True(Math.Abs(transform.Position.Y - expectedY) <= 0.001f, $"{expectedName} Y mismatch; components: {componentNames}");
        Assert.True(Math.Abs(transform.Position.Z - expectedZ) <= 0.001f, $"{expectedName} Z mismatch; components: {componentNames}");
    }
}
