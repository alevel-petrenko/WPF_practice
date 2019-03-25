using BusinessLayer.Interfaces;

namespace BusinessLayer.DataReader
{
    /// <summary>Check whether content from file is valid</summary>
    /// <author>Anton Petrenko</author>
    public class LocalFileValidator : IValidator
    {
        public bool IsDataExist(string content)
        {
            throw new System.NotImplementedException();
        }

        private bool IsFileInValidFormat(string content)
        {
            throw new System.NotImplementedException();
        }
    }
}
