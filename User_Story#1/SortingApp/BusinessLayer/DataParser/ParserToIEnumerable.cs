using BusinessLayer.DataParser.Interfaces;
using System;
using System.Collections.Generic;

namespace BusinessLayer.DataParser
{
    /// <summary>
    /// Parse collection to array of Double type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.DataParser.Interfaces.IDataParser" />
    public class ParserToIEnumerable<T> : IDataParser
    {
        /// <summary>
        /// The list of items from file
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private T[] listOfItemsFromFile;

        /// <summary>
        /// The separators array
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly char[] separators;

        /// <summary>
        /// Convert data to collection of type Double.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void ConvertDataToCollectionOfDouble()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the ParserToIEnumerable class with array of separators.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public ParserToIEnumerable()
        {
            separators = new char[] { '.', ',', ';', '/', ' ' };
        }
    }
}
