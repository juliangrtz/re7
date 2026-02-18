using Biohazard.BioRand.RE7.Chapters;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Biohazard.BioRand.RE7.Modifiers {
    internal class DropItemModifier : Modifier {
        public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger) {
            var areaService = randomizer.AreaService;
            foreach (var area in areaService.Areas) {
                var items = area.Items.ToArray();
                if (items.Length == 0)
                    continue;

                logger.Push($"{area.FileName}");
                foreach (var go in items) {
                    var dropItem = go.FindComponent("chainsaw.DropItem");
                    if (dropItem == null)
                        continue;

                    var stage = dropItem.Get<int>("_ItemData.StageID");
                    var itemId = dropItem.Get<int>("_ItemData.ItemID");
                    var itemCount = dropItem.Get<int>("_ItemData.Count");
                    // dropItem.Get<int>("_ItemData.AmmoItemID");
                    // dropItem.Get<int>("_ItemData.AmmoCount");

                    var contextId = dropItem.Get<ContextID>("_ID");
                    var position = new Transform(go).Position;
                    var item = new Item(itemId, itemCount);
                    logger.LogLine(
                        go.Guid,
                        item,
                        stage,
                        position.X.ToString("0.0"),
                        position.Y.ToString("0.0"),
                        position.Z.ToString("0.0"),
                        contextId);
                }
                logger.Pop();
            }
        }

        public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger) {
            if (!randomizer.GetConfigOption<bool>("random-items"))
                return;

            var preserveModels = randomizer.GetConfigOption<bool>("preserve-item-models");

            var areaService = randomizer.AreaService;
            var itemService = randomizer.GetService<ItemService>();

            // Get context IDs for each item
            foreach (var item in areaService.Areas) {
                foreach (var gameObject in item.Items) {
                    var placement = itemService.FromGuid(gameObject.Guid);
                    if (placement != null) {
                        var itemDrop = gameObject.FindComponent("chainsaw.DropItem")!;
                        var itemData = itemDrop.Get<DropItemContext.SaveData>("_ItemData");
                        placement.OldItem = new Item(itemData.ItemID, itemData.Count);
                        placement.ContextId = itemDrop.Get<ContextID>("_ID");
                    }
                }
            }

            var itemsToRemove = itemService.ItemPlacements
                .Where(x => x.Campaign == randomizer.Campaign)
                .Where(x => x.Tags.Contains(ItemTags.Remove))
                .ToArray();

            var itemsToChange = itemService.ItemPlacements
                .Where(x => x.Campaign == randomizer.Campaign)
                .Where(x => !x.Tags.Contains(ItemTags.Remove))
                .Where(x => CanChangeItem(randomizer, x))
                .ToArray();

            var result = Randomize(randomizer, itemsToChange, logger);

            foreach (var area in areaService.Areas) {
                if (!preserveModels) {
                    UpdateModels(area, result);
                }
                area.ItemSaveData.Update(result);
            }

            foreach (var item in itemsToRemove) {
                var area = areaService.FindAreaContainingGameObject(item.Guid);
                if (area == null)
                    continue;

                area.Scene = area.Scene.RemoveGameObject(item.Guid);
                area.ItemSaveData.Remove(item.ContextId);
            }

            foreach (var item in itemService.ItemPlacements) {
                if (item.Campaign != randomizer.Campaign)
                    continue;

                var positionChange = !item.IsExtra && (item.X != 0 || item.Y != 0 || item.Z != 0);
                var conditionChange = item.Condition != default;
                if (!positionChange && !conditionChange)
                    continue;

                var area = areaService.FindAreaContainingGameObject(item.GuidOrAuto);
                if (area == null)
                    continue;

                var gameObject = area.Scene.FindGameObject(item.GuidOrAuto);
                if (gameObject == null)
                    continue;

                if (positionChange) {
                    var transform = new Transform(gameObject) {
                        Position = item.Position,
                        Eular = item.Eular
                    };
                    gameObject = gameObject.AddOrUpdateComponent(transform.ToComponent());

                    var itemDrop = gameObject.FindComponent("chainsaw.DropItem")!;
                    itemDrop = itemDrop.Set("_ItemData.StageID", item.Stage);
                    gameObject = gameObject.AddOrUpdateComponent(itemDrop);

                    area.ItemSaveData.UpdateStage(item.ContextId, item.Stage);
                }

                if (conditionChange) {
                    gameObject = gameObject.AddOrUpdateComponent(
                        randomizer.FileRepository.TypeRepository.Create("chainsaw.ObjectHide")
                            .Set("Enabled", true)
                            .Set("Settings", new[]
                            {
                                new RuleStratum.StratumBool()
                                {
                                    _Enable = new RuleStratum.Rule()
                                    {
                                        Logic = 0,
                                        Matters =
                                        [
                                            new()
                                            {
                                                _Data = new RuleStratum.ParticleFlag()
                                                {
                                                    Flags = new chainsaw.FlagCondition()
                                                    {
                                                        _Logic = 0,
                                                        _CheckFlags =
                                                        [
                                                            new chainsaw.CheckFlagInfo()
                                                            {
                                                                _CheckFlag = item.Condition,
                                                                _CompareValue = false
                                                            }
                                                        ]
                                                    }
                                                }
                                            }
                                        ]
                                    },
                                    Value = true
                                }
                            }));
                }

                area.Scene = area.Scene.UpdateGameObject(gameObject);
            }
        }

        private static void UpdateModels(Area area, Dictionary<ContextID, Item> placements) {
            area.Scene = area.Scene.VisitGameObjects(go => {
                var itemDrop = go.FindComponent("chainsaw.DropItem");
                if (itemDrop != null) {
                    var contextId = itemDrop.Get<ContextID>("_ID");
                    if (placements.TryGetValue(contextId, out var item)) {
                        go = go.AddOrUpdateComponent(itemDrop
                            .Set("_ItemData.ItemID", item.Id)
                            .Set("_ItemData.Count", item.Count)
                            .Set("_ItemData.AmmoItemID", 0)
                            .Set("_ItemData.AmmoCount", item.Count));
                    }
                }
                return go;
            });
        }

        private static Dictionary<ContextID, Item> Randomize(RE7Randomizer randomizer, IEnumerable<ItemPlacement> placements, RandomizerLogger logger) {
            var result = new Dictionary<ContextID, Item>();
            var randomItemSettings = new RandomItemSettings {
                ItemRatioKeyFunc = (dropKind) => randomizer.GetConfigOption<double>($"item-drop-ratio-{dropKind}"),
                MinAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-min", 0.1),
                MaxAmmoQuantity = randomizer.GetConfigOption("item-drop-ammo-max", 1.0),
                MinMoneyQuantity = randomizer.GetConfigOption("item-drop-money-min", 100),
                MaxMoneyQuantity = randomizer.GetConfigOption("item-drop-money-max", 1000),
            };
            var ammoOnlyAvailableWeapons = randomizer.GetConfigOption("item-drop-ammo-only-available-weapons", true);

            logger.Push($"Randomizing items");

            var itemRandomizer = randomizer.ItemRandomizer;
            foreach (var kvp in placements.GroupBy(x => x.Chapter).OrderBy(x => x.Key)) {
                var chapter = kvp.Key;
                var chapterItems = kvp.ToHashSet();

                logger.Push($"Chapter {chapter}");

                // General items
                var rng = randomizer.GetRng("modifier/dropitem");
                logger.Push("General");
                var generalItems = chapterItems.Shuffle(rng).ToQueue();
                while (generalItems.TryDequeue(out var placement)) {
                    if (ammoOnlyAvailableWeapons) {
                        randomItemSettings.ValidateDropKind = (drop) => {
                            var ammoType = DropKinds.GetAmmoType(drop);
                            return ammoType == null;
                        };
                    }
                    var randomItem = itemRandomizer.GetNextGeneralDrop(rng, randomItemSettings);
                    if (randomItem is Item newItem) {
                        result[placement.ContextId] = newItem;
                        LogItemChange(placement, newItem);
                    }
                }
                logger.Pop();
                logger.Pop();
            }

            logger.Pop();
            return result;

            void LogItemChange(ItemPlacement placement, Item item) {
                logger.LogLine($"{placement.GuidOrAuto} becomes {item}");
            }
        }

        private static bool CanChangeItem(RE7Randomizer randomizer, ItemPlacement placement) {
            var oldItemDefinition = ItemDefinitionRepository.Default.Find(placement.OldItem.Id);
            if (oldItemDefinition != null && oldItemDefinition.Kind == ItemKinds.Key) {
                if (!placement.Tags.Contains(ItemTags.ChangeKey)) {
                    return false;
                }
            }

            if (placement.Tags.Contains(ItemTags.Preserve))
                return false;

            return true;
        }

        private static ItemPlacement? TakeRandomHighValueItem(List<ItemPlacement> items, Rng rng) {
            if (items.Count == 0)
                return null;

            var index = -1;
            var valuableOrder = new[] { "boss", "multikey", "bawk", "ashley", "smallkey", "long", "key", "display", "chest" };
            foreach (var v in valuableOrder) {
                if (v == "boss" || rng.NextProbability(75)) {
                    index = items.FindIndex(x => x.Container == v);
                    if (index != -1)
                        break;
                }
            }

            if (index == -1)
                index = rng.Next(0, items.Count);

            var result = items[index];
            items.RemoveAt(index);
            return result;
        }

        private class ItemPlacementThing {
            public required ItemPlacement Placement { get; init; }
            public required ImmutableArray<RszGameObject> GameObjects { get; init; }
            public required ImmutableArray<DropItemSaveDataTable.Data> Data { get; init; }
        }
    }
}
