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
		/// Tests the queue when add new element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Queue_Add_AddNewElement_CollectionStoreNewElement()
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
		/// Tests the queue when pass new element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Queue_Clear_WhenCalled_CollectionIsEmpty()
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
		/// Tests the enumerator of the  queue.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Queue_GetEnumerator_AddElements_ReceiveAllElements()
		{
			//
			// Arrange.
			//
			string expected = "DAY";
			string actual = string.Empty;

			//
			// Act.
			//
			this.queue.Add('D');
			this.queue.Add('A');
			this.queue.Add('Y');

			foreach (var item in this.queue)
				actual += item;

			//
			// Assert.
			//
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Tests the empty queue when peek first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Queue_ShowCurrent_QueueIsEmpty_GetInvalidOperationException()
		{
			//
			// Act.
			//
			this.queue.ShowCurrent();
		}

		/// <summary>
		/// Tests the queue when peek first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Queue_ShowCurrent_WhenCalled_GetTheFirstElement()
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
		/// Tests the empty queue when remove first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Queue_Remove_QueueIsEmpty_GetInvalidOperationException()
		{
			//
			// Act.
			//
			this.queue.Remove();
		}

		/// <summary>
		/// Tests the queue when remove first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Queue_Remove_WhenCalled_RemoveFirstElementFromCollection()
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