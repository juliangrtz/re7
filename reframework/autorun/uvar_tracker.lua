local SCRIPT_VERSION = "2026-05-29.4"

local LOG_DIR_IO_REL = [[BioRand7\uvar_trace]]
local LOG_DIR_DATA_REL = "BioRand7/uvar_trace"
local LOG_ALL_BOOLEAN_AND_TRIGGER_VARIABLES = false
local LOG_TRIGGER_EVENTS = false
local HOOK_WATCHED_TRIGGER_EVENTS = true
local LOG_RESET_ZERO_EVENTS = false
local LOG_FLOAT_EVENTS = false
local LOG_ONLY_VALUE_CHANGES = true
local LOG_TRIGGER_FIRST_ACTIVATION_ONLY = true
local LOG_LUA_STACKS = false
local FLUSH_EVERY_EVENTS = 128
local ignored_name_fragments = {
    "BirdcageCoinNum",
    "CanOpen",
    "CanChange",
    "ChangedWeapon",
    "OpenInventory",
    "InventoryTabCraft",
    "bJog",
    "bCrouch",
    "HadWalked",
    "HadCamera",
    "PlayerDisplacement"
}

local variable_type = sdk.find_type_definition("via.userdata.Variable")
local application_type = sdk.find_type_definition("via.Application")
local scene_manager_type = sdk.find_type_definition("via.SceneManager")

local type_kind_names = {
    [0] = "Unknown",
    [1] = "Enum",
    [2] = "Boolean",
    [3] = "Int8",
    [4] = "Uint8",
    [5] = "Int16",
    [6] = "Uint16",
    [7] = "Int32",
    [8] = "Uint32",
    [9] = "Int64",
    [10] = "Uint64",
    [11] = "Single",
    [12] = "Double",
    [13] = "C8",
    [14] = "C16",
    [15] = "String",
    [16] = "Trigger",
    [17] = "Vec2",
    [18] = "Vec3",
    [19] = "Vec4",
    [20] = "Matrix",
    [21] = "GUID",
    [22] = "Num"
}

if variable_type == nil then
    log.error("[VariableTracker] via.userdata.Variable not found")
    return
end

local function utc_timestamp()
    if os and os.date then
        return os.date("!%Y-%m-%dT%H:%M:%SZ")
    end

    return "unknown"
end

local function local_timestamp()
    if os and os.date then
        return os.date("%Y-%m-%dT%H:%M:%S%z")
    end

    return "unknown"
end

local function make_session_id()
    local stamp = "unknown"
    if os and os.date then
        stamp = os.date("!%Y%m%dT%H%M%SZ")
    end

    local clock_part = "0"
    if os and os.clock then
        clock_part = tostring(math.floor(os.clock() * 1000))
    end

    return stamp .. "-" .. clock_part
end

local function ensure_log_dir()
    if os == nil or os.execute == nil then
        return
    end

    os.execute([[if not exist "reframework\data\BioRand7" mkdir "reframework\data\BioRand7"]])
    os.execute([[if not exist "reframework\data\BioRand7\uvar_trace" mkdir "reframework\data\BioRand7\uvar_trace"]])
end

local function safe_tostring(value)
    if value == nil then
        return "nil"
    end

    return tostring(value)
end

local function safe_call(obj, method_name, ...)
    if obj == nil then
        return nil
    end

    local ok, value = pcall(obj.call, obj, method_name, ...)
    if ok then
        return value
    end

    return nil
end

local function safe_direct(fn)
    local ok, value = pcall(fn)
    if ok then
        return value
    end

    return nil
end

local function normalize_number(value)
    local n = tonumber(value)
    if n == nil then
        return nil
    end

    return math.floor((n * 1000) + 0.5) / 1000
end

local function read_vec_component(vec, name)
    if vec == nil then
        return nil
    end

    local value = safe_direct(function() return vec:get_field(name) end)
    if value == nil then
        value = safe_direct(function() return vec[name] end)
    end

    return normalize_number(value)
end

local function vec_to_table(vec)
    if vec == nil then
        return nil
    end

    local x = read_vec_component(vec, "x")
    local y = read_vec_component(vec, "y")
    local z = read_vec_component(vec, "z")

    if x == nil and y == nil and z == nil then
        return safe_tostring(vec)
    end

    return { x = x, y = y, z = z }
end

