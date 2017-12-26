using System;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Md5 hashing provider
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Hash/MD5.cs
    /// Editor: AlexLEWIS
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class MD5HashingProvider {
        /// <summary>
        /// MD5 encrypt mehtod,default encrypt string is 32 bits.
        /// </summary>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="bits">Encrypt string bits number,only 16,32,64.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>Encrypt string.</returns>
        public static string Signature(string data, MD5BitTypes bits = MD5BitTypes.L32, Encoding encoding = null) {
            if (data == null) {
                throw new ArgumentNullException(nameof(data));
            }

            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            switch (bits) {
                case MD5BitTypes.L16:
                    return Encrypt16Func()(data)(encoding);

                case MD5BitTypes.L32:
                    return Encrypt32Func()(data)(encoding);

                case MD5BitTypes.L64:
                    return Encrypt64Func()(data)(encoding);

                default:
                    throw new ArgumentOutOfRangeException(nameof(bits), bits, null);
            }
        }

        private static Func<string, Func<Encoding, string>> Encrypt16Func() =>
            str => encoding => BitConverter.ToString(PreencryptFunc()(str)(encoding), 4, 8).Replace("-", "");

        private static Func<string, Func<Encoding, string>> Encrypt32Func() => str => encoding => {
            var bytes = PreencryptFunc()(str)(encoding);
            var sbStr = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes) {
                sbStr.Append(b.ToString("X2"));
            }

            return sbStr.ToString();
        };

        private static Func<string, Func<Encoding, string>> Encrypt64Func() =>
            str => encoding => Convert.ToBase64String(PreencryptFunc()(str)(encoding));

        private static Func<string, Func<Encoding, byte[]>> PreencryptFunc() => str => encoding => {
            using (var md5 = MD5.Create()) {
                return md5.ComputeHash(encoding.GetBytes(str));
            }
        };

        /// <summary>
        /// Verify 
        /// </summary>
        /// <param name="comparison"></param>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="bits">Encrypt string bits number,only 16,32,64.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static bool Verify(string comparison, string data, MD5BitTypes bits = MD5BitTypes.L32, Encoding encoding = null)
            => comparison == Signature(data, bits, encoding);
    }
}