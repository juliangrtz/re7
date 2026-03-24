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
namespace System {
    enum Base64FormattingOptions {
        None = 0,
        InsertLineBreaks = 1,
    };
}
namespace System::Collections::Hashtable::EntryEnumerator {
    enum Mode {
        Entry = 0,
        Key = 1,
        Value = 2,
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
namespace System {
    enum DateTimeKind {
        Unspecified = 0,
        Utc = 1,
        Local = 2,
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
namespace System::Diagnostics::DebuggableAttribute {
    enum DebuggingModes {
        None = 0,
        Default = 1,
        DisableOptimizations = 2,
        IgnoreSymbolStoreSequencePoints = 3,
        EnableEditAndContinue = 4,
    };
}
namespace System::Diagnostics {
    enum DebuggerBrowsableState {
        Never = 0,
        Collapsed = 2,
        RootHidden = 3,
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
namespace System::IO {
    enum SeekOrigin {
        Begin = 0,
        Current = 1,
        End = 2,
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
namespace System::Runtime::CompilerServices {
    enum CompilationRelaxations {
        NoStringInterning = 0,
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
namespace System::Runtime::CompilerServices {
    enum MethodImplOptions {
        Unmanaged = 4,
        ForwardRef = 16,
        PreserveSig = 128,
        InternalCall = 4096,
        Synchronized = 32,
        NoInlining = 8,
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
namespace System::Runtime::InteropServices {
    enum LayoutKind {
        Sequential = 0,
        Explicit = 2,
        Auto = 3,
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
namespace System::Text {
    enum NormalizationForm {
        FormC = 1,
        FormD = 2,
        FormKC = 5,
        FormKD = 6,
    };
}
namespace System::Threading {
    enum ApartmentState {
        STA = 0,
        MTA = 1,
        Unknown = 2,
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
namespace via {
    enum SoftwarePrefetchLevel {
    };
}
namespace via {
    enum bitset_assign_option {
        bits = 0,
        pos = 1,
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
namespace via {
    enum FileAccessPriority {
        TimeCritical = 0,
        Normal = 16383,
        Idle = 32767,
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
namespace via {
    enum PropertiedEventInvokeTiming {
        Equal = 0,
        NotEqual = 1,
        Ever = 2,
        Never = 3,
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
        Max = 23,
        Unknown = 23,
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
namespace via {
    enum Access {
        Private = 0,
        Public = 1,
    };
}
namespace via {
    enum PropKind {
        AutoDetect = 0,
        Getter = 1,
        Setter = 2,
        ArrayGetter = 3,
        ArraySetter = 4,
        Event = 5,
    };
}
namespace via {
    enum Hide {
        Script = 1,
        Tool = 2,
        Public = 4,
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
    };
}
namespace via {
    enum FsmCategory {
        None = 0,
        Fsm = 1,
        Mot = 2,
    };
}
namespace via {
    enum ModuleEntry {
        Initialize = 0,
        InitializeDialog = 1,
        InitializeStorage = 2,
        InitializeResourceManager = 3,
        InitializeScene = 4,
        InitializeRemoteHost = 5,
        InitializeVM = 6,
        InitializeSystemService = 7,
        InitializeShareService = 8,
        InitializeUserService = 9,
        InitializeGlobalUserData = 10,
        InitializeSteam = 11,
        InitializeRenderer = 12,
        InitializeHID = 13,
        InitializeEffect = 14,
        InitializeWwise = 15,
        InitializeGUI = 16,
        InitializeMotion = 17,
        InitializeBehaviorTree = 18,
        InitializeFSM = 19,
        InitializeNavigation = 20,
        InitializeTimeline = 21,
        InitializePhysics = 22,
        InitializeDynamics = 23,
        InitializeHavok = 24,
        InitializeNetwork = 25,
        InitializePuppet = 26,
        InitializeStore = 27,
        InitializeBrowser = 28,
        InitializeDevelopSystem = 29,
        InitializeBehavior = 30,
        InitializeMovie = 31,
        InitializeSkuService = 32,
        InitializeTelemetry = 33,
        InitializeThreadPool = 34,
        Setup = 35,
        SetupResourceManager = 36,
        SetupStorage = 37,
        SetupGlobalUserData = 38,
        SetupScene = 39,
        SetupDevelopSystem = 40,
        SetupUserService = 41,
        SetupSystemService = 42,
        SetupShareService = 43,
        SetupVM = 44,
        SetupHID = 45,
        SetupRenderer = 46,
        SetupEffect = 47,
        SetupWwise = 48,
        SetupMotion = 49,
        SetupNavigation = 50,
        SetupPhysics = 51,
        SetupDynamics = 52,
        SetupHavok = 53,
        SetupMovie = 54,
        SetupNetwork = 55,
        SetupPuppet = 56,
        SetupStore = 57,
        SetupBrowser = 58,
        SetupVoiceChat = 59,
        SetupSkuService = 60,
        SetupTelemetry = 61,
        StartApp = 62,
        SetupBehaviorTree = 63,
        SetupFSM = 64,
        SetupGUI = 65,
        Start = 66,
        StartStorage = 67,
        StartGlobalUserData = 68,
        StartPhysics = 69,
        StartDynamics = 70,
        StartGUI = 71,
        StartTimeline = 72,
        StartBehaviorTree = 73,
        StartFSM = 74,
        StartWwise = 75,
        StartScene = 76,
        Update = 77,
        UpdateDialog = 78,
        UpdateRemoteHost = 79,
        UpdateStorage = 80,
        UpdateScene = 81,
        UpdateDevelopSystem = 82,
        UpdateWidget = 83,
        UpdateCapture = 84,
        PreupdateBehavior = 85,
        BeginDynamics = 86,
        UpdateHID = 87,
        PreupdateGUI = 88,
        UpdateMotionFrame = 89,
        BeginHavok = 90,
        UpdateAIMap = 91,
        CreatePreupdateGroupFSM = 92,
        UpdateGlobalUserData = 93,
        UpdateUserService = 94,
        UpdateSystemService = 95,
        UpdateShareService = 96,
        UpdateSteam = 97,
        BeginPhysics = 98,
        BeginUpdatePrimitive = 99,
        UpdateGUI = 100,
        PreupdateBehaviorTree = 101,
        PreupdateFSM = 102,
        UpdateBehavior = 103,
        CreateNavigationChain = 104,
        UpdateDynamicsAfterUpdate = 105,
        CreateUpdateGroupFSM = 106,
        UpdateTimeline = 107,
        UpdateBehaviorTree = 108,
        UpdateNavigationPrev = 109,
        UpdateFSM = 110,
        UpdateMotion = 111,
        UpdatePhysicsAfterUpdatePhase = 112,
        UpdatePhysicsCharacterController = 113,
        BeginUpdateHavok2 = 114,
        SolveBeginDynamics = 115,
        UpdateNavigation = 116,
        UpdateConstraintsBegin = 117,
        LateUpdateBehavior = 118,
        EditUpdateBehavior = 119,
        BeginUpdateHavok = 120,
        UpdateDynamicsAfterLateUpdate = 121,
        BeginUpdateEffect = 122,
        UpdateConstraintsEnd = 123,
        UpdatePhysicsAfterLateUpdatePhase = 124,
        PrerenderGUI = 125,
        PrepareRendering = 126,
        UpdateWwise = 127,
        CreateSelectorGroupFSM = 128,
        UpdateNetwork = 129,
        UpdateHavok = 130,
        EndUpdateHavok = 131,
        UpdateDynamics = 132,
        UpdatePuppet = 133,
        UpdateStore = 134,
        UpdateBrowser = 135,
        UpdateVoiceChat = 136,
        UpdateBehaviorTreeSelector = 137,
        UpdateFSMSelector = 138,
        BeforeLockSceneRendering = 139,
        SolveEndDynamics = 140,
        EndUpdateHavok2 = 141,
        UpdateJointExpression = 142,
        UpdateEffect = 143,
        EndUpdateEffect = 144,
        LockScene = 145,
        WaitRendering = 146,
        BeginRendering = 147,
        RenderGUI = 148,
        UpdatePrimitive = 149,
        EndUpdatePrimitive = 150,
        GUIPostPrimitiveRender = 151,
        ShapeRenderer = 152,
        UpdateMovie = 153,
        UpdateTelemetry = 154,
        DrawWidget = 155,
        DevelopRenderer = 156,
        EndRendering = 157,
        EndDynamics = 158,
        EndPhysics = 159,
        UnlockScene = 160,
        UpdateVM = 161,
        StepVisualDebugger = 162,
        WaitForVblank = 163,
        Terminate = 164,
        TerminateScene = 165,
        TerminateRemoteHost = 166,
        TerminateTelemetry = 167,
        TerminateMovie = 168,
        TerminateWwise = 169,
        TerminateVoiceChat = 170,
        TerminatePuppet = 171,
        TerminateNetwork = 172,
        TerminateStore = 173,
        TerminateBrowser = 174,
        TerminateGUI = 175,
        TerminateBehaviorTree = 176,
        TerminateFSM = 177,
        TerminateNavigation = 178,
        TerminateEffect = 179,
        TerminateRenderer = 180,
        TerminateHID = 181,
        TerminateDynamics = 182,
        TerminatePhysics = 183,
        TerminateResourceManager = 184,
        TerminateHavok = 185,
        TerminateShareService = 186,
        TerminateGlobalUserData = 187,
        TerminateStorage = 188,
        TerminateVM = 189,
        Finalize = 190,
        FinalizeThreadPool = 191,
        FinalizeTelemetry = 192,
        FinalizeMovie = 193,
        FinalizeBehavior = 194,
        FinalizeDevelopSystem = 195,
        FinalizeTimeline = 196,
        FinalizePuppet = 197,
        FinalizeNetwork = 198,
        FinalizeStore = 199,
        FinalizeBrowser = 200,
        FinalizeBehaviorTree = 201,
        FinalizeFSM = 202,
        FinalizeNavigation = 203,
        FinalizeMotion = 204,
        FinalizeDynamics = 205,
        FinalizePhysics = 206,
        FinalizeHavok = 207,
        FinalizeGUI = 208,
        FinalizeWwise = 209,
        FinalizeEffect = 210,
        FinalizeRenderer = 211,
        FinalizeHID = 212,
        FinalizeSteam = 213,
        FinalizeGlobalUserData = 214,
        FinalizeSkuService = 215,
        FinalizeUserService = 216,
        FinalizeShareService = 217,
        FinalizeSystemService = 218,
        FinalizeScene = 219,
        FinalizeVM = 220,
        FinalizeResourceManager = 221,
        FinalizeRemoteHost = 222,
        FinalizeStorage = 223,
        FinalizeDialog = 224,
    };
}
namespace via {
    enum ProjectionType {
        PerspectiveFovRH = 0,
        OrthographicRH = 1,
        Max = 2,
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
namespace via {
    enum AspectRatio {
        Fit = 0,
        Uniform4x3 = 1,
        Uniform16x9 = 2,
        Uniform16x10 = 3,
    };
}
namespace via {
    enum DisplayType {
        Fit = 0,
        Uniform4x3 = 1,
        Uniform16x9 = 2,
        Uniform16x10 = 3,
        Fix480p = 4,
        Fix720p = 5,
        Fix1080p = 6,
        Fix4K = 7,
        Fix8K = 8,
        FixResolution = 9,
        FixResolution16x9 = 10,
    };
}
namespace via {
    enum RenderType {
        Default = 0,
        Diffuse = 1,
        Specular = 2,
        LightHeatmap = 3,
        ShadowLightHeatmap = 4,
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
        TextureMipMap = 128,
        SceneMipMap = 129,
        Lod = 130,
        StreamingTexture = 131,
        Occluder = 132,
        AlphaTest = 133,
        Wireframe = 256,
        FilledWireframe = 257,
        TelemetryHeatmap = 258,
        TransparentOverdraw = 512,
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
namespace via {
    enum TimeFormat {
        H12 = 0,
        H24 = 1,
        Max = 2,
        Unknown = 2,
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
namespace via {
    enum UserState {
        Invalid = 65535,
        Login = 0,
        Logout = 1,
        Max = 2,
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
namespace via {
    enum SystemServiceSkuFlag {
        Unknown = 65535,
        Default = 0,
        Trial = 1,
        Full = 3,
    };
}
namespace via {
    enum SystemServiceNativeUiOverlaidStatus {
        Unknown = 0,
        NoOverlaid = 1,
        Overlaid = 2,
    };
}
namespace via {
    enum SystemServiceSummerTimeStatus {
        Unknown = 0,
        StandardTime = 1,
        SummerTime = 2,
    };
}
namespace via {
    enum SystemServiceAccountPickerResult {
        Success = 0,
        Cancel = 1,
        Failed = 2,
    };
}
namespace via {
    enum SystemServiceVideoRecorderStatus {
        Unknown = 0,
        Idle = 1,
        Recording = 2,
    };
}
namespace via {
    enum ShareServiceCaps {
        None = 0,
        ScreenShot = 1,
        ScreenShotControl = 2,
        ScreenShotRequest = 4,
        ScreenShotOverlayImage = 16,
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
namespace via {
    enum VideoRecordingStopOption {
        SaveFile = 0,
        SaveFileAndExportLibrary = 1,
        Discard = 2,
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
namespace via {
    enum SharePlayLevel {
        Full = 0,
        ScreenOnly = 1,
        None = 2,
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
namespace via {
    enum AccountPickerTarget {
        Auto = 0,
        UnmanagedDevice = 1,
        LastInputDevice = 2,
    };
}
namespace via {
    enum AccountPickerState {
        NotSupported = 0,
        Idle = 1,
        Running = 2,
    };
}
namespace via {
    enum AccountPickerShowRequestResult {
        Success = 0,
        ErrorNotSupported = 1,
        ErrorAlreadyShown = 2,
        ErrorNoDevices = 3,
        ErrorInvalidParam = 4,
    };
}
namespace via {
    enum AccountPickerResult {
        Disabled = 0,
        UserChanged = 1,
        UserUnchanged = 2,
        DeviceDisconnected = 3,
        Failed = 4,
    };
}
namespace via::movie {
    enum PlaybackPerformance {
        Slowest = 0,
        Normal = 1,
        Fastest = 2,
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
namespace via::storage {
    enum BackgroundInstallSpeed {
        Slow = 0,
        Suspend = 1,
        Fast = 2,
    };
}
namespace via::storage {
    enum ChunkInstalledDevice {
        None = 0,
        Slow = 1,
        Fast = 2,
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
        SaveRun = 12,
        LoadRun = 13,
        RemoveRun = 14,
        ErrorDialog = 15,
        Max = 16,
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
        Failed_NullSaveDataError = 17,
        Failed_FileOpenError = 18,
        Failed_FileWriteError = 19,
        Failed_FileReadError = 20,
        Failed_FileRemoveError = 21,
        Failed_FileCloseError = 22,
        Failed_TempUpError = 23,
        Failed_SlotLimitOver = 24,
        Failed_SaveDataSizeMaxOver = 25,
        Failed_SaveDataSizeMinOver = 26,
        Failed_SegmentTempOpenDialog = 27,
        Failed_TransferringWriteAccess = 28,
        Failed_NoWin64 = 29,
        Failed_Steam_StartNumber = 50,
        Failed_Steam_SaveError = 51,
        Failed_Steam_LoadError = 52,
        Failed_Steam_RemoveError = 53,
        Failed_Steam_NotFireCallback = 54,
        Failed_NoSteam = 55,
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
        Failed_NoXB1 = 163,
        Failed_Other_StartNumber = 200,
        Failed_Simulation_Error = 201,
        Failed_SaveDataVersion_Old = 202,
        Failed_ToDo = 203,
        Failed_SaveServiceNull = 204,
    };
}
namespace via::storage::saveService {
    enum SaveSlot {
        Auto = 0,
        SystemMaxOffset = -128,
        System = -1,
        Slot = 1,
        SlotMax = 256,
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
        OldFormat_0 = 11,
        Max = 12,
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
        TransferringMax = 100,
    };
}
namespace via::storage::saveService {
    enum SaveDataVersion {
        SaveDataVersion_None = 0,
        SaveDataVersion_1_ClassInheritance = 1,
        SaveDataVersion_2_IsNotFindSystemType = 2,
        SaveDataVersion_Max = 3,
    };
}
namespace via::storage::saveService {
    enum SaveDataEncryptionType {
        None = 0,
        AutoStrong = 1,
        XOR = 2,
        BlowFish = 3,
    };
}
namespace via::storage::saveService {
    enum SaveDataEncryptionPlatform {
        None = 0,
        AutoUse = 1,
        All = 2,
    };
}
namespace via::storage::saveService {
    enum SaveDataOption {
        None = 0,
        Encryption = 1,
        CheckOwner = 2,
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
namespace via::storage::saveService {
    enum SaveDataMountMode {
        Read = 0,
        Write = 1,
        CreateWrite = 2,
    };
}
namespace via::storage::saveService {
    enum SaveDataArrayType {
        Value = 0,
        Class = 1,
    };
}
namespace via::browser {
    enum ServiceType {
        None = 0,
        Steam = 1,
        Psn = 2,
        Live = 3,
        Max = 4,
    };
}
namespace via::browser {
    enum RequestId {
        ContextStart = 257,
        BrowserOpen = 513,
        BrowserClose = 514,
    };
}
namespace via::network {
    enum ServiceType {
        None = 0,
        Lamm = 1,
        Steam = 2,
        Psn = 3,
        Live = 4,
        Live_UWP = 5,
        Max = 6,
    };
}
namespace via::network {
    enum Country {
        None = 0,
        Japan = 1,
        Other = 2,
        MaxNum = 3,
    };
}
namespace via::network {
    enum RequestId {
        ContextStart = 257,
        P2pConnect = 513,
        SessionCreate = 769,
        SessionSearch = 770,
        SessionJoin = 771,
        SessionLock = 772,
        SessionKick = 773,
        SessionInvite = 774,
        SessionChat = 777,
        RankingRegister = 1026,
        RankingGetScoreListByRange = 1027,
        RankingGetScoreListByUniqueId = 1028,
        RankingGetAttach = 1029,
        AchievementWrite = 1281,
        AchievementRead = 1282,
        StorageGetInfo = 1537,
        StorageUnlink = 1538,
        StorageOpen = 1539,
        StorageWrite = 1540,
        StorageRead = 1541,
        InvitationJoin = 2049,
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
namespace via::network::wrangler {
    enum EventEnabledState {
        Undefined = 0,
        Off = 1,
        ProviderDefault = 2,
        On = 3,
    };
}
namespace via::network::wrangler {
    enum PopulationSample {
        UseProviderPopulationSample = -2,
        UseSystemPopulationSample = -1,
        Undefined = 0,
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
namespace via::network::wrangler {
    enum EventPriority {
        Undefined = 0,
        Normal = 1,
        Critical = 2,
        ProviderDefault = 3,
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
namespace via::network::wrangler {
    enum ProviderLatency {
        Undefined = 0,
        Normal = 1,
        RealTime = 2,
    };
}
namespace via::network::wrangler {
    enum ProviderPriority {
        Undefined = 0,
        Normal = 1,
        Critical = 2,
    };
}
namespace via::network::wrangler {
    enum XsapiPropertySet {
        Dimensions = 0,
        Measurement = 1,
    };
}
namespace via::network::storage {
    enum Target {
        None = 0,
        Local = 1,
        Native = 2,
    };
}
namespace via::network::storage {
    enum Type {
        None = 0,
        Title = 1,
        User = 2,
    };
}
namespace via::dynamics {
    enum RigidBodyState {
        Disable = 0,
        Static = 1,
        KeyFramed = 2,
        Dynamic = 3,
        Max = 4,
    };
}
namespace via::dynamics {
    enum ShapeType {
        Invalid = 0,
        Sphere = 1,
        Capsule = 2,
        Box = 3,
        Mesh = 4,
        Triangle = 5,
        ConvexHull = 6,
        Max = 7,
    };
}
namespace via::dynamics {
    enum ConstraintType {
        Invalid = 0,
        BallJoint = 1,
        ConeTwist = 2,
        Hinge = 3,
        Max = 4,
    };
}
namespace via::behaviortree {
    enum SystemExecGroup {
        BTs = 0,
        SystemExecGroupNum = 1,
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
namespace via::behaviortree {
    enum RestartType {
        ExecuteOn = 0,
        ExecuteOff = 1,
        UseResource = 2,
        Ignore = 3,
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
namespace via::navigation {
    enum PrimitiveHandleType {
        None = 0,
        IndexedTriangle = 1,
        AABB2 = 2,
        LinkPrimArrow = 3,
    };
}
namespace via::navigation {
    enum UpdateTiming {
        Default = 0,
        Prev = 1,
        Late = 2,
    };
}
namespace via::navigation {
    enum DebugDrawAttribute {
        None = 0,
        Fill = 1,
    };
}
namespace via::navigation {
    enum GraphDrawMode {
        Normal = 0,
        Light = 1,
    };
}
namespace via::navigation {
    enum CostValueType {
        Unit = 0,
        Direct = 1,
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
namespace via::navigation {
    enum WarningStatus {
        Enable = 0,
        EnableContinuous = 1,
        Disable = 2,
    };
}
namespace via::navigation {
    enum PathObjectOperatorType {
        PathObjectOperator_NavigationTargetStraight = 0,
        PathObjectOperator_NavMeshStraight = 1,
        PathObjectOperator_NavigationVolumeSpaceTargetStraight = 2,
        PathObjectOperator_NavigationVolumeSpace = 3,
        PathObjectOperatorNum = 4,
    };
}
namespace via::navigation {
    enum FilterTarget {
        Default = 0,
        Groups = 1,
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
namespace via::navigation::map {
    enum SegmentLayer {
        Lower = 0,
        Upper = 1,
        SegmentLayerNum = 2,
    };
}
namespace via::motion {
    enum PlayState {
        Play = 0,
        Pause = 1,
        Stop = 2,
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
namespace via::motion {
    enum RootPlayMode {
        None = 0,
        Fixed = 1,
        Continuance = 2,
        Joint = 3,
    };
}
namespace via::motion {
    enum InterpolationMode {
        None = 0,
        FrontFade = 1,
        CrossFade = 2,
        SyncCrossFade = 3,
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
namespace via::motion {
    enum TransitionState {
        None = 0,
        Begin = 1,
        Setuped = 2,
        Update = 3,
        End = 4,
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
namespace via::motion {
    enum TimingType {
        Now = 0,
        End = 1,
        SyncPoint = 2,
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
namespace via::motion {
    enum BlendMode {
        Overwrite = 0,
        AddBlend = 1,
        Private = 2,
    };
}
namespace via::motion {
    enum BlendType {
        Normal = 0,
        Layer = 1,
        Interpolation = 2,
        Switch = 3,
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
namespace via::motion {
    enum ConstraintsUpdate {
        PrevLateUpdate = 0,
        AfterLateUpdate = 1,
        Last = 2,
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
namespace via::motion {
    enum SequenceGetMode {
        TypeA = 0,
        TypeB = 1,
    };
}
namespace via::motion {
    enum SequenceUpdateMode {
        Always = 0,
        PlayOnly = 1,
        Disable = 2,
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
namespace via::motion {
    enum TreeLayerMode {
        None = 0,
        Motion = 1,
        Camera = 2,
    };
}
namespace via::motion {
    enum MotionType {
        None = 0,
        Motion = 1,
        Tree = 2,
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
namespace via::motion {
    enum MotionFrameControl {
        Normal = 0,
        SyncBaseLayerNormalizeTime = 1,
        PauseStartFrame = 2,
        PauseEndFrame = 3,
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
namespace via::motion {
    enum ChainType {
        Chain = 0,
        Shooter = 1,
    };
}
namespace via::motion {
    enum ChainVGroundType {
        None = 0,
        Root = 1,
        Target = 2,
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
namespace via::motion::tree {
    enum LinkType {
        Unknown = 0,
        Motion = 1,
        Param = 2,
    };
}
namespace via::motion::tree {
    enum NodeType {
        Unknown = 0,
        Motion = 1,
        Param = 2,
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
namespace via::physics {
    enum MaskType {
        AND = 0,
        NAND = 1,
        Default = 2,
        Max = 3,
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
namespace via::physics {
    enum ShapeType {
        Aabb = 0,
        Sphere = 1,
        ContinuousSphere = 2,
        Capsule = 3,
        ContinuousCapsule = 4,
        Box = 5,
        Mesh = 6,
        StaticCompound = 7,
        Area = 8,
        Triangle = 9,
        Invalid = 10,
        Max = 11,
    };
}
namespace via::physics {
    enum CastRayOption {
        AllHits = 0,
        DisableBackFacingTriangleHits = 1,
        DisableFrontFacingTriangleHits = 2,
        NearSort = 3,
        OneHitBreak = 4,
        Max = 5,
    };
}
namespace via::physics {
    enum ShapeCastOption {
        AllHits = 0,
        DisableBackFacingTriangleHits = 1,
        DisableFrontFacingTriangleHits = 2,
        NearSort = 3,
        OneHitBreak = 4,
        Max = 5,
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
namespace via::physics {
    enum FillMode {
        Solid = 0,
        WireFrame = 1,
    };
}
namespace via::physics {
    enum ForceFillMode {
        None = 0,
        Solid = 1,
        WireFrame = 2,
    };
}
namespace via::physics {
    enum GateEventType {
        None = 0,
        Enter = 1,
        Leave = 2,
    };
}
namespace via::physics {
    enum GateType {
        Both = 0,
        EnterA = 1,
        EnterB = 2,
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
namespace via::gui {
    enum BlendType {
        Alpha = 0,
        Add = 1,
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
namespace via::gui {
    enum CircleColorType {
        Fill = 0,
        InOut = 1,
    };
}
namespace via::gui {
    enum TextureAssetType {
        UVSequence = 0,
        Texture = 1,
    };
}
namespace via::gui {
    enum SamplerType {
        PointWrap = 0,
        PointClamp = 1,
        BilinearWrap = 4,
        BilinearClamp = 5,
    };
}
namespace via::gui {
    enum MessageType {
        Dynamic = 0,
        Static = 1,
    };
}
namespace via::gui {
    enum SoftParticleDistType {
        System = 0,
        Component = 1,
        Disable = 2,
    };
}
namespace via::gui {
    enum FilterType {
        None = 0,
        Blur = 1,
        Glass = 2,
    };
}
namespace via::gui {
    enum MaskType {
        Target = 0,
        NonTarget = 1,
        Mask = 2,
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
namespace via::gui {
    enum ViewType {
        Screen = 0,
        World = 1,
    };
}
namespace via::gui {
    enum BillboardType {
        None = 0,
        XYZ_Axis = 1,
        Y_Axis = 2,
    };
}
namespace via::gui {
    enum ReprojectionType {
        Default = 0,
        WithOverlay = 1,
    };
}
namespace via::gui {
    enum PageAlignmentV {
        Top = 0,
        Center = 1,
        Bottom = 2,
    };
}
namespace via::gui {
    enum PageAlignmentH {
        Left = 0,
        Center = 1,
        Right = 2,
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
namespace via::gui {
    enum LetterAlignmentV {
        Top = 0,
        Center = 1,
        Bottom = 2,
        Baseline = 3,
    };
}
namespace via::gui {
    enum LetterAlignmentH {
        Left = 0,
        Center = 1,
        Right = 2,
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
namespace via::gui {
    enum ControlPointV {
        Top = 0,
        Center = 1,
        Bottom = 2,
    };
}
namespace via::gui {
    enum ControlPointH {
        Left = 0,
        Center = 1,
        Right = 2,
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
namespace via::gui {
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
namespace via::gui {
    enum ResolutionAdjustCondition {
        Always = 0,
        Expanding = 1,
        Shrinking = 2,
        Max = 3,
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
namespace via::gui {
    enum RectVertex {
        LeftTop = 0,
        LeftBottom = 1,
        RightTop = 2,
        RightBottom = 3,
        Max = 4,
    };
}
namespace via::gui {
    enum HitAreaShape {
        Triangle = 0,
        Rect = 1,
        Hexagon = 2,
        Octagon = 3,
    };
}
namespace via::gui {
    enum CursorType {
        Fix = 0,
        Move = 1,
        NoCursor = 2,
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
namespace via::gui {
    enum ListInputDirection {
        Prev = 0,
        Next = 1,
    };
}
namespace via::gui {
    enum ListScrollDirection {
        None = 0,
        Prev = 1,
        Next = 2,
    };
}
namespace via::gui {
    enum MouseSelectType {
        None = 0,
        MouseOver = 1,
        LeftClick = 2,
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
namespace via::gui {
    enum GridLoopType {
        Clamp = 0,
        Loop = 1,
        Next = 2,
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
namespace via::gui {
    enum GridScrollDirection {
        None = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        Left = 4,
    };
}
namespace via::gui {
    enum BarDirection {
        Horizontal = 0,
        Vertical = 1,
        Max = 2,
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
        Max = 10,
    };
}
namespace via::gui {
    enum SubFontNo {
        No0 = 0,
        No1 = 1,
        Max = 2,
    };
}
namespace via::gui {
    enum FontType {
        Unknown = 0,
        Outline = 1,
        Texture = 2,
    };
}
namespace via::gui {
    enum FontColorType {
        Fill = 0,
        Vertical = 1,
    };
}
namespace via::gui {
    enum IconColorType {
        None = 0,
        AlphaOnly = 1,
        RGBA = 2,
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
namespace via::gui {
    enum EventType {
        Unknown = 0,
        EndFrame = 1,
    };
}
namespace via::gui {
    enum ActionType {
        Unknown = 0,
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
namespace via::gui {
    enum MaterialParamType {
        Unknown = 0,
        Float = 1,
        Float4 = 2,
        Color = 3,
        Texture = 4,
    };
}
namespace via::gui {
    enum ColorTransformType {
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
namespace via::gui {
    enum TypingCondition {
        Update = 0,
        Pause = 1,
        End = 2,
    };
}
namespace via::gui {
    enum BindingError {
        None = 0,
        InvalidMaterial = 1,
        InvalidClusterName = 2,
        InvalidParamName = 4,
        InvalidType = 8,
    };
}
namespace via::gui {
    enum UserParamType {
        Int = 0,
        Float = 1,
        String = 2,
    };
}
namespace via::gui {
    enum RenderLayerType {
        Overlay = 0,
        Transparent = 1,
    };
}
namespace via::gui {
    enum ProjectionType {
        PerspectiveFovRH = 0,
        OrthographicRH = 1,
        Max = 2,
    };
}
namespace via::gui {
    enum SceneInfoAttribute {
        GUICameraOnly = 0,
        PrimaryOnly = 1,
        Both = 2,
        Max = 3,
    };
}
namespace via::fsm {
    enum SystemExecGroup {
        Fsm = 0,
        MotionFsm = 1,
        SystemExecGroupNum = 2,
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
namespace via::fsm {
    enum SelectTiming {
        Invalid = 0,
        BeforeAction = 1,
        AfterAction = 2,
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
namespace via::fsm {
    enum StateQueryType {
        All = 0,
        Start = 1,
    };
}
namespace via::fsm {
    enum ExpressionReferenceType {
        LocalUserData = 0,
        GlobalUserData = 1,
        Direct = 2,
    };
}
namespace via::fsm {
    enum TransitionAttribute {
        Warp = 0,
        IgnorePuppetMode = 1,
        TransitionAttributeBitNum = 32,
    };
}
namespace via::fsm {
    enum FsmSelectorType {
        Graph = 0,
    };
}
namespace via::wwise {
    enum PriorityMode {
        Newest = 0,
        Oldest = 1,
    };
}
namespace via::wwise {
    enum FadeType {
        None = 0,
        In = 1,
        Out = 2,
    };
}
namespace via::wwise {
    enum TargetType {
        OnlyThisGameObject = 0,
        IncludesOtherRelatingSounds = 1,
    };
}
namespace via::wwise {
    enum EvaluatesEstimatedDurationType {
        None = 0,
        Minimum = 1,
        Maximum = 2,
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
        AddSecondaryOutput = 18,
        RemoveSecondaryOutput = 19,
        SetSpeakerAngles = 20,
        Max = 21,
    };
}
namespace via::wwise {
    enum EventTargetType {
        GameObject = 0,
        EntireComponent = 1,
    };
}
namespace via::wwise {
    enum StopAllTargetType {
        StopAllType_GameObject = 0,
        StopAllType_EntireComponent = 1,
        StopAllType_Global = 2,
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
namespace via::wwise {
    enum User {
        User_0 = 0,
        User_1 = 1,
        User_2 = 2,
        User_3 = 3,
        User_None = 4,
    };
}
namespace via::wwise {
    enum SinkTypeWindows {
        Main = 0,
        MergeToMain = 1,
        None = 2,
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
        None = 6,
    };
}
namespace via::wwise {
    enum SinkTypeXboxOne {
        Main = 0,
        MergeToMain = 1,
        BGM = 2,
        Communication = 3,
        None = 4,
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
namespace via::hid {
    enum DeviceKind {
        Unknown = 0,
        GamePad = 1,
        Keyboard = 2,
        Mouse = 3,
        Camera = 4,
        HMD = 5,
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
        XboxOne = 8,
        WindowsXInput = 9,
        WindowsGamingInput = 10,
        WindowsJoypad = 11,
        Keyboard = 12,
        Mouse = 13,
        PlayStationCamera = 14,
        Kinect = 15,
        Morpheus = 16,
    };
}
namespace via::hid {
    enum DeviceType {
        Unknown = 0,
        Null = 1,
        GeneralGamePad = 2,
        SpecialGamePad = 3,
        Dualshock4 = 4,
        XboxOneWirelessController = 5,
        Keyboard = 6,
        Mouse = 7,
        PlayStationCamera = 8,
        Kinect = 9,
        Morpheus = 10,
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
        All = 65535,
        Invalid = 65536,
        Max = 65537,
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
        None = 0,
        All = -1,
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
namespace via::hid {
    enum AccountPickerState {
        Null = 0,
        Idle = 1,
        Executing = 2,
        PostProc = 3,
    };
}
namespace via::hid {
    enum AccountPickerResults {
        Null = 0,
        Completed = 1,
        Failed = 2,
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
    };
}
namespace via::hid {
    enum VrTrackerDeviceType {
        HMD = 0,
        Dualshock4 = 1,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraChannel {
        Left = 0,
        Right = 1,
        Max = 2,
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
namespace via::hid::camera {
    enum PlayStationCameraCaptureMemoryType {
        Onion = 1,
        Garlic = 2,
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
namespace via::hid::camera {
    enum PlayStationCameraCaptureWaitFrameType {
        OffMode0 = 1,
        OffMode1 = 2,
        OnMode0 = 3,
        OnMode1 = 4,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraAttr {
        Ignore = -1,
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
namespace via::hid::camera {
    enum PlayStationCameraStartResult {
        OK = 1,
        Started = 1,
        ErrorConfigType = -2147483647,
        ErrorInternal = -2147479552,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraStopResult {
        OK = 1,
        Stoped = 1,
        ErrInternal = -2147479552,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraSetConfigResult {
        OK = 1,
        ErrorStarted = -2147483647,
        ErrorInvalidType = -2147483646,
        ErrorInternal = -2147479552,
    };
}
namespace via::hid::camera {
    enum PlayStationCameraCaptureFrameResult {
        OK = 1,
        ErrorStoped = -2147483647,
        ErrorDeviceDisconnected = -2147483646,
        ErrorInternal = -2147479552,
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
        RequireCBRIDBuffer = 512,
        LateCBRResolve = 1024,
        UseIDBuffer = 768,
        UseCheckerBoard = 2048,
        FastCBRSetting = 1152,
        DefaultCBRSetting = 128,
        HighQualityCBRSetting = 640,
        PS4ProtCBRSetting = 1408,
        VendorAMD = 16777216,
        VendorNVIDIA = 33554432,
        VendorINTEL = 67108864,
        VendorUnkown = 134217728,
        Gen2 = 268435456,
        Gen3 = 536870912,
        Gen4 = 1073741824,
    };
}
namespace via::render {
    enum RenderOutputID {
        Primary = 1,
        Secondary = 2,
        Tertiary = 4,
        Quateary = 8,
        All = 15,
    };
}
namespace via::render {
    enum DistortionType {
        None = 0,
        Left = 1,
        Right = 2,
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
namespace via::render {
    enum IndexBufferFormat {
        U16 = 0,
        U32 = 1,
    };
}
namespace via::render {
    enum ClearFlag {
        Depth = 1,
        Stencil = 2,
    };
}
namespace via::render {
    enum ClearType {
        RTV = 0,
        UAVUint = 1,
        UAVFloat = 2,
        DSV = 3,
    };
}
namespace via::render {
    enum CopyType {
        copyResource = 0,
        copySubresourceRegion = 1,
    };
}
namespace via::render {
    enum MapType {
        WriteDiscard = 0,
        Read = 1,
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
        Int4 = 16,
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
namespace via::render {
    enum RegisterComponent {
        Unknown = 0,
        Uint32 = 1,
        Sint32 = 2,
        Float32 = 3,
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
namespace via::render {
    enum UsageType {
        Default = 0,
        Immutable = 1,
        Dynamic = 2,
        Staging = 3,
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
namespace via::render {
    enum OptionFlag {
        None = 0,
        TextureCube = 4,
        DrawIndirectArgs = 16,
        BufferAllowRawViews = 32,
        BufferStructured = 64,
        DX11Mask = 255,
        HTile = 256,
        NoShadowCopy = 512,
        HTileResolveForShadow = 1024,
        CPUReadableResource = 2048,
        LinearLayout = 4096,
        NoZeroFill = 8192,
        DeltaColorCompression = 16384,
        NoCompression = 32768,
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
        ForceUint = -1,
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
    enum TextureAddressMode {
        TextureAddress_Wrap = 1,
        TextureAddress_Mirror = 2,
        TextureAddress_Clamp = 3,
        TextureAddress_Border = 4,
        TextureAddress_MirrorOnce = 5,
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
namespace via::render {
    enum BufferexSrvFlag {
        Raw = 1,
    };
}
namespace via::render {
    enum BufferUavFlag {
        Raw = 1,
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
namespace via::render {
    enum DepthWriteMask {
        Zero = 0,
        All = 1,
        Num = 2,
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
namespace via::render {
    enum FillMode {
        Wireframe = 1,
        Solid = 2,
        Num = 3,
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
namespace via::render {
    enum TargetFlag {
        None = 0,
        NeedIDBuffer = 1,
        Num = 2,
    };
}
namespace via::render {
    enum TextureStreamingType {
        None = 0,
        Streaming = 1,
        HighMap = 2,
    };
}
namespace via::render {
    enum FenceState {
        Invalidate = -1,
        DoNotWait = -2,
    };
}
namespace via::render {
    enum AsyncExecuteFlag {
        Disable = 0,
        CommandPriorityWait = 1,
        NoWait = 2,
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
namespace via::render {
    enum DebugSeverity {
        None = 0,
        Level0 = 1,
        Level1 = 2,
        Level2 = 3,
    };
}
namespace via::render {
    enum DefaultResolution {
        DefaultResolution_720p = 720,
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
namespace via::render {
    enum ColorSpace {
        AUTO = 0,
        SRGB = 1,
        HDTV = 2,
        HDR10 = 3,
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
namespace via::render {
    enum PCTargetAPI {
        DirectX11 = 0,
        DirectX12 = 1,
    };
}
namespace via::render {
    enum HMDResolutionType {
        None = 0,
        FillAfterLighting = 1,
        FillAfterTransparent = 2,
    };
}
namespace via::render {
    enum LodResourceType {
        Global = 0,
        Local = 1,
        Unknown = 2,
    };
}
namespace via::render {
    enum WindowMode {
        Normal = 0,
        FullScreen = 1,
        Borderless = 2,
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
namespace via::render {
    enum MeshIndexFormat {
        MeshIndexFormat_16 = 0,
        MeshIndexFormat_32 = 1,
    };
}
namespace via::render {
    enum SkinWeightCount {
        SkinWeightCount_4 = 0,
        SkinWeightCount_8 = 1,
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
        Water = 7,
        GUI = 8,
        GUIMesh = 9,
        ExpensiveTransparent = 10,
    };
}
namespace via::render {
    enum InputType {
        Static = 0,
        Dynamic = 1,
        PreTransform = 2,
        StaticTex2 = 3,
        DynamicTex2 = 4,
        Max = 5,
    };
}
namespace via::render {
    enum ShaderType {
        GBuffer = 0,
        GBufferInstancing = 1,
        Shadow = 2,
        ShadowInstancing = 3,
        Pick = 4,
        PickInstancing = 5,
        Forward = 6,
        ForwardInstancing = 7,
        DepthWrite = 8,
        DepthWriteInstancing = 9,
        Water = 10,
        WaterZ = 11,
        WaterPartial = 12,
        WaterZPartial = 13,
        WaterPartialCheap = 14,
        WaterZPartialCheap = 15,
        PreTransform = 16,
    };
}
namespace via::render {
    enum MeshDrawType {
        Solid = 0,
        AlphaTest = 1,
        Decal = 2,
        Transparent = 3,
        Max = 4,
        Begin = 0,
    };
}
namespace via::render {
    enum DummyPipelineType {
        Static = 0,
        Skinning = 1,
        SkinningTex2 = 2,
    };
}
namespace via::render {
    enum ShadowCastMode {
        A = 1,
        B = 2,
    };
}
namespace via::render {
    enum DecalReciveMode {
        Automatic = 0,
        Enable = 1,
        Disable = 2,
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
namespace via::render {
    enum LodMode {
        Automatic = 0,
        Manual = 1,
        FollowParent = 2,
    };
}
namespace via::render {
    enum MaterialType {
        Dummy = 0,
    };
}
namespace via::render {
    enum MaterialParameterType {
        Bool = 0,
        Int = 1,
        Float = 2,
        Float2 = 3,
        Float3 = 4,
        Float4 = 5,
        Texture = 6,
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
namespace via::render {
    enum ShallowWaterRenderingPriority {
        PreDecal = 0,
        PostDecal = 1,
    };
}
namespace via::render {
    enum ShadowCastFlag {
        A = 1,
        B = 2,
        ALL = 3,
    };
}
namespace via::render {
    enum LightPowerUnitType {
        Lumen = 0,
        Candela = 1,
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
namespace via::render {
    enum ShadowResolution {
        Lowest = 128,
        Low = 256,
        Normal = 512,
        High = 1024,
        Highest = 2048,
        Ultra = 4096,
    };
}
namespace via::render {
    enum ShadowFilter {
        Custom = 0,
        Fast = 1,
        Default = 2,
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
namespace via::render::layer {
    enum GBufferLayout {
        PreLighting = 0,
        BaseColorMetallicTranslucency = 1,
        NormalXNormalYRoughnessMisc = 2,
        OcclusionSSSSSVelocityXVelocityYMisc = 3,
        Max = 4,
    };
}
namespace via::render::layer {
    enum SolidSegment {
        ZIgnoreBegin = 0,
        ZIgnorePrepassSolid = 1,
        ZIgnorePrepassTwoSide = 2,
        ZIgnorePrepassTwoSideAlphaTest = 3,
        ZIgnorePrepassAlphaTest = 4,
        ZIgnoreEnd = 5,
    };
}
namespace via::render::layer {
    enum GBufferSegment {
        ZIgnorePrepassSolid = 0,
        ZIgnorePrepassTwoSide = 1,
        ZIgnorePrepassTwoSideAlphaTest = 2,
        ZIgnorePrepassAlphaTest = 3,
        ZPrepassSolid = 4,
        ZPrepassTwoSide = 5,
        ZPrepassTwoSideAlphaTest = 6,
        ZPrepassAlphaTest = 7,
        Solid = 8,
        TwoSide = 9,
        DefaultZPrepass = 10,
        TwoSideAlphaTest = 11,
        AlphaTest = 12,
        EmissiveMask = 16,
        EmissiveSolid = 24,
        EmissiveTwoSide = 25,
        EmissiveTwoSideAlphaTest = 27,
        EmissiveAlphaTest = 28,
        MeshDecal = 30,
        DepthWrite = 32,
        DepthWrittenSolid = 33,
        ViewScaling = 34,
        ViewScalingSolid = 35,
        DecalPrepare = 48,
        DisplacementPrepare = 50,
        Displacement = 51,
        PreDecalBlend = 52,
        PreDecalDepthOnly = 53,
        Decal = 54,
        PostDecalBlend = 55,
        PostDecalDepthOnly = 56,
        DepthWritePostDecal = 58,
        DepthWrittenSolidPostDecal = 59,
        ViewScalingPostDecal = 60,
        ViewScalingSolidPostDecal = 61,
    };
}
namespace via::render::layer {
    enum CommonSegment {
        UpdateConstant = 0,
        ComputeSkinning = 1,
        ComputeSkinningFence = 4,
        Wrinkle = 5,
        Stamp = 6,
        GraphicsBase = 16,
        GUI = 16,
        WrinkleGraphics = 17,
        BloodshedGraphics = 18,
        PostComputeBase = 32,
        BloodshedPostCompute = 32,
        ShallowWaterCompute = 33,
        TextureSpreadCompute = 34,
        PostGraphicsBase = 48,
        BloodshedPostGraphics = 48,
        TextureSpreadGraphics = 49,
        Lowest = 63,
    };
}
namespace via::render::layer {
    enum OverlayDepth {
        OverlayDepth_0 = 0,
        OverlayDepth_Max = 1,
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
namespace via::timeline {
    enum ExecuteGroup {
        ExecuteGroup_00 = 0,
        ExecuteGroup_01 = 1,
        ExecuteGroup_02 = 2,
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
    };
}
namespace via::timeline {
    enum TimelineState {
        Play = 0,
        Pause = 1,
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
namespace via::dialog {
    enum Status {
        None = 0,
        Initialized = 1,
        Running = 2,
        Finished = 3,
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
namespace via::dialog::core {
    enum dummy {
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
namespace via::clr {
    enum MethodFlag {
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
namespace via::clr {
    enum MethodImplFlag {
        CIL = 0,
        Native = 1,
        Optil = 2,
        Runtime = 3,
        Unmanaged = 4,
        ForwardRef = 16,
        PreserveSig = 128,
        InternalCall = 4096,
        Synchronized = 32,
        NoInlining = 8,
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
namespace via::clr {
    enum MethodExceptionFlag {
        MethoExceptionFlag_Exception = 0,
        MethoExceptionFlag_Filter = 1,
        MethoExceptionFlag_Finaly = 2,
        MethoExceptionFlag_Fault = 3,
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
namespace via::clr {
    enum FieldFlag {
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
        PInvokeImpl = 8192,
        RTSpecialName = 1024,
        Marshal = 4096,
        NoILAsmKeyword = 32768,
    };
}
namespace via::clr {
    enum TypeFlag {
        Private = 0,
        Public = 1,
        NestedPublic = 2,
        NestedPrivate = 3,
        NestedFamily = 4,
        NestedAssembly = 5,
        NestedFamandAssem = 6,
        NestedFamorAssem = 7,
        Sequential = 8,
        Explicit = 16,
        Interface = 32,
        Abstract = 128,
        Sealed = 256,
        SpecialName = 1024,
        Import = 4096,
        Serializable = 8192,
        BeforeFieldInit = 1048576,
        Unicode = 65536,
        AutoChar = 131072,
        RTSpecialName = 2048,
        NoKeyword = 262144,
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
namespace via::clr {
    enum ParamFlag {
        In = 1,
        Out = 2,
        Optional = 16,
        HasDefault = 4096,
        HasFieldMarshal = 8192,
        ByRef = 16384,
        Ptr = 32768,
    };
}
namespace via::clr {
    enum PropertyFlag {
        SpecialName = 512,
        RTSpecialName = 1024,
        HasDefault = 4096,
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
namespace via::clr {
    enum SignatureFlag {
        Generic = 16,
        HasThis = 32,
        ExplicitThis = 64,
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
namespace via::clr {
    enum EnumType {
        Dummy = 0,
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
namespace via::clr {
    enum EvalFlag {
        Int32 = 1,
        Int64 = 2,
        Float = 4,
        Ptr = 8,
        ObjRef = 16,
        Value = 32,
        NatInt = 259,
        Integer = 3,
        RefOrPtr = 56,
        Numeric = 7,
        All = 63,
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
        RuntimeTypeHandle = 32,
        RuntimeMethodHandle = 33,
        RuntimeFieldHandle = 34,
        Assembly = 35,
        InvalidCastException = 36,
        IndexOutOfRangeException = 37,
        NullReferenceException = 38,
        DivideByZeroException = 39,
        OverflowException = 40,
        ArgumentOutOfRangeException = 41,
        ArgumentNullException = 42,
        ArgumentException = 43,
        ArithmeticException = 44,
        OutOfMemoryException = 45,
        FormatException = 46,
        RankException = 47,
        ArrayTypeMismatchException = 48,
        NotImplementedException = 49,
        NotSupportedException = 50,
        ObjectDisposedException = 51,
        InvalidOperationException = 52,
        NotFiniteNumberException = 53,
        StackOverflowException = 54,
        ThreadAbortException = 55,
        ThreadStartException = 56,
        ThreadStateException = 57,
        InternalEnumerator = 58,
        IEnumerableT = 59,
        ICollectionT = 60,
        IListT = 61,
        Max = 62,
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
        ThreadStartInvoke = 7,
        DefaultExceptionHandler = 8,
        Generic_GetEnumerator = 9,
        Generic_Compare = 10,
        Max = 11,
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
namespace via::clr {
    enum VMTypeFlag {
        LocalHeap = 1,
        Finalize = 2,
        Enum = 4,
        Primitive = 8,
        Exception = 16,
        Attribute = 32,
        Interface = 64,
        Generic = 128,
        GenericDefinition = 256,
        ContainsGenericParameters = 512,
        Abstract = 1024,
        NativeType = 2048,
        ManagedType = 4096,
        MarkField = 8192,
        MarkStaticField = 16384,
        Constracted = 32768,
        Integer = 65536,
        MarkBitsTbl = 131072,
        SpecType = 262144,
        CycleType = 524288,
    };
}
namespace via::clr {
    enum VMMemberAccess {
        PrivateScope = 0,
        Private = 1,
        FamANDAssem = 2,
        Assembly = 3,
        Family = 4,
        FamORAssem = 5,
        Public = 6,
    };
}
namespace via::clr {
    enum VMMemberFlag {
        Static = 16,
        Generic = 2097152,
        GenericDefinition = 4194304,
        ContainsGenericParameters = 8388608,
        HasThis = 16777216,
        HasRetVal = 33554432,
        FastCall = 67108864,
        EmptyCtor = 134217728,
        Break = 268435456,
    };
}
namespace via::clr {
    enum TokenKind {
        Type = 0,
        Method = 1,
        Field = 2,
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
        Any = 65535,
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
namespace via::memory {
    enum AllocatorType {
        Boot = 0,
        Default = 1,
        Permanent = 2,
        Resource = 3,
        Develop = 4,
        Temp = 5,
        VRAM = 6,
        Max = 7,
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
namespace via::os {
    enum ThreadState {
        Ready = 0,
        Executing = 1,
        Running = 2,
        Suspended = 3,
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
namespace via::os {
    enum FileAttr {
        Read = 0,
        Write = 1,
        ReadWrite = 2,
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
namespace via::os {
    enum FileSeek {
        Begin = 0,
        Current = 1,
        End = 2,
    };
}
namespace via::os {
    enum MutexError {
        None = 0,
        Failed = 1,
    };
}
namespace via::os {
    enum SemaphoreError {
        None = 0,
        Failed = 1,
    };
}
namespace via::os {
    enum ConditionVariableError {
        None = 0,
        Failed = 1,
        TimedOut = 2,
    };
}
namespace via::os {
    enum ReadWriteLockError {
        None = 0,
        Failed = 1,
    };
}
namespace via::os {
    enum ClipboardFormat {
        TEXT_ANSI = 0,
        TEXT_UNICODE = 1,
        BINARY = 2,
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
namespace via::os {
    enum MemorySource {
        UserLand = 0,
        Develop = 1,
        KernelLand = 2,
        Default = 0,
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
namespace via::os {
    enum MemoryBus {
        WB = 256,
        WC = 512,
        Default = 256,
    };
}
namespace via::os {
    enum IpAddressType {
        Default = 0,
        V4 = 1,
        V6 = 2,
    };
}
namespace via::os {
    enum SocketType {
        None = 0,
        Tcp = 1,
        Udp = 2,
        Ssl = 3,
    };
}
namespace via::os {
    enum SocketOption {
        None = 0,
        TcpNoDelay = 1,
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
namespace via::os {
    enum BackgroundInstallSpeed {
        Slow = 0,
        Suspend = 1,
        Fast = 2,
    };
}
namespace via::os {
    enum ChunkInstalledDevice {
        None = 0,
        Slow = 1,
        Fast = 2,
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
namespace via::charset {
    enum UTF16Type {
        LE = 0,
        BE = 1,
        LE_BOM = 2,
        BE_BOM = 3,
        Native = 0,
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
namespace via::str {
    enum ComparisonType {
        Ordinal = 0,
        OrdinalIgnoreCase = 1,
    };
}
namespace via::str {
    enum SplitSeparatorType {
        String = 0,
        CharArray = 1,
    };
}
namespace via::str {
    enum SplitOptionType {
        None = 0,
        RemoveEmptyEntries = 1,
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
namespace via::path {
    enum PathKind {
        RelativeOrAbsolute = 0,
        Absolute = 1,
        Relative = 2,
    };
}
namespace via::path {
    enum DriveType {
        App = 0,
        SaveData = 1,
        AddContent = 2,
        Download = 3,
        Temp = 4,
        Home = 5,
        MaxType = 6,
    };
}
namespace via::detail_bitset {
    enum BIT_IMPL {
        BIT_IMPL_32 = 0,
        BIT_IMPL_64 = 1,
        BIT_IMPL_ARRAY = 2,
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
namespace via::graph {
    enum VertexIndex {
        Invalid = -1,
        From = 0,
        To = 1,
    };
}
namespace via::graph {
    enum VertexRemoveOption {
        None = 0,
        WithEdge = 1,
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
namespace via::Application {
    enum RuntimeTargetType {
        Target_Undefined = 0,
        TargetMachine_Mask = 15,
        TargetMachine_PC = 1,
        TargetMachine_PS4 = 2,
        TargetMachine_XB1 = 3,
        TargetMachineDetail_Mask = 240,
        TargetMachineDetail_PS4Base = 16,
        TargetMachineDetail_PS4NEO = 32,
        TargetMachineDetail_XB1 = 48,
        TargetMachineDetail_XB1X = 64,
        TargetOS_Mask = 3840,
        TargetOS_Windows = 256,
        TargetOS_PS4 = 512,
        TargetServicePlatform_Mask = 61440,
        TargetServicePlatform_Default = 4096,
        TargetServicePlatform_Steam = 8192,
        TargetServicePlatform_UWP = 12288,
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
namespace via::behavior::EffectEvent {
    enum LifeState {
        Unknown = 0,
        Wait = 1,
        Initialize = 2,
        Appear = 3,
        Keep = 4,
        KeepHold = 5,
        Vanish = 6,
        Terminate = 7,
    };
}
namespace via::telemetry::TelemetryManager {
    enum EventType {
        Ready = 0,
        Activated = 0,
        Deactivated = 1,
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
        Finalize = 12,
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
namespace via::browser::utility::Request {
    enum State {
        Dead = 0,
        Start = 1,
        StartFail = 2,
        Update = 3,
        Finish = 4,
    };
}
namespace via::puppet::RemoteGameObject {
    enum Priority {
        None = 0,
        SendRate = 1,
        SyncImmediate = 2,
        SyncImmediateSR0 = 3,
        SyncImmediateAll = 4,
    };
}
namespace via::network::context {
    enum Option {
        None = 0,
        WithTicket = 1,
        OnlyTicket = 2,
    };
}
namespace via::network::Protocol {
    enum MemberIndex {
        None = -1,
        All = -2,
        Other = -3,
        Self = -4,
        Host = -5,
    };
}
namespace via::network::Protocol {
    enum SendOption {
        None = 0,
        Unreliable = 0,
        Reliable = 1,
        ReliableBuffer = 3,
        FastCallback = 4,
        CheckAbsent = 8,
    };
}
namespace via::network::AutoMaster {
    enum Mode {
        Independent = 0,
        ForceMaster = 1,
        ForcePuppet = 2,
        AutoMaster = 3,
    };
}
namespace via::network::AutoMatchmaking {
    enum Mode {
        BecomeSessionHost = 0,
        JoinExistingSession = 1,
    };
}
namespace via::network::AutoMatchmaking {
    enum Phase {
        Idle = 0,
        Host_Init = 1,
        Host_SetRule = 2,
        Host_CreateSession = 3,
        Host_CreateWait = 4,
        Host_InGame = 5,
        Host_Timeout = 6,
        Guest_Init = 7,
        Guest_CreateSession = 8,
        Guest_CreateWait = 9,
        Guest_SetSearchRule = 10,
        Guest_SearchSession = 11,
        Guest_SearchWait = 12,
        Guest_ThinkRule = 13,
        Guest_GiveupSession = 14,
        Guest_GiveupWait = 15,
        Guest_JoinSession = 16,
        Guest_JoinWait = 17,
        Guest_InGame = 18,
        Guest_SearchInterval = 19,
        Guest_Timeout = 20,
    };
}
namespace via::network::AutoMatchmaking {
    enum RuleType {
        Must = 0,
        Should = 1,
    };
}
namespace via::network::service::Context {
    enum Option {
        None = 0,
        WithTicket = 1,
        OnlyTicket = 2,
    };
}
namespace via::network::service::Session {
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
namespace via::network::service::Session {
    enum FilterAttr {
        None = 0,
        Vacant = 1,
        SameCountry = 2,
    };
}
namespace via::network::service::Session {
    enum SearchOption {
        None = 0,
        GetBinary = 1,
        GetPerformance = 2,
    };
}
namespace via::network::service::Ranking {
    enum Target {
        None = 0,
        Local = 1,
        Native = 2,
    };
}
namespace via::network::service::Storage {
    enum Target {
        None = 0,
        Local = 1,
        Native = 2,
    };
}
namespace via::network::service::Storage {
    enum Type {
        None = 0,
        Title = 1,
        User = 2,
    };
}
namespace via::network::utility::SearchKey {
    enum SearchKeyAttr {
        None = 0,
        SameCountry = 1,
    };
}
namespace via::network::utility::Request {
    enum State {
        Dead = 0,
        Start = 1,
        StartFail = 2,
        Update = 3,
        Finish = 4,
    };
}
namespace via::havok::System {
    enum DevelopDrawMode {
        WireFrame = 0,
        Solid = 1,
    };
}
namespace via::havok::PhysicsModifier {
    enum Flag {
        None = 0,
        Need_Step = 1,
    };
}
namespace via::havok::BodyTypeModifier {
    enum BodyType {
        Type_Free = 0,
        Type_Static = 1,
        Type_Keyframed = 2,
        Type_Dynamic = 3,
        Type_Dynamic_Fixed = 4,
        Type_Dynamic_DisableJointWrite = 5,
    };
}
namespace via::havok::RagdollControllerModifier {
    enum Mode {
        None = 0,
        KeyFrameController = 1,
        MotorController = 2,
    };
}
namespace via::havok::ClothTransitionConstraintModifier {
    enum Mode {
        Force_Simulate = 0,
        Force_Animate = 1,
        Transition_To_Simulate = 2,
        Transition_To_Animate = 3,
    };
}
namespace via::havok::ModifierSelector {
    enum ModifierFlag {
        ModInitialized = 0,
        FlagMax = 1,
    };
}
namespace via::havok::ModifierSelector {
    enum Type {
        Enabled = 0,
        Layer = 1,
        Activation = 2,
        BodyType = 3,
        None = 4,
    };
}
namespace via::havok::PhysicsBase {
    enum DebugDrawText {
        BodyName = 0,
        Mass = 1,
        FrictionFactor = 2,
    };
}
namespace via::havok::Cloth {
    enum AnimationStatus {
        Animation = 0,
        Simulation = 1,
        AnimationToSimulation = 2,
        SimulationToAnimation = 3,
        AnimationToSimulationEvent = 4,
        SimulationToAnimationEvent = 5,
    };
}
namespace via::havok::Cloth {
    enum SkeletonBlendStatus {
        None = 0,
        Animation_Current = 1,
        Simulation_Current = 2,
        Bind_Current = 3,
    };
}
namespace via::havok::PhysicsShapeSampleComp {
    enum BodyType {
        TYPE_NONE = 0,
        TYPE_STATIC = 1,
        TYPE_KEYFRAMED = 2,
        TYPE_DYNAMIC = 3,
        TYPE_MIXED = 4,
        TYPE_MAX = 5,
    };
}
namespace via::havok::HavokBodyMotionPropertiesController {
    enum SolverStabilizationType {
        Off = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Aggressive = 4,
    };
}
namespace via::havok::HavokBodyMotionPropertiesController {
    enum DeactivationStrategy {
        Aggressive = 0,
        Balanced = 1,
        StrategyAccurate = 2,
    };
}
namespace via::havok::CastRayQuery {
    enum Options {
        NoFlags = 0,
        ClosestHit = 1,
        AllHits = 2,
        DisableBackFacingTriangleHits = 4,
        DisableFrontFacingTriangleHits = 8,
        EnableInsideHits = 16,
    };
}
namespace via::havok::CastRayQuery {
    enum Type {
        Unknown = 0,
        Ray = 1,
        EndPoint = 2,
    };
}
namespace via::havok::CastShapeQuery {
    enum ShapeType {
        Sphere = 0,
        Capsule = 1,
        LineSegment = 2,
    };
}
namespace via::havok::CastShapeQuery {
    enum Options {
        NoFlags = 0,
        ClosestHit = 1,
        AllHits = 2,
        DisableBackFacingTriangleHits = 4,
        DisableFrontFacingTriangleHits = 8,
        EnableInsideHits = 16,
    };
}
namespace via::havok::CastShapeQuery {
    enum Type {
        Unknown = 0,
        Ray = 1,
        EndPoint = 2,
    };
}
namespace via::behaviortree::SelectorCallerArg {
    enum EventType {
        None = 0,
        EveryFrame = 1,
        ChildEnd = 2,
    };
}
namespace via::behaviortree::SelectorSequence {
    enum RunType {
        Loop = 0,
        Once = 1,
        OnceEnd = 2,
    };
}
namespace via::behaviortree::SelectorCallerChildNodeEnd {
    enum CheckType {
        AnyNode = 0,
        AllNode = 1,
    };
}
namespace via::behaviortree::action::SetBool {
    enum Status {
        False = 0,
        True = 1,
    };
}
namespace via::behaviortree::action::NodeTimer {
    enum Unit {
        Second = 0,
        Frame = 1,
    };
}
namespace via::behaviortree::action::Trace {
    enum TraceType {
        Info = 0,
        Warning = 1,
        Error = 2,
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
namespace via::navigation::FilterInfo {
    enum TraceDestination {
        Optimize = 0,
        PortalCenter = 1,
        NodeCenterWithExtraLink = 2,
    };
}
namespace via::navigation::NodeFilterInfo {
    enum FilterType {
        UseOn = 0,
        UseOff = 1,
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
namespace via::navigation::FailReport {
    enum FailLevel {
        Upper = 0,
        Lower = 1,
    };
}
namespace via::navigation::Navigation {
    enum State {
        Stop = 0,
        Navigation = 1,
        Navigaiton = 1,
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
    };
}
namespace via::navigation::Navigation {
    enum NoMapAction {
        NoMove = 0,
        Straight = 1,
    };
}
namespace via::navigation::Navigation {
    enum TraceLineOptimizeTiming {
        NodeUpdate = 0,
        Frame = 1,
    };
}
namespace via::navigation::Navigation {
    enum NoNodeSearch {
        None = 0,
        NearestNode = 1,
    };
}
namespace via::navigation::Navigation {
    enum LegacySetting {
        Trace3D = 0,
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
namespace via::navigation::AIMapEffector {
    enum EffectType {
        Attribute = 0,
        Disable = 1,
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
namespace via::navigation::AIMapEffector {
    enum EdgePrecisionType {
        x1 = 0,
        x10 = 1,
        x100 = 2,
    };
}
namespace via::navigation::AIMapEffector {
    enum EdgeCreateType {
        Optimize = 0,
        Simple = 1,
        NonConvexCheck = 2,
    };
}
namespace via::navigation::AIMapEffector {
    enum NeedUpdate {
        No = 0,
        Yes = 1,
        Force = 2,
    };
}
namespace via::navigation::NavigationManager {
    enum NavigationUpdateTiming {
        Prev = 1,
        Late = 2,
    };
}
namespace via::navigation::map::PathInfo {
    enum DistanceType {
        Raw = 0,
        Path = 1,
    };
}
namespace via::motion::MotionManager {
    enum CallUpdate {
        ComponentCollection = 0,
        Frame = 1,
        FrameAsync = 2,
        Motion = 3,
        ConstraintBegin = 4,
        ConstraintEnd = 5,
        Expression = 6,
        DebugDraw = 7,
        ReloadCheck = 8,
    };
}
namespace via::motion::CppSampleChild {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
    };
}
namespace via::motion::CppSampleTracks {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
    };
}
namespace via::motion::CppSampleAppendChild {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
    };
}
namespace via::motion::CppSampleAppendData {
    enum Test {
        A = 0,
        B = 1,
        C = 2,
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
namespace via::motion::Motion {
    enum DrawTarget {
        Hidden = 0,
        Main = 1,
        All = 2,
    };
}
namespace via::motion::IkLeg {
    enum Lean {
        Center = 0,
        CenterAndHeal = 1,
    };
}
namespace via::motion::IkLeg {
    enum CenterAdjust {
        None = 0,
        ToRoot = 1,
        Center = 2,
    };
}
namespace via::motion::IkLeg {
    enum CenterDistance {
        OriginalLeg = 0,
        LeachLeg = 1,
    };
}
namespace via::motion::IkLeg {
    enum EffectorTarget {
        Heal = 0,
        Toe = 1,
    };
}
namespace via::motion::IkLeg {
    enum EffectorOffsetCtrl {
        None = 0,
        Local = 1,
        World = 2,
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
namespace via::motion::IkDog {
    enum Lean {
        Center = 0,
        CenterAndHeal = 1,
    };
}
namespace via::motion::IkDog {
    enum CenterAdjust {
        None = 0,
        ThreePoint = 1,
    };
}
namespace via::motion::IkDog {
    enum CenterDistance {
        OriginalLeg = 0,
        LeachLeg = 1,
    };
}
namespace via::motion::IkDog {
    enum EffectorTarget {
        Heal = 0,
        Toe = 1,
    };
}
namespace via::motion::IkDog {
    enum EffectorOffsetCtrl {
        None = 0,
        Local = 1,
        World = 2,
    };
}
namespace via::motion::IkDog {
    enum EffectorCtrl {
        None = 0,
        LocalOffset = 1,
        WorldOffset = 2,
        Local = 3,
        World = 4,
    };
}
namespace via::motion::IkDog {
    enum FreeFoot {
        None = 0,
        BackLeft = 1,
        BackRight = 2,
        ForeLefh = 4,
        ForeRight = 8,
        BackAll = 3,
        ForeAll = 12,
        LeftAll = 5,
        RightAll = 10,
        All = 15,
    };
}
namespace via::motion::IkFourLeg {
    enum Lean {
        Center = 0,
        CenterAndHeal = 1,
    };
}
namespace via::motion::IkFourLeg {
    enum CenterAdjust {
        None = 0,
        ThreePoint = 1,
    };
}
namespace via::motion::IkFourLeg {
    enum CenterDistance {
        OriginalLeg = 0,
        LeachLeg = 1,
    };
}
namespace via::motion::IkFourLeg {
    enum EffectorTarget {
        Heal = 0,
        Toe = 1,
    };
}
namespace via::motion::IkFourLeg {
    enum EffectorOffsetCtrl {
        None = 0,
        Local = 1,
        World = 2,
    };
}
namespace via::motion::IkFourLeg {
    enum EffectorCtrl {
        None = 0,
        LocalOffset = 1,
        WorldOffset = 2,
        Local = 3,
        World = 4,
    };
}
namespace via::motion::IkJacobian {
    enum InverseMethodType {
        LU = 0,
        Cholesky = 1,
        DebugCompare = 2,
    };
}
namespace via::motion::IkJacobian {
    enum MomentumModeType {
        Zero = 0,
        Animation = 1,
        TargetPos = 2,
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
namespace via::motion::ActionPlayMotion {
    enum FrameControl {
        Normal = 0,
        SyncBaseLayer = 1,
        PauseStartFrame = 2,
        PauseEndFrame = 3,
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
namespace via::physics::System {
    enum DirtyType {
        RequestSetColliders = 0,
        Max = 1,
    };
}
namespace via::physics::Shape {
    enum State {
        Enabled = 0,
        Max = 1,
    };
}
namespace via::physics::CharacterController {
    enum State {
        FirstUpdate = 0,
        OverwritePosition = 1,
        Jump = 2,
        UpdateFilterInfo = 3,
        Max = 4,
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
namespace via::gui::Material {
    enum ParamType {
        Unknown = 0,
        Float = 1,
        Float4 = 2,
        Color = 3,
        Texture = 4,
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
namespace via::gui::GUIUtility {
    enum AssociationAnlyzeContext {
        SearchEqual = 0,
        SearchDoubleQuot = 1,
    };
}
namespace via::fsm::FsmManager {
    enum SelectorTiming {
        Last = 0,
        BackGround = 1,
    };
}
namespace via::fsm::Action {
    enum SwitchSetting {
        Off = 0,
        On = 1,
    };
}
namespace via::fsm::action::SetBool {
    enum Status {
        False = 0,
        True = 1,
    };
}
namespace via::fsm::action::Trace {
    enum TraceType {
        Info = 0,
        Warning = 1,
        Error = 2,
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
namespace via::wwise::WwiseGlobalUserVariablesValue {
    enum TypeKind {
        Unknown = 0,
        Boolean = 1,
        Int32 = 2,
        Uint32 = 3,
        Single = 4,
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
namespace via::hid::mouse {
    enum ManipulatorClientDefaultType {
        DirectInput = 1,
        RawInput = 2,
        WindowMessage = 3,
        GlobalParameter = 4,
    };
}
namespace via::hid::mouse {
    enum ManipulatorClientDefaultTypeDev {
        WindowMessage = 3,
        GlobalParameter = 4,
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
namespace via::hid::mouse {
    enum ManipulatorClientTypeDev {
        Null = 0,
        WindowMessage = 3,
        GlobalParameter = 4,
        ToolDefault = 6,
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
namespace via::hid::VrTrackerResultData {
    enum ProjectionQuality {
        Raw = 0,
        None = 3,
        Partial = 6,
        Full = 9,
    };
}
namespace via::hid::VrTrackerResultData {
    enum Validation {
        Active = 0,
        Inactive = 1,
        Unknown = 2,
    };
}
namespace via::hid::VrTrackerResultData {
    enum RearStatus {
        NotReady = 0,
        Ready = 1,
        NotSupported = 2,
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
namespace via::hid::VrTracker {
    enum TrackerDevicePermitType {
        All = 0,
        HmdOnly = 1,
    };
}
namespace via::hid::VrTracker {
    enum ResultType {
        Predicted = 0,
        Raw = 1,
    };
}
namespace via::hid::VrTracker {
    enum PreferenceType {
        FarPosition = 0,
        StablePosition = 1,
    };
}
namespace via::hid::VrTracker {
    enum OrientationType {
        Absolute = 0,
        Relative = 1,
    };
}
namespace via::hid::VrTracker {
    enum CalibrationType {
        Position = 0,
        All = 1,
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
namespace via::hid::VrTracker {
    enum StopStatus {
        Success = 0,
        NotSupported = -1,
        NotStarted = -2,
        InvalidDeviceHandle = -3,
        UnregisterDeviceFailed = -4,
    };
}
namespace via::hid::AudioInManager {
    enum AUDIO_IN_TYPE {
        NORMAL = 0,
        VOICE_CHAT = 1,
        VOICE_RECOGNITION = 2,
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
namespace via::hid::hmd::MorpheusDevice {
    enum StartResult {
        OK = 0,
        ErrorNotSupported = 1,
        ErrorNotStandby = 2,
        ErrorStartupFailed = 3,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum StereoEye {
        Left = 0,
        Right = 1,
        Count = 2,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum FovType {
        DeviceDefault = 0,
        SystemOverride = 1,
    };
}
namespace via::hid::hmd::MorpheusDevice {
    enum ReprojectionType {
        Default = 0,
        WithOverlay = 1,
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
namespace via::hid::hmd::Morpheus {
    enum VrModeStatusCheckLevel {
        Nothing = 0,
        Warning = 1,
        Error = 2,
        Assertion = 3,
    };
}
namespace via::hid::hmd::Morpheus {
    enum VrModeStatusCheckTiming {
        VrTrackerStarted = 0,
        VrVideoModeEnabled = 1,
    };
}
namespace via::effect::graph {
    enum ErrorType {
        NoError = 0,
        InvalidType = 1,
        InsufficientMemory = 2,
        InvalidOperation = 3,
    };
}
namespace via::effect::graph {
    enum ItemType {
        Unknown = 0,
        Transform2D = 1,
        Transform2DClip = 2,
        Transform2DExpression = 3,
        Transform3D = 4,
        Transform3DClip = 5,
        Transform3DExpression = 6,
        ParentOptions = 7,
        FixRandomGenerator = 8,
        Spawn = 9,
        SpawnExpression = 10,
        TypeBillboard2D = 11,
        TypeBillboard2DExpression = 12,
        TypeBillboard3D = 13,
        TypeBillboard3DExpression = 14,
        TypeMesh = 15,
        TypeMeshClip = 16,
        TypeMeshExpression = 17,
        TypeRibbonFollow = 18,
        TypeRibbonLength = 19,
        TypeRibbonChain = 20,
        TypeRibbonFollowExpression = 21,
        TypeRibbonLengthExpression = 22,
        TypeRibbonChainExpression = 23,
        TypePolygon = 24,
        TypePolygonClip = 25,
        TypePolygonExpression = 26,
        TypeRibbonTrail = 27,
        TypePolygonTrail = 28,
        TypeNoDraw = 29,
        Velocity2D = 30,
        Velocity2DExpression = 31,
        Velocity3D = 32,
        Velocity3DExpression = 33,
        RotateAnim = 34,
        RotateAnimExpression = 35,
        ScaleAnim = 36,
        ScaleAnimExpression = 37,
        Life = 38,
        LifeExpression = 39,
        UVSequence = 40,
        UVSequenceExpression = 41,
        EmitterShape2D = 42,
        EmitterShape2DExpression = 43,
        EmitterShape3D = 44,
        EmitterShape3DExpression = 45,
        AlphaCorrection = 46,
        TypeStrainRibbon = 47,
        TypeStrainRibbonExpression = 48,
        ShaderSettings = 49,
        ShaderSettingsExpression = 50,
        Distortion = 51,
        RenderTarget = 52,
        PtLife = 53,
        PtBehavior = 54,
        PtBehaviorClip = 55,
        PlayEfx = 56,
        FadeByAngle = 57,
        FadeByAngleExpression = 58,
        FadeByDepth = 59,
        FadeByDepthExpression = 60,
        FadeByOcclusion = 61,
        FadeByOcclusionExpression = 62,
        FakeDoF = 63,
        LuminanceBleed = 64,
        TypeNodeBillboard = 65,
        TypeNodeBillboardExpression = 66,
        UnitCulling = 67,
        FluidEmitter2D = 68,
        FluidSimulator2D = 69,
        PlayEmitter = 70,
        PtTransform3D = 71,
        PtTransform3DClip = 72,
        PtTransform2D = 73,
        PtTransform2DClip = 74,
        PtVelocity3D = 75,
        PtVelocity3DClip = 76,
        PtVelocity2D = 77,
        PtVelocity2DClip = 78,
        PtColliderAction = 79,
        PtCollision = 80,
        PtColor = 81,
        PtColorClip = 82,
        PtUvSequence = 83,
        PtUvSequenceClip = 84,
        TypeGpuBillboard = 85,
        EmitterPriority = 86,
        ItemNum = 87,
    };
}
namespace via::effect::graph {
    enum ContainerType {
        Unknown = 0,
        Emiter = 1,
        Action = 2,
    };
}
namespace via::render::command {
    enum TypeId {
        Clear = 0,
        CopyResource = 1,
        DrawIndexed = 2,
        Draw = 3,
        DrawIndexedInstanced = 4,
        DrawIndexedInstancedIndirect = 5,
        DrawInstanced = 6,
        MultiDrawIndexedInstancedIndirect = 7,
        Dispatch = 8,
        DispatchIndirect = 9,
        UpdateConstantBuffer = 10,
        UpdateBuffer = 11,
        Marker = 12,
        RecordedCommand = 13,
        AsyncDispatch = 14,
        Fence = 15,
        XB1Extention = 16,
        PS4Extention = 17,
    };
}
namespace via::render::RenderLayer {
    enum Priority {
        TopMost = 0,
        Top = 1,
        Default = 2,
        Bottom = 3,
        BottomMost = 4,
    };
}
namespace via::render::SSRControl {
    enum SSRControlType {
        Default = 0,
        Disable = 1,
        Spherical = 2,
        HighQuality = 3,
    };
}
namespace via::render::SSRControl {
    enum SSRResolvePointNum {
        SSRResolvePointNum_1 = 0,
        SSRResolvePointNum_2 = 1,
        SSRResolvePointNum_4 = 2,
    };
}
namespace via::render::streaming_detail {
    enum StreamingState {
        Ready = 0,
        Request = 1,
        Complete = 2,
    };
}
namespace via::render::Renderer {
    enum HDRDrawMode {
        DrawMDROutRange = 1,
        AdjustMaxNits = 2,
    };
}
namespace via::render::RenderConfig {
    enum RenderingMethod {
        Normal = 0,
        Checkerboard = 1,
        Interlaced = 2,
    };
}
namespace via::render::RenderConfig {
    enum FramerateType {
        FIXING30 = 0,
        FIXING60 = 1,
        VARIABLE = 2,
    };
}
namespace via::render::RenderConfig {
    enum AntiAliasingType {
        FXAA = 0,
        TAA = 1,
        FXAA_TAA = 2,
        SMAA = 3,
    };
}
namespace via::render::RenderConfig {
    enum OptionSetting {
        OFF = 0,
        ON = 1,
        CUSTOM = 2,
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
namespace via::render::RenderOutput {
    enum OutputType {
        Default = 0,
        Composite = 1,
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
namespace via::render::MaterialParam {
    enum MaterialParamType {
        Unkown = 0,
        Float4 = 1,
        Float = 2,
        Texture = 3,
    };
}
namespace via::render::Wrinkle {
    enum CalcMode {
        Maximum = 0,
        Average = 1,
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
namespace via::render::Stamp {
    enum TargetUV {
        Primary = 0,
        Secondary = 1,
    };
}
namespace via::render::Stamp {
    enum RasterMode {
        Standard = 0,
        Wireframe = 2,
        NeighborSample = 3,
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
namespace via::render::VolumeDecal {
    enum WholeBlendMode {
        None = 0,
        BaseColor = 1,
        Normal = 2,
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
namespace via::render::RichDecal {
    enum HeightBlendMode {
        Ignore = 0,
        Add = 1,
        Mul = 2,
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
namespace via::render::Bloodshed {
    enum SourceUV {
        Primary = 0,
        Secondary = 1,
    };
}
namespace via::render::SwingWind {
    enum WindType {
        Directional = 0,
        Point = 1,
        Push = 2,
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
namespace via::render::RenderTargetOperator {
    enum CompareFunc {
        AlwaysPass = 0,
        AlwaysIgnore = 1,
        GreaterEqual = 2,
        Less = 3,
    };
}
namespace via::render::RenderTargetOperator {
    enum Compress {
        None = 0,
        Realtime = 1,
        Hardware = 65,
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
namespace via::render::ShadowQualityControl {
    enum ShadowQualityType {
        Default = 0,
        Fast = 1,
    };
}
namespace via::render::ToneMapping {
    enum AutoExposure {
        Enable = 0,
        FixedEnable = 1,
        Disable = 2,
    };
}
namespace via::render::ToneMapping {
    enum Vignetting {
        Enable = 0,
        KerarePlus = 1,
        Disable = 2,
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
namespace via::render::ColorCorrect {
    enum ColorCorrectMethod {
        LinearAndToneCurve = 0,
        ColorCube = 1,
        Max = 2,
    };
}
namespace via::render::SoftBloom {
    enum Algorithm {
        Standard = 0,
        StandardV2 = 1,
        CoDAW = 2,
    };
}
namespace via::render::DepthOfField {
    enum DepthOfFieldType {
        Default = 0,
        Tessellation = 1,
        Max = 2,
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
namespace via::render::ColorDeficiencySimulation {
    enum DeficiencyType {
        Normal = 0,
        Protanopia = 1,
        Deuteranopia = 2,
        Tritanopia = 3,
        Achromatopsia = 4,
        Max = 5,
    };
}
namespace via::render::LDRImagePlane {
    enum BlendType {
        Overlay = 0,
        Max = 1,
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
namespace via::render::AlphaAA {
    enum AntialiasingMethod {
        FXAA = 0,
        SMAA1x = 1,
        SMAAT2x = 2,
    };
}
namespace via::render::CubeTo2D {
    enum TYPE {
        PARABOROID = 0,
        SPHERE = 1,
    };
}
namespace via::render::layer::Transparent {
    enum SegmentOrder {
        PreTransparent = 0,
        Transparent = 1,
        PreparePostTransparent = 2,
        PostTransparent = 3,
        ZPrepass = 4,
        Distortion = 5,
        PostDistortion = 6,
        Primitive2D = 7,
        TransparentOverlay = 8,
    };
}
namespace via::render::layer::Transparent {
    enum LuminanceBleedType {
        Pre = 0,
        Post = 1,
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
namespace via::render::layer::PrepareOutput {
    enum DISPLAYCOLORSPACE {
        SRGB = 0,
        HDTV_REC709 = 1,
        BT2020 = 2,
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
namespace via::render::layer::ShadowCast {
    enum ShadowCastSegment {
        StaticShadow = 0,
        ShadowClear = 1,
        ShadowSolid = 4,
        ShadowTwoSide = 5,
        ShadowTwoSideAlphaTest = 6,
        ShadowAlphaTest = 7,
        ShadowDitherCoverage = 8,
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
        Finalize = 48,
    };
}
namespace via::render::layer::CubemapCapture {
    enum BASIS {
        SH_ORDER1 = 0,
        SH_ORDER2 = 1,
        FC3_BASIS = 2,
    };
}
namespace via::render::layer::CubemapCapture {
    enum BAKEOPTION {
        NONE = 0,
        BOUNCE_PROBE_ENABLE = 1,
        FULL_ILLUMINATION_ENABLE = 2,
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
namespace via::dialog::VrServiceDialog {
    enum Mode {
        Positioning = 0,
        TipsForEnvironment = 1,
    };
}
namespace via::attribute::FsmCategoryAttribute {
    enum Category {
        None = 0,
        Fsm = 1,
        Mot = 2,
    };
}
namespace via::attribute::RemotePropertyAttribute {
    enum SyncMode {
        Copy = 0,
        Kill = 1,
        Transaction = 2,
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
namespace via::os::http_client {
    enum RedirectPolicy {
        Never = 0,
        Always = 1,
        DisallowHttpsToHttp = 2,
        NoSchemeChanges = 3,
        MAX = 4,
    };
}
namespace via::os::http_client {
    enum Error {
        Unavailable = -2,
        Pending = -1,
        None = 0,
    };
}
namespace via::os::http_client {
    enum Method {
        Get = 0,
        Post = 1,
        Put = 2,
        Delete = 3,
    };
}
namespace via::os::dialog {
    enum Error {
        None = 0,
        InvalidArgument = 1,
        Busy = 2,
    };
}
namespace via::os::dialog {
    enum State {
        None = 0,
        Busy = 1,
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
namespace via::network::service::Ranking::ScoreList {
    enum SortMode {
        None = 0,
        RankAscend = 1,
        RankDescend = 2,
        ValueAscend = 3,
        ValueDescend = 4,
    };
}
namespace via::havok::ClothComplexWind::Wave {
    enum WaveForm {
        WaveType_Sin = 0,
        WaveType_Saw = 1,
        WaveType_RevSaw = 2,
        WaveType_Square = 3,
        WaveType_Tri = 4,
        WaveType_Noise = 5,
    };
}
namespace via::havok::RigidBody::DefaultSetting {
    enum Type {
        Free = 0,
        Static = 1,
        Keyframed = 2,
        Dynamic = 3,
        Dynamic_Fixed = 4,
    };
}
namespace via::havok::Ragdoll::DefaultSetting {
    enum Type {
        Free = 0,
        Static = 1,
        Keyframed = 2,
        Dynamic = 3,
        Dynamic_Fixed = 4,
    };
}
namespace via::havok::Ragdoll::KeyframeControllerSetting {
    enum Preset {
        Custom = 0,
        FixRoot = 1,
        FreeRoot = 2,
    };
}
namespace via::havok::Ragdoll::MotorControllerSetting {
    enum Preset {
        Preset_Custom = 0,
        Preset_4Iterator_FreeRoot_Soft = 1,
        Preset_4Iterator_FreeRoot_Hard = 2,
        Preset_4Iterator_FixRoot_Soft = 3,
        Preset_4Iterator_FixRoot_Hard = 4,
    };
}
namespace via::motion::IkJacobian::Link {
    enum AxisType {
        X = 1,
        Y = 2,
        Z = 4,
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
namespace via::motion::JointRemapValue::RemapValueItem {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace via::motion::JointRemapValue::RemapValueItem {
    enum TRS {
        Trans = 0,
        Rot = 1,
        Scale = 2,
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
namespace via::motion::JointRemapValue::RemapValueItem {
    enum CalculateMode {
        Sum = 0,
        Average = 1,
    };
}
namespace via::physics::StaticCompoundShape::Instance {
    enum Type {
        Additive = 0,
        Subtractive = 1,
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
namespace Em5520Effect {
    enum IDAlias {
        Fire = 0,
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
namespace Em5400Effect {
    enum IDAlias {
        WingBlur = 0,
        DisperseDead = 1,
        BurnDead = 2,
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
namespace Em4100Effect {
    enum IDAlias {
        LostHead = 0,
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
namespace Em3100Effect {
    enum IDAlias {
        Resident = 0,
        BugGather = 1,
        BugHoleGoki = 2,
        BugDrop = 3,
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
namespace CH8Em4450Effect {
    enum IDAlias {
        BabySpawn = 0,
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
namespace CH8Em4100Effect {
    enum CH8IDAlias {
        LostHead = 0,
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
namespace app {
    enum PlayerVoiceAttackType {
        Normal = 0,
        Battle = 1,
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
namespace app {
    enum SelectListMenuResult {
        None = 0,
        Decide = 1,
        Cancel = 2,
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
namespace app {
    enum SaveDataType {
        Optional = 0,
        Auto = 1,
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
namespace app {
    enum ActiveUserPadPairingResult {
        OK = 0,
        NecessaryAccountPicker = 1,
        NecessaryLastInputDevice = 2,
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
namespace app {
    enum WeaponCategory {
        Melee = 0,
        Gun = 1,
        Others = 2,
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
namespace app {
    enum DropTableID {
        DROP_TABLE_DEFAULT = 0,
    };
}
namespace app {
    enum PropID {
        Etc = 0,
    };
}
namespace app {
    enum PropCategory {
        Door = 0,
        Etc = 1,
    };
}
namespace app {
    enum CameraID {
        MainCamera = 0,
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
namespace app {
    enum RegionType {
        Unknown = 0,
        Japan = 1,
        USA = 2,
        Europe = 3,
        Asia = 4,
    };
}
namespace app {
    enum ExtraRegionType {
        Unknown = 0,
        German = 1,
    };
}
namespace app {
    enum CERO {
        None = 0,
        D = 1,
        Z = 2,
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
namespace app::CH9Em6700::Goal {
    enum EvaluatorID {
        HasTarget = 0,
        OutRange = 1,
        InRange = 2,
        HasAttackRight = 3,
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
namespace app::CH9Em5901 {
    enum ThinkOrder {
        None = 0,
        Dead = 1,
    };
}
namespace app::CH9Em5901 {
    enum ThinkState {
        None = 0,
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
namespace app::CH9Em5850 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::CH9Em5850 {
    enum ThinkState {
        None = 0,
        NoLostPlayer = 1,
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
namespace app::CH9Em5800 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::CH9Em5800 {
    enum ThinkState {
        None = 0,
        NoThink = 1,
        Passive = 2,
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
namespace app::CH9Em5700 {
    enum ThinkOrder {
        None = 0,
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
namespace app::CH8Em4450::Action {
    enum CH8ActionCategory {
        Follow = 5,
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
namespace app::vr {
    enum Eye {
        Left = 0,
        Right = 1,
    };
}
namespace app::vr {
    enum DeviceStatus {
        Disabled = 0,
        Inactive = 1,
        Active = 2,
    };
}
namespace app::vr {
    enum VrMode {
        None = 0,
        Stereo = 1,
        Screen = 2,
    };
}
namespace app::vr {
    enum StickRotationMode {
        Analogue = 0,
        Digital = 1,
    };
}
namespace app::vr {
    enum PlayerMoveSpeed {
        Default = 0,
        Slowish = 1,
        Slow = 2,
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
namespace app::network {
    enum EventWriterType {
        ETX = 0,
        XSAPI = 1,
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
namespace app::Nightmare {
    enum TrapLevel {
        Init = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        End = 4,
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
namespace app::Nightmare {
    enum ResultScoreGroup {
        None = 0,
        FinalJunkPartsNum = 1,
        EnemyKillNum = 2,
        FinalWaveState = 3,
        PenaltyCraftItem = 4,
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
namespace app::Nightmare {
    enum SpawnInfoTagID {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
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
namespace app::Collision {
    enum SideType {
        None = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::Em8950 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em8950 {
    enum ThinkState {
        None = 0,
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
namespace app::Em8940 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em8940 {
    enum ThinkState {
        None = 0,
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
namespace app::Em8910 {
    enum ThinkState {
        None = 0,
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
namespace app::Em8900 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em8900 {
    enum ThinkState {
        None = 0,
        Battle = 1,
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
namespace app::Em8100 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em8100 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Battle = 2,
    };
}
namespace app::Em8100 {
    enum OverrideActionNo {
        Test = 0,
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
namespace app::Em8100::Goal {
    enum GoalId {
        Idle = 0,
        Discovery = 1,
        UnDiscovery = 2,
        Battle = 3,
        _None = 4,
    };
}
namespace app::Em8001 {
    enum ThinkOrder {
        None = 0,
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
namespace app::Em8001 {
    enum OverrideActionNo {
        Test = 0,
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
namespace app::Em8001::Message {
    enum CorresponceExistMessageType {
        Retire = 0,
        Override = 1,
        WaitForEnd = 2,
    };
}
namespace app::Em8001::Message {
    enum Priority {
        Low = 0,
        Middle = 1,
        High = 2,
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
namespace app::Em8000::Message {
    enum TagRandomGroup {
        None = 0,
        DeathScissorsAttack = 1,
        GrappleBattleOfSaw = 2,
        CoreRecovery = 3,
        PlayerChainsawStop = 4,
    };
}
namespace app::Em8000::Message {
    enum CorresponceExistMessageType {
        Retire = 0,
        Override = 1,
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
namespace app::Em5552 {
    enum ThinkOrder {
        None = 0,
        Dead = 1,
    };
}
namespace app::Em5552 {
    enum ThinkState {
        None = 0,
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
namespace app::Em5540 {
    enum ThinkOrder {
        None = 0,
        Dead = 1,
        Revive = 2,
    };
}
namespace app::Em5540 {
    enum ThinkState {
        None = 0,
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
namespace app::Em5520 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em5520 {
    enum ThinkState {
        None = 0,
        NoLostPlayer = 1,
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
namespace app::Em5510 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em5510 {
    enum ThinkState {
        None = 0,
        NoThink = 1,
        Passive = 2,
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
namespace app::Em5400 {
    enum ThinkOrder {
        None = 0,
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
namespace app::Em3600 {
    enum ThinkOrder {
        None = 0,
        PLSearchGoTo = 1,
        SneakSet = 2,
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
namespace app::Em3102 {
    enum ThinkState {
        Idle = 0,
        Goto = 1,
        Em3102 = 2,
        LastChase = 3,
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
namespace app::Em3102::Message {
    enum CorresponceExistMessageType {
        Retire = 0,
        Override = 1,
        WaitForEnd = 2,
    };
}
namespace app::Em3102::Message {
    enum Priority {
        Low = 0,
        Middle = 1,
        High = 2,
    };
}
namespace app::Em3102::Goal {
    enum GoalId {
        Idle = 0,
        Rest = 1,
        Em3102 = 2,
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
namespace app::Em3101 {
    enum ThinkOrder {
        None = 0,
        Targetting = 1,
    };
}
namespace app::Em3101 {
    enum ThinkState {
        None = 0,
    };
}
namespace app::Em3101::Action {
    enum ActionNo {
        Idle = 0,
        Run = 1,
        Grapple = 2,
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
namespace app::Em3002 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Battle = 2,
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
namespace app::Em3002::Action {
    enum ActionZero {
        GrappleFinishMove = 0,
        Non = 99,
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
namespace app::Em3002::Goal {
    enum AppearMessageStatus {
        Non = 0,
        DiscoveryHearing = 1,
        DiscoveryVision = 2,
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
namespace app::Em3001 {
    enum ThinkOrder {
        None = 0,
    };
}
namespace app::Em3001 {
    enum ThinkState {
        None = 0,
        Idle = 1,
        Battle = 2,
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
namespace app::Em3001::Action {
    enum ActionZero {
        StepBack = 0,
        GrappleHeadButt = 1,
        GrappleKnee = 2,
        GrappleThrow = 3,
        Non = 99,
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
namespace app::Em3001::Action {
    enum ActionMid {
        StepInStraight = 0,
        StepInSide = 1,
        StepInGrab = 2,
        Num = 3,
        Non = 99,
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
namespace app::Em3001::Goal {
    enum AppearMessageStatus {
        Non = 0,
        UnDiscovery = 1,
        DiscoveryShort = 2,
        DiscoveryMiddle = 3,
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
namespace app::Em3000 {
    enum OverrideActionNo {
        Test = 0,
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
namespace app::Em3000::Action {
    enum ActionZero {
        StepBack = 0,
        GrappleHeadButt = 1,
        GrappleKnee = 2,
        GrappleThrow = 3,
        Non = 99,
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
namespace app::Em3000::Goal {
    enum AppearMessageStatus {
        Non = 0,
        UnDiscovery = 1,
        DiscoveryShort = 2,
        DiscoveryMiddle = 3,
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
namespace app::Em2000 {
    enum ThinkOrder {
        None = 0,
        Chapter4_3_Sleep = 1,
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
namespace app::Em2000::Goal {
    enum Battle4State {
        FirstFlow = 0,
        SecondFlow = 1,
        ThirdFlow = 2,
        MountGrapple = 3,
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
namespace app::AI {
    enum AttackPermitReturnReason {
        Hitted = 0,
        NotHitted = 1,
        Canceled = 2,
        Damaged = 3,
        Died = 4,
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
namespace app::AI {
    enum CommonThinkOrder {
        None = 0,
        Wait = 1,
        Goto = 2,
    };
}
namespace app::AI {
    enum CommonThinkState {
        None = 0,
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
namespace app::Command {
    enum AnalogButtonType {
        LT = 0,
        RT = 1,
    };
}
namespace app::Command {
    enum StickType {
        Left = 0,
        Right = 1,
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
namespace app::Command {
    enum ThresholdType {
        MoreThan = 0,
        LessThan = 1,
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
namespace LibJson::JsonReader {
    enum Phase {
        Idle = 0,
        Name = 1,
        Value = 2,
    };
}
namespace appFSM::CH8ArmBombTimerControl {
    enum RequestTypeEnum {
        Start = 0,
        Stop = 1,
        Reset = 2,
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
namespace app::BirthdayFolderSelector {
    enum StageSetEnum {
        TypeA = 0,
        TypeB = 1,
        Common = 2,
        Max = 3,
    };
}
namespace app::BirthdayFood {
    enum MapIconTypeDef {
        BirthdayFood = 50,
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
namespace app::MenuManager {
    enum InteractOperationCursorType {
        Down = 0,
        Right = 1,
    };
}
namespace app::BirthdayMainMenu {
    enum ScreenTypeEnum {
        Title = 0,
        Select = 1,
    };
}
namespace app::BirthdayPlayerSelector {
    enum PlayerNoEnum {
        Player01 = 0,
        Player02 = 1,
        Max = 2,
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
namespace app::BirthdaySelect {
    enum RankingStateEnum {
        None = 0,
        Init = 1,
        InitWait = 2,
        Start = 3,
        StartWait = 4,
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
namespace app::BirthdayTransitionController {
    enum TransitionTypeEnum {
        None = 0,
        NormalJump = 1,
        Restrat = 2,
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
namespace app::BirthdayTransitionController {
    enum SaveWaitTypeEnum {
        None = 0,
        Result = 1,
        ModeEnd = 2,
        ModeEndToVrTutorial = 3,
        Max = 4,
    };
}
namespace app::BirthdayWeaponMap {
    enum MapIconTypeDef {
        Weapon = 1,
    };
}
namespace app::Em3090 {
    enum ActionStepEnum {
        Wait = 0,
        Eat = 1,
        Reaction = 2,
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
namespace app::CardGameItem {
    enum DrawType {
        NoUse = 0,
        Normal = 1,
        SP_PerfectDraw = 2,
        SP_Gift = 3,
        SP_Curse = 4,
    };
}
namespace app::CardGameItem {
    enum RemoveType {
        NoUse = 0,
        Remove = 1,
        Return = 2,
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
namespace app::CardGameItem {
    enum ItemRemoveType {
        NoUse = 0,
        Last = 1,
        All = 2,
        TableGoal = 3,
        MyBetDown = 4,
    };
}
namespace app::CardGameManager {
    enum HandItemRemoveRequestType {
        RemoveAll = -1,
        RemoveHalf = -2,
    };
}
namespace app::CardGameMaster {
    enum GameBetType {
        Finger = 0,
        Electric = 1,
        Saw = 2,
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
namespace app::CardGameMaster {
    enum PosType {
        Stock = 0,
        Banker = 1,
        Player = 2,
    };
}
namespace app::CardGameMaster {
    enum FaceType {
        Down = 0,
        Up = 1,
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
namespace app::CardGameObjectFingerMachine {
    enum FingerMachineJointMaskID {
        Finger1 = 1,
        Finger2 = 2,
        Finger3 = 3,
        Finger4 = 4,
        Finger5 = 5,
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
namespace app::ItemExplanation {
    enum ItemIconPlayMotion {
        PlayerUse = 0,
        EnemyUse = 1,
        Get = 2,
    };
}
namespace app::ItemExplanation {
    enum ItemTextType {
        Name = 0,
        Explanation = 1,
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
namespace app::Chapter3_IMD_MainMenu {
    enum ProcStateEnum {
        Startup = 0,
        WaitResident = 1,
        InputProc = 2,
        ExitWait = 3,
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
namespace app::AdditionalTreeLayer {
    enum PriorityLevel {
        None = 0,
        Low = 1,
        Middle = 2,
        High = 3,
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
namespace app::FBIKAttackController {
    enum Axis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace app::FBIKAttackController {
    enum HandModeType {
        R = 0,
        L = 1,
    };
}
namespace app::FBIKAttackController {
    enum GuideModeType {
        Plane = 0,
        Line = 1,
    };
}
namespace app::FBIKAttackController {
    enum AttackModeType {
        Rotate = 0,
        Target = 1,
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
namespace app::Humanoid {
    enum HandAdjustModeType {
        AdjustFromRoot = 0,
        AdjustFromElbow = 1,
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
namespace app::IK2Bone {
    enum EffectorJointType {
        Default = 0,
        TargetJoint2 = 0,
        TargetJoint3 = 1,
    };
}
namespace app::IKMultiBone {
    enum SolverType {
        CyclicCoordinateDescent = 0,
        Particle = 1,
    };
}
namespace app::LookAt {
    enum TargetModeEnum {
        Position = 0,
        GameObject = 1,
        Joint = 2,
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
namespace app::MotionGroupTable {
    enum GroupType {
        Other = 0,
        One = 1,
        LeftRight = 2,
        Strafe = 3,
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
namespace app::MotionGroupTable {
    enum VersionNo {
        Initial = 0,
        EnableBankType = 2,
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
namespace app::SmoothAnimator {
    enum SimilarityOptionType {
        None = 0,
        AppendData = 1,
        DummyMotion = 2,
    };
}
namespace app::Attention {
    enum Type {
        Player = 0,
        Enemy = 1,
        Marker = 2,
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
namespace app::Em2000Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Angry = 200,
        Dead = 5100,
    };
}
namespace app::PlayerGrappleEm2000 {
    enum GrappleAutoCorrectType {
        SafePosition = 0,
        SafeDirection = 1,
    };
}
namespace app::Em2100Control {
    enum RequestSetColliderIndex {
        PressMain = 0,
        PressLarge = 1,
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
namespace app::Em3000Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
    };
}
namespace app::Em3000Grapple {
    enum Layer {
        Base = 0,
        Resist = 1,
        Guard = 2,
    };
}
namespace app::Em3001FirstStamp {
    enum TimelineFrame {
        Default = 0,
        Clean = 1,
        Dirty = 2,
    };
}
namespace app::Em3001Think {
    enum Mode {
        Idle = 0,
        Battle = 1,
    };
}
namespace app::Em3001Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
    };
}
namespace app::Em3001Grapple {
    enum Layer {
        Base = 0,
        Resist = 1,
        Guard = 2,
    };
}
namespace app::Em3002Think {
    enum Mode {
        Idle = 0,
        Battle = 1,
    };
}
namespace app::Em3002Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Ghost = 100,
    };
}
namespace app::Em3100SpawnManager {
    enum UseType {
        Patrol = 0,
        BugHole = 1,
        BugHoleFast = 2,
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
namespace app::Em3600Think {
    enum LegState {
        TwoLeg = 0,
        FourLeg = 1,
        FourLegRev = 2,
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
namespace app::Em3600Think {
    enum Phase {
        Generate = 0,
        Sneak = 1,
        Angry = 2,
        Mix = 3,
        Last = 4,
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
namespace app::Em4000ActionController {
    enum DestinationType {
        ChangeThink = 0,
        SelfKill = 1,
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
namespace app::Em4000Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace app::Em4100ActionController {
    enum MoveType {
        Default = 0,
        ForceSolo = 1,
        ForceAround = 2,
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
namespace app::Em4100ActionController {
    enum BackstepQueType {
        Back = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::Em4100ActionController {
    enum DodgeQueType {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em4200ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
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
namespace app::Em5400Think {
    enum Mode {
        Ground = 0,
        Fly = 1,
    };
}
namespace app::Em5510ActionController {
    enum Size {
        Small = 0,
        Middle = 1,
        Large = 2,
    };
}
namespace app::Em5510Think {
    enum ThinkMode {
        Normal = 0,
        NoThink = 1,
        Passive = 2,
    };
}
namespace app::Em5510Think {
    enum BreakState {
        None = 0,
        FirstBreak = 1,
        SecondBreak = 2,
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
namespace app::Em5520FollowBug {
    enum BankId {
        Basic = 10,
        Attack = 20,
        Damage = 30,
    };
}
namespace app::Em8000FirstStamp {
    enum TimelineIndex {
        Default = 0,
        Clean = 1,
        Dirty = 2,
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
namespace app::Em8000ScarController {
    enum PartType {
        LeftLeg = 0,
        RightLeg = 1,
        LeftArm = 2,
        RightArm = 3,
        Head = 4,
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
namespace app::Em8000ZoneGroup {
    enum Property {
        INVALID = -1,
        None = 0,
        AroundPillar = 1,
    };
}
namespace app::Em8100Think {
    enum Mode {
        Idle = 0,
        Battle = 1,
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
namespace app::Em8900Think {
    enum MessageType {
        Move = 0,
        Damage = 1,
        DeathAttack = 2,
    };
}
namespace app::Em8910Think {
    enum TentacleType {
        MoveTentacle = 0,
        AttackTentacle = 1,
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
namespace app::Em8950WwiseMonitoredValue {
    enum LastBossMode {
        DemonWall = 0,
        Daidarabotchi = 1,
    };
}
namespace app::EnemyActionController {
    enum DamageScale {
        S = 0,
        M = 1,
        L = 2,
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
namespace app::EnemyActionController {
    enum DamageAttribute {
        None = 0,
        Fire = 1,
        Acid = 2,
        Explode = 3,
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
namespace app::EnemyActionController {
    enum DamageDirection {
        Front = 0,
        Back = 1,
        Left = 2,
        Right = 3,
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
namespace app::EnemyActionController {
    enum FaceDirectionType {
        Upward = 0,
        Downward = 1,
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
namespace app::EnemyActionController {
    enum HiddenType {
        Invalid = 0,
        ForDead = 1,
        ForSuspend = 2,
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
namespace app::EnemyActionController {
    enum SelfDieReasonType {
        Falling = 0,
        Explosion = 1,
        Force = 2,
        GrappleDead = 3,
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
namespace app::EnemyActionController {
    enum GroundType {
        Ground = 0,
        Wall = 1,
        Ceil = 2,
        Air = 3,
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
namespace app::EnemySpawnInfo {
    enum SuspendType {
        None = 0,
        Specified = 1,
        Self = 2,
        Auto = 3,
        WaitingAutoSpawn = 4,
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
namespace app::EnemyGrappleBase {
    enum GrappleStartType {
        Sync = 0,
        Delay = 1,
        NoPosLerp = 2,
    };
}
namespace app::EnemyGrappleBase {
    enum PosLerpProcessType {
        None = 0,
        ToNullOffsetMove = 1,
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
namespace app::MoldedActionController {
    enum DodgeVariation {
        Left = 0,
        LeftBack = 1,
        Right = 2,
        RightBack = 3,
    };
}
namespace app::MoldedActionController {
    enum Tension {
        Normal = 0,
        Excite = 1,
        Anger = 2,
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
namespace app::FootEffectController {
    enum SETriggerTargetEnum {
        Player = 0,
        PlayerJog = 1,
        PlayerCrouch = 2,
        Enemy = 3,
        Num = 4,
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
namespace app::FootEffectController {
    enum WwiseSpecialMaterialID {
        None = 0,
        LittleWet = 1,
        SoakingWet = 2,
        Water = 3,
    };
}
namespace app::GrappleBase {
    enum ConstModeType {
        EnemyToPlayer = 0,
        PlayerToEnemy = 1,
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
namespace app::HitStopController {
    enum HitStopState {
        None = 0,
        CheckHit = 1,
        SlowDown = 2,
        Stop = 3,
        End = 4,
    };
}
namespace app::HandLightDirectionDelayController {
    enum FollowState {
        Wait = 0,
        FollowSlow = 1,
        FollowFast = 2,
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
namespace app::Item {
    enum ItemSlotSize {
        Slot1 = 0,
        Slot2 = 1,
        Slot3 = 2,
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
namespace app::MoveCharacter {
    enum TEST_RE_SWITCH_MT {
        MT_CONCRETE = 0,
        MT_SOIL = 1,
    };
}
namespace app::MoveCharacter {
    enum TEST_RE_STATE_PITCH {
        PITCH_DOWN = 0,
        PITCH_NORMAL = 1,
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
namespace app::Pl0000EventOnly {
    enum StampRoutine {
        None = 0,
        Recover = 1,
        Wet = 2,
        End = 3,
    };
}
namespace app::Pl0000EventOnly {
    enum StampIndex {
        Recover = 0,
        Wet = 1,
    };
}
namespace app::PlayerBreathController {
    enum HealthConditionEnum {
        Fine = 0,
        Dying = 1,
    };
}
namespace app::PlayerCamera {
    enum FovType {
        Narrow = -10,
        Normal = 0,
        Wide = 10,
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
namespace app::PlayerCamera {
    enum RotationDirectionType {
        Normal = 0,
        InvertHorizontal = 1,
        InvertVertical = 2,
        InvertAll = 3,
    };
}
namespace app::PlayerCamera {
    enum RotationType {
        Incremental = 0,
        Angular = 1,
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
namespace app::PlayerCamera {
    enum RotationInertiaType {
        None = 0,
        Weak = 1,
        Normal = 2,
        Strong = 3,
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
namespace app::PlayerCamera {
    enum ShipShakeType {
        None = 0,
        Small = 1,
        Large = 2,
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
namespace app::PlayerDamageController {
    enum WwiseDamageType {
        Damage = 0,
        Guard = 1,
    };
}
namespace app::PlayerExternalRequestController {
    enum Action {
        Empty = 0,
        Chapter1_Battle1_DownStairs = 1,
    };
}
namespace app::PlayerExternalRequestController {
    enum State {
        Enter = 0,
        Run = 1,
        Exit = 2,
    };
}
namespace app::PlayerHandLight {
    enum PowerActionRequest {
        None = 0,
        ForceOn = 1,
        ForceOff = 2,
    };
}
namespace app::PlayerHandLight {
    enum ControlStatus {
        Free = 0,
        External = 1,
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
namespace app::PlayerLighter {
    enum AssistLightState {
        Off = 0,
        On = 1,
        LighterOn = 2,
    };
}
namespace app::PlayerMelee {
    enum AttackDirection {
        LeftDown = 0,
        RightDown = 1,
    };
}
namespace app::PlayerMeshController {
    enum LHandPartsState {
        Normal = 0,
        LHandCut = 1,
    };
}
namespace app::PlayerMeshController {
    enum LegPartsState {
        Normal = 0,
        LegCut = 1,
        LegCure = 2,
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
namespace app::PlayerMotionController {
    enum RequestPriority {
        Default = 0,
        Damage = 1,
        Dead = 2,
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
namespace app::PlayerWeaponChange {
    enum ItemType {
        Unknown = 0,
        Weapon = 1,
        Item = 2,
    };
}
namespace app::SecondaryMotionReceiver {
    enum MotionChangeCheckState {
        NoCheck = 0,
        Start = 1,
        Checking = 2,
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
namespace app::DebugFolderActivater {
    enum ActiveTypeEnum {
        RootDebug = 0,
        ChapterDebug = 1,
        Max = 2,
    };
}
namespace app::DoomsUpdater {
    enum StepType {
        Start = 0,
        Next = 1,
        AfterNext = 2,
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
namespace app::EffectChainMeshAnim {
    enum PlayTypeEnum {
        Once = 0,
        Loop = 1,
        Pause = 2,
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
namespace app::EffectShakeCamera {
    enum ShakeTypeEnum {
        Small = 1,
        Large = 2,
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
namespace app::EPVExpertCharacterBloodData {
    enum ZDirectionType {
        CollisionNormal = 0,
        InverseCollisionNormal = 1,
        AttackDirection = 2,
        InverseAttackDirection = 3,
        SawRotation = 4,
    };
}
namespace app::EPVExpertCharacterBloodData {
    enum DamageHitTypeEnum {
        None = 0,
        WeakPoint = 1,
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
namespace app::EPVExpertObjectLandingData {
    enum ZDirectionType {
        AttackDirection = 0,
        SawRotation = 1,
    };
}
namespace app::EPVExpertPartsDamageData {
    enum DamageTypeEnum {
        Fire = 0,
        Acid = 1,
        Num = 2,
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
namespace app::EPVExpertWeaponLandingData {
    enum ZDirectionType {
        Random = 0,
        AttackDirection = 1,
        SawRotation = 2,
    };
}
namespace app::MaterialBloodRateController {
    enum BloodType {
        Blood = 0,
        Risotto = 1,
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
namespace app::VFXEmitZoneGroup {
    enum Status {
        None = 0,
        EmitOffTrigger = 1,
        EmitOnTrigger = 2,
        EmitOn = 3,
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
namespace app::GameEventAction {
    enum PressPriorityType {
        Default = 0,
        SpecialFix = 1,
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
namespace app::GameEventAction {
    enum StartPosTypeEnum {
        Point = 0,
        Line = 1,
        StartAngleOnly = 2,
    };
}
namespace app::GameEventAction {
    enum InterpStartTypeEnum {
        DelayPosAndRot = 0,
        DelayPosOnly = 1,
    };
}
namespace app::GameEventAction {
    enum ParentSettingOnEvent {
        NoChange = 0,
        RootObject = 1,
        Clear = 2,
    };
}
namespace app::GameEventAction {
    enum ParentSettingAfterEvent {
        NoChange = 0,
        RestoreBeforeEvent = 1,
        Clear = 2,
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
namespace app::GameEventController {
    enum ProcessType {
        Stop = 0,
        Loading = 1,
        Wait = 2,
        Active = 3,
        End = 4,
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
namespace app::EventActionTask {
    enum PriorityType {
        None = 0,
        InteractEventLow = 1,
        Grapple = 2,
        InteractEventHigh = 3,
        Ingame = 4,
    };
}
namespace app::EventActionController {
    enum ProcessType {
        Running = 0,
        End = 1,
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
namespace app::FF030_Ex_MainMenu {
    enum Step {
        GoNext = 0,
        Option = 1,
        Main = 2,
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
namespace app::AdjustBrightnessGUI {
    enum ModeDef {
        BootFlow = 0,
        Normal = 1,
        HDRBootFlow2nd = 2,
    };
}
namespace app::AmbassadorTrialInGameTitle {
    enum TypeEnum {
        MainMenu = 0,
        InGame = 1,
        InGame_VR = 2,
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
namespace app::ClockTime {
    enum MeridiemType {
        AM = 0,
        PM = 1,
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
namespace app::Cp7GameOverChoice {
    enum Step {
        Main = 0,
        Cutin = 1,
    };
}
namespace app::Cp7GameOverChoice {
    enum Choice {
        Restart = 0,
        Quit = 1,
        Max = 2,
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
namespace app::CraftBenchUIAsset {
    enum IconPanelState {
        ITEM_L = 0,
    };
}
namespace app::CraftBenchUIAsset {
    enum CostNumState {
        DEFAULT = 0,
        SHORTAGE = 1,
        LEVELMAX = 2,
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
namespace app::CraftBenchUIAsset {
    enum TabPanelState {
        DEFAULT = 0,
        SELECT = 1,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemSelectPanelState {
        DEFAULT = 0,
        LEVELMAX = 1,
        LEVELUP = 2,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemSelectChildPanelState {
        SIZE1 = 0,
        SIZE2 = 1,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemBGPanelState {
        DEFAULT = 0,
        LEVELMAX = 1,
        LEVELUP = 2,
    };
}
namespace app::CraftBenchUIAsset {
    enum ItemBGChildChildPanelState {
        SIZE1 = 0,
        SIZE2 = 1,
    };
}
namespace app::CraftBenchUIAsset {
    enum StackPanelState {
        DISABLE = 0,
        SIZE1 = 1,
        SIZE2 = 2,
    };
}
namespace app::TabController {
    enum TabType {
        Item = 0,
        Skill = 1,
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
namespace app::CrusherUIAsset {
    enum MaterPanelState {
        DEFAULT = 0,
        EMPTY = 1,
        FULL = 2,
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
namespace app::DetailSearchGUI {
    enum State {
        TitleAndExp = 0,
        ExpOnly = 1,
        Nothing = 2,
        Highlight = 3,
    };
}
namespace app::DifficultySelectGUI {
    enum ModeDef {
        BootFlow = 0,
        Title = 1,
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
namespace app::EndingAnnounceGUI {
    enum State {
        DEFAULT = 0,
        FADE_IN = 1,
        FADE_OUT = 2,
    };
}
namespace app::FadeControl {
    enum FadeStatusEnum {
        OffBlack = 0,
        OnBlack = 1,
    };
}
namespace app::FadeControl {
    enum FadeRequestEnum {
        None = 0,
        FadeIn = 1,
        FadeOut = 2,
    };
}
namespace app::FileArtContainer {
    enum FileArtState {
        Hide = 0,
        Standby = 1,
        Show = 2,
    };
}
namespace app::FileMenu {
    enum ModeDef {
        FileOnly = 0,
        List = 1,
    };
}
namespace app::FileMenu {
    enum ProcDef {
        File = 0,
        List = 1,
    };
}
namespace app::FileMenu_File {
    enum FileInput {
        Default = 0,
        WaitSelectionChange = 1,
        WaitPageChange = 2,
    };
}
namespace app::FileMenu_FileList {
    enum ProcResultDef {
        Cancel = 0,
        Decide = 1,
    };
}
namespace app::FirstLanguageGUI {
    enum ModeDef {
        First = 0,
        Normal = 1,
        Back = 2,
    };
}
namespace app::FirstLanguageGUI {
    enum Step {
        Main = 0,
        ChangeFont = 1,
        GoNext = 2,
    };
}
namespace app::FirstReNetMenu {
    enum ModeDef {
        Normal = 0,
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
namespace app::FirstSettingMenu {
    enum ModeDef {
        Normal = 0,
    };
}
namespace app::FirstSettingMenu {
    enum ListElemID {
        GoNext = 0,
        Option = 1,
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
    };
}
namespace app::GameOverScreen {
    enum ModeDef {
        Normal = 0,
    };
}
namespace app::GameOverScreen {
    enum ListElemID {
        Restart = 0,
        End = 1,
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
namespace app::GameOverScreen {
    enum Result {
        Unknown = 0,
        Restart = 1,
        Quit = 2,
        Cp7Result = 3,
    };
}
namespace app::GenomeCodexGUI {
    enum Mode {
        HP = 0,
    };
}
namespace app::GenomeCodexGUI {
    enum StepType {
        HP = 0,
        Scan = 1,
        Radar = 2,
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
namespace app::GenomeCodexGUI {
    enum RadarNoiseLvDef {
        None = 0,
        Lv1 = 1,
        Lv2 = 2,
    };
}
namespace app::GenomeCodexGUI {
    enum RadarStateDef {
        None = 0,
        EnableTarget = 1,
        DisableTarget = 2,
    };
}
namespace app::GenomeCodexGUI {
    enum RadarCautionStateDef {
        None = 0,
        Near = 1,
        Reached = 2,
    };
}
namespace app::GenomeCodexGUISimple {
    enum Mode {
        HP = 0,
    };
}
namespace app::GenomeCodexGUISimple {
    enum StepType {
        HP = 0,
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
namespace app::InventoryMenu {
    enum TabIndex {
        Item = 0,
        CombineList = 1,
        Num = 2,
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
namespace app::InventoryMenu {
    enum ItemBoxMode {
        Default = 0,
        ItemSetting = 1,
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
namespace app::InventoryContextMenu {
    enum ResultType {
        NowSelecting = 0,
        Canceled = 1,
        Selected = 2,
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
namespace app::InventoryContextMenu {
    enum ContentEnable {
        Enable = 0,
        OnlyIconDisable = 1,
        Disable = 2,
    };
}
namespace app::InventoryItemBox {
    enum ItemNumType {
        All = 0,
        One = 1,
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
namespace app::ItemCombiner {
    enum Index {
        First = 0,
        Second = 1,
        Num = 2,
    };
}
namespace app::ItemCombiner {
    enum Result {
        Success = 0,
        Fail = 1,
        FailSerum = 2,
    };
}
namespace app::ItemHereIcon {
    enum IconTypeDef {
        Normal = 0,
        Gorgeous = 1,
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
namespace app::JunkPartsUIAsset {
    enum GetPartsState {
        DEFAULT = 0,
        FADE_IN = 1,
        FADE_OUT = 2,
        DISABLE = 3,
    };
}
namespace app::JunkPartsUIAsset {
    enum PartsCountState {
        DEFAULT = 0,
        EMPTY = 1,
        FULL = 2,
    };
}
namespace app::JunkPartsChangedAnimation {
    enum ChangeContext {
        Get = 0,
        Lost = 1,
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
namespace app::LastWaveUIDesc {
    enum DescriptionType {
        OPEN = 0,
        DISPLAY_BONUS = 1,
        DISPLAY_TEXT = 2,
        DISPLAY_RESULT = 3,
    };
}
namespace app::LastWaveTime {
    enum Meridiem {
        AM = 0,
        PM = 1,
    };
}
namespace app::LogoControl {
    enum UseSlideType {
        JP_D = 0,
        JP_Z = 1,
        Other = 2,
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
namespace app::MapManager {
    enum MapChangeDir {
        Up = 0,
        Down = 1,
    };
}
namespace app::MapManager {
    enum MapObjectState {
        Enable = 0,
        Disable = 1,
    };
}
namespace app::MapManager {
    enum SheetMode {
        FRAME = 0,
        MAPIMAGE = 1,
        BG = 2,
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
namespace app::MapManager {
    enum MapSheetState {
        Disable = 0,
        OpenMapWindow = 1,
        OpenMapSheet = 2,
        CheckCategoryMove = 3,
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
namespace app::MapManager {
    enum ChapterSaveSlot {
        Chapter1 = 0,
        Chapter3 = 1,
        Chapter4 = 2,
        _Count = 3,
    };
}
namespace app::MapManager {
    enum CH9MapLegendType {
        Boat = 61,
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
namespace app::MapSheet {
    enum MapSegments {
        inactive = 34,
        active = 35,
        activeIcon = 36,
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
namespace app::MessageLabelGUI {
    enum MsgType {
        MultiDispSubtitle = 0,
        Subtitle = 1,
        Interact = 2,
    };
}
namespace app::MessageLabelGUI {
    enum VrGuiParamIndex {
        Subtitle = 0,
        Interact = 1,
    };
}
namespace app::MultiSubMenu {
    enum TabTypeDef {
        Album = 0,
        Map = 1,
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
namespace app::NowOnSaleMenu {
    enum ModeDef {
        Normal = 0,
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
namespace app::NowOnSaleMenu {
    enum Step {
        Main = 0,
        Yes = 1,
        No = 2,
        Detail = 3,
        Exit = 4,
    };
}
namespace app::ObjectiveGUI {
    enum Level {
        Main = 0,
        Sub = 1,
        SubSub = 2,
    };
}
namespace app::ObjectiveGUI {
    enum ModeDef {
        Inventory = 0,
        Map = 1,
    };
}
namespace app::OptionKeyBind {
    enum SlotType {
        Primary = 0,
        Secondary = 1,
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
namespace app::OptionKeyBind {
    enum State {
        Selection = 0,
        KeyReceiving = 1,
        EmptyCutin = 2,
        ErrorCutin = 3,
        DefaultCutin = 4,
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
namespace app::OptionMenu {
    enum ModeDef {
        MainMenu = 0,
        MainMenu_VR = 1,
        Ingame = 2,
        IngameTitle_VR = 3,
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
        EMD = 33,
        HDRModeChanged = 34,
        HDRModeNG = 35,
        ResolutionChanged = 36,
    };
}
namespace app::OptionMenu {
    enum OptionStatePattern {
        Default = 0,
        Arabic = 1,
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
namespace app::OptionMenu {
    enum RightPanelState {
        DEFAULT = 0,
        EXTRAGAME = 1,
        RENET = 2,
    };
}
namespace app::OptionMenu {
    enum RecordScreenType {
        Pause = 0,
        Ending = 1,
    };
}
namespace app::OptionMenu {
    enum ItemMode {
        Normal = 0,
        Button = 1,
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
namespace app::OptionMenu {
    enum TrackingParamType {
        Ingame = 0,
        MainMenu = 1,
        IngameTitle = 2,
    };
}
namespace app::OptionMenu {
    enum ReNetIndex {
        Web = 0,
        OnOff = 1,
        Detail = 2,
    };
}
namespace app::OptionMenu {
    enum MouseBtnRev {
        Normal = 0,
        Reverse = 1,
    };
}
namespace app::OptionMenu {
    enum OnOff {
        On = 0,
        Off = 1,
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
namespace app::OptionMenu {
    enum ArrowDirc {
        None = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::OptionMenu {
    enum OptionPage {
        Brightness = 0,
        Screen = 1,
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
    };
}
namespace app::OptionMenu {
    enum LangItem {
        Voice = 0,
        Caption = 1,
        Caption_Display = 2,
    };
}
namespace app::OptionMenu {
    enum Dynamicrange {
        Large = 0,
        Small = 1,
    };
}
namespace app::OptionMenu {
    enum SpeakerType {
        Surround = 0,
        TV = 1,
        Headphone = 2,
    };
}
namespace app::OptionMenu {
    enum VirtualSurroundOnOffIndex {
        On = 0,
        Off = 1,
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
    };
}
namespace app::OptionMenu {
    enum AimAssistIndex {
        On = 0,
        Off = 1,
    };
}
namespace app::OptionMenu {
    enum WalkSpeedIndex {
        Default = 0,
        Slowish = 1,
        Slow = 2,
    };
}
namespace app::OptionMenu {
    enum RotTypeIndex {
        Incremental = 0,
        Angular = 1,
    };
}
namespace app::OptionMenu {
    enum HeadRotIndex {
        None = 0,
        AxisZ = 1,
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
namespace app::OptionMenu {
    enum DamageEffectType {
        Normal = 0,
        Less = 1,
    };
}
namespace app::OptionMenu {
    enum ReticleDisplay {
        AlwaysDisplay = 0,
        AimDisplay = 1,
        Hide = 2,
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
namespace app::OptionMenu {
    enum ShakeIndex {
        On = 0,
        Off = 1,
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
namespace app::OptionMenu {
    enum VrFilterTypeIndex {
        Horizon = 0,
        Overall = 1,
    };
}
namespace app::OptionMenu {
    enum VrFrontGuideIndex {
        On = 0,
        Off = 1,
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
    };
}
namespace app::OptionMenu {
    enum DisplayCaption {
        On = 0,
        Off = 1,
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
namespace app::OptionListItem {
    enum Mode {
        Normal = 0,
        Button = 1,
        Record = 2,
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
namespace app::PCSystemData {
    enum DisplayModeCol {
        Resolution = 0,
        Refreshrate = 1,
    };
}
namespace app::GraphicDefaultSettings {
    enum PresetType {
        Default = 0,
        Low = 1,
        Medium = 2,
        High = 3,
    };
}
namespace app::PauseMenu {
    enum ModeDef {
        Normal = 0,
        FoundFootage = 1,
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
namespace app::PauseMenu {
    enum RestratStateEnum {
        SelectWait = 0,
        StartWait = 1,
        LoadWait = 2,
    };
}
namespace app::PharmacyDictionary {
    enum Step {
        News = 0,
        Dictionary = 1,
    };
}
namespace app::PharmacyDictionary {
    enum PageMoveTo {
        Prev = -1,
        Next = 1,
    };
}
namespace app::PopupDialog {
    enum Result {
        None = 0,
        Yes = 1,
        No = 2,
    };
}
namespace app::QuickEquipMenu {
    enum ModeType {
        Normal = 0,
        Inventory = 1,
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
namespace app::ReticleGUI {
    enum DisplayState {
        NoHold = 0,
        CasualHold = 1,
        Hold = 2,
        Firing = 3,
        TargetEnable = 4,
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
namespace app::ReticleGUI {
    enum HitSituation {
        NoHit = 0,
        Improper = 1,
        Hit = 2,
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
namespace app::SaveMenu {
    enum ListElemID {
        Restart = 0,
        End = 1,
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
namespace app::ScreenAreaAdjustGUI {
    enum ModeDef {
        BootFlow = 0,
        Normal = 1,
    };
}
namespace app::TipsGUI {
    enum TipsPosState {
        Left = 0,
        Right = 1,
    };
}
namespace app::TipsGUI {
    enum PanelState {
        DEFAULT = 0,
        DECIDE = 1,
        DISABLE = 2,
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
namespace app::TitleSubMenu {
    enum Mode {
        Invalid = 0,
        Normal = 1,
        VR = 2,
        VR_Dummy = 3,
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
        ToVillage = 14,
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
namespace app::ToVillageGUI {
    enum State {
        Disable = 0,
        Banner = 1,
        StartBg = 2,
        MenuBg = 3,
    };
}
namespace app::ToVillageGUI {
    enum Type {
        StartGame = 0,
        SubMenu = 1,
    };
}
namespace app::ToVillageGUI {
    enum Routine {
        BgFadeIn = 0,
        BgMove = 1,
        MsgMove = 2,
        StoreMove = 3,
        BgFadeOut = 4,
        Finish = 5,
    };
}
namespace app::ToVillageGUI {
    enum ResultCutIn {
        NoResult = 0,
        DecideYes = 1,
        DecideNo = 2,
    };
}
namespace app::TutorialGUI {
    enum VRAdjustMode {
        NORMAL = 0,
        CLOSE = 1,
        VERY_CLOSE = 2,
    };
}
namespace app::TutorialGUI {
    enum VRFixMenu {
        CRAFTBENCHINVENTORY = 4,
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
namespace app::UICommand {
    enum DircType {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    };
}
namespace app::UICommand {
    enum MouseConfirmType {
        Trigger = 0,
        Down = 1,
        Release = 2,
    };
}
namespace app::UICursor {
    enum TypeDef {
        Type1 = 0,
        Type2 = 1,
    };
}
namespace app::UITimer {
    enum CountTypeDef {
        CountUp = 0,
        CountDown = 1,
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
namespace app::VrGui {
    enum VrTrackRotModeDef {
        Billboard = 0,
        Billboard_YOnly = 1,
        TargetObjBillboard_YOnly = 2,
        None = 3,
    };
}
namespace app::VrGui {
    enum TargetTypeDef {
        ActiveCamera = 0,
        ActivePlayer = 1,
        Specify = 2,
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
namespace app::VrMotSickMeasureGui {
    enum TypeDef {
        None = 0,
        Type1 = 1,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum MainState {
        DEFAULT = 0,
        FADE_IN_BONUS = 1,
        FADE_IN_LIMIT = 2,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum TimePanelState {
        TIME_AM = 0,
        TIME_PM = 1,
    };
}
namespace app::WaveAnnouncementUIAsset {
    enum BonusPanelState {
        DEFAULT = 0,
        EVENT = 1,
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
namespace app::WaveAnnouncementUIAsset {
    enum ScorePanelState {
        DISABLE = 0,
        FADE_IN = 1,
    };
}
namespace app::WaveNotifyTimerUIDesc {
    enum Meridiem {
        AM = 0,
        PM = 1,
    };
}
namespace app::WaveNotifyTimerUI {
    enum CountContext {
        Countdown = 0,
        Countup = 1,
    };
}
namespace app::WaveTimerUIAsset {
    enum MainPanelState {
        DEFAULT = 0,
        FADE_OUT = 1,
    };
}
namespace app::WaveTimerUIAsset {
    enum TimePanelState {
        TIME_AM = 0,
        TIME_PM = 1,
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
namespace app::InteractEventAction {
    enum ProcessType {
        Stop = 0,
        Setup = 1,
        Interp = 2,
        Play = 3,
    };
}
namespace app::InteractEventActionMarker {
    enum Result {
        Success = 0,
        Failure = 1,
        Interacted = 2,
    };
}
namespace app::InterpolationJointGroup {
    enum StateType {
        None = 0,
        Setup = 1,
        Reset = 2,
    };
}
namespace app::ActiveControlBase {
    enum EventTypeEnum {
        None = 0,
        Main = 1,
    };
}
namespace app::GimmickActiveControl {
    enum EndTypeEnum {
        None = 0,
        SetNo = 1,
        Auto = 2,
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
namespace app::InteractDetailSearch {
    enum SearchEventRotAxis {
        X = 0,
        Y = 1,
        Z = 2,
    };
}
namespace app::InteractDetailSearch {
    enum SearchEventRotAxisSign {
        Plus = 0,
        Minus = 1,
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
namespace app::InteractLongPressSendFSM {
    enum ProcStep {
        LongPressWait = 0,
        Success = 1,
        InteractInterruption = 2,
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
namespace app::InteractNumberLock {
    enum NumberLockModeParam {
        Normal = 0,
        ForceError = 1,
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
namespace app::ItemCheckParam {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
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
namespace app::InteractPadlock {
    enum PadlockNumType {
        Num3 = 0,
        Num5 = 1,
    };
}
namespace app::InteractPushMove {
    enum PushMoveTypeEnum {
        Front = 0,
        Left = 1,
        Right = 2,
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
namespace app::InteractZoomSendFsm {
    enum ZoomState {
        NotStart = 0,
        Init = 1,
        MainMove = 2,
        Close = 3,
        Exit = 4,
    };
}
namespace app::VideoControl {
    enum VideoTypeDef {
        Normal = 0,
        TitleMovie = 1,
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
namespace app::MotionDelegate {
    enum Priority {
        High = 0,
        Middle = 1,
        Low = 2,
        Num = 3,
    };
}
namespace app::MotionDelegate {
    enum ExitModeEnum {
        OtherTag = 0,
        TransitionOfMotion = 1,
    };
}
namespace app::MovementController {
    enum Mode {
        Internal = 0,
        External = 1,
    };
}
namespace app::MovementController {
    enum SubAdjustType {
        None = 0,
        Position = 1,
        Rotation = 2,
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
namespace app::NightmareFrameOutIconData {
    enum Type {
        CraftBench = 0,
        Crusher = 1,
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
namespace app::ColorCorrectController {
    enum Type {
        Damage = 0,
        Zone = 1,
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
namespace app::CarInGarage {
    enum StampSetting {
        Normal = 0,
        Burn = 1,
        Burnt = 2,
        End = 3,
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
namespace app::CarInGarage {
    enum PushCharaControllerType {
        None = 0,
        Forward = 1,
        Reverse = 2,
    };
}
namespace app::CassettLabelPartsController {
    enum PartsNo {
        Normal = 0,
        Arabic = 1,
    };
}
namespace app::Crusher {
    enum State {
        PowerOff = 0,
        InProduction = 1,
        StopProduction = 2,
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
namespace app::DoorPush {
    enum OpenSide {
        Front = 0,
        Back = 1,
        Auto = 2,
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
namespace app::DoorPush {
    enum KnockType {
        None = 0,
        Immediately = 1,
        Delay = 2,
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
namespace app::Elevator {
    enum DoorAngleType {
        Front = 0,
        Back = 1,
    };
}
namespace app::ElevatorButton {
    enum LightState {
        LightOff = 0,
        LightOn = 1,
        SwitchOn = 2,
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
namespace app::GasBomb {
    enum Rno {
        Running = 0,
        Detonation = 1,
        Interval = 2,
        Exploded = 3,
        End = 4,
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
namespace app::Gunturret {
    enum Rno {
        Searching = 0,
        Detected = 1,
        Shooting = 2,
        Termination = 3,
        End = 4,
    };
}
namespace app::Gunturret {
    enum LampState {
        Sleep = 0,
        Searching = 1,
        Detected = 2,
    };
}
namespace app::ItemSelectReaction {
    enum Result {
        Success = 0,
        Failed = 1,
    };
}
namespace app::LucasTrapMessage {
    enum TrapType {
        Wire = 0,
        FakeBox = 1,
    };
}
namespace app::MapDoor {
    enum DoorState {
        DEFAULT = 0,
        UNLOCK = 1,
        LOCK = 2,
    };
}
namespace app::Oilcan {
    enum OilcanSetType {
        Oilcan = 0,
        FakeBox = 1,
    };
}
namespace app::PanelBoardHandle {
    enum State {
        Red = 0,
        Green = 1,
    };
}
namespace app::WetPlayer {
    enum Routine {
        Start = 0,
        WaitApply = 1,
        End = 2,
    };
}
namespace app::WetPlayer {
    enum Setting {
        Normal = 0,
        Wet = 1,
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
namespace app::WireTrapIMD {
    enum State {
        Wait = 0,
        WireHit = 1,
        Explosion = 2,
        Broken = 3,
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
namespace app::SampleShell {
    enum ShellType {
        Normal = 0,
        Homing = 1,
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
namespace app::StampController {
    enum SaveStateEnum {
        None = 0,
        Preparing = 1,
        Ready = 2,
    };
}
namespace app::StrikeController {
    enum Result {
        Normal = 0,
        Grapple = 1,
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
namespace app::Achievement {
    enum HeroStatsID {
        ClearGame = 0,
        KillEnemy = 1,
        GetItem = 2,
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
namespace app::Achievement {
    enum FoundFootageIndex {
        TVCrew = 0,
        RunawayMia = 1,
        PlayPuzzle = 2,
        Memory = 3,
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
namespace app::AdaptiveResolutionControl {
    enum ResolutionTypeEnum {
        FHD_1080 = 0,
        HD_900 = 1,
        HD_720 = 2,
        X68000_512 = 3,
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
namespace app::AIBeaconManager {
    enum Group {
        Vision = 0,
        Grapple = 1,
        Combat = 2,
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
namespace app::AsyncLoadManager {
    enum PriorityEnum {
        Primary = 0,
        Secondary = 1,
    };
}
namespace app::AsyncLoadManager {
    enum DisebleItemFolderTypeEnum {
        None = 0,
        Em8000_Battle = 1,
        Max = 2,
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
namespace app::BlackOutManager {
    enum FadeColorEnum {
        Black = 0,
        White = 1,
        Max = 2,
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
namespace app::SkillProperties {
    enum SkillType {
        RecoveryRateUp = 0,
        HealthMaxUp = 1,
        ReloadSpeedUp = 2,
        MoveSpeedUp = 3,
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
namespace app::FF030_Ex_ScreenControl {
    enum ScreenTypeEnum {
        Title = 0,
        EndCard = 1,
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
namespace app::FileData {
    enum SKUType {
        All = 0,
        Original = 1,
        CeroD_CeroZ = 2,
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
namespace app::GameManager {
    enum GameMode {
        Title = 0,
        Gameover = 1,
        NormalGame = 2,
        Extra00 = 3,
        Extra01 = 4,
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
namespace app::GameManager {
    enum Difficulty {
        Easy = 0,
        Normal = 1,
        Hard = 2,
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
namespace app::GameManager {
    enum MegusuriIconType {
        Yellow = 0,
        Red = 1,
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
namespace app::GameManager {
    enum GameOverPostRno {
        Wait = 0,
        BlinkStart = 1,
        End = 2,
    };
}
namespace app::GameManager {
    enum PlayerChangeType {
        Pl0000 = 0,
        Pl2000 = 1,
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
namespace app::GameManager {
    enum DlcEpisodeNo {
        Dlc1 = 1,
        Dlc2 = 2,
        Dlc3 = 3,
        Dlc4 = 4,
        AllNum = 5,
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
namespace app::GameManager {
    enum NowOnSaleState {
        None = 0,
        NotSale = 1,
        Sale = 2,
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
        networkPreInit = 15,
        networkPreInit2 = 16,
        networkInit = 17,
        networkInitWait = 18,
        httpClientInit = 19,
        httpClientInitWait = 20,
        npAuthCodeInit = 21,
        npAuthCodeReq = 22,
        npAuthCodeWait = 23,
        uwpTokenAndSignatureInit = 24,
        uwpTokenAndSignatureGet = 25,
        uwpTokenAndSignatureWait = 26,
        stAuthSessionTicketInit = 27,
        stAuthSessionTicketGet = 28,
        stAuthSessionTicketWait = 29,
        renetPost = 30,
        renetPostWait = 31,
        BrowserSetupContext = 32,
        BrowserSetup = 33,
        BrowserOpen = 34,
        BrowserOpenWait = 35,
        BrowserFinalize = 36,
        BrowserFinalizeContext = 37,
        SetupStorage = 38,
        StorageGetInfo = 39,
        StorageGetInfoWait = 40,
        StorageOpenWait = 41,
        StorageOpen = 42,
        StorageReadWait = 43,
        FinalizeContext = 44,
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
namespace app::GameManager {
    enum NetworkError {
        None = 0,
        NetworkInitFailed = 1,
    };
}
namespace app::GameManager {
    enum BrowserMode {
        Normal = 0,
        NetRanking55 = 1,
        StorePageUWP = 2,
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
        Village = 7,
    };
}
namespace app::HIDManager {
    enum InputMode {
        Pad = 0,
        MouseAndKeyboard = 1,
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
namespace app::HIDManager {
    enum MouseCursor {
        Hide = 0,
        Show = 1,
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
namespace app::Inventory {
    enum AddItemResult {
        Put = 0,
        Integration = 1,
        IntegrationAndNoPut = 2,
        NoPut = 3,
        LimitOver = 4,
    };
}
namespace app::Inventory {
    enum ExtendLvDef {
        Lv1 = 0,
        Lv2 = 1,
        Lv3 = 2,
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
namespace app::InventoryManager {
    enum QuickEquipSlotNo {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
        None = 4,
    };
}
namespace app::ItemSlotManager {
    enum StateType {
        Normal = 0,
        ItemMove = 1,
    };
}
namespace app::ItemSlotData {
    enum FindSlotType {
        Normal = 0,
        LowPriorityShortcut = 1,
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
namespace app::LightConditionManager {
    enum ProbesTypeEnum {
        InSide = 0,
        OutSide = 1,
        Max = 2,
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
namespace app::PadManager {
    enum PadNo {
        Pad1 = 0,
        Pad2 = 1,
        PadMax = 2,
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
namespace app::RewardData {
    enum GameMode {
        Main = 0,
        BirthdayGame = 1,
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
namespace app::Richpresence {
    enum DLCContextType {
        DLC1 = 0,
        DLC2 = 1,
        Invalid = -1,
    };
}
namespace app::Richpresence {
    enum CH9ProgressType {
        InGame = 0,
        Menu = 1,
        Invalid = -1,
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
namespace app::Richpresence {
    enum ProcessType {
        Idle = 0,
        Requested = 1,
        RequestWaiting = 2,
        Normal = 3,
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
namespace app::SaveDataManager {
    enum RestartFadeTypeEnum {
        Default = 0,
        WaitFadeInTimeSet = 1,
        NoFadeIn = 2,
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
namespace app::SceneActivater {
    enum SafeLoadStepEnum {
        WaiteActiveList = 0,
        WaiteStandbyList = 1,
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
namespace app::Telemetry {
    enum ClearTimeTypeDLC {
        CrazyHouse = 0,
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
    };
}
namespace app::VolumeDecalContainer {
    enum Type {
        Blood = 0,
        Scar = 1,
        Water = 2,
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
namespace app::VrLightEffectiveRangeController {
    enum LightType {
        PointLight = 0,
        SpotLight = 1,
        IESLight = 2,
    };
}
namespace app::Bomb {
    enum UpdateRno {
        Wait = 0,
        Explosion = 1,
        Sleep = 2,
    };
}
namespace app::Bomb {
    enum ParentType {
        None = 0,
        Transform = 1,
        Joint = 2,
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
namespace app::WeaponChainSaw {
    enum LampState {
        Unknown = 0,
        Run = 1,
        Caution = 2,
        Stall = 3,
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
namespace app::WeaponGun {
    enum BulletTypeSwitch {
        Normal = 0,
        Strong = 1,
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
namespace app::WwiseFrontSpeakerAngle {
    enum Device {
        StereoSpeaker = 0,
        StereoHeadphone = 1,
        Surround = 2,
        None = 3,
    };
}
namespace app::WwisePrefabInitiationTriggerElement {
    enum DeleteTypeEnum {
        Trigger = 0,
        Timer = 1,
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
namespace app::CH8Em4000ActionController {
    enum DestinationType {
        ChangeThink = 0,
        SelfKill = 1,
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
namespace app::CH8Em4000Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace app::CH8Em4000Grapple {
    enum AttackType {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH8Em4090Grapple {
    enum AttackType {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH8Em4100ActionController {
    enum MoveType {
        Default = 0,
        ForceSolo = 1,
        ForceAround = 2,
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
namespace app::CH8Em4100ActionController {
    enum BackstepQueType {
        Back = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::CH8Em4100ActionController {
    enum DodgeQueType {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH8Em4200ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
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
namespace app::CH8Em4400ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
    };
}
namespace app::CH8Em4400BulletBaby {
    enum Status {
        Enable = 0,
        Desable = 1,
    };
}
namespace app::CH8Em4500ActionController {
    enum ModeMotionStatus {
        Small = 0,
        Change = 1,
        Big = 2,
    };
}
namespace app::CH8Em4500AimEvaluatorMarker {
    enum MarkerPartsType {
        Head = 0,
        Body = 1,
    };
}
namespace app::CH8Em4500CoreGuard {
    enum CoreStetus {
        Default = 0,
        Close = 1,
        Open = 2,
    };
}
namespace app::CH8Em4500GeneratePoint {
    enum Order {
        None = 0,
        Generate = 1,
    };
}
namespace app::CH8Em4500QuickJumpNavigation {
    enum NavigationStatus {
        Stop = 0,
        Active = 1,
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
namespace app::CH8PlayerGrowthManager {
    enum SiteScope {
        TypeA = 0,
        TypeB = 1,
        TypeC = 2,
    };
}
namespace app::CH8_EffectChainMeshAnim {
    enum PlayTypeEnum {
        Once = 0,
        Loop = 1,
        Pause = 2,
    };
}
namespace app::CH8FadeControl {
    enum FadeStatusEnum {
        OffBlack = 0,
        OnBlack = 1,
    };
}
namespace app::CH8FadeControl {
    enum FadeRequestEnum {
        None = 0,
        FadeIn = 1,
        FadeOut = 2,
    };
}
namespace app::CH8FadeControlForEvent {
    enum FadeStatusEnum {
        OffBlack = 0,
        OnBlack = 1,
    };
}
namespace app::CH8FadeControlForEvent {
    enum FadeRequestEnum {
        None = 0,
        FadeIn = 1,
        FadeOut = 2,
    };
}
namespace app::CH8HUDControl {
    enum VrGaugeDisableFlag {
        QUICK_EQUIP_FLAG = 1,
        MESSAGE_FLAG = 2,
    };
}
namespace app::CH8HUDControl {
    enum Monster {
        Mather = 0,
        WhiteMoldead = 1,
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
namespace app::CH8MainMenu {
    enum MainMenu {
        NewGame = 0,
        Continue = 1,
        LoadGame = 2,
        Quit = 3,
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
namespace app::CH8SaveMenu {
    enum ModeDef {
        LoadTitleMenu = 0,
        LoadInGame = 1,
        SaveInGame = 2,
        FirstSystemSave = 3,
    };
}
namespace app::CH8SaveMenu {
    enum ListElemID {
        Restart = 0,
        End = 1,
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
namespace app::CH8SettingSkill_Item {
    enum Process {
        Idle = 0,
        DLC_Init = 1,
        DLC_update = 2,
        DLC_update_1 = 3,
        End = 4,
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
namespace app::CH8GetEventItem {
    enum Process {
        WaitInteract = 0,
        WaitDailog = 1,
        WaitDailog2 = 2,
        End = 3,
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
namespace app::CH8NightVisionTrigger {
    enum Mode {
        TriggerOnlyUseNightVision = 0,
        TriggerOnlyNoHasNightVision = 1,
    };
}
namespace app::CH8ChangeFogParamProxy {
    enum REQUEST_MODE {
        NONE = 0,
        NORMAL = 1,
        NIGHT_VISION = 2,
    };
}
namespace app::CH8ChangeToneMapProxy {
    enum REQUEST_MODE {
        NONE = 0,
        NORMAL = 1,
        NIGHT_VISION = 2,
    };
}
namespace app::CH8ChangeToneMapProxy {
    enum STATUS_FLAG {
        INITIALIZE = 1,
        AUTONIGHT_VISION = 2,
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
namespace app::CH8InfraredTrap {
    enum CoreState {
        Wait = 0,
        Explosion = 1,
        Broken = 2,
    };
}
namespace app::CH8InfraredTrap {
    enum WireState {
        Invisible = 0,
        Visible = 1,
        Disable = 2,
    };
}
namespace app::CH8InfraredTrap {
    enum LampState {
        On = 0,
        Off = 1,
    };
}
namespace app::CH8ItemDrop {
    enum PropType {
        None = 0,
        RigidBodyDestruct = 1,
    };
}
namespace app::CH8Oilcan2 {
    enum OilcanSetType {
        Oilcan = 0,
        FakeBox = 1,
    };
}
namespace app::CH8TramPuzzle {
    enum ColliderIndex {
        Marker_Front = 2,
        Marker_Back = 3,
        Sensor = 4,
    };
}
namespace app::CH8TramPuzzleSensor {
    enum SensorType {
        Disable = 0,
        Stop = 1,
        Barricade = 2,
    };
}
namespace app::CH8Achievement {
    enum AchievementIndex {
        Achievement_0 = 57,
        Achievement_1 = 58,
    };
}
namespace app::CH8CheckSceneFolder {
    enum ControlTypeEnum {
        isActivate = 0,
        MAX = 1,
    };
}
namespace app::CH8CheckOnlySceneFolder {
    enum CheckTypeEnum {
        isActivate = 0,
        isDeactivate = 1,
        MAX = 2,
    };
}
namespace app::CH8GameManager {
    enum Difficulty {
        Casual = 0,
        Normal = 1,
        Hard = 2,
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
namespace app::CH8OperatorManager2 {
    enum CaseTable {
        Failure = 0,
        Success = 1,
        Forced = 2,
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
namespace app::CH8SaveManager {
    enum SaveSlotTextType {
        SLOT_TEXT_DIFFICULTY = 0,
        SLOT_TEXT_PLAY_TIME = 1,
        SLOT_TEXT_PLACE = 2,
        SLOT_TEXT_OBJECTIVE = 3,
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
namespace app::CH8SaveManager {
    enum AreaCompartmentStep {
        SlatMineArea = 0,
        Mine01_Battle = 1,
        LuacsLand = 2,
        ShieldMachine = 3,
        Labo = 4,
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
namespace app::CH8Telemetry {
    enum TimerType {
        CH8BossBattle = 0,
        CH8AllClear = 1,
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
namespace app::CH8ShellManager {
    enum GrenadeType {
        Grenadebomb = 0,
        Thermatebomb = 1,
        Stangrenadebomb = 2,
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
namespace app::CH8CheckHitToBalloon {
    enum ConditionTable {
        SphereToSphere = 0,
        SphereToPoint = 1,
    };
}
namespace app::CH8HandgunBulletSound {
    enum CHP8_HandgunBullet {
        Normal = 1,
        Strong = 2,
    };
}
namespace app::CH8PlayerDeathSound {
    enum DeathTable {
        silence = 0,
        death_roar = 1,
        death_end = 2,
    };
}
namespace app::CH8PlayerSwingingSound {
    enum StompTable {
        silence = 0,
        stomp_hit = 1,
        stomp_miss = 2,
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
namespace app::CH8StateSwitchBtlMolded {
    enum CHP8_BTL_MOLDED {
        SILENCE = 0,
        ENCOUNT = 1,
        BATTLE = 2,
        LOST_PL = 3,
        EM4400_DEAD = 4,
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
namespace app::CH8StateSwitchExploreTheArea {
    enum CHP8_EXPLORE_THE_AREA {
        safety = 0,
        contamination = 1,
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
namespace app::CH8StateSwitchM2 {
    enum CHP8_2 {
        SILENCE = 0,
        CHP8_EM4600_BT_MINING = 1,
        CHP8_EM4600_BT_END_MINING = 2,
        CHP8_EM4400_BT_MINING = 3,
        CHP8_EM4400_BT_END_MINING = 4,
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
namespace app::CH8StateSwitchM6 {
    enum CHP8_6 {
        SILENCE = 0,
        BGM_CHP8_STORAGE_01 = 1,
        BGM_CHP8_STORAGE_01_END = 2,
        BGM_CHP8_STORAGE_EXPLORE = 3,
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
namespace app::CH8StateSwitchM8 {
    enum CHP8_8 {
        SILENCE = 0,
        BGM_CHP8_LABO_EVENT = 1,
        BGM_CHP8_LABO_EVENT_AREA_END = 2,
        BGM_CHP8_LABO_EVENT_TEXT_END = 3,
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
namespace app::CH8StateSwitchMission {
    enum CHP8_MISSION {
        SILENCE = 0,
        CHP8_SILENCE_MINE = 1,
        CHP8_MINING_AREA = 2,
        CHP8_STORAGE_AREA = 3,
        CHP8_TRAIN_AREA = 4,
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
namespace app::CH8Em4200ActionPoint {
    enum Type {
        DropPoint = 0,
    };
}
namespace app::CH8Em4200Message {
    enum Tag {
        FirstLiquidBomb = 0,
    };
}
namespace app::CH8Em4400ActionPoint {
    enum Type {
        DropPoint = 0,
    };
}
namespace app::CH8Em4400Message {
    enum Tag {
        FirstLiquidBomb = 0,
    };
}
namespace app::CH8PlayerDefine {
    enum ExternalShakeType {
        LandShake = 2000,
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
namespace app::MissionDetail {
    enum Category {
        Main = 0,
        Sub = 1,
        Other = 2,
    };
}
namespace app::MissionDetail {
    enum DifficultyBits {
        Casual = 1,
        Normal = 2,
        Hard = 4,
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
namespace app::CH8RewardArticle {
    enum DifficultyBits {
        Casual = 1,
        Normal = 2,
        Hard = 4,
    };
}
namespace app::CH8RewardArticle {
    enum Category {
        Item = 0,
        Weapon = 1,
        PowerUp = 2,
    };
}
namespace app::CH8TipsData {
    enum DifficultyBits {
        Casual = 1,
        Normal = 2,
        Hard = 4,
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
namespace app::CH9Em5700Think {
    enum Mode {
        Ground = 0,
        Fly = 1,
    };
}
namespace app::CH9Em5800ActionController {
    enum Size {
        Small = 0,
        Middle = 1,
        Large = 2,
    };
}
namespace app::CH9Em5800Think {
    enum ThinkMode {
        Normal = 0,
        NoThink = 1,
        Passive = 2,
    };
}
namespace app::CH9Em5800Think {
    enum BreakState {
        None = 0,
        FirstBreak = 1,
        SecondBreak = 2,
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
namespace app::CH9Em5850FollowBug {
    enum BankId {
        Basic = 10,
        Attack = 20,
        Damage = 30,
    };
}
namespace app::CH9Em6400ActionController {
    enum MoveMode {
        Default = 0,
        Fast = 1,
        Slow = 2,
    };
}
namespace app::CH9Em6400ActionController {
    enum RushState {
        Normal = 0,
        Anger = 1,
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
namespace app::CH9Em6400ActionController {
    enum AppealAwakenState {
        None = 0,
        Action = 1,
        End = 2,
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
namespace app::CH9Em6400ActionController {
    enum MiddleActionType {
        StepInCommon = 0,
        GuardFollow = 1,
        Max = 2,
        None = -1,
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
namespace app::CH9Em6400ActionController {
    enum CH92BattleWwiseState {
        ENCOUNT = 0,
        LOST_PL = 1,
    };
}
namespace app::CH9Em6400ActionController {
    enum WwiseSwitchListForDamage {
        Head = 0,
        Other = 1,
    };
}
namespace app::CH9Em6400ArmController {
    enum ArmType {
        Default = 0,
        Extend = 1,
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
namespace app::CH9Em6400ArmController {
    enum EntryEffectId {
        ChangeExtendShort = 0,
        ChangeEnd = 1,
        Cancel = 2,
    };
}
namespace app::CH9Em6400HeadController {
    enum InsectMotionState {
        Sleep = 0,
        Active = 1,
    };
}
namespace app::CH9Em6400HeadController {
    enum InsectMotionOrder {
        None = 0,
        Play = 1,
        Stop = 2,
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
namespace app::CH9Em6400Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
    };
}
namespace app::CH9Em6400Grapple {
    enum LerpScaleMode {
        LerpGrappleScale = 0,
        LerpOriginalScale = 1,
        None = 2,
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
namespace app::CH9Em6800 {
    enum eMotionBankID {
        Base = 0,
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
namespace app::CH9Em7500ActionController {
    enum SuspendStatus {
        None = 0,
        Requested = 1,
        Suspending = 2,
        Completed = 3,
    };
}
namespace app::CH9Em7500ActionController {
    enum DivingType {
        ToAppear = 0,
        Suspend = 1,
        SelfDie = 2,
    };
}
namespace app::CH9Em7500Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace app::CH9Em7550Think {
    enum eMotionState {
        Idle = 0,
        Attack = 1,
    };
}
namespace app::CH9Em7700ActionController {
    enum DestinationType {
        ChangeThink = 0,
        SelfKill = 1,
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
namespace app::CH9Em7700Order {
    enum OrderType {
        WarpTo = 0,
    };
}
namespace app::CH9Em7700DebugController {
    enum HandStatus {
        Normal = 0,
        Blade = 1,
        Lost = 2,
    };
}
namespace app::CH9Em7800ActionController {
    enum MoveType {
        Default = 0,
        ForceSolo = 1,
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
namespace app::CH9Em7800ActionController {
    enum BackstepQueType {
        Back = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::CH9Em7800ActionController {
    enum DodgeQueType {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH9Em7900ActionController {
    enum AngerStatus {
        Normal = 0,
        NeedAnger = 1,
        Anger = 2,
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
namespace app::CH9MoldedActionController {
    enum DodgeVariation {
        Left = 0,
        LeftBack = 1,
        Right = 2,
        RightBack = 3,
    };
}
namespace app::CH9MoldedActionController {
    enum Tension {
        Normal = 0,
        Excite = 1,
        Anger = 2,
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
namespace app::CH9MoldedActionController {
    enum WwiseSwitchListForDamage {
        Head = 0,
        Other = 1,
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
namespace app::CH9PlayerEquipManager {
    enum WwiseSwitchListForEquipGauntlet {
        None = 0,
        LeftOnly = 1,
        Both = 2,
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
namespace app::CH9EPVExpertKnuckleLandingData {
    enum ZDirectionType {
        AttackDirection = 0,
        SawRotation = 1,
    };
}
namespace app::CH9Credit {
    enum StepType {
        Logo = 0,
        Page = 1,
    };
}
namespace app::CH9DifficultySelectGUI {
    enum StepType {
        Wait = 0,
        Decide = 1,
        Cancel = 2,
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
namespace app::CH9MainMenu {
    enum CallSe {
        Cursol = 0,
        Decide = 1,
        Cancel = 2,
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
namespace app::CH9MultiSubMenu {
    enum CH9TabTypeDef {
        Album = 0,
        Map = 1,
    };
}
namespace app::CH9Record {
    enum EverywhereElement {
        Everywhere = 8,
        EverywhereHard = 9,
        Max = 10,
    };
}
namespace app::CH9SaveMenu {
    enum ModeType {
        Load = 0,
        Save = 1,
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
namespace app::CH9TimeAttackTimerHUD {
    enum StepType {
        Display = 0,
        Count = 1,
        End = 2,
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
namespace app::CH9SM2644Movement {
    enum CollisionID {
        PressNormal = 0,
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
namespace app::CH9SM2644Movement {
    enum eMotionLayer {
        Base = 0,
        Inertia = 1,
        Damage = 2,
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
namespace app::CH9SM2644Movement {
    enum eEngineState {
        Stop = 0,
        Driving = 1,
    };
}
namespace app::CH9SM2644Movement {
    enum eGearState {
        Front = 0,
        Back = 1,
    };
}
namespace app::CH9Bomb {
    enum BombSetType {
        Oilcan = 0,
        FakeBox = 1,
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
namespace app::CH9WireTrap {
    enum State {
        Wait = 0,
        WireHit = 1,
        Explosion = 2,
        Broken = 3,
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
namespace app::CH9EverywhereManager {
    enum MissionType {
        TimeAttack = 0,
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
namespace app::CH9RewardManager {
    enum ClearType {
        CasualClear = 0,
        NormalClear = 1,
        HardClear = 2,
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
namespace app::CH9Telemetry {
    enum UseRewardPattern {
        RingBattle = 0,
        BossBattle = 1,
        ThroughPlay = 2,
        Max = 3,
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
namespace app::CH9InstallationWp1900 {
    enum eInstallationType {
        OnGround = 0,
        OnWater = 1,
        OnShallowWater = 2,
        OnBrokenFloor = 3,
        OnBoat = 4,
    };
}
namespace app::CH9KnuckleBullet {
    enum UpdateRno {
        Stomp = 0,
        AttackBack = 1,
        Sleep = 2,
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
namespace app::CH9ShellManager {
    enum ForceSleepType {
        ActiveAll = 0,
        OnBrokenFloorOnly = 1,
    };
}
namespace app::CH9ThrowingWeaponBase {
    enum ParentType {
        None = 0,
        Transform = 1,
        Joint = 2,
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
namespace app::CH9ThrowingWp1800 {
    enum eHitWallType {
        None = 0,
        Wall = 1,
        Door = 2,
        BrokenFloor = 3,
    };
}
namespace app::CH9WeaponThrowable {
    enum eUseType {
        Equip = 0,
        Throwing = 1,
    };
}
namespace app::CH9WeaponWwiseStateList {
    enum SndSwitch_enhanceType {
        NORMAL = 0,
        ENHACE = 1,
        ROT = 2,
    };
}
namespace app::Ch9AccelerationControl {
    enum eStatus {
        Stop = 0,
        Acceleration = 1,
        Deceleration = 2,
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
namespace app::CH9Em7900ActionPoint {
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
namespace app::CH9GauntletChargeGauge {
    enum eHandType {
        Left = 0,
        Right = 1,
        Max = 2,
    };
}
namespace app::CH9GauntletChargeGauge {
    enum eChargeHand {
        OneHnad = 0,
        BothHnads = 1,
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
namespace app::ShallowWaterMaterialControl {
    enum BoatType {
        Boat01 = 0,
        Boat02 = 1,
        Max = 2,
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
namespace app::CH9StartCheck {
    enum ResultType {
        Checking = 0,
        ReturnExtraContents = 1,
        StartMainMenu = 2,
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
namespace app::CH9EverywhereMissionBase {
    enum Progress {
        Idle = 0,
        Start = 1,
        End = 2,
    };
}
namespace app::CH9EverywhereData {
    enum Type {
        Item = 0,
        Weapon = 1,
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
namespace app::DebugRecordRequest {
    enum Type {
        Attacker = 0,
        Victim = 1,
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
namespace app::TestMovement {
    enum MovementType {
        PositionLine = 0,
        PositionRoll = 1,
        RotationLine = 2,
        RotationRoll = 3,
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
namespace app::EnvironmentEffectManager {
    enum RequestStatus {
        None = 0,
        Create = 1,
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
namespace app::EPVDataBase {
    enum RotateBase {
        ParentJoint = 0,
        ModelNull = 1,
    };
}
namespace app::EffectCommonDefine {
    enum EffectEndType {
        Kill = 0,
        Finish = 1,
    };
}
namespace app::EffectCommonDefine {
    enum EffectActionOnProviderDestroy {
        None = 0,
        Finish = 1,
        Kill = 2,
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
namespace app::CharacterDefine {
    enum Type {
        Player = 0,
        Enemy = 1,
        Npc = 2,
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
namespace app::CharacterDefine {
    enum Vitality {
        Full = 0,
        Normal = 1,
        Weak = 2,
        Dying = 3,
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
namespace app::CharacterDefine {
    enum Hand {
        Right = 0,
        Left = 1,
        Both = 2,
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
namespace app::Em4200ActionPoint {
    enum Type {
        DropPoint = 0,
    };
}
namespace app::Em4200Message {
    enum Tag {
        FirstLiquidBomb = 0,
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
namespace app::EnemyMessage {
    enum Tag {
        CounterableForGrapple = 0,
        CounterableBombForGrapple = 1,
        ResistableForGrapple = 2,
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
namespace app::EnemySlipParameter {
    enum Type {
        Fire = 0,
        Acid = 1,
        Invalid = -1,
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
namespace app::PlayerDefine {
    enum TouchType {
        None = 0,
        Wall = 1,
        Door = 2,
        EndImmediately = 3,
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
namespace app::PlayerDefine {
    enum ExternalShakeRequester {
        ScriptOrFSM = 0,
        Effect = 1,
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
namespace app::PlayerDefine {
    enum DamageEffectDisableLayer {
        Event = 1,
        GameOver = 2,
        Fsm = 4,
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
namespace app::PlayerUpperVerticalRotateParameter {
    enum ActionType {
        Normal = 0,
        Aim = 1,
        Unknown = 2,
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
namespace app::Cp7AchievementDataControl {
    enum VrTrackingType {
        InGame = 0,
        EndGame = 1,
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
namespace app::DLC1VideoCameraUI {
    enum ModeDef {
        Start = 0,
        NoiseAnim = 1,
        Close = 2,
        StartEnding = 3,
        CloseEnding = 4,
    };
}
namespace app::ControlMaterial {
    enum ParamType {
        Float4 = 1,
        Float = 2,
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
namespace app::WaveEndDesc {
    enum Type {
        Continue = 0,
        Last = 1,
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
namespace app::GameFlowEndNode {
    enum EndTypeEnum {
        Noraml = 0,
        After = 1,
        Max = 2,
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
namespace app::CheckSceneFolder {
    enum ControlTypeEnum {
        isActivate = 0,
        MAX = 1,
    };
}
namespace app::VideoCameraUIDisp {
    enum Switch {
        ON = 0,
        OFF = 1,
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
namespace app::StaffRollData {
    enum SKUType {
        All = 0,
        WW = 1,
        JP = 2,
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
namespace app::MathEx {
    enum SliceType {
        Round = 0,
        Pizza = 1,
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
namespace app::PosLerp {
    enum State {
        LerpPos = 0,
        LerpRot = 1,
        LerpLocalPos = 2,
        LerpLocalRot = 3,
        Num = 4,
    };
}
namespace app::TinyTimer {
    enum Mode {
        None = 0,
        Up = 1,
        Down = 2,
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
namespace app::Cp7NightmareReward {
    enum Type {
        CraftItem = 0,
        JumkBonus = 1,
        ItemBonus = 2,
        CraftTrap = 3,
    };
}
namespace app::ReliefItemTable {
    enum TableType {
        Normal = 0,
    };
}
namespace app::wwise::WwiseOptionMenu {
    enum DynamicRangeControl {
        Small = 0,
        Large = 1,
    };
}
namespace app::wwise::WwiseOptionMenu {
    enum Speaker {
        TV = 0,
        Headphone = 1,
        Surround = 2,
    };
}
namespace app::wwise::WwiseOptionMenu {
    enum VirtualSurround {
        NoUse = 0,
        Use = 1,
    };
}
namespace app::RecordSystem::RecordOrder {
    enum OrderTypeEnum {
        Stamp = 1,
        Decal = 2,
        StampAndDecal = 3,
    };
}
namespace app::FsmBirthday::FirstTutorial {
    enum OpTypeEnum {
        CheckFlag = 0,
        SetFlag = 1,
        Max = 2,
    };
}
namespace app::CH9Em7900::ThinkOrderSet {
    enum Type {
        None = 0,
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
namespace app::CH9Em7900::ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
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
namespace app::CH9Em7900::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH9Em7900::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
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
namespace app::CH9Em7900::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH9Em7900::Action::Grapple {
    enum Type {
        Mount = 0,
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
namespace app::CH9Em7900::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH9Em7900::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace app::CH9Em7900::Action::FinishBlow {
    enum Type {
        SneakB = 0,
    };
}
namespace app::CH9Em7800::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH9Em7800::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
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
namespace app::CH9Em7800::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH9Em7800::Action::WanderIdle {
    enum Type {
        Normal = 0,
    };
}
namespace app::CH9Em7800::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::CH9Em7800::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace app::CH9Em7800::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
        Air = 2,
    };
}
namespace app::CH9Em7800::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace app::CH9Em7800::Action::Grapple {
    enum Type {
        Thrust = 0,
    };
}
namespace app::CH9Em7800::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH9Em7800::Action::FinishBlow {
    enum Type {
        SneakB = 0,
    };
}
namespace app::CH9Em7700::ThinkOrderSet {
    enum Type {
        None = 0,
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
namespace app::CH9Em7700::ThinkAppearSet {
    enum MimicryType {
        Floor1 = 0,
        Floor2 = 1,
        Lean1 = 2,
        Lean2 = 3,
        Lean3 = 4,
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
namespace app::CH9Em7700::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH9Em7700::Action::WanderIdle {
    enum Type {
        Normal = 0,
    };
}
namespace app::CH9Em7700::Action::Move {
    enum Type {
        Normal = 0,
        Destination = 1,
        Wanderer = 2,
    };
}
namespace app::CH9Em7700::Action::Move {
    enum CrawlMode {
        Wait = 0,
        Walk = 1,
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
namespace app::CH9Em7700::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH9Em7700::Action::Grapple {
    enum Type {
        Bite = 0,
        Mount = 1,
        Slash = 2,
    };
}
namespace app::CH9Em7700::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace app::CH9Em7700::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH9Em7700::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
        ForceSpin = 2,
    };
}
namespace app::CH9Em7700::Action::FinishBlow {
    enum Type {
        SneakB = 0,
        FinishblowL = 1,
        FinishblowR = 2,
    };
}
namespace app::CH9Em7500::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH9Em7500::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
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
namespace app::CH9Em7500::Action::Idle {
    enum Type {
        Normal = 0,
        Homing = 1,
    };
}
namespace app::CH9Em7500::Action::Dive {
    enum Type {
        Normal = 0,
        Into = 1,
    };
}
namespace app::CH9Em7500::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::CH9Em7500::Action::Grapple {
    enum Type {
        SneakB = 0,
        DeathRoll = 1,
        DeathEscape = 2,
    };
}
namespace app::CH9Em7500::Action::Suspend {
    enum Type {
        Normal = 0,
        SelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH9Em7500::Action::Dead {
    enum Type {
        Normal = 0,
        Air = 1,
    };
}
namespace app::CH9Em7500::Evaluator::CheckRangeFromJoint {
    enum Type {
        Simple = 0,
        NormalizedRateScore = 1,
        RateScore = 2,
    };
}
namespace app::CH9Em6700::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH9Em6700::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
    };
}
namespace app::CH9Em6700::ThinkAppearSet {
    enum Type {
        Default = 0,
        Surface = 10,
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
namespace app::CH9Em6700::Action::Idle {
    enum Type {
        Normal = 0,
        Homing = 1,
    };
}
namespace app::CH9Em6700::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::CH9Em6700::Action::Grapple {
    enum Type {
        SneakB = 0,
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
namespace app::CH9Em6400::ThinkAppearSet {
    enum Type {
        Default = 0,
        Chapter92Battle = 200,
        Chapter92BattleFinal = 300,
        Chapter94BattleFinal = 500,
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
namespace app::CH9Em6400::Action::Walk {
    enum Type {
        Normal = 0,
        TNormal = 1,
    };
}
namespace app::CH9Em6400::Action::Confront {
    enum Type {
        Idle = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::CH9Em6400::Action::Guard {
    enum Type {
        Idle = 0,
    };
}
namespace app::CH9Em6400::Action::Turn {
    enum Type {
        Idle = 0,
        Move = 1,
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
namespace app::CH9Em6400::Action::Step {
    enum StepCorrectionDirection {
        None = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::CH9Em6400::Action::GuardFollow {
    enum Type {
    };
}
namespace app::CH9Em6400::Action::Appeal {
    enum Type {
        Type00 = 0,
        Type01 = 1,
        Type02 = 2,
    };
}
namespace app::CH9Em6400::Action::AppealAwaken {
    enum Type {
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
namespace app::CH9Em6400::Action::AttackBack {
    enum Type {
        PunchBR = 0,
        PunchBL = 1,
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
namespace app::CH9Em6400::Action::AttackToGrapple {
    enum Type {
        None = 0,
        CommonGrab = 1,
        CommonGrabSp = 2,
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
namespace app::CH9Em6400::Evaluator::CheckRangeFromJoint {
    enum Type {
        Simple = 0,
        NormalizedRateScore = 1,
        RateScore = 2,
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
namespace app::CH9Em5850::Action::Appear {
    enum Type {
        Born = 0,
        Gather = 1,
        Call = 2,
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
namespace app::CH9Em5800::Action::Generate {
    enum Type {
        Em5700 = 0,
        Em5850 = 1,
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
namespace app::CH9Em5700::Action::FlyMove {
    enum Type {
        Normal = 0,
        LookTarget = 1,
    };
}
namespace app::CH9Em5700::Action::GroundMove {
    enum Type {
        Normal = 0,
        Reaction = 1,
    };
}
namespace app::CH9Em5700::Action::Dead {
    enum Type {
        Fall = 0,
        Disperse = 1,
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
namespace app::CH9Em5700::Action::Damage {
    enum Type {
        DamageS = 0,
        DamageFlyS_L = 1,
        DamageFlyS_R = 2,
        DamageLGround = 3,
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
namespace app::CH9Em5700::Action::Grapple {
    enum Type {
        Stab = 0,
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
namespace app::CH9Em5700::Goal::SideMove {
    enum MoveDirect {
        Left = 0,
        Right = 1,
    };
}
namespace app::CH9Em5700::Goal::Attack {
    enum Type {
        Stab = 0,
        Strike = 1,
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
namespace app::CH8Em4500::CH8ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH8Em4500::CH8ThinkStateSet {
    enum Type {
        Default = 0,
        Wait = 1,
    };
}
namespace app::CH8Em4500::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        Stand = 1,
        Fall = 2,
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
namespace app::CH8Em4500::Action::CH8Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
    };
}
namespace app::CH8Em4500::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4500::Action::CH8Grapple {
    enum Type {
        Mount = 0,
    };
}
namespace app::CH8Em4500::Action::CH8ConsecutiveStrike {
    enum ConboType {
        Two = 0,
        Four = 1,
    };
}
namespace app::CH8Em4500::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4500::Action::CH8StrikeToParry {
    enum StrikeType {
        Right = 0,
        Left = 1,
    };
}
namespace app::CH8Em4500::Action::CH8Jump {
    enum Jumptype {
        None = -1,
        Normal = 0,
    };
}
namespace app::CH8Em4500::Action::CH8Swoon {
    enum SwoonType {
        Default = 0,
        Quick = 1,
    };
}
namespace app::CH8Em4500::Action::CH8BackWalk {
    enum BackWalkType {
        Standard = 0,
        RequestNextAction = 1,
    };
}
namespace app::CH8Em4500::Action::CH8JumpUp {
    enum JumpType {
        Normal = 0,
        ModeChange = 1,
        ModeRunaway = 2,
    };
}
namespace app::CH8Em4500::Action::CH8ThreatOneShot {
    enum ThreatType {
        Small = 0,
        Big = 1,
    };
}
namespace app::CH8Em4450::CH8Em4450ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH8Em4450::CH8Em4450ThinkStateSet {
    enum Type {
        Default = 0,
        Wait = 1,
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
namespace app::CH8Em4450::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4450::Action::CH8Grapple {
    enum Type {
        Exprotion = 0,
    };
}
namespace app::CH8Em4450::Action::CH8Avoidance {
    enum AvoidanceType {
        Right = 0,
        Left = 1,
    };
}
namespace app::CH8Em4450::Action::CH8ParryStagger {
    enum AvoidanceType {
        Right = 0,
        Left = 1,
    };
}
namespace app::CH8Em4450::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Em4400::CH8ThinkOrderSet {
    enum Type {
        None = 0,
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
namespace app::CH8Em4400::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
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
namespace app::CH8Em4400::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Grapple {
    enum Type {
        Mount = 0,
        AllFoursSmash = 1,
    };
}
namespace app::CH8Em4400::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
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
namespace app::CH8Em4400::Action::CH8Generate {
    enum GenerateState {
        Start = 0,
        Loop = 1,
        End = 2,
        Chancel = 3,
        RequestEnd = 4,
    };
}
namespace app::CH8Em4400::Action::CH8Generate {
    enum AddLayerState {
        Default = 0,
        Generating = 1,
        Break = 2,
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
namespace app::CH8Em4400::Action::CH8Generate {
    enum GeneratePosition {
        Head = 0,
        Chest = 1,
        Stomach = 2,
        Thigh = 3,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum StateTable {
        Start = 0,
        Loop = 1,
        End = 2,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum SmallDamageReactionTable {
        Small_v1 = 0,
        Small_v2 = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum LargeDamageReactionTable {
        Large_F = 1000,
        Large_L = 1001,
        Large_R = 1002,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum TutorialLineTable {
        ON = 0,
        OFF = 1,
    };
}
namespace app::CH8Em4400::Action::CH8Kneel {
    enum RequestType {
        Normal = 0,
        Force = 1,
    };
}
namespace app::CH8Em4200::CH8ThinkOrderSet {
    enum Type {
        None = 0,
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
namespace app::CH8Em4200::CH8ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
        EventAttack = 3,
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
namespace app::CH8Em4200::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH8Em4200::Action::CH8Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
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
namespace app::CH8Em4200::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Em4200::Action::CH8Grapple {
    enum Type {
        Mount = 0,
    };
}
namespace app::CH8Em4200::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4200::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4200::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4100::CH8ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::CH8Em4100::CH8ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
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
namespace app::CH8Em4100::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH8Em4100::Action::CH8Move {
    enum Type {
        Solo = 0,
        Normal = 1,
        Wanderer = 2,
    };
}
namespace app::CH8Em4100::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        Parry = 2,
    };
}
namespace app::CH8Em4100::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
        Air = 2,
    };
}
namespace app::CH8Em4100::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4100::Action::CH8Grapple {
    enum Type {
        Thrust = 0,
    };
}
namespace app::CH8Em4100::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Em4100::Action::CH8StrikeToParry {
    enum StrikeToParryType {
        Right = 0,
        Left = 1,
        Head = 2,
    };
}
namespace app::CH8Em4000::CH8ThinkOrderSet {
    enum Type {
        None = 0,
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
namespace app::CH8Em4000::CH8ThinkAppearSet {
    enum MimicryType {
        Floor1 = 0,
        Floor2 = 1,
        Lean1 = 2,
        Lean2 = 3,
        Lean3 = 4,
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
namespace app::CH8Em4000::Action::CH8Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::CH8Em4000::Action::CH8Move {
    enum Type {
        Normal = 0,
        Destination = 1,
        Wanderer = 2,
    };
}
namespace app::CH8Em4000::Action::CH8Move {
    enum CrawlMode {
        Wait = 0,
        Walk = 1,
    };
}
namespace app::CH8Em4000::Action::CH8Strike {
    enum Type {
        Normal = 0,
        Backstep = 1,
        Slash = 2,
    };
}
namespace app::CH8Em4000::Action::CH8Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::CH8Em4000::Action::CH8Grapple {
    enum Type {
        Bite = 0,
        Mount = 1,
        Slash = 2,
    };
}
namespace app::CH8Em4000::Action::CH8BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
        Parry = 2,
    };
}
namespace app::CH8Em4000::Action::CH8Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4000::Action::CH8Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::CH8Em4000::Action::CH8CounterRush {
    enum CounterType {
        ParryCounter = 0,
        ActiveCounter = 1,
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
namespace app::vr::VrCameraQualitySetting {
    enum ImageQuality {
        None = 0,
        Default = 1,
        DotByDot = 2,
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
namespace app::vr::VrManager {
    enum FadeRequestType {
        None = 0,
        PlayerCamera = 1,
        Event = 2,
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
namespace app::vr::VrTutorialOpenFlow {
    enum Phase {
        Cutin = 0,
        Yes = 1,
        No = 2,
        End = 3,
    };
}
namespace app::vr::VrPlayerVisibleController {
    enum PlayerVisibleType {
        Default = 0,
        OnlyArm = 1,
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
namespace app::vr::VrScreenFilter {
    enum FilterType {
        Vertical = 0,
        Horizon = 1,
        Overall = 2,
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
namespace app::Chain::WindParameter {
    enum Priority {
        Low = 0,
        Normal = 1,
        High = 2,
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
namespace app::Nightmare::NightmareTrapLevelBehavior {
    enum Type {
        Target = 0,
        Symbol = 1,
        Interact = 2,
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
namespace app::Nightmare::NightmareTrapUnitDestroyUpdater {
    enum State {
        None = 0,
        WaitStart = 1,
        CheckDestroyAble = 2,
        WaitDestroyAble = 3,
        EndDestroyAble = 4,
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
namespace app::Havok::ClothAnimationColtroller {
    enum PhysicsGroup {
        None = 0,
        Group0 = 1,
        Group1 = 2,
        Group2 = 4,
        Group3 = 8,
    };
}
namespace app::Havok::RagdollCharacter {
    enum PartsId {
        Hip = 0,
        R_Thigh = 1,
        R_Shin = 2,
        R_Foot = 3,
        L_Thigh = 4,
        L_Shin = 5,
        L_Foot = 6,
        Waist = 7,
        Chest = 8,
        R_Shoulder = 9,
        R_UpperArm = 10,
        R_Forearm = 11,
        R_Hand = 12,
        L_Shoulder = 13,
        L_UpperArm = 14,
        L_Forearm = 15,
        L_Hand = 16,
        Neck = 17,
        Head = 18,
    };
}
namespace app::Havok::RigidBodyDestruct {
    enum EraseModeEnum {
        None = 0,
        Partial = 1,
        All = 2,
    };
}
namespace app::Havok::HavokSystem {
    enum FramerateType {
        Variable = 0,
        Fix30Fps = 1,
        Fix60Fps = 2,
    };
}
namespace app::Havok::CH8Em4500RagdollCharacter {
    enum PartsId {
        Hip = 0,
        R_Thigh = 1,
        R_Shin = 2,
        R_Foot = 3,
        L_Thigh = 4,
        L_Shin = 5,
        L_Foot = 6,
        Waist = 7,
        Chest = 8,
        R_Shoulder = 9,
        R_UpperArm = 10,
        R_Forearm = 11,
        R_Hand = 12,
        L_Shoulder = 13,
        L_UpperArm = 14,
        L_Forearm = 15,
        L_Hand = 16,
        Neck = 17,
        Head = 18,
    };
}
namespace app::Havok::HavokClothAnimationTrack {
    enum Mode {
        Simulation = 0,
        Animation = 1,
        AnimationEvent = 2,
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
namespace app::cutin::CutinProc1Button {
    enum StateType {
        Normal = 0,
        ReNet = 1,
        NetworkWait = 2,
        FileWait = 3,
        VRTutorial = 4,
    };
}
namespace app::cutin::CutinHandle1Button {
    enum ResultDef {
        Button = 0,
        Undecided = 1,
    };
}
namespace app::cutin::CutinHandle2Choice {
    enum ResultDef {
        Select1 = 0,
        Select2 = 1,
        Undecided = 2,
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
namespace app::cutin::CutinHandleNoInput {
    enum ResultDef {
        NoButton = 0,
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
namespace app::Collision::HitController {
    enum PressSkipAxis {
        X = 1,
        Y = 2,
        Z = 4,
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
namespace app::Collision::CollisionSystem {
    enum AsyncCastRayMode {
        IsHit = 0,
        NearHitDetail = 1,
        AllHitsDetail = 2,
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
namespace app::Collision::ShapeUserData {
    enum SideCalcType {
        None = 0,
        FixR = 1,
        FixL = 2,
        Auto = 3,
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
namespace app::Em8100::Em8100WwiseMonitoredValue {
    enum PropertyBurn {
        None = 0,
        Burn1 = 1,
        Burn2 = 2,
        Burn3 = 3,
        Max = 4,
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
namespace app::Em8100::Action::Idle {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
        StandF = 3,
    };
}
namespace app::Em8100::Action::Walk {
    enum Type {
        Normal = 0,
    };
}
namespace app::Em8100::Action::TurnWalk {
    enum Type {
        Right = 0,
        Left = 1,
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
namespace app::Em8100::Action::SplashAttack {
    enum Type {
        Normal = 0,
        Grab = 1,
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
namespace app::Em8100::Action::GrabTurn {
    enum Type {
        Right = 0,
        Left = 1,
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
namespace app::Em8100::Action::Dead {
    enum Type {
        Ground = 0,
        Beam = 1,
        Grab = 2,
        Stand = 3,
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
namespace app::Em8001::Em8001ActionController {
    enum MotionSpeedControlGroup {
        Base = 0,
        Attack = 1,
        Rank = 2,
    };
}
namespace app::Em8001::Em8001WwiseStateList {
    enum PropertyStealth {
        UnDiscovery = 0,
        Discovery = 1,
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
namespace app::Em8001::Define::Grapple {
    enum FsmState {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
    };
}
namespace app::Em8001::Define::Facial {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Dead = 700,
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
namespace app::Em8001::Action::Base {
    enum SequenceEndType {
        None = 0,
        ActionEnd = 1,
        NextState = 2,
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
namespace app::Em8001::Action::OpenDoor {
    enum Type {
        Swing_Front = 0,
        Swing_Back = 1,
    };
}
namespace app::Em8001::Action::Acid {
    enum Type {
        Start = 0,
        End = 1,
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
namespace app::Em8001::Action::AttackCombo {
    enum Type {
        INVALID = -1,
        None = 0,
        Combo_Swing = 1,
        Combo_SwingBack = 2,
        SUM = 3,
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
namespace app::Em8001::Action::Grapple {
    enum Type {
        None = 0,
        Cutting = 1,
        CuttingBack = 2,
        ShotGunGuard = 3,
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
namespace app::Em8001::Action::Walk {
    enum Type {
        Normal = 0,
        LoopStart = 1,
        Acid = 2,
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
namespace app::Em8001::Override::Em8001OverrideController {
    enum BlendState {
        None = 0,
        StartBlend = 1,
        Blend = 2,
        EndBlend = 3,
    };
}
namespace app::Em8001::Override::Em8001OverrideController {
    enum OverrideActionArg {
        Gesture = 0,
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
namespace app::Em8001::IK::ProcessBase {
    enum TransitionChangeState {
        INVALID = -1,
        None = 0,
        Up = 1,
        Down = 2,
        SUM = 3,
    };
}
namespace app::Em8000::Em8000ActionStartPoint {
    enum ActionType {
        None = 0,
        Appear = 1,
        GetScissors = 2,
    };
}
namespace app::Em8000::Em8000ActionTargetPoint {
    enum TargetType {
        None = 0,
        GetScissors = 1,
    };
}
namespace app::Em8000::Em8000AroundTargetAgent {
    enum DistanceGroup {
        Near = 0,
        Middle = 1,
        Far = 2,
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
namespace app::Em8000::Em8000AroundTargetAgent {
    enum SelectType {
        CurrentPointPos = 0,
        QueryPointPos = 1,
        QueryNodePos = 2,
        BlendQueryPos = 3,
        RayCastPos = 4,
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
namespace app::Em8000::Em8000PropsBreakTarget {
    enum TargetType {
        None = 0,
        Stretcher = 1,
        IronShelf = 2,
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
namespace app::Em8000::Action::Em8000ActionBase {
    enum SequenceEndType {
        None = 0,
        ActionEnd = 1,
        NextState = 2,
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
namespace app::Em8000::Action::Em8000Dead {
    enum Type {
        LegBreak = 0,
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
namespace app::Em8000::Action::Em8000KneeDown {
    enum KneeDownAttackType {
        None = 0,
        SwingAttack = 1,
        CrazyAttack = 2,
        EndAttack = 3,
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
namespace app::Em8000::Action::Em8000EngineStop {
    enum State {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
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
namespace app::Em8000::Action::Em8000ComboAttack {
    enum Type {
        INVALID = -1,
        None = 0,
        ComboAttack = 1,
        ComboAttackBack = 2,
        SUM = 3,
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
namespace app::Em8000::Action::Em8000Damage {
    enum DownState {
        INVALID = -1,
        None = 0,
        NoDelegateProcess = 1,
        SUM = 2,
    };
}
namespace app::Em8000::Action::Em8000Walk {
    enum Type {
        None = 0,
        Normal = 1,
        LoopStart = 2,
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
namespace app::Em8000::Action::Em8000ActionStatus {
    enum Mode {
        None = 0,
        Axe = 1,
        Hand = 2,
        Scissor = 3,
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
namespace app::Em8000::Override::Em8000OverrideController {
    enum BlendState {
        None = 0,
        StartBlend = 1,
        Blend = 2,
        EndBlend = 3,
    };
}
namespace app::Em8000::Override::Em8000OverrideController {
    enum OverrideActionArg {
        Gesture = 0,
        CoreLoopStart = 1,
        CoreLoopEnd = 2,
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
namespace app::Em5520::Action::Appear {
    enum Type {
        Born = 0,
        Gather = 1,
        Call = 2,
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
namespace app::Em5510::Action::Generate {
    enum Type {
        Em5400 = 0,
        Em5520 = 1,
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
namespace app::Em5400::Action::FlyMove {
    enum Type {
        Normal = 0,
        LookTarget = 1,
    };
}
namespace app::Em5400::Action::GroundMove {
    enum Type {
        Normal = 0,
        Reaction = 1,
    };
}
namespace app::Em5400::Action::Dead {
    enum Type {
        Fall = 0,
        Disperse = 1,
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
namespace app::Em5400::Action::Damage {
    enum Type {
        DamageS = 0,
        DamageFlyS_L = 1,
        DamageFlyS_R = 2,
        DamageLGround = 3,
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
namespace app::Em5400::Action::Grapple {
    enum Type {
        Stab = 0,
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
namespace app::Em5400::Goal::SideMove {
    enum MoveDirect {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em5400::Goal::Attack {
    enum Type {
        Stab = 0,
        Strike = 1,
    };
}
namespace app::Em4200::ThinkOrderSet {
    enum Type {
        None = 0,
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
namespace app::Em4200::ThinkAppearSet {
    enum Type {
        Default = 0,
        First = 1,
        Summon = 2,
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
namespace app::Em4200::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::Em4200::Action::Move {
    enum Type {
        Normal = 0,
        Wanderer = 1,
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
namespace app::Em4200::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::Em4200::Action::Grapple {
    enum Type {
        Mount = 0,
    };
}
namespace app::Em4200::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4200::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4200::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4100::ThinkOrderSet {
    enum Type {
        None = 0,
    };
}
namespace app::Em4100::ThinkStateSet {
    enum Type {
        Default = 0,
        Wanderer = 1,
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
namespace app::Em4100::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::Em4100::Action::Move {
    enum Type {
        Solo = 0,
        Normal = 1,
        Wanderer = 2,
    };
}
namespace app::Em4100::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4100::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
        Air = 2,
    };
}
namespace app::Em4100::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4100::Action::Grapple {
    enum Type {
        Thrust = 0,
    };
}
namespace app::Em4100::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::Em4000::ThinkOrderSet {
    enum Type {
        None = 0,
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
namespace app::Em4000::ThinkAppearSet {
    enum MimicryType {
        Floor1 = 0,
        Floor2 = 1,
        Lean1 = 2,
        Lean2 = 3,
        Lean3 = 4,
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
namespace app::Em4000::Action::Idle {
    enum Type {
        Normal = 0,
        ForLostTarget = 1,
    };
}
namespace app::Em4000::Action::Move {
    enum Type {
        Normal = 0,
        Destination = 1,
        Wanderer = 2,
    };
}
namespace app::Em4000::Action::Move {
    enum CrawlMode {
        Wait = 0,
        Walk = 1,
    };
}
namespace app::Em4000::Action::Strike {
    enum Type {
        Normal = 0,
        Backstep = 1,
        Slash = 2,
    };
}
namespace app::Em4000::Action::Suspend {
    enum Option {
        None = 0,
        WithSelfDie = 1,
        Hide = 2,
    };
}
namespace app::Em4000::Action::Grapple {
    enum Type {
        Bite = 0,
        Mount = 1,
        Slash = 2,
    };
}
namespace app::Em4000::Action::BlownAway {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4000::Action::Damage {
    enum Type {
        Normal = 0,
        Down = 1,
    };
}
namespace app::Em4000::Action::Dead {
    enum Type {
        Normal = 0,
        Down = 1,
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
namespace app::Em3600::Em3600WwiseMonitoredValue {
    enum PropertyPhase {
        Normal = 0,
        FirstDiscovery = 1,
        Last = 2,
        FirstGrappleAttack = 3,
        FirstGrappleAttackEnd = 4,
    };
}
namespace app::Em3600::Em3600WwiseMonitoredValue {
    enum PropertyLayer {
        Low = 0,
        High = 1,
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
namespace app::Em3600::Action::PoseChange {
    enum Type {
        Default = 0,
        FourLegStartTurn = 1,
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
namespace app::Em3600::Action::Sneak {
    enum Type {
        roof = 0,
        floor = 1,
        floor_v1 = 2,
        window = 3,
    };
}
namespace app::Em3600::Action::Jump {
    enum Type {
        JumpS = 0,
        JumpM = 1,
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
namespace app::Em3600::Action::BackJump {
    enum Type {
        Normal = 0,
        NoWallStick = 1,
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
namespace app::Em3600::Action::ExMove {
    enum Type {
        Stride = 0,
        GetOver = 1,
    };
}
namespace app::Em3600::Action::FourLegMoveTurn {
    enum Type {
        Left = 0,
        Right = 1,
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
namespace app::Em3102::Em3102ActionController {
    enum MotionSpeedControlGroup {
        Move = 0,
        Rank = 1,
    };
}
namespace app::Em3102::Em3102Think {
    enum FacialBasicID {
        NoDefault = -1,
        Normal = 0,
        Ghost = 1000,
    };
}
namespace app::Em3102::Em3102WwiseStateList {
    enum PropertyStealth {
        UnDiscovery = 0,
        Discovery = 1,
    };
}
namespace app::Em3102::Goal::BattleRest {
    enum LeaveStatus {
        Non = 0,
        Leave = 1,
        Arrive = 2,
    };
}
namespace app::Em3102::Define::Mesh {
    enum State {
        Human = 0,
        Demon = 1,
    };
}
namespace app::Em3102::Action::Walk {
    enum Type {
        None = 0,
        Walk = 1,
        DetectWalk = 2,
    };
}
namespace app::Em3102::Action::Run {
    enum Type {
        None = 0,
        Run = 1,
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
namespace app::Em3102::Action::Search {
    enum Type {
        None = 0,
        SearchR = 1,
        SearchL = 2,
    };
}
namespace app::Em3102::Action::DoorOpen {
    enum Type {
        None = 0,
        Left = 1,
        Right = 2,
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
namespace app::Em3102::Action::Grapple {
    enum Type {
        Finish = 0,
    };
}
namespace app::Em3101::Action::Grapple {
    enum Type {
        BedRoomGrapple = 0,
    };
}
namespace app::Em3100::Em3100WwiseStateList {
    enum PropertyStealth {
        UnDiscovery = 0,
        Discovery = 1,
    };
}
namespace app::Em3100::Action::Walk {
    enum Type {
        Default = 0,
        Fret_v1 = 1,
        Fret_v2 = 2,
    };
}
namespace app::Em3100::Action::Run {
    enum Type {
        Default = 0,
        Patrol = 1,
    };
}
namespace app::Em3100::Action::OverLook {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em3100::Action::WalkOverLook {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em3100::Action::WalkLookBack {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em3100::Action::DiscoveryTurn {
    enum Type {
        Default = 0,
        Patrol = 1,
        OrderTurn = 2,
    };
}
namespace app::Em3100::Action::DiscoveryLoop {
    enum Type {
        Default = 0,
        Patrol = 1,
    };
}
namespace app::Em3100::Action::WalkEvade {
    enum Type {
        Left = 0,
        Right = 1,
    };
}
namespace app::Em3100::Action::Grapple {
    enum Type {
        FFDeathGrapple = 0,
        FallDownGrapple = 1,
    };
}
namespace app::Em3100::Action::Damage {
    enum Type {
        Head = 0,
        Left = 1,
        Right = 2,
    };
}
namespace app::Em3100::Action::Dead {
    enum Type {
        Default = 0,
        DeadWait = 1,
    };
}
namespace app::Em3100::Action::DoorOpen {
    enum Type {
        Left = 0,
        Right = 1,
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
namespace app::Em3100::Action::DLC_TestAction {
    enum Type {
        OrderBugHoleInstructEnd = 0,
        OrderBusInstructEnd = 1,
        OrderStun = 2,
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
namespace app::Em3002::Em3002WwiseMonitoredValue {
    enum PropertyEncount {
        InCamera = 0,
        OutCamera = 1,
        Max = 2,
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
namespace app::Em3002::Action::Rest {
    enum Type {
        Rest1 = 0,
        Rest2 = 1,
        Rest3 = 2,
    };
}
namespace app::Em3002::Action::Appear {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::Em3002::Action::Walk {
    enum Type {
        Normal = 0,
        TNormal = 1,
    };
}
namespace app::Em3002::Action::Turn {
    enum Type {
        Fast = 0,
        Move = 1,
    };
}
namespace app::Em3002::Action::Attack {
    enum Type {
        PunchL = 0,
    };
}
namespace app::Em3002::Action::AttackToGrapple {
    enum Type {
        CommonGrab = 0,
        TCommonGrab = 1,
    };
}
namespace app::Em3002::Action::OpenDoor {
    enum Type {
        Normal = 0,
        Kick = 1,
    };
}
namespace app::Em3002::Action::Grapple {
    enum Type {
        CommonTurn = 0,
        FinishMove = 1,
    };
}
namespace app::Em3002::Goal::Search {
    enum Type {
        Non = 0,
        Vision = 1,
        Hearing = 2,
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
namespace app::Em3002::Goal::BattleRest {
    enum LeaveStatus {
        Non = 0,
        Leave = 1,
        Arrive = 2,
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
namespace app::Em3001::Em3001WwiseMonitoredValue {
    enum PropertyEncount {
        InCamera = 0,
        OutCamera = 1,
        Max = 2,
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
namespace app::Em3001::Action::Appear {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::Em3001::Action::Walk {
    enum Type {
        Normal = 0,
        Acid = 1,
        TNormal = 2,
    };
}
namespace app::Em3001::Action::Turn {
    enum Type {
        Fast = 0,
        Move = 1,
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
namespace app::Em3001::Action::Zigzag {
    enum Type {
        Normal = 0,
        TNormal = 1,
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
namespace app::Em3001::Action::AttackBack {
    enum Type {
        SwingB = 0,
        PunchB = 1,
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
namespace app::Em3001::Action::AttackToGrapple {
    enum Type {
        CommonGrab = 0,
        TCommonGrab = 1,
    };
}
namespace app::Em3001::Action::OpenDoor {
    enum Type {
        Normal = 0,
        Kick = 1,
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
namespace app::Em3001::Goal::Search {
    enum Type {
        Non = 0,
        Vision = 1,
        Hearing = 2,
        Damage = 3,
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
namespace app::Em3000::Em3000ActionController {
    enum MotionSpeedControlGroup {
        Base = 0,
        Attack = 1,
        Rank = 2,
    };
}
namespace app::Em3000::Em3000WwiseMonitoredValue {
    enum PropertyEncount {
        InCamera = 0,
        OutCamera = 1,
        Max = 2,
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
namespace app::Em3000::Em8000CorpsebagManager {
    enum Group {
        Corpsebag = 0,
        CorpsebagShort = 1,
        CorpsebagNoBattle = 2,
        SUM = 3,
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
namespace app::Em3000::Action::Appear {
    enum Type {
        Front = 0,
        Right = 1,
        Left = 2,
    };
}
namespace app::Em3000::Action::Walk {
    enum Type {
        Normal = 0,
        Fire = 1,
        TNormal = 2,
    };
}
namespace app::Em3000::Action::Turn {
    enum Type {
        Fast = 0,
        Move = 1,
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
namespace app::Em3000::Action::Zigzag {
    enum Type {
        Normal = 0,
        TNormal = 1,
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
namespace app::Em3000::Action::AttackBack {
    enum Type {
        SwingB = 0,
        PunchB = 1,
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
namespace app::Em3000::Action::AttackKnock {
    enum Type {
        Forward = 0,
        Back = 1,
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
namespace app::Em3000::Action::OpenDoor {
    enum Type {
        Normal = 0,
        Kick = 1,
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
namespace app::Em3000::Action::Chapter3Battle1Final_Damage {
    enum Type {
        NoDamage = 0,
        RunOverR = 1,
        RunOverL = 2,
        RunOverRSide = 3,
        RunOverLSide = 4,
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
namespace app::Em3000::IK::ProcessBase {
    enum TransitionChangeState {
        INVALID = -1,
        None = 0,
        Up = 1,
        Down = 2,
        SUM = 3,
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
namespace app::Em3000::Goal::Chapter3Battle1DestroyTable {
    enum DestroyTableStatus {
        Non = 0,
        GotoTable = 1,
        CanDestroyTable = 2,
        DestroyTable = 3,
        DestroyTableEnd = 4,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1Final {
    enum Message {
        Non = 0,
        AppearEnd = 1,
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
namespace app::Em3000::Goal::Chapter3Battle1Final {
    enum GetOffCarStatus {
        Non = 0,
        GotoGetOffCar = 1,
        CanGetOffCar = 2,
        GetOffCarEnd = 3,
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
namespace app::Em3000::Goal::Chapter3Battle1FinalDrivePL {
    enum PLDriveStatus {
        Non = 0,
        GotoCarFront = 1,
        ArriveCarFront = 2,
    };
}
namespace app::Em3000::Goal::Chapter3Battle1Rest {
    enum LeaveStatus {
        Non = 0,
        Leave = 1,
        Arrive = 2,
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
namespace app::Em2000::Em2000ActionController {
    enum Chapter4Stamp {
        None = 0,
        Separate = 1,
        Battle = 2,
    };
}
namespace app::Em2000::Em2000FaceController {
    enum FaceNo {
        Enemy = 0,
        Npc = 1,
        Blend = 2,
    };
}
namespace app::Em2000::Em2000FaceController {
    enum PartsNo {
        p000 = 0,
        p001 = 1,
        p002 = 2,
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
namespace app::Em2000::Action::Chapter1Battle2Throw {
    enum Type {
        ThrowingToLeft = 0,
        ThrowingToRight = 1,
    };
}
namespace app::Em2000::Action::Chapter1Battle4WalkStrafe {
    enum Type {
        Slow = 0,
        Normal = 1,
        Fast = 2,
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
namespace app::Em2000::Action::Chapter1Battle4StabAttack {
    enum Type {
        StabNormal = 0,
        StabLong = 1,
    };
}
namespace app::Em2000::Action::Chapter1Battle4DestroyObject {
    enum Type {
        DestroyObjectL = 0,
        DestroyObjectR = 1,
    };
}
namespace app::AI::EvaluationMethod {
    enum Type {
        Average = 0,
        Weighted = 1,
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
namespace app::AI::GoalArbitrator {
    enum State {
        InActive = 0,
        Active = 1,
        Suspend = 2,
        Quit = 3,
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
namespace app::AI::GoalArbitrator {
    enum Cycle {
        EveryFrame = 0,
        Permitted = 1,
        ElapsedSec = 2,
    };
}
namespace app::AI::MoldedCommonBoard {
    enum RenderTargetStatusEnum {
        None = 0,
        Used = 1,
        UsedFromDead = 2,
    };
}
namespace app::AI::MoldedCommonBoard {
    enum RenderTargetType {
        Slow = 0,
        Quick = 1,
        Fat = 2,
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
namespace app::AI::AIChildBeacon {
    enum ProcessType {
        InActive = 0,
        Activate = 1,
        Running = 2,
        Terminate = 3,
    };
}
namespace app::AI::AIGrappleBeacon {
    enum StatusType {
        InActive = 0,
        Active = 1,
        Terminate = 2,
    };
}
namespace app::AI::AIGrappleBeacon {
    enum GrappleTypeEnum {
        None = 0,
        Chapter1Battle1 = 1,
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
namespace app::AI::AILookAtAgent {
    enum Distance {
        Near = 0,
        Middle = 1,
        Far = 2,
    };
}
namespace app::AI::AILookAtAgent {
    enum Priority {
        Low = 0,
        Normal = 1,
        High = 2,
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
namespace app::AI::Em2000WallBreakMansionAISetInfo {
    enum InteractEventType {
        None = 0,
        em2000_WallBreak_Front = 1,
        em2000_WallBreak_Back = 2,
    };
}
namespace app::AI::MansionAIEffectorZoneGroup {
    enum EffectorTypeEnum {
        ForbidDespawn = 0,
    };
}
namespace app::AI::MansionAIEffectorZoneGroup {
    enum ConditionTypeEnum {
        InPlayer = 0,
        InEnemy = 1,
        InPlayerAndEnemy = 2,
    };
}
namespace app::AI::CH8MoldedCommonBoard {
    enum RenderTargetStatusEnum {
        None = 0,
        Used = 1,
        UsedFromDead = 2,
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
namespace app::AI::CH9AIWorldBlackBoard {
    enum ExistPlayerHideZoneState {
        None = 0,
        Enter = 1,
        Overlap = 2,
        Leave = 3,
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
namespace app::AI::NodeLinkInfo {
    enum Validation {
        Invalid = 0,
        Node = 1,
        Link = 2,
        Valid = 3,
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
namespace app::AI::UseDoorInfo {
    enum SearchDirectionType {
        Default = 0,
        OwnerAxisZ = 1,
        PotalInfo = 2,
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
namespace app::AI::AINavigationHelper {
    enum StateType {
        None = 0,
        Stopping = 1,
        End = 2,
    };
}
namespace app::AI::AIThinkActionOrderSetParam {
    enum TargetType {
        ApproachTarget = 0,
        WatchTarget = 1,
    };
}
namespace app::AI::AIVolumeSpaceNavigationHelper {
    enum StateType {
        None = 0,
        Stopping = 1,
        End = 2,
    };
}
namespace app::AI::AIWanderHelper {
    enum EvaluateType {
        Random = 0,
        Nearest = 1,
        Farest = 2,
    };
}
namespace app::AI::MansionAIEvaluationParameter {
    enum VisibleType {
        None = 0,
        Visible = 1,
        Invisible = 2,
    };
}
namespace app::AI::CommonEvaluator::CheckRange {
    enum Type {
        Simple = 0,
        NormalizedRateScore = 1,
        RateScore = 2,
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
namespace app::BedRoom::BedRoomMonitoringGimick {
    enum MotionDirection {
        Right = 0,
        Front = 1,
        Left = 2,
    };
}
namespace app::BedRoom::BedRoomMonitoringGimick {
    enum FalidMessageSituation {
        EnterRoom = 0,
        TraySurvice = 1,
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
namespace app::fsm::CallObjective {
    enum Mode {
        Disable = 0,
        Enable = 1,
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
namespace app::fsm::CH8AreaHitTest {
    enum TestTypeParam {
        InArea = 0,
        OutArea = 1,
    };
}
namespace app::fsm::CH8AreaHitTest {
    enum TargetParam {
        Player = 0,
        Enemy = 1,
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
namespace app::fsm::CH8BuySkill {
    enum SkillID {
        None = 0,
        StepUpNightGoggle = 1,
    };
}
namespace app::fsm::CH8ChangeMapShutterState {
    enum ChangeMapShutterStateType {
        Close = 0,
        Open = 1,
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
namespace app::fsm::CH8CheckEm4500Action {
    enum CompareTable {
        Equal = 0,
        NotEqual = 1,
    };
}
namespace app::fsm::CH8CheckEnemySpawned {
    enum CheckTable {
        IsSpawned = 0,
        IsUpdate = 1,
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
namespace app::fsm::CH8CheckMessageState {
    enum StateCheckType {
        None = 0,
        TimeCount = 1,
        MessageEnd = 2,
        PageStart = 3,
        PageEnd = 4,
    };
}
namespace app::fsm::CH8CheckOpenFileMenu {
    enum Status {
        Open = 0,
        Close = 1,
    };
}
namespace app::fsm::CH8CheckSeceFolder {
    enum CheckType {
        IsActivate = 0,
        IsDeactivate = 1,
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
namespace app::fsm::CH8ControlMaterial {
    enum ParamType {
        Float4 = 1,
        Float = 2,
    };
}
namespace app::fsm::CH8CountAddTest {
    enum TestTypeParam {
        CoinCounter = 0,
    };
}
namespace app::fsm::CH8ElevatorDoor {
    enum ActionType {
        Open = 0,
        Close = 1,
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
namespace app::fsm::CH8ElevatorButtonCheck {
    enum CheckType {
        Use = 0,
        SameFloor = 1,
        OpenDoor = 2,
        CloseDoor = 3,
        SecurityLock = 4,
    };
}
namespace app::fsm::CH8ElevatorButtonAction {
    enum ActionType {
        DoorOpen = 0,
        DoorClose = 1,
        Call = 2,
    };
}
namespace app::fsm::CH8EndOperator {
    enum GUIStateTable {
        DEFAULT = 0,
        FADEOUT = 1,
    };
}
namespace app::fsm::CH8FadeControlAction {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
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
namespace app::fsm::CH8SystemDataSave {
    enum State {
        Init = 0,
        Saveing = 1,
        SaveFailed = 2,
    };
}
namespace app::fsm::CH8InteractStart {
    enum StartTypeParam {
        Normal = 0,
        SwitchOn = 1,
        SwitchOff = 2,
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
namespace app::fsm::CH8ItemTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace app::fsm::CH8ItemTest {
    enum CheckTarget {
        Inventory = 0,
        ItemBox = 1,
        InventoryAndItemBox = 2,
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
namespace app::fsm::CH8LiftSet {
    enum SetType {
        SkipInterval = 0,
    };
}
namespace app::fsm::CH8MotionPlay {
    enum AdjustStartFrameTypeEnum {
        None = 0,
        NormalizeTime = 1,
        ReverseNormalizeTime = 2,
    };
}
namespace app::fsm::CH8NoSaveValueControl {
    enum ControlTargetEnum {
        None = 0,
        LastBattle = 1,
        HUDEvent = 2,
    };
}
namespace app::fsm::CH8NoSaveValueControl {
    enum ControlTypeEnum {
        Set = 0,
        Check = 1,
    };
}
namespace app::fsm::CH8PartsEnable {
    enum PartsSetType {
        EnableSet = 0,
        DisableSet = 1,
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
namespace app::fsm::CH8PlayerDetectCheck {
    enum Type {
        None = 0,
        Enemy = 1,
    };
}
namespace app::fsm::CH8PlayerRequestCommandForce {
    enum CommandType {
        Guard = 0,
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
namespace app::fsm::CH8StateCheck {
    enum IntType {
        None = 0,
        Life = 1,
    };
}
namespace app::fsm::CH8EnemyStateCheck {
    enum EnemyBoolType {
        None = 0,
        Discovery = 1,
    };
}
namespace app::fsm::CH8EnemyStateCheck {
    enum EnemyIntType {
        None = 0,
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
namespace app::fsm::CH8PlayerStateCheck {
    enum PlayerIntType {
        None = 0,
        LoadNum = 1,
        NoGuardDamageChain = 2,
    };
}
namespace app::fsm::CH8RequestFade {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace app::fsm::CH8RequestFadeInOut {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
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
namespace app::fsm::CH8SetDoorState {
    enum OverrideType {
        NotSet = 0,
        UseDefault = 1,
        Override = 2,
    };
}
namespace app::fsm::CH8StartOperator {
    enum GUIStateTable {
        DEFAULT = 0,
        FADEIN = 1,
    };
}
namespace app::fsm::CH8SteelGateAction {
    enum ActionType {
        ManualOpen = 0,
    };
}
namespace app::fsm::CH8TramPuzzleAction {
    enum Type {
        None = 0,
        Overlapping = 1,
    };
}
namespace app::fsm::CH8VideoDisp {
    enum SetState {
        Play = 0,
        Stop = 1,
        Clear = 2,
    };
}
namespace app::fsm::CH8Wait {
    enum WaitTypeEnum {
        Normal = 0,
        FlagSet = 1,
    };
}
namespace app::fsm::CH9InGameContentAction {
    enum OperationTypeEnum {
        ContentStart = 0,
        ContentEnd = 1,
    };
}
namespace app::fsm::AdjustSafeSpace {
    enum FindType {
        Direction = 0,
        SpaceCheck = 1,
    };
}
namespace app::fsm::AreaHitTest {
    enum TestTypeParam {
        InArea = 0,
        OutArea = 1,
    };
}
namespace app::fsm::AreaHitTest {
    enum TargetParam {
        Player = 0,
        Enemy = 1,
    };
}
namespace app::fsm::ChangeDamageGUI {
    enum SaturationType {
        NotSet = 0,
        FullColor = 1,
        Monochrome = 2,
    };
}
namespace app::fsm::ChangeDamageGUI {
    enum VisibleType {
        NotSet = 0,
        Visible = 1,
        Invisible = 2,
    };
}
namespace app::fsm::ChangeDamageGUI {
    enum ConnectType {
        NotSet = 0,
        Connect = 1,
        Disconnect = 2,
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
namespace app::fsm::CheckDoorAngle {
    enum CompareType {
        LessThan = 0,
        LessThanOrEqualTo = 1,
        GreaterThan = 2,
        GreaterThanOrEqualTo = 3,
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
namespace app::fsm::CheckGenomeCodexState {
    enum Mode {
        Scan = 0,
        Install = 1,
        TraceScan = 2,
        CommunicationTalking = 3,
        CommunicationCall = 4,
    };
}
namespace app::fsm::CountAddTest {
    enum TestTypeParam {
        CoinCounter = 0,
    };
}
namespace app::fsm::CallCp7EndNoise {
    enum ElementNumber {
        Step0 = 0,
        Step1 = 1,
    };
}
namespace app::fsm::OpenWaveAnnouncement {
    enum Meridiem {
        AM = 0,
        PM = 1,
    };
}
namespace app::fsm::EffectControlAction {
    enum TargetModeEnum {
        TargetOnly = 0,
        TargetAndChildren = 1,
        ChildrenOnly = 2,
    };
}
namespace app::fsm::ElevatorDoor {
    enum ActionType {
        Open = 0,
        Close = 1,
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
namespace app::fsm::ElevatorButtonCheck {
    enum CheckType {
        Use = 0,
        SameFloor = 1,
        OpenDoor = 2,
        CloseDoor = 3,
        SecurityLock = 4,
    };
}
namespace app::fsm::ElevatorButtonAction {
    enum ActionType {
        DoorOpen = 0,
        DoorClose = 1,
        Call = 2,
    };
}
namespace app::fsm::EmLoadRequest {
    enum LoadTypeEnum {
        Load = 0,
        UnLoad = 1,
        MAX = 2,
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
namespace app::fsm::GUIFadeInOut {
    enum FadeDefine {
        FadeIn = 0,
        FadeOut = 1,
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
namespace app::fsm::HandLightPower {
    enum ActionType {
        None = 0,
        ForceOn = 1,
        ForceOff = 2,
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
namespace app::fsm::InteractParamSet {
    enum FarIconForceDispParam {
        NoChange = 0,
        On = 1,
        Off = 2,
    };
}
namespace app::fsm::InteractStart {
    enum StartTypeParam {
        Normal = 0,
        SwitchOn = 1,
        SwitchOff = 2,
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
namespace app::fsm::IntTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace app::fsm::ItemTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace app::fsm::ItemTest {
    enum CheckTarget {
        Inventory = 0,
        ItemBox = 1,
        InventoryAndItemBox = 2,
    };
}
namespace app::fsm::MapExObject {
    enum ControlTypes {
        Default = 0,
        Mode1 = 1,
        Mode2 = 2,
    };
}
namespace app::fsm::MapPlayerPosLock {
    enum ControlTypes {
        None = 0,
        Lock = 1,
        Unlock = 2,
    };
}
namespace app::fsm::MotionPlay {
    enum AdjustStartFrameTypeEnum {
        None = 0,
        NormalizeTime = 1,
        ReverseNormalizeTime = 2,
    };
}
namespace app::fsm::EnemyThinkAction {
    enum ActionOrderType {
        ActionSet = 0,
        ActionEnd = 1,
    };
}
namespace app::fsm::OpenCloseCreditsScene {
    enum Action {
        Open = 0,
        End = 1,
    };
}
namespace app::fsm::PartsEnable {
    enum PartsSetType {
        EnableSet = 0,
        DisableSet = 1,
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
namespace app::fsm::StateCheck {
    enum BoolType {
        None = 0,
        Grapple = 1,
        Damage = 2,
        Dead = 3,
        Crouch = 4,
    };
}
namespace app::fsm::StateCheck {
    enum IntType {
        None = 0,
        Life = 1,
    };
}
namespace app::fsm::EnemyStateCheck {
    enum EnemyBoolType {
        None = 0,
        Discovery = 1,
    };
}
namespace app::fsm::EnemyStateCheck {
    enum EnemyIntType {
        None = 0,
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
namespace app::fsm::PlayerStateCheck {
    enum PlayerIntType {
        None = 0,
        LoadNum = 1,
        NoGuardDamageChain = 2,
    };
}
namespace app::fsm::PlayTimeTest {
    enum CompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
    };
}
namespace app::fsm::PositionCheck {
    enum DistCompareType {
        Equal = 0,
        LessThan = 1,
        GreaterThan = 2,
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
namespace app::fsm::PositionCheck {
    enum CheckTimeTypeEnum {
        Time = 0,
        TotalTime = 1,
    };
}
namespace app::fsm::RequestFadeInOut {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace app::fsm::RequestFadeInOut_HideIcon {
    enum FadeTypeEnum {
        FadeOut = 0,
        FadeIn = 1,
    };
}
namespace app::fsm::requestMenuFromFsm {
    enum RequestTargetMenuEnum {
        AmbassadorTrialInGameTitle = 0,
        AmbassadorTrialObjective = 1,
        FF030_Ex_Objective = 2,
    };
}
namespace app::fsm::requestMenuFromFsm {
    enum RequestTypeEnum {
        Open = 0,
        Close = 1,
    };
}
namespace app::fsm::RigidBodyCheck {
    enum TestTypeParam {
        IsBreak = 0,
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
namespace app::fsm::SetDoorState {
    enum OverrideType {
        NotSet = 0,
        UseDefault = 1,
        Override = 2,
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
namespace app::fsm::SetGenomeCodexNoiseLv {
    enum RadarNoiseLvDef {
        None = 0,
        Lv1 = 1,
        Lv2 = 2,
    };
}
namespace app::fsm::SetGenomeCodexRadarEnable {
    enum StateDef {
        Disable = 0,
        Enable = 1,
    };
}
namespace app::fsm::SetMansionAI {
    enum SetType {
        Enable = 0,
        Disable = 1,
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
namespace app::fsm::Sm0113Phone_Exclusive {
    enum CheckTypeEnum {
        CK_1st = 0,
        CK_2nd = 1,
        CK_3rd = 2,
    };
}
namespace app::fsm::Sm0113Phone_Exclusive {
    enum StepEnum {
        CK_Length_Sep = 0,
        CK_Length_Con = 1,
        CK_Time = 2,
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
namespace app::fsm::VibrationSet {
    enum VibSizeType {
        SizeS = 0,
        SizeM = 1,
        SizeL = 2,
    };
}
namespace app::fsm::VideoDisp {
    enum SetState {
        Play = 0,
        Stop = 1,
        Clear = 2,
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
namespace app::fsm::Wait {
    enum WaitTypeEnum {
        Normal = 0,
        FlagSet = 1,
    };
}
namespace app::fsm::Em3102::Em3102Target {
    enum Event {
        None = 0,
        ActionEnd = 1,
        ActionFailed = 2,
    };
}
namespace app::CardGameObjectElectricMachine::BetFlip {
    enum StopNoDefine {
        Random = -1,
        NoDisp = 100,
    };
}
namespace app::CardGameObjectSawGauge::FlipRotate {
    enum FlipType {
        Bet = 0,
        Banker = 1,
        Player = 2,
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
namespace app::BasicAnimationController::AnimatorParam {
    enum ParamType {
        Int = 0,
        Float = 1,
        Bool = 2,
    };
}
namespace app::MotionGroupTable::MotionInfo {
    enum InfoType {
        Motion = 0,
        State = 1,
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
namespace app::Em3001Order::Appear {
    enum Type {
        None = 0,
        Dummy = 1,
        AppearF = 2,
        AppearR = 3,
        AppearL = 4,
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
namespace app::Em3100Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em3101Order::Appear {
    enum Type {
        Idle = 0,
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
namespace app::Em3600Think::MotherHoleInfo {
    enum HoleType {
        Hide = 0,
        Appear = 1,
        Sneak = 2,
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
namespace app::Em5510Order::Appear {
    enum Type {
        Idle = 0,
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
namespace app::Em5540Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em5552Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em8100Order::Appear {
    enum Type {
        None = 0,
        Restart = 1,
        ForceBattleStart = 2,
    };
}
namespace app::Em8900Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em8910Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em8940Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::Em8950Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::EnemySpawnInfo::ResumeParameter {
    enum Type {
        LastStandingPoint = 0,
        FirstAppearPoint = 1,
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
namespace app::GrappleBase::SafeSpaceParam {
    enum FindType {
        None = 0,
        Position = 1,
        Direction = 2,
        DirectionAndPosition = 3,
    };
}
namespace app::GrappleBase::SafeSpaceParam {
    enum BaseObjectType {
        Default = 0,
        PlayerY = 1,
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
namespace app::DamageController::DamageRecord {
    enum DamageType {
        Hit = 0,
        Manual = 1,
        Debug = 2,
    };
}
namespace app::CardGameKillCountProduction::KillCountProductionSoundController {
    enum Type {
        BlackOut = 0,
        CountDown = 1,
    };
}
namespace app::InventoryMenu::CursorParam {
    enum TypeDef {
        ItemSlot = 0,
        ItemBoxList = 1,
    };
}
namespace app::InventoryMenu::CursorParam {
    enum ModeDef {
        ItemSlotOnly = 0,
        ItemBoxMode = 1,
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
namespace app::LastWaveUIAsset::TimePanel {
    enum TimeState {
        TIME_AM = 0,
        TIME_PM = 1,
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
namespace app::UITimer::StringConvertParam {
    enum IntegralEmptyDigitTypeDef {
        Nothing = 0,
        Zero = 1,
        Space = 2,
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
namespace app::CarInGarage::Donut {
    enum Routine {
        Steer = 0,
        Approach = 1,
        Turn = 2,
        FinishTurn = 3,
        End = 4,
    };
}
namespace app::CarInGarage::Action {
    enum WallHitStatus {
        None = 0,
        Hit = 1,
        Crash = 2,
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
namespace app::CH8Em4500ActionController::BattleCondition {
    enum Status {
        Fast = 0,
        Second = 1,
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
namespace app::CH8PlayerOrder::IgnoreInputReturnFromMenu {
    enum IgnoreInputTimeType {
        Frame = 0,
        Second = 1,
    };
}
namespace app::CH8SaveDataOverWriter::OverWriteInfo {
    enum WriteTarget {
        Fsm = 0,
    };
}
namespace app::CH8SaveDataOverWriter::OverWriteInfo {
    enum ActionState {
        PreSave = 0,
        PostLoad = 1,
    };
}
namespace app::CH8HUDControl::AirGauge {
    enum EventKeyItem {
        None = 0,
        NightVision = 1,
        AirFilter = 2,
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
namespace app::CH8HUDControl::AirGauge {
    enum OxySoundState {
        Normal = 0,
        Warning = 1,
        Danger = 2,
    };
}
namespace app::CH8HUDControl::AirGauge {
    enum PollutionLevel {
        Clean = 0,
        Caution = 1,
        Max = 2,
    };
}
namespace app::CH8ActivateObjectOperation::OperationData {
    enum DataType {
        Operation = 0,
        BoolVariable = 1,
        IntVariable = 2,
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
namespace app::CH8ActivateObjectOperation::OperationData {
    enum IntCompareTarget {
        Variable = 0,
        Input = 1,
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
namespace app::CH8VoiceHealthRemaining::CH8VoiceParam {
    enum ConditionTable {
        Health20 = 0,
        Health50 = 1,
    };
}
namespace app::CH8VoiceOxygenRemainingAmount::CH8VoiceParam {
    enum ConditionTable {
        Air20 = 0,
        Air30 = 1,
        Air50 = 2,
    };
}
namespace app::CH9MessageController::MessageInfoListCtrl {
    enum PlayType {
        Default = 0,
        RandomOnce = 1,
        RandomLoop = 2,
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
namespace app::CH9EnemyOrder::FinishBlowInfo {
    enum InputButton {
        AttackRight = 0,
        AttackLeft = 1,
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
namespace app::CH9Em5800Order::Appear {
    enum Type {
        Idle = 0,
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
namespace app::CH9Em5901Order::Appear {
    enum Type {
        Idle = 0,
    };
}
namespace app::CH9Em7700ActionController::BattleCondition {
    enum WanderIdleActionType {
        None = 0,
        AfterNotice = 1,
        BeforeNotice = 2,
    };
}
namespace app::CH9Em7800ActionController::BattleCondition {
    enum WanderIdleActionType {
        None = 0,
        AfterNotice = 1,
        BeforeNotice = 2,
    };
}
namespace app::CH9MoldedActionController::BattleConditionBase {
    enum FinishBlowResult {
        None = 0,
        Dead = 1,
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
namespace app::CH9RewardData::RewardData {
    enum Type {
        Difficulty = 0,
        Item = 1,
        Everywhere = 2,
        Weapon = 3,
    };
}
namespace app::EffectSphereHolder::SphereInfo {
    enum Status {
        Start = 0,
        Update = 1,
        End = 2,
    };
}
namespace app::EPVStandardData::Element {
    enum HideModeForVREnum {
        None = 0,
        HideOn3DVR = 1,
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
namespace app::Em8000BattleDirective::ScissorsBattleParameter {
    enum ChainsawEngineDamageTrigger {
        None = 0,
        Grapple_BattleOfSaw = 1,
        RepelPlayerChainsawAttack = 2,
    };
}
namespace app::SmoothAnimatorTransitionTable::SubItem {
    enum Classification {
        Everything = 0,
        MotionGroup = 1,
    };
}
namespace app::vr::VrSettingData::Camera {
    enum CameraPositionType {
        Original = 0,
        UseXZRoot = 1,
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
namespace app::Collision::HitController::DamageInfo {
    enum Attribution {
        None = 0,
        Fire = 1,
        Acid = 2,
    };
}
namespace app::Collision::HitController::DamageInfo {
    enum Scale {
        L = 0,
        M = 1,
        S = 2,
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
namespace app::Em8001::Em8001ActionController::ProgramableTurnProcess {
    enum RatioUpdateType {
        Time = 0,
    };
}
namespace app::Em8001::Em8001Order::Appear {
    enum Type {
        None = 0,
    };
}
namespace app::Em8001::Em8001BattleDirective::ScissorsBattleParameter {
    enum ChainsawEngineDamageTrigger {
        None = 0,
        Grapple_BattleOfSaw = 1,
        RepelPlayerChainsawAttack = 2,
    };
}
namespace app::Em8001::Motion::Em8001MotionID::Type {
    enum UpperOverride {
        None = 0,
        Gesture = 1,
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
namespace app::Em8000::Em8000Define::Grapple {
    enum FsmState {
        Start = 0,
        Loop = 1,
        End = 2,
        INVALID = 3,
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
namespace app::Em8000::Motion::Em8000MotionID::Type {
    enum UpperOverride {
        None = 0,
        Gesture = 1,
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
namespace app::Em3102::Em3102Order::Appear {
    enum Type {
        None = 0,
    };
}
namespace app::Em3000::Em3000ActionController::ProgramableTurnProcess {
    enum RatioUpdateType {
        Time = 0,
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
namespace app::AI::AIWanderHelper::StartNodeParamInfo {
    enum DirectionPriority {
        Nothing = 0,
        Front = 1,
        Back = 2,
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
namespace app::fsm::PositionCheck::CameraParam {
    enum CameraTargetSetting {
        TargetObject = 0,
        OwnerObject = 1,
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
