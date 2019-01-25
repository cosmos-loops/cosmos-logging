using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core;

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
        /// <summary>
        /// Encrypt string data with xml/json format.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="publicKey">The public key of xml format.</param>
        /// <param name="padding"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="sizeType"></param>
        /// <param name="keyType"></param>
        /// <returns>The encrypted data.</returns>
        public static string Encrypt(
            string data,
            string publicKey,
            RSAEncryptionPadding padding,
            Encoding encoding = null,
            RSAKeySizeTypes sizeType = RSAKeySizeTypes.R2048,
            RSAKeyTypes keyType = RSAKeyTypes.XML)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            switch (keyType)
            {
                case RSAKeyTypes.XML:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(data, padding);
                }

                case RSAKeyTypes.JSON:
                {
                    var util = new RSAJsonUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(data, padding);
                }

                case RSAKeyTypes.Pkcs1:
                {
                    var util = new RSAPkcs1Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(data, padding);
                }

                case RSAKeyTypes.Pkcs8:
                {
                    var util = new RSAPkcs8Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(data, padding);
                }

                default:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(data, padding);
                }
            }
        }

        /// <summary>
        /// Encrypt byte[] data with xml/json format.
        /// </summary>
        /// <param name="dataBytes">The data to be encrypted.</param>
        /// <param name="publicKey">The public key of xml format.</param>
        /// <param name="sizeType"></param>
        /// <param name="keyType"></param>
        /// <param name="padding"></param>
        /// <returns>The encrypted data.</returns>
        public static string Encrypt(
            byte[] dataBytes,
            string publicKey,
            RSAEncryptionPadding padding,
            RSAKeySizeTypes sizeType = RSAKeySizeTypes.R2048,
            RSAKeyTypes keyType = RSAKeyTypes.XML)
        {
            switch (keyType)
            {
                case RSAKeyTypes.XML:
                {
                    var util = new RSAXmlUtil(Encoding.UTF8, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(dataBytes, padding);
                }

                case RSAKeyTypes.JSON:
                {
                    var util = new RSAJsonUtil(Encoding.UTF8, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(dataBytes, padding);
                }

                case RSAKeyTypes.Pkcs1:
                {
                    var util = new RSAPkcs1Util(Encoding.UTF8, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(dataBytes, padding);
                }

                case RSAKeyTypes.Pkcs8:
                {
                    var util = new RSAPkcs8Util(Encoding.UTF8, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(dataBytes, padding);
                }

                default:
                {
                    var util = new RSAXmlUtil(Encoding.UTF8, publicKey, keySize: (int) sizeType);
                    return util.Encrypt(dataBytes, padding);
                }
            }
        }


        /// <summary>
        /// Decrypt string data with xml/json format.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="privateKey">The private key of xml format.</param>
        /// <param name="padding"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="sizeType"></param>
        /// <param name="keyType"></param>
        /// <returns>The decrypted data.</returns>
        public static string Decrypt(
            string data,
            string privateKey,
            RSAEncryptionPadding padding,
            Encoding encoding = null,
            RSAKeySizeTypes sizeType = RSAKeySizeTypes.R2048,
            RSAKeyTypes keyType = RSAKeyTypes.XML)
        {
            switch (keyType)
            {
                case RSAKeyTypes.XML:
                {
                    var util = new RSAXmlUtil(encoding, null, privateKey, (int) sizeType);
                    return util.Decrypt(data, padding);
                }

                case RSAKeyTypes.JSON:
                {
                    var util = new RSAJsonUtil(encoding, null, privateKey, (int) sizeType);
                    return util.Decrypt(data, padding);
                }

                case RSAKeyTypes.Pkcs1:
                {
                    var util = new RSAPkcs1Util(encoding, null, privateKey, (int) sizeType);
                    return util.Decrypt(data, padding);
                }

                case RSAKeyTypes.Pkcs8:
                {
                    var util = new RSAPkcs8Util(encoding, null, privateKey, (int) sizeType);
                    return util.Decrypt(data, padding);
                }

                default:
                {
                    var util = new RSAXmlUtil(encoding, null, privateKey, (int) sizeType);
                    return util.Decrypt(data, padding);
                }
            }
        }

        /// <summary>
        /// Decrypt byte[] data with xml/json format.
        /// </summary>
        /// <param name="dataBytes">The data to be encrypted.</param>
        /// <param name="privateKey">The private key of xml format.</param>
        /// <param name="padding"></param>
        /// <param name="sizeType"></param>
        /// <param name="keyType"></param>
        /// <returns>The decrypted data.</returns>
        public static string Decrypt(
            byte[] dataBytes,
            string privateKey,
            RSAEncryptionPadding padding,
            RSAKeySizeTypes sizeType = RSAKeySizeTypes.R2048,
            RSAKeyTypes keyType = RSAKeyTypes.XML)
        {
            switch (keyType)
            {
                case RSAKeyTypes.XML:
                {
                    var util = new RSAXmlUtil(Encoding.UTF8, null, privateKey, (int) sizeType);
                    return util.Decrypt(dataBytes, padding);
                }

                case RSAKeyTypes.JSON:
                {
                    var util = new RSAJsonUtil(Encoding.UTF8, null, privateKey, (int) sizeType);
                    return util.Decrypt(dataBytes, padding);
                }

                case RSAKeyTypes.Pkcs1:
                {
                    var util = new RSAPkcs1Util(Encoding.UTF8, null, privateKey, (int) sizeType);
                    return util.Decrypt(dataBytes, padding);
                }

                case RSAKeyTypes.Pkcs8:
                {
                    var util = new RSAPkcs8Util(Encoding.UTF8, null, privateKey, (int) sizeType);
                    return util.Decrypt(dataBytes, padding);
                }

                default:
                {
                    var util = new RSAXmlUtil(Encoding.UTF8, null, privateKey, (int) sizeType);
                    return util.Decrypt(dataBytes, padding);
                }
            }
        }

        public static string SignatureAsString(
            string data,
            string publicKey,
            HashAlgorithmName hashAlgorithmName,
            RSASignaturePadding padding,
            Encoding encoding = null,
            RSAKeySizeTypes sizeType = RSAKeySizeTypes.R2048,
            RSAKeyTypes keyType = RSAKeyTypes.XML)
        {
            switch (keyType)
            {
                case RSAKeyTypes.XML:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignData(data, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.JSON:
                {
                    var util = new RSAJsonUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignData(data, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.Pkcs1:
                {
                    var util = new RSAPkcs1Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignData(data, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.Pkcs8:
                {
                    var util = new RSAPkcs8Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignData(data, hashAlgorithmName, padding);
                }

                default:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignData(data, hashAlgorithmName, padding);
                }
            }
        }

        public static byte[] Signature(
            string data,
            string publicKey,
            HashAlgorithmName hashAlgorithmName,
            RSASignaturePadding padding,
            Encoding encoding = null,
            RSAKeySizeTypes sizeType = RSAKeySizeTypes.R2048,
            RSAKeyTypes keyType = RSAKeyTypes.XML)
        {
            switch (keyType)
            {
                case RSAKeyTypes.XML:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignDataGetBytes(data, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.JSON:
                {
                    var util = new RSAJsonUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignDataGetBytes(data, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.Pkcs1:
                {
                    var util = new RSAPkcs1Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignDataGetBytes(data, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.Pkcs8:
                {
                    var util = new RSAPkcs8Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignDataGetBytes(data, hashAlgorithmName, padding);
                }

                default:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.SignDataGetBytes(data, hashAlgorithmName, padding);
                }
            }
        }

        public static bool Verify(
            string data,
            string publicKey,
            string signature,
            HashAlgorithmName hashAlgorithmName,
            RSASignaturePadding padding,
            Encoding encoding = null,
            RSAKeySizeTypes sizeType = RSAKeySizeTypes.R2048,
            RSAKeyTypes keyType = RSAKeyTypes.XML)
        {
            switch (keyType)
            {
                case RSAKeyTypes.XML:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.VerifyData(data, signature, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.JSON:
                {
                    var util = new RSAJsonUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.VerifyData(data, signature, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.Pkcs1:
                {
                    var util = new RSAPkcs1Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.VerifyData(data, signature, hashAlgorithmName, padding);
                }

                case RSAKeyTypes.Pkcs8:
                {
                    var util = new RSAPkcs8Util(encoding, publicKey, keySize: (int) sizeType);
                    return util.VerifyData(data, signature, hashAlgorithmName, padding);
                }

                default:
                {
                    var util = new RSAXmlUtil(encoding, publicKey, keySize: (int) sizeType);
                    return util.VerifyData(data, signature, hashAlgorithmName, padding);
                }
            }
        }
    }
}