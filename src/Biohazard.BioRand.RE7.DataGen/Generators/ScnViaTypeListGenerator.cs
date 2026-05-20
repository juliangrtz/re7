using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Text;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class ScnViaTypeListGenerator : IFileGenerator {
    public string Id => "scn-via-type-list";
    public bool CopyToDataDirectory => false;

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json.gz").Ungzip());

    private readonly PakFile _pakFile = Constants.BioRandPakFile;

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    public object Generate(GenerateCommand.GenerateSettings settings) {
        var result = new ConcurrentHashSet<string>();

        var relevantHashes = _pakFile.FileHashes
            .Where(hash => {
                var path = _pakList.GetPath(hash);
                return path != null && path.EndsWith($".scn.{FileVersions.SceneFileVersion}");
            })
            .ToList();

        Parallel.ForEach(relevantHashes, hash => {
            var path = _pakList.GetPath(hash)!;
            var scene =
                new ScnFile(FileVersions.SceneFileVersion, _pakFile.GetEntryData(hash)).ReadScene(_rszRepository);

            scene.VisitComponents(component => {
                var name = component.Type.Name;
                if (name.StartsWith("via.")) {
                    result.Add(name);
                }
            });
        });

        return result.Items.Order();
    }
}