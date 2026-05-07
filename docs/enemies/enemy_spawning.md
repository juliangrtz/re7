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

Static CH8 scene probing showed that `app.AI.CH8AIWorldBlackBoard` is serialized on `/CH8_SystemObject` in `ch8/scenes/chapter8.scn.20`, not in `enemy_c08.scn.20`. Do not inject this component directly into main `master.scn.20`: a live campaign test crashed after adding a cloned blackboard singleton without the full CH8 scene/runtime context. Do not import `app.CH8GameManager` or `app.CH8SaveManager` into the campaign master scene either; those remain chapter-specific.

Do not force `scenes/dlc/dlc_active_root.scn`, `dlc_chapter8.scn`, or `dlc_chapter9.scn` standby from the main campaign as a shortcut for asset loading. Runtime testing on 2026-05-07 produced a boot black screen before `app.GameManager` initialization when those DLC root scene graphs were activated from the generated main-game PAK. Also do not activate CH8 gameplay/boss support folders such as `Mother_c08` or `c08_MotherLoder` from the main campaign just to pull resources; runtime testing loaded stray Mama Molded objects at CH8 coordinates. Copy their dependency closure, but only stand up support folders that do not introduce independent enemy generators, such as `Enemy_c08/c08_AIMap`, until the campaign-safe runtime mounting path is understood.

Live main-game testing on 2026-05-07 also showed that cloned CH8 `Em4400` pool children can appear T-posed and far from spawn-info locations if their `via.GameObject.Tag` is empty. IDA for `EnemyPool.pickupInstanceAndInfo` and live REFramework state matched: the pool registered only direct child GameObjects that satisfy its enemy-child predicate, deactivates those, and stores them in `Instancies`. Untagged CH8 template children stayed visible under the pool, were not added to `Instancies`, and never reached `spawnInstance` / `setupInstance`. Imported enemy templates therefore need the runtime root tag `Enemy` before insertion into a main-game `EnemyPool`.

After fixing the pool tag, live testing still left CH8 replacements inert because `EnemyGenerator.spawn` can take an early pooled-instance path that calls `EnemySpawnInfo.spawnInstance()` and returns without reaching the later force-spawn `setupInstance()` branch. The result is a bound enemy instance with `RequestedOperation = Setup`, no completed setup, and no warp/AI initialization. The managed REFramework plugin now treats DLC enemy integration as required when DLC enemy ratios are enabled and hooks `EnemySpawnInfo.spawnInstance` for imported `CH8EnemySpawnInfo` / `CH9EnemySpawnInfo` in non-DLC chapters, then calls `setupInstance()` immediately once the enemy controllers are bound. Do not remove that hook unless the native deferred setup path is made to run reliably in main campaign scenes.

A later live trace disproved the CH8 action-promotion idea. Promoted `app.fsm.CH8EnemyGenerate` actions updated in Chapter 4 and repeatedly called `EnemyGeneratorManager.requestOperation`, but the imported spawn infos still did not progress to a visible spawn. Keep main-campaign request actions as base `app.fsm.EnemyGenerate`; only the generator, pool, spawn-info, and enemy option/component chain should become CH8-specific. Scene-limit and multiplier code still recognizes CH8 generate-action classes defensively so older generated scenes can be analyzed or reduced, but the randomizer should not create them for campaign replacements.

A follow-up main-game trace found promoted `app.CH8EnemyGenerator` / `app.CH8EnemyPool` objects present but not ticking: their Dooms pause flags were enabled and their GameObjects had `UpdateSelf = false`. Imported DLC enemy setup in campaign scenes must therefore also force the generated CH8 runtime chain active. The managed plugin now prepares imported DLC enemy generators, pools, spawn infos, spawned enemy GameObjects, and bound enemy controller components before setup. It also clears imported CH8 `requestOptionWithNeedAreaList` queues outside Chapter 8 so campaign spawns do not wait on CH8-specific need-area logic.

