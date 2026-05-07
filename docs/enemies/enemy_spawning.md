 Enemy spawning in re7.exe is centered on three types:

  - app.EnemyGeneratorManager
  - app.EnemyGenerator
  - app.EnemyPool / app.EnemySpawnInfo

  The top-level entry is app.EnemyGeneratorManager::requestSpawn318333 at 0x14036F580, which quickly gates spawning behind a global FSM bool, then
  calls requestSpawn318334 at 0x140DA7700. That second function validates the EnemySpawnInfo request, rejects already-completed or already-live
  entries, checks the source GameObject is active, then iterates this->generators and calls app.EnemyGenerator::spawn50594 at 0x1417997A0 until one  returns a live GameObject.

  Inside a generator, the real work is split between:

  - app.EnemyGenerator::spawn50594 at 0x1417997A0
  - app.EnemyGenerator::spawnImplement50605 at 0x14179B8B0
  - app.EnemyGenerator::getFoundSpawnInfo50604 at 0x141750A10
  - app.EnemyGenerator::doUpdate50587 at 0x141743460

  What it does at a high level:

  - The generator locks itself and records the current requested EnemySpawnInfo.
  - It looks for matching spawn records in its pool by Guid and by UnitAlias.
  - It prefers reusing pooled instances rather than constructing fresh ones. app.EnemyPool::pickupInstanceAndInfo50573 at 0x141665700 builds those
    EnemySpawnInfo components into SpawnInfos and ForceSpawnInfos.
  - Normal spawn path: spawnImplement50605 finds a matching pooled unit, writes that unit’s GameObject into info->EnemyInstance, then calls
    app.EnemySpawnInfo::spawnInstance90109 at 0x1414AB380.
  - Force-spawn path is mixed into spawnImplement50605: if info->IsForceSpawn is set, it searches force-spawn candidates, can skip some correction/
  - requestOrder90106 at 0x140080EA0 forwards an order to the spawned enemy if an EnemyOrder exists.
  - reserveAppearAndThinkStateSet90116 at 0x140086860 stores delayed AI appear/think sets for application after spawn.
  - spawnInstance90109 marks the request as spawned, clears respawn wait, binds controllers off the live EnemyInstance (EnemyDamageController,
    EnemyActionController, EnemyStatus, EnemyOrder, MovementController, etc.), activates/configures the object, and applies movement/filter/map
    policy says cancellation counts as completion.

  The main runtime model looks like this:

  1. Pool startup scans level objects and pre-registers enemy instances plus their EnemySpawnInfo records.
  2. A spawn request comes in through EnemyGeneratorManager::requestSpawn.
  3. The manager tries each EnemyGenerator.
  4. A generator matches the request to a pooled spawn slot by GUID/alias.
  5. It binds the pooled GameObject into EnemySpawnInfo, calls spawnInstance, and optionally setupInstance.
  6. If the request is force-spawned or time-limited, extra handling in spawnImplement decides whether to complete, defer, or cancel the request.

  The important conclusion is that RE7 is not primarily “creating enemies from scratch” on each request here. The code I found is mostly a pooled-
  instance activation system driven by EnemySpawnInfo records and EnemyGenerator selection logic.

## DLC enemy component shapes

Main-game generator scenes normally use this hierarchy:

- `app.EnemyGenerator`
- `app.EnemyPool`
- `app.EnemySpawnInfo`
- `app.EnemySpawnInfoOptionEm####`

Not a Hero (CH8) scenes use their own generator and pool subclasses:

- `app.CH8EnemyGenerator`
- `app.CH8EnemyPool`
- `app.CH8EnemySpawnInfo`
- `app.CH8EnemySpawnInfoOptionEm####`

End of Zoe (CH9) enemy spawn-info objects use:

- `app.CH9EnemySpawnInfo`
- `app.CH9EnemySpawnInfoOptionEm####`

No `app.CH9EnemyGenerator` or `app.CH9EnemyPool` type was found in the current TDB, but CH8 definitely has both. For CH8 enemies in main-game generator scenes, replacing only the enemy-specific option component is not enough. The randomized generator should also be promoted to `app.CH8EnemyGenerator` and its child pool to `app.CH8EnemyPool`, while the individual spawn info should become `app.CH8EnemySpawnInfo`.

