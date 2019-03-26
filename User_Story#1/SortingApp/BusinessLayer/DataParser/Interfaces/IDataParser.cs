﻿namespace BusinessLayer.DataParser.Interfaces
{
    /// <summary>
    /// Represents general interface for data parser classes.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public interface IDataParser
    {
        /// <summary>
        /// Convert data to collection of type Double.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        void ConvertDataToCollectionOfDouble();
    }
}
