using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Impl;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyDirectiveModifier : Modifier
{
    private readonly List<IDirectiveModifier> _modifiers =
    [
        new EvelineFinalBossDirectiveModifier(),
        new InsectsDirectiveModifier(),
        new JackShearsDirectiveModifier(),
        new JackMutatedDirectiveModifier(),
        new JackStalkerDirectiveModifier(),
        new MargeMutatedDirectiveModifier(),
        new MargeStalkerDirectiveModifier(),
        new MiaDirectiveModifier(),
        new MoldedDirectiveModifier(),
        new MoldedFatDirectiveModifier(),
        new MoldedQuickDirectiveModifier(),
    ];

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var enemy in EnemyDefinitions.Instance.All.OrderBy(em => em.EnemyId))
        {
            foreach (var modifier in _modifiers)
            {
                if (modifier.Supports(enemy))
                {
                    logger.Push($"{enemy.EnemyId} -- {enemy.Name}");
                    modifier.Apply(enemy, randomizer, logger);
                    logger.Pop();
                }
            }
        }
    }
}
