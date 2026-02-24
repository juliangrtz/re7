# Technical Notes

I've gathered this information while working on the randomizer.

## Important directories (main game -> re_chunk_000.pak)

- (key) item locations: re_chunk_000\natives\stm\leveldesign\itemset

- prefabs: re_chunk_000\natives\stm\prefab\item

- item combine data
  - re_chunk_000\natives\stm\prefab\item\dictionarycombinedata.user.2
  - re_chunk_000\natives\stm\prefab\item\itemcombinedata.user.2

- key item prefabs
  - re_chunk_000\natives\stm\prefab\item\keyitemsettings.user.2

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

## Starting inventory

Ethan starting inventory: natives\stm\leveldesign\fsm\chapter1\other -> tested successfully with chainsaw

Mia starting inventory (VHS): natives\stm\leveldesign\fsm\chapter4\chapter4_1\other\4-1startinventory.user.2

Mia starting inventory (w/ machine gun): natives\stm\leveldesign\fsm\ff050\other\ff050_startinventory.user.2

Clancy VHS starting inventory? natives\stm\leveldesign\fsm\ff000\other\startinventory_ff000.user.2
