using Biohazard.BioRand.RE7.Items;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class InventoryModifier : Modifier
{
    private readonly string EthanStartingInventoryPath = PakPath.Of("leveldesign/fsm/chapter1/other/ch1_startinventory.user.2");
    private readonly string MiaStartingInventoryPath = PakPath.Of("leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user.2");
    private readonly string MiaStartingInventoryFF050Path = PakPath.Of("leveldesign/fsm/ff050/other/ff050_startinventory.user.2"); // VHS: Old Videotape
    private readonly string ClancyStartingInventoryFF000Path = PakPath.Of("leveldesign/fsm/ff000/other/startinventory_ff000.user.2"); // VHS: "Derelict House Footage"

    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

    private List<StartingInventoryItem> GetInventory(RE7Randomizer randomizer, string path)
        => randomizer.FileRepository.DeserializeUserFile<app.AddItemListData>(path)._AddItems;

    private static void LogVanillaInventory(RandomizerLogger logger, string name, List<StartingInventoryItem> items)
    {
        logger.Push($"{name} starting inventory");

        foreach (var item in items)
            logger.LogLine(itemDefinitions.FromId(item.ItemDataID)!.Name!);

        logger.Pop();
    }

    public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        LogVanillaInventory(logger, "Ethan (Chapter 1)", GetInventory(randomizer, EthanStartingInventoryPath));
        LogVanillaInventory(logger, "Mia (Chapter 4)", GetInventory(randomizer, MiaStartingInventoryPath));
        LogVanillaInventory(logger, "Mia (Chapter 4, VHS)", GetInventory(randomizer, MiaStartingInventoryFF050Path));
        LogVanillaInventory(logger, "Clancy (Chapter 1, VHS)", GetInventory(randomizer, ClancyStartingInventoryFF000Path));
    }

    public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        // TODO
    }
}