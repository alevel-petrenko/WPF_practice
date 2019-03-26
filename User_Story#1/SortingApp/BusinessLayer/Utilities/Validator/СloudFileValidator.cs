using BusinessLayer.Validator.Interfaces;

namespace BusinessLayer.Validator
{
    /// <summary>
    /// Check whether content from cloud doc is valid.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.Interfaces.IValidator" />
    public class СloudFileValidator : IValidator
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
    }
}
