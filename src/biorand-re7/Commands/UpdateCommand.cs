using Biohazard.BioRand.RE7.Serialization;
using Spectre.Console;
using Spectre.Console.Cli;

namespace BioHazard.BioRand.RE7.Commands;

internal sealed class UpdateCommand : AsyncCommand<UpdateCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        // No arguments or options required
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings, CancellationToken token)
    {
        var solutionDir = FindSolutionDirectory();
        if (solutionDir == null)
        {
            AnsiConsole.MarkupLine("[red]Project directory not found.[/]");
            return 1;
        }

        var dataDir = Path.Combine(solutionDir, "src", "BioHazard.BioRand.RE7", "_Data");

        var dynamicData = new DynamicData(download: true);
        foreach (var dataName in Enum.GetValues<DynamicDataName>())
        {
            var filename = DynamicData.GetFileName(dataName)!;

            var destinationPath = Path.Combine(dataDir, filename);
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
            try
            {
                var fileBytes = dynamicData.GetData(dataName)!;

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

    private static string? FindSolutionDirectory()
    {
        var dir = Directory.GetCurrentDirectory();
        while (dir != null)
        {
            if (File.Exists(Path.Combine(dir, "biorand-re7.sln")))
            {
                return dir;
            }
            dir = Path.GetDirectoryName(dir);
        }
        return null;
    }
}