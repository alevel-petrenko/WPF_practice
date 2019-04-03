using System;
using BusinessLayer.Utilities.Validator.Interfaces;
using System.IO;

namespace BusinessLayer.Reader
{
    /// <summary>
    /// Provides functionality that reads content from file and store it.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public class DataReader
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The content.</returns>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The path.</returns>
        public string Path { get; set; }

        /// <summary>
        /// The validator
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly IValidator validator;

        /// <summary>
        /// Initializes a new instance of the DataReader class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="validator">The validator.</param>
        public DataReader(IValidator validator)
        {
            if (validator != null)
            {
                this.validator = validator;
                this.Path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
            }
            else
                throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Reads the content from specified path through specified validator.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public string ReadContent()
        {
            try
            {
                if (validator.IsDataExist(this.Path))
                {
                    using (StreamReader reader = new StreamReader(this.Path))
                    {
                        this.Content = reader.ReadToEnd();
                    }
                }
                return this.Content;
            }
            catch (ArgumentNullException e)
            {
                throw new Exception(e.Message + " causes exception");
            }
        }
    }
}
