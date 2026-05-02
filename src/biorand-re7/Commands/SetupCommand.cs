using IntelOrca.Biohazard.REE.Package;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Biohazard.BioRand.RE7.Commands;

internal sealed class SetupCommand : AsyncCommand<SetupCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-i|--input")]
        public string? InputPath { get; init; }

        [CommandOption("-o|--output")]
        public string? OutputPath { get; init; }

        [CommandOption("--full")]
        public bool Full { get; init; }
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        if (settings.InputPath == null)
        {
            return ValidationResult.Error($"Input path not specified");
        }
        if (settings.OutputPath == null)
        {
            return ValidationResult.Error($"Output path not specified");
        }
        return base.Validate(context, settings);
    }

    public override Task<int> ExecuteAsync(CommandContext context, Settings settings, CancellationToken token)
    {
        var patternList = settings.Full ? FullPatterns : MiniPatterns;
        var gamePath = settings.InputPath!;
        using var pak = OpenGamePakCollection(gamePath);

        var outputPath = settings.OutputPath!;
        if (outputPath.EndsWith(".pak", StringComparison.OrdinalIgnoreCase))
        {
            var newPak = new PakFileBuilder();
            HarvestFiles(pak, patternList, (path, data) =>
            {
                newPak.AddEntry(path, data);
            });
            newPak.Save(settings.OutputPath!, CompressionKind.Zstd);
        }
        else
        {
            HarvestFiles(pak, patternList, (path, data) =>
            {
                var targetPath = Path.Combine(outputPath, path);
                var targetDir = Path.GetDirectoryName(targetPath)!;
                Directory.CreateDirectory(targetDir);
                File.WriteAllBytes(targetPath, data);
            });
        }
        return Task.FromResult(0);
    }

    private static void HarvestFiles(
        IPakFile pak,
        ImmutableArray<string> patternList,
        Action<string, byte[]> cb
    )
    {
        var pakList = RandomizerExecutor.GetDefaultPakList();
        var patternListRegex = patternList.Select(x => new Regex(x, RegexOptions.IgnoreCase)).ToArray();
        foreach (var path in pakList.Entries)
        {
            if (!patternListRegex.Any(x => x.IsMatch(path)))
                continue;

            var file = pak.GetEntryData(path);
            if (file == null)
            {
                Console.WriteLine("X " + path);
            }
            else
            {
                cb(path, file);
                Console.WriteLine("* " + path);
            }
        }
    }

    private static PakFileCollection OpenGamePakCollection(string gamePath)
    {
        var basePakPath = Path.Combine(gamePath, "re_chunk_000.pak");
        if (!File.Exists(basePakPath))
        {
            throw new FileNotFoundException("Failed to find re_chunk_000.pak.", basePakPath);
        }

        var pakFiles = new List<IPakFile> { new PatchedPakFile(basePakPath) };
        var rootPakPaths = new HashSet<string>(
            Directory.EnumerateFiles(gamePath, "*.pak", SearchOption.TopDirectoryOnly)
                .Select(Path.GetFullPath),
            StringComparer.OrdinalIgnoreCase);

        foreach (var pakPath in Directory
            .EnumerateFiles(gamePath, "*.pak", SearchOption.AllDirectories)
            .Select(Path.GetFullPath)
            .Where(path => !rootPakPaths.Contains(path))
            .Order(StringComparer.OrdinalIgnoreCase))
        {
            pakFiles.Add(new PakFile(pakPath));
        }

        return new PakFileCollection(pakFiles.ToImmutableArray());
    }

    private static readonly ImmutableArray<string> FullPatterns = [
        @"natives/.*\.gui\.\d+",
        @"natives/stm/ch[89]/.*\.aimap\.\d+",
        @"natives/stm/ch[89]/.*\.fsm\.\d+",
        @"natives/stm/ch[89]/.*\.jmap\.\d+",
        @"natives/stm/ch[89]/.*\.mcol\.\d+",
        @"natives/stm/ch[89]/.*\.mdf2\.\d+",
        @"natives/stm/ch[89]/.*\.mesh\.\d+",
        @"natives/stm/ch[89]/.*\.motlist\.\d+",
        @"natives/stm/ch[89]/.*\.rbs\.\d+",
        @"natives/stm/ch[89]/.*\.rdd\.\d+",
        @"natives/stm/ch[89]/.*\.rtex\.\d+",
        @"natives/stm/ch[89]/.*\.tml\.\d+",
        @"natives/.*\.motfsm2\.\d+",
        @"natives/.*\.msg\.\d+",
        @"natives/.*\.pfb\.\d+",
        @"natives/.*\.scn\.\d+",
        @"natives/.*\.user\.\d+",
        @"natives/.*\.uvar\.\d+",
        @"natives/.*\.rcol\.\d+",
        @"natives/stm/sound/resource/snd_container/.*chp[89].*\.wcc\.\d+",
        @"natives/stm/animation/weapon/.*\.motlist\.\d+", // only weapons, otherwise the PAK file size explodes
        @"natives/stm/animation/weapon/.*\.motbank\.\d+"
    ];

    private static readonly ImmutableArray<string> MiniPatterns = [
    ];
}
