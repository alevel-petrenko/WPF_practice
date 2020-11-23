using Business.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents base tests for the stack collection.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public class StackTestBase
	{
		/// <summary>
		/// Holds the stack.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		protected ICustomCollection<int> stack;

		/// <summary>
		/// Tests the stack when add new element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Stack_Add_AddNewElement_CollectionStoreNewElement()
		{
			//
			// Arrange.
			//
			int expectedInteger = 5;

			//
			// Act.
			//
			this.stack.Add(1);
			this.stack.Add(expectedInteger);
			int actualInteger = this.stack.ShowCurrent();

			//
			// Assert.
			//
			Assert.AreEqual(expectedInteger, actualInteger);
		}

		/// <summary>
		/// Tests the stack when pass new element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Stack_Clear_WhenCalled_CollectionIsEmpty()
		{
			//
			// Act.
			//
			this.stack.Add(1);
			this.stack.Add(2);
			this.stack.Add(3);
			this.stack.Clear();

			//
			// Assert.
			//
			Assert.IsFalse(this.stack.Any());
		}

		/// <summary>
		/// Tests the enumerator of the stack.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Stack_GetEnumerator_AddElements_ReceiveAllElements()
		{
			//
			// Arrange.
			//
			int expected = 60;
			int actual = default;

			//
			// Act.
			//
			this.stack.Add(10);
			this.stack.Add(20);
			this.stack.Add(30);

			foreach (var item in this.stack)
				actual += item;

			//
			// Assert.
			//
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Tests the empty stack when peek last element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Stack_ShowCurrent_StackIsEmpty_GetInvalidOperationException()
		{
			//
			// Act.
			//
			this.stack.ShowCurrent();
		}

		/// <summary>
		/// Tests the stack when peek last element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Stack_ShowCurrent_WhenCalled_GetTheFirstElement()
		{
			//
			// Arrange.
			//
			int expectedInteger = 3;

			//
			// Act.
			//
			this.stack.Add(1);
			this.stack.Add(2);
			this.stack.Add(expectedInteger);
			var actualInteger = this.stack.ShowCurrent();

			//
			// Assert.
			//
			Assert.AreEqual(expectedInteger, actualInteger);
		}

		/// <summary>
		/// Tests the empty stack when remove first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Stack_Remove_StackIsEmpty_GetInvalidOperationException()
		{
			//
			// Act.
			//
			this.stack.Remove();
		}

		/// <summary>
		/// Tests the stack when remove first element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void Stack_Remove_WhenCalled_RemoveFirstElementFromCollection()
		{
			//
			// Arrange.
			//
			int expectedInteger = 2;

			//
			// Act.
			//
			this.stack.Add(1);
			this.stack.Add(expectedInteger);
			var actualInteger = this.stack.Remove();

			//
			// Assert.
			//
			Assert.AreEqual(expectedInteger, actualInteger);
		}
	}
}