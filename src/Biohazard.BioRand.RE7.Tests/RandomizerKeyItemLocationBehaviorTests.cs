using System.Text;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerKeyItemLocationBehaviorTests
{
    [Fact]
    public void KeyItemLocation_WithInjectedData_RelocatesChainCutter()
    {
        var keyItemsCsv = """
Enabled,OriginalScnFile,NewScnFile,Id,NewX,NewY,NewZ,Comment
TRUE,natives/stm/environment/scene/chapter1/c01_b1f.scn.20,natives/stm/environment/scene/chapter1/c01_corridor01.scn.20,ChainCutter,19.5,1.0,20.5,Test relocation
""";

        using var result = RandomizerTest.RunState(
            config =>
            {
                config["random-key-item-locations"] = true;
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(DynamicDataName.KeyItems, Encoding.UTF8.GetBytes(keyItemsCsv));
            });

        var placements = result.ItemPlacementService.FromId("ChainCutter")
            .Where(x => x.SceneFile == "natives/stm/environment/scene/chapter1/c01_b1f.scn.20")
            .ToArray();
        var originalScene = result.ReadAfterScene("natives/stm/environment/scene/chapter1/c01_b1f.scn.20");
        var beforeRelocatedScene = result.ReadBeforeScene("natives/stm/environment/scene/chapter1/c01_corridor01.scn.20");
        var relocatedScene = result.ReadAfterScene("natives/stm/environment/scene/chapter1/c01_corridor01.scn.20");

        Assert.All(placements, placement => Assert.Null(originalScene.FindGameObject(placement.Guid)));
        Assert.True(result.WasFileModified("natives/stm/environment/scene/chapter1/c01_corridor01.scn.20"));
        Assert.True(relocatedScene.GetGameObjects().Count() > beforeRelocatedScene.GetGameObjects().Count());
    }
}
