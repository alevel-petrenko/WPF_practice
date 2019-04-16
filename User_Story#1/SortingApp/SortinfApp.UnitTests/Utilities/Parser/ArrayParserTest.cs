using System;
using System.Linq;
using BusinessLayer.DataParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.Utilities.Parser
{
    /// <summary>
    /// Represents tests for ArrayParser class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class ArrayParserTest
    {
        /// <summary>
        /// Tests ConvertData if pass null content it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void ArrayParser_ConvertData_PassEmptyContent_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var arrayParser = new ArrayParser<bool>();
            string dataToConvert = "     ";

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => arrayParser.ConvertData(dataToConvert));
        }

        /// <summary>
        /// Tests ConvertData if pass string with bool values it will get array of bool values.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void ArrayParser_ConvertData_PassStringWithBoolValues_GetArrayOfBoolValues()
        {
            //
            // Arrange.
            //
            var arrayParser = new ArrayParser<bool>();
            string dataToConvert = "true, false;false/true|false";
            var expectedArray = new bool[] { true, false, false, true, false };
            bool actualResult;

            //
            // Act.
            //
            var actualArray = arrayParser.ConvertData(dataToConvert);
            actualResult = actualArray.SequenceEqual(expectedArray);

            //
            // Assert.
            //
            Assert.IsTrue(actualResult);
        }

        /// <summary>
        /// Tests ConvertData if pass string with one empty value between separators it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void ArrayParser_ConvertData_PassStringWithOneEmptyValue_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var arrayParser = new ArrayParser<bool>();
            string dataToConvert = "true,;false/true|false";

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => arrayParser.ConvertData(dataToConvert));
        }
    }
}
