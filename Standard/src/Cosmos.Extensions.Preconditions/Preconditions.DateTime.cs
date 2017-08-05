using System;
using Cosmos.Extensions;

namespace Cosmos
{
    /// <summary>
    /// DateTime arguments checking
    /// </summary>
    public static partial class Preconditions
    {
        /// <summary>
        /// 检查时间是否合法
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotInvalidDate(DateTime argument, string argumentName, string message = null)
        {
            if (!Judgements.DateTimeJudgement.IsValid(argument))
            {
                throw new ArgumentException(message ?? $"{nameof(argument)} is invalid datetime value.", argumentName);
            }
        }

        /// <summary>
        /// 检查时间是否合法
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotInvalidDate(DateTime? argument, string argumentName, string message = null)
        {
            IsNotInvalidDate(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查时间是否为过去
        /// <para>如果是过去，则抛出异常</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotInPast(DateTime argument, string argumentName, string message = null)
        {
            if (argument < DateTime.UtcNow)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be in past.");
            }
        }

        /// <summary>
        /// 检查时间是否为过去
        /// <para>如果是过去，则抛出异常</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotInPast(DateTime? argument, string argumentName, string message = null)
        {
            IsNotInPast(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查时间是否为未来
        /// <para>如果是未来，则抛出异常</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotInFuture(DateTime argument, string argumentName, string message = null)
        {
            if (argument > DateTime.UtcNow)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be in future.");
            }
        }

        /// <summary>
        /// 检查时间是否为未来
        /// <para>如果是未来，则抛出异常</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotInFuture(DateTime? argument, string argumentName, string message = null)
        {
            IsNotInFuture(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查时间间隔是否为负
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(TimeSpan argument, string argumentName, string message = null)
        {
            if (argument < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
            }
        }

        /// <summary>
        /// 检查时间间隔是否为负
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(TimeSpan? argument, string argumentName, string message = null)
        {
            IsNotNegative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查时间间隔是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(TimeSpan argument, string argumentName, string message = null)
        {
            if (argument <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
            }
        }

        /// <summary>
        /// 检查时间间隔是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(TimeSpan? argument, string argumentName, string message = null)
        {
            IsNotNegativeOrZero(argument.SafeValue(), argumentName, message);
        }
    }
}
