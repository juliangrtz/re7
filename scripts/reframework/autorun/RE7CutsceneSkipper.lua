if not reframework:get_game_name() == "re7" then return end
if sdk.get_tdb_version() == 49 then
	re.msg("Cutscene Skipper is not compatible with this build of RE7!")
end

local scene
scene_timer = 0
while scene_timer < 100 and not pcall(function()
		scene = sdk.call_native_func(sdk.get_native_singleton("via.SceneManager"),
			sdk.find_type_definition("via.SceneManager"), "get_CurrentScene()")
		scene_timer = nil
	end) do
	scene_timer = scene_timer + 1
end

local message_display_timer
local cutscene_obj, cs_gameobj
local tics = 0
local changed, was_changed
local cs_name, last_cs_name
local stop_wwise
local is_skipping = false
--local save_mgr
local paused_playtime = false
local cs_timer


local cutscenes_dict = json.load_string([[{
	"c00e00_00": {
		"active": true
	},
	"c01e00_00": {
		"active": true
	},
	"c01e05_00": {
		"active": true
	},
	"c01e05_02": {
		"active": true
	},
	"c01e07_00": {
		"active": true
	},
	"c01e07_01": {
		"active": true
	},
	"c01e08_00": {
		"active": true
	},
	"c03e00_00": {
		"active": true
	},
	"c03e01_00": {
		"active": true
	},
	"c03e04_00": {
		"active": true
	},
	"c03e41_00": {
		"active": true
	},
	"c03e55_00": {
		"active": true
	},
	"c04e00_00": {
		"active": true
	},
	"c04e10_00": {
		"active": true
	},
	"c04e12_00": {
		"active": true
	},
	"c04e12_01": {
		"active": true
	},
	"c04e20_00": {
		"active": true
	},
	"c04e25_00": {
		"active": true
	},
	"c04e74_00": {
		"active": true
	},
	"c04e80_00": {
		"active": true
	},
	"c04e80_01": {
		"active": true
	},
	"c04e82_00": {
		"active": true
	},
	"c04f00_00": {
		"active": true
	},
	"c04f01_00": {
		"active": true
	},
	"c04e38_00": {
		"active": false,
		"name": "Mia chainsaw hand flashback",
		"delay": 1.0
	},
	"c04e81_00": {
		"active": true
	},
	"c04e65_00": {
		"active": false
	},
	
	"c03e51_10": {
		"active": true,
		"name": "Mia Bound talk"
	},
	"c03e50_00": {
		"active": false,
		"name": "Zoe Bound Intro"
	},
	"c03e51_00": {
		"active": false,
		"name": "Zoe Unbinding"
	},
	"c03e51_20": {
		"active": false,
		"name": "Zoe Receive Serum"
	},
	"c03e63_00": {
		"active": false,
		"name": "Final Jack Intro",
		"delay": 1.0
	},
	"c03e64_00": {
		"active": true
	},
	"c03e64_02": {
		"active": true
	},
	"c03e53_00": {
		"active": true
	},
	"c03e54_00": {
		"active": true
	},
	"c04e01_00": {
		"active": true
	},
	"c03e52_00": {
		"active": true,
		"name": "Walk to Mia + Zoe on dock",
		"delay": 1.0
	}
}]])

local default_settings = {
	mod_enabled = true,
	auto_skip = true,
	stop_all_audio = false,
}

local re7csettings = json.load_file("RE7CutsceneSkipperSettings.json") or {}

for k, v in pairs(default_settings) do
	if re7csettings[k] == nil then
		re7csettings[k] = v
	end
end

re.on_application_entry("UpdateMotion", function()
	cutscene_obj = scene:call("findComponents(System.Type)", sdk.typeof("app.GameEventController"))[0]
end)

local keys = {
	Enter = 13,
	Space = 32,
	Escape = 27,
}

local kb_state = {
	down = {
		[keys.Enter] = false,
		[keys.Space] = false,
	},
	released = {
		[keys.Enter] = false,
		[keys.Space] = false,
	},
	timers = {
		[keys.Enter] = os.clock(),
		[keys.Space] = os.clock(),
	},
}

local kb_typedef = sdk.find_type_definition("via.hid.Keyboard")
local gp_typedef = sdk.find_type_definition("via.hid.GamePad")

re.on_application_entry("UpdateHID", function()
	local kb = sdk.call_native_func(sdk.get_native_singleton("via.hid.Keyboard"), kb_typedef, "get_Device")
	if kb then
		local time = os.clock()
		for key, state in pairs(kb_state.down) do
			kb_state.down[key] = kb:call("isDown", key)
		end
		for key, state in pairs(kb_state.released) do
			kb_state.released[key] = kb:call("isRelease", key)
		end
		for key, state in pairs(kb_state.timers) do
			kb_state.timers[key] = ((kb_state.down[key] or kb_state.released[key]) and kb_state.timers[key]) or time
		end
	end
end)

local function cs()
	was_changed = was_changed or changed
end

re.on_draw_ui(function()
	was_changed = false
	if imgui.tree_node("RE7 Cutscene Skipper") then
		imgui.spacing()
		imgui.begin_rect()
		changed, re7csettings.mod_enabled = imgui.checkbox("Enabled", re7csettings.mod_enabled); cs()
		imgui.same_line()
		changed, re7csettings.auto_skip = imgui.checkbox("Auto Skip", re7csettings.auto_skip); cs()
		if imgui.is_item_hovered() then
			imgui.set_tooltip(re7csettings.auto_skip and "Skip all cutscenes automatically" or
				"Hold SPACE to skip a cutscene")
		end
		--changed, re7csettings.stop_all_audio = imgui.checkbox("Stop All Audio on Skip", re7csettings.stop_all_audio);  cs()
		imgui.end_rect(3)
		imgui.tree_pop()
	end

	if was_changed then
		json.dump_file("RE7CutsceneSkipperSettings.json", re7csettings)
	end

	imgui.text()
end)

