using BusinessLayer.Utilities.Parser.Interfaces;
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
        /// Holds the parser.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private IDataParser parser;

        /// <summary>
        /// Holds the reader.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private DataReader reader;

        /// <summary>
        /// Holds the sorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private T[] sortedCollection;

        /// <summary>
        /// Holds the sorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private CollectionSorter<T> sorter;

        /// <summary>
        /// Holds the writer.
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
            if (reader != null && writer != null && sorter != null && parser != null)
            {
                this.parser = parser;
                this.reader = reader;
                this.sorter = sorter;
                this.writer = writer;
            }
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
