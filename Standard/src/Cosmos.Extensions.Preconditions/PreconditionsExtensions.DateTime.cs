using System;

namespace Cosmos
{
    /// <summary>
    /// DateTime arguments checking extensions
    /// </summary>
    public static partial class PreconditionsExtensions
    {
        /// <summary>
        /// 检查是否为合法时间
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckValidDate(this DateTime argument, string argumentName, string message = null)
            => Preconditions.IsNotInvalidDate(argument, argumentName, message);

        /// <summary>
        /// 检查是否为合法时间
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckValidDate(this DateTime? argument, string argumentName, string message = null)
            => Preconditions.IsNotInvalidDate(argument, argumentName, message);

        /// <summary>
        /// 检查是否为过去
        /// <para> 如果为过去，则抛出 ArgumentOutOfRangeException </para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNotInPast(this DateTime argument, string argumentName, string message = null)
            => Preconditions.IsNotInPast(argument, argumentName, message);

        /// <summary>
        /// 检查是否为过去
        /// <para>如果为过去，则抛出 ArgumentOutOfRangeException</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNotInPast(this DateTime? argument, string argumentName, string message = null)
            => Preconditions.IsNotInPast(argument, argumentName, message);

        /// <summary>
        /// 检查是否为未来
        /// <para> 如果为未来，则抛出 ArgumentOutOfRangeException </para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNotInFuture(this DateTime argument, string argumentName, string message = null)
            => Preconditions.IsNotInFuture(argument, argumentName, message);

        /// <summary>
        /// 检查是否为未来
        /// <para>如果为未来，则抛出 ArgumentOutOfRangeException</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNotInFuture(this DateTime? argument, string argumentName, string message = null)
            => Preconditions.IsNotInFuture(argument, argumentName, message);

        /// <summary>
        /// 检查是否为负时间间隔
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegative(this TimeSpan argument, string argumentName, string message = null)
            => Preconditions.IsNotNegative(argument, argumentName, message);

        /// <summary>
        /// 检查是否为负时间间隔
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegative(this TimeSpan? argument, string argumentName, string message = null)
            => Preconditions.IsNotNegative(argument, argumentName, message);

        /// <summary>
        /// 检查是否为零时间间隔或负时间间隔
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegativeOrZero(this TimeSpan argument, string argumentName, string message = null)
            => Preconditions.IsNotNegativeOrZero(argument, argumentName, message);

        /// <summary>
        /// 检查是否为零时间间隔或负时间间隔
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegativeOrZero(this TimeSpan? argument, string argumentName, string message = null)
            => Preconditions.IsNotNegativeOrZero(argument, argumentName, message);
    }
}
