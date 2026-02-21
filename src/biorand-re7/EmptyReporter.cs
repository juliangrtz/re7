using Biohazard.BioRand.RE7;

namespace BioHazard.BioRand.RE7;

public class EmptyReporter : IProgressReporter
{
    public void RunTask(string text, Action cb)
    {
        cb();
    }
}