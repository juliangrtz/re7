using Biohazard.BioRand.RE7.Enemies.Impl;

namespace Biohazard.BioRand.RE7.Enemies;

public sealed class EnemyDefinitions
{
    private static readonly Lazy<EnemyDefinitions> _instance = new(Create, isThreadSafe: true);

    public List<IEnemyDefinition> All { get; private set; } = [];
    public List<IEnemyDefinition> Bosses { get; private set; } = [];
    public List<IEnemyDefinition> NonBosses { get; private set; } = [];

    public static EnemyDefinitions Instance => _instance.Value;

    private static EnemyDefinitions Create()
    {
        var instance = new EnemyDefinitions();
        instance.Initialize();
        return instance;
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
            //new MiaChainsaw(),
            //new MiaKnife(),
            new Impl.Molded(),
            new MoldedBlade(),
            new MoldedQuick(),
            new MoldedFat(),
            new NotAHeroEm4210(),
            new NotAHeroEm4400(),
            new NotAHeroEm4450(),
            new NotAHeroEm4460(),
            new NotAHeroEm4500(),
            new NotAHeroEm4600(),
            new EndOfZoeEm5700(),
            new EndOfZoeEm5800(),
            new EndOfZoeEm5850(),
            new EndOfZoeEm6700(),
            new EndOfZoeEm7500(),
            new EndOfZoeEm7700(),
            new EndOfZoeEm7800(),
            new EndOfZoeEm7900(),
        ];
        Bosses = All.Where(em => em.IsBoss).ToList();
        NonBosses = All.Where(em => !em.IsBoss).ToList();
    }

    public IEnemyDefinition? FromId(EnemyID id)
        => All.FirstOrDefault(em => em?.EnemyId == id, null);

    public IEnemyDefinition? FromId(string id)
        => All.FirstOrDefault(em =>
            em?.EnemyAlias.Equals(id, StringComparison.InvariantCultureIgnoreCase) == true ||
            em?.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase) == true,
            null);
}
