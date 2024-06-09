using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSObjectRef.h
/// </summary>
public static unsafe partial class JSObject
{
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeTypedArray")]
    public static partial JSObjectRef MakeTypedArray(JSContextRef ctx, JSTypedArrayType arrayType,
        IntPtr length, JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeTypedArrayWithBytesNoCopy")]
    public static partial JSObjectRef MakeTypedArrayWithBytesNoCopy(JSContextRef ctx,
        JSTypedArrayType arrayType, IntPtr bytes, IntPtr byteLength, JSTypedArrayBytesDeallocator bytesDeallocator,
        IntPtr deallocatorContext, JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeTypedArrayWithArrayBuffer")]
    public static partial JSObjectRef MakeTypedArrayWithArrayBuffer(JSContextRef ctx,
        JSTypedArrayType arrayType, JSObjectRef buffer, JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeTypedArrayWithArrayBufferAndOffset")]
    public static partial JSObjectRef MakeTypedArrayWithArrayBufferAndOffset(JSContextRef ctx,
        JSTypedArrayType arrayType, JSObjectRef buffer, IntPtr byteOffset, IntPtr length, JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetTypedArrayBytesPtr")]
    public static partial IntPtr GetTypedArrayBytesPtr(JSContextRef ctx, JSObjectRef obj,
        JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetTypedArrayLength")]
    public static partial IntPtr GetTypedArrayLength(JSContextRef ctx, JSObjectRef obj,
        JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetTypedArrayByteLength")]
    public static partial IntPtr GetTypedArrayByteLength(JSContextRef ctx, JSObjectRef obj,
        JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetTypedArrayByteOffset")]
    public static partial IntPtr GetTypedArrayByteOffset(JSContextRef ctx, JSObjectRef obj,
        JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetTypedArrayBuffer")]
    public static partial JSObjectRef GetTypedArrayBuffer(JSContextRef ctx, JSObjectRef obj,
        JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectMakeArrayBufferWithBytesNoCopy")]
    public static partial JSObjectRef MakeArrayBufferWithBytesNoCopy(JSContextRef ctx, IntPtr bytes,
        IntPtr byteLength, JSTypedArrayBytesDeallocator bytesDeallocator, IntPtr deallocatorContext,
        JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetArrayBufferBytesPtr")]
    public static partial IntPtr GetArrayBufferBytesPtr(JSContextRef ctx, JSObjectRef obj,
        JSValueRef* exception);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSObjectGetArrayBufferByteLength")]
    public static partial IntPtr GetArrayBufferByteLength(JSContextRef ctx, JSObjectRef obj,
        JSValueRef* exception);
}