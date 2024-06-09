using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSObjectRef.h
/// </summary>
public static partial class JSPropertyNameAccumumulator
{
    /// <summary>
    /// Adds a property name to a JavaScript property name accumulator.
    /// </summary>
    /// <param name="accumulator">The accumulator object to which to add the property name.</param>
    /// <param name="propertyName">The property name to add.</param>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSPropertyNameAccumulatorAddName")]
    public static partial void AddName(JSPropertyNameAccumulatorRef accumulator,
        JSStringRef propertyName);
}