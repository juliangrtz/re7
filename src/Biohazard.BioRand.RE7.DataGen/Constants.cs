using IntelOrca.Biohazard.REE.Package;

namespace Biohazard.BioRand.RE7.DataGen;

internal class Constants
{
    public static PakFile BioRandPakFile = new(BioRandPakFilePath);
    public static string BioRandPakFilePath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        ".biorand",
        "biorand-re7.pak"
    );
}
