local re = re

--- Creates a MessageBox with text. Note that this will pause game execution until the user presses OK.
--- Callback Creators
--- Most creators have a pre and post function. Pre meaning the callback gets triggered before the original method is called, and post being after it's called.
local function re_msg(text)
    return re.msg(text)
end

--- Calls function when scripts are being reset. Useful for cleaning up stuff. Calls on_config_save().
local function re_on_script_reset(func)
    return re.on_script_reset(func)
end

--- Called when REFramework wants to save its config.
local function re_on_config_save(func)
    return re.on_config_save(func)
end

--- Called every frame when the &quot;Script Generated UI&quot; in the menu is open. 
--- imgui functions can be called here, and will be placed in their own dropdown in the REFramework menu.
local function re_on_draw_ui(func)
    return re.on_draw_ui(func)
end

--- Called every frame. draw functions can be used here. Don't use imgui functions unless using begin_window etc...
--- Try to minimize calling game methods when inside on_frame and on_draw_ui.
local function re_on_frame(func)
    return re.on_frame(func)
end

--- Valid names for re.on_application_entry can be found by viewing via.ModuleEntry in the Object Explorer.
---@param name ApplicationEntryOptions|string
---@param func function
local function re_on_pre_application_entry(name, func)
    re.on_pre_application_entry(name, func)
end

--- Triggers function when the application/module entry associated with  name is being executed.
--- This is very powerful, and can be used to run code at many important points in the engine's logic loop.
---@param name ApplicationEntryOptions|string
---@param func function
local function re_on_application_entry(name, func)
    re.on_application_entry(name, func)
end

---@param func function
local function re_on_pre_gui_draw_element(func)
    re.on_pre_gui_draw_element(func)
end

--- Function prototype: function on_*_draw_element(element, context)
--- Triggers function when a GUI element is being drawn.
--- Requires that a bool is returned in on_pre_gui_draw_element. When false is returned, the GUI element is not drawn.
--- element is an REComponent*.
--- Example:
--- re.on_pre_gui_draw_element(function(element, context)
---     local game_object = element:call(&quot;get_GameObject&quot;)
---     if game_object == nil then return true end
---     local name = game_object:call(&quot;get_Name&quot;)
---     log.info(&quot;drawing element: &quot; .. name)
---     -- Stops the crosshair from being drawn in most RE Engine games.
---     if name == &quot;GUIReticle&quot; or name == &quot;GUI_Reticle&quot; then
---         return false
---     end
---     return true
--- end)
---@param func function
local function re_on_gui_draw_element(func)
    return re.on_gui_draw_element(func)
end

return {
    msg = re_msg,
    on_script_reset = re_on_script_reset,
    on_config_save = re_on_config_save,
    on_draw_ui = re_on_draw_ui,
    on_frame = re_on_frame,
    on_pre_application_entry = re_on_pre_application_entry,
    on_application_entry = re_on_application_entry,
    on_pre_gui_draw_element = re_on_pre_gui_draw_element,
    on_gui_draw_element = re_on_gui_draw_element,
}
