namespace Cosmos.Encryption.Core
{
    internal class RSAConstants
    {
        public const string PUBLIC_KEY_START = "-----BEGIN PUBLIC KEY-----";
        public const string PUBLIC_KEY_END = "-----END PUBLIC KEY-----";

        public const string PRIVATE_KEY_START = "-----BEGIN PRIVATE KEY-----";
        public const string PRIVATE_KEY_END = "-----END PRIVATE KEY-----";

        public const string RSA_PRIVATE_KEY_START = "-----BEGIN RSA PRIVATE KEY-----";
        public const string RSA_PRIVATE_KEY_END = "-----END RSA PRIVATE KEY-----";

        public const string R_N = "\r\n";
    }
}