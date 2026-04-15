using app;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Modifiers;


/// <summary>
/// Using this modifier properly requires REFramework (_Data/REF_Scripts/RecipeMods.lua).
/// This is because the game has very strict limitations for what is shown in the combine GUI.
/// </summary>
internal class RecipeModifier : Modifier
{
    // The combine GUI only allows 20 slots, even in a modded state (4 cols, 5 rows).
    public const int MaxRecipeCount = 20;

    private const string RandomizerKey = "modifier/recipes";

    private static readonly string DictionaryCombineDataPath = PakPath.UserFile("prefab/item/dictionarycombinedata.user");
    private static readonly string ItemCombineDataPath = PakPath.UserFile("prefab/item/itemcombinedata.user");

    private static readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;
    private List<Recipe> _originalRecipes = new();
    private List<DictionaryCombineData.Data> _originalDictCombineData = new();

    private static void LogRecipeState(RandomizerLogger logger, List<Recipe> recipes, List<DictionaryCombineData.Data> dict, bool beforeModifications)
    {
        var adjective = beforeModifications ? "Original" : "Modded";
        logger.Push($"{adjective} crafting recipes");

        foreach (var recipe in recipes)
        {
            logger.LogLine(recipe.Format());
        }

        logger.Pop();

        logger.Push($"{adjective} crafting dictionary");
        foreach (var itemId in dict.Select(d => _itemDefinitions.FromId(d.ItemDataID)?.Name).Choose())
        {
            logger.LogLine(itemId);
        }
        logger.Pop();
    }

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        _originalRecipes = randomizer.FileRepository.DeserializeUserFile<ItemCombineData>(ItemCombineDataPath)._Datas;
        _originalDictCombineData = randomizer.FileRepository.DeserializeUserFile<DictionaryCombineData>(DictionaryCombineDataPath)._Datas;
        LogRecipeState(logger, _originalRecipes, _originalDictCombineData, beforeModifications: true);
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var addNewRecipes = randomizer.GetConfigOption<bool>("recipes-add-new");

        if (!addNewRecipes)
        {
            return;
        }

        var mode = randomizer.GetConfigOption<string>("recipes-randomization-mode");
        var rng = randomizer.GetRng(RandomizerKey);
        if (mode == "No crafting")
        {
            logger.LogLine("User chose to disable crafting entirely. Removing all recipes now.");
            AddRecipes(randomizer, [], clear: true);
            RebuildDictionary(randomizer, []);
            return;
        }

        var csv = randomizer.DynamicData.GetData(DynamicDataName.Recipes) ?? throw new Exception("Unable to get recipe data");
        var recipes = Csv.Deserialize<RecipeModel>(csv).ToImmutableList();

        recipes.ForEach(r =>
        {
            if(!(r.Count1_Min > 0
            && r.Count1_Max > 0
            && r.Count2_Min > 0
            && r.Count2_Max > 0
            && r.OutputCount_Min > 0
            && r.OutputCount_Max > 0
            && _itemDefinitions.NameToId(r.Item1) != null
            && _itemDefinitions.NameToId(r.Item2) != null
            && _itemDefinitions.NameToId(r.OutputItem) != null))
            {
                throw new IntelOrca.Biohazard.BioRand.RandomizerUserException("Bad CSV recipe! Please check your spoiler log and report this. Recipe: " + r);
            }
        });

        // Apply config
        var recipePool = (mode switch
        {
            "Easy" => recipes.Where(r => r.Pool == RecipePool.Easy),
            "Balanced" => recipes.Where(r => r.Pool == RecipePool.Balanced),
            "Chaos" => recipes.Where(r => r.Pool == RecipePool.Chaos),
            "Crazy" => recipes.Where(r => r.Pool == RecipePool.Crazy),
            _ => throw new ArgumentException($"Invalid recipe randomization mode '{mode}' supplied!")
        }).ToList();

        if (!randomizer.GetConfigOption<bool>("recipes-allow-stabilizers-and-steroids"))
        {
            recipePool.RemoveAll(recipe => recipe.OutputItem is "Depressant" or "Stimulant");
        }

        // Some items are always added, no matter the mode.
        var alwaysAdded = recipes
            .Where(r => r.Pool == RecipePool.AlwaysEnabled)
            .Select(r => CreateRecipe(r, rng))
            .ToList();
        AddRecipes(randomizer, alwaysAdded, clear: false);

        var addedRecipes = new List<Recipe>();
        var minRecipeAmount = randomizer.GetConfigOption<int>("recipes-new-min");
        var maxRecipeAmount = randomizer.GetConfigOption<int>("recipes-new-max");
        var amount = rng.Next(minRecipeAmount, maxRecipeAmount + 1);

