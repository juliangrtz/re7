using System.Text;
using Biohazard.BioRand.RE7.Extensions;
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
            ["3CrestKeyB"] = new(3, ExpectedScope.BeforeDogDoor),
            ["3CrestKeyA"] = new(3, ExpectedScope.BeforeDogDoor),
            ["Battery"] = new(3, ExpectedScope.BeforeBarnBatterySocket),
            ["MorgueKey"] = new(3, ExpectedScope.Chapter3Start),
            ["MasterKey"] = new(3, ExpectedScope.BeforeSnakeRooms),
            ["TalismanKey"] = new(3, ExpectedScope.BeforeCrowDoor),
            ["EthanCarKey"] = new(3, ExpectedScope.BeforeGarage),
            ["SilhouettePazzlePiece"] = new(3, ExpectedScope.BeforeShadowPuzzle),
            ["EvCable"] = new(4, ExpectedScope.MiaPresentShip),
            ["FuseCh4"] = new(4, ExpectedScope.MiaPresentShip),
            ["EvOpener"] = new(4, ExpectedScope.MiaPresentShip),
            ["SpareKey"] = new(4, ExpectedScope.MiaPresentShip),
            ["SerumTypeE"] = new(4, ExpectedScope.BeforeNecrotoxinUse),
        };
    private const string MainHouseHallScenePath = "natives/stm/environment/scene/chapter3/c03_mainhousehall.scn.20";
    private static readonly Guid MainHouseHallDrawerCoinGuid = new("ccd5a2ee-49f5-485b-97a8-42cf8282da07");

    [Fact]
    public void KeyItemLocations_RandomizesSupportedKeyItemsIntoRouteSafeNormalPlacements()
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
        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "EthanCarKey" && !IsMainHouseBeforeGarage(change.Placement.SceneFile));
        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "MorgueKey" && !IsMainHouseBeforeGarage(change.Placement.SceneFile));
        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "SilhouettePazzlePiece" && IsYardOrTrailer(change.Placement.SceneFile));
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
    public void KeyItemLocations_RandomizedKeyItemPickupsUseFreshInteractions()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-key-item-locations"] = true;
        });

        var randomizedKeyItems = GetChangedPlacements(result)
            .Where(change => ExpectedRules.ContainsKey(change.AfterId))
            .ToList();

        Assert.NotEmpty(randomizedKeyItems);
        Assert.Contains(randomizedKeyItems, change => change.AfterId == "3CrestKeyA");

        foreach (var change in randomizedKeyItems)
        {
            var beforeScene = result.ReadBeforeScene(change.Placement.SceneFile);
            var afterScene = result.ReadAfterScene(change.Placement.SceneFile);
            var beforeGameObject = beforeScene.FindGameObject(change.Placement.Guid);
            var gameObject = afterScene.FindGameObject(change.Placement.Guid);
            Assert.NotNull(gameObject);
            Assert.NotNull(beforeGameObject);

            if (HasFsmInHierarchy(beforeScene, change.Placement.Guid))
            {
                AssertOriginalPickupShapePreserved(beforeGameObject!, gameObject!, change.AfterId);
                AssertVisualResourcesMatch(result.Randomizer.TemplateService.GetItemTemplate(change.AfterId), gameObject!);
                continue;
            }

            AssertPickupInteractionsAreReadyForFreshPlacement(gameObject!, change.AfterId);
        }
    }

    [Fact]
    public void KeyItemLocations_DetectsFsmControlledPickupPlacements()
    {
        using var result = RandomizerTest.RunState();
        var scene = result.ReadBeforeScene(MainHouseHallScenePath);

        Assert.True(HasFsmInHierarchy(scene, MainHouseHallDrawerCoinGuid));
    }

    [Fact]
    public void KeyItemLocations_FsmControlledCoinPickup_CanUseBlueDogHeadVisuals()
    {
        using var result = RandomizerTest.RunState();
        var scene = result.ReadBeforeScene(MainHouseHallScenePath);
        var coinGameObject = scene.FindGameObject(MainHouseHallDrawerCoinGuid);
        var blueDogHeadTemplate = result.Randomizer.TemplateService.GetItemTemplate("3CrestKeyA");

        Assert.NotNull(coinGameObject);
        var updated = coinGameObject!.ApplyVisualResourcesFromTemplate(blueDogHeadTemplate);

        AssertVisualResourcesMatch(blueDogHeadTemplate, updated);
        Assert.NotEqual(GetVisualResource(coinGameObject, "Mesh"), GetVisualResource(updated, "Mesh"));
        Assert.Equal(
            coinGameObject.Components.Select(component => component.Type.Name),
            updated.Components.Select(component => component.Type.Name));
        Assert.Equal(
            coinGameObject.Children.Select(child => child.Name),
            updated.Children.Select(child => child.Name));
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

    private static void AssertPickupInteractionsAreReadyForFreshPlacement(RszGameObject gameObject, string itemId)
    {
        var interactions = new List<app.InteractDetailSearch>();
        gameObject.VisitGameObjects(child =>
        {
            var interact = child.FindComponent<app.InteractDetailSearch>();
            if (interact != null)
            {
                interactions.Add(interact);
            }
        });

        Assert.True(interactions.Count > 0, $"{itemId} replacement has no InteractDetailSearch pickup interaction.");
        Assert.All(interactions, interact => Assert.False(interact.IsCheckAngle));
        Assert.All(interactions, interact => Assert.False(interact.IsItemGet));
    }

    private static void AssertOriginalPickupShapePreserved(RszGameObject before, RszGameObject after, string itemId)
    {
        Assert.Equal(itemId, after.FindComponent<app.Item>()!.ItemDataID);
        Assert.Equal(before.Name, after.Name);
        Assert.Equal(
            before.Components.Select(component => component.Type.Name),
            after.Components.Select(component => component.Type.Name));
        Assert.Equal(
            before.Children.Select(child => child.Name),
            after.Children.Select(child => child.Name));
    }

    private static void AssertVisualResourcesMatch(RszGameObject expected, RszGameObject actual)
    {
        Assert.Equal(GetVisualResource(expected, "Mesh"), GetVisualResource(actual, "Mesh"));
        Assert.Equal(GetVisualResource(expected, "Material"), GetVisualResource(actual, "Material"));
    }

    private static string GetVisualResource(RszGameObject gameObject, string fieldName)
    {
        var mesh = gameObject.FindComponent("via.render.Mesh");
        Assert.NotNull(mesh);
        return mesh![fieldName].ToString() ?? "";
    }

    private static bool HasFsmInHierarchy(RszScene scene, Guid guid)
        => scene.FindGameObjectsByGuidWithFsmContext([guid]).TryGetValue(guid, out var match) &&
            match.HasFsmInHierarchy;

    private static bool ScopeMatches(ExpectedScope scope, ItemPlacement placement)
        => scope switch
        {
            ExpectedScope.BeforeGarage => IsMainHouseBeforeGarage(placement.SceneFile),
            ExpectedScope.Chapter3Start => IsMainHouseBeforeGarage(placement.SceneFile),
            ExpectedScope.BeforeShadowPuzzle => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile),
            ExpectedScope.BeforeDogDoor => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile),
            ExpectedScope.BeforeScorpionDoor => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile)
                || IsYardOrTrailer(placement.SceneFile),
            ExpectedScope.BeforeCrowDoor => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile)
                || IsYardOrTrailer(placement.SceneFile)
                || IsOldHouseBeforeCrowDoor(placement.SceneFile),
            ExpectedScope.BeforeSnakeRooms => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile)
                || IsYardOrTrailer(placement.SceneFile)
                || IsOldHouseBeforeCrowDoor(placement.SceneFile)
                || IsOldHouseAfterCrowDoorOrGreenHouse(placement.SceneFile),
            ExpectedScope.BeforeBarnBatterySocket => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile)
                || IsYardOrTrailer(placement.SceneFile)
                || IsOldHouseBeforeCrowDoor(placement.SceneFile)
                || IsOldHouseAfterCrowDoorOrGreenHouse(placement.SceneFile)
                || IsMainHouseSnakeKeyRoom(placement.SceneFile)
                || IsTestingAreaBeforeBarnFight(placement.SceneFile),
            ExpectedScope.MiaPresentShip => IsMiaPresentShipRoute(placement.SceneFile),
            ExpectedScope.BeforeNecrotoxinUse => IsSaltMineBeforeNecrotoxinUse(placement.SceneFile),
            _ => true,
        };

    private static bool PathContains(string path, string value)
        => path.Contains(value, StringComparison.OrdinalIgnoreCase);

    private static bool IsMainHouseBeforeGarage(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/mainhouse_west/")
            || PathContains(path, "c03_mainhouse1fgaragehallway")
            || PathContains(path, "c03_mainhouse1fhallway")
            || PathContains(path, "c03_mainhouse1fldk")
            || PathContains(path, "c03_mainhouse1fliving")
            || PathContains(path, "c03_mainhouse1fpantry")
            || PathContains(path, "c03_mainhouse1fwash");

    private static bool IsMainHouseBeforeShadowPuzzle(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/mainhouse_hall/")
            || PathContains(path, "c03_mainhouse2fbath")
            || PathContains(path, "c03_mainhouse2fgrandma")
            || PathContains(path, "c03_mainhouse2fhallway")
            || PathContains(path, "c03_mainhouse2fplay")
            || PathContains(path, "c03_mainhouse2fstoreroom")
            || PathContains(path, "c03_mainhousehall")
            || PathContains(path, "c03_mainhousestair01");

    private static bool IsMainHouseEastOrBasement(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/mainhouse_east/")
            || PathContains(path, "c03_rightarea");

    private static bool IsMainHouseSnakeKeyRoom(string path)
        => PathContains(path, "c03_mainhouse2fbedroom")
            || PathContains(path, "c03_mainhouse2fkids")
            || PathContains(path, "c03_mainhousoutsideterrace2f3");

    private static bool IsYardOrTrailer(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/gardenarea/")
            || PathContains(path, "c03_gardenarea")
            || PathContains(path, "c03_trailerhouse")
            || PathContains(path, "c03_mainhousoutside")
            || PathContains(path, "c03_mainhousoutsideterrace");

    private static bool IsOldHouseBeforeCrowDoor(string path)
        => PathContains(path, "c03_oldhouse1fbridge")
            || PathContains(path, "c03_oldhouse1fentrance")
            || PathContains(path, "c03_oldhouse1fhallway")
            || PathContains(path, "c03_oldhouse1fhole")
            || PathContains(path, "c03_oldhouse1fhollway")
            || PathContains(path, "c03_oldhouse1fkitchen")
            || PathContains(path, "c03_oldhouse1fpuzzle")
            || PathContains(path, "c03_oldhouse1froom")
            || PathContains(path, "c03_oldhouse1fstorage")
            || PathContains(path, "c03_oldhouse1funderfloor")
            || PathContains(path, "c03_oldhouse1fwallinside")
            || PathContains(path, "c03_oldhouseoutside")
            || PathContains(path, "c03_oldhousesaferoom");

    private static bool IsOldHouseAfterCrowDoorOrGreenHouse(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/oldhouse/")
            || PathContains(path, "/leveldesign/itemset/chapter3/greenhouse/")
            || PathContains(path, "c03_oldhouse1fstairs")
            || PathContains(path, "c03_oldhouse2f")
            || PathContains(path, "c03_oldhousecave")
            || PathContains(path, "c03_gh");

    private static bool IsTestingAreaBeforeBarnFight(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/cowshed/")
            || PathContains(path, "c03_cowshed");

    private static bool IsMiaPresentShipRoute(string path)
        => !PathContains(path, "past")
            && (PathContains(path, "/environment/scene/chapter4/c04_ship")
                || PathContains(path, "/leveldesign/itemset/chapter4/ship")
                || PathContains(path, "/scenes/chapter/chapter4/c04_shipelevator"));

    private static bool IsSaltMineBeforeNecrotoxinUse(string path)
        => !PathContains(path, "/chapter4/lastbattle/")
            && (PathContains(path, "/environment/scene/chapter4/c04_cottage")
                || PathContains(path, "/environment/scene/chapter4/c04_cave")
                || PathContains(path, "/leveldesign/itemset/chapter4/saltdome"));

    private enum ExpectedScope
    {
        Any,
        BeforeGarage,
        Chapter3Start,
        BeforeShadowPuzzle,
        BeforeDogDoor,
        BeforeScorpionDoor,
        BeforeCrowDoor,
        BeforeSnakeRooms,
        BeforeBarnBatterySocket,
        MiaPresentShip,
        BeforeNecrotoxinUse,
    }

    private sealed record ExpectedKeyItemRule(int Chapter, ExpectedScope Scope);

    private sealed record ChangedItemPlacement(ItemPlacement Placement, string BeforeId, string AfterId);
}
