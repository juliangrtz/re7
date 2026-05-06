using System.Collections.Immutable;
using System.Net.Http;
using System.Threading;

namespace Biohazard.BioRand.RE7.Serialization;

public enum DynamicDataName
{
    ItemPlacements,
    Recipes,
    Enemies,
    ExtraEnemies,
    EnemyLimits,
    Messages,
    BirdCages,
    KeyItems,
    DebugStartItems,
    BirthdaySkills,
}

public sealed class DynamicData(bool download)
{
    private const string GoogleSheetUrl = "https://docs.google.com/spreadsheets/d/1YNdX9LWrhh6KDKd8Mx7JpTCMq8XY8u6BfX20YYNx9jk/export?format=csv&gid={0}";

    private static readonly ImmutableDictionary<DynamicDataName, (string FileName, int? GoogleSheetId)> g_map = new Dictionary<DynamicDataName, (string, int?)>
    {
        [DynamicDataName.ItemPlacements] = ("item_placements.csv", 1561602125),
        [DynamicDataName.Recipes] = ("recipes.csv", 358865420),
        [DynamicDataName.Enemies] = ("enemies.csv", 2063646676),
        [DynamicDataName.ExtraEnemies] = ("extra_enemies.csv", 2063983386),
        [DynamicDataName.EnemyLimits] = ("enemy_limits.csv", 1254028764),
        [DynamicDataName.Messages] = ("messages.csv", 1050646915),
        [DynamicDataName.BirdCages] = ("bird_cages.csv", 1920824337),
        [DynamicDataName.KeyItems] = ("key_items.csv", 91603961),
        [DynamicDataName.DebugStartItems] = ("debug_start_items.csv", 639198893),
        [DynamicDataName.BirthdaySkills] = ("birthday_skills.csv", 1933511558),
    }.ToImmutableDictionary();

    private readonly Dictionary<DynamicDataName, byte[]> _map = [];
    private readonly Lock _sync = new();

    public static string? GetFileName(DynamicDataName name)
    {
        if (g_map.TryGetValue(name, out var entry))
        {
            return entry.FileName;
        }
        return null;
    }

    public byte[]? GetData(DynamicDataName name)
    {
        lock (_sync)
        {
            if (!_map.TryGetValue(name, out var data))
            {
                var (fileName, gid) = g_map[name];
                if (download && gid.HasValue)
                {
                    var downloadUrl = string.Format(GoogleSheetUrl, gid.Value);
                    data = Download(downloadUrl);
                }
                else
                {
                    data = EmbeddedData.GetFile(fileName);
                }
                _map[name] = data;
            }
            return data;
        }
    }

    internal void SetData(DynamicDataName name, byte[] data)
    {
        lock (_sync)
        {
            _map[name] = data;
        }
    }

    private static byte[] Download(string url)
    {
        using var httpClient = new HttpClient();
        return httpClient.GetByteArrayAsync(url).Result;
    }
}
