using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates insertion sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type</typeparam>
    public class InsertionSortCreator<T> : CollectionSortCreatorBase<T> where T : IComparable
    {
        /// <summary>
        /// Returns instanse of InsertionSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public override CollectionSorterBase<T> Create()
        {
            return new InsertionSorter<T>();
        }
    }
}
