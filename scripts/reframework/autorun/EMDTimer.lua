if not reframework:get_game_name() == "re7" then
    re.msg("[Ethan Must Die Timer] Only compatible with RE7!")
    return
end

local in_imd = false
local igt
local hrs, mins, secs, ms
local stopped
local timerPositions = {
    "Top left",
    "Top center",
    "Top right",
    "Bottom left",
    "Bottom center",
    "Bottom right"
}
local enemySpawns = 0

-- region Settings
local settingsJson = "EthanMustDieTimer.json"
local default_settings = {
    timerPosIndex = 1,
    enabled = true,
    color = 0xffffffff
}
local settings = json.load_file(settingsJson) or {}
for k, v in pairs(default_settings) do
    if settings[k] == nil then
        settings[k] = v
    end
end
--endregion

local function formatTimeDetailed(hours, minutes, seconds, milliseconds)
    if hours > 0 then
        return string.format("%02d:%02d:%02d:%03d", hours, minutes, seconds, milliseconds)
    else
        return string.format("%02d:%02d:%03d", minutes, seconds, milliseconds)
    end
end

local function formatTimeConsole(minutes, seconds)
    return string.format("%01d:%02d", minutes, seconds)
end

sdk.hook(
    sdk.find_type_definition("app.InGameTimerForIMD"):get_method("tStart"),
    function(args)
        in_imd = true
        stopped = false
        igt = sdk.to_managed_object(args[2])
    end,
    function(r) return r end
)

sdk.hook(
    sdk.find_type_definition("app.Chapter3_IMD_Result"):get_method("onOpen"),
    function(_)
        stopped = true
        printSplit("End", "4:56")
    end,
    function(r) return r end
)

sdk.hook(
    sdk.find_type_definition("app.PlayerDamageController"):get_method("doDie"),
    function(_)
        stopped = true
        enemySpawns = 0
    end,
    function(r) return r end
)

sdk.hook(
    sdk.find_type_definition("app.InGameTimerForIMD"):get_method("onDestroy"),
    function(_)
        igt = nil
        enemySpawns = 0
    end,
    function(r) return r end
)

local function printSplit(name, wrTime)
    print(name .. ": " .. formatTimeConsole(mins, secs) .. " / " .. wrTime)
end

sdk.hook(
    sdk.find_type_definition("app.EnemyGeneratorManager"):get_method("requestSpawn"),
    function(_)
        if not igt or not in_imd then return end
        enemySpawns = enemySpawns + 1
        if enemySpawns == 3 then
            printSplit("Main Hall", "0:14")
        elseif enemySpawns == 5 then
            printSplit("Hallway", "0:24")
        elseif enemySpawns == 7 then
            printSplit("Fat Molded", "0:45")
        elseif enemySpawns == 8 then
            printSplit("Wire Traps", "1:10")
        elseif enemySpawns == 10 then
            printSplit("Gauntlet 1", "1:22")
        elseif enemySpawns == 13 then
            printSplit("Porch", "2:17")
        elseif enemySpawns == 20 then
            printSplit("Gauntlet 2", "2:57")
        elseif enemySpawns == 24 then
            printSplit("Quick Moldeds", "3:18")
        elseif enemySpawns == 27 then
            printSplit("Green House Gate", "3:39")
        end
    end,
    function(r) return r end
)

-- app.Em3600ActionController.requestDeadAction
sdk.hook(
    sdk.find_type_definition("app.Em3600ActionController"):get_method("requestWindowBrakeEffect"),
    function(_)
        if not in_imd then return end
        printSplit("Marge fight", "4:05")
    end,
    function(r) return r end
)

local function getCoordinates()
    local pos = timerPositions[settings.timerPosIndex]
    local scene_manager = sdk.get_native_singleton("via.SceneManager")
    local scene_manager_type = sdk.find_type_definition("via.SceneManager")
    local view = sdk.call_native_func(scene_manager, scene_manager_type, "get_MainView")
    if not view then return 0, 0 end

    local size = view:call("get_Size")
    local w, h = size.w, size.h
    local padding = 20
    local textWidth = 50
    local textHeight = 25

    if pos == "Top left" then
        return padding, padding
    elseif pos == "Top center" then
        return (w / 2) - (textWidth / 2), padding
    elseif pos == "Top right" then
        return w - textWidth - padding, padding
    elseif pos == "Bottom left" then
        return padding, h - textHeight - padding
    elseif pos == "Bottom center" then
        return (w / 2) - (textWidth / 2), h - textHeight - padding
    elseif pos == "Bottom right" then
        return w - textWidth - padding, h - textHeight - padding
    end

    return 0, 0
end

re.on_frame(function()
    if not igt or not settings.enabled then return end

    if not stopped then
        hrs = igt:call("getCurrentHours") or 0
        mins = igt:call("getCurrentMinutes") or 0
        secs = igt:call("getCurrentSeconds") or 0
        ms = igt:call("getCurrentMilliseconds") or 0
    end

    local x, y = getCoordinates()
    draw.text(formatTimeDetailed(hrs, mins, secs, ms), x, y, settings.color)
end)

re.on_draw_ui(function()
    if imgui.tree_node("Ethan Must Die Timer") then
        local changedEnabled, changedTimerPos, changedColor
        changedEnabled, settings.enabled = imgui.checkbox("Enabled", settings.enabled)
        changedTimerPos, settings.timerPosIndex = imgui.combo("Position", settings.timerPosIndex, timerPositions)
        changedColor, settings.color = imgui.color_picker("Color", settings.color, 0)

        local changed = changedEnabled or changedTimerPos or changedColor
        if changed then json.dump_file(settingsJson, settings) end
        imgui.tree_pop()
    end
end)
