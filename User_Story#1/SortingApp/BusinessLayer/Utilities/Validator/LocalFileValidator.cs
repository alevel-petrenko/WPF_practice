using System;
using BusinessLayer.Utilities.Validator.Interfaces;
using System.IO;

namespace BusinessLayer.Validator
{
    /// <summary>
    /// Checks whether content from file is valid.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.Interfaces.IValidator" />
    public class LocalFileValidator : IValidator
    {
        /// <summary>
        /// Determines whether data exists.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="content">The content of the file.</param>
        /// <returns>
        ///   <c>true</c> if data exists; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDataExist(string content)
        {
            return File.Exists(content) && this.IsFileInValidFormat(content);
        }

        /// <summary>
        /// Determines whether file is in valid format.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if file is in valid format; otherwise, <c>false</c>.
        /// </returns>
        private bool IsFileInValidFormat(string content)
        {
            if (content is null)
                throw new ArgumentNullException(nameof(content));

            string format = Path.GetExtension(content);
            if (format == ".txt" || format == ".doc" || format == ".docx")
                return true;

            else
                return false;
        }
    }
}
