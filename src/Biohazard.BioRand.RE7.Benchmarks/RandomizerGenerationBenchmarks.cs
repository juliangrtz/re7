using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using IntelOrca.Biohazard.BioRand;
using System.Reflection;

namespace Biohazard.BioRand.RE7.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class RandomizerGenerationBenchmarks {
    private const int Seed = 0x42424242;
    private RandomizerExecutor _executor = null!;
    private RandomizerInput _input = null!;

    [Params(
        RandomizerScenario.Minimal,
        RandomizerScenario.DefaultProfile,
        RandomizerScenario.ItemsAndKeyItems,
        RandomizerScenario.Enemies,
        RandomizerScenario.RealisticProfile)]
    public RandomizerScenario Scenario { get; set; }

    [GlobalSetup]
    public void GlobalSetup() {
        _executor = new RandomizerExecutor(BenchmarkPakPath.Resolve(), new NoOpReporter());
        _input = CreateInput();
    }

    [IterationSetup]
    public void IterationSetup() {
        _input = CreateInput();
    }

    [Benchmark(Description = "Generate patch and Fluffy outputs")]
    public long Generate() {
        var output = _executor.Randomize(_input);
        return output.Assets.Sum(asset => (long)asset.Data.Length);
    }

    private RandomizerInput CreateInput() {
        return new RandomizerInput{
            Seed = Seed,
            UserName = "benchmark",
            ProfileName = $"Benchmark: {Scenario}",
            ProfileAuthor = "BenchmarkDotNet",
            ProfileDescription = "BioRand RE7 randomizer throughput benchmark.",
            Configuration = CreateConfiguration(Scenario)
        };
    }

    private static RandomizerConfiguration CreateConfiguration(RandomizerScenario scenario) {
        var configuration = RandomizerExecutor.DefaultConfiguration;
        configuration["debug-download-data"] = false;

        switch (scenario) {
            case RandomizerScenario.Minimal:
                DisableHighLevelFeatures(configuration);
                break;
            case RandomizerScenario.ItemsAndKeyItems:
                DisableHighLevelFeatures(configuration);
                configuration["random-items"] = true;
                configuration["random-key-item-locations"] = true;
                configuration["additional-items"] = true;
                configuration["additional-wooden-crates"] = true;
                break;
            case RandomizerScenario.Enemies:
                DisableHighLevelFeatures(configuration);
                configuration["random-enemies"] = true;
                configuration["extra-enemy-amount"] = 0.25;
                configuration["random-enemy-drops"] = true;
                break;
            case RandomizerScenario.RealisticProfile:
                configuration = LoadEmbeddedConfiguration("realistic-profile.json");
                configuration["debug-download-data"] = ShouldDownloadDynamicData();
                break;
            case RandomizerScenario.DefaultProfile:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(scenario), scenario, null);
        }

        return configuration;
    }

    private static RandomizerConfiguration LoadEmbeddedConfiguration(string fileName) {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = assembly
            .GetManifestResourceNames()
            .Single(name => name.EndsWith($".{fileName}", StringComparison.Ordinal));

        using var stream = assembly.GetManifestResourceStream(resourceName)
                           ?? throw new FileNotFoundException($"Embedded profile '{fileName}' not found.");
        using var reader = new StreamReader(stream);
        return RandomizerConfiguration.FromJson(reader.ReadToEnd());
    }

    private static bool ShouldDownloadDynamicData() {
        var value = Environment.GetEnvironmentVariable("BIORAND_RE7_BENCHMARK_DOWNLOAD_DATA");
        return string.Equals(value, "1", StringComparison.OrdinalIgnoreCase)
               || string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
    }

    private static void DisableHighLevelFeatures(RandomizerConfiguration configuration) {
        configuration["randomized-messages"] = false;
        configuration["random-enemies"] = false;
        configuration["extra-enemy-amount"] = 0.0;
        configuration["enemy-multiplier"] = 1.0;
        configuration["random-enemy-drops"] = false;

        configuration["random-items"] = false;
        configuration["random-key-item-locations"] = false;
        configuration["madhouse-normal-saves"] = false;
        configuration["replace-madhouse-tapes"] = false;
        configuration["replace-weapons"] = false;
        configuration["random-bird-cage-magnum"] = false;
        configuration["random-bird-cage-drugs-coins"] = false;
        configuration["additional-items"] = false;
        configuration["additional-wooden-crates"] = false;

        configuration["random-starting-inventory-ethan"] = false;
        configuration["random-starting-inventory-mia"] = false;
        configuration["random-starting-inventory-vhs"] = false;

        configuration["recipes-add-new"] = false;

        configuration["weapon-mod-damage"] = false;
        configuration["weapon-mod-ammo-capacity"] = false;
        configuration["weapon-mod-reload-speed"] = false;
    }
}

public enum RandomizerScenario {
    Minimal,
    DefaultProfile,
    ItemsAndKeyItems,
    Enemies,
    RealisticProfile
}

internal sealed class NoOpReporter : IProgressReporter {
    public void RunTask(string text, Action cb) {
        cb();
    }
}