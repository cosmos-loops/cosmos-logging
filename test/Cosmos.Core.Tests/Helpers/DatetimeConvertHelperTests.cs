using System;
using Cosmos.Helpers;
using Xunit;

namespace Cosmos.Core.Tests.Helpers
{
    public class DatetimeConvertHelperTests
    {

        [Theory]
        [InlineData("2017-02-10 10:10:10")]
        public void StringDatetimeTest(string datetime)
        {
            var dt = DateTimeConvertHelper.ToDateTime(datetime);

            Assert.Equal(2017, dt.Year);
            Assert.Equal(2, dt.Month);
            Assert.Equal(10, dt.Day);

            Assert.Equal(10, dt.Hour);
            Assert.Equal(10, dt.Minute);
            Assert.Equal(10, dt.Second);
        }

        [Theory]
        [InlineData("2017-02-10 10:10:10.011")]
        public void StringDatetimeWithMillisecondTest(string datetime)
        {
            var dt = DateTimeConvertHelper.ToDateTime(datetime);

            Assert.Equal(2017, dt.Year);
            Assert.Equal(2, dt.Month);
            Assert.Equal(10, dt.Day);

            Assert.Equal(10, dt.Hour);
            Assert.Equal(10, dt.Minute);
            Assert.Equal(10, dt.Second);
            Assert.Equal(11, dt.Millisecond);
        }

        [Theory]
        [InlineData("2017-02-30 10:10:10")]
        public void StringDefaultDatetimeTest(string datetime)
        {
            var def = new DateTime(2017, 1, 1, 0, 0, 0, 001);
            var dt = DateTimeConvertHelper.ToDateTime(datetime, def);

            Assert.Equal(def, dt);
        }

        [Theory]
        [InlineData("2017-02-30 10:10:10")]
        public void StringNullDefaultDatetimeTest(string datetime)
        {
            var dt = DateTimeConvertHelper.ToDateTime(datetime);
            Assert.Equal(default(DateTime), dt);
        }
    }
}
