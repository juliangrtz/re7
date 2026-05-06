using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Services;
using Enums.app;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class ExtraPlacementModifier : Modifier
{
    #region Tags
    internal const string WoodenCrateTag = "crate";
    internal const string NotFakeCrateTag = "not_fake";
    internal const string FakeCrateTag = "fake";
    internal const string WeaponChestTag = "weapon_chest";
    internal const string ItemBoxTag = "item_box";
    internal const string RandomItemTag = "random";
    #endregion

    private const string WoodenCrateGameObjectName = "ItemBox_VLong";
    private const string FakeWoodenCrateGameObjectName = "ItemBox_Fake";
    private const string ItemBoxGameObjectName = "ItemBox";
    private const int PreferredHealingDropProbability = 50; // TODO Config?

    private readonly static ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    private enum ExtraPlacementKind
    {
        Item,
        WoodenCrate,
        WeaponChest,
        ItemBox
    }

    private RszScene AddExtraChest(
        RszScene scene,
        Randomizer randomizer,
        RandomizerLogger logger,
        ItemPlacement placement)
        => randomizer.ChestService.PlaceWeaponChest(logger, scene, placement);

    private RszScene AddExtraCrate(
        RszScene scene,
        RszGameObject parentGameObject,
        Randomizer randomizer,
        RandomizerLogger logger,
        ItemPlacement placement,
        Rng rng)
    {
        var allowFakeCrates = randomizer.GetConfigOption<bool>("additional-wooden-crates-fakes");
        RszGameObject template;
        var isFake = false;
        var newGuid = rng.NextGuid();
        var minFakePct = randomizer.GetConfigOption<double>("additional-wooden-crates-fakes-pct-min");
        var maxFakePct = randomizer.GetConfigOption<double>("additional-wooden-crates-fakes-pct-max");
        var fakeProbability = rng.NextDouble(minFakePct, maxFakePct);

        if ((allowFakeCrates && placement.Tags.Contains(FakeCrateTag)) ||
            (!placement.Tags.Contains(NotFakeCrateTag) && allowFakeCrates && rng.NextProbability(fakeProbability)))
        {
            isFake = true;
            template = randomizer.TemplateService
                .GetObject(FakeWoodenCrateGameObjectName)
                .CloneWithNewGuids(
                    randomizer.GetRng("modifier/extra-placement/crate-template-instances", placement.SceneFile, placement.GuidOrAuto, true),
                    newGuid);
        }
        else
        {
            template = randomizer.TemplateService
                .GetObject(WoodenCrateGameObjectName)
                .CloneWithNewGuids(
                    randomizer.GetRng("modifier/extra-placement/crate-template-instances", placement.SceneFile, placement.GuidOrAuto, false),
                    newGuid);
            var itemDropDestruct = template.FindComponent<app.ItemDropDestruct>()!;
            itemDropDestruct.Enabled = true;
            itemDropDestruct.SaveGUID = itemDropDestruct.SaveGUID != Guid.Empty ? itemDropDestruct.SaveGUID : rng.NextGuid();
            template = template.AddOrUpdateComponent(itemDropDestruct);
        }

        var transform = template.FindComponent<via.Transform>()!;
        transform.Position = placement.Position;
        transform.Scale = Vector3.One;
        template = template.AddOrUpdateComponent(transform);

        parentGameObject = parentGameObject.AddOrUpdateChild(template);
        logger.LogLine($"[EXTRA] {(isFake ? "FAKE " : "")}Wooden crate at {placement.Position} in {placement.SceneFile}");
        logger.LogLine($"GUID: {newGuid}");

        return scene.UpdateGameObject(parentGameObject);
    }

    private RszScene AddExtraItemBox(
        RszScene scene,
        RszGameObject parentGameObject,
        Randomizer randomizer,
        RandomizerLogger logger,
        ItemPlacement placement,
        Rng rng)
    {
        var newGuid = rng.NextGuid();
        var template = randomizer.TemplateService
            .GetObject(ItemBoxGameObjectName)
            .CloneWithNewGuids(
                randomizer.GetRng("modifier/extra-placement/item-box-template-instances", placement.SceneFile, placement.GuidOrAuto),
                newGuid);
        var interactGameObject = template.Children.FirstOrDefault(child => child.FindComponent<app.InteractSendFsm>() != null);
        if (interactGameObject != null)
        {
            var interact = interactGameObject.FindComponent<app.InteractSendFsm>()!;
            interact.SaveGUID = rng.NextGuid();
            interactGameObject = interactGameObject.AddOrUpdateComponent(interact);
            template = template.AddOrUpdateChild(interactGameObject);
        }

        var transform = template.FindComponent<via.Transform>()!;
        transform.Position = placement.Position;
        transform.Rotation = placement.Rotation;
        transform.Scale = Vector3.One;
        template = template.AddOrUpdateComponent(transform);

        parentGameObject = parentGameObject.AddOrUpdateChild(template);
        logger.LogLine($"[EXTRA] Item box at {placement.Position} in {placement.SceneFile}");
        logger.LogLine($"GUID: {newGuid}");

        return scene.UpdateGameObject(parentGameObject);
    }

    private RszScene AddExtraItem(
        RszScene scene,
        RszGameObject parentGameObject,
        Randomizer randomizer,
        RandomizerLogger logger,
        ItemPlacement placement,
        Rng rng,
        bool isRandom,
        RandomItemSettings randomItemSettings)
    {
        RszGameObject template;
        Item drop;
        app.Item item;
        Guid newGuid;

        if (isRandom)
        {
            var preferHealing = randomizer.GetConfigOption<bool>("additional-items-prefer-healing");

            if (preferHealing && rng.NextProbability(PreferredHealingDropProbability))
            {
                var heal = randomizer.ItemRandomizer.GetRandomItemDefinition(rng, Enums.app.Item.ItemCategoryType.Drug, true);
                drop = new Item(heal?.Id ?? ItemID.Herb.ToString(), 1);
            }
            else
            {
                drop = randomizer.ItemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);
            }

            var templateItemId = randomizer.ItemRandomizer.GetItemTemplateIdForDrop(drop.Id, rng, randomItemSettings);
            newGuid = rng.NextGuid();
            var templateInstanceRng = randomizer.GetRng(
                "modifier/extra-placement/template-instances",
                placement.SceneFile,
                placement.GuidOrAuto,
                templateItemId);
            template = randomizer.TemplateService
                .GetItemTemplate(templateItemId)
                .CloneWithNewGuids(templateInstanceRng, newGuid);
            item = template.FindComponent<app.Item>()!;

            item.ItemDataID = drop.Id;
            item.ItemStackNum = drop.CountNormal;
            item._IsOverwriteDifficultItemNumSetting = true;
            item._DifficultItemNumSetting.EasyNum = drop.CountEasy;
            item._DifficultItemNumSetting.HardNum = drop.CountMadhouse;

            var name = _itemDefinitions.FromId(drop.Id)!.Name;
            logger.LogLine($"[RANDOM EXTRA] [{drop.CountEasy}, {drop.CountNormal}, {drop.CountMadhouse}]x {name} " +
                $"at {placement.Position} in {placement.SceneFile}");
        }
        else
        {
            var templateItemId = randomizer.ItemRandomizer.GetItemTemplateIdForDrop(placement.Id, rng, randomItemSettings);
            newGuid = rng.NextGuid();
            var templateInstanceRng = randomizer.GetRng(
                "modifier/extra-placement/template-instances",
                placement.SceneFile,
                placement.GuidOrAuto,
                templateItemId);
            template = randomizer.TemplateService
                .GetItemTemplate(templateItemId)
                .CloneWithNewGuids(templateInstanceRng, newGuid);
            item = template.FindComponent<app.Item>()!;

            item.ItemDataID = placement.Id;
            item.ItemStackNum = placement.StackNum;
            item._IsOverwriteDifficultItemNumSetting = true;
            item._DifficultItemNumSetting.EasyNum = placement.EasyNum;
            item._DifficultItemNumSetting.HardNum = placement.HardNum;

            var name = _itemDefinitions.FromId(placement.Id)!.Name;
            logger.LogLine($"[EXTRA] [{placement.EasyNum}, {placement.StackNum}, {placement.HardNum}]x {name} at {placement.Position} in {placement.SceneFile}");
        }

        logger.LogLine($"GUID: {newGuid}");

        item.SaveGUID = placement.SaveGuid != Guid.Empty ? placement.SaveGuid : rng.NextGuid();
        item.RoomId = 0;
        item.Enabled = true;
        template = template.AddOrUpdateComponent(item);

        var transform = template.FindComponent<via.Transform>()!;
        transform.Position = placement.Position;
        transform.Rotation = placement.Rotation;
        template = template.AddOrUpdateComponent(transform);

        parentGameObject = parentGameObject.AddOrUpdateChild(template);
        return scene.UpdateGameObject(parentGameObject);
    }

    private static ExtraPlacementKind GetPlacementKind(ItemPlacement placement)
    {
        var specialKinds = new List<ExtraPlacementKind>(3);
        if (placement.Tags.Contains(WoodenCrateTag))
        {
            specialKinds.Add(ExtraPlacementKind.WoodenCrate);
        }
        if (placement.Tags.Contains(WeaponChestTag))
        {
            specialKinds.Add(ExtraPlacementKind.WeaponChest);
        }
        if (placement.Tags.Contains(ItemBoxTag))
        {
            specialKinds.Add(ExtraPlacementKind.ItemBox);
        }

        return specialKinds.Count switch
        {
            0 => ExtraPlacementKind.Item,
            1 => specialKinds[0],
            _ => throw new Exception(
                $"Extra placement at {placement.Position} in {placement.SceneFile} has conflicting special tags: {string.Join(", ", placement.Tags)}")
        };
    }

    private static bool IsPlacementEnabled(
        ExtraPlacementKind kind,
        bool allowExtraItems,
        bool allowExtraCrates)
        => kind switch
        {
            ExtraPlacementKind.ItemBox => true,
            ExtraPlacementKind.WoodenCrate => allowExtraCrates,
            ExtraPlacementKind.WeaponChest => allowExtraItems,
            _ => allowExtraItems
        };

    private RszScene ApplyPlacementToScene(
        RszScene scene,
        RszGameObject parentGameObject,
        Randomizer randomizer,
        RandomizerLogger logger,
        Rng rng,
        ItemPlacement placement,
        RandomItemSettings randomItemSettings,
        bool allowExtraItems,
        bool allowExtraCrates)
    {
        var kind = GetPlacementKind(placement);
        if (!IsPlacementEnabled(kind, allowExtraItems, allowExtraCrates))
            return scene;

        return kind switch
        {
            ExtraPlacementKind.WoodenCrate => AddExtraCrate(scene, parentGameObject, randomizer, logger, placement, rng),
            ExtraPlacementKind.WeaponChest => AddExtraChest(scene, randomizer, logger, placement),
            ExtraPlacementKind.ItemBox => AddExtraItemBox(scene, parentGameObject, randomizer, logger, placement, rng),
            _ => AddPlacementItem(scene, parentGameObject, randomizer, logger, placement, rng, randomItemSettings)
        };
    }

    private RszScene AddPlacementItem(
        RszScene scene,
        RszGameObject parentGameObject,
        Randomizer randomizer,
        RandomizerLogger logger,
        ItemPlacement placement,
        Rng rng,
        RandomItemSettings randomItemSettings)
    {
        var isRandom = placement.Tags.Contains(RandomItemTag);
        var hasFixedItem = !string.IsNullOrWhiteSpace(placement.Id);

        if (!isRandom && !hasFixedItem)
        {
            logger.LogLine($"[SKIP EXTRA] Placement at {placement.Position} in {placement.SceneFile} has no item id and is not marked random.");
            return scene;
        }

        return AddExtraItem(scene, parentGameObject, randomizer, logger, placement, rng, isRandom, randomItemSettings);
    }

    private void HandleExtraItemsForScene(
        Randomizer randomizer,
        RandomizerLogger logger,
        Rng rng,
        List<ItemPlacement> placements,
        RandomItemSettings randomItemSettings,
        bool allowExtraItems,
        bool allowExtraCrates)
    {
        if (placements.Count == 0)
            return;

        randomizer.FileRepository.ModifyScnFile(placements[0].SceneFile, scene =>
        {
            Guid? dynamicParentGuid = null;
            RszGameObject GetDynamicParentGameObject()
            {
                if (dynamicParentGuid == null)
                {
                    dynamicParentGuid = scene.FindGameObject(go => go.Name.EndsWith("_dynamic"))?.Guid
                        ?? throw new Exception("Failed to obtain \"_dynamic\" parent GameObject!");
                }

                return scene.FindGameObject(dynamicParentGuid.Value)!;
            }

            foreach (var placement in placements)
            {
                scene = ApplyPlacementToScene(
                    scene,
                    GetDynamicParentGameObject(),
                    randomizer,
                    logger,
                    rng,
                    placement,
                    randomItemSettings,
                    allowExtraItems,
                    allowExtraCrates);
            }

            return scene;
        });
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var itemPlacementService = randomizer.ItemPlacementService;
        var context = randomizer.StaticItemRandomizationService;
        var randomItemsEnabled = randomizer.GetConfigOption<bool>("random-items");
        var allowExtraItems = randomizer.GetConfigOption<bool>("additional-items");
        var allowExtraCrates = randomizer.GetConfigOption<bool>("additional-wooden-crates");
        var extraPlacements = itemPlacementService.ItemPlacements
            .Where(placement => placement.Enabled && placement.IsExtra && !string.IsNullOrEmpty(placement.SceneFile))
            .ToList();
        var hasAlwaysOnItemBoxes = extraPlacements.Any(placement => placement.Tags.Contains(ItemBoxTag));

        if (!allowExtraItems && !allowExtraCrates && !hasAlwaysOnItemBoxes)
            return;

        extraPlacements
            .GroupBy(placement => placement.SceneFile, StringComparer.OrdinalIgnoreCase)
            .ToList()
            .ForEach(group => HandleExtraItemsForScene(
                randomizer,
                logger,
                context.Rng,
                group.ToList(),
                context.RandomItemSettings,
                allowExtraItems,
                allowExtraCrates));
    }
}
