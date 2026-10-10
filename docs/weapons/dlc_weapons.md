# Not a Hero and End of Zoe weapons

Status: experimental, **not campaign-certified**. Investigation: 2026-10-10.

This is the handoff for the DLC weapon integration attempt. Do not interpret the
source catalog, a successful export, an item-box entry, or a forced shot as a
working randomizer weapon. AMG-Dual has an **experimental Ethan lab adapter**,
but is not yet included in campaign generation or the supported-weapon grant.

Related: [integration plan](../DLCIntegrationPlan.MD),
[binary evidence](../DLCIntegrationEvidence.MD), [technical notes](../Notes.MD),
and [Lua API hazards](../reframework-lua.md).

## Implemented boundary

There are now two separate entry points, sharing `DlcWeaponImporter`:

- `DlcWeaponLabPatch` remains an explicit mod export under `BioRand/DlcWeaponLab`.
  Its manual Lua runner is not loaded by `BioRand7.lua` and grants nothing on load.
  The export preflights and copies the campaign dependency manifest plus 32
  gauntlet hand, material, texture and motion resources from the installed game.
- The lab also exports a **Spirit Blade base-melee adapter**.
  It preserves WeaponID 63 and the source render/motion/collider stack and
  includes opt-in hand-axe motions and confirmed-hit recovery. The campaign
  version additionally isolates its attack RCOL and participates in generation
  and debug grants. Lab candidacy and campaign candidacy remain separate
  properties; do not promote a lab export merely because its prefab loads.
- `DlcCampaignWeaponPatch` integrates five candidates under `BioRand/DlcWeapons`
  when **both** `dlc-campaign-weapons` and `allow-dlc-items` are true. The new
  experimental option defaults to false. Ordinary profiles retain their old pools.
- The candidate set is Tactical Knife, Samurai Edge, Thor's Hammer, Joe's M21,
  and Spirit Blade. The remaining nine catalog entries, including AMG-Dual,
  stay excluded pending player-system work.
- Campaign integration includes item definitions, starting weapons and ammunition,
  random weapon pools, pickup templates, item settings/messages, inspection
  resource folders, and weapon-stat controls. Custom bird-cage entries are gated;
  the default cage table still disables ordinary guns.
- Inventory/detail PFBs and resource scenes are namespaced. CH8 gun parameters and
  knife attack RCOL are copied to that namespace before stat changes. Joe's M21
  deliberately shares campaign M21 parameters and controls. Source DLC settings
  and inventory PFBs are not rewritten, and DLC gameplay roots stay inactive.
- `_Data/dlc_weapon_assets.txt` lists 113 required installed resources, including
  weapon render/motion/collision/VFX dependencies and import metadata. Generation
  preflights every entry before registering anything and emits a clear error if
  the baseline needs `setup --dlc-weapons`. Extracted game assets are not committed.
- `BioRand7/dlc_weapons.lua` makes at most one deferred loading request per matching
  campaign prefab per session. It does not automatically grant items, force native
  initialization or repair AI. Its scoped player adapter maps Spirit Blade's
  motion bank and observes confirmed damage for recovery; it never synthesizes
  attacks or input. Both flags imply REFramework is required.
- **BioRand 7 > Debug tools > Add supported DLC weapons to item box** queues a
  one-shot grant on `UpdateBehavior`. It adds one of each of the five candidates,
  skipping weapons already owned in inventory or storage. Both integration flags,
  campaign Ethan, and all five ready campaign prefabs are required. Missing/foreign
  adapters abort before any additions; a native add failure stops the batch without
  retrying or removing earlier successes. The menu reports the result. Loading a
  save, starting a new game, resetting scripts, or reloading config cancels pending
  requests. The button does not deploy assets, equip weapons, or save the game.

This implements the campaign generation path, **not completed playthrough
certification**. Save migration is not implemented. Use backed-up test saves until
normal acquisition, storage, save/load, and all relevant player transitions pass.

### Preparing an opt-in seed

Use an installation with Not a Hero and End of Zoe, with generated/mod PAKs removed
from the setup input. Setup reads installed patch PAKs too: harvesting an already
randomized installation can contaminate the baseline and make patches fail their
expected-match checks. Do not weaken those checks to accept a dirty baseline.

```powershell
dotnet run --project src/biorand-re7 -- setup -i "<clean RE7 install>" -o out/dlc-baseline.pak --full --dlc-weapons
dotnet run --project src/biorand-re7 -- generate --input out/dlc-baseline.pak --config "<profile.json>" --seed 1685410476 --output out/dlc-seed
```

The profile must set `"allow-dlc-items": true` and `"dlc-campaign-weapons": true`.
Deploy a complete generated output with RE7 stopped; do not mix stale lab settings,
new inventory prefabs, and a different seed's runtime configuration.

## Source inventory

Names are resolved from source item messages, not inferred from asset names.
WeaponID is distinct from the string ItemDataID.

