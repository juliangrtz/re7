using System.Text;

namespace Biohazard.BioRand.RE7.Tests;

public class KeyItemHintsGeneratorTests {
    [Fact]
    public void RenderHtml_OrdersHintsByRouteAndEscapesGameData() {
        var hints = new[]{
            new KeyItemHint(
                12,
                "Crow <Key>",
                "TalismanKey",
                1,
                "Old House & Greenhouse",
                "natives/stm/late.scn.20",
                new Guid("22222222-2222-2222-2222-222222222222"),
                4,
                5,
                6),
            new KeyItemHint(
                3,
                "Hatch Key",
                "FloorDoorKey",
                2,
                "Main House",
                "natives/stm/early.scn.20",
                new Guid("11111111-1111-1111-1111-111111111111"),
                1.25f,
                -2.5f,
                3),
        };

        var html = KeyItemHintsGenerator.RenderHtml(hints, 35825);

        Assert.True(
            html.IndexOf("Hatch Key", StringComparison.Ordinal) <
            html.IndexOf("Crow &lt;Key&gt;", StringComparison.Ordinal));
        Assert.Contains("BioRand RE7 &mdash; Key Item Locations (Seed 35825)", html);
        Assert.Contains("Hatch Key x2", html);
        Assert.Contains("Old House &amp; Greenhouse", html);
        Assert.Contains("1.25, -2.5, 3", html);
        Assert.DoesNotContain("Crow <Key>", html);
        Assert.Equal(html, Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(html)));
    }
}
