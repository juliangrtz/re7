local version = "1.0"

-- IDA regex: ^app.*IMD.*
-- app_DLCContentSceneManager__addChapter3_IMD_UpLayer318169( red sky?
-- app_DropItemPoolIMD___c__DisplayClass3_0___getTargetInstance_b__0360444 start with knife?
-- app_ItemBoxLotteryManagerIMD__getDropItemInstance184498
-- Enemy spawning: app.EnemyGeneratorManager.requestSpawn()

if not reframework:get_game_name() == "re7" then --or sdk.get_tdb_version() ~= 70 then
    re.msg("[Ethan Must Die Mods] Only compatible with RE7!")
    return
end

-- region Settings
local default_settings = {
    manipulateRNG = true,
    showCratePositions = true,
    detailedLogging = false
}

local settings = json.load_file("EthanMustDieSettings.json") or {}

for k, v in pairs(default_settings) do
    if settings[k] == nil then
        settings[k] = v
    end
end
--endregion

local re7utils = require("utility/RE7Utils")
local crates = {}
local crateItems = {
    NORMAL = { "ChemicalM", "Gunpowder", "ChemicalM", "Gunpowder", "ChemicalM", "Gunpowder", "ChemicalM", "Gunpowder" },
    RARE = { "Burner", "RemedyL", "HandgunBulletL", "HandgunBulletL" },
    SUPERRARE = { "Handgun_M19", "MachineGun" },
    LEGENDARY = { "GrenadeLauncher", "HandgunBulletL", "HandgunBulletL" }
}
local crateIndices = { NORMAL = 0, RARE = 0, SUPERRARE = 0, LEGENDARY = 0 }
local crateDistribution = {
    ["Normal"] = 0,
    ["Rare"] = 0,
    ["SuperRare"] = 0,
    ["Legendary"] = 0,
}
local orderedKeys = { "Normal", "Rare", "SuperRare", "Legendary" }

local function areVectorsClose(vec1, vec2, epsilon)
    return math.abs(vec1.x - vec2.x) < epsilon and
        math.abs(vec1.y - vec2.y) < epsilon and
        math.abs(vec1.z - vec2.z) < epsilon
end

local function hasCrateAtPos(pos, type)
    for i = 1, #crates do
        local crate = crates[i]
        if areVectorsClose(crate:get_Transform():get_Position(), pos, 0.01) then
            if string.find(crate:get_Name(), type) then
                return true
            end
        end
    end

    return false
end

local function forceItem(id)
    crateItems = {
        NORMAL = { id },
        RARE = { id },
        SUPERRARE = { id },
        LEGENDARY = { id }
    }
end

local function manipulateCrateRNG(destroyedCrateType)
    local itemBoxLotteryManager = sdk.get_managed_singleton("app.ItemBoxLotteryManagerIMD")

    if not itemBoxLotteryManager then
        log.error("[Ethan Must Die Mods] Cannot manipulate RNG: Not playing Ethan Must Die!")
        return
    end

    if settings.detailedLogging then
        log.debug("[Ethan Must Die Mods] Destroyed a " .. destroyedCrateType:lower() .. " crate.")
    end

    local itemDropTableContainer = itemBoxLotteryManager:get_field("ItemDropTableContainer")
    local dropTableList = itemDropTableContainer:get_field("DropTableList")
    local dropItemParams = dropTableList:get_field("mItems")

    local index = crateIndices[destroyedCrateType] % #crateItems[destroyedCrateType] + 1
    local newItem = crateItems[destroyedCrateType][index]
    crateIndices[destroyedCrateType] = crateIndices[destroyedCrateType] + 1
    if settings.detailedLogging then log.debug("[Ethan Must Die Mods] Forcing item " .. newItem) end

    for i = 0, 3 do
        local param = dropItemParams[i]
        --local dropTableName = param:get_field("DropTableName")
        local dropItemList = param:get_field("DropItemList")
        local items = dropItemList:get_field("mItems")

        for j = 0, #items - 1 do
            local item = items[j]
            item.ItemID = newItem
        end
    end

    if destroyedCrateType ~= "NORMAL" then
        log.debug("[Ethan Must Die Mods] Forcing weapon " .. newItem .. "...")

        local substituteDropTableList = itemDropTableContainer:get_field("SubstituteDropTableList")
        local substituteDropItemParams = substituteDropTableList:get_field("mItems")
        local table = substituteDropItemParams[0]
        local dropItemList = table:get_field("DropItemList")
        local items = dropItemList:get_field("mItems")

        for j = 0, #items - 1 do
            local item = items[j]

            if re7utils.EMDWeapons[newItem] then
                local wp = re7utils.EMDWeapons[newItem]
                item.WeaponID = wp.id
                item.ItemID = wp.itemID
                item.StackNum = wp.stackNum
            else
                item.WeaponID = newItem
                item.ItemID = newItem
            end
        end
    end
end

--region Hooks
local restartControl
sdk.hook(
    sdk.find_type_definition("app.OtherRestartControl"):get_method("doUpdate"),
    function(args)
        if restartControl then return end
        restartControl = sdk.to_managed_object(args[2])
    end,
    function(r) return r end
)

re.on_draw_ui(function()
    if imgui.tree_node("Ethan Must Die Trainer") then
        imgui.text("Version " .. version)
        imgui.spacing()

        imgui.begin_rect()

        imgui.text_colored("This tool shall only be used for experimentation\nand not official speedruns!", 0xFF0000FF)
        _, settings.manipulateRNG = imgui.checkbox("Manipulate RNG", settings.manipulateRNG)

        if imgui.tree_node("Developer Tools") then
            _, settings.detailedLogging = imgui.checkbox("Detailed logging", settings.detailedLogging)

            if imgui.button("Albert > Infinite Ammo > Heal") then
                crateItems = {
                    NORMAL = { "Handgun_Albert_Reward", "UnlimitedAmmo", "RemedyL", },
                    RARE = { "Handgun_Albert_Reward", "UnlimitedAmmo", "RemedyL", },
                    SUPERRARE = { "Handgun_Albert_Reward", "UnlimitedAmmo", "RemedyL", },
                    LEGENDARY = { "Handgun_Albert_Reward", "UnlimitedAmmo", "RemedyL", },
                }
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Force specific items") then
            if imgui.button("Albert") then forceItem("Handgun_Albert_Reward") end; imgui.same_line()
            if imgui.button("Burner") then forceItem("Burner") end; imgui.same_line()
            if imgui.button("M19") then forceItem("Handgun_M19") end; imgui.same_line()
            if imgui.button("MPM") then forceItem("Handgun_MPM") end; imgui.same_line()
            if imgui.button("P19") then forceItem("MachineGun") end;
            if imgui.button("44 MAG") then forceItem("Magnum") end; imgui.same_line()
            if imgui.button("M21") then forceItem("Shotgun_DB") end; imgui.same_line()
            if imgui.button("M37") then forceItem("Shotgun_M37") end; imgui.same_line()
            if imgui.button("Heal") then forceItem("RemedyL") end; imgui.same_line()
            if imgui.button("Roids") then forceItem("Stimulant") end;
            if imgui.button("Grenade Launcher") then forceItem("GrenadeLauncher") end; imgui.same_line()
            if imgui.button("Key") then forceItem("GreenHouseKey") end; imgui.same_line()
            if imgui.button("Inf. Ammo") then forceItem("UnlimitedAmmo") end;

            for _ = 0, 3 do imgui.spacing() end

            if imgui.button("Reset drop tables") then
                crateItems = {
                    NORMAL = { "ChemicalM", "Gunpowder" },
                    RARE = { "Burner", "RemedyL", "HandgunBulletL", "HandgunBulletL" },
                    SUPERRARE = { "Handgun_M19", "MachineGun" },
                    LEGENDARY = { "GrenadeLauncher", "Magnum", "HandgunBulletL" }
                }

                crateIndices = { NORMAL = 0, RARE = 0, SUPERRARE = 0, LEGENDARY = 0 }
            end
            imgui.tree_pop()
        end

        if imgui.tree_node("Teleport") then
            if imgui.button("Main Hall") then re7utils.teleportPlayer(Vector3f.new(-1.082761, 0.000000, 14.237036)) end; imgui
                .same_line()
            if imgui.button("Basement") then re7utils.teleportPlayer(Vector3f.new(-19.955242, -5.250000, 12.617932)) end; imgui
                .same_line()
            if imgui.button("Wire Traps") then re7utils.teleportPlayer(Vector3f.new(-10.607572, -7.252150, -1.949934)) end
            if imgui.button("Gauntlet 1") then re7utils.teleportPlayer(Vector3f.new(-21.759951, -5.250000, -2.505168)) end; imgui
                .same_line()
            if imgui.button("Jack") then re7utils.teleportPlayer(Vector3f.new(0.530319, 4.000000, 4.860207)) end; imgui
                .same_line()
            if imgui.button("Hallway") then re7utils.teleportPlayer(Vector3f.new(22.662031, 0, 12.848048)) end
            if imgui.button("Trailer") then re7utils.teleportPlayer(Vector3f.new(7.704638, -1.626612, 39.341892)) end; imgui
                .same_line()
            if imgui.button("Green House Entrance") then
                re7utils.teleportPlayer(Vector3f.new(12.959277, 0.850000, 72.082726))
            end
            imgui.tree_pop()
        end

        imgui.spacing()

        if imgui.tree_node("Crates") then
            _, settings.showCratePositions = imgui.checkbox("Show crate positions", settings.showCratePositions)
            imgui.text("N = Normal (1 star)")
            imgui.text("R = Rare (2 stars)")
            imgui.text("S = Super rare (3 stars)")
            imgui.text("L = Legendary (4 stars)")

            imgui.spacing()

            imgui.text("Normal crate near spawn (1): " ..
                tostring(hasCrateAtPos(Vector3f.new(-4.831269, 0.835502, 44.972279), "Normal")))
            imgui.text("Normal crate near spawn (2): " ..
                tostring(hasCrateAtPos(Vector3f.new(-3.277556, -1.154342, 21.520510), "Normal")))

            imgui.spacing()

            for _, key in ipairs(orderedKeys) do
                imgui.text(key .. " boxes: " .. crateDistribution[key])
            end
            imgui.tree_pop()
        end

        if imgui.tree_node("Actions") then
            if imgui.button("Restart run") then
                if restartControl then restartControl:requestRestart() end
            end

            if imgui.button("Spawn statue with Albert") then
                local playerPos = re7utils.get_localplayer():get_Transform():get_Position()
                sdk.get_managed_singleton("app.EthanGraveMarkerManager").GraveMarker:instantiate(playerPos)
            end
            imgui.tree_pop()
        end

        imgui.tree_pop()
        imgui.end_rect(5)
        imgui.spacing()
        imgui.spacing()
    end
end)

-- Called when destroying an angel statue.
sdk.hook(
    sdk.find_type_definition("app.EthanGraveMarker"):get_method("createDropItem"),
    function(args)
        sdk.to_managed_object(args[2]).createItemId = "Handgun_Albert_Reward" -- Force Albert
    end,
    function(retval) return retval end
)

-- Box initialization function.
sdk.hook(
    sdk.find_type_definition("app.ItemBoxSetPointIMD"):get_method("overrideIntaractParam"),
    function(args)
        local box = sdk.to_managed_object(args[3])
        table.insert(crates, box)

        if settings.detailedLogging then
            log.debug("[Ethan Must Die Mods] Box at " ..
                re7utils.vec3tostring(box:get_Transform():get_Position()) .. " :: " .. box:get_Name())
        end

        local name = box:get_Name()
        if name == "sm9133_IMD_NormalBox" then
            crateDistribution["Normal"] = crateDistribution["Normal"] + 1
        elseif name == "sm9133_IMD_RareBox" then
            crateDistribution["Rare"] = crateDistribution["Rare"] + 1
        elseif name == "sm9133_IMD_SuperRareBox" then
            crateDistribution["SuperRare"] = crateDistribution["SuperRare"] + 1
        elseif name == "sm2619_IMD_LegendaryBox" then
            crateDistribution["Legendary"] = crateDistribution["Legendary"] + 1
        else
            log.debug("WTF: " .. name)
        end
    end,
    function(retval) return retval end
)

-- Cleanup on restarts.
sdk.hook(
    sdk.find_type_definition("app.ItemBoxLotteryManagerIMD"):get_method("onDestroy"),
    function(_)
        crates = {}
        crateDistribution = {
            ["Normal"] = 0,
            ["Rare"] = 0,
            ["SuperRare"] = 0,
            ["Legendary"] = 0,
        }
        re7utils.clearDebugConsole()
    end,
    function(retval) return retval end
)

-- This method gets called every time a crate is destroyed.
sdk.hook(
    sdk.find_type_definition("app.ItemBoxLotteryManagerIMD"):get_method("getDropItemInstance"),
    function(args)
        local destroyedCrate = sdk.to_managed_object(args[3])
        local dropTableName = sdk.to_managed_object(args[4]):call("ToString")
        manipulateCrateRNG(dropTableName)

        for i, crate in ipairs(crates) do
            if (crate:get_Transform():get_Position() == destroyedCrate:get_Transform():get_Position()) then
                table.remove(crates, i)
            end
        end
    end,
    function(retval) return retval end --post
)



local function getCrateLabelAndColor(name)
    if name == "sm9133_IMD_NormalBox" then
        return { label = "N", color = re7utils.rgbToInt(1, 0.984, 0, 1):int() }
    elseif name == "sm9133_IMD_RareBox" then
        return { label = "R", color = re7utils.rgbToInt(0, 1, 0, 1):int() }
    elseif name == "sm9133_IMD_SuperRareBox" then
        return { label = "S", color = re7utils.rgbToInt(1, 0, 0.894, 1):int() }
    elseif name == "sm2619_IMD_LegendaryBox" then
        return { label = "L", color = re7utils.rgbToInt(1, 0, 0, 1):int() }
    else
        log.debug(name)
        return { label = "?", color = re7utils.rgbToInt(1, 1, 1, 1):int() }
    end
end

re.on_frame(function()
    if not settings.showCratePositions or not next(crates) then return end

    for i = 1, #crates - 1 do
        local crate = crates[i]
        local crateName = crate:get_Name()
        local labelColorPair = getCrateLabelAndColor(crateName)
        draw.world_text(labelColorPair.label, crate:get_Transform():get_Position(), labelColorPair.color)
    end
end)

--endregion
