using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Biohazard.BioRand.RE7;
using IntelOrca.Biohazard.REE.Package;
using Spectre.Console;
using Spectre.Console.Cli;

namespace BioHazard.BioRand.RE7.Commands {
    internal sealed class SetupCommand : AsyncCommand<SetupCommand.Settings> {
        public sealed class Settings : CommandSettings {
            [CommandOption("-i|--input")]
            public string? InputPath { get; init; }

            [CommandOption("-o|--output")]
            public string? OutputPath { get; init; }

            [CommandOption("--full")]
            public bool Full { get; init; }

            [CommandOption("-r|--raytracing")]
            public bool IsForRaytracingVersion { get; init; }
        }

        public override ValidationResult Validate(CommandContext context, Settings settings) {
            if (settings.InputPath == null) {
                return ValidationResult.Error($"Input path not specified");
            }
            if (settings.OutputPath == null) {
                return ValidationResult.Error($"Output path not specified");
            }
            return base.Validate(context, settings);
        }

        public override Task<int> ExecuteAsync(CommandContext context, Settings settings, CancellationToken token) {
            var patternList = settings.Full ? FullPatterns : MiniPatterns;
            var gamePath = settings.InputPath!;
            var pak = new RePakCollection(gamePath);

            var outputPath = settings.OutputPath!;
            if (outputPath.EndsWith(".pak", StringComparison.OrdinalIgnoreCase)) {
                var newPak = new PakFileBuilder();
                HarvestFiles(pak, patternList, settings.IsForRaytracingVersion, (path, data) => {
                    newPak.AddEntry(path, data);
                });
                newPak.Save(settings.OutputPath!, CompressionKind.Zstd);
            } else {
                HarvestFiles(pak, patternList, settings.IsForRaytracingVersion, (path, data) => {
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
            bool isUsingRaytracingVersion,
            Action<string, byte[]> cb
        ) {
            var pakList = RE7RandomizerExecutor.GetDefaultPakList(isUsingRaytracingVersion);
            var patternListRegex = patternList.Select(x => new Regex(x, RegexOptions.IgnoreCase)).ToArray();
            foreach (var path in pakList.Entries) {
                if (!patternListRegex.Any(x => x.IsMatch(path)))
                    continue;

                var file = pak.GetEntryData(path);
                if (file == null) {
                    Console.WriteLine("X " + path);
                } else {
                    cb(path, file);
                    Console.WriteLine("* " + path);
                }
            }
        }

        private static readonly ImmutableArray<string> FullPatterns = [
            @"natives/.*\.gui\.\d+",
            @"natives/.*\.motfsm2\.\d+",
            @"natives/.*\.msg\.\d+",
            @"natives/.*\.pfb\.\d+",
            @"natives/.*\.scn\.\d+",
            @"natives/.*\.user\.\d+",
            @"natives/.*\.uvar\.\d+"
        ];

        private static readonly ImmutableArray<string> MiniPatterns = [
        ];
    }
}
