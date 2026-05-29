using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Weapons;
using IntelOrca.Biohazard.REE.Messages;
using System.Text.Json.Nodes;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerWeaponModifierBehaviorTests {
    [Fact]
    public void WeaponModifier_ReloadSpeed_DoesNotModifySharedReloadSpeedTable() {
        using var result = RandomizerTest.RunState(config => {
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
    public void WeaponModifier_ReloadSpeed_IncludesREFrameworkConfigWithPerWeaponRanges() {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(config => {
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
        Assert.Equal(0.5, reframeworkConfig["weapon-reload-speed-multiplier-handgun-g17"]!.GetValue<double>());
        Assert.Null(reframeworkConfig["weapon-reload-speed-min"]);
        Assert.Null(reframeworkConfig["weapon-reload-speed-max"]);
    }

    [Fact]
    public void WeaponModifier_Damage_ModifiesMatchingAttackUserData() {
        var weapon = WeaponDefinitionRepository.Default.FromWeaponId("Handgun_G17");
        var rcolPath = weapon.RcolPaths.Single();

        using var result = RandomizerTest.RunState(config => {
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

    [Fact]
    public void WeaponModifier_GunParameterStats_ScaleWeaponGunParameters() {
        var weapon = WeaponDefinitionRepository.Default.FromWeaponId("Handgun_G17");

        using var result = RandomizerTest.RunState(config => {
            config["weapon-mod-range"] = true;
            config["weapon-range-min-handgun-g17"] = 1.5;
            config["weapon-range-max-handgun-g17"] = 1.5;

            config["weapon-mod-radius"] = true;
            config["weapon-radius-min-handgun-g17"] = 1.25;
            config["weapon-radius-max-handgun-g17"] = 1.25;

            config["weapon-mod-accuracy"] = true;
            config["weapon-accuracy-min-handgun-g17"] = 0.5;
            config["weapon-accuracy-max-handgun-g17"] = 0.5;

            config["weapon-mod-recoil"] = true;
            config["weapon-recoil-min-handgun-g17"] = 2.0;
            config["weapon-recoil-max-handgun-g17"] = 2.0;
        });

        var before = result.ReadBeforeUserFile<app.WeaponGunParameter>(weapon.UserParamsPath!);
        var after = result.ReadAfterUserFile<app.WeaponGunParameter>(weapon.UserParamsPath!);

        Assert.True(result.WasFileModified(weapon.UserParamsPath!));
        Assert.Equal(ScalePositive(before.Range, 1.5), after.Range, precision: 3);
        Assert.Equal(ScalePositive(before.AttenuationStart, 1.5), after.AttenuationStart, precision: 3);
        Assert.Equal(ScalePositive(before.AttenuationEnd, 1.5), after.AttenuationEnd, precision: 3);
        Assert.Equal(before.MinAttenuationDamageRate, after.MinAttenuationDamageRate);
        Assert.Equal(ScalePositive(before.Radius, 1.25), after.Radius, precision: 3);
        Assert.Equal(Scale(before.DiffusionRadius, 0.5), after.DiffusionRadius, precision: 3);
        Assert.Equal(Scale(before.AimDiffusionRadius, 0.5), after.AimDiffusionRadius, precision: 3);
        Assert.Equal(Scale(before.RecoilXAngle, 2.0), after.RecoilXAngle, precision: 3);
        Assert.Equal(Scale(before.RecoilYAngle, 2.0), after.RecoilYAngle, precision: 3);
    }

    [Fact]
    public void WeaponModifier_ReplacesWeaponDescriptionWithRandomizedRolls() {
        using var result = RandomizerTest.RunState(config => {
            config["weapon-mod-damage"] = true;
            config["weapon-mod-damage-include-stun"] = false;
            config["weapon-mod-damage-include-player-damage"] = false;
            config["weapon-damage-min-handgun-g17"] = 1.5;
            config["weapon-damage-max-handgun-g17"] = 1.5;

            config["weapon-mod-ammo-capacity"] = true;
            config["weapon-ammo-capacity-min-handgun-g17"] = 2.0;
            config["weapon-ammo-capacity-max-handgun-g17"] = 2.0;

            config["weapon-mod-reload-speed"] = true;
            config["weapon-reload-speed-min-handgun-g17"] = 0.8;
            config["weapon-reload-speed-max-handgun-g17"] = 0.8;

            config["weapon-mod-range"] = true;
            config["weapon-range-min-handgun-g17"] = 1.4;
            config["weapon-range-max-handgun-g17"] = 1.4;

            config["weapon-mod-radius"] = true;
            config["weapon-radius-min-handgun-g17"] = 1.3;
            config["weapon-radius-max-handgun-g17"] = 1.3;

            config["weapon-mod-accuracy"] = true;
            config["weapon-accuracy-min-handgun-g17"] = 0.6;
            config["weapon-accuracy-max-handgun-g17"] = 0.6;

            config["weapon-mod-recoil"] = true;
            config["weapon-recoil-min-handgun-g17"] = 1.7;
            config["weapon-recoil-max-handgun-g17"] = 1.7;
        });

        var itemSettings = result.ReadBeforeUserFile<app.ItemSettings>(RandomizerTestPaths.ResourceItemSettingsPath);
        var handgun = itemSettings._Settings.Single(x => x.ItemDataID == "Handgun_G17");
        var afterDescription = result.ReadAfterMsgFile(RandomizerTestPaths.UiItemMessagePath)
            .GetString(handgun.ManualMsg, LanguageId.English);

        Assert.True(result.WasFileModified(RandomizerTestPaths.UiItemMessagePath));
        Assert.Equal(
            "BioRand: Damage 1.5x, Ammo capacity 2x, Reload speed 0.8x, Range 1.4x, Hit radius 1.3x, Spread 0.6x, Recoil 1.7x",
            afterDescription);
    }

    private static float Scale(float value, double factor)
        => (float)Math.Round(value * factor, 3);

    private static float ScalePositive(float value, double factor) {
        if (value == 0) {
            return 0;
        }

        return Math.Max(0.001f, Scale(value, factor));
    }
}