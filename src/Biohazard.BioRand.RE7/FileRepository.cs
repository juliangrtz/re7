using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7;

internal class FileRepository : IPatchContext, IDisposable
{
    private readonly record struct FileCacheEntry(bool Exists, byte[] Data);

    public static RszTypeRepository RszRepository { get; private set; }

    public RszTypeRepository TypeRepository => RszRepository;
    public bool ExportingMod => false;

    private readonly Randomizer? _randomizer;
    private readonly PatchedPakFile? _inputPakFile;
    private readonly string? _inputGamePath;
    private readonly ConcurrentDictionary<string, FileCacheEntry> _inputFiles = new(StringComparer.OrdinalIgnoreCase);
    private readonly ConcurrentDictionary<string, byte[]> _outputFiles = new(StringComparer.OrdinalIgnoreCase);

    public Randomizer? Randomizer => _randomizer;
    public DynamicData DynamicData { get; } = new DynamicData(download: false);

    public FileRepository()
    {
    }

    public FileRepository(PatchedPakFile inputPakFile, DynamicData dynamicData)
    {
        _inputPakFile = inputPakFile;
        DynamicData = dynamicData;
    }

    public FileRepository(Randomizer randomizer, string inputGamePath, DynamicData dynamicData)
    {
        _randomizer = randomizer;
        if (inputGamePath.EndsWith(".pak", System.StringComparison.OrdinalIgnoreCase))
        {
            _inputPakFile = new PatchedPakFile(inputGamePath);
        }
        else
        {
            _inputGamePath = inputGamePath;
        }
        DynamicData = dynamicData;

        if (RszRepository == null)
        {
            var rszJson = EmbeddedData.GetFile("rszre7rt.json");
            RszRepository = RszRepositorySerializer.Default.FromJson(rszJson);
        }
    }

    public void Dispose()
    {
        _inputPakFile?.Dispose();
    }

    public byte[] GetSupplementFile(string path)
    {
        return EmbeddedData.GetFile(path);
    }

    public byte[]? GetFile(string path)
    {
        if (_outputFiles.TryGetValue(path, out var data))
            return data;

        var entry = _inputFiles.GetOrAdd(path, LoadInputFile);
        return entry.Exists ? entry.Data : null;
    }

    public void SetFile(string path, byte[] data)
    {
        _outputFiles[path] = data;
    }

    internal ImmutableDictionary<string, byte[]> GetOutputFilesSnapshot()
    {
        return _outputFiles.ToImmutableDictionary(
            x => x.Key,
            x => x.Value.ToArray(),
            StringComparer.OrdinalIgnoreCase
        );
    }

    public void WriteOutputPakFile(string path)
    {
        var builder = new PakFileBuilder();
        foreach (var outputFile in _outputFiles)
        {
            builder.AddEntry(outputFile.Key, outputFile.Value);
        }
        builder.Save(path, CompressionKind.Zstd);
    }

    public PakFileBuilder GetOutputPakFile()
    {
        var builder = new PakFileBuilder();
        foreach (var outputFile in _outputFiles)
        {
            builder.AddEntry(outputFile.Key, outputFile.Value);
        }
        return builder;
    }

    public void WriteOutputFolder(string path)
    {
        foreach (var outputFile in _outputFiles)
        {
            var fullPath = Path.Combine(path, outputFile.Key);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
            File.WriteAllBytes(fullPath, outputFile.Value);
        }
    }

    public T? GetConfigOption<T>(string key, T? defaultValue = default)
    {
        var randomizer = _randomizer;
        return randomizer == null ? defaultValue : randomizer.GetConfigOption(key, defaultValue);
    }

    private FileCacheEntry LoadInputFile(string path)
    {
        if (_inputGamePath == null)
        {
            var data = _inputPakFile?.GetEntryData(path);
            return data == null
                ? new FileCacheEntry(false, Array.Empty<byte>())
                : new FileCacheEntry(true, data);
        }

        var fullPath = Path.Combine(_inputGamePath, path);
        if (!File.Exists(fullPath))
        {
            return new FileCacheEntry(false, Array.Empty<byte>());
        }

        return new FileCacheEntry(true, File.ReadAllBytes(fullPath));
    }
}
