local imgui = imgui

--- Creates a new window with the title of name.
--- open is a bool. Can be nil. If not nil, a close button will be shown in the top right of the window.
--- flags - ImGuiWindowFlags.
--- begin_window must have a corresponding end_window call.
--- This function may only be called in on_frame, not on_draw_ui.
--- Returns a bool. Returns false if the user wants to close the window.
---@param name string
---@param open boolean
---@param flags ImGuiWindowFlags|number
---@return boolean
local function imgui_begin_window(name, open, flags)
    return imgui.begin_window(name, open, flags)
end

--- Ends the last begin_window call. Required.
local function imgui_end_window()
    imgui.end_window()
end

---@param size Vector2f
---@param border boolean
---@param flags ImGuiWindowFlags|number
---@return unknown
local function imgui_begin_child_window(size, border, flags)
    imgui.begin_child_window(size, border, flags)
end

local function imgui_end_child_window()
    return imgui.end_child_window()
end

local function imgui_begin_group()
    return imgui.begin_group()
end

local function imgui_end_group()
    return imgui.end_group()
end

local function imgui_begin_rect()
    return imgui.begin_rect()
end

--- These two methods draw a rectangle around the elements between begin_rect and end_rect
---@param additional_size number
---@param rounding number
local function imgui_end_rect(additional_size, rounding)
    imgui.end_rect(additional_size, rounding)
end

--- Will disable and darken elements in between it and end.
---@param disabled boolean|nil (default true)
local function imgui_begin_disabled(disabled)
    if disabled == nil then
        disabled = true
    end
    imgui.begin_disabled(disabled)
end

--- Ends disable and darken elements.
local function imgui_end_disabled()
    imgui.end_disabled()
end

--- Draws a button with label text, and optional size.
--- Returns true when the user presses the button.
---@param label string
---@param size Vector2f|table (size 2 array)
---@return boolean
local function imgui_button(label, size)
    return imgui.button(label, size)
end

---@param label string
---@return boolean
local function imgui_small_button(label)
    return imgui.small_button(label)
end

--- size is a Vector2f or a size 2 array.
---@param id string
---@param size Vector2f|table (size 2 array)
---@param flags number
---@return boolean
local function imgui_invisible_button(id, size, flags)
    return imgui.invisible_button(id, size, flags)
end

---@param id string
---@param dir number (ImguiDir)
---@return boolean
local function imgui_arrow_button(id, dir)
    return imgui.arrow_button(id, dir)
end

--- Draws text.
---@param text string
local function imgui_text(text)
    imgui.text(text)
end

--- Draws text with color.
--- color is an integer color in the form ARGB.
---@param text string
---@param color number (unsigned int)
local function imgui_text_colored(text, color)
    imgui.text_colored(text, color)
end

--- Returns a tuple of changed, value
---@param label string
---@param value boolean
---@return boolean,boolean
local function imgui_checkbox(label, value)
    return imgui.checkbox(label, value)
end

--- Returns a tuple of changed, value
---@param label string
---@param value number
---@param speed number
---@param min number
---@param max number
---@param display_format string (ex "%.3f")
---@return boolean,number
local function imgui_drag_float(label, value, speed, min, max, display_format)
    return imgui.drag_float(label, value, speed, min, max, display_format)
end

--- Returns a tuple of changed, value
---@param label string
---@param value Vector2f
---@param speed number
---@param min number
---@param max number
---@param display_format string (ex "%.3f")
---@return boolean,Vector2f
local function imgui_drag_float2(label, value, speed, min, max, display_format)
    return imgui.drag_float2(label, value, speed, min, max, display_format)
end

--- Returns a tuple of changed, value
---@param label string
---@param value Vector3f
---@param speed number
---@param min number
---@param max number
---@param display_format string (ex "%.3f")
---@return boolean,Vector3f
local function imgui_drag_float3(label, value, speed, min, max, display_format)
    return imgui.drag_float3(label, value, speed, min, max, display_format)
end

--- Returns a tuple of changed, value
---@param label string
---@param value Vector4f
---@param speed number
---@param min number
---@param max number
---@param display_format string (ex "%.3f")
---@return boolean,Vector4f
local function imgui_drag_float4(label, value, speed, min, max, display_format)
    return imgui.drag_float4(label, value, speed, min, max, display_format)
