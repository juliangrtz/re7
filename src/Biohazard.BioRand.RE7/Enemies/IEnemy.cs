using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;
using System.ComponentModel.DataAnnotations;

namespace Biohazard.BioRand.RE7.Enemies;

internal interface IEnemy
{
    [Key]
    public EnemyID Id { get; }

    public EnemyCategory Category { get; }
    public ConfigCategory ConfigCategory { get; }

    public string Name { get; }

    public bool IsBoss { get; }

    public int Health { get; }

    public RszGameObject GetPrefab(TemplateService templateService)
        => templateService.GetObject($"EnemyTemplate_{Id}");

    public void ApplyConfigStats(Randomizer randomizer);
}
