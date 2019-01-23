using System.Collections.Generic;
using System.Linq;

namespace Cosmos
{
    public static class ArrayExtensions
    {
        public static TElement[] ToSafeArray<TElement>(this IEnumerable<TElement> source)
        {
            return source as TElement[] ?? source.ToArray();
        }
    }
}