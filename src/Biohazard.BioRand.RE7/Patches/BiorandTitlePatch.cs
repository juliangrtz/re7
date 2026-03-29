using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.REE.Messages;

namespace Biohazard.BioRand.RE7.Patches;

internal class BiorandTitlePatch(IPatchContext context) : IPatch
{
    private readonly Guid NewGameTextGuid = new Guid("07d3faa6-af33-4452-b570-d607c1bc1d9c");

    public void Apply()
    {
        if (!context.GetConfigOption<bool>("main-menu-biorand-touch"))
            return;

        context.ApplyOverlay(context.GetSupplementFile("biorand_title.zip")!);

        var languagesWithEnglishText = new List<LanguageId>() {
                LanguageId.English,
                LanguageId.Japanese,
                LanguageId.Russian,
                LanguageId.Polish,
                LanguageId.Korean,
                LanguageId.Arabic,
                LanguageId.TransitionalChinese,
                LanguageId.SimplelifiedChinese,
                LanguageId.Thai
        };

        context.ModifyMsgFile(PakPath.MessageFile("message/ui_menu_mes.msg"), message =>
        {
            languagesWithEnglishText.ForEach(lang =>
            {
                message.SetString(NewGameTextGuid, lang, "NEW BIORAND7 GAME");
            });

            message.SetString(NewGameTextGuid, LanguageId.German, "NEUES BIORAND7 SPIEL");
            message.SetString(NewGameTextGuid, LanguageId.Spanish, "NUEVA BIORAND7 PARTIDA");
            message.SetString(NewGameTextGuid, LanguageId.PortugueseBr, "NOVO BIORAND7 JOGO");
            // In French the text would become too long :(
        });
    }
}
