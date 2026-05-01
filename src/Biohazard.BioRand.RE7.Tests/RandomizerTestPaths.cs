using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Tests;

internal static class RandomizerTestPaths
{
    public static readonly string EthanInventoryPath = PakPath.UserFile("leveldesign/fsm/chapter1/other/ch1_startinventory.user");
    public static readonly string ClancyInventoryPath = PakPath.UserFile("leveldesign/fsm/ff000/other/startinventory_ff000.user");
    public static readonly string MiaInventoryPath = PakPath.UserFile("leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user");
    public static readonly string MiaVhsInventoryPath = PakPath.UserFile("leveldesign/fsm/ff050/other/ff050_startinventory.user");
    public static readonly string ReloadSpeedTablePath = PakPath.UserFile("prefab/character/pl0000/pl0000reloadspeedratetable.user");
    public static readonly string KeyItemSettingsPath = PakPath.UserFile("prefab/item/keyitemsettings.user");
    public static readonly string ItemResourcesScenePath = PakPath.SceneFile("scenes/items/itemresources.scn");
    public static readonly string UiItemMessagePath = PakPath.MessageFile("message/ui_item_mes.msg");
    public static readonly string ChapterJumpScenePath = PakPath.SceneFile("scenes/chapterjumpdata/chapterjumpdata.scn");
    public static readonly string Chapter4DropTablePath = PakPath.UserFile("prefab/item/reliefitemtable_04_01_0000.user");
    public static readonly string ItemCombineDataPath = PakPath.UserFile("prefab/item/itemcombinedata.user");
    public static readonly string DictionaryCombineDataPath = PakPath.UserFile("prefab/item/dictionarycombinedata.user");
    public static readonly string BirdCageScenePath = PakPath.SceneFile("environment/scene/chapter3/c03_trailerhouse.scn");
    public static readonly string GlobalVariablesPath = $"{PakPath.Of("userdata/globalvariables.uvar")}.{FileVersions.UvarFileVersion}";
    public static readonly Guid GuestHouseJumpGuid = new("88045366-0683-481a-8b9a-1d8c59aa048a");
}
