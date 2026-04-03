namespace Biohazard.BioRand.RE7.Enemies;

internal interface IEnemyStatsModifier
{
    bool Supports(IEnemyDefinition enemy);
    void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger);
}