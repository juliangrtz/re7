namespace Biohazard.BioRand.RE7.Tests.Modifiers
{
    public class RecipeModifierTests : RandomizerTest
    {
        private readonly string ItemCombineDataPath = @"natives\stm\prefab\item\itemcombinedata.user.2";
        private readonly string DictionaryCombineDataPath = @"natives\stm\prefab\item\dictionarycombinedata.user.2";

        [SkipCIFact]
        public void Test_Random_Recipes_Config_Off_DX12()
        {
            // Given
            var config = """
                {
                  "game-version": "dx12_rt",
                  "recipe-randomization-mode": "off"
                }
                """;

            // When
            var resultPak = RunRandomizer(config);

            // Then
            // TODO: Find better way to test the result
            Assert.Null(resultPak.GetEntryData(ItemCombineDataPath));
            Assert.Null(resultPak.GetEntryData(DictionaryCombineDataPath));
        }

        [SkipCIFact]
        public void Test_Random_Recipes_Config_Chaos_DX12()
        {
            // Given
            var config = """
                {
                  "game-version": "dx12_rt",
                  "recipe-randomization-mode": "chaos"
                }
                """;

            // When
            var resultPak = RunRandomizer(config);

            // Then
            // TODO: Find better way to test the result
            Assert.NotNull(resultPak.GetEntryData(ItemCombineDataPath));
            Assert.NotNull(resultPak.GetEntryData(DictionaryCombineDataPath));
        }
    }
}