using BusinessLayer.DataParser.Interfaces;
using BusinessLayer.Reader;
using BusinessLayer.SortingAlgorithms;
using BusinessLayer.Writer;

namespace BusinessLayer
{
    /// <summary>
    /// Handle all requests regarding reading, sorting collection and writing it to the file.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    public class CollectionSortHandler<T>
    {
        /// <summary>
        /// The parser instance.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private IDataParser parser;

        /// <summary>
        /// The reader instance.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private DataReader reader;

        /// <summary>
        /// The sorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private T[] sortedCollection;

        /// <summary>
        /// The sorter instance.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private CollectionSorter<T> sorter;

        /// <summary>
        /// The writer instance.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private DataWriter<T> writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSortHandler{T}"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="reader">The reader instance.</param>
        /// <param name="writer">The writer instance.</param>
        /// <param name="sorter">The sorter instance.</param>
        /// <param name="parser">The parser instance.</param>
        public CollectionSortHandler(DataReader reader, DataWriter<T> writer, CollectionSorter<T> sorter, IDataParser parser)
        {
            this.parser = parser;
            this.reader = reader;
            this.sorter = sorter;
            this.writer = writer;
        }

        /// <summary>
        /// Executes reading and sorting for collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Execute()
        {

        }

        /// <summary>
        /// Writes sorted collection to file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Write()
        {

        }
    }
}
