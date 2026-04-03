#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // These words must begin with upper case characters
#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable IDE0001 // Underscore as first character in properties
#pragma warning disable CS0108 // Inherited member hides base member

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

    public class PlayerMaxHealthTable
    {
        public System.Collections.Generic.List<float> MaxHealthList { get; set; } = [];
    }
}

namespace app
{
    public class Em2000DirectivesHolder
    {
        public string Alias { get; set; } = "";
        public app.EnemyDirectivesHolder holder { get; set; }
    }

    public class Em3000DirectivesHolder
    {
        public string Alias { get; set; } = "";
        public app.EnemyDirectivesHolder holder { get; set; }
    }

    public class Em3100DirectivesHolder
    {
        public string Alias { get; set; } = "";
        public app.EnemyDirectivesHolder holder { get; set; }
    }

    public class Em3600DirectivesHolder
    {
        public string Alias { get; set; } = "";
        public app.EnemyDirectivesHolder holder { get; set; }
    }

    public class Em4000DirectivesHolder
    {
        public string Alias { get; set; } = "";
        public app.EnemyDirectivesHolder holder { get; set; }
    }

    public class Em4100DirectivesHolder
    {
        public string Alias { get; set; } = "";
        public app.EnemyDirectivesHolder holder { get; set; }
    }

    public class Em4200DirectivesHolder
    {
        public string Alias { get; set; } = "";
        public app.EnemyDirectivesHolder holder { get; set; }
    }

    public class EnemyDirectivesHolder
    {
        public RszUserDataNode defaultDirective { get; set; }
        public System.Collections.Generic.List<app.EnemyDirectiveUnit> Units { get; set; } = [];
    }
    public class EnemyDirective
    {
    }

    public class EnemyDirectiveUnit
    {
        public int Rank { get; set; }
        public RszUserDataNode Directive { get; set; }
    }
}

namespace app
{
    public class Em2000BattleDirective
    {
        public app.Em2000BattleDirective.Common common { get; set; }
        public app.Em2000BattleDirective.Chapter1Battle1 chapter1Battle1 { get; set; }
        public app.Em2000BattleDirective.Chapter1Battle2 chapter1Battle2 { get; set; }
        public app.Em2000BattleDirective.Chapter1Battle4 chapter1Battle4 { get; set; }
        public app.Em2000BattleDirective.Chapter4Battle chapter4Battle { get; set; }
        public app.Em2000BattleDirective.TimeLineStateNo timeLineStateNo { get; set; }
        public class Chapter1Battle1
        {
            public float Health { get; set; }
            public float CrawlStartInRange { get; set; }
            public float CrawlGrappleInRange { get; set; }
            public float CrawlMinFOV { get; set; }
            public float CrawlMinFOVRange { get; set; }
            public float CrawlEndResetFOVInterpolateTime { get; set; }
            public float RunGrappleInRange { get; set; }
            public float KnifeCatchLoopTime { get; set; }
        }
        public class Chapter1Battle2
        {
            public float Health { get; set; }
            public float WalkKnifeAttackRange { get; set; }
            public float RunKnifeAttackRange { get; set; }
            public float WalkKnifeRushRange { get; set; }
            public float RunKnifeRushRange { get; set; }
            public float ThrowRange { get; set; }
            public int ToSecondFlowAttackCounter { get; set; }
            public float FirstFlowWalkTime { get; set; }
            public float SecondFlowWalkTime { get; set; }
            public float WalkTimeDeclineByDamage { get; set; }
            public float CounterAttackRange { get; set; }
            public float MessageInterval { get; set; }
        }
        public class Chapter1Battle4
        {
            public float Health { get; set; }
            public float WalkSpeedRateThird { get; set; }
            public float FirstFlowEndTime { get; set; }
            public float FirstFlowEndHP { get; set; }
            public float SecondFlowEndTime { get; set; }
            public float SecondFlowEndHP { get; set; }
            public float AfterStrikeHandicapTimeMin { get; set; }
            public float AfterStrikeHandicapTimeMax { get; set; }
            public float NearestRange { get; set; }
            public float MountRange { get; set; }
            public float MountInRangeTime { get; set; }
            public float MountGrappleSleepTime { get; set; }
            public float ShortSlashRange { get; set; }
            public float SlashRange { get; set; }
            public float StabShortRange { get; set; }
            public float StabMiddleRange { get; set; }
            public float StabLongRange { get; set; }
            public float StabAttackSleepTime { get; set; }
            public float RunSlashRange { get; set; }
            public float RunStartRange { get; set; }
            public float RunStartTime { get; set; }
            public float StepAttackMiddleRange { get; set; }
            public float StepAttackLongRange { get; set; }
            public float StepAttackInRangeTime { get; set; }
            public float StepAttackSleepTime { get; set; }
            public float MountLoopTime { get; set; }
            public float WallBreakEvaluationTime { get; set; }
            public float MessageInterval { get; set; }
            public float HandicapTime { get; set; }
            public float EvasiveWalkRate { get; set; }
            public float WalkSpeedRateForRank { get; set; }
        }
        public class Chapter4Battle
        {
            public float MessageInterval { get; set; }
        }
        public class Common
        {
            public float MotionCancelThreshold { get; set; }
        }
        public class TimeLineStateNo
        {
            public int Chapter1Battle1CrawlStart { get; set; }
            public int Chapter1Battle1MountStart { get; set; }
            public int Chapter1Battle1FinishEventStart { get; set; }
        }
    }
}

