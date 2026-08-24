using Biohazard.BioRand.RE7.Enemies;

namespace Biohazard.BioRand.RE7.Modifiers;

internal sealed record EnemyRandomizerOptions(
    int EnemyVariety,
    int MaxPackSize,
    bool DebugUniqueHp,
    bool IsBalanced,
    ScaleOptions ScaleOptions,
    double ForceTargetingProbability
);

internal sealed record ScaleOptions(
    double Probability,
    float Min,
    float Max
);

internal sealed class EnemyHealthResolver(Randomizer randomizer, EnemyRandomizerOptions options, Rng healthRng) {
    private readonly HashSet<float> _assignedHealthValues = [];

    public float GetHealth(IEnemyDefinition enemy) {
        var health = enemy.GetHealth(randomizer, healthRng);
        if (!options.DebugUniqueHp) {
            return health;
        }

        while (!_assignedHealthValues.Add(health)) {
            health += 1f;
        }

        return health;
    }
}
