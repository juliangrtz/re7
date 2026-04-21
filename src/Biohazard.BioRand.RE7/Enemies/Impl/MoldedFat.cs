using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MoldedFat : IEnemyDefinition
{
    public string Id => "MoldedFat";

    public EnemyID EnemyId => EnemyID.Em4200;

    public EnemyCategory Category => EnemyCategory.Molded;

    public string Name => "Molded (Fat)";

    public bool IsBoss => false;

    public int BaseHealth => 6000;

    public List<string> RcolPaths => [
            PakPath.RcolFile("collision/collider/enemy/em4200/em4200.rcol"),
            PakPath.RcolFile("collision/collider/enemy/em4200/em4200explosionattack.rcol"),
            PakPath.RcolFile("collision/collider/enemy/em4200/em4200splashattack.rcol"),
    ];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em4200/parameter/directive/em4200directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em4200/parameter/resist/em4200resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em4200.scn");

    public bool UsesEnemyGenerator => true;
}
internal class MoldedFatDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em4200;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em4200");
        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em4200DirectivesHolder>(enemy.DirectivesHolderPath);

        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em4200BattleDirective>(
                userFilePath,
                d => ModifyDirective(d, logger)
            );
        }
    }

    private app.Em4200BattleDirective ModifyDirective(
        app.Em4200BattleDirective directive,
        RandomizerLogger logger)
    {
        // TODO: Make puke range configurable
        return directive;
    }
}
