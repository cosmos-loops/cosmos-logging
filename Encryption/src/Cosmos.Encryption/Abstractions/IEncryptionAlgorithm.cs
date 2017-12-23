namespace Cosmos.Encryption.Abstractions {
    public interface IEncryptionAlgorithm {
        string Encrypt(string plainText);
        string Decrypt(string cipher);
    }
}