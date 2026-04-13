using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Services;

internal class TemplateService
{
    private const string TemplateSceneFileName = "template.scn";
    private readonly ScnFile _templateScnFile;
    private readonly RszScene _scene;
    private readonly Dictionary<string, RszGameObject> _itemTemplates = new();

    public TemplateService(Randomizer randomizer)
    {
        if (randomizer.IsOnRaytracingVersion)
        {
            _templateScnFile = new(
                FileVersions.SceneFileVersionRT,
                EmbeddedData.GetFile($"{TemplateSceneFileName}.{FileVersions.SceneFileVersionRT}")
            );
        }
        else
        {
            _templateScnFile = new(
                FileVersions.SceneFileVersionNonRT,
                EmbeddedData.GetFile($"{TemplateSceneFileName}.{FileVersions.SceneFileVersionNonRT}")
            );
        }

        _scene = _templateScnFile.ReadScene(randomizer.FileRepository.TypeRepository);
        _scene.VisitGameObjects(go =>
        {
            if (go.Name.StartsWith("ItemTemplate"))
            {
                _itemTemplates.Add(go.Name.SubstringAfter("_"), go);
            }
        });
    }

    public RszGameObject GetObject(string name) 
        => _scene.FindGameObject(name) ?? throw new Exception($"Object with name {name} not found in template scene!");

    public RszGameObject GetEnemyTemplate(string enemyID)
        => GetObject($"EnemyTemplate_{enemyID}");

    public RszGameObject GetEnemySpawnInfo(string enemyID)
        => GetObject($"EnemySpawnInfo_{enemyID}");

    // TODO: DLC item support
    public RszGameObject GetItemTemplate(string id)
    {
        _itemTemplates.TryGetValue(id, out RszGameObject? result);
        return result ?? throw new Exception($"Item template {id} not found in template scene!");
    }
}
