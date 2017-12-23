using System;
using System.Text;

namespace Cosmos.Encryption {
    public static class Base64EncryptProvicer {
        /// <summary>
        /// Base64 encryption.
        /// Author: Seay Xu
        ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Base64.cs
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, Encoding encoding = null) {
            if (data == null) {
                throw new ArgumentNullException(nameof(data));
            }

            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            return Convert.ToBase64String(encoding.GetBytes(data));
        }

        /// <summary>
        /// Base64 decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The decrypted string.</returns>
        public static string Decrypt(string data, Encoding encoding = null) {
            if (data == null) {
                throw new ArgumentNullException(nameof(data));
            }

            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            return encoding.GetString(Convert.FromBase64String(data));
        }
    }
}