using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies;

internal static class EnemyGenerateActionComponents
{
    public const string EnemyGenerateType = "app.fsm.EnemyGenerate";
    public const string Ch8EnemyGenerateType = "app.fsm.CH8EnemyGenerate";
    public const string Ch8EnemyGenerateCrossPositionType = "app.fsm.CH8EnemyGenerateCrossPosition";

    private static readonly HashSet<string> RuntimeOnlyFields =
    [
        "mySpawnInfo",
        "isFailedRequest"
    ];

    public static bool IsSingleEnemyGenerateAction(RszObjectNode objectNode)
        => objectNode.Type.Name is EnemyGenerateType or Ch8EnemyGenerateType or Ch8EnemyGenerateCrossPositionType;

    public static bool IsEnabled(RszObjectNode objectNode)
        => objectNode.Type.FindFieldIndex("v0_Enabled") == -1 ||
           RszSerializer.Deserialize<bool>(objectNode["v0_Enabled"]);

    public static Guid GetSpawnInfo(RszObjectNode objectNode)
        => objectNode.Type.FindFieldIndex("SpawnInfo") == -1
            ? Guid.Empty
            : RszSerializer.Deserialize<Guid>(objectNode["SpawnInfo"]);

    public static RszObjectNode SetSpawnInfo(RszObjectNode objectNode, Guid spawnInfo)
        => objectNode.SetField("SpawnInfo", spawnInfo);

    public static RszObjectNode Disable(RszObjectNode objectNode)
        => SetSpawnInfo(objectNode.SetField("v0_Enabled", false), Guid.Empty);

    public static RszObjectNode EnableForSpawnInfo(RszObjectNode objectNode, Guid spawnInfo)
        => SetSpawnInfo(objectNode.SetField("v0_Enabled", true), spawnInfo);

    public static RszObjectNode ChangeActionType(
        RszObjectNode source,
        RszTypeRepository repository,
        string targetTypeName)
    {
        if (source.Type.Name == targetTypeName)
        {
            return source;
        }

        var target = repository.Create(targetTypeName);
        foreach (var targetField in target.Type.Fields)
        {
            if (RuntimeOnlyFields.Contains(targetField.Name))
            {
                continue;
            }

            if (source.Type.FindFieldIndex(targetField.Name) is var sourceIndex && sourceIndex != -1)
            {
                target = target.SetField(targetField.Name, source.Children[sourceIndex]);
            }
        }

        return target;
    }
}
