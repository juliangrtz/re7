namespace Biohazard.BioRand.RE7.Tests;

public class RngTests {
    [Fact]
    public void NextInclusive_CanReturnUpperBound() {
        var rng = new Rng(0);
        var values = Enumerable.Range(0, 100)
            .Select(_ => rng.NextInclusive(1, 2))
            .ToHashSet();

        Assert.Contains(1, values);
        Assert.Contains(2, values);
    }
}