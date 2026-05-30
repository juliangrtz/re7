using Biohazard.BioRand.RE7.Serialization;
using System.Reflection;

namespace Biohazard.BioRand.RE7;

internal class RandomizerFactory {
    public static RandomizerFactory Default { get; } = new();

    private static Assembly CurrentAssembly => Assembly.GetExecutingAssembly();
    private Version CurrentVersion { get; } = GetCurrentVersion();
    public string CurrentVersionNumber => $"{CurrentVersion.Major}.{CurrentVersion.Minor}.{CurrentVersion.Build}";

    public string CurrentVersionInfo =>
        $"BioRand for Resident Evil 7 v{CurrentVersion.Major}.{CurrentVersion.Minor}.{CurrentVersion.Build} ({GitHash})";

    public string GitHash { get; } = GetGitHash();

    private RandomizerFactory() { }

    private static Version GetCurrentVersion() {
        var version = CurrentAssembly.GetName().Version ?? new Version();
        if (version.Revision == -1)
            return version;
        return new Version(version.Major, version.Minor, version.Build);
    }

    private static string GetGitHash() {
        var attribute = CurrentAssembly
            .GetCustomAttributes<AssemblyInformationalVersionAttribute>()
            .FirstOrDefault();
        if (attribute == null)
            return string.Empty;

        var rev = attribute.InformationalVersion;
        var plusIndex = rev.IndexOf('+');
        if (plusIndex != -1) {
            return rev.Substring(plusIndex + 1);
        }

        return rev;
    }

    public static byte[] GetDefaultProfile() => EmbeddedData.GetFile("default-profile.json");
}