using BusinessLayer.Validator.Interfaces;

namespace BusinessLayer.Validator
{
    /// <summary>
    /// Check whether content from file is valid.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.Interfaces.IValidator" />
    public class LocalFileValidator : IValidator
    {
        /// <summary>
        /// Determines whether data exists.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if data exists; otherwise, <c>false</c>.
        /// </returns>
        /// <owner>Anton Petrenko</owner>
        public bool IsDataExist(string content)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether file is in valid format.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if file is in valid format; otherwise, <c>false</c>.
        /// </returns>
        /// <owner>Anton Petrenko</owner>
        private bool IsFileInValidFormat(string content)
        {
            throw new System.NotImplementedException();
        }
    }
}
