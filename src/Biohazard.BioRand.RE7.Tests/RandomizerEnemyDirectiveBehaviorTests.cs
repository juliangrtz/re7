using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.REEngine;

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

    private static string GetFirstMoldedDirectivePath(RandomizerRunResult result, IEnemyDefinition enemy)
    {
        var holder = result.ReadAfterUserFile<app.Em4000DirectivesHolder>(enemy.DirectivesHolderPath);
        return PakPath.UserFile(holder.holder.Units.First().Directive.Path);
    }
}
