namespace Biohazard.BioRand.RE7.Modifiers;

internal static class ScriptedSceneSafety {
    public static bool IsFlashbackPath(string path)
        => path.Contains("/environment/scene/ff", StringComparison.OrdinalIgnoreCase)
           || path.Contains("/leveldesign/itemset/ff", StringComparison.OrdinalIgnoreCase)
           || path.Contains("/scenes/chapter/ff", StringComparison.OrdinalIgnoreCase)
           || path.Contains("past.scn", StringComparison.OrdinalIgnoreCase);

    public static bool AllowsEnemyMutation(string path)
        => !IsFlashbackPath(path);

    public static bool AllowsCollisionBearingExtra(string path)
        => !IsFlashbackPath(path);
}
