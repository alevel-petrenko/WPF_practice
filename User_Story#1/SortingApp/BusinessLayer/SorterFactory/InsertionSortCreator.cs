using BusinessLayer.SortingAlgorithms;
using System;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates insertion sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    public class InsertionSortCreator<T> : CollectionSortCreator<T> where T : IComparable
    {
        /// <summary>
        /// Returns instanse of InsertionSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public override CollectionSorter<T> Create()
        {
            return new InsertionSorter<T>();
        }
    }
}
