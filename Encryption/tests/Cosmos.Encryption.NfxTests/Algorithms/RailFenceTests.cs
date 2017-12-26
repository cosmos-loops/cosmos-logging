using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Algorithms;
using Xunit;

namespace Cosmos.Encryption.NfxTests.Algorithms {
    public class RailFenceTests {
        readonly IEncryptionAlgorithm _target;

        public RailFenceTests() {
            _target = new RailFence(2);
        }

        [Fact]
        public void EncryptTest() {
            //Arrange
            string plain = "meetmeafterthegraduationparty";
            string cypher = "mematrhgautopryetefeterdainat*";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.Equal(cypher, actual);
        }

        [Fact]
        public void DecryptTest() {
            //Arrange
            string plain = "meetmeafterthegraduationparty*";
            string cypher = "mematrhgautopryetefeterdainat*";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.Equal(plain, actual);
        }
    }
}