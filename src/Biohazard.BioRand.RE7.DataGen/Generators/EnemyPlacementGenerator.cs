using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Molded;
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
internal class EnemyPlacementGenerator : IFileGenerator
{
    public string Id => "enemies";
    public bool CopyToDataDirectory => true;

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json"));

    private readonly PakFile _pakFile =
        new(EmbeddedData.GetFile("biorand-re7.pak"));

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private List<EnemyPlacement> ReadEnemyPlacements(ulong hash)
    {
        var result = new List<EnemyPlacement>();
        var path = _pakList.GetPath(hash)!;
        var scene = new ScnFile(FileVersions.SceneFileVersionRT, _pakFile.GetEntryData(hash)).ReadScene(_rszRepository);
        scene.VisitGameObjects(gameObject =>
        {
            var emSpawnInfo = gameObject.FindComponent<app.EnemySpawnInfo>();

            if (emSpawnInfo != null)
            {
                var transformComponent = gameObject.FindComponent<via.Transform>()!;
                var dlc = DlcTypeExtensions.FromPakFileName(path);
                var chapter = dlc == null ? GetChapterFromPath(path) : DlcTypeExtensions.ToChapter(dlc.Value);

                if(!Enum.TryParse(emSpawnInfo.UnitAlias, true, out EnemyID enemyId))
                {
                    AnsiConsole.MarkupLine($"[yellow]Encountered weird Enemy ID {emSpawnInfo.UnitAlias} in {path}[/].");
                    return;
                }

                result.Add(new EnemyPlacement
                {
                    EnemyID = enemyId,
                    Chapter = chapter,
                    Dlc = dlc,
                    Comment = null,
                    Name = "TODO",
                    Difficulty = GetDifficultyFromPath(path),
                    Enabled = emSpawnInfo.Enabled,
                    HatType = Enums.app.MoldedActionController.ExtraHatUnit.Type.NoUse, // TODO
                    IsExtra = false,
                    IsForceSpawn = emSpawnInfo.IsForceSpawn,
                    MoldedBodyPartMask = emSpawnInfo.BackupParam.moldedCommon.ToMask(),
                    PosX = transformComponent.Position.X,
                    PosY = transformComponent.Position.Y,
                    PosZ = transformComponent.Position.Z,
                    RotX = transformComponent.Rotation.X,
                    RotY = transformComponent.Rotation.Y,
                    RotZ = transformComponent.Rotation.Z,
                    RotW = transformComponent.Rotation.W,
                    SceneFile = path,
                    SpawnInfoGuid = emSpawnInfo.MyGUID,
                    Tags = [],
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

    private List<EnemyPlacement> GetItemPlacements(GenerateSettings settings)
    {
        var result = new ConcurrentBag<EnemyPlacement>();

        var relevantHashes = _pakFile.FileHashes
            .Where(hash =>
            {
                var path = _pakList.GetPath(hash);
                return path != null
                       //&& _itemPathPrefixes.Any(prefix => path.StartsWith(prefix))
                       && path.EndsWith($".scn.{FileVersions.SceneFileVersionRT}");
            })
            .ToList();

        Parallel.ForEach(relevantHashes, hash =>
        {
            var path = _pakList.GetPath(hash)!;
            var itemPlacements = ReadEnemyPlacements(hash);

            if (itemPlacements.Count == 0)
            {
                return;
            }

            foreach (var placement in itemPlacements)
                result.Add(placement);

            AnsiConsole.MarkupLine($"[green]Extracted {itemPlacements.Count} enemy placements from {path}[/].");
        });

        return result.ToList();
    }

    public object Generate(GenerateSettings settings)
    {
        var itemPlacements = GetItemPlacements(settings);
        AnsiConsole.MarkupLine($"[green]Generated {itemPlacements.Count} enemy placements.[/]");
        return itemPlacements.OrderBy(it => it.Chapter);
    }
}