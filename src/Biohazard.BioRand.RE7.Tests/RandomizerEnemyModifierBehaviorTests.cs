using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Modifiers;
using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerEnemyModifierBehaviorTests
{
    private static readonly string DlcActiveRootScenePath = PakPath.SceneFile("scenes/dlc/dlc_active_root.scn");
    private static readonly string DlcChapter8ScenePath = PakPath.SceneFile("scenes/dlc/dlc_chapter8.scn");
    private static readonly string DlcChapter9ScenePath = PakPath.SceneFile("scenes/dlc/dlc_chapter9.scn");
    private static readonly string Ch8ChapterScenePath = PakPath.SceneFile("ch8/scenes/chapter8.scn");
    private static readonly string Ch8GameScenePath = PakPath.SceneFile("ch8/scenes/ch8_game.scn");
    private static readonly string Ch8EnemyScenePath = PakPath.SceneFile("ch8/scenes/chapter/chapter8/enemy_c08.scn");
    private const string Ch8Em4600MeshPath = "CH8/Character/Enemy/em4600/em4600.mesh";
    private const string Ch8Em4600MaterialPath = "CH8/Character/Enemy/em4600/em4600.mdf2";
    private const string Ch8Em4400PrefabPath = "CH8/Prefab/Character/Enemy/Em4400/Em4400.pfb";
    private const string Ch8Em4400DirectivesHolderPath = "CH8/Prefab/Character/Enemy/Em4400/parameter/directives/Em4400DirectivesHolder.user";
    private const string Ch8Em4400ReddishDirectivesHolderPath = "CH8/Prefab/Character/Enemy/Em4400/parameter/directives/Reddish/CH8ReddishEm4400DirectivesHolder.user";
    private const string Ch8Em4600MeshPakPath = "natives/stm/ch8/character/enemy/em4600/em4600.mesh.220128762";
    private const string Ch8Em4600MaterialPakPath = "natives/stm/ch8/character/enemy/em4600/em4600.mdf2.21";
    private const string Ch8Em4600DeadBodyPrefabPakPath = "natives/stm/ch8/prefab/character/enemy/em4600/nomove/em4600deadbody.pfb.17";
    private static readonly string Ch9ChapterScenePath = PakPath.SceneFile("ch9/scenes/chapter/chapter9.scn");
    private static readonly string Ch9InGameScenePath = PakPath.SceneFile("ch9/scenes/chapter/c09_ingame.scn");
    private static readonly string Ch9EnemyScenePath = PakPath.SceneFile("ch9/scenes/chapter/enemy_c09.scn");
    private static readonly string Ch9VfxScenePath = PakPath.SceneFile("ch9/vfx/vfx_scene/vfx_c09.scn");
    private static readonly HashSet<string> MainGameAreaScenePaths = AreaDefinitionRepository.Default.All
        .Where(area => area.Dlc == null)
        .Select(area => area.Path)
        .ToHashSet(StringComparer.OrdinalIgnoreCase);

    private static readonly string[] GeneratorEnemyIds =
    [
        "Molded",
        "MoldedFat",
        "FlyingBug"
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

    [Theory]
    [InlineData("app.EnemySpawnInfoOptionEm4000", true)]
    [InlineData("app.CH8EnemySpawnInfoOptionEm4400", true)]
    [InlineData("app.CH9EnemySpawnInfoOptionEm7700", true)]
    [InlineData("app.EnemySpawnInfoOptionDLC", false)]
    [InlineData("app.EnemySpawnInfoOptionBase", false)]
    public void IsEnemySpecificSpawnInfoOption_RecognizesOnlyConcreteEnemyOptions(string typeName, bool expected)
    {
        Assert.Equal(expected, EnemySpawnInfoComponents.IsEnemySpecificSpawnInfoOption(typeName));
    }

    [Fact]
    public void DlcEnemyDefinitions_MapNotAHeroAliasesToTheirRuntimeOptionStacks()
    {
        var dlcEnemies = EnemyDefinitions.Instance.All
            .Where(enemy => enemy.IsDlc)
            .ToArray();

        Assert.NotEmpty(dlcEnemies);
        Assert.DoesNotContain(dlcEnemies, enemy => enemy.SpawnOptionType == "app.CH8EnemySpawnInfoOptionEm4100");
        Assert.Contains(dlcEnemies, enemy =>
            enemy.Id == "NotAHeroEm4210" &&
            enemy.SpawnOptionType == "app.CH8EnemySpawnInfoOptionEm4200" &&
            enemy.TemplateComponentPrefix == "app.CH8Em4200");
        Assert.Contains(dlcEnemies, enemy =>
            enemy.Id == "NotAHeroEm4600" &&
            enemy.SpawnOptionType == "app.CH8EnemySpawnInfoOptionEm4000" &&
            enemy.TemplateComponentPrefix == "app.CH8Em4000");
        Assert.Contains(dlcEnemies, enemy => enemy.Id == "NotAHeroEm4400" && enemy.Name == "Mama Mold (Em4400)");
        Assert.Contains(dlcEnemies, enemy => enemy.Id == "NotAHeroEm4450" && enemy.Name == "Little Crawler (Em4450)");
        Assert.Contains(dlcEnemies, enemy => enemy.Id == "NotAHeroEm4460" && enemy.Name == "Mama Mold (Em4460)");
        Assert.Contains(dlcEnemies, enemy => enemy.Id == "NotAHeroEm4500" && enemy.IsBoss && enemy.Name == "Mutated Lucas (Em4500)");
        Assert.Contains(dlcEnemies, enemy => enemy.Id == "NotAHeroEm4600" && enemy.Name == "Fumer (Em4600)");
        Assert.Contains(dlcEnemies, enemy => enemy.SpawnOptionType == "app.CH9EnemySpawnInfoOptionEm7700");
    }

    [Fact]
    public void TemplateService_ContainsDlcEnemyTemplatesImportedFromCh8Ch9()
    {
        using var result = RandomizerTest.RunState();
        var templateService = result.Randomizer.TemplateService;
        var importedAliases = new[]
        {
            "Em4210",
            "Em4400",
            "Em4450",
            "Em4460",
            "Em4500",
            "Em4600",
            "Em7500",
            "Em7700",
            "Em7800",
            "Em7900"
        };

        foreach (var alias in importedAliases)
        {
            Assert.True(templateService.HasEnemyTemplate(alias), $"Missing EnemyTemplate_{alias}.");
            Assert.True(templateService.HasEnemySpawnInfo(alias), $"Missing EnemySpawnInfo_{alias}.");
        }
    }

    [Fact]
    public void TemplateService_Em4400TemplateKeepsNotAHeroDirectiveHolders()
    {
        using var result = RandomizerTest.RunState();
        var template = result.Randomizer.TemplateService.GetEnemyTemplate("Em4400");
        var think = template.FindComponent("app.CH8Em4400Think");

        Assert.NotNull(think);
        AssertUserDataPath(think, "DirectivesHolder", Ch8Em4400DirectivesHolderPath);
        AssertUserDataArrayPath(think, "OtherDirectivesHolder", Ch8Em4400ReddishDirectivesHolderPath);
    }

    [Fact]
    public void DlcEnemySupport_StandbysSelectedSupportSceneChainsWithoutActivatingDlcRoots()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4400", "EndOfZoeEm7700"]);
        });

        Assert.False(result.WasFileModified(DlcActiveRootScenePath));
        Assert.False(result.WasFileModified(DlcChapter8ScenePath));
        Assert.False(result.WasFileModified(DlcChapter9ScenePath));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch8ChapterScenePath), "CH8_Game"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch8GameScenePath), "Enemy_c08"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch8EnemyScenePath), "c08_AIMap"));
        Assert.False(IsFolderStandby(result.ReadAfterScene(Ch8GameScenePath), "Mother_c08"));
        Assert.False(IsFolderStandby(result.ReadAfterScene(Ch8EnemyScenePath), "c08_MotherLoder"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9ChapterScenePath), "c09_InGame"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9InGameScenePath), "Enemy_c09"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9InGameScenePath), "VFX_c09"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9EnemyScenePath), "Enemy_c09_1"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9EnemyScenePath), "Enemy_c09_2"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9EnemyScenePath), "Enemy_c09_3"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9EnemyScenePath), "Enemy_c09_4"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9VfxScenePath), "VFX_c09_1"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9VfxScenePath), "VFX_c09_2"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9VfxScenePath), "VFX_c09_3"));
        Assert.True(IsFolderStandby(result.ReadAfterScene(Ch9VfxScenePath), "VFX_c09_4"));
        Assert.True(IsSceneFolderControlDefaultStandby(result.ReadAfterScene(Ch9EnemyScenePath), "Enemy_c09_1"));
        Assert.True(IsSceneFolderControlDefaultStandby(result.ReadAfterScene(Ch9VfxScenePath), "VFX_c09_1"));
    }

    [Fact]
    public void DlcEnemySupport_IncludesREFrameworkPlugin_WhenDlcEnemiesAreEnabled()
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config =>
        {
            config["random-enemies"] = true;
            config["random-enemy-drops"] = false;
            config["allow-dlc-items"] = false;
            config["recipes-add-new"] = false;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4400"]);
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0xD1CE7);
        using var zipDisposable = zip;

        Assert.NotNull(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(zip.GetEntry("reframework/data/BioRand7/config.json"));
    }

    [Fact]
    public void RandomizeEnemies_DlcEnemiesWithTemplatesCanEnterGeneratorPool()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["EndOfZoeEm7700"]);
        });

        Assert.Contains("Constructed an enemy table of size 1:", result.ProcessLog);
        Assert.Contains("End of Zoe Enemy (Em7700)", result.ProcessLog);
        Assert.DoesNotContain("Skipping End of Zoe Enemy (Em7700)", result.ProcessLog);
        Assert.Contains(GetChangedScenePaths(result), path =>
            GetEligibleGeneratorAliases(result.ReadAfterScene(path))
                .Any(aliases => aliases.Contains("Em7700", StringComparer.OrdinalIgnoreCase)));
    }

    [Fact]
    public void RandomizeEnemies_Em4600AddsMeshAndMaterialResourcesToModifiedScenes()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4600"]);
        });

        var em4600Scenes = GetChangedScenePaths(result)
            .Where(path => GetEligibleGeneratorAliases(result.ReadAfterScene(path))
                .Any(aliases => aliases.Contains("Em4600", StringComparer.OrdinalIgnoreCase)))
            .ToArray();

        Assert.NotEmpty(em4600Scenes);
        foreach (var path in em4600Scenes)
        {
            var scnFile = new ScnFile(FileVersions.SceneFileVersion, result.ReadAfterBytes(path));
            Assert.Contains(Ch8Em4600MeshPath, scnFile.Resources, StringComparer.OrdinalIgnoreCase);
            Assert.Contains(Ch8Em4600MaterialPath, scnFile.Resources, StringComparer.OrdinalIgnoreCase);
        }
    }

    [Fact]
    public void RandomizeEnemies_NotAHeroReplacementsUseCh8GeneratorAndPoolComponents()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4600"]);
        });

        var matchingGenerators = 0;
        foreach (var path in GetChangedScenePaths(result))
        {
            result.ReadAfterScene(path).VisitGameObjects(gameObject =>
            {
                var generator = EnemyGenerationComponents.FindGeneratorNode(gameObject);
                if (generator == null || !ContainsSpawnInfoAlias(gameObject, "Em4600"))
                {
                    return;
                }

                matchingGenerators++;
                Assert.Equal(EnemyGenerationComponents.Ch8EnemyGeneratorType, generator.Type.Name);
                var pool = gameObject.Children
                    .Select(EnemyGenerationComponents.FindPoolNode)
                    .SingleOrDefault(component => component != null);
                Assert.NotNull(pool);
                Assert.Equal(EnemyGenerationComponents.Ch8EnemyPoolType, pool.Type.Name);
            });
        }

        Assert.True(matchingGenerators > 0, "Expected at least one Em4600 generator replacement.");
    }

    [Fact]
    public void RandomizeEnemies_NotAHeroReplacementsAddMatchingPoolInstances()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4400"]);
        });

        var matchingGenerators = 0;
        foreach (var path in GetChangedScenePaths(result))
        {
            result.ReadAfterScene(path).VisitGameObjects(gameObject =>
            {
                var generator = EnemyGenerationComponents.FindGeneratorNode(gameObject);
                if (generator == null || !ContainsSpawnInfoAlias(gameObject, "Em4400"))
                {
                    return;
                }

                matchingGenerators++;
                var poolObject = gameObject.Children.Single(child =>
                    EnemyGenerationComponents.FindPoolNode(child) != null);
                var poolInstances = poolObject.Children
                    .Where(child =>
                        child.Name.Equals("Em4400", StringComparison.OrdinalIgnoreCase) &&
                        child.Prefab?.Equals(Ch8Em4400PrefabPath, StringComparison.OrdinalIgnoreCase) == true &&
                        GetGameObjectTag(child).Equals("Enemy", StringComparison.OrdinalIgnoreCase))
                    .ToArray();
                Assert.NotEmpty(poolInstances);
                foreach (var poolInstance in poolInstances)
                {
                    var think = poolInstance.FindComponent("app.CH8Em4400Think");
                    Assert.NotNull(think);
                    AssertUserDataPath(think, "DirectivesHolder", Ch8Em4400DirectivesHolderPath);
                    AssertUserDataArrayPath(think, "OtherDirectivesHolder", Ch8Em4400ReddishDirectivesHolderPath);
                }
                Assert.Contains(poolObject.Children, child =>
                    child.Name.Equals("Em4400", StringComparison.OrdinalIgnoreCase) &&
                    child.Prefab?.Equals(Ch8Em4400PrefabPath, StringComparison.OrdinalIgnoreCase) == true &&
                    GetGameObjectTag(child).Equals("Enemy", StringComparison.OrdinalIgnoreCase));
            });
        }

        Assert.True(matchingGenerators > 0, "Expected at least one Em4400 generator replacement.");
    }

    [Fact]
    public void RandomizeEnemies_NotAHeroReplacementsKeepBaseEnemyGenerateActions()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4400"]);
        });

        var baseGenerateActions = 0;
        var ch8GenerateActions = 0;
        foreach (var path in GetChangedScenePaths(result))
        {
            var scene = result.ReadAfterScene(path);
            var ch8SpawnInfoGuids = GetSpawnInfoGameObjects(scene, "Em4400")
                .Select(spawnInfo => spawnInfo.Guid)
                .ToHashSet();
            if (ch8SpawnInfoGuids.Count == 0)
            {
                continue;
            }

            foreach (var action in GetEnemyGenerateActions(scene, ch8SpawnInfoGuids))
            {
                if (action.Type.Name == EnemyGenerateActionComponents.Ch8EnemyGenerateType)
                {
                    ch8GenerateActions++;
                }
                else if (action.Type.Name == EnemyGenerateActionComponents.EnemyGenerateType)
                {
                    baseGenerateActions++;
                }
            }
        }

        Assert.True(baseGenerateActions > 0, "Expected at least one base enemy generate action to reference an Em4400 spawn info.");
        Assert.Equal(0, ch8GenerateActions);
    }

    [Fact]
    public void RandomizeEnemies_NotAHeroReplacementsRemainMultipliableWithCh8GeneratorComponents()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            config["enemy-multiplier"] = 1.25;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4600"]);
        });

        Assert.Contains(GetChangedScenePaths(result), path =>
            GetEligibleGeneratorAliases(result.ReadAfterScene(path))
                .Any(aliases => aliases.Contains("Em4600", StringComparer.OrdinalIgnoreCase)));
    }

    [Theory]
    [InlineData("NotAHeroEm4210", "Em4210", "app.CH8EnemySpawnInfo")]
    [InlineData("NotAHeroEm4460", "Em4460", "app.CH8EnemySpawnInfo")]
    [InlineData("NotAHeroEm4600", "Em4600", "app.CH8EnemySpawnInfo")]
    [InlineData("EndOfZoeEm7700", "Em7700", "app.CH9EnemySpawnInfo")]
    public void RandomizeEnemies_DlcEnemyReplacementsUseDlcSpawnInfoComponents(
        string enabledEnemyId,
        string enemyAlias,
        string expectedSpawnInfoType)
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, [enabledEnemyId]);
        });

        var spawnInfos = GetChangedScenePaths(result)
            .SelectMany(path => GetSpawnInfoGameObjects(result.ReadAfterScene(path), enemyAlias))
            .ToArray();

        Assert.NotEmpty(spawnInfos);
        foreach (var spawnInfoGameObject in spawnInfos)
        {
            Assert.Equal(
                expectedSpawnInfoType,
                EnemySpawnInfoComponents.FindSpawnInfoNode(spawnInfoGameObject)?.Type.Name);
        }
    }

    [Fact]
    public void RandomizeEnemies_DlcEnemyReplacementsKeepSetupCriticalParameters()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4600"]);
        });

        var spawnInfos = GetChangedScenePaths(result)
            .SelectMany(path => GetSpawnInfoGameObjects(result.ReadAfterScene(path), "Em4600"))
            .Select(EnemySpawnInfoComponents.FindSpawnInfoNode)
            .OfType<RszObjectNode>()
            .ToArray();

        Assert.NotEmpty(spawnInfos);
        foreach (var spawnInfo in spawnInfos)
        {
            AssertNonNullField(spawnInfo, "MapParameter");
            AssertNonNullField(spawnInfo, "HealthParameter");
            AssertNonNullField(spawnInfo, "spawnNeedArea");
        }
    }

    [Fact]
    public void RandomizeEnemies_Em4600CopiesAssetFilesIntoOutputPak()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["NotAHeroEm4600"]);
        });

        AssertCopiedIfInputExists(result, Ch8Em4600MeshPakPath);
        AssertCopiedIfInputExists(result, Ch8Em4600MaterialPakPath);
        Assert.True(result.WasFileModified(Ch8Em4600DeadBodyPrefabPakPath));
    }

    [Fact]
    public void RandomizeEnemies_DlcEnemiesWithoutImportedTemplatesAreSkipped()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemies"] = true;
            config["enemy-variety"] = 1;
            config["enemy-pack-max-size"] = 1;
            ConfigureGeneratorEnemyPool(config, ["EndOfZoeEm5700"]);
        });

        Assert.Contains("Skipping End of Zoe Enemy (Em5700): missing EnemyTemplate_Em5700.", result.ProcessLog);
        Assert.Contains("Constructed an empty enemy table! Aborting...", result.ProcessLog);
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
            .Where(MainGameAreaScenePaths.Contains)
            .OrderBy(path => path, StringComparer.Ordinal)
            .ToList();

    private static List<List<string>> GetEligibleGeneratorAliases(RszScene scene)
    {
        var result = new List<List<string>>();

        scene.VisitGameObjects(gameObject =>
        {
            var enemyGenerator = EnemyGenerationComponents.FindGeneratorNode(gameObject);
            if (enemyGenerator == null || !EnemyGenerationComponents.IsEnabled(enemyGenerator))
                return;

            var aliases = new List<string>();
            gameObject.VisitGameObjects(child =>
            {
                if (!EnemyModifier.ShouldReplaceSpawnInfo(child))
                    return;

                var spawnInfo = EnemySpawnInfoComponents.FindSpawnInfo(child);
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

    private static bool ContainsSpawnInfoAlias(RszGameObject gameObject, string alias)
    {
        var result = false;
        gameObject.VisitGameObjects(child =>
        {
            if (EnemySpawnInfoComponents.FindSpawnInfo(child)?.UnitAlias.Equals(alias, StringComparison.OrdinalIgnoreCase) == true)
            {
                result = true;
            }
        });
        return result;
    }

    private static string GetGameObjectTag(RszGameObject gameObject)
    {
        Assert.NotEqual(-1, gameObject.Settings.Type.FindFieldIndex("Tag"));
        return ((RszStringNode)gameObject.Settings["Tag"]).Value;
    }

    private static List<RszObjectNode> GetEnemyGenerateActions(RszScene scene, HashSet<Guid> spawnInfoGuids)
    {
        var result = new List<RszObjectNode>();
        scene.VisitGameObjects(gameObject =>
        {
            foreach (var component in gameObject.Components)
            {
                component.Visit(node =>
                {
                    if (node is RszObjectNode objectNode &&
                        EnemyGenerateActionComponents.IsSingleEnemyGenerateAction(objectNode) &&
                        spawnInfoGuids.Contains(EnemyGenerateActionComponents.GetSpawnInfo(objectNode)))
                    {
                        result.Add(objectNode);
                    }
                });
            }
        });
        return result;
    }

    private static List<RszGameObject> GetSpawnInfoGameObjects(RszScene scene, string alias)
    {
        var result = new List<RszGameObject>();
        scene.VisitGameObjects(gameObject =>
        {
            if (EnemySpawnInfoComponents.FindSpawnInfo(gameObject)?.UnitAlias.Equals(alias, StringComparison.OrdinalIgnoreCase) == true)
            {
                result.Add(gameObject);
            }
        });
        return result;
    }

    private static void AssertNonNullField(RszObjectNode node, string fieldName)
    {
        Assert.NotEqual(-1, node.Type.FindFieldIndex(fieldName));
        Assert.False(node[fieldName] is RszNullNode, $"Expected '{node.Type.Name}.{fieldName}' to remain non-null.");
    }

    private static void AssertUserDataPath(RszObjectNode node, string fieldName, string expectedPath)
    {
        Assert.NotEqual(-1, node.Type.FindFieldIndex(fieldName));
        var userData = Assert.IsType<RszUserDataNode>(node[fieldName]);
        Assert.False(userData.IsEmpty, $"Expected '{node.Type.Name}.{fieldName}' to keep a userdata reference.");
        Assert.Equal(expectedPath, userData.Path);
    }

    private static void AssertUserDataArrayPath(RszObjectNode node, string fieldName, string expectedPath)
    {
        Assert.NotEqual(-1, node.Type.FindFieldIndex(fieldName));
        var array = Assert.IsType<RszArrayNode>(node[fieldName]);
        var userData = Assert.Single(array.Children.OfType<RszUserDataNode>());
        Assert.False(userData.IsEmpty, $"Expected '{node.Type.Name}.{fieldName}' to keep a userdata reference.");
        Assert.Equal(expectedPath, userData.Path);
    }

    private static bool IsFolderStandby(RszScene scene, string folderName)
    {
        var result = false;
        VisitSceneNodes(scene, node =>
        {
            if (node is RszFolder folder &&
                folder.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase) &&
                folder.Settings["Standby"] is RszValueNode standby)
            {
                result = RszSerializer.Deserialize<bool>(standby);
            }
        });
        return result;
    }

    private static bool IsSceneFolderControlDefaultStandby(RszScene scene, string controlName)
    {
        var result = false;
        scene.VisitComponents(component =>
        {
            if (component.Type.Name != "app.SceneFolderControl")
            {
                return;
            }

            var currentControlName = ((RszStringNode)component["ControlName"]).Value;
            if (currentControlName.Equals(controlName, StringComparison.OrdinalIgnoreCase) &&
                component["isDefaultStandby"] is RszValueNode defaultStandby)
            {
                result = RszSerializer.Deserialize<bool>(defaultStandby);
            }
        });
        return result;
    }

    private static string? GetFolderScenePath(RszScene scene, string folderName)
    {
        string? result = null;
        VisitSceneNodes(scene, node =>
        {
            if (node is RszFolder folder &&
                folder.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase) &&
                folder.Settings["ScenePath"] is RszResourceNode scenePath)
            {
                result = scenePath.Value;
            }
        });
        return result;
    }

    private static void VisitSceneNodes(IRszSceneNode node, Action<IRszSceneNode> visitor)
    {
        visitor(node);
        foreach (var child in node.Children)
        {
            VisitSceneNodes(child, visitor);
        }
    }

    private static void AssertCopiedIfInputExists(RandomizerRunResult result, string path)
    {
        try
        {
            result.ReadBeforeBytes(path);
        }
        catch (InvalidOperationException)
        {
            return;
        }

        Assert.True(result.WasFileModified(path), $"Expected '{path}' to be copied into the output pak.");
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
