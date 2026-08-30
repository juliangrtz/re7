using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class AreaServiceTests {
    [Fact]
    public void Areas_AreOrderedOrdinallyForCrossPlatformDeterminism() {
        using var result = RandomizerTest.RunState();

        var paths = result.AreaService.Areas.Select(area => area.Path).ToArray();

        Assert.Equal(paths.Order(StringComparer.Ordinal), paths);
    }

    [Fact]
    public void FindAreaContainingGameObject_ReturnsOwningAreaForLoadedSceneGuid() {
        using var result = RandomizerTest.RunState();

        var area = result.AreaService.Areas.FirstOrDefault(x => TryGetFirstGuid(x.Scene, out _));
        Assert.NotNull(area);
        Assert.True(TryGetFirstGuid(area!.Scene, out var guid));

        var resolvedArea = result.AreaService.FindAreaContainingGameObject(guid);

        Assert.NotNull(resolvedArea);
        Assert.NotNull(resolvedArea!.Scene.FindGameObject(guid));
    }

    private static bool TryGetFirstGuid(IRszSceneNode node, out Guid guid) {
        Guid? firstGuid = null;
        node.VisitGameObjects(gameObject => {
            if (firstGuid == null) {
                firstGuid = gameObject.Guid;
            }
        });
        guid = firstGuid ?? Guid.Empty;
        return firstGuid != null;
    }
}
