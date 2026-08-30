local Config = {}
Config.__index = Config

local CONFIG_PATH = "BioRand7/config.json"

function Config.new()
    local self = setmetatable({}, Config)
    self:reload()
    return self
end

function Config:reload()
    self.values = json.load_file(CONFIG_PATH) or {}
end

function Config:get(key, default)
    local value = self.values[key]
    if value == nil then
        return default
    end
    return value
end

function Config:entries()
    local entries = {}
    for key, value in pairs(self.values) do
        entries[#entries + 1] = { key = key, value = value }
    end
    table.sort(entries, function(left, right)
        return left.key:lower() < right.key:lower()
    end)
    return entries
end

return Config
