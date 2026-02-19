local utils = {}

function utils.clearDebugConsole()
    for _ = 0, 100 do log.debug("") end
end

function utils.rgbToInt(r, g, b, a)
    local t = {
        R = r,
        G = g,
        B = b,
        A = a,
        int = function(self)
            return math.floor(self.A * 255) * 16777216 +
                math.floor(self.B * 255) * 65536 +
                math.floor(self.G * 255) * 256 +
                math.floor(self.R * 255)
        end
    }

    return t
end

function utils.sleep(a)
    local sec = tonumber(os.clock() + a);
    while (os.clock() < sec) do
    end
end

function utils.vec3tostring(vec3) return string.format("(%f, %f, %f)", vec3.x, vec3.y, vec3.z) end

function utils.areVectorsClose(vec1, vec2, epsilon)
    return math.abs(vec1.x - vec2.x) < epsilon and
        math.abs(vec1.y - vec2.y) < epsilon and
        math.abs(vec1.z - vec2.z) < epsilon
end

function utils.teleportPlayer(pos)
    local player = utils.get_localplayer()
    local controller = utils.get_component(player, "via.physics.CharacterController")
    if not player or not controller then return end
    controller:call("warp")
    player:get_Transform():set_Position(pos)
    controller:call("warp")
end

function utils.get_localplayer()
    local object_man = sdk.get_managed_singleton("app.ObjectManager")

    if not object_man then
        return nil
    end

    return object_man:get_field("PlayerObj")
end

local known_typeofs = {}
function utils.get_component(game_object, type_name)
    local t = known_typeofs[type_name] or sdk.typeof(type_name)

    if t == nil then
        return nil
    end

    known_typeofs[type_name] = t
    return game_object:call("getComponent(System.Type)", t)
end

function utils.to_table(managedObj)
    if not managedObj then return nil end

    local t = {}
    local klass = sdk.find_type_definition(managedObj:get_type_definition():get_full_name())
    if not klass then return t end

    local fields = klass:get_fields()
    for i = 0, #fields - 1 do
        local field = fields[i]
        local ok, value = pcall(function()
            return field:get_data(managedObj)
        end)
        if ok then
            if sdk.is_managed_object(value) then
                t[field:get_name()] = utils.to_table(value)
            else
                t[field:get_name()] = value
            end
        end
    end

    return t
end

--[[
sdk.hook(
    sdk.find_type_definition(""):get_method(""),
    function(args)

    end,
    function(retval)
        return retval
    end
)
]]

function utils.hook(klass, func, pre, post)
    sdk.hook(
        sdk.find_type_definition(klass):get_method(func),
        pre,
        post
    )
end

function utils.setup_settings(settingsFile, default_settings)
    local settings = json.load_file(settingsFile) or {}

    for k, v in pairs(default_settings) do
        if settings[k] == nil then
            settings[k] = v
        end
    end
end

local has_warned = false
function utils.get_singleton(name)
    local s = sdk.get_managed_singleton(name)
    if not s and not has_warned then
        re.msg("Did not find singleton " .. name .. "!")
        has_warned = true
    end
    return s
end

function utils.get_transform(game_object)
    return game_object:call("get_Transform")
end

function utils.print_components(game_object)
    local transform = utils.get_transform(game_object)
    if not transform then return end

    local components = game_object:call("get_Components")
    for i = 1, #components do
        log.debug("Component " .. i .. ": " .. components[i]:get_type_definition():get_full_name())
    end
end

-- Author: praydog
function utils.generate_statics(typename, no_reverse)
    local t = sdk.find_type_definition(typename)
    local fields = t:get_fields()
    local enum = {}
    local names = {}

    for _, field in ipairs(fields) do
        if field:is_static() then
            local raw_value = field:get_data(nil)
            if raw_value ~= nil then
                local name = field:get_name()
                enum[name] = raw_value
                if not no_reverse then
                    enum[raw_value] = name
                end
                table.insert(names, name)
            end
        end
    end
    return enum, names
end

return utils