local function get_address(obj)
    if obj == nil then
        return nil
    end

    local address = safe_direct(function() return obj:get_address() end)
    if address == nil then
        return nil
    end

    return string.format("0x%X", address)
end

local function get_application()
    return sdk.get_native_singleton("via.Application")
end

local function get_scene_manager()
    return sdk.get_native_singleton("via.SceneManager")
end

local function get_game_manager()
    return sdk.get_managed_singleton("app.GameManager")
end

local function get_player()
    local player = nil

    pcall(function()
        local object_manager = sdk.get_managed_singleton("app.ObjectManager")
        if object_manager ~= nil then
            player = object_manager:get_field("PlayerObj")
        end
    end)

    if player == nil then
        pcall(function()
            local gm = get_game_manager()
            if gm ~= nil then
                player = gm:call("getPlayer")
            end
        end)
    end

    return player
end

local function get_transform_position(game_object)
    if game_object == nil then
        return nil
    end

    local transform = safe_direct(function() return game_object:get_Transform() end)
    if transform == nil then
        transform = safe_call(game_object, "get_Transform")
    end
    if transform == nil then
        return nil
    end

    local pos = safe_direct(function() return transform:get_Position() end)
    if pos == nil then
        pos = safe_call(transform, "get_Position")
    end

    return vec_to_table(pos)
end

local function get_player_position()
    return get_transform_position(get_player())
end

local function get_camera_position()
    local camera = nil

    pcall(function()
        camera = sdk.get_primary_camera()
    end)

    if camera == nil then
        return nil
    end

    local camera_object = safe_call(camera, "get_GameObject")
    if camera_object ~= nil then
        return get_transform_position(camera_object)
    end

    return get_transform_position(camera)
end

local function get_frame_count()
    local app = get_application()
    if app == nil or application_type == nil then
        return nil
    end

    return safe_direct(function()
        return sdk.call_native_func(app, application_type, "get_FrameCount")
    end)
end

local function get_uptime_seconds()
    local app = get_application()
    if app == nil or application_type == nil then
        return nil
    end

    local value = safe_direct(function()
        return sdk.call_native_func(app, application_type, "get_UpTimeSecond")
    end)

    return normalize_number(value)
end

local function get_scene_info()
    local sm = get_scene_manager()
    if sm == nil or scene_manager_type == nil then
        return nil
    end

    local scene = safe_direct(function()
        return sdk.call_native_func(sm, scene_manager_type, "get_CurrentScene")
    end)
    if scene == nil then
        return nil
    end

    return {
        address = get_address(scene),
        name = safe_tostring(safe_call(scene, "get_Name")),
        frame = tonumber(safe_call(scene, "get_FrameCount")),
        enabled = safe_call(scene, "get_Enabled"),
        main_scene = safe_call(scene, "get_MainScene")
    }
end

local function get_game_info()
    local gm = get_game_manager()
    if gm == nil then
        return nil
    end

    return {
        address = get_address(gm),
        current_chapter = safe_tostring(safe_call(gm, "get_CurrentChapter")),
        scene_loading = safe_call(gm, "get_IsSceneLoading")
    }
end

local function get_context()
    return {
        frame = tonumber(get_frame_count()),
        uptime_seconds = get_uptime_seconds(),
        scene = get_scene_info(),
        game = get_game_info(),
        player_position = get_player_position(),
        camera_position = get_camera_position()
    }
end

local watched_guid_buckets = {}
local watched_guid_count = 0
local watched_guids = json.load_file("uvar_guids.json") or {}
local extra_watched_guids = {
    "f063d396-0835-497b-8b29-7adb1b9194f3", -- c01_objective_ChainCut_ItemUse
}

local function add_watched_guid(guid)
    if type(guid) == "string" then
        local normalized = guid:lower()
        local prefix = normalized:match("^[^%-]+") or normalized:sub(1, 8)
        local bucket = watched_guid_buckets[prefix]

        if bucket == nil then
            bucket = {}
            watched_guid_buckets[prefix] = bucket
        end

        if bucket[normalized] ~= true then
            watched_guid_count = watched_guid_count + 1
        end

        bucket[normalized] = true
    end
end

for _, guid in ipairs(watched_guids) do
    add_watched_guid(guid)
end

for _, guid in ipairs(extra_watched_guids) do
    add_watched_guid(guid)
end

