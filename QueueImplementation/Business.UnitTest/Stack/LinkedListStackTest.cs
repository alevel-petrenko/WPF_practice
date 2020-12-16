using Business.Stack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents tests for <see cref="LinkedListStack<T>"/>.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	[TestClass]
	public sealed class LinkedListStackTest : StackTestBase
	{
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestInitialize]
		public void SetUp()
		{
			this.stack = new LinkedListStack<int>();
		}
	}
}