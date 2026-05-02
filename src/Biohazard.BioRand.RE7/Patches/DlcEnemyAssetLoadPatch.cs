using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Patches;

internal class DlcEnemyAssetLoadPatch(IPatchContext context) : IPatch
{
    private static readonly string DlcActiveRootScenePath = PakPath.SceneFile("scenes/dlc/dlc_active_root.scn");
    private static readonly string DlcChapter8ScenePath = PakPath.SceneFile("scenes/dlc/dlc_chapter8.scn");
    private static readonly string DlcChapter9ScenePath = PakPath.SceneFile("scenes/dlc/dlc_chapter9.scn");
    private static readonly string Ch8ChapterScenePath = PakPath.SceneFile("ch8/scenes/chapter8.scn");
    private static readonly string Ch8GameScenePath = PakPath.SceneFile("ch8/scenes/ch8_game.scn");
    private static readonly string Ch9ChapterScenePath = PakPath.SceneFile("ch9/scenes/chapter/chapter9.scn");
    private static readonly string Ch9InGameScenePath = PakPath.SceneFile("ch9/scenes/chapter/c09_ingame.scn");
    private static readonly string Ch9EnemyScenePath = PakPath.SceneFile("ch9/scenes/chapter/enemy_c09.scn");
    private static readonly string Ch9VfxScenePath = PakPath.SceneFile("ch9/vfx/vfx_scene/vfx_c09.scn");
    private static readonly string TemplateScenePath = $"template.scn.{FileVersions.SceneFileVersion}";
    private static readonly string[] DlcEnemyAssetScenePaths =
    [
        PakPath.SceneFile("ch8/scenes/chapter/chapter8/enemy_c08.scn"),
        PakPath.SceneFile("ch8/scenes/chapter/chapter8/mother_c08.scn"),
        PakPath.SceneFile("ch9/scenes/chapter/enemy/chapter9_1/enemy_c09_1.scn"),
        PakPath.SceneFile("ch9/scenes/chapter/enemy/chapter9_2/enemy_c09_2.scn"),
        PakPath.SceneFile("ch9/scenes/chapter/enemy/chapter9_3/enemy_c09_3.scn"),
        PakPath.SceneFile("ch9/scenes/chapter/enemy/chapter9_4/enemy_c09_4.scn"),
        PakPath.SceneFile("ch9/vfx/vfx_scene/vfx_c09_1.scn"),
        PakPath.SceneFile("ch9/vfx/vfx_scene/vfx_c09_2.scn"),
        PakPath.SceneFile("ch9/vfx/vfx_scene/vfx_c09_3.scn"),
        PakPath.SceneFile("ch9/vfx/vfx_scene/vfx_c09_4.scn"),
    ];

    private Dictionary<string, string>? _pakPathByVersionlessPath;

    public void Apply()
    {
        ApplyChapterRoots();
        ApplyNotAHeroEnemyFolders();
        ApplyEndOfZoeEnemyFolders();
        CopyDlcEnemyAssetFiles();
    }

    private void ApplyChapterRoots()
    {
        SetFoldersStandby(DlcActiveRootScenePath, "DLC_Chapter8", "DLC_Chapter9");
        SetFoldersStandby(DlcChapter8ScenePath, "Chapter8");
        SetFoldersStandby(DlcChapter9ScenePath, "Chapter9");
    }

    private void ApplyNotAHeroEnemyFolders()
    {
        SetFoldersStandby(Ch8ChapterScenePath, "CH8_Game");
        SetFoldersStandby(Ch8GameScenePath, "Enemy_c08", "Mother_c08");
        SetSceneFolderControlsDefaultStandby(Ch8ChapterScenePath, "Chapter8_Game");
        SetSceneFolderControlsDefaultStandby(Ch8GameScenePath, "Mother");
    }

    private void ApplyEndOfZoeEnemyFolders()
    {
        SetFoldersStandby(Ch9ChapterScenePath, "c09_InGame");
        SetFoldersStandby(Ch9InGameScenePath, "Enemy_c09", "VFX_c09");
        SetFoldersStandby(Ch9EnemyScenePath, "Enemy_c09_1", "Enemy_c09_2", "Enemy_c09_3", "Enemy_c09_4");
        SetFoldersStandby(Ch9VfxScenePath, "VFX_c09_1", "VFX_c09_2", "VFX_c09_3", "VFX_c09_4");

        SetSceneFolderControlsDefaultStandby(Ch9ChapterScenePath, "Chapter9_InGame");
        SetSceneFolderControlsDefaultStandby(Ch9EnemyScenePath, "Enemy_c09_1", "Enemy_c09_2", "Enemy_c09_3", "Enemy_c09_4");
        SetSceneFolderControlsDefaultStandby(Ch9VfxScenePath, "VFX_c09_1", "VFX_c09_2", "VFX_c09_3", "VFX_c09_4");
    }

