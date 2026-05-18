using Biohazard.BioRand.RE7.Extensions;
using System.Text.Json.Nodes;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerRandomEventPluginBehaviorTests
{
    [Fact]
    public void RandomEvents_EnableREFrameworkConfigAndInjectPluginSeedMetadata()
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config =>
        {
            config["allow-dlc-items"] = false;
            config["random-events"] = true;
            config["random-events-interval-min"] = 10;
            config["random-events-interval-max"] = 20;
            config["event-player-blindness-duration"] = 3;
            config["event-enemy-max-targets"] = 4;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0xE7E775);
        using var zipDisposable = zip;

        var rootConfigEntry = zip.GetEntry("config.json");
        var reframeworkConfigEntry = zip.GetEntry("reframework/data/BioRand7/config.json");

        Assert.NotNull(rootConfigEntry);
        Assert.NotNull(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(reframeworkConfigEntry);

        var rootConfig = JsonNode.Parse(rootConfigEntry!.GetBytes())!.AsObject();
        var reframeworkConfig = JsonNode.Parse(reframeworkConfigEntry!.GetBytes())!.AsObject();

        Assert.Null(rootConfig["biorand-seed"]);
        Assert.Equal(0xE7E775, reframeworkConfig["biorand-seed"]!.GetValue<int>());
        Assert.True(reframeworkConfig["random-events"]!.GetValue<bool>());
        Assert.Equal(10, reframeworkConfig["random-events-interval-min"]!.GetValue<int>());
        Assert.Equal(20, reframeworkConfig["random-events-interval-max"]!.GetValue<int>());
        Assert.Equal(3, reframeworkConfig["event-player-blindness-duration"]!.GetValue<int>());
        Assert.Equal(4, reframeworkConfig["event-enemy-max-targets"]!.GetValue<int>());
    }

    [Fact]
    public void RandomEvents_InfiniteAmmo_UsesPassiveSkillInfinityFlag()
    {
        var source = ReadPluginSource("REFPlugin.RandomEvents.cs");

        Assert.Contains("case RandomEventKind.WeaponInfiniteAmmo:", source);
        Assert.Contains("ApplyWeaponInfiniteAmmoEvent()", source);
        Assert.Contains("\"set_loadNum\"", source);
        Assert.Contains("PreHookResult.Skip", source);
        Assert.Contains("InfiniteAmmoPassiveSkillDelta", source);
        Assert.Contains("BulletStackNumInfinityCount", source);
        Assert.Contains("PlayerOrder.REFType", source);
        Assert.Contains("PlayerStatus.REFType", source);
    }

    [Fact]
    public void RandomEvents_DebugUi_CanStartEverySupportedEffect()
    {
        var randomEventsSource = ReadPluginSource("REFPlugin.RandomEvents.cs");
        var uiSource = ReadPluginSource("REFPlugin.UI.cs");

        Assert.Contains("activeRandomEventStartedFromUi", randomEventsSource);
        Assert.Contains("StartRandomEventFromUi(RandomEventKind.PlayerStatus)", uiSource);
        Assert.Contains("StartRandomStatusEffectFromUi(delta)", uiSource);
        Assert.Contains("RandomStatusEffectDeltas", uiSource);

        foreach (var kind in new[]
        {
            "PlayerBlindness",
            "PlayerFreeze",
            "PlayerScale",
            "WeaponInfiniteAmmo",
            "WeaponNeuroAmmo",
            "WeaponExplosiveAmmo",
            "EnemySpeed",
            "EnemyInvisible",
            "EnemyWeak",
            "EnemyStrong",
            "EnemyPaused",
        })
        {
            Assert.Contains($"RandomEventKind.{kind}", uiSource);
        }
    }

    private static string ReadPluginSource(string fileName)
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory != null && !File.Exists(Path.Combine(directory.FullName, "biorand-re7.sln")))
        {
            directory = directory.Parent;
        }

        if (directory == null)
            throw new DirectoryNotFoundException("Could not locate repository root.");

        var path = Path.Combine(
            directory.FullName,
            "src",
            "Biohazard.BioRand.RE7.REFrameworkPlugins",
            fileName);
        return File.ReadAllText(path);
    }
}
