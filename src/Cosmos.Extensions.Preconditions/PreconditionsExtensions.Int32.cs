namespace Cosmos
{
    /// <summary>
    /// Integer arguments checking extensions
    /// </summary>
    public static partial class PreconditionsExtensions
    {
        /// <summary>
        /// 检查指定数字是否超界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckOutOfRange(this int argument, int min, int max, string argumentName, string message = null)
            => Preconditions.IsNotOutOfRange(argument, min, max, argumentName, message);

        /// <summary>
        /// 检查指定数字是否超界
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckOutOfRange(this int? argument, int min, int max, string argumentName, string message = null)
            => Preconditions.IsNotOutOfRange(argument, min, max, argumentName, message);

        /// <summary>
        /// 检查整型是否为负
        /// <para>如果为负则抛出 ArgumentOutOfRangeException</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegative(this int argument, string argumentName, string message = null)
            => Preconditions.IsNotNegative(argument, argumentName, message);

        /// <summary>
        /// 检查整型是否为负
        /// <para>如果为负则抛出 ArgumentOutOfRangeException</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegative(this int? argument, string argumentName, string message = null)
            => Preconditions.IsNotNegative(argument, argumentName, message);

        /// <summary>
        /// 检查整型是否为负或为零
        /// <para>如果为负或为零则抛出 ArgumentOutOfRangeException</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegativeOrZero(this int argument, string argumentName, string message = null)
            => Preconditions.IsNotNegativeOrZero(argument, argumentName, message);

        /// <summary>
        /// 检查整型是否为负或为零
        /// <para>如果为负或为零则抛出 ArgumentOutOfRangeException</para>
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNegativeOrZero(this int? argument, string argumentName, string message = null)
            => Preconditions.IsNotNegativeOrZero(argument, argumentName, message);
    }
}
