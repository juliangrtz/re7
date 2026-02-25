namespace Biohazard.BioRand.RE7.Inventory;

internal enum WeaponTier
{
    Low = 0,
    Medium = 1,
    High = 2
}

internal class StartingInventoryProfile
{
    public WeaponTier MinTier { get; set; }
    public WeaponTier MaxTier { get; set; }
    public int MinAmmo { get; set; }
    public int MaxAmmo { get; set; }
    public int HealingCount { get; set; }
    public bool AllowLateGameWeapons { get; set; }
    public bool AllowSpecialWeapons { get; set; }
}