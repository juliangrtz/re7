using System.IO.Compression;

namespace Biohazard.BioRand.RE7.Tests;

public class REFrameworkTests
{
    private const string REFrameworkDirectoryName = "reframework";

    private static bool ContainsREFramework(ZipArchive zip)
    {
        return zip.Entries
            .Select(e => e.FullName)
            .Any(name => name.StartsWith($"{REFrameworkDirectoryName}/"));
    }

    [Fact]
    public void Test_REFramework_Included()
    {
        // Given
        var config = """
            {
              "game-version": "dx12_rt",
              "recipes-add-new": true,
              "recipes-replace-original": true,
              "recipes-show-in-menu": true,
              "recipes-randomization-mode": "Crazy",
              "recipes-new-min": 20,
              "recipes-new-max": 20
            }
            """;

        // When
        var (resultZip, _) = RandomizerTest.Run(config);

        // Then
        Assert.True(ContainsREFramework(resultZip));
    }

    [Fact]
    public void Test_REFramework_Excluded()
    {
        // Given
        var config = """
            {
              "game-version": "dx12_rt"
            }
            """;

        // When
        var (resultZip, _) = RandomizerTest.Run(config);

        // Then
        Assert.False(ContainsREFramework(resultZip));
    }

    [Fact]
    public void Test_REFramework_Force_Debug()
    {
        // Given
        var config = """
            {
              "game-version": "dx12_rt",
              "recipes-add-new": false,
              "recipes-replace-original": false,
              "recipes-show-in-menu": false,
              "recipes-randomization-mode": "Crazy",
              "recipes-new-min": 0,
              "recipes-new-max": 0,
              "debug-force-reframework": true
            }
            """;

        // When
        var (resultZip, _) = RandomizerTest.Run(config);

        // Then
        Assert.True(ContainsREFramework(resultZip));
    }
}