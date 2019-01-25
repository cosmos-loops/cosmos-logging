using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Cosmos.Encryption.Core.Internals.Extensions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Encryption
{
    /// <summary>
    /// Asymmetric/RSA encryption.
    /// Reference: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Asymmetric/RSA.cs
    /// Reference: myloveCc
    ///     https://github.com/myloveCc/NETCore.Encrypt/blob/master/src/NETCore.Encrypt/EncryptProvider.cs
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class RSAEncryptionProvider
    {
        public static RSAKey CreateKey(RSAKeySizeTypes size = RSAKeySizeTypes.R2048, RSAKeyTypes keyType = RSAKeyTypes.XML, bool format = false)
        {
            switch (keyType)
            {
                case RSAKeyTypes.Pkcs1:
                    return Core.RSAKeyGenerator.Pkcs1Key((int) size, format);

                case RSAKeyTypes.Pkcs8:
                    return Core.RSAKeyGenerator.Pkcs8Key((int) size, format);

                case RSAKeyTypes.XML:
                    return Core.RSAKeyGenerator.XmlKey((int) size);

                case RSAKeyTypes.JSON:
                    return Core.RSAKeyGenerator.JsonKey((int) size);

                default:
                    return Core.RSAKeyGenerator.XmlKey((int) size);
            }
        }

        public static RSA CreateFromXmlKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var rsa = RSA.Create();
            rsa.FromLvccXmlString(key);
            return rsa;
        }

        public static RSA CreateFromJsonKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var rsa = RSA.Create();
            rsa.FromJsonString(key);
            return rsa;
        }

        public static RSA CreateFromPkcs1PublicKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var rsa = RSA.Create();
            rsa.FromPkcs1PublicString(key, out _);
            return rsa;
        }

        public static RSA CreateFromPkcs1PrivateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var rsa = RSA.Create();
            rsa.FromPkcs1PrivateString(key, out _);
            return rsa;
        }

        public static RSA CreateFromPkcs8PublicKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var rsa = RSA.Create();
            rsa.FromPkcs8PublicString(key, out _);
            return rsa;
        }

        public static RSA CreateFromPkcs8PrivateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var rsa = RSA.Create();
            rsa.FromPkcs8PrivateString(key, out _);
            return rsa;
        }

        /// <summary>
        /// Get private key of xml format from certificate file.
        /// </summary>
        /// <param name="certFile">The string path of certificate file.</param>
        /// <param name="password">The string password of certificate file.</param>
        /// <returns>String private key of xml format.</returns>
        public static string GetPrivateKey(string certFile, string password)
        {
            if (!File.Exists(certFile))
            {
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
        public static string GetPublicKey(string certFile)
        {
            if (!File.Exists(certFile))
            {
                throw new FileNotFoundException(nameof(certFile));
            }

            var cert = new X509Certificate2(certFile);
            return cert.PublicKey.Key.ToXmlString(false);
        }
    }
}