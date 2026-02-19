#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // These words must begin with upper case characters
#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace app
{
    internal class DictionaryCombineData {
        public System.Collections.Generic.List<Data> _Datas { get; set; } = [];

        internal class Data {
            public string ItemDataID { get; set; } = "";
        }
    }

    internal class ItemCombineData
    {
        public System.Collections.Generic.List<Data> _Datas { get; set; } = [];

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
