local version = "1.2"

if reframework:get_game_name() ~= "re7" then --or sdk.get_tdb_version() ~= 70 then
	re.msg("[Item Unlocker] Only compatible with RE7!")
	return
end

local item_friendly_names = {
	-- Weapons - Melee
	["Bar"] = "Crowbar",
	["ChainSaw"] = "Chain Saw",
	["CircularSaw"] = "Circular Saw",
	["HandAxe"] = "Axe",
	["Knife"] = "Knife",
	["MiaKnife"] = "Survival Knife",

	-- Weapons - Firearms
	["Burner"] = "Flamethrower",
	["GrenadeLauncher"] = "Grenade Launcher",
	["Handgun_Albert"] = "Albert-01",
	["Handgun_Albert_Reward"] = "Albert-01 R",
	["Handgun_G17"] = "G17 Handgun",
	["Handgun_M19"] = "M19 Handgun",
	["Handgun_MPM"] = "MPM Handgun",
	["MachineGun"] = "P19 Machine Gun",
	["Magnum"] = "44 MAG",
	["Shotgun_DB"] = "M21 Shotgun",
	["Shotgun_M37"] = "M37 Shotgun",
	["BlueBlaster"] = "BlueBlaster",
	["HyperBlaster"] = "HyperBlaster",
	["RedBlaster"] = "RedBlaster",

	-- Weapons - Thrown
	["LiquidBomb"] = "Remote Bomb",

	-- Ammo
	["UnlimitedAmmo"] = "Infinite Ammo",
	["AcidBulletS"] = "Neuro Rounds",
	["BurnerBullet"] = "Burner Fuel",
	["FlameBulletS"] = "Flame Rounds",
	["HandgunBullet"] = "Handgun Ammo",
	["HandgunBulletL"] = "Enhanced Handgun Ammo",
	["MachineGunBullet"] = "Machine Gun Ammo",
	["MagnumBullet"] = "44 Mag Ammo",
	["ShotgunBullet"] = "Shotgun Ammo",

	-- Medicine
	["EyeDrops"] = "Psychostimulants",
	["Herb"] = "Herb",
	["RemedyL"] = "Strong First Aid Med",
	["RemedyM"] = "First Aid Med",

	-- Player Upgrades
	["AlphaGrass"] = "X-ray Glasses",
	["BookDefence01"] = "The Secrets Of Defense",
	["BookDefence02"] = "The Essence Of Defense",
	["Depressant"] = "Stabilizer - Faster Reload",
	["Stimulant"] = "Steroids - Increase Max Health",
	["EasyBoots"] = "Walking Shoes",

	-- Coins
	["Coin"] = "Antique Coin",
	["GoodLuckCoinA"] = "Defense Coin",
	["GoodLuckCoinB"] = "Attack Coin",
	["GoodLuckCoinC"] = "Instinct Coin",
	["GoodLuckCoinD"] = "GoodLuckCoinD",
	["GoodLuckCoinE"] = "GoodLuckCoinE",
	["PowerUpCoin01A"] = "Assault Coin",
	["PowerUpCoin01B"] = "Iron Defense Coin",

	-- Crafting
	["Alcohol"] = "Solid Fuel",
	["AlloyClay"] = "Chilled Chem Fluid",
	["ChemicalL"] = "Separating Agent",
	["ChemicalM"] = "Strong Chem Fluid",
	["ChemicalS"] = "Chem Fluid",
	["Flower"] = "Supplements",
	["Gunpowder"] = "Gun Powder",
	["Magnesium"] = "Weak Acid",
	["RepairKit"] = "Gun Repair Kit",

	-- Documents/Books
	["MailMia"] = "Email from Mia",
	["MiaDriversLicense"] = "Mia Driving License",
	["ProposalBookFf"] = "Project Proposal",

	-- Keys
	["3CrestKeyA"] = "Blue Dogs Head",
	["3CrestKeyB"] = "White Dogs Head",
	["3CrestKeyC"] = "Red Dogs Head",
	["CabinKey"] = "Captain's Cabin Locker Key",
	["CylinderKey"] = "Lock Pick",
	["EntranceHallKey"] = "Ox Statuette",
	["EthanCarKey"] = "Car Key",
	["FloorDoorKey"] = "Hatch Key",
	["LucasCardKey"] = "Keycard - Blue",
	["LucasCardKey2"] = "Keycard - Red",
	["MasterKey"] = "Snake Key",
	["MorgueKey"] = "Scorpion Key",
	["SpareKey"] = "Corrosive",
	["TalismanKey"] = "Crow Key",
	["WorkroomKey"] = "Dissection Room Key",

	-- Maps
	["TreasureMap01"] = "Treasure Photo - Morgue",
	["TreasureMap02"] = "Treasure Photo - Old House",
	["TreasureMap03"] = "Treasure Photo - Master Bedroom",

	-- Mission Items
	["Battery"] = "Battery",
	["BrokenHandgun_M19"] = "Broken Handgun",
	["BrokenShotgun_DB"] = "Broken Shotgun",
	["BurnerPartsA"] = "Burner Grip",
	["BurnerPartsB"] = "Burner Nozzle",
	["ChainCutter"] = "Bolt Cutters",
	["Crank"] = "Crank",
	["DummyAxe"] = "Toy Axe",
	["EvCable"] = "Power Cable",
	["EvelynRadar1"] = "Eveline Strange Bottle",
	["EvelynRadar2"] = "Eveline Tissue Samples (1)",
	["EvelynRadar3"] = "Eveline Tissue Samples (2)",
	["EvelynRadar4"] = "Eveline Tissue Samples (3)",
	["EvOpener"] = "Lug Wrench",
	["Fuse"] = "Fuse",
	["FuseCh4"] = "General Purpose Fuse",
	["Lantern"] = "Lantern",
	["PendulumClock"] = "Clock Pendulum",
	["SerumComplete"] = "Serum Complete",
	["SerumMaterialA"] = "D-Series Arm",
	["SerumMaterialB"] = "D-Series Head",
	["SerumTypeE"] = "E-Necrotoxin",
	["SilhouettePazzlePiece"] = "Wooden Statuette",
	["SilhouettePazzlePieceOldHouse"] = "Stone Statuette",
	["Timebomb"] = "Time Bomb",
	["ToyShotgun"] = "Model Shotgun",

	-- Body Parts
	["EthanLeg"] = "Ethan's Leg",
	["HandCutOff"] = "Ethan's Hand",

	-- Mission Items (Happy Birthday)
	["Balloonbomb"] = "Balloon",
	["Candle"] = "Candle",
	["Glasses"] = "Dirty Telescope",
	["ScrewFinger"] = "Dummy Finger",
	["Quill"] = "Quill Pen",
	["Valve"] = "Valve Handle",
	["SpringCoil"] = "Winding Key",

	-- Other
	["SaveTape"] = "Cassette Tape (Save)",
	["SupplyBoxA"] = "Box A (2xHerb, RemedyM, RemedyL)",
	["SupplyBoxOpenedA"] = "Box A (Opened)",
	["SupplyBoxB"] = "Box B (Gunpowder, 10xHandgunBullet, 3xHandgunBulletL)",
	["SupplyBoxOpenedB"] = "Box B (Opened)",
	["SupplyBoxC"] = "Box C (RemedyM, 7xShotgunBullet)",
	["SupplyBoxOpenedC"] = "Box C (Opened)",

	-- DLC
	["CH9_WP000"] = "WP001",
	["CH9_WP001"] = "WP002",
	["CH9_WP002"] = "WP003",
	["CH9_WP003"] = "WP004",
	["CH9_WP004"] = "WP005",
	["CH9_WP005"] = "WP006",
	["CH9_WP006"] = "WP007",
	["CH9_WP007"] = "WP008",
	["CH9_WP008"] = "WP009",

	-- Videotapes
	["FoundFootage000"] = "Derelict House Footage (1)",
	["FoundFootage010"] = "FoundFootage010",
	["FoundFootage020"] = "Derelict House Footage (2)",
	["FoundFootage030"] = "Mia",
	["FoundFootage040"] = "Happy Birthday",
	["FoundFootage050"] = "Old Videotape",
}

