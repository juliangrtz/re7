using System.Text;

using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerRecipeModifierBehaviorTests
{
    [Fact]
    public void RecipeModifier_WithInjectedRecipes_AddsSelectedRecipesAndRebuildsDictionary()
    {
        var recipesCsv = """
Enabled,Pool,Count1_Min,Count1_Max,Item1,Count2_Min,Count2_Max,Item2,OutputCount_Min,OutputCount_Max,OutputItem,Comment
true,AlwaysEnabled,1,1,Herb,1,1,Herb,1,1,Strong Chem Fluid,Always recipe
true,Balanced,2,2,Handgun Ammo,1,1,Gunpowder,3,3,Shotgun Shells,Balanced recipe
true,Balanced,1,1,Herb,1,1,Herb,1,1,Stabilizer,Filtered recipe
""";

        using var result = RandomizerTest.RunState(
            config =>
            {
                config["recipes-add-new"] = true;
                config["recipes-randomization-mode"] = "Balanced";
                config["recipes-new-min"] = 1;
                config["recipes-new-max"] = 1;
                config["recipes-allow-stabilizers-and-steroids"] = false;
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(DynamicDataName.Recipes, Encoding.UTF8.GetBytes(recipesCsv));
            });

        var beforeRecipes = result.ReadBeforeUserFile<app.ItemCombineData>(RandomizerTestPaths.ItemCombineDataPath);
        var afterRecipes = result.ReadAfterUserFile<app.ItemCombineData>(RandomizerTestPaths.ItemCombineDataPath);
        var afterDictionary = result.ReadAfterUserFile<app.DictionaryCombineData>(RandomizerTestPaths.DictionaryCombineDataPath);

        Assert.True(result.WasFileModified(RandomizerTestPaths.ItemCombineDataPath));
        Assert.True(result.WasFileModified(RandomizerTestPaths.DictionaryCombineDataPath));
        Assert.Equal(beforeRecipes._Datas.Count + 2, afterRecipes._Datas.Count);
        Assert.Equal("ShotgunBullet", afterRecipes._Datas[0].ResultItemID);
        Assert.Equal("ChemicalM", afterRecipes._Datas[1].ResultItemID);
        Assert.Equal(["ChemicalM", "ShotgunBullet"], afterDictionary._Datas.Select(x => x.ItemDataID).ToArray());
    }

    [Fact]
    public void RecipeModifier_WithQuantityRandomization_ScalesSelectedRecipeAmounts()
    {
        var recipesCsv = """
Enabled,Pool,Count1_Min,Count1_Max,Item1,Count2_Min,Count2_Max,Item2,OutputCount_Min,OutputCount_Max,OutputItem,Comment
true,AlwaysEnabled,1,1,Herb,1,1,Herb,1,1,Strong Chem Fluid,Always recipe
true,Balanced,2,2,Handgun Ammo,1,1,Gunpowder,3,3,Shotgun Shells,Balanced recipe
""";

        using var result = RandomizerTest.RunState(
            config =>
            {
                config["recipes-add-new"] = true;
                config["recipes-randomization-mode"] = "Balanced";
                config["recipes-new-min"] = 1;
                config["recipes-new-max"] = 1;
                config["recipes-random-item-quantities"] = true;
                config["recipes-count-min"] = 2.0;
                config["recipes-count-max"] = 2.0;
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(DynamicDataName.Recipes, Encoding.UTF8.GetBytes(recipesCsv));
            });

        var recipes = result.ReadAfterUserFile<app.ItemCombineData>(RandomizerTestPaths.ItemCombineDataPath)._Datas;
        var selectedRecipe = recipes[0];

        Assert.Equal("HandgunBullet", selectedRecipe.SrcItemID1);
        Assert.Equal(4, selectedRecipe.SrcItemNum1);
        Assert.Equal("Gunpowder", selectedRecipe.SrcItemID2);
        Assert.Equal(2, selectedRecipe.SrcItemNum2);
        Assert.Equal("ShotgunBullet", selectedRecipe.ResultItemID);
        Assert.Equal(6, selectedRecipe.ResultItemNum);
    }
}
