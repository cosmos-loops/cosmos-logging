using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Safty value and nullable value extensions
    /// </summary>
    public static class SafeAndNullableExtensions
    {
        /// <summary>
        /// 安全返回值
        /// </summary>
        /// <param name="value"> 可空值 </param>
        public static T SafeValue<T>(this T? value) where T : struct => value.GetValueOrDefault();

        /// <summary>
        /// 安全返回值
        /// <para>如果可空值真为空，则返回默认值</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T SafeValue<T>(this T? value, T defaultValue) where T : struct =>
            value.GetValueOrDefault(defaultValue);

        /// <summary>
        /// 获取 Null安全 的字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string SafeValue(this string @string) => (@string ?? string.Empty).Trim();

        /// <summary>
        /// 安全获取字符串类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static string SafeString(this object @object) => (@object as string).SafeValue();

        /// <summary>
        /// 安全获取字符串类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string SafeString(this object @object, string defaultValue)
        {
            var @string = @object.SafeString();
            return string.IsNullOrWhiteSpace(@string) ? defaultValue : @string;
        }

        /// <summary>
        /// 获取安全时间类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static DateTime? SafeDateTime(this object @object) => @object as DateTime?;

        /// <summary>
        /// 获取安全时间类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime SafeDateTime(this object @object, DateTime defaultValue) =>
            @object.SafeDateTime().SafeValue(defaultValue);

        /// <summary>
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static Guid? SafeGuid(this object @object) => @object as Guid?;

        /// <summary>
        /// 获取安全的 Guid 类型
        /// </summary>
        /// <param name="object"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid SafeGuid(this object @object, Guid defaultValue) =>
            @object.SafeGuid().SafeValue(defaultValue);

        /// <summary>
        /// 安全移除空白字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeTrim(this string str) => str?.Trim();

        /// <summary>
        /// 安全获得 IQueryable 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryable<T>(this IQueryable<T> @query) =>
            Judgements.CollectionJudgement.IsNullOrEmpty(query) ? (new List<T>()).AsQueryable() : query;

        /// <summary>
        /// 安全获得 IQueryable 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable<T> SafeQueryable<T>(this IEnumerable<T> enumerable) =>
            enumerable.AsQueryable().SafeQueryable();

        /// <summary>
        /// 安全获得 IQueryable 集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IQueryable SafeQueryable(this IQueryable query) =>
            Judgements.CollectionJudgement.IsNullOrEmpty(query) ? (new List<object>()).AsQueryable() : query;

        /// <summary>
        /// 安全获得 IQueryable 集合
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IQueryable SafeQuertable(this IEnumerable enumerable) => enumerable.AsQueryable().SafeQueryable();

        /// <summary>
        /// 获取所给定的可空类型的不可空类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(this Type type) => Nullable.GetUnderlyingType(type);

        /// <summary>
        /// 获取所给定的可空类型的不可空类型
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(this TypeInfo typeinfo) =>
            Nullable.GetUnderlyingType(typeinfo.AsType()).GetTypeInfo();

        /// <summary>
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="hander"></param>
        /// <param name="sender"></param>
        public static void SafeInvoke(this EventHandler hander, object sender) =>
            hander.SafeInvoke(sender, EventArgs.Empty);

        /// <summary>
        /// 以给定参数安全执行事件
        /// </summary>
        /// <param name="hander"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SafeInvoke(this EventHandler hander, object sender, EventArgs e) =>
            hander?.Invoke(sender, e);

        /// <summary>
        /// 以给定参数安全执行事件
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="hander"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SafeInvoke<TEventArgs>(this EventHandler<TEventArgs> hander, object sender, TEventArgs e) =>
            hander?.Invoke(sender, e);
    }
}