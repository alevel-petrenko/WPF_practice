namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Sorts elements in an ascending order.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    abstract public class CollectionSorter<T>
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="inputCollection">The input collection.</param>
        abstract public void Sort(T[] inputCollection);
    }
}
