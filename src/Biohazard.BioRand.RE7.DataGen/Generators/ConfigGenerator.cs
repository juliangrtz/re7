using Biohazard.BioRand.RE7.DataGen.Commands;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class ConfigGenerator : IFileGenerator
{
    public string Id => "config";
    public string FileName => "default-profile";

    public object Generate(GenerateCommand.GenerateSettings settings)
        => RE7RandomizerExecutor.DefaultConfiguration;
}