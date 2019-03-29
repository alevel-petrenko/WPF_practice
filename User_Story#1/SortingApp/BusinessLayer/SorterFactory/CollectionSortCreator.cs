using BusinessLayer.SortingAlgorithms;
using System;

namespace BusinessLayer.SorterFactory
{
    /// <summary>
    /// Generates concrete sort class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    abstract public class CollectionSortCreator<T> where T : IComparable
    {
        /// <summary>
        /// Returns instanse of CollectionSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        abstract public CollectionSorter<T> Create();
    }
}
