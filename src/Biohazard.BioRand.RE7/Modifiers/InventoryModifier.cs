using app;
using Biohazard.BioRand.RE7.Inventory;
using Biohazard.BioRand.RE7.Items;
using Enums.app;
using Enums.app.Inventory;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class InventoryModifier : Modifier
{
    private const string RandomizerKey = "modifier/inventory";

    private readonly Dictionary<MainCampaignCharacter, string> _paths = new()
    {
        { MainCampaignCharacter.Ethan, PakPath.Of("leveldesign/fsm/chapter1/other/ch1_startinventory.user.2") },
        { MainCampaignCharacter.ClancyVHS, PakPath.Of("leveldesign/fsm/ff000/other/startinventory_ff000.user.2") }, // "Derelict House Footage" (Guest House)
        { MainCampaignCharacter.Mia, PakPath.Of("leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user.2") },
        { MainCampaignCharacter.MiaVHS,  PakPath.Of("leveldesign/fsm/ff050/other/ff050_startinventory.user.2") }, // Old Videotape (Ship)
    };

    private static readonly ItemDefinitionRepository itemDefinitions = ItemDefinitionRepository.Default;

    private List<StartingInventoryItem> GetInventory(RE7Randomizer randomizer, MainCampaignCharacter character)
        => randomizer.FileRepository.DeserializeUserFile<app.AddItemListData>(_paths[character])._AddItems;

    private static void LogVanillaInventory(RandomizerLogger logger, MainCampaignCharacter character, List<StartingInventoryItem> items)
    {
        logger.Push($"{character}'s starting inventory");

        foreach (var item in items)
            logger.LogLine(itemDefinitions.FromId(item.ItemDataID)!.Name!);

        logger.Pop();
    }

    public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            LogVanillaInventory(logger, character, GetInventory(randomizer, character));
        }
    }

    private void RandomizeInventory(
        RE7Randomizer randomizer,
        RandomizerLogger logger,
        MainCampaignCharacter character,
        List<StartingWeaponCategory> weapons
    )
    {
        if (character == MainCampaignCharacter.ClancyVHS)
        {
            // There are no options for Clancy's starting inventory as the section is pretty much an interactive cutscene.
            // For the memes we are "randomizing" his inventory anyways ;)
            randomizer.FileRepository.ModifyUserFile<AddItemListData>(_paths[character], root =>
            {
                root._AddItems.Add(new() { ItemDataID = ItemID.Handgun_Albert.ToString(), Num = 1 });
                root._AddItems.Add(new() { ItemDataID = "UnlimitedAmmo", Num = 1 });
                return root;
            });

            return;
        }
        else if (character == MainCampaignCharacter.Ethan)
        {
        }
        else if (character.ToString().StartsWith("Mia", StringComparison.InvariantCultureIgnoreCase))
        {
        }
        else
        {
            logger.LogLine($"Unknown character '{character}'!");
        }
    }

    private ExtendLvDef? ToExtendLvDef(string str, Rng rng) => str switch
    {
        "random" => rng.Next(Enum.GetValues<ExtendLvDef>()),
        "8" => null,
        "12" => ExtendLvDef.Lv1,
        "16" => ExtendLvDef.Lv2,
        "20" => ExtendLvDef.Lv3,
        _ => throw new ArgumentException($"Invalid size '{str}' specified")
    };

    private void SetInventorySizes(
        RE7Randomizer randomizer,
        Rng rng,
        string ethanInventorySize,
        string miaInventorySize
    )
    {
        var ethanExtendLv = ToExtendLvDef(ethanInventorySize, rng);
        if (ethanExtendLv != null)
        {
            randomizer.FileRepository.ModifyScnFile(PakPath.Of("leveldesign/fsm/chapter1/c01_tutorial.scn.20"), scene =>
            {
                var tutorialWalkGuid = new Guid("305daaa1-c01e-4bc5-88f2-e37e4e44d356");
                var tutorialWalkGameObject = scene.FindGameObject(tutorialWalkGuid)!;
                var fsm = tutorialWalkGameObject.FindComponent<via.fsm.Fsm>();
                // TODO: Edit fsm
                return scene;
            });
        }

        var miaExtendLv = ToExtendLvDef(miaInventorySize, rng);
        if (miaExtendLv != null)
        {
            // Wake up in front of ship
            randomizer.FileRepository.ModifyScnFile(PakPath.Of("leveldesign/fsm/chapter4/c04_tutorial.scn.20"), scene =>
            {
                return scene;
            });

            // VHS
            randomizer.FileRepository.ModifyScnFile(PakPath.Of("leveldesign/fsm/ff050/ff050_tutorial.scn.20"), scene =>
            {
                return scene;
            });
        }
    }

    public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
    {
        var randomizeEthanInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-ethan");
        var randomizeMiaInventory = randomizer.GetConfigOption<bool>("random-starting-inventory-mia");

        if (!randomizeEthanInventory && !randomizeMiaInventory)
        {
            return;
        }

        var rng = randomizer.GetRng(RandomizerKey);
        var ethanInventorySize = randomizer.GetConfigOption("random-starting-inventory-size-ethan", "8")!;
        var miaInventorySize = randomizer.GetConfigOption("random-starting-inventory-size-mia", "8")!;
        SetInventorySizes(randomizer, rng, ethanInventorySize, miaInventorySize);

        //var characterToWeaponMap = new Dictionary<MainCampaignCharacter, List<StartingWeaponCategory>>();
        var categories = Enum.GetValues<StartingWeaponCategory>();

        foreach (var character in Enum.GetValues<MainCampaignCharacter>())
        {
            var list = new List<StartingWeaponCategory>();
            foreach (var category in categories)
            {
                if (randomizer.GetConfigOption<bool>(
                    $"inventory-weapon-{category.ToString().ToLowerInvariant()}-{character.ToString().ToLowerInvariant()}")
                )
                {
                    list.Add(category);
                }
            }

            //characterToWeaponMap.Add(character, list);
            RandomizeInventory(randomizer, logger, character, list);
        }
    }
}