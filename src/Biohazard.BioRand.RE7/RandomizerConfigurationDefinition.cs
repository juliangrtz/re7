using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Modifiers;
using IntelOrca.Biohazard.BioRand;
using static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition;

namespace Biohazard.BioRand.RE7;

internal static class RandomizerConfigurationDefinition
{
    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

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

        #endregion General

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
        group.Warning = "This feature requires RE Framework.";
        group.Items.Add(new GroupItem()
        {
            Id = "recipes-add-new",
            Label = "Add new recipes",
            Description = "Whether to add new, random recipes.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "recipes-replace-original",
            Label = "Replace original recipes",
            Description = "Whether to replace the original recipes.",
            Type = "switch",
            Default = false
        });

        group.Items.Add(new GroupItem()
        {
            Id = "recipes-allow-stabilizers-and-steroids",
            Label = "Allow stabilizers and steroids",
            Description = "Whether to allow stabilizers and steroids in the item pool.",
            Type = "switch",
            Default = true
        });

        group.Items.Add(new GroupItem()
        {
            Id = "recipes-randomization-mode",
            Label = "Recipe generation mode",
            Description = "Controls how ingredients and results are selected.\n" +
            "Easy: You'll get useful recipes only. Recipes are chosen within a well-defined pool.\n" +
            "Balanced: All recipes respect item categories (ammo -> ammo, healing -> healing, etc.).\n" +
            "Chaos: Anything could craft anything.\n" +
            "Crazy: Deliberately nonsensical recipes." +
            "No crafting: You cannot craft anything. For hardcore players only.\n",
            Type = "dropdown",
            Options = ["Easy", "Balanced", "Chaos", "Crazy", "No crafting"],
            Default = "Balanced"
        });

        group.Items.Add(new GroupItem()
        {
            Id = $"recipes-new-min",
            Label = "Min. amount of new recipes",
            Description = "Only relevant if you add new recipes.",
            Type = "range",
            Min = 1,
            Max = RecipeModifier.MaxRecipeCount,
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
            Default = 12
        });

        group = page.CreateGroup("Stack Limits");
        group.Warning = "Zero means that the original stack limits stay.";
        group.Advanced = true;

        var items = from item in itemDefinitions
                    where item.IsStackable && !item.IsDlcItem // In the future the non-DLC restriction will be neutralized.
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
            Label = "Force RE Framework installation",
            Description = "Always forces the installation of RE Framework, regardless of the configuration.",
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
        group.Items.Add(new GroupItem()
        {
            Id = $"debug-unique-enemy-hp",
            Label = "Unique Enemy HP",
            Description = "Gives every single enemy a unique HP value. Used to identify enemies within the game files.",
            Type = "switch",
            Default = false
        });

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

    // TODO: Add extension methods like
    // public static void AddDropdown(this Group group, GroupItem item) { ... }
}