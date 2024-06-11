using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSObjectRef.h
/// </summary>
public static unsafe partial class JSObject
{
    /// <summary>
    /// The callback invoked when an object is first created.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject being created.</param>
    /// <remarks>
    /// If you named your function Initialize, you would declare it like this:
    /// 
    /// <code>
    /// void Initialize(JSContextRef ctx, JSObjectRef @object);
    /// </code>
    /// 
    /// Unlike the other object callbacks, the initialize callback is called on the least
    /// derived class (the parent class) first, and the most derived class last.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void InitializeCallback(JSContextRef ctx, JSObjectRef @object);

    /// <summary>
    /// The callback invoked when an object is finalized (prepared for garbage collection). 
    /// An object may be finalized on any thread.
    /// </summary>
    /// <param name="@object">The JSObject being finalized.</param>
    /// <remarks>
    /// If you named your function Finalize, you would declare it like this:
    /// 
    /// <code>
    /// void Finalize(JSObjectRef @object);
    /// </code>
    /// 
    /// The finalize callback is called on the most derived class first, and the least 
    /// derived class (the parent class) last.
    /// 
    /// You must not call any function that may cause a garbage collection or an allocation
    /// of a garbage collected object from within a JSObjectFinalizeCallback. This includes
    /// all functions that have a JSContextRef parameter.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FinalizeCallback(JSObjectRef @object);

    /// <summary>
    /// The callback invoked when determining whether an object has a property.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="@object">The JSObject to search for the property.</param>
    /// <param name="propertyName">A JSString containing the name of the property look up.</param>
    /// <returns>True if object has the property, otherwise false.</returns>
    /// <remarks>
    /// If you named your function HasProperty, you would declare it like this:
    /// 
    /// <code>
    /// bool HasProperty(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName);
    /// </code>
    /// 
    /// If this function returns false, the hasProperty request forwards to object's statically declared properties, then its parent class chain (which includes the default object class), then its prototype chain.
    /// 
    /// This callback enables optimization in cases where only a property's existence needs to be known, not its value, and computing its value would be expensive.
    /// 
    /// If this callback is NULL, the getProperty callback will be used to service hasProperty requests.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool HasPropertyCallback(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName);

