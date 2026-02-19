local reframework = reframework

--- Returns true if the REFramework menu is open.
---@return boolean
local function reframework_is_drawing_ui()
    return reframework.is_drawing_ui()
end

--- Returns the name of the game this REFramework was compiled for.
--- e.g. &quot;dmc5&quot; or &quot;re2&quot;
---@return string
local function reframework_get_game_name()
    return reframework.get_game_name()
end

--- key is a Windows virtual key code.
---@param key integer
---@return boolean
local function reframework_is_key_down(key)
    return reframework.is_key_down(key)
end

--- Returns the total number of commits on the current branch of the REFramework build.
---@return integer
local function reframework_get_commit_count()
    return reframework.get_commit_count()
end

--- Returns the branch name of the REFramework build.
--- ex: &quot;master&quot;
---@return string
local function reframework_get_branch()
    return reframework.get_branch()
end

--- Returns the commit hash of the REFramework build.
---@return string
local function reframework_get_commit_hash()
    return reframework.get_commit_hash()
end

--- Returns the last tag of the REFramework build on its current branch.
--- ex: &quot;v1.5.4&quot;
---@return string
local function reframework_get_tag()
    return reframework.get_tag()
end

--- Returns the last tag of the REFramework build on its current branch as a long.
---@return number
local function reframework_get_tag_long()
    return reframework.get_tag_long()
end

--- Returns the number of commits past the last tag.
---@return number
local function reframework_get_commits_past_tag()
    return reframework.get_commits_past_tag()
end

--- Returns the date that REFramework was built (mm/dd/yyyy).
---@return any
local function reframework_get_build_date()
    return reframework.get_build_date()
end

--- Returns the time that REFramework was built.
---@return any
local function reframework_get_build_time()
    return reframework.get_build_time()
end

return {
    is_drawing_ui = reframework_is_drawing_ui,
    get_game_name = reframework_get_game_name,
    is_key_down = reframework_is_key_down,
    get_commit_count = reframework_get_commit_count,
    get_branch = reframework_get_branch,
    get_commit_hash = reframework_get_commit_hash,
    get_tag = reframework_get_tag,
    get_tag_long = reframework_get_tag_long,
    get_commits_past_tag = reframework_get_commits_past_tag,
    get_build_date = reframework_get_build_date,
    get_build_time = reframework_get_build_time,
}
