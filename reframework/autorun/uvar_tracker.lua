local variable_type = sdk.find_type_definition("via.userdata.Variable")
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
local watched_guid_buckets = {}

if variable_type == nil then
    log.debug("[VariableTracker] via.userdata.Variable not found")
    return
end

local watched_guids = json.load_file("uvar_guids.json") or {}
log.debug("[VariableTracker] " .. #watched_guids .. " GUIDs loaded.")

for _, guid in ipairs(watched_guids) do
    if type(guid) == "string" then
        local normalized = guid:lower()
        local prefix = normalized:match("^[^%-]+") or normalized:sub(1, 8)
        local bucket = watched_guid_buckets[prefix]

        if bucket == nil then
            bucket = {}
            watched_guid_buckets[prefix] = bucket
        end

        bucket[normalized] = true
    end
end

local function get_name(this_object)
    local ok, name = pcall(this_object.call, this_object, "get_Name")
    if ok and name ~= nil then
        return tostring(name)
    end

    return string.format("0x%X", this_object:get_address())
end

local function get_type_kind_name(this_object)
    local ok, kind = pcall(this_object.call, this_object, "get_TypeKind")
    if not ok or kind == nil then
        return "Unknown"
    end

    local kind_value = tonumber(kind)
    if kind_value == nil then
        return tostring(kind)
    end

    return type_kind_names[kind_value] or string.format("Unknown(%d)", kind_value)
end

local function normalize_guid(guid)
    return guid:ToString()
end

local function get_guid(this_object)
    return this_object:get_Guid():ToString("D")
end

local function is_watched_guid(guid)
    if guid == nil then
        return false
    end

    local prefix = guid:match("^[^%-]+") or guid:sub(1, 8)
    local bucket = watched_guid_buckets[prefix]
    return bucket ~= nil and bucket[guid] == true
end

local ignored = { "BirdcageCoinNum", "CanOpen", "CanChange", "ChangedWeapon", "OpenInventory", "InventoryTabCraft" }
local function hook(signature, read_value)
    local method = variable_type:get_method(signature)
    if method == nil then
        log.debug(string.format("[VariableTracker] Missing method: %s", signature))
        return
    end

    sdk.hook(method, function(args)
        if not sdk.is_managed_object(args[1]) then return end

        local this_object = sdk.to_managed_object(args[1])
        local guid = get_guid(this_object)
        if not is_watched_guid(guid) then
            return
        end

        local name = get_name(this_object)
        for _, str in ipairs(ignored) do
            if string.find(name, str) ~= nil then
                return
            end
        end

        local value = read_value(args[3])
        log.debug(string.format(
            "[%s] %s (%s) = %s",
            guid,
            get_name(this_object),
            get_type_kind_name(this_object),
            value
        ))
    end, function(retval)
        return retval
    end)
end

hook("set_Bool(System.Boolean)", function(arg)
    return tostring(sdk.to_int64(arg) ~= 0)
end)

--hook("set_F32(System.Single)", function(arg)
--    return tostring(sdk.to_float(arg))
--end)

hook("set_S32(System.Int32)", function(arg)
    return tostring(arg)
end)

hook("set_String(System.String)", function(arg)
    local value = sdk.to_managed_object(arg)
    if value == nil then
        return "nil"
    end

    return tostring(value:call("ToString"))
end)

hook("set_U32(System.UInt32)", function(arg)
    return tostring(arg)
end)

hook("set_U64(System.UInt64)", function(arg)
    return tostring(arg)
end)

hook("setTrigger()", function(args)
    return ""
end)