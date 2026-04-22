using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerEnemyDirectiveBehaviorTests
{
    [Fact]
    public void EnemyDirectiveModifier_MoldedSpeed_ConfigUpdatesDirectiveFiles()
    {
        var enemy = EnemyDefinitions.Instance.All.First(x => x.Id == "Molded");

        using var result = RandomizerTest.RunState(config =>
        {
            config["random-enemy-speed"] = true;
            config["enemy-speed-min"] = 2.0;
            config["enemy-speed-max"] = 2.0;
        });

        var holder = result.ReadAfterUserFile<app.Em4000DirectivesHolder>(enemy.DirectivesHolderPath);
        var directivePath = PakPath.UserFile(holder.holder.Units.First().Directive.Path);
        var before = result.ReadBeforeUserFile<app.Em4000BattleDirective>(directivePath);
        var after = result.ReadAfterUserFile<app.Em4000BattleDirective>(directivePath);

        Assert.True(result.WasFileModified(directivePath));
        Assert.Equal(before.movement.idleIntervalTime / 2.0f, after.movement.idleIntervalTime, 3);
        Assert.Equal(before.movement.animationSpeedRate * 2.0f, after.movement.animationSpeedRate, 3);
    }
}
