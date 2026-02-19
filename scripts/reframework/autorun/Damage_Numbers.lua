package.preload[ "Damage_Numbers.config" ] = assert( (loadstring or load)( "local this = {};\
local version = \"1.1\";\
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
\
this.current_config = nil;\
this.config_file_name = \"Damage Numbers/config.json\";\
\
this.default_config = {};\
\
function this.init()\
\9this.default_config = {\
\9\9enabled = true,\
\
\9\9version = this.version,\
\
\9\9customization_menu = {\
\9\9\9position = {\
\9\9\9\9x = 480,\
\9\9\9\9y = 200\
\9\9\9},\
\
\9\9\9size = {\
\9\9\9\9width = 730,\
\9\9\9\9height = 550\
\9\9\9},\
\
\9\9\9pivot = {\
\9\9\9\9x = 0,\
\9\9\9\9y = 0\
\9\9\9}\
\9\9},\
\
\9\9font = {\
\9\9\9family = \"Bahnschrift\",\
\9\9\9size = 24,\
\9\9\9bold = true,\
\9\9\9italic = false\
\9\9},\
\
\9\9settings = {\
\9\9\9timer_delays = {\
\9\9\9\9update_singletons_delay = 0,\
\9\9\9\9update_window_size_delay = 0,\
\9\9\9\9update_game_data_delay = 0.1,\
\9\9\9\9update_player_data_delay = 0.1\
\9\9\9},\
\
\9\9\9use_d2d_if_available = true,\
\
\9\9\9render_during_cutscenes = true,\
\9\9\9render_when_game_timer_is_paused = true,\
\9\9\9render_when_any_menu_is_opened = false,\
\
\9\9\9render_when_normal = true,\
\9\9\9render_when_aiming = true,\
\9\9\9render_when_guarding = true,\
\
\9\9\9display_delay = 0.022222,\
\9\9\9-- display_duration = 0.988888,\
\
\9\9\9--display_delay = 0.116666,\
\9\9\9--display_delay = 0.0,\
\9\9\9display_duration = 0.650,\
\
\9\9\9floating_direction = {\
\9\9\9\9min = -105,\
\9\9\9\9max = -75\
\9\9\9},\
\
\9\9\9floating_distance = {\
\9\9\9\9min = 50,\
\9\9\9\9max = 100\
\9\9\9}\
\9\9},\
\
\9\9keyframes = {\
\9\9\9opacity_scale = {\
\9\9\9\9type = \"float\",\
\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9[1] = {\
\9\
\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9value = 0,\
\9\9\9\9},\
\9\9\9\9[2] = {\
\9\
\9\9\9\9\9timeline_position = 0.166666,\
\9\9\9\9\9value = 1,\
\9\9\9\9},\
\9\9\9\9[3] = {\
\9\
\9\9\9\9\9timeline_position = 0.666666,\
\9\9\9\9\9value = 1,\
\9\9\9\9},\
\9\9\9\9[4] = {\
\9\
\9\9\9\9\9timeline_position = 1,\
\9\9\9\9\9value = 0,\
\9\9\9\9},\
\9\9\9},\
\
\9\9\9floating_movement = {\
\9\9\9\9type = \"float\",\
\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9[1] = {\
\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9value = 0,\
\9\9\9\9},\
\9\9\9\9[2] = {\
\9\9\9\9\9timeline_position = 1,\
\9\9\9\9\9value = 1,\
\9\9\9\9},\
\9\9\9},\
\
\9\9\9damage_number_label = {\
\9\9\9\9visibility = {\
\9\9\9\9\9type = \"bool\",\
\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9[1] = {\
\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9value = true,\
\9\9\9\9\9}\
\9\9\9\9},\
\9\
\9\9\9\9offset = {\
\9\9\9\9\9x = {\
\9\9\9\9\9\9type = \"float\",\
\9\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9\9[1] = {\
\9\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9\9value = 0,\
\9\
\9\9\9\9\9\9}\
\9\9\9\9\9},\
\9\
\9\9\9\9\9y = {\
\9\9\9\9\9\9type = \"float\",\
\9\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9\9[1] = {\
\9\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9\9value = 0,\
\9\9\9\9\9\9}\
\9\9\9\9\9},\
\9\9\9\9},\
\9\9\9\9\
\9\9\9\9color = {\
\9\9\9\9\9type = \"color\",\
\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9[1] = {\
\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9value = 0xB9FFF7F2,\
\9\9\9\9\9}\
\9\9\9\9},\
\9\
\9\9\9\9shadow = {\
\9\9\9\9\9visibility = {\
\9\9\9\9\9\9type = \"bool\",\
\9\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9\9[1] = {\
\9\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9\9value = true,\
\9\9\9\9\9\9}\
\9\9\9\9\9},\
\9\
\9\9\9\9\9offset = {\
\9\9\9\9\9\9x = {\
\9\9\9\9\9\9\9type = \"float\",\
\9\9\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9\9\9[1] = {\
\9\9\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9\9\9value = 1,\
\9\9\9\9\9\9\9}\
\9\9\9\9\9\9},\
\9\
\9\9\9\9\9\9y = {\
\9\9\9\9\9\9\9type = \"float\",\
\9\9\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9\9\9[1] = {\
\9\9\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9\9\9value = 1,\
\9\9\9\9\9\9\9}\
\9\9\9\9\9\9},\
\9\9\9\9\9},\
\9\
\9\9\9\9\9color = {\
\9\9\9\9\9\9type = \"color\",\
\9\9\9\9\9\9current_keyframe_index = 1,\
\9\9\9\9\9\9[1] = {\
\9\9\9\9\9\9\9timeline_position = 0,\
\9\9\9\9\9\9\9value = 0xFF000000,\
\9\9\9\9\9\9}\
\9\9\9\9\9}\
\9\9\9\9}\
\9\9\9},\
\9\9},\
\
\9\9damage_number_label = {\
\9\9\9visibility = true,\
\
\9\9\9text_format = \"%s\", -- current_health/max_health\
\
\9\9\9offset = {\
\9\9\9\9x = 0,\
\9\9\9\9y = 0\
\9\9\9},\
\9\9\9\
\9\9\9color = 0xFFFFFFFF,\
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
\9\9debug = {\
\9\9\9history_size = 64\
\9\9}\
\9};\
end\
\
function this.load()\
\9local loaded_config = json.load_file(this.config_file_name);\
\9if loaded_config ~= nil then\
\9\9log.info(\"[Damage Numbers] config.json loaded successfully\");\
\9\9this.current_config = utils.table.merge(this.default_config, loaded_config);\
\9\9this.fix_string_indices();\
\9else\
\9\9log.error(\"[Damage Numbers] Failed to load config.json\");\
\9\9this.current_config = utils.table.deep_copy(this.default_config);\
\9end\
end\
\
function this.save()\
\9-- save current config to disk, replacing any existing file\
\9local success = json.dump_file(this.config_file_name, this.current_config);\
\9if success then\
\9\9log.info(\"[Damage Numbers] config.json saved successfully\");\
\9else\
\9\9log.error(\"[Damage Numbers] Failed to save config.json\");\
\9end\
end\
\
function this.reset()\
\9this.current_config = utils.table.deep_copy(this.default_config);\
\9this.current_config.version = version;\
end\
\
function this.fix_string_indices()\
\9local keyframes = this.current_config.keyframes;\
\9local damage_number_label_keyframes = keyframes.damage_number_label;\
\9local damage_number_label_shadow_keyframes = damage_number_label_keyframes.shadow;\
\
\9keyframes.opacity_scale = this.fix_string_indices_(keyframes.opacity_scale);\
\9keyframes.floating_movement = this.fix_string_indices_(keyframes.floating_movement);\
\
\9damage_number_label_keyframes.visibility = this.fix_string_indices_(damage_number_label_keyframes.visibility);\
\9damage_number_label_keyframes.offset.x = this.fix_string_indices_(damage_number_label_keyframes.offset.x);\
\9damage_number_label_keyframes.offset.y = this.fix_string_indices_(damage_number_label_keyframes.offset.y);\
\9damage_number_label_keyframes.color = this.fix_string_indices_(damage_number_label_keyframes.color);\
\
\9damage_number_label_shadow_keyframes.visibility = this.fix_string_indices_(damage_number_label_shadow_keyframes.visibility);\
\9damage_number_label_shadow_keyframes.offset.x = this.fix_string_indices_(damage_number_label_shadow_keyframes.offset.x);\
\9damage_number_label_shadow_keyframes.offset.y = this.fix_string_indices_(damage_number_label_shadow_keyframes.offset.y);\
\9damage_number_label_shadow_keyframes.color = this.fix_string_indices_(damage_number_label_shadow_keyframes.color);\
end\
\
function this.fix_string_indices_(keyframes)\
\9local fixed_keyframes = {};\
\9for key, value in pairs(keyframes) do\
\9\9local index = tonumber(key);\
\
\9\9if index ~= nil then\
\9\9\9fixed_keyframes[index] = value;\
\9\9else\
\9\9\9fixed_keyframes[key] = value;\
\9\9end\
\9end\
\
\9return fixed_keyframes;\
end\
\
function this.init_module()\
\9utils = require(\"Damage_Numbers.utils\");\
\
\9this.init();\
\9this.load();\
\9this.current_config.version = version;\
end\
\
return this;\
", '@'..".\\Damage_Numbers\\config.lua" ) )

