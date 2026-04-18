using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using Enums.app;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class ItemModifier : Modifier
{
    private const string RandomizerKey = "modifier/static-items";
    private const string ItemBoxGameObjectName = "ItemBox_VLong";
    private const string FakeItemBoxGameObjectName = "ItemBox_Fake";

    private readonly static ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;
    private readonly static HashSet<Guid> _birdCageGuids = new(BirdCageModifier.Guids);

    private const int PreferredHealingDropProbability = 50; // TODO Config?

    private Vector3 RandomizeScale(Rng rng)
    {
        float[] allowedScales = [0.5f, 0.75f, 1f, 1.25f, 1.5f];
        var chosen = rng.Next(allowedScales);
        return new Vector3(chosen, chosen, chosen);
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
        var fakePct = (int)rng.NextDouble(minFakePct, maxFakePct);

        if ((allowFakeCrates && placement.Tags.Contains(ItemPlacement.FakeCrateTag)) ||
            (!placement.Tags.Contains(ItemPlacement.NotFakeCrateTag) && allowFakeCrates && rng.NextProbability(fakePct)))
        {
            isFake = true;
            template = randomizer.TemplateService.GetObject(FakeItemBoxGameObjectName).Clone();
            var fsm = template.FindComponent<via.fsm.Fsm>()!;
            foreach (var action in fsm.SceneData[0].v1_Actions)
            {
                if (action is app.fsm.PartsEnable partsEnable && partsEnable.GameObjSet.GameObj == template.Guid)
                {
                    partsEnable.GameObjSet.GameObj = newGuid;
                }
                else if (action is app.fsm.CollidersEnable collidersEnable && collidersEnable.GameObjSet.GameObj == template.Guid)
                {
                    collidersEnable.GameObjSet.GameObj = newGuid;
                }
            }

            template = template.AddOrUpdateComponent(fsm);

            var oilcan = template.FindComponent<app.Oilcan>()!;
            oilcan.FsmObject = newGuid;
            oilcan.DisableLucasMessage = true;
            template = template.AddOrUpdateComponent(oilcan);
        }
        else
        {
            template = randomizer.TemplateService.GetObject(ItemBoxGameObjectName).Clone();
            var itemDropDestruct = template.FindComponent<app.ItemDropDestruct>()!;
            itemDropDestruct.Enabled = true;
            itemDropDestruct.SaveGUID = itemDropDestruct.SaveGUID != Guid.Empty ? itemDropDestruct.SaveGUID : Guid.NewGuid();
            template = template.AddOrUpdateComponent(itemDropDestruct);
        }

        template = template.WithGuid(placement.Guid != Guid.Empty ? placement.Guid : newGuid);
        //template = template.WithName("sm9133_BreakableVLongBox01A_RigidBodyDestruction");

        var transform = template.FindComponent<via.Transform>()!;
        transform.Position = placement.Position;
        transform.Rotation = new Quaternion(0, 0, 0, 1);
        transform.Scale = RandomizeScale(rng);
        template = template.AddOrUpdateComponent(transform);

        parentGameObject = parentGameObject.AddOrUpdateChild(template);
        logger.LogLine($"[EXTRA] {(isFake ? "FAKE " : "")}Wooden crate at {placement.Position} in {placement.SceneFile}");
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

            template = randomizer.TemplateService.GetItemTemplate(drop.Id);
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
            template = randomizer.TemplateService.GetItemTemplate(placement.Id);
            item = template.FindComponent<app.Item>()!;

            item.ItemDataID = placement.Id;
            item.ItemStackNum = placement.StackNum;
            item._IsOverwriteDifficultItemNumSetting = true;
            item._DifficultItemNumSetting.EasyNum = placement.EasyNum;
            item._DifficultItemNumSetting.HardNum = placement.HardNum;

            var name = _itemDefinitions.FromId(placement.Id)!.Name;
            logger.LogLine($"[EXTRA] [{placement.EasyNum}, {placement.StackNum}, {placement.HardNum}]x {name} at {placement.Position} in {placement.SceneFile}");
        }

        var newGuid = rng.NextGuid();
        template.Guid = newGuid;
        logger.LogLine($"GUID: {newGuid}");

        item.SaveGUID = placement.SaveGuid != Guid.Empty ? placement.SaveGuid : Guid.NewGuid();
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

    private void HandleExtraItemsForScene(
        Randomizer randomizer,
        RandomizerLogger logger,
        Rng rng,
        IReadOnlyList<ItemPlacement> placements,
        RandomItemSettings randomItemSettings,
        bool allowExtraItems,
        bool allowExtraCrates)
    {
        if (placements.Count == 0 || (!allowExtraItems && !allowExtraCrates))
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
                if (allowExtraCrates && placement.Tags.Contains(ItemPlacement.WoodenCrateTag))
                {
                    scene = AddExtraCrate(scene, GetDynamicParentGameObject(), randomizer, logger, placement, rng);
                }
                else if (placement.Tags.Contains(ItemPlacement.WeaponChestTag))
                {
                    scene = AddExtraChest(scene, randomizer, logger, placement);
                }
                else if (allowExtraItems)
                {
                    var isRandom = placement.Tags.Contains(ItemPlacement.RandomItemTag);
                    var hasFixedItem = !string.IsNullOrWhiteSpace(placement.Id);

                    if (isRandom || hasFixedItem)
                    {
                        scene = AddExtraItem(scene, GetDynamicParentGameObject(), randomizer, logger, placement, rng, isRandom, randomItemSettings);
                    }
                    else
                    {
                        logger.LogLine($"[SKIP EXTRA] Placement at {placement.Position} in {placement.SceneFile} has no item id and is not marked random.");
                    }
                }
            }

            return scene;
        });
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("random-items"))
            return;

        var rng = randomizer.GetRng(RandomizerKey);
        var itemRandomizer = randomizer.ItemRandomizer;
        var itemPlacementService = randomizer.ItemPlacementService;
        var areaService = randomizer.AreaService;
        var templateService = randomizer.TemplateService;
        var allowExtraItems = randomizer.GetConfigOption<bool>("additional-items");
        var allowExtraCrates = randomizer.GetConfigOption<bool>("additional-wooden-crates");
        var replaceMadhouseTapes = randomizer.GetConfigOption<bool>("replace-madhouse-tapes");
        var replaceWeapons = randomizer.GetConfigOption<bool>("replace-weapons");
        var preserveItemModels = randomizer.GetConfigOption<bool>("preserve-item-models");
        var randomItemSettings = new RandomItemSettings()
        {
            MinAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-min", 0.1),
            MaxAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-max", 1.0),
            ItemRatioKeyFunc = (id) => randomizer.GetConfigOption<double>($"item-drop-ratio-{id.ToString().ToLowerInvariant()}")
        };

        // Extra items
        itemPlacementService.ItemPlacements
            .Where(placement => placement.Enabled && placement.IsExtra && !string.IsNullOrEmpty(placement.SceneFile))
            .GroupBy(placement => placement.SceneFile, StringComparer.OrdinalIgnoreCase)
            .ToList()
            .ForEach(group => HandleExtraItemsForScene(randomizer, logger, rng, group.ToList(), randomItemSettings, allowExtraItems, allowExtraCrates));

        // Normal items
        foreach (var area in areaService.Areas)
        {
            var randomizableItems = new List<(ItemDefinition Definition, ItemPlacement Placement)>();
            foreach (var itemGameObject in area.Items)
            {
                foreach (var placement in itemPlacementService.FromGuid(itemGameObject.Guid))
                {
                    if (placement.Dlc != null
                        || placement.IsExtra
                        || !placement.Enabled
                        || placement.Tags.Contains(ItemPlacement.ExcludeTag)
                        || _birdCageGuids.Contains(placement.Guid))
                    {
                        continue;
                    }

                    var definition = _itemDefinitions.FromId(placement.Id);
                    if (definition == null || !itemRandomizer.IsItemAllowed(definition))
                        continue;

                    randomizableItems.Add((definition, placement));
                }
            }

            if (randomizableItems.Count == 0)
                continue;

            logger.Push(area.Path);

            var itemsToReplace = new List<(ItemDefinition Definition, ItemPlacement Placement)>(randomizableItems.Count);
            foreach (var (definition, placement) in randomizableItems)
            {
                if (!replaceMadhouseTapes && definition.Id == "SaveTape")
                {
                    logger.LogLine($"NOT replacing Madhouse cassette tape at {placement.Position} in {placement.SceneFile}");
                    logger.LogLine($"GUID: {placement.Guid}");
                    continue;
                }

                if (!replaceWeapons && definition.IsWeapon)
                {
                    logger.LogLine($"NOT replacing weapon \"{definition.Name}\" at {placement.Position} in {placement.SceneFile}");
                    logger.LogLine($"GUID: {placement.Guid}");
                    continue;
                }

                itemsToReplace.Add((definition, placement));
            }

            if (itemsToReplace.Count > 0)
            {
                randomizer.FileRepository.ModifyScnFile(area.Path, scene =>
                {
                    foreach (var (_, placement) in itemsToReplace)
                    {
                        var originalGameObject = scene.FindGameObject(placement.Guid)!;
                        var originalTransform = originalGameObject.FindComponent<via.Transform>();
                        var itemComponent = originalGameObject.FindComponent<app.Item>()!;
                        var drop = itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);

                        var replaceeName = _itemDefinitions.FromId(itemComponent.ItemDataID)!.Name;
                        var replacerName = _itemDefinitions.FromId(drop.Id)!.Name;
                        var quantity = itemComponent._IsOverwriteDifficultItemNumSetting
                            ? $"[{itemComponent._DifficultItemNumSetting.EasyNum}, {itemComponent.ItemStackNum}, {itemComponent._DifficultItemNumSetting.HardNum}]"
                            : itemComponent.ItemStackNum.ToString();
                        logger.LogLine($"Replacing {quantity}x {replaceeName} at {placement.Position} with " +
                            $"[{drop.CountEasy}, {drop.CountNormal}, {drop.CountMadhouse}]x {replacerName}...");
                        logger.LogLine($"GUID: {originalGameObject.Guid}");
                        logger.LogLine($"Scene: {placement.SceneFile}");

                        itemComponent.SaveGUID = Guid.NewGuid(); // IMPORTANT!
                        itemComponent.ItemDataID = drop.Id;
                        itemComponent.ItemStackNum = drop.CountNormal;
                        itemComponent._IsOverwriteDifficultItemNumSetting = true;
                        itemComponent._DifficultItemNumSetting.EasyNum = drop.CountEasy;
                        itemComponent._DifficultItemNumSetting.HardNum = drop.CountMadhouse;
                        originalGameObject = originalGameObject.AddOrUpdateComponent(itemComponent);

                        var newGameObject = templateService.GetItemTemplate(drop.Id);
                        newGameObject = newGameObject.WithGuid(originalGameObject.Guid);
                        newGameObject = newGameObject.AddOrUpdateComponent(originalTransform);
                        newGameObject = newGameObject.AddOrUpdateComponent(itemComponent);

                        if (preserveItemModels)
                        {
                            var mesh = originalGameObject.FindComponent("via.render.Mesh");
                            if (mesh != null)
                            {
                                newGameObject = newGameObject.AddOrUpdateComponent(mesh);
                            }
                        }

                        scene = scene.ReplaceGameObject(originalGameObject.Guid, newGameObject);
                    }

                    return scene;
                });
            }

            logger.Pop();
        }
    }
}
