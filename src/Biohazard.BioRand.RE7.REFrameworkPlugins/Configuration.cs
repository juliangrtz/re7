using System.Text.Json;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

/// <summary>
/// Reads config.json in the reframework/data directory.
/// It's copied there in Biohazard.BioRand.RE7.RE7RandomizerOutput
/// </summary>
internal class Configuration
{
    private const string WorkingDirectory = @"reframework\data\BioRand7";
    private const string DataDirectory = @"data\BioRand7";
    private const string ConfigFileName = "config.json";
    private readonly object sync = new();
    private readonly Dictionary<string, JsonElement> jsonConfig = new();

    public string ConfigPath { get; private set; } = GetDefaultConfigPath();
    public bool HasConfigFile { get; private set; }
    public string? LoadError { get; private set; }

    public Configuration()
        => Reload();

    public void Reload()
    {
        lock (sync)
        {
            jsonConfig.Clear();
            HasConfigFile = false;
            LoadError = null;
            ConfigPath = ResolveConfigPath();

            if (!File.Exists(ConfigPath))
                return;

            try
            {
                var file = File.ReadAllText(ConfigPath);
                var values = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(file) ?? new();
                foreach (var (key, value) in values)
                {
                    jsonConfig[key] = value.Clone();
                }
                HasConfigFile = true;
            }
            catch (Exception ex)
            {
                LoadError = ex.Message;
            }
        }
    }

    public string Read(string key)
    {
        return ReadOrDefault(key, string.Empty);
    }

    public bool TryRead<T>(string key, out T value)
    {
        value = default!;

        JsonElement jsonValue;
        lock (sync)
        {
            if (!jsonConfig.TryGetValue(key, out jsonValue))
                return false;

            jsonValue = jsonValue.Clone();
        }

        try
        {
            var parsed = JsonSerializer.Deserialize<T>(jsonValue.GetRawText());
            if (parsed == null)
                return false;

            value = parsed;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public T ReadOrDefault<T>(string key, T defaultValue)
    {
        return TryRead(key, out T value) ? value : defaultValue;
    }

    public KeyValuePair<string, JsonElement>[] GetEntriesSnapshot()
    {
        lock (sync)
        {
            return jsonConfig
                .OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                .Select(x => new KeyValuePair<string, JsonElement>(x.Key, x.Value.Clone()))
                .ToArray();
        }
    }

    public int Entries
    {
        get
        {
            lock (sync)
            {
                return jsonConfig.Count;
            }
        }
    }

    public string[] GetConfigSearchPaths()
        => GetCandidateConfigPaths();

    private static string ResolveConfigPath()
    {
        var candidates = GetCandidateConfigPaths();
        return candidates.FirstOrDefault(File.Exists)
            ?? candidates.First();
    }

    private static string[] GetCandidateConfigPaths()
    {
        var result = new List<string>();
        AddCandidate(result, Path.Combine(Environment.CurrentDirectory, WorkingDirectory, ConfigFileName));
        AddCandidate(result, Path.Combine(AppContext.BaseDirectory, WorkingDirectory, ConfigFileName));
        AddCandidate(result, Path.Combine(AppContext.BaseDirectory, DataDirectory, ConfigFileName));
        AddCandidate(result, Path.Combine(AppContext.BaseDirectory, "..", DataDirectory, ConfigFileName));
        AddCandidate(result, Path.Combine(AppContext.BaseDirectory, "..", "..", DataDirectory, ConfigFileName));

        var processDirectory = GetProcessDirectory();
        if (processDirectory != null)
        {
            AddCandidate(result, Path.Combine(processDirectory, WorkingDirectory, ConfigFileName));
        }

        return result.Count == 0
            ? [GetDefaultConfigPath()]
            : result
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
    }

    private static void AddCandidate(List<string> result, string path)
    {
        try
        {
            result.Add(Path.GetFullPath(path));
        }
        catch
        {
        }
    }

    private static string? GetProcessDirectory()
    {
        try
        {
            var processPath = Environment.ProcessPath;
            return string.IsNullOrWhiteSpace(processPath)
                ? null
                : Path.GetDirectoryName(processPath);
        }
        catch
        {
            return null;
        }
    }

    private static string GetDefaultConfigPath()
        => Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, WorkingDirectory, ConfigFileName));
}
