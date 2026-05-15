using System.Text.RegularExpressions;

using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Impl;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Modifiers;
using Biohazard.BioRand.RE7.Weapons;

namespace Biohazard.BioRand.RE7.Tests;

public class ConfigurationIdUsageTest
{
    private const string ConfigReadMethodPattern =
        @"(?:Get(?:ConfigOption|ValueOrDefault)|Read(?:OrDefault|EnemyDropConfigOrDefault))";

    private readonly HashSet<string> _definedIds =
        RandomizerExecutor.ConfigurationDefinition.AllItems
            .Where(i => i.Id != null)
            .Select(i => i.Id!)
            .ToHashSet(StringComparer.Ordinal);

    private static readonly HashSet<string> RuntimeConfigIds = new(StringComparer.Ordinal)
    {
        "username",
        "special",
        "tags",
    };

    private static readonly HashSet<string> IndirectlyReferencedConfigIds = new(StringComparer.Ordinal)
    {
        "debug-force-reframework",
        EnemyModifier.EnemyForceTargetingProbabilityConfigKey,
    };

    private static readonly Lazy<HashSet<string>> GeneratedConfigIds = new(CreateGeneratedConfigIds);

    [Fact]
    public void Test_All_StringId_References_Exist()
    {
        var projectRoot = GetProjectRoot();
        var csFiles = Directory.GetFiles(projectRoot, "*.cs", SearchOption.AllDirectories);
        var configRegex = new Regex(
            $"{ConfigReadMethodPattern}(?:<[^>]+>)?\\s*\\(\\s*\"([a-zA-Z0-9\\-]+)\"",
            RegexOptions.Compiled);
        var invalidUsages = new HashSet<string>();

        foreach (var file in csFiles)
        {
            var content = File.ReadAllText(file);
            foreach (Match match in configRegex.Matches(content))
            {
                var value = match.Groups[1].Value;

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
        static Regex UsageRegex(string id) => new(
            $"{ConfigReadMethodPattern}(?:<[^>]+>)?\\s*\\(\\s*\"{Regex.Escape(id)}\"",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        var unused = _definedIds
            .Where(id =>
                !UsageRegex(id).IsMatch(content) &&
                !GeneratedConfigIds.Value.Contains(id) &&
                !IndirectlyReferencedConfigIds.Contains(id))
            .ToList();

        Assert.True(unused.Count == 0,
            $"Unused config IDs: {string.Join(", ", unused)}");
    }

    private bool IsValidId(string value)
    {
        if (_definedIds.Contains(value))
            return true;

        return RuntimeConfigIds.Contains(value) ||
            GeneratedConfigIds.Value.Contains(value);
    }

    private static HashSet<string> CreateGeneratedConfigIds()
    {
        var ids = new HashSet<string>(StringComparer.Ordinal);

        AddDropIds(ids, "enemy-drop", ItemDrops.GenericRuntimeDrops);
        AddDropIds(ids, "item-drop", ItemDrops.GenericDrops);
        AddEnemyIds(ids);
        AddInventoryIds(ids);
        AddWeaponIds(ids);

        return ids;
    }

    private static void AddDropIds(HashSet<string> ids, string configPrefix, IEnumerable<string> genericDrops)
    {
        foreach (var drop in genericDrops)
        {
            ids.Add($"{configPrefix}-ratio-{drop.ToLowerInvariant()}");
        }

        foreach (var drop in ItemDrops.HighValueDrops)
        {
            ids.Add($"{configPrefix}-valuable-{drop}");
        }
    }

    private static void AddEnemyIds(HashSet<string> ids)
    {
        foreach (var enemy in EnemyDefinitions.Instance.Randomizable)
        {
            var id = enemy.Id.ToLowerInvariant();
            ids.Add($"enemy-ratio-{id}");

            if (enemy.SupportsSpeedRandomization)
            {
                ids.Add($"enemy-speed-min-{id}");
                ids.Add($"enemy-speed-max-{id}");
            }

        }

        foreach (var enemy in EnemyDefinitions.Instance.All)
        {
            if (enemy is MargeStalker or MoldedBlade or EvelineGrandmother)
                continue;

            var prefix = enemy.IsBoss ? "boss" : "enemy";
            foreach (var healthPart in enemy.HealthParts)
            {
                var id = healthPart.ConfigId.ToLowerInvariant();
                ids.Add($"{prefix}-health-min-{id}");
                ids.Add($"{prefix}-health-max-{id}");
            }
        }
    }

    private static void AddInventoryIds(HashSet<string> ids)
    {
        foreach (var character in new[] { "ethan", "mia" })
        {
            foreach (var category in Enum.GetValues<StartingWeaponCategory>())
            {
                ids.Add($"inventory-weapon-{category.ToString().ToLowerInvariant()}-{character}");
            }
        }

        foreach (var item in ItemDefinitionRepository.Default.Items.Where(item => item.IsStackLimitConfigurable))
        {
            ids.Add(item.StackLimitConfigId);
        }
    }

    private static void AddWeaponIds(HashSet<string> ids)
    {
        var weaponDefinitions = WeaponDefinitionRepository.Default;
        var weapons = weaponDefinitions.PlayerWeapons
            .Where(wp => !wp.WeaponId.ToString().Contains("blaster", StringComparison.InvariantCultureIgnoreCase));
        foreach (var weapon in weapons)
        {
            var id = SanitizeWeaponId(weapon);
            ids.Add($"weapon-damage-min-{id}");
            ids.Add($"weapon-damage-max-{id}");
        }

        foreach (var gun in weaponDefinitions.Guns.Where(gun => gun.UserType == Enums.app.CharacterDefine.Type.Player))
        {
            var id = SanitizeWeaponId(gun);
            ids.Add($"weapon-ammo-capacity-min-{id}");
            ids.Add($"weapon-ammo-capacity-max-{id}");
            ids.Add($"weapon-reload-speed-min-{id}");
            ids.Add($"weapon-reload-speed-max-{id}");
        }
    }

    private static string SanitizeWeaponId(WeaponDefinition weapon)
        => weapon.WeaponId.ToString().ToLowerInvariant().Replace("_", "-");

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
