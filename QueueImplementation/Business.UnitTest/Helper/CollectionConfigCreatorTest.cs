using Business.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
		/// Collections the type of the configuration creator test initialize collection when call get custom collection of correct.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void CollectionConfigCreatorTest_InitializeCollection_WhenCall_GetCustomCollectionOfCorrectType()
		{
			var creator = new CollectionConfigCreator<int>();
		}
	}
}