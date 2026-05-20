namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyPlaceModifier : Modifier {
    public override void LogState(Randomizer randomizer, RandomizerLogger logger) { }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger) {
        var extraEnemiesPercent = randomizer.GetConfigOption("extra-enemy-amount", 0.0);
        if (extraEnemiesPercent == 0.0)
            return;
    }
}