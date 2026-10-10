-- Experimental Ethan adapter. Kept separate from the campaign weapon allowlist.
local Gauntlet = {}
Gauntlet.__index = Gauntlet

local WEAPON, BANK = 67, 9910
local LAYERS = { 1, 2, 9 }
local AIM = { ["Melee.ReadyToAim"] = true, ["Melee.AimIdle"] = true,
    ["Melee.AimIdleSp"] = true, ["Melee.AimMove"] = true }
local BOTH = { ["Melee.ReadyStart"] = true, ["Melee.ReadyIdle"] = true,
    ["Melee.ReadyIdleSp"] = true, ["Melee.ReadyMove"] = true, ["Melee.ReadyJogStart"] = true,
    ["Melee.ReadyJogEnd"] = true, ["Melee.AttackL"] = true, ["Melee.AttackR"] = true,
    ["Melee.AttackLToReady"] = true, ["Melee.AttackRToReady"] = true,
    ["Melee.AimAttackC"] = true, ["Melee.AimToReady"] = true }
local COMBO = { { id = 2441, request = 0, source = 43 }, { id = 2641, request = 1, source = 40 },
    { id = 2443, request = 2, source = 45 }, { id = 2643, request = 6, source = 42 } }
local CHANGE = "changeMotion(System.UInt32, System.UInt32, System.Single, System.Single, via.motion.InterpolationMode, via.motion.InterpolationCurve)"
local REQUEST = "requestMotion(System.String, System.UInt32, System.Single, System.Single, app.PlayerMotionController.RequestPriority)"

function Gauntlet.new(game, enabled, root)
    return setmetatable({ game = game, enabled = enabled, root = root,
        resources = {}, combo = 0, track_indices = {} }, Gauntlet)
end

function Gauntlet:matches(player)
    if not player or player ~= self.game:player() or player:call("get_Name") ~= "Pl0000" then return false end
    local manager = self.game:singleton("app.ItemManager")
    local data = manager and manager:call("findItemData", "CH9_WP006")
    local prefab = data and data:get_field("ItemPrefab")
    local path = prefab and prefab:call("get_Path")
    return path ~= nil and path:lower() == (self.root .. "/CH9_WP006/Item.pfb"):lower()
end

function Gauntlet:resource(kind, path)
    local key = kind .. ":" .. path
    if self.resources[key] then return self.resources[key] end
    local resource = assert(sdk.create_resource(kind, path), "Missing gauntlet resource: " .. path):add_ref()
    local ok, holder = pcall(function()
        return assert(resource:create_holder(kind .. "Holder"), "Cannot create gauntlet resource holder"):add_ref()
    end)
    resource:release()
    if not ok then error(holder) end
    assert(holder:call("get_ResourcePath"):lower() == path:lower(), "Unexpected gauntlet resource")
    self.resources[key] = holder
    return holder
end

function Gauntlet:owns_banks()
    local s = self.session
    if not s or s.player ~= self.game:player() then return false end
    for i = 1, 3 do
        local entry = s.banks[i]
        if not entry then return false end
        local bank = s.motion:call("getDynamicMotionBank", entry.index)
        if bank ~= entry.bank or bank:call("get_BankID") ~= 0 or bank:call("get_BankType") ~= BANK then return false end
    end
    return true
end

