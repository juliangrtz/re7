using System.Text;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerStartingInventoryAdditionalBehaviorTests {
    [Fact]
    public void StartingInventory_VhsEnabled_RandomizesVhsInventories() {
        using var result = RandomizerTest.RunState(config => {
            config["random-starting-inventory-ethan"] = true;
            config["random-starting-inventory-mia"] = false;
            config["random-starting-inventory-vhs"] = true;

            foreach (var category in Enum.GetValues<StartingWeaponCategory>()) {
                config[$"inventory-weapon-{category.ToString().ToLowerInvariant()}-ethan"] = false;
            }

            config["inventory-weapon-handgun-ethan"] = true;
            config["random-starting-inventory-give-ammo"] = false;
        });

        var beforeClancy = result.ReadBeforeUserFile<app.AddItemListData>(RandomizerTestPaths.ClancyInventoryPath)
            ._AddItems;
        var afterClancy = result.ReadAfterUserFile<app.AddItemListData>(RandomizerTestPaths.ClancyInventoryPath)
            ._AddItems;
        var beforeMiaVhs = result.ReadBeforeUserFile<app.AddItemListData>(RandomizerTestPaths.MiaVhsInventoryPath)
            ._AddItems;
        var afterMiaVhs = result.ReadAfterUserFile<app.AddItemListData>(RandomizerTestPaths.MiaVhsInventoryPath)
            ._AddItems;

        Assert.True(result.WasFileModified(RandomizerTestPaths.ClancyInventoryPath));
        Assert.False(result.WasFileModified(RandomizerTestPaths.MiaVhsInventoryPath));
        Assert.True(afterClancy.Count > beforeClancy.Count);
        Assert.Equal(beforeMiaVhs.Count, afterMiaVhs.Count);
    }

    [Fact]
    public void StartingInventory_DebugUser_UsesInjectedDebugStartItems() {
        var debugCsv = """
                       ItemId,Quantity
                       Coin,2
                       Herb,1
                       """;

        using var result = RandomizerTest.RunState(
            config => {
                config["username"] = "captainezekiel";
                config["random-starting-inventory-ethan"] = true;
                config["inventory-weapon-handgun-ethan"] = false;
                config["random-starting-inventory-give-ammo"] = false;
            },
            prepareRandomizer: randomizer => {
                randomizer.DynamicData.SetData(DynamicDataName.DebugStartItems, Encoding.UTF8.GetBytes(debugCsv));
            });

        var ethanInventory = result.ReadAfterUserFile<app.AddItemListData>(RandomizerTestPaths.EthanInventoryPath)
            ._AddItems;

        Assert.Contains(
            [("Coin", 2), ("Herb", 1)],
            ethanInventory.Select(x => (x.ItemDataID, x.Num)).ToArray());
    }

    [Fact]
    public void StartingInventory_EthanRandomSkillsEnabled_AddsBirthdaySkillToEthan() {
        using var result = RandomizerTest.RunState(config => {
            config["random-starting-inventory-ethan"] = false;
            config["random-starting-inventory-mia"] = false;
            config["random-starting-inventory-vhs"] = false;
            config["random-starting-inventory-skills-ethan"] = true;
        });

        Assert.True(result.WasFileModified(RandomizerTestPaths.EthanInventoryPath));
        Assert.False(result.WasFileModified(RandomizerTestPaths.MiaInventoryPath));
        AssertRandomSkillItems(result, RandomizerTestPaths.EthanInventoryPath);
    }

    [Fact]
    public void StartingInventory_MiaRandomSkillsEnabled_AddsBirthdaySkillToMia() {
        using var result = RandomizerTest.RunState(config => {
            config["random-starting-inventory-ethan"] = false;
            config["random-starting-inventory-mia"] = false;
            config["random-starting-inventory-vhs"] = false;
            config["random-starting-inventory-skills-mia"] = true;
        });

        Assert.False(result.WasFileModified(RandomizerTestPaths.EthanInventoryPath));
        Assert.True(result.WasFileModified(RandomizerTestPaths.MiaInventoryPath));
        Assert.False(result.WasFileModified(RandomizerTestPaths.MiaVhsInventoryPath));
        AssertRandomSkillItems(result, RandomizerTestPaths.MiaInventoryPath);
    }

    private static void AssertRandomSkillItems(RandomizerRunResult result, string inventoryPath) {
        var before = result.ReadBeforeUserFile<app.AddItemListData>(inventoryPath)._AddItems;
        var after = result.ReadAfterUserFile<app.AddItemListData>(inventoryPath)._AddItems;
        var newItems = after.Skip(before.Count).ToArray();
        var skillItems = newItems
            .Where(item => ItemDrops.IsBirthdaySkill(item.ItemDataID))
            .ToArray();

        Assert.InRange(skillItems.Length, 1, 2);
        Assert.Equal(skillItems.Length,
            skillItems.Select(item => item.ItemDataID).Distinct(StringComparer.OrdinalIgnoreCase).Count());
        Assert.All(skillItems, item => Assert.Equal(1, item.Num));
        Assert.All(skillItems,
            item => Assert.False(item.ItemDataID.EndsWith("no", StringComparison.OrdinalIgnoreCase)));
        Assert.Equal(skillItems.Length, newItems.Length);
    }
}