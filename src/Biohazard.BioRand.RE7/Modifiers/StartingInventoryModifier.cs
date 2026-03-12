using app;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Enums.app;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class StartingInventoryModifier : Modifier
{
    private const string RandomizerKey = "modifier/inventory";
    private const int AntiqueCoinsProbabilityPct = 1;
    private const int AntiqueCoinsCount = 2;

    private readonly Dictionary<MainCampaignCharacter, string> _paths = new()
    {
        { MainCampaignCharacter.Ethan, PakPath.UserFile("leveldesign/fsm/chapter1/other/ch1_startinventory.user") },
        { MainCampaignCharacter.ClancyVHS, PakPath.UserFile("leveldesign/fsm/ff000/other/startinventory_ff000.user") }, // "Derelict House Footage" (Guest House)
        { MainCampaignCharacter.Mia, PakPath.UserFile("leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user") },
        { MainCampaignCharacter.MiaVHS,  PakPath.UserFile("leveldesign/fsm/ff050/other/ff050_startinventory.user") }, // Old Videotape (Ship)
    };

    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

    private List<StartingInventoryItem> GetInventory(Randomizer randomizer, MainCampaignCharacter character)
        => randomizer.FileRepository.DeserializeUserFile<app.AddItemListData>(_paths[character])._AddItems;

    private static void LogVanillaInventory(RandomizerLogger logger, MainCampaignCharacter character, List<StartingInventoryItem> items)
    {
        logger.Push($"{character}'s starting inventory");

        foreach (var item in items)
            logger.LogLine(itemDefinitions.FromId(item.ItemDataID)!.Name!);

        logger.Pop();
    }

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            LogVanillaInventory(logger, character, GetInventory(randomizer, character));
        }
    }

    private (ItemID?, ItemID?) PickRandomWeaponPair(Rng rng, List<StartingWeaponCategory> weapons)
    {
        if (weapons.Count == 0)
            return (null, null);

        ItemID? primaryWeapon = null;
        ItemID? secondaryWeapon = null;

        var allowedWeapons = weapons.ToDictionary(
            category => category,
            category => category.GetItemIds()
        );

        var primaryCandidates = allowedWeapons.Keys
            .Where(cat => cat != StartingWeaponCategory.Bladed)
            .ToList();

        if (primaryCandidates.Count > 0)
        {
            var primaryCategory = rng.Next(primaryCandidates);
            primaryWeapon = rng.Next(allowedWeapons[primaryCategory]);
        }

        if (allowedWeapons.TryGetValue(StartingWeaponCategory.Bladed, out var bladedItems))
        {
            secondaryWeapon = rng.Next(bladedItems);
        }

        return (primaryWeapon, secondaryWeapon);
    }

    private void RandomizeStartingInventory(
        Randomizer randomizer,
        RandomizerLogger logger,
        Rng rng,
        MainCampaignCharacter character,
        List<StartingWeaponCategory> weapons
    )
    {
        if (character == MainCampaignCharacter.ClancyVHS)
        {
            // There are no options for Clancy's starting inventory as the section is pretty much an interactive cutscene.
            // For the memes we are "randomizing" his inventory anyways ;)
            randomizer.FileRepository.ModifyUserFile<AddItemListData>(_paths[character], root =>
            {
                root._AddItems.Add(new() { ItemDataID = ItemID.Handgun_Albert.ToString(), Num = 1 });
                root._AddItems.Add(new() { ItemDataID = "UnlimitedAmmo", Num = 1 });
                return root;
            });

            return;
        }
        else if (character == MainCampaignCharacter.Ethan || character.ToString().StartsWith("Mia", StringComparison.InvariantCultureIgnoreCase))
        {
            var (primary, secondary) = PickRandomWeaponPair(rng, weapons);
            randomizer.FileRepository.ModifyUserFile<AddItemListData>(_paths[character], root =>
            {
                if (primary != null)
                {
                    root._AddItems.Add(
                        new StartingInventoryItem() { ItemDataID = primary.Value.ToString(), Num = 1 }
                    );
                }

                if (secondary != null)
                {
                    root._AddItems.Add(
                        new StartingInventoryItem() { ItemDataID = secondary.Value.ToString()!, Num = 1 }
                    );
                }

                if (rng.NextProbability(AntiqueCoinsProbabilityPct))
                {
                    root._AddItems.Add(new StartingInventoryItem() { ItemDataID = "Coin", Num = AntiqueCoinsCount });
                }
                return root;
            });
        }
        else
        {
            logger.LogLine($"Unknown character '{character}'!");
        }
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var randomizeEthansInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-ethan");
        var randomizeMiasInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-mia");

        if (!randomizeEthansInventory && !randomizeMiasInventory)
        {
            return;
        }

        var rng = randomizer.GetRng(RandomizerKey);

        // Starter weapons
        var categories = Enum.GetValues<StartingWeaponCategory>();
        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            if (character == MainCampaignCharacter.Ethan && !randomizeEthansInventory)
                continue;

            if ((character == MainCampaignCharacter.Mia || character == MainCampaignCharacter.MiaVHS) && !randomizeMiasInventory)
                continue;

            var configuredCategories = new List<StartingWeaponCategory>();
            foreach (var category in categories)
            {
                if (randomizer.GetConfigOption<bool>(
                    $"inventory-weapon-{category.ToString().ToLowerInvariant()}-{character.ToString().ToLowerInvariant()}")
                )
                {
                    configuredCategories.Add(category);
                }
            }

            RandomizeStartingInventory(randomizer, logger, rng, character, configuredCategories);
        }
    }
}