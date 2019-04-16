using BusinessLayer.SorterFactory;
using BusinessLayer.SortingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.SorterFactory
{
    /// <summary>
    /// Represents tests for SelectionSortCreator class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class SelectionSortCreatorTest
    {
        /// <summary>
        /// Tests Create method and gets new instance of SelectionSorter class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void SelectionSortCreator_Create_GetNewInstanceSelectionSort()
        {
            //
            // Arrange.
            //
            var selectionSortCreator = new SelectionSortCreator<string>();
            var typeExpected = typeof(SelectionSorter<string>);

            //
            // Act.
            //
            var selectionSorterActual = selectionSortCreator.Create();

            //
            // Assert.
            //
            Assert.AreEqual(typeExpected, selectionSorterActual.GetType());
        }
    }
}
