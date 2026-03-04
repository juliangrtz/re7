namespace Biohazard.BioRand.RE7;

internal abstract class Modifier
{
    public virtual void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
    }

    public virtual void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
    }
}