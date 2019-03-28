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
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if data exists; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDataExist(string content)
        {
            return File.Exists(content) ? IsFileInValidFormat(content) : false;
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
            if (content != null)
            {
                string[] subArray = content.Split('.');
                string format = subArray[subArray.Length - 1];
                if (format == "txt" || format == "doc" || format == "docx")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
