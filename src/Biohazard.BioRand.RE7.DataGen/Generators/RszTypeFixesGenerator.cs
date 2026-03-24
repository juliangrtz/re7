using Biohazard.BioRand.RE7.DataGen.Commands;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class RszTypeFixesGenerator : IFileGenerator
{
    public string Id => "rsz-fix";
    public bool CopyToDataDirectory => true;

    public object Generate(GenerateCommand.GenerateSettings settings)
    {
        throw new NotImplementedException();
    }
}
