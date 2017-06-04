using System;
using Cosmos.Extensions;

namespace Cosmos
{
    /// <summary>
    /// Numeric arguments checking
    /// </summary>
    public static partial class Arguments
    {
        /// <summary>
        /// 检查整数是否为负
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(int argument, string argumentName, string message = null)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
            }
        }

        /// <summary>
        /// 检查整数是否为负
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(int? argument, string argumentName, string message = null)
        {
            IsNotNegative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查整数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(int argument, string argumentName, string message = null)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
            }
        }

        /// <summary>
        /// 检查整数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(int? argument, string argumentName, string message = null)
        {
            IsNotNegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查整数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(int argument, int min, int max, string argumentName, string message = null)
        {
            if (!Judgements.NumericJudgement.IsBetween(argument, min, max))
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
            }
        }

        /// <summary>
        /// 检查整数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(int? argument, int min, int max, string argumentName, string message = null)
        {
            IsNotOutOfRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// 检查长整数是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(long argument, string argumentName, string message = null)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
            }
        }

        /// <summary>
        /// 检查长整数是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(long? argument, string argumentName, string message = null)
        {
            IsNotNegative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查长整数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(long argument, string argumentName, string message = null)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
            }
        }

        /// <summary>
        /// 检查长整数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(long? argument, string argumentName, string message = null)
        {
            IsNotNegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查长整数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(long argument, long min, long max, string argumentName, string message = null)
        {
            if (!Judgements.NumericJudgement.IsBetween(argument, min, max))
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
            }
        }

        /// <summary>
        /// 检查长整数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(long? argument, long min, long max, string argumentName, string message = null)
        {
            IsNotOutOfRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// 检查单精度浮点数是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(float argument, string argumentName, string message = null)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
            }
        }

        /// <summary>
        /// 检查单精度浮点数是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(float? argument, string argumentName, string message = null)
        {
            IsNotNegative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查单精度浮点数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(float argument, string argumentName, string message = null)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
            }
        }

        /// <summary>
        /// 检查单精度浮点数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(float? argument, string argumentName, string message = null)
        {
            IsNotNegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查单精度浮点数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(float argument, float min, float max, string argumentName, string message = null)
        {
            if (!Judgements.NumericJudgement.IsBetween(argument, min, max))
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
            }
        }

        /// <summary>
        /// 检查单精度浮点数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(float? argument, float min, float max, string argumentName, string message = null)
        {
            IsNotOutOfRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// 检查双精度浮点数是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(double argument, string argumentName, string message = null)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
            }
        }

        /// <summary>
        /// 检查双精度浮点数是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(double? argument, string argumentName, string message = null)
        {
            IsNotNegative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查双精度浮点数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(double argument, string argumentName, string message = null)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
            }
        }

        /// <summary>
        /// 检查双精度浮点数是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(double? argument, string argumentName, string message = null)
        {
            IsNotNegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查多精度浮点数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(double argument, double min, double max, string argumentName, string message = null)
        {
            if (!Judgements.NumericJudgement.IsBetween(argument, min, max))
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
            }
        }

        /// <summary>
        /// 检查多精度浮点数是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(double? argument, double min, double max, string argumentName, string message = null)
        {
            IsNotOutOfRange(argument.SafeValue(), min, max, argumentName, message);
        }

        /// <summary>
        /// 检查 Decimal 是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(decimal argument, string argumentName, string message = null)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative.");
            }
        }

        /// <summary>
        /// 检查 Decimal 是否为负数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegative(decimal? argument, string argumentName, string message = null)
        {
            IsNotNegative(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查 Decimal 是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(decimal argument, string argumentName, string message = null)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} can not be negative or zero.");
            }
        }

        /// <summary>
        /// 检查 Decimal 是否为非正数
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotNegativeOrZero(decimal? argument, string argumentName, string message = null)
        {
            IsNotNegativeOrZero(argument.SafeValue(), argumentName, message);
        }

        /// <summary>
        /// 检查 Decimal 是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(decimal argument, decimal min, decimal max, string argumentName, string message = null)
        {
            if (!Judgements.NumericJudgement.IsBetween(argument, min, max))
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, message ?? $"{nameof(argument)} is not between {min} and {max}.");
            }
        }

        /// <summary>
        /// 检查 Decimal 是否越界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void IsNotOutOfRange(decimal? argument, decimal min, decimal max, string argumentName, string message = null)
        {
            IsNotOutOfRange(argument.SafeValue(), min, max, argumentName, message);
        }
    }
}
