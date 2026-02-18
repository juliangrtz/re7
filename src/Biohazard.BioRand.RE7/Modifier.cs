namespace Biohazard.BioRand.RE7 {
    internal abstract class Modifier {
        public virtual void LogState(RE7Randomizer randomizer, RandomizerLogger logger) {
        }

        public virtual void Apply(RE7Randomizer randomizer, RandomizerLogger logger) {
        }
    }
}
