using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Modifiers;
using Biohazard.BioRand.RE7.Weapons;
using IntelOrca.Biohazard.BioRand;
using static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition;

namespace Biohazard.BioRand.RE7;

// TODO: Add extension methods like
// public static void AddDropdown(this Group group, GroupItem item) { ... }
internal static class RandomizerConfigurationDefinition
{
    private static readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;
    private static readonly WeaponDefinitionRepository _weaponDefinitions = WeaponDefinitionRepository.Default;

    public static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition Create()
    {
        var configDefinition = new IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition();

        #region General

        var page = configDefinition.CreatePage("General");
        var group = page.CreateGroup("");
        group.Items.Add(new GroupItem()
        {
            Id = "game-version",
            Label = "Game Version",
            Description = "What version of the game to generate for." +
            " You can identify it in Steam by right-clicking the game," +
            " selecting 'Properties' and then 'Game Versions & Betas'.",
            Type = "dropdown",
            Options = ["dx12_rt", "dx11_non-rt"],
            Default = "dx12_rt"
        });

        group.Items.Add(new GroupItem()
        {
            Id = "skip-guest-house",
            Label = "Skip Guest House Chapter",
            Description = "Whether to skip the guest house chapter and start from the main Baker house.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "shuffle-chapters",
            Label = "Shuffle Chapters",
            Description = "Whether to shuffle chapter transitions.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "shuffle-chapters-with-ff",
            Label = "Include Found Footage Chapters When Shuffling",
            Description = "Whether to include the Found Footage VHS sections when shuffling chapters.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "randomized-messages",
            Label = "Randomize Text",
            Description = "Randomize various text in the game to a meme.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "main-menu-biorand-touch",
            Label = "Add BioRand touch to main menu",
            Description = "Whether to add a BioRand touch to the main menu such as a modified logo and \"New Game\" text.",
            Type = "switch",
            Default = true
        });

        group = page.CreateGroup("");

        group.Items.Add(new GroupItem()
        {
            Id = $"allow-bonus-items",
            Label = "Allow Bonus Weapons",
            Description = "Let BioRand include the unlockable weapons (Albert-01R, Infinite Ammo, Essence/Secrets of Defence etc.) in the pool.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"allow-dlc-items",
            Label = "Allow DLC Weapons",
            Description = "Let BioRand include the DLC weapons (Thor's Hammer, AMG-Dual, Blasters etc.) in the pool.",
            Type = "switch",
            Default = false
        });

        #endregion General

        #region Items

        page = configDefinition.CreatePage("Items");
        group = page.CreateGroup("");

        group.Items.Add(new GroupItem()
        {
            Id = "random-items",
            Label = "Random Items",
            Description = "Whether to randomize most of the static items. Excludes certain items such as key items or the model shotguns.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "random-key-item-locations",
            Label = "Random Key Item Locations",
            Description = "Whether to randomize some of the key item locations.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "replace-madhouse-tapes",
            Label = "Replace Madhouse Cassette Tapes",
            Description = "Whether to also randomize the cassette tapes on the Madhouse difficulty.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "replace-weapons",
            Label = "Replace Weapons",
            Description = "Whether to also randomize the weapons such as the G17 handgun in the garage. " +
            "WARNING: Enabling this means that you may never get certain weapons!",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"random-bird-cage-magnum",
            Label = "Random Bird Cage 44 MAG",
            Description = "Whether to randomize the 44 MAG in bird cages. Appropriate replacements are guaranteed.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"random-bird-cage-drugs-coins",
            Label = "Random Bird Cage Drugs/Coins",
            Description = "Whether to randomize drugs (stabilizers and steroids) and coins in bird cages. Appropriate replacements are guaranteed.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"item-drop-respect-difficulty",
            Label = "Ammo drops respect the difficulty",
            Description = "Will drop more items on Easy/Normal and fewer items on Madhouse. " +
            "If you disable this all difficulties will share the same ammo quantities.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"item-drop-ammo-only-available-weapons",
            Label = "Ammo for available weapons only",
            Description = "Only drop ammo for weapons that are available before or in the chapter with the drop. " +
            "Currently only works for item crates. Ammo replacements for static items will be completely random.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"item-drop-ammo-min",
            Label = "Min. Ammo Quantity",
            Description = "The minimum percentage of an ammo stack to drop.",
            Type = "percent",
            Min = 0.1,
            Max = 1,
            Step = 0.1,
            Default = 0.1
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"item-drop-ammo-max",
            Label = "Max. Ammo Quantity",
            Description = "The maximum percentage of an ammo stack to drop.",
            Type = "percent",
            Min = 0.1,
            Max = 10,
            Step = 0.1,
            Default = 0.4
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"preserve-item-models",
            Label = "Preserve Item Models",
            Description = "When randomizing items, keep the original item model in the world.",
            Type = "switch",
            Default = false,
        });

        group = page.CreateGroup("Additional Items");
        group.Items.Add(new GroupItem()
        {
            Id = $"additional-items",
            Label = "Additional items",
            Description = "Toggles additional items that will spawn in preselected locations.",
            Type = "switch",
            Default = true,
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"additional-items-prefer-healing",
            Label = "Prefer additional healing items and drugs",
            Description = "Will drop more healing items such as herbs, first aid meds and steroids.",
            Type = "switch",
            Default = false,
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"additional-wooden-crates",
            Label = "Additional wooden crates",
            Description = "Toggles additional wooden item crates that will drop random items.",
            Type = "switch",
            Default = true,
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"additional-wooden-crates-fakes",
            Label = "Allow explosive fake crates",
            Description = "Will also spawn explosive fake crates similar to the ones in Ethan Must Die and End of Zoe. " +
            "However, you won't recognize these by the ticking sound or the model!",
            Type = "switch",
            Default = true,
        });

        group = page.CreateGroup("General Drops");
        var drops = ItemDrops.GenericDrops.OrderBy(drop => _itemDefinitions.FromId(drop.ToString())!.CategoryType);
        foreach (var drop in drops)
        {
            var category = ItemDrops.GetCategory(drop);
            var (bgColor, textColor) = ItemDrops.GetColor(category);
            group.Items.Add(new GroupItem()
            {
                Id = $"item-drop-ratio-{drop.ToString().ToLowerInvariant()}",
                Label = _itemDefinitions.FromId(drop.ToString())!.Name,
                Category = new GroupItemCategory()
                {
                    Label = category,
                    BackgroundColor = bgColor,
                    TextColor = textColor,
                },
                Type = "range",
                Min = 0,
                Max = 1,
                Step = 0.01,
                Default = 0.5
            });
        }

        group = page.CreateGroup("Valuable Drops");
        group.Advanced = true;
        foreach (var drop in ItemDrops.HighValueDrops)
        {
            group.Items.Add(new GroupItem()
            {
                Id = $"item-drop-valuable-{drop}",
                Label = ItemDrops.GetHighValueDropLabel(drop),
                Type = "switch",
                Default = ItemDrops.GetEnabledValuableDrops().Contains(drop)
            });
        }

        #endregion Items

        #region Inventory

        page = configDefinition.CreatePage("Inventory");

        group = page.CreateGroup("Starting inventory");
        group.Items.Add(new GroupItem()
        {
            Id = "random-starting-inventory-ethan",
            Label = "Ethan: Random starting weapons",
            Description = "Whether to start with a random inventory as Ethan. " +
            "You'll receive a random gun and a random bladed weapon.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "random-starting-inventory-mia",
            Label = "Mia: Random starting weapons",
            Description = "Whether to start with a random inventory as Mia. " +
            "You'll receive a random gun and a random bladed weapon.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "random-starting-inventory-give-ammo",
            Label = "Provide ammo for primary weapon",
            Description = "Whether to provide a random amount of ammo for your primary weapon.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "random-starting-inventory-vhs",
            Label = "Randomize VHS sections as well",
            Description = "Whether to randomize Clancy's and Mia's VHS sections too.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "random-starting-inventory-size-ethan",
            Label = "Ethan: Inventory size",
            Description = "Controls the size of your starting inventory as Ethan. The default is 12. Requires RE Framework.",
            Type = "dropdown",
            Options = ["random", "12", "16", "20"],
            Default = "12"
        });

        group.Items.Add(new GroupItem()
        {
            Id = "random-starting-inventory-size-mia",
            Label = "Mia: Inventory size",
            Description = "Controls the size of your starting inventory as Mia. The default is 12. Requires RE Framework.",
            Type = "dropdown",
            Options = ["random", "12", "16", "20"],
            Default = "12"
        });

        var categories = Enum.GetValues<StartingWeaponCategory>();
        foreach (var character in new[] { "Ethan", "Mia" })
        {
            group = page.CreateGroup($"{character}: Allowed weapon categories");
            foreach (var category in categories)
            {
                group.Items.Add(new GroupItem()
                {
                    Id = $"inventory-weapon-{category.ToString().ToLowerInvariant()}-{character.ToLowerInvariant()}",
                    Description = (category == StartingWeaponCategory.Bladed ? "Knives and Axe" : null),
                    Label = category.GetLabel(),
                    Type = "switch",
                    Default = category is StartingWeaponCategory.Bladed or StartingWeaponCategory.Handgun
                });
            }
        }

        group = page.CreateGroup("Recipes");
        group.Warning = "This feature requires RE Framework to increase the crafting menu slots from 8 to 20.";
        group.Items.Add(new GroupItem()
        {
            Id = "recipes-add-new",
            Label = "Add new recipes",
            Description = "Whether to add new, random recipes. " +
            "The original recipes still exist even though they are not shown in the crafting menu!",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "recipes-randomization-mode",
            Label = "Recipe generation mode",
            Description = "Controls how ingredients and results are selected.\n" +
            "Easy: You'll get useful recipes only.\n" +
            "Balanced: All recipes respect item categories (ammo -> ammo, healing -> healing, etc.).\n" +
            "Hard: You require more resources for less items. \n" +
            "Crazy: Mostly deliberate, nonsensical recipes." +
            "No crafting: You cannot craft anything. For hardcore players only!\n",
            Type = "dropdown",
            Options = ["Easy", "Balanced", "Chaos", "Crazy", "No crafting"],
            Default = "Balanced"
        });

        group.Items.Add(new GroupItem()
        {
            Id = "recipes-allow-stabilizers-and-steroids",
            Label = "Allow stabilizers and steroids as results",
            Description = "Whether to allow stabilizers and steroids as results.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "recipes-random-item-quantities",
            Label = "Randomize item quantities",
            Description = "Whether to randomize the input and output quantities.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"recipes-count-min",
            Label = "Min. item quantity factor",
            Description = "Only relevant if you randomize item quantities. " +
            "It is ensured that always at least one item is required.",
            Type = "range",
            Min = 0.5,
            Max = 3,
            Step = 0.1,
            Default = 1
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"recipes-count-max",
            Label = "Max. item quantity factor",
            Description = "Only relevant if you randomize item quantities.",
            Type = "range",
            Min = 1,
            Max = 3,
            Step = 0.1,
            Default = 2
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"recipes-new-min",
            Label = "Min. amount of new recipes",
            Description = "Only relevant if you add new recipes.",
            Type = "range",
            Min = 1,
            Max = RecipeModifier.MaxRecipeCount,
            Step = 1,
            Default = 4
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"recipes-new-max",
            Label = "Max. amount of new recipes",
            Description = "Only relevant if you add new recipes.",
            Type = "range",
            Min = 1,
            Max = RecipeModifier.MaxRecipeCount,
            Step = 1,
            Default = 12
        });

        group.Items.Add(new GroupItem()
        {
            Id = "recipes-unlock-from-start",
            Label = "Unlock combine menu from the start",
            Description = "Whether to unlock the ability to combine items from the start.",
            Type = "switch",
            Default = true
        });

        group = page.CreateGroup("Stack Limits");
        group.Advanced = true;

        var items = from item in _itemDefinitions.Items
                    where item.IsStackable && !item.IsDlcItem // TODO: Remove second condition when DLCs are supported.
                    select (item.Id, item.Name, item.MaxStack);

        foreach ((string id, string name, int maxStack) in items)
        {
            group.Items.Add(new GroupItem()
            {
                Id = $"inventory-stack-limit-{id.ToLowerInvariant()}",
                Label = name,
                Type = "range",
                Min = 0,
                Max = 999,
                Step = 1,
                Default = maxStack
            });
        }

        #endregion Inventory

        #region Weapons
        page = configDefinition.CreatePage("Weapons");
        group = page.CreateGroup("Damage");

        group.Items.Add(new GroupItem()
        {
            Id = "weapon-mod-damage",
            Label = "Randomize Damage",
            Description = "Whether to randomize weapon damage values.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "weapon-mod-damage-include-stun",
            Label = "Include Stun",
            Description = "Whether to apply the randomization to stun as well.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "weapon-mod-damage-include-player-damage",
            Label = "Include Player Damage",
            Description = "Whether to apply the randomization to player damage values too, e.g. for the Remote Bomb.",
            Type = "switch",
            Default = true
        });

        group = page.CreateGroup("");

        var weapons = _weaponDefinitions.PlayerWeapons
            .Where(wp => !wp.WeaponId.ToString().Contains("blaster", StringComparison.InvariantCultureIgnoreCase))
            .OrderBy(gun => gun.Name ?? gun.WeaponId.ToString());
        foreach (var definition in weapons)
        {
            var sanitizedId = definition.WeaponId.ToString().ToLowerInvariant().Replace("_", "-");
            var name = _itemDefinitions.FromId(definition.WeaponId.ToString())!.Name;
            group.Items.Add(new GroupItem()
            {
                Id = $"weapon-damage-min-{sanitizedId}",
                Label = $"Min. Damage Multiplier {name}",
                Type = "range",
                Min = 0,
                Max = 2,
                Step = 0.1,
                Default = 0.8
            });

            group.Items.Add(new GroupItem()
            {
                Id = $"weapon-damage-max-{sanitizedId}",
                Label = $"Max. Damage Multiplier {name}",
                Type = "range",
                Min = 0,
                Max = 2,
                Step = 0.1,
                Default = 1.2
            });
        }

        group = page.CreateGroup("Ammo Capacities");

        group.Items.Add(new GroupItem()
        {
            Id = "weapon-mod-ammo-capacity",
            Label = "Randomize Ammo Capacity",
            Description = "Whether to randomize the ammo capacities. A new game must be created for this to work!",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "weapon-mod-ammo-capacity-prevent-zero",
            Label = "Ensure a minimum capacity of 1",
            Description = "Whether to ensure that the minimum capacity is one.",
            Type = "switch",
            Default = true
        });

        var guns = _weaponDefinitions.Guns
            .Where(gun => gun.UserType == Enums.app.CharacterDefine.Type.Player)
            .OrderBy(gun => gun.Name ?? gun.WeaponId.ToString());
        foreach (var definition in guns)
        {
            var sanitizedId = definition.WeaponId.ToString().ToLowerInvariant().Replace("_", "-");
            var name = _itemDefinitions.FromId(definition.WeaponId.ToString())!.Name;
            group.Items.Add(new GroupItem()
            {
                Id = $"weapon-ammo-capacity-min-{sanitizedId}",
                Label = $"Min. Ammo Capacity Multiplier {name}",
                Type = "range",
                Min = 0,
                Max = 2,
                Step = 0.1,
                Default = 0.8
            });

            group.Items.Add(new GroupItem()
            {
                Id = $"weapon-ammo-capacity-max-{sanitizedId}",
                Label = $"Max. Ammo Capacity Multiplier {name}",
                Type = "range",
                Min = 0,
                Max = 2,
                Step = 0.1,
                Default = 1.2
            });
        }

        #endregion

        #region Debug

        page = configDefinition.CreatePage("Debug");
        page.Advanced = true;
        group = page.CreateGroup("");
        group.Warning = "These options are only for testing / debugging the randomizer.";
        group.Items.Add(new GroupItem()
        {
            Id = "debug-download-data",
            Label = "Download Data",
            Description = "Download latest spreadsheet data before generating the randomizer.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "debug-force-reframework",
            Label = "Force RE Framework artifacts",
            Description = "Always forces the installation of RE Framework artifacts, regardless of the configuration.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "debug-download-reframework-nightly",
            Label = "Download RE Framework Nightly",
            Description = "Installs RE Framework nightly from praydog's GitHub repository.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"enable-special",
            Label = "Enable Personal Touch",
            Description = "Enables a personal touch or meme for the current user.",
            Type = "switch",
            Default = true
        });
        //group.Items.Add(new GroupItem()
        //{
        //    Id = $"debug-unique-enemy-hp",
        //    Label = "Unique Enemy HP",
        //    Description = "Gives every single enemy a unique HP value. Used to identify enemies within the game files.",
        //    Type = "switch",
        //    Default = false
        //});

        #endregion Debug

        var defaultProfileBytes = RandomizerFactory.GetDefaultProfile();
        var defaultProfileJson = Encoding.UTF8.GetString(defaultProfileBytes);
        var defaultProfile = RandomizerConfiguration.FromJson(defaultProfileJson);
        foreach (var item in configDefinition.AllItems)
        {
            if (defaultProfile.TryGetValue(item.Id!, out var defaultOverride))
            {
                item.Default = defaultOverride;
            }
        }
        return configDefinition;
    }
}