    private void SetFoldersStandby(string path, params string[] folderNames)
    {
        var names = folderNames.ToHashSet(StringComparer.OrdinalIgnoreCase);
        context.ModifyScnFile(path, scene => (RszScene)SetFoldersStandby(scene, names));
    }

    private static IRszSceneNode SetFoldersStandby(IRszSceneNode node, HashSet<string> folderNames)
    {
        if (node is RszFolder folder && folderNames.Contains(folder.Name))
        {
            node = new RszFolder(folder.Settings.Set("Standby", true), folder.Children);
        }

        if (node.Children.IsDefaultOrEmpty)
        {
            return node;
        }

        var children = node.Children
            .Select(child => SetFoldersStandby(child, folderNames))
            .ToImmutableArray();
        return node.WithChildren(children);
    }

    private void SetSceneFolderControlsDefaultStandby(string path, params string[] controlNames)
    {
        var names = controlNames.ToHashSet(StringComparer.OrdinalIgnoreCase);
        context.ModifyScnFile(path, scene => scene.VisitComponents(component =>
        {
            if (component.Type.Name != "app.SceneFolderControl")
            {
                return component;
            }

            var controlName = ((RszStringNode)component["ControlName"]).Value;
            return names.Contains(controlName)
                ? component.Set("isDefaultStandby", true)
                : component;
        }));
    }

    private void CopyDlcEnemyAssetFiles()
    {
        if (!ShouldCopyDlcEnemyAssetFiles())
        {
            return;
        }

        var pending = new Queue<string>();
        var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var path in DlcEnemyAssetScenePaths)
        {
            pending.Enqueue(path);
        }

        foreach (var reference in GetTemplateDlcEnemyDependencyReferences())
        {
            if (TryResolvePakPath(reference, out var path))
            {
                pending.Enqueue(path);
            }
        }

