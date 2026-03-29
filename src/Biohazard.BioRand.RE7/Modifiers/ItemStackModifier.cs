using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class ItemStackModifier : Modifier
{
    private readonly string itemDir = PakPath.Of("prefab/item");
    private const int MaxStackSize = 999;
    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

    private static Dictionary<ItemDefinition, int> GetItemsWithCustomStackSize(Randomizer randomizer)
    {
        var result = new Dictionary<ItemDefinition, int>();

        foreach (var item in itemDefinitions.Items)
        {
            if (!item.IsStackable || item.IsDlcItem)
                continue;

            var configuredStackSize = randomizer.GetConfigOption($"inventory-stack-limit-{item.Id.ToLowerInvariant()}", item.MaxStack);
            if (configuredStackSize != item.MaxStack)
            {
                result[item] = configuredStackSize;
            }
        }

        return result;
    }

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        var customStacks = GetItemsWithCustomStackSize(randomizer);
        logger.Push("Stack sizes");
        foreach (var item in itemDefinitions.Items)
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

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var customStacks = GetItemsWithCustomStackSize(randomizer);

        if (customStacks.Count == 0)
        {
            logger.LogLine("All item stacks are equal to the vanilla values.");
        }

        foreach (var group in customStacks
            .Where(it => it.Key != null)
            .GroupBy(it => it.Key.SourceUserFile)
        )
        {
            var stackSizeByItemId = group.ToDictionary(
                it => it.Key.Id,
                it => it.Value
            );

            randomizer.FileRepository.ModifyUserFile<app.ItemSettings>($"{itemDir}/{group.Key}", root =>
            {
                foreach (var setting in root._Settings)
                {
                    if (stackSizeByItemId.TryGetValue(setting.ItemDataID, out var newStackSize))
                        setting.MaxStackNum = Math.Clamp(newStackSize, 0, MaxStackSize);
                }

                return root;
            });

            logger.LogLine($"Patched {group.Key}.");
        }
    }
}