namespace Biohazard.BioRand.RE7.Extensions;

public static class EnumExtensions
{
    public static TEnum? ParseOrNull<TEnum>(string value) where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(value, ignoreCase: true, out var result))
        {
            return result;
        }

        return null;
    }
}