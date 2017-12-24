using System;
using System.Security.Cryptography;
using System.Text;

namespace Cosmos.Encryption.Core {
    /// <summary>
    /// Abstrace Symmetric/SymmetricEncyptionBase encryption.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Symmetric/XES.cs
    ///  Editor: AlexLEWIS
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public abstract class SymmetricEncyptionBase {
        /// <summary>
        /// 用于整理获得真实 key / iv 的方法
        /// </summary>
        private static Func<string, Func<string, Func<Encoding, Func<int, byte[]>>>>
            ComputeRealValueFunc() => originString => salt => encoding => size => {
            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            var len = size / 8;

            if (string.IsNullOrWhiteSpace(salt)) {
                var retBytes = new byte[len];
                Array.Copy(encoding.GetBytes(originString.PadRight(len)), retBytes, len);
                return retBytes;
            }

            var saltBytes = encoding.GetBytes(salt);
            var rfcOriginStringData = new Rfc2898DeriveBytes(encoding.GetBytes(originString), saltBytes, 1000);
            return rfcOriginStringData.GetBytes(size);
        };

        protected static string EncryptCore<T>(string data, string pwd, string iv, string salt = null, Encoding encoding = null,
            int keySize = 128, int blockSize = 128)
            where T : SymmetricAlgorithm, new() {
            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            byte[] encrypted;
            using (SymmetricAlgorithm cipher = new T()) {
                cipher.Mode = CipherMode.ECB;
                cipher.Key = ComputeRealValueFunc()(pwd)(salt)(encoding)(keySize);
                cipher.KeySize = keySize;
                if (!string.IsNullOrWhiteSpace(iv)) {
                    cipher.IV = ComputeRealValueFunc()(iv)(salt)(encoding)(blockSize);
                    cipher.BlockSize = blockSize;
                }

                using (ICryptoTransform encryptor = cipher.CreateEncryptor()) {
                    var valueBytes = encoding.GetBytes(data);
                    encrypted = encryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
                }

                cipher.Clear();
            }

            return Convert.ToBase64String(encrypted);
        }

        protected static string DecryptCore<T>(string data, string pwd, string iv, string salt = null, Encoding encoding = null,
            int keySize = 128, int blockSize = 128)
            where T : SymmetricAlgorithm, new() {
            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            byte[] decrypted;
            using (SymmetricAlgorithm cipher = new T()) {
                cipher.Mode = CipherMode.ECB;
                cipher.Key = ComputeRealValueFunc()(pwd)(salt)(encoding)(keySize);
                cipher.KeySize = keySize;
                if (!string.IsNullOrWhiteSpace(iv)) {
                    cipher.IV = ComputeRealValueFunc()(iv)(salt)(encoding)(blockSize);
                    cipher.BlockSize = blockSize;
                }

                using (ICryptoTransform decryptor = cipher.CreateDecryptor()) {
                    var valueBytes = encoding.GetBytes(data);
                    decrypted = decryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
                }

                cipher.Clear();
            }

            return encoding.GetString(decrypted);
        }
    }
}