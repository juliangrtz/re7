using System;

namespace Biohazard.BioRand.RE7.Extensions
{
    public static class EnumExtensions
    {
        public static TEnum? ParseOrNull<TEnum>(string value) where TEnum : struct, Enum
        {
            try
            {
                return Enum.Parse<TEnum>(value);
            }
            catch
            {
                return null;
            }
        }
    }
}