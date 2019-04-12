using System;
using BusinessLayer.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.Utilities.Validator
{
    /// <summary>
    /// Tests for СloudFileValidator class. 
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class СloudFileValidatorTest
    {
        /// <summary>
        /// Tests IsDataExist if pass empty url it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void СloudFileValidator_IsDataExist_PassEmtptyUrl_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var cloudFileValidator = new СloudFileValidator();
            string url = null;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => cloudFileValidator.IsDataExist(url));
        }

        /// <summary>
        /// Tests IsDataExist if pass nonexistent url it will get false.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void СloudFileValidator_IsDataExist_PassNonexistentUrl_GetFalse()
        {
            //
            // Arrange.
            //
            var cloudFileValidator = new СloudFileValidator();
            string url = "https://abcd";
            bool actualResult;

            //
            // Act.
            //
            actualResult = cloudFileValidator.IsDataExist(url);

            //
            // Assert.
            //
            Assert.IsFalse(actualResult);
        }

        /// <summary>
        /// Tests IsDataExist if pass exist url it will get true.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void СloudFileValidator_IsDataExist_PassExistUrl_GetTrue()
        {
            //
            // Arrange.
            //
            var cloudFileValidator = new СloudFileValidator();
            string url = "https://www.microsoft.com/uk-ua/";
            bool actualResult;

            //
            // Act.
            //
            actualResult = cloudFileValidator.IsDataExist(url);

            //
            // Assert.
            //
            Assert.IsTrue(actualResult);
        }
    }
}
