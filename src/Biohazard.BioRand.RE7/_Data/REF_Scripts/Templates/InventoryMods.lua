--[[
This script sets Ethan's and Mia's inventory size on initialization and prevents the game from reducing the inventory size afterwards.
]]

local function get_local_player()
    local object_man = sdk.get_managed_singleton("app.ObjectManager")
    if not object_man then return nil end
    return object_man:get_field("PlayerObj")
end

-- replaced via C# parameterization
local desired_inventory_size_ethan = %INVENTORY_LV_ETHAN%
local desired_inventory_size_mia   = %INVENTORY_LV_MIA%

local function get_desired_size_for_player(player_name)
    if not player_name then return nil end

    -- Ethan (Pl00...)
    if player_name:find("^Pl00") then
        return desired_inventory_size_ethan

    -- Mia (Pl2...)
    elseif player_name:find("^Pl2") then
        return desired_inventory_size_mia
    end

    return nil
end

local function set_extend_lv_if_needed(inventory, desired_lv)
    if not inventory or not desired_lv then return end

    local current_lv = inventory:get_field("_ExtendLv")

    if current_lv ~= desired_lv then
        inventory:setExtendLv(desired_lv)
    end
end

-- Hook inventory constructor
sdk.hook(
    sdk.find_type_definition("app.Inventory"):get_method(".ctor"),
    function(args)
        local inventory = sdk.to_managed_object(args[2])
        if not inventory then return end

        local player = get_local_player()
        if not player then return end

        local player_name = player:get_Name()
        local desired_lv = get_desired_size_for_player(player_name)

        set_extend_lv_if_needed(inventory, desired_lv)
    end
)

-- Prevent inventory shrinking
sdk.hook(
    sdk.find_type_definition("app.Inventory"):get_method("setExtendLv"),
    function(args)
        local inventory = sdk.to_managed_object(args[2])
        if not inventory then return end

        local new_lv = sdk.to_int64(args[3])

        local player = get_local_player()
        if not player then return end

        local desired_lv = get_desired_size_for_player(player:get_Name())
        if not desired_lv then return end

        if new_lv < desired_lv then
            return sdk.PreHookResult.SKIP_ORIGINAL
        end
    end
)