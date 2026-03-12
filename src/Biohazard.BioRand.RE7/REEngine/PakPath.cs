namespace Biohazard.BioRand.RE7.REEngine;

public static class PakPath
{
    private const string PrefixRT = "natives/stm/";
    private const string PrefixNonRT = "natives/x64/";
    public static bool IsOnRT { get; internal set; } = true;

    /// <summary>
    /// Appends "natives/stm/" for the RT version or "natives/x64/" for the non-RT version to avoid redundancy.
    /// </summary>
    public static string Of(this string path)
        => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}";

    public static string UserFile(this string path)
        => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}.{Constants.UserFileVersion}";

    public static string SceneFile(this string path)
        => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}.{Constants.SceneFileVersion}";

    public static string FromAbsolutePath(this string absolutePath)
        => Of(absolutePath.Without(absolutePath.SubstringBefore(PrefixRT)));
}