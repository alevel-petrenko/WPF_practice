using Business.Helper;
using Business.Helper.Enumeration;
using Business.Queue;
using Business.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents tests for <see cref="CollectionConfigCreator<T>"/>.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	[TestClass]
	public sealed class CollectionConfigCreatorTest
	{
		/// <summary>
		/// Holds the configuration creator.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private CollectionConfigCreator<char> creator;

		/// <summary>
		/// Tests the collection initialization when pass not correct collection or type.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="selectedQueueStackType">The type of the selected collection (queue/stack).</param>
		/// <param name="selectedArrayLinkedListType">The type of the selected collection (array/linked list).</param>
		[TestMethod]
		[DataRow(null, BasicCollectionType.Array)]
		[DataRow(CustomCollectionType.Stack, null)]
		[ExpectedException(typeof(ArgumentException))]
		public void CollectionConfigCreator_InitializeCollection_PassNotCorrectType_GetArgumentException(CustomCollectionType? selectedQueueStackType,
			BasicCollectionType? selectedArrayLinkedListType)
		{
			//
			// Act.
			//
			creator.InitializeCollection(selectedQueueStackType, selectedArrayLinkedListType);
		}

		/// <summary>
		/// Tests the collection initialization when pass collection and type.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="selectedQueueStackType">The type of the selected collection (queue/stack).</param>
		/// <param name="selectedArrayLinkedListType">The type of the selected collection (array/linked list).</param>
		/// <param name="expectedType">The type of expected collection.</param>
		[TestMethod]
		[DataRow(CustomCollectionType.Queue, BasicCollectionType.Array, typeof(ArrayQueue<char>))]
		[DataRow(CustomCollectionType.Queue, BasicCollectionType.LinkedList, typeof(LinkedListQueue<char>))]
		[DataRow(CustomCollectionType.Stack, BasicCollectionType.Array, typeof(ArrayStack<char>))]
		[DataRow(CustomCollectionType.Stack, BasicCollectionType.LinkedList, typeof(LinkedListStack<char>))]
		public void CollectionConfigCreator_InitializeCollection_WhenCalled_GetCustomCollectionOfCorrectType(CustomCollectionType selectedQueueStackType,
			BasicCollectionType selectedArrayLinkedListType, Type expectedType)
		{
			//
			// Act.
			//
			var actualCollection = creator.InitializeCollection(selectedQueueStackType, selectedArrayLinkedListType);

			//
			// Assert.
			//
			Assert.IsInstanceOfType(actualCollection, expectedType);
		}

		/// <summary>
		/// Setups this instance.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestInitialize]
		public void Setup()
		{
			this.creator = new CollectionConfigCreator<char>();
		}
	}
}