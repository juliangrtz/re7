using Biohazard.BioRand.RE7.Commands;

namespace Biohazard.BioRand.RE7.Tests;

public class UpdateCommandTests {
    [Fact]
    public void FindSourceDirectory_FindsSourceBelowRepositoryRoot() {
        var root = CreateTemporaryRepository();
        try {
            var sourceDirectory = UpdateCommand.FindSourceDirectory(root);

            Assert.Equal(Path.Combine(root, "src"), sourceDirectory);
        }
        finally {
            Directory.Delete(root, recursive: true);
        }
    }

    [Fact]
    public void FindSourceDirectory_FindsSourceFromNestedProjectDirectory() {
        var root = CreateTemporaryRepository();
        var nestedDirectory = Path.Combine(root, "src", "biorand-re7", "bin", "Debug");
        Directory.CreateDirectory(nestedDirectory);
        try {
            var sourceDirectory = UpdateCommand.FindSourceDirectory(nestedDirectory);

            Assert.Equal(Path.Combine(root, "src"), sourceDirectory);
        }
        finally {
            Directory.Delete(root, recursive: true);
        }
    }

    private static string CreateTemporaryRepository() {
        var root = Path.Combine(Path.GetTempPath(), $"biorand-re7-tests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(Path.Combine(root, "src", "Biohazard.BioRand.RE7", "_Data"));
        return root;
    }
}
