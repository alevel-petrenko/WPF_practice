using System;
using BusinessLayer.Utilities.Validator.Interfaces;
using System.Net;

namespace BusinessLayer.Validator
{
    /// <summary>
    /// Checks whether content of cloud doc is valid.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="BusinessLayer.Interfaces.IValidator" />
    public class СloudFileValidator : IValidator
    {
        /// <summary>
        /// Determines whether data exists.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="content">The content of cloud doc.</param>
        /// <returns>
        ///   <c>true</c> if data exists; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDataExist(string url)
        {
            if (url is null)
                throw new ArgumentNullException(nameof(url));
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}
