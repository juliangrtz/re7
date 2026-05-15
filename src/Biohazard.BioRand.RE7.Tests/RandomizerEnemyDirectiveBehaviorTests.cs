using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerEnemyDirectiveBehaviorTests
{
    [Fact]
    public void EnemyDirectiveModifier_MoldedSpeed_ConfigUpdatesDirectiveFiles()
    {
        var enemy = EnemyDefinitions.Instance.All.First(x => x.Id == "Molded");

        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemy-speed"] = true;
            config["enemy-speed-min-molded"] = 2.0;
            config["enemy-speed-max-molded"] = 2.0;
        });

        var holder = result.ReadAfterUserFile<app.Em4000DirectivesHolder>(enemy.DirectivesHolderPath);
        var directivePath = PakPath.UserFile(holder.holder.Units.First().Directive.Path);
        var before = result.ReadBeforeUserFile<app.Em4000BattleDirective>(directivePath);
        var after = result.ReadAfterUserFile<app.Em4000BattleDirective>(directivePath);

        Assert.True(result.WasFileModified(directivePath));
        Assert.Equal(before.movement.idleIntervalTime / 2.0f, after.movement.idleIntervalTime, 3);
        Assert.Equal(before.movement.animationSpeedRate * 2.0f, after.movement.animationSpeedRate, 3);
    }

    [Fact]
    public void EnemyDirectiveModifier_MoldedSpeed_UsesPerEnemyConfig()
    {
        var molded = EnemyDefinitions.Instance.All.First(x => x.Id == "Molded");
        var blade = EnemyDefinitions.Instance.All.First(x => x.Id == "MoldedBlade");

        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemy-speed"] = true;
            config["enemy-speed-min-molded"] = 2.0;
            config["enemy-speed-max-molded"] = 2.0;
            config["enemy-speed-min-moldedblade"] = 1.5;
            config["enemy-speed-max-moldedblade"] = 1.5;
        });

        var moldedDirectivePath = GetFirstMoldedDirectivePath(result, molded);
        var moldedBefore = result.ReadBeforeUserFile<app.Em4000BattleDirective>(moldedDirectivePath);
        var moldedAfter = result.ReadAfterUserFile<app.Em4000BattleDirective>(moldedDirectivePath);

        var bladeDirectivePath = GetFirstMoldedDirectivePath(result, blade);
        var bladeBefore = result.ReadBeforeUserFile<app.Em4000BattleDirective>(bladeDirectivePath);
        var bladeAfter = result.ReadAfterUserFile<app.Em4000BattleDirective>(bladeDirectivePath);

        Assert.Equal(moldedBefore.movement.animationSpeedRate * 2.0f, moldedAfter.movement.animationSpeedRate, 3);
        Assert.Equal(bladeBefore.movement.animationSpeedRate * 1.5f, bladeAfter.movement.animationSpeedRate, 3);
    }

    [Fact]
    public void EnemyDirectiveModifier_MoldedSpeed_ProbabilityZeroSkipsSpeedChanges()
    {
        var enemy = EnemyDefinitions.Instance.All.First(x => x.Id == "Molded");

        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemy-speed"] = true;
            config["enemy-speed-probability"] = 0.0;
            config["enemy-speed-min-molded"] = 2.0;
            config["enemy-speed-max-molded"] = 2.0;
        });

        var directivePath = GetFirstMoldedDirectivePath(result, enemy);
        var before = result.ReadBeforeUserFile<app.Em4000BattleDirective>(directivePath);
        var after = result.ReadAfterUserFile<app.Em4000BattleDirective>(directivePath);

        Assert.Equal(before.movement.idleIntervalTime, after.movement.idleIntervalTime, 3);
        Assert.Equal(before.movement.animationSpeedRate, after.movement.animationSpeedRate, 3);
    }

    [Fact]
    public void EnemyDirectiveModifier_EnemySpeed_DoesNotModifySharedRankSpeed()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemy-speed"] = true;
            config["enemy-speed-min-molded"] = 2.0;
            config["enemy-speed-max-molded"] = 2.0;
        });

        var holderPath = PakPath.UserFile("prefab/character/misc/parameter/battle/enemyrankparameterholder.user");
        var holder = result.ReadBeforeUserFile<app.EnemyRankParameterHolder>(holderPath);
        foreach (var unit in holder.Units)
        {
            var userFilePath = PakPath.UserFile(unit.RankParameter.Path);
            Assert.False(result.WasFileModified(userFilePath));
        }
    }

    [Fact]
    public void EnemyDirectiveModifier_JackMutatedHealth_UsesIndividualAbsolutePartValues()
    {
        var directivePath = PakPath.UserFile("prefab/character/em8100/parameter/directive/em8100battledirective.user");

        using var result = RandomizerTest.RunState(config =>
        {
            config["boss-random-health"] = true;
            config["boss-health-min-jackmutated-body"] = 31000.0;
            config["boss-health-max-jackmutated-body"] = 31000.0;
            config["boss-health-min-jackmutated-eye-1"] = 1700.0;
            config["boss-health-max-jackmutated-eye-1"] = 1700.0;
            config["boss-health-min-jackmutated-final-eye"] = 1550.0;
            config["boss-health-max-jackmutated-final-eye"] = 1550.0;
        });

        var before = ReadFirstUserObject(result.ReadBeforeBytes(directivePath));
        var after = ReadFirstUserObject(result.ReadAfterBytes(directivePath));

        Assert.True(result.WasFileModified(directivePath));
        Assert.NotEqual(31000.0f, before.Get<float>("battle.Health"));
        Assert.Equal(31000.0f, after.Get<float>("battle.Health"));
        Assert.Equal(1700.0f, after.Get<float>("weak.WeakInfoList[0].MaxHealth"));
        Assert.Equal(1550.0f, after.Get<float>("weak.LastWeakMaxHealth"));
    }

    [Fact]
    public void EnemyDirectiveModifier_MargeMutatedHealth_UsesSecondaryAbsolutePartValues()
    {
        var resistPath = PakPath.UserFile("prefab/character/em3600/resistparameters/em3600resistparameter_normal.user");

        using var result = RandomizerTest.RunState(config =>
        {
            config["boss-random-health"] = true;
            config["boss-health-min-margemutated-escape-resist"] = 1111.0;
            config["boss-health-max-margemutated-escape-resist"] = 1111.0;
            config["boss-health-min-margemutated-wall-move-resist"] = 922.0;
            config["boss-health-max-margemutated-wall-move-resist"] = 922.0;
            config["boss-health-min-margemutated-sneak-grapple-resist"] = 333.0;
            config["boss-health-max-margemutated-sneak-grapple-resist"] = 333.0;
        });

        var before = ReadFirstUserObject(result.ReadBeforeBytes(resistPath));
        var after = ReadFirstUserObject(result.ReadAfterBytes(resistPath));

        Assert.True(result.WasFileModified(resistPath));
        Assert.NotEqual(1111.0f, before.Get<float>("units[0].parts[0].healthMax"));
        Assert.Equal(1111.0f, after.Get<float>("units[0].parts[0].healthMax"));
        Assert.Equal(922.0f, after.Get<float>("units[1].parts[0].healthMax"));
        Assert.Equal(333.0f, after.Get<float>("units[2].parts[0].healthMax"));
    }

    [Fact]
    public void EnemyDirectiveModifier_MoldedFatHealth_UsesLostPartAbsoluteValues()
    {
        var resistPath = PakPath.UserFile("prefab/character/em4200/parameter/resist/em4200resistparameter_04.user");

        using var result = RandomizerTest.RunState(config =>
        {
            config["enemy-random-health"] = true;
            config["enemy-health-min-moldedfat-lost-head"] = 2100.0;
            config["enemy-health-max-moldedfat-lost-head"] = 2100.0;
            config["enemy-health-min-moldedfat-lost-left-arm"] = 1100.0;
            config["enemy-health-max-moldedfat-lost-left-arm"] = 1100.0;
            config["enemy-health-min-moldedfat-lost-right-arm"] = 1200.0;
            config["enemy-health-max-moldedfat-lost-right-arm"] = 1200.0;
            config["enemy-health-min-moldedfat-lost-left-leg"] = 2200.0;
            config["enemy-health-max-moldedfat-lost-left-leg"] = 2200.0;
            config["enemy-health-min-moldedfat-lost-right-leg"] = 2300.0;
            config["enemy-health-max-moldedfat-lost-right-leg"] = 2300.0;
        });

        var before = ReadFirstUserObject(result.ReadBeforeBytes(resistPath));
        var after = ReadFirstUserObject(result.ReadAfterBytes(resistPath));

        Assert.True(result.WasFileModified(resistPath));
        Assert.NotEqual(2100.0f, before.Get<float>("units[2].parts[0].healthUnits[0].healthMax"));
        Assert.Equal(2100.0f, after.Get<float>("units[2].parts[0].healthUnits[0].healthMax"));
        Assert.Equal(1100.0f, after.Get<float>("units[2].parts[1].healthUnits[0].healthMax"));
        Assert.Equal(1200.0f, after.Get<float>("units[2].parts[2].healthUnits[0].healthMax"));
        Assert.Equal(2200.0f, after.Get<float>("units[2].parts[3].healthUnits[0].healthMax"));
        Assert.Equal(2300.0f, after.Get<float>("units[2].parts[4].healthUnits[0].healthMax"));
    }

    private static string GetFirstMoldedDirectivePath(RandomizerRunResult result, IEnemyDefinition enemy)
    {
        var holder = result.ReadAfterUserFile<app.Em4000DirectivesHolder>(enemy.DirectivesHolderPath);
        return PakPath.UserFile(holder.holder.Units.First().Directive.Path);
    }

    private static RszObjectNode ReadFirstUserObject(byte[] data)
        => new UserFile(data).GetObjects(FileRepository.RszRepository)[0];
}
