using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSObjectRef.h
/// </summary>
public static unsafe partial class JSClass
{
    /// <summary>
    /// Creates a JavaScript class suitable for use with JSObjectMake.
    /// </summary>
    /// <param name="definition">A JSClassDefinition that defines the class.</param>
    /// <returns>A JSClass with the given definition. Ownership follows the Create Rule.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSClassCreate")]
    public static partial JSClassRef Create(JSClassDefinition* definition);

    /// <summary>
    /// Retains a JavaScript class.
    /// </summary>
    /// <param name="jsClass">The JSClass to retain.</param>
    /// <returns>A JSClass that is the same as jsClass.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSClassRetain")]
    public static partial JSClassRef Retain(JSClassRef jsClass);

    /// <summary>
    /// Releases a JavaScript class.
    /// </summary>
    /// <param name="jsClass">The JSClass to release.</param>
    /// <returns></returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSClassRelease")]
    public static partial void Release(JSClassRef jsClass);
}