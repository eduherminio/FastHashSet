using Motvin.Collections;
using System.Collections.Generic;

namespace FastHashSet
{
    public static class EnumerableExtensions
    {
        public static FastHashSet<T> ToFastHashSet<T>(this IEnumerable<T> enumerable)
        {
            return new FastHashSet<T>(enumerable);
        }
    }
}
