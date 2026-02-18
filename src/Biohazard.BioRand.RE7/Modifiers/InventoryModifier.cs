using Biohazard.BioRand.RE7.Items;
using IntelOrca.Biohazard.BioRand;
using System.Linq;

namespace Biohazard.BioRand.RE7.Modifiers {
    internal class InventoryModifier : Modifier {
        private RE7PlayerInventory? _inventory;

        public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger) {
            _inventory ??= RE7PlayerInventory.FromData(randomizer.FileRepository, randomizer.Campaign);
            var inventory = _inventory;

            logger.LogLine($"PTAS = {inventory.PTAS}");
            logger.LogLine($"Spinels = {inventory.SpinelCount}");

            var itemsById = inventory.PlayerData.InventoryData.InventoryItems
                .GroupBy(x => x.Item._ItemId)
                .OrderBy(x => x.Key)
                .ToArray();
            foreach (var itemGroup in itemsById) {
                var item = itemGroup.First();
                var count = itemGroup.Sum(x => x.Item._CurrentItemCount);
                var itemName = ItemDefinitionRepository.Default.GetName(item.Item._ItemId);
                logger.LogLine($"{itemName} {count}");
            }
        }

        public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger) {
            _inventory ??= RE7PlayerInventory.FromData(randomizer.FileRepository, randomizer.Campaign);
            var inventory = _inventory;

            var itemRandomizer = randomizer.ItemRandomizer;
            if (!randomizer.GetConfigOption<bool>("random-inventory")) {
                itemRandomizer.MarkItemPlaced(ItemIds.SG09R);
                itemRandomizer.MarkItemPlaced(ItemIds.CombatKnife);
                return;
            }

            var itemData = RE7ItemData.FromRandomizer(randomizer);
            var rng = randomizer.GetRng("modifier/inventory");

            inventory.PTAS = rng.Next(0, 200) * 100;
            inventory.SpinelCount = rng.Next(0, 5);
            inventory.ClearItems();

            // Weapons
            AddRandomStuff(randomizer, inventory, rng);
            inventory.UpdateWeapons(itemData);
            inventory.AutoSort(itemData);
            inventory.AssignShortcuts();
            inventory.Save(randomizer.FileRepository);

            foreach (var item in inventory.PlayerData.InventoryData.InventoryItems) {
                var size = itemData.GetSize(item.Item._ItemId);
                var width = size.Width;
                var height = size.Height;
                if (item.CurrDirection != 0) {
                    (width, height) = (height, width);
                }
                logger.LogLine($"Add item {item.Item} ({item.STRUCT_SlotIndex_Column}, {item.STRUCT_SlotIndex_Row}) ({width}x{height}) Rotation = {item.CurrDirection}");
            }
        }

        private void AddRandomStuff(RE7Randomizer randomizer, RE7PlayerInventory inventory, Rng rng, int count = 10) {
            var randomKinds = new[] {
                ItemKinds.Fish,
                ItemKinds.Fish,
                ItemKinds.Viper,
                ItemKinds.Viper,
                ItemKinds.Health,
                ItemKinds.Health,
                ItemKinds.Egg,
                ItemKinds.Egg,
                ItemKinds.Grenade,
                ItemKinds.Grenade,
                ItemKinds.Knife,
                ItemKinds.Knife,
                ItemKinds.Gunpowder,
                ItemKinds.Gunpowder,
                ItemKinds.Resource,
                ItemKinds.Resource
            };

            var itemRandomizer = randomizer.ItemRandomizer;
            var bag = new EndlessBag<string>(rng, randomKinds);
            for (var i = 0; i < count; i++) {
                var kind = bag.Next();
                var randomItem = itemRandomizer.GetRandomItemDefinition(rng, kind);
                if (randomItem != null)
                    inventory.AddItem(new Item(randomItem.Id, -1));
            }
        }
    }
}
