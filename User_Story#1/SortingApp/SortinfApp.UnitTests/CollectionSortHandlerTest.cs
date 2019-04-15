using BusinessLayer;
using BusinessLayer.Reader.Fakes;
using BusinessLayer.Utilities.Parser.Interfaces.Fakes;
using BusinessLayer.Utilities.Validator.Interfaces.Fakes;
using BusinessLayer.Writer.Fakes;
using Helper;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SortinfApp.UnitTests
{
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
            var reader = new StubDataReader(new StubIValidator());
            var writer = new StubDataWriter<double>();

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => new CollectionSortHandler<double>(reader, writer, null));
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
            var reader = new StubDataReader(new StubIValidator());

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => new CollectionSortHandler<double>(reader, null, parser));
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
            var writer = new StubDataWriter<double>();

            //
            // Assert.
            //
            Assert.ThrowsException<ArgumentNullException>(() => new CollectionSortHandler<double>(null, writer, parser));
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
                var path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
                var reader = new ShimDataReader();
                var writer = new StubDataWriter<int>();
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
                var writer = new StubDataWriter<int>();
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
        /// Tests Read if pass empty content to parser it will throw ArgumentNullException.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        [TestMethod]
        public void CollectionSortHandler_Read_PassEmptyEmptyContentToParser_ThrowArgumentNullException()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                CollectionSortHandler<int> collectionSortHandler;
                var path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
                var parser = new StubIDataParser<int>()
                {
                    ConvertDataString = (str) => throw new ArgumentNullException()
                };
                var writer = new StubDataWriter<int>();
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
                var path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
                var parser = new StubIDataParser<double>()
                {
                    ConvertDataString = (str) => new double[] { 166, 11, 56, 4, 1.5 }
                };
                var reader = new ShimDataReader();
                var writer = new StubDataWriter<double>();
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
                var path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
                var parser = new StubIDataParser<double>()
                {
                    ConvertDataString = (str) => new double[] { 166, 11, 56, 4, 1.5 }
                };
                var reader = new ShimDataReader();
                var writer = new StubDataWriter<double>();
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
                var path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
                var parser = new StubIDataParser<double>()
                {
                    ConvertDataString = (str) => new double[] { 166, 11, 56, 4, 1.5 }
                };
                var reader = new ShimDataReader();
                var writer = new StubDataWriter<double>();
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
        /// Collections the sort handler execute left empty unsorted collection throw argument null exception.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// TODO Edit XML Comment Template for CollectionSortHandler_Execute_LeftEmptyUnsortedCollection_ThrowArgumentNullException
        [TestMethod]
        public void CollectionSortHandler_Execute_LeftEmptyUnsortedCollection_ThrowArgumentNullException()
        {
            using (ShimsContext.Create())
            {
                //
                // Arrange.
                //
                var expectedCollection = new double[] { 1.5, 4, 11, 56, 166 };
                var sorterType = SortType.QuickSort;
                var path = @"D:\Git\WPF_practice\User_Story#1\collectionToRead.txt";
                var parser = new StubIDataParser<double>()
                {
                    ConvertDataString = (str) => new double[] { 166, 11, 56, 4, 1.5 }
                };
                var reader = new ShimDataReader();
                var writer = new StubDataWriter<double>();
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
    }
}
