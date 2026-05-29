using Enums.app.GameManager;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerChapterJumpBehaviorTests {
    [Fact]
    public void ChapterJumpData_StartChapterMainHouse_ChangesGuestHouseJumpToChapter3() {
        using var result = RandomizerTest.RunState(config => { config["start-chapter"] = "Main House"; });

        var before = RandomizerTestHelpers.GetChapterJump(
            result.ReadBeforeScene(RandomizerTestPaths.ChapterJumpScenePath), RandomizerTestPaths.GuestHouseJumpGuid);
        var after = RandomizerTestHelpers.GetChapterJump(
            result.ReadAfterScene(RandomizerTestPaths.ChapterJumpScenePath), RandomizerTestPaths.GuestHouseJumpGuid);

        Assert.True(result.WasFileModified(RandomizerTestPaths.ChapterJumpScenePath));
        Assert.Equal(ChapterNo.Chapter1, before.JumpChapter);
        Assert.Equal(ChapterNo.Chapter3, after.JumpChapter);
    }

    [Fact]
    public void ChapterJumpData_StartChapterWreckedShip_ChangesGuestHouseJumpToChapter4() {
        using var result = RandomizerTest.RunState(config => { config["start-chapter"] = "Wrecked Ship"; });

        var before = RandomizerTestHelpers.GetChapterJump(
            result.ReadBeforeScene(RandomizerTestPaths.ChapterJumpScenePath), RandomizerTestPaths.GuestHouseJumpGuid);
        var after = RandomizerTestHelpers.GetChapterJump(
            result.ReadAfterScene(RandomizerTestPaths.ChapterJumpScenePath), RandomizerTestPaths.GuestHouseJumpGuid);

        Assert.True(result.WasFileModified(RandomizerTestPaths.ChapterJumpScenePath));
        Assert.Equal(ChapterNo.Chapter1, before.JumpChapter);
        Assert.Equal(ChapterNo.Chapter4, after.JumpChapter);
    }

    [Fact]
    public void ChapterJumpData_StartChapterMainHouse_IsPreservedWhenShuffling() {
        using var result = RandomizerTest.RunState(config => {
            config["start-chapter"] = "Main House";
            config["shuffle-chapters"] = true;
            config["shuffle-chapters-with-ff"] = false;
        });

        var after = RandomizerTestHelpers.GetChapterJump(
            result.ReadAfterScene(RandomizerTestPaths.ChapterJumpScenePath), RandomizerTestPaths.GuestHouseJumpGuid);

        Assert.True(result.WasFileModified(RandomizerTestPaths.ChapterJumpScenePath));
        Assert.Equal(ChapterNo.Chapter3, after.JumpChapter);
    }

    [Fact]
    public void ChapterJumpData_ShuffleWithoutFoundFootage_DerangesMainCampaignTransitions() {
        using var result = RandomizerTest.RunState(config => {
            config["shuffle-chapters"] = true;
            config["shuffle-chapters-with-ff"] = false;
        });

        var candidates = new[]{ ChapterNo.Chapter1, ChapterNo.Chapter3, ChapterNo.Chapter4 };
        var before = RandomizerTestHelpers
            .GetChapterJumps(result.ReadBeforeScene(RandomizerTestPaths.ChapterJumpScenePath))
            .Where(x => candidates.Contains(x.JumpChapter))
            .ToArray();
        var after = RandomizerTestHelpers
            .GetChapterJumps(result.ReadAfterScene(RandomizerTestPaths.ChapterJumpScenePath))
            .Where(x => before.Select(b => b.Guid).Contains(x.Guid))
            .ToArray();

        Assert.True(result.WasFileModified(RandomizerTestPaths.ChapterJumpScenePath));
        Assert.Equal(before.Length, after.Length);
        Assert.Equal(before.Select(x => x.JumpChapter).OrderBy(x => x),
            after.Select(x => x.JumpChapter).OrderBy(x => x));
        Assert.All(after, entry => {
            var original = before.Single(x => x.Guid == entry.Guid);
            Assert.NotEqual(original.JumpChapter, entry.JumpChapter);
        });
    }
}