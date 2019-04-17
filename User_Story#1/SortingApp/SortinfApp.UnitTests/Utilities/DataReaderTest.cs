using System;
using System.IO;
using BusinessLayer.Reader;
using BusinessLayer.Utilities.Validator.Interfaces.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.Utilities
{
    /// <summary>
    /// Represents tests for DataReader class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class DataReaderTest
    {
        /// <summary>
        /// Tests DataReader if pass empty validator in constructor it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void DataReader_DataReader_PassEmptyValidatorInConstructor_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            StubIValidator validator = null;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => new DataReader(validator));
        }

        /// <summary>
        /// Tests ReadContent if pass empty path to the file it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void DataReader_ReadContent_PassEmptyPathToTheFile_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var validator = new StubIValidator()
            {
                IsDataExistString = (string str) => true
            };
            var dataReader = new DataReader(validator);
            var path = string.Empty;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => dataReader.ReadContent(path));
        }

        /// <summary>
        /// Tests ReadContent if pass incorrect path to the file it will get empty result.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void DataReader_ReadContent_PassIncorrectPathToTheFile_GetEmptyString()
        {
            //
            // Arrange.
            //
            string actualResult;
            var expectedResult = string.Empty;
            var validator = new StubIValidator()
            {
                IsDataExistString = (string str) => false
            };
            var dataReader = new DataReader(validator);
            var path = Path.GetTempPath();

            //
            // Act.
            //
            actualResult = dataReader.ReadContent(path);

            //
            // Assert.
            //
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Tests ReadContent if pass correct path to the file it will get correct content of the file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void DataReader_ReadContent_PassPathToTheFile_GetCorrectContentOfTheFile()
        {
            //
            // Arrange.
            //
            string actualResult;
            string expectedResult = "166/ 11/ 56/ 4 / 1.5/ 1/ 0.99/ 4.95/ 487/ 1000/ 1.45/ 0.99";
            string path = Path.GetTempPath() + @"\collectionToRead.txt";
            var validator = new StubIValidator()
            {
                IsDataExistString = (string str) => true
            };
            var dataReader = new DataReader(validator);

            //
            // Act.
            //
            File.WriteAllText(path, expectedResult);
            actualResult = dataReader.ReadContent(path);
            File.Delete(path);

            //
            // Assert.
            //
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
