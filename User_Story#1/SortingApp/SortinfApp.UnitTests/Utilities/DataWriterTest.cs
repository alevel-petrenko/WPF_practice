using System;
using BusinessLayer.Reader;
using BusinessLayer.Utilities.Validator.Interfaces.Fakes;
using BusinessLayer.Writer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.Utilities
{
    /// <summary>
    /// Represents tests for DataWriter class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class DataWriterTest
    {
        /// <summary>
        /// Tests WriteContent if pass empty collection it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void DataWriter_WriteContent_PassEmptyCollection_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var dataWriter = new DataWriter<double>();

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => dataWriter.WriteContent(null));
        }

        /// <summary>
        /// Tests WriteContent if pass empty path to the file it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void DataWriter_WriteContent_PassEmptyPathToTheFile_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var collection = new double[] { 1.01, 5.2, 10.131 };
            var dataWriter = new DataWriter<double>
            {
                Path = null
            };

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => dataWriter.WriteContent(collection));
        }

        /// <summary>
        /// Tests WriteContent if pass path to the file it will write collection to the file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void DataWriter_WriteContent_PassPathToTheFile_WriteCollectionToTheFile()
        {
            //
            // Arrange.
            //
            string actualCollection;
            string path = @"D:\collectionToWrite.txt";
            var collection = new double[] { 1.01, 5.2, 10.131 };
            var dataWriter = new DataWriter<double>
            {
                Path = path
            };
            var expectedCollection = "1.01;5.2;10.131";
            var validator = new StubIValidator()
            {
                IsDataExistString = (str) => true
            };
            var dataReader = new DataReader(validator)
            {
                Path = path
            };

            //
            // Act.
            //
            dataWriter.WriteContent(collection);
            actualCollection = dataReader.ReadContent();

            //
            // Assert.
            //
            Assert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
