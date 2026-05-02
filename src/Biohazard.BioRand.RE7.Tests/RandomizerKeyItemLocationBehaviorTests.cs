using System.Text;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerKeyItemLocationBehaviorTests
{
    [Fact]
    public void KeyItemLocation_WithMultipleCandidateLocations_RelocatesSingleChainCutter()
    {
        var expectedGuid = new Guid("1a17da81-3f83-47a1-ac82-ead889f829fc");
        var keyItemsCsv = """
        Enabled,OriginalScnFile,KeyItemGuid,NewScnFile,Id,NewX,NewY,NewZ,Comment
        TRUE,natives/stm/environment/scene/chapter1/c01_b1f.scn.20,1a17da81-3f83-47a1-ac82-ead889f829fc,natives/stm/environment/scene/chapter1/c01_b1c.scn.20,ChainCutter,16.46,-6.581,23.8,Alternative Bolt Cutter Location 1
        TRUE,natives/stm/environment/scene/chapter1/c01_b1f.scn.20,1a17da81-3f83-47a1-ac82-ead889f829fc,natives/stm/environment/scene/chapter1/c01_b1c.scn.20,ChainCutter,13.443,-6,23.605,Alternative Bolt Cutter Location 2
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
        var beforeRelocatedScene = result.ReadBeforeScene("natives/stm/environment/scene/chapter1/c01_b1c.scn.20");
        var relocatedScene = result.ReadAfterScene("natives/stm/environment/scene/chapter1/c01_b1c.scn.20");
        var expectedPlacement = Assert.Single(placements, placement => placement.Guid == expectedGuid);

        Assert.All(placements, placement => Assert.Null(originalScene.FindGameObject(placement.Guid)));
        var relocatedGameObjects = placements
            .Select(placement => (Placement: placement, GameObject: relocatedScene.FindGameObject(placement.Guid)))
            .Where(x => x.GameObject != null)
            .ToArray();

        var relocated = Assert.Single(relocatedGameObjects);
        var relocatedGameObject = Assert.IsType<RszGameObject>(relocated.GameObject);
        Assert.Equal(expectedGuid, relocatedGameObject.Guid);

        var relocatedItem = relocatedGameObject.FindComponent<app.Item>();
        Assert.NotNull(relocatedItem);
        Assert.Equal("ChainCutter", relocatedItem!.ItemDataID);
        Assert.Equal(expectedPlacement.SaveGuid, relocatedItem.SaveGUID);

        var relocatedTransform = relocatedGameObject.FindComponent<via.Transform>();
        Assert.NotNull(relocatedTransform);
        Assert.True(
            PositionMatches(relocatedTransform!, 16.46f, -6.581f, 23.8f)
            || PositionMatches(relocatedTransform!, 13.443f, -6f, 23.605f));

        var dynamicParent = Assert.IsType<RszGameObject>(
            relocatedScene.FindGameObject(gameObject => gameObject.Name.EndsWith("_dynamic")));
        Assert.Contains(dynamicParent.Children, child => child.Guid == relocatedGameObject.Guid);
        Assert.True(result.WasFileModified("natives/stm/environment/scene/chapter1/c01_b1c.scn.20"));
        Assert.True(relocatedScene.GetGameObjects().Count() > beforeRelocatedScene.GetGameObjects().Count());
    }

    private static bool PositionMatches(via.Transform transform, float x, float y, float z)
    {
        const float tolerance = 0.001f;
        return Math.Abs(transform.Position.X - x) <= tolerance
            && Math.Abs(transform.Position.Y - y) <= tolerance
            && Math.Abs(transform.Position.Z - z) <= tolerance;
    }
}
