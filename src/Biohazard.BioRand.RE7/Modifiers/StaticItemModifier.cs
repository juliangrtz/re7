using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Services;
using Enums.app;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class StaticItemModifier : Modifier
{
    private const string RandomizerKey = "modifier/static-items";
    private const string ItemBoxGameObjectName = "ItemBox_VLong";
    private const string FakeItemBoxGameObjectName = "ItemBox_Fake";

    private readonly static ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    private const int PreferredHealingDropProbability = 20;
    private const int FakeCrateProbability = 10;

    private Vector3 RandomizeScale(Rng rng)
    {
        float[] allowedScales = [0.5f, 0.75f, 1f, 1.25f, 1.5f];
        var chosen = rng.Next(allowedScales);
        return new Vector3(chosen, chosen, chosen);
    }

    private RszScene AddExtraCrate(RszScene scene, RszGameObject parentGameObject, Randomizer randomizer, Rng rng, ItemPlacement placement)
    {
        var allowFakeCrates = randomizer.GetConfigOption<bool>("additional-wooden-crates-fakes");
        RszGameObject template;

        var newGuid = rng.NextGuid();
        if ((allowFakeCrates && placement.Tags.Contains(ItemPlacement.FakeCrateTag)) ||
            (!placement.Tags.Contains(ItemPlacement.NotFakeCrateTag) && allowFakeCrates && rng.NextProbability(FakeCrateProbability)))
        {
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
        return scene.UpdateGameObject(parentGameObject);
    }

    private RszScene AddExtraItem(
        RszScene scene,
        RszGameObject parentGameObject,
        Randomizer randomizer,
        ItemPlacement placement,
        Rng rng,
        bool isRandom,
        RandomItemSettings randomItemSettings)
    {
        var template = randomizer.TemplateService.GetItemTemplate(placement.Id);
        var item = template.FindComponent<app.Item>()!;
        if (isRandom)
        {
            var preferHealing = randomizer.GetConfigOption<bool>("additional-items-prefer-healing");
            Item drop;

            if (preferHealing && rng.NextProbability(PreferredHealingDropProbability))
            {
                var heal = randomizer.ItemRandomizer.GetRandomItemDefinition(rng, Enums.app.Item.ItemCategoryType.Drug, true);
                drop = new Item(heal?.Id ?? ItemID.Herb.ToString(), 1);
            }
            else
            {
                drop = randomizer.ItemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);
            }
            item.ItemDataID = drop.Id;
            item.ItemStackNum = drop.CountNormal;
            item._IsOverwriteDifficultItemNumSetting = true;
            item._DifficultItemNumSetting.EasyNum = drop.CountEasy;
            item._DifficultItemNumSetting.HardNum = drop.CountMadhouse;
        }
        else
        {
            item.ItemDataID = placement.Id;
            item.ItemStackNum = placement.StackNum;
            item._IsOverwriteDifficultItemNumSetting = true;
            item._DifficultItemNumSetting.EasyNum = placement.EasyNum;
            item._DifficultItemNumSetting.HardNum = placement.HardNum;
        }
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

    private void HandleExtraItem(Randomizer randomizer, RandomizerLogger logger, Rng rng, ItemPlacement placement, RandomItemSettings randomItemSettings)
    {
        if (!placement.Enabled)
            return;

        var allowExtraItems = randomizer.GetConfigOption<bool>("additional-items");
        var allowExtraCrates = randomizer.GetConfigOption<bool>("additional-wooden-crates");

        randomizer.FileRepository.ModifyScnFile(placement.SceneFile, randomizer.IsOnRaytracingVersion, scene =>
        {
            RszGameObject parentGameObject = scene.FindGameObject(go => go.Name.EndsWith("_dynamic"))
                ?? throw new Exception("Failed to obtain \"_dynamic\" parent GameObject!");

            if (allowExtraCrates && placement.Tags.Contains(ItemPlacement.WoodenCrateTag))
            {
                scene = AddExtraCrate(scene, parentGameObject, randomizer, rng, placement);
                logger.LogLine($"[EXTRA] Wooden crate at {placement.Position} in {placement.SceneFile}");
            }
            else if (allowExtraItems)
            {

                var isRandom = placement.Tags.Contains("random");
                scene = AddExtraItem(scene, parentGameObject, randomizer, placement, rng, isRandom, randomItemSettings);
                logger.LogLine($"[{(isRandom ? "RANDOM " : "")}EXTRA] {placement.StackNum}x {placement.Id} at {placement.Position} in {placement.SceneFile}");
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
        var randomItemSettings = new RandomItemSettings()
        {
            MinAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-min", 0.1),
            MaxAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-max", 1.0),
            ItemRatioKeyFunc = (id) => randomizer.GetConfigOption<double>($"item-drop-ratio-{id.ToString().ToLowerInvariant()}")
        };

        // Extra items
        itemPlacementService.ItemPlacements
            .Where(placement => placement.IsExtra)
            .ToList()
            .ForEach(placement => HandleExtraItem(randomizer, logger, rng, placement, randomItemSettings));

        // Normal items
        foreach (var area in areaService.Areas)
        {
            var randomizableItems = area.Items
                .SelectMany(i => itemPlacementService.FromGuid(i.Guid))
                .Select(i => (_itemDefinitions.FromId(i.Id)!, i))
                .Where(tuple =>
                {
                    var (definition, placement) = tuple;
                    return definition != null
                        && placement.Enabled
                        && itemRandomizer.IsItemAllowed(definition)
                        && !BirdCageModifier.Guids.Contains(placement.Guid);
                })
                .ToList();

            if (randomizableItems.Count == 0)
                continue;

            logger.Push(area.Path);

            foreach (var (definition, placement) in randomizableItems)
            {
                randomizer.FileRepository.ModifyScnFile(placement.SceneFile, randomizer.IsOnRaytracingVersion, scene =>
                {
                    var originalGameObject = scene.FindGameObject(placement.Guid)!;
                    var originalTransform = originalGameObject.FindComponent<via.Transform>();
                    var itemComponent = originalGameObject.FindComponent<app.Item>()!;
                    var drop = itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);
                    logger.LogLine($"Replacing {itemComponent.ItemStackNum}x {itemComponent.ItemDataID} at {placement.Position} with " +
                        $"[{drop.CountEasy}, {drop.CountNormal}, {drop.CountMadhouse}]x {drop.Id}...");

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

                    if (randomizer.GetConfigOption<bool>("preserve-item-models"))
                    {
                        var mesh = originalGameObject.FindComponent("via.render.Mesh");
                        if (mesh != null)
                        {
                            newGameObject = newGameObject.AddOrUpdateComponent(mesh);
                        }
                    }

                    scene = scene.ReplaceGameObject(originalGameObject.Guid, newGameObject);

                    return scene;
                });
            }
            logger.Pop();
        }
    }
}