Another live trace on 2026-05-07 found `Em4400` bound to an imported `app.CH8EnemySpawnInfo` but parked near world origin while the spawn-info GameObject was near the player. The CH8 command controller had a valid `CH8Idle` but `CurrentAction = null`; a single `CH8CommandActionController.doUpdate()` advanced it into idle in one test, but later campaign tests showed even that narrow direct update can crash. The plugin should keep generic imported-DLC spawn-info rescue only: complete pending setup, normalize spawn/alive flags, warp the enemy instance to the campaign spawn-info transform, and clear `RequestedOperation` to `None` once setup has been completed outside CH8/CH9. Do not call CH8 command-controller lifecycle/update methods from the managed plugin in campaign scenes.

Follow-up testing showed that spawned `Em4400` instances could animate idle but not aggro or receive bullet damage. The plugin must not rely on every generated TDB member being callable on the campaign-runtime object: direct per-frame reads of inherited/CH8-specific members such as `visionSensor`, `hearingSensor`, `myThink`, `enemyThink`, and `myCommandActionController` produced `Member not found` spam. Resolve those systems from the enemy `GameObject` components and treat action-controller member writes as best-effort. Do not force-start `HitController`, `DamageController`, `RequestSetCollider`, or `ColliderSet` components from a per-frame plugin bridge; a live 2026-05-07 attempt to walk the imported hierarchy and call damage/collider lifecycle/update methods caused a crash. The damage/collision issue still needs a traced native CH8 comparison before adding another runtime fix.

The next live trace narrowed the idle `Em4400` failure further. The imported enemy `GameObject` had the expected CH8 component stack attached, but `CH8Em4400ActionController` and `CH8Em4400Think` had not cached those component references. The action controller still had null `myThink`, `enemyThink`, `myCommandActionController`, `myStatus`, status/order/damage/sensor references, and was marked as dead/finished; the think component likewise had null target, action/status/order/sensor/player-status references. Runtime bridging for imported CH8 pool instances should therefore bind existing components into the action/think/status/order/damage graph and clear dead flags. It should not force collider or damage lifecycle methods as a substitute for this binding.

A later trace against a real live CH8 `Em4400` instance found an important REFramework.NET trap: `IObject.As<T>()` is not a type check. It can create a proxy for an incompatible object, for example exposing `via.Transform` through an `app.CH8Em4400ActionController` interface until property access fails with `Member not found`. Component lookups in the managed plugin must validate the runtime TDB type chain against the target `REFType` before returning typed proxies. Unchecked proxy casts were a likely cause of the earlier `Member not found` spam and bad bridge writes.

The same healthy CH8 `Em4400` trace showed `CH8Em4400ActionController.myUpdateController = null` and no `app.CH8EnemyUpdateController` component on the enemy object. That is normal for this instance and should not be treated as the missing campaign-integration piece. The healthy instance had a fully bound action/think/command graph, `hasDie = false`, `isFinishedDead = false`, `think.Target` pointing at the CH8 player object, `playerStatus/targetStatus = app.CH8PlayerStatus`, and a live command action (`app.CH8Em4400.Action.CH8Splash` during the trace).

The real CH8 `Em4400` spawn-info state also differs from the earlier campaign rescue assumptions: a live spawned Mother Molded was `RequestedOperation = None`, `IsSpawned = true`, `IsAppeared = false`, `IsAlive = true`, `IsCompleted = false`, and `isCompletedOperation = true`. Imported campaign setup rescue should normalize toward that state after `setupInstance()`. Forcing `IsAppeared = true` and `isCompletedOperation = false` can leave the hybrid generator/spawn-info pair stale.

The managed plugin's Em4400 bridge should remain narrow: bind existing component references from the spawned enemy object, clear dead flags, target the player if the think component has no target, and avoid `CH8EnemyUpdateController` creation. Prefer native CH8 command registration when possible; only fall back to managed command-action construction when live state proves the native container/list is still empty.

Comparing a T-posed campaign `Em4400` against the healthy Not a Hero trace on 2026-05-07 narrowed the current failure to native command-action registration. The campaign instance had the correct `Enemy` tag, update/draw enabled, the expected 63-component CH8 stack, bound action/think/status/order/damage/sensor references, and CH8-parity spawn-info flags (`RequestedOperation = None`, spawned/alive/completedOperation true). The decisive difference was `CH8Em4400ActionController.MyCommandActionContainer.get_count() = 0`, `CH8CommandActionController.ActionList.Count = 0`, `currentActionNo = -1`, and `findIdleAction() = null`; the healthy CH8 instance had 29 registered command actions and a live current action. Static comparison of `mother_c08.scn.20` with `EnemyTemplate_Em4400` showed that `MyCommandActionContainer` and the action list are not serialized scene data, so they must be produced by native CH8 runtime registration. Do not call `setupInstance()`, force `isStarted`, synthesize actions, or tick `doUpdate()` before that registration exists; defer campaign setup until the native command container/list is populated, then trace the earlier lifecycle hook if registration never appears.

