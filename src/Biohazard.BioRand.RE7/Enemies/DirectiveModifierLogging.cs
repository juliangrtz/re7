using Biohazard.BioRand.RE7.Modifiers;
using System.Globalization;

namespace Biohazard.BioRand.RE7.Enemies;

internal static class DirectiveModifierLogging {
    public static string GetLogLabel(this IDirectiveModifier modifier)
        => modifier switch{
            EnemyRankParamDirectiveModifier => "Enemy rank parameters",
            _ => modifier.GetType().Name.Replace("DirectiveModifier", string.Empty, StringComparison.Ordinal),
        };

    extension(RandomizerLogger logger) {
        public void LogDirectiveFile(object rank,
            string userFilePath,
            Action action)
            => LogDirectiveFile(logger, $"Rank {rank}", userFilePath, action);

        public void LogDirectiveFile(string label,
            string userFilePath,
            Action action) {
            logger.Push($"{label} @ {userFilePath}");
            try {
                action();
            }
            finally {
                logger.Pop();
            }
        }

        public void LogChange(string label, double before, double after)
            => logger.LogLine($"{label}: {FormatValue(before)} => {FormatValue(after)}");

        public void LogMultiplier(string label, double multiplier)
            => logger.LogLine($"{label}: {FormatValue(multiplier)}x");

        public void LogHealthAssignment(string label, double baseHealth, double health)
            => logger.LogLine($"{label}: {FormatValue(baseHealth)} => {FormatValue(health)} HP");

        public void LogSpawnHealthAssignment(IEnemyDefinition enemy,
            float health,
            string source,
            string spawnName,
            Guid spawnGuid,
            string? extraDetails = null) {
            var line =
                $"HP MAP: HP={FormatPreciseValue(health)} | " +
                $"Enemy={enemy.Name} ({enemy.EnemyId}) | " +
                $"Base={FormatValue(enemy.BaseHealth)} | " +
                $"Source={source} | " +
                $"Spawn={spawnName} | " +
                $"Guid={spawnGuid}";

            if (!string.IsNullOrWhiteSpace(extraDetails)) {
                line += $" | {extraDetails}";
            }

            logger.LogLine(line);
        }

        public void LogUniqueSpawnHpHelp()
            => logger.LogLine(
                "Unique enemy HP is enabled. Search for \"HP MAP:\" entries to map an in-game HP value back to a spawn.");

        public void LogSkip(string reason)
            => logger.LogLine($"Skipped: {reason}");
    }

    private static string FormatValue(double value)
        => value.ToString("0.###", CultureInfo.InvariantCulture);

    private static string FormatPreciseValue(float value)
        => value.ToString("G9", CultureInfo.InvariantCulture);
}