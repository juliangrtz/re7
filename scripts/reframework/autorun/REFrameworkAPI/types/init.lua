local RealVector2f = Vector2f
local RealVector3f = Vector3f
local RealVector4f = Vector4f
local RealMatrix4x4f = Matrix4x4f
local RealQuaternion = Quaternion
local RealValueType = ValueType

---@class Vector2f
Vector2f = { x = 0.0, y = 0.0 }
Vector2f = RealVector2f

---Creates a new Vector2f
---@param x number
---@param y number
---@return Vector2f
function Vector2f:new(x, y)
    return RealVector2f.new(x, y)
end

---Returns the dot product between self and other.
---@param other Vector2f
---@return number
function Vector2f:dot(other) end

---Returns the cross product between self and other.
---@param other Vector2f
---@return number
function Vector2f:cross(other) end

---Returns the length of self.
---@return number
function Vector2f:length() end

---Normalizes self. Nothing is returned.
function Vector2f:normalize() end

---Returns the normalization of self.
---@return Vector2f
function Vector2f:normalized() end

---Converts self to a Vector3f. Not available if self is already a Vector3f.
---@return Vector3f
function Vector2f:to_vec3() end

---Converts self to a Vector4f. Not available if self is already a Vector4f.
---@return Vector4f
function Vector2f:to_vec4() end

---Returns the refraction of self over normal with the given eta.
---@param normal Vector2f
---@param eta number
---@return Vector2f
function Vector2f:refract(normal, eta) end

---Returns the refraction of self over normal with the given eta.
---@param other Vector2f
---@param t number
---@return Vector2f
function Vector2f:lerp(other, t) end

---Converts self to a Matrix4x4f. Treats self as the forward vector.
---@return Matrix4x4f
function Vector2f:to_mat() end

---Converts self to a Quaternion. Treats self as the forward vector.
---Equivalent to self:to_mat():to_quat().
---@return Quaternion
function Vector2f:to_quat() end

-- END Vector2f

---@class Vector3f
Vector3f = { x = 0.0, y = 0.0, z = 0.0 }
Vector3f = RealVector3f

---Creates a new Vector3f
---@param x number
---@param y number
---@param z number
---@return Vector3f
function Vector3f:new(x, y, z)
    return RealVector3f.new(x, y, z)
end

---Returns the dot product between self and other.
---@param other Vector3f
---@return number
function Vector3f:dot(other) end

---Returns the cross product between self and other.
---@param other Vector3f
---@return number
function Vector3f:cross(other) end

---Returns the length of self.
---@return number
function Vector3f:length() end

---Normalizes self. Nothing is returned.
function Vector3f:normalize() end

---Returns the normalization of self.
---@return Vector3f
function Vector3f:normalized() end

---Converts self to a Vector2f. Not available if self is already a Vector2f.
---@return Vector2f
function Vector3f:to_vec2() end

---Converts self to a Vector4f. Not available if self is already a Vector4f.
---@return Vector4f
function Vector3f:to_vec4() end

---Returns the refraction of self over normal with the given eta.
---@param normal Vector3f
---@param eta number
---@return Vector3f
function Vector3f:refract(normal, eta) end

---Returns the refraction of self over normal with the given eta.
---@param other Vector3f
---@param t number
---@return Vector3f
function Vector3f:lerp(other, t) end

---Converts self to a Matrix4x4f. Treats self as the forward vector.
---@return Matrix4x4f
function Vector3f:to_mat() end

---Converts self to a Quaternion. Treats self as the forward vector.
---Equivalent to self:to_mat():to_quat().
---@return Quaternion
function Vector3f:to_quat() end

-- END Vector3f

---@class Vector4f
Vector4f = { x = 0.0, y = 0.0, z = 0.0, w = 0.0 }
Vector4f = RealVector4f

---Creates a new Vector4f
---@param x number
---@param y number
---@param z number
---@param w number
---@return Vector4f
function Vector4f:new(x, y, z, w)
    return RealVector4f.new(x, y, z, w)
end

---Returns the dot product between self and other.
---@param other Vector4f
---@return number
function Vector4f:dot(other) end

---Returns the cross product between self and other.
---@param other Vector4f
---@return number
function Vector4f:cross(other) end

---Returns the length of self.
---@return number
function Vector4f:length() end

---Normalizes self. Nothing is returned.
function Vector4f:normalize() end

---Returns the normalization of self.
---@return Vector4f
function Vector4f:normalized() end

---Converts self to a Vector2f. Not available if self is already a Vector2f.
---@return Vector2f
function Vector4f:to_vec2() end

---Converts self to a Vector3f. Not available if self is already a Vector3f.
---@return Vector3f
function Vector4f:to_vec3() end

---Returns the refraction of self over normal with the given eta.
---@param normal Vector4f
---@param eta number
---@return Vector4f
function Vector4f:refract(normal, eta) end

---Returns the refraction of self over normal with the given eta.
---@param other Vector4f
---@param t number
---@return Vector4f
function Vector4f:lerp(other, t) end

---Converts self to a Matrix4x4f. Treats self as the forward vector.
---@return Matrix4x4f
function Vector4f:to_mat() end

---Converts self to a Quaternion. Treats self as the forward vector.
---Equivalent to self:to_mat():to_quat().
---@return Quaternion
function Vector4f:to_quat() end

-- END Vector4f

---@class Matrix4x4f
Matrix4x4f = { x1 = 0.0, y1= 0.0, z1= 0.0, w1= 0.0, x2= 0.0, y2= 0.0, z2= 0.0, w2= 0.0, x3= 0.0, y3= 0.0, z3= 0.0, w3= 0.0, x4= 0.0, y4= 0.0, z4= 0.0, w4= 0.0 }
Matrix4x4f = RealMatrix4x4f

---Creates a new Matrix4x4f
---@return Matrix4x4f
function Matrix4x4f:new()
    return RealMatrix4x4f.new()
end

---Creates a new Matrix4x4f
---@param x1 number
---@param y1 number
---@param z1 number
---@param w1 number
---@param x2 number
---@param y2 number
---@param z2 number
---@param w2 number
---@param x3 number
---@param y3 number
---@param z3 number
---@param w3 number
---@param x4 number
---@param y4 number
---@param z4 number
---@param w4 number
---@return Matrix4x4f
function Matrix4x4f:new(x1, y1, z1, w1, x2, y2, z2, w2, x3, y3, z3, w3, x4, y4, z4, w4)
    return RealMatrix4x4f.new(x1, y1, z1, w1, x2, y2, z2, w2, x3, y3, z3, w3, x4, y4, z4, w4)
end

---Returns the identity matrix.
---@return Matrix4x4f
function Matrix4x4f:identity()
    return RealMatrix4x4f.identity()
end

---Returns a Quaternion built from self.
---@return Quaternion
function Matrix4x4f:to_quat() end

---Returns a Matrix4x4f that is the inverse of self.
---@return Matrix4x4f
function Matrix4x4f:inverse() end

---Inverts self. Returns nothing.
function Matrix4x4f:invert() end

---Returns the linear interpolation between self and other with the given t.
---@param other Matrix4x4f
---@param t number
---@return Matrix4x4f
function Matrix4x4f:interpolate(other, t) end

---Extracts the rotation matrix from self.
---@return Matrix4x4f
function Matrix4x4f:matrix_rotation() end

-- END Matrix4x4f

---@class Quaternion
Quaternion = { x = 0.0, y = 0.0, z = 0.0, w = 0.0 }
Quaternion = RealQuaternion

---Creates a new Quaternion
---@param x number
---@param y number
---@param z number
---@param w number
---@return Quaternion
function Quaternion:new(x, y, z, w)
    return RealQuaternion.new(x, y, z, w)
end

---Returns the identity quaternion.
---@return Quaternion
function Quaternion:identity()
    return RealQuaternion.identity()
end

---Returns a Matrix4x4f built from self.
---@return Matrix4x4f
function Quaternion:to_mat4() end

---Returns a Vector3f representing the Euler angles for this Quaternion.
---@return Vector3f
function Quaternion:to_euler() end

---Returns a Quaternion that is the inverse of self.
---@return Quaternion
function Quaternion:inverse() end

---Inverts self. Returns nothing.
function Quaternion:invert() end

---Normalizes self. Returns nothing.
function Quaternion:normalize() end

---Returns a Quaternion that is the normalization of self.
---@return Quaternion
function Quaternion:normalized() end

---Returns a Quaternion that is the spherical linear interpolation between self and other with the given t.
---@param other Quaternion
---@param t number
---@return Quaternion
function Quaternion:slerp(other, t) end

---Returns the dot product between self and other.
---@param other Quaternion
---@return number
function Quaternion:dot(other) end

---Returns the length of self.
---@return number
function Quaternion:length() end

---Returns a Quaternion that is the conjugate of self.
---@return Quaternion
function Quaternion:conjugate() end

-- END Quaternion

---@class System
System = {}

---@class System.String
System.String = { Length = 0 }

---@class System.Array
System.Array = { Length = 0 }

---@class SystemArray
SystemArray = { }

---Returns the array's elements as a lua table.
---Keep in mind these objects will all be full REManagedObject types, not the ValueTypes they represent, if any, like System.Int32
---@return any
function SystemArray:get_elements() end

---Returns the object at index in the array.
---@return any
function SystemArray:get_element(index) end

---Returns the size of the array.
---@return number
function SystemArray:get_size() end

---@class System.SByte
System.SByte = {}

---@class System.Byte
System.Byte = {}

---@class System.Int16
System.Int16 = {}

---@class System.UInt16
System.UInt16 = {}

---@class System.Int32
System.Int32 = {}

---@class System.UInt32
System.UInt32 = {}

---@class System.Int64
System.Int64 = {}

---@class System.UInt64
System.UInt64 = {}

---@class System.Single
System.Single = {}

---@class System.Double
System.Double = {}

---@class System.Type
System.Type = {}

-- END DotNet Types

---@class REFeild
REFeild = {}

---@return string
function REFeild:getName() end

-- END REFeild

---@class RETypeDefinition
RETypeDefinition = {}

---Returns the full name of the class.
---Equivalent to concatenating self:get_namespace() and self:get_name().
---@return string
function RETypeDefinition:get_full_name() end

---Returns the type name. Does not contain namespace.
---@return string
function RETypeDefinition:get_name() end

---Returns the namespace this type is contained in.
---@return string
function RETypeDefinition:get_namespace() end

