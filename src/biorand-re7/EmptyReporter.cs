using IntelOrca.Biohazard.BioRand;

namespace Biohazard.BioRand.RE7;

public class EmptyReporter : IRandomizerProgress {
    public void RunTask(string text, Action cb) {
        cb();
    }
}