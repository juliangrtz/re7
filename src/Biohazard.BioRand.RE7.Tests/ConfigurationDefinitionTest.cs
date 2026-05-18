using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition;

namespace Biohazard.BioRand.RE7.Tests;

public class ConfigurationDefinitionTest
{
    private readonly IEnumerable<GroupItem> items = RandomizerExecutor.ConfigurationDefinition.AllItems;

    [Fact]
    public void Test_Id_Uniqueness()
    {
        var duplicates = items
            .Where(i => i.Id != null)
            .GroupBy(i => i.Id)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        Assert.True(duplicates.Count == 0,
            $"Duplicate IDs found: {string.Join(", ", duplicates)}");
    }

    [Fact]
    public void Test_Id_Naming_Conventions()
    {
        foreach (var item in items.Where(item => item.Id != null))
        {
            Assert.Matches("^[a-zA-Z0-9\\-]+$", item.Id!);

            var id = item.Id!;
            if (id.EndsWith("-min") || id.EndsWith("-max"))
            {
                Assert.Matches("range|percent", item.Type);
            }
            // else if(id...
        }
    }

    [Fact]
    public void Test_Numeric_Sanity()
    {
        foreach (var item in items)
        {
            if (item.Min != null)
            {
                Assert.NotNull(item.Max);
                Assert.True(item.Min <= item.Max!);
            }

            if (item.Step != null)
            {
                Assert.NotNull(item.Min);
                Assert.NotNull(item.Max);
                Assert.InRange(item.Step.Value, 0.01, item.Max!.Value);
            }
        }
    }

    [Fact]
    public void Test_Min_Max_Correspondence()
    {
        foreach (var item in items.Where(item => item.Id != null))
        {
            if (item.Id!.EndsWith("-min"))
            {
                var correspondingMaxValue = item.Id.ReplaceLastOccurrence("-min", "-max");
                Assert.Contains(items, item => item.Id == correspondingMaxValue);
            }
        }
    }

    [Fact]
    public void Test_Max_Min_Correspondence()
    {
        foreach (var item in items.Where(item => item.Id != null))
        {
            if (item.Id!.EndsWith("-max"))
            {
                var correspondingMinValue = item.Id.ReplaceLastOccurrence("-max", "-min");
                Assert.Contains(items, item => item.Id == correspondingMinValue);
            }
        }
    }

    [Fact]
    public void Test_Range_Items_Validity()
    {
        foreach (var item in items.Where(i => i.Type == "range"))
        {
            Assert.NotNull(item.Min);
            Assert.NotNull(item.Max);
            Assert.NotNull(item.Default);

            var defaultValue = Convert.ToDouble(item.Default);
            Assert.InRange(defaultValue, item.Min.Value, item.Max.Value);
        }
    }

    [Fact]
    public void Test_Dropdown_Items_Validity()
    {
        foreach (var item in items.Where(i => i.Type == "dropdown"))
        {
            Assert.NotNull(item.Options);
            Assert.NotEmpty(item.Options);
            Assert.Contains(item.Default, item.Options!);
        }
    }

    [Fact]
    public void Test_Switch_Items_Validity()
    {
        foreach (var item in items.Where(i => i.Type == "switch"))
        {
            Assert.IsType<bool>(item.Default);
        }
    }

    [Fact]
    public void Test_Stack_Limit_Items_Include_NonWeapon_Inventory_Items()
    {
        var ids = items
            .Where(item => item.Id != null)
            .Select(item => item.Id!)
            .ToHashSet(StringComparer.Ordinal);
        var itemDefinitions = ItemDefinitionRepository.Default;

        Assert.Contains(itemDefinitions.FromId("ChemicalS")!.StackLimitConfigId, ids);
        Assert.Contains(itemDefinitions.FromId("ChemicalM")!.StackLimitConfigId, ids);
        Assert.Contains(itemDefinitions.FromId("ChemicalL")!.StackLimitConfigId, ids);
        Assert.Contains(itemDefinitions.FromId("Stimulant")!.StackLimitConfigId, ids);
        Assert.Contains(itemDefinitions.FromId("Depressant")!.StackLimitConfigId, ids);
        Assert.Contains(itemDefinitions.FromId("LiquidBomb")!.StackLimitConfigId, ids);
        Assert.DoesNotContain(itemDefinitions.FromId("Handgun_G17")!.StackLimitConfigId, ids);
        Assert.DoesNotContain(itemDefinitions.FromId("BackDoorKey")!.StackLimitConfigId, ids);
        Assert.DoesNotContain(itemDefinitions.FromId("PendulumClock")!.StackLimitConfigId, ids);
        Assert.DoesNotContain(itemDefinitions.FromId("EvelynRadar")!.StackLimitConfigId, ids);
        Assert.DoesNotContain(itemDefinitions.FromId("EvelynRadar2")!.StackLimitConfigId, ids);
        Assert.DoesNotContain(itemDefinitions.FromId("EvelynRadar3")!.StackLimitConfigId, ids);
    }

