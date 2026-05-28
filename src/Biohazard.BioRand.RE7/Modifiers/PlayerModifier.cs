using Biohazard.BioRand.RE7.REEngine;
using System.Globalization;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class PlayerModifier : Modifier {
    private const string RandomizerKey = "modifier/player";

    internal static readonly IReadOnlyList<PlayerMaxHealthLevel> MaxHealthLevels =[
        new("base", "Base", 1000),
        new("steroid-use-1", "Steroid use 1", 1100),
        new("steroid-use-2", "Steroid use 2", 1200),
        new("steroid-use-3", "Steroid use 3", 1300),
        new("steroid-use-4", "Steroid use 4", 1400),
    ];

    internal static readonly IReadOnlyList<PlayerReloadSpeedLevel> ReloadSpeedLevels =[
        new("base", "Base", 1.0),
        new("stabilizer-use-1", "Stabilizer use 1", 1.2),
        new("stabilizer-use-2", "Stabilizer use 2", 1.4),
    ];

    private static readonly string PlayerMaxHealthTablePath =
        "prefab/character/pl0000/pl0000maxhealthtable.user".UserFile();

    private static readonly string PlayerReloadSpeedTablePath =
        "prefab/character/pl0000/pl0000reloadspeedratetable.user".UserFile();

    private static readonly string SystemParameterDataPath =
        "prefab/system/systemparameterdata.user".UserFile();

    public override void LogState(Randomizer randomizer, RandomizerLogger logger) {
        var table = randomizer.FileRepository.DeserializeUserFile<app.PlayerMaxHealthTable>(PlayerMaxHealthTablePath);
        logger.LogLine(
            $"[{PlayerMaxHealthTablePath}] Max health levels: {string.Join(", ", table.MaxHealthList.Select(FormatHealth))}");

        var reloadSpeedTable =
            randomizer.FileRepository.DeserializeUserFile<app.PlayerReloadSpeedRateTable>(PlayerReloadSpeedTablePath);
        logger.LogLine(
            $"[{PlayerReloadSpeedTablePath}] Reload speed levels: " +
            $"{string.Join(", ", reloadSpeedTable.ReloadSpeedRateList.Select(FormatValue))}");

        var systemParameters =
            randomizer.FileRepository.DeserializeUserFile<app.SystemParameterData>(SystemParameterDataPath);
        logger.LogLine(
            $"[{SystemParameterDataPath}] Psychostimulants: duration = {FormatValue(systemParameters.MegusuriParam.MegusuriMaxTime)}, " +
            $"range = {FormatValue(systemParameters.MegusuriParam.MegusuriRange)}");
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger) {
        ApplyMaxHealth(randomizer, logger);
        ApplyReloadSpeed(randomizer, logger);
        ApplyPsychostimulants(randomizer, logger);
    }

    private static void ApplyMaxHealth(Randomizer randomizer, RandomizerLogger logger) {
        if (!randomizer.GetConfigOption<bool>("player-random-max-health")) {
            logger.LogLine("Player max health randomization is disabled.");
            return;
        }

        randomizer.FileRepository.ModifyUserFile<app.PlayerMaxHealthTable>(PlayerMaxHealthTablePath, table => {
            var levelCount = Math.Min(table.MaxHealthList.Count, MaxHealthLevels.Count);
            if (table.MaxHealthList.Count != MaxHealthLevels.Count) {
                logger.LogLine(
                    $"Expected {MaxHealthLevels.Count} max-health levels but found {table.MaxHealthList.Count}. " +
                    $"Randomizing the first {levelCount}.");
            }

            for (var i = 0; i < levelCount; i++) {
                var level = MaxHealthLevels[i];
                var oldHealth = table.MaxHealthList[i];
                var newHealth = GetMaxHealth(randomizer, level);
                table.MaxHealthList[i] = newHealth;
                logger.LogLine($"{level.Label}: {FormatHealth(oldHealth)} => {FormatHealth(newHealth)} HP");
            }

            return table;
        });
    }

    private static void ApplyReloadSpeed(Randomizer randomizer, RandomizerLogger logger) {
        if (!randomizer.GetConfigOption<bool>("player-random-reload-speed")) {
            logger.LogLine("Player reload speed randomization is disabled.");
            return;
        }

        randomizer.FileRepository.ModifyUserFile<app.PlayerReloadSpeedRateTable>(PlayerReloadSpeedTablePath, table => {
            var levelCount = Math.Min(table.ReloadSpeedRateList.Count, ReloadSpeedLevels.Count);
            if (table.ReloadSpeedRateList.Count != ReloadSpeedLevels.Count) {
                logger.LogLine(
                    $"Expected {ReloadSpeedLevels.Count} reload-speed levels but found {table.ReloadSpeedRateList.Count}. " +
                    $"Randomizing the first {levelCount}.");
            }

            for (var i = 0; i < levelCount; i++) {
                var level = ReloadSpeedLevels[i];
                var oldRate = table.ReloadSpeedRateList[i];
                var newRate = GetReloadSpeedRate(randomizer, level);
                table.ReloadSpeedRateList[i] = newRate;
                logger.LogLine($"{level.Label}: {FormatValue(oldRate)} => {FormatValue(newRate)} reload rate");
            }

            return table;
        });
    }

    private static void ApplyPsychostimulants(Randomizer randomizer, RandomizerLogger logger) {
        if (!randomizer.GetConfigOption<bool>("player-random-psychostimulants")) {
            logger.LogLine("Psychostimulant randomization is disabled.");
            return;
        }

        var durationMultiplier = GetMultiplier(
            randomizer,
            randomizer.GetConfigOption<double>("player-psychostimulant-duration-min"),
            randomizer.GetConfigOption<double>("player-psychostimulant-duration-max"),
            "psychostimulants/duration");
        var rangeMultiplier = GetMultiplier(
            randomizer,
            randomizer.GetConfigOption<double>("player-psychostimulant-range-min"),
            randomizer.GetConfigOption<double>("player-psychostimulant-range-max"),
            "psychostimulants/range");
        logger.LogLine($"Psychostimulant duration multiplier: {FormatMultiplier(durationMultiplier)}x");
        logger.LogLine($"Psychostimulant range multiplier: {FormatMultiplier(rangeMultiplier)}x");

        randomizer.FileRepository.ModifyUserFile<app.SystemParameterData>(SystemParameterDataPath, systemParameters => {
            var param = systemParameters.MegusuriParam;

            var oldDuration = param.MegusuriMaxTime;
            param.MegusuriMaxTime = ScaleValue(oldDuration, durationMultiplier);
            logger.LogLine(
                $"Psychostimulant duration: {FormatValue(oldDuration)} => {FormatValue(param.MegusuriMaxTime)} seconds");

            var oldRange = param.MegusuriRange;
            param.MegusuriRange = ScaleValue(oldRange, rangeMultiplier);
            logger.LogLine(
                $"Psychostimulant range: {FormatValue(oldRange)} => {FormatValue(param.MegusuriRange)}");

            return systemParameters;
        });
    }

    private static double GetMultiplier(Randomizer randomizer, double min, double max, string rngKey) {
        if (max < min) {
            (min, max) = (max, min);
        }

        return Math.Round(randomizer.GetRng(RandomizerKey, rngKey).NextDouble(min, max), 2);
    }

    private static float GetMaxHealth(Randomizer randomizer, PlayerMaxHealthLevel level) {
        var from = randomizer.GetConfigOption<double>(level.FromConfigId, level.DefaultFromHealth);
        var to = randomizer.GetConfigOption<double>(level.ToConfigId, level.DefaultToHealth);
        if (to < from) {
            (from, to) = (to, from);
        }

        return Math.Max(1f,
            (float)Math.Round(randomizer.GetRng(RandomizerKey, "max-health", level.ConfigId).NextDouble(from, to)));
    }

    private static float GetReloadSpeedRate(Randomizer randomizer, PlayerReloadSpeedLevel level) {
        var from = randomizer.GetConfigOption<double>(level.FromConfigId, level.DefaultFromRate);
        var to = randomizer.GetConfigOption<double>(level.ToConfigId, level.DefaultToRate);
        if (to < from) {
            (from, to) = (to, from);
        }

        return Math.Max(0.1f,
            (float)Math.Round(randomizer.GetRng(RandomizerKey, "reload-speed", level.ConfigId).NextDouble(from, to),
                3));
    }

    private static float ScaleValue(float value, double multiplier)
        => (float)Math.Round(value * multiplier, 3);

    private static string FormatHealth(float health)
        => health.ToString("0.###", CultureInfo.InvariantCulture);

    private static string FormatValue(float value)
        => value.ToString("0.###", CultureInfo.InvariantCulture);

    private static string FormatMultiplier(double multiplier)
        => multiplier.ToString("0.##", CultureInfo.InvariantCulture);
}

internal sealed record PlayerMaxHealthLevel(string ConfigId, string Label, int VanillaHealth) {
    public string FromConfigId => $"player-max-health-from-{ConfigId}";
    public string ToConfigId => $"player-max-health-to-{ConfigId}";
    public int DefaultFromHealth => (int)Math.Round(VanillaHealth * 0.75);
    public int DefaultToHealth => (int)Math.Round(VanillaHealth * 1.25);
}

internal sealed record PlayerReloadSpeedLevel(string ConfigId, string Label, double VanillaRate) {
    public string FromConfigId => $"player-reload-speed-from-{ConfigId}";
    public string ToConfigId => $"player-reload-speed-to-{ConfigId}";
    public double DefaultFromRate => Math.Round(VanillaRate * 0.75, 2);
    public double DefaultToRate => Math.Round(VanillaRate * 1.25, 2);
}