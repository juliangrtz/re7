using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class JackShears : IEnemyDefinition
{
    public string Id => "JackShears";

    public EnemyID EnemyId => EnemyID.Em8001;

    public EnemyCategory Category => EnemyCategory.Jack;

    public string Name => "Jack Baker (Scissor Chainsaw)";

    public bool IsBoss => true;

    public int BaseHealth => 4500;

    // TODO: Fix paths

    public List<string> RcolPaths => [
        PakPath.RcolFile("collision/collider/enemy/em8000/em8000.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8000/em8000chainsawsensor.rcol"),
        PakPath.RcolFile("collision/collider/enemy/em8000/em8100deadbody.rcol.20"),
    ];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em8000/parameter/directive/em8000directiveholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em8000/parameter/resist/em8000resistparameterholder.user");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/chapter/chapter3/enemy_em8000.scn");

    public bool UsesEnemyGenerator => true;
}

internal class JackShearsDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em8001;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em8100");

        // Health
        var min = randomizer.GetConfigOption<int>("boss-health-min-jackshears");
        var max = randomizer.GetConfigOption<int>("boss-health-max-jackshears");
        var healthMultiplier = (float)rng.NextDouble(min, max);
        logger.LogLine($"Health: {enemy.BaseHealth} => {enemy.BaseHealth * healthMultiplier}");

        var userFilePath = PakPath.UserFile("prefab/character/em8001/parameter/directive/em8001battledirective_default.user");
        logger.LogLine($"[Default] {userFilePath}");

        randomizer.FileRepository.ModifyUserFile(userFilePath, directive =>
        {
            directive = directive.Set("Common.InitHP", enemy.BaseHealth * healthMultiplier);
            return directive;
        });
    }
}