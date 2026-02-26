using System.Reflection;

namespace Biohazard.BioRand.RE7.Serialization;

public static class EmbeddedData
{
    private static readonly Assembly assembly = Assembly.GetExecutingAssembly();
    public const string DataDirectoryName = "_Data";

    public static Stream? GetStream(string name)
    {
        var exeDirectory = AppContext.BaseDirectory;
        var dataDirectory = Path.Combine(exeDirectory, DataDirectoryName);
        var dataPath = Path.Combine(dataDirectory, name);
        if (File.Exists(dataPath))
            return new MemoryStream(File.ReadAllBytes(dataPath));

        var resourceName = $"Biohazard.BioRand.RE7.{DataDirectoryName}.{name}";
        return assembly.GetManifestResourceStream(resourceName);
    }

    public static byte[] GetFile(string name)
    {
        return TryGetFile(name) ?? throw new FileNotFoundException($"{name} not found");
    }

    public static byte[]? TryGetFile(string name)
    {
        using var stream = GetStream(name);
        if (stream == null)
            return null;

        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        return ms.ToArray();
    }

    public static byte[]? GetCompressedFile(string name)
    {
        using var stream = GetStream(name);
        if (stream == null)
            return null;

        using var gzipStream = new GZipStream(stream, CompressionMode.Decompress);
        using var ms = new MemoryStream();
        gzipStream.CopyTo(ms);
        return ms.ToArray();
    }
}