using System;
using System.Reflection;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Type conversion Utilities
    /// </summary>
    public static class TypeConversion
    {
        /// <summary>
        /// Convert nullable type to underlying type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(Type type) => Nullable.GetUnderlyingType(type);

        /// <summary>
        /// Convert nullable typeinfo to underlying typeinfo
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(TypeInfo typeinfo) => Nullable.GetUnderlyingType(typeinfo.AsType()).GetTypeInfo();
    }
}