    /// <summary>
    /// The callback invoked when getting a property's value.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="@object">The JSObject to search for the property.</param>
    /// <param name="propertyName">A JSString containing the name of the property to get.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to return an exception, if any.</param>
    /// <returns>The property's value if object has the property, otherwise NULL.</returns>
    /// <remarks>
    /// If you named your function GetProperty, you would declare it like this:
    /// 
    /// <code>
    /// JSValueRef GetProperty(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName, JSValueRef* exception);
    /// </code>
    /// 
    /// If this function returns NULL, the get request forwards to object's statically declared properties, then its parent class chain (which includes the default object class), then its prototype chain.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate JSValueRef GetPropertyCallback(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName,
        JSValueRef* exception);

    /// <summary>
    /// The callback invoked when setting a property's value.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="@object">The JSObject on which to set the property's value.</param>
    /// <param name="propertyName">A JSString containing the name of the property to set.</param>
    /// <param name="value">A JSValue to use as the property's value.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to return an exception, if any.</param>
    /// <returns>True if the property was set, otherwise false.</returns>
    /// <remarks>
    /// If you named your function SetProperty, you would declare it like this:
    /// 
    /// <code>
    /// bool SetProperty(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName, JSValueRef value, JSValueRef* exception);
    /// </code>
    /// 
    /// If this function returns false, the set request forwards to object's statically declared properties, then its parent class chain (which includes the default object class).
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool SetPropertyCallback(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName,
        JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// The callback invoked when deleting a property.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="@object">The JSObject in which to delete the property.</param>
    /// <param name="propertyName">A JSString containing the name of the property to delete.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to return an exception, if any.</param>
    /// <returns>True if propertyName was successfully deleted, otherwise false.</returns>
    /// <remarks>
    /// If you named your function DeleteProperty, you would declare it like this:
    /// 
    /// <code>
    /// bool DeleteProperty(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName, JSValueRef* exception);
    /// </code>
    /// 
    /// If this function returns false, the delete request forwards to object's statically declared properties, then its parent class chain (which includes the default object class).
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool DeletePropertyCallback(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName,
        JSValueRef* exception);

    /// <summary>
    /// The callback invoked when collecting the names of an object's properties.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="@object">The JSObject whose property names are being collected.</param>
    /// <param name="propertyNames">A JavaScript property name accumulator in which to accumulate the names of object's properties.</param>
    /// <remarks>
    /// If you named your function GetPropertyNames, you would declare it like this:
    /// 
    /// <code>
    /// void GetPropertyNames(JSContextRef ctx, JSObjectRef @object, JSPropertyNameAccumulatorRef propertyNames);
    /// </code>
    /// 
    /// Property name accumulators are used by JSObjectCopyPropertyNames and JavaScript for...in loops.
    /// 
    /// Use JSPropertyNameAccumulatorAddName to add property names to accumulator. A class's getPropertyNames callback only needs to provide the names of properties that the class vends through a custom getProperty or setProperty callback. Other properties, including statically declared properties, properties vended by other classes, and properties belonging to object's prototype, are added independently.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void GetPropertyNamesCallback(JSContextRef ctx, JSObjectRef @object,
        JSStringRef propertyNames);

    /// <summary>
    /// The callback invoked when an object is called as a function.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="function">A JSObject that is the function being called.</param>
    /// <param name="thisObject">A JSObject that is the 'this' variable in the function's scope.</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of the arguments passed to the function.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to return an exception, if any.</param>
    /// <returns>A JSValue that is the function's return value.</returns>
    /// <remarks>
    /// If you named your function CallAsFunction, you would declare it like this:
    /// 
    /// <code>
    /// JSValueRef CallAsFunction(JSContextRef ctx, JSObjectRef function, JSObjectRef thisObject, int argumentCount, const JSValueRef arguments[], JSValueRef* exception);
    /// </code>
    /// 
    /// If your callback were invoked by the JavaScript expression 'myObject.myFunction()', function would be set to myFunction, and thisObject would be set to myObject.
    /// 
    /// If this callback is NULL, calling your object as a function will throw an exception.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate JSValueRef CallAsFunctionCallback(JSContextRef ctx, JSObjectRef function, JSObjectRef thisObject,
        int argumentCount, JSValueRef* arguments, JSValueRef* exception);

    /// <summary>
    /// The callback invoked when an object is used as a constructor in a 'new' expression.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="constructor">A JSObject that is the constructor being called.</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of the arguments passed to the function.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to return an exception, if any.</param>
    /// <returns>A JSObject that is the constructor's return value.</returns>
    /// <remarks>
    /// If you named your function CallAsConstructor, you would declare it like this:
    /// 
    /// <code>
    /// JSObjectRef CallAsConstructor(JSContextRef ctx, JSObjectRef constructor, int argumentCount, const JSValueRef arguments[], JSValueRef* exception);
    /// </code>
    /// 
    /// If your callback were invoked by the JavaScript expression 'new myConstructor()', constructor would be set to myConstructor.
    /// 
    /// If this callback is NULL, using your object as a constructor in a 'new' expression will throw an exception.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate JSObjectRef CallAsConstructorCallback(JSContextRef ctx, JSObjectRef constructor,
        int argumentCount, JSValueRef* arguments, JSValueRef* exception);

    /// <summary>
    /// The callback invoked when an object is used as the target of an 'instanceof' expression.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="constructor">The JSObject that is the target of the 'instanceof' expression.</param>
    /// <param name="possibleInstance">The JSValue being tested to determine if it is an instance of constructor.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to return an exception, if any.</param>
    /// <returns>True if possibleInstance is an instance of constructor, otherwise false.</returns>
    /// <remarks>
    /// If you named your function HasInstance, you would declare it like this:
    /// 
    /// <code>
    /// bool HasInstance(JSContextRef ctx, JSObjectRef constructor, JSValueRef possibleInstance, JSValueRef* exception);
    /// </code>
    /// 
    /// If your callback were invoked by the JavaScript expression 'someValue instanceof myObject', constructor would be set to myObject and possibleInstance would be set to someValue.
    /// 
    /// If this callback is NULL, 'instanceof' expressions that target your object will return false.
    /// 
    /// Standard JavaScript practice calls for objects that implement the callAsConstructor callback to implement the hasInstance callback as well.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool HasInstanceCallback(JSContextRef ctx, JSObjectRef constructor, JSValueRef possibleInstance,
        JSValueRef* exception);

    /// <summary>
    /// The callback invoked when converting an object to a particular JavaScript type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="@object">The JSObject to convert.</param>
    /// <param name="type">A JSType specifying the JavaScript type to convert to.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to return an exception, if any.</param>
    /// <returns>The object's converted value, or NULL if the object was not converted.</returns>
    /// <remarks>
    /// If you named your function ConvertToType, you would declare it like this:
    /// 
    /// <code>
    /// JSValueRef ConvertToType(JSContextRef ctx, JSObjectRef @object, JSType type, JSValueRef* exception);
    /// </code>
    /// 
    /// If this function returns false, the conversion request forwards to object's parent class chain (which includes the default object class).
    /// 
    /// This function is only invoked when converting an object to number or string. An object converted to boolean is 'true.' An object converted to object is itself.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate JSValueRef ConvertToTypeCallback(JSContextRef ctx, JSObjectRef @object, JSType type,
        JSValueRef* exception);

    /// <summary>
    /// A JSClassDefinition structure of the current version, filled with NULL pointers and having no attributes.
    /// </summary>
    public static readonly JSClassDefinition JSClassDefinitionEmpty = new();
    
    /// <summary>
    /// Creates a JavaScript object.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="jsClass">The JSClass to assign to the object. Pass NULL to use the default object class.</param>
    /// <param name="data">A void* to set as the object's private data. Pass NULL to specify no private data.</param>
    /// <returns>A JSObject with the given class and private data.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMake")]
    public static partial JSObjectRef Make(JSContextRef ctx, JSClassRef jsClass, void* data);

    /// <summary>
    /// Convenience method for creating a JavaScript function with a given callback as its implementation.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="name">A JSString containing the function's name. This will be used when converting the function to string. Pass NULL to create an anonymous function.</param>
    /// <param name="callAsFunction">The JSObjectCallAsFunctionCallback to invoke when the function is called.</param>
    /// <returns>A JSObject that is a function. The object's prototype will be the default function prototype.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeFunctionWithCallback")]
    public static partial JSObjectRef MakeFunctionWithCallback(JSContextRef ctx, JSStringRef name,
        CallAsFunctionCallback callAsFunction);

    /// <summary>
    /// Convenience method for creating a JavaScript constructor.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="jsClass">A JSClass that is the class your constructor will assign to the objects its constructs. jsClass will be used to set the constructor's .prototype property, and to evaluate 'instanceof' expressions. Pass NULL to use the default object class.</param>
    /// <param name="callAsConstructor">A JSObjectCallAsConstructorCallback to invoke when your constructor is used in a 'new' expression. Pass NULL to use the default object constructor.</param>
    /// <returns>A JSObject that is a constructor. The object's prototype will be the default object prototype.
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "MakeConstructor")]
    public static partial JSObjectRef MakeConstructor(JSContextRef ctx, JSClassRef jsClass,
        CallAsConstructorCallback callAsConstructor);

    /// <summary>
    /// Creates a JavaScript Array object.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of data to populate the Array with. Pass NULL if argumentCount is 0.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A JSObject that is an Array.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeArray")]
    public static partial JSObjectRef MakeArray(JSContextRef ctx, int argumentCount, JSValueRef* arguments,
        JSValueRef* exception);

    /// <summary>
    /// Creates a JavaScript Date object, as if by invoking the built-in Date constructor.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of arguments to pass to the Date Constructor. Pass NULL if argumentCount is 0.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A JSObject that is a Date.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeDate")]
    public static partial JSObjectRef MakeDate(JSContextRef ctx, int argumentCount, JSValueRef* arguments,
        JSValueRef* exception);

    /// <summary>
    /// Creates a JavaScript Error object, as if by invoking the built-in Error constructor.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of arguments to pass to the Error Constructor. Pass NULL if argumentCount is 0.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A JSObject that is an Error.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeError")]
    public static partial JSObjectRef MakeError(JSContextRef ctx, int argumentCount, JSValueRef* arguments,
        JSValueRef* exception);

    /// <summary>
    /// Creates a JavaScript RegExp object, as if by invoking the built-in RegExp constructor.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of arguments to pass to the RegExp Constructor. Pass NULL if argumentCount is 0.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A JSObject that is a RegExp.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeRegExp")]
    public static partial JSObjectRef MakeRegExp(JSContextRef ctx, int argumentCount, JSValueRef* arguments,
        JSValueRef* exception);

    /// <summary>
    /// Creates a JavaScript promise object by invoking the provided executor.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="resolve">A pointer to a JSObjectRef in which to store the resolve function for the new promise. Pass NULL if you do not care to store the resolve callback.</param>
    /// <param name="reject">A pointer to a JSObjectRef in which to store the reject function for the new promise. Pass NULL if you do not care to store the reject callback.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A JSObject that is a promise or NULL if an exception occurred.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeDeferredPromise")]
    public static partial JSObjectRef MakeDeferredPromise(JSContextRef ctx, JSObjectRef* resolve,
        JSObjectRef* reject, JSValueRef* exception);

    /// <summary>
    /// Creates a function with a given script as its body.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="name">A JSString containing the function's name. This will be used when converting the function to string. Pass NULL to create an anonymous function.</param>
    /// <param name="parameterCount">An integer count of the number of parameter names in parameterNames.</param>
    /// <param name="parameterNames">A JSString array containing the names of the function's parameters. Pass NULL if parameterCount is 0.</param>
    /// <param name="body">A JSString containing the script to use as the function's body.</param>
    /// <param name="sourceURL">A JSString containing a URL for the script's source file. This is only used when reporting exceptions. Pass NULL if you do not care to include source file information in exceptions.</param>
    /// <param name="startingLineNumber">An integer value specifying the script's starting line number in the file located at sourceURL. This is only used when reporting exceptions. The value is one-based, so the first line is line 1 and invalid values are clamped to 1.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store a syntax error exception, if any. Pass NULL if you do not care to store a syntax error exception.</param>
    /// <returns>A JSObject that is a function, or NULL if either body or parameterNames contains a syntax error. The object's prototype will be the default function prototype.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeFunction")]
    public static partial JSObjectRef MakeFunction(JSContextRef ctx, JSStringRef name, uint parameterCount,
        JSStringRef* parameterNames, JSStringRef body, JSStringRef sourceURL, int startingLineNumber,
        JSValueRef* exception);

    /// <summary>
    /// Gets an object's prototype.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">A JSObject whose prototype you want to get.</param>
    /// <returns>A JSValue that is the object's prototype.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetPrototype")]
    public static partial JSValueRef GetPrototype(JSContextRef ctx, JSObjectRef @object);

    /// <summary>
    /// Sets an object's prototype.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose prototype you want to set.</param>
    /// <param name="value">A JSValue to set as the object's prototype.</param>
    /// <returns></returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectSetPrototype")]
    public static partial void SetPrototype(JSContextRef ctx, JSObjectRef @object, JSValueRef value);

    /// <summary>
    /// Tests whether an object has a given property.
    /// </summary>
    /// <param name="object">The JSObject to test.</param>
    /// <param name="propertyName">A JSString containing the property's name.</param>
    /// <returns>true if the object has a property whose name matches propertyName, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectHasProperty")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool HasProperty(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName);

    /// <summary>
    /// Gets a property from an object.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to get.</param>
    /// <param name="propertyName">A JSString containing the property's name.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The property's value if object has the property, otherwise the undefined value.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetProperty")]
    public static partial JSValueRef GetProperty(JSContextRef ctx, JSObjectRef @object,
        JSStringRef propertyName, JSValueRef* exception);

    /// <summary>
    /// Sets a property on an object.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to set.</param>
    /// <param name="propertyName">A JSString containing the property's name.</param>
    /// <param name="value">A JSValueRef to use as the property's value.</param>
    /// <param name="attributes">A logically ORed set of JSPropertyAttributes to give to the property.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns></returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectSetProperty")]
    public static partial void SetProperty(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName,
        JSValueRef value, JSPropertyAttributes attributes, JSValueRef* exception);

    /// <summary>
    /// Deletes a property from an object.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to delete.</param>
    /// <param name="propertyName">A JSString containing the property's name.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>true if the delete operation succeeds, otherwise false (for example, if the property has the kJSPropertyAttributeDontDelete attribute set).</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectDeleteProperty")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool DeleteProperty(JSContextRef ctx, JSObjectRef @object, JSStringRef propertyName,
        JSValueRef* exception);

    /// <summary>
    /// Tests whether an object has a given property using a JSValueRef as the property key.
    /// </summary>
    /// <param name="object">The JSObject to test.</param>
    /// <param name="propertyKey">A JSValueRef containing the property key to use when looking up the property.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>true if the object has a property whose name matches propertyKey, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectHasPropertyForKey")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool HasPropertyForKey(JSContextRef ctx, JSObjectRef @object, JSValueRef propertyKey,
        JSValueRef* exception);

    /// <summary>
    /// Gets a property from an object using a JSValueRef as the property key.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to get.</param>
    /// <param name="propertyKey">A JSValueRef containing the property key to use when looking up the property.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The property's value if object has the property key, otherwise the undefined value.
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetPropertyForKey")]
    public static partial JSValueRef GetPropertyForKey(JSContextRef ctx, JSObjectRef @object,
        JSValueRef propertyKey, JSValueRef* exception);

    /// <summary>
    /// Sets a property on an object using a JSValueRef as the property key.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to set.</param>
    /// <param name="propertyKey">A JSValueRef containing the property key to use when looking up the property.</param>
    /// <param name="value">A JSValueRef to use as the property's value.</param>
    /// <param name="attributes">A logically ORed set of JSPropertyAttributes to give to the property.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns></returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectSetPropertyForKey")]
    public static partial void SetPropertyForKey(JSContextRef ctx, JSObjectRef @object, JSValueRef propertyKey,
        JSValueRef value, JSPropertyAttributes attributes, JSValueRef* exception);

    /// <summary>
    /// Deletes a property from an object using a JSValueRef as the property key.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to delete.</param>
    /// <param name="propertyKey">A JSValueRef containing the property key to use when looking up the property.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>true if the delete operation succeeds, otherwise false (for example, if the property has the kJSPropertyAttributeDontDelete attribute set).
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectDeletePropertyForKey")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool DeletePropertyForKey(JSContextRef ctx, JSObjectRef @object,
        JSValueRef propertyKey, JSValueRef* exception);

    /// <summary>
    /// Gets a property from an object by numeric index.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to get.</param>
    /// <param name="propertyIndex">An integer value that is the property's name.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The property's value if object has the property, otherwise the undefined value.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetPropertyAtIndex")]
    public static partial JSValueRef GetPropertyAtIndex(JSContextRef ctx, JSObjectRef @object,
        uint propertyIndex, JSValueRef* exception);

    /// <summary>
    /// Sets a property on an object by numeric index.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject whose property you want to set.</param>
    /// <param name="propertyIndex">The property's name as a number.</param>
    /// <param name="value">A JSValue to use as the property's value.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns></returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectSetPropertyAtIndex")]
    public static partial void SetPropertyAtIndex(JSContextRef ctx, JSObjectRef @object, uint propertyIndex,
        JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// Gets an object's private data.
    /// </summary>
    /// <param name="object">A JSObject whose private data you want to get.</param>
    /// <returns>A void* that is the object's private data, if the object has private data, otherwise NULL.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetPrivate")]
    public static partial void* GetPrivate(JSObjectRef @object);

    /// <summary>
    /// Sets a pointer to private data on an object.
    /// </summary>
    /// <param name="object">The JSObject whose private data you want to set.</param>
    /// <param name="data">A void* to set as the object's private data.</param>
    /// <returns>true if object can store private data, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectSetPrivate")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool SetPrivate(JSObjectRef @object, void* data);

    /// <summary>
    /// Tests whether an object can be called as a function.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject to test.</param>
    /// <returns>true if the object can be called as a function, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectIsFunction")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool IsFunction(JSContextRef ctx, JSObjectRef @object);

    /// <summary>
    /// Calls an object as a function.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject to call as a function.</param>
    /// <param name="thisObject">The object to use as "this," or NULL to use the global object as "this."</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of arguments to pass to the function. Pass NULL if argumentCount is 0.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The JSValue that results from calling object as a function, or NULL if an exception is thrown or object is not a function.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectCallAsFunction")]
    public static partial JSValueRef CallAsFunction(JSContextRef ctx, JSObjectRef @object,
        JSObjectRef thisObject, int argumentCount, JSValueRef* arguments, JSValueRef* exception);

    /// <summary>
    /// Tests whether an object can be called as a constructor.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject to test.</param>
    /// <returns>true if the object can be called as a constructor, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectIsConstructor")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool IsConstructor(JSContextRef ctx, JSObjectRef @object);

    /// <summary>
    /// Calls an object as a constructor.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The JSObject to call as a constructor.</param>
    /// <param name="argumentCount">An integer count of the number of arguments in arguments.</param>
    /// <param name="arguments">A JSValue array of arguments to pass to the constructor. Pass NULL if argumentCount is 0.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The JSObject that results from calling object as a constructor, or NULL if an exception is thrown or object is not a constructor.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectCallAsConstructor")]
    public static partial JSObjectRef CallAsConstructor(JSContextRef ctx, JSObjectRef @object,
        int argumentCount, JSValueRef* arguments, JSValueRef* exception);

    /// <summary>
    /// Gets the names of an object's enumerable properties.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="object">The object whose property names you want to get.</param>
    /// <returns>A JSPropertyNameArray containing the names object's enumerable properties. Ownership follows the Create Rule.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectCopyPropertyNames")]
    public static partial JSPropertyNameArrayRef CopyPropertyNames(JSContextRef ctx, JSObjectRef @object);
}

