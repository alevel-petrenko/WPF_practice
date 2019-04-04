﻿using System;
using BusinessLayer.Utilities.Validator.Interfaces;
using System.IO;

namespace BusinessLayer.Validator
{
    /// <summary>
    /// Checks whether content of file is valid.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.Interfaces.IValidator" />
    public class LocalFileValidator : IValidator
    {
        /// <summary>
        /// Determines whether data exists.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="path">The path to the file.</param>
        /// <returns>
        ///   <c>true</c> if data exists; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDataExist(string path)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            return File.Exists(path) && this.IsFileInValidFormat(path);
        }

        /// <summary>
        /// Determines whether file is in valid format.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="path">The path to the file.</param>
        /// <returns>
        ///   <c>true</c> if file is in valid format; otherwise, <c>false</c>.
        /// </returns>
        private bool IsFileInValidFormat(string path)
        {
            string format = Path.GetExtension(path);
            if (format == ".txt")
                return true;

            else
                return false;
        }
    }
}
