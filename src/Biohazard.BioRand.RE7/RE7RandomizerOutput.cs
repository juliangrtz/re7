using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Package;

namespace Biohazard.BioRand.RE7;

public sealed class RE7RandomizerOutput
{
    private byte[]? _zipFile;
    private byte[]? _modFile;

    public RandomizerInput Input { get; }
    public PakFileBuilder PakFile { get; }
    public Dictionary<string, string> LogFiles { get; }
    public int PakVersion { get; }
    public bool IsWithREFramework { get; }

    private const string REFrameworkPluginName = "Biohazard.BioRand.RE7.REFrameworkPlugins.dll";

    internal RE7RandomizerOutput(RandomizerInput input, PakFileBuilder pakFile, Dictionary<string, string> logFiles, int pakVersion, bool isWithREFramework)
    {
        Input = input;
        PakFile = pakFile;
        LogFiles = logFiles;
        PakVersion = pakVersion;
        IsWithREFramework = isWithREFramework;
    }

    public byte[] GetOutputZip()
    {
        if (_zipFile != null)
            return _zipFile;

        _zipFile = BuildZipFile()
            .AddEntry($"re_chunk_000.pak.patch_{PakVersion:000}.pak", PakFile.ToByteArray())
            .Build();
        return _zipFile;
    }

    public byte[] GetOutputMod()
    {
        if (_modFile != null)
            return _modFile;

        var zipFile = BuildZipFile();
        foreach (var entry in PakFile.Entries)
        {
            zipFile.AddEntry(entry.Key, (byte[])entry.Value);
        }
        _modFile = zipFile
            .AddEntry("pic.jpg", EmbeddedData.GetFile("modimage.jpg"))
            .AddEntry("modinfo.ini", GetModInfo())
            .Build();
        return _modFile;
    }

    private OutputZipFileBuilder BuildZipFile(string logPrefix = "")
    {
        var builder = new OutputZipFileBuilder();
        var configBytes = Encoding.UTF8.GetBytes(Input.Configuration.ToJson());
        builder.AddEntry($"{logPrefix}config.json", configBytes);

        foreach (var logFile in LogFiles)
        {
            builder.AddEntry($"{logPrefix}{logFile.Key}", Encoding.UTF8.GetBytes(logFile.Value));
        }

        if (IsWithREFramework)
        {
            var pluginPath = Path.Combine(
                AppContext.BaseDirectory,
                REFrameworkPluginName
            );

            builder.AddEntry(
                $@"reframework\plugins\managed\{REFrameworkPluginName}",
                File.ReadAllBytes(pluginPath));

            builder.AddEntry(@"reframework\data\BioRand7\config.json", configBytes);
        }

        return builder;
    }

    private byte[] GetModInfo()
    {
        var rf = RE7RandomizerFactory.Default;

        var name = $"BioRand - {Sanitize(Input.ProfileName)} [{Input.Seed}]";
        var description = SanitizeParagraph(
            $"{Sanitize(Input.ProfileName)} by {Sanitize(Input.ProfileAuthor)} [{Input.Seed}]\n" +
            Input.ProfileDescription);
        var author = "BioRand 7 by IntelOrca, Descole & BioRand Team";
        var version = $"{rf.CurrentVersionNumber} ({rf.GitHash})";

        var lines = new List<string> {
            $"name={name}",
            $"version={version}",
            $"description={description}",
            "screenshot=pic.jpg",
            $"author={author}",
            "category=!Other > Misc"
        };

        if (IsWithREFramework)
        {
            lines.Add("requirement=RE Framework");
        }

        lines.Add("");

        var content = string.Join('\n', lines);
        return Encoding.UTF8.GetBytes(content);
    }

    private static string SanitizeParagraph(string? s)
    {
        return (s ?? "").Trim().ReplaceLineEndings("\\n");
    }

    private static string Sanitize(string? s)
    {
        return (s ?? "").Trim().ReplaceLineEndings(" ");
    }
}