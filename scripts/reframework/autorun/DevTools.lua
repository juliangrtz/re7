local re7utils = require("utility/RE7Utils")
local freezeAmmo = false
local ChapterNo = {
    BootLogo = 0,
    FirstMenu = 1,
    Chapter0 = 2,
    Title = 3,
    Chapter1 = 4,
    Chapter3 = 5,
    Chapter4 = 6,
    FF000 = 7,
    FF010 = 8,
    FF020 = 9,
    FF030 = 10,
    FF040 = 11,
    FF050 = 12,
    Chapter123 = 13,
    Chapter324 = 14,
    OpeningMovie = 15,
    OpeningCar = 16,
    EndingMovie = 17,
    VRTutorial = 18,
    NoChapter = 19,
    BirthdayMain = 20,
    BirthdayTitle = 21,
    BirthdayStage1 = 22,
    BirthdayStage2 = 23,
    BirthdayStage3 = 24,
    BirthdayStage4 = 25,
    BirthdayResult = 26,
    EndCard = 27,
    Chapter7Title = 28,
    Chapter7_1 = 29,
    Chapter7_2 = 30,
    Chapter7_3 = 31,
    Chapter7_4 = 32,
    Chapter3_IMD_Title = 33,
    Chapter3_IMD = 34,
    Chapter8 = 35,
    Chapter7_Intro_Movie = 36,
    Chapter9 = 37,
};

local ChapterNames = {}
for k, v in pairs(ChapterNo) do
    ChapterNames[v] = k
end

sdk.hook(
    sdk.find_type_definition("app.WeaponGun"):get_method("set_loadNum(System.Int32)"),
    function(_) if freezeAmmo then return sdk.PreHookResult.SKIP_ORIGINAL end end,
    function(r) return r end
)

re.on_draw_ui(function()
    if imgui.tree_node("Developer Tools") then
        _, freezeAmmo = imgui.checkbox("Freeze ammo", freezeAmmo)

        --[[         if imgui.button("Copy player position to clipboard") then
            local player = re7utils.get_localplayer()
            if not player then return end
            sdk.copy_to_clipboard(re7utils.vec3tostring(player:get_Transform():get_Position()))
            log.debug("Copied position to clipboard")
        end ]]

        if imgui.button("Log player position") then
            local player = re7utils.get_localplayer()
            if not player then return end
            log.debug(re7utils.vec3tostring(player:get_Transform():get_Position()))
        end

        if imgui.button("Log current chapter number") then
            local gameMngr = sdk.get_managed_singleton("app.GameManager")
            log.debug(gameMngr._CurrentChapter .. " (" .. ChapterNames[gameMngr._CurrentChapter] .. ")")
        end

        if imgui.button("Clear debug console") then
            re7utils.clearDebugConsole()
        end

        imgui.tree_pop()
    end
end)