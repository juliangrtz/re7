namespace Biohazard.BioRand.RE7.Patches;

internal class JacksWelcomeToBioRandSevenSonAtticPunchPatch(IPatchContext context) : IPatch {
    public void Apply()
        => context.ApplyOverlay(context.GetSupplementFile("biorand_jack_attic_punch.zip")!);
}

// ReSharper disable once InconsistentNaming
internal class uhTranceYeetusPaintingPatch(IPatchContext context) : IPatch {
    public void Apply() {
        if (!string.Equals(context.GetConfigOption<string>("username"), "uhTrance",
                StringComparison.InvariantCultureIgnoreCase))
            return;

        context.ApplyOverlay(context.GetSupplementFile("trance_painting.zip")!);
    }
}