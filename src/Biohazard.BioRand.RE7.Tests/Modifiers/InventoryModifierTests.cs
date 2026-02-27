namespace Biohazard.BioRand.RE7.Tests.Modifiers;

public class InventoryModifierTests
{
    private const string InventoryLuaScript = "reframework/autorun/InventoryMods.lua";
    private const string EthanStartingInventoryFile = "natives/stm/leveldesign/fsm/chapter1/other/ch1_startinventory.user.2";
    private const string MiaStartingInventoryFile = "natives/stm/leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user.2";
    private const string MiaStartingInventoryFF050File = "natives/stm/leveldesign/fsm/ff050/other/ff050_startinventory.user.2";

    [Fact]
    public void Test_Random_Inventory_Off()
    {
        // Given
        var config = """
            {
              "game-version": "dx12_rt",
              "random-starting-inventory-ethan": false,
              "random-starting-inventory-mia": false
            }
            """;

        // When
        var (resultZip, resultPak) = RandomizerTest.Run(config);

        // Then
        Assert.Null(resultZip.GetEntry(InventoryLuaScript));
        Assert.Null(resultPak.GetEntryData(EthanStartingInventoryFile));
        Assert.Null(resultPak.GetEntryData(MiaStartingInventoryFile));
        Assert.Null(resultPak.GetEntryData(MiaStartingInventoryFF050File));
    }

    [Fact]
    public void Test_Random_Inventory_On_With_Default_Inventory_Sizes()
    {
        // Given
        var config = """
            {
              "game-version": "dx12_rt",
              "random-starting-inventory-ethan": true,
              "random-starting-inventory-mia": true,
              "random-starting-inventory-size-ethan": "12",
              "random-starting-inventory-size-mia": "12",
              "inventory-weapon-bladed-ethan": true,
              "inventory-weapon-chainsaw-ethan": true,
              "inventory-weapon-bladed-mia": true,
              "inventory-weapon-chainsaw-mia": true
            }
            """;

        // When
        var (resultZip, resultPak) = RandomizerTest.Run(config);

        // Then
        Assert.Null(resultZip.GetEntry(InventoryLuaScript));
        Assert.NotNull(resultPak.GetEntryData(EthanStartingInventoryFile));
        Assert.NotNull(resultPak.GetEntryData(MiaStartingInventoryFile));
        Assert.NotNull(resultPak.GetEntryData(MiaStartingInventoryFF050File));
    }

    [Fact]
    public void Test_Random_Inventory_On_With_Non_Default_Inventory_Sizes()
    {
        // Given
        var config = """
            {
              "game-version": "dx12_rt",
              "random-starting-inventory-ethan": true,
              "random-starting-inventory-mia": true,
              "random-starting-inventory-size-ethan": "20",
              "random-starting-inventory-size-mia": "20",
              "inventory-weapon-bladed-ethan": true,
              "inventory-weapon-chainsaw-ethan": true,
              "inventory-weapon-bladed-mia": true,
              "inventory-weapon-chainsaw-mia": true
            }
            """;

        // When
        var (resultZip, resultPak) = RandomizerTest.Run(config);

        // Then
        Assert.NotNull(resultZip.GetEntry(InventoryLuaScript));
        Assert.NotNull(resultPak.GetEntryData(EthanStartingInventoryFile));
        Assert.NotNull(resultPak.GetEntryData(MiaStartingInventoryFile));
        Assert.NotNull(resultPak.GetEntryData(MiaStartingInventoryFF050File));
    }
}