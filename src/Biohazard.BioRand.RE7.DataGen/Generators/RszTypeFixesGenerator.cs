using Biohazard.BioRand.RE7.DataGen.Commands;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

/// <summary>
/// TODO: Analyze RSZ dump and compare it to IL2CPP dump to detect errors.
/// </summary>
internal class RszTypeFixesGenerator : IFileGenerator
{
    public string Id => "rsz-fix";
    public bool CopyToDataDirectory => true;

    public object Generate(GenerateCommand.GenerateSettings settings)
    {
        throw new NotImplementedException();
    }
}
