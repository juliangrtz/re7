using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class LucasPuzzleInventoryModifier : Modifier {
    internal const string ScenePath = "natives/stm/leveldesign/fsm/chapter3/chapter3_4/levelfsm_c03_4.scn.20";

    internal static readonly string[] PatchedFsmGameObjectNames =[
        "1000_PazzleDoorUnLock_FFS",
        "1000_BoxEmpty_DoorOpen",
    ];

    private const string InventoryCheckActionType = "app.fsm.CheckInventoryEmpty";
    private const string SuccessfulActionType = "app.fsm.Wait";

    public override void Apply(Randomizer randomizer, RandomizerLogger logger) {
        if (!randomizer.GetConfigOption<bool>("random-key-item-locations"))
            return;

        var replacedChecks = 0;
        var patchedObjects = new List<string>();

        randomizer.FileRepository.ModifyScnFile(ScenePath, scene => {
            return scene.VisitGameObjects(gameObject => {
                if (!PatchedFsmGameObjectNames.Contains(gameObject.Name, StringComparer.Ordinal))
                    return gameObject;

                var components = gameObject.Components.ToBuilder();
                var changed = false;

                for (var i = 0; i < components.Count; i++) {
                    var component = components[i];
                    if (component.Type.Name != "via.fsm.Fsm")
                        continue;

                    var (patchedComponent, checksReplacedInComponent) = ReplaceInventoryChecks(component);
                    if (checksReplacedInComponent != 0) {
                        replacedChecks += checksReplacedInComponent;
                        components[i] = patchedComponent;
                        changed = true;
                    }
                }

                if (!changed)
                    return gameObject;

                patchedObjects.Add(gameObject.Name);
                return gameObject.WithComponents(components.ToImmutable());
            });
        });

        logger.LogLine(
            $"Lucas puzzle room inventory gate: replaced {replacedChecks} inventory-empty FSM checks with successful waits in {ScenePath}.");
        foreach (var objectName in patchedObjects.Distinct(StringComparer.Ordinal)) {
            logger.LogLine($"  {objectName}");
        }
    }

    private static (RszObjectNode Component, int ReplacedChecks) ReplaceInventoryChecks(RszObjectNode component) {
        var replacedChecks = 0;
        var updated = component.Visit(node => {
            if (node is not RszObjectNode objectNode ||
                objectNode.Type.Name != InventoryCheckActionType) {
                return node;
            }

            replacedChecks++;
            return CreateSuccessfulWaitAction(objectNode);
        });

        return (updated, replacedChecks);
    }

    private static RszObjectNode CreateSuccessfulWaitAction(RszObjectNode inventoryCheck) {
        var repository = inventoryCheck.Type.Repository;
        return repository.Create(SuccessfulActionType)
            .SetField("v0_Enabled", inventoryCheck.Get<bool>("v0_Enabled"))
            .SetField("v1_Modified", true)
            .SetField("v2_UID", inventoryCheck.Get<uint>("v2_UID"))
            .SetField("v3_ListNo", inventoryCheck.Get<byte>("v3_ListNo"))
            .SetField("Time", 0f)
            .SetField("RandamMax", 0f)
            .SetField("WaitType", 0)
            .SetField("SetFlag", Guid.Empty);
    }
}