using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies;

internal static class EnemyGenerationComponents
{
    public const string EnemyGeneratorType = "app.EnemyGenerator";
    public const string Ch8EnemyGeneratorType = "app.CH8EnemyGenerator";
    public const string EnemyPoolType = "app.EnemyPool";
    public const string Ch8EnemyPoolType = "app.CH8EnemyPool";

    public static bool IsEnemyGenerator(string typeName)
        => typeName is EnemyGeneratorType or Ch8EnemyGeneratorType;

    public static bool IsEnemyPool(string typeName)
        => typeName is EnemyPoolType or Ch8EnemyPoolType;

    public static RszObjectNode? FindGeneratorNode(RszGameObject gameObject)
        => gameObject.Components.FirstOrDefault(component => IsEnemyGenerator(component.Type.Name));

    public static RszObjectNode? FindPoolNode(RszGameObject gameObject)
        => gameObject.Components.FirstOrDefault(component => IsEnemyPool(component.Type.Name));

    public static bool IsEnabled(RszObjectNode component)
        => component.Type.FindFieldIndex("Enabled") == -1 ||
           RszSerializer.Deserialize<bool>(component["Enabled"]);

    public static string GetAlias(RszObjectNode generator)
        => generator.Type.FindFieldIndex("Alias") == -1
            ? string.Empty
            : ((RszStringNode)generator["Alias"]).Value;

    public static RszObjectNode ChangeComponentType(RszObjectNode source, RszTypeRepository repository, string targetTypeName)
    {
        if (source.Type.Name == targetTypeName)
        {
            return source;
        }

        var target = repository.Create(targetTypeName);
        foreach (var targetField in target.Type.Fields)
        {
            if (source.Type.FindFieldIndex(targetField.Name) is var sourceIndex && sourceIndex != -1)
            {
                target = target.SetField(targetField.Name, source.Children[sourceIndex]);
            }
        }

        return target;
    }
}
