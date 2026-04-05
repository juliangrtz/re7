using Biohazard.BioRand.RE7.REEngine;
using System.ComponentModel.DataAnnotations;

namespace Biohazard.BioRand.RE7.Enemies;

public interface IEnemyDefinition
{
    [Key]
    public string Id { get; }

    public EnemyID EnemyId { get; }

    public EnemyCategory Category { get; }

    public string Name { get; }

    public bool IsBoss { get; }

    public int BaseHealth { get; }

    public string DirectivesHolderPath { get; }
    public string ResistParamsHolderPath { get; }

    public string OriginalPrefabPath =>
        PakPath.SceneFile($"scenes/enemy/{EnemyId.ToString().ToLowerInvariant()}.scn");

    public bool IsMolded =>
        Category == EnemyCategory.Molded;

    internal float GetHealthMultiplier(Randomizer randomizer, Rng rng)
        => (float)rng.NextDouble(
            randomizer.GetConfigOption<double>($"{(IsBoss ? "boss" : "enemy")}-health-min-{Id.ToLowerInvariant()}"),
            randomizer.GetConfigOption<double>($"{(IsBoss ? "boss" : "enemy")}-health-max-{Id.ToLowerInvariant()}")
       );
}
