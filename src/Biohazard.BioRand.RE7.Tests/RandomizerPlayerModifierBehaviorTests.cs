using Biohazard.BioRand.RE7.Modifiers;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerPlayerModifierBehaviorTests {
    [Fact]
    public void PlayerModifier_MaxHealth_Disabled_DoesNotModifyTable() {
        using var result = RandomizerTest.RunState();

        Assert.False(result.WasFileModified(RandomizerTestPaths.PlayerMaxHealthTablePath));
        Assert.Equal(
            result.ReadBeforeBytes(RandomizerTestPaths.PlayerMaxHealthTablePath),
            result.ReadAfterBytes(RandomizerTestPaths.PlayerMaxHealthTablePath));
    }

    [Fact]
    public void PlayerModifier_Psychostimulants_Disabled_DoesNotModifySystemParameters() {
        using var result = RandomizerTest.RunState();

        Assert.False(result.WasFileModified(RandomizerTestPaths.SystemParameterDataPath));
        Assert.Equal(
            result.ReadBeforeBytes(RandomizerTestPaths.SystemParameterDataPath),
            result.ReadAfterBytes(RandomizerTestPaths.SystemParameterDataPath));
    }

    [Fact]
    public void PlayerModifier_MaxHealth_UsesConfiguredHpRangeForEachTableEntry() {
        using var result = RandomizerTest.RunState(config => {
            config["player-random-max-health"] = true;
            for (var i = 0; i < PlayerModifier.MaxHealthLevels.Count; i++) {
                var level = PlayerModifier.MaxHealthLevels[i];
                var health = 900 + (i * 125);
                config[level.FromConfigId] = health;
                config[level.ToConfigId] = health;
            }
        });

        var before = result.ReadBeforeUserFile<app.PlayerMaxHealthTable>(RandomizerTestPaths.PlayerMaxHealthTablePath);
        var after = result.ReadAfterUserFile<app.PlayerMaxHealthTable>(RandomizerTestPaths.PlayerMaxHealthTablePath);

        Assert.True(result.WasFileModified(RandomizerTestPaths.PlayerMaxHealthTablePath));
        Assert.Equal(before.MaxHealthList.Count, after.MaxHealthList.Count);
        Assert.Equal(PlayerModifier.MaxHealthLevels.Count, after.MaxHealthList.Count);
        for (var i = 0; i < before.MaxHealthList.Count; i++) {
            Assert.Equal(900 + (i * 125), after.MaxHealthList[i]);
        }
    }

    [Fact]
    public void PlayerModifier_Psychostimulants_ScalesDurationAndRange() {
        using var result = RandomizerTest.RunState(config => {
            config["player-random-psychostimulants"] = true;
            config["player-psychostimulant-duration-min"] = 2.0;
            config["player-psychostimulant-duration-max"] = 2.0;
            config["player-psychostimulant-range-min"] = 0.5;
            config["player-psychostimulant-range-max"] = 0.5;
        });

        var before = result.ReadBeforeUserFile<app.SystemParameterData>(RandomizerTestPaths.SystemParameterDataPath);
        var after = result.ReadAfterUserFile<app.SystemParameterData>(RandomizerTestPaths.SystemParameterDataPath);

        Assert.True(result.WasFileModified(RandomizerTestPaths.SystemParameterDataPath));
        Assert.Equal(before.MegusuriParam.MegusuriMaxTime * 2.0f, after.MegusuriParam.MegusuriMaxTime);
        Assert.Equal(before.MegusuriParam.MegusuriRange * 0.5f, after.MegusuriParam.MegusuriRange);
    }
}