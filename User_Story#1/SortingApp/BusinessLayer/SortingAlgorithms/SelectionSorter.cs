using System;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Provides functionality that sorts elements in an ascending order by Selection type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorterBase{T}" />
    public class SelectionSorter<T> : CollectionSorterBase<T> where T : IComparable
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        public override void Sort(T[] inputCollection)
        {
            if (inputCollection is null)
                throw new ArgumentNullException(nameof(inputCollection));
            for (int i = 0; i < inputCollection.Length - 1; i++)
            {
                var min = i;
                for (int j = i + 1; j < inputCollection.Length; j++)
                {
                    if (inputCollection[min].CompareTo(inputCollection[j]) > 0)
                    {
                        min = j;
                    }
                }
                var temp = inputCollection[min];
                inputCollection[min] = inputCollection[i];
                inputCollection[i] = temp;
            }
        }
    }
}
