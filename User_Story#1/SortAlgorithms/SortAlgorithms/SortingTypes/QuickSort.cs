using System;

namespace SortAlgorithms.SortingTypes
{
    public class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        public override void Sort(T[] inputCollection)
        {
            var pivot = inputCollection[(inputCollection.Length/2)];
            int currentIndex = 0;
            int wall = 0;

            for (; currentIndex < inputCollection.Length; currentIndex++)
            {
                if (inputCollection[currentIndex].CompareTo(pivot) < 0)
                {
                    var temp = inputCollection[currentIndex];
                    inputCollection[currentIndex] = inputCollection[wall];
                    inputCollection[wall] = temp;
                    wall++;
                }
                else if (inputCollection[currentIndex].CompareTo(pivot) < 0)
                {
                    continue;
                }
            }
            // 16 8 10 11 58 4 7
        }
    }
}