using BusinessLayer.SorterFactory;
using BusinessLayer.SortingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests.SorterFactory
{
    /// <summary>
    /// Tests for InsertionSortCreator class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class InsertionSortCreatorTest
    {
        /// <summary>
        /// Tests Create method if call method it will get new instance InsertionSorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void InsertionSortCreator_Create_CallMethod_GetNewInstanceInsertionSorter()
        {
            //
            // Arrange.
            //
            var insertionSortCreator = new InsertionSortCreator<string>();
            var type = typeof(InsertionSorter<string>);
            //
            // Act.
            //
            var insertionSorterActual = insertionSortCreator.Create();

            //
            // Assert.
            //
            Assert.AreEqual(type, insertionSorterActual.GetType());
        }
    }
}
