using Biohazard.BioRand.RE7.Enemies;
using Biohazard.BioRand.RE7.Enemies.Impl;
using Biohazard.BioRand.RE7.REEngine;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class EnemyDirectiveModifier : Modifier
{
    private readonly List<IDirectiveModifier> _enemySpecificDirectiveModifiers =
    [
        new EvelineFinalBossDirectiveModifier(),
        new InsectsDirectiveModifier(),
        new JackShearsDirectiveModifier(),
        new JackMutatedDirectiveModifier(),
        new JackStalkerDirectiveModifier(),
        new MargeMutatedDirectiveModifier(),
        new MargeStalkerDirectiveModifier(),
        new MiaDirectiveModifier(),
        new MoldedDirectiveModifier(),
        //new MoldedFatDirectiveModifier(),
        new MoldedQuickDirectiveModifier(),
    ];

    private readonly List<IDirectiveModifier> _genericDirectiveModifiers =
    [
        new EnemyRankParamDirectiveModifier(),
        new MoldedCommonRankParamsDirectiveModifier(),
    ];

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        foreach (var enemy in EnemyDefinitions.Instance.All.OrderBy(em => em.EnemyId))
        {
            foreach (var enemySpecificModifier in _enemySpecificDirectiveModifiers)
            {
                if (enemySpecificModifier.Supports(enemy))
                {
                    logger.Push($"{enemy.EnemyId} -- {enemy.Name}");
                    enemySpecificModifier.Apply(enemy, randomizer, logger);
                    logger.Pop();
                }
            }
        }

        foreach (var modifier in _genericDirectiveModifiers)
        {
            logger.Push($"Generic -- {modifier.GetType().Name}");
            modifier.Apply(null!, randomizer, logger);
            logger.Pop();
        }
    }
}

internal sealed class EnemyRankParamDirectiveModifier : IDirectiveModifier
{
    private const string EnemyRankParameterHolderPath =
        "prefab/character/misc/parameter/battle/enemyrankparameterholder.user";

    public bool Supports(IEnemyDefinition enemy) => true;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/enemy-rank-params");
        var applySpeed = randomizer.GetConfigOption<bool>("random-enemy-speed");
        var applyDamage = randomizer.GetConfigOption<bool>("random-enemy-damage");

        if (!applySpeed && !applyDamage)
        {
            return;
        }

        var speedMultiplier = applySpeed
            ? (float)rng.NextDouble(
                randomizer.GetConfigOption<double>("enemy-speed-min"),
                randomizer.GetConfigOption<double>("enemy-speed-max"))
            : 1f;

        var damageMultiplier = applyDamage
            ? GetDamageMultiplier(randomizer, rng)
            : 1f;

        if (applySpeed)
        {
            logger.LogLine($"New enemy animation speed rate: {speedMultiplier}x");
        }

        if (applyDamage)
        {
            logger.LogLine($"New enemy damage multiplier: {damageMultiplier}x");
        }

        var holderPath = PakPath.UserFile(EnemyRankParameterHolderPath);
        var holder = randomizer.FileRepository.DeserializeUserFile<app.EnemyRankParameterHolder>(holderPath);

        foreach (var unit in holder.Units)
        {
            var rank = unit.Rank;
            var userFilePath = PakPath.UserFile(unit.RankParameter.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.EnemyRankParameter>(userFilePath, param =>
            {
                if (applySpeed)
                {
                    var oldAttack = param.AnimationSpeedRateForAttack;
                    var oldDamage = param.AnimationSpeedRateForDamage;
                    var oldMove = param.AnimationSpeedRateForMove;

                    param.AnimationSpeedRateForAttack *= speedMultiplier;
                    param.AnimationSpeedRateForDamage *= speedMultiplier;
                    param.AnimationSpeedRateForMove *= speedMultiplier;

                    logger.LogLine(
                        $"  Speed: " +
                        $"Atk {oldAttack:F3} => {param.AnimationSpeedRateForAttack:F3}, " +
                        $"Dmg {oldDamage:F3} => {param.AnimationSpeedRateForDamage:F3}, " +
                        $"Move {oldMove:F3} => {param.AnimationSpeedRateForMove:F3}");
                }

                if (applyDamage)
                {
                    var oldRate = param.DamageRate;

                    param.DamageRate *= damageMultiplier;

                    logger.LogLine(
                        $"  Damage: {oldRate:F3} => {param.DamageRate:F3}");
                }

                return param;
            });
        }
    }

    private static float GetDamageMultiplier(Randomizer randomizer, Rng rng)
    {
        if (randomizer.GetConfigOption<bool>("enemy-insta-death"))
        {
            return 9999f;
        }

        return (float)rng.NextDouble(
            randomizer.GetConfigOption<double>("enemy-damage-min"),
            randomizer.GetConfigOption<double>("enemy-damage-max"));
    }
}

internal sealed class MoldedCommonRankParamsDirectiveModifier : IDirectiveModifier
{
    private const string MoldedCommonRankParameterHolder =
        "prefab/character/misc/parameter/moldedcommon/moldedcommonrankparameterholder.user";

    public bool Supports(IEnemyDefinition enemy) => enemy.IsMolded;

    public void Apply(IEnemyDefinition enemy, Randomizer randomizer, RandomizerLogger logger)
    {
        var rng = randomizer.GetRng("enemy/enemy-rank-params");
        var applySpeed = randomizer.GetConfigOption<bool>("random-enemy-speed");

        if (!applySpeed)
        {
            return;
        }

        var speedMultiplier = (float)rng.NextDouble(
                randomizer.GetConfigOption<double>("enemy-speed-min"),
                randomizer.GetConfigOption<double>("enemy-speed-max")
        );

        var holderPath = PakPath.UserFile(MoldedCommonRankParameterHolder);
        var holder = randomizer.FileRepository.DeserializeUserFile<app.MoldedCommonRankParameterHolder>(holderPath);

        foreach (var unit in holder.Units)
        {
            var rank = unit.Rank;
            var userFilePath = PakPath.UserFile(unit.RankParameter.Path);

            logger.LogLine($"[Rank {rank}] {userFilePath}");

            randomizer.FileRepository.ModifyUserFile<app.MoldedCommonRankParameter>(userFilePath, param =>
            {
                if (applySpeed)
                {
                    var oldThreat = param.ThreatIntervalTime;
                    var oldGrapple = param.GrappleIntervalTime;
                    var oldSlash = param.SlashIntervalTime;

                    param.ThreatIntervalTime /= speedMultiplier;
                    param.GrappleIntervalTime /= speedMultiplier;
                    param.SlashIntervalTime /= speedMultiplier;

                    logger.LogLine(
                        $"  Intervals: " +
                        $"Threat {oldThreat:F3} => {param.ThreatIntervalTime:F3}, " +
                        $"Grapple {oldGrapple:F3} => {param.GrappleIntervalTime:F3}, " +
                        $"Slash {oldSlash:F3} => {param.SlashIntervalTime:F3}");
                }

                return param;
            });
        }
    }
}