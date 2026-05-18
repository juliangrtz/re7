using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Extensions;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class GameObjectTemplateGenerator : IFileGenerator
{
    public string Id => "templates";

    public bool CopyToDataDirectory => false;

    public string FileName => "template.scn.20";

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json.gz").Ungzip());

    private readonly PakFile _pakFile = Constants.BioRandPakFile;

    private readonly JsonSerializerOptions _serializationOptions = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public RszFolder CreateFolder(string name, string tag = "") =>
        new RszFolder(_rszRepository
                .Create("via.Folder")
                    .Set("Name", name)
                    .Set("Tag", tag)
                    .Set("Update", true)
                    .Set("Draw", true)
                    .Set("Standby", true), []
        );

    private ScnFile BuildScene()
    {
        var areas = JsonSerializer.Deserialize<List<AreaDefinition>>(EmbeddedData.GetFile("areas.json"), _serializationOptions)!;
        var itemTemplates = new Dictionary<string, RszGameObject>(); // item id -> GameObject

        foreach (var area in areas)
        {
            var scene = new ScnFile(FileVersions.SceneFileVersion, _pakFile.GetEntryData(area.Path)).ReadScene(_rszRepository);

            scene.VisitGameObjects(gameObject =>
            {
                var item = gameObject.FindComponent<app.Item>();
                var melee = gameObject.FindComponent<app.Weapon>();
                var gun = gameObject.FindComponent<app.WeaponGun>();

                if (item != null)
                {
                    itemTemplates.TryAdd(item.ItemDataID, gameObject);
                }
            });
        }

        var resultSceneBuilder = new ScnFile(FileVersions.SceneFileVersion, _pakFile.GetEntryData(areas[0].Path)).ToBuilder(_rszRepository);
        resultSceneBuilder.Scene = resultSceneBuilder.Scene.WithChildren([]);

        // Items
        var itemTemplatesFolder = CreateFolder("ItemTemplates");
        foreach (var (id, go) in itemTemplates.OrderBy(t => t.Key))
        {
            var enrichedGo = NormalizeItemTemplateInteractions(go)
                .WithSettings(go.Settings
                    .Set("Name", $"ItemTemplate_{id}")
                    .Set("Tag", go.Name)
                    .Set("Update", true)
                    .Set("Draw", true)
                );
            itemTemplatesFolder = itemTemplatesFolder.Add(enrichedGo);
        }
        resultSceneBuilder.Scene = resultSceneBuilder.Scene.Add(itemTemplatesFolder);

        var built = resultSceneBuilder.AddMissingResources().Build();
        return built;
    }

    private static RszGameObject NormalizeItemTemplateInteractions(RszGameObject gameObject)
        => gameObject
            .PreparePickupInteractionsForPlacement()
            .PrepareWeaponPickupInteractionGameObjects();

    public object Generate(GenerateSettings settings)
    {
        var scene = BuildScene();
        var goCount = 0;
        scene.ReadScene(_rszRepository).VisitGameObjects(go =>
        {
            goCount++;
        });
        AnsiConsole.MarkupLine($"[green]Generated GameObject template scene with {goCount} objects.[/]");
        return scene.Data.ToArray();
    }
}