end

--- Returns a tuple of changed, value
---@param label string
---@param value number
---@param speed number
---@param min number
---@param max number
---@param display_format string (ex "%d")
---@return boolean,number
local function imgui_drag_int(label, value, speed, min, max, display_format)
    return imgui.drag_int(label, value, speed, min, max, display_format)
end

--- Returns a tuple of changed, value
---@param label string
---@param value number
---@param min number
---@param max number
---@param display_format string (ex "%.3f")
---@return boolean,number
local function imgui_slider_float(label, value, min, max, display_format)
    return imgui.slider_float(label, value, min, max, display_format)
end

--- Returns a tuple of changed, value
---@param label string
---@param value number
---@param min number
---@param max number
---@param display_format string (ex "%d")
---@return boolean,number
local function imgui_slider_int(label, value, min, max, display_format)
    return imgui.slider_int(label, value, min, max, display_format)
end

--- Returns a tuple of changed, value, selection_start, selection_end
---@param label string
---@param value string
---@param flags ImGuiInputTextFlags|number
---@return boolean,string,number,number
local function imgui_input_text(label, value, flags)
    return imgui.input_text(label, value, flags)
end

--- Returns a tuple of changed, value, selection_start, selection_end
---@param label string
---@param value string
---@param size Vector2f
---@param flags ImGuiInputTextFlags|number
---@return boolean,string,number,number
local function imgui_input_text_multiline(label, value, size, flags)
    return imgui.input_text_multiline(label, value, size, flags)
end

--- Returns a tuple of changed, value. 
--- changed = true when selection changes. 
--- value is the selection index within values (a table)
--- values can be a table with any type of keys, as long as the values are strings.
---@param label string
---@param selection number
---@param values table
---@return boolean,number
local function imgui_combo(label, selection, values)
    return imgui.combo(label, selection, values)
end

--- Returns a tuple of changed, value. color is an integer color in the form ABGR which imgui and draw APIs expect.
---@param label string
---@param color number
---@param flags ImGuiColorEditFlags|number
---@return boolean,number
local function imgui_color_picker(label, color, flags)
    return imgui.color_picker(label, color, flags)
end

--- Returns a tuple of changed, value. color is an integer color in the form ARGB.
---@param label string
---@param color number
---@param flags ImGuiColorEditFlags|number
---@return boolean,number
local function imgui_color_picker_argb(label, color, flags)
    return imgui.color_picker_argb(label, color, flags)
end

--- Returns a tuple of changed, value
---@param label string
---@param color Vector3f
---@param flags ImGuiColorEditFlags|number
---@return boolean,Vector3f
local function imgui_color_picker3(label, color, flags)
    return imgui.color_picker3(label, color, flags)
end

--- Returns a tuple of changed, value
---@param label string
---@param color Vector4f
---@param flags ImGuiColorEditFlags|number
---@return boolean,Vector4f
local function imgui_color_picker4(label, color, flags)
    return imgui.color_picker4(label, color, flags)
end

--- Returns a tuple of changed, value. color is an integer color in the form ABGR which imgui and draw APIs expect.
---@param label string
---@param color number
---@param flags ImGuiColorEditFlags|number
---@return boolean,number
local function imgui_color_edit(label, color, flags)
    return imgui.color_edit(label, color, flags)
end

--- Returns a tuple of changed, value. color is an integer color in the form ARGB.
---@param label string
---@param color number
---@param flags ImGuiColorEditFlags|number
---@return boolean,number
local function imgui_color_edit_argb(label, color, flags)
    return imgui.color_edit_argb(label, color, flags)
end

--- Returns a tuple of changed, value
---@param label string
---@param color Vector3f
---@param flags ImGuiColorEditFlags|number
---@return boolean,Vector3f
local function imgui_color_edit3(label, color, flags)
    return imgui.color_edit3(label, color, flags)
end

--- Returns a tuple of changed, value
--- flags for color_picker/edit APIs: ImGuiColorEditFlags
---@param label string
---@param color Vector4f
---@param flags ImGuiColorEditFlags|number
---@return boolean,Vector4f
local function imgui_color_edit4(label, color, flags)
    return imgui.color_edit4(label, color, flags)
end

--- Begins a tree node
---@param label string
---@return boolean
local function imgui_tree_node(label)
    return imgui.tree_node(label)
