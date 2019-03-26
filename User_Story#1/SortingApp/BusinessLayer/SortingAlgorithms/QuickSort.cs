using System;

namespace BusinessLayer.SortingAlgorithms
{
    public class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        public override void Sort(T[] inputCollection)
        {
            SortSubArray(inputCollection, 0, inputCollection.Length);
        }

        private void SortSubArray(T[] inputCollection, int start, int range)
        {
            if (start >= range)
            {
                return;
            }

            var pivot = range - 1;
            int currentIndex = start;
            int wall = start;

            for (; currentIndex < range; currentIndex++)
            {
                if (inputCollection[currentIndex].CompareTo(inputCollection[pivot]) < 0)
                {
                    SwapElements(inputCollection, currentIndex, wall);
                    wall++;
                }
            }
            SwapElements(inputCollection, Array.IndexOf(inputCollection, inputCollection[pivot]), wall);

            SortSubArray(inputCollection, start, pivot - 1);
            SortSubArray(inputCollection, pivot + 1, range);
        }

        private void SwapElements(T[] collection, int rightIndex, int leftIndex)
        {
            if (collection != null && rightIndex >= 0 || leftIndex >= 0)
            {
                var temp = collection[rightIndex];
                collection[rightIndex] = collection[leftIndex];
                collection[leftIndex] = temp;
            }
        }
    }
}
