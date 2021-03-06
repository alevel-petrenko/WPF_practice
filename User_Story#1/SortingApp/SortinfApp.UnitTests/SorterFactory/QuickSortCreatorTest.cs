﻿using BusinessLayer.SorterFactory;
using BusinessLayer.SortingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.SorterFactory
{
    /// <summary>
    /// Represents tests for QuickSortCreator class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class QuickSortCreatorTest
    {
        /// <summary>
        /// Tests Create method and gets new instance of QuickSorter class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void QuickSortCreator_Create_GetNewInstanceSelectionSort()
        {
            //
            // Arrange.
            //
            var quickSortCreator = new QuickSortCreator<string>();
            var typeExpected = typeof(QuickSorter<string>);

            //
            // Act.
            //
            var quickSorterActual = quickSortCreator.Create();

            //
            // Assert.
            //
            Assert.AreEqual(typeExpected, quickSorterActual.GetType());
        }
    }
}
