using System;
using Cosmos.Helpers;
using Xunit;

namespace Cosmos.Core.Tests.Helpers
{
    public class GuidConvertHelperTests
    {
        [Fact]
        public void StringToGuidTest()
        {
            var guid = new Guid();
            var guidStr = guid.ToString();

            var guid2 = GuidConvertHelper.ToGuid(guidStr);

            Assert.Equal(guid, guid2);
        }

        [Theory]
        [InlineData("")]
        [InlineData("lalala")]
        public void StringToNullableGuidTest(string str)
        {
            var guid = GuidConvertHelper.ToNullableGuid(str);

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
            var guid = GuidConvertHelper.ToGuid(obj);

            Assert.Equal(Guid.Empty, guid);
        }
    }
}