    [Fact]
    public void Test_Stack_Limit_Items_Have_Readable_Unique_Labels()
    {
        var stackLimitItems = items
            .Where(item => item.Id?.StartsWith("inventory-stack-limit-", StringComparison.Ordinal) == true)
            .ToArray();
        var duplicateLabels = stackLimitItems
            .GroupBy(item => item.Label)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToList();

        Assert.All(stackLimitItems, item => Assert.False(string.IsNullOrWhiteSpace(item.Label), item.Id));
        Assert.True(duplicateLabels.Count == 0,
            $"Duplicate stack limit labels found: {string.Join(", ", duplicateLabels)}");
    }

    [Fact]
    public void Test_Type_Existence()
    {
        foreach (var item in items)
        {
            Assert.False(string.IsNullOrWhiteSpace(item.Type),
                $"Item '{item.Id}' has no type.");
        }
    }

    [Fact]
    public void Test_EnemyDrop_Configuration_Items_Exist()
    {
        var ids = items
            .Where(item => item.Id != null)
            .Select(item => item.Id!)
            .ToHashSet();

        Assert.Contains("random-enemy-drops", ids);
        Assert.Contains("enemy-drop-probability", ids);
        Assert.Contains("enemy-drop-probability-flyingbug", ids);
        Assert.Contains("enemy-drop-probability-molded", ids);
        Assert.Contains("enemy-drop-probability-jackmutated", ids);
        Assert.DoesNotContain("enemy-drop-probability-moldedblade", ids);
        Assert.Contains("enemy-drop-respect-difficulty", ids);
        Assert.Contains("enemy-drop-ammo-only-available-weapons", ids);
        Assert.Contains("enemy-drop-ammo-min", ids);
        Assert.Contains("enemy-drop-ammo-max", ids);
        Assert.Contains("enemy-drop-ratio-herb", ids);
        Assert.Contains("enemy-drop-ratio-handgunbullet", ids);
        Assert.Contains("enemy-drop-ratio-liquidbomb", ids);
        Assert.DoesNotContain("enemy-drop-ratio-stimulant", ids);
        Assert.DoesNotContain("enemy-drop-ratio-depressant", ids);
        Assert.Contains("item-drop-ratio-stimulant", ids);
        Assert.Contains("item-drop-ratio-depressant", ids);
        Assert.Contains("enemy-drop-valuable-repair-kit", ids);
        Assert.Contains("enemy-drop-valuable-lock-pick", ids);
        Assert.Contains("enemy-drop-valuable-birthday-skill", ids);
    }

    [Fact]
    public void Test_RandomEvent_Configuration_Items_Exist()
    {
        var ids = items
            .Where(item => item.Id != null)
            .Select(item => item.Id!)
            .ToHashSet();

        Assert.Contains("random-events", ids);
        Assert.Contains("random-events-interval-min", ids);
        Assert.Contains("random-events-interval-max", ids);
        Assert.Contains("event-player-status-effects", ids);
        Assert.Contains("event-player-status-duration", ids);
        Assert.Contains("event-player-blindness", ids);
        Assert.Contains("event-player-freeze", ids);
        Assert.Contains("event-player-scale-min", ids);
        Assert.Contains("event-player-scale-max", ids);
        Assert.Contains("event-weapon-infinite-ammo", ids);
        Assert.Contains("event-weapon-neuro-ammo", ids);
        Assert.Contains("event-weapon-explosive-ammo", ids);
        Assert.Contains("event-enemy-speed", ids);
        Assert.Contains("event-enemy-invisible", ids);
        Assert.Contains("event-enemy-weak", ids);
        Assert.Contains("event-enemy-strong", ids);
        Assert.Contains("event-enemy-paused", ids);
        Assert.Contains("event-enemy-radius", ids);
        Assert.Contains("event-enemy-max-targets", ids);
    }
}
