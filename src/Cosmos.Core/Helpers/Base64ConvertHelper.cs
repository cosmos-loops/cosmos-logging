using System;
using System.Text;

namespace Cosmos.Helpers
{
    /// <summary>
    /// Base64 convert helper
    /// </summary>
    public static class Base64ConvertHelper
    {
        /// <summary>
        /// Convert from base64 string to string
        /// </summary>
        /// <param name="base64String"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToString(string base64String, Encoding encoding)
        {
            return encoding.GetString(Convert.FromBase64String(base64String));
        }

        /// <summary>
        /// Convert from bytes to base64 string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] str)
        {
            return Convert.ToBase64String(str);
        }

        /// <summary>
        /// Convert from string to base64 string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToBase64String(string str, Encoding encoding)
        {
            return ToBase64String(encoding.GetBytes(str));
        }
    }
}
