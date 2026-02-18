#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace app
{
    internal class ItemCombineData
    {
        public System.Collections.Generic.List<app.ItemCombineData.Data> _Datas { get; set; } = [];

        internal class Data
        {
            public string _Comment { get; set; } = "";
            public string DataID { get; set; } = "";
            public string SrcItemID1 { get; set; } = "";
            public int SrcItemNum1 { get; set; }
            public string SrcItemID2 { get; set; } = "";
            public int SrcItemNum2 { get; set; }
            public string ResultItemID { get; set; } = "";
            public int ResultItemNum { get; set; }
            public System.Guid EnableFlag { get; set; }
            public bool IsTrophyTarget { get; set; }
            public bool IsTutorialTarget { get; set; }
        }
    }
}