end

--- Begins a tree node
---@param id any
---@param label string
---@return boolean
local function imgui_tree_node_ptr_id(id, label)
    return imgui.tree_node_ptr_id(id, label)
end

--- Begins a tree node
---@param id string
---@param label string
---@return boolean
local function imgui_tree_node_str_id(id, label)
    return imgui.tree_node_str_id(id, label)
end

--- All of the above tree functions must have a corresponding tree_pop!
local function imgui_tree_pop()
    imgui.tree_pop()
end

--- Keeps the next item on the same line
local function imgui_same_line()
    imgui.same_line()
end

--- Adds space
local function imgui_spacing()
    imgui.spacing()
end

--- Adds a new line
local function imgui_new_line()
    imgui.new_line()
end

---@param flags ImGuiHoveredFlags|number
---@return boolean
local function imgui_is_item_hovered(flags)
    return imgui.is_item_hovered(flags)
end

---@return boolean
local function imgui_is_item_active()
    return imgui.is_item_active()
end

---@return boolean
local function imgui_is_item_focused()
    return imgui.is_item_focused()
end

---@param name string
---@return boolean
local function imgui_collapsing_header(name)
    return imgui.collapsing_header(name)
end

--- Loads a font file from the reframework/fonts subdirectory at the specified size with optional Unicode ranges (an array of start, end pairs ending with 0).
--- Returns a handle for use with imgui.push_font(). If filepath is nil, it will load the default font at the specified size.
---@param filepath string
---@param size number (int)
---@param ranges table
---@return any
local function imgui_load_font(filepath, size, ranges)
    return imgui.load_font(filepath, size, ranges)
end

--- Sets the font to be used for the next set of ImGui widgets/draw commands until imgui.pop_font is called.
---@param font any
local function imgui_push_font(font)
    imgui.push_font(font)
end

--- Unsets the previously pushed font.
local function imgui_pop_font()
    imgui.pop_font()
end

--- Returns size of the default font for REFramework's UI.
---@return number
local function imgui_get_default_font_size()
    return imgui.get_default_font_size()
end

--- condition is the ImGuiCond enum.
--- enum ImGuiCond_
--- {
---     ImGuiCond_None          = 0,              // No condition (always set the variable), same as _Always
---     ImGuiCond_Always        = 1 &lt;&lt; 0,   // No condition (always set the variable)
---     ImGuiCond_Once          = 1 &lt;&lt; 1,   // Set the variable once per runtime session (only the first call will succeed)
---     ImGuiCond_FirstUseEver  = 1 &lt;&lt; 2,   // Set the variable if the object/window has no persistently saved data (no entry in .ini file)
---     ImGuiCond_Appearing     = 1 &lt;&lt; 3    // Set the variable if the object/window is appearing after being hidden/inactive (or the first time)
--- };
---@param pos Vector2f
---@param condition ImGuiCond|number
---@param pivot Vector2f|table
local function imgui_set_next_window_pos(pos, condition, pivot)
    imgui.set_next_window_pos(pos, condition, pivot)
end

--- condition is the ImGuiCond enum.
---@param size Vector2f
---@param condition ImGuiCond|number
local function imgui_set_next_window_size(size, condition)
    imgui.set_next_window_size(size, condition)
end

--- id can be an int, const char*, or void*.
local function imgui_push_id(id)
    imgui.push_id(id)
end

local function imgui_pop_id()
    imgui.pop_id()
end

---@return number
local function imgui_get_id()
    return imgui.get_id()
end

--- Returns a Vector2f corresponding to the user's mouse position in window space.
---@return Vector2f
local function imgui_get_mouse()
    return imgui.get_mouse()
end

--- progress is a float between 0 and 1.
--- size is a Vector2f or a size 2 array.
--- overlay is a string on top of the progress bar.
--- local progress = 0.0
--- re.on_frame(function()
---     progress = progress + 0.001
---     if progress &gt; 1.0 then 
---         progress = 0.0
---     end
--- end)
--- re.on_draw_ui(function()
---     imgui.progress_bar(progress, Vector2f.new(200, 20), string.format(&quot;Progress: %.1f%%&quot;, progress * 100))
--- end)
---@param progress number
---@param size Vector2f|table (size 2 array)
---@param overlay string
local function imgui_progress_bar(progress, size, overlay)
    imgui.progress_bar(progress, size, overlay)
