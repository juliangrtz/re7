using Biohazard.BioRand.RE7.DataGen;

namespace Biohazard.BioRand.RE7.Tests;

public class DataGenFileWriterTests {
    [Fact]
    public void WriteOutput_String_CreatesNestedParentDirectories() {
        var root = CreateTemporaryPath();
        var relativePath = Path.Combine("nested", "deeper", "output.txt");
        try {
            var outputPath = FileWriter.WriteOutput(root, relativePath, "content");

            Assert.Equal("content", File.ReadAllText(outputPath));
        }
        finally {
            DeleteDirectoryIfPresent(root);
        }
    }

    [Fact]
    public void WriteOutput_Bytes_CreatesNestedParentDirectories() {
        var root = CreateTemporaryPath();
        var relativePath = Path.Combine("nested", "deeper", "output.bin");
        var content = new byte[]{ 1, 2, 3, 4 };
        try {
            var outputPath = FileWriter.WriteOutput(root, relativePath, content);

            Assert.Equal(content, File.ReadAllBytes(outputPath));
        }
        finally {
            DeleteDirectoryIfPresent(root);
        }
    }

    private static string CreateTemporaryPath()
        => Path.Combine(Path.GetTempPath(), $"biorand-re7-tests-{Guid.NewGuid():N}");

    private static void DeleteDirectoryIfPresent(string path) {
        if (Directory.Exists(path)) {
            Directory.Delete(path, recursive: true);
        }
    }
}
