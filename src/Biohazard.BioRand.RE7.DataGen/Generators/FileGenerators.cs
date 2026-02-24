using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal interface IFileGenerator
{
    string Id { get; }

    object Generate(GenerateSettings settings);
}

internal enum OutputFormat
{
    Csv,
    Json
}