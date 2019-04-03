using System;
using BusinessLayer.SortingAlgorithms;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Provides functionality that generates concrete sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    abstract public class CollectionSortCreatorBase<T> where T : IComparable
    {
        /// <summary>
        /// Generate instanse of CollectionSorterBase.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instanse of CollectionSorterBase.</returns>
        abstract public CollectionSorterBase<T> Create();
    }
}
