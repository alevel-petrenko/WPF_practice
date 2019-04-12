using BusinessLayer.SorterFactory;
using BusinessLayer.SortingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.SorterFactory
{
    /// <summary>
    /// Tests for QuickSortCreator class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class QuickSortCreatorTest
    {
        /// <summary>
        /// Tests Create method if call method it will get new instance QuickSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void QuickSortCreator_Create_CallMethod_GetNewInstanceSelectionSort()
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
