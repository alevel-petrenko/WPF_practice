using System;
using System.Linq;
using BusinessLayer.SortingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingApp.UnitTests.SortingAlgorithms
{
    /// <summary>
    /// Tests for InsertionSorter class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class InsertionSorterTest
    {
        /// <summary>
        /// Tests Sort method if pass null collection it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void InsertionSorter_Sort_PassNullCollection_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            double[] array = null;
            var insertionSorter = new InsertionSorter<double>();

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => insertionSorter.Sort(array));
        }

        /// <summary>
        /// Tests Sort method if pass sorted collection it will leave sorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void InsertionSorter_Sort_PassSortedCollection_GetSortedCollection()
        {
            //
            // Arrange.
            //
            var actualArray = new double[] { 0.15, 0.2, 1.56, 5.0, 9.99 };
            var expectedArray = new double[] { 0.15, 0.2, 1.56, 5.0, 9.99 };
            var insertionSorter = new InsertionSorter<double>();
            bool isCollectionSorted;

            //
            // Act.
            //
            insertionSorter.Sort(actualArray);
            isCollectionSorted = actualArray.SequenceEqual(expectedArray);

            //
            // Assert.
            //
            Assert.IsTrue(isCollectionSorted);
        }

        /// <summary>
        /// Tests Sort method if pass unsorted collection it will make sorted collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void InsertionSorter_Sort_PassUnsortedCollection_GetSortedCollection()
        {
            //
            // Arrange.
            //
            var actualArray = new double[] { 1.56, 0.2, 376.0, 0.15};
            var expectedArray = new double[] { 0.15, 0.2, 1.56, 376.0 };
            var insertionSorter = new InsertionSorter<double>();
            bool isCollectionSorted;

            //
            // Act.
            //
            insertionSorter.Sort(actualArray);
            isCollectionSorted = actualArray.SequenceEqual(expectedArray);

            //
            // Assert.
            //
            Assert.IsTrue(isCollectionSorted);
        }
    }
}
