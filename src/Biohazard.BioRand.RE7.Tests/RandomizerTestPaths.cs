using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Tests;

internal static class RandomizerTestPaths {
    public static readonly string EthanInventoryPath =
        "leveldesign/fsm/chapter1/other/ch1_startinventory.user".UserFile();

    public static readonly string ClancyInventoryPath =
        "leveldesign/fsm/ff000/other/startinventory_ff000.user".UserFile();

    public static readonly string MiaInventoryPath =
        "leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user".UserFile();

    public static readonly string MiaVhsInventoryPath =
        "leveldesign/fsm/ff050/other/ff050_startinventory.user".UserFile();

    public static readonly string ReloadSpeedTablePath =
        "prefab/character/pl0000/pl0000reloadspeedratetable.user".UserFile();

    public static readonly string PlayerMaxHealthTablePath =
        "prefab/character/pl0000/pl0000maxhealthtable.user".UserFile();

    public static readonly string SystemParameterDataPath =
        "prefab/system/systemparameterdata.user".UserFile();

    public static readonly string KeyItemSettingsPath = "prefab/item/keyitemsettings.user".UserFile();
    public static readonly string ResourceItemSettingsPath = "prefab/item/resourceitemsettings.user".UserFile();

    public static readonly string BirthdayResourceItemSettingsPath =
        "prefab/item/resourceitemsettings_birthday.user".UserFile();

    public static readonly string ItemResourcesScenePath = "scenes/items/itemresources.scn".SceneFile();
    public static readonly string UiItemMessagePath = "message/ui_item_mes.msg".MessageFile();

    public static readonly string ChapterJumpScenePath =
        "scenes/chapterjumpdata/chapterjumpdata.scn".SceneFile();

    public static readonly string Chapter4DropTablePath =
        "prefab/item/reliefitemtable_04_01_0000.user".UserFile();

    public static readonly string ItemCombineDataPath = "prefab/item/itemcombinedata.user".UserFile();

    public static readonly string DictionaryCombineDataPath =
        "prefab/item/dictionarycombinedata.user".UserFile();

    public static readonly string BirdCageScenePath =
        "environment/scene/chapter3/c03_trailerhouse.scn".SceneFile();

    public static readonly string GlobalVariablesPath =
        $"{"userdata/globalvariables.uvar".Of()}.{FileVersions.UvarFileVersion}";

    public static readonly Guid GuestHouseJumpGuid = new("88045366-0683-481a-8b9a-1d8c59aa048a");
}