namespace Biohazard.BioRand.RE7;

public interface IProgressReporter
{
    public void RunTask(string text, Action cb);
}