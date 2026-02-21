namespace Biohazard.BioRand.RE7.DataGen
{
    internal interface IFileGenerator
    {
        string Id { get; }
    }

    internal enum TextOutputFormat
    {
        Csv,
        Json
    }

    internal interface ITextFileGenerator : IFileGenerator
    {
        string Generate(TextOutputFormat OutputFormat);
    }

    internal interface IBinaryFileGenerator : IFileGenerator
    {
        byte[] Generate();
    }
}
