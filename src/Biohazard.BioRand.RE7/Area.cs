using IntelOrca.Biohazard.REE.Rsz;

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
                        .Set("Startup", true), []);
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

    public Area(Randomizer randomizer, AreaDefinition definition)
    {
        Randomizer = randomizer;
        Definition = definition;
        ScnFile = randomizer.FileRepository
            .GetScnFile(definition.Path, randomizer.IsOnRaytracingVersion)
            .ToBuilder(randomizer.FileRepository.TypeRepository);
        Scan();
    }

    private void Scan()
    {
        // TODO
    }

    public void Save()
    {
        // TODO
    }

    public IEnumerable<RszGameObject> Items
    {
        get
        {
            var result = new List<RszGameObject>();
            Scene.VisitGameObjects(gameObject =>
            {
                var itemComponent = gameObject.FindComponent("app.Item");
                if (itemComponent != null)
                {
                    result.Add(gameObject);
                }
            });
            return result;
        }
    }

    public override string ToString() => FileName;
}
