using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSObjectRef.h
/// </summary>
public static partial class JSPropertyNameArray
{
    /// <summary>
    /// Retains a JavaScript property name array.
    /// </summary>
    /// <param name="array">The JSPropertyNameArray to retain.</param>
    /// <returns>A JSPropertyNameArray that is the same as array.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSPropertyNameArrayRetain")]
    public static partial JSPropertyNameArrayRef Retain(JSPropertyNameArrayRef array);

    /// <summary>
    /// Releases a JavaScript property name array.
    /// </summary>
    /// <param name="array">The JSPropertyNameArray to release.</param>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSPropertyNameArrayRelease")]
    public static partial void Release(JSPropertyNameArrayRef array);

    /// <summary>
    /// Gets a count of the number of items in a JavaScript property name array.
    /// </summary>
    /// <param name="array">The array from which to retrieve the count.</param>
    /// <returns>An integer count of the number of names in array.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSPropertyNameArrayGetCount")]
    public static partial int GetCount(JSPropertyNameArrayRef array);

    /// <summary>
    /// Gets a property name at a given index in a JavaScript property name array.
    /// </summary>
    /// <param name="array">The array from which to retrieve the property name.</param>
    /// <param name="index">The index of the property name to retrieve.</param>
    /// <returns>A JSStringRef containing the property name.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSPropertyNameArrayGetNameAtIndex")]
    public static partial JSStringRef GetNameAtIndex(JSPropertyNameArrayRef array, int index);
}