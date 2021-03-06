﻿using System;
using BusinessLayer.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingApp.UnitTests.Extensions
{
    /// <summary>
    /// Represents tests for TypeParser class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class TypeParserTest
    {
        /// <summary>
        /// Tests ChangeType method if pass empty value it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void TypeParser_ChangeType_PassEmptyValue_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var value = string.Empty;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => TypeParser.ChangeType<string>(value));
        }

        /// <summary>
        /// Tests ChangeType method if pass null value it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void TypeParser_ChangeType_PassNullValue_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            object integer = null;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => TypeParser.ChangeType<int>(integer));
        }

        /// <summary>
        /// Tests ChangeType method if pass string with integer it will make integer value.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void TypeParser_ChangeType_PassStringWithInt_MakeInt()
        {
            //
            // Arrange.
            //
            var inputValue = "150";
            var expectedResult = 150;
            int actualResult;

            //
            // Act.
            //
            actualResult = TypeParser.ChangeType<int>(inputValue);

            //
            // Assert.
            //
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Tests ChangeType method if pass string with integer it will make value type of int.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void TypeParser_ChangeType_PassStringWithInt_MakeValueTypeOfInt()
        {
            //
            // Arrange.
            //
            var inputValue = "10";
            var expectedType = typeof(int);
            int actualResult;

            //
            // Act.
            //
            actualResult = TypeParser.ChangeType<int>(inputValue);

            //
            // Assert.
            //
            Assert.AreEqual(expectedType, actualResult.GetType());
        }
    }
}
