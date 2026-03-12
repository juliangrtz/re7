using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Reflection;
using System.Text;

namespace Biohazard.BioRand.RE7.Tests;

public class ScnFileTests
{
    private readonly RszTypeRepository _repo =
    RszRepositorySerializer.Default.FromJsonGz(EmbeddedData.GetFile("rszre7rt.json.gz"));

    private readonly PakFile _pakFile =
        new(EmbeddedData.GetFile("biorand-re7.pak"));

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    [SkipCIFact(Skip = "Not reliable yet")]
    void Ensure_Correct_Serialization()
    {
        var differences = new List<string>();

        var scnFileHashes = _pakFile.FileHashes.Where(hash =>
        {
            var path = _pakList.GetPath(hash);
            return path != null && path.EndsWith($".scn.{Constants.SceneFileVersion}");
        }).ToList();

        foreach (var hash in scnFileHashes)
        {
            var path = _pakList.GetPath(hash)!;

            var input = new ScnFile(Constants.SceneFileVersion, _pakFile.GetEntryData(hash));
            var inputBuilder = input.ToBuilder(_repo);
            var output = inputBuilder.Build();

            // TODO: Replace reflection once everything is public
            static object GetRsz(object scn)
            {
                var type = scn.GetType();
                var prop = type.GetProperty("Rsz", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)!;
                return prop.GetValue(scn)!;
            }

            var inputRsz = GetRsz(input);
            var outputRsz = GetRsz(output);

            var readInstanceListMethod = inputRsz.GetType().GetMethod(
                "ReadInstanceList",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance
            )!;

            var inputInstances = readInstanceListMethod.Invoke(inputRsz, [_repo])!;
            var outputInstances = readInstanceListMethod.Invoke(outputRsz, [_repo])!;

            var inputList = ((IEnumerable<RszInstance>)inputInstances).Cast<object>().ToList();
            var outputList = ((IEnumerable<RszInstance>)outputInstances).Cast<object>().ToList();
            if (inputList.Count != outputList.Count)
            {
                differences.Add(
                    $"================================================================================\n" +
                    $"INSTANCE COUNT MISMATCH: {path}: {inputList.Count} vs. {outputList.Count}\n" +
                    $"================================================================================"
                );
                continue;
            }

            for (int i = 0; i < inputList.Count; i++)
            {
                var a = inputList[i]?.ToString() ?? "<null>";
                var b = outputList[i]?.ToString() ?? "<null>";

                if (a != b)
                {
                    var firstDiff = FindFirstDifference(a, b);

                    differences.Add($"""
================================================================================
SCN FILE : {path}
INSTANCE : {i}
TYPE     : {inputList[i]?.GetType().Name}

FIRST DIFF INDEX : {firstDiff}

INPUT :
{a}

OUTPUT:
{b}
================================================================================
""");
                }
            }
        }

        if (differences.Count > 0)
        {
            var report = string.Join(Environment.NewLine, differences);
            Assert.True(false, report);
        }
    }

    static int FindFirstDifference(string a, string b)
    {
        var len = Math.Min(a.Length, b.Length);

        for (int i = 0; i < len; i++)
            if (a[i] != b[i])
                return i;

        return len;
    }
}
