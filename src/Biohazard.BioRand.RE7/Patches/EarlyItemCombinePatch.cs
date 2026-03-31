using Biohazard.BioRand.RE7.Serialization;

namespace Biohazard.BioRand.RE7.Patches;

internal class EarlyItemCombinePatch(IPatchContext context) : IPatch
{
    const string GlobalVariablesPath = "natives/stm/userdata/globalvariables.uvar.2";

    public void Apply()
    {
        if (!context.GetConfigOption<bool>("recipes-unlock-from-start"))
            return;

        var patchedGlobalVars = EmbeddedData.GetFile("globalvariables.uvar.2");
        context.SetFile(GlobalVariablesPath, patchedGlobalVars);

        // TODO: Use FlagService instead
    }
}
