using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Enemies;

internal class EnemyGeneratorWrapper {
    public Area Area { get; }
    public RszGameObject GameObject { get; private set; }
    public app.EnemyGenerator Generator { get; private set; }
    public ImmutableArray<RszGameObject> EnemyGameObjects { get; private set; }
    public ImmutableArray<RszGameObject> EnemySpawnInfos { get; private set; }

    public EnemyGeneratorWrapper(Area area, RszGameObject gameObject, app.EnemyGenerator enemyGeneratorComponent) {
        Area = area;
        GameObject = gameObject;
        Generator = enemyGeneratorComponent;
        ScanEnemies();
    }

    public bool Enabled {
        get => Generator.Enabled;
        set => Generator.Enabled = value;
    }

    private void ScanEnemies() {
        var enemies = ImmutableArray.CreateBuilder<RszGameObject>();
        var enemySpawnInfos = ImmutableArray.CreateBuilder<RszGameObject>();

        GameObject.VisitGameObjects(go => {
            if (HasEnemyMesh(go)) {
                enemies.Add(go);
            }
        });

        var enemyPools = new List<RszGameObject>();
        GameObject.VisitGameObjects(go => {
            if (go.FindComponent<app.EnemyPool>() != null) {
                enemyPools.Add(go);
            }
        });

        foreach (var enemyPool in enemyPools) {
            foreach (var poolChild in enemyPool.Children) {
                if (ContainsEnemyMesh(poolChild))
                    continue;

                poolChild.VisitGameObjects(go => {
                    if (go.FindComponent<app.EnemySpawnInfo>() != null) {
                        enemySpawnInfos.Add(go);
                    }
                });
            }
        }

        EnemyGameObjects = enemies.ToImmutableArray();
        EnemySpawnInfos = enemySpawnInfos.ToImmutableArray();
    }

    private static bool HasEnemyMesh(RszGameObject gameObject) {
        var mesh = gameObject.FindComponent("via.render.Mesh");
        return mesh != null
               && mesh.Children.Length > 2
               && mesh.Children[2]?.ToString()
                   ?.StartsWith("Character/Enemy/", StringComparison.InvariantCultureIgnoreCase) == true;
    }

    private static bool ContainsEnemyMesh(RszGameObject gameObject) {
        var result = false;
        gameObject.VisitGameObjects(child => {
            if (HasEnemyMesh(child)) {
                result = true;
            }
        });
        return result;
    }

    public override string ToString()
        => Generator.Alias;
}