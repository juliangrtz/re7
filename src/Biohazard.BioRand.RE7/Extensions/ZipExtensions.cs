using System.IO;
using System.IO.Compression;

namespace Biohazard.BioRand.RE7.Extensions
{
    internal static class ZipExtensions
    {
        public static byte[] GetData(this ZipArchiveEntry entry)
        {
            using var stream = entry.Open();
            var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
}