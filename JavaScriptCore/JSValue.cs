using System.Runtime.InteropServices;

namespace JavaScriptCore;

public static unsafe partial class JSValue
{
    /// <summary>
    /// Returns a JavaScript value's type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue whose type you want to obtain.</param>
    /// <returns>A value of type JSType that identifies value's type.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueGetType")]
    public static partial JSType GetType(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the undefined type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the undefined type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsUndefined")]
    public static partial bool IsUndefined(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the null type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the null type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsNull")]
    public static partial bool IsNull(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the boolean type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the boolean type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsBoolean")]
    public static partial bool IsBoolean(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the number type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the number type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsNumber")]
    public static partial bool IsNumber(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the string type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the string type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsString")]
    public static partial bool IsString(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the symbol type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the symbol type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsSymbol")]
    public static partial bool IsSymbol(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the BigInt type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the BigInt type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsBigInt")]
    public static partial bool IsBigInt(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value's type is the object type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value's type is the object type, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsObject")]
    public static partial bool IsObject(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value is an object with a given class in its class chain.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <param name="jsClass">The JSClass to test against.</param>
    /// <returns>true if value is an object and has jsClass in its class chain, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsObjectOfClass")]
    public static partial bool IsObjectOfClass(IJSContextRef ctx, JSValueRef value, JSClassRef jsClass);

    /// <summary>
    /// Tests whether a JavaScript value is an array.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value is an array, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsArray")]
    public static partial bool IsArray(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Tests whether a JavaScript value is a date.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <returns>true if value is a date, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsDate")]
    public static partial bool IsDate(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Returns a JavaScript value's Typed Array type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue whose Typed Array type to return.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A value of type JSTypedArrayType that identifies value's Typed Array type, orNone if the value is not a Typed Array object.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueGetTypedArrayType")]
    public static partial JSTypedArrayType GetTypedArrayType(IJSContextRef ctx, JSValueRef value,
        JSValueRef* exception);

    /* Comparing values */

    /// <summary>
    /// Tests whether two JavaScript values are equal, as compared by the JS == operator.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="a">The first value to test.</param>
    /// <param name="b">The second value to test.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>true if the two values are equal, false if they are not equal or an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsEqual")]
    public static partial bool IsEqual(IJSContextRef ctx, JSValueRef a, JSValueRef b, JSValueRef* exception);

    /// <summary>
    /// Tests whether two JavaScript values are strict equal, as compared by the JS === operator.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="a">The first value to test.</param>
    /// <param name="b">The second value to test.</param>
    /// <returns>true if the two values are strict equal, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsStrictEqual")]
    public static partial bool IsStrictEqual(IJSContextRef ctx, JSValueRef a, JSValueRef b);

    /// <summary>
    /// Tests whether a JavaScript value is an object constructed by a given constructor, as compared by the JS instanceof operator.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to test.</param>
    /// <param name="constructor">The constructor to test against.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>true if value is an object constructed by constructor, as compared by the JS instanceof operator, otherwise false.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueIsInstanceOfConstructor")]
    public static partial bool IsInstanceOfConstructor(IJSContextRef ctx, JSValueRef value,
        JSObjectRef constructor, JSValueRef* exception);

    /// <summary>
    /// Compares two JSValues.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="left">The JSValue as the left operand.</param>
    /// <param name="right">The JSValue as the right operand.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A value of JSRelationCondition, a kJSRelationConditionUndefined is returned if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueCompare")]
    public static partial JSRelationCondition Compare(IJSContextRef ctx, JSValueRef left, JSValueRef right,
        JSValueRef* exception);

    /// <summary>
    /// Compares a JSValue with a signed 64-bit integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="left">The JSValue as the left operand.</param>
    /// <param name="right">The int64_t as the right operand.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A value of JSRelationCondition, a kJSRelationConditionUndefined is returned if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueCompareInt64")]
    public static partial JSRelationCondition CompareInt64(IJSContextRef ctx, JSValueRef left, ulong right,
        JSValueRef* exception);

    /// <summary>
    /// Compares a JSValue with an unsigned 64-bit integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="left">The JSValue as the left operand.</param>
    /// <param name="right">The ulong as the right operand.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A value of JSRelationCondition, a kJSRelationConditionUndefined is returned if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueCompareInt64")]
    public static partial JSRelationCondition CompareUInt64(IJSContextRef ctx, JSValueRef left, ulong right,
        JSValueRef* exception);

    /// <summary>
    /// Compares a JSValue with a double.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="left">The JSValue as the left operand.</param>
    /// <param name="right">The double as the right operand.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A value of JSRelationCondition, a kJSRelationConditionUndefined is returned if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueCompareDouble")]
    public static partial JSRelationCondition CompareDouble(IJSContextRef ctx, JSValueRef left, double right,
        JSValueRef* exception);

    /* Creating values */

    /// <summary>
    /// Creates a JavaScript value of the undefined type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <returns>The unique undefined value.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueMakeUndefined")]
    public static partial JSValueRef MakeUndefined(IJSContextRef ctx);

    /// <summary>
    /// Creates a JavaScript value of the null type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <returns>The unique null value.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueMakeNull")]
    public static partial JSValueRef MakeNull(IJSContextRef ctx);

    /// <summary>
    /// Creates a JavaScript value of the boolean type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="boolean">The bool to assign to the newly created JSValue.</param>
    /// <returns>A JSValue of the boolean type, representing the value of boolean.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueCompareDouble")]
    public static partial JSValueRef MakeBoolean(IJSContextRef ctx, bool boolean);

    /// <summary>
    /// Creates a JavaScript value of the number type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="number">The double to assign to the newly created JSValue.</param>
    /// <returns>A JSValue of the number type, representing the value of number.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueMakeNumber")]
    public static partial JSValueRef MakeNumber(IJSContextRef ctx, double number);

    /// <summary>
    /// Creates a JavaScript value of the string type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="string">
    /// The JSString to assign to the newly created JSValue.
    /// The newly created JSValue retains string, and releases it upon garbage collection.
    /// </param>
    /// <returns>A JSValue of the string type, representing the value of string.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueMakeString")]
    public static partial JSValueRef MakeString(IJSContextRef ctx, JSStringRef @string);

    /// <summary>
    /// Creates a JavaScript value of the symbol type.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="description">A description of the newly created symbol value.</param>
    /// <returns>A unique JSValue of the symbol type, whose description matches the one provided.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueMakeSymbol")]
    public static partial JSValueRef MakeSymbol(IJSContextRef ctx, JSStringRef description);
    
    /* Converting to and from JSON formatted strings */

    /// <summary>
    /// Creates a JavaScript value from a JSON formatted string.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="string">The JSString containing the JSON string to be parsed.</param>
    /// <returns>A JSValue containing the parsed value, or NULL if the input is invalid.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueMakeFromJSONString")]
    public static partial JSValueRef MakeFromJSONString(IJSContextRef ctx, JSStringRef @string);

    /// <summary>
    /// Creates a JavaScript string containing the JSON serialized representation of a JS value.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="indent">The number of spaces to indent when nesting.  If 0, the resulting JSON will not contains newlines.  The size of the indent is clamped to 10 spaces.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A JSString with the result of serialization, or NULL if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueCreateJSONString")]
    public static partial JSStringRef CreateJSONString(IJSContextRef ctx, JSValueRef value, uint indent,
        JSValueRef* exception);

    /* Converting to primitive values */

    /// <summary>
    /// Converts a JavaScript value to boolean and returns the resulting boolean.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <returns>The boolean result of conversion.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToBoolean")]
    public static partial bool ToBoolean(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Converts a JavaScript value to number and returns the resulting number.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The numeric result of conversion, or NaN if an exception is thrown.
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToNumber")]
    public static partial double ToNumber(IJSContextRef ctx, JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// Converts a JSValue to a singed 32-bit integer and returns the resulting integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>An int with the result of conversion, or 0 if an exception is thrown. Since 0 is valid value, `exception` must be checked after the call.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToInt32")]
    public static partial int ToInt32(IJSContextRef ctx, JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// Converts a JSValue to an unsigned 32-bit integer and returns the resulting integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A uint with the result of conversion, or 0 if an exception is thrown. Since 0 is valid value, `exception` must be checked after the call.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToUInt32")]
    public static partial uint ToUInt32(IJSContextRef ctx, JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// Converts a JSValue to a singed 64-bit integer and returns the resulting integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>An int64_t with the result of conversion, or 0 if an exception is thrown. Since 0 is valid value, `exception` must be checked after the call.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToInt64")]
    public static partial long ToInt64(IJSContextRef ctx, JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// Converts a JSValue to an unsigned 64-bit integer and returns the resulting integer.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A ulong with the result of conversion, or 0 if an exception is thrown. Since 0 is valid value, `exception` must be checked after the call.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToUInt64")]
    public static partial ulong ToUInt64(IJSContextRef ctx, JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// Converts a JavaScript value to string and copies the result into a JavaScript string.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>A JSString with the result of conversion, or NULL if an exception is thrown. Ownership follows the Create Rule.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToStringCopy")]
    public static partial JSStringRef ToStringCopy(IJSContextRef ctx, JSValueRef value, JSValueRef* exception);

    /// <summary>
    /// Converts a JavaScript value to object and returns the resulting object.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to convert.</param>
    /// <param name="exception">A pointer to a JSValueRef in which to store an exception, if any. To reliable detect exception, initialize this to null before the call. Pass NULL if you do not care to store an exception.</param>
    /// <returns>The JSObject result of conversion, or NULL if an exception is thrown.</returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueToObject")]
    public static partial JSObjectRef ToObject(IJSContextRef ctx, JSValueRef value, JSValueRef* exception);

    /* Garbage collection */
    /// <summary>
    /// Protects a JavaScript value from garbage collection.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to protect.</param>
    /// <returns></returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueProtect")]
    public static partial void Protect(IJSContextRef ctx, JSValueRef value);

    /// <summary>
    /// Unprotects a JavaScript value from garbage collection.
    /// </summary>
    /// <param name="ctx">The execution context to use.</param>
    /// <param name="value">The JSValue to unprotect.</param>
    /// <returns></returns>
    [LibraryImport(JavaScriptCore.LibraryObjectName, EntryPoint = "JSValueUnprotect")]
    public static partial void Unprotect(IJSContextRef ctx, JSValueRef value);
}

/// <summary>
/// A constant identifying the type of JavaScript relation condition.
/// <para>kJSRelationConditionUndefined: Fail to compare two operands.</para>
/// <para>kJSRelationConditionEqual: Two operands have equivalent values.</para>
/// <para>kJSRelationConditionGreaterThan: The left operand is greater than the right operand.</para>
/// <para>kJSRelationConditionLessThan: The left operand is less than the right operand.</para>
/// </summary>
public enum JSRelationCondition
{
    Undefined,
    Equal,
    GreaterThan,
    LessThan
}

/// <summary>
/// A constant identifying the type of a JSValue.
/// <para>kJSTypeUndefined: The unique undefined value.</para>
/// <para>kJSTypeNull: The unique null value.</para>
/// <para>kJSTypeBoolean: A primitive boolean value, one of true or false.</para>
/// <para>kJSTypeNumber: A primitive number value.</para>
/// <para>kJSTypeString: A primitive string value.</para>
/// <para>kJSTypeObject: An object value (meaning that this JSValueRef is a JSObjectRef).</para>
/// <para>kJSTypeSymbol: A primitive symbol value.</para>
/// <para>kJSTypeBigInt: A primitive BigInt value.</para>
/// </summary>
public enum JSType
{
    Undefined,
    Null,
    Boolean,
    Number,
    String,
    Object,
    Symbol,
    BigInt
}

/// <summary>
/// A constant identifying the Typed Array type of a JSObjectRef.
/// <para>kJSTypedArrayTypeInt8Array: Int8Array</para>
/// <para>kJSTypedArrayTypeInt16Array: Int16Array</para>
/// <para>kJSTypedArrayTypeInt32Array: Int32Array</para>
/// <para>kJSTypedArrayTypeUint8Array: Uint8Array</para>
/// <para>kJSTypedArrayTypeUint8ClampedArray: Uint8ClampedArray</para>
/// <para>kJSTypedArrayTypeUint16Array: Uint16Array</para>
/// <para>kJSTypedArrayTypeUint32Array: Uint32Array</para>
/// <para>kJSTypedArrayTypeFloat32Array: Float32Array</para>
/// <para>kJSTypedArrayTypeFloat64Array: Float64Array</para>
/// <para>kJSTypedArrayTypeBigInt64Array: BigInt64Array</para>
/// <para>kJSTypedArrayTypeBigUint64Array: BigUint64Array</para>
/// <para>kJSTypedArrayTypeArrayBuffer: ArrayBuffer</para>
/// <para>kJSTypedArrayTypeNone: Not a Typed Array</para>
/// </summary>
public enum JSTypedArrayType
{
   Int8Array,
   Int16Array,
   Int32Array,
   Uint8Array,
   Uint8ClampedArray,
   Uint16Array,
   Uint32Array,
   Float32Array,
   Float64Array,
   ArrayBuffer,
   None,
   BigInt64Array,
   BigUint64Array
}