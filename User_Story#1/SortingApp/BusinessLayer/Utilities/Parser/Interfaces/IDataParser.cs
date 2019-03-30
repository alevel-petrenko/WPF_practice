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
        /// Converts data to collection of srecific type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        T[] DataConverter(string content);
    }
}
