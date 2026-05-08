using System.Text;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerKeyItemLocationBehaviorTests
{
    private static readonly IReadOnlyDictionary<string, ExpectedKeyItemRule> ExpectedRules =
        new Dictionary<string, ExpectedKeyItemRule>(StringComparer.OrdinalIgnoreCase)
        {
            ["3CrestKeyB"] = new(3, ExpectedScope.Chapter3MainHouse),
            ["3CrestKeyA"] = new(3, ExpectedScope.Chapter3MainHouse),
            ["Battery"] = new(3, ExpectedScope.Chapter3PreLucas),
            ["MorgueKey"] = new(3, ExpectedScope.Chapter3PreLucas),
            ["MasterKey"] = new(3, ExpectedScope.Chapter3PreLucas),
            ["TalismanKey"] = new(3, ExpectedScope.Chapter3PreLucas),
            ["EthanCarKey"] = new(3, ExpectedScope.Chapter3MainHouse),
            ["SilhouettePazzlePiece"] = new(3, ExpectedScope.Chapter3MainHouse),
            ["EvCable"] = new(4, ExpectedScope.MiaPresentShip),
            ["FuseCh4"] = new(4, ExpectedScope.MiaPresentShip),
            ["EvOpener"] = new(4, ExpectedScope.MiaPresentShip),
            ["SpareKey"] = new(4, ExpectedScope.MiaPresentShip),
            ["SerumTypeE"] = new(4, ExpectedScope.EthanLateGame),
        };

    [Fact]
    public void KeyItemLocations_RandomizesSupportedKeyItemsIntoChapterScopedNormalPlacements()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-key-item-locations"] = true;
        });

        var randomizedKeyItems = GetChangedPlacements(result)
            .Where(change => ExpectedRules.ContainsKey(change.AfterId))
            .ToList();

        Assert.Equal(ExpectedRules.Count, randomizedKeyItems.Count);
        Assert.Equal(
            ExpectedRules.Keys.Order(StringComparer.OrdinalIgnoreCase),
            randomizedKeyItems.Select(change => change.AfterId).Order(StringComparer.OrdinalIgnoreCase));

        foreach (var change in randomizedKeyItems)
        {
            var rule = ExpectedRules[change.AfterId];
            Assert.Equal(rule.Chapter, change.Placement.Chapter);
            Assert.True(ScopeMatches(rule.Scope, change.Placement), $"{change.AfterId} was placed in unexpected scene {change.Placement.SceneFile}.");
        }

        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "3CrestKeyB" && change.Placement.Chapter == 4);
        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "SerumTypeE" && change.Placement.SceneFile.Contains("/chapter4/lastbattle", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void KeyItemLocations_ReplacesOriginalSupportedKeyItemPickupsWithFillers()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-key-item-locations"] = true;
        });

        foreach (var placement in result.ItemPlacementService.MainGamePlacements
            .Where(placement =>
                !string.IsNullOrWhiteSpace(placement.Id) &&
                ExpectedRules.ContainsKey(placement.Id) &&
                placement.Enabled &&
                !placement.IsExtra)
            .DistinctBy(placement => (placement.SceneFile, placement.Guid)))
        {
            var afterItem = GetItem(result.ReadAfterScene(placement.SceneFile), placement.Guid);
            Assert.NotEqual(placement.Id, afterItem.ItemDataID);
            Assert.DoesNotContain(afterItem.ItemDataID, ExpectedRules.Keys);
        }
    }

    [Fact]
    public void KeyItemLocations_DoesNotReadLegacyKeyItemsCsv()
    {
        using var result = RandomizerTest.RunState(
            config =>
            {
                config["random-key-item-locations"] = true;
            },
            prepareRandomizer: randomizer =>
            {
                randomizer.DynamicData.SetData(
                    DynamicDataName.KeyItems,
                    Encoding.UTF8.GetBytes("this,is,not,the,legacy,schema\r\n"));
            });

        Assert.Contains("[KEY ITEM]", result.ProcessLog);
    }

    private static IEnumerable<ChangedItemPlacement> GetChangedPlacements(RandomizerRunResult result)
    {
        foreach (var placement in result.ItemPlacementService.MainGamePlacements
            .Where(placement => placement.Enabled && !placement.IsExtra)
            .DistinctBy(placement => (placement.SceneFile, placement.Guid)))
        {
            if (!result.WasFileModified(placement.SceneFile))
                continue;

            var beforeItem = GetItemOrNull(result.ReadBeforeScene(placement.SceneFile), placement.Guid);
            var afterItem = GetItemOrNull(result.ReadAfterScene(placement.SceneFile), placement.Guid);
            if (beforeItem == null || afterItem == null || beforeItem.ItemDataID == afterItem.ItemDataID)
                continue;

            yield return new ChangedItemPlacement(placement, beforeItem.ItemDataID, afterItem.ItemDataID);
        }
    }

    private static app.Item GetItem(RszScene scene, Guid guid)
    {
        var item = GetItemOrNull(scene, guid);
        Assert.NotNull(item);
        return item!;
    }

    private static app.Item? GetItemOrNull(RszScene scene, Guid guid)
        => scene.FindGameObject(guid)?.FindComponent<app.Item>();

    private static bool ScopeMatches(ExpectedScope scope, ItemPlacement placement)
        => scope switch
        {
            ExpectedScope.Chapter3MainHouse => IsChapter3MainHouseScene(placement.SceneFile),
            ExpectedScope.Chapter3PreLucas => IsChapter3PreLucasScene(placement.SceneFile),
            ExpectedScope.MiaPresentShip => IsMiaPresentShipScene(placement.SceneFile),
            ExpectedScope.EthanLateGame => IsEthanLateGameScene(placement.SceneFile),
            _ => true,
        };

    private static bool IsMiaPresentShipScene(string sceneFile)
        => sceneFile.Contains("/chapter4/ship", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter4/c04_ship", StringComparison.OrdinalIgnoreCase);

    private static bool IsChapter3MainHouseScene(string sceneFile)
        => sceneFile.Contains("/chapter3/mainhouse", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter3/c03_mainhouse", StringComparison.OrdinalIgnoreCase);

    private static bool IsChapter3PreLucasScene(string sceneFile)
        => IsChapter3MainHouseScene(sceneFile)
            || sceneFile.Contains("/scene/chapter3/c03_rightarea", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter3/c03_soft_1", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter3/c03_oldhouse", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter3/c03_gh", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/chapter3/oldhouse", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/chapter3/gardenarea", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter3/c03_gardenarea", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter3/c03_trailerhouse", StringComparison.OrdinalIgnoreCase);

    private static bool IsEthanLateGameScene(string sceneFile)
        => sceneFile.Contains("/chapter4/saltdome", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter4/c04_cottage", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/scene/chapter4/c04_mainhouse", StringComparison.OrdinalIgnoreCase)
            || sceneFile.Contains("/animation/ingame/c04/", StringComparison.OrdinalIgnoreCase);

    private enum ExpectedScope
    {
        Any,
        Chapter3MainHouse,
        Chapter3PreLucas,
        MiaPresentShip,
        EthanLateGame,
    }

    private sealed record ExpectedKeyItemRule(int Chapter, ExpectedScope Scope);

    private sealed record ChangedItemPlacement(ItemPlacement Placement, string BeforeId, string AfterId);
}
