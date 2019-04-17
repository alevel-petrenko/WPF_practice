using System;
using System.IO;
using BusinessLayer.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.Utilities.Validator
{
    /// <summary>
    /// Represents tests for LocalFileValidator class. 
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class LocalFileValidatorTest
    {
        /// <summary>
        /// Tests IsDataExist if pass empty value it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void LocalFileValidator_IsDataExist_PassEmptyValue_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var localFileValidator = new LocalFileValidator();
            string path = string.Empty;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => localFileValidator.IsDataExist(path));
        }

        /// <summary>
        /// Tests IsDataExist if pass null value it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void LocalFileValidator_IsDataExist_PassNullValue_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var localFileValidator = new LocalFileValidator();
            string path = null;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => localFileValidator.IsDataExist(path));
        }

        /// <summary>
        /// Tests IsDataExist if pass exist file it will get true.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void LocalFileValidator_IsDataExist_PassExistFile_GetTrue()
        {
            //
            // Arrange.
            //
            var localFileValidator = new LocalFileValidator();
            string path = Path.GetTempPath() + @"\collectionToRead.txt";
            bool isDataValid;

            //
            // Act.
            //
            using (File.Create(path)) { }
            isDataValid = localFileValidator.IsDataExist(path);
            File.Delete(path);

            //
            // Assert.
            //
            Assert.IsTrue(isDataValid);
        }

        /// <summary>
        /// Tests IsDataExist if pass incorect format it will get false.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void LocalFileValidator_IsDataExist_PassIncorectFormat_GetFalse()
        {
            //
            // Arrange.
            //
            var localFileValidator = new LocalFileValidator();
            string path = Path.GetTempPath() + @"\collectionToRead.csv";
            bool isDataValid;

            //
            // Act.
            //
            using (File.Create(path)) { }
            isDataValid = localFileValidator.IsDataExist(path);
            File.Delete(path);

            //
            // Assert.
            //
            Assert.IsFalse(isDataValid);
        }

        /// <summary>
        /// Tests IsDataExist if pass nonexistent file it will get false.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void LocalFileValidator_IsDataExist_PassNonexistentFile_GetFalse()
        {
            //
            // Arrange.
            //
            var localFileValidator = new LocalFileValidator();
            string path = Path.GetTempPath();
            bool isDataValid;

            //
            // Act.
            //
            isDataValid = localFileValidator.IsDataExist(path);

            //
            // Assert.
            //
            Assert.IsFalse(isDataValid);
        }
    }
}