using Enums.app;

namespace Biohazard.BioRand.RE7.Inventory;

public enum StartingWeaponCategory
{
    Bladed,
    Chainsaw,
    CircularSaw,
    Handgun,
    MachineGun,
    Shotgun,
    Bomb,
    Burner,
    Magnum,
    GrenadeLauncher
};

internal static class StartingWeaponCategoryExtensions
{
    public static string GetLabel(this StartingWeaponCategory category)
        => category switch
        {
            StartingWeaponCategory.Bladed => "Edged/Bladed",
            StartingWeaponCategory.Chainsaw => "Chainsaw",
            StartingWeaponCategory.CircularSaw => "Circular Saw",
            StartingWeaponCategory.Handgun => "Handgun",
            StartingWeaponCategory.MachineGun => "P19 Machine Gun",
            StartingWeaponCategory.Shotgun => "Shotgun",
            StartingWeaponCategory.Bomb => "Remote Bomb",
            StartingWeaponCategory.Burner => "Burner",
            StartingWeaponCategory.Magnum => "44 MAG",
            StartingWeaponCategory.GrenadeLauncher => "Grenade Launcher",
            _ => throw new ArgumentException("Invalid category")
        };

    public static List<ItemID> GetItemIds(this StartingWeaponCategory category)
        => category switch
        {
            StartingWeaponCategory.Bladed => [ItemID.HandAxe, ItemID.Knife, ItemID.MiaKnife],
            StartingWeaponCategory.Chainsaw => [ItemID.ChainSaw],
            StartingWeaponCategory.CircularSaw => [ItemID.CircularSaw],
            StartingWeaponCategory.Handgun => [
                ItemID.Handgun_G17, ItemID.Handgun_M19, ItemID.Handgun_MPM,
                ItemID.Handgun_Albert, ItemID.Handgun_Albert_Reward
            ],
            StartingWeaponCategory.MachineGun => [ItemID.MachineGun],
            StartingWeaponCategory.Shotgun => [ItemID.Shotgun_DB, ItemID.Shotgun_M37],
            StartingWeaponCategory.Bomb => [ItemID.LiquidBomb],
            StartingWeaponCategory.Burner => [ItemID.Burner],
            StartingWeaponCategory.Magnum => [ItemID.Magnum],
            StartingWeaponCategory.GrenadeLauncher => [ItemID.GrenadeLauncher],
            _ => throw new ArgumentException("Invalid category")
        };
}