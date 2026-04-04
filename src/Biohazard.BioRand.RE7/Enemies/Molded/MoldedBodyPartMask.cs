using static app.EnemySpawnInfo.BackupParameter;

namespace Biohazard.BioRand.RE7.Enemies.Molded;

[Flags]
public enum MoldedBodyPartMask
{
    None = 0,
    LeftArm = 1 << 0,
    RightArm = 1 << 1,
    LeftLeg = 1 << 2,
    RightLeg = 1 << 3
}

public static class MoldedBodyPartHelper
{
    public static MoldedBodyPartMask ToMask(
        bool isLostLeftArm,
        bool isLostRightArm,
        bool isLostLeftLeg,
        bool isLostRightLeg)
    {
        var mask = MoldedBodyPartMask.None;

        if (isLostLeftArm) mask |= MoldedBodyPartMask.LeftArm;
        if (isLostRightArm) mask |= MoldedBodyPartMask.RightArm;
        if (isLostLeftLeg) mask |= MoldedBodyPartMask.LeftLeg;
        if (isLostRightLeg) mask |= MoldedBodyPartMask.RightLeg;

        return mask;
    }

    public static MoldedBodyPartMask FromMoldedCommon(MoldedCommon common)
    {
        if (common == null) return MoldedBodyPartMask.None;

        return ToMask(
            common.IsLostLeftArm,
            common.IsLostRightArm,
            common.IsLostLeftLeg,
            common.IsLostRightLeg
        );
    }

    public static void UpdateMoldedCommon(MoldedBodyPartMask mask, MoldedCommon common)
    {
        if (common == null) return;

        common.IsLostLeftArm = mask.HasFlag(MoldedBodyPartMask.LeftArm);
        common.IsLostRightArm = mask.HasFlag(MoldedBodyPartMask.RightArm);
        common.IsLostLeftLeg = mask.HasFlag(MoldedBodyPartMask.LeftLeg);
        common.IsLostRightLeg = mask.HasFlag(MoldedBodyPartMask.RightLeg);
    }

    public static MoldedBodyPartMask ToMask(this MoldedCommon common)
    {
        return FromMoldedCommon(common);
    }

    public static MoldedCommon ToMoldedCommon(this MoldedBodyPartMask mask)
    {
        return new MoldedCommon
        {
            IsLostLeftArm = mask.HasFlag(MoldedBodyPartMask.LeftArm),
            IsLostRightArm = mask.HasFlag(MoldedBodyPartMask.RightArm),
            IsLostLeftLeg = mask.HasFlag(MoldedBodyPartMask.LeftLeg),
            IsLostRightLeg = mask.HasFlag(MoldedBodyPartMask.RightLeg)
        };
    }
}