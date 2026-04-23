using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Services;
using Biohazard.BioRand.RE7;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;
using System.IO.Compression;

namespace Biohazard.BioRand.RE7.Tests;

public static class RandomizerTest
{
    private static readonly string BiorandDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        ".biorand"
    );

    private const string PAKName = "biorand-re7.pak";

    private static readonly string PAKPath = Path.Combine(
        BiorandDirectory,
        PAKName
    );

    static RandomizerTest()
    {
        if (!Directory.Exists(BiorandDirectory))
        {
            Directory.CreateDirectory(BiorandDirectory);
        }

        if (!File.Exists(PAKPath))
        {
            File.WriteAllBytes(PAKPath, EmbeddedData.GetFile(PAKName));
        }
    }

    private static readonly RandomizerExecutor executor = new(PAKPath, new EmptyReporter());
    private const int DefaultTestingSeed = 0x42424242;

    public static string InputPakPath => PAKPath;

    public static RandomizerConfiguration CreateFeatureTestConfiguration(Action<RandomizerConfiguration>? configure = null)
    {
        var configuration = RandomizerExecutor.DefaultConfiguration;

        configuration["debug-download-data"] = false;

        configuration["randomized-messages"] = false;
        configuration["random-enemies"] = false;
        configuration["extra-enemy-amount"] = 0.0;
        configuration["enemy-multiplier"] = 1.0;

        configuration["random-items"] = false;
        configuration["random-key-item-locations"] = false;
        configuration["replace-madhouse-tapes"] = false;
        configuration["replace-weapons"] = false;
        configuration["random-bird-cage-magnum"] = false;
        configuration["random-bird-cage-drugs-coins"] = false;
        configuration["additional-items"] = false;
        configuration["additional-wooden-crates"] = false;

        configuration["random-starting-inventory-ethan"] = false;
        configuration["random-starting-inventory-mia"] = false;
        configuration["random-starting-inventory-vhs"] = false;

        configuration["recipes-add-new"] = false;

        configuration["weapon-mod-damage"] = false;
        configuration["weapon-mod-ammo-capacity"] = false;
        configuration["weapon-mod-reload-speed"] = false;

        configure?.Invoke(configuration);
        return configuration;
    }

    public static (ZipArchive, PakFile) Run(string configJson, int seed = DefaultTestingSeed)
    {
        var input = new RandomizerInput()
        {
            Seed = seed,
            Configuration = RandomizerConfiguration.FromJson(configJson)
        };

        var output = executor.Randomize(input);
        Assert.NotNull(output);

        var zipAsset = output.Assets.FirstOrDefault(asset => asset.Key == "1-patch")?.Data.Unzip();
        Assert.NotNull(zipAsset);

        return (
            zipAsset,
            new PakFile(
                zipAsset
                .Entries
                .Single(entry => entry.Name.EndsWith(".pak"))
                .GetBytes()
            )
        );
    }

    internal static RandomizerRunResult RunState(
        Action<RandomizerConfiguration>? configure = null,
        int seed = DefaultTestingSeed,
        Action<Randomizer>? prepareRandomizer = null)
    {
        var configuration = CreateFeatureTestConfiguration(configure);
        var input = new RandomizerInput()
        {
            Seed = seed,
            UserName = "behavior-tests",
            ProfileName = "Behavior Tests",
            ProfileAuthor = "xUnit",
            ProfileDescription = "Randomizer behavior test profile.",
            Configuration = configuration
        };

        var randomizer = new Randomizer(input, PAKPath, new EmptyReporter());
        prepareRandomizer?.Invoke(randomizer);
        var beforeRepository = new FileRepository(randomizer, PAKPath, randomizer.DynamicData);
        randomizer.Randomize();

        return new RandomizerRunResult(randomizer, beforeRepository);
    }
}

public sealed class RandomizerRunResult : IDisposable
{
    private readonly Randomizer _randomizer;
    private readonly FileRepository _beforeRepository;

    internal RandomizerRunResult(Randomizer randomizer, FileRepository beforeRepository)
    {
        _randomizer = randomizer;
        _beforeRepository = beforeRepository;
        ChangedFiles = _randomizer.FileRepository.GetOutputFilesSnapshot();
    }

    public ImmutableDictionary<string, byte[]> ChangedFiles { get; }
    internal Randomizer Randomizer => _randomizer;
    internal ItemRandomizer ItemRandomizer => _randomizer.ItemRandomizer;
    internal ItemPlacementService ItemPlacementService => _randomizer.ItemPlacementService;
    internal AreaService AreaService => _randomizer.AreaService;
    public string ProcessLog => _randomizer.LastLog?.Process.Output ?? string.Empty;

    public byte[] ReadBeforeBytes(string path)
        => _beforeRepository.GetFile(path) ?? throw new InvalidOperationException($"Missing baseline file '{path}'.");

    public byte[] ReadAfterBytes(string path)
        => _randomizer.FileRepository.GetFile(path) ?? throw new InvalidOperationException($"Missing output file '{path}'.");

    public T ReadBeforeUserFile<T>(string path) => _beforeRepository.DeserializeUserFile<T>(path);

    public T ReadAfterUserFile<T>(string path) => _randomizer.FileRepository.DeserializeUserFile<T>(path);

    public MsgFile ReadBeforeMsgFile(string path) => _beforeRepository.GetMsgFile(path);

    public MsgFile ReadAfterMsgFile(string path) => _randomizer.FileRepository.GetMsgFile(path);

    public RszScene ReadBeforeScene(string path)
        => _beforeRepository.GetScnFile(path).ReadScene(_beforeRepository.TypeRepository);

    public RszScene ReadAfterScene(string path)
        => _randomizer.FileRepository.GetScnFile(path).ReadScene(_randomizer.FileRepository.TypeRepository);

    public bool WasFileModified(string path) => ChangedFiles.ContainsKey(path);

    public void Dispose()
    {
        _beforeRepository.Dispose();
        _randomizer.Dispose();
    }
}
