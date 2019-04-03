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
        /// Initializes a new instance of the class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public DataWriter()
        {
            this.Path = @"D:\Git\WPF_practice\User_Story#1\collectionToWrite.txt";
        }

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
            if(collection is null || !collection.Any())
            throw new ArgumentNullException(nameof(collection));
            try
            {
                using (var writer = new StreamWriter(Path))
                {
                    foreach (var value in collection)
                    {
                        string.Join(";", collection.Select(item => item));
                    }
                }
            }
            catch
            {
                throw new IOException();
            }
        }
    }
}
