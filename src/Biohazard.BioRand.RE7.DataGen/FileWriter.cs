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
        Directory.CreateDirectory(outputDirectory);
        var finalPath = Path.Combine(outputDirectory, path);
        File.WriteAllText(finalPath, content);
        return finalPath;
    }

    public static string WriteOutput(string outputDirectory, string path, byte[] content) {
        Directory.CreateDirectory(outputDirectory);
        var finalPath = Path.Combine(outputDirectory, path);
        File.WriteAllBytes(finalPath, content);
        return finalPath;
    }
}