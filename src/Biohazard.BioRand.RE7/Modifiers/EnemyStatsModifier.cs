using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Impl;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyStatsModifier : Modifier
{
    private readonly List<IEnemyStatsModifier> _modifiers =
    [
        new MiaStatsModifier(),
    ];

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            foreach (var modifier in _modifiers)
            {
                if (modifier.Supports(enemy))
                {
                    modifier.Apply(enemy, randomizer, logger);
                }
            }
        }
    }
}
