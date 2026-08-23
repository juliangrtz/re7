using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Modifiers;
using IntelOrca.Biohazard.REE.Rsz;
using System.Text.Json.Nodes;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerMadhouseSaveBehaviorTests {
    [Fact]
    public void MadhouseNormalSaves_ClearAutosaveHardNoSaveFlags() {
        using var result = RandomizerTest.RunState(config => { config[MadhouseSaveModifier.ConfigKey] = true; });

        var baselineFlags = 0;
        var patchedFlags = 0;
        foreach (var path in MadhouseSaveModifier.AutosaveScenePaths) {
            baselineFlags += CountHardNoSaveFlags(result.ReadBeforeScene(path));
            patchedFlags += CountHardNoSaveFlags(result.ReadAfterScene(path));
            Assert.True(result.WasFileModified(path), $"Expected save scene to be modified: {path}");
        }

        Assert.True(baselineFlags > 0);
        Assert.Equal(0, patchedFlags);
    }

    [Fact]
    public void MadhouseNormalSaves_IncludesREFrameworkConfigAndPlugin_WhenEnabled() {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config => {
            config["allow-dlc-items"] = false;
            config["random-enemy-drops"] = false;
            config[MadhouseSaveModifier.ConfigKey] = true;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0x5A7E);
        using var zipDisposable = zip;

        var scriptEntry = zip.GetEntry("reframework/autorun/BioRand7/madhouse_saves.lua");
        var reframeworkConfigEntry = zip.GetEntry("reframework/data/BioRand7/config.json");

        Assert.NotNull(zip.GetEntry("reframework/autorun/BioRand7.lua"));
        Assert.NotNull(scriptEntry);
        Assert.Null(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(reframeworkConfigEntry);

        var reframeworkConfig = JsonNode.Parse(reframeworkConfigEntry!.GetBytes())!.AsObject();
        Assert.True(reframeworkConfig[MadhouseSaveModifier.ConfigKey]!.GetValue<bool>());
    }

    private static int CountHardNoSaveFlags(RszScene scene) {
        var count = 0;
        scene.Visit(node => {
            if (node is not RszObjectNode objectNode)
                return node;

            if (objectNode.Type.Name == "app.TriggerInAction" &&
                objectNode["ExtraCommand"] is RszObjectNode extraCommand &&
                ReadBoolean(extraCommand, "IsHardNoSave")) {
                count++;
            }

            if (objectNode.Type.Name == "app.fsm.AutoSave" &&
                ReadBoolean(objectNode, "IsHardNoSave")) {
                count++;
            }

            return node;
        });

        return count;
    }

    private static bool ReadBoolean(RszObjectNode objectNode, string fieldName)
        => objectNode.Type.FindFieldIndex(fieldName) != -1 &&
           objectNode[fieldName] is RszValueNode valueNode &&
           RszSerializer.Deserialize<bool>(valueNode);
}
