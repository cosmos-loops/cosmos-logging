using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotNetCore.Collections.Paginable;

namespace Cosmos
{
    public static class Enumerables
    {
        public static IEnumerable<T> Merge<T>(IEnumerator<T> left, IEnumerator<T> right)
        {
            while (left.MoveNext()) yield return left.Current;
            while (right.MoveNext()) yield return right.Current;
        }

        public static IEnumerable<T> Merge<T>(IEnumerator<T> left, T last)
        {
            while (left.MoveNext()) yield return left.Current;
            yield return last;
        }

        public static IEnumerable<T> Merge<T>(T first, IEnumerator<T> right)
        {
            yield return first;
            while (right.MoveNext()) yield return right.Current;
        }

        public static IEnumerable<T> Flatten<T>(IEnumerable<T> inputs, Func<T, IEnumerable<T>> enumerableFunc)
        {
            if (inputs != null)
            {
                var stack = new Stack<T>(inputs);
                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    if (current == null) continue;
                    yield return current;
                    var enumerable = enumerableFunc?.Invoke(current);
                    if (enumerable != null)
                    {
                        foreach (var child in enumerable) stack.Push(child);
                    }
                }
            }
        }

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable Flatten(IEnumerable inputs, Func<object, IEnumerable> enumerate)
        {
            return Flatten(inputs.Cast<object>(), o => (enumerate(o) ?? new object[0]).Cast<object>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">data from database</param>
        /// <param name="pageNumber">page number</param>
        /// <param name="itemCountPerPage">page size</param>
        /// <returns></returns>
        public static QueryablePage<T> Of<T>(IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
            => queryable.GetPage(pageNumber, itemCountPerPage) as QueryablePage<T>;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">data in memory</param>
        /// <param name="pageNumber">page number</param>
        /// <param name="itemCountPerPage">page size</param>
        /// <returns></returns>
        public static EnumerablePage<T> Of<T>(IEnumerable<T> enumerable, int pageNumber, int itemCountPerPage)
            => enumerable.GetPage(pageNumber, itemCountPerPage) as EnumerablePage<T>;
    }
}
