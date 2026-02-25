using app;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Enums.app;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class InventoryModifier : Modifier
{
    private readonly Dictionary<MainCampaignCharacter, string> _paths = new()
    {
        { MainCampaignCharacter.Ethan, PakPath.Of("leveldesign/fsm/chapter1/other/ch1_startinventory.user.2") },
        { MainCampaignCharacter.ClancyVHS, PakPath.Of("leveldesign/fsm/ff000/other/startinventory_ff000.user.2") }, // "Derelict House Footage" (Guest House)
        { MainCampaignCharacter.Mia, PakPath.Of("leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user.2") },
        { MainCampaignCharacter.MiaVHS,  PakPath.Of("leveldesign/fsm/ff050/other/ff050_startinventory.user.2") }, // Old Videotape (Ship)
    };

    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

    private List<StartingInventoryItem> GetInventory(RE7Randomizer randomizer, MainCampaignCharacter character)
        => randomizer.FileRepository.DeserializeUserFile<app.AddItemListData>(_paths[character])._AddItems;

    private static void LogVanillaInventory(RandomizerLogger logger, MainCampaignCharacter character, List<StartingInventoryItem> items)
    {
        logger.Push($"{character}'s starting inventory");

        foreach (var item in items)
            logger.LogLine(itemDefinitions.FromId(item.ItemDataID)!.Name!);

        logger.Pop();
    }

    public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            LogVanillaInventory(logger, character, GetInventory(randomizer, character));
        }
    }

    private void RandomizeInventory(
        RE7Randomizer randomizer,
        RandomizerLogger logger,
        MainCampaignCharacter character,
        List<StartingWeaponCategory> weapons
    )
    {
        if (character == MainCampaignCharacter.ClancyVHS)
        {
            // There are no options for Clancy's starting inventory as the section is pretty much an interactive cutscene.
            // For the memes we are randomizing his inventory anyways ;)
            randomizer.FileRepository.ModifyUserFile<AddItemListData>(_paths[character], root =>
            {
                root._AddItems.Add(new() { ItemDataID = ItemID.Handgun_Albert.ToString(), Num = 1 });
                root._AddItems.Add(new() { ItemDataID = "UnlimitedAmmo", Num = 1 });
                return root;
            });

            return;
        }
        else if (character == MainCampaignCharacter.Ethan)
        {
        }
        else if (character.ToString().StartsWith("Mia", StringComparison.InvariantCultureIgnoreCase))
        {
        }
        else
        {
            logger.LogLine($"Unknown character '{character}'!");
        }
    }

    public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        var randomizeEthanInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-ethan");
        var randomizeMiaInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-mia");

        if (!randomizeEthanInventory && !randomizeMiaInventory)
        {
            return;
        }

        var ethanInventoryMode = randomizer.GetConfigOption<string>("random-starting-inventory-mode-ethan");
        var miaInventoryMode = randomizer.GetConfigOption<string>("random-starting-inventory-mode-mia");
        var ethanInventorySize = randomizer.GetConfigOption<string>("random-starting-inventory-size-ethan");
        var miaInventorySize = randomizer.GetConfigOption<string>("random-starting-inventory-size-mia");

        //var characterToWeaponMap = new Dictionary<MainCampaignCharacter, List<StartingWeaponCategory>>();
        var categories = Enum.GetValues<StartingWeaponCategory>();

        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            var list = new List<StartingWeaponCategory>();
            foreach (var category in categories)
            {
                if (randomizer.GetConfigOption<bool>(
                    $"inventory-weapon-{category.ToString().ToLowerInvariant()}-{character.ToString().ToLowerInvariant()}")
                )
                {
                    list.Add(category);
                }
            }

            //characterToWeaponMap.Add(character, list);
            RandomizeInventory(randomizer, logger, character, list);
        }
    }
}