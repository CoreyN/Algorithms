using System;
using System.Collections.Generic;

namespace Algorithms.Search
{
    public static class BinarySearch
    {
        /* Precondition: the list to be searched must be sortred.
         * Worst case run time: O(lg n)
         */
        public static int? Search<T>(T needle, IList<T> haystack) where T : IComparable<T>
        {
            if (needle == null)
                throw new ArgumentNullException("needle");

            int low = 0;
            int high = haystack.Count - 1;

            //Loop invariant: if the needle is in the haystack, then its index
            //in haystack is in the closed interval [low, high].
            while(high >= low)
            {
                int middle = GetMiddleIndex(low, high);

                if(haystack[middle].CompareTo(needle) < 0)
                    low = middle + 1;
                else if (haystack[middle].CompareTo(needle) > 0)
                    high = middle - 1;
                else
                    return middle;
            }

            return null;
        }

        private static int GetMiddleIndex(int low, int high)
        {
            //Using this formula to calculate the middle index avoids a possible integer
            //overflow on very large arrays.
            return (high - low) / 2 + low;
        }
    }
}
