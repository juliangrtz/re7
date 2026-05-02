using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Enemies;

internal class EnemyGeneratorWrapper
{
    public Area Area { get; }
    public RszGameObject GameObject { get; private set; }
    public RszObjectNode Generator { get; private set; }
    public ImmutableArray<RszGameObject> EnemyGameObjects { get; private set; }
    public ImmutableArray<RszGameObject> EnemySpawnInfos { get; private set; }

    public EnemyGeneratorWrapper(Area area, RszGameObject gameObject, RszObjectNode enemyGeneratorComponent)
    {
        Area = area;
        GameObject = gameObject;
        Generator = enemyGeneratorComponent;
        ScanEnemies();
    }

    public bool Enabled
    {
        get => EnemyGenerationComponents.IsEnabled(Generator);
        set => Generator = Generator.SetField("Enabled", value);
    }

    public string Alias => EnemyGenerationComponents.GetAlias(Generator);

    private void ScanEnemies()
    {
        var enemies = ImmutableArray.CreateBuilder<RszGameObject>();
        var enemySpawnInfos = ImmutableArray.CreateBuilder<RszGameObject>();

        GameObject.VisitGameObjects(go =>
        {
            var mesh = go.FindComponent("via.render.Mesh");
            if (mesh != null
                && mesh.Children[2]?.ToString()?.StartsWith("Character/Enemy/", StringComparison.InvariantCultureIgnoreCase) == true)
            {
                enemies.Add(go);
            }

            var spawnInfo = EnemySpawnInfoComponents.FindSpawnInfo(go);
            if (spawnInfo != null)
            {
                enemySpawnInfos.Add(go);
            }
        });

        EnemyGameObjects = enemies.ToImmutableArray();
        EnemySpawnInfos = enemySpawnInfos.ToImmutableArray();
    }

    public override string ToString()
        => Alias;
}
