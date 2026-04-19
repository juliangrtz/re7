using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app.GameManager;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Tests;

internal static class RandomizerTestHelpers
{
    public static void ConfigureSingleDropRate(RandomizerConfiguration configuration, string id, double value)
    {
        configuration[$"item-drop-ratio-{id.ToLowerInvariant()}"] = value;
    }

    public static Dictionary<string, app.Collision.AttackUserData> ReadAttackUserDataByRequestSet(RandomizerRunResult result, string path, bool before)
    {
        var bytes = before ? result.ReadBeforeBytes(path) : result.ReadAfterBytes(path);
        var builder = new RcolFile(FileVersions.RcolFileVersion, bytes)
            .ToBuilder(result.Randomizer.FileRepository.TypeRepository);

        return builder.RequestSets
            .Where(x => x.UserData?.Type.Name == "app.Collision.AttackUserData")
            .ToDictionary(
                x => x.Name,
                x => RszSerializer.Deserialize<app.Collision.AttackUserData>(x.UserData!)!);
    }

    public static app.ChapterJumpData GetChapterJump(RszScene scene, Guid guid)
    {
        var gameObject = scene.FindGameObject(guid);
        Assert.NotNull(gameObject);
        var jump = gameObject!.FindComponent<app.ChapterJumpData>();
        Assert.NotNull(jump);
        return jump!;
    }

    public static IReadOnlyList<(Guid Guid, ChapterNo JumpChapter)> GetChapterJumps(RszScene scene)
    {
        var result = new List<(Guid, ChapterNo)>();
        scene.VisitGameObjects(gameObject =>
        {
            var jump = gameObject.FindComponent<app.ChapterJumpData>();
            if (jump != null)
            {
                result.Add((gameObject.Guid, jump.JumpChapter));
            }
        });
        return result;
    }

    public static RszGameObject GetDynamicParent(RszScene scene)
    {
        var gameObject = scene.FindGameObject(go => go.Name.EndsWith("_dynamic", StringComparison.Ordinal));
        Assert.NotNull(gameObject);
        return gameObject!;
    }

    public static List<BirdCageState> GetBirdCageStates(RszScene scene)
    {
        var states = new List<BirdCageState>();

        scene.VisitGameObjects(gameObject =>
        {
            if (!gameObject.Name.Contains("CoinBox", StringComparison.OrdinalIgnoreCase))
                return;

            var gimmick = gameObject.Children.FirstOrDefault(child =>
                child.Name.EndsWith("_Gimmick", StringComparison.Ordinal) &&
                child.FindComponent<app.CoinCounter>() != null);
            var itemHolder = gameObject.Children.FirstOrDefault(child => child.FindComponent<app.Item>() != null);
            if (gimmick == null || itemHolder == null)
                return;

            var item = itemHolder.FindComponent<app.Item>()!;
            var coinCounter = gimmick.FindComponent<app.CoinCounter>()!;
            states.Add(new BirdCageState(gameObject.Guid, item.ItemDataID, item.ItemStackNum, coinCounter.CoinMax));
        });

        return states;
    }
}

internal sealed record BirdCageState(Guid ContainerGuid, string ItemId, int ItemCount, int CoinCount);
