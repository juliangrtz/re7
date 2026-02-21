using Biohazard.BioRand.RE7.DLC;
using Enums.app;
using Enums.app.Item;
using System;
using System.Text.Json.Serialization;

namespace Biohazard.BioRand.RE7.Items
{
    /// <summary>
    /// Represents the definition of an RE7 item.
    /// Not to be confused with a concrete <see cref="Item"/>!
    /// </summary>
    public class ItemDefinition
    {
        /// <summary>
        /// Unique identifier.
        /// <para></para>
        /// Example: FoundFootage000
        /// </summary>
        public ItemID Id { get; set; }

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
        /// </summary>
        public WeaponID? WeaponId { get; set; }

        /// <summary>
        /// Whether the item can be stored in the item box.
        /// </summary>
        public bool CanStoreInItemBox { get; set; }

        /// <summary>
        /// Extracted from the game files.
        /// </summary>
        public string? DeveloperComment { get; set; }

        public override string ToString() => Name ?? Id.ToString();

        // TODO
        public string ToDetailedString()
        {
            throw new NotImplementedException();
        }
    }
}
