using Biohazard.BioRand.RE7.Items;
using Enums.app.GameManager;

namespace Biohazard.BioRand.RE7.Extensions;

public static class Re7TypeExtensions
{
    private static readonly ItemDefinitionRepository _itemDefinitions = ItemDefinitionRepository.Default;

    public static string Format(this Recipe recipe)
    {
        var readableSrc1 = _itemDefinitions.FromId(recipe.SrcItemID1)?.Name ?? recipe.SrcItemID1;
        var readableSrc2 = _itemDefinitions.FromId(recipe.SrcItemID2)?.Name ?? recipe.SrcItemID2;
        var readableResult = _itemDefinitions.FromId(recipe.ResultItemID)?.Name ?? recipe.ResultItemID;

        return $"{recipe.SrcItemNum1,3}x {readableSrc1,-30} + " +
            $"{recipe.SrcItemNum2,3}x {readableSrc2,-30} -> " +
            $"{recipe.ResultItemNum,3}x {readableResult,-30}";
    }

    public static void Log(this ItemDropTable table, RandomizerLogger logger)
    {
        foreach (var item in table.DataList)
        {
            var name = _itemDefinitions.FromId(item.ItemID)?.Name ?? item.ItemID;
            logger.Push(name);
            logger.LogLine($"Easy drop rate: {item.EasyDropRate} %");
            logger.LogLine($"Normal drop rate: {item.NormalDropRate} %");
            logger.LogLine($"Madhouse drop rate: {item.HardDropRate} %");
            logger.LogLine($"Easy drop amount: {item.ReliefNum}");
            logger.LogLine($"Normal drop amount: {item.NormalDropNum}");
            logger.LogLine($"Madhouse drop amount: {item.ReliefDropNum}");
            logger.Pop();
        }
    }

    public static string ToReadableString(this ChapterNo chapter) => chapter switch
    {
        ChapterNo.BootLogo => "Boot Logo",
        ChapterNo.FirstMenu => "Main Menu",
        ChapterNo.Title => "Title Screen",
        ChapterNo.Chapter1 => "Ethan's arrival",
        ChapterNo.Chapter3 => "Ethan at dinner table",
        ChapterNo.Chapter4 => "Ship",
        ChapterNo.FF000 => "Found Footage: Derelict House Footage",
        ChapterNo.FF030 => "Found Footage: Mia",
        ChapterNo.FF040 => "Found Footage: Happy Birthday",
        ChapterNo.FF050 => "Found Footage: Old Videotape",
        ChapterNo.Chapter123 => "Chapters 1, 2 and 3",
        ChapterNo.Chapter324 => "Chapters 3, 2 and 4",
        ChapterNo.OpeningMovie => "Opening (driving cutscene)",
        ChapterNo.OpeningCar => "Opening (car)",
        ChapterNo.EndingMovie => "Credits",
        ChapterNo.VRTutorial => "VR Tutorial",
        ChapterNo.NoChapter => "No chapter",
        ChapterNo.BirthdayMain => "Jack's 55th Birthday DLC Main Menu",
        ChapterNo.BirthdayTitle => "Jack's 55th Birthday DLC Stage Selection",
        ChapterNo.BirthdayStage1 => "Jack's 55th Birthday DLC Stage 1",
        ChapterNo.BirthdayStage2 => "Jack's 55th Birthday DLC Stage 2",
        ChapterNo.BirthdayStage3 => "Jack's 55th Birthday DLC Stage 3",
        ChapterNo.BirthdayStage4 => "Jack's 55th Birthday DLC Stage 4",
        ChapterNo.BirthdayResult => "Jack's 55th Birthday DLC Result Screen",
        ChapterNo.EndCard => "End Card",
        ChapterNo.Chapter7Title => "Banned Footage DLC Menu",
        ChapterNo.Chapter7_1 => "Bedroom DLC",
        ChapterNo.Chapter7_2 => "21 DLC",
        ChapterNo.Chapter7_3 => "Nightmare DLC",
        ChapterNo.Chapter7_4 => "Daughters DLC",
        ChapterNo.Chapter3_IMD_Title => "Ethan Must Die DLC Menu",
        ChapterNo.Chapter3_IMD => "Ethan Must Die DLC",
        ChapterNo.Chapter8 => "Not a Hero DLC",
        ChapterNo.Chapter7_Intro_Movie => "Banned Footage DLC Intro Movie",
        ChapterNo.Chapter9 => "End of Zoe DLC",
        _ => "Unused chapter"
    };
}
