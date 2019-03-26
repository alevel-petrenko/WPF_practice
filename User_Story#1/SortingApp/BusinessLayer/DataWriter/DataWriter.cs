using BusinessLayer.Interfaces;
using System.IO;

namespace BusinessLayer.DataWriter
{
    /// <summary>
    /// Write content to file.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public class DataWriter<T>
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        /// <owner>Anton Petrenko</owner>
        public string Path { get; set; }

        /// <summary>
        /// The writer.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private StreamWriter writer;

        /// <summary>
        /// Writes the collection by specified path.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void WriteContent(T[] collection)
        {
            using (writer = new StreamWriter(Path))
            {

            }
        }
    }
}