`app.EnemySpawnInfoOptionDLC` exists and `app.EnemySpawnInfo` exposes DLC-option-like state, but real DLC spawn infos do not universally include it. Prefer copying the real imported DLC spawn-info object shape for the target alias and copying only shared campaign fields from the original main-game spawn info.

Live CH8 runtime validation on 2026-05-07 showed that asset references are not the whole dependency chain. A real Not a Hero session has `app.CH8GameManager`, `app.AI.CH8AIWorldBlackBoard`, `app.CH8EnemyGenerator`, `app.CH8EnemyPool`, and active support folders such as `Enemy_c08/c08_AIMap` and `Enemy_c08/c08_MotherLoder`. IDA confirms that `EnemySpawnInfo.spawnInstance` must reach a valid setup request before `setupInstance` warps the enemy to the spawn-info transform and applies option-provided AI state. If a DLC enemy appears T-posed or at a template/default position, assume setup did not complete; check `MapParameter`, generator update, and `setupInstance` before chasing mesh/material load issues.

Do not force `scenes/dlc/dlc_active_root.scn`, `dlc_chapter8.scn`, or `dlc_chapter9.scn` standby from the main campaign as a shortcut for asset loading. Runtime testing on 2026-05-07 produced a boot black screen before `app.GameManager` initialization when those DLC root scene graphs were activated from the generated main-game PAK. Also do not activate CH8 gameplay/boss support folders such as `Mother_c08` or `c08_MotherLoder` from the main campaign just to pull resources; runtime testing loaded stray Mama Molded objects at CH8 coordinates. Copy their dependency closure, but only stand up support folders that do not introduce independent enemy generators, such as `Enemy_c08/c08_AIMap`, until the campaign-safe runtime mounting path is understood.

Live main-game testing on 2026-05-07 also showed that cloned CH8 `Em4400` pool children can appear T-posed and far from spawn-info locations if their `via.GameObject.Tag` is empty. IDA for `EnemyPool.pickupInstanceAndInfo` and live REFramework state matched: the pool registered only direct child GameObjects that satisfy its enemy-child predicate, deactivates those, and stores them in `Instancies`. Untagged CH8 template children stayed visible under the pool, were not added to `Instancies`, and never reached `spawnInstance` / `setupInstance`. Imported enemy templates therefore need the runtime root tag `Enemy` before insertion into a main-game `EnemyPool`.

After fixing the pool tag, live testing still left CH8 replacements inert because `EnemyGenerator.spawn` can take an early pooled-instance path that calls `EnemySpawnInfo.spawnInstance()` and returns without reaching the later force-spawn `setupInstance()` branch. The result is a bound enemy instance with `RequestedOperation = Setup`, no completed setup, and no warp/AI initialization. The managed REFramework plugin now treats DLC enemy integration as required when DLC enemy ratios are enabled and hooks `EnemySpawnInfo.spawnInstance` for imported `CH8EnemySpawnInfo` / `CH9EnemySpawnInfo` in non-DLC chapters, then calls `setupInstance()` immediately once the enemy controllers are bound. Do not remove that hook unless the native deferred setup path is made to run reliably in main campaign scenes.

A later live trace disproved the CH8 action-promotion idea. Promoted `app.fsm.CH8EnemyGenerate` actions updated in Chapter 4 and repeatedly called `EnemyGeneratorManager.requestOperation`, but the imported spawn infos still did not progress to a visible spawn. Keep main-campaign request actions as base `app.fsm.EnemyGenerate`; only the generator, pool, spawn-info, and enemy option/component chain should become CH8-specific. Scene-limit and multiplier code still recognizes CH8 generate-action classes defensively so older generated scenes can be analyzed or reduced, but the randomizer should not create them for campaign replacements.