end

---@param pos Vector2f|table (size 2 array)
---@param size Vector2f|table (size 2 array)
local function imgui_item_size(pos, size)
    imgui.item_size(pos, size)
end

--- Adds an item with the specified position and size to the current window.
---@param pos Vector2f|table (size 2 array)
---@param size Vector2f|table (size 2 array)
local function imgui_item_add(pos, size)
    imgui.item_add(pos, size)
end

--- Clears the current window's draw list path.
local function imgui_draw_list_path_clear()
    imgui.draw_list_path_clear()
end

--- Adds a line to the current window's draw list path given the specified pos
--- pos is a Vector2f or a size 2 array.
---@param pos Vector2f|table (size 2 array)
local function imgui_draw_list_path_line_to(pos)
    imgui.draw_list_path_line_to(pos)
end

--- Strokes the current window's draw list path with the specified color, closed state, and thickness.
--- color is an integer color in the form ARGB.
--- closed is a bool.
--- thickness is a float.
---@param color number (ARGB int)
---@param closed boolean
---@param thickness number
local function imgui_draw_list_path_stroke(color, closed, thickness)
    imgui.draw_list_path_stroke(color, closed, thickness)
end

--- Returns the index of the specified imgui_key.
---@param imgui_key number
---@return ImGuiKey|number
local function imgui_get_key_index(imgui_key)
    return imgui.get_key_index(imgui_key)
end

--- Returns true if the specified key is currently being held down.
---@param key ImGuiKey|number
---@return boolean
local function imgui_is_key_down(key)
    return imgui.is_key_down(key)
end

--- Returns true if the specified key was pressed during the current frame.
---@param key ImGuiKey|number
---@return boolean
local function imgui_is_key_pressed(key)
    return imgui.is_key_pressed(key)
end

--- Returns true if the specified key was released during the current frame.
---@param key ImGuiKey|number
---@return boolean
local function imgui_is_key_released(key)
    return imgui.is_key_released(key)
end

--- Returns true if the specified mouse button is currently being held down.
---@param button ImGuiMouseButton|number
---@return boolean
local function imgui_is_mouse_down(button)
    return imgui.is_mouse_down(button)
end

--- Returns true if the specified mouse button was clicked during the current frame.
---@param button ImGuiMouseButton|number
---@return boolean
local function imgui_is_mouse_clicked(button)
    return imgui.is_mouse_clicked(button)
end

--- Returns true if the specified mouse button was released during the current frame.
---@param button ImGuiMouseButton|number
---@return boolean
local function imgui_is_mouse_released(button)
    return imgui.is_mouse_released(button)
end

--- Returns true if the specified mouse button was double-clicked during the current frame.
---@param button ImGuiMouseButton|number
---@return boolean
local function imgui_is_mouse_double_clicked(button)
    return imgui.is_mouse_double_clicked(button)
end

--- Indents the current line by indent_width pixels.
---@param indent_width number
local function imgui_indent(indent_width)
    imgui.indent(indent_width)
end

--- Unindents the current line by indent_width pixels.
---@param indent_width number
local function imgui_unindent(indent_width)
    imgui.unindent(indent_width)
end

--- Starts a tooltip window that will be drawn at the current cursor position.
local function imgui_begin_tooltip()
    imgui.begin_tooltip()
end

--- Ends the current tooltip window.
local function imgui_end_tooltip()
    imgui.end_tooltip()
end

--- Sets the text for the current tooltip window.
---@param text string
local function imgui_set_tooltip(text)
    imgui.set_tooltip(text)
end

--- Opens a popup with the specified str_id and flags.
---@param str_id string
---@param flags ImGuiWindowFlags|number
local function imgui_open_popup(str_id, flags)
    imgui.open_popup(str_id, flags)
end

--- Begins a new popup with the specified str_id and flags.
---@param str_id string
---@param flags ImGuiWindowFlags|number
---@return boolean
local function imgui_begin_popup(str_id, flags)
    return imgui.begin_popup(str_id, flags)
end

--- Begins a new popup with the specified str_id and flags, anchored to the last item.
---@param str_id string
---@param flags ImGuiWindowFlags|number
---@return boolean
local function imgui_begin_popup_context_item(str_id, flags)
    return imgui.begin_popup_context_item(str_id, flags)
