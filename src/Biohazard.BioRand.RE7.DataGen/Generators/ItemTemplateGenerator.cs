using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

/// <summary>
/// TODO non-RT
/// </summary>
internal class ItemTemplateGenerator : IFileGenerator
{
    public string Id => "item_templates";

    public bool CopyToDataDirectory => false;

    public string FileName => "item_templates.scn.20";

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json"));

    private readonly PakFile _pakFile =
        new(EmbeddedData.GetFile("biorand-re7.pak"));

    private readonly JsonSerializerOptions _serializationOptions = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    private byte[] GetItemTemplateScene(GenerateSettings settings)
    {
        var areas = JsonSerializer.Deserialize<List<AreaDefinition>>(EmbeddedData.GetFile("areas.json"), _serializationOptions)!;
        var templates = new Dictionary<string, RszGameObject>(); // item id -> GameObject

        foreach (var area in areas)
        {
            var scene = new ScnFile(FileVersions.SceneFileVersionRT, _pakFile.GetEntryData(area.Path)).ReadScene(_rszRepository);

            scene.VisitGameObjects(gameObject =>
            {
                var item = gameObject.FindComponent<app.Item>();
                var melee = gameObject.FindComponent<app.Weapon>();
                var gun = gameObject.FindComponent<app.WeaponGun>();

                if (item != null)
                {
                    templates.TryAdd(item.ItemDataID, gameObject);
                }
            });
        }

        var resultSceneBuilder = new ScnFile(FileVersions.SceneFileVersionRT, _pakFile.GetEntryData(areas[0].Path)).ToBuilder(_rszRepository);
        resultSceneBuilder.Scene = resultSceneBuilder.Scene.WithChildren([]);
        foreach (var (id, go) in templates.OrderBy(t => t.Key))
        {
            var newName = $"ItemTemplate_{id}"; // TODO: Somehow save original GO name as well
            resultSceneBuilder.Scene = resultSceneBuilder.Scene.Add(go.WithName(newName));
        }

        var built = resultSceneBuilder.AddMissingResources().Build();
        return built.Data.ToArray();
    }

    public object Generate(GenerateSettings settings)
    {
        var scene = GetItemTemplateScene(settings);
        AnsiConsole.MarkupLine($"[green]Generated item template scene.[/]");
        return scene;
    }
}
