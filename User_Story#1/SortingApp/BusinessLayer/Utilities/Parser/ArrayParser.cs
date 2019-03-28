using BusinessLayer.Extensions;
using BusinessLayer.Utilities.Parser.Interfaces;
using System.Collections.Generic;

namespace BusinessLayer.DataParser
{
    /// <summary>
    /// Parses string into array of srecific type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BusinessLayer.DataParser.Interfaces.IDataParser" />
    public class ArrayParser<T> : IDataParser<T>
    {
        /// <summary>
        /// The list of items from file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private T[] listOfItemsFromFile;

        /// <summary>
        /// The array with separator values.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly char[] separators;

        /// <summary>
        /// Initializes a new instance of the Parser class with array of separators.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public ArrayParser()
        {
            this.listOfItemsFromFile = new T[1];
            this.separators = new char[] { ';', '/', '|' };
        }

        /// <summary>
        /// Convert data to collection of type T.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public T[] DataConverter(string content)
        {
            List<T> numbers = new List<T>();
            string[] items = content.Split(separators);
            for (int i = 0; i < items.Length; i++)
            {
                numbers.Add(TypeParser.ChangeType<T>(items[i].Trim()));
            }
            this.listOfItemsFromFile = numbers.ToArray();
            return this.listOfItemsFromFile;
        }
    }
}