end

--- Ends the current popup window.
local function imgui_end_popup()
    imgui.end_popup()
end

--- Closes the current popup window.
local function imgui_close_current_popup()
    imgui.close_current_popup()
end

--- Returns true if the popup with the specified str_id is open.
---@param str_id string
---@return boolean
local function imgui_is_popup_open(str_id)
    return imgui.is_popup_open(str_id)
end

--- Calculates and returns the size of the specified text as a Vector2f.
---@param text string
---@return Vector2f
local function imgui_calc_text_size(text)
    return imgui.calc_text_size(text)
end

--- Returns the size of the current window as a Vector2f.
---@return Vector2f
local function imgui_get_window_size()
    return imgui.get_window_size()
end

--- Returns the position of the current window as a Vector2f.
---@return Vector2f
local function imgui_get_window_pos()
    return imgui.get_window_pos()
end

--- Sets the open state of the next collapsing header or tree node to is_open based on the specified condition.
---@param is_open boolean
---@param condition ImGuiCond|number
local function imgui_set_next_item_open(is_open, condition)
    imgui.set_next_item_open(is_open, condition)
end

--- Begins a new list box with the specified label and size.
---@param label string
---@param size Vector2f
---@return boolean
local function imgui_begin_list_box(label, size)
    return imgui.begin_list_box(label, size)
end

--- Ends the current list box.
local function imgui_end_list_box()
    imgui.end_list_box()
end

--- Begins a new menu bar.
local function imgui_begin_menu_bar()
    return imgui.begin_menu_bar()
end

--- Ends the current menu bar.
---@return boolean
local function imgui_end_menu_bar()
    return imgui.end_menu_bar()
end

--- Begins the main menu bar.
---@return boolean
local function imgui_begin_main_menu_bar()
    return imgui.begin_main_menu_bar()
end

--- Ends the main menu bar.
local function imgui_end_main_menu_bar()
    imgui.end_main_menu_bar()
end

--- Begins a new menu with the specified label. The menu will be disabled if enabled is false.
---comment
---@param label string
---@param enabled boolean
---@return boolean
local function imgui_begin_menu(label, enabled)
    return imgui.begin_menu(label, enabled)
end

--- Ends the current menu.
local function imgui_end_menu()
    imgui.end_menu()
end

--- Adds a menu item with the specified label, shortcut, selected state, and enabled state.
---@param label string
---@param shortcut string
---@param selected boolean
---@param enabled boolean
---@return boolean
local function imgui_menu_item(label, shortcut, selected, enabled)
    return imgui.menu_item(label, shortcut, selected, enabled)
end

--- Returns the size of the display as a Vector2f.
---@return Vector2f
local function imgui_get_display_size()
    return imgui.get_display_size()
end

--- Pushes the width of the next item to item_width pixels.
---@param item_width number
local function imgui_push_item_width(item_width)
    imgui.push_item_width(item_width)
end

--- Pops the last item width off the stack.
local function imgui_pop_item_width()
    imgui.pop_item_width()
end

--- Sets the width of the next item to item_width pixels.
---@param item_width number
local function imgui_set_next_item_width(item_width)
    imgui.set_next_item_width(item_width)
end

--- Calculates and returns the current item width.
---@return number
local function imgui_calc_item_width()
    return imgui.calc_item_width()
end

--- Pushes a new style color onto the style stack.
---@param style_color ImGuiCol|number
---@param color number|Vector4f
local function imgui_push_style_color(style_color, color)
    imgui.push_style_color(style_color, color)
end

--- Pops count style colors off the style stack.
---@param count number
local function imgui_pop_style_color(count)
    imgui.pop_style_color(count)
end

--- Pushes a new style variable onto the style stack.
---@param idx number
---@param value ImGuiStyleVar|number|Vector2f
local function imgui_push_style_var(idx, value)
    imgui.push_style_var(idx, value)
end

--- Pops count style variables off the style stack.
---@param count number
local function imgui_pop_style_var(count)
    imgui.pop_style_var(count)
end

--- Returns the current cursor position as a Vector2f.
---@return Vector2f
local function imgui_get_cursor_pos()
    return imgui.get_cursor_pos()
end

--- Sets the current cursor position to pos.
---@param pos Vector2f
local function imgui_set_cursor_pos(pos)
    imgui.set_cursor_pos(pos)
