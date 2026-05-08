# Key Item Randomization Notes

## Current Support

`KeyItemLocationModifier` now ignores the legacy `key_items.csv` relocation table and instead swaps `app.Item.ItemDataID` at normal item placements. This avoids cloning key-item pickup objects and their FSM-linked behavior into unrelated scenes.

Supported items are limited to the current "WORKS" pool:

| Item | Item ID | Placement scope |
| --- | --- | --- |
| White Dog's Head | `3CrestKeyB` | Chapter 3 main-house placements only |
| Blue Dog's Head | `3CrestKeyA` | Chapter 3 main-house placements only |
| Battery | `Battery` | Chapter 3 pre-Lucas placements |
| Scorpion Key | `MorgueKey` | Chapter 3 pre-Lucas placements |
| Snake Key | `MasterKey` | Chapter 3 pre-Lucas placements |
| Crow Key | `TalismanKey` | Chapter 3 pre-Lucas placements |
| Car Key | `EthanCarKey` | Chapter 3 main-house placements only |
| Wooden Statuette | `SilhouettePazzlePiece` | Chapter 3 main-house placements only |
| Power Cable | `EvCable` | Chapter 4 present-ship Mia placements only |
| General Purpose Fuse | `FuseCh4` | Chapter 4 present-ship Mia placements only |
| Lug Wrench | `EvOpener` | Chapter 4 present-ship Mia placements only |
| Corrosive | `SpareKey` | Chapter 4 present-ship Mia placements only, stack count 4 |
| E-Necrotoxin | `SerumTypeE` | Chapter 4 late-game Ethan placements before the final battle only |

Original pickups for those IDs are replaced with ordinary filler drops so the randomized key item is not duplicated at its vanilla location.

## Evidence Sources

The current notes are based on `.analysis/likely-uvars.tsv`, `.analysis/uvar-evidence.json`, and `.analysis/UvarResearch/Program.cs`. The relevant evidence is mostly global variable usage around MainFlow and objective FSMs. The IDA MCP server was not exposed as a callable tool in this Codex session, so the investigation did not include fresh IDA xrefs.

## Unsafe Categories

### Works only if used after a boss/check

These items can probably be picked up early, but using them before the required story state can softlock. Future support should either place them only after the relevant check or add a use-gate/runtime guard.

| Item | Item ID | Relevant evidence | Future gate |
| --- | --- | --- | --- |
| Ox Statuette | `EntranceHallKey` | Jack garage progression is represented by `c03_1_Jack*` flags and `c03_1_Main_SwitchOnGarageShutter`. | Only place after the garage fight, or block/use-gate the main hall door until Jack 1 is complete. |
| Lantern | `Lantern` | `c03_3_Main_GetLantern`, `c03_objective_LanternGet`, and `c03_3_Main_SolveLanternGimmick` are tied to the Marguerite route. | Only place after long-arm Marguerite is defeated, or set the lantern-get objective chain when a randomized lantern is picked up. |
| Clock Pendulum | `PendulumClock` | Same Jack 1 risk as the Ox Statuette when the clock puzzle is used before garage progression is complete. | Let it appear only after Jack 1, or guard the clock use interaction until Jack 1 completion. |

### Does not work if picked up early

These are tied to pickup FSMs/objective flags strongly enough that an early generic pickup does not satisfy the story chain.

| Item | Item ID | Relevant evidence | Needed before enabling |
| --- | --- | --- | --- |
| Axe | `HandAxe` | Guest-house axe combat is tied to tutorial and Mia battle FSMs, including `Tutorial_AttackHandAxe`. | Separate weapon grant from battle FSM state, or add runtime handling for the Mia fight weapon state. |
| Serum | `DybbukMedicine` | Serum making/usage flows involve `c03_5_Main_SerumMakeEventEnd` and boat-house serum delivery/use nodes. | Prove which serum variant is consumed and set serum-made/delivery checks when the randomized item is obtained. |
| Dissection Room Key | `WorkroomKey` | `c03_2_Main_OpenTrayInWorkshopKey` marks the tray/workshop-key pickup. | Mark the tray-open/get check when the randomized replacement is collected. |
| Red Dog's Head | `3CrestKeyC` | `c03_2_Main_GetCrestInFreezerRoom` and Jack 2 chainsaw state `c03_2_ChainSaw_Interacted` are in the freezer route. | Preserve/complete the freezer crest check and Jack 2 route requirements. |
| Hatch Key | `FloorDoorKey` | `c03_1_Main_GetFloorDoorKey` is required by floor-door and later Lucas-yard flow nodes. | Set the hatch-key acquired check on randomized pickup, or keep this item after the floor-door route. |
| Crank | `Crank` | `c03_3_Main_GetCrank` is referenced by Old House and serum-route flow nodes. | Set the crank acquired check on randomized pickup. |
| Bolt Cutters | `ChainCutter` | `c01_objective_ChainCut_ItemUse` gates Mia cell-door cutting. Legacy relocation notes already marked this as softlocking. | Handle both pickup and chain-door-use objective state; likely needs a runtime use hook. |
| Fuse | `Fuse` | `c01_Main_FuseGet` and `c01_Main_FuseBox01AInFuse` gate the guest-house fuse box route. | Set fuse-get when randomized, and ensure fuse-box insertion still advances correctly. |
| D-Series Arm | `SerumMaterialA` | Serum material flow references arm search and delivery nodes under `F_MakeSerum`. | Set material-obtained/delivery checks or keep after the arm acquisition scene. |
| D-Series Head | `SerumMaterialB` | Lucas/serum material flow references the monitor-room/head path and serum delivery nodes. | Set material-obtained/delivery checks or keep after the head acquisition scene. |

### Could work if checks are marked complete

These look viable for a second phase because the blocking checks are already visible in the HFSM/uvar corpus.

| Item | Item ID | Candidate checks |
| --- | --- | --- |
| Stone Statuette | `SilhouettePazzlePieceOldHouse` | The Mia tape shadow puzzle uses `FF030_Main_SolvePazzle`; the main Old House path also has related shadow-puzzle/objective checks. |
| Blue Keycard | `LucasCardKey` | `c03_4A_Main_LucasCardKeyGet_InLoft` and `c03_Objective_2LucasCardKey_Get`; also needs the toy-axe/stone-puzzle completion check before the attic branch can be bypassed. |
| Red Keycard | `LucasCardKey2` | `c03_4B_Main_LucasCardKeyGet_InWorkRoom`, `c03_4B_Main_BedNumberUnlocking`, and `c03_Objective_2LucasCardKey_Get`; needs the clock puzzle check. |
| Candle | `Candle` | `c03_4_Main_PazzleRoom_CandleOn`, `c03_4_Main_PazzleRoom_ToLightCandle`, `c03_4_Main_PazzleRoom_CandleSetCake`, `LastCandleFire`, and `c03_objective_PazzleRoomNoItem_AreaIn`. |

## Implementation Direction

Future support should add a small named-uvar helper to `FlagService`, because it currently sets flags by GUID only. The `.analysis/uvar-evidence.json` records variable names and GUIDs, so the next step is to add a safe lookup layer, then enable one unsafe item at a time behind focused regression tests.
