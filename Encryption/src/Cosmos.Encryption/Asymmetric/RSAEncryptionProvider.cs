using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Cosmos.Encryption.Core.Internals.Extensions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption {
    /// <summary>
    /// Asymmetric/RSA encryption.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Asymmetric/RSA.cs
    /// Reference: myloveCc
    ///     https://github.com/myloveCc/NETCore.Encrypt/blob/master/src/NETCore.Encrypt/EncryptProvider.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class RSAEncryptionProvider {
        public static RSAKey CreateKey(RSAKeySizeTypes size = RSAKeySizeTypes.R2048, RSAKeyTypes keyType = RSAKeyTypes.XML) {
            using (var rsa = new RSACryptoServiceProvider((int) size)) {
                var publicKey = keyType == RSAKeyTypes.JSON
                    ? rsa.ToJsonString(false)
                    : rsa.ToLvccXmlString(false);

                var privateKey = keyType == RSAKeyTypes.JSON
                    ? rsa.ToJsonString(true)
                    : rsa.ToLvccXmlString(true);

                return new RSAKey {
                    PublicKey = publicKey,
                    PrivateKey = privateKey,
                    Exponent = rsa.ExportParameters(false).Exponent.ToHexString(),
                    Modulus = rsa.ExportParameters(false).Modulus.ToHexString()
                };
            }
        }

        /// <summary>
        /// Rsa from xml or json string
        /// </summary>
        /// <param name="rsaKey"></param>
        /// <param name="keyType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static RSA RSAFromString(string rsaKey, RSAKeyTypes keyType = RSAKeyTypes.XML) {
            if (string.IsNullOrEmpty(rsaKey)) {
                throw new ArgumentNullException(nameof(rsaKey));
            }

            var rsa = RSA.Create();
            if (keyType == RSAKeyTypes.XML) {
                rsa.FromLvccXmlString(rsaKey);
            } else {
                rsa.FromJsonString(rsaKey);
            }

            return rsa;
        }

        /// <summary>
        /// Get private key of xml format from certificate file.
        /// </summary>
        /// <param name="certFile">The string path of certificate file.</param>
        /// <param name="password">The string password of certificate file.</param>
        /// <returns>String private key of xml format.</returns>
        public static string GetPrivateKey(string certFile, string password) {
            if (!File.Exists(certFile)) {
                throw new FileNotFoundException(nameof(certFile));
            }

            var cert = new X509Certificate2(certFile, password, X509KeyStorageFlags.Exportable);
            return cert.PrivateKey.ToXmlString(true);
        }

        /// <summary>
        /// Get public key of xml format from certificate file.
        /// </summary>
        /// <param name="certFile">The string path of certificate file.</param>
        /// <returns>String public key of xml format.</returns>
        public static string GetPublicKey(string certFile) {
            if (!File.Exists(certFile)) {
                throw new FileNotFoundException(nameof(certFile));
            }

            var cert = new X509Certificate2(certFile);
            return cert.PublicKey.Key.ToXmlString(false);
        }

        /// <summary>
        /// Encrypt string data with xml/json format.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="publicKey">The public key of xml format.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="keyType"></param>
        /// <returns>The encrypted data.</returns>
        public static string Encrypt(string data, string publicKey, Encoding encoding = null, RSAKeyTypes keyType = RSAKeyTypes.XML) {
            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            return Encrypt(encoding.GetBytes(data), publicKey, keyType);
        }

        /// <summary>
        /// Encrypt byte[] data with xml/json format.
        /// </summary>
        /// <param name="dataBytes">The data to be encrypted.</param>
        /// <param name="publicKey">The public key of xml format.</param>
        /// <param name="keyType"></param>
        /// <returns>The encrypted data.</returns>
        public static string Encrypt(byte[] dataBytes, string publicKey, RSAKeyTypes keyType = RSAKeyTypes.XML) {
            using (var rsa = new RSACryptoServiceProvider()) {
                if (keyType == RSAKeyTypes.XML) {
                    rsa.FromLvccXmlString(publicKey);
                } else {
                    rsa.FromJsonString(publicKey);
                }

                return Convert.ToBase64String(rsa.Encrypt(dataBytes, false));
            }
        }

        /// <summary>
        /// Decrypt string data with xml/json format.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="privateKey">The private key of xml format.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="keyType"></param>
        /// <returns>The decrypted data.</returns>
        public static string Decrypt(string data, string privateKey, Encoding encoding = null, RSAKeyTypes keyType = RSAKeyTypes.XML) {
            return Decrypt(Convert.FromBase64String(data), privateKey, encoding, keyType);
        }

        /// <summary>
        /// Decrypt byte[] data with xml/json format.
        /// </summary>
        /// <param name="dataBytes">The data to be encrypted.</param>
        /// <param name="privateKey">The private key of xml format.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="keyType"></param>
        /// <returns>The decrypted data.</returns>
        public static string Decrypt(byte[] dataBytes, string privateKey, Encoding encoding = null, RSAKeyTypes keyType = RSAKeyTypes.XML) {
            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            using (var rsa = new RSACryptoServiceProvider()) {
                if (keyType == RSAKeyTypes.XML) {
                    rsa.FromLvccXmlString(privateKey);
                } else {
                    rsa.FromJsonString(privateKey);
                }

                return encoding.GetString(rsa.Decrypt(dataBytes, false));
            }
        }

        #region Get hash sign

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hash"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static bool GetHash(string data, ref byte[] hash, Encoding encoding = null) {
            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            hash = HashStringFunc()(data)(encoding);
            return true;
        }

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hash"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public static bool GetHash(string data, ref string hash, Encoding encoding = null) {
            if (encoding == null) {
                encoding = Encoding.UTF8;
            }

            hash = Convert.ToBase64String(HashStringFunc()(data)(encoding));
            return true;
        }

        private static Func<string, Func<Encoding, byte[]>> HashStringFunc() =>
            data => encoding => HashAlgorithm.Create("MD5").ComputeHash(encoding.GetBytes(data));

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool GetHash(FileStream fs, ref byte[] hash) {
            hash = HashFileFunc()(fs);
            return true;
        }

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool GetHash(FileStream fs, ref string hash) {
            hash = Convert.ToBase64String(HashFileFunc()(fs));
            return true;
        }

        private static Func<FileStream, byte[]> HashFileFunc() => fs => {
            var ret = HashAlgorithm.Create("MD5").ComputeHash(fs);
            fs.Close();
            return ret;
        };

        #endregion
    }
}