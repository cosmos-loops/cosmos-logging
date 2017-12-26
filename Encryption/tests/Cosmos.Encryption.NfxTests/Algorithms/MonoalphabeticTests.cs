using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Algorithms;
using Xunit;

namespace Cosmos.Encryption.NfxTests.Algorithms {
    public class MonoalphabeticTests {
        readonly IEncryptionAlgorithm _target = new Monoalphabetic();

        [Fact]
        public void EncryptTest() {
            //Arrange
            string plain = "abcd";

            //Act
            string cypher = _target.Encrypt(plain);

            //Assert
            Assert.NotEqual(cypher, plain);

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.Equal(plain, actual);
        }
    }
}