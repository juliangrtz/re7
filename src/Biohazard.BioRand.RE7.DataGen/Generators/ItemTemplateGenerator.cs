using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class GameObjectTemplateGenerator : IFileGenerator
{
    public string Id => "templates";

    public bool CopyToDataDirectory => true;

    public string FileName => "template.scn.20";

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json.gz").Ungzip());

    private readonly PakFile _pakFile = Constants.BioRandPakFile;

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

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

    private static readonly string[] _enemyRootComponentSuffixes =
    [
        "ActionController",
        "DamageController",
        "Order",
        "Status",
        "Think"
    ];

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
            var enrichedGo = go
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

    private ScnFile ExtendExistingTemplateScene(GenerateSettings settings)
    {
        var resultSceneBuilder = new ScnFile(FileVersions.SceneFileVersion, EmbeddedData.GetFile(FileName))
            .ToBuilder(_rszRepository);
        var scene = resultSceneBuilder.Scene;
        var sourceMap = FindDlcEnemySources(settings);
        var addedTemplates = new List<string>();
        var addedSpawnInfos = new List<string>();

        foreach (var source in sourceMap.Values.OrderBy(source => source.Enemy.EnemyAlias, StringComparer.Ordinal))
        {
            var enemy = source.Enemy;
            var enemyAlias = enemy.EnemyAlias;

            if (scene.FindGameObject($"EnemyTemplate_{enemyAlias}") == null)
            {
                if (source.TemplateGameObject == null)
                {
                    AnsiConsole.MarkupLine(
                        $"[yellow]Missing DLC enemy template source for {Markup.Escape(enemy.Name)} ({enemyAlias}).[/]");
                }
                else
                {
                    scene = AddToRootFolder(
                        scene,
                        "EnemyTemplates",
                        CreateTemplateGameObject(source.TemplateGameObject, $"EnemyTemplate_{enemyAlias}", $"DlcEnemyTemplate/{enemyAlias}"));
                    addedTemplates.Add(enemyAlias);
                }
            }

            if (enemy.UsesEnemyGenerator && scene.FindGameObject($"EnemySpawnInfo_{enemyAlias}") == null)
            {
                if (source.SpawnInfoGameObject == null)
                {
                    AnsiConsole.MarkupLine(
                        $"[yellow]Missing DLC enemy spawn-info source for {Markup.Escape(enemy.Name)} ({enemyAlias}).[/]");
                }
                else
                {
                    scene = AddToRootFolder(
                        scene,
                        "EnemySpawnInfos",
                        CreateTemplateGameObject(source.SpawnInfoGameObject, $"EnemySpawnInfo_{enemyAlias}", $"DlcEnemySpawnInfo/{enemyAlias}"));
                    addedSpawnInfos.Add(enemyAlias);
                }
            }
        }

        resultSceneBuilder.Scene = scene;
        var built = resultSceneBuilder.AddMissingResources().Build();

        if (addedTemplates.Count != 0)
        {
            AnsiConsole.MarkupLine($"[green]Added DLC enemy templates:[/] {string.Join(", ", addedTemplates)}");
        }

        if (addedSpawnInfos.Count != 0)
        {
            AnsiConsole.MarkupLine($"[green]Added DLC enemy spawn infos:[/] {string.Join(", ", addedSpawnInfos)}");
        }

        return built;
    }

    private Dictionary<string, DlcEnemyTemplateSource> FindDlcEnemySources(GenerateSettings settings)
    {
        var result = EnemyDefinitions.Instance.All
            .Where(enemy => enemy.IsDlc)
            .ToDictionary(
                enemy => enemy.EnemyAlias,
                enemy => new DlcEnemyTemplateSource(enemy),
                StringComparer.OrdinalIgnoreCase);

        var sceneHashes = _pakFile.FileHashes
            .Select(hash => new { Hash = hash, Path = _pakList.GetPath(hash) })
            .Where(entry => entry.Path?.EndsWith($".scn.{FileVersions.SceneFileVersion}", StringComparison.OrdinalIgnoreCase) == true &&
                            (entry.Path.Contains("/ch8/", StringComparison.OrdinalIgnoreCase) ||
                             entry.Path.Contains("/ch9/", StringComparison.OrdinalIgnoreCase)))
            .OrderBy(entry => entry.Path, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        foreach (var entry in sceneHashes)
        {
            RszScene sourceScene;
            try
            {
                sourceScene = new ScnFile(FileVersions.SceneFileVersion, _pakFile.GetEntryData(entry.Hash))
                    .ReadScene(_rszRepository);
            }
            catch (Exception ex)
            {
                if (settings.Verbose)
                {
                    AnsiConsole.MarkupLine(
                        $"[yellow]Skipping scene {Markup.Escape(entry.Path!)}: {Markup.Escape(ex.Message)}[/]");
                }
                continue;
            }

            sourceScene.VisitGameObjects(gameObject =>
            {
                foreach (var source in result.Values)
                {
                    if (source.TemplateGameObject == null && IsEnemyRootCandidate(gameObject, source.Enemy))
                    {
                        source.TemplateGameObject = gameObject;
                        source.TemplateSourcePath = entry.Path;
                    }

                    if (source.SpawnInfoGameObject == null && IsSpawnInfoCandidate(gameObject, source.Enemy))
                    {
                        source.SpawnInfoGameObject = gameObject;
                        source.SpawnInfoSourcePath = entry.Path;
                    }
                }
            });
        }

        if (settings.Verbose)
        {
            foreach (var source in result.Values.OrderBy(source => source.Enemy.EnemyAlias, StringComparer.Ordinal))
            {
                AnsiConsole.MarkupLine(
                    $"[grey]{source.Enemy.EnemyAlias}: template={Markup.Escape(source.TemplateSourcePath ?? "<missing>")}, spawnInfo={Markup.Escape(source.SpawnInfoSourcePath ?? "<missing>")}[/]");
            }
        }

        return result;
    }

    private static bool IsEnemyRootCandidate(RszGameObject gameObject, IEnemyDefinition enemy)
    {
        if (!IsEnemyAliasCandidate(gameObject, enemy.EnemyAlias))
        {
            return false;
        }

        if (gameObject.FindComponent("via.render.Mesh") == null)
            return false;

        var componentPrefix = GetDlcEnemyComponentPrefix(enemy);
        return gameObject.Components
            .Select(component => component.Type.Name)
            .Count(componentName =>
                componentName.StartsWith(componentPrefix, StringComparison.Ordinal) &&
                _enemyRootComponentSuffixes.Any(suffix => componentName.EndsWith(suffix, StringComparison.Ordinal))) >= 2;
    }

    private static bool IsSpawnInfoCandidate(RszGameObject gameObject, IEnemyDefinition enemy)
    {
        var spawnInfo = EnemySpawnInfoComponents.FindSpawnInfo(gameObject);
        return enemy.SpawnOptionType != null &&
               spawnInfo?.UnitAlias.Equals(enemy.EnemyAlias, StringComparison.OrdinalIgnoreCase) == true &&
               gameObject.Components.Any(component => component.Type.Name == enemy.SpawnOptionType);
    }

    private static string GetDlcEnemyComponentPrefix(IEnemyDefinition enemy)
    {
        if (enemy.TemplateComponentPrefix != null)
        {
            return enemy.TemplateComponentPrefix;
        }

        return enemy.SpawnOptionType switch
        {
            { } spawnOptionType when spawnOptionType.Contains(".CH8", StringComparison.Ordinal) => $"app.CH8{enemy.EnemyAlias}",
            { } spawnOptionType when spawnOptionType.Contains(".CH9", StringComparison.Ordinal) => $"app.CH9{enemy.EnemyAlias}",
            _ => $"app.{enemy.EnemyAlias}"
        };
    }

    private static bool IsEnemyAliasCandidate(RszGameObject gameObject, string enemyAlias)
    {
        if (gameObject.Name.Equals(enemyAlias, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return gameObject.Prefab?.Replace('\\', '/').EndsWith($"/{enemyAlias}.pfb", StringComparison.OrdinalIgnoreCase) == true;
    }

    private RszScene AddToRootFolder(RszScene scene, string folderName, RszGameObject gameObject)
    {
        var children = scene.Children.ToBuilder();
        for (var i = 0; i < children.Count; i++)
        {
            if (children[i] is RszFolder folder && folder.Name == folderName)
            {
                children[i] = folder.Add(gameObject);
                return scene.WithChildren(children.ToImmutable());
            }
        }

        children.Add(CreateFolder(folderName).Add(gameObject));
        return scene.WithChildren(children.ToImmutable());
    }

    private static RszGameObject CreateTemplateGameObject(
        RszGameObject sourceGameObject,
        string templateName,
        string guidSeed)
    {
        var clone = CloneGameObject(sourceGameObject, guidSeed);
        return clone.WithSettings(clone.Settings
            .Set("Name", templateName)
            .Set("Tag", sourceGameObject.Name)
            .Set("Update", true)
            .Set("Draw", true));
    }

    private static RszGameObject CloneGameObject(RszGameObject rootGameObject, string guidSeed)
    {
        var guidMap = new Dictionary<Guid, Guid>();
        var index = 0;
        var root = rootGameObject.VisitGameObjects(gameObject =>
        {
            var newGuid = CreateDeterministicGuid($"{guidSeed}/{index++}/{gameObject.Guid:N}");
            guidMap[gameObject.Guid] = newGuid;
            return gameObject.WithGuid(newGuid);
        });

        return ReplaceGameObjectRefs(root, guidMap);
    }

    private static Guid CreateDeterministicGuid(string seed)
    {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(seed));
        return new Guid(hash);
    }

    private static RszGameObject ReplaceGameObjectRefs(
        RszGameObject gameObject,
        Dictionary<Guid, Guid> guidMap)
    {
        return gameObject.Visit(node =>
        {
            if (node is RszValueNode valueNode && valueNode.Type == RszFieldType.GameObjectRef)
            {
                var refGuid = RszSerializer.Deserialize<Guid>(valueNode);
                if (guidMap.TryGetValue(refGuid, out var newGuid))
                {
                    return RszSerializer.Serialize(RszFieldType.GameObjectRef, newGuid);
                }
            }

            return node;
        });
    }

    public object Generate(GenerateSettings settings)
    {
        // The committed template carries curated non-item objects too; extend it
        // instead of replacing it with the item-only scene this generator started as.
        var scene = ExtendExistingTemplateScene(settings);
        var goCount = 0;
        scene.ReadScene(_rszRepository).VisitGameObjects(go =>
        {
            goCount++;
        });
        AnsiConsole.MarkupLine($"[green]Generated GameObject template scene with {goCount} objects.[/]");
        return scene.Data.ToArray();
    }

    private sealed class DlcEnemyTemplateSource(IEnemyDefinition enemy)
    {
        public IEnemyDefinition Enemy { get; } = enemy;
        public RszGameObject? TemplateGameObject { get; set; }
        public string? TemplateSourcePath { get; set; }
        public RszGameObject? SpawnInfoGameObject { get; set; }
        public string? SpawnInfoSourcePath { get; set; }
    }
}