end

--- Returns the initial cursor position as a Vector2f.
---@return Vector2f
local function imgui_get_cursor_start_pos()
    return imgui.get_cursor_start_pos()
end

--- Returns the current cursor position in screen coordinates as a Vector2f.
---@return Vector2f
local function imgui_get_cursor_screen_pos()
    return imgui.get_cursor_screen_pos()
end

--- Sets the current cursor position in screen coordinates to pos.
---@param pos Vector2f
local function imgui_set_cursor_screen_pos(pos)
    imgui.set_cursor_screen_pos(pos)
end

--- Sets the default focus to the next widget.
--- Scroll APIs
local function imgui_set_item_default_focus()
    imgui.set_item_default_focus()
end

--- Returns the horizontal scroll position.
---@return number
local function imgui_get_scroll_x()
    return imgui.get_scroll_x()
end

--- Returns the vertical scroll position.
---@return number
local function imgui_get_scroll_y()
    return imgui.get_scroll_y()
end

--- Sets the horizontal scroll position to scroll_x.
---@param scroll_x number
local function imgui_set_scroll_x(scroll_x)
    imgui.set_scroll_x(scroll_x)
end

--- Sets the vertical scroll position to scroll_y.
---@param scroll_y number
local function imgui_set_scroll_y(scroll_y)
    imgui.set_scroll_y(scroll_y)
end

--- Returns the maximum horizontal scroll position.
---@return number
local function imgui_get_scroll_max_x()
    return imgui.get_scroll_max_x()
end

--- Returns the maximum vertical scroll position.
---@return number
local function imgui_get_scroll_max_y()
    return imgui.get_scroll_max_y()
end

--- Centers the horizontal scroll position.
---@param center_x_ratio number
local function imgui_set_scroll_here_x(center_x_ratio)
    imgui.set_scroll_here_x(center_x_ratio)
end

--- Centers the vertical scroll position.
---@param center_y_ratio number
local function imgui_set_scroll_here_y(center_y_ratio)
    imgui.set_scroll_here_y(center_y_ratio)
end

--- Sets the horizontal scroll position from the specified local_x and center_x_ratio.
---@param local_x number
---@param center_x_ratio number
local function imgui_set_scroll_from_pos_x(local_x, center_x_ratio)
    imgui.set_scroll_from_pos_x(local_x, center_x_ratio)
end

--- Sets the vertical scroll position from the specified local_y and center_y_ratio.
--- Table API
---@param local_y number
---@param center_y_ratio number
local function imgui_set_scroll_from_pos_y(local_y, center_y_ratio)
    imgui.set_scroll_from_pos_y(local_y, center_y_ratio)
end

--- Begins a new table with the specified str_id, column count, flags, outer_size, and inner_width.
--- str_id is a string.
--- column is an integer.
--- flags is an optional ImGuiTableFlags enum.
--- outer_size is a Vector2f or a size 2 array.
--- inner_width is an optional float.
---@param str_id string
---@param column number
---@param flags ImGuiTableFlags|number
---@param outer_size Vector2f|table (size 2 array)
---@param inner_width number
---@return boolean
local function imgui_begin_table(str_id, column, flags, outer_size, inner_width)
    return imgui.begin_table(str_id, column, flags, outer_size, inner_width)
end

--- Ends the current table.
local function imgui_end_table()
    imgui.end_table()
end

--- Begins a new row in the current table with the specified row_flags and min_row_height.
--- row_flags is an optional ImGuiTableRowFlags enum.
--- min_row_height is an optional float.
---@param row_flags ImGuiTableRowFlags|number
---@param min_row_height number
local function imgui_table_next_row(row_flags, min_row_height)
    imgui.table_next_row(row_flags, min_row_height)
end

--- Advances to the next column in the current table.
---@return boolean
local function imgui_table_next_column()
    return imgui.table_next_column()
end

--- Sets the current column index to column_index.
---@param column_index number
---@return boolean
local function imgui_table_set_column_index(column_index)
    return imgui.table_set_column_index(column_index)
end

--- Sets up a column in the current table with the specified label, flags, init_width_or_weight, and user_id.
---comment
---@param label string
---@param flags ImGuiTableColumnFlags|number
---@param init_width_or_weight number
---@param user_id number (ImGuiID)
local function imgui_table_setup_column(label, flags, init_width_or_weight, user_id)
    imgui.table_setup_column(label, flags, init_width_or_weight, user_id)
