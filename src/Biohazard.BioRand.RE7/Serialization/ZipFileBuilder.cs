namespace Biohazard.BioRand.RE7.Serialization;

internal class OutputZipFileBuilder()
{
    private readonly Dictionary<string, byte[]> _entries = new();

    public OutputZipFileBuilder AddEntry(string path, byte[] data)
    {
        _entries.Add(path, data);
        return this;
    }

    public byte[] Build()
    {
        using var memory = new MemoryStream();
        using (var archive = new ZipArchive(memory, ZipArchiveMode.Create, leaveOpen: true))
        {
            foreach (var entry in _entries)
            {
                var zipEntry = archive.CreateEntry(entry.Key, CompressionLevel.Fastest);
                using var entryStream = zipEntry.Open();
                entryStream.Write(entry.Value);
            }
        }

        return memory.ToArray();
    }
}
