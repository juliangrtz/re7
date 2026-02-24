namespace Biohazard.BioRand.RE7.Tests.Modifiers;

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
              "game-version": "dx12_rt"
            }
            """;

        // When
        var (_, resultPak) = RunRandomizer(config);

        // Then
        // TODO: Find better way to test the result
        Assert.Null(resultPak.GetEntryData(ItemCombineDataPath));
        Assert.Null(resultPak.GetEntryData(DictionaryCombineDataPath));
    }

    [SkipCIFact]
    public void Test_Random_Recipes_Config_Crazy_DX12()
    {
        // Given
        var config = """
            {
              "game-version": "dx12_rt",
              "recipes-add-new": true,
              "recipes-replace-original": false,
              "recipes-show-in-menu": true,
              "recipes-randomization-mode": "crazy",
              "recipes-new-min": 20,
              "recipes-new-max": 20
            }
            """;

        // When
        var (_, resultPak) = RunRandomizer(config);

        // Then
        // TODO: Find better way to test the result
        Assert.NotNull(resultPak.GetEntryData(ItemCombineDataPath));
        Assert.NotNull(resultPak.GetEntryData(DictionaryCombineDataPath));
    }
}