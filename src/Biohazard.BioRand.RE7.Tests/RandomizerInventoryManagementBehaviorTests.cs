using Biohazard.BioRand.RE7.Extensions;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerInventoryManagementBehaviorTests {
    [Fact]
    public void InventoryManagement_AllowsOnlyBirthdayBlasters_ToMoveToItemBox() {
        using var result = RandomizerTest.RunState(config => { config["inventory-unrestricted-management"] = true; });

        var keyItems = result.ReadAfterUserFile<app.ItemSettings>(RandomizerTestPaths.KeyItemSettingsPath)._Settings;
        var resourceItems =
            result.ReadAfterUserFile<app.ItemSettings>(RandomizerTestPaths.ResourceItemSettingsPath)._Settings;
        var birthdayResourceItems = result
            .ReadAfterUserFile<app.ItemSettings>(RandomizerTestPaths.BirthdayResourceItemSettingsPath)
            ._Settings;

        Assert.True(result.WasFileModified(RandomizerTestPaths.BirthdayResourceItemSettingsPath));
        Assert.True(birthdayResourceItems.Single(x => x.ItemDataID == "BlueBlaster").CanStoreItembox);
        Assert.True(birthdayResourceItems.Single(x => x.ItemDataID == "RedBlaster").CanStoreItembox);
        Assert.False(keyItems.Single(x => x.ItemDataID == "SerumComplete").CanStoreItembox);
        Assert.False(keyItems.Single(x => x.ItemDataID == "SerumTypeE").CanStoreItembox);
        Assert.False(resourceItems.Single(x => x.ItemDataID == "EvelynRadar").CanStoreItembox);
        Assert.False(resourceItems.Single(x => x.ItemDataID == "EvelynRadar1").CanStoreItembox);
        Assert.False(resourceItems.Single(x => x.ItemDataID == "EvelynRadar2").CanStoreItembox);
        Assert.False(resourceItems.Single(x => x.ItemDataID == "EvelynRadar3").CanStoreItembox);
        Assert.False(resourceItems.Single(x => x.ItemDataID == "EvelynRadar4").CanStoreItembox);
    }

    [Fact]
    public void InventoryManagement_LeavesFoundFootageMarkedAsKeyItems_ForRuntimeDiscardHook() {
        using var result = RandomizerTest.RunState(config => { config["inventory-unrestricted-management"] = true; });

        var keyItems = result.ReadAfterUserFile<app.ItemSettings>(RandomizerTestPaths.KeyItemSettingsPath)._Settings;

        Assert.Equal(
            Enums.app.Item.ItemCategoryType.KeyItem,
            keyItems.Single(x => x.ItemDataID == "FoundFootage000").Category);
    }

    [Fact]
    public void InventoryManagement_IncludesREFrameworkPlugin_WhenEnabled() {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config => {
            config["allow-dlc-items"] = false;
            config["inventory-unrestricted-management"] = true;
            config["random-enemy-drops"] = false;
            config["recipes-add-new"] = false;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0x1B0C);
        using var zipDisposable = zip;

        Assert.NotNull(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(zip.GetEntry("reframework/data/BioRand7/config.json"));
    }
}