using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates selection sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type</typeparam>
    public class SelectionSortCreator<T> : CollectionSortCreatorBase<T> where T : IComparable
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
