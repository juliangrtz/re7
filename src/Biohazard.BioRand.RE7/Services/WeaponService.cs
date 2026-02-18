using System.Collections.Generic;

namespace Biohazard.BioRand.RE7.Services {
#pragma warning disable CS9113 // Parameter is unread.
    internal class WeaponService(RE7Randomizer randomizer)
#pragma warning restore CS9113 // Parameter is unread.
    {
        private readonly List<int> _restrictedUpgrades = [];

        public void RestrictUpgrades(int wp) {
            _restrictedUpgrades.Add(wp);
        }

        public bool IsRestricted(int wp) => _restrictedUpgrades.Contains(wp);
    }
}