end

--- Sets up a scrolling region in the current table with cols columns and rows rows frozen.
---@param cols number
---@param rows number
local function imgui_table_setup_scroll_freeze(cols, rows)
    imgui.table_setup_scroll_freeze(cols, rows)
end

--- Submits a header row in the current table.
local function imgui_table_headers_row()
    imgui.table_headers_row()
end

--- Submits a header cell with the specified label in the current table.
---@param label string
local function imgui_table_header(label)
    imgui.table_header(label)
end

--- Returns the sort specifications for the current table.
---@return table|ImGuiTableSortSpecs
local function imgui_table_get_sort_specs()
    return imgui.table_get_sort_specs()
end

--- Returns the number of columns in the current table.
---@return number
local function imgui_table_get_column_count()
    return imgui.table_get_column_count()
end

--- Returns the current column index.
---@return number
local function imgui_table_get_column_index()
    return imgui.table_get_column_index()
end

--- Returns the current row index.
---@return number
local function imgui_table_get_row_index()
    return imgui.table_get_row_index()
end

--- Returns the name of the specified column in the current table.
---@param column number
---@return string
local function imgui_table_get_column_name(column)
    return imgui.table_get_column_name(column)
end

--- Returns the flags of the specified column in the current table.
---@param column number
---@return ImGuiTableColumnFlags|number
local function imgui_table_get_column_flags(column)
    return imgui.table_get_column_flags(column)
end

--- Sets the background color of the specified target in the current table with the given color and column index.
---@param target ImGuiTableBgTarget|number
---@param color number
---@param column number
local function imgui_table_set_bg_color(target, color, column)
    imgui.table_set_bg_color(target, color, column)
end

