using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Modifiers;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Services;
using Enums.app.Item;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

public class RandomizerItemRandomizationTests
{
    private const string ForcedDropId = "Herb";
    private const string BirdCageScenePath = "environment/scene/chapter3/c03_trailerhouse.scn";

    [Fact]
    public void ItemRandomizer_DefaultFilters_RejectStoryUnlockableAndDlcItems()
    {
        using var result = RandomizerTest.RunState();
        var itemRandomizer = result.ItemRandomizer;
        var items = ItemDefinitionRepository.Default.Items;

        Assert.All(items.Where(x => x.IsStoryProgressionItem), item => Assert.False(itemRandomizer.IsItemAllowed(item)));
        Assert.All(items.Where(x => x.IsUnlockable), item => Assert.False(itemRandomizer.IsItemAllowed(item)));
        Assert.All(items.Where(x => x.IsDlcItem), item => Assert.False(itemRandomizer.IsItemAllowed(item)));
    }

    [Fact]
    public void ItemRandomizer_ConfigFlags_AllowUnlockableAndDlcItems()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["allow-bonus-items"] = true;
            config["allow-dlc-items"] = true;
        });

        var unlockable = ItemDefinitionRepository.Default.Items.First(x => x.IsUnlockable && !x.IsStoryProgressionItem);
        var dlcItem = ItemDefinitionRepository.Default.Items.First(x => x.IsDlcItem && !x.IsStoryProgressionItem);

        Assert.True(result.ItemRandomizer.IsItemAllowed(unlockable));
        Assert.True(result.ItemRandomizer.IsItemAllowed(dlcItem));
    }

    [Fact]
    public void ItemRandomizer_NoRecurrence_DoesNotRepeatDrawnItems()
    {
        using var result = RandomizerTest.RunState();
        var rng = result.Randomizer.GetRng("tests/no-recurrence");
        var itemRandomizer = result.ItemRandomizer;
        var poolSize = ItemDefinitionRepository.Default
            .GetAll(ItemCategoryType.Drug)
            .Count(itemRandomizer.IsItemAllowed);

        Assert.True(poolSize >= 3);

        var draws = Enumerable.Range(0, Math.Min(5, poolSize))
            .Select(_ => itemRandomizer.GetRandomItemDefinition(rng, ItemCategoryType.Drug, allowReoccurance: false))
            .ToArray();

        Assert.DoesNotContain(draws, item => item == null);
        Assert.Equal(draws.Length, draws.Select(x => x!.Id).Distinct(StringComparer.OrdinalIgnoreCase).Count());
    }

    [Fact]
    public void ItemPlacementService_FromSceneGuid_FiltersDuplicateGuidsToCurrentScene()
    {
        using var result = RandomizerTest.RunState();

        var duplicatedGuid = new Guid("3e6a9272-9495-44b5-963e-299206d95e16");
        var chapter3Scene = "natives/stm/environment/scene/chapter3/c03_mainhouse1fliving.scn.20";
        var chapter4Scene = "natives/stm/environment/scene/chapter4/c04_mainhouse1flivingjack.scn.20";

        var allPlacements = result.ItemPlacementService.FromGuid(duplicatedGuid)
            .Where(x => x.Dlc == null)
            .ToList();
        var chapter3Placements = result.ItemPlacementService.FromSceneGuid(chapter3Scene, duplicatedGuid);
        var chapter4Placements = result.ItemPlacementService.FromSceneGuid(chapter4Scene, duplicatedGuid);

        Assert.True(allPlacements.Count >= 2);
        Assert.Single(chapter3Placements);
        Assert.Single(chapter4Placements);
        Assert.All(chapter3Placements, placement => Assert.Equal(chapter3Scene, placement.SceneFile));
        Assert.All(chapter4Placements, placement => Assert.Equal(chapter4Scene, placement.SceneFile));
    }

    [Fact]
    public void ItemRandomizer_ZeroDropRatios_FallsBackToEthanLeg()
    {
        using var result = RandomizerTest.RunState();

        var drop = result.ItemRandomizer.GetNextGeneralDrop(
            result.Randomizer.GetRng("tests/zero-ratios"),
            new RandomItemSettings
            {
                MinAmmoQuantity = 0.5,
                MaxAmmoQuantity = 0.5,
                ItemRatioKeyFunc = _ => 0
            });

        Assert.Equal("EthanLeg", drop.Id);
        Assert.Equal(1, drop.CountEasy);
        Assert.Equal(1, drop.CountNormal);
        Assert.Equal(1, drop.CountMadhouse);
    }

    [Fact]
    public void ItemRandomizer_CreateGeneralItemPool_PreservesFractionalWeightPrecision()
    {
        using var result = RandomizerTest.RunState();

        var bag = result.ItemRandomizer.CreateGeneralItemPool(
            new RandomItemSettings
            {
                ItemRatioKeyFunc = id => id switch
                {
                    "Herb" => 0.03,
                    "Gunpowder" => 0.04,
                    _ => 0
                }
            },
            result.Randomizer.GetRng("tests/pool-precision"));
        var draws = bag.Next(bag.Count);

        Assert.Equal(7, bag.Count);
        Assert.Equal(3, draws.Count(x => x == "Herb"));
        Assert.Equal(4, draws.Count(x => x == "Gunpowder"));
    }

    [Fact]
    public void ItemRandomizer_DetermineDropAmount_RespectsDifficultyScalingForAmmo()
    {
        using var respecting = RandomizerTest.RunState(config => config["item-drop-respect-difficulty"] = true);
        using var flat = RandomizerTest.RunState(config => config["item-drop-respect-difficulty"] = false);

        var ammo = ItemDefinitionRepository.Default.FromId("ShotgunBullet")!;
        var baseAmount = (uint)Math.Max(1, (int)Math.Round(Math.Min(ammo.MaxStack, 150) * 0.5));

        var respectingAmounts = respecting.ItemRandomizer.DetermineDropAmount(
            ammo.Id,
            0.5,
            0.5,
            respecting.Randomizer.GetRng("tests/respect-difficulty"));
        var flatAmounts = flat.ItemRandomizer.DetermineDropAmount(
            ammo.Id,
            0.5,
            0.5,
            flat.Randomizer.GetRng("tests/flat-difficulty"));

        Assert.Equal(respecting.ItemRandomizer.ApplyDifficultyToDropAmount(baseAmount), respectingAmounts);
        Assert.Equal((baseAmount, baseAmount, baseAmount), flatAmounts);
    }

    [Fact]
    public void RandomItems_SingleDropPool_ReplacesEligibleNormalPlacement()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-items"] = true;
            ConfigureSingleDrop(config, ForcedDropId);
        });

        var (definition, placement) = FindRandomizedPlacement(
            result,
            (item, _) => !item.IsWeapon && item.Id != "SaveTape" && !item.IsStoryProgressionItem && item.Id != ForcedDropId);

        var beforeItem = GetItem(result.ReadBeforeScene(placement.SceneFile), placement.Guid);
        var afterItem = GetItem(result.ReadAfterScene(placement.SceneFile), placement.Guid);

        Assert.True(result.WasFileModified(placement.SceneFile));
        Assert.Equal(definition.Id, beforeItem.ItemDataID);
        Assert.Equal(ForcedDropId, afterItem.ItemDataID);
        Assert.Equal(1, afterItem.ItemStackNum);
        Assert.True(afterItem._IsOverwriteDifficultItemNumSetting);
        Assert.Equal(1, afterItem._DifficultItemNumSetting.EasyNum);
        Assert.Equal(1, afterItem._DifficultItemNumSetting.HardNum);
        Assert.NotEqual(beforeItem.SaveGUID, afterItem.SaveGUID);
    }

    [Fact]
    public void RandomItems_ReplaceWeaponsDisabled_PreservesWeaponPlacement()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-items"] = true;
            config["replace-weapons"] = false;
            ConfigureSingleDrop(config, ForcedDropId);
        });

        var (definition, placement) = FindRandomizedPlacement(result, (item, _) => item.IsWeapon);

        var beforeItem = GetItem(result.ReadBeforeScene(placement.SceneFile), placement.Guid);
        var afterItem = GetItem(result.ReadAfterScene(placement.SceneFile), placement.Guid);

        Assert.True(definition.IsWeapon);
        Assert.Equal(beforeItem.ItemDataID, afterItem.ItemDataID);
        Assert.Equal(beforeItem.ItemStackNum, afterItem.ItemStackNum);
        Assert.Equal(beforeItem.SaveGUID, afterItem.SaveGUID);
    }

    [Fact]
    public void RandomItems_ReplaceWeaponsEnabled_ReplacesWeaponPlacement()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-items"] = true;
            config["replace-weapons"] = true;
            ConfigureSingleDrop(config, ForcedDropId);
        });

        var (definition, placement) = FindRandomizedPlacement(result, (item, _) => item.IsWeapon && item.Id != ForcedDropId);

        var beforeItem = GetItem(result.ReadBeforeScene(placement.SceneFile), placement.Guid);
        var afterItem = GetItem(result.ReadAfterScene(placement.SceneFile), placement.Guid);

        Assert.True(definition.IsWeapon);
        Assert.NotEqual(beforeItem.ItemDataID, afterItem.ItemDataID);
        Assert.Equal(ForcedDropId, afterItem.ItemDataID);
    }

    [Fact]
    public void RandomItems_ReplaceMadhouseTapesDisabled_PreservesSaveTapePlacement()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-items"] = true;
            config["replace-madhouse-tapes"] = false;
            ConfigureSingleDrop(config, ForcedDropId);
        });

        var (_, placement) = FindRandomizedPlacement(result, (item, _) => item.Id == "SaveTape");

        var beforeItem = GetItem(result.ReadBeforeScene(placement.SceneFile), placement.Guid);
        var afterItem = GetItem(result.ReadAfterScene(placement.SceneFile), placement.Guid);

        Assert.Equal("SaveTape", beforeItem.ItemDataID);
        Assert.Equal(beforeItem.ItemDataID, afterItem.ItemDataID);
        Assert.Equal(beforeItem.SaveGUID, afterItem.SaveGUID);
    }

    [Fact]
    public void RandomItems_ReplaceMadhouseTapesEnabled_ReplacesSaveTapePlacement()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-items"] = true;
            config["replace-madhouse-tapes"] = true;
            ConfigureSingleDrop(config, ForcedDropId);
        });

        var (_, placement) = FindRandomizedPlacement(result, (item, _) => item.Id == "SaveTape");

        var beforeItem = GetItem(result.ReadBeforeScene(placement.SceneFile), placement.Guid);
        var afterItem = GetItem(result.ReadAfterScene(placement.SceneFile), placement.Guid);

        Assert.Equal("SaveTape", beforeItem.ItemDataID);
        Assert.Equal(ForcedDropId, afterItem.ItemDataID);
        Assert.NotEqual(beforeItem.SaveGUID, afterItem.SaveGUID);
    }

    [Fact]
    public void AdditionalItems_Enabled_AddsRandomExtraItemAtConfiguredPlacement()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-items"] = true;
            config["additional-items"] = true;
            ConfigureSingleDrop(config, ForcedDropId);
        });

        var placement = result.ItemPlacementService.ItemPlacements.First(x =>
            x.Enabled &&
            x.IsExtra &&
            !string.IsNullOrEmpty(x.SceneFile) &&
            x.Tags.Contains(ExtraPlacementModifier.RandomItemTag));

        var beforeDynamic = GetDynamicParent(result.ReadBeforeScene(placement.SceneFile));
        var afterDynamic = GetDynamicParent(result.ReadAfterScene(placement.SceneFile));
        var newChildren = GetNewChildren(beforeDynamic, afterDynamic);
        var newItem = Assert.Single(newChildren, child => child.FindComponent<app.Item>() != null);
        var item = newItem.FindComponent<app.Item>()!;
        var transform = newItem.FindComponent<via.Transform>()!;

        Assert.True(result.WasFileModified(placement.SceneFile));
        Assert.Equal(beforeDynamic.Children.Count() + 1, afterDynamic.Children.Count());
        Assert.Equal(ForcedDropId, item.ItemDataID);
        Assert.Equal(1, item.ItemStackNum);
        AssertPositionMatchesPlacement(transform, placement);
    }

    [Fact]
    public void AdditionalWoodenCrates_Enabled_AddsCrateAtConfiguredPlacement()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-items"] = true;
            config["additional-wooden-crates"] = true;
            config["additional-wooden-crates-fakes"] = false;
            ConfigureSingleDrop(config, ForcedDropId);
        });

        var placement = result.ItemPlacementService.ItemPlacements.First(x =>
            x.Enabled &&
            x.IsExtra &&
            !string.IsNullOrEmpty(x.SceneFile) &&
            x.Tags.Contains(ExtraPlacementModifier.WoodenCrateTag) &&
            x.Tags.Contains(ExtraPlacementModifier.NotFakeCrateTag));

        var beforeDynamic = GetDynamicParent(result.ReadBeforeScene(placement.SceneFile));
        var afterDynamic = GetDynamicParent(result.ReadAfterScene(placement.SceneFile));
        var newChild = Assert.Single(GetNewChildren(beforeDynamic, afterDynamic));
        var transform = newChild.FindComponent<via.Transform>()!;
        var destruct = newChild.FindComponent<app.ItemDropDestruct>();

        Assert.True(result.WasFileModified(placement.SceneFile));
        Assert.Equal(beforeDynamic.Children.Count() + 1, afterDynamic.Children.Count());
        Assert.NotNull(destruct);
        Assert.True(destruct!.Enabled);
        AssertPositionMatchesPlacement(transform, placement);
    }

    [Fact]
    public void BirdCageModifier_Enabled_ChangesRewardDataInBirdCageScene()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["random-bird-cage-drugs-coins"] = true;
        });

        var path = PakPath.SceneFile(BirdCageScenePath);
        var beforeStates = GetBirdCageStates(result.ReadBeforeScene(path));
        var afterStates = GetBirdCageStates(result.ReadAfterScene(path));

        Assert.True(result.WasFileModified(path));
        Assert.NotEmpty(beforeStates);
        Assert.Equal(beforeStates.Count, afterStates.Count);
        Assert.Contains(afterStates, after =>
        {
            var before = beforeStates.Single(x => x.ContainerGuid == after.ContainerGuid);
            return before.ItemId != after.ItemId ||
                   before.ItemCount != after.ItemCount ||
                   before.CoinCount != after.CoinCount;
        });
    }

    private static void ConfigureSingleDrop(RandomizerConfiguration configuration, string itemId)
    {
        foreach (var dropId in ItemDrops.GenericDrops)
        {
            configuration[$"item-drop-ratio-{dropId.ToLowerInvariant()}"] = dropId == itemId ? 1.0 : 0.0;
        }
    }

    private static (ItemDefinition Definition, ItemPlacement Placement) FindRandomizedPlacement(
        RandomizerRunResult result,
        Func<ItemDefinition, ItemPlacement, bool> predicate)
    {
        var itemRandomizer = result.ItemRandomizer;

        var match = result.AreaService.Areas
            .SelectMany(area => area.Items.Select(gameObject => (AreaPath: area.Path, GameObject: gameObject)))
            .SelectMany(x => result.ItemPlacementService.FromSceneGuid(x.AreaPath, x.GameObject.Guid))
            .DistinctBy(placement => placement.Guid)
            .Select(placement => (Definition: ItemDefinitionRepository.Default.FromId(placement.Id)!, Placement: placement))
            .Where(tuple =>
                tuple.Definition != null &&
                tuple.Placement.Dlc == null &&
                !tuple.Placement.IsExtra &&
                tuple.Placement.Enabled &&
                !tuple.Placement.Tags.Contains(ItemPlacement.ExcludeTag) &&
                itemRandomizer.IsItemAllowed(tuple.Definition) &&
                !BirdCageModifier.Guids.Contains(tuple.Placement.Guid) &&
                predicate(tuple.Definition, tuple.Placement))
            .FirstOrDefault();

        Assert.NotNull(match.Definition);
        return match;
    }

    private static app.Item GetItem(RszScene scene, Guid guid)
    {
        var gameObject = scene.FindGameObject(guid);
        Assert.NotNull(gameObject);

        var item = gameObject!.FindComponent<app.Item>();
        Assert.NotNull(item);
        return item!;
    }

    private static RszGameObject GetDynamicParent(RszScene scene)
    {
        var gameObject = scene.FindGameObject(go => go.Name.EndsWith("_dynamic", StringComparison.Ordinal));
        Assert.NotNull(gameObject);
        return gameObject!;
    }

    private static IReadOnlyList<RszGameObject> GetNewChildren(RszGameObject before, RszGameObject after)
    {
        var beforeGuids = before.Children.Select(child => child.Guid).ToHashSet();
        return after.Children.Where(child => !beforeGuids.Contains(child.Guid)).ToArray();
    }

    private static void AssertPositionMatchesPlacement(via.Transform transform, ItemPlacement placement)
    {
        const float tolerance = 0.001f;

        Assert.InRange(Math.Abs(transform.Position.X - placement.PosX), 0, tolerance);
        Assert.InRange(Math.Abs(transform.Position.Y - placement.PosY), 0, tolerance);
        Assert.InRange(Math.Abs(transform.Position.Z - placement.PosZ), 0, tolerance);
    }

    private static List<BirdCageState> GetBirdCageStates(RszScene scene)
    {
        var states = new List<BirdCageState>();

        scene.VisitGameObjects(gameObject =>
        {
            if (!gameObject.Name.Contains("CoinBox", StringComparison.OrdinalIgnoreCase))
                return;

            var gimmick = gameObject.Children.FirstOrDefault(child =>
                child.Name.EndsWith("_Gimmick", StringComparison.Ordinal) &&
                child.FindComponent<app.CoinCounter>() != null);
            var itemHolder = gameObject.Children.FirstOrDefault(child => child.FindComponent<app.Item>() != null);
            if (gimmick == null || itemHolder == null)
                return;

            var item = itemHolder.FindComponent<app.Item>()!;
            var coinCounter = gimmick.FindComponent<app.CoinCounter>()!;
            states.Add(new BirdCageState(gameObject.Guid, item.ItemDataID, item.ItemStackNum, coinCounter.CoinMax));
        });

        return states;
    }

    private sealed record BirdCageState(Guid ContainerGuid, string ItemId, int ItemCount, int CoinCount);
}
