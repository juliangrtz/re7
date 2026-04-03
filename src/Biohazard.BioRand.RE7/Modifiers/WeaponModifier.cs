using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Weapons;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class WeaponModifier : Modifier
{
    private const string RandomizerKey = "modifier/weapons";
    private readonly WeaponDefinitionRepository _weaponDefinitions = WeaponDefinitionRepository.Default;

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var definition in _weaponDefinitions.WeaponDefinitions)
        {
            if (string.IsNullOrEmpty(definition.UserParamsPath))
            {
                continue;
            }

            var data = randomizer.FileRepository.DeserializeUserFile<app.WeaponGunParameter>(definition.UserParamsPath);
            var name = definition.Name ?? definition.WeaponId.ToString();
            logger.LogLine($"[{definition.UserParamsPath}] {name}: {data.Format()}");
        }
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng(RandomizerKey);
        if (randomizer.GetConfigOption<bool>("weapon-mod-damage"))
        {
            RandomizeWeaponDamage(randomizer, logger, rng);
        }

        if (randomizer.GetConfigOption<bool>("weapon-mod-ammo-capacity"))
        {
            RandomizeAmmoCapacities(randomizer, logger, rng);
        }

        if (randomizer.GetConfigOption<bool>("weapon-mod-reload-speed"))
        {
            RandomizeReloadSpeedRate(randomizer, logger, rng);
        }
    }

    private void ModifyDamageInRcol(
        string rcolPath,
        WeaponDefinition weapon,
        Randomizer randomizer,
        RandomizerLogger logger,
        double factor,
        bool randomizeStun,
        bool randomizePlayerDmg
    )
    {
        int ScaleDamage(int value) => Math.Max(0, (int)Math.Round(value * factor));

        logger.Push(weapon.Name ?? weapon.WeaponId.ToString());
        randomizer.FileRepository.ModifyRcolFile(rcolPath, randomizer.IsOnRaytracingVersion, rcol =>
        {
            foreach (var requestSet in rcol.RequestSets)
            {
                if (requestSet.UserData == null)
                {
                    logger.LogLine($"Skipping request set {requestSet.Name} in {rcolPath}, it has no user data?!");
                    continue;
                }

                var isDefaultBulletRcol = rcolPath.Contains("defaultbullet.rcol");
                if (isDefaultBulletRcol && !string.Equals(requestSet.Name, weapon.WeaponId.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var isPlayerRequestSet = requestSet.Name.Contains("player", StringComparison.OrdinalIgnoreCase);
                if (isPlayerRequestSet && !randomizePlayerDmg)
                {
                    continue;
                }

                if (requestSet.UserData.Type.Name != "app.Collision.AttackUserData")
                {
                    continue;
                }

                var attackUserData = RszSerializer.Deserialize<app.Collision.AttackUserData>(requestSet.UserData)!;
                var prevDmg = attackUserData.Damage;
                var prevStun = attackUserData.Stun;

                attackUserData.Damage = ScaleDamage(attackUserData.Damage);
                if (randomizeStun)
                {
                    attackUserData.Stun = ScaleDamage(attackUserData.Stun);
                }

                if (prevDmg == attackUserData.Damage)
                {
                    logger.LogLine($"Damage of RequestSet {requestSet.Name} remains ({prevDmg})");
                }
                else
                {
                    logger.LogLine($"Damage of RequestSet {requestSet.Name} changes from {prevDmg} to {attackUserData.Damage}");
                }

                if (prevStun == attackUserData.Stun)
                {
                    logger.LogLine($"Stun of RequestSet {requestSet.Name} remains ({prevStun})");
                }
                else
                {
                    logger.LogLine($"Stun of RequestSet {requestSet.Name} changes from {prevStun} to {attackUserData.Stun}");
                }

                requestSet.UserData = (RszObjectNode)RszSerializer.Serialize(requestSet.UserData.Type, attackUserData);
            }
        });
        logger.Pop();
    }

    private void RandomizeWeaponDamage(Randomizer randomizer, RandomizerLogger logger, Rng rng)
    {
        var randomizeStun = randomizer.GetConfigOption<bool>("weapon-mod-damage-include-stun");
        var randomizePlayerDmg = randomizer.GetConfigOption<bool>("weapon-mod-damage-include-player-damage");

        foreach (var definition in _weaponDefinitions.WeaponDefinitions)
        {
            var sanitizedId = definition.WeaponId.ToString().ToLowerInvariant().Replace("_", "-");
            var min = randomizer.GetConfigOption($"weapon-damage-min-{sanitizedId}", -1d);
            var max = randomizer.GetConfigOption($"weapon-damage-max-{sanitizedId}", -1d);
            if ((min == -1d && max == -1d) || (min == 1.0d && max == 1.0d))
            {
                continue;
            }

            var factor = Math.Round(rng.NextDouble(min, max), 1);
            foreach (var rcolPath in definition.RcolPaths)
            {
                ModifyDamageInRcol(rcolPath, definition, randomizer, logger, factor, randomizeStun, randomizePlayerDmg);
            }
        }
    }

    private void RandomizeAmmoCapacities(Randomizer randomizer, RandomizerLogger logger, Rng rng)
    {
        var ensureAtLeastOneBullet = randomizer.GetConfigOption<bool>("weapon-mod-ammo-capacity-prevent-zero");
        var minCap = ensureAtLeastOneBullet ? 1 : 0;

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
            var factor = Math.Max(minCap, Math.Round(rng.NextDouble(min, max), 1));

            randomizer.FileRepository.ModifyUserFile<app.WeaponGunParameter>(definition.UserParamsPath, root =>
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

    private void RandomizeReloadSpeedRate(Randomizer randomizer, RandomizerLogger logger, Rng rng)
    {
        var reloadSpeedRateTablePath = PakPath.UserFile("prefab/character/pl0000/pl0000reloadspeedratetable.user");
        var includeStabilizers = randomizer.GetConfigOption<bool>("weapon-mod-reload-speed-include-stabilizers");
        var min = randomizer.GetConfigOption<double>("weapon-reload-speed-min");
        var max = randomizer.GetConfigOption<double>("weapon-reload-speed-max");
        var factor = rng.NextDouble(min, max);

        randomizer.FileRepository.ModifyUserFile<app.PlayerReloadSpeedRateTable>(reloadSpeedRateTablePath, root =>
        {
            var upper = includeStabilizers ? root.ReloadSpeedRateList.Count : 1;
            for (int i = 0; i < upper; i++)
            {
                var @new = Math.Max(0.1f, Math.Round(root.ReloadSpeedRateList[i] * factor, 2));
                logger.LogLine($"[{i} stabilizers] Changing reload speed rate from {root.ReloadSpeedRateList[i]} to {@new}");
                root.ReloadSpeedRateList[i] = (float)@new;
            }

            return root;
        });
    }

    // TODO: Acid/Fire Bullets
    // Example file: em8100slipparameter.user.2
}
