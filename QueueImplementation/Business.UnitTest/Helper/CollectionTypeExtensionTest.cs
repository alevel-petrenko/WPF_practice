using Business.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents tests for <see cref="CollectionTypeExtension"/>.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	[TestClass]
	public class CollectionTypeExtensionTest
	{
		/// <summary>
		/// Tests the convertion of collection type to text.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="type">The collection type.</param>
		/// <param name="expectedTypeText">The collection type text.</param>
		[DataRow(CollectionType.Array, "array")]
		[DataRow(CollectionType.LinkedList, "linkedlist")]
		[TestMethod]
		public void CollectionTypeExtension_AsString_WhenCalled_GetCorrectTypeName(CollectionType type, string expectedTypeText)
		{
			//
			// Act.
			//
			var actualResult = type.AsString();

			//
			// Assert.
			//
			Assert.AreEqual(expectedTypeText, actualResult);
		}
	}
}