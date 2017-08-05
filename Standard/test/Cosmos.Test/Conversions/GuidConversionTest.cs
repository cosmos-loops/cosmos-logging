using System;
using Cosmos.Conversions;
using Xunit;

namespace Cosmos.Test.Conversions
{
    public class GuidConversionTest
    {
        [Fact]
        public void StringToGuidTest()
        {
            var guid = new Guid();
            var guidStr = guid.ToString();

            var guid2 = GuidConversion.ToGuid(guidStr);

            Assert.Equal(guid, guid2);
        }

        [Theory]
        [InlineData("")]
        [InlineData("lalala")]
        public void StringToNullableGuidTest(string str)
        {
            var guid = GuidConversion.ToNullableGuid(str);

            Assert.Null(guid);
        }


        [Theory]
        [InlineData("")]
        [InlineData("lalala")]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData(1234.56789)]
        public void ConvertFailureTest(object obj)
        {
            var guid = GuidConversion.ToGuid(obj);

            Assert.Equal(Guid.Empty, guid);
        }
    }
}
