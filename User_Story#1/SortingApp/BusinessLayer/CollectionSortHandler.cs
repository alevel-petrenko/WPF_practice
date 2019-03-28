﻿using BusinessLayer.Utilities.Parser.Interfaces;
using BusinessLayer.Reader;
using BusinessLayer.SortingAlgorithms;
using BusinessLayer.Writer;
using System;

namespace BusinessLayer
{
    /// <summary>
    /// Handles all requests regarding reading, sorting collection and writing it to the file.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    public class CollectionSortHandler<T> where T : IComparable
    {
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
        private T[] sortedCollection;

        /// <summary>
        /// Holds the sorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private CollectionSorter<T> sorter;

        /// <summary>
        /// Holds the unsorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private T[] unSortedCollection;

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
        public CollectionSortHandler(DataReader reader, DataWriter<T> writer, CollectionSorter<T> sorter, IDataParser<T> parser)
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
        /// Executes sorting for collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Execute()
        {
            this.unSortedCollection.CopyTo(sortedCollection, 0);
            this.sorter.Sort(sortedCollection);
        }

        /// <summary>
        /// Executes reading for collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Read()
        {
            this.unSortedCollection = parser.DataConverter(reader.ReadContent());
        }

        /// <summary>
        /// Writes sorted collection to file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Write()
        {
            this.writer.WriteContent(sortedCollection);
        }
    }
}
