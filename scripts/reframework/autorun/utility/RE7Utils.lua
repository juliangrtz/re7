local re7utils = {}

function re7utils.clearDebugConsole()
    for _ = 0, 100 do log.debug("") end
end

function re7utils.rgbToInt(r, g, b, a)
    local t = {
        R = r,
        G = g,
        B = b,
        A = a,
        int = function(self)
            return math.floor(self.A * 255) * 16777216 +
                math.floor(self.B * 255) * 65536 +
                math.floor(self.G * 255) * 256 +
                math.floor(self.R * 255)
        end
    }

    return t
end

function re7utils.sleep(a)
    local sec = tonumber(os.clock() + a);
    while (os.clock() < sec) do
    end
end

function re7utils.vec3tostring(vec3) return string.format("(%f, %f, %f)", vec3.x, vec3.y, vec3.z) end

function re7utils.teleportPlayer(pos)
    local player = re7utils.get_localplayer()
    local controller = re7utils.get_component(player, "via.physics.CharacterController")
    if not player or not controller then return end
    controller:call("warp")
    player:get_Transform():set_Position(pos)
    controller:call("warp")
end

function re7utils.get_localplayer()
    local object_man = sdk.get_managed_singleton("app.ObjectManager")

    if not object_man then
        return nil
    end

    return object_man:get_field("PlayerObj")
end

local known_typeofs = {}
function re7utils.get_component(game_object, type_name)
    local t = known_typeofs[type_name] or sdk.typeof(type_name)

    if t == nil then
        return nil
    end

    known_typeofs[type_name] = t
    return game_object:call("getComponent(System.Type)", t)
end

function re7utils.to_table(managedObj)
    if not managedObj then return nil end

    local t = {}
    local klass = sdk.find_type_definition(managedObj:get_type_definition():get_full_name())
    if not klass then return t end

    local fields = klass:get_fields()
    for i = 0, #fields - 1 do
        local field = fields[i]
        local ok, value = pcall(function()
            return field:get_data(managedObj)
        end)
        if ok then
            if sdk.is_managed_object(value) then
                t[field:get_name()] = re7utils.to_table(value)
            else
                t[field:get_name()] = value
            end
        end
    end

    return t
end

-- region Data lookup

re7utils.ItemFriendlyNames = {
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

    -- Videotapes
    ["FoundFootage000"] = "Derelict House Footage (1)",
    ["FoundFootage010"] = "FoundFootage010",
    ["FoundFootage020"] = "Derelict House Footage (2)",
    ["FoundFootage030"] = "Mia",
    ["FoundFootage040"] = "Happy Birthday",
    ["FoundFootage050"] = "Old Videotape",
}

re7utils.WeaponIDs = {
    -- Weapons - Melee
    ["Bar"] = { name = "Crowbar", id = 4 },
    ["ChainSaw"] = { name = "Chain Saw", id = 29 },
    ["CircularSaw"] = { name = "Circular Saw", id = 2 },
    ["HandAxe"] = { name = "Axe", id = 1 },
    ["Knife"] = { name = "Knife", id = 3 },
    ["MiaKnife"] = { name = "Survival Knife", id = 42 },

    -- Weapons - Firearms
    ["Burner"] = { name = "Flamethrower", id = 17 },
    ["GrenadeLauncher"] = { name = "Grenade Launcher", id = 16 },
    ["Handgun_Albert"] = { name = "Albert-01", id = 9 },
    ["Handgun_Albert_Reward"] = { name = "Albert-01 R", id = 46 },
    ["Handgun_G17"] = { name = "G17 Handgun", id = 7 },
    ["Handgun_M19"] = { name = "M19 Handgun", id = 6 },
    ["Handgun_MPM"] = { name = "MPM Handgun", id = 8 },
    ["MachineGun"] = { name = "P19 Machine Gun", id = 14 },
    ["Magnum"] = { name = "44 MAG", id = 15 },
    ["Shotgun_DB"] = { name = "M21 Shotgun", id = 13 },
    ["Shotgun_M37"] = { name = "M37 Shotgun", id = 11 },
    ["BlueBlaster"] = { name = "BlueBlaster", id = 51 },
    ["HyperBlaster"] = { name = "HyperBlaster", id = 44 },
    ["RedBlaster"] = { name = "RedBlaster", id = 52 },

    -- Weapons - Thrown
    ["LiquidBomb"] = { name = "Remote Bomb", id = 21 },
    ["Timebomb"] = { name = "Time Bomb", id = 22 },

    -- Medicine
    ["EyeDrops"] = { name = "Psychostimulants", id = 25 },
    ["RemedyM"] = { name = "First Aid Med", id = 24 },
    ["Stimulant"] = { name = "Steroids - Increase Max Health", id = 26 },
    ["Depressant"] = { name = "Stabilizer - Faster Reload", id = 27 },

    -- Mission Items
    ["ChainCutter"] = { name = "Bolt Cutters", id = 32 },
    ["Lantern"] = { name = "Lantern", id = 35 },
    ["Candle"] = { name = "Candle", id = 18 },
    ["Glasses"] = { name = "Dirty Telescope", id = 19 },
    ["EvelynRadar1"] = { name = "Eveline Strange Bottle", id = 20 },
}

