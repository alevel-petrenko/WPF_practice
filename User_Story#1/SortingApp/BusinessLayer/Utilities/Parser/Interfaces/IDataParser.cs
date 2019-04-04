using System;

namespace BusinessLayer.Utilities.Parser.Interfaces
{
    /// <summary>
    /// Provides functionality that parses data.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public interface IDataParser<T> where T : IComparable
    {
        /// <summary>
        /// Converts data to collection of specific type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="content">Content of the file.</param>
        T[] ConvertData(string content);
    }
}
