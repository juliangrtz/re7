using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using BioHazard.BioRand.RE7;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Package;
using System.IO.Compression;

namespace Biohazard.BioRand.RE7.Tests;

public static class RandomizerTest
{
    private static readonly string BiorandDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        ".biorand"
    );

    private const string PAKName = "biorand-re7.pak";

    private static readonly string PAKPath = Path.Combine(
        BiorandDirectory,
        PAKName
    );

    static RandomizerTest()
    {
        if (!Directory.Exists(BiorandDirectory))
        {
            Directory.CreateDirectory(BiorandDirectory);
        }

        if (!File.Exists(PAKPath))
        {
            File.WriteAllBytes(PAKPath, EmbeddedData.GetFile(PAKName));
        }

        /*
        AppDomain.CurrentDomain.ProcessExit += (_, _) =>
        {
            new DirectoryInfo(BiorandDirectory).Delete(recursive: true);
        };
        */
    }

    private static readonly RE7RandomizerExecutor executor = new(PAKPath, new EmptyReporter());
    private const int DefaultTestingSeed = 0x42424242;

    public static (ZipArchive, PakFile) Run(string configJson, int seed = DefaultTestingSeed)
    {
        var input = new RandomizerInput()
        {
            Seed = seed,
            Configuration = RandomizerConfiguration.FromJson(configJson)
        };

        var output = executor.Randomize(input);
        Assert.NotNull(output);

        var zipAsset = output.Assets.FirstOrDefault(asset => asset.Key == "1-patch")?.Data.Unzip();
        Assert.NotNull(zipAsset);

        return (
            zipAsset,
            new PakFile(
                zipAsset
                .Entries
                .Single(entry => entry.Name.EndsWith(".pak"))
                .GetBytes()
            )
        );
    }
}