| ItemDataID | Source name | Chapter | WeaponID | Native component | Lab adapter |
| --- | --- | --- | --- | --- | --- |
| `CKnife` | Tactical Knife | CH8 | 48 | `app.Weapon` | Experimental knife |
| `Handgun_Albert_C` | Samurai Edge - AW Model-01 | CH8 | 49 | `app.CH8WeaponGun` | Experimental base gun |
| `Shotgun_Albert` | Thor's Hammer - AW Model-02 | CH8 | 50 | `app.CH8WeaponGun` | Experimental base gun |
| `Grenadebomb` | Grenade | CH8 | 58 | `app.CH8WeaponThrowable` | None |
| `Thermatebomb` | Incendiary Grenade | CH8 | 59 | `app.CH8WeaponThrowable` | None |
| `Stangrenadebomb` | Neuro-stun Grenade | CH8 | 60 | `app.CH8WeaponThrowable` | None |
| `CH9_WP000` | AMG-78a | CH9 | 61 | `app.CH9Weapon1600` | None |
| `CH9_WP001` | AMG-78 | CH9 | 62 | `app.CH9Weapon1600` | None |
| `CH9_WP002` | Spirit Blade | CH9 | 63 | `app.CH9Weapon1700` | Base melee: Ethan attack/damage/recovery and cold campaign save/load verified |
| `CH9_WP003` | Throwing Knife | CH9 | 64 | `app.CH9Weapon1500` | None |
| `CH9_WP004` | Throwing Spear | CH9 | 65 | `app.CH9Weapon1800` | None |
| `CH9_WP005` | Stake Bomb | CH9 | 66 | `app.CH9Weapon1900` | None |
| `CH9_WP006` | AMG-Dual | CH9 | 67 | `app.CH9Weapon1600` | Experimental Ethan punch/charge adapter; lab only |
| `NumaItem072` | Joe's M21 | CH9 | 13 | `app.CH9WeaponGun` | Experimental base gun |

Additional identities that must not be conflated:

- `NumaItem071` is Joe's bare fists, using `CH9Weapon1600` and WeaponID 0. It is
  player support, not a fifteenth portable weapon.
- `CH9_WP007`, `CH9_WP008`, and `CH9_WP009` enum values do not establish usable
  weapons; no corresponding records were found in the inspected item settings.
- Spirit Blade's asset family is `wp1700_Hatchet`; the asset name is not its UI name.
- `NumaItem072` shares WeaponID 13 with campaign `Shotgun_DB`. A dictionary keyed
  only by WeaponID cannot represent both inventory identities independently.

Relevant native paths, relative to `natives/stm/`:

| Purpose | Path |
| --- | --- |
| Campaign item records | `prefab/item/resourceitemsettings.user.2` |
| CH8 item records | `ch8/prefab/item/resourceitemsettings_chapter8.user.2` |
| CH9 item records | `ch9/prefab/item/resourceitemsettings_chapter9.user.2` |
| CH8 messages | `ch8/message/ch8_item_mes.msg.17` |
| CH9 messages | `message/ch9_item_mes.msg.17` |
| Campaign messages | `message/ui_item_mes.msg.17` |
| CH8 resident weapons | `ch8/scenes/residentweapons.scn.20` |
| CH8 resource-folder index | `ch8/scenes/items/itemresources_chapter8.scn.20` |
| CH9 resource-folder index | `ch9/scenes/items/itemresources_chapter9 .scn.20` |

The space before `.scn` in the last path is real. Joe's M21 name message already
exists in the campaign message table. Merge messages by GUID and destination
language/attribute layout; copying a foreign message record verbatim can mismatch
the destination MSG schema.

## What the adapters change

The gun adapters replace only the CH8/CH9 gun component with `app.WeaponGun`,
copying its serialized base fields. They retain the native WeaponID and source
weapon parameters. The knife already uses `app.Weapon`.
Spirit Blade replaces its CH9-specific weapon component with `app.Weapon`, keeps
the source mesh/motion/collider stack, and uses the scoped player adapter below.

The export removes `app.DisableSave`, `app.CH8HandgunBulletSound`,
`app.CH8ReticleChanger`, and `app.CH8ReticleMaterialChanger` where present, and
permits item-box storage. Removing `DisableSave` is an experiment, **not proof of
persistence compatibility**. Source save GUIDs are not a certified identity policy.

For the gun experiment:

- `AlbertHandgunBullet` maps to campaign `HandgunBullet`.
- `AlbertShotgunBullet` maps to campaign `ShotgunBullet`.
- Existing enhanced campaign handgun ammunition remains available where present.
- `AlbertHandgunBulletL` (RAMRODs) is removed from the accepted ammo list. The base
  adapter does not reproduce CH8 anti-regeneration semantics.

The CH8 source stack limits are 90 normal handgun rounds, 120 shotgun rounds,
27 RAMRODs, and 6 per grenade type. CH9 throwing knives, spears, and stake bombs
have source stack limits of 9999. Those values are discovery evidence, not an
approved campaign balance policy.

## Live evidence and limitations

Runtime: RE7 `1.0.0.7`, executable SHA-256
`D550260029B51A580E206B9A12A4EB7F4A1B4DD230BBA5DEFCCA81DA40597321`,
REFramework `v1.5.9.1+507-d1461375`.

The HTTP/managed live endpoints timed out during the initial attempt. A temporary local
Lua command bridge executed bounded probes on `UpdateBehavior`. IDA MCP was not
reachable; the IDA facts linked above are from the earlier investigation, not a
new decompilation pass. Session-specific addresses are deliberately not recorded.

### Campaign adapter pass

The later pass used working read-only REFramework endpoints and a temporary
`UpdateBehavior` command bridge for mutations. A cold restart loaded the staged
110-file campaign export (92 dependencies plus 18 adapted/merged files).

