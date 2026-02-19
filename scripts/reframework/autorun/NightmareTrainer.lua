if reframework:get_game_name() ~= "re7" then
    re.msg("[Nightmare Trainer] Only compatible with RE7!")
    return
end

local has_warned = false
local function get_singleton(name)
    local s = sdk.get_managed_singleton(name)
    if not s and not has_warned then
        re.msg("[Nightmare Trainer] Did not find singleton " .. name .. ", are you inside a Nightmare game?")
        has_warned = true
    end
    return s
end

local function give_scrap()
    local playerJunkPartsMngr = get_singleton("app.PlayerJunkPartsManager")
    playerJunkPartsMngr:set_JunkPartsCount(99999)
    playerJunkPartsMngr:set_InitialJunkPartsCount(99999)
    playerJunkPartsMngr:set_CurrentJunkPartsCount(99999)
end

local instaKillEnemies = false
sdk.hook(
    sdk.find_type_definition("app.EnemyGeneratorManager"):get_method("requestSpawn"),
    function(args)
        if not instaKillEnemies then
            return
        end

        local mngr = sdk.to_managed_object(args[2])
        local spawnInfo = sdk.to_managed_object(args[3])
        mngr:requestKill(spawnInfo)
    end,
    function(retval) return retval end
)

re.on_draw_ui(function()
    if imgui.tree_node("Nightmare Trainer") then
        if imgui.tree_node("Scrap") then
            if imgui.button("Set 99999 scrap (maximum)") then
                give_scrap()
            end

            imgui.text("Note: Huge values will result in an overflow.")
            local changed, scrap = imgui.input_text("scrap", scrap, 1 << 0) -- Allow 0123456789.+-*/

            if changed then
                local playerJunkPartsMngr = get_singleton("app.PlayerJunkPartsManager")
                playerJunkPartsMngr:set_JunkPartsCount(tonumber(scrap))
                playerJunkPartsMngr:set_InitialJunkPartsCount(tonumber(scrap))
                playerJunkPartsMngr:set_CurrentJunkPartsCount(tonumber(scrap))
            end

            imgui.tree_pop()
        end

        if imgui.tree_node("Miscellaneous") then
            _, instaKillEnemies = imgui.checkbox("Instantly kill enemies upon spawn", instaKillEnemies)

            if imgui.button("Unlock all skills") then
                give_scrap()

                local craftSkillMngr = get_singleton("app.CraftSkillManager")
                local playerGrowthMngr = craftSkillMngr._PlayerGrowth
                playerGrowthMngr.RecoveryLevel = 2
                playerGrowthMngr.HealthLevel = 5
                playerGrowthMngr.MoveSpeedLevel = 2
                playerGrowthMngr.ReloadSpeedLevel = 2

                for _ = 0, 5 do
                    craftSkillMngr:tryCustomizeCrusher()

                    for i = 0, 7 do
                        craftSkillMngr:tryCustomize(i)
                    end
                end
            end

            if imgui.button("Instant restart") then
                local otherRestartControl = get_singleton("app.OtherRestartControl")
                otherRestartControl:requestRestart()
            end
            imgui.tree_pop()
        end

        if imgui.tree_node("Developer Tools") then
            local _, groupId = imgui.input_text("Enemy group ID")
            if imgui.button("Request kill") then
                local enemyGeneratorManager = get_singleton("app.EnemyGeneratorManager")
                enemyGeneratorManager:requestAllKill(groupId)
            end
            imgui.tree_pop()
        end

        imgui.tree_pop()
    end
end)
