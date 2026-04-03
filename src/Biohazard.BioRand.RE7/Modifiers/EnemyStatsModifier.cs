using Biohazard.BioRand.RE7.Enemies;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyStatsModifier : Modifier
{
    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
        => EnemyDefinitions.Instance.All.ForEach(em => em.ApplyConfigStats(randomizer, logger));
}
