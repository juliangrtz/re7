local sdk = sdk

--- Returns the version of the type database. A good approximation of the version of the RE Engine the game is running on.
---@return integer
local function sdk_get_tdb_version()
    return sdk.get_tdb_version()
end

--- Returns game_namespace.name.
--- DMC5: name would get converted to app.name
--- RE3: name would get converted to offline.name
---@param name string
---@return string
local function sdk_game_namespace(name)
    return sdk.game_namespace(name)
end

---@return any
local function sdk_get_thread_context()
    return sdk.get_thread_context()
end

--- Returns a void*. Can be used with sdk.call_native_func
--- Possible singletons can be found in the Native Singletons view in the Object Explorer.
---@param name string
---@return any
local function sdk_get_native_singleton(name)
    return sdk.get_native_singleton(name)
end

--- Returns an REManagedObject*.
--- Possible singletons can be found in the Singletons view in the Object Explorer.
---@param name string
---@return REManagedObject|any (REManagedObject*)
local function sdk_get_managed_singleton(name)
    return sdk.get_managed_singleton(name)
end

--- Returns an RETypeDefinition*.
---@param name string
---@return RETypeDefinition|any (RETypeDefinition*)
local function sdk_find_type_definition(name)
    return sdk.find_type_definition(name)
end

--- Returns a System.Type. 
--- Equivalent to calling sdk.find_type_definition(name):get_runtime_type().
--- Equivalent to typeof in C#.
---@param name string
---@return System.Type|any
local function sdk_typeof(name)
    return sdk.typeof(name)
end

--- Returns an REManagedObject.
--- Equivalent to calling sdk.find_type_definition(typename):create_instance()
--- simplify - defaults to false. Set this to true if this function is returning nil.
---@param typename string
---@param simplify boolean
---@return REManagedObject
local function sdk_create_instance(typename, simplify)
    return sdk.create_instance(typename, simplify)
end

--- Creates and returns a new System.String from str.
---@param str string
---@return System.String|any
local function sdk_create_managed_string(str)
    return sdk.create_managed_string(str)
end

--- Creates and returns a new SystemArray of the given type, with length elements.
--- type can be any of the following:
--- A System.Type returned from sdk.typeof
--- An RETypeDefinition returned from sdk.find_type_definition
--- A Lua string representing the type name.
--- Any other type will throw a Lua error.
--- If type cannot resolve to a valid System.Type, a Lua error will be thrown.
---@param type string|any
---@param length number
---@return SystemArray|System.Array
local function sdk_create_managed_array(type, length)
    return sdk.create_managed_array(type, length)
end

--- Returns a fully constructed REManagedObject of type System.SByte given the value.
---@param value integer (int8_t)
---@return REManagedObject|System.SByte
local function sdk_create_sbyte(value)
    return sdk.create_sbyte(value)
end

--- Returns a fully constructed REManagedObject of type System.Byte given the value.
---@param value integer (uint8_t)
---@return REManagedObject|System.Byte
local function sdk_create_byte(value)
    return sdk.create_byte(value)
end

--- Returns a fully constructed REManagedObject of type System.Int16 given the value.
---@param value integer (int16_t)
---@return REManagedObject|System.Int16
local function sdk_create_int16(value)
    return sdk.create_int16(value)
end

--- Returns a fully constructed REManagedObject of type System.UInt16 given the value.
---@param value integer (uint16_t)
---@return REManagedObject|System.UInt16
local function sdk_create_uint16(value)
    return sdk.create_uint16(value)
end

--- Returns a fully constructed REManagedObject of type System.Int32 given the value.
---@param value integer (int32_t)
---@return REManagedObject|System.Int32
local function sdk_create_int32(value)
    return sdk.create_int32(value)
end

--- Returns a fully constructed REManagedObject of type System.UInt32 given the value.
---@param value integer (int32_t)
---@return REManagedObject|System.UInt32
local function sdk_create_uint32(value)
    return sdk.create_uint32(value)
end

--- Returns a fully constructed REManagedObject of type System.Int64 given the value.
---@param value integer (int64_t)
---@return REManagedObject|System.Int64
local function sdk_create_int64(value)
    return sdk.create_int64(value)
end

--- Returns a fully constructed REManagedObject of type System.UInt64 given the value.
---@param value integer (int64_t)
---@return REManagedObject|System.UInt64
local function sdk_create_uint64(value)
    return sdk.create_uint64(value)
end

--- Returns a fully constructed REManagedObject of type System.Single given the value.
---@param value integer (float)
---@return REManagedObject|System.Single
local function sdk_create_single(value)
    return sdk.create_single(value)
end

--- Returns a fully constructed REManagedObject of type System.Double given the value.
---@param value integer (float)
---@return REManagedObject|System.Double
local function sdk_create_double(value)
    return sdk.create_double(value)
end

--- Returns an REResource.
--- If the typename does not correctly correspond to the resource file or is not a resource type, nil will be returned.
---@return any (REResource)
local function sdk_create_resource(typename, resource_path)
    return sdk.create_resource(typename, resource_path)
