using System;
using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Symmetric/TripleDES encryption.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Symmetric/TripleDES.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public sealed class TripleDESEncryptionProvider : SymmetricEncyptionBase {
        private TripleDESEncryptionProvider() { }

        public static TripleDESKey CreateKey(TripleDESKeySizeTypes keySize = TripleDESKeySizeTypes.L192, Encoding encoding = null) {
            if (encoding == null) encoding = Encoding.UTF8;
            using (var provider = new TripleDESCryptoServiceProvider()) {
                return new TripleDESKey {
                    Key = encoding.GetString(provider.Key),
                    IV = encoding.GetString(provider.IV),
                };
            }
        }

        /// <summary>
        /// TripleDES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="pwd">The password to derive the key for.</param>
        /// <param name="keySize">The size only can be 128, 192.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="iv">The initialization iv (IV) to use to derive the key.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, string pwd = null, string iv = null, string salt = null, Encoding encoding = null,
            TripleDESKeySizeTypes keySize = TripleDESKeySizeTypes.L192) {
            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(pwd)) {
                throw new ArgumentNullException(nameof(pwd));
            }

            if (string.IsNullOrEmpty(iv)) {
                throw new ArgumentNullException(nameof(iv));
            }

            if (encoding == null) encoding = Encoding.UTF8;

            //return EncryptCore<DESCryptoServiceProvider>(data, pwd, iv, salt, encoding, 64, 64);
            return Convert.ToBase64String(NiceEncryptCore<TripleDESCryptoServiceProvider>(encoding.GetBytes(data),
                ComputeRealValueFunc()(pwd)(salt)(encoding)((int) keySize),
                ComputeRealValueFunc()(iv)(salt)(encoding)(64)));
            //return ""; //EncryptCore<TripleDESCryptoServiceProvider>(data, password, iv, salt, encoding, (int) keySize, 64, mode);
        }

        /// <summary>
        /// TripleDES decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="pwd">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="keySize">The size only can be 128, 192.</param>
        /// <param name="iv">The initialization vector (IV) to use to derive the key.</param>
        /// <returns>The decryption string.</returns>
        public static string Decrypt(string data, string pwd = null, string iv = null, string salt = null, Encoding encoding = null,
            TripleDESKeySizeTypes keySize = TripleDESKeySizeTypes.L192) {
            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(pwd)) {
                throw new ArgumentNullException(nameof(pwd));
            }

            if (string.IsNullOrEmpty(iv)) {
                throw new ArgumentNullException(nameof(iv));
            }

            if (encoding == null) encoding = Encoding.UTF8;


            return encoding.GetString(NiceDecryptCore<TripleDESCryptoServiceProvider>(Convert.FromBase64String(data),
                ComputeRealValueFunc()(pwd)(salt)(encoding)((int) keySize),
                ComputeRealValueFunc()(iv)(salt)(encoding)(64)));
            //return ""; //NiceEncryptCore<TripleDESCryptoServiceProvider>(data, password, iv, salt, encoding, (int) keySize, 64, mode);
        }
    }
}