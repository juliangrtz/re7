using System.Reflection;

namespace Biohazard.BioRand.RE7.DataGen;

internal class EmbeddedResource
{
    public static byte[] Get(string filename)
    {
        var prefix = "Biohazard.BioRand.RE7.DataGen._Data";
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{prefix}.{filename}")!;
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}