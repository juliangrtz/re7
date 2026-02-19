local version = "1.1"

--[[
TODO

[X] Player X/Z/Y axis setting
[X] Player scale
[X] Invincibility
[X] Infinite Ammo
[X] Player speed
[X] Unlock All Items
[X] Inventory case size modifier
[X] Stats
[X] Enemy one hit kill
[X] Enemy speed
[X] NoClip/Wallhack

Bindable hotkeys
Inventory editor (Adding/Removing weapons/key items/treasures/ammo)
Enemy scale
Enemy ignore player
Damage modifier
No recoil
Game difficulty modifier
Manual flashlight
Camera FOV modifier
]]

if reframework:get_game_name() ~= "re7" then
    re.msg("[RE7 Ultimate Trainer] Only compatible with Resident Evil 7!")
    return
end

local default_settings = {
    godmode = false,
    infinite_ammo = false,
    move_speed_multiplier = 1.0,
    player_scale = 1.0,
    enemy_scale = 1.0,
    change_enemy_speed = false,
    enemy_speed_multiplier = 1.0,
    enemy_insta_kill = false,
    freeze_itembox_count = false,
    noclip = false,
    noclip_speed = 0.4,
}
local settingsFile = "UltimateRE7Trainer.json"
local settings = json.load_file(settingsFile) or {}

for k, v in pairs(default_settings) do
    if settings[k] == nil then
        settings[k] = v
    end
end

--region Data

local AchievementTag = {
    CountOfKilledByKnife = 0,
    CountOfKilledByAttachBomb = 1,
    CountOfOpenItemBox = 2,
    CountOfUsedCure = 3,
    CountOfRepulsedInTheAir = 4,
    CountOfRepulsedMother = 5,
    CountOfSucceededGuards = 6,
    CountOfCloseDoor = 7,
    CountOfBrokenInsectDoorsByKnife = 8,
    CountOfTwoKilledAtOneShot = 9,
    CountOfAvoidBySquat = 10,
    CountOfGetItemByDetailSearch = 11,
    CountOfUsedEyedLotion = 12,
    CountOfSetupMissShadowPuzzle = 13,
    CountOfCoins = 14,
    CountOfCoinsForHard = 15,
    CountOfFiles = 16,
    CountOfPicking = 17,
    CountOfStabilizers = 18,
    CountOfSteroids = 19,
    CollectOffFormulated = 20,
    CollectOffClearedFF = 21,
    StatsGetFuseCHP1 = 22,
    StatsGetFuseCHP4 = 23,
    StatsGetFuseFF = 24,
    StatsGetShotgunDummy = 25,
    StatsGetShotgunWp1039 = 26,
    StatsGetShotgunWp1030 = 27,
    StatsGetShotgunWp1230 = 28,
    StatsGetShotgunWp1280 = 29,
    StatsGetCandle = 30,
    StatsGetCandleFire = 31,
}

local ItemId = {
    "Bar", "ChainSaw", "CircularSaw", "HandAxe", "Knife", "MiaKnife", "Burner", "GrenadeLauncher", "Handgun_Albert",
    "Handgun_Albert_Reward", "Handgun_G17", "Handgun_M19", "Handgun_MPM", "MachineGun", "Magnum", "Shotgun_DB",
    "Shotgun_M37", "BlueBlaster", "HyperBlaster", "RedBlaster", "LiquidBomb", "UnlimitedAmmo", "AcidBulletS",
    "BurnerBullet", "FlameBulletS", "HandgunBullet", "HandgunBulletL", "MachineGunBullet", "MagnumBullet",
    "ShotgunBullet", "EyeDrops", "Herb", "RemedyL", "RemedyM", "AlphaGrass", "BookDefence01", "BookDefence02",
    "Depressant", "Stimulant", "EasyBoots", "Coin", "GoodLuckCoinA", "GoodLuckCoinB", "GoodLuckCoinC",
    "GoodLuckCoinD", "GoodLuckCoinE", "PowerUpCoin01A", "PowerUpCoin01B", "Alcohol", "AlloyClay", "ChemicalL",
    "ChemicalM", "ChemicalS", "Flower", "Gunpowder", "Magnesium", "RepairKit", "MailMia", "MiaDriversLicense",
    "ProposalBookFf", "3CrestKeyA", "3CrestKeyB", "3CrestKeyC", "CabinKey", "CylinderKey", "EntranceHallKey",
    "EthanCarKey", "FloorDoorKey", "LucasCardKey", "LucasCardKey2", "MasterKey", "MorgueKey", "SpareKey",
    "TalismanKey", "WorkroomKey", "TreasureMap01", "TreasureMap02", "TreasureMap03", "Battery", "BrokenHandgun_M19",
    "BrokenShotgun_DB", "BurnerPartsA", "BurnerPartsB", "ChainCutter", "Crank", "DummyAxe", "EvCable", "EvelynRadar1",
    "EvelynRadar2", "EvelynRadar3", "EvelynRadar4", "EvOpener", "Fuse", "FuseCh4", "Lantern", "PendulumClock",
    "SerumComplete", "SerumMaterialA", "SerumMaterialB", "SerumTypeE", "SilhouettePazzlePiece",
    "SilhouettePazzlePieceOldHouse", "Timebomb", "ToyShotgun", "EthanLeg", "HandCutOff", "Balloonbomb", "Candle",
    "Glasses", "ScrewFinger", "Quill", "Valve", "SpringCoil", "SaveTape", "SupplyBoxA", "SupplyBoxOpenedA",
    "SupplyBoxB", "SupplyBoxOpenedB", "SupplyBoxC", "SupplyBoxOpenedC", "FoundFootage000", "FoundFootage010",
    "FoundFootage020", "FoundFootage030", "FoundFootage040", "FoundFootage050"
}

