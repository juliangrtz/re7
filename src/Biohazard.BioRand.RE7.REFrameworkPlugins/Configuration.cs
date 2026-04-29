using System.Text.Json;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

/// <summary>
/// Reads config.json in the reframework/data directory.
/// It's copied there in Biohazard.BioRand.RE7.RE7RandomizerOutput
/// </summary>
internal class Configuration
{
    private const string WorkingDirectory = @"reframework\data\BioRand7";
    private readonly Dictionary<string, JsonElement> jsonConfig = new();

    public string ConfigPath { get; } = Path.GetFullPath(Path.Combine(WorkingDirectory, "config.json"));
    public bool HasConfigFile { get; }
    public string? LoadError { get; }

    public Configuration()
    {
        if (!File.Exists(ConfigPath))
            return;

        try
        {
            var file = File.ReadAllText(ConfigPath);
            jsonConfig = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(file) ?? new();
            HasConfigFile = true;
        }
        catch (Exception ex)
        {
            LoadError = ex.Message;
        }
    }

    public string Read(string key)
    {
        return ReadOrDefault(key, string.Empty);
    }

    public bool TryRead<T>(string key, out T value)
    {
        value = default!;

        if (!jsonConfig.TryGetValue(key, out var jsonValue))
            return false;

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

    public int Entries => jsonConfig.Count;
}
