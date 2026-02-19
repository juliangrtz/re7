local json = json

--- Takes a JSON string and turns it into a Lua value (usually a table). Returns nil on error.
---@param json_str string
---@return table|any
local function json_load_string(json_str)
    return json.load_string(json_str)
end

--- Takes a Lua value (usually a table) and turns it into a JSON string. Returns an empty string on error. If unspecified, indent will default to -1.
---@param value table|any
---@param indent number
---@return string
local function json_dump_string(value, indent)
    return json.dump_string(value, indent)
end

--- Loads a JSON file identified by filepath relative to the reframework/data subdirectory and returns it as a Lua value (usually a table). Returns nil if the file does not exist.
---@param filepath string
---@return table|any
local function json_load_file(filepath)
    return json.load_file(filepath)
end

--- Takes a Lua value (usually a table), and turns it into a JSON file identified as filepath relative to the reframework/data subdirectory.  Returns true if the dump was successful, false otherwise. If unspecified, indent will default to 4
---@param filepath string
---@param value table|any
---@param indent number
---@return boolean
local function json_dump_file(filepath, value, indent)
    return json.dump_file(filepath, value, indent)
end

return {
    load_string = json_load_string,
    dump_string = json_dump_string,
    load_file = json_load_file,
    dump_file = json_dump_file,
}
