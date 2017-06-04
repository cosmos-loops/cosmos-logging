using System;
using System.Text;

namespace Cosmos
{
    /// <summary>
    /// Random NonceStr Provider
    /// </summary>
    public static class RandomNonceStrProvider
    {
        // ReSharper disable once InconsistentNaming
        private const string NONCESTR = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// Create random noncestr
        /// </summary>
        /// <returns></returns>
        public static string Create()
        {
            return Create(16);
        }

        /// <summary>
        /// Create random noncestr
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Create(int length)
        {
            if (length <= 16)
            {
                length = 16;
            }

            var sb = new StringBuilder();
            var rd = new Random();

            for (var i = 0; i < length; i++)
                sb.Append(NONCESTR[rd.Next(NONCESTR.Length - 1)]);

            return sb.ToString();
        }
    }
}
