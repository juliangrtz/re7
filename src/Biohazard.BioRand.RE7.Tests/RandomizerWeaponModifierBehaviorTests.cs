using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Weapons;
using System.Text.Json.Nodes;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerWeaponModifierBehaviorTests
{
    [Fact]
    public void WeaponModifier_ReloadSpeed_DoesNotModifySharedReloadSpeedTable()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["weapon-mod-reload-speed"] = true;
            config["weapon-mod-reload-speed-include-stabilizers"] = false;
            config["weapon-reload-speed-min-handgun-g17"] = 0.5;
            config["weapon-reload-speed-max-handgun-g17"] = 0.5;
        });

        Assert.False(result.WasFileModified(RandomizerTestPaths.ReloadSpeedTablePath));
        Assert.Equal(
            result.ReadBeforeBytes(RandomizerTestPaths.ReloadSpeedTablePath),
            result.ReadAfterBytes(RandomizerTestPaths.ReloadSpeedTablePath));
    }

    [Fact]
    public void WeaponModifier_ReloadSpeed_IncludesREFrameworkConfigWithPerWeaponRanges()
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config =>
        {
            config["allow-dlc-items"] = false;
            config["random-enemy-drops"] = false;
            config["recipes-add-new"] = false;
            config["weapon-mod-reload-speed"] = true;
            config["weapon-reload-speed-min-handgun-g17"] = 0.5;
            config["weapon-reload-speed-max-handgun-g17"] = 0.5;
        });

        var (zip, _) = RandomizerTest.Run(configuration.ToJson(), seed: 0x51EED);
        using var zipDisposable = zip;

        var reframeworkConfigEntry = zip.GetEntry("reframework/data/BioRand7/config.json");

        Assert.NotNull(zip.GetEntry("reframework/plugins/managed/Biohazard.BioRand.RE7.REFrameworkPlugins.dll"));
        Assert.NotNull(reframeworkConfigEntry);

        var reframeworkConfig = JsonNode.Parse(reframeworkConfigEntry!.GetBytes())!.AsObject();
        Assert.Equal(0x51EED, reframeworkConfig["biorand-seed"]!.GetValue<int>());
        Assert.True(reframeworkConfig["weapon-mod-reload-speed"]!.GetValue<bool>());
        Assert.Equal(0.5, reframeworkConfig["weapon-reload-speed-min-handgun-g17"]!.GetValue<double>());
        Assert.Equal(0.5, reframeworkConfig["weapon-reload-speed-max-handgun-g17"]!.GetValue<double>());
        Assert.Null(reframeworkConfig["weapon-reload-speed-min"]);
        Assert.Null(reframeworkConfig["weapon-reload-speed-max"]);
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