local function change_speed(is_skipping, tbl)
	if is_skipping then
		cs_timer = nil
		scene:call("set_TimeScale(System.Single)", 1.0)
		if stop_wwise then
			stop_wwise()
		end
	else
		if tv then
			cutscene_obj:set_field("IsMovieCancel", true)
		else
			scene:call("set_TimeScale(System.Single)", tbl and tbl.speed or 100.1)
		end

		local timer = os.clock()
		stop_wwise = stop_wwise or function()
			if os.clock() - timer < 0.75 then return end
			local try, wwises = pcall(scene.call, scene, "findComponents(System.Type)",
				sdk.typeof("via.wwise.WwiseContainer")) --
			if try and wwises and wwises.get_elements then
				for i, wwise in ipairs(wwises:get_elements()) do
					stop_wwise = nil
					if re7csettings.stop_all_audio then
						wwise:call("stopAll()")
					else
						for c = 0, wwise:call("getContainableAssetCount") - 1 do
							local asset = wwise:call("getContainableAsset", c)
							local asset_path = asset and asset:call("get_ResourcePath")
							if asset_path and asset_path:lower():find("event") then
								wwise:call("stopAll()")
								break
							end
						end
					end
				end
			end
		end
	end
end

re.on_frame(function()
	tics = tics + 1

	if tics > 1 and re7csettings.mod_enabled then
		if not scene then return end
		systemObject = scene:call("findGameObject(System.String)", "SystemObject")
		if not systemObject then return end
		save_mgr = systemObject:call("getComponent(System.Type)", sdk.typeof("app.SaveDataManager"))

		local current_speed = scene:call("get_TimeScale()") or 1.0
		is_skipping = (current_speed > 50.0)

		player_cam = scene:call("findComponents(System.Type)", sdk.typeof("app.PlayerCamera"))[0]
		player_gameobj = player_cam and player_cam:call("get_GameObject")
		tv = (player_gameobj and not cutscene_obj) and scene:call("findGameObject(System.String)", "movieBox_640_480")

		if tv then
			local video_ctrl = tv:call("getComponent(System.Type)", sdk.typeof("app.VideoControl"))
			if video_ctrl and video_ctrl:call("getMovieState") == 2 then -- via::movie::Movie -> PlayState
				cutscene_obj = video_ctrl
			end
		end

		if cutscene_obj then
			cs_gameobj = cutscene_obj:call("get_GameObject")
			last_cs_name = cs_name
			cs_name = cs_gameobj:call("get_Name"):gsub("_Controller", "")
			last_cs_name = last_cs_name or cs_name
			local cs_updated = (last_cs_name ~= cs_name)

			space_key_down_time = os.clock() - kb_state.timers[keys.Space]
			message_display_timer = (kb_state.down[keys.Space] and os.clock()) or message_display_timer
			local tbl = cutscenes_dict[cs_name] or {}

			save_mgr:set_field("_IsPlayTimePause", true)
			paused_playtime = true

			--imgui.text(cs_name)

			if tbl.active or tv then
				local do_auto_skip = re7csettings.auto_skip and not tbl.no_auto

				local can_continue = true
				if tbl.delay then
					cs_timer = cs_timer or os.clock()
					can_continue = (os.clock() - cs_timer > tbl.delay)
				end
				--[[if player_gameobj then
					local gun = player_gameobj:call("getComponent(System.Type)", sdk.typeof("app.PlayerGun"))
					if gun and gun:call("get_isAttackAcceptedStatus") then
						can_continue = false
					end
					--local humanoid = can_continue and player_gameobj:call("getComponent(System.Type)", sdk.typeof("app.Humanoid"))
					--if humanoid and humanoid:call("get_Enabled") then
					--	can_continue = false
					--end
					local cc = can_continue and player_gameobj:call("getComponent(System.Type)", sdk.typeof("via.physics.CharacterController"))
					if cc and cc:call("get_Enabled") then
						can_continue = false
					end
				end]]

				if not can_continue then
					--imgui.text("Can't continue")
					if is_skipping then change_speed(true) end
				elseif do_auto_skip or (message_display_timer and os.clock() - message_display_timer < 1.0) then
					local size = sdk.call_native_func(
						sdk.call_native_func(scene_manager, sdk.find_type_definition("via.SceneManager"), "get_MainView"),
						sdk.find_type_definition("via.SceneView"), "get_Size")
					size = { w = size:get_field("w"), h = size:get_field("h") }
					imgui.set_next_window_pos({ size.w / 2 + ((size.w / 8) * -0.33), 0 }, 3, { 0, 0 })
					imgui.set_next_window_size({ 300, 24 }, 3)
					imgui.begin_window("RE7 Cutscene Skipper", true, 129)
					if not do_auto_skip then
						imgui.text("Hold SPACE to Skip")
					end
					if (not is_skipping and (do_auto_skip or space_key_down_time > 0.5)) or (is_skipping and kb_state.released[keys.Space]) then
						change_speed(is_skipping)
					end
				end
			elseif is_skipping then
				change_speed(true)
			end

			imgui.end_window()
		else
			timer = nil
			if is_skipping then
				pcall(scene.call, scene, "set_TimeScale(System.Single)", 1.0)
			end
			if paused_playtime then
				paused_playtime = false
				save_mgr:set_field("_IsPlayTimePause", false)
			end
			if stop_wwise then
				stop_wwise()
			end
		end
	end
end)
