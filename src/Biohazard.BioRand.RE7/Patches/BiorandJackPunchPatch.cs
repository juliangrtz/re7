namespace Biohazard.BioRand.RE7.Patches;

internal class BiorandJackPunchPatch(IPatchContext context) : IPatch
{
    public void Apply() 
        => context.ApplyOverlay(context.GetSupplementFile("biorand_jackpunch.zip")!);
}
