using Biohazard.BioRand.RE7.Items;

namespace Biohazard.BioRand.RE7.Extensions;

public static class Re7TypeExtensions
{
    private static readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    public static string Format(this Recipe recipe)
    {
        var readableSrc1 = _itemDefinitions.FromId(recipe.SrcItemID1)?.Name ?? recipe.SrcItemID1;
        var readableSrc2 = _itemDefinitions.FromId(recipe.SrcItemID2)?.Name ?? recipe.SrcItemID2;
        var readableResult = _itemDefinitions.FromId(recipe.ResultItemID)?.Name ?? recipe.ResultItemID;

        return $"{recipe.SrcItemNum1,3}x {readableSrc1,-30} + " +
            $"{recipe.SrcItemNum2,3}x {readableSrc2,-30} -> " +
            $"{recipe.ResultItemNum,3}x {readableResult,-30}";
    }

    public static void Log(this ItemDropTable table, RandomizerLogger logger)
    {
        foreach (var item in table.DataList)
        {
            var name = _itemDefinitions.FromId(item.ItemID)?.Name ?? item.ItemID;
            logger.Push(name);
            logger.LogLine($"Easy drop rate: {item.EasyDropRate} %");
            logger.LogLine($"Normal drop rate: {item.NormalDropRate} %");
            logger.LogLine($"Madhouse drop rate: {item.HardDropRate} %");
            logger.LogLine($"Easy drop amount: {item.ReliefNum}");
            logger.LogLine($"Normal drop amount: {item.NormalDropNum}");
            logger.LogLine($"Madhouse drop amount: {item.ReliefDropNum}");
            logger.Pop();
        }
    }
}
