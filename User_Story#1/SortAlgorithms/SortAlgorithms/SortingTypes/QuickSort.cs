using System;

namespace SortAlgorithms.SortingTypes
{
    public class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        public override void Sort(T[] inputCollection)
        {
            SortSubArray(inputCollection, 0, inputCollection.Length-1);
        }

        private void SortSubArray (T[] inputCollection, int left, int range)
        {
            var pivot = inputCollection[inputCollection.Length / 2];
            int currentIndex = left;
            int wall = left;

            for (; currentIndex <= range; currentIndex++)
            {
                if (currentIndex == Array.IndexOf(inputCollection, pivot))
                {
                    continue;
                }
                if (inputCollection[currentIndex].CompareTo(pivot) < 0)
                {
                    Swap(inputCollection, currentIndex, wall);
                    wall++;
                }
                if (currentIndex == inputCollection.Length - 1)
                {
                    Swap(inputCollection, Array.IndexOf(inputCollection, pivot), wall);
                }
            }
        }

        private void Swap (T[] collection, int currentIndex, int wall)
        {
            if (collection != null)
            {
                var temp = collection[currentIndex];
                collection[currentIndex] = collection[wall];
                collection[wall] = temp;
            }
        }
    }
}