        var toBeAdded = recipePool
            .OrderBy(_ => rng.Next())
            .Take(amount)
            .Select(r => CreateRecipe(r, rng));

        if (randomizer.GetConfigOption<bool>("recipes-random-item-quantities"))
        {
            var minQuantity = randomizer.GetConfigOption<double>("recipes-count-min");
            var maxQuantity = randomizer.GetConfigOption<double>("recipes-count-max");

            double Scale() => Math.Round(rng.NextDouble(minQuantity, maxQuantity), 1);

            foreach (var r in toBeAdded)
            {
                var src1 = r.SrcItemNum1;
                var src2 = r.SrcItemNum2;
                var result = r.ResultItemNum;

                r.SrcItemNum1 = Math.Max(1, (int)Math.Round(src1 * Scale()));
                r.SrcItemNum2 = Math.Max(1, (int)Math.Round(src2 * Scale()));
                r.ResultItemNum = Math.Max(1, (int)Math.Round(result * Scale()));
            }
        }

        addedRecipes.AddRange(toBeAdded);
        AddRecipes(randomizer, addedRecipes, clear: false);

        // Rebuild dictionarycombinedata.user.2
        // This file holds the result item IDs of the items that are displayed in the combine GUI.
        var newDict = RebuildDictionary(randomizer, alwaysAdded.Concat(addedRecipes).ToList());

        // Finally, write the spoiler log.
        LogRecipeState(logger, addedRecipes, newDict, beforeModifications: false);
    }

    private static List<DictionaryCombineData.Data> RebuildDictionary(Randomizer randomizer, List<Recipe> newRecipes)
    {
        var result = new List<DictionaryCombineData.Data>();
        randomizer.FileRepository.ModifyUserFile<DictionaryCombineData>(
            DictionaryCombineDataPath,
            root =>
            {
                root._Datas.Clear();

                for (int i = 0; i < newRecipes.Count && i < MaxRecipeCount; i++)
                {
                    root._Datas.Add(new() { ItemDataID = newRecipes[i].ResultItemID });
                }

                root._Datas = root._Datas
                                .DistinctBy(d => d.ItemDataID)
                                //.OrderBy(d => _itemDefinitions.FromId(d.ItemDataID)!.CategoryType)
                                .ToList();
                result = root._Datas;
                return root;
            });
        return result;
    }

    private static Recipe CreateRecipe(RecipeModel model, Rng rng)
        => new Recipe()
        {
            _Comment = model.Comment,
            DataID = model.OutputItem,
            SrcItemID1 = _itemDefinitions.NameToId(model.Item1),
            SrcItemNum1 = rng.Next(model.Count1_Min, model.Count1_Max),
            SrcItemID2 = _itemDefinitions.NameToId(model.Item2),
            SrcItemNum2 = rng.Next(model.Count2_Min, model.Count2_Max),
            ResultItemID = _itemDefinitions.NameToId(model.OutputItem),
            ResultItemNum = rng.Next(model.OutputCount_Min, model.OutputCount_Max),
            EnableFlag = Guid.Empty,
            IsTutorialTarget = false,
            IsTrophyTarget = false,
        };

    private static void AddRecipes(Randomizer randomizer, List<Recipe> recipes, bool clear)
    {
        randomizer.FileRepository.ModifyUserFile<ItemCombineData>(ItemCombineDataPath, root =>
        {
            if (clear)
            {
                root._Datas.Clear();
            }

            // Instead of appending we are prepending new recipes.
            // Our new recipes are then prioritized in the combine GUI when there are multiple possible ingredients for the same target item.
            root._Datas.PrependValues(recipes);
            return root;
        });
    }

    internal enum RecipePool
    {
        AlwaysEnabled,
        Easy,
        Balanced,
        Chaos,
        Crazy
    }

    internal sealed class RecipeModel
    {
        public RecipePool Pool { get; init; }
        public int Count1_Min { get; init; }
        public int Count1_Max { get; init; }
        public string Item1 { get; init; } = "";
        public int Count2_Min { get; init; }
        public int Count2_Max { get; init; }
        public string Item2 { get; init; } = "";
        public int OutputCount_Min { get; init; }
        public int OutputCount_Max { get; init; }
        public string OutputItem { get; init; } = "";
        public string Comment { get; init; } = "";

        public override string ToString()
            => $"[{Count1_Min}-{Count1_Max}]x {Item1} + [{Count2_Min}-{Count2_Max}]x {Item2} -> [{OutputCount_Min}-{OutputCount_Max}]x {OutputItem} ({Pool})";
    }
}