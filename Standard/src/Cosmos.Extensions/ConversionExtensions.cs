using System;
using System.Reflection;
using System.Text;
using Cosmos.Extensions;

namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static class ConversionExtensions {
        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static object CastTo(this object value, Type conversionType) {
            return Conversions.ObjectConversion.To(value, conversionType);
        }

        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object CastTo(this object value, Type conversionType, object defaultValue) {
            return Conversions.ObjectConversion.To(value, conversionType, defaultValue);
        }

        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static object CastTo(this object value, TypeInfo conversionType) {
            return Conversions.ObjectConversion.To(value, conversionType);
        }

        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static object CastTo(this object value, TypeInfo conversionType, object defaultValue) {
            return Conversions.ObjectConversion.To(value, conversionType, defaultValue);
        }

        /// <summary>
        /// 把对象类型转化为指定类型，转化失败时返回指定的默认值
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转化的源对象</param>
        /// <returns>转化后的指定类型对象，转化失败时返回指定的默认值</returns>
        public static T CastTo<T>(this object value) {
            return Conversions.ObjectConversion.To<T>(value);
        }

        /// <summary>
        /// 把对象类型转化为指定类型，转化失败时返回指定的默认值
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转化的源对象</param>
        /// <param name="defaultValue">转化失败返回的指定默认值</param>
        /// <returns>转化后的指定类型对象，转化失败时返回指定的默认值</returns>
        public static T CastTo<T>(this object value, T defaultValue) {
            return Conversions.ObjectConversion.To<T>(value, defaultValue);
        }

        #region CastTo<TFrom,TTo>

        /// <summary>
        /// 将变量按指定的转换前类型与转换后类型进行转换
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(this TFrom value) {
            return CastTo(value, default(TTo));
        }

        /// <summary>
        /// 将变量按指定的转换前类型与转换后类型进行转换
        /// <para>如果转换失败，返回指定的默认值</para>
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TTo CastTo<TFrom, TTo>(this TFrom value, TTo defaultValue) {
            object result;
            var fromType = typeof(TFrom);
            var toType = typeof(TTo);
            try {

                #region CastToString

                //如果从 Int32 转换为字符，使用 Int32.CastToString(defaultValue) 方法
                if (fromType == typeof(int) && toType == typeof(string)) {
                    int @int;
                    int.TryParse(value.SafeString(), out @int);
                    result = @int.CastToString(defaultValue.SafeString("0"));
                }
                //如果从 Decimal 转换为字符，使用 Decimal.CastToString(defaultValue) 方法
                else if (fromType == typeof(decimal) && toType == typeof(string)) {
                    decimal @decimal;
                    decimal.TryParse(value.SafeString(), out @decimal);
                    result = @decimal.CastToString(defaultValue.SafeString("0.00"));
                }
                //如果从 Double 转换为字符，使用 Double.CastToString(defaultValue) 方法
                else if (fromType == typeof(double) && toType == typeof(string)) {
                    double @double;
                    double.TryParse(value.SafeString(), out @double);
                    result = @double.CastToString(defaultValue.SafeString("0.0"));
                }

                #endregion CastToString

                #region CastToDateTime

                //如果从 String 转换为 DateTime?，使用 String.CastToDateTime(defaultValue) 方法
                else if (fromType == typeof(string) && toType == typeof(DateTime?)) {
                    result = value.SafeString().CastToNullableDateTime(defaultValue.SafeDateTime());
                }
                //如果从 String 转换为 DateTime，使用 String.CastToDateTime(defaultValue) 方法
                else if (fromType == typeof(string) && toType == typeof(DateTime)) {
                    result = value.SafeString().CastToDateTime(defaultValue.SafeDateTime(DateTime.Now));
                }

                #endregion

                #region CastToEnum

                //如果从 String 转换为枚举，使用 String.CastToEnum(defaultValue, false) 方法
                else if (fromType == typeof(string) && toType.GetTypeInfo().IsEnum) {
                    result = value.SafeString().CastToEnum(defaultValue);
                }

                #endregion CastToEnum

                #region CastToGuid

                //如果从 String 转换为 Guid，使用 String.CastToGuid() 方法
                else if (fromType == typeof(string) && toType == typeof(Guid)) {
                    var @string = value.SafeString();
                    result = @string.CastToGuid(defaultValue.SafeGuid().SafeValue());
                }

                #endregion CastToGuid

                #region Default Func

                //默认方法
                else {
                    result = value.CastTo<TTo>(defaultValue);
                }

                #endregion Default Func

            }
            catch {
                result = defaultValue;
            }

            return (TTo) result;
        }

        #endregion

        #region CastToString

        #region Int32.CastToString(安全转换数字)

        /// <summary>
        /// 将数字安全转换为字符串
        /// <para>如果数字为零，则返回默认值</para>
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string CastToString(this int number, string defaultValue = "") {
            return number == 0 ? defaultValue : number.ToString();
        }

        /// <summary>
        /// 将数字安全转换为字符串
        /// <para>如果数字为空或为零，则返回默认值</para>
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string CastToString(this int? number, string defaultValue = "") {
            return CastToString(number.SafeValue(), defaultValue);
        }

        #endregion

        #region Decimal.CastToString(安全转换数字)

        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string CastToString(this decimal number, string defaultValue = "") {
            return number == 0 ? defaultValue : $"{number:0.##}";
        }

        #endregion

        #region Double.CastToString(安全转换数字)

        /// <summary>
        /// 获取格式化字符串
        /// </summary>
        /// <param name="number">数值</param>
        /// <param name="defaultValue">空值显示的默认文本</param>
        public static string CastToString(this double number, string defaultValue = "") {
            return $"{number:0.##}";
        }

        #endregion

        #region Array.CastToString<T>(用指定的字符串来指示其边界)

        /// <summary>
        /// 用指定的字符串来指示其边界（输出为 String 结果）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="format"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string CastToString<T>(this T[] array, string format, string delimiter) {
            if (array == null || array.Length == 0) return string.Empty;
            if (string.IsNullOrEmpty(format)) format = "{0}";

            var builder = new StringBuilder();
            for (var index = 0; index < array.Length; ++index) {
                if (index != 0) builder.Append(delimiter);
                builder.AppendFormat(format, array[index]);
            }

            return builder.ToString();
        }

        #endregion

        #region Object.CastToString(通用对象转换为字符串)

        /// <summary>
        /// 通用对象转换为字符串
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static string CastToString(this object @object) {
            return Conversions.ObjectConversion.ToString(@object);
        }

        #endregion

        #endregion CastToString

        #region CastToDateTime

        #region String.CastToDateTime

        /// <summary>
        /// 将字符串时间转换为时间
        /// </summary>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime CastToDateTime(this string @string, DateTime defaultValue = default(DateTime)) {
            return Conversions.ObjectConversion.ToDateTime(@string, defaultValue);
        }

        /// <summary>
        /// 将字符串时间转换为可空时间
        /// </summary>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime? CastToNullableDateTime(this string @string, DateTime? defaultValue = null) {
            return Conversions.ObjectConversion.ToNullableDateTime(@string, defaultValue);
        }

        #endregion String.CastToDateTime

        #endregion CastToDateTime

        #region CastToGuid

        #region String.CastToGuid(将字符串转换为 Guid)

        /// <summary>
        /// 将字符串转换为 Guid
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string @string) {
            return Conversions.GuidConversion.ToGuid(@string);
        }

        /// <summary>
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string @string, Guid defaultValue) {
            return Conversions.GuidConversion.ToNullableGuid(@string).SafeValue(defaultValue);
        }

        #endregion String.CastToGuid(将字符串转换为 Guid)

        #endregion CastToGuid

        #region CastToEnum

        #region String.CastToEnum

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="string"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string @string) {
            return CastToEnum<TEnum>(@string, false);
        }

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="string">     </param>
        /// <param name="ignorecase"> 是否区分大小写 </param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string @string, bool ignorecase) {
            if (string.IsNullOrWhiteSpace(@string)) {
                throw new ArgumentNullException(nameof(@string));
            }

            var t = typeof(TEnum);
            if (!t.GetTypeInfo().IsEnum) {
                throw new ArgumentException(nameof(@string));
            }

            return (TEnum) Enum.Parse(t, @string, ignorecase);
        }

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string @string, TEnum defaultValue) {
            return CastToEnum(@string, defaultValue, false);
        }

        /// <summary>
        /// 将指定的字符串转换为枚举
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignorecase">是否区分大小写</param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string @string, TEnum defaultValue, bool ignorecase) {
            if (string.IsNullOrWhiteSpace(@string)) {
                throw new ArgumentNullException(nameof(@string));
            }

            if (defaultValue == null) {
                throw new ArgumentNullException(nameof(defaultValue));
            }

            var result = defaultValue;

            var t = typeof(TEnum);
            // ReSharper disable once InvertIf
            if (!t.GetTypeInfo().IsEnum) {
                throw new ArgumentException(nameof(@string));
            }

            try {
                result = (TEnum) Enum.Parse(t, @string, ignorecase);
            }
            catch {
                // ignored
            }

            return result;
        }

        #endregion String.CastToEnum

        #endregion CastToEnum

        #region CastToNumber

        #region String.CastToInt

        /// <summary>
        /// 将字符串转换为 Int
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static int CastToInt(this string @string) {
            return Conversions.NumericConversion.ToInt32(@string);
        }

        /// <summary>
        /// 将字符串转换为 Int
        /// </summary>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int CastToInt(this string @string, int defaultValue) {
            return Conversions.NumericConversion.ToNullableInt32(@string).SafeValue(defaultValue);
        }

        #endregion String.CastToInt

        #region String.CastToDouble

        /// <summary>
        /// 将字符串转换为 Double
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static double CastToDouble(this string @string) {
            return Conversions.NumericConversion.ToDouble(@string);
        }

        /// <summary>
        /// 将字符串转换为 Double
        /// </summary>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double CastToDouble(this string @string, double defaultValue) {
            return Conversions.NumericConversion.ToNullableDouble(@string).SafeValue(defaultValue);
        }

        #endregion String.CastToDouble

        #region String.CastToDecimal

        /// <summary>
        /// 将字符串转换为 Decimal
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string @string) {
            return Conversions.NumericConversion.ToDecimal(@string);
        }

        /// <summary>
        /// 将字符串转换为 Decimal
        /// </summary>
        /// <param name="string"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string @string, decimal defaultValue) {
            return Conversions.NumericConversion.ToNullableDecimal(@string).SafeValue(defaultValue);
        }

        #endregion String.CastToDecimal

        #endregion CastToNumber

    }
}