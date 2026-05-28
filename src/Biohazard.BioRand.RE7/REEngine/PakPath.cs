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
            => $"{path.Of()}.{FileVersions.UserFileVersion}".ToLowerInvariant();

        public string SceneFile()
            => $"{path.Of()}.{FileVersions.SceneFileVersion}".ToLowerInvariant();

        public string MessageFile()
            => $"{path.Of()}.{FileVersions.MsgFileVersion}".ToLowerInvariant();

        public string RcolFile()
            => $"{path.Of()}.{FileVersions.RcolFileVersion}".ToLowerInvariant();

        public string FromAbsolutePath()
            =>
                path.Without(path.SubstringBefore(Prefix)).Of().ToLowerInvariant();
    }
}