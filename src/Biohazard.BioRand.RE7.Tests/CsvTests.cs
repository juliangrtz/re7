using Biohazard.BioRand.RE7.Serialization;
using System.Globalization;
using System.Text;

namespace Biohazard.BioRand.RE7.Tests;

public class CsvTests
{
    [Fact]
    public void Deserialize_UsesInvariantCultureForDecimalScalars()
    {
        var originalCulture = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            var csv = Encoding.UTF8.GetBytes("""
                FloatValue,DoubleValue
                4.88,0.25
                """);

            var row = Assert.Single(Csv.Deserialize<DecimalRow>(csv));

            Assert.Equal(4.88f, row.FloatValue, 3);
            Assert.Equal(0.25, row.DoubleValue, 3);
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    private sealed class DecimalRow
    {
        public float FloatValue { get; init; }
        public double DoubleValue { get; init; }
    }
}
