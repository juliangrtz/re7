using Biohazard.BioRand.RE7.Serialization;
using System.Reflection;

internal static class REFrameworkScriptService
{
    private static readonly Assembly assembly = Assembly.GetExecutingAssembly();

    private const string BaseDir = "REF_Scripts";
    private const string StaticDir = "REF_Scripts.Static";
    private const string TemplateDir = "REF_Scripts.Templates";

    private static readonly Dictionary<string, byte[]> StaticScripts = LoadStaticScripts();
    private static readonly Dictionary<string, byte[]> TemplateScripts = LoadTemplateScripts();

    private static readonly Dictionary<string, string> ParametrizedScripts = new();

    public static List<string> Exclusions { get; private set; } = new();

    private static Dictionary<string, byte[]> LoadStaticScripts()
    {
        return assembly
            .GetManifestResourceNames()
            .Where(res => res.Contains(StaticDir) && res.EndsWith(".lua"))
            .ToDictionary(
                res => $"reframework/autorun/{GetFileName(res)}",
                res => EmbeddedData.TryGetFile(GetEmbeddedPath(res))!
            );
    }

    private static Dictionary<string, byte[]> LoadTemplateScripts()
    {
        return assembly
            .GetManifestResourceNames()
            .Where(res => res.Contains(TemplateDir) && res.EndsWith(".lua"))
            .ToDictionary(
                res => GetFileName(res),
                res => EmbeddedData.TryGetFile(GetEmbeddedPath(res))!
            );
    }

    private static string GetFileName(string resourceName)
        => resourceName.Split('.').Reverse().Skip(1).First() + ".lua";

    private static string GetEmbeddedPath(string resourceName)
    {
        var idx = resourceName.IndexOf(BaseDir);
        return resourceName.Substring(idx);
    }

    public static void RegisterParametrizedScript(
        string templateFileName,
        Dictionary<string, string> variables)
    {
        if (!TemplateScripts.TryGetValue(templateFileName, out var originalBytes))
            throw new ArgumentException($"Template '{templateFileName}' not found.");

        var script = Encoding.UTF8.GetString(originalBytes);

        foreach (var (variable, value) in variables)
        {
            script = script.Replace(variable, value);
        }

        ParametrizedScripts[templateFileName] = script;
    }

    public static List<(string path, byte[] content)> GetREFrameworkScripts()
    {
        var result = new List<(string, byte[])>();

        foreach (var (path, content) in StaticScripts.Where(s => !Exclusions.Contains(s.Key)))
            result.Add((path, content));

        foreach (var (fileName, script) in ParametrizedScripts.Where(s => !Exclusions.Contains(s.Key)))
            result.Add(($"reframework/autorun/{fileName}", Encoding.UTF8.GetBytes(script)));

        return result;
    }
}