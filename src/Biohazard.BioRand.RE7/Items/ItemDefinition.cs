using Biohazard.BioRand.RE7.DLC;
using Enums.app;
using Enums.app.Item;
using System.Text.Json.Serialization;

namespace Biohazard.BioRand.RE7.Items;

/// <summary>
/// Represents the definition of an RE7 item.
/// Not to be confused with a concrete <see cref="Item"/>!
/// </summary>
public sealed class ItemDefinition
{
    /// <summary>
    /// Unique identifier.
    /// Often but not always an <see cref="ItemID"/>.
    /// <para></para>
    /// Example: FoundFootage000
    /// </summary>
    public required string Id { get; set; }

    /// <summary>
    /// More readable name than the <see cref="Id"/> used in RE7's UI.
    /// <para></para>
    /// Example: Derelict House Footage
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Used to differentiate between different categories like ammo, health, weapon etc.
    /// </summary>
    public ItemCategoryType CategoryType { get; set; }

    /// <summary>
    /// Space used in the inventory.
    /// <para></para>
    /// Example: Slot1
    /// </summary>
    public ItemSlotSize Size { get; set; } = ItemSlotSize.Slot1;

    /// <summary>
    /// Whether the item is an unlockable extra.
    /// See <a href="https://steamcommunity.com/sharedfiles/filedetails?id=1761418830">here</a>
    /// </summary>
    public bool IsUnlockable { get; set; }

    /// <summary>
    /// Specifies the DLC the item exists in.
    /// <para></para>
    /// Example: NotAHero
    /// </summary>
    public DlcType? Dlc { get; set; }

    /// <summary>
    /// Maximum stack number of the item. Always 1 for weapons.
    /// </summary>
    public int MaxStack { get; set; }

    /// <summary>
    /// Identifier if the item is a weapon.
    /// Often the same as the <see cref="ItemID"/> if the <see cref="CategoryType"/> is <see cref="ItemCategoryType.Weapon"/>.
    /// </summary>
    public WeaponID? WeaponId { get; set; }

    /// <summary>
    /// Whether the item can be stored in the item box.
    /// </summary>
    public bool CanStoreInItemBox { get; set; }

    /// <summary>
    /// Japanese developer comment extracted from the game files.
    /// Sometimes gives helpful information if the item is special.
    /// Must be (de)serialized as UTF-8!
    /// </summary>
    public string? DeveloperComment { get; set; }

    /// <summary>
    /// Which user file the definition's data is coming from.
    /// Stored to be able to later re-write stuff.
    /// </summary>
    public string? SourceUserFile { get; set; }

    [JsonIgnore]
    public bool IsWeapon => CategoryType == ItemCategoryType.Weapon;

    [JsonIgnore]
    public bool IsStackable => MaxStack > 1;

    [JsonIgnore]
    public bool IsDlcItem => Dlc != null;

    public ItemID? ItemId => EnumExtensions.ParseOrNull<ItemID>(Id);

    /// <summary>
    /// Items required to progress the story.
    /// Particular attention is required with these!
    /// </summary>
    private readonly List<string> _storyProgressionItems = [
        "3CrestKeyA",
        "3CrestKeyB",
        "3CrestKeyC",
        "Balloonbomb",
        "Battery",
        "CabinKey",
        "Candle",
        "Candle_Lighted",
        "ChainCutter",
        "ChainSaw",
        "Crank",
        "DybbukMedicine",
        "EntranceHallKey",
        "EthanCarKey",
        "EthanLeg",
        "EvCable",
        "EvelynRadar",
        "EvelynRadar1",
        "EvelynRadar2",
        "EvelynRadar3",
        "EvelynRadar4",
        "EvOpener",
        "FloorDoorKey",
        "FoundFootage000",
        "FoundFootage030",
        "FoundFootage040",
        "FoundFootage050",
        "Fuse",
        "FuseCh4",
        "Glasses",
        "Glasses_End",
        "Glasses_Washed",
        "HandAxe",
        "HandCutOff",
        "Handgun_Albert",
        "Lantern",
        "LucasCardKey",
        "LucasCardKey2",
        "MasterKey",
        "MorgueKey",
        "Order",
        "PendulumClock",
        "Quill",
        "ScrewFinger",
        "SerumComplete",
        "SerumMaterialA",
        "SerumMaterialB",
        "SerumTypeE",
        "SilhouettePazzlePiece",
        "SilhouettePazzlePieceChildroom",
        "SilhouettePazzlePieceOldHouse",
        "SkinnyDoll",
        "SpareKey",
        "SpringCoil",
        "TalismanKey",
        "Timebomb",
        "Valve",
        "WorkroomKey",
    ];

    [JsonIgnore]
    public bool IsStoryProgressionItem => _storyProgressionItems.Contains(Id);

    public override string ToString() => Name ?? Id;

    public string ToDetailedString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("=== Item Definition ===");
        sb.AppendLine($"Id:                 {Id}");
        sb.AppendLine($"Name:               {Name ?? "<null>"}");
        sb.AppendLine($"Category:           {CategoryType}");
        sb.AppendLine($"Size:               {Size}");
        sb.AppendLine($"Max Stack:          {MaxStack}");
        sb.AppendLine($"Is Unlockable:      {IsUnlockable}");
        sb.AppendLine($"Can Store In Box:   {CanStoreInItemBox}");
        sb.AppendLine($"DLC:                {Dlc?.ToString() ?? "<Base Game>"}");
        sb.AppendLine($"Weapon Id:          {WeaponId?.ToString() ?? "<none>"}");

        if (!string.IsNullOrWhiteSpace(DeveloperComment))
        {
            sb.AppendLine("Developer Comment:");
            sb.AppendLine($"    {DeveloperComment}");
        }

        sb.AppendLine("=======================");
        return sb.ToString();
    }
}