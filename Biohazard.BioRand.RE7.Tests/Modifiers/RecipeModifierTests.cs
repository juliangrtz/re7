namespace Biohazard.BioRand.RE7.Tests.Modifiers {
    public class RecipeModifierTests : RandomizerTest {
        private readonly string ItemCombineDataPath = @"natives\stm\prefab\item\itemcombinedata.user.2";
        private readonly string DictionaryCombineDataPath = @"natives\stm\prefab\item\dictionarycombinedata.user.2";

        [Fact]
        public void Test_Random_Recipes_Config_True() {
            // Given
            var config = """
                {
                  "random-recipes": true
                }
                """;

            // When
            var resultPak = RunRandomizer(config);

            // Then
            // TODO: Find better way to test the result
            Assert.NotNull(resultPak.GetEntryData(ItemCombineDataPath));
            Assert.NotNull(resultPak.GetEntryData(DictionaryCombineDataPath));
        }

        [Fact]
        public void Test_Random_Recipes_Config_False() {
            // Given
            var config = """
                {
                  "random-recipes": false
                }
                """;

            // When
            var resultPak = RunRandomizer(config);

            // Then
            // TODO: Find better way to test the result
            Assert.Null(resultPak.GetEntryData(ItemCombineDataPath));
            Assert.Null(resultPak.GetEntryData(DictionaryCombineDataPath));
        }
    }
}
