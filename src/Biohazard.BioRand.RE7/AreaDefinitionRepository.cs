using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7;

public class AreaDefinitionRepository
{
    private static AreaDefinitionRepository? _default;
    private static readonly object _defaultLock = new();

    public List<AreaDefinition> All { get; set; } = [];
    public List<AreaDefinition> General { get; set; } = [];
    public List<AreaDefinition> Items { get; set; } = [];
    public List<AreaDefinition> Enemies { get; set; } = [];

    private void Initialize()
    {
        All = EmbeddedData.GetFile("areas.json").DeserializeJson<List<AreaDefinition>>();
        General = All.Where(area => area.Kind == AreaKind.General).ToList();
        Items = All.Where(area => area.Kind == AreaKind.Item).ToList();
        Enemies = All.Where(area => area.Kind == AreaKind.Enemy).ToList();
    }

    public static AreaDefinitionRepository Default
    {
        get
        {
            if (_default == null)
            {
                lock (_defaultLock)
                {
                    if (_default == null)
                    {
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
