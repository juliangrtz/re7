using Biohazard.BioRand.RE7.Enemies;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7;

internal class Area {
    private ImmutableArray<Guid> _pendingGameObjectGuids = [];

    public Randomizer Randomizer { get; }
    public AreaDefinition Definition { get; }
    public string Path => Definition.Path;
    public string FileName => System.IO.Path.GetFileName(Path);
    public ScnFile.Builder ScnFile { get; }

    public RszScene Scene {
        get => ScnFile.Scene;
        set => ScnFile.Scene = value;
    }

    public RszFolder BioRandFolder {
        get {
            var biorandFolder = Scene.Children.OfType<RszFolder>().FirstOrDefault(x => x.Name == "BioRand");
            if (biorandFolder == null) {
                biorandFolder = new RszFolder(Randomizer.FileRepository.TypeRepository
                    .Create("via.Folder")
                    .Set("Name", "BioRand")
                    .Set("Update", true)
                    .Set("Draw", true)
                    .Set("Standby", true), []);
                Scene = Scene.Add(biorandFolder);
            }

            return biorandFolder;
        }
        set {
            Scene = Scene.WithChildren(
                Scene.Children.Replace(BioRandFolder, value));
        }
    }

    public ImmutableArray<EnemyGeneratorWrapper> EnemyGenerators { get; set; }

    public ImmutableArray<RszGameObject> Items { get; set; }

    public ImmutableArray<RszGameObject> Weapons { get; set; }

    public Area(Randomizer randomizer, AreaDefinition definition, AreaScanMode scanMode = AreaScanMode.Full) {
        Randomizer = randomizer;
        Definition = definition;
        ScnFile = randomizer.FileRepository
            .GetScnFile(definition.Path)
            .ToBuilder(randomizer.FileRepository.TypeRepository);
        if (scanMode != AreaScanMode.IndexedTargets || !ScanIndexedTargets()) {
            Scan();
        }
    }

    private bool ScanIndexedTargets() {
        var targets = AreaSceneTargetRepository.Default.FromPath(Path);
        if (targets == null)
            return false;

        var targetGuids = targets.GetEnemyGeneratorGuids()
            .Concat(targets.GetItemGuids())
            .Concat(targets.GetWeaponGuids())
            .ToHashSet();
        var targetGameObjects = FindTargetGameObjects(Scene, targetGuids);
        var itemPlacementService = Randomizer.ItemPlacementService;

        EnemyGenerators = targets.GetEnemyGeneratorGuids()
            .Select(guid => targetGameObjects.GetValueOrDefault(guid))
            .Where(gameObject => gameObject != null)
            .Select(gameObject => (
                GameObject: gameObject!,
                Component: gameObject!.FindComponent<app.EnemyGenerator>()))
            .Where(x => x.Component?.Enabled == true)
            .Select(x => new EnemyGeneratorWrapper(this, x.GameObject, x.Component!))
            .ToImmutableArray();
        Items = targets.GetItemGuids()
            .Select(guid => targetGameObjects.GetValueOrDefault(guid))
            .Where(gameObject => gameObject != null && itemPlacementService.HasItem(gameObject.Guid))
            .Cast<RszGameObject>()
            .ToImmutableArray();
        Weapons = targets.GetWeaponGuids()
            .Select(guid => targetGameObjects.GetValueOrDefault(guid))
            .Where(gameObject => gameObject != null)
            .Cast<RszGameObject>()
            .ToImmutableArray();
        _pendingGameObjectGuids = [];

        return true;
    }

    private static Dictionary<Guid, RszGameObject> FindTargetGameObjects(IRszSceneNode node,
        HashSet<Guid> remainingGuids) {
        var result = new Dictionary<Guid, RszGameObject>();
        if (remainingGuids.Count == 0)
            return result;

        FindTargetGameObjectsInner(node);
        return result;

        void FindTargetGameObjectsInner(IRszSceneNode current) {
            if (remainingGuids.Count == 0)
                return;

            if (current is RszGameObject gameObject && remainingGuids.Remove(gameObject.Guid)) {
                result[gameObject.Guid] = gameObject;
            }

            foreach (var child in current.Children) {
                FindTargetGameObjectsInner(child);
            }
        }
    }

    private void Scan() {
        var enemyGenerators = ImmutableArray.CreateBuilder<EnemyGeneratorWrapper>();
        var weapons = ImmutableArray.CreateBuilder<RszGameObject>();
        var items = ImmutableArray.CreateBuilder<RszGameObject>();
        var gameObjectGuids = ImmutableArray.CreateBuilder<Guid>();
        var itemPlacementService = Randomizer.ItemPlacementService;
        ScanInner(Scene);
        EnemyGenerators = enemyGenerators.ToImmutable();
        Weapons = weapons.ToImmutable();
        Items = items.ToImmutable();
        _pendingGameObjectGuids = gameObjectGuids.ToImmutable();

        void ScanInner(IRszSceneNode node) {
            if (node is RszGameObject gameObject) {
                gameObjectGuids.Add(gameObject.Guid);

                var enemyGeneratorComponent = gameObject.FindComponent<app.EnemyGenerator>();
                if (enemyGeneratorComponent != null && enemyGeneratorComponent.Enabled) {
                    enemyGenerators.Add(new EnemyGeneratorWrapper(this, gameObject, enemyGeneratorComponent));
                    return;
                }

                if (itemPlacementService.HasItem(gameObject.Guid)) {
                    items.Add(gameObject);
                    return;
                }

                if (gameObject.FindComponent<app.Weapon>() != null ||
                    gameObject.FindComponent<app.WeaponGun>() != null) {
                    weapons.Add(gameObject);
                    return;
                }
            }

            foreach (var child in node.Children) {
                ScanInner(child);
            }
        }
    }

    internal void MapGameObjectGuids(Dictionary<Guid, Area> guidToArea) {
        foreach (var guid in _pendingGameObjectGuids) {
            guidToArea[guid] = this;
        }

        _pendingGameObjectGuids = [];
    }

    public override string ToString() => FileName;
}

internal enum AreaScanMode {
    Full,
    IndexedTargets,
}