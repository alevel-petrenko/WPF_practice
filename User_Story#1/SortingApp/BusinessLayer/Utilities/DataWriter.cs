using System;
using System.IO;
using System.Linq;

namespace BusinessLayer.Writer
{
    /// <summary>
    /// Provides functionality that writes content to file.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public class DataWriter<T> where T : IComparable
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
            if (collection is null || !collection.Any())
                throw new ArgumentNullException(nameof(collection));

            try
            {
                string temp = string.Empty;
                foreach (var value in collection)
                {
                    temp = string.Join(";", collection.Select(item => item));
                }

                using (var writer = new StreamWriter(this.Path))
                {
                    writer.Write(temp);
                }
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }
    }
}
