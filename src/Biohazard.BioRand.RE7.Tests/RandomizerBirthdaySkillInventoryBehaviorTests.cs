using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.REEngine;
using Enums.app;
using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerBirthdaySkillInventoryBehaviorTests
{
    private const string Skl001ItemPrefabPath = "Prefab/Skill/skl001/Skl001.pfb";
    private const string Skl001DropPrefabPath = "Prefab/Skill/skl001/Skl001Get.pfb";
    private const string Skl001PassiveSkillUserPath = "Prefab/Skill/skl001/Skl001PassiveSkill.user";

    [Fact]
    public void BirthdaySkills_AreInjectedIntoCampaignKeyItemSettings_AsEquipItems()
    {
        using var result = RandomizerTest.RunState();

        var settings = result.ReadAfterUserFile<app.ItemSettings>(RandomizerTestPaths.KeyItemSettingsPath)._Settings;
        var skill = settings.SingleOrDefault(x => x.ItemDataID == "skl001");

        Assert.True(result.WasFileModified(RandomizerTestPaths.KeyItemSettingsPath));
        Assert.NotNull(skill);
        Assert.Equal(Enums.app.Item.ItemCategoryType.KeyItem, skill!.Category);
        Assert.Equal(ItemSortCategory.EquipItem, skill.SortCategory);
        Assert.Equal(Enums.app.Item.ItemSlotSize.Slot1, skill.SlotSize);
        Assert.Equal(Skl001ItemPrefabPath, skill.ItemPrefab.Path.ToString());
        Assert.Equal(Skl001DropPrefabPath, skill.DropItemSetting.DropItemPrefab.Path.ToString());
        Assert.DoesNotContain(settings, x => x.ItemDataID == "skl001no");
        Assert.Equal(23, settings.Count(x => x.ItemDataID.StartsWith("skl", StringComparison.OrdinalIgnoreCase)));
    }

    [Fact]
    public void BirthdaySkills_AreRegisteredInCampaignItemResources_AndUiMessages()
    {
        using var result = RandomizerTest.RunState();

        var itemResources = result.ReadAfterScene(RandomizerTestPaths.ItemResourcesScenePath);
        var skillFolder = itemResources.Children
            .OfType<IntelOrca.Biohazard.REE.Rsz.RszFolder>()
            .SingleOrDefault(x => x.Name == "skl001");
        var skillResourceScenePath = PakPath.SceneFile("scenes/items/resources/skl001.scn");
        var skillResourceScene = result.ReadAfterScene(skillResourceScenePath);
        var resourceNode = skillResourceScene.FindGameObject("ItemResource")?.FindComponent("app.ItemResource");
        var dropPrefabPath = PrefabPath(Skl001DropPrefabPath);
        var dropPrefab = result.ReadAfterPfb(dropPrefabPath);
        var itemPrefabPath = PrefabPath(Skl001ItemPrefabPath);
        var itemPrefab = result.ReadAfterPfb(itemPrefabPath);
        var passiveSkillUserPath = PakPath.UserFile(Skl001PassiveSkillUserPath);
        var dropItem = dropPrefab.GetGameObjects()
            .Select(x => x.FindComponent("app.Item"))
            .FirstOrDefault(x => x != null);
        var dropInteract = dropPrefab.GetGameObjects()
            .Select(x => x.FindComponent("app.InteractDetailSearch"))
            .FirstOrDefault(x => x != null);
        var dropPassiveSkill = dropPrefab.GetGameObjects()
            .Select(x => x.FindComponent("app.PassiveSkillItem"))
            .FirstOrDefault(x => x != null);
        var itemPassiveSkill = itemPrefab.GetGameObjects()
            .Select(x => x.FindComponent("app.PassiveSkillItem"))
            .FirstOrDefault(x => x != null);
        var birthdaySettings = result.ReadBeforeUserFile<app.ItemSettings>(PakPath.UserFile("prefab/item/birthdayskillitemsetting.user"));
        var skillSetting = birthdaySettings._Settings.Single(x => x.ItemDataID == "skl001");
        var uiItemMessages = result.ReadAfterMsgFile(RandomizerTestPaths.UiItemMessagePath);

        Assert.True(result.WasFileModified(RandomizerTestPaths.ItemResourcesScenePath));
        Assert.NotNull(skillFolder);
        Assert.Equal("Scenes/Items/Resources/skl001.scn", ((RszResourceNode)skillFolder!.Settings["ScenePath"]).Value);
        Assert.NotNull(resourceNode);
        Assert.Equal("skl001", ((RszStringNode)resourceNode!["_ItemDataId"]).Value);
        Assert.Equal(
            Skl001DropPrefabPath,
            ((RszResourceNode)((RszObjectNode)resourceNode["_ResourcePrefab"])["Path"]).Value);
        Assert.True(result.WasFileModified(dropPrefabPath));
        Assert.NotNull(dropItem);
        Assert.Equal("skl001", ((RszStringNode)dropItem!["ItemDataID"]).Value);
        Assert.NotNull(dropInteract);
        Assert.Null(dropPassiveSkill);
        Assert.True(result.WasFileModified(itemPrefabPath));
        Assert.True(result.WasFileModified(passiveSkillUserPath));
        Assert.NotNull(itemPassiveSkill);
        Assert.Equal(
            Skl001PassiveSkillUserPath,
            ((RszUserDataNode)itemPassiveSkill!["PassiveSkill"]).Path);
        Assert.Equal(result.ReadBeforeBytes(passiveSkillUserPath), result.ReadAfterBytes(passiveSkillUserPath));
        Assert.NotNull(uiItemMessages.FindMessage(skillSetting.NameMsg));
        Assert.NotNull(uiItemMessages.FindMessage(skillSetting.ManualMsg));
        Assert.Equal("Infinite Ammo", uiItemMessages.GetString(skillSetting.NameMsg, LanguageId.English));
    }

    [Fact]
    public void BirthdaySkillSupport_IncludesREFrameworkPlugin_WhenDlcItemsAreAllowed()
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config =>
        {
            config["allow-dlc-items"] = true;
            config["random-enemy-drops"] = false;
            config["recipes-add-new"] = false;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0x7B157);
        using var zipDisposable = zip;

        Assert.NotNull(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(zip.GetEntry("reframework/data/BioRand7/config.json"));
    }

    [Fact]
    public void BirthdaySkillSupport_IncludesREFrameworkPlugin_WhenStartingSkillsAreEnabled()
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config =>
        {
            config["allow-dlc-items"] = false;
            config["random-starting-inventory-skills-mia"] = true;
            config["random-enemy-drops"] = false;
            config["recipes-add-new"] = false;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0x7B157);
        using var zipDisposable = zip;

        Assert.NotNull(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(zip.GetEntry("reframework/data/BioRand7/config.json"));
    }

    private static string PrefabPath(string prefabPath)
        => $"{PakPath.Of(prefabPath)}.{FileVersions.PfbFileVersion}".ToLowerInvariant();
}
