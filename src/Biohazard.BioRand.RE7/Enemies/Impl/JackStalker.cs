using Biohazard.BioRand.RE7.REEngine;
using Enums.app;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class JackStalker : IEnemyDefinition
{
    public string Id => "JackStalker";

    public EnemyID EnemyId => EnemyID.Em3000;

    public EnemyCategory Category => EnemyCategory.Jack;

    public string Name => "Jack Baker (Stalker)";

    public bool IsBoss => false;

    public int BaseHealth => 10000;

    public List<string> RcolPaths
        => [
            PakPath.RcolFile("collision/collider/enemy/em3000/em3000.rcol"),
            PakPath.RcolFile("collision/collider/enemy/em3000/em3000throwattack.rcol")
           ];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em3000/parameter/directive/em3000directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em2000/parameter/resist/em3000resistparameter.user6");

    public string OriginalPrefabPath
        => PakPath.SceneFile($"scenes/enemy/em3000.scn");

    public bool UsesEnemyGenerator => false;

    private readonly List<WeaponID> _availableWeapons = [
        /* Vanilla */ WeaponID.Shovel, WeaponID.Roller, WeaponID.FireAxe, 
        /* Modded */ WeaponID.ChainSaw
    ];

    public RszGameObject IndividualizeTemplate(Rng rng, RszGameObject template)
    {
        var equipManager = template.FindComponent<app.EquipManager>()!;
        equipManager.EquipWeaponIdRight = rng.Next(_availableWeapons);
        //equipManager.EquipWeaponIdLeft = rng.Next(_availableWeapons);
        template = template.AddOrUpdateComponent(equipManager);
        return template;
    }
}

internal class JackStalkerDirectiveModifier : IDirectiveModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3000;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em3000");
        var applySpeed = randomizer.GetConfigOption<bool>("random-enemy-speed");

        var minSpeed = randomizer.GetConfigOption<double>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<double>("enemy-speed-max");
        var speedMultiplier = applySpeed ? (float)rng.NextDouble(minSpeed, maxSpeed) : 1f;

        var healthMultiplier = enemy.GetHealthMultiplier(randomizer, rng);
        logger.LogHealthMultiplier(enemy.BaseHealth, healthMultiplier);
        if (applySpeed)
        {
            logger.LogMultiplier("Walk speed multiplier", speedMultiplier);
        }
        else
        {
            logger.LogLine("Walk speed multiplier: 1x (enemy speed randomization disabled)");
        }

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em3000DirectivesHolder>(enemy.DirectivesHolderPath);

        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogDirectiveFile(rank, userFilePath, () => randomizer.FileRepository.ModifyUserFile<app.Em3000BattleDirective>(
                userFilePath,
                d => ModifyDirective(d, logger, healthMultiplier, speedMultiplier)
            ));
        }
    }

    private app.Em3000BattleDirective ModifyDirective(
        app.Em3000BattleDirective directive,
        RandomizerLogger logger,
        float healthMultiplier,
        float speedMultiplier)
    {
        // TODO Scale?
        // directive.common.ModelScale

        // Health
        var oldHealth = directive.chapter3Battle1Final.Health;
        directive.chapter3Battle1Final.Health *= healthMultiplier;
        logger.LogChange("Chapter 3 final health", oldHealth, directive.chapter3Battle1Final.Health);

        // Speed
        if (speedMultiplier == 1f)
        {
            logger.LogLine("No walk speed changes.");
        }
        else
        {
            //directive.common.MotionSpeedForBack *= speedMultiplier;
            //directive.common.MotionSpeedForStepIn *= speedMultiplier;
            var oldWalkSpeed = directive.common.MotionSpeedForWalk;
            directive.common.MotionSpeedForWalk *= speedMultiplier;
            logger.LogChange("Walk speed", oldWalkSpeed, directive.common.MotionSpeedForWalk);
        }

        // Misc.
        var oldDiscoveryTime = directive.chapter3Battle1.MansionAIForceDiscoveryTime;
        directive.chapter3Battle1.MansionAIForceDiscoveryTime = 0.5f; // ;)
        logger.LogChange("Mansion AI forced discovery time", oldDiscoveryTime, directive.chapter3Battle1.MansionAIForceDiscoveryTime);
        return directive;
    }
}
