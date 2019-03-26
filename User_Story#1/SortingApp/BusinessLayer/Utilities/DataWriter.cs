using System.IO;

namespace BusinessLayer.Writer
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
        /// <owner>Anton Petrenko</owner>
        /// <returns>The path.</returns>
        public string Path { get; set; }

        /// <summary>
        /// Writes the collection by specified path.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void WriteContent(T[] collection)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {

            }
        }
    }
}
