using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7.Tests;

public class EnemySceneLimitTests
{
    [Fact]
    public void EmbeddedEnemyLimitsOnlyTargetGeneralNonDlcScenes()
    {
        var generalSceneFiles = AreaDefinitionRepository.Default.All
            .Where(area => area.Kind == AreaKind.General && area.Dlc == null)
            .Select(area => area.Path)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var limits = Csv.Deserialize<EnemySceneLimit>(EmbeddedData.GetFile("enemy_limits.csv"))
            .Where(limit => !string.IsNullOrWhiteSpace(limit.SceneFile))
            .ToArray();
        var sceneFiles = limits.Select(limit => limit.SceneFile).ToList();

        Assert.NotEmpty(limits);
        Assert.Equal(sceneFiles.Count, sceneFiles.Distinct(StringComparer.OrdinalIgnoreCase).Count());
        Assert.All(limits, limit =>
        {
            Assert.Contains(limit.SceneFile, generalSceneFiles);
            Assert.True(limit.MaxEnemies >= 0);
        });
    }
}
