using BusinessLayer.Interfaces;
using System.IO;

namespace BusinessLayer.DataReader
{
    /// <summary>Read content from file and store it</summary>
    /// <author>Anton Petrenko</author>
    public class DataReader
    {
        public string Content { get; set; }
        public string Path { get; set; }
        private StreamReader reader;
        private readonly IValidator validator;

        public DataReader(IValidator validator)
        {
            this.validator = validator;
        }

        public void ReadContent()
        {
            using (reader = new StreamReader(Path))
            {

            }
        }
    }
}
