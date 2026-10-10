local Player = {}
Player.__index = Player

local SPIRIT_BLADE = 63
local HAND_AXE_BANK = 10

function Player.new(game, enabled, resource_root)
    return setmetatable({ game = game, enabled = enabled, resource_root = resource_root }, Player)
end

function Player:bank_for(controller, weapon_id)
    if weapon_id ~= SPIRIT_BLADE or not self.enabled() then return nil end
    local owner = controller:call("get_GameObject")
    if not owner or owner ~= self.game:player() or owner:call("get_Name") ~= "Pl0000" then return nil end
    local manager = self.game:singleton("app.ItemManager")
    local data = manager and manager:call("findItemData", "CH9_WP002")
    local prefab = data and data:get_field("ItemPrefab")
    local path = prefab and prefab:call("get_Path")
    if path and path:lower() == (self.resource_root .. "/CH9_WP002/Item.pfb"):lower() then
        return HAND_AXE_BANK
    end
end

function Player:install()
    if self.installed then return end
    self.installed = true
    -- Install before equip: changing the bank after entering an empty ReadyStart
    -- animation does not restart that animation or finish the weapon-change task.
    self.game:hook("app.PlayerMotionController", "getBankType(app.WeaponID)", function(args)
        local storage = thread.get_hook_storage()
        storage.dlc_weapon_bank = nil
        local id = sdk.to_int64(args[3])
        if id == SPIRIT_BLADE and self.enabled() then
            storage.dlc_weapon_bank = self:bank_for(self.game:object(args[2]), id)
        end
    end, function(retval)
        local storage = thread.get_hook_storage()
        local bank = storage.dlc_weapon_bank
        storage.dlc_weapon_bank = nil
        return bank and sdk.to_ptr(bank) or retval
    end)
end

return Player
