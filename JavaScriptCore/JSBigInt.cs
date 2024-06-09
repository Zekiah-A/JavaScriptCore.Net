using System.Runtime.InteropServices;

namespace JavaScriptCore;

/// <summary>
/// Mirrors methods from JSValueRef.h
/// </summary>
public static unsafe partial class JSBigInt
{
    /// <summary>
    /// Creates a JavaScript BigInt with a double.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The value to copy into the new BigInt JSValue.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A BigInt JSValue of the value, or NULL if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSBigIntCreateWithDouble")]
    public static partial JSValueRef CreateWithDouble(JSContextRef ctx, double value, JSValueRef* exception);

    /// <summary>
    /// Creates a JavaScript BigInt with a 64-bit signed integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="integer">The 64-bit signed integer to copy into the new BigInt JSValue.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A BigInt JSValue of the integer, or NULL if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSBigIntCreateWithInt64")]
    public static partial JSValueRef CreateWithInt64(JSContextRef ctx, long integer, JSValueRef* exception);

    /// <summary>
    /// Creates a JavaScript BigInt with a 64-bit unsigned integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="integer">The 64-bit unsigned integer to copy into the new BigInt JSValue.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A BigInt JSValue of the integer, or NULL if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSBigIntCreateWithUInt64")]
    public static partial JSValueRef CreateWithUInt64(JSContextRef ctx, ulong integer, JSValueRef* exception);

    /// <summary>
    /// Creates a JavaScript BigInt with an integer represented in string.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="string">The JSStringRef representation of an integer.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A BigInt JSValue of the string, or NULL if an exception is thrown.
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSBigIntCreateWithString")]
    public static partial JSValueRef CreateWithString(JSContextRef ctx, JSStringRef @string,
        JSValueRef* exception);
}