using Business.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents tests for <see cref="LinkedListQueue<T>"/>.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	[TestClass]
	public sealed class LinkedListQueueTest : QueueTestBase
	{
		/// <summary>
		/// Setups this instance.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestInitialize]
		public void Setup()
		{
			this.queue = new LinkedListQueue<char>();
		}
	}
}