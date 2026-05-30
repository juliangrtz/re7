namespace Biohazard.BioRand.RE7;

internal sealed class RandomizerLoggerIO {
    public RandomizerLogger Input { get; } = new();
    public RandomizerLogger Process { get; } = new();
    public RandomizerLogger Output { get; } = new();
}