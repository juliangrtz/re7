namespace Biohazard.BioRand.RE7.DataGen;

internal class FileWriter {
    public static string WriteOutput(string path, object content)
        => WriteOutput("GeneratedFiles", path, content);

    public static string WriteOutput(string outputDirectory, string path, object content) {
        if (content is string v) {
            return WriteOutput(outputDirectory, path, v);
        } else if (content is byte[] b) {
            return WriteOutput(outputDirectory, path, b);
        } else throw new Exception("Unsupported content type");
    }

    public static string WriteOutput(string outputDirectory, string path, string content) {
        var finalPath = Path.Combine(outputDirectory, path);
        CreateParentDirectory(finalPath);
        File.WriteAllText(finalPath, content);
        return finalPath;
    }

    public static string WriteOutput(string outputDirectory, string path, byte[] content) {
        var finalPath = Path.Combine(outputDirectory, path);
        CreateParentDirectory(finalPath);
        File.WriteAllBytes(finalPath, content);
        return finalPath;
    }

    private static void CreateParentDirectory(string path) {
        var parentDirectory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(parentDirectory)) {
            Directory.CreateDirectory(parentDirectory);
        }
    }
}
