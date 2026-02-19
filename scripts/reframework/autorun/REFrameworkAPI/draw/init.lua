local draw = draw

--- Returns an optional Vector2f corresponding to the 2D screen position. Returns nil if world_pos is not visible.
--- @param world_pos Vector2f
--- @return Vector2f|nil
local function draw_world_to_screen(world_pos)
    return draw.world_to_screen(world_pos)
end

---@param text string
---@param pos_3d Vector3f
---@param color number
local function draw_world_text(text, pos_3d, color)
    draw.world_text(text, pos_3d, color)
end

---@param text string
---@param x number
---@param y number
---@param color integer
local function draw_text(text, x, y, color)
    draw.text(text, x, y, color)
end

---@param x number
---@param y number
---@param w number
---@param h number
---@param color integer
local function draw_filled_rect(x, y, w, h, color)
    draw.filled_rect(x, y, w, h, color)
end

---comment
---@param x number
---@param y number
---@param w number
---@param h number
---@param color integer
local function draw_outline_rect(x, y, w, h, color)
    draw.outline_rect(x, y, w, h, color)
end

---@param x1 number
---@param y1 number
---@param x2 number
---@param y2 number
---@param color integer
local function draw_line(x1, y1, x2, y2, color)
    draw.line(x1, y1, x2, y2, color)
end

---@param x number
---@param y number
---@param radius number
---@param color integer
---@param num_segments integer
local function draw_outline_circle(x, y, radius, color, num_segments)
    draw.outline_circle(x, y, radius, color, num_segments)
end

---@param x number
---@param y number
---@param radius number
---@param color integer
---@param num_segments integer
local function draw_filled_circle(x, y, radius, color, num_segments)
    draw.filled_circle(x, y, radius, color, num_segments)
end

---@param x1 number
---@param y1 number
---@param x2 number
---@param y2 number
---@param x3 number
---@param y3 number
---@param x4 number
---@param y4 number
---@param color integer
local function draw_outline_quad(x1, y1, x2, y2, x3, y3, x4, y4, color)
    draw.outline_quad(x1, y1, x2, y2, x3, y3, x4, y4, color)
end

---@param x1 number
---@param y1 number
---@param x2 number
---@param y2 number
---@param x3 number
---@param y3 number
---@param x4 number
---@param y4 number
---@param color integer
local function draw_filled_quad(x1, y1, x2, y2, x3, y3, x4, y4, color)
    draw.filled_quad(x1, y1, x2, y2, x3, y3, x4, y4, color)
end

--- Draws a 3D sphere with a 2D approximation in world space.
---@param world_pos Vector2f|Vector3f|Vector4f
---@param radius number
---@param color integer
---@param outline boolean
local function draw_sphere(world_pos, radius, color, outline)
    draw.sphere(world_pos, radius, color, outline)
end

--- Draws a 3D capsule with a 2D approximation in world space.
---@param world_start_pos Vector2f|Vector3f|Vector4f
---@param world_end_pos Vector2f|Vector3f|Vector4f
---@param radius number
---@param color integer
---@param outline boolean
local function draw_capsule(world_start_pos, world_end_pos, radius, color, outline)
    draw.capsule(world_start_pos, world_end_pos, radius, color, outline)
end

--- unique_id, an int64 that must be unique for every gizmo. Usually an address of an object will work. The same ID will control multiple gizmos with the same ID.
--- matrix, the Matrix4x4f the gizmo is modifying.
--- operation, defaults to UNIVERSAL. Use imgui.ImGuizmoOperation enum.
--- mode, defaults to WORLD. WORLD or LOCAL. Use imgui.ImGuizmoMode enum.
--- Returns a tuple of changed, mat. Mat is the modified matrix that was passed.
---     imgui.new_enum(&quot;ImGuizmoOperation&quot;, 
---                     &quot;TRANSLATE&quot;, ImGuizmo::OPERATION::TRANSLATE, 
---                     &quot;ROTATE&quot;, ImGuizmo::OPERATION::ROTATE,
---                     &quot;SCALE&quot;, ImGuizmo::OPERATION::SCALE,
---                     &quot;SCALEU&quot;, ImGuizmo::OPERATION::SCALEU,
---                     &quot;UNIVERSAL&quot;, ImGuizmo::OPERATION::UNIVERSAL);
---     imgui.new_enum(&quot;ImGuizmoMode&quot;, 
---                     &quot;WORLD&quot;, ImGuizmo::MODE::WORLD,
---                     &quot;LOCAL&quot;, ImGuizmo::MODE::LOCAL);
---@param unique_id integer
---@param matrix Matrix4x4f
---@param operation ImGuizmoOperation|integer
---@param mode ImGuizmoMode|integer
---@return any
local function draw_gizmo(unique_id, matrix, operation, mode)
    return draw.gizmo(unique_id, matrix, operation, mode)
end

---@param matrix Matrix4x4f
local function draw_cube(matrix)
    draw.cube(matrix)
end

---@param matrix Matrix4x4f
---@param size number
local function draw_grid(matrix, size)
    draw.grid(matrix, size)
end

return {
    world_to_screen = draw_world_to_screen,
    world_text = draw_world_text,
    text = draw_text,
    filled_rect = draw_filled_rect,
    outline_rect = draw_outline_rect,
    line = draw_line,
    outline_circle = draw_outline_circle,
    filled_circle = draw_filled_circle,
    outline_quad = draw_outline_quad,
    filled_quad = draw_filled_quad,
    sphere = draw_sphere,
    capsule = draw_capsule,
    gizmo = draw_gizmo,
    cube = draw_cube,
    grid = draw_grid,
}
