using System.Text;
using Cosmos.Encryption.Core.Internals.Extensions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    // ReSharper disable once InconsistentNaming
    public static class MD4HashingProvider {
        public static string Signature(string data, Encoding encoding = null) {
            return SignatureHash(data, encoding).ToHexString();
        }

        public static string Signature(byte[] data) {
            return Core(data).ToHexString();
        }

        public static byte[] SignatureHash(string data, Encoding encoding = null) {
            if (encoding == null) encoding = Encoding.UTF8;
            return Core(encoding.GetBytes(data));
        }

        public static byte[] SignatureHash(byte[] data) {
            return Core(data);
        }

        private static byte[] Core(byte[] buffer) {
            using (var md4 = new MD4CryptoServiceProvider()) {
                return md4.ComputeHash(buffer);
            }
        }

        /// <summary>
        /// Verify 
        /// </summary>
        /// <param name="comparison"></param>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static bool Verify(string comparison, string data, Encoding encoding = null)
            => comparison == Signature(data, encoding);
    }
}