| Check | Observation | Remaining limitation |
| --- | --- | --- |
| Full seed generation | Completed with a clean baseline augmented by the manifest; starting loadouts selected the CH8 candidates and an extra chest selected Joe's M21 | The full generated seed was not deployed for a playthrough |
| Cold prefab load | All four campaign handles became `Ready=true`, `Valid=true` without manual preparation | Readiness is not functional certification |
| Samurai Edge ownership | Native item-box withdrawal created an inventory-owned pistol; inventory equip selected WeaponID 49 | Acquisition used a temporary boxed test grant, not a world pickup |
| Samurai Edge firing | Normal mouse input reached native `shoot`/`fireBullet` for ID 49 and consumed rounds | Shot timing and balance are not certified |
| Empty-magazine reload | Normal attack input on an empty magazine triggered the reload animation; 0 loaded / 30 reserve became 9 / 21 | Dedicated reload-key automation was inconclusive |
| Normal Molded damage | User observed lethal headshots and lower body damage with Samurai Edge | Not a controlled damage/balance measurement; balancing deferred |
| Tactical Knife | Box withdrawal and equip reached ID 48 / bank 30 | Hand pose and attack behavior were not certified |
| Thor's Hammer | Box withdrawal produced the correct inventory ID | The session later crashed; firing/reload were not validated |
| Joe's M21 | Serialized adapter and generated chest passed checks | No clean live equip/fire/reload pass yet |

Two later sessions were invalidated by direct inventory/menu probes: a vanilla
weapon storage call threw and was followed by process exit; another session
developed an invalid native inventory reference before exiting after shotgun
withdrawal. The latter crash log included native finalization frames. These facts
do **not** isolate a weapon defect or exonerate the adapters. Do not count either
session as a storage, persistence, or multi-weapon compatibility pass. The temporary
bridge and diagnostic hooks are not part of the production module.

Save files matched the pre-test backup after these sessions. No DLC-bearing save
was written, so that comparison is preservation evidence, not a save/load test.

### Earlier lab evidence

| Check | Observation | What it does not prove |
| --- | --- | --- |
| Source discovery | All 14 IDs match source settings, components, and WeaponIDs | Campaign usability |
| Compiled export | Deterministic output; four candidate IDs, correct base types/ammo, render/motion components retained | Runtime lifecycle or complete asset closure |
| Item-box insertion | `ItemBoxData.addItem` accepted the experimental pistol | Instantiation, withdrawal, or equip |
| Raw CH8 pistol on Ethan | `_CH8PlayerStatus` was null; campaign had no `CH8ShellManager` | That every gun failure has the same cause |
| Forced adapted pistol | Native `shoot`/`fireBullet` ran; magazine decreased 7 to 6 with trainer infinite ammo disabled | Normal inventory equip, correct animation, reload, damage, persistence |
| Imported prefab readiness | Four imported handles reported `Exist=true`, `Standby=true`, but `Ready=false`, `Valid=false` in a fresh campaign | A missing physical file |
| Explicit knife load | Standby off, same path reassigned, standby on; a later probe saw `Ready=true`, `Valid=true`, then instantiated the prefab | Inventory ownership or attack readiness |
| Deferred knife insertion | `isCanAddItem` returned true; `addItem(app.Item, via.GameObject)` with a null out argument threw | Whether the cause is the Lua out-argument marshalling or native item setup |
| AMG-Dual | Lab punches/charges damage campaign Molded; cold equipped load with explicit dependencies | Complete campaign lifecycle and normal held-button charging |

The forced pistol experiment included temporary motion-bank/name experiments and
did not use a normal inventory-owned weapon throughout. It is useful evidence of
the base bullet path, but must not be reported as a clean compatibility pass.
These historical lab results are superseded only where the campaign-pass table
above records a stronger check; they must not be generalized to all four weapons.

The campaign bullet RCOL already includes `Handgun_Albert_C` damage 300,
`Handgun_Albert_C_L` damage 1000, and `Shotgun_Albert` damage 60. The inspected base
gun path supports bullet types 20/21 for WeaponID 49 and 22 for WeaponID 50.
These are source/runtime mapping observations, **not measured enemy damage**.

Original Ethan motion-bank probes returned 48 -> 30, 49 -> 100, 50 -> 120,
13 -> 110, and 58/61..67 -> 0. Campaign Albert IDs 9/46 returned 101 and M37 ID 11
returned 160. Do not globally rewrite WeaponIDs to borrow animations: identity
also drives bullet type, parameters, saves, and equip behavior. A bank mapping
alone does not prove that all required motions exist or transition correctly.

## Why AMG-Dual is different

### Additional source evidence (2026-10-10)

Joe's complete player object is serialized as `Pl9000` in
`ch9/scenes/chapter/c09_ingame.scn.20`, not `chapter9resident.scn.20`.
Its prefab reference is `CH9/Prefab/Character/Pl9000/Pl9000.pfb`. This scene
provides the complete component inventory even when that prefab is absent from
the local extracted subset. The motion uses `pl9000.motbank` and
`pl9000_JointMap.jmap`; its ten FSM layers include Body, Weapon, RHand,
TouchWall, PosturalCamera, DamageCamera, AddBlend, and WeaponUpper resources.
These are player resources, not dependencies contained in the gauntlet item PFB.

