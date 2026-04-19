using System.Text;

using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerStartingInventoryAdditionalBehaviorTests
{
    [Fact]
    public void StartingInventory_VhsEnabled_RandomizesVhsInventories()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-starting-inventory-ethan"] = true;
            config["random-starting-inventory-mia"] = false;
            config["random-starting-inventory-vhs"] = true;

            foreach (var category in Enum.GetValues<StartingWeaponCategory>())
            {
                config[$"inventory-weapon-{category.ToString().ToLowerInvariant()}-ethan"] = false;
            }

            config["inventory-weapon-handgun-ethan"] = true;
            config["random-starting-inventory-give-ammo"] = false;
        });

        var beforeClancy = result.ReadBeforeUserFile<app.AddItemListData>(RandomizerTestPaths.ClancyInventoryPath)._AddItems;
        var afterClancy = result.ReadAfterUserFile<app.AddItemListData>(RandomizerTestPaths.ClancyInventoryPath)._AddItems;
        var beforeMiaVhs = result.ReadBeforeUserFile<app.AddItemListData>(RandomizerTestPaths.MiaVhsInventoryPath)._AddItems;
        var afterMiaVhs = result.ReadAfterUserFile<app.AddItemListData>(RandomizerTestPaths.MiaVhsInventoryPath)._AddItems;

        Assert.True(result.WasFileModified(RandomizerTestPaths.ClancyInventoryPath));
        Assert.False(result.WasFileModified(RandomizerTestPaths.MiaVhsInventoryPath));
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

        var ethanInventory = result.ReadAfterUserFile<app.AddItemListData>(RandomizerTestPaths.EthanInventoryPath)._AddItems;

        Assert.Equal(
            [("Coin", 2), ("Herb", 1)],
            ethanInventory.Select(x => (x.ItemDataID, x.Num)).ToArray());
    }
}
