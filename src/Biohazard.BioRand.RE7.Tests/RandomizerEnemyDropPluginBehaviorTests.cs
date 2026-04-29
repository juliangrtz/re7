using Biohazard.BioRand.RE7.Extensions;
using System.Text.Json.Nodes;

namespace Biohazard.BioRand.RE7.Tests;

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
}
