using IntelOrca.Biohazard.BioRand;
using System.Text;
using static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition;

namespace Biohazard.BioRand.RE7
{
    internal static class RE7RandomizerConfigurationDefinition
    {
        public static RandomizerConfigurationDefinition Create()
        {
            var configDefinition = new RandomizerConfigurationDefinition();

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

            #region Recipes

            page = configDefinition.CreatePage("Recipes");
            group = page.CreateGroup("");
            group.Items.Add(new GroupItem()
            {
                Id = $"recipe-randomization-mode",
                Label = "Recipe randomization mode",
                Description = "Off: No changes.\n" +
                "Shuffle outputs: Only target items change.\n" +
                "Shuffle inputs: Only source items change.\n" +
                "Full random: Both source and target items change with safeguards.\n" +
                "Chaos: Anything can craft anything. No safeguards!",
                Type = "dropdown",
                Options = ["off", "shuffle_outputs", "shuffle_inputs", "full_random", "chaos"],
                Default = "off"
            });

            group.Items.Add(new GroupItem()
            {
                Id = "recipe-only-add",
                Label = "Only add new recipes",
                Description = "Whether to only add new crafting recipes.",
                Type = "switch",
                Default = true
            });

            group.Items.Add(new GroupItem()
            {
                Id = $"recipe-new-entries-min",
                Label = "Min. amount of new recipes",
                Type = "range",
                Min = 1,
                Max = 20,
                Default = 4
            });

            group.Items.Add(new GroupItem()
            {
                Id = $"recipe-new-entries-max",
                Label = "Max. amount of new recipes",
                Type = "range",
                Min = 1,
                Max = 20,
                Default = 8
            });

            group = page.CreateGroup("");
            group.Items.Add(new GroupItem()
            {
                Id = $"recipe-source-count-min",
                Label = "Min. amount of source items",
                Type = "range",
                Min = 1,
                Max = 5,
                Default = 1
            });

            group.Items.Add(new GroupItem()
            {
                Id = $"recipe-source-count-max",
                Label = "Max. amount of source items",
                Type = "range",
                Min = 1,
                Max = 5,
                Default = 2
            });

            group.Items.Add(new GroupItem()
            {
                Id = $"recipe-target-count-min",
                Label = "Min. amount of target items",
                Type = "range",
                Min = 1,
                Max = 5,
                Default = 1
            });

            group.Items.Add(new GroupItem()
            {
                Id = $"recipe-target-count-max",
                Label = "Max. amount of target items",
                Type = "range",
                Min = 1,
                Max = 5,
                Default = 2
            });

            #endregion Recipes

            #region Debug

            page = configDefinition.CreatePage("Debug");
            page.Advanced = true;
            group = page.CreateGroup("");
            group.Warning = "These options are only for testing / debugging the randomizer.";
#if ENABLE_BETA_FEATURES
            group.Items.Add(new GroupItem()
            {
                Id = "debug-download-data",
                Label = "Download Data",
                Description = "Download latest spreadsheet data before generating the randomizer.",
                Type = "switch",
                Default = false
            });
#endif
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

            var defaultProfileBytes = RE7RandomizerFactory.GetDefaultProfile();
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
}