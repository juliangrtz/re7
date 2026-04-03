using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;
using System.ComponentModel.DataAnnotations;

namespace Biohazard.BioRand.RE7.Enemies;

internal interface IEnemyDefinition
{
    [Key]
    public string Id { get; }

    public EnemyID EnemyId { get; }

    public EnemyCategory Category { get; }

    public string Name { get; }

    public bool IsBoss { get; }

    public int Health { get; }

    public string DirectivesHolderPath { get; }
    public string ResistParamsHolderPath { get; }

    public RszGameObject GetPrefab(TemplateService templateService)
        => templateService.GetObject($"EnemyTemplate_{Id}");
}
