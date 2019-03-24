using System;

namespace SortAlgorithms.SortingTypes
{
    public class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        public override void Sort(T[] inputCollection)
        {
            for (int i = 0; i < inputCollection.Length; i++)
            {
                var pivot = inputCollection[inputCollection.Length - 1];
                int currentIndex = 0;
                int wall = 0;

                while (currentIndex < inputCollection.Length)
                {
                    if (inputCollection[currentIndex].CompareTo(pivot) > 0)
                    {
                        currentIndex++;
                    }
                    else if (currentIndex == Array.IndexOf(inputCollection, pivot) ||
                        inputCollection[currentIndex].CompareTo(pivot) <= 0)
                    {
                        var temp = inputCollection[currentIndex];
                        inputCollection[currentIndex] = inputCollection[wall];
                        inputCollection[wall] = temp;
                        wall++;
                    }
                }
            }
            // 16 10 11 58 4 7
        }
    }
}
