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
        /// <value>
        /// The content.
        /// </value>
        /// <owner>Anton Petrenko</owner>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        /// <owner>Anton Petrenko</owner>
        public string Path { get; set; }

        /// <summary>
        /// The reader
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private StreamReader reader;

        /// <summary>
        /// The validator
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly IValidator validator;

        /// <summary>
        /// Initializes a new instance of the DataReader class.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <owner>Anton Petrenko</owner>
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
            using (reader = new StreamReader(Path))
            {

            }
        }
    }
}
