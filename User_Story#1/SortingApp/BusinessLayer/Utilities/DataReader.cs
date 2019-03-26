using BusinessLayer.Validator.Interfaces;
using System.IO;

namespace BusinessLayer.Reader
{
    /// <summary>
    /// Read content from file and store it.
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
            this.validator = validator;
        }

        /// <summary>
        /// Reads the content from specified path through specified validator.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void ReadContent()
        {
            using (StreamReader reader = new StreamReader(Path))
            {

            }
        }
    }
}
