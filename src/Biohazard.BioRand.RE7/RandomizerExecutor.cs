using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Package;
using System.Globalization;
using System.Threading;

namespace Biohazard.BioRand.RE7;

public class RandomizerExecutor(string inputGamePath, IProgressReporter reporter)
{
    public static string BuildVersion => RandomizerFactory.Default.GitHash;
    public static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition ConfigurationDefinition => RandomizerConfigurationDefinition.Create();
    public static RandomizerConfiguration DefaultConfiguration => RandomizerConfigurationDefinition.Create().GetDefault();

    public IntelOrca.Biohazard.BioRand.RandomizerOutput Randomize(RandomizerInput input)
    {
        // We swap to invariant culture so , is decimal point
        var backupCulture = Thread.CurrentThread.CurrentCulture;
        var backupCultureUi = Thread.CurrentThread.CurrentUICulture;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        try
        {
            using var randomizer = new Randomizer(input, inputGamePath, reporter);
            return randomizer.Randomize();
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = backupCulture;
            Thread.CurrentThread.CurrentUICulture = backupCultureUi;
        }
    }

    public static PakList GetDefaultPakList(bool isForRaytracingVersion)
    {
        var pakListBytes = EmbeddedData.GetFile($"pakcontents{(isForRaytracingVersion ? "rt" : "")}.txt.gz").Ungzip();
        var pakListText = Encoding.UTF8.GetString(pakListBytes);
        return new PakList(pakListText);
    }
}