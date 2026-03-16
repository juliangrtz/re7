using app;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Enums.app;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class WeaponModifier : Modifier
{
    private const string RandomizerKey = "modifier/weapons";

    // DLC weapons such as the blasters in Jack's 55th Birthday are excluded for now.
    public static readonly List<(WeaponID, string)> WeaponPrefabs = [
        (WeaponID.MachineGun, PakPath.UserFile("prefab/weapon/wp1160_machinegun/wp1160_machinegun_parameter.user")),
        (WeaponID.Handgun_Albert, PakPath.UserFile("prefab/weapon/wp1340_chrishandgun/wp1340_chrishandgun_parameter.user")),
        (WeaponID.Magnum, PakPath.UserFile("prefab/weapon/wp1140_magnum/wp1140_magnum_parameter.user")),
        (WeaponID.Shotgun_M37, PakPath.UserFile("prefab/weapon/wp1230_pumpshotgun/wp1230_pumpshotgun_parameter.user")),
        (WeaponID.GrenadeLauncher, PakPath.UserFile("prefab/weapon/wp1110_portablecannon/wp1110_portablecannon_parameter.user")),
        (WeaponID.Handgun_M19, PakPath.UserFile("prefab/weapon/wp1010_handgun/wp1010_handgun_parameter.user")),
        (WeaponID.Handgun_MPM, PakPath.UserFile("prefab/weapon/wp1240_miahandgun/wp1240_miahandgun_parameter.user")),
        (WeaponID.Handgun_Albert_Reward, PakPath.UserFile("prefab/weapon/wp1340_chrishandgun/wp1340_chrishandgun_reward_parameter.user")),
        (WeaponID.Shotgun_DB, PakPath.UserFile("prefab/weapon/wp1030_shotgun/wp1030_shotgun_parameter.user")),
        (WeaponID.Handgun_G17, PakPath.UserFile("prefab/weapon/wp1210_handgun/wp1210_handgun_parameter.user")),
        (WeaponID.Burner, PakPath.UserFile("prefab/weapon/wp1000_gasburner/wp1000_gasburner_parameter.user"))
    ];

    private readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var (weaponId, path) in WeaponPrefabs)
        {
            var data = randomizer.FileRepository.DeserializeUserFile<WeaponGunParameter>(path);
            var name = _itemDefinitions.FromId(weaponId.ToString())!.Name;
            logger.LogLine($"[{path}] {name}: {data.Format()}");
        }
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (randomizer.GetConfigOption<bool>("weapon-mod-ammo-capacity"))
        {
            var rng = randomizer.GetRng(RandomizerKey);

            foreach (var (weaponId, path) in WeaponPrefabs)
            {
                var name = _itemDefinitions.FromId(weaponId.ToString())!.Name;
                var sanitizedId = weaponId.ToString().ToLowerInvariant().Replace("_", "-");
                var min = randomizer.GetConfigOption<double>($"weapon-ammo-capacity-min-{sanitizedId}");
                var max = randomizer.GetConfigOption<double>($"weapon-ammo-capacity-max-{sanitizedId}");
                var factor = Math.Max(1, Math.Round(rng.NextDouble(min, max), 1));

                randomizer.FileRepository.ModifyUserFile<WeaponGunParameter>(path, root =>
                {
                    var newLoadNum = (int)Math.Round(root.MaxLoadNum * factor);

                    if (root.MaxLoadNum == newLoadNum)
                    {
                        logger.LogLine($"Ammo capacity of {name} remains ({root.MaxLoadNum})");
                    }
                    else
                    {
                        logger.LogLine($"Changing ammo capacity of {name} from {root.MaxLoadNum} to {newLoadNum}");
                    }
                    root.MaxLoadNum = newLoadNum;
                    return root;
                });
            }
        }

        // TODO: Reverse engineer .motlist file format
    }
}
