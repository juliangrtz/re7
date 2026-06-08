using app;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using IntelOrca.Biohazard.BioRand.REE;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class StartingInventoryModifier : Modifier {
    private readonly Randomizer _randomizer;

    public StartingInventoryModifier(Randomizer randomizer) {
        _randomizer = randomizer;
    }

    private const string RandomizerKey = "modifier/inventory";
    private const int AntiqueCoinsProbabilityPct = 1;
    private const int AntiqueCoinsCount = 2;

    private static readonly (ItemID ItemId, int Count)[] StarterHealing =[
        (ItemID.RemedyM, 1),
        (ItemID.RemedyL, 1),
    ];

    private static readonly Dictionary<WeaponID, (ItemID ItemId, int Count)[]> StarterAmmoLoadouts = new(){
        [WeaponID.Handgun] =[(ItemID.HandgunBullet, 20), (ItemID.HandgunBulletL, 20)],
        [WeaponID.Handgun_M19] =[(ItemID.HandgunBullet, 20), (ItemID.HandgunBulletL, 20)],
        [WeaponID.Handgun_G17] =[(ItemID.HandgunBullet, 20), (ItemID.HandgunBulletL, 20)],
        [WeaponID.Handgun_MPM] =[(ItemID.HandgunBullet, 20), (ItemID.HandgunBulletL, 20)],
        [WeaponID.Handgun_Albert] =[(ItemID.HandgunBullet, 20), (ItemID.HandgunBulletL, 20)],
        [WeaponID.Handgun_Albert_Reward] =[(ItemID.HandgunBullet, 20), (ItemID.HandgunBulletL, 20)],
        [WeaponID.ShotGun] =[(ItemID.ShotgunBullet, 15)],
        [WeaponID.Shotgun_M37] =[(ItemID.ShotgunBullet, 15)],
        [WeaponID.Shotgun_M37S] =[(ItemID.ShotgunBullet, 15)],
        [WeaponID.Shotgun_DB] =[(ItemID.ShotgunBullet, 15)],
        [WeaponID.MachineGun] =[(ItemID.MachineGunBullet, 150)],
        [WeaponID.Magnum] =[(ItemID.MagnumBullet, 10)],
        [WeaponID.GrenadeLauncher] =[(ItemID.FlameBulletS, 3), (ItemID.AcidBulletS, 3)],
        [WeaponID.Burner] =[(ItemID.BurnerBullet, 150)],
    };

    private static readonly string[] StartingSkillLevelOneIds =[
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

    private readonly Dictionary<MainCampaignCharacter, string> _paths = new(){
        { MainCampaignCharacter.Ethan, "leveldesign/fsm/chapter1/other/ch1_startinventory.user".UserFile() },{
            MainCampaignCharacter.ClancyVHS, "leveldesign/fsm/ff000/other/startinventory_ff000.user".UserFile()
        }, // "Derelict House Footage" (Guest House)
        {
            MainCampaignCharacter.Mia,
            "leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user".UserFile()
        },{
            MainCampaignCharacter.MiaVHS, "leveldesign/fsm/ff050/other/ff050_startinventory.user".UserFile()
        }, // Old Videotape (Ship)
    };

    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

    private List<StartingInventoryItem> GetInventory(Randomizer randomizer, MainCampaignCharacter character)
        => randomizer.FileRepository.DeserializeUserFile<app.AddItemListData>(_paths[character])._AddItems;

    private record DebugStartItem {
        public string ItemId { get; init; } = "";
        public int Quantity { get; init; }
        public string Comment { get; init; } = "";
        public DebugStartItem() { }
    }

    private static void LogVanillaInventory(RandomizerLogger logger, MainCampaignCharacter character,
        List<StartingInventoryItem> items) {
        logger.Push($"{character}'s starting inventory");

        foreach (var item in items)
            logger.LogLine(itemDefinitions.FromId(item.ItemDataID)!.Name!);

        logger.Pop();
    }

    public override void LogState(RandomizerLogger logger) {
        var randomizer = _randomizer;
        foreach (var character in Enum.GetValues<MainCampaignCharacter>()) {
            LogVanillaInventory(logger, character, GetInventory(randomizer, character));
        }
    }

    // Returns a random gun and bladed weapon
    private (ItemID?, ItemID?) PickRandomWeaponPair(Rng rng, List<StartingWeaponCategory> weapons) {
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

        if (primaryCandidates.Count > 0) {
            var primaryCategory = rng.Next(primaryCandidates);
            primaryWeapon = rng.Next(allowedWeapons[primaryCategory]);
        }

        if (allowedWeapons.TryGetValue(StartingWeaponCategory.Bladed, out var bladedItems)) {
            secondaryWeapon = rng.Next(bladedItems);
        }

        return (primaryWeapon, secondaryWeapon);
    }

    private void RandomizeStartingInventory(
        Randomizer randomizer,
        RandomizerLogger logger,
        Rng inventoryRng,
        Rng skillRng,
        MainCampaignCharacter character,
        bool randomizeInventory,
        bool giveRandomSkill,
        List<StartingWeaponCategory> weapons,
        IReadOnlyList<StartingInventoryItem> debugItems
    ) {
        var giveAmmo = randomizer.GetConfigOption<bool>("random-starting-inventory-give-ammo");
        var (primary, secondary) = randomizeInventory
            ? PickRandomWeaponPair(inventoryRng, weapons)
            : ((ItemID?)null, (ItemID?)null);
        var path = _paths[character];
        logger.Push($"{character} @ {path}");
        randomizer.FileRepository.ModifyUserFile<AddItemListData>(path, root => {
            if (randomizeInventory && primary != null) {
                logger.LogLine($"Primary weapon: {primary}");
                var id = primary.Value.ToString();
                root._AddItems.Add(
                    new StartingInventoryItem(){ ItemDataID = id, Num = 1 }
                );

                if (giveAmmo && Enum.TryParse(id, out WeaponID wpId) &&
                    StarterAmmoLoadouts.TryGetValue(wpId, out var ammoLoadout)) {
                    foreach (var (ammoType, ammoCount) in ammoLoadout) {
                        logger.LogLine($"Extra ammo: {ammoCount}x {ammoType}");
                        root._AddItems.Add(new StartingInventoryItem(){
                            ItemDataID = ammoType.ToString(),
                            Num = ammoCount,
                        });
                    }
                }
            }

            if (randomizeInventory && secondary != null) {
                logger.LogLine($"Secondary weapon: {secondary}");
                root._AddItems.Add(
                    new StartingInventoryItem(){ ItemDataID = secondary.Value.ToString()!, Num = 1 }
                );
            }

            if (randomizeInventory && inventoryRng.NextProbability(AntiqueCoinsProbabilityPct)) {
                logger.LogLine($"Nice! {AntiqueCoinsCount}x extra antique coin(s)!");
                root._AddItems.Add(new StartingInventoryItem(){ ItemDataID = "Coin", Num = AntiqueCoinsCount });
            }

            if (randomizeInventory) {
                foreach (var (itemId, count) in StarterHealing) {
                    EnsureMinimumItem(root._AddItems, itemId, count, logger);
                }
            }

#if !DEBUG
            if (randomizer.UserTags.Contains("re7:debugstartitems"))
            {
#endif
            if (randomizeInventory) {
                if (debugItems.Count > 0) {
                    logger.LogLine(
                        $"Adding debug items: {string.Join(", ", debugItems.Select(x => $"{x.Num}x {x.ItemDataID}"))}");
                    root._AddItems.AddRange(debugItems.Select(CloneInventoryItem));
                }
            }
#if !DEBUG
            }
#endif

            if (giveRandomSkill) {
                var skillId = skillRng.Next(StartingSkillLevelOneIds);
                logger.LogLine($"Random starting skill: {skillId}");
                BirthdaySkillVisuals.CopyRequiredFiles(randomizer.FileRepository, skillId);
                root._AddItems.Add(new StartingInventoryItem{
                    ItemDataID = skillId,
                    Num = 1,
                });
            }

            return root;
        });
        logger.Pop();
    }

    private static void EnsureMinimumItem(
        List<StartingInventoryItem> items,
        ItemID itemId,
        int minimumCount,
        RandomizerLogger logger
    ) {
        var id = itemId.ToString();
        var existingCount = items
            .Where(item => string.Equals(item.ItemDataID, id, StringComparison.OrdinalIgnoreCase))
            .Sum(item => item.Num);
        var countToAdd = minimumCount - existingCount;
        if (countToAdd <= 0)
            return;

        logger.LogLine($"Starter item: {countToAdd}x {itemId}");
        items.Add(new StartingInventoryItem(){
            ItemDataID = id,
            Num = countToAdd,
        });
    }

    private static StartingInventoryItem CloneInventoryItem(StartingInventoryItem item) {
        return new StartingInventoryItem(){
            ItemDataID = item.ItemDataID,
            Num = item.Num,
        };
    }

    public override void Apply(RandomizerLogger logger) {
        var randomizer = _randomizer;
        var randomizeEthansInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-ethan");
        var randomizeMiasInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-mia");
        var randomizeVhs = randomizer.GetConfigOption<bool>("random-starting-inventory-vhs");
        var giveRandomSkillEthan = randomizer.GetConfigOption<bool>("random-starting-inventory-skills-ethan");
        var giveRandomSkillMia = randomizer.GetConfigOption<bool>("random-starting-inventory-skills-mia");

        if (!randomizeEthansInventory && !randomizeMiasInventory && !giveRandomSkillEthan && !giveRandomSkillMia) {
            return;
        }

        var rng = randomizer.GetRng(RandomizerKey);
        var debugItems = randomizeEthansInventory || randomizeMiasInventory
            ? LoadDebugStartItems(randomizer)
            : [];

        // Starter weapons
        var categories = Enum.GetValues<StartingWeaponCategory>();
        foreach (var character in Enum.GetValues<MainCampaignCharacter>()) {
            var shouldRandomizeInventory = character switch{
                MainCampaignCharacter.Ethan => randomizeEthansInventory,
                MainCampaignCharacter.Mia => randomizeMiasInventory,
                MainCampaignCharacter.ClancyVHS => randomizeVhs && (randomizeEthansInventory || randomizeMiasInventory),
                MainCampaignCharacter.MiaVHS => randomizeMiasInventory && randomizeVhs,
                _ => false,
            };
            var shouldGiveRandomSkills = character switch{
                MainCampaignCharacter.Ethan => giveRandomSkillEthan,
                MainCampaignCharacter.Mia => giveRandomSkillMia,
                _ => false,
            };

            if (!shouldRandomizeInventory && !shouldGiveRandomSkills)
                continue;

            var configuredCategories = new List<StartingWeaponCategory>();
            if (shouldRandomizeInventory &&
                character is MainCampaignCharacter.ClancyVHS) // Allow all weapons for Clancy, it doesn't really matter
            {
                configuredCategories = Enum.GetValues<StartingWeaponCategory>().ToList();
            } else if (shouldRandomizeInventory) {
                foreach (var category in categories) {
                    var characterStr = character is MainCampaignCharacter.MiaVHS
                        ? "mia"
                        : character.ToString().ToLowerInvariant();
                    if (randomizer.GetConfigOption<bool>(
                            $"inventory-weapon-{category.ToString().ToLowerInvariant()}-{characterStr}")
                       ) {
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
                configuredCategories,
                debugItems);
        }
    }

    private static IReadOnlyList<StartingInventoryItem> LoadDebugStartItems(Randomizer randomizer) {
#if !DEBUG
        if (!randomizer.UserTags.Contains("re7:debugstartitems"))
        {
            return [];
        }
#endif

        return Csv.Deserialize<DebugStartItem>(randomizer.DynamicData.GetData(DynamicDataName.DebugStartItems)!)
            .Where(x => x.Quantity > 0)
            .Select(x => new StartingInventoryItem(){ ItemDataID = x.ItemId, Num = x.Quantity })
            .ToArray();
    }
}
