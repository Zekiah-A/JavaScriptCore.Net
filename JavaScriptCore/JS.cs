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
    public static partial JSValueRef EvaluateScript(JSContextRef ctx, JSStringRef script, JSObjectRef* thisObject,
        JSStringRef* sourceURL, int startingLineNumber, JSValueRef* exception);

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
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool CheckScriptSyntax(JSContextRef ctx, JSStringRef script, JSStringRef sourceURL,
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
public unsafe struct JSContextGroupRef : IEquatable<JSContextGroupRef>
{
    // OpaqueJSContextGroup*
    private void* ptr;
    public static readonly JSContextGroupRef Null = new JSContextGroupRef();

    public bool Equals(JSContextGroupRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSContextGroupRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// A JavaScript execution context. Holds the global object and other execution state.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSContextRef : IEquatable<JSContextRef>
{
    // OpaqueJSContext*
    private void* ptr;
    public static readonly JSContextRef Null = new JSContextRef();

    public bool Equals(JSContextRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSContextRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// A global JavaScript execution context. A JSGlobalContext is a JSContext.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSGlobalContextRef : IEquatable<JSGlobalContextRef>
{
    // OpaqueJSContext*
    private void* ptr;
    public static readonly JSGlobalContextRef Null = new JSGlobalContextRef();
    
    // A JSGlobalContext is a JSContext, therefore we can fake their "inheritance" with some funny implicit casting
    // using pointer hacks.
    public static implicit operator JSContextRef(JSGlobalContextRef objectRef)
    {
        return *(JSContextRef*)&objectRef;
    }

    public bool Equals(JSGlobalContextRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSGlobalContextRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// A UTF16 character buffer. The fundamental string representation in JavaScript.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSStringRef : IEquatable<JSStringRef>
{
    // OpaqueJSString*
    private void* ptr;
    public static readonly JSStringRef Null = new JSStringRef();

    public bool Equals(JSStringRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSStringRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// A JavaScript class. Used with JSObjectMake to construct objects with custom behavior.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSClassRef : IEquatable<JSClassRef>
{
    // OpaqueJSClass*
    private void* ptr;
    public static readonly JSClassRef Null = new JSClassRef();

    public bool Equals(JSClassRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSClassRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// An array of JavaScript property names.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSPropertyNameArrayRef : IEquatable<JSPropertyNameArrayRef>
{
    // OpaqueJSPropertyNameArray*
    private void* ptr;
    public static readonly JSPropertyNameArrayRef Null = new JSPropertyNameArrayRef();

    public bool Equals(JSPropertyNameArrayRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSPropertyNameArrayRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// An ordered set used to collect the names of a JavaScript object's properties.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSPropertyNameAccumulatorRef : IEquatable<JSPropertyNameAccumulatorRef>
{
    // OpaqueJSPropertyNameAccumulator*
    private void* ptr;
    public static readonly JSPropertyNameAccumulatorRef Null = new JSPropertyNameAccumulatorRef();

    public bool Equals(JSPropertyNameAccumulatorRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSPropertyNameAccumulatorRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// A function used to deallocate bytes passed to a Typed Array constructor.
/// </summary>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void JSTypedArrayBytesDeallocator(void* bytes, void* deallocatorContext);

// JavaScript data types

/// <summary>
/// A JavaScript value. The base type for all JavaScript values, and polymorphic functions on them.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSValueRef : IEquatable<JSValueRef>
{
    // OpaqueJSValue*
    private void* ptr;
    public static readonly JSValueRef Null = new JSValueRef();

    public bool Equals(JSValueRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSValueRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}

/// <summary>
/// A JavaScript object. A JSObject is a JSValue.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSObjectRef : IEquatable<JSObjectRef>
{
    // OpaqueJSObject*
    private void* ptr;
    public static readonly JSObjectRef Null = new JSObjectRef();
    
    // A JSObject is a JSValue, therefore we can fake their "inheritance" with some funny implicit casting
    // using pointer hacks.
    public static implicit operator JSValueRef(JSObjectRef objectRef)
    {
        return *(JSValueRef*)&objectRef;
    }

    public bool Equals(JSObjectRef other)
    {
        return ptr == other.ptr;
    }

    public override bool Equals(object? obj)
    {
        return obj is JSObjectRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return unchecked((int)(long)ptr);
    }
}
