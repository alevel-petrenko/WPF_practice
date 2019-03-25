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
                if (currentIndex == Array.IndexOf(inputCollection, pivot))
                {
                    continue;
                }
                if (inputCollection[currentIndex].CompareTo(pivot) < 0)
                {
                    var temp = inputCollection[currentIndex];
                    inputCollection[currentIndex] = inputCollection[wall];
                    inputCollection[wall] = temp;
                    wall++;
                }
                if (currentIndex == inputCollection.Length-1)
                {
                    var temp = inputCollection[Array.IndexOf(inputCollection, pivot)];
                    inputCollection[Array.IndexOf(inputCollection, pivot)] = inputCollection[wall];
                    inputCollection[wall] = temp;
                }
            }
        }
    }
}