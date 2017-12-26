using Xunit;

namespace Cosmos.Encryption.NfxTests.Hash {
    public class HmacTests {
        [Fact]
        public void HmacMd5Test() {
            var signature = HMACMD5HashingProvider.Signature("image", "alexinea");
            Assert.Equal("C970FEC14C50EF84E1480EA2746BBA58", signature);
        }
        
        [Fact]
        public void HmacSha1Test() {
            var signature = HMACSHA1HashingProvider.Signature("image", "alexinea");
            Assert.Equal("0E5CF78AECFE44262169BB15003F97443E9DDFE3", signature);
        }

        [Fact]
        public void HmacSha256Test() {
            var signature = HMACSHA256HashingProvider.Signature("image", "alexinea");
            Assert.Equal("8A51972243A890448E2054424D09EC87F68DEE753CA4EF64A4907107F1EF7917", signature);
        }

        [Fact]
        public void HmacSha384Test() {
            var signature = HMACSHA384HashingProvider.Signature("image", "alexinea");
            Assert.Equal("BBA2453672D08873C997F2CBDE45A0F5721D5D84CF36D491394873CF4F12823266BAED5513759BA8908786C7E97094AC", signature);
        }
        
        [Fact]
        public void HmacSha512Test() {
            var signature = HMACSHA512HashingProvider.Signature("image", "alexinea");
            Assert.Equal("5761F399848FD4E1C2A6DAA3C5EF03A8478B430667A1F706C39338925A93F14B782F64C831FF8F54C3CB7EF6A2BF6A29B091A9A20620E3B2AB7DCD7676CFFAAF", signature);
        }
    }
}