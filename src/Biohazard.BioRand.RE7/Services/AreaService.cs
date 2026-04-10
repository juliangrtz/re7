using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Biohazard.BioRand.RE7.Services;

internal class AreaService(Randomizer randomizer)
{
    private readonly Dictionary<Guid, Area> _guidToArea = [];

    public ImmutableArray<Area> Areas { get; private set; } = [];
    public Randomizer Randomizer { get; } = randomizer;

    public void LoadAreas()
    {
        var areaRepo = AreaDefinitionRepository.Default;
        Areas = areaRepo.All
            .Where(a => a.Dlc == null)
            .AsParallel()
            .Select(d => new Area(Randomizer, d))
            .OrderBy(x => x.Path)
            .ToImmutableArray();

        // Map initial guids
        foreach (var area in Areas)
        {
            area.Scene.VisitGameObjects(gameObject =>
            {
                _guidToArea[gameObject.Guid] = area;
            });
        }
    }

    public Area? FindAreaContainingGameObject(Guid guid)
    {
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
