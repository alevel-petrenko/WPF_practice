namespace BusinessLayer.Utilities.Parser.Interfaces
{
    /// <summary>
    /// Represents general interface for data parser classes.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public interface IDataParser<T>
    {
        /// <summary>
        /// Converts data to collection of srecific type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        T[] DataConverter(string content);
    }
}
