using System;
using System.Linq;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Sort elements in an ascending order by Selection type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorter{T}" />
    public class SelectionSort<T> : CollectionSorter<T> where T : IComparable
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <param name="inputCollection">The input collection.</param>
        /// <owner>Anton Petrenko</owner>
        public override void Sort(T[] inputCollection)
        {
            for (int i = 0; i < inputCollection.Count(); i++)
            {
                var min = inputCollection[i];
                int j = i + 1;
                for (; j < inputCollection.Count(); j++)
                {
                    if (min.CompareTo(inputCollection[j]) > 0)
                    {
                        min = inputCollection[j];
                    }
                }
                inputCollection[Array.IndexOf(inputCollection, min)] = inputCollection[i];
                inputCollection[i] = min;
            }
        }
    }
}
