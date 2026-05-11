using System.Text;
using System.Numerics;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Modifiers;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app.Item;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

[Trait("Category", "RequiresPak")]
public class RandomizerKeyItemLocationBehaviorTests
{
    private static readonly IReadOnlyDictionary<string, ExpectedKeyItemRule> ExpectedRules =
        new Dictionary<string, ExpectedKeyItemRule>(StringComparer.OrdinalIgnoreCase)
        {
            ["Fuse"] = new(1, ExpectedScope.GuestHouseAfterAxeFight),
            ["HandAxe"] = new(1, ExpectedScope.GuestHouseBeforeAxeFight),
            ["FloorDoorKey"] = new(3, ExpectedScope.Chapter3Start),
            ["3CrestKeyB"] = new(3, ExpectedScope.BeforeDogDoor),
            ["3CrestKeyA"] = new(3, ExpectedScope.BeforeDogDoor),
            ["3CrestKeyC"] = new(3, ExpectedScope.BeforeDogDoor),
            ["Battery"] = new(3, ExpectedScope.BeforeBarnBatterySocket),
            ["EntranceHallKey"] = new(3, ExpectedScope.BeforeOxDoor),
            ["PendulumClock"] = new(3, ExpectedScope.AfterGarageBeforeShadowPuzzle),
            ["MorgueKey"] = new(3, ExpectedScope.Chapter3Start),
            ["WorkroomKey"] = new(3, ExpectedScope.BeforeDissectionRoom),
            ["MasterKey"] = new(3, ExpectedScope.BeforeSnakeRooms),
            ["TalismanKey"] = new(3, ExpectedScope.BeforeCrowDoor),
            ["Crank"] = new(3, ExpectedScope.BeforeCrowDoor),
            ["SilhouettePazzlePieceOldHouse"] = new(3, ExpectedScope.BeforeOldHouseShadowPuzzle),
            ["SerumMaterialA"] = new(3, ExpectedScope.BeforeBoatHouse),
            ["Lantern"] = new(3, ExpectedScope.OldHouseAfterCrowDoor),
            ["LucasCardKey"] = new(3, ExpectedScope.BeforeBarnBatterySocket),
            ["LucasCardKey2"] = new(3, ExpectedScope.BeforeBarnBatterySocket),
            ["SerumMaterialB"] = new(3, ExpectedScope.BeforeBoatHouse),
            ["SerumComplete"] = new(3, ExpectedScope.BoatHouse),
            ["Candle_Lighted"] = new(3, ExpectedScope.BeforeBarnBatterySocket),
            ["EthanCarKey"] = new(3, ExpectedScope.Chapter3Start),
            ["SilhouettePazzlePiece"] = new(3, ExpectedScope.BeforeShadowPuzzle),
            ["EvCable"] = new(4, ExpectedScope.MiaPresentShip),
            ["FuseCh4"] = new(4, ExpectedScope.MiaPresentShip),
            ["EvOpener"] = new(4, ExpectedScope.MiaPresentShip),
            ["SpareKey"] = new(4, ExpectedScope.MiaPresentShip),
            ["SerumTypeE"] = new(4, ExpectedScope.BeforeNecrotoxinUse),
        };
    private static readonly HashSet<string> ExpectedDefaultSkippedKeyItemIds = new(StringComparer.OrdinalIgnoreCase)
    {
        "Candle_Lighted",
        "HandAxe",
    };
    private static readonly IReadOnlyDictionary<string, ExpectedPickupFlag> ExpectedPickupFlags =
        new Dictionary<string, ExpectedPickupFlag>(StringComparer.OrdinalIgnoreCase)
        {
            ["Fuse"] = new("c01_Main_FuseGet", new("f7486e9b-8924-494c-9738-c26fa3c2e055"), true),
            ["FloorDoorKey"] = new("c03_1_Main_GetFloorDoorKey", new("024d7582-3a98-4587-9b4f-a4dc47cd2cb4"), true),
            ["3CrestKeyC"] = new("c03_2_Main_GetCrestInFreezerRoom", new("ed2860cf-2569-4045-96c8-ba01e0fcfed8"), true),
            ["WorkroomKey"] = new("c03_2_Main_OpenTrayInWorkshopKey", new("b3096800-d600-4015-b934-63d671b597a9"), true),
            ["MasterKey"] = new("c03_2_Main_GetSnakeKey", new("f4bf6a88-ccd2-4614-87aa-59d77cae3754"), true),
            ["Crank"] = new("c03_3_Main_GetCrank", new("e4ef4f89-4d98-4d81-86a0-8ea640eac4dc"), true),
            ["TalismanKey"] = new("c03_3_Main_TalismanKeyGet", new("6ed99e11-2047-4236-84a0-6457c7a3b1c9"), true),
            ["SilhouettePazzlePiece"] = new("c03_2_Main_GetPazzleObject", new("e165ff7a-0829-4edc-8c34-68a01a1ff3b2"), true),
            ["SilhouettePazzlePieceOldHouse"] = new("c03_3_Main_EnterMiaCapturedRoom", new("17e5af29-0cab-4e3c-a78d-71ee87798b6c"), true),
            ["SerumMaterialA"] = new("c03_3_Main_GetEvlineArm", new("e4b4b42e-ecfc-415e-a713-e1a3604af371"), true),
            ["Lantern"] = new("c03_3_Main_GetLantern", new("acb7e0bd-e123-4a57-8a0b-1bf77087e856"), true),
            ["LucasCardKey"] = new("c03_4A_Main_LucasCardKeyGet_InLoft", new("b5532ea8-facb-428d-bf61-ea3e66d373dd"), true),
            ["LucasCardKey2"] = new("c03_4B_Main_LucasCardKeyGet_InWorkRoom", new("b9f9b409-c6b8-4142-9697-c70f24a7c15b"), true),
            ["SerumMaterialB"] = new("c03_objective_EvlineFace_Get", new("21411c8c-2b95-418e-8efa-8bf79bae4ae5"), true),
            ["Candle_Lighted"] = new("c03_4_Main_PazzleRoom_CandleOn", new("e8f18a82-943a-41dd-977b-f1d729499dee"), true),
            ["SerumComplete"] = new("c03_5_Main_GetKesseiEventEnd", new("2f3f5ec1-c595-4078-a686-118a5a8d1a8f"), true),
            ["EvCable"] = new("c04_objective_ElevatorCableGetInventory", new("8dc1c235-4ffc-4894-bd45-ae1cf2e5fba2"), true),
            ["FuseCh4"] = new("c04_objective_ElevatorFuseGetInventory", new("c7004b40-85bc-4d0a-a274-05d771d581ab"), true),
        };
    private const string MainHouseHallScenePath = "natives/stm/environment/scene/chapter3/c03_mainhousehall.scn.20";
    private static readonly Guid MainHouseHallExtraItemGuid = new("6f2662e3-3bdf-6e6f-46f0-4dd15ea89164");
    private static readonly Guid MainHouseHallDrawerCoinGuid = new("ccd5a2ee-49f5-485b-97a8-42cf8282da07");
    private static readonly Guid GuestHouseFuseCabinetGuid = new("b116eb16-c4c5-4d43-8901-044ec9dccbcf");
    private static readonly Guid GuestHouseMiaDriversLicenseGuid = new("ee3242fe-55a4-450c-b8ca-0a8ab3c39546");
    private const string GuestHouseMiaCellScenePath = "natives/stm/environment/scene/chapter1/c01_b1f.scn.20";
    private static readonly Guid[] MainHouseHallShotgunPuzzleGuids =
    [
        new("65a64069-d77d-0f46-31f9-f16439d0218e"),
        new("73fce2c5-6b93-047d-24be-ced1b2904df2"),
        new("a5594b78-dd67-47f9-b730-cc618d6d82c6"),
        new("46573881-af8d-045c-2145-946ddc5c01c9"),
    ];
    private const string ShipMaintenanceRoomScenePath = "natives/stm/environment/scene/chapter4/c04_ship1foffice.scn.20";
    private static readonly Guid ShipMaintenanceRoomDrawerHandgunGuid = new("23ffe0b9-43d3-4091-9588-bc45740c0b43");

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
        var expectedRandomizedIds = ExpectedRules.Keys
            .Where(id => !ExpectedDefaultSkippedKeyItemIds.Contains(id))
            .Order(StringComparer.OrdinalIgnoreCase)
            .ToList();

