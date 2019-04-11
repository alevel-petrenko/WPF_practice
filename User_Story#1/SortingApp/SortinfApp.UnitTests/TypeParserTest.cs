using System;
using BusinessLayer.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests
{
    /// <summary>
    /// Tests for TypeParser class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class TypeParserTest
    {
        /// <summary>
        /// Tests ChangeType method if pass null value it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void TypeParser_ChangeType_PassNullValue_ThrowArgumentNullException()
        {
            /// <summary>
            /// Arrange.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            object integer = null;

            /// <summary>
            /// Assert.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            Assert.ThrowsException<ArgumentNullException>( () => TypeParser.ChangeType<int>(integer));
        }

        /// <summary>
        /// Tests ChangeType method if pass string with number it will make integer value.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void TypeParser_ChangeType_PassStringWithInt_MakeInt()
        {
            /// <summary>
            /// Arrange.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            var inputValue = "150";
            var expectedResult = 150;

            /// <summary>
            /// Act.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            var actualResult = TypeParser.ChangeType<int>(inputValue);

            /// <summary>
            /// Assert.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Tests ChangeType method if pass string with int it will make value type of int.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void TypeParser_ChangeType_PassStringWithInt_MakeValueTypeOfInt()
        {
            /// <summary>
            /// Arrange.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            var inputValue = "10";
            var expectedType = typeof(int);

            /// <summary>
            /// Act.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            var actualResult = TypeParser.ChangeType<int>(inputValue);

            /// <summary>
            /// Assert.
            /// </summary>
            /// <owner>Anton Petrenko</owner>
            Assert.AreEqual(expectedType, actualResult.GetType());
        }
    }
}
