using Business.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents base tests for queue collection.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public class QueueTestBase
	{
		/// <summary>
		/// Holds the queue.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		protected ICustomCollection<char> queue;

		/// <summary>
		/// Tests the array queue when add new element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayQueue_Add_AddNewElement_CollectionStoreNewElement()
		{
			//
			// Arrange.
			//
			char expectedChar = 'S';

			//
			// Act.
			//
			this.queue.Add(expectedChar);
			char actualChar = this.queue.ShowCurrent();

			//
			// Assert.
			//
			Assert.AreEqual(expectedChar, actualChar);
		}

		/// <summary>
		/// Tests the array queue when pass new element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayQueue_Clear_WhenCalled_CollectionIsEmpty()
		{
			//
			// Act.
			//
			this.queue.Add('D');
			this.queue.Add('A');
			this.queue.Add('Y');
			this.queue.Clear();

			//
			// Assert.
			//
			Assert.IsFalse(this.queue.Any());
		}

		/// <summary>
		/// Tests the empty array queue when peek first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ArrayQueue_ShowCurrent_QueueIsEmpty_GetInvalidOperationException()
		{
			//
			// Act.
			//
			this.queue.ShowCurrent();
		}

		/// <summary>
		/// Tests the array queue when peek first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayQueue_ShowCurrent_WhenCalled_GetTheFirstElement()
		{
			//
			// Arrange.
			//
			char expectedChar = 'D';

			//
			// Act.
			//
			this.queue.Add(expectedChar);
			this.queue.Add('A');
			this.queue.Add('Y');
			var actualChar = this.queue.ShowCurrent();

			//
			// Assert.
			//
			Assert.AreEqual(expectedChar, actualChar);
		}

		/// <summary>
		/// Tests the empty array queue when remove first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ArrayQueue_Remove_QueueIsEmpty_GetInvalidOperationException()
		{
			//
			// Act.
			//
			this.queue.Remove();
		}

		/// <summary>
		/// Tests the array queue when remove first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayQueue_Remove_WhenCalled_RemoveFirstElementFromCollection()
		{
			//
			// Arrange.
			//
			char expectedChar = 'D';

			//
			// Act.
			//
			this.queue.Add(expectedChar);
			this.queue.Add('A');
			var actualChar = this.queue.Remove();

			//
			// Assert.
			//
			Assert.AreEqual(expectedChar, actualChar);
		}
	}
}