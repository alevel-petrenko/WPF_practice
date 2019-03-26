using System;
using System.Linq;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Sort elements in an ascending order by Selection type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BusinessLayer.SortingAlgorithms.CollectionSorter{T}" />
    public class SelectionSorter<T> : CollectionSorter<T> where T : IComparable
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
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
