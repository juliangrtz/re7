using REFrameworkNET;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

internal class Logger(Configuration config)
{
    public bool LogVerbose { get; set; } = bool.Parse(config.Read("verbose-reframework-plugin-logging"));

    public void Log(string message, bool isVerbose = false)
    {
        if (isVerbose && !LogVerbose)
            return;

        API.LogInfo($"[BIORAND 7] {message}");
    }
}