using Biohazard.BioRand.RE7.Enemies;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Modifiers;

internal sealed record EnemyTableEntry(
    IEnemyDefinition Enemy,
    double Weight
);

internal static class EnemyPoolSelector
{
    internal static ImmutableArray<EnemyTableEntry> SelectAreaEnemyPool(
        IReadOnlyList<EnemyTableEntry> enemyPool,
        int enemyVariety,
        Rng rng)
    {
        if (enemyPool.Count == 0)
            return [];

        var desiredCount = Math.Clamp(enemyVariety, 1, enemyPool.Count);
        if (desiredCount >= enemyPool.Count)
            return [.. enemyPool];

        var remainingEntries = enemyPool.ToList();
        var selectedEntries = ImmutableArray.CreateBuilder<EnemyTableEntry>(desiredCount);
        while (selectedEntries.Count < desiredCount)
        {
            var selectedEnemy = ChooseWeightedEnemy(remainingEntries, rng);
            var selectedEntry = remainingEntries.First(entry => entry.Enemy == selectedEnemy);
            selectedEntries.Add(selectedEntry);
            remainingEntries.Remove(selectedEntry);
        }

        return selectedEntries.ToImmutable();
    }

    internal static IEnemyDefinition ChooseWeightedEnemy(
        IReadOnlyList<EnemyTableEntry> enemyPool,
        Rng rng)
    {
        if (enemyPool.Count == 0)
            throw new InvalidOperationException("No enemy entries are available.");

        if (enemyPool.Count == 1)
            return enemyPool[0].Enemy;

        var totalWeight = enemyPool.Sum(entry => entry.Weight);
        var roll = rng.NextDouble(0, totalWeight);
        var cumulativeWeight = 0.0;

        for (var i = 0; i < enemyPool.Count - 1; i++)
        {
            cumulativeWeight += enemyPool[i].Weight;
            if (roll < cumulativeWeight)
                return enemyPool[i].Enemy;
        }

        return enemyPool[^1].Enemy;
    }
}

internal sealed class EnemyPackSelector(IEnumerable<EnemyTableEntry> enemyPool, int maxPackSize, Rng rng)
{
    private readonly List<EnemyTableEntry> _enemyPool = [.. enemyPool];
    private readonly int _maxPackSize = Math.Max(1, maxPackSize);
    private readonly Rng _rng = rng;
    private IEnemyDefinition? _currentEnemy;
    private int _remainingPackSize;

    public IEnemyDefinition Next()
    {
        if (_currentEnemy == null || _remainingPackSize == 0)
        {
            _currentEnemy = ChooseNextEnemy();
            _remainingPackSize = _rng.Next(1, _maxPackSize + 1);
        }

        _remainingPackSize--;
        return _currentEnemy;
    }

    private IEnemyDefinition ChooseNextEnemy()
    {
        if (_enemyPool.Count == 0)
            throw new InvalidOperationException("Cannot choose an enemy from an empty pack selector.");

        if (_enemyPool.Count == 1 || _currentEnemy == null)
            return EnemyPoolSelector.ChooseWeightedEnemy(_enemyPool, _rng);

        var candidates = _enemyPool
            .Where(entry => entry.Enemy != _currentEnemy)
            .ToList();

        return EnemyPoolSelector.ChooseWeightedEnemy(candidates, _rng);
    }
}
