using Business.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents tests for <see cref="ArrayStack<T>"/>.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	[TestClass]
	public sealed class ArrayStackTest : StackTestBase
	{
		/// <summary>
		/// Tests the array stack for adding more than 4 records.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void ArrayStack_Add_AddFiveValues_AllValuesAreStored()
		{
			//
			// Action.
			//
			for (int i = 0; i < 5; i++)
				this.stack.Add(i);

			var actual = this.stack.ShowCurrent();

			//
			// Assert.
			//
			Assert.AreEqual(4, actual);
		}

		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestInitialize]
		public void SetUp()
		{
			this.stack = new ArrayStack<int>();
		}
	}
}