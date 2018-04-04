using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cosmos {
    /// <summary>
    /// Judgement extensions
    /// </summary>
    public static class JudgementExtensions {
        /// <summary>
        /// 判断指定日期是否为今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime date) => Judgements.DateTimeJudgement.IsToday(date);

        /// <summary>
        /// 判断指定日期是否为今天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime? date) => Judgements.DateTimeJudgement.IsToday(date);

        /// <summary>
        /// 判断指定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTimeOffset dto) => Judgements.DateTimeJudgement.IsToday(dto);

        /// <summary>
        /// 判断指定
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTimeOffset? dto) => Judgements.DateTimeJudgement.IsToday(dto);

        /// <summary>
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime date) => Judgements.DateTimeJudgement.IsWeekday(date);

        /// <summary>
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime? date) => Judgements.DateTimeJudgement.IsWeekday(date);

        /// <summary>
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date) => Judgements.DateTimeJudgement.IsWeekend(date);

        /// <summary>
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime? date) => Judgements.DateTimeJudgement.IsWeekend(date);

        /// <summary>
        /// 判断时间是否合法
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsValid(this DateTime target) => Judgements.DateTimeJudgement.IsValid(target);

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="guid"> 值 </param>
        public static bool IsNullOrEmpty(this Guid? guid) => Judgements.GuidJudgement.IsNullOrEmpty(guid);

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="guid"> 值 </param>
        public static bool IsNullOrEmpty(this Guid guid) => Judgements.GuidJudgement.IsNullOrEmpty(guid);

        /// <summary>
        /// 判断指定字符串是否为 Guid
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsGuid(this string @string) => Judgements.GuidJudgement.IsValid(@string);

        /// <summary>
        /// 检查字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string @string) => string.IsNullOrEmpty(@string);

        /// <summary>
        /// 检查字符串不是 null 或 System.String.Empty 字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNotNullNorEmpty(this string @string) => !@string.IsNullOrEmpty();

        /// <summary>
        /// 检查字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string @string) => string.IsNullOrWhiteSpace(@string);

        /// <summary>
        /// 检查字符串不是 null、空或由空白字符串组成
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNotNullNorWhiteSpace(this string @string) => !@string.IsNullOrWhiteSpace();

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, params string[] values)
            => Judgements.StringJudgement.StartWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, ICollection<string> values)
            => Judgements.StringJudgement.StartWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string @string, params string[] values)
            => Judgements.StringJudgement.EndWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string @string, ICollection<string> values)
            => Judgements.StringJudgement.EndWithThese(@string, values);

        /// <summary>
        /// 指示指定的字符串是否为 Int 类型
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsInt(this string @string) => Judgements.NumericJudgement.IsInt32(@string);

        /// <summary>
        /// 指示指定的字符串是否为数字
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNumberic(this string @string) => Judgements.NumericJudgement.IsNumeric(@string);

        /// <summary>
        /// 判断是否为 Url 路径
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsWebUrl(this string target) => Judgements.StringJudgement.IsWebUrl(target);

        /// <summary>
        /// 判断是否为 Email 地址
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEmail(this string target) => Judgements.StringJudgement.IsEmail(target);

        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="text"></param>
        public static bool ContainsChinese(string text) => Judgements.StringJudgement.ContainsChineseCharacters(text);

        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsNumber(string text) => Judgements.StringJudgement.ContainsNumber(text);

        /// <summary>
        /// 判断指定类型是否为数值类型
        /// </summary>
        /// <param name="type">要检查的类型</param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this Type type) => Judgements.TypeJudgement.IsNumericType(type);

        /// <summary>
        /// 判断指定类型是否为数值类型
        /// </summary>
        /// <param name="typeInfo">要检查的类型</param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this TypeInfo typeInfo) => Judgements.TypeJudgement.IsNumericType(typeInfo);

        /// <summary>
        /// 指示类型是否为可空类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableType(this Type type) => Judgements.TypeJudgement.IsNullableType(type);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNull(this IEnumerable source) => Judgements.CollectionJudgement.IsNull(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty(this IEnumerable source) => Judgements.CollectionJudgement.IsNullOrEmpty(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => Judgements.CollectionJudgement.IsNullOrEmpty(source);

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="enumeration"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this ICollection<T> enumeration, int count)
            => Judgements.CollectionJudgement.ContainsAtLeast(enumeration, count);

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this ICollection<T> @this, ICollection<T> @that)
            => Judgements.CollectionJudgement.ContainsEqualCount(@this, @that);

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="enumeration"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this IQueryable<T> enumeration, int count)
            => Judgements.QueryableJudgement.ContainsAtLeast(enumeration, count);

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this IQueryable<T> @this, IQueryable<T> @that)
            => Judgements.QueryableJudgement.ContainsEqualCount(@this, @that);

    }
}