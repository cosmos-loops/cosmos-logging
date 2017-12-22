namespace Cosmos.Encryption.Algorithms.Abstractions {
    public interface IEncryptionAlgorithm {
        string Encrypt(string plainText);
        string Decrypt(string cipher);
    }
}