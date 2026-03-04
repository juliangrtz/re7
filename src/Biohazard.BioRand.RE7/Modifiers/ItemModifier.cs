using Biohazard.BioRand.RE7.Items;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class ItemModifier : Modifier
{
    private readonly string itemDir = PakPath.Of("prefab/item");
    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

    private static Dictionary<ItemDefinition, int> GetItemsWithCustomStackSize(RE7Randomizer randomizer)
    {
        var result = new Dictionary<ItemDefinition, int>();

        foreach (var item in itemDefinitions)
        {
            if (!item.IsStackable || item.IsDlcItem)
                continue;

            var configuredStackSize = randomizer.GetConfigOption($"inventory-stack-limit-{item.Id.ToLowerInvariant()}", 0);
            if (configuredStackSize != 0)
            {
                result[item] = configuredStackSize;
            }
        }

        return result;
    }

    public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        var customStacks = GetItemsWithCustomStackSize(randomizer);
        logger.Push("Stack sizes");
        foreach (var item in itemDefinitions)
        {
            if (!item.IsStackable || item.IsDlcItem)
                continue;

            var logLine = $"{item.Name} ({item.Id}), stack = {item.MaxStack}";

            if (customStacks.TryGetValue(item, out var newSize))
            {
                logLine += $", new stack = {newSize}";
            }

            logger.LogLine(logLine);
        }
        logger.Pop();
    }

    public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        var customStacks = GetItemsWithCustomStackSize(randomizer);

        foreach (var group in customStacks
            .Where(it => it.Key != null)
            .GroupBy(it => it.Key.SourceUserFile)
        )
        {
            var stackSizeByItemId = group.ToDictionary(
                it => it.Key.Id,
                it => it.Value
            );

            randomizer.FileRepository.ModifyUserFile<app.ItemSettings>($"{itemDir}/{group.Key!}", root =>
            {
                foreach (var setting in root._Settings)
                {
                    if (stackSizeByItemId.TryGetValue(setting.ItemDataID, out var newStackSize))
                        setting.MaxStackNum = newStackSize;
                }

                return root;
            });

            logger.LogLine($"Patched {group.Key!}.");
        }
    }
}