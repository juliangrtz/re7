using System.Reflection;

namespace Biohazard.BioRand.RE7.Enemies;

internal class EnemyDefinitions
{
    private static EnemyDefinitions? _instance;

    public List<IEnemyDefinition> All { get; private set; } = [];
    public List<IEnemyDefinition> Bosses { get; private set; } = [];
    public List<IEnemyDefinition> NonBosses { get; private set; } = [];

    public static EnemyDefinitions Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EnemyDefinitions();
                _instance.Initialize();
            }
            return _instance;
        }
    }

    private void Initialize()
    {
        All = Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .Where(t => typeof(IEnemyDefinition).IsAssignableFrom(t)
                                    && !t.IsInterface
                                    && !t.IsAbstract)
                        .Select(t => (IEnemyDefinition)Activator.CreateInstance(t)!)
                        .ToList();
        Bosses = All.Where(em => em.IsBoss).ToList();
        NonBosses = All.Where(em => !em.IsBoss).ToList();
    }

    public IEnemyDefinition GetById(EnemyID id)
        => All.SingleOrDefault(em => em?.EnemyId == id, null) ?? throw new Exception($"Invalid enemy ID '{id}'");
}
