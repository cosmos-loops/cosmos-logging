using System;
using System.IO;
using System.Runtime.CompilerServices;
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
        protected static Func<string, Func<string, Func<Encoding, Func<int, byte[]>>>>
            ComputeRealValueFunc() => originString => salt => encoding => size => {
            if (string.IsNullOrWhiteSpace(originString)) {
                return new byte[0];
            }

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
            return rfcOriginStringData.GetBytes(len);
        };

        protected static byte[] NiceEncryptCore<TCryptoServiceProvider>(byte[] sourceBytes, byte[] keyBytes, byte[] ivBytes)
            where TCryptoServiceProvider : SymmetricAlgorithm, new() {
            using (var provider = new TCryptoServiceProvider()) {
                provider.Key = keyBytes;
                provider.IV = ivBytes;
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cs.Write(sourceBytes, 0, sourceBytes.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }

        protected static byte[] NiceDecryptCore<TCryptoServiceProvider>(byte[] encryptBytes, byte[] keyBytes, byte[] ivBytes)
            where TCryptoServiceProvider : SymmetricAlgorithm, new() {
            using (var provider = new TCryptoServiceProvider()) {
                provider.Key = keyBytes;
                provider.IV = ivBytes;
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write)) {
                        cs.Write(encryptBytes, 0, encryptBytes.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }
    }
}