local PlaneType = {
    None = 0,
    Ground = 1,
    Slope = 2,
    Wall = 3,
    Ceiling = 4,
}

--endregion

local has_warned = false
local function get_singleton(name)
    local s = sdk.get_managed_singleton(name)
    if not s and not has_warned then
        re.msg("[RE7 Ultimate Trainer] Did not find singleton " .. name .. ", are you inside a Nightmare game?")
        has_warned = true
    end
    return s
end

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

local function setExtendLv(lv)
    local inventory = getComponent(getLocalPlayer(), "app.Inventory")
    if not inventory then return end
    local lvl = inventory:get_field("_ExtendLv")
    if lvl ~= 2 then
        inventory:setExtendLv(lv)
    end
end

local function getItemBoxData()
    local inventory = getComponent(getLocalPlayer(), "app.Inventory")
    if not inventory then return end
    return inventory:get_field("<ItemBoxData>k__BackingField")
end

local function addAllItemsToItemBox()
    for _, itemId in ipairs(ItemId) do
        local signature = "addItem(System.String, System.Int32, app.WeaponGun.WeaponGunSaveData)"
        local itemBoxData = getItemBoxData()
        if not itemBoxData then return end
        itemBoxData:call(signature, itemId, 100, nil)
    end
end

local function teleportPlayer(x, y, z)
    local player = getLocalPlayer()
    local controller = getComponent(player, "via.physics.CharacterController")
    if not player or not controller then return end
    controller:call("warp")
    player:get_Transform():set_Position(Vector3f.new(x, y, z))
    controller:call("warp")
end

local function changePlayerScale(scale)
    local player = getLocalPlayer()
    if not player then return end
    player:get_Transform():set_LocalScale(Vector3f.new(scale, scale, scale))
end

local function addCount(stat, count)
    local achvm = get_singleton("app.Achievement")
    local signature = "addCount(app.Achievement.VariablesTagID)"

    for _ = 0, count do
        achvm:call(signature, stat)
    end
end

--region Hooks
sdk.hook(
    sdk.find_type_definition("app.PlayerDamageController"):get_method("get_isEnableDamage"),
    nil,
    function(retval)
        if settings.godmode then
            return false
        else
            return retval
        end
    end
)

sdk.hook(
    sdk.find_type_definition("app.PlayerMovement"):get_method("getMoveSpeed"),
    nil,
    function(retval)
        local original = sdk.to_float(retval)
        return sdk.float_to_ptr(original * settings.move_speed_multiplier)
    end
)

sdk.hook(
    sdk.find_type_definition("app.WeaponGun"):get_method("set_loadNum"),
    function(a)
        if settings.infinite_ammo then
            return sdk.PreHookResult.SKIP_ORIGINAL
        end
    end,
    nil
)

sdk.hook(
    sdk.find_type_definition("app.Achievement"):get_method("addCount(app.Achievement.VariablesTagID)"),
    function(args)
        if settings.freeze_itembox_count and sdk.to_int64(args[3]) == AchievementTag.CountOfOpenItemBox then
            return sdk.PreHookResult.SKIP_ORIGINAL
        end
    end,
    nil
)

