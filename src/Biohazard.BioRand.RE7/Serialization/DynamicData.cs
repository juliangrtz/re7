using System.Collections.Immutable;
using System.Net.Http;
using System.Threading;

namespace Biohazard.BioRand.RE7.Serialization;

public enum DynamicDataName
{
    ItemPlacements,
    Recipes,
    Enemies,
    EnemyLimits,
    Events,
    Messages,
    BirdCages,
    KeyItems
}

public sealed class DynamicData(bool download)
{
    private const string GoogleSheetUrl = "https://docs.google.com/spreadsheets/d/1YNdX9LWrhh6KDKd8Mx7JpTCMq8XY8u6BfX20YYNx9jk/export?format=csv&gid={0}";

    private static readonly ImmutableDictionary<DynamicDataName, (string, int)> g_map = new Dictionary<DynamicDataName, (string, int)>
    {
        [DynamicDataName.ItemPlacements] = ("item_placements.csv", 1561602125),
        [DynamicDataName.Recipes] = ("recipes.csv", 358865420),
        [DynamicDataName.Enemies] = ("enemies.csv", 2063646676),
        [DynamicDataName.EnemyLimits] = ("enemy_limits.csv", 1254028764),
        [DynamicDataName.Events] = ("events.csv", 1728585114),
        [DynamicDataName.Messages] = ("messages.csv", 1050646915),
        [DynamicDataName.BirdCages] = ("bird_cages.csv", 1920824337),
        [DynamicDataName.KeyItems] = ("key_items.csv", 91603961),
    }.ToImmutableDictionary();

    private readonly Dictionary<DynamicDataName, byte[]> _map = [];
    private readonly Lock _sync = new();

    public static string? GetFileName(DynamicDataName name)
    {
        if (g_map.TryGetValue(name, out var entry))
        {
            var (fileName, _) = entry;
            return fileName;
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
                if (download)
                {
                    var downloadUrl = string.Format(GoogleSheetUrl, gid);
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

    private static byte[] Download(string url)
    {
        using var httpClient = new HttpClient();
        return httpClient.GetByteArrayAsync(url).Result;
    }
}