end

--- Returns an REManagedObject which is a via.UserData. typename can be &quot;via.UserData&quot; unless you know the full typename.
---@return REManagedObject|any (via.UserData)
local function sdk_create_userdata(typename, userdata_path)
    return sdk.create_userdata(typename, userdata_path)
end

--- Returns a list of REManagedObject generated from data. 
--- data is the raw RSZ data contained for example in a .scn file, starting at the RSZ magic in the header.
--- data must in table format as an array of bytes.
--- Example usage:
--- local rsz_data = json.load_file(&quot;Foobar.json&quot;)
--- local objects = sdk.deserialize(rsz_data)
--- for i, v in ipairs(objects) do
---     local obj_type = v:get_type_definition()
---     log.info(obj_type:get_full_name())
--- end
---@return any (REManagedObject[])
local function sdk_deserialize(data)
    return sdk.deserialize(data)
end

--- Return value is dependent on what the method returns.
--- Full function prototype can be passed as method_name if there are multiple functions with the same name but different parameters.
--- Should only be used with native types, not REManagedObject (though, it can be if wanted).
--- Example:
--- local scene_manager = sdk.get_native_singleton(&quot;via.SceneManager&quot;)
--- local scene_manager_type = sdk.find_type_definition(&quot;via.SceneManager&quot;)
--- local scene = sdk.call_native_func(scene_manager, scene_manager_type, &quot;get_CurrentScene&quot;)
--- if scene ~= nil then
---     -- We can use call like this because scene is a managed object, not a native one.
---     scene:call(&quot;set_TimeScale&quot;, 5.0)
--- end
---@return any
local function sdk_call_native_func(object, type_definition, method_name, ...)
    local args = {...}
    return sdk.call_native_func(object, type_definition, method_name, args)
end

--- Return value is dependent on what the method returns.
--- Full function prototype can be passed as method_name if there are multiple functions with the same name but different parameters.
--- Alternative calling method:
--- managed_object:call(method_name, args...)
---@return any
local function sdk_call_object_func(managed_object, method_name, ...)
    local args = {...}
    return sdk.call_object_func(managed_object, method_name, args)
end

local function sdk_get_native_field(object, type_definition, field_name)
    return sdk.get_native_field(object, type_definition, field_name)
end

local function sdk_set_native_field(object, type_definition, field_name, value)
    sdk.set_native_field(object, type_definition, field_name, value)
end

--- Returns a REManagedObject*. Returns the current camera being used by the engine.
---@return REManagedObject|any (REManagedObject*)
local function sdk_get_primary_camera()
    return sdk.get_primary_camera()
end

--- Creates a hook for method_definition, intercepting all incoming calls the game makes to it.
--- ignore_jmp is false.
--- Using pre_function and post_function, the behavior of these functions can be modified.
--- NOTE: Some native methods may not be able to be hooked with this, e.g. if they are just a  wrapper over the native function. Some additional work will need to be done from our end to make those work.
--- pre_function and post_function looks like so:
--- local function pre_function(args)
---     -- args are modifiable
---     -- args[1] = thread_context
---     -- args[2] = &quot;this&quot;/object pointer
---     -- rest of args are the actual parameters
---     -- actual parameters start at args[2] in a static function
---     -- Some native functions will have the object start at args[1] and rest at args[2]
---     -- All args are void* and not auto-converted to their respective types.
---     -- You will need to do things like sdk.to_managed_object(args[2])
---     -- or sdk.to_int64(args[3]) to get arguments to better interact with or read.
---     -- if the argument is a ValueType, you need to do this to access its fields:
---     -- local type = sdk.find_type_definition(&quot;via.Position&quot;)
---     -- local x = sdk.get_native_field(arg[3], type, &quot;x&quot;)
---     -- OPTIONAL: Specify an sdk.PreHookResult
---     -- e.g.
---     -- return sdk.PreHookResult.SKIP_ORIGINAL -- prevents the original function from being called
---     -- return sdk.PreHookResult.CALL_ORIGINAL -- calls the original function, same as not returning anything
--- end
--- local function post_function(retval)
---     -- return something else if you don't want the original return value
---     -- NOTE: the post_function will still be called if SKIP_ORIGINAL is returned from the pre_function
---     -- So, if your function expects something valid in return, keep that in mind, as retval will not be valid.
---     -- Make sure to convert custom retvals to sdk.to_ptr(retval)
---     return retval
--- end
--- Example hook:
--- local function on_pre_get_timescale(args)
--- end
--- local function on_post_get_timescale(retval)
---     -- Make the game run 5 times as fast instead
---     -- TODO: Make it so casting return values like this is not necessary
---     return sdk.float_to_ptr(5.0)
--- end
--- sdk.hook(sdk.find_type_definition(&quot;via.Scene&quot;):get_method(&quot;get_TimeScale&quot;), on_pre_get_timescale, on_post_get_timescale)
---@param method_definition REMethodDefinition
---@param pre_func function
---@param post_func function
local function sdk_hook(method_definition, pre_func, post_func)
    sdk.hook(method_definition, pre_func, post_func, false)
