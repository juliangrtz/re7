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
        => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}.{FileVersions.UserFileVersion}";

    public static string SceneFile(this string path)
        => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}.{(IsOnRT ? FileVersions.SceneFileVersionRT : FileVersions.SceneFileVersionNonRT)}";

    public static string MessageFile(this string path)
        => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}.{(IsOnRT ? FileVersions.MsgFileVersionRT : FileVersions.MsgFileVersionNonRT)}";

    public static string RcolFile(this string path)
    => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}.{(IsOnRT ? FileVersions.RcolFileVersionRT : FileVersions.RcolFileVersionNonRT)}";

    public static string FromAbsolutePath(this string absolutePath)
        => Of(absolutePath.Without(absolutePath.SubstringBefore(IsOnRT ? PrefixRT : PrefixNonRT)));
}