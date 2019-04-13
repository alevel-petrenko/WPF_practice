using System;
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
        /// Tests IsDataExist if pass empty path it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void LocalFileValidator_IsDataExist_PassEmtptyPath_ThrowArgumentNullException()
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
            string path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.csv";
            bool actualResult;

            //
            // Act.
            //
            actualResult = localFileValidator.IsDataExist(path);

            //
            // Assert.
            //
            Assert.IsFalse(actualResult);
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
            string path = @"D:\collectionToRead.txt";
            bool actualResult;

            //
            // Act.
            //
            actualResult = localFileValidator.IsDataExist(path);

            //
            // Assert.
            //
            Assert.IsFalse(actualResult);
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
            string path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
            bool actualResult;

            //
            // Act.
            //
            actualResult = localFileValidator.IsDataExist(path);

            //
            // Assert.
            //
            Assert.IsTrue(actualResult);
        }
    }
}