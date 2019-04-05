using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Provides functionality that creates selection sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    public class SelectionSortCreator<T> : CollectionSortCreatorBase<T> where T : IComparable
    {
        /// <summary>
        /// Creates instanse of SelectionSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instanse of SelectionSorter.</returns>
        public override CollectionSorterBase<T> Create()
        {
            return new SelectionSorter<T>();
        }
    }
}
