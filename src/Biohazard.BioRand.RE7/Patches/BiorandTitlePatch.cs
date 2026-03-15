namespace Biohazard.BioRand.RE7.Patches;

internal class BiorandTitlePatch(IPatchContext context) : IPatch
{
    public void Apply()
    {
        context.ApplyOverlay(context.GetSupplementFile("biorand_title.zip")!);
        // TODO: Mod "New Game" and "Continue" texts
    }
}
