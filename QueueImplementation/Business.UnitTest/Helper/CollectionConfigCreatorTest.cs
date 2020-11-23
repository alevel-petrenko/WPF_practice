using Business.Helper;
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
		[DataRow("", "Array")]
		[DataRow("Queue", "")]
		[DataRow(" ", "Linked list")]
		[DataRow("Stack", " ")]
		[DataRow(null, "Array")]
		[DataRow("Stack", null)]
		[ExpectedException(typeof(ArgumentException))]
		public void CollectionConfigCreator_InitializeCollection_PassNotCorrectType_GetArgumentException(string selectedQueueStackType,
			string selectedArrayLinkedListType)
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
		[DataRow("Queue", "Array", typeof(ArrayQueue<char>))]
		[DataRow("Queue", "Linked list", typeof(LinkedListQueue<char>))]
		[DataRow("Stack", "Array", typeof(ArrayStack<char>))]
		[DataRow("Stack", "Linked list", typeof(LinkedListStack<char>))]
		public void CollectionConfigCreator_InitializeCollection_WhenCalled_GetCustomCollectionOfCorrectType(string selectedQueueStackType, 
			string selectedArrayLinkedListType, Type expectedType)
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