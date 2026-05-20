using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7;

public sealed class AreaSceneTargets {
    public string Path { get; set; } = "";
    public List<Guid>? ItemGuids { get; set; }
    public List<Guid>? WeaponGuids { get; set; }
    public List<Guid>? EnemyGeneratorGuids { get; set; }
    public List<Guid>? EnemySpawnInfoGuids { get; set; }
    public List<Guid>? EnemyGenerateGuids { get; set; }

    public IReadOnlyList<Guid> GetItemGuids() => ItemGuids is null ? Array.Empty<Guid>() : ItemGuids;
    public IReadOnlyList<Guid> GetWeaponGuids() => WeaponGuids is null ? Array.Empty<Guid>() : WeaponGuids;

    public IReadOnlyList<Guid> GetEnemyGeneratorGuids() =>
        EnemyGeneratorGuids is null ? Array.Empty<Guid>() : EnemyGeneratorGuids;

    public IReadOnlyList<Guid> GetEnemySpawnInfoGuids() =>
        EnemySpawnInfoGuids is null ? Array.Empty<Guid>() : EnemySpawnInfoGuids;

    public IReadOnlyList<Guid> GetEnemyGenerateGuids() =>
        EnemyGenerateGuids is null ? Array.Empty<Guid>() : EnemyGenerateGuids;

    public bool HasAnyTargets() =>
        GetItemGuids().Count != 0 ||
        GetWeaponGuids().Count != 0 ||
        GetEnemyGeneratorGuids().Count != 0 ||
        GetEnemySpawnInfoGuids().Count != 0 ||
        GetEnemyGenerateGuids().Count != 0;
}

internal sealed class AreaSceneTargetRepository {
    private const string FileName = "area_scene_targets.json";
    private static AreaSceneTargetRepository? _default;
    private static readonly object _defaultLock = new();
    private Dictionary<string, AreaSceneTargets> _byPath = new(StringComparer.OrdinalIgnoreCase);

    public IReadOnlyList<AreaSceneTargets> All { get; private set; } = [];

    private void Initialize() {
        var data = EmbeddedData.TryGetFile(FileName);
        if (data == null) {
            All = [];
            _byPath = new Dictionary<string, AreaSceneTargets>(StringComparer.OrdinalIgnoreCase);
            return;
        }

        All = data.DeserializeJson<List<AreaSceneTargets>>();
        _byPath = All.ToDictionary(targets => targets.Path, StringComparer.OrdinalIgnoreCase);
    }

    public AreaSceneTargets? FromPath(string path)
        => _byPath.TryGetValue(path, out var targets) ? targets : null;

    public static AreaSceneTargetRepository Default {
        get {
            if (_default == null) {
                lock (_defaultLock) {
                    if (_default == null) {
                        var repository = new AreaSceneTargetRepository();
                        repository.Initialize();
                        _default = repository;
                    }
                }
            }

            return _default;
        }
    }
}