re7utils.EMDWeapons = {
    Hand = { id = 0, itemID = "HandgunBulletL", stackNum = 4 },
    CircularSaw = { id = 2, itemID = "HandgunBulletL", stackNum = 4 },
    Handgun = { id = 5, itemID = "HandgunBulletL", stackNum = 4 },
    Handgun_M19 = { id = 6, itemID = "HandgunBulletL", stackNum = 4 },
    Handgun_G17 = { id = 7, itemID = "HandgunBulletL", stackNum = 4 },
    Handgun_MPM = { id = 8, itemID = "HandgunBulletL", stackNum = 4 },
    Handgun_Albert_Reward = { id = 46, itemID = "HandgunBulletL", stackNum = 4 },
    Shotgun_M37 = { id = 11, itemID = "ShotgunBullet", stackNum = 5 },
    Shotgun_DB = { id = 13, itemID = "ShotgunBullet", stackNum = 3 },
    MachineGun = { id = 14, itemID = "MachineGunBullet", stackNum = 70 },
    Magnum = { id = 15, itemID = "MagnumBullet", stackNum = 4 },
    GrenadeLauncher = { id = 16, itemID = "AcidBulletS", stackNum = 2 },
    Burner = { id = 17, itemID = "BurnerBullet", stackNum = 100 },
    Glasses = { id = 17, itemID = "HandgunBulletL", stackNum = 4 },
    Remedy = { id = 24, itemID = "HandgunBulletL", stackNum = 4 },
    RemedyL = { id = 0, itemID = "HandgunBulletL", stackNum = 4 },
    HandgunBulletL = { id = 0, itemID = "HandgunBulletL", stackNum = 4 },
    EyeDrops = { id = 25, itemID = "HandgunBulletL", stackNum = 4 },
    Stimulant = { id = 26, itemID = "HandgunBulletL", stackNum = 4 },
    Depressant = { id = 27, itemID = "HandgunBulletL", stackNum = 4 },
    MiaKnife = { id = 42, itemID = "HandgunBulletL", stackNum = 4 },
}

re7utils.EMDItems = {
    -- TBD
}

re7utils.Enemies = {
    em2000 = "Mia",
    em3000 = "Jack",
    em3100 = "Marguerite",
    em3200 = "Lucas",
    em3300 = "Old Eveline",
    em3400 = "Zoe",
    em3550 = "Young Eveline",
    em3600 = "Marguerite Boss",
    em4000 = "Molded",
    em4100 = "4-Legged Molded",
    em4200 = "Fat Molded",
    em5200 = "Crow",
    em5400 = "Insects",
    em5500 = "Darker Insects",
    em5600 = "Cockroach",
    em6000 = "Alan",
    em6100 = "Police David",
    em6200 = "Andre",
    em6500 = "Molded David",
    em8000 = "Jack Saw Fight",
    em8100 = "Jack Eyes Boss",
    em8900 = "Evie Final Form",
    em9200 = "Pete",
    em9600 = "???",
    em9700 = "Dead Andre",
    em9900 = "Worker David"
}

--endregion

return re7utils
