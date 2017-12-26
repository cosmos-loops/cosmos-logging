using Xunit;

namespace Cosmos.Encryption.Tests.Hash {
    public class ShaTests {
        [Fact]
        public void Sha1Test() {
            var signature = SHA1HashingProvider.Signature("image");
            Assert.Equal("0E76292794888D4F1FA75FB3AFF4CA27C58F56A6", signature);
        }

        [Fact]
        public void Sha256Test() {
            var signature = SHA256HashingProvider.Signature("image");
            Assert.Equal("6105D6CC76AF400325E94D588CE511BE5BFDBB73B437DC51ECA43917D7A43E3D", signature);
        }
        
        [Fact]
        public void Sha384Test() {
            var signature = SHA384HashingProvider.Signature("image");
            Assert.Equal("7158862BE7FF7D2AE0A585B872F415CF09B7FE8C6CE170EF944061E7788D73C1F5835652D8AFE9939B01905D5AA7C48C", signature);
        }
        
        [Fact]
        public void Sha512Test() {
            var signature = SHA512HashingProvider.Signature("image");
            Assert.Equal("EB31D04DA633DC9F49DFBD66CDB92FBB9B4F9C9BE67914C0209B5DD31CC65A136E1CDCE7D0DB88112E3A759131B9D970CFAAC7EE77CCD620C3DD49043F88958E", signature);
        }
    }
}