package.preload[ "Damage_Numbers.customization_menu" ] = assert( (loadstring or load)( "local this = {};\
\
local utils;\
local config;\
local screen;\
local keyframe_customization;\
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
this.font = nil;\
this.font_range = {0x1, 0xFFFF, 0};\
this.is_opened = false;\
\
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
function this.init()\
end\
\
function this.draw()\
\9local cached_config = config.current_config;\
\
\9local window_position = Vector2f.new(config.current_config.customization_menu.position.x, config.current_config.customization_menu.position.y);\
\9local window_pivot = Vector2f.new(config.current_config.customization_menu.pivot.x, config.current_config.customization_menu.pivot.y);\
\9local window_size = Vector2f.new(config.current_config.customization_menu.size.width, config.current_config.customization_menu.size.height);\
\
\9imgui.set_next_window_pos(window_position, 1 << 3, window_pivot);\
\9imgui.set_next_window_size(window_size, 1 << 3);\
\
\9this.is_opened = imgui.begin_window(\
\9\9\"Damage Numbers v\" .. config.current_config.version, this.is_opened, this.window_flags);\
\
\9if not this.is_opened then\
\9\9imgui.end_window();\
\9\9return;\
\9end\
\
\9local changed = false;\
\9local config_changed = false;\
\9local window_changed = false;\
\9local timer_delays_changed = false;\
\9local index = 1;\
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
\9if imgui.button(\"Reset Config\") then\
\9\9config.reset();\
\9\9config_changed = true;\
\9end\
\
\9changed, cached_config.enabled = imgui.checkbox(\"Enabled\", cached_config.enabled);\
\9config_changed = config_changed or changed;\
\
\9if imgui.tree_node(\"Font\") then\
\9\9imgui.text(\"Any changes to the font require script reload!\");\
\
\9\9changed, index = imgui.combo(\"Family\",\
\9\9\9utils.table.find_index(this.fonts, cached_config.font.family), this.fonts);\
\9\9config_changed = config_changed or changed;\
\
\9\9if changed then\
\9\9\9cached_config.font.family = this.fonts[index];\
\9\9end\
\
\9\9changed, cached_config.font.size = imgui.slider_int(\"Size\",\
\9\9\9cached_config.font.size, 1, 100);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.font.bold = imgui.checkbox(\"Bold\",\
\9\9\9cached_config.font.bold);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.font.italic = imgui.checkbox(\"Italic\",\
\9\9\9cached_config.font.italic);\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.tree_pop();\
\
\9end\
\
\9if imgui.tree_node(\"Settings\") then\
\9\9if imgui.tree_node(\"Timer Delays\") then\
\
\9\9\9changed, cached_config.settings.timer_delays.update_singletons_delay = imgui.drag_float(\
\9\9\9\9\"Update Singletons (sec)\",\
\9\9\9\9cached_config.settings.timer_delays.update_singletons_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\
\9\9\9changed, cached_config.settings.timer_delays.update_window_size_delay = imgui.drag_float(\
\9\9\9\9\"Update Window Size (sec)\",\
\9\9\9\9cached_config.settings.timer_delays.update_window_size_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\9\9\9\
\9\9\9changed, cached_config.settings.timer_delays.update_game_data_delay = imgui.drag_float(\
\9\9\9\9\"Update Game Data (sec)\",\
\9\9\9\9cached_config.settings.timer_delays.update_game_data_delay, 0.001, 0, 5, \"%.3f\");\
\
\9\9\9changed, cached_config.settings.timer_delays.update_player_data_delay = imgui.drag_float(\
\9\9\9\9\"Update Player Data (sec)\",\
\9\9\9\9cached_config.settings.timer_delays.update_player_data_delay, 0.001, 0, 5, \"%.3f\");\
\9\9\9\
\9\9\9config_changed = config_changed or changed;\
\9\9\9timer_delays_changed = timer_delays_changed or changed;\
\
\9\9\9imgui.tree_pop();\
\9\9end\
\
\9\9imgui.new_line();\
\9\9imgui.begin_rect()\
\
\9\9changed, cached_config.settings.use_d2d_if_available = imgui.checkbox(\"Use Direct2D Renderer if Available\",\
\9\9\9cached_config.settings.use_d2d_if_available);\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect()\
\
\9\9changed, cached_config.settings.render_during_cutscenes = imgui.checkbox(\"Render during Cutscenes\",\
\9\9\9cached_config.settings.render_during_cutscenes);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_game_timer_is_paused = imgui.checkbox(\"Render when Game Timer Is Paused\",\
\9\9\9cached_config.settings.render_when_game_timer_is_paused);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_any_menu_is_opened = imgui.checkbox(\"Render when Any Menu Is Opened\",\
\9\9\9cached_config.settings.render_when_any_menu_is_opened);\
\9\9config_changed = config_changed or changed;\
\9\9\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\9\9imgui.begin_rect()\
\9\9\
\9\9changed, cached_config.settings.render_when_normal = imgui.checkbox(\"Render when Normal\",\
\9\9\9cached_config.settings.render_when_normal);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_aiming = imgui.checkbox(\"Render when Aiming\",\
\9\9\9cached_config.settings.render_when_aiming);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.render_when_guarding = imgui.checkbox(\"Render when Guarding\",\
\9\9\9cached_config.settings.render_when_guarding);\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.end_rect(5);\
\9\9imgui.new_line();\
\
\9\9changed, cached_config.settings.display_delay = imgui.drag_float(\"Display Delay (sec)\",\
\9\9\9cached_config.settings.display_delay, 0.001, 0, 100, \"%.3f\");\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.display_duration = imgui.drag_float(\"Display Duration (sec)\",\
\9\9\9cached_config.settings.display_duration, 0.001, 0, 100, \"%.3f\");\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.new_line();\
\
\9\9changed, cached_config.settings.floating_direction.min = imgui.drag_float(\"Floating Direction (Min)\",\
\9\9\9cached_config.settings.floating_direction.min, 0.1, -720, cached_config.settings.floating_direction.max, \"%.1f\");\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.floating_direction.max = imgui.drag_float(\"Floating Direction (Max)\",\
\9\9\9cached_config.settings.floating_direction.max, 0.1, cached_config.settings.floating_direction.min, 720, \"%.1f\");\
\9\9config_changed = config_changed or changed;\
\
\9\9imgui.new_line();\
\
\9\9changed, cached_config.settings.floating_distance.min = imgui.drag_float(\"Floating Distance (Min)\",\
\9\9\9cached_config.settings.floating_distance.min, 0.1, 0, cached_config.settings.floating_distance.max, \"%.1f\");\
\9\9config_changed = config_changed or changed;\
\
\9\9changed, cached_config.settings.floating_distance.max = imgui.drag_float(\"Floating Distance (Max)\",\
\9\9\9cached_config.settings.floating_distance.max, 0.1, cached_config.settings.floating_distance.min, 2000, \"%.1f\");\
\9\9config_changed = config_changed or changed;\
\9\9\
\9\9imgui.tree_pop();\
\9end\
\
\9if imgui.tree_node(\"Keyframes\") then\
\9\9changed = keyframe_customization.draw(\"Opacity\", cached_config.keyframes.opacity_scale, 0.001, 0, 1, \"%.1f\", true);\
\9\9config_changed = config_changed or changed;\
\
\9\9changed = keyframe_customization.draw(\"Floating Movemement\", cached_config.keyframes.floating_movement, 0.001, 0, 1, \"%.1f\", true);\
\9\9config_changed = config_changed or changed;\
\
\9\9if imgui.tree_node(\"Damage Number Label\") then\
\9\9\9changed = keyframe_customization.draw(\"Visibility\", cached_config.keyframes.damage_number_label.visibility);\
\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9if imgui.tree_node(\"Offset\") then\
\9\9\9\9changed = keyframe_customization.draw(\"X\", cached_config.keyframes.damage_number_label.offset.x, 0.1, -screen.width, screen.width, \"%.1f\");\
\9\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9\9changed = keyframe_customization.draw(\"Y\", cached_config.keyframes.damage_number_label.offset.y, 0.1, -screen.width, screen.width, \"%.1f\");\
\9\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\9\
\9\9\9changed = keyframe_customization.draw(\"Color\", cached_config.keyframes.damage_number_label.color);\
\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9if imgui.tree_node(\"Shadow\") then\
\9\9\9\9changed = keyframe_customization.draw(\"Visibility\", cached_config.keyframes.damage_number_label.shadow.visibility);\
\9\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9\9if imgui.tree_node(\"Offset\") then\
\9\9\9\9\9changed = keyframe_customization.draw(\"X\", cached_config.keyframes.damage_number_label.shadow.offset.x, 0.1, -screen.width, screen.width, \"%.1f\");\
\9\9\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9\9\9changed = keyframe_customization.draw(\"Y\", cached_config.keyframes.damage_number_label.shadow.offset.y, 0.1, -screen.width, screen.width, \"%.1f\");\
\9\9\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9\9\9imgui.tree_pop();\
\9\9\9\9end\
\9\
\9\9\9\9changed = keyframe_customization.draw(\"Color\", cached_config.keyframes.damage_number_label.shadow.color);\
\9\9\9\9config_changed = config_changed or changed;\
\9\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\9\9\9\
\9\9\9imgui.tree_pop();\
\9\9end\
\9\9\
\9\9imgui.tree_pop();\
\9end\
\
\9changed = this.draw_debug();\
\9config_changed = config_changed or changed;\
\
\9imgui.new_line();\
\9imgui.end_window();\
\
\9if config_changed or window_changed then\
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
\9if imgui.tree_node(\"Debug\") then\
\9\9\
\9\9imgui.text_colored(\"Current Time:\", 0xFFAAAA66);\
\9\9imgui.same_line();\
\9\9imgui.text(string.format(\"%.3fs\", time.total_elapsed_script_seconds));\
\
\9\9if error_handler.is_empty then\
\9\9\9imgui.text(\"Everything seems to be OK!\");\
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
\9\9if imgui.tree_node(\"History\") then\
\
\9\9\9changed, cached_config.history_size = imgui.drag_int(\
\9\9\9\9\"History Size\", cached_config.history_size, 1, 0, 1024);\
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
\
function this.init_module()\
\9utils = require(\"Damage_Numbers.utils\");\
\9config = require(\"Damage_Numbers.config\");\
\9screen = require(\"Damage_Numbers.screen\");\
\9keyframe_customization = require(\"Damage_Numbers.keyframe_customization\");\
\9time = require(\"Damage_Numbers.time\");\
\9error_handler = require(\"Damage_Numbers.error_handler\");\
\
\9this.init();\
end\
\
return this;", '@'..".\\Damage_Numbers\\customization_menu.lua" ) )

package.preload[ "Damage_Numbers.damage_handler" ] = assert( (loadstring or load)( "local this = {};\
\
local config;\
local utils;\
local time;\
local keyframe_handler;\
local drawing;\
local customization_menu;\
local player_handler;\
local game_handler;\
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
this.list = {};\
\
local enemy_action_controller_type_def = sdk.find_type_definition(\"app.EnemyActionController\");\
local give_damage_method = enemy_action_controller_type_def:get_method(\"giveDamage\");\
local give_die_method = enemy_action_controller_type_def:get_method(\"giveDie\");\
\
local damage_info_type_def = sdk.find_type_definition(\"app.Collision.HitController.DamageInfo\");\
local get_position_method = damage_info_type_def:get_method(\"get_Position\");\
local damage_field = damage_info_type_def:get_field(\"Damage\");\
local get_damage_scale_method = damage_info_type_def:get_method(\"get_DamageScale\");\
\
function this.new(damage, hit_position)\
\9local cached_config = config.current_config;\
\
\9local damage_number = {};\
\
\9damage_number.display_delay = cached_config.settings.display_delay;\
\9damage_number.display_duration = cached_config.settings.display_duration;\
\
\9if damage_number.display_duration < utils.constants.epsilon then\
\9\9return;\
\9end\
\
\9damage_number.init_time = time.total_elapsed_script_seconds;\
\9damage_number.progress = 0;\
\
\9damage_number.text = string.format(\"%.0f\", utils.math.round(damage)) or \"0\";\
\
\9damage_number.hit_position = hit_position or Vector3f.new(0, 0, 0);\
\9damage_number.current_position = hit_position;\
\
\9damage_number.floating_distance = utils.math.random(cached_config.settings.floating_distance.min, cached_config.settings.floating_distance.max);\
\9damage_number.floating_direction = utils.vec2.random(damage_number.floating_distance, cached_config.settings.floating_direction.min, cached_config.settings.floating_direction.max);\
\
\9damage_number.floating_progress = 0;\
\9damage_number.opacity_scale = 0;\
\
\9damage_number.label = utils.table.deep_copy(cached_config.damage_number_label);\
\9damage_number.keyframes = utils.table.deep_copy(cached_config.keyframes);\
\
\9table.insert(this.list, damage_number);\
end\
\
function this.update_progress(damage_number)\
\9local elapsed_time = time.total_elapsed_script_seconds - damage_number.init_time;\
\
\9if elapsed_time < damage_number.display_delay then\
\9\9damage_number.progress = 0;\
\9\9return;\
\9end\
\
\9damage_number.progress = (elapsed_time - damage_number.display_delay) / damage_number.display_duration;\
end\
\
function this.update_values_from_keyframes(damage_number)\
\9local label = damage_number.label;\
\9local label_shadow = label.shadow;\
\
\9local progress = damage_number.progress;\
\9local keyframes = damage_number.keyframes;\
\
\9local damage_number_label_keyframes = keyframes.damage_number_label;\
\9local damage_number_label_shadow_keyframes = damage_number_label_keyframes.shadow;\
\
\9damage_number.opacity_scale = keyframe_handler.calculate_current_value(progress, keyframes.opacity_scale);\
\9damage_number.floating_progress = keyframe_handler.calculate_current_value(progress, keyframes.floating_movement);\
\
\9label.visibility = keyframe_handler.calculate_current_value(progress, damage_number_label_keyframes.visibility);\
\
\9label.offset.x = keyframe_handler.calculate_current_value(progress, damage_number_label_keyframes.offset.x);\
\9label.offset.y = keyframe_handler.calculate_current_value(progress, damage_number_label_keyframes.offset.y);\
\
\9label.color = keyframe_handler.calculate_current_value(progress, damage_number_label_keyframes.color);\
\
\9label_shadow.visibility = keyframe_handler.calculate_current_value(progress, damage_number_label_shadow_keyframes.visibility);\
\
\9label_shadow.offset.x = keyframe_handler.calculate_current_value(progress, damage_number_label_shadow_keyframes.offset.x);\
\9label_shadow.offset.y = keyframe_handler.calculate_current_value(progress, damage_number_label_shadow_keyframes.offset.y);\
\
\9label_shadow.color = keyframe_handler.calculate_current_value(progress, damage_number_label_shadow_keyframes.color);\
end\
\
function this.tick()\
\9local cached_config = config.current_config.settings;\
\
\9if not cached_config.render_during_cutscenes and game_handler.game.is_cutscene_playing then\
\9\9return;\
\9end\
\
\9if not cached_config.render_when_game_timer_is_paused and game_handler.game.is_paused then\
\9\9return;\
\9end\
\
\9if not cached_config.render_when_any_menu_is_opened and game_handler.game.is_menu_opened then\
\9\9return;\
\9end\
\
\9if player_handler.player.is_aiming then\
\9\9if not cached_config.render_when_aiming then\
\9\9\9return;\
\9\9end\
\9elseif player_handler.player.is_guarding then\
\9\9if not cached_config.render_when_guarding then\
\9\9\9return;\
\9\9end\
\9elseif not cached_config.render_when_normal then\
\9\9return;\
\9end\
\
\9for index, damage_number in pairs(this.list) do\
\9\9this.update_progress(damage_number);\
\
\9\9if damage_number.progress == 0 then\
\9\9\9goto continue;\
\9\9end\
\
\9\9if damage_number.progress > 1 then\
\9\9\9this.list[index] = nil;\
\9\9\9goto continue;\
\9\9end\
\
\9\9this.update_values_from_keyframes(damage_number);\
\
\9\9local hit_position_on_screen = draw.world_to_screen(damage_number.hit_position);\
\9\9if hit_position_on_screen == nil then\
\9\9\9goto continue;\
\9\9end\
\
\
\9\9damage_number.current_position = {\
\9\9\9x = hit_position_on_screen.x + damage_number.floating_direction.x * damage_number.floating_progress,\
\9\9\9y = hit_position_on_screen.y + damage_number.floating_direction.y * damage_number.floating_progress,\
\9\9}\
\
\9\9drawing.draw_label(damage_number.label, damage_number.current_position, damage_number.opacity_scale, damage_number.text);\
\9\
\9\9::continue::\
\9end\
end\
\
function this.on_damage(damage_info)\
\9if damage_info == nil then\
\9\9error_handler.report(\"damage_handler.on_damage\", \"No DamageInfo\");\
\9\9return;\
\9end\
\
\9local damage = damage_field:get_data(damage_info);\
\9if damage == nil then\
\9\9error_handler.report(\"damage_handler.on_damage\", \"No Damage\");\
\9\9return;\
\9end\
\
\9if damage == 0 then\
\9\9return;\
\9end\
\
\9local damage_scale = get_damage_scale_method:call(damage_info);\
\9if damage_scale == nil then\
\9\9error_handler.report(\"damage_handler.on_damage\", \"No DamageScale\");\
\9\9return;\
\9end\
\
\9if damage_scale == 0 then\
\9\9return;\
\9end\
\
\9local scaled_damage = damage / damage_scale;\
\
\9local position = get_position_method:call(damage_info);\
\9if position == nil then\
\9\9error_handler.report(\"damage_handler.on_damage\", \"No Position\");\
\9\9return;\
\9end\
\
\9this.new(scaled_damage, position);\
end\
\
function this.init_module()\
\9config = require(\"Damage_Numbers.config\");\
\9utils = require(\"Damage_Numbers.utils\");\
\9time = require(\"Damage_Numbers.time\");\
\9keyframe_handler = require(\"Damage_Numbers.keyframe_handler\");\
\9drawing = require(\"Damage_Numbers.drawing\");\
\9player_handler = require(\"Damage_Numbers.player_handler\");\
\9game_handler = require(\"Damage_Numbers.game_handler\");\
\9error_handler = require(\"Damage_Numbers.error_handler\");\
\9\
\9sdk.hook(give_damage_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9local damage_info = sdk.to_managed_object(args[3]);\
\
\9\9this.on_damage(damage_info);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
\
\9sdk.hook(give_die_method, function(args)\
\9\9local enemy_action_controller = sdk.to_managed_object(args[2]);\
\9\9local damage_info = sdk.to_managed_object(args[3]);\
\
\9\9this.on_damage(damage_info);\
\
\9end, function(retval)\
\9\9return retval;\
\9end);\
end\
\
return this;", '@'..".\\Damage_Numbers\\damage_handler.lua" ) )

package.preload[ "Damage_Numbers.drawing" ] = assert( (loadstring or load)( "local this = {};\
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
\9local cached_config = config.current_config.font;\
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
\9config = require(\"Damage_Numbers.config\");\
\9utils = require(\"Damage_Numbers.utils\");\
end\
\
return this;\
", '@'..".\\Damage_Numbers\\drawing.lua" ) )

package.preload[ "Damage_Numbers.error_handler" ] = assert( (loadstring or load)( "local this = {};\
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
\9time = require(\"Damage_Numbers.time\");\
\9utils = require(\"Damage_Numbers.utils\");\
\9config = require(\"Damage_Numbers.config\");\
end\
\
return this;", '@'..".\\Damage_Numbers\\error_handler.lua" ) )

package.preload[ "Damage_Numbers.game_handler" ] = assert( (loadstring or load)( "local this = {};\
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
\9singletons = require(\"Damage_Numbers.singletons\");\
\9error_handler = require(\"Damage_Numbers.error_handler\");\
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
return this;", '@'..".\\Damage_Numbers\\game_handler.lua" ) )

package.preload[ "Damage_Numbers.keyframe_customization" ] = assert( (loadstring or load)( "local this = {};\
\
local utils;\
local config;\
local screen;\
local customization_menu;\
local keyframe_handler;\
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
function this.draw(name, keyframes, step, min, max, format, is_value_percentage)\
\9if is_value_percentage == nil then\
\9\9is_value_percentage = false;\
\9end\
\
\9local keyframes_changed = false;\
\9local changed = false;\
\
\9if imgui.tree_node(name) then\
\9\9if imgui.small_button(\" + ##0\") then\
\9\9\9keyframe_handler.add_keyframe(keyframes, 1);\
\9\9\9keyframes_changed = true;\
\9\9end\
\
\9\9imgui.same_line();\
\
\9\9local min_timeline_position = 0;\
\9\9local max_timeline_position = 1;\
\9\9local keyframe_count = #keyframes;\
\
\9\9for i = 1, keyframe_count do\
\9\9\9if keyframe_count ~= 1 then\
\9\9\9\9if imgui.small_button(string.format(\" - ##%d\", i)) then\
\9\9\9\9\9keyframe_handler.remove_keyframe(keyframes, i);\
\9\9\9\9\9keyframes_changed = true;\
\9\9\9\9\9break;\
\9\9\9\9end\
\
\9\9\9\9imgui.same_line();\
\9\9\9end\
\
\9\9\9if imgui.tree_node(string.format(\"[%d]\", i)) then\
\9\9\9\9local keyframe = keyframes[i];\
\
\9\9\9\9if keyframe == nil then\
\9\9\9\9\9break;\
\9\9\9\9end\
\
\9\9\9\9if i > 1 then\
\9\9\9\9\9min_timeline_position = keyframes[i - 1].timeline_position;\
\9\9\9\9end\
\
\9\9\9\9if i < keyframe_count then\
\9\9\9\9\9max_timeline_position = keyframes[i + 1].timeline_position;\
\9\9\9\9end\
\
\9\9\9\9local timeline_position_percents = 0;\
\9\9\9\9changed, timeline_position_percents = imgui.drag_float(\"Timeline Position (%)\",\
\9\9\9\9\009100 * keyframe.timeline_position, 0.1, 100 * min_timeline_position, 100 * max_timeline_position, \"%.1f\");\
\9\9\9\9keyframes_changed = keyframes_changed or changed;\
\
\9\9\9\9local timeline_position = timeline_position_percents / 100;\
\
\9\9\9\9if changed and timeline_position >= min_timeline_position and timeline_position <= max_timeline_position then\
\9\9\9\9\9keyframe.timeline_position = timeline_position\
\9\9\9\9end\
\
\9\9\9\9if keyframes.type == \"bool\" then\
\9\9\9\9\9changed, keyframe.value = imgui.checkbox(\"Value\", keyframe.value);\
\9\9\9\9\9keyframes_changed = keyframes_changed or changed;\
\
\9\9\9\9elseif keyframes.type == \"float\" then\
\9\9\9\9\9if is_value_percentage then\
\9\9\9\9\9\9local value_percents = 0;\
\
\9\9\9\9\9\9changed, value_percents = imgui.drag_float(\"Value (%)\", 100 * keyframe.value, 0.1, 0, 100, \"%.1f\");\
\9\9\9\9\9\9keyframes_changed = keyframes_changed or changed;\
\
\9\9\9\9\9\9if changed then\
\9\9\9\9\9\9\9keyframe.value = value_percents / 100;\
\9\9\9\9\9\9end\
\
\9\9\9\9\9else\
\9\9\9\9\9\9changed, keyframe.value = imgui.drag_float(\"Value\", keyframe.value, step, min, max, format);\
\9\9\9\9\9\9keyframes_changed = keyframes_changed or changed;\
\9\9\9\9\9end\
\
\
\9\9\9\9else\
\9\9\9\9\9changed, keyframe.value = imgui.color_picker_argb(\"\", keyframe.value, customization_menu.color_picker_flags);\
\9\9\9\9\9keyframes_changed = keyframes_changed or changed;\
\9\9\9\9end\
\
\9\9\9\9imgui.tree_pop();\
\9\9\9end\
\
\9\9\9if imgui.small_button(string.format(\" + ##%d\", i)) then\
\9\9\9\9keyframe_handler.add_keyframe(keyframes, i + 1);\
\9\9\9\9keyframes_changed = true;\
\9\9\9\9break;\
\9\9\9end\
\
\9\9\9if i ~= keyframe_count then\
\9\9\9\9imgui.same_line();\
\9\9\9end\
\9\9end\
\
\9\9imgui.tree_pop();\
\9end\
\
\9return keyframes_changed;\
end\
\
function this.init_module()\
\9utils = require(\"Damage_Numbers.utils\");\
\9config = require(\"Damage_Numbers.config\");\
\9screen = require(\"Damage_Numbers.screen\");\
\9customization_menu = require(\"Damage_Numbers.customization_menu\");\
\9keyframe_handler = require(\"Damage_Numbers.keyframe_handler\");\
end\
\
return this;", '@'..".\\Damage_Numbers\\keyframe_customization.lua" ) )

package.preload[ "Damage_Numbers.keyframe_handler" ] = assert( (loadstring or load)( "local this = {};\
\
local drawing;\
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
this.keyframe_types = {\
\9bool = \"bool\",\
\9float = \"float\",\
\9color = \"color\"\
}\
\
function this.calculate_current_value(progress, keyframes)\
\9local keyframe_count = #keyframes;\
\
\9local current_keyframe = keyframes[keyframes.current_keyframe_index];\
\
\9if keyframes.current_keyframe_index >= keyframe_count or progress < current_keyframe.timeline_position then\
\9\9return current_keyframe.value;\
\9end\
\
\9local next_keyframe = keyframes[keyframes.current_keyframe_index + 1];\
\
\9if progress > next_keyframe.timeline_position then\
\9\9keyframes.current_keyframe_index = keyframes.current_keyframe_index + 1;\
\9\9current_keyframe = next_keyframe;\
\
\9\9if keyframes.current_keyframe_index >= keyframe_count then\
\9\9\9return current_keyframe.value;\
\9\9end\
\9end\
\9\
\9local next_keyframe = keyframes[keyframes.current_keyframe_index + 1];\
\
\9return this.interpolate_linear(progress, current_keyframe, next_keyframe, keyframes.type);\
end\
\
\
function this.interpolate_linear(progress, current_keyframe, next_keyframe, type)\
\9if next_keyframe == nil or type == this.keyframe_types.bool then\
\9\9return current_keyframe.value;\
\9end\
\
\9local timeline_position_difference = next_keyframe.timeline_position - current_keyframe.timeline_position;\
\9local timeline_local_progress = (progress - current_keyframe.timeline_position);\
\9local interpolated_value = 0;\
\
\9if type == this.keyframe_types.float then\
\9\9interpolated_value = current_keyframe.value + timeline_local_progress * ((next_keyframe.value - current_keyframe.value) / timeline_position_difference);\
\
\9else\
\9\9local current_alpha, current_red, current_green, current_blue = drawing.color_to_argb(current_keyframe.value);\
\9\9local next_alpha, next_red, next_green, next_blue = drawing.color_to_argb(next_keyframe.value);\
\
\9\9local interpolated_alpha = current_alpha + timeline_local_progress * ((next_alpha - current_alpha) / timeline_position_difference);\
\9\9local interpolated_red = current_red + timeline_local_progress * ((next_red - current_red) / timeline_position_difference);\
\9\9local interpolated_green = current_green + timeline_local_progress * ((next_green - current_green) / timeline_position_difference);\
\9\9local interpolated_blue = current_blue + timeline_local_progress * ((next_blue - current_blue) / timeline_position_difference);\
\
\9\9interpolated_value = drawing.argb_to_color(interpolated_alpha, interpolated_red, interpolated_green, interpolated_blue);\
\9end\
\
\9return interpolated_value;\
end\
\
function this.add_keyframe(keyframes, position, type)\
\9local keyframe_count = #keyframes;\
\
\9if position < 1 then\
\9\9position = 1;\
\9end\
\
\9if position > keyframe_count then\
\9\9position = keyframe_count + 1;\
\9end\
\
\9if position == 1 then\
\9\9local next_keyframe = keyframes[1];\
\
\9\9local new_keyframe = {};\
\9\9new_keyframe.timeline_position = next_keyframe.timeline_position / 2;\
\9\9new_keyframe.value = next_keyframe.value;\
\9\
\9\9table.insert(keyframes, position, new_keyframe);\
\
\9\9return;\
\9end\
\
\9if position == keyframe_count + 1 then\
\9\9local current_keyframe = keyframes[keyframe_count];\
\
\9\9local new_keyframe = {};\
\9\9new_keyframe.timeline_position = (1 + current_keyframe.timeline_position) / 2;\
\9\9new_keyframe.value = current_keyframe.value;\
\9\
\9\9table.insert(keyframes, new_keyframe);\
\
\9\9return;\
\9end\
\
\9local current_keyframe = keyframes[position - 1];\
\9local next_keyframe = keyframes[position];\
\
\9local new_keyframe = {};\
\9new_keyframe.timeline_position = (current_keyframe.timeline_position + next_keyframe.timeline_position) / 2;\
\9new_keyframe.value = (current_keyframe.value + next_keyframe.value) / 2;\
\
\9table.insert(keyframes, position, new_keyframe);\
end\
\
function this.remove_keyframe(keyframes, position)\
\9local keyframe_count = #keyframes;\
\
\9if keyframe_count == 0 then\
\9\9return;\
\9end\
\
\9if position < 1 then\
\9\9position = 1;\
\9end\
\
\9if position > keyframe_count then\
\9\9position = keyframe_count;\
\9end\
\
\9table.remove(keyframes, position);\
end\
\
function this.init_module()\
\9drawing = require(\"Damage_Numbers.drawing\");\
end\
\
return this;", '@'..".\\Damage_Numbers\\keyframe_handler.lua" ) )

package.preload[ "Damage_Numbers.player_handler" ] = assert( (loadstring or load)( "local this = {};\
\
local utils;\
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
this.player = {};\
this.player.is_aiming = false;\
this.player.is_guarding = false;\
\
-- local player_manager_type_def = sdk.find_type_definition(\"app.PlayerManager\");\
-- local get_current_position_method = player_manager_type_def:get_method(\"get_CurrentPosition\");\
-- local get_current_player_condition_method = player_manager_type_def:get_method(\"get_CurrentPlayerCondition\");\
\
-- local player_condition_type_def = get_current_player_condition_method:get_return_type();\
-- local get_is_hold_method = player_condition_type_def:get_method(\"get_IsHold\");\
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
function this.update()\
\9local inventory_manager = singletons.inventory_manager;\
\9if inventory_manager == nil then\
\9\9error_handler.report(\"player_handler.update\", \"No InventoryManager\");\
\9\9return;\
\9end\
\
\9local inventory = inventory_field:get_data(inventory_manager);\
\9if inventory == nil then\
\9\9error_handler.report(\"player_handler.update\", \"No Inventory\");\
\9\9return;\
\9end\
\
\9local player_status = player_status_field:get_data(inventory);\
\9if player_status == nil then\
\9\9error_handler.report(\"player_handler.update\", \"No PlayerStatus\");\
\9\9return;\
\9end\
\
\9this.update_is_aiming(player_status);\
\9this.update_is_guarding(player_status);\
end\
\
function this.update_is_aiming(player_status)\
\9local is_aim = get_is_aim_method:call(player_status);\
\9if is_aim == nil then\
\9\9error_handler.report(\"player_handler.update_is_aiming\", \"No IsAim\");\
\9\9return;\
\9end\
\
\9this.player.is_aiming = is_aim;\
end\
\
function this.update_is_guarding(player_status)\
\9local is_guard = get_is_guard_method:call(player_status);\
\9if is_guard == nil then\
\9\9error_handler.report(\"player_handler.update_is_guarding\", \"No IsGuard\");\
\9\9return;\
\9end\
\
\9this.player.is_guarding = is_guard;\
end\
\
function this.init_module()\
\9utils = require(\"Damage_Numbers.utils\");\
\9singletons = require(\"Damage_Numbers.singletons\");\
\9error_handler = require(\"Damage_Numbers.error_handler\");\
end\
\
return this;", '@'..".\\Damage_Numbers\\player_handler.lua" ) )

package.preload[ "Damage_Numbers.screen" ] = assert( (loadstring or load)( "local this = {};\
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
\9config = require(\"Damage_Numbers.config\");\
\9singletons = require(\"Damage_Numbers.singletons\");\
\9utils = require(\"Damage_Numbers.utils\");\
end\
\
return this;\
", '@'..".\\Damage_Numbers\\screen.lua" ) )

package.preload[ "Damage_Numbers.singletons" ] = assert( (loadstring or load)( "local this = {};\
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
local menu_manager_name = \"app.MenuManager\";\
\
this.game_manager = nil;\
this.inventory_manager = nil;\
this.menu_manager = nil;\
\
function this.update()\
\9this.update_game_manager();\
\9this.update_inventory_manager();\
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
\9customization_menu = require(\"Damage_Numbers.customization_menu\");\
\9error_handler = require(\"Damage_Numbers.error_handler\");\
\
\9this.update();\
end\
\
return this;\
", '@'..".\\Damage_Numbers\\singletons.lua" ) )

package.preload[ "Damage_Numbers.time" ] = assert( (loadstring or load)( "local this = {};\
\
local singletons;\
local customization_menu;\
local config;\
local utils;\
local screen;\
local game_handler;\
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
\9\
\9timer.last_trigger_time = os.clock() + start_offset_seconds;\
\
\9this.timer_list[callback] =  timer;\
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
\9singletons = require(\"Damage_Numbers.singletons\");\
\9screen = require(\"Damage_Numbers.screen\");\
\9customization_menu = require(\"Damage_Numbers.customization_menu\");\
\9config = require(\"Damage_Numbers.config\");\
\9utils = require(\"Damage_Numbers.utils\");\
\9game_handler = require(\"Damage_Numbers.game_handler\");\
\9player_handler = require(\"Damage_Numbers.player_handler\");\
end\
\
return this;", '@'..".\\Damage_Numbers\\time.lua" ) )

package.preload[ "Damage_Numbers.utils" ] = assert( (loadstring or load)( "local this = {};\
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
\
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
function this.vec2.random(distance, min_direction, max_direction)\
\9distance = distance or 1;\
\9min_direction = min_direction or 0;\
\9max_direction = max_direction or 360;\
\
\9if min_direction > max_direction then\
\9\9local temp = min_direction;\
\9\9min_direction = max_direction;\
\9\9max_direction = temp;\
\9end\
\
\9min_direction = min_direction / 360;\
\9max_direction = max_direction / 360;\
\
\9local radians = ((max_direction - min_direction) * math.random() + min_direction) * math.pi * 2;\
\
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
return this;", '@'..".\\Damage_Numbers\\utils.lua" ) )

assert( (loadstring or load)( "local sdk = sdk;\
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
local time = require(\"Damage_Numbers.time\");\
local drawing = require(\"Damage_Numbers.drawing\");\
local utils = require(\"Damage_Numbers.utils\");\
local config = require(\"Damage_Numbers.config\");\
local screen = require(\"Damage_Numbers.screen\");\
local singletons = require(\"Damage_Numbers.singletons\");\
local error_handler = require(\"Damage_Numbers.error_handler\");\
\
local keyframe_customization = require(\"Damage_Numbers.keyframe_customization\");\
local customization_menu = require(\"Damage_Numbers.customization_menu\");\
\
local keyframe_handler = require(\"Damage_Numbers.keyframe_handler\");\
local damage_handler = require(\"Damage_Numbers.damage_handler\");\
local game_handler = require(\"Damage_Numbers.game_handler\");\
local player_handler = require(\"Damage_Numbers.player_handler\");\
\
------------------------INIT MODULES-------------------------\
-- #region\
time.init_module();\
drawing.init_module();\
utils.init_module();\
config.init_module();\
screen.init_module();\
singletons.init_module();\
error_handler.init_module();\
\
keyframe_customization.init_module();\
customization_menu.init_module();\
\
keyframe_handler.init_module();\
damage_handler.init_module();\
\
game_handler.init_module();\
player_handler.init_module();\
\
log.info(\"[Damage Numbers] Loaded.\");\
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
\9damage_handler.tick();\
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
\
\9if imgui.button(\"Damage Numbers v\" .. config.current_config.version .. \"##DAMAGE_NUMBERS\") then\
\9\9customization_menu.is_opened = not customization_menu.is_opened;\
\9end\
\
\9imgui.same_line();\
\
\9changed, cached_config.enabled = imgui.checkbox(\"Enabled##DAMAGE_NUMBERS\", cached_config.enabled);\
\9if changed then\
\9\9config.save();\
\9end\
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
\9end, function() \
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
time.init_global_timers();", '@'.."Damage_Numbers.lua" ) )( ... )

