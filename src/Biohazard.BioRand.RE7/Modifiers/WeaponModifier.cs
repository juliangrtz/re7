using app;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Enums.app;
using IntelOrca.Biohazard.BioRand;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class WeaponModifier : Modifier
{
    private const string RandomizerKey = "modifier/weapons";

    // DLC weapons such as the blasters in Jack's 55th Birthday are excluded for now.
    public static readonly List<(WeaponID, string)> WeaponPrefabs = [
        (WeaponID.MachineGun, "prefab/weapon/wp1160_machinegun/wp1160_machinegun_parameter.user"),
        (WeaponID.Handgun_Albert, "prefab/weapon/wp1340_chrishandgun/wp1340_chrishandgun_parameter.user"),
        (WeaponID.Magnum, "prefab/weapon/wp1140_magnum/wp1140_magnum_parameter.user"),
        (WeaponID.Shotgun_M37, "prefab/weapon/wp1230_pumpshotgun/wp1230_pumpshotgun_parameter.user"),
        (WeaponID.GrenadeLauncher, "prefab/weapon/wp1110_portablecannon/wp1110_portablecannon_parameter.user"),
        (WeaponID.Handgun_M19, "prefab/weapon/wp1010_handgun/wp1010_handgun_parameter.user"),
        (WeaponID.Handgun_MPM, "prefab/weapon/wp1240_miahandgun/wp1240_miahandgun_parameter.user"),
        (WeaponID.Handgun_Albert_Reward, "prefab/weapon/wp1340_chrishandgun/wp1340_chrishandgun_reward_parameter.user"),
        (WeaponID.Shotgun_DB, "prefab/weapon/wp1030_shotgun/wp1030_shotgun_parameter.user"),
        (WeaponID.Handgun_G17, "prefab/weapon/wp1210_handgun/wp1210_handgun_parameter.user"),
        (WeaponID.Burner, "prefab/weapon/wp1000_gasburner/wp1000_gasburner_parameter.user")
    ];

    private readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var (weaponId, path) in WeaponPrefabs)
        {
            var pakPath = PakPath.UserFile(path);
            var data = randomizer.FileRepository.DeserializeUserFile<WeaponGunParameter>(pakPath);
            var name = _itemDefinitions.FromId(weaponId.ToString())!.Name;
            logger.LogLine($"[{pakPath}] {name}: {data.Format()}");
        }
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        // TODO





    }
}
