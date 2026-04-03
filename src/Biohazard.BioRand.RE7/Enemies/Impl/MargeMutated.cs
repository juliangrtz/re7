using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Enemies.Impl;

internal class MargeMutated : IEnemyDefinition
{
    public string Id => "MargeMutated";

    public EnemyID EnemyId => EnemyID.Em3600;

    public EnemyCategory Category => EnemyCategory.Marguerite;

    public string Name => "Marguerite Baker (Mutated)";

    public bool IsBoss => true;

    public int BaseHealth => 15000;

    public List<string> RcolPaths =>
        [
            PakPath.RcolFile("collision/collider/enemy/em3600/em3600.rcol"),
            PakPath.RcolFile("collision/collider/enemy/em3600/em3600shell.rcol")
        ];

    public string DirectivesHolderPath
        => PakPath.UserFile("prefab/character/em3600/em3600directivesholder.user");

    public string ResistParamsHolderPath
        => PakPath.UserFile("prefab/character/em3600/em3600resistparameterholder.user");

    public RszGameObject GetPrefab(TemplateService templateService)
        => templateService.GetObject($"EnemyTemplate_{Id}");
}

internal class MargeMutatedStatsModifier : IEnemyStatsModifier
{
    public bool Supports(IEnemyDefinition enemy)
        => enemy.EnemyId == EnemyID.Em3600;

    class Em3600HealthModifier(float health) : ITemplateModifier
    {
        public string GameObjectName => "EnemyTemplate_Em3600";
        private readonly float _health = health;

        public RszGameObject Apply(RszGameObject gameObject)
        {
            var dmgController = gameObject.FindComponent<app.Em3600DamageController>()!;
            dmgController.HealthInfo.Health = _health;
            dmgController.HealthInfo.MaxHealth = _health;
            return gameObject;
        }
    }

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/em3600");
        logger.Push($"{enemy.EnemyId} -- {enemy.Name}");

        // Health (vanilla prefab + rando prefab)
        var min = randomizer.GetConfigOption<int>("enemy-health-min-margemutated");
        var max = randomizer.GetConfigOption<int>("enemy-health-max-margemutated");
        var newHealth = (float)rng.NextDouble(min, max);
        logger.LogLine($"Health: {enemy.BaseHealth} => {newHealth}");

        var path = PakPath.SceneFile("scenes/chapter/chapter3/enemy_em3600.scn");
        randomizer.FileRepository.ModifyScnFile(path, randomizer.IsOnRaytracingVersion, root =>
        {
            var em3600 = root.FindGameObject("Em3600")!;
            var dmgController = em3600.FindComponent<app.Em3600DamageController>()!;
            dmgController.HealthInfo.Health = newHealth;
            dmgController.HealthInfo.MaxHealth = newHealth;
            return root;
        });

        randomizer.TemplateService.InjectModifier(new Em3600HealthModifier(newHealth));

        // Speed
        var minSpeed = randomizer.GetConfigOption<int>("enemy-speed-min");
        var maxSpeed = randomizer.GetConfigOption<int>("enemy-speed-max");
        var newSpeed = (float)rng.NextDouble(minSpeed, maxSpeed);

        var holder = randomizer.FileRepository.DeserializeUserFile<app.Em3600DirectivesHolder>(enemy.DirectivesHolderPath);
        foreach (var directive in holder.holder.Units)
        {
            var rank = directive.Rank;
            var userFilePath = PakPath.UserFile(directive.Directive.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.Em3600Directive>(
                userFilePath,
                d => ModifyDirective(d, logger, newSpeed)
            );
        }

        logger.Pop();
    }

    private app.Em3600Directive ModifyDirective(
        app.Em3600Directive directive,
        RandomizerLogger logger,
        float speed)
    {
        logger.LogLine($"Speed: {speed}x normal speed");
        directive.MyCommonParam.NormalAttackIntervalTime /= speed;
        directive.MyCommonParam.GrappleAttackIntervalTime /= speed;
        directive.MyCommonParam.GroundAttackIntervalTime /= speed;
        directive.MyCommonParam.WallAttackIntervalTime /= speed;
        directive.MyCommonParam.ChangeTwoLegMoveSpeed *= speed;
        directive.MyCommonParam.ChangeFourLegMoveSpeed *= speed;

        directive.NormalModeParam.MoveSpeedRate *= speed;
        directive.NormalModeParam.MoveSpeedBlendRateUpSpeed *= speed;

        directive.WallMoveModeParam.MoveSpeed *= speed;

        directive.GenerateModeParam.GenerateTime /= speed;
        directive.GenerateModeParam.SpawnBugsIntervalTime /= speed;

        directive.SneakModeParam.SneakTime /= speed;

        directive.EscapeModeParam.MoveSpeed *= speed;

        directive.LastModeParam.MoveSpeed *= speed;

        return directive;
    }
}