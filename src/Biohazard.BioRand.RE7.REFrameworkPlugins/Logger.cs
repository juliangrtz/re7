using REFrameworkNET;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

internal static class Logger
{
    public static void Log(string message)
        => API.LogInfo($"[BIORAND 7] {message}");
}