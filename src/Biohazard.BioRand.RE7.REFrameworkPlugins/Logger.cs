using REFrameworkNET;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

internal class Logger(Configuration config)
{
    public bool LogVerbose { get; set; } = bool.TryParse(config.ReadOrDefault("verbose-reframework-plugin-logging", "false"), out var verbose)
        && verbose;

    public void Log(string message, bool isVerbose = false)
    {
        if (isVerbose && !LogVerbose)
            return;

        API.LogInfo($"[BIORAND 7] {message}");
    }
}
