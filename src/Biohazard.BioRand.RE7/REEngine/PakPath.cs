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
        => $"{(IsOnRT ? PrefixRT : PrefixNonRT)}{path}".ToLowerInvariant();

    public static string UserFile(this string path)
        => $"{Of(path)}.{FileVersions.UserFileVersion}".ToLowerInvariant();

    public static string SceneFile(this string path)
        => $"{Of(path)}.{(IsOnRT ? FileVersions.SceneFileVersionRT : FileVersions.SceneFileVersionNonRT)}".ToLowerInvariant();

    public static string MessageFile(this string path)
        => $"{Of(path)}.{(IsOnRT ? FileVersions.MsgFileVersionRT : FileVersions.MsgFileVersionNonRT)}".ToLowerInvariant();

    public static string RcolFile(this string path)
    => $"{Of(path)}.{(IsOnRT ? FileVersions.RcolFileVersionRT : FileVersions.RcolFileVersionNonRT)}".ToLowerInvariant();

    public static string FromAbsolutePath(this string absolutePath)
        => Of(absolutePath.Without(absolutePath.SubstringBefore(IsOnRT ? PrefixRT : PrefixNonRT))).ToLowerInvariant();
}