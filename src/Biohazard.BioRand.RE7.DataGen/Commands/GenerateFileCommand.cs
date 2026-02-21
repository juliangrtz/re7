using Biohazard.BioRand.RE7.DataGen.Generators;
using Biohazard.BioRand.RE7.Extensions;
using CsvHelper;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;


namespace Biohazard.BioRand.RE7.DataGen.Commands
{
    internal sealed class GenerateCommand : Command<GenerateSettings>
    {
        internal sealed class GenerateSettings : CommandSettings
        {
            [CommandArgument(0, "<generators>")]
            public string[] Generators { get; set; } = default!;

            [CommandOption("--format")]
            [DefaultValue(new[] { OutputFormat.Csv, OutputFormat.Json })]
            public OutputFormat[] Formats { get; set; } = default!;

            [CommandOption("-v|--verbose")]
            public bool Verbose { get; set; } = default!;

            public override ValidationResult Validate()
            {
                if (Generators.Length == 0)
                    return ValidationResult.Error("At least one generator must be specified.");

                return ValidationResult.Success();
            }
        }

        private static readonly IFileGenerator[] _fileGenerators =
        [
            new ItemDefinitionGenerator()
        ];

        private readonly JsonSerializerOptions _serializationOptions = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private static string GetCsv(dynamic data)
        {
            using var writer = new StringWriterWithEncoding(Encoding.UTF8);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(data);
            return writer.ToString();
        }

        public override int Execute(CommandContext context, GenerateSettings settings, CancellationToken token)
        {
            var idSet = new HashSet<string>(settings.Generators, StringComparer.OrdinalIgnoreCase);

            var selected = _fileGenerators
                .Where(gen => idSet.Contains(gen.Id))
                .ToArray();

            if (selected.Length == 0)
            {
                AnsiConsole.MarkupLine("[red]No valid generators selected![/]");
                return -1;
            }

            foreach (var generator in selected)
            {
                try
                {
                    var result = generator.Generate(settings);
                    foreach (var format in settings.Formats)
                    {
                        var outputFileName = $"{generator.Id}.{format.ToString().ToLowerInvariant()}";
                        var output = format switch
                        {
                            OutputFormat.Json => JsonSerializer.Serialize(result, _serializationOptions),
                            OutputFormat.Csv => GetCsv(result),
                            _ => throw new ArgumentException("Unknown output format!"),
                        };

                        if (output != null)
                        {
                            var outputPath = FileWriter.WriteOutput(outputFileName, output);
                            AnsiConsole.MarkupLine(
                                $"[green]Generator '{generator.Id}' (format {format.ToString().ToTitleCase()}) finished: [bold]{Path.GetFullPath(outputPath)}[/][/] "
                            );
                        }
                        else
                        {
                            throw new SerializationException("Unable to serialize data!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]Generator '{generator.Id}' failed: {ex.Message}[/]");
                    return -1;
                }
            }

            return 0;
        }
    }
}
