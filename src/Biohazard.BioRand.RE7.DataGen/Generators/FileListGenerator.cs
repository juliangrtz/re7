using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using Spectre.Console;
using System.Text;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal sealed class FileListGenerator : IFileGenerator
{
    public string Id => "file-list";
    public bool CopyToDataDirectory => false;

    private readonly PakFile _pakFile = new(EmbeddedData.GetFile("biorand-re7.pak"));
    private readonly PakList _pakList = new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));
    private readonly PakFile _pakFileNonRT = new(EmbeddedData.GetFile("biorand-re7-nonrt.pak"));
    private readonly PakList _pakListNonRT = new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontents.txt.gz"))));

    private static readonly Dictionary<string, (string rt, string nonRt)> _knownPatterns = new()
    {
        { "rcol", (".rcol.20", ".rcol.2") },
        { "prefab", (".user.2", ".pfb.16") },
        { "scene", (".scn.20", ".scn.18") },
        { "message", (".msg.17", ".msg.12") },
        { "motlist", (".motlist.524", ".motlist.60") },
        { "motbank", (".motbank.3", ".motbank.1") },
    };

    public object Generate(GenerateCommand.GenerateSettings settings)
    {
        AnsiConsole.WriteLine("Known patterns: " + string.Join('|', _knownPatterns.Keys));
        var inputRt = AnsiConsole.Ask<string>("Enter a known or custom pattern to filter RT files:");
        var inputNonRt = AnsiConsole.Ask<string>("Enter a known or custom pattern to filter non-RT files:");

        var patternRt = ResolvePattern(inputRt, isRt: true);
        var patternNonRt = ResolvePattern(inputNonRt, isRt: false);
        var rt = CollectPaths(_pakFile, _pakList, patternRt);
        var nonRt = CollectPaths(_pakFileNonRT, _pakListNonRT, patternNonRt);

        return new FileListResult
        {
            RT = rt,
            NonRT = nonRt
        };
    }

    private static string ResolvePattern(string input, bool isRt)
    {
        if (_knownPatterns.TryGetValue(input, out var tuple))
        {
            return isRt ? tuple.rt : tuple.nonRt;
        }

        return input;
    }

    private static List<string> CollectPaths(PakFile pakFile, PakList pakList, string suffix)
    {
        var result = new List<string>();

        foreach (var hash in pakFile.FileHashes)
        {
            var path = pakList.GetPath(hash);
            if (path != null && path.EndsWith(suffix))
            {
                result.Add(path);
            }
        }

        return result;
    }

    private sealed class FileListResult
    {
        public required List<string> RT { get; init; }
        public required List<string> NonRT { get; init; }
    }
}