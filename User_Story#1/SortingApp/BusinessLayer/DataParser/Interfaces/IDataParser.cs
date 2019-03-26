namespace BusinessLayer.DataParser.Interfaces
{
    /// <summary>
    /// Represents general interface for validation classes.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public interface IDataParser
    {
        /// <summary>
        /// Determines whether data exists.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if data exists; otherwise, <c>false</c>.
        /// </returns>
        /// <owner>Anton Petrenko</owner>
        void ConvertDataToCollectionOfDouble();
    }
}
