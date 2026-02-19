local changeSpeed = false
local speed = 2.0

local function hook(clazz, func, pre, post)
    sdk.hook(
        sdk.find_type_definition(clazz):get_method(func),
        pre,
        post
    )
end

-- Generic enemy animation speed
hook(
    "app.EnemyActionController",
    "get_latestAnimationSpeedRateForRank",
    nil,
    function(retval)
        if changeSpeed then
            local original = sdk.to_float(retval)
            return sdk.float_to_ptr(original * speed)
        else
            return retval
        end
    end
)

-- Evie Shock Waves
--[[
Em3500Shell
1 = via.physics.RequestSetCollider
2 = app.Collision.HitController
3 = app.Em3500Shell
4 = app.Collision.CalculateAttack
5 = app.EffectSphereCollider
]]
-- local didIt = false
-- hook(
--     "app.Collision.HitController",
--     "registerDamageHistory(via.GameObject, app.Collision.AttackUserData)",
--     function(args)
--         if didIt then return end
--         didIt = true
--         local g = sdk.to_managed_object(args[3])
--         local c = get_components(g)
--         for i = 1, #c do
--             log.debug(i .. " = " .. c[i]:get_type_definition():get_full_name())
--         end
--     end,
--     nil
-- )

-- local em3500Shell
-- local simpleEffectContainer
-- hook(
--     "app.Em3500Shell.<>c__DisplayClass3_0",
--     "<doStart>b__0(app.ISimpleEffectContainer)",
--     function(args)
--         em3500Shell = sdk.to_managed_object(args[2])
--         simpleEffectContainer = sdk.to_managed_object(args[3])
--         log.debug("Got Em3500Shell")
--     end,
--     nil
-- )

-- Evie Phase 1
hook(
    "app.Em8900Think.FaceInfo",
    "updateMotionSpeed",
    function(args)
        local original = sdk.to_float(args[3])
        args[3] = sdk.float_to_ptr(original * speed)
    end,
    nil
)

hook(
    "app.Em8900Think.TentacleInfo",
    "updateMotionSpeed",
    function(args)
        local original = sdk.to_float(args[3])
        args[3] = sdk.float_to_ptr(original * speed)
    end,
    nil
)

-- Evie Phase 2
local Em8950ActionController
local isPhase2 = false

hook(
    "app.Em8950ActionController",
    "doStart",
    function(args)
        Em8950ActionController = sdk.to_managed_object(args[2])
    end,
    nil
)

hook(
    "app.Em8940ActionController",
    "processLastBossFootWork",
    function(_)
        isPhase2 = true
    end,
    nil
)

hook(
    "app.Em8940ActionController",
    "doUpdate",
    nil,
    function(_)
        if Em8950ActionController and isPhase2 then
            Em8950ActionController.MotionManager.MotionPlaySpeed = speed
        end
    end
)

re.on_draw_ui(function()
    if imgui.tree_node("Enemy Speed Changer") then
        imgui.text("Made for uhTrance <3")

        imgui.text("Whether to change the speed of enemies.")
        _, changeSpeed = imgui.checkbox("Change speed", changeSpeed)

        imgui.text("Common values")

        if imgui.button("Speed x0.5") then speed = 0.5 end
        if imgui.button("Speed x1.0") then speed = 1 end
        if imgui.button("Speed x1.5") then speed = 1.5 end
        if imgui.button("Speed x2.0") then speed = 2.0 end

        imgui.text("Custom value")
        _, speed = imgui.slider_float("x", speed, 0.1, 10.0, nil)

        if imgui.button("(Debug) Print rank") then
            local signature = "getGameRank()"
            local gameMngr = sdk.get_managed_singleton("app.GameManager")
            local rank = gameMngr:call(signature)
            log.debug("Rank: " .. rank)
        end

        if imgui.button("(Debug) Print speed") then
            log.debug("Speed: " .. speed)
        end

        imgui.tree_pop()
    end
end)