Live static TDB fields give Joe's bank IDs: bare knuckles 5, AMG-78a 6,
AMG-78 7, AMG-Dual 8, Spirit Blade 10, throwing knife 300, throwing spear 310,
and liquid bomb 230. Chris's grenade/incendiary/neuro-stun banks are 260/270/280.
These constants establish mappings, not that Ethan's bank contains those motions.
Spirit Blade's bank 10 is the same family as the campaign hand axe.

`CH9/Prefab/Weapon/CH9ThrowWepParam.user` supplies Spirit Blade recovery values
100 and 150 (`Wp1700RecoveryValueS/L`). Its source weapon owns CH9 status/order
references and `checkAttackHit()`; the base-melee lab conversion omits that native
healing path. Healing must be driven by confirmed hits, not clicks or every frame
of an active attack. Do not change the inventory/native WeaponID to borrow a bank.

The 2026-10-10 cold campaign load registered the isolated Spirit Blade PFB,
accepted its deferred load request and an item-box entry. Normal item-box withdrawal
and the examine model worked. Ethan equipped native ID 63 and accepted mouse-driven
melee attacks with hand-axe bank 10. Subsequent hallway combat confirmed native
damage against a campaign `Em4000`: a 100-point base hit reduced health by 60,
after its normal resistance. Request sets 0/2/4 activated during `Melee.AttackL`
and unregistered when the swing ended; `IsAttacking` also returned to false.

The bank hook must exist **before equip**. Equipping unsupported ID 63 first entered
`Melee.ReadyStart` with frame/end-frame both zero. Changing the bank afterwards did
not restart the animation, and subsequent `Inventory.equipWeapon` calls stayed
pending (`isUseItemRequested=true`, `isUseItemTried=false`). This initially looked
like an absent axe motion resource. In fact, `getActiveMotionBankCount` included
`pl0000_Ax`, bank type 10; `getMotionBankCount` returned zero and was not a valid
inventory of the active banks. A one-shot research restart of the already-stalled
ready state proved the resource worked. The checked-in adapter does **not** force
FSM states: installed before a fresh knife-to-blade equip, it allows the native
ready/idle/attack transitions to complete normally. `dlc_weapon_player.lua` changes
the bank return for ID 63 and the exact imported prefab path. It accepts active
campaign Ethan (`Pl0000`, `Pl0000_Chapter1`), Mia (`Pl2000`, `Pl2100`) and VHS
Clancy (`Pl3000`), selecting available bank 10 or falling back to bank 30. Ship Mia
uses Ethan's complete bank. In the loaded ship save, `Pl2100` equipped native ID
63 and completed a mouse-driven swing with request sets 0/2/4, returning to idle
with no registered hit sets. This was a staged inventory test, not normal pickup
or storage certification; direct menu calls threw after partially doing their
work. Do not retry a failed native inventory call without inspecting ownership.
Continuous story transitions and VHS validation remain open.
Bank availability also needs an exact identity check: in live Ethan,
`findMotionBank(0, 9911)` returned `pl0000_Hands` with bank ID/type 0/0 even though
type 9911 did not exist. A non-null result is not proof that the requested bank
exists. The adapter verifies the returned `BankID` and `BankType`; its regression
test models this fallback instead of returning null for an absent bank.
Do not confuse `Pl3100_Chapter7_#` with Mia: these belong to the Bedroom, 21 and
Nightmare DLC scenes, as the area catalog confirms. They remain excluded.
The lab must be armed; the campaign uses both config flags.
It does not rewrite weapon identity or alter DLC players.

The shared recovery adapter observes `DamageController.addDamageCore`, whose returned
`DamageRecord.AddedDamage` and receiver health change both confirmed real damage
in the live test. The record's `CalculatedDamage`, `AddedDamage`, and `DamageInfo`
are fields; `get_DamageController()` is a real accessor. Recovery requires positive
added damage, enemy health loss, the tracked weapon attacker, and the current
player identity. It queues 100.0 health (150.0 for an aimed attack) for UpdateBehavior,
with one recovery per attack window and no native hit-object retention between
frames. Loads, disarming, and weapon/player changes invalidate pending recovery.
A live light strike healed Ethan from 500 to 600 HP; a deliberate wall swing left
health at 600, and the next landed strike healed to 700. Aimed recovery still
requires runtime validation. The solution built with zero warnings
or errors, and all 22 Lua 5.4 suites passed after this adapter was added.
`Weapon.onAttackTrigger/offAttackTrigger` hooks did not fire for this observed
attack path, so they are not used as the recovery reset mechanism.

A normal manual save retained Spirit Blade in inventory and equipped state. A
fresh process loaded it successfully with the campaign adapter: ID 63, campaign
prefab `Ready=true`, bank 10, pause zero, and a normal mouse attack returning to
idle. The first lab-only cold load stalled until a deferred prefab request was
made; serialized `Standby=true` alone was insufficient. The campaign preload must
include Spirit Blade before inventory restoration waits on that handle. Do not
mistake this loading-screen stall for a corrupt save. Damage randomization changes
only the namespaced attack RCOL; source CH9 RCOL bytes remain unchanged.

Combat test setup matters: a spawned Molded immediately self-suspended in the
safe room even after disabling its explicit self-suspend option. The same setup
stayed active in the adjacent hallway. The staged human `Em3100` was not a valid
damage control: even a vanilla G17 shot produced no damage there. Do not infer a
weapon RCOL failure from an unverified target. The eventual test protection only
disabled incoming player damage; enemy resistance and health handling stayed native.

