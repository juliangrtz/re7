using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerExtraEnemyGenerationBehaviorTests
{
    private const string ExtraEnemyScenePath = "natives/stm/scenes/chapter/chapter1/enemy_c01.scn.20";

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

    private static RandomizerRunResult RunWithExtraEnemies()
    {
        var extraEnemiesCsv = $"""
            Enabled,Id,Comment,SceneFile,Chapter,PosX,PosY,PosZ,RotX,RotY,RotZ,RotW
            TRUE,Em4000,Extra molded A,{ExtraEnemyScenePath},1,-49,4.88,108,0,0,0,1
            TRUE,Em4100,Extra molded B,{ExtraEnemyScenePath},1,-47.92,4.99,100.86,0,0,0,1
            """;

        return RandomizerTest.RunState(
            config =>
            {
                config["extra-enemy-amount"] = 1.0;
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(
                    DynamicDataName.ExtraEnemies,
                    System.Text.Encoding.UTF8.GetBytes(extraEnemiesCsv));
            });
    }

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
