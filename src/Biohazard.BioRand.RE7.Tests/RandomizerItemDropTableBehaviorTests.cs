namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerItemDropTableBehaviorTests
{
    [Fact]
    public void ItemDropTable_AvailableWeaponsOnly_FiltersUnavailableAmmoAndAddsLockPick()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            RandomizerTestHelpers.ConfigureSingleDropRate(config, "HandgunBullet", 0.5);
            RandomizerTestHelpers.ConfigureSingleDropRate(config, "MachineGunBullet", 0.25);
            config["item-drop-ammo-only-available-weapons"] = true;
            config["item-drop-valuable-lock-pick"] = true;
            config["item-drop-valuable-repair-kit"] = false;
            config["item-drop-valuable-weapon"] = false;
            config["item-drop-valuable-dlc-coin"] = false;
        });

        var table = result.ReadAfterUserFile<app.ReliefItemTable>(RandomizerTestPaths.Chapter4DropTablePath);

        Assert.True(result.WasFileModified(RandomizerTestPaths.Chapter4DropTablePath));
        Assert.DoesNotContain(table.DataList, x => x.ItemID == "HandgunBullet");
        Assert.Contains(table.DataList, x => x.ItemID == "MachineGunBullet" && x.NormalDropRate == 25);
        Assert.Contains(table.DataList, x => x.ItemID == "CylinderKey" && x.NormalDropRate == 3 && x.NormalDropNum == 1);
    }
}
