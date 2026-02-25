using Enums.app.ReticleGUI;

namespace Biohazard.BioRand.RE7.Weapons;

internal static class StartingWeaponCategory
{
    public static List<string> Values => new()
    {
        "Knife",
        "Chainsaw",
        "Circular Saw",
        "Handgun",
        "Machine gun",
        "Shotgun",
        "Bomb",
        "Burner",
        "44 MAG",
        "Grenade Launcher"
    };

    public static WeaponTypeDef? ToWeaponTypeDef(string value)
        => EnumExtensions.ParseOrNull<WeaponTypeDef>(value);
}