A follow-up main-game trace found promoted `app.CH8EnemyGenerator` / `app.CH8EnemyPool` objects present but not ticking: their Dooms pause flags were enabled and their GameObjects had `UpdateSelf = false`. Imported DLC enemy setup in campaign scenes must therefore also force the generated CH8 runtime chain active. The managed plugin now prepares imported DLC enemy generators, pools, spawn infos, spawned enemy GameObjects, and bound enemy controller components before setup. It also clears imported CH8 `requestOptionWithNeedAreaList` queues outside Chapter 8 so campaign spawns do not wait on CH8-specific need-area logic.

Another live trace on 2026-05-07 found `Em4400` bound to an imported `app.CH8EnemySpawnInfo` but parked near world origin while the spawn-info GameObject was near the player. The CH8 command controller had a valid `CH8Idle` but `CurrentAction = null`; a single `CH8CommandActionController.doUpdate()` advanced it into idle. The plugin now rescues already-bound imported DLC spawn infos, explicitly runs the missing command-controller tick for `Em4400`, normalizes the spawn/alive flags, warps the enemy instance to the campaign spawn-info transform, and clears `RequestedOperation` to `None` once setup has been completed outside CH8/CH9.

Runtime traces are only valid while `re7.exe` is actually running. A disconnected MCP pipe or sudden empty/no-spawn readings should be treated as an environment signal first; one 2026-05-07 "no spawns" reading was caused by the game being closed.

REFramework.NET post hooks need compatible signatures at runtime, not just successful C# compilation. If a post hook needs method arguments, verify the binding in-game; otherwise prefer a pre hook. Also avoid forcing `DoomsBehavior.Enabled = true` on imported DLC components. A live test showed that changing `Enabled` can reset the imported CH8 pool and clear registered spawn infos/instances. Use pause flags and GameObject update/draw state instead.

Do not promote main-campaign `app.fsm.EnemyGenerate` actions to `app.fsm.CH8EnemyGenerate`. A 2026-05-07 runtime trace showed promoted CH8 generate actions updating with `Operation = Spawn` and valid `mySpawnInfo` references, then repeatedly entering `EnemyGeneratorManager.requestOperation` without producing visible campaign spawns. Keep the campaign's base generate actions as the request layer and adapt the generator/pool/spawn-info runtime underneath them.

Important CH8 alias quirks:

- `Em4210` is Fat Headless Molded. Its `UnitAlias` is `Em4210`, but its component/option stack is based on `CH8Em4200`.
- `Em4600` is Fumer. Its `UnitAlias` is `Em4600`, but its component/option stack is based on `CH8Em4000`.
- `Em4460` is Mama Mold. It has a normal generator-style source and also appears in a wrapper-style object with nested `Em4450` spawn info.
- `Em4500` is Mutated Lucas, the Not a Hero final boss. Treat it as a special-case/boss enemy, not a safe baseline integration target.

## Scene limit mapping

`app.fsm.EnemyGenerate::start357603` resolves its target `EnemySpawnInfo` by GUID first. It can fall back to
`app.ObjectManager::findObjectInContainer170087(containerName, objectName)`, but the base-game molded/hard spawn scenes inspected for this
work had empty `GameObjContainer` names and direct `SpawnInfo` GUID references.

IDA also showed that `via.SceneManager::loadScene267475` takes a path string, hands it to the resource manager, and the resource manager hashes
the path internally for lookup/caching. `EnemyGenerate` itself does not store that hash or a full path; it stores the target `SpawnInfo` GUID.
The useful static mapping is therefore:

1. collect enabled `EnemyGenerate.SpawnInfo` GUID references from the General scene being limited,
2. resolve those GUIDs through the vanilla `enemies.csv` spawn-info data,
3. disable surplus `EnemyGenerate` actions in the General scene only when the multiplier is already reducing the vanilla count.

This avoids a manual vanilla-scene-file column. The pooled `EnemySpawnInfo` records can still live in separate files such as
`natives/stm/scenes/chapter/chapter4/chapter4_2/moldeads.scn.20`; the cap acts on the General scene's requests that point at those records.
For neutral or upward multipliers, scene limits cap added vanilla enemies but do not delete the baseline vanilla requests.
