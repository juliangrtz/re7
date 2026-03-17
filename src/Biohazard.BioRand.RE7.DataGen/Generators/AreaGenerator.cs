using Biohazard.BioRand.RE7.Area;
using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.DLC;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Collections.Concurrent;
using System.Text;
using System.Text.RegularExpressions;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class AreaGenerator : IFileGenerator
{
    public string Id => "areas";

    private readonly PakFile _pakFile =
        new(EmbeddedData.GetFile("biorand-re7.pak"));

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private readonly List<string> _pathExclusions = [
        "/alphatest/",
        "/vfx/",
        "/animation/",
        "/light/",
        "lightset",
        "/fsm/",
        "/levelfsm/",
        "/ui/",
        "/sound/",
        "/vr/",
        "/install/",
        "/preloading/",
        "/loadtemp/",
        "/mainmenu/",
        "cubemap"
    ];

    private readonly Regex chapterRegex = new Regex(@"(chapter|ch|c)[_-]*(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly Regex itemRegex = new Regex(@"/items/|/itemsettings/|/itemset/|_item_", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly Regex enemyRegex = new Regex(@"enemy|enemies", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private int? ExtractChapter(string path, GenerateCommand.GenerateSettings settings)
    {
        var match = chapterRegex.Match(path);
        if (match.Success)
        {
            if (int.TryParse(match.Groups[2].Value, out var chapter))
            {
                if (chapter is >= 0 and <= 9)
                {
#if DEBUG
                    AnsiConsole.MarkupLine($"[grey]Chapter match:[/] '{match.Value}' (chapter {chapter}) in '{path}'");
#endif
                    return chapter;
                }
                else return null;
            }
            else return null;
        }
        else
        {
            if (settings.Verbose)
            {
                AnsiConsole.MarkupLine($"[yellow]Failed to extract chapter for path '{path}'[/]!");
            }

            return null;
        }
    }


    private Difficulty? ExtractDifficulty(string path)
    {
        if (path.EndsWith("easy.scn.20") || path.EndsWith("casual.scn.20"))
        {
            return Difficulty.Easy;
        }
        else if (path.EndsWith("normal.scn.20"))
        {
            return Difficulty.Normal;
        }
        else if (path.EndsWith("hard.scn.20"))
        {
            return Difficulty.Madhouse;
        }
        else
        {
            return null;
        }
    }

    private AreaKind ExtractKind(string path)
    {
        if (itemRegex.IsMatch(path))
        {
            return AreaKind.Item;
        }
        else if (enemyRegex.IsMatch(path))
        {
            return AreaKind.Enemy;
        }
        else
        {
            return AreaKind.General;
        }
    }

    public object Generate(GenerateCommand.GenerateSettings settings)
    {
        var result = new ConcurrentBag<AreaDefinition>();

        var relevantHashes = _pakFile.FileHashes
            .Where(hash =>
            {
                var path = _pakList.GetPath(hash);
                return path != null && path.EndsWith($".scn.{FileVersions.SceneFileVersionRT}");
            })
            .ToList();

        Parallel.ForEach(relevantHashes, hash =>
        {
            var path = _pakList.GetPath(hash)!;
            if (_pathExclusions.Any(ex => path.Contains(ex, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            var dlc = DlcTypeExtensions.FromPakFileName(path);
            var chapter = dlc == null ? ExtractChapter(path, settings) : null;
            var kind = ExtractKind(path);
            var difficulty = ExtractDifficulty(path);

            if (chapter == null && dlc == null)
            {
                return;
            }

            result.Add(new AreaDefinition
            {
                Path = path,
                Chapter = chapter,
                Description = dlc == null ? "" : null,
                Dlc = dlc,
                OnlyDifficulty = difficulty,
                Kind = kind
            });
        });

        return result.ToList().OrderBy(area => area.Chapter ?? int.MaxValue);
    }
}
