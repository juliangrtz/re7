using Biohazard.BioRand.RE7.Serialization;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Biohazard.BioRand.RE7.Commands;

internal sealed class UpdateCommand : AsyncCommand<UpdateCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        // No arguments or options required
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings, CancellationToken token)
    {
        var rootDir = FindRootDirectory();
        if (rootDir == null)
        {
            AnsiConsole.MarkupLine("[red]Project root directory not found.[/]");
            return 1;
        }

        var dataDir = Path.Combine(rootDir, "BioHazard.BioRand.RE7", "_Data");

        var dynamicData = new DynamicData(download: true);
        foreach (var dataName in Enum.GetValues<DynamicDataName>())
        {
            var filename = DynamicData.GetFileName(dataName)!;

            var destinationPath = Path.Combine(dataDir, filename);
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
            try
            {
                var fileBytes = dynamicData.GetData(dataName)!;

                if (fileBytes.Length == 0)
                {
                    AnsiConsole.MarkupLineInterpolated($"[yellow]Skipped empty file {destinationPath} (0 bytes)[/]");
                    continue;
                }

                await File.WriteAllBytesAsync(destinationPath, fileBytes);
                AnsiConsole.MarkupLineInterpolated($"[green]Downloaded and overwrote: {destinationPath} ({fileBytes.Length} bytes)[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLineInterpolated($"[red]Failed to update {filename}: {ex.Message}[/]");
            }
        }

        return 0;
    }

    private static string? FindRootDirectory()
    {
        var dir = Directory.GetCurrentDirectory();
        while (dir != null)
        {
            if (dir.EndsWith("src"))
            {
                return dir;
            }
            dir = Path.GetDirectoryName(dir);
        }
        return null;
    }
}