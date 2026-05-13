# RE7 World Map

`re7_world_map.json` is a source-backed scene map for placement safety and offline analysis. It joins the existing scene list, enemy-cap table, item placements, vanilla enemy rows, extra enemy anchors, and indexed scene targets into one file.

The map is intentionally conservative. It is not a navmesh, door graph, or exact collision model. It should be used as the first filter for enemy placement decisions, especially for large enemies and static blockers such as Elder Eveline in the wheelchair.

## Files

| File | Purpose |
| - | - |
| `re7_world_map.json` | Generated scene map. Current coverage: 1,278 scenes, 487 main-campaign scenes, 791 DLC scenes. |
| `Build-Re7WorldMap.ps1` | Rebuilds the JSON from the current repo data. |

## Safety Fields

| Field | Meaning |
| - | - |
| `confidence` | `Confirmed` means the scene has configured `enemy_limits.csv` capacity and class evidence; `Likely`/`Hypothesis` are naming/path based. |
| `safety.placementClass` | Coarse scene type such as `connectorOrPathway`, `smallRoom`, `openOrCombatArea`, `safeHub`, or `supportOrResource`. |
| `safety.blockerRisk` | Traversal-block risk. Treat `critical`, `high`, and `noDirectPlacement` as rejection reasons for large or static blockers. |
| `safety.largeEnemyPolicy` | `allow`, `discourage`, or `forbid` for large enemies such as Fat Molded or boss-scale enemies. |
| `safety.staticBlockerPolicy` | Static blockers are never auto-allowed. `manualOnly` still requires runtime route validation. |
| `safety.suggestedMaxExtraEnemies` | Configured cap when present; otherwise a conservative heuristic cap. |
| `stats` | Item/enemy/extra-placement counts and target GUID counts for data analysis. |
| `coordinateEvidence` | Bounds from known item/enemy/extra placement points, not room geometry. |

## Placement Use

Use the map as a hard prefilter:

1. Reject direct placement when `safety.blockerRisk` is `noDirectPlacement`.
2. Reject large enemies when `safety.largeEnemyPolicy` is `forbid`.
3. Reject Elder Eveline or other static blockers unless `safety.staticBlockerPolicy` is `manualOnly` and a live route probe proves traversal remains possible.
4. Treat `confidence != "Confirmed"` as requiring manual or runtime validation before enabling new randomized placements.
5. For Molded-style extras, keep checking `navigationMap` against the enemy navigation-surface rules in `.analysis/knowledge/EnemiesAndSpawning.MD`.

## Regeneration

From the repo root:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\docs\world\Build-Re7WorldMap.ps1
```

The generator reads only embedded repo data and does not touch a local RE7 install.
