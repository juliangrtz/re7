using Biohazard.BioRand.RE7.Modifiers;
using System.Globalization;

namespace Biohazard.BioRand.RE7.Enemies;

internal static class DirectiveModifierLogging
{
    public static string GetLogLabel(this IDirectiveModifier modifier)
        => modifier switch
        {
            EnemyRankParamDirectiveModifier => "Enemy rank parameters",
            MoldedCommonRankParamsDirectiveModifier => "Molded common rank parameters",
            _ => modifier.GetType().Name.Replace("DirectiveModifier", string.Empty, StringComparison.Ordinal),
        };

    public static void LogDirectiveFile(
        this RandomizerLogger logger,
        object rank,
        string userFilePath,
        Action action)
        => LogDirectiveFile(logger, $"Rank {rank}", userFilePath, action);

    public static void LogDirectiveFile(
        this RandomizerLogger logger,
        string label,
        string userFilePath,
        Action action)
    {
        logger.Push($"{label} @ {userFilePath}");
        try
        {
            action();
        }
        finally
        {
            logger.Pop();
        }
    }

    public static void LogChange(this RandomizerLogger logger, string label, double before, double after)
        => logger.LogLine($"{label}: {FormatValue(before)} => {FormatValue(after)}");

    public static void LogMultiplier(this RandomizerLogger logger, string label, double multiplier)
        => logger.LogLine($"{label}: {FormatValue(multiplier)}x");

    public static void LogHealthMultiplier(this RandomizerLogger logger, int baseHealth, double multiplier)
        => logger.LogLine(
            $"Health multiplier: {FormatValue(multiplier)}x " +
            $"({FormatValue(baseHealth)} => {FormatValue(baseHealth * multiplier)})");

    public static void LogSkip(this RandomizerLogger logger, string reason)
        => logger.LogLine($"Skipped: {reason}");

    private static string FormatValue(double value)
        => value.ToString("0.###", CultureInfo.InvariantCulture);
}
