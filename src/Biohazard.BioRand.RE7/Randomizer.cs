using Biohazard.BioRand.RE7.Modifiers;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Cryptography;
using System.Collections.Immutable;
using System.Threading;

namespace Biohazard.BioRand.RE7;

internal class Randomizer : IDisposable {
    private readonly string _inputGamePath;
    private FileRepository _fileRepository = new();
    private ImmutableArray<Modifier> _modifiers = GetModifiers();
    private readonly Dictionary<Type, object> _services = [];
    private readonly Lock _servicesLock = new();
    private readonly Dictionary<string, string> _logFiles = [];

    public int PakVersion { get; set; } = 1;
    public RandomizerInput Input { get; }
    public IProgressReporter Reporter { get; }
    public FileRepository FileRepository => _fileRepository;
    public DynamicData DynamicData { get; }
    internal bool CaptureStateLogs { get; set; } = true;
    internal RandomizerLoggerIO? LastLog { get; private set; }

    public static string BuildVersion => RandomizerFactory.Default.GitHash;

    public static IntelOrca.Biohazard.BioRand.RandomizerConfigurationDefinition ConfigurationDefinition =>
        RandomizerConfigurationDefinition.Create();

    public static RandomizerConfiguration DefaultConfiguration =>
        RandomizerConfigurationDefinition.Create().GetDefault();

    private static readonly string[] _optionsThatRequireREFramework =[
        "debug-force-reframework",
        "madhouse-normal-saves",
        "inventory-unrestricted-management",
        "random-events",
        "random-starting-inventory-skills-ethan",
        "random-starting-inventory-skills-mia",
        "recipes-add-new",
        "weapon-mod-reload-speed",
    ];

    private bool IsREFrameworkRequired()
        => GetConfigOption<bool>("random-enemies")
           || GetConfigOption<bool>("random-enemy-drops")
           || GetConfigOption<bool>("allow-dlc-items")
           || _optionsThatRequireREFramework.Any(option => GetConfigOption<bool>(option))
           || GetConfigOption<string>("random-starting-inventory-size-ethan") != "12"
           || GetConfigOption<string>("random-starting-inventory-size-mia") != "12";

    public Randomizer(RandomizerInput input, string inputGamePath, IProgressReporter reporter) {
        Input = input;
        _inputGamePath = inputGamePath;
        Reporter = reporter;

        DynamicData = new DynamicData(Input.Configuration.GetValueOrDefault<bool>("debug-download-data"));
    }

    public void Dispose() {
        _fileRepository?.Dispose();
    }

    public IntelOrca.Biohazard.BioRand.RandomizerOutput Randomize() {
        var input = Input;
        _fileRepository = new FileRepository(this, _inputGamePath, DynamicData);

        var log = Randomize(input);
        AddLogFile($"input.log", log.Input.Output);
        AddLogFile($"process.log", log.Process.Output);
        AddLogFile($"output.log", log.Output.Output);

        IntelOrca.Biohazard.BioRand.RandomizerOutput? result = null;
        Reporter.RunTask("Building mod", () => {
            var output = new RandomizerOutput(
                input,
                _fileRepository.GetOutputPakFile(),
                _fileRepository.GetAdditionalOutputPakFile(),
                _logFiles,
                PakVersion,
                IsREFrameworkRequired()
            );
            var assets = new List<RandomizerOutputAsset>{
                new(
                    "1-patch",
                    "Patch",
                    "Simply drop this file into your RE 7 install folder.",
                    $"biorand-re7-{input.Seed}.zip",
                    output.GetOutputZip()),
                new(
                    "2-fluffy",
                    "Fluffy Mod",
                    "Drop this zip file into Fluffy Mod Manager's mod folder and enable it.",
                    $"biorand-re7-{input.Seed}-mod.zip",
                    output.GetOutputMod())
            };
            if (output.HasAdditionalAssets) {
                assets.Add(new RandomizerOutputAsset(
                    "3-assets",
                    $"Additional Assets (Version ${output.AdditionalAssetPakVersion})",
                    "Required for large optional assets, such as Jack's 55th Birthday skill patches. " +
                    "You only have to download and install this if you want to use the additional assets. " +
                    "Only needs to be updated if the version changes.",
                    $"biorand-re7-assets-{output.AdditionalAssetPakVersion}.zip",
                    output.GetAdditionalAssetsZip()));
            }

            result = new IntelOrca.Biohazard.BioRand.RandomizerOutput(
                assets.ToImmutableArray(),
                """
                <p class="mt-3">What should I do if my game crashes?</p>
                <ol class="list-decimal text-gray-300" style="margin-left: 3rem;">
                  <li>Reload from last checkpoint and try again.</li>
                  <li>Alter the enemy sliders slightly or reduce the number temporarily. This will reshuffle the enemies. Reload from last checkpoint and try again.</li> <li>As a last resort, change your seed, and reload from last checkpoint.</li>
                </ol>
                """);
        });
        return result!;
    }

