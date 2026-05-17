using Hexa.NET.ImGui;
using System.Globalization;
using System.Text.Json;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;
public partial class REFPlugin
{
    private static void OnImGuiDrawUi()
    {
        if (!IsInitialized) return;

        if (ImGui.TreeNode("BioRand 7"))
        {
            DrawSeedAndConfigInfo();
            ImGui.Separator();
            DrawRuntimeInfo();
            ImGui.Separator();
            DrawFeatureInfo();
            ImGui.Separator();
            DrawDebugTools();
            ImGui.Separator();
            DrawConfigValues();
            ImGui.TreePop();
        }
    }

    private static void DrawSeedAndConfigInfo()
    {
        DrawLabelValue("Seed", GetSeedLabel());
        DrawLabelValue("Config file", GetConfigStatusLabel());
        DrawLabelValue("Config entries", config.Entries.ToString(CultureInfo.InvariantCulture));
        ImGui.TextWrapped($"Path: {config.ConfigPath}");
        if (config.LoadError != null)
        {
            ImGui.TextWrapped($"Load error: {config.LoadError}");
        }

        if (!config.HasConfigFile && config.LoadError == null && ImGui.TreeNode("Config search paths"))
        {
            foreach (var path in config.GetConfigSearchPaths())
            {
                ImGui.TextWrapped(path);
            }

            ImGui.TreePop();
        }
    }

    private static void DrawRuntimeInfo()
    {
        DrawLabelValue("Player", ReadRuntimeValue(GetPlayerName));
        DrawLabelValue("Chapter", ReadRuntimeValue(GetCurrentChapterName));
        DrawLabelValue("Difficulty", ReadRuntimeValue(() => GetCurrentDifficulty().ToString()));
        DrawLabelValue("Position", ReadRuntimeValue(GetPlayerPositionLabel));
    }

    private static void DrawFeatureInfo()
    {
        DrawLabelValue("Key item locations", FormatEnabled(config.ReadOrDefault("random-key-item-locations", false)));
        DrawLabelValue("Static item locations", FormatEnabled(config.ReadOrDefault("random-items", true)));
        DrawLabelValue("Additional items", FormatEnabled(config.ReadOrDefault("additional-items", false)));
        DrawLabelValue("Enemy drops", $"{FormatEnabled(IsEnemyDropEnabled())} ({GetEnemyDropStateLabel()})");
        DrawLabelValue("Em3300 explosions", $"{FormatEnabled(IsEm3300ExplosionEnabled())} ({GetEm3300ExplosionStateLabel()})");
        DrawLabelValue("Madhouse saves", FormatEnabled(ReadRuntimeBool(IsMadhouseNormalSaveSystemEnabled)));
        DrawLabelValue("Reload speed", $"{FormatEnabled(config.ReadOrDefault("weapon-mod-reload-speed", false))} ({GetWeaponReloadSpeedStateLabel()})");
        DrawLabelValue("Ethan inventory", config.ReadOrDefault("random-starting-inventory-size-ethan", "12"));
        DrawLabelValue("Mia inventory", config.ReadOrDefault("random-starting-inventory-size-mia", "12"));
    }

    private static void DrawDebugTools()
    {
        if (ImGui.TreeNode("Debug tools"))
        {
            var logVerbose = logger.LogVerbose;
            if (ImGui.Checkbox("Verbose logging", ref logVerbose))
            {
                logger.LogVerbose = logVerbose;
                logger.Log($"Verbose logging {(logVerbose ? "enabled" : "disabled")} from UI.");
            }

            if (ImGui.Button("Reload config"))
            {
                ReloadConfigurationFromUi();
            }

            ImGui.SameLine();
            if (ImGui.Button("Log snapshot"))
            {
                LogRuntimeSnapshot();
            }

            if (ImGui.Button("Clear enemy drop state"))
            {
                ClearEnemyDropStateFromUi();
            }

            ImGui.SameLine();
            if (ImGui.Button("Clear Em3300 state"))
            {
                ClearEm3300ExplosionStateFromUi();
            }

            if (ImGui.Button("Clear reload cache"))
            {
                ClearWeaponReloadSpeedStateFromUi();
            }

            ImGui.TreePop();
        }
    }

    private static void DrawConfigValues()
    {
        if (ImGui.TreeNode("Config values"))
        {
            foreach (var (key, value) in config.GetEntriesSnapshot())
            {
                ImGui.TextWrapped($"{key}: {FormatConfigValue(value)}");
            }

            ImGui.TreePop();
        }
    }

    private static void DrawLabelValue(string label, string value)
        => ImGui.TextWrapped($"{label}: {value}");

