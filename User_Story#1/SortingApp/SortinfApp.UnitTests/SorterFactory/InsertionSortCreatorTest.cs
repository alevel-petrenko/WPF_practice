using BusinessLayer.SorterFactory;
using BusinessLayer.SortingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.SorterFactory
{
    /// <summary>
    /// Represents tests for InsertionSortCreator class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class InsertionSortCreatorTest
    {
        /// <summary>
        /// Tests Create method and gets new instance of InsertionSorter class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void InsertionSortCreator_Create_GetNewInstanceInsertionSorter()
        {
            //
            // Arrange.
            //
            var insertionSortCreator = new InsertionSortCreator<string>();
            var typeExpected = typeof(InsertionSorter<string>);

            //
            // Act.
            //
            var insertionSorterActual = insertionSortCreator.Create();

            //
            // Assert.
            //
            Assert.AreEqual(typeExpected, insertionSorterActual.GetType());
        }
    }
}
