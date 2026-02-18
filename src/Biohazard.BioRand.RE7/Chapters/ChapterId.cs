using Biohazard.BioRand.RE7.Chapters;
using System;

namespace Biohazard.BioRand.RE7.Chapters {
    internal static class ChapterId {
        private static readonly int[] _ethan =
        [
            21000, // 0
            21100, // 1
            21200, // 2
            21300, // 3
            22100, // 4
            22200, // 5
            22300, // 6
            23100, // 7
            23200, // 8
            23300, // 9
            24100, // 10
            24200, // 11
            24300, // 12
            25100, // 13
            25200, // 14
            25300, // 15
            25400  // 16
        ];

        private static readonly int[] _mia =
        [
            30000, // 0
            30100, // 1
            31100, // 2
            32100, // 3
            33100, // 4
            33200, // 5
            34100, // 6
            35100, // 7
        ];

        private static int[] GetArray(Campaign campaign) => campaign == Campaign.Ethan ? _ethan : _mia;

        public static int GetCount(Campaign campaign) => campaign == Campaign.Ethan ? 16 : 7;

        public static int[] GetAll(Campaign campaign) => GetArray(campaign);

        public static int FromNumber(Campaign campaign, int chapterNumber) {
            var arr = GetArray(campaign);
            return arr[chapterNumber];
        }

        public static int FromId(int id) {
            foreach (var arr in new[] { GetArray(Campaign.Ethan), GetArray(Campaign.Mia) }) {
                var index = Array.IndexOf(arr, id);
                if (index != -1) {
                    return index;
                }
            }
            throw new ArgumentException("Id does not exist", nameof(id));
        }
    }
}