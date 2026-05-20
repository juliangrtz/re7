using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using Spectre.Console;
using System.Text;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal sealed class FileListGenerator : IFileGenerator {
    public string Id => "file-list";
    public bool CopyToDataDirectory => false;

    private readonly PakFile _pakFile = Constants.BioRandPakFile;

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private static readonly Dictionary<string, string> _knownPatterns = new(){
        { "rcol", ".rcol.20" },
        { "prefab", ".user.2" },
        { "scene", ".scn.20" },
        { "message", ".msg.17" },
        { "motlist", ".motlist.524" },
        { "motbank", ".motbank.3" },
    };

    public object Generate(GenerateCommand.GenerateSettings settings) {
        AnsiConsole.WriteLine("Known patterns: " + string.Join('|', _knownPatterns.Keys));
        var input = AnsiConsole.Ask<string>("Enter a known or custom pattern to filter files:");
        var pattern = ResolvePattern(input);
        var files = CollectPaths(_pakFile, _pakList, pattern);

        return new FileListResult{
            Files = files
        };
    }

    private static string ResolvePattern(string input) {
        if (_knownPatterns.TryGetValue(input, out var pattern)) {
            return pattern;
        }

        return input;
    }

    private static List<string> CollectPaths(PakFile pakFile, PakList pakList, string suffix) {
        var result = new List<string>();

        foreach (var hash in pakFile.FileHashes) {
            var path = pakList.GetPath(hash);
            if (path != null && path.EndsWith(suffix)) {
                result.Add(path);
            }
        }

        return result;
    }

    private sealed class FileListResult {
        public required List<string> Files { get; init; }
    }
}