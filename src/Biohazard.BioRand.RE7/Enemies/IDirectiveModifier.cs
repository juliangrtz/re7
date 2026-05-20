namespace Biohazard.BioRand.RE7.Enemies;

internal interface IDirectiveModifier {
    bool Supports(IEnemyDefinition enemy);
    void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger);
}