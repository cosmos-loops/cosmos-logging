using System;
using System.Collections.Generic;

namespace Cosmos
{
    /// <summary>
    /// Argument checking extensions
    /// </summary>
    public static partial class PreconditionsExtensions
    {
        /// <summary>
        /// 检查 Guid 是否为空
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        public static void CheckNull(this Guid argument, string argumentName)
            => Preconditions.IsNotEmpty(argument, argumentName);

        /// <summary>
        /// 检查 Guid 是否为空
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNull(this Guid? argument, string argumentName, string message = null)
            => Preconditions.IsNotNull(argument, argumentName, message);

        /// <summary>
        /// 检查集合是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        public static void CheckNull<T>(this ICollection<T> argument, string argumentName)
            => Preconditions.IsNotEmpty(argument, argumentName);

        /// <summary>
        /// 检查键值对是否为空
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNull<TKey, TValue>(this KeyValuePair<TKey, TValue> argument, string argumentName, string message = null)
        {
            if (string.IsNullOrWhiteSpace(argument.ToString()))
            {
                throw new ArgumentNullException(argumentName, message ?? $"{nameof(argument)} contains nothing.");
            }
        }

        /// <summary>
        /// 检测空值,为 null 则抛出 ArgumentNullException 异常
        /// </summary>
        /// <param name="argument">对象</param>
        /// <param name="argumentName">参数名</param>
        /// <param name="message">消息</param>
        public static void CheckNull(this object argument, string argumentName, string message = null)
            => Preconditions.IsNotNull(argument, argumentName, message);
    }
}