return {
    begin_window = imgui_begin_window,
    end_window = imgui_end_window,
    begin_child_window = imgui_begin_child_window,
    end_child_window = imgui_end_child_window,
    begin_group = imgui_begin_group,
    end_group = imgui_end_group,
    begin_rect = imgui_begin_rect,
    end_rect = imgui_end_rect,
    begin_disabled = imgui_begin_disabled,
    end_disabled = imgui_end_disabled,
    button = imgui_button,
    small_button = imgui_small_button,
    invisible_button = imgui_invisible_button,
    arrow_button = imgui_arrow_button,
    text = imgui_text,
    text_colored = imgui_text_colored,
    checkbox = imgui_checkbox,
    drag_float = imgui_drag_float,
    drag_float2 = imgui_drag_float2,
    drag_float3 = imgui_drag_float3,
    drag_float4 = imgui_drag_float4,
    drag_int = imgui_drag_int,
    slider_float = imgui_slider_float,
    slider_int = imgui_slider_int,
    input_text = imgui_input_text,
    input_text_multiline = imgui_input_text_multiline,
    combo = imgui_combo,
    color_picker = imgui_color_picker,
    color_picker_argb = imgui_color_picker_argb,
    color_picker3 = imgui_color_picker3,
    color_picker4 = imgui_color_picker4,
    color_edit = imgui_color_edit,
    color_edit_argb = imgui_color_edit_argb,
    color_edit3 = imgui_color_edit3,
    color_edit4 = imgui_color_edit4,
    tree_node = imgui_tree_node,
    tree_node_ptr_id = imgui_tree_node_ptr_id,
    tree_node_str_id = imgui_tree_node_str_id,
    tree_pop = imgui_tree_pop,
    same_line = imgui_same_line,
    spacing = imgui_spacing,
    new_line = imgui_new_line,
    is_item_hovered = imgui_is_item_hovered,
    is_item_active = imgui_is_item_active,
    is_item_focused = imgui_is_item_focused,
    collapsing_header = imgui_collapsing_header,
    load_font = imgui_load_font,
    push_font = imgui_push_font,
    pop_font = imgui_pop_font,
    get_default_font_size = imgui_get_default_font_size,
    set_next_window_pos = imgui_set_next_window_pos,
    set_next_window_size = imgui_set_next_window_size,
    push_id = imgui_push_id,
    pop_id = imgui_pop_id,
    get_id = imgui_get_id,
    get_mouse = imgui_get_mouse,
    progress_bar = imgui_progress_bar,
    item_size = imgui_item_size,
    item_add = imgui_item_add,
    draw_list_path_clear = imgui_draw_list_path_clear,
    draw_list_path_line_to = imgui_draw_list_path_line_to,
    draw_list_path_stroke = imgui_draw_list_path_stroke,
    get_key_index = imgui_get_key_index,
    is_key_down = imgui_is_key_down,
    is_key_pressed = imgui_is_key_pressed,
    is_key_released = imgui_is_key_released,
    is_mouse_down = imgui_is_mouse_down,
    is_mouse_clicked = imgui_is_mouse_clicked,
    is_mouse_released = imgui_is_mouse_released,
    is_mouse_double_clicked = imgui_is_mouse_double_clicked,
    indent = imgui_indent,
    unindent = imgui_unindent,
    begin_tooltip = imgui_begin_tooltip,
    end_tooltip = imgui_end_tooltip,
    set_tooltip = imgui_set_tooltip,
    open_popup = imgui_open_popup,
    begin_popup = imgui_begin_popup,
    begin_popup_context_item = imgui_begin_popup_context_item,
    end_popup = imgui_end_popup,
    close_current_popup = imgui_close_current_popup,
    is_popup_open = imgui_is_popup_open,
    calc_text_size = imgui_calc_text_size,
    get_window_size = imgui_get_window_size,
    get_window_pos = imgui_get_window_pos,
    set_next_item_open = imgui_set_next_item_open,
    begin_list_box = imgui_begin_list_box,
    end_list_box = imgui_end_list_box,
    begin_menu_bar = imgui_begin_menu_bar,
    end_menu_bar = imgui_end_menu_bar,
    begin_main_menu_bar = imgui_begin_main_menu_bar,
    end_main_menu_bar = imgui_end_main_menu_bar,
    begin_menu = imgui_begin_menu,
    end_menu = imgui_end_menu,
    menu_item = imgui_menu_item,
    get_display_size = imgui_get_display_size,
    push_item_width = imgui_push_item_width,
    pop_item_width = imgui_pop_item_width,
    set_next_item_width = imgui_set_next_item_width,
    calc_item_width = imgui_calc_item_width,
    push_style_color = imgui_push_style_color,
    pop_style_color = imgui_pop_style_color,
    push_style_var = imgui_push_style_var,
    pop_style_var = imgui_pop_style_var,
    get_cursor_pos = imgui_get_cursor_pos,
    set_cursor_pos = imgui_set_cursor_pos,
    get_cursor_start_pos = imgui_get_cursor_start_pos,
    get_cursor_screen_pos = imgui_get_cursor_screen_pos,
    set_cursor_screen_pos = imgui_set_cursor_screen_pos,
    set_item_default_focus = imgui_set_item_default_focus,
    get_scroll_x = imgui_get_scroll_x,
    get_scroll_y = imgui_get_scroll_y,
    set_scroll_x = imgui_set_scroll_x,
    set_scroll_y = imgui_set_scroll_y,
    get_scroll_max_x = imgui_get_scroll_max_x,
    get_scroll_max_y = imgui_get_scroll_max_y,
    set_scroll_here_x = imgui_set_scroll_here_x,
    set_scroll_here_y = imgui_set_scroll_here_y,
    set_scroll_from_pos_x = imgui_set_scroll_from_pos_x,
    set_scroll_from_pos_y = imgui_set_scroll_from_pos_y,
    begin_table = imgui_begin_table,
    end_table = imgui_end_table,
    table_next_row = imgui_table_next_row,
    table_next_column = imgui_table_next_column,
    table_set_column_index = imgui_table_set_column_index,
    table_setup_column = imgui_table_setup_column,
    table_setup_scroll_freeze = imgui_table_setup_scroll_freeze,
    table_headers_row = imgui_table_headers_row,
    table_header = imgui_table_header,
    table_get_sort_specs = imgui_table_get_sort_specs,
    table_get_column_count = imgui_table_get_column_count,
    table_get_column_index = imgui_table_get_column_index,
    table_get_row_index = imgui_table_get_row_index,
    table_get_column_name = imgui_table_get_column_name,
    table_get_column_flags = imgui_table_get_column_flags,
    table_set_bg_color = imgui_table_set_bg_color,
}
