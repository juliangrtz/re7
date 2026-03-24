using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Services;

internal class TemplateService
{
    private const string TemplateSceneFileName = "template.scn";
    private readonly ScnFile _templateScnFile;
    private readonly RszScene _scene;

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
    }


    public RszGameObject GetObject(string name)
        => _scene.FindGameObject(name) ?? throw new Exception($"Object with name {name} not found in template scene!");

    public RszGameObject GetObject(Guid guid)
    => _scene.FindGameObject(guid) ?? throw new Exception($"Object with GUID {guid} not found in template scene!");
}
