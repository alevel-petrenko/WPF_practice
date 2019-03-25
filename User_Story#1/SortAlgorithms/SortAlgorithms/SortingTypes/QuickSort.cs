using System;

namespace SortAlgorithms.SortingTypes
{
    public class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        public override void Sort(T[] inputCollection)
        {
            SortSubArray(inputCollection, 0, inputCollection.Length);
        }

        private void SortSubArray(T[] inputCollection, int left, int range)
        {
            if (left >= range)
            {
                return;
            }

            var pivot = (range - left) / 2;
            int currentIndex = left;
            int wall = left;

            for (; currentIndex < range; currentIndex++)
            {
                if (currentIndex == Array.IndexOf(inputCollection, pivot))
                {
                    continue;
                }
                if (inputCollection[currentIndex].CompareTo(pivot) < 0)
                {
                    SwapElements(inputCollection, currentIndex, wall);
                    wall++;
                }
            }
            SwapElements(inputCollection, Array.IndexOf(inputCollection, pivot), wall);

            SortSubArray(inputCollection, left, pivot - 1);
            SortSubArray(inputCollection, pivot + 1, range);
        }

        private void SwapElements(T[] collection, int currentIndex, int wall)
        {
            if (collection != null && currentIndex >= 0 || wall >= 0)
            {
                var temp = collection[currentIndex];
                collection[currentIndex] = collection[wall];
                collection[wall] = temp;
            }
        }
    }
}