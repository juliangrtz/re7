namespace Biohazard.BioRand.RE7.REEngine;

public static class PakPath {
    private const string Prefix = "natives/stm/";

    extension(string path) {
        /// <summary>
        /// Appends "natives/stm/" to avoid redundancy.
        /// </summary>
        public string Of()
            => $"{Prefix}{path}".ToLowerInvariant();

        public string UserFile()
            => $"{Of(path)}.{FileVersions.UserFileVersion}".ToLowerInvariant();

        public string SceneFile()
            => $"{Of(path)}.{FileVersions.SceneFileVersion}".ToLowerInvariant();

        public string MessageFile()
            => $"{Of(path)}.{FileVersions.MsgFileVersion}".ToLowerInvariant();

        public string RcolFile()
            => $"{Of(path)}.{FileVersions.RcolFileVersion}".ToLowerInvariant();

        public string FromAbsolutePath()
            => Of(path.Without(path.SubstringBefore(Prefix))).ToLowerInvariant();
    }
}