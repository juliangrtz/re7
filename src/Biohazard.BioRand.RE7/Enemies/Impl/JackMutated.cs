using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class JackMutated : IEnemyDefinition {
    internal static readonly IReadOnlyList<EnemyHealthPart> PartHealth =[
        new("JackMutated-eye-1", "Eye 1", 1600),
        new("JackMutated-eye-2", "Eye 2", 1200),
        new("JackMutated-eye-3", "Eye 3", 1200),
        new("JackMutated-eye-4", "Eye 4", 1200),
        new("JackMutated-eye-5", "Eye 5", 500),
        new("JackMutated-eye-6", "Eye 6", 1000),
        new("JackMutated-eye-7", "Eye 7", 800),
        new("JackMutated-eye-8", "Eye 8", 500),
        new("JackMutated-final-eye", "Final Eye", 1500),
    ];

    public string Id => "JackMutated";

    public EnemyID EnemyId => EnemyID.Em8100;

    public EnemyCategory Category => EnemyCategory.Jack;

    public string Name => "Jack Baker (Mutated)";

    public bool IsBoss => true;

    public int BaseHealth => 30000;

    public IReadOnlyList<EnemyHealthPart> HealthParts => PartHealth;

    public List<string> RcolPaths =>[
        PakPath.RcolFile("collision/collider/enemy/em8100/em8100.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8100/em8100deadbody.rcol.20"),
    ];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em8100/parameter/directive/em8100directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em8100/parameter/resist/em8100resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em8100.scn");

    public bool UsesEnemyGenerator => false;

    public bool SupportsRandomEnemyPlacement => false;
}

internal class JackMutatedDirectiveModifier : IDirectiveModifier {
    private const string DirectiveFolder = "prefab/character/em8100/parameter/directive";

    private static readonly IReadOnlyDictionary<string, string> HealthPartPaths =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase){
            ["JackMutated-eye-1"] = "weak.WeakInfoList[0].MaxHealth",
            ["JackMutated-eye-2"] = "weak.WeakInfoList[1].MaxHealth",
            ["JackMutated-eye-3"] = "weak.WeakInfoList[2].MaxHealth",
            ["JackMutated-eye-4"] = "weak.WeakInfoList[3].MaxHealth",
            ["JackMutated-eye-5"] = "weak.WeakInfoList[4].MaxHealth",
            ["JackMutated-eye-6"] = "weak.WeakInfoList[5].MaxHealth",
            ["JackMutated-eye-7"] = "weak.WeakInfoList[6].MaxHealth",
            ["JackMutated-eye-8"] = "weak.WeakInfoList[7].MaxHealth",
            ["JackMutated-final-eye"] = "weak.LastWeakMaxHealth",
        };

    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em8100;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger) {
        if (!enemy.ShouldRandomizeHealth(randomizer)) {
            logger.LogSkip("Boss health randomization is disabled.");
            return;
        }

        var rng = randomizer.GetRng("enemy/em8100/health");
        var healthValues = enemy.HealthParts
            .ToDictionary(
                part => part.ConfigId,
                part => enemy.GetHealth(randomizer, rng, part),
                StringComparer.OrdinalIgnoreCase);

        foreach (var part in enemy.HealthParts) {
            logger.LogHealthAssignment(part.Label, part.BaseHealth, healthValues[part.ConfigId]);
        }

        foreach (var (label, path) in GetDirectiveFiles()) {
            logger.LogDirectiveFile(label, path, () => randomizer.FileRepository.ModifyUserFile(path, directive => {
                foreach (var part in enemy.HealthParts) {
                    var fieldPath = HealthPartPaths[part.ConfigId];
                    var oldHealth = directive.Get<float>(fieldPath);
                    var newHealth = healthValues[part.ConfigId];
                    directive = directive.Set(fieldPath, newHealth);
                    logger.LogChange(part.Label, oldHealth, newHealth);
                }

                return directive;
            }));
        }
    }

    private static IEnumerable<(string Label, string Path)> GetDirectiveFiles() {
        yield return ("Default", PakPath.UserFile($"{DirectiveFolder}/em8100battledirective.user"));

        for (var rank = 0; rank <= 9; rank++) {
            yield return ($"Rank {rank}", PakPath.UserFile($"{DirectiveFolder}/em8100battledirectiverank{rank}.user"));
        }
    }
}