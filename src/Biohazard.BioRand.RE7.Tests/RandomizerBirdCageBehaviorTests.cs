namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerBirdCageBehaviorTests
{
    [Fact]
    public void BirdCageModifier_MagnumOption_ChangesMagnumBirdCageRewards()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-bird-cage-magnum"] = true;
        });

        var before = RandomizerTestHelpers.GetBirdCageStates(result.ReadBeforeScene(RandomizerTestPaths.BirdCageScenePath))
            .Where(x => x.ItemId == "Magnum")
            .ToArray();
        var after = RandomizerTestHelpers.GetBirdCageStates(result.ReadAfterScene(RandomizerTestPaths.BirdCageScenePath))
            .Where(x => before.Select(b => b.ContainerGuid).Contains(x.ContainerGuid))
            .ToArray();

        Assert.True(result.WasFileModified(RandomizerTestPaths.BirdCageScenePath));
        Assert.NotEmpty(before);
        Assert.All(after, entry =>
        {
            var original = before.Single(x => x.ContainerGuid == entry.ContainerGuid);
            Assert.NotEqual(original.ItemId, entry.ItemId);
        });
    }
}
