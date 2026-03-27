using System.Text.RegularExpressions;

namespace Biohazard.BioRand.RE7.Tests;

public class ConfigurationIdUsageTest
{
    private readonly HashSet<string> _definedIds =
        RandomizerExecutor.ConfigurationDefinition.AllItems
            .Where(i => i.Id != null)
            .Select(i => i.Id!)
            .ToHashSet();

    // TODO: Find better way to determine dynamically created IDs
    private static readonly string[] Exclusions =
    [
        "debug-force-reframework",
        "username",
        "special",
        "item-drop-ratio-",
        "item-drop-valuable-",
        "inventory-weapon-",
        "inventory-stack-limit-",
        "weapon-damage-min-",
        "weapon-damage-max-",
        "weapon-ammo-capacity-min-",
        "weapon-ammo-capacity-max-"
    ];

    [Fact]
    public void Test_All_StringId_References_Exist()
    {
        var projectRoot = GetProjectRoot();
        var csFiles = Directory.GetFiles(projectRoot, "*.cs", SearchOption.AllDirectories);
        var configRegex = new Regex("Get(ConfigOption|ValueOrDefault).*\\(\"([a-zA-Z0-9\\-]+)\".*\\)", RegexOptions.Compiled);
        var invalidUsages = new HashSet<string>();

        foreach (var file in csFiles)
        {
            var content = File.ReadAllText(file);
            foreach (Match match in configRegex.Matches(content))
            {
                var value = match.Groups[2].Value;

                if (IsValidId(value))
                    continue;

                invalidUsages.Add(value);
            }
        }

        Assert.True(invalidUsages.Count == 0,
            $"Invalid config ID usages found: {string.Join(", ", invalidUsages)}");
    }

    [Fact]
    public void Test_All_ConfigIds_Are_Referenced()
    {
        var projectRoot = GetProjectRoot();
        var csFiles = Directory.GetFiles(projectRoot, "*.cs", SearchOption.AllDirectories);

        var content = string.Join("\n", csFiles.Select(File.ReadAllText));
        static Regex Regex(string id) => new Regex($"Get(ConfigOption|ValueOrDefault).*\\(\"{id}\".*\\)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        var unused = _definedIds
            .Where(id =>
                !Regex(id).IsMatch(content) &&
                !Exclusions.Any(prefix => id.StartsWith(prefix)))
            .ToList();

        Assert.True(unused.Count == 0,
            $"Unused config IDs: {string.Join(", ", unused)}");
    }

    private bool IsValidId(string value)
    {
        if (_definedIds.Contains(value))
            return true;

        return Exclusions.Any(prefix => value.StartsWith(prefix));
    }

    private string GetProjectRoot()
    {
        var dir = AppContext.BaseDirectory;

        while (dir != null && Directory.GetFiles(dir, "*.sln").Length == 0)
        {
            dir = Directory.GetParent(dir)?.FullName;
        }

        if (dir == null)
            throw new InvalidOperationException("Could not locate BioRand 7 solution root!");

        return dir;
    }
}