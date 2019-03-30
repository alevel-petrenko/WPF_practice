using BusinessLayer.SortingAlgorithms;
using System;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates selection sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    public class SelectionSortCreator<T> : CollectionSortCreator<T> where T : IComparable
    {
        /// <summary>
        /// Returns instanse of SelectionSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public override CollectionSorterBase<T> Create()
        {
            return new SelectionSorter<T>();
        }
    }
}
