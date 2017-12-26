using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Algorithms;
using Xunit;

namespace Cosmos.Encryption.NfxTests.Algorithms {
    public class HillTests {
        readonly int[,] matrix;
        readonly IEncryptionAlgorithm _target;

        public HillTests()
        {
            matrix = new int[3, 3];

            matrix[0, 0] = 17;
            matrix[0, 1] = 21;
            matrix[0, 2] = 2;

            matrix[1, 0] = 17;
            matrix[1, 1] = 18;
            matrix[1, 2] = 2;

            matrix[2, 0] = 5;
            matrix[2, 1] = 21;
            matrix[2, 2] = 19;

            _target = new Hill(matrix);
        }

        [Fact]
        public void EncryptTest()
        {
            //Arrange
            string plain = "paymoremoney";
            string cypher = "lnshdlewmtrw";

            //Act
            string actual = _target.Encrypt(plain);

            //Assert
            Assert.Equal(cypher, actual);
        }

        [Fact]
        public void DecryptTest()
        {
            //Arrange
            string plain = "paymoremoney";
            string cypher = "lnshdlewmtrw";

            //Act
            string actual = _target.Decrypt(cypher);

            //Assert
            Assert.Equal(plain, actual);
        }
    }
}