        while (pending.TryDequeue(out var path))
        {
            if (!visited.Add(path))
            {
                continue;
            }

            var data = context.GetFile(path);
            if (data == null)
            {
                continue;
            }

            context.SetFile(path, data);
            foreach (var reference in GetFileDependencyReferences(path, data))
            {
                if (TryResolvePakPath(reference, out var dependencyPath))
                {
                    pending.Enqueue(dependencyPath);
                }
            }
        }
    }

    private bool ShouldCopyDlcEnemyAssetFiles()
    {
        if (context.GetConfigOption("extra-enemy-amount", 0.0) > 0.0)
        {
            return true;
        }

        return context.GetConfigOption<bool>("random-enemies") &&
               EnemyDefinitions.Instance.All
                   .Where(enemy => enemy.IsDlc)
                   .Any(enemy => context.GetConfigOption<double>($"enemy-ratio-{enemy.Id.ToLowerInvariant()}") != 0.0);
    }

    private IEnumerable<string> GetTemplateDlcEnemyDependencyReferences()
    {
        var templateScene = new ScnFile(
                FileVersions.SceneFileVersion,
                context.GetSupplementFile(TemplateScenePath))
            .ReadScene(context.TypeRepository);
        var aliases = EnemyDefinitions.Instance.All
            .Where(enemy => enemy.IsDlc)
            .Select(enemy => enemy.EnemyAlias)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var alias in aliases)
        {
            foreach (var name in new[] { $"EnemyTemplate_{alias}", $"EnemySpawnInfo_{alias}" })
            {
                var gameObject = templateScene.FindGameObject(name);
                if (gameObject == null)
                {
                    continue;
                }

                foreach (var reference in CollectGameObjectDependencyReferences(gameObject))
                {
                    yield return reference;
                }
            }
        }
    }

    private IEnumerable<string> GetFileDependencyReferences(string path, byte[] data)
    {
        try
        {
            var version = GetVersion(path);
            var versionlessPath = StripVersionSuffix(path);
            if (versionlessPath.EndsWith(".scn", StringComparison.OrdinalIgnoreCase))
            {
                var scnFile = new ScnFile(version, data);
                foreach (var resource in scnFile.Resources)
                {
                    yield return resource;
                }

                foreach (var prefab in scnFile.Prefabs)
                {
                    yield return prefab;
                }

                foreach (var reference in CollectSceneDependencyReferences(scnFile.ReadScene(context.TypeRepository)))
                {
                    yield return reference;
                }
            }
            else if (versionlessPath.EndsWith(".pfb", StringComparison.OrdinalIgnoreCase))
            {
                var pfbFile = new PfbFile(version, data);
                foreach (var resource in pfbFile.Resources)
                {
                    yield return resource;
                }

                foreach (var reference in CollectSceneDependencyReferences(pfbFile.ReadScene(context.TypeRepository)))
                {
                    yield return reference;
                }
            }
            else if (versionlessPath.EndsWith(".user", StringComparison.OrdinalIgnoreCase))
            {
                var userFile = new UserFile(data);
                foreach (var obj in userFile.GetObjects(context.TypeRepository))
                {
                    foreach (var reference in CollectRszDependencyReferences(obj))
                    {
                        yield return reference;
                    }
                }
            }
        }
        finally
        {
        }
    }

    private static IEnumerable<string> CollectSceneDependencyReferences(RszScene scene)
    {
        foreach (var child in scene.Children)
        {
            foreach (var reference in CollectSceneNodeDependencyReferences(child))
            {
                yield return reference;
            }
        }
    }

    private static IEnumerable<string> CollectSceneNodeDependencyReferences(IRszSceneNode node)
    {
        switch (node)
        {
            case RszFolder folder:
                foreach (var reference in CollectRszDependencyReferences(folder.Settings))
                {
                    yield return reference;
                }
                break;
            case RszGameObject gameObject:
                foreach (var reference in CollectGameObjectDependencyReferences(gameObject))
                {
                    yield return reference;
                }
                break;
        }

        foreach (var child in node.Children)
        {
            foreach (var reference in CollectSceneNodeDependencyReferences(child))
            {
                yield return reference;
            }
        }
    }

    private static IEnumerable<string> CollectGameObjectDependencyReferences(RszGameObject gameObject)
    {
        if (!string.IsNullOrWhiteSpace(gameObject.Prefab))
        {
            yield return gameObject.Prefab;
        }

        foreach (var reference in CollectRszDependencyReferences(gameObject.Settings))
        {
            yield return reference;
        }

        foreach (var component in gameObject.Components)
        {
            foreach (var reference in CollectRszDependencyReferences(component))
            {
                yield return reference;
            }
        }
    }

    private static IEnumerable<string> CollectRszDependencyReferences(IRszNode node)
    {
        switch (node)
        {
            case RszResourceNode resourceNode when !resourceNode.IsEmpty:
                yield return resourceNode.Value!;
                break;
            case RszUserDataNode userDataNode when !userDataNode.IsEmpty:
                yield return userDataNode.Path!;
                break;
        }

        if (node is IRszNodeContainer container)
        {
            foreach (var child in container.Children)
            {
                foreach (var reference in CollectRszDependencyReferences(child))
                {
                    yield return reference;
                }
            }
        }
    }

    private bool TryResolvePakPath(string reference, out string path)
    {
        reference = reference.Replace('\\', '/').Trim();
        if (string.IsNullOrWhiteSpace(reference))
        {
            path = string.Empty;
            return false;
        }

        var versionlessPath = reference.StartsWith("natives/stm/", StringComparison.OrdinalIgnoreCase)
            ? StripVersionSuffix(reference).ToLowerInvariant()
            : PakPath.Of(StripVersionSuffix(reference));

        if (GetPakPathLookup().TryGetValue(versionlessPath, out path!))
        {
            return true;
        }

        path = string.Empty;
        return false;
    }

    private Dictionary<string, string> GetPakPathLookup()
    {
        if (_pakPathByVersionlessPath != null)
        {
            return _pakPathByVersionlessPath;
        }

        _pakPathByVersionlessPath = RandomizerExecutor.GetDefaultPakList()
            .Entries
            .GroupBy(path => StripVersionSuffix(path).ToLowerInvariant(), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First().ToLowerInvariant(), StringComparer.OrdinalIgnoreCase);
        return _pakPathByVersionlessPath;
    }

    private static string StripVersionSuffix(string path)
    {
        var index = path.LastIndexOf('.');
        return index != -1 && int.TryParse(path[(index + 1)..], out _)
            ? path[..index]
            : path;
    }

    private static int GetVersion(string path)
    {
        var index = path.LastIndexOf('.');
        return index != -1 && int.TryParse(path[(index + 1)..], out var version)
            ? version
            : throw new InvalidOperationException($"Unable to determine resource version from '{path}'.");
    }
}
