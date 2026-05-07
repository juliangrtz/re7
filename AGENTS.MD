# Agent Guide

## Scope

These instructions apply to the whole repository.

## Project Snapshot

BioRand 7 is a .NET 10 x64 C# cloud randomizer for Resident Evil 7. The main solution is `biorand-re7.sln`.

Important projects and directories:

- `src/Biohazard.BioRand.RE7/` - core randomizer library, modifiers, services, RE Engine serializers/helpers, embedded `_Data`.
- `src/biorand-re7/` - Spectre.Console CLI for setup, generation, updates, mods, and remote agent mode.
- `src/Biohazard.BioRand.RE7.DataGen/` - data/code generation tools for CSV/JSON/binary outputs and RSZ C# types.
- `src/Biohazard.BioRand.RE7.REFrameworkPlugins/` - REFramework.NET plugin, unsafe code, checked-in plugin DLL references in `lib/`, copies its build output into the core project bin folder.
- `src/Biohazard.BioRand.RE7.Tests/` - xUnit behavior/regression tests over the embedded baseline pak.
- `src/reeutils/` - git submodule for RE Engine tooling. Do not edit it casually; call out any intentional submodule changes.
- `docs/` - active reverse-engineering notes and roadmap. Read `docs/Notes.MD` before changing item, enemy, inventory, recipe, chapter, or DLC logic.
- `.analysis/re7_src/` - locally generated REFramework.NET C# type database. Prefer it for DLC class names, inheritance, fields, and enums before spending time in IDA.
- `assets/`, `reframework/`, `reversing/`, `dumps/` - mod assets and research material. `dumps/` and local output folders are not normal source changes.

## Before Editing

- Check `git status --short` and preserve user changes.
- If dependencies look missing, run `git submodule update --init --recursive`.
- Prefer focused edits. This code touches game binaries and softlock-prone state; avoid broad refactors unless the task asks for them.
- Keep generated/game-data churn deliberate. Large diffs in `_Data`, `GeneratedEnums.cs`, `GeneratedTypes.cs`, or binary assets need a clear reason.
- For DLC work, check `docs/Notes.MD`, `docs/enemies/enemy_spawning.md`, `docs/enemies/spawnInfoOptions.md`, and the relevant `.analysis/*-findings.md` note before editing.

## Build And Test

Commands below are PowerShell examples from the repo root. Adapt path separators if needed.

```powershell
dotnet restore .\biorand-re7.sln
dotnet build .\biorand-re7.sln --no-restore
dotnet test .\biorand-re7.sln --no-build --verbosity normal
```

For a focused test pass:

```powershell
dotnet test .\src\Biohazard.BioRand.RE7.Tests\Biohazard.BioRand.RE7.Tests.csproj --verbosity normal
```

CI currently checks out submodules, installs .NET 10.0, then runs restore, build, and test. If .NET 10 is unavailable locally, say so rather than downgrading target frameworks.

## CLI Usage

Run the CLI through the project:

```powershell
dotnet run --project .\src\biorand-re7\biorand-re7.csproj -- generate -o .\out\biorand-re7.pak --seed 35825
dotnet run --project .\src\biorand-re7\biorand-re7.csproj -- setup -i "C:\Program Files (x86)\Steam\steamapps\common\RESIDENT EVIL 7 biohazard" -o .\out\custom.pak --full
dotnet run --project .\src\biorand-re7\biorand-re7.csproj -- update
dotnet run --project .\src\biorand-re7\biorand-re7.csproj -- mod
```

Safety notes:

- `generate --kill` terminates `re7.exe`; use it only when explicitly requested.
- URL generation reads auth/server settings from `%USERPROFILE%\.biorand\local.json`; never commit tokens or ask the user to paste them into repo files.
- `setup` reads a local RE7 install and writes extracted game assets. Do not run it against a user install path unless the user supplied/approved that path.
- Generation may extract logs or natives into the current directory or `%USERPROFILE%\.biorand\extract` in Debug builds. Keep those out of commits.

## Data Generation

Run DataGen through:

```powershell
dotnet run --project .\src\Biohazard.BioRand.RE7.DataGen\Biohazard.BioRand.RE7.DataGen.csproj -- generate config
dotnet run --project .\src\Biohazard.BioRand.RE7.DataGen\Biohazard.BioRand.RE7.DataGen.csproj -- generate areas item_placements item_definitions weapon_definitions enemies
dotnet run --project .\src\Biohazard.BioRand.RE7.DataGen\Biohazard.BioRand.RE7.DataGen.csproj -- rsz-to-cs app.TypeName --with-enums
```

DataGen writes to `GeneratedFiles/`; generators with `CopyToDataDirectory => true` also overwrite files in `src/Biohazard.BioRand.RE7/_Data/`.

When changing configuration defaults:

- Update `RandomizerConfigurationDefinition.cs`.
- Regenerate `default-profile.json` with the `config` generator when defaults should change.
- Add/adjust tests for the affected option.

Dynamic CSV data can also be refreshed by the CLI `update` command from Google Sheets. Do not silently refresh remote data as part of an unrelated change.

## Coding Conventions