A separate deployment check
found current campaign assets alongside an older installed `BioRand7.lua` that
did not require or update `dlc_weapons.lua`; enabling the config alone therefore
did not load the four existing prefabs. Deploy the entrypoint and feature modules
together. After the matching entrypoint was loaded, all four became ready.

### Player-system requirements

The gauntlet inventory prefab has Transform, Item, and `CH9Weapon1600`; it is not
a self-contained pair of animated weapon meshes. The earlier IDA trace shows
`CH9Weapon1600.onInsertInventory` resolving `CH9PlayerEquipManager` from its owner
and registering a knuckle weapon.

That manager uses `ICH9PlayerOrder`, `CH9PlayerWeaponChange`, and
`CH9PlayerMeshController`. Actual punching is implemented by
`CH9PlayerKnuckleWeapon : WeaponGun` on Joe's player/hand system. Its references
include `ICH9PlayerStatus`, `ICH9PlayerOrder`, and `CH9PlayerSequenceManager`; it
switches default/gauntlet IDs and has separate left/right-hand and stomp behavior.

Ethan lacks this input, combo/charge, sequence, hit-window, and mesh-switching
chain. Replacing `CH9Weapon1600` with `app.Weapon` would not implement AMG-Dual.
The remaining investigation is a player-system adapter, including cancellation,
damage reactions, guarding, scripted interactions, and restoring Ethan's state.
Do not activate a whole Joe player/gameplay root to satisfy one missing interface.

Joe's serialized right/left hand children use `pl9010.mesh` / `pl9020.mesh` and
matching materials, not a mesh in the inventory prefab. Their gauntlet emissive
materials are controlled by `CH9PlayerMeshController.setGantletParts`. The base
player's hand meshes and the gauntlet variants therefore need a reversible visual
adapter, in addition to attack logic. The native motion resource API successfully
loaded Joe's Knuckle (53 motions), GauntletW (64), Gauntlet (26), and GauntletR (26)
lists into unused diagnostic dynamic banks on Ethan. This proves resource loading,
not animation retargeting or gameplay. Finite raw punches exist alongside blend
trees: e.g. right straight 2440 (60 frames) and its hit reaction 2565 (28 frames).
Never treat a blend-tree end frame of -1 as a missing resource.

### AMG-Dual campaign prototype

The lab exporter now has a sixth asset candidate, `CH9_WP006` / native WeaponID
67, but it remains excluded from campaign pools and debug grants. The stock lab
helper does not yet expose it: the following observations used an isolated,
temporary player adapter, not a complete shipped implementation.

- Converting the inventory component to base `app.Weapon` avoids Joe's
  `registerKnuckleWeapon` callback. Campaign inventory recognized a one-slot,
  quick-selectable weapon with icon 905, its name and description. Native box
  withdrawal and equip were exercised; normal two-way storage and cold save/load
  are not yet certified. The original description still mentions Extreme Challenge.
- Joe's GauntletW motion list is an override, not a complete bank. It lacks idle
  and the first punch. Three owned dynamic banks with the same isolated type,
  ordered GauntletW, Knuckle, then Ethan's axe fallback, produced a normal
  `ReadyStart -> ReadyIdle -> AttackL -> AttackLToReady -> ReadyIdle` path.
  Base campaign banks were not overwritten. Special idle also completed normally.
  A temporary gap while replacing the research hook stranded an existing idle
  motion; never disable a bank mapping underneath an equipped weapon.
- Joe's hand meshes/materials can replace Ethan's existing hand renderers and
  follow his animated joints. Restore the exact original resources and part mask
  on unequip. Enabling all gauntlet parts was only a visual loading proof, not a
  validated variant selection.
- The inventory prefab has no skeleton or collision components. The exporter
  adds the ordinary melee HitController/RequestSetCollider component pair and an
  isolated subset of Joe's player RCOL: right/left hooks, right/left uppercuts,
  the two both-hand charge levels, and the left straight finisher. Request IDs
  are compacted to 0 through 6 (the finisher is 6);
  native attack userdata, shapes and bone names remain intact. Source RCOL is not
  changed.
- Do **not** clear the RCOL joint names and attach these shapes to a palm. Joe's
  capsules use upper-arm/forearm-local coordinates. A hidden mesh on the weapon,
  using the active player's body mesh/material, an identity local transform,
  empty attachment joint, and SameJointsConstraint provided both arm skeletons.
  All six tested arm/palm joint positions exactly matched Ethan. Joe's right-hand
  mesh alone supplied only right-arm bones and was insufficient for Dual-AMG.
  The serialized Transform field is spelled `SameJointsContraint`; the live
  accessor is `set_SameJointsConstraint`.
- A mouse-driven prototype punch registered the native right-hand attack only
  during its bounded animation window. `addDamageCore` recorded native attacker
  `wp1620_GauntletW_Item`, raw damage 300, calculated/added damage 180, and a
  matching 180 HP loss on a normal campaign Em4000. The collider unregistered and
  the attack returned to idle. Enemy resistance was unchanged; test protection
  blocked only incoming player damage. This proves native combat routing, not
  exact timing parity with Joe.

Further runtime findings from the isolated adapter:

- `PlayerMotionController.updateLArmMotion` both selects a motion work entry and
  dispatches it to the motion FSM. Copying the right-arm entry after this method,
  or skipping it without dispatching the replacement, leaves the left arm in
  `RemoveWeapon`. A scoped equivalent dispatch synchronized layers 1, 2 and 9.
