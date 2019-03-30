using System;
using System.IO;

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

        public DataWriter()
        {
            Path = @"D:\Git\WPF_practice\User_Story#1\collectionToWrite.txt";
        }

        /// <summary>
        /// Writes the collection by specified path.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void WriteContent(T[] collection)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path))
                {
                    foreach (var value in collection)
                    {
                        writer.Write(value + "; ");
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
