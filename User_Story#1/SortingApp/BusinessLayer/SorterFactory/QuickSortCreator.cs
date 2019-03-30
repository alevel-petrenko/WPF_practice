using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates quick sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type</type
    public class QuickSortCreator<T> : CollectionSortCreatorBase<T> where T : IComparable
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
