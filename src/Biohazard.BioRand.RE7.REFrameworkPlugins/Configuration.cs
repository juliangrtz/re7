using System.Text.Json;
using static Biohazard.BioRand.RE7.REFrameworkPlugins.Logger;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

/// <summary>
/// Reads config.json in the reframework/data directory.
/// It's copied there in Biohazard.BioRand.RE7.RE7RandomizerOutput
/// </summary>
internal class Configuration
{
    private const string workingDirectory = @"reframework\data\BioRand7";
    private readonly Dictionary<string, JsonElement> jsonConfig = new();

    public Configuration()
    {
        var file = File.ReadAllText($@"{workingDirectory}\config.json");
        jsonConfig = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(file)
            ?? throw new JsonException("Bad configuration!");
    }

    public string Read(string key)
    {
        return jsonConfig[key].ToString();
    }

    public int Entries => jsonConfig.Count;
}