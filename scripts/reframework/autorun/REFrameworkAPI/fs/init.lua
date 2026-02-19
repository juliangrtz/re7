local fs = fs

--- Returns a table of file paths that match the filter. filter should be a regex string for the files you wish to match.
--- Example
--- -- Get my mods JSON files.
--- local json_files = fs.glob([[my-cool-mod\\.*json]])
--- -- Iterate over them.
--- for k, v in ipairs(json_files) do
---     -- v will be something like `my-cool-mod\config-file-1.json` 
--- end
---@param filter string
---@return table
local function fs_glob(filter)
    return fs.glob(filter)
end

--- Reads filename and returns the data as a string.
---@param filename string
---@return string
local function fs_read(filename)
    return fs.read(filename)
end

--- Writes data to filename. data is a string.
---@param filename string
---@param data string
local function fs_write(filename, data)
    fs.write(filename, data)
end

return {
    glob = fs_glob,
    read = fs_read,
    write = fs_write,
}
