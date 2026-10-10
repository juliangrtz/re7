return function()
    local Gauntlet = require("BioRand7/dlc_gauntlet")
    local function object(fields, calls)
        return { get_field = function(_, key) return fields[key] end,
            set_field = function(_, key, value) fields[key] = value end,
            add_ref = function(self) return self end,
            call = function(_, method, ...)
                assert(calls[method], "Unexpected call: " .. method)
                return calls[method](...)
            end }
    end
    local enabled, name, path = true, "Pl0000", "BioRand/DlcWeaponLab/CH9_WP006/Item.pfb"
    local player = object({}, { get_Name = function() return name end })
    local current_player = player
    local data = object({ ItemPrefab = object({}, { get_Path = function() return path end }) }, {})
    local items = object({}, { findItemData = function(id) assert(id == "CH9_WP006"); return data end })
    local hooks, storage = {}, {}
    local paused, loading, health = false, false, 500
    local manager = object({}, { get_IsPause = function() return paused end, get_IsSceneLoading = function() return loading end })
    local damage = object({}, { get_health = function() return health end })
    local current_weapon
    local equip = object({}, { get_equipWeaponRight = function() return current_weapon end })
    local game = {
        player = function() return current_player end,
        valid = function() return true end,
        singleton = function(_, kind) return kind == "app.ItemManager" and items or manager end,
        component = function(_, owner, kind)
            assert(owner == player)
            return kind == "app.EquipManager" and equip or kind == "app.PlayerDamageController" and damage
        end,
        object = function(_, value) return value end,
        hook = function(_, kind, method, pre, post) hooks[kind .. ":" .. method] = {pre, post} end,
    }
    local adapter = Gauntlet.new(game, function() return enabled end, "BioRand/DlcWeaponLab")
    assert(adapter:matches(player))
    name = "Pl9000"; assert(not adapter:matches(player)); name = "Pl0000"
    path = "BioRand/DlcWeapons/CH9_WP006/Item.pfb"; assert(not adapter:matches(player))
    path = "BioRand/DlcWeaponLab/CH9_WP006/Item.pfb"
    assert(not adapter:matches({}) and not adapter:matches(nil))

    local creations, releases, refs, fail = 0, 0, 0, false
    sdk = { to_int64 = function(value) return value end, to_ptr = function(value) return value end,
        PreHookResult = { SKIP_ORIGINAL = "skip" },
        create_resource = function(kind, resource_path)
            creations = creations + 1
            return { add_ref = function(self) refs = refs + 1; return self end,
                release = function() releases = releases + 1 end,
                create_holder = function(_, holder_kind)
                    assert(holder_kind == kind .. "Holder")
                    if fail then error("holder failed") end
                    return object({}, { get_ResourcePath = function() return resource_path end })
                end }
        end }
    thread = { get_hook_storage = function() return storage end }
    local resource = adapter:resource("Resource", "test/path")
    assert(adapter:resource("Resource", "test/path") == resource and creations == 1 and releases == 1 and refs == 1)
    fail = true
    assert(not pcall(function() adapter:resource("Resource", "other/path") end))
    assert(releases == 2 and not adapter.resources["Resource:other/path"], "Release temporary resource on failure")

    local motion_id, ended, frame, source, charge_level = 2001, false, 0.0, -1, 0
    local change_count, on_count, off_count, collider_requests, cleared, returns = 0, 0, 0, {}, {}, {}
    local node = object({}, {
        get_MotionID = function() return motion_id end, get_Weight = function() return 1.0 end,
        get_SequenceTracksCount = function() return 2 end,
        ["getSequenceTracksTypeinfo(System.UInt32)"] = function(index)
            return object({}, { get_FullName = function() return index == 0 and "app.Collision.ColliderTrack" or "app.SequenceTrackObject.CH9PlayerGauntletChargeLevel" end })
        end,
        ["getSequenceTracks(System.UInt32, via.motion.Tracks)"] = function(index, destination)
            if index == 0 then destination:set_field("RequestId", source)
            else destination:set_field("IsChargeLevel1", charge_level == 1); destination:set_field("IsChargeLevel2", charge_level == 2) end
            return true
        end,
    })
    local layer = object({}, {
        get_MotionID = function() return motion_id end, get_StateEndOfMotion = function() return ended end,
        get_Frame = function() return frame end, getRawMotionNodeCount = function() return 1 end,
        getRawMotionNode = function() return node end,
        ["changeMotion(System.UInt32, System.UInt32, System.Single, System.Single, via.motion.InterpolationMode, via.motion.InterpolationCurve)"] = function(bank, id, start, interpolation)
            assert(bank == 0 and math.type(start) == "float" and math.type(interpolation) == "float")
            motion_id, frame, ended = id, start, false
            change_count = change_count + 1
        end,
    })
    local banks = {}
    for i = 1, 3 do banks[i] = {index = i, bank = object({}, { get_BankID = function() return 0 end, get_BankType = function() return 9910 end })} end
    local motion = object({}, { getLayer = function() return layer end,
        getDynamicMotionBank = function(index) return banks[index] and banks[index].bank end })
    local state_name = "Melee.ReadyIdle"
    local task = {}
    local manager_fields = { OwnerTask = task, CurrentTask = task }
    local motion_manager = object(manager_fields, { getCurrentMotionFsmStateName = function() return state_name end })
    local controller_fields = { CurrentWeaponID = 67 }
    local controller = object(controller_fields, {
        ["requestMotion(System.String, System.UInt32, System.Single, System.Single, app.PlayerMotionController.RequestPriority)"] = function(state, index, start, interpolation, priority)
            assert(index == 1 and priority == 0 and math.type(start) == "float" and math.type(interpolation) == "float")
            returns[#returns + 1] = state
        end,
    })
    local weapon = object({ WeaponID = 67 }, {
        get_GameObject = function() return {} end,
        onAttackTrigger = function() on_count = on_count + 1 end,
        offAttackTrigger = function() off_count = off_count + 1 end,
    })
    current_weapon, adapter.weapon = weapon, weapon
    adapter.collider = object({}, { ["unregisterRequestSet(System.UInt32)"] = function(index) cleared[index] = true end })
    adapter.hit = object({}, { requestCollider = function(index) collider_requests[#collider_requests + 1] = index end })
    adapter.collider_track = object({}, { initialize = function() end })
    adapter.charge_track = object({}, { initialize = function() end })
    adapter.session = { player = player, motion = motion, controller = controller, manager = motion_manager, banks = banks, hands = {} }
    assert(adapter:owns_banks())
    adapter:prepare(player)
    adapter:install(); adapter:install()
    local bank_hook = hooks["app.PlayerMotionController:getBankType(app.WeaponID)"]
    bank_hook[1]({nil, controller, 67}); assert(bank_hook[2](10) == 9910 and next(storage) == nil)
    bank_hook[1]({nil, controller, 1}); assert(bank_hook[2](10) == 10)
    bank_hook[1]({nil, {}, 67}); assert(bank_hook[2](10) == 10)
    assert(adapter:scope(controller))
    enabled = false; assert(not adapter:scope(controller)); enabled = true
    current_player = nil; assert(not adapter:owns_banks() and not adapter:scope(controller)); current_player = player

    local function update(name, id)
        state_name, motion_id, ended = name, id or motion_id, false
        adapter:update()
    end
    local expected = { {2441, 0, 43}, {2641, 1, 40}, {2443, 2, 45}, {2643, 6, 42} }
    for _, entry in ipairs(expected) do
        update("Melee.ReadyIdle", 2001)
        source = -1
        update("Melee.AttackL", 2400)
        assert(motion_id == entry[1] and adapter.attack.request == entry[2] and not adapter.active)
        source = 999; adapter:update(); assert(not adapter.active, "Only the matching native hit track may activate damage")
        source = entry[3]; adapter:update(); adapter:update()
        assert(adapter.active and collider_requests[#collider_requests] == entry[2])
        source = -1; adapter:update(); assert(not adapter.active and cleared[6])
        ended = true; adapter:update(); adapter:update()
        assert(returns[#returns] == "Melee.AttackLToReady")
    end
    assert(#returns == 4 and on_count == 4 and change_count == 12, "One finite completion per punch; both arms and linked layer")

    update("Melee.ReadyIdle", 2001)
    update("Melee.ReadyToAim", 2205)
    assert(motion_id == 2688)
    charge_level = 2; adapter:update(); assert(adapter.charge.level == 2)
    ended = true; adapter:update(); assert(motion_id == 2689 and returns[#returns] == "Melee.AimIdle")
    update("Melee.AimIdle", 2200); assert(motion_id == 2689 and adapter.charge.level == 2)
    update("Melee.AimAttackC", 2407)
    assert(motion_id == 2691 and adapter.attack.request == 5 and not adapter.charge)
    source = 33; adapter:update(); assert(adapter.active)
    paused = true; adapter:update(); assert(not adapter.active and adapter.attack.interrupted)
    paused = false; adapter:update(); assert(not adapter.active, "Resuming an interrupted damage window must not hit again")
    ended = true; adapter:update(); assert(returns[#returns] == "Melee.AimToReady")
    update("Melee.ReadyIdle", 2001)
    charge_level = 0; update("Melee.ReadyToAim", 2205)
    update("Melee.AimAttackC", 2407); assert(motion_id == 2690 and adapter.attack.request == 4)
    source = 32; adapter:update(); assert(adapter.active)
    manager_fields.CurrentTask = {}; adapter:update(); assert(not adapter.active and not adapter.controllable)
    manager_fields.CurrentTask = task
    health = 0; adapter:update(); assert(not adapter.controllable)
    health, loading = 500, true; adapter:update(); assert(not adapter.controllable)
    loading, manager_fields.OwnerTask = false, nil; adapter:update(); assert(not adapter.controllable)
    manager_fields.OwnerTask = task
    local old_session = adapter.session
    adapter:reset(); assert(not adapter.weapon and not adapter.attack and not adapter.charge and adapter.session == old_session)
    assert(adapter:owns_banks(), "Do not remove banks while the native player may still refer to them")
    banks[2] = nil
    assert(not adapter:owns_banks())
    assert(not pcall(function() adapter:prepare(player) end), "Never silently reappend after ownership loss")
end
