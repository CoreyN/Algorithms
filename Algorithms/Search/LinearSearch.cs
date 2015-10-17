using System;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class LinearSearch
    {
        public static int? Search<T>(T needle, IList<T> haystack) where T : IEquatable<T>
        {
            if (needle == null)
                throw new ArgumentNullException("needle");

            for(int i = 0; i < haystack.Count; i++)
            {
                if (needle.Equals(haystack[i]))
                    return i;
            }

            return null;
        }
    }
}
