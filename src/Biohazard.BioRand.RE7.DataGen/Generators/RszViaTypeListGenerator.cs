using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Text;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class ScnViaTypeListGenerator : IFileGenerator
{
    public string Id => "scn-via-type-list";

    private readonly RszTypeRepository _rszRepository =
    RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json"));

    private readonly PakFile _pakFile =
        new(EmbeddedData.GetFile("biorand-re7.pak"));

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    public object Generate(GenerateCommand.GenerateSettings settings)
    {
        var result = new ConcurrentHashSet<string>();

        var relevantHashes = _pakFile.FileHashes
            .Where(hash =>
            {
                var path = _pakList.GetPath(hash);
                return path != null && path.EndsWith($".scn.{Constants.SceneFileVersionRT}");
            })
            .ToList();

        Parallel.ForEach(relevantHashes, hash =>
        {
            var path = _pakList.GetPath(hash)!;
            var scene = new ScnFile(Constants.SceneFileVersionRT, _pakFile.GetEntryData(hash)).ReadScene(_rszRepository);

            scene.VisitComponents(component =>
            {
                var name = component.Type.Name;
                if (name.StartsWith("via."))
                {
                    result.Add(name);
                }
            });
        });

        return result.Items.Order();
    }
}
