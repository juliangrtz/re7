using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Weapons;
using Enums.app.GameManager;
using IntelOrca.Biohazard.REE.Rsz;
using System.Text;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerRemainingBehaviorTests
{
    private static readonly string EthanInventoryPath = PakPath.UserFile("leveldesign/fsm/chapter1/other/ch1_startinventory.user");
    private static readonly string ClancyInventoryPath = PakPath.UserFile("leveldesign/fsm/ff000/other/startinventory_ff000.user");
    private static readonly string MiaVhsInventoryPath = PakPath.UserFile("leveldesign/fsm/ff050/other/ff050_startinventory.user");
    private static readonly string ReloadSpeedTablePath = PakPath.UserFile("prefab/character/pl0000/pl0000reloadspeedratetable.user");
    private static readonly string ChapterJumpScenePath = PakPath.SceneFile("scenes/chapterjumpdata/chapterjumpdata.scn");
    private static readonly string Chapter4DropTablePath = PakPath.UserFile("prefab/item/reliefitemtable_04_01_0000.user");
    private static readonly string ItemCombineDataPath = PakPath.UserFile("prefab/item/itemcombinedata.user");
    private static readonly string DictionaryCombineDataPath = PakPath.UserFile("prefab/item/dictionarycombinedata.user");
    private static readonly Guid GuestHouseJumpGuid = new("88045366-0683-481a-8b9a-1d8c59aa048a");

    [Fact]
    public void StartingInventory_VhsEnabled_RandomizesVhsInventories()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-starting-inventory-ethan"] = true;
            config["random-starting-inventory-mia"] = false;
            config["random-starting-inventory-vhs"] = true;

            foreach (var category in Enum.GetValues<Inventory.StartingWeaponCategory>())
            {
                config[$"inventory-weapon-{category.ToString().ToLowerInvariant()}-ethan"] = false;
            }

            config["inventory-weapon-handgun-ethan"] = true;
            config["random-starting-inventory-give-ammo"] = false;
        });

        var beforeClancy = result.ReadBeforeUserFile<app.AddItemListData>(ClancyInventoryPath)._AddItems;
        var afterClancy = result.ReadAfterUserFile<app.AddItemListData>(ClancyInventoryPath)._AddItems;
        var beforeMiaVhs = result.ReadBeforeUserFile<app.AddItemListData>(MiaVhsInventoryPath)._AddItems;
        var afterMiaVhs = result.ReadAfterUserFile<app.AddItemListData>(MiaVhsInventoryPath)._AddItems;

        Assert.True(result.WasFileModified(ClancyInventoryPath));
        Assert.False(result.WasFileModified(MiaVhsInventoryPath));
        Assert.True(afterClancy.Count > beforeClancy.Count);
        Assert.Equal(beforeMiaVhs.Count, afterMiaVhs.Count);
    }

    [Fact]
    public void StartingInventory_DebugUser_UsesInjectedDebugStartItems()
    {
        var debugCsv = """
ItemId,Quantity
Coin,2
Herb,1
""";

        using var result = RandomizerTest.RunState(
            config =>
            {
                config["username"] = "captainezekiel";
                config["random-starting-inventory-ethan"] = true;
                config["inventory-weapon-handgun-ethan"] = false;
                config["random-starting-inventory-give-ammo"] = false;
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(DynamicDataName.DebugStartItems, Encoding.UTF8.GetBytes(debugCsv));
            });

        var ethanInventory = result.ReadAfterUserFile<app.AddItemListData>(EthanInventoryPath)._AddItems;

        Assert.Equal(
            [("Coin", 2), ("Herb", 1)],
            ethanInventory.Select(x => (x.ItemDataID, x.Num)).ToArray());
    }

    [Fact]
    public void WeaponModifier_ReloadSpeed_LeavesStabilizersUntouchedWhenExcluded()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["weapon-mod-reload-speed"] = true;
            config["weapon-mod-reload-speed-include-stabilizers"] = false;
            config["weapon-reload-speed-min"] = 0.5;
            config["weapon-reload-speed-max"] = 0.5;
        });

        var before = result.ReadBeforeUserFile<app.PlayerReloadSpeedRateTable>(ReloadSpeedTablePath);
        var after = result.ReadAfterUserFile<app.PlayerReloadSpeedRateTable>(ReloadSpeedTablePath);

        Assert.True(result.WasFileModified(ReloadSpeedTablePath));
        Assert.Equal(before.ReloadSpeedRateList[0] * 0.5f, after.ReloadSpeedRateList[0], 3);
        Assert.Equal(before.ReloadSpeedRateList.Skip(1), after.ReloadSpeedRateList.Skip(1));
    }

    [Fact]
    public void WeaponModifier_Damage_ModifiesMatchingAttackUserData()
    {
        var weapon = WeaponDefinitionRepository.Default.FromWeaponId("Handgun_G17");
        var rcolPath = weapon.RcolPaths.Single();

        using var result = RandomizerTest.RunState(config =>
        {
            config["weapon-mod-damage"] = true;
            config["weapon-mod-damage-include-stun"] = false;
            config["weapon-mod-damage-include-player-damage"] = false;
            config["weapon-damage-min-handgun-g17"] = 2.0;
            config["weapon-damage-max-handgun-g17"] = 2.0;
        });

        var before = ReadAttackUserDataByRequestSet(result, rcolPath, before: true);
        var after = ReadAttackUserDataByRequestSet(result, rcolPath, before: false);

        var beforeHandgun = before["Handgun_G17"];
        var afterHandgun = after["Handgun_G17"];

        Assert.True(result.WasFileModified(rcolPath));
        Assert.Equal(beforeHandgun.Damage * 2, afterHandgun.Damage);
        Assert.Equal(beforeHandgun.Stun, afterHandgun.Stun);
    }

    [Fact]
    public void ItemDropTable_AvailableWeaponsOnly_FiltersUnavailableAmmoAndAddsLockPick()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            ConfigureSingleDropRate(config, "HandgunBullet", 0.5);
            ConfigureSingleDropRate(config, "MachineGunBullet", 0.25);
            config["item-drop-ammo-only-available-weapons"] = true;
            config["item-drop-valuable-lock-pick"] = true;
            config["item-drop-valuable-repair-kit"] = false;
            config["item-drop-valuable-weapon"] = false;
            config["item-drop-valuable-dlc-coin"] = false;
        });

        var table = result.ReadAfterUserFile<app.ReliefItemTable>(Chapter4DropTablePath);

        Assert.True(result.WasFileModified(Chapter4DropTablePath));
        Assert.DoesNotContain(table.DataList, x => x.ItemID == "HandgunBullet");
        Assert.Contains(table.DataList, x => x.ItemID == "MachineGunBullet" && x.NormalDropRate == 25);
        Assert.Contains(table.DataList, x => x.ItemID == "CylinderKey" && x.NormalDropRate == 3 && x.NormalDropNum == 1);
    }

    [Fact]
    public void ChapterJumpData_SkipGuestHouse_ChangesGuestHouseJumpToChapter3()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["skip-guest-house"] = true;
        });

        var before = GetChapterJump(result.ReadBeforeScene(ChapterJumpScenePath), GuestHouseJumpGuid);
        var after = GetChapterJump(result.ReadAfterScene(ChapterJumpScenePath), GuestHouseJumpGuid);

        Assert.True(result.WasFileModified(ChapterJumpScenePath));
        Assert.Equal(ChapterNo.Chapter1, before.JumpChapter);
        Assert.Equal(ChapterNo.Chapter3, after.JumpChapter);
    }

    [Fact]
    public void ChapterJumpData_ShuffleWithoutFoundFootage_DerangesMainCampaignTransitions()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["shuffle-chapters"] = true;
            config["shuffle-chapters-with-ff"] = false;
        });

        var candidates = new[] { ChapterNo.Chapter1, ChapterNo.Chapter3, ChapterNo.Chapter4 };
        var before = GetChapterJumps(result.ReadBeforeScene(ChapterJumpScenePath))
            .Where(x => candidates.Contains(x.JumpChapter))
            .ToArray();
        var after = GetChapterJumps(result.ReadAfterScene(ChapterJumpScenePath))
            .Where(x => before.Select(b => b.Guid).Contains(x.Guid))
            .ToArray();

        Assert.True(result.WasFileModified(ChapterJumpScenePath));
        Assert.Equal(before.Length, after.Length);
        Assert.Equal(before.Select(x => x.JumpChapter).OrderBy(x => x), after.Select(x => x.JumpChapter).OrderBy(x => x));
        Assert.All(after, entry =>
        {
            var original = before.Single(x => x.Guid == entry.Guid);
            Assert.NotEqual(original.JumpChapter, entry.JumpChapter);
        });
    }

    [Fact]
    public void KeyItemLocation_WithInjectedData_RelocatesChainCutter()
    {
        var keyItemsCsv = """
Enabled,OriginalScnFile,NewScnFile,Id,NewX,NewY,NewZ,Comment
TRUE,natives/stm/environment/scene/chapter1/c01_b1f.scn.20,natives/stm/environment/scene/chapter1/c01_corridor01.scn.20,ChainCutter,19.5,1.0,20.5,Test relocation
""";

        using var result = RandomizerTest.RunState(
            config =>
            {
                config["random-key-item-locations"] = true;
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(DynamicDataName.KeyItems, Encoding.UTF8.GetBytes(keyItemsCsv));
            });

        var placements = result.ItemPlacementService.FromId("ChainCutter")
            .Where(x => x.SceneFile == "natives/stm/environment/scene/chapter1/c01_b1f.scn.20")
            .ToArray();
        var originalScene = result.ReadAfterScene("natives/stm/environment/scene/chapter1/c01_b1f.scn.20");
        var beforeRelocatedScene = result.ReadBeforeScene("natives/stm/environment/scene/chapter1/c01_corridor01.scn.20");
        var relocatedScene = result.ReadAfterScene("natives/stm/environment/scene/chapter1/c01_corridor01.scn.20");

        Assert.All(placements, placement => Assert.Null(originalScene.FindGameObject(placement.Guid)));
        Assert.True(result.WasFileModified("natives/stm/environment/scene/chapter1/c01_corridor01.scn.20"));
        Assert.True(relocatedScene.GetGameObjects().Count() > beforeRelocatedScene.GetGameObjects().Count());
    }

    [Fact]
    public void RecipeModifier_WithInjectedRecipes_AddsSelectedRecipesAndRebuildsDictionary()
    {
        var recipesCsv = """
Pool,Count1_Min,Count1_Max,Item1,Count2_Min,Count2_Max,Item2,OutputCount_Min,OutputCount_Max,OutputItem,Comment
AlwaysEnabled,1,1,Herb,1,1,Herb,1,1,Strong Chem Fluid,Always recipe
Balanced,2,2,Handgun Ammo,1,1,Gunpowder,3,3,Shotgun Shells,Balanced recipe
Balanced,1,1,Herb,1,1,Herb,1,1,Stabilizer,Filtered recipe
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

        var beforeRecipes = result.ReadBeforeUserFile<app.ItemCombineData>(ItemCombineDataPath);
        var afterRecipes = result.ReadAfterUserFile<app.ItemCombineData>(ItemCombineDataPath);
        var afterDictionary = result.ReadAfterUserFile<app.DictionaryCombineData>(DictionaryCombineDataPath);

        Assert.True(result.WasFileModified(ItemCombineDataPath));
        Assert.True(result.WasFileModified(DictionaryCombineDataPath));
        Assert.Equal(beforeRecipes._Datas.Count + 2, afterRecipes._Datas.Count);
        Assert.Equal("ShotgunBullet", afterRecipes._Datas[0].ResultItemID);
        Assert.Equal("ChemicalM", afterRecipes._Datas[1].ResultItemID);
        Assert.Equal(["ChemicalM", "ShotgunBullet"], afterDictionary._Datas.Select(x => x.ItemDataID).ToArray());
    }

    [Fact]
    public void RecipeModifier_WithQuantityRandomization_ScalesSelectedRecipeAmounts()
    {
        var recipesCsv = """
Pool,Count1_Min,Count1_Max,Item1,Count2_Min,Count2_Max,Item2,OutputCount_Min,OutputCount_Max,OutputItem,Comment
AlwaysEnabled,1,1,Herb,1,1,Herb,1,1,Strong Chem Fluid,Always recipe
Balanced,2,2,Handgun Ammo,1,1,Gunpowder,3,3,Shotgun Shells,Balanced recipe
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

        var recipes = result.ReadAfterUserFile<app.ItemCombineData>(ItemCombineDataPath)._Datas;
        var selectedRecipe = recipes[0];

        Assert.Equal("HandgunBullet", selectedRecipe.SrcItemID1);
        Assert.Equal(4, selectedRecipe.SrcItemNum1);
        Assert.Equal("Gunpowder", selectedRecipe.SrcItemID2);
        Assert.Equal(2, selectedRecipe.SrcItemNum2);
        Assert.Equal("ShotgunBullet", selectedRecipe.ResultItemID);
        Assert.Equal(6, selectedRecipe.ResultItemNum);
    }

    [Fact]
    public void BirdCageModifier_MagnumOption_ChangesMagnumBirdCageRewards()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-bird-cage-magnum"] = true;
        });

        var path = PakPath.SceneFile("environment/scene/chapter3/c03_trailerhouse.scn");
        var before = GetBirdCageStates(result.ReadBeforeScene(path))
            .Where(x => x.ItemId == "Magnum")
            .ToArray();
        var after = GetBirdCageStates(result.ReadAfterScene(path))
            .Where(x => before.Select(b => b.ContainerGuid).Contains(x.ContainerGuid))
            .ToArray();

        Assert.True(result.WasFileModified(path));
        Assert.NotEmpty(before);
        Assert.All(after, entry =>
        {
            var original = before.Single(x => x.ContainerGuid == entry.ContainerGuid);
            Assert.NotEqual(original.ItemId, entry.ItemId);
        });
    }

    [Fact]
    public void EnemyDirectiveModifier_MoldedSpeed_ConfigUpdatesDirectiveFiles()
    {
        var enemy = EnemyDefinitions.Instance.All.First(x => x.Id == "Molded");

        using var result = RandomizerTest.RunState(config =>
        {
            config["enemy-speed-min"] = 2.0;
            config["enemy-speed-max"] = 2.0;
        });

        var holder = result.ReadAfterUserFile<app.Em4000DirectivesHolder>(enemy.DirectivesHolderPath);
        var directivePath = PakPath.UserFile(holder.holder.Units.First().Directive.Path);
        var before = result.ReadBeforeUserFile<app.Em4000BattleDirective>(directivePath);
        var after = result.ReadAfterUserFile<app.Em4000BattleDirective>(directivePath);

        Assert.True(result.WasFileModified(directivePath));
        Assert.Equal(before.movement.idleIntervalTime / 2.0f, after.movement.idleIntervalTime, 3);
        Assert.Equal(before.movement.animationSpeedRate * 2.0f, after.movement.animationSpeedRate, 3);
    }

    private static void ConfigureSingleDropRate(IntelOrca.Biohazard.BioRand.RandomizerConfiguration configuration, string id, double value)
    {
        configuration[$"item-drop-ratio-{id.ToLowerInvariant()}"] = value;
    }

    private static Dictionary<string, app.Collision.AttackUserData> ReadAttackUserDataByRequestSet(RandomizerRunResult result, string path, bool before)
    {
        var bytes = before ? result.ReadBeforeBytes(path) : result.ReadAfterBytes(path);
        var builder = new RcolFile(FileVersions.RcolFileVersion, bytes)
            .ToBuilder(result.Randomizer.FileRepository.TypeRepository);

        return builder.RequestSets
            .Where(x => x.UserData?.Type.Name == "app.Collision.AttackUserData")
            .ToDictionary(
                x => x.Name,
                x => RszSerializer.Deserialize<app.Collision.AttackUserData>(x.UserData!)!);
    }

    private static app.ChapterJumpData GetChapterJump(RszScene scene, Guid guid)
    {
        var gameObject = scene.FindGameObject(guid);
        Assert.NotNull(gameObject);
        var jump = gameObject!.FindComponent<app.ChapterJumpData>();
        Assert.NotNull(jump);
        return jump!;
    }

    private static IReadOnlyList<(Guid Guid, ChapterNo JumpChapter)> GetChapterJumps(RszScene scene)
    {
        var result = new List<(Guid, ChapterNo)>();
        scene.VisitGameObjects(gameObject =>
        {
            var jump = gameObject.FindComponent<app.ChapterJumpData>();
            if (jump != null)
            {
                result.Add((gameObject.Guid, jump.JumpChapter));
            }
        });
        return result;
    }

    private static RszGameObject GetDynamicParent(RszScene scene)
    {
        var gameObject = scene.FindGameObject(go => go.Name.EndsWith("_dynamic", StringComparison.Ordinal));
        Assert.NotNull(gameObject);
        return gameObject!;
    }

    private static List<BirdCageState> GetBirdCageStates(RszScene scene)
    {
        var states = new List<BirdCageState>();

        scene.VisitGameObjects(gameObject =>
        {
            if (!gameObject.Name.Contains("CoinBox", StringComparison.OrdinalIgnoreCase))
                return;

            var gimmick = gameObject.Children.FirstOrDefault(child =>
                child.Name.EndsWith("_Gimmick", StringComparison.Ordinal) &&
                child.FindComponent<app.CoinCounter>() != null);
            var itemHolder = gameObject.Children.FirstOrDefault(child => child.FindComponent<app.Item>() != null);
            if (gimmick == null || itemHolder == null)
                return;

            var item = itemHolder.FindComponent<app.Item>()!;
            var coinCounter = gimmick.FindComponent<app.CoinCounter>()!;
            states.Add(new BirdCageState(gameObject.Guid, item.ItemDataID, item.ItemStackNum, coinCounter.CoinMax));
        });

        return states;
    }

    private sealed record BirdCageState(Guid ContainerGuid, string ItemId, int ItemCount, int CoinCount);
}