local function get_name(this_object)
    local name = safe_call(this_object, "get_Name")
    if name ~= nil then
        return safe_tostring(name)
    end

    return get_address(this_object) or "unknown"
end

local function get_type_kind_name(this_object)
    local kind = safe_call(this_object, "get_TypeKind")
    if kind == nil then
        return "Unknown"
    end

    local kind_value = tonumber(kind)
    if kind_value == nil then
        return safe_tostring(kind)
    end

    return type_kind_names[kind_value] or string.format("Unknown(%d)", kind_value)
end

local function get_guid(this_object)
    local guid = safe_direct(function()
        return this_object:get_Guid():ToString("D")
    end)
    if guid == nil then
        guid = safe_call(this_object, "get_Guid")
    end

    if guid == nil then
        return nil
    end

    return safe_tostring(guid):lower()
end

local function is_watched_guid(guid)
    if guid == nil then
        return false
    end

    local prefix = guid:match("^[^%-]+") or guid:sub(1, 8)
    local bucket = watched_guid_buckets[prefix]
    return bucket ~= nil and bucket[guid] == true
end

local function should_log_variable(guid, kind_name)
    if LOG_ALL_BOOLEAN_AND_TRIGGER_VARIABLES and kind_name == "Boolean" then
        return true
    end

    if LOG_TRIGGER_EVENTS and kind_name == "Trigger" then
        return true
    end

    return is_watched_guid(guid)
end

local function is_ignored_name(name)
    if name == nil then
        return false
    end

    for _, fragment in ipairs(ignored_name_fragments) do
        if string.find(name, fragment) ~= nil then
            return true
        end
    end

    return false
end

local function read_variable_value(this_object, kind_name)
    if kind_name == "Boolean" then
        return safe_call(this_object, "get_Bool")
    elseif kind_name == "Int32" then
        return tonumber(safe_call(this_object, "get_S32"))
    elseif kind_name == "Uint32" then
        return tonumber(safe_call(this_object, "get_U32"))
    elseif kind_name == "Uint64" then
        local value = safe_call(this_object, "get_U64")
        return value == nil and nil or safe_tostring(value)
    elseif kind_name == "Single" then
        return normalize_number(safe_call(this_object, "get_F32"))
    elseif kind_name == "String" then
        local value = safe_call(this_object, "get_String")
        return value == nil and nil or safe_tostring(value)
    elseif kind_name == "Trigger" then
        return safe_call(this_object, "get_Trigger")
    end

    return nil
end

local function read_origin_value(this_object, kind_name)
    if kind_name == "Boolean" then
        return safe_call(this_object, "get_OriginBool")
    elseif kind_name == "Int32" then
        return tonumber(safe_call(this_object, "get_OriginS32"))
    elseif kind_name == "Uint32" then
        return tonumber(safe_call(this_object, "get_OriginU32"))
    elseif kind_name == "Uint64" then
        local value = safe_call(this_object, "get_OriginU64")
        return value == nil and nil or safe_tostring(value)
    elseif kind_name == "Single" then
        return normalize_number(safe_call(this_object, "get_OriginF32"))
    end

    return nil
end

local function zero_value(kind_name)
    if kind_name == "Boolean" or kind_name == "Trigger" then
        return false
    elseif kind_name == "String" then
        return ""
    elseif kind_name == "Int32" or kind_name == "Uint32" or kind_name == "Uint64" or kind_name == "Single" then
        return 0
    end

    return nil
end

local function read_variable_metadata(this_object, guid, kind_name)
    return {
        address = get_address(this_object),
        guid = guid,
        in_watch_list = is_watched_guid(guid),
        name = get_name(this_object),
        type = kind_name,
        valid = safe_call(this_object, "get_Valid"),
        const = safe_call(this_object, "get_Const"),
        expression = safe_call(this_object, "get_Expression"),
        readonly = safe_call(this_object, "get_ReadOnly"),
        write_protect = safe_call(this_object, "get_WriteProtect"),
        name_hash = safe_tostring(safe_call(this_object, "get_NameHash"))
    }
end

local function values_equal(left, right)
    return safe_tostring(left) == safe_tostring(right)
end

local session_id = make_session_id()
local started_utc = utc_timestamp()
local started_local = local_timestamp()
local trace_path = LOG_DIR_IO_REL .. [[\]] .. session_id .. ".ndjson"
local text_path = LOG_DIR_IO_REL .. [[\]] .. session_id .. ".txt"
local latest_summary_rel_path = LOG_DIR_DATA_REL .. "/latest_session.json"
local session_summary_rel_path = LOG_DIR_DATA_REL .. "/" .. session_id .. "_summary.json"

