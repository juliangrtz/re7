using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class ScnFileTests {
    private readonly RszTypeRepository _repo =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json.gz").Ungzip());

    private readonly PakFile _pakFile =
        new(File.ReadAllBytes(RandomizerTest.InputPakPath));

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(
            EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private const string _singleFileTest =
        "natives/stm/environment/scene/chapter4/c04_cottage.scn.20";

    record InstanceDifference(
        string SceneFile,
        int InstanceIndex,
        string? Type,
        int FirstDiffIndex,
        string Input,
        string Output
    );

    record InstanceCountMismatch(
        string SceneFile,
        int InputCount,
        int OutputCount
    );

    [Fact]
    void Test_Single_Scene_File() {
        var hash = _pakFile.FileHashes.FirstOrDefault(h =>
            _pakList.GetPath(h) == _singleFileTest);

        Assert.True(hash != 0, $"File not found in pak list: {_singleFileTest}");

        var differences = TestSceneFile(hash, _singleFileTest);

        if (differences.Count > 0)
            Assert.Fail(ToJson(differences));
    }

    [Fact(Skip = "Skip until RSZ is fixed")]
    void Test_Relevant_Scene_Files() {
        var differences = new List<object>();
        var allowedDirectories = new string[]{
            //"natives/stm/ch8", "natives/stm/ch9", 
            "natives/stm/environment", "natives/stm/leveldesign", "natives/stm/scenes"
        };
        var scnFileHashes = _pakFile.FileHashes.Where(hash => {
            var path = _pakList.GetPath(hash);

            return path != null
                   && allowedDirectories.Any(dir => path.StartsWith(dir))
                   && path.EndsWith($".scn.{FileVersions.SceneFileVersion}")
                   && !path.Contains("levelfsm");
        }).ToList();

        foreach (var hash in scnFileHashes) {
            var path = _pakList.GetPath(hash)!;
            differences.AddRange(TestSceneFile(hash, path));
        }

        if (differences.Count > 0)
            Assert.Fail(ToJson(differences));
    }

    [Fact(Skip = "Skip until RSZ is fixed")]
    void Test_All_Scene_Files() {
        var differences = new List<object>();

        var scnFileHashes = _pakFile.FileHashes.Where(hash => {
            var path = _pakList.GetPath(hash);
            return path != null && path.EndsWith($".scn.{FileVersions.SceneFileVersion}");
        });

        foreach (var hash in scnFileHashes) {
            var path = _pakList.GetPath(hash)!;
            differences.AddRange(TestSceneFile(hash, path));
        }

        if (differences.Count > 0)
            Assert.Fail(ToJson(differences));
    }

    private List<object> TestSceneFile(ulong hash, string path) {
        var differences = new List<object>();

        var input = new ScnFile(FileVersions.SceneFileVersion, _pakFile.GetEntryData(hash));
        var output = input.ToBuilder(_repo).Build();

        var inputInstances = ReadInstances(GetRsz(input));
        var outputInstances = ReadInstances(GetRsz(output));

        if (inputInstances.Count != outputInstances.Count) {
            differences.Add(new InstanceCountMismatch(
                path,
                inputInstances.Count,
                outputInstances.Count
            ));

            return differences;
        }

        for (int i = 0; i < inputInstances.Count; i++) {
            var a = inputInstances[i]?.ToString() ?? "<null>";
            var b = outputInstances[i]?.ToString() ?? "<null>";

            if (a != b) {
                differences.Add(new InstanceDifference(
                    path,
                    i,
                    inputInstances[i]?.GetType().Name,
                    FindFirstDifference(a, b),
                    a,
                    b
                ));
            }
        }

        return differences;
    }

    private static object GetRsz(object scn) {
        var prop = scn.GetType().GetProperty(
            "Rsz",
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)!;

        return prop.GetValue(scn)!;
    }

    private List<object> ReadInstances(object rsz) {
        var method = rsz.GetType().GetMethod(
            "ReadInstanceList",
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)!;

        var instances = method.Invoke(rsz, [_repo])!;

        return ((IEnumerable<RszInstance>)instances).Cast<object>().ToList();
    }

    private static int FindFirstDifference(string a, string b) {
        var len = Math.Min(a.Length, b.Length);

        for (int i = 0; i < len; i++)
            if (a[i] != b[i])
                return i;

        return len;
    }

    private static string ToJson(object obj) {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions{
            WriteIndented = true
        });
    }
}