        Assert.True(
            expectedRandomizedIds.Count == randomizedKeyItems.Count,
            $"Expected {expectedRandomizedIds.Count}, actual {randomizedKeyItems.Count}: {string.Join(", ", randomizedKeyItems.Select(change => change.AfterId).Order(StringComparer.OrdinalIgnoreCase))}\n{result.ProcessLog}");
        Assert.Equal(
            expectedRandomizedIds,
            randomizedKeyItems.Select(change => change.AfterId).Order(StringComparer.OrdinalIgnoreCase));
        foreach (var skippedId in ExpectedDefaultSkippedKeyItemIds)
        {
            Assert.Contains($"Skipped key item {ItemDefinitionRepository.Default.GetName(skippedId)}:", result.ProcessLog);
        }

        foreach (var change in randomizedKeyItems)
        {
            var rule = ExpectedRules[change.AfterId];
            Assert.Equal(rule.Chapter, change.Placement.Chapter);
            Assert.True(ScopeMatches(rule.Scope, change.Placement), $"{change.AfterId} was placed in unexpected scene {change.Placement.SceneFile}.");
        }

        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "3CrestKeyB" && change.Placement.Chapter == 4);
        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "MorgueKey" && !IsMainHouseBeforeGarage(change.Placement.SceneFile));
        Assert.DoesNotContain(randomizedKeyItems, change => change.AfterId == "SerumTypeE" && change.Placement.SceneFile.Contains("/chapter4/lastbattle", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void KeyItemLocations_ReplacesOriginalSupportedKeyItemPickupsWithFillers()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-key-item-locations"] = true;
        });

        var randomizedIds = GetChangedPlacements(result)
            .Where(change => ExpectedRules.ContainsKey(change.AfterId))
            .Select(change => change.AfterId)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var placement in result.ItemPlacementService.MainGamePlacements
            .Where(placement =>
                !string.IsNullOrWhiteSpace(placement.Id) &&
                randomizedIds.Contains(placement.Id) &&
                placement.Enabled &&
                !placement.IsExtra)
            .DistinctBy(placement => (placement.SceneFile, placement.Guid)))
        {
            var afterItem = GetItem(result.ReadAfterScene(placement.SceneFile), placement.Guid);
            Assert.NotEqual(placement.Id, afterItem.ItemDataID);
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

        foreach (var change in randomizedKeyItems)
        {
            var beforeScene = result.ReadBeforeScene(change.Placement.SceneFile);
            var afterScene = result.ReadAfterScene(change.Placement.SceneFile);
            var targetGuid = GetTargetGuid(change.Placement);
            var beforeGameObject = change.Placement.IsExtra ? null : beforeScene.FindGameObject(targetGuid);
            var gameObject = afterScene.FindGameObject(targetGuid);
            Assert.NotNull(gameObject);

            if (!change.Placement.IsExtra)
            {
                Assert.NotNull(beforeGameObject);
                Assert.False(
                    HasDrawerContext(beforeScene, targetGuid),
                    $"{change.AfterId} was placed in a drawer-backed pickup: {change.Placement.SceneFile} / {targetGuid}.");

                if (ShouldPreserveOriginalPickupCarrier(change.Placement, beforeScene, targetGuid))
                {
                    AssertOriginalPickupShapePreserved(beforeGameObject!, gameObject!, change.AfterId);
                    AssertVisualResourcesMatch(result.Randomizer.TemplateService.GetItemTemplate(change.AfterId), gameObject!);
                    continue;
                }
            }

            AssertPickupInteractionsAreReadyForFreshPlacement(gameObject!, change.AfterId);
        }
    }

    [Fact]
    public void KeyItemLocations_RandomizedPickupsSetRequiredAcquisitionFlags()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-key-item-locations"] = true;
        });

        var randomizedKeyItems = GetChangedPlacements(result)
            .Where(change => ExpectedPickupFlags.ContainsKey(change.AfterId))
            .ToDictionary(change => change.AfterId, StringComparer.OrdinalIgnoreCase);

        foreach (var (itemId, expectedFlag) in ExpectedPickupFlags.Where(entry => !ExpectedDefaultSkippedKeyItemIds.Contains(entry.Key)))
        {
            Assert.True(randomizedKeyItems.TryGetValue(itemId, out var change), $"{itemId} was not randomized.");
            var gameObject = result.ReadAfterScene(change!.Placement.SceneFile)
                .FindGameObject(GetTargetGuid(change.Placement));
            Assert.NotNull(gameObject);
            AssertPickupSetsBoolFlag(
                gameObject!,
                itemId,
                expectedFlag.Name,
                expectedFlag.Guid,
                expectedFlag.Value);
        }
    }

    [Fact]
    public void KeyItemLocations_PreservesVanillaBoltCutters()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-key-item-locations"] = true;
        });

        var changes = GetChangedPlacements(result).ToList();

        Assert.DoesNotContain(changes, change => change.BeforeId == "ChainCutter" || change.AfterId == "ChainCutter");
        Assert.Contains("Skipped key item Bolt Cutters", result.ProcessLog);
    }

    [Fact]
    public void KeyItemLocations_DetectsFsmControlledPickupPlacements()
    {
        using var result = RandomizerTest.RunState();
        var scene = result.ReadBeforeScene(MainHouseHallScenePath);

        Assert.True(HasFsmInHierarchy(scene, MainHouseHallDrawerCoinGuid));
        Assert.True(HasDrawerContext(scene, MainHouseHallDrawerCoinGuid));
    }

    [Fact]
    public void KeyItemLocations_DetectsInteractDrawerReferencedPickupPlacements()
    {
        using var result = RandomizerTest.RunState();
        var scene = result.ReadBeforeScene(ShipMaintenanceRoomScenePath);

        Assert.True(HasFsmInHierarchy(scene, ShipMaintenanceRoomDrawerHandgunGuid));
        Assert.True(HasDrawerContext(scene, ShipMaintenanceRoomDrawerHandgunGuid));
    }

    [Fact]
    public void KeyItemLocations_DoesNotPlaceKeyItemsInShipMaintenanceRoomDrawerPickup()
    {
        using var result = RandomizerTest.RunState(
            config =>
            {
                config["random-key-item-locations"] = true;
                config["replace-weapons"] = true;
                config["additional-items"] = true;
            },
            seed: 999477);

        var drawerItem = GetItem(result.ReadAfterScene(ShipMaintenanceRoomScenePath), ShipMaintenanceRoomDrawerHandgunGuid);
        Assert.DoesNotContain(drawerItem.ItemDataID, ExpectedRules.Keys);
    }

    [Fact]
    public void KeyItemLocations_DoesNotPlaceKeyItemsInMainHallShotgunPuzzlePickups()
    {
        using var result = RandomizerTest.RunState(
            config =>
            {
                config["random-key-item-locations"] = true;
                config["replace-weapons"] = true;
                config["additional-items"] = true;
            },
            seed: 999477);

        var scene = result.ReadAfterScene(MainHouseHallScenePath);
        foreach (var guid in MainHouseHallShotgunPuzzleGuids)
        {
            var item = GetItem(scene, guid);
            Assert.DoesNotContain(item.ItemDataID, ExpectedRules.Keys);
        }
    }

    [Fact]
    public void KeyItemLocations_DoesNotTreatFuseCabinetAsPreBoltCuttersCandidate()
    {
        using var result = RandomizerTest.RunState();
        var fuseCabinet = result.ItemPlacementService.MainGamePlacements.Single(placement =>
            placement.Guid == GuestHouseFuseCabinetGuid &&
            placement.SceneFile.Equals("natives/stm/environment/scene/chapter1/c01_corridor01.scn.20", StringComparison.OrdinalIgnoreCase));

        Assert.False(KeyItemLocationModifier.CanPlaceKeyItemInPlacementForTesting(fuseCabinet, "ChainCutter"));
        Assert.False(KeyItemLocationModifier.CanPlaceKeyItemInPlacementForTesting(fuseCabinet, "HandAxe"));
    }

    [Fact]
    public void KeyItemLocations_DoesNotUseMissableGuestHouseOutsidePlacements()
    {
        using var result = RandomizerTest.RunState();
        var driversLicense = result.ItemPlacementService.MainGamePlacements.Single(placement =>
            placement.Guid == GuestHouseMiaDriversLicenseGuid &&
            placement.SceneFile.Equals("natives/stm/environment/scene/chapter1/c01_outside11.scn.20", StringComparison.OrdinalIgnoreCase));

        Assert.False(KeyItemLocationModifier.CanPlaceKeyItemInPlacementForTesting(driversLicense, "ChainCutter"));
        Assert.False(KeyItemLocationModifier.CanPlaceKeyItemInPlacementForTesting(driversLicense, "HandAxe"));
    }

    [Fact]
    public void KeyItemLocations_DoesNotTreatMiaCellAsPreBoltCuttersCandidate()
    {
        using var result = RandomizerTest.RunState();
        var miaCell = result.ItemPlacementService.MainGamePlacements.Single(placement =>
            placement.IsExtra &&
            placement.Comment == "Mia's Cell" &&
            placement.SceneFile.Equals(GuestHouseMiaCellScenePath, StringComparison.OrdinalIgnoreCase));

        Assert.False(KeyItemLocationModifier.CanPlaceKeyItemInPlacementForTesting(miaCell, "ChainCutter"));
        Assert.False(KeyItemLocationModifier.CanPlaceKeyItemInPlacementForTesting(miaCell, "HandAxe"));
    }

    [Fact]
    public void KeyItemLocations_OnlyUsesPlainRandomItemsAsNonKeyTargets()
    {
        var definitions = ItemDefinitionRepository.Default;

        foreach (var id in new[] { "BrokenShotgun_DB", "Shotgun_DB", "Shotgun_M37", "ToyShotgun", "PendulumClock", "Coin", "TreasureMap01" })
        {
            var definition = definitions.FromId(id);
            Assert.NotNull(definition);
            Assert.False(KeyItemLocationModifier.IsPlainRandomItemTarget(definition), $"{id} should not be a key-item randomization target.");
        }

        foreach (var id in new[] { "HandgunBullet", "ShotgunBullet", "ChemicalL", "ChemicalS", "SyntheticDetergent", "Herb" })
        {
            var definition = definitions.FromId(id);
            Assert.NotNull(definition);
            Assert.True(KeyItemLocationModifier.IsPlainRandomItemTarget(definition), $"{id} should be a plain key-item randomization target.");
            Assert.Contains(definition.CategoryType, new[] { ItemCategoryType.Shell, ItemCategoryType.Drug, ItemCategoryType.Material });
        }
    }

    [Fact]
    public void KeyItemLocations_DoesNotPlaceKeyItemsInDrawerPickups()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-key-item-locations"] = true;
        });

        var randomizedKeyItems = GetChangedPlacements(result)
            .Where(change => ExpectedRules.ContainsKey(change.AfterId))
            .ToList();

        foreach (var change in randomizedKeyItems)
        {
            var beforeScene = result.ReadBeforeScene(change.Placement.SceneFile);
            if (!change.Placement.IsExtra)
            {
                var targetGuid = GetTargetGuid(change.Placement);
                Assert.False(
                    HasDrawerContext(beforeScene, targetGuid),
                    $"{change.AfterId} was placed in a drawer-backed pickup: {change.Placement.SceneFile} / {targetGuid}.");
            }
        }

        var drawerItem = GetItem(result.ReadAfterScene(MainHouseHallScenePath), MainHouseHallDrawerCoinGuid);
        Assert.DoesNotContain(drawerItem.ItemDataID, ExpectedRules.Keys);
    }

    [Fact]
    public void KeyItemLocations_CanUsePlainExtraItemPlacementsWhenAdditionalItemsAreEnabled()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["additional-items"] = true;
            config["random-key-item-locations"] = true;
        });

        var extraKeyItem = GetChangedPlacements(result)
            .FirstOrDefault(change => change.Placement.IsExtra && ExpectedRules.ContainsKey(change.AfterId));

        Assert.NotNull(extraKeyItem);
        Assert.True(ExtraPlacementModifier.IsPlainExtraItemPlacement(extraKeyItem!.Placement));
        var gameObject = result.ReadAfterScene(extraKeyItem.Placement.SceneFile).FindGameObject(GetTargetGuid(extraKeyItem.Placement));
        Assert.NotNull(gameObject);
        Assert.True(gameObject!.Settings.Get<bool>("Update"));
        Assert.True(gameObject.Settings.Get<bool>("Draw"));
    }

    [Fact]
    public void KeyItemLocations_PreservesExtraPickupCarrierInteractionsWhenAdditionalItemsAreEnabled()
    {
        using var extraOnly = RandomizerTest.RunState(config =>
        {
            config["additional-items"] = true;
        });
        using var keyItems = RandomizerTest.RunState(config =>
        {
            config["additional-items"] = true;
            config["random-key-item-locations"] = true;
        });

        var extraKeyItem = GetChangedPlacements(keyItems)
            .FirstOrDefault(change => change.Placement.IsExtra && ExpectedRules.ContainsKey(change.AfterId));

        Assert.NotNull(extraKeyItem);
        var targetGuid = GetTargetGuid(extraKeyItem!.Placement);
        var carrier = extraOnly.ReadAfterScene(extraKeyItem.Placement.SceneFile).FindGameObject(targetGuid);
        var replacement = keyItems.ReadAfterScene(extraKeyItem.Placement.SceneFile).FindGameObject(targetGuid);

        Assert.NotNull(carrier);
        Assert.NotNull(replacement);
        AssertOriginalPickupShapePreserved(carrier!, replacement!, extraKeyItem.AfterId);
        AssertVisualResourcesMatch(keyItems.Randomizer.TemplateService.GetItemTemplate(extraKeyItem.AfterId), replacement!);
    }

    [Fact]
    public void KeyItemLocations_CanMaterializePlainExtraItemPlacementsWhenAdditionalItemsAreDisabled()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["additional-items"] = false;
            config["random-key-item-locations"] = true;
        });

        var extraKeyItem = GetChangedPlacements(result)
            .FirstOrDefault(change => change.Placement.IsExtra && ExpectedRules.ContainsKey(change.AfterId));

        Assert.NotNull(extraKeyItem);
        Assert.True(ExtraPlacementModifier.IsPlainExtraItemPlacement(extraKeyItem!.Placement));
        var gameObject = result.ReadAfterScene(extraKeyItem.Placement.SceneFile).FindGameObject(GetTargetGuid(extraKeyItem.Placement));
        Assert.NotNull(gameObject);
        Assert.True(gameObject!.Settings.Get<bool>("Update"));
        Assert.True(gameObject.Settings.Get<bool>("Draw"));
    }

    [Fact]
    public void KeyItemLocations_MainHallExtraPlacementUsesValidIdentityRotation()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["additional-items"] = true;
        });

        var placement = result.ItemPlacementService.ItemPlacements.Single(placement =>
            placement.IsExtra &&
            placement.Comment == "Main Hall" &&
            placement.SceneFile.Equals(MainHouseHallScenePath, StringComparison.OrdinalIgnoreCase));
        Assert.Equal(MainHouseHallExtraItemGuid, ExtraPlacementModifier.GetGeneratedItemGuid(placement));
        AssertQuaternionEquals(Quaternion.Identity, placement.Rotation);

        var scene = result.ReadAfterScene(MainHouseHallScenePath);
        var gameObject = scene.FindGameObject(MainHouseHallExtraItemGuid);
        Assert.NotNull(gameObject);
        var transform = gameObject!.FindComponent<GeneratedViaTransform>();
        Assert.NotNull(transform);
        AssertQuaternionEquals(Quaternion.Identity, transform!.Rotation);
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
            .Where(placement =>
                placement.Enabled &&
                (!placement.IsExtra || ExtraPlacementModifier.IsPlainExtraItemPlacement(placement)))
            .DistinctBy(placement => (placement.SceneFile, GetTargetGuid(placement))))
        {
            if (!result.WasFileModified(placement.SceneFile))
                continue;

            var targetGuid = GetTargetGuid(placement);
            var beforeItem = placement.IsExtra ? null : GetItemOrNull(result.ReadBeforeScene(placement.SceneFile), targetGuid);
            var afterItem = GetItemOrNull(result.ReadAfterScene(placement.SceneFile), targetGuid);
            if (afterItem == null || beforeItem?.ItemDataID == afterItem.ItemDataID)
                continue;

            yield return new ChangedItemPlacement(placement, beforeItem?.ItemDataID ?? placement.Id, afterItem.ItemDataID);
        }
    }

    private static Guid GetTargetGuid(ItemPlacement placement)
        => placement.IsExtra && ExtraPlacementModifier.IsPlainExtraItemPlacement(placement)
            ? ExtraPlacementModifier.GetGeneratedItemGuid(placement)
            : placement.Guid;

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

    private static void AssertPickupSetsBoolFlag(
        RszGameObject gameObject,
        string itemId,
        string flagName,
        Guid flagGuid,
        bool value)
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
        Assert.All(interactions, interact =>
        {
            Assert.Equal(flagName, interact.SetFsmBoolFlag);
            Assert.Equal(flagGuid, interact.SetFsmBoolFlagId);
            Assert.Equal(value, interact.SetFsmBoolFlagValue);
        });
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

    private static bool HasDrawerContext(RszScene scene, Guid guid)
        => scene.FindGameObjectsByGuidWithFsmContext([guid]).TryGetValue(guid, out var match) &&
            match.HasDrawerContext;

    private static bool ShouldPreserveOriginalPickupCarrier(ItemPlacement placement, RszScene beforeScene, Guid targetGuid)
    {
        if (HasFsmInHierarchy(beforeScene, targetGuid))
            return true;

        if (string.IsNullOrWhiteSpace(placement.Id)
            || ExpectedRules.ContainsKey(placement.Id))
        {
            return false;
        }

        var definition = ItemDefinitionRepository.Default.FromId(placement.Id);
        return definition != null && KeyItemLocationModifier.IsPlainRandomItemTarget(definition);
    }

    private static void AssertQuaternionEquals(Quaternion expected, Quaternion actual)
    {
        const float tolerance = 0.0001f;
        Assert.True(Math.Abs(expected.X - actual.X) <= tolerance, $"Expected X={expected.X}, actual X={actual.X}.");
        Assert.True(Math.Abs(expected.Y - actual.Y) <= tolerance, $"Expected Y={expected.Y}, actual Y={actual.Y}.");
        Assert.True(Math.Abs(expected.Z - actual.Z) <= tolerance, $"Expected Z={expected.Z}, actual Z={actual.Z}.");
        Assert.True(Math.Abs(expected.W - actual.W) <= tolerance, $"Expected W={expected.W}, actual W={actual.W}.");
    }

    private static bool ScopeMatches(ExpectedScope scope, ItemPlacement placement)
        => scope switch
        {
            ExpectedScope.GuestHouseBeforeBoltCutters => IsGuestHouseBeforeBoltCutters(placement.SceneFile),
            ExpectedScope.GuestHouseBeforeAxeFight => IsGuestHouseBeforeBoltCutters(placement.SceneFile)
                || IsGuestHouseAfterBoltCutters(placement.SceneFile),
            ExpectedScope.GuestHouseAfterAxeFight => IsGuestHouseAfterAxeFight(placement.SceneFile),
            ExpectedScope.Chapter3Start => IsMainHouseBeforeGarage(placement.SceneFile),
            ExpectedScope.BeforeOxDoor => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsGarage(placement.SceneFile),
            ExpectedScope.AfterGarageBeforeShadowPuzzle => IsMainHouseBeforeShadowPuzzle(placement.SceneFile),
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
            ExpectedScope.BeforeDissectionRoom => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile),
            ExpectedScope.BeforeOldHouseShadowPuzzle => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile)
                || IsYardOrTrailer(placement.SceneFile)
                || IsOldHouseBeforeCrowDoor(placement.SceneFile),
            ExpectedScope.OldHouseAfterCrowDoor => IsOldHouseAfterCrowDoorOrGreenHouse(placement.SceneFile),
            ExpectedScope.BeforeBarnBatterySocket => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile)
                || IsYardOrTrailer(placement.SceneFile)
                || IsOldHouseBeforeCrowDoor(placement.SceneFile)
                || IsOldHouseAfterCrowDoorOrGreenHouse(placement.SceneFile)
                || IsMainHouseSnakeKeyRoom(placement.SceneFile)
                || IsTestingArea(placement.SceneFile)
                || IsTestingAreaBeforeBarnFight(placement.SceneFile),
            ExpectedScope.BeforeBoatHouse => IsMainHouseBeforeGarage(placement.SceneFile)
                || IsMainHouseBeforeShadowPuzzle(placement.SceneFile)
                || IsMainHouseEastOrBasement(placement.SceneFile)
                || IsYardOrTrailer(placement.SceneFile)
                || IsOldHouseBeforeCrowDoor(placement.SceneFile)
                || IsOldHouseAfterCrowDoorOrGreenHouse(placement.SceneFile)
                || IsMainHouseSnakeKeyRoom(placement.SceneFile)
                || IsTestingArea(placement.SceneFile)
                || IsTestingAreaBeforeBarnFight(placement.SceneFile),
            ExpectedScope.BoatHouse => IsBoatHouseRoute(placement.SceneFile),
            ExpectedScope.MiaPresentShip => IsMiaPresentShipRoute(placement.SceneFile),
            ExpectedScope.BeforeNecrotoxinUse => IsSaltMineBeforeNecrotoxinUse(placement.SceneFile),
            _ => true,
        };

    private static bool PathContains(string path, string value)
        => path.Contains(value, StringComparison.OrdinalIgnoreCase);

    private static bool IsGuestHouseBeforeBoltCutters(string path)
        => !IsFlashbackPath(path)
            && (PathContains(path, "c01_kitchen")
                || PathContains(path, "c01_living")
                || PathContains(path, "c01_corridor01")
                || PathContains(path, "c01_corridor02")
                || PathContains(path, "c01_b1a")
                || PathContains(path, "c01_b1b")
                || PathContains(path, "c01_b1c")
                || PathContains(path, "c01_b1d")
                || PathContains(path, "c01_b1e"));

    private static bool IsGuestHouseAfterBoltCutters(string path)
        => !IsFlashbackPath(path)
            && (PathContains(path, "c01_b1g")
                || PathContains(path, "c01_b1h")
                || PathContains(path, "c01_b1i")
                || PathContains(path, "c01_b1j")
                || PathContains(path, "c01_corridor03")
                || PathContains(path, "c01_storeroom"));

    private static bool IsGuestHouseAfterAxeFight(string path)
        => !IsFlashbackPath(path)
            && (PathContains(path, "c01_bathroom")
                || PathContains(path, "c01_2f")
                || PathContains(path, "c01_3f")
                || PathContains(path, "/leveldesign/itemset/chapter1/"));

    private static bool IsFlashbackPath(string path)
        => PathContains(path, "/environment/scene/ff")
            || PathContains(path, "/leveldesign/itemset/ff");

    private static bool IsMainHouseBeforeGarage(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/mainhouse_west/")
            || PathContains(path, "c03_mainhouse1fgaragehallway")
            || PathContains(path, "c03_mainhouse1fhallway")
            || PathContains(path, "c03_mainhouse1fldk")
            || PathContains(path, "c03_mainhouse1fliving")
            || PathContains(path, "c03_mainhouse1fpantry")
            || PathContains(path, "c03_mainhouse1fwash");

    private static bool IsGarage(string path)
        => PathContains(path, "c03_mainhouse1fgarage.scn");

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

    private static bool IsTestingArea(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/leftarea/")
            || PathContains(path, "c03_leftarea");

    private static bool IsBoatHouseRoute(string path)
        => PathContains(path, "/leveldesign/itemset/chapter3/boatshed/")
            || PathContains(path, "c03_boat")
            || PathContains(path, "c03_gardenareaboat");

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
        GuestHouseBeforeBoltCutters,
        GuestHouseBeforeAxeFight,
        GuestHouseAfterAxeFight,
        Chapter3Start,
        BeforeOxDoor,
        AfterGarageBeforeShadowPuzzle,
        BeforeShadowPuzzle,
        BeforeDogDoor,
        BeforeScorpionDoor,
        BeforeCrowDoor,
        BeforeSnakeRooms,
        BeforeDissectionRoom,
        BeforeOldHouseShadowPuzzle,
        OldHouseAfterCrowDoor,
        BeforeBarnBatterySocket,
        BeforeBoatHouse,
        BoatHouse,
        MiaPresentShip,
        BeforeNecrotoxinUse,
    }

    private sealed record ExpectedKeyItemRule(int Chapter, ExpectedScope Scope);

    private sealed record ExpectedPickupFlag(string Name, Guid Guid, bool Value);

    private sealed record ChangedItemPlacement(ItemPlacement Placement, string BeforeId, string AfterId);
}
