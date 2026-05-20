using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7;

public class AreaDefinitionRepository {
    private static AreaDefinitionRepository? _default;
    private static readonly object _defaultLock = new();
    private Dictionary<string, AreaDefinition> _areasByPath = new(StringComparer.OrdinalIgnoreCase);

    public List<AreaDefinition> All { get; set; } = [];
    public List<AreaDefinition> General { get; set; } = [];
    public List<AreaDefinition> Items { get; set; } = [];
    public List<AreaDefinition> Enemies { get; set; } = [];

    private void Initialize() {
        All = EmbeddedData.GetFile("areas.json").DeserializeJson<List<AreaDefinition>>();
        ApplyCsvDescriptions(All);
        General = All.Where(area => area.Kind == AreaKind.General).ToList();
        Items = All.Where(area => area.Kind == AreaKind.Item).ToList();
        Enemies = All.Where(area => area.Kind == AreaKind.Enemy).ToList();
        _areasByPath = All
            .Where(area => !string.IsNullOrWhiteSpace(area.Path))
            .GroupBy(area => area.Path, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);
    }

    public string FormatScenePath(string path) {
        if (_areasByPath.TryGetValue(path, out var area) && !string.IsNullOrWhiteSpace(area.Description)) {
            return $"{NormalizeDescription(area.Description)} :: {path}";
        }

        return path;
    }

    private static void ApplyCsvDescriptions(List<AreaDefinition> areas) {
        var csv = EmbeddedData.TryGetFile("areas.csv");
        if (csv == null)
            return;

        var descriptionsByPath = Csv.Deserialize<AreaDefinition>(csv)
            .Where(area => !string.IsNullOrWhiteSpace(area.Path) && !string.IsNullOrWhiteSpace(area.Description))
            .GroupBy(area => area.Path, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                group => group.Key,
                group => NormalizeDescription(group.First().Description!),
                StringComparer.OrdinalIgnoreCase);

        foreach (var area in areas) {
            if (descriptionsByPath.TryGetValue(area.Path, out var description)) {
                area.Description = description;
            }
        }
    }

    private static string NormalizeDescription(string description) {
        var parts = description
            .Split('/', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return parts.Length == 0 ? description.Trim() : string.Join(" / ", parts);
    }

    public static AreaDefinitionRepository Default {
        get {
            if (_default == null) {
                lock (_defaultLock) {
                    if (_default == null) {
                        var repository = new AreaDefinitionRepository();
                        repository.Initialize();
                        _default = repository;
                    }
                }
            }

            return _default;
        }
    }
}