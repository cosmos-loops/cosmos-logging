using System.Collections.Generic;
using System.Linq;
using Cosmos.Judgements;
using Xunit;

namespace Cosmos.Test.Judgements
{
    public class QueryableJudgementTest
    {
        List<string> source = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8" };

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(7)]
        [InlineData(8)]
        public void ContainAtLeastTest_True(int count)
        {
            var query = source.AsQueryable();
            Assert.True(QueryableJudgement.ContainsAtLeast(query, count));
        }

        [Theory]
        [InlineData(9)]
        public void ContainAtLeastTest_False(int count)
        {
            var query = source.AsQueryable();
            Assert.False(QueryableJudgement.ContainsAtLeast(query, count));
        }

        [Fact]
        public void ContainsEqualCountTest()
        {
            var query = source.AsQueryable();
            var targetQuery = new List<string> { "9", "8", "7", "6", "5", "4", "3", "2" }.AsQueryable();
            Assert.True(QueryableJudgement.ContainsEqualCount(query, targetQuery));
            Assert.True(QueryableJudgement.ContainsEqualCount<string>(null, null));
            Assert.False(QueryableJudgement.ContainsEqualCount(query, null));
            Assert.False(QueryableJudgement.ContainsEqualCount(null, targetQuery));

            var wrongQuery = new List<string> { "1" }.AsQueryable();
            Assert.False(QueryableJudgement.ContainsEqualCount(query, wrongQuery));
        }
    }
}
