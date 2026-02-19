if reframework:get_game_name() ~= "re7" then
    re.msg("[Phone Call Skipper] Only compatible with Resident Evil 7!")
    return
end

local in_phone_call = false
local enabled = true

-- Hook the start of phone interactions.
sdk.hook(
    sdk.find_type_definition("app.InteractEventAction"):get_method("startInteract(System.String, via.Transform)"),
    function(args)
        local name = sdk.to_managed_object(args[3]):call("ToString")
        in_phone_call = string.find(name, "PhoneStart") ~= nil
    end,
    function(retval)
        return retval
    end
)

-- Hook the message system to skip phone dialogues.
sdk.hook(
    sdk.find_type_definition("app.MessageSystem"):get_method("playSoundRow"),
    function(args)
        if enabled and in_phone_call then
            sdk.to_managed_object(args[2]):requestEndAllMessage()
        end
    end,
    function(retval)
        return retval
    end
)

-- Draw UI in the REFramework menu.
re.on_draw_ui(function()
    if imgui.tree_node("Phone Call Skipper") then
        imgui.begin_rect()
        imgui.text("This will skip all phone calls in the main game.\nYou still need to pick up the phone.")
        _, enabled = imgui.checkbox("Enabled", enabled)
        imgui.end_rect(2)
        imgui.tree_pop()
    end
end)