namespace app
{
    public class Em3000BattleDirective
    {
        public app.Em3000BattleDirective.Common common { get; set; }
        public app.Em3000BattleDirective.Chapter3Battle1 chapter3Battle1 { get; set; }
        public app.Em3000BattleDirective.Chapter3Battle1Final chapter3Battle1Final { get; set; }
        public app.Em3000BattleDirective.Chapter3Battle2 chapter3Battle2 { get; set; }
        public app.Em3000BattleDirective.Chapter3Battle1Anger chapter3Battle1Anger { get; set; }
        public app.Em3000BattleDirective.Chapter3Battle1FinalAnger chapter3Battle1FinalAnger { get; set; }
        public app.Em3000BattleDirective.Chapter3Battle2Anger chapter3Battle2Anger { get; set; }
        public class AngerBase
        {
            public float Attack { get; set; }
            public float MissAttack { get; set; }
            public float Damaged { get; set; }
            public float DamagedNotResist { get; set; }
            public float Discovery { get; set; }
            public float UnDiscoveryPerSec { get; set; }
            public float NotAttackPerSec { get; set; }
            public float NotAttack { get; set; }
            public float MaxLimit { get; set; }
            public float ConditionTotalDamage { get; set; }
            public float ConditionTotalTime { get; set; }
        }
        public class BattleBase
        {
            public float DistanceZero { get; set; }
            public float DistanceShort { get; set; }
            public float DistanceMid { get; set; }
            public float AttackDelay { get; set; }
            public float AttackSHitDelay { get; set; }
            public float AttackMHitDelay { get; set; }
            public float AttackLHitDelay { get; set; }
            public float AttackBlowHitDelay { get; set; }
            public float AttackDelayAdd { get; set; }
            public float AttackHitDelayAdd { get; set; }
            public float MessageDelay { get; set; }
            public float MessageAppearDelay { get; set; }
            public float MoveSpeedUpPerSec { get; set; }
            public float MoveSpeedDownPerSec { get; set; }
            public float MoveSpeedFast { get; set; }
            public float MoveSpeedFastMax { get; set; }
            public float MoveSpeedSlowMax { get; set; }
            public float DistanceWalkSlow { get; set; }
            public float DistanceWalkSlowForFast { get; set; }
            public bool IsAttackShortGrapple { get; set; }
            public float ForwardStepDist { get; set; }
            public float KnockDelay { get; set; }
            public float CommonTurnDelay { get; set; }
            public float RestDelay { get; set; }
            public float DamageTotalPLClearTime { get; set; }
            public float DamageTotalForReserve { get; set; }
            public float TurnForWanderDelay { get; set; }
            public float MountPLHPRate { get; set; }
            public Enums.app.Em3000.Action.ActionZero ActionZeroType { get; set; }
            public Enums.app.Em3000.Action.ActionShort ActionShortType { get; set; }
        }
        public class Chapter3Battle1
        {
            public float DistanceZero { get; set; }
            public float DistanceShort { get; set; }
            public float DistanceMid { get; set; }
            public float AttackDelay { get; set; }
            public float AttackSHitDelay { get; set; }
            public float AttackMHitDelay { get; set; }
            public float AttackLHitDelay { get; set; }
            public float AttackBlowHitDelay { get; set; }
            public float AttackDelayAdd { get; set; }
            public float AttackHitDelayAdd { get; set; }
            public float MessageDelay { get; set; }
            public float MessageAppearDelay { get; set; }
            public float MoveSpeedUpPerSec { get; set; }
            public float MoveSpeedDownPerSec { get; set; }
            public float MoveSpeedFast { get; set; }
            public float MoveSpeedFastMax { get; set; }
            public float MoveSpeedSlowMax { get; set; }
            public float DistanceWalkSlow { get; set; }
            public float DistanceWalkSlowForFast { get; set; }
            public bool IsAttackShortGrapple { get; set; }
            public float ForwardStepDist { get; set; }
            public float KnockDelay { get; set; }
            public float CommonTurnDelay { get; set; }
            public float RestDelay { get; set; }
            public float DamageTotalPLClearTime { get; set; }
            public float DamageTotalForReserve { get; set; }
            public float TurnForWanderDelay { get; set; }
            public float MountPLHPRate { get; set; }
            public Enums.app.Em3000.Action.ActionZero ActionZeroType { get; set; }
            public Enums.app.Em3000.Action.ActionShort ActionShortType { get; set; }
            public float DistanceExtra { get; set; }
            public float MansionAIForceDiscoveryTime { get; set; }
            public float LookWindowEndTime { get; set; }
            public float LookWindowEndDistance { get; set; }
        }
        public class Chapter3Battle1Anger
        {
            public float Attack { get; set; }
            public float MissAttack { get; set; }
            public float Damaged { get; set; }
            public float DamagedNotResist { get; set; }
            public float Discovery { get; set; }
            public float UnDiscoveryPerSec { get; set; }
            public float NotAttackPerSec { get; set; }
            public float NotAttack { get; set; }
            public float MaxLimit { get; set; }
            public float ConditionTotalDamage { get; set; }
            public float ConditionTotalTime { get; set; }
        }
        public class Chapter3Battle1Final
        {
            public float DistanceZero { get; set; }
            public float DistanceShort { get; set; }
            public float DistanceMid { get; set; }
            public float AttackDelay { get; set; }
            public float AttackSHitDelay { get; set; }
            public float AttackMHitDelay { get; set; }
            public float AttackLHitDelay { get; set; }
            public float AttackBlowHitDelay { get; set; }
            public float AttackDelayAdd { get; set; }
            public float AttackHitDelayAdd { get; set; }
            public float MessageDelay { get; set; }
            public float MessageAppearDelay { get; set; }
            public float MoveSpeedUpPerSec { get; set; }
            public float MoveSpeedDownPerSec { get; set; }
            public float MoveSpeedFast { get; set; }
            public float MoveSpeedFastMax { get; set; }
            public float MoveSpeedSlowMax { get; set; }
            public float DistanceWalkSlow { get; set; }
            public float DistanceWalkSlowForFast { get; set; }
            public bool IsAttackShortGrapple { get; set; }
            public float ForwardStepDist { get; set; }
            public float KnockDelay { get; set; }
            public float CommonTurnDelay { get; set; }
            public float RestDelay { get; set; }
            public float DamageTotalPLClearTime { get; set; }
            public float DamageTotalForReserve { get; set; }
            public float TurnForWanderDelay { get; set; }
            public float MountPLHPRate { get; set; }
            public Enums.app.Em3000.Action.ActionZero ActionZeroType { get; set; }
            public Enums.app.Em3000.Action.ActionShort ActionShortType { get; set; }
            public float Health { get; set; }
            public float WalkZigzagHPRate { get; set; }
            public float DamageTotalForEnemyGetInto { get; set; }
        }
        public class Chapter3Battle1FinalAnger
        {
            public float Attack { get; set; }
            public float MissAttack { get; set; }
            public float Damaged { get; set; }
            public float DamagedNotResist { get; set; }
            public float Discovery { get; set; }
            public float UnDiscoveryPerSec { get; set; }
            public float NotAttackPerSec { get; set; }
            public float NotAttack { get; set; }
            public float MaxLimit { get; set; }
            public float ConditionTotalDamage { get; set; }
            public float ConditionTotalTime { get; set; }
        }
        public class Chapter3Battle2
        {
            public float DistanceZero { get; set; }
            public float DistanceShort { get; set; }
            public float DistanceMid { get; set; }
            public float AttackDelay { get; set; }
            public float AttackSHitDelay { get; set; }
            public float AttackMHitDelay { get; set; }
            public float AttackLHitDelay { get; set; }
            public float AttackBlowHitDelay { get; set; }
            public float AttackDelayAdd { get; set; }
            public float AttackHitDelayAdd { get; set; }
            public float MessageDelay { get; set; }
            public float MessageAppearDelay { get; set; }
            public float MoveSpeedUpPerSec { get; set; }
            public float MoveSpeedDownPerSec { get; set; }
            public float MoveSpeedFast { get; set; }
            public float MoveSpeedFastMax { get; set; }
            public float MoveSpeedSlowMax { get; set; }
            public float DistanceWalkSlow { get; set; }
            public float DistanceWalkSlowForFast { get; set; }
            public bool IsAttackShortGrapple { get; set; }
            public float ForwardStepDist { get; set; }
            public float KnockDelay { get; set; }
            public float CommonTurnDelay { get; set; }
            public float RestDelay { get; set; }
            public float DamageTotalPLClearTime { get; set; }
            public float DamageTotalForReserve { get; set; }
            public float TurnForWanderDelay { get; set; }
            public float MountPLHPRate { get; set; }
            public Enums.app.Em3000.Action.ActionZero ActionZeroType { get; set; }
            public Enums.app.Em3000.Action.ActionShort ActionShortType { get; set; }
            public float DistanceExtra { get; set; }
            public float MansionAIForceDiscoveryTime { get; set; }
            public float MessageDistanceShort { get; set; }
            public float DownTime { get; set; }
            public float DownTimeForwardDistance { get; set; }
            public float DownTimeForwardSec { get; set; }
            public float DownTimeDamageRemainSec { get; set; }
        }
        public class Chapter3Battle2Anger
        {
            public float Attack { get; set; }
            public float MissAttack { get; set; }
            public float Damaged { get; set; }
            public float DamagedNotResist { get; set; }
            public float Discovery { get; set; }
            public float UnDiscoveryPerSec { get; set; }
            public float NotAttackPerSec { get; set; }
            public float NotAttack { get; set; }
            public float MaxLimit { get; set; }
            public float ConditionTotalDamage { get; set; }
            public float ConditionTotalTime { get; set; }
        }
        public class Common
        {
            public float ModelScale { get; set; }
            public float LeaveTime { get; set; }
            public float DistanceCancelAttack { get; set; }
            public float MotionSpeedForWalk { get; set; }
            public float MotionSpeedForStepIn { get; set; }
            public float MotionSpeedForBack { get; set; }
            public bool IsReserve { get; set; }
            public float TurnSpeedSlowPerSec { get; set; }
            public float TurnSpeedNormalPerSec { get; set; }
            public float TurnSpeedFastPerSec { get; set; }
            public float TurnSpeedStepInPerSec { get; set; }
            public float DistanceDoorForNoDown { get; set; }
        }
    }
}

