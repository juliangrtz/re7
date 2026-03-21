using System.Collections.Immutable;
using System.Net.Http;
using System.Threading;

namespace Biohazard.BioRand.RE7.Serialization;

public sealed class DynamicData(bool download)
{
    private const string GoogleSheetUrl = "https://docs.google.com/spreadsheets/d/1YNdX9LWrhh6KDKd8Mx7JpTCMq8XY8u6BfX20YYNx9jk/export?format=csv&gid={0}";

    private static readonly ImmutableDictionary<DynamicDataName, (string, int)> g_map = new Dictionary<DynamicDataName, (string, int)>
    {
        [DynamicDataName.ItemPlacements] = ("items.csv", 1561602125),
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

public enum DynamicDataName
{
    ItemPlacements,
}