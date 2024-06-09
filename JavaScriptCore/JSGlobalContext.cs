using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSContextRef.h
/// </summary>
public static unsafe partial class JSGlobalContext
{
    /// <summary>
    /// Creates a global JavaScript execution context.
    /// JSGlobalContextCreate allocates a global object and populates it with all the
    /// built-in JavaScript objects, such as Object, Function, String, and Array.
    ///
    /// In WebKit version 4.0 and later, the context is created in a unique context group.
    /// Therefore, scripts may execute in it concurrently with scripts executing in other contexts.
    /// However, you may not use values created in the context in other contexts.
    /// </summary>
    /// <param name="globalObjectClass">The class to use when creating the global object. Pass NULL to use the default object class.</param>
    /// <returns>A JSGlobalContext with a global object of class globalObjectClass.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextCreate")]
    public static partial JSGlobalContextRef Create(JSClassRef* globalObjectClass);

    /// <summary>
    /// Creates a global JavaScript execution context in the context group provided.
    /// JSGlobalContextCreateInGroup allocates a global object and populates it with
    /// all the built-in JavaScript objects, such as Object, Function, String, and Array.
    /// </summary>
    /// <param name="globalObjectClass">The class to use when creating the global object. Pass NULL to use the default object class.</param>
    /// <param name="group">The context group to use. The created global context retains the group. Pass NULL to create a unique group for the context.</param>
    /// <returns>A JSGlobalContext with a global object of class globalObjectClass and a context group equal to group.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextCreateInGroup")]
    public static partial JSGlobalContextRef CreateInGroup(JSContextGroupRef group,
        JSClassRef globalObjectClass);

    /// <summary>
    /// Retains a global JavaScript execution context.
    /// </summary>
    /// <param name="ctx">The JSGlobalContext to retain.</param>
    /// <returns>A JSGlobalContext that is the same as ctx.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextRetain")]
    public static partial JSGlobalContextRef Retain(JSGlobalContextRef ctx);

    /// <summary>
    /// Releases a global JavaScript execution context.
    /// </summary>
    /// <param name="ctx">The JSGlobalContext to release.</param>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextRelease")]
    public static partial void Release(JSGlobalContextRef ctx);

    /// <summary>
    /// Gets a copy of the name of a context.
    /// </summary>
    /// <param name="ctx">The JSGlobalContext whose name you want to get.</param>
    /// <returns>The name for ctx.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextCopyName")]
    public static partial JSStringRef CopyName(JSGlobalContextRef ctx);
    
    
    /// <summary>
    /// Sets the name exposed when inspecting a context.
    /// </summary>
    /// <param name="ctx">The JSGlobalContext that you want to name.</param>
    /// <param name="name">The name to set on the context.</param>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextSetName")]
    public static partial void SetName(JSGlobalContextRef ctx, JSStringRef name);

    /// <summary>
    /// Gets whether the context is inspectable in Web Inspector.
    /// </summary>
    /// <param name="ctx">The JSGlobalContext that you want to change the inspectability of.</param>
    /// <returns>Whether the context is inspectable in Web Inspector.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextIsInspectable")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool IsInspectable(JSGlobalContextRef ctx);

    /// <summary>
    /// Sets whether the context is inspectable in Web Inspector. Default value is NO.
    /// </summary>
    /// <param name="ctx">The JSGlobalContext that you want to change the inspectability of.</param>
    /// <param name="inspectable">YES to allow Web Inspector to connect to the context, otherwise NO.</param>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGlobalContextSetInspectable")]
    public static partial void SetInspectable(JSGlobalContextRef ctx, [MarshalAs(UnmanagedType.U1)] bool inspectable);
}