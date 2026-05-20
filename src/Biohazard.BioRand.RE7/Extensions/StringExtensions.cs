using System.Globalization;
using System.Security.Cryptography;

namespace Biohazard.BioRand.RE7.Extensions;

public static class StringExtensions {
    extension(string str) {
        public string ToTitleCase() {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        public string ReplaceLastOccurrence(string find, string replace) {
            int place = str.LastIndexOf(find);

            if (place == -1)
                return str;

            return str.Remove(place, find.Length).Insert(place, replace);
        }

        public string SubstringBefore(string stopAt) {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(stopAt))
                return str;

            int index = str.IndexOf(stopAt, StringComparison.Ordinal);

            if (index >= 0)
                return str[..index];

            return str;
        }

        public string SubstringAfter(string startAt) {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(startAt))
                return str;

            int index = str.IndexOf(startAt, StringComparison.Ordinal);

            if (index >= 0)
                return str[(index + startAt.Length)..];

            return str;
        }

        public Guid GetGuidHash() {
            var hash = MD5.HashData(Encoding.ASCII.GetBytes(str));
            hash[8] = (byte)(0x40 | (hash[8] & 0x0F));
            return new Guid(hash);
        }

        public string RemoveControlCharacters()
            => new([.. str.Where(c => !char.IsControl(c))]);

        public string Without(string toBeRemoved)
            => str.Replace(toBeRemoved, "");

        public string Truncate(int length, bool ellipsis = true) {
            if (!string.IsNullOrEmpty(str)) {
                str = str.Trim();
                if (str.Length > length) {
                    if (ellipsis) {
                        return str.Substring(0, length) + "...";
                    }

                    return str.Substring(0, length);
                }
            }

            return str ?? string.Empty;
        }
    }
}