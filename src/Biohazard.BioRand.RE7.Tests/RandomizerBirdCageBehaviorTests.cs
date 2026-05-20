using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;

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
                                                           Enabled,Category,ItemId,MinAmount,MaxAmount,Coins,InputItemIds
                                                           true,Drug,MachineGun,1,1,7,Coin CoinOld
                                                           true,Drug,MiaKnife,1,1,3,Coin CoinOld
                                                           true,Drug,Herb,3,6,2,Coin CoinOld
                                                           true,Drug,RemedyM,2,4,2,Coin CoinOld
                                                           true,Drug,RemedyL,1,3,3,Coin CoinOld
                                                           true,Drug,Gunpowder,3,6,2,Coin CoinOld
                                                           true,Drug,ChemicalS,2,4,2,Coin CoinOld
                                                           true,Drug,ShotgunBullet,8,12,3,Coin CoinOld
                                                           true,Drug,HandgunBullet,15,25,2,Coin CoinOld
                                                           true,Drug,HandgunBulletL,10,15,2,Coin CoinOld
                                                           true,Drug,MagnumBullet,4,6,7,Coin CoinOld
                                                       """));
            });

        var changed = GetChangedBirdCageStates(result);

        Assert.NotEmpty(changed);
        Assert.DoesNotContain(changed, state => state.ItemId == "MachineGun");
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
}