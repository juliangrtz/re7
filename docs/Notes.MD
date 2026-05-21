# Technical Notes

I've gathered this information while working on the randomizer.

## Important directories (main game -> re_chunk_000.pak)

- (key) item locations: re_chunk_000/natives/stm/leveldesign/itemset

- prefabs: re_chunk_000/natives/stm/prefab/item

- item combine data
  - re_chunk_000/natives/stm/prefab/item/dictionarycombinedata.user.2
  - re_chunk_000/natives/stm/prefab/item/itemcombinedata.user.2

- key item prefabs
  - re_chunk_000/natives/stm/prefab/item/keyitemsettings.user.2

- message text and markup
  - re_chunk_000/natives/stm/message/*.msg.17
  - See `docs/items/MessageMarkup.MD` for RE7 message tags such as `<COLOR RRGGBB>`, `<SIZE n>`, `<ICON NAME>`, `<PAGE>`, `<TIME ...>`, and engine-supported but unobserved tag types.

## DLC PAK file table

The .pak files are found in the `dlc` directory.

| **PAK file**        | **DLC**                 | **Comment**                                  | **URL**                                                                 |
|---------------------|-------------------------|----------------------------------------------|-------------------------------------------------------------------------|
| re_dlc_stm_529930   | Banned Footage Vol. 1   | Nightmare, Bedroom, Ethan Must Die           | https://store.steampowered.com/app/529930/Banned_Footage_Vol1/         |
| re_dlc_stm_530610   | Banned Footage Vol. 2   | 21, Daughters, Jack's 55th Birthday          | https://store.steampowered.com/app/530610/Banned_Footage_Vol2/         |
| re_dlc_stm_530611   | End of Zoe              |                                              | https://store.steampowered.com/app/530611/End_of_Zoe/                  |
| re_dlc_stm_564190   | Not a Hero              |                                              | https://store.steampowered.com/app/564190/Not_A_Hero/                  |
| re_dlc_stm_530595   | Defense Coin            |                                              | https://store.steampowered.com/app/530595/Defense_Coin__Madhouse_Mode_Unlock/ |
| re_dlc_stm_530596   | Attack Coin             |                                              | https://store.steampowered.com/app/530596/Attack_Coin__Madhouse_Mode_Unlock/  |
| re_dlc_stm_530597   | Instinct Coin           |                                              | https://store.steampowered.com/app/530597/Instinct_Coin__Madhouse_Mode_Unlock/ |
| re_dlc_stm_530598   | Reload Coin             |                                              | https://store.steampowered.com/app/530598/Reload_Coin__Madhouse_Mode_Unlock/   |
| re_dlc_stm_530599   | Universal Coin          |                                              | https://store.steampowered.com/app/530599/Universal_Coin__Madhouse_Mode_Unlock/|

## Internal DLC IDs

`
(chapter|c)0?7_1 => Bedroom
((chapter|c)0?7_2)|cardgame|survival => 21
(chapter|c)0?7_3 => Nightmare
(chapter|c)0?7_4 => Daughters
(chapter|c|ch)0?8 => NotAHero
(chapter|c|ch)0?9 => EndOfZoe
birthday => Jacks55thBirthday
/(e|i)md => EthanMustDie
(dlcitem|coin)_01 => DefenseCoinAndMadhouseUnlock
(dlcitem|coin)_02 => AttackCoinAndMadhouseUnlock
(dlcitem|coin)_03 => InstinctCoinAndMadhouseUnlock
(dlcitem|coin)_04 => ReloadCoinAndMadhouseUnlock
(dlcitem|coin)_05 => UniversalCoinAndMadhouseUnlock
`

## DLC integration notes

General lessons:

- The C# TDB in `.analysis/re7_src` is the fastest source for class names, inheritance, fields, and enums. Use IDA for xrefs, decompilation, strings, and runtime control flow after narrowing the target.
- `CH8` is Not a Hero and `CH9` is End of Zoe. Jack's 55th Birthday logic uses `Birthday*` and `FsmBirthday*` classes, not CH8 classes.
- Bringing a DLC object into the main game usually requires the full runtime component chain and asset load chain. A prefab, mesh, or enum ID alone is rarely enough.
- `natives/stm/scenes/master.scn.20` and `natives/stm/scenes/dlc/dlc_active_root.scn.20` are important DLC scene roots. Standby/default-standby state on the DLC folder chain can decide whether referenced DLC scenes and assets are actually mounted.
- If a DLC asset still does not appear after scene data looks correct, compare what the DLC mode loads from the main menu rather than only inspecting the final object prefab.
- Live REFramework MCP is configured through `C:\Users\Julian\.codex\config.toml` and runs `F:\RE_Modding\re-engine-mcp-master\mcp-server` against `http://localhost:8899`.
- Confirmed live MCP probes on 2026-05-06: `reframework_get_tdb` returned 78687 types, 507723 methods, 147762 fields, and 103892 properties; `reframework_get_camera` returned FOV 81, near clip 0.05, far clip 1000; `reframework_get_singletons` exposed relevant managers including `app.DLCContentManager`, `app.DLCContentSceneManager`, `app.EnemyGeneratorManager`, `app.InventoryManager`, `app.ItemManager`, `app.ItemResourceManager`, `app.ObjectManager`, `via.ResourceManager`, and `via.SceneManager`.
- `reframework_get_inventory` is a thin MCP wrapper over `GET /api/inventory` and still returned a generic invocation error after retrying in a loaded gameplay state. Treat that endpoint as needing WebAPI/plugin investigation before using it for RE7 inventory research.

Birthday skills:

- Skills are defined under `natives/stm/prefab/item/birthdayskillitemsetting.user.2` and use IDs `skl001` through `skl023`.
- The `skl###no` entries are locked/dummy Birthday variants and should not be injected as usable main-game skills.
- Direct placement of `Prefab/Skill/skl001/Skl001PassiveSkill.user` into Ethan's `app.PlayerPassiveSkillManager.PlayerPassiveSkill` worked and granted infinite ammo, proving the main-game player manager can consume Birthday passive userdata.
- For inventory support, the important chain is the original skill inventory prefab `Prefab/Skill/skl###/Skl###.pfb`, its `app.PassiveSkillItem`, the referenced `PlayerPassiveSkill.user`, messages copied into `ui_item_mes.msg.17`, and REFramework handling to avoid the native Birthday-only inventory callback freeze.
- Birthday skills do not have normal world pickup meshes. Static/random placements should use a known-good pickup shell and override `app.Item.ItemDataID` to the chosen `skl###`.

Not a Hero and End of Zoe enemies:

- DLC enemies need imported enemy templates and spawn-info templates in `template.scn.20`; missing templates should be skipped rather than emitted partially.
- Not a Hero generator replacements require `app.CH8EnemyGenerator`, `app.CH8EnemyPool`, `app.CH8EnemySpawnInfo`, and the concrete `app.CH8EnemySpawnInfoOptionEm####`.
- End of Zoe generator replacements use `app.CH9EnemySpawnInfo` and `app.CH9EnemySpawnInfoOptionEm####`; no `CH9EnemyGenerator`/`CH9EnemyPool` types were found in the current TDB.
- `app.EnemySpawnInfoOptionDLC` exists, but real DLC spawn-info objects do not universally include or require it.
- Template import must match concrete `UnitAlias` and prefab alias, not just option class suffix. Some CH8 aliases reuse base stacks.
- `Em4210` = Fat Headless Molded. It uses `UnitAlias = Em4210`, but the runtime stack is `app.CH8Em4200*` plus `app.CH8EnemySpawnInfoOptionEm4200`.
- `Em4400` = Mama Mold.
- `Em4450` = Little Crawler.
- `Em4460` = Mama Mold. A wrapper object with nested `Em4450` exists, but `main300generator.scn.20` also has a normal generator-style `UnitAlias = Em4460` source.
- `Em4500` = Mutated Lucas. This is the Not a Hero final boss and should stay opt-in/special-case until runtime-proven.
- `Em4600` = Fumer. It uses `UnitAlias = Em4600`, but the runtime stack is `app.CH8Em4000*` plus `app.CH8EnemySpawnInfoOptionEm4000`.

## Recipes

- `prefab/item/dictionarycombinedata.user.2`
  - Defines what recipes are shown in the combine menu
  - Only contains ItemDataID keys for a `Dictionary` that is evaluated at runtime
  - All entries MUST be valid item IDs (see enum `app.ItemID`)! Otherwise the game does not load (infinite loop). Own IDs are not allowed.
  - Must reference DataIDs from recipes in `prefab/item/itemcombinedata.user.2`
  - If there are more than 8 entries the additional ones won't be accessible in the combine menu, only the icons can be seen but the cursor can't be moved to them. Modding it via REFramework is possible but not ideal
  - Duplicate entries lead to weird GUI behaviour

- `prefab/item/itemcombinedata.user.2`
  - DataID is referenced by the dictionary above
  - source item IDs and result item ID must be valid
  - the combine GUI has very strict validations, random combinations do _not_ appear!
  - items _can_ be combined with themselves
  - EnableFlag refers to a flag which allows the item to be crafted. E.g. the flag `eab670f7-4475-4258-b900-cbe91664c9a3` which is `cmb_enable_DybbukMedicine` activates the ability to craft the serum
  - IsTrophyTarget: Likely refers to the achievement "1st Place at the Science Fair" where you must create all items that contain Chem Fluid and Strong Chem Fluid
  - IsTutorialTarget: ?

Original recipes:

```text
  Original crafting recipes
      1x Burner Grip                    +   1x Burner Nozzle                  ⇒   1x Burner                        
      1x Herb                           +   1x Chem Fluid                     ⇒   1x First Aid Med                 
      1x Herb                           +   1x Strong Chem Fluid              ⇒   1x Strong First Aid Med          
      1x Supplements                    +   1x Chem Fluid                     ⇒   1x Psychostimulants              
      1x Solid Fuel                     +   1x Strong Chem Fluid              ⇒   2x Flame Rounds                  
      1x Supplements                    +   1x Strong Chem Fluid              ⇒   2x Neuro Rounds                  
      1x Solid Fuel                     +   1x Chem Fluid                     ⇒ 100x Burner Fuel                   
      1x First Aid Med                  +   1x Separating Agent               ⇒   1x Chem Fluid                    
      1x Psychostimulants               +   1x Separating Agent               ⇒   1x Chem Fluid                    
    100x Burner Fuel                    +   1x Separating Agent               ⇒   1x Chem Fluid                    
      1x Strong First Aid Med           +   1x Separating Agent               ⇒   1x Strong Chem Fluid             
      1x Flame Rounds                   +   1x Separating Agent               ⇒   1x Strong Chem Fluid             
      1x Neuro Rounds                   +   1x Separating Agent               ⇒   1x Strong Chem Fluid             
      1x Gunpowder                      +   1x Strong Chem Fluid              ⇒  10x Enhanced Handgun Ammo                                             
      1x Repair Kit                     +   1x Broken Handgun                 ⇒   1x M19 Handgun                   
      1x Repair Kit                     +   1x Broken Shotgun                 ⇒   1x M21 Shotgun                   
      1x Gunpowder                      +   1x Chem Fluid                     ⇒  10x Handgun Ammo                  
     10x Handgun Ammo                   +   1x Separating Agent               ⇒   1x Chem Fluid                    
     10x Enhanced Handgun Ammo          +   1x Separating Agent               ⇒   1x Strong Chem Fluid             
     10x Handgun Ammo                   +   1x Gunpowder                      ⇒   5x Enhanced Handgun Ammo    
```

Recipes in the combine GUI:

```text
      1x Herb                                               [Drug]     +   1x Chem Fluid                                         [Material] ⇒   1x First Aid Med                                      [Drug]
      1x Gunpowder                                          [Material] +   1x Chem Fluid                                         [Material] ⇒  10x Handgun Ammo                                       [Shell]
      1x Solid Fuel                                         [Material] +   1x Chem Fluid                                         [Material] ⇒ 100x Burner Fuel                                        [Shell]
      1x Supplements                                        [Material] +   1x Chem Fluid                                         [Material] ⇒   1x Psychostimulants                                   [Drug]
      1x Herb                                               [Drug]     +   1x Strong Chem Fluid                                  [Material] ⇒   1x Strong First Aid Med                               [Drug]
      1x Gunpowder                                          [Material] +   1x Strong Chem Fluid                                  [Material] ⇒  10x Enhanced Handgun Ammo                              [Shell]
      1x Solid Fuel                                         [Material] +   1x Strong Chem Fluid                                  [Material] ⇒   2x Flame Rounds                                       [Shell]
      1x Supplements                                        [Material] +   1x Strong Chem Fluid                                  [Material] ⇒   2x Neuro Rounds                                       [Shell]

```

Ideas for new recipes:

```cs
        // Ammo -> Ammo
        CreateRecipe("HandgunBulletL", 20, "ChemicalL", 1, "MagnumBullet", 10), // Enhanced Handgun Ammo + Strong Chem Fluid => 44 MAG Ammo
        CreateRecipe("ShotgunBullet", 10, "ChemicalM", 1, "MagnumBullet", 5), // Shotgun Shell + Strong Chem Fluid => 44 MAG Ammo
        CreateRecipe("HandgunBulletL", 10, "MagnumBullet", 5, "ShotgunBullet", 20), // Enhanced Handgun Ammo + 44 MAG Ammo => Shotgun Shells
        CreateRecipe("BurnerBullet", 100, "HandgunBulletL", 10, "FlameBulletS", 5), // Burner Fuel + Enhanced Handgun Ammo => Flame Rounds
        CreateRecipe("HandgunBulletL", 10, "ChemicalS", 1, "AcidBulletS", 5), // Enhanced Handgun Ammo + Strong Chem Fluid => Neuro Rounds

        // Heal -> Heal
        CreateRecipe("RemedyM", 1, "RemedyM", 1, "RemedyL", 1), // First Aid Med + First Aid Med => Strong First Aid Med
        CreateRecipe("RemedyM", 1, "Herb", 1, "RemedyL", 1), // First Aid Med + Herb => Strong First Aid Med
        CreateRecipe("RemedyL", 1, "RemedyL", 1, "Stimulant", 1), // Strong First Aid Med + Strong First Aid Med => Steroids
        CreateRecipe("RemedyM", 1, "EyeDrops", 1, "Depressant", 1), // First Aid Med + Psychostimulants => Stabilizer
        CreateRecipe("EyeDrops", 1, "Herb", 1, "Depressant", 1), // Psychostimulants + Herb => Stabilizer
```

## Inventory

Ethan starting inventory: natives/stm/leveldesign/fsm/chapter1/other -> tested successfully with chainsaw

Mia starting inventory (VHS): natives/stm/leveldesign/fsm/chapter4/chapter4_1/other/4-1startinventory.user.2

Mia starting inventory (w/ machine gun): natives/stm/leveldesign/fsm/ff050/other/ff050_startinventory.user.2

Clancy VHS starting inventory natives/stm/leveldesign/fsm/ff000/other/startinventory_ff000.user.2

---------

Files where inventory size is changed:

- levelfsm_c07_3_normalmode.scn.20
- levelfsm_c07_3_survivalmode.scn.20
- stage1_seta.scn.20
- stage1_setb.scn.20
- stage2_seta.scn.20
- stage2_setb.scn.20
- stage3_seta.scn.20
- stage3_setb.scn.20
- ship1f.scn.20
- shipoutside.scn.20
- mainhouse_east.scn.20
- oldhouse.scn.20
- levelfsm_ff000.scn.20
- level_fsm_ff050.scn.20
- levelfsm_c07_2_storymode.scn.20
- levelfsm_c04_1.scn.20
- levelfsm_c04_2.scn.20
- mainflow_gimmick.scn.20
- levelfsm_c09_4.scn.20
- ch8_game.scn.20

## Enemies

### IDs

- em2000: Mia
- em3000: Jack
- em3001: Jack (Nightmare DLC)
- em3002: Jack (Daughters DLC)
- em3100: Marguerite
- em3101: Marguerite (Bedroom DLC)
- em3600: Marguerite Fight Boss
- em4000: Molded
- em4100: 4-Legged Molded
- em4200: Fat Molded
- em5400: Insects
- em5500: Darker Insects
- em55[10..40]: Insects
- em6400: end of zoe jack
- em8000: Jack Saw Fight
- em8001: Jack with Shears (Nightmare DLC)
- em8100: Jack Eyes Boss
- em8900: Evie Final Form

### IMPORTANT WHEN RANDOMIZING

- in the FSM, the UIDs are **not** arbitrary. they are actually state IDs hard-coded in .fsm.16 files!
- therefore, only assign valid UIDs in biorand
- wandering enemies must be edited by removing the MapName in via.navigation.NavigationSurface

### General notes

- Initial Jack (Em3000) encounter: natives/stm/leveldesign/fsm/chapter1/amaro.scn.20
- Molded Group outside of Swamp Hut: natives/stm/scenes/chapter/chapter4/chapter4_2/moldeads.scn.20

## Player Stats

- HP: natives/stm/prefab/character/pl0000/pl0000maxhealthtable.user.2

## Misc

- Eye drop params (max time and range): natives/stm/prefab/system/systemparameterdata.user
- Lucas puzzle door FSM: leveldesign/fsm/chapter3/chapter3_4/levelfsm_c03_4.scn.20
