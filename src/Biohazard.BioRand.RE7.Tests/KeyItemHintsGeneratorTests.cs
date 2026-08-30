using Biohazard.BioRand.RE7.Serialization;
using System.Text;

namespace Biohazard.BioRand.RE7.Tests;

public class KeyItemHintsGeneratorTests {
    [Fact]
    public void RenderHtml_RendersOrderedKeyItemsOnEmbeddedFloorPlan() {
        var hints = new[]{
            new KeyItemHint(
                12,
                "Crow <Key>",
                "TalismanKey",
                1,
                "White Dog's Head",
                "Main House & Processing Area",
                "natives/stm/late.scn.20",
                new Guid("0da28012-ad6a-0da5-1f0a-cacd2c677ed3"),
                4,
                5,
                6),
            new KeyItemHint(
                3,
                "Hatch Key",
                "FloorDoorKey",
                2,
                "Dinner <Table>",
                "Main House",
                "natives/stm/early.scn.20",
                new Guid("25295cda-b1c6-428b-47c7-fa9b4bcdaf61"),
                1.25f,
                -2.5f,
                3),
        };

        var html = KeyItemHintsGenerator.RenderHtml(hints, 35825);

        Assert.True(
            html.IndexOf("Hatch Key", StringComparison.Ordinal) <
            html.IndexOf("Crow &lt;Key&gt;", StringComparison.Ordinal));
        Assert.Contains("Key Item Spoiler Maps (Seed 35825)", html);
        Assert.Contains("Hatch Key x2", html);
        Assert.Contains("Dining Area", html);
        Assert.Contains("Living Room", html);
        Assert.Contains("Pickup: Dinner &lt;Table&gt;", html);
        Assert.Contains("data:image/gif;base64,", html);
        Assert.Contains("class=\"map-marker\"", html);
        Assert.Contains("1.25, -2.5, 3", html);
        Assert.DoesNotContain("<table", html);
        Assert.DoesNotContain("Crow <Key>", html);
        Assert.Equal(html, Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(html)));
    }

    [Fact]
    public void RenderHtml_PreservesUnknownPlacementInGraphicalRouteFallback() {
        var hint = new KeyItemHint(
            5,
            "Unknown <Key>",
            "UnknownKey",
            1,
            "Unmapped pickup",
            "Unknown & Region",
            "natives/stm/unknown.scn.20",
            new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
            10,
            20,
            30);

        var html = KeyItemHintsGenerator.RenderHtml([hint], 1);

        Assert.Contains("Other route locations", html);
        Assert.Contains("Unknown &lt;Key&gt;", html);
        Assert.Contains("Unknown &amp; Region", html);
        Assert.Contains("10, 20, 30", html);
    }

    [Fact]
    public void MapCalibration_UsesEmbeddedImagesAndInBoundsMarkers() {
        Assert.NotEmpty(KeyItemMapRepository.Locations);

        foreach (var map in KeyItemMapRepository.Maps) {
            Assert.NotEmpty(EmbeddedData.GetFile($"key_item_maps/{map.FileName}"));
        }

        foreach (var (guid, location) in KeyItemMapRepository.Locations) {
            Assert.True(KeyItemMapRepository.TryGetMap(location.MapId, out var map),
                $"Map '{location.MapId}' for {guid} does not exist.");
            Assert.InRange(location.X, 0, map.Width);
            Assert.InRange(location.Y, 0, map.Height);
        }
    }
}
