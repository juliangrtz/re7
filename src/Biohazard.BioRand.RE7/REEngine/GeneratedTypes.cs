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

    public class CH8WeaponGun : WeaponGun
    {
    }

    public class CH9PlayerKnuckleWeapon : WeaponGun
    {
    }

    public class CH9WeaponGun : WeaponGun
    {
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

    public class Weapon
    {
        public bool Enabled { get; set; } = new();
        public Enums.app.WeaponID WeaponID { get; set; }
        public app.Weapon.AttachParam EquipParam { get; set; }
        public RszUserDataNode WeaponData { get; set; }
        public bool IsInventoryWeapon { get; set; }
        public Enums.app.CharacterDefine.Type UserType { get; set; }
        public uint HitMaterial { get; set; }
        public RszUserDataNode HoldAdaptiveTriggerUserData { get; set; }
        public RszUserDataNode FireAdaptiveTriggerUserData { get; set; }
        public RszUserDataNode ActiveAdaptiveTriggerUserData { get; set; }
        public class AttachParam
        {
            public string JointName { get; set; } = "";
            public System.Numerics.Vector3 Position { get; set; }
            public System.Numerics.Vector3 Angle { get; set; }
        }
        public class Hash
        {
            public class MotionFsm
            {
            }
        }
        public class MotionID
        {
            public int value__ { get; set; }
        }
        public class MotionVariable
        {
        }
        public class StateName
        {
        }
    }
    public class CH8WeaponThrowable : Weapon
    {
        public float LifeSec { get; set; }
        public float LifeSecLimit { get; set; }
        public float _throwSpeedRate { get; set; }
        public float _underThrowSpeedRate { get; set; }
        public System.Numerics.Quaternion ShootRayCorrect { get; set; }
        public System.Numerics.Quaternion UnderShootRayCorrect { get; set; }
        public System.Collections.Generic.List<uint> specificDispPartsIndexList { get; set; } = [];
        public Enums.app.CH8ShellManager.GrenadeType GrenadeType { get; set; }
    }
    public class CH9WeaponMelee : Weapon
    {
        public int AutoEquipPriority { get; set; }
    }
    public class CH9WeaponThrowable : Weapon
    {
        public Enums.app.CH9WeaponThrowable.eUseType UseType { get; set; }
        public class eUseType
        {
            public int value__ { get; set; }
        }
    }
    public class HandLight : Weapon
    {
    }
    public class HandLightNpc : Weapon
    {
        public bool DefaultLightEnable { get; set; }
        public class Define
        {
            public class Effect
            {
            }
        }
    }
    public class WeaponChainSaw : Weapon
    {
        public via.Prefab TimeLineContainerPrefab { get; set; }
        public class LampState
        {
            public int value__ { get; set; }
        }
        public class MotionVariable
        {
        }
        public class TimelineIndex
        {
        }
    }
    public class WeaponGun : Weapon
    {
        public Enums.app.WeaponGun.BulletTypeSwitch BulletTypeForSound { get; set; }
        public RszUserDataNode WeaponGunParameter { get; set; }
        public System.Collections.Generic.List<app.WeaponGun.BulletInfo> BulletInfoList { get; set; } = [];
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
            public System.Collections.Generic.List<app.WeaponGun.BulletInfo> BulletInfoList { get; set; } = [];
            public Enums.app.ItemID BulletItemID { get; set; }
        }
    }
    public class WeaponItem : Weapon
    {
        public System.Guid UseSuccessFlagID { get; set; }
        public bool IsStackNumInfinity { get; set; }
        public class StateName
        {
        }
    }
    public class WeaponData
    {
        public System.Collections.Generic.List<app.WeaponData.EquipData> EquipDatas { get; set; } = [];
        public class EquipData
        {
            public app.ObjectID OwnerID { get; set; }
            public app.Weapon.AttachParam AttachParam { get; set; }
        }
    }
}