- The native CH9 mesh controller selects parts 2 and 3 for non-VR dual gauntlets,
  with parts 0, 1 and 4 disabled. This replaced the all-parts loading experiment.
- Read `app.Collision.ColliderTrack` from each active raw `MotionNodeCtrl` through
  `getSequenceTracks`. A successful read alone does not mean an active hit window:
  `RequestId` is -1 outside it. Right/left hook windows were observed around frames
  26 through 31, later than the initial approximate test window.
- Direct `TreeLayer.changeMotion` is not a complete FSM transition. Raw punches
  can finish while the FSM remains in `Melee.AttackL/R`. A one-shot normal-priority
  request to the corresponding `AttackL/RToReady` state returned both tested hooks
  to idle. The straight finisher requires `AttackStraightV2_Double`, not the left
  uppercut's collider or damage value.
- The two-hand charge clip carries
  `app.SequenceTrackObject.CH9PlayerGauntletChargeLevel` markers. Reading those
  tracks reached charge level 2 in campaign. However, replacing the raw clip also
  left `PlayerMelee.actionID` unknown; animation and charge markers alone do not
  prove working attack/cancel dispatch.
- A test hook on `CommandUpdater.isRequested` can give false confidence: native
  melee code may fetch the command group and read `IsRequested` directly. A queued
  request observed in an updater hook was absent at melee consumption time. Keep
  diagnostic command injection separate from normal-input acceptance evidence.

The standalone `dlc_gauntlet.lua` lab adapter was subsequently tested after a
process restart, without the EMV resource helper or live collider repairs:

- Right and left mouse-click punches both reached the campaign Molded's native
  `DamageController.addDamageCore`: 300 raw damage, 108 applied in that contact.
  The finisher delivered 500 raw / 300 applied; the level-2 charge delivered
  3,000 raw / 1,800 applied. These values are observations, not fixed campaign
  damage multipliers. Only incoming player damage was blocked for the test.
- The motion name is not authoritative for collision selection. Clip 2443 is
  named `Knuckle_Attack-R-Uppercut`, but emits request 45,
  `AttackBodyblowR_Double`, rather than request 44, `AttackUppercutR_Double`.
  The exported request and runtime marker must agree. The adapter now checks
  exact source IDs (43, 40, 45, 42; charged attacks 32/33), not any nonnegative ID.
- Native `MotionDelegateTagManager.addTagFromMotion` loses the melee action tag
  after a raw clip replacement. A narrowly scoped post-hook adds the native
  `MeleeAimIdle` tag, with `PlayerMelee` as sender, for the two owned charge clips
  in the corresponding aim FSM states. This restored attack/cancel dispatch.
  No tag-list pointer writes or global action-ID overrides are needed.
- Native `SequenceTrackObject.CH9PlayerGauntletChargeLevel` markers reached
  level 2. `Melee.AimAttackC` selects missing campaign clip 2407, which the
  adapter replaces with 2690 or 2691. Both attacks returned to idle. Charge
  tests used bounded diagnostic native command requests, not held-button input;
  normal held-RMB acceptance remains a separate test.
- Switching to Knife during charging restored both original Ethan hand meshes
  and bank type 30. Re-equipping reused exactly three owned dynamic banks.
  Pausing inside an active punch cleared all registered attack colliders;
  resuming completed the animation without rearming that interrupted hit.
- `app.PauseManager` is not a managed singleton. Check the actual
  `app.GameManager.get_IsPause` and scene-loading state. The current motion task
  must also be the non-null owner task before requesting gauntlet collisions.
- `sdk.create_resource` plus `REResource:create_holder` supplies the mesh,
  material and motion-list holders directly. Balance the temporary resource
  reference on success and failure; retain holders and original hand resources.
  Verify hand ancestry and exact motion-bank identity before changing anything.
  Keep the isolated banks until their native player is destroyed, rather than
  removing a bank while native animation state may still refer to it.

The opt-in lab now exposes AMG-Dual and disarms its adapter on update failures.
Its Lua regression coverage includes ownership guards, cached resource creation,
all four punch mappings, both charge levels, finite completion, pause/external
task/death suppression and refusal to reclaim another bank's slot.

Remaining work includes normal held-button charging and feedback, combo timing,
guard/damage/event interactions, broader load/player transitions, normal
pickup/two-way storage and resource teardown.
Do not promote this candidate based only on animation or isolated damage tests.

### Cold-load gauntlet failures

A disposable manual campaign save with AMG-Dual equipped exposed startup
problems that warm re-equips had hidden:

1. The player becomes discoverable before its motion manager, fallback bank and
   hand renderers are ready. Preparation now resolves all dependencies before
   allocating resources or appending banks. Scene loading does not consume the
   bounded post-load readiness timeout. Initial equip also waits for player control.
2. Native saved equip can select `Melee.ReadyStart` before bank type 9910 exists,
   leaving an empty clip with end frame zero. After the actual idle clip becomes
   available, one normal-priority `Melee.ReadyIdle` request repairs that initial
   state. It does not force an FSM state or replace a finite equip/other action.
3. Correct mesh/material paths and non-null resource holders do not prove native
   readiness. Both hand renderers remained invisible with `MeshReady` and
   `MaterialReady` false. Waiting for Ethan's original hands to finish loading
   did not solve this, while switching away and back could hide the failure.

