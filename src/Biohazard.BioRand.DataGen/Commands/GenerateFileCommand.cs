using Biohazard.BioRand.RE7.DataGen;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
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
            [DefaultValue(new[] { TextOutputFormat.Csv, TextOutputFormat.Json })]
            public TextOutputFormat[] Formats { get; set; } = default!;

            public override ValidationResult Validate()
            {
                if (Generators.Length == 0)
                    return ValidationResult.Error("At least one generator must be specified.");

                return ValidationResult.Success();
            }
        }

        private static readonly ITextFileGenerator[] TextFileGenerators =
        [
            new ItemDefinitionGenerator()
        ];

        public override int Execute(CommandContext context, GenerateSettings settings, CancellationToken token)
        {
            var idSet = new HashSet<string>(settings.Generators, StringComparer.OrdinalIgnoreCase);

            var selected = TextFileGenerators
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
                    foreach (var format in settings.Formats)
                    {
                        var result = generator.Generate(format);
                        var outputPath = $"{generator.Id}.{format.ToString().ToLowerInvariant()}";
                        FileWriter.WriteOutput(outputPath, result);

                        AnsiConsole.MarkupLine(
                            $"[green]✔[/] Generator '[yellow]{generator.Id}[/]' -> {outputPath}");
                    }
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine(
                        $"[red]✖[/] Generator '{generator.Id}' failed: {ex.Message}");
                }
            }

            return 0;
        }
    }
}
