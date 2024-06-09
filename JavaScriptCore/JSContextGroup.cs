using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSContextRef.h
/// </summary>
public static partial class JSContextGroup
{
    /// <summary>
    /// Creates a JavaScript context group.
    /// A JSContextGroup associates JavaScript contexts with one another.
    /// Contexts in the same group may share and exchange JavaScript objects. Sharing and/or exchanging
    /// JavaScript objects between contexts in different groups will produce undefined behavior.
    /// When objects from the same context group are used in multiple threads, explicit
    /// synchronization is required.
    /// 
    /// A JSContextGroup may need to run deferred tasks on a run loop, such as garbage collection
    /// or resolving WebAssembly compilations. By default, calling JSContextGroupCreate will use
    /// the run loop of the thread it was called on. Currently, there is no API to change a
    /// JSContextGroup's run loop once it has been created.
    /// </summary>
    /// <returns>The created JSContextGroup.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSContextGroupCreate")]
    public static partial JSContextGroupRef Create();

    /// <summary>
    /// Retains a JavaScript context group.
    /// </summary>
    /// <param name="group">The JSContextGroup to retain.</param>
    /// <returns>A JSContextGroup that is the same as group.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSContextGroupRetain")]
    public static partial JSContextGroupRef Retain(JSContextGroupRef group);

    /// <summary>
    /// Releases a JavaScript context group.
    /// </summary>
    /// <param name="group">The JSContextGroup to release.</param>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSContextGroupRelease")]
    public static partial void Release(JSContextGroupRef group);
}