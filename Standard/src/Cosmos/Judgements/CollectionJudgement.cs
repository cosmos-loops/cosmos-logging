using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Judgements
{
    /// <summary>
    /// Collection Judgement Utilities
    /// </summary>
    public static class CollectionJudgement
    {
        /// <summary>
        /// To judge whether the collection is null or not
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNull(IEnumerable coll)
        {
            return coll == null;
        }

        /// <summary>
        /// To judge whether the collection is null or empty
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(IEnumerable coll)
        {
            if (coll == null)
            {
                return true;
            }

            return !coll.Cast<object>().Any();
        }

        /// <summary>
        /// To judge whether the collection is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(IEnumerable<T> coll)
        {
            return coll == null || !coll.Any();
        }

        /// <summary>
        /// To judge whether one collection contains specified count of elements at least
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="coll"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(ICollection<T> coll, int count)
        {
            return coll?.Count >= count;
        }

        /// <summary>
        /// To judge whether these two collections contain same count of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftCcoll"></param>
        /// <param name="rightColl"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(ICollection<T> leftCcoll, ICollection<T> rightColl)
        {
            if (leftCcoll == null && rightColl == null)
            {
                return true;
            }

            if (leftCcoll == null || rightColl == null)
            {
                return false;
            }

            return leftCcoll.Count().Equals(rightColl.Count());
        }
    }
}
