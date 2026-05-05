using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Weapons;
using IntelOrca.Biohazard.REE.Messages;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerBehaviorTests
{
    private static readonly string EthanInventoryPath = PakPath.UserFile("leveldesign/fsm/chapter1/other/ch1_startinventory.user");
    private static readonly string ClancyInventoryPath = PakPath.UserFile("leveldesign/fsm/ff000/other/startinventory_ff000.user");
    private static readonly string MiaInventoryPath = PakPath.UserFile("leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user");
    private static readonly string MiaVhsInventoryPath = PakPath.UserFile("leveldesign/fsm/ff050/other/ff050_startinventory.user");
    private static readonly string ItemCombineDataPath = PakPath.UserFile("prefab/item/itemcombinedata.user");
    private static readonly string DictionaryCombineDataPath = PakPath.UserFile("prefab/item/dictionarycombinedata.user");
    private static readonly string UiMenuMessagePath = PakPath.MessageFile("message/ui_menu_mes.msg");

    [Fact]
    public void StartingInventory_Disabled_DoesNotModifyStartingInventoryFiles()
    {
        using var result = RandomizerTest.RunState();

        foreach (var path in new[] { EthanInventoryPath, ClancyInventoryPath, MiaInventoryPath, MiaVhsInventoryPath })
        {
            Assert.False(result.WasFileModified(path));
            Assert.Equal(result.ReadBeforeBytes(path), result.ReadAfterBytes(path));
        }
    }

    [Fact]
    public void StartingInventory_EnabledForEthan_AppendsAllowedWeaponsAndAmmo()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-starting-inventory-ethan"] = true;
            config["random-starting-inventory-mia"] = false;
            config["random-starting-inventory-vhs"] = false;

            foreach (var category in Enum.GetValues<StartingWeaponCategory>())
            {
                config[$"inventory-weapon-{category.ToString().ToLowerInvariant()}-ethan"] = false;
            }

            config["inventory-weapon-bladed-ethan"] = true;
            config["inventory-weapon-handgun-ethan"] = true;
            config["random-starting-inventory-give-ammo"] = true;
        });

        var before = result.ReadBeforeUserFile<app.AddItemListData>(EthanInventoryPath)._AddItems;
        var after = result.ReadAfterUserFile<app.AddItemListData>(EthanInventoryPath)._AddItems;
        var newItems = after.Skip(before.Count).ToList();

        var allowedHandguns = StartingWeaponCategory.Handgun
            .GetItemIds()
            .Select(id => id.ToString())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var allowedBladed = StartingWeaponCategory.Bladed
            .GetItemIds()
            .Select(id => id.ToString())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var allowedAmmo = StartingWeaponCategory.Handgun
            .GetItemIds()
            .Select(id => WeaponDefinitionRepository.Default.FromWeaponId(id.ToString()))
            .SelectMany(weapon => weapon.BulletItemIDs ?? [])
            .Select(id => id.ToString())
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        Assert.True(result.WasFileModified(EthanInventoryPath));
        Assert.True(after.Count > before.Count);
        Assert.Contains(newItems, item => allowedHandguns.Contains(item.ItemDataID));
        Assert.Contains(newItems, item => allowedBladed.Contains(item.ItemDataID));
        Assert.Contains(newItems, item => allowedAmmo.Contains(item.ItemDataID));
    }

    [Fact]
    public void ItemStackModifier_CustomStackSize_ChangesConfiguredItemOnly()
    {
        var handgunBullets = ItemDefinitionRepository.Default.FromId("HandgunBullet")!;
        var shotgunShells = ItemDefinitionRepository.Default.FromId("ShotgunBullet")!;
        var itemSettingsPath = $"{PakPath.Of("prefab/item")}/{handgunBullets.SourceUserFile}";

        using var result = RandomizerTest.RunState(config =>
        {
            config[handgunBullets.StackLimitConfigId] = 99;
        });

        var before = result.ReadBeforeUserFile<app.ItemSettings>(itemSettingsPath);
        var after = result.ReadAfterUserFile<app.ItemSettings>(itemSettingsPath);

        var beforeHandgunBullets = before._Settings.Single(x => x.ItemDataID == handgunBullets.Id);
        var afterHandgunBullets = after._Settings.Single(x => x.ItemDataID == handgunBullets.Id);
        var beforeShotgunShells = before._Settings.Single(x => x.ItemDataID == shotgunShells.Id);
        var afterShotgunShells = after._Settings.Single(x => x.ItemDataID == shotgunShells.Id);

        Assert.True(result.WasFileModified(itemSettingsPath));
        Assert.Equal(handgunBullets.MaxStack, beforeHandgunBullets.MaxStackNum);
        Assert.Equal(99, afterHandgunBullets.MaxStackNum);
        Assert.Equal(beforeShotgunShells.MaxStackNum, afterShotgunShells.MaxStackNum);
    }

    [Fact]
    public void ItemStackModifier_CustomStackSize_ChangesConfiguredNonStackableItem()
    {
        var chemFluid = ItemDefinitionRepository.Default.FromId("ChemicalS")!;
        var strongChemFluid = ItemDefinitionRepository.Default.FromId("ChemicalM")!;
        var itemSettingsPath = $"{PakPath.Of("prefab/item")}/{chemFluid.SourceUserFile}";

        using var result = RandomizerTest.RunState(config =>
        {
            config[chemFluid.StackLimitConfigId] = 5;
        });

        var before = result.ReadBeforeUserFile<app.ItemSettings>(itemSettingsPath);
        var after = result.ReadAfterUserFile<app.ItemSettings>(itemSettingsPath);

        var beforeChemFluid = before._Settings.Single(x => x.ItemDataID == chemFluid.Id);
        var afterChemFluid = after._Settings.Single(x => x.ItemDataID == chemFluid.Id);
        var beforeStrongChemFluid = before._Settings.Single(x => x.ItemDataID == strongChemFluid.Id);
        var afterStrongChemFluid = after._Settings.Single(x => x.ItemDataID == strongChemFluid.Id);

        Assert.True(result.WasFileModified(itemSettingsPath));
        Assert.Equal(chemFluid.MaxStack, beforeChemFluid.MaxStackNum);
        Assert.Equal(5, afterChemFluid.MaxStackNum);
        Assert.Equal(beforeStrongChemFluid.MaxStackNum, afterStrongChemFluid.MaxStackNum);
    }

    [Fact]
    public void RecipeModifier_NoCrafting_ClearsRecipesAndDictionary()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["recipes-add-new"] = true;
            config["recipes-randomization-mode"] = "No crafting";
        });

        var beforeRecipes = result.ReadBeforeUserFile<app.ItemCombineData>(ItemCombineDataPath);
        var afterRecipes = result.ReadAfterUserFile<app.ItemCombineData>(ItemCombineDataPath);
        var beforeDictionary = result.ReadBeforeUserFile<app.DictionaryCombineData>(DictionaryCombineDataPath);
        var afterDictionary = result.ReadAfterUserFile<app.DictionaryCombineData>(DictionaryCombineDataPath);

        Assert.True(result.WasFileModified(ItemCombineDataPath));
        Assert.True(result.WasFileModified(DictionaryCombineDataPath));
        Assert.NotEmpty(beforeRecipes._Datas);
        Assert.NotEmpty(beforeDictionary._Datas);
        Assert.Empty(afterRecipes._Datas);
        Assert.Empty(afterDictionary._Datas);
    }

    [Fact]
    public void WeaponModifier_AmmoCapacity_ChangesSpecificWeaponParameter()
    {
        var handgun = WeaponDefinitionRepository.Default.FromWeaponId("Handgun_G17");
        Assert.NotNull(handgun.UserParamsPath);

        using var result = RandomizerTest.RunState(config =>
        {
            config["weapon-mod-ammo-capacity"] = true;
            config["weapon-mod-ammo-capacity-prevent-zero"] = true;
            config["weapon-ammo-capacity-min-handgun-g17"] = 2.0;
            config["weapon-ammo-capacity-max-handgun-g17"] = 2.0;
        });

        var before = result.ReadBeforeUserFile<app.WeaponGunParameter>(handgun.UserParamsPath!);
        var after = result.ReadAfterUserFile<app.WeaponGunParameter>(handgun.UserParamsPath!);

        Assert.True(result.WasFileModified(handgun.UserParamsPath!));
        Assert.Equal(before.MaxLoadNum * 2, after.MaxLoadNum);
    }

    [Fact]
    public void MessageModifier_ReplacesKnownUiMessage()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["randomized-messages"] = true;
        });

        var beforeMessage = result.ReadBeforeMsgFile(UiMenuMessagePath).FindMessage("Menu_Pause_Restart_Desc");
        var afterMessage = result.ReadAfterMsgFile(UiMenuMessagePath).FindMessage("Menu_Pause_Restart_Desc");

        Assert.NotNull(beforeMessage);
        Assert.NotNull(afterMessage);

        var beforeEnglish = beforeMessage!.Values.Single(x => x.Language == LanguageId.English).Text;
        var afterEnglish = afterMessage!.Values.Single(x => x.Language == LanguageId.English).Text;

        Assert.True(result.WasFileModified(UiMenuMessagePath));
        Assert.NotEqual(beforeEnglish, afterEnglish);
    }
}
