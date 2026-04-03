using System.Reflection;

namespace Biohazard.BioRand.RE7.Enemies;

internal class EnemyDefinitions
{
    private static EnemyDefinitions? _instance;

    public List<IEnemy> All { get; private set; } = [];
    public List<IEnemy> Bosses { get; private set; } = [];
    public List<IEnemy> NonBosses { get; private set; } = [];

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
                        .Where(t => typeof(IEnemy).IsAssignableFrom(t)
                                    && !t.IsInterface
                                    && !t.IsAbstract)
                        .Select(t => (IEnemy)Activator.CreateInstance(t)!)
                        .ToList();
        Bosses = All.Where(em => em.IsBoss).ToList();
        NonBosses = All.Where(em => !em.IsBoss).ToList();
    }

    public IEnemy GetById(EnemyID id)
        => All.SingleOrDefault(em => em?.EnemyId == id, null) ?? throw new Exception($"Invalid enemy ID '{id}'");
}
