using System;
using System.Reflection;

namespace Cosmos.Judgements {
    /// <summary>
    /// Type Judgement Utilities
    /// </summary>
    public static class TypeJudgement {
        /// <summary>
        /// To judge whether the type is number type or not
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumericType(Type type) {
            return type == typeof(byte)
                   || type == typeof(short)
                   || type == typeof(int)
                   || type == typeof(long)
                   || type == typeof(sbyte)
                   || type == typeof(ushort)
                   || type == typeof(uint)
                   || type == typeof(ulong)
                   || type == typeof(decimal)
                   || type == typeof(double)
                   || type == typeof(float);
        }

        /// <summary>
        /// To judge whether the type is number type or not
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNumericType(TypeInfo typeInfo) {
            return IsNumericType(typeInfo.AsType());
        }

        /// <summary>
        /// To judge whether the type is nullable type or not
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(Type type) {
            return (((type != null) && type.GetTypeInfo().IsGenericType) && (type.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }

        /// <summary>
        /// To judge whether the type is nullable type or not
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool IsNullableType(TypeInfo typeInfo) {
            return IsNullableType(typeInfo.AsType());
        }
    }
}