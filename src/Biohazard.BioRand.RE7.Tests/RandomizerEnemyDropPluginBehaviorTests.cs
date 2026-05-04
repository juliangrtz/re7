using Biohazard.BioRand.RE7.Extensions;
using System.Text.Json.Nodes;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerEnemyDropPluginBehaviorTests
{
    [Fact]
    public void EnemyDrops_EnableREFrameworkConfigAndInjectPluginSeedMetadata()
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config =>
        {
            config["random-enemy-drops"] = true;
            config["recipes-add-new"] = false;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0x12345678);
        using var zipDisposable = zip;

        var rootConfigEntry = zip.GetEntry("config.json");
        var reframeworkConfigEntry = zip.GetEntry("reframework/data/BioRand7/config.json");

        Assert.NotNull(rootConfigEntry);
        Assert.NotNull(reframeworkConfigEntry);

        var rootConfig = JsonNode.Parse(rootConfigEntry!.GetBytes())!.AsObject();
        var reframeworkConfig = JsonNode.Parse(reframeworkConfigEntry!.GetBytes())!.AsObject();

        Assert.Null(rootConfig["biorand-seed"]);
        Assert.Equal(0x12345678, reframeworkConfig["biorand-seed"]!.GetValue<int>());
        Assert.True(reframeworkConfig["random-enemy-drops"]!.GetValue<bool>());
    }

    [Fact]
    public void RandomEnemiesStampSaveHook_IncludesREFrameworkPlugin()
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config =>
        {
            config["allow-dlc-items"] = false;
            config["random-enemy-drops"] = false;
            config["recipes-add-new"] = false;
            config["random-enemies"] = true;
            config["enemy-stamp-save-hook"] = true;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0x5AFE);
        using var zipDisposable = zip;

        var reframeworkConfigEntry = zip.GetEntry("reframework/data/BioRand7/config.json");

        Assert.NotNull(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(reframeworkConfigEntry);

        var reframeworkConfig = JsonNode.Parse(reframeworkConfigEntry!.GetBytes())!.AsObject();
        Assert.True(reframeworkConfig["enemy-stamp-save-hook"]!.GetValue<bool>());
    }
}