-- region Settings
local default_settings = {
	jackSoftlockFix = false,
	requiredHitsJack2 = 10,
	itemQuantity = 100,
	items = {
		["CH9_WP000"] = false,
		["CH9_WP001"] = false,
		["CH9_WP002"] = false,
		["CH9_WP003"] = false,
		["CH9_WP004"] = false,
		["CH9_WP005"] = false,
		["CH9_WP006"] = false,
		["CH9_WP007"] = false,
		["CH9_WP008"] = false,
		["Bar"] = false,
		["ChainSaw"] = false,
		["CircularSaw"] = false,
		["HandAxe"] = false,
		["Knife"] = false,
		["MiaKnife"] = false,
		["Burner"] = false,
		["GrenadeLauncher"] = false,
		["Handgun_Albert"] = false,
		["Handgun_Albert_Reward"] = false,
		["Handgun_G17"] = false,
		["Handgun_M19"] = false,
		["Handgun_MPM"] = false,
		["MachineGun"] = false,
		["Magnum"] = false,
		["Shotgun_DB"] = false,
		["Shotgun_M37"] = false,
		["BlueBlaster"] = false,
		["HyperBlaster"] = false,
		["RedBlaster"] = false,
		["LiquidBomb"] = false,
		["UnlimitedAmmo"] = false,
		["AcidBulletS"] = false,
		["BurnerBullet"] = false,
		["FlameBulletS"] = false,
		["HandgunBullet"] = false,
		["HandgunBulletL"] = false,
		["MachineGunBullet"] = false,
		["MagnumBullet"] = false,
		["ShotgunBullet"] = false,
		["EyeDrops"] = false,
		["Herb"] = false,
		["RemedyL"] = false,
		["RemedyM"] = false,
		["AlphaGrass"] = false,
		["BookDefence01"] = false,
		["BookDefence02"] = false,
		["Depressant"] = false,
		["Stimulant"] = false,
		["EasyBoots"] = false,
		["Coin"] = false,
		["GoodLuckCoinA"] = false,
		["GoodLuckCoinB"] = false,
		["GoodLuckCoinC"] = false,
		["GoodLuckCoinD"] = false,
		["GoodLuckCoinE"] = false,
		["PowerUpCoin01A"] = false,
		["PowerUpCoin01B"] = false,
		["Alcohol"] = false,
		["AlloyClay"] = false,
		["ChemicalL"] = false,
		["ChemicalM"] = false,
		["ChemicalS"] = false,
		["Flower"] = false,
		["Gunpowder"] = false,
		["Magnesium"] = false,
		["RepairKit"] = false,
		["MailMia"] = false,
		["MiaDriversLicense"] = false,
		["ProposalBookFf"] = false,
		["3CrestKeyA"] = false,
		["3CrestKeyB"] = false,
		["3CrestKeyC"] = false,
		["CabinKey"] = false,
		["CylinderKey"] = false,
		["EntranceHallKey"] = false,
		["EthanCarKey"] = false,
		["FloorDoorKey"] = false,
		["LucasCardKey"] = false,
		["LucasCardKey2"] = false,
		["MasterKey"] = false,
		["MorgueKey"] = false,
		["SpareKey"] = false,
		["TalismanKey"] = false,
		["WorkroomKey"] = false,
		["TreasureMap01"] = false,
		["TreasureMap02"] = false,
		["TreasureMap03"] = false,
		["Battery"] = false,
		["BrokenHandgun_M19"] = false,
		["BrokenShotgun_DB"] = false,
		["BurnerPartsA"] = false,
		["BurnerPartsB"] = false,
		["ChainCutter"] = false,
		["Crank"] = false,
		["DummyAxe"] = false,
		["EvCable"] = false,
		["EvelynRadar1"] = false,
		["EvelynRadar2"] = false,
		["EvelynRadar3"] = false,
		["EvelynRadar4"] = false,
		["EvOpener"] = false,
		["Fuse"] = false,
		["FuseCh4"] = false,
		["Lantern"] = false,
		["PendulumClock"] = false,
		["SerumComplete"] = false,
		["SerumMaterialA"] = false,
		["SerumMaterialB"] = false,
		["SerumTypeE"] = false,
		["SilhouettePazzlePiece"] = false,
		["SilhouettePazzlePieceOldHouse"] = false,
		["Timebomb"] = false,
		["ToyShotgun"] = false,
		["EthanLeg"] = false,
		["HandCutOff"] = false,
		["Balloonbomb"] = false,
		["Candle"] = false,
		["Glasses"] = false,
		["ScrewFinger"] = false,
		["Quill"] = false,
		["Valve"] = false,
		["SpringCoil"] = false,
		["SaveTape"] = false,
		["SupplyBoxA"] = false,
		["SupplyBoxOpenedA"] = false,
		["SupplyBoxB"] = false,
		["SupplyBoxOpenedB"] = false,
		["SupplyBoxC"] = false,
		["SupplyBoxOpenedC"] = false,
		["FoundFootage000"] = false,
		["FoundFootage010"] = false,
		["FoundFootage020"] = false,
		["FoundFootage030"] = false,
		["FoundFootage040"] = false,
		["FoundFootage050"] = false
	}
}