---Returns an REMethodDefinition. To be used in things like sdk.hook.
---The full function prototype can be supplied to get an overloaded function.
---Example: foo:get_method("Bar(System.Int32, System.Single)")
---@param name string
---@return REMethodDefinition
function RETypeDefinition:get_method(name) end

---Returns a list of REMethodDefinition
---Filters out methods that are potentially just stubs or null.
---@return any
function RETypeDefinition:get_methods() end

---Returns an REField.
---@param name string
---@return REFeild
function RETypeDefinition:get_field(name) end

---Returns a list of REField
---@return any
function RETypeDefinition:get_fields() end

-- END RETypeDefinition

---@class REMethodDefinition
REMethodDefinition = {}

---@return string
function REMethodDefinition:get_name() end

---Returns an RETypeDefinition*.
---@return RETypeDefinition
function REMethodDefinition:get_return_type() end

---Returns a void*. Pointer to the actual function in memory.
---@return function
function REMethodDefinition:get_function() end

---Returns an RETypeDefinition* corresponding to the class/type that declared this method.
---@return RETypeDefinition
function REMethodDefinition:get_declaring_type() end

---Returns the number of parameters required to call the function.
---@return number
function REMethodDefinition:get_num_params() end

---Returns a list of RETypeDefinition
---@return any
function REMethodDefinition:get_param_types() end

---Returns a list of strings for the parameter names
---@return any
function REMethodDefinition:get_param_names() end

---Returns whether this method is static or not.
---@return boolean
function REMethodDefinition:is_static() end

---Equivalent to calling obj:call(args...)
---Can also use self(obj, args...)
---@param obj any
---@param ... any
---@return any
function REMethodDefinition:call(obj, ...) end

-- END REMethodDefinition

---@class REManagedObject
REManagedObject = {}

---Return value is dependent on the method's return type. Wrapper over sdk.call_object_func.
---
---Full function prototype can be passed as method_name if there are multiple functions with the same name but different parameters.
---
---e.g. self:call("foo(System.String, System.Single, System.UInt32, System.Object)", a, b, c, d)
---
---Valid method names can be found in the Object Explorer. Find the type you're looking for, and valid methods will be found under TDB Methods.
---@param method_name string
---@param ... any
---@return any
function REManagedObject:call(method_name, ...) end

---Returns an RETypeDefinition*.
---@return RETypeDefinition
function REManagedObject:get_type_definition() end

---Return type is dependent on the field type.
---@param name string
---@return any
function REManagedObject:get_field(name) end

---@param name string
---@param value any
function REManagedObject:set_field(name, value) end

---@return number
function REManagedObject:get_address() end

---@return number
function REManagedObject:get_reference_count() end

---Experimental API to deserialize data into self.
---
---data is RSZ data, in table format as an array of bytes.
---
---Will only work on native via types.
---@param data any
---@param objects any
---@return any
function REManagedObject:deserialize_native(data, objects) end

---Dangerous Method
---Increments the object's internal reference count.
function REManagedObject:add_ref() end

---Dangerous Method
---Increments the object's internal reference count without REFramework managing it. Any objects created with REFramework and also using this method will not be deleted after the Lua state is destroyed.
function REManagedObject:add_ref_permanent() end

---Dangerous Method
---Decrements the object's internal reference count. Destroys the object if it reaches 0. Can only be used on objects managed by Lua.
function REManagedObject:release() end

---Dangerous Method
---Decrements the object's internal reference count. Destroys the object if it reaches 0. Can be used on any REManagedObject. Can crash the game or cause undefined behavior.
---
---When a new Lua reference is created to an REManagedObject, REFramework automatically increments its reference count internally with self:add_ref(). This will keep the object alive until you are no longer referencing the object in Lua. self:release() is automatically called when Lua is no longer referencing the object anywhere.
---
---The only time you will need to manually call self:add_ref() and self:release() is when a newly created object is returned by the engine, e.g. an array, or something from sdk.create_instance().
---
---A more in-depth explanation can be found in the "FrameGC Algorithm" section of this GDC presentation by Capcom:
---
---https://github.com/kasicass/blog/blob/master/3d-reengine/2021_03_10_achieve_rapid_iteration_re_engine_design.md#framegc-algorithm-17
function REManagedObject:force_release() end

---Dangerous Method
---@param offset any
---@return number
function REManagedObject:read_byte(offset) end

---Dangerous Method
---@param offset any
---@return number
function REManagedObject:read_short(offset) end

---Dangerous Method
---@param offset any
---@return number
function REManagedObject:read_dword(offset) end

---Dangerous Method
---@param offset any
---@return number
function REManagedObject:read_qword(offset) end

---Dangerous Method
---@param offset any
---@return number
function REManagedObject:read_float(offset) end

---Dangerous Method
---@param offset any
---@return number
function REManagedObject:read_double(offset) end