local event_index = 0
local write_failures = 0
local last_values = {}
local last_trigger_frame_by_guid = {}
local seen_trigger_guid = {}
local ignored_guid_cache = {}
local pending_json_lines = {}
local pending_text_lines = {}
local context_cache = nil
local context_cache_frame = nil
local is_flushing = false

local function append_lines(path, lines)
    if #lines == 0 then
        return true
    end

    if io == nil or io.open == nil then
        write_failures = write_failures + 1
        log.error("[VariableTracker] Lua io.open is unavailable")
        return false
    end

    local file, err = io.open(path, "a")
    if file == nil then
        write_failures = write_failures + 1
        log.error("[VariableTracker] Failed to open " .. path .. ": " .. safe_tostring(err))
        return false
    end

    for _, line in ipairs(lines) do
        file:write(line)
        file:write("\n")
    end

    file:close()
    return true
end

local function append_line(path, line)
    return append_lines(path, { line })
end

local function flush_pending_logs(force)
    if is_flushing then
        return
    end

    if not force and (#pending_json_lines + #pending_text_lines) < FLUSH_EVERY_EVENTS then
        return
    end

    is_flushing = true

    local json_lines = pending_json_lines
    local text_lines = pending_text_lines
    pending_json_lines = {}
    pending_text_lines = {}

    append_lines(trace_path, json_lines)
    append_lines(text_path, text_lines)

    is_flushing = false
end

local function write_json_line(event)
    local encoded = json.dump_string(event, -1)
    if encoded == nil or encoded == "" then
        encoded = "{\"event\":\"json_encode_failed\"}"
    end

    table.insert(pending_json_lines, encoded)
    return true
end

local function format_position(pos)
    if type(pos) ~= "table" then
        return safe_tostring(pos)
    end

    return string.format("%.3f, %.3f, %.3f", tonumber(pos.x) or 0, tonumber(pos.y) or 0, tonumber(pos.z) or 0)
end

local function write_text_line(event)
    local context = event.context or {}
    local scene = context.scene or {}
    local game = context.game or {}
    local player_pos = context.player_position
    local text = string.format(
        "#%06d frame=%s uptime=%s chapter=%s scene=%s player=[%s] %s %s (%s) %s -> %s via %s",
        event.index or 0,
        safe_tostring(context.frame),
        safe_tostring(context.uptime_seconds),
        safe_tostring(game.current_chapter),
        safe_tostring(scene.name),
        format_position(player_pos),
        event.variable.guid,
        event.variable.name,
        event.variable.type,
        safe_tostring(event.old_value),
        safe_tostring(event.new_value),
        event.method
    )

    table.insert(pending_text_lines, text)
end

local function write_manifest(reason)
    local manifest = {
        script_version = SCRIPT_VERSION,
        session_id = session_id,
        started_utc = started_utc,
        started_local = started_local,
        updated_utc = utc_timestamp(),
        updated_local = local_timestamp(),
        reason = reason,
        watched_guid_count = watched_guid_count,
        log_all_boolean_and_trigger_variables = LOG_ALL_BOOLEAN_AND_TRIGGER_VARIABLES,
        log_trigger_events = LOG_TRIGGER_EVENTS,
        hook_watched_trigger_events = HOOK_WATCHED_TRIGGER_EVENTS,
        log_reset_zero_events = LOG_RESET_ZERO_EVENTS,
        log_float_events = LOG_FLOAT_EVENTS,
        log_only_value_changes = LOG_ONLY_VALUE_CHANGES,
        log_trigger_first_activation_only = LOG_TRIGGER_FIRST_ACTIVATION_ONLY,
        log_lua_stacks = LOG_LUA_STACKS,
        event_count = event_index,
        write_failures = write_failures,
        trace_path = trace_path,
        text_path = text_path
    }

    json.dump_file(latest_summary_rel_path, manifest, 2)
    json.dump_file(session_summary_rel_path, manifest, 2)
end

local function get_context_cached()
    local frame = get_frame_count()
    if context_cache == nil or frame == nil or frame ~= context_cache_frame then
        context_cache = get_context()
        context_cache_frame = context_cache and context_cache.frame or frame
    end

    return context_cache
end

local function record_event(kind, method_name, this_object, guid, old_value, new_value)
    local kind_name = get_type_kind_name(this_object)
    local variable = read_variable_metadata(this_object, guid, kind_name)
    local previous = last_values[guid]
    local changed = not values_equal(old_value, new_value)

    if LOG_ONLY_VALUE_CHANGES and kind ~= "trigger" and not changed then
        return
    end

    local context = get_context_cached()
    if kind == "trigger" then
        if LOG_TRIGGER_FIRST_ACTIVATION_ONLY and seen_trigger_guid[guid] == true then
            return
        end

        local frame = context and context.frame or get_frame_count() or -1
        if last_trigger_frame_by_guid[guid] == frame then
            return
        end

        last_trigger_frame_by_guid[guid] = frame
        seen_trigger_guid[guid] = true
    end

    event_index = event_index + 1

    local event = {
        event = kind,
        index = event_index,
        session_id = session_id,
        script_version = SCRIPT_VERSION,
        timestamp_utc = utc_timestamp(),
        timestamp_local = local_timestamp(),
        os_clock = os and os.clock and normalize_number(os.clock()) or nil,
        method = method_name,
        variable = variable,
        old_value = old_value,
        new_value = new_value,
        changed = changed,
        previous_event_index = previous and previous.index or nil,
        previous_seen_value = previous and previous.value or nil,
        context = context,
        lua_stack = LOG_LUA_STACKS and debug and debug.traceback and debug.traceback("", 3) or nil
    }

    last_values[guid] = {
        index = event_index,
        value = new_value,
        changed = changed
    }

    write_json_line(event)
    write_text_line(event)
end

local function handle_hook_error(signature, err)
    local event = {
        event = "hook_error",
        session_id = session_id,
        timestamp_utc = utc_timestamp(),
        method = signature,
        error = safe_tostring(err),
        lua_stack = debug and debug.traceback and debug.traceback("", 2) or nil
    }
    write_json_line(event)
    append_line(text_path, "[ERROR] " .. signature .. ": " .. safe_tostring(err))
    log.error("[VariableTracker] " .. signature .. " failed: " .. safe_tostring(err))
end

local function hook_value(signature, value_reader)
    local method = variable_type:get_method(signature)
    if method == nil then
        log.warn(string.format("[VariableTracker] Missing method: %s", signature))
        return
    end

    sdk.hook(method, function(args)
        local ok, err = pcall(function()
            if not sdk.is_managed_object(args[1]) then
                return
            end

            local this_object = sdk.to_managed_object(args[1])
            local guid = get_guid(this_object)
            if not is_watched_guid(guid) and not LOG_ALL_BOOLEAN_AND_TRIGGER_VARIABLES and not LOG_TRIGGER_EVENTS then
                return
            end

            local kind_name = get_type_kind_name(this_object)
            if not should_log_variable(guid, kind_name) then
                return
            end

            if ignored_guid_cache[guid] then
                return
            end

            if is_ignored_name(get_name(this_object)) then
                ignored_guid_cache[guid] = true
                return
            end

            local old_value = read_variable_value(this_object, kind_name)
            local new_value = value_reader(args[3])
            record_event("set", signature, this_object, guid, old_value, new_value)
        end)

        if not ok then
            handle_hook_error(signature, err)
        end
    end, function(retval)
        return retval
    end)
end

local function hook_noarg(signature, event_kind, new_value_reader)
    local method = variable_type:get_method(signature)
    if method == nil then
        log.warn(string.format("[VariableTracker] Missing method: %s", signature))
        return
    end

    sdk.hook(method, function(args)
        local ok, err = pcall(function()
            if not sdk.is_managed_object(args[1]) then
                return
            end

            local this_object = sdk.to_managed_object(args[1])
            local guid = get_guid(this_object)
            if not is_watched_guid(guid) and not LOG_ALL_BOOLEAN_AND_TRIGGER_VARIABLES and not LOG_TRIGGER_EVENTS then
                return
            end

            local kind_name = get_type_kind_name(this_object)
            if not should_log_variable(guid, kind_name) then
                return
            end

            if ignored_guid_cache[guid] then
                return
            end

            if is_ignored_name(get_name(this_object)) then
                ignored_guid_cache[guid] = true
                return
            end

            local old_value = read_variable_value(this_object, kind_name)
            local new_value = new_value_reader(this_object, kind_name)
            record_event(event_kind, signature, this_object, guid, old_value, new_value)
        end)

        if not ok then
            handle_hook_error(signature, err)
        end
    end, function(retval)
        return retval
    end)
end

local function read_bool_arg(arg)
    return sdk.to_int64(arg) ~= 0
end

local function read_i32_arg(arg)
    return tonumber(sdk.to_int64(arg))
end

local function read_u32_arg(arg)
    return tonumber(sdk.to_int64(arg))
end

local function read_u64_arg(arg)
    return safe_tostring(arg)
end

local function read_f32_arg(arg)
    return normalize_number(sdk.to_float(arg))
end

local function read_string_arg(arg)
    local value = sdk.to_managed_object(arg)
    if value == nil then
        return nil
    end

    local as_string = safe_call(value, "ToString")
    if as_string == nil then
        return safe_tostring(value)
    end

    return safe_tostring(as_string)
end

ensure_log_dir()

write_json_line({
    event = "session_start",
    session_id = session_id,
        script_version = SCRIPT_VERSION,
        timestamp_utc = started_utc,
        timestamp_local = started_local,
        watched_guid_count = watched_guid_count,
        log_all_boolean_and_trigger_variables = LOG_ALL_BOOLEAN_AND_TRIGGER_VARIABLES,
        log_trigger_events = LOG_TRIGGER_EVENTS,
        hook_watched_trigger_events = HOOK_WATCHED_TRIGGER_EVENTS,
        log_reset_zero_events = LOG_RESET_ZERO_EVENTS,
        log_float_events = LOG_FLOAT_EVENTS,
        log_only_value_changes = LOG_ONLY_VALUE_CHANGES,
        log_trigger_first_activation_only = LOG_TRIGGER_FIRST_ACTIVATION_ONLY,
        log_lua_stacks = LOG_LUA_STACKS,
        trace_path = trace_path,
    text_path = text_path,
    summary_path = latest_summary_rel_path,
    context = get_context()
})
append_line(text_path, string.format(
    "[session_start] %s local=%s watched_only=%s trigger_events=%s watched_trigger_events=%s float_events=%s only_changes=%s watched_guids=%d trace=%s",
    started_utc,
    started_local,
    safe_tostring(not LOG_ALL_BOOLEAN_AND_TRIGGER_VARIABLES),
    safe_tostring(LOG_TRIGGER_EVENTS),
    safe_tostring(HOOK_WATCHED_TRIGGER_EVENTS),
    safe_tostring(LOG_FLOAT_EVENTS),
    safe_tostring(LOG_ONLY_VALUE_CHANGES),
    watched_guid_count,
    trace_path
))
flush_pending_logs(true)

hook_value("set_Bool(System.Boolean)", read_bool_arg)
hook_value("set_S32(System.Int32)", read_i32_arg)
hook_value("set_U32(System.UInt32)", read_u32_arg)
hook_value("set_U64(System.UInt64)", read_u64_arg)
if LOG_FLOAT_EVENTS then
    hook_value("set_F32(System.Single)", read_f32_arg)
end
hook_value("set_String(System.String)", read_string_arg)

if LOG_TRIGGER_EVENTS or HOOK_WATCHED_TRIGGER_EVENTS then
    hook_noarg("setTrigger()", "trigger", function()
        return true
    end)
end
if LOG_RESET_ZERO_EVENTS then
    hook_noarg("resetValue()", "reset", function(this_object, kind_name)
        return read_origin_value(this_object, kind_name)
    end)
    hook_noarg("setZero()", "zero", function(_, kind_name)
        return zero_value(kind_name)
    end)
end

if re.on_frame ~= nil then
    re.on_frame(function()
        flush_pending_logs(true)
    end)
end

re.on_script_reset(function()
    flush_pending_logs(true)
    write_json_line({
        event = "session_end",
        reason = "script_reset",
        session_id = session_id,
        timestamp_utc = utc_timestamp(),
        timestamp_local = local_timestamp(),
        event_count = event_index,
        context = get_context()
    })
    append_line(text_path, string.format("[session_end] script_reset events=%d", event_index))
    flush_pending_logs(true)
    write_manifest("script_reset")
end)

write_manifest("session_start")
log.info(string.format(
    "[VariableTracker] Recording only %d progression-watch GUIDs to %s",
    watched_guid_count,
    trace_path
))
