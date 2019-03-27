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
    public class ArrayParcer<T> : IDataParser<T>
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
        /// Initializes a new instance of the ParserToIEnumerable class with array of separators.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public ArrayParcer()
        {
            separators = new char[] { '.', ',', ';', '/' };
        }

        /// <summary>
        /// Convert data to collection of type Double.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void DataConverter(string content)
        {
            string[] items = content.Split(separators);
            for (int i = 0; i < items.Length; i++)
            {
                if (Double.TryParse(items[i], out double number))
                {
                    listOfItemsFromFile = new double[1]
                }
            }
        }
    }
}
