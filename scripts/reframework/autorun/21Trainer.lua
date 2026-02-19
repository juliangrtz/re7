if reframework:get_game_name() ~= "re7" then
    re.msg("[21 Trainer] Only compatible with RE7!")
    return
end

-- Taken from https://residentevil.fandom.com/wiki/Trump_cards.
local trumpCards = {
    { id = 10, name = "BetUp_1p", friendly = "One-Up", desc = "Draw 1 trump card; opponent’s bet +1 while on table." },
    { id = 12, name = "BetUp_2p", friendly = "Two-Up", desc = "Draw 1 trump card; opponent’s bet +2 while on table." },
    { id = 30, name = "Draw_2", friendly = "2-Card", desc = "Draw the 2-card. If it’s no longer in the deck, nothing happens." },
    { id = 31, name = "Draw_3", friendly = "3-Card", desc = "Draw the 3-card. If it’s no longer in the deck, nothing happens." },
    { id = 32, name = "Draw_4", friendly = "4-Card", desc = "Draw the 4-card. If it’s no longer in the deck, nothing happens." },
    { id = 33, name = "Draw_5", friendly = "5-Card", desc = "Draw the 5-card. If it’s no longer in the deck, nothing happens." },
    { id = 34, name = "Draw_6", friendly = "6-Card", desc = "Draw the 6-card. If it’s no longer in the deck, nothing happens." },
    { id = 35, name = "Draw_7", friendly = "Remove", desc = "Draw the 7-card. If it’s no longer in the deck, nothing happens." },
    { id = 54, name = "Return", friendly = "Return", desc = "Return the last face-up card you drew to the deck." },
    { id = 53, name = "Exchange", friendly = "Exchange", desc = "Swap the last cards drawn by you and your opponent (face-down cannot be swapped)." },
    { id = 57, name = "Destroy_p", friendly = "Destroy+", desc = "Remove all your opponent’s trump cards from the table." },
    { id = 58, name = "Destroy_pp", friendly = "Destroy++", desc = "Remove all opponent’s trump cards; they cannot use trump cards while this card is on the table." },
    { id = 56, name = "Destroy", friendly = "Destroy", desc = "Remove your opponent’s last placed trump card from the table." },
    { id = 45, name = "PerfectDraw", friendly = "Perfect Draw", desc = "Draw the best possible card from the deck." },
    { id = 47, name = "PerfectDraw_p", friendly = "Perfect Draw+", desc = "Draw the best possible card; opponent’s bet +5 while on table." },
    { id = 80, name = "Goal_24", friendly = "Go for 24", desc = "Closest to 24 wins while card is on table; replaces other Go-For cards." },
    { id = 82, name = "Goal_17", friendly = "Go for 17", desc = "Closest to 17 wins while card is on table; replaces other Go-For cards." },
    { id = 81, name = "Goal_27", friendly = "Go for 27", desc = "Closest to 27 wins while card is on table; replaces other Go-For cards." },
    { id = 50, name = "Gift", friendly = "Love Your Enemy", desc = "Your opponent draws the best possible card for them." },
    { id = 51, name = "SPChange", friendly = "Trump Switch", desc = "Discard two trump cards at random, then draw three more cards." },
    { id = 52, name = "SPChange_p", friendly = "Trump Switch+", desc = "Discard one trump card at random, then draw four more cards." },
}

local trumpCardComboValues = {}
for _, v in ipairs(trumpCards) do table.insert(trumpCardComboValues, v.friendly) end
local selectedTrumpCardIdx = 1
local currentTrumpCardId = 10
local cardGameMaster
local alwaysWin = false

local function cardGameManager()
    return sdk.get_managed_singleton("app.CardGameManager")
end

sdk.hook(
    sdk.find_type_definition("app.CardGameMaster"):get_method("update"),
    function(args)
        if cardGameMaster ~= nil then return end
        cardGameMaster = sdk.to_managed_object(args[2])
    end,
    function(_) end
)

local posType
sdk.hook(
    sdk.find_type_definition("app.CardGameMaster"):get_method("calcSum"),
    function(args)
        if alwaysWin then
            posType = sdk.to_int64(args[3]) & 0xFFFFFFFF
        end
    end,
    function(retval)
        if alwaysWin then
            -- 0=Stock, 1=Banker, 2=Player
            if posType == 2 then
                return sdk.to_ptr(21)
            elseif posType == 1 then
                return sdk.to_ptr(666)
            end
        end
        return retval
    end
)

re.on_draw_ui(function()
    if imgui.tree_node("21 Trainer") then
        imgui.text("Just keep your current hand.")
        imgui.text("You will always have the best score.")
        local changedAlwaysWin
        changedAlwaysWin, alwaysWin = imgui.checkbox("Always win", alwaysWin)

        imgui.spacing()

        if imgui.tree_node("Trump cards") then
            local changedTrumpCard, new_index = imgui.combo("Trump card", selectedTrumpCardIdx, trumpCardComboValues)
            if changedTrumpCard then
                selectedTrumpCardIdx = new_index
                local entry = trumpCards[selectedTrumpCardIdx]
                currentTrumpCardId = entry.id
            end

            imgui.text(trumpCards[selectedTrumpCardIdx].desc)

            if imgui.button("Give selected trump card") and cardGameManager then
                cardGameManager():addPlayerHandItem(currentTrumpCardId)
            end

            imgui.tree_pop()
        end

        --[[ if imgui.tree_node("Miscellaneous") then
            if imgui.button("Force enemy's death") then
                local fingerMachine = cardGameManager():get_field("<bankerFingerMachine>k__BackingField")
                if fingerMachine then
                    fingerMachine:setBet(5)
                end

                local elecMachine = cardGameManager():get_field("<bankerElectricMachine>k__BackingField")
                if elecMachine then
                    elecMachine:setElectricDamageLevel(10)

                end
            end

            imgui.tree_pop()
        end ]]

        --[[ if imgui.tree_node("Developer Tools") then
            if imgui.button("Log trump cards") then
                local itemType = sdk.find_type_definition("app.CardGameItem.ItemType")
                local fields = itemType:get_fields()

                for _, field in ipairs(fields) do
                    if field:is_static() then
                        local name = field:get_name()
                        local value = field:get_data(nil)
                        print(string.format("%s = %s", name, tostring(value)))
                    end
                end
            end
            imgui.tree_pop()
        end ]]

        imgui.tree_pop()
    end
end)