/// <summary>
/// JSPropertyAttribute
/// </summary>
/// <para>kJSPropertyAttributeNone: Specifies that a property has no special attributes.</para>
/// <para>kJSPropertyAttributeReadOnly: Specifies that a property is read-only.</para>
/// /// <para>kJSPropertyAttributeDontEnum: Specifies that a property should not be enumerated by JSPropertyEnumerators and JavaScript for...in loops.</para>
/// <para>kJSPropertyAttributeDontDelete: Specifies that the delete operation should fail on a property.</para>
public enum JSPropertyAttributes
{
    None = 0,
    ReadOnly = 1 << 1,
    DontEnum = 1 << 2,
    DontDelete = 1 << 3
};

/// <summary>
/// JSClassAttribute
/// </summary>
/// <para>kJSClassAttributeNone: Specifies that a class has no special attributes.</para>
/// <para>
/// kJSClassAttributeNoAutomaticPrototype: Specifies that a class should not automatically generate a shared prototype
/// for its instance objects. Use kJSClassAttributeNoAutomaticPrototype in combination with JSObjectSetPrototype to
/// manage prototypes manually.
/// </para>
public enum JSClassAttributes
{
    None = 0,
    NoAutomaticPrototype = 1 << 1
}

/// <summary>
/// This structure describes a statically declared value property.
/// </summary>
/// <para>name: A null-terminated UTF8 string containing the property's name.</para>
/// <para>getProperty: A JSObjectGetPropertyCallback to invoke when getting the property's value.</para>
/// <para>setProperty: A JSObjectSetPropertyCallback to invoke when setting the property's value. May be NULL if the ReadOnly attribute is set.</para>
/// <para>attributes: A logically ORed set of JSPropertyAttributes to give to the property.</para>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSStaticValue
{
    public char* Name;
    public JSObject.GetPropertyCallback GetProperty;
    public JSObject.SetPropertyCallback SetProperty;
    public JSPropertyAttributes Attributes;
}

