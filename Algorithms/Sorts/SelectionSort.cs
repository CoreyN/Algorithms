namespace Algorithms.Sorts
{
    public static class SelectionSort
    {
        public static void Sort(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                int indexOfMin = FindIndexOfMinimumElementInTail(array, i);
                Swap(array, i, indexOfMin);
            }
        }

        private static int FindIndexOfMinimumElementInTail(int[] array, int startIndex)
        {
            int indexOfMin = startIndex;

            for (int j = startIndex; j < array.Length; j++)
            {
                if (array[j] < array[indexOfMin])
                {
                    indexOfMin = j;
                }
            }

            return indexOfMin;
        }

        private static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
