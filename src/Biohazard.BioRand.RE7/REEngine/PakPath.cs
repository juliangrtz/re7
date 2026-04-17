namespace Biohazard.BioRand.RE7.REEngine;

public static class PakPath
{
    private const string Prefix = "natives/stm/";

    /// <summary>
    /// Appends "natives/stm/" to avoid redundancy.
    /// </summary>
    public static string Of(this string path)
        => $"{Prefix}{path}".ToLowerInvariant();

    public static string UserFile(this string path)
        => $"{Of(path)}.{FileVersions.UserFileVersion}".ToLowerInvariant();

    public static string SceneFile(this string path)
        => $"{Of(path)}.{FileVersions.SceneFileVersion}".ToLowerInvariant();

    public static string MessageFile(this string path)
        => $"{Of(path)}.{FileVersions.MsgFileVersion}".ToLowerInvariant();

    public static string RcolFile(this string path)
    => $"{Of(path)}.{FileVersions.RcolFileVersion}".ToLowerInvariant();

    public static string FromAbsolutePath(this string absolutePath)
        => Of(absolutePath.Without(absolutePath.SubstringBefore(Prefix))).ToLowerInvariant();
}
