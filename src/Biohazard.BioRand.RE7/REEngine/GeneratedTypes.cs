#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // These words must begin with upper case characters
#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable IDE0001 // Underscore as first character in properties

using System.Numerics;

namespace app
{
    public class DictionaryCombineData
    {
        public List<Data> _Datas { get; set; } = [];

        public class Data
        {
            public string ItemDataID { get; set; } = "";
        }
    }

    public class ItemCombineData
    {
        public List<Data> _Datas { get; set; } = [];

        public class Data
        {
            public string _Comment { get; set; } = "";
            public string DataID { get; set; } = "";
            public string SrcItemID1 { get; set; } = "";
            public int SrcItemNum1 { get; set; }
            public string SrcItemID2 { get; set; } = "";
            public int SrcItemNum2 { get; set; }
            public string ResultItemID { get; set; } = "";
            public int ResultItemNum { get; set; }
            public Guid EnableFlag { get; set; }
            public bool IsTrophyTarget { get; set; }
            public bool IsTutorialTarget { get; set; }
        }
    }

    public class Item
    {
        public bool Enabled { get; set; }
        public Guid SaveGUID { get; set; }
        public string ItemDataID { get; set; }
        public int ItemStackNum { get; set; }
        public int RoomId { get; set; }
        public bool _IsOverwriteDifficultItemNumSetting { get; set; }
        public DifficultItemNumRateData _DifficultItemNumSetting { get; set; }

        public class DifficultItemNumRateData
        {
            public int EasyNum { get; set; }
            public int HardNum { get; set; }
        }
    }

    public class ItemDropDestruct
    {
        public bool Enabled { get; set; }
        public string SetItemID { get; set; } = "";
        public int ChangeStackNum { get; set; }
        public bool UseDrawerPos { get; set; }
        public object DropItemInteract { get; set; }
        public Guid SaveGUID { get; set; }
    }

    public class ItemSettings
    {
        public List<ItemData> _Settings { get; set; } = [];
    }

    public class ItemData
    {
        public string _Comment { get; set; } = "";
        public string ItemDataID { get; set; } = "";
        public System.Guid NameMsg { get; set; }
        public System.Guid ManualMsg { get; set; }
        public Enums.app.Item.ItemCategoryType Category { get; set; }
        public Enums.app.ItemSortCategory SortCategory { get; set; }
        public int SortPriority { get; set; }
        public Enums.app.Item.ItemSlotSize SlotSize { get; set; }
        public int MaxStackNum { get; set; }
        public bool CanStoreItembox { get; set; }
        public via.Prefab ItemPrefab { get; set; }
        public app.ItemData.WeaponData WeaponSetting { get; set; }
        public app.ItemData.UIData UISetting { get; set; }
        public app.ItemData.DropItemData DropItemSetting { get; set; }

        public class DropItemData
        {
            public via.Prefab DropItemPrefab { get; set; }
        }

        public class UIData
        {
            public int IconFrameNo { get; set; }
            public int RoomID { get; set; }
            public int MapIconFrameNo { get; set; }
        }

        public class WeaponData
        {
            public Enums.app.ReticleGUI.WeaponTypeDef ReticleType { get; set; }
            public Enums.app.WeaponInfoType WeaponInfoType { get; set; }
        }
    }

    public class AddItemListData
    {
        public List<Data> _AddItems { get; set; } = [];

        public class Data
        {
            public string ItemDataID { get; set; } = "";
            public int Num { get; set; }
        }
    }

    public class SetInventoryExtend
    {
        public bool v0_Enabled { get; set; }
        public bool v1_Modified { get; set; }
        public uint v2_UID { get; set; }
        public byte v3_ListNo { get; set; }
        public System.Guid _TargetGameObject { get; set; }
        public Enums.app.Inventory.ExtendLvDef _SetExtendLv { get; set; }
        public bool isSetExtendLv { get; set; }
    }
}

namespace via
{
    public class Transform
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public string ParentJoint { get; set; } = "";
        public bool SameJointsContraint { get; set; }
        public bool JointSegmentScale { get; set; }
        public bool JointFastLockScene { get; set; }
    }

    public class Prefab
    {
        public bool Standby { get; set; }
        public object Path { get; set; } // Actually a via.Resource
    }

    namespace fsm
    {
        public class SceneFsmData
        {
            public ulong v0_ResourceID { get; set; }
            public object v1_Actions { get; set; }
            public object v2_Conditions { get; set; }
        }

        public class Fsm
        {
            public object Resource { get; set; } // Actually a via.Resource
            public ReadOnlyMemory<byte> v1 { get; set; }
            public ReadOnlyMemory<byte> v2 { get; set; }
            public ReadOnlyMemory<byte> v3 { get; set; }
            public object v4 { get; set; }
            public ReadOnlyMemory<byte> v5 { get; set; }
            public ReadOnlyMemory<byte> v6 { get; set; }
            public ReadOnlyMemory<byte> v7 { get; set; }
            public ReadOnlyMemory<byte> v8 { get; set; }
            public ReadOnlyMemory<byte> v9 { get; set; }
            public ReadOnlyMemory<byte> v10 { get; set; }
            public ReadOnlyMemory<byte> v11 { get; set; }
        }
    }
}