sdk.hook(
    sdk.find_type_definition("app.EnemyActionController"):get_method("calcDamageRate"),
    nil,
    function(retval)
        if settings.enemy_insta_kill then
            local original = sdk.to_float(retval)
            return sdk.float_to_ptr(original * 100000)
        else
            return retval
        end
    end
)

sdk.hook(
    sdk.find_type_definition("app.EnemyActionController"):get_method("get_latestAnimationSpeedRateForRank"),
    nil,
    function(retval)
        if settings.change_enemy_speed then
            local original = sdk.to_float(retval)
            return sdk.float_to_ptr(original * settings.enemy_speed_multiplier)
        else
            return retval
        end
    end
)

sdk.hook(
    sdk.find_type_definition("app.WeaponGun"):get_method("getBulletType"),
    nil,
    function(retval)
        if settings.all_guns_automatic then
            return sdk.to_int64(23)
        else
            return retval
        end
    end
)

--endregion

re.on_frame(function()
    if not settings.noclip then return end

    local player = getLocalPlayer()
    if not player then return end

    local transform = player:get_Transform()
    local pos = transform:get_Position()

    local w = reframework:is_key_down(0x57) -- W
    local s = reframework:is_key_down(0x53) -- S
    local d = reframework:is_key_down(0x44) -- D
    local a = reframework:is_key_down(0x41) -- A

    if w then pos.x = pos.x - settings.noclip_speed end
    if s then pos.x = pos.x + settings.noclip_speed end
    if d then pos.z = pos.z - settings.noclip_speed end
    if a then pos.z = pos.z + settings.noclip_speed end

    local controller = getComponent(player, "via.physics.CharacterController")
    if controller then
        controller:call("warp")
    end

    transform:set_Position(pos)

    if controller then
        controller:call("warp")
    end
end)


