using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Services;

internal class AreaService(Randomizer randomizer)
{
    private readonly Dictionary<Guid, Area> _guidToArea = [];
    private ImmutableArray<Area> _areas = [];
    private bool _isLoaded;

    public ImmutableArray<Area> Areas
    {
        get
        {
            EnsureLoaded();
            return _areas;
        }
        private set => _areas = value;
    }

    public Randomizer Randomizer { get; } = randomizer;

    public void LoadAreas() => EnsureLoaded();

    private void EnsureLoaded()
    {
        if (_isLoaded)
            return;

        LoadAreasCore();
        _isLoaded = true;
    }

    private void LoadAreasCore()
    {
        Areas = AreaDefinitionRepository.Default.All
            .Where(a => a.Dlc == null)
            .AsParallel()
            .Select(d => new Area(Randomizer, d))
            .OrderBy(x => x.Path)
            .ToImmutableArray();

        // Map initial guids
        _guidToArea.Clear();

        foreach (var area in _areas)
        {
            area.MapGameObjectGuids(_guidToArea);
        }
    }

    public Area? FindAreaContainingGameObject(Guid guid)
    {
        EnsureLoaded();
        _guidToArea.TryGetValue(guid, out var area);
        return area;
    }

    public void RemoveGuid(Guid guid)
    {
        _guidToArea.Remove(guid);
    }

    public void AddGuidToArea(Guid guid, Area area)
    {
        _guidToArea[guid] = area;
    }

    public Area FindBestArea(AreaKind kind, int? chapter = null)
    {
        EnsureLoaded();

        if (chapter != null)
        {
            return Areas
                .Where(x => x.Definition.Kind == kind)
                .First(x => x.Definition.Chapter == chapter);
        }
        else
        {
            return Areas
                .Where(x => x.Definition.Kind == kind)
                .First();
        }
    }
}
