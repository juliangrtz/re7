using Biohazard.BioRand.RE7.DataGen._Data;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.DataGen.CodeGen
{
    /// <summary>
    /// TODO: Look into proper Roslyn-powered C# code generation
    /// https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/
    /// </summary>
    internal class RszCodeGenerator
    {
        private static readonly byte[] rszJsonGz = EmbeddedResource.Get("rszre7rt.json.gz");
        private static readonly RszTypeRepository _rszRepository = RszRepositorySerializer.Default.FromJsonGz(rszJsonGz);

        public static string Generate(string typeName, bool generateEnums = false)
        {
            var type = _rszRepository.FromName(typeName) ?? throw new ArgumentException($"Type name {typeName} is invalid!");
            var csb = new RszTypeCsharpWriter()
            {
                GenerateEnums = generateEnums,
                UseEnumTypes = true,
                EnumNamespace = nameof(Enums)
            };
            return csb.Generate(type);
        }
    }
}
