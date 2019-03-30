using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates concrete sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type</typeparam>
    abstract public class CollectionSortCreatorBase<T> where T : IComparable
    {
        /// <summary>
        /// Returns instanse of CollectionSorterBase.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        abstract public CollectionSorterBase<T> Create();
    }
}
