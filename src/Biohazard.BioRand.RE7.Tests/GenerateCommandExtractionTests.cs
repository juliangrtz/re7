using Biohazard.BioRand.RE7.Commands;
using System.IO.Compression;

namespace Biohazard.BioRand.RE7.Tests;

public class GenerateCommandExtractionTests {
    [Fact]
    public void EnsureParentDirectory_AllowsCurrentDirectoryOutputPath() {
        GenerateCommand.EnsureParentDirectory("biorand-re7-test-output.pak");
    }

    [Fact]
    public void EnsureParentDirectory_CreatesNestedOutputDirectory() {
        var outputRoot = CreateTemporaryDirectory();
        var outputPath = Path.Combine(outputRoot, "nested", "seed.pak");
        var outputDirectory = Path.GetDirectoryName(outputPath)!;

        try {
            GenerateCommand.EnsureParentDirectory(outputPath);

            Assert.True(Directory.Exists(outputDirectory));
        }
        finally {
            Directory.Delete(outputRoot, recursive: true);
        }
    }

    [Theory]
    [InlineData("seed.pak", ".pak")]
    [InlineData("seed.PAK", ".pak")]
    [InlineData("seed.ZiP", ".zip")]
    public void HasExtension_IsCaseInsensitive(string path, string extension) {
        Assert.True(GenerateCommand.HasExtension(path, extension));
    }

    [Fact]
    public void GetPakFile_ReadsCaseInsensitivePakEntry() {
        var expected = new byte[]{ 1, 2, 3, 4 };
        byte[] archiveBytes;
        using (var stream = new MemoryStream()) {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true)) {
                var entry = archive.CreateEntry("nested/seed.PAK");
                using var entryStream = entry.Open();
                entryStream.Write(expected);
            }
            archiveBytes = stream.ToArray();
        }

        Assert.Equal(expected, GenerateCommand.GetPakFile(archiveBytes));
    }

    [Fact]
    public void ExtractEntryToDirectory_ExtractsNestedEntry() {
        using var zip = CreateZip(("natives/stm/test.txt", "ok"));
        var outputPath = CreateTemporaryDirectory();

        try {
            GenerateCommand.ExtractEntryToDirectory(zip.Entries.Single(), outputPath);

            Assert.Equal(
                "ok",
                File.ReadAllText(Path.Combine(outputPath, "natives", "stm", "test.txt")));
        }
        finally {
            Directory.Delete(outputPath, recursive: true);
        }
    }

    [Theory]
    [InlineData("natives/../outside.txt")]
    [InlineData("natives/stm/../../outside.txt")]
    public void ExtractEntryToDirectory_RejectsTraversalEntry(string entryName) {
        using var zip = CreateZip((entryName, "bad"));
        var outputPath = CreateTemporaryDirectory();

        try {
            Assert.Throws<InvalidDataException>(() =>
                GenerateCommand.ExtractEntryToDirectory(zip.Entries.Single(), outputPath));

            Assert.False(File.Exists(Path.Combine(Path.GetDirectoryName(outputPath)!, "outside.txt")));
        }
        finally {
            Directory.Delete(outputPath, recursive: true);
        }
    }

    private static ZipArchive CreateZip(params (string Name, string Content)[] entries) {
        var stream = new MemoryStream();
        using (var zip = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true)) {
            foreach (var (name, content) in entries) {
                var entry = zip.CreateEntry(name);
                using var writer = new StreamWriter(entry.Open());
                writer.Write(content);
            }
        }

        stream.Position = 0;
        return new ZipArchive(stream, ZipArchiveMode.Read);
    }

    private static string CreateTemporaryDirectory() {
        var path = Path.Combine(Path.GetTempPath(), $"biorand-re7-tests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(path);
        return path;
    }
}
