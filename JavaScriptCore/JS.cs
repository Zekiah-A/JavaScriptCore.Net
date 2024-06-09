﻿using System;
using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSBase.h
/// </summary>
public static unsafe partial class JS
{
    // Script Evaluation
    /// <summary>
    /// Evaluates a string of JavaScript.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="script">A JSString containing the script to evaluate.</param>
    /// <param name="thisObject">The object to use as "this," or NULL to use the global object as "this."</param>
    /// <param name="sourceURL">A JSString containing a URL for the script's source file. This is used by debuggers and when reporting exceptions. Pass NULL if you do not care to include source file information.</param>
    /// <param name="startingLineNumber">An integer value specifying the script's starting line number in the file located at sourceURL. This is only used when reporting exceptions. The value is one-based, so the first line is line 1 and invalid values are clamped to 1.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The JSValue that results from evaluating script, or NULL if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSEvaluateScript")]
    public static partial JSValueRef EvaluateScript(IJSContextRef ctx, JSStringRef script, JSObjectRef? thisObject,
        JSStringRef? sourceURL, int startingLineNumber, JSValueRef* exception);

    /// <summary>
    /// Checks for syntax errors in a string of JavaScript.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="script">A JSString containing the script to check for syntax errors.</param>
    /// <param name="sourceURL">A JSString containing a URL for the script's source file. This is only used when reporting exceptions. Pass NULL if you do not care to include source file information in exceptions.</param>
    /// <param name="startingLineNumber">An integer value specifying the script's starting line number in the file located at sourceURL. This is only used when reporting exceptions. The value is one-based, so the first line is line 1 and invalid values are clamped to 1.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store a syntax error exception, if any. Pass NULL if you do not care to store a syntax error exception.</param>
    /// <returns>true if the script is syntactically correct, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSCheckScriptSyntax")]
    public static partial bool CheckScriptSyntax(IJSContextRef ctx, JSStringRef script, JSStringRef sourceURL,
        int startingLineNumber, JSValueRef* exception);

    /// <summary>
    /// Performs a JavaScript garbage collection.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <remarks>
    /// JavaScript values that are on the machine stack, in a register, protected by JSValueProtect, set as the global object of an execution context, or reachable from any such value will not be collected.
    /// During JavaScript execution, you are not required to call this function; the JavaScript engine will garbage collect as needed. JavaScript values created within a context group are automatically destroyed when the last reference to the context group is released.
    /// </remarks>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSGarbageCollect")]
    public static partial void GarbageCollect(JSContextRef ctx);
}

// JavaScript engine interface

/// <summary>
/// A group that associates JavaScript contexts with one another. Contexts in the same group may share and exchange JavaScript objects.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSContextGroupRef
{
    // OpaqueJSContextGroup*
    private IntPtr ptr;
}

/// <summary>
/// Out-of-library: Allows us to fake "sameness" of JSGlobalContext and JSContextRef within C#, see
/// https://developer.apple.com/documentation/javascriptcore/jsglobalcontextref#Discussion
/// </summary>
public interface IJSContextRef { }

/// <summary>
/// A JavaScript execution context. Holds the global object and other execution state.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSContextRef : IJSContextRef
{
    // OpaqueJSContext*
    private IntPtr ptr;
}

/// <summary>
/// A global JavaScript execution context. A JSGlobalContext is a JSContext
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSGlobalContextRef : IJSContextRef
{
    // OpaqueJSContext*
    private IntPtr ptr;
}

/// <summary>
/// A UTF16 character buffer. The fundamental string representation in JavaScript.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSStringRef
{
    // OpaqueJSString*
    private IntPtr ptr;
}

/// <summary>
/// A JavaScript class. Used with JSObjectMake to construct objects with custom behavior.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSClassRef
{
    // OpaqueJSClass*
    private IntPtr ptr;
}

/// <summary>
/// An array of JavaScript property names.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSPropertyNameArrayRef
{
    // OpaqueJSPropertyNameArray*
    private IntPtr ptr;
}

/// <summary>
/// An ordered set used to collect the names of a JavaScript object's properties.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSPropertyNameAccumulatorRef
{
    // OpaqueJSPropertyNameAccumulator*
    private IntPtr ptr;
}

/// <summary>
/// A function used to deallocate bytes passed to a Typed Array constructor.
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void JSTypedArrayBytesDeallocator(IntPtr bytes, IntPtr deallocatorContext);

// JavaScript data types

/// <summary>
/// A JavaScript value. The base type for all JavaScript values, and polymorphic functions on them.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSValueRef
{
    private IntPtr ptr;
}

/// <summary>
/// A JavaScript object. A JSObject is a JSValue.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct JSObjectRef
{
    private IntPtr ptr;
}