The successful cold-load configuration combines two hidden Transform/Mesh children
in the inventory prefab with the explicit `_Data/dlc_gauntlet_assets.txt` dependency
set. The hidden children preload Joe's hand resources; the existing Ethan hand
renderers still perform the visible swap. No Joe gameplay components are imported.
The manifest includes both hands, MDFs, streaming texture companions, record-system
textures/render targets, and GauntletW/Knuckle motion lists. Only paths are committed,
not extracted game assets.

Controlled comparison using the same save and runtime adapter:

- Hidden mesh references without the dependency copy left the item prefab unready
  and blocked loading. Adding unused resource-table paths also stalled; this did
  **not** establish that unused table entries themselves were the cause.
- Copying the dependencies with the original componentless prefab allowed loading
  but still produced invisible, unready hand renderers.
- Hidden native mesh references plus the dependency copy loaded the saved equipped
  gauntlets visibly, with both mesh/material readiness flags true and no manual
  re-equip. The initial empty-motion recovery reached idle automatically.

The exact native reason runtime-created holders fail on first binding has not been
isolated. Do not replace this evidence with arbitrary delays or per-frame rebinding.
An existing save loading after a preload fix is also evidence against prematurely
diagnosing the earlier loading-screen stall as save corruption.

Other blocked families have distinct requirements:

- CH8 grenades use standby, pin-pull, timed throw, underthrow, stock consumption,
  collision adjustment, and `CH8ShellManager` grenade pools.
- CH9 throwing knives and spears derive from `CH9WeaponThrowable`, with their
  own equip/throw/use-type lifecycle. They are not conventional `WeaponGun`s.
- Spirit Blade has `RequestSetCollider`, CH9 owner status/order, attack-hit checks,
  and recovery values. A knife mesh swap would omit its behavior.
- Stake Bomb also has `CH9WeaponLiquidBombAppend`; a campaign remote-bomb ID is
  not automatically an equivalent implementation.

## Pitfalls to carry forward

1. **Prove the test environment first.** Trainer infinite ammo, instant kills,
   frozen item-box counts, and random-event ammo bonuses were confounders here.
   Record and restore their settings. Confirm the native infinity flag as well
   as the HUD before interpreting ammunition results.
2. **Separate registration, resource loading, initialization, and ownership.**
   Loaded `ItemSettings._Settings` alone did not populate `_SettingsSearch` in a
   dynamic test; `setup()` did. The serialized lab uses the normal campaign load
   path instead of globally replacing settings at runtime.
3. **Prefab existence is not readiness.** Check `Path`, `Exist`, `Ready`, and
   `Valid`; then wait for native callbacks. Do not force awake/start or perform
   creation, inventory resizing, insertion, and equip in one callback.
4. **A filtered dump is not a component inventory.** `SceneProbe` prints only
   matching components. The CH8 PFBs do contain render/motion components, also
   visible in `residentweapons.scn`. An initial inference that they were stubs
   was disproved. Inspect the full component list before adding a hydration step.
5. **Respect actual TDB signatures.** `ItemManager.createItemInstance` is static.
   Generated C# `out GameObject` is not a literal Lua `via.GameObject&` signature.
   The raw method is `addItem(app.Item,via.GameObject)`, but finding it does not
   validate null out-argument marshalling. `Inventory` uses real
   `get_ItemSlotManager`/`get_ItemBoxData` accessors, not fields with those names.
6. **Do not use menu shortcuts as compatibility evidence.** Calling only
   `MenuManager.openItemBoxMenu` produced placeholder UI rather than an initialized
   inventory. A manual `InventoryMenu.setup` attempt threw. Reload after these
   failures; the lab intentionally has no open-box command.
7. **Treat failed mutations as terminal for that experiment.** A combined slot
   resize/insertion/equip experiment threw and then crashed RE7. The precise cause
   was not isolated. No resizing, direct insertion, forced equip, or retry loop is
   included in the committed helper.
8. **Use the smallest resource scope.** An isolated CH8 shell manager experiment
   initialized 30 bullets and 6 shells per grenade type, but this was not a full
   gameplay proof. The source `CH8_SystemObject` also owns mode services; importing
   it wholesale risks rank/mission/singleton interference.
9. **Keep item and interaction IDs synchronized.** Future pickups need both
   `app.Item.ItemDataID` and independent `app.fsm.ItemAddTest._ItemDataID` paths
   rebound. Native `ItemResource` registration/detail-search resources are a
   separate requirement from inventory prefab registration.
10. **Certification and selection are separate.** Keep the experimental campaign
    gate independent of DLC and unlockable permission. The full source catalog is
    not a usable weapon pool. `Shotgun_DB` stays the canonical reverse lookup for
    WeaponID 13; Joe's M21 is a separate inventory ID but shares stats/ammunition.
    Non-repeating selections treat the two IDs as aliases.
11. **Cached templates may already be wrong for the new mode.** The embedded
    template scene already contains raw DLC objects. A create-only-if-missing
    branch silently reused them. Campaign adapters explicitly replace those
    cached entries once. Donor gun components must use the imported native ID,
    not merely the new ItemDataID and mesh. Tactical Knife uses the MiaKnife pickup
    shell because the ordinary Knife template lacks the required interaction child.
