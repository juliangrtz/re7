using Biohazard.BioRand.RE7.DataGen.Commands;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class ConfigGenerator : IFileGenerator
{
    public string Id => "config";
    public string FileName => "default-profile";

    public object Generate(GenerateCommand.GenerateSettings settings)
    {
        var definition = RandomizerExecutor.ConfigurationDefinition;
        var result = new Dictionary<string, object>();
        foreach (var item in definition.AllItems)
        {
            result.Add(item.Id!, item.Default!);
        }
        return result;
    }
}