    public RandomizerLoggerIO Randomize(RandomizerInput input) {
        _modifiers = GetModifiers();

        var logger = new RandomizerLoggerIO();
        foreach (var l in new[]{ logger.Input, logger.Process, logger.Output }) {
            l.LogHr();
            l.LogVersion();
            l.LogLine($"Seed = {input.Seed}");
            l.LogHr();
        }

        if (DynamicData.DownloadEnabled) {
            Reporter.RunTask("Downloading latest spreadsheet data from Google Sheets", DynamicData.PrefetchAll);
        }

        // Patches
        Reporter.RunTask("Applying patches", () => ExportedMods.ApplyAll(this, FileRepository));

        if (CaptureStateLogs) {
            // Input
            IterateModifiers((n, m) => {
                logger.Input.Push(n);
                m.LogState(this, logger.Input);
                logger.Input.Pop();
                logger.Input.LogHr();
            });
        } else {
            logger.Input.LogLine("State logging disabled.");
            logger.Input.LogHr();
        }

        // Apply modifiers
        IterateModifiers((n, m) => {
            logger.Process.Push(n);
            Reporter.RunTask($"Running modifier: {n}", () => m.Apply(this, logger.Process));
            logger.Process.Pop();
            logger.Process.LogHr();
        });

        // Save Flags
        FlagService.Save(logger.Process);

        if (CaptureStateLogs) {
            // Output
            IterateModifiers((n, m) => {
                logger.Output.Push(n);
                m.LogState(this, logger.Output);
                logger.Output.Pop();
                logger.Output.LogHr();
            });
        } else {
            logger.Output.LogLine("State logging disabled.");
            logger.Output.LogHr();
        }

        LastLog = logger;
        return logger;
    }

    private void IterateModifiers(Action<string, Modifier> action) {
        foreach (var modifier in _modifiers) {
            var name = modifier.GetType().Name.Replace("Modifier", "");
            action(name, modifier);
        }
    }

    private static ImmutableArray<Modifier> GetModifiers() {
        return[
            // Enemies
            new EnemyDirectiveModifier(),
            new EnemyModifier(),
            new EnemyMultiplierModifier(),
            new EnemyPlaceModifier(),

            // Inventory
            new StartingInventoryModifier(),
            new RecipeModifier(),
            new ItemStackModifier(),

            // Items
            new ExtraPlacementModifier(),
            new ItemModifier(),
            new BirdCageModifier(),
            new ItemDropTableModifier(),
            new LucasPuzzleInventoryModifier(),
            new KeyItemLocationModifier(),

            // Weapons
            new WeaponModifier(),

            // Misc.
            new MadhouseSaveModifier(),
            new ChapterJumpDataModifier(),
            new MessageModifier(),
            new UvarDefaultsModifier(),
        ];
    }

    public string User => GetConfigOption<string>("username") ?? "player";
    public List<string> UserTags => GetConfigOption<string>("tags")?.Split(",")?.ToList() ?? [];
    public int Seed => Input.Seed;

    public Rng GetRng(params object[] key) {
        var hashInput = string.Concat([Input.Seed, .. key]);
        var seed = MurMur3.HashData(hashInput);
        return new Rng(seed);
    }

    public T? GetConfigOption<T>(string key, T? defaultValue = default) {
        if (Input.Configuration == null)
            return defaultValue;
        return Input.Configuration.GetValueOrDefault<T>(key, defaultValue);
    }

    public T? GetEnumConfigOption<T>(string key) where T : struct, Enum {
        var value = Input.Configuration.GetValueOrDefault<string>(key);
        if (Input.Configuration == null || value == null)
            return default;

        return EnumExtensions.ParseOrNull<T>(value);
    }

    public bool HasSpecialTouch(string kind) {
        if (!GetConfigOption("enable-special", true))
            return false;

        var special = GetConfigOption<string>("special");
        var present = special?.Split(',').Contains(kind) == true;
        return present;
    }

    public T GetService<T>() {
        using var scope = _servicesLock.EnterScope();
        var type = typeof(T);
        _services.TryGetValue(type, out var service);
        if (service == null) {
            service = Activator.CreateInstance(type, [this])!;
            _services[type] = service;
        }

        return (T)service;
    }

    public TemplateService TemplateService => GetService<TemplateService>();
    public AreaService AreaService => GetService<AreaService>();
    public ItemRandomizer ItemRandomizer => GetService<ItemRandomizer>();
    public ItemPlacementService ItemPlacementService => GetService<ItemPlacementService>();

    public StaticItemRandomizationService StaticItemRandomizationService =>
        GetService<StaticItemRandomizationService>();

    public FlagService FlagService => GetService<FlagService>();
    public ChestService ChestService => GetService<ChestService>();
    public EnemySceneLimitService EnemySceneLimitService => GetService<EnemySceneLimitService>();

    public void AddLogFile(string name, string content) {
        _logFiles[name] = content;
    }
}