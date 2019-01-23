using System.Linq;

namespace Cosmos.Judgements
{
    /// <summary>
    /// Queryable Judgement Utilities
    /// </summary>
    public static class QueryableJudgement
    {
        /// <summary>
        /// To judge whether one queryable collection contains specified count of elements at least
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(IQueryable<T> query, int count)
        {
            if (query == null)
                return false;

            return (from t in query.Take(count) select t).Count() >= count;
        }

        /// <summary>
        /// To judge whether these two queryable collections contain same count of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="targetQuery"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(IQueryable<T> query, IQueryable<T> targetQuery)
        {
            if (query == null && targetQuery == null)
                return true;

            if (query == null || targetQuery == null)
                return false;

            return query.Count().Equals(targetQuery.Count());
        }
    }
}