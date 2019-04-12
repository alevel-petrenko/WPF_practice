using BusinessLayer.DataParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SortinfApp.UnitTests.Utilities.Parser
{
    /// <summary>
    /// 
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class ArrayParserTest
    {
        /// <summary>
        /// Tests ConvertData if pass null content it will get ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void ArrayParser_ConvertData_PassNullContent_GetArgumentNullException()
        {
            //
            // Arrange.
            //
            var arrayParser = new ArrayParser<bool>();
            string dataToConvert = null;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => arrayParser.ConvertData(dataToConvert));
        }

        /// <summary>
        /// Arrays the parser convert data pass null content get argument null exception.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void ArrayParser_ConvertData_PassStringWithBoolValues_GetArrayOfBoolValues()
        {
            //
            // Arrange.
            //
            var arrayParser = new ArrayParser<bool>();
            string dataToConvert = "true, false, false, true, false";

            //
            // Act.
            //

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => arrayParser.ConvertData(dataToConvert));
        }
    }
}
