using Biohazard.BioRand.RE7.Enemies;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7;

internal class Area
{
    public Randomizer Randomizer { get; }
    public AreaDefinition Definition { get; }
    public string Path => Definition.Path;
    public string FileName => System.IO.Path.GetFileName(Path);
    public ScnFile.Builder ScnFile { get; }

    public RszScene Scene
    {
        get => ScnFile.Scene;
        set => ScnFile.Scene = value;
    }

    public RszFolder BioRandFolder
    {
        get
        {
            var biorandFolder = Scene.Children.OfType<RszFolder>().FirstOrDefault(x => x.Name == "BioRand");
            if (biorandFolder == null)
            {
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
        set
        {
            Scene = Scene.WithChildren(
                Scene.Children.Replace(BioRandFolder, value));
        }
    }

    public ImmutableArray<EnemyGeneratorWrapper> EnemyGenerators { get; set; }

    public ImmutableArray<RszGameObject> Items { get; set; }

    public ImmutableArray<RszGameObject> Weapons { get; set; }

    public Area(Randomizer randomizer, AreaDefinition definition)
    {
        Randomizer = randomizer;
        Definition = definition;
        ScnFile = randomizer.FileRepository
            .GetScnFile(definition.Path)
            .ToBuilder(randomizer.FileRepository.TypeRepository);
        Scan();
    }

    private void Scan()
    {
        var enemyGenerators = ImmutableArray.CreateBuilder<EnemyGeneratorWrapper>();
        var weapons = ImmutableArray.CreateBuilder<RszGameObject>();
        var items = ImmutableArray.CreateBuilder<RszGameObject>();
        ScanInner(Scene);
        EnemyGenerators = enemyGenerators.ToImmutable();
        Weapons = weapons.ToImmutable();
        Items = items.ToImmutable();

        void ScanInner(IRszSceneNode node)
        {
            if (node is RszGameObject gameObject)
            {
                var enemyGeneratorComponent = gameObject.FindComponent<app.EnemyGenerator>();
                if (enemyGeneratorComponent != null && enemyGeneratorComponent.Enabled)
                {
                    enemyGenerators.Add(new EnemyGeneratorWrapper(this, gameObject, enemyGeneratorComponent));
                    return;
                }

                if (Randomizer.ItemPlacementService.HasItem(gameObject.Guid))
                {
                    items.Add(gameObject);
                    return;
                }

                if (gameObject.FindComponent<app.Weapon>() != null || gameObject.FindComponent<app.WeaponGun>() != null)
                {
                    weapons.Add(gameObject);
                    return;
                }
            }

            foreach (var child in node.Children)
            {
                ScanInner(child);
            }
        }
    }

    public override string ToString() => FileName;
}
