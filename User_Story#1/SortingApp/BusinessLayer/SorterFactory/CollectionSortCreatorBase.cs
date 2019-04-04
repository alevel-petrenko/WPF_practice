using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Provides base functionality that creates concrete sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    abstract public class CollectionSortCreatorBase<T> where T : IComparable
    {
        /// <summary>
        /// Creates instanse of CollectionSorterBase.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instanse of CollectionSorterBase.</returns>
        abstract public CollectionSorterBase<T> Create();
    }
}
