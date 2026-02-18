using IntelOrca.Biohazard.BioRand;
using System.Text;
using static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition;

namespace Biohazard.BioRand.RE7 {
    internal static class RE7RandomizerConfigurationDefinition {
        public static RandomizerConfigurationDefinition Create() {
            var configDefinition = new RandomizerConfigurationDefinition();

            #region General

            var page = configDefinition.CreatePage("General");
            var group = page.CreateGroup("");
            group.Items.Add(new GroupItem() {
                Id = "game-version",
                Label = "Game Version",
                Description = "What version of the game to generate for. Check what version you're using on Steam.",
                Type = "dropdown",
                Options = ["rt", "non-rt"],
                Default = "rt"
            });

            group.Items.Add(new GroupItem() {
                Id = $"start-chapter",
                Label = "Start Chapter",
                Description = "Which chapter to start on.",
                Type = "range",
                Min = 1,
                Max = 16,
                Default = 1
            });

            #endregion

            #region Items

            page = configDefinition.CreatePage("Items");
            group = page.CreateGroup("");
            group.Items.Add(new GroupItem() {
                Id = $"random-recipes",
                Label = "Random Recipes",
                Description = "Let Biorand randomize all the crafting recipes in the game.",
                Type = "switch",
                Default = false
            });
         
            #endregion

            #region Debug

            page = configDefinition.CreatePage("Debug");
            page.Advanced = true;
            group = page.CreateGroup("");
            group.Warning = "These options are only for testing / debugging the randomizer.";
#if ENABLE_BETA_FEATURES
            group.Items.Add(new GroupItem() {
                Id = "debug-download-data",
                Label = "Download Data",
                Description = "Download latest spreadsheet data before generating the randomizer.",
                Type = "switch",
                Default = false
            });
#endif
            group.Items.Add(new GroupItem() {
                Id = $"enable-special",
                Label = "Enable Personal Touch",
                Description = "Enables a personal touch or meme for the current user.",
                Type = "switch",
                Default = true
            });
            group.Items.Add(new GroupItem() {
                Id = $"debug-unique-enemy-hp",
                Label = "Unique Enemy HP",
                Description = "Gives every single enemy a unique HP value. Used to identify enemies within the game files.",
                Type = "switch",
                Default = false
            });

            #endregion

            var defaultProfileBytes = RE7RandomizerFactory.GetDefaultProfile();
            var defaultProfileJson = Encoding.UTF8.GetString(defaultProfileBytes);
            var defaultProfile = RandomizerConfiguration.FromJson(defaultProfileJson);
            foreach (var item in configDefinition.AllItems) {
                if (defaultProfile.TryGetValue(item.Id!, out var defaultOverride)) {
                    item.Default = defaultOverride;
                }
            }
            return configDefinition;
        }
    }
}
