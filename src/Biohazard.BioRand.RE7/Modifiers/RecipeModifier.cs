using app;
using Biohazard.BioRand.RE7.Items;
using Enums.app.Item;

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

    private static readonly string DictionaryCombineDataPath = PakPath.Of("prefab/item/dictionarycombinedata.user.2");
    private static readonly string ItemCombineDataPath = PakPath.Of("prefab/item/itemcombinedata.user.2");

    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;
    private List<Recipe> originalRecipes = new();
    private List<DictionaryCombineData.Data> originalDictCombineData = new();

    #region Data

    private readonly List<ItemCategoryType> typeBlacklist = new() // Regardless of the selected mode, some items must be blacklisted.
    {
        ItemCategoryType.KeyItem, ItemCategoryType.DiscardableKeyItem, ItemCategoryType.UsableKeyItem,
        ItemCategoryType.Map, ItemCategoryType.File
    };

    private readonly List<string> originalRecipeBlacklist = new() // To prevent softlocks and keep certain weapons.
    {
        "DybbukMedicine", "TreasureMap01", "TreasureMap02", "TreasureMap03",
        "Burner"
    };

    private readonly List<Recipe> extraIngredientRecipes = new() // These items are unused in the game but can still be created if referenced.
    {
        CreateRecipeByNames(combine: 1, "Strong Chem Fluid", with: 1, "Strong Chem Fluid", toGet: 1, "Acid Powder"),
        CreateRecipeByNames(combine: 1, "Chem Fluid", with: 1, "Chem Fluid", toGet: 1, "Chilled Chem Fluid"),
        CreateRecipeByNames(combine: 1, "Chem Fluid", with: 1, "Strong Chem Fluid", toGet: 1, "Weak Acid"),
    };

    private readonly List<Recipe> easyModeRecipePool = new()
    {
        // ======== Ammo ========
        CreateRecipeByNames(combine: 20, "Enhanced Handgun Ammo", with: 2, "Gunpowder", toGet: 15, "Shotgun Shells"),
        CreateRecipeByNames(combine: 30, "Machine Gun Ammo", with: 20, "Handgun Ammo", toGet: 5, "44 MAG Ammo"),
        CreateRecipeByNames(combine: 10, "Shotgun Shells", with: 2, "Gunpowder", toGet: 5, "44 MAG Ammo"),
        CreateRecipeByNames(combine: 20, "Enhanced Handgun Ammo", with: 1, "Strong Chem Fluid", toGet: 10, "44 MAG Ammo"),
        CreateRecipeByNames(combine: 1, "Neuro Rounds", with: 1, "Chem Fluid", toGet: 3, "Flame Rounds"),
        CreateRecipeByNames(combine: 1, "Flame Rounds", with: 1, "Chem Fluid", toGet: 3, "Neuro Rounds"),

        // ======== Guns ========
        CreateRecipeByNames(combine: 1, "Knife", with: 1, "Chilled Chem Fluid", toGet: 1, "Axe"),
        CreateRecipeByNames(combine: 1, "Axe", with: 1, "Weak Acid", toGet: 1, "Crowbar"),
        CreateRecipeByNames(combine: 1, "Knife", with: 1, "Acid Powder", toGet: 1, "Survival Knife"), // Mia knife
        CreateRecipeByNames(combine: 5, "Remote Bomb", with: 1, "Acid Powder", toGet: 1, "Chainsaw"),
        CreateRecipeByNames(combine: 1, "G17 Handgun", with: 1, "Weak Acid", toGet: 1, "M19 Handgun"),
        CreateRecipeByNames(combine: 1, "M19 Handgun", with: 1, "Weak Acid", toGet: 1, "MPM Handgun"),
        CreateRecipeByNames(combine: 1, "MPM Handgun", with: 1, "Weak Acid", toGet: 5, "Remote Bomb"),

        // ======== Heal ========
        CreateRecipeByNames(combine: 1, "Psychostimulants", with: 1, "Psychostimulants", toGet: 1, "Herb"),
        CreateRecipeByNames(combine: 1, "Psychostimulants", with: 1, "Herb", toGet: 1, "First Aid Med"),
        CreateRecipeByNames(combine: 1, "Strong First Aid Med", with: 1, "Separating Agent", toGet: 2, "First Aid Med"),
        CreateRecipeByNames(combine: 1, "First Aid Med", with: 1, "First Aid Med", toGet: 1, "Strong First Aid Med"),
        CreateRecipeByNames(combine: 1, "Strong Chem Fluid", with: 1, "First Aid Med", toGet: 1, "Strong First Aid Med"),

        // ======== Drugs ========
        CreateRecipeByNames(combine: 1, "Acid Powder", with: 1, "Acid Powder", toGet: 1, "Steroids"),
        CreateRecipeByNames(combine: 1, "Stabilizer", with: 1, "Stabilizer", toGet: 1, "Steroids"),
        CreateRecipeByNames(combine: 1, "Chilled Chem Fluid", with: 1, "Weak Acid", toGet: 1, "Stabilizer"),
        CreateRecipeByNames(combine: 1, "Acid Powder", with: 1, "Weak Acid", toGet: 1, "Stabilizer"),

        // ======== Etc. ========
        CreateRecipeByNames(combine: 1, "Chilled Chem Fluid", with: 1, "Chilled Chem Fluid", toGet: 1, "Repair Kit")
    };

    private readonly List<string> crazyModeItemPool = new() {
            "Leg",
            "Burner Grip",
            "Axe",
            "Driver's License",
            "\"Derelict House Footage\"", // Footage
            "\"Mia\"", // Footage
            "\"Happy Birthday\"", // Footage
            "Strong Chem Fluid",
            "Flame Rounds",
            "Neuro Rounds",
            "Crowbar",
            "Chilled Chem Fluid",
            "Weak Acid",
            "Acid Powder",
            "Psychostimulants",
            "Stabilizer",
            "Car Key",
            "Assault Coin",
            "Dirty Coin",
        };

    #endregion Data

    private static void LogRecipeState(RandomizerLogger logger, List<Recipe> recipes, List<DictionaryCombineData.Data> dict, bool beforeModifications)
    {
        var adjective = beforeModifications ? "Original" : "Modded";
        logger.Push($"{adjective} crafting recipes");

        foreach (var recipe in recipes)
        {
            logger.LogLine(itemDefinitions.FormatRecipe(recipe));
        }

        logger.Pop();

        logger.Push($"{adjective} crafting dictionary");
        foreach (var itemId in dict.Select(d => itemDefinitions.FromId(d.ItemDataID)?.Name).Choose())
        {
            logger.LogLine(itemId);
        }
        logger.Pop();
    }

    public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        originalRecipes = randomizer.FileRepository.DeserializeUserFile<ItemCombineData>(ItemCombineDataPath)._Datas;
        originalDictCombineData = randomizer.FileRepository.DeserializeUserFile<DictionaryCombineData>(DictionaryCombineDataPath)._Datas;
        LogRecipeState(logger, originalRecipes, originalDictCombineData, beforeModifications: true);
    }

    public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        var addNewRecipes = randomizer.GetConfigOption<bool>("recipes-add-new");
        var replaceOriginalRecipes = randomizer.GetConfigOption<bool>("recipes-replace-original");

        if (!addNewRecipes && !replaceOriginalRecipes)
        {
            return;
        }

        var mode = randomizer.GetConfigOption<string>("recipes-randomization-mode");
        var rng = randomizer.GetRng(RandomizerKey);
        if (mode == "No crafting")
        {
            // Disable crafting entirely.
            AddRecipes(randomizer, [], clear: true);
            RebuildDictionary(randomizer, []);
            return;
        }

        // Apply config
        var recipePool = mode switch
        {
            "Easy" => CreateEasyPool(rng),
            "Balanced" => CreateBalancedPool(rng),
            "Chaos" => CreateChaosPool(rng),
            "Crazy" => CreateCrazyPool(rng),
            _ => throw new ArgumentException($"Invalid recipe randomization mode '{mode}' supplied!")
        };

        if (!randomizer.GetConfigOption<bool>("recipes-allow-stabilizers-and-steroids"))
        {
            recipePool.RemoveAll(recipe => recipe.ResultItemID is "Depressant" or "Stimulant");
        }

        if (replaceOriginalRecipes)
        {
            ReplaceOriginalRecipes(randomizer, rng, recipePool);
        }

        var addedRecipes = new List<Recipe>();
        if (addNewRecipes)
        {
            var min = randomizer.GetConfigOption<int>("recipes-new-min");
            var max = randomizer.GetConfigOption<int>("recipes-new-max");
            var amount = rng.Next(min, max);
            addedRecipes.AddRange(recipePool.OrderBy(_ => rng.Next()).Take(amount));
        }
        AddRecipes(randomizer, addedRecipes, clear: false);

        // Rebuild dictionarycombinedata.user.2
        // This file holds the result item IDs of the items that are displayed in the combine GUI.
        var newDict = RebuildDictionary(randomizer, addedRecipes);

        // Finally, write the spoiler log.
        LogRecipeState(logger, addedRecipes, newDict, beforeModifications: false);
    }

    private static List<DictionaryCombineData.Data> RebuildDictionary(RE7Randomizer randomizer, List<Recipe> newRecipes)
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
                                .OrderBy(d => itemDefinitions.FromId(d.ItemDataID)!.CategoryType)
                                .ToList();
                result = root._Datas;
                return root;
            });
        return result;
    }

    private static Recipe CreateRecipeByNames(
        int combine,
        string srcItemName1,
        int with,
        string srcItemName2,
        int toGet,
        string resultItemName
    ) => new Recipe()
    {
        _Comment = "Generated by BioRand.",
        DataID = resultItemName,
        SrcItemID1 = itemDefinitions.GetIdByName(srcItemName1),
        SrcItemNum1 = combine,
        SrcItemID2 = itemDefinitions.GetIdByName(srcItemName2),
        SrcItemNum2 = with,
        ResultItemID = itemDefinitions.GetIdByName(resultItemName),
        ResultItemNum = toGet,
        EnableFlag = Guid.Empty,
        IsTutorialTarget = false,
        IsTrophyTarget = false,
    };

    private static Recipe CreateRecipeByIds(
        int combine,
        string srcItemId1,
        int with,
        string srcItemId2,
        int toGet,
        string resultItemId
    ) => new Recipe()
    {
        _Comment = "Generated by BioRand.",
        DataID = resultItemId,
        SrcItemID1 = srcItemId1,
        SrcItemNum1 = combine,
        SrcItemID2 = srcItemId2,
        SrcItemNum2 = with,
        ResultItemID = resultItemId,
        ResultItemNum = toGet,
        EnableFlag = Guid.Empty,
        IsTutorialTarget = false,
        IsTrophyTarget = false,
    };

    private static void AddRecipes(RE7Randomizer randomizer, List<Recipe> recipes, bool clear)
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

    private List<Recipe> ReplaceOriginalRecipes(RE7Randomizer randomizer, Rng rng, List<Recipe> pool)
    {
        var replacements = new List<Recipe>();
        randomizer.FileRepository.ModifyUserFile<ItemCombineData>(ItemCombineDataPath, root =>
        {
            replacements = root._Datas;
            for (int i = 0; i < replacements.Count; i++)
            {
                var recipe = replacements[i];

                if (!originalRecipes.Contains(recipe))
                    continue;

                if (originalRecipeBlacklist.Contains(recipe.ResultItemID))
                    continue;

                replacements[i] = rng.Next(pool);
            }

            root._Datas = replacements;
            return root;
        });

        return replacements;
    }

    #region Pool generation

    private List<Recipe> CreateEasyPool(Rng rng)
    {
        var pool = new List<Recipe>(extraIngredientRecipes);
        var groups = easyModeRecipePool.GroupBy(recipe => recipe.ResultItemID);
        foreach (var group in groups)
        {
            pool.Add(rng.Next(group));
        }
        return pool;
    }

    private List<Recipe> CreateBalancedPool(Rng rng)
    {
        var pool = new List<Recipe>();
        var validItems = itemDefinitions
            .Where(i => !typeBlacklist.Contains(i.CategoryType))
            .Where(i => !i.IsDlcItem) // We don't support DLC items yet.
            .Where(i => i.Name is not "Acid Powder" and not "Chilled Chem Fluid" and not "Weak Acid")
            .ToList();

        foreach (var original in originalRecipes)
        {
            if (originalRecipeBlacklist.Contains(original.ResultItemID))
                continue;

            var originalResult = itemDefinitions.FromId(original.ResultItemID)!;

            var candidates = validItems
                .Where(i => i.CategoryType == originalResult.CategoryType) // Stay within the category.
                .ToList();

            if (candidates.Count == 0)
                continue;

            var replacement = rng.Next(candidates);
            pool.Add(CreateRecipeByIds(
                    original.SrcItemNum1, original.SrcItemID1, original.SrcItemNum2, original.SrcItemID2,
                    original.ResultItemNum, replacement.Id
            ));
        }

        return pool.ToList();
    }

    private List<Recipe> CreateChaosPool(Rng rng)
    {
        var pool = new List<Recipe>();

        var validItems = itemDefinitions
            .Where(i => !typeBlacklist.Contains(i.CategoryType))
            .Where(i => !i.IsDlcItem)
            .ToList();

        foreach (var original in originalRecipes)
        {
            if (originalRecipeBlacklist.Contains(original.ResultItemID))
                continue;

            var replacement = rng.Next(validItems);
            pool.Add(CreateRecipeByIds(
                    original.SrcItemNum1, original.SrcItemID1, original.SrcItemNum2, original.SrcItemID2,
                    original.ResultItemNum, replacement.Id
            ));
        }

        return pool;
    }

    private List<Recipe> CreateCrazyPool(Rng rng)
    {
        var recipes = new List<Recipe>();

        var validIngredients = itemDefinitions
            .Where(i => !typeBlacklist.Contains(i.CategoryType))
            .Where(i => !i.IsDlcItem)
            .ToList();

        var crazyResults = crazyModeItemPool
            .Select(itemDefinitions.FromName)
            .Choose()
            .OrderBy(_ => rng.Next())
            .ToList();

        int count = Math.Min(MaxRecipeCount, crazyResults.Count);
        for (int i = 0; i < count; i++)
        {
            var ingredient1 = rng.Next(validIngredients);
            var ingredient2 = rng.Next(validIngredients);
            var result = crazyResults[i];

            recipes.Add(CreateRecipeByIds(
                rng.Next(1, 5),
                ingredient1.Id,
                rng.Next(1, 5),
                ingredient2.Id,
                rng.Next(1, 42),
                result!.Id
            ));
        }

        return recipes;
    }

    #endregion Pool generation
}