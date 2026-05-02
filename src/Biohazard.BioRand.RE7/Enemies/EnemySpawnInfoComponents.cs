using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies;

public static class EnemySpawnInfoComponents
{
    public const string DlcSpawnInfoOptionType = "app.EnemySpawnInfoOptionDLC";

    public static bool IsSpawnInfo(string typeName)
        => typeName is "app.EnemySpawnInfo" or "app.CH8EnemySpawnInfo" or "app.CH9EnemySpawnInfo";

    public static bool IsEnemySpecificSpawnInfoOption(string typeName)
        => typeName.StartsWith("app.EnemySpawnInfoOptionEm", StringComparison.Ordinal) ||
           typeName.StartsWith("app.CH8EnemySpawnInfoOptionEm", StringComparison.Ordinal) ||
           typeName.StartsWith("app.CH9EnemySpawnInfoOptionEm", StringComparison.Ordinal);

    public static bool IsDlcSpawnInfoOption(string typeName)
        => typeName == DlcSpawnInfoOptionType;

    public static RszObjectNode? FindSpawnInfoNode(RszGameObject gameObject)
        => gameObject.Components.FirstOrDefault(component => IsSpawnInfo(component.Type.Name));

    public static app.EnemySpawnInfo? FindSpawnInfo(RszGameObject gameObject)
    {
        var node = FindSpawnInfoNode(gameObject);
        return node == null ? null : RszSerializer.Deserialize<app.EnemySpawnInfo>(node);
    }
}
