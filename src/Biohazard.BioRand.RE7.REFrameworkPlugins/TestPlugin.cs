namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

using REFrameworkNET;
using REFrameworkNET.Attributes;

public class REFrameworkPlugin
{
    [PluginEntryPoint]
    public static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            API.LogInfo("Hello from BioRand 7!");
        }
    }
}