IDA MCP follow-up showed the native registration split: `app.CH8Em4400ActionController::doAwake149958` fills `MyCommandActionContainer`, and `app.EnemyActionController::doStart166846` calls `app.CommandActionController::regist45234` to transfer those actions into `CH8CommandActionController.ActionList`. In campaign-imported pooled instances the action controller can be engine-started while its CH8 `isStarted` flag and command container stay uninitialized, so the rescue first tries that native registration pair when the list is empty: call Em4400 `doAwake()` if the container is empty, then `regist(container)` if the container exists and `ActionList` is still empty. A later live probe showed campaign `doAwake()` can return before the Em4400 insert block, leaving both counts at zero; in that state, fall back to managed construction of the known CH8 Em4400 command actions, then continue setup only once `ActionList.Count > 0`. The managed fallback must match the healthy/native 29-action set; do not instantiate every generated Em4400 action class, and do not add the generic `CH8Damage`/`CH8Dead` classes unless a native trace proves they are present. The fallback should not force command-controller lifecycle or tick `doUpdate()`.

After command registration was fixed, live campaign `Em4400` testing moved from T-pose to active AI, then froze inside terminal command actions. `CH8Rush` and `CH8Splash` both reached `SmoothAnimator.CurrentState = EndTransition` with `hasRequest = false`, `isExecuting = false`, `isEndExecuting = true`, `ActionList.Count = 29`, and an active current command action whose `isActionEnd` stayed false while `activeTimer` kept climbing. A controlled REFramework write of only the current command action's raw `IsActionEnd` field advanced the controller back to `CH8Idle` for both actions. The managed plugin now treats this as a narrow imported-Em4400 campaign stall: only non-DLC chapters, current `app.CH8Em4400.Action.*`, active/non-satisfying/non-ended action, complete 29-action list, current-action address match, active owner, and completed SmoothAnimator transition.

When binding imported CH8 runtime references, do not use guessed backing-field strings through `IObject.GetField` / dynamic `SetField`. Some CH8 classes use exact private field names instead of auto-property backing fields, and object-reference writes through that path did not stick reliably. Also do not broad-write object references with `TypeDefinition.GetField(...).SetDataBoxed(address, value, false)`: a 2026-05-07 live `Em4400` bridge build corrupted the REFramework VM and crashed RE7. A follow-up no-op exact-field build still crashed until the remaining managed Em4400 action/think/status graph bridge and per-frame instance tick were disabled, so treat the whole managed graph-repair approach as unsafe for now. A later test showed that even the narrow one-shot `CH8CommandActionController.doUpdate()` idle kick can crash in campaign scenes. Exact TDB fields remain useful for identifying native layout, but live writes should only be attempted as single-field controlled probes. Prefer enumerating `GameObject.Components` before `getComponent(runtimeType)` for imported DLC objects; live `Em4400` instances exposed the full component array even while typed/inherited accessors failed.

If REFramework logs are spammed with `Invalid number of arguments passed to REMethodDefinition::invoke for app.MapManager.getMapCategory` / `getMapLevel`, check for a running `re-engine-mcp` process before blaming the managed plugin. On 2026-05-07 the MCP server process was still polling live runtime state and likely corrupted the VM while the game was being crash-tested.

Runtime traces are only valid while `re7.exe` is actually running. A disconnected MCP pipe or sudden empty/no-spawn readings should be treated as an environment signal first; one 2026-05-07 "no spawns" reading was caused by the game being closed.

The static managed REFramework plugin is loaded from the game's `reframework/plugins/managed` directory at process start. Building the repo updates the build output and embedded `_Data` DLL, but it does not hot-reload the already-loaded static plugin in a running RE7 process. When validating runtime fixes, compare the game plugin DLL hash/timestamp with the repo build output and restart RE7 after copying a changed static DLL.

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
