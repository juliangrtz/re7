using Enums.app;

namespace Biohazard.BioRand.RE7.Services;

#pragma warning disable CS9113 // Parameter is unread.

internal class WeaponService(RE7Randomizer randomizer)
#pragma warning restore CS9113 // Parameter is unread.
{
    private readonly List<WeaponID> _restrictedUpgrades = [];

    public void RestrictUpgrades(WeaponID wp)
    {
        _restrictedUpgrades.Add(wp);
    }

    public bool IsRestricted(WeaponID wp) =>
        _restrictedUpgrades.Contains(wp);
}