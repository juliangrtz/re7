using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Concurrent;
using System.Text;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal sealed class AreaSceneTargetsGenerator : IFileGenerator
{
    public string Id => "area_scene_targets";
    public bool CopyToDataDirectory => true;

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json.gz").Ungzip());

    private readonly PakFile _pakFile = Constants.BioRandPakFile;

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    public object Generate(GenerateCommand.GenerateSettings settings)
    {
        var areaDefinitions = ((IEnumerable<AreaDefinition>)new AreaGenerator().Generate(settings)).ToList();
        var hashByPath = _pakFile.FileHashes
            .Select(hash => (Hash: hash, Path: _pakList.GetPath(hash)))
            .Where(x => x.Path != null)
            .ToDictionary(x => x.Path!, x => x.Hash, StringComparer.OrdinalIgnoreCase);
        var results = new ConcurrentBag<AreaSceneTargets>();

        Parallel.ForEach(areaDefinitions, definition =>
        {
            if (!hashByPath.TryGetValue(definition.Path, out var hash))
                return;

            var targets = ReadTargets(definition.Path, hash);
            if (targets.HasAnyTargets())
            {
                results.Add(targets);
            }
        });

        return results
            .OrderBy(targets => targets.Path, StringComparer.Ordinal)
            .ToList();
    }

    private AreaSceneTargets ReadTargets(string path, ulong hash)
    {
        var scene = new ScnFile(FileVersions.SceneFileVersion, _pakFile.GetEntryData(hash))
            .ReadScene(_rszRepository);
        var itemGuids = new List<Guid>();
        var weaponGuids = new List<Guid>();
        var enemyGeneratorGuids = new List<Guid>();
        var enemySpawnInfoGuids = new List<Guid>();
        var enemyGenerateGuids = new List<Guid>();

        scene.VisitGameObjects(gameObject =>
        {
            if (gameObject.FindComponent<app.Item>() != null)
            {
                itemGuids.Add(gameObject.Guid);
            }

            if (gameObject.FindComponent<app.Weapon>() != null ||
                gameObject.FindComponent<app.WeaponGun>() != null)
            {
                weaponGuids.Add(gameObject.Guid);
            }

            var enemyGenerator = gameObject.FindComponent<app.EnemyGenerator>();
            if (enemyGenerator?.Enabled == true)
            {
                enemyGeneratorGuids.Add(gameObject.Guid);
            }

            var enemySpawnInfo = gameObject.FindComponent<app.EnemySpawnInfo>();
            if (enemySpawnInfo?.Enabled == true)
            {
                enemySpawnInfoGuids.Add(gameObject.Guid);
            }

            if (HasEnemyGenerateAction(gameObject))
            {
                enemyGenerateGuids.Add(gameObject.Guid);
            }
        });

        return new AreaSceneTargets
        {
            Path = path,
            ItemGuids = NullIfEmpty(itemGuids),
            WeaponGuids = NullIfEmpty(weaponGuids),
            EnemyGeneratorGuids = NullIfEmpty(enemyGeneratorGuids),
            EnemySpawnInfoGuids = NullIfEmpty(enemySpawnInfoGuids),
            EnemyGenerateGuids = NullIfEmpty(enemyGenerateGuids),
        };
    }

    private static bool HasEnemyGenerateAction(RszGameObject gameObject)
    {
        if (gameObject.FindComponent("via.fsm.Fsm") == null ||
            gameObject.FindComponent("app.TriggerInAction") == null)
        {
            return false;
        }

        var result = false;
        gameObject.Visit(node =>
        {
            if (node is RszObjectNode objectNode &&
                objectNode.Type.Name == "app.fsm.EnemyGenerate")
            {
                result = true;
            }
        });
        return result;
    }

    private static List<Guid>? NullIfEmpty(List<Guid> values)
        => values.Count == 0 ? null : values;
}
