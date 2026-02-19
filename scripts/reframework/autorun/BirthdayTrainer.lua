if reframework:get_game_name() ~= "re7" then
    re.msg("[Jack's 55th Birthday Trainer] Only compatible with RE7!")
    return
end

local has_warned = false
local function get_singleton(name)
    local s = sdk.get_managed_singleton(name)
    if not s and not has_warned then
        re.msg("[Jack's 55th Birthday Trainer] Did not find singleton " ..
            name .. ", are you inside a Jack's 55th Birthday game?")
        has_warned = true
    end
    return s
end

--region Timer

local function get_timer()
    local birthday_game_master = get_singleton("app.BirthdayGameMaster")
    return birthday_game_master.Timer
end

local function resume_timer()
    local timer = get_timer()
    timer:requestReleasePause()
end

local function pause_timer()
    local timer = get_timer()
    timer:requestPause()
end

local function reset_timer()
    local timer = get_timer()
    timer:requestTimerReset()
    timer:requestTimerStart()
end

local function format_timer()
    local timer = get_timer()
    local min   = string.format("%02d", timer:get_CurrentTimerMin())
    local sec   = string.format("%02d", timer:get_CurrentTimerSec())
    local ms    = string.format("%03d", timer:get_CurrentTimerMillSec())

    return string.format("%s:%s:%s", min, sec, ms)
end

local function add_bonus_time(secs)
    local timer = get_timer()
    timer:addBonusTime(tonumber(secs) + 0.0)
end

--endregion

--region Satiety

local function get_satiety_level()
    local birthday_game_master = get_singleton("app.BirthdayGameMaster")
    return birthday_game_master.SatietyLevel
end

local function format_satiety_level()
    local satiety_level = get_satiety_level()
    return tostring(satiety_level.SatietyLevelValue) .. "/" .. tostring(satiety_level.TargetSatietyLevel)
    -- SatietyLevelValue / TargetSatietyLevel
end

local function add_satiety_points(pts)
    get_satiety_level():addSatietyLevel(tonumber(pts) + 0.0)
end

--endregion

local secs = ""
local points = ""
local view_elapsed_time = false

re.on_draw_ui(function()
    if imgui.tree_node("Jack's 55th Birthday Trainer") then
        if imgui.tree_node("Game state") then
            imgui.text("Only do this while you're in the game!")
            imgui.spacing()

            if imgui.button("Force start") then
                get_singleton("app.BirthdayGameMaster"):notifyGameStart()
            end

            if imgui.button("Force end") then
                get_satiety_level():finishGame()
            end
            imgui.tree_pop()
        end

        if imgui.tree_node("Timer") then
            if view_elapsed_time then
                imgui.text("Elapsed time: " .. format_timer())
            end

            if imgui.button("Resume timer") then resume_timer() end
            if imgui.button("Pause timer") then pause_timer() end
            if imgui.button("Reset timer") then reset_timer() end

            imgui.spacing()

            imgui.set_next_item_width(130)
            _, secs = imgui.input_text("seconds", secs, 1 << 0)

            if imgui.button("Add bonus time") then
                add_bonus_time(secs)
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Jack's satiety") then
            imgui.text(format_satiety_level())

            _, get_satiety_level().goodJob = imgui.checkbox("Always good job", get_satiety_level().goodJob)

            imgui.set_next_item_width(130)
            _, points = imgui.input_text("points", points, 1 << 0)

            if imgui.button("Add satiety points") then
                add_satiety_points(points)
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Developer Tools") then
            _, view_elapsed_time = imgui.checkbox("View elapsed time", view_elapsed_time)
            imgui.tree_pop()
        end

        imgui.tree_pop()
    end
end)
