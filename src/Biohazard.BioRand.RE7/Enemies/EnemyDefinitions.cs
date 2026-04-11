using Biohazard.BioRand.RE7.Enemies.Impl;

namespace Biohazard.BioRand.RE7.Enemies;

public sealed class EnemyDefinitions
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
        All = [
            //new EvelineFinalBoss(),
            new EvelineGrandmother(),
            new FlyingBug(),
            new InsectHive(),
            new InsectSwarm(),
            new JackShears(),
            //new JackMutated(),
            new JackStalker(),
            new MargeMutated(),
            //new MargeStalker(),
            new MiaChainsaw(),
            //new MiaKnife(),
            new Impl.Molded(),
            new MoldedBlade(),
            new MoldedQuick(),
            new MoldedFat(),
        ];
        Bosses = All.Where(em => em.IsBoss).ToList();
        NonBosses = All.Where(em => !em.IsBoss).ToList();
    }

    public IEnemyDefinition? FromId(EnemyID id)
        => All.FirstOrDefault(em => em?.EnemyId == id, null);

    public IEnemyDefinition? FromId(string id)
    => All.FirstOrDefault(em => em?.EnemyId.ToString() == id, null);
}