    private static string GetSeedLabel()
        => TryReadConfiguredSeed(out var seed)
            ? string.Create(CultureInfo.InvariantCulture, $"{seed}")
            : "not present";

    private static bool TryReadConfiguredSeed(out int seed)
        => config.TryRead(PluginSeedConfigKey, out seed);

    private static string GetConfigStatusLabel()
    {
        if (config.LoadError != null)
            return "error";

        return config.HasConfigFile ? "loaded" : "missing, using defaults";
    }

    private static string FormatEnabled(bool enabled)
        => enabled ? "enabled" : "disabled";

    private static string ReadRuntimeValue(Func<string?> read)
    {
        try
        {
            return read() ?? "unavailable";
        }
        catch (Exception ex)
        {
            return $"unavailable ({ex.GetType().Name})";
        }
    }

    private static bool ReadRuntimeBool(Func<bool> read)
    {
        try
        {
            return read();
        }
        catch
        {
            return false;
        }
    }

    private static string GetPlayerPositionLabel()
    {
        if (!TryGetPlayerPosition(out var playerPosition))
            return "unavailable";

        return string.Create(
            CultureInfo.InvariantCulture,
            $"{playerPosition.x:0.###}, {playerPosition.y:0.###}, {playerPosition.z:0.###}");
    }

    private static string GetEnemyDropStateLabel()
    {
        lock (enemyDropStateLock)
        {
            return $"{droppedEnemyObjects.Count} dropped, {enemyDropGenerations.Count} tracked";
        }
    }

    private static string GetEm3300ExplosionStateLabel()
    {
        lock (em3300ExplosionStateLock)
        {
            return $"{em3300ExplosionStates.Count} tracked";
        }
    }

    private static string GetWeaponReloadSpeedStateLabel()
    {
        lock (weaponReloadSpeedCacheLock)
        {
            return $"{weaponReloadSpeedMultiplierCache.Count} cached";
        }
    }

    private static string FormatConfigValue(JsonElement value)
    {
        var result = value.ValueKind switch
        {
            JsonValueKind.String => value.GetString() ?? string.Empty,
            JsonValueKind.Number or JsonValueKind.True or JsonValueKind.False => value.GetRawText(),
            JsonValueKind.Null => "null",
            JsonValueKind.Undefined => "undefined",
            _ => value.GetRawText()
        };

        return result.Length <= 160
            ? result
            : string.Concat(result.AsSpan(0, 157), "...");
    }

    private static void ReloadConfigurationFromUi()
    {
        config.Reload();
        logger.LogVerbose = config.ReadOrDefault("verbose-reframework-plugin-logging", logger.LogVerbose);
        logger.Log($"Reloaded configuration from UI. Status: {GetConfigStatusLabel()}, entries: {config.Entries}.");
    }

    private static void LogRuntimeSnapshot()
    {
        logger.Log(
            $"Snapshot: seed={GetSeedLabel()}, player={ReadRuntimeValue(GetPlayerName)}, chapter={ReadRuntimeValue(GetCurrentChapterName)}, difficulty={ReadRuntimeValue(() => GetCurrentDifficulty().ToString())}, position={ReadRuntimeValue(GetPlayerPositionLabel)}.");
        logger.Log(
            $"Features: key-items={FormatEnabled(config.ReadOrDefault("random-key-item-locations", false))}, items={FormatEnabled(config.ReadOrDefault("random-items", true))}, enemy-drops={FormatEnabled(IsEnemyDropEnabled())}, em3300={FormatEnabled(IsEm3300ExplosionEnabled())}, reload-speed={FormatEnabled(config.ReadOrDefault("weapon-mod-reload-speed", false))}.");
    }

    private static void ClearEnemyDropStateFromUi()
    {
        lock (enemyDropStateLock)
        {
            droppedEnemyObjects.Clear();
            enemyDropGenerations.Clear();
        }

        logger.Log("Cleared enemy drop state from UI.");
    }

    private static void ClearEm3300ExplosionStateFromUi()
    {
        lock (em3300ExplosionStateLock)
        {
            em3300ExplosionStates.Clear();
        }

        logger.Log("Cleared Em3300 explosion state from UI.");
    }

    private static void ClearWeaponReloadSpeedStateFromUi()
    {
        lock (weaponReloadSpeedCacheLock)
        {
            weaponReloadSpeedMultiplierCache.Clear();
        }

        lock (weaponReloadSpeedLogLock)
        {
            lastLoggedWeaponReloadSpeedWeapon = null;
            lastLoggedWeaponReloadSpeedDepressantLevel = null;
            lastLoggedWeaponReloadSpeedRate = null;
        }

        logger.Log("Cleared weapon reload speed cache from UI.");
    }
}
