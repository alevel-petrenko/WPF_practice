using System;
using System.IO;
using BusinessLayer.Reader;
using BusinessLayer.SorterFactory;
using BusinessLayer.SortingAlgorithms;
using BusinessLayer.Utilities.Parser.Interfaces;
using BusinessLayer.Writer;
using Helper;

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
        /// Holds the parser.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly IDataParser<T> parser;

        /// <summary>
        /// Holds the reader.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly DataReader reader;

        /// <summary>
        /// Holds the sorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private CollectionSorterBase<T> sorter;

        /// <summary>
        /// Holds the writer.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly DataWriter<T> writer;

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
            if (reader is null)
                throw new ArgumentNullException(nameof(reader));

            if (parser is null)
                throw new ArgumentNullException(nameof(parser));

            if (writer is null)
                throw new ArgumentNullException(nameof(writer));

            this.parser = parser;
            this.reader = reader;
            this.writer = writer;
        }


        /// <summary>
        /// Executes sorting for collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Execute()
        {
            try
            {
                this.SortedCollection = new T[this.UnSortedCollection.Length];
                this.UnSortedCollection.CopyTo(this.SortedCollection, 0);
                this.sorter.Sort(this.SortedCollection);
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
        public void GenerateSorter(SortType type)
        {
            switch (type)
            {
                case SortType.InsertionSort:
                    this.sorter = new InsertionSortCreator<T>().Create();
                    break;
                case SortType.SelectionSort:
                    this.sorter = new SelectionSortCreator<T>().Create();
                    break;
                case SortType.QuickSort:
                    this.sorter = new QuickSortCreator<T>().Create();
                    break;
            }
        }

        /// <summary>
        /// Executes reading for collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Read(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            try
            {
                this.reader.Path = path;
                this.UnSortedCollection = this.parser.ConvertData(this.reader.ReadContent());
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message + " was empty.");
            }
            catch (IOException)
            {
                throw new Exception("Reading from the file failed.");
            }
        }

        /// <summary>
        /// Holds the sorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public T[] SortedCollection { get; private set; }

        /// <summary>
        /// Holds the unsorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public T[] UnSortedCollection { get; private set; }

        /// <summary>
        /// Writes sorted collection to file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Write(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            try
            {
                this.writer.Path = path;
                this.writer.WriteContent(this.SortedCollection);
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message + " was empty.");
            }
            catch (IOException)
            {
                throw new Exception("Writing to the file failed.");
            }
        }
    }
}