function Gauntlet:prepare(player)
    if self.session and self.session.player == player then
        assert(self:owns_banks(), "Gauntlet motion banks changed ownership")
        return
    end
    self:reset()
    self.session = nil
    assert(self:matches(player), "Gauntlets require the matching Ethan lab prefab")
    local controller = assert(self.game:component(player, "app.PlayerMotionController"))
    local motion = assert(controller:get_field("Motion"))
    local existing = motion:call("findMotionBank(System.UInt32, System.UInt32)", 0, BANK)
    assert(not existing or existing:call("get_BankType") ~= BANK, "Gauntlet bank type is already occupied")
    local fallback = motion:call("findMotionBank(System.UInt32, System.UInt32)", 0, 10)
    assert(fallback and fallback:call("get_BankID") == 0 and fallback:call("get_BankType") == 10,
        "Ethan's axe fallback bank is unavailable")
    local holders = {
        self:resource("via.motion.MotionListResource", "CH9/Animation/Player/pl9000/motlist/pl9000_GauntletW.motlist"),
        self:resource("via.motion.MotionListResource", "CH9/Animation/Player/pl9000/motlist/pl9000_Knuckle.motlist"),
        fallback:call("get_MotionList"),
    }
    local scene = sdk.call_native_func(sdk.get_native_singleton("via.SceneManager"),
        sdk.find_type_definition("via.SceneManager"), "get_CurrentScene")
    local hands = {}
    for _, entry in ipairs({ { "Pl0000HandR", "pl9010" }, { "Pl0000HandL", "pl9020" } }) do
        local object = assert(scene:call("findGameObject(System.String)", entry[1]), "Missing Ethan hand")
        local parent, owned = object:call("get_Transform"), false
        for _ = 1, 32 do
            if not parent then break end
            if parent:call("get_GameObject") == player then owned = true; break end
            parent = parent:call("get_Parent")
        end
        assert(owned, "Hand renderer belongs to another player")
        local path = "CH9/Character/Player/pl9000/" .. entry[2] .. "/" .. entry[2]
        hands[#hands + 1] = { object = object, mesh = assert(self.game:component(object, "via.render.Mesh")),
            replacement = self:resource("via.render.MeshResource", path .. ".mesh"),
            material = self:resource("via.render.MeshMaterialResource", path .. ".mdf2") }
    end
    self.collider_track = self.collider_track or sdk.create_instance("app.Collision.ColliderTrack"):add_ref()
    self.charge_track = self.charge_track or sdk.create_instance("app.SequenceTrackObject.CH9PlayerGauntletChargeLevel"):add_ref()
    local s = { player = player, controller = controller, motion = motion, hands = hands, banks = {},
        sequence = assert(self.game:component(player, "app.PlayerSequenceManager")),
        manager = assert(controller:get_field("MotionManager")) }
    self.session = s
    -- Append only our isolated bank type. Never replace a campaign bank.
    for _, holder in ipairs(holders) do
        local bank = sdk.create_instance("via.motion.DynamicMotionBank"):add_ref()
        bank:call("set_MotionList", holder)
        bank:call("set_OverwriteBankID", true); bank:call("set_BankID", 0)
        bank:call("set_OverwriteBankType", true); bank:call("set_BankType", BANK)
        local index = motion:call("getDynamicMotionBankCount")
        motion:call("setDynamicMotionBankCount", index + 1)
        motion:call("setDynamicMotionBank", index, bank)
        s.banks[#s.banks + 1] = { index = index, bank = bank }
    end
end

function Gauntlet:clear_attack()
    if self.weapon and self.session and self.session.player == self.game:player()
        and self.game:valid(self.weapon:call("get_GameObject")) then
        for i = 0, 6 do self.collider:call("unregisterRequestSet(System.UInt32)", i) end
        self.weapon:call("offAttackTrigger")
    end
    self.active = false
end

function Gauntlet:reset()
    self:clear_attack()
    local s = self.session
    if s and s.player == self.game:player() then
        for _, hand in ipairs(s.hands) do
            if hand.original and self.game:valid(hand.object) then
                hand.mesh:call("setMesh", hand.original)
                hand.mesh:call("set_Material", hand.original_material)
                for i, value in ipairs(hand.parts) do hand.mesh:call("setPartsEnable", i - 1, value) end
            end
            hand.original, hand.original_material, hand.parts = nil, nil, nil
        end
    end
    self.weapon, self.collider, self.hit = nil, nil, nil
    self.attack, self.charge, self.last_state, self.controllable = nil, nil, nil, false
    self.combo = 0
    -- Banks belong to the live player until its destruction. Dropping them during
    -- a load callback or while the weapon is still equipped invalidates animations.
end

function Gauntlet:equip(weapon)
    self:reset()
    local s, game = self.session, self.game
    local object = weapon:call("get_GameObject")
    local item = game:component(object, "app.Item")
    assert(item and item:get_field("ItemDataID") == "CH9_WP006", "Unexpected gauntlet instance")
    local collider = assert(game:component(object, "via.physics.RequestSetCollider"))
    assert(collider:call("getNumCollidables(System.UInt32)", 6) > 0, "Gauntlet collider export is outdated")
    self.collider, self.hit = collider, assert(game:component(object, "app.Collision.HitController"))
    self.weapon = weapon
    local skeleton = game:component(object, "via.render.Mesh")
        or object:call("createComponent", sdk.typeof("via.render.Mesh"))
    local body = assert(game:component(s.player, "via.render.Mesh"))
    skeleton:call("set_DrawDefault", false)
    skeleton:call("setMesh", body:call("getMesh"))
    skeleton:call("set_Material", body:call("get_Material"))
    local transform = object:call("get_Transform")
    transform:call("set_LocalPosition", Vector3f.new(0, 0, 0))
    transform:call("set_LocalRotation", Quaternion.new(0, 0, 0, 1))
    assert(weapon:get_field("EquipParam"):get_field("JointName") == "", "Unexpected gauntlet attachment")
    transform:call("set_ParentJoint", "")
    transform:call("set_SameJointsConstraint", true)
    for _, hand in ipairs(s.hands) do
        hand.original, hand.original_material = hand.mesh:call("getMesh"):add_ref(), hand.mesh:call("get_Material"):add_ref()
        hand.parts = {}
        for i = 0, hand.mesh:call("getPartsEnableCount") - 1 do
            hand.parts[#hand.parts + 1] = hand.mesh:call("getPartsEnable", i)
        end
        hand.mesh:call("setMesh", hand.replacement)
        hand.mesh:call("set_Material", hand.material)
        for i = 0, 4 do hand.mesh:call("setPartsEnable", i, i == 2 or i == 3) end
    end
end

function Gauntlet:change_clip(id, frame)
    for _, index in ipairs(LAYERS) do
        self.session.motion:call("getLayer", index):call(CHANGE, 0, id, frame or 0.0, 4.0, 2, 1)
    end
end

function Gauntlet:request(name)
    self.session.controller:call(REQUEST, name, 1, 0.0, 4.0, 0)
end

function Gauntlet:read_track(node, kind, destination)
    local id = node:call("get_MotionID")
    local key = tostring(id) .. kind
    local index = self.track_indices[key]
    if index == nil then
        index = false
        for i = 0, node:call("get_SequenceTracksCount") - 1 do
            local type = node:call("getSequenceTracksTypeinfo(System.UInt32)", i)
            if type and type:call("get_FullName") == kind then index = i; break end
        end
        self.track_indices[key] = index
    end
    if index == false then return false end
    destination:call("initialize", 1)
    return node:call("getSequenceTracks(System.UInt32, via.motion.Tracks)", index, destination)
end

function Gauntlet:update_motion(name, layer)
    local ordinary = name == "Melee.AttackL" or name == "Melee.AttackR"
    if name ~= self.last_state then
        self:clear_attack()
        self.attack = (ordinary or name == "Melee.AimAttackC") and { pending = true } or nil
        if name == "Melee.ReadyToAim" then self.charge = { id = 2688, frame = 0.0, level = 0 }
        elseif not AIM[name] and name ~= "Melee.AimAttackC" then self.charge = nil end
        self.last_state = name
    end
    if AIM[name] and self.charge then
        local charge, id = self.charge, layer:call("get_MotionID")
        if id >= 2200 and id <= 2208 then self:change_clip(charge.id, charge.frame) end
        if layer:call("get_MotionID") == charge.id then
            charge.frame = layer:call("get_Frame")
            for i = 0, layer:call("getRawMotionNodeCount") - 1 do
                local node = layer:call("getRawMotionNode", i)
                if node:call("get_MotionID") == charge.id and self:read_track(node,
                    "app.SequenceTrackObject.CH9PlayerGauntletChargeLevel", self.charge_track) then
                    if self.charge_track:get_field("IsChargeLevel2") then charge.level = 2
                    elseif self.charge_track:get_field("IsChargeLevel1") then charge.level = math.max(charge.level, 1) end
                end
            end
            if charge.id == 2688 and layer:call("get_StateEndOfMotion") then
                charge.id, charge.frame = 2689, 0.0
                self:change_clip(2689)
                self:request("Melee.AimIdle")
            end
        end
    end
    local attack, id = self.attack, layer:call("get_MotionID")
    if attack and attack.pending then
        if name == "Melee.AimAttackC" and id == 2407 then
            local strong = self.charge and self.charge.level == 2
            self.attack = { id = strong and 2691 or 2690, request = strong and 5 or 4,
                source = strong and 33 or 32, charged = true }
            self.charge, self.combo = nil, 0
        elseif ordinary and id == (name == "Melee.AttackL" and 2400 or 2401) then
            self.combo = self.combo % #COMBO + 1
            local entry = COMBO[self.combo]
            self.attack = { id = entry.id, request = entry.request, source = entry.source }
        end
        if self.attack.id then self:change_clip(self.attack.id) end
    end
    attack = self.attack
    local active = false
    if attack and attack.id and not attack.finished and not attack.interrupted then
        for i = 0, layer:call("getRawMotionNodeCount") - 1 do
            local node = layer:call("getRawMotionNode", i)
            if node:call("get_MotionID") == attack.id and node:call("get_Weight") > 0.5
                and self:read_track(node, "app.Collision.ColliderTrack", self.collider_track) then
                active = active or self.collider_track:get_field("RequestId") == attack.source
            end
        end
    end
    if active and not self.active then self.weapon:call("onAttackTrigger"); self.active = true
    elseif not active and self.active then self:clear_attack() end
    if active then self.hit:call("requestCollider", attack.request) end
    if attack and attack.id and not attack.finished and layer:call("get_MotionID") == attack.id
        and layer:call("get_StateEndOfMotion") then
        self:clear_attack()
        attack.finished = true
        self:request(attack.charged and "Melee.AimToReady" or name .. "ToReady")
    end
end

function Gauntlet:update()
    local player = self.game:player()
    if not self.enabled() or self.error or not self:matches(player) then self:reset(); return end
    self:prepare(player)
    local s = self.session
    local weapon = self.game:component(player, "app.EquipManager"):call("get_equipWeaponRight")
    if not weapon or weapon:get_field("WeaponID") ~= WEAPON then self:reset(); return end
    if self.weapon ~= weapon then self:equip(weapon) end
    local manager = self.game:singleton("app.GameManager")
    local damage = self.game:component(player, "app.PlayerDamageController")
    local owner = s.manager:get_field("OwnerTask")
    self.controllable = manager and not manager:call("get_IsPause") and not manager:call("get_IsSceneLoading")
        and damage and damage:call("get_health") > 0 and owner ~= nil and s.manager:get_field("CurrentTask") == owner
    if not self.controllable then
        self:clear_attack()
        if self.attack then self.attack.interrupted = true end
        return
    end
    self:update_motion(s.manager:call("getCurrentMotionFsmStateName", 1, false), s.motion:call("getLayer", 1))
end

function Gauntlet:scope(controller)
    local s = self.session
    return s and self.enabled() and not self.error and s.player == self.game:player() and controller == s.controller
        and controller:get_field("CurrentWeaponID") == WEAPON
end

function Gauntlet:install()
    if self.installed then return end
    self.installed = true
    local bank_key, sequence_key, tag_key = {}, {}, {}
    self.game:hook("app.PlayerMotionController", "getBankType(app.WeaponID)", function(args)
        thread.get_hook_storage()[bank_key] = nil
        if sdk.to_int64(args[3]) ~= WEAPON then return end
        local controller = self.game:object(args[2])
        if self.session and controller == self.session.controller and self:owns_banks() then
            thread.get_hook_storage()[bank_key] = BANK
        end
    end, function(ret)
        local storage = thread.get_hook_storage()
        local bank = storage[bank_key]; storage[bank_key] = nil
        return bank and sdk.to_ptr(bank) or ret
    end)
    self.game:hook("app.PlayerMotionController", "updateLArmMotion()", function(args)
        local controller = self.game:object(args[2])
        if not self:scope(controller) then return end
        local work = controller:get_field("MotionWorks"):get_element(1)
        local name = work:get_field("StateName")
        if not BOTH[name] and not AIM[name] then return end
        if work:get_field("IsSet") then
            controller:call("setMotionWorkCore", name, work:get_field("StartFrame"), work:get_field("InterpolationFrame"),
                work:get_field("InterpolationMode"), work:get_field("InterpolationCurve"), work:get_field("Priority"), 2)
            local left = controller:get_field("MotionWorks"):get_element(2)
            if left:get_field("IsSet") then
                controller:get_field("MotionFsm"):call("setCurrentStateFullName(System.String, System.UInt32, System.Single, System.Single, via.motion.InterpolationMode, via.motion.InterpolationCurve)",
                    left:get_field("StateName"), 2, left:get_field("StartFrame"), left:get_field("InterpolationFrame"),
                    left:get_field("InterpolationMode"), left:get_field("InterpolationCurve"))
            end
        end
        controller:call("set_isBothHands", true)
        return sdk.PreHookResult.SKIP_ORIGINAL
    end, function(ret) return ret end)
    self.game:hook("app.PlayerSequenceManager", "updateActionTrack()", function(args)
        local s = self.session
        thread.get_hook_storage()[sequence_key] = s and self.weapon and self.controllable
            and self:scope(s.controller) and self.game:object(args[2]) == s.sequence
    end, function(ret)
        local storage = thread.get_hook_storage()
        local scoped = storage[sequence_key]; storage[sequence_key] = nil
        if scoped then
            local s = self.session
            local name = s.manager:call("getCurrentMotionFsmStateName", 1, false)
            if name == "Melee.ReadyIdle" or name == "Melee.ReadyIdleSp" or name == "Melee.ReadyMove" then
                s.sequence:set_field("IsAimAccepted", true)
            elseif AIM[name] then
                s.sequence:set_field("IsAimCancelAccepted", true)
                s.sequence:set_field("IsAttackAccepted", true)
            end
        end
        return ret
    end)
    self.game:hook("app.MotionDelegateTagManager", "addTagFromMotion", function(args)
        local s = self.session
        thread.get_hook_storage()[tag_key] = s and self.weapon and self.controllable and self:scope(s.controller)
            and self.game:object(args[2]) == s.manager:get_field("TagManager") and sdk.to_int64(args[3]) == 1
    end, function(ret)
        local storage = thread.get_hook_storage()
        local scoped = storage[tag_key]; storage[tag_key] = nil
        if scoped then
            local s = self.session
            local id = s.motion:call("getLayer", 1):call("get_MotionID")
            if (id == 2688 or id == 2689) and AIM[s.manager:call("getCurrentMotionFsmStateName", 1, false)] then
                self.aim_tag = self.aim_tag or self.game:static_field("app.PlayerDefine.MotionTag", "MeleeAimIdle")
                s.manager:get_field("TagManager"):call("addTag(System.Int32, System.UInt32, System.Type)",
                    1, self.aim_tag, sdk.typeof("app.PlayerMelee"))
            end
        end
        return ret
    end)
end

return Gauntlet
