using BusinessLayer.Extentions;
using BusinessLayer.Utilities.Parser.Interfaces;

namespace BusinessLayer.DataParser
{
    /// <summary>
    /// Parse collection to array of Double type.
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
        /// The separators array.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly char[] separators;

        /// <summary>
        /// Initializes a new instance of the Parser class with array of separators.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public ArrayParser()
        {
            listOfItemsFromFile = new T[1];
            this.separators = new char[] { ';', '/', '|' };
        }

        /// <summary>
        /// Convert data to collection of type T.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public T[] DataConverter(string content)
        {
            string[] items = content.Split(separators);
            for (int i = 0; i < items.Length; i++)
            {
                listOfItemsFromFile[i] = TypeParser.ChangeType<T>(items[i].Trim());
                listOfItemsFromFile.CopyTo(listOfItemsFromFile, 0);
            }
            return listOfItemsFromFile;
        }
    }
}
