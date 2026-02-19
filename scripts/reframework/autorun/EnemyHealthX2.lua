if reframework:get_game_name() ~= "re7" then
    re.msg("[Enemy HP x2] Only compatible with RE7!")
    return
end


sdk.hook(
    sdk.find_type_definition("app.DamageController"):get_method("setHealth(System.Single, System.Single)"),
    function(args)
        args[3] = sdk.float_to_ptr(math.min(sdk.to_float(args[3]) * 2.0, 30000.0))
        args[4] = sdk.float_to_ptr(math.min(sdk.to_float(args[4]) * 2.0, 30000.0))
    end,
    nil
)
