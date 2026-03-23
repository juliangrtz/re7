using app;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Weapons;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class WeaponModifier : Modifier
{
    private const string RandomizerKey = "modifier/weapons";
    private readonly WeaponDefinitionRepository _weaponDefinitions = WeaponDefinitionRepository.Default;

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var definition in _weaponDefinitions.WeaponDefinitions)
        {
            if(string.IsNullOrEmpty(definition.UserParamsPath))
            {
                continue;
            }

            var data = randomizer.FileRepository.DeserializeUserFile<WeaponGunParameter>(definition.UserParamsPath);
            var name = definition.Name ?? definition.WeaponId.ToString();
            logger.LogLine($"[{definition.UserParamsPath}] {name}: {data.Format()}");
        }
    }

    private void RandomizeWeaponDamage(Randomizer randomizer, Rng rng)
    {
        var path = PakPath.RcolFile("collision/collider/weapon/defaultbullet.rcol");
        randomizer.FileRepository.ModifyRcolFile(path, randomizer.IsOnRaytracingVersion, rcol =>
        {
            //foreach (var requestSet in rcol.RequestSets)
            //{
            //    if (requestSet.Name == "Magnum")
            //    {
            //        var attackUserData = RszSerializer.Deserialize<app.Collision.AttackUserData>(requestSet.UserData!)!;
            //        attackUserData.Damage = 99999;
            //        attackUserData.Stun = 99999;
            //        requestSet.UserData = (RszObjectNode)RszSerializer.Serialize(requestSet.UserData!.Type, attackUserData);
            //    }
            //}
        });
    }


    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng(RandomizerKey);

        if (randomizer.GetConfigOption<bool>("weapon-mod-damage-values"))
        {
            RandomizeWeaponDamage(randomizer, rng);
        }

        if (randomizer.GetConfigOption<bool>("weapon-mod-ammo-capacity"))
        {
            foreach (var definition in _weaponDefinitions.WeaponDefinitions)
            {
                if (definition.UserParamsPath == null)
                {
                    continue;
                }

                var name = definition.Name;
                var sanitizedId = definition.WeaponId.ToString().ToLowerInvariant().Replace("_", "-");
                var min = randomizer.GetConfigOption<double>($"weapon-ammo-capacity-min-{sanitizedId}");
                var max = randomizer.GetConfigOption<double>($"weapon-ammo-capacity-max-{sanitizedId}");
                var factor = Math.Max(1, Math.Round(rng.NextDouble(min, max), 1));

                randomizer.FileRepository.ModifyUserFile<WeaponGunParameter>(definition.UserParamsPath, root =>
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
    }
}
