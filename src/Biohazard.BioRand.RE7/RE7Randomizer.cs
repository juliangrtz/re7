using Biohazard.BioRand.RE7.Modifiers;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Cryptography;
using System.Collections.Immutable;
using System.Threading;

namespace Biohazard.BioRand.RE7;

internal class RE7Randomizer : IDisposable
{
    private readonly string _inputGamePath;
    private FileRepository _fileRepository = new FileRepository();
    private ImmutableArray<Modifier> _modifiers = GetModifiers();
    private readonly Dictionary<Type, object> _services = [];
    private readonly Lock _servicesLock = new();
    private readonly Dictionary<string, string> _logFiles = [];

    public int PakVersion { get; set; } = 2;
    public RandomizerInput Input { get; }
    public IProgressReporter Reporter { get; }
    public FileRepository FileRepository => _fileRepository;
    public DynamicData DynamicData { get; }

    public ItemRandomizer ItemRandomizer => GetService<ItemRandomizer>();

    public static string BuildVersion => RE7RandomizerFactory.Default.GitHash;
    public static RandomizerConfigurationDefinition ConfigurationDefinition => RE7RandomizerConfigurationDefinition.Create();
    public static RandomizerConfiguration DefaultConfiguration => RE7RandomizerConfigurationDefinition.Create().GetDefault();

    // These options must be bools!
    private static readonly string[] _optionsThatRequireREFramework = [
        "debug-force-reframework",
        "recipes-add-new",
        "recipes-replace-original"
    ];

    public RE7Randomizer(RandomizerInput input, string inputGamePath, IProgressReporter reporter)
    {
        Input = input;
        _inputGamePath = inputGamePath;
        Reporter = reporter;
        DynamicData = new DynamicData(
#if ENABLE_BETA_FEATURES
            Input.Configuration.GetValueOrDefault<bool>("debug-download-data")
#else
            false
#endif
        );
        PakPath.IsOnRT = IsOnRaytracingVersion;
    }

    public void Dispose()
    {
        _fileRepository?.Dispose();
    }

    public RandomizerOutput Randomize()
    {
        var input = Input;
        _fileRepository = new FileRepository(this, _inputGamePath, DynamicData);

        var log = Randomize(input);
        AddLogFile($"input.log", log.Input.Output);
        AddLogFile($"process.log", log.Process.Output);
        AddLogFile($"output.log", log.Output.Output);

        RandomizerOutput? result = null;
        Reporter.RunTask("Building mod", () =>
        {
            var isWithREFramework = _optionsThatRequireREFramework.Any(option => GetConfigOption<bool>(option))
                                        || GetConfigOption<string>("random-starting-inventory-size-ethan") != "12" // TODO: This smells, improve
                                        || GetConfigOption<string>("random-starting-inventory-size-mia") != "12";
            var output = new RE7RandomizerOutput(input, _fileRepository.GetOutputPakFile(), _logFiles, PakVersion, isWithREFramework);
            result = new RandomizerOutput(
                [
                    new RandomizerOutputAsset(
                        "1-patch",
                        "Patch",
                        "Simply drop this file into your RE 7 install folder.",
                        $"biorand-re7-{input.Seed}.zip",
                        output.GetOutputZip()),
                    new RandomizerOutputAsset(
                        "2-fluffy",
                        "Fluffy Mod",
                        "Drop this zip file into Fluffy Mod Manager's mod folder and enable it.",
                        $"biorand-re7-{input.Seed}-mod.zip",
                        output.GetOutputMod())
                ],
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

    public RandomizerLoggerIO Randomize(RandomizerInput input)
    {
        _modifiers = GetModifiers();

        var logger = new RandomizerLoggerIO();
        foreach (var l in new[] { logger.Input, logger.Process, logger.Output })
        {
            l.LogHr();
            l.LogVersion();
            l.LogLine($"Seed = {input.Seed}");
            l.LogHr();
        }

        // Patches
        Reporter.RunTask("Applying patches", () => ExportedMods.ApplyAll(this, FileRepository));

        // Input
        IterateModifiers((n, m) =>
        {
            logger.Input.Push(n);
            m.LogState(this, logger.Input);
            logger.Input.Pop();
            logger.Input.LogHr();
        });

        // Apply modifiers
        IterateModifiers((n, m) =>
        {
            logger.Process.Push(n);
            Reporter.RunTask($"Running modifier: {n}", () => m.Apply(this, logger.Process));
            logger.Process.Pop();
            logger.Process.LogHr();
        });

        // Output
        IterateModifiers((n, m) =>
        {
            logger.Output.Push(n);
            m.LogState(this, logger.Output);
            logger.Output.Pop();
            logger.Output.LogHr();
        });

        return logger;
    }

    private void IterateModifiers(Action<string, Modifier> action)
    {
        foreach (var modifier in _modifiers)
        {
            var name = modifier.GetType().Name.Replace("Modifier", "");
            action(name, modifier);
        }
    }

    private static ImmutableArray<Modifier> GetModifiers()
    {
        return
        [
            new InventoryModifier(),
            new RecipeModifier(),
        ];
    }

    public string User => GetConfigOption<string>("username") ?? "player";
    public int Seed => Input.Seed;

    public Rng GetRng(params object[] key)
    {
        var hashInput = string.Concat([Input.Seed, .. key]);
        var seed = MurMur3.HashData(hashInput);
        return new Rng(seed);
    }

    public T? GetConfigOption<T>(string key, T? defaultValue = default)
    {
        if (Input.Configuration == null)
            return defaultValue;
        return Input.Configuration.GetValueOrDefault<T>(key, defaultValue);
    }

    public T? GetEnumConfigOption<T>(string key) where T : struct, Enum
    {
        var value = Input.Configuration.GetValueOrDefault<string>(key);
        if (Input.Configuration == null || value == null)
            return default;

        return EnumExtensions.ParseOrNull<T>(value);
    }

    public bool IsOnRaytracingVersion
        => GetConfigOption<string>("game-version") == "dx12_rt";

    public string RaytracingString
        => IsOnRaytracingVersion ? "rt" : "";

    public bool HasSpecialTouch(string kind)
    {
        if (!GetConfigOption("enable-special", true))
            return false;

        var special = GetConfigOption<string>("special");
        var present = special?.Split(',').Contains(kind) == true;
        return present;
    }

    public T GetService<T>()
    {
        using var scope = _servicesLock.EnterScope();
        var type = typeof(T);
        _services.TryGetValue(type, out var service);
        if (service == null)
        {
            service = Activator.CreateInstance(type, [this])!;
            _services[type] = service;
        }
        return (T)service;
    }

    public void AddLogFile(string name, string content)
    {
        _logFiles[name] = content;
    }
}