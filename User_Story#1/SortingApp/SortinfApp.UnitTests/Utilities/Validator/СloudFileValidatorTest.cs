using System;
using BusinessLayer.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.Utilities.Validator
{
    /// <summary>
    /// Represents tests for СloudFileValidator class. 
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
        public void СloudFileValidator_IsDataExist_PassEmptyUrl_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var cloudFileValidator = new СloudFileValidator();
            string url = "   ";

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => cloudFileValidator.IsDataExist(url));
        }

        /// <summary>
        /// Tests IsDataExist if pass null url it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void СloudFileValidator_IsDataExist_PassNullUrl_ThrowArgumentNullException()
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
            bool isResourceValid;

            //
            // Act.
            //
            isResourceValid = cloudFileValidator.IsDataExist(url);

            //
            // Assert.
            //
            Assert.IsTrue(isResourceValid);
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
            bool isResourceValid;

            //
            // Act.
            //
            isResourceValid = cloudFileValidator.IsDataExist(url);

            //
            // Assert.
            //
            Assert.IsFalse(isResourceValid);
        }
    }
}
