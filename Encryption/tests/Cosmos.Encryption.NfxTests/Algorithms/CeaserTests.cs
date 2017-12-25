using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Algorithms;
using Xunit;

namespace Cosmos.Encryption.Tests.Algorithms {
    public class CeaserTests {
        readonly IEncryptionAlgorithm _target;

        public CeaserTests() {
            _target = new Ceaser(3);
        }

        [Fact]
        public void EncryptTest() {
            //Arrange
            string plain = "meetmeafterthetogaparty";
            string cypher = "phhwphdiwhuwkhwrjdsduwb";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.Equal(cypher, actual);
        }

        [Fact]
        public void DecryptTest() {
            //Arrange
            string plain = "meetmeafterthetogaparty";
            string cypher = "phhwphdiwhuwkhwrjdsduwb";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.Equal(plain, actual);
        }
    }
}