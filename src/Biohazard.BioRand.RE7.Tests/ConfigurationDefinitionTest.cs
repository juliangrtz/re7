using Biohazard.BioRand.RE7.Extensions;
using static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition;

namespace Biohazard.BioRand.RE7.Tests;

public class ConfigurationDefinitionTest : RandomizerTest
{
    private readonly IEnumerable<GroupItem> items = RE7RandomizerExecutor.ConfigurationDefinition.AllItems;

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
            Assert.Matches("^[a-z0-9\\-]+$", item.Id!);

            var id = item.Id!;
            if (id.EndsWith("-min") || id.EndsWith("-max"))
            {
                Assert.Equal("range", item.Type);
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
                Assert.True(item.Min < item.Max!);
            }

            if (item.Step != null)
            {
                Assert.NotNull(item.Min);
                Assert.NotNull(item.Max);
                Assert.InRange(item.Step.Value, item.Min!.Value, item.Max!.Value);
            }
        }
    }

    [Fact]
    public void Test_Description_Uniqueness()
    {
        var duplicates = items
            .Where(i => i.Description != null)
            .GroupBy(i => i.Description)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        Assert.True(duplicates.Count == 0,
            $"Duplicate descriptions found: {string.Join(", ", duplicates)}");
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

            var defaultValue = Convert.ToInt32(item.Default);
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
    public void Test_Type_Existence()
    {
        foreach (var item in items)
        {
            Assert.False(string.IsNullOrWhiteSpace(item.Type),
                $"Item '{item.Id}' has no type.");
        }
    }
}