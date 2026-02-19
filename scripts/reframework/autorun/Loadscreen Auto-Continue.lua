local Game = reframework:get_game_name()
if not Game:find("re[2478]") then return end

local LoadscreenName
local PromptName
local BehaviorName
if Game == "re2" then LoadscreenName = "GUI_GameSceneLoading"; PromptName = "<PanelSkip>k__BackingField"; BehaviorName = "gui.GameSceneLoadingBehavior"
elseif Game == "re4" then LoadscreenName = "Gui_ui0600"; PromptName = "_SkipGuide"; BehaviorName = "LoadingGuiBehavior"
elseif Game == "re7" then LoadscreenName = "TipsGUI"; PromptName = "SkipPanel"; BehaviorName = "TipsGUI"
elseif Game == "re8" then LoadscreenName = "GUISceneLoading"; PromptName = "<buttonText>k__BackingField"; BehaviorName = "GUISceneLoading"
end
local function Scene() return sdk.call_native_func(sdk.get_native_singleton("via.SceneManager"), sdk.find_type_definition("via.SceneManager"), "get_CurrentScene()") end
local function LoadscreenGUI() if Scene() then return Scene():call("findGameObject(System.String)", LoadscreenName) end end
local function IsLoading() return LoadscreenGUI() and LoadscreenGUI():get_Draw() end

local function LoadscreenAutoContinue()
	if not IsLoading() then return end
	local LoadingBehavior = LoadscreenGUI():call("getComponent(System.Type)", sdk.typeof(sdk.game_namespace(BehaviorName)))

	-- Hide continue prompt
	local ContinuePrompt = LoadingBehavior[PromptName]
	if ContinuePrompt and ContinuePrompt:get_Visible() then
		ContinuePrompt:set_Visible(false)
		if Game:find("re[478]") then ContinuePrompt:set_ForceInvisible(true) end
	end

	-- Close loadscreen when ready
	if Game == "re7" then
		if ContinuePrompt:get_PlayState() == "FADE_IN" then sdk.get_managed_singleton(sdk.game_namespace("NowLoadingMovieManager")):closeNowLoadingMovie() end -- Close loadscreen once (hidden) "Continue" text begins fade-in
	end
end

re.on_frame(function()
	LoadscreenAutoContinue()
end)