--region UI
re.on_draw_ui(function()
    if imgui.tree_node("RE7 Ultimate Trainer") then
        imgui.text("Version " .. version)
        imgui.text_colored("Work in progress", 0xFF00FFFF)
        imgui.spacing()

        if imgui.tree_node("Player") then
            imgui.text("You'll no longer take damage with this.")
            local changedGodmode
            changedGodmode, settings.godmode = imgui.checkbox("God mode", settings.godmode)
            if changedGodmode then json.dump_file(settingsFile, settings) end

            local changedNoclip
            imgui.text("Move wherever you want.")
            changedNoclip, settings.noclip = imgui.checkbox("(BETA) Noclip", settings.noclip)
            if changedNoclip then json.dump_file(settingsFile, settings) end

            local changedNoclipSpeed
            imgui.text("Noclip speed")
            changedNoclipSpeed, settings.noclip_speed = imgui.slider_float("delta x,y,z",
                settings.noclip_speed, 0.1, 1.0, nil)
            if changedNoclipSpeed then json.dump_file(settingsFile, settings) end

            local changedMovementSpeed
            imgui.text("Movement speed multiplier")
            changedMovementSpeed, settings.move_speed_multiplier = imgui.slider_float("x speed (player)",
                settings.move_speed_multiplier, 0.1, 100.0, nil)
            if changedMovementSpeed then json.dump_file(settingsFile, settings) end

            if imgui.button("Reset movement speed") then
                settings.move_speed_multiplier = 1.0
                json.dump_file(settingsFile, settings)
            end

            imgui.spacing()

            imgui.text("Position")
            imgui.set_next_item_width(50)
            local changedX, x = imgui.input_text("X", x, 1 << 0)
            imgui.same_line()
            imgui.set_next_item_width(50)
            local changedY, y = imgui.input_text("Y", y, 1 << 0)
            imgui.same_line()
            imgui.set_next_item_width(50)
            local changedZ, z = imgui.input_text("Z", z, 1 << 0)
            imgui.same_line()

            if changedX or changedY or changedZ then
                teleportPlayer(x, y, z)
            end

            imgui.spacing()

            imgui.text("Scale")
            local changedPlayerScale
            changedPlayerScale, settings.player_scale = imgui.slider_float("x scale (player)", settings.player_scale, 0.1,
                100.0, nil)

            if changedPlayerScale then
                changePlayerScale(settings.player_scale)
                json.dump_file(settingsFile, settings)
            end

            if imgui.button("Reset scale") then
                settings.player_scale = 1.0
                changePlayerScale(1.0)
                json.dump_file(settingsFile, settings)
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Weapons") then
            local changedInfAmmo
            imgui.text("Ammo count never decreases.")
            changedInfAmmo, settings.infinite_ammo = imgui.checkbox("Infinite ammo", settings.infinite_ammo)
            if changedInfAmmo then json.dump_file(settingsFile, settings) end

            local changedAutoGuns
            changedAutoGuns, settings.all_guns_automatic = imgui.checkbox("All guns are automatic",
                settings.all_guns_automatic)
            if changedAutoGuns then json.dump_file(settingsFile, settings) end

            imgui.tree_pop()
        end

        if imgui.tree_node("Items") then
            if imgui.button("Unlock all items in the item box") then
                addAllItemsToItemBox()
            end

            if imgui.button("Set maximum inventory size") then
                setExtendLv(2)
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Enemies") then
            imgui.text("Instantly kill enemies when damaging them.")
            local changedEnemyInstaKill
            changedEnemyInstaKill, settings.enemy_insta_kill = imgui.checkbox("Insta kill", settings.enemy_insta_kill)
            if changedEnemyInstaKill then json.dump_file(settingsFile, settings) end

            imgui.text("Whether to change the speed of enemies.")
            imgui.text("This won't work for all enemies and bosses!")
            local toggleEnemySpeed
            toggleEnemySpeed, settings.change_enemy_speed = imgui.checkbox("Change speed", settings.change_enemy_speed)
            if toggleEnemySpeed then json.dump_file(settingsFile, settings) end

            imgui.text("Movement speed multiplier")
            local changedMovementSpeed
            changedMovementSpeed, settings.enemy_speed_multiplier = imgui.slider_float("x speed (enemy)",
                settings.enemy_speed_multiplier, 0.1, 10.0, nil)
            if changedMovementSpeed then json.dump_file(settingsFile, settings) end

            if imgui.button("Reset movement speed") then
                settings.enemy_speed_multiplier = 1.0
                json.dump_file(settingsFile, settings)
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Stats") then
            local gameMngr = sdk.get_managed_singleton("app.GameManager")
            if gameMngr then
                imgui.text("Current rank: " .. gameMngr:getGameRank() .. "/9")
            end

            local changedItemBoxCount
            changedItemBoxCount, settings.freeze_itembox_count = imgui.checkbox("Freeze item box open count",
                settings.freeze_itembox_count)
            if changedItemBoxCount then
                json.dump_file(settingsFile, settings)
            end

            if imgui.button("Set restart count to 0") then
                local gameMngr = get_singleton("app.GameManager")
                gameMngr.RestartCount = sdk.create_int32(0)
            end

            if imgui.button("Add antique coins") then
                addCount(AchievementTag.CountOfCoins, 18)
                addCount(AchievementTag.CountOfCoinsForHard, 33)
            end

            if imgui.button("Add 32 files") then
                addCount(AchievementTag.CountOfFiles, 32)
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Miscellaneous") then
            if imgui.button("Set default settings") then
                settings = default_settings
            end

            if imgui.button("Print achievement stats") then
                local achvm = get_singleton("app.Achievement")

                for i, t in ipairs(AchievementTag) do
                    local ok, result = pcall(function()
                        return achvm:getCount(i)
                    end)

                    if ok then
                        log.debug(t .. " = " .. result)
                    end
                end
            end

            if imgui.button("Log data for troubleshooting") then
                log.debug("--------------------------------------------------")
                log.debug("RE7 Ultimate Trainer v" .. version)
                if getLocalPlayer() ~= nil then
                    log.debug("Is in game.")
                else
                    log.debug("Is not in game.")
                end
                log.debug("Game: " .. reframework:get_game_name())
                log.debug("REFramework commit count: " .. reframework:get_commit_count())
                log.debug("REFramework branch: " .. reframework:get_branch())
                log.debug("REFramework commit hash: " .. reframework:get_commit_hash())
                log.debug("REFramework tag: " .. reframework:get_tag())
                log.debug("REFramework build time: " ..
                    reframework:get_build_date() .. " - " .. reframework:get_build_time())
                log.debug("--------------------------------------------------")

                re.msg(
                    "Data logged. Please spawn the debug console and provide the output when describing your issue. You can spawn it in the menu above (ScriptRunner).")
            end
        end

        imgui.spacing()

        imgui.tree_pop()
    end
end)
--endregion
