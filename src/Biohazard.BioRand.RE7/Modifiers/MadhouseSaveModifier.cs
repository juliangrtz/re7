using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.REE.Rsz;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class MadhouseSaveModifier : Modifier
{
    internal const string ConfigKey = "madhouse-normal-saves";

    internal static readonly string[] AutosaveScenePaths =
    [
        PakPath.SceneFile("leveldesign/fsm/chapter1/levelfsm_c01.scn"),
        PakPath.SceneFile("leveldesign/fsm/chapter3/chapter3_1/levelfsm_c03_1.scn"),
        PakPath.SceneFile("leveldesign/fsm/chapter3/chapter3_2/levelfsm_c03_2.scn"),
        PakPath.SceneFile("leveldesign/fsm/chapter3/chapter3_3/levelfsm_c03_3.scn"),
        PakPath.SceneFile("leveldesign/fsm/chapter3/chapter3_4/levelfsm_c03_4.scn"),
        PakPath.SceneFile("leveldesign/fsm/chapter3/chapter3_5/levelfsm_c03_5.scn"),
        PakPath.SceneFile("leveldesign/fsm/chapter4/chapter4_1/levelfsm_c04_1.scn"),
        PakPath.SceneFile("leveldesign/fsm/chapter4/chapter4_2/levelfsm_c04_2.scn"),
        PakPath.SceneFile("leveldesign/fsm/ff000/levelfsm_ff000.scn"),
        PakPath.SceneFile("leveldesign/fsm/ff030/levelfsm_ff030.scn"),
        PakPath.SceneFile("leveldesign/fsm/ff040/levelfsm_ff040.scn"),
        PakPath.SceneFile("leveldesign/fsm/ff050/level_fsm_ff050.scn"),
    ];

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
        logger.LogLine($"Madhouse normal saves: {IsEnabled(randomizer)}");
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!IsEnabled(randomizer))
            return;

        var totalPatchedFlags = 0;
        foreach (var path in AutosaveScenePaths)
        {
            var patchedFlags = 0;
            randomizer.FileRepository.ModifyScnFile(path, scene =>
            {
                return scene.Visit(node =>
                {
                    if (node is not RszObjectNode objectNode)
                        return node;

                    var updatedObject = ClearHardNoSaveFlag(objectNode, ref patchedFlags);
                    if (updatedObject.Type.Name == "app.TriggerInAction")
                    {
                        updatedObject = ClearTriggerInActionHardNoSaveFlag(updatedObject, ref patchedFlags);
                    }

                    return updatedObject;
                });
            });

            if (patchedFlags == 0)
                continue;

            totalPatchedFlags += patchedFlags;
            logger.LogLine($"Enabled Madhouse autosaves in {path}: cleared {patchedFlags} save restriction flags.");
        }

        logger.LogLine($"Enabled Easy/Normal save behavior on Madhouse: cleared {totalPatchedFlags} save restriction flags.");
    }

    private static RszObjectNode ClearTriggerInActionHardNoSaveFlag(RszObjectNode objectNode, ref int patchedFlags)
    {
        if (objectNode.Type.FindFieldIndex("ExtraCommand") == -1 ||
            objectNode["ExtraCommand"] is not RszObjectNode extraCommand ||
            !ReadBoolean(extraCommand, "IsHardNoSave"))
        {
            return objectNode;
        }

        patchedFlags++;
        return objectNode.Set("ExtraCommand.IsHardNoSave", false);
    }

    private static RszObjectNode ClearHardNoSaveFlag(RszObjectNode objectNode, ref int patchedFlags)
    {
        if (!IsAutosaveAction(objectNode) || !ReadBoolean(objectNode, "IsHardNoSave"))
            return objectNode;

        patchedFlags++;
        return objectNode.Set("IsHardNoSave", false);
    }

    private static bool IsAutosaveAction(RszObjectNode objectNode)
        => objectNode.Type.Name is "app.fsm.AutoSave" or "app.fsm.CH8AutoSave";

    internal static bool IsEnabled(Randomizer randomizer)
        => randomizer.GetConfigOption("madhouse-normal-saves", true);

    private static bool ReadBoolean(RszObjectNode objectNode, string fieldName)
        => objectNode.Type.FindFieldIndex(fieldName) != -1 &&
           objectNode[fieldName] is RszValueNode valueNode &&
           RszSerializer.Deserialize<bool>(valueNode);
}
