using System;
using System.IO;
using BusinessLayer.Utilities.Validator.Interfaces;

namespace BusinessLayer.Reader
{
    /// <summary>
    /// Provides functionality that reads content from file and stores it.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public class DataReader
    {
        /// <summary>
        /// The validator.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly IValidator validator;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="validator">The validator.</param>
        public DataReader(IValidator validator)
        {
            if (validator is null)
                throw new ArgumentNullException(nameof(validator));

            this.validator = validator;
        }

        /// <summary>
        /// Reads the content from specified path through specified validator.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public string ReadContent(string path)
        {
            try
            {
                string content = string.Empty;
                if (!validator.IsDataExist(path))
                    return content;

                using (var reader = new StreamReader(path))
                {
                    content = reader.ReadToEnd();
                }

                return content;
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message + " was empty.");
            }
        }
    }
}
