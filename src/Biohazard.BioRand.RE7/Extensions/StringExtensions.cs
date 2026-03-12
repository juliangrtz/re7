using System.Globalization;
using System.Security.Cryptography;

namespace Biohazard.BioRand.RE7.Extensions;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
    }

    public static string ReplaceLastOccurrence(this string source, string find, string replace)
    {
        int place = source.LastIndexOf(find);

        if (place == -1)
            return source;

        return source.Remove(place, find.Length).Insert(place, replace);
    }

    public static string SubstringBefore(this string text, string stopAt)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(stopAt))
            return text;

        int index = text.IndexOf(stopAt, StringComparison.Ordinal);

        if (index >= 0)
            return text[..index];

        return text;
    }

    public static string SubstringAfter(this string text, string startAt)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(startAt))
            return text;

        int index = text.IndexOf(startAt, StringComparison.Ordinal);

        if (index >= 0)
            return text[(index + startAt.Length)..];

        return text;
    }

    public static Guid GetGuidHash(this string s)
    {
        var hash = MD5.HashData(Encoding.ASCII.GetBytes(s));
        hash[8] = (byte)(0x40 | (hash[8] & 0x0F));
        return new Guid(hash);
    }

    public static string RemoveControlCharacters(this string message)
        => new([.. message.Where(c => !char.IsControl(c))]);

    public static string Without(this string str, string toBeRemoved)
        => str.Replace(toBeRemoved, "");
}
