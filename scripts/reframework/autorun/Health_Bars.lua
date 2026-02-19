package.preload["Health_Bars.bar_customization"] = assert((loadstring or load)("local this = {};\
\
local utils;\
local config;\
local language;\
local screen;\
local customization_menu;\
local error_handler;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
local outline_styles = {};\
local displayed_outline_styles = {};\
\
local directions = {};\
local displayed_directions = {};\
\
function this.init()\
\9local cached_default_language = language.default_language.customization_menu;\
\9local cached_current_language = language.current_language.customization_menu;\
\
\9outline_styles = {\
\9\9cached_default_language.inside,\
\9\9cached_default_language.center,\
\9\9cached_default_language.outside\
\9};\
\
\9displayed_outline_styles = {\
\9\9cached_current_language.inside,\
\9\9cached_current_language.center,\
\9\9cached_current_language.outside\
\9};\
\
\9directions = {\
\9\9cached_default_language.left_to_right,\
\9\9cached_default_language.right_to_left,\
\9\9cached_default_language.top_to_bottom,\
\9\9cached_default_language.bottom_to_top\
\9};\
\
\9displayed_directions = {\
\9\9cached_current_language.left_to_right,\
\9\9cached_current_language.right_to_left,\
\9\9cached_current_language.top_to_bottom,\
\9\9cached_current_language.bottom_to_top\
\9};\
end\
\
function this.draw(bar_name, bar)\
\9local cached_language = language.current_language.customization_menu;\
\
\9local bar_changed = false;\
\9local changed = false;\
\9local index = 1;\
\
\9if imgui.tree_node(bar_name) then\
\9\9changed, bar.visibility = imgui.checkbox(cached_language.visible, bar.visibility);\
\9\9bar_changed = bar_changed or changed;\
\
\9\9if imgui.tree_node(cached_language.settings) then\
\9\9\9local fill_direction_index = utils.table.find_index(directions, bar.settings.fill_direction);\
\9\9\9changed, fill_direction_index = imgui.combo(cached_language.fill_type, fill_direction_index, displayed_directions);\
\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9if changed then\
\9\9\9\9bar.settings.fill_direction = directions[fill_direction_index];\
\9\9\9end\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9if imgui.tree_node(cached_language.offset) then\
\9\9\9changed, bar.offset.x = imgui.drag_float(cached_language.x,\
\9\9\9\9bar.offset.x, 0.1, -screen.width, screen.width, \"%.1f\");\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9changed, bar.offset.y = imgui.drag_float(cached_language.y,\
\9\9\9\9bar.offset.y, 0.1, -screen.height, screen.height, \"%.1f\");\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9if imgui.tree_node(cached_language.size) then\
\9\9\9changed, bar.size.width = imgui.drag_float(cached_language.width,\
\9\9\9\9bar.size.width, 0.1, 0, screen.width, \"%.1f\");\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9changed, bar.size.height = imgui.drag_float(cached_language.height,\
\9\9\9\9bar.size.height, 0.1, 0, screen.height, \"%.1f\");\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9if imgui.tree_node(cached_language.outline) then\
\9\9\9changed, bar.outline.visibility = imgui.checkbox(cached_language.visible\
\9\9\9\9, bar.outline.visibility);\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9changed, bar.outline.thickness = imgui.drag_float(cached_language.thickness,\
\9\9\9\9bar.outline.thickness, 0.1, 0, screen.width, \"%.1f\");\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9changed, bar.outline.offset = imgui.drag_float(cached_language.offset,\
\9\9\9\9bar.outline.offset, 0.1, -screen.height, screen.height, \"%.1f\");\
\9\9\9bar_changed = bar_changed or changed;\
\
\
\9\9\9changed, index = imgui.combo(cached_language.style,\
\9\9\9\9utils.table.find_index(outline_styles, bar.outline.style),\
\9\9\9\9displayed_outline_styles);\
\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9if changed then\
\9\9\9\9bar.outline.style = outline_styles[index];\
\9\9\9end\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9if imgui.tree_node(cached_language.colors) then\
\9\9\9if imgui.tree_node(cached_language.foreground) then\
\9\9\9\9changed, bar.colors.foreground = imgui.color_picker_argb(\"\", bar.colors.foreground,\
\9\9\9\9\9customization_menu.color_picker_flags);\
\9\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\
\9\9\9if imgui.tree_node(cached_language.background) then\
\9\9\9\9changed, bar.colors.background = imgui.color_picker_argb(\"\", bar.colors.background,\
\9\9\9\9\9customization_menu.color_picker_flags);\
\9\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\
\9\9\9if imgui.tree_node(cached_language.outline) then\
\9\9\9\9changed, bar.colors.outline = imgui.color_picker_argb(\"\", bar.colors.outline,\
\9\9\9\9\9customization_menu.color_picker_flags);\
\9\9\9\9bar_changed = bar_changed or changed;\
\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9bar_changed = bar_changed or changed;\
\
\9\9imgui.tree_pop();\
\9end\
\
\9return bar_changed;\
end\
\
function this.init_module()\
\9utils = require(\"Health_Bars.utils\");\
\9config = require(\"Health_Bars.config\");\
\9language = require(\"Health_Bars.language\");\
\9screen = require(\"Health_Bars.screen\");\
\9customization_menu = require(\"Health_Bars.customization_menu\");\
\9error_handler = require(\"Health_Bars.error_handler\");\
end\
\
return this;\
", '@' .. ".\\Health_Bars\\bar_customization.lua"))

package.preload["Health_Bars.config"] = assert((loadstring or load)("local this = {};\
local version = \"1.2\";\
\
local utils;\
local language;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
this.current_config = nil;\
this.config_file_name = \"Health Bars/config.json\";\
\
this.default_config = {};\
\
function this.init()\
\9this.default_config = {\
\9\9enabled = true,\
\9\9\
\9\9version = this.version,\
\9\9language = \"default\",\
\
\9\9customization_menu = {\
\9\9\9position = {\
\9\9\9\9x = 480,\
\9\9\9\9y = 200\
\9\9\9},\
\
\9\9\9size = {\
\9\9\9\9width = 650,\
\9\9\9\9height = 480\
\9\9\9},\
\
\9\9\9pivot = {\
\9\9\9\9x = 0,\
\9\9\9\9y = 0\
\9\9\9}\
\9\9},\
\
\9\9menu_font = {\
\9\9\9size = 15\
\9\9},\
\
\9\9ui_font = {\
\9\9\9family = \"Consolas\",\
\9\9\9size = 13,\
\9\9\9bold = true,\
\9\9\9italic = false\
\9\9},\
\
\9\9settings = {\
\9\9\9timer_delays = {\
\9\9\9\9update_singletons_delay = 0,\
\9\9\9\9update_window_size_delay = 0,\
\9\9\9\9update_game_data_delay = 0.1,\
\9\9\9\9update_player_data_delay = 0.1,\
\9\9\9\9update_enemy_data_delay = 0.1,\
\9\9\9},\
\9\9\9\
\9\9\9use_d2d_if_available = true,\
\9\9\9\
\9\9\9render_during_cutscenes = true,\
\9\9\9render_when_game_timer_is_paused = true,\
\9\9\9render_when_any_menu_is_opened = false,\
\
\9\9\9render_aim_target_enemy = true,\
\9\9\9render_damaged_enemies = true,\
\9\9\9render_everyone_else = true,\
\
\9\9\9render_when_normal = true,\
\9\9\9render_when_aiming = true,\
\9\9\9render_when_guarding = true,\
\
\9\9\9hide_if_dead = true,\
\9\9\9hide_if_full_health = true,\
\9\9\9hide_if_enemy_is_not_in_sight = true,\
\
\9\9\9opacity_falloff = true,\
\9\9\9max_distance = 30,\
\
\9\9\9apply_time_duration_on_aiming = false,\
\9\9\9apply_time_duration_on_guarding = false,\
\9\9\9apply_time_duration_on_aim_target = false,\
\9\9\9apply_time_duration_on_damage_dealt = false,\
\9\9\9reset_time_duration_on_aim_target_for_everyone = true,\
\9\9\9reset_time_duration_on_damage_dealt_for_everyone = true,\
\9\9\9time_duration = 15,\
\9\9},\
\
\9\9world_offset = {\
\9\9\9x = 0,\
\9\9\9y = 0.35,\
\9\9\9z = 0\
\9\9},\
\
\9\9health_value_label = {\
\9\9\9visibility = true,\
\
\9\9\9settings = {\
\9\9\9\9right_alignment_shift = 11\
\9\9\9},\
\
\9\9\9include = {\
\9\9\9\9current_value = true,\
\9\9\9\9max_value = true\
\9\9\9},\
\
\9\9\9text_format = \"%s\", -- current_health/max_health\
\
\9\9\9offset = {\
\9\9\9\9x = -20,\
\9\9\9\9y = 0\
\9\9\9},\
\9\9\9\
\9\9\9color = 0xFFFFFCC0,\
\
\9\9\9shadow = {\
\9\9\9\9visibility = true,\
\9\9\9\9offset = {\
\9\9\9\9\9x = 1,\
\9\9\9\9\9y = 1\
\9\9\9\9},\
\9\9\9\9color = 0xFF000000\
\9\9\9}\
\9\9},\
\
\9\9health_bar = {\
\9\9\9visibility = true,\
\
\9\9\9settings = {\
\9\9\9\9fill_direction = \"Left to Right\"\
\9\9\9},\
\
\9\9\9offset = {\
\9\9\9\9x = -64,\
\9\9\9\9y = 0\
\9\9\9},\
\
\9\9\9size = {\
\9\9\9\9width = 128,\
\9\9\9\9height = 8\
\9\9\9},\
\
\9\9\9outline = {\
\9\9\9\9visibility = true,\
\9\9\9\9thickness = 2.5,\
\9\9\9\9offset = 0,\
\9\9\9\9style = \"Outside\"\
\9\9\9},\
\
\9\9\9colors = {\
\9\9\9\9foreground = 0x80A0FF71,\
\9\9\9\9background = 0x48000000,\
\9\9\9\9outline = 0x68000000\
\9\9\9}\
\9\9},\
\
\9\9debug = {\
\9\9\9history_size = 64\
\9\9},\
\9};\
end\
\
function this.load()\
\9local loaded_config = json.load_file(this.config_file_name);\
\9if loaded_config ~= nil then\
\9\9log.info(\"[Health Bars] config.json loaded successfully\");\
\9\9this.current_config = utils.table.merge(this.default_config, loaded_config);\
\9else\
\9\9log.error(\"[Health Bars] Failed to load config.json\");\
\9\9this.current_config = utils.table.deep_copy(this.default_config);\
\9end\
end\
\
function this.save()\
\9-- save current config to disk, replacing any existing file\
\9local success = json.dump_file(this.config_file_name, this.current_config);\
\9if success then\
\9\9log.info(\"[Health Bars] config.json saved successfully\");\
\9else\
\9\9log.error(\"[Health Bars] Failed to save config.json\");\
\9end\
end\
\
function this.reset()\
\9this.current_config = utils.table.deep_copy(this.default_config);\
\9this.current_config.version = version;\
end\
\
function this.init_module()\
\9utils = require(\"Health_Bars.utils\");\
\9language = require(\"Health_Bars.language\");\
\9this.init();\
\9this.load();\
\9this.current_config.version = version;\
\
\9language.update(utils.table.find_index(language.language_names, this.current_config.language));\
end\
\
return this;\
", '@' .. ".\\Health_Bars\\config.lua"))

package.preload["Health_Bars.customization_menu"] = assert((loadstring or load)("local this = {};\
\
local utils;\
local config;\
local language;\
local label_customization;\
local bar_customization;\
local time;\
local enemy_handler;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
this.font = nil;\
this.full_font_range = {0x1, 0xFFFF, 0};\
this.is_opened = false;\
\
this.window_position = Vector2f.new(480, 200);\
this.window_pivot = Vector2f.new(0, 0);\
this.window_size = Vector2f.new(650, 700);\
this.window_flags = 0x10120;\
this.color_picker_flags = 327680;\
this.decimal_input_flags = 33;\
\
this.config_changed = false;\
\
this.fonts = {\9\"Arial\", \"Arial Black\", \"Bahnschrift\", \"Calibri\", \"Cambria\", \"Cambria Math\", \"Candara\",\
\9\9\9\9\"Comic Sans MS\", \"Consolas\", \"Constantia\", \"Corbel\", \"Courier New\", \"Ebrima\",\
\9\9\9\9\"Franklin Gothic Medium\", \"Gabriola\", \"Gadugi\", \"Georgia\", \"HoloLens MDL2 Assets\", \"Impact\",\
\9\9\9\9\"Ink Free\", \"Javanese Text\", \"Leelawadee UI\", \"Lucida Console\", \"Lucida Sans Unicode\",\
\9\9\9\9\"Malgun Gothic\", \"Marlett\", \"Microsoft Himalaya\", \"Microsoft JhengHei\", \"Microsoft New Tai Lue\",\
\9\9\9\9\"Microsoft PhagsPa\", \"Microsoft Sans Serif\", \"Microsoft Tai Le\", \"Microsoft YaHei\",\
\9\9\9\9\"Microsoft Yi Baiti\", \"MingLiU-ExtB\", \"Mongolian Baiti\", \"MS Gothic\", \"MV Boli\", \"Myanmar Text\",\
\9\9\9\9\"Nirmala UI\", \"Palatino Linotype\", \"Segoe MDL2 Assets\", \"Segoe Print\", \"Segoe Script\", \"Segoe UI\",\
\9\9\9\9\"Segoe UI Historic\", \"Segoe UI Emoji\", \"Segoe UI Symbol\", \"SimSun\", \"Sitka\", \"Sylfaen\", \"Symbol\",\
\9\9\9\9\"Tahoma\", \"Times New Roman\", \"Trebuchet MS\", \"Verdana\", \"Webdings\", \"Wingdings\", \"Yu Gothic\"\
};\
\
function this.reload_font(pop_push)\
\9local cached_language = language.current_language;\
\
\9local font_range = cached_language.unicode_glyph_ranges;\
\
\9if cached_language.font_name == \"\" then\
\9\9font_range = nil;\
\
\9elseif cached_language.unicode_glyph_ranges == nil\
\9or utils.table.is_empty(cached_language.unicode_glyph_ranges)\
\9or #cached_language.unicode_glyph_ranges == 1\
\9or not utils.number.is_odd(#cached_language.unicode_glyph_ranges)\
\9 then\
\
\9\9font_range = this.full_font_range;\
\9end\
\
\9this.font = imgui.load_font(cached_language.font_name,\
\9\9config.current_config.menu_font.size, font_range);\
\
\9if pop_push then\
\9\9imgui.pop_font();\
\9\9imgui.push_font(this.font);\
\9end\
end\
\
function this.init()\
\9label_customization.init();\
\9bar_customization.init();\
end\
\
function this.draw()\
\9local cached_config = config.current_config;\
\9local cached_language = language.current_language.customization_menu;\
\
\9local window_position = Vector2f.new(config.current_config.customization_menu.position.x, config.current_config.customization_menu.position.y);\
\9local window_pivot = Vector2f.new(config.current_config.customization_menu.pivot.x, config.current_config.customization_menu.pivot.y);\
\9local window_size = Vector2f.new(config.current_config.customization_menu.size.width, config.current_config.customization_menu.size.height);\
\
\9imgui.set_next_window_pos(window_position, 1 << 3, window_pivot);\
\9imgui.set_next_window_size(window_size, 1 << 3);\
\
\9imgui.push_font(this.font);\
\
\9this.is_opened = imgui.begin_window(\
\9\9cached_language.mod_name .. \" v\" .. config.current_config.version, this.is_opened, this.window_flags);\
\
\9if not this.is_opened then\
\9\9imgui.pop_font();\
\9\9imgui.end_window();\
\9\9return;\
\9end\
\
\9local changed = false;\
\9local config_changed = false;\
\9local enemy_filters_changed = false;\
\9local timer_delays_changed = false;\
\9local language_changed = false;\
\9local menu_font_changed = false;\
\9local window_changed = false;\
\
\9local index = 1;\
\9local language_index = 1;\
\
\9local new_window_position = imgui.get_window_pos();\
\9if window_position.x ~= new_window_position.x or window_position.y ~= new_window_position.y then\
\9\9window_changed = window_changed or true;\
\
\9\9config.current_config.customization_menu.position.x = new_window_position.x;\
\9\9config.current_config.customization_menu.position.y = new_window_position.y;\
\9end\
\
\9local new_window_size = imgui.get_window_size();\
\9if window_size.x ~= new_window_size.x or window_size.y ~= new_window_size.y then\
\9\9window_changed = window_changed or true;\
\
\9\9config.current_config.customization_menu.size.width = new_window_size.x;\
\9\9config.current_config.customization_menu.size.height = new_window_size.y;\
\9end\
\
\9if imgui.button(cached_language.reset_config) then\
\9\9config.reset();\
\9\9config_changed = true;\
\9end\
\
\9changed, cached_config.enabled = imgui.checkbox(cached_language.enabled, cached_config.enabled);\
\9config_changed = config_changed or changed;\
\
\9if imgui.tree_node(cached_language.language) then\
\9\9imgui.text(cached_language.menu_font_change_disclaimer);\
\
\9\9changed, language_index = imgui.combo(cached_language.language,\
\9\9\9utils.table.find_index(language.language_names, cached_config.language), language.language_names);\
\
\9\9config_changed = config_changed or changed;\
\9\9language_changed = language_changed or changed;\
\
\9\9imgui.tree_pop();\
\9end\
\
\9if imgui.tree_node(language.current_language.customization_menu.menu_font) then\
\9\9imgui.text(cached_language.menu_font_change_disclaimer);\
\
\9\9local new_value = cached_config.menu_font.size;\
\9\9changed, new_value = imgui.input_text(\" \", cached_config.menu_font.size, this.decimal_input_flags);\
\9\9new_value = tonumber(new_value);\
\
\9\9if new_value ~= nil then\
\9\9\9if new_value < 5 then\
\9\9\9\9new_value = 5;\
\9\9\9elseif new_value > 100 then\
\9\9\9\9new_value = 100;\
\9\9\9end\
\
\9\9\9cached_config.menu_font.size = math.floor(new_value);\
\9\9end\
\
\9\9config_changed = config_changed or changed;\
\9\9this.menu_font_changed = this.menu_font_changed or changed;\
\
\9\9imgui.same_line();\
\
\9\9changed = imgui.button(\"-\");\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.same_line();\
\
\9\9if changed then\
\9\9\9cached_config.menu_font.size = cached_config.menu_font.size - 1;\
\
\9\9\9if cached_config.menu_font.size < 5 then\
\9\9\9\9cached_config.menu_font.size = 5;\
\9\9\9else\
\9\9\9\9this.menu_font_changed = this.menu_font_changed or changed;\
\9\9\9end\
\9\9end\
\
\9\9changed = imgui.button(\"+\");\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.same_line();\
\
\9\9if changed then\
\9\9\9cached_config.menu_font.size = cached_config.menu_font.size + 1;\
\
\9\9\9if cached_config.menu_font.size > 100 then\
\9\9\9\9cached_config.menu_font.size = 100;\
\9\9\9else\
\9\9\9\9this.menu_font_changed = this.menu_font_changed or changed;\
\9\9\9end\
\9\9end\
\
\9\9imgui.text(language.current_language.customization_menu.size);\
\
\9\9if imgui.button(language.current_language.customization_menu.apply) then\
\9\9\9menu_font_changed = true;\
\9\9end\
\
\9\9imgui.tree_pop();\
\9end\
\
\9if imgui.tree_node(cached_language.ui_font) then\
\9\9imgui.text(cached_language.font_notice);\
\
\9\9changed, index = imgui.combo(cached_language.family,\
\9\9\9utils.table.find_index(this.fonts, cached_config.ui_font.family), this.fonts);\
\9\9config_changed = config_changed or changed;\
\
\9\9if changed then\
\9\9\9cached_config.ui_font.family = this.fonts[index];\
\9\9end\
\
\9\9changed, cached_config.ui_font.size = imgui.slider_int(cached_language.size,\
\9\9\9cached_config.ui_font.size, 1, 100);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.ui_font.bold = imgui.checkbox(cached_language.bold,\
\9\9\9cached_config.ui_font.bold);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.ui_font.italic = imgui.checkbox(cached_language.italic,\
\9\9\9cached_config.ui_font.italic);\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.tree_pop();\
\
\9end\
\
\9if imgui.tree_node(cached_language.settings) then\
\9\9if imgui.tree_node(language.current_language.customization_menu.timer_delays) then\
\
\9\9\9changed, cached_config.settings.timer_delays.update_singletons_delay = imgui.drag_float(\
\9\9\9\9language.current_language.customization_menu.update_singletons_delay,\
\9\9\9\9cached_config.settings.timer_delays.update_singletons_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\
\9\9\9changed, cached_config.settings.timer_delays.update_window_size_delay = imgui.drag_float(\
\9\9\9\9language.current_language.customization_menu.update_window_size_delay,\
\9\9\9\9cached_config.settings.timer_delays.update_window_size_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\9\9\9\
\9\9\9changed, cached_config.settings.timer_delays.update_game_data_delay = imgui.drag_float(\
\9\9\9\9language.current_language.customization_menu.update_game_data_delay,\
\9\9\9\9cached_config.settings.timer_delays.update_game_data_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\
\9\9\9changed, cached_config.settings.timer_delays.update_player_data_delay = imgui.drag_float(\
\9\9\9\9language.current_language.customization_menu.update_player_data_delay,\
\9\9\9\9cached_config.settings.timer_delays.update_player_data_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\
\9\9\9changed, cached_config.settings.timer_delays.update_enemy_data_delay = imgui.drag_float(\
\9\9\9\9language.current_language.customization_menu.update_enemy_data_delay,\
\9\9\9\9cached_config.settings.timer_delays.update_enemy_data_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9imgui.new_line();\
\9\9imgui.begin_rect();\
\
\9\9changed, cached_config.settings.use_d2d_if_available = imgui.checkbox(cached_language.use_d2d_renderer_if_available,\
\9\9\9cached_config.settings.use_d2d_if_available);\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect();\
\
\9\9changed, cached_config.settings.render_during_cutscenes = imgui.checkbox(cached_language.render_during_cutscenes,\
\9\9\9cached_config.settings.render_during_cutscenes);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_game_timer_is_paused = imgui.checkbox(cached_language.render_when_game_timer_is_paused,\
\9\9\9cached_config.settings.render_when_game_timer_is_paused);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_any_menu_is_opened = imgui.checkbox(cached_language.render_when_any_menu_is_opened,\
\9\9\9cached_config.settings.render_when_any_menu_is_opened);\
\9\9config_changed = config_changed or changed;\
\9\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect();\
\
\9\9changed, cached_config.settings.render_aim_target_enemy = imgui.checkbox(cached_language.render_aim_target_enemy,\
\9\9\9cached_config.settings.render_aim_target_enemy);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_damaged_enemies = imgui.checkbox(cached_language.render_damaged_enemies,\
\9\9\9cached_config.settings.render_damaged_enemies);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_everyone_else = imgui.checkbox(cached_language.render_everyone_else,\
\9\9\9cached_config.settings.render_everyone_else);\
\9\9config_changed = config_changed or changed;\
\9\9\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect()\
\9\9\
\9\9changed, cached_config.settings.render_when_normal = imgui.checkbox(cached_language.render_when_normal,\
\9\9\9cached_config.settings.render_when_normal);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_aiming = imgui.checkbox(cached_language.render_when_aiming,\
\9\9\9cached_config.settings.render_when_aiming);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_guarding = imgui.checkbox(cached_language.render_when_guarding,\
\9\9\9cached_config.settings.render_when_guarding);\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect()\
\
\9\9changed, cached_config.settings.hide_if_dead = imgui.checkbox(cached_language.hide_if_dead,\
\9\9\9cached_config.settings.hide_if_dead);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.hide_if_full_health = imgui.checkbox(cached_language.hide_if_full_health,\
\9\9\9cached_config.settings.hide_if_full_health);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.hide_if_enemy_is_not_in_sight = imgui.checkbox(cached_language.hide_if_enemy_is_not_in_sight,\
\9\9\9cached_config.settings.hide_if_enemy_is_not_in_sight);\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect()\
\
\9\9changed, cached_config.settings.opacity_falloff = imgui.checkbox(cached_language.opacity_falloff,\
\9\9\9cached_config.settings.opacity_falloff);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.max_distance = imgui.drag_float(cached_language.max_distance,\
\9\9\9cached_config.settings.max_distance, 1, 0, 10000, \"%.0f\");\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect()\
\
\9\9changed, cached_config.settings.apply_time_duration_on_aiming = imgui.checkbox(cached_language.apply_time_duration_on_aiming,\
\9\9\9cached_config.settings.apply_time_duration_on_aiming);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.apply_time_duration_on_guarding = imgui.checkbox(cached_language.apply_time_duration_on_guarding,\
\9\9\9cached_config.settings.apply_time_duration_on_guarding);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.apply_time_duration_on_aim_target = imgui.checkbox(cached_language.apply_time_duration_on_aim_target,\
\9\9\9cached_config.settings.apply_time_duration_on_aim_target);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.apply_time_duration_on_damage_dealt = imgui.checkbox(cached_language.apply_time_duration_on_damage_dealt,\
\9\9\9cached_config.settings.apply_time_duration_on_damage_dealt);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.reset_time_duration_on_aim_target_for_everyone = imgui.checkbox(cached_language.reset_time_duration_on_aim_target_for_everyone,\
\9\9\9cached_config.settings.reset_time_duration_on_aim_target_for_everyone);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.reset_time_duration_on_damage_dealt_for_everyone = imgui.checkbox(cached_language.reset_time_duration_on_damage_dealt_for_everyone,\
\9\9\9cached_config.settings.reset_time_duration_on_damage_dealt_for_everyone);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.time_duration = imgui.drag_float(cached_language.time_duration,\
\9\9\9cached_config.settings.time_duration, 0.1, 0, 1000, \"%.1f\");\
\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9\
\9\9imgui.tree_pop();\
\9end\
\
\9if imgui.tree_node(cached_language.world_offset) then\
\9\9changed, cached_config.world_offset.x = imgui.drag_float(cached_language.x,\
\9\9\9cached_config.world_offset.x, 0.01, -10, 10, \"%.2f\");\
\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.world_offset.y = imgui.drag_float(cached_language.y,\
\9\9\9cached_config.world_offset.y, 0.01, -10, 10, \"%.2f\");\
\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.world_offset.z = imgui.drag_float(cached_language.z,\
\9\9\9\9cached_config.world_offset.z, 0.01, -10, 10, \"%.2f\");\
\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.tree_pop();\
\9end\
\
\9changed = label_customization.draw(cached_language.health_value_label, cached_config.health_value_label);\
\9config_changed = config_changed or changed;\
\9\
\9changed = bar_customization.draw(cached_language.health_bar, cached_config.health_bar);\
\9config_changed = config_changed or changed;\
\
\9changed = this.draw_debug();\
\9config_changed = config_changed or changed;\
\9\
\9imgui.new_line();\
\9imgui.end_window();\
\9imgui.pop_font();\
\
\9if timer_delays_changed then\
\9\9time.init_global_timers();\
\9end\
\
\9if language_changed then\
\9\9cached_config.language = language.language_names[language_index];\
\9\9language.update(language_index);\
\9\9this.init();\
\
\9\9this.reload_font();\
\9end\
\
\9if menu_font_changed then\
\9\9this.reload_font();\
\9end\
\
\9if enemy_filters_changed then\
\9\9for enemy_core, enemy in pairs(enemy_handler.enemy_list) do\
\9\9\9enemy_handler.update_is_filtered_out(enemy);\
\9\9end\
\9end\
\
\9if config_changed or language_changed or window_changed then\
\9\9config.save();\
\9end\
end\
\
function this.draw_debug()\
\9local cached_config = config.current_config.debug;\
\
\9local changed = false;\
\9local config_changed = false;\
\
\9if imgui.tree_node(language.current_language.customization_menu.debug) then\
\9\9\
\9\9imgui.text_colored(string.format(\"%s:\", language.current_language.customization_menu.current_time), 0xFFAAAA66);\
\9\9imgui.same_line();\
\9\9imgui.text(string.format(\"%.3fs\", time.total_elapsed_script_seconds));\
\
\9\9if error_handler.is_empty then\
\9\9\9imgui.text(language.current_language.customization_menu.everything_seems_to_be_ok);\
\9\9else\
\9\9\9for error_key, error in pairs(error_handler.list) do\
\
\9\9\9\9imgui.button(string.format(\"%.3fs\", error.time));\
\9\9\9\9imgui.same_line();\
\9\9\9\9imgui.text_colored(error_key, 0xFFAA66AA);\
\9\9\9\9imgui.same_line();\
\9\9\9\9imgui.text(error.message);\
\9\9\9end\
\9\9end\
\
\9\9if imgui.tree_node(language.current_language.customization_menu.history) then\
\
\9\9\9changed, cached_config.history_size = imgui.drag_int(\
\9\9\9\9language.current_language.customization_menu.history_size, cached_config.history_size, 1, 0, 1024);\
\
\9\9\9config_changed = config_changed or changed;\
\
\9\9\9if changed then\
\9\9\9\9error_handler.history = {};\
\9\9\9end\
\
\9\9\9for index, error in pairs(error_handler.history) do\
\9\9\9\9imgui.text_colored(index, 0xFF66AA66);\
\9\9\9\9imgui.same_line();\
\9\9\9\9imgui.button(string.format(\"%.3fs\", error.time));\
\9\9\9\9imgui.same_line();\
\9\9\9\9imgui.text_colored(error.key, 0xFFAA66AA);\
\9\9\9\9imgui.same_line();\
\9\9\9\9imgui.text(error.message);\
\9\9\9end\
\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9imgui.tree_pop();\
\9end\
\
\9return config_changed;\
end\
\
function this.init_module()\
\9utils = require(\"Health_Bars.utils\");\
\9config = require(\"Health_Bars.config\");\
\9language = require(\"Health_Bars.language\");\
\9label_customization = require(\"Health_Bars.label_customization\");\
\9bar_customization = require(\"Health_Bars.bar_customization\");\
\9time = require(\"Health_Bars.time\");\
\9enemy_handler = require(\"Health_Bars.enemy_handler\");\
\9error_handler = require(\"Health_Bars.error_handler\");\
\
\9this.init();\
\9this.reload_font();\
end\
\
return this;", '@' .. ".\\Health_Bars\\customization_menu.lua"))

package.preload["Health_Bars.drawing"] = assert((loadstring or load)("local this = {};\
\
local config;\
local utils;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
this.font = nil;\
\
function this.init_font()\
\9local cached_config = config.current_config.ui_font;\
\9this.font = d2d.Font.new(cached_config.family, cached_config.size, cached_config.bold, cached_config.italic);\
end\
\
function this.argb_color_to_abgr_color(argb_color)\
\9local alpha = (argb_color >> 24) & 0xFF;\
\9local red = (argb_color >> 16) & 0xFF;\
\9local green = (argb_color >> 8) & 0xFF;\
\9local blue = argb_color & 0xFF;\
\
\9local abgr_color = 0x1000000 * alpha + 0x10000 * blue + 0x100 * green + red;\
\
\9return abgr_color;\
end\
\
function this.color_to_argb(color)\
\9local alpha = (color >> 24) & 0xFF;\
\9local red = (color >> 16) & 0xFF;\
\9local green = (color >> 8) & 0xFF;\
\9local blue = color & 0xFF;\
\
\9return alpha, red, green, blue;\
end\
\
function this.argb_to_color(alpha, red, green, blue)\
\9return 0x1000000 * alpha + 0x10000 * red + 0x100 * green + blue;\
end\
\
function this.scale_color_opacity(color, scale)\
\9local alpha, red, green, blue = this.color_to_argb(color);\
\9local new_alpha = math.floor(alpha * scale);\
\9if new_alpha < 0 then\
\9\9new_alpha = 0;\
\9end\
\9if new_alpha > 255 then\
\9\9new_alpha = 255;\
\9end\
\
\9return this.argb_to_color(new_alpha, red, green, blue);\
end\
\
function this.scale_label_opacity(label, scale)\
\9if label == nil or scale == nil or not label.visibility then\
\9\9return;\
\9end\
\
\9label.color = this.scale_color_opacity(label.color, scale);\
\9label.shadow.color = this.scale_color_opacity(label.shadow.color, scale);\
end\
\
function this.scale_bar_opacity(bar, scale)\
\9if bar == nil or scale == nil or not bar.visibility then\
\9\9return;\
\9end\
\
\9bar.colors.foreground = this.scale_color_opacity(bar.colors.foreground, scale);\
\9bar.colors.background = this.scale_color_opacity(bar.colors.background, scale);\
end\
\
function this.draw_label(label, position, opacity_scale, ...)\
\9if label == nil or not label.visibility then\
\9\9return;\
\9end\
\
\9local text = string.format(label.text_format, table.unpack({...}));\
\
\9if text == \"\" then\
\9\9return;\
\9end\
\
\9local position_x = position.x + label.offset.x;\
\9local position_y = position.y + label.offset.y;\
\
\9local use_d2d = d2d ~= nil and config.current_config.settings.use_d2d_if_available;\
\
\9if label.shadow.visibility then\
\9\9local new_shadow_color = label.shadow.color;\
\
\9\9if opacity_scale < 1 then\
\9\9\9new_shadow_color = this.scale_color_opacity(new_shadow_color, opacity_scale);\
\9\9end\
\
\9\9if use_d2d then\
\9\9\9d2d.text(this.font, text, position_x + label.shadow.offset.x, position_y + label.shadow.offset.y, new_shadow_color);\
\9\9else\
\9\9\9new_shadow_color = this.argb_color_to_abgr_color(new_shadow_color);\
\9\9\9draw.text(text, position_x + label.shadow.offset.x, position_y + label.shadow.offset.y, new_shadow_color);\
\9\9end\
\9end\
\
\9local new_color = label.color;\
\9if opacity_scale < 1 then\
\9\9new_color = this.scale_color_opacity(new_color, opacity_scale);\
\9end\
\
\9if use_d2d then\
\9\9d2d.text(this.font, text, position_x, position_y, new_color);\
\9else\
\9\9new_color = this.argb_color_to_abgr_color(new_color);\
\9\9draw.text(text, position_x, position_y, new_color);\
\9end\
end\
\
function this.draw_bar(bar, position, opacity_scale, percentage)\
\9if bar == nil or not bar.visibility then\
\9\9return;\
\9end\
\
\9if percentage > 1 then\
\9\9percentage = 1;\
\9end\
\
\9if percentage < 0 then\
\9\9percentage = 0;\
\9end\
\
\9local outline_visibility = bar.outline.visibility;\
\9local style = bar.outline.style; -- Inside/Center/Outside\
\9local fill_direction = bar.settings.fill_direction; -- Left to Right/Right to Left/Top to Bottom/Bottom to Top\
\
\9local outline_thickness = bar.outline.thickness;\
\9if not outline_visibility then\
\9\9outline_thickness = 0;\
\9end\
\
\9local half_outline_thickness = outline_thickness / 2;\
\
\9local outline_offset = bar.outline.offset;\
\
\9if outline_thickness == 0 then\
\9\9outline_offset = 0;\
\9end\
\9local half_outline_offset = outline_offset / 2;\
\
\9local outline_position_x = 0;\
\9local outline_position_y = 0;\
\
\9local outline_width = 0;\
\9local outline_height = 0;\
\
\9local position_x = 0;\
\9local position_y = 0;\
\
\9local width = 0;\
\9local height = 0;\
\
\9local foreground_width = 0;\
\9local foreground_height = 0;\
\
\9local background_width = 0;\
\9local background_height = 0;\
\
\9local foreground_shift_x = 0;\
\9local foreground_shift_y = 0;\
\
\9local background_shift_x = 0;\
\9local background_shift_y = 0;\
\
\9if style == \"Inside\" then\
\9\9outline_position_x = position.x + bar.offset.x + half_outline_thickness;\
\9\9outline_position_y = position.y + bar.offset.y + half_outline_thickness;\
\
\9\9outline_width = bar.size.width - outline_thickness;\
\9\9outline_height = bar.size.height - outline_thickness;\
\
\9\9position_x = outline_position_x + half_outline_thickness + outline_offset;\
\9\9position_y = outline_position_y + half_outline_thickness + outline_offset;\
\
\9\9width = outline_width - outline_thickness - outline_offset - outline_offset;\
\9\9height = outline_height - outline_thickness - outline_offset - outline_offset;\
\
\9elseif style == \"Center\" then\
\9\9outline_position_x = position.x + bar.offset.x - half_outline_offset;\
\9\9outline_position_y = position.y + bar.offset.y - half_outline_offset;\
\
\9\9outline_width = bar.size.width + outline_offset;\
\9\9outline_height = bar.size.height + outline_offset;\
\
\9\9position_x = outline_position_x + half_outline_thickness + outline_offset;\
\9\9position_y = outline_position_y + half_outline_thickness + outline_offset;\
\
\9\9width = outline_width - outline_thickness - outline_offset - outline_offset;\
\9\9height = outline_height - outline_thickness - outline_offset - outline_offset;\
\
\9else -- Outside\
\9\9position_x = position.x + bar.offset.x;\
\9\9position_y = position.y + bar.offset.y;\
\
\9\9width = bar.size.width;\
\9\9height = bar.size.height;\
\
\9\9outline_position_x = position_x - half_outline_thickness - outline_offset;\
\9\9outline_position_y = position_y - half_outline_thickness - outline_offset;\
\
\9\9outline_width = width + outline_thickness + outline_offset + outline_offset;\
\9\9outline_height = height + outline_thickness + outline_offset + outline_offset;\
\9end\
\
\9if fill_direction == \"Right to Left\" then\
\9\9foreground_width = width * percentage;\
\9\9foreground_height = height;\
\
\9\9background_width = width - foreground_width;\
\9\9background_height = height;\
\
\9\9foreground_shift_x = background_width;\
\
\9elseif fill_direction == \"Top to Bottom\" then\
\9\9foreground_width = width;\
\9\9foreground_height = height * percentage;\
\
\9\9background_width = width;\
\9\9background_height = height - foreground_height;\
\
\9\9background_shift_y = foreground_height;\
\
\9elseif fill_direction == \"Bottom to Top\" then\
\9\9foreground_width = width;\
\9\9foreground_height = height * percentage;\
\
\9\9background_width = width;\
\9\9background_height = height - foreground_height;\
\
\9\9foreground_shift_y = background_height;\
\
\9else -- Left to Right\
\9\9foreground_width = width * percentage;\
\9\9foreground_height = height;\
\
\9\9background_width = width - foreground_width;\
\9\9background_height = height;\
\
\9\9background_shift_x = foreground_width;\
\9end\
\
\9local foreground_color = bar.colors.foreground;\
\9local background_color = bar.colors.background;\
\9local outline_color = bar.colors.outline;\
\
\9if opacity_scale < 1 then\
\9\9foreground_color = this.scale_color_opacity(foreground_color, opacity_scale);\
\9\9background_color = this.scale_color_opacity(background_color, opacity_scale);\
\9\9outline_color = this.scale_color_opacity(outline_color, opacity_scale);\
\9end\
\
\9local use_d2d = d2d ~= nil and config.current_config.settings.use_d2d_if_available;\
\
\9-- background\
\9if background_width ~= 0 then\
\9\9if use_d2d then\
\9\9\9d2d.fill_rect(position_x + background_shift_x, position_y + background_shift_y, background_width, background_height, background_color);\
\9\9else\
\9\9\9background_color = this.argb_color_to_abgr_color(background_color);\
\9\9\9draw.filled_rect(position_x + background_shift_x, position_y + background_shift_y, background_width, background_height, background_color)\
\9\9end\
\9end\
\
\9-- foreground\
\9if foreground_width ~= 0 then\
\9\9if use_d2d then\
\9\9\9d2d.fill_rect(position_x + foreground_shift_x, position_y + foreground_shift_y, foreground_width, foreground_height, foreground_color);\
\9\9else\
\9\9\9foreground_color = this.argb_color_to_abgr_color(foreground_color);\
\9\9\9draw.filled_rect(position_x + foreground_shift_x, position_y + foreground_shift_y, foreground_width, foreground_height, foreground_color)\
\9\9end\
\9end\
\
\9-- outline\
\9if outline_thickness ~= 0 then\
\9\9if use_d2d then\
\9\9\9d2d.outline_rect(outline_position_x, outline_position_y, outline_width, outline_height, outline_thickness, outline_color);\
\9\9else\
\9\9\9outline_color = this.argb_color_to_abgr_color(outline_color);\
\9\9\9draw.outline_rect(outline_position_x, outline_position_y, outline_width, outline_height, outline_color);\
\9\9end\
\9end\
end\
\
function this.init_module()\
\9config = require(\"Health_Bars.config\");\
\9utils = require(\"Health_Bars.utils\");\
end\
\
return this;\
", '@' .. ".\\Health_Bars\\drawing.lua"))

package.preload["Health_Bars.enemy_handler"] = assert((loadstring or load)("local this = {};\
\
local utils;\
local singletons;\
local config;\
local drawing;\
local customization_menu;\
local player_handler;\
local game_handler;\
local time;\
local error_handler;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
this.enemy_list = {};\
this.enemy_game_object_list = {};\
\
local disable_is_in_sight_delay_seconds = 5;\
local health_update_delay_seconds = 1;\
\
local health_update_timer = nil;\
\
local enemy_action_controller_type_def = sdk.find_type_definition(\"app.EnemyActionController\");\
local do_update_method = enemy_action_controller_type_def:get_method(\"doUpdate\");\
local do_on_destroy_method = enemy_action_controller_type_def:get_method(\"doOnDestroy\");\
local give_damage_method = enemy_action_controller_type_def:get_method(\"giveDamage\");\
local give_die_method = enemy_action_controller_type_def:get_method(\"giveDie\");\
local get_enemy_damage_controller_method = enemy_action_controller_type_def:get_method(\"get_enemyDamageController\");\
local get_game_object_method = enemy_action_controller_type_def:get_method(\"get_GameObject\");\
local get_is_in_camera_method = enemy_action_controller_type_def:get_method(\"get_isInCameraLive\");\
local on_dead_for_stats_method = enemy_action_controller_type_def:get_method(\"onDeadForStats\");\
local spawn_method = enemy_action_controller_type_def:get_method(\"spawn\");\
local give_die_method = enemy_action_controller_type_def:get_method(\"giveDie\");\
local finish_dead_method = enemy_action_controller_type_def:get_method(\"finishDead\");\
\
local enemy_damage_controller_type_def = get_enemy_damage_controller_method:get_return_type();\
local get_health_info_method = enemy_damage_controller_type_def:get_method(\"getHealthInfo\");\
\
local health_info_type_def = get_health_info_method:get_return_type();\
local get_health_method = health_info_type_def:get_method(\"get_health\");\
local get_max_health_method = health_info_type_def:get_method(\"get_maxHealth\");\
\
local game_object_type_def = get_game_object_method:get_return_type();\
local get_transform_method = game_object_type_def:get_method(\"get_Transform\");\
\
local transform_type_def = get_transform_method:get_return_type();\
local get_joint_by_name_method = transform_type_def:get_method(\"getJointByName\");\
\
local joint_type_def = get_joint_by_name_method:get_return_type();\
local get_position_method = joint_type_def:get_method(\"get_Position\");\
\
-- Mia Attic Boss Fight\
local em_2000_action_controller_type_def = sdk.find_type_definition(\"app.Em2000.Em2000ActionController\")\
local generate_action_cancel_value_method = em_2000_action_controller_type_def:get_method(\"generateActionCancelValue\");\
\
function this.new(enemy_action_controller)\
\9local enemy = {};\
\9enemy.enemy_action_controller = enemy_action_controller;\
\
\9enemy.game_object = nil;\
\
\9enemy.health = -1;\
\9enemy.max_health = -100;\
\9enemy.health_percentage = 0;\
\9enemy.is_dead = false;\
\
\9enemy.head_joint = nil;\
\9enemy.position = Vector3f.new(0, 0, 0);\
\9enemy.distance = 0;\
\
\9enemy.is_in_sight = false;\
\9enemy.disable_is_in_sight_timer = nil;\
\9\
\9enemy.last_reset_time = 0;\
\9enemy.last_update_time = 0;\
\
\9this.update_health(enemy);\
\
\9if enemy.health == -1 or enemy.max_health == -1 then\
\9\9return nil;\
\9end\
\
\9this.update_game_object(enemy);\
\9this.update_head_joint(enemy);\
\9this.update_position(enemy);\
\
\9this.enemy_list[enemy_action_controller] = enemy;\
\9this.enemy_game_object_list[enemy.game_object] = enemy;\
\9\
\9return enemy;\
end\
\
function this.get_enemy(enemy_action_controller)\
\9local enemy = this.enemy_list[enemy_action_controller];\
\9if enemy == nil then\
\9\9enemy = this.new(enemy_action_controller);\
\9end\
\
\9return enemy;\
end\
\
function this.get_enemy_null(enemy_action_controller, create_if_not_found)\
\9if create_if_not_found == nil then\
\9\9create_if_not_found = true;\
\9end\
\
\9local enemy = this.enemy_list[enemy_action_controller];\
\9if enemy == nil and create_if_not_found then\
\9\9enemy = this.new(enemy_action_controller);\
\9end\
\
\9return enemy;\
end\
\
function this.update()\
\9for enemy_action_controller, enemy in pairs(this.enemy_list) do\
\9\9this.update_health(enemy);\
\9\9this.update_is_in_sight(enemy);\
\9end\
end\
\
function this.update_health(enemy)\
\9local enemy_damage_controller = get_enemy_damage_controller_method:call(enemy.enemy_action_controller);\
\9if enemy_damage_controller == nil then\
\9\9error_handler.report(\"enemy_handler.update_health\", \"No EnemyDamageController\");\
\9\9return;\
\9end\
\
\9local health_info = get_health_info_method:call(enemy_damage_controller);\
\9if health_info == nil then\
\9\9error_handler.report(\"enemy_handler.update_health\", \"No HealthInfo\");\
\9\9return;\
\9end\
\
\9local health = get_health_method:call(health_info);\
\9local max_health = get_max_health_method:call(health_info);\
\
\9if health == nil then\
\9\9error_handler.report(\"enemy_handler.update_health\", \"No Health\");\
\9else\
\9\9enemy.health = utils.math.round(health);\
\9end\
\
\9if max_health == nil then\
\9\9error_handler.report(\"enemy_handler.update_health\", \"No MaxHealth\");\
\9else\
\9\9enemy.max_health = utils.math.round(max_health);\
\9end\
\
\9if enemy.max_health == 0 then\
\9\9enemy.health_percentage = 0;\
\9else\
\9\9enemy.health_percentage = enemy.health / enemy.max_health;\
\9end\
\
\9enemy.is_dead = utils.number.is_equal(enemy.health, 0);\
end\
\
function this.update_is_in_sight(enemy)\
\9local is_in_camera_live = get_is_in_camera_method:call(enemy.enemy_action_controller);\
\9if is_in_camera_live == nil then\
\9\9error_handler.report(\"enemy_handler.update_is_in_sight\", \"No IsInCameraLive\");\
\9\9return;\
\9end\
\
\9if is_in_camera_live then\
\9\9enemy.is_in_sight = true;\
\9\9return;\
\9end\
\
\9if enemy.disable_is_in_sight_timer == nil then\
\9\9enemy.disable_is_in_sight_timer = time.new_delay_timer(function()\
\9\9\9enemy.is_in_sight = false;\
\9\9\9enemy.disable_is_in_sight_timer = nil;\
\9\9end, disable_is_in_sight_delay_seconds);\
\
\9\9return;\
\9end\
end\
\
function this.update_game_object(enemy)\
\9local enemy_game_object = get_game_object_method:call(enemy.enemy_action_controller);\
\9if enemy_game_object == nil then\
\9\9error_handler.report(\"enemy_handler.update_game_object\", \"No GameObject\");\
\9\9return;\
\9end\
\
\9enemy.game_object = enemy_game_object;\
end\
\
function this.update_head_joint(enemy)\
\9if enemy.game_object == nil then\
\9\9error_handler.report(\"enemy_handler.update_head_joint\", \"No GameObject\");\
\9\9return;\
\9end\
\
\9local enemy_transform = get_transform_method:call(enemy.game_object);\
\9if enemy_transform == nil then\
\9\9error_handler.report(\"enemy_handler.update_head_joint\", \"No Transform\");\
\9\9return;\
\9end\
\
\9local joint = get_joint_by_name_method:call(enemy_transform, \"head\")\
\9or get_joint_by_name_method:call(enemy_transform, \"Head\")\
\9or get_joint_by_name_method:call(enemy_transform, \"_10\") -- Bugs on cabinet\
\9or get_joint_by_name_method:call(enemy_transform, \"root\");\
\
\9if joint == nil then\
\9\9error_handler.report(\"enemy_handler.update_head_joint\", \"No Head Joint\");\
\9\9return;\
\9end\
\
\9enemy.head_joint = joint;\
end\
\
function this.update_last_reset_time(enemy)\
\9enemy.last_reset_time = time.total_elapsed_script_seconds;\
end\
\
function this.tick()\
\9this.update_all_positions();\
end\
\
function this.update_all_positions()\
\9for enemy_action_controller, enemy in pairs(this.enemy_list) do\
\9\9this.update_position(enemy);\
\9end\
end\
\
function this.update_position(enemy)\
\9if(enemy.head_joint == nil) then\
\9\9error_handler.report(\"enemy_handler.update_position\", \"No Head Joint\");\
\9\9return;\
\9end\
\
\9local head_joint_position = get_position_method:call(enemy.head_joint);\
\9if head_joint_position == nil then\
\9\9error_handler.report(\"enemy_handler.update_position\", \"No Head Joint Position\");\
\9\9return;\
\9end\
\
\9enemy.position = head_joint_position;\
\9enemy.distance = (player_handler.player.position - head_joint_position):length();\
\
\9-- this.update_health(enemy);\
end\
\
function this.draw_enemies()\
\9local cached_config = config.current_config;\
\9local cached_settings_config = cached_config.settings;\
\9local cached_world_offset_config = cached_config.world_offset;\
\
\9if not cached_settings_config.render_during_cutscenes and game_handler.game.is_cutscene_playing then\
\9\9return;\
\9end\
\
\9if not cached_settings_config.render_when_game_timer_is_paused and game_handler.game.is_paused then\
\9\9return;\
\9end\
\
\9if not cached_settings_config.render_when_any_menu_is_opened and game_handler.game.is_menu_opened then\
\9\9return;\
\9end\
\
\9if player_handler.player.is_aiming then\
\9\9if not cached_settings_config.render_when_aiming then\
\9\9\9return;\
\9\9end\
\9elseif player_handler.player.is_guarding then\
\9\9if not cached_settings_config.render_when_guarding then\
\9\9\9return;\
\9\9end\
\9elseif not cached_settings_config.render_when_normal then\
\9\9return;\
\9end\
\
\9local max_distance = cached_settings_config.max_distance;\
\
\9for enemy_action_controller, enemy in pairs(this.enemy_list) do\
\9\9if max_distance ~= 0 and enemy.distance > max_distance then\
\9\9\9goto continue;\
\9\9end\
\
\9\9if enemy.max_health <= 1 then\
\9\9\9goto continue;\
\9\9end\
\
\9\9if enemy.position.x == 0 and enemy.position.y == 0 and enemy.position.z == 0 then\
\9\9\9goto continue;\
\9\9end\
\
\9\9local is_time_duration_on = false;\
\
\9\9if cached_settings_config.apply_time_duration_on_aiming\
\9\9or cached_settings_config.apply_time_duration_on_guarding\
\9\9or cached_settings_config.apply_time_duration_on_aim_target\
\9\9or cached_settings_config.apply_time_duration_on_damage_dealt then\
\9\9\9if cached_settings_config.time_duration ~= 0 then\
\9\9\9\9if time.total_elapsed_script_seconds - enemy.last_reset_time > cached_settings_config.time_duration then\
\9\9\9\9\9goto continue;\
\9\9\9\9else\
\9\9\9\9\9is_time_duration_on = true;\
\9\9\9\9end\
\9\9\9end\
\9\9end\
\
\9\9if not cached_settings_config.render_aim_target_enemy\
\9\9and enemy.game_object == player_handler.player.aim_target\
\9\9and not is_time_duration_on then\
\9\9\9goto continue;\
\9\9end\
\
\9\9if not cached_settings_config.render_damaged_enemies\
\9\9and not utils.number.is_equal(enemy.health, enemy.max_health)\
\9\9and not is_time_duration_on then\
\9\9\9if enemy.game_object == player_handler.player.aim_target then\
\9\9\9\9if not cached_settings_config.render_aim_target_enemy then\
\9\9\9\9\9goto continue;\
\9\9\9\9end\
\9\9\9else\
\9\9\9\9goto continue;\
\9\9\9end\
\9\9end\
\
\9\9if not cached_settings_config.render_everyone_else\
\9\9and enemy.game_object ~= player_handler.player.aim_target\
\9\9and utils.number.is_equal(enemy.health, enemy.max_health)\
\9\9and not is_time_duration_on then\
\9\9\9goto continue;\
\9\9end\
\
\9\9if cached_settings_config.hide_if_dead\
\9\9and enemy.is_dead then\
\9\9\9goto continue;\
\9\9end\
\
\9\9if cached_settings_config.hide_if_full_health\
\9\9and utils.number.is_equal(enemy.health, enemy.max_health) then\
\9\9\9goto continue;\
\9\9end\
\
\9\9if cached_settings_config.hide_if_enemy_is_not_in_sight\
\9\9and not enemy.is_in_sight then\
\9\9\9goto continue;\
\9\9end\
\
\9\9local world_offset = Vector3f.new(cached_world_offset_config.x, cached_world_offset_config.y, cached_world_offset_config.z);\
\
\9\9local position_on_screen = draw.world_to_screen(enemy.position + world_offset);\
\9\9if position_on_screen == nil then\
\9\9\9goto continue;\
\9\9end\
\
\9\9local opacity_scale = 1;\
\9\9if cached_settings_config.opacity_falloff and max_distance ~= 0 then\
\9\9\9opacity_scale = 1 - (enemy.distance / max_distance);\
\9\9end\
\
\9\9local health_value_text = \"\";\
\
\9\9local health_value_label = cached_config.health_value_label;\
\9\9local health_value_include = health_value_label.include;\
\9\9local right_alignment_shift = health_value_label.settings.right_alignment_shift;\
\
\9\9if health_value_include.current_value then\
\9\9\9health_value_text = string.format(\"%.0f\", enemy.health);\
\
\9\9\9if health_value_include.max_value then\
\9\9\9\9health_value_text = string.format(\"%s/%.0f\", health_value_text, enemy.max_health);\
\9\9\9end\
\9\9elseif health_value_include.max_value then\
\9\9\9health_value_text = string.format(\"%.0f\", enemy.max_health);\
\9\9end\
\
\9\9if right_alignment_shift ~= 0 then\
\9\9\9local right_aligment_format = string.format(\"%%%ds\", right_alignment_shift);\
\9\9\9health_value_text = string.format(right_aligment_format, health_value_text);\
\9\9end\
\
\9\9drawing.draw_bar(cached_config.health_bar, position_on_screen, opacity_scale, enemy.health_percentage);\
\9\9drawing.draw_label(health_value_label, position_on_screen, opacity_scale, health_value_text);\
\9\9\
\9\9::continue::\
\9end\
end\
\
function this.on_update(enemy_action_controller)\
\9local enemy = this.get_enemy(enemy_action_controller);\
end\
\
function this.on_destroy(enemy_action_controller)\
\9local enemy = this.get_enemy(enemy_action_controller);\
\9if enemy == nil then\
\9\9return;\
\9end\
\
\9this.enemy_list[enemy_action_controller] = nil;\
\9this.enemy_game_object_list[enemy.game_object] = nil;\
end\
\
function this.on_damage(enemy_action_controller)\
\9local enemy = this.get_enemy(enemy_action_controller);\
\9if enemy == nil then\
\9\9return;\
\9end\
\
\9this.update_health(enemy);\
\9this.on_damage_or_die(enemy)\
\
\9enemy.is_in_sight = true;\
\
\9time.remove_delay_timer(enemy.disable_is_in_sight_timer);\
\9enemy.disable_is_in_sight_timer = nil;\
end\
\
function this.on_die(enemy_action_controller)\
\9local enemy = this.get_enemy(enemy_action_controller);\
\9if enemy == nil then\
\9\9return;\
\9end\
\
\9this.update_health(enemy);\
\9enemy.is_dead = true;\
\9this.on_damage_or_die(enemy);\
end\
\
function this.on_damage_or_die(attacked_enemy)\
\9local cached_config = config.current_config.settings;\
\
\9if cached_config.reset_time_duration_on_damage_dealt_for_everyone then\
\9\9for enemy_action_controller, enemy in pairs(this.enemy_list) do\
\9\9\9if time.total_elapsed_script_seconds - enemy.last_reset_time < cached_config.time_duration then\
\9\9\9\9this.update_last_reset_time(enemy);\
\9\9\9end\
\9\9end\
\9end\
\
\9if cached_config.apply_time_duration_on_damage_dealt then\
\9\9this.update_last_reset_time(attacked_enemy);\
\9end\
end\
\
function this.init_module()\
\9utils = require(\"Health_Bars.utils\");\
\9config = require(\"Health_Bars.config\");\
\9singletons = require(\"Health_Bars.singletons\");\
\9drawing = require(\"Health_Bars.drawing\");\
\9customization_menu = require(\"Health_Bars.customization_menu\");\
\9player_handler = require(\"Health_Bars.player_handler\");\
\9game_handler = require(\"Health_Bars.game_handler\");\
\9time = require(\"Health_Bars.time\");\
\9error_handler = require(\"Health_Bars.error_handler\");\
\
\9sdk.hook(do_update_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9this.on_update(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(generate_action_cancel_value_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9this.on_damage(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(give_damage_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\
\9\9this.on_damage(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(give_die_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\
\9\9this.on_die(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(do_on_destroy_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9this.on_destroy(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(on_dead_for_stats_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9this.on_die(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(spawn_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9this.on_update(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(finish_dead_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9this.on_die(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(give_die_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9this.on_die(enemy_action_controller);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
end\
\
return this;", '@' .. ".\\Health_Bars\\enemy_handler.lua"))

package.preload["Health_Bars.error_handler"] = assert((loadstring or load)("local this = {};\
\
local time;\
local utils;\
local config;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
local ValueType = ValueType;\
local package = package;\
\
this.list = {};\
this.is_empty = true;\
\
this.history = {};\
\
function this.report(error_key, error_message)\
\9if error_key == nil or error_key == \"\"\
\9or error_message == nil or error_message == \"\" then\
\9\9return;\
\9end\
\
\9local error_time = time.total_elapsed_script_seconds;\
\
\9if utils.number.is_equal(error_time, 0) then\
\9\9return;\
\9end\
\
\9local error = {\
\9\9key = error_key,\
\9\9time = error_time,\
\9\9message = error_message\
\9};\
\
\9this.list[error_key] = error;\
\9this.is_empty = false;\
\
\9this.add_to_history(error_key, error);\
end\
\
function this.add_to_history(error_key, error)\
\9this.clear_history();\
\
\9table.insert(this.history, error);\
end\
\
function this.clear_history()\
\9local history_size = config.current_config.debug.history_size;\
\
\9while #this.history >= history_size do\
\9\9table.remove(this.history, 1);\
\9end\
end\
\
function this.init_module()\
\9time = require(\"Health_Bars.time\");\
\9utils = require(\"Health_Bars.utils\");\
\9config = require(\"Health_Bars.config\");\
end\
\
return this;", '@' .. ".\\Health_Bars\\error_handler.lua"))

package.preload["Health_Bars.game_handler"] = assert((loadstring or load)("local this = {};\
\
local singletons;\
local error_handler;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
this.game = {};\
this.game.is_paused = false;\
this.game.is_menu_opened = false;\
this.game.is_cutscene_playing = false;\
\
local is_initialized = false;\
\
local game_manager_type_def = sdk.find_type_definition(\"app.GameManager\");\
local request_event_method = game_manager_type_def:get_method(\"requestEvent\");\
local pause_manager_field = game_manager_type_def:get_field(\"PauseManager\");\
local game_event_man_field = game_manager_type_def:get_field(\"_GameEventMan\");\
\
local pause_manager_type_def = pause_manager_field:get_type();\
local get_is_pause_method = pause_manager_type_def:get_method(\"get_isPause\");\
local exec_method = pause_manager_type_def:get_method(\"exec\");\
\
local game_event_manager_type_def = game_event_man_field:get_type();\
local running_event_controllers_field = game_event_manager_type_def:get_field(\"RunningEventControllers\");\
\
local running_event_controllers_list = running_event_controllers_field:get_type();\
local running_event_controllers_list_get_count_method = running_event_controllers_list:get_method(\"get_Count\");\
\
local menu_manager_type_def = sdk.find_type_definition(\"app.MenuManager\");\
local is_exist_stack_open_menu_method = menu_manager_type_def:get_method(\"isExistStackOpenMenu\");\
\
function this.update()\
\9this.update_is_cutscene();\
\9this.update_is_menu_opened();\
end\
\
function this.update_is_cutscene()\
\9if is_initialized and not this.game.is_cutscene_playing then\
\9\9return;\
\9end\
\
\9local game_manager = singletons.game_manager;\
\9if game_manager == nil then\
\9\9error_handler.report(\"game_handler.update_is_cutscene\", \"No GameManager\");\
\9\9return;\
\9end\
\
\9local game_event_manager = game_event_man_field:get_data(game_manager);\
\9if game_event_manager == nil then\
\9\9error_handler.report(\"game_handler.update_is_cutscene\", \"No GameEventManager\");\
\9\9return;\
\9end\
\
\9local running_event_controllers = running_event_controllers_field:get_data(game_event_manager);\
\9if running_event_controllers == nil then\
\9\9error_handler.report(\"game_handler.update_is_cutscene\", \"No RunningEventControllers\");\
\9\9return;\
\9end\
\
\9local count = running_event_controllers_list_get_count_method:call(running_event_controllers);\
\9if count == nil then\
\9\9error_handler.report(\"game_handler.update_is_cutscene\", \"No RunningEventControllers -> Count\");\
\9\9return;\
\9end\
\
\9this.game.is_cutscene_playing = count ~= 0;\
end\
\
function this.update_is_menu_opened()\
\9local menu_manager = singletons.menu_manager;\
\9if menu_manager == nil then\
\9\9error_handler.report(\"game_handler.update_is_menu_opened\", \"No MenuManager\");\
\9\9return;\
\9end\
\
\9local is_exist_stack_open_menu =  is_exist_stack_open_menu_method:call(menu_manager);\
\9if is_exist_stack_open_menu == nil then\
\9\9error_handler.report(\"game_handler.update_is_menu_opened\", \"No IsExistStackOpenMenu\");\
\9\9return;\
\9end\
\
\9this.game.is_menu_opened = is_exist_stack_open_menu;\
end\
\
function this.init()\
\9local game_manager = singletons.game_manager;\
\9if game_manager == nil then\
\9\9error_handler.report(\"game_handler.init\", \"No GameManager\");\
\9\9return;\
\9end\
\
\9local pause_manager = pause_manager_field:get_data(game_manager);\
\9if pause_manager == nil then\
\9\9error_handler.report(\"game_handler.init\", \"No PauseManager\");\
\9\9return;\
\9end\
\
\9local is_pause = get_is_pause_method:call(pause_manager);\
\9if is_pause == nil then\
\9\9error_handler.report(\"game_handler.init\", \"No IsPause\");\
\9\9return;\
\9end\
\
\9this.game.is_paused = is_pause;\
\
\9this.update_is_cutscene();\
\
\9is_initialized = true;\
end\
\
function this.on_exec(is_request_pause)\
\9if is_request_pause == nil then\
\9\9error_handler.report(\"game_handler.on_exec\", \"No IsRequestPause\");\
\9\9return;\
\9end\
\
\9this.game.is_paused = is_request_pause;\
end\
\
function this.on_request_event()\
\9this.game.is_cutscene_playing = true;\
end\
\
function this.init_module()\
\9singletons = require(\"Health_Bars.singletons\");\
\9error_handler = require(\"Health_Bars.error_handler\");\
\
\9this.init();\
\
\9sdk.hook(exec_method, function(args)\
\9\9local is_request_pause = (sdk.to_int64(args[3]) & 1) == 1;\
\9\9this.on_exec(is_request_pause);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(request_event_method, function(args)\
\9\9this.on_request_event();\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
end\
\
return this;", '@' .. ".\\Health_Bars\\game_handler.lua"))

package.preload["Health_Bars.label_customization"] = assert((loadstring or load)("local this = {};\
\
local utils;\
local config;\
local language;\
local screen;\
local customization_menu;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
local include_names = {};\
\
function this.init()\
\9local cached_current_language = language.current_language.customization_menu;\
\
\9include_names = {\
\9\9[\"current_value\"] = cached_current_language.current_value,\
\9\9[\"max_value\"] = cached_current_language.max_value\
\9};\
end\
\
function this.draw(label_name, label)\
\9local cached_language = language.current_language.customization_menu;\
\
\9local label_changed = false;\
\9local changed = false;\
\
\9if imgui.tree_node(label_name) then\
\9\9changed, label.visibility = imgui.checkbox(cached_language.visible, label.visibility);\
\9\9label_changed = label_changed or changed;\
\
\9\9if imgui.tree_node(cached_language.settings) then\
\9\9\9changed, label.settings.right_alignment_shift =imgui.slider_int(cached_language.right_alignment_shift, label.settings.right_alignment_shift, 0, 32);\
\9\9\9label_changed = label_changed or changed;\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\
\9\9if label.include ~= nil then\
\9\9\9if imgui.tree_node(cached_language.include) then\
\9\9\9\9for include_name, include in pairs(label.include) do\
\9\9\9\9\9changed, label.include[include_name] = imgui.checkbox(include_names[include_name], include);\
\9\9\9\9\9label_changed = label_changed or changed;\
\9\9\9\9end\
\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\9\9end\
\9\9\
\9\9-- add text format\
\
\9\9if imgui.tree_node(cached_language.offset) then\
\9\9\9changed, label.offset.x = imgui.drag_float(cached_language.x, label.offset.x, 0.1, -screen.width, screen.width, \"%.1f\");\
\9\9\9label_changed = label_changed or changed;\
\
\9\9\9changed, label.offset.y = imgui.drag_float(cached_language.y, label.offset.y, 0.1, -screen.height, screen.height, \"%.1f\");\
\9\9\9label_changed = label_changed or changed;\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9if imgui.tree_node(cached_language.color) then\
\9\9\9changed, label.color = imgui.color_picker_argb(\"\", label.color, customization_menu.color_picker_flags);\
\9\9\9label_changed = label_changed or changed;\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9if imgui.tree_node(cached_language.shadow) then\
\9\9\9changed, label.shadow.visibility = imgui.checkbox(cached_language.visible, label.shadow.visibility);\
\9\9\9label_changed = label_changed or changed;\
\
\9\9\9if imgui.tree_node(cached_language.offset) then\
\9\9\9\9changed, label.shadow.offset.x = imgui.drag_float(cached_language.x,\
\9\9\9\9\9label.shadow.offset.x, 0.1, -screen.width, screen.width, \"%.1f\");\
\9\9\9\9label_changed = label_changed or changed;\
\
\9\9\9\9changed, label.shadow.offset.y = imgui.drag_float(cached_language.y,\
\9\9\9\9\9label.shadow.offset.y, 0.1, -screen.height, screen.height, \"%.1f\");\
\9\9\9\9label_changed = label_changed or changed;\
\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\
\9\9\9if imgui.tree_node(cached_language.color) then\
\9\9\9\9changed, label.shadow.color = imgui.color_picker_argb(\"\", label.shadow.color, customization_menu.color_picker_flags);\
\9\9\9\9label_changed = label_changed or changed;\
\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9imgui.tree_pop();\
\9end\
\
\9return label_changed;\
end\
\
function this.init_module()\
\9utils = require(\"Health_Bars.utils\");\
\9config = require(\"Health_Bars.config\");\
\9language = require(\"Health_Bars.language\");\
\9screen = require(\"Health_Bars.screen\");\
\9customization_menu = require(\"Health_Bars.customization_menu\");\
end\
\
return this;", '@' .. ".\\Health_Bars\\label_customization.lua"))

package.preload["Health_Bars.language"] = assert((loadstring or load)("local this = {};\
\
local utils;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
local ValueType = ValueType;\
local package = package;\
\
this.language_folder = \"Health Bars\\\\languages\\\\\";\
\
this.current_language = {};\
\
--[[\
\9EXAMPLE: \
\9unicode_glyph_ranges = {\
\9\0090x0020, 0x00FF, -- Basic Latin + Latin Supplement\
\9\0090x2000, 0x206F, -- General Punctuation\
\9\0090x3000, 0x30FF, -- CJK Symbols and Punctuations, Hiragana, Katakana\
\9\0090x31F0, 0x31FF, -- Katakana Phonetic Extensions\
\9\0090x4e00, 0x9FAF, -- CJK Ideograms\
\9\0090xFF00, 0xFFEF, -- Half-width characters\
\9\0090\
\9},\
]]\
\
this.default_language = {\
\9font_name = \"\",\
\9unicode_glyph_ranges = {0},\
\9\
\9customization_menu = {\
\9\9mod_name = \"Health Bars\";\
\
\9\9enabled = \"Enabled\",\
\9\9reset_config = \"Reset Config\",\
\
\9\9menu_font_change_disclaimer = \"Changing Language and Menu Font Size several times will cause a crash!\",\
\9\9language = \"Language\",\
\9\9apply = \"Apply\",\
\
\9\9ui_font = \"UI Font\",\
\9\9menu_font = \"Menu Font\",\
\9\9font_notice = \"Any changes to the font require script reload!\",\
\9\9family = \"Family\",\
\9\9size = \"Size\",\
\9\9bold = \"Bold\",\
\9\9italic = \"Italic\",\
\
\9\9settings = \"Settings\",\
\9\9use_d2d_renderer_if_available = \"Use Direct2D Renderer if Available\",\
\9\9render_during_cutscenes = \"Render during Cutscenes\",\
\9\9render_when_game_timer_is_paused = \"Render when Game Timer Is Paused\",\
\9\9render_when_any_menu_is_opened = \"Render when Any Menu Is Opened\",\
\
\9\9render_aim_target_enemy = \"Render Aim Target Enemy\",\
\9\9render_damaged_enemies = \"Render Damaged Enemies\",\
\9\9render_everyone_else = \"Render Everyone Else\",\
\9\9\
\9\9render_when_normal = \"Render when Normal\",\
\9\9render_when_aiming = \"Render when Aiming\",\
\9\9render_when_guarding = \"Render when Guarding\",\
\
\9\9hide_if_dead = \"Hide if Dead\",\
\9\9hide_if_full_health = \"Hide if Full Health\",\
\9\9hide_if_enemy_is_not_in_sight = \"Hide if Enemy Is Not in Sight\",\
\
\9\9opacity_falloff = \"Opacity Falloff\",\
\9\9max_distance = \"Max Distance\",\
\
\9\9apply_time_duration_on_aiming = \"Apply Time Duration on Aiming\",\
\9\9apply_time_duration_on_guarding = \"Apply Time Duration on Guarding\",\
\9\9apply_time_duration_on_aim_target = \"Apply Time Duration on Aim Target\",\
\9\9apply_time_duration_on_damage_dealt = \"Apply Time Duration on Damage Dealt\",\
\9\9reset_time_duration_on_aim_target_for_everyone = \"Reset Time Duration on Aim Target for Everyone\",\
\9\9reset_time_duration_on_damage_dealt_for_everyone = \"Reset Time Duration on Damage Dealt for Everyone\",\
\9\9time_duration = \"Time Duration (sec)\",\
\
\9\9world_offset = \"World Offset\",\
\9\9x = \"X\",\
\9\9y = \"Y\",\
\9\9z = \"Z\",\
\
\9\9health_value_label = \"Health Value Label\",\
\9\9health_bar = \"Health Bar\",\
\
\9\9visible = \"Visible\",\
\9\9right_alignment_shift = \"Right Alignment Shift\",\
\
\9\9include = \"Include\",\
\9\9current_value = \"Current Value\",\
\9\9max_value = \"Max Value\",\
\9\9\
\9\9offset = \"Offset\",\
\9\9color = \"Color\",\
\9\9shadow = \"Shadow\",\
\
\9\9fill_type = \"Fill Type\",\
\9\9left_to_right = \"Left to Right\",\
\9\9right_to_left = \"Right to Left\",\
\9\9top_to_bottom = \"Top to Bottom\",\
\9\9bottom_to_top = \"Bottom to Top\",\
\
\9\9width = \"Width\",\
\9\9height = \"Height\",\
\
\9\9outline = \"Outline\",\
\9\9thickness = \"Thickness\",\
\9\9style = \"Style\",\
\9\9inside = \"Inside\",\
\9\9center = \"Center\",\
\9\9outside = \"Outside\",\
\
\9\9colors = \"Colors\",\
\9\9foreground = \"Foreground\",\
\9\9background = \"Background\",\
\
\9\9timer_delays = \"Timer Delays\",\
\
\9\9update_singletons_delay = \"Update Singletons (sec)\",\
\9\9update_window_size_delay = \"Update Window Size (sec)\",\
\9\9update_game_data_delay = \"Update Game Data (sec)\",\
\9\9update_player_data_delay = \"Update Player Data (sec)\",\
\9\9update_enemy_data_delay = \"Update Enemy Data (sec)\",\
\
\9\9debug = \"Debug\",\
\9\9current_time = \"Current Time\",\
\9\9everything_seems_to_be_ok = \"Everything seems to be OK!\",\
\9\9history = \"History\",\
\9\9history_size = \"History Size\",\
\9}\
};\
\
this.language_names = { \"default\" };\
this.languages = { this.default_language };\
\
function this.load()\
\9local language_files = fs.glob([[Health Bars\\\\languages\\\\.*json]]);\
\
\9if language_files == nil then\
\9\9return;\
\9end\
\
\9for i, language_file_name in ipairs(language_files) do\
\
\9\9local language_name = language_file_name:gsub(this.language_folder, \"\"):gsub(\".json\",\"\");\
\
\9\9local loaded_language = json.load_file(language_file_name);\
\9\9if loaded_language ~= nil then\
\
\9\9\9log.info(\"[Health Bars] \" .. language_file_name .. \".json loaded successfully\");\
\9\9\9table.insert(this.language_names, language_name);\
\
\9\9\9local merged_language = utils.table.merge(this.default_language, loaded_language);\
\9\9\9table.insert(this.languages, merged_language);\
\
\9\9\9this.save(language_file_name, merged_language);\
\9\9else\
\9\9\9log.error(\"[Health Bars] Failed to load \" .. language_file_name .. \".json\");\
\9\9end\
\9end\
end\
\
function this.save(file_name, language_table)\
\9local success = json.dump_file(file_name, language_table);\
\9if success then\
\9\9log.info(\"[Health Bars] \" .. file_name .. \" saved successfully\");\
\9else\
\9\9log.error(\"[Health Bars] Failed to save \" .. file_name);\
\9end\
end\
\
function this.save_default()\
\9this.save(this.language_folder .. \"en-us.json\", this.default_language);\
end\
\
function this.update(index)\
\9this.current_language = this.languages[index];\
end\
\
function this.init_module()\
\9utils = require(\"Health_Bars.utils\");\
\9\
\9this.save_default();\
\9this.load();\
\9this.current_language = this.default_language;\
end\
\
return this;\
", '@' .. ".\\Health_Bars\\language.lua"))

package.preload["Health_Bars.player_handler"] = assert((loadstring or load)("local this = {};\
\
local utils;\
local singletons;\
local error_handler;\
local enemy_handler;\
local time;\
local config;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
this.player = {};\
this.player.position = Vector3f.new(0, 0, 0);\
this.player.is_aiming = false;\
this.player.is_guarding = false;\
this.player.aim_target = nil;\
\
local interact_manager_type_def = sdk.find_type_definition(\"app.InteractManager\");\
local interact_player_status_field = interact_manager_type_def:get_field(\"_PlayerStatus\");\
\
local player_status_type_def = sdk.find_type_definition(\"app.PlayerStatus\");\
local player_camera_field = player_status_type_def:get_field(\"PlayerCamera\");\
\
local player_camera_type_def = player_camera_field:get_type();\
local get_camera_position_method = player_camera_type_def:get_method(\"get_CameraPosition\");\
local look_target_hit_result_field = player_camera_type_def:get_field(\"LookTargetHitResult\");\
\
local hit_result_type_def = look_target_hit_result_field:get_type();\
local game_object_field = hit_result_type_def:get_field(\"GameObject\");\
\
local inventory_manager_type_def = sdk.find_type_definition(\"app.InventoryManager\");\
local inventory_field = inventory_manager_type_def:get_field(\"_Inventory\");\
\
local inventory_type_def = inventory_field:get_type();\
local player_status_field = inventory_type_def:get_field(\"PlayerStatus\");\
\
local player_status_type_def = sdk.find_type_definition(\"app.PlayerStatus\");\
local get_is_aim_method = player_status_type_def:get_method(\"get_IsAim\");\
local get_is_guard_method = player_status_type_def:get_method(\"get_isGuard\");\
\
function this.tick()\
\9this.update_position();\
end\
\
function this.update()\
\9local inventory_manager = singletons.inventory_manager;\
\9if inventory_manager == nil then\
\9\9error_handler.report(\"player_handler.update\", \"No InventoryManager\");\
\9\9return;\
\9end\
\
\9local inventory = inventory_field:get_data(inventory_manager);\
\9if inventory == nil then\
\9\9return;\
\9end\
\
\9local player_status = player_status_field:get_data(inventory);\
\9if player_status == nil then\
\9\9-- error_handler.report(\"player_handler.update\", \"No PlayerStatus\");\
\9\9return;\
\9end\
\
\9this.update_is_aiming(player_status);\
\9this.update_is_guarding(player_status);\
\9this.update_aim_target();\
end\
\
function this.update_position()\
\9local interact_manager = singletons.interact_manager;\
\9if interact_manager == nil then\
\9\9error_handler.report(\"player_handler.update_position\", \"No InteractManager\");\
\9\9return;\
\9end\
\
\9local player_status = interact_player_status_field:get_data(interact_manager);\
\9if player_status == nil then\
\9\9error_handler.report(\"player_handler.update_position\", \"No PlayerStatus\");\
\9\9return;\
\9end\
\
\9local player_camera = player_camera_field:get_data(player_status);\
\9if player_camera == nil then\
\9\9-- error_handler.report(\"player_handler.update_position\", \"No PlayerCamera\");\
\9\9return;\
\9end\
\
\9local position = get_camera_position_method:call(player_camera);\
\9if position == nil then\
\9\9error_handler.report(\"player_handler.update_position\", \"No Position\");\
\9\9return;\
\9end\
\
\9this.player.position = position;\
end\
\
function this.update_is_aiming(player_status)\
\9local cached_config = config.current_config.settings;\
\
\9local is_aim = get_is_aim_method:call(player_status);\
\9if is_aim == nil then\
\9\9error_handler.report(\"player_handler.update_is_aiming\", \"No IsAim\");\
\9\9return;\
\9end\
\
\9this.player.is_aiming = is_aim;\
\
\9if is_aim and cached_config.apply_time_duration_on_aiming then\
\9\9for enemy_context, enemy in pairs(enemy_handler.enemy_list) do\
\9\9\9enemy_handler.update_last_reset_time(enemy);\
\9\9end\
\9end\
end\
\
function this.update_is_guarding(player_status)\
\9local cached_config = config.current_config.settings;\
\
\9local is_guard = get_is_guard_method:call(player_status);\
\9if is_guard == nil then\
\9\9error_handler.report(\"player_handler.update_is_guarding\", \"No IsGuard\");\
\9\9return;\
\9end\
\
\9this.player.is_guarding = is_guard;\
\
\9if is_guard and cached_config.apply_time_duration_on_guarding then\
\9\9for enemy_context, enemy in pairs(enemy_handler.enemy_list) do\
\9\9\9enemy_handler.update_last_reset_time(enemy);\
\9\9end\
\9end\
end\
\
function this.update_aim_target()\
\9local cached_config = config.current_config.settings;\
\
\9local interact_manager = singletons.interact_manager;\
\9if interact_manager == nil then\
\9\9error_handler.report(\"player_handler.update_aim_target\", \"No InteractManager\");\
\9\9return;\
\9end\
\
\9local player_status = interact_player_status_field:get_data(interact_manager);\
\9if player_status == nil then\
\9\9error_handler.report(\"player_handler.update_aim_target\", \"No PlayerStatus\");\
\9\9return;\
\9end\
\
\9local player_camera = player_camera_field:get_data(player_status);\
\9if player_camera == nil then\
\9\9error_handler.report(\"player_handler.update_aim_target\", \"No PlayerCamera\");\
\9\9return;\
\9end\
\
\9local look_target_hit_result = look_target_hit_result_field:get_data(player_camera);\
\9if look_target_hit_result == nil then\
\9\9error_handler.report(\"player_handler.update_aim_target\", \"No LookTargetHitResult\");\
\9\9return;\
\9end\
\
\9local game_object = game_object_field:get_data(look_target_hit_result);\
\9if game_object == nil then\
\9\9-- error_handler.report(\"player_handler.update_aim_target\", \"No GameObject\");\
\9\9return;\
\9end\
\
\9if game_object == nil then\
\9\9return;\
\9end\
\
\9local target_enemy = enemy_handler.enemy_game_object_list[game_object];\
\9if target_enemy == nil then\
\9\9--error_handler.report(\"player_handler.update_aim_target\", \"No AimTargetEnemy\");\
\9\9return;\
\9end\
\
\9if cached_config.reset_time_duration_on_aim_target_for_everyone then\
\9\9for enemy_context, enemy in pairs(enemy_handler.enemy_list) do\
\9\9\9if time.total_elapsed_script_seconds - enemy.last_reset_time < cached_config.time_duration then\
\9\9\9\9enemy_handler.update_last_reset_time(enemy);\
\9\9\9end\
\9\9end\
\9end\
\9\
\9if cached_config.apply_time_duration_on_aim_target then\
\9\9enemy_handler.update_last_reset_time(target_enemy);\
\9end\
\
\9this.player.aim_target = game_object;\
end\
\
function this.init_module()\
\9utils = require(\"Health_Bars.utils\");\
\9singletons = require(\"Health_Bars.singletons\");\
\9error_handler = require(\"Health_Bars.error_handler\");\
\9enemy_handler = require(\"Health_Bars.enemy_handler\");\
\9time = require(\"Health_Bars.time\");\
\9config = require(\"Health_Bars.config\");\
end\
\
return this;", '@' .. ".\\Health_Bars\\player_handler.lua"))

package.preload["Health_Bars.screen"] = assert((loadstring or load)("local this = {};\
\
local config;\
local singletons;\
local utils;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
this.width = 1920;\
this.height = 1080;\
\
local scene_view;\
local scene_view_type = sdk.find_type_definition(\"via.SceneView\");\
local get_size_method = scene_view_type:get_method(\"get_Size\");\
\
local size_type = get_size_method:get_return_type();\
local width_field = size_type:get_field(\"w\");\
local height_field = size_type:get_field(\"h\");\
\
function this.update_window_size()\
\9local width;\
\9local height;\
\
\9--if d2d ~= nil and config.current_config.settings.use_d2d_if_available then\
\9--\9local success, d2d_width, d2d_height = pcall(d2d.surface_size);\
\9--\9if success then\
\9--\9\9width = d2d_width;\
\9--\9\9height = d2d_height;\
\9--\9else\
\9--\9\9width, height = this.get_game_window_size();\
\9--\9end\
\9--else\
\9--\9width, height = this.get_game_window_size();\
\9--end\
\
\9width, height = this.get_game_window_size();\
\
\9if width ~= nil then\
\9\9this.width = width;\
\9end\
\
\9if height ~= nil then\
\9\9this.height = height;\
\9end\
end\
\
function this.get_game_window_size()\
\9if scene_view == nil then\
\9\9if singletons.scene_manager == nil then\
\9\9\9return;\
\9\9end\
\
\9\9scene_view = sdk.call_native_func(singletons.scene_manager, sdk.find_type_definition(\"via.SceneManager\"), \"get_MainView\");\
\
\9\9if scene_view == nil then\
\9\9\9return;\
\9\9end\
\9end\
\
\9local size = get_size_method:call(scene_view);\
\9if size == nil then\
\9\9return;\
\9end\
\
\9local screen_width = width_field:get_data(size);\
\9if screen_width == nil then\
\9\9return;\
\9end\
\
\9local screen_height = height_field:get_data(size);\
\9if screen_height == nil then\
\9\9return;\
\9end\
\
\9return screen_width, screen_height;\
end\
\
function this.init_module()\
\9config = require(\"Health_Bars.config\");\
\9singletons = require(\"Health_Bars.singletons\");\
\9utils = require(\"Health_Bars.utils\");\
end\
\
return this;\
", '@' .. ".\\Health_Bars\\screen.lua"))

package.preload["Health_Bars.singletons"] = assert((loadstring or load)("local this = {};\
\
local customization_menu;\
local error_handler;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
\
local game_manager_name = \"app.GameManager\";\
local inventory_manager_name = \"app.InventoryManager\";\
local interact_manager_name = \"app.InteractManager\";\
local menu_manager_name = \"app.MenuManager\";\
\
this.game_manager = nil;\
this.inventory_manager = nil;\
this.interact_manager = nil;\
this.menu_manager = nil;\
\
function this.update()\
\9this.update_game_manager();\
\9this.update_inventory_manager();\
\9this.update_interact_manager();\
\9this.update_menu_manager();\
end\
\
function this.update_game_manager()\
\9this.game_manager = sdk.get_managed_singleton(game_manager_name);\
\9if this.game_manager == nil then\
\9\9error_handler.report(\"[singletons.update_player_manager] No GameManager\");\
\9end\
\
\9return this.game_manager;\
end\
\
function this.update_inventory_manager()\
\9this.inventory_manager = sdk.get_managed_singleton(inventory_manager_name);\
\9if this.inventory_manager == nil then\
\9\9error_handler.report(\"[singletons.update_inventory_manager] No InventoryManager\");\
\9end\
\
\9return this.inventory_manager;\
end\
\
function this.update_interact_manager()\
\9this.interact_manager = sdk.get_managed_singleton(interact_manager_name);\
\9if this.interact_manager == nil then\
\9\9error_handler.report(\"[singletons.update_interact_manager] No InteractManager\");\
\9end\
\
\9return this.interact_manager;\
end\
\
function this.update_menu_manager()\
\9this.menu_manager = sdk.get_managed_singleton(menu_manager_name);\
\9if this.menu_manager == nil then\
\9\9error_handler.report(\"[singletons.update_menu_manager] No MenuManager\");\
\9end\
\
\9return this.menu_manager;\
end\
\
local menu_manager = sdk.get_managed_singleton(\"app.MenuManager\");\
\
function this.init_module()\
\9customization_menu = require(\"Health_Bars.customization_menu\");\
\9error_handler = require(\"Health_Bars.error_handler\");\
\
\9this.update();\
end\
\
return this;\
", '@' .. ".\\Health_Bars\\singletons.lua"))

package.preload["Health_Bars.time"] = assert((loadstring or load)("local this = {};\
\
local singletons;\
local customization_menu;\
local config;\
local utils;\
local screen;\
local game_handler;\
local enemy_handler;\
local player_handler;\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
local ValueType = ValueType;\
local package = package;\
\
this.total_elapsed_script_seconds = 0;\
\
this.timer_list = {};\
this.delay_timer_list = {};\
\
function this.new_timer(callback, cooldown_seconds, start_offset_seconds)\
\9start_offset_seconds = start_offset_seconds or utils.math.random();\
\
\9if callback == nil or cooldown_seconds == nil then\
\9\9return;\
\9end\
\
\9local timer = {};\
\9timer.callback = callback;\
\9timer.cooldown = cooldown_seconds;\
\
\9timer.last_trigger_time = os.clock() + start_offset_seconds;\
\
\9this.timer_list[callback] =  timer;\
\
\9return timer;\
end\
\
function this.new_delay_timer(callback, delay_seconds)\
\9if callback == nil or delay_seconds == nil then\
\9\9return;\
\9end\
\
\9local delay_timer = {};\
\9delay_timer.callback = callback;\
\9delay_timer.delay = delay_seconds;\
\9\
\9delay_timer.init_time = os.clock();\
\
\9this.delay_timer_list[callback] = delay_timer;\
\
\9return delay_timer;\
end\
\
function this.remove_delay_timer(delay_timer)\
\9if delay_timer == nil then\
\9\9return;\
\9end\
\
\9this.delay_timer_list[delay_timer.callback] = nil;\
end\
\
function this.init_global_timers()\
\9local cached_config = config.current_config.settings.timer_delays;\
\
\9this.timer_list = {};\
\
\9this.new_timer(singletons.update, cached_config.update_singletons_delay);\
\9this.new_timer(screen.update_window_size, cached_config.update_window_size_delay);\
\9this.new_timer(game_handler.update, cached_config.update_game_data_delay);\
\9this.new_timer(player_handler.update, cached_config.update_player_data_delay);\
\9this.new_timer(enemy_handler.update, cached_config.update_enemy_data_delay);\
end\
\
function this.update_timers()\
\9this.update_script_time();\
\
\9for callback, timer in pairs(this.timer_list) do\
\9\9if this.total_elapsed_script_seconds - timer.last_trigger_time > timer.cooldown then\
\9\9\9timer.last_trigger_time = this.total_elapsed_script_seconds;\
\9\9\9callback();\
\9\9end\
\9end\
\
\9local remove_list = {};\
\
\9for callback, delay_timer in pairs(this.delay_timer_list) do\
\9\9if this.total_elapsed_script_seconds - delay_timer.init_time > delay_timer.delay then\
\9\9\9callback();\
\9\9\9table.insert(remove_list, callback);\
\9\9end\
\9end\
\
\9for i, callback in ipairs(remove_list) do\
\9\9this.delay_timer_list[callback] = nil;\
\9end\
end\
\
function this.update_script_time()\
\9this.total_elapsed_script_seconds = os.clock();\
end\
\
function this.init_module()\
\9singletons = require(\"Health_Bars.singletons\");\
\9screen = require(\"Health_Bars.screen\");\
\9customization_menu = require(\"Health_Bars.customization_menu\");\
\9config = require(\"Health_Bars.config\");\
\9utils = require(\"Health_Bars.utils\");\
\9game_handler = require(\"Health_Bars.game_handler\");\
\9enemy_handler = require(\"Health_Bars.enemy_handler\");\
\9player_handler = require(\"Health_Bars.player_handler\");\
end\
\
return this;", '@' .. ".\\Health_Bars\\time.lua"))

package.preload["Health_Bars.utils"] = assert((loadstring or load)("local this = {};\
\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
local ValueType = ValueType;\
local package = package;\
\
local table_tostring;\
local deep_copy;\
local merge;\
local is_empty;\
local unicode_map;\
local unicode_relative_position;\
local unicode_chars;\
local epsilon = 0.000001;\
\
this.table = {};\
this.type = {};\
this.number = {};\
this.string = {};\
this.vec2 = {};\
this.vec3 = {};\
this.vec4 = {};\
this.math = {};\
this.unicode = {};\
this.sdk = {};\
\
this.constants = {};\
this.constants.uninitialized_int = -420;\
this.constants.uninitialized_string = \"Uninitialized\";\
this.constants.epsilon = epsilon;\
\
function this.table.tostring(table_)\
\9if type(table_) == \"number\" or type(table_) == \"boolean\" or type(table_) == \"string\" then\
\9\9return tostring(table_);\
\9end\
\
\9if is_empty(table_) then\
\9\9return \"{}\"; \
\9end\
\
\9local cache = {};\
\9local stack = {};\
\9local output = {};\
    local depth = 1;\
    local output_str = \"{\\n\";\
\
    while true do\
        local size = 0;\
        for k,v in pairs(table_) do\
            size = size + 1;\
        end\
\
        local cur_index = 1;\
        for k,v in pairs(table_) do\
            if cache[table_] == nil or cur_index >= cache[table_] then\
\
                if string.find(output_str, \"}\", output_str:len()) then\
                    output_str = output_str .. \",\\n\";\
                elseif not string.find(output_str, \"\\n\", output_str:len()) then\
                    output_str = output_str .. \"\\n\";\
                end\
\
                -- This is necessary for working with HUGE tables otherwise we run out of memory using concat on huge strings\
                table.insert(output,output_str);\
                output_str = \"\";\
\
                local key;\
                if type(k) == \"number\" or type(k) == \"boolean\" then\
                    key = \"[\" .. tostring(k) .. \"]\";\
                else\
                    key = \"['\" .. tostring(k) .. \"']\";\
                end\
\
                if type(v) == \"number\" or type(v) == \"boolean\" then\
                    output_str = output_str .. string.rep('\\t', depth) .. key .. \" = \" .. tostring(v);\
                elseif type(v) == \"table\" then\
                    output_str = output_str .. string.rep('\\t', depth) .. key .. \" = {\\n\";\
                    table.insert(stack, table_);\
                    table.insert(stack, v);\
                    cache[table_] = cur_index + 1;\
                    break;\
                else\
                    output_str = output_str .. string.rep('\\t', depth) .. key .. \" = '\" .. tostring(v) .. \"'\";\
                end\
\
                if cur_index == size then\
                    output_str = output_str .. \"\\n\" .. string.rep('\\t', depth - 1) .. \"}\";\
                else\
                    output_str = output_str .. \",\";\
                end\
            else\
                -- close the table\
                if cur_index == size then\
                    output_str = output_str .. \"\\n\" .. string.rep('\\t', depth - 1) .. \"}\";\
                end\
            end\
\
            cur_index = cur_index + 1;\
        end\
\
        if size == 0 then\
            output_str = output_str .. \"\\n\" .. string.rep('\\t', depth - 1) .. \"}\";\
        end\
\
        if #stack > 0 then\
            table_ = stack[#stack];\
            stack[#stack] = nil;\
            depth = cache[table_] == nil and depth + 1 or depth - 1;\
        else\
            break;\
        end\
    end\
\
    -- This is necessary for working with HUGE tables otherwise we run out of memory using concat on huge strings\
    table.insert(output, output_str);\
    output_str = table.concat(output);\
\
    return output_str;\
end\
\
function this.table.tostringln(table_)\
\9return \"\\n\" .. table_tostring(table_);\
end\
\
function this.table.is_empty(table_)\
\9return next(table_) == nil;\
end\
\
function this.table.deep_copy(original, copies)\
\9copies = copies or {};\
\9local original_type = type(original);\
\9local copy;\
\9if original_type == \"table\" then\
\9\9if copies[original] then\
\9\9\9copy = copies[original];\
\9\9else\
\9\9\9copy = {};\
\9\9\9copies[original] = copy;\
\9\9\9for original_key, original_value in next, original, nil do\
\9\9\9\9copy[deep_copy(original_key, copies)] = deep_copy(original_value,copies);\
\9\9\9end\
\9\9\9setmetatable(copy, deep_copy(getmetatable(original), copies));\
\9\9end\
\9else -- number, string, boolean, etc\
\9\9copy = original;\
\9end\
\9return copy;\
end\
\
function this.table.find_index(table_, value, nullable)\
\9for i = 1, #table_ do\
\9\9if table_[i] == value then\
\9\9\9return i;\
\9\9end\
\9end\
\
\9if not nullable then\
\9\9return 1;\
\9end\
\
\9return nil;\
end\
\
function this.table.merge(...)\
\9local tables_to_merge = { ... };\
\9assert(#tables_to_merge > 1, \"There should be at least two tables to merge them\");\
\
\9for key, table_ in ipairs(tables_to_merge) do\
\9\9assert(type(table_) == \"table\", string.format(\"Expected a table as function parameter %d\", key));\
\9end\
\
\9local result = deep_copy(tables_to_merge[1]);\
\
\9for i = 2, #tables_to_merge do\
\9\9local from = tables_to_merge[i];\
\9\9for key, value in pairs(from) do\
\9\9\9if type(value) == \"table\" then\
\9\9\9\9result[key] = result[key] or {};\
\9\9\9\9assert(type(result[key]) == \"table\", string.format(\"Expected a table: '%s'\", key));\
\9\9\9\9result[key] = merge(result[key], value);\
\9\9\9else\
\9\9\9\9result[key] = value;\
\9\9\9end\
\9\9end\
\9end\
\
\9return result;\
end\
\
function this.type.is_boolean(value)\
\9return value == true or value == false;\
end\
\
function this.type.is_REField(value)\
\9return \9value.get_return_type == nil;\
end\
\
function this.type.is_REMethodDefinition(value)\
\9return \9value.get_return_type ~= nil;\
end\
\
function this.number.is_NaN(value)\
\9return tostring(value) == tostring(0/0);\
end\
\
function this.number.round(value)\
\9return math.floor(value + 0.5);\
end\
\
function this.number.is_odd(value)\
\9return value % 2 ~= 0;\
end\
\
function this.number.is_even(value)\
\9return value % 2 == 0;\
end\
\
function this.number.is_equal(value1, value2)\
\9if math.abs(value1 - value2) < epsilon then\
\9\9return true;\
\9end\
\
\9return false;\
end\
\
function this.string.trim(str)\
\9return str:match(\"^%s*(.-)%s*$\");\
end\
\
function this.string.starts_with(str, pattern)\
\9return str:find(\"^\" .. pattern) ~= nil;\
end\
\
function this.vec2.tostring(vector2f)\
\9return string.format(\"<%f, %f>\", vector2f.x, vector2f.y);\
end\
\
function this.vec2.random(distance)\
\9distance = distance or 1;\
\9local radians = math.random() * math.pi * 2;\
\9return Vector2f.new(\
\9\9distance * math.cos(radians),\
\9\9distance * math.sin(radians)\
\9);\
end\
\
function this.vec3.tostring(vector3f)\
\9return string.format(\"<%f, %f, %f>\", vector3f.x, vector3f.y, vector3f.z);\
end\
\
function this.vec4.tostring(vector4f)\
\9return string.format(\"<%f, %f, %f, %f>\", vector4f.x, vector4f.y, vector4f.z, vector4f.w);\
end\
\
--- When called without arguments, returns a pseudo-random float with uniform distribution in the range [0,1). When called with two floats min and max, math.random returns a pseudo-random float with uniform distribution in the range [min, max). The call .random(max) is equivalent to .random(1, max)\
---@param min number\
---@param max number\
---@return number\
function this.math.random(min, max)\
\9if min == nil and max == nil then\
\9\9return math.random();\
\9end\
\
\9if max == nil then\
\9\9return max * math.random();\
\9end\
\
\9return min + (max - min) * math.random();\
end\
\
function this.math.sign(value)\
\9return (value >= 0 and 1) or -1;\
end\
function this.math.round(value, bracket)\
\9bracket = bracket or 1;\
\9return math.floor(value / bracket + this.math.sign(value) * 0.5) * bracket;\
end\
\
-- https://github.com/blitmap/lua-utf8-simple/blob/master/utf8_simple.lua\
\
-- ABNF from RFC 3629\
--\
-- UTF8-octets = *( UTF8-char )\
-- UTF8-char = UTF8-1 / UTF8-2 / UTF8-3 / UTF8-4\
-- UTF8-1 = %x00-7F\
-- UTF8-2 = %xC2-DF UTF8-tail\
-- UTF8-3 = %xE0 %xA0-BF UTF8-tail / %xE1-EC 2( UTF8-tail ) /\
-- %xED %x80-9F UTF8-tail / %xEE-EF 2( UTF8-tail )\
-- UTF8-4 = %xF0 %x90-BF 2( UTF8-tail ) / %xF1-F3 3( UTF8-tail ) /\
-- %xF4 %x80-8F 2( UTF8-tail )\
-- UTF8-tail = %x80-BF\
\
-- 0xxxxxxx                            | 007F   (127)\
-- 110xxxxx\00910xxxxxx                   | 07FF   (2047)\
-- 1110xxxx\00910xxxxxx 10xxxxxx          | FFFF   (65535)\
-- 11110xxx\00910xxxxxx 10xxxxxx 10xxxxxx | 10FFFF (1114111)\
\
local pattern = \"[%z\\1-\\127\\194-\\244][\\128-\\191]*\";\
\
-- helper function\
function this.unicode.relative_position(position, length)\
\9if position < 0 then\
\9\9position = length + position + 1;\
\9end\
\9return position;\
end\
\
-- THE MEAT\
\
-- maps f over s's utf8 characters f can accept args: (visual_index, utf8_character, byte_index)\
function this.unicode.map(s, f, no_subs)\
\9local i = 0;\
\
\9if no_subs then\
\9\9for b, e in s:gmatch(\"()\" .. pattern .. \"()\") do\
\9\9\9i = i + 1;\
\9\9\9local c = e - b;\
\9\9\9f(i, c, b);\
\9\9end\
\9else\
\9\9for b, c in s:gmatch(\"()(\" .. pattern .. \")\") do\
\9\9\9i = i + 1;\
\9\9\9f(i, c, b);\
\9\9end\
\9end\
end\
\
-- THE REST\
\
-- returns the number of characters in a UTF-8 string\
function this.unicode.len(s)\
\9-- count the number of non-continuing bytes\
\9return select(2, s:gsub('[^\\128-\\193]', ''));\
end\
\
-- replace all utf8 chars with mapping\
function this.unicode.replace(s, map)\
\9return s:gsub(pattern, map);\
end\
\
-- reverse a utf8 string\
function this.unicode.reverse(s)\
\9-- reverse the individual greater-than-single-byte characters\
\9s = s:gsub(pattern, function (c)\
\9\9return #c > 1 and c:reverse()\
\9end);\
\
\9return s:reverse();\
end\
\
-- strip non-ascii characters from a utf8 string\
function this.unicode.strip(s)\
\9return s:gsub(pattern, function(c)\
\9\9return #c > 1 and '';\
\9end);\
end\
\
-- generator for the above -- to iterate over all utf8 chars\
function this.unicode.chars(s, no_subs)\
\9return coroutine.wrap(function()\
\9\9return unicode_map(s, coroutine.yield, no_subs);\
\9end);\
end\
\
-- like string.sub() but i, j are utf8 strings\
-- a utf8-safe string.sub()\
function this.unicode.sub(str, i, j)\
\9if coroutine == nil then\
\9\9return str;\
\9end\
\
\9local l = utf8.len(str);\
\
\9i = unicode_relative_position(i, l);\
\9j = j and unicode_relative_position(j, l) or l;\
\
\9if i < 1 then\
\9\9i = 1;\
\9end\
\
\9if j > l then\
\9\9j = l;\
\9end\
\
\9if i > j then\
\9\9return \"\";\
\9end\
\
\9local diff = j - i;\
\9local iterator = unicode_chars(str, true);\
\
\9-- advance up to i\
\9for _ = 1, i - 1 do\
\9\9iterator();\
\9end\
\
\9local c, b = select(2, iterator());\
\
\9-- i and j are the same, single-charaacter sub\
\9if diff == 0 then\
\9\9return string.sub(str, b, b + c - 1);\
\9end\
\
\9i = b;\
\
\9-- advance up to j\
\9for _ = 1, diff - 1 do\
\9\9iterator();\
\9end\
\
\9c, b = select(2, iterator());\
\
\9return string.sub(str, i, b + c - 1);\
end\
\
function this.sdk.generate_enum(type_def)\
\9if not type_def then\
\9\9return {};\
\9end\
\
\9local fields = type_def:get_fields();\
\9local enum = {};\
\
\9for i, field in ipairs(fields) do\
\9\9if field:is_static() then\
\9\9\9local name = field:get_name();\
\9\9\9local raw_value = field:get_data(nil);\
\
\9\9\9local enum_entry = {\
\9\9\9\9name = name,\
\9\9\9\9value = raw_value;\
\9\9\9};\
\
\9\9\9table.insert(enum, enum_entry);\
\9\9end\
\9end\
\
\9return enum;\
end\
\
function this.sdk.generate_enum_by_typename(type_name)\
\9local type_def = sdk.find_type_definition(type_name);\
\9if not type_def then\
\9\9return {};\
\9end;\
\
\9return this.sdk.generate_enum(type_def);\
end\
\
function this.init_module()\
end\
\
table_tostring = this.table.tostring;\
deep_copy = this.table.deep_copy;\
merge = this.table.merge;\
is_empty = this.table.is_empty;\
unicode_map = this.unicode.map;\
unicode_relative_position = this.unicode.relative_position;\
unicode_chars = this.unicode.chars;\
\
return this;", '@' .. ".\\Health_Bars\\utils.lua"))

assert((loadstring or load)("\
local sdk = sdk;\
local tostring = tostring;\
local pairs = pairs;\
local ipairs = ipairs;\
local tonumber = tonumber;\
local require = require;\
local pcall = pcall;\
local table = table;\
local string = string;\
local Vector3f = Vector3f;\
local d2d = d2d;\
local math = math;\
local json = json;\
local log = log;\
local fs = fs;\
local next = next;\
local type = type;\
local setmetatable = setmetatable;\
local getmetatable = getmetatable;\
local assert = assert;\
local select = select;\
local coroutine = coroutine;\
local utf8 = utf8;\
local re = re;\
local imgui = imgui;\
local draw = draw;\
local Vector2f = Vector2f;\
local reframework = reframework;\
local os = os;\
local ValueType = ValueType;\
local package = package;\
\
local time = require(\"Health_Bars.time\");\
local drawing = require(\"Health_Bars.drawing\");\
local utils = require(\"Health_Bars.utils\");\
local config = require(\"Health_Bars.config\");\
local language = require(\"Health_Bars.language\");\
local screen = require(\"Health_Bars.screen\");\
local singletons = require(\"Health_Bars.singletons\");\
local error_handler = require(\"Health_Bars.error_handler\");\
\
local label_customization = require(\"Health_Bars.label_customization\");\
local bar_customization = require(\"Health_Bars.bar_customization\");\
local customization_menu = require(\"Health_Bars.customization_menu\");\
\
local game_handler = require(\"Health_Bars.game_handler\");\
local player_handler = require(\"Health_Bars.player_handler\");\
local enemy_handler = require(\"Health_Bars.enemy_handler\");\
\
------------------------INIT MODULES-------------------------\
-- #region\
time.init_module();\
drawing.init_module();\
utils.init_module();\
language.init_module();\
config.init_module();\
screen.init_module();\
singletons.init_module();\
error_handler.init_module();\
\
label_customization.init_module();\
bar_customization.init_module();\
customization_menu.init_module();\
\
game_handler.init_module();\
player_handler.init_module();\
enemy_handler.init_module();\
\
log.info(\"[Health Bars] Loaded.\");\
-- #endregion\
------------------------INIT MODULES-------------------------\
\
----------------------------LOOP-----------------------------\
-- #region\
re.on_pre_application_entry(\"UpdateBehavior\", function()\
\9if not config.current_config.enabled then\
\9\9return;\
\9end\
\
\9time.update_timers();\
end);\
\
local function main_loop()\
\9if not config.current_config.enabled then\
\9\9return;\
\9end\
\
\9player_handler.tick();\
\9enemy_handler.tick();\
\9enemy_handler.draw_enemies();\
end\
\
-- #endregion\
----------------------------LOOP-----------------------------\
\
--------------------------RE_IMGUI---------------------------\
-- #region\
re.on_draw_ui(function()\
\9local changed = false;\
\9local cached_config = config.current_config;\
if imgui.tree_node(\"Health Bars\") then\
\9if imgui.button(\"Health Bars v\" .. config.current_config.version) then\
\9\9customization_menu.is_opened = not customization_menu.is_opened;\
\9end\
\
\9imgui.same_line();\
\
\9changed, cached_config.enabled = imgui.checkbox(\"Enabled##HEALTH_BARS\", cached_config.enabled);\
\9if changed then\
\9\9config.save();\
\9end\
imgui.tree_pop()\
end\
end);\
\
re.on_frame(function()\
\9if not reframework:is_drawing_ui() then\
\9\9customization_menu.is_opened = false;\
\9end\
\
\9if customization_menu.is_opened then\
\9\9pcall(customization_menu.draw);\
\9end\
end);\
-- #endregion\
--------------------------RE_IMGUI---------------------------\
\
----------------------------D2D------------------------------\
-- #region\
if d2d ~= nil then\
\9d2d.register(function()\
\9\9drawing.init_font();\
\9end, function()\
\9\9if config.current_config.settings.use_d2d_if_available then\
\9\9\9main_loop();\
\9\9end\
\9end);\
end\
\
re.on_frame(function()\
\9if d2d == nil or not config.current_config.settings.use_d2d_if_available then\
\9\9main_loop();\
\9end\
end);\
-- #endregion\
----------------------------D2D------------------------------\
\
time.init_global_timers();", '@' .. "Health_Bars.lua"))(...)
