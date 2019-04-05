using System;
using System.Linq;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Provides functionality that sort elements in an ascending order by Quick sort type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorterBase{T}" />
    public class QuickSorter<T> : CollectionSorterBase<T> where T : IComparable
    {
        /// <summary>
        /// Stores value for first element to find in array.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private const int StartElement = 0;

        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        public override void Sort(T[] inputCollection)
        {
            if (inputCollection is null || !inputCollection.Any())
                throw new ArgumentNullException(nameof(inputCollection));

            this.Sort(inputCollection, StartElement, inputCollection.Length - 1);
        }

        /// <summary>
        /// Sorts the specified input collection by start and end elements.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        /// <param name="startElement">The start element.</param>
        /// <param name="endElement">The end element.</param>
        private void Sort(T[] inputCollection, int startElement, int endElement)
        {
            if (startElement > endElement)
                return;

                int wall = this.Separate(inputCollection, startElement, endElement);
                this.Sort(inputCollection, startElement, wall - 1);
                this.Sort(inputCollection, wall + 1, endElement);
        }

        /// <summary>
        /// Separates the array by "wall" value.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        /// <param name="start">The first index of array.</param>
        /// <param name="end">The last index of array.</param>
        private int Separate(T[] inputCollection, int start, int end)
        {
            var pivot = end;
            int wall = start - 1;
            for (int currentIndex = start; currentIndex < end; currentIndex++)
            {
                if (inputCollection[currentIndex].CompareTo(inputCollection[pivot]) <= 0)
                {
                    wall++;
                    this.SwapElements(inputCollection, currentIndex, wall);
                }
            }
            this.SwapElements(inputCollection, ++wall, pivot);

            return wall;
        }

        /// <summary>
        /// Swaps the elements.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="collection">The collection.</param>
        /// <param name="leftIndex">Index of left element in array.</param>
        /// <param name="rightIndex">Index of right element in array.</param>
        private void SwapElements(T[] collection, int leftIndex, int rightIndex)
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
