using app;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Weapons;
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
    private static readonly WeaponDefinitionRepository weaponDefinitions = WeaponDefinitionRepository.Default;

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

    // Returns a random gun and bladed weapon
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

    // (min, max)
    private (int, int) DetermineAppropriateStartingAmmoCount(WeaponID wp) => wp switch
    {
        WeaponID.Handgun => (10, 20),
        WeaponID.Handgun_M19 => (10, 20),
        WeaponID.Handgun_G17 => (10, 20),
        WeaponID.Handgun_MPM => (10, 20),
        WeaponID.Handgun_Albert => (10, 15),
        WeaponID.Handgun_Albert_Reward => (5, 8),
        WeaponID.ShotGun => (5, 10),
        WeaponID.Shotgun_M37 => (5, 10),
        WeaponID.Shotgun_M37S => (5, 10),
        WeaponID.Shotgun_DB => (5, 10),
        WeaponID.MachineGun => (30, 50),
        WeaponID.Magnum => (1, 5),
        WeaponID.GrenadeLauncher => (1, 1),
        WeaponID.Burner => (75, 150),
        _ => (0, 0)
    };

    private void RandomizeStartingInventory(
        Randomizer randomizer,
        RandomizerLogger logger,
        Rng rng,
        MainCampaignCharacter character,
        List<StartingWeaponCategory> weapons
    )
    {
        var giveAmmo = randomizer.GetConfigOption<bool>("random-starting-inventory-give-ammo");
        var (primary, secondary) = PickRandomWeaponPair(rng, weapons);
        var path = _paths[character];
        logger.Push($"{character} @ {path}");
        randomizer.FileRepository.ModifyUserFile<AddItemListData>(path, root =>
        {
            if (primary != null)
            {
                logger.LogLine($"Primary weapon: {primary}");
                var id = primary.Value.ToString();
                root._AddItems.Add(
                    new StartingInventoryItem() { ItemDataID = id, Num = 1 }
                );

                if (giveAmmo && Enum.TryParse(id, out WeaponID wpId))
                {
                    foreach (var ammoType in weaponDefinitions.GetAmmoTypes(wpId))
                    {
                        if (/*rng.CoinToss() &&*/ ammoType == AmmoTypes.Get(wpId)?.StrongAmmo)
                            continue;

                        (int min, int max) = DetermineAppropriateStartingAmmoCount(wpId);
                        var ammoCount = rng.Next(min, max);
                        if (ammoCount == 0)
                        {
                            logger.LogLine("Avoiding extra ammo (unsupported weapon type).");
                            continue;
                        }

                        logger.LogLine($"Extra ammo: {ammoCount}x {ammoType}");
                        root._AddItems.Add(
                            new StartingInventoryItem() { ItemDataID = ammoType.ToString(), Num = ammoCount }
                        );
                    }
                }
            }

            if (secondary != null)
            {
                logger.LogLine($"Secondary weapon: {secondary}");
                root._AddItems.Add(
                    new StartingInventoryItem() { ItemDataID = secondary.Value.ToString()!, Num = 1 }
                );
            }

            if (rng.NextProbability(AntiqueCoinsProbabilityPct))
            {
                logger.LogLine($"Nice! {AntiqueCoinsCount}x extra antique coin(s)!");
                root._AddItems.Add(new StartingInventoryItem() { ItemDataID = "Coin", Num = AntiqueCoinsCount });
            }

            return root;
        });
        logger.Pop();
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var randomizeEthansInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-ethan");
        var randomizeMiasInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-mia");
        var randomizeVhs = randomizer.GetConfigOption<bool>("random-starting-inventory-vhs");

        if (!randomizeEthansInventory && !randomizeMiasInventory)
        {
            return;
        }

        var rng = randomizer.GetRng(RandomizerKey);

        // Starter weapons
        var categories = Enum.GetValues<StartingWeaponCategory>();
        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            if (!randomizeVhs && character is MainCampaignCharacter.ClancyVHS or MainCampaignCharacter.MiaVHS)
                continue;

            if (!randomizeEthansInventory && character is MainCampaignCharacter.Ethan)
                continue;

            if (!randomizeMiasInventory && character is MainCampaignCharacter.Mia or MainCampaignCharacter.MiaVHS)
                continue;

            var configuredCategories = new List<StartingWeaponCategory>();
            if (character is MainCampaignCharacter.ClancyVHS) // Allow all weapons for Clancy, it doesn't really matter
            {
                configuredCategories = Enum.GetValues<StartingWeaponCategory>().ToList();
            }
            else
            {
                foreach (var category in categories)
                {
                    var characterStr = character is MainCampaignCharacter.MiaVHS ? "mia" : character.ToString().ToLowerInvariant();
                    if (randomizer.GetConfigOption<bool>(
                        $"inventory-weapon-{category.ToString().ToLowerInvariant()}-{characterStr}")
                    )
                    {
                        configuredCategories.Add(category);
                    }
                }
            }


            RandomizeStartingInventory(randomizer, logger, rng, character, configuredCategories);
        }
    }
}