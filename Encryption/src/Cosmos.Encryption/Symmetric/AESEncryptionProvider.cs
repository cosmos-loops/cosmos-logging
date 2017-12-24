using System;
using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core;

namespace Cosmos.Encryption.Symmetric {
    /// <summary>
    /// Symmetric/AES encryption.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Symmetric/AES.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class AESEncryptionProvider : SymmetricEncyptionBase {
        private AESEncryptionProvider() { }

        /// <summary>
        /// Create an AES key.
        /// </summary>
        /// <returns></returns>
        public static AESKey CreateKey(AESKeySizeTypes size = AESKeySizeTypes.L256, Encoding encoding = null) {
            if (encoding == null) encoding = Encoding.UTF8;
            using (var provider = new AesCryptoServiceProvider {KeySize = (int) size}) {
                return new AESKey {
                    Key = encoding.GetString(provider.Key),
                    IV = encoding.GetString(provider.IV),
                    Size = size
                };
            }
        }

        /// <summary>
        /// AES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="keySize">The size only can be 128, 192, or 256</param>
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
            AESKeySizeTypes keySize = AESKeySizeTypes.L256) {
            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            return EncryptCore<RijndaelManaged>(data, password, iv, salt, encoding, (int) keySize, 128);
        }


        /// <summary>
        /// AES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">your key.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static string Encrypt(string data, AESKey key, Encoding encoding = null) {
            if (key == null) {
                throw new ArgumentNullException(nameof(key));
            }

            return Encrypt(data, key.Key, key.IV, encoding: encoding, keySize: key.Size);
        }

        /// <summary>
        /// AES decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="keySize">The size only can be 128, 192, or 256</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="iv">The initialization iv (IV) to use to derive the key.</param>
        /// <returns>The decryption string.</returns>
        public static string Decrypt(
            string data,
            string password = null,
            string iv = null,
            string salt = null,
            Encoding encoding = null,
            AESKeySizeTypes keySize = AESKeySizeTypes.L256) {
            return EncryptCore<RijndaelManaged>(data, password, iv, salt, encoding, (int) keySize, 128);
        }

        /// <summary>
        /// AES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">your key.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static string Decrypt(string data, AESKey key, Encoding encoding = null) {
            if (key == null) {
                throw new ArgumentNullException(nameof(key));
            }

            return Decrypt(data, key.Key, key.IV, encoding: encoding, keySize: key.Size);
        }
    }
}