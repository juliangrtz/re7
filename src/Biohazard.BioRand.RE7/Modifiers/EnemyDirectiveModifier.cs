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
            var matchingModifiers = _enemySpecificDirectiveModifiers
                .Where(modifier => modifier.Supports(enemy))
                .ToArray();

            if (matchingModifiers.Length == 0)
            {
                continue;
            }

            logger.Push($"{enemy.EnemyId} -- {enemy.Name}");
            if (matchingModifiers.Length == 1)
            {
                matchingModifiers[0].Apply(enemy, randomizer, logger);
            }
            else
            {
                foreach (var enemySpecificModifier in matchingModifiers)
                {
                    logger.Push(enemySpecificModifier.GetLogLabel());
                    enemySpecificModifier.Apply(enemy, randomizer, logger);
                    logger.Pop();
                }
            }
            logger.Pop();
        }

        foreach (var modifier in _genericDirectiveModifiers)
        {
            logger.Push($"Generic -- {modifier.GetLogLabel()}");
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
            logger.LogSkip("Enemy speed and damage randomization are both disabled.");
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
            logger.LogMultiplier("Animation speed multiplier", speedMultiplier);
        }

        if (applyDamage)
        {
            logger.LogMultiplier("Damage multiplier", damageMultiplier);
        }

        var holderPath = PakPath.UserFile(EnemyRankParameterHolderPath);
        var holder = randomizer.FileRepository.DeserializeUserFile<app.EnemyRankParameterHolder>(holderPath);

        foreach (var unit in holder.Units)
        {
            var rank = unit.Rank;
            var userFilePath = PakPath.UserFile(unit.RankParameter.Path);

            logger.LogDirectiveFile(rank, userFilePath, () => randomizer.FileRepository.ModifyUserFile<app.EnemyRankParameter>(userFilePath, param =>
            {
                if (applySpeed)
                {
                    var oldAttack = param.AnimationSpeedRateForAttack;
                    var oldDamage = param.AnimationSpeedRateForDamage;
                    var oldMove = param.AnimationSpeedRateForMove;

                    param.AnimationSpeedRateForAttack *= speedMultiplier;
                    param.AnimationSpeedRateForDamage *= speedMultiplier;
                    param.AnimationSpeedRateForMove *= speedMultiplier;

                    logger.LogChange("Attack animation speed", oldAttack, param.AnimationSpeedRateForAttack);
                    logger.LogChange("Damage animation speed", oldDamage, param.AnimationSpeedRateForDamage);
                    logger.LogChange("Move animation speed", oldMove, param.AnimationSpeedRateForMove);
                }

                if (applyDamage)
                {
                    var oldRate = param.DamageRate;

                    param.DamageRate *= damageMultiplier;

                    logger.LogChange("Damage rate", oldRate, param.DamageRate);
                }

                return param;
            }));
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
            logger.LogSkip("Enemy speed randomization is disabled.");
            return;
        }

        var speedMultiplier = (float)rng.NextDouble(
                randomizer.GetConfigOption<double>("enemy-speed-min"),
                randomizer.GetConfigOption<double>("enemy-speed-max")
        );
        logger.LogMultiplier("Molded common speed multiplier", speedMultiplier);

        var holderPath = PakPath.UserFile(MoldedCommonRankParameterHolder);
        var holder = randomizer.FileRepository.DeserializeUserFile<app.MoldedCommonRankParameterHolder>(holderPath);

        foreach (var unit in holder.Units)
        {
            var rank = unit.Rank;
            var userFilePath = PakPath.UserFile(unit.RankParameter.Path);

            logger.LogDirectiveFile(rank, userFilePath, () => randomizer.FileRepository.ModifyUserFile<app.MoldedCommonRankParameter>(userFilePath, param =>
            {
                var oldThreat = param.ThreatIntervalTime;
                var oldGrapple = param.GrappleIntervalTime;
                var oldSlash = param.SlashIntervalTime;

                param.ThreatIntervalTime /= speedMultiplier;
                param.GrappleIntervalTime /= speedMultiplier;
                param.SlashIntervalTime /= speedMultiplier;

                logger.LogChange("Threat interval", oldThreat, param.ThreatIntervalTime);
                logger.LogChange("Grapple interval", oldGrapple, param.GrappleIntervalTime);
                logger.LogChange("Slash interval", oldSlash, param.SlashIntervalTime);

                return param;
            }));
        }
    }
}
