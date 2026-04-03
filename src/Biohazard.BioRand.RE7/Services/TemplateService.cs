using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Services;

internal class TemplateService
{
    private const string TemplateSceneFileName = "template.scn";
    private readonly ScnFile _templateScnFile;
    private readonly RszScene _scene;
    private readonly Dictionary<string, RszGameObject> _itemTemplates = new();
    private readonly List<ITemplateModifier> _templateModifiers = new();

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

    public void InjectModifier(ITemplateModifier modifier)
    {
        if(!HasModifier(modifier))
            _templateModifiers.Add(modifier);
    }

    public void RemoveModifier(ITemplateModifier modifier)
        => _templateModifiers.Remove(modifier);

    public bool HasModifier(ITemplateModifier modifier)
        => _templateModifiers.Contains(modifier);

    public RszGameObject GetObject(string name)
    {
        var go = _scene.FindGameObject(name) ?? throw new Exception($"Object with name {name} not found in template scene!");
        _templateModifiers.ForEach(m =>
        {
            if (m.GameObjectName == name)
            {
                go = m.Apply(go);
            }
        });
        return go;
    }

    // TODO: DLC item support
    public RszGameObject GetItemTemplate(string id)
    {
        _itemTemplates.TryGetValue(id, out RszGameObject? result);
        return result ?? throw new Exception($"Item template {id} not found in template scene!");
    }
}

internal interface ITemplateModifier
{
    string GameObjectName { get; }
    RszGameObject Apply(RszGameObject gameObject);
}