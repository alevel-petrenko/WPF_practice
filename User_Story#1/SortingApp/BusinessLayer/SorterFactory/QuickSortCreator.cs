using BusinessLayer.SortingAlgorithms;
using System;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates quick sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></type
    public class QuickSortCreator<T> : CollectionSortCreator<T> where T : IComparable
    {
        /// <summary>
        /// Returns instanse of QuickSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public override CollectionSorterBase<T> Create()
        {
            return new QuickSorter<T>();
        }
    }
}
