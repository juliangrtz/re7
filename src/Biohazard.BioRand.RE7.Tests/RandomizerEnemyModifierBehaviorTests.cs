using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Modifiers;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerEnemyModifierBehaviorTests
{
    private const string OldHouseBugEnemyScenePath = "natives/stm/scenes/chapter/chapter3/enemy_c03_3.scn.20";

    private static readonly string[] GeneratorEnemyIds =
    [
        "Molded",
        "MoldedFat",
        "MoldedQuick"
    ];

    [Fact]
    public void SelectAreaEnemyPool_RespectsEnemyVarietyLimit()
    {
        var enemyPool = new[]
        {
            new EnemyModifier.EnemyTableEntry(new TestEnemyDefinition("A", EnemyID.Em4000), 1.0),
            new EnemyModifier.EnemyTableEntry(new TestEnemyDefinition("B", EnemyID.Em4100), 1.0),
            new EnemyModifier.EnemyTableEntry(new TestEnemyDefinition("C", EnemyID.Em4200), 1.0),
            new EnemyModifier.EnemyTableEntry(new TestEnemyDefinition("D", EnemyID.Em5400), 1.0)
        };

        var selectedEnemies = EnemyModifier.SelectAreaEnemyPool(enemyPool, enemyVariety: 2, new Rng(0x42424242));

        Assert.Equal(2, selectedEnemies.Length);
        Assert.Equal(2, selectedEnemies.Select(x => x.Enemy.Id).Distinct(StringComparer.Ordinal).Count());
        Assert.All(selectedEnemies, selected => Assert.Contains(enemyPool, entry => entry.Enemy.Id == selected.Enemy.Id));
    }

    [Fact]
    public void RandomizeEnemies_EnemyVarietyOne_UsesSingleEligibleAliasPerScene()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, GeneratorEnemyIds);
        });

        var changedScenePaths = GetChangedScenePaths(result);
        Assert.NotEmpty(changedScenePaths);

        var scenesWithEligibleSpawns = 0;
        foreach (var path in changedScenePaths)
        {
            var aliases = GetEligibleGeneratorAliases(result.ReadAfterScene(path))
                .SelectMany(x => x)
                .ToList();
            if (aliases.Count == 0)
                continue;

            scenesWithEligibleSpawns++;
            Assert.Single(aliases.Distinct(StringComparer.OrdinalIgnoreCase));
        }

        Assert.True(scenesWithEligibleSpawns > 0);
    }

    [Fact]
    public void RandomizeEnemies_PackMaxSizeOne_AvoidsAdjacentDuplicateAliasesWithinGenerators()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = GeneratorEnemyIds.Length;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, GeneratorEnemyIds);
        });

        var changedScenePaths = GetChangedScenePaths(result);
        Assert.NotEmpty(changedScenePaths);

        var generatorsWithMultipleEligibleSpawns = 0;
        foreach (var path in changedScenePaths)
        {
            foreach (var aliases in GetEligibleGeneratorAliases(result.ReadAfterScene(path)))
            {
                if (aliases.Count < 2)
                    continue;

                generatorsWithMultipleEligibleSpawns++;
                for (var i = 1; i < aliases.Count; i++)
                {
                    Assert.False(
                        string.Equals(aliases[i - 1], aliases[i], StringComparison.OrdinalIgnoreCase),
                        $"Found adjacent duplicate aliases in '{path}': {aliases[i - 1]} then {aliases[i]}.");
                }
            }
        }

        Assert.True(generatorsWithMultipleEligibleSpawns > 0);
    }

    [Fact]
    public void RandomizeEnemies_DoesNotReplaceOldHouseInsectSpawnsWithNonInsects()
    {
        using var result = RandomizerTest.RunState(
            config =>
            {
                config["random-enemies"] = true;
                config["enemy-variety"] = 3;
                config["enemy-pack-max-size"] = 1;
                ConfigureGeneratorEnemyPool(config, ["Molded", "MoldedFat", "JackStalker"]);
            },
            seed: 410980);

        var beforeAliases = GetGeneratorSpawnAliases(result.ReadBeforeScene(OldHouseBugEnemyScenePath), "Bug");
        var afterAliases = GetGeneratorSpawnAliases(result.ReadAfterScene(OldHouseBugEnemyScenePath), "Bug");

        Assert.NotEmpty(beforeAliases);
        Assert.All(beforeAliases, alias => Assert.True(EnemyModifier.IsInsectSpawnAlias(alias)));
        Assert.Equal(beforeAliases, afterAliases);
    }

    private static void ConfigureGeneratorEnemyPool(RandomizerConfiguration configuration, IEnumerable<string> enabledEnemyIds)
    {
        var enabledSet = enabledEnemyIds.ToHashSet(StringComparer.OrdinalIgnoreCase);
        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            configuration[$"enemy-ratio-{enemy.Id.ToLowerInvariant()}"] = enabledSet.Contains(enemy.Id) ? 1.0 : 0.0;
        }
    }

    private static List<string> GetChangedScenePaths(RandomizerRunResult result)
        => result.ChangedFiles.Keys
            .Where(path => path.EndsWith(".scn.20", StringComparison.OrdinalIgnoreCase))
            .OrderBy(path => path, StringComparer.Ordinal)
            .ToList();

    private static List<List<string>> GetEligibleGeneratorAliases(RszScene scene)
    {
        var result = new List<List<string>>();

        scene.VisitGameObjects(gameObject =>
        {
            var enemyGenerator = gameObject.FindComponent<app.EnemyGenerator>();
            if (enemyGenerator?.Enabled != true)
                return;

            var aliases = new List<string>();
            gameObject.VisitGameObjects(child =>
            {
                if (!EnemyModifier.ShouldReplaceSpawnInfo(child))
                    return;

                var spawnInfo = child.FindComponent<app.EnemySpawnInfo>();
                if (spawnInfo != null)
                {
                    aliases.Add(spawnInfo.UnitAlias);
                }
            });

            if (aliases.Count > 0)
            {
                result.Add(aliases);
            }
        });

        return result;
    }

    private static List<string> GetGeneratorSpawnAliases(RszScene scene, string generatorAlias)
    {
        var result = new List<string>();

        scene.VisitGameObjects(gameObject =>
        {
            var enemyGenerator = gameObject.FindComponent<app.EnemyGenerator>();
            if (!string.Equals(enemyGenerator?.Alias, generatorAlias, StringComparison.Ordinal))
                return;

            gameObject.VisitGameObjects(child =>
            {
                if (!EnemyModifier.ShouldReplaceSpawnInfo(child))
                    return;

                var spawnInfo = child.FindComponent<app.EnemySpawnInfo>();
                if (spawnInfo != null)
                {
                    result.Add(spawnInfo.UnitAlias);
                }
            });
        });

        return result;
    }

    private sealed class TestEnemyDefinition(string id, EnemyID enemyId) : IEnemyDefinition
    {
        public string Id { get; } = id;
        public EnemyID EnemyId { get; } = enemyId;
        public EnemyCategory Category => EnemyCategory.Molded;
        public string Name => id;
        public bool IsBoss => false;
        public int BaseHealth => 100;
        public string DirectivesHolderPath => string.Empty;
        public string ResistParamsHolderPath => string.Empty;
        public string OriginalPrefabPath => string.Empty;
        public bool UsesEnemyGenerator => true;
    }
}