namespace app
{
    public class Em3100Directive
    {
        public app.Em3100Directive.BugHoleParam bugHoleParam { get; set; }
        public app.Em3100Directive.FFParam fFParam { get; set; }
        public app.Em3100Directive.PatrolParam patrolParam { get; set; }
        public float FretWalkSpeed { get; set; }
        public class BugHoleParam
        {
            public float AutoDeadTimerSec { get; set; }
            public float AttackIntervalSec { get; set; }
            public float StunTimeSec { get; set; }
            public int NumInstructEm5520 { get; set; }
            public float Em5400SpawnInterval { get; set; }
            public float InstructLoopTimerSec { get; set; }
        }
        public class FFParam
        {
            public float LookAtPLTimerSec { get; set; }
            public string UseVisionParamName { get; set; } = "";
        }
        public class PatrolParam
        {
            public int NumInstructEm5400 { get; set; }
            public int NumInstructEm5520 { get; set; }
            public float ThreashouldHPDash { get; set; }
            public string UseVisionParamName { get; set; } = "";
        }
    }
}

namespace app
{
    public class Em3600Directive
    {
        public app.Em3600Directive.CommonParam MyCommonParam { get; set; }
        public app.Em3600Directive.DamageParam MyDamageParam { get; set; }
        public app.Em3600Directive.NormalBattleMode NormalModeParam { get; set; }
        public app.Em3600Directive.WallMoveMode WallMoveModeParam { get; set; }
        public app.Em3600Directive.GenerateMode GenerateModeParam { get; set; }
        public app.Em3600Directive.SneakMode SneakModeParam { get; set; }
        public app.Em3600Directive.EscapeMode EscapeModeParam { get; set; }
        public app.Em3600Directive.LastMode LastModeParam { get; set; }
        public class AttackConditionParam
        {
            public bool IsUse { get; set; }
            public int Priority { get; set; }
            public app.Em3600Directive.floatParamBase InRange { get; set; }
            public app.Em3600Directive.floatParamBase OutRange { get; set; }
            public app.Em3600Directive.floatParamBase FrontAngle { get; set; }
            public app.Em3600Directive.floatParamBase LeftAngle { get; set; }
            public app.Em3600Directive.floatParamBase RightAngle { get; set; }
            public app.Em3600Directive.floatParamBase BackAngle { get; set; }
            public bool IsNotStand { get; set; }
            public bool IsNotSit { get; set; }
            public float Interval { get; set; }
            public float ForwardStepDist { get; set; }
            public float HomingSpeed { get; set; }
        }
        public class AttackHitIntervalParam
        {
            public bool IsUse { get; set; }
            public float AttackIntervalThresholdSub { get; set; }
            public float AttackHitThresholdAdd { get; set; }
            public float GuardHitThresholdAdd { get; set; }
            public float GrappleHitThresholdAdd { get; set; }
            public float ThresholdSubIntervalSec { get; set; }
            public float InRange { get; set; }
        }
        public class CommonParam
        {
            public float GenerateToSneakHealthRate { get; set; }
            public float SneakToAngryHealthRate { get; set; }
            public float AngryEndTime { get; set; }
            public float LastModeHealthRate { get; set; }
            public float CoreCoverBreakHealthRate { get; set; }
            public float StunUpRate { get; set; }
            public float NormalAttackIntervalTime { get; set; }
            public float GrappleAttackIntervalTime { get; set; }
            public float GroundAttackIntervalTime { get; set; }
            public float WallAttackIntervalTime { get; set; }
            public float ChangeTwoLegMoveSpeed { get; set; }
            public float ChangeFourLegMoveSpeed { get; set; }
        }
        public class DamageParam
        {
            public float FallDamageStruggleTime { get; set; }
            public float BackJumpDist { get; set; }
        }
        public class EscapeMode
        {
            public float MoveSpeed { get; set; }
        }
        public class floatParamBase
        {
            public bool IsUse { get; set; }
            public float Paramater { get; set; }
        }
        public class GenerateMode
        {
            public float GenerateTime { get; set; }
            public int GenerateSuccessSpawnEm5400 { get; set; }
            public bool IsSpawnBugs { get; set; }
            public float SpawnBugsIntervalTime { get; set; }
            public int SpawnEm5400Num { get; set; }
            public int SpawnEm5520Num { get; set; }
        }
        public class GrappleAttackConditionParam
        {
            public bool IsUse { get; set; }
            public int Priority { get; set; }
            public app.Em3600Directive.floatParamBase InRange { get; set; }
            public app.Em3600Directive.floatParamBase OutRange { get; set; }
            public app.Em3600Directive.floatParamBase FrontAngle { get; set; }
            public app.Em3600Directive.floatParamBase LeftAngle { get; set; }
            public app.Em3600Directive.floatParamBase RightAngle { get; set; }
            public app.Em3600Directive.floatParamBase BackAngle { get; set; }
            public bool IsNotStand { get; set; }
            public bool IsNotSit { get; set; }
            public float Interval { get; set; }
            public float ForwardStepDist { get; set; }
            public float HomingSpeed { get; set; }
            public float LoopWaitTime { get; set; }
        }
        public class LastMode
        {
            public float MoveSpeed { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftPunchL { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftPunchR { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftPunchDown { get; set; }
            public app.Em3600Directive.AttackConditionParam RightPunchL { get; set; }
            public app.Em3600Directive.AttackConditionParam RightPunchR { get; set; }
            public app.Em3600Directive.AttackConditionParam RightPunchDown { get; set; }
            public app.Em3600Directive.AttackConditionParam BothUpperStandUp { get; set; }
            public app.Em3600Directive.GrappleAttackConditionParam MountFourLeg { get; set; }
            public app.Em3600Directive.AttackConditionParam BackStep { get; set; }
            public app.Em3600Directive.SideStepConditionParam SideStepParam { get; set; }
            public app.Em3600Directive.AttackHitIntervalParam AttackHitInterval { get; set; }
        }
        public class NormalBattleMode
        {
            public float MoveSpeedRate { get; set; }
            public float MoveSpeedBlendRateUpSpeed { get; set; }
            public float WarpTimeSec { get; set; }
            public float WarpTimeStopSec { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftPunchL { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftPunchR { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftPunchDown { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftPunchWalk { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftUpper { get; set; }
            public app.Em3600Directive.AttackConditionParam LeftBackSwing { get; set; }
            public app.Em3600Directive.AttackConditionParam RightPunchL { get; set; }
            public app.Em3600Directive.AttackConditionParam RightPunchR { get; set; }
            public app.Em3600Directive.AttackConditionParam RightPunchDown { get; set; }
            public app.Em3600Directive.AttackConditionParam RightPunchWalk { get; set; }
            public app.Em3600Directive.AttackConditionParam RightUpper { get; set; }
            public app.Em3600Directive.AttackConditionParam RightBackSwing { get; set; }
            public app.Em3600Directive.AttackConditionParam BothPunchL { get; set; }
            public app.Em3600Directive.AttackConditionParam BothPunchR { get; set; }
            public app.Em3600Directive.AttackConditionParam BothPunchDown { get; set; }
            public app.Em3600Directive.AttackConditionParam BothPunchBack { get; set; }
            public app.Em3600Directive.AttackConditionParam ThrowR { get; set; }
            public app.Em3600Directive.AttackConditionParam ThrowL { get; set; }
            public app.Em3600Directive.AttackConditionParam ThrowF { get; set; }
            public app.Em3600Directive.GrappleAttackConditionParam Mount { get; set; }
            public app.Em3600Directive.GrappleAttackConditionParam Choke { get; set; }
            public app.Em3600Directive.AttackConditionParam Combo { get; set; }
            public app.Em3600Directive.AttackConditionParam FrontStep { get; set; }
            public app.Em3600Directive.SideStepConditionParam SideStepParam { get; set; }
            public app.Em3600Directive.GrappleAttackConditionParam Raise { get; set; }
            public app.Em3600Directive.GrappleAttackConditionParam Drop { get; set; }
            public app.Em3600Directive.AttackHitIntervalParam AttackHitInterval { get; set; }
            public app.Em3600Directive.ShieldingSpotActionParam ShieldingSpotAction { get; set; }
        }
        public class ShieldingSpotActionParam
        {
            public app.Em3600Directive.floatParamBase InTime { get; set; }
            public app.Em3600Directive.floatParamBase InDamage { get; set; }
            public app.Em3600Directive.floatParamBase Duration { get; set; }
        }
        public class SideStepConditionParam
        {
            public bool IsUse { get; set; }
            public float SideStepThresholdAdd { get; set; }
            public float SideStepThresholdSub { get; set; }
            public float AttackHitThresholdAdd { get; set; }
        }
        public class SneakGrappleStartAttackConditionParam
        {
            public app.Em3600Directive.floatParamBase FrontAngle { get; set; }
            public app.Em3600Directive.floatParamBase InRange { get; set; }
        }
        public class SneakMode
        {
            public float SneakTime { get; set; }
            public float SneakAttackBeforWaitTime { get; set; }
            public float LoopWaitTime { get; set; }
            public app.Em3600Directive.SneakGrappleStartAttackConditionParam CellAttack { get; set; }
            public app.Em3600Directive.SneakGrappleStartAttackConditionParam FloorAttack { get; set; }
            public app.Em3600Directive.SneakGrappleStartAttackConditionParam WindowAttack { get; set; }
        }
        public class WallAttackConditionParam
        {
            public bool IsUse { get; set; }
            public app.Em3600Directive.floatParamBase InRange { get; set; }
            public app.Em3600Directive.floatParamBase OutRange { get; set; }
            public app.Em3600Directive.floatParamBase NeedHeightUp { get; set; }
            public app.Em3600Directive.floatParamBase NeedHeightDown { get; set; }
            public float BeforeInterval { get; set; }
            public float Interval { get; set; }
            public float MaxFallSpeed { get; set; }
            public float AddFallSpeed { get; set; }
            public float HomingRate { get; set; }
            public bool IsLerpRotate { get; set; }
            public float RotateRate { get; set; }
        }
        public class WallMoveMode
        {
            public float WallModeHealthRate { get; set; }
            public float MoveSpeed { get; set; }
            public app.Em3600Directive.WallAttackConditionParam FallAttack { get; set; }
            public app.Em3600Directive.WallAttackConditionParam FallAttackLow { get; set; }
            public app.Em3600Directive.WallAttackConditionParam CellAttack { get; set; }
            public app.Em3600Directive.WallAttackConditionParam FallAttackRev { get; set; }
        }
    }
}

namespace app
{
    public class Em3600DamageController
    {
        public bool Enabled { get; set; } = new();
        public bool IsEnableDebug { get; set; }
        public object DebugDamage { get; set; }
        public object DebugRecovery { get; set; }
        public app.HealthInfo HealthInfo { get; set; }
        public Enums.app.CharacterDefine.Type CharType { get; set; }
        public Enums.app.WeaponID WeaponIDOnDamaged { get; set; }
        public Enums.app.WeaponID AttackerWeaponID { get; set; }
        public Enums.app.EnemyID AttackerEnemyID { get; set; }
        public Enums.app.Collision.HitController.DamageInfo.Scale DamageScale { get; set; }
        public Enums.app.Collision.HitController.DamageInfo.Type DamageType { get; set; }
        public Enums.app.Collision.HitController.DamageInfo.Attribution DamageAttribution { get; set; }
    }
    public class HealthInfo
    {
        public float MaxHealth { get; set; }
        public float Health { get; set; }
    }
}

namespace app
{
    public class Em4000DamageController
    {
        public bool Enabled { get; set; } = new();
        public bool IsEnableDebug { get; set; }
        public object DebugDamage { get; set; }
        public object DebugRecovery { get; set; }
        public app.HealthInfo HealthInfo { get; set; }
        public Enums.app.CharacterDefine.Type CharType { get; set; }
        public Enums.app.WeaponID WeaponIDOnDamaged { get; set; }
        public Enums.app.WeaponID AttackerWeaponID { get; set; }
        public Enums.app.EnemyID AttackerEnemyID { get; set; }
        public Enums.app.Collision.HitController.DamageInfo.Scale DamageScale { get; set; }
        public Enums.app.Collision.HitController.DamageInfo.Type DamageType { get; set; }
        public Enums.app.Collision.HitController.DamageInfo.Attribution DamageAttribution { get; set; }
    }
}

namespace app
{
    public class Em4000BattleDirective
    {
        public app.Em4000BattleDirective.Basic basic { get; set; }
        public app.Em4000BattleDirective.Movement movement { get; set; }
        public app.Em4000BattleDirective.GuardDevise guardDevise { get; set; }
        public app.Em4000BattleDirective.Dodge dodge { get; set; }
        public app.Em4000BattleDirective.Grapple grapple { get; set; }
        public app.Em4000BattleDirective.Strike strike { get; set; }
        public app.Em4000BattleDirective.StrikeUpper strikeUpper { get; set; }
        public app.Em4000BattleDirective.SlashPursuit slashPursuit { get; set; }
        public app.Em4000BattleDirective.Mouth mouth { get; set; }
        public app.Em4000BattleDirective.CancelAttack cancelAttack { get; set; }
        public app.Em4000BattleDirective.BiteCrawl biteCrawl { get; set; }
        public app.Em4000BattleDirective.NearBiteTry nearBiteTry { get; set; }
        public app.Em4000BattleDirective.MiddleBiteTry middleBiteTry { get; set; }
        public app.Em4000BattleDirective.SlashTry slashTry { get; set; }
        public app.Em4000BattleDirective.ExtraBiteTry extraBiteTry { get; set; }
        public app.Em4000BattleDirective.Notice notice { get; set; }
        public app.Em4000BattleDirective.ChanceCounter chanceCounter { get; set; }
        public class AttackBase
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
        }
        public class Base
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
        }
        public class Basic
        {
            public bool isLoverBandRally { get; set; }
            public System.Numerics.Vector2 loverBandRangeForRootTranslate { get; set; }
            public System.Numerics.Vector2 loverBandRangeCrawlForRootTranslate { get; set; }
            public float coverHeadTime { get; set; }
            public float fastStandupRange { get; set; }
            public int needCoverHeadCount { get; set; }
            public System.Numerics.Vector2 crawlIntervalTime { get; set; }
            public System.Numerics.Vector2 crawlMoveTime { get; set; }
            public float dharmaLimitTime { get; set; }
            public float returnAttackRightTimeLimit { get; set; }
            public float appearCancelRange { get; set; }
            public float resumeCancelRange { get; set; }
            public float landingCancelRange { get; set; }
        }
        public class BiteCrawl
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
        }
        public class CancelAttack
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
            public float counterStunLimit { get; set; }
            public float counterHomingRate { get; set; }
            public float counterHomingRateToBack { get; set; }
            public bool canLostPartsCancelAttack { get; set; }
            public bool isOptimizeSide { get; set; }
        }
        public class ChanceCounter
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float nearPlayerRange { get; set; }
        }
        public class Dodge
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float frontAngle { get; set; }
            public System.Numerics.Vector2 range { get; set; }
            public System.Numerics.Vector2 height { get; set; }
            public float aimingTime { get; set; }
            public bool isCancelWithEnd { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
        }
        public class ExtraBiteTry
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
        }
        public class Grapple
        {
            public float timeLimitNormalGrapple { get; set; }
            public float timeLimitMountGrapple { get; set; }
            public float intervalLoopMountGrapple { get; set; }
            public float intervalTime { get; set; }
        }
        public class GuardDevise
        {
            public float backCancelDistance { get; set; }
            public float backCancelToStrikeDistance { get; set; }
            public float backCancelToStrikeAngle { get; set; }
            public float backstepHomingSpeed { get; set; }
            public float backCancelToStrikeHomingSpeed { get; set; }
            public bool isUseCancelSequence { get; set; }
        }
        public class MiddleBiteTry
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
            public System.Numerics.Vector2 limitRange { get; set; }
            public float stayTime { get; set; }
            public float mountRange { get; set; }
            public bool isInvalidFirstAttackAction { get; set; }
        }
        public class Mouth
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
        }
        public class Movement
        {
            public float switchIntervalTime { get; set; }
            public System.Numerics.Vector2 range { get; set; }
            public System.Numerics.Vector2 walkToIdle { get; set; }
            public float idleIntervalTime { get; set; }
            public bool canDamageCancelMove { get; set; }
            public bool canLostPartsCancelMove { get; set; }
            public System.Numerics.Vector2 cancelMoveRange { get; set; }
            public bool canIntervalWait { get; set; }
            public float cancelMoveHomingSpeed { get; set; }
            public float naviCircleValueForStand { get; set; }
            public float naviCircleValueForCrawl { get; set; }
            public float destinationThreshold { get; set; }
            public float animationSpeedRate { get; set; }
        }
        public class NearBiteTry
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
            public float stayTime { get; set; }
            public bool isInvalidForDamage { get; set; }
            public float animationSpeedRate { get; set; }
        }
        public class Notice
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float nearPlayerRange { get; set; }
        }
        public class SlashPursuit
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
        }
        public class SlashTry
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
            public bool isInvalidFirstAttackAction { get; set; }
        }
        public class Strike
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
            public float backstep { get; set; }
            public int countOfMaxCombo { get; set; }
            public bool isUseCrawlCombo { get; set; }
        }
        public class StrikeUpper
        {
            public bool isUse { get; set; }
            public float priorityWeight { get; set; }
            public bool isUseCancelSequence { get; set; }
            public float homingSpeed { get; set; }
            public float angle { get; set; }
            public System.Numerics.Vector2 rangeOverIn { get; set; }
            public System.Numerics.Vector2 heightLowHigh { get; set; }
            public float attackIntervalTime { get; set; }
            public bool isValidGuardDevise { get; set; }
            public bool canFromBack { get; set; }
            public bool canFromBackWithNotice { get; set; }
            public float nearPlayerRange { get; set; }
            public float farPlayerRange { get; set; }
        }
    }
}
