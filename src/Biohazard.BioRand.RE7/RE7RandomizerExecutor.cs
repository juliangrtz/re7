using Biohazard.BioRand.RE7.Extensions;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Package;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Biohazard.BioRand.RE7 {
    public class RE7RandomizerExecutor(string inputGamePath, IProgressReporter reporter) {
        public static string BuildVersion => RE7RandomizerFactory.Default.GitHash;
        public static RandomizerConfigurationDefinition ConfigurationDefinition => RE7RandomizerConfigurationDefinition.Create();
        public static RandomizerConfiguration DefaultConfiguration => RE7RandomizerConfigurationDefinition.Create().GetDefault();

        public RandomizerOutput Randomize(RandomizerInput input) {
            // We swap to invariant culture so , is decimal point
            var backupCulture = Thread.CurrentThread.CurrentCulture;
            var backupCultureUi = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            try {
                using var randomizer = new RE7Randomizer(input, inputGamePath, reporter);
                return randomizer.Randomize();
            } finally {
                Thread.CurrentThread.CurrentCulture = backupCulture;
                Thread.CurrentThread.CurrentUICulture = backupCultureUi;
            }
        }

        public static PakList GetDefaultPakList() {
            var pakListBytes = EmbeddedData.GetFile("pakcontentsrt.txt.gz").Ungzip();
            var pakListText = Encoding.UTF8.GetString(pakListBytes);
            return new PakList(pakListText);
        }
    }
}
