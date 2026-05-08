using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7.Benchmarks;

internal static class BenchmarkPakPath
{
    private const string BenchmarkPakPathEnvVariable = "BIORAND_RE7_BENCHMARK_PAK";
    private const string TestPakPathEnvVariable = "BIORAND_RE7_TEST_PAK";
    private const string PakName = "biorand-re7.pak";

    private static readonly string BiorandDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        ".biorand"
    );

    private static readonly string LocalPakPath = Path.Combine(
        BiorandDirectory,
        PakName
    );

    public static string Resolve()
    {
        var configuredPath = ResolveConfiguredPath(BenchmarkPakPathEnvVariable)
            ?? ResolveConfiguredPath(TestPakPathEnvVariable);
        if (configuredPath is not null)
            return configuredPath;

        if (File.Exists(LocalPakPath))
            return LocalPakPath;

        var embeddedPak = EmbeddedData.TryGetFile(PakName);
        if (embeddedPak is not null)
        {
            Directory.CreateDirectory(BiorandDirectory);
            File.WriteAllBytes(LocalPakPath, embeddedPak);
            return LocalPakPath;
        }

        throw new FileNotFoundException(
            $"Baseline {PakName} not found. Put it at {LocalPakPath} or set {BenchmarkPakPathEnvVariable}.");
    }

    private static string? ResolveConfiguredPath(string variable)
    {
        var configuredPath = Environment.GetEnvironmentVariable(variable);
        if (string.IsNullOrWhiteSpace(configuredPath))
            return null;

        if (!File.Exists(configuredPath))
            throw new FileNotFoundException("Configured baseline PAK not found.", configuredPath);

        return configuredPath;
    }
}
