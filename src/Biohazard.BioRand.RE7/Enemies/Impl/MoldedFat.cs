using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MoldedFat : IEnemyDefinition {
    internal static readonly IReadOnlyList<EnemyHealthPart> PartHealth =[
        new("MoldedFat", "Molded (Fat)", 6000),
        new("MoldedFat-lost-head", "Lost Head", 2000),
        new("MoldedFat-lost-left-arm", "Lost Left Arm", 1000),
        new("MoldedFat-lost-right-arm", "Lost Right Arm", 1000),
        new("MoldedFat-lost-left-leg", "Lost Left Leg", 2000),
        new("MoldedFat-lost-right-leg", "Lost Right Leg", 2000),
    ];

    public string Id => "MoldedFat";

    public EnemyID EnemyId => EnemyID.Em4200;

    public EnemyCategory Category => EnemyCategory.Molded;

    public string Name => "Molded (Fat)";

    public bool IsBoss => false;

    public int BaseHealth => 6000;

    public IReadOnlyList<EnemyHealthPart> HealthParts => PartHealth;

    public List<string> RcolPaths =>[
        "collision/collider/enemy/em4200/em4200.rcol".RcolFile(),
        "collision/collider/enemy/em4200/em4200explosionattack.rcol".RcolFile(),
        "collision/collider/enemy/em4200/em4200splashattack.rcol".RcolFile(),
    ];

    public string DirectivesHolderPath
        => "prefab/character/em4200/parameter/directive/em4200directivesholder.user".UserFile();

    public string ResistParamsHolderPath
        => "prefab/character/em4200/parameter/resist/em4200resistparameterholder.user".UserFile();

    public string OriginalPrefabPath
        => $"scenes/enemy/em4200.scn".SceneFile();

    public bool UsesEnemyGenerator => true;
}

internal class MoldedFatDirectiveModifier : IDirectiveModifier {
    private static readonly IReadOnlyDictionary<string, string> LostPartHealthPaths =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase){
            ["MoldedFat-lost-head"] = "units[2].parts[0].healthUnits[0].healthMax",
            ["MoldedFat-lost-left-arm"] = "units[2].parts[1].healthUnits[0].healthMax",
            ["MoldedFat-lost-right-arm"] = "units[2].parts[2].healthUnits[0].healthMax",
            ["MoldedFat-lost-left-leg"] = "units[2].parts[3].healthUnits[0].healthMax",
            ["MoldedFat-lost-right-leg"] = "units[2].parts[4].healthUnits[0].healthMax",
        };

    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em4200;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger) {
        if (!enemy.ShouldRandomizeHealth(randomizer)) {
            logger.LogSkip("Enemy health randomization is disabled.");
            return;
        }

        var rng = randomizer.GetRng("enemy/em4200/health");
        var healthValues = enemy.HealthParts
            .Where(part => LostPartHealthPaths.ContainsKey(part.ConfigId))
            .ToDictionary(
                part => part.ConfigId,
                part => enemy.GetHealth(randomizer, rng, part),
                StringComparer.OrdinalIgnoreCase);

        foreach (var part in enemy.HealthParts.Where(part => healthValues.ContainsKey(part.ConfigId))) {
            logger.LogHealthAssignment(part.Label, part.BaseHealth, healthValues[part.ConfigId]);
        }

        foreach (var (label, path) in GetResistFiles()) {
            logger.LogDirectiveFile(label, path, () => randomizer.FileRepository.ModifyUserFile(path,
                resistParameter => {
                    foreach (var part in enemy.HealthParts.Where(part => healthValues.ContainsKey(part.ConfigId))) {
                        var fieldPath = LostPartHealthPaths[part.ConfigId];
                        var oldHealth = resistParameter.Get<float>(fieldPath);
                        var newHealth = healthValues[part.ConfigId];
                        resistParameter = resistParameter.Set(fieldPath, newHealth);
                        logger.LogChange(part.Label, oldHealth, newHealth);
                    }

                    return resistParameter;
                }));
        }
    }

    private static IEnumerable<(string Label, string Path)> GetResistFiles() {
        yield return ("Default",
            "prefab/character/em4200/parameter/resist/em4200resistparameter_04.user".UserFile());
        yield return ("Chapter 3/4 boss",
            "prefab/character/em4200/parameter/resist/chp3_4_boss/em4200resistparameter.user".UserFile());
    }
}