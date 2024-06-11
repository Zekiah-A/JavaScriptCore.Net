using System.Runtime.InteropServices;

namespace JavaScriptCore;

public static unsafe partial class JSString
{
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringCreateWithCharacters")]
    public static partial JSStringRef CreateWithCharacters(JSChar* chars, int numChars);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringCreateWithUTF8CString")]
    public static partial JSStringRef CreateWithUTF8CString(char* @string);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringRetain")]
    public static partial JSStringRef Retain(JSStringRef str);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringRelease")]
    public static partial void Release(JSStringRef str);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringGetLength")]
    public static partial int GetLength(JSStringRef str);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringGetCharactersPtr")]
    public static partial JSChar* GetCharactersPtr(JSStringRef str);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringGetMaximumUTF8CStringSize")]
    public static partial int GetMaximumUTF8CStringSize(JSStringRef str);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringGetUTF8CString")]
    public static partial int GetUTF8CString(JSStringRef @string, char* buffer, int bufferSize);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringIsEqual")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool IsEqual(JSStringRef a, JSStringRef b);

    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSStringIsEqualToUTF8CString")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool IsEqualToUTF8CString(JSStringRef a, char* b);
}

/// <summary>
/// A UTF-16 code unit. One, or a sequence of two, can encode any Unicode
/// character. As with all scalar types, endianness depends on the underlying
/// architecture.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct JSChar
{
    private char @char;
    
    // A JSChar is binary identical to a C# char (both are UTF-16), so we can use dirty pointer hacks to
    // simulate their same-ness.
    public static implicit operator char(JSChar jsChar)
    {
        return *(char*)&jsChar;
    }
}
