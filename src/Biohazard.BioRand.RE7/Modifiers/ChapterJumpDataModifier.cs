using app;
using Biohazard.BioRand.RE7.REEngine;
using Enums.app.GameManager;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class ChapterJumpDataModifier : Modifier {
    private const string RandomizerKey = "modifier/chapter-jump-data";
    private readonly string _path = "scenes/chapterjumpdata/chapterjumpdata.scn".SceneFile();
    private readonly Guid ChapterJumpData_c01 = new("88045366-0683-481a-8b9a-1d8c59aa048a");

    private readonly List<(ChapterNo Chapter, bool IsFoundFootage)> _validChapters =[
        (ChapterNo.Chapter1, false),
        (ChapterNo.FF000, true), // Derelict House Footage, Clancy
        (ChapterNo.FF030, true), // Old House, Mia
        //(ChapterNo.FF040, true), //  Happy Birthday puzzle, Clancy -> bugged
        //(ChapterNo.FF050, true), // Ship, Mia -> bugged
        (ChapterNo.Chapter3, false),
        (ChapterNo.Chapter4, false),
    ];

    public override void LogState(Randomizer randomizer, RandomizerLogger logger) {
        var transitions = randomizer.FileRepository.GetScnFile(_path)
            .ReadScene(randomizer.FileRepository.TypeRepository);
        transitions.GetGameObjects().ForEach(go => {
            ChapterJumpData? chapterJumpData;
            if ((chapterJumpData = go.FindComponent<ChapterJumpData>()) != null) {
                logger.LogLine(
                    $"Chapter jump data '{chapterJumpData.JumpPositionName}': {chapterJumpData.JumpChapter.ToReadableString()} " +
                    $" (Enabled: {chapterJumpData.Enabled}, get player pos: {chapterJumpData.IsGetPlayerPos})");
            }
        });
    }

    private void SkipGuestHouse(Randomizer randomizer, RandomizerLogger logger) {
        randomizer.FileRepository.ModifyScnFile(_path, scene => {
            var go = scene.FindGameObject(ChapterJumpData_c01)!;
            var jumpData = go.FindComponent<ChapterJumpData>()!;
            jumpData.JumpChapter = ChapterNo.Chapter3;
            go = go.AddOrUpdateComponent(jumpData);
            scene = scene.UpdateGameObject(go);
            return scene;
        });

        logger.LogLine("Applied guest house skip");
    }

    private void ShuffleChapters(Randomizer randomizer, RandomizerLogger logger, bool skipGuestHouse, bool includeFF) {
        var candidates = _validChapters
            .Where(x =>
                (includeFF || !x.IsFoundFootage) &&
                (!skipGuestHouse || x.Chapter != ChapterNo.Chapter1))
            .Select(x => x.Chapter)
            .ToList();
        var rng = randomizer.GetRng(RandomizerKey);
        randomizer.FileRepository.ModifyScnFile(_path, scene => {
            var targetJumps = scene.GetGameObjects()
                .Select(go => (GameObject: go, Jump: go.FindComponent<ChapterJumpData>()))
                .Where(x => x.Jump != null && candidates.Contains(x.Jump.JumpChapter))
                .Select(x => (x.GameObject, Jump: x.Jump!))
                .ToList();

            var originalChapters = targetJumps
                .Select(x => x.Jump.JumpChapter)
                .ToList();
            var shuffledChapters = CreateDerangement(originalChapters, rng);

            for (var i = 0; i < targetJumps.Count; i++) {
                var (gameObject, jump) = targetJumps[i];
                var original = jump.JumpChapter;
                var next = shuffledChapters[i];

                jump.JumpChapter = next;
                logger.LogLine($"Chapter transition: {original.ToReadableString()} -> {next.ToReadableString()}");
                var updated = gameObject.AddOrUpdateComponent(jump);
                scene = scene.UpdateGameObject(updated);
            }

            return scene;
        });
    }

    private static List<ChapterNo> CreateDerangement(List<ChapterNo> original, Rng rng) {
        if (original.Count < 2)
            return [.. original];

        var shuffled = new List<ChapterNo>(original);
        for (var attempt = 0; attempt < 1024; attempt++) {
            for (int i = shuffled.Count - 1; i > 0; i--) {
                int j = rng.Next(0, i + 1);
                (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
            }

            if (original.Zip(shuffled).All(pair => pair.First != pair.Second))
                return shuffled;
        }

        return shuffled;
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger) {
        var skipGuestHouse = randomizer.GetConfigOption<bool>("skip-guest-house");
        var shuffleChapters = randomizer.GetConfigOption<bool>("shuffle-chapters");
        var shuffleChaptersWithFf = randomizer.GetConfigOption<bool>("shuffle-chapters-with-ff");

        if (skipGuestHouse) {
            SkipGuestHouse(randomizer, logger);
        }

        if (shuffleChapters) {
            ShuffleChapters(randomizer, logger, skipGuestHouse, shuffleChaptersWithFf);
        }
    }
}