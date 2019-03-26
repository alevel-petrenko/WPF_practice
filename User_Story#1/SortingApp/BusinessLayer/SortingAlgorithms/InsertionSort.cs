using System;
using System.Linq;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Sort elements in an ascending order by Insertion type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorter{T}" />
    public class InsertionSort<T> : CollectionSorter<T> where T : IComparable
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <param name="inputCollection">The input collection.</param>
        /// <owner>Anton Petrenko</owner>
        public override void Sort(T[] inputCollection)
        {
            for (int i = 1; i < inputCollection.Count(); i++)
            {
                var temp = inputCollection[i];
                int j = i - 1;
                while ((j >= 0) && (inputCollection[j].CompareTo(temp) > 0))
                {
                    inputCollection[j + 1] = inputCollection[j];
                    j--;
                }
                inputCollection[j + 1] = temp;
            }
        }
    }
}
