using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cosmos.Extensions;

namespace Cosmos
{
    /// <summary>
    /// Arguments checking
    /// </summary>
    public static partial class Preconditions
    {
        /// <summary>
        /// 检查对象是否为空
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNull(object argument, string argumentName, string message = null)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message ?? $"{nameof(argument)} can not be null.");
            }
        }

        /// <summary>
        /// 检查集合是否为空
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNull(IEnumerable argument, string argumentName, string message = null)
        {
            if (Judgements.CollectionJudgement.IsNull(argument))
            {
                throw new ArgumentNullException(argumentName, message ?? $"{nameof(argument)} can not be null.");
            }
        }

        /// <summary>
        /// 检查集合是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotEmpty(IEnumerable argument, string argumentName, string message = null)
        {
            if (Judgements.CollectionJudgement.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(argumentName,
                    message ?? $"{nameof(argument)} can not be null or empty.");
            }
        }

        /// <summary>
        /// 检查集合至少包含多少个元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="number"></param>
        /// <param name="message"></param>
        public static void IsAtLeast<T>(ICollection<T> argument, string argumentName, int number, string message = null)
        {
            if (!Judgements.CollectionJudgement.ContainsAtLeast(argument, number))
            {
                throw new ArgumentOutOfRangeException(argumentName,
                    message ?? $"{nameof(argument)} should has {number} items at least.");
            }
        }

        /// <summary>
        /// 检查 Guid 是否为空
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotEmpty(Guid argument, string argumentName, string message = null)
        {
            if (Judgements.GuidJudgement.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(argumentName,
                    message ?? $"{nameof(argument)} can not be null or empty.");
            }
        }

        /// <summary>
        /// 检查 Guid? 是否为空
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotEmpty(Guid? argument, string argumentName, string message = null)
        {
            IsNotEmpty(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查字符串是否为 Blank
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotEmpty(string argument, string argumentName, string message = null)
        {
            if (string.IsNullOrWhiteSpace((argument ?? string.Empty).Trim()))
            {
                throw new ArgumentNullException(argumentName, message ?? $"{nameof(argument)} can not be blank.");
            }
        }

        /// <summary>
        /// 检查字符串是否为 Blank
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotBlank(string argument, string argumentName, string message = null)
        {
            IsNotEmpty(argument, argumentName, message);
        }

        /// <summary>
        /// 检查字符串长度是否超界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="length"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfLength(string argument, int length, string argumentName, string message = null)
        {
            if (argument.Trim().Length > length)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument.Trim().Length,
                    message ?? $"{nameof(argument)}'s length can not be greater than {length}.");
            }
        }

    }
}