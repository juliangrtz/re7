local settingsJson = "NoOnScreenBlood.json"
local default_settings = {
    enabled = true
}
local settings = json.load_file(settingsJson) or {}
for k, v in pairs(default_settings) do
    if settings[k] == nil then
        settings[k] = v
    end
end

sdk.hook(
    sdk.find_type_definition("app.PlayerDamageController"):get_method("doStart"),
    function(args)
        if settings.enabled then
            sdk.to_managed_object(args[2]).IsEnableDamageEffect = false
        end
    end,
    function(r) return r end
)

re.on_draw_ui(function()
    if imgui.tree_node("No blood effect") then
        imgui.text(
            "Enabling this will completely disable the blood effect when taking damage.\n" ..
            "A little bit of blood could briefly be visible after the first hit."
        )

        local changedEnabled
        changedEnabled, settings.enabled = imgui.checkbox("Enabled", settings.enabled)
        local changed = changedEnabled or changedTimerPos or changedColor
        if changed then json.dump_file(settingsJson, settings) end
        imgui.tree_pop()
    end
end)
