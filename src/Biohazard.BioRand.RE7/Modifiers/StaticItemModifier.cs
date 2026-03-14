using Biohazard.BioRand.RE7.Items;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class StaticItemModifier : Modifier
{
    private const string RandomizerKey = "modifier/static-items";
    private readonly static ItemPlacementRepository _itemPlacements = ItemPlacementRepository.Default;
    private readonly static ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    private readonly static List<string> _itemExclusions = [
        "Handgun_Albert_Reward", // Albert 01-R
        "Coin", // Antique Coin --> TODO Add config option
        "RepairKit", // Repair Kit
    ];

    // (itemID, amount)
    // TODO
    // Keep in mind that random weapons need a different app.WeaponGun component!
    private (string, int) GetRandomItem(ItemDefinition item, Randomizer randomizer, Rng rng)
    {
        switch (item.CategoryType)
        {
            case Enums.app.Item.ItemCategoryType.OtherItem:
                break;
            case Enums.app.Item.ItemCategoryType.Weapon:
                break;
            case Enums.app.Item.ItemCategoryType.Shell:
                break;
            case Enums.app.Item.ItemCategoryType.Drug:
                break;
            case Enums.app.Item.ItemCategoryType.KeyItem:
                break;
            case Enums.app.Item.ItemCategoryType.File:
                break;
            case Enums.app.Item.ItemCategoryType.Map:
                break;
            case Enums.app.Item.ItemCategoryType.Material:
                break;
            case Enums.app.Item.ItemCategoryType.StackWeapon:
                break;
            case Enums.app.Item.ItemCategoryType.UsableKeyItem:
                break;
            case Enums.app.Item.ItemCategoryType.DiscardableKeyItem:
                break;
            case Enums.app.Item.ItemCategoryType.SupplyBox:
                break;
            case Enums.app.Item.ItemCategoryType.Max:
                break;
        }

        return ("", 0);
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        return;
        var rng = randomizer.GetRng(RandomizerKey);

        // TODO: Filter bird cage items
        // TODO: Add option for tapes
        var randomizableItems = _itemPlacements.PlacementToItemMap
                                    .Where(x => x.Value != null)
                                    .Where(x => !x.Value.IsStoryProgressionItem)
                                    .Where(x => !x.Value.IsDlcItem)
                                    .Where(x => !_itemExclusions.Contains(x.Key.Id))
                                    .ToList();

        foreach (var (placement, definition) in randomizableItems)
        {
            if(placement == null || definition == null)
            {
                continue;
            }

            randomizer.FileRepository.ModifyScnFile(placement.Container, scene =>
            {
                var gameObject = scene.FindGameObject(placement.Guid)!;
                var itemComponent = gameObject.FindComponent<app.Item>()!;
                if(!itemComponent.Enabled)
                {
                    logger.LogLine($"[!] Enabling disabled item {definition.Name} in scene {placement.Container} (GUID: {placement.Guid})");
                    itemComponent.Enabled = true;
                }

                var (id, stack) = GetRandomItem(definition, randomizer, rng);
                itemComponent.ItemDataID = id;
                itemComponent.ItemStackNum = stack;
                
                // TODO: Handle itemComponent._DifficultItemNumSetting

                gameObject = gameObject.AddOrUpdateComponent(itemComponent);
                scene = scene.UpdateGameObject(gameObject);
                return scene;
            });
        }

        ;

        // Debugging test: Change Axe to ChainSaw
        //var axe = _itemPlacements.Single(item => item.Id == "HandAxe");
        //randomizer.FileRepository.ModifyScnFile(axe.Container, scene =>
        //{
        //    var gameObject = scene.FindGameObject(axe.Guid)!;
        //    var itemComponent = gameObject.FindComponent<app.Item>()!;
        //    itemComponent.ItemDataID = "HandAxe";
        //    gameObject = gameObject.AddOrUpdateComponent(itemComponent);
        //    scene = scene.UpdateGameObject(gameObject);
        //    return scene;
        //});


    }
}