end

---@param method_definition string
---@param pre_func function
---@param post_func function
---@param ignore_jmp boolean
local function sdk_hook_jmp(method_definition, pre_func, post_func, ignore_jmp)
    sdk.hook(method_definition, pre_func, post_func, ignore_jmp)
end


--- Similar to sdk.hook but hooks on a per-object basis instead, instead of hooking the function globally for all objects.
--- Only works if the target method is a virtual method.
---@param obj REManagedObject|any
---@param method string
---@param pre function
---@param post function
local function sdk_hook_vtable(obj, method, pre, post)
    sdk.hook_vtable(obj, method, pre, post)
end

--- Returns true if value is a valid REManagedObject.
--- Use only if necessary. Does a bunch of checks and calls IsBadReadPtr a lot.
---@param value any
---@return boolean
local function sdk_is_managed_object(value)
    return sdk.is_managed_object(value)
end

--- Attempts to convert value to an REManagedObject*.
--- value can be any of the following types:
--- An REManagedObject*, in which case it is returned as-is
--- A lua number convertible to uintptr_t, representing the object's address
--- A void*
--- Any other type will return nil.
--- A value that is not a valid REManagedObject* will return nil, equivalent to calling sdk.is_managed_object on it.
---@param value any
---@return REManagedObject|any (REManagedObject*)
local function sdk_to_managed_object(value)
    return sdk.to_managed_object(value)
end

--- Attempts to convert value to a double.
--- value can be any of the following types:
--- A void*
---@param value any
---@return number (double)
local function sdk_to_double(value)
    return sdk.to_double(value)
end

--- Attempts to convert value to a float.
--- value can be any of the following types:
--- A void*
---@param value any
---@return number (float)
local function sdk_to_float(value)
    return sdk.to_float(value)
end

--- Attempts to convert value to a int64.
--- value can be any of the following types:
--- A void*
--- If you need a smaller datatype, you can do:
--- (sdk.to_int64(value) &amp; 1) == 1 for a boolean
--- (sdk.to_int64(value) &amp; 0xFF) for an unsigned byte
--- (sdk.to_int64(value) &amp; 0xFFFF) for an unsigned short (2 bytes)
--- (sdk.to_int64(value) &amp; 0xFFFFFFFF) for an unsigned int (4 bytes)
---@param value any
---@return number (int64_t)
local function sdk_to_int64(value)
    return sdk.to_int64(value)
end

--- Attempts to convert value to a void*.
--- value can be any of the following types:
--- An REManagedObject*
--- A lua number convertible to int64_t
--- A lua number convertible to double
--- A lua boolean
--- A void*, in which case it is returned as-is
--- Any other type will return nil.
---@param value any
---@return any
local function sdk_to_ptr(value)
    return sdk.to_ptr(value)
end

--- Converts number to a void*.
--- Enums
---@param number number
---@return any
local function sdk_float_to_ptr(number)
    return sdk.float_to_ptr(number)
end

return {
    get_tdb_version = sdk_get_tdb_version,
    game_namespace = sdk_game_namespace,
    get_thread_context = sdk_get_thread_context,
    get_native_singleton = sdk_get_native_singleton,
    get_managed_singleton = sdk_get_managed_singleton,
    find_type_definition = sdk_find_type_definition,
    typeof = sdk_typeof,
    create_instance = sdk_create_instance,
    create_managed_string = sdk_create_managed_string,
    create_managed_array = sdk_create_managed_array,
    create_sbyte = sdk_create_sbyte,
    create_byte = sdk_create_byte,
    create_int16 = sdk_create_int16,
    create_uint16 = sdk_create_uint16,
    create_int32 = sdk_create_int32,
    create_uint32 = sdk_create_uint32,
    create_int64 = sdk_create_int64,
    create_uint64 = sdk_create_uint64,
    create_single = sdk_create_single,
    create_double = sdk_create_double,
    create_resource = sdk_create_resource,
    create_userdata = sdk_create_userdata,
    deserialize = sdk_deserialize,
    call_native_func = sdk_call_native_func,
    call_object_func = sdk_call_object_func,
    get_native_field = sdk_get_native_field,
    set_native_field = sdk_set_native_field,
    get_primary_camera = sdk_get_primary_camera,
    hook = sdk_hook,
    sdk_hook_jmp = sdk_hook_jmp,
    hook_vtable = sdk_hook_vtable,
    is_managed_object = sdk_is_managed_object,
    to_managed_object = sdk_to_managed_object,
    to_double = sdk_to_double,
    to_float = sdk_to_float,
    to_int64 = sdk_to_int64,
    to_ptr = sdk_to_ptr,
    float_to_ptr = sdk_float_to_ptr,
}
