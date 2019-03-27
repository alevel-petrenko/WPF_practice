namespace BusinessLayer.Utilities.Parser.Interfaces
{
    /// <summary>
    /// Represents general interface for data parser classes.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public interface IDataParser<T>
    {
        /// <summary>
        /// Convert data to collection of type Double.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        void DataConverter(string content);
    }
}
