using Enums.app;

namespace Biohazard.BioRand.RE7.Weapons;

public static class AmmoTypes
{
    public record Lookup(
        ItemID? NormalAmmo,
        ItemID? StrongAmmo
    );

    public static Lookup? Get(WeaponID id) => id switch
    {
        WeaponID.Handgun or WeaponID.Handgun_M19 or WeaponID.Handgun_G17 or WeaponID.Handgun_MPM or WeaponID.Handgun_Albert_Reward
            => new Lookup(ItemID.HandgunBullet, ItemID.HandgunBulletL),
        WeaponID.ShotGun or WeaponID.Shotgun_M37 or WeaponID.Shotgun_M37S or WeaponID.Shotgun_DB
            => new Lookup(ItemID.ShotgunBullet, ItemID.ShotgunBullet),
        WeaponID.MachineGun => new Lookup(ItemID.MachineGunBullet, ItemID.NoName),
        WeaponID.Magnum => new Lookup(ItemID.MagnumBullet, ItemID.NoName),
        WeaponID.GrenadeLauncher => new Lookup(ItemID.NoName, ItemID.NoName),
        WeaponID.Burner => new Lookup(ItemID.BurnerBullet, ItemID.NoName),
        _ => null
    };
}