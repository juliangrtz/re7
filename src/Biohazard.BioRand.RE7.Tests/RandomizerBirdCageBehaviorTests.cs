using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerBirdCageBehaviorTests {
    private static readonly string[] BirdCageScenePaths =[
        RandomizerTestPaths.BirdCageScenePath,
        PakPath.SceneFile("leveldesign/itemset/chapter3/mainhouse_hall/hard.scn"),
        PakPath.SceneFile("environment/scene/chapter4/c04_cottage.scn"),
        PakPath.SceneFile("leveldesign/itemset/chapter4/shipoutside/hard.scn"),
    ];

    [Fact]
    public void BirdCageModifier_MagnumOption_ChangesMagnumBirdCageRewards() {
        using var result = RandomizerTest.RunState(config => { config["random-bird-cage-magnum"] = true; });

        var before = RandomizerTestHelpers
            .GetBirdCageStates(result.ReadBeforeScene(RandomizerTestPaths.BirdCageScenePath))
            .Where(x => x.ItemId == "Magnum")
            .ToArray();
        var after = RandomizerTestHelpers
            .GetBirdCageStates(result.ReadAfterScene(RandomizerTestPaths.BirdCageScenePath))
            .Where(x => before.Select(b => b.ContainerGuid).Contains(x.ContainerGuid))
            .ToArray();

        Assert.True(result.WasFileModified(RandomizerTestPaths.BirdCageScenePath));
        Assert.NotEmpty(before);
        Assert.All(after, entry => {
            var original = before.Single(x => x.ContainerGuid == entry.ContainerGuid);
            Assert.NotEqual(original.ItemId, entry.ItemId);
        });
    }

    [Fact]
    public void BirdCageModifier_BothOptions_DoesNotDuplicateChangedRewards() {
        using var result = RandomizerTest.RunState(config => {
            config["random-bird-cage-magnum"] = true;
            config["random-bird-cage-drugs-coins"] = true;
        });

        var changed = GetChangedBirdCageStates(result);

        Assert.NotEmpty(changed);
        Assert.Equal(
            changed.Count,
            changed.Select(state => state.ItemId).Distinct(StringComparer.OrdinalIgnoreCase).Count());
    }

    [Fact]
    public void BirdCageModifier_SkipsAlreadyPlacedWeaponRewardsWhenAlternativesExist() {
        using var result = RandomizerTest.RunState(
            config => { config["random-bird-cage-drugs-coins"] = true; },
            prepareRandomizer: randomizer => {
                randomizer.ItemRandomizer.MarkItemPlaced("MachineGun");
                randomizer.DynamicData.SetData(
                    DynamicDataName.BirdCages,
                    System.Text.Encoding.UTF8.GetBytes("""
                                                           Enabled,ItemId,MinAmount,MaxAmount,CoinsMin,CoinsMax,InputItemIds
                                                           true,MachineGun,1,1,7,7,Coin CoinOld
                                                           true,MiaKnife,1,1,3,3,Coin CoinOld
                                                           true,Herb,3,6,2,2,Coin CoinOld
                                                           true,RemedyM,2,4,2,2,Coin CoinOld
                                                           true,RemedyL,1,3,3,3,Coin CoinOld
                                                           true,Gunpowder,3,6,2,2,Coin CoinOld
                                                           true,ChemicalS,2,4,2,2,Coin CoinOld
                                                           true,ShotgunBullet,8,12,3,3,Coin CoinOld
                                                           true,HandgunBullet,15,25,2,2,Coin CoinOld
                                                           true,HandgunBulletL,10,15,2,2,Coin CoinOld
                                                           true,MagnumBullet,4,6,7,7,Coin CoinOld
                                                       """));
            });

        var changed = GetChangedBirdCageStates(result);

        Assert.NotEmpty(changed);
        Assert.DoesNotContain(changed, state => state.ItemId == "MachineGun");
    }

    [Fact]
    public void BirdCageModifier_UsesConfiguredCoinRange() {
        using var result = RandomizerTest.RunState(
            config => { config["random-bird-cage-magnum"] = true; },
            prepareRandomizer: randomizer => {
                randomizer.DynamicData.SetData(
                    DynamicDataName.BirdCages,
                    System.Text.Encoding.UTF8.GetBytes("""
                                                       Enabled,ItemId,MinAmount,MaxAmount,CoinsMin,CoinsMax,InputItemIds
                                                       true,Herb,1,1,4,6,Coin CoinOld
                                                       """));
            });

        var changed = GetChangedBirdCageStates(result);

        Assert.NotEmpty(changed);
        Assert.All(changed, state => {
            Assert.Equal("Herb", state.ItemId);
            Assert.InRange(state.CoinCount, 4, 6);
        });
    }

    [Fact]
    public void BirdCageModifier_BirthdaySkillRewards_UseOverlayVisuals() {
        var scenePath = PakPath.SceneFile("leveldesign/itemset/chapter3/mainhouse_hall/hard.scn");
        using var result = RandomizerTest.RunState(
            config => { config["random-bird-cage-drugs-coins"] = true; },
            prepareRandomizer: randomizer => {
                randomizer.DynamicData.SetData(
                    DynamicDataName.BirdCages,
                    System.Text.Encoding.UTF8.GetBytes("""
                                                       Enabled,ItemId,MinAmount,MaxAmount,CoinsMin,CoinsMax,InputItemIds
                                                       true,skl002,1,1,3,3,Coin CoinOld
                                                       """));
            });

        var before = RandomizerTestHelpers.GetBirdCageStates(result.ReadBeforeScene(scenePath))
            .ToDictionary(state => state.ContainerGuid);
        var beforeScene = result.ReadBeforeScene(scenePath);
        var afterScene = result.ReadAfterScene(scenePath);
        var changed = RandomizerTestHelpers.GetBirdCageStates(afterScene)
            .Where(state =>
                before.TryGetValue(state.ContainerGuid, out var beforeState) &&
                beforeState.ItemId != state.ItemId)
            .ToArray();
        Assert.True(BirthdaySkillVisuals.TryGetResources("skl002", out var visuals));

        Assert.NotEmpty(changed);
        Assert.All(changed, state => {
            Assert.Equal("skl002", state.ItemId);
            var mesh = GetBirdCageItemMesh(afterScene, state.ContainerGuid);
            var beforeTransform = GetBirdCageItemHolder(beforeScene, state.ContainerGuid)
                .FindComponent<GeneratedViaTransform>();
            var afterTransform = GetBirdCageItemHolder(afterScene, state.ContainerGuid)
                .FindComponent<GeneratedViaTransform>();

            Assert.Equal(visuals.Mesh, ((RszResourceNode)mesh["Mesh"]).Value);
            Assert.Equal(visuals.Material, ((RszResourceNode)mesh["Material"]).Value);
            Assert.NotNull(beforeTransform);
            Assert.NotNull(afterTransform);
            AssertQuaternionEquals(
                BirthdaySkillVisuals.CorrectRotation(beforeTransform!.Rotation),
                afterTransform!.Rotation);
        });
        Assert.Contains("natives/stm/props/sm9959_skillpatch02/sm9959_skillpatch02.mesh.220128762",
            result.ChangedFiles.Keys);
        Assert.Contains("natives/stm/props/sm9959_skillpatch02/skl002/skl002.mdf2.21",
            result.ChangedFiles.Keys);
        Assert.Contains("natives/stm/props/sm9959_skillpatch02/skl002/skl002_ALBM.tex.35",
            result.ChangedFiles.Keys);
        Assert.Contains("natives/stm/props/sm9959_skillpatch02/skl002/skl002_ATOS.tex.35",
            result.ChangedFiles.Keys);
        Assert.Contains("natives/stm/props/sm9959_skillpatch02/skl002/skl002_NRMR.tex.35",
            result.ChangedFiles.Keys);
        Assert.Contains("natives/stm/ui/ui0100/tex/ui0105_iam.tex.35", result.ChangedFiles.Keys);
        Assert.DoesNotContain(result.ChangedFiles.Keys,
            path => path.StartsWith(
                "natives/stm/props/sm9959_skillpatch02/skl008/",
                StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(result.ChangedFiles.Keys,
            path => path.StartsWith("natives/stm/props/sm9958_skillpatch01/", StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(result.ChangedFiles.Keys,
            path => path.StartsWith("natives/stm/props/sm9960_skillpatch03/", StringComparison.OrdinalIgnoreCase));
    }

    private static List<BirdCageState> GetChangedBirdCageStates(RandomizerRunResult result) {
        var changed = new List<BirdCageState>();
        foreach (var scenePath in BirdCageScenePaths) {
            var before = RandomizerTestHelpers.GetBirdCageStates(result.ReadBeforeScene(scenePath))
                .ToDictionary(state => state.ContainerGuid);
            var after = RandomizerTestHelpers.GetBirdCageStates(result.ReadAfterScene(scenePath));

            changed.AddRange(after.Where(state =>
                before.TryGetValue(state.ContainerGuid, out var beforeState) &&
                (beforeState.ItemId != state.ItemId ||
                 beforeState.ItemCount != state.ItemCount ||
                 beforeState.CoinCount != state.CoinCount)));
        }

        return changed;
    }

    private static RszObjectNode GetBirdCageItemMesh(RszScene scene, Guid containerGuid) {
        var itemHolder = GetBirdCageItemHolder(scene, containerGuid);
        var mesh = itemHolder.FindComponent("via.render.Mesh");
        Assert.NotNull(mesh);
        return mesh!;
    }

    private static RszGameObject GetBirdCageItemHolder(RszScene scene, Guid containerGuid) {
        var container = scene.FindGameObject(containerGuid);
        Assert.NotNull(container);
        return container!.Children.Single(child => child.FindComponent<app.Item>() != null);
    }

    private static void AssertQuaternionEquals(Quaternion expected, Quaternion actual) {
        if (Quaternion.Dot(expected, actual) < 0) {
            actual = new Quaternion(-actual.X, -actual.Y, -actual.Z, -actual.W);
        }

        Assert.InRange(MathF.Abs(actual.X - expected.X), 0, 0.0001f);
        Assert.InRange(MathF.Abs(actual.Y - expected.Y), 0, 0.0001f);
        Assert.InRange(MathF.Abs(actual.Z - expected.Z), 0, 0.0001f);
        Assert.InRange(MathF.Abs(actual.W - expected.W), 0, 0.0001f);
    }
}
