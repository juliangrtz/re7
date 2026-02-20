using Biohazard.BioRand.RE7.Extensions;
using BioHazard.BioRand.RE7;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Package;

namespace Biohazard.BioRand.RE7.Tests
{
    public abstract class RandomizerTest : IDisposable
    {
        private static readonly string PAKPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".biorand",
            "biorand-re7.pak"
        );
        private readonly RE7RandomizerExecutor executor = new(PAKPath, new EmptyReporter());
        private const int DefaultTestingSeed = 0x42424242;

        public RandomizerConfiguration Configuration { get; private set; }

        public PakFile RunRandomizer(string configJson, int seed = DefaultTestingSeed)
        {
            var input = new RandomizerInput()
            {
                Seed = seed,
                Configuration = RandomizerConfiguration.FromJson(configJson)
            };

            var output = executor.Randomize(input);
            Assert.NotNull(output);

            var zipAsset = output.Assets.FirstOrDefault(asset => asset.Key == "1-patch");
            Assert.NotNull(zipAsset);

            return new PakFile(zipAsset
                .Data
                .Unzip()
                .Entries
                .Single(entry => entry.Name.EndsWith(".pak"))
                .GetBytes()
            );
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