12. **Preserved FSM pickups need identity repair too.** Replacing a template only
    covers cloned pickups. Preserved objects and configured bird cages also need
    their existing weapon component rebound. Matching local ItemAddTest IDs are
    rewritten without changing object GUIDs or FSM UIDs. External parent/sibling
    FSM references still require scene-specific runtime validation.
13. **Check raw field names and offsets.** `InventoryItemIcon.ParentItemParam` is
    backed by `<ParentItemParam>k__BackingField`, not a same-named field. At the
    inspected layout, InventoryMenu offset `0x2A0` is `_SelectedMoveItem`, not
    `_FocusItemIcon` (`0x298`). A plausible-looking generated property or nearby
    offset is not enough to justify a mutation.
14. **Lua assertions can change native argument counts.** `assert(value, message)`
    returns both arguments. At the end of a Lua argument list, it can accidentally
    pass the message to `object:call` as another native argument. Assert separately
    or parenthesize the expression. Validate against the live TDB signature.
15. **Input and capture failures are not weapon failures.** Short synthetic key
    taps were inconsistently consumed by the game, including vanilla controls.
    Prefer an observed native action and ammo transition over assuming a key was
    received. Do not force reload/shoot and then call it normal-input validation.
16. **Keep scope and parameter ownership explicit.** Readiness repair does not
    supply missing meshes or sounds. Copy the dependency manifest and resource
    registrations first. Isolate CH8 parameter/knife RCOL edits from source DLC;
    document deliberate aliases such as Joe's M21. The added campaign
    WeaponMotionController was not independently A/B-tested as a causal fix.

These are the same broad lessons as Em4400: serialized component parity does not
prove native initialization, and one successful animation does not prove a
complete behavior chain. Keep observations separate from root-cause hypotheses.

## Running the isolated lab

Use a disposable save/profile and back up saves and overridden loose files first.
Installed source DLC assets are required for export. The lab copies its curated
dependency manifests, but this is not a claim of complete sound/VFX closure.
Do not redistribute extracted game assets. The export writes campaign settings
and messages, so do not assume it composes with an arbitrary generated PAK or
another loose-file override.

```powershell
dotnet run --project src/biorand-re7 -- mod -m "DLC Weapon Lab" -i "<RE7 install>" -o out/dlc-weapon-lab
```

1. Deploy the explicit lab export using the normal mod workflow, with RE7 stopped.
2. Ensure the current `BioRand7/game.lua`, `BioRand7/dlc_weapon_lab.lua`,
   `BioRand7/dlc_weapon_player.lua` and `BioRand7/dlc_gauntlet.lua` modules are
   deployed. Run `tools/dlc_weapon_lab.lua` manually via ScriptRunner; do not
   add it to ordinary autorun or grant weapons on load.
3. Load Ethan's campaign. Enable commands, select one candidate, and use
   **Prepare prefab** once. Wait, then **Add to item box**. A not-ready error
   disarms the lab; investigate it instead of repeatedly forcing initialization.
4. Use a real item box and free the required slots normally. Test withdrawal,
   inspection, equip, attack, empty-magazine behavior, reload, ammo switching,
   re-equip, storage, and scene transitions. Inspect native weapon state too.
5. Return the test weapon to storage before **Remove boxed test weapons**. Only
   additions recorded in the current lab session are eligible for removal.
   New-game/load/script-reset events discard receipts; after that, reload an
   uncontaminated save instead of guessing which items belong to the experiment.
6. Do not save a production playthrough. Remove lab overrides with RE7 stopped,
   restore previous overridden files/settings, and restart to clear cached
   resources and temporary hooks.

The helper queues commands outside draw callbacks, executes each once, checks the
Ethan owner and exact lab prefab path, refuses duplicates, and disarms on errors.
Preparation requests loading only; it neither certifies the prefab nor repairs
the rest of the native lifecycle.

## Acceptance and next steps

Automated coverage includes the 14 source identities, rejected unsupported
adapters, default-off behavior, both permission gates, manifest extraction and
missing-resource preflight, deterministic lab export, serialized native identities,
pickup interaction rebinding, messages, ammo mapping, capacity changes, and the
WeaponID 13 alias. Lua coverage checks exact namespace guards, deferred bounded
loading, failures without repeated mutations, and load/new-game invalidation.

The campaign integration full test-project run passed 595 tests, and all 23 Lua suites
passed under Lua 5.4. The machine's `lua` command was Lua 5.1, so a compatible
Lua 5.4 runtime was used. Automated success does not remove the manual risks above.

Remaining acceptance work:

1. Reproduce normal pickup and item-box operations with no direct inventory/menu
   probes, starting from clean sessions. Isolate the later invalid-reference crash.
2. Test each candidate's equip, normal attack, enemy damage, reload, ammo switching,
   inspect view, re-equip, and two-way storage. Check the knife's hand pose explicitly.
3. Write and reload a disposable DLC-bearing save; cross scene/chapter boundaries,
   item-box transfers, Mia and VHS/Clancy transitions, and title-menu reloads.
4. Validate all candidate pickup families in a complete generated seed, including
   parent-controlled FSMs and any explicitly enabled bird-cage entries. Check sound
   loading separately; the curated manifest is not proof of a complete sound-bank
   closure. Check randomized loaded ammo on scene pickups as well as inventory PFBs.
5. Continue AMG and throwable player-system work separately from the conventional
   gun adapter. Keep unproven candidates out of generation and debug grants until
   their complete equip/attack/cancel/restore lifecycle is demonstrated.
