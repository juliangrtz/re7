namespace Biohazard.BioRand.RE7.DataGen;

internal class FileWriter
{
    static FileWriter()
    {
        if (!Directory.Exists("GeneratedFiles"))
        {
            Directory.CreateDirectory("GeneratedFiles");
        }
    }

    private const string OutputDirectory = "GeneratedFiles";

    public static string WriteOutput(string path, string content)
    {
        var finalPath = $"{OutputDirectory}\\{path}";
        File.WriteAllText(finalPath, content);
        return finalPath;
    }

    public static string WriteOutput(string path, byte[] content)
    {
        var finalPath = $"{OutputDirectory}\\{path}";
        File.WriteAllBytes(finalPath, content);
        return finalPath;
    }
}