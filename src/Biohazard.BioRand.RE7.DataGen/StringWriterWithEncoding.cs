using System.Text;

namespace Biohazard.BioRand.RE7.DataGen
{
    public sealed class StringWriterWithEncoding : StringWriter
    {
        public override Encoding Encoding { get; }

        public StringWriterWithEncoding(Encoding encoding)
        {
            Encoding = encoding;
        }
    }
}