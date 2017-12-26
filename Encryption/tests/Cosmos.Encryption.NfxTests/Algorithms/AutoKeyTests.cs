using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Algorithms;
using Xunit;

namespace Cosmos.Encryption.NfxTests.Algorithms {
    public class AutoKeyTests {
        [Fact]
        public void AutoKey_EncryptTest() {
            //Arrange
            IEncryptionAlgorithm target = new AutoKey("deceptive");
            string plain = "wearediscoveredsaveyourself";
            string cypher = "zicvtwqngkzeiigasxstslvvwla";

            //Act
            string actual = target.Encrypt(plain);

            //Assert
            Assert.Equal(cypher, actual);
        }

        [Fact]
        public void AutoKey_DecryptTest() {
            //Arrange
            IEncryptionAlgorithm target = new AutoKey("deceptivewearediscoveredsav");
            string plain = "wearediscoveredsaveyourself";
            string cypher = "zicvtwqngkzeiigasxstslvvwla";

            //Act
            string actual = target.Decrypt(cypher);

            //Assert
            Assert.Equal(plain, actual);
        }
    }
}