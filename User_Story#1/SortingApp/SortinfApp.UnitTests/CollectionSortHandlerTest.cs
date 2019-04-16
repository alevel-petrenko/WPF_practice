using System;
using System.IO;
using System.Linq;
using BusinessLayer;
using BusinessLayer.Reader.Fakes;
using BusinessLayer.Utilities.Parser.Interfaces.Fakes;
using BusinessLayer.Utilities.Validator.Interfaces.Fakes;
using BusinessLayer.Writer.Fakes;
using Helper;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortinfApp.UnitTests
{
    /// <summary>
    /// Represents tests for CollectionSortHandler class.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    [TestClass]
    public class CollectionSortHandlerTest
    {
        /// <summary>
        /// Collections the sort handler collection sort handler pass null value in constructor throw argument null exception.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_CollectionSortHandler_PassNullParserInConstructor_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            StubIDataParser parser = null;
            var reader = new ShimDataReader(new StubIValidator());
            var writer = new ShimDataWriter<double>();

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => new CollectionSortHandler<double>(reader, writer, parser));
        }

        /// <summary>
        /// Collections the sort handler collection sort handler pass null value in constructor throw argument null exception.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_CollectionSortHandler_PassNullReaderInConstructor_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var parser = new StubIDataParser<double>();
            ShimDataReader reader = null;
            var writer = new ShimDataWriter<double>();

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => new CollectionSortHandler<double>(reader, writer, parser));
        }

        /// <summary>
        /// Collections the sort handler collection sort handler pass null value in constructor throw argument null exception.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_CollectionSortHandler_PassNullWriterInConstructor_ThrowArgumentNullException()
        {
            //
            // Arrange.
            //
            var parser = new StubIDataParser<double>();
            var reader = new ShimDataReader(new StubIValidator());
            ShimDataWriter writer = null;

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => new CollectionSortHandler<double>(reader, writer, parser));
        }

        /// <summary>
        /// Tests Execute if left empty unsorted collection it will throw exception.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Execute_LeftEmptyUnsortedCollection_ThrowException()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var parser = new StubIDataParser<double>();
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<double>();
                CollectionSortHandler<double> collectionSortHandler;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<double>(reader, writer, parser);

                //
                // Assert.
                //
                Assert.ThrowsException<Exception>(() => collectionSortHandler.Execute());
            }
        }

        /// <summary>
        /// Tests Execute if pass InsertionSort as SortType it will get sorted collection according to that type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Execute_PassInsertionSortType_GetSortedCollection()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var expectedCollection = new double[] { 1.5, 4, 11, 56, 166 };
                var sorterType = SortType.InsertionSort;
                var path = Path.GetTempPath();
                var parser = new StubIDataParser<double>()
                {
                    ConvertDataString = (str) => new double[] { 166, 11, 56, 4, 1.5 }
                };
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<double>();
                CollectionSortHandler<double> collectionSortHandler;
                bool result;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<double>(reader, writer, parser);
                collectionSortHandler.GenerateSorter(sorterType);
                collectionSortHandler.Read(path);
                collectionSortHandler.Execute();
                result = collectionSortHandler.SortedCollection.SequenceEqual(expectedCollection);

                //
                // Assert.
                //
                Assert.IsTrue(result);
            }
        }

        /// <summary>
        /// Tests Execute if pass QuickSort as SortType it will get sorted collection according to that type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Execute_PassQuickSortType_GetSortedCollection()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var expectedCollection = new double[] { 1.5, 4, 11, 56, 166 };
                var sorterType = SortType.QuickSort;
                var path = Path.GetTempPath();
                var parser = new StubIDataParser<double>()
                {
                    ConvertDataString = (str) => new double[] { 166, 11, 56, 4, 1.5 }
                };
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<double>();
                CollectionSortHandler<double> collectionSortHandler;
                bool result;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<double>(reader, writer, parser);
                collectionSortHandler.GenerateSorter(sorterType);
                collectionSortHandler.Read(path);
                collectionSortHandler.Execute();
                result = collectionSortHandler.SortedCollection.SequenceEqual(expectedCollection);

                //
                // Assert.
                //
                Assert.IsTrue(result);
            }
        }

        /// <summary>
        /// Tests Execute if pass SelectionSort as SortType it will get sorted collection according to that type.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Execute_PassSelectionSortType_GetSortedCollection()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var expectedCollection = new double[] { 1.5, 4, 11, 56, 166 };
                var sorterType = SortType.SelectionSort;
                var path = Path.GetTempPath();
                var parser = new StubIDataParser<double>()
                {
                    ConvertDataString = (str) => new double[] { 166, 11, 56, 4, 1.5 }
                };
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<double>();
                CollectionSortHandler<double> collectionSortHandler;
                bool result;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<double>(reader, writer, parser);
                collectionSortHandler.GenerateSorter(sorterType);
                collectionSortHandler.Read(path);
                collectionSortHandler.Execute();
                result = collectionSortHandler.SortedCollection.SequenceEqual(expectedCollection);

                //
                // Assert.
                //
                Assert.IsTrue(result);
            }
        }

        /// <summary>
        /// Tests Read if pass correct path to the file it will get correct content of the file.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Read_PassCorrectPathToTheFile_GetCorrectContent()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                int[] actualCollection;
                var expectedCollection = new int[] { 125, 12, 33 };
                var parser = new StubIDataParser<int>()
                {
                    ConvertDataString = (str) => expectedCollection
                };
                var path = Path.GetTempPath();
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<int>();
                CollectionSortHandler<int> collectionSortHandler;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<int>(reader, writer, parser);
                collectionSortHandler.Read(path);
                actualCollection = collectionSortHandler.UnSortedCollection;

                //
                // Assert.
                //
                Assert.AreEqual(expectedCollection, actualCollection);
            }
        }

        /// <summary>
        /// Tests Read if pass empty content to parser it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Read_PassEmptyContentToParser_ThrowArgumentNullException()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                CollectionSortHandler<int> collectionSortHandler;
                var path = Path.GetTempPath();
                var parser = new StubIDataParser<int>()
                {
                    ConvertDataString = (str) => throw new ArgumentNullException()
                };
                var writer = new ShimDataWriter<int>();
                var reader = new ShimDataReader();

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<int>(reader, writer, parser);

                //
                // Assert.
                //
                Assert.ThrowsException<Exception>(() => collectionSortHandler.Read(path));
            }
        }

        /// <summary>
        /// Tests Read if pass empty path to the file it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Read_PassEmptyPath_ThrowArgumentNullException()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var parser = new StubIDataParser<int>();
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<int>();
                CollectionSortHandler<int> collectionSortHandler;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<int>(reader, writer, parser);

                //
                // Assert.
                //
                Assert.ThrowsException<ArgumentNullException>(() => collectionSortHandler.Read("   "));
            }
        }

        /// <summary>
        /// Tests Write if left empty collection it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Write_LeftEmptySortedCollection_ThrowArgumentNullException()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var path = Path.GetTempPath();
                var parser = new StubIDataParser<double>();
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<double>()
                {
                    WriteContentT0Array = (array) => throw new ArgumentNullException()
                };
                CollectionSortHandler<double> collectionSortHandler;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<double>(reader, writer, parser);

                //
                // Assert.
                //
                Assert.ThrowsException<ArgumentNullException>(() => collectionSortHandler.Write(path));
            }
        }
    
        /// <summary>
        /// Tests Write if pass empty path ut will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Write_PassEmptyPath_ThrowArgumentNullException()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var parser = new StubIDataParser<double>();
                var reader = new ShimDataReader();
                var writer = new ShimDataWriter<double>();
                CollectionSortHandler<double> collectionSortHandler;

                //
                // Act.
                //
                collectionSortHandler = new CollectionSortHandler<double>(reader, writer, parser);

                //
                // Assert.
                //
                Assert.ThrowsException<ArgumentNullException>(() => collectionSortHandler.Write(null));
            }
        }
    }
}
