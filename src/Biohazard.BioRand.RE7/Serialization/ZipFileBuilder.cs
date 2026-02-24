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
        var tempDir = Directory.CreateTempSubdirectory()!;
        try
        {
            foreach (var entry in _entries)
            {
                var fullPath = Path.Combine(tempDir.FullName, entry.Key);
                var dir = Path.GetDirectoryName(fullPath)!;
                Directory.CreateDirectory(dir);
                File.WriteAllBytes(fullPath, entry.Value);
            }

            var ms = new MemoryStream();
            ZipFile.CreateFromDirectory(tempDir.FullName, ms);
            return ms.ToArray();
        }
        finally
        {
            tempDir.Delete(recursive: true);
        }
    }
}