using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen;

internal interface IFileGenerator
{
    string Id { get; }

    string? FileName => null; // <Id>.<Extension> if null

    object Generate(GenerateSettings settings);

    bool CopyToDataDirectory => false;
}

internal enum OutputFormat
{
    Csv,
    Json,
    Binary
}