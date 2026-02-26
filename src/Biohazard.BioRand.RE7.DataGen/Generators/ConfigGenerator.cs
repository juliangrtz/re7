using Biohazard.BioRand.RE7.DataGen.Commands;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class ConfigGenerator : IFileGenerator
{
    public string Id => "config";
    public string FileName => "default-profile";

    // Currently this just copies the default-profile.json file.
    // TODO: Make it generate a config with default values from the definition
    public object Generate(GenerateCommand.GenerateSettings settings)
        => RE7RandomizerExecutor.DefaultConfiguration;
}