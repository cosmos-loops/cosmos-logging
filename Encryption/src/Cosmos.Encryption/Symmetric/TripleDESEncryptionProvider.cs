using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core;

namespace Cosmos.Encryption.Symmetric {
    /// <summary>
    /// Symmetric/TripleDES encryption.
    /// Author: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Symmetric/TripleDES.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class TripleDESEncryptionProvider : SymmetricEncyptionBase {
        private TripleDESEncryptionProvider() { }

        /// <summary>
        /// TripleDES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="keySize">The size only can be 128, 192.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="iv">The initialization iv (IV) to use to derive the key.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(
            string data,
            string password = null,
            string iv = null,
            string salt = null,
            Encoding encoding = null,
            TripleDESKeySizeTypes keySize = TripleDESKeySizeTypes.L192) {
            return EncryptCore<TripleDESCryptoServiceProvider>(data, password, iv, salt, encoding, (int) keySize, 64);
        }
        
        /// <summary>
        /// TripleDES decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="keySize">The size only can be 128, 192.</param>
        /// <param name="iv">The initialization vector (IV) to use to derive the key.</param>
        /// <returns>The decryption string.</returns>
        public static string Decrypt(
            string data,
            string password = null,
            string iv = null,
            string salt = null,
            Encoding encoding = null,
            TripleDESKeySizeTypes keySize = TripleDESKeySizeTypes.L192) {
            return EncryptCore<TripleDESCryptoServiceProvider>(data, password, iv, salt, encoding, (int) keySize, 64);
        }
    }
}