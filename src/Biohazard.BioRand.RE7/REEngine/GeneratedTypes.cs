#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // These words must begin with upper case characters
#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable IDE0001 // Underscore as first character in properties

using IntelOrca.Biohazard.REE.Rsz;
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

    public class WeaponGun
    {
        public bool Enabled { get; set; } = new();
        public Enums.app.WeaponID WeaponID { get; set; }
        public object EquipParam { get; set; }
        public RszUserDataNode WeaponData { get; set; }
        public bool IsInventoryWeapon { get; set; }
        public Enums.app.CharacterDefine.Type UserType { get; set; }
        public uint HitMaterial { get; set; }
        public RszUserDataNode HoldAdaptiveTriggerUserData { get; set; }
        public RszUserDataNode FireAdaptiveTriggerUserData { get; set; }
        public RszUserDataNode ActiveAdaptiveTriggerUserData { get; set; }
        public Enums.app.WeaponGun.BulletTypeSwitch BulletTypeForSound { get; set; }
        public RszUserDataNode WeaponGunParameter { get; set; }
        public List<app.WeaponGun.BulletInfo> BulletInfoList { get; set; } = [];

        public class BulletInfo
        {
            public Enums.app.ItemID BulletItemID { get; set; }
            public int LoadNum { get; set; }
        }

        public class BulletTypeSwitch
        {
            public int value__ { get; set; }
        }

        public class StateName
        {
        }

        public class WeaponGunSaveData
        {
            public bool IsValid { get; set; }
            public List<app.WeaponGun.BulletInfo> BulletInfoList { get; set; } = [];
            public Enums.app.ItemID BulletItemID { get; set; }
        }
    }

    public class CH8WeaponGun : WeaponGun
    {
    }

    public class CH9PlayerKnuckleWeapon : WeaponGun
    {
    }

    public class CH9WeaponGun : WeaponGun
    {
    }

    public class WeaponData
    {
        public List<app.WeaponData.EquipData> EquipDatas { get; set; } = [];

        public class EquipData
        {
            public app.ObjectID OwnerID { get; set; }
            public object AttachParam { get; set; }
        }
    }

    public class ObjectID
    {
        public Enums.app.Group Group { get; set; }
        public string CategoryName { get; set; } = "";
        public string ObjectName { get; set; } = "";
        public string LayoutName { get; set; } = "";
    }

    public class WeaponGunParameter
    {
        public int MaxLoadNum { get; set; }
        public bool IsLoadNumInfinity { get; set; }
        public bool IsBulletStackNumInfinity { get; set; }
        public float Range { get; set; }
        public float AttenuationStart { get; set; }
        public float AttenuationEnd { get; set; }
        public float MinAttenuationDamageRate { get; set; }
        public float Radius { get; set; }
        public int DiffusionNum { get; set; }
        public float DiffusionRadius { get; set; }
        public float AimDiffusionRadius { get; set; }
        public float RecoilBurstInterval { get; set; }
        public int RecoilBurstCount { get; set; }
        public float RecoilYAngle { get; set; }
        public float RecoilXAngle { get; set; }
    }

    public class CoinCounter
    {
        public bool Enabled { get; set; }
        public int CoinMax { get; set; }
        public int NowCoin { get; set; }
        public int DispNum { get; set; }
        public Guid GameObj { get; set; }
        public int SaveNumber { get; set; }
    }

    public class ItemSelectReaction
    {
        public bool Enabled { get; set; }
        public List<ReactionSetting> ReactionSettings { get; set; } = [];
        public string FailedStateName { get; set; } = "";
        public string CancelStateName { get; set; } = "";
        public Guid FsmObj { get; set; }
        public bool IsAllItemSuccess { get; set; }
        public class ReactionSetting
        {
            public string ItemID { get; set; } = "";
            public string StateName { get; set; } = "";
            public Enums.app.ItemSelectReaction.Result Result { get; set; }
        }
        public class Result
        {
            public int value__ { get; set; }
        }
    }

    public class ReliefItemTable
    {
        public string _Comment { get; set; } = "";
        public List<ReliefItemTableData> DataList { get; set; } = [];
        public class ReliefItemTableData
        {
            public string ItemID { get; set; } = "";
            public uint EasyDropRate { get; set; }
            public uint NormalDropRate { get; set; }
            public uint HardDropRate { get; set; }
            public uint ReliefNum { get; set; }
            public uint NormalDropNum { get; set; }
            public uint ReliefDropNum { get; set; }
        }
    }

    public class ChapterJumpData
    {
        public bool Enabled { get; set; } = new();
        public string JumpPositionName { get; set; } = "";
        public Enums.app.GameManager.ChapterNo JumpChapter { get; set; }
        public bool IsGetPlayerPos { get; set; }
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
        public bool AbsoluteScaling { get; set; }
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