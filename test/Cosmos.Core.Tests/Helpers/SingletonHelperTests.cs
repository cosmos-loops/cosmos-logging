using System.Collections.Generic;
using Cosmos.Helpers;
using Xunit;

namespace Cosmos.Core.Tests.Helpers
{
    public class SingletonHelperTests
    {
        public class One { }

        [Fact]
        public void OneObjectSingletonTest()
        {
            var one = new One();

            SingletonHelper.SetSingleton(one);

            var one2 = SingletonHelper.GetSingleton<One>();

            Assert.True(one == one2);
            Assert.True(one.Equals(one2));
        }

        [Fact]
        public void OneListSingletonTest()
        {
            var list = new List<One> { new One(), new One() };

            SingletonHelper.SetSingletonList(list);

            var list2 = SingletonHelper.GetSingletonList<One>();

            Assert.True(list == list2);
            Assert.True(list.Equals(list2));
            Assert.Equal(2, list.Count);
            Assert.Equal(2, list2.Count);
        }

        [Fact]
        public void OneListDirectSingletonTest()
        {
            IList<One> list = new List<One> { new One(), new One() };

            SingletonHelper.SetSingleton(list);

            var list2 = SingletonHelper.GetSingleton<IList<One>>();

            Assert.True(list == list2);
            Assert.True(list.Equals(list2));
            Assert.Equal(2, list.Count);
            Assert.Equal(2, list2.Count);
        }

        [Fact]
        public void OneDictionarySingletonTest()
        {
            var dict = new Dictionary<string, One>();
            dict.Add("1", new One());
            dict.Add("2", new One());
            dict.Add("3", new One());

            SingletonHelper.SetSingletonDictionary(dict);

            var dict2 = SingletonHelper.GetSingletonDictionary<string, One>();

            Assert.True(dict == dict2);
            Assert.True(dict.Equals(dict2));
            Assert.Equal(3, dict.Count);
            Assert.Equal(3, dict2.Count);
        }

        [Fact]
        public void OneDictionaryDirectSingletonTest()
        {
            IDictionary<string, One> dict = new Dictionary<string, One>();
            dict.Add("1", new One());
            dict.Add("2", new One());
            dict.Add("3", new One());

            SingletonHelper.SetSingleton(dict);

            var dict2 = SingletonHelper.GetSingleton<IDictionary<string, One>>();

            Assert.True(dict == dict2);
            Assert.True(dict.Equals(dict2));
            Assert.Equal(3, dict.Count);
            Assert.Equal(3, dict2.Count);
        }

    }
}
