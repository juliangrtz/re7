using app;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Weapons;
using Enums.app;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class StartingInventoryModifier : Modifier
{
    private const string RandomizerKey = "modifier/inventory";
    private const int AntiqueCoinsProbabilityPct = 1;
    private const int AntiqueCoinsCount = 2;
    private static readonly string[] StartingSkillLevelOneIds =
    [
        "skl009", // Defense I
        "skl011", // Speed Up I
        "skl013", // Firepower Up I
        "skl015", // Impact I
        "skl017", // Toughness I
        "skl018", // Guard Up
        "skl019", // Quick Reload
        "skl021", // Vengeance
        "skl022", // Narrow Escape
    ];
    private static readonly string[] StartingSkillLevelTwoIds =
    [
        "skl002", // Health Regen
        "skl008", // Defense II
        "skl010", // Speed Up II
        "skl012", // Firepower Up II
        "skl014", // Impact II
        "skl016", // Toughness II
        "skl023", // Brawler
    ];

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

    private record DebugStartItem
    {
        public string ItemId { get; init; } = "";
        public int Quantity { get; init; }
        public string Comment { get; init; } = "";
        public DebugStartItem() { }
    }

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
        Rng inventoryRng,
        Rng skillRng,
        MainCampaignCharacter character,
        bool randomizeInventory,
        bool giveRandomSkills,
        List<StartingWeaponCategory> weapons
    )
    {
        var giveAmmo = randomizer.GetConfigOption<bool>("random-starting-inventory-give-ammo");
        var (primary, secondary) = randomizeInventory
            ? PickRandomWeaponPair(inventoryRng, weapons)
            : ((ItemID?)null, (ItemID?)null);
        var path = _paths[character];
        logger.Push($"{character} @ {path}");
        randomizer.FileRepository.ModifyUserFile<AddItemListData>(path, root =>
        {
            if (randomizeInventory && primary != null)
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
                        var ammoCount = inventoryRng.Next(min, max);
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

            if (randomizeInventory && secondary != null)
            {
                logger.LogLine($"Secondary weapon: {secondary}");
                root._AddItems.Add(
                    new StartingInventoryItem() { ItemDataID = secondary.Value.ToString()!, Num = 1 }
                );
            }

            if (randomizeInventory && inventoryRng.NextProbability(AntiqueCoinsProbabilityPct))
            {
                logger.LogLine($"Nice! {AntiqueCoinsCount}x extra antique coin(s)!");
                root._AddItems.Add(new StartingInventoryItem() { ItemDataID = "Coin", Num = AntiqueCoinsCount });
            }

#if !DEBUG
            if (randomizer.UserTags.Contains("re7:debugstartitems"))
            {
#endif
            if (randomizeInventory)
            {
                var debugItems = Csv.Deserialize<DebugStartItem>(randomizer.DynamicData.GetData(DynamicDataName.DebugStartItems)!)
                    .Where(x => x.Quantity > 0)
                    .Select(x => new StartingInventoryItem() { ItemDataID = x.ItemId, Num = x.Quantity })
                    .ToArray();

                if (debugItems.Any())
                {
                    logger.LogLine($"Adding debug items: {string.Join(", ", debugItems.Select(x => $"{x.Num}x {x.ItemDataID}"))}");
                    root._AddItems.AddRange(debugItems);
                }
            }
#if !DEBUG
            }
#endif

            if (giveRandomSkills)
            {
                var skills = PickRandomStartingSkills(skillRng);
                logger.LogLine($"Random starting skill(s): {string.Join(", ", skills)}");
                root._AddItems.AddRange(skills.Select(id => new StartingInventoryItem()
                {
                    ItemDataID = id,
                    Num = 1,
                }));
            }

            return root;
        });
        logger.Pop();
    }

    private static List<string> PickRandomStartingSkills(Rng rng)
    {
        var result = new List<string>();

        result.Add(rng.Next(StartingSkillLevelOneIds));

        var skillCount = rng.Next(1, 3);
        if (skillCount == 2)
        {
            var secondPool = rng.CoinToss()
                ? StartingSkillLevelOneIds.Where(id => !result.Contains(id)).ToArray()
                : StartingSkillLevelTwoIds;
            result.Add(rng.Next(secondPool));
        }

        return result;
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var randomizeEthansInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-ethan");
        var randomizeMiasInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-mia");
        var randomizeVhs = randomizer.GetConfigOption<bool>("random-starting-inventory-vhs");
        var giveRandomSkillsEthan = randomizer.GetConfigOption<bool>("random-starting-inventory-skills-ethan");
        var giveRandomSkillsMia = randomizer.GetConfigOption<bool>("random-starting-inventory-skills-mia");

        if (!randomizeEthansInventory && !randomizeMiasInventory && !giveRandomSkillsEthan && !giveRandomSkillsMia)
        {
            return;
        }

        var rng = randomizer.GetRng(RandomizerKey);

        // Starter weapons
        var categories = Enum.GetValues<StartingWeaponCategory>();
        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            var shouldRandomizeInventory = character switch
            {
                MainCampaignCharacter.Ethan => randomizeEthansInventory,
                MainCampaignCharacter.Mia => randomizeMiasInventory,
                MainCampaignCharacter.ClancyVHS => randomizeVhs && (randomizeEthansInventory || randomizeMiasInventory),
                MainCampaignCharacter.MiaVHS => randomizeMiasInventory && randomizeVhs,
                _ => false,
            };
            var shouldGiveRandomSkills = character switch
            {
                MainCampaignCharacter.Ethan => giveRandomSkillsEthan,
                MainCampaignCharacter.Mia => giveRandomSkillsMia,
                _ => false,
            };

            if (!shouldRandomizeInventory && !shouldGiveRandomSkills)
                continue;

            var configuredCategories = new List<StartingWeaponCategory>();
            if (shouldRandomizeInventory && character is MainCampaignCharacter.ClancyVHS) // Allow all weapons for Clancy, it doesn't really matter
            {
                configuredCategories = Enum.GetValues<StartingWeaponCategory>().ToList();
            }
            else if (shouldRandomizeInventory)
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


            RandomizeStartingInventory(
                randomizer,
                logger,
                rng,
                randomizer.GetRng(RandomizerKey, "skills", character),
                character,
                shouldRandomizeInventory,
                shouldGiveRandomSkills,
                configuredCategories);
        }
    }
}
