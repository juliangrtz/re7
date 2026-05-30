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
    public void PlayerModifier_ReloadSpeed_Disabled_DoesNotModifyTable() {
        using var result = RandomizerTest.RunState();

        Assert.False(result.WasFileModified(RandomizerTestPaths.ReloadSpeedTablePath));
        Assert.Equal(
            result.ReadBeforeBytes(RandomizerTestPaths.ReloadSpeedTablePath),
            result.ReadAfterBytes(RandomizerTestPaths.ReloadSpeedTablePath));
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
    public void PlayerModifier_ReloadSpeed_UsesConfiguredRateRangeForEachTableEntry() {
        using var result = RandomizerTest.RunState(config => {
            config["player-random-reload-speed"] = true;
            for (var i = 0; i < PlayerModifier.ReloadSpeedLevels.Count; i++) {
                var level = PlayerModifier.ReloadSpeedLevels[i];
                var rate = 0.85 + (i * 0.25);
                config[level.FromConfigId] = rate;
                config[level.ToConfigId] = rate;
            }
        });

        var before =
            result.ReadBeforeUserFile<app.PlayerReloadSpeedRateTable>(RandomizerTestPaths.ReloadSpeedTablePath);
        var after = result.ReadAfterUserFile<app.PlayerReloadSpeedRateTable>(RandomizerTestPaths.ReloadSpeedTablePath);

        Assert.True(result.WasFileModified(RandomizerTestPaths.ReloadSpeedTablePath));
        Assert.Equal(before.ReloadSpeedRateList.Count, after.ReloadSpeedRateList.Count);
        Assert.Equal(PlayerModifier.ReloadSpeedLevels.Count, after.ReloadSpeedRateList.Count);
        for (var i = 0; i < before.ReloadSpeedRateList.Count; i++) {
            Assert.Equal(0.85f + (i * 0.25f), after.ReloadSpeedRateList[i], precision: 3);
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