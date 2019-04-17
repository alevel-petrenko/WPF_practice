using System;
using System.Collections.Generic;
using BusinessLayer.Extensions;
using BusinessLayer.Utilities.Parser.Interfaces;

namespace BusinessLayer.DataParser
{
    /// <summary>
    /// Provides functionality that parses string into array of specific type.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    /// <seealso cref="BusinessLayer.DataParser.Interfaces.IDataParser" />
    public class ArrayParser<T> : IDataParser<T> where T : IComparable
    {
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
            this.separators = new char[] { ';', ',', '/', '|'};
        }

        /// <summary>
        /// Convert data to collection of type T.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="content">Content of the file.</param>
        public T[] ConvertData(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException(nameof(content));

            try
            {
                var numbers = new List<T>();
                string[] items = content.Split(separators);
                for (int i = 0; i < items.Length; i++)
                {
                    numbers.Add(TypeParser.ChangeType<T>(items[i].Trim()));
                }

                return numbers.ToArray();
            }
            catch(ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
