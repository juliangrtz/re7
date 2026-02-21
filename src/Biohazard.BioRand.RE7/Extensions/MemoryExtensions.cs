namespace Biohazard.BioRand.RE7.Extensions;

public static class MemoryExtensions
{
    public static void WriteToFile(this string data, string path)
    {
        File.WriteAllText(path, data);
    }

    public static void WriteToFile(this byte[] data, string path)
        => data.AsSpan().WriteToFile(path);

    public static void WriteToFile(this Span<byte> data, string path)
    {
        File.WriteAllBytes(path, data);
    }

    public static void WriteToFile(this ReadOnlyMemory<byte> data, string path)
        => data.Span.WriteToFile(path);

    public static void WriteToFile(this ReadOnlySpan<byte> data, string path)
    {
        File.WriteAllBytes(path, data);
    }

    public static byte[] Ungzip(this byte[] input)
    {
        using var inputStream = new MemoryStream(input);
        using var outputStream = new MemoryStream();
        using var deflateStream = new GZipStream(inputStream, CompressionMode.Decompress);
        deflateStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }

    public static ZipArchive Unzip(this byte[] input)
    {
        var inputStream = new MemoryStream(input);
        return new ZipArchive(inputStream, ZipArchiveMode.Read, leaveOpen: false);
    }

    public static byte[] GetBytes(this ZipArchiveEntry entry)
    {
        using var stream = entry.Open();
        using var memory = new MemoryStream();
        stream.CopyTo(memory);
        return memory.ToArray();
    }
}