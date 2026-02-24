--[[
This script is needed
A) to increase the original slot size of the combine GUI from 8 to 20 and
B) to bypass internal restrictions of the combine GUI that filter certain items and recipes.

TODO:
- allow mouse usage for additional recipes
- fix icon glitches for items that take more than one slot
]]

sdk.hook(
    sdk.find_type_definition("app.InventoryMenu.DictionaryCombineUIController"):get_method("deactivate"),
    function(args)
        local this = sdk.to_managed_object(args[2])
        this.RowNum = 5 -- More is not possible. Yet.
    end,
    function(r) return r end
)

local function returnTrue(name, fn)
sdk.hook(
    sdk.find_type_definition(name):get_method(fn),
    function(args)
    end,
    function(retval)
        return sdk.to_ptr(true)
    end
)
end

returnTrue("app.InventoryMenu", "DictionaryCombine_UnlockedCombine(app.ItemCombineData.Data)")
