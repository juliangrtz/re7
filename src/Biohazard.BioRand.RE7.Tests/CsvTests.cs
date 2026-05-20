using Biohazard.BioRand.RE7.Serialization;
using System.Globalization;
using System.Text;

namespace Biohazard.BioRand.RE7.Tests;

public class CsvTests {
    [Fact]
    public void Deserialize_UsesInvariantCultureForDecimalScalars() {
        var originalCulture = CultureInfo.CurrentCulture;
        try {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            var csv = Encoding.UTF8.GetBytes("""
                                             FloatValue,DoubleValue
                                             4.88,0.25
                                             """);

            var row = Assert.Single(Csv.Deserialize<DecimalRow>(csv));

            Assert.Equal(4.88f, row.FloatValue, 3);
            Assert.Equal(0.25, row.DoubleValue, 3);
        }
        finally {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    [Fact]
    public void Deserialize_MapsBomPrefixedFirstHeader() {
        var csv = Encoding.UTF8.GetBytes("\uFEFFName,Value\nMain Hall,7\n");

        var row = Assert.Single(Csv.Deserialize<BomHeaderRow>(csv));

        Assert.Equal("Main Hall", row.Name);
        Assert.Equal(7, row.Value);
    }

    private sealed class DecimalRow {
        public float FloatValue { get; init; }
        public double DoubleValue { get; init; }
    }

    private sealed class BomHeaderRow {
        public string Name { get; init; } = "";
        public int Value { get; init; }
    }
}