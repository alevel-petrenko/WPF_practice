using BusinessLayer.Utilities.Parser.Interfaces;
using System;

namespace BusinessLayer.DataParser
{
    /// <summary>
    /// Parse collection to array of Double type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BusinessLayer.DataParser.Interfaces.IDataParser" />
    public class ArrayParcer<T> : IDataParser
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
        public void DataConverter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the ParserToIEnumerable class with array of separators.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public ArrayParcer()
        {
            separators = new char[] { '.', ',', ';', '/', ' ' };
        }
    }
}