local settingsFile = "ItemUnlocker.json"
local settings = json.load_file(settingsFile) or {}

for k, v in pairs(default_settings) do
	if settings[k] == nil then
		settings[k] = v
	end
end
--endregion

local function getLocalPlayer()
	local object_man = sdk.get_managed_singleton("app.ObjectManager")

	if not object_man then
		return nil
	end

	return object_man:get_field("PlayerObj")
end

local known_typeofs = {}
local function getComponent(game_object, type_name)
	local t = known_typeofs[type_name] or sdk.typeof(type_name)

	if t == nil then
		return nil
	end

	known_typeofs[type_name] = t
	return game_object:call("getComponent(System.Type)", t)
end

-- region Jack 2 softlock fix
-- Without this – admittedly wacky – fix, it is not possible to expose Jack's weak spot with certain weapons
-- during the fight in the basement when getting the red dog head.
-- If you figure out a better solution that is closer to Jack's original behavior feel free to contact me!

local em8010Core = nil -- Em8010 is Jack's mutated head (weak spot)
sdk.hook(sdk.find_type_definition("app.Em8010.Em8010Core"):get_method("doStart"),
	function(args) em8010Core = sdk.to_managed_object(args[2]) end,
	function(retval) return retval end
)

local jackHits = 0
sdk.hook(
	sdk.find_type_definition("app.Em8010.Em8010Core"):get_method("calcDamage"),
	function(_)
		if not settings.jackSoftlockFix or not em8010Core then return end

		jackHits = jackHits + 1
		if jackHits > 0 and jackHits % settings.requiredHitsJack2 == 0 then
			-- app::Em8010::Em8010Core
			em8010Core:tryOrder(1) -- Open
		end
	end,
	function(retval) return retval end
)

