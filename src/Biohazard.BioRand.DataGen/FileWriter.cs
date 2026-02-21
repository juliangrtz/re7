namespace Biohazard.BioRand.RE7.DataGen
{
    internal class FileWriter
    {
        static FileWriter()
        {
            if (!Directory.Exists("GeneratedFiles"))
            {
                Directory.CreateDirectory("GeneratedFiles");
            }
        }

        public static void WriteOutput(string path, string content)
            => File.WriteAllText($"GeneratedFiles\\{path}", content);

        public static void WriteOutput(string path, byte[] content)
            => File.WriteAllBytes($"GeneratedFiles\\{path}", content);
    }
}
