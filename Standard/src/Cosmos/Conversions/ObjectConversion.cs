using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cosmos.Conversions {
    /// <summary>
    /// Object Conversion Utilities
    /// </summary>
    public static class ObjectConversion {
        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="string"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj) {
            return obj?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object To(object fromObj, Type targetType) {
            return To(fromObj, targetType, null);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetType"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object To(object fromObj, Type targetType, object defaultValue) {
            if (fromObj == null) {
                return defaultValue;
            }

            if (fromObj is string && string.IsNullOrWhiteSpace(fromObj.ToString())) {
                return defaultValue;
            }

            var fromObjType = Nullable.GetUnderlyingType(targetType) ?? targetType;
            try {
                if (fromObjType.Name.ToLower() == "guid") {
                    return (object) GuidConversion.ToGuid(fromObj);
                }

                if (fromObjType.GetTypeInfo().IsEnum) {
                    return Enum.Parse(fromObjType, fromObj.ToString());
                }

                if (fromObj is string fromStr && decimal.TryParse(fromStr, out decimal decimalRet)) {
                    return Convert.ChangeType(decimalRet, fromObjType);
                }

                if (fromObj is IConvertible) {
                    return Convert.ChangeType(fromObj, fromObjType);
                }

                return fromObj;
            }
            catch {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetTypeInfo"></param>
        /// <returns></returns>
        public static object To(object fromObj, TypeInfo targetTypeInfo) {
            return To(fromObj, targetTypeInfo.AsType(), null);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to another type of <see cref="object"/> instance
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="targetTypeInfo"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object To(object fromObj, TypeInfo targetTypeInfo, object defaultValue) {
            return To(fromObj, targetTypeInfo.AsType(), defaultValue);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to a <see cref="TTo"/> instance
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObj"></param>
        /// <returns></returns>
        public static TTo To<TTo>(object fromObj) {
            return To<TTo>(fromObj, default(TTo));
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to a <see cref="TTo"/> instance
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TTo To<TTo>(object fromObj, TTo defaultValue) {
            try {
                return (TTo) To(fromObj, typeof(TTo), defaultValue);
            }

            catch {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert from string to a <see cref="TTo"/> instances list
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="listStr"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static IEnumerable<TTo> ToList<TTo>(string listStr, char splitChar = ',') {
            var ret = new List<TTo>();
            if (string.IsNullOrWhiteSpace(listStr)) {
                return ret;
            }

            var array = listStr.Split(splitChar);
            ret.AddRange(from each in array where !string.IsNullOrWhiteSpace(each) select To<TTo>(each));

            return ret;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTime"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultRet = default(DateTime)) {
            if (obj == null) {
                return defaultRet;
            }

            return DateTime.TryParse(obj.ToString(), out DateTime ret) ? ret : defaultRet;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTime"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(object obj, DateTime? defaultRet = null) {
            if (obj == null) {
                return defaultRet;
            }

            return DateTime.TryParse(obj.ToString(), out DateTime result) ? result : defaultRet;
        }
    }
}