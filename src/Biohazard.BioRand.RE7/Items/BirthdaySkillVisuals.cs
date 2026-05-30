using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Items;

internal readonly record struct BirthdaySkillVisualResources(string Mesh, string Material);

internal static class BirthdaySkillVisuals {
    private const string OverlayZipName = "silver_birthday_patches.zip";
    private const float RotationXCorrectionScale = 0.5f;

    public static bool TryGetResources(string itemDataId, out BirthdaySkillVisualResources resources) {
        var normalizedId = itemDataId.ToLowerInvariant();
        if (!TryGetMeshFolder(normalizedId, out var meshFolder)) {
            resources = default;
            return false;
        }

        resources = new BirthdaySkillVisualResources(
            $"Props/{meshFolder}/{meshFolder}.mesh",
            $"Props/{meshFolder}/{normalizedId}/{normalizedId}.mdf2");
        return true;
    }

    public static void CopyRequiredFiles(IPatchContext context, string itemDataId) {
        var normalizedId = itemDataId.ToLowerInvariant();
        if (!TryGetMeshFolder(normalizedId, out var meshFolder))
            return;

        if (context is FileRepository repository && repository.HasAdditionalOutputAssetBundle(OverlayZipName))
            return;

        var meshPath = $"natives/stm/props/{meshFolder}/{meshFolder}.mesh.220128762";
        var materialFolderPath = $"natives/stm/props/{meshFolder}/{normalizedId}/";
        var zipData = context.GetSupplementFile(OverlayZipName) ??
                      throw new RandomizerUserException($"Unable to read Birthday skill overlay '{OverlayZipName}'.");
        using var supplementZip = new ZipArchive(new MemoryStream(zipData), ZipArchiveMode.Read);
        var copiedMesh = false;
        var copiedMaterialFolder = false;

        foreach (var entry in supplementZip.Entries) {
            if (entry.Length == 0)
                continue;

            var path = entry.FullName.Replace('\\', '/');
            if (!IsSafeOverlayPath(path)) {
                throw new RandomizerUserException(
                    $"Birthday skill overlay '{OverlayZipName}' contains an invalid entry '{entry.FullName}'.");
            }

            copiedMesh |= path.Equals(meshPath, StringComparison.OrdinalIgnoreCase);
            copiedMaterialFolder |= path.StartsWith(materialFolderPath, StringComparison.OrdinalIgnoreCase);
            SetRequiredAssetFile(context, path, ReadZipEntry(entry));
        }

        if (!copiedMesh || !copiedMaterialFolder) {
            throw new RandomizerUserException(
                $"Birthday skill overlay '{OverlayZipName}' does not contain required files for '{itemDataId}'.");
        }

        if (context is FileRepository outputRepository) {
            outputRepository.MarkAdditionalOutputAssetBundle(OverlayZipName);
        }
    }

    public static RszGameObject ApplyRotationCorrection(RszGameObject gameObject) {
        var transform = gameObject.FindComponent("via.Transform");
        if (transform == null)
            return gameObject;

        var correctedRotation = CorrectRotation(transform.Get<Quaternion>("Rotation"));
        return gameObject.AddOrUpdateComponent(transform.Set("Rotation", correctedRotation));
    }

    public static Quaternion CorrectRotation(Quaternion rotation) {
        rotation.X *= RotationXCorrectionScale;
        return rotation;
    }

    private static bool TryGetMeshFolder(string normalizedId, out string meshFolder) {
        meshFolder = normalizedId switch{
            "skl001" => "sm9958_skillpatch01",
            "skl002" or "skl008" or "skl010" or "skl012" or "skl014" or "skl016" or "skl023" =>
                "sm9959_skillpatch02",
            "skl003" or "skl009" or "skl011" or "skl013" or "skl015" or "skl017" or "skl018" or
                "skl019" or "skl021" or "skl022" => "sm9960_skillpatch03",
            _ => "",
        };
        return meshFolder.Length != 0;
    }

    private static byte[] ReadZipEntry(ZipArchiveEntry entry) {
        using var entryStream = entry.Open();
        using var memoryStream = new MemoryStream();
        entryStream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }

    private static bool IsSafeOverlayPath(string path) {
        return path.StartsWith("natives/", StringComparison.OrdinalIgnoreCase) &&
               !path.Split('/').Any(segment => segment == "..");
    }

    private static void SetRequiredAssetFile(IPatchContext context, string path, byte[] data) {
        if (context is FileRepository repository) {
            repository.SetAdditionalOutputAssetFile(path, data);
            return;
        }

        context.SetFile(path, data);
    }
}