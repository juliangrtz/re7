using Biohazard.BioRand.RE7.Weapons;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerWeaponModifierBehaviorTests
{
    [Fact]
    public void WeaponModifier_ReloadSpeed_LeavesStabilizersUntouchedWhenExcluded()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["weapon-mod-reload-speed"] = true;
            config["weapon-mod-reload-speed-include-stabilizers"] = false;
            config["weapon-reload-speed-min"] = 0.5;
            config["weapon-reload-speed-max"] = 0.5;
        });

        var before = result.ReadBeforeUserFile<app.PlayerReloadSpeedRateTable>(RandomizerTestPaths.ReloadSpeedTablePath);
        var after = result.ReadAfterUserFile<app.PlayerReloadSpeedRateTable>(RandomizerTestPaths.ReloadSpeedTablePath);

        Assert.True(result.WasFileModified(RandomizerTestPaths.ReloadSpeedTablePath));
        Assert.Equal(before.ReloadSpeedRateList[0] * 0.5f, after.ReloadSpeedRateList[0], 3);
        Assert.Equal(before.ReloadSpeedRateList.Skip(1), after.ReloadSpeedRateList.Skip(1));
    }

    [Fact]
    public void WeaponModifier_Damage_ModifiesMatchingAttackUserData()
    {
        var weapon = WeaponDefinitionRepository.Default.FromWeaponId("Handgun_G17");
        var rcolPath = weapon.RcolPaths.Single();

        using var result = RandomizerTest.RunState(config =>
        {
            config["weapon-mod-damage"] = true;
            config["weapon-mod-damage-include-stun"] = false;
            config["weapon-mod-damage-include-player-damage"] = false;
            config["weapon-damage-min-handgun-g17"] = 2.0;
            config["weapon-damage-max-handgun-g17"] = 2.0;
        });

        var before = RandomizerTestHelpers.ReadAttackUserDataByRequestSet(result, rcolPath, before: true);
        var after = RandomizerTestHelpers.ReadAttackUserDataByRequestSet(result, rcolPath, before: false);

        var beforeHandgun = before["Handgun_G17"];
        var afterHandgun = after["Handgun_G17"];

        Assert.True(result.WasFileModified(rcolPath));
        Assert.Equal(beforeHandgun.Damage * 2, afterHandgun.Damage);
        Assert.Equal(beforeHandgun.Stun, afterHandgun.Stun);
    }
}
