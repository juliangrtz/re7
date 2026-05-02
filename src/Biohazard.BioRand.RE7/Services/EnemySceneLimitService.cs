using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Serialization;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Services;

internal sealed class EnemySceneLimitService(Randomizer randomizer)
{
    private readonly Lazy<LimitMaps> _limitMaps = new(() => LoadLimitMaps(randomizer));
    private readonly Lazy<ImmutableDictionary<Guid, VanillaSpawnInfo>> _spawnInfos = new(() => LoadSpawnInfos(randomizer));

    public bool HasSceneLimits => _limitMaps.Value.DirectSceneLimits.Count != 0;

    public int? GetMaxEnemiesForExtraScene(string sceneFile)
    {
        var maps = _limitMaps.Value;
        if (maps.DirectSceneLimits.TryGetValue(sceneFile, out var directLimit))
        {
            return directLimit;
        }

        return null;
    }

    public int? GetMaxEnemiesForScene(string sceneFile)
        => GetMaxEnemiesForExtraScene(sceneFile);

    public bool TryGetVanillaSpawnInfo(Guid guid, out VanillaSpawnInfo spawnInfo)
        => _spawnInfos.Value.TryGetValue(guid, out spawnInfo!);

    private static LimitMaps LoadLimitMaps(Randomizer randomizer)
    {
        var rows = Csv.Deserialize<EnemySceneLimit>(randomizer.DynamicData.GetData(DynamicDataName.EnemyLimits)!)
            .Where(limit => !string.IsNullOrWhiteSpace(limit.SceneFile))
            .ToArray();

        var directLimits = rows
            .GroupBy(limit => limit.SceneFile, StringComparer.OrdinalIgnoreCase)
            .ToImmutableDictionary(
                group => group.Key,
                group => ClampLimit(group.Last().MaxEnemies),
                StringComparer.OrdinalIgnoreCase);

        return new LimitMaps(directLimits);
    }

    private static ImmutableDictionary<Guid, VanillaSpawnInfo> LoadSpawnInfos(Randomizer randomizer)
    {
        return Csv.Deserialize<EnemyPlacementRow>(randomizer.DynamicData.GetData(DynamicDataName.Enemies)!)
            .Where(row =>
                row.Enabled &&
                row.IsSpawnInfo &&
                row.Dlc == null &&
                row.Guid != Guid.Empty)
            .GroupBy(row => row.Guid)
            .ToImmutableDictionary(
                group => group.Key,
                group =>
                {
                    var row = group.First();
                    return new VanillaSpawnInfo(row.Guid, row.EnemyID, row.SceneFile);
                });
    }

    private static int ClampLimit(int maxEnemies)
        => Math.Max(0, maxEnemies);

    internal sealed record VanillaSpawnInfo(Guid Guid, string UnitAlias, string SceneFile);

    private sealed record LimitMaps(ImmutableDictionary<string, int> DirectSceneLimits);

    private sealed class EnemyPlacementRow
    {
        public string EnemyID { get; set; } = "";
        public bool Enabled { get; set; }
        public DlcType? Dlc { get; set; }
        public bool IsSpawnInfo { get; set; }
        public Guid Guid { get; set; }
        public string SceneFile { get; set; } = "";
    }
}
