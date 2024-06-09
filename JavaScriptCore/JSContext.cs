using System;
using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSContextRef.h
/// </summary>
public static partial class JSContext
{
    /// <summary>
    /// Gets the global object of a JavaScript execution context.
    /// </summary>
    /// <param name="ctx">The JSContext whose global object you want to get.</param>
    /// <returns>ctx's global object.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSContextGetGlobalObject")]
    public static partial JSObjectRef GetGlobalObject(IJSContextRef ctx);

    /// <summary>
    /// Gets the context group to which a JavaScript execution context belongs.
    /// </summary>
    /// <param name="ctx">The JSContext whose group you want to get.</param>
    /// <returns>ctx's group.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSContextGetGroup")]
    public static partial JSContextGroupRef GetGroup(JSContextRef ctx);

    /// <summary>
    /// Gets the global context of a JavaScript execution context.
    /// </summary>
    /// <param name="ctx">The JSContext whose global context you want to get.</param>
    /// <returns>ctx's global context.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSContextGetGlobalContext")]
    public static partial JSGlobalContextRef GetGlobalContext(JSContextRef ctx);
}