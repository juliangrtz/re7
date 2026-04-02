namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyMultiplierModifier : Modifier
{
    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {

    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var multiplier = randomizer.GetConfigOption("enemy-multiplier", 0.0);
        if (multiplier == 1.0)
            return;
    }
}
