using System;
using BusinessLayer.Utilities.Parser.Interfaces;
using BusinessLayer.Reader;
using BusinessLayer.SortingAlgorithms;
using BusinessLayer.Writer;
using BusinessLayer.SorterFactory;

namespace BusinessLayer
{
    /// <summary>
    /// Handles all requests regarding reading, sorting collection and writing it to the file.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    public class CollectionSortHandler<T> where T : IComparable
    {
        /// <summary>
        /// Holds the creator.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private CollectionSortCreatorBase<T> creator;

        /// <summary>
        /// Holds the parser.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private IDataParser<T> parser;

        /// <summary>
        /// Holds the reader.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private DataReader reader;

        /// <summary>
        /// Holds the sorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public T[] SortedCollection { get; private set; }

        /// <summary>
        /// Holds the sorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private CollectionSorterBase<T> sorter;

        /// <summary>
        /// Holds the unsorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public T[] UnSortedCollection { get; private set; }

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
        public CollectionSortHandler(DataReader reader, DataWriter<T> writer, IDataParser<T> parser)
        {
            if (reader != null && writer != null && parser != null)
            {
                this.parser = parser;
                this.reader = reader;
                this.writer = writer;
            }
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Executes sorting for collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Execute()
        {
            try
            {
                this.SortedCollection = new T[UnSortedCollection.Length];
                this.UnSortedCollection.CopyTo(SortedCollection, 0);
                this.sorter.Sort(SortedCollection);
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message + " was empty.");
            }
        }

        /// <summary>
        /// Generates the sorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="type">The type.</param>
        public void GenerateSorter(string type)
        {
            switch (type)
            {
                case "InsertionSort":
                    this.creator = new InsertionSortCreator<T>();
                    break;
                case "SelectionSort":
                    this.creator = new SelectionSortCreator<T>();
                    break;
                case "QuickSort":
                    this.creator = new QuickSortCreator<T>();
                    break;
                default:
                    return;
            }
            this.sorter = this.creator.Create();
        }

        /// <summary>
        /// Executes reading for collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Read()
        {
            try
            {
                this.UnSortedCollection = this.parser.DataConverter(this.reader.ReadContent());
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message + " was empty.");
            }
        }

        /// <summary>
        /// Writes sorted collection to file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Write()
        {
            this.writer.WriteContent(SortedCollection);
        }
    }
}
