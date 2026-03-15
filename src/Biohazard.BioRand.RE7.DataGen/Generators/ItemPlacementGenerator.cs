using Biohazard.BioRand.RE7.DLC;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Collections.Concurrent;
using System.Text;
using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

/// <summary>
/// TODO: non-RT
/// </summary>
internal class ItemPlacementGenerator : IFileGenerator
{
    public string Id => "item_placements";

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json"));

    private readonly PakFile _pakFile =
        new(EmbeddedData.GetFile("biorand-re7.pak"));

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private List<ItemPlacement> ReadItemPlacements(ulong hash)
    {
        var result = new List<ItemPlacement>();
        var path = _pakList.GetPath(hash)!;
        var scene = new ScnFile(Constants.SceneFileVersionRT, _pakFile.GetEntryData(hash)).ReadScene(_rszRepository);
        scene.VisitGameObjects(gameObject =>
        {
            var itemComponent = gameObject.FindComponent<app.Item>();

            if (itemComponent != null)
            {
                var transformComponent = gameObject.FindComponent<via.Transform>()!;
                var mesh = gameObject.FindComponent("via.render.Mesh");
                var dlc = DlcTypeExtensions.FromPakFileName(path);
                var chapter = dlc == null ? GetChapterFromPath(path) : DlcTypeExtensions.ToChapter(dlc.Value);

                result.Add(new ItemPlacement
                {
                    Id = itemComponent.ItemDataID,
                    Enabled = itemComponent.Enabled,
                    StackNum = itemComponent.ItemStackNum,
                    Position = transformComponent.Position,
                    Rotation = transformComponent.Rotation,
                    Guid = gameObject.Guid,
                    SaveGuid = itemComponent.SaveGUID,
                    EasyNum = itemComponent._DifficultItemNumSetting.EasyNum,
                    HardNum = itemComponent._DifficultItemNumSetting.HardNum,
                    Container = path,
                    GameObjectName = gameObject.Name,
                    Chapter = chapter,
                    Difficulty = GetDifficultyFromPath(path),
                    Mesh = mesh?.Children[2].ToString() ?? "",
                    Material = mesh?.Children[3].ToString() ?? "",
                    Dlc = dlc
                });
            }
        });

        return result;
    }

    private int GetChapterFromPath(string path)
    {
        if (path.Contains("chapter0"))
        {
            return 0;
        }
        else if (path.Contains("chapter1") || path.Contains("c01"))
        {
            return 1;
        }
        // Chapter 2 does not exist...
        else if (path.Contains("chapter3") || path.Contains("c03"))
        {
            return 3;
        }
        else if (path.Contains("chapter4") || path.Contains("c04") || path.Contains("ff050"))
        {
            return 4;
        }
        else if (path.Contains("chapter7") || path.Contains("c07"))
        {
            return 7; // Banned Footage DLCs
        }
        else if (path.Contains("chapter8") || path.Contains("c08"))
        {
            return 8; // Not a Hero DLC
        }
        else if (path.Contains("chapter9") || path.Contains("c09"))
        {
            return 9; // End of Zoe DLC
        }
        else
        {
            return -1;
        }
    }

    private Difficulty? GetDifficultyFromPath(string path)
    {
        if (path.Contains("easy"))
        {
            return Difficulty.Easy;
        }
        else if (path.Contains("normal"))
        {
            return Difficulty.Normal;
        }
        else if (path.Contains("hard"))
        {
            return Difficulty.Madhouse;
        }
        else
        {
            return null;
        }
    }

    private List<ItemPlacement> GetItemPlacements(GenerateSettings settings)
    {
        var result = new ConcurrentBag<ItemPlacement>();

        var relevantHashes = _pakFile.FileHashes
            .Where(hash =>
            {
                var path = _pakList.GetPath(hash);
                return path != null
                       //&& _itemPathPrefixes.Any(prefix => path.StartsWith(prefix))
                       && path.Contains($".scn.{Constants.SceneFileVersionRT}");
            })
            .ToList();

        Parallel.ForEach(relevantHashes, hash =>
        {
            var path = _pakList.GetPath(hash)!;
            var itemPlacements = ReadItemPlacements(hash);

            if (itemPlacements.Count == 0)
            {
                if (settings.Verbose)
                    AnsiConsole.MarkupLine($"[yellow]{path}[/] does not contain item placements.");

                return;
            }

            foreach (var placement in itemPlacements)
                result.Add(placement);

            AnsiConsole.MarkupLine($"[green]Extracted {itemPlacements.Count} item placements from {path}[/].");
        });

        return result.ToList();
    }

    public object Generate(GenerateSettings settings)
    {
        var itemPlacements = GetItemPlacements(settings);
        AnsiConsole.MarkupLine($"[green]Generated {itemPlacements.Count} item placements.[/]");
        return itemPlacements.OrderBy(it => it.Id);
    }
}