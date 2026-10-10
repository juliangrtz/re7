return function()
    local Weapons = require("BioRand7/dlc_weapons")
    local enabled, allow, available, ready, foreign, fail = false, true, false, false, false, false
    local calls, loads, errors, now = 0, 0, 0, 0
    os.clock = function() return now end
    local manager = { call = function(_, method, id)
        assert(method == "findItemData")
        calls = calls + 1
        if not available then return end
        return { get_field = function(_, name)
            assert(name == "ItemPrefab")
            return { call = function(_, name, value)
                if name == "get_Path" then return foreign and "CH8/Weapon.pfb" or "BioRand/DlcWeapons/" .. id .. "/Item.pfb" end
                if name == "get_Ready" then return ready end
                assert(name == "set_Standby" or name == "set_Path")
                loads = loads + 1
                if fail then error("load failure") end
            end }
        end }
    end }
    local context = {
        config = { get = function(_, key) if key == "dlc-campaign-weapons" then return enabled else return allow end end },
        game = { singleton = function(_, name) assert(name == "app.ItemManager"); return manager end },
        log = { error = function() errors = errors + 1 end },
    }
    local weapons = Weapons.new(context)
    weapons:update(); assert(calls == 0)
    enabled, allow = true, false
    weapons:update(); assert(calls == 0)
    allow = true
    weapons:update(); assert(calls == 11 and loads == 0)
    available, now = true, 1
    weapons:update(); assert(loads == 33)
    now = 3; weapons:update(); assert(loads == 33 and calls == 22)
    weapons:reset(); ready = true
    weapons:update(); assert(loads == 33)
    weapons:reset(); ready, foreign = false, true
    weapons:update(); assert(loads == 33)
    weapons:reset(); foreign, fail = false, true
    weapons:update(); assert(loads == 44 and errors == 11)
    now = 5; weapons:update(); assert(loads == 44, "Failed mutations must not retry every frame")

    local module_name = "BioRand7/dlc_weapon_player"
    local previous = package.loaded[module_name]
    local gauntlet_name = "BioRand7/dlc_gauntlet"
    local previous_gauntlet = package.loaded[gauntlet_name]
    local grenade_name = "BioRand7/dlc_grenade"
    local previous_grenade = package.loaded[grenade_name]
    local grenade_installed, grenade_updated, grenade_reset, grenade_enabled = 0, 0, 0
    package.loaded[grenade_name] = { new = function(game, is_enabled, root)
        assert(game == context.game and root == "BioRand/DlcWeapons")
        grenade_enabled = is_enabled
        return {
            install = function() grenade_installed = grenade_installed + 1 end,
            update = function(self)
                grenade_updated = grenade_updated + 1
                if not self.error then error("grenade failure") end
            end,
            reset = function() grenade_reset = grenade_reset + 1 end,
        }
    end }
    local gauntlet_installed, gauntlet_updated, gauntlet_reset, gauntlet_enabled = 0, 0, 0
    package.loaded[gauntlet_name] = { new = function(game, is_enabled, root)
        assert(game == context.game and root == "BioRand/DlcWeapons")
        gauntlet_enabled = is_enabled
        return {
            install = function() gauntlet_installed = gauntlet_installed + 1 end,
            update = function() gauntlet_updated = gauntlet_updated + 1; error("gauntlet failure") end,
            reset = function() gauntlet_reset = gauntlet_reset + 1 end,
        }
    end }
    local installed, updated, reset = 0, 0, 0
    local adapter_enabled
    package.loaded[module_name] = { new = function(game, is_enabled, root)
        assert(game == context.game and root == "BioRand/DlcWeapons")
        adapter_enabled = is_enabled
        return {
            install = function() installed = installed + 1 end,
            update = function() updated = updated + 1; error("adapter failure") end,
            reset = function() reset = reset + 1 end,
        }
    end }
    weapons:install(); weapons:install()
    assert(installed == 1 and adapter_enabled())
    assert(gauntlet_installed == 1 and gauntlet_enabled())
    assert(grenade_installed == 1 and grenade_enabled())
    weapons:update(); weapons:update()
    assert(updated == 1 and reset == 1 and not adapter_enabled(), "Adapter failures must stop until reset")
    assert(gauntlet_updated == 1 and gauntlet_reset == 1 and not gauntlet_enabled())
    assert(grenade_updated == 2 and grenade_reset == 1 and not grenade_enabled() and weapons.grenade_adapter.error,
        "Failed grenade controllers still drain deferred native pool cleanup")
    weapons:reset()
    assert(reset == 2 and adapter_enabled(), "New sessions reset adapter state without reinstalling hooks")
    assert(gauntlet_reset == 2 and gauntlet_enabled())
    assert(grenade_reset == 2 and grenade_enabled() and not weapons.grenade_adapter.error)
    enabled = false
    assert(not adapter_enabled())
    assert(not gauntlet_enabled())
    assert(not grenade_enabled())
    enabled, allow = true, false
    assert(not adapter_enabled())
    package.loaded[module_name] = previous
    package.loaded[gauntlet_name] = previous_gauntlet
    package.loaded[grenade_name] = previous_grenade
end