---Dangerous Method
---@param offset number
---@param value number
function REManagedObject:write_byte(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function REManagedObject:write_short(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function REManagedObject:write_dword(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function REManagedObject:write_qword(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function REManagedObject:write_float(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function REManagedObject:write_double(offset, value) end

-- END REManagedObject

---@class REComponent
REComponent = {}
setmetatable(REComponent, {__index = REManagedObject})

---END REComponent

---@class RETransform
RETransform = { }
setmetatable(RETransform, {__index = REComponent})

---Returns a Matrix4x4f. Returns the reference pose (T-pose) for a specific joint relative to the transform's origin (in local transform space).
---@param joint any
---@return Matrix4x4f
function RETransform:calculate_base_transform(joint) end

---Sets the world position (Vector4f) of the transform.
---When no_dirty is true, the transform and its parents will not be marked as dirty. This seems to be necessary when the scene is locked, because parent transforms will end up getting stuck.
---@param position Vector4f
---@param no_dirty boolean
function RETransform:set_position(position, no_dirty) end

---Sets the world rotation (Quaternion) of the transform.
---@param rotation Quaternion
function RETransform:set_rotation(rotation) end

---Gets the world position (Vector4f) of the transform.
---@return Vector4f
function RETransform:get_position() end

---Gets the world rotation (Quaternion) of the transform.
---@return Quaternion
function RETransform:get_rotation() end

--- END RETransform

---@class ValueType
ValueType = { type = RETypeDefinition, data = {} }
ValueType = RealValueType

---Creates a new ValueType
---@param typename string
---@return ValueType
function ValueType:new(typename)
    return RealValueType.new(typename)
end

---Return value is dependent on the method's return type
---@param name string
---@param ... any
---@return any
function ValueType:call(name, ...) end

---@param name string
---@return string
function ValueType:get_field(name) end

---Note that this does not change anything in-game. ValueType is just a local copy.
---You'll need to pass the ValueType somewhere that would make use of the changed data.
---@param name string
---@param value any
function ValueType:set_field(name, value) end

---@return number
function ValueType:address() end

---@return RETypeDefinition
function ValueType:get_type_definition() end

---Dangerous Method
---@param offset any
---@return number
function ValueType:read_byte(offset) end

---Dangerous Method
---@param offset any
---@return number
function ValueType:read_short(offset) end

---Dangerous Method
---@param offset any
---@return number
function ValueType:read_dword(offset) end

---Dangerous Method
---@param offset any
---@return number
function ValueType:read_qword(offset) end

---Dangerous Method
---@param offset any
---@return number
function ValueType:read_float(offset) end

---Dangerous Method
---@param offset any
---@return number
function ValueType:read_double(offset) end

---Dangerous Method
---@param offset number
---@param value number
function ValueType:write_byte(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function ValueType:write_short(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function ValueType:write_dword(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function ValueType:write_qword(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function ValueType:write_float(offset, value) end

---Dangerous Method
---@param offset number
---@param value number
function ValueType:write_double(offset, value) end

-- END ValueType

---@class ImGuiWindowFlags
ImGuiWindowFlags =
{
    ImGuiWindowFlags_None                   = 0,
    ImGuiWindowFlags_NoTitleBar             = 1 << 0,   -- Disable title-bar
    ImGuiWindowFlags_NoResize               = 1 << 1,   -- Disable user resizing with the lower-right grip
    ImGuiWindowFlags_NoMove                 = 1 << 2,   -- Disable user moving the window
    ImGuiWindowFlags_NoScrollbar            = 1 << 3,   -- Disable scrollbars (window can still scroll with mouse or programmatically)
    ImGuiWindowFlags_NoScrollWithMouse      = 1 << 4,   -- Disable user vertically scrolling with mouse wheel. On child window, mouse wheel will be forwarded to the parent unless NoScrollbar is also set.
    ImGuiWindowFlags_NoCollapse             = 1 << 5,   -- Disable user collapsing window by double-clicking on it. Also referred to as Window Menu Button (e.g. within a docking node).
    ImGuiWindowFlags_AlwaysAutoResize       = 1 << 6,   -- Resize every window to its content every frame
    ImGuiWindowFlags_NoBackground           = 1 << 7,   -- Disable drawing background color (WindowBg, etc.) and outside border. Similar as using SetNextWindowBgAlpha(0.0f).
    ImGuiWindowFlags_NoSavedSettings        = 1 << 8,   -- Never load/save settings in .ini file
    ImGuiWindowFlags_NoMouseInputs          = 1 << 9,   -- Disable catching mouse, hovering test with pass through.
    ImGuiWindowFlags_MenuBar                = 1 << 10,  -- Has a menu-bar
    ImGuiWindowFlags_HorizontalScrollbar    = 1 << 11,  -- Allow horizontal scrollbar to appear (off by default). You may use SetNextWindowContentSize(ImVec2(width,0.0f)); prior to calling Begin() to specify width. Read code in imgui_demo in the "Horizontal Scrolling" section.
    ImGuiWindowFlags_NoFocusOnAppearing     = 1 << 12,  -- Disable taking focus when transitioning from hidden to visible state
    ImGuiWindowFlags_NoBringToFrontOnFocus  = 1 << 13,  -- Disable bringing window to front when taking focus (e.g. clicking on it or programmatically giving it focus)
    ImGuiWindowFlags_AlwaysVerticalScrollbar= 1 << 14,  -- Always show vertical scrollbar (even if ContentSize.y < Size.y)
    ImGuiWindowFlags_AlwaysHorizontalScrollbar=1<< 15,  -- Always show horizontal scrollbar (even if ContentSize.x < Size.x)
    ImGuiWindowFlags_AlwaysUseWindowPadding = 1 << 16,  -- Ensure child windows without border uses style.WindowPadding (ignored by default for non-bordered child windows, because more convenient)
    ImGuiWindowFlags_NoNavInputs            = 1 << 18,  -- No gamepad/keyboard navigation within the window
    ImGuiWindowFlags_NoNavFocus             = 1 << 19,  -- No focusing toward this window with gamepad/keyboard navigation (e.g. skipped by CTRL+TAB)
    ImGuiWindowFlags_UnsavedDocument        = 1 << 20,  -- Display a dot next to the title. When used in a tab/docking context, tab is selected when clicking the X + closure is not assumed (will wait for user to stop submitting the tab). Otherwise closure is assumed when pressing the X, so if you keep submitting the tab may reappear at end of tab bar.
    ImGuiWindowFlags_NoNav                  = 1 << 18 | 1 << 19,
    ImGuiWindowFlags_NoDecoration           = 1 << 0 | 1 << 1 | 1 << 3 | 1 << 5,
    ImGuiWindowFlags_NoInputs               = 1 << 9 | 1 << 18 | 1 << 19,

    -- [Internal]
    ImGuiWindowFlags_NavFlattened           = 1 << 23,  -- [BETA] On child window: allow gamepad/keyboard navigation to cross over parent border to this child or between sibling child windows.
    ImGuiWindowFlags_ChildWindow            = 1 << 24,  -- Don't use! For internal use by BeginChild()
    ImGuiWindowFlags_Tooltip                = 1 << 25,  -- Don't use! For internal use by BeginTooltip()
    ImGuiWindowFlags_Popup                  = 1 << 26,  -- Don't use! For internal use by BeginPopup()
    ImGuiWindowFlags_Modal                  = 1 << 27,  -- Don't use! For internal use by BeginPopupModal()
    ImGuiWindowFlags_ChildMenu              = 1 << 28,  -- Don't use! For internal use by BeginMenu()
}

---@class ImGuiInputTextFlags
ImGuiInputTextFlags =
{
    ImGuiInputTextFlags_None                = 0,
    ImGuiInputTextFlags_CharsDecimal        = 1 << 0,   -- Allow 0123456789.+-*/
    ImGuiInputTextFlags_CharsHexadecimal    = 1 << 1,   -- Allow 0123456789ABCDEFabcdef
    ImGuiInputTextFlags_CharsUppercase      = 1 << 2,   -- Turn a..z into A..Z
    ImGuiInputTextFlags_CharsNoBlank        = 1 << 3,   -- Filter out spaces, tabs
    ImGuiInputTextFlags_AutoSelectAll       = 1 << 4,   -- Select entire text when first taking mouse focus
    ImGuiInputTextFlags_EnterReturnsTrue    = 1 << 5,   -- Return 'true' when Enter is pressed (as opposed to every time the value was modified). Consider looking at the IsItemDeactivatedAfterEdit() function.
    ImGuiInputTextFlags_CallbackCompletion  = 1 << 6,   -- Callback on pressing TAB (for completion handling)
    ImGuiInputTextFlags_CallbackHistory     = 1 << 7,   -- Callback on pressing Up/Down arrows (for history handling)
    ImGuiInputTextFlags_CallbackAlways      = 1 << 8,   -- Callback on each iteration. User code may query cursor position, modify text buffer.
    ImGuiInputTextFlags_CallbackCharFilter  = 1 << 9,   -- Callback on character inputs to replace or discard them. Modify 'EventChar' to replace or discard, or return 1 in callback to discard.
    ImGuiInputTextFlags_AllowTabInput       = 1 << 10,  -- Pressing TAB input a '\t' character into the text field
    ImGuiInputTextFlags_CtrlEnterForNewLine = 1 << 11,  -- In multi-line mode, unfocus with Enter, add new line with Ctrl+Enter (default is opposite: unfocus with Ctrl+Enter, add line with Enter).
    ImGuiInputTextFlags_NoHorizontalScroll  = 1 << 12,  -- Disable following the cursor horizontally
    ImGuiInputTextFlags_AlwaysOverwrite     = 1 << 13,  -- Overwrite mode
    ImGuiInputTextFlags_ReadOnly            = 1 << 14,  -- Read-only mode
    ImGuiInputTextFlags_Password            = 1 << 15,  -- Password mode, display all characters as '*'
    ImGuiInputTextFlags_NoUndoRedo          = 1 << 16,  -- Disable undo/redo. Note that input text owns the text data while active, if you want to provide your own undo/redo stack you need e.g. to call ClearActiveID().
    ImGuiInputTextFlags_CharsScientific     = 1 << 17,  -- Allow 0123456789.+-*/eE (Scientific notation input)
    ImGuiInputTextFlags_CallbackResize      = 1 << 18,  -- Callback on buffer capacity changes request (beyond 'buf_size' parameter value), allowing the string to grow. Notify when the string wants to be resized (for string types which hold a cache of their Size). You will be provided a new BufSize in the callback and NEED to honor it. (see misc/cpp/imgui_stdlib.h for an example of using this)
    ImGuiInputTextFlags_CallbackEdit        = 1 << 19,  -- Callback on any edit (note that InputText() already returns true on edit, the callback is useful mainly to manipulate the underlying buffer while focus is active)
    ImGuiInputTextFlags_EscapeClearsAll     = 1 << 20,  -- Escape key clears content if not empty, and deactivate otherwise (contrast to default behavior of Escape to revert)
}

---@class ImGuiTreeNodeFlags
ImGuiTreeNodeFlags =
{
    ImGuiTreeNodeFlags_None                 = 0,
    ImGuiTreeNodeFlags_Selected             = 1 << 0,   -- Draw as selected
    ImGuiTreeNodeFlags_Framed               = 1 << 1,   -- Draw frame with background (e.g. for CollapsingHeader)
    ImGuiTreeNodeFlags_AllowItemOverlap     = 1 << 2,   -- Hit testing to allow subsequent widgets to overlap this one
    ImGuiTreeNodeFlags_NoTreePushOnOpen     = 1 << 3,   -- Don't do a TreePush() when open (e.g. for CollapsingHeader) = no extra indent nor pushing on ID stack
    ImGuiTreeNodeFlags_NoAutoOpenOnLog      = 1 << 4,   -- Don't automatically and temporarily open node when Logging is active (by default logging will automatically open tree nodes)
    ImGuiTreeNodeFlags_DefaultOpen          = 1 << 5,   -- Default node to be open
    ImGuiTreeNodeFlags_OpenOnDoubleClick    = 1 << 6,   -- Need double-click to open node
    ImGuiTreeNodeFlags_OpenOnArrow          = 1 << 7,   -- Only open when clicking on the arrow part. If ImGuiTreeNodeFlags_OpenOnDoubleClick is also set, single-click arrow or double-click all box to open.
    ImGuiTreeNodeFlags_Leaf                 = 1 << 8,   -- No collapsing, no arrow (use as a convenience for leaf nodes).
    ImGuiTreeNodeFlags_Bullet               = 1 << 9,   -- Display a bullet instead of arrow
    ImGuiTreeNodeFlags_FramePadding         = 1 << 10,  -- Use FramePadding (even for an unframed text node) to vertically align text baseline to regular widget height. Equivalent to calling AlignTextToFramePadding().
    ImGuiTreeNodeFlags_SpanAvailWidth       = 1 << 11,  -- Extend hit box to the right-most edge, even if not framed. This is not the default in order to allow adding other items on the same line. In the future we may refactor the hit system to be front-to-back, allowing natural overlaps and then this can become the default.
    ImGuiTreeNodeFlags_SpanFullWidth        = 1 << 12,  -- Extend hit box to the left-most and right-most edges (bypass the indented area).
    ImGuiTreeNodeFlags_NavLeftJumpsBackHere = 1 << 13,  -- (WIP) Nav: left direction may move to this TreeNode() from any of its child (items submitted between TreeNode and TreePop)
    ImGuiTreeNodeFlags_CollapsingHeader     = 1 << 1 | 1 << 3 | 1 << 4,
}

---@class ImGuiColorEditFlags
ImGuiColorEditFlags =
{
    ImGuiColorEditFlags_None            = 0,
    ImGuiColorEditFlags_NoAlpha         = 1 << 1,   --              // ColorEdit, ColorPicker, ColorButton: ignore Alpha component (will only read 3 components from the input pointer).
    ImGuiColorEditFlags_NoPicker        = 1 << 2,   --              // ColorEdit: disable picker when clicking on color square.
    ImGuiColorEditFlags_NoOptions       = 1 << 3,   --              // ColorEdit: disable toggling options menu when right-clicking on inputs/small preview.
    ImGuiColorEditFlags_NoSmallPreview  = 1 << 4,   --              // ColorEdit, ColorPicker: disable color square preview next to the inputs. (e.g. to show only the inputs)
    ImGuiColorEditFlags_NoInputs        = 1 << 5,   --              // ColorEdit, ColorPicker: disable inputs sliders/text widgets (e.g. to show only the small preview color square).
    ImGuiColorEditFlags_NoTooltip       = 1 << 6,   --              // ColorEdit, ColorPicker, ColorButton: disable tooltip when hovering the preview.
    ImGuiColorEditFlags_NoLabel         = 1 << 7,   --              // ColorEdit, ColorPicker: disable display of inline text label (the label is still forwarded to the tooltip and picker).
    ImGuiColorEditFlags_NoSidePreview   = 1 << 8,   --              // ColorPicker: disable bigger color preview on right side of the picker, use small color square preview instead.
    ImGuiColorEditFlags_NoDragDrop      = 1 << 9,   --              // ColorEdit: disable drag and drop target. ColorButton: disable drag and drop source.
    ImGuiColorEditFlags_NoBorder        = 1 << 10,  --              // ColorButton: disable border (which is enforced by default)

    -- User Options (right-click on widget to change some of them).
    ImGuiColorEditFlags_AlphaBar        = 1 << 16,  --              // ColorEdit, ColorPicker: show vertical alpha bar/gradient in picker.
    ImGuiColorEditFlags_AlphaPreview    = 1 << 17,  --              // ColorEdit, ColorPicker, ColorButton: display preview as a transparent color over a checkerboard, instead of opaque.
    ImGuiColorEditFlags_AlphaPreviewHalf= 1 << 18,  --              // ColorEdit, ColorPicker, ColorButton: display half opaque / half checkerboard, instead of opaque.
    ImGuiColorEditFlags_HDR             = 1 << 19,  --              // (WIP) ColorEdit: Currently only disable 0.0f..1.0f limits in RGBA edition (note: you probably want to use ImGuiColorEditFlags_Float flag as well).
    ImGuiColorEditFlags_DisplayRGB      = 1 << 20,  -- [Display]    // ColorEdit: override _display_ type among RGB/HSV/Hex. ColorPicker: select any combination using one or more of RGB/HSV/Hex.
    ImGuiColorEditFlags_DisplayHSV      = 1 << 21,  -- [Display]    // "
    ImGuiColorEditFlags_DisplayHex      = 1 << 22,  -- [Display]    // "
    ImGuiColorEditFlags_Uint8           = 1 << 23,  -- [DataType]   // ColorEdit, ColorPicker, ColorButton: _display_ values formatted as 0..255.
    ImGuiColorEditFlags_Float           = 1 << 24,  -- [DataType]   // ColorEdit, ColorPicker, ColorButton: _display_ values formatted as 0.0f..1.0f floats instead of 0..255 integers. No round-trip of value via integers.
    ImGuiColorEditFlags_PickerHueBar    = 1 << 25,  -- [Picker]     // ColorPicker: bar for Hue, rectangle for Sat/Value.
    ImGuiColorEditFlags_PickerHueWheel  = 1 << 26,  -- [Picker]     // ColorPicker: wheel for Hue, triangle for Sat/Value.
    ImGuiColorEditFlags_InputRGB        = 1 << 27,  -- [Input]      // ColorEdit, ColorPicker: input and output data in RGB format.
    ImGuiColorEditFlags_InputHSV        = 1 << 28,  -- [Input]      // ColorEdit, ColorPicker: input and output data in HSV format.

    -- Defaults Options. You can set application defaults using SetColorEditOptions(). The intent is that you probably don't want to
    -- override them in most of your calls. Let the user choose via the option menu and/or call SetColorEditOptions() once during startup.
    ImGuiColorEditFlags_DefaultOptions_ = 1 << 23 | 1 << 20 | 1 << 27 | 1 << 25,

    -- [Internal] Masks
    ImGuiColorEditFlags_DisplayMask_    = 1 << 20 | 1 << 21 | 1 << 22,
    ImGuiColorEditFlags_DataTypeMask_   = 1 << 23 | 1 << 24,
    ImGuiColorEditFlags_PickerMask_     = 1 << 26 | 1 << 25,
    ImGuiColorEditFlags_InputMask_      = 1 << 27 | 1 << 28,
}

---@class ImGuiHoveredFlags
ImGuiHoveredFlags =
{
    ImGuiHoveredFlags_None                          = 0,        -- Return true if directly over the item/window, not obstructed by another window, not obstructed by an active popup or modal blocking inputs under them.
    ImGuiHoveredFlags_ChildWindows                  = 1 << 0,   -- IsWindowHovered() only: Return true if any children of the window is hovered
    ImGuiHoveredFlags_RootWindow                    = 1 << 1,   -- IsWindowHovered() only: Test from root window (top most parent of the current hierarchy)
    ImGuiHoveredFlags_AnyWindow                     = 1 << 2,   -- IsWindowHovered() only: Return true if any window is hovered
    ImGuiHoveredFlags_NoPopupHierarchy              = 1 << 3,   -- IsWindowHovered() only: Do not consider popup hierarchy (do not treat popup emitter as parent of popup) (when used with _ChildWindows or _RootWindow)
    ImGuiHoveredFlags_AllowWhenBlockedByPopup       = 1 << 5,   -- Return true even if a popup window is normally blocking access to this item/window
    ImGuiHoveredFlags_AllowWhenBlockedByActiveItem  = 1 << 7,   -- Return true even if an active item is blocking access to this item/window. Useful for Drag and Drop patterns.
    ImGuiHoveredFlags_AllowWhenOverlapped           = 1 << 8,   -- IsItemHovered() only: Return true even if the position is obstructed or overlapped by another window
    ImGuiHoveredFlags_AllowWhenDisabled             = 1 << 9,   -- IsItemHovered() only: Return true even if the item is disabled
    ImGuiHoveredFlags_NoNavOverride                 = 1 << 10,  -- Disable using gamepad/keyboard navigation state when active, always query mouse.
    ImGuiHoveredFlags_RectOnly                      = 1 << 5 | 1 << 7 | 1 << 8,
    ImGuiHoveredFlags_RootAndChildWindows           = 1 << 1 | 1 << 0,

    -- Hovering delays (for tooltips)
    ImGuiHoveredFlags_DelayNormal                   = 1 << 11,  -- Return true after io.HoverDelayNormal elapsed (~0.30 sec)
    ImGuiHoveredFlags_DelayShort                    = 1 << 12,  -- Return true after io.HoverDelayShort elapsed (~0.10 sec)
    ImGuiHoveredFlags_NoSharedDelay                 = 1 << 13,  -- Disable shared delay system where moving from one item to the next keeps the previous timer for a short time (standard for tooltips with long delays)
};

---@class ImGuiCond
ImGuiCond =
{
    ImGuiCond_None          = 0,        -- No condition (always set the variable), same as _Always
    ImGuiCond_Always        = 1 << 0,   -- No condition (always set the variable), same as _None
    ImGuiCond_Once          = 1 << 1,   -- Set the variable once per runtime session (only the first call will succeed)
    ImGuiCond_FirstUseEver  = 1 << 2,   -- Set the variable if the object/window has no persistently saved data (no entry in .ini file)
    ImGuiCond_Appearing     = 1 << 3,   -- Set the variable if the object/window is appearing after being hidden/inactive (or the first time)
};

-- A key identifier (ImGuiKey_XXX or ImGuiMod_XXX value): can represent Keyboard, Mouse and Gamepad values.
-- All our named keys are >= 512. Keys value 0 to 511 are left unused as legacy native/opaque key values (< 1.87).
-- Since >= 1.89 we increased typing (went from int to enum), some legacy code may need a cast to ImGuiKey.
-- Read details about the 1.87 and 1.89 transition : https://github.com/ocornut/imgui/issues/4921
-- Note that "Keys" related to physical keys and are not the same concept as input "Characters", the later are submitted via io.AddInputCharacter().
---@class ImGuiKey
ImGuiKey =
{
    ImGuiMod_None = 0,
    ImGuiKey_NamedKey_COUNT = 140,
    ImGuiKey_NamedKey_BEGIN = 512,
    ImGuiKey_LeftArrow = 513,
    ImGuiKey_RightArrow = 514,
    ImGuiKey_UpArrow = 515,
    ImGuiKey_DownArrow = 516,
    ImGuiKey_PageUp = 517,
    ImGuiKey_PageDown = 518,
    ImGuiKey_Home = 519,
    ImGuiKey_End = 520,
    ImGuiKey_Insert = 521,
    ImGuiKey_Delete = 522,
    ImGuiKey_Backspace = 523,
    ImGuiKey_Space = 524,
    ImGuiKey_Enter = 525,
    ImGuiKey_Escape = 526,
    ImGuiKey_LeftCtrl = 527,
    ImGuiKey_LeftShift = 528,
    ImGuiKey_LeftAlt = 529,
    ImGuiKey_LeftSuper = 530,
    ImGuiKey_RightCtrl = 531,
    ImGuiKey_RightShift = 532,
    ImGuiKey_RightAlt = 533,
    ImGuiKey_RightSuper = 534,
    ImGuiKey_Menu = 535,
    ImGuiKey_0 = 536,
    ImGuiKey_1 = 537,
    ImGuiKey_2 = 538,
    ImGuiKey_3 = 539,
    ImGuiKey_4 = 540,
    ImGuiKey_5 = 541,
    ImGuiKey_6 = 542,
    ImGuiKey_7 = 543,
    ImGuiKey_8 = 544,
    ImGuiKey_9 = 545,
    ImGuiKey_A = 546,
    ImGuiKey_B = 547,
    ImGuiKey_C = 548,
    ImGuiKey_D = 549,
    ImGuiKey_E = 550,
    ImGuiKey_F = 551,
    ImGuiKey_G = 552,
    ImGuiKey_H = 553,
    ImGuiKey_I = 554,
    ImGuiKey_J = 555,
    ImGuiKey_K = 556,
    ImGuiKey_L = 557,
    ImGuiKey_M = 558,
    ImGuiKey_N = 559,
    ImGuiKey_O = 560,
    ImGuiKey_P = 561,
    ImGuiKey_Q = 562,
    ImGuiKey_R = 563,
    ImGuiKey_S = 564,
    ImGuiKey_T = 565,
    ImGuiKey_U = 566,
    ImGuiKey_V = 567,
    ImGuiKey_W = 568,
    ImGuiKey_X = 569,
    ImGuiKey_Y = 570,
    ImGuiKey_Z = 571,
    ImGuiKey_F1 = 572,
    ImGuiKey_F2 = 573,
    ImGuiKey_F3 = 574,
    ImGuiKey_F4 = 575,
    ImGuiKey_F5 = 576,
    ImGuiKey_F6 = 577,
    ImGuiKey_F7 = 578,
    ImGuiKey_F8 = 579,
    ImGuiKey_F9 = 580,
    ImGuiKey_F10 = 581,
    ImGuiKey_F11 = 582,
    ImGuiKey_F12 = 583,
    ImGuiKey_Apostrophe = 584,
    ImGuiKey_Comma = 585,
    ImGuiKey_Minus = 586,
    ImGuiKey_Period = 587,
    ImGuiKey_Slash = 588,
    ImGuiKey_Semicolon = 589,
    ImGuiKey_Equal = 590,
    ImGuiKey_LeftBracket = 591,
    ImGuiKey_Backslash = 592,
    ImGuiKey_RightBracket = 593,
    ImGuiKey_GraveAccent = 594,
    ImGuiKey_CapsLock = 595,
    ImGuiKey_ScrollLock = 596,
    ImGuiKey_NumLock = 597,
    ImGuiKey_PrintScreen = 598,
    ImGuiKey_Pause = 599,
    ImGuiKey_Keypad0 = 600,
    ImGuiKey_Keypad1 = 601,
    ImGuiKey_Keypad2 = 602,
    ImGuiKey_Keypad3 = 603,
    ImGuiKey_Keypad4 = 604,
    ImGuiKey_Keypad5 = 605,
    ImGuiKey_Keypad6 = 606,
    ImGuiKey_Keypad7 = 607,
    ImGuiKey_Keypad8 = 608,
    ImGuiKey_Keypad9 = 609,
    ImGuiKey_KeypadDecimal = 610,
    ImGuiKey_KeypadDivide = 611,
    ImGuiKey_KeypadMultiply = 612,
    ImGuiKey_KeypadSubtract = 613,
    ImGuiKey_KeypadAdd = 614,
    ImGuiKey_KeypadEnter = 615,
    ImGuiKey_KeypadEqual = 616,
    ImGuiKey_GamepadStart = 617,
    ImGuiKey_GamepadBack = 618,
    ImGuiKey_GamepadFaceLeft = 619,
    ImGuiKey_GamepadFaceRight = 620,
    ImGuiKey_GamepadFaceUp = 621,
    ImGuiKey_GamepadFaceDown = 622,
    ImGuiKey_GamepadDpadLeft = 623,
    ImGuiKey_GamepadDpadRight = 624,
    ImGuiKey_GamepadDpadUp = 625,
    ImGuiKey_GamepadDpadDown = 626,
    ImGuiKey_GamepadL1 = 627,
    ImGuiKey_GamepadR1 = 628,
    ImGuiKey_GamepadL2 = 629,
    ImGuiKey_GamepadR2 = 630,
    ImGuiKey_GamepadL3 = 631,
    ImGuiKey_GamepadR3 = 632,
    ImGuiKey_GamepadLStickLeft = 633,
    ImGuiKey_GamepadLStickRight = 634,
    ImGuiKey_GamepadLStickUp = 635,
    ImGuiKey_GamepadLStickDown = 636,
    ImGuiKey_GamepadRStickLeft = 637,
    ImGuiKey_GamepadRStickRight = 638,
    ImGuiKey_GamepadRStickUp = 639,
    ImGuiKey_GamepadRStickDown = 640,
    ImGuiKey_MouseLeft = 641,
    ImGuiKey_MouseRight = 642,
    ImGuiKey_MouseMiddle = 643,
    ImGuiKey_MouseX1 = 644,
    ImGuiKey_MouseX2 = 645,
    ImGuiKey_MouseWheelX = 646,
    ImGuiKey_MouseWheelY = 647,
    ImGuiKey_ReservedForModCtrl = 648,
    ImGuiKey_ReservedForModShift = 649,
    ImGuiKey_ReservedForModAlt = 650,
    ImGuiKey_ReservedForModSuper = 651,
    ImGuiKey_COUNT = 652,
    ImGuiMod_Shortcut = 2048,
    ImGuiMod_Ctrl = 4096,
    ImGuiMod_Shift = 8192,
    ImGuiMod_Alt = 16384,
    ImGuiMod_Super = 32768,
    ImGuiMod_Mask_ = 63488,    
}

---@class ImGuiMouseButton
ImGuiMouseButton =
{
    ImGuiMouseButton_Left = 0,
    ImGuiMouseButton_Right = 1,
    ImGuiMouseButton_Middle = 2,
    ImGuiMouseButton_COUNT = 5
};

---@class ImGuiCol
ImGuiCol =
{
    ImGuiCol_Text = 0,
    ImGuiCol_TextDisabled = 1,
    ImGuiCol_WindowBg = 2,
    ImGuiCol_ChildBg = 3,
    ImGuiCol_PopupBg = 4,
    ImGuiCol_Border = 5,
    ImGuiCol_BorderShadow = 6,
    ImGuiCol_FrameBg = 7,
    ImGuiCol_FrameBgHovered = 8,
    ImGuiCol_FrameBgActive = 9,
    ImGuiCol_TitleBg = 10,
    ImGuiCol_TitleBgActive = 11,
    ImGuiCol_TitleBgCollapsed = 12,
    ImGuiCol_MenuBarBg = 13,
    ImGuiCol_ScrollbarBg = 14,
    ImGuiCol_ScrollbarGrab = 15,
    ImGuiCol_ScrollbarGrabHovered = 16,
    ImGuiCol_ScrollbarGrabActive = 17,
    ImGuiCol_CheckMark = 18,
    ImGuiCol_SliderGrab = 19,
    ImGuiCol_SliderGrabActive = 20,
    ImGuiCol_Button = 21,
    ImGuiCol_ButtonHovered = 22,
    ImGuiCol_ButtonActive = 23,
    ImGuiCol_Header = 24,
    ImGuiCol_HeaderHovered = 25,
    ImGuiCol_HeaderActive = 26,
    ImGuiCol_Separator = 27,
    ImGuiCol_SeparatorHovered = 28,
    ImGuiCol_SeparatorActive = 29,
    ImGuiCol_ResizeGrip = 30,
    ImGuiCol_ResizeGripHovered = 31,
    ImGuiCol_ResizeGripActive = 32,
    ImGuiCol_Tab = 33,
    ImGuiCol_TabHovered = 34,
    ImGuiCol_TabActive = 35,
    ImGuiCol_TabUnfocused = 36,
    ImGuiCol_TabUnfocusedActive = 37,
    ImGuiCol_PlotLines = 38,
    ImGuiCol_PlotLinesHovered = 39,
    ImGuiCol_PlotHistogram = 40,
    ImGuiCol_PlotHistogramHovered = 41,
    ImGuiCol_TableHeaderBg = 42,
    ImGuiCol_TableBorderStrong = 43,
    ImGuiCol_TableBorderLight = 44,
    ImGuiCol_TableRowBg = 45,
    ImGuiCol_TableRowBgAlt = 46,
    ImGuiCol_TextSelectedBg = 47,
    ImGuiCol_DragDropTarget = 48,
    ImGuiCol_NavHighlight = 49,
    ImGuiCol_NavWindowingHighlight = 50,
    ImGuiCol_NavWindowingDimBg = 51,
    ImGuiCol_ModalWindowDimBg = 52,
    ImGuiCol_COUNT = 53,    
}

---@class ImGuiStyleVar
ImGuiStyleVar =
{
    ImGuiStyleVar_Alpha = 0,
    ImGuiStyleVar_DisabledAlpha = 1,
    ImGuiStyleVar_WindowPadding = 2,
    ImGuiStyleVar_WindowRounding = 3,
    ImGuiStyleVar_WindowBorderSize = 4,
    ImGuiStyleVar_WindowMinSize = 5,
    ImGuiStyleVar_WindowTitleAlign = 6,
    ImGuiStyleVar_ChildRounding = 7,
    ImGuiStyleVar_ChildBorderSize = 8,
    ImGuiStyleVar_PopupRounding = 9,
    ImGuiStyleVar_PopupBorderSize = 10,
    ImGuiStyleVar_FramePadding = 11,
    ImGuiStyleVar_FrameRounding = 12,
    ImGuiStyleVar_FrameBorderSize = 13,
    ImGuiStyleVar_ItemSpacing = 14,
    ImGuiStyleVar_ItemInnerSpacing = 15,
    ImGuiStyleVar_IndentSpacing = 16,
    ImGuiStyleVar_CellPadding = 17,
    ImGuiStyleVar_ScrollbarSize = 18,
    ImGuiStyleVar_ScrollbarRounding = 19,
    ImGuiStyleVar_GrabMinSize = 20,
    ImGuiStyleVar_GrabRounding = 21,
    ImGuiStyleVar_TabRounding = 22,
    ImGuiStyleVar_ButtonTextAlign = 23,
    ImGuiStyleVar_SelectableTextAlign = 24,
    ImGuiStyleVar_SeparatorTextBorderSize = 25,
    ImGuiStyleVar_SeparatorTextAlign = 26,
    ImGuiStyleVar_SeparatorTextPadding = 27,
    ImGuiStyleVar_COUNT = 28,
}

---@class ImGuiTableFlags
ImGuiTableFlags =
{
    -- Features
    ImGuiTableFlags_None                       = 0,
    ImGuiTableFlags_Resizable                  = 1 << 0,   -- Enable resizing columns.
    ImGuiTableFlags_Reorderable                = 1 << 1,   -- Enable reordering columns in header row (need calling TableSetupColumn() + TableHeadersRow() to display headers)
    ImGuiTableFlags_Hideable                   = 1 << 2,   -- Enable hiding/disabling columns in context menu.
    ImGuiTableFlags_Sortable                   = 1 << 3,   -- Enable sorting. Call TableGetSortSpecs() to obtain sort specs. Also see ImGuiTableFlags_SortMulti and ImGuiTableFlags_SortTristate.
    ImGuiTableFlags_NoSavedSettings            = 1 << 4,   -- Disable persisting columns order, width and sort settings in the .ini file.
    ImGuiTableFlags_ContextMenuInBody          = 1 << 5,   -- Right-click on columns body/contents will display table context menu. By default it is available in TableHeadersRow().
    -- Decorations
    ImGuiTableFlags_RowBg                      = 1 << 6,   -- Set each RowBg color with ImGuiCol_TableRowBg or ImGuiCol_TableRowBgAlt (equivalent of calling TableSetBgColor with ImGuiTableBgFlags_RowBg0 on each row manually)
    ImGuiTableFlags_BordersInnerH              = 1 << 7,   -- Draw horizontal borders between rows.
    ImGuiTableFlags_BordersOuterH              = 1 << 8,   -- Draw horizontal borders at the top and bottom.
    ImGuiTableFlags_BordersInnerV              = 1 << 9,   -- Draw vertical borders between columns.
    ImGuiTableFlags_BordersOuterV              = 1 << 10,  -- Draw vertical borders on the left and right sides.
    ImGuiTableFlags_BordersH                   = 1 << 7 | 1 << 8, -- Draw horizontal borders.
    ImGuiTableFlags_BordersV                   = 1 << 9 | 1 << 10, -- Draw vertical borders.
    ImGuiTableFlags_BordersInner               = 1 << 9 | 1 << 7, -- Draw inner borders.
    ImGuiTableFlags_BordersOuter               = 1 << 10 | 1 << 8, -- Draw outer borders.
    ImGuiTableFlags_Borders                    = 1 << 9 | 1 << 7 | 1 << 10 | 1 << 8,   -- Draw all borders.
    ImGuiTableFlags_NoBordersInBody            = 1 << 11,  -- [ALPHA] Disable vertical borders in columns Body (borders will always appear in Headers). -> May move to style
    ImGuiTableFlags_NoBordersInBodyUntilResize = 1 << 12,  -- [ALPHA] Disable vertical borders in columns Body until hovered for resize (borders will always appear in Headers). -> May move to style
    -- Sizing Policy (read above for defaults)
    ImGuiTableFlags_SizingFixedFit             = 1 << 13,  -- Columns default to _WidthFixed or _WidthAuto (if resizable or not resizable), matching contents width.
    ImGuiTableFlags_SizingFixedSame            = 2 << 13,  -- Columns default to _WidthFixed or _WidthAuto (if resizable or not resizable), matching the maximum contents width of all columns. Implicitly enable ImGuiTableFlags_NoKeepColumnsVisible.
    ImGuiTableFlags_SizingStretchProp          = 3 << 13,  -- Columns default to _WidthStretch with default weights proportional to each columns contents widths.
    ImGuiTableFlags_SizingStretchSame          = 4 << 13,  -- Columns default to _WidthStretch with default weights all equal, unless overridden by TableSetupColumn().
    -- Sizing Extra Options
    ImGuiTableFlags_NoHostExtendX              = 1 << 16,  -- Make outer width auto-fit to columns, overriding outer_size.x value. Only available when ScrollX/ScrollY are disabled and Stretch columns are not used.
    ImGuiTableFlags_NoHostExtendY              = 1 << 17,  -- Make outer height stop exactly at outer_size.y (prevent auto-extending table past the limit). Only available when ScrollX/ScrollY are disabled. Data below the limit will be clipped and not visible.
    ImGuiTableFlags_NoKeepColumnsVisible       = 1 << 18,  -- Disable keeping column always minimally visible when ScrollX is off and table gets too small. Not recommended if columns are resizable.
    ImGuiTableFlags_PreciseWidths              = 1 << 19,  -- Disable distributing remainder width to stretched columns (width allocation on a 100-wide table with 3 columns: Without this flag: 33,33,34. With this flag: 33,33,33). With larger number of columns, resizing will appear to be less smooth.
    -- Clipping
    ImGuiTableFlags_NoClip                     = 1 << 20,  -- Disable clipping rectangle for every individual columns (reduce draw command count, items will be able to overflow into other columns). Generally incompatible with TableSetupScrollFreeze().
    -- Padding
    ImGuiTableFlags_PadOuterX                  = 1 << 21,  -- Default if BordersOuterV is on. Enable outermost padding. Generally desirable if you have headers.
    ImGuiTableFlags_NoPadOuterX                = 1 << 22,  -- Default if BordersOuterV is off. Disable outermost padding.
    ImGuiTableFlags_NoPadInnerX                = 1 << 23,  -- Disable inner padding between columns (double inner padding if BordersOuterV is on, single inner padding if BordersOuterV is off).
    -- Scrolling
    ImGuiTableFlags_ScrollX                    = 1 << 24,  -- Enable horizontal scrolling. Require 'outer_size' parameter of BeginTable() to specify the container size. Changes default sizing policy. Because this creates a child window, ScrollY is currently generally recommended when using ScrollX.
    ImGuiTableFlags_ScrollY                    = 1 << 25,  -- Enable vertical scrolling. Require 'outer_size' parameter of BeginTable() to specify the container size.
    -- Sorting
    ImGuiTableFlags_SortMulti                  = 1 << 26,  -- Hold shift when clicking headers to sort on multiple column. TableGetSortSpecs() may return specs where (SpecsCount > 1).
    ImGuiTableFlags_SortTristate               = 1 << 27,  -- Allow no sorting, disable default sorting. TableGetSortSpecs() may return specs where (SpecsCount == 0).

    -- [Internal] Combinations and masks
    ImGuiTableFlags_SizingMask_                = 1 << 13 | 2 << 13 | 3 << 13 | 4 << 13,
}

---@class ImGuiTableColumnFlags
ImGuiTableColumnFlags =
{
    -- Input configuration flags
    ImGuiTableColumnFlags_None                  = 0,
    ImGuiTableColumnFlags_Disabled              = 1 << 0,   -- Overriding/master disable flag: hide column, won't show in context menu (unlike calling TableSetColumnEnabled() which manipulates the user accessible state)
    ImGuiTableColumnFlags_DefaultHide           = 1 << 1,   -- Default as a hidden/disabled column.
    ImGuiTableColumnFlags_DefaultSort           = 1 << 2,   -- Default as a sorting column.
    ImGuiTableColumnFlags_WidthStretch          = 1 << 3,   -- Column will stretch. Preferable with horizontal scrolling disabled (default if table sizing policy is _SizingStretchSame or _SizingStretchProp).
    ImGuiTableColumnFlags_WidthFixed            = 1 << 4,   -- Column will not stretch. Preferable with horizontal scrolling enabled (default if table sizing policy is _SizingFixedFit and table is resizable).
    ImGuiTableColumnFlags_NoResize              = 1 << 5,   -- Disable manual resizing.
    ImGuiTableColumnFlags_NoReorder             = 1 << 6,   -- Disable manual reordering this column, this will also prevent other columns from crossing over this column.
    ImGuiTableColumnFlags_NoHide                = 1 << 7,   -- Disable ability to hide/disable this column.
    ImGuiTableColumnFlags_NoClip                = 1 << 8,   -- Disable clipping for this column (all NoClip columns will render in a same draw command).
    ImGuiTableColumnFlags_NoSort                = 1 << 9,   -- Disable ability to sort on this field (even if ImGuiTableFlags_Sortable is set on the table).
    ImGuiTableColumnFlags_NoSortAscending       = 1 << 10,  -- Disable ability to sort in the ascending direction.
    ImGuiTableColumnFlags_NoSortDescending      = 1 << 11,  -- Disable ability to sort in the descending direction.
    ImGuiTableColumnFlags_NoHeaderLabel         = 1 << 12,  -- TableHeadersRow() will not submit label for this column. Convenient for some small columns. Name will still appear in context menu.
    ImGuiTableColumnFlags_NoHeaderWidth         = 1 << 13,  -- Disable header text width contribution to automatic column width.
    ImGuiTableColumnFlags_PreferSortAscending   = 1 << 14,  -- Make the initial sort direction Ascending when first sorting on this column (default).
    ImGuiTableColumnFlags_PreferSortDescending  = 1 << 15,  -- Make the initial sort direction Descending when first sorting on this column.
    ImGuiTableColumnFlags_IndentEnable          = 1 << 16,  -- Use current Indent value when entering cell (default for column 0).
    ImGuiTableColumnFlags_IndentDisable         = 1 << 17,  -- Ignore current Indent value when entering cell (default for columns > 0). Indentation changes _within_ the cell will still be honored.

    -- Output status flags, read-only via TableGetColumnFlags()
    ImGuiTableColumnFlags_IsEnabled             = 1 << 24,  -- Status: is enabled == not hidden by user/api (referred to as "Hide" in _DefaultHide and _NoHide) flags.
    ImGuiTableColumnFlags_IsVisible             = 1 << 25,  -- Status: is visible == is enabled AND not clipped by scrolling.
    ImGuiTableColumnFlags_IsSorted              = 1 << 26,  -- Status: is currently part of the sort specs
    ImGuiTableColumnFlags_IsHovered             = 1 << 27,  -- Status: is hovered by mouse

    -- [Internal] Combinations and masks
    ImGuiTableColumnFlags_WidthMask_            = 1 << 3 | 1 << 4,
    ImGuiTableColumnFlags_IndentMask_           = 1 << 16 | 1 << 17,
    ImGuiTableColumnFlags_StatusMask_           = 1 << 24 | 1 << 25 | 1 << 26 | 1 << 27,
    ImGuiTableColumnFlags_NoDirectResize_       = 1 << 30,  -- [Internal] Disable user resizing this column directly (it may however we resized indirectly from its left edge)
};

---@class ImGuiTableRowFlags
ImGuiTableRowFlags =
{
    ImGuiTableRowFlags_None                     = 0,
    ImGuiTableRowFlags_Headers                  = 1 << 0,   -- Identify header row (set default background color + width of its contents accounted differently for auto column width)
};

---@class ImGuiTableBgTarget
ImGuiTableBgTarget =
{
    ImGuiTableBgTarget_None                     = 0,
    ImGuiTableBgTarget_RowBg0                   = 1,        -- Set row background color 0 (generally used for background, automatically set when ImGuiTableFlags_RowBg is used)
    ImGuiTableBgTarget_RowBg1                   = 2,        -- Set row background color 1 (generally used for selection marking)
    ImGuiTableBgTarget_CellBg                   = 3,        -- Set cell background color (top-most color)
};

---@class ImGuiSortDirection
ImGuiSortDirection =
{
    ImGuiSortDirection_None         = 0,
    ImGuiSortDirection_Ascending    = 1,    -- Ascending = 0->9, A->Z etc.
    ImGuiSortDirection_Descending   = 2     -- Descending = 9->0, Z->A etc.
}

---@class ImGuizmoOperation
ImGuizmoOperation =
{
   TRANSLATE_X      = (1 << 0),
   TRANSLATE_Y      = (1 << 1),
   TRANSLATE_Z      = (1 << 2),
   ROTATE_X         = (1 << 3),
   ROTATE_Y         = (1 << 4),
   ROTATE_Z         = (1 << 5),
   ROTATE_SCREEN    = (1 << 6),
   SCALE_X          = (1 << 7),
   SCALE_Y          = (1 << 8),
   SCALE_Z          = (1 << 9),
   BOUNDS           = (1 << 10),
   SCALE_XU         = (1 << 11),
   SCALE_YU         = (1 << 12),
   SCALE_ZU         = (1 << 13),

   TRANSLATE = 1 << 0 | 1 << 1 | 1 << 2,
   ROTATE = 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6,
   SCALE = 1 << 7 | 1 << 8 | 1 << 9,
   SCALEU = 1 << 11 | 1 << 12 | 13,
   UNIVERSAL = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6 | 1 << 11 | 1 << 12 | 13
}

---@class ImGuizmoMode
ImGuizmoMode =
{
   LOCAL = 0,
   WORLD = 1
}

-- Sorting specification for one column of a table (sizeof == 12 bytes)
---@class ImGuiTableColumnSortSpecs
ImGuiTableColumnSortSpecs =
{
    ColumnUserID = 0,       -- User id of the column (if specified by a TableSetupColumn() call)
    ColumnIndex = 0,        -- Index of the column
    SortOrder = 0,          -- Index within parent ImGuiTableSortSpecs (always stored in order starting from 0, tables sorted on a single criteria will always have a 0 here)
    ISortDirection = 8,     -- ImGuiSortDirection_Ascending or ImGuiSortDirection_Descending (you can use this or SortSign, whichever is more convenient for your sort function)
}

-- Sorting specifications for a table (often handling sort specs for a single column, occasionally more)
-- Obtained by calling TableGetSortSpecs().
-- When 'SpecsDirty == true' you can sort your data. It will be true with sorting specs have changed since last call, or the first time.
-- Make sure to set 'SpecsDirty = false' after sorting, else you may wastefully sort your data every frame!
---@cals ImGuiTableSortSpecs
ImGuiTableSortSpecs =
{
    Specs = ImGuiTableColumnSortSpecs,     -- Pointer to sort spec array.
    SpecsCount = 0,                        -- Sort spec count. Most often 1. May be > 1 when ImGuiTableFlags_SortMulti is enabled. May be == 0 when ImGuiTableFlags_SortTristate is enabled.
    SpecsDirty = false                     -- Set to true when specs have changed since last time! Use this to sort again, then clear the flag.
};

-- END ImGui

---@class ApplicationEntryOptions
ApplicationEntryOptions =
{
    Initialize = "Initialize",
    InitializeLog = "InitializeLog",
    InitializeGameCore = "InitializeGameCore",
    InitializeStorage = "InitializeStorage",
    InitializeResourceManager = "InitializeResourceManager",
    InitializeScene = "InitializeScene",
    InitializeRemoteHost = "InitializeRemoteHost",
    InitializeVM = "InitializeVM",
    InitializeSystemService = "InitializeSystemService",
    InitializeHardwareService = "InitializeHardwareService",
    InitializePushNotificationService = "InitializePushNotificationService",
    InitializeDialog = "InitializeDialog",
    InitializeShareService = "InitializeShareService",
    InitializeUserService = "InitializeUserService",
    InitializeUDS = "InitializeUDS",
    InitializeModalDialogService = "InitializeModalDialogService",
    InitializeGlobalUserData = "InitializeGlobalUserData",
    InitializeSteam = "InitializeSteam",
    InitializeWeGame = "InitializeWeGame",
    InitializeXCloud = "InitializeXCloud",
    InitializeRebe = "InitializeRebe",
    InitializeBcat = "InitializeBcat",
    InitializeEffectMemorySettings = "InitializeEffectMemorySettings",
    InitializeRenderer = "InitializeRenderer",
    InitializeVR = "InitializeVR",
    InitializeSpeedTree = "InitializeSpeedTree",
    InitializeHID = "InitializeHID",
    InitializeEffect = "InitializeEffect",
    InitializeGeometry = "InitializeGeometry",
    InitializeLandscape = "InitializeLandscape",
    InitializeHoudini = "InitializeHoudini",
    InitializeSound = "InitializeSound",
    InitializeWwiselib = "InitializeWwiselib",
    InitializeSimpleWwise = "InitializeSimpleWwise",
    InitializeWwise = "InitializeWwise",
    InitializeAudioRender = "InitializeAudioRender",
    InitializeGUI = "InitializeGUI",
    InitializeSpine = "InitializeSpine",
    InitializeMotion = "InitializeMotion",
    InitializeBehaviorTree = "InitializeBehaviorTree",
    InitializeAutoPlay = "InitializeAutoPlay",
    InitializeScenario = "InitializeScenario",
    InitializeOctree = "InitializeOctree",
    InitializeAreaMap = "InitializeAreaMap",
    InitializeFSM = "InitializeFSM",
    InitializeNavigation = "InitializeNavigation",
    InitializePointGraph = "InitializePointGraph",
    InitializeFluidFlock = "InitializeFluidFlock",
    InitializeTimeline = "InitializeTimeline",
    InitializePhysics = "InitializePhysics",
    InitializeDynamics = "InitializeDynamics",
    InitializeHavok = "InitializeHavok",
    InitializeBake = "InitializeBake",
    InitializeNetwork = "InitializeNetwork",
    InitializePuppet = "InitializePuppet",
    InitializeVoiceChat = "InitializeVoiceChat",
    InitializeVivoxlib = "InitializeVivoxlib",
    InitializeStore = "InitializeStore",
    InitializeBrowser = "InitializeBrowser",
    InitializeDevelopSystem = "InitializeDevelopSystem",
    InitializeBehavior = "InitializeBehavior",
    InitializeMovie = "InitializeMovie",
    InitializeMame = "InitializeMame",
    InitializeSkuService = "InitializeSkuService",
    InitializeTelemetry = "InitializeTelemetry",
    InitializeHansoft = "InitializeHansoft",
    InitializeNNFC = "InitializeNNFC",
    InitializeMixer = "InitializeMixer",
    InitializeThreadPool = "InitializeThreadPool",
    Setup = "Setup",
    SetupJobScheduler = "SetupJobScheduler",
    SetupResourceManager = "SetupResourceManager",
    SetupStorage = "SetupStorage",
    SetupGlobalUserData = "SetupGlobalUserData",
    SetupScene = "SetupScene",
    SetupDevelopSystem = "SetupDevelopSystem",
    SetupUserService = "SetupUserService",
    SetupSystemService = "SetupSystemService",
    SetupHardwareService = "SetupHardwareService",
    SetupPushNotificationService = "SetupPushNotificationService",
    SetupShareService = "SetupShareService",
    SetupModalDialogService = "SetupModalDialogService",
    SetupVM = "SetupVM",
    SetupHID = "SetupHID",
    SetupRenderer = "SetupRenderer",
    SetupEffect = "SetupEffect",
    SetupGeometry = "SetupGeometry",
    SetupLandscape = "SetupLandscape",
    SetupHoudini = "SetupHoudini",
    SetupSound = "SetupSound",
    SetupWwiselib = "SetupWwiselib",
    SetupSimpleWwise = "SetupSimpleWwise",
    SetupWwise = "SetupWwise",
    SetupAudioRender = "SetupAudioRender",
    SetupMotion = "SetupMotion",
    SetupNavigation = "SetupNavigation",
    SetupPointGraph = "SetupPointGraph",
    SetupPhysics = "SetupPhysics",
    SetupDynamics = "SetupDynamics",
    SetupHavok = "SetupHavok",
    SetupMovie = "SetupMovie",
    SetupMame = "SetupMame",
    SetupNetwork = "SetupNetwork",
    SetupPuppet = "SetupPuppet",
    SetupStore = "SetupStore",
    SetupBrowser = "SetupBrowser",
    SetupVoiceChat = "SetupVoiceChat",
    SetupVivoxlib = "SetupVivoxlib",
    SetupSkuService = "SetupSkuService",
    SetupTelemetry = "SetupTelemetry",
    SetupHansoft = "SetupHansoft",
    StartApp = "StartApp",
    SetupOctree = "SetupOctree",
    SetupAreaMap = "SetupAreaMap",
    SetupBehaviorTree = "SetupBehaviorTree",
    SetupFSM = "SetupFSM",
    SetupGUI = "SetupGUI",
    SetupSpine = "SetupSpine",
    SetupSpeedTree = "SetupSpeedTree",
    SetupNNFC = "SetupNNFC",
    Start = "Start",
    StartStorage = "StartStorage",
    StartResourceManager = "StartResourceManager",
    StartGlobalUserData = "StartGlobalUserData",
    StartPhysics = "StartPhysics",
    StartDynamics = "StartDynamics",
    StartGUI = "StartGUI",
    StartTimeline = "StartTimeline",
    StartOctree = "StartOctree",
    StartAreaMap = "StartAreaMap",
    StartBehaviorTree = "StartBehaviorTree",
    StartFSM = "StartFSM",
    StartSound = "StartSound",
    StartWwise = "StartWwise",
    StartAudioRender = "StartAudioRender",
    StartScene = "StartScene",
    StartRebe = "StartRebe",
    StartNetwork = "StartNetwork",
    Update = "Update",
    UpdateDialog = "UpdateDialog",
    UpdateRemoteHost = "UpdateRemoteHost",
    UpdateStorage = "UpdateStorage",
    UpdateScene = "UpdateScene",
    UpdateDevelopSystem = "UpdateDevelopSystem",
    UpdateWidget = "UpdateWidget",
    UpdateAutoPlay = "UpdateAutoPlay",
    UpdateScenario = "UpdateScenario",
    UpdateCapture = "UpdateCapture",
    BeginFrameRendering = "BeginFrameRendering",
    UpdateVR = "UpdateVR",
    UpdateHID = "UpdateHID",
    UpdateMotionFrame = "UpdateMotionFrame",
    BeginDynamics = "BeginDynamics",
    PreupdateGUI = "PreupdateGUI",
    BeginHavok = "BeginHavok",
    UpdateAIMap = "UpdateAIMap",
    CreatePreupdateGroupFSM = "CreatePreupdateGroupFSM",
    CreatePreupdateGroupBehaviorTree = "CreatePreupdateGroupBehaviorTree",
    UpdateGlobalUserData = "UpdateGlobalUserData",
    UpdateUDS = "UpdateUDS",
    UpdateUserService = "UpdateUserService",
    UpdateSystemService = "UpdateSystemService",
    UpdateHardwareService = "UpdateHardwareService",
    UpdatePushNotificationService = "UpdatePushNotificationService",
    UpdateShareService = "UpdateShareService",
    UpdateSteam = "UpdateSteam",
    UpdateWeGame = "UpdateWeGame",
    UpdateBcat = "UpdateBcat",
    UpdateXCloud = "UpdateXCloud",
    UpdateRebe = "UpdateRebe",
    UpdateNNFC = "UpdateNNFC",
    BeginPhysics = "BeginPhysics",
    BeginUpdatePrimitive = "BeginUpdatePrimitive",
    BeginUpdatePrimitiveGUI = "BeginUpdatePrimitiveGUI",
    BeginUpdateSpineDraw = "BeginUpdateSpineDraw",
    UpdatePuppet = "UpdatePuppet",
    UpdateGUI = "UpdateGUI",
    PreupdateBehavior = "PreupdateBehavior",
    PreupdateBehaviorTree = "PreupdateBehaviorTree",
    PreupdateFSM = "PreupdateFSM",
    PreupdateTimeline = "PreupdateTimeline",
    UpdateBehavior = "UpdateBehavior",
    CreateUpdateGroupBehaviorTree = "CreateUpdateGroupBehaviorTree",
    CreateNavigationChain = "CreateNavigationChain",
    CreateUpdateGroupFSM = "CreateUpdateGroupFSM",
    UpdateTimeline = "UpdateTimeline",
    PreUpdateAreaMap = "PreUpdateAreaMap",
    UpdateOctree = "UpdateOctree",
    UpdateAreaMap = "UpdateAreaMap",
    UpdateBehaviorTree = "UpdateBehaviorTree",
    UpdateTimelineFsm2 = "UpdateTimelineFsm2",
    UpdateNavigationPrev = "UpdateNavigationPrev",
    UpdateFSM = "UpdateFSM",
    UpdateMotion = "UpdateMotion",
    UpdateSpine = "UpdateSpine",
    EffectCollisionLimit = "EffectCollisionLimit",
    UpdatePhysicsAfterUpdatePhase = "UpdatePhysicsAfterUpdatePhase",
    UpdateGeometry = "UpdateGeometry",
    UpdateLandscape = "UpdateLandscape",
    UpdateHoudini = "UpdateHoudini",
    UpdatePhysicsCharacterController = "UpdatePhysicsCharacterController",
    BeginUpdateHavok2 = "BeginUpdateHavok2",
    UpdateDynamics = "UpdateDynamics",
    UpdateNavigation = "UpdateNavigation",
    UpdatePointGraph = "UpdatePointGraph",
    UpdateFluidFlock = "UpdateFluidFlock",
    UpdateConstraintsBegin = "UpdateConstraintsBegin",
    LateUpdateBehavior = "LateUpdateBehavior",
    EditUpdateBehavior = "EditUpdateBehavior",
    LateUpdateSpine = "LateUpdateSpine",
    BeginUpdateHavok = "BeginUpdateHavok",
    BeginUpdateEffect = "BeginUpdateEffect",
    UpdateConstraintsEnd = "UpdateConstraintsEnd",
    UpdatePhysicsAfterLateUpdatePhase = "UpdatePhysicsAfterLateUpdatePhase",
    PrerenderGUI = "PrerenderGUI",
    PrepareRendering = "PrepareRendering",
    UpdateSound = "UpdateSound",
    UpdateWwiselib = "UpdateWwiselib",
    UpdateSimpleWwise = "UpdateSimpleWwise",
    UpdateWwise = "UpdateWwise",
    UpdateAudioRender = "UpdateAudioRender",
    CreateSelectorGroupFSM = "CreateSelectorGroupFSM",
    UpdateNetwork = "UpdateNetwork",
    UpdateHavok = "UpdateHavok",
    EndUpdateHavok = "EndUpdateHavok",
    UpdateFSMSelector = "UpdateFSMSelector",
    UpdateBehaviorTreeSelector = "UpdateBehaviorTreeSelector",
    BeforeLockSceneRendering = "BeforeLockSceneRendering",
    EndUpdateHavok2 = "EndUpdateHavok2",
    UpdateJointExpression = "UpdateJointExpression",
    UpdateBehaviorTreeSelectorLegacy = "UpdateBehaviorTreeSelectorLegacy",
    UpdateEffect = "UpdateEffect",
    EndUpdateEffect = "EndUpdateEffect",
    UpdateWidgetDynamics = "UpdateWidgetDynamics",
    LockScene = "LockScene",
    WaitRendering = "WaitRendering",
    EndDynamics = "EndDynamics",
    EndPhysics = "EndPhysics",
    BeginRendering = "BeginRendering",
    UpdateSpeedTree = "UpdateSpeedTree",
    RenderDynamics = "RenderDynamics",
    RenderGUI = "RenderGUI",
    RenderGeometry = "RenderGeometry",
    RenderLandscape = "RenderLandscape",
    RenderHoudini = "RenderHoudini",
    UpdatePrimitiveGUI = "UpdatePrimitiveGUI",
    UpdatePrimitive = "UpdatePrimitive",
    UpdateSpineDraw = "UpdateSpineDraw",
    EndUpdatePrimitive = "EndUpdatePrimitive",
    EndUpdatePrimitiveGUI = "EndUpdatePrimitiveGUI",
    EndUpdateSpineDraw = "EndUpdateSpineDraw",
    GUIPostPrimitiveRender = "GUIPostPrimitiveRender",
    ShapeRenderer = "ShapeRenderer",
    UpdateMovie = "UpdateMovie",
    UpdateMame = "UpdateMame",
    UpdateTelemetry = "UpdateTelemetry",
    UpdateHansoft = "UpdateHansoft",
    DrawWidget = "DrawWidget",
    DevelopRenderer = "DevelopRenderer",
    EndRendering = "EndRendering",
    UpdateStore = "UpdateStore",
    UpdateBrowser = "UpdateBrowser",
    UpdateVoiceChat = "UpdateVoiceChat",
    UpdateVivoxlib = "UpdateVivoxlib",
    UnlockScene = "UnlockScene",
    UpdateVM = "UpdateVM",
    StepVisualDebugger = "StepVisualDebugger",
    WaitForVblank = "WaitForVblank",
    Terminate = "Terminate",
    TerminateScene = "TerminateScene",
    TerminateRemoteHost = "TerminateRemoteHost",
    TerminateHansoft = "TerminateHansoft",
    TerminateTelemetry = "TerminateTelemetry",
    TerminateMame = "TerminateMame",
    TerminateMovie = "TerminateMovie",
    TerminateSound = "TerminateSound",
    TerminateSimpleWwise = "TerminateSimpleWwise",
    TerminateWwise = "TerminateWwise",
    TerminateWwiselib = "TerminateWwiselib",
    TerminateAudioRender = "TerminateAudioRender",
    TerminateVoiceChat = "TerminateVoiceChat",
    TerminateVivoxlib = "TerminateVivoxlib",
    TerminatePuppet = "TerminatePuppet",
    TerminateNetwork = "TerminateNetwork",
    TerminateStore = "TerminateStore",
    TerminateBrowser = "TerminateBrowser",
    TerminateSpine = "TerminateSpine",
    TerminateGUI = "TerminateGUI",
    TerminateAreaMap = "TerminateAreaMap",
    TerminateOctree = "TerminateOctree",
    TerminateFluidFlock = "TerminateFluidFlock",
    TerminateBehaviorTree = "TerminateBehaviorTree",
    TerminateFSM = "TerminateFSM",
    TerminateNavigation = "TerminateNavigation",
    TerminatePointGraph = "TerminatePointGraph",
    TerminateEffect = "TerminateEffect",
    TerminateGeometry = "TerminateGeometry",
    TerminateLandscape = "TerminateLandscape",
    TerminateHoudini = "TerminateHoudini",
    TerminateRenderer = "TerminateRenderer",
    TerminateHID = "TerminateHID",
    TerminateDynamics = "TerminateDynamics",
    TerminatePhysics = "TerminatePhysics",
    TerminateResourceManager = "TerminateResourceManager",
    TerminateHavok = "TerminateHavok",
    TerminateModalDialogService = "TerminateModalDialogService",
    TerminateShareService = "TerminateShareService",
    TerminateGlobalUserData = "TerminateGlobalUserData",
    TerminateStorage = "TerminateStorage",
    TerminateVM = "TerminateVM",
    TerminateJobScheduler = "TerminateJobScheduler",
    Finalize = "Finalize",
    FinalizeThreadPool = "FinalizeThreadPool",
    FinalizeHansoft = "FinalizeHansoft",
    FinalizeTelemetry = "FinalizeTelemetry",
    FinalizeMame = "FinalizeMame",
    FinalizeMovie = "FinalizeMovie",
    FinalizeBehavior = "FinalizeBehavior",
    FinalizeDevelopSystem = "FinalizeDevelopSystem",
    FinalizeTimeline = "FinalizeTimeline",
    FinalizePuppet = "FinalizePuppet",
    FinalizeNetwork = "FinalizeNetwork",
    FinalizeStore = "FinalizeStore",
    FinalizeBrowser = "FinalizeBrowser",
    finalizeAutoPlay = "finalizeAutoPlay",
    finalizeScenario = "finalizeScenario",
    FinalizeBehaviorTree = "FinalizeBehaviorTree",
    FinalizeFSM = "FinalizeFSM",
    FinalizeNavigation = "FinalizeNavigation",
    FinalizePointGraph = "FinalizePointGraph",
    FinalizeAreaMap = "FinalizeAreaMap",
    FinalizeOctree = "FinalizeOctree",
    FinalizeFluidFlock = "FinalizeFluidFlock",
    FinalizeMotion = "FinalizeMotion",
    FinalizeDynamics = "FinalizeDynamics",
    FinalizePhysics = "FinalizePhysics",
    FinalizeHavok = "FinalizeHavok",
    FinalizeBake = "FinalizeBake",
    FinalizeSpine = "FinalizeSpine",
    FinalizeGUI = "FinalizeGUI",
    FinalizeSound = "FinalizeSound",
    FinalizeWwiselib = "FinalizeWwiselib",
    FinalizeSimpleWwise = "FinalizeSimpleWwise",
    FinalizeWwise = "FinalizeWwise",
    FinalizeAudioRender = "FinalizeAudioRender",
    FinalizeEffect = "FinalizeEffect",
    FinalizeGeometry = "FinalizeGeometry",
    FinalizeSpeedTree = "FinalizeSpeedTree",
    FinalizeLandscape = "FinalizeLandscape",
    FinalizeHoudini = "FinalizeHoudini",
    FinalizeRenderer = "FinalizeRenderer",
    FinalizeHID = "FinalizeHID",
    FinalizeVR = "FinalizeVR",
    FinalizeBcat = "FinalizeBcat",
    FinalizeRebe = "FinalizeRebe",
    FinalizeXCloud = "FinalizeXCloud",
    FinalizeSteam = "FinalizeSteam",
    FinalizeWeGame = "FinalizeWeGame",
    FinalizeNNFC = "FinalizeNNFC",
    FinalizeGlobalUserData = "FinalizeGlobalUserData",
    FinalizeModalDialogService = "FinalizeModalDialogService",
    FinalizeSkuService = "FinalizeSkuService",
    FinalizeUDS = "FinalizeUDS",
    FinalizeUserService = "FinalizeUserService",
    FinalizeShareService = "FinalizeShareService",
    FinalizeSystemService = "FinalizeSystemService",
    FinalizeHardwareService = "FinalizeHardwareService",
    FinalizePushNotificationService = "FinalizePushNotificationService",
    FinalizeScene = "FinalizeScene",
    FinalizeVM = "FinalizeVM",
    FinalizeResourceManager = "FinalizeResourceManager",
    FinalizeRemoteHost = "FinalizeRemoteHost",
    FinalizeStorage = "FinalizeStorage",
    FinalizeDialog = "FinalizeDialog",
    FinalizeMixer = "FinalizeMixer",
    FinalizeGameCore = "FinalizeGameCore",
}

return {
    Vector2f = Vector2f,
    Vector3f = Vector3f,
    Vector4f = Vector4f,
    Matrix4x4f = Matrix4x4f,
    Quaternion = Quaternion,
    ValueType = ValueType
}
