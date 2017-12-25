using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Algorithms;
using Xunit;

namespace Cosmos.Encryption.Tests.Algorithms {
    public class PlayFairTests {
        readonly IEncryptionAlgorithm _target;

        public PlayFairTests() {
            _target = new PlayFair("playfairexample");
        }

        [Fact]
        public void EncryptTest() {
            //Arrange
            string plain = "hidethegoldinthetreestump";
            string cypher = "bmodzbxdnabekudmuixmmouvif";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.Equal(cypher, actual);
        }

        [Fact]
        public void DecryptTest() {
            //Arrange
            string plain = "hidethegoldinthetrexestump";
            string cypher = "bmodzbxdnabekudmuixmmouvif";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.Equal(plain, actual);
        }
    }
}