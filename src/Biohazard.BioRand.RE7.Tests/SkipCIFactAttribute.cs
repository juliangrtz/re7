namespace Biohazard.BioRand.RE7.Tests;

public class SkipCIFactAttribute : FactAttribute
{
    private const string CIEnvVariable = "GITHUB_ACTIONS";

    public SkipCIFactAttribute()
    {
        if (IsRunningInGitHubActions())
        {
            Skip = "Test skipped because it is running in GitHub Actions. Please run the test locally.";
        }
    }

    private static bool IsRunningInGitHubActions() =>
        Environment.GetEnvironmentVariable(CIEnvVariable) != null;
}