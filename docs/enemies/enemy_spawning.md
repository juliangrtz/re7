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

Live REFramework MCP singleton probing confirmed `app.EnemyGeneratorManager` is available in the running game. Use that runtime object, plus `app.DLCContentSceneManager`, `via.ResourceManager`, and `via.SceneManager`, when serialized DLC scene output looks correct but enemies or assets still do not appear.

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