/// <summary>
/// This structure describes a statically declared function property.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSStaticFunction
{
    /// <summary>
    /// A null-terminated UTF8 string containing the property's name.
    /// </summary>
    public char* Name;

    /// <summary>
    /// A JSObjectCallAsFunctionCallback to invoke when the property is called as a function.
    /// </summary>
    public JSObject.CallAsFunctionCallback CallAsFunction;

    /// <summary>
    /// A logically ORed set of JSPropertyAttributes to give to the property.
    /// </summary>
    public JSPropertyAttributes Attributes;
}

/// <summary>
/// This structure contains properties and callbacks that define a type of object. 
/// All fields other than the version field are optional. Any pointer may be NULL.
///
/// If you named your getter function "GetX" and your setter function "SetX",
/// you would declare a JSStaticValue array containing "X" like this:
/// <code>
/// JSStaticValue StaticValueArray[] = {
///     { "X", GetX, SetX, kJSPropertyAttributeNone },
///     { 0, 0, 0, 0 }
/// };
/// </code>
/// Standard JavaScript practice calls for storing function objects in prototypes, so they can be shared.
/// The default JSClass created by JSClassCreate follows this idiom, instantiating objects with a shared
/// automatically generating prototype containing the class's function objects.
/// The kJSClassAttributeNoAutomaticPrototype attribute specifies that a JSClass should not automatically
/// generate such a prototype. The resulting JSClass instantiates objects with the default object prototype,
/// and gives each instance object its own copy of the class's function objects.
///
/// A NULL callback specifies that the default object callback should substitute, except in the case
/// of hasProperty, where it specifies that getProperty should substitute.
/// It is not possible to use JS subclassing with objects created from a class definition that sets
/// callAsConstructor by default. Subclassing is supported via the JSObjectMakeConstructor function, however.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSClassDefinition
{
    /// <summary>
    /// The version number of this structure. The current version is 0.
    /// </summary>
    public int Version; /* current (and only) version is 0 */

    /// <summary>
    /// A logically ORed set of JSClassAttributes to give to the class.
    /// </summary>
    public JSClassAttributes Attributes;

    /// <summary>
    /// A null-terminated UTF8 string containing the class's name.
    /// </summary>
    public /*const*/ char* ClassName;

    /// <summary>
    /// A JSClass to set as the class's parent class. Pass NULL to use the default object class.
    /// </summary>
    public JSClassRef ParentClass;

    /// <summary>
    /// A JSStaticValue array containing the class's statically declared value properties. 
    /// Pass NULL to specify no statically declared value properties. 
    /// The array must be terminated by a JSStaticValue whose name field is NULL.
    /// </summary>
    public /*const*/ JSStaticValue* StaticValues;

    /// <summary>
    /// A JSStaticFunction array containing the class's statically declared function properties. 
    /// Pass NULL to specify no statically declared function properties. 
    /// The array must be terminated by a JSStaticFunction whose name field is NULL.
    /// </summary>
    public /*const*/ JSStaticFunction* StaticFunctions;

    /// <summary>
    /// The callback invoked when an object is first created. Use this callback to initialize the object.
    /// </summary>
    public JSObject.InitializeCallback Initialize;

    /// <summary>
    /// The callback invoked when an object is finalized (prepared for garbage collection). 
    /// Use this callback to release resources allocated for the object, and perform other cleanup.
    /// </summary>
    public JSObject.FinalizeCallback Finalize;

    /// <summary>
    /// The callback invoked when determining whether an object has a property. 
    /// If this field is NULL, getProperty is called instead. 
    /// The hasProperty callback enables optimization in cases where only a property's existence needs to be known, 
    /// not its value, and computing its value is expensive.
    /// </summary>
    public JSObject.HasPropertyCallback HasProperty;

    /// <summary>
    /// The callback invoked when getting a property's value.
    /// </summary>
    public JSObject.GetPropertyCallback GetProperty;

    /// <summary>
    /// The callback invoked when setting a property's value.
    /// </summary>
    public JSObject.SetPropertyCallback SetProperty;

    /// <summary>
    /// The callback invoked when deleting a property.
    /// </summary>
    public JSObject.DeletePropertyCallback DeleteProperty;

    /// <summary>
    /// The callback invoked when collecting the names of an object's properties.
    /// </summary>
    public JSObject.GetPropertyNamesCallback GetPropertyNames;

    /// <summary>
    /// The callback invoked when an object is called as a function.
    /// </summary>
    public JSObject.CallAsFunctionCallback CallAsFunction;

    /// <summary>
    /// The callback invoked when an object is used as the target of an 'instanceof' expression.
    /// </summary>
    public JSObject.HasInstanceCallback HasInstance;

    /// <summary>
    /// The callback invoked when an object is used as a constructor in a 'new' expression.
    /// </summary>
    public JSObject.CallAsConstructorCallback CallAsConstructor;

    /// <summary>
    /// The callback invoked when converting an object to a particular JavaScript type.
    /// </summary>
    public JSObject.ConvertToTypeCallback ConvertToType;
}