namespace app.Collision
{
    public class AttackUserData
    {
        public string Name { get; set; } = "";
        public object ParentUserData { get; set; } = new();
        public Enums.app.Collision.ContactBaseUserData.PriorityLevel Priority { get; set; }
        public int Damage { get; set; }
        public int Stun { get; set; }
        public float VrGain { get; set; }
        public bool IsWithAttack { get; set; }
        public float Timer { get; set; }
        public uint Attribute0 { get; set; }
        public uint Attribute1 { get; set; }
        public uint Attribute2 { get; set; }
        public uint Attribute3 { get; set; }
        public uint Attribute4 { get; set; }
        public int User0 { get; set; }
        public int User1 { get; set; }
        public int User2 { get; set; }
        public int User3 { get; set; }
        public int UniqueID { get; set; }
        public int ShellID { get; set; }
        public System.Numerics.Vector3 ExtHitWallFrom { get; set; }
        public System.Numerics.Vector3 ExtHitWallTo { get; set; }
        public class Attribute
        {
            public int value__ { get; set; }
        }
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
}

namespace hikako
{
    public class AdaptiveTriggerUserData
    {
        public string Description { get; set; } = "";
        public float Power { get; set; }
        public float Frequency { get; set; }
        public float StartPos { get; set; }
        public float EndPos { get; set; }
    }
}

namespace app.Havok
{
    public class RigidBodyDestruct
    {
        public bool Enabled { get; set; } = new();
        public app.Collision.MaterialId MaterialId { get; set; }
        public bool IsActiveCollisionTerrain { get; set; }
        public bool IsActiveCollisionEffect { get; set; }
        public bool IsStartActivate { get; set; }
        public bool IsSkipHitRay { get; set; }
        public bool IsSkipHitSphere { get; set; }
        public bool IsSkipOnContact { get; set; }
        public bool IsSkipHitFromPlayer { get; set; }
        public bool IsOnlyHitFromPlayer { get; set; }
        public bool IsBreakOnContact { get; set; }
        public bool IsEarlyDeactivate { get; set; }
        public bool IsSkipRayBreak { get; set; }
        public bool IsDebugBreak { get; set; }
        public System.Numerics.Vector3 BreakDir { get; set; }
        public float UpImpulse { get; set; }
        public float ExplodeImpulse { get; set; }
        public float YImpulseGain { get; set; }
        public bool IsStatic { get; set; }
        public float BreakForce { get; set; }
        public System.Guid SaveGUID { get; set; }
        public float EraseSec { get; set; }
        public bool IsEraseInView { get; set; }
        public Enums.app.Havok.RigidBodyDestruct.EraseModeEnum EraseMode { get; set; }
        public bool IsSkipSave { get; set; }
        public System.Collections.Generic.List<string> AfterKeyFramedRigidNames { get; set; } = [];
        public class EraseModeEnum
        {
            public int value__ { get; set; }
        }
        public class SaveData
        {
            public System.Guid SaveGUID { get; set; }
            public string FolderName { get; set; } = "";
            public bool IsBreak { get; set; }
        }
    }
}
namespace app.Collision
{
    public class MaterialId
    {
        public Enums.app.Collision.MaterialId.TypeLabel Type { get; set; }
        public class TypeLabel
        {
            public int value__ { get; set; }
        }
    }
}

namespace app
{
    public class Oilcan
    {
        public bool Enabled { get; set; } = new();
        public System.Guid FsmObject { get; set; }
        public System.Collections.Generic.List<app.Oilcan.HitSetting> HitSettings { get; set; } = [];
        public bool IsHitOnce { get; set; }
        public Enums.app.Oilcan.OilcanSetType OilcanType { get; set; }
        public bool DisableLucasMessage { get; set; }
        public class HitSetting
        {
            public string StateName { get; set; } = "";
        }
        public class OilcanSetType
        {
            public int value__ { get; set; }
        }
    }
}

namespace app.fsm
{
    public class CollidersEnable : via.fsm.Action
    {
        public bool v0_Enabled { get; set; } = new();
        public bool v1_Modified { get; set; } = new();
        public uint v2_UID { get; set; } = new();
        public byte v3_ListNo { get; set; } = new();
        public bool IsOwnerObjSet { get; set; }
        public app.ObjectSet GameObjSet { get; set; }
        public int IndexNo { get; set; }
        public bool IsEnable { get; set; }
        public bool WithChildren { get; set; }
        public bool WithRigidBody { get; set; }
    }
}
namespace app
{
    public class ObjectSet
    {
        public app.ObjectID GameObjID { get; set; }
        public app.ObjectLabel.SelectionLabel GameObjLabel { get; set; }
        public app.ObjectManager.SelectableContainerObjectName GameObjContainer { get; set; }
        public System.Guid GameObj { get; set; }
    }
}

namespace app.fsm
{
    public class PartsEnable : via.fsm.Action
    {
        public bool v0_Enabled { get; set; } = new();
        public bool v1_Modified { get; set; } = new();
        public uint v2_UID { get; set; } = new();
        public byte v3_ListNo { get; set; } = new();
        public bool IsOwnerObjSet { get; set; }
        public app.ObjectSet GameObjSet { get; set; }
        public Enums.app.fsm.PartsEnable.PartsSetType SetType { get; set; }
        public bool IsOnlySet { get; set; }
        public System.Collections.Generic.List<int> PartsNoList { get; set; } = [];
        public class PartsSetType
        {
            public int value__ { get; set; }
        }
    }
}

namespace app
{
    public class ObjectManager
    {
        public bool Enabled { get; set; } = new();
        public class ListType
        {
            public int value__ { get; set; }
        }
        public class SelectableContainerObjectName
        {
            public string ContainerName { get; set; } = "";
            public string ObjectName { get; set; } = "";
        }
    }
}

namespace app
{
    public class ObjectLabel
    {
        public bool Enabled { get; set; } = new();
        public app.ObjectID ObjectID { get; set; }
        public uint Attributes { get; set; }
        public class Attribute
        {
            public int value__ { get; set; }
        }
        public class SelectionLabel
        {
            public app.ObjectLabel.SelectionLabel.SingleSelect SingleSelectObject { get; set; }
            public app.ObjectLabel.SelectionLabel.HierarchySelect HierarchySelectObject { get; set; }
            public class HierarchySelect
            {
                public string CategoryName { get; set; } = "";
                public Enums.app.Group Group { get; set; }
                public string RootName { get; set; } = "";
                public Enums.app.Group ChildGroup { get; set; }
                public string ChildName { get; set; } = "";
                public Enums.app.Group GrandChildGroup { get; set; }
                public string GrandChildName { get; set; } = "";
            }
            public class SingleSelect
            {
                public string CategoryName { get; set; } = "";
                public Enums.app.Group Group { get; set; }
                public string ObjectFullName { get; set; } = "";
            }
        }
    }
}

namespace via.fsm
{
    public class Fsm
    {
        public RszResourceNode Resource { get; set; }
        public System.Guid InstanceGuid { get; set; }
        public bool Enabled { get; set; } = new();
        public bool PuppetMode { get; set; } = new();
        public System.Collections.Generic.List<via.fsm.SceneFsmData> SceneData { get; set; } = [];
        public Enums.via.fsm.ExecGroup ExecGroup { get; set; }
        public bool UseExecuteOnScene { get; set; } = new();
        public bool ExecuteOnScene { get; set; } = new();
        public bool EnabledLogTrace { get; set; } = new();
        public bool OnDebug { get; set; } = new();
        public bool MuteResourceDialog { get; set; } = new();
        public uint DebugID { get; set; } = new();
        public class WrappedArrayContainer_SceneData
        {
        }
    }
    public class FsmResourceHolder
    {
    }
    public class SceneFsmData
    {
        public ulong v0_ResourceID { get; set; } = new();
        public System.Collections.Generic.List<via.fsm.Action> v1_Actions { get; set; } = [];
        public System.Collections.Generic.List<via.fsm.Condition> v2_Conditions { get; set; } = [];
        public class WrappedArrayContainer_Actions
        {
        }
        public class WrappedArrayContainer_Conditions
        {
        }
    }
    public class Action
    {
        public bool v0_Enabled { get; set; } = new();
        public bool v1_Modified { get; set; } = new();
        public uint v2_UID { get; set; } = new();
        public byte v3_ListNo { get; set; } = new();
        public class SwitchSetting
        {
            public int value__ { get; set; }
        }
    }
    public class ActionPlayMotion : Action
    {
        public RszResourceNode v4_Resource { get; set; } = new();
    }
    public class Condition
    {
        public uint v0_UID { get; set; } = new();
        public bool v1_Enabled { get; set; } = new();
        public bool v2_Condition { get; set; } = new();
        public System.Guid v3_Expression { get; set; }
        public Enums.via.fsm.ExpressionReferenceType v4_ExpressionReferenceType { get; set; }
        public string v5_Name { get; set; } = "";
    }

    public class ConditionAllActionNodeWorkEnd : Condition
    {
    }
    public class ConditionAllActionNodeWorkFailed : Condition
    {
    }
    public class ConditionNodeWorkEnd : Condition
    {
    }
    public class ConditionNodeWorkFailed : Condition
    {
    }
    public class ConditionTrue : Condition
    {
    }
    public class ConditionUserDataExpression : Condition
    {
    }
}

namespace app
{
    public class PlayerReloadSpeedRateTable
    {
        public System.Collections.Generic.List<float> ReloadSpeedRateList { get; set; } = [];
    }
}
