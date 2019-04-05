using System;

namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Provides base functionality that sorts elements in an ascending order.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    abstract public class CollectionSorterBase<T> where T : IComparable
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        abstract public void Sort(T[] inputCollection);
    }
}
