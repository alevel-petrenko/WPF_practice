using Business.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents tests for <see cref="ArrayQueue<T>"/>.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	[TestClass]
	public sealed class ArrayQueueTest : QueueTestBase
	{
		/// <summary>
		/// Tests the array queue when add new elements.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayQueue_Add_AddFiveNewElements_CollectionStoreElements()
		{
			//
			// Act.
			//
			this.queue.Add('A');
			this.queue.Add('B');
			this.queue.Add('C');
			this.queue.Add('D');
			this.queue.Add('E');
			char actualChar = this.queue.ShowCurrent();

			//
			// Assert.
			//
			Assert.AreEqual('A', actualChar);
		}

		/// <summary>
		/// Tests the array queue when add new elements.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayQueue_Add_AddSixNewElementsAndRemoveOne_CollectionStoreElements()
		{
			//
			// Act.
			//
			this.queue.Add('A');
			this.queue.Add('B');
			this.queue.Add('C');
			this.queue.Add('D');
			this.queue.Remove();
			this.queue.Add('E');
			this.queue.Add('F');
			char actualChar = this.queue.ShowCurrent();

			//
			// Assert.
			//
			Assert.AreEqual('B', actualChar);
		}

		/// <summary>
		/// Tests the enumerator of the array queue.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayQueue_GetEnumerator_AddElementsAndRemoveOneElement_ReceiveAllElementsInCorrectOrder()
		{
			//
			// Arrange.
			//
			string expected = "DAY1";
			string actual = string.Empty;

			//
			// Act.
			//
			this.queue.Add('O');
			this.queue.Add('D');
			this.queue.Add('A');
			this.queue.Add('Y');
			this.queue.Remove();
			this.queue.Add('1');

			foreach (var item in this.queue)
				actual += item;

			//
			// Assert.
			//
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Setups this instance.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestInitialize]
		public void Setup()
		{
			this.queue = new ArrayQueue<char>();
		}
	}
}