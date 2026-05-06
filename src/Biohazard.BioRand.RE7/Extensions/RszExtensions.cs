using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Extensions;

public static class RszExtensions
{
    public static RszGameObject CloneWithNewGuids(
        this RszGameObject rootGameObject,
        Rng rng,
        Guid? rootGuid = null)
    {
        var guidMap = new Dictionary<Guid, Guid>();
        var isRoot = true;
        var root = rootGameObject.VisitGameObjects(gameObject =>
        {
            var newGuid = rootGuid.HasValue && isRoot
                ? rootGuid.Value
                : rng.NextGuid();
            isRoot = false;
            guidMap[gameObject.Guid] = newGuid;
            return gameObject.WithGuid(newGuid);
        });

        return ReplaceGameObjectRefs(root, guidMap);
    }

    private static RszGameObject ReplaceGameObjectRefs(
        RszGameObject gameObject,
        IReadOnlyDictionary<Guid, Guid> guidMap)
    {
        return gameObject.Visit(node =>
        {
            if (node is RszValueNode valueNode && valueNode.Type == RszFieldType.GameObjectRef)
            {
                var refGuid = RszSerializer.Deserialize<Guid>(valueNode);
                if (guidMap.TryGetValue(refGuid, out var newGuid))
                {
                    return RszSerializer.Serialize(RszFieldType.GameObjectRef, newGuid);
                }
            }

            return node;
        });
    }

#if false
    public static Dictionary<string, object> ToDictionary(this RszInstance instance)
    {
        var dict = new Dictionary<string, object>();
        for (var i = 0; i < instance.Fields.Length; i++)
        {
            var field = instance.Fields[i];
            if (instance.Values.Length <= i)
                continue;

            var value = instance.Values[i];
            if (value is RszInstance child)
            {
                value = ToDictionary(child);
            }
            else if (value is List<object> list)
            {
                var copy = list.ToList();
                for (var j = 0; j < copy.Count; j++)
                {
                    if (copy[j] is RszInstance el)
                    {
                        copy[j] = ToDictionary(el);
                    }
                }
                value = copy;
            }
            dict[field.name] = value;
        }
        return dict;
    }

    public static string ToSimpleJson(this RszInstance instance)
    {
        var dict = ToDictionary(instance);
        return JsonSerializer.Serialize(dict, new JsonSerializerOptions()
        {
            IncludeFields = true,
            WriteIndented = true
        });
    }
#endif

    public static RszObjectNode Serialize<T>(this RszTypeRepository repo, T obj)
    {
        return (RszObjectNode)RszSerializer.Serialize(
            repo.FromName(obj!.GetType().FullName!)!,
            obj);
    }

    public static RszScene Add(
        this RszScene scene,
        RszTypeRepository repo,
        SceneHierachyPath hier,
        RszGameObject gameObject)
    {
        var folders = hier.Folders;
        var updatedRoot = AddToNode(scene, 0);
        return (RszScene)updatedRoot;

        IRszSceneNode AddToNode(
            IRszSceneNode node,
            int index)
        {
            if (index >= folders.Count)
            {
                // No more folders, add the game object here
                return node.WithChildren(node.Children.Add(gameObject));
            }

            // Find or add folder
            var folderName = folders[index];
            var childIndex = node.Children
                .FindIndex(x => x is RszFolder f && f.Name == folderName);
            var child = childIndex != -1
                ? node.Children[childIndex]
                : new RszFolder(
                    repo.Create("via.Folder")
                        .Set("Name", folderName)
                        .Set("Update", true)
                        .Set("Draw", true)
                        .Set("Startup", true),
                    []);

            // Add sub folders/game object
            child = AddToNode(child, index + 1);

            // Rebuild root
            return childIndex != -1
                ? node.WithChildren(node.Children.SetItem(childIndex, child))
                : node.WithChildren(node.Children.Add(child));
        }
    }

    public static List<RszGameObject> GetGameObjects(this RszScene scene)
    {
        var result = new List<RszGameObject>();
        scene.VisitGameObjects(go => result.Add(go));
        return result;
    }

    public static T ReplaceGameObject<T>(
        this T node,
        Guid targetGuid,
        RszGameObject replacement,
        bool keepChildren = true)
    where T : IRszSceneNode
    {
        if (node.Children.IsDefaultOrEmpty)
            return node;

        var children = node.Children.ToBuilder();

        for (var i = 0; i < children.Count; i++)
        {
            if (children[i] is RszGameObject oldGameObject && oldGameObject.Guid == targetGuid)
            {
                var newGameObject = replacement;

                if (keepChildren)
                {
                    newGameObject = newGameObject.WithChildren(oldGameObject.Children);
                }

                newGameObject = newGameObject.WithGuid(oldGameObject.Guid);

                children[i] = newGameObject;
            }
            else
            {
                children[i] = children[i].ReplaceGameObject(targetGuid, replacement, keepChildren);
            }
        }

        return (T)node.WithChildren(children.ToImmutable());
    }
}
