namespace BusinessLayer.SortingAlgorithms
{
    /// <summary>
    /// Sort elements in an ascending order.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <owner>Anton Petrenko</owner>
    abstract public class CollectionSorter<T>
    {
        /// <summary>
        /// Sorts the specified input collection.
        /// </summary>
        /// <param name="inputCollection">The input collection.</param>
        /// <owner>Anton Petrenko</owner>
        abstract public void Sort(T[] inputCollection);
    }
}
