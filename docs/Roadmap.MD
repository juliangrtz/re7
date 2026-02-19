
# RE7 Randomizer roadmap for 2026 and general thoughts

All estimates provided are non-binding and subject to change. Features will likely be implemented in descending order.

## 1. Recipe randomization

* Only potential softlock: `SerumMaterialA + 1x SerumMaterialB -> 1x DybbukMedicine`
* Strange recipe: `1x Flower + 1x ChemicalS -> 1x EyeDrops`, ID "Flower" does not exist!
* Always enabled:
  * Anti-softlock
  * New recipes in crafting menu
* Starting recipe randomization
* Probabilities for most wanted recipes
* Option to disable nonsensical recipes entirely
* Pre-defined additional recipes like in RE4RR:
  * Chem Fluid + Chem Fluid => Strong Chem Fluid
  * Strong Chem Fluid + Separating agent => 3x Chem Fluid
  * Separating Agent + Ammo => Gunpowder
  * etc.

**Estimated completion: February**

## 2. Item randomization

* Options can pretty much be copied from RE4R except for money and treasures
* Need to be especially aware of early game softlocks!
  * Bolt cutters
  * Axe for Mia 1
  * Knife from Deputy
  * etc.
* Particular focus on key items!
* Box drops sometimes don't work
  * Testing required
  * Appears to often fail for weapons
* Not all item IDs can just be replaced with others, certain items won't spawn
* Inventory
  * Random starting inventory
  * Backpack randomization
  * Stack Limits (-> RE4R)

**Estimated completion: March**

------- This is probably a good time to allow alpha testing -------

## 3. Enemy randomization

* Change via.Transform properties => Location, Rotation, Scale
* Health can be modified easily
* Speed too; but some enemies have their own values in special ActionControllers!
* Goal: *Enhance enemy variety, especially the Molded*
* Enemy Spawn Controllers are tricky
  * Can't just copy enemies from .scn file A to .scn file B
  * Bosses are particulary finicky
* Certain bosses might not be spawnable in random locations:
  * Jack 3 requires fixed boat house waypoints, must be investigated
  * Same for the Evie final boss fight
* Introduce item drops (can be copied from Marge)
* Be particularly careful with roaming enemies (non-mutated Jack and Marge)
* Roaming Jack can't die => Careful with elevators, they won't move!
* Must be tested *very* carefully

**Estimated completion: May**


## 4. Quality of Life

* Bugfixes
* Softlock prevention
* Code refactoring

**Estimated completion: June**

------- This is probably a good time to allow beta testing -------

## 5. 100 % DLC content in main game

 * Goal: *Full item and enemy integration*
 * Challenging, can't just bring the assets over
 * Banned Footage content is easier to mod in than End of Zoe and Not a Hero
 * In-depth reverse engineering required
 * In the worst case binary patching might be necessary!
 * Ethan Must Die crate quality concept in main game

**Estimated completion: August**

## 6. Chapter shuffling

 * Certain triggers might break
 * Possibly certain chapter order subsets must be preserved
 * Testing required
 * Have to manipulate flags (userdata/globalvariables.uvar.2)

 **Estimated completion: September**

 ## 7. Additional features
 * Remains to be seen

<br>

**Estimated initial public access: October**
