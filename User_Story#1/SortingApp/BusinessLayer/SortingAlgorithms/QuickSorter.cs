using System;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Provides functionality that sort elements in an ascending order by Quick sort type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type</typeparam>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorterBase{T}" />
    public class QuickSorter<T> : CollectionSorterBase<T> where T : IComparable
    {
        /// <summary>
        /// Constant to store value for first element to find in array.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private const int startElement = 0;

        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        public override void Sort(T[] inputCollection)
        {
            if (inputCollection is null)
                throw new ArgumentNullException(nameof(inputCollection));
            this.SortSubArray(inputCollection, startElement, inputCollection.Length);
        }

        /// <summary>
        /// Sorts the sub array.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        /// <param name="start">The first index of array.</param>
        /// <param name="end">The last index of array.</param>
        private void SortSubArray(T[] inputCollection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            var pivot = end - 1;
            int wall = start;
            for (int currentIndex = start; currentIndex < end; currentIndex++)
            {
                if (inputCollection[currentIndex].CompareTo(inputCollection[pivot]) <= 0)
                {
                    this.SwapElements(inputCollection, currentIndex, wall);
                    wall++;
                }
            }
            this.SortSubArray(inputCollection, start, wall - 1);
            this.SortSubArray(inputCollection, wall + 1, end);
        }

        /// <summary>
        /// Swaps the elements.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="collection">The collection.</param>
        /// <param name="rightIndex">Index of right element in array.</param>
        /// <param name="leftIndex">Index of left element in array.</param>
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
