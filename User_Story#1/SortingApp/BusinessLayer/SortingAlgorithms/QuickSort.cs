using System;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Sort elements in an ascending order by Quick sort type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorter{T}" />
    public class QuickSort<T> : CollectionSorter<T> where T : IComparable
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <param name="inputCollection">The input collection.</param>
        /// <owner>Anton Petrenko</owner>
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

        /// <summary>
        /// Swaps the elements.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="rightIndex">Index of the most right element in array.</param>
        /// <param name="leftIndex">Index of the most left element in array.</param>
        /// <owner>Anton Petrenko</owner>
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
