namespace Biohazard.BioRand.RE7.DLC
{
    public enum DlcType
    {
        BeginningHourDemo,
        NotAHero,
        EndOfZoe,
        Nightmare,
        Bedroom,
        EthanMustDie,
        TwentyOne,
        Daughters,
        AttackCoinAndMadhouseUnlock,
        DefenseCoinAndMadhouseUnlock,
        UniversalCoinAndMadhouseUnlock,
        ReloadCoinAndMadhouseUnlock,
        InstinctCoinAndMadhouseUnlock,
    }

    public static class DlcTypeExtensions
    {
        public static bool IsBannedFootage1(this DlcType type) =>
            type is DlcType.Nightmare or
                DlcType.Bedroom or
                DlcType.EthanMustDie;

        public static bool IsBannedFootage2(this DlcType type) =>
             type is DlcType.TwentyOne or
                DlcType.Daughters;

        public static bool IsBannedFootage(this DlcType type)
        {
            return IsBannedFootage1(type) || IsBannedFootage2(type);
        }
    }
}