-- endregion

local function getItemBoxData()
	local inventory = getComponent(getLocalPlayer(), "app.Inventory")
	if not inventory then return end
	return inventory:get_field("<ItemBoxData>k__BackingField")
end

local function addItemsToItemBox()
	for itemId, enabled in pairs(settings.items) do
		if enabled then
			local quantity = tonumber(settings.itemQuantity)
			local signature = "addItem(System.String, System.Int32, app.WeaponGun.WeaponGunSaveData)"
			local itemBoxData = getItemBoxData()
			if not itemBoxData then return end
			local success = itemBoxData:call(signature, itemId, quantity, nil)
			log.debug(tostring(success))
		end
	end
end

local function clearInventory()
	local inventory = getComponent(getLocalPlayer(), "app.Inventory")
	if not inventory then return end
	inventory:RemoveListAll()
end

local inventoryMenu
sdk.hook(sdk.find_type_definition("app.InventoryMenu"):get_method("onOpen"), function(args)
	inventoryMenu = sdk.to_managed_object(args[2])
end, function(retval) return retval end)

local function addItemsToInventory()
	for itemId, enabled in pairs(settings.items) do
		if enabled then
			local inventory = getComponent(getLocalPlayer(), "app.Inventory")
			if not inventory then return end
			local emptySlots = inventory:getEmptySlotNum()
			if (emptySlots - 4) <= 0 then return end -- Quick slots don't count :/

			local signature = "addItem(System.String, System.Int32, app.WeaponGun.WeaponGunSaveData)"
			local itemBoxData = getItemBoxData()
			if not itemBoxData then return end

			local quantity = tonumber(settings.itemQuantity)
			itemBoxData:call(signature, itemId, quantity, nil)
			local itemParam = itemBoxData:findItem(itemId)

			if not inventoryMenu then return end
			inventoryMenu:moveItemBoxToInventory(itemParam, quantity)
		end
	end
end

local function clearItemBox()
	local itemBoxData = getItemBoxData()
	if not itemBoxData then return end
	itemBoxData:clearItems()
end

local function setExtendLv(lv)
	local inventory = getComponent(getLocalPlayer(), "app.Inventory")
	if not inventory then return end
	inventory:setExtendLv(lv)
end



local function render_checkbox(item_id)
	local label = item_friendly_names[item_id] or item_id
	local changed, new_val = imgui.checkbox(label, settings.items[item_id])
	if changed then
		settings.items[item_id] = new_val
		json.dump_file(settingsFile, settings)
	end
end

