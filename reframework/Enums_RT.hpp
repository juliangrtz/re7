namespace app::Em5540::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        Attack = 2,
        Dead = 3,
        AttackAction = 4,
        DeadAction = 5,
    };
}
namespace app::VideoCameraUIDisp {
    enum Switch {
        ON = 0,
        OFF = 1,
    };
}
namespace app::vr {
    enum AAType {
        None = 0,
        FXAA = 1,
        TAA = 2,
        SMAA = 3,
    };
}
namespace via::wwiselib {
    enum CurveInterpolationType {
        Log3 = 0,
        Sine = 1,
        Log1 = 2,
        InvSCurve = 3,
        Linear = 4,
        SCurve = 5,
        Exp1 = 6,
        SineRecip = 7,
        Exp3 = 8,
    };
}
namespace via::hid::VrTracker {
    enum StopStatus {
        Success = 0,
        NotSupported = -1,
        NotStarted = -2,
        InvalidDeviceHandle = -3,
        UnregisterDeviceFailed = -4,
    };
}
namespace app::EffectDecal {
    enum DecalDirectionEnum {
        XPlus = 0,
        XMinus = 1,
        YPlus = 2,
        YMinus = 3,
        ZPlus = 4,
        ZMinus = 5,
    };
}
namespace via::dynamics {
    enum ShapeCastOption {
        AllHits = 0,
        DisableBackFacingTriangleHits = 1,
        DisableFrontFacingTriangleHits = 2,
        BackFacingTriangleHits = 3,
        FrontFacingTriangleHits = 4,
        NearSort = 5,
        EnableInsideHits = 6,
        OneHitBreak = 7,
        Max = 8,
    };
}
namespace via::puppet::dev::SyncInfo {
    enum Event {
        None = 0,
        SendTransform = 1,
        RecvTransform = 2,
        SendState = 4,
        RecvState = 8,
        Warp = 16,
        SwitchParent = 32,
    };
}
namespace via {
    enum ScreenShotOverlayImageOrigin {
        LeftTop = 1,
        LeftCenter = 2,
        LeftBottom = 3,
        CenterTop = 4,
        CenterCenter = 5,
        CenterBottom = 6,
        RightTop = 7,
        RightCenter = 8,
        RightBottom = 9,
    };
}
namespace via::clr {
    enum EnumI1 {
        Dummy = 0,
    };
}
namespace via::render {
    enum ClearFlag {
        Depth = 1,
        Stencil = 2,
    };
}
namespace app::QuickEquipMenu {
    enum ModeType {
        Normal = 0,
        Inventory = 1,
    };
}
namespace via {
    enum GroupPlacement {
        Top = 0,
        Bottom = 1,
        Natural = 2,
    };
}
namespace app::CH8SaveManager {
    enum ProcStatus {
        Idle = 0,
        Load_CH8_System_Entry = 1,
        Load_CH8_System_Wait = 2,
        Save_CH8_System_Entry = 3,
        Save_CH8_System_Wait = 4,
        DispplayMessage = 5,
    };
}
namespace via::render {
    enum LuminanceBleedFilterType {
        DownSample = 0,
        Variance = 1,
        AdjacentClamping = 2,
        Gaussian = 3,
    };
}
namespace via::network::Core::ShowError {
    enum Phase {
        None = 0,
        ErrorDialogOpen = 1,
        ErrorDialogWait = 2,
        OsMessageDialogOpen = 3,
        OsMessageDialogWait = 4,
        ReModalDialogOpen = 5,
        ReModalDialogWait = 6,
        Finish = 7,
    };
}
namespace via::eq::Var {
    enum Identifier {
        None = 0,
        Constant = 1,
        Override = 2,
    };
}
namespace app::CH9MoldedActionController {
    enum WwiseSwitchListForDamage {
        Head = 0,
        Other = 1,
    };
}
namespace app::MultiSubMenu {
    enum TabTypeDef {
        Album = 0,
        Map = 1,
    };
}
namespace via {
    enum SystemServiceNativeUiOverlaidStatus {
        Unknown = 0,
        NoOverlaid = 1,
        Overlaid = 2,
    };
}
namespace app::Em3100SpawnManager {
    enum UseType {
        Patrol = 0,
        BugHole = 1,
        BugHoleFast = 2,
    };
}
namespace app::Em3000 {
    enum OverrideActionNo {
        Test = 0,
    };
}
namespace app::InventoryItemIcon {
    enum State {
        Default = 0,
        Focus = 1,
        UnFocus = 2,
        Disable = 3,
        DisableFocus = 4,
        DisableUnFocus = 5,
    };
}
namespace app::BirthdayTransitionController {
    enum SaveWaitTypeEnum {
        None = 0,
        Result = 1,
        ModeEnd = 2,
        ModeEndToVrTutorial = 3,
        Max = 4,
    };
}
namespace via::uvsequence {
    enum UVTransform {
        None = 0,
        Rotate90 = 1,
        Rotate180 = 2,
        Rotate270 = 3,
        Reverse = 4,
        ReverseRotate90 = 5,
        ReverseRotate180 = 6,
        ReverseRotate270 = 7,
    };
}
namespace app::Em8100::Action::Dead {
    enum Type {
        Ground = 0,
        Beam = 1,
        Grab = 2,
        Stand = 3,
    };
}
namespace app::OptionMenu {
    enum ConsoleGraphicItem {
        RayTracingMode = 0,
        HighFrameRate = 1,
    };
}
namespace via {
    enum Country {
        Unknown = -1,
        Afghanistan = 4,
        AlandIslands = 248,
        Albania = 8,
        Algeria = 12,
        AmericanSamoa = 16,
        Andorra = 20,
        Angola = 24,
        Anguilla = 660,
        AntArtica = 10,
        AntiguaAndBarbuda = 28,
        Argentina = 32,
        Armenia = 51,
        Aruba = 533,
        Australia = 36,
        Austria = 40,
        Azerbaijan = 31,
        Bahamas = 44,
        Bahrain = 48,
        Bangladesh = 50,
        Barados = 52,
        Belarus = 112,
        Belgium = 56,
        Belize = 84,
        Benin = 204,
        Bermuda = 60,
        Bhutan = 64,
        Bolivia = 68,
        Bonaire = 535,
        BosniaAndHerzegovina = 70,
        Botswana = 72,
        BouvetIsland = 74,
        Brazil = 76,
        BritishIndianOceanTerritory = 86,
        BruneiDarussalam = 96,
        Bulgaria = 100,
        BurkinaFaso = 854,
        Burundi = 108,
        CaboVerde = 132,
        Cambodia = 116,
        Cameroon = 120,
        Canada = 124,
        CaymanIslands = 136,
        CentralAfricanRepublic = 140,
        Chad = 148,
        Chile = 152,
        China = 156,
        ChristmasIsland = 162,
        CocosIslands = 166,
        Colombia = 170,
        Comoros = 174,
        Congo = 178,
        CongoDemocraticRepublic = 180,
        CookIsland = 184,
        CostaRica = 188,
        CotedDIVoire = 384,
        Croatia = 191,
        Cuba = 192,
        Curacao = 531,
        Cyprus = 196,
        CzechRepublic = 203,
        Denmark = 208,
        Djibouti = 262,
        Dominica = 212,
        DominicanRepublic = 214,
        Ecuador = 218,
        Egypt = 818,
        ElSalvador = 222,
        EquatorialGuinea = 226,
        Eritrea = 232,
        Estonia = 233,
        Ethiopia = 231,
        FalkanIslands = 236,
        FaroeIslands = 234,
        Fiji = 242,
        Finland = 246,
        France = 250,
        FrenchGuiana = 254,
        FrenchPolynesia = 258,
        FrenchSouthernTerritories = 260,
        Gabon = 266,
        Gambia = 270,
        Georgia = 268,
        Germany = 276,
        Ghana = 288,
        Gibraltar = 292,
        Greece = 300,
        Greenland = 304,
        Grenada = 308,
        Guadeloupe = 312,
        Guam = 316,
        Guatemala = 320,
        Guernsey = 831,
        Guinea = 324,
        GuineaBissau = 624,
        Guyana = 328,
        Haiti = 332,
        HeardIslandAndMcDonaldIslands = 334,
        Honduras = 340,
        HongKong = 344,
        Hungary = 348,
        Iceland = 352,
        India = 356,
        Indonesia = 360,
        Iran = 364,
        Iraq = 368,
        Ireland = 372,
        IsleOfMan = 833,
        Israel = 376,
        Italy = 380,
        Jamaica = 388,
        Japan = 392,
        Jersey = 832,
        Jordan = 400,
        Kazakhstan = 398,
        Kenya = 404,
        Kiribati = 296,
        NorthKorea = 408,
        SouthKorea = 410,
        Kuwait = 414,
        Kyrgyzstan = 417,
        Laos = 418,
        Latvia = 428,
        Lebanon = 422,
        Lesotho = 426,
        Liberia = 430,
        Libya = 434,
        Liechtenstein = 438,
        Lithuania = 440,
        Luxembourg = 442,
        Macao = 446,
        Macedonia = 807,
        Madagascar = 450,
        Malawi = 454,
        Malaysia = 458,
        Maldives = 462,
        Mali = 466,
        Malta = 470,
        MarshallIslands = 584,
        Martinique = 474,
        Mauritania = 478,
        Mauritius = 480,
        Mayotte = 175,
        Mexico = 484,
        Micronesia = 583,
        Moldova = 498,
        Monaco = 492,
        Mongolia = 496,
        Montenegro = 499,
        Montserrat = 500,
        Morocco = 504,
        Mozambique = 508,
        Myanmar = 104,
        Namibia = 516,
        Nauru = 520,
        Nepal = 524,
        Netherlands = 528,
        NewCaledonia = 540,
        NewZealand = 554,
        Nicaragua = 558,
        Niger = 562,
        Nigeria = 566,
        Niue = 570,
        NorfolkIsland = 574,
        NorthernMarianaIsland = 580,
        Norway = 578,
        Oman = 512,
        Pakistan = 586,
        Palau = 585,
        Palestine = 275,
        Panama = 591,
        PapuaNewGuinea = 598,
        Paraguay = 600,
        Peru = 604,
        Philippines = 608,
        Pitcairn = 612,
        Poland = 616,
        Portugal = 630,
        PuertoRico = 630,
        Qatar = 634,
        Reunion = 638,
        Romania = 642,
        Russia = 643,
        Rwanda = 646,
        SaintBarthelemy = 652,
        SaintHelena = 654,
        SaintKittsAndNevis = 659,
        SaintLucia = 662,
        SaintMartin = 663,
        SaintPierreAndMiquelon = 666,
        SaintVincentAndTheGrenadines = 670,
        Samoa = 882,
        SanMarino = 674,
        SaoTomeAndPrincipe = 678,
        SaudiArabia = 682,
        Senegal = 686,
        Serbia = 688,
        Seychelles = 690,
        SierraLeone = 694,
        Singapore = 702,
        SintMaarten = 534,
        Slovakia = 703,
        Slovenia = 705,
        SolomonIslands = 90,
        Somalia = 706,
        SouthAfrica = 710,
        SouthGeorgiaAndTheSouthSandwichIslands = 239,
        SouthSudan = 728,
        Spain = 724,
        SriLanka = 144,
        Sudan = 729,
        Suriname = 740,
        SvalbardAndJanMayen = 744,
        Swaziland = 756,
        Sweden = 752,
        Switzerland = 756,
        Syria = 760,
        Taiwan = 158,
        Tajikistan = 762,
        Tanzania = 834,
        Thailand = 764,
        TimorLeste = 626,
        Togo = 768,
        Tokelau = 772,
        Tonga = 776,
        TrinidadAndTobago = 780,
        Tunisia = 788,
        Turkey = 792,
        Turkmenistan = 795,
        TurksAndCalcosIslands = 796,
        Tuvalu = 798,
        Uganda = 800,
        Ukraine = 804,
        UnitedArabEmirates = 784,
        UnitedKingdom = 826,
        UnitedStatesMinorOutlyingIslands = 581,
        UnitedStatesOfAmerica = 840,
        Uruguay = 858,
        Uzbekistan = 860,
        Vanauatu = 548,
        VaticanCity = 336,
        Venezuela = 862,
        VietNam = 704,
        VirginIslandsBritish = 92,
        VirginIslandsUS = 850,
        WallisAndFutuna = 876,
        WesternSahara = 732,
        Yemen = 887,
        Zambia = 894,
        Zimbabwe = 716,
        Prchina = 156,
        Czech = 203,
        Hong_kong = 344,
        New_zealand = 554,
        South_korea = 410,
        United_states = 840,
        United_kingdom = 826,
        Uae = 784,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum RayTracingResoultion {
        Origin_Res = 0,
        Half_Res = 1,
    };
}
namespace app::Pl0000EventOnly {
    enum StampRoutine {
        None = 0,
        Recover = 1,
        Wet = 2,
        End = 3,
    };
}
namespace app::Em3600::Action::Step {
    enum Type {
        StepL = 0,
        StepR = 1,
        StepB = 2,
        StepF = 3,
        StepLFast = 4,
        StepRFast = 5,
        StepLFourLeg = 6,
        StepRFourLeg = 7,
        StepBFourLeg = 8,
    };
}
namespace app::InteractObjectBase {
    enum Lv {
        None = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
    };
}
namespace via::gui::detail {
    enum ControlPointV {
        Top = 0,
        Center = 1,
        Bottom = 2,
    };
}
namespace app::Em2100Control {
    enum RequestSetColliderIndex {
        PressMain = 0,
        PressLarge = 1,
    };
}
namespace app::PlayerReticleController {
    enum ReticleDisplayState {
        Hide = 0,
        NoHold = 1,
        CasualHold = 2,
        Hold = 3,
        Firing = 4,
        TargetEnable = 5,
    };
}
namespace app::Nightmare::NightmareTrapUnitWireTrapUpdater {
    enum State {
        Init = 0,
        Wait = 1,
        Expand = 2,
        Finish = 3,
    };
}
namespace via::effect::gpgpu::detail {
    enum NodeBillboardType {
        Bezier = 0,
        Spline = 1,
        Num = 2,
    };
}
namespace app::Em3600::Action::ExMove {
    enum Type {
        Stride = 0,
        GetOver = 1,
    };
}
namespace via::motion::IkLeg2 {
    enum CenterStabilizing {
        None = 0,
        FadeFrame = 1,
        SpeedLimit = 2,
    };
}
namespace System::IO {
    enum SeekOrigin {
        Begin = 0,
        Current = 1,
        End = 2,
    };
}
namespace via::wwise::WwiseGlobalUserVariablesValue {
    enum ComparisonOperator {
        Equal = 0,
        NotEqual = 1,
        LessThan = 2,
        LessThanOrEqual = 3,
        GreaterThan = 4,
        GreaterThanOrEqual = 5,
        Between = 6,
    };
}
namespace app::DoorPush {
    enum OpenSide {
        Front = 0,
        Back = 1,
        Auto = 2,
    };
}
namespace app::Em4000Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace via::audiorender {
    enum SourceType {
        None = 4294967295,
        Wave = 544629111,
        ADPCM = 2003137400,
        Vorbis = 543647599,
        Atrac9 = 540636257,
        XMA = 543255928,
    };
}
namespace via::eq::Operator {
    enum Type {
        Exp = 0,
        Mul = 1,
        Div = 2,
        Mod = 3,
        Add = 4,
        Sub = 5,
    };
}
namespace app::Em3102::Goal {
    enum GoalId {
        Idle = 0,
        Rest = 1,
        Em3102 = 2,
    };
}
namespace via::audiorender {
    enum Channel_4ch {
        L = 0,
        R = 1,
        Ls = 2,
        Rs = 3,
        Max = 4,
    };
}
namespace app::GameEventAction {
    enum StartPosTypeEnum {
        Point = 0,
        Line = 1,
        StartAngleOnly = 2,
    };
}
namespace via::hid {
    enum DeviceKindDetails {
        Unknown = 0,
        Null = 1,
        MergedGamePad = 2,
        MergedKeyboard = 3,
        MergedMouse = 4,
        Dualshock4 = 5,
        DualShock4RemotePlay = 6,
        PSVitaRemotePlay = 7,
        DualSense = 8,
        DualSenseRemotePlay = 9,
        XboxOne = 10,
        XboxOneArcadeStick = 11,
        WindowsXInput = 12,
        WindowsGamingInput = 13,
        WindowsJoypad = 14,
        STADIAController = 15,
        SwitchJoyCon = 16,
        SwitchProController = 17,
        SwitchDebugPad = 18,
        MobileController = 19,
        TouchScreenBuiltIn = 20,
        Keyboard = 21,
        Mouse = 22,
        PlayStationCamera = 23,
        Kinect = 24,
        Morpheus = 25,
        ViveController = 26,
        OculusTouch = 27,
        VirtualKeyboard = 28,
    };
}
namespace via::network::BattleInput {
    enum Error {
        None = 0,
        OpponentNotExist = 1,
        Checksum = 2,
        Timeout = 3,
        User = 4,
    };
}
namespace via::gui {
    enum TextureAssetType {
        UVSequence = 0,
        Texture = 1,
    };
}
namespace app {
    enum WeaponCategory {
        Melee = 0,
        Gun = 1,
        Others = 2,
    };
}
namespace app::InventoryMenu::CursorParam {
    enum TypeDef {
        ItemSlot = 0,
        ItemBoxList = 1,
    };
}
namespace app::PlayerWeaponChange {
    enum ItemType {
        Unknown = 0,
        Weapon = 1,
        Item = 2,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1Final {
    enum DriveCarStatus {
        None = 0,
        Goto = 1,
        CanGetInto = 2,
        Driving = 3,
        End = 4,
    };
}
namespace via::Window::MessageArgs {
    enum PenTabCursor {
        Pen = 1,
        TailSwitch = 2,
    };
}
namespace app::CH9SM2644Movement {
    enum eMotionLayer {
        Base = 0,
        Inertia = 1,
        Damage = 2,
    };
}
namespace app::Chapter3_IMD_Result {
    enum ProcStateEnum {
        Startup = 0,
        WaitResident_1 = 1,
        WaitResident_2 = 2,
        WaitResident_3 = 3,
        InputProc = 4,
        ExitWait = 5,
    };
}
namespace app::CH9TimeAttackTimerHUD {
    enum StepType {
        Display = 0,
        Count = 1,
        End = 2,
    };
}
namespace via::render {
    enum ColorSpace {
        AUTO = 0,
        SRGB = 1,
        HDTV = 2,
        HDR10 = 3,
    };
}
namespace via::os {
    enum MemorySource {
        UserLand = 0,
        Develop = 1,
        KernelLand = 2,
        Default = 0,
    };
}
namespace app::GameEventController {
    enum ProcessType {
        Stop = 0,
        Loading = 1,
        Wait = 2,
        Active = 3,
        End = 4,
    };
}
namespace via::fsm {
    enum SelectTiming {
        Invalid = 0,
        BeforeAction = 1,
        AfterAction = 2,
    };
}
namespace via::storage {
    enum BackgroundInstallSpeed {
        Slow = 0,
        Suspend = 1,
        Fast = 2,
    };
}
namespace app::Em3001::Em3001ActionController {
    enum Message {
        AppearUnDiscovery = 0,
        AppearDiscoveryShort = 1,
        AppearDiscoveryMiddle = 2,
        UnDiscovery = 3,
        Wander = 4,
        WalkFast = 5,
        WalkNormal = 6,
        StepIn = 7,
        AttackHit = 8,
        AttackUnHit = 9,
        AttackGuard = 10,
        DamageGun = 11,
        DamageMeleeFirst = 12,
        DamageMelee = 13,
        NoBullet = 14,
        DeadPL = 15,
        Num = 16,
    };
}
namespace app::Em5400::Action::Damage {
    enum Type {
        DamageS = 0,
        DamageFlyS_L = 1,
        DamageFlyS_R = 2,
        DamageLGround = 3,
    };
}
namespace via::motion::ChainResource {
    enum ChainParamFlags {
        ChianParamFlags_None = 0,
        ReflectEnviromental = 1,
    };
}
namespace via::wwise {
    enum SinkTypePs4 {
        Main = 0,
        MergeToMain = 1,
        Voice = 2,
        Personal = 3,
        PAD = 4,
        BGM = 5,
        Aux = 6,
        DVR = 7,
        SCEAudio3D = 8,
        None = 9,
    };
}
namespace app::SaveDataManager {
    enum PadPairingStateEnum {
        Wait = 0,
        End = 1,
        Sleep = 2,
        RebootMess = 3,
        Reboot = 4,
        PadMess = 5,
        PadWait = 6,
        PadOkCheck = 7,
        AccountPickerWait = 8,
        AccountPickerSuccess = 9,
        AccountPickerError = 10,
        AccountPickerErrorWait = 11,
        AccountPickerGuestError = 12,
    };
}
namespace via::navigation::RelationMapInfo {
    enum Operation {
        CopyAttribute = 0,
        OperationNum = 1,
    };
}
namespace app::PlayerDefine {
    enum DamageEffectDisableLayer {
        Event = 1,
        GameOver = 2,
        Fsm = 4,
    };
}
namespace app::Em8100::Action::TurnWalk {
    enum Type {
        Right = 0,
        Left = 1,
    };
}
namespace app::Em8910Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::CH8StateSwitchExploreTheArea {
    enum CHP8_EXPLORE_THE_AREA {
        safety = 0,
        contamination = 1,
    };
}
namespace app::Em4100::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::hid::textInput {
    enum TextInputKeyboardMode {
        Full = 0,
        Numeric = 1,
        Ascii = 2,
    };
}
namespace app::CH8Em4100ActionController {
    enum DodgeQueType {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH9Em5850::Action::Appear {
    enum Type {
        Born = 0,
        Gather = 1,
        Call = 2,
    };
}
namespace app::fsm::RigidBodyCheck {
    enum TestTypeParam {
        IsBreak = 0,
    };
}
namespace via::math {
    enum FpClassify {
        Infinite = 0,
        Nan = 1,
        Normal = 2,
        SubNormal = 3,
        Zero = 4,
        Unknown = 5,
    };
}
namespace via::motion {
    enum SequenceCategory {
        Game = 0,
        Sound = 1,
        VFX = 2,
        MotSync = 3,
        Physics = 4,
        Extra0 = 5,
        Extra1 = 6,
        Extra2 = 7,
        Extra3 = 8,
        Extra4 = 9,
    };
}
namespace via::navigation::map::PathInfo {
    enum WallOverType {
        NoWall = 0,
        Up = 1,
        Down = 2,
        Same = 3,
        Invalid = 4,
    };
}
namespace app::fsm::SetDoorState {
    enum SetState {
        NotSet = 0,
        Lock = 1,
        Unlock = 2,
        OpenFront = 3,
        OpenBack = 4,
        LittleOpenFront = 5,
        LittleOpenBack = 6,
        ContinuousOpenFront = 7,
        ContinuousOpenBack = 8,
        ContinuousOpenAuto = 9,
        ContinuousLittleOpenFront = 10,
        ContinuousLittleOpenBack = 11,
        ContinuousLittleOpenAuto = 12,
        ContinuousLock = 13,
        ContinuousUnlock = 14,
    };
}
namespace app::BlackOutManager {
    enum FadeColorEnum {
        Black = 0,
        White = 1,
        Max = 2,
    };
}
namespace Em3100Effect {
    enum IDAlias {
        Resident = 0,
        BugGather = 1,
        BugHoleGoki = 2,
        BugDrop = 3,
    };
}
namespace app::Em8100::Em8100ActionController {
    enum MaterialName {
        em8100_head = 0,
        em8100_body = 1,
        em8100_weak01 = 2,
        em8100_weak02 = 3,
        em8100_weak03 = 4,
        em8100_weak04 = 5,
        em8100_weak05 = 6,
        em8100_weak06 = 7,
        em8100_weak07 = 8,
        em8100_weak08 = 9,
        Num = 10,
    };
}
namespace app::UICommand {
    enum InputLevel {
        VrTutorial = 0,
        Normal = 1,
        Cutin = 2,
        EventFade = 3,
        Loading = 4,
        Tips = 5,
        NormalHigh = 6,
        VrSetting = 7,
        SystemCutin = 8,
        NetworkErrorCutin = 9,
        SaveDataErrorCutin = 10,
        AccountErrorCutin = 11,
        Max = 12,
        Invalid = 13,
    };
}
namespace via::render::RenderOutput {
    enum OutputType {
        Default = 0,
        Composite = 1,
        CompositeElement = 2,
    };
}
namespace app::Em5510Think {
    enum BreakState {
        None = 0,
        FirstBreak = 1,
        SecondBreak = 2,
    };
}
namespace app::TinyTimer {
    enum Mode {
        None = 0,
        Up = 1,
        Down = 2,
    };
}
namespace app::JunkPartsUIAsset {
    enum GetPartsState {
        DEFAULT = 0,
        FADE_IN = 1,
        FADE_OUT = 2,
        DISABLE = 3,
    };
}
namespace app::AI::CommonEvaluator::CheckRange {
    enum Type {
        Simple = 0,
        NormalizedRateScore = 1,
        RateScore = 2,
    };
}
namespace via::motion {
    enum InterpolationCurve {
        Linear = 0,
        Smooth = 1,
        EaseIn = 2,
        EaseOut = 3,
    };
}
namespace via::render {
    enum ShaderModifier {
        None = 0,
        ClippingPlane = 1,
        Max = 2,
    };
}
namespace app::CH8Em4000::Goal {
    enum CH8EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromFrontWithDirective = 8,
        IsTargetRun = 9,
        IsTargetCrouching = 10,
        IsTargetDamage = 11,
        IsSlipFire = 12,
        IsSlipAcid = 13,
        AdditiveSensedAttack = 14,
    };
}
namespace via::render::detail {
    enum ConstantBufferType {
        None = 0,
        Polygon3D = 1,
        Polygon2D = 2,
        Mesh = 3,
        Lensflare = 4,
        PrimitiveMaterial = 5,
    };
}
namespace via::motion::IkDamageAction {
    enum DamageTransition {
        Non = 0,
        Impact = 1,
        Transition = 2,
        Damping = 3,
    };
}
namespace via::render::RenderTargetOperator {
    enum Compress {
        None = 0,
        Realtime = 1,
        Hardware = 65,
        JPEG = 2,
        PNG = 3,
        PNG24 = 4,
    };
}
namespace via::dynamics::BoxShape {
    enum VoronoiId {
        PlusX = 0,
        MinusX = 1,
        PlusY = 2,
        MinusY = 3,
        PlusZ = 4,
        MinusZ = 5,
        Max = 6,
    };
}
namespace app::InventoryContextMenu {
    enum ContentEnable {
        Enable = 0,
        OnlyIconDisable = 1,
        Disable = 2,
    };
}
namespace app::CH9Bomb {
    enum BombSetType {
        Oilcan = 0,
        FakeBox = 1,
    };
}
namespace app::fsm::CH8ItemTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace via::motion::detail {
    enum WindType {
        None = 0,
        WindOrSpring = 1,
        GravityWave = 2,
        WindWave = 3,
    };
}
namespace via::motion::LowerBodyRetarget {
    enum EffectorTarget {
        Heal = 0,
        Toe = 1,
    };
}
namespace app::CH8Em4450::Action {
    enum CH8ActionNo {
        Appear = 4,
        Wait = 5,
        AirAttack = 6,
        Grapple = 7,
        falling = 8,
        Avoidance = 9,
        ParryStagger = 10,
        Suspend = 11,
        PrepareExplosion = 12,
    };
}
namespace via::timeline {
    enum RestoreType {
        Linear = 0,
        Descrete = 1,
    };
}
namespace app::Cp7AchievementMenu {
    enum Step {
        Main = 0,
        Decide = 1,
        Reward = 2,
        Retry = 3,
        Quit = 4,
        NewReward = 5,
        NewRewardCutin = 6,
        WaitMain = 7,
    };
}
namespace app::CH8ActivateObjectOperation::OperationData {
    enum IntCompareType {
        Less = 0,
        LessEqual = 1,
        Equal = 2,
        GreaterEqual = 3,
        Greater = 4,
        NotEqual = 5,
    };
}
namespace app::OptionMenu {
    enum LeftFrameState {
        DEFAULT = 0,
        FOUR = 4,
        FIVE = 5,
        SIX = 6,
        SEVEN = 7,
    };
}
namespace app::CH8CaveCheckSwitch {
    enum CaveStateID {
        CHP8_INTRO_START = 0,
        END = 1,
        SILENCE = 2,
        Max = 3,
    };
}
namespace via::render::BlendShapeController {
    enum LodType {
        BakedTexture = 0,
        CalculatedLod = 1,
    };
}
namespace app::PlayerCamera {
    enum VrRotationAngleType {
        Angle1 = 0,
        Angle2 = 1,
        Angle3 = 2,
        Angle4 = 3,
        Angle5 = 4,
        Angle6 = 5,
    };
}
namespace app::CH9Em5700::Action::GroundMove {
    enum Type {
        Normal = 0,
        Reaction = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::MotionDelegate {
    enum HandlerState {
        Fadein = 0,
        Update = 1,
        Fadeout = 2,
        End = 3,
    };
}
namespace via::render::layer::PreDeferredLighting {
    enum Segment {
        SSAO_CompressDepthNormal = 0,
        GeometryAO = 1,
        SSAO_Process = 2,
        SSAO_Resolve = 3,
        IndirectIllumination = 4,
        ParticleDepthOperation = 1,
    };
}
namespace via::landscape {
    enum DummyPipelineType {
        Static = 0,
        Skinning = 1,
        Max = 2,
    };
}
namespace via::wwise {
    enum SinkTypeNSW {
        Main = 0,
        MergeToMain = 1,
        Plugin = 2,
        None = 3,
    };
}
namespace via::hid::gamePlayer {
    enum DevicePickerShowRule {
        None = 0,
        KeepEnoughDevice = 1,
    };
}
namespace via::Window::MessageArgs {
    enum DeviceStatus {
        Arrival = 0,
        Removal = 1,
    };
}
namespace via::storage::saveService {
    enum SaveDataEncryptionPlatform {
        None = 0,
        AutoUse = 1,
        All = 2,
    };
}
namespace via::hid::gamePlayer {
    enum AccountPickerShowRule {
        None = 0,
        DetectValidUserOnly1P = 1,
        DetectValidUser = 2,
        DetectOtherValidUser = 3,
    };
}
namespace via::hansoft {
    enum DataMode {
        None = 0,
        Task = 1,
        Sprint = 2,
        Release = 3,
        QA = 4,
        Backlog = 5,
    };
}
namespace app::PauseMenu {
    enum Step {
        Main = 0,
        GoOutFF = 1,
        Restart = 2,
        Option = 3,
        Quit = 4,
        Load = 5,
        Retry = 6,
        Record = 7,
        FileError = 8,
        StageSelect = 9,
        OtherRestartSaving = 10,
        Achievement = 11,
    };
}
namespace app::PlayerDefine {
    enum ExternalShakeRequester {
        ScriptOrFSM = 0,
        Effect = 1,
    };
}
namespace app::VrGui {
    enum VrTrackRotModeDef {
        Billboard = 0,
        Billboard_YOnly = 1,
        TargetObjBillboard_YOnly = 2,
        None = 3,
    };
}
namespace via::network::error {
    enum CauseContext {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        LinkStateInactive = 129,
        LostAuth = 130,
        NotAuth = 131,
        Banned = 132,
        Expire = 133,
        ServerFull = 134,
        ServerAccessLimited = 135,
        UserAccessLimited = 136,
        AgeRestricted = 138,
        RequireNewVersion = 139,
        UniqueIdChanged = 140,
        ClosedByServer = 141,
    };
}
namespace via::gui::renderer::detail {
    enum PrimCmdType {
        Unknown = 0,
        Polygon = 1,
        Mesh = 2,
        MeshInstancing = 3,
    };
}
namespace via::motion::chain {
    enum WindDelayType {
        None = 0,
        Auto = 1,
        Manual = 2,
    };
}
namespace app::Em8000::Em8000ActionStartPoint {
    enum ActionType {
        None = 0,
        Appear = 1,
        GetScissors = 2,
    };
}
namespace app::Em3001::Goal::Battle {
    enum Message {
        Non = 0,
        AppearEnd = 1,
        Battle1 = 2,
        Battle2 = 3,
    };
}
namespace via::render {
    enum BinnerControl {
        Automatic = 1,
        ForceOn = 2,
        ForceOff = 3,
        Num = 4,
    };
}
namespace app::GameManager {
    enum AnalysisLogTiming {
        Start = 0,
        ChangeOption = 1,
        Clear = 2,
    };
}
namespace via::motion::detail::ChainGroupData {
    enum AngleLimitDirectionMode {
        BasePose = 0,
        MotionPose = 1,
    };
}
namespace app::BirthdayTitle {
    enum SeCallTypeEnum {
        Enter = 0,
        Cancel = 1,
        Cursol = 2,
        Max = 3,
    };
}
namespace app::DoorEventAction {
    enum ProcessType {
        Stop = 0,
        Setup = 1,
        Interp = 2,
        Play = 3,
    };
}
namespace app::vr::VrScreenFilter {
    enum FilterMode {
        Off = 0,
        Small = 1,
        Large = 2,
        Auto = 3,
    };
}
namespace app::CH8Em4100::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        Parry = 2,
    };
}
namespace app::Em3000::Goal {
    enum AppearMessageStatus {
        Non = 0,
        UnDiscovery = 1,
        DiscoveryShort = 2,
        DiscoveryMiddle = 3,
    };
}
namespace via::effect::detail {
    enum LifeType {
        None = 0,
        AppearOnly = 1,
        SyncKeepHold = 2,
    };
}
namespace app::Collision::ContactBaseUserData {
    enum PriorityLevel {
        SystemDefault = 0,
        SystemQuery = 1,
        __________________________P16 = 16,
        Press0_Low = 17,
        Press1 = 18,
        Press2 = 19,
        Press3_Middle = 20,
        Press4 = 21,
        Press5 = 22,
        Press6_High = 23,
        Press7_Fix = 24,
        __________________________P32 = 32,
        Attack0_Low = 33,
        Attack1 = 34,
        Attack2 = 35,
        Attack3_Middle = 36,
        Attack4 = 37,
        Attack5 = 38,
        Attack6_High = 39,
        __________________________P48 = 48,
        Damage0_Low = 49,
        Damage1 = 50,
        Damage2 = 51,
        Damage3_Middle = 52,
        Damage4 = 53,
        Damage5 = 54,
        Damage6_High = 55,
    };
}
namespace app::VideoCameraUI {
    enum ModeDef {
        Start = 0,
        NoiseStrong = 1,
        NoiseAnim = 2,
        NoiseWeak = 3,
        Close = 4,
        StartEnding = 5,
        CloseEnding = 6,
        NoiseAnimEnd = 7,
    };
}
namespace via::fsm {
    enum SystemExecGroup {
        Fsm = 0,
        MotionFsm = 1,
        SystemExecGroupNum = 2,
    };
}
namespace app::CH8SaveManager {
    enum AreaCompartmentStep {
        SlatMineArea = 0,
        Mine01_Battle = 1,
        LuacsLand = 2,
        ShieldMachine = 3,
        Labo = 4,
    };
}
namespace via::motion {
    enum TransitionState {
        None = 0,
        Begin = 1,
        Setuped = 2,
        Update = 3,
        End = 4,
    };
}
namespace via::motion::JointPoseData {
    enum EnableFlags {
        Trans = 1,
        Rotation = 2,
        Scale = 4,
    };
}
namespace via::motion::SupportPolygon {
    enum SupportModeType {
        None = 0,
        FootL = 1,
        FootR = 2,
        FootLR = 3,
    };
}
namespace app::CH9Em7900::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH9Em6400::Action::Confront {
    enum Type {
        Idle = 0,
        Right = 1,
        Left = 2,
    };
}
namespace via::network::RemoteProcedureReceiveQueue {
    enum DeliverResult {
        Success = 0,
        NoMessage = 1,
        RemoteProcedureNotFound = 2,
        MemberNotExist = 3,
    };
}
namespace app::CH9Record {
    enum EverywhereElement {
        Everywhere = 8,
        EverywhereHard = 9,
        Max = 10,
    };
}
namespace app::Em4000::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::render::layer {
    enum SolidSegment {
        Star = 0,
        RayTracing = 1,
        ZPrepass = 2,
        PrepareRoughTransparent = 3,
        DrawRoughTransparent = 4,
        ZIgnoreBegin = 5,
        ZIgnorePrepassSolid = 6,
        ZIgnorePrepassTwoSide = 7,
        ZIgnorePrepassTwoSideAlphaTest = 8,
        ZIgnorePrepassAlphaTest = 9,
        ZIgnoreEnd = 10,
        SolidVfx = 11,
        DrawPostSolidVfx = 12,
        ZIgnoreStencilSolid = 13,
        ZIgnoreStencilTwoSide = 14,
        ZIgnoreStencilTwoSideAlphaTest = 15,
        ZIgnoreStencilAlphaTest = 16,
    };
}
namespace app::CH9MainMenu {
    enum CallSe {
        Cursol = 0,
        Decide = 1,
        Cancel = 2,
    };
}
namespace app::Chain::ChainHelper::ChangeBlendRateProcess {
    enum ChangeStateType {
        None = 0,
        Awake = 1,
        Update = 2,
        Complete = 3,
        Destroyable = 4,
    };
}
namespace app::CH8Em4450::Action::CH8ParryStagger {
    enum AvoidanceType {
        Right = 0,
        Left = 1,
    };
}
namespace app {
    enum RegionType {
        Unknown = 0,
        Japan = 1,
        USA = 2,
        Europe = 3,
        Asia = 4,
    };
}
namespace via::render {
    enum Ownership {
        CPU = 0,
        GPU = 1,
    };
}
namespace app::PlayerDefine {
    enum ExternalShakeType {
        None = 0,
        Small = 1,
        Large = 2,
        SmallLoop = 3,
        LargeLoop = 4,
        Shake = 5,
        VibrationLoop = 6,
    };
}
namespace app::Em5510 {
    enum ThinkState {
        None = 0,
        NoThink = 1,
        Passive = 2,
    };
}
namespace app::fsm::FsmUnlockAchievementDLC {
    enum WrappedID {
        BedroomClear = 0,
        FoundAllMouse = 1,
        NightmareClear = 2,
        NightTerrorClear = 3,
        CrazyHouseClear = 4,
        A21Clear = 5,
        A21SurvivalClear = 6,
        A21SurvivalPlusClear = 7,
        DaughtersBadEnding = 8,
        DaughtersTrueEnding = 9,
    };
}
namespace via::network::error {
    enum MethodUtility {
        Update = 0,
        ShowProfile = 1,
    };
}
namespace app::EnemyActionController {
    enum FaceDirectionType {
        Upward = 0,
        Downward = 1,
    };
}
namespace app::Em8000::Action::Em8000Attack {
    enum Type {
        INVALID = -1,
        None = 0,
        Dash = 1,
        TurnAttack = 2,
        RearAttackL = 3,
        RearAttackR = 4,
        DashBlowAttack = 5,
        DamageCancelBlow = 6,
        PainStream = 7,
        LegCut = 8,
        ZeroFrontBack = 9,
        PropsBreakBlow = 10,
        PropsBreakSwing = 11,
        ShortPainStream = 12,
        ShortBlow = 13,
        CorpsebagCut = 14,
        BreakPillar = 15,
        SUM = 16,
    };
}
namespace via::effect::detail {
    enum EmitterParticleType {
        Unknown = 0,
        Billboard = 1,
        Mesh = 2,
        RibbonFollow = 3,
        RibbonLength = 4,
        RibbonChain = 5,
        FluidEmitter = 6,
        NodeBillboardGPU = 7,
        StrainRibbon = 8,
        NoDraw = 9,
        Polygon = 10,
        RibbonTrail = 11,
        PolygonTrail = 12,
        BillboardGPU = 13,
        PolygonGPU = 14,
        RibbonFixEnd = 15,
        RibbonLightweight = 16,
        RibbonFollowGPU = 17,
        Lightning = 18,
        MeshGPU = 19,
        MeshTrailGPU = 20,
        GpuLightning = 21,
        BillboardMaterial = 22,
        PolygonMaterial = 23,
        RibbonLengthGPU = 24,
        RibbonFollowMaterial = 25,
        RibbonLengthMaterial = 26,
        RibbonChainMaterial = 27,
        RibbonFixEndMaterial = 28,
        RibbonLightweightMaterial = 29,
        StrainRibbonMaterial = 30,
        LightningMaterial = 31,
        PolygonTrailMaterial = 32,
        RibbonParticle = 33,
        ModularBillboard = 34,
        ModularRibbonFollow = 35,
        ModularRibbonLength = 36,
        ModularPolygon = 37,
        ModularMesh = 38,
    };
}
namespace via::effect::gpgpu::Lightning3DCS::Lightning3DResource {
    enum ShaderType {
        Default = 0,
        Default_IgnoreDepth = 1,
        StochasticPreZ = 2,
        StochasticTransparent = 3,
        MaxType = 4,
    };
}
namespace app::CH9Em6400Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
    };
}
namespace app {
    enum ActiveUserPadPairingStatus {
        InitialPairingWait = 0,
        OK = 1,
        ActiveUserChanged = 2,
        ActivePadLost = 3,
    };
}
namespace via::clr {
    enum MetadataType {
        Module = 0,
        TypeRef = 1,
        TypeDef = 2,
        FieldPtr = 3,
        Field = 4,
        MethodPtr = 5,
        MethodDef = 6,
        ParamPtr = 7,
        Param = 8,
        InterfaceImpl = 9,
        MemberRef = 10,
        Constant = 11,
        CustomAttribute = 12,
        FieldMarshal = 13,
        DeclSecurity = 14,
        ClassLayout = 15,
        FieldLayout = 16,
        StandAloneSig = 17,
        EventMap = 18,
        EventPtr = 19,
        Event = 20,
        PropertyMap = 21,
        PropertyPtr = 22,
        Property = 23,
        MethodSemantics = 24,
        MethodImpl = 25,
        ModuleRef = 26,
        TypeSpec = 27,
        ImplMap = 28,
        FieldRVA = 29,
        ENCLog = 30,
        ENCMap = 31,
        Assembly = 32,
        AssemblyProcessor = 33,
        AssemblyOS = 34,
        AssemblyRef = 35,
        AssemblyRefProcessor = 36,
        AssemblyRefOS = 37,
        File = 38,
        ExportedType = 39,
        ManifestResource = 40,
        NestedClass = 41,
        GenericParam = 42,
        MethodSpec = 43,
        GenericParamConstraint = 44,
        Max = 45,
        UserString = 112,
    };
}
namespace via::os {
    enum ThreadPriority {
        TimeCritical = 0,
        Highest = 1,
        AboveNormal = 2,
        Normal = 3,
        BelowNormal = 4,
        Lowest = 5,
        Idle = 6,
        NumOfPriority = 7,
    };
}
namespace app::CH9Em5700Order::Appear {
    enum Type {
        Idle = 0,
        Ground = 1,
        Appear = 2,
        Generate = 3,
        GenerateS = 4,
        GenerateM = 5,
        GenerateL = 6,
    };
}
namespace via::kernel {
    enum XCloudResult {
        OK = 0,
        NoData = 1,
        InvalidArgs = 2,
        FatalError = 3,
    };
}
namespace Em4200Effect {
    enum IDAlias {
        Explosion = 0,
        Splash = 1,
        VerticalSplash = 2,
        HorizontalSplash = 3,
        LostHead = 4,
        LostLeftArm = 5,
        LostRightArm = 6,
        LostLeftLeg = 7,
        LostRightLeg = 8,
        StandSplashFromSequence = 9,
        WalkSplashFromSequence = 10,
        CrawlSplashFromSequence = 11,
        SimpleSplashFromSequence = 12,
        GrappleSplashFromSequence = 13,
        SelfSplashFromSequence = 14,
    };
}
namespace app::CH9Em5700::Action::FlyMove {
    enum Type {
        Normal = 0,
        LookTarget = 1,
    };
}
namespace via::network::session {
    enum SearchKeyAttr {
        None = 0,
    };
}
namespace app::PauseMenu {
    enum ListElemID {
        GoOutFF = 0,
        Restart = 1,
        Option = 2,
        End = 3,
        Load = 4,
    };
}
namespace via::render::RenderLayer {
    enum Priority {
        TopMost = 16777216,
        Top = 50331648,
        AboveDefault = 67108864,
        Default = 83886080,
        Bottom = 117440512,
        BelowDefault = 100663296,
        BottomMost = 150994944,
    };
}
namespace app::CH8RewardArticle {
    enum DifficultyBits {
        Casual = 1,
        Normal = 2,
        Hard = 4,
    };
}
namespace via::render {
    enum ByteBufferDataType {
        None = 0,
        Byte = 1,
        Integer = 2,
        Float = 3,
    };
}
namespace via::landscape::layer::LandformBlendLayer {
    enum BlendLayerPipelineStateType {
        BlendHeightMap = 0,
        BlendUneditableMask = 1,
        Max = 2,
    };
}
namespace app::network {
    enum EventWriterType {
        ETX = 0,
        XSAPI = 1,
    };
}
namespace via::motion::JointExMultiRemapValue::AimConstraintData {
    enum WorldUpType {
        SceneUp = 0,
        ObjectUp = 1,
        ObjectRotationUp = 2,
        Vector = 3,
        None = 4,
    };
}
namespace app::Em3102::Action::Branch {
    enum Type {
        None = 0,
        BranchR = 1,
        BranchL = 2,
        BranchMadR = 3,
        BranchMadL = 4,
    };
}
namespace via::hid::gamePlayer {
    enum AssignMethodType {
        None = 0,
        SelectUser = 1,
        UserEqualPlayer = 2,
        PlatformDefault = 3,
    };
}
namespace via::motion {
    enum ExpressionUpdate {
        MotionBegin = 0,
        MotionEnd = 1,
        ConstraintsBegin = 2,
        ConstraintsEnd = 3,
        Last = 4,
        ByBehavior = 5,
    };
}
namespace via::network::native::NswProfileInfo {
    enum ImageSize {
        Size64x64 = 0,
        Size128x128 = 1,
        Size256x256 = 2,
        Standard = 2,
    };
}
namespace via::PlaneXZ {
    enum NGLevel {
        None = 0,
        NanFinite = 1,
        Assert = 2,
        Default = 1,
    };
}
namespace via::audiorender {
    enum Channel_3oAmb {
        Channel_3oAmb_0 = 0,
        Channel_3oAmb_1 = 1,
        Channel_3oAmb_2 = 2,
        Channel_3oAmb_3 = 3,
        Channel_3oAmb_4 = 4,
        Channel_3oAmb_5 = 5,
        Channel_3oAmb_6 = 6,
        Channel_3oAmb_7 = 7,
        Channel_3oAmb_8 = 8,
        Channel_3oAmb_9 = 9,
        Channel_3oAmb_10 = 10,
        Channel_3oAmb_11 = 11,
        Channel_3oAmb_12 = 12,
        Channel_3oAmb_13 = 13,
        Channel_3oAmb_14 = 14,
        Channel_3oAmb_15 = 15,
        Channel_3oAmb_Max = 16,
    };
}
namespace via::hid {
    enum VibrationOutputNode {
        Dual = 0,
        LeftOnly = 1,
        RightOnly = 2,
        LeftAndRightSeparately = 3,
    };
}
namespace app::FootEffectController {
    enum SETriggerTypeEnum {
        LeftLegContact = 0,
        RightLegContact = 1,
        LeftLegSlide = 2,
        RightLegSlide = 3,
        LeftLegStep = 4,
        RightLegStep = 5,
        LeftHandContact = 6,
        RightHandContact = 7,
        Num = 8,
    };
}
namespace via::hid {
    enum GamePadButton {
        LUp = 1,
        LDown = 2,
        LLeft = 4,
        LRight = 8,
        RUp = 16,
        RDown = 32,
        RLeft = 64,
        RRight = 128,
        LTrigTop = 256,
        LTrigBottom = 512,
        RTrigTop = 1024,
        RTrigBottom = 2048,
        LStickPush = 4096,
        RStickPush = 8192,
        CLeft = 16384,
        CRight = 32768,
        CCenter = 65536,
        Decide = 131072,
        Cancel = 262144,
        PlatformHome = 524288,
        EmuLup = 1048576,
        EmuLright = 2097152,
        EmuLdown = 4194304,
        EmuLleft = 8388608,
        EmuRup = 16777216,
        EmuRright = 33554432,
        EmuRdown = 67108864,
        EmuRleft = 134217728,
        EmuAll = 267386880,
        LSL = 268435456,
        LSR = 536870912,
        RSL = 1073741824,
        RSR = 2147483648,
        LSide = 268435456,
        RSide = 536870912,
        None = 0,
        All = 4294967295,
    };
}
namespace via::motion::IkFourLeg {
    enum RayCastCallbackID {
        BackLeft = 1,
        BackRight = 2,
        ForeLeft = 4,
        ForeRight = 8,
        Detail = 16,
        BackLeftDetail = 17,
        BackRightDetail = 18,
        ForeLeftDetail = 20,
        ForeRightDetail = 24,
        Base = 32,
        BackLeftBase = 33,
        BackRightBase = 34,
        ForeLeftBase = 36,
        ForeRightBase = 40,
    };
}
namespace app::Em3001::Action::Rest {
    enum Type {
        Rest1 = 0,
        Rest2 = 1,
        Rest3 = 2,
        Rest4 = 3,
        Rest5 = 4,
        Rest6 = 5,
    };
}
namespace via::clr {
    enum EnumI4 {
        Dummy = 0,
    };
}
namespace app::Em8001 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Battle = 2,
        DeadPause = 3,
    };
}
namespace via::effect::detail {
    enum ExpressionOperator {
        Addition = 0,
        Subtraction = 1,
        Multiplication = 2,
        Division = 3,
        Assign = 4,
        ForceWord = 4294967295,
    };
}
namespace app::Em8001::Action::Walk {
    enum WalkType {
        INVALID = -1,
        None = 0,
        Normal = 1,
        Fast = 2,
        SUM = 3,
    };
}
namespace app::OptionKeyBind {
    enum SlotType {
        Primary = 0,
        Secondary = 1,
    };
}
namespace via::render {
    enum LightSourceModel {
        Version1 = 0,
        Version2 = 1,
        Invalid = -1,
    };
}
namespace via::motion::IkMultipleDamageAction {
    enum DebugDamageTransition {
        Non = 0,
        ImpactState = 1,
        MaxState = 2,
    };
}
namespace via::gui::Effect2D {
    enum DefaultExternParam {
        EffectPosX = 0,
        EffectPosY = 1,
        EffectScaleX = 2,
        EffectScaleY = 3,
        EffectRot = 4,
    };
}
namespace via::motion::RetargetFourLegRig {
    enum ChainCalcAxis {
        BaseLocal = 0,
        BaseControlRoot = 1,
    };
}
namespace via::motion::tree {
    enum LinkType {
        Unknown = 0,
        Motion = 1,
        Param = 2,
    };
}
namespace via::navigation::algorithm::MapGraphAstar {
    enum PassStateEnterWallType {
        None = 0,
        Bottom = 1,
        Top = 2,
        Side = 3,
    };
}
namespace via::render {
    enum ShadowCastFlag {
        A = 1,
        B = 2,
        ALL = 3,
    };
}
namespace via::sound {
    enum SoundGraphAxisType {
        Linear = 0,
        Db = 1,
    };
}
namespace via::navigation::AIMapEffectorCore {
    enum ExtraLinkCreationResult {
        Success = 0,
        Fail = 1,
        Retry = 2,
    };
}
namespace app::Item {
    enum ItemCategoryType {
        OtherItem = 0,
        Weapon = 1,
        Shell = 2,
        Drug = 3,
        KeyItem = 4,
        File = 5,
        Map = 6,
        Material = 7,
        StackWeapon = 8,
        UsableKeyItem = 9,
        DiscardableKeyItem = 10,
        SupplyBox = 11,
        Max = 12,
    };
}
namespace app::Em8000::Em8000AditiveDamageInfo {
    enum DamageDirection {
        INVALID = -1,
        None = 0,
        Front = 1,
        Back = 2,
        Left = 4,
        Right = 8,
        SUM = 15,
    };
}
namespace via::render::command {
    enum TypeId {
        Clear = 0,
        CopyTexture = 1,
        CopyBuffer = 2,
        DrawIndexed = 3,
        Draw = 4,
        DrawIndexedInstanced = 5,
        DrawIndexedInstancedIndirect = 6,
        DrawInstanced = 7,
        MultiDrawIndexedInstancedIndirect = 8,
        MultiDrawIndexedInstancedIndirectCount = 9,
        Dispatch = 10,
        DispatchIndirect = 11,
        UpdateConstantBuffer = 12,
        UpdateBuffer = 13,
        Marker = 14,
        DepthBoundsTest = 15,
        RecordedCommand = 16,
        AsyncDispatch = 17,
        Fence = 18,
        FenceWithSyncPoint = 19,
        DispatchRay = 20,
        BuildTLAS = 21,
        BuildBLAS = 22,
        CompactBLAS = 23,
        XB1Extention = 24,
        PS4Extention = 25,
        NVNExtention = 26,
        PS5Extention = 27,
        VKExtension = 28,
        DirectXExtention = 29,
    };
}
namespace app::VrGui {
    enum DistanceCorrectMode {
        NOSET = 0,
        NONE = 1,
        FLEXIBLE = 2,
        CLOSE = 3,
    };
}
namespace via::simplewwise {
    enum AudioInputModuleType {
        None = 0,
        Movie = 1,
        Mame = 2,
    };
}
namespace app::CH9Em7900::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::network::storage {
    enum Target {
        None = 0,
        Local = 1,
        Native = 2,
    };
}
namespace app::Em3100::Message {
    enum TagMessage {
        None = 0,
        BugHole_BattleStart_A_0 = 1,
        BugHole_Common_A_0 = 2,
        BugHole_Common_B_0 = 3,
        BugHole_High_A_0 = 4,
        BugHole_High_B_0 = 5,
        BugHole_Instruct_Common_A_0 = 6,
        BugHole_Instruct_Common_F_0 = 7,
        BugHole_Instruct_Common_G_0 = 8,
        BugHole_Instruct_Common_H_0 = 9,
        BugHole_Instruct_High_A_0 = 10,
        BugHole_Instruct_High_B_0 = 11,
        BugHole_Instruct_High_C_0 = 12,
        BugHole_TargetUseLadder_A_0 = 13,
        BugHole_TargetUseLadder_B_0 = 14,
        BugHole_TargetUseLadder_C_0 = 15,
        BugHole_StunEnd_A_0 = 16,
        BugHole_StunEnd_B_0 = 17,
        BugHole_StunEnd_C_0 = 18,
        FF_Discovery_A_0 = 19,
        FF_Discovery_B_0 = 20,
        FF_Discovery_C_0 = 21,
        FF_DeathGrapple_A_0 = 22,
        FF_DeathGrapple_B_0 = 23,
        Patrol_Common_A_0 = 24,
        Patrol_Common_B_0 = 25,
        Patrol_Common_C_0 = 26,
        Patrol_Common_D_0 = 27,
        Patrol_Common_E_0 = 28,
        Patrol_Common_F_0 = 29,
        Patrol_Discovery_Miss_A_0 = 30,
        Patrol_Discovery_Miss_B_0 = 31,
        Patrol_Discovery_Miss_C_0 = 32,
        Patrol_Lost_Player_A_0 = 33,
        Patrol_Lost_Player_B_0 = 34,
        Patrol_Discovery_A_0 = 35,
        Patrol_Discovery_B_0 = 36,
        Patrol_Discovery_C_0 = 37,
        PatrolInstruct_Common_A_0 = 38,
        PatrolInstruct_Common_B_0 = 39,
        PatrolInstruct_Common_C_0 = 40,
        PatrolInstruct_Common_D_0 = 41,
        PatrolInstruct_Common_E_0 = 42,
        PatrolInstruct_Common_F_0 = 43,
        FallDownGrapple_A_0 = 44,
    };
}
namespace via::nnfc::nfp {
    enum NfpType {
        CharacterFigure = 0,
        CharacterCard = 1,
        KnittedFigure = 2,
        Unknown = 254,
        Invalid = 255,
    };
}
namespace app::BirthdayGameData {
    enum BirthdayWepType {
        MiaKnife = 0,
        ChainSaw = 1,
        Knife = 2,
        Bar = 3,
        CircularSaw = 4,
        Axe = 5,
        GoldenBar = 6,
        Handgun_M19 = 7,
        Handgun_M19_L = 8,
        Handgun_G17 = 9,
        Handgun_G17_L = 10,
        Handgun_MPM = 11,
        Handgun_MPM_L = 12,
        Handgun_Albert_Reward = 13,
        Handgun_Albert_Reward_L = 14,
        Shotgun_M37 = 15,
        Shotgun_M37S = 16,
        Shotgun_DB = 17,
        MachineGun = 18,
        Magnum = 19,
        Burner = 20,
        FlameBulletS = 21,
        AcidBulletS = 22,
        HyperBlaster = 23,
        HyperBlaster_L = 24,
        TrapBomb = 25,
        LiquidBomb = 26,
        BoxBomb = 27,
        BoxBomb_02 = 28,
        Em4200Effect = 29,
        Em4200Bomb = 30,
        BlueBlaster = 31,
        RedBlaster = 32,
        MAX = 33,
    };
}
namespace app::fsm::RequestFadeInOut_HideIcon {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace via::network::error {
    enum CauseNative {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
    };
}
namespace via::behaviortree {
    enum ExecGroup {
        ExecGroup_00 = 0,
        ExecGroup_01 = 1,
        ExecGroup_02 = 2,
        ExecGroup_03 = 3,
        ExecGroup_04 = 4,
        ExecGroup_05 = 5,
        ExecGroup_06 = 6,
        ExecGroup_07 = 7,
    };
}
namespace app::vr {
    enum Eye {
        Left = 0,
        Right = 1,
    };
}
namespace via::clr {
    enum IL {
        IL_nop = 0,
        IL_break = 1,
        IL_ldarg_0 = 2,
        IL_ldarg_1 = 3,
        IL_ldarg_2 = 4,
        IL_ldarg_3 = 5,
        IL_ldloc_0 = 6,
        IL_ldloc_1 = 7,
        IL_ldloc_2 = 8,
        IL_ldloc_3 = 9,
        IL_stloc_0 = 10,
        IL_stloc_1 = 11,
        IL_stloc_2 = 12,
        IL_stloc_3 = 13,
        IL_ldarg_s = 14,
        IL_ldarga_s = 15,
        IL_starg_s = 16,
        IL_ldloc_s = 17,
        IL_ldloca_s = 18,
        IL_stloc_s = 19,
        IL_ldnull = 20,
        IL_ldc_i4_m1 = 21,
        IL_ldc_i4_0 = 22,
        IL_ldc_i4_1 = 23,
        IL_ldc_i4_2 = 24,
        IL_ldc_i4_3 = 25,
        IL_ldc_i4_4 = 26,
        IL_ldc_i4_5 = 27,
        IL_ldc_i4_6 = 28,
        IL_ldc_i4_7 = 29,
        IL_ldc_i4_8 = 30,
        IL_ldc_i4_s = 31,
        IL_ldc_i4 = 32,
        IL_ldc_i8 = 33,
        IL_ldc_r4 = 34,
        IL_ldc_r8 = 35,
        IL_0x24 = 36,
        IL_dup = 37,
        IL_pop = 38,
        IL_jmp = 39,
        IL_call = 40,
        IL_calli = 41,
        IL_ret = 42,
        IL_br_s = 43,
        IL_brfalse_s = 44,
        IL_brtrue_s = 45,
        IL_beq_s = 46,
        IL_bge_s = 47,
        IL_bgt_s = 48,
        IL_ble_s = 49,
        IL_blt_s = 50,
        IL_bne_un_s = 51,
        IL_bge_un_s = 52,
        IL_bgt_un_s = 53,
        IL_ble_un_s = 54,
        IL_blt_un_s = 55,
        IL_br = 56,
        IL_brfalse = 57,
        IL_brtrue = 58,
        IL_beq = 59,
        IL_bge = 60,
        IL_bgt = 61,
        IL_ble = 62,
        IL_blt = 63,
        IL_bne_un = 64,
        IL_bge_un = 65,
        IL_bgt_un = 66,
        IL_ble_un = 67,
        IL_blt_un = 68,
        IL_switch = 69,
        IL_ldind_i1 = 70,
        IL_ldind_u1 = 71,
        IL_ldind_i2 = 72,
        IL_ldind_u2 = 73,
        IL_ldind_i4 = 74,
        IL_ldind_u4 = 75,
        IL_ldind_i8 = 76,
        IL_ldind_i = 77,
        IL_ldind_r4 = 78,
        IL_ldind_r8 = 79,
        IL_ldind_ref = 80,
        IL_stind_ref = 81,
        IL_stind_i1 = 82,
        IL_stind_i2 = 83,
        IL_stind_i4 = 84,
        IL_stind_i8 = 85,
        IL_stind_r4 = 86,
        IL_stind_r8 = 87,
        IL_add = 88,
        IL_sub = 89,
        IL_mul = 90,
        IL_div = 91,
        IL_div_un = 92,
        IL_rem = 93,
        IL_rem_un = 94,
        IL_and = 95,
        IL_or = 96,
        IL_xor = 97,
        IL_shl = 98,
        IL_shr = 99,
        IL_shr_un = 100,
        IL_neg = 101,
        IL_not = 102,
        IL_conv_i1 = 103,
        IL_conv_i2 = 104,
        IL_conv_i4 = 105,
        IL_conv_i8 = 106,
        IL_conv_r4 = 107,
        IL_conv_r8 = 108,
        IL_conv_u4 = 109,
        IL_conv_u8 = 110,
        IL_callvirt = 111,
        IL_cpobj = 112,
        IL_ldobj = 113,
        IL_ldstr = 114,
        IL_newobj = 115,
        IL_castclass = 116,
        IL_isinst = 117,
        IL_conv_r_un = 118,
        IL_unbox = 121,
        IL_throw = 122,
        IL_ldfld = 123,
        IL_ldflda = 124,
        IL_stfld = 125,
        IL_ldsfld = 126,
        IL_ldsflda = 127,
        IL_stsfld = 128,
        IL_stobj = 129,
        IL_conv_ovf_i1_un = 130,
        IL_conv_ovf_i2_un = 131,
        IL_conv_ovf_i4_un = 132,
        IL_conv_ovf_i8_un = 133,
        IL_conv_ovf_u1_un = 134,
        IL_conv_ovf_u2_un = 135,
        IL_conv_ovf_u4_un = 136,
        IL_conv_ovf_u8_un = 137,
        IL_conv_ovf_i_un = 138,
        IL_conv_ovf_u_un = 139,
        IL_box = 140,
        IL_newarr = 141,
        IL_ldlen = 142,
        IL_ldelema = 143,
        IL_ldelem_i1 = 144,
        IL_ldelem_u1 = 145,
        IL_ldelem_i2 = 146,
        IL_ldelem_u2 = 147,
        IL_ldelem_i4 = 148,
        IL_ldelem_u4 = 149,
        IL_ldelem_i8 = 150,
        IL_ldelem_i = 151,
        IL_ldelem_r4 = 152,
        IL_ldelem_r8 = 153,
        IL_ldelem_ref = 154,
        IL_stelem_i = 155,
        IL_stelem_i1 = 156,
        IL_stelem_i2 = 157,
        IL_stelem_i4 = 158,
        IL_stelem_i8 = 159,
        IL_stelem_r4 = 160,
        IL_stelem_r8 = 161,
        IL_stelem_ref = 162,
        IL_ldelem = 163,
        IL_stelem = 164,
        IL_unbox_any = 165,
        IL_conv_ovf_i1 = 179,
        IL_conv_ovf_u1 = 180,
        IL_conv_ovf_i2 = 181,
        IL_conv_ovf_u2 = 182,
        IL_conv_ovf_i4 = 183,
        IL_conv_ovf_u4 = 184,
        IL_conv_ovf_i8 = 185,
        IL_conv_ovf_u8 = 186,
        IL_refanyval = 194,
        IL_ckfinite = 195,
        IL_mkrefany = 198,
        IL_ldtoken = 208,
        IL_conv_u2 = 209,
        IL_conv_u1 = 210,
        IL_conv_i = 211,
        IL_conv_ovf_i = 212,
        IL_conv_ovf_u = 213,
        IL_add_ovf = 214,
        IL_add_ovf_un = 215,
        IL_mul_ovf = 216,
        IL_mul_ovf_un = 217,
        IL_sub_ovf = 218,
        IL_sub_ovf_un = 219,
        IL_endfinally = 220,
        IL_leave = 221,
        IL_leave_s = 222,
        IL_stind_i = 223,
        IL_conv_u = 224,
        IL_arglist = 65024,
        IL_ceq = 65025,
        IL_cgt = 65026,
        IL_cgt_un = 65027,
        IL_clt = 65028,
        IL_clt_un = 65029,
        IL_ldftn = 65030,
        IL_ldvirtftn = 65031,
        IL_ldarg = 65033,
        IL_ldarga = 65034,
        IL_starg = 65035,
        IL_ldloc = 65036,
        IL_ldloca = 65037,
        IL_stloc = 65038,
        IL_localloc = 65039,
        IL_endfilter = 65041,
        IL_unaligned = 65042,
        IL_volatile = 65043,
        IL_tail = 65044,
        IL_initobj = 65045,
        IL_constrained = 65046,
        IL_cpblk = 65047,
        IL_initblk = 65048,
        IL_rethrow = 65050,
        IL_sizeof = 65052,
        IL_refanytype = 65053,
        IL_readonly = 65054,
    };
}
namespace via::timeline {
    enum TimelineState {
        Play = 0,
        Pause = 1,
    };
}
namespace via {
    enum GameLiveStreamingStatus {
        Disable = -1,
        Failed = -2,
        Stop = 0,
        OnAir = 1,
    };
}
namespace app::Nightmare {
    enum TrapLevel {
        Init = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        End = 4,
    };
}
namespace app::GameManager {
    enum GameMode {
        Title = 0,
        Gameover = 1,
        NormalGame = 2,
        Extra00 = 3,
        Extra01 = 4,
    };
}
namespace app::AI::AIVisionBeacon {
    enum VisionType {
        Unknown = 0,
        Player = 1,
        Enemy = 2,
        WanderPoint = 3,
    };
}
namespace app::CH8FadeControlForEvent {
    enum FadeRequestEnum {
        None = 0,
        FadeIn = 1,
        FadeOut = 2,
    };
}
namespace app::Em2000 {
    enum ThinkOrder {
        None = 0,
        Chapter4_3_Sleep = 1,
    };
}
namespace app::Em3000::Action::StepIn {
    enum Type {
        Straight = 0,
        Side = 1,
        Thrust = 2,
        Grab = 3,
        TStraight = 4,
        TSide = 5,
        TThrust = 6,
        TGrab = 7,
    };
}
namespace app::CH8Em4200::CH8ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::movie {
    enum VideoDecoderMode {
        Default = 0,
        Hardware = 1,
        Cpu = 2,
    };
}
namespace app::Em8001::Action {
    enum ActionNo {
        Idle = 0,
        BattleIdle = 1,
        Rest = 2,
        EngineStop = 3,
        Dead = 4,
        OpenDoor = 5,
        Acid = 6,
        Walk = 7,
        WalkTurn = 8,
        Attack = 9,
        AttackCombo = 10,
        Damage = 11,
        DamageDown = 12,
        Grapple = 13,
    };
}
namespace app::CH9Em7700ActionController::BattleCondition {
    enum WanderIdleActionType {
        None = 0,
        AfterNotice = 1,
        BeforeNotice = 2,
    };
}
namespace via::vr {
    enum VrDeviceType {
        Invalid = 0,
        HMD = 1,
        Controller = 2,
        Tracker = 3,
        TrackingReference = 4,
        Unknown = 5,
    };
}
namespace via::wwise {
    enum PhysicsValueType {
        LinearVelocity = 0,
        AngularVelocity = 1,
        FrictionFactor = 2,
        Momentum = 3,
        AngularMomemtum = 4,
        MassTimesFrictionFactor = 5,
    };
}
namespace via::audiorender {
    enum PrepareType {
        None = 0,
        Sec = 1,
        Marker = 2,
        BarBeat = 3,
    };
}
namespace app::EPVDataBase {
    enum EffectRelationType {
        FollowParent = 0,
        InitializationParent = 1,
        World = 2,
        WorldAng = 3,
        FollowCamera = 4,
        FollowCameraPos = 5,
        CameraNodeBillboard = 6,
    };
}
namespace app::fsm::PositionCheck::CameraParam {
    enum CameraTargetSetting {
        TargetObject = 0,
        OwnerObject = 1,
    };
}
namespace app::CH8Em4000::Goal::CH8GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Release = 2,
        Mimicry = 3,
        ExtraWait = 4,
        Destination = 5,
        Discovery = 6,
        DiscoveryWhite = 7,
        UnDiscovery = 8,
        ClosedRoute = 9,
        IdleLostTarget = 10,
        Idle = 11,
        Follow = 12,
        Grapple = 13,
        SlashTry = 14,
        MiddleBiteTry = 15,
        NearBiteTry = 16,
        BiteCrawl = 17,
        StrikeUpper = 18,
        Strike = 19,
        StrikeCrawl = 20,
        Mouth = 21,
        SlashPursuit = 22,
        Dodge = 23,
        Door = 24,
        DoorOpen = 25,
        DoorOpen2 = 26,
        DoorClose = 27,
        DoorClose2 = 28,
        Move = 29,
        AppearAction = 30,
        IdleAction = 31,
        NoticeAction = 32,
        StrikeUpperAction = 33,
        StrikeAction = 34,
        StrikeCrawlAction = 35,
        SlashPursuitAction = 36,
        SlashTryAction = 37,
        MouthAction = 38,
        BiteCrawlAction = 39,
        NearBiteTryAction = 40,
        MiddleBiteTryAction = 41,
        ExtraBiteTryAction = 42,
        DodgeAction = 43,
        GrappleAction = 44,
        MimicryIdle = 45,
        MimicryRelease = 46,
        ExtraBiteTry = 47,
        WaitAttack = 48,
        WhiteBackStrike = 49,
        WhiteFeintStrike = 50,
        WhiteComboStrike = 51,
        WhitePowerfulStrike = 52,
        WhiteStrikeAction = 53,
        WhiteSpoit = 54,
    };
}
namespace via::nnfc::nfp {
    enum FontRegion {
        JpUsEu = 0,
        China = 1,
        Korea = 2,
        Taiwan = 3,
        Count = 4,
        Term = 4,
        Min = 0,
        Max = 3,
    };
}
namespace app::fsm::SetMansionAI {
    enum SetType {
        Enable = 0,
        Disable = 1,
    };
}
namespace app::CH9Em7700::Action::WanderIdle {
    enum Type {
        Normal = 0,
    };
}
namespace app::AI::MansionAIEffectorZoneGroup {
    enum ConditionTypeEnum {
        InPlayer = 0,
        InEnemy = 1,
        InPlayerAndEnemy = 2,
    };
}
namespace app::Em2000::Action::Chapter1Battle4DestroyObject {
    enum Type {
        DestroyObjectL = 0,
        DestroyObjectR = 1,
    };
}
namespace via::effect::gpgpu::DeformedMesh::MeshCsResource {
    enum SkinningShaderType {
        SkinningShaderType_None = 0,
        SkinningShaderType_None_StorePrimaryUV = 1,
        SkinningShaderType_None_StoreSecondaryUV = 2,
        SkinningShaderType_None_StorePrimarySecondaryUV = 3,
        SkinningShaderType_4w = 4,
        SkinningShaderType_4w_StorePrimaryUV = 5,
        SkinningShaderType_4w_StoreSecondaryUV = 6,
        SkinningShaderType_4w_StorePrimarySecondaryUV = 7,
        SkinningShaderType_6w = 8,
        SkinningShaderType_6w_StorePrimaryUV = 9,
        SkinningShaderType_6w_StoreSecondaryUV = 10,
        SkinningShaderType_6w_StorePrimarySecondaryUV = 11,
        SkinningShaderType_8w = 12,
        SkinningShaderType_8w_StorePrimaryUV = 13,
        SkinningShaderType_8w_StoreSecondaryUV = 14,
        SkinningShaderType_8w_StorePrimarySecondaryUV = 15,
        SkinningShaderType_12w = 16,
        SkinningShaderType_12w_StorePrimaryUV = 17,
        SkinningShaderType_12w_StoreSecondaryUV = 18,
        SkinningShaderType_12w_StorePrimarySecondaryUV = 19,
        SkinningShaderType_Max = 20,
    };
}
namespace app::Em3001::Em3001WwiseMonitoredValue {
    enum PropertyLayer {
        Discovery = 0,
        UnDiscovery = 1,
        DamageDown = 2,
        Max = 3,
    };
}
namespace app::ControlMaterial {
    enum ParamType {
        Float4 = 1,
        Float = 2,
    };
}
namespace via::render {
    enum E2DStretchMode {
        None = 0,
        Fit = 1,
        Stretch = 2,
        Flexible = 3,
    };
}
namespace via::collision {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
        Num = 3,
    };
}
namespace via::audiorender {
    enum StreamBlockStatus {
        None = 0,
        Standby = 1,
        WaitDecode = 2,
        Decoding = 3,
        Decoded = 4,
        StreamEnd = 5,
        WaitStream = 6,
        DecodeFailed = 7,
        Error = 8,
    };
}
namespace app::Em8100 {
    enum OverrideActionNo {
        Test = 0,
    };
}
namespace via::render {
    enum VFXPrimitiveShadingRate {
        Coarse1x1 = 0,
        Coarse1x2 = 1,
        Coarse2x1 = 2,
        Coarse2x2 = 3,
        Coarse2x4 = 4,
        Coarse4x2 = 5,
        Coarse4x4 = 6,
    };
}
namespace via::gui {
    enum LinkMoveDirection {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4,
    };
}
namespace via::simplewwise {
    enum GameObjectIdIndex {
        Driver = 1,
        Manager = 2,
        Listener_0 = 3,
        Listener_1 = 4,
        Listener_2 = 5,
        Listener_3 = 6,
        Listener_4 = 7,
        Listener_5 = 8,
        Listener_6 = 9,
        Listener_7 = 10,
        Offset = 11,
    };
}
namespace app::CH8Telemetry {
    enum TimerType {
        CH8BossBattle = 0,
        CH8AllClear = 1,
    };
}
namespace app::Collision::CollisionSystem {
    enum AsyncCastRayState {
        Unknown = 0,
        NotYet = 1,
        True = 2,
        False = 3,
    };
}
namespace app::Em5400::Action::Grapple {
    enum Type {
        Stab = 0,
    };
}
namespace via::motion::Fsm2ActionPlayMotion {
    enum FrameControl {
        Normal = 0,
        SyncBaseLayerNormalizeTime = 1,
        PauseStartFrame = 2,
        PauseEndFrame = 3,
    };
}
namespace app::Richpresence {
    enum ContextType {
        Easy = 0,
        Normal = 1,
        Hard = 2,
        Invalid = -1,
    };
}
namespace via::gui {
    enum InputListType {
        None = 0,
        UpDown = 1,
        LeftRight = 2,
        LBRB = 3,
        Max = 4,
    };
}
namespace via::behaviortree::TreeNode {
    enum WorkFlags {
        IsNotifiedEnd = 1,
        HasEvaluated = 2,
        HasSelected = 4,
        IsCalledActionPrestart = 8,
        IsCalledActionStart = 16,
        IsNotifiedUnderLayerEnd = 32,
        IsBranchState = 64,
        IsEndState = 128,
        IsStartedSelector = 256,
        OverridedSelector = 512,
        DuplicatedAction = 1024,
        IsAsRestartable = 2048,
    };
}
namespace via::motion::DevelopRetargetResource {
    enum RetargetJointNameType {
        HeadName = 0,
        NeckName = 1,
        Spine0Name = 2,
        Spine1Name = 3,
        Spine2Name = 4,
        Spine3Name = 5,
        Spine4Name = 6,
        HipsName = 7,
        LShoulderName = 8,
        LArmName = 9,
        LForeArmName = 10,
        LHandName = 11,
        LThumbName = 12,
        LIndexName = 13,
        LMiddleName = 14,
        LRingName = 15,
        LPinkyName = 16,
        RShoulderName = 17,
        RArmName = 18,
        RForeArmName = 19,
        RHandName = 20,
        RThumbName = 21,
        RIndexName = 22,
        RMiddleName = 23,
        RRingName = 24,
        RPinkyName = 25,
        LUpLegName = 26,
        LLegName = 27,
        LFootName = 28,
        LToeName = 29,
        RUpLegName = 30,
        RLegName = 31,
        RFootName = 32,
        RToeName = 33,
        MAX = 34,
    };
}
namespace app::Nightmare {
    enum ResultScoreGroup {
        None = 0,
        FinalJunkPartsNum = 1,
        EnemyKillNum = 2,
        FinalWaveState = 3,
        PenaltyCraftItem = 4,
    };
}
namespace app::Em5510::Action {
    enum ActionNo {
        Idle = 0,
        Damage = 1,
        Dead = 2,
        Generate = 3,
    };
}
namespace via::render::Atmosphere2 {
    enum IBLTextureBakeMode {
        Panorama = 0,
        Cubemap = 1,
    };
}
namespace via::motion {
    enum BlendMode {
        Overwrite = 0,
        AddBlend = 1,
        Private = 2,
    };
}
namespace via::io::file::FileInfo {
    enum ATTR {
        DIRECTORY = 1,
        ARCHIVABLE = 2,
        HIDDEN = 4,
        NORMAL = 8,
        READONLY = 16,
        SYSTEM = 32,
    };
}
namespace app::Em3002::Em3002WwiseMonitoredValue {
    enum PropertyEncount {
        InCamera = 0,
        OutCamera = 1,
        Max = 2,
    };
}
namespace via::motion::Chain {
    enum WindDirection {
        Global = 0,
        Local = 1,
    };
}
namespace app::CH8Em4500::Action::CH8ConsecutiveStrike {
    enum ConboType {
        Two = 0,
        Four = 1,
    };
}
namespace app::CH8Em4500::Action::CH8JumpUp {
    enum JumpType {
        Normal = 0,
        ModeChange = 1,
        ModeRunaway = 2,
    };
}
namespace via::gui {
    enum CommonState {
        Default = 0,
        Focus = 1,
        Select = 2,
        Unfocus = 3,
        Disable = 4,
        DisableFocus = 5,
        DisableSelect = 6,
        DisableUnfocus = 7,
        FadeIn = 8,
        FadeOut = 9,
        Decide = 10,
        PlusInput = 11,
        MinusInput = 12,
        Max = 13,
    };
}
namespace via::storage::saveService {
    enum SaveState {
        None = 0,
        IDLE = 1,
        SaveDialogStart = 2,
        LoadDialogStart = 3,
        RemoveDialogStart = 4,
        SaveDialogRun = 5,
        LoadDialogRun = 6,
        RemoveDialogRun = 7,
        DialogIDLE = 8,
        SaveStart = 9,
        LoadStart = 10,
        RemoveStart = 11,
        RemoveAllSlotStart = 12,
        CheckExistingStart = 13,
        ExportToMemoryStart = 14,
        ImportFromMemoryStart = 15,
        ReleaseImportMemoryStart = 16,
        LoadMetadataFromMemoryStart = 17,
        SaveRun = 18,
        LoadRun = 19,
        RemoveRun = 20,
        RemoveAllSlotRun = 21,
        CheckExistingRun = 22,
        ExportToMemoryRun = 23,
        ImportFromMemoryRun = 24,
        ReleaseImportMemoryRun = 25,
        LoadMetadataFromMemoryRun = 26,
        UploadTelemetryStart = 27,
        DownloadTelemetryStart = 28,
        UploadTelemetryRun = 29,
        DownloadTelemetryRun = 30,
        ErrorDialog = 31,
        Max = 32,
    };
}
namespace via::render::MaterialParam {
    enum ResourceType {
        Unkown = 0,
        ByteBuffer = 1,
    };
}
namespace app::CH8InfraredTrap {
    enum WireState {
        Invisible = 0,
        Visible = 1,
        Disable = 2,
    };
}
namespace app::Grenade {
    enum UpdateRno {
        Wait = 0,
        Move = 1,
        Explosion = 2,
        Residual = 3,
        Sleep = 4,
    };
}
namespace via::motion::IkLeg2 {
    enum EffectorOffsetCtrl {
        None = 0,
        Local = 1,
        World = 2,
    };
}
namespace app::BirthdayTransitionController {
    enum TransitionTypeEnum {
        None = 0,
        NormalJump = 1,
        Restrat = 2,
    };
}
namespace via::storage::saveService::detail::exportToMemory {
    enum ExportToMemoryVersion {
        ExportToMemoryVersion_Invalid = 0,
        ExportToMemoryVersion_1 = 1,
        ExportToMemoryVersion_Latest = 1,
    };
}
namespace via::render::RenderTargetOperator {
    enum StreamState {
        NotRequested = 0,
        Failed = 1,
        Requested = 2,
        Processing = 3,
        Finished = 4,
    };
}
namespace app::CH8Em4500::Action::CH8Swoon {
    enum SwoonType {
        Default = 0,
        Quick = 1,
    };
}
namespace app::EnemyActionController {
    enum DamageType {
        Strike = 0,
        Slash = 1,
        Shoot = 2,
        Shapeless = 3,
        Landscape = 4,
    };
}
namespace app::MovementController {
    enum SubAdjustType {
        None = 0,
        Position = 1,
        Rotation = 2,
    };
}
namespace via::motion::IkLeg {
    enum ToeCtrlOption {
        None = 0,
        TwoRayCast = 1,
        ToeOnly = 2,
    };
}
namespace via::effect::detail {
    enum PtClipAttribute {
        BindToLife = 1,
    };
}
namespace via::hid {
    enum DeviceType {
        Unknown = 0,
        Null = 1,
        GeneralGamePad = 2,
        GeneralArcadeStick = 3,
        SpecialGamePad = 4,
        Dualshock4 = 5,
        DualSense = 6,
        XboxOneWirelessController = 7,
        Npad = 8,
        STADIAGamePad = 9,
        TouchScreen = 10,
        Keyboard = 11,
        Mouse = 12,
        PlayStationCamera = 13,
        Kinect = 14,
        Morpheus = 15,
        VRController = 16,
        SwitchSoftwareKeyboard = 17,
        SwitchInlineSoftwareKeyboard = 18,
        PS4SoftwareKeyboard = 19,
        XboxOneSoftwareKeyboard = 20,
        GameCoreSoftwareKeyboard = 21,
        PS5SoftwareKeyboard = 22,
        AndroidSoftwareKeyboard = 23,
        IOSSoftwareKeyboard = 24,
        STADIASoftwareKeyboard = 25,
    };
}
namespace app::InventoryMenu {
    enum TabIndex {
        Item = 0,
        CombineList = 1,
        Num = 2,
    };
}
namespace via::motion::ActionPlayMotion {
    enum FrameControl {
        Normal = 0,
        SyncBaseLayer = 1,
        PauseStartFrame = 2,
        PauseEndFrame = 3,
    };
}
namespace app::CH9Em6700ActionController {
    enum SuspendStatus {
        None = 0,
        Requested = 1,
        Suspending = 2,
        Completed = 3,
    };
}
namespace via::hid {
    enum AccountPickerResults {
        Null = 0,
        Completed = 1,
        Failed = 2,
    };
}
namespace app::IKMultiBone {
    enum SolverType {
        CyclicCoordinateDescent = 0,
        Particle = 1,
    };
}
namespace app::cutin::CutinHandle2Choice {
    enum ResultDef {
        Select1 = 0,
        Select2 = 1,
        Undecided = 2,
    };
}
namespace app::Em5520::Action {
    enum ActionNo {
        Idle = 0,
        Move = 1,
        Attack = 2,
        Damage = 3,
        Dead = 4,
        Appear = 5,
        Leave = 6,
        Suspend = 7,
    };
}
namespace via::render::detail {
    enum PrimitiveVfxShader {
        Billboard2D = 0,
        Billboard2DOverdraw = 1,
        Billboard2DTexUnit = 2,
        Billboard2DTexUnitOverdraw = 3,
        Billboard2DTexUnitOverdrawSplitRGBA = 4,
        Billboard2DTexUnitSplitRGBA = 5,
        Billboard3D = 6,
        Billboard3DDisableTest = 7,
        Billboard3DDisableTestTextureBlend = 8,
        Billboard3DDisableTestTextureBlendNoSoft = 9,
        Billboard3DDisableTestTextureBlendNoSoftNorm = 10,
        Billboard3DDisableTestTextureBlendNorm = 11,
        Billboard3DDisableTestNoSoft = 12,
        Billboard3DDisableTestNoSoftNorm = 13,
        Billboard3DDisableTestNorm = 14,
        Billboard3DTextureBlend = 15,
        Billboard3DTextureBlendNoSoft = 16,
        Billboard3DTextureBlendNoSoftNorm = 17,
        Billboard3DTextureBlendNorm = 18,
        Billboard3DNoSoft = 19,
        Billboard3DNoSoftNorm = 20,
        Billboard3DNorm = 21,
        Billboard3DLighting = 22,
        Billboard3DLightingDisableTest = 23,
        Billboard3DLightingDisableTestTextureBlend = 24,
        Billboard3DLightingDisableTestTextureBlendNoSoft = 25,
        Billboard3DLightingDisableTestTextureBlendNoSoftNorm = 26,
        Billboard3DLightingDisableTestTextureBlendNorm = 27,
        Billboard3DLightingDisableTestNoSoft = 28,
        Billboard3DLightingDisableTestNoSoftNorm = 29,
        Billboard3DLightingDisableTestNorm = 30,
        Billboard3DLightingTextureBlend = 31,
        Billboard3DLightingTextureBlendNoSoft = 32,
        Billboard3DLightingTextureBlendNoSoftNorm = 33,
        Billboard3DLightingTextureBlendNorm = 34,
        Billboard3DLightingNoSoft = 35,
        Billboard3DLightingNoSoftNorm = 36,
        Billboard3DLightingNorm = 37,
        Billboard3DMieLighting = 38,
        Billboard3DMieLightingDisableTest = 39,
        Billboard3DMieLightingDisableTestTextureBlend = 40,
        Billboard3DMieLightingDisableTestTextureBlendNoSoft = 41,
        Billboard3DMieLightingDisableTestTextureBlendNoSoftNorm = 42,
        Billboard3DMieLightingDisableTestTextureBlendNorm = 43,
        Billboard3DMieLightingDisableTestNoSoft = 44,
        Billboard3DMieLightingDisableTestNoSoftNorm = 45,
        Billboard3DMieLightingDisableTestNorm = 46,
        Billboard3DMieLightingTextureBlend = 47,
        Billboard3DMieLightingTextureBlendNoSoft = 48,
        Billboard3DMieLightingTextureBlendNoSoftNorm = 49,
        Billboard3DMieLightingTextureBlendNorm = 50,
        Billboard3DMieLightingNoSoft = 51,
        Billboard3DMieLightingNoSoftNorm = 52,
        Billboard3DMieLightingNorm = 53,
        Billboard3DLuminanceBleed = 54,
        Billboard3DLuminanceBleedDisableTest = 55,
        Billboard3DLuminanceBleedDisableTestTextureBlend = 56,
        Billboard3DLuminanceBleedDisableTestTextureBlendNoSoft = 57,
        Billboard3DLuminanceBleedDisableTestTextureBlendNoSoftNorm = 58,
        Billboard3DLuminanceBleedDisableTestTextureBlendNorm = 59,
        Billboard3DLuminanceBleedDisableTestNoSoft = 60,
        Billboard3DLuminanceBleedDisableTestNoSoftNorm = 61,
        Billboard3DLuminanceBleedDisableTestNorm = 62,
        Billboard3DLuminanceBleedTextureBlend = 63,
        Billboard3DLuminanceBleedTextureBlendNoSoft = 64,
        Billboard3DLuminanceBleedTextureBlendNoSoftNorm = 65,
        Billboard3DLuminanceBleedTextureBlendNorm = 66,
        Billboard3DLuminanceBleedNoSoft = 67,
        Billboard3DLuminanceBleedNoSoftNorm = 68,
        Billboard3DLuminanceBleedNorm = 69,
        Billboard3DCutout = 70,
        Billboard3DCutoutDisableTest = 71,
        Billboard3DCutoutDisableTestNoSoft = 72,
        Billboard3DCutoutDisableTestNoSoftNorm = 73,
        Billboard3DCutoutDisableTestNorm = 74,
        Billboard3DCutoutNoSoft = 75,
        Billboard3DCutoutNoSoftNorm = 76,
        Billboard3DCutoutNorm = 77,
        Billboard3DCutoutLighting = 78,
        Billboard3DCutoutLightingDisableTest = 79,
        Billboard3DCutoutLightingDisableTestNoSoft = 80,
        Billboard3DCutoutLightingDisableTestNoSoftNorm = 81,
        Billboard3DCutoutLightingDisableTestNorm = 82,
        Billboard3DCutoutLightingNoSoft = 83,
        Billboard3DCutoutLightingNoSoftNorm = 84,
        Billboard3DCutoutLightingNorm = 85,
        Billboard3DCutoutMieLighting = 86,
        Billboard3DCutoutMieLightingDisableTest = 87,
        Billboard3DCutoutMieLightingDisableTestNoSoft = 88,
        Billboard3DCutoutMieLightingDisableTestNoSoftNorm = 89,
        Billboard3DCutoutMieLightingDisableTestNorm = 90,
        Billboard3DCutoutMieLightingNoSoft = 91,
        Billboard3DCutoutMieLightingNoSoftNorm = 92,
        Billboard3DCutoutMieLightingNorm = 93,
        Billboard3DCutoutLuminanceBleed = 94,
        Billboard3DCutoutLuminanceBleedDisableTest = 95,
        Billboard3DCutoutLuminanceBleedDisableTestNoSoft = 96,
        Billboard3DCutoutLuminanceBleedDisableTestNoSoftNorm = 97,
        Billboard3DCutoutLuminanceBleedDisableTestNorm = 98,
        Billboard3DCutoutLuminanceBleedNoSoft = 99,
        Billboard3DCutoutLuminanceBleedNoSoftNorm = 100,
        Billboard3DCutoutLuminanceBleedNorm = 101,
        Billboard3DTexUnit = 102,
        Billboard3DTexUnitDisableTest = 103,
        Billboard3DTexUnitDisableTestNoSoft = 104,
        Billboard3DTexUnitDisableTestNoSoftSplitRGBA = 105,
        Billboard3DTexUnitDisableTestNoSoftSplitRGBANorm = 106,
        Billboard3DTexUnitDisableTestNoSoftNorm = 107,
        Billboard3DTexUnitDisableTestSplitRGBA = 108,
        Billboard3DTexUnitDisableTestSplitRGBANorm = 109,
        Billboard3DTexUnitDisableTestNorm = 110,
        Billboard3DTexUnitNoSoft = 111,
        Billboard3DTexUnitNoSoftSplitRGBA = 112,
        Billboard3DTexUnitNoSoftSplitRGBANorm = 113,
        Billboard3DTexUnitNoSoftNorm = 114,
        Billboard3DTexUnitSplitRGBA = 115,
        Billboard3DTexUnitSplitRGBANorm = 116,
        Billboard3DTexUnitNorm = 117,
        Billboard3DTexUnitLighting = 118,
        Billboard3DTexUnitLightingDisableTest = 119,
        Billboard3DTexUnitLightingDisableTestNoSoft = 120,
        Billboard3DTexUnitLightingDisableTestNoSoftSplitRGBA = 121,
        Billboard3DTexUnitLightingDisableTestNoSoftSplitRGBANorm = 122,
        Billboard3DTexUnitLightingDisableTestNoSoftNorm = 123,
        Billboard3DTexUnitLightingDisableTestSplitRGBA = 124,
        Billboard3DTexUnitLightingDisableTestSplitRGBANorm = 125,
        Billboard3DTexUnitLightingDisableTestNorm = 126,
        Billboard3DTexUnitLightingNoSoft = 127,
        Billboard3DTexUnitLightingNoSoftSplitRGBA = 128,
        Billboard3DTexUnitLightingNoSoftSplitRGBANorm = 129,
        Billboard3DTexUnitLightingNoSoftNorm = 130,
        Billboard3DTexUnitLightingSplitRGBA = 131,
        Billboard3DTexUnitLightingSplitRGBANorm = 132,
        Billboard3DTexUnitLightingNorm = 133,
        Billboard3DShadow = 134,
        Billboard3DShadowNorm = 135,
        Billboard3DShadowNormTranslucent = 136,
        Billboard3DShadowTranslucent = 137,
        Billboard3DCutoutShadow = 138,
        Billboard3DCutoutShadowNorm = 139,
        Billboard3DCutoutShadowNormTranslucent = 140,
        Billboard3DCutoutShadowTranslucent = 141,
        Billboard3DTexUnitShadow = 142,
        Billboard3DTexUnitShadowSplitRGBA = 143,
        Billboard3DTexUnitShadowSplitRGBANorm = 144,
        Billboard3DTexUnitShadowSplitRGBANormTranslucent = 145,
        Billboard3DTexUnitShadowSplitRGBATranslucent = 146,
        Billboard3DTexUnitShadowNorm = 147,
        Billboard3DTexUnitShadowNormTranslucent = 148,
        Billboard3DTexUnitShadowTranslucent = 149,
        Billboard3DHdr = 150,
        Billboard3DHdrDisableTest = 151,
        Billboard3DHdrDisableTestNoSoft = 152,
        Billboard3DHdrDisableTestNoSoftNorm = 153,
        Billboard3DHdrDisableTestNorm = 154,
        Billboard3DHdrNoSoft = 155,
        Billboard3DHdrNoSoftNorm = 156,
        Billboard3DHdrNorm = 157,
        Polygon = 158,
        PolygonDisableTest = 159,
        PolygonDisableTestTextureBlend = 160,
        PolygonDisableTestTextureBlendNoSoft = 161,
        PolygonDisableTestNoSoft = 162,
        PolygonTextureBlend = 163,
        PolygonTextureBlendNoSoft = 164,
        PolygonNoSoft = 165,
        PolygonLighting = 166,
        PolygonLightingDisableTest = 167,
        PolygonLightingDisableTestTextureBlend = 168,
        PolygonLightingDisableTestTextureBlendNoSoft = 169,
        PolygonLightingDisableTestNoSoft = 170,
        PolygonLightingTextureBlend = 171,
        PolygonLightingTextureBlendNoSoft = 172,
        PolygonLightingNoSoft = 173,
        PolygonMieLighting = 174,
        PolygonMieLightingDisableTest = 175,
        PolygonMieLightingDisableTestTextureBlend = 176,
        PolygonMieLightingDisableTestTextureBlendNoSoft = 177,
        PolygonMieLightingDisableTestNoSoft = 178,
        PolygonMieLightingTextureBlend = 179,
        PolygonMieLightingTextureBlendNoSoft = 180,
        PolygonMieLightingNoSoft = 181,
        PolygonLuminanceBleed = 182,
        PolygonLuminanceBleedDisableTest = 183,
        PolygonLuminanceBleedDisableTestTextureBlend = 184,
        PolygonLuminanceBleedDisableTestTextureBlendNoSoft = 185,
        PolygonLuminanceBleedDisableTestNoSoft = 186,
        PolygonLuminanceBleedTextureBlend = 187,
        PolygonLuminanceBleedTextureBlendNoSoft = 188,
        PolygonLuminanceBleedNoSoft = 189,
        PolygonStrip = 190,
        PolygonStripDisableTest = 191,
        PolygonStripDisableTestTextureBlend = 192,
        PolygonStripDisableTestTextureBlendNoSoft = 193,
        PolygonStripDisableTestNoSoft = 194,
        PolygonStripTextureBlend = 195,
        PolygonStripTextureBlendNoSoft = 196,
        PolygonStripNoSoft = 197,
        PolygonStripLighting = 198,
        PolygonStripLightingDisableTest = 199,
        PolygonStripLightingDisableTestTextureBlend = 200,
        PolygonStripLightingDisableTestTextureBlendNoSoft = 201,
        PolygonStripLightingDisableTestNoSoft = 202,
        PolygonStripLightingTextureBlend = 203,
        PolygonStripLightingTextureBlendNoSoft = 204,
        PolygonStripLightingNoSoft = 205,
        PolygonStripMieLighting = 206,
        PolygonStripMieLightingDisableTest = 207,
        PolygonStripMieLightingDisableTestTextureBlend = 208,
        PolygonStripMieLightingDisableTestTextureBlendNoSoft = 209,
        PolygonStripMieLightingDisableTestNoSoft = 210,
        PolygonStripMieLightingTextureBlend = 211,
        PolygonStripMieLightingTextureBlendNoSoft = 212,
        PolygonStripMieLightingNoSoft = 213,
        PolygonStripLuminanceBleed = 214,
        PolygonStripLuminanceBleedDisableTest = 215,
        PolygonStripLuminanceBleedDisableTestTextureBlend = 216,
        PolygonStripLuminanceBleedDisableTestTextureBlendNoSoft = 217,
        PolygonStripLuminanceBleedDisableTestNoSoft = 218,
        PolygonStripLuminanceBleedTextureBlend = 219,
        PolygonStripLuminanceBleedTextureBlendNoSoft = 220,
        PolygonStripLuminanceBleedNoSoft = 221,
        PolygonShadow = 222,
        PolygonShadowTranslucent = 223,
        PolygonStripShadow = 224,
        PolygonStripShadowTranslucent = 225,
        Ribbon = 226,
        RibbonDisableTest = 227,
        RibbonDisableTestTextureBlend = 228,
        RibbonDisableTestTextureBlendNoSoft = 229,
        RibbonDisableTestTextureBlendNoSoftNorm = 230,
        RibbonDisableTestTextureBlendNorm = 231,
        RibbonDisableTestNoSoft = 232,
        RibbonDisableTestNoSoftNorm = 233,
        RibbonDisableTestNorm = 234,
        RibbonTextureBlend = 235,
        RibbonTextureBlendNoSoft = 236,
        RibbonTextureBlendNoSoftNorm = 237,
        RibbonTextureBlendNorm = 238,
        RibbonNoSoft = 239,
        RibbonNoSoftNorm = 240,
        RibbonNorm = 241,
        RibbonLighting = 242,
        RibbonLightingDisableTest = 243,
        RibbonLightingDisableTestTextureBlend = 244,
        RibbonLightingDisableTestTextureBlendNoSoft = 245,
        RibbonLightingDisableTestTextureBlendNoSoftNorm = 246,
        RibbonLightingDisableTestTextureBlendNorm = 247,
        RibbonLightingDisableTestNoSoft = 248,
        RibbonLightingDisableTestNoSoftNorm = 249,
        RibbonLightingDisableTestNorm = 250,
        RibbonLightingTextureBlend = 251,
        RibbonLightingTextureBlendNoSoft = 252,
        RibbonLightingTextureBlendNoSoftNorm = 253,
        RibbonLightingTextureBlendNorm = 254,
        RibbonLightingNoSoft = 255,
        RibbonLightingNoSoftNorm = 256,
        RibbonLightingNorm = 257,
        RibbonMieLighting = 258,
        RibbonMieLightingDisableTest = 259,
        RibbonMieLightingDisableTestTextureBlend = 260,
        RibbonMieLightingDisableTestTextureBlendNoSoft = 261,
        RibbonMieLightingDisableTestTextureBlendNoSoftNorm = 262,
        RibbonMieLightingDisableTestTextureBlendNorm = 263,
        RibbonMieLightingDisableTestNoSoft = 264,
        RibbonMieLightingDisableTestNoSoftNorm = 265,
        RibbonMieLightingDisableTestNorm = 266,
        RibbonMieLightingTextureBlend = 267,
        RibbonMieLightingTextureBlendNoSoft = 268,
        RibbonMieLightingTextureBlendNoSoftNorm = 269,
        RibbonMieLightingTextureBlendNorm = 270,
        RibbonMieLightingNoSoft = 271,
        RibbonMieLightingNoSoftNorm = 272,
        RibbonMieLightingNorm = 273,
        RibbonLuminanceBleed = 274,
        RibbonLuminanceBleedDisableTest = 275,
        RibbonLuminanceBleedDisableTestTextureBlend = 276,
        RibbonLuminanceBleedDisableTestTextureBlendNoSoft = 277,
        RibbonLuminanceBleedDisableTestTextureBlendNoSoftNorm = 278,
        RibbonLuminanceBleedDisableTestTextureBlendNorm = 279,
        RibbonLuminanceBleedDisableTestNoSoft = 280,
        RibbonLuminanceBleedDisableTestNoSoftNorm = 281,
        RibbonLuminanceBleedDisableTestNorm = 282,
        RibbonLuminanceBleedTextureBlend = 283,
        RibbonLuminanceBleedTextureBlendNoSoft = 284,
        RibbonLuminanceBleedTextureBlendNoSoftNorm = 285,
        RibbonLuminanceBleedTextureBlendNorm = 286,
        RibbonLuminanceBleedNoSoft = 287,
        RibbonLuminanceBleedNoSoftNorm = 288,
        RibbonLuminanceBleedNorm = 289,
        RibbonShadow = 290,
        RibbonShadowNorm = 291,
        RibbonShadowNormTranslucent = 292,
        RibbonShadowTranslucent = 293,
        FluidBillboard = 294,
        FluidBillboardDisableTest = 295,
        FluidBillboardDisableTestNoSoft = 296,
        FluidBillboardNoSoft = 297,
        FluidBillboardLighting = 298,
        FluidBillboardLightingDisableTest = 299,
        FluidBillboardLightingDisableTestNoSoft = 300,
        FluidBillboardLightingNoSoft = 301,
        FluidBillboardMieLighting = 302,
        FluidBillboardMieLightingDisableTest = 303,
        FluidBillboardMieLightingDisableTestNoSoft = 304,
        FluidBillboardMieLightingNoSoft = 305,
        FluidPolygon = 306,
        FluidPolygonDisableTest = 307,
        FluidPolygonDisableTestNoSoft = 308,
        FluidPolygonNoSoft = 309,
        FluidPolygonLighting = 310,
        FluidPolygonLightingDisableTest = 311,
        FluidPolygonLightingDisableTestNoSoft = 312,
        FluidPolygonLightingNoSoft = 313,
        FluidPolygonMieLighting = 314,
        FluidPolygonMieLightingDisableTest = 315,
        FluidPolygonMieLightingDisableTestNoSoft = 316,
        FluidPolygonMieLightingNoSoft = 317,
        FluidPolygonStrip = 318,
        FluidPolygonStripDisableTest = 319,
        FluidPolygonStripDisableTestNoSoft = 320,
        FluidPolygonStripNoSoft = 321,
        FluidPolygonStripLighting = 322,
        FluidPolygonStripLightingDisableTest = 323,
        FluidPolygonStripLightingDisableTestNoSoft = 324,
        FluidPolygonStripLightingNoSoft = 325,
        FluidPolygonStripMieLighting = 326,
        FluidPolygonStripMieLightingDisableTest = 327,
        FluidPolygonStripMieLightingDisableTestNoSoft = 328,
        FluidPolygonStripMieLightingNoSoft = 329,
        FluidRibbon = 330,
        FluidRibbonDisableTest = 331,
        FluidRibbonDisableTestNoSoft = 332,
        FluidRibbonNoSoft = 333,
        FluidRibbonLighting = 334,
        FluidRibbonLightingDisableTest = 335,
        FluidRibbonLightingDisableTestNoSoft = 336,
        FluidRibbonLightingNoSoft = 337,
        FluidRibbonMieLighting = 338,
        FluidRibbonMieLightingDisableTest = 339,
        FluidRibbonMieLightingDisableTestNoSoft = 340,
        FluidRibbonMieLightingNoSoft = 341,
        DistortionBillboard3D = 342,
        DistortionBillboard3DDisableTest = 343,
        DistortionBillboard3DDisableTestNoSoft = 344,
        DistortionBillboard3DDisableTestNoSoftNorm = 345,
        DistortionBillboard3DDisableTestNorm = 346,
        DistortionBillboard3DNoSoft = 347,
        DistortionBillboard3DNoSoftNorm = 348,
        DistortionBillboard3DNorm = 349,
        DistortionBillboard3DCutout = 350,
        DistortionBillboard3DCutoutDisableTest = 351,
        DistortionBillboard3DCutoutDisableTestNoSoft = 352,
        DistortionBillboard3DCutoutDisableTestNoSoftNorm = 353,
        DistortionBillboard3DCutoutDisableTestNorm = 354,
        DistortionBillboard3DCutoutNoSoft = 355,
        DistortionBillboard3DCutoutNoSoftNorm = 356,
        DistortionBillboard3DCutoutNorm = 357,
        DistortionPolygon = 358,
        DistortionPolygonDisableTest = 359,
        DistortionPolygonDisableTestNoSoft = 360,
        DistortionPolygonNoSoft = 361,
        DistortionPolygonStrip = 362,
        DistortionPolygonStripDisableTest = 363,
        DistortionPolygonStripDisableTestNoSoft = 364,
        DistortionPolygonStripNoSoft = 365,
        DistortionRibbon = 366,
        DistortionRibbonDisableTest = 367,
        DistortionRibbonDisableTestNoSoft = 368,
        DistortionRibbonDisableTestNoSoftNorm = 369,
        DistortionRibbonDisableTestNorm = 370,
        DistortionRibbonNoSoft = 371,
        DistortionRibbonNoSoftNorm = 372,
        DistortionRibbonNorm = 373,
        MetaballBillboard = 374,
        MetaballBillboardLighting = 375,
        MetaballPolygon = 376,
        MetaballPolygonLighting = 377,
        MetaballPolygonStrip = 378,
        MetaballPolygonStripLighting = 379,
        MetaballRibbon = 380,
        MetaballRibbonLighting = 381,
        Billboard3DOverdraw = 382,
        Billboard3DOverdrawDisableTest = 383,
        Billboard3DCutoutOverdraw = 384,
        Billboard3DCutoutOverdrawDisableTest = 385,
        Billboard3DTexUnitOverdraw = 386,
        Billboard3DTexUnitOverdrawDisableTest = 387,
        Billboard3DTexUnitOverdrawDisableTestSplitRGBA = 388,
        Billboard3DTexUnitOverdrawSplitRGBA = 389,
        Billboard3DHdrOverdraw = 390,
        Billboard3DHdrOverdrawDisableTest = 391,
        PolygonOverdraw = 392,
        PolygonOverdrawDisableTest = 393,
        PolygonStripOverdraw = 394,
        PolygonStripOverdrawDisableTest = 395,
        RibbonOverdraw = 396,
        RibbonOverdrawDisableTest = 397,
        Billboard2DCutout = 398,
        Billboard2DCutoutOverdraw = 399,
        Billboard3DAlphaDissolve = 400,
        Billboard3DAlphaDissolveLighting = 401,
        Billboard3DAlphaDissolveLightingNorm = 402,
        Billboard3DAlphaDissolveNorm = 403,
        Billboard3DAlphaDissolveCutout = 404,
        Billboard3DAlphaDissolveCutoutLighting = 405,
        Billboard3DAlphaDissolveCutoutLightingNorm = 406,
        Billboard3DAlphaDissolveCutoutNorm = 407,
        Billboard3DAlphaDissolveTexUnit = 408,
        Billboard3DAlphaDissolveTexUnitLighting = 409,
        Billboard3DAlphaDissolveTexUnitLightingSplitRGBA = 410,
        Billboard3DAlphaDissolveTexUnitLightingSplitRGBANorm = 411,
        Billboard3DAlphaDissolveTexUnitLightingNorm = 412,
        Billboard3DAlphaDissolveTexUnitSplitRGBA = 413,
        Billboard3DAlphaDissolveTexUnitSplitRGBANorm = 414,
        Billboard3DAlphaDissolveTexUnitNorm = 415,
        PolygonAlphaDissolve = 416,
        PolygonAlphaDissolveLighting = 417,
        PolygonStripAlphaDissolve = 418,
        PolygonStripAlphaDissolveLighting = 419,
        RibbonAlphaDissolve = 420,
        RibbonAlphaDissolveLighting = 421,
        RibbonAlphaDissolveLightingNorm = 422,
        RibbonAlphaDissolveNorm = 423,
        Billboard3DZPrepass = 424,
        Billboard3DZPrepassNorm = 425,
        Billboard3DZPrepassCutout = 426,
        Billboard3DZPrepassCutoutNorm = 427,
        Billboard3DZPrepassTexUnit = 428,
        Billboard3DZPrepassTexUnitSplitRGBA = 429,
        Billboard3DZPrepassTexUnitSplitRGBANorm = 430,
        Billboard3DZPrepassTexUnitNorm = 431,
        PolygonZPrepass = 432,
        PolygonStripZPrepass = 433,
        RibbonZPrepass = 434,
        RibbonZPrepassNorm = 435,
        RibbonTexUnit = 436,
        RibbonTexUnitDisableTest = 437,
        RibbonTexUnitDisableTestNoSoft = 438,
        RibbonTexUnitDisableTestNoSoftSplitRGBA = 439,
        RibbonTexUnitDisableTestNoSoftSplitRGBANorm = 440,
        RibbonTexUnitDisableTestNoSoftNorm = 441,
        RibbonTexUnitDisableTestSplitRGBA = 442,
        RibbonTexUnitDisableTestSplitRGBANorm = 443,
        RibbonTexUnitDisableTestNorm = 444,
        RibbonTexUnitNoSoft = 445,
        RibbonTexUnitNoSoftSplitRGBA = 446,
        RibbonTexUnitNoSoftSplitRGBANorm = 447,
        RibbonTexUnitNoSoftNorm = 448,
        RibbonTexUnitSplitRGBA = 449,
        RibbonTexUnitSplitRGBANorm = 450,
        RibbonTexUnitNorm = 451,
        RibbonTexUnitLighting = 452,
        RibbonTexUnitLightingDisableTest = 453,
        RibbonTexUnitLightingDisableTestNoSoft = 454,
        RibbonTexUnitLightingDisableTestNoSoftSplitRGBA = 455,
        RibbonTexUnitLightingDisableTestNoSoftSplitRGBANorm = 456,
        RibbonTexUnitLightingDisableTestNoSoftNorm = 457,
        RibbonTexUnitLightingDisableTestSplitRGBA = 458,
        RibbonTexUnitLightingDisableTestSplitRGBANorm = 459,
        RibbonTexUnitLightingDisableTestNorm = 460,
        RibbonTexUnitLightingNoSoft = 461,
        RibbonTexUnitLightingNoSoftSplitRGBA = 462,
        RibbonTexUnitLightingNoSoftSplitRGBANorm = 463,
        RibbonTexUnitLightingNoSoftNorm = 464,
        RibbonTexUnitLightingSplitRGBA = 465,
        RibbonTexUnitLightingSplitRGBANorm = 466,
        RibbonTexUnitLightingNorm = 467,
        RibbonTexUnitShadow = 468,
        RibbonTexUnitShadowSplitRGBA = 469,
        RibbonTexUnitShadowSplitRGBANorm = 470,
        RibbonTexUnitShadowSplitRGBANormTranslucent = 471,
        RibbonTexUnitShadowSplitRGBATranslucent = 472,
        RibbonTexUnitShadowNorm = 473,
        RibbonTexUnitShadowNormTranslucent = 474,
        RibbonTexUnitShadowTranslucent = 475,
        RibbonAlphaDissolveTexUnit = 476,
        RibbonAlphaDissolveTexUnitLighting = 477,
        RibbonAlphaDissolveTexUnitLightingSplitRGBA = 478,
        RibbonAlphaDissolveTexUnitLightingSplitRGBANorm = 479,
        RibbonAlphaDissolveTexUnitLightingNorm = 480,
        RibbonAlphaDissolveTexUnitSplitRGBA = 481,
        RibbonAlphaDissolveTexUnitSplitRGBANorm = 482,
        RibbonAlphaDissolveTexUnitNorm = 483,
        RibbonZPrepassTexUnit = 484,
        RibbonZPrepassTexUnitSplitRGBA = 485,
        RibbonZPrepassTexUnitSplitRGBANorm = 486,
        RibbonZPrepassTexUnitNorm = 487,
        RibbonTexUnitOverdraw = 488,
        RibbonTexUnitOverdrawDisableTest = 489,
        RibbonTexUnitOverdrawDisableTestSplitRGBA = 490,
        RibbonTexUnitOverdrawSplitRGBA = 491,
        DistortionBillboard2D = 492,
        DistortionBillboard2DCutout = 493,
        Billboard2DLuminanceBleed = 494,
        Billboard2DCutoutLuminanceBleed = 495,
        Billboard3DSimpleLuminanceBleed = 496,
        Billboard3DSimpleLuminanceBleedDisableTest = 497,
        Billboard3DSimpleLuminanceBleedDisableTestTextureBlend = 498,
        Billboard3DSimpleLuminanceBleedDisableTestTextureBlendNoSoft = 499,
        Billboard3DSimpleLuminanceBleedDisableTestTextureBlendNoSoftNorm = 500,
        Billboard3DSimpleLuminanceBleedDisableTestTextureBlendNorm = 501,
        Billboard3DSimpleLuminanceBleedDisableTestNoSoft = 502,
        Billboard3DSimpleLuminanceBleedDisableTestNoSoftNorm = 503,
        Billboard3DSimpleLuminanceBleedDisableTestNorm = 504,
        Billboard3DSimpleLuminanceBleedTextureBlend = 505,
        Billboard3DSimpleLuminanceBleedTextureBlendNoSoft = 506,
        Billboard3DSimpleLuminanceBleedTextureBlendNoSoftNorm = 507,
        Billboard3DSimpleLuminanceBleedTextureBlendNorm = 508,
        Billboard3DSimpleLuminanceBleedNoSoft = 509,
        Billboard3DSimpleLuminanceBleedNoSoftNorm = 510,
        Billboard3DSimpleLuminanceBleedNorm = 511,
        Billboard3DCutoutSimpleLuminanceBleed = 512,
        Billboard3DCutoutSimpleLuminanceBleedDisableTest = 513,
        Billboard3DCutoutSimpleLuminanceBleedDisableTestNoSoft = 514,
        Billboard3DCutoutSimpleLuminanceBleedDisableTestNoSoftNorm = 515,
        Billboard3DCutoutSimpleLuminanceBleedDisableTestNorm = 516,
        Billboard3DCutoutSimpleLuminanceBleedNoSoft = 517,
        Billboard3DCutoutSimpleLuminanceBleedNoSoftNorm = 518,
        Billboard3DCutoutSimpleLuminanceBleedNorm = 519,
        PolygonSimpleLuminanceBleed = 520,
        PolygonSimpleLuminanceBleedDisableTest = 521,
        PolygonSimpleLuminanceBleedDisableTestTextureBlend = 522,
        PolygonSimpleLuminanceBleedDisableTestTextureBlendNoSoft = 523,
        PolygonSimpleLuminanceBleedDisableTestNoSoft = 524,
        PolygonSimpleLuminanceBleedTextureBlend = 525,
        PolygonSimpleLuminanceBleedTextureBlendNoSoft = 526,
        PolygonSimpleLuminanceBleedNoSoft = 527,
        PolygonStripSimpleLuminanceBleed = 528,
        PolygonStripSimpleLuminanceBleedDisableTest = 529,
        PolygonStripSimpleLuminanceBleedDisableTestTextureBlend = 530,
        PolygonStripSimpleLuminanceBleedDisableTestTextureBlendNoSoft = 531,
        PolygonStripSimpleLuminanceBleedDisableTestNoSoft = 532,
        PolygonStripSimpleLuminanceBleedTextureBlend = 533,
        PolygonStripSimpleLuminanceBleedTextureBlendNoSoft = 534,
        PolygonStripSimpleLuminanceBleedNoSoft = 535,
        RibbonSimpleLuminanceBleed = 536,
        RibbonSimpleLuminanceBleedDisableTest = 537,
        RibbonSimpleLuminanceBleedDisableTestTextureBlend = 538,
        RibbonSimpleLuminanceBleedDisableTestTextureBlendNoSoft = 539,
        RibbonSimpleLuminanceBleedDisableTestTextureBlendNoSoftNorm = 540,
        RibbonSimpleLuminanceBleedDisableTestTextureBlendNorm = 541,
        RibbonSimpleLuminanceBleedDisableTestNoSoft = 542,
        RibbonSimpleLuminanceBleedDisableTestNoSoftNorm = 543,
        RibbonSimpleLuminanceBleedDisableTestNorm = 544,
        RibbonSimpleLuminanceBleedTextureBlend = 545,
        RibbonSimpleLuminanceBleedTextureBlendNoSoft = 546,
        RibbonSimpleLuminanceBleedTextureBlendNoSoftNorm = 547,
        RibbonSimpleLuminanceBleedTextureBlendNorm = 548,
        RibbonSimpleLuminanceBleedNoSoft = 549,
        RibbonSimpleLuminanceBleedNoSoftNorm = 550,
        RibbonSimpleLuminanceBleedNorm = 551,
        Billboard2DSimpleLuminanceBleed = 552,
        Billboard2DCutoutSimpleLuminanceBleed = 553,
        Billboard3DTexelOp = 554,
        Billboard3DTexelOpDisableTest = 555,
        Billboard3DTexelOpDisableTestTextureBlend = 556,
        Billboard3DTexelOpDisableTestTextureBlendNoSoft = 557,
        Billboard3DTexelOpDisableTestTextureBlendNoSoftNorm = 558,
        Billboard3DTexelOpDisableTestTextureBlendNorm = 559,
        Billboard3DTexelOpDisableTestNoSoft = 560,
        Billboard3DTexelOpDisableTestNoSoftNorm = 561,
        Billboard3DTexelOpDisableTestNorm = 562,
        Billboard3DTexelOpTextureBlend = 563,
        Billboard3DTexelOpTextureBlendNoSoft = 564,
        Billboard3DTexelOpTextureBlendNoSoftNorm = 565,
        Billboard3DTexelOpTextureBlendNorm = 566,
        Billboard3DTexelOpNoSoft = 567,
        Billboard3DTexelOpNoSoftNorm = 568,
        Billboard3DTexelOpNorm = 569,
        Billboard3DTexelOpLighting = 570,
        Billboard3DTexelOpLightingDisableTest = 571,
        Billboard3DTexelOpLightingDisableTestTextureBlend = 572,
        Billboard3DTexelOpLightingDisableTestTextureBlendNoSoft = 573,
        Billboard3DTexelOpLightingDisableTestTextureBlendNoSoftNorm = 574,
        Billboard3DTexelOpLightingDisableTestTextureBlendNorm = 575,
        Billboard3DTexelOpLightingDisableTestNoSoft = 576,
        Billboard3DTexelOpLightingDisableTestNoSoftNorm = 577,
        Billboard3DTexelOpLightingDisableTestNorm = 578,
        Billboard3DTexelOpLightingTextureBlend = 579,
        Billboard3DTexelOpLightingTextureBlendNoSoft = 580,
        Billboard3DTexelOpLightingTextureBlendNoSoftNorm = 581,
        Billboard3DTexelOpLightingTextureBlendNorm = 582,
        Billboard3DTexelOpLightingNoSoft = 583,
        Billboard3DTexelOpLightingNoSoftNorm = 584,
        Billboard3DTexelOpLightingNorm = 585,
        PolygonTexelOp = 586,
        PolygonTexelOpDisableTest = 587,
        PolygonTexelOpDisableTestTextureBlend = 588,
        PolygonTexelOpDisableTestTextureBlendNoSoft = 589,
        PolygonTexelOpDisableTestNoSoft = 590,
        PolygonTexelOpTextureBlend = 591,
        PolygonTexelOpTextureBlendNoSoft = 592,
        PolygonTexelOpNoSoft = 593,
        PolygonTexelOpLighting = 594,
        PolygonTexelOpLightingDisableTest = 595,
        PolygonTexelOpLightingDisableTestTextureBlend = 596,
        PolygonTexelOpLightingDisableTestTextureBlendNoSoft = 597,
        PolygonTexelOpLightingDisableTestNoSoft = 598,
        PolygonTexelOpLightingTextureBlend = 599,
        PolygonTexelOpLightingTextureBlendNoSoft = 600,
        PolygonTexelOpLightingNoSoft = 601,
        PolygonStripTexelOp = 602,
        PolygonStripTexelOpDisableTest = 603,
        PolygonStripTexelOpDisableTestTextureBlend = 604,
        PolygonStripTexelOpDisableTestTextureBlendNoSoft = 605,
        PolygonStripTexelOpDisableTestNoSoft = 606,
        PolygonStripTexelOpTextureBlend = 607,
        PolygonStripTexelOpTextureBlendNoSoft = 608,
        PolygonStripTexelOpNoSoft = 609,
        PolygonStripTexelOpLighting = 610,
        PolygonStripTexelOpLightingDisableTest = 611,
        PolygonStripTexelOpLightingDisableTestTextureBlend = 612,
        PolygonStripTexelOpLightingDisableTestTextureBlendNoSoft = 613,
        PolygonStripTexelOpLightingDisableTestNoSoft = 614,
        PolygonStripTexelOpLightingTextureBlend = 615,
        PolygonStripTexelOpLightingTextureBlendNoSoft = 616,
        PolygonStripTexelOpLightingNoSoft = 617,
        RibbonTexelOp = 618,
        RibbonTexelOpDisableTest = 619,
        RibbonTexelOpDisableTestTextureBlend = 620,
        RibbonTexelOpDisableTestTextureBlendNoSoft = 621,
        RibbonTexelOpDisableTestTextureBlendNoSoftNorm = 622,
        RibbonTexelOpDisableTestTextureBlendNorm = 623,
        RibbonTexelOpDisableTestNoSoft = 624,
        RibbonTexelOpDisableTestNoSoftNorm = 625,
        RibbonTexelOpDisableTestNorm = 626,
        RibbonTexelOpTextureBlend = 627,
        RibbonTexelOpTextureBlendNoSoft = 628,
        RibbonTexelOpTextureBlendNoSoftNorm = 629,
        RibbonTexelOpTextureBlendNorm = 630,
        RibbonTexelOpNoSoft = 631,
        RibbonTexelOpNoSoftNorm = 632,
        RibbonTexelOpNorm = 633,
        RibbonTexelOpLighting = 634,
        RibbonTexelOpLightingDisableTest = 635,
        RibbonTexelOpLightingDisableTestTextureBlend = 636,
        RibbonTexelOpLightingDisableTestTextureBlendNoSoft = 637,
        RibbonTexelOpLightingDisableTestTextureBlendNoSoftNorm = 638,
        RibbonTexelOpLightingDisableTestTextureBlendNorm = 639,
        RibbonTexelOpLightingDisableTestNoSoft = 640,
        RibbonTexelOpLightingDisableTestNoSoftNorm = 641,
        RibbonTexelOpLightingDisableTestNorm = 642,
        RibbonTexelOpLightingTextureBlend = 643,
        RibbonTexelOpLightingTextureBlendNoSoft = 644,
        RibbonTexelOpLightingTextureBlendNoSoftNorm = 645,
        RibbonTexelOpLightingTextureBlendNorm = 646,
        RibbonTexelOpLightingNoSoft = 647,
        RibbonTexelOpLightingNoSoftNorm = 648,
        RibbonTexelOpLightingNorm = 649,
        Billboard3DTexelOpCutout = 650,
        Billboard3DTexelOpCutoutDisableTest = 651,
        Billboard3DTexelOpCutoutDisableTestNoSoft = 652,
        Billboard3DTexelOpCutoutDisableTestNoSoftNorm = 653,
        Billboard3DTexelOpCutoutDisableTestNorm = 654,
        Billboard3DTexelOpCutoutNoSoft = 655,
        Billboard3DTexelOpCutoutNoSoftNorm = 656,
        Billboard3DTexelOpCutoutNorm = 657,
        Billboard3DTexelOpCutoutLighting = 658,
        Billboard3DTexelOpCutoutLightingDisableTest = 659,
        Billboard3DTexelOpCutoutLightingDisableTestNoSoft = 660,
        Billboard3DTexelOpCutoutLightingDisableTestNoSoftNorm = 661,
        Billboard3DTexelOpCutoutLightingDisableTestNorm = 662,
        Billboard3DTexelOpCutoutLightingNoSoft = 663,
        Billboard3DTexelOpCutoutLightingNoSoftNorm = 664,
        Billboard3DTexelOpCutoutLightingNorm = 665,
        ParticleDeferredLighting = 666,
        ParticleDeferredLightingNorm = 667,
        ParticleDeferredLightingNormOutdoor = 668,
        ParticleDeferredLightingOutdoor = 669,
        Billboard3DDeferredLighting = 670,
        Billboard3DDeferredLightingDisableTest = 671,
        Billboard3DDeferredLightingDisableTestTextureBlend = 672,
        Billboard3DDeferredLightingDisableTestTextureBlendNoSoft = 673,
        Billboard3DDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 674,
        Billboard3DDeferredLightingDisableTestTextureBlendNoSoftVolumetricFogNorm = 675,
        Billboard3DDeferredLightingDisableTestTextureBlendNoSoftNorm = 676,
        Billboard3DDeferredLightingDisableTestTextureBlendVolumetricFog = 677,
        Billboard3DDeferredLightingDisableTestTextureBlendVolumetricFogNorm = 678,
        Billboard3DDeferredLightingDisableTestTextureBlendNorm = 679,
        Billboard3DDeferredLightingDisableTestNoSoft = 680,
        Billboard3DDeferredLightingDisableTestNoSoftVolumetricFog = 681,
        Billboard3DDeferredLightingDisableTestNoSoftVolumetricFogNorm = 682,
        Billboard3DDeferredLightingDisableTestNoSoftNorm = 683,
        Billboard3DDeferredLightingDisableTestVolumetricFog = 684,
        Billboard3DDeferredLightingDisableTestVolumetricFogNorm = 685,
        Billboard3DDeferredLightingDisableTestNorm = 686,
        Billboard3DDeferredLightingTextureBlend = 687,
        Billboard3DDeferredLightingTextureBlendNoSoft = 688,
        Billboard3DDeferredLightingTextureBlendNoSoftVolumetricFog = 689,
        Billboard3DDeferredLightingTextureBlendNoSoftVolumetricFogNorm = 690,
        Billboard3DDeferredLightingTextureBlendNoSoftNorm = 691,
        Billboard3DDeferredLightingTextureBlendVolumetricFog = 692,
        Billboard3DDeferredLightingTextureBlendVolumetricFogNorm = 693,
        Billboard3DDeferredLightingTextureBlendNorm = 694,
        Billboard3DDeferredLightingNoSoft = 695,
        Billboard3DDeferredLightingNoSoftVolumetricFog = 696,
        Billboard3DDeferredLightingNoSoftVolumetricFogNorm = 697,
        Billboard3DDeferredLightingNoSoftNorm = 698,
        Billboard3DDeferredLightingVolumetricFog = 699,
        Billboard3DDeferredLightingVolumetricFogNorm = 700,
        Billboard3DDeferredLightingNorm = 701,
        Billboard3DCutoutDeferredLighting = 702,
        Billboard3DCutoutDeferredLightingDisableTest = 703,
        Billboard3DCutoutDeferredLightingDisableTestNoSoft = 704,
        Billboard3DCutoutDeferredLightingDisableTestNoSoftVolumetricFog = 705,
        Billboard3DCutoutDeferredLightingDisableTestNoSoftVolumetricFogNorm = 706,
        Billboard3DCutoutDeferredLightingDisableTestNoSoftNorm = 707,
        Billboard3DCutoutDeferredLightingDisableTestVolumetricFog = 708,
        Billboard3DCutoutDeferredLightingDisableTestVolumetricFogNorm = 709,
        Billboard3DCutoutDeferredLightingDisableTestNorm = 710,
        Billboard3DCutoutDeferredLightingNoSoft = 711,
        Billboard3DCutoutDeferredLightingNoSoftVolumetricFog = 712,
        Billboard3DCutoutDeferredLightingNoSoftVolumetricFogNorm = 713,
        Billboard3DCutoutDeferredLightingNoSoftNorm = 714,
        Billboard3DCutoutDeferredLightingVolumetricFog = 715,
        Billboard3DCutoutDeferredLightingVolumetricFogNorm = 716,
        Billboard3DCutoutDeferredLightingNorm = 717,
        Billboard3DTexUnitDeferredLighting = 718,
        Billboard3DTexUnitDeferredLightingDisableTest = 719,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoft = 720,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoftSplitRGBA = 721,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoftSplitRGBAVolumetricFog = 722,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoftSplitRGBAVolumetricFogNorm = 723,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoftSplitRGBANorm = 724,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoftVolumetricFog = 725,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoftVolumetricFogNorm = 726,
        Billboard3DTexUnitDeferredLightingDisableTestNoSoftNorm = 727,
        Billboard3DTexUnitDeferredLightingDisableTestSplitRGBA = 728,
        Billboard3DTexUnitDeferredLightingDisableTestSplitRGBAVolumetricFog = 729,
        Billboard3DTexUnitDeferredLightingDisableTestSplitRGBAVolumetricFogNorm = 730,
        Billboard3DTexUnitDeferredLightingDisableTestSplitRGBANorm = 731,
        Billboard3DTexUnitDeferredLightingDisableTestVolumetricFog = 732,
        Billboard3DTexUnitDeferredLightingDisableTestVolumetricFogNorm = 733,
        Billboard3DTexUnitDeferredLightingDisableTestNorm = 734,
        Billboard3DTexUnitDeferredLightingNoSoft = 735,
        Billboard3DTexUnitDeferredLightingNoSoftSplitRGBA = 736,
        Billboard3DTexUnitDeferredLightingNoSoftSplitRGBAVolumetricFog = 737,
        Billboard3DTexUnitDeferredLightingNoSoftSplitRGBAVolumetricFogNorm = 738,
        Billboard3DTexUnitDeferredLightingNoSoftSplitRGBANorm = 739,
        Billboard3DTexUnitDeferredLightingNoSoftVolumetricFog = 740,
        Billboard3DTexUnitDeferredLightingNoSoftVolumetricFogNorm = 741,
        Billboard3DTexUnitDeferredLightingNoSoftNorm = 742,
        Billboard3DTexUnitDeferredLightingSplitRGBA = 743,
        Billboard3DTexUnitDeferredLightingSplitRGBAVolumetricFog = 744,
        Billboard3DTexUnitDeferredLightingSplitRGBAVolumetricFogNorm = 745,
        Billboard3DTexUnitDeferredLightingSplitRGBANorm = 746,
        Billboard3DTexUnitDeferredLightingVolumetricFog = 747,
        Billboard3DTexUnitDeferredLightingVolumetricFogNorm = 748,
        Billboard3DTexUnitDeferredLightingNorm = 749,
        Billboard3DTexelOpDeferredLighting = 750,
        Billboard3DTexelOpDeferredLightingDisableTest = 751,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlend = 752,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlendNoSoft = 753,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 754,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlendNoSoftVolumetricFogNorm = 755,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlendNoSoftNorm = 756,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlendVolumetricFog = 757,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlendVolumetricFogNorm = 758,
        Billboard3DTexelOpDeferredLightingDisableTestTextureBlendNorm = 759,
        Billboard3DTexelOpDeferredLightingDisableTestNoSoft = 760,
        Billboard3DTexelOpDeferredLightingDisableTestNoSoftVolumetricFog = 761,
        Billboard3DTexelOpDeferredLightingDisableTestNoSoftVolumetricFogNorm = 762,
        Billboard3DTexelOpDeferredLightingDisableTestNoSoftNorm = 763,
        Billboard3DTexelOpDeferredLightingDisableTestVolumetricFog = 764,
        Billboard3DTexelOpDeferredLightingDisableTestVolumetricFogNorm = 765,
        Billboard3DTexelOpDeferredLightingDisableTestNorm = 766,
        Billboard3DTexelOpDeferredLightingTextureBlend = 767,
        Billboard3DTexelOpDeferredLightingTextureBlendNoSoft = 768,
        Billboard3DTexelOpDeferredLightingTextureBlendNoSoftVolumetricFog = 769,
        Billboard3DTexelOpDeferredLightingTextureBlendNoSoftVolumetricFogNorm = 770,
        Billboard3DTexelOpDeferredLightingTextureBlendNoSoftNorm = 771,
        Billboard3DTexelOpDeferredLightingTextureBlendVolumetricFog = 772,
        Billboard3DTexelOpDeferredLightingTextureBlendVolumetricFogNorm = 773,
        Billboard3DTexelOpDeferredLightingTextureBlendNorm = 774,
        Billboard3DTexelOpDeferredLightingNoSoft = 775,
        Billboard3DTexelOpDeferredLightingNoSoftVolumetricFog = 776,
        Billboard3DTexelOpDeferredLightingNoSoftVolumetricFogNorm = 777,
        Billboard3DTexelOpDeferredLightingNoSoftNorm = 778,
        Billboard3DTexelOpDeferredLightingVolumetricFog = 779,
        Billboard3DTexelOpDeferredLightingVolumetricFogNorm = 780,
        Billboard3DTexelOpDeferredLightingNorm = 781,
        Billboard3DTexelOpCutoutDeferredLighting = 782,
        Billboard3DTexelOpCutoutDeferredLightingDisableTest = 783,
        Billboard3DTexelOpCutoutDeferredLightingDisableTestNoSoft = 784,
        Billboard3DTexelOpCutoutDeferredLightingDisableTestNoSoftVolumetricFog = 785,
        Billboard3DTexelOpCutoutDeferredLightingDisableTestNoSoftVolumetricFogNorm = 786,
        Billboard3DTexelOpCutoutDeferredLightingDisableTestNoSoftNorm = 787,
        Billboard3DTexelOpCutoutDeferredLightingDisableTestVolumetricFog = 788,
        Billboard3DTexelOpCutoutDeferredLightingDisableTestVolumetricFogNorm = 789,
        Billboard3DTexelOpCutoutDeferredLightingDisableTestNorm = 790,
        Billboard3DTexelOpCutoutDeferredLightingNoSoft = 791,
        Billboard3DTexelOpCutoutDeferredLightingNoSoftVolumetricFog = 792,
        Billboard3DTexelOpCutoutDeferredLightingNoSoftVolumetricFogNorm = 793,
        Billboard3DTexelOpCutoutDeferredLightingNoSoftNorm = 794,
        Billboard3DTexelOpCutoutDeferredLightingVolumetricFog = 795,
        Billboard3DTexelOpCutoutDeferredLightingVolumetricFogNorm = 796,
        Billboard3DTexelOpCutoutDeferredLightingNorm = 797,
        PolygonDeferredLighting = 798,
        PolygonDeferredLightingDisableTest = 799,
        PolygonDeferredLightingDisableTestTextureBlend = 800,
        PolygonDeferredLightingDisableTestTextureBlendNoSoft = 801,
        PolygonDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 802,
        PolygonDeferredLightingDisableTestTextureBlendVolumetricFog = 803,
        PolygonDeferredLightingDisableTestNoSoft = 804,
        PolygonDeferredLightingDisableTestNoSoftVolumetricFog = 805,
        PolygonDeferredLightingDisableTestVolumetricFog = 806,
        PolygonDeferredLightingTextureBlend = 807,
        PolygonDeferredLightingTextureBlendNoSoft = 808,
        PolygonDeferredLightingTextureBlendNoSoftVolumetricFog = 809,
        PolygonDeferredLightingTextureBlendVolumetricFog = 810,
        PolygonDeferredLightingNoSoft = 811,
        PolygonDeferredLightingNoSoftVolumetricFog = 812,
        PolygonDeferredLightingVolumetricFog = 813,
        PolygonStripDeferredLighting = 814,
        PolygonStripDeferredLightingDisableTest = 815,
        PolygonStripDeferredLightingDisableTestTextureBlend = 816,
        PolygonStripDeferredLightingDisableTestTextureBlendNoSoft = 817,
        PolygonStripDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 818,
        PolygonStripDeferredLightingDisableTestTextureBlendVolumetricFog = 819,
        PolygonStripDeferredLightingDisableTestNoSoft = 820,
        PolygonStripDeferredLightingDisableTestNoSoftVolumetricFog = 821,
        PolygonStripDeferredLightingDisableTestVolumetricFog = 822,
        PolygonStripDeferredLightingTextureBlend = 823,
        PolygonStripDeferredLightingTextureBlendNoSoft = 824,
        PolygonStripDeferredLightingTextureBlendNoSoftVolumetricFog = 825,
        PolygonStripDeferredLightingTextureBlendVolumetricFog = 826,
        PolygonStripDeferredLightingNoSoft = 827,
        PolygonStripDeferredLightingNoSoftVolumetricFog = 828,
        PolygonStripDeferredLightingVolumetricFog = 829,
        RibbonDeferredLighting = 830,
        RibbonDeferredLightingDisableTest = 831,
        RibbonDeferredLightingDisableTestTextureBlend = 832,
        RibbonDeferredLightingDisableTestTextureBlendNoSoft = 833,
        RibbonDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 834,
        RibbonDeferredLightingDisableTestTextureBlendNoSoftVolumetricFogNorm = 835,
        RibbonDeferredLightingDisableTestTextureBlendNoSoftNorm = 836,
        RibbonDeferredLightingDisableTestTextureBlendVolumetricFog = 837,
        RibbonDeferredLightingDisableTestTextureBlendVolumetricFogNorm = 838,
        RibbonDeferredLightingDisableTestTextureBlendNorm = 839,
        RibbonDeferredLightingDisableTestNoSoft = 840,
        RibbonDeferredLightingDisableTestNoSoftVolumetricFog = 841,
        RibbonDeferredLightingDisableTestNoSoftVolumetricFogNorm = 842,
        RibbonDeferredLightingDisableTestNoSoftNorm = 843,
        RibbonDeferredLightingDisableTestVolumetricFog = 844,
        RibbonDeferredLightingDisableTestVolumetricFogNorm = 845,
        RibbonDeferredLightingDisableTestNorm = 846,
        RibbonDeferredLightingTextureBlend = 847,
        RibbonDeferredLightingTextureBlendNoSoft = 848,
        RibbonDeferredLightingTextureBlendNoSoftVolumetricFog = 849,
        RibbonDeferredLightingTextureBlendNoSoftVolumetricFogNorm = 850,
        RibbonDeferredLightingTextureBlendNoSoftNorm = 851,
        RibbonDeferredLightingTextureBlendVolumetricFog = 852,
        RibbonDeferredLightingTextureBlendVolumetricFogNorm = 853,
        RibbonDeferredLightingTextureBlendNorm = 854,
        RibbonDeferredLightingNoSoft = 855,
        RibbonDeferredLightingNoSoftVolumetricFog = 856,
        RibbonDeferredLightingNoSoftVolumetricFogNorm = 857,
        RibbonDeferredLightingNoSoftNorm = 858,
        RibbonDeferredLightingVolumetricFog = 859,
        RibbonDeferredLightingVolumetricFogNorm = 860,
        RibbonDeferredLightingNorm = 861,
        FluidBillboardDeferredLighting = 862,
        FluidBillboardDeferredLightingDisableTest = 863,
        FluidBillboardDeferredLightingDisableTestNoSoft = 864,
        FluidBillboardDeferredLightingDisableTestNoSoftVolumetricFog = 865,
        FluidBillboardDeferredLightingDisableTestVolumetricFog = 866,
        FluidBillboardDeferredLightingNoSoft = 867,
        FluidBillboardDeferredLightingNoSoftVolumetricFog = 868,
        FluidBillboardDeferredLightingVolumetricFog = 869,
        FluidPolygonDeferredLighting = 870,
        FluidPolygonDeferredLightingDisableTest = 871,
        FluidPolygonDeferredLightingDisableTestNoSoft = 872,
        FluidPolygonDeferredLightingDisableTestNoSoftVolumetricFog = 873,
        FluidPolygonDeferredLightingDisableTestVolumetricFog = 874,
        FluidPolygonDeferredLightingNoSoft = 875,
        FluidPolygonDeferredLightingNoSoftVolumetricFog = 876,
        FluidPolygonDeferredLightingVolumetricFog = 877,
        FluidPolygonStripDeferredLighting = 878,
        FluidPolygonStripDeferredLightingDisableTest = 879,
        FluidPolygonStripDeferredLightingDisableTestNoSoft = 880,
        FluidPolygonStripDeferredLightingDisableTestNoSoftVolumetricFog = 881,
        FluidPolygonStripDeferredLightingDisableTestVolumetricFog = 882,
        FluidPolygonStripDeferredLightingNoSoft = 883,
        FluidPolygonStripDeferredLightingNoSoftVolumetricFog = 884,
        FluidPolygonStripDeferredLightingVolumetricFog = 885,
        FluidRibbonDeferredLighting = 886,
        FluidRibbonDeferredLightingDisableTest = 887,
        FluidRibbonDeferredLightingDisableTestNoSoft = 888,
        FluidRibbonDeferredLightingDisableTestNoSoftVolumetricFog = 889,
        FluidRibbonDeferredLightingDisableTestVolumetricFog = 890,
        FluidRibbonDeferredLightingNoSoft = 891,
        FluidRibbonDeferredLightingNoSoftVolumetricFog = 892,
        FluidRibbonDeferredLightingVolumetricFog = 893,
        RibbonTexUnitDeferredLighting = 894,
        RibbonTexUnitDeferredLightingDisableTest = 895,
        RibbonTexUnitDeferredLightingDisableTestNoSoft = 896,
        RibbonTexUnitDeferredLightingDisableTestNoSoftSplitRGBA = 897,
        RibbonTexUnitDeferredLightingDisableTestNoSoftSplitRGBAVolumetricFog = 898,
        RibbonTexUnitDeferredLightingDisableTestNoSoftSplitRGBAVolumetricFogNorm = 899,
        RibbonTexUnitDeferredLightingDisableTestNoSoftSplitRGBANorm = 900,
        RibbonTexUnitDeferredLightingDisableTestNoSoftVolumetricFog = 901,
        RibbonTexUnitDeferredLightingDisableTestNoSoftVolumetricFogNorm = 902,
        RibbonTexUnitDeferredLightingDisableTestNoSoftNorm = 903,
        RibbonTexUnitDeferredLightingDisableTestSplitRGBA = 904,
        RibbonTexUnitDeferredLightingDisableTestSplitRGBAVolumetricFog = 905,
        RibbonTexUnitDeferredLightingDisableTestSplitRGBAVolumetricFogNorm = 906,
        RibbonTexUnitDeferredLightingDisableTestSplitRGBANorm = 907,
        RibbonTexUnitDeferredLightingDisableTestVolumetricFog = 908,
        RibbonTexUnitDeferredLightingDisableTestVolumetricFogNorm = 909,
        RibbonTexUnitDeferredLightingDisableTestNorm = 910,
        RibbonTexUnitDeferredLightingNoSoft = 911,
        RibbonTexUnitDeferredLightingNoSoftSplitRGBA = 912,
        RibbonTexUnitDeferredLightingNoSoftSplitRGBAVolumetricFog = 913,
        RibbonTexUnitDeferredLightingNoSoftSplitRGBAVolumetricFogNorm = 914,
        RibbonTexUnitDeferredLightingNoSoftSplitRGBANorm = 915,
        RibbonTexUnitDeferredLightingNoSoftVolumetricFog = 916,
        RibbonTexUnitDeferredLightingNoSoftVolumetricFogNorm = 917,
        RibbonTexUnitDeferredLightingNoSoftNorm = 918,
        RibbonTexUnitDeferredLightingSplitRGBA = 919,
        RibbonTexUnitDeferredLightingSplitRGBAVolumetricFog = 920,
        RibbonTexUnitDeferredLightingSplitRGBAVolumetricFogNorm = 921,
        RibbonTexUnitDeferredLightingSplitRGBANorm = 922,
        RibbonTexUnitDeferredLightingVolumetricFog = 923,
        RibbonTexUnitDeferredLightingVolumetricFogNorm = 924,
        RibbonTexUnitDeferredLightingNorm = 925,
        PolygonTexelOpDeferredLighting = 926,
        PolygonTexelOpDeferredLightingDisableTest = 927,
        PolygonTexelOpDeferredLightingDisableTestTextureBlend = 928,
        PolygonTexelOpDeferredLightingDisableTestTextureBlendNoSoft = 929,
        PolygonTexelOpDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 930,
        PolygonTexelOpDeferredLightingDisableTestTextureBlendVolumetricFog = 931,
        PolygonTexelOpDeferredLightingDisableTestNoSoft = 932,
        PolygonTexelOpDeferredLightingDisableTestNoSoftVolumetricFog = 933,
        PolygonTexelOpDeferredLightingDisableTestVolumetricFog = 934,
        PolygonTexelOpDeferredLightingTextureBlend = 935,
        PolygonTexelOpDeferredLightingTextureBlendNoSoft = 936,
        PolygonTexelOpDeferredLightingTextureBlendNoSoftVolumetricFog = 937,
        PolygonTexelOpDeferredLightingTextureBlendVolumetricFog = 938,
        PolygonTexelOpDeferredLightingNoSoft = 939,
        PolygonTexelOpDeferredLightingNoSoftVolumetricFog = 940,
        PolygonTexelOpDeferredLightingVolumetricFog = 941,
        PolygonStripTexelOpDeferredLighting = 942,
        PolygonStripTexelOpDeferredLightingDisableTest = 943,
        PolygonStripTexelOpDeferredLightingDisableTestTextureBlend = 944,
        PolygonStripTexelOpDeferredLightingDisableTestTextureBlendNoSoft = 945,
        PolygonStripTexelOpDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 946,
        PolygonStripTexelOpDeferredLightingDisableTestTextureBlendVolumetricFog = 947,
        PolygonStripTexelOpDeferredLightingDisableTestNoSoft = 948,
        PolygonStripTexelOpDeferredLightingDisableTestNoSoftVolumetricFog = 949,
        PolygonStripTexelOpDeferredLightingDisableTestVolumetricFog = 950,
        PolygonStripTexelOpDeferredLightingTextureBlend = 951,
        PolygonStripTexelOpDeferredLightingTextureBlendNoSoft = 952,
        PolygonStripTexelOpDeferredLightingTextureBlendNoSoftVolumetricFog = 953,
        PolygonStripTexelOpDeferredLightingTextureBlendVolumetricFog = 954,
        PolygonStripTexelOpDeferredLightingNoSoft = 955,
        PolygonStripTexelOpDeferredLightingNoSoftVolumetricFog = 956,
        PolygonStripTexelOpDeferredLightingVolumetricFog = 957,
        RibbonTexelOpDeferredLighting = 958,
        RibbonTexelOpDeferredLightingDisableTest = 959,
        RibbonTexelOpDeferredLightingDisableTestTextureBlend = 960,
        RibbonTexelOpDeferredLightingDisableTestTextureBlendNoSoft = 961,
        RibbonTexelOpDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 962,
        RibbonTexelOpDeferredLightingDisableTestTextureBlendNoSoftVolumetricFogNorm = 963,
        RibbonTexelOpDeferredLightingDisableTestTextureBlendNoSoftNorm = 964,
        RibbonTexelOpDeferredLightingDisableTestTextureBlendVolumetricFog = 965,
        RibbonTexelOpDeferredLightingDisableTestTextureBlendVolumetricFogNorm = 966,
        RibbonTexelOpDeferredLightingDisableTestTextureBlendNorm = 967,
        RibbonTexelOpDeferredLightingDisableTestNoSoft = 968,
        RibbonTexelOpDeferredLightingDisableTestNoSoftVolumetricFog = 969,
        RibbonTexelOpDeferredLightingDisableTestNoSoftVolumetricFogNorm = 970,
        RibbonTexelOpDeferredLightingDisableTestNoSoftNorm = 971,
        RibbonTexelOpDeferredLightingDisableTestVolumetricFog = 972,
        RibbonTexelOpDeferredLightingDisableTestVolumetricFogNorm = 973,
        RibbonTexelOpDeferredLightingDisableTestNorm = 974,
        RibbonTexelOpDeferredLightingTextureBlend = 975,
        RibbonTexelOpDeferredLightingTextureBlendNoSoft = 976,
        RibbonTexelOpDeferredLightingTextureBlendNoSoftVolumetricFog = 977,
        RibbonTexelOpDeferredLightingTextureBlendNoSoftVolumetricFogNorm = 978,
        RibbonTexelOpDeferredLightingTextureBlendNoSoftNorm = 979,
        RibbonTexelOpDeferredLightingTextureBlendVolumetricFog = 980,
        RibbonTexelOpDeferredLightingTextureBlendVolumetricFogNorm = 981,
        RibbonTexelOpDeferredLightingTextureBlendNorm = 982,
        RibbonTexelOpDeferredLightingNoSoft = 983,
        RibbonTexelOpDeferredLightingNoSoftVolumetricFog = 984,
        RibbonTexelOpDeferredLightingNoSoftVolumetricFogNorm = 985,
        RibbonTexelOpDeferredLightingNoSoftNorm = 986,
        RibbonTexelOpDeferredLightingVolumetricFog = 987,
        RibbonTexelOpDeferredLightingVolumetricFogNorm = 988,
        RibbonTexelOpDeferredLightingNorm = 989,
        ParticleDeferredLightingBillboardCutout = 990,
        ParticleDeferredLightingBillboardCutoutNorm = 991,
        ParticleDeferredLightingBillboardCutoutNormOutdoor = 992,
        ParticleDeferredLightingBillboardCutoutOutdoor = 993,
        ParticleDeferredLightingBillboardTexUnit = 994,
        ParticleDeferredLightingBillboardTexUnitNorm = 995,
        ParticleDeferredLightingBillboardTexUnitNormOutdoor = 996,
        ParticleDeferredLightingBillboardTexUnitOutdoor = 997,
        ParticleDeferredLightingPolygon = 998,
        ParticleDeferredLightingPolygonOutdoor = 999,
        ParticleDeferredLightingPolygonStrip = 1000,
        ParticleDeferredLightingPolygonStripOutdoor = 1001,
        ParticleDeferredLightingRibbon = 1002,
        ParticleDeferredLightingRibbonNorm = 1003,
        ParticleDeferredLightingRibbonNormOutdoor = 1004,
        ParticleDeferredLightingRibbonOutdoor = 1005,
        ParticleDeferredLightingRibbonTexUnit = 1006,
        ParticleDeferredLightingRibbonTexUnitNorm = 1007,
        ParticleDeferredLightingRibbonTexUnitNormOutdoor = 1008,
        ParticleDeferredLightingRibbonTexUnitOutdoor = 1009,
        StretchBlurRibbon = 1010,
        StretchBlurRibbonDisableTest = 1011,
        StretchBlurRibbonDisableTestNoSoft = 1012,
        StretchBlurRibbonDisableTestNoSoftStencil = 1013,
        StretchBlurRibbonDisableTestStencil = 1014,
        StretchBlurRibbonNoSoft = 1015,
        StretchBlurRibbonNoSoftStencil = 1016,
        StretchBlurRibbonStencil = 1017,
        StretchBlurPolygonStrip = 1018,
        StretchBlurPolygonStripDisableTest = 1019,
        StretchBlurPolygonStripDisableTestNoSoft = 1020,
        StretchBlurPolygonStripDisableTestNoSoftStencil = 1021,
        StretchBlurPolygonStripDisableTestStencil = 1022,
        StretchBlurPolygonStripNoSoft = 1023,
        StretchBlurPolygonStripNoSoftStencil = 1024,
        StretchBlurPolygonStripStencil = 1025,
        Billboard3DStochasticTransparent = 1026,
        Billboard3DStochasticTransparentTextureBlend = 1027,
        Billboard3DStochasticTransparentTextureBlendNoSoft = 1028,
        Billboard3DStochasticTransparentTextureBlendNoSoftNorm = 1029,
        Billboard3DStochasticTransparentTextureBlendNorm = 1030,
        Billboard3DStochasticTransparentNoSoft = 1031,
        Billboard3DStochasticTransparentNoSoftNorm = 1032,
        Billboard3DStochasticTransparentNorm = 1033,
        Billboard3DStochasticTransparentZPrePass = 1034,
        Billboard3DStochasticTransparentZPrePassNorm = 1035,
        Billboard3DStochasticTransparentLighting = 1036,
        Billboard3DStochasticTransparentLightingTextureBlend = 1037,
        Billboard3DStochasticTransparentLightingTextureBlendNoSoft = 1038,
        Billboard3DStochasticTransparentLightingTextureBlendNoSoftNorm = 1039,
        Billboard3DStochasticTransparentLightingTextureBlendNorm = 1040,
        Billboard3DStochasticTransparentLightingNoSoft = 1041,
        Billboard3DStochasticTransparentLightingNoSoftNorm = 1042,
        Billboard3DStochasticTransparentLightingNorm = 1043,
        Billboard3DStochasticTransparentTexUnit = 1044,
        Billboard3DStochasticTransparentTexUnitNoSoft = 1045,
        Billboard3DStochasticTransparentTexUnitNoSoftSplitRGBA = 1046,
        Billboard3DStochasticTransparentTexUnitNoSoftSplitRGBANorm = 1047,
        Billboard3DStochasticTransparentTexUnitNoSoftNorm = 1048,
        Billboard3DStochasticTransparentTexUnitSplitRGBA = 1049,
        Billboard3DStochasticTransparentTexUnitSplitRGBANorm = 1050,
        Billboard3DStochasticTransparentTexUnitNorm = 1051,
        Billboard3DStochasticTransparentTexUnitLighting = 1052,
        Billboard3DStochasticTransparentTexUnitLightingNoSoft = 1053,
        Billboard3DStochasticTransparentTexUnitLightingNoSoftSplitRGBA = 1054,
        Billboard3DStochasticTransparentTexUnitLightingNoSoftSplitRGBANorm = 1055,
        Billboard3DStochasticTransparentTexUnitLightingNoSoftNorm = 1056,
        Billboard3DStochasticTransparentTexUnitLightingSplitRGBA = 1057,
        Billboard3DStochasticTransparentTexUnitLightingSplitRGBANorm = 1058,
        Billboard3DStochasticTransparentTexUnitLightingNorm = 1059,
        PolygonStochasticTransparent = 1060,
        PolygonStochasticTransparentTextureBlend = 1061,
        PolygonStochasticTransparentTextureBlendNoSoft = 1062,
        PolygonStochasticTransparentNoSoft = 1063,
        PolygonStochasticTransparentLighting = 1064,
        PolygonStochasticTransparentLightingTextureBlend = 1065,
        PolygonStochasticTransparentLightingTextureBlendNoSoft = 1066,
        PolygonStochasticTransparentLightingNoSoft = 1067,
        PolygonStripStochasticTransparent = 1068,
        PolygonStripStochasticTransparentTextureBlend = 1069,
        PolygonStripStochasticTransparentTextureBlendNoSoft = 1070,
        PolygonStripStochasticTransparentNoSoft = 1071,
        PolygonStripStochasticTransparentLighting = 1072,
        PolygonStripStochasticTransparentLightingTextureBlend = 1073,
        PolygonStripStochasticTransparentLightingTextureBlendNoSoft = 1074,
        PolygonStripStochasticTransparentLightingNoSoft = 1075,
        PolygonStochasticTransparentZPrePass = 1076,
        PolygonStripStochasticTransparentZPrePass = 1077,
        RibbonStochasticTransparent = 1078,
        RibbonStochasticTransparentTextureBlend = 1079,
        RibbonStochasticTransparentTextureBlendNoSoft = 1080,
        RibbonStochasticTransparentTextureBlendNoSoftNorm = 1081,
        RibbonStochasticTransparentTextureBlendNorm = 1082,
        RibbonStochasticTransparentNoSoft = 1083,
        RibbonStochasticTransparentNoSoftNorm = 1084,
        RibbonStochasticTransparentNorm = 1085,
        RibbonStochasticTransparentLighting = 1086,
        RibbonStochasticTransparentLightingTextureBlend = 1087,
        RibbonStochasticTransparentLightingTextureBlendNoSoft = 1088,
        RibbonStochasticTransparentLightingTextureBlendNoSoftNorm = 1089,
        RibbonStochasticTransparentLightingTextureBlendNorm = 1090,
        RibbonStochasticTransparentLightingNoSoft = 1091,
        RibbonStochasticTransparentLightingNoSoftNorm = 1092,
        RibbonStochasticTransparentLightingNorm = 1093,
        FluidBillboardStochasticTransparent = 1094,
        FluidBillboardStochasticTransparentNoSoft = 1095,
        FluidBillboardStochasticTransparentLighting = 1096,
        FluidBillboardStochasticTransparentLightingNoSoft = 1097,
        FluidPolygonStochasticTransparent = 1098,
        FluidPolygonStochasticTransparentNoSoft = 1099,
        FluidPolygonStochasticTransparentLighting = 1100,
        FluidPolygonStochasticTransparentLightingNoSoft = 1101,
        FluidPolygonStripStochasticTransparent = 1102,
        FluidPolygonStripStochasticTransparentNoSoft = 1103,
        FluidPolygonStripStochasticTransparentLighting = 1104,
        FluidPolygonStripStochasticTransparentLightingNoSoft = 1105,
        FluidRibbonStochasticTransparent = 1106,
        FluidRibbonStochasticTransparentNoSoft = 1107,
        FluidRibbonStochasticTransparentLighting = 1108,
        FluidRibbonStochasticTransparentLightingNoSoft = 1109,
        RibbonStochasticTransparentZPrePass = 1110,
        RibbonStochasticTransparentZPrePassNorm = 1111,
        FluidBillboardStochasticTransparentZPrePass = 1112,
        FluidPolygonStochasticTransparentZPrePass = 1113,
        FluidPolygonStripStochasticTransparentZPrePass = 1114,
        FluidRibbonStochasticTransparentZPrePass = 1115,
        Billboard3DAlphaDissolveDeferredLighting = 1116,
        Billboard3DAlphaDissolveDeferredLightingNorm = 1117,
        Billboard3DAlphaDissolveCutoutDeferredLighting = 1118,
        Billboard3DAlphaDissolveCutoutDeferredLightingLighting = 1119,
        Billboard3DAlphaDissolveCutoutDeferredLightingLightingNorm = 1120,
        Billboard3DAlphaDissolveCutoutDeferredLightingNorm = 1121,
        Billboard3DAlphaDissolveTexUnitDeferredLighting = 1122,
        Billboard3DAlphaDissolveTexUnitDeferredLightingLighting = 1123,
        Billboard3DAlphaDissolveTexUnitDeferredLightingLightingSplitRGBA = 1124,
        Billboard3DAlphaDissolveTexUnitDeferredLightingLightingSplitRGBANorm = 1125,
        Billboard3DAlphaDissolveTexUnitDeferredLightingLightingNorm = 1126,
        Billboard3DAlphaDissolveTexUnitDeferredLightingSplitRGBA = 1127,
        Billboard3DAlphaDissolveTexUnitDeferredLightingSplitRGBANorm = 1128,
        Billboard3DAlphaDissolveTexUnitDeferredLightingNorm = 1129,
        PolygonAlphaDissolveDeferredLighting = 1130,
        PolygonAlphaDissolveDeferredLightingLighting = 1131,
        PolygonStripAlphaDissolveDeferredLighting = 1132,
        PolygonStripAlphaDissolveDeferredLightingLighting = 1133,
        RibbonAlphaDissolveDeferredLighting = 1134,
        RibbonAlphaDissolveDeferredLightingLighting = 1135,
        RibbonAlphaDissolveDeferredLightingLightingNorm = 1136,
        RibbonAlphaDissolveDeferredLightingNorm = 1137,
        RibbonAlphaDissolveTexUnitDeferredLighting = 1138,
        RibbonAlphaDissolveTexUnitDeferredLightingLighting = 1139,
        RibbonAlphaDissolveTexUnitDeferredLightingLightingSplitRGBA = 1140,
        RibbonAlphaDissolveTexUnitDeferredLightingLightingSplitRGBANorm = 1141,
        RibbonAlphaDissolveTexUnitDeferredLightingLightingNorm = 1142,
        RibbonAlphaDissolveTexUnitDeferredLightingSplitRGBA = 1143,
        RibbonAlphaDissolveTexUnitDeferredLightingSplitRGBANorm = 1144,
        RibbonAlphaDissolveTexUnitDeferredLightingNorm = 1145,
        PolygonCutout = 1146,
        PolygonCutoutDisableTest = 1147,
        PolygonCutoutDisableTestTextureBlend = 1148,
        PolygonCutoutDisableTestTextureBlendNoSoft = 1149,
        PolygonCutoutDisableTestNoSoft = 1150,
        PolygonCutoutTextureBlend = 1151,
        PolygonCutoutTextureBlendNoSoft = 1152,
        PolygonCutoutNoSoft = 1153,
        PolygonCutoutLighting = 1154,
        PolygonCutoutLightingDisableTest = 1155,
        PolygonCutoutLightingDisableTestNoSoft = 1156,
        PolygonCutoutLightingNoSoft = 1157,
        PolygonCutoutMieLighting = 1158,
        PolygonCutoutMieLightingDisableTest = 1159,
        PolygonCutoutMieLightingDisableTestNoSoft = 1160,
        PolygonCutoutMieLightingNoSoft = 1161,
        PolygonCutoutLuminanceBleed = 1162,
        PolygonCutoutLuminanceBleedDisableTest = 1163,
        PolygonCutoutLuminanceBleedDisableTestTextureBlend = 1164,
        PolygonCutoutLuminanceBleedDisableTestTextureBlendNoSoft = 1165,
        PolygonCutoutLuminanceBleedDisableTestNoSoft = 1166,
        PolygonCutoutLuminanceBleedTextureBlend = 1167,
        PolygonCutoutLuminanceBleedTextureBlendNoSoft = 1168,
        PolygonCutoutLuminanceBleedNoSoft = 1169,
        PolygonCutoutShadow = 1170,
        PolygonCutoutShadowTranslucent = 1171,
        DistortionPolygonCutout = 1172,
        DistortionPolygonCutoutDisableTest = 1173,
        DistortionPolygonCutoutDisableTestNoSoft = 1174,
        DistortionPolygonCutoutNoSoft = 1175,
        PolygonCutoutOverdraw = 1176,
        PolygonCutoutOverdrawDisableTest = 1177,
        PolygonCutoutAlphaDissolve = 1178,
        PolygonCutoutAlphaDissolveLighting = 1179,
        PolygonCutoutZPrepass = 1180,
        PolygonCutoutSimpleLuminanceBleed = 1181,
        PolygonCutoutSimpleLuminanceBleedDisableTest = 1182,
        PolygonCutoutSimpleLuminanceBleedDisableTestTextureBlend = 1183,
        PolygonCutoutSimpleLuminanceBleedDisableTestTextureBlendNoSoft = 1184,
        PolygonCutoutSimpleLuminanceBleedDisableTestNoSoft = 1185,
        PolygonCutoutSimpleLuminanceBleedTextureBlend = 1186,
        PolygonCutoutSimpleLuminanceBleedTextureBlendNoSoft = 1187,
        PolygonCutoutSimpleLuminanceBleedNoSoft = 1188,
        PolygonCutoutDeferredLighting = 1189,
        PolygonCutoutDeferredLightingDisableTest = 1190,
        PolygonCutoutDeferredLightingDisableTestTextureBlend = 1191,
        PolygonCutoutDeferredLightingDisableTestTextureBlendNoSoft = 1192,
        PolygonCutoutDeferredLightingDisableTestTextureBlendNoSoftVolumetricFog = 1193,
        PolygonCutoutDeferredLightingDisableTestTextureBlendVolumetricFog = 1194,
        PolygonCutoutDeferredLightingDisableTestNoSoft = 1195,
        PolygonCutoutDeferredLightingDisableTestNoSoftVolumetricFog = 1196,
        PolygonCutoutDeferredLightingDisableTestVolumetricFog = 1197,
        PolygonCutoutDeferredLightingTextureBlend = 1198,
        PolygonCutoutDeferredLightingTextureBlendNoSoft = 1199,
        PolygonCutoutDeferredLightingTextureBlendNoSoftVolumetricFog = 1200,
        PolygonCutoutDeferredLightingTextureBlendVolumetricFog = 1201,
        PolygonCutoutDeferredLightingNoSoft = 1202,
        PolygonCutoutDeferredLightingNoSoftVolumetricFog = 1203,
        PolygonCutoutDeferredLightingVolumetricFog = 1204,
        ParticleDeferredLightingPolygonCutout = 1205,
        ParticleDeferredLightingPolygonCutoutOutdoor = 1206,
        PolygonCutoutAlphaDissolveDeferredLighting = 1207,
        PolygonCutoutAlphaDissolveDeferredLightingLighting = 1208,
        PolygonTexelOpCutoutLighting = 1209,
        PolygonTexelOpCutoutLightingDisableTest = 1210,
        PolygonTexelOpCutoutLightingDisableTestNoSoft = 1211,
        PolygonTexelOpCutoutLightingNoSoft = 1212,
        PolygonTexelOpCutoutDeferredLighting = 1213,
        PolygonTexelOpCutoutDeferredLightingDisableTest = 1214,
        PolygonTexelOpCutoutDeferredLightingDisableTestNoSoft = 1215,
        PolygonTexelOpCutoutDeferredLightingDisableTestNoSoftVolumetricFog = 1216,
        PolygonTexelOpCutoutDeferredLightingDisableTestVolumetricFog = 1217,
        PolygonTexelOpCutoutDeferredLightingNoSoft = 1218,
        PolygonTexelOpCutoutDeferredLightingNoSoftVolumetricFog = 1219,
        PolygonTexelOpCutoutDeferredLightingVolumetricFog = 1220,
        PolygonTexelOpCutout = 1221,
        PolygonTexelOpCutoutDisableTest = 1222,
        PolygonTexelOpCutoutDisableTestNoSoft = 1223,
        PolygonTexelOpCutoutNoSoft = 1224,
        StretchBlurBillboard3D = 1225,
        StretchBlurBillboard3DDisableTest = 1226,
        StretchBlurBillboard3DDisableTestNoSoft = 1227,
        StretchBlurBillboard3DDisableTestNoSoftStencil = 1228,
        StretchBlurBillboard3DDisableTestStencil = 1229,
        StretchBlurBillboard3DNoSoft = 1230,
        StretchBlurBillboard3DNoSoftStencil = 1231,
        StretchBlurBillboard3DStencil = 1232,
        Num = 1233,
    };
}
namespace app::AI {
    enum AttackPermitGroup {
        Group0 = 0,
        Group1 = 1,
        Group2 = 2,
        Group3 = 3,
        Group4 = 4,
        Group5 = 5,
    };
}
namespace via::motion::IkDamageAction {
    enum CalcuCenterOffset {
        ImpactState = 0,
        MaxState = 1,
    };
}
namespace via::dialog::VrServiceDialog {
    enum Mode {
        Positioning = 0,
        TipsForEnvironment = 1,
    };
}
namespace via::motion::tree::RoundingNode {
    enum Mode {
        Round = 0,
        Floor = 1,
        Ceil = 2,
    };
}
namespace app::CH9RewardManager {
    enum ClearType {
        CasualClear = 0,
        NormalClear = 1,
        HardClear = 2,
    };
}
namespace app::CH9Em7500::Action::Grapple {
    enum Type {
        SneakB = 0,
        DeathRoll = 1,
        DeathEscape = 2,
    };
}
namespace app::CH9Telemetry {
    enum OtherCountType {
        RightPunch = 0,
        LeftPunch = 1,
        Stomp = 2,
        Sneak = 3,
    };
}
namespace via::nnfc::nfp {
    enum NfpError {
        None = 0,
        NotSupport = 1,
        InvalidFormat = 2,
        WirelessOff = 3,
        TagLost = 4,
        TagLostOnFlush = 5,
        NoAppData = 6,
        MismatchApp = 7,
        NeedRegister = 8,
        NeedRestore = 9,
        NeedFormat = 10,
        DifferentTag = 61440,
        MismatchUser = 61441,
        Unknown = 65535,
    };
}
namespace app::CH9Em6400ActionController {
    enum ActionCancelType {
        Miss = 0,
        Guard = 1,
        Hit = 2,
        OverDistShort = 3,
        OverDistMiddle = 4,
        OverDistance = 5,
        HitTargetBack = 6,
    };
}
namespace app::CH8Em4400::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::render::Wrinkle {
    enum CalcMode {
        Maximum = 0,
        Average = 1,
    };
}
namespace app::CH9Em5850FollowBug {
    enum BankId {
        Basic = 10,
        Attack = 20,
        Damage = 30,
    };
}
namespace app::FF030_Ex_EndCard {
    enum StepEnum {
        WaitInput = 0,
        PAGE_1 = 1,
        PAGE_2 = 2,
        None = 3,
        Max = 4,
    };
}
namespace app::Em5520FollowBug {
    enum BankId {
        Basic = 10,
        Attack = 20,
        Damage = 30,
    };
}
namespace app::CH9StartCheck {
    enum StepType {
        CheckWait = 0,
        FirstCheck = 1,
        SystemLoad = 2,
        SystemCrushCutin = 3,
        SystemFailedCutin = 4,
        NotLoadCutin = 5,
        CheckEnd = 6,
    };
}
namespace via::network::ContextNpln {
    enum UserType {
        Prearranged = 0,
        New = 1,
        Existing = 2,
    };
}
namespace app::CH9Em6400ActionController {
    enum MoveMode {
        Default = 0,
        Fast = 1,
        Slow = 2,
    };
}
namespace via::gui {
    enum BlendType {
        Alpha = 0,
        Add = 1,
        Disable = 2,
    };
}
namespace app::Em5520::Action::Appear {
    enum Type {
        Born = 0,
        Gather = 1,
        Call = 2,
    };
}
namespace via::gui::detail {
    enum PageAlignmentH {
        Left = 0,
        Center = 1,
        Right = 2,
    };
}
namespace via::motion {
    enum RIKJointId {
        Hip = 7,
        LeftHip = 26,
        LeftKnee = 27,
        LeftAnkle = 28,
        RightHip = 30,
        RightKnee = 31,
        RightAnkle = 32,
        Waist = 2,
        LeftShoulder = 9,
        LeftElbow = 10,
        LeftWrist = 11,
        RightShoulder = 18,
        RightElbow = 19,
        RightWrist = 20,
        Head = 0,
        Spine1 = 3,
        Spine2 = 4,
        Spine3 = 5,
        Spine4 = 6,
        Neck = 1,
        LeftCollar = 8,
        RightCollar = 17,
        LeftFoot = 29,
        RightFoot = 33,
        Max = 24,
    };
}
namespace via::render {
    enum InstanceKeyState {
        Invalid = 0,
        Complete = 1,
    };
}
namespace via::autoplay::action::AutoButton {
    enum Activation {
        Together = 0,
        Sequence = 1,
    };
}
namespace via::motion::IkLeg2 {
    enum DirectionType {
        Global = 0,
        Local = 1,
        Manual = 2,
    };
}
namespace app::CH8SaveManager {
    enum SaveTextIndexPS4 {
        SLOT_TEXT_INDEX_AUTOSAVE = 0,
        SLOT_TEXT_INDEX_DIFFICULTY = 1,
        SLOT_TEXT_INDEX_PLAY_TIME = 2,
        SLOT_TEXT_INDEX_OBJECTIVE = 3,
        SLOT_TEXT_INDEX_COUNT = 4,
        SLOT_TEXT_INDEX_COUNT_NOT_AUTOSAVE = 3,
    };
}
namespace app::CH9Em7900::Action::FinishBlow {
    enum Type {
        SneakB = 0,
    };
}
namespace app::ShallowWaterMaterialControl {
    enum BoatType {
        Boat01 = 0,
        Boat02 = 1,
        Max = 2,
    };
}
namespace via::gui::MessageTag {
    enum Type {
        Unknown = 0,
        Page = 1,
        Line = 2,
        Size = 3,
        Font = 4,
        Color = 5,
        Char = 6,
        Space = 7,
        Wordwrap = 8,
        Center = 9,
        Left = 10,
        Right = 11,
        Top = 12,
        Bottom = 13,
        Time = 14,
        Ruby = 15,
        RubyB = 16,
        RubyRB = 17,
        RubyRT = 18,
        Event = 19,
        TCU = 20,
        Draw = 21,
        GlowDraw = 22,
        ShadowDraw = 23,
        Sprite = 24,
        Baseline = 25,
        Glow = 26,
        Shadow = 27,
        Italic = 28,
        Bold = 29,
    };
}
namespace app::fsm::CH8VideoDisp {
    enum SetState {
        Play = 0,
        Stop = 1,
        Clear = 2,
    };
}
namespace via::autoplay::action::AutoPlayTimer {
    enum Unit {
        Second = 0,
        Frame = 1,
    };
}
namespace app::InteractMaterialControl {
    enum Status {
        None = 0,
        Wait = 1,
        Stay = 2,
        Lock = 3,
        UnLock = 4,
        Choise = 5,
        ChoiseEnd = 6,
    };
}
namespace via::timeline {
    enum LoadState {
        Initialize = 0,
        Loading = 1,
        Reload = 2,
        Normal = 3,
        Empty = 4,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemSelectPanelState {
        DEFAULT = 0,
        LEVELMAX = 1,
        LEVELUP = 2,
    };
}
namespace via::physics::FilterInfoData {
    enum Attribute {
        MaskNAND = 0,
        Max = 1,
    };
}
namespace app::Em3100::Action::DiscoveryLoop {
    enum Type {
        Default = 0,
        Patrol = 1,
    };
}
namespace via::motion::tree::TransitionNode {
    enum Mode {
        Default = 0,
        Sync = 1,
    };
}
namespace via::render::PrimitiveFluid2D::Attribute {
    enum ParticleType {
        Billboard = 0,
        Polygon = 1,
        Ribbon = 2,
    };
}
namespace app::Em3001::Goal {
    enum AttackMessageStatus {
        Non = 0,
        Hit = 1,
        UnHit = 2,
        Guard = 3,
    };
}
namespace app::OptionMenu {
    enum ArrowDirc {
        None = 0,
        Left = 1,
        Right = 2,
    };
}
namespace via::render {
    enum PCTargetAPI {
        DirectX11 = 0,
        DirectX12 = 1,
        Vulkan = 2,
        DirectX12Legacy = 3,
    };
}
namespace System::Reflection {
    enum EventAttributes {
        None = 0,
        SpecialName = 512,
        RTSpecialName = 1024,
        ReservedMask = 1024,
    };
}
namespace via::navigation::MapAccessor {
    enum SearchResult {
        Found = 0,
        Wait = 1,
        None = 2,
    };
}
namespace app::WaveNotifyTimerUI {
    enum CountContext {
        Countdown = 0,
        Countup = 1,
    };
}
namespace app::HIDManager {
    enum MouseCursor {
        Hide = 0,
        Show = 1,
    };
}
namespace app::WeaponGun {
    enum BulletTypeSwitch {
        Normal = 0,
        Strong = 1,
    };
}
namespace via::simplewwise::BankInfoResource::IdNameInfo {
    enum LanguageType {
        None = 0,
        Japanese = 1,
        English_US = 2,
        French_France = 3,
        Italian = 4,
        German = 5,
        Spanish_Spain = 6,
        Chinese_PRC = 7,
    };
}
namespace app::GameManager {
    enum GameOverPostRno {
        Wait = 0,
        BlinkStart = 1,
        End = 2,
    };
}
namespace via::render::RenderConfig {
    enum AntiAliasingType {
        FXAA = 0,
        TAA = 1,
        FXAA_TAA = 2,
        SMAA = 3,
        NONE = 4,
    };
}
namespace via::render {
    enum MapType {
        WriteDiscard = 0,
        Read = 1,
    };
}
namespace via::autoplay::action::AutoNavigationPoint {
    enum ReachDistanceType {
        Long = 0,
        Normal = 1,
    };
}
namespace via::network::error {
    enum MethodWebSocketClient {
        Update = 0,
        Open = 1,
        Send = 2,
    };
}
namespace app::fsm::ChangePlayerGrowth {
    enum IncreaseType {
        None = 0,
        Weapon = 1,
        Recovery = 2,
        Health = 3,
        MoveSpeed = 4,
        ReloadSpeed = 5,
    };
}
namespace app::CH9Em5800 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::CommandAction {
    enum ProcessType {
        InActive = 0,
        Starting = 1,
        Active = 2,
        Ending = 3,
    };
}
namespace app::OptionManager {
    enum loadStep {
        Default = 0,
        FirstFontLoad = 1,
        unload = 2,
        load = 3,
    };
}
namespace via::motion::IkLeg2 {
    enum CastRayEventIdFlags {
        None = 0,
        Left = 1,
        Right = 2,
        Heal = 4,
        Detail = 8,
    };
}
namespace app::CH8Telemetry {
    enum GameOverType {
        CountOfByCaughtMother = 0,
        CountOfByCar = 1,
        CountOfByTrapBomb = 2,
        CountOfByTrapPendulum = 3,
        CountOfByTrapCake = 4,
        CountOfByLegCut = 5,
        CountOfBySuicide = 6,
        CountOfByGrapple = 7,
        CountOfBySuffocation = 16,
        CountOfByShieldMachine = 17,
        CountOfByInfraredTrap = 18,
        CountOfByTrapRescue = 19,
        CountOfByTurret = 20,
        CountOfByGasBomb = 21,
    };
}
namespace via::navigation::NavigationWaypoint {
    enum EndNodeUsage {
        Trace = 0,
        Skip = 1,
    };
}
namespace via::network::error {
    enum MethodHttpClient {
        Request = 0,
    };
}
namespace via::hid::virtualKeyboard::nsw {
    enum InitialCursorPos {
        First = 0,
        Last = 1,
    };
}
namespace app::Cp7NightmareReward {
    enum Type {
        CraftItem = 0,
        JumkBonus = 1,
        ItemBonus = 2,
        CraftTrap = 3,
    };
}
namespace app::Telemetry {
    enum OtherCountType {
        CountOfRepulsedInTheAir = 0,
        CountOfKilledByAttachBomb = 1,
        CountOfAvoidInTheSquat = 2,
        CountOfBrokenInsectDoors = 3,
        CountOfSucceededGuards = 4,
        CountOfOpenItemBox = 5,
        CountOfCutPlayerLegs = 6,
        CountOfCutPlayerArms = 7,
        CountOfOpenDoors = 8,
        CountOfCloseDoors = 9,
        CountOfSetupShadowPuzzle = 10,
        CountOfChooseMia = 11,
        CountOfChooseZoe = 12,
        CountOfAttackedCar = 13,
        CountOfDamagedCar = 14,
        CountOfGenerateNest = 15,
        CountOfDamageTrap = 16,
        CountOfInteractBrassiere = 17,
        CountOfDumpItem = 18,
        CountOfEatHerbs = 19,
        CountOfBilliards = 20,
    };
}
namespace via::sound::GameParameterInfo {
    enum Scope {
        None = 0,
        Global = 1,
        GameObject = 2,
        Request = 3,
    };
}
namespace app::fsm::CH8EndOperator {
    enum GUIStateTable {
        DEFAULT = 0,
        FADEOUT = 1,
    };
}
namespace via::movie::MovieManager {
    enum GCTarget {
        RAM = 0,
        VRAM = 1,
        MOVIE = 2,
    };
}
namespace app::PlayerExternalRequestController {
    enum Action {
        Empty = 0,
        Chapter1_Battle1_DownStairs = 1,
    };
}
namespace app::GameEventAction {
    enum ParentSettingOnEvent {
        NoChange = 0,
        RootObject = 1,
        Clear = 2,
    };
}
namespace app::fsm::MapExObject {
    enum ControlTypes {
        Default = 0,
        Mode1 = 1,
        Mode2 = 2,
    };
}
namespace System::Globalization {
    enum UnicodeCategory {
        UppercaseLetter = 0,
        LowercaseLetter = 1,
        TitlecaseLetter = 2,
        ModifierLetter = 3,
        OtherLetter = 4,
        NonSpacingMark = 5,
        SpacingCombiningMark = 6,
        EnclosingMark = 7,
        DecimalDigitNumber = 8,
        LetterNumber = 9,
        OtherNumber = 10,
        SpaceSeparator = 11,
        LineSeparator = 12,
        ParagraphSeparator = 13,
        Control = 14,
        Format = 15,
        Surrogate = 16,
        PrivateUse = 17,
        ConnectorPunctuation = 18,
        DashPunctuation = 19,
        OpenPunctuation = 20,
        ClosePunctuation = 21,
        InitialQuotePunctuation = 22,
        FinalQuotePunctuation = 23,
        OtherPunctuation = 24,
        MathSymbol = 25,
        CurrencySymbol = 26,
        ModifierSymbol = 27,
        OtherSymbol = 28,
        OtherNotAssigned = 29,
    };
}
namespace via::nnfc {
    enum NnfcMode {
        Invalid = 0,
        NFP = 1,
    };
}
namespace app::CH9Telemetry {
    enum RewardItemPattern {
        Item002 = 0,
        WP000 = 1,
        WP006 = 2,
        WP002 = 3,
        Max = 4,
    };
}
namespace via::gui::renderer::detail {
    enum PrimDrawType {
        Unknown = 0,
        Mesh = 1,
        MeshInstancing = 2,
        GUI = 3,
        GUIMaterial = 4,
    };
}
namespace via::vr::psCamera {
    enum PSCameraFramerate {
        PSCameraFramerate_UNKNOWN = 0,
        PSCameraFramerate_7_5 = 7,
        PSCameraFramerate_15 = 15,
        PSCameraFramerate_30 = 30,
        PSCameraFramerate_60 = 60,
        PSCameraFramerate_120 = 120,
        PSCameraFramerate_240 = 240,
    };
}
namespace app::GameManager {
    enum NowOnSaleType {
        Chapter7_1 = 0,
        Chapter7_2 = 1,
        Chapter7_3 = 2,
        Chapter7_4 = 3,
        BannedFootage = 4,
        NotaHero = 5,
        Chapter9 = 6,
    };
}
namespace via::autoplay::action::AutoButton {
    enum Unit {
        Seconds = 0,
        Frames = 1,
    };
}
namespace app::AreaHitObj {
    enum AreaHitType {
        Normal = 0,
        Flag = 1,
        MansionAI = 2,
        LookAt = 3,
        Feint = 4,
        StopInteract = 5,
    };
}
namespace app::CardGameItem {
    enum ItemRemoveType {
        NoUse = 0,
        Last = 1,
        All = 2,
        TableGoal = 3,
        MyBetDown = 4,
    };
}
namespace via::audiorender::fx::multi_band_eq {
    enum EQUnitEnable {
        False = 0,
        True = 1,
    };
}
namespace app::InteractClockPuzzle {
    enum ClockState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        RotLeft = 3,
        RotRight = 4,
        Success = 5,
        SuccessWait = 6,
        NotSuccess = 7,
        Close = 8,
        Exit = 9,
    };
}
namespace via::motion::MotionManager {
    enum CallUpdate {
        ComponentCollection = 0,
        Structure = 1,
        Frame = 2,
        FrameAsync = 3,
        Motion = 4,
        ConstraintBegin = 5,
        ConstraintEnd = 6,
        Expression = 7,
        DebugDraw = 8,
        ReloadCheck = 9,
    };
}
namespace app::CH9Em7500::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH8Em4100::Goal::CH8GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Discovery = 2,
        UnDiscovery = 3,
        ClosedRoute = 4,
        IdleLostTarget = 5,
        Idle = 6,
        Follow = 7,
        Grapple = 8,
        Dodge = 9,
        WallAttack = 10,
        StrikeScratch = 11,
        StrikeJump = 12,
        StrikeLongJump = 13,
        StrikeDash = 14,
        AroundFlewover = 15,
        Door = 16,
        DoorOpen = 17,
        DoorOpen2 = 18,
        DoorClose = 19,
        DoorClose2 = 20,
        Move = 21,
        AppearAction = 22,
        IdleAction = 23,
        IdleLostTargetAction = 24,
        NoticeAction = 25,
        WallAttackAction = 26,
        StrikeScratchAction = 27,
        StrikeJumpAction = 28,
        StrikeLongJumpAction = 29,
        StrikeDashAction = 30,
        AroundFlewoverAction = 31,
        DodgeAction = 32,
        GrappleAction = 33,
    };
}
namespace app::CH9Em7500::Action::Dead {
    enum Type {
        Normal = 0,
        Air = 1,
    };
}
namespace via::gui::Memo {
    enum MemoRotationType {
        Billboard = 0,
        TransformAndOffset = 1,
        OffsetOnly = 2,
    };
}
namespace app::fsm::SetGenomeCodexNoiseLv {
    enum RadarNoiseLvDef {
        None = 0,
        Lv1 = 1,
        Lv2 = 2,
    };
}
namespace via::storage {
    enum CompressionLevel {
        Default = 0,
        Maximum = 1,
    };
}
namespace via::clr {
    enum ExceptionTranslationFlag {
        None = 0,
        InvalidCast = 1,
        IndexOutOfRange = 2,
        NullReference = 4,
        ArgumentOutOfRange = 8,
        ArgumentNull = 16,
        InvalidOperation = 32,
        StackOverflow = 64,
        Argument = 128,
        Format = 256,
        NotImplemented = 512,
        NotSupported = 1024,
        Any = 65535,
    };
}
namespace app::StampController {
    enum SaveStateEnum {
        None = 0,
        Preparing = 1,
        Ready = 2,
    };
}
namespace via::os {
    enum FileError {
        None = 0,
        NotFound = 1,
        AccessDenied = 2,
        TooManyOpenFiles = 3,
        InvalidOperation = 4,
        Critical = 5,
    };
}
namespace via::vr::psCamera {
    enum PSCameraCaptureMemoryType {
        Onion = 1,
        Garlic = 2,
    };
}
namespace app::fsm::GUIFadeInOut {
    enum FadeDefine {
        FadeIn = 0,
        FadeOut = 1,
    };
}
namespace via::os {
    enum ConditionVariableError {
        None = 0,
        Failed = 1,
        TimedOut = 2,
    };
}
namespace app::AmbassadorTrialInGameTitle {
    enum TypeEnum {
        MainMenu = 0,
        InGame = 1,
        InGame_VR = 2,
    };
}
namespace via::motion::IkLeg2 {
    enum ToeCtrlOption {
        None = 0,
        TwoRayCast = 1,
        ToeOnly = 2,
    };
}
namespace app::Em3001::Action::TurnForWander {
    enum Type {
        Right = 0,
        Left = 1,
        BranchR = 2,
        BranchL = 3,
    };
}
namespace app::fsm::CallObjective {
    enum Mode {
        Disable = 0,
        Enable = 1,
    };
}
namespace app::CH8Em4090Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace via::gui {
    enum ResolutionAdjustAnchor {
        LeftTop = 0,
        LeftCenter = 1,
        LeftBottom = 2,
        CenterTop = 3,
        CenterCenter = 4,
        CenterBottom = 5,
        RightTop = 6,
        RightCenter = 7,
        RightBottom = 8,
        Max = 9,
    };
}
namespace via::render::layer::ShadowCast {
    enum ShadowCastSegment {
        StaticShadow = 0,
        ShadowClear = 1,
        ShadowSolid = 4,
        ShadowTwoSide = 5,
        ShadowTwoSideAlphaTest = 6,
        ShadowAlphaTest = 7,
        ShadowDitherCoverage = 8,
        ShadowTranslucent = 9,
        StaticShadowSolid = 4,
        StaticShadowTwoSide = 5,
        StaticShadowTwoSideAlphaTest = 6,
        StaticShadowAlphaTest = 7,
        CacheCopy = 16,
        DynamicShadow = 32,
        DynamicShadowSolid = 36,
        DynamicShadowTwoSide = 37,
        DynamicShadowTwoSideAlphaTest = 38,
        DynamicShadowAlphaTest = 39,
        DynamicShadowDitherCoverage = 40,
        DynamicShadowTranslucent = 41,
        Finalize = 48,
    };
}
namespace via::motion::GpuMotion {
    enum PlayState {
        Play = 0,
        Pause = 1,
        Stop = 2,
        Max = 3,
    };
}
namespace via::render::RenderTargetOperator {
    enum JpegSamplingRatio {
        YUV444 = 0,
        YUV422 = 1,
        YUV420 = 2,
        YUV411 = 3,
    };
}
namespace via::hid::VrTracker {
    enum OrientationType {
        Absolute = 0,
        Relative = 1,
    };
}
namespace app::CH9Em7700::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::effect::detail {
    enum PlayOrder {
        Forward = 0,
        Reverse = 1,
        RandomReverse = 2,
    };
}
namespace app::Em3102::Message {
    enum Priority {
        Low = 0,
        Middle = 1,
        High = 2,
    };
}
namespace via::navigation::NavigationSurface {
    enum LineAdjustSideType {
        ContourSide = 0,
        Both = 1,
    };
}
namespace via::motion::detail::IkFourLegSolver {
    enum SolverType {
        SOLVE_2BONE = 0,
        SOLVE_3BONE = 1,
    };
}
namespace via::AnimationCurve {
    enum Wrap {
        Once = 0,
        Loop = 1,
        Loop_Always = 2,
    };
}
namespace app {
    enum AccountPickerResult {
        ActiveUserChanged = 0,
        ActiveUserUnchanged = 1,
        InvalidUser = 2,
        GuestUser = 3,
        DeviceDisconnected = 4,
        Failed = 5,
    };
}
namespace app::ItemSelectReaction {
    enum Result {
        Success = 0,
        Failed = 1,
    };
}
namespace app::EffectSphereHolder::SphereInfo {
    enum Status {
        Start = 0,
        Update = 1,
        End = 2,
    };
}
namespace app::AI::MoldedCommonBoard {
    enum RenderTargetType {
        Slow = 0,
        Quick = 1,
        Fat = 2,
    };
}
namespace via::gui {
    enum Segment {
        Keep = -1,
        Segment00 = 0,
        Segment01 = 1,
        Segment02 = 2,
        Segment03 = 3,
        Segment04 = 4,
        Segment05 = 5,
        Segment06 = 6,
        Segment07 = 7,
        Segment08 = 8,
        Segment09 = 9,
        Segment10 = 10,
        Segment11 = 11,
        Segment12 = 12,
        Segment13 = 13,
        Segment14 = 14,
        Segment15 = 15,
        Segment16 = 16,
        Segment17 = 17,
        Segment18 = 18,
        Segment19 = 19,
        Segment20 = 20,
        Segment21 = 21,
        Segment22 = 22,
        Segment23 = 23,
        Segment24 = 24,
        Segment25 = 25,
        Segment26 = 26,
        Segment27 = 27,
        Segment28 = 28,
        Segment29 = 29,
        Segment30 = 30,
        Segment31 = 31,
        Segment32 = 32,
        Segment33 = 33,
        Segment34 = 34,
        Segment35 = 35,
        Segment36 = 36,
        Segment37 = 37,
        Segment38 = 38,
        Segment39 = 39,
        Segment40 = 40,
        Segment41 = 41,
        Segment42 = 42,
        Segment43 = 43,
        Segment44 = 44,
        Segment45 = 45,
        Segment46 = 46,
        Segment47 = 47,
        Segment48 = 48,
        Segment49 = 49,
        Segment50 = 50,
        Segment51 = 51,
        Segment52 = 52,
        Segment53 = 53,
        Segment54 = 54,
        Segment55 = 55,
        Segment56 = 56,
        Segment57 = 57,
        Segment58 = 58,
        Segment59 = 59,
        Segment60 = 60,
    };
}
namespace via {
    enum SystemServiceSummerTimeStatus {
        Unknown = 0,
        StandardTime = 1,
        SummerTime = 2,
    };
}
namespace app::VrExternalLightSetting {
    enum LightType {
        SpotLight = 0,
        LightProbes = 1,
        PointLight = 2,
        Max = 3,
    };
}
namespace app::fsm::EnemyStateCheck {
    enum EnemyIntType {
        None = 0,
    };
}
namespace app::Em5400::Action::GroundMove {
    enum Type {
        Normal = 0,
        Reaction = 1,
    };
}
namespace app::Em8000::Em8000Define::Grapple {
    enum FsmState {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
    };
}
namespace via::os {
    enum SocketOption {
        None = 0,
        TcpNoDelay = 1,
    };
}
namespace via::vr::detail {
    enum ControllerInfoType {
        Connection = 0,
        Input = 1,
        Pose = 2,
    };
}
namespace via::navigation::NavigationSurface {
    enum UnderSearchSettingType {
        Single = 0,
        Each = 1,
    };
}
namespace via {
    enum ShareServiceTicketStatus {
        Invalid = 0,
        Requested = 1,
        Running = 2,
        Finished = 3,
    };
}
namespace via::effect {
    enum PlayerType {
        Effect = 0,
        Lensflare = 1,
    };
}
namespace via::audiorender {
    enum PanType {
        Position = 0,
        Angle = 1,
        SphericalHarmonics = 2,
    };
}
namespace app::InteractRotateArt {
    enum ArtState {
        NotStart = 0,
        Init = 1,
        RotLeft = 2,
        RotRight = 3,
        Exit = 4,
    };
}
namespace app::CharacterDefine {
    enum Hand {
        Right = 0,
        Left = 1,
        Both = 2,
    };
}
namespace via::motion::RetargetFourLegRig {
    enum RotationControlType {
        Constant = 0,
        Interpolation = 1,
        InterpolationAdd = 2,
    };
}
namespace via::network::error {
    enum CauseProtocol {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        SendWindowFull = 129,
        ReceiveQueueFull = 130,
    };
}
namespace app::Em3000Grapple {
    enum Layer {
        Base = 0,
        Resist = 1,
        Guard = 2,
    };
}
namespace via::gui {
    enum FadeMode {
        In = 0,
        Wait = 1,
        Out = 2,
        Invisible = 3,
        End = 4,
    };
}
namespace via::navigation::Navigation {
    enum DetectBaseType {
        Agent = 0,
        Target = 1,
    };
}
namespace app::Em3000::Em3000WwiseMonitoredValue {
    enum GameRank {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        MAX = 10,
    };
}
namespace via::render::DepthOfField {
    enum DepthOfFieldBokehControl {
        Default = 0,
        IgnoreNear = 1,
        IgnoreFar = 2,
        DepthOfFieldBokehControle_Max = 3,
    };
}
namespace via::render::GeometryAOControl {
    enum GeometryAOCullTolerance {
        Small = 0,
        Middle = 1,
    };
}
namespace via::effect::detail {
    enum PtColorOperator {
        Overwrite = 0,
        Multiply = 1,
    };
}
namespace via::render::BottomLevelAccelerationStructure {
    enum COMPACTION {
        NOTSUPPORT = 1,
        WAIT = 2,
        READY = 4,
        COMPACTED = 8,
        COMPLETE = 16,
    };
}
namespace app::CarInGarage {
    enum StampSetting {
        Normal = 0,
        Burn = 1,
        Burnt = 2,
        End = 3,
    };
}
namespace app::CH9Em6700::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
    };
}
namespace app::Em3002Order::Appear {
    enum Type {
        None = 0,
        Dummy = 1,
        AppearF = 2,
        AppearR = 3,
        AppearL = 4,
        AppearTargetF = 5,
    };
}
namespace via::network::native::StadiaStatsValue {
    enum ValueType {
        Int = 0,
        Double = 1,
        String = 2,
    };
}
namespace app::fsm::CH8StateCheck {
    enum IntType {
        None = 0,
        Life = 1,
    };
}
namespace via::network::error {
    enum CauseMatchmaking {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        KickoutByHost = 129,
        Unsupported = 130,
    };
}
namespace app::Humanoid {
    enum LimbType {
        HandR = 0,
        HandL = 1,
        FootR = 2,
        FootL = 3,
    };
}
namespace app::CH9SM2644Movement {
    enum eBoatState {
        Wait = 0,
        PLRideWait = 1,
        Driving = 2,
        ControlledbyPier = 3,
        ControlledbyEvent = 4,
    };
}
namespace app::CH9ThrowingWp1800 {
    enum eHitWallType {
        None = 0,
        Wall = 1,
        Door = 2,
        BrokenFloor = 3,
    };
}
namespace via::network::error {
    enum CauseAchievements {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
    };
}
namespace via::render::ToneMapping {
    enum Vignetting {
        Enable = 0,
        KerarePlus = 1,
        Disable = 2,
    };
}
namespace app {
    enum DropTableID {
        DROP_TABLE_DEFAULT = 0,
    };
}
namespace app::Telemetry {
    enum ProgressType {
        Prologue = 0,
        Chapter1 = 1,
        Garage = 2,
        Scissor = 3,
        Greenhouse = 4,
        Partyroom = 5,
        Chapter3 = 6,
        Ship = 7,
        Chapter4 = 8,
        FF1 = 9,
        FF2 = 10,
        FF3 = 11,
        FF4 = 12,
    };
}
namespace via::audiorender::MemoryPool {
    enum MemoryPoolType {
        MemoryPoolType_None = 0,
        MemoryPoolType_4KiB = 1,
        MemoryPoolType_16KiB = 2,
        MemoryPoolType_64KiB = 3,
        MemoryPoolType_256KiB = 4,
        MemoryPoolType_1024KiB = 5,
        MemoryPoolType_Allocator = 6,
    };
}
namespace app::WireTrapIMD {
    enum State {
        Wait = 0,
        WireHit = 1,
        Explosion = 2,
        Broken = 3,
    };
}
namespace via::gui {
    enum GUIShaderCommonFlag {
        DrawRenderTarget = 1,
        LinearAlphaBlend = 2,
        LinearAlphaBlendNonLerp = 4,
    };
}
namespace via::navigation {
    enum DebugDrawAttribute {
        None = 0,
        Fill = 1,
        Contour = 2,
        ContourOnly = 4,
    };
}
namespace app::Em5520FollowBug {
    enum State {
        Normal = 0,
        Attack = 1,
        Return = 2,
        Damage = 3,
        Dead = 4,
        Born = 5,
        Gather = 6,
        Leave = 7,
        Suspend = 8,
    };
}
namespace mpl_::assert_ {
    enum relations {
        equal = 1,
        not_equal = 2,
        greater = 3,
        greater_equal = 4,
        less = 5,
        less_equal = 6,
    };
}
namespace via::audiorender {
    enum Channel_21ch {
        L = 0,
        R = 1,
        LFE = 2,
        Max = 3,
    };
}
namespace app::Em4000BladeController {
    enum Type {
        Default = 0,
        Slash = 1,
        SlashTry = 2,
        Grapple = 3,
        Pursuit = 4,
        None = -1,
    };
}
namespace app::CH8HUDControl::AirGauge {
    enum OxySoundState {
        Normal = 0,
        Warning = 1,
        Danger = 2,
    };
}
namespace via::motion::detail {
    enum ChainJiggleRangeShape {
        None = 0,
        OBB = 1,
        Sphere = 2,
        Cone = 3,
    };
}
namespace via::os::PackManager {
    enum HandleUsage {
        Read = 0,
        StartPrefetch = 1,
        QueryCache = 2,
    };
}
namespace app::MotionDelegate::TagProcess {
    enum CourseState {
        None = 0,
        Waiting = 1,
        FadingIn = 2,
        Running = 3,
        FadingOut = 4,
    };
}
namespace app::CH9Em5700::Action::Generate {
    enum Type {
        GenerateS = 0,
        GenerateM = 1,
        GenerateL = 2,
        GenerateCommon = 3,
    };
}
namespace app::Collision::HitController::DamageInfo {
    enum Attribution {
        None = 0,
        Fire = 1,
        Acid = 2,
    };
}
namespace via::clr {
    enum EnumU1 {
        Dummy = 0,
    };
}
namespace app::BirthdayWeaponMap {
    enum MapIconTypeDef {
        Weapon = 1,
    };
}
namespace via::render {
    enum GeometryAODirection {
        None = 0,
        Uniform = 1,
    };
}
namespace via::network::p2p {
    enum StarSocketProtocol {
        Udp = 0,
        Dtls = 1,
        Dblowfish = 2,
        Max = 3,
    };
}
namespace app::RewardData {
    enum GameMode {
        Main = 0,
        BirthdayGame = 1,
    };
}
namespace app::Command {
    enum StickType {
        Left = 0,
        Right = 1,
    };
}
namespace app::NowOnSaleMenu {
    enum ListElemID {
        GoNext = 0,
        Store = 1,
        Option = 2,
        RENet = 3,
    };
}
namespace app::TipsGUI {
    enum TipsPosState {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em2000::Em2000FaceController {
    enum FaceNo {
        Enemy = 0,
        Npc = 1,
        Blend = 2,
    };
}
namespace LibJson::JsonReader {
    enum Phase {
        Idle = 0,
        Name = 1,
        Value = 2,
    };
}
namespace via::os::dialog {
    enum Result {
        None = 0,
        Busy = 1,
        Ok = 2,
        RightButton = 3,
        LeftButton = 4,
        Cancel = 5,
        Abort = 6,
        Error = 7,
    };
}
namespace app::WaveTimerUIAsset {
    enum TimePanelState {
        TIME_AM = 0,
        TIME_PM = 1,
    };
}
namespace app::Em3102::Define::Mesh {
    enum State {
        Human = 0,
        Demon = 1,
    };
}
namespace app::FootEffectController {
    enum SETriggerTargetEnum {
        Player = 0,
        PlayerJog = 1,
        PlayerCrouch = 2,
        Enemy = 3,
        Num = 4,
    };
}
namespace app::CarInGarage::HijackedByEnemy {
    enum CoordGroup {
        PosSouthEast = 1,
        PosSouthWest = 2,
        PosNorthEast = 4,
        PosNorthWest = 8,
        DirNorth = 16,
        DirEast = 32,
        DirSouth = 64,
        DirWest = 128,
    };
}
namespace via::vr {
    enum VrEye {
        Left = 0,
        Right = 1,
    };
}
namespace via::render::VolumetricFogControl {
    enum DebugView {
        None = 0,
        Contribution = 1,
        Transmittance = 2,
    };
}
namespace via::motion::IkFourLeg {
    enum RayCastSkipOption {
        None = 1,
        DIV2 = 2,
        DIV4 = 4,
    };
}
namespace app::MapSheet {
    enum MapSegments {
        inactive = 34,
        active = 35,
        activeIcon = 36,
    };
}
namespace app::FloorDoor {
    enum State {
        Unknown = 0,
        Closed = 1,
        Opening = 2,
        Opened = 3,
        Closing = 4,
    };
}
namespace app::MotionExtraData {
    enum ContactStatus {
        None = 0,
        LeftLegContact = 1,
        RightLegContact = 2,
        LeftLegStop = 4,
        RightLegStop = 8,
        LeftLegFix = 5,
        RightLegFix = 10,
        BothLegContact = 3,
        BothLegFix = 15,
        LeftLegStep = 16,
        RightLegStep = 32,
        LeftToeStop = 64,
        RightToeStop = 128,
        LeftToeFix = 65,
        RightToeFix = 130,
        BothToeFix = 195,
        LegAll = 255,
        LeftHandContact = 256,
        RightHandContact = 512,
        LeftHandStop = 1024,
        RightHandStop = 2048,
        LeftHandFix = 1280,
        RightHandFix = 2560,
        BothHandContact = 768,
        BothHandFix = 3840,
        LeftHandStep = 4096,
        RightHandStep = 8192,
        LeftHandTipStop = 16384,
        RightHandTipStop = 32768,
        LeftHandTipFix = 16640,
        RightHandTipFix = 33280,
        BothHandTipFix = 49920,
    };
}
namespace via::DateTime {
    enum Comparison {
        Full = 0,
        FullAbout = 1,
        Date = 2,
        Time = 3,
        TimeAbout = 4,
    };
}
namespace via::attribute {
    enum KeyComparisonType {
        None = 0,
        Equal = 1,
        NotEqual = 2,
        Less = 3,
        LessEqual = 4,
        Greater = 5,
        GreaterEqual = 6,
    };
}
namespace via::userdata::CalculateNode {
    enum Operation {
        Add = 0,
        Sub = 1,
        Mul = 2,
        Div = 3,
        Mod = 4,
        Pow = 5,
        Min = 6,
        Max = 7,
    };
}
namespace via::motion::IkJacobian::Effector {
    enum AttributeType {
        Position = 1,
        Rotation = 2,
        Animation = 4,
        TargetObj = 8,
    };
}
namespace via::render::detail {
    enum PipelineStateVariation {
        Standard = 0,
        Instancing = 1,
        Max = 2,
    };
}
namespace app {
    enum PropCategory {
        Door = 0,
        Etc = 1,
    };
}
namespace System::Reflection {
    enum PropertyAttributes {
        None = 0,
        SpecialName = 512,
        RTSpecialName = 1024,
        HasDefault = 4096,
        Reserved2 = 8192,
        Reserved3 = 16384,
        Reserved4 = 32768,
        ReservedMask = 62464,
    };
}
namespace via::network::native::StadiaEntitlementConsumeResult {
    enum ConsumeError {
        None = 0,
        NotConsumable = 1,
        InvalidPlayer = 2,
        InvalidArgument = 3,
        ServiceUnavailable = 4,
        Unknown = 5,
    };
}
namespace app::Em8000::Action::Em8000KneeDown {
    enum Type {
        FromF = 0,
        FromB = 1,
        FromL = 2,
        FromR = 3,
        Small = 4,
        NoMotion = 5,
        AxeFromF = 6,
        AxeFromB = 7,
        AxeFromL = 8,
        AxeFromR = 9,
        AxeSmall = 10,
    };
}
namespace app::CH9Em5700::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        VolumeSpaceMoveToTarget = 2,
        VolumeSpaceMoveToPosition = 3,
        NoNavigationMoveToTarget = 4,
        SideMove = 5,
        GotoGeneratePoint = 6,
        GroundWait = 7,
        Dead = 8,
        Attack = 9,
        GroundToFly = 10,
        FlyToGround = 11,
        Turn = 12,
        Turn2 = 13,
        MenaceGround = 14,
        MenaceHovering = 15,
        HermiteCurveMove = 16,
        Generate = 17,
        GrappleToAttack = 18,
        Grapple = 19,
        Battle = 20,
        TargetApproach = 21,
        NearStabAttack = 22,
        StrikeAttack = 23,
        NearGrappleAttack = 24,
        ToGrapple = 25,
        MoveAtion = 26,
        IdleAction = 27,
        IdleReactionAction = 28,
        DeadAction = 29,
        AttackAction = 30,
        GroundToFlyAction = 31,
        FlyToGroundAction = 32,
        TurnAction = 33,
        MenaceGroundAction = 34,
        GenerateAction = 35,
        GrappleToAttackAction = 36,
        GrappleAction = 37,
    };
}
namespace app::Em5510ActionController {
    enum Size {
        Small = 0,
        Middle = 1,
        Large = 2,
    };
}
namespace via::network::session {
    enum SearchByFriendOption {
        None = 0,
    };
}
namespace app::PlayerUpperVerticalRotateParameter {
    enum ActionType {
        Normal = 0,
        Aim = 1,
        Unknown = 2,
    };
}
namespace app::Em8001::Motion::Em8001MotionID::Type {
    enum UpperOverride {
        None = 0,
        Gesture = 1,
    };
}
namespace via::clr::TypeDB {
    enum AttributeListKind {
        Default = 0,
        Field = 1,
        Method = 0,
        Property = 0,
        Event = 0,
        Type = 0,
        Parameter = 0,
        Module = 0,
        Assembly = 0,
        Num = 2,
    };
}
namespace via::areamap::test::DistanceFromItemWithTag {
    enum Condition {
        Mode_Closest = 0,
        Mode_Farthest = 1,
    };
}
namespace app::Em8000::Override::Em8000OverrideController {
    enum OverrideActionArg {
        Gesture = 0,
        CoreLoopStart = 1,
        CoreLoopEnd = 2,
    };
}
namespace app::CH8Em4000Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace app::Em3000Think {
    enum Mode {
        Idle = 0,
        Chapter3Battle1 = 1,
        Chapter3Battle1Final = 2,
        Chapter3Battle2 = 3,
        _DO_NOT_USE_Chapter3Battle2Final = 4,
        DebugWalk = 5,
        Em8000Hand = 6,
        Em8000Axe = 7,
        Em8000Scissors = 8,
        Chapter3Battle1FinalEnd = 9,
        Chapter3Battle2FinalEnd = 10,
    };
}
namespace app::Telemetry {
    enum GameOverType {
        CountOfByCaughtMother = 0,
        CountOfByCar = 1,
        CountOfByTrapBomb = 2,
        CountOfByTrapPendulum = 3,
        CountOfByTrapCake = 4,
        CountOfByLegCut = 5,
        CountOfBySuicide = 6,
        CountOfByGrapple = 7,
    };
}
namespace app {
    enum FormulationIDAlias {
        RemedyM = 0,
        RemedyL = 1,
        EyeDrops = 2,
        FlameBulletS = 3,
        AcidBulletS = 4,
        BurnerBullet = 5,
        HandgunBulletL = 6,
        HandgunBullet = 7,
    };
}
namespace app::CH9Em7700BladeLeftController {
    enum Type {
        Default = 0,
        Slash = 1,
        SlashTry = 2,
        Grapple = 3,
        Pursuit = 4,
        None = -1,
    };
}
namespace via::fsm::Selector {
    enum Attribute {
        AttributeSelectBeforeAction = 0,
        AttributeBitNum = 32,
    };
}
namespace via::network::error {
    enum MethodOverlaySession {
        Update = 0,
        HostChange = 1,
        Process = 2,
    };
}
namespace via::network::error {
    enum MethodProtocol {
        Update = 0,
        SendMember = 1,
        Deliver = 2,
    };
}
namespace via::effect::gpgpu::RibbonLengthCS::RibbonLengthResource {
    enum ShaderType {
        Default = 0,
        LuminanceBleed = 1,
        SimpleLuminanceBleed = 2,
        Default_IgnoreDepth = 3,
        LuminanceBleed_IgnoreDepth = 4,
        SimpleLuminanceBleed_IgnoreDepth = 5,
        StochasticPreZ = 6,
        StochasticTransparent = 7,
        MaxType = 8,
    };
}
namespace app::Em8000::Action::Em8000Walk {
    enum Type {
        None = 0,
        Normal = 1,
        LoopStart = 2,
    };
}
namespace via::wwise {
    enum EventTargetType {
        GameObject = 0,
        EntireComponent = 1,
    };
}
namespace via::path {
    enum DriveType {
        App = 0,
        SaveData = 1,
        AddContent = 2,
        Download = 3,
        Temp = 4,
        Host = 5,
        HostApp = 6,
        DevKit = 7,
        SdCard = 8,
        Home = 9,
        MaxType = 10,
    };
}
namespace via {
    enum VideoRecordingStopOption {
        SaveFile = 0,
        SaveFileAndExportLibrary = 1,
        Discard = 2,
    };
}
namespace System::Reflection {
    enum MemberTypes {
        Constructor = 1,
        Event = 2,
        Field = 4,
        Method = 8,
        Property = 16,
        TypeInfo = 32,
        Custom = 64,
        NestedType = 128,
        All = 191,
    };
}
namespace via::motion::IkLeg2Data {
    enum AxisFlags {
        X = 1,
        Y = 2,
        Z = 4,
        Negative = 8,
    };
}
namespace app::SaveDataManager {
    enum CrossSaveStep {
        None = 0,
        CheckExistingStart = 1,
        CheckExistingEnd = 2,
        CheckSystemStart = 3,
        CheckSystemEnd = 4,
        RemoveDataStart = 5,
        RemoveDataWait = 6,
        Begining = 7,
        LoadStart = 8,
        LoadWait = 9,
        SaveStart = 10,
        SaveWait = 11,
        Finish = 12,
        SaveExpansion = 13,
        DialogStart = 14,
        DialogWait = 15,
    };
}
namespace app::EnemyResistParameter {
    enum EnemyResistType {
        Small = 0,
        Middle = 1,
        Large = 2,
        Lost = 3,
        BlownAway = 4,
        Grapple = 5,
        ChanceCounter = 6,
        Max = 7,
        None = 8,
    };
}
namespace app::SceneActivater {
    enum SafeLoadStepEnum {
        WaiteActiveList = 0,
        WaiteStandbyList = 1,
    };
}
namespace via::effect::gpgpu::detail {
    enum VelocityType {
        None = 0,
        Radial = 1,
        Normal = 2,
        Direction = 3,
        Spread = 4,
        ScreenSpace = 5,
        TypeMask = 15,
    };
}
namespace via::gui::renderer::detail {
    enum PrimitiveDistortion {
        Blur = 0,
        Refract = 1,
    };
}
namespace via::motion::detail::IkFingerSolver {
    enum fingerType {
        Thumb = 0,
        Normal = 1,
    };
}
namespace app::CH8InfraredTrap {
    enum CoreState {
        Wait = 0,
        Explosion = 1,
        Broken = 2,
    };
}
namespace app::CH9Em5901Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace via {
    enum GamePresetsDifficulty {
        Default = 0,
        Easiest = 1,
        Easy = 2,
        Normal = 3,
        Hard = 4,
        Hardest = 5,
    };
}
namespace app::GameManager {
    enum BrowserMode {
        Normal = 0,
        NetRanking55 = 1,
        StorePageUWP = 2,
        PrivacyPolicy = 3,
    };
}
namespace app::CardGameItem {
    enum HandItemRemoveType {
        NoUse = 0,
        Mine = 1,
        MineHalf = 2,
        Yours = 3,
        YoursHalf = 4,
        YoursAll = 5,
    };
}
namespace via::render::RenderTargetOperator {
    enum PngFormat {
        RGB8bit = 0,
        RGBA8bit = 1,
    };
}
namespace app::PlayerTerrainMoveChecker {
    enum CheckDescendResult {
        None = 0,
        Success_Stand = 1,
        Success_Crouch = 2,
        Failure_Orthogonal = 3,
        Failure_EdgeNotFound = 4,
        Failure_TooLow = 5,
        Failure_TooHigh = 6,
        Failure_ObstacleFound = 7,
    };
}
namespace via::fsm {
    enum ExecGroup {
        ExecGroup_00 = 0,
        ExecGroup_01 = 1,
        ExecGroup_02 = 2,
        ExecGroup_03 = 3,
        ExecGroup_04 = 4,
        ExecGroup_05 = 5,
        ExecGroup_06 = 6,
        ExecGroup_07 = 7,
    };
}
namespace app::Em3102::Em3102ActionController {
    enum MotionSpeedControlGroup {
        Move = 0,
        Rank = 1,
    };
}
namespace app::InteractSendFsm {
    enum HardSaveState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        Success = 3,
        NotSuccess = 4,
        Cancel = 5,
        Exit = 6,
    };
}
namespace via::timeline {
    enum PlayState {
        PlayStart = 0,
        Play = 1,
        Stop = 2,
        Pause = 3,
        End = 4,
        HalfwayPlay = 5,
        PlayEnd = 6,
        Restore = 7,
    };
}
namespace app::ReticleGUI {
    enum WeaponTypeDef {
        HandGun = 0,
        MachineGun = 1,
        ShotGun = 2,
        LiquidBomb = 3,
        Burner = 4,
        Magnum = 5,
        GrenadeLauncher = 6,
        Nothing = 7,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum Status {
        Sleep = 0,
        Setup = 1,
        Standby = 2,
        Startup = 3,
        Active = 4,
        Cleanup = 5,
    };
}
namespace via::memory {
    enum PerfCounterType {
        Alloc = 0,
        LocalAlloc = 1,
        Free = 2,
        GCArena = 3,
        GCArenaFast = 4,
        AssignEmptyList = 5,
        AssignSearch = 6,
        AssignRetry = 7,
        End = 8,
    };
}
namespace app::Em3000Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
    };
}
namespace via::physics {
    enum FillMode {
        Solid = 0,
        WireFrame = 1,
        Solid_WireFrame = 2,
    };
}
namespace via::render {
    enum BlendOp {
        Add = 1,
        Subtract = 2,
        RevSubtract = 3,
        Min = 4,
        Max = 5,
        Num = 6,
    };
}
namespace via::motion {
    enum StartType {
        None = 0,
        Frame = 1,
        NormalizedTime = 2,
        SyncTime = 3,
        AutoSyncTime = 4,
        AutoSyncTimeSamePointCount = 5,
    };
}
namespace via::motion::IkDamageAction {
    enum DebugDamageTransition {
        Non = 0,
        ImpactState = 1,
        MaxState = 2,
    };
}
namespace app::AI::AIVolumeSpaceNavigationHelper {
    enum StateType {
        None = 0,
        Stopping = 1,
        End = 2,
    };
}
namespace app::Em2000::Action::Chapter1Battle2Throw {
    enum Type {
        ThrowingToLeft = 0,
        ThrowingToRight = 1,
    };
}
namespace via::render::DepthOfField {
    enum DepthOfFieldType {
        Default = 0,
        Tessellation = 1,
        Lite = 2,
        Circular = 3,
        Max = 4,
    };
}
namespace app::fsm::CH8InteractStart {
    enum StartTypeParam {
        Normal = 0,
        SwitchOn = 1,
        SwitchOff = 2,
    };
}
namespace app::CH9Em7800::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::AI {
    enum CommonThinkOrder {
        None = 0,
        Wait = 1,
        Goto = 2,
    };
}
namespace app::GameManager {
    enum PlayerChangeState {
        None = 0,
        PlayerUnLoad = 1,
        PlayerLoad = 2,
        PlayerLoadEnd = 3,
        Exit = 4,
    };
}
namespace via::effect::detail {
    enum MaterialType {
        Default = 0,
        VertexAnimation = 1,
    };
}
namespace app::CH8Em4500::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData {
    enum TransformElement {
        Trans = 0,
        Rot = 1,
        Scale = 2,
        Deform = 3,
        RotRPY = 4,
        RotPYR = 5,
        ExpMap = 6,
        Material = 7,
        MaterialF4 = 8,
        MaterialPosF4 = 9,
        MaterialRotF4 = 10,
        ComponentProperty = 11,
        UserValue = 12,
    };
}
namespace via::motion {
    enum MotionFrameControl {
        Normal = 0,
        SyncBaseLayerNormalizeTime = 1,
        PauseStartFrame = 2,
        PauseEndFrame = 3,
    };
}
namespace app::vr::VrFirstBootFlow {
    enum Phase {
        ReturnTitle = 0,
        ReturnTitleFade = 1,
        Cutin = 2,
        Request = 3,
        SuccessCutin = 4,
        FailedCutin = 5,
        Success = 6,
        Failed = 7,
        End = 8,
        TutorialCheck = 9,
    };
}
namespace via::motion {
    enum TreeLayerMode {
        None = 0,
        Motion = 1,
        Camera = 2,
    };
}
namespace app::CH9Em7900::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceKneeDown = 2,
        ForceSpin = 3,
    };
}
namespace via::gui {
    enum ReprojectionType {
        Default = 0,
        WithOverlay = 1,
    };
}
namespace via::render::layer::Transparent {
    enum ReducedTransparentBuffer {
        Eighth = 0,
        Quat = 1,
        Default = 2,
        Half = 3,
        Full = 4,
        Max = 5,
    };
}
namespace via::render {
    enum GlobalSparseShadowDebugDrawMode {
        None = 0,
        GlobalShadow = 1,
        BakeShadow = 2,
    };
}
namespace via::motion::IkLegSpine {
    enum FootLockRotOption {
        None = 0,
        AxisX = 1,
        AxisY = 2,
        AxisZ = 3,
    };
}
namespace app::fsm::InteractParamSet {
    enum FarIconForceDispParam {
        NoChange = 0,
        On = 1,
        Off = 2,
    };
}
namespace via::vr::psCamera {
    enum PSCameraFormatLevel {
        Level0 = 1,
        Level1 = 2,
        Level2 = 4,
        Level3 = 8,
        All = 15,
        LevelMax = 4,
    };
}
namespace app::BedRoom::BedRoomMonitoringGimick {
    enum MotionDirection {
        Right = 0,
        Front = 1,
        Left = 2,
    };
}
namespace via::physics::DynamicBoundingVolumeHierarchy {
    enum ErrorCode {
        None = 0,
        FunctorAbort = 1,
        Max = 2,
    };
}
namespace via::landscape::beta {
    enum NodePlaneSurfaceCountEnum {
        Surface1x1 = 0,
        Surface2x2 = 1,
        Surface4x4 = 2,
        Surface8x8 = 3,
        Surface16x16 = 4,
    };
}
namespace via::physics {
    enum ShapeClosestOption {
        AllHits = 0,
        DisableBackFacingTriangleHits = 1,
        DisableFrontFacingTriangleHits = 2,
        NearSort = 3,
        OneHitBreak = 4,
        Max = 5,
    };
}
namespace via::motion::DevelopRetarget {
    enum FootTarget {
        Foot = 0,
        Toe = 1,
    };
}
namespace via::motion {
    enum EJointLODGroupLevel {
        Default = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
        Max = 6,
    };
}
namespace app::ObjectiveGUI {
    enum Level {
        Main = 0,
        Sub = 1,
        SubSub = 2,
    };
}
namespace via::render {
    enum BindFlag {
        ShaderResource = 8,
        RenderTarget = 32,
        DepthStencil = 64,
        UnorderedAccess = 128,
    };
}
namespace via::clr {
    enum MethodCodeFlag {
        FatFormat = 3,
        TinyFormat = 2,
        MoreSects = 8,
        InitLocals = 16,
    };
}
namespace app::ItemExplanation {
    enum ItemIconPlayMotion {
        PlayerUse = 0,
        EnemyUse = 1,
        Get = 2,
    };
}
namespace app::ObjectLabel {
    enum Attribute {
        EmAppear = 0,
        EmHide = 1,
        EmClimb = 2,
        EmKnockable = 3,
        EmOpenable = 4,
        EmExit = 5,
        EmPush = 6,
        Dummy07 = 7,
        Dummy08 = 8,
        Dummy09 = 9,
        Dummy10 = 10,
        MotionUpdateInterval = 11,
        MovingTerrain = 12,
        FixedPressObject = 13,
        ISDNPauseTarget = 14,
        Dummy15 = 15,
        PlThreat = 16,
        PlFear = 17,
    };
}
namespace app::Em8000::Message {
    enum Tag {
        None = 0,
        Appear_A_0 = 100,
        Appear_B_0 = 101,
        PlayerChainsawGet_A_0 = 200,
        Move_A_0 = 300,
        Move_A_1 = 301,
        Move_A_2 = 302,
        DeathScissorsAttack_A_0 = 400,
        DeathScissorsAttack_B_0 = 401,
        Grapple_A_0 = 500,
        Grapple_B_0 = 501,
        Grapple_C_0 = 502,
        CoreRecovery_A_0 = 600,
        CoreRecovery_B_0 = 601,
        PlayerChainsawStop_A_0 = 700,
        PlayerChainsawStop_B_0 = 701,
        PlayerChainsawStop_C_0 = 702,
        PlayerDead_A_0 = 800,
        Dead_A_0 = 900,
    };
}
namespace via::hid::VrTracker {
    enum TrackerDevicePermitType {
        All = 0,
        HmdOnly = 1,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum AddPartsState {
        DEFAULT = 0,
        FADE_IN = 1,
        FADE_OUT = 2,
        DISABLE = 3,
    };
}
namespace via::hid::detail {
    enum VirtualKeyboardState {
        None = 0,
        Showing = 1,
        Done = 2,
    };
}
namespace app::Em3600::Goal::GoalGenerator {
    enum ID {
        OneAction = 0,
        OneAction2 = 1,
        UnDiscovery = 2,
        Dead = 3,
        Discovery = 4,
        NoMoveInsuranceJump = 5,
        Turn = 6,
        FourLegMoveTurn = 7,
        FourLegMoveBackTurn = 8,
        PoseChange = 9,
        TwoLegMove = 10,
        FourLegMove = 11,
        MoveToPosition = 12,
        MoveToTarget = 13,
        Attack = 14,
        GrappleAttack = 15,
        GrappleSneakAttack = 16,
        Step = 17,
        MoveToClimb = 18,
        MoveToDescend = 19,
        TurnAndAction = 20,
        Grapple = 21,
        DoorOpen = 22,
        DoorClose = 23,
        Jump = 24,
        Fall = 25,
        NearAppear = 26,
        ForceWarpNearAppear = 27,
        OrderAppear = 28,
        Suspend = 29,
        Wait = 30,
        BattleNormal = 31,
        DefaultMoveToTarget = 32,
        DefaultMoveToPosition = 33,
        TwoLegAttack = 34,
        FourLegAttack = 35,
        ComboAttack = 36,
        SideStep = 37,
        ToGrapple = 38,
        StandUp = 39,
        DropGrappleAttack = 40,
        TwoLegAttackHitInterval = 41,
        BackStepOrThrow = 42,
        BackStepAndThrow = 43,
        Throw = 44,
        TargetLadder = 45,
        TargetLadderAttack = 46,
        InShieldingSpot = 47,
        Damage = 48,
        WallDamage = 49,
        NormalDamage = 50,
        DamageBackMoveChoice = 51,
        DamageCellJump = 52,
        DamageBackWalk = 53,
        DamageBackJump = 54,
        FourLegRevMoveUp = 55,
        WallStickActionChoice = 56,
        FourLegRevEnd = 57,
        FourLegRevWallAttck = 58,
        Escape = 59,
        EscapeMoveToPosition = 60,
        HideChoice = 61,
        HideAndSneak = 62,
        HideAndGenerate = 63,
        JumpGround = 64,
        Genarate = 65,
        GenerateTargetJump = 66,
        Spawning = 67,
        GenerateCancel = 68,
        Last = 69,
        LastMoveToTarget = 70,
        Menace = 71,
        FourLegAttackHitInterval = 72,
        FourLegSideMove = 73,
        OmakeModeDiscovery = 74,
        WallModeCancel = 75,
        Sneak = 76,
        SneakSet = 77,
        SneakWait = 78,
        SneakWaitAndAttack = 79,
        ChangeSneakPointSet = 80,
        SneakGrappleStep = 81,
        SneakGrappleStartAttack = 82,
        SneakGrappleStartWaitAttack = 83,
        NearWarpAppear = 84,
        LerpAfterAppear = 85,
        SneakCancel = 86,
        OrderSneakSet = 87,
        BattleWall = 88,
        BattleWallMove = 89,
        WallMoveToTarget = 90,
        WallMoveSideTurn = 91,
        WallUp = 92,
        WallDown = 93,
        WallJump = 94,
        WallMoveCancel = 95,
        WallExMove = 96,
        WallFallAttack = 97,
        CellFallAttack = 98,
        WallJumpAttack = 99,
        WallModeFourLegAttack = 100,
        WallModeInsuranceJump = 101,
    };
}
namespace via {
    enum MobileBarState {
        Invisible = 0,
        Visible = 1,
        VisibleOverContent = 2,
    };
}
namespace app::CH8Em4200::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::motion::IkHand {
    enum CalculationType {
        CalculationType_Easy = 0,
        CalculationType_2Bone = 1,
        CalculationType_FitGround = 2,
        CalculationType_FitGround3D = 3,
        CalculationType_MultiConst = 4,
    };
}
namespace app::ElevatorButton {
    enum LightState {
        LightOff = 0,
        LightOn = 1,
        SwitchOn = 2,
    };
}
namespace via::effect::detail {
    enum LifeState {
        Unknown = 0,
        Wait = 1,
        Initialize = 2,
        Appear = 3,
        AppearOnly = 4,
        Keep = 5,
        KeepHold = 6,
        KeepAfter = 7,
        Vanish = 8,
        Terminate = 9,
    };
}
namespace app::InteractObjectBase {
    enum Category {
        None = 0,
        ManualInteract = 1,
        AutoInteract = 2,
        ChangeInteract = 3,
        NoManageInteract = 4,
    };
}
namespace via::hid::gamePlayer {
    enum DialogShowingState {
        None = 0,
        ShowingAcoountPicker = 1,
        ShowingDevicePicker = 2,
    };
}
namespace via::landscape {
    enum MapBakerGroundBakeType {
        SplatSDF = 0,
    };
}
namespace app::Em3002::Action {
    enum ActionShort {
        GrappleFinishMove = 0,
        PunchL = 1,
        Num = 2,
        Non = 99,
    };
}
namespace via::audiorender {
    enum Channel_2ch {
        L = 0,
        R = 1,
        Max = 2,
    };
}
namespace via::audiorender {
    enum SeekStatus {
        None = 0,
        Beforehand = 1,
        Immediately = 2,
    };
}
namespace app::Em3000::Action::Appear {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::fsm::PlayerStateCheck {
    enum PlayerBoolType {
        None = 0,
        FullyOperatable = 1,
        Move = 2,
        Jog = 3,
        Reloadable = 4,
        ModeChangeable = 5,
        CameraOperated = 6,
        GlassesScopeEnabled = 7,
        UseRemedy = 8,
        LArmHemostasis = 9,
        Reload = 10,
        StandUpAccepted = 11,
        GuardAccepted = 12,
        UseRemedyAccepted = 13,
        DetonateAccepted = 14,
        ChainSawReloadAccepted = 15,
        ChainSawAimAttackLoopAccepted = 16,
        UseBombAccepted = 17,
        BombSetup = 18,
        GunAttackAccepted = 19,
        MeleeAttackAccepted = 20,
        Guard = 21,
        LookAtTattooAccepted = 22,
        LookAtTattoo = 23,
        ChainSawReload = 24,
        MeleeAttack = 25,
        GunAttack = 26,
        ChainSawAimAttackLoop = 27,
        CameraOperatable = 28,
        ChangeMode = 29,
        MoveAccepted = 30,
        QuickTurnAccepted = 31,
        QuickTurn = 32,
        GunReloadAccepted = 33,
        ChangeModeAccepted = 34,
        SetMotionExternalTask = 35,
    };
}
namespace via::wwise {
    enum RequestType {
        None = 0,
        RegisterGameObject = 1,
        UnregisterGameObject = 2,
        SetActiveListeners = 3,
        SetListenerPosition = 4,
        Set3dPosition = 5,
        SetRtpcValue = 6,
        SetState = 7,
        SetSwitch = 8,
        PostEvent = 9,
        SeekOnEvent = 10,
        PostTrigger = 11,
        StopPlayingId = 12,
        StopAll = 13,
        SetGameObjectOutputBusVolume = 14,
        SetGameObjectAuxSendValues = 15,
        SetAttenuationScalingFactor = 16,
        SetObjectObstructionAndOcclusion = 17,
        AddOutput = 18,
        RemoveOutput = 19,
        ReplaceOutput = 20,
        SetSpeakerAngles = 21,
        RegisterEmitter = 22,
        UnregisterEmitter = 23,
        SetPortal = 24,
        RemovePortal = 25,
        SetRoom = 26,
        RemoveRoom = 27,
        SetGameObjectInRoom = 28,
        SetPortalObstructionAndOcclusion = 29,
        Max = 30,
    };
}
namespace app::Cp7MainMenu {
    enum ListElement {
        Nightmare = 0,
        BedRoom = 1,
        TwentyOne = 2,
        Daughters = 3,
        Quit = 4,
        Max = 5,
    };
}
namespace app::ExpansionData {
    enum ExpansionBool {
        Dummy = 0,
        Lang_Caption = 1,
        SaveDataTransfer = 2,
        Max = 512,
    };
}
namespace app::SmoothAnimatorTransitionTable::SubItem {
    enum Classification {
        Everything = 0,
        MotionGroup = 1,
    };
}
namespace via::landscape {
    enum MeshBakeType {
        TwoWay = 0,
        Upper = 1,
        Lower = 2,
    };
}
namespace via::storage::saveService {
    enum SaveServiceSegmentType {
        Default_0 = 0,
        Default_1 = 1,
        Default_2 = 2,
        Default_3 = 3,
        Default_4 = 4,
        Default_5 = 5,
        Default_6 = 6,
        Default_7 = 7,
        Default_8 = 8,
        Default_9 = 9,
        Temp_0 = 10,
        Telemetry_0 = 11,
        Telemetry_1 = 12,
        Telemetry_2 = 13,
        Telemetry_3 = 14,
        Telemetry_4 = 15,
        Telemetry_5 = 16,
        Telemetry_6 = 17,
        Telemetry_7 = 18,
        Telemetry_8 = 19,
        Telemetry_9 = 20,
        CacheStorage_0 = 21,
        CacheStorage_1 = 22,
        CacheStorage_2 = 23,
        CacheStorage_3 = 24,
        CacheStorage_4 = 25,
        CacheStorage_5 = 26,
        CacheStorage_6 = 27,
        CacheStorage_7 = 28,
        CacheStorage_8 = 29,
        CacheStorage_9 = 30,
        ImportMemory_0 = 31,
        OldFormat_0 = 32,
        Max = 33,
        Default_Head = 0,
        Default_Tail = 9,
        Temp_Head = 10,
        Temp_Tail = 10,
        Telemetry_Head = 11,
        Telemetry_Tail = 20,
        CacheStorage_Head = 21,
        CacheStorage_Tail = 30,
        ImportMemory_Head = 31,
        ImportMemory_Tail = 31,
    };
}
namespace app::Em3102::Message {
    enum Group {
        None = 0,
        Awareness = 1,
        Call_Jack = 2,
        Chase = 3,
        Chase_AfterKey = 4,
        Crazy = 5,
        Encount_Vision = 6,
        SteadyDown = 7,
        Walk = 8,
        Walk_Fast = 9,
    };
}
namespace via::physics {
    enum CastRayOption {
        AllHits = 0,
        DisableBackFacingTriangleHits = 1,
        DisableFrontFacingTriangleHits = 2,
        BackFacingHits = 3,
        BackFacingTriangleHits = 3,
        FrontFacingHits = 4,
        FrontFacingTriangleHits = 4,
        NearSort = 5,
        InsideHits = 6,
        OneHitBreak = 7,
        Max = 8,
    };
}
namespace app::Em3001Grapple {
    enum Layer {
        Base = 0,
        Resist = 1,
        Guard = 2,
    };
}
namespace via::wwise::SetState {
    enum SetTiming {
        Start = 0,
        End = 1,
    };
}
namespace via::navigation::NavigationWaypoint {
    enum RegionShapeType {
        OBB = 0,
        Sphere = 1,
    };
}
namespace app::CH8Em4450::CH8Em4450ThinkAppearSet {
    enum Type {
        Default = 0,
        Ground = 1,
        Mother = 2,
        Fall = 3,
        FromWall = 4,
        Em4460Spawn = 5,
        Splash = 6,
        AppearAttack = 7,
    };
}
namespace app::OtherRestartControl {
    enum RestartStepEnum {
        GetControlFolder = 0,
        CloseScene = 1,
        WaitCloseFolderOnMem = 2,
        WaitClose = 3,
        ActivateScene = 4,
        WaitActivate = 5,
        ApplayLoadData = 6,
        WaitApplay = 7,
        NotifyEndProc = 8,
        End = 9,
    };
}
namespace via::navigation::map::NodeContent {
    enum EdgeAttribute {
        Contour = 1,
        Divided = 2,
        Vertical = 4,
        ContourP0 = 8,
        ContourP1 = 16,
        WallP0 = 32,
        WallP1 = 64,
        InnerSide = 65536,
    };
}
namespace via::motion {
    enum TimingType {
        Now = 0,
        End = 1,
        SyncPoint = 2,
    };
}
namespace via::render {
    enum StencilOp {
        Keep = 1,
        Zero = 2,
        Replace = 3,
        IncSat = 4,
        DecSat = 5,
        Invert = 6,
        Inc = 7,
        Dec = 8,
        Num = 9,
    };
}
namespace via::navigation::PathfinderSurface {
    enum PathCreateType {
        UpperOnly = 0,
        LowerOnly = 1,
        Hybrid = 2,
    };
}
namespace app::CH8Em4200::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::os {
    enum SocketError {
        Pending = -1,
        None = 0,
        General = 1,
        NoEnoughMemory = 2,
        InvalidArgument = 3,
        NotProvided = 4,
        AlreadyInitialized = 5,
        NotInitialized = 6,
        CreateDescriptor = 7,
        SetOption = 8,
        GetOption = 9,
        Connect = 10,
        Bind = 11,
        Listen = 12,
        Accept = 13,
        SendSelf = 14,
        SendPeer = 15,
        RecvSelf = 16,
        RecvPeer = 17,
        DisconnectByPeer = 18,
        CloseByPeer = 19,
        DnsGeneral = 20,
        DnsNotFound = 21,
        DnsNoResult = 22,
    };
}
namespace app::FBIKAttackController {
    enum GuideModeType {
        Plane = 0,
        Line = 1,
    };
}
namespace app::Em8950WwiseMonitoredValue {
    enum LastBossMode {
        DemonWall = 0,
        Daidarabotchi = 1,
    };
}
namespace via::render::layer::DeferredLighting {
    enum LightingPathDebug {
        Albedo = 0,
        Diffuse = 1,
        Specular = 2,
        DirectLight = 3,
        Probe = 4,
        SSAO = 5,
        LocalCubeMap = 6,
        IBL = 7,
        SSR = 8,
        Max = 9,
    };
}
namespace via::render {
    enum PipeType {
        Graphics = 0,
        Compute = 1,
        Copy = 2,
        DMA = 3,
    };
}
namespace via::fsm::Action {
    enum SwitchSetting {
        Off = 0,
        On = 1,
    };
}
namespace via::os {
    enum ReadWriteLockError {
        None = 0,
        Failed = 1,
    };
}
namespace via::landscape {
    enum MapBakerStatus {
        NotStarted = 0,
        Running = 1,
        Completed = 2,
        Failed = 3,
    };
}
namespace System::Reflection {
    enum FieldAttributes {
        FieldAccessMask = 7,
        PrivateScope = 0,
        Private = 1,
        FamANDAssem = 2,
        Assembly = 3,
        Family = 4,
        FamORAssem = 5,
        Public = 6,
        Static = 16,
        InitOnly = 32,
        Literal = 64,
        NotSerialized = 128,
        SpecialName = 512,
        PinvokeImpl = 8192,
        RTSpecialName = 1024,
        HasFieldMarshal = 4096,
        HasDefault = 32768,
        HasFieldRVA = 256,
        ReservedMask = 38144,
    };
}
namespace via::motion::IkSpineConformGround::ManageJoint {
    enum JOINT_TYPE {
        NON = 0,
        START = 1,
        RAY = 2,
        END = 3,
    };
}
namespace via::gui {
    enum CursorType {
        Fix = 0,
        Move = 1,
        NoCursor = 2,
    };
}
namespace via::render::ToneMapping {
    enum TemporalAAAlgorithm {
        Legacy = 0,
        Standard = 1,
        StandardV2 = 2,
        Sharp = 3,
    };
}
namespace via::motion::JointRemapValue::RemapValueItem {
    enum CalculateMode {
        Sum = 0,
        Average = 1,
    };
}
namespace via::os::dialog {
    enum Error {
        None = 0,
        InvalidArgument = 1,
        Busy = 2,
        Unkown = 3,
    };
}
namespace via::userdata::CompareNode {
    enum Operation {
        Eq = 0,
        Neq = 1,
        Ge = 2,
        Le = 3,
        Gt = 4,
        Lt = 5,
    };
}
namespace via::os::http_client {
    enum Method {
        Get = 0,
        Post = 1,
        Put = 2,
        Patch = 3,
        Delete = 4,
    };
}
namespace app::Command {
    enum StickDirectionType {
        All = 0,
        AllInverse = 1,
        Vertical = 2,
        VerticalInverse = 3,
        Horizontal = 4,
        HorizontalInverse = 5,
        NearUp = 6,
        NearRight = 7,
        NearDown = 8,
        NearLeft = 9,
        Near8Up = 10,
        Near8UpRight = 11,
        Near8Right = 12,
        Near8DownRight = 13,
        Near8Down = 14,
        Near8DownLeft = 15,
        Near8Left = 16,
        Near8UpLeft = 17,
    };
}
namespace via::landscape {
    enum EcotopePipelineState {
        DrawDefault = 0,
        DrawMap = 1,
        DrawPoint = 2,
        DrawHeightField = 3,
        DrawHeightFieldSingle = 4,
        DrawPick = 5,
        UpdateDensityTexture = 6,
        FilterGeneratePoints = 7,
        FilterGeneratePointsSingle = 8,
        CountGeneratePointsSingle = 9,
        Max = 10,
    };
}
namespace via::clr::VM {
    enum CounterType {
        CycleGC = 0,
        LocalFrameGC = 1,
        GlobalFrameGC = 2,
        LocalObject = 3,
        LocalSize = 4,
        LocalToGlobal = 5,
        CycleGarbage = 6,
        CycleTrace = 7,
        GlobalGarbage = 8,
        Finalize = 9,
        Max = 10,
    };
}
namespace via::hid {
    enum AdaptiveTriggerMotor {
        LAnalogTriggerMotor = 0,
        RAnalogTriggerMotor = 1,
        Null = 254,
        All = 255,
    };
}
namespace app::BirthdayResult {
    enum ResultStepEnum {
        Wait_Result = 0,
        Draw_Rank = 1,
        Wait_DrawRank = 2,
        Wait_Input_Rank = 3,
        Check_Reward = 4,
        Wait_Reward = 5,
        Wait_Draw_SS = 6,
        Wait_Input = 7,
        Max = 8,
    };
}
namespace app::CH8Em4200::Action::CH8Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app {
    enum PropID {
        Etc = 0,
    };
}
namespace app::FirstLanguageGUI {
    enum Step {
        Main = 0,
        ChangeFont = 1,
        GoNext = 2,
    };
}
namespace via::audiorender {
    enum Channel_5ch {
        L = 0,
        R = 1,
        C = 2,
        Ls = 3,
        Rs = 4,
        Max = 5,
    };
}
namespace via::render::layer::CubemapCapture {
    enum BASIS {
        SH_ORDER1 = 0,
        SH_ORDER2 = 1,
        FC3_BASIS = 2,
        AMBIENTCUBE_BASIS = 3,
    };
}
namespace via::behavior::EffectEvent {
    enum LifeState {
        Unknown = 0,
        Wait = 1,
        Initialize = 2,
        Appear = 3,
        AppearOnly = 4,
        Keep = 5,
        KeepHold = 6,
        KeepAfter = 7,
        Vanish = 8,
        Terminate = 9,
    };
}
namespace via::os {
    enum MutexError {
        None = 0,
        Failed = 1,
    };
}
namespace app::CH8Em4400::Action {
    enum CH8ActionNo {
        MountTry = 4,
        Grapple = 5,
        Appear = 6,
        LostParts = 7,
        BlownAway = 8,
        SlipFire = 9,
        SlipAcid = 10,
        Falling = 11,
        Feint = 12,
        Anger = 13,
        Rush = 14,
        Splash = 15,
        Breath = 16,
        BreathFirst = 17,
        BreathForce = 18,
        ChanceCounter = 19,
        DamageToMove = 20,
        DamageToBreath = 21,
        Wait = 22,
        Suspend = 23,
        Resume = 24,
        Warp = 25,
        Generate = 26,
        Escape = 27,
        EasyWait = 28,
        AllFoursSmash = 29,
        Kneel = 30,
        SuspendWalk = 31,
        AppearDamage = 32,
    };
}
namespace via::motion::JointConstraintsResource {
    enum LegacyVersion {
        Latest = 0,
        Legacy1 = 1,
    };
}
namespace via::audiorender {
    enum ListenerBitMask {
        ListenerBitMask_0 = 1,
        ListenerBitMask_1 = 2,
        ListenerBitMask_2 = 4,
        ListenerBitMask_3 = 8,
        ListenerBitMask_4 = 16,
        ListenerBitMask_5 = 32,
        ListenerBitMask_6 = 64,
        ListenerBitMask_7 = 128,
    };
}
namespace app::Sm3073DamageController {
    enum TutorialNo {
        Attack = 0,
        RightOnlyCombo = 1,
        Combo = 2,
        Invalid = -1,
    };
}
namespace via::audiorender {
    enum StateThread {
        None = 0,
        Uninitialized = 1,
        Initializing = 2,
        Idle = 3,
        Executing = 4,
        Terminated = 5,
        Max = 6,
    };
}
namespace app::MapDoor {
    enum DoorState {
        DEFAULT = 0,
        UNLOCK = 1,
        LOCK = 2,
    };
}
namespace via::navigation {
    enum CostValueType {
        Unit = 0,
        Direct = 1,
    };
}
namespace via::audiorender {
    enum OutputBitsPerSample {
        OutputBitsPerSample_None = 0,
        OutputBitsPerSample_16bit = 16,
        OutputBitsPerSample_24bit = 24,
        OutputBitsPerSample_32bit = 32,
    };
}
namespace via::os::websocket_client {
    enum ErrorMethod {
        Update = 0,
        Open = 1,
        Send = 2,
    };
}
namespace via::landscape {
    enum TextureType {
        Heightmap = 0,
        UneditableMask = 1,
    };
}
namespace app::CH9Em7700::Action::Grapple {
    enum Type {
        Bite = 0,
        Mount = 1,
        Slash = 2,
    };
}
namespace app::Em3000 {
    enum ThinkOrder {
        None = 0,
        Chapter3Battle1_CutLeg = 1,
        Chapter3Battle1_Final = 2,
        Chapter3Battle1_Rest = 3,
        Chapter3Battle1_Rest_End = 4,
        Chapter3Battle1_GetIntoCar = 5,
        Chapter3Battle1_DrivePL = 6,
        Chapter3Battle1_DestroyTable = 7,
        Chapter3Battle1_DestroyWall = 8,
        Chapter3Battle1_CutLeg_End = 9,
    };
}
namespace app::Enemy {
    enum EnemySpecialAttribute {
        None = 0,
        Em3000BloodPunch = 1,
        Em5520FollowAttack = 2,
        Em5540FollowAttack = 3,
        Em8100StaggerAttack = 4,
        Em8500BlowAttack = 5,
        Em8510StaggerAttack = 6,
        Em8950DeadAttack = 7,
        MosquitoesAttack = 8,
    };
}
namespace app::Em3600ActionController {
    enum Em3600DamageDirection {
        Front = 0,
        Back = 10,
        Left = 20,
        Right = 30,
        Up = 40,
        Down = 50,
    };
}
namespace via::gui::detail {
    enum LetterAlignmentH {
        Left = 0,
        Center = 1,
        Right = 2,
    };
}
namespace app::CH9MoldedActionController {
    enum LinkGroup {
        GroupA = 0,
        GroupB = 1,
        GroupC = 2,
        GroupD = 3,
        GroupE = 4,
        GroupF = 5,
        GroupG = 6,
        GroupH = 7,
        GroupI = 8,
        GroupJ = 9,
        GroupK = 10,
        GroupL = 11,
        GroupM = 12,
        GroupN = 13,
        GroupO = 14,
        GroupP = 15,
        GroupQ = 16,
        GroupR = 17,
        GroupS = 18,
        GroupT = 19,
        GroupU = 20,
        GroupV = 21,
        GroupW = 22,
        GroupX = 23,
        GroupY = 24,
        GroupZ = 25,
    };
}
namespace app::CH9Em7800::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace via::physics::BoundingVolumeHierarchy {
    enum ErrorCode {
        None = 0,
        FunctorAbort = 1,
        Max = 2,
    };
}
namespace app::fsm::AreaHitTest {
    enum TestTypeParam {
        InArea = 0,
        OutArea = 1,
    };
}
namespace via::autoplay::AutoPlay {
    enum AutoPlayStatus {
        Wait = 0,
        PauseConvert = 1,
        PauseLoad = 2,
        Play = 3,
    };
}
namespace app::EnemyGenerator {
    enum Operation {
        None = 0,
        Spawn = 1,
        Kill = 2,
        Suspend = 3,
        Resume = 4,
        Dead = 5,
        ReAppearance = 6,
        Setup = 100,
        Suspending = 101,
    };
}
namespace app::CardGameCondition {
    enum CompareType {
        Equal = 0,
        NotEqual = 1,
        Less = 2,
        LessEqual = 3,
        Greater = 4,
        GreaterEqual = 5,
        NoUse = 6,
    };
}
namespace via::gui {
    enum TextAnimationCommand {
        Restart = 0,
        Resume = 1,
        Pause = 2,
        End = 3,
    };
}
namespace app::CH8CheckHitToBalloon {
    enum ConditionTable {
        SphereToSphere = 0,
        SphereToPoint = 1,
    };
}
namespace app::CH8Em4450::CH8Em4450ThinkStateSet {
    enum Type {
        Default = 0,
        Wait = 1,
    };
}
namespace app::Em8000::Action::Em8000ActionStatus {
    enum Mode {
        None = 0,
        Axe = 1,
        Hand = 2,
        Scissor = 3,
    };
}
namespace app::CraftBenchUIAsset {
    enum CostNumState {
        DEFAULT = 0,
        SHORTAGE = 1,
        LEVELMAX = 2,
    };
}
namespace app::CH9Em7900::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::InventoryMenu {
    enum ModeType {
        Normal = 0,
        InteractItemSelect = 1,
        ItemBoxMode = 2,
        ItemSet = 3,
    };
}
namespace app::Em2000Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Angry = 200,
        Dead = 5100,
    };
}
namespace app::CH8SaveDataOverWriter::OverWriteInfo {
    enum WriteTarget {
        Fsm = 0,
    };
}
namespace app::CharacterDefine {
    enum Vitality {
        Full = 0,
        Normal = 1,
        Weak = 2,
        Dying = 3,
    };
}
namespace app::LastWaveTime {
    enum Meridiem {
        AM = 0,
        PM = 1,
    };
}
namespace via::render {
    enum TextureAddressMode {
        TextureAddress_Wrap = 1,
        TextureAddress_Mirror = 2,
        TextureAddress_Clamp = 3,
        TextureAddress_Border = 4,
        TextureAddress_MirrorOnce = 5,
    };
}
namespace app::CH8Em4500::Action::CH8Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::CarInGarage::AfterCrashCommon {
    enum Routine {
        WaitStartEnemyOut = 0,
        LeakOil = 1,
        Fire = 2,
        WaitEnemyOut = 3,
        WaitExplosion = 4,
        WaitSecondExplosion = 5,
        JustAfterExplosion = 6,
        AfterExplosion = 7,
        End = 8,
    };
}
namespace app::Em3002::Action {
    enum ActionZero {
        GrappleFinishMove = 0,
        Non = 99,
    };
}
namespace hikako::GameIntentManager {
    enum LaunchType {
        OBJECTIVE = 0,
        CHALLENGE = 1,
        OPENENDED = 2,
    };
}
namespace via::areamap::test::DotProductItem {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace via::hid {
    enum ExecuteGroup_hdVibration {
        ExecuteGroup_00 = 0,
        ExecuteGroup_01 = 1,
    };
}
namespace app::Em8900::Action {
    enum ActionNo {
        Idle = 0,
        Idle_L = 1,
        Idle_R = 2,
        Idle_Offense = 3,
        MoveForward = 4,
        Damage = 5,
        Dead = 6,
        Recover = 7,
        Appear = 8,
    };
}
namespace via::dynamics {
    enum ClothCalculateMode {
        Default = 0,
        Performance = 1,
        Balance = 2,
        Quality = 3,
    };
}
namespace via::gui::renderer::detail {
    enum PrimitiveGUIMaskMode {
        None = 0,
        Target = 1,
        TargetReverse = 2,
        Mask = 3,
        MaskBlend2 = 4,
        MaskBlend3 = 5,
    };
}
namespace app::Em8001::Em8001AditiveDamageInfo {
    enum DamageDirection {
        INVALID = -1,
        None = 0,
        Front = 1,
        Back = 2,
        Left = 4,
        Right = 8,
        SUM = 15,
    };
}
namespace app::CH8ActivateObjectOperation {
    enum TargetBit {
        GameObject = 1,
        Colliders = 2,
        Fsm = 4,
        InteractSendFsm = 8,
        DoorPush = 16,
        CH8ActivateObjectOperation = 32,
    };
}
namespace app::CH8SaveMenu {
    enum ModeDef {
        LoadTitleMenu = 0,
        LoadInGame = 1,
        SaveInGame = 2,
        FirstSystemSave = 3,
    };
}
namespace app::OptionMenu {
    enum ListElemID {
        Controls = 0,
        Display = 1,
        Audio = 2,
        Language = 3,
        Graphics = 4,
        Record = 5,
        Default = 6,
    };
}
namespace app::ReticleGUI {
    enum HitSituation {
        NoHit = 0,
        Improper = 1,
        Hit = 2,
    };
}
namespace via::render::detail {
    enum PrimitiveVfxShaderCombiner {
        Default = 0,
        FlowMap = 1,
        Num = 2,
    };
}
namespace app::Em3001 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Battle = 2,
    };
}
namespace app::CH8StateSwitchEnvShieldMachine {
    enum CHP8_ENVSHIELDMACHINE {
        silence = 0,
        shieldmachine_rush = 1,
        shieldmachine_fire = 2,
        shieldmachine_escape = 3,
    };
}
namespace via::navigation::map::ContentWall {
    enum WallLinkType {
        Bottom = 0,
        Top = 1,
        Side = 2,
    };
}
namespace via::gui {
    enum ColorType {
        Fill = 0,
        Vertical = 1,
        Horizontal = 2,
        EachVertex = 3,
    };
}
namespace app::Em8001::Action::Damage {
    enum Type {
        INVALID = -1,
        NoDamage = 0,
        MHeadF = 1,
        MHeadB = 2,
        MHeadR = 3,
        MHeadL = 4,
        MBodyF = 5,
        MBodyB = 6,
        MBodyR = 7,
        MBodyL = 8,
        MLegL = 9,
        MLegR = 10,
        SUM = 11,
    };
}
namespace app::CH9Em6400::ThinkAppearSet {
    enum Type {
        Default = 0,
        Chapter92Battle = 200,
        Chapter92BattleFinal = 300,
        Chapter94BattleFinal = 500,
    };
}
namespace app::ObjectiveGUI {
    enum ModeDef {
        Inventory = 0,
        Map = 1,
    };
}
namespace app::fsm::VibrationSet {
    enum VibSizeType {
        SizeS = 0,
        SizeM = 1,
        SizeL = 2,
    };
}
namespace via::render {
    enum InputType {
        Static = 0,
        Dynamic = 1,
        PreTransformStatic = 2,
        PreTransformDynamic = 3,
        Max = 4,
        RenderTargetPS = 0,
        RenderTargetCS = 1,
        RenderTargetMax = 2,
        PostProcess = 0,
        PostProcessTonemap = 1,
        PostProcessTonemapTriplesection = 2,
        PostProcessTonemapTriplesectionHdr = 3,
        PostProcessTonemapHdr = 4,
        PostProcessTonemapC4L = 5,
        PostProcessTonemapTriplesectionC4L = 6,
        PostProcessTonemapTriplesectionC4LHdr = 7,
        PostProcessTonemapC4LHdr = 8,
        PostProcessMax = 9,
        SpeedTreeV8Optimize0 = 0,
        SpeedTreeV8Optimize1 = 1,
        SpeedTreeV8Optimize2 = 2,
        SpeedTreeV8OptimizeMax = 3,
        SpeedTreeV8Billboard = 0,
        SpeedTreeV8BillboardFaceCrossFading = 1,
        SpeedTreeV8BillboardMax = 2,
        Unknown = -1,
    };
}
namespace app::PlayerDefine {
    enum TouchType {
        None = 0,
        Wall = 1,
        Door = 2,
        EndImmediately = 3,
    };
}
namespace app::AI::CH9AIWorldBlackBoard {
    enum ExistPlayerHideZoneState {
        None = 0,
        Enter = 1,
        Overlap = 2,
        Leave = 3,
    };
}
namespace app::Em3000::Action::AttackBack {
    enum Type {
        SwingB = 0,
        PunchB = 1,
    };
}
namespace via::hansoft {
    enum HttpMethod {
        Get = 0,
        Post = 1,
        Put = 2,
        Delete = 3,
    };
}
namespace app::GenomeCodexGUI {
    enum RadarStateDef {
        None = 0,
        EnableTarget = 1,
        DisableTarget = 2,
    };
}
namespace via::hid {
    enum FlickDirection {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    };
}
namespace via::gui {
    enum InputGridType {
        None = 0,
        LeftStick = 1,
        RightStick = 2,
        Dpad = 3,
        Max = 4,
    };
}
namespace via::effect::gpgpu::detail {
    enum VelocityFlags {
        VelocityType = 0,
        EnableInherit = 4,
        UseWorldCoordinates = 5,
    };
}
namespace via::hid {
    enum KeyboardMainKey {
        None = 0,
        Back = 8,
        Tab = 9,
        Clear = 12,
        Enter = 13,
        Return = 13,
        Pause = 19,
        Capital = 20,
        Kana = 21,
        Junja = 23,
        Final = 24,
        Hanja = 25,
        Escape = 27,
        Convert = 28,
        NonConvert = 29,
        Accept = 30,
        ModeChange = 31,
        Space = 32,
        Prior = 33,
        Next = 34,
        End = 35,
        Home = 36,
        Left = 37,
        Up = 38,
        Right = 39,
        Down = 40,
        Select = 41,
        Print = 42,
        Execute = 43,
        SnapShot = 44,
        Insert = 45,
        Delete = 46,
        Help = 47,
        Alpha0 = 48,
        Alpha1 = 49,
        Alpha2 = 50,
        Alpha3 = 51,
        Alpha4 = 52,
        Alpha5 = 53,
        Alpha6 = 54,
        Alpha7 = 55,
        Alpha8 = 56,
        Alpha9 = 57,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LWin = 91,
        RWin = 92,
        Apps = 93,
        Sleep = 95,
        NumPad0 = 96,
        NumPad1 = 97,
        NumPad2 = 98,
        NumPad3 = 99,
        NumPad4 = 100,
        NumPad5 = 101,
        NumPad6 = 102,
        NumPad7 = 103,
        NumPad8 = 104,
        NumPad9 = 105,
        Multiply = 106,
        Add = 107,
        Separator = 108,
        Subtract = 109,
        Decimal = 110,
        Divide = 111,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F13 = 124,
        F14 = 125,
        F15 = 126,
        F16 = 127,
        F17 = 128,
        F18 = 129,
        F19 = 130,
        F20 = 131,
        F21 = 132,
        F22 = 133,
        F23 = 134,
        F24 = 135,
        NumLock = 144,
        Scroll = 145,
        NumPadEnter = 146,
    };
}
namespace app::CH9Em5700::Action::Grapple {
    enum Type {
        Stab = 0,
    };
}
namespace via::landscape::MeshDrawParameterRange {
    enum Bit {
        Solid = 1,
        AlphaTest = 2,
        Transparent = 16,
        Forward = 8,
        NoTransparent = 11,
    };
}
namespace via::landscape {
    enum MapBakerPointCloudBakeType {
        SplatSDF = 0,
    };
}
namespace via::gui {
    enum CircleColorType {
        Fill = 0,
        InOut = 1,
    };
}
namespace app::Em3002::Em3002ActionController {
    enum Message {
        DiscoveryHearing = 0,
        DiscoveryVision = 1,
        UnDiscovery = 2,
        Wander = 3,
        WalkNormal = 4,
        Rest = 5,
        RestForWindow = 6,
        RestForUnderFloor = 7,
        DeadPL = 8,
        OpenShutterPL = 9,
        Num = 10,
    };
}
namespace via::network::error {
    enum MethodSession {
        Update = 0,
        Create = 1,
        SearchByFilter = 2,
        SearchByFriend = 3,
        SearchByUniqueId = 4,
        Join = 5,
        Kick = 6,
        Invite = 7,
        SetSearchKey = 8,
        SetCustomProperty = 9,
        SetPrivate = 10,
        SetClose = 11,
        GetInfo = 12,
        DropMember = 13,
        InviteByUniqueId = 13,
    };
}
namespace via::network::wrangler {
    enum XsapiPropertySet {
        Dimensions = 0,
        Measurement = 1,
    };
}
namespace via::network::session {
    enum FilterAttr {
        None = 0,
        FindFull = 1,
    };
}
namespace via::autoplay::AutoPlay {
    enum PadEnterType {
        Nomal = 0,
        Reverse = 1,
    };
}
namespace app::Elevator {
    enum DoorAngleType {
        Front = 0,
        Back = 1,
    };
}
namespace via::hansoft {
    enum EnvironmentType {
        None = 0,
        Test = 1,
        Prod = 2,
    };
}
namespace app::CH9Em6400::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        UnDiscovery = 2,
        Discovery = 3,
        Idle = 4,
        BattleIdle = 5,
        Turn = 6,
        Follow = 7,
        Confront = 8,
        DamageToAction = 9,
        GuardToAction = 10,
        Search = 11,
        Leave = 12,
        Rest = 13,
        Step = 14,
        StepForAttackCancel = 15,
        StepBack = 16,
        StepIn = 17,
        GuardFollow = 18,
        Appeal = 19,
        AppealAwaken = 20,
        AppealProvoke = 21,
        Grapple = 22,
        AttackToGrapple = 23,
        GrappleFromAttack = 24,
        Combo = 25,
        ActionZero = 26,
        ActionZeroBase = 27,
        ActionZeroCrouch = 28,
        ActionShort = 29,
        ActionShortBase = 30,
        ActionShortCrouch = 31,
        ActionMiddle = 32,
        ActionMiddleBase = 33,
        ActionMiddleCrouch = 34,
        ActionFar = 35,
        ActionFarBase = 36,
        ActionFarCrouch = 37,
        ActionZeroBackBase = 38,
        ActionShortBackBase = 39,
        ActionAttackSp = 40,
        ActionCounter = 41,
        ActionCancel = 42,
        Attack = 43,
        AttackZero = 44,
        AttackShort = 45,
        AttackMiddle = 46,
        AttackBackShort = 47,
        AttackSp = 48,
        AttackCounter = 49,
        AttackCancel = 50,
        AppearAction = 51,
        WalkAction = 52,
        IdleAction = 53,
        TurnAction = 54,
        AppealAction = 55,
        GrappleAction = 56,
        AttackZeroAction = 57,
        AttackToGrappleAction = 58,
        GrappleFromPlayer = 59,
        Chapter92Battle = 60,
        Chapter92BattleBase = 61,
        Chapter92Battle_Leave = 62,
        Chapter92BattleFinal = 63,
        Chapter92BattleFinalBase = 64,
        Chapter94BattleFinal = 65,
        Chapter94BattleFinalBase = 66,
        Dead = 67,
    };
}
namespace app::CrusherUIAsset {
    enum MaterPanelState {
        DEFAULT = 0,
        EMPTY = 1,
        FULL = 2,
    };
}
namespace app::MotionGroupTable {
    enum MoveTypeEnum {
        Other = 0,
        Idle = 1,
        Walk = 2,
        Run = 3,
    };
}
namespace app::CH8Em4450::Action {
    enum CH8ActionCategory {
        Follow = 5,
    };
}
namespace via::render {
    enum ShallowWaterRenderingPriority {
        PreDecal = 0,
        PostDecal = 1,
    };
}
namespace app::Em3101Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace via::render {
    enum LightImportantLevel {
        Highest = 0,
        High = 1,
        Normal = 2,
        Low = 3,
        Lowest = 4,
    };
}
namespace via::navigation::map::PathInfo {
    enum PathObjectAttribute {
        GlobalPortalPosition = 0,
        PossibleNearEnd = 1,
        FixNodeCenter = 2,
        PassingExtraLink = 3,
        SkipThis = 4,
        DisableRecalcPortalLine = 5,
    };
}
namespace app::Collision::HitController {
    enum PressSkipAxis {
        X = 1,
        Y = 2,
        Z = 4,
    };
}
namespace via::storage::ProprietaryDLC {
    enum ErrorReason {
        InvalidToken = 0,
        Unknown = 1,
        None = 2,
        NetworkRequest = 3,
        StorageSpace = 4,
        Corrupted = 5,
    };
}
namespace app::AsyncLoadManager {
    enum PriorityEnum {
        Primary = 0,
        Secondary = 1,
    };
}
namespace via::effect::detail::CustomCSData {
    enum ShaderType {
        EmitBillboard = 0,
        EmitRibbonFollow = 1,
        EmitRibbonLength = 2,
        EmitMesh = 3,
        EmitMeshTrail = 4,
        EmitLightning3D = 5,
        EmitPolygon = 6,
        InitializeParticleItem = 7,
        UpdateBillboard = 8,
        UpdateRibbonFollow = 9,
        UpdateRibbonLength = 10,
        UpdateMesh = 11,
        UpdateMeshTrail = 12,
        UpdateLightning3D = 13,
        UpdatePolygon = 14,
        Max = 15,
    };
}
namespace via::effect::lensflare {
    enum AxisType {
        PositiveX = 0,
        PositiveY = 1,
        PositiveZ = 2,
        NegativeX = 3,
        NegativeY = 4,
        NegativeZ = 5,
    };
}
namespace app::Ch9AccelerationControl {
    enum eStatus {
        Stop = 0,
        Acceleration = 1,
        Deceleration = 2,
    };
}
namespace app::CH8Em4100::Action::CH8Move {
    enum Type {
        Solo = 0,
        Normal = 1,
        Wanderer = 2,
    };
}
namespace app::CH9Em7500ActionController {
    enum DivingType {
        ToAppear = 0,
        Suspend = 1,
        SelfDie = 2,
    };
}
namespace app::CH9MoldedActionController {
    enum Tension {
        Normal = 0,
        Excite = 1,
        Anger = 2,
    };
}
namespace app::Em8100::Action::Idle {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
        StandF = 3,
    };
}
namespace app::GameManager {
    enum GameClearState {
        None = 0,
        Init = 1,
        Reward0 = 2,
        Reward1 = 3,
        Reward2 = 4,
        Reward3 = 5,
        Reward4 = 6,
        CloseReward = 7,
        SaveData = 8,
        Exit = 9,
        Announcement = 10,
    };
}
namespace app::Em8000::Em8000AroundTargetAgent {
    enum DistanceGroup {
        Near = 0,
        Middle = 1,
        Far = 2,
    };
}
namespace app::Achievement {
    enum FoundFootageIndex {
        TVCrew = 0,
        RunawayMia = 1,
        PlayPuzzle = 2,
        Memory = 3,
    };
}
namespace via::motion::tree::BaseGamePadButtonNode {
    enum BtnKind {
        LL = 0,
        LU = 1,
        LR = 2,
        LD = 3,
        RL = 4,
        RU = 5,
        RR = 6,
        RD = 7,
        LB = 8,
        RB = 9,
    };
}
namespace via::effect::dev::PreviewAnimationBehavior {
    enum PreviewAxis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace via::effect::detail {
    enum BlendType {
        AlphaBlend = 0,
        Physical = 1,
        AddContrast = 2,
        EdgeBlend = 3,
        Multiply = 4,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData {
    enum OutputMode {
        Mode_Sum = 0,
        Mode_Average = 1,
        Mode_Mul = 2,
        Mode_Min = 3,
        Mode_Max = 4,
    };
}
namespace app::Em8001::Define::WeaponGroup {
    enum Group {
        INVALID = -1,
        None = 0,
        Handgun = 1,
        Shotgun = 2,
        Melee = 3,
        Grenade = 4,
        Bomb = 5,
        Magnum = 6,
        MachineGun = 7,
        Other = 8,
    };
}
namespace via::network::log {
    enum Category {
        None = 0,
        Dev01 = 1,
        Dev02 = 2,
        Dev03 = 3,
        Dev04 = 4,
        Dev05 = 5,
        Dev06 = 6,
        Dev07 = 7,
        Dev08 = 8,
        Dev09 = 9,
        Dev10 = 10,
        QA_01 = 11,
        QA_02 = 12,
        QA_03 = 13,
        QA_04 = 14,
        QA_05 = 15,
        QA_06 = 16,
        QA_07 = 17,
        QA_08 = 18,
        QA_09 = 19,
        QA_10 = 20,
    };
}
namespace app::MenuSound {
    enum MenuSoundTrigger {
        Enter = 0,
        Exit = 1,
        Cursol = 2,
        ChangeValue = 3,
        Decision = 4,
        Back = 5,
        NotSelect = 6,
        MapFileMenuOpen = 7,
        MapFileMenuClose = 8,
        MapFileMenuChange = 9,
        FileNextPage = 10,
    };
}
namespace via::render::LightShaft {
    enum LightShaftType {
        AABB = 0,
        LightSpaceCalc = 1,
        SimpleVolume = 2,
        AABBExtinction = 3,
        LightSpaceCalcExtinction = 4,
        Num = 5,
    };
}
namespace via::motion::MotionListElementData {
    enum Flags {
        Flags_Mirror = 1,
        Flags_LocalTree = 2,
        Flags_3 = 4,
        Flags_4 = 8,
        Flags_5 = 16,
        Flags_6 = 32,
        Flags_7 = 64,
        Flags_SeqOnly = 128,
    };
}
namespace via::Rect3DXZ {
    enum VoronoiId {
        L_Bit = 1,
        R_Bit = 2,
        T_Bit = 4,
        B_Bit = 8,
        Internal = 0,
        Edge_L_Bit = 1,
        Edge_R_Bit = 2,
        Edge_T_Bit = 4,
        Edge_B_Bit = 8,
        Vertex_LT_Bit = 5,
        Vertex_LB_Bit = 9,
        Vertex_RT_Bit = 6,
        Vertex_RB_Bit = 10,
    };
}
namespace via::os {
    enum BackgroundInstallSpeed {
        Slow = 0,
        Suspend = 1,
        Fast = 2,
    };
}
namespace via::attribute::FsmCategoryAttribute {
    enum Category {
        None = 0,
        Fsm = 1,
        Mot = 2,
        Auto = 4,
        BehaviorTree = 8,
        Timeline = 16,
    };
}
namespace via::render::SSAOControl {
    enum SSAOAlgorithm {
        Default = 0,
        Temporal = 1,
    };
}
namespace app::CH8TipsData {
    enum DifficultyBits {
        Casual = 1,
        Normal = 2,
        Hard = 4,
    };
}
namespace app::AdditionalTreeLayer {
    enum PriorityLevel {
        None = 0,
        Low = 1,
        Middle = 2,
        High = 3,
    };
}
namespace via::Application {
    enum RuntimeTargetType {
        Target_Undefined = 0,
        TargetMachine_Mask = 15,
        TargetMachine_PC = 1,
        TargetMachine_PS4 = 2,
        TargetMachine_XB1 = 3,
        TargetMachine_NSW = 4,
        TargetMachine_PS5 = 5,
        TargetMachine_Linux = 6,
        TargetMachine_STADIA = 7,
        TargetMachine_Mobile = 8,
        TargetMachine_XBS = 9,
        TargetMachine_Mac = 10,
        TargetMachineDetail_Mask = 240,
        TargetMachineDetail_PS4Base = 16,
        TargetMachineDetail_PS4NEO = 32,
        TargetMachineDetail_XB1 = 48,
        TargetMachineDetail_XB1X = 64,
        TargetMachineDetail_XBSS = 80,
        TargetMachineDetail_XBSX = 96,
        TargetOS_Mask = 3840,
        TargetOS_Windows = 256,
        TargetOS_PS4 = 512,
        TargetOS_NSW = 768,
        TargetOS_PS5 = 1024,
        TargetOS_Linux = 1280,
        TargetOS_STADIA = 1536,
        TargetOS_Android = 1792,
        TargetOS_iOS = 2048,
        TargetOS_OSX = 2304,
        TargetServicePlatform_Mask = 61440,
        TargetServicePlatform_Default = 4096,
        TargetServicePlatform_Steam = 8192,
        TargetServicePlatform_UWP = 12288,
        TargetServicePlatform_WeGame = 16384,
        TargetServicePlatform_Ubitus = 20480,
        TargetServicePlatform_Solstice = 24576,
    };
}
namespace via::motion::Motion {
    enum DrawTarget {
        Hidden = 0,
        Main = 1,
        All = 2,
        Layer0 = 3,
        Layer1 = 4,
        Layer2 = 5,
        Layer3 = 6,
        Layer4 = 7,
        Layer5 = 8,
        Layer6 = 9,
        Layer7 = 10,
    };
}
namespace via::wwise {
    enum WwiseProjectNo {
        WwiseProjectNo_0 = 0,
        WwiseProjectNo_1 = 1,
        WwiseProjectNo_2 = 2,
        WwiseProjectNo_3 = 3,
        WwiseProjectNo_Default = 0,
    };
}
namespace via::audiorender {
    enum Channel_1ch {
        Channel_1Ch = 0,
        Max = 1,
    };
}
namespace via::motion::detail::ChainNode {
    enum HitFlags {
        None = 0,
        Self = 2,
        Model = 4,
        Collider = 8,
        Angle = 16,
        Group = 32,
        VGround = 64,
        Collision = 110,
    };
}
namespace app::CH9Em5700Think {
    enum Mode {
        Ground = 0,
        Fly = 1,
    };
}
namespace via::render::detail::PrimitiveMeshMaterialManager {
    enum ShaderCapability {
        AlphaTest = 1,
        TwoSided = 2,
    };
}
namespace app::CH9SM2644Movement {
    enum CollisionID {
        PressNormal = 0,
    };
}
namespace via::wwise::midi {
    enum MMC {
        Stop = 1,
        Play = 2,
        RecStrobe = 3,
    };
}
namespace app::InteractZoomSendFsm {
    enum ZoomState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        Close = 3,
        Exit = 4,
    };
}
namespace app::CH8Em4400::Action::CH8Generate {
    enum EggParts {
        Head = 8,
        Chest = 9,
        Hip = 10,
        Thigh = 11,
    };
}
namespace via::str::detail::format::csharp::format_item {
    enum ExFmtFlag {
        Ignore = 0,
        SetPrecision = 0,
        ZeroPadding = 0,
        Centering = 0,
    };
}
namespace app::Bomb {
    enum UpdateRno {
        Wait = 0,
        Explosion = 1,
        Sleep = 2,
    };
}
namespace via::render::LDRImagePlane {
    enum BlendType {
        Overlay = 0,
        Max = 1,
    };
}
namespace CH8Em4400Effect {
    enum CH8IDAlias {
        Explosion = 0,
        Splash = 1,
        VerticalSplash = 2,
        HorizontalSplash = 3,
        LostHead = 4,
        LostLeftArm = 5,
        LostRightArm = 6,
        LostLeftLeg = 7,
        LostRightLeg = 8,
        StandSplashFromSequence = 9,
        WalkSplashFromSequence = 10,
        CrawlSplashFromSequence = 11,
        SimpleSplashFromSequence = 12,
        GrappleSplashFromSequence = 13,
        SelfSplashFromSequence = 14,
        Spore = 15,
    };
}
namespace app::AI::AILookAtAgent {
    enum Distance {
        Near = 0,
        Middle = 1,
        Far = 2,
    };
}
namespace via::landscape {
    enum GroundCommonSegment {
        WarmingPhysicalTexture = 0,
        ClearVirtualTexture = 1,
        Streaming = 2,
        Default = 3,
    };
}
namespace app::fsm::PositionCheck {
    enum CheckTimeTypeEnum {
        Time = 0,
        TotalTime = 1,
    };
}
namespace app::CH9RankManager {
    enum Flow {
        None = 0,
        Run = 1,
        CheckMessage = 2,
        MessageDisp = 3,
        WaitSelect = 4,
        WaitSelect2 = 5,
        WaitInfo = 6,
        End = 7,
    };
}
namespace app::fsm::HandLightPower {
    enum ActionType {
        None = 0,
        ForceOn = 1,
        ForceOff = 2,
    };
}
namespace app::BirthdayPlayerSelector {
    enum PlayerNoEnum {
        Player01 = 0,
        Player02 = 1,
        Max = 2,
    };
}
namespace app::Havok::RigidBodyDestruct {
    enum EraseModeEnum {
        None = 0,
        Partial = 1,
        All = 2,
    };
}
namespace via::userdata {
    enum ParamType {
        Unknown = 0,
        Bool = 1,
        U8 = 2,
        S8 = 3,
        U16 = 4,
        S16 = 5,
        S32 = 6,
        U32 = 7,
        S64 = 8,
        U64 = 9,
        F32 = 10,
        F64 = 11,
        Str8 = 12,
        Str16 = 13,
        Address = 14,
        Object = 15,
        Vec2 = 16,
        Vec3 = 17,
        Vec4 = 18,
        Matrix = 19,
        Guid = 20,
    };
}
namespace via::graph {
    enum VertexIndex {
        Invalid = -1,
        From = 0,
        To = 1,
    };
}
namespace app::CardGameInventoryMenu {
    enum StepType {
        OpenWait = 0,
        ItemSlot = 1,
        ItemMove = 2,
        Discard = 3,
        Close = 4,
    };
}
namespace via::motion::IkLegSpine {
    enum OffsetCtrl {
        None = 0,
        LocalOffset = 1,
        WorldOffset = 2,
        Local = 3,
        World = 4,
    };
}
namespace app::RecordOrderContainer {
    enum Type {
        Blood = 0,
        Scar = 1,
        Water = 2,
        Foam = 3,
    };
}
namespace app::Em2000::Action {
    enum ActionNo {
        Idle = 0,
        DoorOpen = 1,
        Chapter1Battle1Crawl = 2,
        Chapter1Battle1ThrowStairs = 3,
        Chapter1Battle1Idle = 4,
        Chapter1Battle1Mount = 5,
        Chapter1Battle1Standup = 6,
        Chapter1Battle1Run = 7,
        Chapter1Battle1Finish = 8,
        Chapter1Battle2CloserSlow = 9,
        Chapter1Battle2CloserFast = 10,
        Chapter1Battle2KnifeStab = 11,
        Chapter1Battle2KnifeRush = 12,
        Chapter1Battle2Chase = 13,
        Chapter1Battle2Throw = 14,
        Chapter1Battle2Counter = 15,
        Chapter1Battle2Damage = 16,
        Chapter1Battle2Dead = 17,
        Chapter1Battle2Attack = 18,
        Chapter1Battle4WalkStrafe = 19,
        Chapter1Battle4Run = 20,
        Chapter1Battle4StabAttack = 21,
        Chapter1Battle4SlashAttack = 22,
        Chapter1Battle4DestroyObject = 23,
        Chapter1Battle4RunAttack = 24,
        Chapter1Battle4BackStabGrapple = 25,
        Chapter1Battle4CloseRange = 26,
        Chapter1Battle4StabGrapple = 27,
        Chapter1Battle4SlashGrapple = 28,
        Chapter1Battle4RunSlashGrapple = 29,
        Chapter1Battle4MountRun = 30,
        Chapter1Battle4Mount = 31,
        Chapter1Battle4Stick = 32,
        Chapter1Battle4Finish = 33,
        Chapter1Battle4Damage = 34,
        Chapter1Battle4Dead = 35,
        Chapter1Battle4DeadLoop = 36,
        Chapter43Sleep = 37,
    };
}
namespace app::MoveCharacter {
    enum TEST_RE_SWITCH_MT {
        MT_CONCRETE = 0,
        MT_SOIL = 1,
    };
}
namespace app::CH8CharacterExistActionRestrictZoneGroup::ActionRestrictWork {
    enum Type {
        Em4000Grapple = 0,
        Em4100WallAttack = 1,
        Em4100AroundFlewover = 2,
        Em4200Grapple = 3,
        Em4300Grapple = 4,
        Em4200Walk = 5,
        Em4400Grapple = 6,
        Em4450Grapple = 7,
        CounterRush = 8,
        Stomp = 9,
    };
}
namespace via::motion::detail::ChainGroupData {
    enum AttrFlags {
        None = 0,
        RootRotation = 1,
        AngleLimit = 2,
        ExtraNode = 4,
        CollisionDefault = 8,
        CollisionSelf = 16,
        CollisionModel = 32,
        CollisionVGround = 64,
        CollisionCollider = 128,
        CollisionGroup = 256,
        EnablePartBlend = 512,
        WindDefault = 1024,
        TransAnimation = 2048,
        AngleLimitRestitution = 4096,
        StretchBoth = 8192,
        EndRotConstraint = 16384,
        EnableEnvWind = 32768,
    };
}
namespace via::gui::detail {
    enum PageAlignmentV {
        Top = 0,
        Center = 1,
        Bottom = 2,
    };
}
namespace via::effect::detail {
    enum SourceSinkType {
        Circle = 0,
        Rectangle = 1,
    };
}
namespace via::hid::mouse {
    enum ManipulatorClientType {
        Null = 0,
        DirectInput = 1,
        RawInput = 2,
        WindowMessage = 3,
        GlobalParameter = 4,
        RuntimeDefault = 5,
        ToolDefault = 6,
    };
}
namespace via::motion::IkMultipleDamageAction {
    enum CalcuCenterOffset {
        ImpactState = 0,
        MaxState = 1,
    };
}
namespace via::debug {
    enum LevelType {
        Verbose = 0,
        Warning = 1,
        Info = 2,
        Error = 3,
        Fatal = 4,
    };
}
namespace app::OptionMenu {
    enum CameraItem {
        NormalFOV = 0,
        AimFOV = 1,
        RotDirc = 2,
        RotSpd = 3,
        RotInertia = 4,
        Shake = 5,
    };
}
namespace via::network::protocol {
    enum MemberIndex {
        None = -1,
        All = -2,
        Other = -3,
        Self = -4,
        Host = -5,
    };
}
namespace app::PlayerCamera {
    enum RotationInertiaType {
        None = 0,
        Weak = 1,
        Normal = 2,
        Strong = 3,
    };
}
namespace via::effect::detail {
    enum FlipType {
        None = 0,
        Flip = 1,
        RandomFlip = 2,
    };
}
namespace app::OptionMenu {
    enum Dynamicrange {
        Large = 0,
        Small = 1,
    };
}
namespace app::EnemySpawnInfo {
    enum CollisionFilterType {
        PressCheckDefault = 0,
        TerrainCheckDefault = 1,
        TerrainCheckEnemy = 2,
        TerrainCheckBoss = 3,
        TerrainCheckFly = 4,
        EffectCheckDefault = 5,
        EffectCheckBullet = 6,
        EffectCheckVision = 7,
    };
}
namespace app::PlayerDefine {
    enum ReturnState {
        Unknown = 0,
        StandIdle = 1,
        CrouchIdle = 2,
        ProneIdle = 3,
        SupineIdle = 4,
        BlowDamage_LadderL = 5,
        BlowDamage_LadderR = 6,
        BlowDamage_SlantingLadderL = 7,
        BlowDamage_SlantingLadderR = 8,
        Damage = 9,
    };
}
namespace hikako::raytracing::RayTracingManager {
    enum MachineType {
        INVALID = 0,
        PC = 1,
        PS4 = 2,
        XB1 = 3,
        PS5 = 4,
        XBS = 5,
    };
}
namespace via::render::LightProbes {
    enum LightProbesPriority {
        Base = 0,
        Low = 1,
        Middle = 2,
        High = 3,
        Higher = 4,
        Highest = 5,
    };
}
namespace via::render::PrimitiveMaterialGeometry {
    enum GeometryType {
        Billboard3D = 0,
        Ribbon = 1,
        Polygon = 2,
        Max = 3,
    };
}
namespace app::CH9Em5700::Action::Damage {
    enum Type {
        DamageS = 0,
        DamageFlyS_L = 1,
        DamageFlyS_R = 2,
        DamageLGround = 3,
    };
}
namespace via {
    enum ScreenShotImageSize {
        ScreenShotImageSize_1280x720 = 0,
    };
}
namespace via::gui::BlurManager {
    enum BlurFilterLayerType {
        None = 0,
        Transparent = 1,
        PostEffect = 2,
        Overlay = 3,
    };
}
namespace via::render {
    enum Blend {
        Zero = 1,
        One = 2,
        SrcColor = 3,
        InvSrcColor = 4,
        SrcAlpha = 5,
        InvSrcAlpha = 6,
        DestAlpha = 7,
        InvDestAlpha = 8,
        DestColor = 9,
        InvDestColor = 10,
        SrcAlphaSat = 11,
        BlendFactor = 12,
        InvBlendFactor = 13,
        Src1Color = 14,
        InvSrc1Color = 15,
        Src1Alpha = 16,
        InvSrc1Alpha = 17,
        Num = 18,
    };
}
namespace via::attribute::RemoteProperty {
    enum SyncMode {
        Copy = 0,
        Kill = 1,
        Transaction = 2,
    };
}
namespace via::render {
    enum DsvFlag {
        Dsv_ReadOnlyDepth = 1,
        Dsv_ReadOnlyStencil = 2,
        Dsv_StencilLeft = 4,
        Dsv_StencilRight = 8,
    };
}
namespace via::landscape::beta::QuadTreesLodManager::NodeMeta {
    enum PriorityOption {
        None = 0,
        VirtualRoot = 1,
        Persistent = 2,
        ReadBack = 3,
    };
}
namespace via::motion::IkMultipleDamageAction {
    enum CalculationBendRotation {
        Parent = 0,
        Root = 1,
    };
}
namespace app::OptionMenu {
    enum AimAssistIndex {
        On = 0,
        Off = 1,
    };
}
namespace app::Em8000::Damage {
    enum Tag {
        NoDamage = 0,
        Small_Head_F = 1,
        Small_Head_B = 2,
        Small_Head_L = 3,
        Small_Head_R = 4,
        Small_Chest_FL = 5,
        Small_Chest_FR = 6,
        Small_Chest_BL = 7,
        Small_Chest_BR = 8,
        Small_Chest_L = 9,
        Small_Chest_R = 10,
        Small_Stomach_F = 11,
        Small_Stomach_B = 12,
        Small_Stomach_L = 13,
        Small_Stomach_R = 14,
        Small_LeftArm_F = 15,
        Small_LeftArm_B = 16,
        Small_LeftArm_L = 17,
        Small_LeftArm_R = 18,
        Small_RightArm_F = 19,
        Small_RightArm_B = 20,
        Small_RightArm_L = 21,
        Small_RightArm_R = 22,
        Small_LeftLeg_F = 23,
        Small_LeftLeg_B = 24,
        Small_LeftLeg_L = 25,
        Small_LeftLeg_R = 26,
        Small_RightLeg_F = 27,
        Small_RightLeg_B = 28,
        Small_RightLeg_L = 29,
        Small_RightLeg_R = 30,
        Small_KneeBreak_F = 31,
        Small_KneeBreak_B = 32,
        Small_KneeBreak_L = 33,
        Small_KneeBreak_R = 34,
        Mid_Head_F = 35,
        Mid_Head_FL = 36,
        Mid_Head_FR = 37,
        Mid_Head_B = 38,
        Mid_Head_L = 39,
        Mid_Head_R = 40,
        Mid_Body_F = 41,
        Mid_Body_B = 42,
        Mid_Body_L = 43,
        Mid_Body_R = 44,
        Mid_Leg_L = 45,
        Mid_Leg_R = 46,
        Run_Mid_Head_F = 47,
        Run_Mid_Head_B = 48,
        Run_Mid_Head_L = 49,
        Run_Mid_Head_R = 50,
        Run_Mid_Body_F = 51,
        Run_Mid_Body_B = 52,
        Run_Mid_Body_L = 53,
        Run_Mid_Body_R = 54,
        Run_Mid_Leg_L = 55,
        Run_Mid_Leg_R = 56,
        Down = 57,
        Corpsebag_L = 58,
        Corpsebag_R = 59,
    };
}
namespace app::Em4200::Action::Grapple {
    enum Type {
        Mount = 0,
    };
}
namespace via::render {
    enum InterporateResolve {
        Default = 0,
        Fast = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Generate {
    enum GeneratePosition {
        Head = 0,
        Chest = 1,
        Stomach = 2,
        Thigh = 3,
    };
}
namespace via::gui::BlurManager {
    enum BlurFilterMipMap {
        MipMapMax = 6,
    };
}
namespace via {
    enum ModuleEntry {
        Initialize = 0,
        InitializeLog = 1,
        InitializeGameCore = 2,
        InitializeSteam = 3,
        InitializeWeGame = 4,
        InitializeStorage = 5,
        InitializeResourceManager = 6,
        InitializeScene = 7,
        InitializeRemoteHost = 8,
        InitializeVM = 9,
        InitializeSystemService = 10,
        InitializeHardwareService = 11,
        InitializePushNotificationService = 12,
        InitializeDialog = 13,
        InitializeShareService = 14,
        InitializeUserService = 15,
        InitializeUDS = 16,
        InitializeModalDialogService = 17,
        InitializeGlobalUserData = 18,
        InitializeXCloud = 19,
        InitializeRebe = 20,
        InitializeBcat = 21,
        InitializeEffectMemorySettings = 22,
        InitializeRenderer = 23,
        InitializeVR = 24,
        InitializeSpeedTree = 25,
        InitializeHID = 26,
        InitializeEffect = 27,
        InitializeGeometry = 28,
        InitializeLandscape = 29,
        InitializeHoudini = 30,
        InitializeSound = 31,
        InitializeWwiselib = 32,
        InitializeSimpleWwise = 33,
        InitializeWwise = 34,
        InitializeAudioRender = 35,
        InitializeGUI = 36,
        InitializeSpine = 37,
        InitializeMotion = 38,
        InitializeBehaviorTree = 39,
        InitializeAutoPlay = 40,
        InitializeScenario = 41,
        InitializeOctree = 42,
        InitializeAreaMap = 43,
        InitializeFSM = 44,
        InitializeNavigation = 45,
        InitializePointGraph = 46,
        InitializeFluidFlock = 47,
        InitializeMLSupport = 48,
        InitializeTimeline = 49,
        InitializePhysics = 50,
        InitializeDynamics = 51,
        InitializeHavok = 52,
        InitializeBake = 53,
        InitializeNetwork = 54,
        InitializePuppet = 55,
        InitializeVoiceChat = 56,
        InitializeVivoxlib = 57,
        InitializeStore = 58,
        InitializeBrowser = 59,
        InitializeDevelopSystem = 60,
        InitializeBehavior = 61,
        InitializeMovie = 62,
        InitializeMame = 63,
        InitializeSkuService = 64,
        InitializeTelemetry = 65,
        InitializeHansoft = 66,
        InitializeNNFC = 67,
        InitializeMixer = 68,
        InitializeThreadPool = 69,
        InitializeRds = 70,
        InitializeObsoleteSecurity = 71,
        Setup = 72,
        SetupJobScheduler = 73,
        SetupResourceManager = 74,
        SetupStorage = 75,
        SetupGlobalUserData = 76,
        SetupScene = 77,
        SetupDevelopSystem = 78,
        SetupUserService = 79,
        SetupSystemService = 80,
        SetupHardwareService = 81,
        SetupPushNotificationService = 82,
        SetupShareService = 83,
        SetupModalDialogService = 84,
        SetupVM = 85,
        SetupHID = 86,
        SetupRenderer = 87,
        SetupEffect = 88,
        SetupGeometry = 89,
        SetupLandscape = 90,
        SetupHoudini = 91,
        SetupSound = 92,
        SetupWwiselib = 93,
        SetupSimpleWwise = 94,
        SetupWwise = 95,
        SetupAudioRender = 96,
        SetupMotion = 97,
        SetupNavigation = 98,
        SetupPointGraph = 99,
        SetupPhysics = 100,
        SetupDynamics = 101,
        SetupHavok = 102,
        SetupMovie = 103,
        SetupMame = 104,
        SetupRebe = 105,
        SetupNetwork = 106,
        SetupPuppet = 107,
        SetupStore = 108,
        SetupBrowser = 109,
        SetupVoiceChat = 110,
        SetupVivoxlib = 111,
        SetupSkuService = 112,
        SetupTelemetry = 113,
        SetupHansoft = 114,
        StartApp = 115,
        SetupOctree = 116,
        SetupAreaMap = 117,
        SetupBehaviorTree = 118,
        SetupFSM = 119,
        SetupGUI = 120,
        SetupSpine = 121,
        SetupSpeedTree = 122,
        SetupNNFC = 123,
        Start = 124,
        StartStorage = 125,
        StartResourceManager = 126,
        StartGlobalUserData = 127,
        StartPhysics = 128,
        StartDynamics = 129,
        StartGUI = 130,
        StartTimeline = 131,
        StartOctree = 132,
        StartAreaMap = 133,
        StartBehaviorTree = 134,
        StartFSM = 135,
        StartSound = 136,
        StartWwise = 137,
        StartAudioRender = 138,
        StartScene = 139,
        StartRebe = 140,
        StartNetwork = 141,
        Update = 142,
        UpdateDialog = 143,
        UpdateRemoteHost = 144,
        UpdateStorage = 145,
        UpdateScene = 146,
        UpdateDevelopSystem = 147,
        UpdateWidget = 148,
        UpdateAutoPlay = 149,
        UpdateScenario = 150,
        UpdateCapture = 151,
        BeginFrameRendering = 152,
        UpdateVR = 153,
        UpdateHID = 154,
        UpdateMotionFrame = 155,
        BeginDynamics = 156,
        PreupdateGUI = 157,
        BeginHavok = 158,
        UpdateAIMap = 159,
        CreatePreupdateGroupFSM = 160,
        CreatePreupdateGroupBehaviorTree = 161,
        UpdateGlobalUserData = 162,
        UpdateUDS = 163,
        UpdateUserService = 164,
        UpdateSystemService = 165,
        UpdateHardwareService = 166,
        UpdatePushNotificationService = 167,
        UpdateShareService = 168,
        UpdateSteam = 169,
        UpdateWeGame = 170,
        UpdateBcat = 171,
        UpdateXCloud = 172,
        UpdateRebe = 173,
        UpdateNNFC = 174,
        BeginPhysics = 175,
        BeginUpdatePrimitive = 176,
        BeginUpdatePrimitiveGUI = 177,
        BeginUpdateSpineDraw = 178,
        BeginPuppet = 179,
        UpdateGUI = 180,
        PreupdateBehavior = 181,
        PreupdateBehaviorTree = 182,
        PreupdateFSM = 183,
        PreupdateNetwork = 184,
        PreupdateTimeline = 185,
        PreupdateEffect = 186,
        UpdateBehavior = 187,
        UpdateMLSupport = 188,
        CreateUpdateGroupBehaviorTree = 189,
        CreateNavigationChain = 190,
        CreateUpdateGroupFSM = 191,
        UpdateTimeline = 192,
        PreUpdateAreaMap = 193,
        UpdateOctree = 194,
        UpdateAreaMap = 195,
        UpdateBehaviorTree = 196,
        UpdateTimelineFsm2 = 197,
        UpdateNavigationPrev = 198,
        UpdateFSM = 199,
        UpdateMotion = 200,
        UpdateSpine = 201,
        EffectCollisionLimit = 202,
        UpdatePhysicsAfterUpdatePhase = 203,
        UpdateGeometry = 204,
        UpdateLandscape = 205,
        UpdateHoudini = 206,
        UpdatePhysicsCharacterController = 207,
        BeginUpdateHavok2 = 208,
        UpdateDynamics = 209,
        UpdateNavigation = 210,
        UpdatePointGraph = 211,
        UpdateFluidFlock = 212,
        UpdateConstraintsBegin = 213,
        LateUpdateBehavior = 214,
        EditUpdateBehavior = 215,
        LateUpdateSpine = 216,
        BeginUpdateHavok = 217,
        BeginUpdateEffect = 218,
        UpdateConstraintsEnd = 219,
        UpdatePhysicsAfterLateUpdatePhase = 220,
        PrerenderGUI = 221,
        PrepareRendering = 222,
        UpdateSound = 223,
        UpdateWwiselib = 224,
        UpdateSimpleWwise = 225,
        UpdateWwise = 226,
        UpdateAudioRender = 227,
        CreateSelectorGroupFSM = 228,
        UpdateNetwork = 229,
        UpdateHavok = 230,
        EndUpdateHavok = 231,
        UpdateFSMSelector = 232,
        UpdateBehaviorTreeSelector = 233,
        BeforeLockSceneRendering = 234,
        EndUpdateHavok2 = 235,
        UpdateJointExpression = 236,
        UpdateBehaviorTreeSelectorLegacy = 237,
        UpdateEffect = 238,
        EndUpdateEffect = 239,
        UpdateWidgetDynamics = 240,
        LockScene = 241,
        WaitRendering = 242,
        EndDynamics = 243,
        EndPhysics = 244,
        BeginRendering = 245,
        UpdatePuppet = 246,
        UpdateSpeedTree = 247,
        RenderDynamics = 248,
        RenderGUI = 249,
        RenderGeometry = 250,
        RenderLandscape = 251,
        RenderHoudini = 252,
        RenderMLSupport = 253,
        UpdatePrimitiveGUI = 254,
        UpdatePrimitive = 255,
        UpdateSpineDraw = 256,
        EndUpdatePrimitive = 257,
        EndUpdatePrimitiveGUI = 258,
        EndUpdateSpineDraw = 259,
        GUIPostPrimitiveRender = 260,
        ShapeRenderer = 261,
        UpdateMovie = 262,
        UpdateMame = 263,
        UpdateTelemetry = 264,
        UpdateHansoft = 265,
        DrawWidget = 266,
        DevelopRenderer = 267,
        EndRendering = 268,
        UpdateStore = 269,
        UpdateBrowser = 270,
        UpdateVoiceChat = 271,
        UpdateVivoxlib = 272,
        UnlockScene = 273,
        UpdateVM = 274,
        StepVisualDebugger = 275,
        UpdateRds = 276,
        UpdateObsoleteSecurity = 277,
        WaitForVblank = 278,
        Terminate = 279,
        TerminateScene = 280,
        TerminateRemoteHost = 281,
        TerminateHansoft = 282,
        TerminateTelemetry = 283,
        TerminateMame = 284,
        TerminateMovie = 285,
        TerminateAudioRender = 286,
        TerminateWwise = 287,
        TerminateSimpleWwise = 288,
        TerminateWwiselib = 289,
        TerminateSound = 290,
        TerminateVoiceChat = 291,
        TerminateVivoxlib = 292,
        TerminatePuppet = 293,
        TerminateNetwork = 294,
        TerminateStore = 295,
        TerminateBrowser = 296,
        TerminateSpine = 297,
        TerminateGUI = 298,
        TerminateAreaMap = 299,
        TerminateOctree = 300,
        TerminateFluidFlock = 301,
        TerminateMLSupport = 302,
        TerminateBehaviorTree = 303,
        TerminateFSM = 304,
        TerminateNavigation = 305,
        TerminatePointGraph = 306,
        TerminateEffect = 307,
        TerminateGeometry = 308,
        TerminateLandscape = 309,
        TerminateHoudini = 310,
        TerminateRenderer = 311,
        TerminateHID = 312,
        TerminateDynamics = 313,
        TerminatePhysics = 314,
        TerminateResourceManager = 315,
        TerminateHavok = 316,
        TerminateModalDialogService = 317,
        TerminateShareService = 318,
        TerminateGlobalUserData = 319,
        TerminateStorage = 320,
        TerminateVM = 321,
        TerminateJobScheduler = 322,
        Finalize = 323,
        FinalizeRds = 324,
        FinalizeObsoleteSecurity = 325,
        FinalizeThreadPool = 326,
        FinalizeHansoft = 327,
        FinalizeTelemetry = 328,
        FinalizeMame = 329,
        FinalizeMovie = 330,
        FinalizeBehavior = 331,
        FinalizeDevelopSystem = 332,
        FinalizeTimeline = 333,
        FinalizePuppet = 334,
        FinalizeNetwork = 335,
        FinalizeStore = 336,
        FinalizeBrowser = 337,
        finalizeAutoPlay = 338,
        finalizeScenario = 339,
        FinalizeBehaviorTree = 340,
        FinalizeFSM = 341,
        FinalizeNavigation = 342,
        FinalizePointGraph = 343,
        FinalizeAreaMap = 344,
        FinalizeOctree = 345,
        FinalizeFluidFlock = 346,
        FinalizeMLSupport = 347,
        FinalizeMotion = 348,
        FinalizeDynamics = 349,
        FinalizePhysics = 350,
        FinalizeHavok = 351,
        FinalizeBake = 352,
        FinalizeSpine = 353,
        FinalizeGUI = 354,
        FinalizeSound = 355,
        FinalizeWwiselib = 356,
        FinalizeSimpleWwise = 357,
        FinalizeWwise = 358,
        FinalizeAudioRender = 359,
        FinalizeEffect = 360,
        FinalizeGeometry = 361,
        FinalizeSpeedTree = 362,
        FinalizeLandscape = 363,
        FinalizeHoudini = 364,
        FinalizeRenderer = 365,
        FinalizeHID = 366,
        FinalizeVR = 367,
        FinalizeBcat = 368,
        FinalizeRebe = 369,
        FinalizeXCloud = 370,
        FinalizeSteam = 371,
        FinalizeWeGame = 372,
        FinalizeNNFC = 373,
        FinalizeGlobalUserData = 374,
        FinalizeModalDialogService = 375,
        FinalizeSkuService = 376,
        FinalizeUDS = 377,
        FinalizeUserService = 378,
        FinalizeShareService = 379,
        FinalizeSystemService = 380,
        FinalizeHardwareService = 381,
        FinalizePushNotificationService = 382,
        FinalizeScene = 383,
        FinalizeVM = 384,
        FinalizeResourceManager = 385,
        FinalizeRemoteHost = 386,
        FinalizeStorage = 387,
        FinalizeDialog = 388,
        FinalizeMixer = 389,
        FinalizeGameCore = 390,
    };
}
namespace app {
    enum ItemSortCategory {
        Weapon = 0,
        Shell = 1,
        Drug = 2,
        UsableItem = 3,
        EquipItem = 4,
        KeyItem = 5,
        Other = 6,
        SkillItem = 7,
        Food = 8,
        ItemDummy = 9,
        Max = 10,
        Invalid = 11,
    };
}
namespace via::dynamics {
    enum DistanceLinkVisibleType {
        Structural = 0,
        Shear = 1,
        Bending = 2,
        Stretch = 3,
    };
}
namespace via::network::error {
    enum MethodMatchmaking {
        Searching = 0,
        Permition = 1,
    };
}
namespace via::Stream {
    enum Attribute {
        Default = 0,
        Write = 1,
        Expandable = 2,
        HasUserBit = 4,
        TypeBitMask = 255,
        UserDataBitMask = 16711680,
    };
}
namespace app::PosLerp {
    enum State {
        LerpPos = 0,
        LerpRot = 1,
        LerpLocalPos = 2,
        LerpLocalRot = 3,
        Num = 4,
    };
}
namespace via::render {
    enum LightCullingResolution {
        Default = 0,
        Low = 1,
    };
}
namespace via::render {
    enum WindowMode {
        Normal = 0,
        FullScreen = 1,
        Borderless = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::fsm::CH8ControlMaterial {
    enum ParamType {
        Float4 = 1,
        Float = 2,
    };
}
namespace via::Cylinder {
    enum NGLevel {
        None = 0,
        Point = 1,
        SizeNone = 2,
        NanFinite = 3,
        Assert = 4,
        Default = 3,
    };
}
namespace via::timeline::DialogueTimelinePlayer {
    enum ResourceType {
        None = 0,
        DialogueTimeline = 1,
        DialogueTimelineList = 2,
    };
}
namespace app::fsm::CH8MotionPlay {
    enum AdjustStartFrameTypeEnum {
        None = 0,
        NormalizeTime = 1,
        ReverseNormalizeTime = 2,
    };
}
namespace via {
    enum SystemServiceNgWordsReplacementResult {
        Succeed = 0,
        Failed = 1,
    };
}
namespace via::dynamics::HeightFieldResource {
    enum PointState {
        Removed = 0,
        Max = 1,
    };
}
namespace via::landscape::GroundUtility {
    enum PipelineStateType {
        CopyTexture = 0,
        CopyTextureArray = 1,
        CopyRegionTexture = 2,
        CombineTexture = 3,
        SplitTexture = 4,
        AddBlendTexture = 5,
        SubtractBlendTexture = 6,
        MultiplyBlendTexture = 7,
        FillTexture = 8,
    };
}
namespace app::CH8FadeControl {
    enum FadeStatusEnum {
        OffBlack = 0,
        OnBlack = 1,
    };
}
namespace app::Telemetry {
    enum ProgressTypeDLC {
        Nightmare = 0,
        NightTerror = 1,
        Bedroom = 2,
        TwentyOne = 3,
        TwentyOneSurvival = 4,
        TwentyOneSurvivalPlus = 5,
        CrazyHouse = 6,
        DaughtersBadEnd = 7,
        DaughtersTrueNend = 8,
    };
}
namespace app::CH8Em4000::Action::CH8Move {
    enum CrawlMode {
        Wait = 0,
        Walk = 1,
    };
}
namespace app::MenuHolder {
    enum ReloadStep {
        None = 0,
        Destroy = 1,
        Standby = 2,
        Ready = 3,
    };
}
namespace app::CH9MultiSubMenu {
    enum CH9TabTypeDef {
        Album = 0,
        Map = 1,
    };
}
namespace app::EndingAnnounceGUI {
    enum State {
        DEFAULT = 0,
        FADE_IN = 1,
        FADE_OUT = 2,
    };
}
namespace via::motion::Chassis {
    enum State {
        Initialized = 0,
        Max = 1,
    };
}
namespace via::hid::virtualKeyboard::nsw {
    enum TextCheckResult {
        Success = 0,
        ShowFailureDialog = 1,
        ShowConfirmDialog = 2,
    };
}
namespace via::motion::detail {
    enum ChainNodeCollisionShape {
        None = 0,
        Sphere = 1,
        Capsule = 2,
        StretchCapsule = 3,
    };
}
namespace via::render::layer::Overlay {
    enum UITargetType {
        Default = 0,
        Effect2DPlane0 = 1,
        Effect2DPlane1 = 2,
        Effect2DPlane2 = 3,
        Effect2DPlane3 = 4,
        Max = 5,
    };
}
namespace app::MissionDetail {
    enum CompareType {
        Less = 0,
        LessEqual = 1,
        Equal = 2,
        GreaterEqual = 3,
        Greater = 4,
    };
}
namespace app {
    enum PlayerID {
        Pl0000 = 0,
        Pl1000 = 1,
        Pl2000 = 2,
        Pl3000 = 3,
        Pl4000 = 4,
        Pl5000 = 5,
        Pl6000 = 6,
        Pl7000 = 7,
        Pl3100 = 8,
        Pl3400 = 9,
        Pl9999 = 10,
        Pl9000 = 11,
        Pl9100 = 12,
        Pl9200 = 13,
    };
}
namespace app::cutin::CutinHandle1Button {
    enum ResultDef {
        Button = 0,
        Undecided = 1,
    };
}
namespace via::network::error {
    enum MethodNative {
        Method0 = 0,
        Method1 = 1,
        Method2 = 2,
    };
}
namespace via::reflection::detail {
    enum Stage {
        BSS = 0,
        Heap = 1,
    };
}
namespace via::render::layer {
    enum GBufferLayout {
        PreLighting = 0,
        BaseColorMetallicTranslucency = 1,
        NormalXNormalYRoughnessMisc = 2,
        OcclusionSSSSSVelocityXVelocityYMisc = 3,
        Max = 4,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum Raytracing {
        AmbientOcclusion = 0,
        HybridPathTracing = 1,
        PurePathTracing = 2,
        PathSpaceFilter = 3,
        ScreenSpacePhotonMapping = 4,
        Debug = 5,
        ASVGF = 6,
    };
}
namespace via::render {
    enum CopyType {
        copyResource = 0,
        copySubresourceRegion = 1,
    };
}
namespace via::render {
    enum Comparison {
        Never = 1,
        Less = 2,
        Equal = 3,
        LessEqual = 4,
        Greater = 5,
        NotEqual = 6,
        GreaterEqual = 7,
        Always = 8,
        Num = 9,
    };
}
namespace app::SaveDataManager {
    enum SaveErrorStateEnum {
        None = 0,
        SaveErrorInit = 1,
        SaveCutinWait = 2,
        SaveCutinWait2 = 3,
        SaveRetryWait = 4,
        SaveRetrySuccess = 5,
        SaveExit = 6,
        LoadErrorInit = 7,
        LoadCutinWait = 8,
        LoadCutinWait2 = 9,
        LoadRetryWait = 10,
        LoadRetrySuccess = 11,
        LoadExit = 12,
    };
}
namespace via::hid::VrTracker {
    enum PreferenceType {
        FarPosition = 0,
        StablePosition = 1,
    };
}
namespace app::CH9Em5700ActionController {
    enum MaterialName {
        Risotto_Rate = 0,
        Record_RandumFlag = 1,
        Burn_Rate = 2,
        Max = 3,
    };
}
namespace via::gui::renderer::detail {
    enum PrimitiveGUIFilter {
        None = 0,
        InstantBlur = 1,
        GaussianBlur = 2,
    };
}
namespace app::CH9GauntletChargeGauge {
    enum eHandType {
        Left = 0,
        Right = 1,
        Max = 2,
    };
}
namespace app::Em3000::Goal::Search {
    enum Type {
        Non = 0,
        Vision = 1,
        Hearing = 2,
        Damage = 3,
    };
}
namespace app::fsm::Em3102::Em3102Target {
    enum Event {
        None = 0,
        ActionEnd = 1,
        ActionFailed = 2,
    };
}
namespace app::Em8001::Em8001BattleDirective::ScissorsBattleParameter {
    enum ChainsawEngineDamageTrigger {
        None = 0,
        Grapple_BattleOfSaw = 1,
        RepelPlayerChainsawAttack = 2,
    };
}
namespace app::Em3000::Em3000WwiseMonitoredValue {
    enum PropertyLayer {
        Discovery = 0,
        UnDiscovery = 1,
        DamageDown = 2,
        Max = 3,
    };
}
namespace app::CardGameMaster {
    enum GameBetType {
        Finger = 0,
        Electric = 1,
        Saw = 2,
    };
}
namespace app::Em8001::Em8001ActionController {
    enum MotionSpeedControlGroup {
        Base = 0,
        Attack = 1,
        Rank = 2,
    };
}
namespace via::navigation {
    enum PrimitiveHandleType {
        None = 0,
        IndexedTriangle = 1,
        IndexedPolygon = 2,
        AABB2 = 3,
        OBB = 4,
        LinkPrimArrow = 5,
        PosBasedLinkPrimArrow = 6,
        Sphere = 7,
    };
}
namespace via::areamap::test::DistanceFromNameRegion {
    enum Condition {
        Mode_Closest = 0,
        Mode_Farthest = 1,
    };
}
namespace app::MissionDetail {
    enum ConditionType {
        None = 0,
        DefeatEnemy = 1,
        EnterArea = 2,
        BreakEveryWare = 3,
        TryCount = 4,
        DealDamage = 5,
        CleanupArea = 6,
    };
}
namespace app::Em3001::Action::Damage {
    enum Type {
        NoDamage = 0,
        MidHeadF = 1,
        MidHeadFR = 2,
        MidHeadFL = 3,
        MidHeadB = 4,
        MidHeadR = 5,
        MidHeadL = 6,
        MidBodyF = 7,
        MidBodyB = 8,
        MidBodyR = 9,
        MidBodyL = 10,
        MidLegR = 11,
        MidLegL = 12,
        MidHeadFRun = 13,
        MidHeadBRun = 14,
        MidHeadRRun = 15,
        MidHeadLRun = 16,
        MidBodyFRun = 17,
        MidBodyBRun = 18,
        MidBodyRRun = 19,
        MidBodyLRun = 20,
        MidLegRRun = 21,
        MidLegLRun = 22,
        CommonKneeDownFromF = 23,
        CommonKneeDownFromB = 24,
        CommonKneeDownFromL = 25,
        CommonKneeDownFromR = 26,
        AcidStart = 27,
        AcidEnd = 28,
    };
}
namespace app::fsm::CH8StartOperator {
    enum GUIStateTable {
        DEFAULT = 0,
        FADEIN = 1,
    };
}
namespace via {
    enum SystemServiceSkuFlag {
        Unknown = 65535,
        Default = 0,
        Trial = 1,
        Full = 3,
    };
}
namespace via::memory {
    enum CounterType {
        UsedSize = 0,
        Overhead = 1,
        AllocCount = 2,
        FreeCount = 3,
        AllocSize = 4,
        FreeSize = 5,
    };
}
namespace via::navigation::AIMapEffector {
    enum EffectType {
        Attribute = 0,
        Disable = 1,
    };
}
namespace via::motion {
    enum JointMaskIDMode {
        ID = 0,
        BitFlagOr = 1,
        BitFlagAnd = 2,
    };
}
namespace app::VolumeDecalContainer {
    enum Type {
        Blood = 0,
        Scar = 1,
        Water = 2,
    };
}
namespace app::OptionMenu {
    enum SpeakerType {
        Surround = 0,
        TV = 1,
        Headphone = 2,
    };
}
namespace via::Rect3D {
    enum VoronoiId {
        L_Bit = 1,
        R_Bit = 2,
        T_Bit = 4,
        B_Bit = 8,
        Internal = 0,
        Edge_L_Bit = 1,
        Edge_R_Bit = 2,
        Edge_T_Bit = 4,
        Edge_B_Bit = 8,
        Vertex_LT_Bit = 5,
        Vertex_LB_Bit = 9,
        Vertex_RT_Bit = 6,
        Vertex_RB_Bit = 10,
    };
}
namespace app::CH8Em4200::CH8ThinkStateSet {
    enum Type {
        Default = 0,
        Fixed = 1,
        Wanderer = 2,
        Wait = 3,
        Elevator = 4,
    };
}
namespace app::CH9Em6400::Action::Walk {
    enum Type {
        Normal = 0,
        TNormal = 1,
    };
}
namespace via::render::VolumetricFogControl {
    enum JitterNoiseType {
        Default = 0,
        Fast = 1,
    };
}
namespace app::FileDataManager {
    enum Player {
        None = 0,
        Ethan = 1,
        Mia_Chapter4 = 2,
        Mia_Chapter4FF = 3,
    };
}
namespace via::hid::virtualKeyboard {
    enum KeyboardMode {
        Full = 0,
        Numeric = 1,
        Latin = 2,
        ASCII = 3,
        FullExcludingAsia = 4,
    };
}
namespace app::Em8000FirstStamp {
    enum TimelineIndex {
        Default = 0,
        Clean = 1,
        Dirty = 2,
    };
}
namespace via {
    enum SystemServiceVideoRecorderStatus {
        Unknown = 0,
        Idle = 1,
        Recording = 2,
    };
}
namespace via::areamap::RegionConnection {
    enum AccessState {
        Access_Open = 0,
        Access_Locked = 1,
        Access_Closed = 2,
    };
}
namespace app::Em8001::Action::Walk {
    enum Type {
        Normal = 0,
        LoopStart = 1,
        Acid = 2,
    };
}
namespace app::CH9Em7700DebugController {
    enum HandStatus {
        Normal = 0,
        Blade = 1,
        Lost = 2,
    };
}
namespace app::CH9Em6800 {
    enum eBaseMotionID {
        CarryStand = 0,
        CarryWalk = 1,
        CarryDead = 2,
        CarryWalkEnd = 104,
        CarryMove = 500,
        CarryTurnL = 501,
        CarryTurnR = 502,
        BedSleep = 1000,
        SofaSleep = 1100,
        ChurchSleep = 1200,
        ChairSleep = 1300,
        GroundSleep = 1301,
    };
}
namespace app::CH9Em6400::Action::Rest {
    enum Type {
        Rest00 = 0,
        Rest01 = 1,
        Rest02 = 2,
        Rest03 = 3,
        Rest04 = 4,
        Rest05 = 5,
        Rest06 = 6,
    };
}
namespace app::EffectCommonDefine {
    enum EffectActionOnProviderDestroy {
        None = 0,
        Finish = 1,
        Kill = 2,
    };
}
namespace app::Em3100::Action::OverLook {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace via::render {
    enum UavDimension {
        Unknown = 0,
        Buffer = 1,
        Texture1d = 2,
        Texture1darray = 3,
        Texture2d = 4,
        Texture2darray = 5,
        Texture3d = 8,
    };
}
namespace app::Em4100ActionController {
    enum MoveType {
        Default = 0,
        ForceSolo = 1,
        ForceAround = 2,
    };
}
namespace app::CH8StateSwitchMission {
    enum CHP8_MISSION {
        SILENCE = 0,
        CHP8_SILENCE_MINE = 1,
        CHP8_MINING_AREA = 2,
        CHP8_STORAGE_AREA = 3,
        CHP8_TRAIN_AREA = 4,
    };
}
namespace via::landscape::layer::OutputLayer {
    enum OutputPipelineStateType {
        CombineHeightmap = 0,
        CombineUneditableMask = 1,
        CombineSpline = 2,
        Max = 3,
    };
}
namespace via {
    enum BasisPlane {
        XZ = 0,
        XY = 1,
        YZ = 2,
    };
}
namespace app::Em5400::Action {
    enum ActionNo {
        Idle = 0,
        GroundIdleReaction = 1,
        Attack = 2,
        Turn = 3,
        GroundMove = 4,
        FlyMove = 5,
        FlyToGround = 6,
        GroundToFly = 7,
        MenaceHovering = 8,
        MenaceGround = 9,
        Damage = 10,
        Dead = 11,
        Appear = 12,
        Generate = 13,
        Grapple = 14,
        GrappleToAttack = 15,
    };
}
namespace app::CH9Em6400::ThinkStateSet {
    enum Type {
        None = 0,
        Chapter92Battle = 200,
        Chapter92BattleSecond = 250,
        Chapter92BattleFinal = 300,
        Chapter92BattleFinalSecond = 350,
        Chapter94BattleFinal = 600,
        Chapter94BattleFinalSecond = 650,
        Chapter94BattleFinalThird = 700,
        Chapter92BattleFinalDead = 20100,
        Chapter94BattleFinalDead = 20200,
    };
}
namespace via {
    enum VideoRecordingStatus {
        Disable = -1,
        NotSupported = -2,
        None = 0,
        Running = 1,
        Paused = 2,
        Ready = 3,
    };
}
namespace via::vr {
    enum VrDeviceName {
        None = 0,
        PSVR_HMD = 1,
        PSVR_DEALSHOCK4 = 2,
        PSVR_MOVE = 3,
        PSVR_GUN = 4,
        OpenVR_ViveHMD = 5,
        OpenVR_ViveContoller = 6,
        OpenVR_ViveTracker = 7,
        OpenVR_OculusTouch = 8,
        OpenVR_OculusHMD = 9,
        OculusVR_OculusHMD = 10,
        OculusVR_OculusTouch = 11,
        OculusVR_OculusRemote = 12,
        VRDEVICE_NUM_MAX = 13,
    };
}
namespace via::wwise::WwiseGeneratedBankInfo {
    enum IdType {
        None = 0,
        Bank = 1,
        Event = 2,
        SwitchGroup = 3,
        Switch = 4,
        Rtpc = 5,
        Trigger = 6,
        StateGroup = 7,
        State = 8,
        AudioBus = 9,
        AuxiliaryBus = 10,
        InMemoryAudio = 11,
        StreamedAudio = 12,
    };
}
namespace app::CardGameAchievementControl {
    enum AchieveType {
        TotalWin = 0,
        TotalUseItem = 1,
        TotalTwentyOne = 2,
        TotalRemove = 3,
        TotalWinSpecialGuest = 4,
        PerfectClearSurvival1 = 5,
        PerfectClearSurvival2 = 6,
        ClearSurvival1 = 7,
        ClearSurvival2 = 8,
        BurstWin = 9,
        WinTwentyFour = 10,
        OneRoundUseItem = 11,
        ContinuousTwentyOne = 12,
        ContinuousPerfectWin = 13,
    };
}
namespace app::fsm::SetGenomeCodexRadarEnable {
    enum StateDef {
        Disable = 0,
        Enable = 1,
    };
}
namespace via::os {
    enum MemoryProtection {
        CPU_RO = 4,
        CPU_RW = 8,
        GPU_RO = 16,
        GPU_WO = 32,
        GPU_RW = 48,
        Default = 56,
    };
}
namespace app::CH9ThrowingWp1500 {
    enum UpdateRno {
        Wait = 0,
        Move = 1,
        HitWall = 2,
        HitEnemy = 3,
        BrokenWait = 4,
        Sleep = 5,
    };
}
namespace app::SecondaryMotionReceiver {
    enum MotionChangeCheckState {
        NoCheck = 0,
        Start = 1,
        Checking = 2,
    };
}
namespace via::motion::JointExLimit {
    enum LimitFlags {
        None = 0,
        TransMinX = 1,
        TransMaxX = 2,
        TransMinY = 4,
        TransMaxY = 8,
        TransMinZ = 16,
        TransMaxZ = 32,
        RotMinX = 64,
        RotMinY = 128,
        RotMinZ = 256,
        RotMaxX = 512,
        RotMaxY = 1024,
        RotMaxZ = 2048,
        ScaleMinX = 4096,
        ScaleMinY = 8192,
        ScaleMinZ = 16384,
        ScaleMaxX = 32768,
        ScaleMaxY = 65536,
        ScaleMaxZ = 131072,
    };
}
namespace app::Em5552::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        Attack = 2,
        Dead = 3,
        AttackAction = 4,
        DeadAction = 5,
    };
}
namespace via::math {
    enum RotationOrder {
        XYZ = 0,
        YZX = 1,
        ZXY = 2,
        ZYX = 3,
        YXZ = 4,
        XZY = 5,
    };
}
namespace via::effect {
    enum PlayerState {
        Idle = 0,
        Start = 1,
        Running = 2,
        ForceStop = 3,
        Finish = 4,
        Finished = 5,
        Restart = 6,
    };
}
namespace via::motion::detail::ChainLinkData {
    enum AttrFlags {
        EnableStretch = 1,
    };
}
namespace via::DateTime {
    enum Kind {
        Unspecified = 0,
        UTC = 1,
        Local = 2,
    };
}
namespace via::network::AutoMatchmaking {
    enum RuleType {
        Must = 0,
        Should = 1,
    };
}
namespace via {
    enum Hide {
        Script = 1,
        Tool = 2,
        Public = 4,
    };
}
namespace via::render::layer::PrepareOutput {
    enum DISPLAYCOLORSPACE {
        SRGB = 0,
        HDTV_REC709 = 1,
        BT2020 = 2,
    };
}
namespace System::Threading {
    enum ThreadState {
        Running = 0,
        StopRequested = 1,
        SuspendRequested = 2,
        Background = 4,
        Unstarted = 8,
        Stopped = 16,
        WaitSleepJoin = 32,
        Suspended = 64,
        AbortRequested = 128,
        Aborted = 256,
    };
}
namespace app::CH9Em6400::ThinkOrderSet {
    enum Type {
        None = 0,
        LeaveEnd = 1,
        GrappleFromPlayer = 2,
        Chapter92Battle_Leave = 250,
    };
}
namespace via::motion {
    enum SequenceUpdateMode {
        Always = 0,
        PlayOnly = 1,
        DisableReverseEvent = 2,
        Disable = 3,
    };
}
namespace via::render::layer::CaptureGBuffer {
    enum FACEINDEX {
        POSITIVE_X = 0,
        NEGATIVE_X = 1,
        POSITIVE_Y = 2,
        NEGATIVE_Y = 3,
        POSITIVE_Z = 4,
        NEGATIVE_Z = 5,
    };
}
namespace via::navigation::FailReport {
    enum FailLevel {
        Upper = 0,
        Lower = 1,
    };
}
namespace via::landscape::layer::LandformBaseLayer {
    enum Priority {
        TopMost = 16777216,
        Top = 50331648,
        Default = 83886080,
        Bottom = 117440512,
        BottomMost = 150994944,
    };
}
namespace app::CH9Em6700::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        OutRange = 1,
        InRange = 2,
        HasAttackRight = 3,
    };
}
namespace app::CH9Em7500ActionController {
    enum SuspendStatus {
        None = 0,
        Requested = 1,
        Suspending = 2,
        Completed = 3,
    };
}
namespace app::Em8000::Em8000MaterialController {
    enum TargetTag {
        None = 0,
        Own = 1,
        Head = 2,
        Core = 3,
    };
}
namespace via::effect::gpgpu::detail {
    enum GpuBufferType {
        PhysicalProps = 0,
        TextureProps = 1,
        ExtForceProps = 2,
        CollisionProps = 3,
        AnimationProps = 4,
        PropsNum = 5,
        PhysicalPropsMask = 1,
        TexturePropsMask = 2,
        ExtForcePropsMask = 4,
        CollisionPropsMask = 8,
        AnimationPropsMask = 16,
    };
}
namespace via::gui::OutlineFont {
    enum ShapeType {
        Arabic = 0,
        Thai = 1,
        Hindi = 2,
    };
}
namespace app::CH9Em7700BladeController {
    enum Type {
        Default = 0,
        Slash = 1,
        SlashTry = 2,
        Grapple = 3,
        Pursuit = 4,
        None = -1,
    };
}
namespace via::areamap::test::BasicDistance {
    enum Condition {
        Mode_Closest = 0,
        Mode_Farthest = 1,
    };
}
namespace app::ChapterLoadTempManager {
    enum CollectTypeEnum {
        Env = 0,
        Advanced = 1,
        Other = 2,
        Level = 3,
        MAX = 4,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum VFXSpecularDenoiserFlag {
        Full = 1,
        Spatial = 2,
        Temporal = 4,
        Median = 8,
    };
}
namespace app::InteractPushMove {
    enum PushMoveTypeEnum {
        Front = 0,
        Left = 1,
        Right = 2,
    };
}
namespace via::gui {
    enum LightGroupBit {
        Group0 = 1,
        Group1 = 2,
        Group2 = 4,
        Group3 = 8,
        Group4 = 16,
        Group5 = 32,
        Group6 = 64,
        Group7 = 128,
        All = 255,
    };
}
namespace via::navigation::map::NodeBlock {
    enum Attribute {
        Static = 0,
        ModifyBase = 1,
    };
}
namespace via::motion::SubExJointRemapInput {
    enum JointLimitFlags {
        BasePose = 1,
        MidPoint = 2,
        Enable = 4,
    };
}
namespace via::motion::ChainResource {
    enum SettingAttrFlags {
        None = 0,
        Default = 1,
        VirtualGroundRoot = 2,
        VirtualGroundTarget = 4,
        IgnoreSameGroupCollision = 8,
        VirtualGroundMask = 6,
    };
}
namespace app::vr::VrErrorFlow {
    enum Phase {
        FadeOut = 0,
        Request = 1,
        Success = 2,
        SuccessCutin = 3,
        Failed = 4,
        Retry = 5,
        FadeIn = 6,
        CancelCutin = 7,
        RequestStop = 8,
        ReturnTitle = 9,
        VrTutorialCutin = 10,
        End = 11,
    };
}
namespace app::Em3000::Action::Zigzag {
    enum Type {
        Normal = 0,
        TNormal = 1,
    };
}
namespace app::CH9Em6400ActionController {
    enum DamageReactionType {
        None = 0,
        Middle = 1,
        Large = 2,
        Down = 3,
        Blow = 4,
        KnockDown = 5,
    };
}
namespace via::landscape {
    enum BakerSegment {
        BakeMesh = 0,
        BakePath = 1,
        BakeRoad = 2,
        BakeGround = 3,
        BakeFoliageMap = 4,
        BakeIntersect = 5,
        BakePointCloud = 6,
        BakeSDF = 7,
    };
}
namespace via::physics::System {
    enum PaintType {
        Overwrite = 0,
        Add = 1,
        Reset = 2,
    };
}
namespace app::Em3002::Action::Turn {
    enum Type {
        Fast = 0,
        Move = 1,
    };
}
namespace via::dialog {
    enum Status {
        None = 0,
        Initialized = 1,
        Running = 2,
        Finished = 3,
    };
}
namespace via::effect {
    enum VectorFieldDrawFlag {
        None = 0,
        Box = 1,
        Grid = 2,
    };
}
namespace app::CH9SceneFoldersCtrlRequester {
    enum ControlTypeEnum {
        None = 0,
        Standby_True = 1,
        Standby_False = 2,
        Activate = 3,
        deActivate = 4,
        Load = 5,
        UnLoad = 6,
    };
}
namespace app::EnemyActionController {
    enum HiddenType {
        Invalid = 0,
        ForDead = 1,
        ForSuspend = 2,
    };
}
namespace app::CH9Em6400::Action::GuardFollow {
    enum Type {
    };
}
namespace via::render::RenderConfig {
    enum LensDistortionSetting {
        ON = 0,
        DistortionOnly = 1,
        OFF = 2,
    };
}
namespace via::audiorender::fx::distortion {
    enum DistType {
        Distortion = 0,
        TubeDrive = 1,
        OverDrive = 2,
    };
}
namespace CH8Em4200Effect {
    enum CH8IDAlias {
        Explosion = 0,
        Splash = 1,
        VerticalSplash = 2,
        HorizontalSplash = 3,
        LostHead = 4,
        LostLeftArm = 5,
        LostRightArm = 6,
        LostLeftLeg = 7,
        LostRightLeg = 8,
        StandSplashFromSequence = 9,
        WalkSplashFromSequence = 10,
        CrawlSplashFromSequence = 11,
        SimpleSplashFromSequence = 12,
        GrappleSplashFromSequence = 13,
        SelfSplashFromSequence = 14,
    };
}
namespace app::Em8001::Action::DamageDown {
    enum Direction {
        INVALID = -1,
        None = 0,
        Front = 1,
        Back = 2,
        Left = 3,
        Right = 4,
        SUM = 5,
    };
}
namespace app::Em8100::Action::Walk {
    enum Type {
        Normal = 0,
    };
}
namespace app::Em3000::Action::AttackToGrapple {
    enum Type {
        CommonGrab = 0,
        NeckSlash = 1,
        ShovelLift = 2,
        CutLeg = 3,
        Climax = 4,
        TCommonGrab = 5,
        TNeckSlash = 6,
        TShovelLift = 7,
        TCutLeg = 8,
        TClimax = 9,
    };
}
namespace app::ColorCorrectController {
    enum Type {
        Damage = 0,
        Zone = 1,
    };
}
namespace app::PlayerCamera {
    enum CameraTypeEnum {
        MaximumOperatable = 0,
        PivotRotation = 1,
        ElasticRotation = 2,
        ElasticRotationForCounter = 3,
        HalfAnimation = 4,
        HalfAnimationNoResetAngle = 5,
        FullAnimation = 6,
        InterpRotation2FullAnim = 7,
        Return2MaxOperatable = 8,
        QuickTurn = 9,
        Num = 10,
    };
}
namespace CH8Em4000Effect {
    enum IDAlias {
        LostHead = 0,
        LostLeftArm = 1,
        LostRightArm = 2,
        LostLeftLeg = 3,
        LostRightLeg = 4,
        StandSplashFromSequence = 5,
        WalkSplashFromSequence = 6,
        CrawlSplashFromSequence = 7,
        SimpleSplashFromSequence = 8,
        GrappleSplashFromSequence = 9,
        SelfSplashFromSequence = 10,
        ContaminationWhite = 11,
        ContaminationWhiteBuff = 12,
    };
}
namespace app::PCSystemData {
    enum DefaultResolutionMaxType {
        MAX1920P = 0,
        MAX3840P = 1,
    };
}
namespace app::fsm::OpenWaveAnnouncement {
    enum Meridiem {
        AM = 0,
        PM = 1,
    };
}
namespace app::CH8HUDControl::AirGauge {
    enum HealthCondition {
        Normal = 0,
        Warning = 1,
        Danger = 2,
        Die = 3,
    };
}
namespace via::motion::detail {
    enum ChainCollisionShape {
        None = 0,
        Sphere = 1,
        Capsule = 2,
        OBB = 3,
        Plane = 4,
        TaperedCapsule = 5,
        LineSphere = 6,
        LerpSphere = 7,
    };
}
namespace app::CH9ThrowingWeaponBase {
    enum ParentType {
        None = 0,
        Transform = 1,
        Joint = 2,
    };
}
namespace via::dynamics {
    enum SimulationContinuousType {
        Skinning = 0,
        Previous = 1,
    };
}
namespace via::motion::IkLeg {
    enum EffectorOffsetCtrl {
        None = 0,
        Local = 1,
        World = 2,
    };
}
namespace app::fsm::EffectControlAction {
    enum TargetModeEnum {
        TargetOnly = 0,
        TargetAndChildren = 1,
        ChildrenOnly = 2,
    };
}
namespace via::motion::chain {
    enum ChainVGroundType {
        None = 0,
        Root = 1,
        Target = 2,
    };
}
namespace via::os {
    enum ChunkInstalledDevice {
        None = 0,
        Slow = 1,
        Fast = 2,
    };
}
namespace via::userdata::MultiLogicNode {
    enum Operation {
        And = 0,
        Or = 1,
    };
}
namespace app::CH8PlayerDefine {
    enum ExternalShakeType {
        LandShake = 2000,
    };
}
namespace app::AI::NodeLinkInfo {
    enum Validation {
        Invalid = 0,
        Node = 1,
        Link = 2,
        Valid = 3,
    };
}
namespace via::motion::MotionAppendData {
    enum PrimitiveClassType {
        Unkonw = 0,
        Vec2 = 1,
        Vec3 = 2,
        Vec4 = 3,
        Quaternion = 4,
        Matrix = 5,
    };
}
namespace app::CH9Em6400ActionController {
    enum ActionCategory {
        None = 0,
        Common = 1,
        First = 2,
        Counter = 3,
        Guard = 4,
        Grapple = 5,
        TargetBack = 6,
        TargetCrouch = 7,
        TargetCharge = 8,
        AngerMax = 9,
        Anger = 10,
        TargetChargeMax = 11,
        Damage = 12,
        ChargeMaxDamage = 13,
        Back = 14,
        Max = 15,
    };
}
namespace app::Em8001::Action::Acid {
    enum State {
        None = 0,
        Start = 1,
        End = 2,
        INVALID = 3,
    };
}
namespace via::render {
    enum ShadowPrecision {
        Default = 0,
        Low = 1,
    };
}
namespace via::network::MatchmakingRules {
    enum Attribute {
        Ticket = 0,
        Player = 1,
    };
}
namespace via::effect::gpgpu::NodeBillboardCS::NodeBillboardResource {
    enum ComputeShaderType {
        Initialize = 0,
        BoundingBox = 1,
        BoundingSphere = 2,
        BoundingBoxRotate = 3,
        BoundingSphereRotate = 4,
        Lighting = 5,
        LightingVolumetricFog = 6,
        Num = 7,
    };
}
namespace app::CH8InfraredTrap {
    enum LampState {
        On = 0,
        Off = 1,
    };
}
namespace via::render {
    enum AmbientBRDF {
        Legacy = 0,
        New = 1,
    };
}
namespace via::hid::VrTracker {
    enum MotionSensorDataUpdateTiming {
        Nothing = 0,
        Always = 2147483647,
        OnLedTrackerProcessSuccessful = 4,
        OnLedTrackerProcessFailed = 3,
        OnVrTrackerGpuSubmitFailed = 1,
        OnVrTrackerGpuWaitAndCpuProcessFailed = 2,
    };
}
namespace app::CH8ActivateObjectOperation::OperationData {
    enum DataType {
        Operation = 0,
        BoolVariable = 1,
        IntVariable = 2,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraCaptureFrameResult {
        OK = 1,
        ErrorStoped = 2147483649,
        ErrorDeviceDisconnected = 2147483650,
        ErrorInternal = 2147487744,
    };
}
namespace via::render {
    enum PipePriority {
        Lowest = 0,
        Default = 7,
        Highest = 15,
    };
}
namespace app::cutin::CutinProc1Button {
    enum StateType {
        Normal = 0,
        ReNet = 1,
        NetworkWait = 2,
        FileWait = 3,
        VRTutorial = 4,
    };
}
namespace via::motion::IkLookAt2 {
    enum AxisCoord {
        Local = 0,
        Root = 1,
    };
}
namespace via::behaviortree {
    enum ExecGroupCreationType {
        EveryFrame = 0,
        Loaded = 1,
    };
}
namespace app::Em8950 {
    enum ThinkState {
        None = 0,
    };
}
namespace app::CH8SaveDataOverWriter::OverWriteInfo {
    enum ActionState {
        PreSave = 0,
        PostLoad = 1,
    };
}
namespace via::effect::detail {
    enum GroupLevel {
        GroupLevel_0 = 0,
        GroupLevel_1 = 1,
        GroupLevel_Num = 2,
    };
}
namespace app::Em4200::ThinkStateSet {
    enum Type {
        Default = 0,
        Fixed = 1,
        Wanderer = 2,
        Wait = 3,
        Elevator = 4,
    };
}
namespace app::EffectChainMeshAnim {
    enum PlayTypeEnum {
        Once = 0,
        Loop = 1,
        Pause = 2,
    };
}
namespace app::CH8ShellManager {
    enum GrenadeType {
        Grenadebomb = 0,
        Thermatebomb = 1,
        Stangrenadebomb = 2,
    };
}
namespace app::fsm::CH8Wait {
    enum WaitTypeEnum {
        Normal = 0,
        FlagSet = 1,
    };
}
namespace app::FileMenu {
    enum ModeDef {
        FileOnly = 0,
        List = 1,
    };
}
namespace app::CH8HUDControl::AirGauge {
    enum PollutionLevel {
        Clean = 0,
        Caution = 1,
        Max = 2,
    };
}
namespace app::Em4000::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromFrontWithDirective = 8,
        IsTargetLegCut = 9,
        IsTargetRun = 10,
        IsTargetCrouching = 11,
        IsTargetDamage = 12,
        IsSlipFire = 13,
        IsSlipAcid = 14,
        AdditiveSensedAttack = 15,
    };
}
namespace via::gui {
    enum RegionFitType {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        Both = 3,
    };
}
namespace app::CH9MoldedActionController {
    enum WwiseSwitchList {
        HeadON = 0,
        HeadOFF = 1,
        LeftArmNORMAL = 2,
        LeftArmOFF = 3,
        LeftArmSWORD = 4,
        RightArmNORMAL = 5,
        RightArmOFF = 6,
        RightArmSWORD = 7,
    };
}
namespace app::CH8StateSwitchM4 {
    enum CHP8_4 {
        SILENCE = 0,
        CHP8_BGM_TRAIN_01 = 1,
        CHP8_BGM_TRAIN_02 = 2,
        CHP8_BGM_TRAIN_02_END = 3,
    };
}
namespace app::Em3102::Message {
    enum Tag {
        None = 0,
        Walk_A = 17000,
        Walk_B = 17001,
        Walk_C = 17002,
        Walk_E = 17003,
        Walk_F = 17004,
        Walk_G = 17005,
        Crazy_A = 14000,
        Walk_Fast_A = 18000,
        Walk_Fast_B = 18001,
        Walk_Fast_C = 18002,
        Walk_Fast_D = 18003,
        SteadyDown_A = 16000,
        Encount_Vision_A = 15000,
        Encount_Vision_B = 15001,
        Encount_Vision_C = 15002,
        Chase_A = 12000,
        Chase_B = 12001,
        Chase_C = 12002,
        Chase_D = 12003,
        Chase_E = 12004,
        Chase_F = 12005,
        Awareness_A = 10000,
        Awareness_B = 10001,
        Chase_AfterKey_A = 13000,
        Chase_AfterKey_B = 13001,
        Call_Jack_A = 11000,
        Call_Jack_B = 11001,
        Call_Jack_C = 11002,
    };
}
namespace app::CH9Em6400ActionController {
    enum CH92BattleWwiseState {
        ENCOUNT = 0,
        LOST_PL = 1,
    };
}
namespace via::motion::SubExJointRemapInput {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace System::Threading {
    enum ApartmentState {
        STA = 0,
        MTA = 1,
        Unknown = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Generate {
    enum MotionLayer {
        CantUse0 = 0,
        CantUse1 = 1,
        ChatUse2 = 2,
        AddBlendHead = 3,
        AddBlendChest = 4,
        AddBlendStomach = 5,
        AddBlendThigh = 6,
    };
}
namespace app::Em4200::ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
    };
}
namespace app::CH8Em4400ActionPoint {
    enum Type {
        DropPoint = 0,
    };
}
namespace app::Em8100::Action::Turn {
    enum Type {
        Right = 0,
        Left = 1,
        Back = 2,
        RR90 = 3,
        RL90 = 4,
        RL180 = 5,
        LL90 = 6,
        LR90 = 7,
        LR180 = 8,
    };
}
namespace via::motion {
    enum SequencePhase {
        Init = 0,
        First = 1,
        Second = 2,
        Normal = 3,
    };
}
namespace via::Component {
    enum TypeFlag {
        CollectionIndexEnable = 1,
        BehaviorGroupIndexEnable = 2,
        CollectionIndexMask = 1044480,
        BehaviorGroupIndexMask = 4293918720,
    };
}
namespace via::render::LDRRadialBlur {
    enum LookAtType {
        WorldPosition = 0,
        ScreenPosition = 1,
    };
}
namespace via::render::MeshRenderer {
    enum Status {
        None = 0,
        BeginRendering = 1,
    };
}
namespace via::render::PrimitiveMaterial {
    enum SolidShader {
        BillboardMaterial = 0,
        RibbonMaterial = 1,
        PolygonMaterial = 2,
        PolygonStripMaterial = 3,
        Max = 4,
    };
}
namespace app::CardGameTutorial {
    enum TutorialItem {
        BasicRule = 0,
        OneRound = 1,
        SPCard = 2,
        Survival = 3,
        SurvivalPlus = 4,
        Word = 5,
        End = 6,
    };
}
namespace via::network::dev::NetworkDataLoggingInternal {
    enum Metrics {
        Traffic = 0,
        Performance = 1,
        Rpc = 2,
        Profile = 3,
    };
}
namespace app::VrLightEffectiveRangeController {
    enum LightType {
        PointLight = 0,
        SpotLight = 1,
        IESLight = 2,
    };
}
namespace app::AI::UseDoorInfo {
    enum SearchDirectionType {
        Default = 0,
        OwnerAxisZ = 1,
        PotalInfo = 2,
    };
}
namespace via::landscape {
    enum LandformPipelineStateType {
        Draw3D = 0,
        Pick = 1,
        FlatColor = 2,
        Wireframe = 3,
        Shadow = 4,
        CalculateHeight = 5,
        DownSampleSpline = 6,
        DrawOutline = 7,
        GenerateSlopeTexture = 8,
        Max = 9,
    };
}
namespace via::effect::detail {
    enum LuminanceBleedType {
        None = 0,
        Transparent = 1,
        PostTransparent = 2,
    };
}
namespace via::effect {
    enum WindInfluenceDrawFlag {
        None = 0,
        Select = 1,
        All = 2,
    };
}
namespace via::render::ByteBufferUpdateExecutor {
    enum UpdateType {
        Byte = 0,
        ByteArray = 1,
        Integer = 2,
        IntegerArray = 3,
        Float = 4,
        FloatArray = 5,
        Float4 = 6,
        Float4Array = 7,
    };
}
namespace via::simplewwise {
    enum IdType {
        None = 0,
        Bank = 1,
        Event = 2,
        SwitchGroup = 3,
        Switch = 4,
        Rtpc = 5,
        Trigger = 6,
        StateGroup = 7,
        State = 8,
        AudioBus = 9,
        AuxiliaryBus = 10,
        InMemoryAudio = 11,
        StreamedAudio = 12,
        AudioDevice = 13,
    };
}
namespace via::render {
    enum HazeCompositorFilterType {
        Variance = 0,
        AdjacentClamping = 1,
        Gaussian = 2,
    };
}
namespace app::DoorPush {
    enum InitialState {
        Unlock = 0,
        Lock = 1,
        LittleOpenFront = 2,
        LittleOpenBack = 3,
        OpenFront = 4,
        OpenBack = 5,
    };
}
namespace app::CH9RewardData::RewardData {
    enum Type {
        Difficulty = 0,
        Item = 1,
        Everywhere = 2,
        Weapon = 3,
    };
}
namespace via::network::utility::Request {
    enum State {
        Dead = 0,
        Init = 1,
        Start = 2,
        StartFail = 3,
        Update = 4,
        Finish = 5,
    };
}
namespace via::vr {
    enum VrSystemStatus {
        Unknown = 0,
        Invalid = 1,
        UnUsed = 2,
        Standby = 3,
        Ready = 4,
        Running = 5,
    };
}
namespace via::fsm::FsmManager {
    enum SelectorTiming {
        Last = 0,
        BackGround = 1,
    };
}
namespace app::SystemData {
    enum DataType {
        Display_Tutorial = 0,
        Display_Calling = 1,
        Display_Brightness = 2,
        Display_Adjustment_Setting = 3,
    };
}
namespace app::Em3001::Action::AttackToGrapple {
    enum Type {
        CommonGrab = 0,
        TCommonGrab = 1,
    };
}
namespace via::nnfc {
    enum DeviceState {
        Initialize = 0,
        NoDevice = 1,
        Conflict = 2,
        Ready = 3,
        Detect = 4,
        Mount = 5,
        Panic = 6,
    };
}
namespace app::FirstReNetMenu {
    enum ModeDef {
        Normal = 0,
    };
}
namespace via::dynamics::gjk::SimplexSolver {
    enum SimplexType {
        None = 0,
        Point = 1,
        LineSegment = 2,
        Triangle = 3,
        Tetrahedron = 4,
        Max = 5,
    };
}
namespace via {
    enum GamePresetsCamera {
        Default = 0,
        Normal = 1,
        Reverse = 2,
    };
}
namespace app::ShellManager {
    enum BulletType {
        Unknown = 0,
        Handgun_M19 = 1,
        Handgun_M19_L = 2,
        Handgun_G17 = 3,
        Handgun_G17_L = 4,
        Handgun_MPM = 5,
        Handgun_MPM_L = 6,
        Handgun_Albert = 7,
        Handgun_Albert_L = 8,
        Handgun_Albert_Reward = 9,
        Handgun_Albert_Reward_L = 10,
        HyperBlaster = 11,
        HyperBlaster_L = 12,
        BlueBlaster = 13,
        RedBlaster = 14,
        Shotgun_M37 = 15,
        Shotgun_DB = 16,
        MachineGun = 17,
        Magnum = 18,
        Burner = 19,
        Handgun_Albert_C = 20,
        Handgun_Albert_C_L = 21,
        Shotgun_Albert = 22,
        FlameBulletS = 23,
        FlameBulletL = 24,
        AcidBulletS = 25,
        AcidBulletL = 26,
    };
}
namespace app::Em4100::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::fsm::CH8AreaHitTest {
    enum TargetParam {
        Player = 0,
        Enemy = 1,
    };
}
namespace via::motion {
    enum SequenceGetMode {
        TypeA = 0,
        TypeB = 1,
    };
}
namespace app::GameManager {
    enum ChapterNo {
        BootLogo = 0,
        FirstMenu = 1,
        Chapter0 = 2,
        Title = 3,
        Chapter1 = 4,
        Chapter3 = 5,
        Chapter4 = 6,
        FF000 = 7,
        FF010 = 8,
        FF020 = 9,
        FF030 = 10,
        FF040 = 11,
        FF050 = 12,
        Chapter123 = 13,
        Chapter324 = 14,
        OpeningMovie = 15,
        OpeningCar = 16,
        EndingMovie = 17,
        VRTutorial = 18,
        NoChapter = 19,
        BirthdayMain = 20,
        BirthdayTitle = 21,
        BirthdayStage1 = 22,
        BirthdayStage2 = 23,
        BirthdayStage3 = 24,
        BirthdayStage4 = 25,
        BirthdayResult = 26,
        EndCard = 27,
        Chapter7Title = 28,
        Chapter7_1 = 29,
        Chapter7_2 = 30,
        Chapter7_3 = 31,
        Chapter7_4 = 32,
        Chapter3_IMD_Title = 33,
        Chapter3_IMD = 34,
        Chapter8 = 35,
        Chapter7_Intro_Movie = 36,
        Chapter9 = 37,
    };
}
namespace via::wwise {
    enum StoppedEventType {
        None = 0,
        GameObject_EventId_Duration = 1,
        GameObject_RequestId_Duration = 2,
        RequestId_Duration = 3,
        Target_EventId_Duration = 4,
        Max = 5,
    };
}
namespace app::fsm::CH8CheckOpenFileMenu {
    enum Status {
        Open = 0,
        Close = 1,
    };
}
namespace app::CH9GauntletChargeGauge {
    enum eChargeHand {
        OneHnad = 0,
        BothHnads = 1,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemBGChildChildPanelState {
        SIZE1 = 0,
        SIZE2 = 1,
    };
}
namespace app::Em8000::Motion::Em8000MotionID::Type {
    enum UpperOverride {
        None = 0,
        Gesture = 1,
    };
}
namespace via::render {
    enum LuminanceBleedResolution {
        Low = 0,
        Mid = 1,
        High = 2,
    };
}
namespace app::CH9TipsFlagManager {
    enum TipsType {
        DeadByEm7500In9_2Solo = 0,
        DeadByEm7500In9_2Duo = 1,
        DeadByEm7500In9_3 = 2,
        DeadInIslandExceptEm7500 = 3,
        DeadInBakerLoad = 4,
        DeadByEm7700 = 5,
        DeadByEm7700DB = 6,
        DeadByEm7800 = 7,
        DeadByEm7900 = 8,
        DeadByEm6400In9_2A = 9,
        DeadByEm6400In9_2B = 10,
        DeadByEm6400In9_4 = 11,
    };
}
namespace app::UICommand {
    enum DircType {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    };
}
namespace app::Em3001Think {
    enum Mode {
        Idle = 0,
        Battle = 1,
    };
}
namespace app::Em4000::ThinkAppearSet {
    enum MimicryType {
        Floor1 = 0,
        Floor2 = 1,
        Lean1 = 2,
        Lean2 = 3,
        Lean3 = 4,
    };
}
namespace app::fsm::PlayerAction {
    enum PlayerActionType {
        None = 0,
        ForceCrawl = 1,
        LeftArmCut = 2,
        ForceSupine = 3,
    };
}
namespace app::CardGameObjectFingerMachine {
    enum FingerMachineJointMaskID {
        Finger1 = 1,
        Finger2 = 2,
        Finger3 = 3,
        Finger4 = 4,
        Finger5 = 5,
    };
}
namespace app {
    enum WeaponInfoType {
        Nothing = 0,
        Gun = 1,
        Burner = 2,
        GrenadeLauncher = 3,
        CircularSaw = 4,
        ChainSaw = 5,
        LimitBlaster = 6,
    };
}
namespace app::Em3600 {
    enum ThinkState {
        None = 0,
        BattleStart = 1,
        BattleDefault = 2,
        OmakeMode = 3,
    };
}
namespace app::CH8GasBomb {
    enum Rno {
        Running = 0,
        Detonation = 1,
        Interval = 2,
        Exploded = 3,
        End = 4,
    };
}
namespace via::landscape {
    enum LodDebugType {
        None = 0,
        LodLevel = 1,
        NodeUV = 2,
        PatchUV = 3,
        CrackInfo = 4,
        PhysicalPageIndex = 5,
        Max = 6,
    };
}
namespace via::network::session {
    enum SearchKeyGroup {
        None = 0,
        Develop = 1,
        QA = 2,
        Master = 3,
        Pub = 4,
        Event = 5,
        Custom = 6,
    };
}
namespace app::Em8940Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em3001::Goal {
    enum GoalId {
        Discovery = 0,
        UnDiscovery = 1,
        Idle = 2,
        Rest = 3,
        AppearF = 4,
        AppearR = 5,
        AppearL = 6,
        Battle = 7,
        Wander = 8,
    };
}
namespace via::navigation {
    enum AdjustPrio {
        Floor = 0,
        Wall = 1,
    };
}
namespace app::Cp7GameOverChoice {
    enum Step {
        Main = 0,
        Cutin = 1,
    };
}
namespace via::timeline {
    enum NodeType {
        Unknown = 0,
        GameObject = 1,
        Component = 2,
        Folder = 3,
    };
}
namespace app::InventoryItemBox {
    enum ItemNumType {
        All = 0,
        One = 1,
    };
}
namespace via::render::Atmosphere {
    enum IBLTextureBakeMode {
        Panorama = 0,
        Cubemap = 1,
    };
}
namespace app::CarInGarage::Donut {
    enum Routine {
        Steer = 0,
        Approach = 1,
        Turn = 2,
        FinishTurn = 3,
        End = 4,
    };
}
namespace via::navigation::map::Node {
    enum SystemAttributes {
        SystemAttribute_ModifiedChildren = 0,
        SystemAttribute_Junction = 1,
        SystemAttribute_DisableHybridTrace = 2,
        SystemAttribute_MultiSharedEdge = 3,
        SystemAttribute_HasExtraLink = 4,
        SystemAttribute_ConnectExtraLinkBoundary = 5,
        SystemAttribute_Wall = 6,
        SystemAttribute_ConnectedWall = 7,
        SystemAttributeBitNum = 32,
    };
}
namespace via::navigation::Navigation {
    enum NoMapAction {
        NoMove = 0,
        Straight = 1,
    };
}
namespace app {
    enum Easing {
        Linear = 0,
        InQuad = 1,
        OutQuad = 2,
        InOutQuad = 3,
        InCubic = 4,
        OutCubic = 5,
        InOutCubic = 6,
    };
}
namespace via::effect {
    enum PolygonDivideDrawFlag {
        None = 0,
        Select = 1,
        All = 2,
    };
}
namespace app::UITimer {
    enum CountTypeDef {
        CountUp = 0,
        CountDown = 1,
    };
}
namespace app::InventoryMenu {
    enum DircType {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4,
    };
}
namespace via::network::error {
    enum CauseUtility {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        ProfileAlreadyShowing = 129,
    };
}
namespace app::Em3002::Goal::Search {
    enum Type {
        Non = 0,
        Vision = 1,
        Hearing = 2,
    };
}
namespace app::DoorPush {
    enum SETriggerID {
        Unknown = 0,
        Locked = 1,
        CreakSlow = 2,
        CreakStop = 3,
        OpenKnob = 4,
        OpenLock = 5,
        OpenSlow = 6,
        AutoCloseCreakShort = 7,
        AutoCloseCreakLong = 8,
        AutoClose = 9,
        AutoCloseSoft = 10,
        Rattle = 11,
        RattleShort = 12,
    };
}
namespace via::audiorender {
    enum RequestType {
        None = 0,
        Play = 1,
        Prepare = 2,
        Resume = 3,
        ResumeAfterFadeOut = 4,
        ResumeAfterStopped = 5,
        ResumeBeforeFadeOut = 6,
        ResumeBeforeStopped = 7,
        ResumeBarBeat = 8,
        ResumeEveryBar = 9,
        ResumeEveryBeat = 10,
        CancelResumeBarBeat = 11,
        CancelResumeEveryBar = 12,
        CancelResumeEveryBeat = 13,
        Pause = 14,
        Stop = 15,
        StopMarker = 16,
        StopBarBeat = 17,
        StopNextBar = 18,
        Seek = 19,
        ResetDelayStop = 20,
        PauseAll = 21,
        CancelPauseAll = 22,
        StopAll = 23,
        SetVolume = 24,
        StartFadeIn = 25,
        ResumeFadeIn = 26,
        FadeIn = 27,
        StartFadeOut = 28,
        FadeOut = 29,
        FadeOutMarker = 30,
        FadeOutBarBeat = 31,
        SetSendingBusVolume = 32,
        StartFadeInSendingBus = 33,
        FadeInSendingBus = 34,
        StartFadeOutSendingBus = 35,
        FadeOutSendingBus = 36,
        Rewind = 37,
        SetPan = 38,
        SetPan2ch = 39,
        SetMultiPan = 40,
        SetSourcePosition = 41,
        SetSourceMultiPosition = 42,
        SetListenerPositionRotation = 43,
        SetCoordinateType = 44,
        SetPanType = 45,
        SetMultiPanEnable = 46,
        SetMultiPanDisable = 47,
        SetPitch = 48,
        SetPitchByRatio = 49,
        EnablePropagation = 50,
        DisablePropagation = 51,
        SetPropagation = 52,
        SetPropagationLpfQ = 53,
        StartInterpolatePropagation = 54,
        InterpolatePropagation = 55,
        SetInteractiveVolume = 56,
        StartInterpolateInteractiveVolume = 57,
        InterpolateInteractiveVolume = 58,
        SetMixer = 59,
        ClearMixer = 60,
        SetInsertEffect = 61,
        StartSendingBus = 62,
        StopSendingBus = 63,
        SetBusVolume = 64,
        MuteOrUnmuteBus = 65,
        EnableBusPosition = 66,
        DisableBusPosition = 67,
        SetBusPosition = 68,
        EnableBusPropagation = 69,
        DisableBusPropagation = 70,
        SetBusPropagation = 71,
        SetAllBusPropagationLpfQ = 72,
        SetBusPropagationLpfQ = 73,
        StartInterpolateBusPropagation = 74,
        InterpolateBusPropagation = 75,
        SetBusInteractiveVolume = 76,
        StartInterpolateBusInteractiveVolume = 77,
        InterpolateBusInteractiveVolume = 78,
        BypassEffect = 79,
        SetMultiBandEqFrequency = 80,
        SetMultiBandEqQ = 81,
        SetMultiBandEqGainDb = 82,
        StartGetWaveOnBus = 83,
        StopGetWaveOnBus = 84,
        StartOutputPort = 85,
        StopOutputPort = 86,
        StartOutputVibrationPort = 87,
        StopOutputVibrationPort = 88,
        SetDistortionGainDb = 89,
        SetDistortionMixAmount = 90,
        SetDistortionDistType = 91,
        SetDistortionOutputGainDb = 92,
        SetI3DL2ReverbDryVolume = 93,
        SetI3DL2ReverbRoom = 94,
        SetI3DL2ReverbRoomHf = 95,
        SetI3DL2ReverbRoomRolloffFactor = 96,
        SetI3DL2ReverbDecayTime = 97,
        SetI3DL2ReverbDecayHFRatio = 98,
        SetI3DL2ReverbReflections = 99,
        SetI3DL2ReverbReflectionsDelay = 100,
        SetI3DL2ReverbReverb = 101,
        SetI3DL2ReverbReverbDelay = 102,
        SetI3DL2ReverbDiffusion = 103,
        SetI3DL2ReverbDensity = 104,
        SetI3DL2ReverbHFReference = 105,
        SetSimpleFdnReverbDryVolumeDb = 106,
        SetSimpleFdnReverbWetVolumeDb = 107,
        SetSimpleFdnReverbHf = 108,
        SetSimpleFdnReverbReverbTime = 109,
        SetSimpleFdnReverbPreDelay = 110,
        SetSimpleFdnReverbDensity = 111,
        SetSphericalHarmonics = 112,
        Max = 113,
    };
}
namespace app::GameFlowEndNode {
    enum EndTypeEnum {
        Noraml = 0,
        After = 1,
        Max = 2,
    };
}
namespace via::navigation::map::Link {
    enum PortalType {
        Destination = 0,
        Source = 1,
        ToBoundary = 2,
        FromBoundary = 3,
    };
}
namespace app::CH8StateSwitchM2 {
    enum CHP8_2 {
        SILENCE = 0,
        CHP8_EM4600_BT_MINING = 1,
        CHP8_EM4600_BT_END_MINING = 2,
        CHP8_EM4400_BT_MINING = 3,
        CHP8_EM4400_BT_END_MINING = 4,
    };
}
namespace app::Command {
    enum HIDCommandType {
        None = 0,
        Aim = 1,
        Attack = 2,
        Reload = 3,
        Guard = 4,
        ChangeAmmo = 5,
        SwitchWeaponLeft = 6,
        SwitchWeaponRight = 7,
        SwitchWeaponUp = 8,
        SwitchWeaponDown = 9,
        MoveForward = 10,
        MoveBackward = 11,
        MoveLeft = 12,
        MoveRight = 13,
        DashHold = 14,
        DashToggle = 15,
        QuickTurn = 16,
        Crouch = 17,
        Interact = 18,
        Heal = 19,
        Pause = 20,
        Map = 21,
        Inventory = 22,
        Confirm = 23,
        Cancel = 24,
        CursorUp = 25,
        CursorDown = 26,
        CursorLeft = 27,
        CursorRight = 28,
        SwitchTabLeft = 29,
        SwitchTabRight = 30,
        MoveItem = 31,
        SortInventory = 32,
        ItemSetSwitchScreen = 33,
        ItemSetAdd = 34,
        ItemSetUse = 35,
        MapLegend = 36,
        MapUp = 37,
        MapDown = 38,
        MapCurrentLocation = 39,
        SpDelete = 40,
        SpCheck = 41,
        SpUse = 42,
        TakeCard = 43,
        TakeNoCard = 44,
    };
}
namespace System {
    enum TypeCode {
        Empty = 0,
        Object = 1,
        DBNull = 2,
        Boolean = 3,
        Char = 4,
        SByte = 5,
        Byte = 6,
        Int16 = 7,
        UInt16 = 8,
        Int32 = 9,
        UInt32 = 10,
        Int64 = 11,
        UInt64 = 12,
        Single = 13,
        Double = 14,
        Decimal = 15,
        DateTime = 16,
        String = 18,
    };
}
namespace app::OptionMenu {
    enum Fov_Value {
        Fov_60 = 0,
        Fov_70 = 1,
        Fov_80 = 2,
        Fov_90 = 3,
        Fov_100 = 4,
        Fov_110 = 5,
        Fov_120 = 6,
    };
}
namespace via::movie {
    enum PlaybackStrategy {
        OneShot = 0,
        Loop = 1,
        Replay = 2,
    };
}
namespace app::MessageLabelGUI {
    enum MsgType {
        MultiDispSubtitle = 0,
        Subtitle = 1,
        Interact = 2,
    };
}
namespace via::effect::gpgpu::BillboardCS::BillboardResource {
    enum ShaderType {
        Default = 0,
        LuminanceBleed = 1,
        SimpleLuminanceBleed = 2,
        Default_IgnoreDepth = 3,
        LuminanceBleed_IgnoreDepth = 4,
        SimpleLuminanceBleed_IgnoreDepth = 5,
        StochasticPreZ = 6,
        StochasticTransparent = 7,
        MaxType = 8,
    };
}
namespace via::physics::CastRayQuery {
    enum Type {
        Unknown = 0,
        Ray = 1,
        EndPoint = 2,
        Max = 3,
    };
}
namespace via::motion {
    enum MotionType {
        None = 0,
        Motion = 1,
        Tree = 2,
    };
}
namespace via::hid::textInput {
    enum TextInputResult {
        OK = 0,
        AlreadyDone = 1,
        Error = 2,
        NotImplemented = 3,
        Invalid = 4,
        Busy = 5,
    };
}
namespace via::motion::IkLegSpine {
    enum AdditionalFootAdjustMode {
        None = 0,
        RayFromKnee = 1,
        RayFromHip = 2,
        RayFromHipFast = 3,
        FourRayFromToe = 4,
        SideRayFromToe = 5,
    };
}
namespace via::simplewwise {
    enum ProjectNo {
        No0 = 0,
        No1 = 1,
        No2 = 2,
        No3 = 3,
        Default = 0,
    };
}
namespace via::motion::detail::ChainLinkData {
    enum LinkMode {
        TopToBottom = 0,
        BottomToTop = 1,
        Manual = 2,
    };
}
namespace via::network::MatchmakingRules {
    enum DataType {
        None = -1,
        Number = 0,
        TotalValue = 1,
        TotalBit = 2,
        Qos = 3,
        String = 4,
    };
}
namespace app::OptionMenu {
    enum DisplayCaption {
        On = 0,
        Off = 1,
    };
}
namespace via::audiorender {
    enum SourceStatus {
        None = 0,
        Initialized = 1,
        Prepare = 2,
        PrepareFinished = 3,
        Pause = 4,
        Play = 5,
        PlayFinished = 6,
        Finished = 7,
    };
}
namespace via::gui::MessageAnalyzer {
    enum State {
        Normal = 0,
        Ruby = 1,
        RubyRB = 2,
        RubyRT = 3,
        TCU = 4,
    };
}
namespace app::Em4200::Action::Breath {
    enum Type {
        Vertical = 0,
        Horizontal = 1,
        Walk = 2,
        Simple = 3,
    };
}
namespace app::fsm::setGenomeCodexMode {
    enum Mode {
        Scan = 0,
        Install = 1,
        TraceScan = 2,
        CommunicationCall = 3,
        CommunicationIncoming = 4,
        CommunicationTalking = 5,
        CommunicationEndTalking = 6,
        CommunicationEndTalkingCutOff = 7,
        RadarCautionNone = 8,
        RadarCautionNear = 9,
        RadarCautionReached = 10,
        CommunicationIncomingUnknown = 11,
    };
}
namespace via::physics::RequestSetColliderResource {
    enum RequestSetState {
        AlwaysRegister = 0,
        Max = 1,
    };
}
namespace Em3600Effect {
    enum IDAlias {
        Resident = 0,
        Grapple = 1,
        Generate = 2,
        SneakHint_00 = 3,
        SneakHint_01 = 4,
        SneakHint_02 = 5,
        SneakHint_03 = 6,
        SneakHint_04 = 7,
        SneakHint_05 = 8,
        SneakHint_06 = 9,
        SneakHint_07 = 10,
        SneakHint_08 = 11,
        SneakHint_09 = 12,
        SneakHint_10 = 13,
        SneakHint_11 = 14,
        SneakHint_12 = 15,
        SneakHint_13 = 16,
        SneakHint_14 = 17,
        SneakHint_15 = 18,
        SneakHint_16 = 19,
        SneakHint_17 = 20,
        SneakHint_18 = 21,
        WeakPointHit = 22,
        AngryMode = 23,
        WindowBrake = 24,
        CoreCoverBreak = 25,
    };
}
namespace via::puppet::RemoteGameObject {
    enum SendPriority {
        None = 0,
        Unreliable = 1,
        Reliable = 2,
        Both = 3,
        SyncImmediate = 4,
    };
}
namespace System::Collections::Specialized {
    enum NotifyCollectionChangedAction {
        Add = 0,
        Remove = 1,
        Replace = 2,
        Move = 3,
        Reset = 4,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraFrameStatus {
        Active = 0,
        NotActive = 1,
        AlreadyRead = 2,
        NotStable = 3,
        InvalidFrame = 4,
        InvalidMetaData = 5,
    };
}
namespace app::CH9Em7500::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        OutRange = 1,
        InRange = 2,
        Front = 3,
        FrontFromTarget = 4,
        RightFromTarget = 5,
        LeftFromTarget = 6,
        IsWanderIntervalTimer = 7,
        InRangeFromJoint = 8,
        FrontFromJoint = 9,
        CanGrapple = 10,
        HasAttackRight = 11,
    };
}
namespace app {
    enum CraftState {
        Craftable = 0,
        LevelMax = 1,
        JunkPartsShortage = 2,
        InventoryAddFailed = 3,
        Unknwon = 4,
        Max = 5,
    };
}
namespace via::effect::detail {
    enum StretchType {
        Time = 0,
        Distance = 1,
    };
}
namespace app::PlayerMotionController {
    enum RequestPriority {
        Default = 0,
        Damage = 1,
        Dead = 2,
    };
}
namespace app::CH8ItemDrop {
    enum PropType {
        None = 0,
        RigidBodyDestruct = 1,
    };
}
namespace app::fsm::InteractStart {
    enum StartTypeParam {
        Normal = 0,
        SwitchOn = 1,
        SwitchOff = 2,
    };
}
namespace via::effect::gpgpu::detail {
    enum GlobalLocalVectorFieldFlags {
        Local = 1,
        Global = 2,
    };
}
namespace via::network::msgpack {
    enum ObjectType {
        NilObject = 0,
        Boolean = 1,
        PositiveInteger = 2,
        NegativeInteger = 3,
        Float64 = 4,
        Float32 = 10,
        Str = 5,
        Array = 6,
        Map = 7,
        Bin = 8,
        Ext = 9,
        None = 255,
    };
}
namespace app::CH9Em5800 {
    enum ThinkState {
        None = 0,
        NoThink = 1,
        Passive = 2,
    };
}
namespace app::Em3002::Action::Walk {
    enum Type {
        Normal = 0,
        TNormal = 1,
    };
}
namespace via::movie {
    enum Codec {
        Unknown = 0,
        H264 = 1,
        WMV9 = 2,
        LLMV_SLP = 3,
        H265 = 4,
        Bink = 5,
    };
}
namespace app::Em3102::Action::Search {
    enum Type {
        None = 0,
        SearchR = 1,
        SearchL = 2,
    };
}
namespace app::CH8Em4500CoreGuard {
    enum CoreStetus {
        Default = 0,
        Close = 1,
        Open = 2,
    };
}
namespace app::vr::VrFlowBase {
    enum FlowType {
        Start = 0,
        Stop = 1,
        Error = 2,
        FirstBoot = 3,
        SecondBoot = 4,
        Tutorial = 5,
    };
}
namespace via::motion::detail {
    enum InstancePoolType {
        DoNothing = 0,
        CallFinalize = 1,
        PlacementNew = 2,
    };
}
namespace via::hid::camera::detail::PlayStationCameraLedTracker {
    enum StartResult {
        OK = 0,
        ErrorUnknown = -1,
        ErrorAlreadyStarted = -2,
        ErrorUpdateStatusIsNotWait = -3,
        ErrorCameraDeviceIsNotFound = -4,
        ErrorCameraStartFailed = -5,
        ErrorNotSupported = -6,
    };
}
namespace via::dynamics {
    enum ShapeType {
        Invalid = 0,
        Sphere = 1,
        Capsule = 2,
        Box = 3,
        Mesh = 4,
        HeightField = 5,
        Triangle = 6,
        ConvexHull = 7,
        StaticCompound = 8,
        Max = 9,
    };
}
namespace via::hid::AudioInManager {
    enum AUDIO_IN_TYPE {
        NORMAL = 0,
        VOICE_CHAT = 1,
        VOICE_RECOGNITION = 2,
    };
}
namespace app::CH8Em4500ActionController {
    enum ModeMotionStatus {
        Small = 0,
        Change = 1,
        Big = 2,
    };
}
namespace via::motion::IkDog {
    enum RayCastSkipOption {
        None = 1,
        DIV2 = 2,
        DIV4 = 4,
    };
}
namespace app::Nightmare {
    enum WaveState {
        None = 0,
        Wave1 = 1,
        Wave2 = 2,
        Wave3 = 3,
        Wave4 = 4,
        Wave5 = 5,
        Clear = 6,
    };
}
namespace via::str::detail::format::boost::format_item {
    enum ExFmtFlag {
        Ignore = 0,
        SetPrecision = 0,
        ZeroPadding = 0,
        Centering = 0,
    };
}
namespace app::CH8Em4400::Action::CH8Generate {
    enum GenerateState {
        Start = 0,
        Loop = 1,
        End = 2,
        Chancel = 3,
        RequestEnd = 4,
    };
}
namespace via::storage {
    enum SaveServiceWriteMode {
        SaveServiceWriteMode_Default = 131072,
        SaveServiceWriteMode_1_Byte = 1,
        SaveServiceWriteMode_512_Sector = 512,
        SaveServiceWriteMode_1_KiloByte = 1024,
        SaveServiceWriteMode_4K_Sector = 4096,
        SaveServiceWriteMode_64_KiloByte = 65536,
        SaveServiceWriteMode_128_KiloByte = 131072,
        SaveServiceWriteMode_256_KiloByte = 262144,
        SaveServiceWriteMode_512_KiloByte = 524288,
        SaveServiceWriteMode_1_MegaByte = 1048576,
        SaveServiceWriteMode_HighSpeed = 2147483647,
    };
}
namespace via::gui {
    enum GridScrollDirection {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4,
    };
}
namespace app::OptionMenu {
    enum ReticleDisplay {
        AlwaysDisplay = 0,
        AimDisplay = 1,
        Hide = 2,
    };
}
namespace via::audiorender {
    enum AmbisonicsNormalizeType {
        N = 0,
        SN3D = 1,
    };
}
namespace app::Em5520::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        ReturnMove = 2,
        GotoTarget = 3,
        Attack = 4,
        Leave = 5,
        VolumeSpaceMoveToTarget = 6,
        VolumeSpaceMoveToPosition = 7,
        Dead = 8,
        Appear = 9,
        Suspend = 10,
        DamageWait = 11,
        NearDoor = 12,
        NearDoorClose = 13,
        NearDoorOpen = 14,
        AttackAction = 15,
        LeaveAction = 16,
        DeadAction = 17,
        AppearAction = 18,
        IdleAction = 19,
        SuspendAction = 20,
        Warp1 = 21,
        Warp2 = 22,
    };
}
namespace via::audiorender {
    enum ResourceChunkTag {
        Head = 1751347827,
        Data = 1684238963,
    };
}
namespace via::navigation::Navigation {
    enum AdjustPositionType {
        CurrentPosition = 0,
        Direct = 1,
    };
}
namespace via::vr::psCamera {
    enum PSCameraStopResult {
        OK = 1,
        Stoped = 2,
        ErrInternal = 2147487744,
    };
}
namespace app::CH9Em7900::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromFrontWithDirective = 8,
        IsTargetDamage = 9,
        IsOccluded = 10,
        IsTargetOnLadder = 11,
        CanBreathOcclude = 12,
        IsStandOnSlope = 13,
        AdditiveSensedAttack = 14,
    };
}
namespace via::audiorender {
    enum FilterType {
        LowPass = 0,
        HighPass = 1,
        BandPass = 2,
        Notch = 3,
        AllPass = 4,
        Peaking = 5,
        LowShelf = 6,
        HighShelf = 7,
        Number = 8,
    };
}
namespace app::Em3100::Action::WalkOverLook {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace via::motion::DataHeader {
    enum ErrFlags {
        None = 0,
        Empty = 1,
        NotFoundRefAsset = 2,
        NotFoundIncludeAsset = 4,
    };
}
namespace app::CH9WeaponWwiseStateList {
    enum SndSwitch_enhanceType {
        NORMAL = 0,
        ENHACE = 1,
        ROT = 2,
    };
}
namespace via {
    enum SystemServicePerformanceMode {
        Invalid = 0,
        Normal = 1,
        Boost = 2,
    };
}
namespace app::Em4000::Action::Move {
    enum Type {
        Normal = 0,
        Destination = 1,
        Wanderer = 2,
    };
}
namespace via::network::AutoMatchmaking {
    enum DataType {
        Number = 0,
        TotalValue = 1,
        TotalBit = 2,
    };
}
namespace via::render::compress {
    enum PngFormat {
        Unknown = 0,
        RGB8bit = 1,
        RGBA8bit = 2,
        Gray8bit = 3,
        GrayAlpha8bit = 4,
        RGB16bit = 5,
        RGBA16bit = 6,
        Gray16bit = 7,
        GrayAlpha16bit = 8,
    };
}
namespace via::network::error {
    enum Service {
        None = 0,
        Context = 1,
        P2p = 2,
        Session = 3,
        Ranking = 4,
        Achievements = 5,
        Storage = 6,
        Protocol = 7,
        Invitation = 8,
        HttpClient = 9,
        Native = 10,
        IdConverter = 11,
        Utility = 12,
        WebSocketClient = 13,
        OverlaySession = 14,
        Matchmaking = 15,
    };
}
namespace via::geometry {
    enum BrushPipelineState {
        Shape = 0,
        ShapeDefault = 1,
        ShapeShadow = 2,
        ShapeWire = 3,
        ShapePick = 4,
        ShapeOutline = 5,
        ImagePlane = 6,
        ImagePlaneDefault = 7,
        ShapeTransparent = 8,
        ShapeDefaultTransparent = 9,
        CollectVeretx = 10,
        Max = 11,
    };
}
namespace app::fsm::CH8NoSaveValueControl {
    enum ControlTargetEnum {
        None = 0,
        LastBattle = 1,
        HUDEvent = 2,
    };
}
namespace via::render::layer::PostShadowCast {
    enum PostShadowCastSegment {
        DepthOcclusion = 0,
    };
}
namespace via::hid::gamePlayer {
    enum AutoDeviceSelectionFlag {
        None = 0,
        TryOnAssign = 2,
        TryOnReassign = 4,
    };
}
namespace app {
    enum EventCharaID {
        Pl0000 = 0,
        Pl1000 = 1,
        Em2000 = 2,
        Em7300A = 3,
        Em7300B = 4,
        Em7300C = 5,
        Em8910A = 6,
        Em8910B = 7,
        Em8910C = 8,
        Em9900A = 9,
        Em9900B = 10,
        Em9900C = 11,
        Em3000 = 12,
        Em3000Head = 13,
    };
}
namespace app::SaveDataManager {
    enum RestartFadeTypeEnum {
        Default = 0,
        WaitFadeInTimeSet = 1,
        NoFadeIn = 2,
    };
}
namespace via::render::layer::DeferredLighting {
    enum AllowShadowType {
        Standard = 0,
        StandardAndTranslucent = 1,
        Max = 2,
    };
}
namespace app::FileMenu_File {
    enum FileInput {
        Default = 0,
        WaitSelectionChange = 1,
        WaitPageChange = 2,
    };
}
namespace app::Em3001::Goal::Search {
    enum Type {
        Non = 0,
        Vision = 1,
        Hearing = 2,
        Damage = 3,
    };
}
namespace app::CH9Em6400::Action::Step {
    enum StepCorrectionDirection {
        None = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::Em3001::Em3001WwiseMonitoredValue {
    enum GameRank {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        MAX = 10,
    };
}
namespace via::motion::detail {
    enum ChainTaperedCollideMethod {
        TermSphere = 0,
    };
}
namespace app::FF030_Ex_ScreenControl {
    enum ScreenTypeEnum {
        Title = 0,
        EndCard = 1,
    };
}
namespace via::autoplay::action::AutoAttack {
    enum Precision {
        High = 0,
        Medium = 1,
        Low = 2,
    };
}
namespace app::CH9Em7800::Action::FinishBlow {
    enum Type {
        SneakB = 0,
    };
}
namespace app::Em5552::Action {
    enum ActionNo {
        Idle = 0,
        Attack = 1,
        Damage = 2,
        Dead = 3,
    };
}
namespace via::render {
    enum UsageType {
        Default = 0,
        Immutable = 1,
        Dynamic = 2,
        Staging = 3,
    };
}
namespace app::Nightmare::NightmareTrapLevelBehavior {
    enum Type {
        Target = 0,
        Symbol = 1,
        Interact = 2,
    };
}
namespace via::rebe {
    enum RebeServiceState {
        None = 0,
        Initialized = 1,
        Running = 2,
        Authorized = 3,
        Failed = 4,
    };
}
namespace via::effect::gpgpu::detail {
    enum DepthOperatorFlags {
        UseBounce = 1,
        UseYNormalEmission = 2,
        FreezeBounceParticle = 4,
    };
}
namespace via::network::wrangler {
    enum ProviderEnabledState {
        Undefined = 0,
        ForceOff = 1,
        OffByDefault = 2,
        OnByDefault = 3,
        ForceOn = 4,
    };
}
namespace app::DrawDebugShape {
    enum DrawTypeEnum {
        Capsule = 0,
        Line = 1,
        OBB = 2,
        Point = 3,
        Rect = 4,
        Sphere = 5,
        String2D = 6,
        String3D = 7,
        Triangle = 8,
        UnitBox = 9,
        FillRect = 10,
        FillTriangle = 11,
    };
}
namespace app {
    enum FsmParam {
        None = 0,
        Open = 1,
        Close = 2,
        Up = 3,
        Down = 4,
        Start = 5,
        End = 6,
        SelectA = 7,
        SelectB = 8,
        SelectC = 9,
        SelectD = 10,
        SelectE = 11,
        On = 12,
        Off = 13,
    };
}
namespace via::render {
    enum HazeCompositorBlur {
        Level1 = 0,
        Level2 = 1,
        Level3 = 2,
        Level4 = 3,
    };
}
namespace via::landscape::road {
    enum HeightBakeType {
        Both = 0,
        RaiseOnly = 1,
        LowerOnly = 2,
    };
}
namespace app::dev1lab::PlatformTicketController {
    enum Phase {
        Invalid = 0,
        Request = 1,
        Wait = 2,
        Complate = 3,
    };
}
namespace app::CH8Em4500::Goal::CH8GoalGenerator {
    enum ID {
        Appear = 0,
        Battle = 1,
        FastBattle = 2,
        SecondBattle = 3,
        Anger = 4,
        Idle = 5,
        Follow = 6,
        AppearAction = 7,
        Move = 8,
        AttackBeating = 9,
        Grapple = 10,
        GrappleAction = 11,
        TwoConsecutiveStrike = 12,
        FourConsecutiveStrike = 13,
        ConsecutiveStrikeAction = 14,
        Jump = 15,
        JumpAction = 16,
        BladeThrustStrikeStrike = 17,
        BladeThrustStrikeStrikeAction = 18,
        AttackScratchBig = 19,
        AttackScratchBigAction = 20,
        QuickJump = 21,
        QuickJumpAction = 22,
        ShortStrike = 23,
        ShortStrikeBack = 24,
        BackWalk = 25,
        BackWalkNextAction = 26,
        SpitBeam = 27,
        JumpUp = 28,
        Avoidance = 29,
        ContinousJump = 30,
        ThinkChangeThreat = 31,
        RushMode = 32,
        SpitBeamMode = 33,
        OxygenObstacleMode = 34,
        OpenCoreMode = 35,
        RunawayMode = 36,
        DownAfterThreat = 37,
        WalkItervalThreat = 38,
        StrikeToParry = 39,
    };
}
namespace via::motion::RetargetRig {
    enum RotationCalcOrder {
        After = 0,
        Before = 1,
    };
}
namespace via::effect::detail {
    enum SamplingPositionType {
        Emitter = 0,
        Joint = 1,
        Particle = 2,
    };
}
namespace via::navigation::Navigation {
    enum NoNodeSearch {
        None = 0,
        NearestNode = 1,
    };
}
namespace app::LookAt {
    enum Index {
        _LookAtJoint0 = 0,
        _LookAtJoint1 = 1,
        _LookAtJoint2 = 2,
        _LookAtJoint3 = 3,
        _LookAtJoint4 = 4,
        Head = 5,
        L_Eye = 6,
        R_Eye = 7,
    };
}
namespace via::hid {
    enum GestureState {
        Update = 0,
        Begin = 1,
        End = 2,
        Cancel = 3,
        BeginOneShot = 4,
    };
}
namespace via::network::error {
    enum MethodRanking {
        Update = 0,
        Register = 1,
        GetScoreByRange = 2,
        GetScoreByUniqueId = 3,
        GetScoreByFriend = 4,
    };
}
namespace app::CardGameMaster {
    enum FaceType {
        Down = 0,
        Up = 1,
    };
}
namespace app::Em5540Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::GimmickActiveControl {
    enum EndTypeEnum {
        None = 0,
        SetNo = 1,
        Auto = 2,
    };
}
namespace via::os::detail {
    enum SocketSslSubError {
        None = 0,
    };
}
namespace app::MapManager {
    enum SheetMode {
        FRAME = 0,
        MAPIMAGE = 1,
        BG = 2,
    };
}
namespace via::render::PrimitiveMaterial {
    enum ShaderType {
        Transparent = 0,
        Solid = 1,
        SolidExpensive = 2,
    };
}
namespace via::hid {
    enum NpadId {
        Handheld = 1,
        No1 = 2,
        No2 = 4,
        No3 = 8,
        No4 = 16,
        No5 = 32,
        No6 = 64,
        No7 = 128,
        No8 = 256,
        Invalid = -1,
    };
}
namespace via::physics {
    enum PhaseType {
        AfterUpdate = 0,
        CharacterControl = 1,
        AfterLateUpdate = 2,
        Max = 3,
    };
}
namespace via::storage::DLC {
    enum MountMode {
        Automatic = 0,
        Manual = 1,
    };
}
namespace via::landscape::beta::GroundBetaManager {
    enum GroundPipelineStateType {
        CSGroundSplatTextureCopy = 0,
        CSGroundSplatTextureCopyTail = 1,
        CSUploadToPhysicalTexture = 2,
        CSUploadToPhysicalUintTexture = 3,
        CSUpdateVirtualTexture = 4,
        CSBuildGroundNodeList = 5,
        CSClearGroundNodeList = 6,
        CSClearGroundDrawIndirectArgs = 7,
        CSUpdateGroundLodMap = 8,
        CSBuildVisibleRenderNodeList = 9,
        CSBuildVisibleRenderNodeListEdit = 10,
        DrawGroundNodesNear = 11,
        DrawGroundNodesNoBlendNear = 12,
        DrawGroundNodesBilinearNear = 13,
        DrawGroundNodesFar = 14,
        DrawGroundNodesNoBlendFar = 15,
        DrawGroundNodesBilinearFar = 16,
        DrawGroundNodesShadows = 17,
        DrawGroundNodesCullingOffShadows = 18,
        DrawGroundNodesPick = 19,
        DrawGroundNodesOutline = 20,
        DrawGroundNodesWireframe = 21,
        DrawGroundNodesFilledWireframe = 22,
        DrawGroundNodesMaterialDebug = 23,
        DrawGroundNodesLodDebug = 24,
        Max = 25,
    };
}
namespace app::OptionMenu {
    enum Step {
        Main = 0,
        Controls = 1,
        Display = 2,
        Audio = 3,
        Language = 4,
        Graphics = 5,
        Record = 6,
        Default = 7,
        HDRMaxNits = 8,
        Brightness = 9,
        HDRBrightness = 10,
        ScreenArea = 11,
        KeyBind = 12,
        BootFlow = 13,
        VrOn = 14,
        VrOff = 15,
        VrTutorial = 16,
        Birthday = 17,
        DLC1 = 18,
        DLC2 = 19,
        DLC3 = 20,
        DLC4 = 21,
        DLC5 = 22,
        DLC6 = 23,
        DLC7 = 24,
        Store = 25,
        ReNet = 26,
        ReNetCutinOnCheck = 27,
        ReNetCutinOn = 28,
        ReNetCutinOff = 29,
        ReNetCutinWeb = 30,
        ReNetCutinDetail = 31,
        Manual = 32,
        PrivacyPolicy = 33,
        GDPR = 34,
        GDPR2 = 35,
        EMD = 36,
        HDRModeChanged = 37,
        HDRModeNG = 38,
        ResolutionChanged = 39,
        CrossSave = 40,
        Credit = 41,
    };
}
namespace via::effect::gpgpu::detail {
    enum GpuParentOptions {
        None = 0,
        UseLocal = 1,
    };
}
namespace app::CH9Em6400ActionController {
    enum ActionDistanceType {
        None = 0,
        Zero = 1,
        Short = 2,
        Middle = 3,
        Far = 4,
        Max = 5,
    };
}
namespace via::behaviortree::action::SetBool {
    enum Status {
        False = 0,
        True = 1,
    };
}
namespace app::fsm::CH8EnemyStateCheck {
    enum EnemyIntType {
        None = 0,
    };
}
namespace via::render::command::UpdateBuffer {
    enum BufferType {
        VertexBuffer = 0,
        IndexBuffer = 1,
        Buffer = 2,
        VertexBufferFromUserPtr = 3,
        IndexBufferFromUserPtr = 4,
        BufferFromUserPtr = 5,
    };
}
namespace via::motion::IkLeg2 {
    enum IkCtrl {
        HumanToe = 0,
        HumanHeal = 1,
        HumanExToe = 2,
        HumanExHeal = 3,
        BeastToe = 4,
    };
}
namespace via::motion::detail::ChainJiggleData {
    enum AttrFlags {
        None = 0,
        OverrideDamping = 1,
    };
}
namespace via::render::primitive {
    enum LightingType {
        Billboard = 0,
        Ribbon = 1,
        Polygon = 2,
    };
}
namespace via::storage::saveService {
    enum SaveDataType {
        Array = -1,
        Int32 = 0,
        Int64 = 1,
        Float = 2,
        Struct = 3,
        String = 4,
        Class = 5,
    };
}
namespace app::Em5510 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::CH8Em4000ActionController {
    enum DestinationType {
        ChangeThink = 0,
        SelfKill = 1,
    };
}
namespace app::AI::GoalArbitrator {
    enum Cycle {
        EveryFrame = 0,
        Permitted = 1,
        ElapsedSec = 2,
    };
}
namespace via::landscape {
    enum BakerPipelineState {
        BakeHeightMapFromUpper = 0,
        BakeHeightMapFromLower = 1,
        BakePathHeightMap = 2,
        BakePathSplatMap = 3,
        BakeRoadHeightMap = 4,
        BakeRoadSplatMap = 5,
        BakeRoadSDF = 6,
        BakeGroundSplatSDF = 7,
        BakeFoliagePointMap = 8,
        BakeFoliageMapSDF = 9,
        BakeHeightIntersectMap = 10,
        BakeHeightIntersectSDF = 11,
        BakePointCloudSplatMap = 12,
        BakePointCloudSDF = 13,
        CutOutSDFTexture = 14,
        Max = 15,
    };
}
namespace via::wwise {
    enum SinkTypeWindows {
        Main = 0,
        MergeToMain = 1,
        Secondary = 2,
        Communication = 3,
        MicrodsoftSpatialSound = 4,
        None = 5,
    };
}
namespace app::CH9Em7700::ThinkStateSet {
    enum Type {
        Default = 0,
        Mimicry = 1,
        Dregs = 2,
        Destination = 3,
        Wanderer = 4,
        Extra = 5,
        TU2 = 6,
    };
}
namespace via::render {
    enum SrvDimension {
        Unknown = 0,
        Buffer = 1,
        Texture1d = 2,
        Texture1darray = 3,
        Texture2d = 4,
        Texture2darray = 5,
        Texture2dms = 6,
        Texture2dmsarray = 7,
        Texture3d = 8,
        Texturecube = 9,
        Texturecubearray = 10,
        Bufferex = 11,
        AccelerationStructure = 12,
    };
}
namespace app::MapManager {
    enum LegendType {
        None = -1,
        Player = 0,
        Arms = 1,
        Keyitem = 2,
        SavePoint = 3,
        Itembox = 4,
        Pharmacy = 5,
        KeyPickBox = 7,
        CommonKey = 20,
        TalismanKey = 21,
        MorgueKey = 22,
        MasterKey = 23,
        SpareKey = 24,
        Food = 50,
        BirthdayJack = 51,
        BirthdaySealed = 52,
    };
}
namespace app::ReliefItemTable {
    enum TableType {
        Normal = 0,
    };
}
namespace via::os::websocket_client {
    enum ErrorCause {
        Timeout = 256,
        Native = 257,
        HandshakeFailed = 258,
        IllegalStatusCode = 259,
        FrameParseFailed = 260,
        InvalidHeaderValue = 261,
        ClosedByServer = 262,
        DisconnectByServer = 263,
    };
}
namespace via::render::CubeTo2D {
    enum TYPE {
        PARABOROID = 0,
        SPHERE = 1,
    };
}
namespace via {
    enum AccountPickerShowRequestResult {
        Success = 0,
        ErrorNotSupported = 1,
        ErrorAlreadyShown = 2,
        ErrorNoDevices = 3,
        ErrorInvalidParam = 4,
        ErrorForbidden = 5,
    };
}
namespace app::CH8Em4400::Action::CH8Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::CH8Telemetry {
    enum OtherCountType {
        CountOfAirTank = 0,
        CountOfQuizWrong = 1,
        CountOfPunch = 2,
        CountOfStomp = 3,
        CountOfTrapPanel = 4,
        CountOfInfraredTrap = 5,
    };
}
namespace via::simplewwise {
    enum OutputDevice {
        None = 0,
        HDMI = 1,
        Headphone = 2,
        Speaker = 3,
        USBDevice = 4,
        TV = 5,
        AVReceiver = 6,
        SoundBar = 7,
        Max = 8,
    };
}
namespace app::MoldedActionController::LostPartsUnit {
    enum Type {
        Head = 0,
        LeftArm = 1,
        RightArm = 2,
        LeftLeg = 3,
        RightLeg = 4,
        Body = 5,
        Blade = 6,
    };
}
namespace via::motion::TransitionData {
    enum StartType {
        Frame = 0,
        NormalizedTime = 1,
        SyncTime = 2,
        AutoSyncTime = 3,
        AutoSyncTimeSamePointCount = 4,
    };
}
namespace app::AdditionalTreeLayer {
    enum State {
        None = 0,
        Start = 1,
        EaseIn = 2,
        LoopCk = 3,
        ClipEnd = 4,
        EaseOut = 5,
        End = 6,
        Deactivate = 7,
    };
}
namespace via::network::error {
    enum CauseIdConverter {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
    };
}
namespace app::Em8000ScarController {
    enum PartType {
        LeftLeg = 0,
        RightLeg = 1,
        LeftArm = 2,
        RightArm = 3,
        Head = 4,
    };
}
namespace via::network::BattleReplay {
    enum Error {
        None = 0,
        Abort = 1,
        Command = 2,
        StartRound = 3,
        Finish = 4,
        Drain = 5,
    };
}
namespace via::render {
    enum ShallowWaterRenderingMode {
        Translucent = 0,
        TranslucentLighting = 1,
        GBuffer = 2,
        GBufferDepth = 3,
        UserMaterial = 4,
    };
}
namespace via::rebe {
    enum RebeDevFlags {
        General = 1,
        General2 = 2,
        HjmIgnore = 4,
        GcpExpire = 8,
        RebeExpire = 16,
        SessionKeyExpire = 32,
        RelayForceUDP = 64,
    };
}
namespace app::MotionGroupTable {
    enum GroupType {
        Other = 0,
        One = 1,
        LeftRight = 2,
        Strafe = 3,
    };
}
namespace app::CH8InteractSavePoint {
    enum HardSaveState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        Success = 3,
        NotSuccess = 4,
        Cancel = 5,
        Exit = 6,
    };
}
namespace via::motion::SecondaryRetarget {
    enum TransStretchMode {
        LengthRate = 0,
        Offset = 1,
        Motion = 2,
    };
}
namespace via::motion::IkHand2::EffectorInfo {
    enum OutputType {
        JointRayCast = 0,
        WeightRayCast = 1,
        Weight = 2,
    };
}
namespace app::CH9Em7900::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::Pl0000EventOnly {
    enum StampIndex {
        Recover = 0,
        Wet = 1,
    };
}
namespace app::Em3000 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Chapter3Battle1 = 2,
        Chapter3Battle1_Final = 3,
        Chapter3Battle2 = 4,
        _DO_NOT_USE_Chapter3Battle2_Final = 5,
        DebugWalk = 6,
        Em8000 = 7,
        Dev_Em8000Scissors = 8,
        Chapter3Battle1_Final_End = 9,
        Chapter3Battle2_Final_End = 10,
    };
}
namespace via::navigation::map::MapSegmentObject {
    enum ShapeCoordType {
        Local = 0,
        Global = 1,
    };
}
namespace via::os::websocket_client {
    enum Error {
        Unavailable = -3,
        NativeError = -2,
        InvalidParameter = -1,
        None = 0,
    };
}
namespace via::clr {
    enum ElementType {
        End = 0,
        Void = 1,
        Boolean = 2,
        Char = 3,
        I1 = 4,
        U1 = 5,
        I2 = 6,
        U2 = 7,
        I4 = 8,
        U4 = 9,
        I8 = 10,
        U8 = 11,
        R4 = 12,
        R8 = 13,
        String = 14,
        Ptr = 15,
        ByRef = 16,
        ValueType = 17,
        Class = 18,
        Var = 19,
        Array = 20,
        GenericInst = 21,
        TypedByRef = 22,
        I = 24,
        U = 25,
        FNPtr = 27,
        Object = 28,
        SzArray = 29,
        MVar = 30,
        RE_Reqd = 31,
        RE_Opt = 32,
        Internal = 33,
        Max = 34,
        Modifier = 64,
        Stencil = 65,
        Pinned = 69,
        Enum = 85,
        Any = 127,
    };
}
namespace via::audiorender {
    enum Channel_5oAmb {
        Channel_5oAmb_0 = 0,
        Channel_5oAmb_1 = 1,
        Channel_5oAmb_2 = 2,
        Channel_5oAmb_3 = 3,
        Channel_5oAmb_4 = 4,
        Channel_5oAmb_5 = 5,
        Channel_5oAmb_6 = 6,
        Channel_5oAmb_7 = 7,
        Channel_5oAmb_8 = 8,
        Channel_5oAmb_9 = 9,
        Channel_5oAmb_10 = 10,
        Channel_5oAmb_11 = 11,
        Channel_5oAmb_12 = 12,
        Channel_5oAmb_13 = 13,
        Channel_5oAmb_14 = 14,
        Channel_5oAmb_15 = 15,
        Channel_5oAmb_16 = 16,
        Channel_5oAmb_17 = 17,
        Channel_5oAmb_18 = 18,
        Channel_5oAmb_19 = 19,
        Channel_5oAmb_20 = 20,
        Channel_5oAmb_21 = 21,
        Channel_5oAmb_22 = 22,
        Channel_5oAmb_23 = 23,
        Channel_5oAmb_24 = 24,
        Channel_5oAmb_25 = 25,
        Channel_5oAmb_26 = 26,
        Channel_5oAmb_27 = 27,
        Channel_5oAmb_28 = 28,
        Channel_5oAmb_29 = 29,
        Channel_5oAmb_30 = 30,
        Channel_5oAmb_31 = 31,
        Channel_5oAmb_32 = 32,
        Channel_5oAmb_33 = 33,
        Channel_5oAmb_34 = 34,
        Channel_5oAmb_35 = 35,
        Channel_5oAmb_Max = 36,
    };
}
namespace app::Em3100::Em3100WwiseStateList {
    enum PropertyStealth {
        UnDiscovery = 0,
        Discovery = 1,
    };
}
namespace via::wwise {
    enum FadeType {
        None = 0,
        In = 1,
        Out = 2,
    };
}
namespace app::ObjectManager {
    enum ListType {
        EnemySave = 0,
        Item = 1,
        OtherObjectSave = 2,
        DoorPush = 3,
        InteractObjectBase = 4,
        TriggerInAction = 5,
        TriggerActionAreaHit = 6,
        MotionDestruct = 7,
        RigidBodyDestruct = 8,
        GimmickActiveControl = 9,
        ItemDropDestruct = 10,
        EnemyExistZone = 11,
        PlayerExistZone = 12,
        Em2000GrappleZone = 13,
        LookAtMarkerZone = 14,
        TimeLineKicker = 15,
        LightZoneDLC = 16,
        Candle = 17,
        _Max = 18,
    };
}
namespace via {
    enum DeviceOrientation {
        Portrait = 0,
        LandscapeLeft = 1,
        LandscapeRight = 2,
        PortraitUpsideDown = 3,
    };
}
namespace app::CardGameItem {
    enum ItemType {
        NoUse = 0,
        BetUp_1p = 10,
        BetUp_2 = 11,
        BetUp_2p = 12,
        BetUp_2x = 13,
        BetDown_1 = 15,
        BetDown_2 = 16,
        BetUp_21 = 20,
        Draw_2 = 30,
        Draw_3 = 31,
        Draw_4 = 32,
        Draw_5 = 33,
        Draw_6 = 34,
        Draw_7 = 35,
        Draw_2p = 36,
        Draw_3p = 37,
        Draw_4p = 38,
        Draw_5p = 39,
        Draw_6p = 40,
        Draw_7p = 41,
        PerfectDraw = 45,
        PerfectDraw_x = 46,
        PerfectDraw_p = 47,
        Gift = 50,
        SPChange = 51,
        SPChange_p = 52,
        Exchange = 53,
        Return = 54,
        Remove = 55,
        Destroy = 56,
        Destroy_p = 57,
        Destroy_pp = 58,
        Replace = 59,
        Desperation = 60,
        ShieldAssault = 61,
        ShieldAssault_p = 62,
        Happiness = 63,
        MindShift = 64,
        MindShift_p = 65,
        Desire = 66,
        Desire_p = 67,
        Escape = 68,
        DeadSilence = 69,
        Oblivion = 70,
        Conjuring = 71,
        BlackMagic = 72,
        Curse = 73,
        Goal_24 = 80,
        Goal_27 = 81,
        Goal_17 = 82,
    };
}
namespace via::render::Primitive {
    enum ShapeType {
        Sphere = 0,
        Tetrahedron = 1,
        Cube = 2,
        Cone = 3,
        Cylinder = 4,
        Max = 5,
    };
}
namespace app::CH8Em4100::Goal {
    enum CH8EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromRear = 8,
        IsTargetDamage = 9,
        IsAttackFromFrontWithDirective = 10,
        IsSlipFire = 11,
        AdditiveSensedAttack = 12,
    };
}
namespace app::Em8100Think {
    enum Mode {
        Idle = 0,
        Battle = 1,
    };
}
namespace hikako::WwiseVibrationDefineInfo {
    enum MotorIndex {
        Left = 0,
        Right = 1,
    };
}
namespace via::landscape {
    enum BakerBakeTextureType {
        Height = 0,
        Splat = 1,
        SDF = 2,
        Max = 3,
    };
}
namespace via::landscape {
    enum MeshDrawType {
        Solid = 0,
        AlphaTest = 1,
        Decal = 2,
        Forward = 3,
        Transparent = 4,
        Max = 5,
        Begin = 0,
    };
}
namespace app::Em8910Think {
    enum TentacleType {
        MoveTentacle = 0,
        AttackTentacle = 1,
    };
}
namespace app {
    enum PlayerVoiceAttackType {
        Normal = 0,
        Battle = 1,
    };
}
namespace app::Oilcan {
    enum OilcanSetType {
        Oilcan = 0,
        FakeBox = 1,
    };
}
namespace via::motion::IkDamageAction {
    enum CalculationAddRotation {
        SpecificJoint = 0,
        AllJoint = 1,
    };
}
namespace via::render {
    enum PreZForCullResolution {
        PreZForCullResolution_Recommended = 256,
        PreZForCullResolution_256x128 = 256,
        PreZForCullResolution_512x256 = 512,
    };
}
namespace via::navigation {
    enum NodePickPriority {
        Floor = 0,
        Wall = 1,
        FloorOnly = 2,
    };
}
namespace via::dynamics::ConeTwistConstraint::Initializer {
    enum PositionType {
        World = 0,
        Local = 1,
    };
}
namespace via::hid::camera::detail::PlayStationCameraLedTracker {
    enum UpdateTaskStatus {
        Wait = 0,
        Standup = 1,
        Run = 2,
        Shitdown = 3,
        Reboot = 4,
    };
}
namespace via::render {
    enum SamplerType {
        PointWrap = 0,
        PointClamp = 1,
        PointBorder = 2,
        PointMirror = 3,
        BilinearWrap = 4,
        BilinearClamp = 5,
        BilinearBorder = 6,
        BilinearMirror = 7,
        TrilinearWrap = 8,
        TrilinearClamp = 9,
        TrilinearBorder = 10,
        TrilinearMirror = 11,
        Anisotropic2Wrap = 12,
        Anisotropic2Clamp = 13,
        Anisotropic2Border = 14,
        Anisotropic2Mirror = 15,
        Anisotropic4Wrap = 16,
        Anisotropic4Clamp = 17,
        Anisotropic4Border = 18,
        Anisotropic4Mirror = 19,
        Anisotropic8Wrap = 20,
        Anisotropic8Clamp = 21,
        Anisotropic8Border = 22,
        Anisotropic8Mirror = 23,
        Anisotropic16Wrap = 24,
        Anisotropic16Clamp = 25,
        Anisotropic16Border = 26,
        Anisotropic16Mirror = 27,
        PointCompare = 28,
        LinearCompare = 29,
        Max = 30,
        AutomaticWrap = 31,
        AutomaticClamp = 32,
        AutomaticBorder = 33,
        AutomaticMirror = 34,
        SecondaryAutomaticWrap = 35,
        SecondaryAutomaticClamp = 36,
        SecondaryAutomaticBorder = 37,
        SecondaryAutomaticMirror = 38,
    };
}
namespace via::navigation::AIMapEffector {
    enum EdgeCreateType {
        Optimize = 0,
        Simple = 1,
        NonConvexCheck = 2,
        OptimizeLegacy = 3,
    };
}
namespace via::motion::tree::CalculateNode {
    enum Operation {
        Add = 0,
        Sub = 1,
        Mul = 2,
        Div = 3,
        Mod = 4,
        Pow = 5,
        Min = 6,
        Max = 7,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1Rest {
    enum LeaveStatus {
        Non = 0,
        Leave = 1,
        Arrive = 2,
    };
}
namespace via {
    enum GamePresetsGraphics {
        Default = 0,
        FrameRate = 1,
        Resolution = 2,
    };
}
namespace app::Em3001::Action::Grapple {
    enum Type {
        CommonTurn = 0,
        CommonHeadButt = 1,
        CommonKnee = 2,
        CommonThrowR = 3,
        CommonThrowL = 4,
    };
}
namespace app::CH8Em4400::CH8ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::clr {
    enum SystemType {
        None = 0,
        Object = 1,
        String = 2,
        Array = 3,
        Delegate = 4,
        MulticastDelegate = 5,
        Enum = 6,
        ValueType = 7,
        Exception = 8,
        Attribute = 9,
        Thread = 10,
        ThreadStart = 11,
        Type = 12,
        Byte = 13,
        SByte = 14,
        Char = 15,
        Int16 = 16,
        UInt16 = 17,
        Int32 = 18,
        UInt32 = 19,
        Int64 = 20,
        UInt64 = 21,
        Single = 22,
        Double = 23,
        IntPtr = 24,
        UIntPtr = 25,
        Boolean = 26,
        DateTime = 27,
        TimeSpan = 28,
        Guid = 29,
        TypedReference = 30,
        Void = 31,
        RuntimeType = 32,
        RuntimeAssembly = 33,
        RuntimeConstructorInfo = 34,
        RuntimeEventInfo = 35,
        RuntimeFieldInfo = 36,
        RuntimeMethodInfo = 37,
        RuntimeModule = 38,
        RuntimeParameterInfo = 39,
        RuntimePropertyInfo = 40,
        RuntimeTypeHandle = 41,
        RuntimeMethodHandle = 42,
        RuntimeFieldHandle = 43,
        Assembly = 44,
        MemberInfo = 45,
        ConstructorInfo = 46,
        EventInfo = 47,
        FieldInfo = 48,
        MethodInfo = 49,
        Module = 50,
        ParameterInfo = 51,
        PropertyInfo = 52,
        FlagsAttribute = 53,
        InvalidCastException = 54,
        IndexOutOfRangeException = 55,
        NullReferenceException = 56,
        DivideByZeroException = 57,
        OverflowException = 58,
        ArgumentOutOfRangeException = 59,
        ArgumentNullException = 60,
        ArgumentException = 61,
        ArithmeticException = 62,
        OutOfMemoryException = 63,
        FormatException = 64,
        RankException = 65,
        ArrayTypeMismatchException = 66,
        NotImplementedException = 67,
        NotSupportedException = 68,
        ObjectDisposedException = 69,
        InvalidOperationException = 70,
        NotFiniteNumberException = 71,
        StackOverflowException = 72,
        ThreadAbortException = 73,
        ThreadStartException = 74,
        ThreadStateException = 75,
        TypeAccessException = 76,
        TargetException = 77,
        TargetInvocationException = 78,
        InternalEnumerator = 79,
        IEnumerableT = 80,
        ICollectionT = 81,
        IListT = 82,
        IComparable = 83,
        IComparer = 84,
        AppDomain = 85,
        IComparerT = 86,
        IEnumerator = 87,
        IComparableT = 88,
        ListT = 89,
        NullableT = 90,
        DBNull = 91,
        Max = 92,
    };
}
namespace app::CH9EverywhereManager {
    enum MissionType {
        TimeAttack = 0,
    };
}
namespace app::AI::CH9AIWorldBlackBoard {
    enum SideType {
        FrontRight = 0,
        FrontLeft = 1,
        BackRight = 2,
        BackLeft = 3,
        Max = 4,
    };
}
namespace app::Em3000::Action::Grapple {
    enum Type {
        CommonTurn = 0,
        CommonHeadButt = 1,
        CommonKnee = 2,
        CommonShovelLift = 3,
        CommonThrowR = 4,
        CommonThrowL = 5,
        CommonGetOut = 6,
        CommonFinishNeck = 7,
        CommonMount = 8,
        Chapter3Battle1NeckSlash = 9,
        Chapter3Battle1NoNeckSlash = 10,
        Chapter3Battle1CutLeg = 11,
        Chapter3Battle1FinalClimax = 12,
        Chapter3Battle2FinalCutting = 13,
        Chapter3Battle2FinalCuttingBack = 14,
        Chapter3Battle2FinalShotGunGuard = 15,
        Em8000BattleOfSaw = 16,
        Em8000LegCut = 17,
        Em8000CuttingHead = 18,
        Em8000CuttingFinal = 19,
        CommonFinishMove = 20,
    };
}
namespace via::landscape {
    enum MapBakerBakeTarget {
        Mesh = 0,
        Road = 1,
        Ground = 2,
        HeightIntersect = 3,
        FoliageMap = 4,
        MeshUserAttribute = 5,
        Path = 6,
    };
}
namespace via::navigation::map {
    enum MapType {
        NavMesh = 0,
        WayPoint = 1,
        VolumeSpace = 2,
        NoMap = 3,
    };
}
namespace app::CH9MainMenu {
    enum SelectType {
        NewGame = 0,
        Continue = 1,
        LoadGame = 2,
        Quit = 3,
    };
}
namespace app::DLC1VideoCameraUI {
    enum ModeDef {
        Start = 0,
        NoiseAnim = 1,
        Close = 2,
        StartEnding = 3,
        CloseEnding = 4,
    };
}
namespace app::UITimer::StringConvertParam {
    enum IntegralEmptyDigitTypeDef {
        Nothing = 0,
        Zero = 1,
        Space = 2,
    };
}
namespace via::render::SSRControl {
    enum SSRControlType {
        Default = 0,
        Disable = 1,
        Spherical = 2,
        HighQuality = 3,
        ForwardWaterMesh = 4,
        FidelityFX_SSSR = 5,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
        W = 3,
    };
}
namespace app::Em8001::Em8001BattleDirective::ScissorsBattleParameter::AttackActionParameter {
    enum AttackActionType {
        None = 0,
        Zero_Front_Back = 1,
        Zero_Back_Swing = 2,
        Short_Scissors = 3,
        Short_Swing = 4,
        Short_PainStream = 5,
        Middle_Dash_Swing = 6,
        Middle_Dash_Scissors = 7,
        Middle_PainStream = 8,
        Combo_Swing = 9,
        Combo_SwingBack = 10,
        DamageCancel_Swing = 11,
    };
}
namespace via::wwise {
    enum ListenerBitMask {
        ListenerBitMask_0 = 1,
        ListenerBitMask_1 = 2,
        ListenerBitMask_2 = 4,
        ListenerBitMask_3 = 8,
        ListenerBitMask_4 = 16,
        ListenerBitMask_5 = 32,
        ListenerBitMask_6 = 64,
        ListenerBitMask_7 = 128,
    };
}
namespace app::CH8Em4500::Action {
    enum CH8ActionNo {
        Appear = 4,
        Idle = 5,
        AttackBeating = 6,
        ConsecutiveStrike = 7,
        BladeThrustStrike = 8,
        ScratchBigStrike = 9,
        Grapple = 10,
        StrikeToParry = 11,
        Jump = 12,
        QuickJump = 13,
        StrikeToCatch = 14,
        Swoon = 15,
        SpitSwoon = 16,
        Charge = 17,
        ModeChange = 18,
        Anger = 19,
        SlipAcid = 20,
        SlipFire = 21,
        ShortStrike = 22,
        ShortStrikeBack = 23,
        BackWalk = 24,
        BackWalkNextAction = 25,
        Threat = 26,
        ParryThreat = 27,
        CounterAttack = 28,
        ParryCounterAttack = 29,
        SpitBeam = 30,
        JumpUp = 31,
        JumpUpThreat = 32,
        JumpDown = 33,
        JumpDownAttack = 34,
        GuardCancellation = 35,
        Avoidance = 36,
        ContinuousJump = 37,
        ThinkChangeThreat = 38,
        ThreatOneShot = 39,
    };
}
namespace via::render::command::PS4Extention {
    enum ExtentionType {
        ExtentionType_4KCheckerBoardRenderingEnable = 0,
        ExtentionType_4KCheckerBoardRenderingEvenFrameEnable = 0,
        ExtentionType_4KCheckerBoardRenderingOddFrameEnable = 1,
        ExtentionType_TemporalAntialiasing4KCheckerBoardRenderingEvenFrameEnable = 2,
        ExtentionType_TemporalAntialiasing4KCheckerBoardRenderingOddFrameEnable = 3,
        ExtentionType_4KCheckerBoardRenderingDisable = 4,
        ExtentionType_AlphaUnroll_Enable = 5,
        ExtentionType_AlphaUnroll_Disable = 6,
        ExtentionType_PsInvoke_Enable = 7,
        ExtentionType_PsInvoke_Disable = 8,
        ExtentionType_ObjectID_Enable = 9,
        ExtentionType_ObjectID_Disable = 10,
        ExtentionType_ForcedResolve = 11,
        ExtentionType_Resummarized = 12,
        ExtentionType_ForceEQAAx4DepthTestEnable = 13,
        ExtentionType_ForceEQAAx4Disable = 14,
    };
}
namespace via::motion::IkLegSpine {
    enum DrawMode {
        DrawMode_Hidden = 0,
        DrawMode_Default = 1,
        DrawMode_Root = 2,
        DrawMode_Base = 3,
        DrawMode_Foot = 4,
        DrawMode_Spine = 5,
        DrawMode_Setting = 6,
        DrawMode_LegAxis = 7,
        DrawMode_ForeLeg = 8,
        DrawMode_BackLeg = 9,
        DrawMode_3BoneHeight = 10,
        DrawMode_Test = 11,
    };
}
namespace app::fsm::CH8BlackOut {
    enum RequestTypeEnum {
        None = 0,
        SceneJump = 1,
        ShadowPazzle = 2,
        FSMAction = 4,
        SceneActivater = 8,
        LoadGame = 16,
        Title = 32,
        Birthday = 64,
        VrModeChange = 128,
        VrTutorial = 256,
        ScenarioJump = 512,
        FSMAction_HideIcon = 1024,
    };
}
namespace via::render {
    enum UserAttributeAndCustomParamsFormat {
        Disable = 0,
        R11G11B10Float = 1,
        R16G16B16A16Float = 2,
        R32G32B32A32Float = 3,
    };
}
namespace app::CH9Em6700::Action::Idle {
    enum Type {
        Normal = 0,
        Homing = 1,
    };
}
namespace app::AIBeaconManager {
    enum Group {
        Vision = 0,
        Grapple = 1,
        Combat = 2,
    };
}
namespace via {
    enum SystemServiceAppParamIndex {
        Index0 = 0,
        Index1 = 1,
        Index2 = 2,
        Index3 = 3,
        Index4 = 4,
        Index5 = 5,
        Index6 = 6,
        Index7 = 7,
        Max = 8,
    };
}
namespace app::Em3102::Em3102Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Ghost = 1000,
    };
}
namespace app::CH8NightVisionTrigger {
    enum Mode {
        TriggerOnlyUseNightVision = 0,
        TriggerOnlyNoHasNightVision = 1,
    };
}
namespace app::EnemyActionController {
    enum DamageActionType {
        Damage = 0,
        BlownAway = 1,
        LostParts = 2,
        Resist = 3,
        PullAhead = 4,
        Dead = 5,
        SlipFire = 6,
        SlipAcid = 7,
    };
}
namespace via::render::layer::Overlay {
    enum Effect2DPlane {
        Plane0 = 1,
        Plane1 = 2,
        Plane2 = 3,
        Plane3 = 4,
        Max = 5,
    };
}
namespace app::CH8Em4100::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::FirstReNetMenu {
    enum Step {
        Main = 0,
        Yes = 1,
        No = 2,
        Detail = 3,
        Yes2 = 4,
    };
}
namespace app::GenomeCodexGUI {
    enum StepType {
        HP = 0,
        Scan = 1,
        Radar = 2,
    };
}
namespace app::Command {
    enum PlatformType {
        None = 0,
        PS4 = 1,
        XboxOne = 2,
        PC = 4,
        PSVitaRemotePlay = 8,
        PSVR = 16,
    };
}
namespace app::CH9Em6400::Action::Appeal {
    enum Type {
        Type00 = 0,
        Type01 = 1,
        Type02 = 2,
    };
}
namespace app::CH9KnuckleBullet {
    enum UpdateRno {
        Stomp = 0,
        AttackBack = 1,
        Sleep = 2,
    };
}
namespace via::os {
    enum SocketType {
        None = 0,
        Tcp = 1,
        Udp = 2,
        Ssl = 3,
        Dtls = 4,
        Dblowfish = 5,
    };
}
namespace via::simplewwise {
    enum DeviceTypeXB1 {
        None = 0,
        Main = 1,
        MergeToMain = 2,
        BGM = 3,
        Communication = 4,
        Personal = 5,
        DVR = 6,
        MicrodsoftSpatialSound = 7,
    };
}
namespace app {
    enum EnemyBaseActionNo {
        Idle = 0,
        Damage = 1,
        Dead = 2,
        Move = 3,
        BaseMax = 4,
        ValidRangeToInherit = 4,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraFormat {
        Unknown = 0,
        NoUse = 1,
        BaseYUV422 = 65536,
        BaseRAW16 = 65537,
        BaseRAW8 = 65538,
        ScaleYUV422 = 131072,
        ScaleY16 = 131073,
        ScaleY8 = 131074,
    };
}
namespace via::render {
    enum DsvDimension {
        Unknown = 0,
        Texture1d = 1,
        Texture1darray = 2,
        Texture2d = 3,
        Texture2darray = 4,
        Texture2dms = 5,
        Texture2dmsarray = 6,
    };
}
namespace via::behaviortree::action::NodeTimer {
    enum Unit {
        Second = 0,
        Frame = 1,
    };
}
namespace app::FBIKAttackController {
    enum AttackModeType {
        Rotate = 0,
        Target = 1,
    };
}
namespace via::hid::HDVibrationSource {
    enum TargetNode {
        Dual = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::fsm::requestMenuFromFsm {
    enum RequestTypeEnum {
        Open = 0,
        Close = 1,
    };
}
namespace via::gui {
    enum EditSceneDraw3DLayerType {
        Default = 0,
        ForceTransparent = 1,
    };
}
namespace via::navigation::Navigation {
    enum TraceLineOptimizeTiming {
        NodeUpdate = 0,
        Frame = 1,
        Start = 2,
    };
}
namespace app::GameManager {
    enum NetworkMode {
        None = 0,
        Wait = 1,
        StoreOpen = 2,
        BrowserOpenReNet = 3,
        ReNetSendResult = 4,
        ReNetGetNowOnSale = 5,
        ContextStart = 6,
    };
}
namespace app::MoldedActionController {
    enum SuspendStatusType {
        None = 0,
        Requested = 1,
        Moving = 2,
        Arrived = 3,
        RequestedAction = 4,
        Completed = 5,
    };
}
namespace via::gui {
    enum AssetLanguage {
        Invalid = -1,
        No0 = 0,
        No1 = 1,
        No2 = 2,
        No3 = 3,
        Max = 4,
    };
}
namespace app::Crusher {
    enum State {
        PowerOff = 0,
        InProduction = 1,
        StopProduction = 2,
    };
}
namespace app::InteractPadlock {
    enum PadlockState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        RotUp = 3,
        RotDown = 4,
        Success = 5,
        SuccessWait = 6,
        NotSuccess = 7,
        Close = 8,
        Exit = 9,
    };
}
namespace via::render::detail {
    enum EnabledPrimitiveProcessor {
        DOFBlend = 1,
        Lighting = 2,
        MieLighting = 4,
        ComputeShader = 8,
        Shadow = 16,
        StochasticTransparent = 32,
        Fluid2D = 64,
        DeferredLighting = 128,
        None = 0,
        All = 255,
    };
}
namespace via::network::MatchmakingProcComfirm {
    enum Phase {
        None = 0,
        Idle = 1,
        Search = 2,
        SearchWait = 3,
        SearchResult = 4,
        SearchInterval = 5,
        SyncTarget = 6,
        SyncTargetWait = 7,
        Modify = 8,
        Modify2 = 9,
        End = 10,
    };
}
namespace app::OverrideAction {
    enum Slot {
        Tension = 0,
        Action = 1,
        Area = 2,
        Dialogue = 3,
        HighArea = 4,
        HighAction = 5,
    };
}
namespace via::landscape {
    enum NodePlaneSurfaceType {
        Surface1x1 = 0,
        Surface2x2 = 1,
        Surface4x4 = 2,
        Surface8x8 = 3,
        Surface16x16 = 4,
    };
}
namespace app::OptionMenu {
    enum WalkSpeedIndex {
        Default = 0,
        Slowish = 1,
        Slow = 2,
    };
}
namespace via::gui {
    enum UserParamType {
        Int = 0,
        Float = 1,
        String = 2,
    };
}
namespace app::Em8001 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace via::motion::IkSpineConformGround {
    enum RayCastCallbackID {
        PartsHead = 256,
        PartsTail = 512,
        OrientHorizon = 4096,
        HeadHorizon = 4352,
        TailHorizon = 4608,
    };
}
namespace app::CardGameObjectElectricMachine {
    enum MeshPartsDef {
        MachineBody = 0,
        Bet_x0 = 1,
        Bet_x9 = 10,
        Bet_0x = 11,
        Bet_9x = 20,
        Meter_0 = 21,
        Meter_9 = 30,
    };
}
namespace via::motion::IkLegSpine {
    enum FootLockMode {
        Auto = 0,
        SemiAuto = 1,
    };
}
namespace app::fsm::CH8LiftSet {
    enum SetType {
        SkipInterval = 0,
    };
}
namespace via::hid {
    enum GamePlayerIndex {
        Player1P = 0,
        Player2P = 1,
        Player3P = 2,
        Player4P = 3,
        Player5P = 4,
        Player6P = 5,
        Player7P = 6,
        Player8P = 7,
        Player9P = 8,
        Player10P = 9,
        Player11P = 10,
        Player12P = 11,
        Player13P = 12,
        Player14P = 13,
        Player15P = 14,
        Player16P = 15,
        Max = 16,
        Invalid = -1,
    };
}
namespace app::InteractDetailSearch {
    enum SearchEventRotAxis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace via::hid {
    enum VibrationOutputMotor {
        Motor0 = 0,
        Motor1 = 1,
        Motor2 = 2,
        Motor3 = 3,
        All = 128,
        Invalid = -1,
    };
}
namespace via::motion::IkLeg {
    enum RayCastCallbackID {
        Left = 1,
        Right = 2,
        Heal = 4,
        LeftHeal = 5,
        RightHeal = 6,
        Detail = 8,
        LeftDetail = 9,
        RightDetail = 10,
        LeftHealDetail = 13,
        RightHealDetail = 30,
    };
}
namespace via::vr {
    enum VrHandRole {
        Left = 0,
        Right = 1,
    };
}
namespace app::CardGameKillCountProduction::KillCountProductionSoundController {
    enum Type {
        BlackOut = 0,
        CountDown = 1,
    };
}
namespace app::CH9EverywhereManager {
    enum MissionNo {
        Mission01 = 0,
        Mission02 = 1,
        Mission03 = 2,
        Mission04 = 3,
        Mission05 = 4,
        Mission06 = 5,
        Mission07 = 6,
        Mission08 = 7,
        Mission09 = 8,
        Mission10 = 9,
        Max = 10,
        None = 11,
    };
}
namespace app::DetailSearchGUI {
    enum State {
        TitleAndExp = 0,
        ExpOnly = 1,
        Nothing = 2,
        Highlight = 3,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1DestroyTable {
    enum DestroyTableStatus {
        Non = 0,
        GotoTable = 1,
        CanDestroyTable = 2,
        DestroyTable = 3,
        DestroyTableEnd = 4,
    };
}
namespace via::hid {
    enum GestureFingerNumber {
        One = 0,
        Two = 1,
        Three = 2,
    };
}
namespace app {
    enum GroupFlag {
        Player = 1,
        Enemy = 2,
        Item = 8,
        Weapon = 4,
        Prop = 16,
        Etc = 32,
        Vfx = 64,
        Camera = 128,
        ActionPoint = 256,
        EventChara = 512,
        Souko = 1024,
    };
}
namespace app::VrGui {
    enum TargetTypeDef {
        ActiveCamera = 0,
        ActivePlayer = 1,
        Specify = 2,
    };
}
namespace app::fsm::AreaHitTest {
    enum TargetParam {
        Player = 0,
        Enemy = 1,
    };
}
namespace via::render::MaterialParam {
    enum MaterialParamType {
        Unkown = 0,
        Float4 = 1,
        Float = 2,
        Texture = 3,
        ByteBuffer = 4,
    };
}
namespace via::render {
    enum VFXResolutionTexType {
        R16G16B16A16 = 0,
        R10G10B10A2 = 1,
    };
}
namespace app::FirstLanguageGUI {
    enum ModeDef {
        First = 0,
        Normal = 1,
        Back = 2,
    };
}
namespace app::CH9Em7800::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace via::motion::FullBodyIKRig {
    enum ActiveLevel {
        Idle = 0,
        SmoothingToIdle = 1,
        InitSmoothing = 2,
        Active = 3,
    };
}
namespace app::FadeControl {
    enum FadeRequestEnum {
        None = 0,
        FadeIn = 1,
        FadeOut = 2,
    };
}
namespace via::navigation::NodeQueryInfo {
    enum RegionType {
        None = 0,
        Sphere = 1,
        AABB = 2,
        OBB = 3,
        Capsule = 4,
        Cylinder = 5,
        LineSegment = 6,
        Collidable = 7,
    };
}
namespace via::render {
    enum ShaderStage {
        Vertex = 0,
        Hull = 1,
        Domain = 2,
        Geometry = 3,
        Pixel = 4,
        Compute = 5,
        Max = 6,
    };
}
namespace via::movie {
    enum DecodeLayer {
        Common = 0,
        Overlay = 1,
    };
}
namespace app::Em3001FirstStamp {
    enum TimelineFrame {
        Default = 0,
        Clean = 1,
        Dirty = 2,
    };
}
namespace app::OptionMenu {
    enum RecordScreenType {
        Pause = 0,
        Ending = 1,
    };
}
namespace via::hansoft {
    enum HansoftResult {
        None = 0,
        Doing = 1,
        Success = 2,
        InvalidBuild = 3,
        PayloadEmpty = 4,
        InvalidRecv = 5,
        InvalidProjectName = 6,
        InvalidLicenseId = 7,
        InvalidEnvironmentType = 8,
        InvalidDataMode = 9,
        ServerConnectionFailed = 10,
        ServerSendFailed = 11,
        RequestFailed = 12,
    };
}
namespace app::InteractNumberLock {
    enum NumberLockState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        Success = 3,
        SuccessWait = 4,
        NotSuccess = 5,
        Close = 6,
        Exit = 7,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum MainState {
        DEFAULT = 0,
        FADE_IN_BONUS = 1,
        FADE_IN_LIMIT = 2,
    };
}
namespace app::PharmacyDictionary {
    enum Step {
        News = 0,
        Dictionary = 1,
    };
}
namespace via::audiorender {
    enum RequestBoolean {
        False = 0,
        True = 1,
    };
}
namespace via::landscape {
    enum ShaderType {
        Auto = 0,
        Near = 1,
        Far = 2,
        Max = 3,
    };
}
namespace app::PCSystemData {
    enum DisplayModeCol {
        Resolution = 0,
        Refreshrate = 1,
    };
}
namespace app::Nightmare {
    enum SpawnInfoTagID {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
    };
}
namespace via::areamap::test::DotProductSelf {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace app::CharacterDefine {
    enum Type {
        Player = 0,
        Enemy = 1,
        Npc = 2,
    };
}
namespace via::navigation::algorithm::MapGraphAstar {
    enum SearchPhase {
        SearchPhase_1st = 0,
        SearchPhase_2nd = 1,
    };
}
namespace via::motion::IkTrain {
    enum ControlType {
        AutoPassTargetPosition = 0,
        HeadTargetPosition = 1,
    };
}
namespace via::motion::IkLeg2 {
    enum CenterDistance {
        OriginalLeg = 0,
        LeachLeg = 1,
    };
}
namespace app::Bomb {
    enum ParentType {
        None = 0,
        Transform = 1,
        Joint = 2,
    };
}
namespace app::Em8000::Action::Em8000ComboAttack {
    enum Type {
        INVALID = -1,
        None = 0,
        ComboAttack = 1,
        ComboAttackBack = 2,
        SUM = 3,
    };
}
namespace app::CH9MoldedActionController {
    enum SuspendStatusType {
        None = 0,
        Requested = 1,
        Moving = 2,
        Arrived = 3,
        RequestedAction = 4,
        Completed = 5,
    };
}
namespace app::OptionMenu {
    enum RightPanelState {
        DEFAULT = 0,
        EXTRAGAME = 1,
        RENET = 2,
        CROSSSAVE = 3,
    };
}
namespace app::dev1lab::AnalysisLogTransmitter::HttpRequest {
    enum Phase {
        None = 0,
        Request = 1,
        ReceiveResponseHeader = 2,
        ReceiveResponseBody = 3,
        RequestSucceed = 4,
        RequestFaild = 5,
        Complate = 6,
        Finalize = 7,
    };
}
namespace app::HitStopController {
    enum HitStopState {
        None = 0,
        CheckHit = 1,
        SlowDown = 2,
        Stop = 3,
        End = 4,
    };
}
namespace via::render::detail {
    enum CustomFilterTiming {
        Default = 0,
        BeforePostEffectLayer = 1,
        AfterCBRResolved = 2,
    };
}
namespace app::PlayerCamera {
    enum MouseRotationSensitivityType {
        Sensitivity0 = 0,
        Sensitivity1 = 1,
        Sensitivity2 = 2,
        Sensitivity3 = 3,
        Sensitivity4 = 4,
        Sensitivity5 = 5,
        Sensitivity6 = 6,
        Sensitivity7 = 7,
        Sensitivity8 = 8,
        Sensitivity9 = 9,
        Sensitivity10 = 10,
        Sensitivity11 = 11,
        Sensitivity12 = 12,
        Sensitivity13 = 13,
        Sensitivity14 = 14,
        Sensitivity15 = 15,
        Sensitivity16 = 16,
        Sensitivity17 = 17,
        Sensitivity18 = 18,
        Sensitivity19 = 19,
        Sensitivity20 = 20,
        Sensitivity21 = 21,
        Sensitivity22 = 22,
        Sensitivity23 = 23,
        Sensitivity24 = 24,
        Sensitivity25 = 25,
        Sensitivity26 = 26,
        Sensitivity27 = 27,
        Sensitivity28 = 28,
        Sensitivity29 = 29,
        Sensitivity30 = 30,
        Sensitivity31 = 31,
        Sensitivity32 = 32,
        Sensitivity33 = 33,
        Sensitivity34 = 34,
        Sensitivity35 = 35,
        Sensitivity36 = 36,
        Sensitivity37 = 37,
        Sensitivity38 = 38,
        Sensitivity39 = 39,
        Sensitivity40 = 40,
    };
}
namespace via::octree {
    enum GridDirection {
        All = 0,
        NorthGrid = 1,
        SouthGrid = 2,
        WestGrid = 3,
        EastGrid = 4,
        UpGrid = 5,
        DownGrid = 6,
    };
}
namespace app::Em3002::Goal {
    enum AppearMessageStatus {
        Non = 0,
        DiscoveryHearing = 1,
        DiscoveryVision = 2,
    };
}
namespace app::Em4400::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Return = 1,
        Wander = 2,
        Fixed = 3,
        Wait = 4,
        Elevator = 5,
        Discovery = 6,
        UnDiscovery = 7,
        IdleLostTarget = 8,
        Idle = 9,
        Follow = 10,
        Grapple = 11,
        MountTry = 12,
        Rush = 13,
        Splash = 14,
        BreathSimple = 15,
        BreathForce = 16,
        Breath = 17,
        FixedBreath = 18,
        Door = 19,
        DoorOpen = 20,
        DoorClose = 21,
        Move = 22,
        AppearAction = 23,
        IdleAction = 24,
        ElevatorAction = 25,
        RushAction = 26,
        SplashAction = 27,
        BreathSimpleAction = 28,
        BreathForceAction = 29,
        BreathAction = 30,
        MountTryAction = 31,
        GrappleAction = 32,
        Generate = 33,
        Escape = 34,
        EasyWait = 35,
        AllFoursSmash = 36,
        Kneel = 37,
    };
}
namespace app::CraftBenchUIAsset {
    enum StackPanelState {
        DISABLE = 0,
        SIZE1 = 1,
        SIZE2 = 2,
    };
}
namespace app::Em3001::Action::Appear {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
    };
}
namespace via::render {
    enum InterleaveConditionType {
        OR = 0,
        AND = 1,
    };
}
namespace via::render::VolumeDecal {
    enum ProjectionShape {
        Obb = 0,
        Pyramid = 2,
        PyramidY = 3,
        Max = 4,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1Final {
    enum GetOffCarStatus {
        Non = 0,
        GotoGetOffCar = 1,
        CanGetOffCar = 2,
        GetOffCarEnd = 3,
    };
}
namespace via::behaviortree::TreeNodeData {
    enum NodeAttribute {
        IsEnabled = 1,
        IsRestartable = 2,
        HasReferenceTree = 4,
        BubblesChildEnd = 8,
        SelectOnce = 16,
        IsFSMNode = 32,
        TraverseToLeaf = 64,
    };
}
namespace via::detail {
    enum ModalDialogResult {
        Ok = 0,
        Busy = 1,
        Invalid = 2,
    };
}
namespace via::gui {
    enum TypingCondition {
        Update = 0,
        Pause = 1,
        End = 2,
        Unknown = 3,
    };
}
namespace via::gui {
    enum LetterAlignment {
        LeftTop = 0,
        LeftCenter = 4,
        LeftBottom = 8,
        LeftBaseline = 12,
        CenterTop = 1,
        CenterCenter = 5,
        CenterBottom = 9,
        CenterBaseline = 13,
        RightTop = 2,
        RightCenter = 6,
        RightBottom = 10,
        RightBaseline = 14,
    };
}
namespace app::CH8Em4200::Goal {
    enum CH8EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromFrontWithDirective = 8,
        IsTargetDamage = 9,
        IsOccluded = 10,
        IsTargetOnLadder = 11,
        CanBreathOcclude = 12,
        IsStandOnSlope = 13,
        AdditiveSensedAttack = 14,
    };
}
namespace via::physics {
    enum MaskType {
        AND = 0,
        NAND = 1,
        Default = 2,
        Max = 3,
    };
}
namespace via::render::ShadowQualityControl {
    enum ShadowQualityType {
        Default = 0,
        Fast = 1,
    };
}
namespace app::CH9Em6400::Action::Damage {
    enum Type {
        None = 0,
        MidHeadF = 1,
        MidHeadFR = 2,
        MidHeadFL = 3,
        MidHeadB = 4,
        MidHeadR = 5,
        MidHeadL = 6,
        MidBodyF = 7,
        MidBodyB = 8,
        MidBodyR = 9,
        MidBodyL = 10,
        MidLegR = 11,
        MidLegL = 12,
        MidHeadFRun = 13,
        MidHeadBRun = 14,
        MidHeadRRun = 15,
        MidHeadLRun = 16,
        MidBodyFRun = 17,
        MidBodyBRun = 18,
        MidBodyRRun = 19,
        MidBodyLRun = 20,
        MidLegRRun = 21,
        MidLegLRun = 22,
        CommonKneeDownF = 23,
        CommonKneeDownB = 24,
        FaintF = 25,
        FaintB = 26,
        BlowKneeDownF = 27,
        BlowKneeDownB = 28,
        KnockDown = 29,
    };
}
namespace app::CH9EverywhereData {
    enum Type {
        Item = 0,
        Weapon = 1,
    };
}
namespace via::network {
    enum RequestId {
        ContextStart = 257,
        P2pConnect = 513,
        SessionCreate = 769,
        SessionSearchByFilter = 770,
        SessionSearchByFriend = 771,
        SessionSearchByUniqueId = 772,
        SessionGetInfo = 780,
        SessionJoin = 773,
        SessionKick = 774,
        SessionInvite = 775,
        SessionSetSearchKey = 776,
        SessionSetCustomProperty = 777,
        SessionSetPrivate = 778,
        SessionSetClose = 779,
        SessionInviteByUniqueId = 781,
        RankingRegister = 1025,
        RankingGetScoreByRange = 1026,
        RankingGetScoreByUniqueId = 1027,
        RankingGetScoreByFriend = 1028,
        AchievementsWrite = 1281,
        AchievementsRead = 1282,
        AchievementsUnlock = 1283,
        AchievementsGetInfo = 1284,
        StorageGetInfo = 1537,
        StorageUnlink = 1538,
        StorageOpen = 1539,
        StorageWrite = 1540,
        StorageRead = 1541,
        InvitationJoin = 2050,
        IdConverterGetNickname = 2816,
        UtilityShowProfile = 3073,
    };
}
namespace app::vr::VrManager {
    enum FadeRequestType {
        None = 0,
        PlayerCamera = 1,
        Event = 2,
    };
}
namespace app::vr::VrManager {
    enum RequestFlowType {
        None = 0,
        FirstBoot = 1,
        SecondBoot = 2,
        TitleOption = 3,
        Ingame = 4,
        FirstBootTutorial = 5,
        AmbassadorTrial = 6,
    };
}
namespace app::CH8OperatorManager2 {
    enum ResultTable {
        None = 0,
        Runnning = 1,
        Filure = 2,
        IsEnd = 3,
    };
}
namespace app::vr::VrTutorialOpenFlow {
    enum Phase {
        Cutin = 0,
        Yes = 1,
        No = 2,
        End = 3,
    };
}
namespace app::fsm::Em9900ManagerActionBase {
    enum ActionType {
        None = 0,
        Start = 1,
        A = 2,
        B = 3,
        C = 4,
        D = 5,
        End = 6,
    };
}
namespace app::fsm::HandLightBlink {
    enum ActionType {
        None = 0,
        AutoBlinkEnable = 1,
        AutoBlinkDisable = 2,
        PlayBlink = 3,
        StopBlink = 4,
    };
}
namespace app::TitleSubMenu {
    enum CameraMotionID {
        VoiceRecorder_to_SaveSlot = 0,
        SaveSlot_to_VoiceRecorder = 1,
        VoiceRecorder_to_Option = 2,
        Optin_to_VoiceRecorder = 3,
        VoiceRecorder = 4,
    };
}
namespace app::TestMovement {
    enum MovementType {
        PositionLine = 0,
        PositionRoll = 1,
        RotationLine = 2,
        RotationRoll = 3,
    };
}
namespace app::Em3000::Action::TurnAttack {
    enum Type {
        Forward = 0,
        Right = 1,
        Left = 2,
        BackR = 3,
        BackL = 4,
    };
}
namespace app::CarInGarage {
    enum PushCharaControllerType {
        None = 0,
        Forward = 1,
        Reverse = 2,
    };
}
namespace via::motion::LowerBodyRetarget {
    enum TransformMode {
        Default = 0,
        None = 1,
    };
}
namespace app::Havok::RagdollCharacter {
    enum PartsId {
        Hip = 0,
        Push_Hip = 1,
        R_Thigh = 2,
        R_Shin = 3,
        R_Foot = 4,
        L_Thigh = 5,
        L_Shin = 6,
        L_Foot = 7,
        Push_Waist = 8,
        Waist = 9,
        Chest = 10,
        R_Shoulder = 11,
        R_UpperArm = 12,
        R_Forearm = 13,
        R_Hand = 14,
        L_Shoulder = 15,
        L_UpperArm = 16,
        L_Forearm = 17,
        L_Hand = 18,
        Neck = 19,
        Head = 20,
    };
}
namespace via::audiorender {
    enum OutputLogType {
        Default = 1,
        NSWSaturation = 2,
        ExternalSource = 4,
        All = 4294967295,
    };
}
namespace app::Em8001::Action::OpenDoor {
    enum Type {
        Swing_Front = 0,
        Swing_Back = 1,
    };
}
namespace via::hid {
    enum KeyboardSpecialKey {
        None = 0,
        Shift = 16,
        Control = 17,
        Menu = 18,
    };
}
namespace app::CH8PlayerOrder::IgnoreInputReturnFromMenu {
    enum IgnoreInputTimeType {
        Frame = 0,
        Second = 1,
    };
}
namespace app::AI::AINavigationHelper {
    enum ResultType {
        None = 0,
        Update = 1,
        Fail = 2,
        Complete = 3,
    };
}
namespace app::fsm::CH9InGameContentAction {
    enum OperationTypeEnum {
        ContentStart = 0,
        ContentEnd = 1,
    };
}
namespace via::physics::StaticCompoundShape::Instance {
    enum Type {
        Additive = 0,
        Subtractive = 1,
    };
}
namespace app::FileMenu_FileList {
    enum ProcResultDef {
        Cancel = 0,
        Decide = 1,
    };
}
namespace app::Em3001::Action::Walk {
    enum Type {
        Normal = 0,
        Acid = 1,
        TNormal = 2,
    };
}
namespace app::SaveDataManager {
    enum LoadingState {
        None = 0,
        SaveDataLoading = 1,
        RootClear = 2,
        RootLoading = 3,
        RootLoading_2nd = 4,
        Exit = 5,
    };
}
namespace via {
    enum AreaQueryCategory {
        Unknown = 0,
        AreaItem = 1,
        Position = 2,
        GameObject = 4,
        AreaRegion = 8,
        Any = 255,
    };
}
namespace via::dynamics {
    enum VehicleGear {
        Reverse = 0,
        Neutral = 1,
        First = 2,
        Second = 3,
        Third = 4,
        Fourth = 5,
        Fifth = 6,
        Sixth = 7,
    };
}
namespace app::CH8Em4090Grapple {
    enum AttackType {
        Left = 0,
        Right = 1,
    };
}
namespace app::EventActionTask {
    enum PriorityType {
        None = 0,
        InteractEventLow = 1,
        Grapple = 2,
        InteractEventHigh = 3,
        Ingame = 4,
    };
}
namespace app::CH8Em4500::Action::CH8Jump {
    enum Jumptype {
        None = -1,
        Normal = 0,
    };
}
namespace app::Em3600::Action::Grapple {
    enum Type {
        ThrowF = 0,
        Mount = 1,
        MountFourLeg = 2,
        Cell = 3,
        Choke = 4,
        Drop = 5,
        Floor = 6,
        Floor_v1 = 7,
        Window = 8,
    };
}
namespace via::motion::Motion {
    enum IntervalUpdateOption {
        None = 0,
        ApplyAllJoints = 1,
        UpdateRootAndApplyRoot = 2,
        UpdateRootAndApplyAllJoints = 3,
    };
}
namespace via::render::layer::StochasticTransparent {
    enum Segment {
        Preprocess = 0,
        ZPrePass = 1,
        UpdateBuffer = 2,
        Composite = 3,
    };
}
namespace app::Em8001::Message {
    enum Priority {
        Low = 0,
        Middle = 1,
        High = 2,
    };
}
namespace app::Em3600::Action::Hide {
    enum Type {
        FirePlace_1F = 0,
        Floor_1F = 1,
        SmallRoomCeiling_1F = 2,
        GHNearbyDoor_1F = 3,
        GHWindow_1F = 4,
        GHBackGround_1F = 5,
        StairWindow_1_5F = 6,
        Ceiling_2F = 7,
        FirePlace_2F = 8,
        GHRoofHole_2F = 9,
        Bridge_2F = 10,
        StairRoomCeiling_2F = 11,
        GHTopofDoor_2F = 12,
    };
}
namespace app::ItemExplanation {
    enum ItemTextType {
        Name = 0,
        Explanation = 1,
    };
}
namespace app::CH8SettingSkill_Item {
    enum Process {
        Idle = 0,
        DLC_Init = 1,
        DLC_update = 2,
        DLC_update_1 = 3,
        End = 4,
    };
}
namespace app::WetPlayer {
    enum Setting {
        Normal = 0,
        Wet = 1,
    };
}
namespace hikako::ActivityManager {
    enum ProgressActivityType {
        Objective_01 = 0,
        Objective_FF01 = 1,
        Objective_02 = 2,
        Objective_FF02 = 3,
        Objective_03 = 4,
        Objective_FF03 = 5,
        Objective_04 = 6,
        Objective_FF04 = 7,
        Objective_05 = 8,
        Objective_74 = 9,
        Objective_08 = 10,
        Objective_09 = 11,
        Max = 12,
    };
}
namespace via::geometry::GeometryBrush {
    enum BooleanState {
        No = 0,
        ReadyNo = 1,
        ReadyYes = 2,
        Yes = 3,
    };
}
namespace via::motion::IkDog {
    enum RayCastCallbackID {
        BackLeft = 1,
        BackRight = 2,
        ForeLeft = 4,
        ForeRight = 8,
        Detail = 16,
        BackLeftDetail = 17,
        BackRightDetail = 18,
        ForeLeftDetail = 20,
        ForeRightDetail = 24,
        Base = 32,
        BackLeftBase = 33,
        BackRightBase = 34,
        ForeLeftBase = 36,
        ForeRightBase = 40,
    };
}
namespace app::CH8Em4000BladeController {
    enum Type {
        Default = 0,
        Slash = 1,
        SlashTry = 2,
        Grapple = 3,
        Pursuit = 4,
        None = -1,
    };
}
namespace via::render::LDRColorDeficiencySimulation {
    enum DeficiencyType {
        Normal = 0,
        Protanopia = 1,
        Deuteranopia = 2,
        Tritanopia = 3,
        Achromatopsia = 4,
        Max = 5,
    };
}
namespace via::navigation {
    enum PathObjectOperatorType {
        PathObjectOperator_NavigationTargetStraight = 0,
        PathObjectOperator_NavMeshStraight = 1,
        PathObjectOperator_NavMeshMapBoundary = 2,
        PathObjectOperator_NavMeshWall = 3,
        PathObjectOperator_NavigationVolumeSpaceTargetStraight = 4,
        PathObjectOperator_NavigationVolumeSpace = 5,
        PathObjectOperator_NavigationWaypointTargetStraight = 6,
        PathObjectOperator_NavigationWaypoint = 7,
        PathObjectOperatorNum = 8,
    };
}
namespace app::CH8Em4200::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::ActiveControlBase {
    enum EventTypeEnum {
        None = 0,
        Main = 1,
    };
}
namespace via {
    enum InterpolationType {
        Unknown = 0,
        Discrete = 1,
        Linear = 2,
        Event = 3,
        Slerp = 4,
        Hermite = 5,
        AutoHermite = 6,
        Bezier = 7,
        AutoBezier = 8,
        OffsetFrame = 9,
        OffsetSec = 10,
        PassEvent = 11,
        Bezier3D = 12,
        Range = 13,
        DiscreteToEnd = 14,
    };
}
namespace app::Em3001Order::Appear {
    enum Type {
        None = 0,
        Dummy = 1,
        AppearF = 2,
        AppearR = 3,
        AppearL = 4,
    };
}
namespace via::navigation::algorithm::MapGraphAstar {
    enum TryPossibilityType {
        NoTry = 0,
        Node = 1,
        Path = 2,
    };
}
namespace via::network::error {
    enum MethodIdConverter {
        GetNickname = 0,
    };
}
namespace app::CH8ChangeFogParamProxy {
    enum REQUEST_MODE {
        NONE = 0,
        NORMAL = 1,
        NIGHT_VISION = 2,
    };
}
namespace via::render {
    enum LightMask {
        Default = 0,
        Beauty = 1,
    };
}
namespace app::CH8Em4000::CH8ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::render::LightVolumeDecal {
    enum DecalTextureSize {
        DecalTextureSize_64 = 64,
        DecalTextureSize_128 = 128,
        DecalTextureSize_256 = 256,
        DecalTextureSize_512 = 512,
        DecalTextureSize_1K = 1024,
    };
}
namespace via::motion::IkMultiBoneData {
    enum AttributeFlags {
        IsUseMotionPose = 1,
    };
}
namespace via {
    enum HardwareServiceThermalState {
        Normal = 0,
        LittleHigh = 1,
        High = 2,
        Serious = 3,
        Critical = 4,
        Emergency = 5,
        Shutdown = 6,
    };
}
namespace app::CH9Em7700Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace app::Cp7CardGameReward {
    enum Type {
        OpenItem = 0,
        AddDrawNum = 1,
        AddBetNum = 2,
        Everywhere = 3,
    };
}
namespace app::TitleExtraContentGUI {
    enum State {
        EXTRAGAME1 = 0,
        EXTRAGAME2 = 1,
        DLC1 = 2,
        DLC2 = 3,
        DLC3 = 4,
        DISABLE = 5,
    };
}
namespace app::Em4100::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4200ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
    };
}
namespace app::Em3600::Action::Fall {
    enum Type {
        Normal = 0,
        TwoLegJumpOff = 1,
        GenerateCancelWall = 2,
        GenerateCancelCell = 3,
        FourLegRevFall = 4,
    };
}
namespace app::OptionMenu {
    enum VrFrontGuideIndex {
        On = 0,
        Off = 1,
    };
}
namespace via::motion::IkLeg2 {
    enum CenterAdjust {
        None = 0,
        CogCtrl = 1,
        ToRoot = 2,
    };
}
namespace via::landscape::beta {
    enum LodDebugTypeEnum {
        None = 0,
        LodLevel = 1,
        NodeUV = 2,
        PatchUV = 3,
        CrackInfo = 4,
        Max = 5,
    };
}
namespace app::Em4200::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::FadeControl {
    enum FadeStatusEnum {
        OffBlack = 0,
        OnBlack = 1,
    };
}
namespace app::CH9SaveMenu {
    enum StepType {
        Init = 0,
        Main = 1,
        Load = 2,
        WaitLoad = 3,
        LoadFailed = 4,
        Save = 5,
        WaitSave = 6,
        SaveFull = 7,
    };
}
namespace app::fsm::CH8ElevatorDoor {
    enum ActionType {
        Open = 0,
        Close = 1,
    };
}
namespace via::telemetry::TelemetryManager {
    enum EventType {
        Ready = 0,
        Activated = 0,
        Deactivated = 1,
        AsyncCompleted = 2,
    };
}
namespace app::Em5400Order::Appear {
    enum Type {
        Idle = 0,
        Ground = 1,
        Appear = 2,
        Generate = 3,
        GenerateS = 4,
        GenerateM = 5,
        GenerateL = 6,
    };
}
namespace app::GameManager {
    enum RankPointType {
        PlGetItem = 0,
        EmAttackFailed = 1,
        PlDying = 2,
        PlRetry = 3,
        EmLostHead = 4,
        EmHeadShot = 5,
    };
}
namespace via::render::VolumetricFogControl {
    enum ShadowQuality {
        Auto = 0,
        High = 1,
        Middle = 2,
    };
}
namespace via::os::websocket_client {
    enum MessageType {
        Binary = 0,
        Text = 1,
    };
}
namespace via::render {
    enum LightBakeOption {
        None = 0,
        Direct = 1,
        Indirect = 2,
        All = 3,
    };
}
namespace app::CH9Em6400::Action::AppealAwaken {
    enum Type {
    };
}
namespace app::GameManager {
    enum ChapterType {
        BootLogo = 0,
        FirstMenu = 1,
        FirstPlayable = 2,
        Title = 3,
        NormalStage = 4,
        FoundFootage = 5,
        StandbyStage = 6,
        OpeningCar = 7,
        OpeningMovie = 8,
        EndingMovie = 9,
        VRTutorial = 10,
    };
}
namespace app::NowOnSaleMenu {
    enum Step {
        Main = 0,
        Yes = 1,
        No = 2,
        Detail = 3,
        Exit = 4,
    };
}
namespace via {
    enum EffectPerformanceLevel {
        Low = 0,
        Normal = 1,
        Caution = 2,
        Middle = 3,
        High = 4,
    };
}
namespace app::Em3600Order::Appear {
    enum Type {
        TwoLegIdle = 0,
        FourLegIdle = 1,
        Floor = 2,
        Wall = 3,
        Cell = 4,
    };
}
namespace app::CH9Em7700ActionController {
    enum DestinationType {
        ChangeThink = 0,
        SelfKill = 1,
    };
}
namespace app::Achievement {
    enum VariablesTagID {
        CountOfKilledByKnife = 0,
        CountOfKilledByAttachBomb = 1,
        CountOfOpenItemBox = 2,
        CountOfUsedCure = 3,
        CountOfRepulsedInTheAir = 4,
        CountOfRepulsedMother = 5,
        CountOfSucceededGuards = 6,
        CountOfCloseDoors = 7,
        CountOfBrokenInsectDoorsByKnife = 8,
        CountOfTwoKilledAtOneShot = 9,
        CountOfAvoidBySquat = 10,
        CountOfGetItemByDetailSearch = 11,
        CountOfUsedEyeLotion = 12,
        CountOfSetupMissShadowPuzzle = 13,
        CountOfCoins = 14,
        CountOfCoinsForHard = 15,
        CountOfFiles = 16,
        CountOfPicking = 17,
        CountOfStabilizers = 18,
        CountOfSteroids = 19,
        CollectOfFormulated = 20,
        CollectOfClearedFF = 21,
        StatsGetFuseCHP1 = 22,
        StatsGetFuseCHP4 = 23,
        StatsGetFuseFF = 24,
        StatsGetShotgunDummy = 25,
        StatsGetShotgunWp1039 = 26,
        StatsGetShotgunWp1030 = 27,
        StatsGetShotgunWp1230 = 28,
        StatsGetShotgunWp1280 = 29,
        StatsGetCandle = 30,
        StatsGetCandleFire = 31,
        Invalid = -1,
    };
}
namespace via::navigation::map::MapData {
    enum MapStructure {
        Unclassified = 0,
        GroundBase = 1,
        AllSurface = 2,
    };
}
namespace app::Em3002 {
    enum ThinkOrder {
        None = 0,
        Rest = 1,
        RestEnd = 2,
        CallFromMother = 3,
        FastWalkStart = 4,
        FastWalkEnd = 5,
        JointStart = 6,
        JointEnd = 7,
        FinalStart = 8,
        NormalFather = 9,
        GhostFather = 10,
    };
}
namespace via::landscape::streaming::beta {
    enum PageRequestType {
        Allocate = 0,
        Deallocate = 1,
        Nop = 2,
    };
}
namespace app::Em3102 {
    enum ThinkOrder {
        None = 0,
        Rest = 1,
        RestEnd = 2,
        DeadChase = 3,
        NormalMother = 4,
        GhostMother = 5,
    };
}
namespace via::effect::detail {
    enum DivideAxisType {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace app::Em5510Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace via::eq::Token {
    enum Type {
        Constant = 0,
        Operator = 1,
        UnaryOperator = 2,
        Function = 3,
        Variable = 4,
    };
}
namespace via::puppet::RemoteGameObject {
    enum WarpType {
        Initialize = 0,
        Master = 1,
        Puppet = 2,
        Distance = 3,
    };
}
namespace via::effect::detail {
    enum EffectBoundsType {
        None = 0,
        Sphere = 1,
        AABB = 2,
        OBB = 3,
    };
}
namespace via::navigation::AIMapAutoScan {
    enum AutoState {
        Move = 0,
        FromCenter = 1,
        ToCenter = 2,
        MoveRoot = 3,
    };
}
namespace app::DetectionParam {
    enum Level {
        Lv0 = 0,
        Lv1 = 1,
        Lv2 = 2,
        Lv3 = 3,
        Lv4 = 4,
        Lv5 = 5,
        Max = 6,
    };
}
namespace app::MovementController {
    enum Mode {
        Internal = 0,
        External = 1,
    };
}
namespace app::MapManager {
    enum MapSheetState {
        Disable = 0,
        OpenMapWindow = 1,
        OpenMapSheet = 2,
        CheckCategoryMove = 3,
    };
}
namespace app::Em4000Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace app::CH8GameManager {
    enum Difficulty {
        Casual = 0,
        Normal = 1,
        Hard = 2,
    };
}
namespace app::vr::VrFlowBase {
    enum CutinType {
        VrModeChangeCheck = 0,
        Success = 1,
        Cancel = 2,
        Field = 3,
        ReturnTitle = 4,
        Tutorial = 5,
        TutorialEnd = 6,
    };
}
namespace app::Em4000::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em5400::Action::FlyMove {
    enum Type {
        Normal = 0,
        LookTarget = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Breath {
    enum Type {
        Vertical = 0,
        Horizontal = 1,
        Walk = 2,
        Simple = 3,
    };
}
namespace app::CH9Em6400HeadController {
    enum InsectMotionState {
        Sleep = 0,
        Active = 1,
    };
}
namespace via::render::TextureScaler {
    enum ScalingMethodType {
        Nearest = 0,
        Bilinear = 1,
        SmoothBilinear = 2,
        BicubicBSpline = 3,
        BicubicCatmullRom = 4,
    };
}
namespace via::network::MatchmakingRules {
    enum Duties {
        Guest = 0,
        Host = 1,
    };
}
namespace app::KeyHelpPlayable {
    enum DispTypeDef {
        Up = 0,
        Center = 1,
        Message = 2,
        MessageHeal = 3,
        MessageDouble = 4,
    };
}
namespace app::CH9Em6400::Action::Step {
    enum RequestStepType {
        Back = 0,
        BackLong = 1,
        BackLeft = 2,
        BackRight = 3,
        BackLeftLong = 4,
        BackRightLong = 5,
        Forward = 6,
        ForwardLeft = 7,
        ForwardRight = 8,
        ForwardLeftLong = 9,
        ForwardRightLong = 10,
    };
}
namespace via::hid {
    enum NpadJoyHoldType {
        Vertical = 0,
        Horizontal = 1,
    };
}
namespace app::Em4000::ThinkStateSet {
    enum Type {
        Default = 0,
        Mimicry = 1,
        Dregs = 2,
        Destination = 3,
        Wanderer = 4,
        Extra = 5,
        TU2 = 6,
    };
}
namespace app::Em4100ActionPoint {
    enum Type {
        ClimbWall40 = 0,
        ClimbWall79 = 1,
        ClimbWall80 = 2,
        ClimbWall119 = 3,
        ClimbOver80 = 4,
        ClimbOver119 = 5,
        Climb2Fto1F = 6,
        Climb1Fto2F = 7,
        Climb2Fto2F = 8,
    };
}
namespace via::hid::virtualKeyboard::nsw {
    enum WindowMode {
        Single = 0,
        Floating = 1,
        AdjacentFloating = 2,
    };
}
namespace app::CH8Em4200::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH9Em7700::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromFrontWithDirective = 8,
        IsTargetLegCut = 9,
        IsTargetRun = 10,
        IsTargetCrouching = 11,
        IsTargetDamage = 12,
        IsSlipFire = 13,
        IsSlipAcid = 14,
        AdditiveSensedAttack = 15,
    };
}
namespace via::physics::CollisionSkinningMeshResource {
    enum WeightType {
        None = 0,
        Weight4 = 1,
        Weight8 = 2,
    };
}
namespace via::physics::RequestSetCollider::RequestSet {
    enum State {
        Registered = 0,
        Max = 1,
    };
}
namespace via {
    enum DisplayType {
        Fit = 0,
        Uniform4x3 = 1,
        Uniform16x9 = 2,
        Uniform16x10 = 3,
        Uniform21x9 = 4,
        Uniform32x9 = 5,
        Uniform48x9 = 6,
        Fix480p = 7,
        Fix720p = 8,
        Fix1080p = 9,
        Fix4K = 10,
        Fix8K = 11,
        FixResolution = 12,
        FixResolution16x9 = 13,
        NintendoSwitch = 14,
        NintendoSwitchLite = 15,
        Custom = 16,
        Nexus6P = 17,
        GalaxyS9 = 18,
        XperiaZ5Premium = 19,
        iPhoneX = 20,
        iPhone7 = 21,
        ZenPadS8 = 22,
    };
}
namespace via::motion::IkLeg2 {
    enum RayCastSkipOption {
        None = 1,
        DIV2 = 2,
    };
}
namespace via::render::layer::PostDeferredLighting {
    enum PriorSegment {
        ComputeVolumetricFog = 0,
        IndirectIlluminationWait = 16,
    };
}
namespace via::effect::detail {
    enum Shape3DType {
        Box = 0,
        Sphere = 1,
        Cylinder = 2,
    };
}
namespace app::Em3600::Em3600WwiseMonitoredValue {
    enum PropertyBgmMode {
        Normal = 0,
        Wall = 1,
        Generate = 2,
        Sneak = 3,
        Quick = 4,
    };
}
namespace app::CH8Em4100::Action::CH8Grapple {
    enum Type {
        Thrust = 0,
    };
}
namespace via::motion::FullBodyIKRig {
    enum JointType {
        Cone = 0,
        Hinge = 1,
    };
}
namespace via::render {
    enum WindowModeChangeStatus {
        SetWindowMode = 0,
        KeyboardShortcuts = 1,
        Occlude = 2,
        AutoReturnFullScreen = 3,
    };
}
namespace via::gui {
    enum SVGStrokeRangeType {
        TotalPath = 0,
        EachPath = 1,
    };
}
namespace app::Em8910 {
    enum ThinkOrder {
        None = 0,
        CleaveAttack = 1,
        PierceAttack = 2,
        PoundingAttack = 3,
        ForceDead = 4,
        ForceAttackEnd = 5,
        BattleEndPierceAttack = 6,
    };
}
namespace via::dynamics {
    enum SimulationMeshVisibleType {
        Normal = 0,
        Weight = 1,
        Mass = 2,
        Shear = 3,
        Bend = 4,
        Warning = 5,
    };
}
namespace via::timeline::UserCurvePlayer {
    enum ResourceType {
        None = 0,
        UserCurve = 1,
        UserCurveList = 2,
    };
}
namespace via::render {
    enum BufferUavFlag {
        Raw = 1,
    };
}
namespace via::storage::saveService {
    enum SaveIcon {
        IconNew = 0,
        Icon1 = 1,
        Icon2 = 2,
        Icon3 = 3,
        Icon4 = 4,
        Icon5 = 5,
        Icon6 = 6,
        Icon7 = 7,
        Icon8 = 8,
        Icon9 = 9,
        Icon10 = 10,
        Icon11 = 11,
        Icon12 = 12,
        Icon13 = 13,
        Icon14 = 14,
        Icon15 = 15,
        Icon16 = 16,
        Icon17 = 17,
        Icon18 = 18,
        Icon19 = 19,
        Icon20 = 20,
        Icon21 = 21,
        Icon22 = 22,
        Icon23 = 23,
        Icon24 = 24,
        Icon25 = 25,
        Icon26 = 26,
        Icon27 = 27,
        Icon28 = 28,
        Icon29 = 29,
        Icon30 = 30,
        Icon31 = 31,
        Icon32 = 32,
        Icon33 = 33,
        Icon34 = 34,
        Icon35 = 35,
        Icon36 = 36,
        Icon37 = 37,
        Icon38 = 38,
        Icon39 = 39,
        Icon40 = 40,
        Icon41 = 41,
        Icon42 = 42,
        Icon43 = 43,
        Icon44 = 44,
        Icon45 = 45,
        Icon46 = 46,
        Icon47 = 47,
        Icon48 = 48,
        Icon49 = 49,
        Icon50 = 50,
        Icon51 = 51,
        Icon52 = 52,
        Icon53 = 53,
        Icon54 = 54,
        Icon55 = 55,
        Icon56 = 56,
        Icon57 = 57,
        Icon58 = 58,
        Icon59 = 59,
        Icon60 = 60,
        Icon61 = 61,
        Icon62 = 62,
        Icon63 = 63,
        Icon64 = 64,
        Icon65 = 65,
        Icon66 = 66,
        Icon67 = 67,
        Icon68 = 68,
        Icon69 = 69,
        Icon70 = 70,
        Icon71 = 71,
        Icon72 = 72,
        Icon73 = 73,
        Icon74 = 74,
        Icon75 = 75,
        Icon76 = 76,
        Icon77 = 77,
        Icon78 = 78,
        Icon79 = 79,
        Icon80 = 80,
        Icon81 = 81,
        Icon82 = 82,
        Icon83 = 83,
        Icon84 = 84,
        Icon85 = 85,
        Icon86 = 86,
        Icon87 = 87,
        Icon88 = 88,
        Icon89 = 89,
        Icon90 = 90,
        Icon91 = 91,
        Icon92 = 92,
        Icon93 = 93,
        Icon94 = 94,
        Icon95 = 95,
        Icon96 = 96,
        Icon97 = 97,
        Icon98 = 98,
        Icon99 = 99,
        IconMax = 100,
    };
}
namespace app::CH9MessageController::MessageInfoListCtrl {
    enum PlayType {
        Default = 0,
        RandomOnce = 1,
        RandomLoop = 2,
    };
}
namespace app::CH9Em6400ActionController {
    enum ShortActionType {
        Attack_SkillA1 = 100,
        Attack_SkillA2 = 101,
        Attack_SkillA3 = 102,
        Attack_SkillB1 = 200,
        Attack_SkillB2 = 201,
        Attack_SkillB3 = 202,
        Attack_SkillC1 = 300,
        Attack_TSkillA1 = 1100,
        Attack_TSkillA2 = 1101,
        Attack_TSkillA3 = 1102,
        Attack_TSkillB1 = 1200,
        Attack_TSkillB2 = 1201,
        Attack_TSkillB3 = 1202,
        Attack_TSkillC1 = 1300,
        Attack_FSkillA3 = 2100,
        Attack_FSkillB3 = 2200,
        Attack_SkillSpA = 4000,
        Attack_SkillSpC = 4002,
        Attack_TSkillSpA = 4200,
        Attack_SkillA1End = 4500,
        Attack_SkillA2End = 4501,
        Attack_SkillB1End = 4502,
        Attack_SkillB2End = 4503,
        Attack_SkillC1End = 4504,
        Attack_TSkillA1End = 4600,
        Attack_TSkillA2End = 4601,
        Attack_TSkillB1End = 4602,
        Attack_TSkillB2End = 4603,
        Attack_TSkillC1End = 4604,
        Attack_Back = 4800,
        Grab = 5000,
        GrabSp = 5001,
        StepBack = 6000,
        StepBackLong = 6001,
        StepBackLR = 6002,
        StepBackLRLong = 6003,
        StepIn = 6004,
        StepInLong = 6005,
        StepInLR = 6006,
        StepInLRLong = 6007,
        Attack_SkillExSwingR1 = 8000,
        Attack_SkillExSwingL1 = 8100,
        Attack_SkillExSwingD1 = 8200,
        Attack_SkillExSwingT1 = 8300,
        Attack_TSkillExSwingR1 = 9000,
        Attack_TSkillExSwingL1 = 9100,
        Attack_TSkillExSwingD1 = 9200,
        Attack_TSkillExSwingT1 = 9300,
        Max = 9301,
        None = -1,
    };
}
namespace app::Em3000::Action::Damage {
    enum Type {
        NoDamage = 0,
        MidHeadF = 1,
        MidHeadFR = 2,
        MidHeadFL = 3,
        MidHeadB = 4,
        MidHeadR = 5,
        MidHeadL = 6,
        MidBodyF = 7,
        MidBodyB = 8,
        MidBodyR = 9,
        MidBodyL = 10,
        MidLegR = 11,
        MidLegL = 12,
        MidHeadFRun = 13,
        MidHeadBRun = 14,
        MidHeadRRun = 15,
        MidHeadLRun = 16,
        MidBodyFRun = 17,
        MidBodyBRun = 18,
        MidBodyRRun = 19,
        MidBodyLRun = 20,
        MidLegRRun = 21,
        MidLegLRun = 22,
        Down = 23,
        CommonKneeDownFromF = 24,
        CommonKneeDownFromB = 25,
        CommonKneeDownFromL = 26,
        CommonKneeDownFromR = 27,
        CorpsebagL = 28,
        CorpsebagR = 29,
    };
}
namespace app::OptionMenu {
    enum OptionStatePattern {
        Default = 0,
        Arabic = 1,
    };
}
namespace app::CH8Em4000::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::InteractDetailSearch {
    enum SearchEventSubInteractType {
        EndInteract = 0,
        NotEndInteract = 1,
        PauseWaitInteract = 2,
        NotEndInteract_RepeatFSM = 3,
    };
}
namespace app::InteractObjectBase {
    enum Type {
        None = 0,
        ManualMovable = 1,
        ManualDetailSearch = 2,
        ManualSendFsmEvent = 3,
        AutoSendFsmEvent = 4,
        ManualSendMessage = 5,
        ManualDoor = 6,
        AutoGUI = 7,
        ManualPushMove = 8,
        NoManageShadowPuzzle = 9,
        NoManagePadlock = 10,
        NoManageNumberLock = 11,
        NoManageClock = 12,
        ManualArt = 13,
        ManualCardan = 14,
        ManualZoomSendFsm = 15,
    };
}
namespace app::Em8100::Em8100WwiseMonitoredValue {
    enum PropertyBurn {
        None = 0,
        Burn1 = 1,
        Burn2 = 2,
        Burn3 = 3,
        Max = 4,
    };
}
namespace via::storage::saveService {
    enum SaveDataArrayType {
        Value = 0,
        Class = 1,
    };
}
namespace via::wwise {
    enum OutputDevice {
        None = 0,
        HDMI = 1,
        Headphone = 2,
        Speaker = 3,
        USBDevice = 4,
        Max = 5,
    };
}
namespace app::FBIKAttackController {
    enum HandModeType {
        R = 0,
        L = 1,
    };
}
namespace app::CH9Em6700::ThinkAppearSet {
    enum Type {
        Default = 0,
        Surface = 10,
    };
}
namespace app::ScreenAreaAdjustGUI {
    enum ModeDef {
        BootFlow = 0,
        Normal = 1,
    };
}
namespace app::Chapter3_IMD_MainMenu {
    enum ProcStateEnum {
        Startup = 0,
        WaitResident = 1,
        InputProc = 2,
        ExitWait = 3,
        JumpGameIntent = 4,
    };
}
namespace via::motion::FullBodyIKRig {
    enum AngleLimitAxisSource {
        Motion = 0,
        Parent = 1,
    };
}
namespace app::EnemySpawnInfo::ResumeParameter {
    enum Type {
        LastStandingPoint = 0,
        FirstAppearPoint = 1,
    };
}
namespace app::Havok::CH8Em4500RagdollCharacter {
    enum PartsId {
        Hip = 0,
        Hip_Live = 1,
        R_Thigh = 2,
        R_Shin = 3,
        R_Foot = 4,
        L_Thigh = 5,
        L_Shin = 6,
        L_Foot = 7,
        Waist = 8,
        Waist_Live = 9,
        Chest = 10,
        R_Shoulder = 11,
        R_UpperArm = 12,
        R_Forearm = 13,
        R_Hand = 14,
        L_Shoulder = 15,
        L_UpperArm = 16,
        L_Forearm = 17,
        L_Hand = 18,
        Neck = 19,
        Head = 20,
    };
}
namespace via::gui {
    enum FontSlot {
        Slot0 = 0,
        Slot1 = 1,
        Slot2 = 2,
        Slot3 = 3,
        Slot4 = 4,
        Slot5 = 5,
        Slot6 = 6,
        Slot7 = 7,
        Slot8 = 8,
        Slot9 = 9,
        Slot10 = 10,
        Slot11 = 11,
        Slot12 = 12,
        Slot13 = 13,
        Slot14 = 14,
        Slot15 = 15,
        Max = 16,
    };
}
namespace via::render {
    enum Filter {
        MinMagMipPoint = 0,
        MinMagPointMipLinear = 1,
        MinPointMagLinearMipPoint = 4,
        MinPointMagMipLinear = 5,
        MinLinearMagMipPoint = 16,
        MinLinearMagPointMipLinear = 17,
        MinMagLinearMipPoint = 20,
        MinMagMipLinear = 21,
        Anisotropic = 85,
        ComparisonMinMagMipPoint = 128,
        ComparisonMinMagPointMipLinear = 129,
        ComparisonMinPointMagLinearMipPoint = 132,
        ComparisonMinPointMagMipLinear = 133,
        ComparisonMinLinearMagMipPoint = 144,
        ComparisonMinLinearMagPointMipLinear = 145,
        ComparisonMinMagLinearMipPoint = 148,
        ComparisonMinMagMipLinear = 149,
        ComparisonAnisotropic = 213,
    };
}
namespace via::render {
    enum EyeballShadingType {
        Standard = 0,
        Expensive = 1,
        ExpensiveWithCaustics = 2,
    };
}
namespace app::CH8Telemetry {
    enum LostPartsType {
        Em4400Head = 0,
        Em4600Head = 1,
        Em4600LeftArm = 2,
        Em4600RightArm = 3,
        Em4600LeftLeg = 4,
        Em4600RightLeg = 5,
    };
}
namespace app::CH8Em4450::Action::CH8Avoidance {
    enum AvoidanceType {
        Right = 0,
        Left = 1,
    };
}
namespace app::CH9Em6700::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::fsm::RequestFadeInOut {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace via::gui::GUIUtility {
    enum AnalyzeContext {
        Key = 0,
        Association = 1,
        Value = 2,
        SearchNextKey = 3,
        Unknown = 4,
    };
}
namespace app::Em5510Think {
    enum ThinkMode {
        Normal = 0,
        NoThink = 1,
        Passive = 2,
    };
}
namespace via::motion::IkLegSpine {
    enum CenterAdjustMode {
        Default = 0,
        LockIgnore = 1,
    };
}
namespace via::fsm {
    enum StateQueryType {
        All = 0,
        Start = 1,
    };
}
namespace via::clr::VMRuntimeType {
    enum Kind {
        Default = 0,
        GenericParameter = 1,
        ByRef = 2,
        Pointer = 3,
    };
}
namespace via::memory {
    enum InstanceType {
        Default = 0,
        Object = 1,
        ManagedObject = 2,
    };
}
namespace app::PlayerMeshController {
    enum LegPartsState {
        Normal = 0,
        LegCut = 1,
        LegCure = 2,
    };
}
namespace app::fsm::AdjustSafeSpace {
    enum FindType {
        Direction = 0,
        SpaceCheck = 1,
    };
}
namespace app::Em2000::Action::Chapter1Battle4SlashAttack {
    enum Type {
        SlashL = 0,
        SlashR = 1,
        ShortSlashL = 2,
        ShortSlashR = 3,
        StepSlashM = 4,
        StepSlashL = 5,
        Counter = 6,
        CounterL = 7,
        CounterR = 8,
    };
}
namespace app::CH8Em4500::Action::CH8ThreatOneShot {
    enum ThreatType {
        Small = 0,
        Big = 1,
    };
}
namespace app::Item {
    enum ITEMSTATE {
        SCENE_SET = 0,
        DROP_SET = 1,
        INVENTRY_IN = 2,
        EQUIP_MAIN = 3,
        EQUIP_SUB = 4,
        CHARA_HOLD = 5,
        LOST = 6,
        LOST_NOSAVE = 7,
    };
}
namespace app::Em3100::Message {
    enum TagRandomMessageGroup {
        None = 0,
        BugHole_BattleStart = 1,
        BugHole_Common = 2,
        BugHole_High = 3,
        BugHole_Instruct_Common = 4,
        BugHole_Instruct_High = 5,
        BugHole_TargetUseLadder = 6,
        BugHole_StunEnd = 7,
        FF_Discovery = 8,
        FF_DeathGrapple = 9,
        PatrolCommon = 10,
        PatrolDiscoveryMiss = 11,
        PatrolLostPlayer = 12,
        PatrolDiscovery = 13,
        PatrolInstruct = 14,
        PatrolFallDown = 15,
    };
}
namespace via::simplewwise {
    enum CallbackType {
        None = 0,
        EndOfEvent = 1,
        EndOfDynamicSequenceItem = 2,
        Marker = 4,
        Duration = 8,
        SpeakerVolumeMatrix = 16,
        Starvation = 32,
        MusicPlaylistSelect = 64,
        MusicPlayStarted = 128,
        MusicSyncBeat = 256,
        MusicSyncBar = 512,
        MusicSyncEntry = 1024,
        MusicSyncExit = 2048,
        MusicSyncGrid = 4096,
        MusicSyncUserCue = 8192,
        MusicSyncPoint = 16384,
        MusicSyncAll = 32512,
        MIDIEvent = 65536,
        CallbackBits = 1048575,
        EnableGetSourcePlayPosition = 1048576,
        EnableGetMusicPlayPosition = 2097152,
        EnableGetSourceStreamBuffering = 4194304,
    };
}
namespace via::render {
    enum AccelerationStructureGeometryFlag {
        None = 0,
        Opaque = 1,
    };
}
namespace app {
    enum BulletID {
        None = 0,
        Normal = 1,
        Strong = 2,
        Fire = 3,
        Acid = 4,
    };
}
namespace via::typeinfo {
    enum TypeCode {
        Undefined = 0,
        Object = 1,
        Action = 2,
        Struct = 3,
        NativeObject = 4,
        Resource = 5,
        UserData = 6,
        Bool = 7,
        C8 = 8,
        C16 = 9,
        S8 = 10,
        U8 = 11,
        S16 = 12,
        U16 = 13,
        S32 = 14,
        U32 = 15,
        S64 = 16,
        U64 = 17,
        F32 = 18,
        F64 = 19,
        String = 20,
        MBString = 21,
        Enum = 22,
        Uint2 = 23,
        Uint3 = 24,
        Uint4 = 25,
        Int2 = 26,
        Int3 = 27,
        Int4 = 28,
        Float2 = 29,
        Float3 = 30,
        Float4 = 31,
        Float3x3 = 32,
        Float3x4 = 33,
        Float4x3 = 34,
        Float4x4 = 35,
        Half2 = 36,
        Half4 = 37,
        Mat3 = 38,
        Mat4 = 39,
        Vec2 = 40,
        Vec3 = 41,
        Vec4 = 42,
        VecU4 = 43,
        Quaternion = 44,
        Guid = 45,
        Color = 46,
        DateTime = 47,
        AABB = 48,
        Capsule = 49,
        TaperedCapsule = 50,
        Cone = 51,
        Line = 52,
        LineSegment = 53,
        OBB = 54,
        Plane = 55,
        PlaneXZ = 56,
        Point = 57,
        Range = 58,
        RangeI = 59,
        Ray = 60,
        RayY = 61,
        Segment = 62,
        Size = 63,
        Sphere = 64,
        Triangle = 65,
        Cylinder = 66,
        Ellipsoid = 67,
        Area = 68,
        Torus = 69,
        Rect = 70,
        Rect3D = 71,
        Frustum = 72,
        KeyFrame = 73,
        Uri = 74,
        GameObjectRef = 75,
        RuntimeType = 76,
        Sfix = 77,
        Sfix2 = 78,
        Sfix3 = 79,
        Sfix4 = 80,
        Position = 81,
        F16 = 82,
        Decimal = 83,
        End = 84,
    };
}
namespace via::simplewwise {
    enum DeviceTypeWindows {
        None = 0,
        Main = 1,
        MergeToMain = 2,
        Secondary = 3,
        Communication = 4,
        MicrodsoftSpatialSound = 5,
    };
}
namespace via::navigation::algorithm::LinkValidityGetter {
    enum BaseType {
        Start = 0,
        Goal = 1,
    };
}
namespace via::effect::gpgpu::RibbonLengthCS::RibbonLengthResource {
    enum RibbonLengthComputeShaderType {
        InitializeCS = 0,
        ConstructCS = 1,
        DepthOcclusion = 2,
        DepthOcclusionGlobalSparseShadow = 3,
        MaxType = 4,
    };
}
namespace app::Nightmare {
    enum SpawnInfoTagName {
        Molded_Slow = 0,
        Molded_Blade = 1,
        Molded_Quick = 2,
        Molded_Fat = 3,
        Molded_Rush_Slow = 4,
        Molded_Rush_Blade = 5,
        Molded_Rush_Quick = 6,
        Molded_Rush_Fat = 7,
        Jack_Roller = 8,
        Jack_Scissors = 9,
    };
}
namespace via::render::layer::Transparent {
    enum LuminanceBleedType {
        Pre = 0,
        Post = 1,
    };
}
namespace via::behaviortree::TreeNode {
    enum SelectorStatus {
        Off = 0,
        Start = 1,
        Work = 2,
    };
}
namespace via::hid {
    enum DeviceCaps {
        None = 0,
        ForceFeedback = 1,
        TouchInterface = 2,
        GamePadButtonCLeft = 4,
        GamePadButtonCCenter = 8,
        GamePadButtonCRight = 16,
        MotionSensor = 32,
        Tracking = 64,
    };
}
namespace app::Em8001::Action::Acid {
    enum Type {
        Start = 0,
        End = 1,
    };
}
namespace via::render::PrimitiveDrawObject {
    enum DrawType {
        Default = 0,
        ZPrepass = 1,
        Shadow = 2,
        TranslucentShadow = 3,
        DeferredLighting = 4,
        Num = 5,
    };
}
namespace via::motion::IkLookAt2 {
    enum State {
        Focusing = 0,
        Moving = 1,
        Following = 2,
        OutView = 3,
    };
}
namespace app::LastWaveUIAsset::MainPanel {
    enum MainState {
        DEFAULT = 0,
        PLAY_BONUS = 1,
        PLAY_TEXT = 2,
        PLAY_RESULT = 3,
    };
}
namespace via::render::Bloodshed {
    enum SourceChannel {
        R = 1,
        G = 2,
        B = 3,
        A = 4,
    };
}
namespace app::Em8000::Damage {
    enum Mode {
        Common = 0,
        Hand = 1,
        Axe = 2,
        Scissors = 3,
    };
}
namespace via::motion::JointExMultiRemapValue {
    enum RotOrder {
        XYZ = 0,
        YZX = 1,
        ZXY = 2,
        ZYX = 3,
        YXZ = 4,
        XZY = 5,
    };
}
namespace System::Globalization {
    enum DateTimeStyles {
        None = 0,
        AllowLeadingWhite = 1,
        AllowTrailingWhite = 2,
        AllowInnerWhite = 4,
        AllowWhiteSpaces = 7,
        NoCurrentDateDefault = 8,
        AdjustToUniversal = 16,
        AssumeLocal = 32,
        AssumeUniversal = 64,
        RoundtripKind = 128,
    };
}
namespace via::render {
    enum SupportRenderMode {
        DeferredAndForward = 0,
        Deferred = 1,
        Forward = 2,
    };
}
namespace app::EffectCommonDefine {
    enum EffectEndType {
        Kill = 0,
        Finish = 1,
    };
}
namespace via {
    enum HashType {
        CRC16 = 0,
        CRC32 = 1,
        MD2 = 2,
        MD4 = 3,
        MD5 = 4,
        SHA1 = 5,
        SHA256 = 6,
        SHA384 = 7,
        SHA512 = 8,
        RIPEMD128 = 9,
        RIPEMD160 = 10,
        RIPEMD256 = 11,
        RIPEMD320 = 12,
    };
}
namespace via::sound {
    enum SoundCurveType {
        Linear = 0,
        FlatHermite = 1,
        SineFadeIn = 2,
        SineFadeOut = 3,
        Constant = 4,
    };
}
namespace via::movie::Movie {
    enum CosmeticState {
        Preparing = 0,
        Ready = 1,
        Playing = 2,
        Paused = 3,
        Finished = 4,
    };
}
namespace app::Em3600Think::MotherHoleInfo {
    enum HoleType {
        Hide = 0,
        Appear = 1,
        Sneak = 2,
    };
}
namespace app::CH8ChangeToneMapProxy {
    enum STATUS_FLAG {
        INITIALIZE = 1,
        AUTONIGHT_VISION = 2,
    };
}
namespace via::areamap::AreaTest {
    enum Mode {
        Score = 0,
        Filter = 1,
        Both = 2,
    };
}
namespace via::movie {
    enum PlaybackPerformance {
        Slowest = 0,
        Normal = 1,
        Fastest = 2,
        Maximum = 3,
    };
}
namespace via::render::RoughTransparentUpdater {
    enum DebugMode {
        None = 0,
        Downsample = 1,
        Blur = 2,
    };
}
namespace app::Em3600 {
    enum ThinkOrder {
        None = 0,
        PLSearchGoTo = 1,
        SneakSet = 2,
    };
}
namespace via::hid::VrTrackerResultData {
    enum ProjectionQuality {
        Raw = 0,
        None = 3,
        Partial = 6,
        Full = 9,
    };
}
namespace via::motion::RetargetRig {
    enum JointTypes {
        Head = 0,
        EndNeck = 1,
        BaseNeck = 2,
        RightShoulder = 3,
        LeftShoulder = 4,
        EndSpine = 5,
        BaseSpine = 6,
        Cog = 7,
        Hip = 8,
        RightArm = 9,
        RightForeArm = 10,
        RightHand = 11,
        RightFoot = 12,
        LeftArm = 13,
        LeftForeArm = 14,
        LeftHand = 15,
        LeftFoot = 16,
        MAX = 17,
    };
}
namespace app::CH9Em5901::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        Attack = 2,
        Dead = 3,
        AttackAction = 4,
        DeadAction = 5,
    };
}
namespace via::fluidflock::FluidFlockSimulationModelBase {
    enum NeiborSearchMethod {
        Default = 0,
        UseCellSpace = 1,
        Highbrid = 2,
    };
}
namespace via::render {
    enum ShadowCastMode {
        A = 1,
        B = 2,
    };
}
namespace app::Em3100::Action {
    enum ActionNo {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Turn = 3,
        OverLook = 4,
        WalkOverLook = 5,
        WalkLookBack = 6,
        WalkLookBackTurn = 7,
        DiscoveryTurn = 8,
        DiscoveryLoop = 9,
        Cough = 10,
        Suspicion = 11,
        SetHair = 12,
        Fret = 13,
        WalkFret = 14,
        WalkEvade = 15,
        Attack = 16,
        AttackZeroRange = 17,
        Damage = 18,
        Dead = 19,
        DoorOpen = 20,
        Stun = 21,
        FireDamage = 22,
        Grapple = 23,
        FFRoomMove = 24,
        PatrolBugInstruct = 25,
        BugHoleInstruct = 26,
        DLC_TestAction = 27,
    };
}
namespace app::Em4000::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em3101 {
    enum ThinkState {
        None = 0,
    };
}
namespace via::wwise {
    enum User {
        User_0 = 0,
        User_1 = 1,
        User_2 = 2,
        User_3 = 3,
        User_None = 4,
    };
}
namespace app::StaffRollData {
    enum Type {
        Work = 0,
        Company = 1,
        Organization = 2,
        Job = 3,
        Name = 4,
        Logo = 5,
    };
}
namespace app::Item {
    enum ItemSlotSize {
        Slot1 = 0,
        Slot2 = 1,
        Slot3 = 2,
    };
}
namespace app::CH9Em6400ActionController {
    enum SearchMode {
        None = 0,
        Vision = 1,
        Hearing = 2,
        Damage = 3,
    };
}
namespace app::CH8Em4200::Action {
    enum CH8ActionNo {
        MountTry = 4,
        Grapple = 5,
        Appear = 6,
        LostParts = 7,
        BlownAway = 8,
        SlipFire = 9,
        SlipAcid = 10,
        Falling = 11,
        Feint = 12,
        Anger = 13,
        Rush = 14,
        Splash = 15,
        Breath = 16,
        BreathFirst = 17,
        BreathForce = 18,
        ChanceCounter = 19,
        DamageToMove = 20,
        DamageToBreath = 21,
        Wait = 22,
        Suspend = 23,
        Resume = 24,
        Warp = 25,
        StrikeToParry = 26,
    };
}
namespace via::gui {
    enum GridLoopType {
        Clamp = 0,
        Loop = 1,
        Next = 2,
    };
}
namespace app::CH9Em7500::Evaluator::CheckRangeFromJoint {
    enum Type {
        Simple = 0,
        NormalizedRateScore = 1,
        RateScore = 2,
    };
}
namespace app::CH8Em4100::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::GameManager {
    enum Difficulty {
        Easy = 0,
        Normal = 1,
        Hard = 2,
    };
}
namespace CH8Em4450Effect {
    enum IDAlias {
        BabySpawn = 0,
    };
}
namespace via::audiorender {
    enum Channel_51ch {
        L = 0,
        R = 1,
        C = 2,
        LFE = 3,
        Ls = 4,
        Rs = 5,
        Max = 6,
    };
}
namespace app::CH9Em7700::Action::Move {
    enum CrawlMode {
        Wait = 0,
        Walk = 1,
    };
}
namespace via {
    enum InterpolationFlag {
        Unknown = 0,
        Discrete = 1,
        Linear = 2,
        Event = 4,
        Slerp = 8,
        Hermite = 16,
        AutoHermite = 32,
        Bezier = 64,
        AutoBezier = 128,
        OffsetFrame = 256,
        OffsetSec = 512,
        PassEvent = 1024,
        Bezier3D = 2048,
        Range = 4096,
        DiscreteToEnd = 8192,
    };
}
namespace app::Em4200::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::render {
    enum ExecuteTiming {
        Sync = 0,
        Async = 1,
        Precede = 2,
    };
}
namespace app::BedRoom::BedRoomManager {
    enum GimickReset {
        None = 0,
        DeActivate = 1,
        Wait = 2,
        Activate = 3,
    };
}
namespace app::CH8Em4400Message {
    enum Tag {
        FirstLiquidBomb = 0,
    };
}
namespace app::Em5400ActionController {
    enum MaterialName {
        Risotto_Rate = 0,
        Record_RandumFlag = 1,
        Burn_Rate = 2,
        Max = 3,
    };
}
namespace via::network::error {
    enum CauseHttpClient {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
    };
}
namespace app::Em3000::Em3000WwiseMonitoredValue {
    enum PropertyEncount {
        InCamera = 0,
        OutCamera = 1,
        Max = 2,
    };
}
namespace app::BirthdaySealedSetting {
    enum ColorTypeEnum {
        Red = 0,
        Blue = 1,
        Green = 2,
        Yellow = 3,
        Orange = 4,
        MAX = 5,
    };
}
namespace app::fsm::CountAddTest {
    enum TestTypeParam {
        CoinCounter = 0,
    };
}
namespace app::AI::EvaluationMethod {
    enum Type {
        Average = 0,
        Weighted = 1,
    };
}
namespace via::wwise::FreeArea {
    enum FreeArea0to7 {
        FreeArea0to7_None = 4294967295,
        FreeArea0to7_0 = 0,
        FreeArea0to7_1 = 1,
        FreeArea0to7_2 = 2,
        FreeArea0to7_3 = 3,
        FreeArea0to7_4 = 4,
        FreeArea0to7_5 = 5,
        FreeArea0to7_6 = 6,
        FreeArea0to7_7 = 7,
    };
}
namespace via::os {
    enum ClipboardFormat {
        TEXT_ANSI = 0,
        TEXT_UNICODE = 1,
        BINARY = 2,
    };
}
namespace app::MathEx {
    enum RotationOrder {
        XYZ = 0,
        XZY = 1,
        YXZ = 2,
        YZX = 3,
        ZXY = 4,
        ZYX = 5,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraSetConfigResult {
        OK = 1,
        ErrorStarted = 2147483649,
        ErrorInvalidType = 2147483650,
        ErrorInternal = 2147487744,
    };
}
namespace via::nnfc {
    enum NpadId {
        Pad1 = 0,
        Pad2 = 1,
        Pad3 = 2,
        Pad4 = 3,
        Any = 4,
        Invalid = 5,
    };
}
namespace via::attribute::RemoteFieldAttribute {
    enum SyncMode {
        Copy = 0,
        Kill = 1,
        Transaction = 2,
        FrequentCopy = 3,
    };
}
namespace app::GraphicDefaultSettings {
    enum PresetType {
        Default = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Stadia_FullHD = 4,
        Stadia_4K = 5,
        Stadia_4K_Low = 6,
        Max = 7,
    };
}
namespace via::audiorender::fx::mt_equalizer {
    enum EQUnit {
        Low = 0,
        MidLow = 1,
        MidHigh = 2,
        High = 3,
        MaxNum = 4,
    };
}
namespace app::GenomeCodexGUISimple {
    enum StepType {
        HP = 0,
    };
}
namespace via {
    enum PropertiedEventInvokeTiming {
        Equal = 0,
        NotEqual = 1,
        Ever = 2,
        Never = 3,
    };
}
namespace app::BedRoom::BedRoomQuestionBehavior {
    enum AnswerType {
        None = 0,
        AnswerOne = 1,
        AnswerTwo = 2,
        AnswerThree = 3,
        AnswerWait = 4,
    };
}
namespace app::GasCylinder {
    enum Routine {
        Wait = 0,
        StartSpout = 1,
        Spout = 2,
        End = 3,
    };
}
namespace app::LogoControl {
    enum UseSlideType {
        JP_D = 0,
        JP_Z = 1,
        Other = 2,
    };
}
namespace via::render::Outline {
    enum DrawMode {
        Outline = 0,
        Silhouette = 1,
        Both = 2,
        HiddenSwitch = 3,
    };
}
namespace via::userdata {
    enum VariableError {
        None = 0,
        ChangeValueAtWriteProtect = 1,
    };
}
namespace via::navigation::NavigationVolumeSpace {
    enum ShapeType {
        Sphere = 0,
        Capsule = 1,
    };
}
namespace app::Em3102 {
    enum ThinkState {
        Idle = 0,
        Goto = 1,
        Em3102 = 2,
        LastChase = 3,
    };
}
namespace via::hid {
    enum DeviceIndex {
        Index0 = 0,
        Index1 = 1,
        Index2 = 2,
        Index3 = 3,
        Index4 = 4,
        Index5 = 5,
        Index6 = 6,
        Index7 = 7,
        Index8 = 8,
        Index9 = 9,
        Index10 = 10,
        Index11 = 11,
        Index12 = 12,
        Index13 = 13,
        Index14 = 14,
        Index15 = 15,
        Index16 = 16,
        Index17 = 17,
        Index18 = 18,
        Index19 = 19,
        Index20 = 20,
        Index21 = 21,
        Index22 = 22,
        Index23 = 23,
        Index24 = 24,
        Index25 = 25,
        Index26 = 26,
        Index27 = 27,
        Index28 = 28,
        Index29 = 29,
        Index30 = 30,
        Index31 = 31,
        Index32 = 32,
        Index33 = 33,
        Index34 = 34,
        Index35 = 35,
        Index36 = 36,
        Index37 = 37,
        Index38 = 38,
        Index39 = 39,
        Index40 = 40,
        Index41 = 41,
        Index42 = 42,
        Index43 = 43,
        Index44 = 44,
        Index45 = 45,
        Index46 = 46,
        Index47 = 47,
        Index48 = 48,
        All = 65535,
        Invalid = 65536,
        Max = 65537,
    };
}
namespace via::storage {
    enum ChunkInstalledDevice {
        None = 0,
        Slow = 1,
        Fast = 2,
    };
}
namespace app::Em4100::Action::Move {
    enum Type {
        Solo = 0,
        Normal = 1,
        Wanderer = 2,
    };
}
namespace app::CH9Em6400ActionController {
    enum AppealAwakenState {
        None = 0,
        Action = 1,
        End = 2,
    };
}
namespace app::CH9SM2644Movement {
    enum eGearState {
        Front = 0,
        Back = 1,
    };
}
namespace via::dynamics::HingeConstraint::Initializer {
    enum PositionType {
        World = 0,
        Local = 1,
    };
}
namespace via::navigation::PathObject {
    enum PortalEndEdgeAttrType {
        P0 = 0,
        P1 = 1,
        TypeNum = 2,
    };
}
namespace via::landscape::streaming::beta {
    enum StreamingRequestType {
        Load = 0,
        Unload = 1,
    };
}
namespace app::fsm::PlayTimeTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace app::LookAt {
    enum TargetModeEnum {
        Position = 0,
        GameObject = 1,
        Joint = 2,
    };
}
namespace via::os::dialog {
    enum State {
        None = 0,
        Busy = 1,
    };
}
namespace app::CH8CheckOnlySceneFolder {
    enum CheckTypeEnum {
        isActivate = 0,
        isDeactivate = 1,
        MAX = 2,
    };
}
namespace app::Em3102::Action::Sane {
    enum State {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
    };
}
namespace app::CH9Em5800::Action::Generate {
    enum Type {
        Em5700 = 0,
        Em5850 = 1,
    };
}
namespace app::fsm::CH8HardwareCheck {
    enum checkTypeEnum {
        PS4 = 0,
        Xone = 1,
        PC = 2,
        Steam = 3,
        UWP = 4,
    };
}
namespace app::EnemyActionController {
    enum GroundType {
        Ground = 0,
        Wall = 1,
        Ceil = 2,
        Air = 3,
    };
}
namespace app::InteractEventActionMarker {
    enum Result {
        Success = 0,
        Failure = 1,
        Interacted = 2,
    };
}
namespace app::CH9TitleMainLoop {
    enum StepType {
        WaitSave = 0,
        StartCheck = 1,
        FirstSave = 2,
        FirstSaveFailed = 3,
        QuitSave = 4,
        QuitSaveFailed = 5,
        QuitSaveRetry = 6,
        EverywhereCutin = 7,
        Main = 8,
        NewGame = 9,
        Continue = 10,
        LoadGame = 11,
        Quit = 12,
        WaitContinue = 13,
        ContinueFailed = 14,
        Idle = 15,
    };
}
namespace app::Em3102::Action::Walk {
    enum Type {
        None = 0,
        Walk = 1,
        DetectWalk = 2,
    };
}
namespace via::effect {
    enum GroupType {
        Invalid = -1,
        Free = 0,
        EffectCollision = 1,
        UserVariable = 2,
        RootUserVariable = 3,
    };
}
namespace app::fsm::Wait {
    enum WaitTypeEnum {
        Normal = 0,
        FlagSet = 1,
    };
}
namespace app::HIDManager {
    enum InputMode {
        Pad = 0,
        MouseAndKeyboard = 1,
    };
}
namespace via::render {
    enum ColorWrite {
        EnableRed = 1,
        EnableGreen = 2,
        EnableBlue = 4,
        EnableAlpha = 8,
        EnableRGB = 7,
        EnableAll = 15,
    };
}
namespace via::hid {
    enum GamePadEmuButtonThresholdType {
        Square = 0,
        Circle = 1,
    };
}
namespace via::navigation::Navigation {
    enum OnFindingNavigationVectorType {
        Keep = 0,
        Target = 1,
        Zero = 2,
    };
}
namespace app::TableItemExplanation {
    enum Player {
        Start = -1,
        Enemy = 0,
        Player = 1,
        End = 2,
    };
}
namespace via::audiorender {
    enum DistortionParameter {
        GainDb = 0,
        MixAmount = 1,
        DistType = 2,
        OutputGain = 3,
        OutputGainDb = 4,
    };
}
namespace app::Em3100::Action::WalkEvade {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em8900Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em2000::Goal {
    enum GoalId {
        Chapter1Battle2CloserSlow = 0,
        Chapter1Battle2CloserFast = 1,
        Chapter1Battle2AttackToGrapple = 2,
        Chapter1Battle2Counter = 3,
        Chapter1Battle2KnifeStab = 4,
        Chapter1Battle2KnifeRush = 5,
        Chapter1Battle2Throw = 6,
        Chapter1Battle4WalkSlow = 7,
        Chapter1Battle4WalkNormal = 8,
        Chapter1Battle4WalkFast = 9,
        Chapter1Battle4RunSlash = 10,
        Chapter1Battle4SlashAttack = 11,
        Chapter1Battle4StabAttackGrapple = 12,
        Chapter1Battle4StepAttack = 13,
        Chapter1Battle4CloseRangeGrapple = 14,
        Chapter1Battle4MountGrapple = 15,
        Chapter1Battle4HalfOpenDoor = 16,
        _None = 17,
    };
}
namespace app::Em8000::Action::Em8000Damage {
    enum Direction {
        INVALID = -1,
        None = 0,
        Front = 1,
        Back = 2,
        Left = 3,
        Right = 4,
        SUM = 5,
    };
}
namespace System::Text {
    enum NormalizationForm {
        FormC = 1,
        FormD = 2,
        FormKC = 5,
        FormKD = 6,
    };
}
namespace app::SaveMenu {
    enum ModeDef {
        LoadTitleMenu = 0,
        LoadInGame = 1,
        SaveInGame = 2,
        FirstSystemSave = 3,
    };
}
namespace app::VFXCullingZoneGroup {
    enum Status {
        None = 0,
        CullingOnTrigger = 1,
        CullingOffTrigger = 2,
        CullingOff = 3,
    };
}
namespace app::Em3002::Em3002WwiseMonitoredValue {
    enum PropertyLayer {
        Discovery = 0,
        UnDiscovery = 1,
        DamageDown = 2,
        Max = 3,
    };
}
namespace via::clr {
    enum BindingFlags {
        Default = 0,
        IgnoreCase = 1,
        DeclaredOnly = 2,
        Instance = 4,
        Static = 8,
        Public = 16,
        NonPublic = 32,
        FlattenHierarchy = 64,
        InvokeMethod = 256,
        CreateInstance = 512,
        GetField = 1024,
        SetField = 2048,
        GetProperty = 4096,
        SetProperty = 8192,
        PutDispProperty = 16384,
        PutRefDispProperty = 32768,
        ExactBinding = 65536,
        SuppressChangeType = 131072,
        OptionalParamBinding = 262144,
        IgnoreReturn = 16777216,
    };
}
namespace via::hid::VrTracker {
    enum CalibrationType {
        Position = 0,
        All = 1,
    };
}
namespace app::fsm::ChangeDamageGUI {
    enum VisibleType {
        NotSet = 0,
        Visible = 1,
        Invisible = 2,
    };
}
namespace app::NowOnSaleMenu {
    enum ModeDef {
        Normal = 0,
    };
}
namespace via::os {
    enum FileSeek {
        Begin = 0,
        Current = 1,
        End = 2,
    };
}
namespace via::gui {
    enum BarDirection {
        Horizontal = 0,
        Vertical = 1,
        Max = 2,
    };
}
namespace via::landscape {
    enum TextureDataFormat {
        DataFormat_Unknown = 0,
        DataFormat_R16Unorm = 1,
        DataFormat_R16G16Unorm = 2,
        DataFormat_Max = 3,
    };
}
namespace via::motion::ChainResource {
    enum DirectionOfEmission {
        Global = 0,
        Local = 1,
        GroupLocal = 2,
    };
}
namespace via::audiorender {
    enum OutputDimension {
        OutputDimension_None = 0,
        OutputDimension_2D = 1,
        OutputDimension_3D = 2,
        OutputDimension_Max = 3,
    };
}
namespace via::physics {
    enum GateType {
        Both = 0,
        EnterA = 1,
        EnterB = 2,
    };
}
namespace via::motion::detail::MotionFsm2TransitionData {
    enum StartType {
        Frame = 0,
        NormalizedTime = 1,
        SyncTime = 2,
        AutoSyncTime = 3,
        AutoSyncTimeSamePointCount = 4,
    };
}
namespace app::CH8Em4500::Action::CH8StrikeToParry {
    enum StrikeType {
        Right = 0,
        Left = 1,
    };
}
namespace via::motion {
    enum RetargetRigFlipFlag {
        Direction = 1,
        UpVector = 2,
    };
}
namespace via::render::layer::CubemapCapture {
    enum BAKEOPTION {
        NONE = 0,
        BOUNCE_PROBE_ENABLE = 1,
        FULL_ILLUMINATION_ENABLE = 2,
    };
}
namespace via::render {
    enum GraphicsFeatures {
        None = 0,
        HMD = 1,
        InterlacedRendering = 2,
        ESRAM = 4,
        AsyncCompute = 8,
        HDRCurvePQ = 16,
        FastAsyncCompute = 32,
        CapableHDRCurvePQ = 64,
        EQAACheckerBoardRendering = 128,
        HardwareCBRIDBuffer = 256,
        LateCBRResolve = 512,
        UseIDBuffer = 256,
        UseCheckerBoard = 1024,
        FastCBRSetting = 640,
        DefaultCBRSetting = 128,
        PS4ProtCBRSetting = 896,
        NotSupportedPredicateRenderingOnBuffer = 4096,
        RayTracing = 8192,
        MeshShader = 16384,
        BindlessResource = 32768,
        SamplerFeedback = 65536,
        HFR = 131072,
        CapableHFR = 262144,
        UAVLIMIT24 = 524288,
        RayTracingLegacyMode = 1048576,
        RootConstantEnableOnPC = 2097152,
        TypedLoadR11G11B10FloatAndR10G10B10A2 = 4194304,
        UavOverlapSupported = 8,
        VendorAMD = 16777216,
        VendorNVIDIA = 33554432,
        VendorINTEL = 67108864,
        VendorUnkown = 0,
        Gen2 = 268435456,
        Gen3 = 536870912,
        Gen4 = 1073741824,
        Gen5 = 2147483648,
        GL_Family = 134217728,
    };
}
namespace app::BirthdayFolderSelector {
    enum StageSetEnum {
        TypeA = 0,
        TypeB = 1,
        Common = 2,
        Max = 3,
    };
}
namespace via::render {
    enum PrimitiveShadingRate {
        Coarse1x1 = 0,
        Coarse1x2 = 1,
        Coarse2x1 = 2,
        Coarse2x2 = 3,
        Coarse2x4 = 4,
        Coarse4x2 = 5,
        Coarse4x4 = 6,
        Lowest = 0,
        Fast = 3,
        Default = 3,
    };
}
namespace via {
    enum SystemServiceEnterButtonAssign {
        RRight = 0,
        RDown = 1,
    };
}
namespace via::areamap::AreaConnectionObject {
    enum ConnectionState {
        Open = 0,
        Locked = 1,
        Closed = 2,
    };
}
namespace via::behaviortree::Action {
    enum MethodImpls {
        AppendedUpdateStart = 1,
        AppendedUpdate = 2,
        Start = 4,
        Update = 8,
        End = 16,
        OnNodeEndNotified = 32,
    };
}
namespace via::vr::psCamera {
    enum PSCameraFrameStatus {
        Active = 0,
        NotActive = 1,
        AlreadyRead = 2,
        NotStable = 3,
        InvalidFrame = 4,
        InvalidMetaData = 5,
    };
}
namespace app::GenomeCodexGUI {
    enum RadarNoiseLvDef {
        None = 0,
        Lv1 = 1,
        Lv2 = 2,
    };
}
namespace app::AI::AIFollowPointManager {
    enum PriorityType {
        MostHigh = 0,
        High = 1,
        Middle = 2,
        Low = 3,
        MostLow = 4,
    };
}
namespace app::Em4200::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::Em8001::Action::Base {
    enum SequenceEndType {
        None = 0,
        ActionEnd = 1,
        NextState = 2,
    };
}
namespace via::render::SoftBloom {
    enum Algorithm {
        Standard = 0,
        StandardV2 = 1,
        StandardV3 = 2,
        CoDAW = 3,
    };
}
namespace app::EnemyActionController {
    enum DamageParts {
        Body = 0,
        Head = 1,
        LeftArm = 2,
        RightArm = 3,
        LeftLeg = 4,
        RightLeg = 5,
    };
}
namespace via::render {
    enum GlobalSparseShadowResolution {
        GlobalSparseShadowResolution_64 = 64,
        GlobalSparseShadowResolution_128 = 128,
        GlobalSparseShadowResolution_256 = 256,
        GlobalSparseShadowResolution_512 = 512,
        GlobalSparseShadowResolution_1K = 1024,
    };
}
namespace app::FileData {
    enum SKUType {
        All = 0,
        Original = 1,
        CeroD_CeroZ = 2,
    };
}
namespace via::render {
    enum StencilValue {
        Zero = 0,
        All = 255,
        SceneBeauty = 1,
        SceneSubsurface = 2,
        IgnoreDepthMesh = 4,
        MaskIgnoreDepthMesh = 8,
        IgnoreDepthStencilValueWrite = 16,
    };
}
namespace via::render {
    enum OptionFlag {
        None = 0,
        TextureCube = 4,
        DrawIndirectArgs = 16,
        BufferAllowRawViews = 32,
        BufferStructured = 64,
        DX11Mask = 255,
        HTile = 256,
        HTileResolveToShadowMmeory = 512,
        DisableWithoutDecompress = 1024,
        CPUReadableResource = 2048,
        LinearLayout = 4096,
        NoZeroFill = 8192,
        DeltaColorCompression = 16384,
        NoCompression = 32768,
        MemoryBankRotation1 = 65536,
        MemoryBankRotation2 = 131072,
        MemoryBankRotation3 = 262144,
        MemoryBankRotationMask = 458752,
        SimultaneousAccess = 524288,
        ZCullStoreBuffer = 1048576,
        AdaptiveZCull = 2097152,
        VideoDecode = 16777216,
        AccelerationStructure = 33554432,
        ReservedResource = 67108864,
        ReservedFull = 134217728,
        BindlessResource = 268435456,
        ExecuteTimingNormal = 2147483648,
        ExecuteTimingPrecede = 1073741824,
        GPUReadOnly = 536870912,
    };
}
namespace app::CH9Em6400ArmController {
    enum ArmType {
        Default = 0,
        Extend = 1,
    };
}
namespace via::gui {
    enum ResolutionAdjustScale {
        None = 0,
        Stretch = 1,
        FitSmallRatioAxis = 2,
        FitLargeRatioAxis = 3,
        Max = 4,
    };
}
namespace app::CH9Em5700::Goal::Attack {
    enum Type {
        Stab = 0,
        Strike = 1,
    };
}
namespace app::CH8HUDControl::AirGauge {
    enum EventKeyItem {
        None = 0,
        NightVision = 1,
        AirFilter = 2,
    };
}
namespace via::Serializer::SerializeType {
    enum Kind {
        Default = 0,
        Array = 1,
        List = 2,
        Nullable = 3,
    };
}
namespace app::Em3000::Action::Turn {
    enum Type {
        Fast = 0,
        Move = 1,
    };
}
namespace via::AnimationCurveData3D {
    enum Wrap {
        Once = 0,
        Loop = 1,
        Loop_Always = 2,
    };
}
namespace via::Window::MessageArgs {
    enum ImeEvent {
        StartComposition = 0,
        UpdateComposition = 1,
        CompleteComposition = 2,
        RestartComposition = 3,
        EndComposition = 4,
        BeginCandidate = 5,
        UpdateCandidate = 6,
        EndCandidate = 7,
        Char = 8,
        ImeChar = 9,
    };
}
namespace via {
    enum SharePlayLevel {
        Full = 0,
        ScreenOnly = 1,
        None = 2,
    };
}
namespace via::Frustum {
    enum PlaneType {
        Left = 0,
        Right = 1,
        Top = 2,
        Bottom = 3,
        Near = 4,
        Far = 5,
    };
}
namespace via::wwise {
    enum EvaluatesEstimatedDurationType {
        None = 0,
        Minimum = 1,
        Maximum = 2,
    };
}
namespace app::CarInGarage {
    enum Layer {
        Body = 0,
        Roof = 1,
        Door = 2,
        Gear = 3,
        Seat = 4,
        Handle = 5,
    };
}
namespace via::render::layer {
    enum ForwardSolidSegment {
        ZIgnorePrepassSolid = 0,
        ZIgnorePrepassTwoSide = 1,
        ZIgnorePrepassTwoSideAlphaTest = 2,
        ZIgnorePrepassAlphaTest = 3,
        StencilPriorityZPrepass = 4,
        ZPrepassSolid = 5,
        ZPrepassTwoSide = 6,
        ZPrepassTwoSideAlphaTest = 7,
        ZPrepassAlphaTest = 8,
        ZPrepassVfx = 9,
        GeometryAO = 10,
        SSAO = 11,
        Solid = 12,
        TwoSide = 13,
        VelocitySolid = 14,
        VelocityTwoSide = 15,
        EmissiveSolid = 16,
        EmissiveTwoSide = 17,
        MeshDecal = 18,
        SolidVfx = 19,
        AfterDepthConfirmed = 20,
        ZIgnoreStencilSolid = 21,
        ZIgnoreStencilTwoSide = 22,
        ZIgnoreStencilTwoSideAlphaTest = 23,
        ZIgnoreStencilAlphaTest = 24,
        PostFill = 25,
    };
}
namespace via::gui::Capture {
    enum CaptureAction {
        Idle = 0,
        Clear = 1,
        Capture = 2,
    };
}
namespace via::effect::detail {
    enum DistortionType {
        Blur = 0,
        Refract = 1,
        BlurTexture = 2,
    };
}
namespace via::render::command::MultiDrawIndexedInstancedIndirectCount {
    enum HINT {
        NONE = 0,
        PREDICATE = 1,
    };
}
namespace via::hid {
    enum TouchScreenState {
        Move = 0,
        Down = 1,
        Up = 2,
        Miss = 3,
    };
}
namespace app::Em3100::Action::Dead {
    enum Type {
        Default = 0,
        DeadWait = 1,
    };
}
namespace app::ItemBoxLotteryManagerIMD {
    enum ItemBoxType {
        BombBox = 0,
        NormalBox = 1,
        RareBox = 2,
        SuperRareBox = 3,
        LegendaryBox = 4,
    };
}
namespace via::dynamics::DefinitionResource {
    enum ChannelAttribute {
        InitialValue = 0,
        Max = 1,
    };
}
namespace app::WeaponChainSaw {
    enum LampState {
        Unknown = 0,
        Run = 1,
        Caution = 2,
        Stall = 3,
    };
}
namespace Em5400Effect {
    enum IDAlias {
        WingBlur = 0,
        DisperseDead = 1,
        BurnDead = 2,
    };
}
namespace via::effect::detail {
    enum ExternType {
        Float = 0,
        Color = 1,
        LimitedFloat = 2,
        Bool = 3,
    };
}
namespace app::WeaponGrenadeLauncherAppend {
    enum PartsState {
        Default = 0,
        ReloadFlame = 1,
        ReloadAcid = 2,
        ChangeModeToFlame = 3,
        ChangeModeToAcid = 4,
    };
}
namespace app::fsm::ChangeDamageGUI {
    enum SaturationType {
        NotSet = 0,
        FullColor = 1,
        Monochrome = 2,
    };
}
namespace app::PadManager {
    enum PadNo {
        Pad1 = 0,
        Pad2 = 1,
        PadMax = 2,
    };
}
namespace via::gui {
    enum ParameterType {
        Invalid = 0,
        Bool = 1,
        Integer = 2,
        UnsignedInt = 3,
        Float = 4,
        String = 5,
        Enum = 6,
        Asset = 7,
        Uint2 = 8,
        Uint3 = 9,
        Uint4 = 10,
        Int2 = 11,
        Int3 = 12,
        Int4 = 13,
        Float2 = 14,
        Float3 = 15,
        Float4 = 16,
        Rect = 17,
        Color = 18,
        MessageId = 19,
        State = 20,
        ColorPreset = 21,
        ObjectPath = 22,
    };
}
namespace via::motion::IkLookAt {
    enum DistanceState {
        None = 0,
        Follow = 1,
    };
}
namespace app::Em4100::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
        Air = 2,
    };
}
namespace app::OptionMenu {
    enum ModeDef {
        MainMenu = 0,
        MainMenu_VR = 1,
        Ingame = 2,
        IngameTitle_VR = 3,
    };
}
namespace app::AdaptiveResolutionControl {
    enum ResolutionTypeEnum {
        FHD_1080 = 0,
        HD_900 = 1,
        HD_720 = 2,
        X68000_512 = 3,
    };
}
namespace app::ItemIconUtil::ItemIconController {
    enum State {
        Default = 0,
        Combine = 1,
        Improper = 2,
        Hold = 3,
        Focus = 4,
        UnFocus = 5,
        Disable = 6,
        DisableFocus = 7,
        DisableUnFocus = 8,
    };
}
namespace via::houdini {
    enum RenderType {
        WireFrame = 0,
        Default = 1,
    };
}
namespace app::WireTrap {
    enum State {
        Wait = 0,
        WireHit = 1,
        Explosion = 2,
        Broken = 3,
    };
}
namespace via::render::ToneMapping {
    enum AutoExposureReferenceLuminance {
        Maximum = 0,
        Average = 1,
    };
}
namespace app::EPVExpertObjectLandingData {
    enum ZDirectionType {
        AttackDirection = 0,
        SawRotation = 1,
    };
}
namespace via::render {
    enum HMDResolutionType {
        None = 0,
        FillAfterLighting = 1,
        FillAfterTransparent = 2,
    };
}
namespace System {
    enum ConsoleColor {
        Black = 0,
        DarkBlue = 1,
        DarkGreen = 2,
        DarkCyan = 3,
        DarkRed = 4,
        DarkMagenta = 5,
        DarkYellow = 6,
        Gray = 7,
        DarkGray = 8,
        Blue = 9,
        Green = 10,
        Cyan = 11,
        Red = 12,
        Magenta = 13,
        Yellow = 14,
        White = 15,
    };
}
namespace app::CH9Em7800ActionController::BattleCondition {
    enum WanderIdleActionType {
        None = 0,
        AfterNotice = 1,
        BeforeNotice = 2,
    };
}
namespace via::clr {
    enum MethodExceptionFlag {
        MethoExceptionFlag_Exception = 0,
        MethoExceptionFlag_Filter = 1,
        MethoExceptionFlag_Finaly = 2,
        MethoExceptionFlag_Fault = 3,
    };
}
namespace app::CH8Em4500::Action::CH8BackWalk {
    enum BackWalkType {
        Standard = 0,
        RequestNextAction = 1,
    };
}
namespace app::CH9Em7500::Action {
    enum ActionNo {
        Appear = 4,
        Dive = 5,
        Underwater = 6,
        AttackPounce = 7,
        AttackTurn = 8,
        Grapple = 9,
        Suspend = 10,
        Resume = 11,
    };
}
namespace app::fsm::CheckDoorState {
    enum CheckType {
        Locked = 0,
        ManualClose = 1,
        ManualClosed = 2,
        ManualOpen = 3,
    };
}
namespace app::Em3000::Action::Chapter3Battle1Final_Damage {
    enum Type {
        NoDamage = 0,
        RunOverR = 1,
        RunOverL = 2,
        RunOverRSide = 3,
        RunOverLSide = 4,
    };
}
namespace app::MoldedActionController {
    enum Tension {
        Normal = 0,
        Excite = 1,
        Anger = 2,
    };
}
namespace app::CH9ThrowingWp1800 {
    enum UpdateRno {
        Wait = 0,
        Move = 1,
        HitWall = 2,
        HitDoor = 3,
        HitBreakWall = 4,
        HitBreakFloor = 5,
        HitEnemy = 6,
        AttacheDeadBody = 7,
        DiveGround = 8,
        BrokenWait = 9,
        HitBrokenWallWait = 10,
        Sleep = 11,
    };
}
namespace app::Em4200::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::fsm::PositionCheck {
    enum DistCompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace via::render {
    enum LightPowerUnitType {
        Lumen = 0,
        Candela = 1,
        None = 2,
    };
}
namespace app::CH9Em6400ArmController {
    enum EntryEffectId {
        ChangeExtendShort = 0,
        ChangeEnd = 1,
        Cancel = 2,
    };
}
namespace System {
    enum DayOfWeek {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    };
}
namespace app::CH8Em4400::CH8ThinkStateSet {
    enum Type {
        Default = 0,
        Fixed = 1,
        Wanderer = 2,
        Wait = 3,
        Elevator = 4,
    };
}
namespace app::GameManager {
    enum ChapterJumpState {
        None = 0,
        StampSave = 1,
        CloseStart = 2,
        OpenStart = 3,
        OpenEnd = 4,
        PlayerLoad = 5,
        DataSet = 6,
        Exit = 7,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraCaptureMemoryType {
        Onion = 1,
        Garlic = 2,
    };
}
namespace via::movie::Movie {
    enum LoadResourceState {
        StartProcessing = 0,
        WaitingForResourceValidation = 1,
        AcceptedCreatePlayer = 2,
        AcceptedWaitPlayerCreation = 3,
        AcceptedInitializeFileBuffer = 4,
        AcceptedWaitForLibraryInitialization = 5,
        ErrorResourceValidation = 6,
        ErrorLibraryStartup = 7,
    };
}
namespace via::hid {
    enum NpadHandheldActivationMode {
        Dual = 0,
        Single = 1,
        None = 2,
    };
}
namespace app::fsm::CH8SetDoorState {
    enum OverrideType {
        NotSet = 0,
        UseDefault = 1,
        Override = 2,
    };
}
namespace app::TabController {
    enum TabType {
        Item = 0,
        Skill = 1,
    };
}
namespace app::CH8Em4000::CH8ThinkAppearSet {
    enum MimicryType {
        Floor1 = 0,
        Floor2 = 1,
        Lean1 = 2,
        Lean2 = 3,
        Lean3 = 4,
    };
}
namespace via::eq::UnaryOperator {
    enum Type {
        Min = 0,
    };
}
namespace via::landscape {
    enum DecalReciveMode {
        Enable = 0,
        Disable = 1,
    };
}
namespace app::Em3000::Goal {
    enum GoalId {
        Discovery = 0,
        UnDiscovery = 1,
        Idle = 2,
        DestroyWall = 3,
        DestroyTable = 4,
        CutLeg = 5,
        AttackDave = 6,
        DrivePL = 7,
        Climax = 8,
        Rest = 9,
        AppearF = 10,
        AppearR = 11,
        AppearL = 12,
        _DO_NOT_USE_AppearEm8000 = 13,
        Chapter3Battle1 = 14,
        Chapter3Battle1Final = 15,
        Chapter3Battle2 = 16,
        _DO_NOT_USE_Chapter3Battle2Final = 17,
        Wander = 18,
        DebugWalk = 19,
        _None = 20,
        Appear = 21,
        Em8000 = 22,
        Em8000Evacuate = 23,
        Em8000KneeDown = 24,
        _DO_NOT_USE_Em8000Appear = 25,
        AppearLookWindow = 26,
        Chapter3Battle1FinalEnd = 27,
        Chapter3Battle2FinalEnd = 28,
    };
}
namespace app::fsm::ItemTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace via::gui {
    enum MaskMode {
        Keep = 0,
        Default = 1,
        Reverse = 2,
        Disable = 3,
        ApplyToParent = 4,
    };
}
namespace via::network::AutoMatchmaking {
    enum MatchPhase {
        Phase_None = 0,
        Phase_Init = 1,
        Phase_CreateSession = 2,
        Phase_CreateWait = 3,
        Phase_SetSearchRule = 4,
        Phase_SearchReady = 5,
        Phase_SearchSession = 6,
        Phase_SearchWait = 7,
        Phase_ThinkRule = 8,
        Phase_GiveupSession = 9,
        Phase_GiveupWait = 10,
        Phase_RebootSession = 11,
        Phase_JoinSession = 12,
        Phase_JoinWait = 13,
        Phase_SyncAttribute = 14,
        Phase_AcceptWait = 15,
        Phase_InGame = 16,
        Phase_SearchInterval = 17,
        Phase_Timeout = 18,
        Phase_TimeoutWait = 19,
        Phase_Release = 20,
        Phase_Fatal = 21,
        Phase_XboxInit = 22,
        Phase_XboxInitWait = 23,
        Phase_XboxMatchWait = 24,
        Phase_XboxMatchWait2 = 25,
        Phase_XboxMatchStop = 26,
        Phase_XboxMatchStopWait = 27,
    };
}
namespace via::motion::detail::IkNboneSolver {
    enum weightType {
        Basic = 0,
        Top = 1,
        Bottom = 2,
        Medium = 3,
    };
}
namespace hikako::ActivityManager {
    enum ActivityOutcome {
        COMPLETED = 0,
        FAILED = 1,
        ABANDONED = 2,
    };
}
namespace via::gui {
    enum GenderType {
        Male = 0,
        Female = 1,
        Unknown = 2,
    };
}
namespace app::Em3100::Action::DLC_TestAction {
    enum Type {
        OrderBugHoleInstructEnd = 0,
        OrderBusInstructEnd = 1,
        OrderStun = 2,
    };
}
namespace via::behaviortree::TreeNode {
    enum WorkStatus {
        Off = 0,
        Start = 1,
        Work = 2,
        Ignore = 3,
    };
}
namespace via::network::error {
    enum CauseStorage {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        FileNotFound = 129,
        Unavailable = 130,
    };
}
namespace via::navigation::AIMapEffector {
    enum EdgePrecisionType {
        x1 = 0,
        x10 = 1,
        x100 = 2,
    };
}
namespace via::vr {
    enum VrModeStatus {
        Invalid = 0,
        Unavailable = 1,
        Available = 2,
        Initializing = 3,
        Running = 4,
        Finished = 5,
    };
}
namespace app::WwisePrefabInitiationTriggerElement {
    enum DeleteTypeEnum {
        Trigger = 0,
        Timer = 1,
    };
}
namespace app::Collision {
    enum PartsType {
        Default = 0,
        Head = 1,
        Chest = 2,
        Stomach = 3,
        ArmUpper = 4,
        ArmLower = 5,
        LegThigh = 6,
        LegShin = 7,
        User00 = 8,
        User01 = 9,
        User02 = 10,
        User03 = 11,
        User04 = 12,
        User05 = 13,
        User06 = 14,
        User07 = 15,
        User08 = 16,
        User09 = 17,
        User10 = 18,
        User11 = 19,
        User12 = 20,
        User13 = 21,
        User14 = 22,
        User15 = 23,
        User16 = 24,
        User17 = 25,
        User18 = 26,
        User19 = 27,
    };
}
namespace via::ModalDialogService {
    enum ModalDialogState {
        Uninitialized = 0,
        Ready = 1,
        Opening = 2,
        Opened = 3,
        Closing = 4,
    };
}
namespace via::audiorender {
    enum Channel_714ch {
        L = 0,
        R = 1,
        C = 2,
        LFE = 3,
        Lrs = 4,
        Rrs = 5,
        Ls = 6,
        Rs = 7,
        Ltf = 8,
        Rtf = 9,
        Ltr = 10,
        Rtr = 11,
        Max = 12,
    };
}
namespace app::Em3600::Em3600WwiseMonitoredValue {
    enum PropertyLayer {
        Low = 0,
        High = 1,
    };
}
namespace via::landscape::beta {
    enum BlendTypeEnum {
        Adaptive = 0,
        Bilinear = 1,
        NoBlend = 2,
        Max = 3,
    };
}
namespace app::GameManager {
    enum StoreTypeEnum {
        Normal = 0,
        TrialVer = 1,
        BannedFootage = 2,
        NotaHero = 3,
        BannedFootage1 = 4,
        BannedFootage2 = 5,
        Chapter9 = 6,
    };
}
namespace app::CH9Em5850 {
    enum ThinkState {
        None = 0,
        NoLostPlayer = 1,
    };
}
namespace via::motion {
    enum InterpolationMode {
        None = 0,
        FrontFade = 1,
        CrossFade = 2,
        SyncCrossFade = 3,
        SyncPointCrossFade = 4,
        FrontOffsetFade = 5,
        InertiaFade = 6,
        FrontSpeedFade = 7,
    };
}
namespace via::render::Bloodshed {
    enum SourceUV {
        Primary = 0,
        Secondary = 1,
    };
}
namespace app::CraftBenchUIAsset {
    enum SelectItemState {
        DEFAULT = 0,
        FOCUS = 1,
        SELECT = 2,
        UNFOCUS = 3,
        DISABLE = 4,
        DISABLE_FOCUS = 5,
        DISABLE_SELECT = 6,
        DISABLE_UNFOCUS = 7,
        DECIDE = 8,
    };
}
namespace app {
    enum ExtraRegionType {
        Unknown = 0,
        German = 1,
    };
}
namespace app::Em2000::Em2000ActionController {
    enum Chapter4Stamp {
        None = 0,
        Separate = 1,
        Battle = 2,
    };
}
namespace via::gui::detail {
    enum RectVertex {
        LeftTop = 0,
        LeftBottom = 1,
        RightTop = 2,
        RightBottom = 3,
        Max = 4,
    };
}
namespace via::motion::tree::BaseSyncBlendNode {
    enum SyncBlendType {
        Normal = 0,
        Weight = 1,
    };
}
namespace via::motion::ChainResource {
    enum LegacyVersion {
        Latest = 0,
        Legacy1 = 1,
    };
}
namespace via::hid {
    enum ControllerSupportResult {
        None = 0,
        Done = 1,
        Canceled = 2,
        Failed = 3,
    };
}
namespace via::effect::gpgpu::detail {
    enum FieldType {
        None = 0,
        Vector = 1,
        Volume = 2,
        GlobalVectorOnly = 3,
    };
}
namespace via::motion::tree::CompareNode {
    enum Operation {
        Eq = 0,
        Neq = 1,
        Ge = 2,
        Le = 3,
        Gt = 4,
        Lt = 5,
    };
}
namespace via {
    enum SystemServiceAccountPickerResult {
        Success = 0,
        Cancel = 1,
        Failed = 2,
    };
}
namespace app::PlayerCamera {
    enum RotationType {
        Incremental = 0,
        Angular = 1,
    };
}
namespace app::Em3102::Em3102WwiseStateList {
    enum PropertyStealth {
        UnDiscovery = 0,
        Discovery = 1,
    };
}
namespace via::simplewwise {
    enum ListenerBitMask {
        ListenerBitMask_0 = 1,
        ListenerBitMask_1 = 2,
        ListenerBitMask_2 = 4,
        ListenerBitMask_3 = 8,
        ListenerBitMask_4 = 16,
        ListenerBitMask_5 = 32,
        ListenerBitMask_6 = 64,
        ListenerBitMask_7 = 128,
    };
}
namespace via::simplewwise {
    enum PriorityMode {
        Newest = 0,
        Oldest = 1,
    };
}
namespace app::Havok::ClothWind::Wave {
    enum WaveForm {
        WaveType_Sin = 0,
        WaveType_Saw = 1,
        WaveType_RevSaw = 2,
        WaveType_Square = 3,
        WaveType_Tri = 4,
        WaveType_Noise = 5,
    };
}
namespace app::EnemySlipParameter {
    enum Type {
        Fire = 0,
        Acid = 1,
        Invalid = -1,
    };
}
namespace app::AI::AIWanderHelper {
    enum EvaluateType {
        Random = 0,
        Nearest = 1,
        Farest = 2,
    };
}
namespace via::render {
    enum SparseTexturePriority {
        High = 0,
        Normal = 1,
        Low = 2,
    };
}
namespace via::navigation {
    enum WarningType {
        StartNodeNotFound = 0,
        EndNodeNotFound = 1,
        PathNotFound = 2,
        PathfindInterrupt = 3,
        InvalidHybridPath = 4,
        WarningTypeNum = 5,
    };
}
namespace via {
    enum SystemServiceCpuBoostMode {
        Normal = 0,
        FastLoad = 1,
    };
}
namespace app::CH8VoiceOxygenRemainingAmount::CH8VoiceParam {
    enum ConditionTable {
        Air20 = 0,
        Air30 = 1,
        Air50 = 2,
    };
}
namespace app::GenomeCodexGUI {
    enum CommuStateDef {
        Call = 0,
        Incoming = 1,
        Talking = 2,
        EndTalking = 3,
        EndTalkingCutOff = 4,
        Disable = 5,
    };
}
namespace via::render::Strands {
    enum SimulationStrandSize {
        STRAND_SIZE_8 = 0,
        STRAND_SIZE_16 = 1,
        STRAND_SIZE_32 = 2,
    };
}
namespace via::gui::MaterialBinding {
    enum BindingError {
        None = 0,
        InvalidMaterial = 1,
        InvalidClusterName = 2,
        InvalidParamName = 4,
        InvalidType = 8,
    };
}
namespace app::Em3102::Action {
    enum ActionNo {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Turn = 3,
        Grapple = 4,
        DoorOpen = 5,
        Sane = 6,
        Grasp = 7,
        Lost = 8,
        InsaneStart = 9,
        InsaneEnd = 10,
        Branch = 11,
        Search = 12,
        Stop = 13,
    };
}
namespace app::Richpresence {
    enum CH9ProgressType {
        InGame = 0,
        Menu = 1,
        Invalid = -1,
    };
}
namespace app::StampController {
    enum Type {
        Blood = 0,
        Scar = 1,
        Water = 2,
        Other = 3,
        Num = 4,
    };
}
namespace app::Em8910 {
    enum ThinkState {
        None = 0,
    };
}
namespace via::landscape {
    enum GroundDevelopLayerSegment {
        WireFrame = 1,
        FillWireFrame = 2,
        MaterialDebug = 16,
        LodDebug = 17,
        NormalDebug = 18,
    };
}
namespace app::CH8Em4500::CH8ThinkStateSet {
    enum Type {
        Default = 0,
        Wait = 1,
    };
}
namespace app::Em8000::Wind {
    enum WindTag {
        None = 0,
        Corpsebag_Idle = 1,
        Corpsebag_Damage_Weak = 2,
        Corpsebag_Damage_Strong = 3,
        Corpsebag_Motion_Weak = 4,
        Corpsebag_Motion_Strong = 5,
    };
}
namespace via::ffts {
    enum ErrType {
        None = 0,
        Critical = -1,
        NoMemory = -2,
        Forceword = 2147483647,
    };
}
namespace app::CH9Em7900::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace via::motion::ActorMotion {
    enum StartFrameMode {
        CurrentFrame = 0,
        KeyOriginFrame = 1,
    };
}
namespace app::GenomeCodexGUISimple {
    enum Mode {
        HP = 0,
    };
}
namespace app::PlayerMeshTag {
    enum MeshID {
        Unknown = 0,
        UpperBody = 1,
        LowerBody = 2,
        LArm = 3,
        RArm = 4,
        Head = 5,
        UpperBodyShadow = 11,
        LowerBodyShadow = 12,
        LArmShadow = 13,
        RArmShadow = 14,
        HeadShadow = 15,
        Codex = 20,
    };
}
namespace app::GameManager {
    enum GameOverMainRno {
        MonochromeStart = 0,
        DimAndGUIStart = 1,
        InputWait = 2,
        RestartFade = 3,
        Restart = 4,
        RestartEndCheck = 5,
        RestartErrorWait = 6,
        QuitFade = 7,
        Quit = 8,
        BirthdayWait = 9,
        BirthdayResultFade = 10,
        BirthdayResult = 11,
        Chapter7Restart = 12,
        Chapter7Result = 13,
        Chapter7ResultWait = 14,
        Chapter7Quit = 15,
        Chapter3_IMD_Restart = 16,
        Chapter3_IMD_Quit = 17,
        Chapter9_Quit = 18,
        End = 19,
    };
}
namespace app::Collision::CollisionSystem::HitResult {
    enum PlaneType {
        None = 0,
        Ground = 1,
        Slope = 2,
        Wall = 3,
        Ceiling = 4,
    };
}
namespace app::Em8001::IK::ProcessBase {
    enum TransitionChangeState {
        INVALID = -1,
        None = 0,
        Up = 1,
        Down = 2,
        SUM = 3,
    };
}
namespace app::Em8000::Message {
    enum TagRandomGroup {
        None = 0,
        DeathScissorsAttack = 1,
        GrappleBattleOfSaw = 2,
        CoreRecovery = 3,
        PlayerChainsawStop = 4,
    };
}
namespace via::render::AlphaAA {
    enum AntialiasingMethod {
        FXAA = 0,
        SMAA1x = 1,
        SMAAT2x = 2,
    };
}
namespace app::CH9Em7900::Action::Grapple {
    enum Type {
        Mount = 0,
    };
}
namespace app::Em8100::Goal::Battle {
    enum Message {
        Non = 0,
        AppearEnd = 1,
        Battle1 = 2,
        Battle2 = 3,
        Battle3 = 4,
    };
}
namespace app::CH9Em7700::Action::Strike {
    enum Type {
        Normal = 0,
        Backstep = 1,
        Slash = 2,
        DoubleBlade = 3,
        Horizontal = 4,
        HorizontalBackstep = 5,
        Vertical = 6,
        FirstAttack = 7,
    };
}
namespace via::os {
    enum FileOptionalAttr {
        Create = 1,
        Append = 2,
        Trunc = 4,
        Sync = 8,
    };
}
namespace via::effect::detail {
    enum LinePreset {
        Follow = 0,
        Length = 1,
        Chain = 2,
    };
}
namespace app::vr {
    enum VrMode {
        None = 0,
        Stereo = 1,
        Screen = 2,
    };
}
namespace app::FF030_Ex_MainMenu {
    enum Step {
        GoNext = 0,
        Option = 1,
        Main = 2,
    };
}
namespace app::CH9Em7550Think {
    enum eMotionState {
        Idle = 0,
        Attack = 1,
    };
}
namespace via::render::SSRControl {
    enum SSRResolvePointNum {
        SSRResolvePointNum_1 = 0,
        SSRResolvePointNum_2 = 1,
        SSRResolvePointNum_4 = 2,
    };
}
namespace via::motion::SubExJointRemapOutput {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace app::CH8VoiceHealthRemaining::CH8VoiceParam {
    enum ConditionTable {
        Health20 = 0,
        Health50 = 1,
    };
}
namespace via::hid::VrTrackerResultData {
    enum RearStatus {
        NotReady = 0,
        Ready = 1,
        NotSupported = 2,
    };
}
namespace app::Em8900 {
    enum ThinkState {
        None = 0,
        Battle = 1,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum ReprojectionType {
        Default = 0,
        WithOverlay = 1,
    };
}
namespace app::InteractObjectBase {
    enum NarrativeSoundType {
        None = 0,
        Icon = 1,
        Icon_EV0 = 2,
        Icon_EV1 = 3,
        Icon_EV2 = 4,
        Icon_EV3 = 5,
        Message = 6,
        Message_EV0 = 7,
        Message_EV1 = 8,
        Message_EV2 = 9,
        Message_EV3 = 10,
        FileMessage = 11,
        FileMessage_EV0 = 12,
        FileMessage_EV1 = 13,
        FileMessage_EV2 = 14,
        FileMessage_EV3 = 15,
    };
}
namespace app::BirthdayBlasterManager {
    enum RTPC_BGM_Type_Enum {
        SPEED_Lv1 = 0,
        SPEED_Lv2 = 1,
        SPEED_Lv3 = 2,
        Reset = 3,
        Max = 4,
    };
}
namespace app::vr {
    enum PlayerMoveSpeed {
        Default = 0,
        Slowish = 1,
        Slow = 2,
    };
}
namespace via::behaviortree {
    enum RestartType {
        ExecuteOn = 0,
        ExecuteOff = 1,
        UseResource = 2,
        Ignore = 3,
    };
}
namespace app::VideoControl {
    enum VideoTypeDef {
        Normal = 0,
        TitleMovie = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum LargeDamageReactionTable {
        Large_F = 1000,
        Large_L = 1001,
        Large_R = 1002,
    };
}
namespace via::render::command::VKExtension {
    enum ExtensionType {
        NewRenderpass = 0,
        NewRenderpassClear = 1,
        PipelineBarrierComputeToTransfer = 2,
    };
}
namespace via::sound::GameParameterRequest {
    enum Type {
        None = 0,
        Set = 1,
        SetFloat = 2,
        Delete = 3,
    };
}
namespace app::CraftBenchUIAsset {
    enum IconPanelState {
        ITEM_L = 0,
    };
}
namespace via::effect::detail {
    enum OrientDirectionType {
        None = 0,
        Forward = 1,
        Backward = 2,
    };
}
namespace via::motion::JointInfoRef {
    enum AttrFlags {
        EnableEmptyInterpolation = 1,
        PropertyAnimation = 2,
        EnableTransPolarBlend = 4,
    };
}
namespace app::CharacterDefine {
    enum Condition {
        Normal = 0,
        Angry = 1,
        Dying = 2,
        Fear = 3,
        Weak = 4,
        Anything = 5,
    };
}
namespace app::CH9Em5850FollowBug {
    enum State {
        Normal = 0,
        Attack = 1,
        Return = 2,
        Damage = 3,
        Dead = 4,
        Born = 5,
        Gather = 6,
        Leave = 7,
        Suspend = 8,
    };
}
namespace app::Em5400::Goal::Attack {
    enum Type {
        Stab = 0,
        Strike = 1,
    };
}
namespace app::GrappleBase {
    enum ProcessType {
        None = 0,
        MotionWait = 1,
        MotionPlay = 2,
        MotionEnd = 3,
    };
}
namespace via::motion::CppSampleChild {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
    };
}
namespace app::PlayerDamageController {
    enum DamageDirection {
        Unknown = 0,
        FL = 1,
        FR = 2,
        LF = 3,
        LB = 4,
        RF = 5,
        RB = 6,
        B = 7,
    };
}
namespace app::fsm::CH8NoSaveValueControl {
    enum ControlTypeEnum {
        Set = 0,
        Check = 1,
    };
}
namespace via::render::LightVolumeDecal {
    enum NormalRoughnessMapType {
        Normal = 0,
        NormalRoughness = 1,
    };
}
namespace via::effect::detail {
    enum FrontDirection {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace via::hid::PortInfo {
    enum StateThread {
        None = 0,
        Uninitialized = 1,
        Initializing = 2,
        Idle = 3,
        Executing = 4,
        Terminated = 5,
        Max = 6,
    };
}
namespace via::effect::detail {
    enum NodeBillboardShapeType {
        Box = 0,
        Sphere = 1,
        Num = 2,
    };
}
namespace via::storage::saveService {
    enum SaveDataEncryptionType {
        None = 0,
        AutoStrong = 1,
        XOR = 2,
        BlowFish = 3,
        RdsModule = 4,
    };
}
namespace System::Runtime::CompilerServices {
    enum CompilationRelaxations {
        NoStringInterning = 0,
    };
}
namespace app::Em8940::Action {
    enum ActionNo {
        Idle = 0,
        Damage = 1,
        Dead = 2,
        Appear = 3,
    };
}
namespace System {
    enum AttributeTargets {
        Assembly = 1,
        Module = 2,
        Class = 4,
        Struct = 8,
        Enum = 16,
        Constructor = 32,
        Method = 64,
        Property = 128,
        Field = 256,
        Event = 512,
        Interface = 1024,
        Parameter = 2048,
        Delegate = 4096,
        ReturnValue = 8192,
        All = 16383,
    };
}
namespace via::effect {
    enum BindingType {
        Joint = 0,
    };
}
namespace app::Em3002::Goal {
    enum AttackMessageStatus {
        Non = 0,
        Hit = 1,
        UnHit = 2,
        Guard = 3,
    };
}
namespace app::CH9Em7500::Action::Suspend {
    enum Type {
        Normal = 0,
        SelfDie = 1,
        Hide = 2,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum Bounce {
        Bounce_0 = 0,
        Bounce_1 = 1,
        Bounce_2 = 2,
        Bounce_3 = 3,
        Bounce_7 = 4,
    };
}
namespace via::vr::psCamera {
    enum PSCameraCaptureWaitFrameType {
        OnMode0 = 0,
        OffMode0 = 1,
        OnMode1 = 2,
        OffMode1 = 3,
    };
}
namespace via::fsm {
    enum TransitionAttribute {
        Warp = 0,
        IgnorePuppetMode = 1,
        TransitionAttributeBitNum = 32,
    };
}
namespace via::render::RenderTargetOperator {
    enum Op {
        None = 0,
        Add = 1,
        Multiply = 2,
        Maximum = 16,
        Minimum = 17,
    };
}
namespace via::hid {
    enum KeyboardDisplayKey {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8,
        I = 9,
        J = 10,
        K = 11,
        L = 12,
        M = 13,
        N = 14,
        O = 15,
        P = 16,
        Q = 17,
        R = 18,
        S = 19,
        T = 20,
        U = 21,
        V = 22,
        W = 23,
        X = 24,
        Y = 25,
        Z = 26,
        At = 27,
        BackQuote = 28,
        LeftSquareBracket = 29,
        LeftBrace = 30,
        SemiColon = 31,
        Plus = 32,
        Colon = 33,
        Asterisk = 34,
        RightSquareBracket = 35,
        RightBrace = 36,
        Comma = 37,
        LeftAngleBracket = 38,
        Period = 39,
        RightAngleBracket = 40,
        Slash = 41,
        Question = 42,
        BackSlash = 43,
        UnderScore = 44,
        Number0 = 45,
        Number1 = 46,
        Number2 = 47,
        Number3 = 48,
        Number4 = 49,
        Number5 = 50,
        Number6 = 51,
        Number7 = 52,
        Number8 = 53,
        Number9 = 54,
        KeybaordDisplayKey_Exclamation = 55,
        DoubleQuotation = 56,
        Sharp = 57,
        Dollar = 58,
        Percent = 59,
        Ampersand = 60,
        SingleQuotation = 61,
        LeftParenthesis = 62,
        RightParenthesis = 63,
        Minus = 64,
        Equal = 65,
        Caret = 66,
        Tilde = 67,
        Pipe = 68,
        Unknown = 0,
        NotSupported = -1,
    };
}
namespace via::gui::detail {
    enum ResolutionAdjust {
        StretchAlways = 0,
        StretchExpanding = 1,
        StretchShrinking = 2,
        FitSmallRatioAxisAlways = 3,
        FitSmallRatioAxisExpanding = 4,
        FitSmallRatioAxisShrinking = 5,
        FitLargeRatioAxisAlways = 6,
        FitLargeRatioAxisExpanding = 7,
        FitLargeRatioAxisShrinking = 8,
        None = 9,
        Max = 10,
    };
}
namespace via::render {
    enum FillMode {
        Wireframe = 1,
        Solid = 2,
        Num = 3,
    };
}
namespace app::Em4100::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Oilcan2 {
    enum OilcanSetType {
        Oilcan = 0,
        FakeBox = 1,
    };
}
namespace app::LightConditionManager {
    enum KindEnum {
        Day = 0,
        Night = 1,
        Midnight = 2,
        Max = 3,
    };
}
namespace via::nnfc::nfp {
    enum NfpSequence {
        None = 0,
        Detection = 1,
        GetTagInfo = 2,
        Mount = 3,
        GetNfpData = 4,
        OpenApplicationArea = 5,
        CreateApplicationData = 6,
        GetApplicationData = 7,
        WriteApplicationData = 8,
    };
}
namespace via::CoreEntry {
    enum CpuBoostMode {
        Normal = 0,
        FastLoad = 1,
    };
}
namespace app::CH9Em7900ActionPoint {
    enum Type {
        DropPoint = 0,
    };
}
namespace app::GrappleBase {
    enum ConstModeType {
        EnemyToPlayer = 0,
        PlayerToEnemy = 1,
    };
}
namespace app::CH9Em6700::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        UnDiscovery = 2,
        Discovery = 3,
        Idle = 4,
        Follow = 5,
        SideToSide = 6,
        SideMove = 7,
        Observe = 8,
        Lean = 9,
        Dodge = 10,
        ClawAttack = 11,
        IdleAction = 12,
        AppearAction = 13,
        MoveAction = 14,
        LeanAction = 15,
        DodgeAction = 16,
        AttackAction = 17,
    };
}
namespace via::landscape::beta {
    enum MaterialDebugTypeEnum {
        None = 0,
        SampleCount = 1,
        LocalUV = 2,
        TriplanarWeights = 3,
        SplatIndex = 4,
        Max = 5,
    };
}
namespace via::storage {
    enum CompressionAlgorithm {
        Deflate = 0,
    };
}
namespace app::Em3000::Action::Walk {
    enum Type {
        Normal = 0,
        Fire = 1,
        TNormal = 2,
    };
}
namespace app::ChainClothSelector {
    enum Type {
        Unknown = 0,
        Cloth = 1,
        Chain = 2,
        Other = 3,
    };
}
namespace via::render::command::NVNExtention {
    enum ExtentionType {
        ResolveDepthBuffer = 0,
        SetTiledCacheTileSize = 1,
        TiledCacheActionEnable = 2,
        TiledCacheActionDisable = 3,
        TiledCacheActionFlush = 4,
        TiledCacheActionFlushNoTiling = 5,
        TiledCacheActionEnableRenderTargetBinning = 6,
        TiledCacheActionDisableRenderTargetBinning = 7,
        SaveZCullData = 8,
        RestoreZCullData = 9,
    };
}
namespace app::CH8StateSwitchM6 {
    enum CHP8_6 {
        SILENCE = 0,
        BGM_CHP8_STORAGE_01 = 1,
        BGM_CHP8_STORAGE_01_END = 2,
        BGM_CHP8_STORAGE_EXPLORE = 3,
    };
}
namespace via::audiorender {
    enum Channel_71ch {
        L = 0,
        R = 1,
        C = 2,
        LFE = 3,
        Lrs = 4,
        Rrs = 5,
        Ls = 6,
        Rs = 7,
        Max = 8,
    };
}
namespace app {
    enum Group {
        Player = 0,
        Enemy = 1,
        Weapon = 2,
        Item = 3,
        Prop = 4,
        Etc = 5,
        Vfx = 6,
        Camera = 7,
        ActionPoint = 8,
        EventChara = 9,
        Souko = 10,
    };
}
namespace via::audiorender {
    enum EffectType {
        None = 0,
        LowPassFilter = 1,
        I3DL2Reverb = 2,
        ConvolutionReverb = 3,
        MTLimitter = 4,
        MTCompressor = 5,
        MTEqualizer = 6,
        MultiBandEq = 7,
        GetWaveOnBus = 8,
        Distortion = 9,
        SimpleFdnReverb = 10,
    };
}
namespace app::CH8StateSwitchM8 {
    enum CHP8_8 {
        SILENCE = 0,
        BGM_CHP8_LABO_EVENT = 1,
        BGM_CHP8_LABO_EVENT_AREA_END = 2,
        BGM_CHP8_LABO_EVENT_TEXT_END = 3,
    };
}
namespace app::FBIKAttackController {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace via::motion::IkTrain {
    enum TrainRotate {
        Default = 0,
        DiffRot = 1,
    };
}
namespace via::effect::detail {
    enum FrontDirectionType {
        ParallelCamera = 0,
        ToCamera = 1,
    };
}
namespace app::Em8100::Action::Grab {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
        BackR = 3,
        BackL = 4,
    };
}
namespace via::motion::IkLeg2 {
    enum FootLockMode {
        Auto = 0,
        SemiAuto = 1,
    };
}
namespace via::render::command::XB1Extention {
    enum ExtentionType {
        ExtentionType_PushToEsram = 0,
        ExtentionType_PopFromEsram = 1,
        ExtentionType_DmaTransfer_DtoE = 2,
        ExtentionType_DmaTransfer_EtoD = 3,
        ExtentionType_ResolveScratchShadow = 4,
        ExtentionType_CopyShadowCache = 5,
        ExtentionType_ResumarizeHTile = 6,
        ExtentionType_BeginCopyShadowCache = 7,
        ExtentionType_4KCheckerBoardRenderingEnable = 8,
        ExtentionType_4KCheckerBoardRenderingEvenFrameEnable = 8,
        ExtentionType_4KCheckerBoardRenderingOddFrameEnable = 9,
        ExtentionType_TemporalAntialiasing4KCheckerBoardRenderingEvenFrameEnable = 10,
        ExtentionType_TemporalAntialiasing4KCheckerBoardRenderingOddFrameEnable = 11,
        ExtentionType_4KCheckerBoardRenderingDisable = 12,
        ExtentionType_AlphaUnroll_Enable = 13,
        ExtentionType_AlphaUnroll_Disable = 14,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData::JointDriverData {
    enum CurveType {
        MinMax = 0,
        Function = 1,
        Scaling = 2,
    };
}
namespace via::dynamics {
    enum RigidBodyState {
        Disable = 0,
        Static = 1,
        KeyFramed = 2,
        Dynamic = 3,
        Phantom = 4,
        Invalid = 5,
        Max = 6,
    };
}
namespace app::WeaponShotgunAppend {
    enum PartsState {
        Default = 0,
        ReloadBefore = 1,
        ReloadAfter = 2,
        LastReloadBefore = 3,
        LastReloadAfter = 4,
    };
}
namespace via::gui::MessageTag {
    enum Attr {
        None = 0,
        PopEnd = 1,
        BaseColor = 2,
        Icon = 4,
        Ruby = 8,
        TCU = 16,
        IconMerge = 32,
    };
}
namespace via::effect::gpgpu::RibbonFollowCS::RibbonFollowResource {
    enum ShaderType {
        Default = 0,
        LuminanceBleed = 1,
        SimpleLuminanceBleed = 2,
        Default_IgnoreDepth = 3,
        LuminanceBleed_IgnoreDepth = 4,
        SimpleLuminanceBleed_IgnoreDepth = 5,
        StochasticPreZ = 6,
        StochasticTransparent = 7,
        MaxType = 8,
    };
}
namespace via::gui {
    enum GridCursorType {
        Fix = 0,
        Move = 1,
    };
}
namespace app::Em8000::Action::Em8000Damage {
    enum Type {
        INVALID = -1,
        NoDamage = 0,
        MHeadF = 1,
        MHeadB = 2,
        MHeadR = 3,
        MHeadL = 4,
        MBodyF = 5,
        MBodyB = 6,
        MBodyR = 7,
        MBodyL = 8,
        MidLegLC32F = 9,
        MidLegRC32F = 10,
        CorpsebagL = 11,
        CorpsebagR = 12,
        SUM = 13,
    };
}
namespace via::gui {
    enum UVValueType {
        Rect = 0,
        UV = 1,
        Legacy = 2,
    };
}
namespace via::physics::System::SearchCollisionInfo {
    enum SearchMaterialAttributeCondition {
        Equal = 0,
        And = 1,
        Or = 2,
        Not = 3,
        Xor = 4,
    };
}
namespace via::network::dev::NetworkDataLoggingInternal {
    enum Phase {
        None = 0,
        Idle = 1,
        Init = 2,
        ConnectReq = 3,
        ConnectWait = 4,
        Connected = 5,
        Release = 6,
    };
}
namespace via::areamap::test::DistanceToSelf {
    enum Condition {
        Mode_Closest = 0,
        Mode_Farthest = 1,
    };
}
namespace via::render::detail {
    enum PipelineStateType {
        Transparent = 0,
        TransparentIgnoreDepth = 1,
        DistortionDepth = 2,
        Solid = 3,
        SolidPreTransform = 4,
        Shadow = 5,
        DeferredLighting = 6,
        PerPixelLighting = 7,
        GpuLighting = 8,
        Forward = 9,
        ForwardPrepass = 10,
        StochasticPreZ = 11,
        StochasticTransparent = 12,
        StochasticTransparentPerPixelLighting = 13,
        StochasticTransparentGpuLighting = 14,
        ModLighting = 15,
        Max = 16,
    };
}
namespace app::Em8000::Em8000AroundTargetAgent {
    enum Direction {
        Front = 0,
        Back = 1,
        Left = 2,
        Right = 3,
        FrontLeft = 4,
        FrontRight = 5,
        BackLeft = 6,
        BackRight = 7,
    };
}
namespace app::fsm::StateCheck {
    enum BoolType {
        None = 0,
        Grapple = 1,
        Damage = 2,
        Dead = 3,
        Crouch = 4,
    };
}
namespace app::CH9Em6400HeadController {
    enum InsectMotionOrder {
        None = 0,
        Play = 1,
        Stop = 2,
    };
}
namespace app::MathEx {
    enum SliceType {
        Round = 0,
        Pizza = 1,
    };
}
namespace app::PlayerDefine {
    enum UpperActionID {
        Unknown = 0,
        UseBaseLayer = 1,
        CommonRemoveWeapon = 2,
        CommonProne = 3,
        CommonProneDamage = 4,
        CommonProneDead = 5,
        CommonUseItem = 6,
        CommonUseRemedy = 7,
        CommonUseRemedySp = 8,
        CommonUseGlasses = 9,
        CommonUseGlassesEnd = 10,
        CommonUseRemedyCureLeg = 11,
        CommonDownWeaponStart = 12,
        CommonDownWeapon = 13,
        CommonInventoryStart = 14,
        CommonInventory = 15,
        CommonInventoryCodexStart = 16,
        CommonInventoryCodex = 17,
        CommonInventoryDetailSearch = 18,
        CommonUseCodexStart = 19,
        CommonUseCodexIdle = 20,
        CommonUseCodexMove = 21,
        CommonUseCodexEnd = 22,
        CommonInstallRadarStart = 23,
        CommonInstallRadar = 24,
        CommonForceCodexOperation = 25,
        CommonLookAtTattooStart = 26,
        CommonLookAtTattoo = 27,
        CommonLookAtTattooEnd = 28,
        CommonCoughStart = 29,
        CommonCough = 30,
        CommonCoughEnd = 31,
        CommonPutWeaponAway = 32,
        CommonEventActionInterpolation = 33,
        HandsReadyStart = 34,
        HandsGuardStart = 35,
        HandsGuard = 36,
        HandsGuardEnd = 37,
        HandsGuardDamage = 38,
        HandsDamage = 39,
        HandsDamageSpEm5540Start = 40,
        HandsDamageSpEm5540 = 41,
        HandsDamageSpEm5540End = 42,
        HandsCodexStart = 43,
        HandsCodexIdle = 44,
        HandsCodexMove = 45,
        HandsCodexEnd = 46,
        HandsLArmDamageToHands = 47,
        MeleeReadyStart = 48,
        MeleeGetWeapon = 49,
        MeleeReadyIdle = 50,
        MeleeReadyIdleSp = 51,
        MeleeReadyMove = 52,
        MeleeReadyJogStart = 53,
        MeleeReadyJogEnd = 54,
        MeleeAimStart = 55,
        MeleeAimIdle = 56,
        MeleeAimIdleSp = 57,
        MeleeAimMove = 58,
        MeleeAimEnd = 59,
        MeleeGuardStart = 60,
        MeleeGuard = 61,
        MeleeGuardEnd = 62,
        MeleeAttackL = 63,
        MeleeAttackR = 64,
        MeleeAttackLoop = 65,
        MeleeAimAttackL = 66,
        MeleeAimAttackR = 67,
        MeleeAimAttackC = 68,
        MeleeAimAttackLoopStart = 69,
        MeleeAimAttackLoop = 70,
        MeleeAimAttackLoopEnd = 71,
        MeleeStick = 72,
        MeleePullL = 73,
        MeleePullR = 74,
        MeleeGetReload = 75,
        MeleeReload = 76,
        MeleeGuardDamage = 77,
        MeleeDamageF = 78,
        MeleeDamageL = 79,
        MeleeDamageR = 80,
        MeleeDamageB = 81,
        MeleeDamageSpEm5540Start = 82,
        MeleeDamageSpEm5540 = 83,
        MeleeDamageSpEm5540End = 84,
        MeleeCodexStart = 85,
        MeleeCodexIdle = 86,
        MeleeCodexMove = 87,
        MeleeCodexEnd = 88,
        GunReadyStart = 89,
        GunGetWeapon = 90,
        GunReadyIdle = 91,
        GunReadyIdleSp = 92,
        GunReadyMove = 93,
        GunReadyJogStart = 94,
        GunReadyJogEnd = 95,
        GunReadyToSemiAim = 96,
        GunSemiAimIdle = 97,
        GunSemiAimMove = 98,
        GunSemiAimToReady = 99,
        GunReadyToAim = 100,
        GunSemiAimToAim = 101,
        GunAimIdle = 102,
        GunAimIdleSp = 103,
        GunAimMove = 104,
        GunAimToSemiAim = 105,
        GunAimToReady = 106,
        GunGuardStart = 107,
        GunGuard = 108,
        GunGuardEnd = 109,
        GunAttack = 110,
        GunAttackLoop = 111,
        GunAimAttack = 112,
        GunAimAttackLoop = 113,
        GunReload = 114,
        GunReloadRepeatStart = 115,
        GunReloadRepeat = 116,
        GunReloadRepeatEnd = 117,
        GunReloadDBStart = 118,
        GunReloadDBOver = 119,
        GunReloadDBOverToUnder = 120,
        GunReloadDBUnder = 121,
        GunReloadDBEnd = 122,
        GunChangeMode = 123,
        GunGuardDamage = 124,
        GunDamage = 125,
        GunDamageSpEm5540Start = 126,
        GunDamageSpEm5540 = 127,
        GunDamageSpEm5540End = 128,
        GunCodexStart = 129,
        GunCodexIdle = 130,
        GunCodexMove = 131,
        GunCodexEnd = 132,
        ItemReadyStart = 133,
        ItemGetWeapon = 134,
        ItemReadyIdle = 135,
        ItemReadyMove = 136,
        ItemReadyJogStart = 137,
        ItemReadyJogEnd = 138,
        ItemGuardStart = 139,
        ItemGuard = 140,
        ItemGuardEnd = 141,
        ItemUse = 142,
        ItemGuardDamage = 143,
        ItemDamage = 144,
        ItemDamageSpEm5540Start = 145,
        ItemDamageSpEm5540 = 146,
        ItemDamageSpEm5540End = 147,
        ItemCodexStart = 148,
        ItemCodexIdle = 149,
        ItemCodexMove = 150,
        ItemCodexEnd = 151,
        LArmDamageReadyStart = 152,
        LArmDamageHemostasisStart = 153,
        LArmDamageReadyIdle = 154,
        LArmDamageReadyIdleSp = 155,
        LArmDamageReadyMove = 156,
        LArmDamageReadyJogStart = 157,
        LArmDamageReadyJogEnd = 158,
        LighterReadyStart = 159,
        LighterReadyIdle = 160,
        LighterReadyMove = 161,
        LighterReadyJogStart = 162,
        LighterReadyJogEnd = 163,
        LighterUse = 164,
        LighterGuardDamage = 165,
        LighterDamage = 166,
        LighterDamageSpEm5540Start = 167,
        LighterDamageSpEm5540 = 168,
        LighterDamageSpEm5540End = 169,
        HandsJustGuard = 170,
        MeleeJustGuard = 171,
        GunJustGuard = 172,
        ItemJustGuard = 173,
        ThrowableReadyStart = 174,
        ThrowableGetWeapon = 175,
        ThrowableReadyIdle = 176,
        ThrowableReadyMove = 177,
        ThrowableStandby = 178,
        ThrowableStandbyIdle = 179,
        ThrowableThrow = 180,
        ThrowableGuardStart = 181,
        ThrowableGuard = 182,
        ThrowableGuardEnd = 183,
        ThrowableJustGuard = 184,
        ThrowableGuardDamage = 185,
        ThrowableDamage = 186,
        MeleeHitAttackRight1 = 187,
        MeleeHitAttackRight2 = 188,
        MeleeHitAttackRight3 = 189,
        MeleeHitAttackRight4 = 190,
        MeleeHitAttackLeft1 = 191,
        MeleeHitAttackLeft2 = 192,
        MeleeHitAttackLeft3 = 193,
        MeleeHitAttackLeft4 = 194,
        MeleeAttackRight1 = 195,
        MeleeAttackRight1dash = 196,
        MeleeAttackRight2 = 197,
        MeleeAttackRight3 = 198,
        MeleeAttackRight4 = 199,
        MeleeAttackRightRapid = 200,
        MeleeAttackLeft1 = 201,
        MeleeAttackLeft1dash = 202,
        MeleeAttackLeft2 = 203,
        MeleeAttackLeft3 = 204,
        MeleeAttackLeft4 = 205,
        MeleeChargeLeftStart = 206,
        MeleeChargeLeftLoop = 207,
        MeleeHitChargeAttackLeft1 = 208,
        MeleeHitChargeAttackLeft2 = 209,
        MeleeHitChargeAttackLeft3 = 210,
        MeleeChargeAttackLeft1 = 211,
        MeleeChargeAttackLeft2 = 212,
        MeleeChargeAttackLeft3 = 213,
        MeleeChargeRightStart = 214,
        MeleeChargeRightLoop = 215,
        MeleeHitChargeAttackRight1 = 216,
        MeleeHitChargeAttackRight2 = 217,
        MeleeHitChargeAttackRight3 = 218,
        MeleeChargeAttackRight1 = 219,
        MeleeChargeAttackRight2 = 220,
        MeleeChargeAttackRight3 = 221,
        MeleeChargeBothHandsStart = 222,
        MeleeChargeBothHandsLoop = 223,
        MeleeHitChargeAttackBothHands1 = 224,
        MeleeHitChargeAttackBothHands2 = 225,
        MeleeChargeAttackBothHands1 = 226,
        MeleeChargeAttackBothHands2 = 227,
    };
}
namespace via::motion::IkSpineConformGround {
    enum ROT_TYPE {
        SPEED = 0,
        DAMPING = 1,
    };
}
namespace app::Em8000::Em8000PropsBreakTarget {
    enum TargetType {
        None = 0,
        Stretcher = 1,
        IronShelf = 2,
    };
}
namespace app::CH9WeaponThrowable {
    enum eUseType {
        Equip = 0,
        Throwing = 1,
    };
}
namespace app::CH9Em5850::Action {
    enum ActionNo {
        Idle = 0,
        Move = 1,
        Attack = 2,
        Damage = 3,
        Dead = 4,
        Appear = 5,
        Leave = 6,
        Suspend = 7,
    };
}
namespace app::CH9MoldedActionController::LostPartsUnit {
    enum Type {
        Head = 0,
        LeftArm = 1,
        RightArm = 2,
        LeftLeg = 3,
        RightLeg = 4,
        Body = 5,
        RightBlade = 6,
        LeftBlade = 7,
    };
}
namespace via::motion {
    enum BlendType {
        Normal = 0,
        Layer = 1,
        Interpolation = 2,
        Switch = 3,
        LayerAlpha = 4,
    };
}
namespace via::gui {
    enum GridAttribute {
        LinkEnabled = 0,
        Max = 1,
    };
}
namespace via::render {
    enum InputElementFormat {
        Float1 = 0,
        Float2 = 1,
        Float3 = 2,
        Float4 = 3,
        Half2 = 4,
        Half4 = 5,
        UByte4 = 6,
        Byte4 = 7,
        NormUByte4 = 8,
        NormByte4 = 9,
        UShort4 = 10,
        Short4 = 11,
        UShort2 = 12,
        Short2 = 13,
        NormUDec3 = 14,
        UDec3 = 15,
        Uint1 = 16,
        Uint2 = 17,
        Uint3 = 18,
        Uint4 = 19,
        Int1 = 20,
        Int2 = 21,
        Int3 = 22,
        Int4 = 23,
    };
}
namespace app {
    enum SelectListMenuResult {
        None = 0,
        Decide = 1,
        Cancel = 2,
    };
}
namespace via::motion {
    enum WrapMode {
        Default = 0,
        Once = 1,
        Loop = 2,
        TurnBack = 3,
        LoopTurnBack = 4,
    };
}
namespace via::audiorender {
    enum Listener {
        Listener_0 = 0,
        Listener_1 = 1,
        Listener_2 = 2,
        Listener_3 = 3,
        Listener_Max = 4,
    };
}
namespace via::render {
    enum TextureFormat {
        Unknown = 0,
        R32G32B32A32Typeless = 1,
        R32G32B32A32Float = 2,
        R32G32B32A32Uint = 3,
        R32G32B32A32Sint = 4,
        R32G32B32Typeless = 5,
        R32G32B32Float = 6,
        R32G32B32Uint = 7,
        R32G32B32Sint = 8,
        R16G16B16A16Typeless = 9,
        R16G16B16A16Float = 10,
        R16G16B16A16Unorm = 11,
        R16G16B16A16Uint = 12,
        R16G16B16A16Snorm = 13,
        R16G16B16A16Sint = 14,
        R32G32Typeless = 15,
        R32G32Float = 16,
        R32G32Uint = 17,
        R32G32Sint = 18,
        R32G8X24Typeless = 19,
        D32FloatS8X24Uint = 20,
        R32FloatX8X24Typeless = 21,
        X32TypelessG8X24Uint = 22,
        R10G10B10A2Typeless = 23,
        R10G10B10A2Unorm = 24,
        R10G10B10A2Uint = 25,
        R11G11B10Float = 26,
        R8G8B8A8Typeless = 27,
        R8G8B8A8Unorm = 28,
        R8G8B8A8UnormSrgb = 29,
        R8G8B8A8Uint = 30,
        R8G8B8A8Snorm = 31,
        R8G8B8A8Sint = 32,
        R16G16Typeless = 33,
        R16G16Float = 34,
        R16G16Unorm = 35,
        R16G16Uint = 36,
        R16G16Snorm = 37,
        R16G16Sint = 38,
        R32Typeless = 39,
        D32Float = 40,
        R32Float = 41,
        R32Uint = 42,
        R32Sint = 43,
        R24G8Typeless = 44,
        D24UnormS8Uint = 45,
        R24UnormX8Typeless = 46,
        X24TypelessG8Uint = 47,
        R8G8Typeless = 48,
        R8G8Unorm = 49,
        R8G8Uint = 50,
        R8G8Snorm = 51,
        R8G8Sint = 52,
        R16Typeless = 53,
        R16Float = 54,
        D16Unorm = 55,
        R16Unorm = 56,
        R16Uint = 57,
        R16Snorm = 58,
        R16Sint = 59,
        R8Typeless = 60,
        R8Unorm = 61,
        R8Uint = 62,
        R8Snorm = 63,
        R8Sint = 64,
        A8Unorm = 65,
        R1Unorm = 66,
        R9G9B9E5Sharedexp = 67,
        R8G8B8G8Unorm = 68,
        G8R8G8B8Unorm = 69,
        Bc1Typeless = 70,
        Bc1Unorm = 71,
        Bc1UnormSrgb = 72,
        Bc2Typeless = 73,
        Bc2Unorm = 74,
        Bc2UnormSrgb = 75,
        Bc3Typeless = 76,
        Bc3Unorm = 77,
        Bc3UnormSrgb = 78,
        Bc4Typeless = 79,
        Bc4Unorm = 80,
        Bc4Snorm = 81,
        Bc5Typeless = 82,
        Bc5Unorm = 83,
        Bc5Snorm = 84,
        B5G6R5Unorm = 85,
        B5G5R5A1Unorm = 86,
        B8G8R8A8Unorm = 87,
        B8G8R8X8Unorm = 88,
        R10G10B10xrBiasA2Unorm = 89,
        B8G8R8A8Typeless = 90,
        B8G8R8A8UnormSrgb = 91,
        B8G8R8X8Typeless = 92,
        B8G8R8X8UnormSrgb = 93,
        Bc6hTypeless = 94,
        Bc6hUF16 = 95,
        Bc6hSF16 = 96,
        Bc7Typeless = 97,
        Bc7Unorm = 98,
        Bc7UnormSrgb = 99,
        ViaExtension = 1024,
        Astc4x4Typeless = 1025,
        Astc4x4Unorm = 1026,
        Astc4x4UnormSrgb = 1027,
        Astc5x4Typeless = 1028,
        Astc5x4Unorm = 1029,
        Astc5x4UnormSrgb = 1030,
        Astc5x5Typeless = 1031,
        Astc5x5Unorm = 1032,
        Astc5x5UnormSrgb = 1033,
        Astc6x5Typeless = 1034,
        Astc6x5Unorm = 1035,
        Astc6x5UnormSrgb = 1036,
        Astc6x6Typeless = 1037,
        Astc6x6Unorm = 1038,
        Astc6x6UnormSrgb = 1039,
        Astc8x5Typeless = 1040,
        Astc8x5Unorm = 1041,
        Astc8x5UnormSrgb = 1042,
        Astc8x6Typeless = 1043,
        Astc8x6Unorm = 1044,
        Astc8x6UnormSrgb = 1045,
        Astc8x8Typeless = 1046,
        Astc8x8Unorm = 1047,
        Astc8x8UnormSrgb = 1048,
        Astc10x5Typeless = 1049,
        Astc10x5Unorm = 1050,
        Astc10x5UnormSrgb = 1051,
        Astc10x6Typeless = 1052,
        Astc10x6Unorm = 1053,
        Astc10x6UnormSrgb = 1054,
        Astc10x8Typeless = 1055,
        Astc10x8Unorm = 1056,
        Astc10x8UnormSrgb = 1057,
        Astc10x10Typeless = 1058,
        Astc10x10Unorm = 1059,
        Astc10x10UnormSrgb = 1060,
        Astc12x10Typeless = 1061,
        Astc12x10Unorm = 1062,
        Astc12x10UnormSrgb = 1063,
        Astc12x12Typeless = 1064,
        Astc12x12Unorm = 1065,
        Astc12x12UnormSrgb = 1066,
        ForceUint = 2147483647,
    };
}
namespace app::InventoryManager {
    enum SUB_MODE {
        ITEM_MAIN_SELECT = 0,
        ITEM_COMMAND_SELECT = 1,
        ITEM_EQUIP_SLOT_SELECT = 2,
        ITEM_EQUIP_SUCCESS_END = 3,
        ITEM_USE_SUCCESS_END = 4,
        ITEM_DROP_MENU = 5,
        ITEM_DROP_SUCCESS_END = 6,
        ITEM_COMBINE_MOVE = 7,
        ITEM_COMBINE_MENU = 8,
        ITEM_COMBINE_SUCCESS_END = 9,
        ITEM_MOVESLOT_MOVE = 10,
        ITEM_MOVESLOT_SUCCESS_END = 11,
        KEY_MAIN_SELECT = 12,
        FILE_MAIN_SELECT = 13,
        FILE_VIEW_FILE = 14,
        QUICKMENU_MAIN_SELECT = 15,
        QUICKMENU_SET_END = 16,
        REPLACEMENU_MAIN_SELECT = 17,
        REPLACEMENU_SET_END = 18,
        ITEMBOX_OUT_MENU_MAIN_SELECT = 19,
        ITEMBOX_OUT_MENU_END = 20,
        ITEMBOX_IN_MENU_MAIN_SELECT = 21,
        ITEMBOX_IN_MENU_END = 22,
    };
}
namespace via::render {
    enum BlendShapePriority {
        blendShapePriority_BlendShape = 0,
        blendShapePriority_AfterBlendShape = 1,
        blendShapePriority_Skinning = 2,
        blendShapePriority_normal = 3,
        blendShapePriority_write = 4,
        blendShapePriority_uavClear = 16,
        blendShapePriority_fix = 17,
    };
}
namespace app::OptionMenu {
    enum LangItem {
        Voice = 0,
        Caption = 1,
        Caption_Display = 2,
    };
}
namespace app::fsm::Sm0113Phone_Exclusive {
    enum CheckTypeEnum {
        CK_1st = 0,
        CK_2nd = 1,
        CK_3rd = 2,
    };
}
namespace app::CH8Em4000::Action::CH8CounterRush {
    enum CounterType {
        ParryCounter = 0,
        ActiveCounter = 1,
    };
}
namespace via::areamap::AreaMemory {
    enum Mode {
        Seconds = 0,
        Frames = 1,
    };
}
namespace via::motion::JointRemapValue::RemapValueItem {
    enum InputType {
        Trans = 0,
        Rot = 1,
        Scale = 2,
        Cone = 3,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum SmallDamageReactionTable {
        Small_v1 = 0,
        Small_v2 = 1,
    };
}
namespace via::hid::mouse::impl {
    enum ManipulatorClientType {
        Null = 0,
        DirectInput = 1,
        RawInput = 2,
        WindowMessage = 3,
        GlobalParameter = 4,
        RuntimeDefault = 5,
        ToolDefault = 6,
    };
}
namespace app::Em5552Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace via::hid {
    enum AdaptiveTriggerState {
        Off = 0,
        Intercepted = 1,
        Standby = 2,
        Active = 3,
        Pulling = 4,
        Fired = 5,
    };
}
namespace app::GameManager {
    enum NowOnSaleState {
        None = 0,
        NotSale = 1,
        Sale = 2,
    };
}
namespace app::Em3002::Action::Grapple {
    enum Type {
        CommonTurn = 0,
        FinishMove = 1,
    };
}
namespace via::navigation::NodeFilterInfo {
    enum FilterType {
        UseOn = 0,
        UseOff = 1,
    };
}
namespace via::render::ShaderTimerResource {
    enum ShaderTimerIncrType {
        MILLISEC = 0,
        SECOND = 1,
        FRAME = 2,
        DIRECT = 3,
    };
}
namespace app::CH8Em4000::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace via::clr {
    enum EnumU2 {
        Dummy = 0,
    };
}
namespace app::FirstGraphicSettingGuiBehavior {
    enum State {
        RAY_TRACING = 0,
        HIGH_FRAMERATE = 1,
        MAX = 2,
    };
}
namespace app::CH8PlayerSwingingSound {
    enum StompTable {
        silence = 0,
        stomp_hit = 1,
        stomp_miss = 2,
    };
}
namespace app::Em8001::IK::Em8001HandIKController {
    enum Type {
        INVALID = -1,
        None = 0,
        Left = 1,
        Right = 2,
        SUM = 3,
    };
}
namespace app::CH9Em5901 {
    enum ThinkOrder {
        None = 0,
        Dead = 1,
    };
}
namespace via::Serializer {
    enum Options {
        None = 0,
        FloatValueCompression = 1,
    };
}
namespace app::CH9Em6400::Action::Turn {
    enum Type {
        Idle = 0,
        Move = 1,
    };
}
namespace app::AI::AIGrappleBeacon {
    enum GrappleTypeEnum {
        None = 0,
        Chapter1Battle1 = 1,
    };
}
namespace via::network::MatchmakingRules {
    enum Category {
        Group = 0,
        P2pVersion = 1,
        Duties = 2,
        Users = 3,
    };
}
namespace via::effect::detail {
    enum LuminanceBleedSamplingType {
        Default = 0,
        NoSubpixel = 1,
    };
}
namespace via::wwise::LQGManager {
    enum CreatePhase {
        None = 0,
        Initialize = 1,
        GetSpaceBasicInfo = 2,
        SortBoundingAABB = 3,
        SearchOverlapping = 4,
        Indexing = 5,
        SearchWrappedAABBIdx = 6,
        CheckSpace = 7,
        MakeFloor = 8,
        SortSpaceAABB = 9,
        CreateQuadtreeQrids = 10,
        Clustering = 11,
        CreateLayer = 12,
        CreateLQG = 13,
        Finished = 14,
    };
}
namespace via::clr {
    enum TokenKind {
        Type = 0,
        Method = 1,
        Field = 2,
    };
}
namespace via::render::layer::PrimitiveSort {
    enum PrimitiveSortSegment {
        WaitForUpdate = 0,
        PrimitiveInitializeSort = 1,
        PrimitiveBitonicSort = 2,
        PrimitiveMergeResult = 3,
    };
}
namespace app::OptionMenu {
    enum ShakeIndex {
        On = 0,
        Off = 1,
    };
}
namespace via::dynamics {
    enum ConstraintType {
        Invalid = 0,
        BallAndSocket = 1,
        Hinge = 2,
        ConeTwist = 3,
        Ragdoll = 4,
        Prismatic = 5,
        Wheel = 6,
        Max = 7,
    };
}
namespace app::CH9Em7700::Action::Move {
    enum Type {
        Normal = 0,
        Destination = 1,
        Wanderer = 2,
    };
}
namespace app::Richpresence {
    enum ProgressType {
        Chapter0 = 0,
        Chapter1 = 1,
        Chapter3 = 2,
        Chapter4 = 3,
        Chapter42 = 4,
        Chapter43 = 5,
        Ending = 6,
        Extra = 7,
        FF = 8,
        Menu = 9,
        Unknown = 10,
        Invalid = -1,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum BonusPanelState {
        DEFAULT = 0,
        EVENT = 1,
    };
}
namespace via::render {
    enum ShaderLod {
        ShaderLod_Automatic = -1,
        ShaderLod_0 = 0,
        ShaderLod_1 = 1,
        ShaderLod_2 = 2,
        ShaderLod_3 = 3,
        ShaderLod_4 = 4,
        ShaderLod_5 = 5,
        ShaderLod_6 = 6,
        ShaderLod_7 = 7,
    };
}
namespace app::PlayerDefine {
    enum OperationLayer {
        Base = 0,
        Menu = 1,
        Interact = 2,
        LayerNum = 3,
    };
}
namespace via::Entry {
    enum Type {
        Initialize = 0,
        Setup = 1,
        Start = 2,
        Update = 3,
        Terminate = 4,
        Finalize = 5,
        Max = 6,
    };
}
namespace via::browser {
    enum OpenError {
        None = 0,
        InvalidArgument = 1,
        Busy = 2,
        NativeApi = 3,
        NotProvided = 4,
    };
}
namespace via::storage {
    enum CompressionServiceTicketStatus {
        Invalid = 0,
        Requested = 1,
        Running = 2,
        Finished = 3,
    };
}
namespace via::network::native {
    enum XboNatType {
        Open = 0,
        Moderate = 1,
        Strict = 2,
        Unknown = -1,
    };
}
namespace app::OptionMenu {
    enum DisplayItem {
        Shake = 0,
        DamageEffect = 1,
        Tutorial = 2,
        Hud = 3,
        AimColor = 4,
        Aim = 5,
        Brightness = 6,
        HDRBrightness = 7,
        HDRWhitePaper = 8,
        Screen = 9,
        VR_Mode = 10,
        VR_Tutorial = 11,
        VR_FilterMode = 12,
        VR_FilterType = 13,
        VR_FrontGuide = 14,
        HDRMode = 15,
    };
}
namespace app {
    enum CameraID {
        MainCamera = 0,
    };
}
namespace app::PopupDialog {
    enum Result {
        None = 0,
        Yes = 1,
        No = 2,
    };
}
namespace app::CH8Em4100::Action {
    enum CH8ActionNo {
        Attack = 4,
        StrikeScratch = 5,
        StrikeDash = 6,
        StrikeJump = 7,
        StrikeLongJump = 8,
        StrikeBackblow = 9,
        StrikeToGuard = 10,
        WallAttack = 11,
        Backstep = 12,
        ChanceCounter = 13,
        BlownAway = 14,
        SlipFire = 15,
        SlipAcid = 16,
        Notice = 17,
        Threat = 18,
        Dodge = 19,
        DamageToMove = 20,
        Climb = 21,
        AroundFlewover = 22,
        Grapple = 23,
        Appear = 24,
        Falling = 25,
        Suspend = 26,
        Resume = 27,
        StrikeToParry = 28,
    };
}
namespace System::Reflection {
    enum CallingConventions {
        Standard = 1,
        VarArgs = 2,
        Any = 3,
        HasThis = 32,
        ExplicitThis = 64,
    };
}
namespace via::physics::CharacterController {
    enum ContactType {
        Ground = 0,
        Wall = 1,
        Ceiling = 2,
        Max = 3,
    };
}
namespace via::audiorender {
    enum Channel_1oAmb {
        Channel_1oAmb_0 = 0,
        Channel_1oAmb_1 = 1,
        Channel_1oAmb_2 = 2,
        Channel_1oAmb_3 = 3,
        Channel_1oAmb_Max = 4,
    };
}
namespace app::CH9Em6400::Action::Attack {
    enum Type {
        None = 0,
        SkillA1 = 1000,
        SkillA2 = 1001,
        SkillA3 = 1002,
        SkillB1 = 1003,
        SkillB2 = 1004,
        SkillB3 = 1005,
        SkillC1 = 1006,
        TSkillA1 = 2000,
        TSkillA2 = 2001,
        TSkillA3 = 2002,
        TSkillB1 = 2003,
        TSkillB2 = 2004,
        TSkillB3 = 2005,
        TSkillC1 = 2006,
        FSkillA3 = 3000,
        FSkillB3 = 3001,
        SkillSpA = 4000,
        SkillSpC = 4001,
        TSkillSpA = 4002,
        SkillA1End = 5000,
        SkillA2End = 5001,
        SkillB1End = 5002,
        SkillB2End = 5003,
        SkillC1End = 5004,
        TSkillA1End = 6000,
        TSkillA2End = 6001,
        TSkillB1End = 6002,
        TSkillB2End = 6003,
        TSkillC1End = 6004,
    };
}
namespace via::kernel::bcat {
    enum BcatResult {
        OK = 0,
        ConnectFailed = 1,
        SyncFailed = 2,
        DownloadFailed = 3,
        EnumerateFailed = 4,
    };
}
namespace via::navigation::QueryObject {
    enum WorkStatus {
        Idle = 0,
        Work = 1,
        Finalize = 2,
    };
}
namespace via::storage::saveService {
    enum SaveDataOption {
        None = 0,
        Encryption = 1,
        CheckOwner = 2,
        RdsModule = 4,
    };
}
namespace app::JunkPartsUIAsset {
    enum PartsCountState {
        DEFAULT = 0,
        EMPTY = 1,
        FULL = 2,
    };
}
namespace via::clr {
    enum MemberTypes {
        Constructor = 1,
        Event = 2,
        Field = 4,
        Method = 8,
        Property = 16,
        TypeInfo = 32,
        Custom = 64,
        NestedType = 128,
    };
}
namespace app::fsm::CH8ElevatorButtonCheck {
    enum CheckType {
        Use = 0,
        SameFloor = 1,
        OpenDoor = 2,
        CloseDoor = 3,
        SecurityLock = 4,
    };
}
namespace via::network::error {
    enum MethodUser {
        Update = 0,
    };
}
namespace via::render::layer {
    enum CommonSegment {
        UpdateConstant = 0,
        UpdateBuffer = 0,
        ComputeBase = 1,
        Vortexel = 2,
        Cloth = 3,
        PrimitiveCS1 = 4,
        ComputeSkinning = 5,
        ComputeSkinningFence = 6,
        PrimitiveCS2 = 6,
        Wrinkle = 7,
        Stamp = 8,
        PrimitiveCS3 = 9,
        UserRenderTargetCS = 10,
        PrimitiveCS4 = 11,
        GraphicsBase = 16,
        GUI = 16,
        WrinkleGraphics = 17,
        BloodshedGraphics = 18,
        PostComputeBase = 32,
        BloodshedPostCompute = 32,
        ShallowWaterCompute = 33,
        TextureSpreadCompute = 34,
        PostRenderTargetCommon = 35,
        AccelerationStructureInit = 35,
        AccelerationStructureBottomLevelMeshBUILD = 36,
        AccelerationStructureBottomLevelMeshREFIT = 37,
        AccelerationStructureBottomLevelMeshCOMPACTION = 38,
        AccelerationStructureBottomLevelVFX = 39,
        AccelerationStructureTopLevelMesh = 40,
        AccelerationStructureTopLevelVFX = 41,
        RayTracingSTOC = 40,
        PostGraphicsBase = 48,
        BloodshedPostGraphics = 48,
        TextureSpreadGraphics = 49,
        ParticleWarming = 62,
        Lowest = 63,
    };
}
namespace app::EnemyThinkBase {
    enum DirectionType {
        Invalid = 0,
        ForwardTo = 1,
        BackFrom = 2,
        RightTo = 3,
        RightFrom = 4,
        LeftTo = 5,
        LeftFrom = 6,
        NoMove = 7,
    };
}
namespace app::fsm::CH8PlayerDetectCheck {
    enum Type {
        None = 0,
        Enemy = 1,
    };
}
namespace app::CH9PlayerMovement {
    enum eReturnType {
        Defalut = 0,
        BoatIdle = 1,
        CarryStart = 2,
        CarryIdle = 3,
        CarryEnd = 4,
        KnuckleIdle = 5,
    };
}
namespace via::clr {
    enum SystemMethod {
        Equals = 0,
        GetHashCode = 1,
        Finalize = 2,
        GetType = 3,
        ToString = 4,
        CompareTo = 5,
        Compare = 6,
        DefaultExceptionHandler = 7,
        Generic_GetEnumerator = 8,
        Generic_CompareTo = 9,
        Generic_Compare = 10,
        MoveNext = 11,
        Current = 12,
        IndexOf = 13,
        Max = 14,
    };
}
namespace app::BasicAnimationController::AnimatorParam {
    enum ParamType {
        Int = 0,
        Float = 1,
        Bool = 2,
    };
}
namespace via::nnfc {
    enum DeviceRegisterResult {
        Success = 0,
        ConflictDevice = 1,
        ConflictMode = 2,
        UnexpectedIndex = 3,
        ThreadBadState = 4,
    };
}
namespace via::render::Stamp {
    enum TargetUV {
        Primary = 0,
        Secondary = 1,
    };
}
namespace via::storage::StaticPropertyContainer {
    enum TypeCode {
        Unknown = 0,
        Bool = 1,
        S8 = 2,
        U8 = 3,
        S16 = 4,
        U16 = 5,
        S32 = 6,
        U32 = 7,
        S64 = 8,
        U64 = 9,
        F32 = 10,
        F64 = 11,
        String = 12,
    };
}
namespace via {
    enum ScreenShotImageOrientation {
        None = 0,
        Rotate90 = 1,
        Rotate180 = 2,
        Rotate270 = 3,
    };
}
namespace app::Em8001::Override::Em8001OverrideController {
    enum State {
        None = 0,
        WalkNormal = 1,
        WalkTurn = 2,
        OverrideIdle = 3,
        ScissorsGesture = 4,
    };
}
namespace via::landscape {
    enum BuildMeshFor {
        Collision = 0,
        Export = 1,
        None = 2,
    };
}
namespace app::OptionMenu {
    enum ControlItem {
        Vibration = 0,
        AimAssist = 1,
        WalkSpeed = 2,
        HeadRot = 3,
        MouseBtnReverse = 4,
        MouseFixing = 5,
        MouseInertia = 6,
        Keybind = 7,
        RotDirection = 8,
        RotType = 9,
        RotSpeed = 10,
        RotInertia = 11,
        SmoothCrouching = 12,
        SwapLR12 = 13,
        SwapLR = 14,
        SwapLRStick = 15,
        SwapL3R3 = 16,
        RotSpeedMouse = 17,
        RotSpeedMouseAim = 18,
        RotInertiaMouse = 19,
        AdaptiveTrigger = 20,
    };
}
namespace via::movie::MovieEntry {
    enum DefaultVideoDecoderMode {
        Hardware = 0,
        Cpu = 1,
    };
}
namespace via::motion::JointMapData {
    enum AttributeFlags {
        Deform = 1,
        JointWeight = 2,
    };
}
namespace app::GrappleBase::SafeSpaceParam {
    enum FindType {
        None = 0,
        Position = 1,
        Direction = 2,
        DirectionAndPosition = 3,
    };
}
namespace System::Globalization {
    enum CultureTypes {
        AllCultures = 0,
        FrameworkCultures = 1,
        InstalledWin32Cultures = 2,
        NeutralCultures = 3,
        ReplacementCultures = 4,
        SpecificCultures = 5,
        UserCustomCulture = 6,
        WindowsOnlyCultures = 7,
    };
}
namespace via::motion::IkMultipleDamageAction {
    enum CalculationAddRotation {
        SpecificJoint = 0,
        AllJoint = 1,
    };
}
namespace app::PlayerMeshController {
    enum LHandPartsState {
        Normal = 0,
        LHandCut = 1,
    };
}
namespace via::fluidflock::FluidFlockSimulationModelBase {
    enum SimulationMethod {
        SPH = 0,
    };
}
namespace via::motion::IkLeg {
    enum Lean {
        Center = 0,
        CenterAndHeal = 1,
    };
}
namespace via::motion::detail::ContactHelper {
    enum VirtualGroundShape {
        None = 0,
        Plane = 1,
        Sphere = 2,
        Capsule = 3,
        OBB = 4,
    };
}
namespace via::motion {
    enum AxisDirection {
        Undef = 0,
        X = 1,
        Y = 2,
        Z = 3,
        NX = 5,
        NY = 6,
        NZ = 7,
    };
}
namespace app::dev1lab::AnalysisLogTransmitter {
    enum Phase {
        Invalid = 0,
        Wait = 1,
        Initialize = 2,
        ReqTicket = 3,
        WaitTicket = 4,
        ReqGetPlatformTicket = 5,
        WaitGetPlatformTicket = 6,
        ReqSendLog = 7,
        WaitSendLog = 8,
        ComplateSendLog = 9,
        Failed = 10,
    };
}
namespace app::Havok::HavokClothAnimationTrack {
    enum Mode {
        Simulation = 0,
        Animation = 1,
        AnimationEvent = 2,
    };
}
namespace app::CH9Em6400ActionController {
    enum MiddleActionType {
        StepInCommon = 0,
        GuardFollow = 1,
        Max = 2,
        None = -1,
    };
}
namespace via::userdata::LogicNode {
    enum Operation {
        And = 0,
        Or = 1,
    };
}
namespace app::CH8Em4400ActionController {
    enum Limb {
        RIGHT_ARM = 0,
        LEFT_ARM = 1,
    };
}
namespace app::CH8RushCheckSwitch {
    enum RushStateID {
        SILENCE = 0,
        CHP8_RUSH_START = 1,
        END = 2,
        Max = 3,
    };
}
namespace via::render::Cloudscape {
    enum RenderingMode {
        Camera = 0,
        IBL = 1,
    };
}
namespace app::DamageController::DamageRecord {
    enum DamageType {
        Hit = 0,
        Manual = 1,
        Debug = 2,
    };
}
namespace via::navigation::map::VertexXZ {
    enum Attribute {
        FREE = 0,
        EDGE_START = 1,
        EDGE_END = 2,
    };
}
namespace via::storage::saveService {
    enum SaveDataMountMode {
        Read = 0,
        Write = 1,
        CreateWrite = 2,
    };
}
namespace app::CH8FadeControl {
    enum FadeRequestEnum {
        None = 0,
        FadeIn = 1,
        FadeOut = 2,
    };
}
namespace via::render::ProjectionSpotLight {
    enum LightingMode {
        All = 0,
        Beauty = 1,
    };
}
namespace app::fsm::StandbyFolderActivate {
    enum ParamType {
        Activate = 0,
        Deactivate = 1,
        StandbyOn = 2,
        StandbyOff = 3,
    };
}
namespace app::CH8GameManager {
    enum PresencePregress {
        Title = 0,
        Play_Casual = 1,
        Play_Normal = 2,
        Play_Hard = 3,
    };
}
namespace app::CH9Em6400::Action::AttackEx {
    enum Type {
        None = 0,
        SkillExSwingR1 = 100,
        SkillExSwingL1 = 200,
        SkillExSwingD1 = 300,
        SkillExSwingT1 = 400,
        TSkillExSwingR1 = 1100,
        TSkillExSwingL1 = 1200,
        TSkillExSwingD1 = 1300,
        TSkillExSwingT1 = 1400,
    };
}
namespace app::WwiseFrontSpeakerAngle {
    enum Device {
        StereoSpeaker = 0,
        StereoHeadphone = 1,
        Surround = 2,
        None = 3,
    };
}
namespace app::AI::CH8AIWorldBlackBoard {
    enum MoldedStateEnum {
        FULL = 0,
        LAYER = 1,
        BASS = 2,
        ENCOUNT = 3,
        LOST_PL = 4,
        INTENSITY = 5,
        SILENCE = 6,
    };
}
namespace via::effect::detail {
    enum EmitterUpdateStatus {
        Idle = 0,
        Running = 1,
        RunUntilDie = 2,
    };
}
namespace via::landscape {
    enum MapBakerRoadBakeType {
        Splat = 0,
        SDF = 1,
    };
}
namespace app::Em8001::Message {
    enum Group {
        None = 0,
        General_Attack_Start = 1,
        General_Attack_Hitted = 2,
        General_Attack_Missed = 3,
        General_Attack_Guarded = 4,
        General_Damage_Melee = 5,
        General_Damage_Gun = 6,
        General_Damage_Other = 7,
        General_Player_Encount_Near = 8,
        General_Player_Encount_Far = 9,
        General_Player_Lost = 10,
        General_Player_Search = 11,
        General_Player_Discovery_Normal = 12,
        General_Player_Discovery_High = 13,
        General_Player_OutOfAmmo = 14,
        First_Damage_Melee = 15,
        First_Player_Encount = 16,
        Exclusive_Attack_InstantDeath = 17,
        Exclusive_Dead = 18,
        Exclusive_Grapple_ShotGunGuard = 19,
        Exclusive_Player_Dead = 20,
    };
}
namespace via::navigation::map {
    enum VerticesMatrixType {
        Original = 0,
        TransformPtrMatrix = 1,
    };
}
namespace via::network::AutoMasterBase {
    enum Mode {
        Independent = 0,
        ForceMaster = 1,
        ForcePuppet = 2,
        AutoMaster = 3,
        SessionHost = 4,
        Replay = 5,
    };
}
namespace app::fsm::IntTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace app::CH8Em4000::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Em4000Grapple {
    enum AttackType {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em3100Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::cutin::CutinHandleNoInput {
    enum ResultDef {
        NoButton = 0,
    };
}
namespace app::Em8000::Action::Em8000Damage {
    enum DownState {
        INVALID = -1,
        None = 0,
        NoDelegateProcess = 1,
        SUM = 2,
    };
}
namespace via::storage::saveService {
    enum SaveResult {
        Null = 0,
        Doing = 1,
        Success = 2,
        Cancel = 3,
        Update_SaveFileDetail = 4,
        Failed_StartNumber = 10,
        Failed_DataNull = 11,
        Failed_DataCrash = 12,
        Failed_DataSizeZero = 13,
        Failed_MetaDataCrash = 14,
        Failed_MountError = 15,
        Failed_UnMountError = 16,
        Failed_CommitError = 17,
        Failed_NullSaveDataError = 18,
        Failed_FileOpenError = 19,
        Failed_FileWriteError = 20,
        Failed_FileReadError = 21,
        Failed_FileRemoveError = 22,
        Failed_FileCloseError = 23,
        Failed_TempUpError = 24,
        Failed_SlotLimitOver = 25,
        Failed_IndexInvalid = 26,
        Failed_SaveDataSizeMaxOver = 27,
        Failed_SaveDataSizeMinOver = 28,
        Failed_OutOfDiskFreeSpace = 29,
        Failed_SegmentTempOpenDialog = 30,
        Failed_TransferringWriteAccess = 31,
        Failed_NoWin64 = 32,
        Failed_Steam_StartNumber = 50,
        Failed_Steam_SaveError = 51,
        Failed_Steam_LoadError = 52,
        Failed_Steam_RemoveError = 53,
        Failed_Steam_NotFireCallback = 54,
        Failed_Steam_OutOfDiskFreeSpace = 55,
        Failed_NoSteam = 56,
        Failed_WeGame_StartNumber = 60,
        Failed_WeGame_SaveError = 61,
        Failed_WeGame_LoadError = 62,
        Failed_WeGame_RemoveError = 63,
        Failed_NoWeGame = 64,
        Failed_SceError_StartNumber = 100,
        Failed_SceInitializeError = 101,
        Failed_SceFinalizeError = 102,
        Failed_SceMountError = 103,
        Failed_SceUnMountError = 104,
        Failed_SceMountInfoError = 105,
        Failed_SceNeedFreeSpace = 106,
        Failed_SceNullSaveDataError = 107,
        Failed_SceBrokenSaveDataError = 108,
        Failed_SceDirectorySearchError = 109,
        Failed_SceNullMountModeError = 110,
        Failed_SceFileOpenError = 111,
        Failed_SceFileWriteError = 112,
        Failed_SceFileReadError = 113,
        Failed_SceFileRemoveError = 114,
        Failed_SceFileCloseError = 115,
        Failed_ScePublicDialogOpenError = 116,
        Failed_SceListDialogOpenError = 117,
        Failed_SceSystemDialogOpenError = 118,
        Failed_SceProgressDialogOpenError = 119,
        Failed_SceErrorDialogOpenError = 120,
        Failed_SceNeedFreeSpaceDialogOpenError = 121,
        Failed_SceDataCrashDialogOpenError = 122,
        Failed_SceOtherErrorDialogOpenError = 123,
        Failed_SceYesNoDialogOpenError = 124,
        Failed_SceDialogResultError = 125,
        Failed_SceDetailSetAllError = 126,
        Failed_SceDetailSetTitleError = 127,
        Failed_SceDetailSetSubTitleError = 128,
        Failed_SceDetailSetDetailError = 129,
        Failed_SceDetailSetUserParamError = 130,
        Failed_SceIconNotFound = 131,
        Failed_SceIconSetError = 132,
        Failed_SceTransferringTitleIDNull = 133,
        Failed_SceTransferringFingerprintNull = 134,
        Failed_SceNoPs4 = 135,
        Failed_XB1_StartNumber = 150,
        Failed_XB1_InvalidUserIndex = 151,
        Failed_XB1_SyncStorageForUserError = 152,
        Failed_XB1_NoAccess = 153,
        Failed_XB1_UpdateTooBig = 154,
        Failed_XB1_QuotaExceeded = 155,
        Failed_XB1_OutOfLocalStorage = 156,
        Failed_XB1_UpdateToStorageError = 157,
        Failed_XB1_SaveDeleteKeyError = 158,
        Failed_XB1_LoadFormStorageError = 159,
        Failed_XB1_RemoveContainerError = 160,
        Failed_XB1_GetContainerInfoError = 161,
        Failed_XB1_TransferringSCIDNull = 162,
        Failed_NoXB1 = 199,
        Failed_GameCore_StartNumber = 150,
        Failed_GameCore_InvalidUserIndex = 151,
        Failed_GameCore_NoAccess = 153,
        Failed_GameCore_UpdateTooBig = 154,
        Failed_GameCore_QuotaExceeded = 155,
        Failed_GameCore_OutOfLocalStorage = 156,
        Failed_GameCore_TransferringSCIDNull = 162,
        Failed_GameCore_UserNotRegisteredInService = 163,
        Failed_GameCore_HandleExpired = 164,
        Failed_NoGameCore = 199,
        Failed_NSW_StartNumber = 200,
        Failed_NSW_InvalidUser = 201,
        Failed_NSW_VirtualUser = 202,
        Failed_NSW_GuestUser = 203,
        Failed_NSW_NeedFreeSpace = 204,
        Failed_NSW_OpenApplet = 205,
        Failed_NSW_QuotaExceeded = 206,
        Failed_NoNSW = 207,
        Failed_STADIA_StartNumber = 250,
        Failed_STADIA_InvalidUser = 251,
        Failed_STADIA_PlayerSaveTooMany = 252,
        Failed_NoSTADIA = 253,
        Failed_Telemetry_StartNumber = 900,
        Failed_Telemetry_DataSize_Limit = 901,
        Failed_Telemetry_InvalidTelemetry = 902,
        Failed_Telemetry_CreateCollectionName = 903,
        Failed_Telemetry_CreateUniqueName = 904,
        Failed_Telemetry_SlotLimit = 905,
        Failed_Telemetry_NotReady = 906,
        Failed_Telemetry_TelemetryModule = 907,
        Failed_Other_StartNumber = 1000,
        Failed_Simulation_Error = 1001,
        Failed_SaveDataVersion_Old = 1002,
        Failed_ToDo = 1003,
        Failed_SaveServiceNull = 1004,
        Failed_InvalidSaveTransferring = 1005,
        Failed_ImportMemoryBroken = 1006,
        Failed_ImportMemoryNotSupported = 1007,
        Failed_Serialize = 1008,
        Failed_Unknown = 1009,
    };
}
namespace app::PlayerHandLight {
    enum ControlStatus {
        Free = 0,
        External = 1,
    };
}
namespace via::render::detail {
    enum PrimitiveShaderType {
        LensflareIris = 0,
        LensflareHoop = 1,
        LensflareGeneric = 2,
        LensflareDebug = 3,
        Max = 4,
    };
}
namespace app::CH9Em5850Order::Appear {
    enum Type {
        None = 0,
        Born = 1,
        Gather = 2,
        Call = 3,
    };
}
namespace app::CH8HUDControl {
    enum VrGaugeDisableFlag {
        QUICK_EQUIP_FLAG = 1,
        MESSAGE_FLAG = 2,
    };
}
namespace app::Em8001::Motion::Em8001MotionID::Tag {
    enum Weapon {
        Idle = 0,
        BattleIdle = 1,
        EngineStop_Start = 2,
        EngineStop_Loop = 3,
        EngineStop_End = 4,
        Rest_WarCry = 5,
        Grapple_Cut_Front = 6,
        Grapple_Cut_Back = 7,
        Grapple_Cut_Front_Mild = 8,
        Grapple_Cut_Back_Mild = 9,
        Grapple_ShotGunGuard = 10,
        Grapple_LegCut = 11,
    };
}
namespace app::Em4100ActionController {
    enum WallAttackQueType {
        LeftWall = 0,
        RightWall = 1,
        Ceil = 2,
        Back = 3,
    };
}
namespace app::OptionMenu {
    enum VrFilterModeIndex {
        Off = 0,
        Small = 1,
        Large = 2,
        Auto = 3,
    };
}
namespace via::motion {
    enum EulerOrder {
        XYZ = 0,
        YZX = 1,
        ZXY = 2,
        ZYX = 3,
        YXZ = 4,
        XZY = 5,
    };
}
namespace app::Em3100::Action::Walk {
    enum Type {
        Default = 0,
        Fret_v1 = 1,
        Fret_v2 = 2,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemBGPanelState {
        DEFAULT = 0,
        LEVELMAX = 1,
        LEVELUP = 2,
    };
}
namespace app::CH8Em4000Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace via::gui::BlurFilter {
    enum BlurType {
        Instant = 0,
        System = 1,
    };
}
namespace via::motion::IkLeg2 {
    enum Lean {
        Center = 0,
        CenterAndHeal = 1,
    };
}
namespace via {
    enum SystemServicePerformanceConfiguration {
        Invalid = 0,
        Cpu1020MhzGpu307MhzEmc1331Mhz = 1,
        Cpu1020MhzGpu384MhzEmc1331Mhz = 2,
        Cpu1020MhzGpu768MhzEmc1600Mhz = 3,
        Cpu1020MhzGpu460MhzEmc1331Mhz = 4,
    };
}
namespace via {
    enum ScreenShotReportOption {
        NoReport = 0,
        ReportOnSuccess = 1,
        ReportOnFailure = 2,
        ReportAlways = 3,
    };
}
namespace via::motion::IkTrain {
    enum ResetPoseMode {
        Auto = 0,
        SemiAuto = 1,
        Manual = 2,
    };
}
namespace via::clr {
    enum ParamModifier {
        None = 0,
        Ptr = 1,
        ByRef = 2,
    };
}
namespace via::motion::IkLeg {
    enum EffectorTarget {
        Heal = 0,
        Toe = 1,
    };
}
namespace app::Inventory {
    enum ExtendLvDef {
        Lv1 = 0,
        Lv2 = 1,
        Lv3 = 2,
    };
}
namespace via {
    enum Err {
        NoError = 0,
        BadAlloc = 1,
        NoResource = 2,
        BadCast = 3,
        NotFound = 4,
        InvalidFormat = 5,
        InvalidArgument = 6,
        InvalidOperation = 7,
        InvalidAlignment = 8,
        Overflow = 9,
        Underflow = 10,
        DivideByZero = 11,
        UnexpectedType = 12,
        Unreachable = 13,
        Nullptr = 14,
        InsufficientCapacity = 15,
        OutOfRange = 16,
        InvalidStatus = 17,
        InvalidSynchronization = 18,
        NotReady = 19,
        Busy = 20,
        NotYetImplemented = 21,
        NotSupported = 22,
        NoCanDo = 23,
        Deny = 24,
        Failed = 25,
        External = 26,
        Boost = 27,
        Critical = 28,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum StateTable {
        Start = 0,
        Loop = 1,
        End = 2,
    };
}
namespace app::CH8MainMenu {
    enum MainMenu {
        NewGame = 0,
        Continue = 1,
        LoadGame = 2,
        Quit = 3,
    };
}
namespace app::vr::VrSystemService {
    enum Request2DVRTypeEnum {
        None = 0,
        Loading = 1,
        EventAction = 2,
        TitleScreen = 4,
        Movie = 8,
        VrModeChange = 16,
        ErrowFlow = 32,
        Credit = 64,
        VideoUI = 128,
        TipsUI = 256,
        ItemSetting = 512,
        LastWaveUI = 1024,
        ResultUI = 2048,
    };
}
namespace via::physics::CastRayResult {
    enum Result {
        Success = 0,
        Failure = 1,
        Error = 2,
    };
}
namespace via::motion::SubExJointRemapOutput {
    enum TRS {
        Trans = 0,
        Rot = 1,
        Scale = 2,
    };
}
namespace app::PanelBoardHandle {
    enum State {
        Red = 0,
        Green = 1,
    };
}
namespace via::rebe {
    enum RebeWorkingState {
        Unknown = 0,
        Alive = 1,
        Busy = 2,
        Maintenance = 3,
        Before = 4,
        End = 5,
    };
}
namespace app::Em8000BattleDirective::ScissorsBattleParameter::AttackActionParameter {
    enum AttackActionType {
        None = 0,
        Zero_Front_Swing = 1,
        Zero_Front_Scissors = 2,
        Zero_Front_Back = 3,
        Zero_Back_Swing = 4,
        Short_Scissors = 5,
        Short_Swing = 6,
        Short_LegCut_Scissors = 7,
        Short_KneeBreak_Swing = 8,
        Short_KneeBreak_Scissors = 9,
        Short_PainStream = 10,
        Middle_Dash_Swing = 11,
        Middle_Dash_Scissors = 12,
        Middle_BreakPlatform = 13,
        Middle_PainStream = 14,
        Combo_Swing = 15,
        Combo_SwingBack = 16,
        DamageCancel_Swing = 17,
        Crazy_Swing = 18,
        Crazy_KneeBreak_Swing = 19,
        BreakPhisicsProps = 20,
        CorpsebagCut = 21,
        BreakPillar = 22,
    };
}
namespace app::Em8950 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Nightmare::NightmareTrapUnitDestroyUpdater {
    enum State {
        None = 0,
        WaitStart = 1,
        CheckDestroyAble = 2,
        WaitDestroyAble = 3,
        EndDestroyAble = 4,
    };
}
namespace app::CH8Em4450::Goal::CH8GoalGenerator {
    enum ID {
        Appear = 0,
        UnDiscovery = 1,
        Discovery = 2,
        AppearAction = 3,
        Follow = 4,
        Wait = 5,
        AttackAir = 6,
        Move = 7,
        Grapple = 8,
        GrappleAction = 9,
        Avoidance = 10,
        AvoidanceAction = 11,
    };
}
namespace app::GameEventAction {
    enum TargetCheckResult {
        Valid = 0,
        NoSetting = 1,
        NoExistContainer = 2,
        NoRegistContainer = 3,
        RegistContainer = 4,
    };
}
namespace via::gui {
    enum FilterType {
        None = 0,
        BlurInstant = 1,
        BlurSystem = 2,
    };
}
namespace via::render {
    enum TexturecubeFace {
        PositiveX = 0,
        NegativeX = 1,
        PositiveY = 2,
        NegativeY = 3,
        PositiveZ = 4,
        NegativeZ = 5,
    };
}
namespace hikako::ActivityManager {
    enum ActivityType {
        START = 0,
        END = 1,
        AVAILABLECHANGE = 2,
        TROPHY = 3,
    };
}
namespace via::motion::SubExJointRemapInput {
    enum InputType {
        Trans = 0,
        Rot = 1,
        Scale = 2,
        Cone = 3,
    };
}
namespace via::navigation::NavigationWaypoint {
    enum TraceTarget {
        Waypoint = 0,
        NavMesh = 1,
        VolumeSpace = 2,
    };
}
namespace hikako::playlog::HikakoPlayLogManager {
    enum ConfigType {
        Disable = 0,
        Default = 1,
        ForceDevelop = 2,
        ForceQA = 3,
        ForceMaster = 4,
    };
}
namespace via::effect::detail::EffectExecutor {
    enum ResourceType {
        Handle = 0,
        Stream = 1,
        Data = 2,
    };
}
namespace via::motion::LowerBodyRetarget {
    enum HipControlMode {
        Default = 0,
    };
}
namespace via::network::MatchmakingRules {
    enum Operate {
        Distance = 0,
        GreaterThan = 1,
        GreaterEqual = 2,
        LessThan = 3,
        LessEqual = 4,
    };
}
namespace via::effect::gpgpu::BillboardCS::BillboardResource {
    enum BillboardComputeShaderType {
        InitializeCS = 0,
        MaxType = 1,
    };
}
namespace via {
    enum FileAccessPriority {
        TimeCritical = 0,
        Normal = 16383,
        Idle = 32767,
    };
}
namespace app::Em3002::Goal {
    enum GoalId {
        Discovery = 0,
        UnDiscovery = 1,
        Idle = 2,
        Rest = 3,
        AppearF = 4,
        AppearR = 5,
        AppearL = 6,
        Battle = 7,
        CallFromMother = 8,
        Wander = 9,
    };
}
namespace app::CH9Em6400MessageController {
    enum Type {
        CommonCH92Battle = 0,
        FirstKnockDownCH92Battle = 1,
        FirstRevaivalCH92Battle = 2,
        CommonCH92BattleFinal = 3,
        CommonCH94BattleFinal = 4,
        CommonCH94BattleFinalThird = 5,
        BattleStartCH94BattleFinal = 6,
        FirstBlowCH94BattleFinal = 7,
        SecondBlowCH94BattleFinal = 8,
        ThirdBlowCH94BattleFinal = 9,
        CommonKillPlayer = 10,
    };
}
namespace app::Em8001::Action::Attack {
    enum Type {
        INVALID = -1,
        None = 0,
        Zero_Front_Back = 1,
        Zero_Back_Swing_L = 2,
        Zero_Back_Swing_R = 3,
        Short_Scissors = 4,
        Short_Swing = 5,
        Short_PainStream = 6,
        Middle_Dash_Swing = 7,
        Middle_Dash_Scissors = 8,
        Middle_PainStream = 9,
        DamageCancel_Swing = 10,
        SUM = 11,
    };
}
namespace app::AsyncLoadManager {
    enum DisebleItemFolderTypeEnum {
        None = 0,
        Em8000_Battle = 1,
        Max = 2,
    };
}
namespace via::effect {
    enum DevelopFlag {
        DevelopDraw = 0,
        EffectCollision = 1,
        ZTestDraw = 2,
        CullingDraw = 3,
        EmitterRangeDraw = 4,
        EmitterShapeDraw = 5,
        TypeNodeBillboardDraw = 6,
        FadeByDraw = 7,
        FluidDebugDraw = 8,
        ProfileDraw = 9,
        ShapeOperatorDraw = 10,
        PtCollisionDraw = 11,
        PlaneColliderDraw = 12,
        DrawGpuBillboard = 13,
        EnableHaze = 14,
        GpuLightningDebugDraw = 15,
        Lightning3DDebugDraw = 16,
        AttractorDraw = 17,
        VanishAreaDraw = 18,
        StretchBlurDraw = 19,
        ScaleByDepthDraw = 20,
        Max = 21,
    };
}
namespace System::Reflection {
    enum TypeAttributes {
        NotPublic = 0,
        AutoLayout = 0,
        AnsiClass = 0,
        Class = 0,
        Public = 1,
        NestedPublic = 2,
        NestedPrivate = 3,
        NestedFamily = 4,
        NestedAssembly = 5,
        NestedFamANDAssem = 6,
        NestedFamORAssem = 7,
        VisibilityMask = 7,
        SequentialLayout = 8,
        ExplicitLayout = 16,
        LayoutMask = 24,
        Interface = 32,
        ClassSemanticsMask = 32,
        Abstract = 128,
        Sealed = 256,
        SpecialName = 1024,
        Import = 4096,
        Serializable = 8192,
        WindowsRuntime = 16384,
        UnicodeClass = 65536,
        AutoClass = 131072,
        CustomFormatClass = 196608,
        CustomFormatMask = 12582912,
        StringFormatMask = 196608,
        BeforeFieldInit = 1048576,
        RTSpecialName = 2048,
        HasSecurity = 262144,
        ReservedMask = 264192,
    };
}
namespace app::CH8Em4100::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData {
    enum Interpolation {
        Linear = 0,
        Slow = 1,
        Fast = 2,
        Smooth = 3,
    };
}
namespace app::EnemyResistParameter {
    enum EnemyResistParts {
        Chest = 0,
        Stomach = 1,
        Head = 2,
        LeftUpperArm = 3,
        LeftLowerArm = 4,
        RightUpperArm = 5,
        RightLowerArm = 6,
        LeftUpperLeg = 7,
        LeftLowerLeg = 8,
        RightUpperLeg = 9,
        RightLowerLeg = 10,
        User00 = 11,
        User01 = 12,
        User02 = 13,
        User03 = 14,
        User04 = 15,
        User05 = 16,
        User06 = 17,
        User07 = 18,
        User08 = 19,
        User09 = 20,
        User10 = 21,
        User11 = 22,
        User12 = 23,
        User13 = 24,
        User14 = 25,
        User15 = 26,
        User16 = 27,
        User17 = 28,
        User18 = 29,
        User19 = 30,
        Max = 31,
    };
}
namespace app::Em3600::Action::Sneak {
    enum Type {
        roof = 0,
        floor = 1,
        floor_v1 = 2,
        window = 3,
    };
}
namespace app::CH9TimeAttackTimerHUD {
    enum SEType {
        None = 0,
        Start = 1,
        Clear = 2,
        Failed = 3,
        Hurry = 4,
    };
}
namespace via::render::BlendShapeController {
    enum BakedTextureSize {
        BakedTextureSize_32 = 32,
        BakedTextureSize_64 = 64,
        BakedTextureSize_128 = 128,
        BakedTextureSize_256 = 256,
        BakedTextureSize_512 = 512,
        BakedTextureSize_1K = 1024,
        BakedTextureSize_2K = 2048,
    };
}
namespace app::fsm::MapPlayerPosLock {
    enum ControlTypes {
        None = 0,
        Lock = 1,
        Unlock = 2,
    };
}
namespace via::gui::Effect {
    enum ExternType {
        Float = 0,
        Color = 1,
    };
}
namespace via::render::command::VKExtension {
    enum ClearTargetBit {
        ColorAttachment1 = 1,
        ColorAttachment2 = 2,
        ColorAttachment3 = 4,
        ColorAttachment4 = 8,
        Depth = 268435456,
        AllColor = 268435455,
        AllTargets = 536870911,
    };
}
namespace via::network::native::StadiaEntitlementInfo {
    enum ItemType {
        Consumable = 0,
        Durable = 1,
        Invalid = 2,
    };
}
namespace via::landscape {
    enum WireframeType {
        None = 0,
        Wire = 1,
        FilledWire = 2,
        OverlayWire = 3,
    };
}
namespace app::fsm::InteractTest {
    enum TestTypeParam {
        Normal = 0,
        SwitchOn = 1,
        SwitchOff = 2,
        EndInteract = 3,
        DoorPush = 4,
        DoorInteract = 5,
        SearchEvent_0 = 6,
        SearchEvent_1 = 7,
        SearchEvent_2 = 8,
        SearchEvent_3 = 9,
        Double_A = 10,
        Double_B = 11,
    };
}
namespace app::CH8StateSwitchStory {
    enum CHP8_STORY {
        silence = 0,
        last_rescue = 1,
        train_event_start = 2,
        train_event_end = 3,
        storage_event_start = 4,
        storage_event_end = 5,
        rescue = 6,
        starage_underlayer = 7,
        storage_turret = 8,
        event_mission_end = 9,
        em4400battle = 10,
    };
}
namespace via::hid::VrTracker {
    enum StartStatus {
        Success = 0,
        NotSupported = -1,
        AlreadyStarted = -2,
        InvalidUserIndex = -3,
        InvalidDeviceHandle = -4,
        RegisterDeviceFailed = -5,
        UserMismatched = -6,
        DeviceNotConnected = -7,
    };
}
namespace app::Em2000::Em2000FaceController {
    enum PartsNo {
        p000 = 0,
        p001 = 1,
        p002 = 2,
    };
}
namespace via {
    enum ScreenShotOverlayImageIndex {
        Index0 = 0,
        Index1 = 1,
        Index2 = 2,
        Index3 = 3,
        Index4 = 4,
        Index5 = 5,
        Index6 = 6,
        Index7 = 7,
        Index8 = 8,
        Index9 = 9,
        Max = 10,
    };
}
namespace via::render {
    enum AutoExposureHistogramMode {
        Default = 0,
        Mobile = 1,
    };
}
namespace app::CH9Em7900Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace via::gui::Material {
    enum ParamType {
        Unknown = 0,
        Float = 1,
        Float4 = 2,
        Color = 3,
        Texture = 4,
    };
}
namespace via::JobScheduler {
    enum Priority {
        High = 0,
        Normal = 1,
        Low = 2,
        End = 3,
    };
}
namespace app::Havok::HavokSystem {
    enum FramerateType {
        Variable = 0,
        Fix30Fps = 1,
        Fix60Fps = 2,
        Fix120Fps = 3,
    };
}
namespace via::motion::IkSpineConformGround {
    enum INTERVAL_OPTION {
        NONE = 0,
        SPINE_TAIL = 1,
    };
}
namespace via::render {
    enum ShaderType {
        GBuffer = 0,
        GBufferInstancing = 1,
        GBufferInstancing2 = 2,
        ZPrePassedGBuffer = 3,
        ZPrePassedGBufferInstancing = 4,
        Shadow = 5,
        ShadowInstancing = 6,
        ShadowInstancing2 = 7,
        Pick = 8,
        PickInstancing = 9,
        Forward = 10,
        ForwardInstancing = 11,
        ForwardInstancing2 = 12,
        ForwardDebug = 13,
        DepthWrite = 14,
        DepthWriteInstancing = 15,
        ZPrePass = 16,
        ZPrePassInstancing = 17,
        ZPrePassInstancing2 = 18,
        StencilWrite = 19,
        StencilWriteInstancing = 20,
        Water = 21,
        WaterZ = 22,
        WaterWzOcc = 23,
        WaterPartial = 24,
        WaterZPartial = 25,
        WaterPartialWzOcc = 26,
        WaterPartialCheap = 27,
        WaterZPartialCheap = 28,
        WaterPartialCheapWzOcc = 29,
        WaterSurfaceDeferred = 30,
        WaterSurfaceForward = 31,
        WaterSurfaceForwardPreZ = 32,
        WaterSurfacePreZ = 33,
        WaterSurfaceReflection = 34,
        PreTransform = 35,
        PreTransformWithNorm = 36,
        PreTransformWithInstanceID = 37,
        PreTransformWithInstanceIDWithNorm = 38,
        PreTransformOptionalBuffer = 39,
        PreTransformOptionalBufferWithNorm = 40,
        PreTransformOptionalBufferFix = 41,
        PreTransformOptionalBufferFixWithNorm = 42,
        RenderTarget = 43,
        PostProcess = 44,
        PostProcessMRT2 = 45,
        SpeedTreeLeaves = 46,
        SpeedTreeFrondsAndCaps = 47,
        SpeedTreeBranches = 48,
        SpeedTreeRigidMeshes = 49,
        SpeedTreeFacingLeaves = 50,
        SpeedTreeGrass = 51,
        SpeedTreeGrassBranches = 52,
        SpeedTreeBillboards = 53,
        SpeedTreeShadowCastLeaves = 54,
        SpeedTreeShadowCastFrondsAndCaps = 55,
        SpeedTreeShadowCastBranches = 56,
        SpeedTreeShadowCastRigidMeshes = 57,
        SpeedTreeShadowCastFacingLeaves = 58,
        SpeedTreeShadowCastGrass = 59,
        SpeedTreeShadowCastGrassBranches = 60,
        SpeedTreeShadowCastBillboards = 61,
        SpeedTreeDepthPrepassLeaves = 62,
        SpeedTreeDepthPrepassFrondsAndCaps = 63,
        SpeedTreeDepthPrepassBranches = 64,
        SpeedTreeDepthPrepassRigidMeshes = 65,
        SpeedTreeDepthPrepassFacingLeaves = 66,
        SpeedTreeDepthPrepassGrass = 67,
        SpeedTreeDepthPrepassGrassBranches = 68,
        SpeedTreeDepthPrepassBillboards = 69,
        SpeedTreeV83dTree = 70,
        SpeedTreeV83dTreeTwoSide = 71,
        SpeedTreeV8Leaf = 72,
        SpeedTreeV8LeafTwoSide = 73,
        SpeedTreeV8Grass = 74,
        SpeedTreeV8Billboards = 75,
        SpeedTreeV83dTreeFoliage = 76,
        SpeedTreeV83dTreeTwoSideFoliage = 77,
        SpeedTreeV8LeafFoliage = 78,
        SpeedTreeV8LeafTwoSideFoliage = 79,
        SpeedTreeV8GrassFoliage = 80,
        SpeedTreeV8BillboardsFoliage = 81,
        SpeedTreeV8Outline = 82,
        SpeedTreeV8Pick = 83,
        SpeedTreeV8TreeFoliageDebugLod = 84,
        SpeedTreeV8TreeTwoSideFoliageDebugLod = 85,
        SpeedTreeV8LeafFoliageDebugLod = 86,
        SpeedTreeV8LeafTwoSideFoliageDebugLod = 87,
        SpeedTreeV8GrassFoliageDebugLod = 88,
        SpeedTreeV8BillboardsFoliageDebugLod = 89,
        DevelopPointCloud = 90,
        VolumetricFogMaterial = 91,
    };
}
namespace via::navigation::map::PathInfo {
    enum DistanceType {
        Raw = 0,
        Path = 1,
    };
}
namespace via::render::RenderConfig {
    enum OptionSetting {
        OFF = 0,
        ON = 1,
        CUSTOM = 2,
    };
}
namespace via::motion::HipLegRig {
    enum LegSolverMode {
        LegSolverMode_2Bone = 0,
        LegSolverMode_3BoneTypeC = 1,
    };
}
namespace via::vr::psCamera {
    enum PSCameraChannel {
        Left = 0,
        Right = 1,
        Max = 2,
    };
}
namespace app::PlayerBonus {
    enum BonusType {
        None = 0,
        NormalBonus = 1,
        EventBonus = 2,
        WaveBonus = 3,
    };
}
namespace app::CH8Em4500::Action::CH8Grapple {
    enum Type {
        Mount = 0,
    };
}
namespace app::Em3002::Action {
    enum ActionNo {
        Idle = 0,
        IdleBattle = 1,
        Rest = 2,
        Ghost = 3,
        Appear = 4,
        Walk = 5,
        FirstWalk = 6,
        Turn = 7,
        Branch = 8,
        Attack = 9,
        AttackToGrapple = 10,
        OpenDoor = 11,
        Grapple = 12,
    };
}
namespace app::MapManager {
    enum MapItemDef {
        Chapter1Map = 0,
        Chapter3_2Map = 1,
        Chapter3_2MapB1F = 2,
        Chapter3_3Map = 3,
        Chapter3_4Map = 4,
        Chapter3_5Map = 5,
        Chapter4_1Map = 6,
        Chapter4_2Map = 7,
        Chapter4_3Map = 8,
    };
}
namespace via::render {
    enum SkinWeightCount {
        SkinWeightCount_4 = 0,
        SkinWeightCount_6 = 1,
        SkinWeightCount_8 = 2,
        SkinWeightCount_12 = 3,
        SkinWeightCount_Max = 7,
    };
}
namespace via::audiorender {
    enum FadeCurveType {
        FadeCurveType_Linear = 0,
        FadeCurveType_3dB = 1,
    };
}
namespace via::octree {
    enum NodeDirection {
        BottomSE = 0,
        BottomNE = 1,
        TopSE = 2,
        TopNE = 3,
        BottomSW = 4,
        BottomNW = 5,
        TopSW = 6,
        TopNW = 7,
        North = 8,
        South = 9,
        West = 10,
        East = 11,
        Up = 12,
        Down = 13,
    };
}
namespace via::gui {
    enum SVGAssetType {
        SVGSequence = 0,
        SVG = 1,
    };
}
namespace app::Em8001::Action::Grapple {
    enum Type {
        None = 0,
        Cutting = 1,
        CuttingBack = 2,
        ShotGunGuard = 3,
    };
}
namespace via::render {
    enum RAYTRACING_INSTANCE_FLAGS {
        RAYTRACING_INSTANCE_FLAG_NONE = 0,
        RAYTRACING_INSTANCE_FLAG_TRIANGLE_CULL_DISABLE = 0,
        RAYTRACING_INSTANCE_FLAG_TRIANGLE_FRONT_COUNTERCLOCKWISE = 0,
        RAYTRACING_INSTANCE_FLAG_FORCE_OPAQUE = 0,
        RAYTRACING_INSTANCE_FLAG_FORCE_NON_OPAQUE = 0,
        RAYTRACING_INSTANCE_FLAG_TAPU4 = 0,
        RAYTRACING_INSTANCE_FLAG_TAPU16 = 0,
        RAYTRACING_INSTANCE_FLAG_TAPU_RESERVED = 0,
    };
}
namespace app::Em3000::Goal {
    enum AttackMessageStatus {
        Non = 0,
        Hit = 1,
        UnHit = 2,
        Guard = 3,
    };
}
namespace app::CH9Em7700Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace via::render {
    enum PQCurve {
        ST2084 = 0,
        PQ1000 = 1,
        PQ2000 = 2,
        Custom = 3,
    };
}
namespace app::CH9EnemyOrder::FinishBlowInfo {
    enum InputButton {
        AttackRight = 0,
        AttackLeft = 1,
    };
}
namespace via::attribute::AreaQueryCategoryAttribute {
    enum Category {
        Unknown = 0,
        AreaItem = 1,
        Position = 2,
        GameObject = 4,
        AreaRegion = 8,
        Any = 255,
    };
}
namespace via::network::Matchmaking {
    enum Option {
        Normal = 0,
        Standby = 1,
    };
}
namespace via::kernel::bcat {
    enum BcatStatus {
        None = 0,
        Connecting = 1,
        ConnectCompleted = 2,
        ConnectFailed = 3,
        Syncing = 4,
        SyncCompleted = 5,
        SyncFailed = 6,
        Downloading = 7,
        DownloadCompleted = 8,
        DownloadFailed = 9,
        Enumerating = 10,
        EnumerateCompleted = 11,
        EnumerateFailed = 12,
        WaitingDialogClose = 13,
        Done = 14,
    };
}
namespace app::AI::AILookAtAgent {
    enum Direction {
        Front = 0,
        FrontLeft = 1,
        FrontRight = 2,
        Left = 3,
        Right = 4,
        BackLeft = 5,
        BackRight = 6,
        FrontLittleLeft = 7,
        FrontLittleRight = 8,
        FrontLargeLeft = 9,
        FrontLargeRight = 10,
    };
}
namespace app::CH9Em7800ActionPoint {
    enum Type {
        ClimbWall40 = 0,
        ClimbWall79 = 1,
        ClimbWall80 = 2,
        ClimbWall119 = 3,
        ClimbOver80 = 4,
        ClimbOver119 = 5,
        Climb2Fto1F = 6,
        Climb1Fto2F = 7,
        Climb2Fto2F = 8,
    };
}
namespace app::CH9Em5800::Action {
    enum ActionNo {
        Idle = 0,
        Damage = 1,
        Dead = 2,
        Generate = 3,
    };
}
namespace app::LastWaveUIAsset::TimePanel {
    enum TimeState {
        TIME_AM = 0,
        TIME_PM = 1,
    };
}
namespace app::MoldedActionController::ExtraHatUnit {
    enum Type {
        PartyHat = 0,
        Cap01 = 1,
        Cap02 = 2,
        Cap03 = 3,
        Hat01 = 4,
        Hat02 = 5,
        Met01 = 6,
        Met02 = 7,
        NoUse = 32767,
    };
}
namespace app::LookAtMarker {
    enum Level {
        None = 0,
        Low = 1,
        Normal = 2,
        High = 3,
    };
}
namespace app::Havok::HavokClothSkeletonBlendTrack {
    enum Mode {
        None = 0,
        AnimationToCurrent = 1,
        SimulationToCurrent = 2,
        BindToCurrent = 3,
    };
}
namespace app::Em3102::Message {
    enum CorresponceExistMessageType {
        Retire = 0,
        Override = 1,
        WaitForEnd = 2,
    };
}
namespace app::SaveMenu {
    enum ListElemID {
        Restart = 0,
        End = 1,
    };
}
namespace via::gui::Capture {
    enum RenderTargetFormat {
        R10G10B10A2Unorm = 24,
        R11G11B10Float = 26,
        R8G8B8A8Unorm = 28,
        R8G8B8A8UnormSrgb = 29,
        R8Unorm = 61,
    };
}
namespace app::CH9Em5700::Action::Dead {
    enum Type {
        Fall = 0,
        Disperse = 1,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData {
    enum AttrFlags {
        None = 0,
        BasePose = 1,
        World = 2,
    };
}
namespace app::AI::GoalArbitrator {
    enum Mode {
        HighScore = 0,
        Step = 1,
        StepLoop = 2,
        FirstScore = 3,
        Random = 4,
    };
}
namespace via::render {
    enum GlobalSDFClipmapNum {
        GlobalSDFClipmapNum_1 = 1,
        GlobalSDFClipmapNum_2 = 2,
        GlobalSDFClipmapNum_3 = 3,
        GlobalSDFClipmapNum_4 = 4,
    };
}
namespace via::gui {
    enum FontRasterSizeFitType {
        None = 0,
        FitFontSizeToRasterSize = 1,
        UndoFitFontSize = 2,
        FitRasterSizeToFontSize = 3,
        UndoFitRasterSize = 4,
    };
}
namespace app::CH9MoldedActionController {
    enum CancelTimingType {
        HasAttackPermit = 0,
        NearPlayer = 1,
        Guarded = 2,
        FarPlayer = 3,
        NearPlayerHasAttackPermit = 4,
        FarPlayerHasAttackPermit = 5,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData::JointDriverData {
    enum InputType {
        Trans = 0,
        Rot = 1,
        Scale = 2,
        RotRPY = 3,
        RotPYR = 4,
        ExpMap = 5,
    };
}
namespace via::simplewwise {
    enum RequestType {
        None = 0,
        SetSpeakerAngles = 1,
        PostEvent = 2,
        SeekOnEvent = 3,
        StopAll = 4,
        StopPlayingId = 5,
        RegisterGameObject = 6,
        UnregisterGameObject = 7,
        Set3dPosition = 8,
        SetMultiplePositions_Position = 9,
        SetMultiplePositions_Forward = 10,
        SetMultiplePositions_Top = 11,
        SetAttenuationScalingFactor = 12,
        SetActiveListeners = 13,
        SetListenerPosition = 14,
        SetRtpcValue = 15,
        SetSwitch = 16,
        PostTrigger = 17,
        SetState = 18,
        SetGameObjectAuxSendValues = 19,
        SetGameObjectAuxSendValuesForEmitter = 20,
        SetGameObjectOutputBusVolume = 21,
        SetObjectObstructionAndOcclusion = 22,
        SetMultipleObstructionAndOcclusion = 23,
        AddOutput = 24,
        RemoveOutput = 25,
        ReplaceOutput = 26,
        RegisterEmitter = 27,
        UnregisterEmitter = 28,
        RegisterListener = 29,
        UnregisterListener = 30,
        SetRoom = 31,
        RemoveRoom = 32,
        SetPortal = 33,
        RemovePortal = 34,
        SetGameObjectInRoom = 35,
        SetEmitterObstructionAndOcclusion = 36,
        SetPortalObstructionAndOcclusion = 37,
        Max = 38,
    };
}
namespace via::physics {
    enum ShapeType {
        Aabb = 0,
        Sphere = 1,
        ContinuousSphere = 2,
        Capsule = 3,
        ContinuousCapsule = 4,
        Box = 5,
        Mesh = 6,
        HeightField = 7,
        StaticCompound = 8,
        Area = 9,
        Triangle = 10,
        SkinningMesh = 11,
        Cylinder = 12,
        DeformableMesh = 13,
        Invalid = 14,
        Max = 15,
    };
}
namespace via::areamap::AreaItem {
    enum Mode {
        Seconds = 0,
        Frames = 1,
    };
}
namespace via::clr {
    enum EventFlag {
        SpecialName = 512,
        RTSpecialName = 1024,
    };
}
namespace app::CH9Em6700::Action {
    enum ActionNo {
        Appear = 4,
        Dodge = 5,
        Lean = 6,
        AttackClaw = 7,
        Grapple = 8,
        BlownAway = 9,
    };
}
namespace app::OptionMenu {
    enum VirtualSurroundOnOffIndex {
        On = 0,
        Off = 1,
    };
}
namespace app::CH9Em5800ActionController {
    enum Size {
        Small = 0,
        Middle = 1,
        Large = 2,
    };
}
namespace via::puppet {
    enum SyncConditions {
        Sync_Always = 0,
        GreaterMid = 1,
        GreaterHigh = 2,
        Sync_Never = 3,
    };
}
namespace app::CH8MainMenu {
    enum Process {
        eProc_Init = 0,
        eProc_MainSelect = 1,
        eProc_WaitMainSelect = 2,
        eProc_NewGame = 3,
        eProc_NewGame_Really = 4,
        eProc_NewGame_Really_1 = 5,
        eProc_NewGame_SelectDifficulty = 6,
        eProc_NewGame_SelectDifficulty_1 = 7,
        eProc_Continue = 8,
        eProc_Continue_1 = 9,
        eProc_LoadGame = 10,
        eProc_LoadGame_1 = 11,
        eProc_Quit = 12,
        eProc_StateEnd = 13,
        eProc_StateEnd_1 = 14,
        eProc_LoadSaveDataFile = 15,
        eProc_StateEnd_End = 16,
        eProc_LoadError = 17,
        eProc_LoadError_1 = 18,
    };
}
namespace via::fsm::action::SetBool {
    enum Status {
        False = 0,
        True = 1,
    };
}
namespace via::motion::Motion {
    enum JointMergeMode {
        None = 0,
        Default = 1,
        GameObjectNameSpace = 2,
    };
}
namespace app::CH9CountManager {
    enum CountType {
        ManualSave = 0,
        GetAttackAmulet = 1,
        GetGuardAmulet = 2,
        KillEm7500 = 3,
        MaxCombo = 4,
        SneakKill = 5,
        UseMedicine = 6,
        UseNotKnuckle = 7,
        Punch = 8,
    };
}
namespace via::octree {
    enum SplitType {
        Capacity = 0,
        Depth = 1,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemSelectChildPanelState {
        SIZE1 = 0,
        SIZE2 = 1,
    };
}
namespace app::Em2000::Action::Chapter1Battle4StabAttack {
    enum Type {
        StabNormal = 0,
        StabLong = 1,
    };
}
namespace app::SaveMenu {
    enum Step {
        Main = 0,
        LoadGame = 1,
        SaveGame = 2,
        MenuSaveFullError = 3,
        SystemDataMessAutoSave = 4,
        SystemDataCheck = 5,
        SystemDataLoad = 6,
        SystemDataMessLoadError = 7,
        SystemDataMessNoData = 8,
        SystemDataSave = 9,
        SystemAutoDataCheck = 10,
        SystemAutoDataSave = 11,
        SystemDataMessSaveError = 12,
        SystemDataMessRetry = 13,
        SystemDataMessNoSave = 14,
        SystemDataExit = 15,
        ExpansionDataCheck = 16,
        ExpansionDataLoad = 17,
        ExpansionDataMessLoadError = 18,
        ExpansionDataMessNoData = 19,
        ExpansionDataSave = 20,
        ExpansionDataMessSaveError = 21,
        ExpansionDataMessRetry = 22,
        ExpansionDataMessNoSave = 23,
        ExpansionDataExit = 24,
        DlcCheckInit = 25,
        DlcCheckWait = 26,
        DlcCheckWait2 = 27,
        DlcCheckError = 28,
        DlcCheckEnd = 29,
        NowOnSaleInit = 30,
        NowOnSaleWait = 31,
        NowOnSaleEnd = 32,
        AccountPickerMess = 33,
        AccountPicker = 34,
        AccountPickerError = 35,
        AccountPickerGuestError = 36,
        TrialDataCheck = 37,
        TrialDataMessGet = 38,
        TrialDataMessGet2 = 39,
        DataConversionCheck = 40,
        DataConversionFlow = 41,
        BootFlowAllEnd = 42,
    };
}
namespace app::CardGameObjectSawGauge::FlipRotate {
    enum FlipType {
        Bet = 0,
        Banker = 1,
        Player = 2,
    };
}
namespace app::SceneFolderCtrlRequester {
    enum ControlTypeEnum {
        None = 0,
        Standby_True = 1,
        Standby_False = 2,
        Activate = 3,
        deActivate = 4,
        Load = 5,
        UnLoad = 6,
    };
}
namespace via::network::error {
    enum MethodContext {
        Update = 0,
        Start = 1,
    };
}
namespace via::navigation::AIMapEffectorCore::ExtraLinkCreationInfo {
    enum State {
        Wait = 0,
        Link = 1,
    };
}
namespace app::Em5540 {
    enum ThinkState {
        None = 0,
    };
}
namespace app::Em8000::Em8000ActionTargetPoint {
    enum TargetType {
        None = 0,
        GetScissors = 1,
    };
}
namespace via::motion::IkSpine {
    enum COG_MANAGE_TYPE {
        INTERNAL = 0,
        EXTERNAL = 1,
    };
}
namespace app::Em3600::Action::Appear {
    enum Type {
        FirePlace_1F = 0,
        Floor_1F = 1,
        SmallRoomCeiling_1F = 2,
        GHNearbyDoor_1F = 3,
        GHWindow_1F = 4,
        GHBackGround_1F = 5,
        StairWindow_1_5F = 6,
        Ceiling_2F = 7,
        FirePlace_2F = 8,
        GHRoofHole_2F = 9,
        Bridge_2F = 10,
        StairRoomCeiling_2F = 11,
        GHTopofDoor_2F = 12,
        Floor_LadderPoint = 13,
    };
}
namespace app::Collision::CalculatePress {
    enum PressType {
        High = 0,
        Middle = 1,
        Low = 2,
        Max = 3,
    };
}
namespace app::CH9Em5700::Action {
    enum ActionNo {
        Idle = 0,
        GroundIdleReaction = 1,
        Attack = 2,
        Turn = 3,
        GroundMove = 4,
        FlyMove = 5,
        FlyToGround = 6,
        GroundToFly = 7,
        MenaceHovering = 8,
        MenaceGround = 9,
        Damage = 10,
        Dead = 11,
        Appear = 12,
        Generate = 13,
        Grapple = 14,
        GrappleToAttack = 15,
    };
}
namespace app::SmoothAnimator {
    enum SimilarityOptionType {
        None = 0,
        AppendData = 1,
        DummyMotion = 2,
    };
}
namespace via::render::FFTBloom {
    enum SceneFFTSize {
        Fix512x512 = 0,
        Fix1024x512 = 1,
        Fix1024x1024 = 2,
        Fix2048x1024 = 3,
        Fix2048x2048 = 4,
        FollowScreen = 5,
    };
}
namespace via::clr {
    enum TypeFlag {
        VisibilityMask = 7,
        NotPublic = 0,
        Public = 1,
        NestedPublic = 2,
        NestedPrivate = 3,
        NestedFamily = 4,
        NestedAssembly = 5,
        NestedFamandAssem = 6,
        NestedFamorAssem = 7,
        LayoutMask = 24,
        AutoLayout = 0,
        SequentialLayout = 8,
        ExplicitLayout = 16,
        ClassSemanticsMask = 32,
        Class = 0,
        Interface = 32,
        Abstract = 128,
        Sealed = 256,
        SpecialName = 1024,
        Import = 4096,
        Serializable = 8192,
        WindowsRuntime = 16384,
        StringFormatMask = 196608,
        AnsiClass = 0,
        UnicodeClass = 65536,
        AutoClass = 131072,
        CustomFormatClass = 196608,
        CustomFormatMask = 12582912,
        BeforeFieldInit = 1048576,
        RTSpecialName = 2048,
        HasSecurity = 262144,
        ReservedMask = 264192,
        LocalHeap = 16777216,
        Finalize = 33554432,
        NativeType = 67108864,
        NativeCtor = 268435456,
        ManagedVTable = 1073741824,
    };
}
namespace app::fsm::CH8AreaHitTest {
    enum TestTypeParam {
        InArea = 0,
        OutArea = 1,
    };
}
namespace via::dynamics::gjk::EPA {
    enum ClosestType {
        Face = 0,
        VertexA = 1,
        VertexB = 2,
        VertexC = 3,
        EdgeA = 4,
        EdgeB = 5,
        EdgeC = 6,
        Invalid = 7,
    };
}
namespace app::Em3001::Action {
    enum ActionMid {
        StepInStraight = 0,
        StepInSide = 1,
        StepInGrab = 2,
        Num = 3,
        Non = 99,
    };
}
namespace via::gui {
    enum UVReverseType {
        None = 0,
        ReverseU = 1,
        ReverseV = 2,
        ReverseUV = 3,
    };
}
namespace app::CH8Em4000::Action::CH8StrikeToParry {
    enum StrikeType {
        AUTO = 0,
        Right = 1,
        Left = 2,
        Center = 3,
    };
}
namespace app::Em5400::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        VolumeSpaceMoveToTarget = 2,
        VolumeSpaceMoveToPosition = 3,
        NoNavigationMoveToTarget = 4,
        SideMove = 5,
        GotoGeneratePoint = 6,
        GroundWait = 7,
        Dead = 8,
        Attack = 9,
        GroundToFly = 10,
        FlyToGround = 11,
        Turn = 12,
        Turn2 = 13,
        MenaceGround = 14,
        MenaceHovering = 15,
        HermiteCurveMove = 16,
        Generate = 17,
        GrappleToAttack = 18,
        Grapple = 19,
        Battle = 20,
        TargetApproach = 21,
        NearStabAttack = 22,
        StrikeAttack = 23,
        NearGrappleAttack = 24,
        ToGrapple = 25,
        MoveAtion = 26,
        IdleAction = 27,
        IdleReactionAction = 28,
        DeadAction = 29,
        AttackAction = 30,
        GroundToFlyAction = 31,
        FlyToGroundAction = 32,
        TurnAction = 33,
        MenaceGroundAction = 34,
        GenerateAction = 35,
        GrappleToAttackAction = 36,
        GrappleAction = 37,
    };
}
namespace via::rebe {
    enum RebeErrorCause {
        None = 0,
        NativeApi = 1,
        ServerResponse = 2,
        JsonFormat = 3,
        Suspended = 4,
        Maintenance = 5,
    };
}
namespace via::vr::psCamera {
    enum PSCameraSetConfigResult {
        OK = 1,
        ErrorStarted = 2147483649,
        ErrorInvalidType = 2147483650,
        ErrorInternal = 2147487744,
    };
}
namespace via::dynamics::internal {
    enum TriangleVoronoiId {
        Internal = 0,
        Edge01 = 1,
        Edge20 = 2,
        V0 = 3,
        Edge12 = 4,
        V1 = 5,
        V2 = 6,
        Max = 7,
    };
}
namespace app::MessageSystem {
    enum DispPriority {
        Default = 100,
        Monologue = 200,
        EnemyVoice = 300,
        Event = 400,
        Force = 500,
        EventMultiDisp = -1,
    };
}
namespace app::CH9Em7500::ThinkAppearSet {
    enum Type {
        Default = 0,
        Surface = 1,
        Presage = 2,
        FirstAppear = 3,
        PresageJump = 4,
    };
}
namespace app::MapManager {
    enum CH9MapLegendType {
        Boat = 61,
    };
}
namespace via {
    enum ScreenShotSaveResult {
        Unknown = 0,
        Success = 1,
        AlbumUnknown = 2,
        AlbumFull = 3,
        AlbumFileCountLimit = 4,
        ShareUnknown = 5,
        ShareCanceled = 6,
        ShareFailed = 7,
    };
}
namespace app::EPVExpertPartsDamageData {
    enum DamageTypeEnum {
        Fire = 0,
        Acid = 1,
        Num = 2,
    };
}
namespace app::AI::Em2000WallBreakMansionAISetInfo {
    enum InteractEventType {
        None = 0,
        em2000_WallBreak_Front = 1,
        em2000_WallBreak_Back = 2,
    };
}
namespace via::render::command::DirectXExtention {
    enum ExtentionType {
        CommandBufferSplitBarrierBegin = 0,
        CommandBufferSplitBarrierEnd = 1,
        DLSSEvaluateSuperSampling = 2,
    };
}
namespace via::detail::atomic {
    enum TypeClassifier {
        Default = 0,
        Integer = 1,
        Pointer = 2,
    };
}
namespace via::navigation::Navigation {
    enum State {
        Stop = 0,
        Navigation = 1,
        Navigaiton = 1,
    };
}
namespace via {
    enum DisplayOrientation {
        Landscape = 0,
        Portrait = 1,
    };
}
namespace app::CH8SaveMenu {
    enum Step {
        Main = 0,
        LoadGame = 1,
        SaveGame = 2,
        MenuSaveFullError = 3,
        SystemDataMessAutoSave = 4,
        SystemDataCheck = 5,
        SystemDataLoad = 6,
        SyatemDataMessLoadError = 7,
        SyatemDataMessNoData = 8,
        SystemDataSave = 9,
        SystemAutoDataCheck = 10,
        SystemAutoDataSave = 11,
        SyatemDataMessSaveError = 12,
        SyatemDataMessRetry = 13,
        SyatemDataMessNoSave = 14,
        SystemDataExit = 15,
        DlcCheckInit = 16,
        DlcCheckWait = 17,
        DlcCheckWait2 = 18,
        DlcCheckError = 19,
        DlcCheckEnd = 20,
        NowOnSaleInit = 21,
        NowOnSaleWait = 22,
        NowOnSaleEnd = 23,
        AccountPickerMess = 24,
        AccountPicker = 25,
        AccountPickerError = 26,
        AccountPickerGuestError = 27,
        TrialDataCheck = 28,
        TrialDataMessGet = 29,
        TrialDataMessGet2 = 30,
        BootFlowAllEnd = 31,
    };
}
namespace app::EPVTargetIDHelper {
    enum IDType {
        ExpertCharacterBlood = 0,
        ExpertGunSmoke = 1,
        ExpertMuzzleFlush = 2,
        ExpertObjectLanding = 3,
        ExpertWeaponLanding = 4,
        BeginCustomType = 5,
    };
}
namespace app::CH8Em4000ActionPoint {
    enum Type {
        ClimbWall40 = 0,
        ClimbWall79 = 1,
        ClimbWall80 = 2,
        ClimbWall119 = 3,
        ClimbOver80 = 4,
        ClimbOver119 = 5,
        ClimbOver150 = 6,
        WarpTo = 7,
    };
}
namespace app::Richpresence {
    enum ProcessType {
        Idle = 0,
        Requested = 1,
        RequestWaiting = 2,
        Normal = 3,
    };
}
namespace via::motion::Chain {
    enum CalculateMode {
        Default = 0,
        Performance = 1,
        Balance = 2,
        Quality = 3,
    };
}
namespace app::Em8000::Action::Em8000Walk {
    enum WalkType {
        INVALID = -1,
        None = 0,
        Normal = 1,
        Fast = 2,
        SUM = 3,
    };
}
namespace via::effect::detail {
    enum ShadowType {
        None = 0,
        Enable = 1,
        ShadowOnly = 2,
        Translucent = 3,
        TranslucentShadowOnly = 4,
    };
}
namespace via::network::error {
    enum CauseP2p {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        DisconnectByPeer = 129,
        CloseByPeer = 130,
        SendSelf = 131,
        SendPeer = 132,
        RecvSelf = 133,
        RecvPeer = 134,
    };
}
namespace app::Em5552 {
    enum ThinkOrder {
        None = 0,
        Dead = 1,
    };
}
namespace app::CH9MoldedActionController::BattleConditionBase {
    enum FinishBlowResult {
        None = 0,
        Dead = 1,
    };
}
namespace via::effect::detail {
    enum CullingTarget {
        Emitter = 0,
        Particle = 1,
    };
}
namespace via::dev::net {
    enum ConnectionState {
        Initialize = 0,
        OpenConnection = 1,
        WaitForConnection = 2,
        HandShake_1 = 3,
        HandShake_2 = 4,
        HandShake_3 = 5,
        Connecting = 6,
        Connected = 7,
        ConnectionError = 8,
        Disconnected = 9,
        Disconnected_Recover = 10,
    };
}
namespace via::landscape::layer::SplineLayer {
    enum SplinePipelineStateType {
        DrawSpline = 0,
        DrawSplineEnableMask = 1,
        DownSampleSpline = 2,
        Max = 3,
    };
}
namespace via::motion::RetargetRig {
    enum RotScaleAxis {
        LocalX = 0,
        LocalY = 1,
        LocalZ = 2,
        XYZ = 3,
    };
}
namespace app::CH9PlayerDefine {
    enum HandEquipType {
        Knuckle = 0,
        GauntletR = 1,
        Gauntlet = 2,
        GauntletW = 3,
        Max = 4,
    };
}
namespace via::motion::chain {
    enum ChainSpringCalcType {
        Position = 0,
        Rotation = 1,
    };
}
namespace app::Em3102::Action::Run {
    enum Type {
        None = 0,
        Run = 1,
    };
}
namespace app::fsm::CheckDoorAngle {
    enum CompareType {
        LessThan = 0,
        LessThanOrEqualTo = 1,
        GreaterThan = 2,
        GreaterThanOrEqualTo = 3,
    };
}
namespace app::CH8Em4000::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        Parry = 2,
    };
}
namespace app::Em3001Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
    };
}
namespace app::Em4100::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
    };
}
namespace app::GameEventActionController {
    enum ProcessType {
        Stop = 0,
        Setup = 1,
        MoveInterp = 2,
        Interp = 3,
        MoveInterpEnd = 4,
        PlayReady = 5,
        Play = 6,
        ActionEnd = 7,
    };
}
namespace app::Nightmare::NightmareTrapUnitBase {
    enum CraftResult {
        Success = 0,
        Failed_Cost = 1,
        Failed_Fatal_HasInstance = 2,
        Failed_Fatal_NullInstance = 3,
        Failed_Other = 4,
    };
}
namespace via::motion::IkLeg2 {
    enum ContactMode {
        RayCast = 0,
        DualRayCast = 1,
    };
}
namespace via::dynamics::ConstraintSet::ConstraintInfo {
    enum ConstraintType {
        BallAndSocket = 0,
        Hinge = 1,
        ConeTwist = 2,
        Ragdoll = 3,
        Prismatic = 4,
    };
}
namespace app::CH8Em4000::Action {
    enum CH8ActionNo {
        BiteTry = 4,
        NearBiteTry = 5,
        Strike = 6,
        StrikeUpper = 7,
        StrikeToGuard = 8,
        SlashPursuit = 9,
        SlashTry = 10,
        BiteCrawl = 11,
        DamageToStrike = 12,
        DamageToMove = 13,
        Thrust = 14,
        Mouth = 15,
        Grapple = 16,
        Appear = 17,
        LostParts = 18,
        BlownAway = 19,
        ChanceCounter = 20,
        SlipFire = 21,
        SlipAcid = 22,
        ExtraWait = 23,
        Dodge = 24,
        Notice = 25,
        Mimicry = 26,
        Falling = 27,
        Threat = 28,
        Warp = 29,
        Suspend = 30,
        Resume = 31,
        Stagger = 32,
        CounterRush = 33,
        WaitAttack = 34,
        WhiteFeintStrike = 35,
        WhiteBackStrike = 36,
        WhiteStrikeCombo = 37,
        WhiteStrikePowerful = 38,
        WhiteSpoit = 39,
        StrikeToParry = 40,
    };
}
namespace via {
    enum RenderType {
        Default = 0,
        Diffuse = 1,
        Specular = 2,
        LightHeatmap = 3,
        ShadowLightHeatmap = 4,
        Stencil = 5,
        DirectLight = 16,
        DiffuseLight = 17,
        Reflection = 18,
        Probe = 19,
        Path = 32,
        Albedo = 64,
        Metallic = 65,
        Roughness = 66,
        SSAO = 67,
        Translucency = 68,
        Normal = 69,
        ZDepth = 70,
        Cavity = 71,
        TextureMipMap = 128,
        SceneMipMap = 129,
        Lod = 130,
        StreamingTexture = 131,
        Occluder = 132,
        AlphaTest = 133,
        TwoSide = 134,
        Wireframe = 256,
        FilledWireframe = 257,
        TriangleDensity = 258,
        DistanceField = 259,
        GlobalDistanceField = 260,
        TelemetryHeatmap = 261,
        TransparentOverdraw = 512,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum LightSelection {
        Default = 0,
        CDF = 1,
    };
}
namespace app::Em3102::Action::DoorOpen {
    enum Type {
        None = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::Cp7AchievementDataControl {
    enum VrTrackingType {
        InGame = 0,
        EndGame = 1,
    };
}
namespace via::render::detail {
    enum TextureType {
        Untyped = -1,
        IBL = 0,
        CubeMap = 1,
        LocalCubeMap = 2,
        TransparentHDR = 3,
        Max = 4,
    };
}
namespace app::GameManager {
    enum NetworkError {
        None = 0,
        NetworkInitFailed = 1,
    };
}
namespace app::PlayerDefine {
    enum BaseActionID {
        Unknown = 0,
        Idle = 1,
        Move = 2,
        JogEnd = 3,
        Turn = 4,
        QuickTurn = 5,
        ProneIdle = 6,
        ProneMove = 7,
        ProneTurn = 8,
        ProneTurnEnd = 9,
        SupineIdle = 10,
        SupineMove = 11,
        SupineTurn = 12,
        ProneToStand = 13,
        SupineToStand = 14,
        ToCrouch = 15,
        ToProne = 16,
        ClimbOn = 17,
        ClimbOver = 18,
        ClimbCancel = 19,
        Descend = 20,
        Fall = 21,
        Land = 22,
        GuardDamage = 23,
        Damage = 24,
        ProneDamage = 25,
        SupineDamage = 26,
        BlowDamageF = 27,
        BlowDamageL = 28,
        BlowDamageR = 29,
        BlowDamageB = 30,
        BlowDamageLadder = 31,
        BlowFallF = 32,
        BlowFallL = 33,
        BlowFallR = 34,
        BlowFallB = 35,
        BlowLand = 36,
        Dead = 37,
        BlowDeadStartF = 38,
        BlowDeadStartL = 39,
        BlowDeadStartR = 40,
        BlowDeadStartB = 41,
        BlowDeadF = 42,
        BlowDeadL = 43,
        BlowDeadR = 44,
        BlowDeadB = 45,
        CureLeg = 46,
        BoatDriving = 47,
        AttackDown = 48,
        SneakKill = 49,
        FinishBlow = 50,
        AttackBack = 51,
        CarryStart = 52,
        CarryEnd = 53,
        CarryMoveEnd = 54,
        CarryStartEventJoeHouse = 55,
        CarryEventDoorThrough = 56,
        CarryEndEventJoeHouse = 57,
        CarryStartEventCamp = 58,
        CarryEndEventCamp = 59,
        GauntletEventPickUp = 60,
        GauntletEventEquip = 61,
    };
}
namespace app::MapManager {
    enum MapSheetDef {
        Chapter3_2_Main1F = 0,
        Chapter3_2_Main2F = 1,
        Chapter3_2_Main3F = 2,
        Chapter3_2_Main1FE = 3,
        Chapter3_2_Garden = 4,
        Chapter3_2_B1F = 5,
        Chapter3_3_OldHouse1F = 6,
        Chapter3_3_OldHouse2F = 7,
        Chapter3_4_Lucas1F = 8,
        Chapter3_4_Lucas2F = 9,
        Chapter3_5_Boat1F = 10,
        Chapter3_5_Boat2F = 11,
        Chapter4_1_1F = 12,
        Chapter4_1_2F = 13,
        Chapter4_1_3F = 14,
        Chapter4_1_4F = 15,
        Chapter4_1_B2F = 16,
        Chapter1_1F = 17,
        Chapter1_2F = 18,
        Chapter1_3F = 19,
        Chapter1_B1F = 20,
        Chapter1_Out = 21,
        Chapter0_1F = 22,
    };
}
namespace via::effect::detail {
    enum PtLifeStatus {
        Initialize = 0,
        Appear = 1,
        Keep = 2,
        Vanish = 3,
        Terminate = 4,
        Unknown = 4294967295,
    };
}
namespace app::Em3600ActionController {
    enum Em3600DamageParts {
        Head = 0,
        Body = 100,
        LeftArm = 200,
        RightArm = 300,
        LeftLeg = 400,
        RightLeg = 500,
    };
}
namespace System::Runtime::CompilerServices {
    enum MethodCodeType {
        IL = 0,
        Native = 1,
        OPTIL = 2,
        Runtime = 3,
    };
}
namespace app::GameManager {
    enum DlcEpisodeNo {
        Dlc1 = 1,
        Dlc2 = 2,
        Dlc3 = 3,
        Dlc4 = 4,
        AllNum = 5,
    };
}
namespace app::MaterialBloodRateController {
    enum BloodType {
        Blood = 0,
        Risotto = 1,
    };
}
namespace app::Collision {
    enum PriorityLevel {
        Priority0_Low = 0,
        Priority1 = 1,
        Priority2 = 2,
        Priority3_Middle = 3,
        Priority4 = 4,
        Priority5 = 5,
        Priority6_High = 6,
    };
}
namespace via::navigation::map::Utility {
    enum order {
        begin = 0,
        cont = 1,
        end = 2,
    };
}
namespace via::motion::IkLegSpine {
    enum RayCtrl {
        None = 0,
        Local = 1,
        World = 2,
        LocalRotTrans = 3,
        WorldRotTrans = 4,
        Manual = 5,
    };
}
namespace app {
    enum GUISegmentOrder {
        AccountErrorCutin = 60,
        SaveIcon = 60,
        Calibration = 60,
        SaveDataErrorCutin = 59,
        GuideIconVR = 59,
        GuideIcon = 59,
        NetworkErrorCutin = 58,
        SystemCutin = 58,
        SystemCutinFade = 57,
        LoadingIcon = 56,
        LoadingTips = 56,
        TopLevelFade = 55,
        LoadingScreen = 55,
        Cutin = 54,
        NormalGuideIcon = 53,
        NormalGuideIconVR = 53,
        FirstBootMenu = 52,
        OptionDetail = 50,
        StaffRoll = 48,
        Option = 48,
        GameOver = 48,
        Cp7AchievementMenu = 48,
        IMDResultMenu = 48,
        StaffRollBG = 46,
        Pause = 46,
        Subtitle = 46,
        FadeMessage = 45,
        Fade = 44,
        BootFlow = 42,
        Title = 38,
        Tutorial = 37,
        Objective = 37,
        TitleMenu = 36,
        MapFrame = 36,
        Cp7MainMenu = 36,
        PharmacyDictionary = 34,
        Puzzle = 34,
        Map = 34,
        DetailSearch = 34,
        Composition = 34,
        FileViewer = 33,
        MapBg = 33,
        MultiSubMenu = 32,
        QuickSlot = 31,
        Inventorty = 31,
        KeyHelp = 28,
        Timer = 26,
        WeaponInfo = 26,
        Reticle = 26,
        Damage = 20,
    };
}
namespace via::render::Atmosphere {
    enum DebugView {
        None = 0,
        TransmittanceToAtmosphere = 1,
        Contribution = 2,
        InScattering = 3,
        Temporal = 4,
        TotalContribution = 5,
        AmbientLight = 6,
        AerialPerspective = 7,
        TransmittanceFromCamera = 8,
    };
}
namespace via::gui::GUIUtility {
    enum AssociationAnlyzeContext {
        SearchEqual = 0,
        SearchDoubleQuot = 1,
    };
}
namespace app::vr::VrStopFlow {
    enum Phase {
        FadeOut = 0,
        Request = 1,
        Success = 2,
        FadeIn = 3,
        ReturnTitle = 4,
        End = 5,
    };
}
namespace app::fsm::CH8RequestFadeInOut {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace via::storage::saveService {
    enum SaveServiceMode {
        SaveServiceMode_Default = 131072,
        SaveServiceMode_1_Byte = 1,
        SaveServiceMode_512_Sector = 512,
        SaveServiceMode_1_KiloByte = 1024,
        SaveServiceMode_4K_Sector = 4096,
        SaveServiceMode_64_KiloByte = 65536,
        SaveServiceMode_128_KiloByte = 131072,
        SaveServiceMode_256_KiloByte = 262144,
        SaveServiceMode_512_KiloByte = 524288,
        SaveServiceMode_1_MegaByte = 1048576,
        SaveServiceMode_HighSpeed = 2147483647,
    };
}
namespace via::houdini {
    enum TargetComponent {
        Mesh = 0,
        GeometryBrush = 1,
        PathDevelop = 2,
    };
}
namespace via::motion::IkLeg {
    enum CenterAdjust {
        None = 0,
        ToRoot = 1,
        Center = 2,
    };
}
namespace app::Em3100::Action::Grapple {
    enum Type {
        FFDeathGrapple = 0,
        FallDownGrapple = 1,
    };
}
namespace via::gui {
    enum MessageType {
        Dynamic = 0,
        Static = 1,
    };
}
namespace app::Em3002::Action::AttackToGrapple {
    enum Type {
        CommonGrab = 0,
        TCommonGrab = 1,
    };
}
namespace via::hid {
    enum PauseGroup_hdVibration {
        PauseGroup_00 = 0,
        PauseGroup_01 = 1,
    };
}
namespace via::AABB {
    enum VoronoiId {
        X_MinBit = 1,
        X_MaxBit = 2,
        Y_MinBit = 4,
        Y_MaxBit = 8,
        Z_MinBit = 16,
        Z_MaxBit = 32,
        Internal = 0,
        P_YZX0 = 1,
        P_YZX1 = 2,
        P_ZXY0 = 4,
        P_ZXY1 = 8,
        P_XYZ0 = 16,
        P_XYZ1 = 32,
        E_XY0Z0 = 20,
        E_XY1Z0 = 24,
        E_XY0Z1 = 36,
        E_XY1Z1 = 40,
        E_YZ0X0 = 17,
        E_YZ1X0 = 33,
        E_YZ0X1 = 18,
        E_YZ1X1 = 34,
        E_ZX0Y0 = 5,
        E_ZX1Y0 = 6,
        E_ZX0Y1 = 9,
        E_ZX1Y1 = 10,
        V_X0Y0Z0 = 21,
        V_X1Y0Z0 = 22,
        V_X0Y1Z0 = 25,
        V_X1Y1Z0 = 26,
        V_X0Y0Z1 = 37,
        V_X1Y0Z1 = 38,
        V_X0Y1Z1 = 41,
        V_X1Y1Z1 = 42,
    };
}
namespace via::navigation::map::LinkObject {
    enum LinkStatus {
        LinkStatus_Enabled = 0,
        LinkStatus_Unload = 1,
        LinkStatus_02 = 2,
        LinkStatus_03 = 3,
        LinkStatus_04 = 4,
        LinkStatus_05 = 5,
        LinkStatus_06 = 6,
        LinkStatus_07 = 7,
        LinkStatus_Length = 8,
    };
}
namespace app::AI::AIChildBeacon {
    enum ProcessType {
        InActive = 0,
        Activate = 1,
        Running = 2,
        Terminate = 3,
    };
}
namespace app::FootEffectController {
    enum WwiseSpecialMaterialID {
        None = 0,
        LittleWet = 1,
        SoakingWet = 2,
        Water = 3,
    };
}
namespace via::clr {
    enum MethodSectType {
        EHTable = 1,
        OptILTable = 2,
        FatFormat = 64,
        MoreSects = 128,
    };
}
namespace app::EPVDefine {
    enum AttackTypeEnum {
        Slash = 96,
        Stab = 97,
        Shoot = 98,
        Strike = 99,
        Bite = 100,
        Explosion = 102,
        Special = 111,
    };
}
namespace app::CH9Em6700::Action::Grapple {
    enum Type {
        SneakB = 0,
    };
}
namespace app::Em3600::Em3600WwiseMonitoredValue {
    enum PropertyPhase {
        Normal = 0,
        FirstDiscovery = 1,
        Last = 2,
        FirstGrappleAttack = 3,
        FirstGrappleAttackEnd = 4,
    };
}
namespace app::CH9Em7700::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::fsm::CallCp7EndNoise {
    enum ElementNumber {
        Step0 = 0,
        Step1 = 1,
    };
}
namespace via::effect::detail {
    enum EmitterFlags {
        Root = 1,
        Ungrouped = 2,
    };
}
namespace app::InGameContentTimer {
    enum ContentTypeEnum {
        GarageBattle = 0,
        ScissorBattle = 1,
        FinalFatherBattle = 2,
        FinalMotherBattle = 3,
        FinalBossBattle = 4,
        PartyRoom = 5,
        PartyRoomInFF = 6,
        CrazyHouse = 7,
        Max = 8,
    };
}
namespace via::hid::virtualKeyboard {
    enum VirtualKeyboardShowResult {
        OK = 0,
        Busy = 1,
        Error = 2,
        NotSupported = 3,
    };
}
namespace via::storage::saveService {
    enum SaveTransferring {
        Default = 0,
        Setting_1 = 1,
        Setting_2 = 2,
        Setting_3 = 3,
        Setting_4 = 4,
        Setting_5 = 5,
        Setting_6 = 6,
        Setting_7 = 7,
        Setting_8 = 8,
        Setting_9 = 9,
        Setting_10 = 10,
        Setting_11 = 11,
        Setting_12 = 12,
        Setting_13 = 13,
        Setting_14 = 14,
        Setting_15 = 15,
        Setting_16 = 16,
        Setting_17 = 17,
        Setting_18 = 18,
        Setting_19 = 19,
        Setting_20 = 20,
        Setting_21 = 21,
        Setting_22 = 22,
        Setting_23 = 23,
        Setting_24 = 24,
        Setting_25 = 25,
        Setting_26 = 26,
        Setting_27 = 27,
        Setting_28 = 28,
        Setting_29 = 29,
        Setting_30 = 30,
        Setting_31 = 31,
        Setting_32 = 32,
        Setting_33 = 33,
        Setting_34 = 34,
        Setting_35 = 35,
        Setting_36 = 36,
        Setting_37 = 37,
        Setting_38 = 38,
        Setting_39 = 39,
        Setting_40 = 40,
        Setting_41 = 41,
        Setting_42 = 42,
        Setting_43 = 43,
        Setting_44 = 44,
        Setting_45 = 45,
        Setting_46 = 46,
        Setting_47 = 47,
        Setting_48 = 48,
        Setting_49 = 49,
        Setting_50 = 50,
        Setting_51 = 51,
        Setting_52 = 52,
        Setting_53 = 53,
        Setting_54 = 54,
        Setting_55 = 55,
        Setting_56 = 56,
        Setting_57 = 57,
        Setting_58 = 58,
        Setting_59 = 59,
        Setting_60 = 60,
        Setting_61 = 61,
        Setting_62 = 62,
        Setting_63 = 63,
        Setting_64 = 64,
        Setting_65 = 65,
        Setting_66 = 66,
        Setting_67 = 67,
        Setting_68 = 68,
        Setting_69 = 69,
        Setting_70 = 70,
        Setting_71 = 71,
        Setting_72 = 72,
        Setting_73 = 73,
        Setting_74 = 74,
        Setting_75 = 75,
        Setting_76 = 76,
        Setting_77 = 77,
        Setting_78 = 78,
        Setting_79 = 79,
        Setting_80 = 80,
        Setting_81 = 81,
        Setting_82 = 82,
        Setting_83 = 83,
        Setting_84 = 84,
        Setting_85 = 85,
        Setting_86 = 86,
        Setting_87 = 87,
        Setting_88 = 88,
        Setting_89 = 89,
        Setting_90 = 90,
        Setting_91 = 91,
        Setting_92 = 92,
        Setting_93 = 93,
        Setting_94 = 94,
        Setting_95 = 95,
        Setting_96 = 96,
        Setting_97 = 97,
        Setting_98 = 98,
        Setting_99 = 99,
        CrossGen_Setting_1 = 100,
        CrossGen_Setting_2 = 101,
        CrossGen_Setting_3 = 102,
        CrossGen_Setting_4 = 103,
        CrossGen_Setting_5 = 104,
        CrossGen_Setting_6 = 105,
        CrossGen_Setting_7 = 106,
        CrossGen_Setting_8 = 107,
        CrossGen_Setting_9 = 108,
        TransferringMax = 109,
    };
}
namespace app::CH9Em6400::Action::Guard {
    enum Type {
        Idle = 0,
    };
}
namespace app::ItemSlotManager {
    enum StateType {
        Normal = 0,
        ItemMove = 1,
    };
}
namespace app::PauseMenu {
    enum ModeDef {
        Normal = 0,
        FoundFootage = 1,
    };
}
namespace via::effect::detail {
    enum RotateAnimFlagType {
        EnableReverseRandom = 1,
    };
}
namespace app::Em8001::Em8001Order::Appear {
    enum Type {
        None = 0,
    };
}
namespace via::hid::virtualKeyboard {
    enum CollapseSetting {
        None = 0,
        CollapseIfHardwareKeyboardIsConnected = 1,
        CollapseIfHardwareKeyboardIsOperated = 2,
    };
}
namespace via::nnfc::nfp {
    enum NfpCfgBit {
        UseDialogOnCommonError = 1,
        AutoRunApplet = 2,
        Default = 3,
    };
}
namespace app::Cp7AchievementDataControl {
    enum MenuType {
        Menu7_2 = 0,
        Menu7_3 = 1,
        InGame7_2 = 2,
        InGame7_3 = 3,
        EndGame7_2 = 4,
        EndGame7_3 = 5,
        Result7_3 = 6,
    };
}
namespace via::effect::vortexel {
    enum VelocityDirectionType {
        Straight = 0,
        Spread = 1,
        SpreadXZ = 2,
        SpreadTangent = 3,
    };
}
namespace app::Em3600::Action::BackJump {
    enum Type {
        Normal = 0,
        NoWallStick = 1,
    };
}
namespace app::PlayerCamera {
    enum FovValue {
        Fov70 = 0,
        Fov75 = 1,
        Fov80 = 2,
        Fov85 = 3,
        Fov90 = 4,
    };
}
namespace app::SmoothAnimator {
    enum State {
        Start = 0,
        Requested = 1,
        RequestedLoop = 2,
        Transiting = 3,
        TransitingLoop = 4,
        EndTransition = 5,
        Unhandling = 6,
    };
}
namespace app::Em3100 {
    enum ThinkOrder {
        None = 0,
        PLSearchGoTo = 1,
        OverLook_L = 2,
        OverLook_R = 3,
        WalkOverLook_L = 4,
        WalkOverLook_R = 5,
        WalkLookBack_L = 6,
        WalkLookBack_R = 7,
        DoorOpenLookBack_L = 8,
        DoorOpenLookBack_R = 9,
        WalkLookBackTurn = 10,
        Cough = 11,
        SetHair = 12,
        Fret = 13,
        WalkFret = 14,
        FFRoomMove = 15,
        RunAwayGoTo = 16,
        PivotTurn = 17,
        DiscoveryTurn = 18,
        Suspicion = 19,
        DLC_TestAction = 20,
    };
}
namespace via::gui {
    enum MouseEventType {
        Unknown = 0,
        Enter = 1,
        Over = 2,
        Leave = 3,
    };
}
namespace app::Em8000BattleDirective::ScissorsBattleParameter {
    enum ChainsawEngineDamageTrigger {
        None = 0,
        Grapple_BattleOfSaw = 1,
        RepelPlayerChainsawAttack = 2,
    };
}
namespace via::landscape {
    enum MapBakerFoliageMapBakeType {
        SDF = 0,
    };
}
namespace Em5540Effect {
    enum IDAlias {
        Fire = 0,
        BugWait_00 = 1,
        BugWait_01 = 2,
        BugWait_02 = 3,
        BugWait_03 = 4,
        BugWait_04 = 5,
        BugWait_05 = 6,
        BugWait_06 = 7,
        BugWait_07 = 8,
        BugWait_08 = 9,
        BugWait_09 = 10,
        Resident = 11,
    };
}
namespace via::network::bson {
    enum ElementId {
        EOO = 0,
        Double = 1,
        String = 2,
        Object = 3,
        Array = 4,
        Binary = 5,
        Bool = 8,
        Int32 = 16,
        Timestamp = 17,
        Int64 = 18,
    };
}
namespace via::motion::JointRemapValue::RemapValueItem {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace via::charset {
    enum EncodingType {
        Unknown = 0,
        Ascii = 1,
        ShiftJIS = 2,
        UTF8_BOM = 3,
        UTF8 = 4,
    };
}
namespace via::network::wrangler {
    enum EventEnabledState {
        Undefined = 0,
        Off = 1,
        ProviderDefault = 2,
        On = 3,
    };
}
namespace via::render::AreaLight {
    enum LTCAreaLightShape {
        Quad = 0,
        Line = 1,
        Disk = 2,
        Max = 3,
    };
}
namespace app::EmLoadControl {
    enum EmLoadTypeEnum {
        Em2000 = 0,
        Em2000Chapter4 = 1,
        Em3000 = 2,
        Em3100 = 3,
        Em3300 = 4,
        Em3600 = 5,
        Em4000 = 6,
        Em4100 = 7,
        Em4200 = 8,
        Em5400 = 9,
        Em5510 = 10,
        Em5511 = 11,
        Em5512 = 12,
        Em5520 = 13,
        Em5540 = 14,
        Em5552 = 15,
        Em8000 = 16,
        Em8100 = 17,
        Em8900 = 18,
        Em8940 = 19,
        None = 20,
        MAX = 20,
    };
}
namespace app::CraftBenchUIAsset {
    enum TabPanelState {
        DEFAULT = 0,
        SELECT = 1,
    };
}
namespace via::physics::CharacterController {
    enum State {
        FirstUpdate = 0,
        OverwritePosition = 1,
        IgnoreVerticalRiseAdjust = 2,
        IgnoreBackfaceTriangle = 3,
        UpdateFilterInfo = 4,
        AfterUnloaded = 5,
        Max = 6,
    };
}
namespace via::landscape {
    enum AreaRangeType {
        Aabb = 0,
        Obb = 1,
    };
}
namespace app::fsm::EnemyStateCheck {
    enum EnemyBoolType {
        None = 0,
        Discovery = 1,
    };
}
namespace app::Interpolation {
    enum State {
        LerpPos = 0,
        LerpRot = 1,
        LerpLocalPos = 2,
        LerpLocalRot = 3,
        Interpolation3 = 4,
        Interpolation1 = 5,
        Num = 6,
    };
}
namespace via::render {
    enum OutputLimitConfigMode {
        Disable = 0,
        LowerLimit = 1,
        UpperLimit = 2,
        UserImage = 3,
    };
}
namespace via::wwise {
    enum SinkTypeXboxOne {
        Main = 0,
        MergeToMain = 1,
        BGM = 2,
        Communication = 3,
        Personal = 4,
        DVR = 5,
        MicrodsoftSpatialSound = 6,
        None = 7,
    };
}
namespace via::os {
    enum SanityCheckLevel {
        Surface = 0,
        Shallow = 1,
        Deep = 2,
    };
}
namespace via::gui::MaterialText {
    enum ParamType {
        Unknown = 0,
        Float = 1,
        Float4 = 2,
        Color = 3,
        Texture = 4,
    };
}
namespace app::MissionDetail {
    enum DifficultyBits {
        Casual = 1,
        Normal = 2,
        Hard = 4,
    };
}
namespace app::PlayerCamera {
    enum FovType {
        Narrow = -10,
        Normal = 0,
        Wide = 10,
    };
}
namespace via::motion::tree::SelectMotionNode {
    enum BankSelect {
        Base = 0,
        Tbl = 1,
        Direct = 2,
    };
}
namespace app::TipsGUI {
    enum PanelState {
        DEFAULT = 0,
        DECIDE = 1,
        DISABLE = 2,
    };
}
namespace app::fsm::ShadowPuzzleSet {
    enum LoadState {
        NotStart = 0,
        LoadInit = 1,
        LoadWait = 2,
        LoadEnd = 3,
        LoadFailed = 4,
    };
}
namespace app::LastWaveUIDesc {
    enum DescriptionType {
        OPEN = 0,
        DISPLAY_BONUS = 1,
        DISPLAY_TEXT = 2,
        DISPLAY_RESULT = 3,
    };
}
namespace app::Em8001::Action::EngineStop {
    enum State {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
    };
}
namespace app::TableItemExplanation {
    enum ItemSlot {
        Start = -1,
        Slot1 = 0,
        Slot2 = 1,
        Slot3 = 2,
        Slot4 = 3,
        Slot5 = 4,
        Slot6 = 5,
        End = 6,
    };
}
namespace app::fsm::CheckGenomeCodexState {
    enum Mode {
        Scan = 0,
        Install = 1,
        TraceScan = 2,
        CommunicationTalking = 3,
        CommunicationCall = 4,
    };
}
namespace via::render {
    enum SamplerQuality {
        Bilinear = 0,
        Trilinear = 1,
        Anisotropic2 = 2,
        Anisotropic4 = 3,
        Anisotropic8 = 4,
        Anisotropic16 = 5,
    };
}
namespace via::effect::gpgpu::detail {
    enum GpuItemConstantBufferType {
        FieldParameter = 0,
        MeshEmitter = 1,
        DirectionalField = 2,
        Max = 3,
    };
}
namespace Em8100Effect {
    enum IDAlias {
        BeamFloor = 0,
        Explosion = 1,
        Burn = 2,
        HitWeak1 = 3,
        HitWeak2 = 4,
        HitWeak3 = 5,
        HitWeak4 = 6,
        HitWeak5 = 7,
        HitWeak6 = 8,
        HitWeak7 = 9,
        HitWeak8 = 10,
        BreakWeak1 = 11,
        BreakWeak2 = 12,
        BreakWeak3 = 13,
        BreakWeak4 = 14,
        BreakWeak5 = 15,
        BreakWeak6 = 16,
        BreakWeak7 = 17,
        BreakWeak8 = 18,
        HitHead = 19,
        Splash = 20,
        SplashLoop = 21,
        SplashOmen1 = 22,
        SplashOmen2 = 23,
        SplashOmen3 = 24,
        SplashOmen4 = 25,
        SplashOmen5 = 26,
        SplashOmen6 = 27,
        SplashOmen7 = 28,
        SplashOmenBreak1 = 29,
        SplashOmenBreak2 = 30,
        SplashOmenBreak3 = 31,
        SplashOmenBreak4 = 32,
        SplashOmenBreak5 = 33,
        SplashOmenBreak6 = 34,
        SplashOmenBreak7 = 35,
        ShortAttackL = 36,
        ShortAttackR = 37,
        TailAttackL = 38,
        TailAttackSwingL = 39,
        TailAttackR = 40,
        TailAttackSwingR = 41,
        HandL = 42,
        HandR = 43,
        HandSagL = 44,
        HandSagR = 45,
        Body = 46,
        BodyLight = 47,
        BodySag = 48,
        Tail = 49,
        BodyLong = 50,
        BodyShort = 51,
        LowerBody = 52,
        TailShort = 53,
    };
}
namespace via::navigation {
    enum GraphDrawMode {
        Normal = 0,
        Light = 1,
    };
}
namespace app::Em8000::Action::Em8000EngineStop {
    enum State {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
    };
}
namespace app::CH8Em4500QuickJumpNavigation {
    enum NavigationStatus {
        Stop = 0,
        Active = 1,
    };
}
namespace app::Em5400Think {
    enum Mode {
        Ground = 0,
        Fly = 1,
    };
}
namespace app::FileArtContainer {
    enum FileArtState {
        Hide = 0,
        Standby = 1,
        Show = 2,
    };
}
namespace via::render {
    enum TonemapFunction {
        Karis = 0,
        TripleSection = 1,
    };
}
namespace app::Em3600Think {
    enum LegState {
        TwoLeg = 0,
        FourLeg = 1,
        FourLegRev = 2,
    };
}
namespace via::landscape::UserAttributeMapBaker {
    enum State {
        Ready = 0,
        ClearTexture = 1,
        WaitVoxelize = 2,
        Baking = 3,
    };
}
namespace via::houdini {
    enum UpdateType {
        Manual = 0,
        SemiAuto = 1,
        Auto = 2,
    };
}
namespace via::motion::FullBodyIKRig {
    enum LimbSolverType {
        Chain = 0,
        Hinge = 1,
        Hinge_3Convex = 2,
    };
}
namespace app::fsm::CH8LiftCheck {
    enum CheckType {
        OpenDoor = 0,
        CloseDoor = 1,
        IsSameFloor = 2,
        ClosingDoor = 3,
    };
}
namespace app::Telemetry {
    enum ClearTimeType {
        GarageBattle = 0,
        ScissorBattle = 1,
        FinalFatherBattle = 2,
        FinalMotherBattle = 3,
        FinalBossBattle = 4,
        PartyRoom = 5,
        PartyRoomInFF = 6,
    };
}
namespace via::hid::gamePlayer {
    enum DevicePickerResult {
        Done = 0,
        Canceled = 1,
        Failed = 2,
    };
}
namespace via::render {
    enum DecalReciveMode {
        Automatic = 0,
        Enable = 1,
        Disable = 2,
    };
}
namespace via::landscape {
    enum MapBakerBakeTextureType {
        Height = 0,
        Splat = 1,
    };
}
namespace via::clr {
    enum SignatureType {
        Default = 0,
        C = 1,
        StdCall = 2,
        ThisCall = 3,
        FastCall = 4,
        VarArg = 5,
        Field = 6,
        LocalVar = 7,
        Property = 8,
        TypeSpec = 9,
        MethodSpec = 10,
    };
}
namespace app::CarInGarage {
    enum Material {
        LeftHeadLightLarge = 0,
        LeftHeadLightSmall = 1,
        RightHeadLightLarge = 2,
        RightHeadLightSmall = 3,
        LeftBackupLight = 4,
        LeftBrakeLight = 5,
        RightBackupLight = 6,
        RightBrakeLight = 7,
    };
}
namespace via::clr {
    enum EvalType {
        Int32 = 0,
        Int64 = 1,
        Float = 2,
        Ptr = 3,
        ObjRef = 4,
        Value = 5,
        Invalid = 7,
    };
}
namespace app::fsm::VRTutorialFlow {
    enum MoveStateType {
        NEXT = 0,
        BACK = 1,
        REPEAT = 2,
        END = 3,
        NUMMAX = 4,
    };
}
namespace app::BlackOutManager {
    enum RequestTypeEnum {
        None = 0,
        SceneJump = 1,
        ShadowPazzle = 2,
        FSMAction = 4,
        SceneActivater = 8,
        LoadGame = 16,
        Title = 32,
        Birthday = 64,
        VrModeChange = 128,
        VrTutorial = 256,
        ScenarioJump = 512,
        FSMAction_HideIcon = 1024,
    };
}
namespace via::wwise {
    enum StateThread {
        None = 0,
        Uninitialized = 1,
        Initializing = 2,
        Idle = 3,
        Executing = 4,
        Terminated = 5,
        Max = 6,
    };
}
namespace via::charset {
    enum UTF16Type {
        LE = 0,
        BE = 1,
        LE_BOM = 2,
        BE_BOM = 3,
        Native = 0,
    };
}
namespace via::os {
    enum SemaphoreError {
        None = 0,
        Failed = 1,
    };
}
namespace via::motion::IkBodyRig {
    enum SourcePosMode {
        Animation = 0,
        Set = 1,
        Add = 2,
    };
}
namespace app::Em8010::Em8010Core {
    enum MotionFSMState {
        None = 0,
        CloseLoop = 1,
        Open = 2,
        OpenLoop = 3,
        Close = 4,
        Damage = 5,
        CuttingFinal = 6,
        NormalFinal = 7,
    };
}
namespace via::effect::detail {
    enum PlayType {
        Pause = 0,
        Loop = 1,
        Finish = 2,
        Play = 3,
    };
}
namespace app::CH8OperatorManager2 {
    enum MessagePriority {
        Default = 1,
        Monologue = 2,
        EnemyVoice = 3,
        Event = 4,
        Force = 5,
        EventMultiDisp = 6,
    };
}
namespace app::fsm::CH8SystemDataSave {
    enum State {
        Init = 0,
        Saveing = 1,
        SaveFailed = 2,
    };
}
namespace app::OptionMenu {
    enum GraphicItem {
        Dr = 0,
        Mode = 1,
        Refreshrate = 2,
        VSYNC = 3,
        Framerate = 4,
        Antialias = 5,
        Motionblur = 6,
        DepthOfFiled = 7,
        Shadow = 8,
        ShadowObject = 9,
        ShadowCatche = 10,
        Texture = 11,
        TextureFiltering = 12,
        AmbienteOcclusion = 13,
        Reflection = 14,
        SubsurfaceScattering = 15,
        ColorSpace = 16,
        Vfx = 17,
        FOV = 18,
        RenderingMethod = 19,
        ImageQuality = 20,
        MeshQuality = 21,
        Bloom = 22,
        LensFlare = 23,
        VolumeLight = 24,
        ChromaticAberration = 25,
        RayTracingMode = 26,
        GIReflection = 27,
        RaytracingReflection = 28,
        FidelityFXSuper = 29,
    };
}
namespace via::gui {
    enum RenderLayerType {
        Overlay = 0,
        Transparent = 1,
        SubScene = 2,
    };
}
namespace via::hid {
    enum KeyboardKey {
        None = 0,
        LButton = 1,
        RButton = 2,
        Cancel = 3,
        MButton = 4,
        XButton1 = 5,
        XButton2 = 6,
        Back = 8,
        Tab = 9,
        Clear = 12,
        Enter = 13,
        Return = 13,
        Shift = 16,
        Control = 17,
        Menu = 18,
        Pause = 19,
        Capital = 20,
        Kana = 21,
        Junja = 23,
        Final = 24,
        Hanja = 25,
        Escape = 27,
        Convert = 28,
        NonConvert = 29,
        Accept = 30,
        ModeChange = 31,
        Space = 32,
        Prior = 33,
        Next = 34,
        End = 35,
        Home = 36,
        Left = 37,
        Up = 38,
        Right = 39,
        Down = 40,
        Select = 41,
        Print = 42,
        Execute = 43,
        SnapShot = 44,
        Insert = 45,
        Delete = 46,
        Help = 47,
        Alpha0 = 48,
        Alpha1 = 49,
        Alpha2 = 50,
        Alpha3 = 51,
        Alpha4 = 52,
        Alpha5 = 53,
        Alpha6 = 54,
        Alpha7 = 55,
        Alpha8 = 56,
        Alpha9 = 57,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LWin = 91,
        RWin = 92,
        Apps = 93,
        Sleep = 95,
        NumPad0 = 96,
        NumPad1 = 97,
        NumPad2 = 98,
        NumPad3 = 99,
        NumPad4 = 100,
        NumPad5 = 101,
        NumPad6 = 102,
        NumPad7 = 103,
        NumPad8 = 104,
        NumPad9 = 105,
        Multiply = 106,
        Add = 107,
        Separator = 108,
        Subtract = 109,
        Decimal = 110,
        Divide = 111,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F13 = 124,
        F14 = 125,
        F15 = 126,
        F16 = 127,
        F17 = 128,
        F18 = 129,
        F19 = 130,
        F20 = 131,
        F21 = 132,
        F22 = 133,
        F23 = 134,
        F24 = 135,
        NumLock = 144,
        Scroll = 145,
        NumPadEnter = 146,
        LShift = 160,
        RShift = 161,
        LControl = 162,
        RControl = 163,
        LMenu = 164,
        RMenu = 165,
        OEM_1 = 186,
        OEM_Plus = 187,
        OEM_Comma = 188,
        OEM_Minus = 189,
        OEM_Period = 190,
        OEM_2 = 191,
        OEM_3 = 192,
        OEM_4 = 219,
        OEM_5 = 220,
        OEM_6 = 221,
        OEM_7 = 222,
        OEM_8 = 223,
        OEM_102 = 226,
        Slash = 191,
        BackSlash = 220,
        DefinedEnter = 254,
        DefinedCancel = 255,
    };
}
namespace via::network::Codec {
    enum Mode {
        Dict = 0,
        Comp = 1,
    };
}
namespace app::CH9Em7500::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace via::render::VolumeOccludee {
    enum VISIBILITY {
        Invisible = 0,
        Visible = 1,
        Unknown = 2,
    };
}
namespace via::path {
    enum PathKind {
        RelativeOrAbsolute = 0,
        Absolute = 1,
        Relative = 2,
    };
}
namespace app::OptionKeyBind {
    enum KeyBindGroupType {
        PlayerCommand = 0,
        InGameOpenMenu = 1,
        CommonUICommand = 2,
        InventoryCommand = 3,
        ItemBoxCommand = 4,
        MapCommand = 5,
        ConfirmCommand = 6,
        TwentyOneCommand = 7,
    };
}
namespace via::effect::gpgpu::detail::DrawPipelineCache {
    enum Type {
        Default = 0,
        Prepass = 1,
        DepthOperator = 2,
        ScreenSpaceEmitter = 3,
        Num = 4,
    };
}
namespace via::audiorender {
    enum Channel_512ch {
        L = 0,
        R = 1,
        C = 2,
        LFE = 3,
        Ls = 4,
        Rs = 5,
        Lt = 6,
        Rt = 7,
        Max = 8,
    };
}
namespace via::wwise::WwiseDriver {
    enum OutputChannel {
        Mono = 0,
        Stereo = 1,
        Surround5_1 = 2,
        Undefined = 3,
    };
}
namespace app::CH8Em4400::Action::CH8Generate {
    enum AddLayerState {
        Default = 0,
        Generating = 1,
        Break = 2,
    };
}
namespace via {
    enum GroupUIStyle {
        Box = 0,
        NoBorder = 1,
        Expander = 2,
    };
}
namespace app::Em8000ScarController {
    enum TimelineFrame {
        Normal = 0,
        RecoverHead = 1,
        RecoverRightArm = 2,
        RecoverLeftArm = 3,
        RecoverRightLeg = 4,
        RecoverLeftLeg = 5,
        BreakRightLeg = 6,
        BreakLeftLeg = 7,
    };
}
namespace via {
    enum AccountPickerResult {
        None = 0,
        Busy = 1,
        Done = 2,
        Skipped = 3,
        Canceled = 4,
        Disabled = 5,
        UserChanged = 6,
        UserUnchanged = 7,
        DeviceDisconnected = 8,
        Failed = 9,
    };
}
namespace app::CH8Em4200ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
    };
}
namespace via::str {
    enum ComparisonType {
        Ordinal = 0,
        OrdinalIgnoreCase = 1,
    };
}
namespace app::OptionMenu {
    enum HeadRotIndex {
        None = 0,
        AxisZ = 1,
    };
}
namespace app::Em3000::IK::Em8000HandIKController {
    enum Type {
        INVALID = -1,
        None = 0,
        Left = 1,
        Right = 2,
        SUM = 3,
    };
}
namespace via::wwise {
    enum GameObjectIdIndex {
        WwiseDriver = 1,
        WwiseManager = 2,
        Listener_0 = 3,
        Listener_1 = 4,
        Listener_2 = 5,
        Listener_3 = 6,
        Listener_4 = 7,
        Listener_5 = 8,
        Listener_6 = 9,
        Listener_7 = 10,
        Offset = 11,
    };
}
namespace app::CH9Em7900::Action::Breath {
    enum Type {
        Vertical = 0,
        Horizontal = 1,
        Walk = 2,
        Backstep = 3,
        Simple = 4,
    };
}
namespace CH8Em4500Effect {
    enum IDAlias {
        SpitBeam = 0,
        SpitBeamEnd = 1,
        Explosion = 2,
        Contamination = 3,
        CloseCore = 4,
        OpenCore = 5,
    };
}
namespace app::CH8ChangeToneMapProxy {
    enum REQUEST_MODE {
        NONE = 0,
        NORMAL = 1,
        NIGHT_VISION = 2,
    };
}
namespace app::Em3101::Action::Grapple {
    enum Type {
        BedRoomGrapple = 0,
    };
}
namespace app::Collision::CollisionSystem {
    enum AsyncCastRayMode {
        IsHit = 0,
        NearHitDetail = 1,
        AllHitsDetail = 2,
    };
}
namespace via::effect::detail {
    enum EmitterExecuteState {
        Update = 1,
        Reset = 2,
        Kill = 4,
        Stop = 8,
    };
}
namespace via::navigation::AIMapEffector {
    enum NeedUpdate {
        No = 0,
        Yes = 1,
        Force = 2,
    };
}
namespace app::CH8FadeControlForEvent {
    enum FadeStatusEnum {
        OffBlack = 0,
        OnBlack = 1,
    };
}
namespace via::render::Cloudscape {
    enum Visualization {
        None = 0,
        Position = 1,
        Texcoord = 2,
        WeatherTexture = 3,
        BaseShapeTexture = 4,
        DetailShapeTexture = 5,
        Transmittance = 6,
        PhaseFunction = 7,
        SunLight = 8,
        AmbientLight = 9,
        WeightedAverageDepth = 10,
        Powder = 11,
        BeerPowder = 12,
        CloudCoverage = 13,
        CloudTexture = 14,
        RenderedImage = 15,
    };
}
namespace via::vr::psCamera {
    enum PSCameraBaseFormat {
        YUV422 = 0,
        RAW16 = 1,
        RAW8 = 2,
        NO_USE = 16,
        UNKNOWN = 255,
    };
}
namespace app::Em3001::Action::AttackRush {
    enum Type {
        Forward = 0,
        Right = 1,
        Left = 2,
        Back = 3,
    };
}
namespace app::EnemyActionController {
    enum DamageDirection {
        Front = 0,
        Back = 1,
        Left = 2,
        Right = 3,
    };
}
namespace via::render::RenderConfig {
    enum DeinterlaceType {
        Fast = 0,
        Fine = 1,
        TemporalBlend = 2,
    };
}
namespace via::motion {
    enum ChainNodeConstMode {
        Default = 0,
        Matrix = 1,
    };
}
namespace via::storage::saveService::detail::exportToMemory {
    enum ExportToMemoryOption {
        None = 0,
    };
}
namespace app::Em3001::Action {
    enum ActionShort {
        Straight = 0,
        SwingDown = 1,
        LSwingDown = 2,
        Side = 3,
        SwingR = 4,
        LSwingR = 5,
        SwingCombo = 6,
        Grab = 7,
        GrappleHeadButt = 8,
        GrappleKnee = 9,
        NonStepIn = 10,
        SwingL = 11,
        LSwingL = 12,
        AttackRush = 13,
        Num = 14,
        Non = 99,
    };
}
namespace app::CH8Em4000::Action::CH8Grapple {
    enum Type {
        Bite = 0,
        Mount = 1,
        Slash = 2,
    };
}
namespace via::motion::IkHand2::EffectorInfo {
    enum InputType {
        Joint = 0,
        Weight = 1,
    };
}
namespace app::MapManager {
    enum MapObjectState {
        Enable = 0,
        Disable = 1,
    };
}
namespace app::Em8001::Override::Em8001OverrideController {
    enum OverrideActionArg {
        Gesture = 0,
    };
}
namespace app::Em8100::Action::GrabTurn {
    enum Type {
        Right = 0,
        Left = 1,
    };
}
namespace app::Em3600::Action::Attack {
    enum Type {
        LPunchL = 0,
        LPunchR = 1,
        LPunchDown = 2,
        LPunchWalk = 3,
        LUpper = 4,
        LBackSwing = 5,
        RPunchL = 6,
        RPunchR = 7,
        RPunchDown = 8,
        RPunchWalk = 9,
        RUpper = 10,
        RBackSwing = 11,
        BPunchL = 12,
        BPunchR = 13,
        BPunchF = 14,
        BPunchB = 15,
        LPunchLFourLeg = 16,
        LPunchRFourLeg = 17,
        LPunchDownFourLeg = 18,
        RPunchLFourLeg = 19,
        RPunchRFourLeg = 20,
        RPunchDownFourLeg = 21,
        BUpperStandUp = 22,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum TimePanelState {
        TIME_AM = 0,
        TIME_PM = 1,
    };
}
namespace via::nnfc::nfp {
    enum NfpApplet {
        Invalid = 0,
        Register = 1,
        Remove = 2,
        Restore = 3,
    };
}
namespace app::CH9Em7700ActionController {
    enum LostPartsByStomp {
        LeftArm = 0,
        RightArm = 1,
        LeftLeg = 2,
        RightLeg = 3,
        Head = 4,
    };
}
namespace via::network::wrangler {
    enum PopulationSample {
        UseProviderPopulationSample = -2,
        UseSystemPopulationSample = -1,
        Undefined = 0,
    };
}
namespace app::CH9Em7800::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace app::DoorPush {
    enum State {
        Closed = 0,
        Locked = 1,
        LittleOpen = 2,
        Push = 3,
        AutoOpen = 4,
        Opened = 5,
        AutoClose = 6,
    };
}
namespace app::Em4100ActionController {
    enum DodgeQueType {
        Left = 0,
        Right = 1,
    };
}
namespace app::MapManager {
    enum MapCategoryDef {
        None = 0,
        Chapter3_Main = 1,
        Chapter3_Main_East = 2,
        Chapter3_Garden = 3,
        Chapter3_3_OldHouse = 4,
        Chapter3_4_Lucas = 5,
        Chapter3_5_Boat = 6,
        Chapter4_1 = 7,
        Chapter4_2 = 8,
        Chapter4_3 = 9,
        Chapter1 = 10,
        Chapter1_Out = 11,
        Chapter0 = 12,
        Chapter8_1 = 13,
        Chapter8_2 = 14,
        Chapter8_3 = 15,
        Chapter8_4 = 16,
        Chapter8_5 = 17,
        Chapter8_6 = 18,
        Chapter8_7 = 19,
    };
}
namespace app::fsm::ElevatorDoor {
    enum ActionType {
        Open = 0,
        Close = 1,
    };
}
namespace app::Em8000::Override::Em8000OverrideController {
    enum State {
        None = 0,
        WalkNormalC3B2Final = 1,
        WalkTurn = 2,
        OverrideIdle = 3,
        ScissorsGesture = 4,
        CoreLoop = 5,
    };
}
namespace via::navigation::NavigationSurface {
    enum PortalOffsetSizeType {
        Ratio = 0,
        Distance = 1,
    };
}
namespace app::fsm::CH8InitSystemSaveData {
    enum State {
        Init = 0,
        SystemLoading = 1,
        SystemSaveing = 2,
        SystemLoadFailed = 3,
        SystemSaveFailed = 4,
        CheckGameData = 5,
        SaveGameData = 6,
        SaveGameDataFailed = 7,
        Idle = 8,
    };
}
namespace via::render::RichDecal {
    enum HeightBlendMode {
        Ignore = 0,
        Add = 1,
        Mul = 2,
    };
}
namespace via::vr::psCamera {
    enum PSCameraResolution {
        PSCameraResolution_1280X800 = 0,
        PSCameraResolution_640X400 = 1,
        PSCameraResolution_320X200 = 2,
        PSCameraResolution_160X100 = 3,
        PSCameraResolution_320X192 = 4,
        PSCameraResolution_SPECIFIED_WIDTH_HEIGHT = 5,
        PSCameraResolution_UNKNOWN = 255,
    };
}
namespace app::CH8Em4450::CH8Em4450ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH9Em7700::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace app::Em8001::Override::Em8001OverrideController {
    enum BlendState {
        None = 0,
        StartBlend = 1,
        Blend = 2,
        EndBlend = 3,
    };
}
namespace app::GasBomb {
    enum Rno {
        Running = 0,
        Detonation = 1,
        Interval = 2,
        Exploded = 3,
        End = 4,
    };
}
namespace via::render::WaveOpticalLensFlare {
    enum LensFlareType {
        First = 0,
        Second = 1,
        Third = 2,
    };
}
namespace via::AABB {
    enum EdgeId {
        EdgeId_011_TO_111 = 0,
        EdgeId_111_TO_101 = 1,
        EdgeId_101_TO_001 = 2,
        EdgeId_001_TO_011 = 3,
        EdgeId_010_TO_110 = 4,
        EdgeId_110_TO_100 = 5,
        EdgeId_100_TO_000 = 6,
        EdgeId_000_TO_010 = 7,
        EdgeId_010_TO_011 = 8,
        EdgeId_110_TO_111 = 9,
        EdgeId_100_TO_101 = 10,
        EdgeId_000_TO_001 = 11,
        EdgeId_Max = 12,
    };
}
namespace via::network::error {
    enum MethodP2p {
        Update = 0,
        Connect = 1,
    };
}
namespace app::CH9Em7800::ThinkAppearSet {
    enum Type {
        Default = 0,
        NoUse_Wall1 = 1,
        NoUse_Wall2 = 2,
        FromWall3_Normal = 3,
        FromWall4_Speedy = 4,
        FromCeil1_Normal = 5,
        FromCeil2_Speedy = 6,
        FirstAppear = 7,
        FromLakeL = 8,
        FromLakeR = 9,
        NoUse_Chandelier = 100,
        NoUse_CeilingLoop = 200,
        NoUse_FromWallLeftLoop = 201,
        NoUse_FromWallRightLoop = 202,
        Summon = 203,
    };
}
namespace app::CH8Em4450::Action::CH8Grapple {
    enum Type {
        Exprotion = 0,
    };
}
namespace via::render {
    enum DefaultResolution {
        DefaultResolution_1080p = 1080,
        DefaultResolution_1260p = 1260,
        DefaultResolution_1440p = 1440,
        DefaultResolution_1620p = 1620,
        DefaultResolution_1800p = 1800,
        DefaultResolution_1890p = 1890,
        DefaultResolution_1980p = 1980,
        DefaultResolution_2070p = 2070,
        DefaultResolution_2160p = 2160,
    };
}
namespace app::vr {
    enum StickRotationMode {
        Analogue = 0,
        Digital = 1,
    };
}
namespace via::hid::detail::SceneObserver {
    enum SceneStatus {
        Paused = 0,
        Resumed = 1,
        Construct = 2,
        Preview = 3,
    };
}
namespace via::motion::IkLegSpine {
    enum SkipStatus {
        None = 0,
        Start = 1,
        Skip = 2,
        End = 3,
    };
}
namespace via::dynamics::PrismaticConstraint::Initializer {
    enum PositionType {
        World = 0,
        Local = 1,
    };
}
namespace app::TutorialGUI {
    enum VRAdjustMode {
        NORMAL = 0,
        CLOSE = 1,
        VERY_CLOSE = 2,
    };
}
namespace via::hid {
    enum NpadJoyAssignmentMode {
        Dual = 0,
        Single = 1,
        None = 2,
    };
}
namespace app::Telemetry {
    enum ClearTimeTypeDLC {
        CrazyHouse = 0,
    };
}
namespace via::audiorender {
    enum Channel_7ch {
        L = 0,
        R = 1,
        C = 2,
        Lrs = 3,
        Rrs = 4,
        Ls = 5,
        Rs = 6,
        Max = 7,
    };
}
namespace app::CH9Em7700::Action::FinishBlow {
    enum Type {
        SneakB = 0,
        FinishblowL = 1,
        FinishblowR = 2,
    };
}
namespace app::CH9DifficultySelectGUI {
    enum StepType {
        Wait = 0,
        Decide = 1,
        Cancel = 2,
    };
}
namespace app::WeaponProperties {
    enum CustomizeWeaponType {
        Handgun = 0,
        Shotgun = 1,
        Machinegun = 2,
        CloseCombat = 3,
        Grenade = 4,
        Magnum = 5,
        Burner = 6,
        Bomb = 7,
        Unknown = 8,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData {
    enum PackFlags {
        None = 0,
        InputPack = 1,
    };
}
namespace app::EnemyActionController {
    enum DamageAttribute {
        None = 0,
        Fire = 1,
        Acid = 2,
        Explode = 3,
    };
}
namespace app::EnvironmentEffectManager {
    enum RequestStatus {
        None = 0,
        Create = 1,
    };
}
namespace via::behaviortree::SelectorSequence {
    enum RunType {
        Loop = 0,
        Once = 1,
        OnceEnd = 2,
    };
}
namespace app::FirstSettingMenu {
    enum ListElemID {
        GoNext = 0,
        Option = 1,
    };
}
namespace via::render {
    enum IndexBufferFormat {
        U16 = 0,
        U32 = 1,
        Unknown = 2,
    };
}
namespace via::CoreEntry {
    enum DevelopPlatform {
        Default = 0,
        X64 = 1,
        PS4 = 2,
        XB1 = 3,
        UWP = 4,
        NSW = 5,
        STM = 6,
        WGM = 7,
        PS5 = 8,
        NIX = 9,
        STADIA = 10,
        Android = 11,
        iOS = 12,
        UBT = 13,
        MSG = 14,
        XBS = 15,
        SOL = 16,
        Mac = 17,
    };
}
namespace app::Em4000::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace via::effect::gpgpu::detail {
    enum ShapeType {
        AABB = 0,
        OBB = 1,
        Sphere = 2,
    };
}
namespace via::render::VolumetricFogControl {
    enum TextureSize {
        W160xH90xD64 = 0,
        W160xH90xD128 = 1,
    };
}
namespace app::Em8000BattleDirective::HandBattleParameter {
    enum ZeroAttackType {
        None = 0,
        Throw = 1,
        Knee = 2,
        HedButt = 3,
    };
}
namespace via::effect::lensflare {
    enum FilterType {
        Global = 0,
        Glow = 1,
        Iris = 2,
        MultiIris = 3,
        Hoop = 4,
        Max = 5,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraConfigType {
        Unknown = 0,
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
        Type4 = 4,
        Extention = 16,
    };
}
namespace app::Em3000::Goal::Chapter3Battle2 {
    enum Message {
        Non = 0,
        AppearEnd = 1,
        Battle1 = 2,
        Battle2 = 3,
        Battle3 = 4,
    };
}
namespace via::physics::Shape {
    enum State {
        Enabled = 0,
        Max = 1,
    };
}
namespace via::os::http_client {
    enum Error {
        Unavailable = -2,
        Pending = -1,
        None = 0,
    };
}
namespace app::OverrideAction {
    enum Layer {
        Layer1 = 0,
        Layer2 = 1,
        Layer3 = 2,
        Layer4 = 3,
        Layer5 = 4,
        Layer6 = 5,
        Layer7 = 6,
        Layer8 = 7,
        Layer9 = 8,
        Layer10 = 9,
    };
}
namespace app::InventoryContextMenu {
    enum Mode {
        Item = 0,
        ItemBox2Inventory = 1,
        ItemBox2InventoryOne = 2,
        Inventory2ItemBox = 3,
        Inventory2ItemBoxOne = 4,
    };
}
namespace app::FileMenu {
    enum ProcDef {
        File = 0,
        List = 1,
    };
}
namespace app::fsm::CH8RequestFade {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace app::Em4000::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::motion::IkSpine::ManageJoint {
    enum JOINT_TYPE {
        NON = 0,
        START = 1,
        RAY = 2,
        END = 3,
    };
}
namespace via::gui::detail {
    enum LetterAlignmentV {
        Top = 0,
        Center = 1,
        Bottom = 2,
        Baseline = 3,
    };
}
namespace via::render {
    enum VolumetricFogType {
        Global = 0,
        Box = 1,
        BoxWorldOffset = 2,
    };
}
namespace via::navigation::NavigationWaypoint {
    enum SearchRegion {
        None = 0,
        Only = 1,
        Priority = 2,
    };
}
namespace app::CH9Em6400ArmController {
    enum State {
        DefaultArm = 0,
        ChangeExtendArm = 1,
        ExtendArm = 2,
        ChangeDefaultArm = 3,
    };
}
namespace via::hid::gamePlayer {
    enum DeviceSelectionRule {
        AssignButtonDown = 0,
        AssignButtonUp = 1,
    };
}
namespace app::PlayerExternalRequestController {
    enum State {
        Enter = 0,
        Run = 1,
        Exit = 2,
    };
}
namespace app::WaveEndDesc {
    enum Type {
        Continue = 0,
        Last = 1,
    };
}
namespace app::CH8Em4500::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        Stand = 1,
        Fall = 2,
    };
}
namespace app::Em4100::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromRear = 8,
        IsTargetDamage = 9,
        IsAttackFromFrontWithDirective = 10,
        IsSlipFire = 11,
        AdditiveSensedAttack = 12,
    };
}
namespace app::MapObject {
    enum MapObjectTypeDef {
        None = 0,
        Item = 2,
        SavePoint = 3,
        ItemBox = 4,
        PharmacyDictionary = 5,
        KeyPickBox = 7,
        SpareKey = 24,
        BirthdayJack = 51,
    };
}
namespace via::motion::detail {
    enum ChainDebugMode {
        DebugDraw = 0,
        CheckBlendRate = 1,
        CheckFreezePose = 2,
        CheckWind = 3,
    };
}
namespace app::PlayerBreathController {
    enum HealthConditionEnum {
        Fine = 0,
        Dying = 1,
    };
}
namespace app::InteractNumberLock {
    enum NumberLockModeParam {
        Normal = 0,
        ForceError = 1,
    };
}
namespace app::GameOverScreen {
    enum ModeDef {
        Normal = 0,
    };
}
namespace app::VrGui {
    enum VrTrackModeDef {
        GameObject = 0,
        Controller = 1,
        SpecifyPosition = 2,
        FixedTransformWhenOpenMenu = 3,
        FixedTrackingPosition = 4,
        SpecifyPositionLocalOffset = 5,
    };
}
namespace app::Em4000::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::Em5510::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        Interval = 2,
        Generate = 3,
        GenerateWait = 4,
        Passive = 5,
        PassiveGenerate = 6,
        Dead = 7,
        GenerateActionEm5400 = 8,
        GenerateActionEm5520 = 9,
        DeadAction = 10,
    };
}
namespace via::motion {
    enum JointExType {
        None = 0,
        Rotation = 1,
        RotToScale = 2,
        RotToScaleEx = 3,
        RotToTrans = 4,
        RotToTransEx = 5,
        Finger = 6,
        Thumb = 7,
        RotToRot = 8,
        RotToRotEx = 9,
        Limit = 10,
        PointConstraint = 11,
        ParentConstraint = 12,
        BsplineConstraint = 13,
        RemapValue = 14,
        MultiRemapValue = 15,
        Rotation2 = 16,
    };
}
namespace System::Runtime::InteropServices {
    enum LayoutKind {
        Sequential = 0,
        Explicit = 2,
        Auto = 3,
    };
}
namespace via::vr::psCamera {
    enum PSCameraConfigType {
        Unknown = 0,
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
        Type4 = 4,
        Type5 = 5,
        Extention = 16,
    };
}
namespace via::gui::detail {
    enum MaskLayer {
        Default = 0,
        Top = 1,
        TopMost = 2,
        Max = 3,
    };
}
namespace System::Diagnostics::DebuggableAttribute {
    enum DebuggingModes {
        None = 0,
        Default = 1,
        DisableOptimizations = 2,
        IgnoreSymbolStoreSequencePoints = 3,
        EnableEditAndContinue = 4,
    };
}
namespace app::CH9EnemyOrder::FinishBlowInfo {
    enum Type {
        SneakB = 0,
        Down = 1,
        Chase = 2,
        Finish = 3,
    };
}
namespace via::motion {
    enum MotionAppendDataClassType {
        Unknown = 0,
        Vec2 = 1,
        Vec3 = 2,
        Vec4 = 3,
        Quaternion = 4,
        Matrix = 5,
    };
}
namespace app::CH8Em4200::Action::CH8Breath {
    enum Type {
        Vertical = 0,
        Horizontal = 1,
        Walk = 2,
        Simple = 3,
    };
}
namespace LibJson {
    enum ValueType {
        Unknown = 0,
        Object = 1,
        Array = 2,
        String = 3,
        Number = 4,
        True = 5,
        False = 6,
        Null = 7,
    };
}
namespace app::Em8950::Action {
    enum ActionNo {
        Idle_Move = 0,
        Idle_Offense = 1,
        MoveForward = 2,
        Damage = 3,
        Dead = 4,
        BiteAttack = 5,
        BiteAttackGrapple = 6,
        Appear = 7,
    };
}
namespace app::CH9Em7800::Action {
    enum ActionNo {
        Attack = 4,
        StrikeScratch = 5,
        StrikeDash = 6,
        StrikeJump = 7,
        StrikeLongJump = 8,
        StrikeBackblow = 9,
        StrikeToGuard = 10,
        StrikeDuctPursuit = 11,
        WallAttack = 12,
        Backstep = 13,
        ChanceCounter = 14,
        BlownAway = 15,
        SlipFire = 16,
        SlipAcid = 17,
        Notice = 18,
        Threat = 19,
        Dodge = 20,
        DamageToMove = 21,
        Climb = 22,
        AroundFlewover = 23,
        Grapple = 24,
        Appear = 25,
        Falling = 26,
        Suspend = 27,
        Resume = 28,
        FinishBlow = 29,
        WanderIdle = 30,
        Wander = 31,
    };
}
namespace via::motion::tree {
    enum NodeType {
        Unknown = 0,
        Motion = 1,
        Param = 2,
    };
}
namespace via::areamap::test::DistanceFromQueryRegion {
    enum Condition {
        Mode_Closest = 0,
        Mode_Farthest = 1,
    };
}
namespace app::Em4000ActionPoint {
    enum Type {
        ClimbWall40 = 0,
        ClimbWall79 = 1,
        ClimbWall80 = 2,
        ClimbWall119 = 3,
        ClimbOver80 = 4,
        ClimbOver119 = 5,
        ClimbOver150 = 6,
        WarpTo = 7,
    };
}
namespace System::Security::Permissions {
    enum SecurityAction {
        Demand = 2,
        Assert = 3,
        Deny = 4,
        PermitOnly = 5,
        LinkDemand = 6,
        InheritanceDemand = 7,
        RequestMinimum = 8,
        RequestOptional = 9,
        RequestRefuse = 10,
    };
}
namespace via::navigation::map::LineSegmentXZ {
    enum CrossCond {
        NO_CONTACT = 0,
        CROSS = 1,
        OVERLAP = 2,
        T_TYPE_V = 256,
        T_TYPE_H = 512,
        L_TYPE = 1024,
        I_TYPE = 2048,
        INCLUSION = 4096,
        HALF_INCLUSION = 8192,
        INCLUDED_BY = 16384,
        HALF_INCLUDED_BY = 32768,
    };
}
namespace app::SampleShell {
    enum ShellType {
        Normal = 0,
        Homing = 1,
    };
}
namespace via::eq::Var {
    enum Type {
        Float = 0,
        Color = 1,
    };
}
namespace via {
    enum GamePresetsSubtitles {
        Default = 0,
        Off = 1,
        On = 2,
    };
}
namespace app::fsm::ElevatorButtonCheck {
    enum CheckType {
        Use = 0,
        SameFloor = 1,
        OpenDoor = 2,
        CloseDoor = 3,
        SecurityLock = 4,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1Final {
    enum Message {
        Non = 0,
        AppearEnd = 1,
    };
}
namespace via {
    enum Language {
        Japanese = 0,
        English = 1,
        French = 2,
        Italian = 3,
        German = 4,
        Spanish = 5,
        Russian = 6,
        Polish = 7,
        Dutch = 8,
        Portuguese = 9,
        PortugueseBr = 10,
        Korean = 11,
        TransitionalChinese = 12,
        SimplelifiedChinese = 13,
        Finnish = 14,
        Swedish = 15,
        Danish = 16,
        Norwegian = 17,
        Czech = 18,
        Hungarian = 19,
        Slovak = 20,
        Arabic = 21,
        Turkish = 22,
        Bulgarian = 23,
        Greek = 24,
        Romanian = 25,
        Thai = 26,
        Ukrainian = 27,
        Vietnamese = 28,
        Indonesian = 29,
        Fiction = 30,
        Hindi = 31,
        LatinAmericanSpanish = 32,
        Max = 33,
        Unknown = 33,
    };
}
namespace via::motion::IkLookAt {
    enum ViewState {
        None = 0,
        Move = 1,
        Follow = 2,
    };
}
namespace app::VrMotSickMeasureGui {
    enum TypeDef {
        None = 0,
        Type1 = 1,
    };
}
namespace app::MapManager {
    enum ChapterSaveSlot {
        Chapter1 = 0,
        Chapter3 = 1,
        Chapter4 = 2,
        _Count = 3,
    };
}
namespace via::audiorender::fx {
    enum FxUnitType {
        None = 0,
        MTLimitter = 1,
        MTCompressor = 2,
        IIR1Filter = 3,
        BiquadFilter = 4,
        AllPassFilter = 5,
        MTEqualizer = 6,
        MultiBandEq = 7,
        Delay = 8,
        DelayLine = 9,
        FDN4 = 10,
        Reverb = 11,
        Test0 = 12,
        Test1 = 13,
        Test2 = 14,
        Number = 15,
        Distortion = 16,
        TubeDrive = 17,
        OverDrive = 18,
    };
}
namespace via::clr {
    enum MethodSemanticsFlag {
        Setter = 1,
        Getter = 2,
        Other = 4,
        AddOn = 8,
        RemoveOn = 16,
        Fire = 32,
    };
}
namespace app::CH9Em6400::Action::AttackBack {
    enum Type {
        PunchBR = 0,
        PunchBL = 1,
    };
}
namespace via::curve {
    enum EaseType {
        Linear = 0,
        InSine = 1,
        OutSine = 2,
        InOutSine = 3,
        InQuad = 4,
        OutQuad = 5,
        InOutQuad = 6,
        InCubic = 7,
        OutCubic = 8,
        InOutCubic = 9,
        InQuart = 10,
        OutQuart = 11,
        InOutQuart = 12,
        InQuint = 13,
        OutQuint = 14,
        InOutQuint = 15,
        InExpo = 16,
        OutExpo = 17,
        InOutExpo = 18,
        InCirc = 19,
        OutCirc = 20,
        InOutCirc = 21,
        InBack = 22,
        OutBack = 23,
        InOutBack = 24,
        InElastic = 25,
        OutElastic = 26,
        InOutElastic = 27,
        InBounce = 28,
        OutBounce = 29,
        InOutBounce = 30,
    };
}
namespace via::render {
    enum LocalCubemapInternalResolution {
        Low = 128,
        Default = 256,
        High = 512,
        Highest = 1024,
    };
}
namespace app::Pad {
    enum Button {
        LeftUp = 1,
        LeftRight = 2,
        LeftDown = 3,
        LeftLeft = 4,
        RightUp = 5,
        RightRight = 6,
        RightDown = 7,
        RightLeft = 8,
        LeftTriggerTop = 9,
        LeftTriggerBottom = 10,
        RightTriggerTop = 11,
        RightTriggerBottom = 12,
        LeftStickPush = 13,
        RightStickPush = 14,
        CenterLeft = 15,
        CenterRight = 16,
        CenterCenter = 17,
        PlatformHome = 18,
        Decide = 19,
        Cancel = 20,
        TouchPadLeft = 21,
        TouchPadRight = 22,
        MaxButtonNum = 23,
    };
}
namespace via::audiorender {
    enum SimpleFdnReverbParameter {
        DryVolume = 0,
        DryVolumeDb = 1,
        WetVolumeDb = 2,
        HF = 3,
        ReverbTime = 4,
        PreDelay = 5,
        Density = 6,
    };
}
namespace app::ItemCombiner {
    enum Index {
        First = 0,
        Second = 1,
        Num = 2,
    };
}
namespace app::CH9PlayerEquipManager {
    enum WwiseSwitchListForEquipGauntlet {
        None = 0,
        LeftOnly = 1,
        Both = 2,
    };
}
namespace via::timeline {
    enum StartType {
        OverFrame = 0,
        StartFrame = 1,
    };
}
namespace via::dialog::core {
    enum dummy {
    };
}
namespace app::AI::AIWorldBlackBoard {
    enum MoldedStateEnum {
        FULL = 0,
        LAYER = 1,
        BASS = 2,
        ENCOUNT = 3,
        LOST_PL = 4,
        INTENSITY = 5,
        SILENCE = 6,
    };
}
namespace via::render::VolumeDecal {
    enum OpacityFlag {
        None = 0,
        BaseColor = 1,
        Normal = 2,
        Emissive = 8,
        BaseColorAndNormal = 3,
        BaseColorAndEmissive = 9,
        NormalAndEmissive = 10,
        All = 11,
    };
}
namespace via::hid::HIDEntry {
    enum RemotePlayKeyAssign {
        PatternA = 0,
        PatternB = 1,
        PatternC = 2,
        PatternD = 3,
        PatternE = 4,
        PatternF = 5,
        PatternG = 6,
        PatternH = 7,
    };
}
namespace via::audiorender {
    enum Channel_4oAmb {
        Channel_4oAmb_0 = 0,
        Channel_4oAmb_1 = 1,
        Channel_4oAmb_2 = 2,
        Channel_4oAmb_3 = 3,
        Channel_4oAmb_4 = 4,
        Channel_4oAmb_5 = 5,
        Channel_4oAmb_6 = 6,
        Channel_4oAmb_7 = 7,
        Channel_4oAmb_8 = 8,
        Channel_4oAmb_9 = 9,
        Channel_4oAmb_10 = 10,
        Channel_4oAmb_11 = 11,
        Channel_4oAmb_12 = 12,
        Channel_4oAmb_13 = 13,
        Channel_4oAmb_14 = 14,
        Channel_4oAmb_15 = 15,
        Channel_4oAmb_16 = 16,
        Channel_4oAmb_17 = 17,
        Channel_4oAmb_18 = 18,
        Channel_4oAmb_19 = 19,
        Channel_4oAmb_20 = 20,
        Channel_4oAmb_21 = 21,
        Channel_4oAmb_22 = 22,
        Channel_4oAmb_23 = 23,
        Channel_4oAmb_24 = 24,
        Channel_4oAmb_Max = 25,
    };
}
namespace app::EnemyMessage {
    enum Tag {
        CounterableForGrapple = 0,
        CounterableBombForGrapple = 1,
        ResistableForGrapple = 2,
    };
}
namespace via::gui {
    enum GridInputDirection {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1FinalDrivePL {
    enum PLDriveStatus {
        Non = 0,
        GotoCarFront = 1,
        ArriveCarFront = 2,
    };
}
namespace app::fsm::ItemTest {
    enum CheckTarget {
        Inventory = 0,
        ItemBox = 1,
        InventoryAndItemBox = 2,
    };
}
namespace via {
    enum SystemServiceOperationMode {
        Handheld = 0,
        Console = 1,
    };
}
namespace via::motion::IkHand2 {
    enum SkipStatus {
        None = 0,
        Start = 1,
        Skip = 2,
        End = 3,
    };
}
namespace via::sound {
    enum SoundCurveYValueType {
        FloatValue = 0,
        IntValue = 1,
        BoolValue = 2,
        EnumValue = 100,
        DbValue = 200,
    };
}
namespace via::effect::gpgpu::detail {
    enum VectorFieldFlags {
        Tiled = 1,
        Local = 2,
        NormalizeLocalVector = 4,
        NormalizeGlobalVector0 = 8,
        NormalizeGlobalVector1 = 16,
        NormalizeGlobalVector2 = 32,
        NormalizeGlobalVector3 = 64,
        NormalizeGlobalVector4 = 128,
        NormalizeGlobalVector5 = 256,
        LocalGlobalVector0 = 512,
        LocalGlobalVector1 = 1024,
        LocalGlobalVector2 = 2048,
        LocalGlobalVector3 = 4096,
        LocalGlobalVector4 = 8192,
        LocalGlobalVector5 = 16384,
    };
}
namespace app::PlayerCamera {
    enum RotationSpeedType {
        Speed0 = 0,
        Speed1 = 1,
        Speed2 = 2,
        Speed3 = 3,
        Speed4 = 4,
        Speed5 = 5,
        Speed6 = 6,
        Speed7 = 7,
        Speed8 = 8,
        Speed9 = 9,
        Speed10 = 10,
    };
}
namespace app::AI::CH8MoldedCommonBoard {
    enum RenderTargetStatusEnum {
        None = 0,
        Used = 1,
        UsedFromDead = 2,
    };
}
namespace via::render::BlendShapeController {
    enum BakedTextureUV {
        Primary = 0,
        Secondary = 1,
    };
}
namespace app::FsmBirthday::FirstTutorial {
    enum OpTypeEnum {
        CheckFlag = 0,
        SetFlag = 1,
        Max = 2,
    };
}
namespace via::areamap::test::DistanceFromItemWithTag {
    enum Limit {
        CurrentArea = 0,
        AllAreas = 1,
    };
}
namespace app::CH8Em4400ActionController {
    enum Egg {
        Head = 0,
        Chest = 1,
        Stomach = 2,
        Thigh = 3,
    };
}
namespace via::keyframe::ChannelBase {
    enum DataType {
        Bool = 0,
        S8 = 1,
        U8 = 2,
        S16 = 3,
        U16 = 4,
        S32 = 5,
        U32 = 6,
        S64 = 7,
        U64 = 8,
        F32 = 9,
        F64 = 10,
        Str8 = 11,
        Str16 = 12,
        Vec2 = 13,
        Vec3 = 14,
        Vec4 = 15,
        Quaternion = 16,
    };
}
namespace via::gui::renderer::detail {
    enum CsPriority {
        CSUpdate_0 = 0,
        CSUpdate_1 = 16,
        CSUpdate_2 = 32,
    };
}
namespace via::hid::detail {
    enum HidAllocatorGpuBuss {
        Onion = 0,
        Garlic = 1,
    };
}
namespace app::AdditionalItemManager {
    enum AdditionalKindEnum {
        StorePrivilege_A = 0,
        StorePrivilege_B = 1,
        StorePrivilege_C = 2,
        StorePrivilege_D = 3,
        StorePrivilege_E = 4,
        StorePrivilege_G = 5,
        StorePrivilege_H = 6,
        StorePrivilege_I = 7,
        StorePrivilege_J = 8,
        StorePrivilege_K = 9,
        StorePrivilege_L = 10,
        StorePrivilege_M = 11,
        StorePrivilege_N = 12,
        DLC_Item_A = 13,
        DLC_Item_B = 14,
        DLC_Item_C = 15,
        DLC_Item_D = 16,
        DLC_Item_E = 17,
        DLC_Item_G = 18,
        DLC_Item_H = 19,
        DLC_Item_I = 20,
        DLC_Item_J = 21,
        DLC_Item_K = 22,
        DLC_Item_L = 23,
        DLC_Item_M = 24,
        DLC_Item_N = 25,
        Max = 26,
    };
}
namespace via::dialog {
    enum ButtonType {
        Ok = 0,
        YesNo = 1,
        None = 2,
        OkCancel = 3,
        Wait = 4,
        WaitCancel = 5,
    };
}
namespace via {
    enum AppletResult {
        None = 0,
        Done = 1,
        Skipped = 2,
        Canceled = 3,
        Failed = 4,
    };
}
namespace app::Em8000::Action::Em8000Dead {
    enum Type {
        LegBreak = 0,
    };
}
namespace app::fsm::CH8SetDoorState {
    enum SetState {
        NotSet = 0,
        Lock = 1,
        Unlock = 2,
        OpenFront = 3,
        OpenBack = 4,
        LittleOpenFront = 5,
        LittleOpenBack = 6,
        ContinuousOpenFront = 7,
        ContinuousOpenBack = 8,
        ContinuousOpenAuto = 9,
        ContinuousLittleOpenFront = 10,
        ContinuousLittleOpenBack = 11,
        ContinuousLittleOpenAuto = 12,
        ContinuousLock = 13,
        ContinuousUnlock = 14,
    };
}
namespace app::InventoryMenu {
    enum ItemBoxMode {
        Default = 0,
        ItemSetting = 1,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraStopResult {
        OK = 1,
        Stoped = 1,
        ErrInternal = 2147487744,
    };
}
namespace app::Em8100::Action::Attack {
    enum Type {
        StrikeR = 0,
        StrikeL = 1,
        StrikeOnBeamR = 2,
        StrikeOnBeamL = 3,
        StrikeBeamR = 4,
        StrikeBeamL = 5,
        TStrikeBeamR = 6,
        TStrikeBeamL = 7,
        StrikeGrabR = 8,
        StrikeGrabL = 9,
        StrikeStandR = 10,
        StrikeStandL = 11,
        TStrikeStandR = 12,
        TStrikeStandL = 13,
        CleaveR = 14,
        CleaveL = 15,
        TailR = 16,
        TailL = 17,
        Non = 99,
    };
}
namespace via::motion::CppSampleTracks {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
    };
}
namespace app::CH8Em4100::CH8ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::gui {
    enum TextAnimationCondition {
        Start = 0,
        Play = 1,
        Pause = 2,
        End = 3,
    };
}
namespace app::CH8PlayerDeathSound {
    enum DeathTable {
        silence = 0,
        death_roar = 1,
        death_end = 2,
    };
}
namespace app::Em3002Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Ghost = 100,
    };
}
namespace app::Em8001::Define::Grapple {
    enum FsmState {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
    };
}
namespace via::clr {
    enum MethodImplFlag {
        CodeTypeMask = 3,
        IL = 0,
        Native = 1,
        OPTIL = 2,
        Runtime = 3,
        ManagedMask = 4,
        Unmanaged = 4,
        Managed = 0,
        ForwardRef = 16,
        PreserveSig = 128,
        InternalCall = 4096,
        Synchronized = 32,
        NoInlining = 8,
        AggressiveInlining = 256,
        NoOptimization = 64,
        HasRetVal = 512,
        ExposeMember = 1024,
        EmptyCtor = 2048,
        ContainsGenericParameters = 8192,
        HasThis = 16384,
        ThreadSafe = 32768,
    };
}
namespace app::Telemetry {
    enum SendTimingType {
        SelectQuit = 0,
        SelectRestart = 1,
        YouAreDead = 2,
        EndChapterOrFF = 3,
        ManualSave = 4,
        SystemSave = 5,
        ExtraQuit = 6,
        ExtraResult = 7,
        GameClear = 8,
        DLCResult = 9,
        IMDClear = 10,
        Active = 11,
        TransferSaveData = 12,
        StoreTransition = 13,
    };
}
namespace app::fsm::CH8StateCheck {
    enum BoolType {
        None = 0,
        Grapple = 1,
        Damage = 2,
        Dead = 3,
        Crouch = 4,
    };
}
namespace via::network::error {
    enum CauseInvitation {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        AlreadyAccepted = 129,
        InvalidSessionInfo = 130,
    };
}
namespace via::fsm {
    enum FsmSelectorType {
        Graph = 0,
    };
}
namespace app::PlayerCamera::CameraController {
    enum TransitionState {
        None = 0,
        Fadein = 1,
        Peek = 2,
        Fadeout = 3,
    };
}
namespace via::effect::gpgpu::detail {
    enum GpuEmitterShape {
        None = 0,
        Sphere = 1,
        Cylinder = 2,
        Box = 3,
    };
}
namespace via::motion::IkLeg2 {
    enum EffectorCtrl {
        None = 0,
        LocalOffset = 1,
        WorldOffset = 2,
        Local = 3,
        World = 4,
    };
}
namespace app::EnemyGrappleBase {
    enum PosLerpProcessType {
        None = 0,
        ToNullOffsetMove = 1,
    };
}
namespace via::network::error {
    enum CauseUser {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        Logouted = 129,
    };
}
namespace app::vr {
    enum DeviceStatus {
        Disabled = 0,
        Inactive = 1,
        Active = 2,
    };
}
namespace app::EnemyActionController {
    enum DamageScale {
        S = 0,
        M = 1,
        L = 2,
    };
}
namespace via::audiorender {
    enum Channel_2oAmb {
        Channel_2oAmb_0 = 0,
        Channel_2oAmb_1 = 1,
        Channel_2oAmb_2 = 2,
        Channel_2oAmb_3 = 3,
        Channel_2oAmb_4 = 4,
        Channel_2oAmb_5 = 5,
        Channel_2oAmb_6 = 6,
        Channel_2oAmb_7 = 7,
        Channel_2oAmb_8 = 8,
        Channel_2oAmb_Max = 9,
    };
}
namespace app::Em3002::Goal::BattleRest {
    enum LeaveStatus {
        Non = 0,
        Leave = 1,
        Arrive = 2,
    };
}
namespace app::fsm::EmLoadRequest {
    enum LoadTypeEnum {
        Load = 0,
        UnLoad = 1,
        MAX = 2,
    };
}
namespace app::OptionKeyBind {
    enum ErrorCheckType {
        PlayerInGameMenu = 0,
        PauseCommon = 1,
        MapCommon = 2,
        InventoryCommon = 3,
        ItemBoxCommon = 4,
        ItemBoxConfirm = 5,
        TwentyOneCommand = 6,
        _Max = 7,
    };
}
namespace app::CH8PlayerGrowthManager {
    enum SiteScope {
        TypeA = 0,
        TypeB = 1,
        TypeC = 2,
    };
}
namespace app::Em4200::Action {
    enum ActionNo {
        MountTry = 4,
        Grapple = 5,
        Appear = 6,
        LostParts = 7,
        BlownAway = 8,
        SlipFire = 9,
        SlipAcid = 10,
        Falling = 11,
        Feint = 12,
        Anger = 13,
        Rush = 14,
        Splash = 15,
        Breath = 16,
        BreathFirst = 17,
        BreathForce = 18,
        ChanceCounter = 19,
        DamageToMove = 20,
        DamageToBreath = 21,
        Wait = 22,
        Suspend = 23,
        Resume = 24,
        Warp = 25,
    };
}
namespace via {
    enum DateFormat {
        YYYYMMDD = 0,
        DDMMYYYY = 1,
        MMDDYYYY = 2,
        Max = 3,
        Unknown = 3,
    };
}
namespace via::landscape {
    enum BlendType {
        Adaptive = 0,
        Bilinear = 1,
        NoBlend = 2,
        Max = 3,
    };
}
namespace via::render {
    enum LightingOption {
        Legacy = 0,
        Default = 1,
        High = 2,
        Spherical = 3,
        SphericalHigh = 4,
    };
}
namespace app::Em8001::Define::Facial {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum StartResult {
        OK = 0,
        ErrorNotSupported = 1,
        ErrorNotStandby = 2,
        ErrorStartupFailed = 3,
    };
}
namespace app::PlayerLighter {
    enum AssistLightState {
        Off = 0,
        On = 1,
        LighterOn = 2,
    };
}
namespace via::motion::detail::CashSkeleton {
    enum ConstructStatus {
        NotBuild = 0,
        PartlyBuilt = 1,
        FullBuilt = 2,
    };
}
namespace app::Collision::HitController::DamageInfo {
    enum Scale {
        L = 0,
        M = 1,
        S = 2,
    };
}
namespace app::Em8001::IK::Em8001FBIKController::FBIKStatus {
    enum State {
        INVALID = -1,
        None = 0,
        Start = 1,
        Up = 2,
        Stay = 3,
        Down = 4,
        End = 5,
        SUM = 6,
    };
}
namespace via::gui {
    enum FontColorType {
        Fill = 0,
        Vertical = 1,
    };
}
namespace app::Inventory {
    enum AddItemResult {
        Put = 0,
        Integration = 1,
        IntegrationAndNoPut = 2,
        NoPut = 3,
        LimitOver = 4,
    };
}
namespace app::WaveNotifyTimerUIDesc {
    enum Meridiem {
        AM = 0,
        PM = 1,
    };
}
namespace app::GameManager {
    enum MegusuriType {
        Item = 0,
        Drawer = 1,
        Destruct = 2,
        EasterEgg = 3,
        CountAll = 4,
    };
}
namespace via::detail_bitset {
    enum BIT_IMPL {
        BIT_IMPL_32 = 0,
        BIT_IMPL_64 = 1,
        BIT_IMPL_ARRAY = 2,
    };
}
namespace via::render {
    enum PrimitiveError {
        NoError = 0,
        InsufficientMemory = 1,
        InvalidState = 2,
        InsufficientTexture = 3,
        InvalidOperation = 4,
    };
}
namespace app::Em3000::Action::TurnForWander {
    enum Type {
        Right = 0,
        Left = 1,
        BranchR = 2,
        BranchL = 3,
    };
}
namespace via::wwise::WwiseIdNameInfo {
    enum LanguageType {
        None = 0,
        Japanese = 1,
        English_US = 2,
        French_France = 3,
        Italian = 4,
        German = 5,
        Spanish_Spain = 6,
        Chinese_PRC = 7,
        Russian = 8,
        Portuguese_Brazil = 9,
        Fiction = 10,
        LatinAmericanSpanish = 11,
    };
}
namespace System::Reflection {
    enum MethodImplAttributes {
        CodeTypeMask = 3,
        IL = 0,
        Native = 1,
        OPTIL = 2,
        Runtime = 3,
        ManagedMask = 4,
        Unmanaged = 4,
        Managed = 0,
        ForwardRef = 16,
        PreserveSig = 128,
        InternalCall = 4096,
        Synchronized = 32,
        NoInlining = 8,
        AggressiveInlining = 256,
        NoOptimization = 64,
        MaxMethodImplVal = 65535,
    };
}
namespace app::BirthdaySelect {
    enum RankingStateEnum {
        None = 0,
        Init = 1,
        InitWait = 2,
        Start = 3,
        StartWait = 4,
    };
}
namespace via::behaviortree::SelectorCallerArg {
    enum EventType {
        None = 0,
        EveryFrame = 1,
        ChildEnd = 2,
    };
}
namespace via {
    enum ProjectionType {
        PerspectiveFovRH = 0,
        OrthographicRH = 1,
        Max = 2,
    };
}
namespace via::hid::hmd::Morpheus {
    enum VrModeStatus {
        Unavailable = 0,
        Available = 1,
        Initializing = 2,
        Running = 3,
        Finished = 4,
    };
}
namespace app::Em3600::Action::FourLegRevEnd {
    enum Type {
        Front = 0,
        Back = 1,
        Left = 2,
        Right = 3,
    };
}
namespace app::CH8Em4000::Action::CH8Move {
    enum Type {
        Normal = 0,
        Destination = 1,
        Wanderer = 2,
    };
}
namespace app::ItemSlotData {
    enum FindSlotType {
        Normal = 0,
        LowPriorityShortcut = 1,
    };
}
namespace via::storage::saveService {
    enum ErrorSimulationV2 {
        None = 0,
        UpdateSaveFileDetailFailed = 1,
    };
}
namespace app::Em8000::Em8000AroundTargetAgent {
    enum SelectType {
        CurrentPointPos = 0,
        QueryPointPos = 1,
        QueryNodePos = 2,
        BlendQueryPos = 3,
        RayCastPos = 4,
    };
}
namespace app::CH9Telemetry {
    enum UseRewardPattern {
        RingBattle = 0,
        BossBattle = 1,
        ThroughPlay = 2,
        Max = 3,
    };
}
namespace via::motion::IkMultipleDamageAction {
    enum DamageTransition {
        Non = 0,
        Impact = 1,
        Transition = 2,
        Damping = 3,
    };
}
namespace app::Cp7GameOverChoice {
    enum Choice {
        Restart = 0,
        Quit = 1,
        Max = 2,
    };
}
namespace via::physics::System {
    enum DirtyType {
        RequestSetColliders = 0,
        Max = 1,
    };
}
namespace app::CH9Em7700::Action {
    enum ActionNo {
        BiteTry = 4,
        NearBiteTry = 5,
        Strike = 6,
        StrikeUpper = 7,
        StrikeToGuard = 8,
        StrikeDuctPursuit = 9,
        SlashTry = 10,
        BiteCrawl = 11,
        DamageToStrike = 12,
        DamageToMove = 13,
        Thrust = 14,
        Mouth = 15,
        Grapple = 16,
        Appear = 17,
        LostParts = 18,
        BlownAway = 19,
        ChanceCounter = 20,
        SlipFire = 21,
        SlipAcid = 22,
        ExtraWait = 23,
        Dodge = 24,
        Notice = 25,
        Mimicry = 26,
        Falling = 27,
        Threat = 28,
        Warp = 29,
        Suspend = 30,
        Resume = 31,
        FinishBlow = 32,
        FinishStun = 33,
        WanderIdle = 34,
        Wander = 35,
        KnuckleDamage = 36,
        KnuckleCounter = 37,
        KnuckleDodge = 38,
    };
}
namespace via::render::layer::Transparent {
    enum UITargetType {
        Default = 0,
        Max = 1,
    };
}
namespace via::motion::IkLegSpine {
    enum LegSolverMode {
        LegSolverMode_2Bone = 0,
        LegSolverMode_3Bone = 1,
        LegSolverMode_3BoneV2 = 2,
        LegSolverMode_UShape = 3,
        LegSolverMode_None = 16,
    };
}
namespace app::Collision::PressUserData {
    enum Attribute {
        SkipPressX = 0,
        SkipPressY = 1,
        SkipPressZ = 2,
        SkipGlobal = 3,
        ___b04 = 4,
        EmPass = 5,
        ___b06 = 6,
        ___b07 = 7,
    };
}
namespace via::render::ToneMapping {
    enum AutoExposure {
        Enable = 0,
        FixedEnable = 1,
        Disable = 2,
    };
}
namespace app::Em4000::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Release = 2,
        Mimicry = 3,
        ExtraWait = 4,
        Destination = 5,
        Discovery = 6,
        UnDiscovery = 7,
        ClosedRoute = 8,
        IdleLostTarget = 9,
        Idle = 10,
        Follow = 11,
        Grapple = 12,
        SlashTry = 13,
        MiddleBiteTry = 14,
        NearBiteTry = 15,
        BiteCrawl = 16,
        StrikeUpper = 17,
        Strike = 18,
        StrikeCrawl = 19,
        Mouth = 20,
        SlashPursuit = 21,
        Dodge = 22,
        Door = 23,
        DoorOpen = 24,
        DoorOpen2 = 25,
        DoorClose = 26,
        DoorClose2 = 27,
        Move = 28,
        AppearAction = 29,
        IdleAction = 30,
        NoticeAction = 31,
        StrikeUpperAction = 32,
        StrikeAction = 33,
        StrikeCrawlAction = 34,
        SlashPursuitAction = 35,
        SlashTryAction = 36,
        MouthAction = 37,
        BiteCrawlAction = 38,
        NearBiteTryAction = 39,
        MiddleBiteTryAction = 40,
        ExtraBiteTryAction = 41,
        DodgeAction = 42,
        GrappleAction = 43,
        MimicryIdle = 44,
        MimicryRelease = 45,
        ExtraBiteTry = 46,
    };
}
namespace via::storage::ProprietaryDLC {
    enum DownloadStatus {
        InvalidToken = 0,
        Queued = 1,
        Downloading = 2,
        DownloadSucceeded = 3,
        DownloadFailed = 4,
    };
}
namespace app::CH8Em4100ActionController {
    enum WallAttackQueType {
        LeftWall = 0,
        RightWall = 1,
        Ceil = 2,
        Back = 3,
    };
}
namespace app::Em5520Order::Appear {
    enum Type {
        None = 0,
        Born = 1,
        Gather = 2,
        Call = 3,
    };
}
namespace via::landscape {
    enum IndexSetStrategy {
        Default = 0,
        IndexSetStragety_SeparateAndIncrementOnly = 1,
    };
}
namespace CH8Em4100Effect {
    enum CH8IDAlias {
        LostHead = 0,
    };
}
namespace via::fsm::StateGraph {
    enum StateAttribute {
        StateAttributeBitNum = 32,
    };
}
namespace via::landscape::beta {
    enum ShaderTypeEnum {
        Auto = 0,
        Near = 1,
        Far = 2,
        Max = 3,
    };
}
namespace via::motion::DevelopRetarget {
    enum Mode {
        None = 0,
        Child = 1,
        Constraint = 2,
    };
}
namespace app::GameOverScreen {
    enum Step {
        Main = 0,
        Restart = 1,
        Quit = 2,
        ItemBox = 3,
        AutoRestart = 4,
        AutoQuit = 5,
        Cp7Result = 6,
        Ch9Main = 7,
    };
}
namespace via::motion {
    enum JointType {
        Root = 0,
        Hips = 1,
        Spine = 2,
        Spine1 = 3,
        Spine2 = 4,
        Spine3 = 5,
        Neck0 = 6,
        Neck1 = 7,
        Neck2 = 8,
        Neck3 = 9,
        Head = 10,
        LeftEye = 11,
        RightEye = 12,
        LeftCollar = 13,
        LeftUpperArm = 14,
        LeftRightArm = 15,
        LeftHand = 16,
        RightCollar = 17,
        RightUpperArm = 18,
        RightRightArm = 19,
        RightHand = 20,
        LeftUpperLeg = 21,
        LeftLowerLeg = 22,
        LeftFoot = 23,
        LeftToe = 24,
        RightUpperLeg = 25,
        RightLowerLeg = 26,
        RightFoot = 27,
        RightToe = 28,
        LeftThumb0 = 29,
        LeftThumb1 = 30,
        LeftThumb2 = 31,
        LeftIndex0 = 32,
        LeftIndex1 = 33,
        LeftIndex2 = 34,
        LeftMiddle0 = 35,
        LeftMiddle1 = 36,
        LeftMiddle2 = 37,
        LeftRing0 = 38,
        LeftRing1 = 39,
        LeftRing2 = 40,
        LeftLittle0 = 41,
        LeftLittle1 = 42,
        LeftLittle2 = 43,
        RightThumb0 = 44,
        RightThumb1 = 45,
        RightThumb2 = 46,
        RightIndex0 = 47,
        RightIndex1 = 48,
        RightIndex2 = 49,
        RightMiddle0 = 50,
        RightMiddle1 = 51,
        RightMiddle2 = 52,
        RightRing0 = 53,
        RightRing1 = 54,
        RightRing2 = 55,
        RightLittle0 = 56,
        RightLittle1 = 57,
        RightLittle2 = 58,
        Count = 59,
    };
}
namespace app::Em8001::Damage {
    enum Tag {
        NoDamage = 0,
        Small_Head_F = 1,
        Small_Head_B = 2,
        Small_Head_L = 3,
        Small_Head_R = 4,
        Small_Chest_FL = 5,
        Small_Chest_FR = 6,
        Small_Chest_BL = 7,
        Small_Chest_BR = 8,
        Small_Chest_L = 9,
        Small_Chest_R = 10,
        Small_Stomach_F = 11,
        Small_Stomach_B = 12,
        Small_Stomach_L = 13,
        Small_Stomach_R = 14,
        Small_LeftArm_F = 15,
        Small_LeftArm_B = 16,
        Small_LeftArm_L = 17,
        Small_LeftArm_R = 18,
        Small_RightArm_F = 19,
        Small_RightArm_B = 20,
        Small_RightArm_L = 21,
        Small_RightArm_R = 22,
        Small_LeftLeg_F = 23,
        Small_LeftLeg_B = 24,
        Small_LeftLeg_L = 25,
        Small_LeftLeg_R = 26,
        Small_RightLeg_F = 27,
        Small_RightLeg_B = 28,
        Small_RightLeg_L = 29,
        Small_RightLeg_R = 30,
        Small_KneeBreak_F = 31,
        Small_KneeBreak_B = 32,
        Small_KneeBreak_L = 33,
        Small_KneeBreak_R = 34,
        Mid_Head_F = 35,
        Mid_Head_B = 36,
        Mid_Head_L = 37,
        Mid_Head_R = 38,
        Mid_Body_F = 39,
        Mid_Body_B = 40,
        Mid_Body_L = 41,
        Mid_Body_R = 42,
        Mid_Leg_L = 43,
        Mid_Leg_R = 44,
        Large_F = 45,
        Large_B = 46,
        Large_L = 47,
        Large_R = 48,
        Large_Small = 49,
        Down = 50,
    };
}
namespace app::Em3001 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em8001::Em8001ActionController::ProgramableTurnProcess {
    enum RatioUpdateType {
        Time = 0,
    };
}
namespace app::AI::AINavigationHelper {
    enum StateType {
        None = 0,
        Stopping = 1,
        End = 2,
    };
}
namespace via::network::Matchmaking {
    enum Phase {
        None = 0,
        Init = 1,
        CreateSession = 2,
        CreateSessionWait = 3,
        SetSearchRule = 4,
        Search = 5,
        SearchReady = 6,
        SearchWait = 7,
        SearchResult = 8,
        SearchInterval = 9,
        GiveupSession = 10,
        RebootSession = 11,
        JoinSession = 12,
        JoinSessionWait = 13,
        Permission = 14,
        PermissionWait = 15,
        Idle = 16,
        Modify = 17,
        Modify2 = 18,
        Suspend = 19,
        Resume = 20,
        Timeout = 21,
        TimeoutWait = 22,
        Restart = 23,
        Release = 24,
        Stop = 25,
    };
}
namespace via::os::http_client {
    enum Security {
        IgnoreUnknownCA = 1,
        IgnoreCertCnInvalid = 2,
        IgnoreCertDateInvalid = 4,
        IgnoreCertWrongUsage = 8,
        AllowRejectedCert = 16,
        IgnoreValidationCache = 32,
    };
}
namespace app::AI {
    enum AttackPermitReturnReason {
        Hitted = 0,
        NotHitted = 1,
        Canceled = 2,
        Damaged = 3,
        Died = 4,
    };
}
namespace app::CH8Em4450::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::render::SSAOControl {
    enum SampleQuality {
        Low = 0,
        Standard = 1,
        High = 2,
    };
}
namespace via {
    enum bitset_assign_option {
        bits = 0,
        pos = 1,
    };
}
namespace via::gui::Capture {
    enum CaptureRequest {
        None = 0,
        Clear = 1,
        Capture = 2,
    };
}
namespace app::GenomeCodexGUI {
    enum RadarCautionStateDef {
        None = 0,
        Near = 1,
        Reached = 2,
    };
}
namespace via::hid {
    enum AccountPickerState {
        Null = 0,
        Idle = 1,
        Executing = 2,
        PostProc = 3,
    };
}
namespace via::motion::IkBodyRig {
    enum JointTypes {
        Head = 0,
        Neck = 1,
        RightClavicle = 2,
        LeftClavicle = 3,
        EndSpine = 4,
        BaseSpine = 5,
        Hips = 6,
        RightHumerus = 7,
        RightRadius = 8,
        RightWrist = 9,
        LeftHumerus = 10,
        LeftRadius = 11,
        LeftWrist = 12,
        RightFemur = 13,
        RightTibia = 14,
        RightAnkle = 15,
        LeftFemur = 16,
        LeftTibia = 17,
        LeftAnkle = 18,
        MAX = 19,
    };
}
namespace app::SkillProperties {
    enum SkillType {
        RecoveryRateUp = 0,
        HealthMaxUp = 1,
        ReloadSpeedUp = 2,
        MoveSpeedUp = 3,
    };
}
namespace app::TitleSubMenu {
    enum Step {
        Main = 0,
        Continue = 1,
        Load = 2,
        NewGame = 3,
        Option = 4,
        ExtraGame = 5,
        SpFeature = 6,
        UserSwitch = 7,
        Quit = 8,
        FileError = 9,
        UserSwitchStart = 10,
        UserSwitchChangeEnd = 11,
        ContinueBefore = 12,
        LoadBefore = 13,
    };
}
namespace app::vr::VrCameraQualitySetting {
    enum ImageQuality {
        None = 0,
        Default = 1,
        DotByDot = 2,
    };
}
namespace via::CoreEntry {
    enum VrDeviceRequirement {
        No = 0,
        Maybe = 1,
        Require = 2,
    };
}
namespace app::NightmareFrameOutController {
    enum Type {
        CraftBenchA = 0,
        CraftBenchB = 1,
        Crusher = 2,
        Max = 3,
        None = 4,
    };
}
namespace via::houdini {
    enum HoudiniPipelineState {
        ShapeDefault = 0,
        ShapeWire = 1,
        ShapeShadow = 2,
        ShapePick = 3,
        ShapePBR = 4,
        Max = 5,
    };
}
namespace via::motion::tree::BaseGamePadStickNode {
    enum StickKind {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em8001::Action::DamageDown {
    enum Type {
        INVALID = -1,
        DownF = 0,
        DownB = 1,
        DownL = 2,
        DownR = 3,
        DownSmall = 4,
        SUM = 5,
    };
}
namespace app::VFXLoadZone {
    enum Status {
        None = 0,
        ActiveTrigger = 1,
        Active = 2,
        InactiveTrigger = 3,
        Inactive = 4,
    };
}
namespace Em5552Effect {
    enum IDAlias {
        BugWait_00 = 0,
        BugWait_01 = 1,
        BugWait_02 = 2,
        BugWait_03 = 3,
        BugWait_04 = 4,
        BugWait_05 = 5,
        BugWait_06 = 6,
        BugWait_07 = 7,
        BugWait_08 = 8,
        BugWait_09 = 9,
    };
}
namespace via::render {
    enum ValidFlag {
        None = 0,
        Color = 1,
        Alpha = 2,
        BaseAlpha = 3,
        Normal = 4,
        Roughness = 8,
        NormalRoughness = 12,
        Emissive = 16,
        All = 31,
    };
}
namespace via::landscape {
    enum PixelFormat {
        Unknown = 0,
        R16Unorm = 1,
        R16G16Unorm = 2,
        R8G8B8A8Unorm = 3,
    };
}
namespace app::AI::GoalArbitrator {
    enum State {
        InActive = 0,
        Active = 1,
        Suspend = 2,
        Quit = 3,
    };
}
namespace app::WwiseContainerApp {
    enum Level {
        Lv0 = 0,
        Lv1 = 1,
        Lv2 = 2,
        Lv3 = 3,
        Lv4 = 4,
        Lv5 = 5,
    };
}
namespace app::vr::VrScreenFilter {
    enum FilterType {
        Vertical = 0,
        Horizon = 1,
        Overall = 2,
    };
}
namespace via {
    enum SystemServiceCaps {
        None = 0,
        Language = 1,
        DateFormat = 2,
        TimeFormat = 4,
        TimeZoneOffset = 8,
        SummerTime = 16,
        SystemUiOverlay = 32,
        BackgroundExecution = 64,
        ApplicationSuspend = 128,
        ApplicationResume = 256,
        GetDisplaySafeAreaRatio = 512,
        SplashScreenControl = 1024,
        ScreenSaverControl = 2048,
        ApplicationParameter = 4096,
        SkuFlag = 8192,
        ResetVrPosition = 16384,
        OpenShareMenu = 32768,
        VideoRecorder = 65536,
        ApplicationActivate = 131072,
        ApplicationDeactivate = 262144,
        Country = 524288,
        AccountPicker = 1048576,
        Geography = 4194304,
        SetScreenBrightness = 8388608,
        GetApplicationVersion = 8388608,
        ApplicationExitRequestControl = 16777216,
        NoticeScreenShownControl = 33554432,
        InputIdleSectionControl = 67108864,
        DyingMessage = 134217728,
    };
}
namespace app::CardGameManager {
    enum HandItemRemoveRequestType {
        RemoveAll = -1,
        RemoveHalf = -2,
    };
}
namespace app::Em4200::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromFrontWithDirective = 8,
        IsTargetDamage = 9,
        IsOccluded = 10,
        IsTargetOnLadder = 11,
        CanBreathOcclude = 12,
        IsStandOnSlope = 13,
        AdditiveSensedAttack = 14,
    };
}
namespace app::Em3101 {
    enum ThinkOrder {
        None = 0,
        Targetting = 1,
    };
}
namespace via {
    enum SystemServiceNgWordsDetectingResult {
        OK = 0,
        NG = 1,
        Error = 2,
    };
}
namespace via::render::RenderConfig {
    enum Quality {
        LOWEST = 0,
        LOW = 1,
        STANDARD = 2,
        HIGH = 3,
        HIGHEST = 4,
        NONE = 5,
    };
}
namespace via::hid::VrTrackerResultData {
    enum Validation {
        Active = 0,
        Inactive = 1,
        Unknown = 2,
    };
}
namespace via::clr {
    enum FieldFlag {
        FieldAccessMask = 7,
        PrivateScope = 0,
        Private = 1,
        FamANDAssem = 2,
        Assembly = 3,
        Family = 4,
        FamORAssem = 5,
        Public = 6,
        Static = 16,
        InitOnly = 32,
        Literal = 64,
        NotSerialized = 128,
        HasFieldRVA = 256,
        SpecialName = 512,
        RTSpecialName = 1024,
        Pointer = 2048,
        HasFieldMarshal = 4096,
        PInvokeImpl = 8192,
        ExposeMember = 16384,
        HasDefault = 32768,
        ReservedMask = 38144,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraStartResult {
        OK = 1,
        Started = 1,
        ErrorConfigType = 2147483649,
        ErrorInternal = 2147487744,
    };
}
namespace app::fsm::CH8ElevatorCheck {
    enum CheckType {
        UseFloor = 0,
        CurrentFloor = 1,
        SecurityLock = 2,
        IsMove = 3,
    };
}
namespace via::motion::TransitionData {
    enum EndType {
        None = 0,
        EndOfMotion = 1,
        ExitFrame = 2,
        ExitFrameFromEnd = 3,
    };
}
namespace app::BirthdayGameData {
    enum StageIDEnum {
        Stage1_A = 0,
        Stage1_B = 1,
        Stage2_A = 2,
        Stage2_B = 3,
        Stage3_A = 4,
        Stage3_B = 5,
        MAX = 6,
    };
}
namespace via::physics {
    enum TriangleVoronoiId {
        Internal = 0,
        Edge01 = 1,
        Edge20 = 2,
        V0 = 3,
        Edge12 = 4,
        V1 = 5,
        V2 = 6,
        Max = 7,
    };
}
namespace via::render {
    enum ParticleLightingResolution {
        Best = 0,
        High = 1,
        Medium = 2,
        Low = 3,
        None = 4,
    };
}
namespace app::Em8900 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::CH8Em4450::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::Em8001::Action::DamageDown {
    enum State {
        None = 0,
        Start = 1,
        Loop = 2,
        Damage = 3,
        End = 4,
        CancelEnd = 5,
        INVALID = 6,
    };
}
namespace via::navigation::NavigationSurface {
    enum PortalOffsetDirectionType {
        InOut = 0,
        LeftRight = 1,
    };
}
namespace app::CraftSkillData {
    enum Type {
        WeaponCustomize = 0,
        PlayerSkill = 1,
        CrusherCustomize = 2,
        None = 3,
    };
}
namespace via::motion::MotionBindFook {
    enum DirtyFlags {
        None = 0,
        Motion = 1,
        MotionId = 2,
        BankId = 4,
        MaskId = 8,
        Frame = 16,
        RootPlayMode = 32,
        BlendMode = 64,
        Speed = 128,
        Mirror = 256,
        PlayState = 512,
        WrapMode = 1024,
    };
}
namespace via::audiorender {
    enum Channel_74ch {
        L = 0,
        R = 1,
        C = 2,
        Lrs = 3,
        Rrs = 4,
        Ls = 5,
        Rs = 6,
        Ltf = 7,
        Rtf = 8,
        Ltr = 9,
        Rtr = 10,
        Max = 11,
    };
}
namespace via::hid {
    enum GamePadExtraButton {
        None = 0,
        TrigTopInHorizontalMode = 1,
        TrigBottomInHorizontalMode = 2,
        Max = 3,
    };
}
namespace via::Triangle {
    enum NGLevel {
        None = 0,
        EdgeShort = 1,
        LS = 2,
        Point = 3,
        EdgeLong = 4,
        CantCalcGID = 5,
        NonFinite = 6,
        Assert = 7,
        Default = 0,
    };
}
namespace app::CutinMenu {
    enum Category {
        Normal = 0,
        NormalHigh = 1,
        VR = 2,
        VR_Tutorial = 3,
        System = 4,
        NetworkError = 5,
        SaveDataError = 6,
        AccountError = 7,
    };
}
namespace app::Em5540::Action {
    enum ActionNo {
        Idle = 0,
        Attack = 1,
        Damage = 2,
        Dead = 3,
    };
}
namespace via::network::error {
    enum MethodAchievements {
        Update = 0,
        Write = 1,
        Read = 2,
        Unlock = 3,
        GetInfo = 4,
    };
}
namespace app::CH9ShellManager {
    enum ForceSleepType {
        ActiveAll = 0,
        OnBrokenFloorOnly = 1,
    };
}
namespace app::AAASceneTransitionController {
    enum TargetTypeEnum {
        AmbassadorTrial = 0,
        FF030_Ex = 1,
        AmbassadorTrial_TU = 2,
        Max = 3,
    };
}
namespace via::wwise::WwiseListener {
    enum ListenerIndex {
        ListenerIndex_0 = 0,
        ListenerIndex_1 = 1,
        ListenerIndex_2 = 2,
        ListenerIndex_3 = 3,
        ListenerIndex_4 = 4,
        ListenerIndex_5 = 5,
        ListenerIndex_6 = 6,
        ListenerIndex_7 = 7,
    };
}
namespace via::hid::VrTrackerResultData {
    enum Status {
        NotStarted = 0,
        Tracking = 1,
        NotTracking = 2,
        Calibrating = 3,
        ErrorGetResultDataFailed = -1,
    };
}
namespace app::CH9Em7700::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::render::Stamp {
    enum StampBlendMethod {
        Opaque = 0,
        Add = 1,
        AddBlend = 2,
        AlphaBlend = 3,
        SubBlend = 4,
        Maximum = 5,
        AddWithNormalBlend = 33,
    };
}
namespace app::PlayerCamera {
    enum ShipShakeType {
        None = 0,
        Small = 1,
        Large = 2,
    };
}
namespace app::Em5400 {
    enum ThinkState {
        None = 0,
        BugHole = 1,
        NoLostPlayer = 2,
        NoSearch = 3,
        UseGrapple = 4,
    };
}
namespace app::OptionMenu {
    enum DamageEffectType {
        Normal = 0,
        Less = 1,
    };
}
namespace via::motion::FullBodyIKRig {
    enum SetupLevel {
        None = 0,
        Normal = 1,
        Resource = 2,
    };
}
namespace System::Reflection {
    enum GenericParameterAttributes {
        None = 0,
        VarianceMask = 3,
        Covariant = 1,
        Contravariant = 2,
        SpecialConstraintMask = 28,
        ReferenceTypeConstraint = 4,
        NotNullableValueTypeConstraint = 8,
        DefaultConstructorConstraint = 16,
    };
}
namespace via::os {
    enum FileAttr {
        Read = 0,
        Write = 1,
        ReadWrite = 2,
    };
}
namespace app::CH9MoldedActionController::ExtraHatUnit {
    enum Type {
        PartyHat = 0,
        Cap01 = 1,
        Cap02 = 2,
        Cap03 = 3,
        Hat01 = 4,
        Hat02 = 5,
        Met01 = 6,
        Met02 = 7,
        NoUse = 32767,
    };
}
namespace via::network::native::NswPresence {
    enum Status {
        Offline = 0,
        Online = 1,
        NotActivated = 2,
    };
}
namespace via::physics::System {
    enum SearchCondition {
        Search_Equal = 0,
        Search_And = 1,
        Search_Or = 2,
    };
}
namespace app::AI::AIGrappleBeacon {
    enum StatusType {
        InActive = 0,
        Active = 1,
        Terminate = 2,
    };
}
namespace app::CardGameMaster {
    enum Result {
        None = 0,
        Win = 1,
        Lose = 2,
        Draw = 3,
    };
}
namespace via::render {
    enum DeviceChangeReason {
        None = 0,
        DisplayMode = 1,
        Adapter = 2,
        DesktopResolution = 4,
        DXGIOutput = 8,
    };
}
namespace app::fsm::FsmUnlockAchievement {
    enum WrappedID {
        GetTreasureByDetailSearch = 0,
        Progress0 = 1,
        Progress1 = 2,
        Progress2 = 3,
        Progress3 = 4,
        Progress4 = 5,
        Progress5 = 6,
        GameClear = 7,
        NoCatchFromMother = 8,
        HappyBirthdayClear = 9,
    };
}
namespace app::CH8Em4200Message {
    enum Tag {
        FirstLiquidBomb = 0,
    };
}
namespace via::Triangle {
    enum VoronoiId {
        Internal = 0,
        Edge01 = 1,
        Edge20 = 2,
        V0 = 3,
        Edge12 = 4,
        V1 = 5,
        V2 = 6,
        Max = 7,
    };
}
namespace app::Em3001::Action::AttackBack {
    enum Type {
        SwingB = 0,
        PunchB = 1,
    };
}
namespace app::Em8100::Action::SplashAttack {
    enum Type {
        Normal = 0,
        Grab = 1,
    };
}
namespace rapidxml {
    enum node_type {
        node_document = 0,
        node_element = 1,
        node_data = 2,
        node_cdata = 3,
        node_comment = 4,
        node_declaration = 5,
        node_doctype = 6,
        node_pi = 7,
    };
}
namespace app::CH9Em7500::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
    };
}
namespace via::effect::lensflare {
    enum ResourceType {
        Handle = 0,
        Stream = 1,
    };
}
namespace app::fsm::Sm0113Phone_Exclusive {
    enum StepEnum {
        CK_Length_Sep = 0,
        CK_Length_Con = 1,
        CK_Time = 2,
    };
}
namespace via::render::streaming_detail {
    enum StreamingOption {
        Protect = 1,
    };
}
namespace via::motion::IkLegSpine {
    enum RayCastCallbackID {
        PartsMask = 255,
        BackLeft = 1,
        BackRight = 2,
        ForeLeft = 4,
        ForeRight = 8,
        Head = 16,
        Chest = 32,
        Hip = 64,
        Tail = 128,
        Detail = 256,
        BackLeftDetail = 257,
        BackRightDetail = 258,
        ForeLeftDetail = 260,
        ForeRightDetail = 264,
        Base = 512,
        BackLeftBase = 513,
        BackRightBase = 514,
        ForeLeftBase = 516,
        ForeRightBase = 520,
        HeadBase = 513,
        ChestBase = 514,
        HipBase = 516,
        TailBase = 520,
        SpineV = 1024,
        SpineH = 2048,
        HeadSpineV = 1040,
        ChestSpineV = 1040,
        HipSpineV = 1040,
        TailSpineV = 1040,
        HipToHead = 2064,
        HipToTail = 2176,
        AdditionalOuter = 4096,
        BackLeftOuter = 4097,
        BackRightOuter = 4098,
        ForeLeftOuter = 4100,
        ForeRightOuter = 4104,
        AdditionalFootDir = 8192,
        BackLeftDir = 8193,
        BackRightDir = 8194,
        ForeLeftDir = 8196,
        ForeRightDir = 8200,
        AdditionalHip = 16384,
        AdditionalHipLeft = 16385,
        AdditionalHipRight = 16386,
        AdditionalHipBack = 16388,
        AdditionalHipFore = 16392,
        ExtraLeg = 268435456,
        ExtraSpine = 536870912,
    };
}
namespace app::fsm::CH8CheckMessageState {
    enum StateCheckType {
        None = 0,
        TimeCount = 1,
        MessageEnd = 2,
        PageStart = 3,
        PageEnd = 4,
    };
}
namespace via::effect::gpgpu::MeshCS::MeshCSResource {
    enum MeshComputeShaderType {
        InitializeCS = 0,
        ConstructCS = 1,
        ConstructDeformableCS = 2,
        InitializeDeformableCS = 3,
        SingleUpdateDeformableCS = 4,
        UpdateDeformableCS = 5,
        DefaultFirstUpdateDeformableCS = 6,
        DefaultSecondUpdateDeformableCS = 7,
        DefaultThirdUpdateDeformableCS = 8,
        DefaultFourthUpdateDeformableCS = 9,
        SingleUpdateDeformableVolumeFieldCS = 10,
        UpdateDeformableVolumeFieldCS = 11,
        DefaultFirstUpdateDeformableVolumeFieldCS = 12,
        DefaultSecondUpdateDeformableVolumeFieldCS = 13,
        DefaultThirdUpdateDeformableVolumeFieldCS = 14,
        DefaultFourthUpdateDeformableVolumeFieldCS = 15,
        SingleUpdateDeformableSimpleVolumeFieldCS = 16,
        UpdateDeformableSimpleVolumeFieldCS = 17,
        DefaultFirstUpdateDeformableSimpleVolumeFieldCS = 18,
        DefaultSecondUpdateDeformableSimpleVolumeFieldCS = 19,
        DefaultThirdUpdateDeformableSimpleVolumeFieldCS = 20,
        DefaultFourthUpdateDeformableSimpleVolumeFieldCS = 21,
        SingleUpdateDeformableMeshContourCS = 22,
        UpdateDeformableMeshContourCS = 23,
        DefaultFirstUpdateDeformableMeshContourCS = 24,
        DefaultSecondUpdateDeformableMeshContourCS = 25,
        DefaultThirdUpdateDeformableMeshContourCS = 26,
        DefaultFourthUpdateDeformableMeshContourCS = 27,
        SingleUpdateDeformableMeshContourDirectionalFieldCS = 28,
        UpdateDeformableMeshContourDirectionalFieldCS = 29,
        DefaultFirstUpdateDeformableMeshContourDirectionalFieldCS = 30,
        DefaultSecondUpdateDeformableMeshContourDirectionalFieldCS = 31,
        DefaultThirdUpdateDeformableMeshContourDirectionalFieldCS = 32,
        DefaultFourthUpdateDeformableMeshContourDirectionalFieldCS = 33,
        SingleUpdateDeformableMeshContourMaskDirectionalFieldCS = 34,
        UpdateDeformableMeshContourMaskDirectionalFieldCS = 35,
        DefaultFirstUpdateDeformableMeshContourMaskDirectionalFieldCS = 36,
        DefaultSecondUpdateDeformableMeshContourMaskDirectionalFieldCS = 37,
        DefaultThirdUpdateDeformableMeshContourMaskDirectionalFieldCS = 38,
        DefaultFourthUpdateDeformableMeshContourMaskDirectionalFieldCS = 39,
        SingleUpdateDeformableMeshContourVolumeFieldCS = 40,
        UpdateDeformableMeshContourVolumeFieldCS = 41,
        DefaultFirstUpdateDeformableMeshContourVolumeFieldCS = 42,
        DefaultSecondUpdateDeformableMeshContourVolumeFieldCS = 43,
        DefaultThirdUpdateDeformableMeshContourVolumeFieldCS = 44,
        DefaultFourthUpdateDeformableMeshContourVolumeFieldCS = 45,
        SingleUpdateDeformableMeshContourSimpleVolumeFieldCS = 46,
        UpdateDeformableMeshContourSimpleVolumeFieldCS = 47,
        DefaultFirstUpdateDeformableMeshContourSimpleVolumeFieldCS = 48,
        DefaultSecondUpdateDeformableMeshContourSimpleVolumeFieldCS = 49,
        DefaultThirdUpdateDeformableMeshContourSimpleVolumeFieldCS = 50,
        DefaultFourthUpdateDeformableMeshContourSimpleVolumeFieldCS = 51,
        SingleUpdateDeformableVectorFieldCS = 52,
        UpdateDeformableVectorFieldCS = 53,
        DefaultFirstUpdateDeformableVectorFieldCS = 54,
        DefaultSecondUpdateDeformableVectorFieldCS = 55,
        DefaultThirdUpdateDeformableVectorFieldCS = 56,
        DefaultFourthUpdateDeformableVectorFieldCS = 57,
        SingleUpdateDeformableSimpleVectorFieldCS = 58,
        UpdateDeformableSimpleVectorFieldCS = 59,
        DefaultFirstUpdateDeformableSimpleVectorFieldCS = 60,
        DefaultSecondUpdateDeformableSimpleVectorFieldCS = 61,
        DefaultThirdUpdateDeformableSimpleVectorFieldCS = 62,
        DefaultFourthUpdateDeformableSimpleVectorFieldCS = 63,
        SingleUpdateDeformableMeshContourVectorFieldCS = 64,
        UpdateDeformableMeshContourVectorFieldCS = 65,
        DefaultFirstUpdateDeformableMeshContourVectorFieldCS = 66,
        DefaultSecondUpdateDeformableMeshContourVectorFieldCS = 67,
        DefaultThirdUpdateDeformableMeshContourVectorFieldCS = 68,
        DefaultFourthUpdateDeformableMeshContourVectorFieldCS = 69,
        SingleUpdateDeformableMeshContourSimpleVectorFieldCS = 70,
        UpdateDeformableMeshContourSimpleVectorFieldCS = 71,
        DefaultFirstUpdateDeformableMeshContourSimpleVectorFieldCS = 72,
        DefaultSecondUpdateDeformableMeshContourSimpleVectorFieldCS = 73,
        DefaultThirdUpdateDeformableMeshContourSimpleVectorFieldCS = 74,
        DefaultFourthUpdateDeformableMeshContourSimpleVectorFieldCS = 75,
        SingleUpdateDeformableVectorFieldCSWithSmoothing = 76,
        UpdateDeformableVectorFieldCSWithSmoothing = 77,
        DefaultFirstUpdateDeformableVectorFieldCSWithSmoothing = 78,
        DefaultSecondUpdateDeformableVectorFieldCSWithSmoothing = 79,
        DefaultThirdUpdateDeformableVectorFieldCSWithSmoothing = 80,
        DefaultFourthUpdateDeformableVectorFieldCSWithSmoothing = 81,
        SingleUpdateDeformableSimpleVectorFieldCSWithSmoothing = 82,
        UpdateDeformableSimpleVectorFieldCSWithSmoothing = 83,
        DefaultFirstUpdateDeformableSimpleVectorFieldCSWithSmoothing = 84,
        DefaultSecondUpdateDeformableSimpleVectorFieldCSWithSmoothing = 85,
        DefaultThirdUpdateDeformableSimpleVectorFieldCSWithSmoothing = 86,
        DefaultFourthUpdateDeformableSimpleVectorFieldCSWithSmoothing = 87,
        SingleUpdateDeformableMeshContourVectorFieldCSWithSmoothing = 88,
        UpdateDeformableMeshContourVectorFieldCSWithSmoothing = 89,
        DefaultFirstUpdateDeformableMeshContourVectorFieldCSWithSmoothing = 90,
        DefaultSecondUpdateDeformableMeshContourVectorFieldCSWithSmoothing = 91,
        DefaultThirdUpdateDeformableMeshContourVectorFieldCSWithSmoothing = 92,
        DefaultFourthUpdateDeformableMeshContourVectorFieldCSWithSmoothing = 93,
        SingleUpdateDeformableMeshContourSimpleVectorFieldCSWithSmoothing = 94,
        UpdateDeformableMeshContourSimpleVectorFieldCSWithSmoothing = 95,
        DefaultFirstUpdateDeformableMeshContourSimpleVectorFieldCSWithSmoothing = 96,
        DefaultSecondUpdateDeformableMeshContourSimpleVectorFieldCSWithSmoothing = 97,
        DefaultThirdUpdateDeformableMeshContourSimpleVectorFieldCSWithSmoothing = 98,
        DefaultFourthUpdateDeformableMeshContourSimpleVectorFieldCSWithSmoothing = 99,
        MaxType = 100,
    };
}
namespace app::InteractEventAction {
    enum ProcessType {
        Stop = 0,
        Setup = 1,
        Interp = 2,
        Play = 3,
    };
}
namespace app::BirthdayMainMenu {
    enum ScreenTypeEnum {
        Title = 0,
        Select = 1,
    };
}
namespace app::Em3600Think {
    enum Phase {
        Generate = 0,
        Sneak = 1,
        Angry = 2,
        Mix = 3,
        Last = 4,
    };
}
namespace app {
    enum UpdateOrder {
        Default = 0,
        MotionManager = 1,
        FsmStateTracker = 2,
        ObjectManager = 3,
        GameManager = 4,
        SaveDataManager = 5,
        SaveDataCollector = 6,
        EnemySaveLoader = 7,
        SaveBehavior = 8,
        InteractSaveBehavior = 9,
        HitBehaviorDamage = 10,
        HavokSystem = 10,
        HitSystemDamage = 11,
        HitBehaviorAttack = 12,
        HitSystemAttack = 13,
        HitBullet = 13,
        HitController = 14,
        HitDamageUser = 14,
        HavokController = 15,
        ENGINE_Sound_Reflection = -120,
        ENGINE_Sound_Behavior = -119,
        EffectSphereCollider = -1500,
        EPVExpertAuto = -1501,
        EPVExpertCharacterBlood = -1502,
        EPVExpertDestruction = -1503,
        EPVExpertExplosion = -1504,
        EPVExpertFootLanding = -1505,
        EPVExpertGunSmoke = -1506,
        EPVExpertObjectLanding = -1507,
        EPVExpertPartsDamage = -1508,
        EPVExpertWeaponLanding = -1509,
        VFXLoadZone = -1600,
        VFXCullingZone = -1601,
        VFXCullingZoneGroup = -1602,
        VFXCullingZoneHelper = -1603,
        VFXEmitZone = -1604,
        VFXEmitZoneGroup = -1605,
        MotionDelegateTagManager = 20,
        DamageControlHelper = 21,
        StrikeControl = 22,
        DamageControl = 23,
        ThinkBefore = 24,
        ParallelEvaluator = 25,
        Think = 26,
        Command = 27,
        Action = 28,
        EventActionController = 29,
        LookAtController = 30,
        OverrideActionController = 31,
        AdditionalTreeLayer = 32,
        MansionAIZone = 33,
        MansionAIPoint = 34,
        MansionAISet = 35,
        InteractManager = 36,
        FsmStateCheckManager = 37,
        PlayerCommand = 38,
        PlayerSequenceManager = 39,
        PlayerCamera = 40,
        PlayerMovement = 41,
        PlayerEventActionManager = 42,
        PlayerViewPointDOFController = 43,
        PlayerVoiceAttackTypeController = 44,
        CameraHijack = 45,
        ViewPoint = 45,
        ViewPointUser = 46,
        HandLightDirectionDelayController = 47,
        BasicAnimationController = 48,
        SmoothAnimator = 49,
        FloorDoor = 50,
        Tram = 50,
        DoorPush = 51,
        MotionManagerHelper = 52,
        RootConstHelper = 53,
        DelayCameraInterpSetup = 54,
        GameEventActionController = 55,
        GameEventController = 56,
        InteractEventAction = 56,
        DoorEventAction = 56,
        CarInGarage = 57,
        FacialMotionBankContainer = 58,
        FaceMotionReceiver = 59,
        LookAtParameterControl = 60,
        SecondaryMotionReceiver = 61,
        c03e00_02 = 62,
        TimeLineKickerContainer = 63,
        AssistLightZoneGroup = 64,
        VibrationManager = 65,
        PlayerUpperVerticalRotate = 66,
        PlayerHands = 67,
        PlayerMelee = 68,
        PlayerGun = 69,
        PlayerGunAfterJointFixed = 70,
        PlayerItem = 71,
        PlayerLArmDamage = 72,
        PlayerLighter = 73,
        PlayerWeaponChange = 74,
        PlayerGenomeCodexController = 75,
        PlayerReticleController = 76,
        PlayerMeshController = 77,
        PlayerShadow = 78,
        PlayerMotionController = 79,
        PlayerResurrection = 80,
        WeaponHandgunAppend = 81,
        WeaponHandgunAlbertAppend = 82,
        WeaponShotgunAppend = 83,
        WeaponGlassesAppend = 83,
        WeaponShotgunDBAppend = 84,
        WeaponLighterAppend = 85,
        CartridgeRequester = 86,
        BulletBase = 87,
        Cartridge = 88,
        Bomb = 89,
        Timebomb = 90,
        WeaponMotionController = 91,
        Em8000ScarController = 92,
        SystemAfter0 = 93,
        ShellManager = 94,
        PadManager = 95,
        Pad = 96,
        HIDManager = 97,
        UserServiceManager = 98,
        AIFollowPoint = 99,
        AIFollowPointManager = 100,
        EnemyPool = 101,
        EnemyGenerator = 102,
        EnemyGeneratorManager = 103,
        EnemySpawnInfo = 104,
        EnemyActionController = 105,
        AIWorldBlackBoard = 106,
        BattleRankManager = 107,
        EnemyRayCastManager = 108,
        EnemyLostPartsController = 109,
        Achievement = 110,
        RichPresence = 111,
        Telemetry = 112,
        VrSystem = 113,
        VrManager = 114,
        VrBehavior = 115,
        HmdTracking = 116,
        VrCamera = 117,
        AILookAtAgent = 118,
        AISensor = 119,
        AINavigationManager = 120,
        ChainContact = 121,
        ChainHelper = 122,
        FollowBugsGroupUpdater = 123,
        WeaponScissors = 124,
        Em8000CorpsebagManager = 125,
        Em8000Corpsebag = 126,
        Em8000CorpsebagInteract = 127,
        Em8010Core = 128,
        Em8000AroundTargetAgent = 129,
        Em8000OverrideControl = 130,
        CameraManager = 131,
        EnemyDeadbodyController = 132,
        VideoControl = 133,
        MotionPreview = 134,
        MotionPreviewManager = 135,
        EnvCompartmentSetting = 136,
        TransformCopy = 137,
        OilCan = 138,
        LucasTrapMessage = 139,
        AttackHitFsmStateSet = 140,
        EndFirstEditTransOrJoint = 10000,
        BeginSecondEditTransOrJoint = 10001,
        EndSecondEditTransOrJoint = 10002,
        EndPlayerEditTransOrJoint = 10003,
        EndEnemyEditTransOrJoint = 10004,
        EndPropsEditTransOrJoint = 10005,
        CH8GameManager = 10006,
        CH8MissionManager = 10007,
        CH8SaveManager = 10008,
        CH8VrCamera = 10009,
        CH8PlayerReticleController = 10010,
        AllEnd = 10011,
        MovementController = 200,
        SequenceController = 201,
        BreathControllerLate = 202,
        AnimationHumanoid = 203,
        AnimationLookAt = 204,
        AnimationStepForward = 204,
        AnimationFullbodyIKApp = 205,
        AnimationFullbodyIK = 206,
        AnimationHitStop = 207,
        AnimationPlayerHand = 208,
        AnimationFootLock = 209,
        ConstraintJointLate = 210,
        AreaHitObjLate = 211,
        ENGINE_UI = -128,
        UIManager = 300,
        UIBefore = 301,
        UIMain = 302,
        UIAfterPlayer = 303,
        UIPostProc = 304,
        UICommand = 305,
        E3ConstraintJointLate = 306,
        E3TieWrapLate = 307,
        E3PlayerBlendLate = 308,
        FootEffectController = 309,
        HandLightCausticsGenerator = 310,
        PushbackWeapon = 311,
        AnimationJackHandIK = 312,
        Em8000ChainsawSensorPositionUpdater = 313,
    };
}
namespace app::Richpresence {
    enum DLCProgressType {
        Bedroom = 0,
        Nightmare = 1,
        CrazyHouse = 2,
        TwentyOne = 3,
        Daughters = 4,
        Birthday = 5,
        Menu = 6,
        Unknown = 7,
        Invalid = -1,
    };
}
namespace app::IKBase {
    enum EffectorRotation {
        Default = 0,
        KeepWorldRotation = 0,
        KeepLocalRotation = 1,
        UseTargetRotation = 2,
    };
}
namespace app::Em3600::Action::Suspend {
    enum Type {
        FirePlace_1F = 0,
        Floor_1F = 1,
        SmallRoomCeiling_1F = 2,
        GHNearbyDoor_1F = 3,
        GHWindow_1F = 4,
        GHBackGround_1F = 5,
        StairWindow_1_5F = 6,
        Ceiling_2F = 7,
        FirePlace_2F = 8,
        GHRoofHole_2F = 9,
        Bridge_2F = 10,
        StairRoomCeiling_2F = 11,
        GHTopofDoor_2F = 12,
    };
}
namespace app::EnemyThinkBase {
    enum ReasonType {
        Outer = 0,
        SensedVision = 1,
        SensedHearing = 2,
        SensedFriend = 3,
        Specified = 4,
        Damaged = 5,
    };
}
namespace app::Em8000::Action::Em8000ActionStatus {
    enum Direction {
        None = 0,
        Front = 1,
        Back = 2,
        Left = 3,
        Right = 4,
    };
}
namespace via::hid {
    enum VirtualDeviceOwnerType {
        VirtualInput = 1,
        RemoteInput = 2,
    };
}
namespace app::dev1lab::AnalysisLogUtil {
    enum SupportEnvironment {
        Invalid = 0,
        PS4 = 1,
        PS5 = 2,
        XboxOne = 3,
        XBS = 4,
        Steam = 5,
    };
}
namespace via::render::FakeLensflare {
    enum ResolutionLevel {
        Full = 0,
        Half = 1,
        Quarter = 2,
    };
}
namespace via::gui {
    enum TypingCommand {
        Resume = 0,
        Pause = 1,
        End = 2,
        Restart = 3,
    };
}
namespace app::ReticleGUI {
    enum DisplayState {
        NoHold = 0,
        CasualHold = 1,
        Hold = 2,
        Firing = 3,
        TargetEnable = 4,
    };
}
namespace app::CH8StateSwitchM7 {
    enum CHP8_7 {
        SILENCE = 0,
        CHP8_RUSH_START = 1,
        CHP8_BGM_COUNTDOWN = 2,
        CHP8_BGM_SHIELDMACHINE_END = 3,
    };
}
namespace via::geometry {
    enum BrushPrimitive {
        Box = 0,
        Frustum = 1,
        Cylinder = 2,
        Cone = 3,
        Sphere = 4,
        Stairs = 5,
        Slope = 6,
        SpiralStair = 7,
        SpiralSlope = 8,
        Floor = 9,
        ImagePlane = 10,
        Mesh = 11,
    };
}
namespace via::vr {
    enum VrSdkType {
        None = 0,
        PSVR = 1,
        OpenVR = 2,
        OculusVR = 3,
    };
}
namespace via::render::detail {
    enum CsPriority {
        CSUpdate_0 = 0,
        CSUpdate_1 = 256,
        CSUpdate_2 = 512,
        CSUpdate_3 = 768,
    };
}
namespace via::audiorender {
    enum OutputDevice {
        None = 0,
        HDMI = 1,
        Speaker = 2,
        Headphone = 3,
        USBDevice = 4,
        Max = 5,
    };
}
namespace app::Em8100Order::Appear {
    enum Type {
        None = 0,
        Restart = 1,
        ForceBattleStart = 2,
    };
}
namespace app::GenomeCodexGUI {
    enum Mode {
        HP = 0,
    };
}
namespace via::os {
    enum ThreadState {
        Ready = 0,
        Executing = 1,
        Running = 2,
        Suspended = 3,
    };
}
namespace app::WaveTimerUIAsset {
    enum MainPanelState {
        DEFAULT = 0,
        FADE_OUT = 1,
    };
}
namespace via::navigation::PathObject {
    enum ObjectAttribute {
        GlobalPortalPosition = 0,
        PossibleNearEnd = 1,
        FixNodeCenter = 2,
        PassingExtraLink = 3,
        SkipThis = 4,
        DisableRecalcPortalLine = 5,
        ObjectAttributeBitNum = 32,
    };
}
namespace app::CH8Em4100::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
        Air = 2,
    };
}
namespace app::CH8SaveManager {
    enum SaveSlot {
        SaveSlotMax = -80,
        SaveSlotMin = -86,
        SystemData = -80,
        GameAutoSaveData = -81,
        GameDataMaxIndex = -81,
        GameDataMinIndex = -86,
        ManualSaveDataMax = -82,
        ManualSaveDataMin = -86,
        RetrySlot = -89,
    };
}
namespace via::eq::Function {
    enum Type {
        Sin = 0,
        Cos = 1,
        ASin = 2,
        ACos = 3,
        Floor = 4,
        Ceil = 5,
        Log = 6,
        Log10 = 7,
        Exp = 8,
        Abs = 9,
        Saturate = 10,
        SinDeg = 11,
        CosDeg = 12,
        ASinDeg = 13,
        ACosDeg = 14,
        Lerp = 15,
        Clamp = 16,
        SmoothStep = 17,
        Min = 18,
        Max = 19,
        Pow = 20,
    };
}
namespace app::fsm::CH8CheckDoorState {
    enum CheckType {
        Locked = 0,
        ManualClose = 1,
        ManualClosed = 2,
        ManualOpen = 3,
        Open = 4,
    };
}
namespace via::render {
    enum ShadowFilter {
        Custom = 0,
        Fast = 1,
        Default = 2,
    };
}
namespace via::physics {
    enum ForceFillMode {
        None = 0,
        Solid = 1,
        WireFrame = 2,
        Solid_WireFrame = 3,
    };
}
namespace via::motion::IkLeg {
    enum FootLockMode {
        Auto = 0,
        SemiAuto = 1,
    };
}
namespace via::motion::IkLegSpine {
    enum WallLimitCtrl {
        Default = 0,
        Normal = 1,
    };
}
namespace via::os {
    enum ObfuscationLevel {
        Low = 0,
        Normal = 1,
        High = 2,
        Maximum = 3,
    };
}
namespace app::CH8Em4200::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Em4500::Goal {
    enum CH8EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        PlayerFront = 4,
        OutRange = 5,
        InRange = 6,
        HeightRange = 7,
        CurrentRouteNearDoor = 8,
        IsAttackFromFrontWithDirective = 9,
        IsTargetLegCut = 10,
        IsTargetRun = 11,
        IsTargetCrouching = 12,
        IsTargetDamage = 13,
        IsSlipFire = 14,
        IsSlipAcid = 15,
        IsTargetNoStand = 16,
        AdditiveSensedAttack = 17,
        AvoidanceDesire = 18,
        PlayerStop = 19,
    };
}
namespace app::Em3001::Action {
    enum ActionNo {
        Idle = 0,
        IdleBattle = 1,
        Rest = 2,
        Appear = 3,
        Walk = 4,
        Turn = 5,
        TurnAttack = 6,
        StepIn = 7,
        Zigzag = 8,
        Branch = 9,
        TurnForWander = 10,
        Attack = 11,
        AttackBack = 12,
        AttackRush = 13,
        AttackToGrapple = 14,
        OpenDoor = 15,
        Grapple = 16,
        Damage = 17,
        Dead = 18,
    };
}
namespace app::Em5400::Action::Attack {
    enum Type {
        Stab = 0,
        RearStab = 1,
        GroundStab = 2,
        Strike = 3,
    };
}
namespace app::CH9Em7500::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        UnDiscovery = 2,
        Discovery = 3,
        Idle = 4,
        IdleLostTarget = 5,
        Dive = 6,
        Suspend = 7,
        Suicide = 8,
        Follow = 9,
        AttackPounce = 10,
        AttackTurn = 11,
        AttackTurnNoCount = 12,
        Grapple = 13,
        AppearAction = 14,
        IdleAction = 15,
        DiveAction = 16,
        UnderwaterAction = 17,
        MoveAction = 18,
        AttackPounceAction = 19,
        AttackTurnAction = 20,
        GrappleAction = 21,
        SuspendAction = 22,
    };
}
namespace via::render::CaptureToTexture {
    enum ReplayCapturedTarget {
        Default = 0,
        DepthOnly = 1,
        ColorOnly = 2,
    };
}
namespace via::landscape::GroundUtility {
    enum TextureBlendType {
        Add = 0,
        Subtract = 1,
        Multiply = 2,
    };
}
namespace app::fsm::VideoDisp {
    enum SetState {
        Play = 0,
        Stop = 1,
        Clear = 2,
    };
}
namespace app::fsm::CH8PlayerRequestCommandForce {
    enum CommandType {
        Guard = 0,
    };
}
namespace app::Em3002::Action::Attack {
    enum Type {
        PunchL = 0,
    };
}
namespace app::CH9Em7800::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::Em8100::Action {
    enum ActionNo {
        Idle = 0,
        IdleGrab = 1,
        Walk = 2,
        TurnWalk = 3,
        Turn = 4,
        Attack = 5,
        SplashAttack = 6,
        Descend = 7,
        Grab = 8,
        GrabClimb = 9,
        GrabDescend = 10,
        GrabTurn = 11,
        Damage = 12,
        Dead = 13,
    };
}
namespace app::CH8Achievement {
    enum AchievementIndex {
        Achievement_0 = 57,
        Achievement_1 = 58,
    };
}
namespace app::CraftBenchUIAsset {
    enum SlotSizeState {
        DEFAULT = 0,
        SIZE1 = 1,
        SIZE2 = 2,
        SIZE3 = 3,
    };
}
namespace app {
    enum SaveDataType {
        Optional = 0,
        Auto = 1,
    };
}
namespace app::CH9Em7700::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace via::effect::gpgpu::MeshCS::MeshTrailCSResource {
    enum MeshTrailComputeShaderType {
        MeshComputeShaderType_InitializeUV1CS = 100,
        MeshComputeShaderType_InitializeDeformableUV1CS = 101,
        MeshComputeShaderType_InitializeUV2CS = 102,
        MeshComputeShaderType_InitializeDeformableUV2CS = 103,
        ConstructTimeCS = 104,
        ConstructDeformableTimeCS = 105,
        MeshTrailUpdateMeshVertexCS = 106,
        MeshTrailUpdateMeshVertexIndexCS = 107,
        MeshTrailUpdateMeshVertexIndexUV1CS = 108,
        MeshTrailUpdateMeshVertexIndexUV2CS = 109,
        MaxType = 110,
    };
}
namespace via::gui::Effect2D {
    enum ExternType {
        Float = 0,
        Color = 1,
    };
}
namespace via::gui {
    enum ListScrollDirection {
        None = 0,
        Prev = 1,
        Next = 2,
    };
}
namespace app::EPVExpertFootLandingData {
    enum FootStepType {
        Contact = 0,
        Lift = 1,
        Step = 2,
        Slide = 3,
    };
}
namespace app::CardGameObjectElectricMachine {
    enum SeType {
        MachineDown = 0,
        MachineUp = 1,
        BetFlipStart = 2,
        RotorStart = 3,
        RotorEnd = 4,
        MeterStart = 5,
        MeterDeath = 6,
    };
}
namespace app::AdjustBrightnessGUI {
    enum ModeDef {
        BootFlow = 0,
        Normal = 1,
        HDRBootFlow2nd = 2,
    };
}
namespace app::OptionMenu {
    enum AudioItem {
        Volume = 0,
        Volume_BGM = 1,
        Volume_SE = 2,
        Volume_System = 3,
        Virtual_Surround = 4,
        Audio_Speaker_Type = 5,
        Dynamic_Range_Control = 6,
        SpatialAudio = 7,
    };
}
namespace via::render::UIColorCorrect {
    enum SourceType {
        LDRPostProcess = 0,
        UIPostProcess = 1,
    };
}
namespace via::clr {
    enum EnumI8 {
        Dummy = 0,
    };
}
namespace app::AI::AILookAtAgent {
    enum PositionType {
        CurrentAgentPos = 0,
        QueryAgentPos = 1,
        QueryNodePos = 2,
        BlendQueryPos = 3,
    };
}
namespace via::motion::FullBodyIKRig::LimbChain {
    enum EndEffectorMode {
        None = 0,
        Set = 1,
    };
}
namespace via::gui {
    enum MaskType {
        Target = 0,
        NonTarget = 1,
        Mask = 2,
        MaskTop = 3,
        MaskTopMost = 4,
    };
}
namespace Em5510Effect {
    enum IDAlias {
        BugGenerate_00 = 0,
        BugGenerate_01 = 1,
        BugGenerate_02 = 2,
        Resident = 3,
        Break_00 = 4,
        Break_01 = 5,
        Break_02 = 6,
        FireSlip_00 = 7,
        FireSlip_01 = 8,
        FireBreak = 9,
        AcidSlip_00 = 10,
        AcidSlip_01 = 11,
    };
}
namespace app::CH8Em4100::CH8ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
    };
}
namespace app::MapManager {
    enum MapWindowState {
        Disable = 0,
        MapControl = 1,
        LegendViewer = 2,
        ResetPosition = 3,
        ChangeMapLevel = 4,
    };
}
namespace app::CH8StateSwitchBtlMolded {
    enum CHP8_BTL_MOLDED {
        SILENCE = 0,
        ENCOUNT = 1,
        BATTLE = 2,
        LOST_PL = 3,
        EM4400_DEAD = 4,
    };
}
namespace app::Em3102 {
    enum ThinkMode {
        None = 0,
        Patrol = 1,
        Search = 2,
        Chase = 3,
        Sane = 4,
    };
}
namespace app::CH9Em7500::Action::Idle {
    enum Type {
        Normal = 0,
        Homing = 1,
    };
}
namespace via::navigation::map::NodeObject {
    enum NodeStatus {
        Enabled = 0,
        DivideReserved = 1,
        Dividing = 2,
        Extended = 3,
        Unload = 4,
        OnStaticBank = 5,
        CutOffRemained = 6,
        DivideReservedDelayed = 7,
        Length = 8,
    };
}
namespace via::audiorender {
    enum EffectBaseParameter {
        Bypass = 0,
    };
}
namespace app::EnemySpawnInfo {
    enum SuspendType {
        None = 0,
        Specified = 1,
        Self = 2,
        Auto = 3,
        WaitingAutoSpawn = 4,
    };
}
namespace app::Em8000FirstStamp {
    enum Routine {
        Cleanup = 0,
        Dirty = 1,
        Wait = 2,
        SetDefault = 3,
    };
}
namespace app::PlayerDefine {
    enum WeaponActionType {
        Hands = 0,
        Melee = 1,
        Gun = 2,
        Item = 3,
        LArmDamage = 4,
        Lighter = 5,
    };
}
namespace app::NowLoadingMovieManager {
    enum PlayState {
        Stop = 0,
        Standby = 1,
        Show = 2,
        Closing = 3,
    };
}
namespace app::cutin::CutinProc3Scroll {
    enum MouseDrag {
        NormalMode = 0,
        DragMode = 1,
    };
}
namespace System::Collections::Generic {
    enum NodeColor {
        Black = 0,
        Red = 1,
    };
}
namespace app::TipsVariableDefine {
    enum Tag {
        Tips_SlowMolded = 0,
        Tips_QuickMolded = 1,
        Tips_FatMolded = 2,
        Tips_LegCutJapan = 3,
        Tips_LegCutForeign = 4,
        Tips_GrappleCounter = 5,
        Tips_KnifeMia = 6,
        Tips_ChainsawMia = 7,
        Tips_ShovelJack = 8,
        Tips_GarageJack = 9,
        Tips_RollerJack = 10,
        Tips_ScissorsJack = 11,
        Tips_PursuitMarguerite = 12,
        Tips_PitFight = 13,
        Tips_MutatedMarguerite = 14,
        Tips_Passcodes = 15,
        Tips_FatMoldedBoss = 16,
        Tips_MutatedJack = 17,
        Tips_EvelineNecrotoxin = 18,
        Tips_EvelineWall = 19,
        Tips_EvelineAlbert = 20,
        Tips_PartyRoom = 21,
        Tips_ScorpionKey = 22,
        _Count = 23,
    };
}
namespace app::fsm::CH8CheckFront {
    enum TargetPontIndex {
        root = 0,
        Head = 1,
        Chest = 2,
        Stomach = 3,
    };
}
namespace app::Em3001::Action::StepIn {
    enum Type {
        Straight = 0,
        Side = 1,
        Grab = 2,
        TStraight = 3,
        TSide = 4,
        TGrab = 5,
    };
}
namespace app::LastWaveUIAsset::JunkpartsAnimationPanel {
    enum PanelState {
        DEFAULT = 0,
        DISABLE = 1,
        FADE_IN = 2,
        FADE_OUT = 3,
    };
}
namespace app::Em3600::Action::Jump {
    enum Type {
        JumpS = 0,
        JumpM = 1,
    };
}
namespace via::gui {
    enum MouseSelectType {
        None = 0,
        MouseOver = 1,
        LeftClick = 2,
    };
}
namespace app::Em3001::Action {
    enum ActionZero {
        StepBack = 0,
        GrappleHeadButt = 1,
        GrappleKnee = 2,
        GrappleThrow = 3,
        Non = 99,
    };
}
namespace app::fsm::ElevatorCheck {
    enum CheckType {
        UseFloor = 0,
        CurrentFloor = 1,
        SecurityLock = 2,
        IsMove = 3,
    };
}
namespace via {
    enum FsmCategory {
        None = 0,
        Fsm = 1,
        Mot = 2,
        Auto = 4,
        BehaviorTree = 8,
        Timeline = 16,
    };
}
namespace app::vr::VrSettingData::Camera {
    enum CameraPositionType {
        Original = 0,
        UseXZRoot = 1,
    };
}
namespace app::EPVExpertCharacterBloodData {
    enum ZDirectionType {
        CollisionNormal = 0,
        InverseCollisionNormal = 1,
        AttackDirection = 2,
        InverseAttackDirection = 3,
        SawRotation = 4,
    };
}
namespace app::AI {
    enum CommonThinkState {
        None = 0,
    };
}
namespace app::fsm::MotionPlay {
    enum AdjustStartFrameTypeEnum {
        None = 0,
        NormalizeTime = 1,
        ReverseNormalizeTime = 2,
    };
}
namespace via::gui::BlurManager {
    enum ParentRenderLayerType {
        None = 0,
        Scene = 1,
        Composite = 2,
    };
}
namespace via::navigation::FailReport {
    enum FailAttribute {
        DestPosNotSpecified = 0,
        StartNodeNotFound = 1,
        DestNodeNotFound = 2,
        PathNotFound = 3,
        PathfindInterrupt = 4,
        FailAttributeNum = 5,
    };
}
namespace via::render {
    enum DebugSeverity {
        None = 0,
        Level0 = 1,
        Level1 = 2,
        Level2 = 3,
    };
}
namespace app::Em8100::Goal {
    enum GoalId {
        Idle = 0,
        Discovery = 1,
        UnDiscovery = 2,
        Battle = 3,
        _None = 4,
    };
}
namespace app::Em8940ActionController {
    enum LayerIndex {
        Body = 0,
        T1 = 1,
        T2 = 2,
        T3 = 3,
        T4 = 4,
        T5 = 5,
        H1 = 6,
        H2 = 7,
        H3 = 8,
        H4 = 9,
        H5 = 10,
    };
}
namespace via::motion::IkMotionData {
    enum IkType {
        IkType_2Bone = 0,
        IkType_3BoneTypeC = 1,
    };
}
namespace app::Em5510::Action::Generate {
    enum Type {
        Em5400 = 0,
        Em5520 = 1,
    };
}
namespace via::audiorender {
    enum CodecType {
        None = 0,
        Wave = 1,
        Vorbis = 2,
        Atrac9 = 3,
        Xma = 4,
        Max = 5,
    };
}
namespace via::motion::SubExJointRemapOutput {
    enum CalculateMode {
        Sum = 0,
        Average = 1,
    };
}
namespace app::VFXEmitZoneGroup {
    enum Status {
        None = 0,
        EmitOffTrigger = 1,
        EmitOnTrigger = 2,
        EmitOn = 3,
    };
}
namespace app::NightmareFrameOutIconData {
    enum Type {
        CraftBench = 0,
        Crusher = 1,
    };
}
namespace app::MotionDelegate {
    enum Priority {
        High = 0,
        Middle = 1,
        Low = 2,
        Num = 3,
    };
}
namespace via::clr {
    enum EnumU8 {
        Dummy = 0,
    };
}
namespace app::Em3102::Em3102Order::Appear {
    enum Type {
        None = 0,
    };
}
namespace via::motion::FullBodyIKRig::BodyLoop {
    enum JointSide {
        Left = 0,
        Right = 1,
        Root = 2,
        MAX = 3,
    };
}
namespace app::Em8001::Em8001WwiseStateList {
    enum PropertyStealth {
        UnDiscovery = 0,
        Discovery = 1,
    };
}
namespace via::effect::detail {
    enum VelocityType {
        Direction = 0,
        Normal = 1,
        Radial = 2,
        Spread = 3,
        ScreenSpace = 4,
    };
}
namespace Em4000Effect {
    enum IDAlias {
        LostHead = 0,
        LostLeftArm = 1,
        LostRightArm = 2,
        LostLeftLeg = 3,
        LostRightLeg = 4,
    };
}
namespace app::CH9TutorialManager {
    enum TutorialType {
        NoWeapon_1 = 0,
        NoWeapon_2 = 1,
        Harpoon = 2,
        knife = 3,
        Bomb = 4,
        BombDetail = 5,
        Gauntlet_2 = 6,
        DoubleGauntlet = 7,
        Guard = 8,
        recovery = 9,
        Combine = 10,
        Matchett_Reward = 11,
        Tutorial_effigy = 12,
        knife_Desc = 13,
        NoDamage_BreakWall = 14,
        HarpoonChange = 15,
        NoWeapon = 16,
        NoWeapon_3 = 17,
        NoWeapon_4 = 18,
        BreakWallTutorial = 19,
        BreakWallTutorial2 = 20,
        Challenge_First = 21,
    };
}
namespace via::landscape::path {
    enum InterpolateType {
        Bezier = 0,
        Liner = 1,
        Spline = 2,
    };
}
namespace app::Em8100 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Battle = 2,
    };
}
namespace via::uds {
    enum UdsEventState {
        Initial = 0,
        Created = 1,
        Posting = 2,
        PostFailed = 3,
        PostSucceeded = 4,
    };
}
namespace System {
    enum StringComparison {
        CurrentCulture = 0,
        CurrentCultureIgnoreCase = 1,
        InvariantCulture = 2,
        InvariantCultureIgnoreCase = 3,
        Ordinal = 4,
        OrdinalIgnoreCase = 5,
    };
}
namespace via::hid::virtualKeyboard::nsw {
    enum InvalidButtonFlag {
        None = 0,
        AnalogStickL = 2,
        AnalogStickR = 4,
        ZL = 8,
        ZR = 16,
    };
}
namespace app::Em4200::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4100ActionController {
    enum MoveType {
        Default = 0,
        ForceSolo = 1,
        ForceAround = 2,
    };
}
namespace via::attribute::RemotePropertyAttribute {
    enum SyncMode {
        Copy = 0,
        Kill = 1,
        Transaction = 2,
    };
}
namespace via::render::Atmosphere {
    enum DebugViewTextureIndex {
        Current = 0,
        Next = 1,
    };
}
namespace app::Em2000::Goal {
    enum Battle4State {
        FirstFlow = 0,
        SecondFlow = 1,
        ThirdFlow = 2,
        MountGrapple = 3,
    };
}
namespace via::render::RenderConfig {
    enum DownsamplerType {
        Default = 0,
        FidelityFXSPD = 1,
    };
}
namespace app::PauseMenu {
    enum RestratStateEnum {
        SelectWait = 0,
        StartWait = 1,
        LoadWait = 2,
    };
}
namespace app::InventoryMenu::CursorParam {
    enum ModeDef {
        ItemSlotOnly = 0,
        ItemBoxMode = 1,
    };
}
namespace app::CH9Em6400::Action::AttackToGrapple {
    enum Type {
        None = 0,
        CommonGrab = 1,
        CommonGrabSp = 2,
    };
}
namespace via::fsm::action::Trace {
    enum TraceType {
        Info = 0,
        Warning = 1,
        Error = 2,
    };
}
namespace via::motion::SubExJointRemapOutput {
    enum JointLimitFlags {
        BasePose = 1,
    };
}
namespace via::attribute {
    enum MemorySizeUnit {
        Byte = 0,
        KiB = 1,
        MiB = 2,
        GiB = 3,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraAttr {
        Ignore = 4294967295,
        AecAgcEnable = 0,
        AecAgcDisable = 1,
        ExposureGainMode0 = 0,
        ExposureGainMode1 = 1,
        WhiteBalanceAuto = 0,
        WhiteBalanceManual = 1,
        GammaControlOn = 0,
        GammaControlOff = 1,
    };
}
namespace via::hid::virtualKeyboard::nsw {
    enum InputFormMode {
        OneLine = 0,
        MultiLine = 1,
        Separate = 2,
    };
}
namespace app::HIDManager {
    enum UserType {
        User0 = 0,
        User1 = 1,
        Merged = 2,
        Max = 3,
        Active = 0,
        Sub = 1,
    };
}
namespace app::Achievement {
    enum StadiaStatsID {
        RestartCount = 1,
        OpenItemBoxCount = 2,
        UsedCureCount = 3,
    };
}
namespace app::Em8900Think {
    enum MessageType {
        Move = 0,
        Damage = 1,
        DeathAttack = 2,
    };
}
namespace app::Gunturret {
    enum LampState {
        Sleep = 0,
        Searching = 1,
        Detected = 2,
    };
}
namespace via::render {
    enum BufferexSrvFlag {
        Raw = 1,
    };
}
namespace app::PlayerHandTouch {
    enum State {
        Search = 0,
        Action = 1,
        Attach = 2,
        Release = 3,
        Bothhand = 4,
        Abort = 5,
    };
}
namespace app::Em4100::Action::Grapple {
    enum Type {
        Thrust = 0,
    };
}
namespace app::CH8Em4200Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace app::Chain::WindParameter {
    enum Priority {
        Low = 0,
        Normal = 1,
        High = 2,
    };
}
namespace via::render {
    enum StochasticTransparentResolution {
        Best = 0,
        High = 1,
        Medium = 2,
        Low = 3,
    };
}
namespace app::Em5540 {
    enum ThinkOrder {
        None = 0,
        Dead = 1,
        Revive = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum RequestType {
        Normal = 0,
        Force = 1,
    };
}
namespace via::timeline {
    enum BindType {
        Children = 0,
        Scene = 1,
        Fixed = 2,
        Direct = 3,
    };
}
namespace app::Em4100::ThinkAppearSet {
    enum Type {
        Default = 0,
        NoUse_Wall1 = 1,
        NoUse_Wall2 = 2,
        FromWall3_Normal = 3,
        FromWall4_Speedy = 4,
        FromCeil1_Normal = 5,
        FromCeil2_Speedy = 6,
        FirstAppear = 7,
        FromLakeL = 8,
        FromLakeR = 9,
        NoUse_Chandelier = 100,
        NoUse_CeilingLoop = 200,
        NoUse_FromWallLeftLoop = 201,
        NoUse_FromWallRightLoop = 202,
        Summon = 203,
    };
}
namespace via::motion::RetargetRig {
    enum CalcAxis {
        BaseRoot = 0,
        BaseFrontDirection = 1,
    };
}
namespace app::CH8HandgunBulletSound {
    enum CHP8_HandgunBullet {
        Normal = 1,
        Strong = 2,
    };
}
namespace via::gui {
    enum ListInputDirection {
        Prev = 0,
        Next = 1,
    };
}
namespace via::motion::IkLeg2Data {
    enum Flags {
        EnableGroundAdjust = 1,
        EnableRaycastSkipByDistance = 2,
        EnableRaycastFromVirtualGround = 4,
        EnableAdjustFootLimit = 8,
        EnableAutoSlopeScaling = 16,
        EnableTiltFromVirtualGround = 32,
    };
}
namespace app::CarInGarage::HijackedByEnemy {
    enum Routine {
        FirstMove = 0,
        TurnForPrepare = 1,
        BreakShelf = 2,
        AdjustCoord = 3,
        MoveToSteelFrame = 4,
        WaitOnFrontSteelFrame = 5,
        ReverseForCrash = 6,
        End = 7,
    };
}
namespace app::AI::UseDoorInfo {
    enum useDoorStatus {
        None = 0,
        Close = 1,
        FrontHalfOpen = 2,
        BackHalfOpen = 3,
        AutoClose = 4,
        Open = 5,
    };
}
namespace via::fsm {
    enum RestartType {
        ExecuteOn = 0,
        ExecuteOff = 1,
        UseResource = 2,
        Ignore = 3,
    };
}
namespace via::network::wrangler {
    enum EventPriority {
        Undefined = 0,
        Normal = 1,
        Critical = 2,
        ProviderDefault = 3,
    };
}
namespace app::CH8Em4100::Action::CH8StrikeToParry {
    enum StrikeToParryType {
        Right = 0,
        Left = 1,
        Head = 2,
    };
}
namespace via::render::streaming_detail {
    enum StreamingState {
        Ready = 0,
        Request = 1,
        Complete = 2,
    };
}
namespace app::CH8StateSwitchM9 {
    enum CHP8_9 {
        SILENCE = 0,
        BLADE_LV1 = 1,
        BLADE_LV2 = 2,
        END = 3,
    };
}
namespace via::os {
    enum SanityCheckSection {
        Text = 0,
        Rdata = 1,
        Antitamper = 2,
        Header = 3,
    };
}
namespace app::GameEventTask {
    enum ProcessType {
        Stop = 0,
        Setup = 1,
        Interp = 2,
        Play = 3,
    };
}
namespace via::motion::IkLeg {
    enum CenterDistance {
        OriginalLeg = 0,
        LeachLeg = 1,
    };
}
namespace via::landscape {
    enum MapBakerHeightIntersectBakeType {
        SDF = 0,
    };
}
namespace via::render::detail {
    enum RequiredTexture {
        IBL = 1,
        CubeMap = 2,
        LocalCubeMap = 4,
        TransparentHDR = 8,
    };
}
namespace Em5520Effect {
    enum IDAlias {
        Fire = 0,
    };
}
namespace via::hid {
    enum MouseCursorImageIndex {
        Index0 = 0,
        Index1 = 1,
        Index2 = 2,
        Index3 = 3,
        Index4 = 4,
        Max = 5,
    };
}
namespace via::navigation::map {
    enum SegmentLayer {
        Lower = 0,
        Upper = 1,
        SegmentLayerNum = 2,
    };
}
namespace via::autoplay::AutoPlayArg {
    enum AutoPlayStatus {
        Change = 0,
        Start = 1,
        Stop = 2,
        End = 3,
        Pause = 4,
        Resume = 5,
        LostDevice = 6,
    };
}
namespace via::dialog {
    enum Result {
        Ok = 0,
        UserCanceled = 1,
        Running = 2,
        InvalidState = 3,
        NotRunning = 4,
        UnexpectedFatal = 5,
        NotSupported = 6,
    };
}
namespace via::render {
    enum ForceShaderLod {
        ForceShaderLod_None = -1,
        ForceShaderLod_0 = 0,
        ForceShaderLod_1 = 1,
        ForceShaderLod_2 = 2,
        ForceShaderLod_3 = 3,
        ForceShaderLod_4 = 4,
        ForceShaderLod_5 = 5,
        ForceShaderLod_6 = 6,
        ForceShaderLod_7 = 7,
    };
}
namespace app::StrikeController {
    enum Result {
        Normal = 0,
        Grapple = 1,
    };
}
namespace app::Em8000::Effect::Em8000EffectID {
    enum Tag {
        None = 0,
        Jack_DeadSplash = 1,
        Corpsebag_CompleteSpawn = 2,
        Weapon_Smoke = 3,
        Weapon_Spark = 4,
        Core_Damage_Front = 5,
        Core_Damage_Back = 6,
    };
}
namespace via::render::LDRLensDistortion {
    enum DistortionType {
        Default = 0,
        Panini = 1,
    };
}
namespace via::effect::detail {
    enum Repeat {
        None = 0,
        U = 1,
        V = 2,
    };
}
namespace via::effect::detail {
    enum CullingMode {
        Draw = 0,
        DrawAndMove = 1,
    };
}
namespace app::CH8Em4500GeneratePoint {
    enum Order {
        None = 0,
        Generate = 1,
    };
}
namespace via::navigation::Navigation {
    enum LegacySetting {
        Trace3D = 0,
        AStar = 1,
        PortalAStar = 2,
        WallUpdateCheck = 3,
    };
}
namespace app::EnemyActionController {
    enum ForbidDamageReactionType {
        Small = 0,
        Middle = 1,
        Large = 2,
        Lost = 3,
        BlownAway = 4,
        Dead = 5,
    };
}
namespace via::render::RenderConfig {
    enum FramerateType {
        FIXING30 = 0,
        FIXING60 = 1,
        VARIABLE = 2,
    };
}
namespace via::motion::MotionCameraSkeleton {
    enum JointHash {
        JointNo_Transform = 0,
        JointNo_Camera = 1,
    };
}
namespace via::uvsequence {
    enum TextureUsageType {
        Albedo = 0,
        Normal = 1,
        Specular = 2,
        Alpha = 3,
        Num = 4,
        Unknown = 5,
    };
}
namespace via::render {
    enum TextureType {
        Default = 0,
        Base = 1,
        BaseAlpha = 2,
        Normal = 3,
        Roughness = 4,
        Metallic = 5,
        Mask1ch = 6,
        Mask2ch = 7,
        Mask3ch = 8,
        Mask4ch = 9,
        BaseDielectric = 10,
        BaseMetallic = 11,
        NormalRoughness = 12,
        Normal2chRoughness = 13,
        HDR = 14,
        Light = 15,
        Image = 16,
        ImageAlpha = 17,
        AlphaGamma = 18,
        BlackWhite = 19,
        Max = 20,
    };
}
namespace app::Command {
    enum AnalogButtonType {
        LT = 0,
        RT = 1,
    };
}
namespace app::Em4200::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Fixed = 2,
        Wait = 3,
        Elevator = 4,
        Discovery = 5,
        UnDiscovery = 6,
        ClosedRoute = 7,
        IdleLostTarget = 8,
        Idle = 9,
        Follow = 10,
        Grapple = 11,
        MountTry = 12,
        Rush = 13,
        BreathSimple = 14,
        BreathForce = 15,
        Breath = 16,
        FixedBreath = 17,
        Door = 18,
        DoorOpen = 19,
        DoorOpen2 = 20,
        DoorClose = 21,
        DoorClose2 = 22,
        Move = 23,
        AppearAction = 24,
        IdleAction = 25,
        ElevatorAction = 26,
        RushAction = 27,
        SplashAction = 28,
        BreathSimpleAction = 29,
        BreathForceAction = 30,
        BreathAction = 31,
        MountTryAction = 32,
        GrappleAction = 33,
    };
}
namespace via::render {
    enum SysValSemantic {
        Undefined = 0,
        Position = 1,
        Clip_Distance = 2,
        Cull_Distance = 3,
        Render_Target_Array_Index = 4,
        Viewport_Array_Index = 5,
        Vertex_Id = 6,
        Primitive_Id = 7,
        Instance_Id = 8,
        Is_Front_Face = 9,
        Sample_Index = 10,
        Final_Quad_Edge_Tessfactor = 11,
        Final_Quad_Inside_Tessfactor = 12,
        Final_Tri_Edge_Tessfactor = 13,
        Final_Tri_Inside_Tessfactor = 14,
        Final_Line_Detail_Tessfactor = 15,
        Final_Line_Density_Tessfactor = 16,
        Target = 17,
        Depth = 18,
        Coverage = 19,
        Depth_Greater_Equal = 20,
        Depth_Less_Equal = 21,
    };
}
namespace via::wwise {
    enum TargetType {
        OnlyThisGameObject = 0,
        IncludesOtherRelatingSounds = 1,
    };
}
namespace via::motion {
    enum EndType {
        None = 0,
        EndOfMotion = 1,
        ExitFrame = 2,
        ExitFrameFromEnd = 3,
        SyncPoint = 4,
        SyncPointFromEnd = 5,
    };
}
namespace app::fsm::CH8FadeControlAction {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace app::CH8TramPuzzleSensor {
    enum SensorType {
        Disable = 0,
        Stop = 1,
        Barricade = 2,
    };
}
namespace app::CH9Em7900::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Fixed = 2,
        Wait = 3,
        Elevator = 4,
        Discovery = 5,
        UnDiscovery = 6,
        ClosedRoute = 7,
        IdleLostTarget = 8,
        Idle = 9,
        Follow = 10,
        Grapple = 11,
        MountTry = 12,
        Rush = 13,
        BreathSimple = 14,
        BreathForce = 15,
        Breath = 16,
        FixedBreath = 17,
        Door = 18,
        DoorOpen = 19,
        DoorOpen2 = 20,
        DoorClose = 21,
        DoorClose2 = 22,
        Move = 23,
        AppearAction = 24,
        IdleAction = 25,
        ElevatorAction = 26,
        RushAction = 27,
        SplashAction = 28,
        BreathSimpleAction = 29,
        BreathForceAction = 30,
        BreathAction = 31,
        MountTryAction = 32,
        GrappleAction = 33,
    };
}
namespace app::PlayerGrappleEm2000 {
    enum GrappleAutoCorrectType {
        SafePosition = 0,
        SafeDirection = 1,
    };
}
namespace app {
    enum EnemyID {
        Em0000 = 0,
        Em0010 = 1,
        Em2000 = 2,
        Em2100 = 3,
        Em3000 = 4,
        Em3100 = 5,
        Em3200 = 6,
        Em3300 = 7,
        Em3390 = 8,
        Em3400 = 9,
        Em3500 = 10,
        Em3600 = 11,
        Em3700 = 12,
        Em4000 = 13,
        Em4100 = 14,
        Em4200 = 15,
        Em5400 = 16,
        Em5510 = 17,
        Em5520 = 18,
        Em5540 = 19,
        Em5552 = 20,
        Em5570 = 21,
        Em6000 = 22,
        Em6100 = 23,
        Em6200 = 24,
        Em8000 = 25,
        Em8100 = 26,
        Em8500 = 27,
        Em8510 = 28,
        Em8520 = 29,
        Em8530 = 30,
        Em8540 = 31,
        Em8550 = 32,
        Em8900 = 33,
        Em8910 = 34,
        Em8940 = 35,
        Em8950 = 36,
        Em9200 = 37,
        Em9600 = 38,
        Em3090 = 39,
        Em3001 = 40,
        Em3002 = 41,
        Em3102 = 42,
        Em8001 = 43,
        Em9800 = 44,
        Em4010 = 45,
        Em4210 = 46,
        Em4400 = 47,
        Em4450 = 48,
        Em4500 = 49,
        Em4600 = 50,
        Em3800 = 51,
        Em3900 = 52,
        Em4700 = 53,
        Em4750 = 54,
        Em4800 = 55,
        Em4900 = 56,
        Em5700 = 57,
        Em5800 = 58,
        Em5801 = 59,
        Em5802 = 60,
        Em5850 = 61,
        Em5900 = 62,
        Em5901 = 63,
        Em6300 = 64,
        Em6350 = 65,
        Em6400 = 66,
        Em6450 = 67,
        Em6500 = 68,
        Em6550 = 69,
        Em6600 = 70,
        Em6650 = 71,
        Em6700 = 72,
        Em6750 = 73,
        Em6800 = 74,
        Em6850 = 75,
        Em6900 = 76,
        Em6950 = 77,
        Em7400 = 78,
        Em7500 = 79,
        Em7550 = 80,
        Em7600 = 81,
        Em7700 = 82,
        Em7800 = 83,
        Em7900 = 84,
    };
}
namespace app::PlayerDefine {
    enum LArmCondition {
        Normal = 0,
        HemostasisStart = 1,
        Hemostasis = 2,
        HemostasisEnd = 3,
    };
}
namespace app::Em4000::Action::Strike {
    enum Type {
        Normal = 0,
        Backstep = 1,
        Slash = 2,
    };
}
namespace app::CH9Em5800Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em2000::Action::Chapter1Battle4WalkStrafe {
    enum Type {
        Slow = 0,
        Normal = 1,
        Fast = 2,
    };
}
namespace via::motion::detail::ChainNodeData {
    enum AngleMode {
        Free = 0,
        LimitCone = 1,
        LimitHinge = 2,
        LimitConeBox = 3,
        LimitOval = 4,
        LimitElliptic = 5,
    };
}
namespace via::network::error {
    enum MethodStorage {
        Update = 0,
        GetInfo = 1,
        Unlink = 2,
        Open = 3,
        Write = 4,
        Read = 5,
    };
}
namespace app::CH9Em6400::Action::GrappleFromPlayer {
    enum Type {
        None = 0,
        FromPlayer_Skill00 = 1,
        FromPlayer_Skill02 = 2,
        FromPlayer_CH92Finish = 3,
        FromPlayer_CH94Finish = 4,
    };
}
namespace via::effect::gpgpu::Lightning3DCS::Lightning3DResource {
    enum Lightning3DComputeShaderType {
        InitializeCS = 0,
        InitializePointPoolCS = 1,
        ConstructCS = 2,
        MaxType = 3,
    };
}
namespace app::Em2000::Goal {
    enum Message {
        Chapter1Battle2Walking = 0,
        Chapter1Battle4Walking = 1,
        Chapter1Battle4Attack = 2,
        Chapter1Battle4Grapple = 3,
        Chapter1Battle4WallBreak = 4,
        Chapter1Battle4Finding1 = 5,
        Chapter1Battle4Finding2 = 6,
        Chapter1Battle4Looking = 7,
        Chapter4Battle2Walking = 8,
    };
}
namespace app::CH8LastBattleMessageData {
    enum MessageIDTable {
        CH8_pl1050_4422_CH8_op1050_4433 = 0,
        CH8_pl1050_4424 = 1,
        CH8_pl1050_4429 = 2,
        CH8_pl1050_4426 = 3,
        CH8_op1050_4437 = 4,
        CH8_pl1050_4421 = 5,
        CH8_op1050_4439 = 6,
        CH8_pl1050_4420 = 7,
        CH8_pl1050_4430 = 8,
        CH8_op1050_4431 = 9,
        CH8_op1050_4432 = 10,
        CH8_op1050_9200 = 11,
        CH8_op1050_9180 = 12,
        CH8_pl1050_9170 = 13,
        CH8_op1050_9205 = 14,
        CH8_pl1050_9190 = 15,
        CH8_pl1050_9195 = 16,
        CH8_op1050_9220 = 17,
        CH8_op1050_9225 = 18,
        CH8_pl1050_9215 = 19,
        CH8_pl1050_9210 = 20,
    };
}
namespace app::cutin::CutinHandle3Scroll {
    enum ResultDef {
        Select1 = 0,
        Select2 = 1,
        Select3 = 2,
        Undecided = 3,
    };
}
namespace app::Command {
    enum ThresholdType {
        MoreThan = 0,
        LessThan = 1,
    };
}
namespace via::network::wrangler {
    enum BlobType {
        Unknown = 0,
        String = 1,
        GUID = 2,
        Int32 = 3,
        UInt32 = 4,
        Int64 = 5,
        UInt64 = 6,
        Float = 7,
        Double = 8,
        Boolean = 9,
    };
}
namespace app::Em3000::Action::AttackRush {
    enum Type {
        Forward = 0,
        Right = 1,
        Left = 2,
        Back = 3,
    };
}
namespace via::render {
    enum DisplaySyncExtension {
        None = 0,
        FreeSync2 = 1,
    };
}
namespace via::hid {
    enum VrTrackerDeviceType {
        HMD = 0,
        Dualshock4 = 1,
    };
}
namespace via::render {
    enum StreamingTextureRequestStrategy {
        Default = 0,
        InsideBounding = 1,
        DistanceFromBounding = 2,
    };
}
namespace System::Reflection {
    enum MethodAttributes {
        MemberAccessMask = 7,
        PrivateScope = 0,
        Private = 1,
        FamANDAssem = 2,
        Assembly = 3,
        Family = 4,
        FamORAssem = 5,
        Public = 6,
        Static = 16,
        Final = 32,
        Virtual = 64,
        HideBySig = 128,
        CheckAccessOnOverride = 512,
        VtableLayoutMask = 256,
        ReuseSlot = 0,
        NewSlot = 256,
        Abstract = 1024,
        SpecialName = 2048,
        PinvokeImpl = 8192,
        UnmanagedExport = 8,
        RTSpecialName = 4096,
        HasSecurity = 16384,
        RequireSecObject = 32768,
        ReservedMask = 53248,
    };
}
namespace via::motion::IkSpine {
    enum RAY_TYPE {
        DEFAULT = 0,
        JOINT = 1,
    };
}
namespace via::motion::JointExMultiRemapValue::ConeInputData {
    enum AttrFlags {
        None = 0,
        BasePose = 1,
    };
}
namespace app::DebugFolderActivater {
    enum ActiveTypeEnum {
        RootDebug = 0,
        ChapterDebug = 1,
        Max = 2,
    };
}
namespace via::render::detail {
    enum PrimitiveRayTracingMode {
        TwoWay = 0,
        FourWay = 1,
    };
}
namespace via::motion::IkLegSpine {
    enum LeanTarget {
        Center = 0,
        CenterAndHeal = 1,
    };
}
namespace app::CH9Em6400ActionController {
    enum RushState {
        Normal = 0,
        Anger = 1,
    };
}
namespace app::GameOverScreen {
    enum Result {
        Unknown = 0,
        Restart = 1,
        Quit = 2,
        Cp7Result = 3,
    };
}
namespace via::gui {
    enum SoftParticleDistType {
        System = 0,
        Component = 1,
        Disable = 2,
    };
}
namespace via::simplewwise {
    enum DeviceTypeNSW {
        None = 0,
        Main = 1,
        MergeToMain = 2,
        Plugin = 3,
    };
}
namespace app::CH8SaveManager {
    enum SaveSlotTextType {
        SLOT_TEXT_DIFFICULTY = 0,
        SLOT_TEXT_PLAY_TIME = 1,
        SLOT_TEXT_PLACE = 2,
        SLOT_TEXT_OBJECTIVE = 3,
    };
}
namespace via::nnfc {
    enum ERRORVIEWER_CODE {
        ERRORVIEWER_WIRELESS_OFF = 0,
        ERRORVIEWER_NFP_NOT_SUPPORT = 1,
        ERRORVIEWER_NFP_INVALID_FORMAT_VER = 2,
    };
}
namespace app::CH8Em4200::Action::CH8Grapple {
    enum Type {
        Mount = 0,
    };
}
namespace app::Em3001::Action::TurnAttack {
    enum Type {
        Forward = 0,
        Right = 1,
        Left = 2,
        BackR = 3,
        BackL = 4,
    };
}
namespace app::Em3001::Goal {
    enum AppearMessageStatus {
        Non = 0,
        UnDiscovery = 1,
        DiscoveryShort = 2,
        DiscoveryMiddle = 3,
    };
}
namespace app::WetPlayer {
    enum Routine {
        Start = 0,
        WaitApply = 1,
        End = 2,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData::JointDriverData {
    enum AttrFlags {
        None = 0,
        BasePose = 1,
        MidPoint = 2,
        World = 4,
    };
}
namespace via::motion::IkMultiBone {
    enum IkMethod {
        OneBone = 0,
        TwoBone = 1,
        ThreeBoneZigzag = 2,
        ThreeBoneConvex = 3,
        CCDIK = 4,
        FABRIK = 5,
    };
}
namespace app::Em4100ActionController {
    enum BackstepQueType {
        Back = 0,
        Left = 1,
        Right = 2,
    };
}
namespace via::gui {
    enum HitAreaShape {
        Triangle = 0,
        Rect = 1,
        Hexagon = 2,
        Octagon = 3,
        FreeTriangle = 4,
    };
}
namespace via::behaviortree::SelectorCallerChildNodeEnd {
    enum CheckType {
        AnyNode = 0,
        AllNode = 1,
    };
}
namespace via::memory {
    enum AllocatorType {
        Boot = 0,
        Default = 1,
        Permanent = 2,
        Resource = 3,
        Develop = 4,
        Temp = 5,
        VRAM = 6,
        Sound = 7,
        Max = 8,
    };
}
namespace via::render::RenderConfig {
    enum RenderingMethod {
        Normal = 0,
        Checkerboard = 1,
        Interlaced = 2,
    };
}
namespace app::CH9Em7700::ThinkAppearSet {
    enum MimicryType {
        Floor1 = 0,
        Floor2 = 1,
        Lean1 = 2,
        Lean2 = 3,
        Lean3 = 4,
    };
}
namespace via::render::AmbientOcclusionGeometryElement {
    enum GeometryType {
        Sphere = 0,
        Capsule = 1,
        None = 2,
    };
}
namespace via {
    enum memory_order {
        relaxed = 0,
        consume = 1,
        acquire = 2,
        release = 3,
        acq_rel = 4,
        seq_cst = 5,
    };
}
namespace via::effect::detail {
    enum Shape2DType {
        Square = 0,
        Circle = 1,
    };
}
namespace via::motion::detail::ChainLinkData {
    enum ConnectionFlags {
        Neighbour = 1,
        Upper = 2,
        Bottom = 4,
    };
}
namespace app::CH8GetEventItem {
    enum Process {
        WaitInteract = 0,
        WaitDailog = 1,
        WaitDailog2 = 2,
        End = 3,
    };
}
namespace app::fsm::OpenCloseCreditsScene {
    enum Action {
        Open = 0,
        End = 1,
    };
}
namespace via::hid::hmd::Morpheus {
    enum VrModeStatusCheckLevel {
        Nothing = 0,
        Warning = 1,
        Error = 2,
        Assertion = 3,
    };
}
namespace via::network::MatchmakingHopper {
    enum Option {
        Flex = 0,
        HostFix = 1,
    };
}
namespace via::AnimationCurveData {
    enum Wrap {
        Once = 0,
        Loop = 1,
        Loop_Always = 2,
    };
}
namespace via::render {
    enum IndexSetStrategy {
        Default = 0,
        IndexSetStragety_SeparateAndIncrementOnly = 1,
        IndexSetStragety_DirtyCheck = 2,
    };
}
namespace app::Nightmare {
    enum TrapID {
        None = 0,
        OilCan = 1,
        WireTrap = 2,
        GasTrap = 3,
        Turret = 4,
    };
}
namespace via::render::PrimitiveMaterial {
    enum Shader {
        Billboard = 0,
        BillboardLighting = 1,
        BillboardPerPixelLighting = 2,
        BillboardMieLighting = 3,
        Ribbon = 4,
        RibbonLighting = 5,
        RibbonPerPixelLighting = 6,
        RibbonMieLighting = 7,
        Polygon = 8,
        PolygonLighting = 9,
        PolygonPerPixelLighting = 10,
        PolygonMieLighting = 11,
        PolygonStrip = 12,
        PolygonStripLighting = 13,
        PolygonStripPerPixelLighting = 14,
        PolygonStripMieLighting = 15,
        BillboardVolumetricFog = 16,
        BillboardLightingVolumetricFog = 17,
        BillboardPerPixelLightingVolumetricFog = 18,
        BillboardMieLightingVolumetricFog = 19,
        RibbonVolumetricFog = 20,
        RibbonLightingVolumetricFog = 21,
        RibbonPerPixelLightingVolumetricFog = 22,
        RibbonMieLightingVolumetricFog = 23,
        PolygonVolumetricFog = 24,
        PolygonLightingVolumetricFog = 25,
        PolygonPerPixelLightingVolumetricFog = 26,
        PolygonMieLightingVolumetricFog = 27,
        PolygonStripVolumetricFog = 28,
        PolygonStripLightingVolumetricFog = 29,
        PolygonStripPerPixelLightingVolumetricFog = 30,
        PolygonStripMieLightingVolumetricFog = 31,
        BillboardToMixBuf = 32,
        BillboardLightingToMixBuf = 33,
        BillboardPerPixelLightingToMixBuf = 34,
        BillboardMieLightingToMixBuf = 35,
        RibbonToMixBuf = 36,
        RibbonLightingToMixBuf = 37,
        RibbonPerPixelLightingToMixBuf = 38,
        RibbonMieLightingToMixBuf = 39,
        PolygonToMixBuf = 40,
        PolygonLightingToMixBuf = 41,
        PolygonPerPixelLightingToMixBuf = 42,
        PolygonMieLightingToMixBuf = 43,
        PolygonStripToMixBuf = 44,
        PolygonStripLightingToMixBuf = 45,
        PolygonStripPerPixelLightingToMixBuf = 46,
        PolygonStripMieLightingToMixBuf = 47,
        BillboardVolumetricFogToMixBuf = 48,
        BillboardLightingVolumetricFogToMixBuf = 49,
        BillboardPerPixelLightingVolumetricFogToMixBuf = 50,
        BillboardMieLightingVolumetricFogToMixBuf = 51,
        RibbonVolumetricFogToMixBuf = 52,
        RibbonLightingVolumetricFogToMixBuf = 53,
        RibbonPerPixelLightingVolumetricFogToMixBuf = 54,
        RibbonMieLightingVolumetricFogToMixBuf = 55,
        PolygonVolumetricFogToMixBuf = 56,
        PolygonLightingVolumetricFogToMixBuf = 57,
        PolygonPerPixelLightingVolumetricFogToMixBuf = 58,
        PolygonMieLightingVolumetricFogToMixBuf = 59,
        PolygonStripVolumetricFogToMixBuf = 60,
        PolygonStripLightingVolumetricFogToMixBuf = 61,
        PolygonStripPerPixelLightingVolumetricFogToMixBuf = 62,
        PolygonStripMieLightingVolumetricFogToMixBuf = 63,
        Billboard_IgnoreDepth = 64,
        BillboardLighting_IgnoreDepth = 65,
        BillboardPerPixelLighting_IgnoreDepth = 66,
        BillboardMieLighting_IgnoreDepth = 67,
        Ribbon_IgnoreDepth = 68,
        RibbonLighting_IgnoreDepth = 69,
        RibbonPerPixelLighting_IgnoreDepth = 70,
        RibbonMieLighting_IgnoreDepth = 71,
        Polygon_IgnoreDepth = 72,
        PolygonLighting_IgnoreDepth = 73,
        PolygonPerPixelLighting_IgnoreDepth = 74,
        PolygonMieLighting_IgnoreDepth = 75,
        PolygonStrip_IgnoreDepth = 76,
        PolygonStripLighting_IgnoreDepth = 77,
        PolygonStripPerPixelLighting_IgnoreDepth = 78,
        PolygonStripMieLighting_IgnoreDepth = 79,
        BillboardVolumetricFog_IgnoreDepth = 80,
        BillboardLightingVolumetricFog_IgnoreDepth = 81,
        BillboardPerPixelLightingVolumetricFog_IgnoreDepth = 82,
        BillboardMieLightingVolumetricFog_IgnoreDepth = 83,
        RibbonVolumetricFog_IgnoreDepth = 84,
        RibbonLightingVolumetricFog_IgnoreDepth = 85,
        RibbonPerPixelLightingVolumetricFog_IgnoreDepth = 86,
        RibbonMieLightingVolumetricFog_IgnoreDepth = 87,
        PolygonVolumetricFog_IgnoreDepth = 88,
        PolygonLightingVolumetricFog_IgnoreDepth = 89,
        PolygonPerPixelLightingVolumetricFog_IgnoreDepth = 90,
        PolygonMieLightingVolumetricFog_IgnoreDepth = 91,
        PolygonStripVolumetricFog_IgnoreDepth = 92,
        PolygonStripLightingVolumetricFog_IgnoreDepth = 93,
        PolygonStripPerPixelLightingVolumetricFog_IgnoreDepth = 94,
        PolygonStripMieLightingVolumetricFog_IgnoreDepth = 95,
        BillboardToMixBuf_IgnoreDepth = 96,
        BillboardLightingToMixBuf_IgnoreDepth = 97,
        BillboardPerPixelLightingToMixBuf_IgnoreDepth = 98,
        BillboardMieLightingToMixBuf_IgnoreDepth = 99,
        RibbonToMixBuf_IgnoreDepth = 100,
        RibbonLightingToMixBuf_IgnoreDepth = 101,
        RibbonPerPixelLightingToMixBuf_IgnoreDepth = 102,
        RibbonMieLightingToMixBuf_IgnoreDepth = 103,
        PolygonToMixBuf_IgnoreDepth = 104,
        PolygonLightingToMixBuf_IgnoreDepth = 105,
        PolygonPerPixelLightingToMixBuf_IgnoreDepth = 106,
        PolygonMieLightingToMixBuf_IgnoreDepth = 107,
        PolygonStripToMixBuf_IgnoreDepth = 108,
        PolygonStripLightingToMixBuf_IgnoreDepth = 109,
        PolygonStripPerPixelLightingToMixBuf_IgnoreDepth = 110,
        PolygonStripMieLightingToMixBuf_IgnoreDepth = 111,
        BillboardVolumetricFogToMixBuf_IgnoreDepth = 112,
        BillboardLightingVolumetricFogToMixBuf_IgnoreDepth = 113,
        BillboardPerPixelLightingVolumetricFogToMixBuf_IgnoreDepth = 114,
        BillboardMieLightingVolumetricFogToMixBuf_IgnoreDepth = 115,
        RibbonVolumetricFogToMixBuf_IgnoreDepth = 116,
        RibbonLightingVolumetricFogToMixBuf_IgnoreDepth = 117,
        RibbonPerPixelLightingVolumetricFogToMixBuf_IgnoreDepth = 118,
        RibbonMieLightingVolumetricFogToMixBuf_IgnoreDepth = 119,
        PolygonVolumetricFogToMixBuf_IgnoreDepth = 120,
        PolygonLightingVolumetricFogToMixBuf_IgnoreDepth = 121,
        PolygonPerPixelLightingVolumetricFogToMixBuf_IgnoreDepth = 122,
        PolygonMieLightingVolumetricFogToMixBuf_IgnoreDepth = 123,
        PolygonStripVolumetricFogToMixBuf_IgnoreDepth = 124,
        PolygonStripLightingVolumetricFogToMixBuf_IgnoreDepth = 125,
        PolygonStripPerPixelLightingVolumetricFogToMixBuf_IgnoreDepth = 126,
        PolygonStripMieLightingVolumetricFogToMixBuf_IgnoreDepth = 127,
        BillboardMaterialLighting = 128,
        RibbonMaterialLighting = 129,
        PolygonMaterialLighting = 130,
        PolygonStripMaterialLighting = 131,
        Max = 132,
    };
}
namespace app::OptionMenu {
    enum Num10 {
        Value0 = 0,
        Value1 = 1,
        Value2 = 2,
        Value3 = 3,
        Value4 = 4,
        Value5 = 5,
        Value6 = 6,
        Value7 = 7,
        Value8 = 8,
        Value9 = 9,
        Value10 = 10,
    };
}
namespace via::hid {
    enum NpadStyle {
        Handheld = 1,
        FullKey = 2,
        JoyDual = 4,
        JoyLeft = 8,
        JoyRight = 16,
    };
}
namespace app::AI {
    enum CH8AttackPermitReturnReason {
        Hitted = 0,
        NotHitted = 1,
        Canceled = 2,
        Damaged = 3,
        Died = 4,
    };
}
namespace via::render {
    enum DepthWriteMask {
        Zero = 0,
        All = 1,
        Num = 2,
    };
}
namespace via::render::detail {
    enum CullingDataType {
        None = 0,
        OBB = 1,
        Sphere = 2,
        AABB = 3,
        Distance = 4,
        Cone = 5,
    };
}
namespace System::Reflection {
    enum BindingFlags {
        Default = 0,
        IgnoreCase = 1,
        DeclaredOnly = 2,
        Instance = 4,
        Static = 8,
        Public = 16,
        NonPublic = 32,
        FlattenHierarchy = 64,
        InvokeMethod = 256,
        CreateInstance = 512,
        GetField = 1024,
        SetField = 2048,
        GetProperty = 4096,
        SetProperty = 8192,
        PutDispProperty = 16384,
        PutRefDispProperty = 32768,
        ExactBinding = 65536,
        SuppressChangeType = 131072,
        OptionalParamBinding = 262144,
        IgnoreReturn = 16777216,
    };
}
namespace app::CH9Em5901 {
    enum ThinkState {
        None = 0,
    };
}
namespace app::MoldedActionController {
    enum DodgeVariation {
        Left = 0,
        LeftBack = 1,
        Right = 2,
        RightBack = 3,
    };
}
namespace app::Em4100::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH9Em7800::Action::Grapple {
    enum Type {
        Thrust = 0,
    };
}
namespace via::motion::IkJacobian::Link {
    enum AxisType {
        X = 1,
        Y = 2,
        Z = 4,
    };
}
namespace via::storage::saveService {
    enum SaveDataVersion {
        SaveDataVersion_None = 0,
        SaveDataVersion_1_ClassInheritance = 1,
        SaveDataVersion_2_IsNotFindSystemType = 2,
        SaveDataVersion_Max = 3,
        SaveDataVersion_Latest = 2,
    };
}
namespace app::IK2Bone {
    enum EffectorJointType {
        Default = 0,
        TargetJoint2 = 0,
        TargetJoint3 = 1,
    };
}
namespace via::motion::GpuMotion {
    enum WrapMode {
        Once = 0,
        Loop = 1,
        Motion = 2,
    };
}
namespace app::GameManager {
    enum MegusuriIconType {
        Yellow = 0,
        Red = 1,
    };
}
namespace app::Em3600Think {
    enum Mode {
        Normal = 0,
        Wall = 1,
        Sneak = 2,
        Generate = 3,
        Escape = 4,
        Last = 5,
        Damage = 6,
        Dead = 7,
        NearAppear = 8,
        TestGrappleAttack = 9,
        TestAttack = 10,
    };
}
namespace via::hid {
    enum GamePadMotor {
        Motor0 = 0,
        Motor1 = 1,
        Motor2 = 2,
        Motor3 = 3,
        Max = 4,
        Null = 5,
        All = 6,
        LowFrequencyMotor = 128,
        HighFrequencyMotor = 129,
        LAnalogTriggerMotor = 130,
        RAnalogTriggerMotor = 131,
    };
}
namespace via::storage::saveService {
    enum CheckExistingResult {
        Null = 0,
        Existing = 1,
        NotExisting = 2,
    };
}
namespace via::fsm {
    enum ExpressionReferenceType {
        LocalUserData = 0,
        GlobalUserData = 1,
        Direct = 2,
    };
}
namespace app::CardGameMaster {
    enum PosType {
        Stock = 0,
        Banker = 1,
        Player = 2,
    };
}
namespace app::Em3000::Action {
    enum ActionShort {
        Straight = 0,
        SwingDown = 1,
        LSwingDown = 2,
        GrappleCutLeg = 3,
        Side = 4,
        SwingR = 5,
        LSwingR = 6,
        SwingCombo = 7,
        Thrust = 8,
        GrappleNeckSlash = 9,
        GrappleShovelLift = 10,
        Grab = 11,
        GrappleHeadButt = 12,
        GrappleKnee = 13,
        GrappleMount = 14,
        GrappleClimax = 15,
        NonStepIn = 16,
        SwingL = 17,
        LSwingL = 18,
        AttackRush = 19,
        Num = 20,
        Non = 99,
    };
}
namespace via::hid {
    enum NpadConnectionAttribute {
        IsConnected = 1,
        IsWired = 2,
        IsLeftConnected = 4,
        IsLeftWired = 8,
        IsRightConnected = 16,
        IsRightWired = 32,
        IsDebugPadConnected = 2147483648,
    };
}
namespace app::JunkPartsChangedAnimation {
    enum ChangeContext {
        Get = 0,
        Lost = 1,
    };
}
namespace app::CarInGarage::Action {
    enum WallHitStatus {
        None = 0,
        Hit = 1,
        Crash = 2,
    };
}
namespace via::audiorender {
    enum Channel_3ch {
        L = 0,
        R = 1,
        C = 2,
        Max = 3,
    };
}
namespace via::landscape {
    enum QuadTreeTextureEnum {
        Invalid = -1,
        Heightmap = 0,
        Normal = 1,
        Albedo = 2,
        Splatmap = 3,
        Max = 4,
    };
}
namespace via::render::layer {
    enum OutlineRenderSegment {
        DrawMask = 0,
        DrawOutline = 5,
        Copy = 7,
        Lowest = 63,
    };
}
namespace via::os::dma {
    enum DMA_RESULT {
        DMA_SUCCESS = 0,
        DMA_INVARG = 0,
        DMA_FAIL = 0,
    };
}
namespace app::Cp7PCLockNumberFsm {
    enum Step {
        StartCamera = 0,
        StartInput = 1,
        WaitInput = 2,
        EndCamera = 3,
        Max = 4,
    };
}
namespace app::Collision::DamageUserData {
    enum Attribute {
        SkipHitStop = 0,
        SkipStageAtari = 1,
        ___b2 = 2,
        ___b3 = 3,
        ___b4 = 4,
        ___b5 = 5,
        ___b6 = 6,
        ___b7 = 7,
        BulletProof = 8,
        AllPartsHit = 9,
        HitThrough = 10,
        ___b32 = 32,
        ___b33 = 33,
        ___b64 = 64,
        ___b65 = 65,
        ___b96 = 96,
        ___b97 = 97,
        ___d00 = 128,
        ___d01 = 129,
    };
}
namespace via::network::log {
    enum Period {
        Develop = 0,
        QA = 1,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum ScorePanelState {
        DISABLE = 0,
        FADE_IN = 1,
    };
}
namespace via::hid {
    enum VibrationPriority {
        Lowest = 0,
        Low = 2,
        Middle = 3,
        High = 4,
        Highest = 6,
    };
}
namespace via::motion::MotionData {
    enum AttrFlags {
        GpuMot = 1,
        JointPose = 2,
    };
}
namespace via::render {
    enum VFXResolution {
        Full = 0,
        Half = 1,
        One_Third = 2,
        Quater = 3,
    };
}
namespace via::motion::CppSampleAppendData {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
    };
}
namespace via::render {
    enum InterleaveSettingInitialValue {
        Automatic = 0,
        Disable = 1,
        Enable = 2,
    };
}
namespace app::OptionMenu {
    enum ReNetIndex {
        Web = 0,
        OnOff = 1,
        Detail = 2,
    };
}
namespace app::Em3600::Action::GrappleAttack {
    enum Type {
        ThrowF = 0,
        Mount = 1,
        MountFourLeg = 2,
        Cell = 3,
        Choke = 4,
        Drop = 5,
        Floor = 6,
        Floor_v1 = 7,
        Window = 8,
    };
}
namespace via::hid::virtualKeyboard::nsw {
    enum InvalidCharFlag {
        None = 0,
        Space = 2,
        AtMark = 4,
        Percent = 8,
        Slash = 16,
        BackSlash = 32,
        Numeric = 64,
        OutsideOfDownloadCode = 128,
        OutsideOfMiiNickName = 256,
    };
}
namespace via::effect::gpgpu::detail {
    enum GpuItemType {
        Billboard = 0,
        Polygon = 1,
        RibbonFollow = 2,
        Mesh = 3,
        MeshTrail = 4,
        Life = 5,
        Blink = 6,
        UVSequence = 7,
        Velocity = 8,
        RotateAnim = 9,
        ScaleAnim = 10,
        DepthOperator = 11,
        PlaneCollider = 12,
        WindInfluence = 13,
        ShapeOperator = 14,
        Lightning3D = 15,
        UVScroll = 16,
        Attractor = 17,
        VanishArea3D = 18,
        CustomComputeShader = 19,
        RibbonLength = 20,
        ScreenSpaceEmitter = 21,
        Noise = 22,
        PtVortexelWind = 23,
        ParentOptions = 24,
        RgbCommon = 25,
        RgbWater = 26,
        MaxType = 27,
        None = 4294967295,
    };
}
namespace via::motion::IkJacobian {
    enum InverseMethodType {
        LU = 0,
        Cholesky = 1,
        DebugCompare = 2,
    };
}
namespace app::CH9Em5800Think {
    enum BreakState {
        None = 0,
        FirstBreak = 1,
        SecondBreak = 2,
    };
}
namespace app::Em3000Order::Appear {
    enum Type {
        None = 0,
        Dummy = 1,
        AppearF = 2,
        AppearR = 3,
        AppearL = 4,
        AppearTargetF = 5,
        AppearTargetR = 6,
        AppearTargetL = 7,
        Em8000Appear = 8,
        Chapter3Battle1_Appear = 9,
    };
}
namespace via::network::session {
    enum SearchByFilterOption {
        None = 0,
        GetPerformance = 2,
        AscendingOrderByTime = 4,
        DescendingOrderByTime = 8,
        DisuseRandom = 16,
    };
}
namespace app::DoomsUpdater {
    enum StepType {
        Start = 0,
        Next = 1,
        AfterNext = 2,
    };
}
namespace app::FirstSettingMenu {
    enum Step {
        Main = 0,
        GoNext = 1,
        Option = 2,
        UserSwitchStart = 3,
        UserSwitch = 4,
        UserSwitchChangeEnd = 5,
        Cautionn = 6,
        PrivacyPolicy = 7,
        GDPR = 8,
        GDPR2 = 9,
    };
}
namespace app::EnemyRankParameter {
    enum SpeedRateType {
        None = 0,
        Attack = 1,
        Damage = 2,
        Move = 3,
    };
}
namespace app::OptionMenu {
    enum ItemMode {
        Normal = 0,
        Button = 1,
    };
}
namespace via::navigation::map {
    enum NodeShapeType {
        Undefined = 0,
        Triangle = 1,
    };
}
namespace app::RecordSystem::RecordOrder {
    enum OrderTypeEnum {
        Stamp = 1,
        Decal = 2,
        StampAndDecal = 3,
    };
}
namespace System {
    enum DateTimeKind {
        Unspecified = 0,
        Utc = 1,
        Local = 2,
    };
}
namespace via::network::core {
    enum InterfaceType {
        Unknown = 0,
        Wireless = 1,
        Wired = 2,
    };
}
namespace via::behaviortree {
    enum NetworkNodeSyncPhase {
        Activate = 0,
        Start = 1,
        Manual = 2,
    };
}
namespace via::attribute::RemoteField {
    enum SyncMode {
        Copy = 0,
        Kill = 1,
        Transaction = 2,
        FrequentCopy = 3,
    };
}
namespace app::TableItemExplanation::TableItemSoundController {
    enum Type {
        Start = 0,
        NotStart = 1,
        End = 2,
        Move = 3,
    };
}
namespace app::CH9Em7800ActionController {
    enum WallAttackQueType {
        LeftWall = 0,
        RightWall = 1,
        Ceil = 2,
        Back = 3,
    };
}
namespace via::render {
    enum LodResourceType {
        Global = 0,
        Local = 1,
        Unknown = 2,
    };
}
namespace via {
    enum CurveType {
        FlatHermite = 0,
        Linear = 1,
        Constant = 2,
        Hermite = 3,
        Broken = 4,
        DetailsHermite = 5,
        DetailsBroken = 6,
    };
}
namespace app::Em3000::Action {
    enum ActionNo {
        Idle = 0,
        IdleBattle = 1,
        Rest = 2,
        Appear = 3,
        Walk = 4,
        Turn = 5,
        TurnAttack = 6,
        StepIn = 7,
        Zigzag = 8,
        Branch = 9,
        TurnForWander = 10,
        Attack = 11,
        AttackBack = 12,
        AttackRush = 13,
        AttackKnock = 14,
        AttackToGrapple = 15,
        OpenDoor = 16,
        GetDown = 17,
        Provoke = 18,
        Grapple = 19,
        Damage = 20,
        Dead = 21,
        Chapter3Battle1_Damage = 22,
        Chapter3Battle1_Dead = 23,
        Chapter3Battle1_TurnForGetIntoCar = 24,
        Chapter3Battle1_LookWindow = 25,
        Chapter3Battle1_ArriveTable = 26,
        Em8000_Attack = 27,
        Em8000_ComboAttack = 28,
        Em8000_Damage = 29,
        Em8000_Dead = 30,
        Em8000_Walk = 31,
        Em8000_KneeDown = 32,
        Em8000_Rest = 33,
        Em8000_EngineStop = 34,
        Em8000_BattleIdle = 35,
        Em8000_BreakAxeAttack = 36,
        Em8000_DeadEnd = 37,
        Em8000_WalkTurn = 38,
    };
}
namespace app::Em3002 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Battle = 2,
    };
}
namespace via::render::layer {
    enum ShadowCastStrategy {
        ExplicitStaticMesh = 1,
        ImplicitStaticMesh = 2,
        DynamicMesh = 4,
        Default = 7,
        UsingSST = 6,
        CreateSST = 1,
    };
}
namespace app::Em8001 {
    enum OverrideActionNo {
        Test = 0,
    };
}
namespace via::render::detail::CopyUtility {
    enum DownSampleFilterType {
        DownSample = 0,
        Gaussian = 1,
        Variance = 2,
        AdjacentClamping = 3,
    };
}
namespace app::Em4200::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace via::effect::detail {
    enum EmitterColorOperator {
        Overwrite = 0,
        Multiply = 1,
    };
}
namespace via::navigation {
    enum FilterTarget {
        Default = 0,
        Groups = 1,
    };
}
namespace via::network::error {
    enum CauseCommon {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
    };
}
namespace app::Em3600::Action::PoseChange {
    enum Type {
        Default = 0,
        FourLegStartTurn = 1,
    };
}
namespace via::hid::virtualKeyboard::nsw {
    enum Preset {
        Default = 0,
        Password = 1,
        UserName = 2,
        DownloadCode = 3,
    };
}
namespace via::network::log {
    enum Level {
        Verbose = 0,
        Warning = 1,
        Info = 2,
        Error = 3,
        Fatal = 4,
    };
}
namespace app::fsm::CH8CompareContaminationLevel {
    enum CompareOp {
        Equal = 0,
        NotEqual = 1,
        Less = 2,
        LessEqual = 3,
        Greater = 4,
        GreaterEqual = 5,
    };
}
namespace app::ClockTime {
    enum MeridiemType {
        AM = 0,
        PM = 1,
    };
}
namespace via::clr {
    enum EnumU4 {
        Dummy = 0,
    };
}
namespace System::Runtime::InteropServices {
    enum CharSet {
        None = 1,
        Ansi = 2,
        Unicode = 3,
        Auto = 4,
    };
}
namespace hikako::raytracing::RayTracingManager {
    enum MachineDetailType {
        INVALID = 0,
        PS4Base = 1,
        PS4NEO = 2,
        XB1 = 3,
        XB1X = 4,
        PS5 = 5,
        XBSS = 6,
        XBSX = 7,
        Luna = 8,
    };
}
namespace app::fsm::CH8EnemyStateCheck {
    enum EnemyBoolType {
        None = 0,
        Discovery = 1,
    };
}
namespace app::CH8Em4000ActionController::BattleCondition {
    enum CounterRushResult {
        None = 0,
        TimeOut = 1,
        Stagger = 2,
        BlownAway = 3,
        Dead = 4,
        Fall = 5,
        BlownAwayFalling = 6,
    };
}
namespace app::Em8100::Em8100WwiseMonitoredValue {
    enum GameRank {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        MAX = 10,
    };
}
namespace via::render::SSAOControl {
    enum FilterQuality {
        Low = 0,
        Standard = 1,
    };
}
namespace via::audiorender {
    enum Channel_54ch {
        L = 0,
        R = 1,
        C = 2,
        Ls = 3,
        Rs = 4,
        Ltf = 5,
        Rtf = 6,
        Ltr = 7,
        Rtr = 8,
        Max = 9,
    };
}
namespace System {
    enum NumberStyles {
        None = 0,
        AllowLeadingWhite = 1,
        AllowTrailingWhite = 2,
        AllowLeadingSign = 4,
        AllowTrailingSign = 8,
        AllowParentheses = 16,
        AllowDecimalPoint = 32,
        AllowThousands = 64,
        AllowExponent = 128,
        AllowCurrencySymbol = 256,
        AllowHexSpecifier = 512,
        Integer = 7,
        HexNumber = 515,
        Number = 111,
        Float = 167,
        Currency = 383,
        Any = 511,
    };
}
namespace app::CardGameItem {
    enum DrawType {
        NoUse = 0,
        Normal = 1,
        SP_PerfectDraw = 2,
        SP_Gift = 3,
        SP_Curse = 4,
    };
}
namespace app::AI::AIThinkActionOrderSetParam {
    enum TargetType {
        ApproachTarget = 0,
        WatchTarget = 1,
    };
}
namespace app::RewardData {
    enum RewardType {
        MainGameDifficulty = 0,
        GameMode = 1,
        Weapon = 2,
        Item = 3,
        SkillItem = 4,
        BirthdayGameStage = 5,
    };
}
namespace app::Em4000::Action::Grapple {
    enum Type {
        Bite = 0,
        Mount = 1,
        Slash = 2,
    };
}
namespace via::nnfc::nfp {
    enum DetailState {
        Init = 0,
        Search = 1,
        Active = 2,
        Deactive = 3,
        Mount = 4,
        Unexpected = 5,
        Invalid = 6,
        UnHandled = 7,
    };
}
namespace via::render {
    enum GBufferType {
        Static = 0,
        Dynamic = 1,
        Transparent = 2,
        TransparentDynamic = 3,
        MAX = 4,
    };
}
namespace via::simplewwise {
    enum DeviceTypePS4 {
        None = 0,
        Main = 1,
        MergeToMain = 2,
        Voice = 3,
        Personal = 4,
        PAD = 5,
        BGM = 6,
        Aux = 7,
        DVR = 8,
        SCEAudio3D = 9,
    };
}
namespace via::render {
    enum LodMode {
        Automatic = 0,
        Manual = 1,
        FollowParent = 2,
        TargetObject = 3,
    };
}
namespace via {
    enum CameraType {
        Game = 0,
        Debug = 1,
        Scene = 2,
        SceneXY = 3,
        SceneYZ = 4,
        SceneXZ = 5,
        Preview = 6,
    };
}
namespace via::render {
    enum SemanticType {
        Position = 0,
        Normal = 1,
        Binormal = 2,
        Tangent = 3,
        Texcoord = 4,
        Index = 5,
        Weight = 6,
        Color = 7,
        VertexID = 8,
        Generic = 9,
        InstanceID = 10,
        UniqueUV = 11,
        TessParam = 12,
        GroupID = 13,
    };
}
namespace via::os::detail {
    enum SocketDtlsSubError {
        None = 0,
        ConnectNotReceiveAnyPacket = 1,
    };
}
namespace app::PlayerHandLight {
    enum PowerActionRequest {
        None = 0,
        ForceOn = 1,
        ForceOff = 2,
    };
}
namespace app::AI::AILookAtAgent {
    enum Priority {
        Low = 0,
        Normal = 1,
        High = 2,
    };
}
namespace via::str {
    enum SplitOptionType {
        None = 0,
        RemoveEmptyEntries = 1,
    };
}
namespace via::motion::IkBodyRig {
    enum SetupLevel {
        None = 0,
        Normal = 1,
        Resource = 2,
    };
}
namespace app::AI::AIWanderHelper::StartNodeParamInfo {
    enum DirectionPriority {
        Nothing = 0,
        Front = 1,
        Back = 2,
    };
}
namespace via::hid::VibrationResource {
    enum VibrationResourceType {
        DirectMotor = 0,
        WaveFile = 1,
    };
}
namespace app::CH8Em4000::Action::CH8Strike {
    enum Type {
        Normal = 0,
        Backstep = 1,
        Slash = 2,
    };
}
namespace via::motion {
    enum ChainType {
        Chain = 0,
        Shooter = 1,
    };
}
namespace via::os::asyncTaskQueue {
    enum TaskType {
        ThreadPool = 0,
        Normal = 1,
        Low = 2,
        Save = 3,
        Install = 4,
        Immediate = 5,
        Blocking = 6,
        End = 7,
    };
}
namespace via::audiorender {
    enum OutputPortType {
        Main = 0,
        BGM = 1,
        Personal = 2,
        PadSpeaker = 3,
        Aux = 4,
        Restricted = 5,
        Vibration = 6,
        Max = 7,
    };
}
namespace via::simplewwise {
    enum MultiPositionType {
        SingleSource = 0,
        MultiSources = 1,
        MultiDirections = 2,
    };
}
namespace app::fsm::CH8BuySkill {
    enum SkillID {
        None = 0,
        StepUpNightGoggle = 1,
    };
}
namespace app::DifficultySelectGUI {
    enum SelectStep {
        Select = 0,
        MadInfo = 1,
        MadWarning = 2,
        Decide = 3,
    };
}
namespace via::audiorender {
    enum MultiBandEqParameter {
        UnitNumber = 0,
        UnitEnable = 1,
        FilterType = 2,
        Frequency = 3,
        Q = 4,
        GainDb = 5,
    };
}
namespace via::motion::RetargetRig {
    enum EffectorTarget {
        Heal = 0,
        Toe = 1,
    };
}
namespace app::ItemHereIcon {
    enum IconTypeDef {
        Normal = 0,
        Gorgeous = 1,
    };
}
namespace via::render {
    enum SparseShadowTreeResolution {
        SparseShadowTreeResolution_4K = 4,
        SparseShadowTreeResolution_8K = 8,
        SparseShadowTreeResolution_16K = 16,
        SparseShadowTreeResolution_24K = 24,
        SparseShadowTreeResolution_32K = 32,
        SparseShadowTreeResolution_64K = 64,
        SparseShadowTreeResolution_AUTO = 0,
    };
}
namespace via::motion::IkDog {
    enum FootLockMode {
        Auto = 0,
        SemiAuto = 1,
    };
}
namespace app::CH8Em4200::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
        EventAttack = 3,
    };
}
namespace app::PlayerCamera {
    enum RotationDirectionType {
        Normal = 0,
        InvertHorizontal = 1,
        InvertVertical = 2,
        InvertAll = 3,
    };
}
namespace app::Em3002::Action::Appear {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
    };
}
namespace via::motion::detail::MotionFsm2TransitionData {
    enum EndType {
        None = 0,
        EndOfMotion = 1,
        ExitFrame = 2,
        ExitFrameFromEnd = 3,
        SyncPoint = 4,
        SyncPointFromEnd = 5,
        ExitNormalizedTime = 6,
        ExitSyncTime = 7,
    };
}
namespace app::Cp7PCLockNumber {
    enum State {
        Normal = 0,
        EndNormal = 1,
        StartError = 2,
        Error = 3,
        EndError = 4,
        Max = 5,
    };
}
namespace app::Cp7MainMenu {
    enum Step {
        Main = 0,
        Sub = 1,
        Cutin = 2,
        Quit = 3,
        Continue = 4,
        NewGame = 5,
        Survival = 6,
        Achievement = 7,
        Survival1 = 8,
        Survival2 = 9,
        Start = 10,
    };
}
namespace via::gui {
    enum EffectAlphaType {
        Independence = 0,
        MultiplyTextColorAlpha = 1,
    };
}
namespace via::motion::ChainDynamicCollisionNode {
    enum ShapeType {
        Sphere = 0,
        Capsule = 1,
        OBB = 2,
        Plane = 3,
        TaperedCapsule = 4,
    };
}
namespace app::CH9InstallationWp1900 {
    enum eInstallationType {
        OnGround = 0,
        OnWater = 1,
        OnShallowWater = 2,
        OnBrokenFloor = 3,
        OnBoat = 4,
    };
}
namespace app::Havok::ClothAnimationColtroller {
    enum PhysicsGroup {
        None = 0,
        Group0 = 1,
        Group1 = 2,
        Group2 = 4,
        Group3 = 8,
    };
}
namespace app::CH8Em4500ActionController::BattleCondition {
    enum Status {
        Fast = 0,
        Second = 1,
    };
}
namespace via::gui {
    enum ViewType {
        Screen = 0,
        World = 1,
    };
}
namespace via::os {
    enum MemoryBus {
        WB = 256,
        WC = 512,
        Default = 256,
    };
}
namespace via::render::detail {
    enum PrimitiveVfxShaderInputLayout {
        Billboard3DIL = 0,
        Billboard3DCutoutIL = 1,
        Billboard3DTexUnitIL = 2,
        Billboard2DIL = 3,
        Billboard2DTexUnitIL = 4,
        PolygonIL = 5,
        RibbonIL = 6,
        Billboard2DCutoutIL = 7,
        RibbonTexUnitIL = 8,
        UnusedIL = 9,
        Billboard3DNormIL = 10,
        Billboard3DCutoutNormIL = 11,
        Billboard3DTexUnitNormIL = 12,
        RibbonNormIL = 13,
        RibbonTexUnitNormIL = 14,
        PolygonCutoutIL = 15,
        Num = 16,
    };
}
namespace app::LightConditionManager {
    enum ProbesTypeEnum {
        InSide = 0,
        OutSide = 1,
        Max = 2,
    };
}
namespace via::effect::gpgpu::detail::GpgpuResource {
    enum ComputeShaderType {
        EmitCS = 0,
        EmitShapeOperatorCS = 1,
        EmitOnMeshContourCS = 2,
        EmitOnMeshContourCS_ColorMap = 3,
        EmitOnMeshContourCS_MaskMap = 4,
        EmitOnMeshContourCS_ColorMaskMap = 5,
        EmitOnMeshContourCS_DirectionalField = 6,
        EmitOnMeshContourCS_DirectionalFieldMaskMap = 7,
        EmitOnMeshNormalContourCS = 8,
        EmitOnMeshNormalContourCS_ColorMap = 9,
        EmitOnMeshNormalContourCS_MaskMap = 10,
        EmitOnMeshNormalContourCS_ColorMaskMap = 11,
        EmitScreenCS = 12,
        SingleEmitCS = 13,
        SingleEmitShapeOperatorCS = 14,
        SingleEmitOnMeshContourCS = 15,
        SingleEmitOnMeshContourCS_ColorMap = 16,
        SingleEmitOnMeshContourCS_MaskMap = 17,
        SingleEmitOnMeshContourCS_ColorMaskMap = 18,
        SingleEmitOnMeshContourCS_DirectionalField = 19,
        SingleEmitOnMeshContourCS_DirectionalFieldMaskMap = 20,
        SingleEmitOnMeshNormalContourCS = 21,
        SingleEmitOnMeshNormalContourCS_ColorMap = 22,
        SingleEmitOnMeshNormalContourCS_MaskMap = 23,
        SingleEmitOnMeshNormalContourCS_ColorMaskMap = 24,
        SingleEmitScreenCS = 25,
        InitializeParticleItemCS = 26,
        SingleUpdateCS = 27,
        UpdateCS = 28,
        DefaultFirstUpdateCS = 29,
        DefaultSecondUpdateCS = 30,
        DefaultThirdUpdateCS = 31,
        DefaultFourthUpdateCS = 32,
        SingleVolumeFieldCS = 33,
        UpdateVolumeFieldCS = 34,
        DefaultFirstUpdateVolumeFieldCS = 35,
        DefaultSecondUpdateVolumeFieldCS = 36,
        DefaultThirdUpdateVolumeFieldCS = 37,
        DefaultFourthUpdateVolumeFieldCS = 38,
        SingleUpdateSimpleVolumeFieldCS = 39,
        UpdateSimpleVolumeFieldCS = 40,
        DefaultFirstUpdateSimpleVolumeFieldCS = 41,
        DefaultSecondUpdateSimpleVolumeFieldCS = 42,
        DefaultThirdUpdateSimpleVolumeFieldCS = 43,
        DefaultFourthUpdateSimpleVolumeFieldCS = 44,
        SingleUpdateMeshContourCS = 45,
        UpdateMeshContourCS = 46,
        DefaultFirstUpdateMeshContourCS = 47,
        DefaultSecondUpdateMeshContourCS = 48,
        DefaultThirdUpdateMeshContourCS = 49,
        DefaultFourthUpdateMeshContourCS = 50,
        SingleUpdateMeshContourDirectionalFieldCS = 51,
        UpdateMeshContourDirectionalFieldCS = 52,
        DefaultFirstUpdateMeshContourDirectionalFieldCS = 53,
        DefaultSecondUpdateMeshContourDirectionalFieldCS = 54,
        DefaultThirdUpdateMeshContourDirectionalFieldCS = 55,
        DefaultFourthUpdateMeshContourDirectionalFieldCS = 56,
        SingleUpdateMeshContourMaskDirectionalFieldCS = 57,
        UpdateMeshContourMaskDirectionalFieldCS = 58,
        DefaultFirstUpdateMeshContourMaskDirectionalFieldCS = 59,
        DefaultSecondUpdateMeshContourMaskDirectionalFieldCS = 60,
        DefaultThirdUpdateMeshContourMaskDirectionalFieldCS = 61,
        DefaultFourthUpdateMeshContourMaskDirectionalFieldCS = 62,
        SingleUpdateMeshContourVolumeFieldCS = 63,
        UpdateMeshContourVolumeFieldCS = 64,
        DefaultFirstUpdateMeshContourVolumeFieldCS = 65,
        DefaultSecondUpdateMeshContourVolumeFieldCS = 66,
        DefaultThirdUpdateMeshContourVolumeFieldCS = 67,
        DefaultFourthUpdateMeshContourVolumeFieldCS = 68,
        SingleUpdateMeshContourSimpleVolumeFieldCS = 69,
        UpdateMeshContourSimpleVolumeFieldCS = 70,
        DefaultFirstUpdateMeshContourSimpleVolumeFieldCS = 71,
        DefaultSecondUpdateMeshContourSimpleVolumeFieldCS = 72,
        DefaultThirdUpdateMeshContourSimpleVolumeFieldCS = 73,
        DefaultFourthUpdateMeshContourSimpleVolumeFieldCS = 74,
        SingleUpdateVectorFieldCS = 75,
        UpdateVectorFieldCS = 76,
        DefaultFirstUpdateVectorFieldCS = 77,
        DefaultSecondUpdateVectorFieldCS = 78,
        DefaultThirdUpdateVectorFieldCS = 79,
        DefaultFourthUpdateVectorFieldCS = 80,
        SingleUpdateSimpleVectorFieldCS = 81,
        UpdateSimpleVectorFieldCS = 82,
        DefaultFirstUpdateSimpleVectorFieldCS = 83,
        DefaultSecondUpdateSimpleVectorFieldCS = 84,
        DefaultThirdUpdateSimpleVectorFieldCS = 85,
        DefaultFourthUpdateSimpleVectorFieldCS = 86,
        SingleUpdateMeshContourVectorFieldCS = 87,
        UpdateMeshContourVectorFieldCS = 88,
        DefaultFirstUpdateMeshContourVectorFieldCS = 89,
        DefaultSecondUpdateMeshContourVectorFieldCS = 90,
        DefaultThirdUpdateMeshContourVectorFieldCS = 91,
        DefaultFourthUpdateMeshContourVectorFieldCS = 92,
        SingleUpdateMeshContourSimpleVectorFieldCS = 93,
        UpdateMeshContourSimpleVectorFieldCS = 94,
        DefaultFirstUpdateMeshContourSimpleVectorFieldCS = 95,
        DefaultSecondUpdateMeshContourSimpleVectorFieldCS = 96,
        DefaultThirdUpdateMeshContourSimpleVectorFieldCS = 97,
        DefaultFourthUpdateMeshContourSimpleVectorFieldCS = 98,
        SingleUpdateVectorFieldCSWithSmoothing = 99,
        UpdateVectorFieldCSWithSmoothing = 100,
        DefaultFirstUpdateVectorFieldCSWithSmoothing = 101,
        DefaultSecondUpdateVectorFieldCSWithSmoothing = 102,
        DefaultThirdUpdateVectorFieldCSWithSmoothing = 103,
        DefaultFourthUpdateVectorFieldCSWithSmoothing = 104,
        SingleUpdateSimpleVectorFieldCSWithSmoothing = 105,
        UpdateSimpleVectorFieldCSWithSmoothing = 106,
        DefaultFirstUpdateSimpleVectorFieldCSWithSmoothing = 107,
        DefaultSecondUpdateSimpleVectorFieldCSWithSmoothing = 108,
        DefaultThirdUpdateSimpleVectorFieldCSWithSmoothing = 109,
        DefaultFourthUpdateSimpleVectorFieldCSWithSmoothing = 110,
        SingleUpdateMeshContourVectorFieldCSWithSmoothing = 111,
        UpdateMeshContourVectorFieldCSWithSmoothing = 112,
        DefaultFirstUpdateMeshContourVectorFieldCSWithSmoothing = 113,
        DefaultSecondUpdateMeshContourVectorFieldCSWithSmoothing = 114,
        DefaultThirdUpdateMeshContourVectorFieldCSWithSmoothing = 115,
        DefaultFourthUpdateMeshContourVectorFieldCSWithSmoothing = 116,
        SingleUpdateMeshContourSimpleVectorFieldCSWithSmoothing = 117,
        UpdateMeshContourSimpleVectorFieldCSWithSmoothing = 118,
        DefaultFirstUpdateMeshContourSimpleVectorFieldCSWithSmoothing = 119,
        DefaultSecondUpdateMeshContourSimpleVectorFieldCSWithSmoothing = 120,
        DefaultThirdUpdateMeshContourSimpleVectorFieldCSWithSmoothing = 121,
        DefaultFourthUpdateMeshContourSimpleVectorFieldCSWithSmoothing = 122,
        MaxType = 123,
    };
}
namespace app::Em3000::Action {
    enum ActionMid {
        StepInStraight = 0,
        StepInSide = 1,
        StepInThrust = 2,
        StepInGrab = 3,
        Num = 4,
        Non = 99,
    };
}
namespace app::GrappleBase::SafeSpaceParam {
    enum BaseObjectType {
        Default = 0,
        PlayerY = 1,
    };
}
namespace app::fsm::CH8CheckEm4500Action {
    enum CompareTable {
        Equal = 0,
        NotEqual = 1,
    };
}
namespace via::gui::renderer::GUIPrimitiveResource {
    enum ShaderType {
        GUIPoly2D = 0,
        GUIPoly2DMask = 1,
        GUIPoly2DMaskReverse = 2,
        GUIPoly2DAdd = 3,
        GUIPoly2DAddMask = 4,
        GUIPoly2DAddMaskReverse = 5,
        GUIPoly2DDetone = 6,
        GUIPoly2DMaskDetone = 7,
        GUIPoly2DMaskReverseDetone = 8,
        GUIPoly2DAddDetone = 9,
        GUIPoly2DAddMaskDetone = 10,
        GUIPoly2DAddMaskReverseDetone = 11,
        PrimitiveShaderType_GUIPoly2DStencil = 12,
        PrimitiveShaderType_GUIPoly2DAddStencil = 13,
        PrimitiveShaderType_GUIPoly2DPStencil = 14,
        PrimitiveShaderType_GUIPoly2DAddPStencil = 15,
        GUIGlyph2D = 16,
        GUIGlyph2DMask = 17,
        GUIGlyph2DMaskReverse = 18,
        GUIGlyph2DAdd = 19,
        GUIGlyph2DAddMask = 20,
        GUIGlyph2DAddMaskReverse = 21,
        GUIGlyph2DDetone = 22,
        GUIGlyph2DMaskDetone = 23,
        GUIGlyph2DMaskReverseDetone = 24,
        GUIGlyph2DAddDetone = 25,
        GUIGlyph2DAddMaskDetone = 26,
        GUIGlyph2DAddMaskReverseDetone = 27,
        PrimitiveShaderType_GUIGlyph2DStencil = 28,
        PrimitiveShaderType_GUIGlyph2DAddStencil = 29,
        PrimitiveShaderType_GUIGlyph2DPStencil = 30,
        PrimitiveShaderType_GUIGlyph2DAddPStencil = 31,
        GUIPoly3D = 32,
        GUIPoly3DTest = 33,
        GUIPoly3DMask = 34,
        GUIPoly3DMaskTest = 35,
        GUIPoly3DMaskReverse = 36,
        GUIPoly3DMaskReverseTest = 37,
        GUIPoly3DAdd = 38,
        GUIPoly3DAddTest = 39,
        GUIPoly3DAddMask = 40,
        GUIPoly3DAddMaskTest = 41,
        GUIPoly3DAddMaskReverse = 42,
        GUIPoly3DAddMaskReverseTest = 43,
        GUIPoly3DDetone = 44,
        GUIPoly3DTestDetone = 45,
        GUIPoly3DMaskDetone = 46,
        GUIPoly3DMaskTestDetone = 47,
        GUIPoly3DMaskReverseDetone = 48,
        GUIPoly3DMaskReverseTestDetone = 49,
        GUIPoly3DAddDetone = 50,
        GUIPoly3DAddTestDetone = 51,
        GUIPoly3DAddMaskDetone = 52,
        GUIPoly3DAddMaskTestDetone = 53,
        GUIPoly3DAddMaskReverseDetone = 54,
        GUIPoly3DAddMaskReverseTestDetone = 55,
        GUIPoly3DTestStencilForDepth = 56,
        GUIPoly3DMaskTestStencilForDepth = 57,
        GUIPoly3DMaskReverseTestStencilForDepth = 58,
        GUIPoly3DAddTestStencilForDepth = 59,
        GUIPoly3DAddMaskTestStencilForDepth = 60,
        GUIPoly3DAddMaskReverseTestStencilForDepth = 61,
        GUIPoly3DTestCorrection = 62,
        GUIGlyph3D = 63,
        GUIGlyph3DTest = 64,
        GUIGlyph3DMask = 65,
        GUIGlyph3DMaskTest = 66,
        GUIGlyph3DMaskReverse = 67,
        GUIGlyph3DMaskReverseTest = 68,
        GUIGlyph3DAdd = 69,
        GUIGlyph3DAddTest = 70,
        GUIGlyph3DAddMask = 71,
        GUIGlyph3DAddMaskTest = 72,
        GUIGlyph3DAddMaskReverse = 73,
        GUIGlyph3DAddMaskReverseTest = 74,
        GUIGlyph3DDetone = 75,
        GUIGlyph3DTestDetone = 76,
        GUIGlyph3DMaskDetone = 77,
        GUIGlyph3DMaskTestDetone = 78,
        GUIGlyph3DMaskReverseDetone = 79,
        GUIGlyph3DMaskReverseTestDetone = 80,
        GUIGlyph3DAddDetone = 81,
        GUIGlyph3DAddTestDetone = 82,
        GUIGlyph3DAddMaskDetone = 83,
        GUIGlyph3DAddMaskTestDetone = 84,
        GUIGlyph3DAddMaskReverseDetone = 85,
        GUIGlyph3DAddMaskReverseTestDetone = 86,
        GUIGlyph3DTestStencilForDepth = 87,
        GUIGlyph3DMaskTestStencilForDepth = 88,
        GUIGlyph3DMaskReverseTestStencilForDepth = 89,
        GUIGlyph3DAddTestStencilForDepth = 90,
        GUIGlyph3DAddMaskTestStencilForDepth = 91,
        GUIGlyph3DAddMaskReverseTestStencilForDepth = 92,
        GUIGlyph3DTestCorrection = 93,
        GUIPolyPers = 94,
        GUIPolyPersTest = 95,
        GUIPolyPersMask = 96,
        GUIPolyPersMaskTest = 97,
        GUIPolyPersMaskReverse = 98,
        GUIPolyPersMaskReverseTest = 99,
        GUIPolyPersAdd = 100,
        GUIPolyPersAddTest = 101,
        GUIPolyPersAddMask = 102,
        GUIPolyPersAddMaskTest = 103,
        GUIPolyPersAddMaskReverse = 104,
        GUIPolyPersAddMaskReverseTest = 105,
        GUIGlyphPers = 106,
        GUIGlyphPersTest = 107,
        GUIGlyphPersMask = 108,
        GUIGlyphPersMaskTest = 109,
        GUIGlyphPersMaskReverse = 110,
        GUIGlyphPersMaskReverseTest = 111,
        GUIGlyphPersAdd = 112,
        GUIGlyphPersAddTest = 113,
        GUIGlyphPersAddMask = 114,
        GUIGlyphPersAddMaskTest = 115,
        GUIGlyphPersAddMaskReverse = 116,
        GUIGlyphPersAddMaskReverseTest = 117,
        GUIPoly2DMaskWrite = 118,
        GUIPoly3DMaskWrite = 119,
        GUIPoly3DMaskWriteTest = 120,
        GUIPolyPersMaskWrite = 121,
        GUIPolyPersMaskWriteTest = 122,
        GUIGlyph2DMaskWrite = 123,
        GUIGlyph3DMaskWrite = 124,
        GUIGlyph3DMaskWriteTest = 125,
        GUIGlyphPersMaskWrite = 126,
        GUIGlyphPersMaskWriteTest = 127,
        GUIPoly2DMaskWriteBlend2 = 128,
        GUIPoly3DMaskWriteBlend2 = 129,
        GUIPoly3DMaskWriteTestBlend2 = 130,
        GUIPolyPersMaskWriteBlend2 = 131,
        GUIPolyPersMaskWriteTestBlend2 = 132,
        GUIGlyph2DMaskWriteBlend2 = 133,
        GUIGlyph3DMaskWriteBlend2 = 134,
        GUIGlyph3DMaskWriteTestBlend2 = 135,
        GUIGlyphPersMaskWriteBlend2 = 136,
        GUIGlyphPersMaskWriteTestBlend2 = 137,
        GUIPoly2DMaskWriteBlend3 = 138,
        GUIPoly3DMaskWriteBlend3 = 139,
        GUIPoly3DMaskWriteTestBlend3 = 140,
        GUIPolyPersMaskWriteBlend3 = 141,
        GUIPolyPersMaskWriteTestBlend3 = 142,
        GUIGlyph2DMaskWriteBlend3 = 143,
        GUIGlyph3DMaskWriteBlend3 = 144,
        GUIGlyph3DMaskWriteTestBlend3 = 145,
        GUIGlyphPersMaskWriteBlend3 = 146,
        GUIGlyphPersMaskWriteTestBlend3 = 147,
        GUIGlyphGlow2D = 148,
        GUIGlyphGlow2DMask = 149,
        GUIGlyphGlow2DMaskReverse = 150,
        GUIGlyphGlow2DAdd = 151,
        GUIGlyphGlow2DAddMask = 152,
        GUIGlyphGlow2DAddMaskReverse = 153,
        GUIGlyphGlow2DDetone = 154,
        GUIGlyphGlow2DMaskDetone = 155,
        GUIGlyphGlow2DMaskReverseDetone = 156,
        GUIGlyphGlow2DAddDetone = 157,
        GUIGlyphGlow2DAddMaskDetone = 158,
        GUIGlyphGlow2DAddMaskReverseDetone = 159,
        GUIGlyphGlow3D = 160,
        GUIGlyphGlow3DTest = 161,
        GUIGlyphGlow3DMask = 162,
        GUIGlyphGlow3DMaskTest = 163,
        GUIGlyphGlow3DMaskReverse = 164,
        GUIGlyphGlow3DMaskReverseTest = 165,
        GUIGlyphGlow3DAdd = 166,
        GUIGlyphGlow3DAddTest = 167,
        GUIGlyphGlow3DAddMask = 168,
        GUIGlyphGlow3DAddMaskTest = 169,
        GUIGlyphGlow3DAddMaskReverse = 170,
        GUIGlyphGlow3DAddMaskReverseTest = 171,
        GUIGlyphGlow3DDetone = 172,
        GUIGlyphGlow3DTestDetone = 173,
        GUIGlyphGlow3DMaskDetone = 174,
        GUIGlyphGlow3DMaskTestDetone = 175,
        GUIGlyphGlow3DMaskReverseDetone = 176,
        GUIGlyphGlow3DMaskReverseTestDetone = 177,
        GUIGlyphGlow3DAddDetone = 178,
        GUIGlyphGlow3DAddTestDetone = 179,
        GUIGlyphGlow3DAddMaskDetone = 180,
        GUIGlyphGlow3DAddMaskTestDetone = 181,
        GUIGlyphGlow3DAddMaskReverseDetone = 182,
        GUIGlyphGlow3DAddMaskReverseTestDetone = 183,
        GUIGlyphGlowPers = 184,
        GUIGlyphGlowPersTest = 185,
        GUIGlyphGlowPersMask = 186,
        GUIGlyphGlowPersMaskTest = 187,
        GUIGlyphGlowPersMaskReverse = 188,
        GUIGlyphGlowPersMaskReverseTest = 189,
        GUIGlyphGlowPersAdd = 190,
        GUIGlyphGlowPersAddTest = 191,
        GUIGlyphGlowPersAddMask = 192,
        GUIGlyphGlowPersAddMaskTest = 193,
        GUIGlyphGlowPersAddMaskReverse = 194,
        GUIGlyphGlowPersAddMaskReverseTest = 195,
        Max = 196,
    };
}
namespace app::Richpresence {
    enum DLCContextType {
        DLC1 = 0,
        DLC2 = 1,
        Invalid = -1,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum VFXResolution {
        Full = 0,
        Half = 1,
        Quarter = 2,
    };
}
namespace via::hid::VrTracker {
    enum ResultType {
        Predicted = 0,
        Raw = 1,
        Default = 0,
    };
}
namespace via::gui {
    enum MaterialParamType {
        Unknown = 0,
        Float = 1,
        Float4 = 2,
        Color = 3,
        Texture = 4,
    };
}
namespace via::sound {
    enum SoundCurveYDbValueType {
        Linear0to1 = 0,
        DbLinear0to1 = 1,
        Linear0toInf = 2,
        DbLinear0toInf = 3,
    };
}
namespace app::Em3102::Action::Grapple {
    enum Type {
        Finish = 0,
    };
}
namespace via::vr::psCamera {
    enum PSCameraStartResult {
        OK = 1,
        Started = 2,
        ErrorConfigType = 2147483649,
        ErrorInternal = 2147487744,
    };
}
namespace via::hid {
    enum DeviceKind {
        Unknown = 0,
        GamePad = 1,
        Keyboard = 2,
        Mouse = 3,
        Camera = 4,
        HMD = 5,
        TouchScreen = 6,
        VirtualKeyboard = 7,
    };
}
namespace via::render::RenderConfig {
    enum VRSType {
        Off = 0,
        Balanced = 1,
        Performance = 2,
    };
}
namespace via::motion::IkLeg2 {
    enum StretchDampingMode {
        None = 0,
        EaseOutQuad = 1,
    };
}
namespace via::gui::MessageAnalyzer {
    enum Error {
        None = 0,
        TagAlloc = 1,
        InvalidChar = 2,
        InvalidFont = 4,
        InvalidTag = 8,
        RangeOverW = 16,
        RangeOverH = 32,
        InvalidState = 64,
    };
}
namespace via::dynamics {
    enum PositionType {
        Normal = 0,
        Previous = 1,
        Skinning = 2,
    };
}
namespace via::os {
    enum IpAddressType {
        Default = 0,
        V4 = 1,
        V6 = 2,
    };
}
namespace via::motion::IkDamageAction {
    enum Calculation {
        Default = 0,
        AddDirection = 1,
    };
}
namespace via::render::LightProbes {
    enum LightProbesMerge {
        Disable = 0,
        A = 1,
        B = 2,
        AB = 3,
        C = 4,
        AC = 5,
        BC = 6,
        ABC = 7,
        D = 8,
        E = 16,
        F = 32,
    };
}
namespace via {
    enum ShareServiceCaps {
        None = 0,
        ScreenShot = 1,
        ScreenShotControl = 2,
        ScreenShotRequest = 4,
        ScreenShotOverlayImage = 8,
        ScreenShotChangeOverlayImage = 16,
        VideoRecording = 32,
        VideoRecordingControl = 64,
        VideoRecordingRequest = 128,
        VideoRecordingOverlayImage = 256,
        VideoRecordingChangeOverlayImage = 512,
        GameLiveStreaming = 1024,
        GameLiveStreamingControl = 2048,
        GameLiveStreamingRequest = 4096,
        GameLiveStreamingStatusWatching = 8192,
        SharePlay = 16384,
        SharePlayControl = 32768,
        SharePlayStatusWatching = 65536,
        ShareUtility = 131072,
        ScreenShotShowFiles = 262144,
    };
}
namespace app::OptionMenu {
    enum OnOff {
        On = 0,
        Off = 1,
    };
}
namespace via::render {
    enum ShadowResolution {
        Lowest = 384,
        Low = 512,
        Normal = 768,
        High = 1024,
        Highest = 2048,
        Ultra = 4096,
    };
}
namespace via::motion::MotionBankDataSolver {
    enum SetupState {
        None = 0,
        Reload = 1,
        Setuped = 2,
    };
}
namespace app::CH8TramPuzzle {
    enum ColliderIndex {
        Marker_Front = 2,
        Marker_Back = 3,
        Sensor = 4,
    };
}
namespace app::CH9Em6400::Evaluator::CheckRangeFromJoint {
    enum Type {
        Simple = 0,
        NormalizedRateScore = 1,
        RateScore = 2,
    };
}
namespace via::navigation::FilterInfo {
    enum TraceDestination {
        Optimize = 0,
        PortalCenter = 1,
        NodeCenterWithExtraLink = 2,
    };
}
namespace app::EPVDataBase {
    enum RotateBase {
        ParentJoint = 0,
        ModelNull = 1,
    };
}
namespace app::CH8LastBattleMessageData {
    enum ExecuteIDTable {
        Stun = 0,
        Shots6 = 1,
        Air10 = 2,
        Air30 = 3,
        Air50 = 4,
        Time180_360_540_720 = 5,
        Health15 = 6,
        GeroBeam = 7,
        Jump = 8,
        Swoon = 9,
        UserShots = 10,
        UserAir = 11,
        UserTime = 12,
        UserHealth = 13,
    };
}
namespace via::motion::CameraAnimation {
    enum AnimType {
        Trans = 1,
        Quat = 2,
        Fov = 4,
        Dist = 8,
    };
}
namespace via::render {
    enum VFXResolutionCompose {
        SimpleMagnify = 0,
        Biliner = 1,
        Debug = 2,
    };
}
namespace via::clr {
    enum ParamFlag {
        In = 1,
        Out = 2,
        Lcid = 4,
        Retval = 8,
        Optional = 16,
        HasDefault = 4096,
        HasFieldMarshal = 8192,
    };
}
namespace via::render {
    enum FenceState {
        Invalidate = 4294967295,
        DoNotWait = 4294967294,
        UAVSync = 4294967293,
    };
}
namespace app::Em8950Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em5520 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace via::navigation::PathObjectOperator {
    enum ForwardResult {
        None = 0,
        Forward = 1,
        End = 2,
    };
}
namespace app::CH8Em4400BulletBaby {
    enum Status {
        Enable = 0,
        Desable = 1,
    };
}
namespace app::Em3100::Action::DoorOpen {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace via::network::storage {
    enum Type {
        None = 0,
        Title = 1,
        User = 2,
    };
}
namespace via::network::wrangler {
    enum ProviderLatency {
        Undefined = 0,
        Normal = 1,
        RealTime = 2,
    };
}
namespace app::CH9PlayerMessageController {
    enum Type {
        EatInsect = 0,
        Sneaking = 1,
        SneakKill = 2,
        MoldeadFirstContact = 3,
        OutOfShotgunAmmo = 4,
        FatAppearance = 5,
        SurprisedGauntlet = 6,
        Damage_ShipBattle1 = 7,
        Damage_ShipBattle2 = 8,
        Damage_ShipBattle3 = 9,
        Dying_LastBattle1 = 10,
        Dying_LastBattle2 = 11,
        GrappleStart = 12,
        GrappleEnd = 13,
    };
}
namespace app::fsm::CH8CheckFront2::TargetStatus {
    enum JointIndexTable {
        root = 0,
        Head = 1,
        Chest = 2,
        Stomach = 3,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData {
    enum TangentType {
        Auto = 0,
        Spline = 1,
        Linear = 2,
        Fast = 3,
        Slow = 4,
        Flat = 5,
        Step = 6,
        StepNext = 7,
        Fixed = 8,
        Clamped = 9,
        Plateau = 10,
    };
}
namespace via::render {
    enum HazeCompositorResolution {
        Low = 0,
        Mid = 1,
        High = 2,
    };
}
namespace via::motion::IkDamageAction {
    enum CalculationBendRotation {
        Parent = 0,
        Root = 1,
    };
}
namespace via::hid::mouse {
    enum ManipulatorClientDefaultTypeDev {
        WindowMessage = 3,
        GlobalParameter = 4,
    };
}
namespace app::Em8000::Action::Em8000KneeDown {
    enum State {
        None = 0,
        Start = 1,
        NoMotionStart = 2,
        Loop = 3,
        End = 4,
        EndAttack = 5,
        Attack = 6,
        Damage = 7,
        CancelEnd = 8,
        Invalid = 9,
    };
}
namespace app::TitleSubMenu {
    enum Mode {
        Invalid = 0,
        Normal = 1,
        VR = 2,
        VR_Dummy = 3,
    };
}
namespace app::EnemyVariablesHash {
    enum Tag {
        BATTLE_CounterableForGrapple = 0,
        BATTLE_ResistableForGrapple = 1,
        BATTLE_CounterableBombForGrapple = 2,
        BATTLE_IsStaySafeZone = 3,
    };
}
namespace appFSM::CH8ArmBombTimerControl {
    enum RequestTypeEnum {
        Start = 0,
        Stop = 1,
        Reset = 2,
    };
}
namespace via::behaviortree {
    enum ExecLine {
        LINE0 = 0,
        LINE1 = 1,
        LINE2 = 2,
    };
}
namespace app::OptionMenu {
    enum RotTypeIndex {
        Incremental = 0,
        Angular = 1,
    };
}
namespace via {
    enum GameIntentType {
        Unknown = 0,
        JoinSession = 1,
        LaunchActivity = 2,
        LaunchMultiplayerActivity = 3,
    };
}
namespace via::effect::lensflare {
    enum TranslationType {
        Free = 0,
        Horizontal = 1,
        Vertical = 2,
        Custom = 3,
    };
}
namespace via::network::error {
    enum CauseWebSocketClient {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        HandshakeFailed = 129,
        IllegalResponse = 130,
        DisconnectByServer = 131,
        SocketBindFailed = 132,
        SocketConnectFailed = 133,
        SocketGetOption = 134,
        SocketInitializeFailed = 135,
        SocketNotProvided = 136,
        SocketSendPeer = 137,
        SocketSendSelf = 138,
        SocketRecvPeer = 139,
        SocketRecvSelf = 140,
    };
}
namespace via::userdata {
    enum TypeKind {
        Unknown = 0,
        Enum = 1,
        Boolean = 2,
        Int8 = 3,
        Uint8 = 4,
        Int16 = 5,
        Uint16 = 6,
        Int32 = 7,
        Uint32 = 8,
        Int64 = 9,
        Uint64 = 10,
        Single = 11,
        Double = 12,
        C8 = 13,
        C16 = 14,
        String = 15,
        Trigger = 16,
        Vec2 = 17,
        Vec3 = 18,
        Vec4 = 19,
        Matrix = 20,
        GUID = 21,
        Num = 22,
    };
}
namespace via::hid::gamePlayer {
    enum AutoPlayFlag {
        None = 0,
        SkipDialog = 2,
        AutoAssign = 4,
        AutoCreateVirtualDevice = 8,
    };
}
namespace via::motion::IkLeg {
    enum EffectorCtrl {
        None = 0,
        LocalOffset = 1,
        WorldOffset = 2,
        Local = 3,
        World = 4,
    };
}
namespace app::CH9Em5850::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        ReturnMove = 2,
        GotoTarget = 3,
        Attack = 4,
        Leave = 5,
        VolumeSpaceMoveToTarget = 6,
        VolumeSpaceMoveToPosition = 7,
        Dead = 8,
        Appear = 9,
        Suspend = 10,
        DamageWait = 11,
        NearDoor = 12,
        NearDoorClose = 13,
        NearDoorOpen = 14,
        AttackAction = 15,
        LeaveAction = 16,
        DeadAction = 17,
        AppearAction = 18,
        IdleAction = 19,
        SuspendAction = 20,
        Warp1 = 21,
        Warp2 = 22,
    };
}
namespace app::Em3000::Action {
    enum ActionZero {
        StepBack = 0,
        GrappleHeadButt = 1,
        GrappleKnee = 2,
        GrappleThrow = 3,
        Non = 99,
    };
}
namespace via::render::LightProbes {
    enum LightProbesType {
        Indoor = 0,
        Outdoor = 1,
        Sparse = 2,
    };
}
namespace via::network::session {
    enum SearchByUniqueIdOption {
        None = 0,
    };
}
namespace via::navigation::FilterInfo {
    enum FilterType {
        Cost = 0,
        NotWalkable = 1,
        Walkable = 2,
        Through = 3,
    };
}
namespace via::render::Stamp {
    enum RasterMode {
        Standard = 0,
        Wireframe = 2,
        NeighborSample = 3,
    };
}
namespace via::render::PrimitiveMaterial {
    enum SolidExpensiveShader {
        BillboardMaterial = 0,
        RibbonMaterial = 1,
        PolygonMaterial = 2,
        PolygonStripMaterial = 3,
        BillboardMaterialWithAttributeAndCustoms = 4,
        RibbonMaterialWithAttributeAndCustoms = 5,
        PolygonMaterialWithAttributeAndCustoms = 6,
        PolygonStripMaterialWithAttributeAndCustoms = 7,
        Max = 8,
    };
}
namespace via::movie {
    enum BlendMode {
        Normal = 0,
        Add = 1,
    };
}
namespace app::Em3001::Action::OpenDoor {
    enum Type {
        Normal = 0,
        Kick = 1,
    };
}
namespace app::CH9EverywhereMissionBase {
    enum Progress {
        Idle = 0,
        Start = 1,
        End = 2,
    };
}
namespace via::effect::lensflare {
    enum RotationOrder {
        XYZ = 0,
        XZY = 1,
        YXZ = 2,
        YZX = 3,
        ZXY = 4,
        ZYX = 5,
    };
}
namespace app::Em8000::Em8000Define::WeaponGroup {
    enum Group {
        INVALID = -1,
        None = 0,
        Handgun = 1,
        Shotgun = 2,
        Melee = 3,
        Saw = 4,
        Corpsebag = 5,
        Other = 6,
    };
}
namespace app::fsm::PlayerStateCheck {
    enum PlayerIntType {
        None = 0,
        LoadNum = 1,
        NoGuardDamageChain = 2,
    };
}
namespace via::render {
    enum IntermediateTargetList {
        Target0 = 0,
        Target1 = 1,
        Target2 = 2,
        Target3 = 3,
        Invalid = -1,
    };
}
namespace app::Em8000::Motion::Em8000MotionID::Tag {
    enum Weapon {
        Idle = 0,
        Rest_WarCry = 1,
        EngineStop_Start = 2,
        EngineStop_Loop = 3,
        EngineStop_End = 4,
        BattleIdle = 5,
        Destroy_Fence = 6,
        Grapple_Cut_Front = 7,
        Grapple_Cut_Back = 8,
        Grapple_Cut_Front_Mild = 9,
        Grapple_Cut_Back_Mild = 10,
        Grapple_ShotGunGuard = 11,
        Grapple_BattleOfSaw_Start = 12,
        Grapple_BattleOfSaw_Loop = 13,
        Grapple_BattleOfSaw_End = 14,
        Grapple_LegCut = 15,
        Grapple_CuttingHead = 16,
        Grapple_CuttingFinal = 17,
    };
}
namespace via::str {
    enum SplitSeparatorType {
        String = 0,
        CharArray = 1,
    };
}
namespace via::render {
    enum VFXResolutionTarget {
        Primitive = 0,
        PrimitivePlusPrimitiveMesh = 1,
    };
}
namespace via::physics {
    enum ShapeCastOption {
        AllHits = 0,
        DisableBackFacingTriangleHits = 1,
        DisableFrontFacingTriangleHits = 2,
        BackFacingTriangleHits = 3,
        FrontFacingTriangleHits = 4,
        NearSort = 5,
        OneHitBreak = 6,
        Max = 7,
    };
}
namespace app::EPVStandardData::Element {
    enum HideModeForVREnum {
        None = 0,
        HideOn3DVR = 1,
    };
}
namespace app::CH9Em7800::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        HasAttackRight = 1,
        CanGrapple = 2,
        Front = 3,
        OutRange = 4,
        InRange = 5,
        HeightRange = 6,
        CurrentRouteNearDoor = 7,
        IsAttackFromRear = 8,
        IsTargetDamage = 9,
        IsAttackFromFrontWithDirective = 10,
        IsSlipFire = 11,
        AdditiveSensedAttack = 12,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum FovType {
        DeviceDefault = 0,
        SystemOverride = 1,
    };
}
namespace app::CH9Em7800::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
    };
}
namespace via::motion::detail {
    enum ChainDebugDisplayMode {
        HighLight = 0,
        SelectOnly = 1,
        None = 2,
    };
}
namespace via::render::VolumeDecal {
    enum ValidFlag {
        None = 0,
        BaseColor = 1,
        Normal = 2,
        Roughness = 4,
        Emissive = 8,
        AlphaMask = 16,
        AlphaSecondMask = 32,
        NormalRoughness = 64,
        All = 127,
        WholeBlendMode = 1610612736,
        FalloffFromTwoside = -2147483648,
    };
}
namespace via::navigation::ObstacleFilterInfo {
    enum FilterType {
        Avoid = 0,
        Through = 1,
    };
}
namespace app::CH8Em4400Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace app::Em8000::Message {
    enum CorresponceExistMessageType {
        Retire = 0,
        Override = 1,
    };
}
namespace via::motion::DevelopRetarget {
    enum HipPositionType {
        None = 0,
        AxisY = 1,
    };
}
namespace app::fsm::CH8PlayerStateCheck {
    enum PlayerBoolType {
        None = 0,
        FullyOperatable = 1,
        Move = 2,
        Jog = 3,
        Reloadable = 4,
        ModeChangeable = 5,
        CameraOperated = 6,
        GlassesScopeEnabled = 7,
        UseRemedy = 8,
        LArmHemostasis = 9,
        Reload = 10,
        StandUpAccepted = 11,
        GuardAccepted = 12,
        UseRemedyAccepted = 13,
        DetonateAccepted = 14,
        ChainSawReloadAccepted = 15,
        ChainSawAimAttackLoopAccepted = 16,
        UseBombAccepted = 17,
        BombSetup = 18,
        GunAttackAccepted = 19,
        MeleeAttackAccepted = 20,
        Guard = 21,
        LookAtTattooAccepted = 22,
        LookAtTattoo = 23,
        ChainSawReload = 24,
        MeleeAttack = 25,
        GunAttack = 26,
        ChainSawAimAttackLoop = 27,
        CameraOperatable = 28,
        ChangeMode = 29,
        MoveAccepted = 30,
        QuickTurnAccepted = 31,
        QuickTurn = 32,
        GunReloadAccepted = 33,
        ChangeModeAccepted = 34,
        SetMotionExternalTask = 35,
        UseNightVision = 36,
        Parry = 37,
        JustGuard = 38,
    };
}
namespace app::CH9Telemetry {
    enum OtherFlagType {
        RingBattleItem002 = 0,
        RingBattleWP000 = 1,
        RingBattleWP006 = 2,
        RingBattleWP002 = 3,
        BossBattleItem002 = 4,
        BossBattleWP000 = 5,
        BossBattleWP006 = 6,
        BossBattleWP002 = 7,
        ThroughPlayItem002 = 8,
        ThroughPlayWP000 = 9,
        ThroughPlayWP006 = 10,
        ThroughPlayWP002 = 11,
    };
}
namespace via::effect::gpgpu::NodeBillboardCS::NodeBillboardResource {
    enum ShaderType {
        Default = 0,
        LuminanceBleed = 1,
        SimpleLuminanceBleed = 2,
        Default_IgnoreDepth = 3,
        LuminanceBleed_IgnoreDepth = 4,
        SimpleLuminanceBleed_IgnoreDepth = 5,
        Distortion = 6,
        MaxType = 7,
    };
}
namespace System {
    enum Base64FormattingOptions {
        None = 0,
        InsertLineBreaks = 1,
    };
}
namespace via::Serializer::JsonToken {
    enum Kind {
        Map = 0,
        Array = 1,
        Boolean = 2,
        Null = 3,
        Integer = 4,
        UnsignedInteger = 5,
        Float = 6,
        String = 7,
        EscapedString = 8,
        Key = 9,
    };
}
namespace app::CH9Em5700 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace via::motion {
    enum RootPlayMode {
        None = 0,
        Fixed = 1,
        Continuance = 2,
        Joint = 3,
        FixedWithScale = 4,
    };
}
namespace via::motion {
    enum ExitType {
        None = 0,
        End = 1,
        Frame = 2,
        FrameFromEnd = 3,
    };
}
namespace via::gui {
    enum BarVisibility {
        Always = 0,
        AutoHideBar = 1,
        AutoHideAll = 2,
    };
}
namespace app::GPISwitch {
    enum SlotType {
        DipSwitch = 0,
        DebugCamera = 1,
        DrawFrameRate = 2,
        DrawPropsdebug = 3,
        Dummy04 = 4,
        Dummy05 = 5,
        Dummy06 = 6,
        Dummy07 = 7,
    };
}
namespace via::clr {
    enum EnumI2 {
        Dummy = 0,
    };
}
namespace via::network::AutoMatchmaking {
    enum RuleCategory {
        Group = 0,
        Region = 1,
        P2pVersion = 2,
        Users = 3,
    };
}
namespace via::effect::detail {
    enum EmitterDimType {
        EmitterDimType_2D = 0,
        EmitterDimType_3D = 1,
    };
}
namespace via::motion::detail::IkNboneSolver {
    enum calcType {
        Basic = 0,
        Heavy = 1,
    };
}
namespace via::render {
    enum RenderDeviceAPI {
        DirectX11 = 0,
        DirectX12 = 1,
        OpenGL = 2,
        OpenGLES = 3,
        Vulkan = 4,
        Mantle = 5,
        Metal = 6,
        Glide = 7,
        DirectX11x = 8,
        DirectX12x = 9,
        GNM = 10,
        AGC = 11,
        NVN = 12,
        Unkown = 13,
        NULL = 14,
        DirectX12Legacy = 15,
    };
}
namespace via::render {
    enum StochasticTransparentSample {
        StochasticTransparentSample_4 = 0,
        StochasticTransparentSample_8 = 1,
    };
}
namespace via::effect::gpgpu::detail {
    enum NodeBillboardBlendType {
        AlphaBlend = 0,
        Physical = 1,
    };
}
namespace via::effect::vortexel {
    enum VelocityAttenuationType {
        None = 0,
        ExpCurve = 1,
        Exp2Curve = 2,
        HalfLinear = 3,
        Linear = 4,
    };
}
namespace via::network::error {
    enum CauseSession {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        PeerOpenTimeout = 129,
        PeerNumOverflow = 130,
        PeerNorecvTimeout = 131,
        PeerReliableOverflow = 132,
        PeerDropBySync = 133,
        PeerDropAll = 134,
        PeerUnstableAll = 135,
        PeerUnstableOne = 136,
        PeerOpenNorecvAnyPkt = 137,
        CannotOpenAllPeer = 144,
        NoHost = 145,
        Full = 146,
        IsNotExist = 148,
        AlreadyExist = 149,
        HostDeny = 150,
        DuplicateJoin = 151,
        PortNotOpen = 152,
        Disallow = 153,
        Incompatible = 154,
        NoResponse = 157,
        DifferentVersion = 158,
        NotReady = 159,
        IsPrivate = 160,
        HostOnly = 161,
        IsClose = 162,
        Disconnected = 163,
        Blocked = 164,
        InvalidSessionId = 165,
    };
}
namespace app::CH8Em4400::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::DifficultySelectGUI {
    enum ModeDef {
        BootFlow = 0,
        Title = 1,
    };
}
namespace via::AnimationCurve3D {
    enum Wrap {
        Once = 0,
        Loop = 1,
        Loop_Always = 2,
    };
}
namespace app::CH9WireTrap {
    enum State {
        Wait = 0,
        WireHit = 1,
        Explosion = 2,
        Broken = 3,
    };
}
namespace app::CH8Em4200ActionPoint {
    enum Type {
        DropPoint = 0,
    };
}
namespace via::effect::EffectTest {
    enum EmitterLifeState {
        EmitterLifeState_Unknown = 0,
        EmitterLifeState_Wait = 1,
        EmitterLifeState_Initialize = 2,
        EmitterLifeState_Appear = 3,
        EmitterLifeState_Keep = 4,
        EmitterLifeState_KeepHold = 5,
        EmitterLifeState_Vanish = 6,
        EmitterLifeState_Terminate = 7,
    };
}
namespace via::motion::IkLookAt {
    enum LookAtState {
        None = 0,
        Move = 1,
        Follow = 2,
    };
}
namespace via::motion::IkLegSpine {
    enum LeanCtrl {
        None = 0,
        Local = 1,
        World = 2,
        UnderHipLocal = 3,
        UnderHipWorld = 4,
        ManualLocal = 5,
        ManualWorld = 6,
    };
}
namespace app::CH8OperatorManager2 {
    enum CaseTable {
        Failure = 0,
        Success = 1,
        Forced = 2,
    };
}
namespace app::MotionGroupTable::MotionInfo {
    enum InfoType {
        Motion = 0,
        State = 1,
    };
}
namespace app::Em2000::Em2000FaceModeController {
    enum ProcessType {
        NormalMove = 0,
        FullControllStart = 1,
        FullControllMove = 2,
        FullControllEnd = 3,
    };
}
namespace app::CH8Em4000::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::motion::IkLeg2 {
    enum FootAdjust {
        KeepDistanceFromGround = 0,
        PushedGround = 1,
    };
}
namespace app::CH9Em5700::Goal::SideMove {
    enum MoveDirect {
        Left = 0,
        Right = 1,
    };
}
namespace app::fsm::SetDoorState {
    enum OverrideType {
        NotSet = 0,
        UseDefault = 1,
        Override = 2,
    };
}
namespace via::physics {
    enum GateEventType {
        None = 0,
        Enter = 1,
        Leave = 2,
    };
}
namespace app::CH8Em4100::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        NoUse_Wall1 = 1,
        NoUse_Wall2 = 2,
        FromWall3_Normal = 3,
        FromWall4_Speedy = 4,
        FromCeil1_Normal = 5,
        FromCeil2_Speedy = 6,
        FirstAppear = 7,
        FromLakeL = 8,
        FromLakeR = 9,
        NoUse_Chandelier = 100,
        NoUse_CeilingLoop = 200,
        NoUse_FromWallLeftLoop = 201,
        NoUse_FromWallRightLoop = 202,
        Summon = 203,
        Attack = 204,
        EventAttack = 205,
    };
}
namespace via::dynamics::internal::BoundingVolumeHierarchy {
    enum ErrorCode {
        None = 0,
        FunctorAbort = 1,
        Max = 2,
    };
}
namespace app::Em5552 {
    enum ThinkState {
        None = 0,
    };
}
namespace app::DebugRecordRequest {
    enum Type {
        Attacker = 0,
        Victim = 1,
    };
}
namespace via::hid::gamePlayer {
    enum PlayerOtherDeviceHandling {
        UseFirstSelected = 1,
        UseLastSelected = 2,
        AssignToOtherPlayer = 3,
    };
}
namespace via::navigation::algorithm::MapGraphAstar {
    enum PassStateFlags {
        EnterWallMask0 = 1,
        EnterWallMask1 = 2,
    };
}
namespace app::EventActionController {
    enum ProcessType {
        Running = 0,
        End = 1,
    };
}
namespace app::fsm::PartsEnable {
    enum PartsSetType {
        EnableSet = 0,
        DisableSet = 1,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum RayTracingSamplingPattern {
        BlueNoise = 0,
        SudokuBasedBlueNoise = 1,
    };
}
namespace app::Em3000::Action::Attack {
    enum Type {
        SwingR = 0,
        SwingL = 1,
        SwingDown = 2,
        LSwingR = 3,
        LSwingL = 4,
        LSwingDown = 5,
        SwingCombo = 6,
        PunchL = 7,
        StepBack = 8,
        TSwingR = 9,
        TSwingL = 10,
        TSwingDown = 11,
        TLSwingR = 12,
        TLSwingDown = 13,
        TSwingCombo = 14,
    };
}
namespace via::hid::mouse {
    enum ManipulatorClientDefaultType {
        DirectInput = 1,
        RawInput = 2,
        WindowMessage = 3,
        GlobalParameter = 4,
    };
}
namespace app::ItemCheckParam {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace app::CardGameItem {
    enum RemoveType {
        NoUse = 0,
        Remove = 1,
        Return = 2,
    };
}
namespace via::motion {
    enum PlayState {
        Play = 0,
        Pause = 1,
        Stop = 2,
    };
}
namespace via::effect::gpgpu::PolygonCS::PolygonResource {
    enum ShaderType {
        Default = 0,
        LuminanceBleed = 1,
        SimpleLuminanceBleed = 2,
        Default_IgnoreDepth = 3,
        LuminanceBleed_IgnoreDepth = 4,
        SimpleLuminanceBleed_IgnoreDepth = 5,
        StochasticPreZ = 6,
        StochasticTransparent = 7,
        MaxType = 8,
    };
}
namespace app::fsm::CH8CheckSeceFolder {
    enum CheckType {
        IsActivate = 0,
        IsDeactivate = 1,
    };
}
namespace via::gui {
    enum IconColorType {
        None = 0,
        AlphaOnly = 1,
        RGBA = 2,
    };
}
namespace app::CarInGarage {
    enum Parts {
        None = -1,
        LeftDoor = 1,
        FrontBody = 2,
        RearBody = 3,
        FrontGlass = 20,
        FrontLeftGlass = 21,
        FrontRightGlass = 22,
        RearLeftGlass = 23,
        RearRightGlass = 24,
        RearGlass = 25,
        FrontLeftLightGlass = 26,
        FrontLeftWinkerGlass = 27,
        FrontRightLightGlass = 28,
        FrontRightWinkerGlass = 29,
        RearLeftWinkerGlass = 30,
        RearRightWinkerGlass = 31,
        FrontBodyLittleBreak = 51,
        FrontBodyBreak = 52,
        RearBodyBreak = 55,
    };
}
namespace via::memory {
    enum DebugMode {
        AllocZeroClear = 1,
        AllocFill = 2,
        FreeZeroClear = 4,
        FreeFill = 8,
        BoundCheck = 16,
        FreeCheck = 32,
        EmbededAlloc = 64,
    };
}
namespace app::Em8100Think {
    enum Status {
        Front = 0,
        Right = 1,
        Left = 2,
        Grab = 3,
    };
}
namespace app::Em3090 {
    enum ActionStepEnum {
        Wait = 0,
        Eat = 1,
        Reaction = 2,
    };
}
namespace via::render::layer::Overlay {
    enum SegmentOrder {
        PostFilter = 0,
        PushToEsram = 0,
        OverlayPostEffect = 62,
        PopFromEsram = 62,
        System = 63,
    };
}
namespace app::Em3100::Action::DiscoveryTurn {
    enum Type {
        Default = 0,
        Patrol = 1,
        OrderTurn = 2,
    };
}
namespace app::wwise::WwiseOptionMenu {
    enum Speaker {
        TV = 0,
        Headphone = 1,
        Surround = 2,
    };
}
namespace via::crypto::pkc {
    enum Type {
        Type_1 = 0,
        Type_2 = 1,
        Type_3 = 2,
        Type_4 = 3,
        Type_Invalid = 4,
    };
}
namespace app::UICursor {
    enum TypeDef {
        Type1 = 0,
        Type2 = 1,
    };
}
namespace via::render::ToneMapping {
    enum NeighborhoodClamp {
        AABBClip = 0,
        VarianceClip = 1,
    };
}
namespace via::audiorender {
    enum StreamType {
        None = 0,
        MemoryStream = 1,
        FileStream = 2,
    };
}
namespace app::CH8OperatorManager {
    enum MessagePriority {
        Default = 100,
        Monologue = 200,
        EnemyVoice = 300,
        Event = 400,
        Force = 500,
        EventMultiDisp = -1,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraFormatLevel {
        Level0 = 1,
        Level1 = 2,
        Level2 = 4,
        Level3 = 8,
        All = 15,
        LevelMax = 4,
    };
}
namespace via::effect::detail {
    enum EmitterStateType {
        Idle = 0,
        Start = 1,
        Running = 2,
        Stop = 3,
        Kill = 4,
    };
}
namespace app::Collision::HitController::DamageInfo {
    enum Type {
        Slash = 0,
        Stab = 1,
        Shoot = 2,
        Strike = 3,
        Catch = 4,
        Bite = 5,
        Explosion = 6,
        Car = 7,
        Wave = 8,
        InsectBath = 9,
    };
}
namespace app::PlayerMelee {
    enum AttackDirection {
        LeftDown = 0,
        RightDown = 1,
    };
}
namespace via::render::SwingWind {
    enum WindType {
        Directional = 0,
        Point = 1,
        Push = 2,
    };
}
namespace app::fsm::CH8InteractTest {
    enum TestTypeParam {
        Normal = 0,
        SwitchOn = 1,
        SwitchOff = 2,
        EndInteract = 3,
        DoorPush = 4,
        DoorInteract = 5,
        SearchEvent_0 = 6,
        SearchEvent_1 = 7,
        SearchEvent_2 = 8,
        SearchEvent_3 = 9,
        Double_A = 10,
        Double_B = 11,
    };
}
namespace via::motion::IkLegSpine {
    enum RayCastMode {
        Default = 0,
        Normal = 1,
        Joint = 2,
        Sphere = 3,
    };
}
namespace via::motion {
    enum ConstraintsUpdate {
        PrevLateUpdate = 0,
        AfterLateUpdate = 1,
        Last = 2,
        ByBehavior = 3,
    };
}
namespace via::motion::JointExMultiRemapValue::ConeInputData {
    enum ConeAxis {
        X = 0,
        Y = 1,
        Z = 2,
        MinusX = 3,
        MinusY = 4,
        MinusZ = 5,
        Vector = 6,
    };
}
namespace via::motion::IkSpineConformGround {
    enum RAY_TYPE {
        DEFAULT = 0,
        JOINT = 1,
    };
}
namespace app::Em5400::Action::Generate {
    enum Type {
        GenerateS = 0,
        GenerateM = 1,
        GenerateL = 2,
        GenerateCommon = 3,
    };
}
namespace via::navigation::Pathfinder {
    enum PathfindResult {
        Fail = 0,
        Success = 1,
        SuccessNearPossible = 2,
        Continue = 3,
    };
}
namespace via::network::error {
    enum CauseOverlaySession {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
        PreJoinHost = 129,
        UnexpectedHost = 130,
        UnexpectedJoin = 131,
        Rollback = 132,
        PreJoinTimeout = 133,
    };
}
namespace app::InteractDetailSearch {
    enum SearchEventRotAxisSign {
        Plus = 0,
        Minus = 1,
    };
}
namespace app::OptionMenu {
    enum RecordItem {
        Difficulty = 0,
        Playtime = 1,
        Restart = 2,
        MrEveryWhere = 3,
        Coin = 4,
        File = 5,
        Itembox = 6,
        Medicine = 7,
        Stabilizer = 8,
        Steroid = 9,
    };
}
namespace via::wwise {
    enum PriorityMode {
        Newest = 0,
        Oldest = 1,
    };
}
namespace via::effect::detail {
    enum ClipKeyType {
        Bool = 0,
        Int32 = 1,
        Int64 = 2,
        UInt32 = 3,
        UInt64 = 4,
        Float = 5,
        Double = 6,
    };
}
namespace hikako {
    enum WeaponTriggerState {
        Idle = 0,
        Wait = 1,
        Fire = 2,
        Active = 3,
    };
}
namespace via::hid::gamePlayer {
    enum AccountPickerResult {
        UserChanged = 0,
        UserUnchanged = 1,
        Canceled = 2,
        DeviceDisconnected = 3,
        Failed = 4,
    };
}
namespace app::Em3002Think {
    enum Mode {
        Idle = 0,
        Battle = 1,
    };
}
namespace app::Em3600::Action::WallAttack {
    enum Type {
        FallAttack = 0,
        FallAttackLow = 1,
        CellAttack = 2,
        FallAttackRev = 3,
        CellFallAttackRev = 4,
    };
}
namespace app::CH9Em7800ActionController {
    enum BackstepQueType {
        Back = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::Em3000::Action::AttackKnock {
    enum Type {
        Forward = 0,
        Back = 1,
    };
}
namespace app::Em3100::Goal::GoalGenerator {
    enum ID {
        OneAction = 0,
        OneAction2 = 1,
        UnDiscovery = 2,
        Discovery = 3,
        Turn = 4,
        MoveToTarget = 5,
        DoorOpen = 6,
        CommonDoorOpen = 7,
        Grapple = 8,
        OrderSearchPLGotoTarget = 9,
        OverLook = 10,
        WalkOverLook_L = 11,
        WalkOverLook_R = 12,
        WalkLookBack_L = 13,
        WalkLookBack_R = 14,
        Cough = 15,
        SetHair = 16,
        Fret = 17,
        WalkFret = 18,
        DoorOpenLookBack = 19,
        WalkLookBackTurn = 20,
        OrderTurn = 21,
        UnDiscoveryFF = 22,
        BattleFF = 23,
        DetectReaction = 24,
        Chase = 25,
        DiscoveryTurn = 26,
        DiscoveryLoop = 27,
        Suspicion = 28,
        UnDiscoveryFFLast = 29,
        BattleFFLast = 30,
        BattleInsectBath = 31,
        AttackChoice = 32,
        TargetLadderGenerate = 33,
        Fall = 34,
        BugHoleDeadAction = 35,
        UnDiscoveryPatrol = 36,
        BattlePatrol = 37,
        BattlePatrolStep = 38,
        HearingPointTurn = 39,
        PatrolBugInstruct = 40,
        PatrolChase = 41,
        PatrolEvacuate = 42,
    };
}
namespace via::render::ColorCorrectLinearParams {
    enum LinearCorrector {
        None = 0,
        Hue = 1,
        Chroma = 2,
        Brightness = 3,
        Sepia = 4,
        Scale = 5,
        NegaPosi = 6,
        GrayScale = 7,
        RedReplace = 8,
        GreenReplace = 9,
        BlueReplace = 10,
        Add = 11,
        Sub = 12,
        Max = 13,
    };
}
namespace via::timeline {
    enum PropertyType {
        Unknown = 0,
        Bool = 1,
        S8 = 2,
        U8 = 3,
        S16 = 4,
        U16 = 5,
        S32 = 6,
        U32 = 7,
        S64 = 8,
        U64 = 9,
        F32 = 10,
        F64 = 11,
        Str8 = 12,
        Str16 = 13,
        Enum = 14,
        Quaternion = 15,
        Array = 16,
        NativeArray = 17,
        Class = 18,
        NativeClass = 19,
        Struct = 20,
        Vec2 = 21,
        Vec3 = 22,
        Vec4 = 23,
        Color = 24,
        Range = 25,
        Float2 = 26,
        Float3 = 27,
        Float4 = 28,
        RangeI = 29,
        Point = 30,
        Size = 31,
        Asset = 32,
        Action = 33,
        Guid = 34,
        Uint2 = 35,
        Uint3 = 36,
        Uint4 = 37,
        Int2 = 38,
        Int3 = 39,
        Int4 = 40,
        OBB = 41,
        Mat4 = 42,
        Rect = 43,
        PathPoint3D = 44,
        Plane = 45,
        Sphere = 46,
        Capsule = 47,
        AABB = 48,
        Nullable = 49,
        Sfix = 50,
        Sfix2 = 51,
        Sfix3 = 52,
        Sfix4 = 53,
        AnimationCurve = 54,
        KeyFrame = 55,
        GameObjectRef = 56,
    };
}
namespace via::navigation::AIMapEffector {
    enum ShapeType {
        ColliderBoundary = 0,
        AABB = 1,
        OBB = 2,
        Sphere = 3,
        MeshOutline = 4,
    };
}
namespace via::physics::CollisionHeightFieldResource {
    enum PointState {
        Removed = 0,
        Max = 1,
    };
}
namespace via::hid::virtualKeyboard {
    enum VirtualKeyboardCloseResult {
        OK = 0,
        AlreadyClosed = 1,
        AlreadyClosing = 2,
        Error = 3,
        NotSupported = 4,
    };
}
namespace app {
    enum WeaponID {
        Hand = 0,
        HandAxe = 1,
        CircularSaw = 2,
        Knife = 3,
        Bar = 4,
        Handgun = 5,
        Handgun_M19 = 6,
        Handgun_G17 = 7,
        Handgun_MPM = 8,
        Handgun_Albert = 9,
        ShotGun = 10,
        Shotgun_M37 = 11,
        Shotgun_M37S = 12,
        Shotgun_DB = 13,
        MachineGun = 14,
        Magnum = 15,
        GrenadeLauncher = 16,
        Burner = 17,
        Candle = 18,
        Glasses = 19,
        EvelynRadar = 20,
        LiquidBomb = 21,
        Timebomb = 22,
        Flare = 23,
        Remedy = 24,
        EyeDrops = 25,
        Stimulant = 26,
        Depressant = 27,
        KitchenKnife = 28,
        ChainSaw = 29,
        WoodChip = 30,
        HandLight = 31,
        ChainCutter = 32,
        ScrewDriver = 33,
        Shovel = 34,
        Lantern = 35,
        Roller = 36,
        Scissors = 37,
        Stick = 38,
        LanternBar = 39,
        GlassPiece = 40,
        FireAxe = 41,
        MiaKnife = 42,
        GoldenBar = 43,
        HyperBlaster = 44,
        BarCircularsaw = 45,
        Handgun_Albert_Reward = 46,
        FireAxeBreakable = 47,
        CKnife = 48,
        Handgun_Albert_C = 49,
        Shotgun_Albert = 50,
        BlueBlaster = 51,
        RedBlaster = 52,
        Birthday003 = 53,
        Birthday004 = 54,
        Lantern_C = 55,
        Lighter_Z = 56,
        GimmickKnife = 57,
        Grenadebomb = 58,
        Thermatebomb = 59,
        Stangrenadebomb = 60,
        CH9_WP000 = 61,
        CH9_WP001 = 62,
        CH9_WP002 = 63,
        CH9_WP003 = 64,
        CH9_WP004 = 65,
        CH9_WP005 = 66,
        CH9_WP006 = 67,
        CH9_WP007 = 68,
        CH9_WP008 = 69,
        CH9_WP009 = 70,
        Num = 71,
        Etc = 9999,
    };
}
namespace app::OptionMenu {
    enum OptionScreenType {
        Option = 0,
        ExtraGame = 1,
        SpecialFeature = 2,
        Record = 3,
    };
}
namespace via::audiorender {
    enum OutputConfig {
        OutputConfig_None = 0,
        OutputConfig_1ch = 1,
        OutputConfig_2ch = 2,
        OutputConfig_3ch = 3,
        OutputConfig_4ch = 4,
        OutputConfig_51ch = 5,
        OutputConfig_512ch = 6,
        OutputConfig_514ch = 7,
        OutputConfig_71ch = 8,
        OutputConfig_712ch = 9,
        OutputConfig_714ch = 10,
        OutputConfig_1oAmb = 11,
        OutputConfig_2oAmb = 12,
        OutputConfig_3oAmb = 13,
        OutputConfig_4oAmb = 14,
        OutputConfig_5oAmb = 15,
        OutputConfig_Max = 16,
    };
}
namespace app::UICommand {
    enum MouseConfirmType {
        Trigger = 0,
        Down = 1,
        Release = 2,
    };
}
namespace app::DoorPush {
    enum KnockType {
        None = 0,
        Immediately = 1,
        Delay = 2,
    };
}
namespace via {
    enum SharePlayControllerMode {
        Disable = -1,
        Failed = -2,
        Invalid = -3,
        WatchingHostPlay = 0,
        PlayingAsHost = 1,
        PlayingWithHost = 2,
    };
}
namespace app::Em3000::Em3000ActionController {
    enum MotionSpeedControlGroup {
        Base = 0,
        Attack = 1,
        Rank = 2,
    };
}
namespace via::gui {
    enum PageAlignment {
        LeftTop = 0,
        LeftCenter = 4,
        LeftBottom = 8,
        CenterTop = 1,
        CenterCenter = 5,
        CenterBottom = 9,
        RightTop = 2,
        RightCenter = 6,
        RightBottom = 10,
    };
}
namespace via::octree {
    enum InsertType {
        Position = 0,
        Collider = 1,
        Collidable = 2,
        AABB = 3,
    };
}
namespace app::InventoryManager {
    enum QuickEquipSlotNo {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
        None = 4,
    };
}
namespace app::CH8SaveMenu {
    enum ListElemID {
        Restart = 0,
        End = 1,
    };
}
namespace app::CH9EPVExpertKnuckleLandingData {
    enum ZDirectionType {
        AttackDirection = 0,
        SawRotation = 1,
    };
}
namespace via {
    enum GamePresetsAudioLanguage {
        System = 0,
        Original = 1,
    };
}
namespace app::EnemyActionController {
    enum SelfDieReasonType {
        Falling = 0,
        Explosion = 1,
        Force = 2,
        GrappleDead = 3,
    };
}
namespace via::hid::hmd::MorpheusTrackerState {
    enum StatusCombination {
        None = 0,
        Position = 4,
        Velocity = 8,
        Acceleration = 16,
        Orientation = 32,
        AngularVelocity = 64,
        AngularAcceleration = 128,
        AccelerometerPosition = 256,
        AccelerometerVelocity = 512,
        AccelerometerAcceleration = 1024,
        CameraPitchAngle = 2048,
        CameraRollAngle = 4096,
    };
}
namespace app::Em3001::Action::Attack {
    enum Type {
        SwingR = 0,
        SwingL = 1,
        SwingDown = 2,
        LSwingR = 3,
        LSwingL = 4,
        LSwingDown = 5,
        SwingCombo = 6,
        PunchL = 7,
        StepBack = 8,
        TSwingR = 9,
        TSwingL = 10,
        TSwingDown = 11,
        TLSwingR = 12,
        TLSwingDown = 13,
        TSwingCombo = 14,
    };
}
namespace via::storage::saveService {
    enum SaveParcentCompleteStatus {
        Start = 0,
        Serialize = 1,
        SizeCheck = 25,
        WriteFile = 50,
        TempUp = 75,
        End = 100,
    };
}
namespace app {
    enum ItemID {
        NoName = 0,
        FoundFootage000 = 1,
        FoundFootage010 = 2,
        FoundFootage020 = 3,
        Fuse = 4,
        ChainCutter = 5,
        HandCutOff = 6,
        Chapter1Map = 7,
        MiaDriversLicense = 8,
        EntranceHallKey = 9,
        RightJawboneObject = 10,
        LeftJawboneObject = 11,
        Chapter3_2Map = 12,
        SilhouettePazzlePiece = 13,
        ToyShotgun = 14,
        MorgueKey = 15,
        BurnerPartsA = 16,
        BurnerPartsB = 17,
        TalismanKey = 18,
        Chapter3_3Map = 19,
        SerumData = 20,
        SerumMaterialA = 21,
        FoundFootage030 = 22,
        Chapter3_4MAP = 23,
        FoundFootage040 = 24,
        Battery = 25,
        SpringCoil = 26,
        CylinderKey = 27,
        SkinnyDoll = 28,
        ScrewFinger = 29,
        Quill = 30,
        SerumMaterialB = 31,
        Valve = 32,
        Shaft = 33,
        CombinedJoint = 34,
        Joint = 35,
        CompletedValve = 36,
        DollArmRight = 37,
        DollArmleft = 38,
        Driver = 39,
        Valve_Shaft = 40,
        Shaft_Joint = 41,
        MasterKey = 42,
        ScrewDriver = 43,
        ChainSaw = 44,
        HandLight = 45,
        KitchenKnife = 46,
        Shovel = 47,
        HandAxe = 48,
        CircularSaw = 49,
        Knife = 50,
        Bar = 51,
        Handgun = 52,
        Handgun_M19 = 53,
        Handgun_G17 = 54,
        Handgun_MPM = 55,
        Handgun_Albert = 56,
        ShotGun = 57,
        Shotgun_M37 = 58,
        Shotgun_M37S = 59,
        Shotgun_DB = 60,
        MachineGun = 61,
        Magnum = 62,
        GrenadeLauncher = 63,
        Burner = 64,
        Candle = 65,
        Candle_Lighted = 66,
        Glasses = 67,
        Glasses_Washed = 68,
        EvelynRadar = 69,
        LiquidBomb = 70,
        Timebomb = 71,
        Flare = 72,
        HandgunBullet = 73,
        HandgunBulletL = 74,
        ShotgunBullet = 75,
        MachineGunBullet = 76,
        MagnumBullet = 77,
        BurnerBullet = 78,
        FlameBulletS = 79,
        FlameBulletL = 80,
        AcidBulletS = 81,
        AcidBulletL = 82,
        RemedyS = 83,
        RemedyM = 84,
        RemedyL = 85,
        EyeDrops = 86,
        Stimulant = 87,
        Depressant = 88,
        FireAxe = 89,
        EthanLeg = 90,
        BrokenHandgun_M19 = 91,
        BrokenShotgun_DB = 92,
        MiaKnife = 93,
        GoldenBar = 94,
        HyperBlaster = 95,
        ChemicalM = 96,
        ChemicalL = 97,
        Gunpowder = 98,
        SpareKey = 99,
        HotloadBullet = 100,
        TreasureMap02 = 101,
        TreasureMap03 = 102,
        ChemicalS = 103,
        BoneJawAB = 104,
        DybbukMedicine = 105,
        food005 = 106,
        food010 = 107,
        food012 = 108,
        food013 = 109,
        food015 = 110,
        food016 = 111,
        food017 = 112,
        food019 = 113,
        EthanCarKey = 114,
        SupplyBoxA = 115,
        SupplyBoxB = 116,
        SupplyBoxC = 117,
        SupplyBoxD = 118,
        SupplyBoxE = 119,
        SupplyBoxOpenedA = 120,
        SupplyBoxOpenedB = 121,
        SupplyBoxOpenedC = 122,
        SupplyBoxOpenedD = 123,
        SupplyBoxOpenedE = 124,
        GoodLuckCoinA = 125,
        GoodLuckCoinB = 126,
        GoodLuckCoinC = 127,
        GoodLuckCoinD = 128,
        GoodLuckCoinE = 129,
        Handgun_Albert_Reward = 130,
        Herb = 131,
        CKnife = 132,
        Handgun_Albert_C = 133,
        Shotgun_Albert = 134,
        BlueBlaster = 135,
        RedBlaster = 136,
        Lantern_C = 137,
        Lighter_Z = 138,
        SafeBottle = 139,
        GimmickKnife = 140,
        ResurrectionMedium = 141,
        BookDefence01 = 142,
        BookDefence02 = 143,
        AlphaGrass = 144,
        EasyBoots = 145,
        UnlimitedAmmo = 146,
        EasyBoots_IMD = 147,
        Grenadebomb = 148,
        Thermatebomb = 149,
        Stangrenadebomb = 150,
        RemedyAmpoulesM = 151,
        RemedyAmpoulesL = 152,
        FuseCh8 = 153,
        AlbertHandgunBullet = 154,
        AlbertHandgunBulletL = 155,
        AlbertShotgunBullet = 156,
        KeyItem01Ch8 = 157,
        KeyItem02Ch8 = 158,
        KeyItem03Ch8 = 159,
        KeyItem04Ch8 = 160,
        KeyItem05Ch8 = 161,
        CH9_WP000 = 162,
        CH9_WP001 = 163,
        CH9_WP002 = 164,
        CH9_WP003 = 165,
        CH9_WP004 = 166,
        CH9_WP005 = 167,
        CH9_WP006 = 168,
        CH9_WP007 = 169,
        CH9_WP008 = 170,
        CH9_WP009 = 171,
        NumaItem000 = 172,
        NumaItem001 = 173,
        NumaItem002 = 174,
        NumaItem003 = 175,
        NumaItem004 = 176,
        NumaItem005 = 177,
        NumaItem006 = 178,
        NumaItem007 = 179,
        NumaItem008 = 180,
        NumaItem009 = 181,
        NumaItem010 = 182,
        NumaItem011 = 183,
        NumaItem012 = 184,
        NumaItem013 = 185,
        NumaItem014 = 186,
        NumaItem015 = 187,
        NumaItem016 = 188,
        NumaItem017 = 189,
        NumaItem018 = 190,
        NumaItem019 = 191,
        NumaItem020 = 192,
        NumaItem021 = 193,
        NumaItem022 = 194,
        NumaItem023 = 195,
        NumaItem024 = 196,
        NumaItem025 = 197,
        NumaItem026 = 198,
        NumaItem027 = 199,
        NumaItem028 = 200,
        NumaItem029 = 201,
        NumaItem030 = 202,
        NumaItem031 = 203,
        NumaItem032 = 204,
        NumaItem033 = 205,
        NumaItem034 = 206,
        NumaItem035 = 207,
        NumaItem036 = 208,
        NumaItem037 = 209,
        NumaItem038 = 210,
        NumaItem039 = 211,
        NumaItem040 = 212,
        NumaItem041 = 213,
        NumaItem042 = 214,
        NumaItem043 = 215,
        NumaItem044 = 216,
        NumaItem045 = 217,
        NumaItem046 = 218,
        NumaItem047 = 219,
        NumaItem048 = 220,
        NumaItem049 = 221,
        NumaItem050 = 222,
        NumaItem051 = 223,
        NumaItem052 = 224,
        NumaItem053 = 225,
        NumaItem054 = 226,
        NumaItem055 = 227,
        NumaItem056 = 228,
        NumaItem057 = 229,
        NumaItem058 = 230,
        NumaItem059 = 231,
        NumaItem060 = 232,
        NumaItem061 = 233,
        NumaItem062 = 234,
        NumaItem063 = 235,
        NumaItem064 = 236,
        NumaItem065 = 237,
        NumaItem066 = 238,
        NumaItem067 = 239,
        NumaItem068 = 240,
        NumaItem069 = 241,
        NumaItem070 = 242,
        NumaItem071 = 243,
        NumaItem072 = 244,
    };
}
namespace app::Em2000Order::Appear {
    enum Type {
        Idle = 0,
        Chp1_Battle1_Before = 1,
        Chp1_Battle2_Before = 2,
        Chp1_Battle3_Before = 3,
        Chp1_Battle4_Before = 4,
        Chp1_Battle4_After = 5,
    };
}
namespace via::render::command::PS5Extention {
    enum ExtentionType {
        ExtentionType_4KCheckerBoardRenderingEnable = 0,
        ExtentionType_4KCheckerBoardRenderingEvenFrameEnable = 0,
        ExtentionType_4KCheckerBoardRenderingOddFrameEnable = 1,
        ExtentionType_TemporalAntialiasing4KCheckerBoardRenderingEvenFrameEnable = 2,
        ExtentionType_TemporalAntialiasing4KCheckerBoardRenderingOddFrameEnable = 3,
        ExtentionType_4KCheckerBoardRenderingDisable = 4,
        ExtentionType_PsInvoke_Enable = 5,
        ExtentionType_PsInvoke_Disable = 6,
    };
}
namespace app::Em2000 {
    enum ThinkState {
        None = 0,
        Chapter1Battle1 = 1,
        Chapter1Battle2 = 2,
        Chapter1Battle3 = 3,
        Chapter1Battle4 = 4,
        Chapter4Battle = 5,
        Chapter4_3Illusion = 6,
    };
}
namespace hikako {
    enum VibrationTrigger {
        None = 0,
        TEST_ALPHA = 1,
        TEST_BETA = 2,
        TEST_GAMMA = 3,
        Legacy_Vibration_SS = 4,
        Legacy_Vibration_S = 5,
        Legacy_Vibration_M = 6,
        Legacy_Vibration_L = 7,
        WP0000_SHOT = 8,
        WP1000_SHOT = 9,
        WP1010_SHOT = 10,
        WP1030_SHOT = 11,
        WP1110_SHOT = 12,
        WP1140_SHOT = 13,
        WP1160_SHOT = 14,
        WP1330_SHOT = 15,
        WP1340_SHOT = 16,
        WP1380_SHOT = 17,
        WP0000_RELOAD = 18,
        WP1000_RELOAD_GAS_MOUNT_01 = 19,
        WP1000_RELOAD_GAS_MOUNT_02 = 20,
        WP1000_RELOAD_GAS_OFF_01 = 21,
        WP1000_RELOAD_GAS_OFF_02 = 22,
        WP1010_RELOAD_BLOWBACK = 23,
        WP1010_RELOAD_MAG_IN = 24,
        WP1010_RELOAD_MAG_OUT = 25,
        WP1010_RELOAD_MAG_PUSH = 26,
        WP1010_RELOAD_BACK = 27,
        WP1010_RELOAD_PULL = 28,
        WP1030_RELOAD_BULLET = 29,
        WP1030_RELOAD_CLOSE = 30,
        WP1030_RELOAD_OPEN = 31,
        WP1030_RELOAD_POMP = 32,
        WP1110_RELOAD_END = 33,
        WP1110_RELOAD_OPEN = 34,
        WP1110_RELOAD_SHELL = 35,
        WP1110_RELOAD_SHELL_OUT = 36,
        WP1140_RELOAD_BLOWBACK = 37,
        WP1140_RELOAD_MAG_IN = 38,
        WP1140_RELOAD_MAG_OUT = 39,
        WP1140_RELOAD_MAG_PUSH = 40,
        WP1160_RELOAD_MAG_IN_1 = 41,
        WP1160_RELOAD_MAG_IN_2 = 42,
        WP1160_RELOAD_MAG_OUT = 43,
        WP1160_RELOAD_PULL = 44,
        WP1330_RELOAD_MAG_IN_1 = 45,
        WP1330_RELOAD_MAG_IN_2 = 46,
        WP1330_RELOAD_MAG_OUT = 47,
        WP1330_RELOAD_PULL = 48,
        WP1340_RELOAD_BLOWBACK = 49,
        WP1340_RELOAD_MAG_IN = 50,
        WP1340_RELOAD_MAG_OUT = 51,
        WP1340_RELOAD_MAG_PUSH = 52,
        WP1340_RELOAD_PUSH = 53,
        WP1340_RELOAD_BACK = 54,
        WP1340_RELOAD_PULL = 55,
        WP1380_RELOAD_BLOWBACK = 56,
        WP1380_RELOAD_MAG_IN = 57,
        WP1380_RELOAD_MAG_OUT = 58,
        WP1380_RELOAD_MAG_PUSH = 59,
    };
}
namespace via::motion::IkLeg2 {
    enum FootLockType {
        MotionPos = 0,
        CurrentPos = 1,
        NoLockInterpolating = 2,
    };
}
namespace app::Em3600::Action::FourLegMoveTurn {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace via::network::wrangler {
    enum EventLatency {
        Undefined = 0,
        Normal = 1,
        RealTime = 2,
        ProviderDefault = 3,
    };
}
namespace via::navigation::Navigation {
    enum StopType {
        Arrived = 0,
        Blocked = 1,
        CallStop = 2,
        AroundAttribute = 3,
        AroundPortal = 4,
        Error = 5,
        OnNode = 6,
    };
}
namespace via {
    enum HardwareServiceCaps {
        None = 0,
        GeneralName = 1,
        InternalName = 2,
        CpuName = 4,
        Manufacturer = 8,
        BrandName = 16,
        IllegalDevice = 32,
        BatteryState = 64,
        BoardName = 128,
        Bootloader = 256,
        StorageSize = 512,
        ExternalStorageSize = 1024,
        PhysicalCoreNumber = 2048,
        LogicalCoreNumber = 4096,
        BaseFrequency = 8192,
        RamSize = 16384,
        ThermalState = 32768,
    };
}
namespace app::GameManager {
    enum PauseRequestType {
        None = 0,
        Title = 1,
        MenuSub = 2,
        MenuPause = 4,
        GameOver = 8,
        DebugCamera = 16,
        Dip = 32,
        SaveDataSave = 64,
        FSM = 128,
        SceneActivater = 256,
        ChapterJump = 512,
        Credit = 1024,
        VrModeChange = 2048,
        SystemCutin = 4096,
        NativeUiOverlaid = 8192,
        BirthdayResult = 16384,
        AccountChange = 32768,
        DebugGlobalVal = 65536,
        PlayGoCutin = 131072,
        SaveDataLoad = 262144,
    };
}
namespace app::CardGameObjectElectricMachine::BetFlip {
    enum StopNoDefine {
        Random = -1,
        NoDisp = 100,
    };
}
namespace app::Em4200Message {
    enum Tag {
        FirstLiquidBomb = 0,
    };
}
namespace via::clr {
    enum SignatureFlag {
        Generic = 16,
        HasThis = 32,
        ExplicitThis = 64,
    };
}
namespace via::wwise::FreeArea {
    enum FreeArea8to11 {
        FreeArea8to11_None = 4294967295,
        FreeArea8to11_8 = 8,
        FreeArea8to11_9 = 9,
        FreeArea8to11_10 = 10,
        FreeArea8to11_11 = 11,
    };
}
namespace via::render::fluid {
    enum TextureResourceType {
        Element1 = 0,
        Element2 = 1,
        Element4 = 2,
        Max = 3,
    };
}
namespace via::hid::mouse {
    enum ManipulatorClientTypeDev {
        Null = 0,
        WindowMessage = 3,
        GlobalParameter = 4,
        ToolDefault = 6,
    };
}
namespace via::render::layer::Overlay {
    enum PriorityOrder {
        CaptureSrcTex = 0,
        PushToEsram = 1,
        DrawDistortionSourceImage = 2,
        RenderToRenderTarget = 3,
        RenderToFrameBuffer = 4,
        PopFromEsram = 4294967295,
    };
}
namespace app::CH8_EffectChainMeshAnim {
    enum PlayTypeEnum {
        Once = 0,
        Loop = 1,
        Pause = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Grapple {
    enum Type {
        Mount = 0,
        AllFoursSmash = 1,
    };
}
namespace app::fsm::CH8PlayerStateCheck {
    enum PlayerIntType {
        None = 0,
        LoadNum = 1,
        NoGuardDamageChain = 2,
    };
}
namespace app::Em8940 {
    enum ThinkState {
        None = 0,
    };
}
namespace app::DebugEMActionChanger {
    enum Enemy_Type {
        em2000 = 0,
        em3000 = 1,
    };
}
namespace app::fsm::EnemyThinkAction {
    enum ActionOrderType {
        ActionSet = 0,
        ActionEnd = 1,
    };
}
namespace app::fsm::CH8SteelGateAction {
    enum ActionType {
        ManualOpen = 0,
    };
}
namespace app::CH8Em4400ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
    };
}
namespace via::landscape {
    enum SplatTextureType {
        Albedo = 0,
        NRRC = 1,
        Height = 2,
        Max = 3,
    };
}
namespace via::render {
    enum RegisterComponent {
        Unknown = 0,
        Uint32 = 1,
        Sint32 = 2,
        Float32 = 3,
    };
}
namespace via::areamap::test::RegionDensity {
    enum Condition {
        Densest = 0,
        Sparsest = 1,
    };
}
namespace via::gui::renderer::detail {
    enum PrimitiveShaderType {
        GUIPoly2D = 0,
        GUIPoly2DMask = 1,
        GUIPoly2DMaskReverse = 2,
        GUIPoly2DAdd = 3,
        GUIPoly2DAddMask = 4,
        GUIPoly2DAddMaskReverse = 5,
        GUIPoly2DDetone = 6,
        GUIPoly2DMaskDetone = 7,
        GUIPoly2DMaskReverseDetone = 8,
        GUIPoly2DAddDetone = 9,
        GUIPoly2DAddMaskDetone = 10,
        GUIPoly2DAddMaskReverseDetone = 11,
        GUIPoly2DStencil = 12,
        GUIPoly2DAddStencil = 13,
        GUIPoly2DPStencil = 14,
        GUIPoly2DAddPStencil = 15,
        GUIGlyph2D = 16,
        GUIGlyph2DMask = 17,
        GUIGlyph2DMaskReverse = 18,
        GUIGlyph2DAdd = 19,
        GUIGlyph2DAddMask = 20,
        GUIGlyph2DAddMaskReverse = 21,
        GUIGlyph2DDetone = 22,
        GUIGlyph2DMaskDetone = 23,
        GUIGlyph2DMaskReverseDetone = 24,
        GUIGlyph2DAddDetone = 25,
        GUIGlyph2DAddMaskDetone = 26,
        GUIGlyph2DAddMaskReverseDetone = 27,
        GUIGlyph2DStencil = 28,
        GUIGlyph2DAddStencil = 29,
        GUIGlyph2DPStencil = 30,
        GUIGlyph2DAddPStencil = 31,
        GUIPoly3D = 32,
        GUIPoly3DTest = 33,
        GUIPoly3DMask = 34,
        GUIPoly3DMaskTest = 35,
        GUIPoly3DMaskReverse = 36,
        GUIPoly3DMaskReverseTest = 37,
        GUIPoly3DAdd = 38,
        GUIPoly3DAddTest = 39,
        GUIPoly3DAddMask = 40,
        GUIPoly3DAddMaskTest = 41,
        GUIPoly3DAddMaskReverse = 42,
        GUIPoly3DAddMaskReverseTest = 43,
        GUIPoly3DDetone = 44,
        GUIPoly3DTestDetone = 45,
        GUIPoly3DMaskDetone = 46,
        GUIPoly3DMaskTestDetone = 47,
        GUIPoly3DMaskReverseDetone = 48,
        GUIPoly3DMaskReverseTestDetone = 49,
        GUIPoly3DAddDetone = 50,
        GUIPoly3DAddTestDetone = 51,
        GUIPoly3DAddMaskDetone = 52,
        GUIPoly3DAddMaskTestDetone = 53,
        GUIPoly3DAddMaskReverseDetone = 54,
        GUIPoly3DAddMaskReverseTestDetone = 55,
        GUIPoly3DTestStencilForDepth = 56,
        GUIPoly3DMaskTestStencilForDepth = 57,
        GUIPoly3DMaskReverseTestStencilForDepth = 58,
        GUIPoly3DAddTestStencilForDepth = 59,
        GUIPoly3DAddMaskTestStencilForDepth = 60,
        GUIPoly3DAddMaskReverseTestStencilForDepth = 61,
        GUIPoly3DTestCorrection = 62,
        GUIGlyph3D = 63,
        GUIGlyph3DTest = 64,
        GUIGlyph3DMask = 65,
        GUIGlyph3DMaskTest = 66,
        GUIGlyph3DMaskReverse = 67,
        GUIGlyph3DMaskReverseTest = 68,
        GUIGlyph3DAdd = 69,
        GUIGlyph3DAddTest = 70,
        GUIGlyph3DAddMask = 71,
        GUIGlyph3DAddMaskTest = 72,
        GUIGlyph3DAddMaskReverse = 73,
        GUIGlyph3DAddMaskReverseTest = 74,
        GUIGlyph3DDetone = 75,
        GUIGlyph3DTestDetone = 76,
        GUIGlyph3DMaskDetone = 77,
        GUIGlyph3DMaskTestDetone = 78,
        GUIGlyph3DMaskReverseDetone = 79,
        GUIGlyph3DMaskReverseTestDetone = 80,
        GUIGlyph3DAddDetone = 81,
        GUIGlyph3DAddTestDetone = 82,
        GUIGlyph3DAddMaskDetone = 83,
        GUIGlyph3DAddMaskTestDetone = 84,
        GUIGlyph3DAddMaskReverseDetone = 85,
        GUIGlyph3DAddMaskReverseTestDetone = 86,
        GUIGlyph3DTestStencilForDepth = 87,
        GUIGlyph3DMaskTestStencilForDepth = 88,
        GUIGlyph3DMaskReverseTestStencilForDepth = 89,
        GUIGlyph3DAddTestStencilForDepth = 90,
        GUIGlyph3DAddMaskTestStencilForDepth = 91,
        GUIGlyph3DAddMaskReverseTestStencilForDepth = 92,
        GUIGlyph3DTestCorrection = 93,
        GUIPolyPers = 94,
        GUIPolyPersTest = 95,
        GUIPolyPersMask = 96,
        GUIPolyPersMaskTest = 97,
        GUIPolyPersMaskReverse = 98,
        GUIPolyPersMaskReverseTest = 99,
        GUIPolyPersAdd = 100,
        GUIPolyPersAddTest = 101,
        GUIPolyPersAddMask = 102,
        GUIPolyPersAddMaskTest = 103,
        GUIPolyPersAddMaskReverse = 104,
        GUIPolyPersAddMaskReverseTest = 105,
        GUIGlyphPers = 106,
        GUIGlyphPersTest = 107,
        GUIGlyphPersMask = 108,
        GUIGlyphPersMaskTest = 109,
        GUIGlyphPersMaskReverse = 110,
        GUIGlyphPersMaskReverseTest = 111,
        GUIGlyphPersAdd = 112,
        GUIGlyphPersAddTest = 113,
        GUIGlyphPersAddMask = 114,
        GUIGlyphPersAddMaskTest = 115,
        GUIGlyphPersAddMaskReverse = 116,
        GUIGlyphPersAddMaskReverseTest = 117,
        GUIPoly2DMaskWrite = 118,
        GUIPoly3DMaskWrite = 119,
        GUIPoly3DMaskWriteTest = 120,
        GUIPolyPersMaskWrite = 121,
        GUIPolyPersMaskWriteTest = 122,
        GUIGlyph2DMaskWrite = 123,
        GUIGlyph3DMaskWrite = 124,
        GUIGlyph3DMaskWriteTest = 125,
        GUIGlyphPersMaskWrite = 126,
        GUIGlyphPersMaskWriteTest = 127,
        GUIPoly2DMaskWriteBlend2 = 128,
        GUIPoly3DMaskWriteBlend2 = 129,
        GUIPoly3DMaskWriteTestBlend2 = 130,
        GUIPolyPersMaskWriteBlend2 = 131,
        GUIPolyPersMaskWriteTestBlend2 = 132,
        GUIGlyph2DMaskWriteBlend2 = 133,
        GUIGlyph3DMaskWriteBlend2 = 134,
        GUIGlyph3DMaskWriteTestBlend2 = 135,
        GUIGlyphPersMaskWriteBlend2 = 136,
        GUIGlyphPersMaskWriteTestBlend2 = 137,
        GUIPoly2DMaskWriteBlend3 = 138,
        GUIPoly3DMaskWriteBlend3 = 139,
        GUIPoly3DMaskWriteTestBlend3 = 140,
        GUIPolyPersMaskWriteBlend3 = 141,
        GUIPolyPersMaskWriteTestBlend3 = 142,
        GUIGlyph2DMaskWriteBlend3 = 143,
        GUIGlyph3DMaskWriteBlend3 = 144,
        GUIGlyph3DMaskWriteTestBlend3 = 145,
        GUIGlyphPersMaskWriteBlend3 = 146,
        GUIGlyphPersMaskWriteTestBlend3 = 147,
        GUIBlurInstant2D = 148,
        GUIBlurInstant3D = 149,
        GUIBlurInstant3DTest = 150,
        GUIBlurGaussian2D = 151,
        GUIBlurGaussian3D = 152,
        GUIBlurGaussian3DTest = 153,
        GUIPoly2DBlendDisable = 154,
        GUIPoly3DBlendDisable = 155,
        GUIPolyPersBlendDisable = 156,
        Max = 157,
    };
}
namespace via::render::Stamp {
    enum StampChannelMask {
        All = 15,
        R = 1,
        G = 2,
        B = 4,
        A = 8,
        RG = 3,
        RB = 5,
        RA = 9,
        GB = 6,
        GA = 10,
        BA = 12,
        RGB = 7,
        RBA = 13,
        RGA = 11,
        GBA = 14,
        None = 0,
    };
}
namespace System::Diagnostics {
    enum DebuggerBrowsableState {
        Never = 0,
        Collapsed = 2,
        RootHidden = 3,
    };
}
namespace app::Em8000::Action::Em8000Dead {
    enum State {
        INVALID = -1,
        None = 0,
        Start = 1,
        End = 2,
        SUM = 3,
    };
}
namespace via::network::wrangler {
    enum FieldType {
        UnicodeString = 0,
        Int8 = 1,
        UInt8 = 2,
        Int16 = 3,
        UInt16 = 4,
        Int32 = 5,
        UInt32 = 6,
        Int64 = 7,
        UInt64 = 8,
        Float = 9,
        Double = 10,
        Boolean = 11,
        Binary = 12,
        GUID = 13,
        Pointer = 14,
        FILETIME = 15,
        SYSTEMTIME = 16,
        CountedUnicodeString = 17,
        IPv4 = 18,
        IPv6 = 19,
    };
}
namespace via::render::VolumeDecal {
    enum WholeBlendMode {
        None = 0,
        BaseColor = 1,
        Normal = 2,
    };
}
namespace via {
    enum AccountPickerTarget {
        Auto = 0,
        UnmanagedDevice = 1,
        LastInputDevice = 2,
    };
}
namespace app::Em4200::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em3000::IK::ProcessBase {
    enum TransitionChangeState {
        INVALID = -1,
        None = 0,
        Up = 1,
        Down = 2,
        SUM = 3,
    };
}
namespace app::Em4100::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Discovery = 2,
        UnDiscovery = 3,
        ClosedRoute = 4,
        IdleLostTarget = 5,
        Idle = 6,
        Follow = 7,
        Grapple = 8,
        Dodge = 9,
        WallAttack = 10,
        StrikeScratch = 11,
        StrikeJump = 12,
        StrikeLongJump = 13,
        StrikeDash = 14,
        AroundFlewover = 15,
        Door = 16,
        DoorOpen = 17,
        DoorOpen2 = 18,
        DoorClose = 19,
        DoorClose2 = 20,
        Move = 21,
        AppearAction = 22,
        IdleAction = 23,
        IdleLostTargetAction = 24,
        NoticeAction = 25,
        WallAttackAction = 26,
        StrikeScratchAction = 27,
        StrikeJumpAction = 28,
        StrikeLongJumpAction = 29,
        StrikeDashAction = 30,
        AroundFlewoverAction = 31,
        DodgeAction = 32,
        GrappleAction = 33,
    };
}
namespace via::autoplay::action::AutoAttack {
    enum Unit {
        Second = 0,
        Frame = 1,
    };
}
namespace via::os::PackReader {
    enum Source {
        Unknown = 0,
        Package = 1,
        DLC = 2,
        ProprietaryDLC = 3,
        Any = 4,
    };
}
namespace app::cutin::CutinProc3Scroll {
    enum InputMode {
        TextScroll = 0,
        PreSelectItem = 1,
        SelectItem = 2,
    };
}
namespace via::eq::Parser {
    enum Error {
        None = 0,
        Syntax = 1,
        InvalidUnaryOperator = 2,
        InvalidNumber = 3,
        InvalidVariable = 4,
        InvalidEquation = 5,
        MemoryInsufficient = 6,
        Critical = 7,
    };
}
namespace via::vr::psCamera {
    enum PSCameraCaptureFrameResult {
        OK = 1,
        OKNotFrameUpdated = 2,
        ErrorStoped = 2147483649,
        ErrorDeviceDisconnected = 2147483650,
        ErrorInternal = 2147487744,
    };
}
namespace app::InteractLongPressSendFSM {
    enum ProcStep {
        LongPressWait = 0,
        Success = 1,
        InteractInterruption = 2,
    };
}
namespace app::Em3000::Em8000CorpsebagManager {
    enum Group {
        Corpsebag = 0,
        CorpsebagShort = 1,
        CorpsebagNoBattle = 2,
        SUM = 3,
    };
}
namespace app::Em3600Zone {
    enum Type {
        None = 0,
        DropGrapple = 1,
        ShieldingSpot = 2,
        GrappleForbid = 3,
    };
}
namespace app::CarInGarage {
    enum Window {
        None = 0,
        Front = 1,
        FrontLeft = 2,
        RearLeft = 3,
        Rear = 4,
        RearRight = 5,
        FrontRight = 6,
    };
}
namespace via::wwise::WwiseGlobalUserVariablesValue {
    enum TypeKind {
        Unknown = 0,
        Boolean = 1,
        Int32 = 2,
        Uint32 = 3,
        Single = 4,
    };
}
namespace via::timeline {
    enum ExecuteGroup {
        ExecuteGroup_00 = 0,
        ExecuteGroup_01 = 1,
        ExecuteGroup_02 = 2,
    };
}
namespace app::CH9SM2644Movement {
    enum eMotionID {
        Invalid = -1,
        Idle = 0,
        Forward_Start = 30,
        Back_Start = 33,
        Left_Turn_End = 41,
        Right_Turn_End = 42,
        Move_Fowerd = 100,
        Move_Left = 110,
        Move_Right = 120,
        Move_Back = 130,
        Move_Blend = 1000,
    };
}
namespace via::areamap::test::RegionArea {
    enum Condition {
        Biggest = 0,
        Smallest = 1,
    };
}
namespace app::GameEventAction {
    enum PressPriorityType {
        Default = 0,
        SpecialFix = 1,
    };
}
namespace app::Em3002::Goal::Battle {
    enum Message {
        Non = 0,
        AppearEnd = 1,
        Battle1 = 2,
        Battle2 = 3,
        Battle3 = 4,
        Battle4 = 5,
    };
}
namespace via::timeline {
    enum PlayType {
        Normal = 0,
        LastKey = 1,
    };
}
namespace via::motion::detail {
    enum ChainCollisionType {
        Self = 0,
        Model = 1,
        Collider = 2,
        VGround = 3,
    };
}
namespace app::Telemetry {
    enum LostPartsType {
        Em4000Head = 0,
        Em4000LeftArm = 1,
        Em4000RightArm = 2,
        Em4000LeftLeg = 3,
        Em4000RightLeg = 4,
        Em4100Head = 5,
        Em4200Head = 6,
        Em4200LeftArm = 7,
        Em4200RightArm = 8,
        Em4200LeftLeg = 9,
        Em4200RightLeg = 10,
    };
}
namespace via::clr {
    enum VMObjType {
        Null = 0,
        Object = 1,
        Array = 2,
        String = 3,
        Delegate = 4,
        ValType = 5,
    };
}
namespace via::render::layer::ParticleLighting {
    enum Segment {
        Preprocess = 0,
        UpdateBuffer = 1,
    };
}
namespace app::fsm::CH8CountAddTest {
    enum TestTypeParam {
        CoinCounter = 0,
    };
}
namespace via::render {
    enum CloudShapeNoiseType {
        BaseShape = 0,
        Detail = 1,
        Max = 2,
    };
}
namespace app::fsm::ElevatorButtonAction {
    enum ActionType {
        DoorOpen = 0,
        DoorClose = 1,
        Call = 2,
    };
}
namespace via::clr {
    enum MethodFlag {
        AccessibilityMask = 7,
        PrivateScope = 0,
        Private = 1,
        FamANDAssem = 2,
        Assembly = 3,
        Family = 4,
        FamORAssem = 5,
        Public = 6,
        Static = 16,
        Final = 32,
        Virtual = 64,
        HideBySig = 128,
        NewSlot = 256,
        Abstract = 1024,
        SpecialName = 2048,
        PinvokeImpl = 8192,
        UnmanagedExp = 8,
        RTSpecialName = 4096,
        NoILAsmKeyword = 16384,
        ReqsecObj = 32768,
    };
}
namespace app::MotionDelegate {
    enum ExitModeEnum {
        OtherTag = 0,
        TransitionOfMotion = 1,
    };
}
namespace via::render {
    enum InstanceMask {
        Default = 1,
        Shadow = 2,
        Solid = 4,
        Transpatent = 8,
        AlphaMask = 16,
    };
}
namespace via::wwise::FreeArea {
    enum FreeArea12to15 {
        FreeArea12to15_None = 4294967295,
        FreeArea12to15_12 = 12,
        FreeArea12to15_13 = 13,
        FreeArea12to15_14 = 14,
        FreeArea12to15_15 = 15,
    };
}
namespace via::motion::JointExMultiRemapValue {
    enum ConstraintType {
        Outputs = 0,
        RotExpression = 1,
        Multi = 2,
        Aim = 3,
        Max = 4,
    };
}
namespace app::Em3000::Em3000ActionController::ProgramableTurnProcess {
    enum RatioUpdateType {
        Time = 0,
    };
}
namespace app::fsm::InGameContentAction {
    enum OperationTypeEnum {
        TimerStart = 0,
        TimerStop = 1,
        TimerReset = 2,
        ResetAll = 3,
        Max = 4,
    };
}
namespace app::fsm::CH8ChangeMapShutterState {
    enum ChangeMapShutterStateType {
        Close = 0,
        Open = 1,
    };
}
namespace via::hid::textInput {
    enum TextInputArgKindDetails {
        Common = 0,
        PlayStation4 = 1,
        PlayStation5 = 2,
    };
}
namespace app::CH9Credit {
    enum StepType {
        Logo = 0,
        Page = 1,
    };
}
namespace app::Em5400 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em5400::Goal::SideMove {
    enum MoveDirect {
        Left = 0,
        Right = 1,
    };
}
namespace via::navigation {
    enum WarningStatus {
        Enable = 0,
        EnableContinuous = 1,
        Disable = 2,
    };
}
namespace app::ExpansionData {
    enum Expansion {
        Dummy = 0,
        Max = 512,
    };
}
namespace app::CH8Em4200::Goal::CH8GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Fixed = 2,
        Wait = 3,
        Elevator = 4,
        Discovery = 5,
        UnDiscovery = 6,
        ClosedRoute = 7,
        IdleLostTarget = 8,
        Idle = 9,
        Follow = 10,
        Grapple = 11,
        MountTry = 12,
        Rush = 13,
        BreathSimple = 14,
        BreathForce = 15,
        Breath = 16,
        FixedBreath = 17,
        Door = 18,
        DoorOpen = 19,
        DoorOpen2 = 20,
        DoorClose = 21,
        DoorClose2 = 22,
        Move = 23,
        AppearAction = 24,
        IdleAction = 25,
        ElevatorAction = 26,
        RushAction = 27,
        SplashAction = 28,
        BreathSimpleAction = 29,
        BreathForceAction = 30,
        BreathAction = 31,
        MountTryAction = 32,
        GrappleAction = 33,
        LostHeadType = 34,
    };
}
namespace via::effect::vortexel {
    enum VelocityEmitType {
        Overwrite = 0,
        Acceleration = 1,
    };
}
namespace via::render::MultiInstanceMesh {
    enum BoundingBoxStrategyType {
        Static = 0,
        Skinning = 1,
        Max = 2,
    };
}
namespace app::RenderTargetTextureSerializer::SerializeProcess {
    enum RoutineNo {
        PreReserve = 0,
        CalcSize = 1,
        PrepareBuffer = 2,
        Stage = 3,
        Serialize = 4,
        Finish = 5,
    };
}
namespace app::CH8Em4000::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        NoUse_Low1 = 10,
        FromLow2_Speedy = 11,
        NoUse_Middle1 = 20,
        FromMiddle2_Micheal = 21,
        NoUse_Middle3 = 22,
        FromMiddle4_Speedy = 23,
        FromCeil1_High = 30,
        FromCeil2_Speedy = 31,
        NoUse_CrawlLow1 = 40,
        FromCrawlLow2_Speedy = 41,
        NoUse_CrawlMiddle1 = 50,
        FromCrawlMiddle2_Speedy = 51,
        NoUse_Mimicry1 = 60,
        Mimicry2_Lying = 61,
        Mimicry3_Stand = 62,
        NoUse_Mimicry4 = 63,
        NoUse_Mimicry5 = 64,
        FromMimicry = 70,
        FromCorpse = 80,
        FromMorgue = 90,
        FromFirst = 100,
        FromFirstStay = 101,
        Shout = 200,
        ShoutWait = 201,
        FromGround = 300,
        FromSurgicalTable = 400,
        Summon = 401,
    };
}
namespace app::EPVExpertPartsDamageData {
    enum DamagePartsEnum {
        Head = 0,
        Chest = 1,
        Stomach = 2,
        LeftUpperArm = 3,
        LeftLowerArm = 4,
        RightUpperArm = 5,
        RightLowerArm = 6,
        LeftThigh = 7,
        LeftShin = 8,
        RightThigh = 9,
        RightShin = 10,
        User0 = 11,
        User1 = 12,
        User2 = 13,
        User3 = 14,
        User4 = 15,
        User5 = 16,
        User6 = 17,
        User7 = 18,
        User8 = 19,
        User9 = 20,
        User10 = 21,
        User11 = 22,
        User12 = 23,
        User13 = 24,
        User14 = 25,
        User15 = 26,
        User16 = 27,
        User17 = 28,
        User18 = 29,
        User19 = 30,
        Anywhere = 31,
        Num = 32,
    };
}
namespace via::render {
    enum DistortionType {
        None = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::CH9Em7700::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Release = 2,
        Mimicry = 3,
        ExtraWait = 4,
        Destination = 5,
        Discovery = 6,
        UnDiscovery = 7,
        ClosedRoute = 8,
        IdleLostTarget = 9,
        Idle = 10,
        Follow = 11,
        Grapple = 12,
        SlashTry = 13,
        MiddleBiteTry = 14,
        NearBiteTry = 15,
        BiteCrawl = 16,
        StrikeUpper = 17,
        Strike = 18,
        StrikeCrawl = 19,
        Mouth = 20,
        StrikeDuctPursuit = 21,
        Dodge = 22,
        FirstAttack = 23,
        Door = 24,
        DoorOpen = 25,
        DoorOpen2 = 26,
        DoorClose = 27,
        DoorClose2 = 28,
        Move = 29,
        AppearAction = 30,
        IdleAction = 31,
        NoticeAction = 32,
        StrikeUpperAction = 33,
        StrikeAction = 34,
        StrikeCrawlAction = 35,
        StrikeDuctPursuitAction = 36,
        SlashTryAction = 37,
        MouthAction = 38,
        BiteCrawlAction = 39,
        NearBiteTryAction = 40,
        MiddleBiteTryAction = 41,
        ExtraBiteTryAction = 42,
        DodgeAction = 43,
        GrappleAction = 44,
        MimicryIdle = 45,
        MimicryRelease = 46,
        ExtraBiteTry = 47,
        WanderIdle = 48,
        WanderIdleAction = 49,
        WanderMove = 50,
    };
}
namespace app::fsm::CH8PlayerAction {
    enum PlayerActionType {
        None = 0,
        ForceCrawl = 1,
        LeftArmCut = 2,
        ForceSupine = 3,
    };
}
namespace via::motion::MotionAppendData {
    enum PropertyType {
        Unknown = 0,
        Enum = 1,
        Boolean = 2,
        Int8 = 3,
        Uint8 = 4,
        Int16 = 5,
        Uint16 = 6,
        Int32 = 7,
        Uint32 = 8,
        Int64 = 9,
        Uint64 = 10,
        Single = 11,
        Double = 12,
        C8 = 13,
        C16 = 14,
        Char = 14,
        String = 15,
        Struct = 16,
        Class = 17,
    };
}
namespace app::OptionMenu {
    enum ImageQuality_Value {
        ImageQuality_05 = 0,
        ImageQuality_06 = 1,
        ImageQuality_07 = 2,
        ImageQuality_08 = 3,
        ImageQuality_09 = 4,
        ImageQuality_10 = 5,
        ImageQuality_11 = 6,
        ImageQuality_12 = 7,
        ImageQuality_13 = 8,
        ImageQuality_14 = 9,
        ImageQuality_15 = 10,
        ImageQuality_16 = 11,
        ImageQuality_17 = 12,
        ImageQuality_18 = 13,
        ImageQuality_19 = 14,
        ImageQuality_20 = 15,
        ImageQuality_06111 = 16,
        ImageQuality_06666 = 17,
    };
}
namespace app::CH9Em6400Grapple {
    enum LerpScaleMode {
        LerpGrappleScale = 0,
        LerpOriginalScale = 1,
        None = 2,
    };
}
namespace app::Em4200ActionPoint {
    enum Type {
        DropPoint = 0,
    };
}
namespace app::CH9GauntletChargeGauge {
    enum eChargeLevel {
        NoCharge = 0,
        Level1 = 1,
        Level2 = 2,
        Max = 3,
    };
}
namespace via::render::VolumeDecal {
    enum Priority {
        Highest = 0,
        Higher = 1,
        High = 2,
        Middle = 3,
        Default = 4,
        Low = 5,
        Lower = 6,
        Lowest = 7,
        Max = 8,
    };
}
namespace app::InterpolationJointGroup {
    enum StateType {
        None = 0,
        Setup = 1,
        Reset = 2,
    };
}
namespace via::network::error {
    enum CauseRanking {
        Debug = 1,
        ActiveRelease = 2,
        NoEnoughMemory = 17,
        InvalidArgument = 18,
        NotProvided = 19,
        AlreadyInitialized = 20,
        NotInitialized = 21,
        EarlyDestruct = 22,
        NoDependentObject = 23,
        DataBroken = 24,
        DataLeftover = 25,
        DataMismatch = 26,
        SizeOverflow = 27,
        NumOverflow = 28,
        OutOfRange = 29,
        ContextNotStarted = 30,
        Abort = 49,
        Cancel = 50,
        Timeout = 65,
        DnsTimeout = 66,
        LowLevel = 81,
        NativeApi = 82,
        ServerResponse = 83,
        AppSuspend = 97,
        AppShutdown = 98,
    };
}
namespace via::gui {
    enum GlyphAtlasSize {
        Size512x512 = 0,
        Size1024x512 = 1,
        Size1024x1024 = 2,
        Size2048x1024 = 3,
        Size2048x2048 = 4,
        Size4096x2048 = 5,
        Size4096x4096 = 6,
    };
}
namespace via::motion::SymmetryMirrorData {
    enum AxisMirrorFlags {
        AxisFlags_X = 1,
        AxisFlags_Y = 2,
        AxisFlags_Z = 4,
        AxisFlags_Enable = 8,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraChannel {
        Left = 0,
        Right = 1,
        Max = 2,
    };
}
namespace app::Em3600Message {
    enum MessageTag {
        BossRoomEnter = 0,
        MountStart_v0 = 1,
        MountStart_v1 = 2,
        MountStart_v2 = 3,
        ChokeStart_v0 = 4,
        CellStart_v0 = 5,
        CellStart_v1 = 6,
        WindowStart_v0 = 7,
        WindowStart_v1 = 8,
        FloorStart_v0 = 9,
        FloorStart_v1 = 10,
        GrappleBite_v1 = 11,
        GrappleBiteHigh_v0 = 12,
        GrappleBiteHigh_v1 = 13,
        GrappleBiteHigh_v2 = 14,
        DeathThroes = 15,
        ChokeDeathThroes = 16,
        CellDeathThroes = 17,
        FloorDeathThroes = 18,
        WindowDeathThroes = 19,
        Damage_v0 = 20,
        Damage_v1 = 21,
        SearchPL_v0 = 22,
        SearchPL_v1 = 23,
        SearchPL_v2 = 24,
        SearchPL_v3 = 25,
        SearchPL_v4 = 26,
        SearchPL_v5 = 27,
        WalkWall_v0 = 28,
        WalkWall_v1 = 29,
        WalkWall_v2 = 30,
        GenerateSwagger_v0 = 31,
        GenerateSwagger_v1 = 32,
        GenerateSuccess_v1 = 33,
        LMFAO_v0 = 34,
        LMFAO_v1 = 35,
        DiscoveryPL_v0 = 36,
        DiscoveryPL_v1 = 37,
        SneakDiscovery_v0 = 38,
        SneakDiscovery_v1 = 39,
        SneakDiscovery_v2 = 40,
        SneakDiscoveryUp = 41,
        HighTension_v0 = 42,
        HighTension_v1 = 43,
        HighTension_v2 = 44,
        HighTension_v3 = 45,
        HighTension_v4 = 46,
        HighTension_v5 = 47,
    };
}
namespace via::render::PrimitiveMesh::Attribute {
    enum PipelineIndex {
        Default = 0,
        DistortionDepth = 1,
        Prepass = 2,
        Shadow = 3,
        DebugOverdraw = 4,
        DeferredLighting = 5,
        Max = 6,
    };
}
namespace app::DebugEMActionChanger {
    enum Chapter_Battle {
        Battle_c01_2 = 0,
        Battle_c01_4 = 1,
        Battle_c03_1 = 2,
        Battle_c03_1_Finish = 3,
    };
}
namespace System {
    enum MidpointRounding {
        ToEven = 0,
        AwayFromZero = 1,
    };
}
namespace via::vr::psCamera {
    enum PSCameraScaleFormat {
        YUV422 = 0,
        Y16 = 3,
        Y8 = 4,
        NO_USE = 16,
        UNKNOWN = 255,
    };
}
namespace via::puppet::RemoteGameObject {
    enum SyncOption {
        ReceiveTransform = 0,
        TrailTransform = 1,
        ReceiveBehaviorTree = 2,
        ReceiveMotionFSM = 3,
        ReceiveMotionFSM_Variables = 4,
        ReceiveMotionFSM_Transform = 5,
        ReceiveMotionJackFSM = 6,
        ReceiveMotionJackFSM_Variables = 7,
        ReceiveMotionJackFSM_Transform = 8,
        ReceiveGlobalTransform = 9,
        Num = 10,
    };
}
namespace app::CH9SaveMenu {
    enum ModeType {
        Load = 0,
        Save = 1,
    };
}
namespace app::MoveCharacter {
    enum TEST_RE_STATE_PITCH {
        PITCH_DOWN = 0,
        PITCH_NORMAL = 1,
    };
}
namespace app::Cp7GameEndControl {
    enum Step {
        StartClear = 0,
        WaitClear = 1,
        StartResult = 2,
        WaitResult = 3,
        GoToMainMenu = 4,
        GoToRetry = 5,
        Max = 6,
    };
}
namespace app::Achievement {
    enum HeroStatsID {
        ClearGame = 0,
        KillEnemy = 1,
        GetItem = 2,
    };
}
namespace via::render::ToneMapping {
    enum TemporalAA {
        Legacy = 0,
        Manual = 1,
        Weak = 2,
        Mild = 3,
        Strong = 4,
        Disable = 5,
    };
}
namespace via::render {
    enum DrawMode {
        Default = 1,
        ShadowCast = 2,
        Envmap = 4,
        Voxelize = 8,
        PreCompute = 16,
    };
}
namespace via::render::layer {
    enum GBufferSegment {
        ZIgnorePrepassSolid = 0,
        ZIgnorePrepassTwoSide = 1,
        ZIgnorePrepassTwoSideAlphaTest = 2,
        ZIgnorePrepassAlphaTest = 3,
        StencilPrioritySolid = 4,
        ZPrepassSolid = 5,
        ZPrepassTwoSide = 6,
        ZPrepassTwoSideAlphaTest = 7,
        ZPrepassAlphaTest = 8,
        ZPrepassVfx = 9,
        GroundSolid = 10,
        Solid = 11,
        TwoSide = 12,
        DefaultZPrepass = 13,
        TwoSideAlphaTest = 14,
        AlphaTest = 15,
        EmissiveMask = 16,
        EmissiveSolid = 27,
        EmissiveTwoSide = 28,
        EmissiveTwoSideAlphaTest = 30,
        EmissiveAlphaTest = 31,
        MeshDecal = 32,
        DepthWrite = 33,
        DepthWrittenSolid = 34,
        ViewScaling = 35,
        ViewScalingSolid = 36,
        DecalPrepare = 39,
        DisplacementPrepare = 40,
        Displacement = 41,
        PreDecalBlend = 42,
        PreDecalDepthOnly = 43,
        Decal = 44,
        PostDecalBlend = 45,
        PostDecalDepthOnly = 46,
        DepthWritePostDecal = 48,
        DepthWrittenSolidPostDecal = 49,
        ViewScalingPostDecal = 50,
        ViewScalingSolidPostDecal = 51,
        ZIgnoreStencilSolid = 54,
        ZIgnoreStencilTwoSide = 55,
        ZIgnoreStencilTwoSideAlphaTest = 56,
        ZIgnoreStencilAlphaTest = 57,
    };
}
namespace via::motion::JointExMultiRemapValue::OutputData::JointDriverData {
    enum InfinityType {
        Const = 0,
        Linear = 1,
        Oscilate = 2,
        Cycle = 3,
        CycleRelative = 4,
    };
}
namespace via::os {
    enum MemoryPage {
        Default = 0,
        Large = 1024,
    };
}
namespace app::PlayerTerrainMoveChecker {
    enum CheckFallResult {
        None = 0,
        Success = 1,
        Failure_TooLow = 2,
        Failure_PositionRecovered = 3,
        Failure_TooHigh = 4,
    };
}
namespace via::render {
    enum PerPixelLightCorrectType {
        None = 0,
        UseSceneTex = 1,
    };
}
namespace via::render {
    enum RenderOutputID {
        Primary = 1,
        Secondary = 2,
        Tertiary = 4,
        Quateary = 8,
        Quinary = 16,
        All = 31,
    };
}
namespace via::landscape {
    enum BakerPriority {
        ClearRenderTarget = 0,
        Bake = 1,
    };
}
namespace app::DebugDrawJoint {
    enum ColorDef {
        Default = 0,
        White = 1,
        Gray = 2,
        LtGray = 3,
        Red = 4,
        Blue = 5,
        Cyan = 6,
        Magenta = 7,
        Yellow = 8,
    };
}
namespace via::render::TextureScaler {
    enum DebugDrawModeType {
        RGBA = 0,
        RGB = 1,
    };
}
namespace app::cutin::CutinHandle3Choice {
    enum ResultDef {
        Select1 = 0,
        Select2 = 1,
        Select3 = 2,
        Undecided = 3,
    };
}
namespace via::motion {
    enum MotionStateFlag {
        None = 0,
        EndFrame = 1,
        NextEndFrame = 2,
        LoopHead = 4,
        LoopTail = 8,
        BlockEnd = 16,
        NextBlockEnd = 32,
        Setup = 128,
    };
}
namespace app::wwise::WwiseOptionMenu {
    enum DynamicRangeControl {
        Small = 0,
        Large = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum TutorialLineTable {
        ON = 0,
        OFF = 1,
    };
}
namespace via::render {
    enum SparseShadowTreeReductionPixel {
        SparseShadowTreeReductionPixel_None = 0,
        SparseShadowTreeReductionPixel_2px = 2,
        SparseShadowTreeReductionPixel_4px = 4,
        SparseShadowTreeReductionPixel_8px = 8,
        SparseShadowTreeReductionPixel_16px = 16,
        SparseShadowTreeReductionPixel_24px = 24,
        SparseShadowTreeReductionPixel_32px = 32,
        SparseShadowTreeReductionPixel_64px = 64,
        SparseShadowTreeReductionPixel_128px = 128,
    };
}
namespace app::fsm::PositionCheck {
    enum DirectionTypeEnum {
        Front = 0,
        Back = 1,
        Left = 2,
        Right = 3,
    };
}
namespace app::Em4100::Action {
    enum ActionNo {
        Attack = 4,
        StrikeScratch = 5,
        StrikeDash = 6,
        StrikeJump = 7,
        StrikeLongJump = 8,
        StrikeBackblow = 9,
        StrikeToGuard = 10,
        WallAttack = 11,
        Backstep = 12,
        ChanceCounter = 13,
        BlownAway = 14,
        SlipFire = 15,
        SlipAcid = 16,
        Notice = 17,
        Threat = 18,
        Dodge = 19,
        DamageToMove = 20,
        Climb = 21,
        AroundFlewover = 22,
        Grapple = 23,
        Appear = 24,
        Falling = 25,
        Suspend = 26,
        Resume = 27,
    };
}
namespace via::render {
    enum LightingTarget {
        Scene = 1,
        Bake = 2,
        All = 3,
    };
}
namespace app::CharacterExistActionRestrictZoneGroup::ActionRestrictWork {
    enum Type {
        Em4000Grapple = 0,
        Em4100WallAttack = 1,
        Em4100AroundFlewover = 2,
        Em4200Grapple = 3,
        Em4300Grapple = 4,
        Em4200Walk = 5,
    };
}
namespace via::sound {
    enum SamplesPerAudioFrame {
        SamplesPerAudioFrame_32 = 32,
        SamplesPerAudioFrame_64 = 64,
        SamplesPerAudioFrame_128 = 128,
        SamplesPerAudioFrame_256 = 256,
        SamplesPerAudioFrame_512 = 512,
        SamplesPerAudioFrame_1024 = 1024,
        SamplesPerAudioFrame_2048 = 2048,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1Final {
    enum RideCarStatus {
        Non = 0,
        GotoRideCar = 1,
        CanRideCar = 2,
        RideCarEnd = 3,
    };
}
namespace app::Em3100::Action::PatrolBugInstruct {
    enum State {
        INVALID = 0,
        Start = 1,
        Loop = 2,
        End = 3,
    };
}
namespace via {
    enum TimeFormat {
        H12 = 0,
        H24 = 1,
        Max = 2,
        Unknown = 2,
    };
}
namespace app::Collision {
    enum SideType {
        None = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::GameManager {
    enum Phase {
        Setup = 0,
        Entry = 1,
        stStoreActivateGameOverlayInit = 2,
        stStoreActivateGameOverlay = 3,
        stStoreActivateGameOverlayWait = 4,
        xboMarketplaceCheckPrivilege = 5,
        xboMarketplaceCheckPrivilegeWait = 6,
        xboMarketplaceShowInit = 7,
        xboMarketplaceShow = 8,
        xboMarketplaceShowDetailsInit = 9,
        xboMarketplaceShowDetails = 10,
        xboMarketplaceWait = 11,
        npCommerceDialogInit = 12,
        npCommerceDialog = 13,
        npCommerceDialogWait = 14,
        ps5SonyCommerceDialog = 15,
        msgStoreShowInit = 16,
        msgStoreShow = 17,
        networkPreInit = 18,
        networkPreInit2 = 19,
        networkInit = 20,
        networkInitWait = 21,
        httpClientInit = 22,
        httpClientInitWait = 23,
        npAuthCodeInit = 24,
        npAuthCodeReq = 25,
        npAuthCodeWait = 26,
        ps5AuthCodeInit = 27,
        ps5AuthCodeReq = 28,
        ps5AuthCodeWait = 29,
        uwpTokenAndSignatureInit = 30,
        uwpTokenAndSignatureGet = 31,
        uwpTokenAndSignatureWait = 32,
        stAuthSessionTicketInit = 33,
        stAuthSessionTicketGet = 34,
        stAuthSessionTicketWait = 35,
        renetPost = 36,
        renetPostWait = 37,
        BrowserSetupContext = 38,
        BrowserSetup = 39,
        BrowserOpen = 40,
        BrowserOpenWait = 41,
        BrowserFinalize = 42,
        BrowserFinalizeContext = 43,
        SetupStorage = 44,
        StorageGetInfo = 45,
        StorageGetInfoWait = 46,
        StorageOpenWait = 47,
        StorageOpen = 48,
        StorageReadWait = 49,
        FinalizeContext = 50,
    };
}
namespace via::fsm::Core {
    enum WorkAttribute {
        WorkAttributeSelectBeforeAction = 0,
        WorkAttributeBitNum = 32,
    };
}
namespace app::Em8000::Override::Em8000OverrideController {
    enum BlendState {
        None = 0,
        StartBlend = 1,
        Blend = 2,
        EndBlend = 3,
    };
}
namespace app::AI::MansionAIEffectorZoneGroup {
    enum EffectorTypeEnum {
        ForbidDespawn = 0,
    };
}
namespace app::CarInGarage::WheelSpinStart {
    enum Routine {
        RevUp = 0,
        IdleSpin = 1,
        Accel = 2,
        Decel = 3,
        DecelAndFollow = 4,
        Damaged = 5,
    };
}
namespace app::BirthdayFood {
    enum MapIconTypeDef {
        BirthdayFood = 50,
    };
}
namespace app::CH9Em7500::Action::Dive {
    enum Type {
        Normal = 0,
        Into = 1,
    };
}
namespace via::wwiselib {
    enum AudioAPIType {
        AudioAPI_Default = 0,
        AudioAPI_XAudio2 = 1,
        AudioAPI_WASAPI = 2,
    };
}
namespace app::CH9InGameContentTimer {
    enum ContentTypeEnum {
        Chp9BossClearTime = 0,
        Chp9CrocodileBattle = 1,
        Chp9MissionNo01 = 2,
        Chp9MissionNo02 = 3,
        Chp9MissionNo03 = 4,
        Chp9MissionNo04 = 5,
        Chp9MissionNo06 = 6,
        Chp9MissionNo07 = 7,
        Chp9MissionNo08 = 8,
        Chp9MissionNo09 = 9,
        Max = 10,
    };
}
namespace via::motion::IkJacobian {
    enum MomentumModeType {
        Zero = 0,
        Animation = 1,
        TargetPos = 2,
    };
}
namespace app::CH9Em7900::ThinkStateSet {
    enum Type {
        Default = 0,
        Fixed = 1,
        Wanderer = 2,
        Wait = 3,
        Elevator = 4,
    };
}
namespace via::gui {
    enum MouseButton {
        NONE = 0,
        L = 1,
        R = 2,
        C = 4,
        UP = 8,
        DOWN = 16,
        EX0 = 32,
        EX1 = 64,
    };
}
namespace app::Em3102::Goal::BattleRest {
    enum LeaveStatus {
        Non = 0,
        Leave = 1,
        Arrive = 2,
    };
}
namespace app::CH8Em4500AimEvaluatorMarker {
    enum MarkerPartsType {
        Head = 0,
        Body = 1,
    };
}
namespace app::Nightmare::NightmareTrapManager::TrapTask {
    enum State {
        None = 0,
        WaitCraft = 1,
        Active = 2,
        Deactive = 3,
        DestroyAble = 4,
        Destroy = 5,
    };
}
namespace app::AI::MansionAIEvaluationParameter {
    enum VisibleType {
        None = 0,
        Visible = 1,
        Invisible = 2,
    };
}
namespace via::effect::detail {
    enum MaterialParameterType {
        None = 0,
        Float = 1,
        Range = 2,
        Texture = 3,
    };
}
namespace via::render::LightVolumeDecal {
    enum BaseAlphaMapType {
        BaseAlpha = 0,
        Msk1ch = 1,
    };
}
namespace app::CH9Em6400ActionController {
    enum WwiseSwitchListForDamage {
        Head = 0,
        Other = 1,
    };
}
namespace app::CH8Em4100ActionPoint {
    enum Type {
        ClimbWall40 = 0,
        ClimbWall79 = 1,
        ClimbWall80 = 2,
        ClimbWall119 = 3,
        ClimbOver80 = 4,
        ClimbOver119 = 5,
        Climb2Fto1F = 6,
        Climb1Fto2F = 7,
        Climb2Fto2F = 8,
    };
}
namespace via::navigation::QueryObject {
    enum WorkAttribute {
        MapChanged = 0,
        WorkAttributeNum = 1,
    };
}
namespace app::CH8Em4400ActionController {
    enum MeshParts {
        Parts0 = 0,
        Parts1 = 1,
        Parts2 = 2,
        Parts3 = 3,
        Parts4 = 4,
        Parts5 = 5,
        Parts6 = 6,
        Parts7 = 7,
    };
}
namespace app::Em8000ZoneGroup {
    enum Property {
        INVALID = -1,
        None = 0,
        AroundPillar = 1,
    };
}
namespace via::landscape {
    enum InterpolateType {
        Liner = 0,
        Bezier = 1,
        Spline = 2,
    };
}
namespace via::network {
    enum ServiceType {
        None = 0,
        Lamm = 1,
        Steam = 2,
        WeGame = 3,
        Psn = 4,
        Live = 5,
        Live_UWP = 6,
        PiaLocal = 7,
        PiaInet = 8,
        Nex = 9,
        Npln = 10,
        Star = 11,
        Ggp = 12,
        Ps5Psn = 13,
        Rebe = 14,
        Live_GDK = 15,
        Solstice = 16,
        Max = 17,
    };
}
namespace app::EffectShakeCamera {
    enum ShakeTypeEnum {
        Small = 1,
        Large = 2,
    };
}
namespace via::render {
    enum AtmosphericDirectionalLight {
        None = 0,
        Enabled = 1,
    };
}
namespace app::BirthdayTransitionController {
    enum StageJumpStepEnum {
        PreScenedeActivateWait = 0,
        WaitActivatePlayer = 1,
        WaitActivateStageSet = 2,
        FadeOut = 3,
        ActivateStageStatic = 4,
        WaitActivateStageStatic = 5,
        WaitEnableActivater = 6,
        EnableActivater = 7,
        End = 8,
    };
}
namespace CH9Em7900Effect {
    enum IDAlias {
        Explosion = 0,
        Splash = 1,
        VerticalSplash = 2,
        HorizontalSplash = 3,
        LostHead = 4,
        LostLeftArm = 5,
        LostRightArm = 6,
        LostLeftLeg = 7,
        LostRightLeg = 8,
        StandSplashFromSequence = 9,
        WalkSplashFromSequence = 10,
        CrawlSplashFromSequence = 11,
        SimpleSplashFromSequence = 12,
        GrappleSplashFromSequence = 13,
        SelfSplashFromSequence = 14,
        StunSplashFromSequence = 15,
    };
}
namespace via::gui::detail {
    enum ControlPointH {
        Left = 0,
        Center = 1,
        Right = 2,
    };
}
namespace via::simplewwise {
    enum User {
        User_0 = 0,
        User_1 = 1,
        User_2 = 2,
        User_3 = 3,
        User_None = 4,
    };
}
namespace via::wwise::WwiseFloatEnumConverterElement {
    enum FloatEnum {
        FloatEnum_0 = 0,
        FloatEnum_1 = 1,
        FloatEnum_2 = 2,
        FloatEnum_3 = 3,
        FloatEnum_4 = 4,
        FloatEnum_5 = 5,
        FloatEnum_6 = 6,
        FloatEnum_7 = 7,
        FloatEnum_8 = 8,
        FloatEnum_9 = 9,
        FloatEnum_Max = 10,
    };
}
namespace app::CH9PurifierEquipment {
    enum EffectTypeEnum {
        Numa1 = 0,
        Numa2 = 1,
        Numa3 = 2,
        Numa4 = 3,
        Max = 4,
    };
}
namespace via::render {
    enum RtvDimension {
        Unknown = 0,
        Buffer = 1,
        Texture1d = 2,
        Texture1darray = 3,
        Texture2d = 4,
        Texture2darray = 5,
        Texture2dms = 6,
        Texture2dmsarray = 7,
        Texture3d = 8,
    };
}
namespace app::Em8000::Em8000Define::WpScissors {
    enum State {
        Idle = 0,
        Start = 1,
        Loop = 2,
        End = 3,
        INVALID = 4,
    };
}
namespace app::AI::CH8MoldedCommonBoard {
    enum RenderTargetType {
        Slow = 0,
        WhiteSlow = 1,
        Quick = 2,
        Fat = 3,
        Mother = 4,
        Perfect = 5,
    };
}
namespace app::InteractCardanGrille {
    enum CardanState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        SuccessInit = 3,
        SuccessCameraMove = 4,
        SuccessCardIn = 5,
        SuccessWait = 6,
        SuccessEnd = 7,
        NotSuccess = 8,
        Close = 9,
        Exit = 10,
        NotSuccessExit = 11,
    };
}
namespace via::gui {
    enum GridPos {
        LT = 0,
        CT = 1,
        RT = 2,
        LC = 3,
        CC = 4,
        RC = 5,
        LB = 6,
        CB = 7,
        RB = 8,
    };
}
namespace app::Em5400::Action::Dead {
    enum Type {
        Fall = 0,
        Disperse = 1,
    };
}
namespace app::Command {
    enum CommandType {
        ButtonTrigger = 0,
        ButtonDown = 1,
        ButtonRelease = 2,
        AnalogButton = 3,
        Stick = 4,
        AnyCommandNotSatisfied = 5,
        NecessaryCommand = 6,
        NotSatisfiedCommand = 7,
        FlickStick = 8,
        Platform = 9,
        KeyBindTrigger = 10,
        KeyBindDown = 11,
        KeyBindRelease = 12,
        KeyBindDirection4 = 13,
        KeyBindDirection2 = 14,
    };
}
namespace via::timeline {
    enum PauseGroup {
        PauseGroup_00 = 0,
        PauseGroup_01 = 1,
        PauseGroup_02 = 2,
        PauseGroup_03 = 3,
        PauseGroup_04 = 4,
        PauseGroup_05 = 5,
        PauseGroup_06 = 6,
        PauseGroup_07 = 7,
        PauseGroup_08 = 8,
        PauseGroup_09 = 9,
    };
}
namespace app::Em3001::Action::Turn {
    enum Type {
        Fast = 0,
        Move = 1,
    };
}
namespace app::Em8010::Em8010Core {
    enum Order {
        None = 0,
        Open = 1,
        OpenGrapple = 2,
        Close = 3,
        DeactivateWithDead = 4,
        Damage = 5,
        CuttingFinal = 6,
        NormalFinal = 7,
    };
}
namespace via::render {
    enum TargetFlag {
        None = 0,
        NeedIDBuffer = 1,
        Num = 2,
    };
}
namespace via::effect::detail {
    enum AxisType {
        PositiveX = 0,
        PositiveY = 1,
        PositiveZ = 2,
        NegativeX = 3,
        NegativeY = 4,
        NegativeZ = 5,
    };
}
namespace app::CH9Em6400::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        OutRange = 1,
        InRange = 2,
        Front = 3,
        FrontFromTarget = 4,
        RightFromTarget = 5,
        LeftFromTarget = 6,
        IsWanderIntervalTimer = 7,
        CanGrapple = 8,
        HasAttackRight = 9,
        IsCanTurn = 10,
    };
}
namespace via::render {
    enum ClearType {
        RTV = 0,
        UAVUint = 1,
        UAVFloat = 2,
        DSV = 3,
        DELAY = 128,
        DELAYMASK = 127,
        RTV_DELAY = 128,
        UAVUint_DELAY = 129,
        UAVFloat_DELAY = 130,
        DSV_DELAY = 131,
    };
}
namespace via::gui::renderer::detail {
    enum ConstantBufferType {
        None = 0,
        Polygon3D = 1,
        Polygon2D = 2,
        Mesh = 3,
        Lensflare = 4,
    };
}
namespace via::motion::JointExBsplineConstraint {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
        NX = 3,
        NY = 4,
        NZ = 5,
    };
}
namespace via::hid::HIDEntry {
    enum EnterButton {
        RRight = 1,
        RDown = 2,
        SystemSetting = 3,
    };
}
namespace app::fsm::CH8ElevatorButtonAction {
    enum ActionType {
        DoorOpen = 0,
        DoorClose = 1,
        Call = 2,
    };
}
namespace via::render::VolumetricFogControl {
    enum IntegrationType {
        Blurry = 0,
        Accurate = 1,
    };
}
namespace via::dynamics::RagdollConstraint::Initializer {
    enum PositionType {
        World = 0,
        Local = 1,
    };
}
namespace app::GameOverScreen {
    enum ListElemID {
        Restart = 0,
        End = 1,
    };
}
namespace app::CH9EndingControl {
    enum Flow {
        ReadyWait = 0,
        Movie = 1,
        Credit = 2,
        Result = 3,
        Unlock = 4,
        End = 5,
    };
}
namespace app::Em3100::Action::WalkLookBack {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH8Em4400::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
    };
}
namespace app::CH9SM2644Movement {
    enum eEngineState {
        Stop = 0,
        Driving = 1,
    };
}
namespace via::motion::IkMultipleDamageAction {
    enum Calculation {
        Default = 0,
        AddDirection = 1,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum Spp {
        Spp_1 = 0,
        Spp_2 = 1,
        Spp_4 = 2,
    };
}
namespace app::GameManager {
    enum StandbyFolderNo {
        Chapter123 = 0,
        Chapter324 = 1,
        Chapter3 = 2,
        Chapter4 = 3,
        Chapter1 = 4,
        MAX = 5,
    };
}
namespace via::effect::gpgpu::DeformedMesh::MeshCsResource {
    enum SkinningType {
        None = 0,
        Weight4 = 1,
        Weight6 = 2,
        Weight8 = 3,
        Weight12 = 4,
        Max = 5,
    };
}
namespace app::JunkPartsUIAsset {
    enum LostPartsState {
        DEFAULT = 0,
        FADE_IN = 1,
        FADE_OUT = 2,
        DISABLE = 3,
    };
}
namespace app::Em3002::Action::Rest {
    enum Type {
        Rest1 = 0,
        Rest2 = 1,
        Rest3 = 2,
    };
}
namespace via::network::wrangler {
    enum ProviderPriority {
        Undefined = 0,
        Normal = 1,
        Critical = 2,
    };
}
namespace via::collision::detail {
    enum CalcToiRet {
        NoHit = 0,
        HitNoMove = 1,
        HitCcd = 2,
    };
}
namespace via::render {
    enum GeometryAOQuality {
        Low = 0,
        Middle = 1,
    };
}
namespace via::motion::IkSpineConformGround {
    enum COG_MANAGE_TYPE {
        INTERNAL = 0,
        EXTERNAL = 1,
    };
}
namespace app::Em3600::Action {
    enum ActionNo {
        Idle = 0,
        TwoLegMove = 1,
        TwoLegStrafeMove = 2,
        FourLegMove = 3,
        TwoLegMoveBack = 4,
        FourLegMoveBack = 5,
        FourLegMoveLeft = 6,
        FourLegMoveRight = 7,
        FourLegRevMove = 8,
        FourLegRevStart = 9,
        FourLegRevEnd = 10,
        PoseChange = 11,
        Menace = 12,
        Turn = 13,
        Attack = 14,
        ComboAttack = 15,
        Damage = 16,
        Dead = 17,
        GrappleAttack = 18,
        Grapple = 19,
        Climb = 20,
        Descend = 21,
        Hide = 22,
        Appear = 23,
        Sneak = 24,
        SneakDamage = 25,
        SneakEnd = 26,
        WallUp = 27,
        WallDown = 28,
        Jump = 29,
        Generate = 30,
        WallAttack = 31,
        Step = 32,
        BackJump = 33,
        CellJump = 34,
        DoorOpen = 35,
        Fall = 36,
        ExMove = 37,
        FourLegMoveTurn = 38,
        Suspend = 39,
    };
}
namespace via::hid::HIDEntry {
    enum KeyboardCooperativeLevel {
        Background = 0,
        Foreground = 1,
        ForegroundNoWinKey = 2,
        ForegroundExclusive = 3,
    };
}
namespace via::network::error {
    enum MethodInvitation {
        Update = 0,
        Accept = 1,
        Join = 2,
    };
}
namespace via::os::asyncTaskQueue {
    enum WorkType {
        Work = 0,
        Complete = 1,
    };
}
namespace via::navigation {
    enum UpdateTiming {
        Default = 0,
        Prev = 1,
        Late = 2,
    };
}
namespace app::fsm::StateCheck {
    enum IntType {
        None = 0,
        Life = 1,
    };
}
namespace via::render::RenderTargetTextureResource {
    enum ResolutionType {
        Absolute = 0,
        Relative = 1,
    };
}
namespace app::Chain::ContactSettingParameter {
    enum ContactLevel {
        Small = 0,
        Middle = 1,
        Large = 2,
        MAX = 3,
    };
}
namespace app::OptionMenu {
    enum OptionPage {
        Brightness = 0,
        Screen = 1,
    };
}
namespace app::AI::CH9AIWorldBlackBoard {
    enum MoldedStateEnum {
        FULL = 0,
        LAYER = 1,
        BASS = 2,
        ENCOUNT = 3,
        LOST_PL = 4,
        INTENSITY = 5,
        SILENCE = 6,
    };
}
namespace app::EPVExpertWeaponLandingData {
    enum ZDirectionType {
        Random = 0,
        AttackDirection = 1,
        SawRotation = 2,
    };
}
namespace via::simpleJson::Base::SuffixType {
    enum TypeCode {
        Empty = 0,
        StrC8 = 1,
        SizeT = 2,
    };
}
namespace app::AI::MoldedCommonBoard {
    enum RenderTargetStatusEnum {
        None = 0,
        Used = 1,
        UsedFromDead = 2,
    };
}
namespace via::clr {
    enum SignatureModFlag {
        Ptr = 1,
        ByRef = 2,
        ValueType = 4,
        Class = 8,
        Var = 16,
        Array = 32,
        GenericInst = 64,
        FNPTr = 128,
        SzArray = 256,
        MVar = 512,
        CModReqd = 1024,
        CModOpt = 2048,
        Stencil = 4096,
        Pinned = 8192,
    };
}
namespace via::timeline::DialogueTimelinePlayer {
    enum DevPlayState {
        Disable = 0,
        Play = 1,
        Pause = 2,
    };
}
namespace via::effect::detail {
    enum Rotate90 {
        None = 0,
        Rotate = 1,
        RandomRotate = 2,
    };
}
namespace via::render::layer::Transparent {
    enum SegmentOrder {
        PreTransparent = 0,
        PreNoDepthStencil = 1,
        Transparent = 2,
        PrepareMixedTransparent = 3,
        MixedTransparent = 4,
        PostMixedTransparent = 5,
        LightShaft = 6,
        PreparePostTransparent = 7,
        PostTransparent = 8,
        TransparentZPostPass = 9,
        ZPrepass = 10,
        Vortexel = 11,
        RoughTransparent = 12,
        Distortion = 13,
        PostDistortion = 14,
        Haze = 15,
        PostNoDepth = 16,
        Deinterlace = 17,
        AfterDeinterlace = 18,
        Lensflare = 19,
        Primitive2D = 20,
        TransparentOverlay = 21,
        BlendBuffer = 22,
    };
}
namespace via::landscape::GroundManager {
    enum GroundPipelineStateType {
        CSUpdateVirtualTexture2 = 0,
        CSBuildGroundNodeList = 1,
        CSClearGroundNodeList = 2,
        CSClearGroundDrawIndirectArgs = 3,
        CSUpdateGroundLodMap = 4,
        CSBuildVisibleRenderNodeList = 5,
        CSBuildVisibleRenderNodeListEdit = 6,
        DrawGroundNodesNear = 7,
        DrawGroundNodesNoBlendNear = 8,
        DrawGroundNodesBilinearNear = 9,
        DrawGroundNodesFar = 10,
        DrawGroundNodesNoBlendFar = 11,
        DrawGroundNodesBilinearFar = 12,
        DrawGroundNodesShadows = 13,
        DrawGroundNodesShadowsNoFaceCulling = 14,
        CSWarmingPhysicalTexture = 15,
        DrawGroundNodesNearWithEditLayer = 16,
        DrawGroundNodesNoBlendNearWithEditLayer = 17,
        DrawGroundNodesBilinearNearWithEditLayer = 18,
        DrawGroundNodesFarWithEditLayer = 19,
        DrawGroundNodesNoBlendFarWithEditLayer = 20,
        DrawGroundNodesBilinearFarWithEditLayer = 21,
        DrawGroundNodesShadowsWithEditLayer = 22,
        DrawGroundNodesShadowsNoFaceCullingWithEditLayer = 23,
        DrawGroundNodesPick = 24,
        DrawGroundNodesOutline = 25,
        DrawGroundNodesWireframe = 26,
        DrawGroundNodesFilledWireframe = 27,
        DrawGroundNodesMaterialDebug = 28,
        DrawGroundNodesLodDebug = 29,
        DrawTexture = 30,
        Max = 31,
    };
}
namespace via::puppet {
    enum SyncPriority {
        High = 0,
        Normal = 1,
        Low = 2,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum RayTracingDenoiserDebugView {
        GI_Reflection = 0,
        GI = 1,
        Reflection = 2,
        GI_Check = 3,
        Reflection_Check = 4,
        DirectLight_Check = 5,
        VFX_BLAS_Check = 6,
        VFX_BLAS_Check_NoAlpha = 7,
    };
}
namespace via::gui {
    enum SamplerType {
        PointWrap = 0,
        PointClamp = 1,
        BilinearWrap = 4,
        BilinearClamp = 5,
        TrilinearWrap = 8,
        TrilinearClamp = 9,
        Anisotropic2Wrap = 12,
        Anisotropic2Clamp = 13,
        Max = 14,
    };
}
namespace app::StaffRollData {
    enum SKUType {
        All = 0,
        WW = 1,
        JP = 2,
    };
}
namespace app::InteractPadlock {
    enum PadlockNumType {
        Num3 = 0,
        Num5 = 1,
    };
}
namespace via::audiorender {
    enum CoordinateSystemType {
        World = 0,
        Local = 1,
    };
}
namespace app::Em8100 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::fsm::requestMenuFromFsm {
    enum RequestTargetMenuEnum {
        AmbassadorTrialInGameTitle = 0,
        AmbassadorTrialObjective = 1,
        FF030_Ex_Objective = 2,
    };
}
namespace app::LucasTrapMessage {
    enum TrapType {
        Wire = 0,
        FakeBox = 1,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum RayTracingResolution {
        Origin_Res = 0,
        Half_Res = 1,
    };
}
namespace app::CH8Em4500ActionController::BattleCondition {
    enum ThinkMode {
        Free = 0,
        Rush = 1,
        SpitBeam = 2,
        OxygenObstacle = 3,
        OpenCore = 4,
        Runaway = 5,
    };
}
namespace via::render {
    enum TextureStreamingType {
        None = 0,
        Streaming = 1,
        HighMap = 2,
    };
}
namespace via::network::MatchmakingRules {
    enum RuleType {
        Must = 0,
        Should = 1,
    };
}
namespace app::CheckSceneFolder {
    enum ControlTypeEnum {
        isActivate = 0,
        MAX = 1,
    };
}
namespace app::CH9Em6400::Action::Grapple {
    enum Type {
        None = 0,
        CommonTurn = 1,
        CommonHeadButt = 2,
        CommonKnee = 3,
        CommonThrowR = 4,
        CommonThrowL = 5,
        CommonSkill01 = 6,
        CommonSkill02 = 7,
    };
}
namespace app::CH9Em5800::Goal::GoalGenerator {
    enum ID {
        UnDiscovery = 0,
        Discovery = 1,
        Interval = 2,
        Generate = 3,
        GenerateWait = 4,
        Passive = 5,
        PassiveGenerate = 6,
        Dead = 7,
        GenerateActionEm5700 = 8,
        GenerateActionEm5850 = 9,
        DeadAction = 10,
    };
}
namespace via::hid::hmd::Morpheus {
    enum VrModeStatusCheckTiming {
        VrTrackerStarted = 0,
        VrVideoModeEnabled = 1,
    };
}
namespace app::OptionMenu {
    enum ReticleColor {
        White = 0,
        Red = 1,
        Blue = 2,
        Green = 3,
        Black = 4,
    };
}
namespace app::CH9StartCheck {
    enum ResultType {
        Checking = 0,
        ReturnExtraContents = 1,
        StartMainMenu = 2,
    };
}
namespace via::wwise {
    enum StopAllTargetType {
        StopAllType_GameObject = 0,
        StopAllType_EntireComponent = 1,
        StopAllType_Global = 2,
    };
}
namespace app::CH9Em6400::Action::Step {
    enum Type {
        In = 0,
        InLong = 1,
        Back = 2,
        BackLong = 3,
        Side = 4,
        SideLong = 5,
        SideBack = 6,
        SideBackLong = 7,
    };
}
namespace app::CH9Em5700::Action::Attack {
    enum Type {
        Stab = 0,
        RearStab = 1,
        GroundStab = 2,
        Strike = 3,
    };
}
namespace hikako::ChallengeActivityManager {
    enum ChallengeType {
        INVALID = 0,
        Nightmare = 1,
        Nightmare_Terror = 2,
        Ethan_Must_Die = 3,
    };
}
namespace via::gui::detail {
    enum SceneInfoAttribute {
        GUICameraOnly = 0,
        PrimaryOnly = 1,
        Both = 2,
        Max = 3,
    };
}
namespace via::Window {
    enum Message {
        Create = 0,
        Close = 1,
        Redraw = 2,
        Focus = 3,
        FocusWindow = 4,
        Activate = 5,
        OSSuspending = 6,
        OSResumed = 7,
        Resize = 8,
        Notify = 9,
        MouseMove = 10,
        MouseWheel = 11,
        MouseDown = 12,
        MouseUp = 13,
        MouseDblClk = 14,
        WinIniChange = 15,
        TimeChange = 16,
        KeyDown = 17,
        KeyUp = 18,
        DeviceChange = 19,
        Input = 20,
        InputDeviceChange = 21,
        MouseDelta = 22,
        PenTabUpdate = 23,
        ImeEvent = 24,
        Max = 25,
    };
}
namespace via {
    enum AccountPickerState {
        NotSupported = 0,
        Idle = 1,
        Running = 2,
    };
}
namespace app::Richpresence {
    enum CH9ContextType {
        Easy = 0,
        Normal = 1,
        Hard = 2,
        Invalid = -1,
    };
}
namespace app::Cp7MainMenu {
    enum ListElementSub {
        Continue = 0,
        NewGame = 1,
        Survival = 2,
        Achievement = 3,
        Survival1 = 4,
        Survival2 = 5,
        Max = 6,
    };
}
namespace via::motion::CppSampleAppendChild {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
    };
}
namespace app::OptionListItem {
    enum Mode {
        Normal = 0,
        Button = 1,
        Record = 2,
    };
}
namespace app::CH9Em7800ActionController {
    enum DodgeQueType {
        Left = 0,
        Right = 1,
    };
}
namespace via::dialog {
    enum Error {
        Nothing = 0,
        NotSupported = -1,
        InvalidParam = -2,
        InvalidState = -3,
        NotRunning = -4,
        UnexpectedFatal = -255,
    };
}
namespace app::EnemyGrappleBase {
    enum GrappleStartType {
        Sync = 0,
        Delay = 1,
        NoPosLerp = 2,
    };
}
namespace app::EffectDecal {
    enum DecalUpEnum {
        XPlus = 0,
        XMinus = 1,
        YPlus = 2,
        YMinus = 3,
        ZPlus = 4,
        ZMinus = 5,
    };
}
namespace app::ItemCombiner {
    enum Result {
        Success = 0,
        Fail = 1,
        FailSerum = 2,
    };
}
namespace app::Achievement {
    enum ProcessType {
        Idle = 0,
        SetupEvent = 1,
        SetupAchievement = 2,
        Normal = 3,
        AchievementWaiting = 4,
    };
}
namespace app::CH8Em4400ActionController::BattleCondition {
    enum KneelDamageReaction {
        None = 0,
        Small_v1 = 1,
        Small_v2 = 2,
        Front = 3,
        Left = 4,
        Right = 5,
    };
}
namespace app::CH9MoldedActionController {
    enum DodgeVariation {
        Left = 0,
        LeftBack = 1,
        Right = 2,
        RightBack = 3,
    };
}
namespace via::wwise {
    enum EventStatusType {
        None = 0,
        Reserved = 1,
        Posted = 2,
        Finished = 3,
        Failed = 4,
        Invalid = 5,
        Max = 6,
    };
}
namespace app::CH8Em4000::CH8ThinkStateSet {
    enum Type {
        Default = 0,
        Mimicry = 1,
        Dregs = 2,
        Destination = 3,
        Wanderer = 4,
        Extra = 5,
        TU2 = 6,
        WaitAttack = 7,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum StereoEye {
        Left = 0,
        Right = 1,
        Count = 2,
    };
}
namespace app::Em3000::IK::Em8000FBIKController::FBIKStatus {
    enum State {
        INVALID = -1,
        None = 0,
        Start = 1,
        Up = 2,
        Stay = 3,
        Down = 4,
        End = 5,
        SUM = 6,
    };
}
namespace app::Collision::MaterialId {
    enum TypeLabel {
        NoneA = 0,
        SoilA = 1,
        SandA = 2,
        GravelA = 3,
        SloughA = 4,
        StoneA = 5,
        StoneB = 6,
        StoneC = 7,
        BrickA = 8,
        PlasterA = 9,
        RubbleA = 10,
        WoodA = 11,
        WoodB = 12,
        WoodCreakC = 13,
        GrassA = 14,
        GrassB = 15,
        GrassC = 16,
        GrassD = 17,
        IronA = 18,
        IronB = 19,
        IronNetC = 20,
        PlasticA = 21,
        PlasticWoodB = 22,
        PlasticConcreteC = 23,
        VinylA = 24,
        VinylWoodB = 25,
        VinylConcreteC = 26,
        GumA = 27,
        GlassA = 28,
        GlassPieceB = 29,
        ClothA = 30,
        ClothWoodB = 31,
        ClothConcreteC = 32,
        PaperA = 33,
        PaperWoodB = 34,
        PaperConcreteC = 35,
        MeatA = 36,
        FoodA = 37,
        FurA = 38,
        InsectA = 39,
        WaterA = 40,
        WaterB = 41,
        WaterC = 42,
        WaterDeepD = 43,
        MoldA = 44,
        WoodChipA = 45,
        MudGrass = 46,
        WoodWetA = 47,
    };
}
namespace app::Elevator {
    enum Floor {
        Floor_4F = 0,
        Floor_3F = 1,
        Floor_2F = 2,
        Floor_1F = 3,
        Floor_B1F = 4,
        Floor_B2F = 5,
    };
}
namespace via::effect::EffectTest {
    enum PtLifeState {
        PtLifeState_Unknown = 0,
        PtLifeState_Wait = 1,
        PtLifeState_Initialize = 2,
        PtLifeState_Appear = 3,
        PtLifeState_Keep = 4,
        PtLifeState_KeepHold = 5,
        PtLifeState_Vanish = 6,
        PtLifeState_Terminate = 7,
    };
}
namespace via::render {
    enum Topology {
        Undefined = 0,
        PointList = 1,
        LineList = 2,
        LineStrip = 3,
        TriangleList = 4,
        TriangleStrip = 5,
        LineListAdj = 6,
        LineStripAdj = 7,
        TriangleListAdj = 8,
        TriangleStripAdj = 9,
        PatchList_ControlPoint1 = 10,
        PatchList_ControlPoint2 = 11,
        PatchList_ControlPoint3 = 12,
        PatchList_ControlPoint4 = 13,
        PatchList_ControlPoint5 = 14,
        PatchList_ControlPoint6 = 15,
        PatchList_ControlPoint7 = 16,
        PatchList_ControlPoint8 = 17,
        PatchList_ControlPoint9 = 18,
        PatchList_ControlPoint10 = 19,
        PatchList_ControlPoint11 = 20,
        PatchList_ControlPoint12 = 21,
        PatchList_ControlPoint13 = 22,
        PatchList_ControlPoint14 = 23,
        PatchList_ControlPoint15 = 24,
        PatchList_ControlPoint16 = 25,
        PatchList_ControlPoint17 = 26,
        PatchList_ControlPoint18 = 27,
        PatchList_ControlPoint19 = 28,
        PatchList_ControlPoint20 = 29,
        PatchList_ControlPoint21 = 30,
        PatchList_ControlPoint22 = 31,
        PatchList_ControlPoint23 = 32,
        PatchList_ControlPoint24 = 33,
        PatchList_ControlPoint25 = 34,
        PatchList_ControlPoint26 = 35,
        PatchList_ControlPoint27 = 36,
        PatchList_ControlPoint28 = 37,
        PatchList_ControlPoint29 = 38,
        PatchList_ControlPoint30 = 39,
        PatchList_ControlPoint31 = 40,
        PatchList_ControlPoint32 = 41,
    };
}
namespace via::nnfc::nfp {
    enum NfpErrorSelector {
        None = 0,
        NotSupport = 1,
        InvalidFormat = 2,
        WirelessOff = 3,
        TagLost = 4,
        TagLostOnFlush = 5,
        NoAppData = 6,
        MismatchApp = 7,
        NeedRegister = 8,
        NeedRestore = 9,
        NeedFormat = 10,
    };
}
namespace app::Em8001::Action::AttackCombo {
    enum Type {
        INVALID = -1,
        None = 0,
        Combo_Swing = 1,
        Combo_SwingBack = 2,
        SUM = 3,
    };
}
namespace via::render::RenderConfig {
    enum SharpnessType {
        Custom = 0,
        Default = 1,
        FidelityFXCAS = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Generate {
    enum GenerateTable {
        HeadStart = 1001,
        HeadEnd = 1002,
        ChestStart = 2001,
        ChestEnd = 2002,
        StomachStart = 3001,
        StomachEnd = 3002,
        ThighStart = 4001,
        ThighEnd = 4002,
    };
}
namespace app::EnemyActionController {
    enum ResistResult {
        Succeeded = 0,
        Damaged = 1,
        Lost = 2,
        BlownAway = 3,
        Slipped = 4,
        PullAhead = 5,
        Counter = 6,
    };
}
namespace app::CarInGarage::HijackedByEnemy {
    enum DestinationGroup {
        WallSouth = 1,
        WallWest = 2,
        WallNorth = 4,
        WallEast = 8,
        Wall = 15,
        Nearest = 16,
        Center = 32,
        Farest = 64,
        WallSouthNearest = 17,
        WallSouthFarest = 65,
        WallWestNearest = 18,
        WallWestCenter = 34,
        WallWestFarest = 66,
        WallNorthNearest = 20,
        WallNorthFarest = 68,
        WallEastNearest = 24,
        WallEastCenter = 40,
        WallEastFarest = 72,
    };
}
namespace app::CH9Em7900::Action {
    enum ActionNo {
        MountTry = 4,
        Grapple = 5,
        Appear = 6,
        LostParts = 7,
        BlownAway = 8,
        SlipFire = 9,
        SlipAcid = 10,
        Falling = 11,
        Feint = 12,
        Anger = 13,
        Rush = 14,
        Splash = 15,
        Breath = 16,
        BreathFirst = 17,
        BreathForce = 18,
        DamageToMove = 19,
        DamageToBreath = 20,
        Wait = 21,
        Suspend = 22,
        Resume = 23,
        Warp = 24,
        FinishBlow = 25,
    };
}
namespace via::gui {
    enum ResolutionAdjustCondition {
        Always = 0,
        Expanding = 1,
        Shrinking = 2,
        Max = 3,
    };
}
namespace via::physics::ShapeClosestResult {
    enum Result {
        Success = 0,
        Failure = 1,
    };
}
namespace via::motion::ChainResource {
    enum ChainAttrFlags {
        None = 0,
        ModelCollisionPreset = 1,
    };
}
namespace via::charset::detail {
    enum ElementType {
        Unknown = 0,
        Ascii = 1,
        Kana = 2,
        HanKana = 2,
        Kanji = 3,
    };
}
namespace app::GameEventAction {
    enum ParentSettingAfterEvent {
        NoChange = 0,
        RestoreBeforeEvent = 1,
        Clear = 2,
    };
}
namespace via::sound::SoundTriggerElement {
    enum PositionType {
        Set = 0,
        Follow = 1,
    };
}
namespace app::Em4000::Action {
    enum ActionNo {
        BiteTry = 4,
        NearBiteTry = 5,
        Strike = 6,
        StrikeUpper = 7,
        StrikeToGuard = 8,
        SlashPursuit = 9,
        SlashTry = 10,
        BiteCrawl = 11,
        DamageToStrike = 12,
        DamageToMove = 13,
        Thrust = 14,
        Mouth = 15,
        Grapple = 16,
        Appear = 17,
        LostParts = 18,
        BlownAway = 19,
        ChanceCounter = 20,
        SlipFire = 21,
        SlipAcid = 22,
        ExtraWait = 23,
        Dodge = 24,
        Notice = 25,
        Mimicry = 26,
        Falling = 27,
        Threat = 28,
        Warp = 29,
        Suspend = 30,
        Resume = 31,
    };
}
namespace app::CH9Em5700 {
    enum ThinkState {
        None = 0,
        BugHole = 1,
        NoLostPlayer = 2,
        NoSearch = 3,
        UseGrapple = 4,
    };
}
namespace via::effect {
    enum PlayerAction {
        Idle = 0,
        Start = 1,
        Kill = 2,
        Finish = 3,
        Pause = 4,
        Resume = 5,
        Step = 6,
        PauseStart = 7,
    };
}
namespace via::network::protocol {
    enum SendOption {
        None = 0,
        Unreliable = 0,
        Unreliable_Low = 0,
        Unreliable_High = 1,
        Reliable = 4,
        ReliableBuffer = 12,
        FastCallback = 16,
        CheckAbsent = 32,
        Tag = 64,
        FastPass = 128,
        CheckNonce = 256,
        SkipReceiveQueue = 512,
    };
}
namespace app::Em3000::Em8000CorpsebagManager {
    enum State {
        INVALID = -1,
        None = 0,
        PlayerInRoom = 1,
        PlayerNearRoom = 2,
        PlayerOutOfRoom = 3,
        SUM = 4,
    };
}
namespace via::motion::JointRemapValue::RemapValueItem {
    enum TRS {
        Trans = 0,
        Rot = 1,
        Scale = 2,
    };
}
namespace app::wwise::WwiseOptionMenu {
    enum VirtualSurround {
        NoUse = 0,
        Use = 1,
    };
}
namespace via::audiorender {
    enum I3DL2ReverbParameter {
        DryVolume = 0,
        OutputChannels = 1,
        Room = 2,
        RoomHF = 3,
        RoomRolloffFactor = 4,
        DecayTime = 5,
        DecayHFRatio = 6,
        Reflections = 7,
        ReflectionsDelay = 8,
        Reverb = 9,
        ReverbDelay = 10,
        Diffusion = 11,
        Density = 12,
        HFReference = 13,
    };
}
namespace via::hid::gamePlayer {
    enum PlayerOtherDeviceHandlingCaps {
        None = 0,
        UseFirstSelected = 2,
        UseLastSelected = 4,
        AssignToOtherPlayer = 8,
    };
}
namespace via::effect::gpgpu::RibbonFollowCS::RibbonFollowResource {
    enum RibbonFollowComputeShaderType {
        InitializeCS = 0,
        ConstructCS = 1,
        DepthOcclusion = 2,
        DepthOcclusionGlobalSparseShadow = 3,
        MaxType = 4,
    };
}
namespace Em4100Effect {
    enum IDAlias {
        LostHead = 0,
    };
}
namespace app::Em3100 {
    enum ThinkState {
        None = 0,
        FF = 1,
        FFLast = 2,
        FFTargetting = 3,
        BugHole = 4,
        BugHoleDead = 5,
        Patrol = 6,
        DO_NOT_USE_RunAway = 7,
        Patrol_Ch3_2 = 8,
        DLC_SensorOFF = 9,
        DLC_SensorON = 10,
        Birthday_Patrol = 11,
    };
}
namespace via::motion::Chain {
    enum GravityCoord {
        Default = 0,
        World = 1,
        Local = 2,
    };
}
namespace via::render::RenderTargetOperator {
    enum CompareFunc {
        AlwaysPass = 0,
        AlwaysIgnore = 1,
        GreaterEqual = 2,
        Less = 3,
    };
}
namespace app::CH8HUDControl {
    enum Monster {
        Mather = 0,
        WhiteMoldead = 1,
    };
}
namespace via::render::RenderOutput {
    enum RenderMode {
        Default = 0,
        LightWeight = 1,
    };
}
namespace app::vr::VrPlayerVisibleController {
    enum PlayerVisibleType {
        Default = 0,
        OnlyArm = 1,
    };
}
namespace app::FsmStateTracker {
    enum Transition {
        None = 0,
        Start = 1,
        Update = 2,
        End = 3,
    };
}
namespace via::movie::Movie {
    enum PlayState {
        Idle = 0,
        InitializeStart = 1,
        Initialized = 2,
        BufferingStart = 3,
        Buffering = 4,
        Buffered = 5,
        PlayStart = 6,
        Playing = 7,
        PauseStart = 8,
        Paused = 9,
        StopStart = 10,
        Stopped = 11,
        SoftStopStart = 12,
        SoftStopped = 13,
        VissStart = 14,
        Finalize = 15,
    };
}
namespace app {
    enum EnemyActionCategory {
        General = 0,
        Move = 1,
        Attack = 2,
        Damage = 3,
        Grapple = 4,
        BaseMax = 5,
        ValidRangeToInherit = 5,
    };
}
namespace app::MessageLabelGUI {
    enum VrGuiParamIndex {
        Subtitle = 0,
        Interact = 1,
    };
}
namespace app::CH8Em4100ActionController {
    enum BackstepQueType {
        Back = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::fsm::CH8PartsEnable {
    enum PartsSetType {
        EnableSet = 0,
        DisableSet = 1,
    };
}
namespace app::CH9Em7900::ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
    };
}
namespace app::CH9Em7800::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
        Air = 2,
    };
}
namespace app::OptionMenu {
    enum FramerateType {
        FIX30 = 0,
        FIX60 = 1,
        VARIABLE = 2,
        FIX120 = 3,
    };
}
namespace via::navigation::algorithm::MapGraphAstar {
    enum Result {
        Success = 0,
        Fail = 1,
        Interrupt = 2,
        Working = 3,
        SuccessNearPossible = 4,
    };
}
namespace via::hid {
    enum NpadJoyDeviceType {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH8ActivateObjectOperation::OperationData {
    enum OperationType {
        AND = 0,
        OR = 1,
        EXOR = 2,
        NOT = 3,
    };
}
namespace app::CH9Em6700::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::CardGameItem {
    enum BetUpDownType {
        NoUse = 0,
        BetUp = 1,
        MyBetDown = 2,
        SP_Desperation = 3,
        SP_BetUp_21 = 4,
        SP_Desire = 5,
        SP_Desire_p = 6,
        SP_Conjuring = 7,
    };
}
namespace app::EPVExpertCharacterBloodData {
    enum DamageHitTypeEnum {
        None = 0,
        WeakPoint = 1,
    };
}
namespace app::GameFlowFsmManager {
    enum GameFlowKindEnum {
        C00_Main = 0,
        C01_Main = 1,
        C03_1_Main = 2,
        C03_2_Main = 3,
        C03_3_Main = 4,
        C03_4_Main = 5,
        C03_5_Main = 6,
        C04_1_Main = 7,
        C04_2_Main = 8,
        C04_3_Main = 9,
        FF000_Main = 10,
        FF030_Main = 11,
        FF040_Main = 12,
        FF050_Main = 13,
        C07_1_Main = 14,
        C07_2_Main = 15,
        C07_3_Main = 16,
        C07_4_Main = 17,
        C08_Main = 18,
        None = 19,
        C03_IMD_Main = 20,
        C09_Main = 21,
    };
}
namespace app::Havok::ClothAnimationColtroller {
    enum AnimationStatus {
        AnimationStatus_Animation = 0,
        AnimationStatus_Simulation = 1,
        AnimationStatus_AnimationToSimulationEvent = 2,
        AnimationStatus_SimulationToAnimationEvent = 3,
    };
}
namespace app::Em3001::Action::Zigzag {
    enum Type {
        Normal = 0,
        TNormal = 1,
    };
}
namespace app::InventoryMenu {
    enum CommandIconType {
        Use = 0,
        Search = 1,
        Combine = 2,
        Discard = 3,
        Move2ItemBox = 4,
        Move2Inventory = 5,
        Move2ItemBoxOne = 6,
        Move2InventoryOne = 7,
        None = 8,
    };
}
namespace app::Em8910::Action {
    enum ActionNo {
        Idle = 0,
        Idle_L = 1,
        Idle_R = 2,
        MoveForward = 3,
        Dead = 4,
        Recover = 5,
        AttackReadyStart = 6,
        AttackReadyLoop = 7,
        AttackReadyEnd = 8,
        AttackCleave = 9,
        AttackPierce = 10,
        AttackReadyDamage = 11,
        AttackBattleEnd = 12,
        AttackPoundingStart = 13,
        AttackPoundingLoop = 14,
        AttackPoundingEnd = 15,
    };
}
namespace app::Collision::AttackUserData {
    enum Attribute {
        DirLine = 0,
        DirCenter = 1,
        DirAngleY = 2,
        DirAngleX = 3,
        ___b04 = 4,
        ___b05 = 5,
        StageAtariOnce = 6,
        SkipStageAtariDamage = 7,
        HitWall = 8,
        ZigZag = 9,
        SkipStageAtari = 10,
        SkipLineList = 11,
        Detection = 12,
        ReservedVFX = 13,
        HavokRemove = 14,
        HavokSkip = 15,
        ScaleL = 32,
        ScaleM = 33,
        ScaleS = 34,
        ___b35 = 35,
        AttrFire = 36,
        AttrAcid = 37,
        ___b38 = 38,
        ___b39 = 39,
        KindKnife = 40,
        KindBomb = 41,
        KindGrenade = 42,
        KindBurner = 43,
        TypeStrike = 44,
        TypeSlash = 45,
        TypeShoot = 46,
        TypeLandscape = 47,
        TypeShapeless = 48,
        ___b49 = 49,
        ___b50 = 50,
        ___b51 = 51,
        QuickDeath = 52,
        NoDeath = 53,
        Blow = 54,
        DefeatGuard = 55,
        EmSpecial0 = 64,
        EmSpecial1 = 65,
        EmSpecial2 = 66,
        EmSpecial3 = 67,
        FxSlash = 96,
        FxStab = 97,
        FxShoot = 98,
        FxStrike = 99,
        FxBite = 100,
        FxCatch = 101,
        FxExplosion = 102,
        FxDummy07 = 103,
        FxDummy08 = 104,
        FxDummy09 = 105,
        FxDummy10 = 106,
        FxDummy11 = 107,
        FxDummy12 = 108,
        FxDummy13 = 109,
        FxNoSound = 110,
        FxSpecialAttack = 111,
        FxSmallBlood = 112,
        FxMiddleBlood = 113,
        FxLargeBlood = 114,
        ___d00 = 128,
        ___d01 = 129,
        DefeatJustGuard = 130,
        EndureJustGuard = 131,
    };
}
namespace app::fsm::ChangeDamageGUI {
    enum ConnectType {
        NotSet = 0,
        Connect = 1,
        Disconnect = 2,
    };
}
namespace app::Em3100::Action::Damage {
    enum Type {
        Head = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::Em4400::Goal {
    enum CH8EvaluatorID {
        HasTarget = 0,
        CanGrapple = 1,
        Front = 2,
        OutRange = 3,
        InRange = 4,
        HeightRange = 5,
        CurrentRouteNearDoor = 6,
        IsAttackFromFrontWithDirective = 7,
        IsTargetRun = 8,
        IsTargetCrouching = 9,
        IsTargetDamage = 10,
        IsSlipFire = 11,
        IsSlipAcid = 12,
        IsThinkSet = 13,
        IsTargetOnLadder = 14,
        IsGenerate = 15,
        IsEscape = 16,
        AdditiveSensedAttack = 17,
    };
}
namespace app::CH8StateSwitchM1 {
    enum CHP8_1 {
        SILENCE = 0,
        CHP8_INTRO_START = 1,
        CHP8_EM4600_BT_START = 2,
        CHP8_EM4600_BT_END = 3,
        CHP8_ELEVATOR = 4,
        CHP8_CAVE_END = 5,
    };
}
namespace via::motion::ContinueOptions {
    enum ContinueType {
        Non = 0,
        PrevEnd = 1,
        ExitFrame = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em3000::Action::Rest {
    enum Type {
        Rest1 = 0,
        Rest2 = 1,
        Rest3 = 2,
        Rest4 = 3,
        Rest5 = 4,
        Rest6 = 5,
    };
}
namespace via::audiorender {
    enum Channel_514ch {
        L = 0,
        R = 1,
        C = 2,
        LFE = 3,
        Ls = 4,
        Rs = 5,
        Ltf = 6,
        Rtf = 7,
        Ltr = 8,
        Rtr = 9,
        Max = 10,
    };
}
namespace app {
    enum CERO {
        None = 0,
        D = 1,
        Z = 2,
    };
}
namespace via::render {
    enum VFXResolutionDepthShrink {
        Farthest = 0,
    };
}
namespace app::CH9Em7800::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::Em9900::Em9900Parameter {
    enum Group {
        NONE = 0,
        A = 1,
        B = 2,
        C = 3,
        D = 4,
    };
}
namespace app::AdditionalTutorial {
    enum AdditionalChapter {
        Chapter7_1 = 0,
        Chapter7_2 = 1,
        Chapter7_3 = 2,
        Chapter7_4 = 3,
    };
}
namespace app::Em3000::Action::OpenDoor {
    enum Type {
        Normal = 0,
        Kick = 1,
    };
}
namespace System::Collections::Generic {
    enum TreeRotation {
        Left = 0,
        LeftRight = 1,
        Right = 2,
        RightLeft = 3,
    };
}
namespace app::OptionMenu {
    enum TrackingParamType {
        Ingame = 0,
        MainMenu = 1,
        IngameTitle = 2,
    };
}
namespace app::CH9Em6800 {
    enum eMotionBankID {
        Base = 0,
    };
}
namespace via::audiorender {
    enum Channel_712ch {
        L = 0,
        R = 1,
        C = 2,
        LFE = 3,
        Lrs = 4,
        Rrs = 5,
        Ls = 6,
        Rs = 7,
        Lt = 8,
        Rt = 9,
        Max = 10,
    };
}
namespace app::Em5520 {
    enum ThinkState {
        None = 0,
        NoLostPlayer = 1,
    };
}
namespace app::OptionMenu {
    enum MouseBtnRev {
        Normal = 0,
        Reverse = 1,
    };
}
namespace app::CH8RewardArticle {
    enum Category {
        Item = 0,
        Weapon = 1,
        PowerUp = 2,
    };
}
namespace via::motion::detail {
    enum ChainDebugColFilterDisplayMode {
        All = 0,
        Group = 1,
        ModelCollision = 2,
    };
}
namespace app::Em4000::ThinkAppearSet {
    enum Type {
        Default = 0,
        NoUse_Low1 = 10,
        FromLow2_Speedy = 11,
        NoUse_Middle1 = 20,
        FromMiddle2_Micheal = 21,
        NoUse_Middle3 = 22,
        FromMiddle4_Speedy = 23,
        FromCeil1_High = 30,
        FromCeil2_Speedy = 31,
        NoUse_CrawlLow1 = 40,
        FromCrawlLow2_Speedy = 41,
        NoUse_CrawlMiddle1 = 50,
        FromCrawlMiddle2_Speedy = 51,
        NoUse_Mimicry1 = 60,
        Mimicry2_Lying = 61,
        Mimicry3_Stand = 62,
        NoUse_Mimicry4 = 63,
        NoUse_Mimicry5 = 64,
        FromMimicry = 70,
        FromCorpse = 80,
        FromMorgue = 90,
        FromFirst = 100,
        FromFirstStay = 101,
        Shout = 200,
        ShoutWait = 201,
        FromGround = 300,
        Summon = 301,
    };
}
namespace app::MotionGroupTable {
    enum VersionNo {
        Initial = 0,
        EnableBankType = 2,
    };
}
namespace via::render::PrimitiveCS {
    enum DrawType {
        Transparent = 0,
        Overlay = 1,
        StochasticTransparent = 2,
    };
}
namespace via::navigation::map {
    enum SectionType {
        NoSection = 0,
        Owner = 1,
        Section = 2,
        ConnectManager = 3,
        IndividualSection = 4,
        Invalid = 4294967295,
    };
}
namespace via::motion::MultiTransitionSolver {
    enum LocalFlagIdx {
        IgnoreFirstInterpolation = 0,
        ForceFrontFade = 1,
        MultiTransEnd = 2,
        AutoPrevMotRefClear = 3,
        NextPrevMotRefClear = 4,
        Reset = 5,
        Max = 6,
    };
}
namespace app::InventoryMenu {
    enum StepType {
        Invalid = 0,
        OpenWait = 1,
        ItemSlot = 2,
        ItemSlotContextMenu = 3,
        ItemBox = 4,
        ItemBoxContextMenu = 5,
        CombineSelect2ndItem = 6,
        CombineFailed = 7,
        CombineConfirm = 8,
        ItemMove = 9,
        CantStoreItembox = 10,
        DiscardConfirm = 11,
        SearchWait = 12,
        Search = 13,
        OpenSupplyBoxConfirm = 14,
        OpenSupplyBoxFailed = 15,
        OpenItemBoxCutin = 16,
        DictionaryCombine = 17,
        DictionaryCombineExecute = 18,
        DictionaryCombineFailed = 19,
        ItemSet = 20,
        ItemSetRegister = 21,
        ItemSetApply = 22,
        Close = 23,
    };
}
namespace via::render::detail {
    enum PrimDrawType {
        Unknown = 0,
        Billboard2D = 1,
        Billboard3D = 2,
        Polygon = 3,
        PolygonStrip = 4,
        Ribbon = 5,
        Mesh = 6,
        MeshInstancing = 7,
        Fluid2D = 8,
        LensflareIris = 9,
        LensflareHoop = 10,
        LensflareGeneric = 11,
        LensflareDebug = 12,
        Billboard3DMaterial = 13,
        RibbonMaterial = 14,
        PolygonMaterial = 15,
        PolygonStripMaterial = 16,
    };
}
namespace via::vr::psCamera {
    enum PSCameraAttr {
        Ignore = 4294967295,
        AecAgcEnable = 0,
        AecAgcDisable = 1,
        ExposureGainMode0 = 0,
        ExposureGainMode1 = 1,
        WhiteBalanceAuto = 0,
        WhiteBalanceManual = 1,
        GammaControlOn = 0,
        GammaControlOff = 1,
    };
}
namespace app::CrusherUIAsset {
    enum CounterPanelState {
        DEFAULT = 0,
        EMPTY = 1,
        FULL = 2,
        EVENT = 3,
    };
}
namespace via::detail_qt {
    enum qt_cell_link_bit {
        qt_cell_link_bit_none = 0,
        qt_cell_link_bit_00 = 1,
        qt_cell_link_bit_01 = 2,
        qt_cell_link_bit_10 = 4,
        qt_cell_link_bit_11 = 8,
    };
}
namespace via {
    enum SharePlayConnectionStatus {
        Disable = -1,
        Failed = -2,
        Dormant = 0,
        Ready = 1,
        Connected = 2,
    };
}
namespace via::landscape::beta {
    enum WireframeTypeEnum {
        None = 0,
        Wire = 1,
        FilledWire = 2,
        OverlayWire = 3,
    };
}
namespace app::Em4200Grapple::Hash::Fsm {
    enum MountFinishType {
        Kill = 0,
        BlownAway = 1,
        HeadShot = 2,
        KickOut = 3,
        BombSet = 4,
        Invalid = -1,
    };
}
namespace app::Em8940 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace via::navigation::RelationMapInfo {
    enum Attribute {
        UseOpimizedData = 0,
        AttributeNum = 1,
    };
}
namespace app::Collision::ShapeUserData {
    enum SideCalcType {
        None = 0,
        FixR = 1,
        FixL = 2,
        Auto = 3,
    };
}
namespace hikako::ActivityManager {
    enum ExtraActivityType {
        Objective_74 = 0,
        Objective_08 = 1,
        Objective_09 = 2,
        ExtraMode_01 = 3,
        ExtraMode_02 = 4,
        ExtraMode_03 = 5,
        ScoreAttack_01 = 6,
        ScoreAttack_02 = 7,
        TimeAttack_01 = 8,
        INVALID = 9,
    };
}
namespace app::GameManager {
    enum PlayerChangeType {
        Pl0000 = 0,
        Pl2000 = 1,
    };
}
namespace via::gui {
    enum LightGroupId {
        Group0 = 0,
        Group1 = 1,
        Group2 = 2,
        Group3 = 3,
        Group4 = 4,
        Group5 = 5,
        Group6 = 6,
        Group7 = 7,
    };
}
namespace hikako {
    enum PadIndex {
        Pad_00 = 0,
        Pad_01 = 1,
        Pad_02 = 2,
        Pad_03 = 3,
        Pad_04 = 4,
        Pad_05 = 5,
        Pad_06 = 6,
        Pad_07 = 7,
        Pad_08 = 8,
        Pad_09 = 9,
    };
}
namespace app::Em8100::Em8100ActionController {
    enum Message {
        Idle = 0,
        IdleBurnEnd = 1,
        Attack = 2,
        AttackBurnEnd = 3,
        Damage = 4,
        DeadPL = 5,
        Num = 6,
    };
}
namespace via::gui {
    enum ControlPoint {
        LeftTop = 0,
        LeftCenter = 4,
        LeftBottom = 8,
        CenterTop = 1,
        CenterCenter = 5,
        CenterBottom = 9,
        RightTop = 2,
        RightCenter = 6,
        RightBottom = 10,
    };
}
namespace app::CH8CheckSceneFolder {
    enum ControlTypeEnum {
        isActivate = 0,
        MAX = 1,
    };
}
namespace app::PlayerTerrainMoveChecker {
    enum CheckClimbResult {
        None = 0,
        Success_Stand = 1,
        Success_Crouch = 2,
        Failure_NonregulatedWidth = 3,
        Failure_NotEnoughWidth = 4,
        Failure_NonregulatedDepth = 5,
        Failure_NonregulatedHeight = 6,
        Failure_NotEnoughDepth = 7,
        Failure_TooHigh = 8,
        Failure_NotEnoughHeadroom = 9,
        Failure_NotForwardMovement = 10,
        Failure_NotConfrontedObstacle = 11,
        Failure_TooLow = 12,
    };
}
namespace app::CharacterDefine {
    enum MoveType {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Crouch = 3,
        Crawl = 4,
        Supine = 5,
        Other = 6,
    };
}
namespace via::landscape {
    enum MaterialDebugType {
        None = 0,
        SampleCount = 1,
        LocalUV = 2,
        TriplanarWeights = 3,
        SplatIndex = 4,
        Max = 5,
    };
}
namespace app::FirstSettingMenu {
    enum ModeDef {
        Normal = 0,
    };
}
namespace app::CarInGarage {
    enum CollisionID {
        PressNormal = 0,
        PressInForwardMove = 1,
        PressInReverseMove = 2,
        AttackPlayerInForwardMove = 3,
        AttackPlayerInReverseMove = 4,
        AttackPlayerInLeftDrift = 5,
        AttackPlayerInRightDrift = 6,
        AttackEnemyInForwardMove = 7,
        AttackEnemyInReverseMove = 8,
        ExplosionForEnemy = 9,
        ExplosionForPlayer = 10,
        AttackOnlyPropsInForwardMove = 11,
        AttackOnlyPropsInReverseMove = 12,
        SecondExplosionForPlayer = 13,
        DestroyRigidBodyForPlayer = 15,
        DestroyRigidBodyForEnemy = 16,
        AttackPlayerInForwardMoveKindly = 17,
        AttackPlayerInLeftDriftKindly = 18,
        AttackPlayerInRightDriftKindly = 19,
        PressExplosion = 20,
        PressAfterExplosion = 21,
        PressRightDoor = 22,
        PressOnPlayerGetUp = 23,
        PressOnHitWallOnFront = 24,
        PressOnHitWallOnRear = 25,
    };
}
namespace app::Achievement {
    enum ID {
        PLATINUM_000 = 0,
        GOLD_000 = 1,
        GOLD_001 = 2,
        GOLD_002 = 3,
        SILVER_000 = 4,
        SILVER_001 = 5,
        SILVER_002 = 6,
        SILVER_003 = 7,
        SILVER_004 = 8,
        SILVER_005 = 9,
        SILVER_006 = 10,
        SILVER_007 = 11,
        SILVER_008 = 12,
        SILVER_009 = 13,
        SILVER_010 = 14,
        SILVER_011 = 15,
        SILVER_012 = 16,
        SILVER_013 = 17,
        BRONZE_000 = 18,
        BRONZE_001 = 19,
        BRONZE_002 = 20,
        BRONZE_003 = 21,
        BRONZE_004 = 22,
        BRONZE_005 = 23,
        BRONZE_006 = 24,
        BRONZE_007 = 25,
        BRONZE_008 = 26,
        BRONZE_009 = 27,
        BRONZE_010 = 28,
        BRONZE_011 = 29,
        BRONZE_012 = 30,
        BRONZE_013 = 31,
        BRONZE_014 = 32,
        BRONZE_015 = 33,
        BRONZE_016 = 34,
        BRONZE_017 = 35,
        BRONZE_018 = 36,
        BRONZE_019 = 37,
        BRONZE_020 = 38,
        BRONZE_021 = 39,
        BRONZE_022 = 40,
        DLC1_BRONZE_000 = 41,
        DLC1_BRONZE_001 = 42,
        DLC1_SILVER_000 = 43,
        DLC1_SILVER_001 = 44,
        DLC1_GOLD_000 = 45,
        DLC2_BRONZE_000 = 46,
        DLC2_BRONZE_001 = 47,
        DLC2_BRONZE_002 = 48,
        DLC2_BRONZE_003 = 49,
        DLC2_BRONZE_004 = 50,
        DLC2_SILVER_000 = 51,
        DLC2_SILVER_001 = 52,
        DLC2_SILVER_002 = 53,
        CH9_GOLD_000 = 54,
        CH9_SILVER_000 = 55,
        CH9_BRONZE_000 = 56,
        CH9_BRONZE_001 = 57,
        CH9_BRONZE_002 = 58,
        CH9_BRONZE_003 = 59,
    };
}
namespace via::effect::detail {
    enum EmitterContextType {
        Unknown = 0,
        Billboard2D = 1,
        Billboard3D = 2,
        RibbonFollow = 3,
        RibbonLength = 4,
        RibbonChain = 5,
        Mesh = 6,
        NodeBillboard = 7,
        StrainRibbon = 8,
        NoDraw = 9,
        Polygon = 10,
        RibbonTrail = 11,
        PolygonTrail = 12,
        GpuBillboard = 13,
        GpuPolygon = 14,
        RibbonFixEnd = 15,
        GpuRibbonFollow = 16,
        RibbonLightweight = 17,
        Lightning3D = 18,
        GpuMesh = 19,
        GpuMeshTrail = 20,
        GpuLightning3D = 21,
        Billboard3DMaterial = 22,
        PolygonMaterial = 23,
        GpuRibbonLength = 24,
        RibbonFollowMaterial = 25,
        RibbonLengthMaterial = 26,
        RibbonChainMaterial = 27,
        RibbonFixEndMaterial = 28,
        RibbonLightweightMaterial = 29,
        StrainRibbonMaterial = 30,
        PolygonTrailMaterial = 31,
        Lightning3DMaterial = 32,
        RibbonParticle = 33,
        ModularBillboard = 34,
        ModularRibbonFollow = 35,
        ModularRibbonLength = 36,
        ModularPolygon = 37,
        ModularMesh = 38,
    };
}
namespace app::Em3000::Em3000ActionController {
    enum Message {
        AppearUnDiscovery = 0,
        AppearDiscoveryShort = 1,
        AppearDiscoveryMiddle = 2,
        UnDiscovery = 3,
        Wander = 4,
        WalkFast = 5,
        WalkNormal = 6,
        StepIn = 7,
        AttackHit = 8,
        AttackUnHit = 9,
        AttackGuard = 10,
        DamageHandgun = 11,
        DamageKnifeFirst = 12,
        DamageKnife = 13,
        NoBullet = 14,
        DeadPL = 15,
        Provoke = 16,
        PlayerGetOff = 17,
        DamageCar = 18,
        DamageDownTime = 19,
        DamageDownAttack = 20,
        Num = 21,
    };
}
namespace via::motion::detail::ChainNodeData {
    enum AttrFlags {
        None = 0,
        PartMotionBlend = 1,
        Jiggle = 2,
    };
}
namespace via::dynamics {
    enum RayCastOption {
        AllHits = 0,
        DisableBackFacingTriangleHits = 1,
        DisableFrontFacingTriangleHits = 2,
        BackFacingTriangleHits = 3,
        FrontFacingTriangleHits = 4,
        NearSort = 5,
        InsideHits = 6,
        OneHitBreak = 7,
        Max = 8,
    };
}
namespace via {
    enum UserIndex {
        User0 = 0,
        User1 = 1,
        User2 = 2,
        User3 = 3,
        User4 = 4,
        User5 = 5,
        User6 = 6,
        User7 = 7,
        User8 = 8,
        User9 = 9,
        User10 = 10,
        User11 = 11,
        User12 = 12,
        User13 = 13,
        User14 = 14,
        User15 = 15,
        Reserved = 16,
        Max = 17,
        System = 18,
        Invalid = 19,
        Merged = 20,
    };
}
namespace via::landscape::beta {
    enum SplatTextureEnum {
        Albedo = 0,
        Normal = 1,
        Height = 2,
        Max = 3,
    };
}
namespace via::sound {
    enum SoundIdCategory {
        None = 999000000,
        Trigger = 999000001,
        Bus = 999000002,
        Effect = 999000003,
        Joint = 999000004,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum GuideMapResolution {
        GuideMapResolution_32x32 = 6,
        GuideMapResolution_64x64 = 7,
        GuideMapResolution_128x128 = 8,
        GuideMapResolution_256x256 = 9,
        GuideMapResolution_512x512 = 10,
    };
}
namespace via::render {
    enum CullMode {
        None = 1,
        Front = 2,
        Back = 3,
        Num = 4,
    };
}
namespace app::Em8001::Message {
    enum CorresponceExistMessageType {
        Retire = 0,
        Override = 1,
        WaitForEnd = 2,
    };
}
namespace app::Em3600::Action::Damage {
    enum Type {
        TwoLegDamage = 0,
        FourLegDamage = 1,
        FireDamage = 2,
        FallDamage = 3,
        FallDamageCell = 4,
        FallDamageForce = 5,
    };
}
namespace app::MenuManager {
    enum InteractOperationCursorType {
        Down = 0,
        Right = 1,
    };
}
namespace app::PlayerDamageController {
    enum WwiseDamageType {
        Damage = 0,
        Guard = 1,
    };
}
namespace app::OptionMenu {
    enum VrFilterTypeIndex {
        Horizon = 0,
        Overall = 1,
    };
}
namespace app::CH8ActivateObjectOperation::OperationData {
    enum IntCompareTarget {
        Variable = 0,
        Input = 1,
    };
}
namespace via::hid::textInput {
    enum TextInputSystemMessage {
        Decided = 0,
        Canceled = 1,
        CanceledAndEnded = 2,
    };
}
namespace via::telemetry::GetServerTimeRequest {
    enum DateTimeFormat {
        ISO8601 = 0,
    };
}
namespace via::gui {
    enum LinkInputDirection {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    };
}
namespace via::render::DepthOfField {
    enum CircularDOFKernelRadius {
        Radius4 = 0,
        Radius6 = 1,
        Radius8 = 2,
        Max = 3,
    };
}
namespace app::Havok {
    enum LayerType {
        CollideAll = 0,
        CollideNone = 1,
        Dummy02 = 2,
        Background = 3,
        Rigidbody = 4,
        Ragdoll = 5,
        Character = 6,
        Dummy07 = 7,
        ClothAccessory = 8,
        ClothProps = 9,
        ClothBackground = 10,
        ClothCharacter = 11,
        Dummy12 = 12,
        RagdollLive = 13,
        RagdollDead = 14,
        RigidbodyCartridge = 15,
        RigidbodyCharacterBreak = 16,
        Dummy17 = 17,
        Sound = 18,
        SystemCastRay = 30,
        SystemCastShape = 31,
    };
}
namespace via::physics {
    enum RequestState {
        None = 0,
        Faulted = 1,
        RanToCompletion = 2,
        Running = 3,
        WaitingToRun = 4,
    };
}
namespace app::QuickSlotItemIcon {
    enum State {
        Default = 0,
        Focus = 1,
        UnFocus = 2,
        Disable = 3,
        Decide = 4,
        None = 5,
    };
}
namespace via::storage::saveService {
    enum SaveSlot {
        Auto = 0,
        SystemMaxOffset = -128,
        System = -1,
        Slot = 1,
        SlotMax = 1024,
    };
}
namespace app::CH9Em6400::Action {
    enum ActionNo {
        Appear = 4,
        Walk = 5,
        Confront = 6,
        Guard = 7,
        FlashGuard = 8,
        Rest = 9,
        Turn = 10,
        Step = 11,
        GuardFollow = 12,
        Appeal = 13,
        AppealAwaken = 14,
        Attack = 15,
        AttackBack = 16,
        AttackToGrapple = 17,
        AttackEx = 18,
        Grapple = 19,
        GrappleFromPlayer = 20,
        Chapter91Battle_OrderAttack = 21,
        Chapter92Battle_OrderAttack = 22,
    };
}
namespace app::CH9PlayerFinishMoveChecker {
    enum FinishMoveType {
        None = 0,
        AttackDown = 1,
        SneakB = 2,
        AttackBack = 3,
        ChaseAttack = 4,
        Finish = 5,
        AutoFinish = 6,
    };
}
namespace via::gui::renderer {
    enum PrimitiveError {
        NoError = 0,
        InsufficientMemory = 1,
        InvalidState = 2,
        InsufficientTexture = 3,
        InvalidOperation = 4,
    };
}
namespace app::Em4000ActionController {
    enum DestinationType {
        ChangeThink = 0,
        SelfKill = 1,
    };
}
namespace app::fsm::CH8CheckEnemySpawned {
    enum CheckTable {
        IsSpawned = 0,
        IsUpdate = 1,
    };
}
namespace via::autoplay::AutoPlayManager {
    enum AutoPlayStatus {
        Wait = 0,
        Play = 1,
        Convert = 2,
        Load = 3,
    };
}
namespace app::EffectCommonDefine {
    enum EffectActionOnParentDisappear {
        None = 0,
        Finish = 1,
        Kill = 2,
        Unparent = 3,
    };
}
namespace app::Em4000::Action::Move {
    enum CrawlMode {
        Wait = 0,
        Walk = 1,
    };
}
namespace via::render::ExperimentalRayTrace {
    enum VFXMedianFilter {
        Vertical = 0,
        Horizontal = 1,
        Plus = 2,
        Cross = 3,
        Square = 4,
    };
}
namespace app::CH9Em7800::Goal::GoalGenerator {
    enum ID {
        Appear = 0,
        Wander = 1,
        Discovery = 2,
        UnDiscovery = 3,
        ClosedRoute = 4,
        IdleLostTarget = 5,
        Idle = 6,
        Follow = 7,
        Grapple = 8,
        Dodge = 9,
        WallAttack = 10,
        StrikeScratch = 11,
        StrikeJump = 12,
        StrikeLongJump = 13,
        StrikeDash = 14,
        StrikeDuctPursuit = 15,
        AroundFlewover = 16,
        Door = 17,
        DoorOpen = 18,
        DoorOpen2 = 19,
        DoorClose = 20,
        DoorClose2 = 21,
        Move = 22,
        AppearAction = 23,
        IdleAction = 24,
        IdleLostTargetAction = 25,
        NoticeAction = 26,
        WallAttackAction = 27,
        StrikeScratchAction = 28,
        StrikeJumpAction = 29,
        StrikeLongJumpAction = 30,
        StrikeDashAction = 31,
        StrikeDuctPursuitAction = 32,
        AroundFlewoverAction = 33,
        DodgeAction = 34,
        GrappleAction = 35,
        WanderIdle = 36,
        WanderIdleAction = 37,
    };
}
namespace app::CH8ResultMenu {
    enum Process {
        eProc_Prepare = 0,
        eProc_Wait = 1,
        eProc_LogoDisp = 2,
        eProc_Result = 3,
        eProc_Result_1 = 4,
        eProc_Clear = 5,
        eProc_Clear_1 = 6,
        eProc_Clear_2 = 7,
        eProc_FadeOut = 8,
        eProc_End = 9,
    };
}
namespace via::render {
    enum MaterialShadingType {
        Standard = 0,
        Decal = 1,
        DecalWithMetallic = 2,
        DecalNRMR = 3,
        Transparent = 4,
        Distortion = 5,
        PrimitiveMesh = 6,
        PrimitiveSolidMesh = 7,
        Water = 8,
        SpeedTree = 9,
        GUI = 10,
        GUIMesh = 11,
        GUIMeshTransparent = 12,
        ExpensiveTransparent = 13,
        Forward = 14,
        RenderTarget = 15,
        PostProcess = 16,
        PrimitiveMaterial = 17,
        PrimitiveSolidMaterial = 18,
        PrimitiveSolidMaterialExpensive = 19,
        SpineMaterial = 20,
        VolumetricFog = 21,
        Max = 22,
    };
}
namespace via::motion::tree::GamePadTriggerNode {
    enum TriggerKind {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em8000::Action::Em8000KneeDown {
    enum KneeDownAttackType {
        None = 0,
        SwingAttack = 1,
        CrazyAttack = 2,
        EndAttack = 3,
    };
}
namespace app::CH9Em5850 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace via::render {
    enum HDROutputFormat {
        None = 0,
        HDR10 = 1,
        scRGB = 2,
    };
}
namespace app::InteractShadowPuzzle {
    enum PuzzleState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        Success = 3,
        SuccessWait = 4,
        NotSuccess = 5,
        ErrorWait = 6,
        Close = 7,
        Exit = 8,
    };
}
namespace via::network::session {
    enum CompOperator {
        None = 0,
        EQ = 1,
        NE = 2,
        GT = 3,
        GE = 4,
        LT = 5,
        LE = 6,
    };
}
namespace app::Attention {
    enum Type {
        Player = 0,
        Enemy = 1,
        Marker = 2,
    };
}
namespace System::Reflection {
    enum ParameterAttributes {
        None = 0,
        In = 1,
        Out = 2,
        Lcid = 4,
        Retval = 8,
        Optional = 16,
        HasDefault = 4096,
        HasFieldMarshal = 8192,
        Reserved3 = 16384,
        Reserved4 = 32768,
        ReservedMask = 61440,
    };
}
namespace System {
    enum StringSplitOptions {
        None = 0,
        RemoveEmptyEntries = 1,
    };
}
namespace via::render::Shadow {
    enum ShadowPriority {
        Low = 0,
        Normal = 1,
        High = 2,
        Max = 3,
    };
}
namespace app::MoldedActionController {
    enum WwiseSwitchList {
        HeadON = 0,
        HeadOFF = 1,
        LeftArmON = 2,
        LeftArmOFF = 3,
        RightArmON = 4,
        RightArmOFF = 5,
    };
}
namespace via::audiorender {
    enum LowPassFilterParameter {
        OutputGain = 0,
        OutputGainDb = 1,
        Frequency = 2,
        Q = 3,
        Gain = 4,
        GainDb = 5,
    };
}
namespace app::CH9Em7900ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
    };
}
namespace app::GameEventAction {
    enum InterpStartTypeEnum {
        DelayPosAndRot = 0,
        DelayPosOnly = 1,
    };
}
namespace app::Humanoid {
    enum HandAdjustModeType {
        AdjustFromRoot = 0,
        AdjustFromElbow = 1,
    };
}
namespace via::effect::graph {
    enum ItemType {
    };
}
namespace System::Runtime::CompilerServices {
    enum MethodImplOptions {
        Unmanaged = 4,
        NoInlining = 8,
        ForwardRef = 16,
        Synchronized = 32,
        NoOptimization = 64,
        PreserveSig = 128,
        AggressiveInlining = 256,
        InternalCall = 4096,
    };
}
namespace via::nnfc::nfp {
    enum ErrorDialogCode {
        None = 0,
        WirelessOff = 1,
        NotSupport = 2,
        InvalidFormatVer = 3,
    };
}
namespace app::Gunturret {
    enum Rno {
        Searching = 0,
        Detected = 1,
        Shooting = 2,
        Termination = 3,
        End = 4,
    };
}
namespace app::MissionDetail {
    enum Category {
        Main = 0,
        Sub = 1,
        Other = 2,
    };
}
namespace via::physics::ShapeCastResult {
    enum Result {
        Success = 0,
        Failure = 1,
    };
}
namespace via::motion::SecondaryRetarget {
    enum IkCalcType {
        Ik2Bone = 0,
        Ik2BoneBeast = 1,
        Ik3BoneZigzag = 2,
        Ik3BoneConvex = 3,
    };
}
namespace via::Window::MessageArgs {
    enum Button {
        L = 0,
        R = 1,
        M = 2,
        EX0 = 3,
        EX1 = 4,
    };
}
namespace app::HandLightDirectionDelayController {
    enum FollowState {
        Wait = 0,
        FollowSlow = 1,
        FollowFast = 2,
    };
}
namespace app::Em3002::Em3002WwiseMonitoredValue {
    enum GameRank {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        MAX = 10,
    };
}
namespace app::CH9Em5800Think {
    enum ThinkMode {
        Normal = 0,
        NoThink = 1,
        Passive = 2,
    };
}
namespace app::BedRoom::BedRoomMonitoringGimick {
    enum FalidMessageSituation {
        EnterRoom = 0,
        TraySurvice = 1,
    };
}
namespace app::Em3100::Action::Run {
    enum Type {
        Default = 0,
        Patrol = 1,
    };
}
namespace app::CH9Em5901::Action {
    enum ActionNo {
        Idle = 0,
        Attack = 1,
        Damage = 2,
        Dead = 3,
    };
}
namespace via::motion::IkLegSpine {
    enum RayCastSkipOption {
        None = 1,
        DIV2 = 2,
        DIV4 = 4,
        DIV6 = 6,
    };
}
namespace via::autoplay::action::AutoAttack {
    enum TurningSpeed {
        Turning_Fast = 0,
        Turning_Normal = 1,
        Turning_Slow = 2,
    };
}
namespace via::fsm::TreeNode {
    enum Attribute {
        BranchOnly = 0,
        DisableNetworkSync = 1,
        AttributeBitNum = 32,
    };
}
namespace app::Cp7TwentyOneInGameData {
    enum BoolType {
        IsFingerBetGame = 0,
        IsElectricBetGame = 1,
        IsSawBetGame = 2,
        _Max = 3,
    };
}
namespace app {
    enum ActiveUserPadPairingResult {
        OK = 0,
        NecessaryAccountPicker = 1,
        NecessaryLastInputDevice = 2,
    };
}
namespace via::hid {
    enum MouseButton {
        NONE = 0,
        L = 1,
        R = 2,
        C = 4,
        UP = 8,
        DOWN = 16,
        EX0 = 32,
        EX1 = 64,
        All = 4294967295,
    };
}
namespace app::Em3002::Action::OpenDoor {
    enum Type {
        Normal = 0,
        Kick = 1,
    };
}
namespace via::effect::vortexel {
    enum VelocityShapeType {
        Box = 0,
        Sphere = 1,
        Cone = 2,
        Cylinder = 3,
    };
}
namespace app::CH9Em7800::Action::WanderIdle {
    enum Type {
        Normal = 0,
    };
}
namespace app::PharmacyDictionary {
    enum PageMoveTo {
        Prev = -1,
        Next = 1,
    };
}
namespace app::CH9Em7800ActionController {
    enum MoveType {
        Default = 0,
        ForceSolo = 1,
    };
}
namespace via::effect::gpgpu::PolygonCS::PolygonResource {
    enum PolygonComputeShaderType {
        InitializeCS = 0,
        MaxType = 1,
    };
}
namespace app::Em8000::Action::Em8000ActionBase {
    enum SequenceEndType {
        None = 0,
        ActionEnd = 1,
        NextState = 2,
    };
}
namespace app::fsm::CH8ItemTest {
    enum CheckTarget {
        Inventory = 0,
        ItemBox = 1,
        InventoryAndItemBox = 2,
    };
}
namespace via::hid::virtualKeyboard {
    enum VirtualKeyboardResult {
        OK = 0,
        Canceled = 1,
        Aborted = 2,
        Closed = 3,
        Error = 4,
    };
}
namespace via::network::error {
    enum Level {
        None = 0,
        Request = 1,
        Service = 2,
        Context = 3,
        User = 4,
        App = 5,
    };
}
namespace via::motion {
    enum JointGroup {
        Default = 0,
        Group1 = 1,
        Group2 = 2,
        Group3 = 3,
        Group4 = 4,
        Group5 = 5,
        Group6 = 6,
    };
}
namespace via::os::http_client {
    enum RedirectPolicy {
        Never = 0,
        Always = 1,
        DisallowHttpsToHttp = 2,
        NoSchemeChanges = 3,
        MAX = 4,
    };
}
namespace app::Em8001::Message {
    enum Tag {
        None = 0,
        General_Player_Encount_Near_A = 10100,
        General_Player_Encount_Near_B = 10101,
        General_Player_Encount_Near_C = 10102,
        General_Player_Encount_Near_D = 10103,
        General_Player_Encount_Near_E = 10104,
        General_Player_Encount_Near_F = 10105,
        General_Player_Encount_Near_G = 10106,
        General_Player_Encount_Near_H = 10107,
        General_Player_Encount_Near_I = 10108,
        General_Player_Encount_Far_A = 10200,
        General_Player_Encount_Far_B = 10201,
        General_Player_Encount_Far_C = 10202,
        General_Player_Encount_Far_D = 10203,
        General_Player_Encount_Far_E = 10204,
        General_Player_Encount_Far_F = 10205,
        General_Player_Encount_Far_G = 10206,
        General_Player_Encount_Far_H = 10207,
        General_Player_Encount_Far_I = 10208,
        General_Player_Lost_A = 10300,
        General_Player_Lost_B = 10301,
        General_Player_Lost_C = 10302,
        General_Player_Lost_D = 10303,
        General_Player_Lost_E = 10304,
        General_Player_Lost_F = 10305,
        General_Player_Lost_G = 10306,
        General_Player_Search_A = 10400,
        General_Player_Search_B = 10401,
        General_Player_Search_C = 10402,
        General_Player_Search_D = 10403,
        General_Player_Search_E = 10404,
        General_Player_Search_F = 10405,
        General_Player_Search_G = 10406,
        General_Player_Search_H = 10407,
        General_Player_Search_I = 10408,
        General_Player_Search_J = 10409,
        General_Player_Search_K = 10410,
        General_Player_Discovery_Normal_A = 10500,
        General_Player_Discovery_Normal_B = 10501,
        General_Player_Discovery_Normal_C = 10502,
        General_Player_Discovery_Normal_D = 10503,
        General_Player_Discovery_Normal_E = 10504,
        General_Player_Discovery_Normal_F = 10505,
        General_Player_Discovery_High_A = 10600,
        General_Player_Discovery_High_B = 10601,
        General_Player_Discovery_High_C = 10602,
        General_Player_Discovery_High_D = 10603,
        General_Player_Discovery_High_E = 10604,
        General_Attack_Start_A = 10700,
        General_Attack_Start_B = 10701,
        General_Attack_Start_C = 10702,
        General_Attack_Start_D = 10703,
        General_Attack_Start_E = 10704,
        General_Attack_Start_F = 10705,
        General_Attack_Start_G = 10706,
        General_Attack_Start_H = 10707,
        General_Attack_Hitted_A = 10800,
        General_Attack_Hitted_B = 10801,
        General_Attack_Hitted_C = 10802,
        General_Attack_Hitted_D = 10803,
        General_Attack_Hitted_E = 10804,
        General_Attack_Missed_A = 10900,
        General_Attack_Missed_B = 10901,
        General_Attack_Missed_C = 10902,
        General_Attack_Missed_D = 10903,
        General_Attack_Missed_E = 10904,
        General_Attack_Missed_F = 10905,
        General_Attack_Missed_G = 10906,
        General_Attack_Guarded_A = 11000,
        General_Attack_Guarded_B = 11001,
        General_Attack_Guarded_C = 11002,
        General_Attack_Guarded_D = 11003,
        General_Attack_Guarded_E = 11004,
        General_Attack_Guarded_F = 11005,
        General_Attack_Guarded_G = 11006,
        General_Attack_Guarded_H = 11007,
        General_Damage_Melee_A = 11100,
        General_Damage_Melee_B = 11101,
        General_Damage_Melee_C = 11102,
        General_Damage_Melee_D = 11103,
        General_Damage_Gun_A = 11200,
        General_Damage_Gun_B = 11201,
        General_Damage_Gun_C = 11202,
        General_Damage_Gun_D = 11203,
        General_Damage_Other_A = 11300,
        General_Damage_Other_B = 11301,
        General_Damage_Other_C = 11302,
        General_Damage_Other_D = 11303,
        General_Player_OutOfAmmo_A = 11400,
        First_Damage_Melee_A = 20100,
        First_Damage_Melee_B = 20101,
        First_Player_Encount_A = 20200,
        First_Player_Encount_B = 20201,
        Exclusive_Attack_InstantDeath_A = 30100,
        Exclusive_Attack_InstantDeath_B = 30101,
        Exclusive_Grapple_ShotGunGuard_A = 30200,
        Exclusive_Grapple_ShotGunGuard_B = 30201,
        Exclusive_Grapple_ShotGunGuard_C = 30202,
        Exclusive_Grapple_ShotGunGuard_D = 30203,
        Exclusive_Player_Dead_A = 30300,
        Exclusive_Dead_A = 30400,
    };
}
namespace via::audiorender {
    enum WavChunkTag {
        Riff = 1380533830,
        Fmt = 1718449184,
        Data = 1684108385,
        Smpl = 1936552044,
        Fact = 1717658484,
        Version = 1986359854,
        Cue = 1668637984,
        List = 1818848884,
        LIST = 1279873876,
        Labl = 1818321516,
        Ixml = 1767394636,
        Junk = 1247104587,
        Cdif = 1128556902,
    };
}
namespace app::CH8Em4500WwiseStateList {
    enum Em4500StateID {
        BLADE_LV1 = 0,
        BLADE_LV2 = 1,
        END = 2,
        SILENCE = 3,
        Max = 4,
    };
}
namespace via::landscape {
    enum BakerBakeTarget {
        Mesh = 0,
        Path = 1,
        Road = 2,
        Ground = 3,
        FoliageMap = 4,
        HeightIntersect = 5,
        MeshUserAttribute = 6,
    };
}
namespace app::Weapon {
    enum MotionID {
        Idle = 0,
        Attack = 1,
        GetWeapon = 2,
        GetWeaponSp = 3,
        Reload = 4,
        ReloadSp = 5,
        ReloadRepeatStart = 6,
        ReloadRepeat = 7,
        ReloadRepeatEnd = 8,
        ReloadDBStart = 9,
        ReloadDBOver = 10,
        ReloadDBOverToUnder = 11,
        ReloadDBUnder = 12,
        ReloadDBEnd = 13,
        ChangeMode = 14,
        Use = 15,
    };
}
namespace app::InventoryContextMenu {
    enum ResultType {
        NowSelecting = 0,
        Canceled = 1,
        Selected = 2,
    };
}
namespace via::clr {
    enum PropertyFlag {
        SpecialName = 512,
        RTSpecialName = 1024,
        HasDefault = 4096,
        ExposeMember = 16384,
    };
}
namespace app::CarInGarage::DrivedByEnemy {
    enum Mode {
        CrashInReverse = 0,
        CrashInFront = 1,
        Front = 2,
        Reverse = 3,
        Damaged = 4,
        PrepareCrash = 5,
        WaitCrash = 6,
        Break = 7,
        End = 8,
    };
}
namespace via::network::context {
    enum Option {
        None = 0,
    };
}
namespace app::CH9Em7500Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace app::fsm::CH8TramPuzzleAction {
    enum Type {
        None = 0,
        Overlapping = 1,
    };
}
namespace via::render::compress {
    enum JpegSamplingRatio {
        YUV444 = 0,
        YUV422 = 1,
        YUV420 = 2,
        YUV411 = 3,
    };
}
namespace via::geometry {
    enum BrushType {
        Additive = 0,
        Subtractive = 1,
    };
}
namespace via::wwiselib {
    enum WwiseModuleType {
        Default = 0,
        SimpleWwise = 1,
        Wwise = 2,
        None = 3,
    };
}
namespace via::timeline::UserCurvePlayer {
    enum DevPlayState {
        Disable = 0,
        Play = 1,
        Pause = 2,
    };
}
namespace app::MapManager {
    enum MapChangeDir {
        Up = 0,
        Down = 1,
    };
}
namespace via::audiorender {
    enum WavTypeId {
        WAVE = 1463899717,
        adtl = 1633973356,
    };
}
namespace app::OptionKeyBind {
    enum State {
        Selection = 0,
        KeyReceiving = 1,
        EmptyCutin = 2,
        ErrorCutin = 3,
        DefaultCutin = 4,
    };
}
namespace app::ClothCollision::CollisionInfo {
    enum ShapeType {
        Plane = 0,
        Sphere = 1,
        Capsule = 2,
    };
}
namespace app::CH8Em4500::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace via::behaviortree::action::Trace {
    enum TraceType {
        Info = 0,
        Warning = 1,
        Error = 2,
    };
}
namespace via::detail::atomic {
    enum SizeClassifier {
        Default = 0,
        Native = 1,
    };
}
namespace via::behaviortree::action {
    enum DataSetOn {
        Start = 0,
        Update = 1,
        NodeEndNotified = 2,
        End = 3,
    };
}
namespace via::render {
    enum BlueNoiseSpp {
        BlueNoiseSpp_1spp = 0,
        BlueNoiseSpp_2spp = 1,
        BlueNoiseSpp_4spp = 2,
        BlueNoiseSpp_8spp = 3,
        BlueNoiseSpp_16spp = 4,
        BlueNoiseSpp_32spp = 5,
        BlueNoiseSpp_64spp = 6,
        BlueNoiseSpp_128spp = 7,
        BlueNoiseSpp_256spp = 8,
        BlueNoiseSpp_Max = 9,
    };
}
namespace via::motion::JointInfo {
    enum Type {
        Joint = 0,
        Append = 1,
        Extra = 2,
        Locator = 3,
    };
}
namespace via {
    enum UserState {
        Invalid = 65535,
        Login = 0,
        Logout = 1,
        Max = 2,
    };
}
namespace via::motion::IkLeg {
    enum RayCastSkipOption {
        None = 1,
        DIV2 = 2,
        DIV4 = 4,
    };
}
namespace app::Em3001::Em3001WwiseMonitoredValue {
    enum PropertyEncount {
        InCamera = 0,
        OutCamera = 1,
        Max = 2,
    };
}
namespace app::CH8GameRankManager {
    enum RankPointType {
        PlGetItem = 0,
        EmAttackFailed = 1,
        PlDying = 2,
        PlRetry = 3,
        EmLostHead = 4,
        EmHeadShot = 5,
    };
}
namespace via::render::PrimitiveMesh::Attribute {
    enum BufferType {
        None = 0,
        Instancing = 1,
        GpuInstacing = 2,
        Deformable = 3,
        Transparent = 4,
    };
}
namespace via::motion::RetargetFourLegRig {
    enum JointTypes {
        Head = 0,
        EndNeck = 1,
        BaseNeck = 2,
        EndSpine = 3,
        BaseSpine = 4,
        Cog = 5,
        ForeLeftFoot = 6,
        ForeRightFoot = 7,
        BackLeftFoot = 8,
        BackRightFoot = 9,
        EndTail = 10,
        BaseTail = 11,
        MAX = 12,
    };
}
namespace app::CH9ShellManager {
    enum ThrowingWeaponType {
        Knuckle = 0,
        CH9_WP000 = 1,
        CH9_WP001 = 2,
        CH9_WP002 = 3,
        CH9_WP003 = 4,
        CH9_WP004 = 5,
        CH9_WP005 = 6,
        CH9_WP006 = 7,
        CH9_WP007 = 8,
        CH9_WP008 = 9,
        CH9_WP009 = 10,
    };
}
namespace app::TutorialGUI {
    enum VRFixMenu {
        CRAFTBENCHINVENTORY = 4,
    };
}
namespace via::render::layer::PostDeferredLighting {
    enum Segment {
        Default = 0,
    };
}
namespace app::Em3101::Action {
    enum ActionNo {
        Idle = 0,
        Run = 1,
        Grapple = 2,
    };
}
namespace app::EnemyActionController {
    enum StandingType {
        Standing = 0,
        Downing = 1,
        Crouching = 2,
        Falling = 3,
    };
}
namespace via::render {
    enum GlobalSDFResolution {
        W128xH64xD128 = 0,
    };
}
namespace via::memory {
    enum AllocPolicy {
        Efficiency = 0,
        Default = 1,
        Performance = 2,
    };
}
namespace via::wwise::SetState2 {
    enum SetTiming {
        Start = 0,
        End = 1,
    };
}
namespace via::fighter::FighterActionContainer {
    enum DevPlayState {
        Disable = 0,
        Play = 1,
        Pause = 2,
    };
}
namespace via::render::FFX {
    enum UpscaleType {
        None = 0,
        UltraQuality = 1,
        Quality = 2,
        Balanced = 3,
        Performance = 4,
    };
}
namespace via::reflection {
    enum TypeKind {
        Unknown = 0,
        Enum = 1,
        Boolean = 2,
        Int8 = 3,
        Uint8 = 4,
        Int16 = 5,
        Uint16 = 6,
        Int32 = 7,
        Uint32 = 8,
        Int64 = 9,
        Uint64 = 10,
        Single = 11,
        Double = 12,
        C8 = 13,
        C16 = 14,
        Char = 14,
        String = 15,
        Struct = 16,
        Class = 17,
        Num = 18,
    };
}
namespace via::gui::BlurManager {
    enum BlurFilterType {
        BlurMipMapHorizontal = 0,
        BlurMipMapVertical = 1,
        BlurFinal = 2,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraCaptureWaitFrameType {
        OffMode0 = 1,
        OffMode1 = 2,
        OnMode0 = 3,
        OnMode1 = 4,
    };
}
namespace app::CassettLabelPartsController {
    enum PartsNo {
        Normal = 0,
        Arabic = 1,
    };
}
namespace app::Em8100::Action::Damage {
    enum Type {
        NoDamage = 0,
        LFront = 1,
        LFrontR = 2,
        LFrontL = 3,
        LRight = 4,
        LRightR = 5,
        LRightL = 6,
        LLeft = 7,
        LLeftR = 8,
        LLeftL = 9,
        LBack = 10,
        LBackR = 11,
        LBackL = 12,
        LGrab = 13,
        LDrop = 14,
        LDropR = 15,
        LDropL = 16,
        LDropLast = 17,
        LDropDown = 18,
    };
}
namespace app::OptionListItem {
    enum DisableMessageType {
        General = 0,
        VrOn = 1,
        VrOff = 2,
        MainMenu = 3,
        HDRMode = 4,
        NotHDRMode = 5,
        HDRConnected = 6,
        RayTracingOn = 7,
        RayTracingOff = 8,
        HardwareNotSupport = 9,
        FidelityFXOff = 10,
    };
}
namespace via::audiorender::fx::mt_equalizer {
    enum EQUnitEnable {
        False = 0,
        True = 1,
    };
}
namespace via::render {
    enum AccelerationStructureBuildFlag {
        PreferFastTrace = 1,
        PreferFastBuild = 2,
        AllowUpdate = 4,
        AllowCompaction = 8,
        FastBuild = 2,
        FastBuildAndUpdate = 6,
        FastTrace = 1,
        FastTraceAllowCompaction = 9,
        FastTraceAndUpdate = 5,
    };
}
namespace app::CH9Em7900::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::MoldedActionController {
    enum CancelTimingType {
        HasAttackPermit = 0,
        NearPlayer = 1,
        Guarded = 2,
        FarPlayer = 3,
        NearPlayerHasAttackPermit = 4,
        FarPlayerHasAttackPermit = 5,
    };
}
namespace via::autoplay {
    enum PlayerIndex {
        Player1 = 0,
        Player2 = 1,
        Player3 = 2,
        Player4 = 3,
    };
}
namespace System::Globalization {
    enum TimeSpanStyles {
        None = 0,
        AssumeNegative = 1,
    };
}
namespace app::CH9Em7700::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace via::motion::IkDog {
    enum RayCastMode {
        Default = 0,
        Normal = 1,
    };
}
namespace via::network::ranking::ScoreInfoTbl {
    enum SortMode {
        None = 0,
        RankAscend = 1,
        RankDescend = 2,
        ValueAscend = 3,
        ValueDescend = 4,
    };
}
namespace via::graph {
    enum VertexRemoveOption {
        None = 0,
        WithEdge = 1,
    };
}
namespace app::CH8SaveManager {
    enum SaveTextIndex {
        SLOT_TEXT_INDEX_GUID = 0,
        SLOT_TEXT_INDEX_DIFFICULTY = 1,
        SLOT_TEXT_INDEX_PLAY_TIME = 2,
        SLOT_TEXT_INDEX_OBJECTIVE = 3,
        SLOT_TEXT_INDEX_COUNT = 4,
    };
}
namespace app::CH8Em4500::CH8ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace via::motion::tree {
    enum ParamType {
        Bool = 0,
        U8 = 1,
        S8 = 2,
        U16 = 3,
        S16 = 4,
        S32 = 5,
        U32 = 6,
        S64 = 7,
        U64 = 8,
        F32 = 9,
        F64 = 10,
        Str8 = 11,
        Str16 = 12,
        ExtraData = 13,
        Herimite = 14,
        Guid = 15,
        Vec2 = 16,
        Vec3 = 17,
        Vec4 = 18,
        Matrix = 19,
    };
}
namespace app::CH9Em7700::ThinkAppearSet {
    enum Type {
        Default = 0,
        NoUse_Low1 = 10,
        FromLow2_Speedy = 11,
        NoUse_Middle1 = 20,
        FromMiddle2_Micheal = 21,
        NoUse_Middle3 = 22,
        FromMiddle4_Speedy = 23,
        FromCeil1_High = 30,
        FromCeil2_Speedy = 31,
        NoUse_CrawlLow1 = 40,
        FromCrawlLow2_Speedy = 41,
        NoUse_CrawlMiddle1 = 50,
        FromCrawlMiddle2_Speedy = 51,
        NoUse_Mimicry1 = 60,
        Mimicry2_Lying = 61,
        Mimicry3_Stand = 62,
        NoUse_Mimicry4 = 63,
        NoUse_Mimicry5 = 64,
        FromMimicry = 70,
        FromCorpse = 80,
        FromMorgue = 90,
        FromFirst = 100,
        FromFirstStay = 101,
        Shout = 200,
        ShoutWait = 201,
        FromGround = 300,
        Summon = 301,
        Cry = 400,
        Scratch = 401,
    };
}
namespace app::EffectManager {
    enum CacheAccessStatusEnum {
        None = 0,
        Alloc = 1,
        Release = 2,
        Create = 3,
        Delete = 4,
    };
}
