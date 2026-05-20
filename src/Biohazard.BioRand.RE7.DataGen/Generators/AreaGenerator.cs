using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Collections.Concurrent;
using System.Text;
using System.Text.RegularExpressions;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class AreaGenerator : IFileGenerator {
    public string Id => "areas";
    public bool CopyToDataDirectory => true;

    private readonly PakFile _pakFile = Constants.BioRandPakFile;

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJsonGz(EmbeddedData.GetFile("rszre7rt.json.gz"));

    private readonly Lazy<Dictionary<string, string>> _csvDescriptions;
    private readonly Lazy<AreaDescriptionProvider> _descriptionProvider;

    private readonly List<string> _pathExclusions =[
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

    private readonly Regex chapterRegex =
        new(@"(chapter|ch|c)[_-]*(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private readonly Regex foundFootageRegex =
        new(@"(?:^|[\/_])ff(\d{3})(?:[\/_\.]|$)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private readonly Regex itemRegex = new("/items/|/itemsettings/|/itemset/|_item_",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private readonly Regex enemyRegex = new("enemy|enemies", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public AreaGenerator() {
        _csvDescriptions = new Lazy<Dictionary<string, string>>(LoadCsvDescriptions);
        _descriptionProvider =
            new Lazy<AreaDescriptionProvider>(() => new AreaDescriptionProvider(_pakFile, _pakList, _rszRepository));
    }

    private int? ExtractChapter(string path, AreaKind kind, GenerateCommand.GenerateSettings settings) {
        var match = chapterRegex.Match(path);
        if (match.Success) {
            if (int.TryParse(match.Groups[2].Value, out var chapter)) {
                if (chapter is >= 0 and <= 9) {
#if DEBUG
                    AnsiConsole.MarkupLine($"[grey]Chapter match:[/] '{match.Value}' (chapter {chapter}) in '{path}'");
#endif
                    return chapter;
                } else return null;
            } else return null;
        }

        var foundFootageChapter = kind is AreaKind.Item or AreaKind.Enemy
            ? ExtractFoundFootageChapter(path)
            : null;
        if (foundFootageChapter != null) {
#if DEBUG
            AnsiConsole.MarkupLine($"[grey]Found footage chapter match:[/] chapter {foundFootageChapter} in '{path}'");
#endif
            return foundFootageChapter;
        }

        if (settings.Verbose) {
            AnsiConsole.MarkupLine($"[yellow]Failed to extract chapter for path '{path}'[/]!");
        }

        return null;
    }

    private int? ExtractFoundFootageChapter(string path) {
        var match = foundFootageRegex.Match(path);
        if (!match.Success || !int.TryParse(match.Groups[1].Value, out var footageId)) {
            return null;
        }

        // FF050 item/enemy scene paths omit c04/chapter4 but are part of the main-game ship section.
        return footageId switch{
            50 => 4,
            _ => null
        };
    }


    private Difficulty? ExtractDifficulty(string path) {
        if (path.EndsWith("easy.scn.20") || path.EndsWith("casual.scn.20")) {
            return Difficulty.Easy;
        } else if (path.EndsWith("normal.scn.20")) {
            return Difficulty.Normal;
        } else if (path.EndsWith("hard.scn.20")) {
            return Difficulty.Madhouse;
        } else {
            return null;
        }
    }

    private AreaKind ExtractKind(string path) {
        if (itemRegex.IsMatch(path)) {
            return AreaKind.Item;
        } else if (enemyRegex.IsMatch(path)) {
            return AreaKind.Enemy;
        } else {
            return AreaKind.General;
        }
    }

    public object Generate(GenerateCommand.GenerateSettings settings) {
        var result = new ConcurrentBag<AreaDefinition>();

        var relevantHashes = _pakFile.FileHashes
            .Where(hash => {
                var path = _pakList.GetPath(hash);
                return path != null && path.EndsWith($".scn.{FileVersions.SceneFileVersion}");
            })
            .ToList();

        Parallel.ForEach(relevantHashes, hash => {
            var path = _pakList.GetPath(hash)!;
            if (_pathExclusions.Any(ex => path.Contains(ex, StringComparison.OrdinalIgnoreCase))) {
                return;
            }

            var dlc = DlcTypeExtensions.FromPakFileName(path);
            var kind = ExtractKind(path);
            var chapter = dlc == null ? ExtractChapter(path, kind, settings) : null;
            var difficulty = ExtractDifficulty(path);

            if (chapter == null && dlc == null) {
                return;
            }

            result.Add(new AreaDefinition{
                Path = path,
                Chapter = chapter,
                Description = ResolveDescription(path, chapter, dlc, kind),
                Dlc = dlc,
                OnlyDifficulty = difficulty,
                Kind = kind
            });
        });

        return result
            .OrderBy(area => area.Chapter ?? int.MaxValue)
            .ThenBy(area => area.Dlc?.ToString() ?? "")
            .ThenBy(area => area.Kind)
            .ThenBy(area => area.Path, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private string? ResolveDescription(string path, int? chapter, DlcType? dlc, AreaKind kind) {
        if (_csvDescriptions.Value.TryGetValue(path, out var csvDescription)) {
            return csvDescription;
        }

        return _descriptionProvider.Value.Describe(path, chapter, dlc, kind);
    }

    private static Dictionary<string, string> LoadCsvDescriptions() {
        var csv = TryReadSourceDataFile("areas.csv") ?? EmbeddedData.TryGetFile("areas.csv");
        if (csv == null)
            return [];

        return Csv.Deserialize<AreaDefinition>(csv)
            .Where(area => !string.IsNullOrWhiteSpace(area.Path) && !string.IsNullOrWhiteSpace(area.Description))
            .GroupBy(area => area.Path, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                group => group.Key,
                group => NormalizeDescription(group.First().Description!),
                StringComparer.OrdinalIgnoreCase);
    }

    private static byte[]? TryReadSourceDataFile(string name) {
        foreach (var root in new[]{ AppContext.BaseDirectory, Environment.CurrentDirectory }) {
            var current = new DirectoryInfo(root);
            while (current != null) {
                var sourcePath = Path.Combine(
                    current.FullName,
                    "src",
                    "Biohazard.BioRand.RE7",
                    EmbeddedData.DataDirectoryName,
                    name);
                if (File.Exists(sourcePath)) {
                    return File.ReadAllBytes(sourcePath);
                }

                sourcePath = Path.Combine(
                    current.FullName,
                    "Biohazard.BioRand.RE7",
                    EmbeddedData.DataDirectoryName,
                    name);
                if (File.Exists(sourcePath)) {
                    return File.ReadAllBytes(sourcePath);
                }

                current = current.Parent;
            }
        }

        return null;
    }

    private static string NormalizeDescription(string description) {
        var parts = description
            .Split('/', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return parts.Length == 0 ? description.Trim() : string.Join(" / ", parts);
    }
}