local changedSoftlock
local changedHits
re.on_draw_ui(function()
	if imgui.tree_node("Item Unlocker") then
		imgui.text("Version " .. version)
		imgui.spacing()

		if imgui.tree_node("Item box") then
			if imgui.button("Add selected items") then addItemsToItemBox() end
			if imgui.button("Remove all items") then clearItemBox() end
			imgui.tree_pop()
		end

		if imgui.tree_node("Inventory") then
			imgui.text_colored("NOTE: The following features are\nexperimental and may crash the game!", 0xFF0000FF)
			imgui.text("Your inventory must be opened and then\nre-opened when adding or removing items.")
			imgui.text("Do not excessively add items,\nthis will crash the game.\nDecrease the quantity before.")
			if imgui.button("Add selected items") then addItemsToInventory() end
			if imgui.button("Remove all items") then clearInventory() end

			imgui.spacing()

			imgui.text("Do not make your inventory\nsmaller when you have a lot of items in it!")
			imgui.text("This will softlock the game.")
			if imgui.button("No backpack") then setExtendLv(0) end
			if imgui.button("First backpack") then setExtendLv(1) end
			if imgui.button("Second backpack") then setExtendLv(2) end

			imgui.tree_pop()
		end

		if imgui.tree_node("Settings") then
			--imgui.begin_rect()
			imgui.text("The number of each item to add.")
			imgui.text("Choose a low number when adding items\nto your inventory!")
			_, settings.itemQuantity, _, _ = imgui.input_text("items", settings.itemQuantity, 1 << 0) -- Allow 0123456789.+-*/

			imgui.spacing()
			imgui.text(
				"It's impossible to expose Jack's weak spot\nwith certain weapons like the axe\nin the basement fight.")
			imgui.text(
				"His weak spot can be forcibly shown\nafter a certain number of hits you can set here.")
			changedSoftlock, settings.jackSoftlockFix = imgui.checkbox("Fix softlock during Jack 2 fight",
				settings.jackSoftlockFix)

			if settings.jackSoftlockFix then
				changedHits, settings.requiredHitsJack2 = imgui.slider_int("hits", settings.requiredHitsJack2, 1, 20, nil)
				if changedSoftlock or changedHits then json.dump_file(settingsFile, settings) end
			end
			--imgui.end_rect(2)
		end

		imgui.spacing()

		imgui.text("List of items")
		if imgui.button("Select all items") then
			for item_id, _ in pairs(settings.items) do
				settings.items[item_id] = true
			end
			json.dump_file(settingsFile, settings)
		end

		imgui.same_line()

		if imgui.button("Unselect all items") then
			for item_id, _ in pairs(settings.items) do
				settings.items[item_id] = false
			end
			json.dump_file(settingsFile, settings)
		end
		imgui.spacing()

		imgui.begin_rect()
		if imgui.tree_node("Weapons") then
			if imgui.tree_node("Melee") then
				render_checkbox("Bar")
				render_checkbox("ChainSaw")
				render_checkbox("CircularSaw")
				render_checkbox("HandAxe")
				render_checkbox("Knife")
				render_checkbox("MiaKnife")
				imgui.tree_pop()
			end
			if imgui.tree_node("Firearms") then
				render_checkbox("Burner")
				render_checkbox("GrenadeLauncher")
				render_checkbox("Handgun_Albert")
				render_checkbox("Handgun_Albert_Reward")
				render_checkbox("Handgun_G17")
				render_checkbox("Handgun_M19")
				render_checkbox("Handgun_MPM")
				render_checkbox("MachineGun")
				render_checkbox("Magnum")
				render_checkbox("Shotgun_DB")
				render_checkbox("Shotgun_M37")
				render_checkbox("BlueBlaster")
				render_checkbox("HyperBlaster")
				render_checkbox("RedBlaster")
				imgui.tree_pop()
			end
			if imgui.tree_node("Thrown") then
				render_checkbox("LiquidBomb")
				imgui.tree_pop()
			end
			imgui.tree_pop()
		end

		if imgui.tree_node("Ammo") then
			render_checkbox("UnlimitedAmmo")
			render_checkbox("AcidBulletS")
			render_checkbox("BurnerBullet")
			render_checkbox("FlameBulletS")
			render_checkbox("HandgunBullet")
			render_checkbox("HandgunBulletL")
			render_checkbox("MachineGunBullet")
			render_checkbox("MagnumBullet")
			render_checkbox("ShotgunBullet")
			imgui.tree_pop()
		end

		if imgui.tree_node("Medicine") then
			render_checkbox("EyeDrops")
			render_checkbox("Herb")
			render_checkbox("RemedyL")
			render_checkbox("RemedyM")
			imgui.tree_pop()
		end

		if imgui.tree_node("Player Upgrades") then
			render_checkbox("AlphaGrass")
			render_checkbox("BookDefence01")
			render_checkbox("BookDefence02")
			render_checkbox("Depressant")
			render_checkbox("Stimulant")
			render_checkbox("EasyBoots")
			imgui.tree_pop()
		end

		if imgui.tree_node("Coins") then
			render_checkbox("Coin")
			render_checkbox("GoodLuckCoinA")
			render_checkbox("GoodLuckCoinB")
			render_checkbox("GoodLuckCoinC")
			render_checkbox("GoodLuckCoinD")
			render_checkbox("GoodLuckCoinE")
			render_checkbox("PowerUpCoin01A")
			render_checkbox("PowerUpCoin01B")
			imgui.tree_pop()
		end

		if imgui.tree_node("Crafting") then
			render_checkbox("Alcohol")
			render_checkbox("AlloyClay")
			render_checkbox("ChemicalL")
			render_checkbox("ChemicalM")
			render_checkbox("ChemicalS")
			render_checkbox("Flower")
			render_checkbox("Gunpowder")
			render_checkbox("Magnesium")
			render_checkbox("RepairKit")
			imgui.tree_pop()
		end

		if imgui.tree_node("Documents/Books") then
			render_checkbox("MailMia")
			render_checkbox("MiaDriversLicense")
			render_checkbox("ProposalBookFf")
			imgui.tree_pop()
		end

		if imgui.tree_node("Keys") then
			for _, key in ipairs({ "3CrestKeyA", "3CrestKeyB", "3CrestKeyC", "CabinKey", "CylinderKey", "EntranceHallKey", "EthanCarKey", "FloorDoorKey", "LucasCardKey", "LucasCardKey2", "MasterKey", "MorgueKey", "SpareKey", "TalismanKey", "WorkroomKey" }) do
				render_checkbox(key)
			end
			imgui.tree_pop()
		end

		if imgui.tree_node("Maps") then
			render_checkbox("TreasureMap01")
			render_checkbox("TreasureMap02")
			render_checkbox("TreasureMap03")
			imgui.tree_pop()
		end

		if imgui.tree_node("Mission Items") then
			for _, key in ipairs({ "Battery", "BrokenHandgun_M19", "BrokenShotgun_DB", "BurnerPartsA", "BurnerPartsB", "ChainCutter", "Crank", "DummyAxe", "EvCable", "EvelynRadar1", "EvelynRadar2", "EvelynRadar3", "EvelynRadar4", "EvOpener", "Fuse", "FuseCh4", "Lantern", "PendulumClock", "SerumComplete", "SerumMaterialA", "SerumMaterialB", "SerumTypeE", "SilhouettePazzlePiece", "SilhouettePazzlePieceOldHouse", "Timebomb", "ToyShotgun" }) do
				render_checkbox(key)
			end
			imgui.tree_pop()
		end

		if imgui.tree_node("Body Parts") then
			render_checkbox("EthanLeg")
			render_checkbox("HandCutOff")
			imgui.tree_pop()
		end

		if imgui.tree_node("Happy Birthday Items") then
			for _, key in ipairs({ "Balloonbomb", "Candle", "Glasses", "ScrewFinger", "Quill", "Valve", "SpringCoil" }) do
				render_checkbox(key)
			end
			imgui.tree_pop()
		end

		if imgui.tree_node("DLC") then
			render_checkbox("CH9_WP000")
			render_checkbox("CH9_WP001")
			render_checkbox("CH9_WP002")
			render_checkbox("CH9_WP003")
			render_checkbox("CH9_WP004")
			render_checkbox("CH9_WP005")
			render_checkbox("CH9_WP006")
			render_checkbox("CH9_WP007")
			render_checkbox("CH9_WP008")
			imgui.tree_pop()
		end
		if imgui.tree_node("Other") then
			render_checkbox("SaveTape")
			imgui.tree_pop()
		end

		if imgui.tree_node("Videotapes") then
			for _, key in ipairs({ "FoundFootage000", "FoundFootage010", "FoundFootage020", "FoundFootage030", "FoundFootage040", "FoundFootage050" }) do
				render_checkbox(key)
			end
			imgui.tree_pop()
		end

		imgui.end_rect(2)
		imgui.tree_pop()
	end
end)