- Use nullable-aware C# and file-scoped namespaces.
- Follow existing local patterns before adding abstractions.
- Use structured RE Engine APIs (`RszScene`, typed user files, `PakPath`, services/repositories) instead of ad hoc byte or string edits when available.
- Keep randomization deterministic. Use `Randomizer.GetRng(...)` with stable keys; avoid `Random.Shared`, `Guid.NewGuid()`, time, unordered iteration, or process-dependent randomness.
- Modifier order in `Randomizer.GetModifiers()` matters. Treat changes there as behavior changes!
- Use `Randomizer` services (`AreaService`, `ItemRandomizer`, `FlagService`, `TemplateService`, etc.) rather than duplicating stateful logic.
- Do not run whole-tree formatters over generated files or vendored/submodule code.

## Tests

Use the existing xUnit helpers:

- `RandomizerTest.CreateFeatureTestConfiguration(...)` starts from defaults and disables most features so tests can enable one behavior at a time.
- `RandomizerTest.RunState(...)` gives before/after repositories and changed-file snapshots.
- `RandomizerTestPaths` centralizes common pak paths.
- `RandomizerTestHelpers` contains readers for scenes, chapter jumps, bird cages, and attack userdata.

Tests should not require a local RE7 install or Google Sheets. The test harness copies the embedded `biorand-re7.pak` to `%USERPROFILE%\.biorand\biorand-re7.pak`.

When game behavior cannot be fully proven by unit tests, add the closest regression test and document the remaining manual validation risk.

## Game-Specific Hazards

Softlock prevention beats chaos.

- Recipes must use valid `app.ItemID` values. The combine dictionary must reference valid recipe DataIDs. Invalid recipe data can stop the game from loading.
- The vanilla combine menu has strict limits; extra visible recipes rely on REFramework behavior.
- Enemy FSM UIDs are not arbitrary IDs; they can be hard-coded state IDs. Preserve valid UIDs unless the code deliberately remaps them.
- Roaming enemies, bosses, elevators, waypoints, and navigation surfaces are especially fragile. Check `docs/Notes.MD` before touching enemy placement logic.
- Starting inventory and inventory-size changes affect multiple Ethan, Mia, and VHS/Clancy files.
- Chapter shuffling and key-item changes can softlock progression. Prefer explicit constraints and behavior tests over pure random placement.
- Some options require REFramework artifacts (`recipes-add-new`, forced REFramework, non-12 inventory sizes). Keep `Randomizer.IsREFrameworkRequired()` in sync with new requirements.
- DLC integration usually requires the full runtime component chain, not only assets or IDs. For CH8 enemies this means `app.CH8EnemyGenerator`, `app.CH8EnemyPool`, `app.CH8EnemySpawnInfo`, and the matching `app.CH8EnemySpawnInfoOptionEm####`; for CH9 generator spawns at least `app.CH9EnemySpawnInfo` and `app.CH9EnemySpawnInfoOptionEm####` are required.
- Imported DLC enemy generator spawns also need REFramework runtime handling. Main-game CH8/CH9 replacements can bind pooled instances but remain at `RequestedOperation = Setup`; the managed plugin hook completes `EnemySpawnInfo.setupInstance()` after `spawnInstance()` for imported DLC spawn infos outside CH8/CH9.
- CH8 replacements also need request-side FSM promotion. If an enabled `app.fsm.EnemyGenerate` action targets a promoted `app.CH8EnemySpawnInfo`, convert it to `app.fsm.CH8EnemyGenerate`; scene-limit and multiplier helpers must remain aware of both vanilla and CH8 generate-action classes.
- `CH8` is Not a Hero and `CH9` is End of Zoe. Jack's 55th Birthday uses Birthday/FsmBirthday classes, not CH8 classes.
- DLC enemy aliases can reuse another enemy's option/component stack. Examples: `Em4210` uses the `CH8Em4200` stack and `CH8EnemySpawnInfoOptionEm4200`; `Em4600` uses the `CH8Em4000` stack and `CH8EnemySpawnInfoOptionEm4000`.
- Treat boss DLC enemies as special cases until runtime-proven. `Em4500` is Mutated Lucas, the Not a Hero final boss, and should not be used as the representative CH8 test enemy.
- DLC asset loading needs scene-root activation plus dependency closure copying. Do not assume that adding a prefab or mesh reference alone mounts the DLC scene folders or their dependent resources.
- Birthday passive skills need the inventory prefab/passive userdata chain plus REFramework runtime handling; `skl###no` entries are locked/dummy Birthday variants and should not be injected as usable main-game skills.

## Artifacts, Secrets, And Repo Hygiene

- Do not commit local build outputs, logs, `TestResults/`, `out/`, `dumps/`, `bin/`, `obj/`, `.vs/`, or `GeneratedFiles/` unless the task specifically calls for a generated artifact.
- Treat game extracts and DLC assets as sensitive. Do not add new extracted vanilla assets or large binaries without explicit intent.
- Do not commit `%USERPROFILE%\.biorand\local.json`, auth tokens, local install paths, or machine-specific `.csproj.user` / `.DotSettings.user` files.
- `src/Biohazard.BioRand.RE7/_Data/**/*` is embedded into the core assembly. Any changes there are runtime changes, not just fixtures.

## Local Search Notes

Prefer `rg` when available. If `rg` fails with access denied in this workspace, use PowerShell fallbacks such as:

```powershell
Get-ChildItem -Recurse -File | Select-String -Pattern "needle"
Get-ChildItem -Recurse -File -Include *.cs,*.md,*.json
```
