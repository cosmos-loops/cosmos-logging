using System;
using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core;
using Cosmos.Encryption.Core.Internals;

namespace Cosmos.Encryption.Symmetric {
    /// <summary>
    /// Symmetric/DES encryption.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Symmetric/DES.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class DESEncryptionProvider : SymmetricEncyptionBase {
        private DESEncryptionProvider() { }

        public static DESKey CreateKey() {
            return new DESKey {
                Key = RandomStringGenerator.Generate(),
                IV = RandomStringGenerator.Generate()
            };
        }

        /// <summary>
        /// DES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="iv">The initialization vector (IV) to use to derive the key.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(
            string data,
            string password = null,
            string iv = null,
            string salt = null,
            Encoding encoding = null) {
            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(password)) {
                throw new ArgumentNullException(nameof(password));
            } 

            return EncryptCore<DESCryptoServiceProvider>(data, password, iv, salt, encoding, 64, 64);
        }

        /// <summary>
        /// DES decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="iv">The initialization vector (IV) to use to derive the key.</param>
        /// <returns>The decryption string.</returns>
        public static string Decrypt(
            string data,
            string password = null,
            string iv = null,
            string salt = null,
            Encoding encoding = null) {
            return EncryptCore<DESCryptoServiceProvider>(data, password, iv, salt, encoding, 64, 64);
        }
    }
}