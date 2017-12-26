using System;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Asymmetric/DSA encryption.
    /// Reference: X-New-Life
    ///     https://github.com/NewLifeX/X/blob/master/NewLife.Core/Security/DSAHelper.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class DSAEncryptionProvider {
        public static DSAKey CreateKey(int keySize = 1024) {
            using (var provider = new DSACryptoServiceProvider(keySize)) {
                var key = new DSAKey();
                var pa = provider.ExportParameters(true);
                key.PrivateKey = provider.ToXmlString(true);
                key.PublicKey = provider.ToXmlString(false);
                return key;
            }
        }

        public static byte[] Signature(byte[] buffer, string privateKey) {
            using (var provider = new DSACryptoServiceProvider()) {
                provider.FromXmlString(privateKey);
                return provider.SignData(buffer);
            }
        }

        public static byte[] Signature(byte[] buffer, DSAKey key) {
            if (key == null) {
                throw new ArgumentNullException(nameof(key));
            }

            return Signature(buffer, key.PrivateKey);
        }

        public static byte[] Signature(string data, string privateKey, Encoding encoding = null) {
            if (encoding == null) encoding = Encoding.UTF8;
            return Signature(encoding.GetBytes(data), privateKey);
        }

        public static byte[] Signature(string data, DSAKey key, Encoding encoding = null) {
            if (encoding == null) encoding = Encoding.UTF8;
            return Signature(encoding.GetBytes(data), key);
        }

        public static bool Verify(byte[] buffer, string publicKey, byte[] rgbSignature) {
            using (var provider = new DSACryptoServiceProvider()) {
                provider.FromXmlString(publicKey);
                return provider.VerifyData(buffer, rgbSignature);
            }
        }

        public static bool Verify(byte[] buffer, DSAKey key, byte[] rgbSignature) {
            if (key == null) {
                throw new ArgumentNullException(nameof(key));
            }

            return Verify(buffer, key.PublicKey, rgbSignature);
        }
    }
}